using System.Globalization;
using System.Text;

namespace System.Xml.Schema;

internal struct XsdDuration
{
	private enum Parts
	{
		HasNone = 0,
		HasYears = 1,
		HasMonths = 2,
		HasDays = 4,
		HasHours = 8,
		HasMinutes = 0x10,
		HasSeconds = 0x20
	}

	public enum DurationType
	{
		Duration,
		YearMonthDuration,
		DayTimeDuration
	}

	private int _years;

	private int _months;

	private int _days;

	private int _hours;

	private int _minutes;

	private int _seconds;

	private uint _nanoseconds;

	public bool IsNegative => (_nanoseconds & 0x80000000u) != 0;

	public int Years => _years;

	public int Months => _months;

	public int Days => _days;

	public int Hours => _hours;

	public int Minutes => _minutes;

	public int Seconds => _seconds;

	public int Nanoseconds => (int)(_nanoseconds & 0x7FFFFFFF);

	public XsdDuration(bool P_0, int P_1, int P_2, int P_3, int P_4, int P_5, int P_6, int P_7)
	{
		if (P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("years");
		}
		if (P_2 < 0)
		{
			throw new ArgumentOutOfRangeException("months");
		}
		if (P_3 < 0)
		{
			throw new ArgumentOutOfRangeException("days");
		}
		if (P_4 < 0)
		{
			throw new ArgumentOutOfRangeException("hours");
		}
		if (P_5 < 0)
		{
			throw new ArgumentOutOfRangeException("minutes");
		}
		if (P_6 < 0)
		{
			throw new ArgumentOutOfRangeException("seconds");
		}
		if (P_7 < 0 || P_7 > 999999999)
		{
			throw new ArgumentOutOfRangeException("nanoseconds");
		}
		_years = P_1;
		_months = P_2;
		_days = P_3;
		_hours = P_4;
		_minutes = P_5;
		_seconds = P_6;
		_nanoseconds = (uint)P_7;
		if (P_0)
		{
			_nanoseconds |= 2147483648u;
		}
	}

	public XsdDuration(TimeSpan P_0, DurationType P_1)
	{
		long ticks = P_0.Ticks;
		bool flag;
		ulong num;
		if (ticks < 0)
		{
			flag = true;
			num = (ulong)(-ticks);
		}
		else
		{
			flag = false;
			num = (ulong)ticks;
		}
		if (P_1 == DurationType.YearMonthDuration)
		{
			int num2 = (int)(num / 315360000000000L);
			int num3 = (int)(num % 315360000000000L / 25920000000000L);
			if (num3 == 12)
			{
				num2++;
				num3 = 0;
			}
			this = new XsdDuration(flag, num2, num3, 0, 0, 0, 0, 0);
			return;
		}
		_nanoseconds = (uint)((int)(num % 10000000) * 100);
		if (flag)
		{
			_nanoseconds |= 2147483648u;
		}
		_years = 0;
		_months = 0;
		_days = (int)(num / 864000000000L);
		_hours = (int)(num / 36000000000L % 24);
		_minutes = (int)(num / 600000000 % 60);
		_seconds = (int)(num / 10000000 % 60);
	}

	public XsdDuration(string P_0, DurationType P_1)
	{
		XsdDuration xsdDuration;
		Exception ex = TryParse(P_0, P_1, out xsdDuration);
		if (ex != null)
		{
			throw ex;
		}
		_years = xsdDuration.Years;
		_months = xsdDuration.Months;
		_days = xsdDuration.Days;
		_hours = xsdDuration.Hours;
		_minutes = xsdDuration.Minutes;
		_seconds = xsdDuration.Seconds;
		_nanoseconds = (uint)xsdDuration.Nanoseconds;
		if (xsdDuration.IsNegative)
		{
			_nanoseconds |= 2147483648u;
		}
	}

	public TimeSpan ToTimeSpan(DurationType P_0)
	{
		TimeSpan result;
		Exception ex = TryToTimeSpan(P_0, out result);
		if (ex != null)
		{
			throw ex;
		}
		return result;
	}

	internal Exception TryToTimeSpan(out TimeSpan P_0)
	{
		return TryToTimeSpan(DurationType.Duration, out P_0);
	}

	internal Exception TryToTimeSpan(DurationType P_0, out TimeSpan P_1)
	{
		ulong num = 0uL;
		checked
		{
			try
			{
				if (P_0 != DurationType.DayTimeDuration)
				{
					num += ((ulong)_years + unchecked(checked((ulong)_months) / 12)) * 365;
					num += unchecked(checked((ulong)_months) % 12) * 30;
				}
				if (P_0 != DurationType.YearMonthDuration)
				{
					num += (ulong)_days;
					num *= 24;
					num += (ulong)_hours;
					num *= 60;
					num += (ulong)_minutes;
					num *= 60;
					num += (ulong)_seconds;
					num *= 10000000;
					num += unchecked(checked((ulong)Nanoseconds) / 100);
				}
				else
				{
					num *= 864000000000L;
				}
				if (IsNegative)
				{
					if (num == 9223372036854775808uL)
					{
						P_1 = new TimeSpan(-9223372036854775808L);
					}
					else
					{
						P_1 = new TimeSpan(-(long)num);
					}
				}
				else
				{
					P_1 = new TimeSpan((long)num);
				}
				return null;
			}
			catch (OverflowException)
			{
				P_1 = TimeSpan.MinValue;
				return new OverflowException(System.SR.Format("XmlConvert_Overflow", P_0, "TimeSpan"));
			}
		}
	}

	public override string ToString()
	{
		return ToString(DurationType.Duration);
	}

	internal string ToString(DurationType P_0)
	{
		Span<char> span = stackalloc char[20];
		System.Text.ValueStringBuilder valueStringBuilder = new System.Text.ValueStringBuilder(span);
		if (IsNegative)
		{
			valueStringBuilder.Append('-');
		}
		valueStringBuilder.Append('P');
		if (P_0 != DurationType.DayTimeDuration)
		{
			if (_years != 0)
			{
				valueStringBuilder.AppendSpanFormattable(_years, null, CultureInfo.InvariantCulture);
				valueStringBuilder.Append('Y');
			}
			if (_months != 0)
			{
				valueStringBuilder.AppendSpanFormattable(_months, null, CultureInfo.InvariantCulture);
				valueStringBuilder.Append('M');
			}
		}
		if (P_0 != DurationType.YearMonthDuration)
		{
			if (_days != 0)
			{
				valueStringBuilder.AppendSpanFormattable(_days, null, CultureInfo.InvariantCulture);
				valueStringBuilder.Append('D');
			}
			if (_hours != 0 || _minutes != 0 || _seconds != 0 || Nanoseconds != 0)
			{
				valueStringBuilder.Append('T');
				if (_hours != 0)
				{
					valueStringBuilder.AppendSpanFormattable(_hours, null, CultureInfo.InvariantCulture);
					valueStringBuilder.Append('H');
				}
				if (_minutes != 0)
				{
					valueStringBuilder.AppendSpanFormattable(_minutes, null, CultureInfo.InvariantCulture);
					valueStringBuilder.Append('M');
				}
				int num = Nanoseconds;
				if (_seconds != 0 || num != 0)
				{
					valueStringBuilder.AppendSpanFormattable(_seconds, null, CultureInfo.InvariantCulture);
					if (num != 0)
					{
						valueStringBuilder.Append('.');
						int length = valueStringBuilder.Length;
						Span<char> span2 = stackalloc char[9];
						int num2 = length + 8;
						for (int num3 = num2; num3 >= length; num3--)
						{
							int num4 = num % 10;
							span2[num3 - length] = (char)(num4 + 48);
							if (num2 == num3 && num4 == 0)
							{
								num2--;
							}
							num /= 10;
						}
						valueStringBuilder.EnsureCapacity(num2 + 1);
						valueStringBuilder.Append(span2.Slice(0, num2 - length + 1));
					}
					valueStringBuilder.Append('S');
				}
			}
			if (valueStringBuilder[valueStringBuilder.Length - 1] == 'P')
			{
				valueStringBuilder.Append("T0S");
			}
		}
		else if (valueStringBuilder[valueStringBuilder.Length - 1] == 'P')
		{
			valueStringBuilder.Append("0M");
		}
		return valueStringBuilder.ToString();
	}

	internal static Exception TryParse(string P_0, out XsdDuration P_1)
	{
		return TryParse(P_0, DurationType.Duration, out P_1);
	}

	internal static Exception TryParse(string P_0, DurationType P_1, out XsdDuration P_2)
	{
		Parts parts = Parts.HasNone;
		P_2 = default(XsdDuration);
		P_0 = P_0.Trim();
		int length = P_0.Length;
		int num = 0;
		int num2;
		int i;
		if (num < length)
		{
			if (P_0[num] == '-')
			{
				num++;
				P_2._nanoseconds = 2147483648u;
			}
			else
			{
				P_2._nanoseconds = 0u;
			}
			if (num < length && P_0[num++] == 'P')
			{
				string text = TryParseDigits(P_0, ref num, false, out num2, out i);
				if (text != null)
				{
					goto IL_02e9;
				}
				if (num < length)
				{
					if (P_0[num] != 'Y')
					{
						goto IL_00be;
					}
					if (i != 0)
					{
						parts |= Parts.HasYears;
						P_2._years = num2;
						if (++num == length)
						{
							goto IL_02b5;
						}
						text = TryParseDigits(P_0, ref num, false, out num2, out i);
						if (text != null)
						{
							goto IL_02e9;
						}
						if (num < length)
						{
							goto IL_00be;
						}
					}
				}
			}
		}
		goto IL_02d2;
		IL_02e9:
		return new OverflowException(System.SR.Format("XmlConvert_Overflow", P_0, P_1));
		IL_0148:
		if (P_0[num] != 'T')
		{
			goto IL_02ad;
		}
		if (i == 0)
		{
			num++;
			string text = TryParseDigits(P_0, ref num, false, out num2, out i);
			if (text != null)
			{
				goto IL_02e9;
			}
			if (num < length)
			{
				if (P_0[num] != 'H')
				{
					goto IL_01c1;
				}
				if (i != 0)
				{
					parts |= Parts.HasHours;
					P_2._hours = num2;
					if (++num == length)
					{
						goto IL_02b5;
					}
					text = TryParseDigits(P_0, ref num, false, out num2, out i);
					if (text != null)
					{
						goto IL_02e9;
					}
					if (num < length)
					{
						goto IL_01c1;
					}
				}
			}
		}
		goto IL_02d2;
		IL_00be:
		if (P_0[num] != 'M')
		{
			goto IL_0103;
		}
		if (i != 0)
		{
			parts |= Parts.HasMonths;
			P_2._months = num2;
			if (++num == length)
			{
				goto IL_02b5;
			}
			string text = TryParseDigits(P_0, ref num, false, out num2, out i);
			if (text != null)
			{
				goto IL_02e9;
			}
			if (num < length)
			{
				goto IL_0103;
			}
		}
		goto IL_02d2;
		IL_0207:
		if (P_0[num] == '.')
		{
			num++;
			parts |= Parts.HasSeconds;
			P_2._seconds = num2;
			string text = TryParseDigits(P_0, ref num, true, out num2, out i);
			if (text != null)
			{
				goto IL_02e9;
			}
			if (i == 0)
			{
				num2 = 0;
			}
			while (i > 9)
			{
				num2 /= 10;
				i--;
			}
			for (; i < 9; i++)
			{
				num2 *= 10;
			}
			P_2._nanoseconds |= (uint)num2;
			if (num >= length || P_0[num] != 'S')
			{
				goto IL_02d2;
			}
			if (++num == length)
			{
				goto IL_02b5;
			}
		}
		else if (P_0[num] == 'S')
		{
			if (i == 0)
			{
				goto IL_02d2;
			}
			parts |= Parts.HasSeconds;
			P_2._seconds = num2;
			if (++num == length)
			{
				goto IL_02b5;
			}
		}
		goto IL_02ad;
		IL_02d2:
		return new FormatException(System.SR.Format("XmlConvert_BadFormat", P_0, P_1));
		IL_01c1:
		if (P_0[num] != 'M')
		{
			goto IL_0207;
		}
		if (i != 0)
		{
			parts |= Parts.HasMinutes;
			P_2._minutes = num2;
			if (++num == length)
			{
				goto IL_02b5;
			}
			string text = TryParseDigits(P_0, ref num, false, out num2, out i);
			if (text != null)
			{
				goto IL_02e9;
			}
			if (num < length)
			{
				goto IL_0207;
			}
		}
		goto IL_02d2;
		IL_02ad:
		if (i == 0 && num == length)
		{
			goto IL_02b5;
		}
		goto IL_02d2;
		IL_0103:
		if (P_0[num] != 'D')
		{
			goto IL_0148;
		}
		if (i != 0)
		{
			parts |= Parts.HasDays;
			P_2._days = num2;
			if (++num == length)
			{
				goto IL_02b5;
			}
			int num3;
			string text = TryParseDigits(P_0, ref num, false, out num3, out i);
			if (text != null)
			{
				goto IL_02e9;
			}
			if (num < length)
			{
				goto IL_0148;
			}
		}
		goto IL_02d2;
		IL_02b5:
		if (parts != Parts.HasNone)
		{
			if (P_1 == DurationType.DayTimeDuration)
			{
				if ((parts & (Parts)3) == 0)
				{
					goto IL_02d0;
				}
			}
			else if (P_1 != DurationType.YearMonthDuration || (parts & (Parts)(-4)) == 0)
			{
				goto IL_02d0;
			}
		}
		goto IL_02d2;
		IL_02d0:
		return null;
	}

	private static string TryParseDigits(string P_0, ref int P_1, bool P_2, out int P_3, out int P_4)
	{
		int num = P_1;
		int length = P_0.Length;
		P_3 = 0;
		P_4 = 0;
		while (P_1 < length && char.IsAsciiDigit(P_0[P_1]))
		{
			int num2 = P_0[P_1] - 48;
			if (P_3 > (2147483647 - num2) / 10)
			{
				if (!P_2)
				{
					return "XmlConvert_Overflow";
				}
				P_4 = P_1 - num;
				while (P_1 < length && char.IsAsciiDigit(P_0[P_1]))
				{
					P_1++;
				}
				return null;
			}
			P_3 = P_3 * 10 + num2;
			P_1++;
		}
		P_4 = P_1 - num;
		return null;
	}
}
