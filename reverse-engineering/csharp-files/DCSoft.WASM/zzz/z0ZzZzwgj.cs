namespace zzz;

internal class z0ZzZzwgj : z0ZzZzpaj
{
	protected internal override bool z0gsk(bool p0)
	{
		return true;
	}

	protected internal override void z0hsk(z0ZzZzfsj p0)
	{
		base.z0hsk(p0);
		z0eek(p0 as z0ZzZzwgj);
	}

	private void z0eek(z0ZzZzwgj p0)
	{
		if (p0 != null)
		{
			p0.z0eek(((z0ZzZzrqj)this).z0eek());
			byte[] array = z0eek();
			byte[] array2 = p0.z0eek();
			if (array2 == null || array2.Length != array.Length)
			{
				p0.z0eek(array);
			}
			p0.z0eek(z0tek());
		}
	}

	protected internal override z0ZzZzfsj z0jsk(z0ZzZzdsj p0, bool p1)
	{
		if (p1)
		{
			z0ZzZzwgj z0ZzZzwgj2 = new z0ZzZzwgj(((z0ZzZzrqj)this).z0rek(), (z0ZzZzvaj)z0yek());
			int p2 = p0.z0uek() + 1;
			p0.z0uek(p2);
			z0ZzZzwgj2.z0eek(p2);
			z0eek(z0ZzZzwgj2);
			return z0ZzZzwgj2;
		}
		return this;
	}

	internal z0ZzZzwgj(string p0, z0ZzZzvaj p1)
		: base(p0, p1)
	{
	}
}
