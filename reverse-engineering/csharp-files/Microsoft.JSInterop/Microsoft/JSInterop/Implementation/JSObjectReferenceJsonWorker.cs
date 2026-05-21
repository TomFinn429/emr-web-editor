using System.Text.Json;

namespace Microsoft.JSInterop.Implementation;

public static class JSObjectReferenceJsonWorker
{
	internal static readonly JsonEncodedText JSObjectIdKey = JsonEncodedText.Encode("__jsObjectId");

	public static long ReadJSObjectReferenceIdentifier(ref Utf8JsonReader P_0)
	{
		long? num = null;
		while (P_0.Read() && P_0.TokenType != JsonTokenType.EndObject)
		{
			if (P_0.TokenType == JsonTokenType.PropertyName)
			{
				if (!num.HasValue && P_0.ValueTextEquals(JSObjectIdKey.EncodedUtf8Bytes))
				{
					P_0.Read();
					num = P_0.GetInt64();
					continue;
				}
				throw new JsonException("Unexcepted JSON property " + P_0.GetString() + ".");
			}
			throw new JsonException($"Unexcepted JSON token {P_0.TokenType}");
		}
		if (!num.HasValue)
		{
			throw new JsonException($"Required property {JSObjectIdKey} not found.");
		}
		return num.Value;
	}

	public static void WriteJSObjectReference(Utf8JsonWriter P_0, JSObjectReference P_1)
	{
		P_0.WriteStartObject();
		P_0.WriteNumber(JSObjectIdKey, P_1.Id);
		P_0.WriteEndObject();
	}
}
