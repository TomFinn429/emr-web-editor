using System.Text.Json.Nodes;
using System.Text.Json.Serialization.Metadata;

namespace System.Text.Json.Serialization.Converters;

internal sealed class JsonObjectConverter : JsonConverter<JsonObject>
{
	internal override void ConfigureJsonTypeInfo(JsonTypeInfo P_0, JsonSerializerOptions P_1)
	{
		P_0.CreateObjectForExtensionDataProperty = () => new JsonObject(P_1.GetNodeOptions());
	}

	internal override void ReadElementAndSetProperty(object P_0, string P_1, ref Utf8JsonReader P_2, JsonSerializerOptions P_3, scoped ref ReadStack P_4)
	{
		JsonNode jsonNode;
		bool flag = JsonNodeConverter.Instance.TryRead(ref P_2, typeof(JsonNode), P_3, ref P_4, out jsonNode);
		JsonObject jsonObject = (JsonObject)P_0;
		JsonNode jsonNode2 = jsonNode;
		jsonObject[P_1] = jsonNode2;
	}

	public override void Write(Utf8JsonWriter P_0, JsonObject P_1, JsonSerializerOptions P_2)
	{
		P_1.WriteTo(P_0, P_2);
	}

	public override JsonObject Read(ref Utf8JsonReader P_0, Type P_1, JsonSerializerOptions P_2)
	{
		JsonTokenType tokenType = P_0.TokenType;
		if (tokenType == JsonTokenType.StartObject)
		{
			return ReadObject(ref P_0, P_2.GetNodeOptions());
		}
		throw ThrowHelper.GetInvalidOperationException_ExpectedObject(P_0.TokenType);
	}

	public static JsonObject ReadObject(ref Utf8JsonReader P_0, JsonNodeOptions? P_1)
	{
		JsonElement jsonElement = JsonElement.ParseValue(ref P_0);
		return new JsonObject(jsonElement, P_1);
	}
}
