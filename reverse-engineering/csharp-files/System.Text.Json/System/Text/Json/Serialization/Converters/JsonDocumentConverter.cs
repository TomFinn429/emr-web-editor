namespace System.Text.Json.Serialization.Converters;

internal sealed class JsonDocumentConverter : JsonConverter<JsonDocument>
{
	public override JsonDocument Read(ref Utf8JsonReader P_0, Type P_1, JsonSerializerOptions P_2)
	{
		return JsonDocument.ParseValue(ref P_0);
	}

	public override void Write(Utf8JsonWriter P_0, JsonDocument P_1, JsonSerializerOptions P_2)
	{
		P_1.WriteTo(P_0);
	}
}
