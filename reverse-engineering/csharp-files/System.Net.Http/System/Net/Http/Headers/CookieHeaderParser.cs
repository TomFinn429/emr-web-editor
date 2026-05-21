using System.Diagnostics.CodeAnalysis;

namespace System.Net.Http.Headers;

internal sealed class CookieHeaderParser : HttpHeaderParser
{
	internal static readonly CookieHeaderParser Parser = new CookieHeaderParser();

	private CookieHeaderParser()
		: base(true, "; ")
	{
	}

	public override bool TryParseValue(string P_0, object P_1, ref int P_2, [NotNullWhen(true)] out object P_3)
	{
		if (string.IsNullOrEmpty(P_0) || P_2 == P_0.Length)
		{
			P_3 = null;
			return false;
		}
		P_3 = P_0;
		P_2 = P_0.Length;
		return true;
	}
}
