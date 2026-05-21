namespace System.Text.Json.Serialization.Converters;

internal sealed class ByteConverter : JsonConverter<byte>
{
	public ByteConverter()
	{
		IsInternalConverterForNumberType = true;
	}

	public override byte Read(ref Utf8JsonReader P_0, Type P_1, JsonSerializerOptions P_2)
	{
		return P_0.GetByte();
	}

	public override void Write(Utf8JsonWriter P_0, byte P_1, JsonSerializerOptions P_2)
	{
		P_0.WriteNumberValue(P_1);
	}

	internal override byte ReadAsPropertyNameCore(ref Utf8JsonReader P_0, Type P_1, JsonSerializerOptions P_2)
	{
		return P_0.GetByteWithQuotes();
	}

	internal override void WriteAsPropertyNameCore(Utf8JsonWriter P_0, byte P_1, JsonSerializerOptions P_2, bool P_3)
	{
		P_0.WritePropertyName(P_1);
	}

	internal override byte ReadNumberWithCustomHandling(ref Utf8JsonReader P_0, JsonNumberHandling P_1, JsonSerializerOptions P_2)
	{
		if (P_0.TokenType == JsonTokenType.String && (JsonNumberHandling.AllowReadingFromString & P_1) != JsonNumberHandling.Strict)
		{
			return P_0.GetByteWithQuotes();
		}
		return P_0.GetByte();
	}

	internal override void WriteNumberWithCustomHandling(Utf8JsonWriter P_0, byte P_1, JsonNumberHandling P_2)
	{
		if ((JsonNumberHandling.WriteAsString & P_2) != JsonNumberHandling.Strict)
		{
			P_0.WriteNumberValueAsString(P_1);
		}
		else
		{
			P_0.WriteNumberValue(P_1);
		}
	}
}
