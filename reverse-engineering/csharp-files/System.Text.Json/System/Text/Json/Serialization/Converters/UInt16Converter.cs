namespace System.Text.Json.Serialization.Converters;

internal sealed class UInt16Converter : JsonConverter<ushort>
{
	public UInt16Converter()
	{
		IsInternalConverterForNumberType = true;
	}

	public override ushort Read(ref Utf8JsonReader P_0, Type P_1, JsonSerializerOptions P_2)
	{
		return P_0.GetUInt16();
	}

	public override void Write(Utf8JsonWriter P_0, ushort P_1, JsonSerializerOptions P_2)
	{
		P_0.WriteNumberValue((long)P_1);
	}

	internal override ushort ReadAsPropertyNameCore(ref Utf8JsonReader P_0, Type P_1, JsonSerializerOptions P_2)
	{
		return P_0.GetUInt16WithQuotes();
	}

	internal override void WriteAsPropertyNameCore(Utf8JsonWriter P_0, ushort P_1, JsonSerializerOptions P_2, bool P_3)
	{
		P_0.WritePropertyName(P_1);
	}

	internal override ushort ReadNumberWithCustomHandling(ref Utf8JsonReader P_0, JsonNumberHandling P_1, JsonSerializerOptions P_2)
	{
		if (P_0.TokenType == JsonTokenType.String && (JsonNumberHandling.AllowReadingFromString & P_1) != JsonNumberHandling.Strict)
		{
			return P_0.GetUInt16WithQuotes();
		}
		return P_0.GetUInt16();
	}

	internal override void WriteNumberWithCustomHandling(Utf8JsonWriter P_0, ushort P_1, JsonNumberHandling P_2)
	{
		if ((JsonNumberHandling.WriteAsString & P_2) != JsonNumberHandling.Strict)
		{
			P_0.WriteNumberValueAsString(P_1);
		}
		else
		{
			P_0.WriteNumberValue((long)P_1);
		}
	}
}
