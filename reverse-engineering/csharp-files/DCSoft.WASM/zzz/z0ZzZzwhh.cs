using System;
using System.Collections.Generic;

namespace zzz;

internal static class z0ZzZzwhh
{
	public static readonly long[] z0yek = new long[4] { 0L, 1L, 2L, 4L };

	public static readonly string[] z0uek = new string[4] { "None", "Default", "Tab", "Enter" };

	public static readonly string[] z0iek = new string[7] { "TopLeft", "TopCenter", "TopRight", "BottomLeft", "BottomCenter", "BottomRight", "PageSpacing" };

	public static readonly string[] z0oek = new string[19]
	{
		"None", "Text", "Field", "InputField", "Table", "TableRow", "TableColumn", "TableCell", "Object", "LineBreak",
		"PageBreak", "ParagraphFlag", "CheckRadioBox", "CheckBox", "Image", "Document", "Button", "Container", "All"
	};

	public static readonly long[] z0pek = new long[19]
	{
		0L, 1L, 2L, 4L, 8L, 16L, 32L, 64L, 128L, 256L,
		512L, 1024L, 2048L, 4096L, 8192L, 16384L, 32768L, 65536L, 16777215L
	};

	public static readonly string[] z0mek = new string[9] { "None", "Default", "Program", "F2", "GotFocus", "MouseDblClick", "MouseClick", "MouseRightClick", "Enter" };

	public static readonly long[] z0nek = new long[5] { 0L, 1L, 2L, 4L, 7L };

	public static readonly long[] z0bek = new long[9] { 0L, 1L, 2L, 4L, 8L, 16L, 32L, 64L, 128L };

	public static readonly string[] z0vek = new string[5] { "Hidden", "Paint", "Print", "PDF", "All" };

	internal static long z0eek(string p0, Dictionary<string, long> p1, string p2, bool p3 = true)
	{
		long num = 0L;
		if (p1.TryGetValue(p0, out num))
		{
			return num;
		}
		string[] array = p0.Split((char[]?)null);
		for (int i = 0; i < array.Length; i++)
		{
			long num2 = 0L;
			if (p1.TryGetValue(array[i], out num2))
			{
				num |= num2;
			}
			else if (p3 && array[i].Length > 0)
			{
				throw new InvalidOperationException(p2 + "没有成员" + array[i]);
			}
		}
		p1[p0] = num;
		return num;
	}

	public static float z0rek(string p0)
	{
		if (p0 == null || p0.Length == 0)
		{
			return 0f;
		}
		if (p0 == "NaN")
		{
			return 0f / 0f;
		}
		float result = 0f;
		if (float.TryParse(p0, out result))
		{
			return result;
		}
		return 0f;
	}

	public static double z0tek(string p0)
	{
		if (p0 == null || p0.Length == 0)
		{
			return 0.0;
		}
		if (p0 == "NaN")
		{
			return 0.0 / 0.0;
		}
		double result = 0.0;
		if (double.TryParse(p0, out result))
		{
			return result;
		}
		return 0.0;
	}

	internal static Exception z0rek(long p0, Type p1)
	{
		return new InvalidOperationException(p1.FullName + "不含数值" + p0);
	}
}
