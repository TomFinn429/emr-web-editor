using System;
using System.Collections.Generic;
using System.Text;

namespace zzz;

internal class z0ZzZzzfj : z0ZzZzygj
{
	public bool z0jrk;

	public static readonly z0ZzZzzfj z0hrk = new z0ZzZzzfj();

	[ThreadStatic]
	private static Dictionary<byte[], string> z0grk = new Dictionary<byte[], string>();

	private long z0frk;

	private z0ZzZzfdj z0drk;

	private static readonly HashSet<string> z0srk = new HashSet<string>
	{
		z0ZzZzkdj.z0bek,
		z0ZzZzgdj.z0cek,
		z0ZzZzqdj.z0tek,
		z0ZzZzfdj.z0tek,
		z0ZzZzgaj.z0oek,
		z0ZzZzfaj.z0uek,
		"cvt ",
		"fpgm",
		"prep"
	};

	private readonly byte[] z0ark;

	private static readonly byte[] z0qrk = new byte[4] { 0, 1, 0, 0 };

	private readonly Dictionary<string, z0ZzZzodj> z0wrk = new Dictionary<string, z0ZzZzodj>();

	private float z0erk = 0.48828125f;

	private z0ZzZzsdj z0rrk;

	private z0ZzZzgdj z0trk;

	private z0ZzZzyfj z0yrk;

	public string z0irk;

	public readonly z0ZzZzwdj z0ork;

	internal z0ZzZzydj z0uek()
	{
		return z0eek<z0ZzZzydj>(z0ZzZzydj.z0zek);
	}

	internal bool z0iek()
	{
		return z0nek() != null;
	}

	internal z0ZzZzfaj z0oek()
	{
		return z0eek<z0ZzZzfaj>(z0ZzZzfaj.z0uek);
	}

	private z0ZzZzzfj()
	{
	}

	private T z0eek<T>(string p0) where T : z0ZzZzodj
	{
		if (!z0wrk.TryGetValue(p0, out var z0ZzZzodj2))
		{
			return null;
		}
		return z0ZzZzodj2 as T;
	}

	internal z0ZzZzgdj z0pek()
	{
		if (z0trk == null)
		{
			z0trk = z0eek<z0ZzZzgdj>(z0ZzZzgdj.z0cek);
		}
		return z0trk;
	}

	internal z0ZzZzfdj z0mek()
	{
		if (z0drk == null)
		{
			z0drk = z0eek<z0ZzZzfdj>(z0ZzZzfdj.z0tek);
		}
		return z0drk;
	}

	internal z0ZzZzgaj z0nek()
	{
		return z0eek<z0ZzZzgaj>(z0ZzZzgaj.z0oek);
	}

	internal z0ZzZzzfj(z0ZzZzjgj p0)
	{
		z0grk = new Dictionary<byte[], string>();
		z0ark = z0cek();
		z0uek(p0);
		z0ork = new z0ZzZzwdj(this);
		z0grk.Clear();
		z0grk = null;
	}

	internal z0ZzZztdj z0bek()
	{
		return z0eek<z0ZzZztdj>(z0ZzZztdj.z0uek);
	}

	internal z0ZzZzyfj z0vek()
	{
		if (z0yrk == null)
		{
			z0yrk = z0eek<z0ZzZzyfj>(z0ZzZzyfj.z0yek);
		}
		return z0yrk;
	}

	protected override void z0ygk(bool p0)
	{
		if (p0)
		{
			foreach (KeyValuePair<string, z0ZzZzodj> item in z0wrk)
			{
				item.Value.Dispose();
			}
		}
		z0wrk.Clear();
		if (z0trk != null)
		{
			z0trk.Dispose();
			z0trk = null;
		}
		if (z0yrk != null)
		{
			z0yrk.Dispose();
			z0yrk = null;
		}
		if (z0drk != null)
		{
			z0drk.Dispose();
			z0drk = null;
		}
		if (z0rrk != null)
		{
			z0rrk.Dispose();
			z0rrk = null;
		}
	}

	private void z0uek(z0ZzZzjgj p0)
	{
		z0frk = p0.z0mek();
		long num = p0.z0uek();
		p0.z0nek();
		short num2 = p0.z0yek();
		p0.z0yek();
		p0.z0yek();
		p0.z0eek(num + 12);
		long num3 = p0.z0mek();
		for (short num4 = 0; num4 < num2; num4++)
		{
			string text = p0.z0iek(4);
			p0.z0nek();
			long num5 = p0.z0nek();
			int num6 = p0.z0nek();
			if (text == z0ZzZzgaj.z0oek && num6 == 0)
			{
				num6 = (int)(num3 - num5);
			}
			if (text != "EBLC" && num5 > 0 && num5 < num3 && num6 > 0)
			{
				long p1 = p0.z0uek();
				p0.z0eek(num5);
				z0uek(z0ZzZzodj.z0eek(text, p0.z0tek(Math.Min(num6, (int)(num3 - num5)))));
				p0.z0eek(p1);
			}
		}
		z0ZzZzkdj z0ZzZzkdj2 = z0lrk();
		if (z0ZzZzkdj2 != null)
		{
			z0erk = 1000f / (float)z0ZzZzkdj2.z0eek();
		}
		z0oek()?.z0eek(this);
		z0nek()?.z0rek(this);
	}

	public static string z0uek(byte[] p0, Encoding p1)
	{
		if (p0 == null)
		{
			return null;
		}
		if (p0.Length == 0)
		{
			return string.Empty;
		}
		string text = null;
		if (!z0grk.TryGetValue(p0, out text))
		{
			text = p1.GetString(p0);
			z0grk[p0] = text;
		}
		return text;
	}

	internal static bool z0uek(z0ZzZzzfj p0, z0ZzZzzfj p1)
	{
		if (p0 == null && p1 == null)
		{
			return false;
		}
		if ((p0 == null && p1 != null) || (p0 != null && p1 == null))
		{
			return false;
		}
		return p0.z0frk == p1.z0frk;
	}

	internal byte[] z0rek(IDictionary<int, string> p0)
	{
		z0nek()?.z0eek(this, p0);
		List<string> p1 = new List<string>(new string[13]
		{
			"post", "name", "cmap", "cvt", "fpgm", "glyf", "head", "hhea", "hmtx", "loca",
			"maxp", "prep", "OS/2"
		});
		return z0yek(p1);
	}

	internal z0ZzZzzfj(byte[] p0, byte[] p1)
	{
		z0grk = new Dictionary<byte[], string>();
		z0ark = p0;
		using (z0ZzZzjgj p2 = new z0ZzZzjgj(p1))
		{
			z0uek(p2);
		}
		z0ork = new z0ZzZzwdj(this);
		z0grk.Clear();
		z0grk = null;
	}

	internal static byte[] z0cek()
	{
		return z0qrk;
	}

	internal float z0uek(int p0)
	{
		z0ZzZzfdj z0ZzZzfdj2 = z0mek();
		if (z0ZzZzfdj2 == null)
		{
			return 0f;
		}
		short[] array = z0ZzZzfdj2.z0eek();
		if (array == null)
		{
			z0ZzZzgdj z0ZzZzgdj2 = z0pek();
			if (z0ZzZzgdj2 == null)
			{
				return 0f;
			}
			z0ZzZzqdj z0ZzZzqdj2 = z0xek();
			array = z0ZzZzfdj2.z0eek(z0ZzZzgdj2.z0tek(), z0ZzZzqdj2?.z0eek() ?? 0);
		}
		if (p0 >= array.Length)
		{
			return 0f;
		}
		return (float)array[p0] * z0erk;
	}

	internal byte[] z0tek(IDictionary<int, string> p0)
	{
		z0nek()?.z0eek(this, p0);
		return z0yek(z0srk);
	}

	internal z0ZzZzqdj z0xek()
	{
		return z0eek<z0ZzZzqdj>(z0ZzZzqdj.z0tek);
	}

	internal z0ZzZzsdj z0zek()
	{
		if (z0rrk == null)
		{
			z0rrk = z0eek<z0ZzZzsdj>(z0ZzZzsdj.z0tek);
		}
		return z0rrk;
	}

	internal void z0uek(z0ZzZzodj p0)
	{
		z0wrk[p0.z0rek()] = p0;
	}

	internal z0ZzZzkdj z0lrk()
	{
		return z0eek<z0ZzZzkdj>(z0ZzZzkdj.z0bek);
	}

	internal z0ZzZzidj z0krk()
	{
		return z0eek<z0ZzZzidj>(z0ZzZzidj.z0iek);
	}

	private byte[] z0yek(ICollection<string> p0)
	{
		short num = 0;
		KeyValuePair<string, z0ZzZzodj>[] array = z0ZzZzlxk.z0eek(z0wrk);
		KeyValuePair<string, z0ZzZzodj>[] array2 = array;
		foreach (KeyValuePair<string, z0ZzZzodj> keyValuePair in array2)
		{
			if (p0.Contains(keyValuePair.Key))
			{
				num++;
			}
		}
		int num2 = 12 + num * 16;
		using z0ZzZzjgj z0ZzZzjgj2 = new z0ZzZzjgj();
		z0ZzZzjgj2.z0eek(z0ark);
		z0ZzZzjgj2.z0eek(num);
		short num3 = Convert.ToInt16(Math.Pow(2.0, Math.Floor(Math.Log(num, 2.0))));
		short num4 = (short)(num3 * 16);
		z0ZzZzjgj2.z0eek(num4);
		z0ZzZzjgj2.z0eek(Convert.ToInt16(Math.Log(num3, 2.0)));
		z0ZzZzjgj2.z0eek((short)(num * 16 - num4));
		array2 = array;
		for (int i = 0; i < array2.Length; i++)
		{
			KeyValuePair<string, z0ZzZzodj> keyValuePair2 = array2[i];
			if (p0.Contains(keyValuePair2.Key))
			{
				num2 += keyValuePair2.Value.z0eek(z0ZzZzjgj2, num2);
			}
		}
		array2 = array;
		for (int i = 0; i < array2.Length; i++)
		{
			KeyValuePair<string, z0ZzZzodj> keyValuePair3 = array2[i];
			if (p0.Contains(keyValuePair3.Key))
			{
				z0ZzZzjgj2.z0eek(keyValuePair3.Value.z0tek());
			}
		}
		z0ZzZzjgj2.z0eek(0L);
		return z0ZzZzjgj2.z0yek(z0ZzZzjgj2.z0mek());
	}
}
