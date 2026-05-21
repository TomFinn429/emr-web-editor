namespace zzz;

internal class z0ZzZzqfj : z0ZzZzsfj
{
	private new readonly z0ZzZzgfj[] z0rek;

	private new readonly byte[] z0tek;

	internal override void z0wdk(z0ZzZzjgj p0)
	{
		base.z0wdk(p0);
		p0.z0eek(z0tek);
		p0.z0oek(z0rek.Length);
		z0ZzZzgfj.z0eek(z0rek, p0);
	}

	internal override int z0adk()
	{
		return 8208 + z0rek.Length * 12;
	}

	internal z0ZzZzqfj(z0ZzZzudj p0, z0ZzZzxfj p1, z0ZzZzjgj p2)
		: base(p0, p1, p2)
	{
		z0tek = p2.z0yek(8192);
		z0rek = z0ZzZzgfj.z0eek(p2, p2.z0nek());
	}

	protected override z0ZzZzhfj z0sdk()
	{
		return (z0ZzZzhfj)8;
	}
}
