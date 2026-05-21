using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Runtime.CompilerServices;

namespace System.Net.Http.Headers;

public class RangeItemHeaderValue : ICloneable
{
	private readonly long? _from;

	private readonly long? _to;

	public long? From => _from;

	public long? To => _to;

	public RangeItemHeaderValue(long? P_0, long? P_1)
	{
		if (!P_0.HasValue && !P_1.HasValue)
		{
			throw new ArgumentException("net_http_headers_invalid_range");
		}
		if (P_0.HasValue && P_0.Value < 0)
		{
			throw new ArgumentOutOfRangeException("from");
		}
		if (P_1.HasValue && P_1.Value < 0)
		{
			throw new ArgumentOutOfRangeException("to");
		}
		if (P_0.HasValue && P_1.HasValue && P_0.Value > P_1.Value)
		{
			throw new ArgumentOutOfRangeException("from");
		}
		_from = P_0;
		_to = P_1;
	}

	internal RangeItemHeaderValue(RangeItemHeaderValue P_0)
	{
		_from = P_0._from;
		_to = P_0._to;
	}

	public override string ToString()
	{
		Span<char> span = stackalloc char[128];
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler;
		IFormatProvider invariantCulture;
		Span<char> span2;
		if (!_from.HasValue)
		{
			invariantCulture = CultureInfo.InvariantCulture;
			IFormatProvider formatProvider = invariantCulture;
			span2 = span;
			Span<char> span3 = span2;
			defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 1, invariantCulture, span2);
			defaultInterpolatedStringHandler.AppendLiteral("-");
			defaultInterpolatedStringHandler.AppendFormatted(_to.Value);
			return string.Create(formatProvider, span3, ref defaultInterpolatedStringHandler);
		}
		if (!_to.HasValue)
		{
			invariantCulture = CultureInfo.InvariantCulture;
			IFormatProvider formatProvider2 = invariantCulture;
			span2 = span;
			Span<char> span4 = span2;
			defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 1, invariantCulture, span2);
			defaultInterpolatedStringHandler.AppendFormatted(_from.Value);
			defaultInterpolatedStringHandler.AppendLiteral("-");
			return string.Create(formatProvider2, span4, ref defaultInterpolatedStringHandler);
		}
		invariantCulture = CultureInfo.InvariantCulture;
		IFormatProvider formatProvider3 = invariantCulture;
		span2 = span;
		Span<char> span5 = span2;
		defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2, invariantCulture, span2);
		defaultInterpolatedStringHandler.AppendFormatted(_from.Value);
		defaultInterpolatedStringHandler.AppendLiteral("-");
		defaultInterpolatedStringHandler.AppendFormatted(_to.Value);
		return string.Create(formatProvider3, span5, ref defaultInterpolatedStringHandler);
	}

	public override bool Equals([NotNullWhen(true)] object? P_0)
	{
		if (!(P_0 is RangeItemHeaderValue rangeItemHeaderValue))
		{
			return false;
		}
		if (_from == rangeItemHeaderValue._from)
		{
			return _to == rangeItemHeaderValue._to;
		}
		return false;
	}

	public override int GetHashCode()
	{
		if (!_from.HasValue)
		{
			return _to.GetHashCode();
		}
		if (!_to.HasValue)
		{
			return _from.GetHashCode();
		}
		return _from.GetHashCode() ^ _to.GetHashCode();
	}

	internal static int GetRangeItemListLength(string P_0, int P_1, ICollection<RangeItemHeaderValue> P_2)
	{
		if (string.IsNullOrEmpty(P_0) || P_1 >= P_0.Length)
		{
			return 0;
		}
		int nextNonEmptyOrWhitespaceIndex = HeaderUtilities.GetNextNonEmptyOrWhitespaceIndex(P_0, P_1, true, out var _);
		if (nextNonEmptyOrWhitespaceIndex == P_0.Length)
		{
			return 0;
		}
		do
		{
			RangeItemHeaderValue rangeItemHeaderValue;
			int rangeItemLength = GetRangeItemLength(P_0, nextNonEmptyOrWhitespaceIndex, out rangeItemHeaderValue);
			if (rangeItemLength == 0)
			{
				return 0;
			}
			P_2.Add(rangeItemHeaderValue);
			nextNonEmptyOrWhitespaceIndex += rangeItemLength;
			nextNonEmptyOrWhitespaceIndex = HeaderUtilities.GetNextNonEmptyOrWhitespaceIndex(P_0, nextNonEmptyOrWhitespaceIndex, true, out var flag2);
			if (nextNonEmptyOrWhitespaceIndex < P_0.Length && !flag2)
			{
				return 0;
			}
		}
		while (nextNonEmptyOrWhitespaceIndex != P_0.Length);
		return nextNonEmptyOrWhitespaceIndex - P_1;
	}

	internal static int GetRangeItemLength(string P_0, int P_1, out RangeItemHeaderValue P_2)
	{
		P_2 = null;
		if (string.IsNullOrEmpty(P_0) || P_1 >= P_0.Length)
		{
			return 0;
		}
		int num = P_1;
		int num2 = num;
		int numberLength = HttpRuleParser.GetNumberLength(P_0, num, false);
		if (numberLength > 19)
		{
			return 0;
		}
		num += numberLength;
		num += HttpRuleParser.GetWhitespaceLength(P_0, num);
		if (num == P_0.Length || P_0[num] != '-')
		{
			return 0;
		}
		num++;
		num += HttpRuleParser.GetWhitespaceLength(P_0, num);
		int num3 = num;
		int num4 = 0;
		if (num < P_0.Length)
		{
			num4 = HttpRuleParser.GetNumberLength(P_0, num, false);
			if (num4 > 19)
			{
				return 0;
			}
			num += num4;
			num += HttpRuleParser.GetWhitespaceLength(P_0, num);
		}
		if (numberLength == 0 && num4 == 0)
		{
			return 0;
		}
		long num5 = 0L;
		if (numberLength > 0 && !HeaderUtilities.TryParseInt64(P_0, num2, numberLength, out num5))
		{
			return 0;
		}
		long num6 = 0L;
		if (num4 > 0 && !HeaderUtilities.TryParseInt64(P_0, num3, num4, out num6))
		{
			return 0;
		}
		if (numberLength > 0 && num4 > 0 && num5 > num6)
		{
			return 0;
		}
		P_2 = new RangeItemHeaderValue((numberLength == 0) ? ((long?)null) : new long?(num5), (num4 == 0) ? ((long?)null) : new long?(num6));
		return num - P_1;
	}

	object ICloneable.Clone()
	{
		return new RangeItemHeaderValue(this);
	}
}
