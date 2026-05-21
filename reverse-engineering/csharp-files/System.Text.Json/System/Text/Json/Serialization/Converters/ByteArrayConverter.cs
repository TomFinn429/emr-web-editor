namespace System.Text.Json.Serialization.Converters;

internal sealed class ByteArrayConverter : JsonConverter<byte[]>
{
	public override byte[] Read(ref Utf8JsonReader P_0, Type P_1, JsonSerializerOptions P_2)
	{
		if (P_0.TokenType == JsonTokenType.Null)
		{
			return null;
		}
		return P_0.GetBytesFromBase64();
	}

	public override void Write(Utf8JsonWriter P_0, byte[] P_1, JsonSerializerOptions P_2)
	{
		if (P_1 == null)
		{
			P_0.WriteNullValue();
		}
		else
		{
			P_0.WriteBase64StringValue(P_1);
		}
	}
}
