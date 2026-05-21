using System;
using System.Diagnostics;

namespace zzz;

[DebuggerDisplay("Size:Width={Width},Height={Height}")]
public struct z0ZzZzcdh : IEquatable<z0ZzZzcdh>
{
	public static readonly z0ZzZzcdh z0yek_jiejie20260327142557;

	private int z0uek;

	private int z0iek;

	public z0ZzZzcdh(int p0, int p1)
	{
		z0uek = p0;
		z0iek = p1;
	}

	public static bool z0eek(z0ZzZzcdh p0, z0ZzZzcdh p1)
	{
		if (p0.z0uek == p1.z0uek)
		{
			return p0.z0iek == p1.z0iek;
		}
		return false;
	}

	public static bool z0rek(z0ZzZzcdh p0, z0ZzZzcdh p1)
	{
		return !z0eek(p0, p1);
	}

	public readonly bool z0eek()
	{
		if (z0uek == 0)
		{
			return z0iek == 0;
		}
		return false;
	}

	public readonly int z0rek()
	{
		return z0uek;
	}

	public void z0eek(int p0)
	{
		z0uek = p0;
	}

	public readonly int z0tek()
	{
		return z0iek;
	}

	public void z0rek(int p0)
	{
		z0iek = p0;
	}

	public override readonly bool Equals(object obj)
	{
		if (obj is z0ZzZzcdh)
		{
			return Equals((z0ZzZzcdh)obj);
		}
		return false;
	}

	public readonly bool Equals(z0ZzZzcdh other)
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
