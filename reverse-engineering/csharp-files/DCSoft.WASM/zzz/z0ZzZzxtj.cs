using System;
using System.Collections.Generic;
using System.Text;

namespace zzz;

public class z0ZzZzxtj
{
	private bool z0oek;

	private int z0pek;

	private static Dictionary<int, Encoding> z0mek;

	private Encoding z0nek;

	private int z0bek = 1;

	private string z0vek;

	private static void z0eek()
	{
		if (z0mek == null)
		{
			z0mek = new Dictionary<int, Encoding>();
			try
			{
				z0mek[77] = z0ZzZzqik.z0eek(10000);
				z0mek[128] = z0ZzZzqik.z0eek(932);
				z0mek[130] = z0ZzZzqik.z0eek(1361);
				z0mek[134] = z0ZzZzqik.z0eek(936);
				z0mek[136] = z0ZzZzqik.z0eek(10002);
				z0mek[161] = z0ZzZzqik.z0eek(1253);
				z0mek[162] = z0ZzZzqik.z0eek(1254);
				z0mek[163] = z0ZzZzqik.z0eek(1258);
				z0mek[177] = z0ZzZzqik.z0eek(1255);
				z0mek[178] = z0ZzZzqik.z0eek(864);
				z0mek[179] = z0ZzZzqik.z0eek(864);
				z0mek[180] = z0ZzZzqik.z0eek(864);
				z0mek[181] = z0ZzZzqik.z0eek(864);
				z0mek[186] = z0ZzZzqik.z0eek(775);
				z0mek[204] = z0ZzZzqik.z0eek(866);
				z0mek[222] = z0ZzZzqik.z0eek(874);
				z0mek[255] = z0ZzZzqik.z0eek(437);
			}
			catch (Exception ex)
			{
				z0ZzZzqok.z0rek.z0dh("RTF.CheckEncodingCharsets:" + ex.Message);
			}
		}
	}

	public void z0eek(string p0)
	{
		z0vek = p0;
	}

	public Encoding z0rek()
	{
		return z0nek;
	}

	public void z0eek(bool p0)
	{
		z0oek = p0;
	}

	public z0ZzZzxtj(int p0, string p1)
	{
		z0pek = p0;
		z0vek = p1;
	}

	public int z0tek()
	{
		return z0bek;
	}

	public void z0eek(int p0)
	{
		z0pek = p0;
	}

	public bool z0yek()
	{
		return z0oek;
	}

	internal static int z0eek(Encoding p0)
	{
		z0eek();
		foreach (int key in z0mek.Keys)
		{
			if (z0mek[key] == p0)
			{
				return key;
			}
		}
		return 1;
	}

	public int z0uek()
	{
		return z0pek;
	}

	internal static Encoding z0rek(int p0)
	{
		switch (p0)
		{
		case 0:
			return z0ZzZzorj.z0eek;
		case 1:
			return z0ZzZzltj.z0rik;
		default:
			z0eek();
			if (z0mek.ContainsKey(p0))
			{
				return z0mek[p0];
			}
			return null;
		}
	}

	public void z0tek(int p0)
	{
		z0bek = p0;
		z0nek = z0rek(z0bek);
	}

	public string z0iek()
	{
		return z0vek;
	}
}
