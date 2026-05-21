using System.Diagnostics.Tracing;
using System.Threading;

namespace System.Net.Http;

internal sealed class HttpTelemetry : EventSource
{
	public static readonly HttpTelemetry Log = new HttpTelemetry();

	private long _stoppedRequests;

	private long _failedRequests;

	public void RequestStop(HttpResponseMessage P_0)
	{
		RequestStop((int)(P_0?.StatusCode ?? ((HttpStatusCode)(-1))));
	}

	private void RequestStop(int P_0)
	{
		Interlocked.Increment(ref _stoppedRequests);
		WriteEvent(2, P_0);
	}

	public void RequestFailed(Exception P_0)
	{
		Interlocked.Increment(ref _failedRequests);
		if (!IsEnabled(EventLevel.Error, EventKeywords.None))
		{
		}
	}

	public void ResponseContentStart()
	{
		WriteEvent(13);
	}

	public void ResponseContentStop()
	{
		WriteEvent(14);
	}
}
