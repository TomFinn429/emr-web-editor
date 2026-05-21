namespace zzz;

internal sealed class z0ZzZznuj
{
	private int z0rek;

	private sbyte[] z0tek;

	public void z0eek(sbyte[] p0, int p1, int p2)
	{
		z0tek = new sbyte[p2];
		z0rek = p2;
		for (int i = 0; i < p2; i++)
		{
			z0tek[i] = p0[p1 + i];
		}
	}

	public int z0eek(int p0)
	{
		return z0tek[p0] & 0xFF;
	}

	public void z0eek(int p0, int p1)
	{
		z0tek[p0] = (sbyte)p1;
	}

	public int z0eek()
	{
		return z0rek;
	}

	public z0ZzZznuj(int p0)
	{
		z0tek = new sbyte[p0];
		z0rek = p0;
	}

	public z0ZzZznuj()
	{
		z0tek = null;
		z0rek = 0;
	}
}
