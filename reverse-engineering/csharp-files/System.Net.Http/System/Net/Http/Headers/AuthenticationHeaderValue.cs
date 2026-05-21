using System.Diagnostics.CodeAnalysis;

namespace System.Net.Http.Headers;

public class AuthenticationHeaderValue : ICloneable
{
	private readonly string _scheme;

	private readonly string _parameter;

	public AuthenticationHeaderValue(string P_0)
		: this(P_0, null)
	{
	}

	public AuthenticationHeaderValue(string P_0, string? P_1)
	{
		HeaderUtilities.CheckValidToken(P_0, "scheme");
		HttpHeaders.CheckContainsNewLine(P_1);
		_scheme = P_0;
		_parameter = P_1;
	}

	private AuthenticationHeaderValue(AuthenticationHeaderValue P_0)
	{
		_scheme = P_0._scheme;
		_parameter = P_0._parameter;
	}

	public override string ToString()
	{
		if (string.IsNullOrEmpty(_parameter))
		{
			return _scheme;
		}
		return _scheme + " " + _parameter;
	}

	public override bool Equals([NotNullWhen(true)] object? P_0)
	{
		if (!(P_0 is AuthenticationHeaderValue authenticationHeaderValue))
		{
			return false;
		}
		if (string.IsNullOrEmpty(_parameter) && string.IsNullOrEmpty(authenticationHeaderValue._parameter))
		{
			return string.Equals(_scheme, authenticationHeaderValue._scheme, StringComparison.OrdinalIgnoreCase);
		}
		if (string.Equals(_scheme, authenticationHeaderValue._scheme, StringComparison.OrdinalIgnoreCase))
		{
			return string.Equals(_parameter, authenticationHeaderValue._parameter, StringComparison.Ordinal);
		}
		return false;
	}

	public override int GetHashCode()
	{
		int num = StringComparer.OrdinalIgnoreCase.GetHashCode(_scheme);
		if (!string.IsNullOrEmpty(_parameter))
		{
			num ^= _parameter.GetHashCode();
		}
		return num;
	}

	internal static int GetAuthenticationLength(string P_0, int P_1, out object P_2)
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
		string text = null;
		switch (tokenLength)
		{
		case 5:
			text = "Basic";
			break;
		case 6:
			text = "Digest";
			break;
		case 4:
			text = "NTLM";
			break;
		case 9:
			text = "Negotiate";
			break;
		}
		string text2 = ((text != null && string.CompareOrdinal(P_0, P_1, text, 0, tokenLength) == 0) ? text : P_0.Substring(P_1, tokenLength));
		int num = P_1 + tokenLength;
		int whitespaceLength = HttpRuleParser.GetWhitespaceLength(P_0, num);
		num += whitespaceLength;
		if (num == P_0.Length || P_0[num] == ',')
		{
			P_2 = new AuthenticationHeaderValue(text2);
			return num - P_1;
		}
		if (whitespaceLength == 0)
		{
			return 0;
		}
		int num2 = num;
		int num3 = num;
		if (!TrySkipFirstBlob(P_0, ref num, ref num3))
		{
			return 0;
		}
		if (num < P_0.Length && !TryGetParametersEndIndex(P_0, ref num, ref num3))
		{
			return 0;
		}
		string text3 = P_0.Substring(num2, num3 - num2 + 1);
		P_2 = new AuthenticationHeaderValue(text2, text3);
		return num - P_1;
	}

	private static bool TrySkipFirstBlob(string P_0, ref int P_1, ref int P_2)
	{
		while (P_1 < P_0.Length && P_0[P_1] != ',')
		{
			if (P_0[P_1] == '"')
			{
				if (HttpRuleParser.GetQuotedStringLength(P_0, P_1, out var num) != HttpParseResult.Parsed)
				{
					return false;
				}
				P_1 += num;
				P_2 = P_1 - 1;
			}
			else
			{
				int whitespaceLength = HttpRuleParser.GetWhitespaceLength(P_0, P_1);
				if (whitespaceLength == 0)
				{
					P_2 = P_1;
					P_1++;
				}
				else
				{
					P_1 += whitespaceLength;
				}
			}
		}
		return true;
	}

	private static bool TryGetParametersEndIndex(string P_0, ref int P_1, ref int P_2)
	{
		int num = P_1;
		do
		{
			num++;
			num = HeaderUtilities.GetNextNonEmptyOrWhitespaceIndex(P_0, num, true, out var _);
			if (num == P_0.Length)
			{
				return true;
			}
			int tokenLength = HttpRuleParser.GetTokenLength(P_0, num);
			if (tokenLength == 0)
			{
				return false;
			}
			num += tokenLength;
			num += HttpRuleParser.GetWhitespaceLength(P_0, num);
			if (num == P_0.Length || P_0[num] != '=')
			{
				return true;
			}
			num++;
			num += HttpRuleParser.GetWhitespaceLength(P_0, num);
			int valueLength = NameValueHeaderValue.GetValueLength(P_0, num);
			if (valueLength == 0)
			{
				return false;
			}
			num += valueLength;
			P_2 = num - 1;
			num = (P_1 = num + HttpRuleParser.GetWhitespaceLength(P_0, num));
		}
		while (num < P_0.Length && P_0[num] == ',');
		return true;
	}

	object ICloneable.Clone()
	{
		return new AuthenticationHeaderValue(this);
	}
}
