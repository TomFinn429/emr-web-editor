using System.Diagnostics.CodeAnalysis;

namespace System.Net.Http.Headers;

public class ProductHeaderValue : ICloneable
{
	private readonly string _name;

	private readonly string _version;

	public ProductHeaderValue(string P_0)
		: this(P_0, null)
	{
	}

	public ProductHeaderValue(string P_0, string? P_1)
	{
		HeaderUtilities.CheckValidToken(P_0, "name");
		if (!string.IsNullOrEmpty(P_1))
		{
			HeaderUtilities.CheckValidToken(P_1, "version");
			_version = P_1;
		}
		_name = P_0;
	}

	private ProductHeaderValue(ProductHeaderValue P_0)
	{
		_name = P_0._name;
		_version = P_0._version;
	}

	public override string ToString()
	{
		if (string.IsNullOrEmpty(_version))
		{
			return _name;
		}
		return _name + "/" + _version;
	}

	public override bool Equals([NotNullWhen(true)] object? P_0)
	{
		if (!(P_0 is ProductHeaderValue productHeaderValue))
		{
			return false;
		}
		if (string.Equals(_name, productHeaderValue._name, StringComparison.OrdinalIgnoreCase))
		{
			return string.Equals(_version, productHeaderValue._version, StringComparison.OrdinalIgnoreCase);
		}
		return false;
	}

	public override int GetHashCode()
	{
		int num = StringComparer.OrdinalIgnoreCase.GetHashCode(_name);
		if (!string.IsNullOrEmpty(_version))
		{
			num ^= StringComparer.OrdinalIgnoreCase.GetHashCode(_version);
		}
		return num;
	}

	internal static int GetProductLength(string P_0, int P_1, out ProductHeaderValue P_2)
	{
		P_2 = null;
		if (string.IsNullOrEmpty(P_0) || P_1 >= P_0.Length)
		{
			return 0;
		}
		int tokenLength = HttpRuleParser.GetTokenLength(P_0, P_1);
		if (tokenLength == 0)
		{
			return 0;
		}
		string text = P_0.Substring(P_1, tokenLength);
		int num = P_1 + tokenLength;
		num += HttpRuleParser.GetWhitespaceLength(P_0, num);
		if (num == P_0.Length || P_0[num] != '/')
		{
			P_2 = new ProductHeaderValue(text);
			return num - P_1;
		}
		num++;
		num += HttpRuleParser.GetWhitespaceLength(P_0, num);
		int tokenLength2 = HttpRuleParser.GetTokenLength(P_0, num);
		if (tokenLength2 == 0)
		{
			return 0;
		}
		string text2 = P_0.Substring(num, tokenLength2);
		num += tokenLength2;
		num += HttpRuleParser.GetWhitespaceLength(P_0, num);
		P_2 = new ProductHeaderValue(text, text2);
		return num - P_1;
	}

	object ICloneable.Clone()
	{
		return new ProductHeaderValue(this);
	}
}
