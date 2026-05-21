namespace zzz;

internal abstract class z0ZzZzwqj : z0ZzZzaqj
{
	private readonly int z0rek;

	private readonly int z0yek;

	private readonly int z0oek;

	private readonly z0ZzZzeqj z0pek;

	protected internal override z0ZzZzeaj z0efk(z0ZzZzdsj p0)
	{
		z0ZzZzeaj z0ZzZzeaj2 = new z0ZzZzeaj(p0);
		z0ZzZzeaj2.z0tek_jiejie20260327142557("Predictor", (int)z0pek, 1);
		z0ZzZzeaj2.z0tek_jiejie20260327142557("Colors", z0rek, 1);
		z0ZzZzeaj2.z0tek_jiejie20260327142557("BitsPerComponent", z0oek, 8);
		z0ZzZzeaj2.z0tek_jiejie20260327142557("Columns", z0yek, 1);
		if (z0ZzZzeaj2.Count != 0)
		{
			return z0ZzZzeaj2;
		}
		return null;
	}

	internal z0ZzZzwqj(object p0)
	{
		z0pek = (z0ZzZzeqj)1;
		z0rek = 1;
		z0oek = 8;
		z0yek = 1;
	}

	protected z0ZzZzwqj(z0ZzZzeqj p0, int p1, int p2, int p3)
	{
		z0pek = p0;
		z0rek = p1;
		z0oek = p2;
		z0yek = p3;
	}
}
