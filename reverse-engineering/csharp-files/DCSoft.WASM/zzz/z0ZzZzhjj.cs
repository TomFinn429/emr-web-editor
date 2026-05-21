namespace zzz;

internal class z0ZzZzhjj : z0ZzZzwjj
{
	private new static int[] z0eek = new int[8] { 0, 0, 0, 1, 0, 4, 0, 1 };

	private static int[] z0rek = new int[8] { 4, 0, 4, 4, 4, 0, 4, 4 };

	protected override void z0msk(z0ZzZzsgj p0)
	{
		base.z0msk(p0);
		double num = z0eek();
		for (int i = 1; i < 6; i += 2)
		{
			p0.z0oek(new z0ZzZziwj(num, (double)i * num, num * 2.0, (double)(i + 1) * num));
			double num2 = 5.0 * z0isk() / 8.0;
			double num3 = (double)((i + 4) % 8) * num;
			p0.z0oek(new z0ZzZziwj(num2, num3, num2 + num, num3 + num));
		}
	}

	internal z0ZzZzhjj(z0ZzZzsxk p0)
		: base(p0, z0rek, z0eek)
	{
	}
}
