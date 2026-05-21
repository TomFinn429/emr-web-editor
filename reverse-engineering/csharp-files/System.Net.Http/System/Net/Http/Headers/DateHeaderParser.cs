using System.Diagnostics.CodeAnalysis;

namespace System.Net.Http.Headers;

internal sealed class DateHeaderParser : HttpHeaderParser
{
	internal static readonly DateHeaderParser Parser = new DateHeaderParser();

	private DateHeaderParser()
		: base(false)
	{
	}

	public override string ToString(object P_0)
	{
		return ((DateTimeOffset)P_0).ToString("r");
	}

	public override bool TryParseValue([NotNullWhen(true)] string P_0, object P_1, ref int P_2, [NotNullWhen(true)] out object P_3)
	{
		P_3 = null;
		if (string.IsNullOrEmpty(P_0) || P_2 == P_0.Length)
		{
			return false;
		}
		ReadOnlySpan<char> readOnlySpan = P_0;
		if (P_2 > 0)
		{
			readOnlySpan = P_0.AsSpan(P_2);
		}
		if (!HttpDateParser.TryParse(readOnlySpan, out var dateTimeOffset))
		{
			return false;
		}
		P_2 = P_0.Length;
		P_3 = dateTimeOffset;
		return true;
	}
}
