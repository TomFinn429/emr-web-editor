using System.Threading;
using System.Threading.Tasks;

namespace System.Net.Http;

public class HttpMessageInvoker : IDisposable
{
	private volatile bool _disposed;

	private readonly bool _disposeHandler;

	private readonly HttpMessageHandler _handler;

	public HttpMessageInvoker(HttpMessageHandler P_0, bool P_1)
	{
		ArgumentNullException.ThrowIfNull(P_0, "handler");
		if (NetEventSource.Log.IsEnabled())
		{
		}
		_handler = P_0;
		_disposeHandler = P_1;
	}

	public virtual Task<HttpResponseMessage> SendAsync(HttpRequestMessage P_0, CancellationToken P_1)
	{
		ArgumentNullException.ThrowIfNull(P_0, "request");
		ObjectDisposedException.ThrowIf(_disposed, this);
		if (ShouldSendWithTelemetry(P_0))
		{
		}
		return _handler.SendAsync(P_0, P_1);
	}

	private static bool ShouldSendWithTelemetry(HttpRequestMessage P_0)
	{
		if (HttpTelemetry.Log.IsEnabled())
		{
		}
		return false;
	}

	internal static bool LogRequestFailed(Exception P_0, bool P_1)
	{
		if (HttpTelemetry.Log.IsEnabled() && P_1)
		{
			HttpTelemetry.Log.RequestFailed(P_0);
		}
		return false;
	}

	public void Dispose()
	{
		Dispose(true);
		GC.SuppressFinalize(this);
	}

	protected virtual void Dispose(bool P_0)
	{
		if (P_0 && !_disposed)
		{
			_disposed = true;
			if (_disposeHandler)
			{
				_handler.Dispose();
			}
		}
	}
}
