namespace zzz;

internal class z0ZzZzghj : z0ZzZzrjj
{
	protected override z0ZzZzywj[] z0ysk(double p0)
	{
		double num = p0 / 2.0;
		return new z0ZzZzywj[4]
		{
			new z0ZzZzywj(num, 0.0 - num),
			new z0ZzZzywj(0.0 - num, 0.0 - num),
			new z0ZzZzywj(0.0 - num, num),
			new z0ZzZzywj(num, num)
		};
	}

	internal z0ZzZzghj(double p0)
		: base(p0)
	{
	}
}
