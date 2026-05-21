using System;
using System.Resources;

namespace zzz;

public class z0ZzZzeah : SystemException
{
	private readonly string[] z0rek;

	private readonly int z0tek;

	private readonly string z0yek;

	private readonly int z0uek;

	public z0ZzZzeah(string p0)
		: this(p0, (Exception)null, 0, 0)
	{
	}

	internal z0ZzZzeah(string p0, string p1, int p2, int p3)
		: this(p0, new string[1] { p1 }, null, p2, p3, null)
	{
	}

	private static string z0eek(string p0, string[] p1, int p2, int p3)
	{
		try
		{
			string text;
			if (p1 != null)
			{
				text = string.Format(p0, p1);
			}
			else
			{
				text = p0;
			}
			string text2 = text;
			if (p2 != 0)
			{
				text2 = "MessageWithErrorPosition:" + text2;
			}
			return text2;
		}
		catch (MissingManifestResourceException)
		{
			return "UNKNOWN(" + p0 + ")";
		}
	}

	internal z0ZzZzeah(string p0, Exception p1, int p2, int p3, string p4)
		: base(z0eek(p0, p2, p3), p1)
	{
		z0yek = "";
		z0rek = new string[1] { p0 };
		z0uek = p2;
		z0tek = p3;
	}

	private static string z0eek(string p0, int p1, int p2)
	{
		if (p0 == null)
		{
			return z0eek("", null, p1, p2);
		}
		if (p1 == 0 && p2 == 0)
		{
			return p0;
		}
		return z0eek("", new string[1] { p0 }, p1, p2);
	}

	internal z0ZzZzeah(string p0, string[] p1, Exception? p2, int p3, int p4, string? p5)
		: base(z0eek(p0, p1, p3, p4), p2)
	{
		z0yek = p0;
		z0rek = p1;
		z0uek = p3;
		z0tek = p4;
	}

	internal z0ZzZzeah(string p0, string[] p1, int p2, int p3)
		: this(p0, p1, null, p2, p3, null)
	{
	}

	public z0ZzZzeah(string p0, Exception p1, int p2, int p3)
		: this(p0, p1, p2, p3, null)
	{
	}

	public z0ZzZzeah()
		: this(null)
	{
	}
}
