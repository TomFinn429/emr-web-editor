using System;
using System.Globalization;
using DCSystem_Drawing;

namespace zzz;

internal static class z0ZzZzufh
{
	private static int z0eek(string p0, NumberFormatInfo p1)
	{
		return int.Parse(p0, NumberStyles.Integer, p1);
	}

	public static Color z0eek(string p0, CultureInfo p1)
	{
		string text = p0.Trim();
		if (text.Length == 0)
		{
			return Color.Empty;
		}
		char c = p1.TextInfo.ListSeparator[0];
		if (!text.Contains(c))
		{
			if (text.Length >= 2 && (text[0] == '\'' || text[0] == '"') && text[0] == text[text.Length - 1])
			{
				text.Substring(1, text.Length - 2);
				return Color.Empty;
			}
			if ((text.Length == 7 && text[0] == '#') || (text.Length == 8 && (text.StartsWith("0x") || text.StartsWith("0X"))) || (text.Length == 8 && (text.StartsWith("&h") || text.StartsWith("&H"))))
			{
				return Color.FromArgb((int)(0xFF000000u | z0rek(text, p1)));
			}
		}
		string[] array = text.Split(c);
		int[] array2 = new int[array.Length];
		for (int i = 0; i < array2.Length; i++)
		{
			array2[i] = z0rek(array[i], p1);
		}
		return array2.Length switch
		{
			1 => Color.FromArgb(array2[0]), 
			3 => Color.FromArgb(array2[0], array2[1], array2[2]), 
			4 => Color.FromArgb(array2[0], array2[1], array2[2], array2[3]), 
			_ => throw new ArgumentException("InvalidColor:" + text), 
		};
	}

	private static int z0eek(string p0, int p1)
	{
		return Convert.ToInt32(p0, p1);
	}

	private static int z0rek(string p0, CultureInfo p1)
	{
		p0 = p0.Trim();
		try
		{
			if (p0[0] == '#')
			{
				return z0eek(p0.Substring(1), 16);
			}
			if (p0.StartsWith("0x", StringComparison.OrdinalIgnoreCase) || p0.StartsWith("&h", StringComparison.OrdinalIgnoreCase))
			{
				return z0eek(p0.Substring(2), 16);
			}
			NumberFormatInfo p2 = (NumberFormatInfo)p1.GetFormat(typeof(NumberFormatInfo));
			return z0eek(p0, p2);
		}
		catch (Exception ex)
		{
			throw new ArgumentException("ConvertInvalidPrimitive:" + p0, ex);
		}
	}
}
