namespace System.Text.Json.Serialization.Converters;

internal sealed class DateTimeConverter : JsonConverter<DateTime>
{
	public override DateTime Read(ref Utf8JsonReader P_0, Type P_1, JsonSerializerOptions P_2)
	{
		return P_0.GetDateTime();
	}

	public override void Write(Utf8JsonWriter P_0, DateTime P_1, JsonSerializerOptions P_2)
	{
		P_0.WriteStringValue(P_1);
	}

	internal override DateTime ReadAsPropertyNameCore(ref Utf8JsonReader P_0, Type P_1, JsonSerializerOptions P_2)
	{
		return P_0.GetDateTimeNoValidation();
	}

	internal override void WriteAsPropertyNameCore(Utf8JsonWriter P_0, DateTime P_1, JsonSerializerOptions P_2, bool P_3)
	{
		P_0.WritePropertyName(P_1);
	}
}
