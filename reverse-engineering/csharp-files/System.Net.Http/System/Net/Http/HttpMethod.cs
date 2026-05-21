using System.Diagnostics.CodeAnalysis;

namespace System.Net.Http;

public class HttpMethod : IEquatable<HttpMethod>
{
	private readonly string _method;

	private readonly int? _http3Index;

	private int _hashcode;

	private static readonly HttpMethod s_getMethod = new HttpMethod("GET", 17);

	private static readonly HttpMethod s_putMethod = new HttpMethod("PUT", 21);

	private static readonly HttpMethod s_postMethod = new HttpMethod("POST", 20);

	private static readonly HttpMethod s_deleteMethod = new HttpMethod("DELETE", 16);

	private static readonly HttpMethod s_headMethod = new HttpMethod("HEAD", 18);

	private static readonly HttpMethod s_optionsMethod = new HttpMethod("OPTIONS", 19);

	private static readonly HttpMethod s_traceMethod = new HttpMethod("TRACE", -1);

	private static readonly HttpMethod s_patchMethod = new HttpMethod("PATCH", -1);

	private static readonly HttpMethod s_connectMethod = new HttpMethod("CONNECT", 15);

	public static HttpMethod Get => s_getMethod;

	public string Method => _method;

	private HttpMethod(string P_0, int P_1)
	{
		_method = P_0;
		_http3Index = P_1;
	}

	public bool Equals([NotNullWhen(true)] HttpMethod? P_0)
	{
		if (P_0 == null)
		{
			return false;
		}
		if ((object)_method == P_0._method)
		{
			return true;
		}
		return string.Equals(_method, P_0._method, StringComparison.OrdinalIgnoreCase);
	}

	public override bool Equals([NotNullWhen(true)] object? P_0)
	{
		return Equals(P_0 as HttpMethod);
	}

	public override int GetHashCode()
	{
		if (_hashcode == 0)
		{
			_hashcode = StringComparer.OrdinalIgnoreCase.GetHashCode(_method);
		}
		return _hashcode;
	}

	public override string ToString()
	{
		return _method;
	}
}
