using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Text;

namespace System.Net.Http.Headers;

public class NameValueHeaderValue : ICloneable
{
	private static readonly Func<NameValueHeaderValue> s_defaultNameValueCreator = CreateNameValue;

	private string _name;

	private string _value;

	public string Name => _name;

	public string? Value => _value;

	internal NameValueHeaderValue()
	{
	}

	public NameValueHeaderValue(string P_0)
		: this(P_0, null)
	{
	}

	public NameValueHeaderValue(string P_0, string? P_1)
	{
		CheckNameValueFormat(P_0, P_1);
		_name = P_0;
		_value = P_1;
	}

	protected internal NameValueHeaderValue(NameValueHeaderValue P_0)
	{
		_name = P_0._name;
		_value = P_0._value;
	}

	public override int GetHashCode()
	{
		int hashCode = StringComparer.OrdinalIgnoreCase.GetHashCode(_name);
		if (!string.IsNullOrEmpty(_value))
		{
			if (_value[0] == '"')
			{
				return hashCode ^ _value.GetHashCode();
			}
			return hashCode ^ StringComparer.OrdinalIgnoreCase.GetHashCode(_value);
		}
		return hashCode;
	}

	public override bool Equals([NotNullWhen(true)] object? P_0)
	{
		if (!(P_0 is NameValueHeaderValue nameValueHeaderValue))
		{
			return false;
		}
		if (!string.Equals(_name, nameValueHeaderValue._name, StringComparison.OrdinalIgnoreCase))
		{
			return false;
		}
		if (string.IsNullOrEmpty(_value))
		{
			return string.IsNullOrEmpty(nameValueHeaderValue._value);
		}
		if (_value[0] == '"')
		{
			return string.Equals(_value, nameValueHeaderValue._value, StringComparison.Ordinal);
		}
		return string.Equals(_value, nameValueHeaderValue._value, StringComparison.OrdinalIgnoreCase);
	}

	public override string ToString()
	{
		if (!string.IsNullOrEmpty(_value))
		{
			return _name + "=" + _value;
		}
		return _name;
	}

	private void AddToStringBuilder(StringBuilder P_0)
	{
		if (GetType() != typeof(NameValueHeaderValue))
		{
			P_0.Append(ToString());
			return;
		}
		P_0.Append(_name);
		if (!string.IsNullOrEmpty(_value))
		{
			P_0.Append('=');
			P_0.Append(_value);
		}
	}

	internal static void ToString(UnvalidatedObjectCollection<NameValueHeaderValue> P_0, char P_1, bool P_2, StringBuilder P_3)
	{
		if (P_0 == null || P_0.Count == 0)
		{
			return;
		}
		foreach (NameValueHeaderValue item in P_0)
		{
			if (P_2 || P_3.Length > 0)
			{
				P_3.Append(P_1);
				P_3.Append(' ');
			}
			item.AddToStringBuilder(P_3);
		}
	}

	internal static int GetHashCode(UnvalidatedObjectCollection<NameValueHeaderValue> P_0)
	{
		if (P_0 == null || P_0.Count == 0)
		{
			return 0;
		}
		int num = 0;
		foreach (NameValueHeaderValue item in P_0)
		{
			num ^= item.GetHashCode();
		}
		return num;
	}

	internal static int GetNameValueLength(string P_0, int P_1, out NameValueHeaderValue P_2)
	{
		return GetNameValueLength(P_0, P_1, s_defaultNameValueCreator, out P_2);
	}

	internal static int GetNameValueLength(string P_0, int P_1, Func<NameValueHeaderValue> P_2, out NameValueHeaderValue P_3)
	{
		P_3 = null;
		if (string.IsNullOrEmpty(P_0) || P_1 >= P_0.Length)
		{
			return 0;
		}
		int tokenLength = HttpRuleParser.GetTokenLength(P_0, P_1);
		if (tokenLength == 0)
		{
			return 0;
		}
		string name = P_0.Substring(P_1, tokenLength);
		int num = P_1 + tokenLength;
		num += HttpRuleParser.GetWhitespaceLength(P_0, num);
		if (num == P_0.Length || P_0[num] != '=')
		{
			P_3 = P_2();
			P_3._name = name;
			num += HttpRuleParser.GetWhitespaceLength(P_0, num);
			return num - P_1;
		}
		num++;
		num += HttpRuleParser.GetWhitespaceLength(P_0, num);
		int valueLength = GetValueLength(P_0, num);
		if (valueLength == 0)
		{
			return 0;
		}
		P_3 = P_2();
		P_3._name = name;
		P_3._value = P_0.Substring(num, valueLength);
		num += valueLength;
		num += HttpRuleParser.GetWhitespaceLength(P_0, num);
		return num - P_1;
	}

	internal static int GetNameValueListLength(string P_0, int P_1, char P_2, UnvalidatedObjectCollection<NameValueHeaderValue> P_3)
	{
		if (string.IsNullOrEmpty(P_0) || P_1 >= P_0.Length)
		{
			return 0;
		}
		int num = P_1 + HttpRuleParser.GetWhitespaceLength(P_0, P_1);
		while (true)
		{
			NameValueHeaderValue nameValueHeaderValue;
			int nameValueLength = GetNameValueLength(P_0, num, s_defaultNameValueCreator, out nameValueHeaderValue);
			if (nameValueLength == 0)
			{
				return 0;
			}
			P_3.Add(nameValueHeaderValue);
			num += nameValueLength;
			num += HttpRuleParser.GetWhitespaceLength(P_0, num);
			if (num == P_0.Length || P_0[num] != P_2)
			{
				break;
			}
			num++;
			num += HttpRuleParser.GetWhitespaceLength(P_0, num);
		}
		return num - P_1;
	}

	internal static NameValueHeaderValue Find(UnvalidatedObjectCollection<NameValueHeaderValue> P_0, string P_1)
	{
		if (P_0 == null || P_0.Count == 0)
		{
			return null;
		}
		foreach (NameValueHeaderValue item in P_0)
		{
			if (string.Equals(item.Name, P_1, StringComparison.OrdinalIgnoreCase))
			{
				return item;
			}
		}
		return null;
	}

	internal static int GetValueLength(string P_0, int P_1)
	{
		if (P_1 >= P_0.Length)
		{
			return 0;
		}
		int tokenLength = HttpRuleParser.GetTokenLength(P_0, P_1);
		if (tokenLength == 0 && HttpRuleParser.GetQuotedStringLength(P_0, P_1, out tokenLength) != HttpParseResult.Parsed)
		{
			return 0;
		}
		return tokenLength;
	}

	private static void CheckNameValueFormat(string P_0, string P_1)
	{
		HeaderUtilities.CheckValidToken(P_0, "name");
		CheckValueFormat(P_1);
	}

	private static void CheckValueFormat(string P_0)
	{
		if (string.IsNullOrEmpty(P_0))
		{
			return;
		}
		if (P_0.StartsWith(' ') || P_0.StartsWith('\t') || P_0.EndsWith(' ') || P_0.EndsWith('\t'))
		{
			ThrowFormatException(P_0);
		}
		if (P_0[0] == '"')
		{
			if (HttpRuleParser.GetQuotedStringLength(P_0, 0, out var num) != HttpParseResult.Parsed || num != P_0.Length)
			{
				ThrowFormatException(P_0);
			}
		}
		else if (HttpRuleParser.ContainsNewLine(P_0))
		{
			ThrowFormatException(P_0);
		}
		static void ThrowFormatException(string text)
		{
			throw new FormatException(System.SR.Format(CultureInfo.InvariantCulture, "net_http_headers_invalid_value", text));
		}
	}

	private static NameValueHeaderValue CreateNameValue()
	{
		return new NameValueHeaderValue();
	}

	object ICloneable.Clone()
	{
		return new NameValueHeaderValue(this);
	}
}
