using System;

namespace Microsoft.JSInterop.Implementation;

public class JSInProcessObjectReference : JSObjectReference, IJSInProcessObjectReference, IJSObjectReference, IAsyncDisposable, IDisposable
{
	private readonly JSInProcessRuntime _jsRuntime;

	protected internal JSInProcessObjectReference(JSInProcessRuntime P_0, long P_1)
		: base(P_0, P_1)
	{
		_jsRuntime = P_0;
	}

	public void Dispose()
	{
		if (!base.Disposed)
		{
			base.Disposed = true;
			_jsRuntime.InvokeVoid("DotNet.jsCallDispatcher.disposeJSObjectReferenceById", base.Id);
		}
	}
}
