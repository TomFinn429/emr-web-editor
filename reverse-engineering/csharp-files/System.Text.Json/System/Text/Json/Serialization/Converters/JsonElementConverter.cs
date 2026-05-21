namespace System.Text.Json.Serialization.Converters;

internal sealed class JsonElementConverter : JsonConverter<JsonElement>
{
	public override JsonElement Read(ref Utf8JsonReader P_0, Type P_1, JsonSerializerOptions P_2)
	{
		return JsonElement.ParseValue(ref P_0);
	}

	public override void Write(Utf8JsonWriter P_0, JsonElement P_1, JsonSerializerOptions P_2)
	{
		P_1.WriteTo(P_0);
	}
}
