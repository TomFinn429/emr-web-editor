namespace zzz;

internal abstract class z0ZzZzpqj : z0ZzZzmwj
{
	private readonly bool z0tek;

	private readonly bool z0uek;

	private readonly z0ZzZzuwj z0iek;

	protected override z0ZzZzeaj z0pfk(z0ZzZzdsj p0)
	{
		z0ZzZzeaj z0ZzZzeaj2 = base.z0pfk(p0);
		if (z0iek.z0tek() != 0.0 || z0iek.z0rek() != 1.0)
		{
			z0ZzZzeaj2.Add("Domain", new object[2]
			{
				z0iek.z0tek(),
				z0iek.z0rek()
			});
		}
		if (z0uek || z0tek)
		{
			z0ZzZzeaj2.Add("Extend", new object[2] { z0uek, z0tek });
		}
		return z0ZzZzeaj2;
	}

	protected z0ZzZzpqj(zzz.z0ZzZzasj<z0ZzZzlqj> p0)
		: base(p0)
	{
		z0iek = new z0ZzZzuwj(0.0, 1.0);
	}
}
