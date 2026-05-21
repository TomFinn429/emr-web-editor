using System;
using System.Diagnostics;

namespace zzz;

[DebuggerDisplay("RectangleF:Left={Left},Top={Top},Width={Width},Height={Height}")]
public struct z0ZzZzbdh : IEquatable<z0ZzZzbdh>
{
	public static readonly z0ZzZzbdh z0xek;

	private float z0zek;

	private float z0lrk;

	private float z0krk;

	private float z0jrk;

	public z0ZzZzbdh(float p0, float p1, float p2, float p3)
	{
		z0zek = p0;
		z0lrk = p1;
		z0krk = p2;
		z0jrk = p3;
	}

	public z0ZzZzbdh(z0ZzZzpdh p0, z0ZzZzxdh p1)
	{
		z0zek = p0.z0rek();
		z0lrk = p0.z0tek();
		z0krk = p1.z0rek();
		z0jrk = p1.z0tek();
	}

	public static z0ZzZzbdh z0eek(float p0, float p1, float p2, float p3)
	{
		return new z0ZzZzbdh(p0, p1, p2 - p0, p3 - p1);
	}

	public readonly z0ZzZzpdh z0eek()
	{
		return new z0ZzZzpdh(z0zek, z0lrk);
	}

	public void z0eek(z0ZzZzpdh p0)
	{
		z0zek = p0.z0rek();
		z0lrk = p0.z0tek();
	}

	public readonly z0ZzZzxdh z0rek()
	{
		return new z0ZzZzxdh(z0krk, z0jrk);
	}

	public void z0eek(z0ZzZzxdh p0)
	{
		z0krk = p0.z0rek();
		z0jrk = p0.z0tek();
	}

	public readonly float z0tek()
	{
		return z0zek;
	}

	public void z0eek(float p0)
	{
		z0zek = p0;
	}

	public readonly float z0yek()
	{
		return z0lrk;
	}

	public void z0rek(float p0)
	{
		z0lrk = p0;
	}

	public readonly float z0uek()
	{
		return z0krk;
	}

	public void z0tek(float p0)
	{
		z0krk = p0;
	}

	public readonly float z0iek()
	{
		return z0jrk;
	}

	public void z0yek(float p0)
	{
		z0jrk = p0;
	}

	public readonly float z0oek()
	{
		return z0zek;
	}

	public readonly float z0pek()
	{
		return z0lrk;
	}

	public readonly float z0mek()
	{
		return z0zek + z0krk;
	}

	public readonly float z0nek()
	{
		return z0lrk + z0jrk;
	}

	public readonly bool z0bek()
	{
		if (!(z0krk <= 0f))
		{
			return z0jrk <= 0f;
		}
		return true;
	}

	public override readonly bool Equals(object obj)
	{
		if (obj is z0ZzZzbdh)
		{
			return Equals((z0ZzZzbdh)obj);
		}
		return false;
	}

	public readonly bool Equals(z0ZzZzbdh other)
	{
		return z0eek(this, other);
	}

	public static bool z0eek(z0ZzZzbdh p0, z0ZzZzbdh p1)
	{
		if (p0.z0zek == p1.z0zek && p0.z0lrk == p1.z0lrk && p0.z0krk == p1.z0krk)
		{
			return p0.z0jrk == p1.z0jrk;
		}
		return false;
	}

	public static bool z0rek(z0ZzZzbdh p0, z0ZzZzbdh p1)
	{
		return !z0eek(p0, p1);
	}

	public readonly bool z0eek(float p0, float p1)
	{
		if (z0zek <= p0 && p0 < z0zek + z0krk && z0lrk <= p1)
		{
			return p1 < z0lrk + z0jrk;
		}
		return false;
	}

	public readonly bool z0rek(z0ZzZzpdh p0)
	{
		return z0eek(p0.z0rek(), p0.z0tek());
	}

	public readonly bool z0eek(z0ZzZzbdh p0)
	{
		if (z0zek <= p0.z0zek && p0.z0zek + p0.z0krk <= z0zek + z0krk && z0lrk <= p0.z0lrk)
		{
			return p0.z0lrk + p0.z0jrk <= z0lrk + z0jrk;
		}
		return false;
	}

	public readonly bool z0eek(z0ZzZzbdh p0, float p1, float p2)
	{
		if (z0zek - p1 <= p0.z0zek && p0.z0zek + p0.z0krk <= z0zek + z0krk + p1 && z0lrk - p2 <= p0.z0lrk)
		{
			return p0.z0lrk + p0.z0jrk <= z0lrk + z0jrk + p2;
		}
		return false;
	}

	public override readonly int GetHashCode()
	{
		return HashCode.Combine(z0zek, z0lrk, z0krk, z0jrk);
	}

	public void z0rek(float p0, float p1)
	{
		z0zek -= p0;
		z0lrk -= p1;
		z0krk += 2f * p0;
		z0jrk += 2f * p1;
	}

	public void z0rek(z0ZzZzbdh p0)
	{
		z0ZzZzbdh z0ZzZzbdh2 = z0tek(p0, this);
		z0zek = z0ZzZzbdh2.z0zek;
		z0lrk = z0ZzZzbdh2.z0lrk;
		z0krk = z0ZzZzbdh2.z0krk;
		z0jrk = z0ZzZzbdh2.z0jrk;
	}

	public static z0ZzZzbdh z0tek(z0ZzZzbdh p0, z0ZzZzbdh p1)
	{
		float num = ((p0.z0zek > p1.z0zek) ? p0.z0zek : p1.z0zek);
		float num2 = ((p0.z0zek + p0.z0krk < p1.z0zek + p1.z0krk) ? (p0.z0zek + p0.z0krk) : (p1.z0zek + p1.z0krk));
		float num3 = ((p0.z0lrk > p1.z0lrk) ? p0.z0lrk : p1.z0lrk);
		float num4 = ((p0.z0lrk + p0.z0jrk < p1.z0lrk + p1.z0jrk) ? (p0.z0lrk + p0.z0jrk) : (p1.z0lrk + p1.z0jrk));
		if (num2 >= num && num4 >= num3)
		{
			return new z0ZzZzbdh(num, num3, num2 - num, num4 - num3);
		}
		return z0xek;
	}

	public readonly bool z0tek(z0ZzZzbdh p0)
	{
		if (p0.z0zek < z0zek + z0krk && z0zek < p0.z0zek + p0.z0krk && p0.z0lrk < z0lrk + z0jrk)
		{
			return z0lrk < p0.z0lrk + p0.z0jrk;
		}
		return false;
	}

	public readonly bool z0eek(z0ZzZzndh p0)
	{
		if ((float)p0.z0xek < z0zek + z0krk && z0zek < (float)(p0.z0xek + p0.z0lrk) && (float)p0.z0zek < z0lrk + z0jrk)
		{
			return z0lrk < (float)(p0.z0zek + p0.z0krk);
		}
		return false;
	}

	public static z0ZzZzbdh z0yek(z0ZzZzbdh p0, z0ZzZzbdh p1)
	{
		float num = Math.Min(p0.z0zek, p1.z0zek);
		float num2 = Math.Max(p0.z0zek + p0.z0krk, p1.z0zek + p1.z0krk);
		float num3 = Math.Min(p0.z0lrk, p1.z0lrk);
		float num4 = Math.Max(p0.z0lrk + p0.z0jrk, p1.z0lrk + p1.z0jrk);
		return new z0ZzZzbdh(num, num3, num2 - num, num4 - num3);
	}

	public void z0tek(z0ZzZzpdh p0)
	{
		z0zek += p0.z0rek();
		z0lrk += p0.z0tek();
	}

	public void z0tek(float p0, float p1)
	{
		z0zek += p0;
		z0lrk += p1;
	}

	public z0ZzZzndh z0vek()
	{
		int num = (int)z0zek;
		int num2 = (int)z0lrk;
		return new z0ZzZzndh(num, num2, (int)(z0zek + z0krk - (float)num), (int)(z0lrk + z0jrk - (float)num2));
	}

	public z0ZzZzndh z0cek()
	{
		int num = (int)Math.Ceiling(z0zek);
		int num2 = (int)Math.Ceiling(z0lrk);
		return new z0ZzZzndh(num, num2, (int)Math.Ceiling(z0zek + z0krk) - num, (int)Math.Ceiling(z0lrk + z0jrk) - num2);
	}

	public override readonly string ToString()
	{
		return $"{{X={z0tek()},Y={z0yek()},Width={z0uek()},Height={z0iek()}}}";
	}
}
