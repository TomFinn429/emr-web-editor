using System.Diagnostics.CodeAnalysis;
using System.Globalization;

namespace System.Net.Http.Headers;

public class RetryConditionHeaderValue : ICloneable
{
	private readonly DateTimeOffset? _date;

	private readonly TimeSpan? _delta;

	public RetryConditionHeaderValue(DateTimeOffset P_0)
	{
		_date = P_0;
	}

	public RetryConditionHeaderValue(TimeSpan P_0)
	{
		if (P_0.TotalSeconds > 2147483647.0)
		{
			throw new ArgumentOutOfRangeException("delta");
		}
		_delta = P_0;
	}

	private RetryConditionHeaderValue(RetryConditionHeaderValue P_0)
	{
		_delta = P_0._delta;
		_date = P_0._date;
	}

	public override string ToString()
	{
		if (_delta.HasValue)
		{
			return ((int)_delta.Value.TotalSeconds).ToString(NumberFormatInfo.InvariantInfo);
		}
		return _date.GetValueOrDefault().ToString("r");
	}

	public override bool Equals([NotNullWhen(true)] object? P_0)
	{
		if (!(P_0 is RetryConditionHeaderValue retryConditionHeaderValue))
		{
			return false;
		}
		if (_delta.HasValue)
		{
			if (retryConditionHeaderValue._delta.HasValue)
			{
				return _delta.Value == retryConditionHeaderValue._delta.Value;
			}
			return false;
		}
		if (retryConditionHeaderValue._date.HasValue)
		{
			return _date.Value == retryConditionHeaderValue._date.Value;
		}
		return false;
	}

	public override int GetHashCode()
	{
		if (!_delta.HasValue)
		{
			return _date.Value.GetHashCode();
		}
		return _delta.Value.GetHashCode();
	}

	internal static int GetRetryConditionLength(string P_0, int P_1, out object P_2)
	{
		P_2 = null;
		if (string.IsNullOrEmpty(P_0) || P_1 >= P_0.Length)
		{
			return 0;
		}
		int num = P_1;
		DateTimeOffset minValue = DateTimeOffset.MinValue;
		int num2 = -1;
		char c = P_0[num];
		if (char.IsAsciiDigit(c))
		{
			int num3 = num;
			int numberLength = HttpRuleParser.GetNumberLength(P_0, num, false);
			if (numberLength == 0 || numberLength > 10)
			{
				return 0;
			}
			num += numberLength;
			num += HttpRuleParser.GetWhitespaceLength(P_0, num);
			if (num != P_0.Length)
			{
				return 0;
			}
			if (!HeaderUtilities.TryParseInt32(P_0, num3, numberLength, out num2))
			{
				return 0;
			}
		}
		else
		{
			if (!HttpDateParser.TryParse(P_0.AsSpan(num), out minValue))
			{
				return 0;
			}
			num = P_0.Length;
		}
		if (num2 == -1)
		{
			P_2 = new RetryConditionHeaderValue(minValue);
		}
		else
		{
			P_2 = new RetryConditionHeaderValue(new TimeSpan(0, 0, num2));
		}
		return num - P_1;
	}

	object ICloneable.Clone()
	{
		return new RetryConditionHeaderValue(this);
	}
}
