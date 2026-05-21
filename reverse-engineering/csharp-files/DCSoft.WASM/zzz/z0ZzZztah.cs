namespace zzz;

public abstract class z0ZzZztah : z0ZzZzoah
{
	internal new z0ZzZztah z0eek;

	public override z0ZzZzoah? z0qf()
	{
		z0ZzZzoah z0ZzZzoah2 = z0ih();
		if (z0ZzZzoah2 != null && z0eek != z0ZzZzoah2.z0iek())
		{
			return z0eek;
		}
		return null;
	}

	internal z0ZzZztah(z0ZzZzfah p0)
		: base(p0)
	{
		z0eek = null;
	}

	public override z0ZzZzoah z0af()
	{
		z0ZzZzoah z0ZzZzoah2 = z0ih();
		if (z0ZzZzoah2 != null)
		{
			z0ZzZzoah z0ZzZzoah3 = z0ZzZzoah2.z0iek();
			while (z0ZzZzoah3 != null)
			{
				z0ZzZzoah z0ZzZzoah4 = z0ZzZzoah3.z0qf();
				if (z0ZzZzoah4 == this)
				{
					break;
				}
				z0ZzZzoah3 = z0ZzZzoah4;
			}
			return z0ZzZzoah3;
		}
		return null;
	}
}
