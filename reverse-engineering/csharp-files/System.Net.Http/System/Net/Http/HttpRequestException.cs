using System.Runtime.CompilerServices;

namespace System.Net.Http;

public class HttpRequestException : Exception
{
	[CompilerGenerated]
	private readonly HttpStatusCode? _003CStatusCode_003Ek__BackingField;

	public HttpRequestException(string? P_0)
		: this(P_0, null)
	{
	}

	public HttpRequestException(string? P_0, Exception? P_1)
		: base(P_0, P_1)
	{
		if (P_1 != null)
		{
			base.HResult = P_1.HResult;
		}
	}

	public HttpRequestException(string? P_0, Exception? P_1, HttpStatusCode? P_2)
		: this(P_0, P_1)
	{
		_003CStatusCode_003Ek__BackingField = P_2;
	}
}
