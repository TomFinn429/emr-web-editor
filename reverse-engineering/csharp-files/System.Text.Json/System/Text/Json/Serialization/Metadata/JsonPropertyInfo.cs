using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text.Json.Reflection;

namespace System.Text.Json.Serialization.Metadata;

public abstract class JsonPropertyInfo
{
	internal static readonly JsonPropertyInfo s_missingProperty = GetPropertyPlaceholder();

	[CompilerGenerated]
	private JsonTypeInfo _003CParentTypeInfo_003Ek__BackingField;

	private JsonTypeInfo _jsonTypeInfo;

	[CompilerGenerated]
	private ConverterStrategy _003CConverterStrategy_003Ek__BackingField;

	private protected JsonConverter _effectiveConverter;

	private JsonConverter _customConverter;

	private protected Func<object, object> _untypedGet;

	private protected Action<object, object> _untypedSet;

	private bool _isUserSpecifiedSetter;

	private protected Func<object, object, bool> _shouldSerialize;

	private bool _isUserSpecifiedShouldSerialize;

	private JsonIgnoreCondition? _ignoreCondition;

	private ICustomAttributeProvider _attributeProvider;

	[CompilerGenerated]
	private string _003CMemberName_003Ek__BackingField;

	[CompilerGenerated]
	private MemberTypes _003CMemberType_003Ek__BackingField;

	[CompilerGenerated]
	private bool _003CIsVirtual_003Ek__BackingField;

	private bool _isExtensionDataProperty;

	private bool _isRequired;

	private volatile bool _isConfigured;

	[CompilerGenerated]
	private bool _003CIgnoreNullTokensOnRead_003Ek__BackingField;

	[CompilerGenerated]
	private bool _003CIgnoreDefaultValuesOnWrite_003Ek__BackingField;

	[CompilerGenerated]
	private bool _003CIsForTypeInfo_003Ek__BackingField;

	private string _name;

	[CompilerGenerated]
	private byte[] _003CNameAsUtf8Bytes_003Ek__BackingField;

	[CompilerGenerated]
	private byte[] _003CEscapedNameSection_003Ek__BackingField;

	private int _order;

	[CompilerGenerated]
	private bool _003CCanSerialize_003Ek__BackingField;

	[CompilerGenerated]
	private bool _003CCanDeserialize_003Ek__BackingField;

	[CompilerGenerated]
	private bool _003CSrcGen_HasJsonInclude_003Ek__BackingField;

	[CompilerGenerated]
	private bool _003CSrcGen_IsPublic_003Ek__BackingField;

	[CompilerGenerated]
	private JsonNumberHandling? _003CDeclaringTypeNumberHandling_003Ek__BackingField;

	private JsonNumberHandling? _numberHandling;

	[CompilerGenerated]
	private JsonNumberHandling? _003CEffectiveNumberHandling_003Ek__BackingField;

	private int _index;

	internal JsonTypeInfo? ParentTypeInfo
	{
		[CompilerGenerated]
		get
		{
			return _003CParentTypeInfo_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			_003CParentTypeInfo_003Ek__BackingField = jsonTypeInfo;
		}
	}

	internal ConverterStrategy ConverterStrategy
	{
		[CompilerGenerated]
		get
		{
			return _003CConverterStrategy_003Ek__BackingField;
		}
		[CompilerGenerated]
		private protected set
		{
			_003CConverterStrategy_003Ek__BackingField = converterStrategy;
		}
	}

	internal JsonConverter EffectiveConverter => _effectiveConverter;

	public JsonConverter? CustomConverter
	{
		get
		{
			return _customConverter;
		}
		set
		{
			VerifyMutable();
			_customConverter = customConverter;
		}
	}

	public Func<object, object?>? Get => _untypedGet;

	public Action<object, object?>? Set => _untypedSet;

	public Func<object, object?, bool>? ShouldSerialize => _shouldSerialize;

	internal JsonIgnoreCondition? IgnoreCondition
	{
		set
		{
			ConfigureIgnoreCondition(jsonIgnoreCondition);
			_ignoreCondition = jsonIgnoreCondition;
		}
	}

	public ICustomAttributeProvider? AttributeProvider
	{
		set
		{
			VerifyMutable();
			_attributeProvider = attributeProvider;
		}
	}

	internal string? MemberName
	{
		[CompilerGenerated]
		get
		{
			return _003CMemberName_003Ek__BackingField;
		}
		[CompilerGenerated]
		private protected set
		{
			_003CMemberName_003Ek__BackingField = text;
		}
	}

	internal MemberTypes MemberType
	{
		[CompilerGenerated]
		get
		{
			return _003CMemberType_003Ek__BackingField;
		}
		[CompilerGenerated]
		private protected set
		{
			_003CMemberType_003Ek__BackingField = memberTypes;
		}
	}

	internal bool IsVirtual
	{
		[CompilerGenerated]
		get
		{
			return _003CIsVirtual_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			_003CIsVirtual_003Ek__BackingField = flag;
		}
	}

	public bool IsExtensionData
	{
		get
		{
			return _isExtensionDataProperty;
		}
		set
		{
			VerifyMutable();
			if (flag && !System.Text.Json.Serialization.Metadata.JsonTypeInfo.IsValidExtensionDataProperty(PropertyType))
			{
				ThrowHelper.ThrowInvalidOperationException_SerializationDataExtensionPropertyInvalid(this);
			}
			_isExtensionDataProperty = flag;
		}
	}

	public bool IsRequired
	{
		get
		{
			return _isRequired;
		}
		set
		{
			VerifyMutable();
			_isRequired = isRequired;
		}
	}

	public Type PropertyType { get; }

	internal bool HasGetter => _untypedGet != null;

	internal bool HasSetter => _untypedSet != null;

	internal bool IgnoreNullTokensOnRead
	{
		[CompilerGenerated]
		get
		{
			return _003CIgnoreNullTokensOnRead_003Ek__BackingField;
		}
		[CompilerGenerated]
		private protected set
		{
			_003CIgnoreNullTokensOnRead_003Ek__BackingField = flag;
		}
	}

	internal bool IgnoreDefaultValuesOnWrite
	{
		[CompilerGenerated]
		get
		{
			return _003CIgnoreDefaultValuesOnWrite_003Ek__BackingField;
		}
		[CompilerGenerated]
		private protected set
		{
			_003CIgnoreDefaultValuesOnWrite_003Ek__BackingField = flag;
		}
	}

	internal bool IgnoreReadOnlyMember => MemberType switch
	{
		MemberTypes.Property => Options.IgnoreReadOnlyProperties, 
		MemberTypes.Field => Options.IgnoreReadOnlyFields, 
		_ => false, 
	};

	internal bool IsForTypeInfo
	{
		[CompilerGenerated]
		get
		{
			return _003CIsForTypeInfo_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			_003CIsForTypeInfo_003Ek__BackingField = flag;
		}
	}

	public string Name
	{
		get
		{
			return _name;
		}
		set
		{
			VerifyMutable();
			if (text == null)
			{
				ThrowHelper.ThrowArgumentNullException("value");
			}
			_name = text;
		}
	}

	internal byte[] NameAsUtf8Bytes
	{
		[CompilerGenerated]
		get
		{
			return _003CNameAsUtf8Bytes_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			_003CNameAsUtf8Bytes_003Ek__BackingField = array;
		}
	}

	internal byte[] EscapedNameSection
	{
		[CompilerGenerated]
		get
		{
			return _003CEscapedNameSection_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			_003CEscapedNameSection_003Ek__BackingField = array;
		}
	}

	public JsonSerializerOptions Options { get; }

	public int Order
	{
		get
		{
			return _order;
		}
		set
		{
			VerifyMutable();
			_order = order;
		}
	}

	internal Type DeclaringType { get; }

	internal JsonTypeInfo JsonTypeInfo
	{
		get
		{
			_jsonTypeInfo.EnsureConfigured();
			return _jsonTypeInfo;
		}
		[param: AllowNull]
		set
		{
			ConverterStrategy = jsonTypeInfo?.Converter.ConverterStrategy ?? ConverterStrategy.None;
			_jsonTypeInfo = jsonTypeInfo;
		}
	}

	internal bool IsIgnored => _ignoreCondition == JsonIgnoreCondition.Always;

	internal bool CanSerialize
	{
		[CompilerGenerated]
		get
		{
			return _003CCanSerialize_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			_003CCanSerialize_003Ek__BackingField = flag;
		}
	}

	internal bool CanDeserialize
	{
		[CompilerGenerated]
		get
		{
			return _003CCanDeserialize_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			_003CCanDeserialize_003Ek__BackingField = flag;
		}
	}

	internal bool SrcGen_HasJsonInclude
	{
		[CompilerGenerated]
		set
		{
			_003CSrcGen_HasJsonInclude_003Ek__BackingField = flag;
		}
	}

	internal bool SrcGen_IsPublic
	{
		[CompilerGenerated]
		set
		{
			_003CSrcGen_IsPublic_003Ek__BackingField = flag;
		}
	}

	internal JsonNumberHandling? DeclaringTypeNumberHandling
	{
		[CompilerGenerated]
		get
		{
			return _003CDeclaringTypeNumberHandling_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			_003CDeclaringTypeNumberHandling_003Ek__BackingField = jsonNumberHandling;
		}
	}

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

	internal JsonNumberHandling? EffectiveNumberHandling
	{
		[CompilerGenerated]
		get
		{
			return _003CEffectiveNumberHandling_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			_003CEffectiveNumberHandling_003Ek__BackingField = jsonNumberHandling;
		}
	}

	internal abstract bool PropertyTypeCanBeNull { get; }

	internal abstract object? DefaultValue { get; }

	internal int RequiredPropertyIndex
	{
		get
		{
			return _index;
		}
		set
		{
			_index = index;
		}
	}

	private protected abstract void SetGetter(Delegate P_0);

	private protected abstract void SetSetter(Delegate P_0);

	private protected abstract void SetShouldSerialize(Delegate P_0);

	private protected abstract void ConfigureIgnoreCondition(JsonIgnoreCondition? P_0);

	internal JsonPropertyInfo(Type P_0, Type P_1, JsonTypeInfo P_2, JsonSerializerOptions P_3)
	{
		DeclaringType = P_0;
		PropertyType = P_1;
		ParentTypeInfo = P_2;
		Options = P_3;
	}

	internal static JsonPropertyInfo GetPropertyPlaceholder()
	{
		JsonPropertyInfo jsonPropertyInfo = new JsonPropertyInfo<object>(typeof(object), null, null);
		jsonPropertyInfo.Name = string.Empty;
		return jsonPropertyInfo;
	}

	private protected void VerifyMutable()
	{
		JsonTypeInfo? parentTypeInfo = ParentTypeInfo;
		if (parentTypeInfo != null && parentTypeInfo.IsReadOnly)
		{
			ThrowHelper.ThrowInvalidOperationException_PropertyInfoImmutable();
		}
	}

	internal void EnsureConfigured()
	{
		if (!_isConfigured)
		{
			Configure();
			_isConfigured = true;
		}
	}

	internal void Configure()
	{
		DeclaringTypeNumberHandling = ParentTypeInfo.NumberHandling;
		if (!IsForTypeInfo)
		{
			CacheNameAsUtf8BytesAndEscapedNameSection();
		}
		if (_jsonTypeInfo == null)
		{
			_jsonTypeInfo = Options.GetTypeInfoInternal(PropertyType, false);
		}
		DetermineEffectiveConverter(_jsonTypeInfo);
		if (IsForTypeInfo)
		{
			DetermineNumberHandlingForTypeInfo();
		}
		else
		{
			DetermineNumberHandlingForProperty();
			DetermineIgnoreCondition();
			DetermineSerializationCapabilities();
		}
		if (IsRequired)
		{
			if (!CanDeserialize)
			{
				ThrowHelper.ThrowInvalidOperationException_JsonPropertyRequiredAndNotDeserializable(this);
			}
			if (IsExtensionData)
			{
				ThrowHelper.ThrowInvalidOperationException_JsonPropertyRequiredAndExtensionData(this);
			}
		}
	}

	private protected abstract void DetermineEffectiveConverter(JsonTypeInfo P_0);

	private protected abstract void DetermineMemberAccessors(MemberInfo P_0);

	private void DeterminePoliciesFromMember(MemberInfo P_0)
	{
		Order = P_0.GetCustomAttribute<JsonPropertyOrderAttribute>(false)?.Order ?? 0;
		NumberHandling = P_0.GetCustomAttribute<JsonNumberHandlingAttribute>(false)?.Handling;
	}

	private void DeterminePropertyNameFromMember(MemberInfo P_0)
	{
		JsonPropertyNameAttribute customAttribute = P_0.GetCustomAttribute<JsonPropertyNameAttribute>(false);
		string text = ((customAttribute != null) ? customAttribute.Name : ((Options.PropertyNamingPolicy == null) ? P_0.Name : Options.PropertyNamingPolicy.ConvertName(P_0.Name)));
		if (text == null)
		{
			ThrowHelper.ThrowInvalidOperationException_SerializerPropertyNameNull(this);
		}
		Name = text;
	}

	private void CacheNameAsUtf8BytesAndEscapedNameSection()
	{
		NameAsUtf8Bytes = Encoding.UTF8.GetBytes(Name);
		EscapedNameSection = JsonHelpers.GetEscapedPropertyNameSection(NameAsUtf8Bytes, Options.Encoder);
	}

	private void DetermineIgnoreCondition()
	{
		if (_ignoreCondition.HasValue)
		{
			return;
		}
		if (Options.IgnoreNullValues)
		{
			if (PropertyTypeCanBeNull)
			{
				IgnoreNullTokensOnRead = !_isUserSpecifiedSetter && !IsRequired;
				IgnoreDefaultValuesOnWrite = ShouldSerialize == null;
			}
		}
		else if (Options.DefaultIgnoreCondition == JsonIgnoreCondition.WhenWritingNull)
		{
			if (PropertyTypeCanBeNull)
			{
				IgnoreDefaultValuesOnWrite = ShouldSerialize == null;
			}
		}
		else if (Options.DefaultIgnoreCondition == JsonIgnoreCondition.WhenWritingDefault)
		{
			IgnoreDefaultValuesOnWrite = ShouldSerialize == null;
		}
	}

	private void DetermineSerializationCapabilities()
	{
		CanSerialize = HasGetter;
		CanDeserialize = HasSetter;
		if (MemberType == (MemberTypes)0 || _ignoreCondition.HasValue)
		{
			return;
		}
		if ((ConverterStrategy & (ConverterStrategy)24) != ConverterStrategy.None)
		{
			if (Get == null && Set != null && !_isUserSpecifiedSetter)
			{
				CanDeserialize = false;
			}
		}
		else if (Get != null && Set == null && IgnoreReadOnlyMember && !_isUserSpecifiedShouldSerialize)
		{
			CanSerialize = false;
		}
	}

	private void DetermineNumberHandlingForTypeInfo()
	{
		if (DeclaringTypeNumberHandling.HasValue && DeclaringTypeNumberHandling != JsonNumberHandling.Strict && !EffectiveConverter.IsInternalConverter)
		{
			ThrowHelper.ThrowInvalidOperationException_NumberHandlingOnPropertyInvalid(this);
		}
		if (NumberHandingIsApplicable())
		{
			EffectiveNumberHandling = DeclaringTypeNumberHandling;
			if (!EffectiveNumberHandling.HasValue && Options.NumberHandling != JsonNumberHandling.Strict)
			{
				EffectiveNumberHandling = Options.NumberHandling;
			}
		}
	}

	private void DetermineNumberHandlingForProperty()
	{
		if (NumberHandingIsApplicable())
		{
			JsonNumberHandling? effectiveNumberHandling = NumberHandling ?? DeclaringTypeNumberHandling ?? _jsonTypeInfo.NumberHandling;
			if (!effectiveNumberHandling.HasValue && Options.NumberHandling != JsonNumberHandling.Strict)
			{
				effectiveNumberHandling = Options.NumberHandling;
			}
			EffectiveNumberHandling = effectiveNumberHandling;
		}
		else if (NumberHandling.HasValue && NumberHandling != JsonNumberHandling.Strict)
		{
			ThrowHelper.ThrowInvalidOperationException_NumberHandlingOnPropertyInvalid(this);
		}
	}

	private bool NumberHandingIsApplicable()
	{
		if (EffectiveConverter.IsInternalConverterForNumberType)
		{
			return true;
		}
		Type type = ((EffectiveConverter.IsInternalConverter && ((ConverterStrategy)24 & ConverterStrategy) != ConverterStrategy.None) ? EffectiveConverter.ElementType : PropertyType);
		type = Nullable.GetUnderlyingType(type) ?? type;
		if (!(type == typeof(byte)) && !(type == typeof(decimal)) && !(type == typeof(double)) && !(type == typeof(short)) && !(type == typeof(int)) && !(type == typeof(long)) && !(type == typeof(sbyte)) && !(type == typeof(float)) && !(type == typeof(ushort)) && !(type == typeof(uint)) && !(type == typeof(ulong)))
		{
			return type == System.Text.Json.Serialization.Metadata.JsonTypeInfo.ObjectType;
		}
		return true;
	}

	private void DetermineIsRequired(MemberInfo P_0, bool P_1)
	{
		IsRequired = P_0.GetCustomAttribute<JsonRequiredAttribute>(false) != null || (P_1 && P_0.HasRequiredMemberAttribute());
	}

	internal abstract bool GetMemberAndWriteJson(object P_0, ref WriteStack P_1, Utf8JsonWriter P_2);

	internal abstract bool GetMemberAndWriteJsonExtensionData(object P_0, ref WriteStack P_1, Utf8JsonWriter P_2);

	internal abstract object GetValueAsObject(object P_0);

	internal void InitializeUsingMemberReflection(MemberInfo P_0, JsonConverter P_1, JsonIgnoreCondition? P_2, bool P_3)
	{
		ICustomAttributeProvider customAttributeProvider = (AttributeProvider = P_0);
		ICustomAttributeProvider customAttributeProvider3 = customAttributeProvider;
		if (!(customAttributeProvider3 is PropertyInfo propertyInfo))
		{
			if (customAttributeProvider3 is FieldInfo fieldInfo)
			{
				MemberName = fieldInfo.Name;
				MemberType = MemberTypes.Field;
			}
		}
		else
		{
			MemberName = propertyInfo.Name;
			IsVirtual = propertyInfo.IsVirtual();
			MemberType = MemberTypes.Property;
		}
		CustomConverter = P_1;
		DeterminePoliciesFromMember(P_0);
		DeterminePropertyNameFromMember(P_0);
		DetermineIsRequired(P_0, P_3);
		if (P_2 != JsonIgnoreCondition.Always)
		{
			DetermineMemberAccessors(P_0);
		}
		IgnoreCondition = P_2;
		IsExtensionData = P_0.GetCustomAttribute<JsonExtensionDataAttribute>(false) != null;
	}

	internal bool ReadJsonAndAddExtensionProperty(object P_0, scoped ref ReadStack P_1, ref Utf8JsonReader P_2)
	{
		object valueAsObject = GetValueAsObject(P_0);
		if (valueAsObject is IDictionary<string, object> dictionary)
		{
			if (P_2.TokenType == JsonTokenType.Null)
			{
				dictionary[P_1.Current.JsonPropertyNameAsString] = null;
			}
			else
			{
				JsonConverter<object> jsonConverter = GetDictionaryValueConverter<object>();
				object obj = jsonConverter.Read(ref P_2, System.Text.Json.Serialization.Metadata.JsonTypeInfo.ObjectType, Options);
				dictionary[P_1.Current.JsonPropertyNameAsString] = obj;
			}
		}
		else if (valueAsObject is IDictionary<string, JsonElement> dictionary2)
		{
			JsonConverter<JsonElement> jsonConverter2 = GetDictionaryValueConverter<JsonElement>();
			JsonElement jsonElement = jsonConverter2.Read(ref P_2, typeof(JsonElement), Options);
			dictionary2[P_1.Current.JsonPropertyNameAsString] = jsonElement;
		}
		else
		{
			EffectiveConverter.ReadElementAndSetProperty(valueAsObject, P_1.Current.JsonPropertyNameAsString, ref P_2, Options, ref P_1);
		}
		return true;
		JsonConverter<TValue> GetDictionaryValueConverter<TValue>()
		{
			JsonTypeInfo jsonTypeInfo = JsonTypeInfo.ElementTypeInfo ?? Options.GetTypeInfoInternal(typeof(TValue));
			return ((JsonTypeInfo<TValue>)jsonTypeInfo).EffectiveConverter;
		}
	}

	internal abstract bool ReadJsonAndSetMember(object P_0, scoped ref ReadStack P_1, ref Utf8JsonReader P_2);

	internal abstract bool ReadJsonAsObject(scoped ref ReadStack P_0, ref Utf8JsonReader P_1, out object P_2);

	internal bool ReadJsonExtensionDataValue(scoped ref ReadStack P_0, ref Utf8JsonReader P_1, out object P_2)
	{
		if (JsonTypeInfo.ElementType == System.Text.Json.Serialization.Metadata.JsonTypeInfo.ObjectType && P_1.TokenType == JsonTokenType.Null)
		{
			P_2 = null;
			return true;
		}
		JsonConverter<JsonElement> jsonConverter = (JsonConverter<JsonElement>)Options.GetConverterInternal(typeof(JsonElement));
		if (!jsonConverter.TryRead(ref P_1, typeof(JsonElement), Options, ref P_0, out var jsonElement))
		{
			P_2 = null;
			return false;
		}
		P_2 = jsonElement;
		return true;
	}

	internal void EnsureChildOf(JsonTypeInfo P_0)
	{
		if (ParentTypeInfo == null)
		{
			ParentTypeInfo = P_0;
		}
		else if (ParentTypeInfo != P_0)
		{
			ThrowHelper.ThrowInvalidOperationException_JsonPropertyInfoIsBoundToDifferentJsonTypeInfo(this);
		}
	}
}
internal sealed class JsonPropertyInfo<T> : JsonPropertyInfo
{
	private Func<object, T> _typedGet;

	private Action<object, T> _typedSet;

	private Func<object, T, bool> _shouldSerializeTyped;

	private JsonConverter<T> _typedEffectiveConverter;

	internal new Func<object, T> Get
	{
		get
		{
			return _typedGet;
		}
		set
		{
			SetGetter(getter);
		}
	}

	internal new Action<object, T> Set
	{
		get
		{
			return _typedSet;
		}
		set
		{
			SetSetter(setter);
		}
	}

	internal new Func<object, T, bool> ShouldSerialize
	{
		get
		{
			return _shouldSerializeTyped;
		}
		set
		{
			SetShouldSerialize(shouldSerialize);
		}
	}

	internal override object DefaultValue => default(T);

	internal override bool PropertyTypeCanBeNull => default(T) == null;

	internal new JsonConverter<T> EffectiveConverter => _typedEffectiveConverter;

	internal JsonPropertyInfo(Type declaringType, JsonTypeInfo declaringTypeInfo, JsonSerializerOptions options)
		: base(declaringType, typeof(T), declaringTypeInfo, options)
	{
	}

	private protected override void SetGetter(Delegate P_0)
	{
		if (P_0 == null)
		{
			_typedGet = null;
			_untypedGet = null;
			return;
		}
		Func<object, T> typedGetter = P_0 as Func<object, T>;
		if (typedGetter != null)
		{
			_typedGet = typedGetter;
			_untypedGet = ((P_0 is Func<object, object> func) ? func : ((Func<object, object>)((object obj) => typedGetter(obj))));
			return;
		}
		Func<object, object> untypedGet = (Func<object, object>)P_0;
		_typedGet = (object obj) => (T)untypedGet(obj);
		_untypedGet = untypedGet;
	}

	private protected override void SetSetter(Delegate P_0)
	{
		if (P_0 == null)
		{
			_typedSet = null;
			_untypedSet = null;
			return;
		}
		Action<object, T> typedSetter = P_0 as Action<object, T>;
		if (typedSetter != null)
		{
			_typedSet = typedSetter;
			_untypedSet = ((P_0 is Action<object, object> action) ? action : ((Action<object, object>)delegate(object obj, object obj2)
			{
				typedSetter(obj, (T)obj2);
			}));
			return;
		}
		Action<object, object> untypedSet = (Action<object, object>)P_0;
		_typedSet = delegate(object obj, T val)
		{
			untypedSet(obj, val);
		};
		_untypedSet = untypedSet;
	}

	private protected override void SetShouldSerialize(Delegate P_0)
	{
		if (P_0 == null)
		{
			_shouldSerializeTyped = null;
			_shouldSerialize = null;
			return;
		}
		Func<object, T, bool> typedPredicate = P_0 as Func<object, T, bool>;
		if (typedPredicate != null)
		{
			_shouldSerializeTyped = typedPredicate;
			_shouldSerialize = ((typedPredicate is Func<object, object, bool> func) ? func : ((Func<object, object, bool>)((object obj, object obj2) => typedPredicate(obj, (T)obj2))));
			return;
		}
		Func<object, object, bool> untypedPredicate = (Func<object, object, bool>)P_0;
		_shouldSerializeTyped = (object obj, T val) => untypedPredicate(obj, val);
		_shouldSerialize = untypedPredicate;
	}

	private protected override void DetermineMemberAccessors(MemberInfo P_0)
	{
		if (!(P_0 is PropertyInfo propertyInfo))
		{
			if (P_0 is FieldInfo fieldInfo)
			{
				Get = base.Options.MemberAccessorStrategy.CreateFieldGetter<T>(fieldInfo);
				if (!fieldInfo.IsInitOnly)
				{
					Set = base.Options.MemberAccessorStrategy.CreateFieldSetter<T>(fieldInfo);
				}
			}
			return;
		}
		bool flag = propertyInfo.GetCustomAttribute<JsonIncludeAttribute>(false) != null;
		MethodInfo getMethod = propertyInfo.GetMethod;
		if (getMethod != null && (getMethod.IsPublic || flag))
		{
			Get = base.Options.MemberAccessorStrategy.CreatePropertyGetter<T>(propertyInfo);
		}
		MethodInfo setMethod = propertyInfo.SetMethod;
		if (setMethod != null && (setMethod.IsPublic || flag))
		{
			Set = base.Options.MemberAccessorStrategy.CreatePropertySetter<T>(propertyInfo);
		}
	}

	internal JsonPropertyInfo(JsonPropertyInfoValues<T> propertyInfo, JsonSerializerOptions options)
		: this(propertyInfo.DeclaringType, (JsonTypeInfo)null, options)
	{
		string text = ((propertyInfo.JsonPropertyName != null) ? propertyInfo.JsonPropertyName : ((options.PropertyNamingPolicy != null) ? options.PropertyNamingPolicy.ConvertName(propertyInfo.PropertyName) : propertyInfo.PropertyName));
		if (text == null)
		{
			ThrowHelper.ThrowInvalidOperationException_SerializerPropertyNameNull(this);
		}
		base.Name = text;
		base.MemberName = propertyInfo.PropertyName;
		base.MemberType = (propertyInfo.IsProperty ? MemberTypes.Property : MemberTypes.Field);
		base.SrcGen_IsPublic = propertyInfo.IsPublic;
		base.SrcGen_HasJsonInclude = propertyInfo.HasJsonInclude;
		base.IsExtensionData = propertyInfo.IsExtensionData;
		base.CustomConverter = propertyInfo.Converter;
		if (propertyInfo.IgnoreCondition != JsonIgnoreCondition.Always)
		{
			Get = propertyInfo.Getter;
			Set = propertyInfo.Setter;
		}
		base.IgnoreCondition = propertyInfo.IgnoreCondition;
		base.JsonTypeInfo = propertyInfo.PropertyTypeInfo;
		base.NumberHandling = propertyInfo.NumberHandling;
	}

	private protected override void DetermineEffectiveConverter(JsonTypeInfo P_0)
	{
		base.ConverterStrategy = (_typedEffectiveConverter = (JsonConverter<T>)(_effectiveConverter = base.Options.ExpandConverterFactory(base.CustomConverter, base.PropertyType)?.CreateCastingConverter<T>() ?? ((JsonTypeInfo<T>)P_0).EffectiveConverter)).ConverterStrategy;
	}

	internal override object GetValueAsObject(object P_0)
	{
		if (base.IsForTypeInfo)
		{
			return P_0;
		}
		return Get(P_0);
	}

	internal override bool GetMemberAndWriteJson(object P_0, ref WriteStack P_1, Utf8JsonWriter P_2)
	{
		T val = Get(P_0);
		if (!typeof(T).IsValueType && base.Options.ReferenceHandlingStrategy == ReferenceHandlingStrategy.IgnoreCycles && val != null && !P_1.IsContinuation && base.ConverterStrategy != ConverterStrategy.Value && P_1.ReferenceResolver.ContainsReferenceForCycleDetection(val))
		{
			val = default(T);
		}
		if (base.IgnoreDefaultValuesOnWrite)
		{
			if (IsDefaultValue(val))
			{
				return true;
			}
		}
		else
		{
			Func<object, T, bool> shouldSerialize = ShouldSerialize;
			if (shouldSerialize != null && !shouldSerialize(P_0, val))
			{
				return true;
			}
		}
		if (val == null)
		{
			if (EffectiveConverter.HandleNullOnWrite)
			{
				if ((int)P_1.Current.PropertyState < 2)
				{
					P_1.Current.PropertyState = StackFramePropertyState.Name;
					P_2.WritePropertyNameSection(base.EscapedNameSection);
				}
				int currentDepth = P_2.CurrentDepth;
				EffectiveConverter.Write(P_2, val, base.Options);
				if (currentDepth != P_2.CurrentDepth)
				{
					ThrowHelper.ThrowJsonException_SerializationConverterWrite(EffectiveConverter);
				}
			}
			else
			{
				P_2.WriteNullSection(base.EscapedNameSection);
			}
			return true;
		}
		if ((int)P_1.Current.PropertyState < 2)
		{
			P_1.Current.PropertyState = StackFramePropertyState.Name;
			P_2.WritePropertyNameSection(base.EscapedNameSection);
		}
		return EffectiveConverter.TryWrite(P_2, in val, base.Options, ref P_1);
	}

	internal override bool GetMemberAndWriteJsonExtensionData(object P_0, ref WriteStack P_1, Utf8JsonWriter P_2)
	{
		T val = Get(P_0);
		Func<object, T, bool> shouldSerialize = ShouldSerialize;
		if (shouldSerialize != null && !shouldSerialize(P_0, val))
		{
			return true;
		}
		if (val == null)
		{
			return true;
		}
		return EffectiveConverter.TryWriteDataExtensionProperty(P_2, val, base.Options, ref P_1);
	}

	internal override bool ReadJsonAndSetMember(object P_0, scoped ref ReadStack P_1, ref Utf8JsonReader P_2)
	{
		bool flag = P_2.TokenType == JsonTokenType.Null;
		bool flag2;
		if (flag && !EffectiveConverter.HandleNullOnRead && !P_1.IsContinuation)
		{
			if (default(T) != null)
			{
				ThrowHelper.ThrowJsonException_DeserializeUnableToConvertValue(EffectiveConverter.TypeToConvert);
			}
			if (!base.IgnoreNullTokensOnRead)
			{
				Set(P_0, default(T));
			}
			flag2 = true;
			P_1.Current.MarkRequiredPropertyAsRead(this);
		}
		else if (EffectiveConverter.CanUseDirectReadOrWrite && !P_1.Current.NumberHandling.HasValue)
		{
			if (!flag || !base.IgnoreNullTokensOnRead || default(T) != null)
			{
				T val = EffectiveConverter.Read(ref P_2, base.PropertyType, base.Options);
				Set(P_0, val);
			}
			flag2 = true;
			P_1.Current.MarkRequiredPropertyAsRead(this);
		}
		else
		{
			flag2 = true;
			if (!flag || !base.IgnoreNullTokensOnRead || default(T) != null || P_1.IsContinuation)
			{
				flag2 = EffectiveConverter.TryRead(ref P_2, base.PropertyType, base.Options, ref P_1, out var val2);
				if (flag2)
				{
					Set(P_0, val2);
					P_1.Current.MarkRequiredPropertyAsRead(this);
				}
			}
		}
		return flag2;
	}

	internal override bool ReadJsonAsObject(scoped ref ReadStack P_0, ref Utf8JsonReader P_1, out object P_2)
	{
		bool result;
		if (P_1.TokenType == JsonTokenType.Null && !EffectiveConverter.HandleNullOnRead && !P_0.IsContinuation)
		{
			if (default(T) != null)
			{
				ThrowHelper.ThrowJsonException_DeserializeUnableToConvertValue(EffectiveConverter.TypeToConvert);
			}
			P_2 = default(T);
			result = true;
		}
		else if (EffectiveConverter.CanUseDirectReadOrWrite && !P_0.Current.NumberHandling.HasValue)
		{
			P_2 = EffectiveConverter.Read(ref P_1, base.PropertyType, base.Options);
			result = true;
		}
		else
		{
			result = EffectiveConverter.TryRead(ref P_1, base.PropertyType, base.Options, ref P_0, out var val);
			P_2 = val;
		}
		return result;
	}

	private protected override void ConfigureIgnoreCondition(JsonIgnoreCondition? P_0)
	{
		if (!P_0.HasValue)
		{
			return;
		}
		switch (P_0.GetValueOrDefault())
		{
		case JsonIgnoreCondition.Never:
			ShouldSerialize = ShouldSerializeIgnoreConditionNever;
			break;
		case JsonIgnoreCondition.Always:
			ShouldSerialize = ShouldSerializeIgnoreConditionAlways;
			break;
		case JsonIgnoreCondition.WhenWritingNull:
			if (PropertyTypeCanBeNull)
			{
				ShouldSerialize = ShouldSerializeIgnoreWhenWritingDefault;
				base.IgnoreDefaultValuesOnWrite = true;
			}
			else
			{
				ThrowHelper.ThrowInvalidOperationException_IgnoreConditionOnValueTypeInvalid(base.MemberName, base.DeclaringType);
			}
			break;
		case JsonIgnoreCondition.WhenWritingDefault:
			ShouldSerialize = ShouldSerializeIgnoreWhenWritingDefault;
			base.IgnoreDefaultValuesOnWrite = true;
			break;
		}
		static bool ShouldSerializeIgnoreConditionAlways(object obj, T val)
		{
			return false;
		}
		static bool ShouldSerializeIgnoreConditionNever(object obj, T val)
		{
			return true;
		}
		static bool ShouldSerializeIgnoreWhenWritingDefault(object obj, T val)
		{
			if (default(T) != null)
			{
				return !EqualityComparer<T>.Default.Equals(default(T), val);
			}
			return val != null;
		}
	}

	private static bool IsDefaultValue(T P_0)
	{
		if (default(T) != null)
		{
			return EqualityComparer<T>.Default.Equals(default(T), P_0);
		}
		return P_0 == null;
	}
}
