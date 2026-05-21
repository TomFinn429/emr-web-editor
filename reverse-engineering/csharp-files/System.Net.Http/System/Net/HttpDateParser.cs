using System.Globalization;

namespace System.Net;

internal static class HttpDateParser
{
	private static readonly string[] s_dateFormats = new string[21]
	{
		"ddd, d MMM yyyy H:m:s 'GMT'", "ddd, d MMM yyyy H:m:s 'UTC'", "ddd, d MMM yyyy H:m:s", "d MMM yyyy H:m:s 'GMT'", "d MMM yyyy H:m:s 'UTC'", "d MMM yyyy H:m:s", "ddd, d MMM yy H:m:s 'GMT'", "ddd, d MMM yy H:m:s 'UTC'", "ddd, d MMM yy H:m:s", "d MMM yy H:m:s 'GMT'",
		"d MMM yy H:m:s 'UTC'", "d MMM yy H:m:s", "dddd, d'-'MMM'-'yy H:m:s 'GMT'", "dddd, d'-'MMM'-'yy H:m:s 'UTC'", "dddd, d'-'MMM'-'yy H:m:s zzz", "dddd, d'-'MMM'-'yy H:m:s", "ddd MMM d H:m:s yyyy", "ddd, d MMM yyyy H:m:s zzz", "ddd, d MMM yyyy H:m:s", "d MMM yyyy H:m:s zzz",
		"d MMM yyyy H:m:s"
	};

	internal static bool TryParse(ReadOnlySpan<char> P_0, out DateTimeOffset P_1)
	{
		P_0 = P_0.Trim();
		if (!DateTimeOffset.TryParseExact(P_0, "r", DateTimeFormatInfo.InvariantInfo, DateTimeStyles.None, out P_1))
		{
			return DateTimeOffset.TryParseExact(P_0, s_dateFormats, DateTimeFormatInfo.InvariantInfo, DateTimeStyles.AllowInnerWhite | DateTimeStyles.AssumeUniversal, out P_1);
		}
		return true;
	}
}
