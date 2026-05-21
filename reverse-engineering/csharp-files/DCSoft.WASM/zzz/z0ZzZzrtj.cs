using System;

namespace zzz;

internal class z0ZzZzrtj : z0ZzZzftj
{
	private int z0vek = 100;

	private byte[] z0cek;

	private int z0xek;

	private z0ZzZzryj z0zek = (z0ZzZzryj)2;

	private int z0lrk = 100;

	private z0ZzZzmrj z0krk = new z0ZzZzmrj();

	private int z0jrk;

	private int z0hrk;

	private int z0grk;

	private string z0frk;

	public void z0eek(int p0)
	{
		z0lrk = p0;
	}

	public void z0rek(int p0)
	{
		z0hrk = p0;
	}

	public new void z0eek(string p0)
	{
		z0frk = p0;
	}

	public new int z0eek()
	{
		return z0vek;
	}

	public new int z0rek()
	{
		return z0hrk;
	}

	public new int z0tek()
	{
		return z0lrk;
	}

	public int z0yek()
	{
		return z0xek;
	}

	public new byte[] z0uek()
	{
		return z0cek;
	}

	public void z0tek(int p0)
	{
		z0xek = p0;
	}

	public new int z0iek()
	{
		return z0grk;
	}

	public void z0yek(int p0)
	{
		z0grk = p0;
	}

	public void z0eek(z0ZzZzmrj p0)
	{
		z0krk = p0;
	}

	public void z0rek(string p0)
	{
		if (p0 != null && p0.Length > 0)
		{
			z0cek = Convert.FromBase64String(p0);
		}
		else
		{
			z0cek = null;
		}
	}

	public new string z0oek()
	{
		if (z0cek == null)
		{
			return null;
		}
		return Convert.ToBase64String(z0cek);
	}

	public int z0pek()
	{
		return z0jrk;
	}

	public void z0eek(z0ZzZzryj p0)
	{
		z0zek = p0;
	}

	public void z0eek(byte[] p0)
	{
		z0cek = p0;
	}

	public new z0ZzZzryj z0mek()
	{
		return z0zek;
	}

	public void z0uek(int p0)
	{
		z0jrk = p0;
	}

	public z0ZzZzmrj z0nek()
	{
		return z0krk;
	}

	public void z0iek(int p0)
	{
		z0vek = p0;
	}

	public string z0bek()
	{
		return z0frk;
	}
}
