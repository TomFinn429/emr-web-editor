using System;
using System.Diagnostics;

namespace zzz;

[DebuggerDisplay("Rectangle:Left={X},Top={Y},Width={Width},Height={Height}")]
public struct z0ZzZzndh : IEquatable<z0ZzZzndh>
{
	public static readonly z0ZzZzndh z0cek;

	internal int z0xek;

	internal int z0zek;

	internal int z0lrk;

	internal int z0krk;

	public z0ZzZzndh(int p0, int p1, int p2, int p3)
	{
		z0xek = p0;
		z0zek = p1;
		z0lrk = p2;
		z0krk = p3;
	}

	public z0ZzZzndh(z0ZzZzodh p0, z0ZzZzcdh p1)
	{
		z0xek = p0.z0rek();
		z0zek = p0.z0tek();
		z0lrk = p1.z0rek();
		z0krk = p1.z0tek();
	}

	public z0ZzZzbdh z0eek()
	{
		return new z0ZzZzbdh(z0xek, z0zek, z0lrk, z0krk);
	}

	public readonly z0ZzZzodh z0rek()
	{
		return new z0ZzZzodh(z0xek, z0zek);
	}

	public void z0eek(z0ZzZzodh p0)
	{
		z0xek = p0.z0rek();
		z0zek = p0.z0tek();
	}

	public readonly z0ZzZzcdh z0tek()
	{
		return new z0ZzZzcdh(z0lrk, z0krk);
	}

	public void z0eek(z0ZzZzcdh p0)
	{
		z0lrk = p0.z0rek();
		z0krk = p0.z0tek();
	}

	public readonly int z0yek()
	{
		return z0xek;
	}

	public void z0eek(int p0)
	{
		z0xek = p0;
	}

	public readonly int z0uek()
	{
		return z0zek;
	}

	public void z0rek(int p0)
	{
		z0zek = p0;
	}

	public readonly int z0iek()
	{
		return z0lrk;
	}

	public void z0tek(int p0)
	{
		z0lrk = p0;
	}

	public readonly int z0oek()
	{
		return z0krk;
	}

	public void z0yek(int p0)
	{
		z0krk = p0;
	}

	public readonly int z0pek()
	{
		return z0xek;
	}

	public readonly int z0mek()
	{
		return z0zek;
	}

	public readonly int z0nek()
	{
		return z0xek + z0lrk;
	}

	public readonly int z0bek()
	{
		return z0zek + z0krk;
	}

	public readonly bool z0vek()
	{
		if (z0krk == 0 && z0lrk == 0 && z0xek == 0)
		{
			return z0zek == 0;
		}
		return false;
	}

	public override readonly bool Equals(object obj)
	{
		if (obj is z0ZzZzndh)
		{
			return Equals((z0ZzZzndh)obj);
		}
		return false;
	}

	public readonly bool Equals(z0ZzZzndh other)
	{
		return z0eek(this, other);
	}

	public static bool z0eek(z0ZzZzndh p0, z0ZzZzndh p1)
	{
		if (p0.z0xek == p1.z0xek && p0.z0zek == p1.z0zek && p0.z0lrk == p1.z0lrk)
		{
			return p0.z0krk == p1.z0krk;
		}
		return false;
	}

	public static bool z0rek(z0ZzZzndh p0, z0ZzZzndh p1)
	{
		return !z0eek(p0, p1);
	}

	public static z0ZzZzndh z0eek(z0ZzZzbdh p0)
	{
		return new z0ZzZzndh((int)Math.Ceiling(p0.z0tek()), (int)Math.Ceiling(p0.z0yek()), (int)Math.Ceiling(p0.z0uek()), (int)Math.Ceiling(p0.z0iek()));
	}

	public static z0ZzZzbdh z0rek(z0ZzZzbdh p0)
	{
		return new z0ZzZzbdh((float)Math.Ceiling(p0.z0tek()), (float)Math.Ceiling(p0.z0yek()), (float)Math.Ceiling(p0.z0uek()), (float)Math.Ceiling(p0.z0iek()));
	}

	public static z0ZzZzndh z0tek(z0ZzZzbdh p0)
	{
		return new z0ZzZzndh((int)p0.z0tek(), (int)p0.z0yek(), (int)p0.z0uek(), (int)p0.z0iek());
	}

	public static z0ZzZzndh z0yek(z0ZzZzbdh p0)
	{
		return new z0ZzZzndh((int)Math.Round(p0.z0tek()), (int)Math.Round(p0.z0yek()), (int)Math.Round(p0.z0uek()), (int)Math.Round(p0.z0iek()));
	}

	public readonly bool z0eek(int p0, int p1)
	{
		if (z0xek <= p0 && p0 < z0xek + z0lrk && z0zek <= p1)
		{
			return p1 < z0zek + z0krk;
		}
		return false;
	}

	public readonly bool z0rek(z0ZzZzodh p0)
	{
		return z0eek(p0.z0rek(), p0.z0tek());
	}

	public readonly bool z0eek(z0ZzZzndh p0)
	{
		if (z0xek <= p0.z0xek && p0.z0xek + p0.z0lrk <= z0xek + z0lrk && z0zek <= p0.z0zek)
		{
			return p0.z0zek + p0.z0krk <= z0zek + z0krk;
		}
		return false;
	}

	public override readonly int GetHashCode()
	{
		return HashCode.Combine(z0yek(), z0uek(), z0iek(), z0oek());
	}

	public static z0ZzZzndh z0tek(z0ZzZzndh p0, z0ZzZzndh p1)
	{
		int num = Math.Max(p0.z0xek, p1.z0xek);
		int num2 = Math.Min(p0.z0xek + p0.z0lrk, p1.z0xek + p1.z0lrk);
		int num3 = Math.Max(p0.z0zek, p1.z0zek);
		int num4 = Math.Min(p0.z0zek + p0.z0krk, p1.z0zek + p1.z0krk);
		if (num2 >= num && num4 >= num3)
		{
			return new z0ZzZzndh(num, num3, num2 - num, num4 - num3);
		}
		return z0cek;
	}

	public readonly bool z0rek(z0ZzZzndh p0)
	{
		if (p0.z0xek < z0xek + z0lrk && z0xek < p0.z0xek + p0.z0lrk && p0.z0zek < z0zek + z0krk)
		{
			return z0zek < p0.z0zek + p0.z0krk;
		}
		return false;
	}

	public static z0ZzZzndh z0yek(z0ZzZzndh p0, z0ZzZzndh p1)
	{
		int num = Math.Min(p0.z0xek, p1.z0xek);
		int num2 = Math.Max(p0.z0xek + p0.z0lrk, p1.z0xek + p1.z0lrk);
		int num3 = Math.Min(p0.z0zek, p1.z0zek);
		int num4 = Math.Max(p0.z0zek + p0.z0krk, p1.z0zek + p1.z0krk);
		return new z0ZzZzndh(num, num3, num2 - num, num4 - num3);
	}

	public void z0tek(z0ZzZzodh p0)
	{
		z0xek += p0.z0rek();
		z0zek += p0.z0tek();
	}

	public void z0rek(int p0, int p1)
	{
		z0xek += p0;
		z0zek += p1;
	}

	public override readonly string ToString()
	{
		return $"{{X={z0yek()},Y={z0uek()},Width={z0iek()},Height={z0oek()}}}";
	}
}
