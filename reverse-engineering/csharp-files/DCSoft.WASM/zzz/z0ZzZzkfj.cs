namespace zzz;

internal class z0ZzZzkfj : z0ZzZztfj
{
	private new readonly byte[] z0eek;

	internal override int z0qdk(int p0)
	{
		if (p0 < z0eek.Length)
		{
			return z0eek[p0];
		}
		return 0;
	}

	internal z0ZzZzkfj(z0ZzZzudj p0, z0ZzZzxfj p1, z0ZzZzjgj p2)
		: base(p0, p1, p2)
	{
		z0eek = p2.z0yek(z0eek());
	}

	internal override void z0wdk(z0ZzZzjgj p0)
	{
		base.z0wdk(p0);
		p0.z0eek(z0eek);
	}

	protected override z0ZzZzhfj z0sdk()
	{
		return (z0ZzZzhfj)0;
	}
}
