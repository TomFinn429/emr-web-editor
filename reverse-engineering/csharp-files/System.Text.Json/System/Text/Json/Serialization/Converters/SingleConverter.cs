namespace System.Text.Json.Serialization.Converters;

internal sealed class SingleConverter : JsonConverter<float>
{
	public SingleConverter()
	{
		IsInternalConverterForNumberType = true;
	}

	public override float Read(ref Utf8JsonReader P_0, Type P_1, JsonSerializerOptions P_2)
	{
		return P_0.GetSingle();
	}

	public override void Write(Utf8JsonWriter P_0, float P_1, JsonSerializerOptions P_2)
	{
		P_0.WriteNumberValue(P_1);
	}

	internal override float ReadAsPropertyNameCore(ref Utf8JsonReader P_0, Type P_1, JsonSerializerOptions P_2)
	{
		return P_0.GetSingleWithQuotes();
	}

	internal override void WriteAsPropertyNameCore(Utf8JsonWriter P_0, float P_1, JsonSerializerOptions P_2, bool P_3)
	{
		P_0.WritePropertyName(P_1);
	}

	internal override float ReadNumberWithCustomHandling(ref Utf8JsonReader P_0, JsonNumberHandling P_1, JsonSerializerOptions P_2)
	{
		if (P_0.TokenType == JsonTokenType.String)
		{
			if ((JsonNumberHandling.AllowReadingFromString & P_1) != JsonNumberHandling.Strict)
			{
				return P_0.GetSingleWithQuotes();
			}
			if ((JsonNumberHandling.AllowNamedFloatingPointLiterals & P_1) != JsonNumberHandling.Strict)
			{
				return P_0.GetSingleFloatingPointConstant();
			}
		}
		return P_0.GetSingle();
	}

	internal override void WriteNumberWithCustomHandling(Utf8JsonWriter P_0, float P_1, JsonNumberHandling P_2)
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
