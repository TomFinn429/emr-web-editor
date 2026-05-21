using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization.Metadata;

namespace System.Text.Json.Serialization.Converters;

internal class ObjectDefaultConverter<T> : JsonObjectConverter<T>
{
	internal override bool CanHaveMetadata => true;

	internal override bool SupportsCreateObjectDelegate => true;

	internal override bool OnTryRead(ref Utf8JsonReader P_0, Type P_1, JsonSerializerOptions P_2, scoped ref ReadStack P_3, [MaybeNullWhen(false)] out T P_4)
	{
		JsonTypeInfo jsonTypeInfo = P_3.Current.JsonTypeInfo;
		object obj;
		if (!P_3.SupportContinuation && !P_3.Current.CanContainMetadata)
		{
			if (P_0.TokenType != JsonTokenType.StartObject)
			{
				ThrowHelper.ThrowJsonException_DeserializeUnableToConvertValue(TypeToConvert);
			}
			if (jsonTypeInfo.CreateObject == null)
			{
				ThrowHelper.ThrowNotSupportedException_DeserializeNoConstructor(jsonTypeInfo.Type, ref P_0, ref P_3);
			}
			obj = jsonTypeInfo.CreateObject();
			jsonTypeInfo.OnDeserializing?.Invoke(obj);
			P_3.Current.InitializeRequiredPropertiesValidationState(jsonTypeInfo);
			while (true)
			{
				P_0.ReadWithVerify();
				JsonTokenType tokenType = P_0.TokenType;
				if (tokenType == JsonTokenType.EndObject)
				{
					break;
				}
				ReadOnlySpan<byte> propertyName = JsonSerializer.GetPropertyName(ref P_3, ref P_0, P_2);
				bool flag;
				JsonPropertyInfo jsonPropertyInfo = JsonSerializer.LookupProperty(obj, propertyName, ref P_3, P_2, out flag);
				ReadPropertyValue(obj, ref P_3, ref P_0, jsonPropertyInfo, flag);
			}
		}
		else
		{
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
					P_4 = default(T);
					return false;
				}
				if (P_3.Current.MetadataPropertyNames == MetadataPropertyName.Ref)
				{
					P_4 = JsonSerializer.ResolveReferenceId<T>(ref P_3);
					return true;
				}
				P_3.Current.ObjectState = StackFrameObjectState.ReadMetadata;
			}
			if (P_3.Current.MetadataPropertyNames.HasFlag(MetadataPropertyName.Type) && P_3.Current.PolymorphicSerializationState != PolymorphicSerializationState.PolymorphicReEntryStarted)
			{
				JsonConverter jsonConverter = ResolvePolymorphicConverter(jsonTypeInfo, P_2, ref P_3);
				if (jsonConverter != null)
				{
					object obj2;
					bool flag2 = jsonConverter.OnTryReadAsObject(ref P_0, P_2, ref P_3, out obj2);
					P_4 = (T)obj2;
					P_3.ExitPolymorphicConverter(flag2);
					return flag2;
				}
			}
			if ((int)P_3.Current.ObjectState < 4)
			{
				if (P_3.Current.CanContainMetadata)
				{
					JsonSerializer.ValidateMetadataForObjectConverter(this, ref P_0, ref P_3);
				}
				if (P_3.Current.MetadataPropertyNames == MetadataPropertyName.Ref)
				{
					P_4 = JsonSerializer.ResolveReferenceId<T>(ref P_3);
					return true;
				}
				if (jsonTypeInfo.CreateObject == null)
				{
					ThrowHelper.ThrowNotSupportedException_DeserializeNoConstructor(jsonTypeInfo.Type, ref P_0, ref P_3);
				}
				obj = jsonTypeInfo.CreateObject();
				if (P_3.Current.MetadataPropertyNames.HasFlag(MetadataPropertyName.Id))
				{
					P_3.ReferenceResolver.AddReference(P_3.ReferenceId, obj);
					P_3.ReferenceId = null;
				}
				jsonTypeInfo.OnDeserializing?.Invoke(obj);
				P_3.Current.ReturnValue = obj;
				P_3.Current.ObjectState = StackFrameObjectState.CreatedObject;
				P_3.Current.InitializeRequiredPropertiesValidationState(jsonTypeInfo);
			}
			else
			{
				obj = P_3.Current.ReturnValue;
			}
			while (true)
			{
				if (P_3.Current.PropertyState == StackFramePropertyState.None)
				{
					P_3.Current.PropertyState = StackFramePropertyState.ReadName;
					if (!P_0.Read())
					{
						P_3.Current.ReturnValue = obj;
						P_4 = default(T);
						return false;
					}
				}
				JsonPropertyInfo jsonPropertyInfo2;
				if ((int)P_3.Current.PropertyState < 2)
				{
					P_3.Current.PropertyState = StackFramePropertyState.Name;
					JsonTokenType tokenType2 = P_0.TokenType;
					if (tokenType2 == JsonTokenType.EndObject)
					{
						break;
					}
					ReadOnlySpan<byte> propertyName2 = JsonSerializer.GetPropertyName(ref P_3, ref P_0, P_2);
					jsonPropertyInfo2 = JsonSerializer.LookupProperty(obj, propertyName2, ref P_3, P_2, out var useExtensionProperty);
					P_3.Current.UseExtensionProperty = useExtensionProperty;
				}
				else
				{
					jsonPropertyInfo2 = P_3.Current.JsonPropertyInfo;
				}
				if ((int)P_3.Current.PropertyState < 3)
				{
					if (!jsonPropertyInfo2.CanDeserialize)
					{
						if (!P_0.TrySkip())
						{
							P_3.Current.ReturnValue = obj;
							P_4 = default(T);
							return false;
						}
						P_3.Current.EndProperty();
						continue;
					}
					if (!ReadAheadPropertyValue(ref P_3, ref P_0, jsonPropertyInfo2))
					{
						P_3.Current.ReturnValue = obj;
						P_4 = default(T);
						return false;
					}
				}
				if ((int)P_3.Current.PropertyState >= 5)
				{
					continue;
				}
				if (!P_3.Current.UseExtensionProperty)
				{
					if (!jsonPropertyInfo2.ReadJsonAndSetMember(obj, ref P_3, ref P_0))
					{
						P_3.Current.ReturnValue = obj;
						P_4 = default(T);
						return false;
					}
				}
				else if (!jsonPropertyInfo2.ReadJsonAndAddExtensionProperty(obj, ref P_3, ref P_0))
				{
					P_3.Current.ReturnValue = obj;
					P_4 = default(T);
					return false;
				}
				P_3.Current.EndProperty();
			}
		}
		jsonTypeInfo.OnDeserialized?.Invoke(obj);
		P_3.Current.ValidateAllRequiredPropertiesAreRead(jsonTypeInfo);
		P_4 = (T)obj;
		if (P_3.Current.PropertyRefCache != null)
		{
			jsonTypeInfo.UpdateSortedPropertyCache(ref P_3.Current);
		}
		return true;
	}

	internal sealed override bool OnTryWrite(Utf8JsonWriter P_0, T P_1, JsonSerializerOptions P_2, ref WriteStack P_3)
	{
		JsonTypeInfo jsonTypeInfo = P_3.Current.JsonTypeInfo;
		object obj = P_1;
		if (!P_3.SupportContinuation)
		{
			P_0.WriteStartObject();
			if (P_3.CurrentContainsMetadata && CanHaveMetadata)
			{
				JsonSerializer.WriteMetadataForObject(this, ref P_3, P_0);
			}
			jsonTypeInfo.OnSerializing?.Invoke(obj);
			List<KeyValuePair<string, JsonPropertyInfo>> list = jsonTypeInfo.PropertyCache.List;
			for (int i = 0; i < list.Count; i++)
			{
				JsonPropertyInfo value = list[i].Value;
				if (value.CanSerialize)
				{
					P_3.Current.JsonPropertyInfo = value;
					P_3.Current.NumberHandling = value.EffectiveNumberHandling;
					bool memberAndWriteJson = value.GetMemberAndWriteJson(obj, ref P_3, P_0);
					P_3.Current.EndProperty();
				}
			}
			JsonPropertyInfo extensionDataProperty = jsonTypeInfo.ExtensionDataProperty;
			if (extensionDataProperty != null && extensionDataProperty.CanSerialize)
			{
				P_3.Current.JsonPropertyInfo = extensionDataProperty;
				P_3.Current.NumberHandling = extensionDataProperty.EffectiveNumberHandling;
				bool memberAndWriteJsonExtensionData = extensionDataProperty.GetMemberAndWriteJsonExtensionData(obj, ref P_3, P_0);
				P_3.Current.EndProperty();
			}
			P_0.WriteEndObject();
		}
		else
		{
			if (!P_3.Current.ProcessedStartToken)
			{
				P_0.WriteStartObject();
				if (P_3.CurrentContainsMetadata && CanHaveMetadata)
				{
					JsonSerializer.WriteMetadataForObject(this, ref P_3, P_0);
				}
				jsonTypeInfo.OnSerializing?.Invoke(obj);
				P_3.Current.ProcessedStartToken = true;
			}
			List<KeyValuePair<string, JsonPropertyInfo>> list2 = jsonTypeInfo.PropertyCache.List;
			while (P_3.Current.EnumeratorIndex < list2.Count)
			{
				JsonPropertyInfo value2 = list2[P_3.Current.EnumeratorIndex].Value;
				if (value2.CanSerialize)
				{
					P_3.Current.JsonPropertyInfo = value2;
					P_3.Current.NumberHandling = value2.EffectiveNumberHandling;
					if (!value2.GetMemberAndWriteJson(obj, ref P_3, P_0))
					{
						return false;
					}
					P_3.Current.EndProperty();
					P_3.Current.EnumeratorIndex++;
					if (JsonConverter.ShouldFlush(P_0, ref P_3))
					{
						return false;
					}
				}
				else
				{
					P_3.Current.EnumeratorIndex++;
				}
			}
			if (P_3.Current.EnumeratorIndex == list2.Count)
			{
				JsonPropertyInfo extensionDataProperty2 = jsonTypeInfo.ExtensionDataProperty;
				if (extensionDataProperty2 != null && extensionDataProperty2.CanSerialize)
				{
					P_3.Current.JsonPropertyInfo = extensionDataProperty2;
					P_3.Current.NumberHandling = extensionDataProperty2.EffectiveNumberHandling;
					if (!extensionDataProperty2.GetMemberAndWriteJsonExtensionData(obj, ref P_3, P_0))
					{
						return false;
					}
					P_3.Current.EndProperty();
					P_3.Current.EnumeratorIndex++;
					if (JsonConverter.ShouldFlush(P_0, ref P_3))
					{
						return false;
					}
				}
				else
				{
					P_3.Current.EnumeratorIndex++;
				}
			}
			if (!P_3.Current.ProcessedEndToken)
			{
				P_3.Current.ProcessedEndToken = true;
				P_0.WriteEndObject();
			}
		}
		jsonTypeInfo.OnSerialized?.Invoke(obj);
		return true;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	protected static void ReadPropertyValue(object P_0, scoped ref ReadStack P_1, ref Utf8JsonReader P_2, JsonPropertyInfo P_3, bool P_4)
	{
		if (!P_3.CanDeserialize)
		{
			P_2.Skip();
		}
		else
		{
			P_2.ReadWithVerify();
			if (!P_4)
			{
				P_3.ReadJsonAndSetMember(P_0, ref P_1, ref P_2);
			}
			else
			{
				P_3.ReadJsonAndAddExtensionProperty(P_0, ref P_1, ref P_2);
			}
		}
		P_1.Current.EndProperty();
	}

	protected static bool ReadAheadPropertyValue(scoped ref ReadStack P_0, ref Utf8JsonReader P_1, JsonPropertyInfo P_2)
	{
		P_0.Current.PropertyState = StackFramePropertyState.ReadValue;
		if (!P_0.Current.UseExtensionProperty)
		{
			if (!JsonConverter.SingleValueReadWithReadAhead(P_2.EffectiveConverter.RequiresReadAhead, ref P_1, ref P_0))
			{
				return false;
			}
		}
		else if (!JsonConverter.SingleValueReadWithReadAhead(true, ref P_1, ref P_0))
		{
			return false;
		}
		return true;
	}
}
