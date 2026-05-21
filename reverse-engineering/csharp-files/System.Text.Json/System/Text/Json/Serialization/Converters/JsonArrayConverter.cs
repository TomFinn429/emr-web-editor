using System.Text.Json.Nodes;

namespace System.Text.Json.Serialization.Converters;

internal sealed class JsonArrayConverter : JsonConverter<JsonArray>
{
	public override void Write(Utf8JsonWriter P_0, JsonArray P_1, JsonSerializerOptions P_2)
	{
		P_1.WriteTo(P_0, P_2);
	}

	public override JsonArray Read(ref Utf8JsonReader P_0, Type P_1, JsonSerializerOptions P_2)
	{
		JsonTokenType tokenType = P_0.TokenType;
		if (tokenType == JsonTokenType.StartArray)
		{
			return ReadList(ref P_0, P_2.GetNodeOptions());
		}
		throw ThrowHelper.GetInvalidOperationException_ExpectedArray(P_0.TokenType);
	}

	public static JsonArray ReadList(ref Utf8JsonReader P_0, JsonNodeOptions? P_1 = null)
	{
		JsonElement jsonElement = JsonElement.ParseValue(ref P_0);
		return new JsonArray(jsonElement, P_1);
	}
}
