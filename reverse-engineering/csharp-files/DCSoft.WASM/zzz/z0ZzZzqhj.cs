namespace zzz;

internal class z0ZzZzqhj : z0ZzZzrjj
{
	protected override z0ZzZzywj[] z0ysk(double p0)
	{
		double num = p0 / 2.0;
		double p1 = 0.1 * p0;
		return new z0ZzZzywj[5]
		{
			new z0ZzZzywj(p1, num),
			new z0ZzZzywj(p1, 0.0 - num),
			new z0ZzZzywj(0.0, 0.0 - num),
			new z0ZzZzywj(0.0 - num, 0.0),
			new z0ZzZzywj(0.0, num)
		};
	}

	internal z0ZzZzqhj(double p0)
		: base(p0)
	{
	}
}
