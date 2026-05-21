namespace System.Text.Json.Serialization.Converters;

internal sealed class UInt64Converter : JsonConverter<ulong>
{
	public UInt64Converter()
	{
		IsInternalConverterForNumberType = true;
	}

	public override ulong Read(ref Utf8JsonReader P_0, Type P_1, JsonSerializerOptions P_2)
	{
		return P_0.GetUInt64();
	}

	public override void Write(Utf8JsonWriter P_0, ulong P_1, JsonSerializerOptions P_2)
	{
		P_0.WriteNumberValue(P_1);
	}

	internal override ulong ReadAsPropertyNameCore(ref Utf8JsonReader P_0, Type P_1, JsonSerializerOptions P_2)
	{
		return P_0.GetUInt64WithQuotes();
	}

	internal override void WriteAsPropertyNameCore(Utf8JsonWriter P_0, ulong P_1, JsonSerializerOptions P_2, bool P_3)
	{
		P_0.WritePropertyName(P_1);
	}

	internal override ulong ReadNumberWithCustomHandling(ref Utf8JsonReader P_0, JsonNumberHandling P_1, JsonSerializerOptions P_2)
	{
		if (P_0.TokenType == JsonTokenType.String && (JsonNumberHandling.AllowReadingFromString & P_1) != JsonNumberHandling.Strict)
		{
			return P_0.GetUInt64WithQuotes();
		}
		return P_0.GetUInt64();
	}

	internal override void WriteNumberWithCustomHandling(Utf8JsonWriter P_0, ulong P_1, JsonNumberHandling P_2)
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
