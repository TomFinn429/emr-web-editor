using System.Runtime.CompilerServices;

namespace System.Text.Json.Serialization.Metadata;

internal abstract class JsonParameterInfo
{
	private JsonTypeInfo _jsonTypeInfo;

	[CompilerGenerated]
	private JsonConverter _003CConverterBase_003Ek__BackingField;

	[CompilerGenerated]
	private bool _003CMatchingPropertyCanBeNull_003Ek__BackingField;

	[CompilerGenerated]
	private object _003CDefaultValue_003Ek__BackingField;

	[CompilerGenerated]
	private bool _003CIgnoreNullTokensOnRead_003Ek__BackingField;

	[CompilerGenerated]
	private JsonSerializerOptions _003COptions_003Ek__BackingField;

	[CompilerGenerated]
	private byte[] _003CNameAsUtf8Bytes_003Ek__BackingField;

	[CompilerGenerated]
	private JsonNumberHandling? _003CNumberHandling_003Ek__BackingField;

	public JsonParameterInfoValues ClrInfo;

	[CompilerGenerated]
	private Type _003CPropertyType_003Ek__BackingField;

	[CompilerGenerated]
	private bool _003CShouldDeserialize_003Ek__BackingField;

	[CompilerGenerated]
	private JsonPropertyInfo _003CMatchingProperty_003Ek__BackingField;

	public JsonConverter ConverterBase
	{
		[CompilerGenerated]
		get
		{
			return _003CConverterBase_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			_003CConverterBase_003Ek__BackingField = jsonConverter;
		}
	}

	private bool MatchingPropertyCanBeNull
	{
		[CompilerGenerated]
		set
		{
			_003CMatchingPropertyCanBeNull_003Ek__BackingField = flag;
		}
	}

	public object DefaultValue
	{
		[CompilerGenerated]
		get
		{
			return _003CDefaultValue_003Ek__BackingField;
		}
		[CompilerGenerated]
		private protected set
		{
			_003CDefaultValue_003Ek__BackingField = obj;
		}
	}

	public bool IgnoreNullTokensOnRead
	{
		[CompilerGenerated]
		get
		{
			return _003CIgnoreNullTokensOnRead_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			_003CIgnoreNullTokensOnRead_003Ek__BackingField = flag;
		}
	}

	public JsonSerializerOptions Options
	{
		[CompilerGenerated]
		get
		{
			return _003COptions_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			_003COptions_003Ek__BackingField = jsonSerializerOptions;
		}
	}

	public byte[] NameAsUtf8Bytes
	{
		[CompilerGenerated]
		get
		{
			return _003CNameAsUtf8Bytes_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			_003CNameAsUtf8Bytes_003Ek__BackingField = array;
		}
	}

	public JsonNumberHandling? NumberHandling
	{
		[CompilerGenerated]
		get
		{
			return _003CNumberHandling_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			_003CNumberHandling_003Ek__BackingField = jsonNumberHandling;
		}
	}

	public JsonTypeInfo JsonTypeInfo => _jsonTypeInfo ?? (_jsonTypeInfo = Options.GetTypeInfoInternal(PropertyType));

	public Type PropertyType
	{
		[CompilerGenerated]
		get
		{
			return _003CPropertyType_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			_003CPropertyType_003Ek__BackingField = type;
		}
	}

	public bool ShouldDeserialize
	{
		[CompilerGenerated]
		get
		{
			return _003CShouldDeserialize_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			_003CShouldDeserialize_003Ek__BackingField = flag;
		}
	}

	public JsonPropertyInfo MatchingProperty
	{
		[CompilerGenerated]
		get
		{
			return _003CMatchingProperty_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			_003CMatchingProperty_003Ek__BackingField = jsonPropertyInfo;
		}
	}

	public virtual void Initialize(JsonParameterInfoValues P_0, JsonPropertyInfo P_1, JsonSerializerOptions P_2)
	{
		MatchingProperty = P_1;
		ClrInfo = P_0;
		Options = P_2;
		ShouldDeserialize = true;
		PropertyType = P_1.PropertyType;
		NameAsUtf8Bytes = P_1.NameAsUtf8Bytes;
		ConverterBase = P_1.EffectiveConverter;
		IgnoreNullTokensOnRead = P_1.IgnoreNullTokensOnRead;
		NumberHandling = P_1.EffectiveNumberHandling;
		MatchingPropertyCanBeNull = P_1.PropertyTypeCanBeNull;
	}

	public static JsonParameterInfo CreateIgnoredParameterPlaceholder(JsonParameterInfoValues P_0, JsonPropertyInfo P_1, bool P_2)
	{
		JsonParameterInfo jsonParameterInfo = new JsonParameterInfo<sbyte>();
		jsonParameterInfo.ClrInfo = P_0;
		jsonParameterInfo.PropertyType = P_1.PropertyType;
		jsonParameterInfo.NameAsUtf8Bytes = P_1.NameAsUtf8Bytes;
		if (P_2)
		{
			jsonParameterInfo.DefaultValue = P_1.DefaultValue;
		}
		else
		{
			Type parameterType = P_0.ParameterType;
			JsonTypeInfo jsonTypeInfo;
			DefaultValueHolder defaultValueHolder = ((!P_1.Options.TryGetTypeInfoCached(parameterType, out jsonTypeInfo)) ? DefaultValueHolder.CreateHolder(P_0.ParameterType) : jsonTypeInfo.DefaultValueHolder);
			jsonParameterInfo.DefaultValue = defaultValueHolder.DefaultValue;
		}
		return jsonParameterInfo;
	}
}
internal sealed class JsonParameterInfo<T> : JsonParameterInfo
{
	public T TypedDefaultValue
	{
		[CompilerGenerated]
		get
		{
			return _003CTypedDefaultValue_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			_003CTypedDefaultValue_003Ek__BackingField = val;
		}
	}

	public override void Initialize(JsonParameterInfoValues P_0, JsonPropertyInfo P_1, JsonSerializerOptions P_2)
	{
		base.Initialize(P_0, P_1, P_2);
		InitializeDefaultValue(P_1);
	}

	private void InitializeDefaultValue(JsonPropertyInfo P_0)
	{
		if (ClrInfo.HasDefaultValue)
		{
			object defaultValue = ClrInfo.DefaultValue;
			if (defaultValue == null && !P_0.PropertyTypeCanBeNull)
			{
				base.DefaultValue = TypedDefaultValue;
				return;
			}
			base.DefaultValue = defaultValue;
			TypedDefaultValue = (T)defaultValue;
		}
		else
		{
			base.DefaultValue = TypedDefaultValue;
		}
	}
}
