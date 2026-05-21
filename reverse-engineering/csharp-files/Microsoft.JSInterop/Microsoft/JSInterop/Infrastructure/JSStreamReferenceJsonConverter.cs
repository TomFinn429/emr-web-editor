using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.JSInterop.Implementation;

namespace Microsoft.JSInterop.Infrastructure;

internal sealed class JSStreamReferenceJsonConverter : JsonConverter<IJSStreamReference>
{
	private static readonly JsonEncodedText _jsStreamReferenceLengthKey = JsonEncodedText.Encode("__jsStreamReferenceLength");

	private readonly JSRuntime _jsRuntime;

	public JSStreamReferenceJsonConverter(JSRuntime P_0)
	{
		_jsRuntime = P_0;
	}

	public override bool CanConvert(Type P_0)
	{
		if (!(P_0 == typeof(IJSStreamReference)))
		{
			return P_0 == typeof(JSStreamReference);
		}
		return true;
	}

	public override IJSStreamReference? Read(ref Utf8JsonReader P_0, Type P_1, JsonSerializerOptions P_2)
	{
		long? num = null;
		long? num2 = null;
		while (P_0.Read() && P_0.TokenType != JsonTokenType.EndObject)
		{
			if (P_0.TokenType == JsonTokenType.PropertyName)
			{
				if (!num.HasValue && P_0.ValueTextEquals(JSObjectReferenceJsonWorker.JSObjectIdKey.EncodedUtf8Bytes))
				{
					P_0.Read();
					num = P_0.GetInt64();
					continue;
				}
				if (!num2.HasValue && P_0.ValueTextEquals(_jsStreamReferenceLengthKey.EncodedUtf8Bytes))
				{
					P_0.Read();
					num2 = P_0.GetInt64();
					continue;
				}
				throw new JsonException("Unexcepted JSON property " + P_0.GetString() + ".");
			}
			throw new JsonException($"Unexcepted JSON token {P_0.TokenType}");
		}
		if (!num.HasValue)
		{
			throw new JsonException($"Required property {JSObjectReferenceJsonWorker.JSObjectIdKey} not found.");
		}
		if (!num2.HasValue)
		{
			throw new JsonException($"Required property {_jsStreamReferenceLengthKey} not found.");
		}
		return new JSStreamReference(_jsRuntime, num.Value, num2.Value);
	}

	public override void Write(Utf8JsonWriter P_0, IJSStreamReference P_1, JsonSerializerOptions P_2)
	{
		JSObjectReferenceJsonWorker.WriteJSObjectReference(P_0, (JSStreamReference)P_1);
	}
}
