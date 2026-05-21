using System;

namespace zzz;

internal class z0ZzZzyah : z0ZzZzaqh
{
	internal z0ZzZzyah z0pek;

	private readonly string z0mek;

	private readonly int z0nek_jiejie20260327142557;

	private readonly string z0bek_jiejie20260327142557;

	private readonly string z0vek;

	private string z0cek;

	internal z0ZzZzfah z0xek;

	public static z0ZzZzyah z0eek(string p0, string p1, string p2, int p3, z0ZzZzfah p4, z0ZzZzyah p5, z0ZzZzaqh p6)
	{
		return new z0ZzZzyah(p0, p1, p2, p3, p4, p5);
	}

	public string z0eek()
	{
		if (z0cek == null)
		{
			if (z0mek.Length > 0)
			{
				if (z0bek_jiejie20260327142557.Length > 0)
				{
					string p = z0mek + ":" + z0bek_jiejie20260327142557;
					if (z0cek == null)
					{
						z0cek = z0xek.z0tek().z0nf(p);
					}
				}
				else
				{
					z0cek = z0mek;
				}
			}
			else
			{
				z0cek = z0bek_jiejie20260327142557;
			}
		}
		return z0cek;
	}

	public string z0rek()
	{
		return z0vek;
	}

	public virtual z0ZzZzwqh z0tek()
	{
		return (z0ZzZzwqh)0;
	}

	public virtual bool z0eek(z0ZzZzaqh p0)
	{
		return p0 == null;
	}

	public string z0yek()
	{
		return z0bek_jiejie20260327142557;
	}

	public int z0uek_jiejie20260327142557()
	{
		return z0nek_jiejie20260327142557;
	}

	public static int z0eek(string p0)
	{
		int result = 0;
		if (p0 != null)
		{
			return string.GetHashCode(p0.AsSpan(p0.LastIndexOf(':') + 1));
		}
		return result;
	}

	public z0ZzZzfah z0iek()
	{
		return z0xek;
	}

	internal z0ZzZzyah(string p0, string p1, string p2, int p3, z0ZzZzfah p4, z0ZzZzyah p5)
	{
		z0mek = p0;
		z0bek_jiejie20260327142557 = p1;
		z0vek = p2;
		z0cek = null;
		z0nek_jiejie20260327142557 = p3;
		z0xek = p4;
		z0pek = p5;
	}

	public string z0oek()
	{
		return z0mek;
	}
}
