using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Text.Json.Reflection;

namespace System.Text.Json.Serialization.Metadata;

public abstract class JsonTypeInfo<T> : JsonTypeInfo
{
	private Action<Utf8JsonWriter, T> _serialize;

	private Func<T> _typedCreateObject;

	internal JsonConverter<T> EffectiveConverter { get; }

	[EditorBrowsable(EditorBrowsableState.Never)]
	public Action<Utf8JsonWriter, T>? SerializeHandler => _serialize;

	private protected override void SetCreateObject(Delegate P_0)
	{
		VerifyMutable();
		if (base.Kind == JsonTypeInfoKind.None)
		{
			ThrowHelper.ThrowInvalidOperationException_JsonTypeInfoOperationNotPossibleForKind(base.Kind);
		}
		if (!base.Converter.SupportsCreateObjectDelegate)
		{
			ThrowHelper.ThrowInvalidOperationException_CreateObjectConverterNotCompatible(base.Type);
		}
		Func<object> untypedCreateObject;
		Func<T> typedCreateObject;
		if (P_0 == null)
		{
			untypedCreateObject = null;
			typedCreateObject = null;
		}
		else
		{
			Func<T> typedDelegate = P_0 as Func<T>;
			if (typedDelegate != null)
			{
				typedCreateObject = typedDelegate;
				untypedCreateObject = ((P_0 is Func<object> func) ? func : ((Func<object>)(() => typedDelegate())));
			}
			else
			{
				untypedCreateObject = (Func<object>)P_0;
				typedCreateObject = () => (T)untypedCreateObject();
			}
		}
		_createObject = untypedCreateObject;
		_typedCreateObject = typedCreateObject;
	}

	private protected void SetCreateObjectIfCompatible(Delegate P_0)
	{
		if (base.Converter.SupportsCreateObjectDelegate && !base.Converter.ConstructorIsParameterized)
		{
			SetCreateObject(P_0);
		}
	}

	internal JsonTypeInfo(JsonConverter P_0, JsonSerializerOptions P_1)
		: base(typeof(T), P_0, P_1)
	{
		EffectiveConverter = P_0.CreateCastingConverter<T>();
	}

	private protected override JsonPropertyInfo CreatePropertyInfoForTypeInfo()
	{
		return new JsonPropertyInfo<T>(typeof(T), null, base.Options)
		{
			JsonTypeInfo = this,
			IsForTypeInfo = true
		};
	}

	private protected override JsonPropertyInfo CreateJsonPropertyInfo(JsonTypeInfo P_0, JsonSerializerOptions P_1)
	{
		return new JsonPropertyInfo<T>(P_0.Type, P_0, P_1)
		{
			JsonTypeInfo = this
		};
	}

	private protected void PopulatePolymorphismMetadata()
	{
		JsonPolymorphismOptions jsonPolymorphismOptions = JsonPolymorphismOptions.CreateFromAttributeDeclarations(base.Type);
		if (jsonPolymorphismOptions != null)
		{
			jsonPolymorphismOptions.DeclaringTypeInfo = this;
			_polymorphismOptions = jsonPolymorphismOptions;
		}
	}

	private protected void MapInterfaceTypesToCallbacks()
	{
		if (base.Kind != JsonTypeInfoKind.Object)
		{
			return;
		}
		if (typeof(IJsonOnSerializing).IsAssignableFrom(typeof(T)))
		{
			base.OnSerializing = delegate(object P_0)
			{
				((IJsonOnSerializing)P_0).OnSerializing();
			};
		}
		if (typeof(IJsonOnSerialized).IsAssignableFrom(typeof(T)))
		{
			base.OnSerialized = delegate(object P_0)
			{
				((IJsonOnSerialized)P_0).OnSerialized();
			};
		}
		if (typeof(IJsonOnDeserializing).IsAssignableFrom(typeof(T)))
		{
			base.OnDeserializing = delegate(object P_0)
			{
				((IJsonOnDeserializing)P_0).OnDeserializing();
			};
		}
		if (typeof(IJsonOnDeserialized).IsAssignableFrom(typeof(T)))
		{
			base.OnDeserialized = delegate(object P_0)
			{
				((IJsonOnDeserialized)P_0).OnDeserialized();
			};
		}
	}
}
public abstract class JsonTypeInfo
{
	internal delegate T ParameterizedConstructorDelegate<T, TArg0, TArg1, TArg2, TArg3>(TArg0 P_0, TArg1 P_1, TArg2 P_2, TArg3 P_3);

	private sealed class ParameterLookupKey
	{
		public string Name { get; }

		public Type Type { get; }

		public ParameterLookupKey(string P_0, Type P_1)
		{
			Name = P_0;
			Type = P_1;
		}

		public override int GetHashCode()
		{
			return StringComparer.OrdinalIgnoreCase.GetHashCode(Name);
		}

		public override bool Equals([NotNullWhen(true)] object P_0)
		{
			ParameterLookupKey parameterLookupKey = (ParameterLookupKey)P_0;
			if (Type == parameterLookupKey.Type)
			{
				return string.Equals(Name, parameterLookupKey.Name, StringComparison.OrdinalIgnoreCase);
			}
			return false;
		}
	}

	private sealed class ParameterLookupValue
	{
		[CompilerGenerated]
		private string _003CDuplicateName_003Ek__BackingField;

		public string DuplicateName
		{
			[CompilerGenerated]
			get
			{
				return _003CDuplicateName_003Ek__BackingField;
			}
			[CompilerGenerated]
			set
			{
				_003CDuplicateName_003Ek__BackingField = text;
			}
		}

		public JsonPropertyInfo JsonPropertyInfo { get; }

		public ParameterLookupValue(JsonPropertyInfo P_0)
		{
			JsonPropertyInfo = P_0;
		}
	}

	private sealed class JsonPropertyInfoList : ConfigurationList<JsonPropertyInfo>
	{
		protected override bool IsImmutable
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				throw new NotSupportedException("Linked away");
			}
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected override void VerifyMutable()
		{
			throw new NotSupportedException("Linked away");
		}
	}

	internal static readonly Type ObjectType = typeof(object);

	[CompilerGenerated]
	private int _003CParameterCount_003Ek__BackingField;

	[CompilerGenerated]
	private JsonPropertyDictionary<JsonParameterInfo> _003CParameterCache_003Ek__BackingField;

	[CompilerGenerated]
	private JsonPropertyDictionary<JsonPropertyInfo> _003CPropertyCache_003Ek__BackingField;

	private volatile ParameterRef[] _parameterRefsSorted;

	private volatile PropertyRef[] _propertyRefsSorted;

	private JsonPropertyInfoList _properties;

	[CompilerGenerated]
	private int _003CNumberOfRequiredProperties_003Ek__BackingField;

	private Action<object> _onSerializing;

	private Action<object> _onSerialized;

	private Action<object> _onDeserializing;

	private Action<object> _onDeserialized;

	private protected Func<object> _createObject;

	[CompilerGenerated]
	private Func<object> _003CCreateObjectForExtensionDataProperty_003Ek__BackingField;

	[CompilerGenerated]
	private bool _003CIsReadOnly_003Ek__BackingField;

	private protected JsonPolymorphismOptions _polymorphismOptions;

	[CompilerGenerated]
	private object _003CCreateObjectWithArgs_003Ek__BackingField;

	[CompilerGenerated]
	private object _003CAddMethodDelegate_003Ek__BackingField;

	[CompilerGenerated]
	private JsonPropertyInfo _003CExtensionDataProperty_003Ek__BackingField;

	[CompilerGenerated]
	private PolymorphicTypeResolver _003CPolymorphicTypeResolver_003Ek__BackingField;

	private JsonTypeInfo _elementTypeInfo;

	[CompilerGenerated]
	private bool _003CCanUseSerializeHandler_003Ek__BackingField;

	private JsonTypeInfo _keyTypeInfo;

	[CompilerGenerated]
	private JsonTypeInfoKind _003CKind_003Ek__BackingField;

	private DefaultValueHolder _defaultValueHolder;

	private JsonNumberHandling? _numberHandling;

	private volatile bool _isConfigured;

	private readonly object _configureLock = new object();

	private ExceptionDispatchInfo _cachedConfigureError;

	internal int ParameterCount
	{
		[CompilerGenerated]
		get
		{
			return _003CParameterCount_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			_003CParameterCount_003Ek__BackingField = num;
		}
	}

	internal JsonPropertyDictionary<JsonParameterInfo>? ParameterCache
	{
		[CompilerGenerated]
		get
		{
			return _003CParameterCache_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			_003CParameterCache_003Ek__BackingField = jsonPropertyDictionary;
		}
	}

	internal JsonPropertyDictionary<JsonPropertyInfo>? PropertyCache
	{
		[CompilerGenerated]
		get
		{
			return _003CPropertyCache_003Ek__BackingField;
		}
		[CompilerGenerated]
		private protected set
		{
			_003CPropertyCache_003Ek__BackingField = jsonPropertyDictionary;
		}
	}

	internal int NumberOfRequiredProperties
	{
		[CompilerGenerated]
		get
		{
			return _003CNumberOfRequiredProperties_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			_003CNumberOfRequiredProperties_003Ek__BackingField = num;
		}
	}

	public Func<object>? CreateObject
	{
		get
		{
			return _createObject;
		}
		set
		{
			SetCreateObject(createObject);
		}
	}

	internal Func<object>? CreateObjectForExtensionDataProperty
	{
		[CompilerGenerated]
		get
		{
			return _003CCreateObjectForExtensionDataProperty_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			_003CCreateObjectForExtensionDataProperty_003Ek__BackingField = func;
		}
	}

	public Action<object>? OnSerializing
	{
		get
		{
			return _onSerializing;
		}
		set
		{
			VerifyMutable();
			if (Kind != JsonTypeInfoKind.Object)
			{
				ThrowHelper.ThrowInvalidOperationException_JsonTypeInfoOperationNotPossibleForKind(Kind);
			}
			_onSerializing = onSerializing;
		}
	}

	public Action<object>? OnSerialized
	{
		get
		{
			return _onSerialized;
		}
		set
		{
			VerifyMutable();
			if (Kind != JsonTypeInfoKind.Object)
			{
				ThrowHelper.ThrowInvalidOperationException_JsonTypeInfoOperationNotPossibleForKind(Kind);
			}
			_onSerialized = onSerialized;
		}
	}

	public Action<object>? OnDeserializing
	{
		get
		{
			return _onDeserializing;
		}
		set
		{
			VerifyMutable();
			if (Kind != JsonTypeInfoKind.Object)
			{
				ThrowHelper.ThrowInvalidOperationException_JsonTypeInfoOperationNotPossibleForKind(Kind);
			}
			_onDeserializing = onDeserializing;
		}
	}

	public Action<object>? OnDeserialized
	{
		get
		{
			return _onDeserialized;
		}
		set
		{
			VerifyMutable();
			if (Kind != JsonTypeInfoKind.Object)
			{
				ThrowHelper.ThrowInvalidOperationException_JsonTypeInfoOperationNotPossibleForKind(Kind);
			}
			_onDeserialized = onDeserialized;
		}
	}

	public JsonPolymorphismOptions? PolymorphismOptions => _polymorphismOptions;

	public bool IsReadOnly
	{
		[CompilerGenerated]
		get
		{
			return _003CIsReadOnly_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			_003CIsReadOnly_003Ek__BackingField = flag;
		}
	}

	internal object? CreateObjectWithArgs
	{
		[CompilerGenerated]
		get
		{
			return _003CCreateObjectWithArgs_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			_003CCreateObjectWithArgs_003Ek__BackingField = obj;
		}
	}

	internal object? AddMethodDelegate
	{
		[CompilerGenerated]
		get
		{
			return _003CAddMethodDelegate_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			_003CAddMethodDelegate_003Ek__BackingField = obj;
		}
	}

	internal JsonPropertyInfo? ExtensionDataProperty
	{
		[CompilerGenerated]
		get
		{
			return _003CExtensionDataProperty_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			_003CExtensionDataProperty_003Ek__BackingField = jsonPropertyInfo;
		}
	}

	internal PolymorphicTypeResolver? PolymorphicTypeResolver
	{
		[CompilerGenerated]
		get
		{
			return _003CPolymorphicTypeResolver_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			_003CPolymorphicTypeResolver_003Ek__BackingField = polymorphicTypeResolver;
		}
	}

	internal bool CanUseSerializeHandler
	{
		[CompilerGenerated]
		get
		{
			return _003CCanUseSerializeHandler_003Ek__BackingField;
		}
		[CompilerGenerated]
		private protected set
		{
			_003CCanUseSerializeHandler_003Ek__BackingField = flag;
		}
	}

	internal bool MetadataSerializationNotSupported { get; }

	internal JsonTypeInfo? ElementTypeInfo
	{
		get
		{
			if (_elementTypeInfo == null)
			{
				if (ElementType != null)
				{
					_elementTypeInfo = Options.GetTypeInfoInternal(ElementType);
				}
			}
			else
			{
				_elementTypeInfo.EnsureConfigured();
			}
			return _elementTypeInfo;
		}
	}

	internal Type? ElementType { get; }

	internal JsonTypeInfo? KeyTypeInfo
	{
		get
		{
			if (_keyTypeInfo == null)
			{
				if (KeyType != null)
				{
					_keyTypeInfo = Options.GetTypeInfoInternal(KeyType);
				}
			}
			else
			{
				_keyTypeInfo.EnsureConfigured();
			}
			return _keyTypeInfo;
		}
	}

	internal Type? KeyType { get; }

	public JsonSerializerOptions Options { get; }

	public Type Type { get; }

	public JsonConverter Converter { get; }

	public JsonTypeInfoKind Kind
	{
		[CompilerGenerated]
		get
		{
			return _003CKind_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			_003CKind_003Ek__BackingField = jsonTypeInfoKind;
		}
	}

	internal JsonPropertyInfo PropertyInfoForTypeInfo { get; }

	internal DefaultValueHolder DefaultValueHolder => _defaultValueHolder ?? (_defaultValueHolder = System.Text.Json.Serialization.Metadata.DefaultValueHolder.CreateHolder(Type));

	public JsonNumberHandling? NumberHandling
	{
		get
		{
			return _numberHandling;
		}
		set
		{
			VerifyMutable();
			_numberHandling = numberHandling;
		}
	}

	internal bool IsConfigured => _isConfigured;

	[RequiresDynamicCode("JSON serialization and deserialization might require types that cannot be statically analyzed and might need runtime code generation. Use System.Text.Json source generation for native AOT applications.")]
	[RequiresUnreferencedCode("JSON serialization and deserialization might require types that cannot be statically analyzed. Use the overload that takes a JsonTypeInfo or JsonSerializerContext, or make sure all of the required types are preserved.")]
	internal JsonPropertyInfo CreatePropertyUsingReflection(Type P_0)
	{
		if (Options.TryGetTypeInfoCached(P_0, out var jsonTypeInfo))
		{
			return jsonTypeInfo.CreateJsonPropertyInfo(this, Options);
		}
		Type type = typeof(JsonPropertyInfo<>).MakeGenericType(P_0);
		return (JsonPropertyInfo)type.CreateInstanceNoWrapExceptions(new Type[3]
		{
			typeof(Type),
			typeof(JsonTypeInfo),
			typeof(JsonSerializerOptions)
		}, new object[3] { Type, this, Options });
	}

	private protected abstract JsonPropertyInfo CreateJsonPropertyInfo(JsonTypeInfo P_0, JsonSerializerOptions P_1);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal JsonPropertyInfo GetProperty(ReadOnlySpan<byte> P_0, ref ReadStackFrame P_1, out byte[] P_2)
	{
		ValidateCanBeUsedForMetadataSerialization();
		ulong key = GetKey(P_0);
		PropertyRef[] propertyRefsSorted = _propertyRefsSorted;
		if (propertyRefsSorted != null)
		{
			int propertyIndex = P_1.PropertyIndex;
			int num = propertyRefsSorted.Length;
			int num2 = Math.Min(propertyIndex, num);
			int num3 = num2 - 1;
			while (true)
			{
				if (num2 < num)
				{
					PropertyRef propertyRef = propertyRefsSorted[num2];
					if (IsPropertyRefEqual(in propertyRef, P_0, key))
					{
						P_2 = propertyRef.NameFromJson;
						return propertyRef.Info;
					}
					num2++;
					if (num3 >= 0)
					{
						propertyRef = propertyRefsSorted[num3];
						if (IsPropertyRefEqual(in propertyRef, P_0, key))
						{
							P_2 = propertyRef.NameFromJson;
							return propertyRef.Info;
						}
						num3--;
					}
				}
				else
				{
					if (num3 < 0)
					{
						break;
					}
					PropertyRef propertyRef = propertyRefsSorted[num3];
					if (IsPropertyRefEqual(in propertyRef, P_0, key))
					{
						P_2 = propertyRef.NameFromJson;
						return propertyRef.Info;
					}
					num3--;
				}
			}
		}
		if (PropertyCache.TryGetValue(JsonHelpers.Utf8GetString(P_0), out JsonPropertyInfo s_missingProperty))
		{
			if (Options.PropertyNameCaseInsensitive)
			{
				if (P_0.SequenceEqual(s_missingProperty.NameAsUtf8Bytes))
				{
					P_2 = s_missingProperty.NameAsUtf8Bytes;
				}
				else
				{
					P_2 = P_0.ToArray();
				}
			}
			else
			{
				P_2 = s_missingProperty.NameAsUtf8Bytes;
			}
		}
		else
		{
			s_missingProperty = JsonPropertyInfo.s_missingProperty;
			P_2 = P_0.ToArray();
		}
		int num4 = 0;
		if (propertyRefsSorted != null)
		{
			num4 = propertyRefsSorted.Length;
		}
		if (num4 < 64)
		{
			if (P_1.PropertyRefCache != null)
			{
				num4 += P_1.PropertyRefCache.Count;
			}
			if (num4 < 64)
			{
				ref List<PropertyRef> propertyRefCache = ref P_1.PropertyRefCache;
				if (propertyRefCache == null)
				{
					propertyRefCache = new List<PropertyRef>();
				}
				PropertyRef propertyRef = new PropertyRef(key, s_missingProperty, P_2);
				P_1.PropertyRefCache.Add(propertyRef);
			}
		}
		return s_missingProperty;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal JsonParameterInfo GetParameter(ReadOnlySpan<byte> P_0, ref ReadStackFrame P_1, out byte[] P_2)
	{
		ulong key = GetKey(P_0);
		ParameterRef[] parameterRefsSorted = _parameterRefsSorted;
		if (parameterRefsSorted != null)
		{
			int parameterIndex = P_1.CtorArgumentState.ParameterIndex;
			int num = parameterRefsSorted.Length;
			int num2 = Math.Min(parameterIndex, num);
			int num3 = num2 - 1;
			while (true)
			{
				if (num2 < num)
				{
					ParameterRef parameterRef = parameterRefsSorted[num2];
					if (IsParameterRefEqual(in parameterRef, P_0, key))
					{
						P_2 = parameterRef.NameFromJson;
						return parameterRef.Info;
					}
					num2++;
					if (num3 >= 0)
					{
						parameterRef = parameterRefsSorted[num3];
						if (IsParameterRefEqual(in parameterRef, P_0, key))
						{
							P_2 = parameterRef.NameFromJson;
							return parameterRef.Info;
						}
						num3--;
					}
				}
				else
				{
					if (num3 < 0)
					{
						break;
					}
					ParameterRef parameterRef = parameterRefsSorted[num3];
					if (IsParameterRefEqual(in parameterRef, P_0, key))
					{
						P_2 = parameterRef.NameFromJson;
						return parameterRef.Info;
					}
					num3--;
				}
			}
		}
		if (ParameterCache.TryGetValue(JsonHelpers.Utf8GetString(P_0), out JsonParameterInfo jsonParameterInfo))
		{
			if (Options.PropertyNameCaseInsensitive)
			{
				if (P_0.SequenceEqual(jsonParameterInfo.NameAsUtf8Bytes))
				{
					P_2 = jsonParameterInfo.NameAsUtf8Bytes;
				}
				else
				{
					P_2 = P_0.ToArray();
				}
			}
			else
			{
				P_2 = jsonParameterInfo.NameAsUtf8Bytes;
			}
		}
		else
		{
			P_2 = P_0.ToArray();
		}
		int num4 = 0;
		if (parameterRefsSorted != null)
		{
			num4 = parameterRefsSorted.Length;
		}
		if (num4 < 32)
		{
			if (P_1.CtorArgumentState.ParameterRefCache != null)
			{
				num4 += P_1.CtorArgumentState.ParameterRefCache.Count;
			}
			if (num4 < 32)
			{
				ArgumentState ctorArgumentState = P_1.CtorArgumentState;
				if (ctorArgumentState.ParameterRefCache == null)
				{
					ctorArgumentState.ParameterRefCache = new List<ParameterRef>();
				}
				ParameterRef parameterRef = new ParameterRef(key, jsonParameterInfo, P_2);
				P_1.CtorArgumentState.ParameterRefCache.Add(parameterRef);
			}
		}
		return jsonParameterInfo;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static bool IsPropertyRefEqual(in PropertyRef P_0, ReadOnlySpan<byte> P_1, ulong P_2)
	{
		if (P_2 == P_0.Key && (P_1.Length <= 7 || P_1.SequenceEqual(P_0.NameFromJson)))
		{
			return true;
		}
		return false;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static bool IsParameterRefEqual(in ParameterRef P_0, ReadOnlySpan<byte> P_1, ulong P_2)
	{
		if (P_2 == P_0.Key && (P_1.Length <= 7 || P_1.SequenceEqual(P_0.NameFromJson)))
		{
			return true;
		}
		return false;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal static ulong GetKey(ReadOnlySpan<byte> P_0)
	{
		ref byte reference = ref MemoryMarshal.GetReference(P_0);
		int length = P_0.Length;
		ulong num;
		if (length > 7)
		{
			num = Unsafe.ReadUnaligned<ulong>(ref reference) & 0xFFFFFFFFFFFFFFL;
			num |= (ulong)((long)Math.Min(length, 255) << 56);
		}
		else
		{
			num = ((length > 5) ? (Unsafe.ReadUnaligned<uint>(ref reference) | ((ulong)Unsafe.ReadUnaligned<ushort>(ref Unsafe.Add(ref reference, 4)) << 32)) : ((length > 3) ? ((ulong)Unsafe.ReadUnaligned<uint>(ref reference)) : ((ulong)((length > 1) ? Unsafe.ReadUnaligned<ushort>(ref reference) : 0))));
			num |= (ulong)((long)length << 56);
			if ((length & 1) != 0)
			{
				int num2 = length - 1;
				num |= (ulong)Unsafe.Add(ref reference, num2) << num2 * 8;
			}
		}
		return num;
	}

	internal void UpdateSortedPropertyCache(ref ReadStackFrame P_0)
	{
		List<PropertyRef> propertyRefCache = P_0.PropertyRefCache;
		if (_propertyRefsSorted != null)
		{
			List<PropertyRef> list = new List<PropertyRef>(_propertyRefsSorted);
			while (list.Count + propertyRefCache.Count > 64)
			{
				propertyRefCache.RemoveAt(propertyRefCache.Count - 1);
			}
			list.AddRange(propertyRefCache);
			_propertyRefsSorted = list.ToArray();
		}
		else
		{
			_propertyRefsSorted = propertyRefCache.ToArray();
		}
		P_0.PropertyRefCache = null;
	}

	internal void UpdateSortedParameterCache(ref ReadStackFrame P_0)
	{
		List<ParameterRef> parameterRefCache = P_0.CtorArgumentState.ParameterRefCache;
		if (_parameterRefsSorted != null)
		{
			List<ParameterRef> list = new List<ParameterRef>(_parameterRefsSorted);
			while (list.Count + parameterRefCache.Count > 32)
			{
				parameterRefCache.RemoveAt(parameterRefCache.Count - 1);
			}
			list.AddRange(parameterRefCache);
			_parameterRefsSorted = list.ToArray();
		}
		else
		{
			_parameterRefsSorted = parameterRefCache.ToArray();
		}
		P_0.CtorArgumentState.ParameterRefCache = null;
	}

	private protected abstract void SetCreateObject(Delegate P_0);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal void ValidateCanBeUsedForMetadataSerialization()
	{
		if (MetadataSerializationNotSupported)
		{
			ThrowHelper.ThrowInvalidOperationException_NoMetadataForTypeProperties(Options.TypeInfoResolver, Type);
		}
	}

	private protected abstract JsonPropertyInfo CreatePropertyInfoForTypeInfo();

	internal JsonTypeInfo(Type P_0, JsonConverter P_1, JsonSerializerOptions P_2)
	{
		Type = P_0;
		Options = P_2;
		Converter = P_1;
		PropertyInfoForTypeInfo = CreatePropertyInfoForTypeInfo();
		ElementType = P_1.ElementType;
		ConverterStrategy converterStrategy = PropertyInfoForTypeInfo.ConverterStrategy;
		if (converterStrategy <= ConverterStrategy.Value)
		{
			if (converterStrategy != ConverterStrategy.None)
			{
				if (converterStrategy - 1 > ConverterStrategy.Object)
				{
					goto IL_0078;
				}
			}
			else
			{
				ThrowHelper.ThrowNotSupportedException_SerializationNotSupported(P_0);
			}
		}
		else if (converterStrategy != ConverterStrategy.Enumerable)
		{
			if (converterStrategy != ConverterStrategy.Dictionary)
			{
				goto IL_0078;
			}
			KeyType = P_1.KeyType;
		}
		Kind = GetTypeInfoKind(P_0, PropertyInfoForTypeInfo.ConverterStrategy);
		return;
		IL_0078:
		throw new InvalidOperationException();
	}

	internal void VerifyMutable()
	{
		if (IsReadOnly)
		{
			ThrowHelper.ThrowInvalidOperationException_TypeInfoImmutable();
		}
	}

	internal void EnsureConfigured()
	{
		if (!_isConfigured)
		{
			ConfigureLocked();
		}
		void ConfigureLocked()
		{
			_cachedConfigureError?.Throw();
			lock (_configureLock)
			{
				if (_isConfigured)
				{
					return;
				}
				_cachedConfigureError?.Throw();
				try
				{
					Configure();
					IsReadOnly = true;
					_isConfigured = true;
				}
				catch (Exception ex)
				{
					_cachedConfigureError = ExceptionDispatchInfo.Capture(ex);
					throw;
				}
			}
		}
	}

	internal void Configure()
	{
		if (!Options.IsImmutable)
		{
			Options.InitializeForMetadataGeneration();
		}
		PropertyInfoForTypeInfo.EnsureChildOf(this);
		PropertyInfoForTypeInfo.EnsureConfigured();
		CanUseSerializeHandler &= Options.SerializerContext?.CanUseSerializationLogic ?? false;
		JsonConverter converter = Converter;
		if (Kind == JsonTypeInfoKind.Object)
		{
			InitializePropertyCache();
			if (converter.ConstructorIsParameterized)
			{
				InitializeConstructorParameters(GetParameterInfoValues(), Options.SerializerContext != null);
			}
		}
		if (PolymorphismOptions != null)
		{
			PolymorphicTypeResolver = new PolymorphicTypeResolver(this);
		}
	}

	internal virtual void LateAddProperties()
	{
	}

	internal abstract JsonParameterInfoValues[] GetParameterInfoValues();

	internal void CacheMember(JsonPropertyInfo P_0, JsonPropertyDictionary<JsonPropertyInfo> P_1, ref Dictionary<string, JsonPropertyInfo> P_2)
	{
		string memberName = P_0.MemberName;
		P_0.EnsureChildOf(this);
		if (P_0.IsExtensionData)
		{
			if (ExtensionDataProperty != null)
			{
				ThrowHelper.ThrowInvalidOperationException_SerializationDuplicateTypeAttribute(Type, typeof(JsonExtensionDataAttribute));
			}
			ExtensionDataProperty = P_0;
			return;
		}
		if (!P_1.TryAdd(P_0.Name, P_0))
		{
			JsonPropertyInfo jsonPropertyInfo = P_1[P_0.Name];
			if (jsonPropertyInfo.IsIgnored)
			{
				P_1[P_0.Name] = P_0;
			}
			else if (!P_0.IsIgnored && jsonPropertyInfo.MemberName != memberName)
			{
				Dictionary<string, JsonPropertyInfo> obj = P_2;
				if (obj == null || !obj.ContainsKey(memberName))
				{
					ThrowHelper.ThrowInvalidOperationException_SerializerPropertyNameConflict(Type, P_0.Name);
				}
			}
		}
		if (P_0.IsIgnored)
		{
			(P_2 ?? (P_2 = new Dictionary<string, JsonPropertyInfo>())).Add(memberName, P_0);
		}
	}

	internal void InitializePropertyCache()
	{
		if (_properties != null)
		{
			ExtensionDataProperty = null;
			if (PropertyCache == null)
			{
				PropertyCache = CreatePropertyCache(_properties.Count);
			}
			else
			{
				PropertyCache.Clear();
			}
			bool flag = false;
			foreach (JsonPropertyInfo property in _properties)
			{
				if (property.IsExtensionData)
				{
					if (ExtensionDataProperty != null)
					{
						ThrowHelper.ThrowInvalidOperationException_SerializationDuplicateTypeAttribute(Type, typeof(JsonExtensionDataAttribute));
					}
					ExtensionDataProperty = property;
				}
				else
				{
					if (!PropertyCache.TryAddValue(property.Name, property))
					{
						ThrowHelper.ThrowInvalidOperationException_SerializerPropertyNameConflict(Type, property.Name);
					}
					flag |= property.Order != 0;
				}
			}
			if (flag)
			{
				PropertyCache.List.StableSortByKey<KeyValuePair<string, JsonPropertyInfo>, int>((KeyValuePair<string, JsonPropertyInfo> P_0) => P_0.Value.Order);
			}
		}
		else
		{
			LateAddProperties();
			if (PropertyCache == null)
			{
				JsonPropertyDictionary<JsonPropertyInfo> jsonPropertyDictionary = (PropertyCache = CreatePropertyCache(0));
			}
		}
		if (ExtensionDataProperty != null)
		{
			ExtensionDataProperty.EnsureChildOf(this);
			ExtensionDataProperty.EnsureConfigured();
		}
		int numberOfRequiredProperties = 0;
		foreach (KeyValuePair<string, JsonPropertyInfo> item in PropertyCache.List)
		{
			JsonPropertyInfo value = item.Value;
			if (value.IsRequired)
			{
				value.RequiredPropertyIndex = numberOfRequiredProperties++;
			}
			value.EnsureChildOf(this);
			value.EnsureConfigured();
		}
		NumberOfRequiredProperties = numberOfRequiredProperties;
	}

	internal void InitializeConstructorParameters(JsonParameterInfoValues[] P_0, bool P_1 = false)
	{
		JsonPropertyDictionary<JsonParameterInfo> jsonPropertyDictionary = new JsonPropertyDictionary<JsonParameterInfo>(Options.PropertyNameCaseInsensitive, P_0.Length);
		Dictionary<ParameterLookupKey, ParameterLookupValue> dictionary = new Dictionary<ParameterLookupKey, ParameterLookupValue>(PropertyCache.Count);
		foreach (KeyValuePair<string, JsonPropertyInfo> item in PropertyCache.List)
		{
			JsonPropertyInfo value = item.Value;
			string text = value.MemberName ?? value.Name;
			ParameterLookupKey parameterLookupKey = new ParameterLookupKey(text, value.PropertyType);
			if (!dictionary.TryAdd(in parameterLookupKey, new ParameterLookupValue(value)))
			{
				ParameterLookupValue parameterLookupValue = dictionary[parameterLookupKey];
				parameterLookupValue.DuplicateName = text;
			}
		}
		foreach (JsonParameterInfoValues jsonParameterInfoValues in P_0)
		{
			ParameterLookupKey parameterLookupKey2 = new ParameterLookupKey(jsonParameterInfoValues.Name, jsonParameterInfoValues.ParameterType);
			if (dictionary.TryGetValue(parameterLookupKey2, out var parameterLookupValue2))
			{
				if (parameterLookupValue2.DuplicateName != null)
				{
					ThrowHelper.ThrowInvalidOperationException_MultiplePropertiesBindToConstructorParameters(Type, jsonParameterInfoValues.Name, parameterLookupValue2.JsonPropertyInfo.Name, parameterLookupValue2.DuplicateName);
				}
				JsonPropertyInfo jsonPropertyInfo = parameterLookupValue2.JsonPropertyInfo;
				JsonParameterInfo jsonParameterInfo = CreateConstructorParameter(jsonParameterInfoValues, jsonPropertyInfo, P_1, Options);
				jsonPropertyDictionary.Add(jsonPropertyInfo.Name, jsonParameterInfo);
			}
			else if (ExtensionDataProperty != null && StringComparer.OrdinalIgnoreCase.Equals(parameterLookupKey2.Name, ExtensionDataProperty.Name))
			{
				ThrowHelper.ThrowInvalidOperationException_ExtensionDataCannotBindToCtorParam(ExtensionDataProperty.MemberName, ExtensionDataProperty);
			}
		}
		ParameterCount = P_0.Length;
		ParameterCache = jsonPropertyDictionary;
	}

	internal static void ValidateType(Type P_0)
	{
		if (IsInvalidForSerialization(P_0))
		{
			ThrowHelper.ThrowInvalidOperationException_CannotSerializeInvalidType(P_0, null, null);
		}
	}

	internal static bool IsInvalidForSerialization(Type P_0)
	{
		if (!(P_0 == typeof(void)) && !P_0.IsPointer && !P_0.IsByRef && !IsByRefLike(P_0))
		{
			return P_0.ContainsGenericParameters;
		}
		return true;
	}

	private static bool IsByRefLike(Type P_0)
	{
		return P_0.IsByRefLike;
	}

	internal static bool IsValidExtensionDataProperty(Type P_0)
	{
		if (!typeof(IDictionary<string, object>).IsAssignableFrom(P_0) && !typeof(IDictionary<string, JsonElement>).IsAssignableFrom(P_0))
		{
			if (P_0.FullName == "System.Text.Json.Nodes.JsonObject")
			{
				return (object)P_0.Assembly == typeof(JsonTypeInfo).Assembly;
			}
			return false;
		}
		return true;
	}

	internal JsonPropertyDictionary<JsonPropertyInfo> CreatePropertyCache(int P_0)
	{
		return new JsonPropertyDictionary<JsonPropertyInfo>(Options.PropertyNameCaseInsensitive, P_0);
	}

	private static JsonParameterInfo CreateConstructorParameter(JsonParameterInfoValues P_0, JsonPropertyInfo P_1, bool P_2, JsonSerializerOptions P_3)
	{
		if (P_1.IsIgnored)
		{
			return JsonParameterInfo.CreateIgnoredParameterPlaceholder(P_0, P_1, P_2);
		}
		JsonConverter effectiveConverter = P_1.EffectiveConverter;
		JsonParameterInfo jsonParameterInfo = effectiveConverter.CreateJsonParameterInfo();
		jsonParameterInfo.Initialize(P_0, P_1, P_3);
		return jsonParameterInfo;
	}

	private static JsonTypeInfoKind GetTypeInfoKind(Type P_0, ConverterStrategy P_1)
	{
		if (P_0 == typeof(object))
		{
			return JsonTypeInfoKind.None;
		}
		return P_1 switch
		{
			ConverterStrategy.Object => JsonTypeInfoKind.Object, 
			ConverterStrategy.Enumerable => JsonTypeInfoKind.Enumerable, 
			ConverterStrategy.Dictionary => JsonTypeInfoKind.Dictionary, 
			_ => JsonTypeInfoKind.None, 
		};
	}
}
