namespace zzz;

internal abstract class z0ZzZzmwj : z0ZzZzfsj
{
	private readonly bool z0yek;

	private readonly z0ZzZznaj z0iek;

	private readonly z0ZzZzmaj z0oek;

	private readonly z0ZzZziwj z0mek;

	private readonly zzz.z0ZzZzasj<z0ZzZzlqj> z0nek;

	protected virtual z0ZzZzeaj z0pfk(z0ZzZzdsj p0)
	{
		z0ZzZzeaj z0ZzZzeaj2 = new z0ZzZzeaj(p0);
		z0ZzZzeaj2.Add("ShadingType", z0ofk());
		z0ZzZzeaj2.Add("ColorSpace", z0iek.z0qfk(p0));
		if (z0oek != null)
		{
			z0ZzZzeaj2.Add("Background", z0oek.z0eek());
		}
		z0ZzZzeaj2.z0tek_jiejie20260327142557("BBox", z0mek);
		z0ZzZzeaj2.z0tek_jiejie20260327142557("AntiAlias", z0yek, false);
		if (z0nek != null)
		{
			z0ZzZzeaj2.z0tek_jiejie20260327142557("Function", (z0nek.Count == 1) ? ((z0ZzZzfsj)z0nek[0]) : ((z0ZzZzfsj)z0nek));
		}
		return z0ZzZzeaj2;
	}

	protected z0ZzZzmwj(zzz.z0ZzZzasj<z0ZzZzlqj> p0)
	{
		z0nek = p0;
		z0iek = new z0ZzZzjqj((z0ZzZzhqj)1);
	}

	protected internal override object z0ngk(z0ZzZzdsj p0)
	{
		return z0pfk(p0);
	}

	protected abstract int z0ofk();
}
