using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace System.Net.Http.Headers;

public class RangeHeaderValue : ICloneable
{
	private string _unit;

	private UnvalidatedObjectCollection<RangeItemHeaderValue> _ranges;

	public ICollection<RangeItemHeaderValue> Ranges => _ranges ?? (_ranges = new UnvalidatedObjectCollection<RangeItemHeaderValue>());

	public RangeHeaderValue()
	{
		_unit = "bytes";
	}

	private RangeHeaderValue(RangeHeaderValue P_0)
	{
		_unit = P_0._unit;
		if (P_0._ranges == null)
		{
			return;
		}
		foreach (RangeItemHeaderValue range in P_0._ranges)
		{
			Ranges.Add(new RangeItemHeaderValue(range));
		}
	}

	public override string ToString()
	{
		Span<char> span = stackalloc char[256];
		System.Text.ValueStringBuilder valueStringBuilder = new System.Text.ValueStringBuilder(span);
		valueStringBuilder.Append(_unit);
		valueStringBuilder.Append('=');
		if (_ranges != null)
		{
			bool flag = true;
			foreach (RangeItemHeaderValue range in _ranges)
			{
				if (flag)
				{
					flag = false;
				}
				else
				{
					valueStringBuilder.Append(", ");
				}
				if (range.From.HasValue)
				{
					valueStringBuilder.AppendSpanFormattable(range.From.GetValueOrDefault());
				}
				valueStringBuilder.Append('-');
				if (range.To.HasValue)
				{
					valueStringBuilder.AppendSpanFormattable(range.To.GetValueOrDefault());
				}
			}
		}
		return valueStringBuilder.ToString();
	}

	public override bool Equals([NotNullWhen(true)] object? P_0)
	{
		if (!(P_0 is RangeHeaderValue rangeHeaderValue))
		{
			return false;
		}
		if (string.Equals(_unit, rangeHeaderValue._unit, StringComparison.OrdinalIgnoreCase))
		{
			return HeaderUtilities.AreEqualCollections(_ranges, rangeHeaderValue._ranges);
		}
		return false;
	}

	public override int GetHashCode()
	{
		int num = StringComparer.OrdinalIgnoreCase.GetHashCode(_unit);
		if (_ranges != null)
		{
			foreach (RangeItemHeaderValue range in _ranges)
			{
				num ^= range.GetHashCode();
			}
		}
		return num;
	}

	internal static int GetRangeLength(string P_0, int P_1, out object P_2)
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
		RangeHeaderValue rangeHeaderValue = new RangeHeaderValue();
		rangeHeaderValue._unit = P_0.Substring(P_1, tokenLength);
		int num = P_1 + tokenLength;
		num += HttpRuleParser.GetWhitespaceLength(P_0, num);
		if (num == P_0.Length || P_0[num] != '=')
		{
			return 0;
		}
		num++;
		num += HttpRuleParser.GetWhitespaceLength(P_0, num);
		int rangeItemListLength = RangeItemHeaderValue.GetRangeItemListLength(P_0, num, rangeHeaderValue.Ranges);
		if (rangeItemListLength == 0)
		{
			return 0;
		}
		num += rangeItemListLength;
		P_2 = rangeHeaderValue;
		return num - P_1;
	}

	object ICloneable.Clone()
	{
		return new RangeHeaderValue(this);
	}
}
