using System;
using System.Diagnostics;

namespace zzz;

[DebuggerDisplay("SizeF:Width={Width},Height={Height}")]
public struct z0ZzZzxdh : IEquatable<z0ZzZzxdh>
{
	public static readonly z0ZzZzxdh z0yek;

	private float z0uek;

	private float z0iek;

	public z0ZzZzxdh(float p0, float p1)
	{
		z0uek = p0;
		z0iek = p1;
	}

	public static bool z0eek(z0ZzZzxdh p0, z0ZzZzxdh p1)
	{
		if (p0.z0uek == p1.z0uek)
		{
			return p0.z0iek == p1.z0iek;
		}
		return false;
	}

	public static bool z0rek(z0ZzZzxdh p0, z0ZzZzxdh p1)
	{
		return !z0eek(p0, p1);
	}

	public readonly bool z0eek()
	{
		if (z0uek == 0f)
		{
			return z0iek == 0f;
		}
		return false;
	}

	public readonly float z0rek()
	{
		return z0uek;
	}

	public void z0eek(float p0)
	{
		z0uek = p0;
	}

	public readonly float z0tek()
	{
		return z0iek;
	}

	public void z0rek(float p0)
	{
		z0iek = p0;
	}

	public override readonly bool Equals(object obj)
	{
		if (obj is z0ZzZzxdh)
		{
			return Equals((z0ZzZzxdh)obj);
		}
		return false;
	}

	public readonly bool Equals(z0ZzZzxdh other)
	{
		return z0eek(this, other);
	}

	public override readonly int GetHashCode()
	{
		return HashCode.Combine(z0uek, z0iek);
	}

	public override readonly string ToString()
	{
		return $"{{Width={z0uek}, Height={z0iek}}}";
	}
}
