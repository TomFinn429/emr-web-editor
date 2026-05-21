using System.Buffers;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization.Metadata;

namespace System.Text.Json.Serialization.Converters;

internal abstract class ObjectWithParameterizedConstructorConverter<T> : ObjectDefaultConverter<T>
{
	internal sealed override bool ConstructorIsParameterized => true;

	internal sealed override bool OnTryRead(ref Utf8JsonReader P_0, Type P_1, JsonSerializerOptions P_2, scoped ref ReadStack P_3, [MaybeNullWhen(false)] out T P_4)
	{
		JsonTypeInfo jsonTypeInfo = P_3.Current.JsonTypeInfo;
		if (jsonTypeInfo.CreateObject != null)
		{
			return base.OnTryRead(ref P_0, P_1, P_2, ref P_3, out P_4);
		}
		ArgumentState ctorArgumentState = P_3.Current.CtorArgumentState;
		object obj;
		if (!P_3.SupportContinuation && !P_3.Current.CanContainMetadata)
		{
			if (P_0.TokenType != JsonTokenType.StartObject)
			{
				ThrowHelper.ThrowJsonException_DeserializeUnableToConvertValue(TypeToConvert);
			}
			ReadOnlySpan<byte> originalSpan = P_0.OriginalSpan;
			ReadOnlySequence<byte> originalSequence = P_0.OriginalSequence;
			ReadConstructorArguments(ref P_3, ref P_0, P_2);
			obj = (T)CreateObject(ref P_3.Current);
			jsonTypeInfo.OnDeserializing?.Invoke(obj);
			if (ctorArgumentState.FoundPropertyCount > 0)
			{
				(JsonPropertyInfo, JsonReaderState, long, byte[], string)[] foundProperties = ctorArgumentState.FoundProperties;
				for (int i = 0; i < ctorArgumentState.FoundPropertyCount; i++)
				{
					JsonPropertyInfo item = foundProperties[i].Item1;
					long item2 = foundProperties[i].Item3;
					byte[] item3 = foundProperties[i].Item4;
					string item4 = foundProperties[i].Item5;
					Utf8JsonReader utf8JsonReader = (originalSequence.IsEmpty ? new Utf8JsonReader(originalSpan.Slice(checked((int)item2)), true, foundProperties[i].Item2) : new Utf8JsonReader(originalSequence.Slice(item2), true, foundProperties[i].Item2));
					P_3.Current.JsonPropertyName = item3;
					P_3.Current.JsonPropertyInfo = item;
					P_3.Current.NumberHandling = item.EffectiveNumberHandling;
					bool flag = item4 != null;
					if (flag)
					{
						P_3.Current.JsonPropertyNameAsString = item4;
						JsonSerializer.CreateExtensionDataProperty(obj, item, P_2);
					}
					ObjectDefaultConverter<T>.ReadPropertyValue(obj, ref P_3, ref utf8JsonReader, item, flag);
				}
				(JsonPropertyInfo, JsonReaderState, long, byte[], string)[] foundProperties2 = ctorArgumentState.FoundProperties;
				ctorArgumentState.FoundProperties = null;
				ArrayPool<(JsonPropertyInfo, JsonReaderState, long, byte[], string)>.Shared.Return(foundProperties2, true);
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
			if ((int)P_3.Current.ObjectState < 3)
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
				BeginRead(ref P_3, ref P_0, P_2);
				P_3.Current.ObjectState = StackFrameObjectState.ConstructorArguments;
			}
			if (!ReadConstructorArgumentsWithContinuation(ref P_3, ref P_0, P_2))
			{
				P_4 = default(T);
				return false;
			}
			obj = (T)CreateObject(ref P_3.Current);
			if (P_3.Current.MetadataPropertyNames.HasFlag(MetadataPropertyName.Id))
			{
				P_3.ReferenceResolver.AddReference(P_3.ReferenceId, obj);
				P_3.ReferenceId = null;
			}
			jsonTypeInfo.OnDeserializing?.Invoke(obj);
			if (ctorArgumentState.FoundPropertyCount > 0)
			{
				for (int j = 0; j < ctorArgumentState.FoundPropertyCount; j++)
				{
					JsonPropertyInfo item5 = ctorArgumentState.FoundPropertiesAsync[j].Item1;
					object item6 = ctorArgumentState.FoundPropertiesAsync[j].Item2;
					string item7 = ctorArgumentState.FoundPropertiesAsync[j].Item3;
					if (item7 == null)
					{
						if (item6 != null || !item5.IgnoreNullTokensOnRead || default(T) != null)
						{
							item5.Set(obj, item6);
							P_3.Current.MarkRequiredPropertyAsRead(item5);
						}
						continue;
					}
					JsonSerializer.CreateExtensionDataProperty(obj, item5, P_2);
					object valueAsObject = item5.GetValueAsObject(obj);
					if (valueAsObject is IDictionary<string, JsonElement> dictionary)
					{
						dictionary[item7] = (JsonElement)item6;
					}
					else
					{
						((IDictionary<string, object>)valueAsObject)[item7] = item6;
					}
				}
				(JsonPropertyInfo, object, string)[] foundPropertiesAsync = ctorArgumentState.FoundPropertiesAsync;
				ctorArgumentState.FoundPropertiesAsync = null;
				ArrayPool<(JsonPropertyInfo, object, string)>.Shared.Return(foundPropertiesAsync, true);
			}
		}
		jsonTypeInfo.OnDeserialized?.Invoke(obj);
		P_3.Current.ValidateAllRequiredPropertiesAreRead(jsonTypeInfo);
		P_4 = (T)obj;
		if (P_3.Current.PropertyRefCache != null)
		{
			P_3.Current.JsonTypeInfo.UpdateSortedPropertyCache(ref P_3.Current);
		}
		if (ctorArgumentState.ParameterRefCache != null)
		{
			P_3.Current.JsonTypeInfo.UpdateSortedParameterCache(ref P_3.Current);
		}
		return true;
	}

	protected abstract void InitializeConstructorArgumentCaches(ref ReadStack P_0, JsonSerializerOptions P_1);

	protected abstract bool ReadAndCacheConstructorArgument(scoped ref ReadStack P_0, ref Utf8JsonReader P_1, JsonParameterInfo P_2);

	protected abstract object CreateObject(ref ReadStackFrame P_0);

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void ReadConstructorArguments(scoped ref ReadStack P_0, ref Utf8JsonReader P_1, JsonSerializerOptions P_2)
	{
		BeginRead(ref P_0, ref P_1, P_2);
		while (true)
		{
			P_1.ReadWithVerify();
			JsonTokenType tokenType = P_1.TokenType;
			if (tokenType == JsonTokenType.EndObject)
			{
				break;
			}
			if (TryLookupConstructorParameter(ref P_0, ref P_1, P_2, out var jsonParameterInfo))
			{
				P_1.ReadWithVerify();
				if (!jsonParameterInfo.ShouldDeserialize)
				{
					P_1.Skip();
					P_0.Current.EndConstructorParameter();
				}
				else
				{
					ReadAndCacheConstructorArgument(ref P_0, ref P_1, jsonParameterInfo);
					P_0.Current.EndConstructorParameter();
				}
				continue;
			}
			ReadOnlySpan<byte> propertyName = JsonSerializer.GetPropertyName(ref P_0, ref P_1, P_2);
			bool flag;
			JsonPropertyInfo jsonPropertyInfo = JsonSerializer.LookupProperty(null, propertyName, ref P_0, P_2, out flag, false);
			if (jsonPropertyInfo.CanDeserialize)
			{
				ArgumentState ctorArgumentState = P_0.Current.CtorArgumentState;
				if (ctorArgumentState.FoundProperties == null)
				{
					ctorArgumentState.FoundProperties = ArrayPool<(JsonPropertyInfo, JsonReaderState, long, byte[], string)>.Shared.Rent(Math.Max(1, P_0.Current.JsonTypeInfo.PropertyCache.Count));
				}
				else if (ctorArgumentState.FoundPropertyCount == ctorArgumentState.FoundProperties.Length)
				{
					(JsonPropertyInfo, JsonReaderState, long, byte[], string)[] array = ArrayPool<(JsonPropertyInfo, JsonReaderState, long, byte[], string)>.Shared.Rent(ctorArgumentState.FoundProperties.Length * 2);
					ctorArgumentState.FoundProperties.CopyTo(array, 0);
					(JsonPropertyInfo, JsonReaderState, long, byte[], string)[] foundProperties = ctorArgumentState.FoundProperties;
					ctorArgumentState.FoundProperties = array;
					ArrayPool<(JsonPropertyInfo, JsonReaderState, long, byte[], string)>.Shared.Return(foundProperties, true);
				}
				ctorArgumentState.FoundProperties[ctorArgumentState.FoundPropertyCount++] = (jsonPropertyInfo, P_1.CurrentState, P_1.BytesConsumed, P_0.Current.JsonPropertyName, P_0.Current.JsonPropertyNameAsString);
			}
			P_1.Skip();
			P_0.Current.EndProperty();
		}
	}

	private bool ReadConstructorArgumentsWithContinuation(scoped ref ReadStack P_0, ref Utf8JsonReader P_1, JsonSerializerOptions P_2)
	{
		while (true)
		{
			if (P_0.Current.PropertyState == StackFramePropertyState.None)
			{
				P_0.Current.PropertyState = StackFramePropertyState.ReadName;
				if (!P_1.Read())
				{
					return false;
				}
			}
			JsonParameterInfo jsonParameterInfo;
			JsonPropertyInfo jsonPropertyInfo;
			if ((int)P_0.Current.PropertyState < 2)
			{
				P_0.Current.PropertyState = StackFramePropertyState.Name;
				JsonTokenType tokenType = P_1.TokenType;
				if (tokenType == JsonTokenType.EndObject)
				{
					return true;
				}
				if (TryLookupConstructorParameter(ref P_0, ref P_1, P_2, out jsonParameterInfo))
				{
					jsonPropertyInfo = null;
				}
				else
				{
					ReadOnlySpan<byte> propertyName = JsonSerializer.GetPropertyName(ref P_0, ref P_1, P_2);
					jsonPropertyInfo = JsonSerializer.LookupProperty(null, propertyName, ref P_0, P_2, out var useExtensionProperty, false);
					P_0.Current.UseExtensionProperty = useExtensionProperty;
				}
			}
			else
			{
				jsonParameterInfo = P_0.Current.CtorArgumentState.JsonParameterInfo;
				jsonPropertyInfo = P_0.Current.JsonPropertyInfo;
			}
			if (jsonParameterInfo != null)
			{
				if (!HandleConstructorArgumentWithContinuation(ref P_0, ref P_1, jsonParameterInfo))
				{
					return false;
				}
			}
			else if (!HandlePropertyWithContinuation(ref P_0, ref P_1, jsonPropertyInfo))
			{
				break;
			}
		}
		return false;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private bool HandleConstructorArgumentWithContinuation(scoped ref ReadStack P_0, ref Utf8JsonReader P_1, JsonParameterInfo P_2)
	{
		if ((int)P_0.Current.PropertyState < 3)
		{
			if (!P_2.ShouldDeserialize)
			{
				if (!P_1.TrySkip())
				{
					return false;
				}
				P_0.Current.EndConstructorParameter();
				return true;
			}
			P_0.Current.PropertyState = StackFramePropertyState.ReadValue;
			if (!JsonConverter.SingleValueReadWithReadAhead(P_2.ConverterBase.RequiresReadAhead, ref P_1, ref P_0))
			{
				return false;
			}
		}
		if (!ReadAndCacheConstructorArgument(ref P_0, ref P_1, P_2))
		{
			return false;
		}
		P_0.Current.EndConstructorParameter();
		return true;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static bool HandlePropertyWithContinuation(scoped ref ReadStack P_0, ref Utf8JsonReader P_1, JsonPropertyInfo P_2)
	{
		if ((int)P_0.Current.PropertyState < 3)
		{
			if (!P_2.CanDeserialize)
			{
				if (!P_1.TrySkip())
				{
					return false;
				}
				P_0.Current.EndProperty();
				return true;
			}
			if (!ObjectDefaultConverter<T>.ReadAheadPropertyValue(ref P_0, ref P_1, P_2))
			{
				return false;
			}
		}
		object obj;
		if (P_0.Current.UseExtensionProperty)
		{
			if (!P_2.ReadJsonExtensionDataValue(ref P_0, ref P_1, out obj))
			{
				return false;
			}
		}
		else if (!P_2.ReadJsonAsObject(ref P_0, ref P_1, out obj))
		{
			return false;
		}
		ArgumentState ctorArgumentState = P_0.Current.CtorArgumentState;
		if (ctorArgumentState.FoundPropertiesAsync == null)
		{
			ctorArgumentState.FoundPropertiesAsync = ArrayPool<(JsonPropertyInfo, object, string)>.Shared.Rent(Math.Max(1, P_0.Current.JsonTypeInfo.PropertyCache.Count));
		}
		else if (ctorArgumentState.FoundPropertyCount == ctorArgumentState.FoundPropertiesAsync.Length)
		{
			(JsonPropertyInfo, object, string)[] array = ArrayPool<(JsonPropertyInfo, object, string)>.Shared.Rent(ctorArgumentState.FoundPropertiesAsync.Length * 2);
			ctorArgumentState.FoundPropertiesAsync.CopyTo(array, 0);
			(JsonPropertyInfo, object, string)[] foundPropertiesAsync = ctorArgumentState.FoundPropertiesAsync;
			ctorArgumentState.FoundPropertiesAsync = array;
			ArrayPool<(JsonPropertyInfo, object, string)>.Shared.Return(foundPropertiesAsync, true);
		}
		ctorArgumentState.FoundPropertiesAsync[ctorArgumentState.FoundPropertyCount++] = (P_2, obj, P_0.Current.JsonPropertyNameAsString);
		P_0.Current.EndProperty();
		return true;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void BeginRead(scoped ref ReadStack P_0, ref Utf8JsonReader P_1, JsonSerializerOptions P_2)
	{
		JsonTypeInfo jsonTypeInfo = P_0.Current.JsonTypeInfo;
		jsonTypeInfo.ValidateCanBeUsedForMetadataSerialization();
		if (jsonTypeInfo.ParameterCount != jsonTypeInfo.ParameterCache.Count)
		{
			ThrowHelper.ThrowInvalidOperationException_ConstructorParameterIncompleteBinding(TypeToConvert);
		}
		P_0.Current.InitializeRequiredPropertiesValidationState(jsonTypeInfo);
		P_0.Current.JsonPropertyInfo = null;
		InitializeConstructorArgumentCaches(ref P_0, P_2);
	}

	protected virtual bool TryLookupConstructorParameter(scoped ref ReadStack P_0, ref Utf8JsonReader P_1, JsonSerializerOptions P_2, out JsonParameterInfo P_3)
	{
		ReadOnlySpan<byte> propertyName = JsonSerializer.GetPropertyName(ref P_0, ref P_1, P_2);
		P_3 = P_0.Current.JsonTypeInfo.GetParameter(propertyName, ref P_0.Current, out var jsonPropertyName);
		P_0.Current.CtorArgumentState.ParameterIndex++;
		P_0.Current.JsonPropertyName = jsonPropertyName;
		P_0.Current.CtorArgumentState.JsonParameterInfo = P_3;
		P_0.Current.NumberHandling = P_3?.NumberHandling;
		return P_3 != null;
	}
}
