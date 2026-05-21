namespace System.Text.Json.Serialization.Converters;

internal sealed class CastingConverter<T, TSource> : JsonConverter<T>
{
	private readonly JsonConverter<TSource> _sourceConverter;

	internal override Type KeyType => _sourceConverter.KeyType;

	internal override Type ElementType => _sourceConverter.ElementType;

	public override bool HandleNull => _sourceConverter.HandleNull;

	internal override ConverterStrategy ConverterStrategy => _sourceConverter.ConverterStrategy;

	internal override bool SupportsCreateObjectDelegate => _sourceConverter.SupportsCreateObjectDelegate;

	internal override JsonConverter SourceConverterForCastingConverter => _sourceConverter;

	internal CastingConverter(JsonConverter<TSource> P_0)
		: base(false)
	{
		_sourceConverter = P_0;
		Initialize();
		base.IsInternalConverter = P_0.IsInternalConverter;
		IsInternalConverterForNumberType = P_0.IsInternalConverterForNumberType;
		base.RequiresReadAhead = P_0.RequiresReadAhead;
		base.CanUseDirectReadOrWrite = P_0.CanUseDirectReadOrWrite;
		base.CanBePolymorphic = P_0.CanBePolymorphic;
	}

	public override T Read(ref Utf8JsonReader P_0, Type P_1, JsonSerializerOptions P_2)
	{
		return CastOnRead(_sourceConverter.Read(ref P_0, P_1, P_2));
	}

	public override void Write(Utf8JsonWriter P_0, T P_1, JsonSerializerOptions P_2)
	{
		_sourceConverter.Write(P_0, CastOnWrite(P_1), P_2);
	}

	internal override bool OnTryRead(ref Utf8JsonReader P_0, Type P_1, JsonSerializerOptions P_2, scoped ref ReadStack P_3, out T P_4)
	{
		TSource val;
		bool result = _sourceConverter.OnTryRead(ref P_0, P_1, P_2, ref P_3, out val);
		P_4 = CastOnRead(val);
		return result;
	}

	internal override bool OnTryWrite(Utf8JsonWriter P_0, T P_1, JsonSerializerOptions P_2, ref WriteStack P_3)
	{
		return _sourceConverter.OnTryWrite(P_0, CastOnWrite(P_1), P_2, ref P_3);
	}

	public override T ReadAsPropertyName(ref Utf8JsonReader P_0, Type P_1, JsonSerializerOptions P_2)
	{
		return CastOnRead(_sourceConverter.ReadAsPropertyName(ref P_0, P_1, P_2));
	}

	internal override T ReadAsPropertyNameCore(ref Utf8JsonReader P_0, Type P_1, JsonSerializerOptions P_2)
	{
		return CastOnRead(_sourceConverter.ReadAsPropertyNameCore(ref P_0, P_1, P_2));
	}

	public override void WriteAsPropertyName(Utf8JsonWriter P_0, T P_1, JsonSerializerOptions P_2)
	{
		_sourceConverter.WriteAsPropertyName(P_0, CastOnWrite(P_1), P_2);
	}

	internal override void WriteAsPropertyNameCore(Utf8JsonWriter P_0, T P_1, JsonSerializerOptions P_2, bool P_3)
	{
		_sourceConverter.WriteAsPropertyNameCore(P_0, CastOnWrite(P_1), P_2, P_3);
	}

	internal override T ReadNumberWithCustomHandling(ref Utf8JsonReader P_0, JsonNumberHandling P_1, JsonSerializerOptions P_2)
	{
		return CastOnRead(_sourceConverter.ReadNumberWithCustomHandling(ref P_0, P_1, P_2));
	}

	internal override void WriteNumberWithCustomHandling(Utf8JsonWriter P_0, T P_1, JsonNumberHandling P_2)
	{
		_sourceConverter.WriteNumberWithCustomHandling(P_0, CastOnWrite(P_1), P_2);
	}

	private static T CastOnRead(TSource P_0)
	{
		if (default(T) == null && default(TSource) == null && P_0 == null)
		{
			return default(T);
		}
		if (P_0 is T)
		{
			object obj = P_0;
			return (T)((obj is T) ? obj : null);
		}
		HandleFailure(P_0);
		return default(T);
		static void HandleFailure(TSource val)
		{
			if (val == null)
			{
				ThrowHelper.ThrowInvalidOperationException_DeserializeUnableToAssignNull(typeof(T));
			}
			else
			{
				ThrowHelper.ThrowInvalidCastException_DeserializeUnableToAssignValue(typeof(TSource), typeof(T));
			}
		}
	}

	private static TSource CastOnWrite(T P_0)
	{
		if (default(TSource) != null && default(T) == null && P_0 == null)
		{
			ThrowHelper.ThrowJsonException_DeserializeUnableToConvertValue(typeof(TSource));
		}
		return (TSource)(object)P_0;
	}
}
