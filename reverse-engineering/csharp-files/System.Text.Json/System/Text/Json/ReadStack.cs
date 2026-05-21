using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text.Json.Serialization;
using System.Text.Json.Serialization.Metadata;

namespace System.Text.Json;

[StructLayout((LayoutKind)3)]
internal struct ReadStack
{
	internal static readonly char[] SpecialCharacters = new char[18]
	{
		'.', ' ', '\'', '/', '"', '[', ']', '(', ')', '\t',
		'\n', '\r', '\f', '\b', '\\', '\u0085', '\u2028', '\u2029'
	};

	public ReadStackFrame Current;

	private ReadStackFrame[] _stack;

	private int _count;

	private int _continuationCount;

	private List<ArgumentState> _ctorArgStateCache;

	public long BytesConsumed;

	public bool ReadAhead;

	public ReferenceResolver ReferenceResolver;

	public bool SupportContinuation;

	public string ReferenceId;

	public object PolymorphicTypeDiscriminator;

	public bool PreserveReferences;

	public bool IsContinuation => _continuationCount != 0;

	private void EnsurePushCapacity()
	{
		if (_stack == null)
		{
			_stack = new ReadStackFrame[4];
		}
		else if (_count - 1 == _stack.Length)
		{
			Array.Resize(ref _stack, 2 * _stack.Length);
		}
	}

	internal void Initialize(JsonTypeInfo P_0, bool P_1 = false)
	{
		JsonSerializerOptions options = P_0.Options;
		if (options.ReferenceHandlingStrategy == ReferenceHandlingStrategy.Preserve)
		{
			ReferenceResolver = options.ReferenceHandler.CreateResolver(false);
			PreserveReferences = true;
		}
		Current.JsonTypeInfo = P_0;
		Current.JsonPropertyInfo = P_0.PropertyInfoForTypeInfo;
		Current.NumberHandling = Current.JsonPropertyInfo.EffectiveNumberHandling;
		Current.CanContainMetadata = PreserveReferences || (P_0.PolymorphicTypeResolver?.UsesTypeDiscriminators ?? false);
		SupportContinuation = P_1;
	}

	public void Push()
	{
		if (_continuationCount == 0)
		{
			if (_count == 0)
			{
				_count = 1;
			}
			else
			{
				JsonTypeInfo jsonTypeInfo = Current.JsonPropertyInfo?.JsonTypeInfo ?? Current.CtorArgumentState.JsonParameterInfo.JsonTypeInfo;
				JsonNumberHandling? numberHandling = Current.NumberHandling;
				EnsurePushCapacity();
				_stack[_count - 1] = Current;
				Current = default(ReadStackFrame);
				_count++;
				Current.JsonTypeInfo = jsonTypeInfo;
				Current.JsonPropertyInfo = jsonTypeInfo.PropertyInfoForTypeInfo;
				Current.NumberHandling = numberHandling ?? Current.JsonPropertyInfo.EffectiveNumberHandling;
				Current.CanContainMetadata = PreserveReferences || (jsonTypeInfo.PolymorphicTypeResolver?.UsesTypeDiscriminators ?? false);
			}
		}
		else
		{
			if (_count++ > 0)
			{
				_stack[_count - 2] = Current;
				Current = _stack[_count - 1];
			}
			if (_continuationCount == _count)
			{
				_continuationCount = 0;
			}
		}
		SetConstructorArgumentState();
	}

	public void Pop(bool P_0)
	{
		if (!P_0)
		{
			if (_continuationCount == 0)
			{
				if (_count == 1)
				{
					_continuationCount = 1;
					_count = 0;
					return;
				}
				EnsurePushCapacity();
				_continuationCount = _count--;
			}
			else if (--_count == 0)
			{
				return;
			}
			_stack[_count] = Current;
			Current = _stack[_count - 1];
		}
		else if (--_count > 0)
		{
			Current = _stack[_count - 1];
		}
		SetConstructorArgumentState();
	}

	public JsonConverter InitializePolymorphicReEntry(JsonTypeInfo P_0)
	{
		Current.PolymorphicJsonTypeInfo = Current.JsonTypeInfo;
		Current.JsonTypeInfo = P_0.PropertyInfoForTypeInfo.JsonTypeInfo;
		Current.JsonPropertyInfo = Current.JsonTypeInfo.PropertyInfoForTypeInfo;
		ref JsonNumberHandling? numberHandling = ref Current.NumberHandling;
		JsonNumberHandling? jsonNumberHandling = numberHandling;
		if (!jsonNumberHandling.HasValue)
		{
			numberHandling = Current.JsonPropertyInfo.NumberHandling;
		}
		Current.PolymorphicSerializationState = PolymorphicSerializationState.PolymorphicReEntryStarted;
		SetConstructorArgumentState();
		return P_0.Converter;
	}

	public JsonConverter ResumePolymorphicReEntry()
	{
		ref JsonTypeInfo jsonTypeInfo = ref Current.JsonTypeInfo;
		ref JsonTypeInfo polymorphicJsonTypeInfo = ref Current.PolymorphicJsonTypeInfo;
		JsonTypeInfo polymorphicJsonTypeInfo2 = Current.PolymorphicJsonTypeInfo;
		JsonTypeInfo jsonTypeInfo2 = Current.JsonTypeInfo;
		jsonTypeInfo = polymorphicJsonTypeInfo2;
		polymorphicJsonTypeInfo = jsonTypeInfo2;
		Current.PolymorphicSerializationState = PolymorphicSerializationState.PolymorphicReEntryStarted;
		return Current.JsonTypeInfo.Converter;
	}

	public void ExitPolymorphicConverter(bool P_0)
	{
		ref JsonTypeInfo jsonTypeInfo = ref Current.JsonTypeInfo;
		ref JsonTypeInfo polymorphicJsonTypeInfo = ref Current.PolymorphicJsonTypeInfo;
		JsonTypeInfo polymorphicJsonTypeInfo2 = Current.PolymorphicJsonTypeInfo;
		JsonTypeInfo jsonTypeInfo2 = Current.JsonTypeInfo;
		jsonTypeInfo = polymorphicJsonTypeInfo2;
		polymorphicJsonTypeInfo = jsonTypeInfo2;
		Current.PolymorphicSerializationState = ((!P_0) ? PolymorphicSerializationState.PolymorphicReEntrySuspended : PolymorphicSerializationState.None);
	}

	public string JsonPath()
	{
		StringBuilder stringBuilder = new StringBuilder("$");
		int continuationCount = _continuationCount;
		(int, bool) tuple = continuationCount switch
		{
			0 => (_count - 1, true), 
			1 => (0, true), 
			_ => (continuationCount, false), 
		};
		int item = tuple.Item1;
		bool item2 = tuple.Item2;
		for (int i = 0; i < item; i++)
		{
			AppendStackFrame(stringBuilder, ref _stack[i]);
		}
		if (item2)
		{
			AppendStackFrame(stringBuilder, ref Current);
		}
		return stringBuilder.ToString();
		static void AppendPropertyName(StringBuilder P_0, string P_1)
		{
			if (P_1 != null)
			{
				if (P_1.IndexOfAny(SpecialCharacters) != -1)
				{
					P_0.Append("['");
					P_0.Append(P_1);
					P_0.Append("']");
				}
				else
				{
					P_0.Append('.');
					P_0.Append(P_1);
				}
			}
		}
		static void AppendStackFrame(StringBuilder P_0, ref ReadStackFrame P_1)
		{
			string text = GetPropertyName(ref P_1);
			AppendPropertyName(P_0, text);
			if (P_1.JsonTypeInfo != null && P_1.IsProcessingEnumerable() && P_1.ReturnValue is IEnumerable enumerable && (P_1.ObjectState == StackFrameObjectState.None || P_1.ObjectState == StackFrameObjectState.CreatedObject || P_1.ObjectState == StackFrameObjectState.ReadElements))
			{
				P_0.Append('[');
				P_0.Append(GetCount(enumerable));
				P_0.Append(']');
			}
		}
		static int GetCount(IEnumerable P_0)
		{
			if (P_0 is ICollection collection)
			{
				return collection.Count;
			}
			int num = 0;
			IEnumerator enumerator = P_0.GetEnumerator();
			while (enumerator.MoveNext())
			{
				num++;
			}
			return num;
		}
		static string GetPropertyName(ref ReadStackFrame P_0)
		{
			string result = null;
			byte[] array = P_0.JsonPropertyName;
			if (array == null)
			{
				if (P_0.JsonPropertyNameAsString != null)
				{
					result = P_0.JsonPropertyNameAsString;
				}
				else
				{
					array = P_0.JsonPropertyInfo?.NameAsUtf8Bytes ?? P_0.CtorArgumentState?.JsonParameterInfo?.NameAsUtf8Bytes;
				}
			}
			if (array != null)
			{
				result = JsonHelpers.Utf8GetString(array);
			}
			return result;
		}
	}

	public JsonTypeInfo GetTopJsonTypeInfoWithParameterizedConstructor()
	{
		for (int i = 0; i < _count - 1; i++)
		{
			if (_stack[i].JsonTypeInfo.Converter.ConstructorIsParameterized)
			{
				return _stack[i].JsonTypeInfo;
			}
		}
		return Current.JsonTypeInfo;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void SetConstructorArgumentState()
	{
		if (!Current.JsonTypeInfo.Converter.ConstructorIsParameterized)
		{
			return;
		}
		if (Current.CtorArgumentStateIndex == 0)
		{
			if (_ctorArgStateCache == null)
			{
				_ctorArgStateCache = new List<ArgumentState>();
			}
			ArgumentState argumentState = new ArgumentState();
			_ctorArgStateCache.Add(argumentState);
			ref int ctorArgumentStateIndex = ref Current.CtorArgumentStateIndex;
			ref ArgumentState ctorArgumentState = ref Current.CtorArgumentState;
			int count = _ctorArgStateCache.Count;
			ArgumentState argumentState2 = argumentState;
			ctorArgumentStateIndex = count;
			ctorArgumentState = argumentState2;
		}
		else
		{
			Current.CtorArgumentState = _ctorArgStateCache[Current.CtorArgumentStateIndex - 1];
		}
	}
}
