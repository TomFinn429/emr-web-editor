using System;
using System.Globalization;

namespace zzz;

internal static class z0ZzZzfwh
{
	internal static bool z0eek(string p0, out object p1)
	{
		z0ZzZzgwh z0ZzZzgwh2 = default(z0ZzZzgwh);
		if (!z0ZzZzgwh2.z0eek(p0))
		{
			p1 = null;
			return false;
		}
		DateTime p2 = new DateTime(z0ZzZzgwh2.z0yek, z0ZzZzgwh2.z0uek, z0ZzZzgwh2.z0iek, z0ZzZzgwh2.z0oek, z0ZzZzgwh2.z0pek, z0ZzZzgwh2.z0mek).AddTicks(z0ZzZzgwh2.z0nek);
		switch (z0ZzZzgwh2.z0cek)
		{
		case (z0ZzZzawh)1:
			p2 = new DateTime(p2.Ticks, DateTimeKind.Utc);
			break;
		case (z0ZzZzawh)2:
		{
			TimeSpan timeSpan2 = new TimeSpan(z0ZzZzgwh2.z0bek, z0ZzZzgwh2.z0vek, 0);
			long num = p2.Ticks + timeSpan2.Ticks;
			if (num <= DateTime.MaxValue.Ticks)
			{
				p2 = new DateTime(num, DateTimeKind.Utc).ToLocalTime();
				break;
			}
			num += z0rek(p2).Ticks;
			if (num > DateTime.MaxValue.Ticks)
			{
				num = DateTime.MaxValue.Ticks;
			}
			p2 = new DateTime(num, DateTimeKind.Local);
			break;
		}
		case (z0ZzZzawh)3:
		{
			TimeSpan timeSpan = new TimeSpan(z0ZzZzgwh2.z0bek, z0ZzZzgwh2.z0vek, 0);
			long num = p2.Ticks - timeSpan.Ticks;
			if (num >= DateTime.MinValue.Ticks)
			{
				p2 = new DateTime(num, DateTimeKind.Utc).ToLocalTime();
				break;
			}
			num += z0rek(p2).Ticks;
			if (num < DateTime.MinValue.Ticks)
			{
				num = DateTime.MinValue.Ticks;
			}
			p2 = new DateTime(num, DateTimeKind.Local);
			break;
		}
		}
		p1 = z0eek(p2);
		return true;
	}

	internal static DateTime z0eek(DateTime p0)
	{
		return p0;
	}

	internal static DateTime z0eek(long p0)
	{
		return new DateTime(p0 * 10000 + 621355968000000000L, DateTimeKind.Utc);
	}

	public static TimeSpan z0rek(DateTime p0)
	{
		return TimeZone.CurrentTimeZone.GetUtcOffset(p0);
	}

	private static bool z0eek(string p0, string p1, CultureInfo p2, out object p3)
	{
		if (DateTime.TryParseExact(p0, p1, p2, DateTimeStyles.RoundtripKind, out var result))
		{
			result = z0eek(result);
			p3 = result;
			return true;
		}
		p3 = null;
		return false;
	}

	internal static bool z0rek(string p0, string p1, CultureInfo p2, out object p3)
	{
		if (p0.Length > 0)
		{
			if (p0[0] == '/')
			{
				if (p0.StartsWith("/Date(", StringComparison.Ordinal) && p0.EndsWith(")/", StringComparison.Ordinal) && z0rek(p0, out p3))
				{
					return true;
				}
			}
			else if (p0.Length >= 19 && p0.Length <= 40 && char.IsDigit(p0[0]) && p0[10] == 'T' && z0eek(p0, out p3))
			{
				return true;
			}
			if (!string.IsNullOrEmpty(p1) && z0eek(p0, p1, p2, out p3))
			{
				return true;
			}
		}
		p3 = null;
		return false;
	}

	private static bool z0rek(string p0, out object p1)
	{
		string text = p0.Substring(6, p0.Length - 8);
		DateTimeKind dateTimeKind = DateTimeKind.Utc;
		int num = text.IndexOf('+', 1);
		if (num == -1)
		{
			num = text.IndexOf('-', 1);
		}
		if (num != -1)
		{
			dateTimeKind = DateTimeKind.Local;
			text = text.Substring(0, num);
		}
		if (!long.TryParse(text, NumberStyles.Integer, CultureInfo.InvariantCulture, out var p2))
		{
			p1 = null;
			return false;
		}
		DateTime dateTime = z0eek(p2);
		p1 = z0eek(dateTimeKind switch
		{
			DateTimeKind.Unspecified => DateTime.SpecifyKind(dateTime.ToLocalTime(), DateTimeKind.Unspecified), 
			DateTimeKind.Local => dateTime.ToLocalTime(), 
			_ => dateTime, 
		});
		return true;
	}
}
