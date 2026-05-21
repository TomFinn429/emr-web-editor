using System.Runtime.InteropServices.JavaScript;
using System.Threading;

namespace System.Net.Http;

internal sealed class WasmFetchResponse : IDisposable
{
	public readonly JSObject FetchResponse;

	private readonly CancellationTokenRegistration _abortRegistration;

	private bool _isDisposed;

	public string ResponseType => FetchResponse.GetPropertyAsString("type");

	public int Status => FetchResponse.GetPropertyAsInt32("status");

	public WasmFetchResponse(JSObject P_0, CancellationTokenRegistration P_1)
	{
		ArgumentNullException.ThrowIfNull(P_0, "fetchResponse");
		FetchResponse = P_0;
		_abortRegistration = P_1;
	}

	public void ThrowIfDisposed()
	{
		if (_isDisposed && FetchResponse.IsDisposed)
		{
			throw new ObjectDisposedException("WasmFetchResponse");
		}
	}

	public void Dispose()
	{
		if (!_isDisposed)
		{
			_isDisposed = true;
			_abortRegistration.Dispose();
			if (FetchResponse != null && !FetchResponse.IsDisposed)
			{
				BrowserHttpInterop.AbortResponse(FetchResponse);
			}
			FetchResponse?.Dispose();
		}
	}
}
