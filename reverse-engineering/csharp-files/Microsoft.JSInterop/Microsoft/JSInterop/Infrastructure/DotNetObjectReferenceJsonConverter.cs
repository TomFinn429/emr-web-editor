using System;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Microsoft.JSInterop.Infrastructure;

internal sealed class DotNetObjectReferenceJsonConverter<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicMethods)] TValue> : JsonConverter<DotNetObjectReference<TValue>> where TValue : class
{
	private static JsonEncodedText DotNetObjectRefKey => DotNetDispatcher.DotNetObjectRefKey;

	public JSRuntime JSRuntime { get; }

	public DotNetObjectReferenceJsonConverter(JSRuntime jsRuntime)
	{
		JSRuntime = jsRuntime;
	}

	public override DotNetObjectReference<TValue> Read(ref Utf8JsonReader P_0, Type P_1, JsonSerializerOptions P_2)
	{
		long num = 0L;
		while (P_0.Read() && P_0.TokenType != JsonTokenType.EndObject)
		{
			if (P_0.TokenType == JsonTokenType.PropertyName)
			{
				if (num == 0L && P_0.ValueTextEquals(DotNetObjectRefKey.EncodedUtf8Bytes))
				{
					P_0.Read();
					num = P_0.GetInt64();
					continue;
				}
				throw new JsonException("Unexpected JSON property " + P_0.GetString() + ".");
			}
			throw new JsonException($"Unexpected JSON Token {P_0.TokenType}.");
		}
		if (num == 0L)
		{
			throw new JsonException($"Required property {DotNetObjectRefKey} not found.");
		}
		return (DotNetObjectReference<TValue>)JSRuntime.GetObjectReference(num);
	}

	public override void Write(Utf8JsonWriter P_0, DotNetObjectReference<TValue> P_1, JsonSerializerOptions P_2)
	{
		long num = JSRuntime.TrackObjectReference(P_1);
		P_0.WriteStartObject();
		P_0.WriteNumber(DotNetObjectRefKey, num);
		P_0.WriteEndObject();
	}
}
