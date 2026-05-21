using System.Text.Json.Nodes;
using System.Text.Json.Serialization.Metadata;

namespace System.Text.Json.Serialization.Converters;

internal sealed class JsonNodeConverter : JsonConverter<JsonNode>
{
	private static JsonNodeConverter s_nodeConverter;

	private static JsonArrayConverter s_arrayConverter;

	private static JsonObjectConverter s_objectConverter;

	private static JsonValueConverter s_valueConverter;

	public static JsonNodeConverter Instance => s_nodeConverter ?? (s_nodeConverter = new JsonNodeConverter());

	public static JsonArrayConverter ArrayConverter => s_arrayConverter ?? (s_arrayConverter = new JsonArrayConverter());

	public static JsonObjectConverter ObjectConverter => s_objectConverter ?? (s_objectConverter = new JsonObjectConverter());

	public static JsonValueConverter ValueConverter => s_valueConverter ?? (s_valueConverter = new JsonValueConverter());

	public override void Write(Utf8JsonWriter P_0, JsonNode P_1, JsonSerializerOptions P_2)
	{
		if (P_1 == null)
		{
			P_0.WriteNullValue();
		}
		else if (P_1 is JsonValue jsonValue)
		{
			ValueConverter.Write(P_0, jsonValue, P_2);
		}
		else if (P_1 is JsonObject jsonObject)
		{
			ObjectConverter.Write(P_0, jsonObject, P_2);
		}
		else
		{
			ArrayConverter.Write(P_0, (JsonArray)P_1, P_2);
		}
	}

	public override JsonNode Read(ref Utf8JsonReader P_0, Type P_1, JsonSerializerOptions P_2)
	{
		switch (P_0.TokenType)
		{
		case JsonTokenType.String:
		case JsonTokenType.Number:
		case JsonTokenType.True:
		case JsonTokenType.False:
			return ValueConverter.Read(ref P_0, P_1, P_2);
		case JsonTokenType.StartObject:
			return ObjectConverter.Read(ref P_0, P_1, P_2);
		case JsonTokenType.StartArray:
			return ArrayConverter.Read(ref P_0, P_1, P_2);
		default:
			throw new JsonException();
		}
	}

	public static JsonNode Create(JsonElement P_0, JsonNodeOptions? P_1)
	{
		return P_0.ValueKind switch
		{
			JsonValueKind.Null => null, 
			JsonValueKind.Object => new JsonObject(P_0, P_1), 
			JsonValueKind.Array => new JsonArray(P_0, P_1), 
			_ => new JsonValueTrimmable<JsonElement>(P_0, JsonMetadataServices.JsonElementConverter, P_1), 
		};
	}
}
