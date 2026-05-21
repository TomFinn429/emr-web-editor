namespace System.Net.Http.Headers;

public sealed class HttpResponseHeaders : HttpHeaders
{
	private HttpGeneralHeaders _generalHeaders;

	private bool _containsTrailingHeaders;

	private HttpGeneralHeaders GeneralHeaders => _generalHeaders ?? (_generalHeaders = new HttpGeneralHeaders(this));

	internal HttpResponseHeaders(bool P_0 = false)
		: base(P_0 ? (HttpHeaderType.General | HttpHeaderType.Response | HttpHeaderType.Content | HttpHeaderType.Custom | HttpHeaderType.NonTrailing) : (HttpHeaderType.General | HttpHeaderType.Response | HttpHeaderType.Custom), HttpHeaderType.Request)
	{
		_containsTrailingHeaders = P_0;
	}

	internal override void AddHeaders(HttpHeaders P_0)
	{
		base.AddHeaders(P_0);
		HttpResponseHeaders httpResponseHeaders = P_0 as HttpResponseHeaders;
		if (httpResponseHeaders._generalHeaders != null)
		{
			GeneralHeaders.AddSpecialsFrom(httpResponseHeaders._generalHeaders);
		}
	}
}
