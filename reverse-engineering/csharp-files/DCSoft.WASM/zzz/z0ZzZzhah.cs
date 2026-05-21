using System;
using System.Globalization;

namespace zzz;

public class z0ZzZzhah
{
	public delegate DateTime z0ixk(string strValue);

	private static volatile string[] z0iek;

	internal static readonly char[] z0oek = new char[4] { ' ', '\t', '\n', '\r' };

	public static z0ixk z0pek = null;

	private static string[] z0eek()
	{
		if (z0iek == null)
		{
			z0rek();
		}
		return z0iek;
	}

	internal static bool z0eek(double p0)
	{
		if (p0 == 0.0 && BitConverter.DoubleToInt64Bits(p0) == BitConverter.DoubleToInt64Bits(-0.0))
		{
			return true;
		}
		return false;
	}

	public static string z0rek(double p0)
	{
		if (double.IsNegativeInfinity(p0))
		{
			return "-INF";
		}
		if (double.IsPositiveInfinity(p0))
		{
			return "INF";
		}
		if (z0eek(p0))
		{
			return "-0";
		}
		return p0.ToString("R", NumberFormatInfo.InvariantInfo);
	}

	internal static string z0eek(string p0)
	{
		return p0.Trim(z0oek);
	}

	internal static Exception z0eek(string p0, string p1, z0ZzZzwsh p2, int p3, int p4)
	{
		return p2 switch
		{
			(z0ZzZzwsh)0 => new ArgumentException(string.Format(p0, p1)), 
			_ => new z0ZzZzeah(p0, p1, p3, p4), 
		};
	}

	private static void z0rek()
	{
		if (z0iek == null)
		{
			z0iek = new string[24]
			{
				"yyyy-MM-ddTHH:mm:ss.FFFFFFFzzzzzz", "yyyy-MM-ddTHH:mm:ss.FFFFFFF", "yyyy-MM-ddTHH:mm:ss.FFFFFFFZ", "HH:mm:ss.FFFFFFF", "HH:mm:ss.FFFFFFFZ", "HH:mm:ss.FFFFFFFzzzzzz", "yyyy-MM-dd", "yyyy-MM-ddZ", "yyyy-MM-ddzzzzzz", "yyyy-MM",
				"yyyy-MMZ", "yyyy-MMzzzzzz", "yyyy", "yyyyZ", "yyyyzzzzzz", "--MM-dd", "--MM-ddZ", "--MM-ddzzzzzz", "---dd", "---ddZ",
				"---ddzzzzzz", "--MM--", "--MM--Z", "--MM--zzzzzz"
			};
		}
	}

	public static bool z0rek(string p0)
	{
		if (p0 == "true")
		{
			return true;
		}
		if (p0 == "false")
		{
			return false;
		}
		p0 = z0eek(p0);
		switch (p0)
		{
		case "1":
		case "true":
			return true;
		case "0":
		case "false":
			return false;
		default:
			throw new FormatException("BadFormat:" + p0 + " Boolean");
		}
	}

	internal static Exception z0eek(char p0, char p1)
	{
		return z0eek(p0, p1, (z0ZzZzwsh)0);
	}

	public static char z0tek(string p0)
	{
		ArgumentNullException.ThrowIfNull(p0, "s");
		if (p0.Length != 1)
		{
			throw new FormatException();
		}
		return p0[0];
	}

	public static string z0eek(float p0)
	{
		if (float.IsNegativeInfinity(p0))
		{
			return "-INF";
		}
		if (float.IsPositiveInfinity(p0))
		{
			return "INF";
		}
		if (z0eek((double)p0))
		{
			return "-0";
		}
		return p0.ToString("R", NumberFormatInfo.InvariantInfo);
	}

	public static DateTime z0yek(string p0)
	{
		if (z0pek != null)
		{
			return z0pek(p0);
		}
		return z0eek(p0, z0eek());
	}

	internal static Exception z0eek(char p0, z0ZzZzwsh p1, int p2, int p3)
	{
		uint num = p0;
		return z0eek("", num.ToString("X", CultureInfo.InvariantCulture), p1, p2, p3);
	}

	internal static Exception z0eek(string p0, string[] p1, z0ZzZzwsh p2, int p3, int p4)
	{
		switch (p2)
		{
		case (z0ZzZzwsh)0:
			return new ArgumentException(string.Format(p0, p1));
		default:
			return new z0ZzZzeah(p0, p1, p3, p4);
		}
	}

	public static DateTime z0eek(string p0, string[] p1)
	{
		return DateTime.ParseExact(p0, p1, DateTimeFormatInfo.InvariantInfo, DateTimeStyles.AllowLeadingWhite | DateTimeStyles.AllowTrailingWhite);
	}

	internal static Exception z0eek(char p0, char p1, z0ZzZzwsh p2)
	{
		return z0eek(p0, p1, p2, 0, 0);
	}

	internal static Exception z0eek(char p0, char p1, z0ZzZzwsh p2, int p3, int p4)
	{
		string[] array = new string[2];
		uint num = p1;
		array[0] = num.ToString("X", CultureInfo.InvariantCulture);
		num = p0;
		array[1] = num.ToString("X", CultureInfo.InvariantCulture);
		string[] p5 = array;
		return z0eek("", p5, p2, p3, p4);
	}

	internal static Exception z0eek(char p0, z0ZzZzwsh p1)
	{
		return z0eek(p0, p1, 0, 0);
	}

	public static string z0eek(bool p0)
	{
		if (!p0)
		{
			return "false";
		}
		return "true";
	}

	internal static Exception z0eek(char p0)
	{
		return z0eek(p0, (z0ZzZzwsh)0);
	}

	public static string z0eek(int p0)
	{
		return p0.ToString(null, CultureInfo.InvariantCulture);
	}

	public static int z0uek(string p0)
	{
		return int.Parse(p0, NumberStyles.Integer, NumberFormatInfo.InvariantInfo);
	}
}
