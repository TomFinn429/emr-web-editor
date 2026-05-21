namespace zzz;

public class z0ZzZztij
{
	public static int z0eek(int p0, int p1)
	{
		if (p0 >= 0)
		{
			return p0 >> p1;
		}
		return (p0 >> p1) + (2 << ~p1);
	}

	public static long z0eek(long p0)
	{
		return p0;
	}

	public static sbyte[] z0eek(byte[] p0)
	{
		sbyte[] array = null;
		if (p0 != null)
		{
			array = new sbyte[p0.Length];
			for (int i = 0; i < p0.Length; i++)
			{
				array[i] = (sbyte)p0[i];
			}
		}
		return array;
	}
}
