using System.Text.Json.Serialization;
using System.Text.Json.Serialization.Metadata;

namespace System.Text.Json.Nodes;

internal sealed class JsonValueTrimmable<TValue> : JsonValue<TValue>
{
	private readonly JsonTypeInfo<TValue> _jsonTypeInfo;

	private readonly JsonConverter<TValue> _converter;

	public JsonValueTrimmable(TValue P_0, JsonConverter<TValue> P_1, JsonNodeOptions? P_2 = null)
		: base(P_0, P_2)
	{
		_converter = P_1;
	}

	public override void WriteTo(Utf8JsonWriter P_0, JsonSerializerOptions P_1 = null)
	{
		if (P_0 == null)
		{
			ThrowHelper.ThrowArgumentNullException("writer");
		}
		if (_converter != null)
		{
			if (P_1 == null)
			{
				P_1 = JsonNode.s_defaultOptions;
			}
			if (_converter.IsInternalConverterForNumberType)
			{
				_converter.WriteNumberWithCustomHandling(P_0, _value, P_1.NumberHandling);
			}
			else
			{
				_converter.Write(P_0, _value, P_1);
			}
		}
		else
		{
			JsonSerializer.Serialize(P_0, _value, _jsonTypeInfo);
		}
	}
}
