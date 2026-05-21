using System.Collections;

namespace zzz;

internal sealed class z0ZzZzvuj : z0ZzZzcuj
{
	private string z0rek;

	private static Hashtable z0tek_jiejie20260327142557;

	private static Hashtable z0yek;

	private static void z0eek(int p0, string[] p1)
	{
		z0ZzZzvuj z0ZzZzvuj2 = new z0ZzZzvuj(p0, p1[0]);
		z0tek_jiejie20260327142557[p0] = z0ZzZzvuj2;
		for (int i = 0; i < p1.Length; i++)
		{
			z0yek[p1[i]] = z0ZzZzvuj2;
		}
	}

	public static z0ZzZzvuj z0eek(string p0)
	{
		if (z0yek == null)
		{
			z0eek();
		}
		return (z0ZzZzvuj)z0yek[p0];
	}

	private static void z0eek(int p0, string p1)
	{
		z0ZzZzvuj z0ZzZzvuj2 = new z0ZzZzvuj(p0, p1);
		z0tek_jiejie20260327142557[p0] = z0ZzZzvuj2;
		z0yek[p1] = z0ZzZzvuj2;
	}

	private z0ZzZzvuj(int p0, string p1)
		: base(p0)
	{
		z0rek = p1;
	}

	private new static void z0eek()
	{
		z0tek_jiejie20260327142557 = Hashtable.Synchronized(new Hashtable(29));
		z0yek = Hashtable.Synchronized(new Hashtable(29));
		z0eek(0, "Cp437");
		z0eek(1, new string[2] { "ISO8859_1", "ISO-8859-1" });
		z0eek(2, "Cp437");
		z0eek(3, new string[2] { "ISO8859_1", "ISO-8859-1" });
		z0eek(4, "ISO8859_2");
		z0eek(5, "ISO8859_3");
		z0eek(6, "ISO8859_4");
		z0eek(7, "ISO8859_5");
		z0eek(8, "ISO8859_6");
		z0eek(9, "ISO8859_7");
		z0eek(10, "ISO8859_8");
		z0eek(11, "ISO8859_9");
		z0eek(12, "ISO8859_10");
		z0eek(13, "ISO8859_11");
		z0eek(15, "ISO8859_13");
		z0eek(16, "ISO8859_14");
		z0eek(17, "ISO8859_15");
		z0eek(18, "ISO8859_16");
		z0eek(20, new string[2] { "SJIS", "Shift_JIS" });
	}
}
