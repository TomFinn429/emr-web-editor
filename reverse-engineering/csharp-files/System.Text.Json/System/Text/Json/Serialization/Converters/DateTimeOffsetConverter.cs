namespace System.Text.Json.Serialization.Converters;

internal sealed class DateTimeOffsetConverter : JsonConverter<DateTimeOffset>
{
	public override DateTimeOffset Read(ref Utf8JsonReader P_0, Type P_1, JsonSerializerOptions P_2)
	{
		return P_0.GetDateTimeOffset();
	}

	public override void Write(Utf8JsonWriter P_0, DateTimeOffset P_1, JsonSerializerOptions P_2)
	{
		P_0.WriteStringValue(P_1);
	}

	internal override DateTimeOffset ReadAsPropertyNameCore(ref Utf8JsonReader P_0, Type P_1, JsonSerializerOptions P_2)
	{
		return P_0.GetDateTimeOffsetNoValidation();
	}

	internal override void WriteAsPropertyNameCore(Utf8JsonWriter P_0, DateTimeOffset P_1, JsonSerializerOptions P_2, bool P_3)
	{
		P_0.WritePropertyName(P_1);
	}
}
