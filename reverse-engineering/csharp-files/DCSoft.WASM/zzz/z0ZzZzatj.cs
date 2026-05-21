namespace zzz;

internal class z0ZzZzatj : z0ZzZzftj
{
	private z0ZzZzqtj z0yek;

	public new z0ZzZzdtj z0eek()
	{
		foreach (z0ZzZzftj item in z0uek())
		{
			if (item is z0ZzZzdtj)
			{
				z0ZzZzdtj z0ZzZzdtj2 = (z0ZzZzdtj)item;
				if (z0ZzZzdtj2.z0eek() == "fldrslt")
				{
					return z0ZzZzdtj2;
				}
			}
		}
		return null;
	}

	public void z0eek(z0ZzZzqtj p0)
	{
		z0yek = p0;
	}

	public new z0ZzZzqtj z0rek()
	{
		return z0yek;
	}

	public new string z0tek()
	{
		foreach (z0ZzZzftj item in z0uek())
		{
			if (item is z0ZzZzdtj)
			{
				z0ZzZzdtj z0ZzZzdtj2 = (z0ZzZzdtj)item;
				if (z0ZzZzdtj2.z0eek() == "fldinst")
				{
					return z0ZzZzdtj2.z0bjk();
				}
			}
		}
		return null;
	}
}
