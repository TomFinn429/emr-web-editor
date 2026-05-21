using System.Collections;

namespace zzz;

internal sealed class z0ZzZzkah : z0ZzZzpah
{
	private new readonly z0ZzZzoah z0eek;

	public z0ZzZzkah(z0ZzZzoah p0)
	{
		z0eek = p0;
	}

	public override IEnumerator GetEnumerator()
	{
		if (z0eek.z0iek() == null)
		{
			return z0ZzZzfah.z0btk;
		}
		return new z0ZzZzlah(z0eek);
	}

	public override int z0sf()
	{
		int num = 0;
		for (z0ZzZzoah z0ZzZzoah2 = z0eek.z0iek(); z0ZzZzoah2 != null; z0ZzZzoah2 = z0ZzZzoah2.z0qf())
		{
			num++;
		}
		return num;
	}

	public override z0ZzZzoah z0df(int p0)
	{
		if (p0 < 0)
		{
			return null;
		}
		z0ZzZzoah z0ZzZzoah2 = z0eek.z0iek();
		while (z0ZzZzoah2 != null)
		{
			if (p0 == 0)
			{
				return z0ZzZzoah2;
			}
			z0ZzZzoah2 = z0ZzZzoah2.z0qf();
			p0--;
		}
		return null;
	}
}
