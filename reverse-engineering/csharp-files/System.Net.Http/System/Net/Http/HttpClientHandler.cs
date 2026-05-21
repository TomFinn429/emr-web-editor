using System.Runtime.Versioning;
using System.Threading;
using System.Threading.Tasks;

namespace System.Net.Http;

public class HttpClientHandler : HttpMessageHandler
{
	private readonly BrowserHttpHandler _underlyingHandler;

	private ClientCertificateOption _clientCertificateOptions;

	private volatile bool _disposed;

	private HttpMessageHandler Handler { get; }

	[UnsupportedOSPlatform("browser")]
	[UnsupportedOSPlatform("ios")]
	[UnsupportedOSPlatform("tvos")]
	public IWebProxy? Proxy
	{
		set
		{
			_underlyingHandler.Proxy = proxy;
		}
	}

	[UnsupportedOSPlatform("browser")]
	public ICredentials? Credentials
	{
		set
		{
			_underlyingHandler.Credentials = credentials;
		}
	}

	public ClientCertificateOption ClientCertificateOptions
	{
		set
		{
			switch (clientCertificateOption)
			{
			case ClientCertificateOption.Manual:
				_clientCertificateOptions = clientCertificateOption;
				break;
			case ClientCertificateOption.Automatic:
				_clientCertificateOptions = clientCertificateOption;
				break;
			default:
				throw new ArgumentOutOfRangeException("value");
			}
		}
	}

	public HttpClientHandler()
	{
		_underlyingHandler = new BrowserHttpHandler();
		Handler = _underlyingHandler;
		if (false)
		{
		}
		ClientCertificateOptions = ClientCertificateOption.Manual;
	}

	protected override void Dispose(bool P_0)
	{
		if (P_0 && !_disposed)
		{
			_disposed = true;
			_underlyingHandler.Dispose();
		}
		base.Dispose(P_0);
	}

	protected internal override Task<HttpResponseMessage> SendAsync(HttpRequestMessage P_0, CancellationToken P_1)
	{
		return Handler.SendAsync(P_0, P_1);
	}
}
