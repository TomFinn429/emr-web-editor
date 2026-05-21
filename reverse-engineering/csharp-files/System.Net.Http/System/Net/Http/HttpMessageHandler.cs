using System.Threading;
using System.Threading.Tasks;

namespace System.Net.Http;

public abstract class HttpMessageHandler : IDisposable
{
	protected HttpMessageHandler()
	{
		if (!NetEventSource.Log.IsEnabled())
		{
		}
	}

	protected internal abstract Task<HttpResponseMessage> SendAsync(HttpRequestMessage P_0, CancellationToken P_1);

	protected virtual void Dispose(bool P_0)
	{
	}

	public void Dispose()
	{
		Dispose(true);
		GC.SuppressFinalize(this);
	}
}
