using System;
using System.Globalization;
using DCSystem_Drawing;

namespace zzz;

public static class z0ZzZzrpk
{
	private static readonly string z0uek;

	private static readonly string z0iek;

	private static readonly string z0oek;

	private static readonly string z0pek;

	private static readonly string z0mek;

	private static readonly string z0nek;

	private static readonly string z0bek;

	public static void z0eek()
	{
	}

	public static int z0eek(float p0, GraphicsUnit p1)
	{
		double num = z0eek(p1);
		return (int)((double)p0 * num * 1440.0);
	}

	public static double z0eek(double p0, GraphicsUnit p1)
	{
		double num = z0eek(p1);
		return p0 / (96.0 * num);
	}

	public static float z0rek(float p0, GraphicsUnit p1)
	{
		return (float)((double)z0eek(p0, p1, GraphicsUnit.Millimeter) / 10.0);
	}

	public static double z0eek(double p0, GraphicsUnit p1, GraphicsUnit p2)
	{
		if (p1 == p2)
		{
			return p0;
		}
		return p0 * z0eek(p2, p1);
	}

	public static int z0eek(int p0, GraphicsUnit p1, GraphicsUnit p2)
	{
		if (p1 == p2)
		{
			return p0;
		}
		return (int)((double)p0 * z0eek(p2, p1));
	}

	public static double z0rek(double p0, GraphicsUnit p1)
	{
		double num = z0eek(p1);
		return p0 * num * 96.0;
	}

	public static double z0eek(string p0, GraphicsUnit p1, double p2)
	{
		if (p0[0] == ' ' || p0[0] == '\t')
		{
			p0 = p0.Trim();
		}
		int length = p0.Length;
		double num = 0.0;
		bool flag = false;
		long num2 = 0L;
		int num3 = length - 1;
		for (int i = 0; i < length; i++)
		{
			char c = p0[i];
			if (c >= '0' && c <= '9')
			{
				num = num * 10.0 + (double)(int)c - 48.0;
				if (num2 > 0)
				{
					num2 *= 10;
				}
				if (i == num3)
				{
					if (num2 > 0)
					{
						num /= (double)num2;
					}
					if (flag)
					{
						num = 0.0 - num;
					}
					return z0eek(num, GraphicsUnit.Pixel, p1);
				}
				continue;
			}
			switch (c)
			{
			case '-':
				flag = true;
				continue;
			case '.':
				num2 = 1L;
				continue;
			default:
				if (c < 'A' || c > 'Z')
				{
					continue;
				}
				break;
			case 'a':
			case 'b':
			case 'c':
			case 'd':
			case 'e':
			case 'f':
			case 'g':
			case 'h':
			case 'i':
			case 'j':
			case 'k':
			case 'l':
			case 'm':
			case 'n':
			case 'o':
			case 'p':
			case 'q':
			case 'r':
			case 's':
			case 't':
			case 'u':
			case 'v':
			case 'w':
			case 'x':
			case 'y':
			case 'z':
				break;
			}
			if (i < length - 1)
			{
				if (c <= 'Z')
				{
					c = (char)(c - 65 + 97);
				}
				char c2 = p0[i + 1];
				if (c2 <= 'Z')
				{
					c2 = (char)(c2 - 65 + 97);
				}
				if (num2 > 0)
				{
					num /= (double)num2;
				}
				if (flag)
				{
					num = 0.0 - num;
				}
				if (c == 'p' && c2 == 'x')
				{
					return z0eek(num, GraphicsUnit.Pixel, p1);
				}
				if (c == 'p' && c2 == 't')
				{
					return z0eek(num, GraphicsUnit.Point, p1);
				}
				if (c == 'e' && c2 == 'm')
				{
					return z0eek(num, GraphicsUnit.Pixel, p1) * 16.0;
				}
				if (c == 'c' && c2 == 'm')
				{
					return z0eek(num, GraphicsUnit.Millimeter, p1) * 10.0;
				}
				if (c == 'm' && c2 == 'm')
				{
					return z0eek(num, GraphicsUnit.Millimeter, p1);
				}
				if (c == 'i' && c2 == 'n')
				{
					return z0eek(num, GraphicsUnit.Inch, p1);
				}
				if (c == 'p' && c2 == 'c')
				{
					return z0eek(num, GraphicsUnit.Point, p1) * 12.0;
				}
				return z0eek(num, GraphicsUnit.Pixel, p1);
			}
		}
		if (double.TryParse(p0, NumberStyles.Any, null, out num))
		{
			return z0eek(num, GraphicsUnit.Pixel, p1);
		}
		return p2;
	}

	public static double z0tek(double p0, GraphicsUnit p1)
	{
		return z0eek(p0, GraphicsUnit.Pixel, p1);
	}

	static z0ZzZzrpk()
	{
		z0pek = "cm";
		z0mek = "mm";
		z0oek = "in";
		z0uek = "pt";
		z0bek = "pc";
		z0nek = "px";
		z0iek = "0.0000";
	}

	public static z0ZzZzodh z0eek(z0ZzZzodh p0, GraphicsUnit p1, GraphicsUnit p2)
	{
		if (p1 == p2)
		{
			return p0;
		}
		double num = z0eek(p2, p1);
		return new z0ZzZzodh((int)((double)p0.z0rek() * num), (int)((double)p0.z0tek() * num));
	}

	public static z0ZzZzcdh z0eek(z0ZzZzcdh p0, GraphicsUnit p1, GraphicsUnit p2)
	{
		if (p1 == p2)
		{
			return p0;
		}
		double num = z0eek(p2, p1);
		return new z0ZzZzcdh((int)((double)p0.z0rek() * num), (int)((double)p0.z0tek() * num));
	}

	public static float z0tek(float p0, GraphicsUnit p1)
	{
		return z0eek(p0 * 10f, GraphicsUnit.Millimeter, p1);
	}

	public static double z0eek(double p0)
	{
		return z0eek(p0, GraphicsUnit.Pixel, GraphicsUnit.Inch) * 100.0;
	}

	public static string z0eek(double p0, GraphicsUnit p1, z0ZzZzkpk p2)
	{
		double num = 0.0;
		string empty = string.Empty;
		switch (p2)
		{
		case (z0ZzZzkpk)0:
			num = z0eek(p0, p1, GraphicsUnit.Millimeter) / 10.0;
			empty = z0pek;
			break;
		case (z0ZzZzkpk)1:
			num = z0eek(p0, p1, GraphicsUnit.Millimeter);
			empty = z0mek;
			break;
		case (z0ZzZzkpk)2:
			num = z0eek(p0, p1, GraphicsUnit.Inch);
			empty = z0oek;
			break;
		case (z0ZzZzkpk)4:
			num = z0eek(p0, p1, GraphicsUnit.Point) / 12.0;
			empty = z0bek;
			break;
		case (z0ZzZzkpk)5:
			num = z0eek(p0, p1, GraphicsUnit.Pixel);
			empty = z0nek;
			break;
		case (z0ZzZzkpk)3:
			num = z0eek(p0, p1, GraphicsUnit.Point);
			empty = z0uek;
			break;
		}
		return num.ToString(z0iek) + empty;
	}

	public static z0ZzZzxdh z0eek(z0ZzZzxdh p0, GraphicsUnit p1, GraphicsUnit p2)
	{
		if (p1 == p2)
		{
			return p0;
		}
		double num = z0eek(p2, p1);
		return new z0ZzZzxdh((float)((double)p0.z0rek() * num), (float)((double)p0.z0tek() * num));
	}

	public static double z0eek(GraphicsUnit p0)
	{
		return p0 switch
		{
			GraphicsUnit.Display => 0.010416666977107525, 
			GraphicsUnit.Document => 1.0 / 300.0, 
			GraphicsUnit.Inch => 1.0, 
			GraphicsUnit.Millimeter => 0.03937007874015748, 
			GraphicsUnit.Pixel => 0.010416666977107525, 
			GraphicsUnit.Point => 1.0 / 72.0, 
			_ => throw new NotSupportedException("Not support " + p0), 
		};
	}

	public static double z0yek(double p0, GraphicsUnit p1)
	{
		double num = z0eek(p1);
		return p0 / (num * 1440.0);
	}

	public static double z0eek(GraphicsUnit p0, GraphicsUnit p1)
	{
		if (p0 == p1)
		{
			return 1.0;
		}
		return z0eek(p1) / z0eek(p0);
	}

	public static int z0eek(int p0, GraphicsUnit p1)
	{
		double num = z0eek(p1);
		return (int)((double)p0 / (num * 1440.0));
	}

	public static float z0eek(float p0, GraphicsUnit p1, GraphicsUnit p2)
	{
		if (p1 == p2)
		{
			return p0;
		}
		return (float)((double)p0 * z0eek(p2, p1));
	}
}
