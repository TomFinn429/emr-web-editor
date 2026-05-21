using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.JSInterop.Implementation;

namespace Microsoft.JSInterop.Infrastructure;

internal sealed class JSObjectReferenceJsonConverter : JsonConverter<IJSObjectReference>
{
	private readonly JSRuntime _jsRuntime;

	public JSObjectReferenceJsonConverter(JSRuntime P_0)
	{
		_jsRuntime = P_0;
	}

	public override bool CanConvert(Type P_0)
	{
		if (!(P_0 == typeof(IJSObjectReference)))
		{
			return P_0 == typeof(JSObjectReference);
		}
		return true;
	}

	public override IJSObjectReference? Read(ref Utf8JsonReader P_0, Type P_1, JsonSerializerOptions P_2)
	{
		long num = JSObjectReferenceJsonWorker.ReadJSObjectReferenceIdentifier(ref P_0);
		return new JSObjectReference(_jsRuntime, num);
	}

	public override void Write(Utf8JsonWriter P_0, IJSObjectReference P_1, JsonSerializerOptions P_2)
	{
		JSObjectReferenceJsonWorker.WriteJSObjectReference(P_0, (JSObjectReference)P_1);
	}
}
