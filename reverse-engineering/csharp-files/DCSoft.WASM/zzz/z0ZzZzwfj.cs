namespace zzz;

internal abstract class z0ZzZzwfj : z0ZzZzsfj
{
	private new readonly z0ZzZzgfj[] z0eek;

	internal override int z0adk()
	{
		return 16 + z0eek.Length * 12;
	}

	internal override int z0qdk(int p0)
	{
		if (z0eek != null && z0eek.Length != 0)
		{
			z0ZzZzgfj[] array = z0eek;
			foreach (z0ZzZzgfj z0ZzZzgfj2 in array)
			{
				if (z0ZzZzgfj2.z0rek() <= p0 && p0 <= z0ZzZzgfj2.z0tek())
				{
					return z0ZzZzgfj2.z0eek();
				}
			}
		}
		return 0;
	}

	internal override void z0wdk(z0ZzZzjgj p0)
	{
		base.z0wdk(p0);
		p0.z0oek(z0eek.Length);
		z0ZzZzgfj.z0eek(z0eek, p0);
	}

	protected z0ZzZzwfj(z0ZzZzudj p0, z0ZzZzxfj p1, z0ZzZzjgj p2)
		: base(p0, p1, p2)
	{
		z0eek = z0ZzZzgfj.z0eek(p2, p2.z0nek());
	}
}
