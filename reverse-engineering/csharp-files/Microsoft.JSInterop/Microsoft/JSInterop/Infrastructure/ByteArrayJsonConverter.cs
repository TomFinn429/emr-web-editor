using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Microsoft.JSInterop.Infrastructure;

internal sealed class ByteArrayJsonConverter : JsonConverter<byte[]>
{
	private int _byteArrayId;

	internal static readonly JsonEncodedText ByteArrayRefKey = JsonEncodedText.Encode("__byte[]");

	public JSRuntime JSRuntime { get; }

	public ByteArrayJsonConverter(JSRuntime P_0)
	{
		JSRuntime = P_0;
	}

	public override byte[]? Read(ref Utf8JsonReader P_0, Type P_1, JsonSerializerOptions P_2)
	{
		if (P_0.TokenType == JsonTokenType.String && P_0.TryGetBytesFromBase64(out byte[] result))
		{
			return result;
		}
		if (JSRuntime.ByteArraysToBeRevived.Count == 0)
		{
			throw new JsonException("JSON serialization is attempting to deserialize an unexpected byte array.");
		}
		if (P_0.TokenType != JsonTokenType.StartObject)
		{
			throw new JsonException($"Unexpected JSON Token {P_0.TokenType}, expected 'StartObject'.");
		}
		if (P_0.Read() && P_0.TokenType == JsonTokenType.PropertyName)
		{
			if (!P_0.ValueTextEquals(ByteArrayRefKey.EncodedUtf8Bytes))
			{
				throw new JsonException("Unexpected JSON Property " + P_0.GetString() + ".");
			}
			if (!P_0.Read() || P_0.TokenType != JsonTokenType.Number)
			{
				throw new JsonException($"Unexpected JSON Token {P_0.TokenType}, expected 'Number'.");
			}
			if (!P_0.TryGetInt32(out var num))
			{
				throw new JsonException("Unexpected number, expected 32-bit integer.");
			}
			if (P_0.Read() && P_0.TokenType != JsonTokenType.EndObject)
			{
				throw new JsonException($"Unexpected JSON Token {P_0.TokenType}, expected 'EndObject'.");
			}
			if (num >= JSRuntime.ByteArraysToBeRevived.Count || num < 0)
			{
				throw new JsonException($"Byte array {num} not found.");
			}
			return JSRuntime.ByteArraysToBeRevived.Buffer[num];
		}
		throw new JsonException($"Unexpected JSON Token {P_0.TokenType}, expected 'PropertyName'.");
	}

	public override void Write(Utf8JsonWriter P_0, byte[] P_1, JsonSerializerOptions P_2)
	{
		int num = ++_byteArrayId;
		JSRuntime.SendByteArray(num, P_1);
		P_0.WriteStartObject();
		P_0.WriteNumber(ByteArrayRefKey, num);
		P_0.WriteEndObject();
	}
}
