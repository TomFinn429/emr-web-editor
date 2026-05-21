using System;
using System.Collections;

namespace zzz;

internal sealed class z0ZzZzlij
{
	private ArrayList z0rek;

	private z0ZzZzxuj z0tek;

	public void z0eek(int[] p0, int p1)
	{
		if (p1 == 0)
		{
			throw new ArgumentException("No error correction bytes");
		}
		int num = p0.Length - p1;
		if (num <= 0)
		{
			throw new ArgumentException("No data bytes provided");
		}
		z0ZzZzzuj p2 = z0eek(p1);
		int[] array = new int[num];
		Array.Copy(p0, 0, array, 0, num);
		int[] array2 = new z0ZzZzzuj(z0tek, array).z0eek(p1, 1).z0tek(p2)[1].z0tek();
		int num2 = p1 - array2.Length;
		for (int i = 0; i < num2; i++)
		{
			p0[num + i] = 0;
		}
		Array.Copy(array2, 0, p0, num + num2, array2.Length);
	}

	public z0ZzZzlij(z0ZzZzxuj p0)
	{
		if (!z0ZzZzxuj.z0pek.Equals(p0))
		{
			throw new ArgumentException("Only QR Code is supported at this time");
		}
		z0tek = p0;
		z0rek = ArrayList.Synchronized(new ArrayList(10));
		z0rek.Add(new z0ZzZzzuj(p0, new int[1] { 1 }));
	}

	private z0ZzZzzuj z0eek(int p0)
	{
		if (p0 >= z0rek.Count)
		{
			z0ZzZzzuj z0ZzZzzuj2 = (z0ZzZzzuj)z0rek[z0rek.Count - 1];
			for (int i = z0rek.Count; i <= p0; i++)
			{
				z0ZzZzzuj z0ZzZzzuj3 = z0ZzZzzuj2.z0rek(new z0ZzZzzuj(z0tek, new int[2]
				{
					1,
					z0tek.z0eek(i - 1)
				}));
				z0rek.Add(z0ZzZzzuj3);
				z0ZzZzzuj2 = z0ZzZzzuj3;
			}
		}
		return (z0ZzZzzuj)z0rek[p0];
	}
}
