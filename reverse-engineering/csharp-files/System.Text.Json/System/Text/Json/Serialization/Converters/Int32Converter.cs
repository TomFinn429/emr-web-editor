namespace System.Text.Json.Serialization.Converters;

internal sealed class Int32Converter : JsonConverter<int>
{
	public Int32Converter()
	{
		IsInternalConverterForNumberType = true;
	}

	public override int Read(ref Utf8JsonReader P_0, Type P_1, JsonSerializerOptions P_2)
	{
		return P_0.GetInt32();
	}

	public override void Write(Utf8JsonWriter P_0, int P_1, JsonSerializerOptions P_2)
	{
		P_0.WriteNumberValue((long)P_1);
	}

	internal override int ReadAsPropertyNameCore(ref Utf8JsonReader P_0, Type P_1, JsonSerializerOptions P_2)
	{
		return P_0.GetInt32WithQuotes();
	}

	internal override void WriteAsPropertyNameCore(Utf8JsonWriter P_0, int P_1, JsonSerializerOptions P_2, bool P_3)
	{
		P_0.WritePropertyName(P_1);
	}

	internal override int ReadNumberWithCustomHandling(ref Utf8JsonReader P_0, JsonNumberHandling P_1, JsonSerializerOptions P_2)
	{
		if (P_0.TokenType == JsonTokenType.String && (JsonNumberHandling.AllowReadingFromString & P_1) != JsonNumberHandling.Strict)
		{
			return P_0.GetInt32WithQuotes();
		}
		return P_0.GetInt32();
	}

	internal override void WriteNumberWithCustomHandling(Utf8JsonWriter P_0, int P_1, JsonNumberHandling P_2)
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
