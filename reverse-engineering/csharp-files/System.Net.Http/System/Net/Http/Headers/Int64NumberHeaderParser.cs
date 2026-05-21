using System.Globalization;

namespace System.Net.Http.Headers;

internal sealed class Int64NumberHeaderParser : BaseHeaderParser
{
	internal static readonly Int64NumberHeaderParser Parser = new Int64NumberHeaderParser();

	private Int64NumberHeaderParser()
		: base(false)
	{
	}

	public override string ToString(object P_0)
	{
		return ((long)P_0).ToString(NumberFormatInfo.InvariantInfo);
	}

	protected override int GetParsedValueLength(string P_0, int P_1, object P_2, out object P_3)
	{
		P_3 = null;
		int numberLength = HttpRuleParser.GetNumberLength(P_0, P_1, false);
		if (numberLength == 0 || numberLength > 19)
		{
			return 0;
		}
		if (!HeaderUtilities.TryParseInt64(P_0, P_1, numberLength, out var num))
		{
			return 0;
		}
		P_3 = num;
		return numberLength;
	}
}
