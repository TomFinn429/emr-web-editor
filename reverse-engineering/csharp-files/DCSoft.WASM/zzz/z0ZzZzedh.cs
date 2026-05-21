using System;
using System.IO;

namespace zzz;

public abstract class z0ZzZzedh : IDisposable
{
	private bool z0mek;

	protected int z0nek;

	private static int z0bek;

	private int z0vek = -2147483648;

	public int z0cek = z0bek++;

	protected int z0xek;

	public z0ZzZzrdh z0zek = z0ZzZzrdh.z0vek;

	public static z0ZzZzedh z0eek(Stream p0)
	{
		return null;
	}

	public virtual object z0eek()
	{
		return MemberwiseClone();
	}

	internal void z0rek()
	{
		if (z0mek)
		{
			throw new ObjectDisposedException(GetType().Name);
		}
	}

	internal z0ZzZztdh z0tek()
	{
		return (z0ZzZztdh)137224;
	}

	public int z0yek()
	{
		z0rek();
		return z0xek;
	}

	internal void z0eek(int p0)
	{
		z0vek = p0;
	}

	public z0ZzZzedh()
	{
	}

	public virtual byte[] z0gd()
	{
		return null;
	}

	public int z0uek()
	{
		return z0vek;
	}

	public int z0iek()
	{
		z0rek();
		return z0nek;
	}

	public virtual void Dispose()
	{
		z0mek = true;
	}

	public virtual void z0hd(Stream p0, z0ZzZzrdh p1)
	{
	}

	public z0ZzZzcdh z0oek()
	{
		return new z0ZzZzcdh(z0nek, z0xek);
	}

	public z0ZzZzrdh z0pek()
	{
		return z0zek;
	}
}
