using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Text;

namespace System.Net.Http.Headers;

public class WarningHeaderValue : ICloneable
{
	private readonly int _code;

	private readonly string _agent;

	private readonly string _text;

	private readonly DateTimeOffset? _date;

	public WarningHeaderValue(int P_0, string P_1, string P_2)
	{
		CheckCode(P_0);
		CheckAgent(P_1);
		HeaderUtilities.CheckValidQuotedString(P_2, "text");
		_code = P_0;
		_agent = P_1;
		_text = P_2;
	}

	public WarningHeaderValue(int P_0, string P_1, string P_2, DateTimeOffset P_3)
	{
		CheckCode(P_0);
		CheckAgent(P_1);
		HeaderUtilities.CheckValidQuotedString(P_2, "text");
		_code = P_0;
		_agent = P_1;
		_text = P_2;
		_date = P_3;
	}

	private WarningHeaderValue(WarningHeaderValue P_0)
	{
		_code = P_0._code;
		_agent = P_0._agent;
		_text = P_0._text;
		_date = P_0._date;
	}

	public override string ToString()
	{
		Span<char> span = stackalloc char[256];
		System.Text.ValueStringBuilder valueStringBuilder = new System.Text.ValueStringBuilder(span);
		valueStringBuilder.AppendSpanFormattable(_code, "000", NumberFormatInfo.InvariantInfo);
		valueStringBuilder.Append(' ');
		valueStringBuilder.Append(_agent);
		valueStringBuilder.Append(' ');
		valueStringBuilder.Append(_text);
		if (_date.HasValue)
		{
			valueStringBuilder.Append(" \"");
			valueStringBuilder.AppendSpanFormattable(_date.Value, "r");
			valueStringBuilder.Append('"');
		}
		return valueStringBuilder.ToString();
	}

	public override bool Equals([NotNullWhen(true)] object? P_0)
	{
		if (!(P_0 is WarningHeaderValue warningHeaderValue))
		{
			return false;
		}
		if (_code != warningHeaderValue._code || !string.Equals(_agent, warningHeaderValue._agent, StringComparison.OrdinalIgnoreCase) || !string.Equals(_text, warningHeaderValue._text, StringComparison.Ordinal))
		{
			return false;
		}
		if (_date.HasValue)
		{
			if (warningHeaderValue._date.HasValue)
			{
				return _date.Value == warningHeaderValue._date.Value;
			}
			return false;
		}
		return !warningHeaderValue._date.HasValue;
	}

	public override int GetHashCode()
	{
		int num = _code.GetHashCode() ^ StringComparer.OrdinalIgnoreCase.GetHashCode(_agent) ^ _text.GetHashCode();
		if (_date.HasValue)
		{
			num ^= _date.Value.GetHashCode();
		}
		return num;
	}

	internal static int GetWarningLength(string P_0, int P_1, out object P_2)
	{
		P_2 = null;
		if (string.IsNullOrEmpty(P_0) || P_1 >= P_0.Length)
		{
			return 0;
		}
		int num = P_1;
		if (!TryReadCode(P_0, ref num, out var num2))
		{
			return 0;
		}
		if (!TryReadAgent(P_0, ref num, out var text))
		{
			return 0;
		}
		int num3 = num;
		if (HttpRuleParser.GetQuotedStringLength(P_0, num, out var num4) != HttpParseResult.Parsed)
		{
			return 0;
		}
		string text2 = P_0.Substring(num3, num4);
		num += num4;
		if (!TryReadDate(P_0, ref num, out var dateTimeOffset))
		{
			return 0;
		}
		P_2 = ((!dateTimeOffset.HasValue) ? new WarningHeaderValue(num2, text, text2) : new WarningHeaderValue(num2, text, text2, dateTimeOffset.Value));
		return num - P_1;
	}

	private static bool TryReadAgent(string P_0, ref int P_1, [NotNullWhen(true)] out string P_2)
	{
		P_2 = null;
		int hostLength = HttpRuleParser.GetHostLength(P_0, P_1, true);
		if (hostLength == 0)
		{
			return false;
		}
		P_2 = P_0.Substring(P_1, hostLength);
		P_1 += hostLength;
		int whitespaceLength = HttpRuleParser.GetWhitespaceLength(P_0, P_1);
		P_1 += whitespaceLength;
		if (whitespaceLength == 0 || P_1 == P_0.Length)
		{
			return false;
		}
		return true;
	}

	private static bool TryReadCode(string P_0, ref int P_1, out int P_2)
	{
		P_2 = 0;
		int numberLength = HttpRuleParser.GetNumberLength(P_0, P_1, false);
		if (numberLength == 0 || numberLength > 3)
		{
			return false;
		}
		if (!HeaderUtilities.TryParseInt32(P_0, P_1, numberLength, out P_2))
		{
			return false;
		}
		P_1 += numberLength;
		int whitespaceLength = HttpRuleParser.GetWhitespaceLength(P_0, P_1);
		P_1 += whitespaceLength;
		if (whitespaceLength == 0 || P_1 == P_0.Length)
		{
			return false;
		}
		return true;
	}

	private static bool TryReadDate(string P_0, ref int P_1, out DateTimeOffset? P_2)
	{
		P_2 = null;
		int whitespaceLength = HttpRuleParser.GetWhitespaceLength(P_0, P_1);
		P_1 += whitespaceLength;
		if (P_1 < P_0.Length && P_0[P_1] == '"')
		{
			if (whitespaceLength == 0)
			{
				return false;
			}
			P_1++;
			int num = P_1;
			while (P_1 < P_0.Length && P_0[P_1] != '"')
			{
				P_1++;
			}
			if (P_1 == P_0.Length || P_1 == num)
			{
				return false;
			}
			if (!HttpDateParser.TryParse(P_0.AsSpan(num, P_1 - num), out var value))
			{
				return false;
			}
			P_2 = value;
			P_1++;
			P_1 += HttpRuleParser.GetWhitespaceLength(P_0, P_1);
		}
		return true;
	}

	object ICloneable.Clone()
	{
		return new WarningHeaderValue(this);
	}

	private static void CheckCode(int P_0)
	{
		if (P_0 < 0 || P_0 > 999)
		{
			throw new ArgumentOutOfRangeException("code");
		}
	}

	private static void CheckAgent(string P_0)
	{
		if (string.IsNullOrEmpty(P_0))
		{
			throw new ArgumentException("net_http_argument_empty_string", "agent");
		}
		if (HttpRuleParser.GetHostLength(P_0, 0, true) != P_0.Length)
		{
			throw new FormatException(System.SR.Format(CultureInfo.InvariantCulture, "net_http_headers_invalid_value", P_0));
		}
	}
}
