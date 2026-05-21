using System;
using Microsoft.JSInterop.Implementation;

namespace Microsoft.JSInterop.WebAssembly;

internal sealed class WebAssemblyJSObjectReference : JSInProcessObjectReference, IJSUnmarshalledObjectReference, IJSInProcessObjectReference, IJSObjectReference, IAsyncDisposable, IDisposable
{
	private readonly WebAssemblyJSRuntime _jsRuntime;

	public WebAssemblyJSObjectReference(WebAssemblyJSRuntime P_0, long P_1)
		: base(P_0, P_1)
	{
		_jsRuntime = P_0;
	}
}
