using System.Net.Http.Headers;
using System.Text;
using System.Threading;

namespace System.Net.Http;

public class HttpRequestMessage : IDisposable
{
	private int _sendStatus;

	private HttpMethod _method;

	private Uri _requestUri;

	private HttpRequestHeaders _headers;

	private Version _version;

	private HttpVersionPolicy _versionPolicy;

	private HttpContent _content;

	private bool _disposed;

	private HttpRequestOptions _options;

	internal static Version DefaultRequestVersion => HttpVersion.Version11;

	public Version Version
	{
		set
		{
			ArgumentNullException.ThrowIfNull(version, "value");
			CheckDisposed();
			_version = version;
		}
	}

	public HttpVersionPolicy VersionPolicy
	{
		set
		{
			CheckDisposed();
			_versionPolicy = versionPolicy;
		}
	}

	public HttpContent? Content => _content;

	public HttpMethod Method => _method;

	public Uri? RequestUri
	{
		get
		{
			return _requestUri;
		}
		set
		{
			CheckDisposed();
			_requestUri = requestUri;
		}
	}

	public HttpRequestHeaders Headers => _headers ?? (_headers = new HttpRequestHeaders());

	public HttpRequestOptions Options => _options ?? (_options = new HttpRequestOptions());

	public HttpRequestMessage(HttpMethod P_0, Uri? P_1)
	{
		ArgumentNullException.ThrowIfNull(P_0, "method");
		_method = P_0;
		_requestUri = P_1;
		_version = DefaultRequestVersion;
		_versionPolicy = HttpVersionPolicy.RequestVersionOrLower;
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Method: ");
		stringBuilder.Append(_method);
		stringBuilder.Append(", RequestUri: '");
		stringBuilder.Append((_requestUri == null) ? "<null>" : _requestUri.ToString());
		stringBuilder.Append("', Version: ");
		stringBuilder.Append(_version);
		stringBuilder.Append(", Content: ");
		stringBuilder.Append((_content == null) ? "<null>" : _content.GetType().ToString());
		stringBuilder.AppendLine(", Headers:");
		HeaderUtilities.DumpHeaders(stringBuilder, _headers, _content?.Headers);
		return stringBuilder.ToString();
	}

	internal bool MarkAsSent()
	{
		return Interlocked.CompareExchange(ref _sendStatus, 1, 0) == 0;
	}

	protected virtual void Dispose(bool P_0)
	{
		if (P_0 && !_disposed)
		{
			_disposed = true;
			_content?.Dispose();
		}
	}

	public void Dispose()
	{
		Dispose(true);
		GC.SuppressFinalize(this);
	}

	private void CheckDisposed()
	{
		ObjectDisposedException.ThrowIf(_disposed, this);
	}
}
