using System;

namespace zzz;

internal sealed class z0ZzZzxuj
{
	private int[] z0yek;

	private z0ZzZzzuj z0uek;

	private z0ZzZzzuj z0iek;

	private int[] z0oek;

	public static readonly z0ZzZzxuj z0pek = new z0ZzZzxuj(285);

	private z0ZzZzxuj(int p0)
	{
		z0oek = new int[256];
		z0yek = new int[256];
		int num = 1;
		for (int i = 0; i < 256; i++)
		{
			z0oek[i] = num;
			num <<= 1;
			if (num >= 256)
			{
				num ^= p0;
			}
		}
		for (int j = 0; j < 255; j++)
		{
			z0yek[z0oek[j]] = j;
		}
		z0iek = new z0ZzZzzuj(this, new int[1]);
		z0uek = new z0ZzZzzuj(this, new int[1] { 1 });
	}

	internal int z0eek(int p0)
	{
		return z0oek[p0];
	}

	internal int z0eek(int p0, int p1)
	{
		if (p0 == 0 || p1 == 0)
		{
			return 0;
		}
		if (p0 == 1)
		{
			return p1;
		}
		if (p1 == 1)
		{
			return p0;
		}
		return z0oek[(z0yek[p0] + z0yek[p1]) % 255];
	}

	internal int z0rek(int p0)
	{
		if (p0 == 0)
		{
			throw new ArgumentException();
		}
		return z0yek[p0];
	}

	internal int z0tek(int p0)
	{
		if (p0 == 0)
		{
			throw new ArithmeticException();
		}
		return z0oek[255 - z0yek[p0]];
	}

	internal static int z0rek(int p0, int p1)
	{
		return p0 ^ p1;
	}

	internal z0ZzZzzuj z0tek(int p0, int p1)
	{
		if (p0 < 0)
		{
			throw new ArgumentException();
		}
		if (p1 == 0)
		{
			return z0iek;
		}
		int[] array = new int[p0 + 1];
		array[0] = p1;
		return new z0ZzZzzuj(this, array);
	}

	internal z0ZzZzzuj z0eek()
	{
		return z0iek;
	}
}
