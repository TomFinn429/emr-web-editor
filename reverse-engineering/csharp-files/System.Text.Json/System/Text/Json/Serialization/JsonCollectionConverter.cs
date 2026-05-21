using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization.Metadata;

namespace System.Text.Json.Serialization;

internal abstract class JsonCollectionConverter<TCollection, TElement> : JsonResumableConverter<TCollection>
{
	internal override bool SupportsCreateObjectDelegate => true;

	internal sealed override ConverterStrategy ConverterStrategy => ConverterStrategy.Enumerable;

	internal override Type ElementType => typeof(TElement);

	protected abstract void Add(in TElement P_0, ref ReadStack P_1);

	protected virtual void CreateCollection(ref Utf8JsonReader P_0, scoped ref ReadStack P_1, JsonSerializerOptions P_2)
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

	protected virtual void ConvertCollection(ref ReadStack P_0, JsonSerializerOptions P_1)
	{
	}

	protected static JsonConverter<TElement> GetElementConverter(JsonTypeInfo P_0)
	{
		return ((JsonTypeInfo<TElement>)P_0).EffectiveConverter;
	}

	protected static JsonConverter<TElement> GetElementConverter(ref WriteStack P_0)
	{
		return (JsonConverter<TElement>)P_0.Current.JsonPropertyInfo.EffectiveConverter;
	}

	internal override bool OnTryRead(ref Utf8JsonReader P_0, Type P_1, JsonSerializerOptions P_2, scoped ref ReadStack P_3, [MaybeNullWhen(false)] out TCollection P_4)
	{
		JsonTypeInfo elementTypeInfo = P_3.Current.JsonTypeInfo.ElementTypeInfo;
		if (!P_3.SupportContinuation && !P_3.Current.CanContainMetadata)
		{
			if (P_0.TokenType != JsonTokenType.StartArray)
			{
				ThrowHelper.ThrowJsonException_DeserializeUnableToConvertValue(TypeToConvert);
			}
			CreateCollection(ref P_0, ref P_3, P_2);
			P_3.Current.JsonPropertyInfo = elementTypeInfo.PropertyInfoForTypeInfo;
			JsonConverter<TElement> elementConverter = GetElementConverter(elementTypeInfo);
			if (elementConverter.CanUseDirectReadOrWrite && !P_3.Current.NumberHandling.HasValue)
			{
				while (true)
				{
					P_0.ReadWithVerify();
					if (P_0.TokenType == JsonTokenType.EndArray)
					{
						break;
					}
					Add(elementConverter.Read(ref P_0, elementConverter.TypeToConvert, P_2), ref P_3);
				}
			}
			else
			{
				while (true)
				{
					P_0.ReadWithVerify();
					if (P_0.TokenType == JsonTokenType.EndArray)
					{
						break;
					}
					elementConverter.TryRead(ref P_0, typeof(TElement), P_2, ref P_3, out var val);
					Add(in val, ref P_3);
				}
			}
		}
		else
		{
			JsonTypeInfo jsonTypeInfo = P_3.Current.JsonTypeInfo;
			if (P_3.Current.ObjectState == StackFrameObjectState.None)
			{
				if (P_0.TokenType == JsonTokenType.StartArray)
				{
					P_3.Current.ObjectState = StackFrameObjectState.ReadMetadata;
				}
				else if (P_3.Current.CanContainMetadata)
				{
					if (P_0.TokenType != JsonTokenType.StartObject)
					{
						ThrowHelper.ThrowJsonException_DeserializeUnableToConvertValue(TypeToConvert);
					}
					P_3.Current.ObjectState = StackFrameObjectState.StartToken;
				}
				else
				{
					ThrowHelper.ThrowJsonException_DeserializeUnableToConvertValue(TypeToConvert);
				}
				P_3.Current.JsonPropertyInfo = elementTypeInfo.PropertyInfoForTypeInfo;
			}
			if (P_3.Current.CanContainMetadata && (int)P_3.Current.ObjectState < 2)
			{
				if (!JsonSerializer.TryReadMetadata(this, jsonTypeInfo, ref P_0, ref P_3))
				{
					P_4 = default(TCollection);
					return false;
				}
				if (P_3.Current.MetadataPropertyNames == MetadataPropertyName.Ref)
				{
					P_4 = JsonSerializer.ResolveReferenceId<TCollection>(ref P_3);
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
					P_4 = (TCollection)obj;
					P_3.ExitPolymorphicConverter(flag);
					return flag;
				}
			}
			if ((int)P_3.Current.ObjectState < 4)
			{
				if (P_3.Current.CanContainMetadata)
				{
					JsonSerializer.ValidateMetadataForArrayConverter(this, ref P_0, ref P_3);
				}
				CreateCollection(ref P_0, ref P_3, P_2);
				if (P_3.Current.MetadataPropertyNames.HasFlag(MetadataPropertyName.Id))
				{
					P_3.ReferenceResolver.AddReference(P_3.ReferenceId, P_3.Current.ReturnValue);
					P_3.ReferenceId = null;
				}
				P_3.Current.ObjectState = StackFrameObjectState.CreatedObject;
			}
			if ((int)P_3.Current.ObjectState < 5)
			{
				JsonConverter<TElement> elementConverter2 = GetElementConverter(elementTypeInfo);
				while (true)
				{
					if ((int)P_3.Current.PropertyState < 3)
					{
						P_3.Current.PropertyState = StackFramePropertyState.ReadValue;
						if (!JsonConverter.SingleValueReadWithReadAhead(elementConverter2.RequiresReadAhead, ref P_0, ref P_3))
						{
							P_4 = default(TCollection);
							return false;
						}
					}
					if ((int)P_3.Current.PropertyState < 4)
					{
						if (P_0.TokenType == JsonTokenType.EndArray)
						{
							break;
						}
						P_3.Current.PropertyState = StackFramePropertyState.ReadValueIsEnd;
					}
					if ((int)P_3.Current.PropertyState < 5)
					{
						if (!elementConverter2.TryRead(ref P_0, typeof(TElement), P_2, ref P_3, out var val2))
						{
							P_4 = default(TCollection);
							return false;
						}
						Add(in val2, ref P_3);
						P_3.Current.EndElement();
					}
				}
				P_3.Current.ObjectState = StackFrameObjectState.ReadElements;
			}
			if ((int)P_3.Current.ObjectState < 6)
			{
				P_3.Current.ObjectState = StackFrameObjectState.EndToken;
				if (P_3.Current.MetadataPropertyNames.HasFlag(MetadataPropertyName.Values) && !P_0.Read())
				{
					P_4 = default(TCollection);
					return false;
				}
			}
			if ((int)P_3.Current.ObjectState < 7 && P_3.Current.MetadataPropertyNames.HasFlag(MetadataPropertyName.Values) && P_0.TokenType != JsonTokenType.EndObject)
			{
				ThrowHelper.ThrowJsonException_MetadataInvalidPropertyInArrayMetadata(ref P_3, P_1, in P_0);
			}
		}
		ConvertCollection(ref P_3, P_2);
		P_4 = (TCollection)P_3.Current.ReturnValue;
		return true;
	}

	internal override bool OnTryWrite(Utf8JsonWriter P_0, TCollection P_1, JsonSerializerOptions P_2, ref WriteStack P_3)
	{
		bool flag;
		if (P_1 == null)
		{
			P_0.WriteNullValue();
			flag = true;
		}
		else
		{
			if (!P_3.Current.ProcessedStartToken)
			{
				P_3.Current.ProcessedStartToken = true;
				if (P_3.CurrentContainsMetadata && CanHaveMetadata)
				{
					P_3.Current.MetadataPropertyName = JsonSerializer.WriteMetadataForCollection(this, ref P_3, P_0);
				}
				P_0.WriteStartArray();
				P_3.Current.JsonPropertyInfo = P_3.Current.JsonTypeInfo.ElementTypeInfo.PropertyInfoForTypeInfo;
			}
			flag = OnWriteResume(P_0, P_1, P_2, ref P_3);
			if (flag && !P_3.Current.ProcessedEndToken)
			{
				P_3.Current.ProcessedEndToken = true;
				P_0.WriteEndArray();
				if (P_3.Current.MetadataPropertyName != MetadataPropertyName.None)
				{
					P_0.WriteEndObject();
				}
			}
		}
		return flag;
	}

	protected abstract bool OnWriteResume(Utf8JsonWriter P_0, TCollection P_1, JsonSerializerOptions P_2, ref WriteStack P_3);
}
