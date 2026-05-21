using System.Diagnostics.CodeAnalysis;

namespace System.Net.Http.Headers;

internal sealed class ProductInfoHeaderParser : HttpHeaderParser
{
	internal static readonly ProductInfoHeaderParser SingleValueParser = new ProductInfoHeaderParser(false);

	internal static readonly ProductInfoHeaderParser MultipleValueParser = new ProductInfoHeaderParser(true);

	private ProductInfoHeaderParser(bool P_0)
		: base(P_0, " ")
	{
	}

	public override bool TryParseValue([NotNullWhen(true)] string P_0, object P_1, ref int P_2, [NotNullWhen(true)] out object P_3)
	{
		P_3 = null;
		if (string.IsNullOrEmpty(P_0) || P_2 == P_0.Length)
		{
			return false;
		}
		int num = P_2 + HttpRuleParser.GetWhitespaceLength(P_0, P_2);
		if (num == P_0.Length)
		{
			return false;
		}
		ProductInfoHeaderValue productInfoHeaderValue;
		int productInfoLength = ProductInfoHeaderValue.GetProductInfoLength(P_0, num, out productInfoHeaderValue);
		if (productInfoLength == 0)
		{
			return false;
		}
		num += productInfoLength;
		if (num < P_0.Length)
		{
			char c = P_0[num - 1];
			if (c != ' ' && c != '\t')
			{
				return false;
			}
		}
		P_2 = num;
		P_3 = productInfoHeaderValue;
		return true;
	}
}
