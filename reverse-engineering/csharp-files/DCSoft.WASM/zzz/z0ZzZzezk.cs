namespace zzz;

internal class z0ZzZzezk : z0ZzZzrjj
{
	private readonly double z0eek;

	protected override double z0pak()
	{
		return z0eek;
	}

	protected override z0ZzZzywj[] z0ysk(double p0)
	{
		double p1 = p0 * 1.7;
		return new z0ZzZzywj[3]
		{
			new z0ZzZzywj(0.0, 0.0),
			new z0ZzZzywj(p1, p0),
			new z0ZzZzywj(p1, 0.0 - p0)
		};
	}

	internal z0ZzZzezk(double p0)
		: base(p0)
	{
		z0eek = p0 * 1.6;
	}
}
