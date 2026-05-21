using System.Text;

namespace System.Xml.Schema;

internal struct XsdDateTime
{
	private enum DateTimeTypeCode
	{
		DateTime,
		Time,
		Date,
		GYearMonth,
		GYear,
		GMonthDay,
		GDay,
		GMonth,
		XdrDateTime
	}

	private enum XsdDateTimeKind
	{
		Unspecified,
		Zulu,
		LocalWestOfZulu,
		LocalEastOfZulu
	}

	private struct Parser
	{
		public DateTimeTypeCode typeCode;

		public int year;

		public int month;

		public int day;

		public int hour;

		public int minute;

		public int second;

		public int fraction;

		public XsdDateTimeKind kind;

		public int zoneHour;

		public int zoneMinute;

		private string _text;

		private int _length;

		private static readonly int[] s_power10 = new int[7] { -1, 10, 100, 1000, 10000, 100000, 1000000 };

		public bool Parse(string P_0, XsdDateTimeFlags P_1)
		{
			_text = P_0;
			_length = P_0.Length;
			int i;
			for (i = 0; i < _length && char.IsWhiteSpace(P_0[i]); i++)
			{
			}
			if (Test(P_1, XsdDateTimeFlags.DateTime | XsdDateTimeFlags.Date | XsdDateTimeFlags.XdrDateTimeNoTz | XsdDateTimeFlags.XdrDateTime) && ParseDate(i))
			{
				if (Test(P_1, XsdDateTimeFlags.DateTime) && ParseChar(i + s_lzyyyy_MM_dd, 'T') && ParseTimeAndZoneAndWhitespace(i + s_lzyyyy_MM_ddT))
				{
					typeCode = DateTimeTypeCode.DateTime;
					return true;
				}
				if (Test(P_1, XsdDateTimeFlags.Date) && ParseZoneAndWhitespace(i + s_lzyyyy_MM_dd))
				{
					typeCode = DateTimeTypeCode.Date;
					return true;
				}
				if (Test(P_1, XsdDateTimeFlags.XdrDateTime) && (ParseZoneAndWhitespace(i + s_lzyyyy_MM_dd) || (ParseChar(i + s_lzyyyy_MM_dd, 'T') && ParseTimeAndZoneAndWhitespace(i + s_lzyyyy_MM_ddT))))
				{
					typeCode = DateTimeTypeCode.XdrDateTime;
					return true;
				}
				if (Test(P_1, XsdDateTimeFlags.XdrDateTimeNoTz))
				{
					if (!ParseChar(i + s_lzyyyy_MM_dd, 'T'))
					{
						typeCode = DateTimeTypeCode.XdrDateTime;
						return true;
					}
					if (ParseTimeAndWhitespace(i + s_lzyyyy_MM_ddT))
					{
						typeCode = DateTimeTypeCode.XdrDateTime;
						return true;
					}
				}
			}
			if (Test(P_1, XsdDateTimeFlags.Time) && ParseTimeAndZoneAndWhitespace(i))
			{
				year = 1904;
				month = 1;
				day = 1;
				typeCode = DateTimeTypeCode.Time;
				return true;
			}
			if (Test(P_1, XsdDateTimeFlags.XdrTimeNoTz) && ParseTimeAndWhitespace(i))
			{
				year = 1904;
				month = 1;
				day = 1;
				typeCode = DateTimeTypeCode.Time;
				return true;
			}
			if (Test(P_1, XsdDateTimeFlags.GYearMonth | XsdDateTimeFlags.GYear) && Parse4Dig(i, ref year) && 1 <= year)
			{
				if (Test(P_1, XsdDateTimeFlags.GYearMonth) && ParseChar(i + s_lzyyyy, '-') && Parse2Dig(i + s_lzyyyy_, ref month) && 1 <= month && month <= 12 && ParseZoneAndWhitespace(i + s_lzyyyy_MM))
				{
					day = 1;
					typeCode = DateTimeTypeCode.GYearMonth;
					return true;
				}
				if (Test(P_1, XsdDateTimeFlags.GYear) && ParseZoneAndWhitespace(i + s_lzyyyy))
				{
					month = 1;
					day = 1;
					typeCode = DateTimeTypeCode.GYear;
					return true;
				}
			}
			if (Test(P_1, XsdDateTimeFlags.GMonthDay | XsdDateTimeFlags.GMonth) && ParseChar(i, '-') && ParseChar(i + s_Lz_, '-') && Parse2Dig(i + s_Lz__, ref month) && 1 <= month && month <= 12)
			{
				if (Test(P_1, XsdDateTimeFlags.GMonthDay) && ParseChar(i + s_lz__mm, '-') && Parse2Dig(i + s_lz__mm_, ref day) && 1 <= day && day <= DateTime.DaysInMonth(1904, month) && ParseZoneAndWhitespace(i + s_lz__mm_dd))
				{
					year = 1904;
					typeCode = DateTimeTypeCode.GMonthDay;
					return true;
				}
				if (Test(P_1, XsdDateTimeFlags.GMonth) && (ParseZoneAndWhitespace(i + s_lz__mm) || (ParseChar(i + s_lz__mm, '-') && ParseChar(i + s_lz__mm_, '-') && ParseZoneAndWhitespace(i + s_lz__mm__))))
				{
					year = 1904;
					day = 1;
					typeCode = DateTimeTypeCode.GMonth;
					return true;
				}
			}
			if (Test(P_1, XsdDateTimeFlags.GDay) && ParseChar(i, '-') && ParseChar(i + s_Lz_, '-') && ParseChar(i + s_Lz__, '-') && Parse2Dig(i + s_Lz___, ref day) && 1 <= day && day <= DateTime.DaysInMonth(1904, 1) && ParseZoneAndWhitespace(i + s_lz___dd))
			{
				year = 1904;
				month = 1;
				typeCode = DateTimeTypeCode.GDay;
				return true;
			}
			return false;
		}

		private bool ParseDate(int P_0)
		{
			if (Parse4Dig(P_0, ref year) && 1 <= year && ParseChar(P_0 + s_lzyyyy, '-') && Parse2Dig(P_0 + s_lzyyyy_, ref month) && 1 <= month && month <= 12 && ParseChar(P_0 + s_lzyyyy_MM, '-') && Parse2Dig(P_0 + s_lzyyyy_MM_, ref day) && 1 <= day)
			{
				return day <= DateTime.DaysInMonth(year, month);
			}
			return false;
		}

		private bool ParseTimeAndZoneAndWhitespace(int P_0)
		{
			if (ParseTime(ref P_0) && ParseZoneAndWhitespace(P_0))
			{
				return true;
			}
			return false;
		}

		private bool ParseTimeAndWhitespace(int P_0)
		{
			if (ParseTime(ref P_0))
			{
				while (P_0 < _length)
				{
					P_0++;
				}
				return P_0 == _length;
			}
			return false;
		}

		private bool ParseTime(ref int P_0)
		{
			if (Parse2Dig(P_0, ref hour) && hour < 24 && ParseChar(P_0 + s_lzHH, ':') && Parse2Dig(P_0 + s_lzHH_, ref minute) && minute < 60 && ParseChar(P_0 + s_lzHH_mm, ':') && Parse2Dig(P_0 + s_lzHH_mm_, ref second) && second < 60)
			{
				P_0 += s_lzHH_mm_ss;
				if (ParseChar(P_0, '.'))
				{
					fraction = 0;
					int num = 0;
					int num2 = 0;
					while (++P_0 < _length)
					{
						int num3 = _text[P_0] - 48;
						if (9u < (uint)num3)
						{
							break;
						}
						if (num < 7)
						{
							fraction = fraction * 10 + num3;
						}
						else if (num == 7)
						{
							if (5 < num3)
							{
								num2 = 1;
							}
							else if (num3 == 5)
							{
								num2 = -1;
							}
						}
						else if (num2 < 0 && num3 != 0)
						{
							num2 = 1;
						}
						num++;
					}
					if (num < 7)
					{
						if (num == 0)
						{
							return false;
						}
						fraction *= s_power10[7 - num];
					}
					else
					{
						if (num2 < 0)
						{
							num2 = fraction & 1;
						}
						fraction += num2;
					}
				}
				return true;
			}
			hour = 0;
			return false;
		}

		private bool ParseZoneAndWhitespace(int P_0)
		{
			if (P_0 < _length)
			{
				char c = _text[P_0];
				if (c == 'Z' || c == 'z')
				{
					kind = XsdDateTimeKind.Zulu;
					P_0++;
				}
				else if (P_0 + 5 < _length && Parse2Dig(P_0 + s_Lz_, ref zoneHour) && zoneHour <= 99 && ParseChar(P_0 + s_lz_zz, ':') && Parse2Dig(P_0 + s_lz_zz_, ref zoneMinute) && zoneMinute <= 99)
				{
					switch (c)
					{
					case '-':
						kind = XsdDateTimeKind.LocalWestOfZulu;
						P_0 += s_lz_zz_zz;
						break;
					case '+':
						kind = XsdDateTimeKind.LocalEastOfZulu;
						P_0 += s_lz_zz_zz;
						break;
					}
				}
			}
			while (P_0 < _length && char.IsWhiteSpace(_text[P_0]))
			{
				P_0++;
			}
			return P_0 == _length;
		}

		private bool Parse4Dig(int P_0, ref int P_1)
		{
			if (P_0 + 3 < _length)
			{
				int num = _text[P_0] - 48;
				int num2 = _text[P_0 + 1] - 48;
				int num3 = _text[P_0 + 2] - 48;
				int num4 = _text[P_0 + 3] - 48;
				if (0 <= num && num < 10 && 0 <= num2 && num2 < 10 && 0 <= num3 && num3 < 10 && 0 <= num4 && num4 < 10)
				{
					P_1 = ((num * 10 + num2) * 10 + num3) * 10 + num4;
					return true;
				}
			}
			return false;
		}

		private bool Parse2Dig(int P_0, ref int P_1)
		{
			if (P_0 + 1 < _length)
			{
				int num = _text[P_0] - 48;
				int num2 = _text[P_0 + 1] - 48;
				if (0 <= num && num < 10 && 0 <= num2 && num2 < 10)
				{
					P_1 = num * 10 + num2;
					return true;
				}
			}
			return false;
		}

		private bool ParseChar(int P_0, char P_1)
		{
			if (P_0 < _length)
			{
				return _text[P_0] == P_1;
			}
			return false;
		}

		private static bool Test(XsdDateTimeFlags P_0, XsdDateTimeFlags P_1)
		{
			return (P_0 & P_1) != 0;
		}
	}

	private DateTime _dt;

	private uint _extra;

	private static readonly int s_lzyyyy = "yyyy".Length;

	private static readonly int s_lzyyyy_ = "yyyy-".Length;

	private static readonly int s_lzyyyy_MM = "yyyy-MM".Length;

	private static readonly int s_lzyyyy_MM_ = "yyyy-MM-".Length;

	private static readonly int s_lzyyyy_MM_dd = "yyyy-MM-dd".Length;

	private static readonly int s_lzyyyy_MM_ddT = "yyyy-MM-ddT".Length;

	private static readonly int s_lzHH = "HH".Length;

	private static readonly int s_lzHH_ = "HH:".Length;

	private static readonly int s_lzHH_mm = "HH:mm".Length;

	private static readonly int s_lzHH_mm_ = "HH:mm:".Length;

	private static readonly int s_lzHH_mm_ss = "HH:mm:ss".Length;

	private static readonly int s_Lz_ = "-".Length;

	private static readonly int s_lz_zz = "-zz".Length;

	private static readonly int s_lz_zz_ = "-zz:".Length;

	private static readonly int s_lz_zz_zz = "-zz:zz".Length;

	private static readonly int s_Lz__ = "--".Length;

	private static readonly int s_lz__mm = "--MM".Length;

	private static readonly int s_lz__mm_ = "--MM-".Length;

	private static readonly int s_lz__mm__ = "--MM--".Length;

	private static readonly int s_lz__mm_dd = "--MM-dd".Length;

	private static readonly int s_Lz___ = "---".Length;

	private static readonly int s_lz___dd = "---dd".Length;

	private static readonly int[] DaysToMonth365 = new int[13]
	{
		0, 31, 59, 90, 120, 151, 181, 212, 243, 273,
		304, 334, 365
	};

	private static readonly int[] DaysToMonth366 = new int[13]
	{
		0, 31, 60, 91, 121, 152, 182, 213, 244, 274,
		305, 335, 366
	};

	private static readonly XmlTypeCode[] s_typeCodes = new XmlTypeCode[8]
	{
		XmlTypeCode.DateTime,
		XmlTypeCode.Time,
		XmlTypeCode.Date,
		XmlTypeCode.GYearMonth,
		XmlTypeCode.GYear,
		XmlTypeCode.GMonthDay,
		XmlTypeCode.GDay,
		XmlTypeCode.GMonth
	};

	private DateTimeTypeCode InternalTypeCode => (DateTimeTypeCode)((_extra & 0xFF000000u) >> 24);

	private XsdDateTimeKind InternalKind => (XsdDateTimeKind)((_extra & 0xFF0000) >> 16);

	public int Year => _dt.Year;

	public int Month => _dt.Month;

	public int Day => _dt.Day;

	public int Hour => _dt.Hour;

	public int Minute => _dt.Minute;

	public int Second => _dt.Second;

	public int Fraction => (int)(_dt.Ticks % 10000000);

	public int ZoneHour => (int)((_extra & 0xFF00) >> 8);

	public int ZoneMinute => (int)(_extra & 0xFF);

	public XsdDateTime(string P_0, XsdDateTimeFlags P_1)
	{
		this = default(XsdDateTime);
		Parser parser = default(Parser);
		if (!parser.Parse(P_0, P_1))
		{
			throw new FormatException(System.SR.Format("XmlConvert_BadFormat", P_0, P_1));
		}
		InitiateXsdDateTime(parser);
	}

	private XsdDateTime(Parser P_0)
	{
		this = default(XsdDateTime);
		InitiateXsdDateTime(P_0);
	}

	private void InitiateXsdDateTime(Parser P_0)
	{
		_dt = new DateTime(P_0.year, P_0.month, P_0.day, P_0.hour, P_0.minute, P_0.second);
		if (P_0.fraction != 0)
		{
			_dt = _dt.AddTicks(P_0.fraction);
		}
		_extra = (uint)(((int)P_0.typeCode << 24) | ((int)P_0.kind << 16) | (P_0.zoneHour << 8) | P_0.zoneMinute);
	}

	internal static bool TryParse(string P_0, XsdDateTimeFlags P_1, out XsdDateTime P_2)
	{
		Parser parser = default(Parser);
		if (!parser.Parse(P_0, P_1))
		{
			P_2 = default(XsdDateTime);
			return false;
		}
		P_2 = new XsdDateTime(parser);
		return true;
	}

	public XsdDateTime(DateTime P_0, XsdDateTimeFlags P_1)
	{
		_dt = P_0;
		DateTimeTypeCode dateTimeTypeCode = (DateTimeTypeCode)(Bits.LeastPosition((uint)P_1) - 1);
		int num = 0;
		int num2 = 0;
		XsdDateTimeKind xsdDateTimeKind;
		switch (P_0.Kind)
		{
		case DateTimeKind.Unspecified:
			xsdDateTimeKind = XsdDateTimeKind.Unspecified;
			break;
		case DateTimeKind.Utc:
			xsdDateTimeKind = XsdDateTimeKind.Zulu;
			break;
		default:
		{
			TimeSpan utcOffset = TimeZoneInfo.Local.GetUtcOffset(P_0);
			if (utcOffset.Ticks < 0)
			{
				xsdDateTimeKind = XsdDateTimeKind.LocalWestOfZulu;
				num = -utcOffset.Hours;
				num2 = -utcOffset.Minutes;
			}
			else
			{
				xsdDateTimeKind = XsdDateTimeKind.LocalEastOfZulu;
				num = utcOffset.Hours;
				num2 = utcOffset.Minutes;
			}
			break;
		}
		}
		_extra = (uint)(((int)dateTimeTypeCode << 24) | ((int)xsdDateTimeKind << 16) | (num << 8) | num2);
	}

	public XsdDateTime(DateTimeOffset P_0, XsdDateTimeFlags P_1)
	{
		_dt = P_0.DateTime;
		TimeSpan timeSpan = P_0.Offset;
		DateTimeTypeCode dateTimeTypeCode = (DateTimeTypeCode)(Bits.LeastPosition((uint)P_1) - 1);
		XsdDateTimeKind xsdDateTimeKind;
		if (!(timeSpan.TotalMinutes < 0.0))
		{
			xsdDateTimeKind = ((!(timeSpan.TotalMinutes > 0.0)) ? XsdDateTimeKind.Zulu : XsdDateTimeKind.LocalEastOfZulu);
		}
		else
		{
			timeSpan = timeSpan.Negate();
			xsdDateTimeKind = XsdDateTimeKind.LocalWestOfZulu;
		}
		_extra = (uint)(((int)dateTimeTypeCode << 24) | ((int)xsdDateTimeKind << 16) | (timeSpan.Hours << 8) | timeSpan.Minutes);
	}

	public static implicit operator DateTime(XsdDateTime P_0)
	{
		DateTime dateTime;
		switch (P_0.InternalTypeCode)
		{
		case DateTimeTypeCode.GDay:
		case DateTimeTypeCode.GMonth:
			dateTime = new DateTime(DateTime.Now.Year, P_0.Month, P_0.Day);
			break;
		case DateTimeTypeCode.Time:
		{
			DateTime now = DateTime.Now;
			TimeSpan value = new DateTime(now.Year, now.Month, now.Day) - new DateTime(P_0.Year, P_0.Month, P_0.Day);
			dateTime = P_0._dt.Add(value);
			break;
		}
		default:
			dateTime = P_0._dt;
			break;
		}
		switch (P_0.InternalKind)
		{
		case XsdDateTimeKind.Zulu:
			dateTime = new DateTime(dateTime.Ticks, DateTimeKind.Utc);
			break;
		case XsdDateTimeKind.LocalEastOfZulu:
		{
			long num = dateTime.Ticks - new TimeSpan(P_0.ZoneHour, P_0.ZoneMinute, 0).Ticks;
			if (num < DateTime.MinValue.Ticks)
			{
				num += TimeZoneInfo.Local.GetUtcOffset(dateTime).Ticks;
				if (num < DateTime.MinValue.Ticks)
				{
					num = DateTime.MinValue.Ticks;
				}
				return new DateTime(num, DateTimeKind.Local);
			}
			dateTime = new DateTime(num, DateTimeKind.Utc).ToLocalTime();
			break;
		}
		case XsdDateTimeKind.LocalWestOfZulu:
		{
			long num = dateTime.Ticks + new TimeSpan(P_0.ZoneHour, P_0.ZoneMinute, 0).Ticks;
			if (num > DateTime.MaxValue.Ticks)
			{
				num += TimeZoneInfo.Local.GetUtcOffset(dateTime).Ticks;
				if (num > DateTime.MaxValue.Ticks)
				{
					num = DateTime.MaxValue.Ticks;
				}
				return new DateTime(num, DateTimeKind.Local);
			}
			dateTime = new DateTime(num, DateTimeKind.Utc).ToLocalTime();
			break;
		}
		}
		return dateTime;
	}

	public static implicit operator DateTimeOffset(XsdDateTime P_0)
	{
		DateTime dateTime;
		switch (P_0.InternalTypeCode)
		{
		case DateTimeTypeCode.GDay:
		case DateTimeTypeCode.GMonth:
			dateTime = new DateTime(DateTime.Now.Year, P_0.Month, P_0.Day);
			break;
		case DateTimeTypeCode.Time:
		{
			DateTime now = DateTime.Now;
			TimeSpan value = new DateTime(now.Year, now.Month, now.Day) - new DateTime(P_0.Year, P_0.Month, P_0.Day);
			dateTime = P_0._dt.Add(value);
			break;
		}
		default:
			dateTime = P_0._dt;
			break;
		}
		return P_0.InternalKind switch
		{
			XsdDateTimeKind.LocalEastOfZulu => new DateTimeOffset(dateTime, new TimeSpan(P_0.ZoneHour, P_0.ZoneMinute, 0)), 
			XsdDateTimeKind.LocalWestOfZulu => new DateTimeOffset(dateTime, new TimeSpan(-P_0.ZoneHour, -P_0.ZoneMinute, 0)), 
			XsdDateTimeKind.Zulu => new DateTimeOffset(dateTime, new TimeSpan(0L)), 
			_ => new DateTimeOffset(dateTime, TimeZoneInfo.Local.GetUtcOffset(dateTime)), 
		};
	}

	public override string ToString()
	{
		Span<char> span = stackalloc char[64];
		System.Text.ValueStringBuilder valueStringBuilder = new System.Text.ValueStringBuilder(span);
		switch (InternalTypeCode)
		{
		case DateTimeTypeCode.DateTime:
			PrintDate(ref valueStringBuilder);
			valueStringBuilder.Append('T');
			PrintTime(ref valueStringBuilder);
			break;
		case DateTimeTypeCode.Time:
			PrintTime(ref valueStringBuilder);
			break;
		case DateTimeTypeCode.Date:
			PrintDate(ref valueStringBuilder);
			break;
		case DateTimeTypeCode.GYearMonth:
			valueStringBuilder.AppendSpanFormattable(Year, "D4");
			valueStringBuilder.Append('-');
			valueStringBuilder.AppendSpanFormattable(Month, "D2");
			break;
		case DateTimeTypeCode.GYear:
			valueStringBuilder.AppendSpanFormattable(Year, "D4");
			break;
		case DateTimeTypeCode.GMonthDay:
			valueStringBuilder.Append("--");
			valueStringBuilder.AppendSpanFormattable(Month, "D2");
			valueStringBuilder.Append('-');
			valueStringBuilder.AppendSpanFormattable(Day, "D2");
			break;
		case DateTimeTypeCode.GDay:
			valueStringBuilder.Append("---");
			valueStringBuilder.AppendSpanFormattable(Day, "D2");
			break;
		case DateTimeTypeCode.GMonth:
			valueStringBuilder.Append("--");
			valueStringBuilder.AppendSpanFormattable(Month, "D2");
			valueStringBuilder.Append("--");
			break;
		}
		PrintZone(ref valueStringBuilder);
		return valueStringBuilder.ToString();
	}

	private void PrintDate(ref System.Text.ValueStringBuilder P_0)
	{
		Span<char> span = P_0.AppendSpan(s_lzyyyy_MM_dd);
		GetYearMonthDay(out var num, out var num2, out var num3);
		WriteXDigits(span, 0, num, 4);
		span[s_lzyyyy] = '-';
		Write2Digits(span, s_lzyyyy_, num2);
		span[s_lzyyyy_MM] = '-';
		Write2Digits(span, s_lzyyyy_MM_, num3);
	}

	private void GetYearMonthDay(out int P_0, out int P_1, out int P_2)
	{
		long ticks = _dt.Ticks;
		int num = (int)(ticks / 864000000000L);
		int num2 = num / 146097;
		num -= num2 * 146097;
		int num3 = num / 36524;
		if (num3 == 4)
		{
			num3 = 3;
		}
		num -= num3 * 36524;
		int num4 = num / 1461;
		num -= num4 * 1461;
		int num5 = num / 365;
		if (num5 == 4)
		{
			num5 = 3;
		}
		P_0 = num2 * 400 + num3 * 100 + num4 * 4 + num5 + 1;
		num -= num5 * 365;
		int[] array = ((num5 == 3 && (num4 != 24 || num3 == 3)) ? DaysToMonth366 : DaysToMonth365);
		P_1 = (num >> 5) + 1;
		while (num >= array[P_1])
		{
			P_1++;
		}
		P_2 = num - array[P_1 - 1] + 1;
	}

	private void PrintTime(ref System.Text.ValueStringBuilder P_0)
	{
		Span<char> span = P_0.AppendSpan(s_lzHH_mm_ss);
		Write2Digits(span, 0, Hour);
		span[s_lzHH] = ':';
		Write2Digits(span, s_lzHH_, Minute);
		span[s_lzHH_mm] = ':';
		Write2Digits(span, s_lzHH_mm_, Second);
		int num = Fraction;
		if (num != 0)
		{
			int num2 = 7;
			while (num % 10 == 0)
			{
				num2--;
				num /= 10;
			}
			span = P_0.AppendSpan(num2 + 1);
			span[0] = '.';
			WriteXDigits(span, 1, num, num2);
		}
	}

	private void PrintZone(ref System.Text.ValueStringBuilder P_0)
	{
		switch (InternalKind)
		{
		case XsdDateTimeKind.Zulu:
			P_0.Append('Z');
			break;
		case XsdDateTimeKind.LocalWestOfZulu:
		{
			Span<char> span = P_0.AppendSpan(s_lz_zz_zz);
			span[0] = '-';
			Write2Digits(span, s_Lz_, ZoneHour);
			span[s_lz_zz] = ':';
			Write2Digits(span, s_lz_zz_, ZoneMinute);
			break;
		}
		case XsdDateTimeKind.LocalEastOfZulu:
		{
			Span<char> span = P_0.AppendSpan(s_lz_zz_zz);
			span[0] = '+';
			Write2Digits(span, s_Lz_, ZoneHour);
			span[s_lz_zz] = ':';
			Write2Digits(span, s_lz_zz_, ZoneMinute);
			break;
		}
		}
	}

	private static void WriteXDigits(Span<char> P_0, int P_1, int P_2, int P_3)
	{
		while (P_3-- != 0)
		{
			P_0[P_1 + P_3] = (char)(P_2 % 10 + 48);
			P_2 /= 10;
		}
	}

	private static void Write2Digits(Span<char> P_0, int P_1, int P_2)
	{
		P_0[P_1] = (char)(P_2 / 10 + 48);
		P_0[P_1 + 1] = (char)(P_2 % 10 + 48);
	}
}
