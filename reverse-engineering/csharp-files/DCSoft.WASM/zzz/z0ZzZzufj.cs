namespace zzz;

internal class z0ZzZzufj : z0ZzZzsfj
{
	private new readonly int z0eek;

	private new readonly short[] z0rek;

	private new readonly int z0tek;

	internal override int z0adk()
	{
		return 20 + z0rek.Length * 2;
	}

	internal override void z0wdk(z0ZzZzjgj p0)
	{
		base.z0wdk(p0);
		p0.z0oek(z0eek);
		p0.z0oek(z0tek);
		p0.z0eek(z0rek);
	}

	internal z0ZzZzufj(z0ZzZzudj p0, z0ZzZzxfj p1, z0ZzZzjgj p2)
		: base(p0, p1, p2)
	{
		z0eek = p2.z0nek();
		z0tek = p2.z0nek();
		z0rek = p2.z0uek(z0tek);
	}

	protected override z0ZzZzhfj z0sdk()
	{
		return (z0ZzZzhfj)10;
	}
}
