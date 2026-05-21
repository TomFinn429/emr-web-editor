using System;

namespace zzz;

internal class z0ZzZzmaj
{
	private readonly double[] z0yek;

	private readonly z0ZzZzrwj z0uek;

	internal z0ZzZzmaj(z0ZzZzrwj p0, params double[] p1)
	{
		if (p0 == null && p1.Length == 0)
		{
			throw new ArgumentOutOfRangeException("components", "ZeroColorComponentsCount");
		}
		z0uek = p0;
		z0yek = p1;
	}

	internal object z0eek()
	{
		return new z0ZzZzqaj(z0yek);
	}

	internal z0ZzZzmaj(params double[] p0)
		: this(null, p0)
	{
	}

	internal double[] z0rek()
	{
		return z0yek;
	}

	internal z0ZzZzrwj z0tek()
	{
		return z0uek;
	}
}
