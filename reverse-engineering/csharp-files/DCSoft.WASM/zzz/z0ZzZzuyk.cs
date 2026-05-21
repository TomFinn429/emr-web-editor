using System;

namespace zzz;

public static class z0ZzZzuyk
{
	private static char[] z0tek = "2020-05-04 15:28:11".ToCharArray();

	public static DateTime z0eek(DateTime p0)
	{
		return new DateTime(p0.Year, p0.Month, p0.Day, p0.Hour, p0.Minute, p0.Second);
	}

	public static DateTime z0eek()
	{
		return DateTime.Now;
	}

	public static string z0rek(DateTime p0)
	{
		if (z0tek == null)
		{
			z0tek = "2020-05-04 15:28:11".ToCharArray();
		}
		int num = 0;
		int year = p0.Year;
		num = year % 10;
		z0tek[3] = (char)(num + 48);
		int num2 = (year - num) / 10;
		num = num2 % 10;
		z0tek[2] = (char)(num + 48);
		int num3 = (num2 - num) / 10;
		num = num3 % 10;
		z0tek[1] = (char)(num + 48);
		num = (num3 - num) / 10 % 10;
		z0tek[0] = (char)(num + 48);
		int month = p0.Month;
		num = month % 10;
		z0tek[6] = (char)(num + 48);
		num = (month - num) / 10 % 10;
		z0tek[5] = (char)(num + 48);
		int day = p0.Day;
		num = day % 10;
		z0tek[9] = (char)(num + 48);
		num = (day - num) / 10 % 10;
		z0tek[8] = (char)(num + 48);
		int hour = p0.Hour;
		num = hour % 10;
		z0tek[12] = (char)(num + 48);
		num = (hour - num) / 10 % 10;
		z0tek[11] = (char)(num + 48);
		int minute = p0.Minute;
		num = minute % 10;
		z0tek[15] = (char)(num + 48);
		num = (minute - num) / 10 % 10;
		z0tek[14] = (char)(num + 48);
		int second = p0.Second;
		num = second % 10;
		z0tek[18] = (char)(num + 48);
		num = (second - num) / 10 % 10;
		z0tek[17] = (char)(num + 48);
		return new string(z0tek);
	}
}
