namespace zzz;

internal static class z0ZzZzhaj
{
	internal static z0ZzZzzfj z0eek(byte[] p0, string p1)
	{
		using z0ZzZzjgj z0ZzZzjgj2 = new z0ZzZzjgj(p0);
		z0ZzZzjgj2.z0rek(8);
		long num = (uint)z0ZzZzjgj2.z0nek();
		long[] array = new long[num];
		for (int i = 0; i < num; i++)
		{
			array[i] = (uint)z0ZzZzjgj2.z0nek();
		}
		for (long num2 = 0L; num2 < num; num2++)
		{
			z0ZzZzjgj2.z0eek(array[num2]);
			z0ZzZzzfj z0ZzZzzfj2 = new z0ZzZzzfj(z0ZzZzjgj2);
			if (z0ZzZzzfj2.z0bek() != null && z0ZzZzzfj2.z0bek().z0eek(p1))
			{
				return z0ZzZzzfj2;
			}
			z0ZzZzzfj2.Dispose();
		}
		return null;
	}
}
