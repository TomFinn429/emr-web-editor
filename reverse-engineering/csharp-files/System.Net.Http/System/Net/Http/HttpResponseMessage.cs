using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Net.Http.Headers;
using System.Text;

namespace System.Net.Http;

public class HttpResponseMessage : IDisposable
{
	private HttpStatusCode _statusCode;

	private HttpResponseHeaders _headers;

	private HttpResponseHeaders _trailingHeaders;

	private string _reasonPhrase;

	private HttpRequestMessage _requestMessage;

	private Version _version;

	private HttpContent _content;

	private bool _disposed;

	private static Version DefaultResponseVersion => HttpVersion.Version11;

	public HttpContent Content
	{
		get
		{
			return _content ?? (_content = new EmptyContent());
		}
		[param: AllowNull]
		set
		{
			CheckDisposed();
			if (NetEventSource.Log.IsEnabled())
			{
			}
			_content = content;
		}
	}

	public HttpStatusCode StatusCode => _statusCode;

	public string? ReasonPhrase
	{
		get
		{
			if (_reasonPhrase != null)
			{
				return _reasonPhrase;
			}
			return HttpStatusDescription.Get(StatusCode);
		}
	}

	public HttpResponseHeaders Headers => _headers ?? (_headers = new HttpResponseHeaders());

	public HttpRequestMessage? RequestMessage
	{
		set
		{
			CheckDisposed();
			if (httpRequestMessage == null || NetEventSource.Log.IsEnabled())
			{
			}
			_requestMessage = httpRequestMessage;
		}
	}

	public bool IsSuccessStatusCode
	{
		get
		{
			if (_statusCode >= HttpStatusCode.OK)
			{
				return _statusCode <= (HttpStatusCode)299;
			}
			return false;
		}
	}

	internal void SetReasonPhraseWithoutValidation(string P_0)
	{
		_reasonPhrase = P_0;
	}

	public HttpResponseMessage(HttpStatusCode P_0)
	{
		if (P_0 < (HttpStatusCode)0 || P_0 > (HttpStatusCode)999)
		{
			throw new ArgumentOutOfRangeException("statusCode");
		}
		_statusCode = P_0;
		_version = DefaultResponseVersion;
	}

	public HttpResponseMessage EnsureSuccessStatusCode()
	{
		if (!IsSuccessStatusCode)
		{
			throw new HttpRequestException(System.SR.Format(CultureInfo.InvariantCulture, "net_http_message_not_success_statuscode", (int)_statusCode, ReasonPhrase), null, _statusCode);
		}
		return this;
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("StatusCode: ");
		stringBuilder.Append((int)_statusCode);
		stringBuilder.Append(", ReasonPhrase: '");
		stringBuilder.Append(ReasonPhrase ?? "<null>");
		stringBuilder.Append("', Version: ");
		stringBuilder.Append(_version);
		stringBuilder.Append(", Content: ");
		stringBuilder.Append((_content == null) ? "<null>" : _content.GetType().ToString());
		stringBuilder.AppendLine(", Headers:");
		HeaderUtilities.DumpHeaders(stringBuilder, _headers, _content?.Headers);
		if (_trailingHeaders != null)
		{
			stringBuilder.AppendLine(", Trailing Headers:");
			HeaderUtilities.DumpHeaders(stringBuilder, _trailingHeaders);
		}
		return stringBuilder.ToString();
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
