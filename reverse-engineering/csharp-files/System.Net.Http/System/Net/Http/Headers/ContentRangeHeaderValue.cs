using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace System.Net.Http.Headers;

public class ContentRangeHeaderValue : ICloneable
{
	private string _unit;

	private long? _from;

	private long? _to;

	private long? _length;

	public bool HasLength => _length.HasValue;

	public bool HasRange => _from.HasValue;

	private ContentRangeHeaderValue()
	{
	}

	private ContentRangeHeaderValue(ContentRangeHeaderValue P_0)
	{
		_from = P_0._from;
		_to = P_0._to;
		_length = P_0._length;
		_unit = P_0._unit;
	}

	public override bool Equals([NotNullWhen(true)] object? P_0)
	{
		if (!(P_0 is ContentRangeHeaderValue contentRangeHeaderValue))
		{
			return false;
		}
		if (_from == contentRangeHeaderValue._from && _to == contentRangeHeaderValue._to && _length == contentRangeHeaderValue._length)
		{
			return string.Equals(_unit, contentRangeHeaderValue._unit, StringComparison.OrdinalIgnoreCase);
		}
		return false;
	}

	public override int GetHashCode()
	{
		int num = StringComparer.OrdinalIgnoreCase.GetHashCode(_unit);
		if (HasRange)
		{
			num = num ^ _from.GetHashCode() ^ _to.GetHashCode();
		}
		if (HasLength)
		{
			num ^= _length.GetHashCode();
		}
		return num;
	}

	public override string ToString()
	{
		Span<char> span = stackalloc char[256];
		System.Text.ValueStringBuilder valueStringBuilder = new System.Text.ValueStringBuilder(span);
		valueStringBuilder.Append(_unit);
		valueStringBuilder.Append(' ');
		if (HasRange)
		{
			valueStringBuilder.AppendSpanFormattable(_from.Value);
			valueStringBuilder.Append('-');
			valueStringBuilder.AppendSpanFormattable(_to.Value);
		}
		else
		{
			valueStringBuilder.Append('*');
		}
		valueStringBuilder.Append('/');
		if (HasLength)
		{
			valueStringBuilder.AppendSpanFormattable(_length.Value);
		}
		else
		{
			valueStringBuilder.Append('*');
		}
		return valueStringBuilder.ToString();
	}

	internal static int GetContentRangeLength(string P_0, int P_1, out object P_2)
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
		int whitespaceLength = HttpRuleParser.GetWhitespaceLength(P_0, num);
		if (whitespaceLength == 0)
		{
			return 0;
		}
		num += whitespaceLength;
		if (num == P_0.Length)
		{
			return 0;
		}
		int num2 = num;
		if (!TryGetRangeLength(P_0, ref num, out var num3, out var num4, out var num5))
		{
			return 0;
		}
		if (num == P_0.Length || P_0[num] != '/')
		{
			return 0;
		}
		num++;
		num += HttpRuleParser.GetWhitespaceLength(P_0, num);
		if (num == P_0.Length)
		{
			return 0;
		}
		int num6 = num;
		if (!TryGetLengthLength(P_0, ref num, out var num7))
		{
			return 0;
		}
		if (!TryCreateContentRange(P_0, text, num2, num3, num4, num5, num6, num7, out P_2))
		{
			return 0;
		}
		return num - P_1;
	}

	private static bool TryGetLengthLength(string P_0, ref int P_1, out int P_2)
	{
		P_2 = 0;
		if (P_0[P_1] == '*')
		{
			P_1++;
		}
		else
		{
			P_2 = HttpRuleParser.GetNumberLength(P_0, P_1, false);
			if (P_2 == 0 || P_2 > 19)
			{
				return false;
			}
			P_1 += P_2;
		}
		P_1 += HttpRuleParser.GetWhitespaceLength(P_0, P_1);
		return true;
	}

	private static bool TryGetRangeLength(string P_0, ref int P_1, out int P_2, out int P_3, out int P_4)
	{
		P_2 = 0;
		P_3 = 0;
		P_4 = 0;
		if (P_0[P_1] == '*')
		{
			P_1++;
		}
		else
		{
			P_2 = HttpRuleParser.GetNumberLength(P_0, P_1, false);
			if (P_2 == 0 || P_2 > 19)
			{
				return false;
			}
			P_1 += P_2;
			P_1 += HttpRuleParser.GetWhitespaceLength(P_0, P_1);
			if (P_1 == P_0.Length || P_0[P_1] != '-')
			{
				return false;
			}
			P_1++;
			P_1 += HttpRuleParser.GetWhitespaceLength(P_0, P_1);
			if (P_1 == P_0.Length)
			{
				return false;
			}
			P_3 = P_1;
			P_4 = HttpRuleParser.GetNumberLength(P_0, P_1, false);
			if (P_4 == 0 || P_4 > 19)
			{
				return false;
			}
			P_1 += P_4;
		}
		P_1 += HttpRuleParser.GetWhitespaceLength(P_0, P_1);
		return true;
	}

	private static bool TryCreateContentRange(string P_0, string P_1, int P_2, int P_3, int P_4, int P_5, int P_6, int P_7, [NotNullWhen(true)] out object P_8)
	{
		P_8 = null;
		long num = 0L;
		if (P_3 > 0 && !HeaderUtilities.TryParseInt64(P_0, P_2, P_3, out num))
		{
			return false;
		}
		long num2 = 0L;
		if (P_5 > 0 && !HeaderUtilities.TryParseInt64(P_0, P_4, P_5, out num2))
		{
			return false;
		}
		if (P_3 > 0 && P_5 > 0 && num > num2)
		{
			return false;
		}
		long num3 = 0L;
		if (P_7 > 0 && !HeaderUtilities.TryParseInt64(P_0, P_6, P_7, out num3))
		{
			return false;
		}
		if (P_5 > 0 && P_7 > 0 && num2 >= num3)
		{
			return false;
		}
		ContentRangeHeaderValue contentRangeHeaderValue = new ContentRangeHeaderValue();
		contentRangeHeaderValue._unit = P_1;
		if (P_3 > 0)
		{
			contentRangeHeaderValue._from = num;
			contentRangeHeaderValue._to = num2;
		}
		if (P_7 > 0)
		{
			contentRangeHeaderValue._length = num3;
		}
		P_8 = contentRangeHeaderValue;
		return true;
	}

	object ICloneable.Clone()
	{
		return new ContentRangeHeaderValue(this);
	}
}
