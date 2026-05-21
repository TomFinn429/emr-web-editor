namespace zzz;

internal class z0ZzZztwj : z0ZzZzzaj
{
	private new readonly z0ZzZznaj z0eek;

	internal z0ZzZztwj()
		: this(new z0ZzZzjqj((z0ZzZzhqj)1))
	{
	}

	protected internal override object z0ngk(z0ZzZzdsj p0)
	{
		z0ZzZzhwj z0ZzZzhwj2 = new z0ZzZzhwj("Pattern");
		return new object[2]
		{
			z0ZzZzhwj2,
			z0eek.z0qfk(p0)
		};
	}

	internal override int z0afk()
	{
		return z0eek.z0afk();
	}

	internal z0ZzZztwj(z0ZzZznaj p0)
	{
		z0eek = p0;
	}

	protected internal override object z0qfk(z0ZzZzdsj p0)
	{
		if (!(z0eek is z0ZzZzjqj z0ZzZzjqj2) || z0ZzZzjqj2.z0eek() != (z0ZzZzhqj)1)
		{
			return base.z0qfk(p0);
		}
		return new z0ZzZzhwj("Pattern");
	}
}
