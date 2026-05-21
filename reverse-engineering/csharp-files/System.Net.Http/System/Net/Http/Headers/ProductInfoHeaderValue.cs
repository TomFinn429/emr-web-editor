using System.Diagnostics.CodeAnalysis;

namespace System.Net.Http.Headers;

public class ProductInfoHeaderValue : ICloneable
{
	private ProductHeaderValue _product;

	private string _comment;

	public ProductInfoHeaderValue(ProductHeaderValue P_0)
	{
		ArgumentNullException.ThrowIfNull(P_0, "product");
		_product = P_0;
	}

	public ProductInfoHeaderValue(string P_0)
	{
		HeaderUtilities.CheckValidComment(P_0, "comment");
		_comment = P_0;
	}

	private ProductInfoHeaderValue(ProductInfoHeaderValue P_0)
	{
		_product = P_0._product;
		_comment = P_0._comment;
	}

	public override string ToString()
	{
		if (_product == null)
		{
			return _comment;
		}
		return _product.ToString();
	}

	public override bool Equals([NotNullWhen(true)] object? P_0)
	{
		if (!(P_0 is ProductInfoHeaderValue productInfoHeaderValue))
		{
			return false;
		}
		if (_product == null)
		{
			return string.Equals(_comment, productInfoHeaderValue._comment, StringComparison.Ordinal);
		}
		return _product.Equals(productInfoHeaderValue._product);
	}

	public override int GetHashCode()
	{
		if (_product == null)
		{
			return _comment.GetHashCode();
		}
		return _product.GetHashCode();
	}

	internal static int GetProductInfoLength(string P_0, int P_1, out ProductInfoHeaderValue P_2)
	{
		P_2 = null;
		if (string.IsNullOrEmpty(P_0) || P_1 >= P_0.Length)
		{
			return 0;
		}
		int num = P_1;
		if (P_0[num] == '(')
		{
			if (HttpRuleParser.GetCommentLength(P_0, num, out var num2) != HttpParseResult.Parsed)
			{
				return 0;
			}
			string text = P_0.Substring(num, num2);
			num += num2;
			num += HttpRuleParser.GetWhitespaceLength(P_0, num);
			P_2 = new ProductInfoHeaderValue(text);
		}
		else
		{
			ProductHeaderValue productHeaderValue;
			int productLength = ProductHeaderValue.GetProductLength(P_0, num, out productHeaderValue);
			if (productLength == 0)
			{
				return 0;
			}
			num += productLength;
			P_2 = new ProductInfoHeaderValue(productHeaderValue);
		}
		return num - P_1;
	}

	object ICloneable.Clone()
	{
		return new ProductInfoHeaderValue(this);
	}
}
