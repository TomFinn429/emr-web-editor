using System;

namespace zzz;

internal abstract class z0ZzZzrwj : z0ZzZzfsj
{
	private readonly z0ZzZzjej z0tek;

	protected virtual z0ZzZzeaj z0vgk(z0ZzZzdsj p0)
	{
		z0ZzZzeaj z0ZzZzeaj2 = new z0ZzZzeaj(p0);
		z0ZzZzeaj2.Add("PatternType", z0bgk());
		if (!z0tek.z0tek())
		{
			z0ZzZzeaj2.Add("Matrix", z0tek.z0bek());
		}
		return z0ZzZzeaj2;
	}

	protected abstract int z0bgk();

	protected z0ZzZzrwj(z0ZzZzjej p0)
	{
		z0tek = p0;
	}

	internal static z0ZzZzrwj z0eek(object p0)
	{
		throw new NotSupportedException();
	}
}
