using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace System.Net.Http;

public class HttpClient : HttpMessageInvoker
{
	private static readonly TimeSpan s_defaultTimeout = TimeSpan.FromSeconds(100.0);

	private static readonly TimeSpan s_maxTimeout = TimeSpan.FromMilliseconds(2147483647.0);

	private static readonly TimeSpan s_infiniteTimeout = Timeout.InfiniteTimeSpan;

	private volatile bool _operationStarted;

	private volatile bool _disposed;

	private CancellationTokenSource _pendingRequestsCts;

	private HttpRequestHeaders _defaultRequestHeaders;

	private Version _defaultRequestVersion = HttpRequestMessage.DefaultRequestVersion;

	private HttpVersionPolicy _defaultVersionPolicy = HttpVersionPolicy.RequestVersionOrLower;

	private Uri _baseAddress;

	private TimeSpan _timeout;

	private int _maxResponseContentBufferSize;

	public HttpClient(HttpMessageHandler P_0)
		: this(P_0, true)
	{
	}

	public HttpClient(HttpMessageHandler P_0, bool P_1)
		: base(P_0, P_1)
	{
		_timeout = s_defaultTimeout;
		_maxResponseContentBufferSize = 2147483647;
		_pendingRequestsCts = new CancellationTokenSource();
	}

	public Task<Stream> GetStreamAsync(Uri? P_0)
	{
		return GetStreamAsync(P_0, CancellationToken.None);
	}

	public Task<Stream> GetStreamAsync(Uri? P_0, CancellationToken P_1)
	{
		HttpRequestMessage httpRequestMessage = CreateRequestMessage(HttpMethod.Get, P_0);
		CheckRequestBeforeSend(httpRequestMessage);
		return GetStreamAsyncCore(httpRequestMessage, P_1);
	}

	private async Task<Stream> GetStreamAsyncCore(HttpRequestMessage P_0, CancellationToken P_1)
	{
		bool telemetryStarted = StartSend(P_0);
		(CancellationTokenSource, bool, CancellationTokenSource) tuple = PrepareCancellationTokenSource(P_1);
		CancellationTokenSource cts = tuple.Item1;
		bool disposeCts = tuple.Item2;
		CancellationTokenSource pendingRequestsCts = tuple.Item3;
		HttpResponseMessage response = null;
		try
		{
			response = await base.SendAsync(P_0, cts.Token).ConfigureAwait(false);
			ThrowForNullResponse(response);
			response.EnsureSuccessStatusCode();
			HttpContent content = response.Content;
			Stream stream = content.TryReadAsStream();
			Stream stream2 = stream;
			if (stream2 == null)
			{
				stream2 = await content.ReadAsStreamAsync(P_1).ConfigureAwait(false);
			}
			return stream2;
		}
		catch (Exception ex)
		{
			HandleFailure(ex, telemetryStarted, response, cts, P_1, pendingRequestsCts);
			throw;
		}
		finally
		{
			FinishSend(response, cts, disposeCts, telemetryStarted, false);
		}
	}

	public override Task<HttpResponseMessage> SendAsync(HttpRequestMessage P_0, CancellationToken P_1)
	{
		return SendAsync(P_0, HttpCompletionOption.ResponseContentRead, P_1);
	}

	public Task<HttpResponseMessage> SendAsync(HttpRequestMessage P_0, HttpCompletionOption P_1, CancellationToken P_2)
	{
		CheckRequestBeforeSend(P_0);
		var (cancellationTokenSource, flag, cancellationTokenSource2) = PrepareCancellationTokenSource(P_2);
		return Core(P_0, P_1, cancellationTokenSource, flag, cancellationTokenSource2, P_2);
		async Task<HttpResponseMessage> Core(HttpRequestMessage httpRequestMessage, HttpCompletionOption httpCompletionOption, CancellationTokenSource cancellationTokenSource3, bool flag2, CancellationTokenSource cancellationTokenSource4, CancellationToken cancellationToken)
		{
			bool telemetryStarted = StartSend(httpRequestMessage);
			bool responseContentTelemetryStarted = false;
			HttpResponseMessage response = null;
			try
			{
				response = await base.SendAsync(httpRequestMessage, cancellationTokenSource3.Token).ConfigureAwait(false);
				ThrowForNullResponse(response);
				if (ShouldBufferResponse(httpCompletionOption, httpRequestMessage))
				{
					if (HttpTelemetry.Log.IsEnabled() && telemetryStarted)
					{
						HttpTelemetry.Log.ResponseContentStart();
						responseContentTelemetryStarted = true;
					}
					await response.Content.LoadIntoBufferAsync(_maxResponseContentBufferSize, cancellationTokenSource3.Token).ConfigureAwait(false);
				}
				return response;
			}
			catch (Exception ex)
			{
				HandleFailure(ex, telemetryStarted, response, cancellationTokenSource3, cancellationToken, cancellationTokenSource4);
				throw;
			}
			finally
			{
				FinishSend(response, cancellationTokenSource3, flag2, telemetryStarted, responseContentTelemetryStarted);
			}
		}
	}

	private void CheckRequestBeforeSend(HttpRequestMessage P_0)
	{
		ArgumentNullException.ThrowIfNull(P_0, "request");
		ObjectDisposedException.ThrowIf(_disposed, this);
		CheckRequestMessage(P_0);
		SetOperationStarted();
		PrepareRequestMessage(P_0);
	}

	private static void ThrowForNullResponse([NotNull] HttpResponseMessage P_0)
	{
		if (P_0 == null)
		{
			throw new InvalidOperationException("net_http_handler_noresponse");
		}
	}

	private static bool ShouldBufferResponse(HttpCompletionOption P_0, HttpRequestMessage P_1)
	{
		if (P_0 == HttpCompletionOption.ResponseContentRead)
		{
			return !string.Equals(P_1.Method.Method, "HEAD", StringComparison.OrdinalIgnoreCase);
		}
		return false;
	}

	private void HandleFailure(Exception P_0, bool P_1, HttpResponseMessage P_2, CancellationTokenSource P_3, CancellationToken P_4, CancellationTokenSource P_5)
	{
		P_2?.Dispose();
		Exception ex = null;
		if (P_0 is OperationCanceledException ex2)
		{
			if (P_4.IsCancellationRequested)
			{
				if (ex2.CancellationToken != P_4)
				{
					P_0 = (ex = new TaskCanceledException(ex2.Message, ex2.InnerException, P_4));
				}
			}
			else if (P_3.IsCancellationRequested && !P_5.IsCancellationRequested && !P_4.IsCancellationRequested)
			{
				P_0 = (ex = new TaskCanceledException(System.SR.Format("net_http_request_timedout", _timeout.TotalSeconds), new TimeoutException(P_0.Message, P_0), ex2.CancellationToken));
			}
		}
		else if (P_0 is HttpRequestException && P_3.IsCancellationRequested)
		{
			P_0 = (ex = new OperationCanceledException(P_4.IsCancellationRequested ? P_4 : P_3.Token));
		}
		HttpMessageInvoker.LogRequestFailed(P_0, P_1);
		if (NetEventSource.Log.IsEnabled())
		{
		}
		if (ex != null)
		{
			throw ex;
		}
	}

	private static bool StartSend(HttpRequestMessage P_0)
	{
		if (HttpTelemetry.Log.IsEnabled())
		{
		}
		return false;
	}

	private static void FinishSend(HttpResponseMessage P_0, CancellationTokenSource P_1, bool P_2, bool P_3, bool P_4)
	{
		if (HttpTelemetry.Log.IsEnabled() && P_3)
		{
			if (P_4)
			{
				HttpTelemetry.Log.ResponseContentStop();
			}
			HttpTelemetry.Log.RequestStop(P_0);
		}
		if (P_2)
		{
			P_1.Dispose();
		}
	}

	protected override void Dispose(bool P_0)
	{
		if (P_0 && !_disposed)
		{
			_disposed = true;
			_pendingRequestsCts.Cancel();
			_pendingRequestsCts.Dispose();
		}
		base.Dispose(P_0);
	}

	private void SetOperationStarted()
	{
		if (!_operationStarted)
		{
			_operationStarted = true;
		}
	}

	private static void CheckRequestMessage(HttpRequestMessage P_0)
	{
		if (!P_0.MarkAsSent())
		{
			throw new InvalidOperationException("net_http_client_request_already_sent");
		}
	}

	private void PrepareRequestMessage(HttpRequestMessage P_0)
	{
		Uri uri = null;
		if (P_0.RequestUri == null && _baseAddress == null)
		{
			throw new InvalidOperationException("net_http_client_invalid_requesturi");
		}
		if (P_0.RequestUri == null)
		{
			uri = _baseAddress;
		}
		else if (!P_0.RequestUri.IsAbsoluteUri)
		{
			if (_baseAddress == null)
			{
				throw new InvalidOperationException("net_http_client_invalid_requesturi");
			}
			uri = new Uri(_baseAddress, P_0.RequestUri);
		}
		if (uri != null)
		{
			P_0.RequestUri = uri;
		}
		if (_defaultRequestHeaders != null)
		{
			P_0.Headers.AddHeaders(_defaultRequestHeaders);
		}
	}

	private (CancellationTokenSource TokenSource, bool DisposeTokenSource, CancellationTokenSource PendingRequestsCts) PrepareCancellationTokenSource(CancellationToken P_0)
	{
		CancellationTokenSource pendingRequestsCts = _pendingRequestsCts;
		bool flag = _timeout != s_infiniteTimeout;
		if (flag || P_0.CanBeCanceled)
		{
			CancellationTokenSource cancellationTokenSource = CancellationTokenSource.CreateLinkedTokenSource(P_0, pendingRequestsCts.Token);
			if (flag)
			{
				cancellationTokenSource.CancelAfter(_timeout);
			}
			return (TokenSource: cancellationTokenSource, DisposeTokenSource: true, PendingRequestsCts: pendingRequestsCts);
		}
		return (TokenSource: pendingRequestsCts, DisposeTokenSource: false, PendingRequestsCts: pendingRequestsCts);
	}

	private HttpRequestMessage CreateRequestMessage(HttpMethod P_0, Uri P_1)
	{
		return new HttpRequestMessage(P_0, P_1)
		{
			Version = _defaultRequestVersion,
			VersionPolicy = _defaultVersionPolicy
		};
	}
}
