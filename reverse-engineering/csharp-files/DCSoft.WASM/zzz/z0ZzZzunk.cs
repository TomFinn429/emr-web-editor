using System;

namespace zzz;

internal class z0ZzZzunk : IDisposable
{
	public object z0uek;

	private string z0iek;

	private string z0oek;

	private int z0pek;

	internal string z0mek;

	public string z0eek()
	{
		return z0iek;
	}

	public void Dispose()
	{
		z0iek = null;
		z0mek = null;
		z0oek = null;
		z0uek = null;
	}

	public string z0rek()
	{
		return z0mek;
	}

	internal bool z0eek(z0ZzZzunk p0)
	{
		if (z0mek == p0.z0mek)
		{
			return z0oek == p0.z0yek();
		}
		return false;
	}

	public z0ZzZzunk(string p0, string p1, string p2)
	{
		z0iek = p0;
		z0mek = p1;
		z0oek = p2;
	}

	public int z0tek()
	{
		if (z0pek == 0)
		{
			z0pek = z0mek.GetHashCode();
			if (z0oek != null && z0oek.Length > 0)
			{
				z0pek += z0oek.GetHashCode();
			}
		}
		return z0pek;
	}

	public z0ZzZzunk(string p0, string p1)
	{
		z0iek = p0;
		z0mek = p0.ToLower();
		z0oek = p1;
	}

	public string z0yek()
	{
		return z0oek;
	}
}
