using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization.Metadata;

namespace System.Text.Json.Serialization;

internal abstract class JsonDictionaryConverter<TDictionary> : JsonResumableConverter<TDictionary>
{
	internal override bool SupportsCreateObjectDelegate => true;

	internal sealed override ConverterStrategy ConverterStrategy => ConverterStrategy.Dictionary;

	protected internal abstract bool OnWriteResume(Utf8JsonWriter P_0, TDictionary P_1, JsonSerializerOptions P_2, ref WriteStack P_3);
}
internal abstract class JsonDictionaryConverter<TDictionary, TKey, TValue> : JsonDictionaryConverter<TDictionary>
{
	protected JsonConverter<TKey> _keyConverter;

	protected JsonConverter<TValue> _valueConverter;

	internal override Type ElementType => typeof(TValue);

	internal override Type KeyType => typeof(TKey);

	protected abstract void Add(TKey P_0, in TValue P_1, JsonSerializerOptions P_2, ref ReadStack P_3);

	protected virtual void ConvertCollection(ref ReadStack P_0, JsonSerializerOptions P_1)
	{
	}

	protected virtual void CreateCollection(ref Utf8JsonReader P_0, scoped ref ReadStack P_1)
	{
		JsonTypeInfo jsonTypeInfo = P_1.Current.JsonTypeInfo;
		if (jsonTypeInfo.CreateObject == null)
		{
			if (TypeToConvert.IsAbstract || TypeToConvert.IsInterface)
			{
				ThrowHelper.ThrowNotSupportedException_CannotPopulateCollection(TypeToConvert, ref P_0, ref P_1);
			}
			else
			{
				ThrowHelper.ThrowNotSupportedException_DeserializeNoConstructor(TypeToConvert, ref P_0, ref P_1);
			}
		}
		P_1.Current.ReturnValue = jsonTypeInfo.CreateObject();
	}

	protected static JsonConverter<T> GetConverter<T>(JsonTypeInfo P_0)
	{
		return ((JsonTypeInfo<T>)P_0).EffectiveConverter;
	}

	internal sealed override bool OnTryRead(ref Utf8JsonReader P_0, Type P_1, JsonSerializerOptions P_2, scoped ref ReadStack P_3, [MaybeNullWhen(false)] out TDictionary P_4)
	{
		JsonTypeInfo keyTypeInfo = P_3.Current.JsonTypeInfo.KeyTypeInfo;
		JsonTypeInfo elementTypeInfo = P_3.Current.JsonTypeInfo.ElementTypeInfo;
		if (!P_3.SupportContinuation && !P_3.Current.CanContainMetadata)
		{
			if (P_0.TokenType != JsonTokenType.StartObject)
			{
				ThrowHelper.ThrowJsonException_DeserializeUnableToConvertValue(TypeToConvert);
			}
			CreateCollection(ref P_0, ref P_3);
			if (_keyConverter == null)
			{
				_keyConverter = GetConverter<TKey>(keyTypeInfo);
			}
			if (_valueConverter == null)
			{
				_valueConverter = GetConverter<TValue>(elementTypeInfo);
			}
			if (_valueConverter.CanUseDirectReadOrWrite && !P_3.Current.NumberHandling.HasValue)
			{
				while (true)
				{
					P_0.ReadWithVerify();
					if (P_0.TokenType == JsonTokenType.EndObject)
					{
						break;
					}
					P_3.Current.JsonPropertyInfo = keyTypeInfo.PropertyInfoForTypeInfo;
					TKey val = ReadDictionaryKey(_keyConverter, ref P_0, ref P_3, P_2);
					P_0.ReadWithVerify();
					P_3.Current.JsonPropertyInfo = elementTypeInfo.PropertyInfoForTypeInfo;
					Add(val, _valueConverter.Read(ref P_0, ElementType, P_2), P_2, ref P_3);
				}
			}
			else
			{
				while (true)
				{
					P_0.ReadWithVerify();
					if (P_0.TokenType == JsonTokenType.EndObject)
					{
						break;
					}
					P_3.Current.JsonPropertyInfo = keyTypeInfo.PropertyInfoForTypeInfo;
					TKey val2 = ReadDictionaryKey(_keyConverter, ref P_0, ref P_3, P_2);
					P_0.ReadWithVerify();
					P_3.Current.JsonPropertyInfo = elementTypeInfo.PropertyInfoForTypeInfo;
					_valueConverter.TryRead(ref P_0, ElementType, P_2, ref P_3, out var val3);
					Add(val2, in val3, P_2, ref P_3);
				}
			}
		}
		else
		{
			JsonTypeInfo jsonTypeInfo = P_3.Current.JsonTypeInfo;
			if (P_3.Current.ObjectState == StackFrameObjectState.None)
			{
				if (P_0.TokenType != JsonTokenType.StartObject)
				{
					ThrowHelper.ThrowJsonException_DeserializeUnableToConvertValue(TypeToConvert);
				}
				P_3.Current.ObjectState = StackFrameObjectState.StartToken;
			}
			if (P_3.Current.CanContainMetadata && (int)P_3.Current.ObjectState < 2)
			{
				if (!JsonSerializer.TryReadMetadata(this, jsonTypeInfo, ref P_0, ref P_3))
				{
					P_4 = default(TDictionary);
					return false;
				}
				if (P_3.Current.MetadataPropertyNames == MetadataPropertyName.Ref)
				{
					P_4 = JsonSerializer.ResolveReferenceId<TDictionary>(ref P_3);
					return true;
				}
				P_3.Current.ObjectState = StackFrameObjectState.ReadMetadata;
			}
			if (P_3.Current.MetadataPropertyNames.HasFlag(MetadataPropertyName.Type) && P_3.Current.PolymorphicSerializationState != PolymorphicSerializationState.PolymorphicReEntryStarted)
			{
				JsonConverter jsonConverter = ResolvePolymorphicConverter(jsonTypeInfo, P_2, ref P_3);
				if (jsonConverter != null)
				{
					object obj;
					bool flag = jsonConverter.OnTryReadAsObject(ref P_0, P_2, ref P_3, out obj);
					P_4 = (TDictionary)obj;
					P_3.ExitPolymorphicConverter(flag);
					return flag;
				}
			}
			if ((int)P_3.Current.ObjectState < 4)
			{
				if (P_3.Current.CanContainMetadata)
				{
					JsonSerializer.ValidateMetadataForObjectConverter(this, ref P_0, ref P_3);
				}
				CreateCollection(ref P_0, ref P_3);
				if (P_3.Current.MetadataPropertyNames.HasFlag(MetadataPropertyName.Id))
				{
					P_3.ReferenceResolver.AddReference(P_3.ReferenceId, P_3.Current.ReturnValue);
					P_3.ReferenceId = null;
				}
				P_3.Current.ObjectState = StackFrameObjectState.CreatedObject;
			}
			if (_keyConverter == null)
			{
				_keyConverter = GetConverter<TKey>(keyTypeInfo);
			}
			if (_valueConverter == null)
			{
				_valueConverter = GetConverter<TValue>(elementTypeInfo);
			}
			while (true)
			{
				if (P_3.Current.PropertyState == StackFramePropertyState.None)
				{
					P_3.Current.PropertyState = StackFramePropertyState.ReadName;
					if (!P_0.Read())
					{
						P_4 = default(TDictionary);
						return false;
					}
				}
				TKey val4;
				if ((int)P_3.Current.PropertyState < 2)
				{
					if (P_0.TokenType == JsonTokenType.EndObject)
					{
						break;
					}
					P_3.Current.PropertyState = StackFramePropertyState.Name;
					if (P_3.Current.CanContainMetadata)
					{
						ReadOnlySpan<byte> span = P_0.GetSpan();
						if (JsonSerializer.IsMetadataPropertyName(span, P_3.Current.BaseJsonTypeInfo.PolymorphicTypeResolver))
						{
							ThrowHelper.ThrowUnexpectedMetadataException(span, ref P_0, ref P_3);
						}
					}
					P_3.Current.JsonPropertyInfo = keyTypeInfo.PropertyInfoForTypeInfo;
					val4 = ReadDictionaryKey(_keyConverter, ref P_0, ref P_3, P_2);
				}
				else
				{
					val4 = (TKey)P_3.Current.DictionaryKey;
				}
				if ((int)P_3.Current.PropertyState < 3)
				{
					P_3.Current.PropertyState = StackFramePropertyState.ReadValue;
					if (!JsonConverter.SingleValueReadWithReadAhead(_valueConverter.RequiresReadAhead, ref P_0, ref P_3))
					{
						P_3.Current.DictionaryKey = val4;
						P_4 = default(TDictionary);
						return false;
					}
				}
				if ((int)P_3.Current.PropertyState < 5)
				{
					P_3.Current.JsonPropertyInfo = elementTypeInfo.PropertyInfoForTypeInfo;
					if (!_valueConverter.TryRead(ref P_0, typeof(TValue), P_2, ref P_3, out var val5))
					{
						P_3.Current.DictionaryKey = val4;
						P_4 = default(TDictionary);
						return false;
					}
					Add(val4, in val5, P_2, ref P_3);
					P_3.Current.EndElement();
				}
			}
		}
		ConvertCollection(ref P_3, P_2);
		P_4 = (TDictionary)P_3.Current.ReturnValue;
		return true;
		static TKey ReadDictionaryKey(JsonConverter<TKey> jsonConverter2, ref Utf8JsonReader reference, scoped ref ReadStack reference2, JsonSerializerOptions jsonSerializerOptions)
		{
			string text = reference.GetString();
			reference2.Current.JsonPropertyNameAsString = text;
			if (jsonConverter2.IsInternalConverter && jsonConverter2.TypeToConvert == typeof(string))
			{
				return (TKey)(object)text;
			}
			return jsonConverter2.ReadAsPropertyNameCore(ref reference, jsonConverter2.TypeToConvert, jsonSerializerOptions);
		}
	}

	internal sealed override bool OnTryWrite(Utf8JsonWriter P_0, TDictionary P_1, JsonSerializerOptions P_2, ref WriteStack P_3)
	{
		if (P_1 == null)
		{
			P_0.WriteNullValue();
			return true;
		}
		if (!P_3.Current.ProcessedStartToken)
		{
			P_3.Current.ProcessedStartToken = true;
			P_0.WriteStartObject();
			if (P_3.CurrentContainsMetadata && CanHaveMetadata)
			{
				JsonSerializer.WriteMetadataForObject(this, ref P_3, P_0);
			}
			P_3.Current.JsonPropertyInfo = P_3.Current.JsonTypeInfo.ElementTypeInfo.PropertyInfoForTypeInfo;
		}
		bool flag = OnWriteResume(P_0, P_1, P_2, ref P_3);
		if (flag && !P_3.Current.ProcessedEndToken)
		{
			P_3.Current.ProcessedEndToken = true;
			P_0.WriteEndObject();
		}
		return flag;
	}
}
