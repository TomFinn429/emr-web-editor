namespace System.Text.Json.Serialization.Converters;

internal sealed class DoubleConverter : JsonConverter<double>
{
	public DoubleConverter()
	{
		IsInternalConverterForNumberType = true;
	}

	public override double Read(ref Utf8JsonReader P_0, Type P_1, JsonSerializerOptions P_2)
	{
		return P_0.GetDouble();
	}

	public override void Write(Utf8JsonWriter P_0, double P_1, JsonSerializerOptions P_2)
	{
		P_0.WriteNumberValue(P_1);
	}

	internal override double ReadAsPropertyNameCore(ref Utf8JsonReader P_0, Type P_1, JsonSerializerOptions P_2)
	{
		return P_0.GetDoubleWithQuotes();
	}

	internal override void WriteAsPropertyNameCore(Utf8JsonWriter P_0, double P_1, JsonSerializerOptions P_2, bool P_3)
	{
		P_0.WritePropertyName(P_1);
	}

	internal override double ReadNumberWithCustomHandling(ref Utf8JsonReader P_0, JsonNumberHandling P_1, JsonSerializerOptions P_2)
	{
		if (P_0.TokenType == JsonTokenType.String)
		{
			if ((JsonNumberHandling.AllowReadingFromString & P_1) != JsonNumberHandling.Strict)
			{
				return P_0.GetDoubleWithQuotes();
			}
			if ((JsonNumberHandling.AllowNamedFloatingPointLiterals & P_1) != JsonNumberHandling.Strict)
			{
				return P_0.GetDoubleFloatingPointConstant();
			}
		}
		return P_0.GetDouble();
	}

	internal override void WriteNumberWithCustomHandling(Utf8JsonWriter P_0, double P_1, JsonNumberHandling P_2)
	{
		if ((JsonNumberHandling.WriteAsString & P_2) != JsonNumberHandling.Strict)
		{
			P_0.WriteNumberValueAsString(P_1);
		}
		else if ((JsonNumberHandling.AllowNamedFloatingPointLiterals & P_2) != JsonNumberHandling.Strict)
		{
			P_0.WriteFloatingPointConstant(P_1);
		}
		else
		{
			P_0.WriteNumberValue(P_1);
		}
	}
}
