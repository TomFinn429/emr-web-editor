using System.Collections;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Text.Json.Serialization;
using System.Text.Json.Serialization.Metadata;
using System.Threading;
using System.Threading.Tasks;

namespace System.Text.Json;

[StructLayout((LayoutKind)3)]
internal struct WriteStack
{
	public WriteStackFrame Current;

	private WriteStackFrame[] _stack;

	private int _count;

	private int _continuationCount;

	private byte _indexOffset;

	public CancellationToken CancellationToken;

	public bool SuppressFlush;

	public Task PendingTask;

	public List<IAsyncDisposable> CompletedAsyncDisposables;

	public int FlushThreshold;

	public bool IsPolymorphicRootValue;

	public ReferenceResolver ReferenceResolver;

	public bool SupportContinuation;

	public bool SupportAsync;

	public string NewReferenceId;

	public object PolymorphicTypeDiscriminator;

	public int CurrentDepth => _count;

	public ref WriteStackFrame Parent => ref _stack[_count - _indexOffset - 1];

	public bool IsContinuation => _continuationCount != 0;

	public bool CurrentContainsMetadata
	{
		get
		{
			if (NewReferenceId == null)
			{
				return PolymorphicTypeDiscriminator != null;
			}
			return true;
		}
	}

	private void EnsurePushCapacity()
	{
		if (_stack == null)
		{
			_stack = new WriteStackFrame[4];
		}
		else if (_count - _indexOffset == _stack.Length)
		{
			Array.Resize(ref _stack, 2 * _stack.Length);
		}
	}

	internal void Initialize(JsonTypeInfo P_0, bool P_1 = false, bool P_2 = false)
	{
		Current.JsonTypeInfo = P_0;
		Current.JsonPropertyInfo = P_0.PropertyInfoForTypeInfo;
		Current.NumberHandling = Current.JsonPropertyInfo.EffectiveNumberHandling;
		SupportContinuation = P_1;
		SupportAsync = P_2;
		JsonSerializerOptions options = P_0.Options;
		if (options.ReferenceHandlingStrategy != ReferenceHandlingStrategy.None)
		{
			ReferenceResolver = options.ReferenceHandler.CreateResolver(true);
		}
	}

	public JsonTypeInfo PeekNestedJsonTypeInfo()
	{
		if (_count != 0)
		{
			return Current.JsonPropertyInfo.JsonTypeInfo;
		}
		return Current.JsonTypeInfo;
	}

	public void Push()
	{
		if (_continuationCount == 0)
		{
			if (_count == 0 && Current.PolymorphicSerializationState == PolymorphicSerializationState.None)
			{
				_count = 1;
				_indexOffset = 1;
				return;
			}
			JsonTypeInfo nestedJsonTypeInfo = Current.GetNestedJsonTypeInfo();
			JsonNumberHandling? numberHandling = Current.NumberHandling;
			EnsurePushCapacity();
			_stack[_count - _indexOffset] = Current;
			Current = default(WriteStackFrame);
			_count++;
			Current.JsonTypeInfo = nestedJsonTypeInfo;
			Current.JsonPropertyInfo = nestedJsonTypeInfo.PropertyInfoForTypeInfo;
			Current.NumberHandling = numberHandling ?? Current.JsonPropertyInfo.EffectiveNumberHandling;
		}
		else
		{
			if (_count++ > 0 || _indexOffset == 0)
			{
				Current = _stack[_count - _indexOffset];
			}
			if (_continuationCount == _count)
			{
				_continuationCount = 0;
			}
		}
	}

	public void Pop(bool P_0)
	{
		if (!P_0)
		{
			if (_continuationCount == 0)
			{
				if (_count == 1 && _indexOffset > 0)
				{
					_continuationCount = 1;
					_count = 0;
					return;
				}
				EnsurePushCapacity();
				_continuationCount = _count--;
			}
			else if (--_count == 0 && _indexOffset > 0)
			{
				return;
			}
			int num = _count - _indexOffset;
			_stack[num + 1] = Current;
			Current = _stack[num];
		}
		else if (--_count > 0 || _indexOffset == 0)
		{
			Current = _stack[_count - _indexOffset];
		}
	}

	public void AddCompletedAsyncDisposable(IAsyncDisposable P_0)
	{
		(CompletedAsyncDisposables ?? (CompletedAsyncDisposables = new List<IAsyncDisposable>())).Add(P_0);
	}

	public void DisposePendingDisposablesOnException()
	{
		Exception ex = null;
		DisposeFrame(Current.CollectionEnumerator, ref ex);
		int num = Math.Max(_count, _continuationCount);
		for (int i = 0; i < num - 1; i++)
		{
			DisposeFrame(_stack[i].CollectionEnumerator, ref ex);
		}
		if (ex != null)
		{
			ExceptionDispatchInfo.Capture(ex).Throw();
		}
		static void DisposeFrame(IEnumerator P_0, ref Exception P_1)
		{
			try
			{
				if (P_0 is IDisposable disposable)
				{
					disposable.Dispose();
				}
			}
			catch (Exception ex2)
			{
				P_1 = ex2;
			}
		}
	}

	public string PropertyPath()
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
		for (int i = 1; i <= item; i++)
		{
			AppendStackFrame(stringBuilder, ref _stack[i - _indexOffset]);
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
				if (P_1.IndexOfAny(ReadStack.SpecialCharacters) != -1)
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
		static void AppendStackFrame(StringBuilder P_0, ref WriteStackFrame P_1)
		{
			string text = P_1.JsonPropertyInfo?.MemberName ?? P_1.JsonPropertyNameAsString;
			AppendPropertyName(P_0, text);
		}
	}
}
