using System.Globalization;

namespace System.Net.Http.Headers;

internal sealed class Int32NumberHeaderParser : BaseHeaderParser
{
	internal static readonly Int32NumberHeaderParser Parser = new Int32NumberHeaderParser();

	private Int32NumberHeaderParser()
		: base(false)
	{
	}

	public override string ToString(object P_0)
	{
		return ((int)P_0).ToString(NumberFormatInfo.InvariantInfo);
	}

	protected override int GetParsedValueLength(string P_0, int P_1, object P_2, out object P_3)
	{
		P_3 = null;
		int numberLength = HttpRuleParser.GetNumberLength(P_0, P_1, false);
		if (numberLength == 0 || numberLength > 10)
		{
			return 0;
		}
		if (!HeaderUtilities.TryParseInt32(P_0, P_1, numberLength, out var num))
		{
			return 0;
		}
		P_3 = num;
		return numberLength;
	}
}
