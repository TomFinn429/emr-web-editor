namespace System.Text.Json.Serialization.Converters;

internal sealed class SByteConverter : JsonConverter<sbyte>
{
	public SByteConverter()
	{
		IsInternalConverterForNumberType = true;
	}

	public override sbyte Read(ref Utf8JsonReader P_0, Type P_1, JsonSerializerOptions P_2)
	{
		return P_0.GetSByte();
	}

	public override void Write(Utf8JsonWriter P_0, sbyte P_1, JsonSerializerOptions P_2)
	{
		P_0.WriteNumberValue(P_1);
	}

	internal override sbyte ReadAsPropertyNameCore(ref Utf8JsonReader P_0, Type P_1, JsonSerializerOptions P_2)
	{
		return P_0.GetSByteWithQuotes();
	}

	internal override void WriteAsPropertyNameCore(Utf8JsonWriter P_0, sbyte P_1, JsonSerializerOptions P_2, bool P_3)
	{
		P_0.WritePropertyName(P_1);
	}

	internal override sbyte ReadNumberWithCustomHandling(ref Utf8JsonReader P_0, JsonNumberHandling P_1, JsonSerializerOptions P_2)
	{
		if (P_0.TokenType == JsonTokenType.String && (JsonNumberHandling.AllowReadingFromString & P_1) != JsonNumberHandling.Strict)
		{
			return P_0.GetSByteWithQuotes();
		}
		return P_0.GetSByte();
	}

	internal override void WriteNumberWithCustomHandling(Utf8JsonWriter P_0, sbyte P_1, JsonNumberHandling P_2)
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
