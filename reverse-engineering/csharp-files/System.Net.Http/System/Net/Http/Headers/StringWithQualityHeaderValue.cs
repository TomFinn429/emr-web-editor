using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Runtime.CompilerServices;

namespace System.Net.Http.Headers;

public class StringWithQualityHeaderValue : ICloneable
{
	private readonly string _value;

	private readonly double? _quality;

	public StringWithQualityHeaderValue(string P_0)
	{
		HeaderUtilities.CheckValidToken(P_0, "value");
		_value = P_0;
	}

	public StringWithQualityHeaderValue(string P_0, double P_1)
	{
		HeaderUtilities.CheckValidToken(P_0, "value");
		if (P_1 < 0.0 || P_1 > 1.0)
		{
			throw new ArgumentOutOfRangeException("quality");
		}
		_value = P_0;
		_quality = P_1;
	}

	private StringWithQualityHeaderValue(StringWithQualityHeaderValue P_0)
	{
		_value = P_0._value;
		_quality = P_0._quality;
	}

	public override string ToString()
	{
		if (_quality.HasValue)
		{
			IFormatProvider invariantCulture = CultureInfo.InvariantCulture;
			IFormatProvider formatProvider = invariantCulture;
			Span<char> span = stackalloc char[128];
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(4, 2, invariantCulture, span);
			defaultInterpolatedStringHandler.AppendFormatted(_value);
			defaultInterpolatedStringHandler.AppendLiteral("; q=");
			defaultInterpolatedStringHandler.AppendFormatted(_quality.Value, "0.0##");
			return string.Create(formatProvider, span, ref defaultInterpolatedStringHandler);
		}
		return _value;
	}

	public override bool Equals([NotNullWhen(true)] object? P_0)
	{
		if (!(P_0 is StringWithQualityHeaderValue stringWithQualityHeaderValue))
		{
			return false;
		}
		if (!string.Equals(_value, stringWithQualityHeaderValue._value, StringComparison.OrdinalIgnoreCase))
		{
			return false;
		}
		if (_quality.HasValue)
		{
			if (stringWithQualityHeaderValue._quality.HasValue)
			{
				return _quality.Value == stringWithQualityHeaderValue._quality.Value;
			}
			return false;
		}
		return !stringWithQualityHeaderValue._quality.HasValue;
	}

	public override int GetHashCode()
	{
		int num = StringComparer.OrdinalIgnoreCase.GetHashCode(_value);
		if (_quality.HasValue)
		{
			num ^= _quality.Value.GetHashCode();
		}
		return num;
	}

	internal static int GetStringWithQualityLength(string P_0, int P_1, out object P_2)
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
		if (num == P_0.Length || P_0[num] != ';')
		{
			P_2 = new StringWithQualityHeaderValue(text);
			return num - P_1;
		}
		num++;
		num += HttpRuleParser.GetWhitespaceLength(P_0, num);
		if (!TryReadQuality(P_0, out var num2, ref num))
		{
			return 0;
		}
		P_2 = new StringWithQualityHeaderValue(text, num2);
		return num - P_1;
	}

	private static bool TryReadQuality(string P_0, out double P_1, ref int P_2)
	{
		int num = P_2;
		P_1 = 0.0;
		if (num == P_0.Length || (P_0[num] != 'q' && P_0[num] != 'Q'))
		{
			return false;
		}
		num++;
		num += HttpRuleParser.GetWhitespaceLength(P_0, num);
		if (num == P_0.Length || P_0[num] != '=')
		{
			return false;
		}
		num++;
		num += HttpRuleParser.GetWhitespaceLength(P_0, num);
		if (num == P_0.Length)
		{
			return false;
		}
		int numberLength = HttpRuleParser.GetNumberLength(P_0, num, true);
		if (numberLength == 0)
		{
			return false;
		}
		if (!double.TryParse(P_0.AsSpan(num, numberLength), NumberStyles.AllowDecimalPoint, NumberFormatInfo.InvariantInfo, out P_1))
		{
			return false;
		}
		if (P_1 < 0.0 || P_1 > 1.0)
		{
			return false;
		}
		num += numberLength;
		num += HttpRuleParser.GetWhitespaceLength(P_0, num);
		P_2 = num;
		return true;
	}

	object ICloneable.Clone()
	{
		return new StringWithQualityHeaderValue(this);
	}
}
