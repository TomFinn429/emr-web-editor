namespace System.Text.Json.Serialization.Converters;

internal sealed class NullableConverter<T> : JsonConverter<T?> where T : struct
{
	private readonly JsonConverter<T> _elementConverter;

	internal override ConverterStrategy ConverterStrategy { get; }

	internal override Type ElementType => typeof(T);

	public override bool HandleNull => true;

	public NullableConverter(JsonConverter<T> elementConverter)
	{
		_elementConverter = elementConverter;
		IsInternalConverterForNumberType = elementConverter.IsInternalConverterForNumberType;
		ConverterStrategy = elementConverter.ConverterStrategy;
		base.CanUseDirectReadOrWrite = elementConverter.CanUseDirectReadOrWrite;
		base.RequiresReadAhead = elementConverter.RequiresReadAhead;
	}

	internal override bool OnTryRead(ref Utf8JsonReader P_0, Type P_1, JsonSerializerOptions P_2, scoped ref ReadStack P_3, out T? P_4)
	{
		if (!P_3.IsContinuation && P_0.TokenType == JsonTokenType.Null)
		{
			P_4 = null;
			return true;
		}
		P_3.Current.JsonPropertyInfo = P_3.Current.JsonTypeInfo.ElementTypeInfo.PropertyInfoForTypeInfo;
		if (_elementConverter.TryRead(ref P_0, typeof(T), P_2, ref P_3, out var value))
		{
			P_4 = value;
			return true;
		}
		P_4 = null;
		return false;
	}

	internal override bool OnTryWrite(Utf8JsonWriter P_0, T? P_1, JsonSerializerOptions P_2, ref WriteStack P_3)
	{
		if (!P_1.HasValue)
		{
			P_0.WriteNullValue();
			return true;
		}
		P_3.Current.JsonPropertyInfo = P_3.Current.JsonTypeInfo.ElementTypeInfo.PropertyInfoForTypeInfo;
		return _elementConverter.TryWrite(P_0, P_1.Value, P_2, ref P_3);
	}

	public override T? Read(ref Utf8JsonReader P_0, Type P_1, JsonSerializerOptions P_2)
	{
		if (P_0.TokenType == JsonTokenType.Null)
		{
			return null;
		}
		return _elementConverter.Read(ref P_0, typeof(T), P_2);
	}

	public override void Write(Utf8JsonWriter P_0, T? P_1, JsonSerializerOptions P_2)
	{
		if (!P_1.HasValue)
		{
			P_0.WriteNullValue();
		}
		else
		{
			_elementConverter.Write(P_0, P_1.Value, P_2);
		}
	}

	internal override T? ReadNumberWithCustomHandling(ref Utf8JsonReader P_0, JsonNumberHandling P_1, JsonSerializerOptions P_2)
	{
		if (P_0.TokenType == JsonTokenType.Null)
		{
			return null;
		}
		return _elementConverter.ReadNumberWithCustomHandling(ref P_0, P_1, P_2);
	}

	internal override void WriteNumberWithCustomHandling(Utf8JsonWriter P_0, T? P_1, JsonNumberHandling P_2)
	{
		if (!P_1.HasValue)
		{
			P_0.WriteNullValue();
		}
		else
		{
			_elementConverter.WriteNumberWithCustomHandling(P_0, P_1.Value, P_2);
		}
	}
}
