using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.JSInterop.Implementation;

namespace Microsoft.JSInterop.WebAssembly;

internal sealed class WebAssemblyJSObjectReferenceJsonConverter : JsonConverter<IJSObjectReference>
{
	private readonly WebAssemblyJSRuntime _jsRuntime;

	public WebAssemblyJSObjectReferenceJsonConverter(WebAssemblyJSRuntime P_0)
	{
		_jsRuntime = P_0;
	}

	public override bool CanConvert(Type P_0)
	{
		if (!(P_0 == typeof(WebAssemblyJSObjectReference)) && !(P_0 == typeof(IJSObjectReference)) && !(P_0 == typeof(IJSInProcessObjectReference)))
		{
			return P_0 == typeof(IJSUnmarshalledObjectReference);
		}
		return true;
	}

	public override IJSObjectReference? Read(ref Utf8JsonReader P_0, Type P_1, JsonSerializerOptions P_2)
	{
		long num = JSObjectReferenceJsonWorker.ReadJSObjectReferenceIdentifier(ref P_0);
		return new WebAssemblyJSObjectReference(_jsRuntime, num);
	}

	public override void Write(Utf8JsonWriter P_0, IJSObjectReference P_1, JsonSerializerOptions P_2)
	{
		JSObjectReferenceJsonWorker.WriteJSObjectReference(P_0, (JSObjectReference)P_1);
	}
}
