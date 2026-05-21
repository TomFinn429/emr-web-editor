namespace System.Text.Json.Serialization.Converters;

internal sealed class StringConverter : JsonConverter<string>
{
	public override string Read(ref Utf8JsonReader P_0, Type P_1, JsonSerializerOptions P_2)
	{
		return P_0.GetString();
	}

	public override void Write(Utf8JsonWriter P_0, string P_1, JsonSerializerOptions P_2)
	{
		if (P_1 == null)
		{
			P_0.WriteNullValue();
		}
		else
		{
			P_0.WriteStringValue(P_1.AsSpan());
		}
	}

	internal override string ReadAsPropertyNameCore(ref Utf8JsonReader P_0, Type P_1, JsonSerializerOptions P_2)
	{
		return P_0.GetString();
	}

	internal override void WriteAsPropertyNameCore(Utf8JsonWriter P_0, string P_1, JsonSerializerOptions P_2, bool P_3)
	{
		if (P_2.DictionaryKeyPolicy != null && !P_3)
		{
			P_1 = P_2.DictionaryKeyPolicy.ConvertName(P_1);
			if (P_1 == null)
			{
				ThrowHelper.ThrowInvalidOperationException_NamingPolicyReturnNull(P_2.DictionaryKeyPolicy);
			}
		}
		P_0.WritePropertyName(P_1);
	}
}
