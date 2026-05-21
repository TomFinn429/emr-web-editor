using System;
using System.Collections.Generic;
using System.Reflection;
using DCSystem_Drawing;

namespace zzz;

public static class z0ZzZzlok
{
	private static readonly int z0rek = Color.Gray.ToArgb();

	private static readonly Dictionary<PropertyInfo, bool> z0tek = new Dictionary<PropertyInfo, bool>();

	private static readonly int z0yek = Color.Black.ToArgb();

	private static readonly string z0uek = "#000000";

	private static readonly string z0iek = "#000000";

	private static readonly string z0oek = "#" + Color.Gray.R.ToString(z0xek) + Color.Gray.G.ToString(z0xek) + Color.Gray.B.ToString(z0xek);

	private static readonly string z0pek = "#FFFFFF";

	private static readonly int z0mek = Color.White.ToArgb();

	private static readonly string z0nek = "#00ffffff";

	private static readonly string z0bek = "#ffffff";

	private static readonly string z0vek_jiejie20260327142557 = "#00000000";

	private static readonly string z0cek = "Empty";

	private static readonly string z0xek = "X2";

	public static bool z0eek(PropertyInfo p0)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("p");
		}
		if (z0tek.TryGetValue(p0, out var result))
		{
			return result;
		}
		if (Attribute.GetCustomAttribute(p0, typeof(z0ZzZzuqh), true) == null)
		{
			z0tek[p0] = false;
			return false;
		}
		z0tek[p0] = true;
		return true;
	}

	public static string z0eek(Color p0, Color p1)
	{
		if (p0.ToArgb() == p1.ToArgb())
		{
			return null;
		}
		if (p0.A == 255)
		{
			int num = p0.ToArgb();
			if (num == z0yek)
			{
				return z0iek;
			}
			if (num == z0mek)
			{
				return z0pek;
			}
			if (num == z0rek)
			{
				return z0oek;
			}
			return "#" + p0.R.ToString(z0xek) + p0.G.ToString(z0xek) + p0.B.ToString(z0xek);
		}
		return "#" + p0.A.ToString(z0xek) + p0.R.ToString(z0xek) + p0.G.ToString(z0xek) + p0.B.ToString(z0xek);
	}

	public static Color z0eek(string p0, Color p1)
	{
		if (string.IsNullOrEmpty(p0))
		{
			return p1;
		}
		p0 = p0.Trim();
		try
		{
			if (p0[0] == '#')
			{
				if (p0.Length == 9)
				{
					if (p0 == z0vek_jiejie20260327142557)
					{
						return Color.Empty;
					}
					if (string.Equals(p0, z0nek, StringComparison.OrdinalIgnoreCase))
					{
						return Color.Transparent;
					}
					int alpha = z0eek(p0, 1);
					int red = z0eek(p0, 3);
					int green = z0eek(p0, 5);
					int blue = z0eek(p0, 7);
					return Color.FromArgb(alpha, red, green, blue);
				}
				if (p0.Length == 7)
				{
					if (p0 == z0uek)
					{
						return Color.Black;
					}
					if (string.Equals(p0, z0bek, StringComparison.OrdinalIgnoreCase))
					{
						return Color.White;
					}
					int red2 = z0eek(p0, 1);
					int green2 = z0eek(p0, 3);
					int blue2 = z0eek(p0, 5);
					return Color.FromArgb(red2, green2, blue2);
				}
			}
			p0 = p0.Trim();
			if (p0.Length > 10 && p0.StartsWith("rgb(", StringComparison.OrdinalIgnoreCase))
			{
				p0 = p0.Substring(4, p0.Length - 5);
			}
			if (p0.IndexOf(',') > 0)
			{
				string[] array = p0.Split(',');
				int[] array2 = new int[4];
				int num = 0;
				string[] array3 = array;
				foreach (string obj in array3)
				{
					int num2 = 0;
					if (int.TryParse(obj.Trim(), out num2))
					{
						array2[num++] = num2;
						if (num == 4)
						{
							break;
						}
					}
				}
				switch (num)
				{
				case 1:
					return Color.FromArgb(array2[0], 255, 255);
				case 2:
					return Color.FromArgb(array2[0], array2[1], 255);
				case 3:
					return Color.FromArgb(array2[0], array2[1], array2[2]);
				case 4:
					return Color.FromArgb(array2[0], array2[1], array2[2], array2[3]);
				}
			}
			if (p0 == z0cek || string.Equals(p0, z0cek, StringComparison.OrdinalIgnoreCase))
			{
				return Color.Empty;
			}
			return z0ZzZzifh.z0eek(p0);
		}
		catch
		{
			return p1;
		}
	}

	private static int z0eek(string p0, int p1)
	{
		int num = 0;
		int num2 = z0ZzZzqik.z0rek(p0[p1]);
		if (num2 > 0)
		{
			num = num2 << 4;
		}
		num2 = z0ZzZzqik.z0rek(p0[p1 + 1]);
		if (num2 > 0)
		{
			num += num2;
		}
		return num;
	}

	public static string z0eek(Color p0)
	{
		if (p0.A == 255)
		{
			int num = p0.ToArgb();
			if (num == z0yek)
			{
				return z0iek;
			}
			if (num == z0mek)
			{
				return z0pek;
			}
			if (num == z0rek)
			{
				return z0oek;
			}
			return "#" + p0.R.ToString(z0xek) + p0.G.ToString(z0xek) + p0.B.ToString(z0xek);
		}
		return "#" + p0.A.ToString(z0xek) + p0.R.ToString(z0xek) + p0.G.ToString(z0xek) + p0.B.ToString(z0xek);
	}
}
