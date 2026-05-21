namespace System.Text.Json.Serialization.Converters;

internal sealed class GuidConverter : JsonConverter<Guid>
{
	public override Guid Read(ref Utf8JsonReader P_0, Type P_1, JsonSerializerOptions P_2)
	{
		return P_0.GetGuid();
	}

	public override void Write(Utf8JsonWriter P_0, Guid P_1, JsonSerializerOptions P_2)
	{
		P_0.WriteStringValue(P_1);
	}

	internal override Guid ReadAsPropertyNameCore(ref Utf8JsonReader P_0, Type P_1, JsonSerializerOptions P_2)
	{
		return P_0.GetGuidNoValidation();
	}

	internal override void WriteAsPropertyNameCore(Utf8JsonWriter P_0, Guid P_1, JsonSerializerOptions P_2, bool P_3)
	{
		P_0.WritePropertyName(P_1);
	}
}
