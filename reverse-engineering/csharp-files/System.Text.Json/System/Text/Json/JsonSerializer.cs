using System.Buffers;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using System.Text.Json.Serialization.Metadata;

namespace System.Text.Json;

public static class JsonSerializer
{
	internal static readonly byte[] s_idPropertyName = Encoding.UTF8.GetBytes("$id");

	internal static readonly byte[] s_refPropertyName = Encoding.UTF8.GetBytes("$ref");

	internal static readonly byte[] s_typePropertyName = Encoding.UTF8.GetBytes("$type");

	internal static readonly byte[] s_valuesPropertyName = Encoding.UTF8.GetBytes("$values");

	internal static readonly JsonEncodedText s_metadataId = JsonEncodedText.Encode("$id");

	internal static readonly JsonEncodedText s_metadataRef = JsonEncodedText.Encode("$ref");

	internal static readonly JsonEncodedText s_metadataType = JsonEncodedText.Encode("$type");

	internal static readonly JsonEncodedText s_metadataValues = JsonEncodedText.Encode("$values");

	[RequiresUnreferencedCode("JSON serialization and deserialization might require types that cannot be statically analyzed. Use the overload that takes a JsonTypeInfo or JsonSerializerContext, or make sure all of the required types are preserved.")]
	[RequiresDynamicCode("JSON serialization and deserialization might require types that cannot be statically analyzed and might need runtime code generation. Use System.Text.Json source generation for native AOT applications.")]
	public static JsonElement SerializeToElement<TValue>(TValue P_0, JsonSerializerOptions? P_1 = null)
	{
		JsonTypeInfo<TValue> typeInfo = GetTypeInfo<TValue>(P_1);
		return WriteElement<TValue>(in P_0, typeInfo);
	}

	private static JsonElement WriteElement<TValue>(in TValue P_0, JsonTypeInfo<TValue> P_1)
	{
		JsonSerializerOptions options = P_1.Options;
		PooledByteBufferWriter pooledByteBufferWriter;
		Utf8JsonWriter utf8JsonWriter = Utf8JsonWriterCache.RentWriterAndBuffer(P_1.Options, out pooledByteBufferWriter);
		try
		{
			WriteCore(utf8JsonWriter, in P_0, P_1);
			return JsonElement.ParseValue(pooledByteBufferWriter.WrittenMemory.Span, options.GetDocumentOptions());
		}
		finally
		{
			Utf8JsonWriterCache.ReturnWriterAndBuffer(utf8JsonWriter, pooledByteBufferWriter);
		}
	}

	[RequiresUnreferencedCode("JSON serialization and deserialization might require types that cannot be statically analyzed. Use the overload that takes a JsonTypeInfo or JsonSerializerContext, or make sure all of the required types are preserved.")]
	[RequiresDynamicCode("JSON serialization and deserialization might require types that cannot be statically analyzed and might need runtime code generation. Use System.Text.Json source generation for native AOT applications.")]
	private static JsonTypeInfo GetTypeInfo(JsonSerializerOptions P_0, Type P_1)
	{
		if (P_0 == null)
		{
			P_0 = JsonSerializerOptions.Default;
		}
		if (!P_0.IsInitializedForReflectionSerializer)
		{
			P_0.InitializeForReflectionSerializer();
		}
		if (!(P_1 == JsonTypeInfo.ObjectType))
		{
			return P_0.GetTypeInfoForRootType(P_1);
		}
		return P_0.ObjectTypeInfo;
	}

	[RequiresUnreferencedCode("JSON serialization and deserialization might require types that cannot be statically analyzed. Use the overload that takes a JsonTypeInfo or JsonSerializerContext, or make sure all of the required types are preserved.")]
	[RequiresDynamicCode("JSON serialization and deserialization might require types that cannot be statically analyzed and might need runtime code generation. Use System.Text.Json source generation for native AOT applications.")]
	private static JsonTypeInfo<T> GetTypeInfo<T>(JsonSerializerOptions P_0)
	{
		return (JsonTypeInfo<T>)GetTypeInfo(P_0, typeof(T));
	}

	internal static bool TryReadMetadata(JsonConverter P_0, JsonTypeInfo P_1, ref Utf8JsonReader P_2, scoped ref ReadStack P_3)
	{
		while (true)
		{
			if (P_3.Current.PropertyState == StackFramePropertyState.None)
			{
				P_3.Current.PropertyState = StackFramePropertyState.ReadName;
				if (!P_2.Read())
				{
					return false;
				}
			}
			if ((int)P_3.Current.PropertyState < 2)
			{
				if (P_2.TokenType == JsonTokenType.EndObject)
				{
					return true;
				}
				if (P_3.Current.MetadataPropertyNames.HasFlag(MetadataPropertyName.Ref))
				{
					ThrowHelper.ThrowJsonException_MetadataReferenceObjectCannotContainOtherProperties(P_2.GetSpan(), ref P_3);
				}
				ReadOnlySpan<byte> span = P_2.GetSpan();
				switch (P_3.Current.LatestMetadataPropertyName = GetMetadataPropertyName(span, P_1.PolymorphicTypeResolver))
				{
				case MetadataPropertyName.Id:
					P_3.Current.JsonPropertyName = s_idPropertyName;
					if (P_3.ReferenceResolver == null)
					{
						ThrowHelper.ThrowJsonException_MetadataUnexpectedProperty(span, ref P_3);
					}
					if ((P_3.Current.MetadataPropertyNames & (MetadataPropertyName.Id | MetadataPropertyName.Ref)) != MetadataPropertyName.None)
					{
						ThrowHelper.ThrowJsonException_MetadataIdIsNotFirstProperty(span, ref P_3);
					}
					if (!P_0.CanHaveMetadata)
					{
						ThrowHelper.ThrowJsonException_MetadataCannotParsePreservedObjectIntoImmutable(P_0.TypeToConvert);
					}
					break;
				case MetadataPropertyName.Ref:
					P_3.Current.JsonPropertyName = s_refPropertyName;
					if (P_3.ReferenceResolver == null)
					{
						ThrowHelper.ThrowJsonException_MetadataUnexpectedProperty(span, ref P_3);
					}
					if (P_0.IsValueType)
					{
						ThrowHelper.ThrowJsonException_MetadataInvalidReferenceToValueType(P_0.TypeToConvert);
					}
					if (P_3.Current.MetadataPropertyNames != MetadataPropertyName.None)
					{
						ThrowHelper.ThrowJsonException_MetadataReferenceObjectCannotContainOtherProperties(P_2.GetSpan(), ref P_3);
					}
					break;
				case MetadataPropertyName.Type:
					P_3.Current.JsonPropertyName = P_1.PolymorphicTypeResolver?.TypeDiscriminatorPropertyNameUtf8 ?? s_typePropertyName;
					if (P_1.PolymorphicTypeResolver == null)
					{
						ThrowHelper.ThrowJsonException_MetadataUnexpectedProperty(span, ref P_3);
					}
					if (P_3.PolymorphicTypeDiscriminator != null)
					{
						ThrowHelper.ThrowJsonException_MetadataDuplicateTypeProperty();
					}
					break;
				case MetadataPropertyName.Values:
					P_3.Current.JsonPropertyName = s_valuesPropertyName;
					if (P_3.Current.MetadataPropertyNames == MetadataPropertyName.None)
					{
						ThrowHelper.ThrowJsonException_MetadataStandaloneValuesProperty(ref P_3, span);
					}
					break;
				default:
					return true;
				}
				P_3.Current.PropertyState = StackFramePropertyState.Name;
			}
			if ((int)P_3.Current.PropertyState < 3)
			{
				P_3.Current.PropertyState = StackFramePropertyState.ReadValue;
				if (!P_2.Read())
				{
					break;
				}
			}
			switch (P_3.Current.LatestMetadataPropertyName)
			{
			case MetadataPropertyName.Id:
				if (P_2.TokenType != JsonTokenType.String)
				{
					ThrowHelper.ThrowJsonException_MetadataValueWasNotString(P_2.TokenType);
				}
				if (P_3.ReferenceId != null)
				{
					ThrowHelper.ThrowNotSupportedException_ObjectWithParameterizedCtorRefMetadataNotSupported(s_refPropertyName, ref P_2, ref P_3);
				}
				P_3.ReferenceId = P_2.GetString();
				break;
			case MetadataPropertyName.Ref:
				if (P_2.TokenType != JsonTokenType.String)
				{
					ThrowHelper.ThrowJsonException_MetadataValueWasNotString(P_2.TokenType);
				}
				if (P_3.ReferenceId != null)
				{
					ThrowHelper.ThrowNotSupportedException_ObjectWithParameterizedCtorRefMetadataNotSupported(s_refPropertyName, ref P_2, ref P_3);
				}
				P_3.ReferenceId = P_2.GetString();
				break;
			case MetadataPropertyName.Type:
				switch (P_2.TokenType)
				{
				case JsonTokenType.String:
					P_3.PolymorphicTypeDiscriminator = P_2.GetString();
					break;
				case JsonTokenType.Number:
					P_3.PolymorphicTypeDiscriminator = P_2.GetInt32();
					break;
				default:
					ThrowHelper.ThrowJsonException_MetadataValueWasNotString(P_2.TokenType);
					break;
				}
				break;
			case MetadataPropertyName.Values:
				if (P_2.TokenType != JsonTokenType.StartArray)
				{
					ThrowHelper.ThrowJsonException_MetadataValuesInvalidToken(P_2.TokenType);
				}
				P_3.Current.PropertyState = StackFramePropertyState.None;
				P_3.Current.MetadataPropertyNames |= P_3.Current.LatestMetadataPropertyName;
				return true;
			}
			P_3.Current.MetadataPropertyNames |= P_3.Current.LatestMetadataPropertyName;
			P_3.Current.PropertyState = StackFramePropertyState.None;
			P_3.Current.JsonPropertyName = null;
		}
		return false;
	}

	internal static bool IsMetadataPropertyName(ReadOnlySpan<byte> P_0, PolymorphicTypeResolver P_1)
	{
		if (P_0.Length <= 0 || P_0[0] != 36)
		{
			if (P_1 == null)
			{
				return false;
			}
			return P_1.TypeDiscriminatorPropertyNameUtf8?.AsSpan().SequenceEqual(P_0) == true;
		}
		return true;
	}

	internal static MetadataPropertyName GetMetadataPropertyName(ReadOnlySpan<byte> P_0, PolymorphicTypeResolver P_1)
	{
		if (P_0.Length > 0 && P_0[0] == 36)
		{
			switch (P_0.Length)
			{
			case 3:
				if (P_0[1] == 105 && P_0[2] == 100)
				{
					return MetadataPropertyName.Id;
				}
				break;
			case 4:
				if (P_0[1] == 114 && P_0[2] == 101 && P_0[3] == 102)
				{
					return MetadataPropertyName.Ref;
				}
				break;
			case 5:
				if (P_1?.TypeDiscriminatorPropertyNameUtf8 == null && P_0[1] == 116 && P_0[2] == 121 && P_0[3] == 112 && P_0[4] == 101)
				{
					return MetadataPropertyName.Type;
				}
				break;
			case 7:
				if (P_0[1] == 118 && P_0[2] == 97 && P_0[3] == 108 && P_0[4] == 117 && P_0[5] == 101 && P_0[6] == 115)
				{
					return MetadataPropertyName.Values;
				}
				break;
			}
		}
		byte[] array = P_1?.TypeDiscriminatorPropertyNameUtf8;
		if (array != null && P_0.SequenceEqual(array))
		{
			return MetadataPropertyName.Type;
		}
		return MetadataPropertyName.None;
	}

	internal static bool TryHandleReferenceFromJsonElement(ref Utf8JsonReader P_0, scoped ref ReadStack P_1, JsonElement P_2, [NotNullWhen(true)] out object P_3)
	{
		bool flag = false;
		P_3 = null;
		if (P_2.ValueKind == JsonValueKind.Object)
		{
			int num = 0;
			foreach (JsonProperty item in P_2.EnumerateObject())
			{
				num++;
				if (flag)
				{
					ThrowHelper.ThrowJsonException_MetadataReferenceObjectCannotContainOtherProperties();
					continue;
				}
				if (item.EscapedNameEquals(s_idPropertyName))
				{
					if (P_1.ReferenceId != null)
					{
						ThrowHelper.ThrowNotSupportedException_ObjectWithParameterizedCtorRefMetadataNotSupported(s_refPropertyName, ref P_0, ref P_1);
					}
					if (item.Value.ValueKind != JsonValueKind.String)
					{
						ThrowHelper.ThrowJsonException_MetadataValueWasNotString(item.Value.ValueKind);
					}
					object obj = P_2;
					P_1.ReferenceResolver.AddReference(item.Value.GetString(), obj);
					P_3 = obj;
					return true;
				}
				if (item.EscapedNameEquals(s_refPropertyName))
				{
					if (P_1.ReferenceId != null)
					{
						ThrowHelper.ThrowNotSupportedException_ObjectWithParameterizedCtorRefMetadataNotSupported(s_refPropertyName, ref P_0, ref P_1);
					}
					if (num > 1)
					{
						ThrowHelper.ThrowJsonException_MetadataReferenceObjectCannotContainOtherProperties();
					}
					if (item.Value.ValueKind != JsonValueKind.String)
					{
						ThrowHelper.ThrowJsonException_MetadataValueWasNotString(item.Value.ValueKind);
					}
					P_3 = P_1.ReferenceResolver.ResolveReference(item.Value.GetString());
					flag = true;
				}
			}
		}
		return flag;
	}

	internal static bool TryHandleReferenceFromJsonNode(ref Utf8JsonReader P_0, scoped ref ReadStack P_1, JsonNode P_2, [NotNullWhen(true)] out object P_3)
	{
		bool flag = false;
		P_3 = null;
		if (P_2 is JsonObject jsonObject)
		{
			int num = 0;
			foreach (KeyValuePair<string, JsonNode> item in jsonObject)
			{
				num++;
				if (flag)
				{
					ThrowHelper.ThrowJsonException_MetadataReferenceObjectCannotContainOtherProperties();
					continue;
				}
				if (item.Key == "$id")
				{
					if (P_1.ReferenceId != null)
					{
						ThrowHelper.ThrowNotSupportedException_ObjectWithParameterizedCtorRefMetadataNotSupported(s_refPropertyName, ref P_0, ref P_1);
					}
					string text = ReadAsStringMetadataValue(item.Value);
					P_1.ReferenceResolver.AddReference(text, P_2);
					P_3 = P_2;
					return true;
				}
				if (item.Key == "$ref")
				{
					if (P_1.ReferenceId != null)
					{
						ThrowHelper.ThrowNotSupportedException_ObjectWithParameterizedCtorRefMetadataNotSupported(s_refPropertyName, ref P_0, ref P_1);
					}
					if (num > 1)
					{
						ThrowHelper.ThrowJsonException_MetadataReferenceObjectCannotContainOtherProperties();
					}
					string text2 = ReadAsStringMetadataValue(item.Value);
					P_3 = P_1.ReferenceResolver.ResolveReference(text2);
					flag = true;
				}
			}
		}
		return flag;
		static string ReadAsStringMetadataValue(JsonNode jsonNode)
		{
			if (jsonNode is JsonValue jsonValue && jsonValue.TryGetValue<string>(out string text3) && text3 != null)
			{
				return text3;
			}
			JsonValueKind jsonValueKind = ((jsonNode == null) ? JsonValueKind.Null : ((jsonNode is JsonObject) ? JsonValueKind.Object : ((jsonNode is JsonArray) ? JsonValueKind.Array : ((jsonNode is JsonValue<JsonElement> { Value: var value }) ? value.ValueKind : JsonValueKind.Undefined))));
			JsonValueKind jsonValueKind2 = jsonValueKind;
			ThrowHelper.ThrowJsonException_MetadataValueWasNotString(jsonValueKind2);
			return null;
		}
	}

	internal static void ValidateMetadataForObjectConverter(JsonConverter P_0, ref Utf8JsonReader P_1, scoped ref ReadStack P_2)
	{
		if (P_2.Current.MetadataPropertyNames.HasFlag(MetadataPropertyName.Values))
		{
			ThrowHelper.ThrowJsonException_MetadataUnexpectedProperty(s_valuesPropertyName, ref P_2);
		}
	}

	internal static void ValidateMetadataForArrayConverter(JsonConverter P_0, ref Utf8JsonReader P_1, scoped ref ReadStack P_2)
	{
		switch (P_1.TokenType)
		{
		case JsonTokenType.EndObject:
			if (P_2.Current.MetadataPropertyNames != MetadataPropertyName.Ref)
			{
				ThrowHelper.ThrowJsonException_MetadataPreservedArrayValuesNotFound(ref P_2, P_0.TypeToConvert);
			}
			break;
		default:
			ThrowHelper.ThrowJsonException_MetadataInvalidPropertyInArrayMetadata(ref P_2, P_0.TypeToConvert, in P_1);
			break;
		case JsonTokenType.StartArray:
			break;
		}
	}

	internal static T ResolveReferenceId<T>(ref ReadStack P_0)
	{
		string referenceId = P_0.ReferenceId;
		object obj = P_0.ReferenceResolver.ResolveReference(referenceId);
		P_0.ReferenceId = null;
		try
		{
			return (T)obj;
		}
		catch (InvalidCastException)
		{
			ThrowHelper.ThrowInvalidOperationException_MetadataReferenceOfTypeCannotBeAssignedToType(referenceId, obj.GetType(), typeof(T));
			return default(T);
		}
	}

	internal static JsonPropertyInfo LookupProperty(object P_0, ReadOnlySpan<byte> P_1, ref ReadStack P_2, JsonSerializerOptions P_3, out bool P_4, bool P_5 = true)
	{
		P_4 = false;
		byte[] jsonPropertyName;
		JsonPropertyInfo jsonPropertyInfo = P_2.Current.JsonTypeInfo.GetProperty(P_1, ref P_2.Current, out jsonPropertyName);
		P_2.Current.PropertyIndex++;
		P_2.Current.JsonPropertyName = jsonPropertyName;
		if (jsonPropertyInfo == JsonPropertyInfo.s_missingProperty)
		{
			JsonPropertyInfo extensionDataProperty = P_2.Current.JsonTypeInfo.ExtensionDataProperty;
			if (extensionDataProperty != null && extensionDataProperty.HasGetter && extensionDataProperty.HasSetter)
			{
				P_2.Current.JsonPropertyNameAsString = JsonHelpers.Utf8GetString(P_1);
				if (P_5)
				{
					CreateExtensionDataProperty(P_0, extensionDataProperty, P_3);
				}
				jsonPropertyInfo = extensionDataProperty;
				P_4 = true;
			}
		}
		P_2.Current.JsonPropertyInfo = jsonPropertyInfo;
		P_2.Current.NumberHandling = jsonPropertyInfo.EffectiveNumberHandling;
		return jsonPropertyInfo;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal static ReadOnlySpan<byte> GetPropertyName(scoped ref ReadStack P_0, ref Utf8JsonReader P_1, JsonSerializerOptions P_2)
	{
		ReadOnlySpan<byte> span = P_1.GetSpan();
		ReadOnlySpan<byte> result = ((!P_1.ValueIsEscaped) ? span : JsonReaderHelper.GetUnescapedSpan(span));
		if (P_0.Current.CanContainMetadata && IsMetadataPropertyName(span, P_0.Current.BaseJsonTypeInfo.PolymorphicTypeResolver))
		{
			ThrowHelper.ThrowUnexpectedMetadataException(span, ref P_1, ref P_0);
		}
		return result;
	}

	internal static void CreateExtensionDataProperty(object P_0, JsonPropertyInfo P_1, JsonSerializerOptions P_2)
	{
		object valueAsObject = P_1.GetValueAsObject(P_0);
		if (valueAsObject != null)
		{
			return;
		}
		Func<object> func = P_1.JsonTypeInfo.CreateObject ?? P_1.JsonTypeInfo.CreateObjectForExtensionDataProperty;
		if (func == null)
		{
			if (P_1.PropertyType.FullName == "System.Text.Json.Nodes.JsonObject")
			{
				ThrowHelper.ThrowInvalidOperationException_NodeJsonObjectCustomConverterNotAllowedOnExtensionProperty();
			}
			else
			{
				ThrowHelper.ThrowNotSupportedException_SerializationNotSupported(P_1.PropertyType);
			}
		}
		valueAsObject = func();
		P_1.Set(P_0, valueAsObject);
	}

	private static TValue ReadCore<TValue>(ref Utf8JsonReader P_0, JsonTypeInfo P_1, scoped ref ReadStack P_2)
	{
		if (P_1 is JsonTypeInfo<TValue> jsonTypeInfo)
		{
			return jsonTypeInfo.EffectiveConverter.ReadCore(ref P_0, jsonTypeInfo.Options, ref P_2);
		}
		object obj = P_1.Converter.ReadCoreAsObject(ref P_0, P_1.Options, ref P_2);
		return (TValue)obj;
	}

	private static TValue ReadFromSpan<TValue>(ReadOnlySpan<byte> P_0, JsonTypeInfo P_1, int? P_2 = null)
	{
		JsonSerializerOptions options = P_1.Options;
		JsonReaderState jsonReaderState = new JsonReaderState(options.GetReaderOptions());
		Utf8JsonReader utf8JsonReader = new Utf8JsonReader(P_0, true, jsonReaderState);
		ReadStack readStack = default(ReadStack);
		readStack.Initialize(P_1);
		if (P_1 is JsonTypeInfo<TValue> jsonTypeInfo)
		{
			return jsonTypeInfo.EffectiveConverter.ReadCore(ref utf8JsonReader, options, ref readStack);
		}
		object obj = P_1.Converter.ReadCoreAsObject(ref utf8JsonReader, options, ref readStack);
		return (TValue)obj;
	}

	[RequiresUnreferencedCode("JSON serialization and deserialization might require types that cannot be statically analyzed. Use the overload that takes a JsonTypeInfo or JsonSerializerContext, or make sure all of the required types are preserved.")]
	[RequiresDynamicCode("JSON serialization and deserialization might require types that cannot be statically analyzed and might need runtime code generation. Use System.Text.Json source generation for native AOT applications.")]
	public static TValue? Deserialize<TValue>([StringSyntax("Json")] string P_0, JsonSerializerOptions? P_1 = null)
	{
		if (P_0 == null)
		{
			ThrowHelper.ThrowArgumentNullException("json");
		}
		JsonTypeInfo typeInfo = GetTypeInfo(P_1, typeof(TValue));
		return ReadFromSpan<TValue>(P_0.AsSpan(), typeInfo);
	}

	private static TValue ReadFromSpan<TValue>(ReadOnlySpan<char> P_0, JsonTypeInfo P_1)
	{
		byte[] array = null;
		Span<byte> span = (((long)P_0.Length > 349525L) ? new byte[JsonReaderHelper.GetUtf8ByteCount(P_0)] : (array = ArrayPool<byte>.Shared.Rent(P_0.Length * 3)));
		try
		{
			int utf8FromText = JsonReaderHelper.GetUtf8FromText(P_0, span);
			span = span.Slice(0, utf8FromText);
			return ReadFromSpan<TValue>(span, P_1, utf8FromText);
		}
		finally
		{
			if (array != null)
			{
				span.Clear();
				ArrayPool<byte>.Shared.Return(array);
			}
		}
	}

	[RequiresUnreferencedCode("JSON serialization and deserialization might require types that cannot be statically analyzed. Use the overload that takes a JsonTypeInfo or JsonSerializerContext, or make sure all of the required types are preserved.")]
	[RequiresDynamicCode("JSON serialization and deserialization might require types that cannot be statically analyzed and might need runtime code generation. Use System.Text.Json source generation for native AOT applications.")]
	public static object? Deserialize(ref Utf8JsonReader P_0, Type P_1, JsonSerializerOptions? P_2 = null)
	{
		if ((object)P_1 == null)
		{
			ThrowHelper.ThrowArgumentNullException("returnType");
		}
		JsonTypeInfo typeInfo = GetTypeInfo(P_2, P_1);
		return Read<object>(ref P_0, typeInfo);
	}

	private static TValue Read<TValue>(ref Utf8JsonReader P_0, JsonTypeInfo P_1)
	{
		if (P_0.CurrentState.Options.CommentHandling == JsonCommentHandling.Allow)
		{
			ThrowHelper.ThrowArgumentException_SerializerDoesNotSupportComments("reader");
		}
		ReadStack readStack = default(ReadStack);
		readStack.Initialize(P_1);
		Utf8JsonReader utf8JsonReader = P_0;
		try
		{
			Utf8JsonReader readerScopedToNextValue = GetReaderScopedToNextValue(ref P_0, ref readStack);
			return ReadCore<TValue>(ref readerScopedToNextValue, P_1, ref readStack);
		}
		catch (JsonException)
		{
			P_0 = utf8JsonReader;
			throw;
		}
	}

	private static Utf8JsonReader GetReaderScopedToNextValue(ref Utf8JsonReader P_0, scoped ref ReadStack P_1)
	{
		ReadOnlySpan<byte> readOnlySpan = default(ReadOnlySpan<byte>);
		ReadOnlySequence<byte> readOnlySequence = default(ReadOnlySequence<byte>);
		try
		{
			JsonTokenType tokenType = P_0.TokenType;
			ReadOnlySpan<byte> readOnlySpan2;
			if ((tokenType == JsonTokenType.None || tokenType == JsonTokenType.PropertyName) && !P_0.Read())
			{
				readOnlySpan2 = default(ReadOnlySpan<byte>);
				ThrowHelper.ThrowJsonReaderException(ref P_0, ExceptionResource.ExpectedOneCompleteToken, 0, readOnlySpan2);
			}
			switch (P_0.TokenType)
			{
			case JsonTokenType.StartObject:
			case JsonTokenType.StartArray:
			{
				long tokenStartIndex = P_0.TokenStartIndex;
				if (!P_0.TrySkip())
				{
					readOnlySpan2 = default(ReadOnlySpan<byte>);
					ThrowHelper.ThrowJsonReaderException(ref P_0, ExceptionResource.NotEnoughData, 0, readOnlySpan2);
				}
				long num2 = P_0.BytesConsumed - tokenStartIndex;
				ReadOnlySequence<byte> originalSequence = P_0.OriginalSequence;
				if (originalSequence.IsEmpty)
				{
					readOnlySpan2 = P_0.OriginalSpan;
					readOnlySpan = checked(readOnlySpan2.Slice((int)tokenStartIndex, (int)num2));
				}
				else
				{
					readOnlySequence = originalSequence.Slice(tokenStartIndex, num2);
				}
				break;
			}
			case JsonTokenType.Number:
			case JsonTokenType.True:
			case JsonTokenType.False:
			case JsonTokenType.Null:
				if (P_0.HasValueSequence)
				{
					readOnlySequence = P_0.ValueSequence;
				}
				else
				{
					readOnlySpan = P_0.ValueSpan;
				}
				break;
			case JsonTokenType.String:
			{
				ReadOnlySequence<byte> originalSequence2 = P_0.OriginalSequence;
				if (originalSequence2.IsEmpty)
				{
					readOnlySpan2 = P_0.ValueSpan;
					int num3 = readOnlySpan2.Length + 2;
					readOnlySpan = P_0.OriginalSpan.Slice((int)P_0.TokenStartIndex, num3);
					break;
				}
				long num4;
				if (!P_0.HasValueSequence)
				{
					readOnlySpan2 = P_0.ValueSpan;
					num4 = readOnlySpan2.Length + 2;
				}
				else
				{
					num4 = P_0.ValueSequence.Length + 2;
				}
				long num5 = num4;
				readOnlySequence = originalSequence2.Slice(P_0.TokenStartIndex, num5);
				break;
			}
			default:
			{
				byte num;
				if (!P_0.HasValueSequence)
				{
					readOnlySpan2 = P_0.ValueSpan;
					num = readOnlySpan2[0];
				}
				else
				{
					readOnlySpan2 = P_0.ValueSequence.First.Span;
					num = readOnlySpan2[0];
				}
				byte b = num;
				readOnlySpan2 = default(ReadOnlySpan<byte>);
				ThrowHelper.ThrowJsonReaderException(ref P_0, ExceptionResource.ExpectedStartOfValueNotFound, b, readOnlySpan2);
				break;
			}
			}
		}
		catch (JsonReaderException ex)
		{
			ThrowHelper.ReThrowWithPath(ref P_1, ex);
		}
		if (!readOnlySpan.IsEmpty)
		{
			return new Utf8JsonReader(readOnlySpan, P_0.CurrentState.Options);
		}
		return new Utf8JsonReader(readOnlySequence, P_0.CurrentState.Options);
	}

	internal static MetadataPropertyName WriteMetadataForObject(JsonConverter P_0, ref WriteStack P_1, Utf8JsonWriter P_2)
	{
		MetadataPropertyName metadataPropertyName = MetadataPropertyName.None;
		if (P_1.NewReferenceId != null)
		{
			P_2.WriteString(s_metadataId, P_1.NewReferenceId);
			metadataPropertyName |= MetadataPropertyName.Id;
			P_1.NewReferenceId = null;
		}
		object polymorphicTypeDiscriminator = P_1.PolymorphicTypeDiscriminator;
		if (polymorphicTypeDiscriminator != null)
		{
			JsonEncodedText? customTypeDiscriminatorPropertyNameJsonEncoded = P_1.Parent.JsonPropertyInfo.JsonTypeInfo.PolymorphicTypeResolver.CustomTypeDiscriminatorPropertyNameJsonEncoded;
			JsonEncodedText jsonEncodedText;
			if (customTypeDiscriminatorPropertyNameJsonEncoded.HasValue)
			{
				JsonEncodedText valueOrDefault = customTypeDiscriminatorPropertyNameJsonEncoded.GetValueOrDefault();
				jsonEncodedText = valueOrDefault;
			}
			else
			{
				jsonEncodedText = s_metadataType;
			}
			JsonEncodedText jsonEncodedText2 = jsonEncodedText;
			if (polymorphicTypeDiscriminator is string text)
			{
				P_2.WriteString(jsonEncodedText2, text);
			}
			else
			{
				P_2.WriteNumber(jsonEncodedText2, (int)polymorphicTypeDiscriminator);
			}
			metadataPropertyName |= MetadataPropertyName.Type;
			P_1.PolymorphicTypeDiscriminator = null;
		}
		return metadataPropertyName;
	}

	internal static MetadataPropertyName WriteMetadataForCollection(JsonConverter P_0, ref WriteStack P_1, Utf8JsonWriter P_2)
	{
		P_2.WriteStartObject();
		MetadataPropertyName result = WriteMetadataForObject(P_0, ref P_1, P_2);
		P_2.WritePropertyName(s_metadataValues);
		return result;
	}

	internal static bool TryGetReferenceForValue(object P_0, ref WriteStack P_1, Utf8JsonWriter P_2)
	{
		bool flag;
		string reference = P_1.ReferenceResolver.GetReference(P_0, out flag);
		if (flag)
		{
			P_2.WriteStartObject();
			P_2.WriteString(s_metadataRef, reference);
			P_2.WriteEndObject();
			P_1.PolymorphicTypeDiscriminator = null;
		}
		else
		{
			P_1.NewReferenceId = reference;
		}
		return flag;
	}

	private static void WriteCore<TValue>(Utf8JsonWriter P_0, in TValue P_1, JsonTypeInfo<TValue> P_2)
	{
		if (P_2.CanUseSerializeHandler)
		{
			P_2.SerializeHandler(P_0, P_1);
		}
		else
		{
			WriteStack writeStack = default(WriteStack);
			JsonTypeInfo jsonTypeInfo = ResolvePolymorphicTypeInfo(in P_1, P_2, out writeStack.IsPolymorphicRootValue);
			writeStack.Initialize(jsonTypeInfo);
			bool flag = (writeStack.IsPolymorphicRootValue ? jsonTypeInfo.Converter.WriteCoreAsObject(P_0, P_1, P_2.Options, ref writeStack) : P_2.EffectiveConverter.WriteCore(P_0, in P_1, P_2.Options, ref writeStack));
		}
		P_0.Flush();
	}

	private static void WriteCoreAsObject(Utf8JsonWriter P_0, object P_1, JsonTypeInfo P_2)
	{
		WriteStack writeStack = default(WriteStack);
		JsonTypeInfo jsonTypeInfo = ResolvePolymorphicTypeInfo(in P_1, P_2, out writeStack.IsPolymorphicRootValue);
		writeStack.Initialize(jsonTypeInfo);
		bool flag = jsonTypeInfo.Converter.WriteCoreAsObject(P_0, P_1, P_2.Options, ref writeStack);
		P_0.Flush();
	}

	private static JsonTypeInfo ResolvePolymorphicTypeInfo<TValue>(in TValue P_0, JsonTypeInfo P_1, out bool P_2)
	{
		if (!typeof(TValue).IsValueType && P_1.Converter.CanBePolymorphic && P_0 != null)
		{
			Type type = P_0.GetType();
			if (type != P_1.Type)
			{
				P_2 = true;
				return P_1.Options.GetTypeInfoForRootType(type);
			}
		}
		P_2 = false;
		return P_1;
	}

	private static void ValidateInputType(object P_0, Type P_1)
	{
		if ((object)P_1 == null)
		{
			ThrowHelper.ThrowArgumentNullException("inputType");
		}
		if (P_0 != null)
		{
			Type type = P_0.GetType();
			if (!P_1.IsAssignableFrom(type))
			{
				ThrowHelper.ThrowArgumentException_DeserializeWrongType(P_1, P_0);
			}
		}
	}

	[RequiresUnreferencedCode("JSON serialization and deserialization might require types that cannot be statically analyzed. Use the overload that takes a JsonTypeInfo or JsonSerializerContext, or make sure all of the required types are preserved.")]
	[RequiresDynamicCode("JSON serialization and deserialization might require types that cannot be statically analyzed and might need runtime code generation. Use System.Text.Json source generation for native AOT applications.")]
	public static string Serialize<TValue>(TValue P_0, JsonSerializerOptions? P_1 = null)
	{
		JsonTypeInfo<TValue> typeInfo = GetTypeInfo<TValue>(P_1);
		return WriteString<TValue>(in P_0, typeInfo);
	}

	[RequiresUnreferencedCode("JSON serialization and deserialization might require types that cannot be statically analyzed. Use the overload that takes a JsonTypeInfo or JsonSerializerContext, or make sure all of the required types are preserved.")]
	[RequiresDynamicCode("JSON serialization and deserialization might require types that cannot be statically analyzed and might need runtime code generation. Use System.Text.Json source generation for native AOT applications.")]
	public static string Serialize(object? P_0, Type P_1, JsonSerializerOptions? P_2 = null)
	{
		ValidateInputType(P_0, P_1);
		JsonTypeInfo typeInfo = GetTypeInfo(P_2, P_1);
		return WriteStringAsObject(P_0, typeInfo);
	}

	private static string WriteString<TValue>(in TValue P_0, JsonTypeInfo<TValue> P_1)
	{
		PooledByteBufferWriter pooledByteBufferWriter;
		Utf8JsonWriter utf8JsonWriter = Utf8JsonWriterCache.RentWriterAndBuffer(P_1.Options, out pooledByteBufferWriter);
		try
		{
			WriteCore(utf8JsonWriter, in P_0, P_1);
			return JsonReaderHelper.TranscodeHelper(pooledByteBufferWriter.WrittenMemory.Span);
		}
		finally
		{
			Utf8JsonWriterCache.ReturnWriterAndBuffer(utf8JsonWriter, pooledByteBufferWriter);
		}
	}

	private static string WriteStringAsObject(object P_0, JsonTypeInfo P_1)
	{
		PooledByteBufferWriter pooledByteBufferWriter;
		Utf8JsonWriter utf8JsonWriter = Utf8JsonWriterCache.RentWriterAndBuffer(P_1.Options, out pooledByteBufferWriter);
		try
		{
			WriteCoreAsObject(utf8JsonWriter, P_0, P_1);
			return JsonReaderHelper.TranscodeHelper(pooledByteBufferWriter.WrittenMemory.Span);
		}
		finally
		{
			Utf8JsonWriterCache.ReturnWriterAndBuffer(utf8JsonWriter, pooledByteBufferWriter);
		}
	}

	[RequiresUnreferencedCode("JSON serialization and deserialization might require types that cannot be statically analyzed. Use the overload that takes a JsonTypeInfo or JsonSerializerContext, or make sure all of the required types are preserved.")]
	[RequiresDynamicCode("JSON serialization and deserialization might require types that cannot be statically analyzed and might need runtime code generation. Use System.Text.Json source generation for native AOT applications.")]
	public static void Serialize<TValue>(Utf8JsonWriter P_0, TValue P_1, JsonSerializerOptions? P_2 = null)
	{
		if (P_0 == null)
		{
			ThrowHelper.ThrowArgumentNullException("writer");
		}
		JsonTypeInfo<TValue> typeInfo = GetTypeInfo<TValue>(P_2);
		WriteCore<TValue>(P_0, in P_1, typeInfo);
	}

	public static void Serialize<TValue>(Utf8JsonWriter P_0, TValue P_1, JsonTypeInfo<TValue> P_2)
	{
		if (P_0 == null)
		{
			ThrowHelper.ThrowArgumentNullException("writer");
		}
		if (P_2 == null)
		{
			ThrowHelper.ThrowArgumentNullException("jsonTypeInfo");
		}
		P_2.EnsureConfigured();
		WriteCore(P_0, in P_1, P_2);
	}
}
