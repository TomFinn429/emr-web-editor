using System;
using System.Text;

namespace zzz;

internal sealed class z0ZzZzdij
{
	private sbyte[] z0uek;

	private int z0iek;

	public int z0eek()
	{
		return z0iek + 7 >> 3;
	}

	public int z0eek(int p0)
	{
		if (p0 < 0 || p0 >= z0iek)
		{
			throw new ArgumentException("Bad index: " + p0);
		}
		return ((z0uek[p0 >> 3] & 0xFF) >> 7 - (p0 & 7)) & 1;
	}

	private void z0rek(int p0)
	{
		if (z0iek >> 3 == z0uek.Length)
		{
			sbyte[] array = new sbyte[z0uek.Length << 1];
			Array.Copy(z0uek, 0, array, 0, z0uek.Length);
			z0uek = array;
		}
		z0uek[z0iek >> 3] = (sbyte)p0;
		z0iek += 8;
	}

	public void z0tek(int p0)
	{
		if (p0 != 0 && p0 != 1)
		{
			throw new ArgumentException("Bad bit");
		}
		int num = z0iek & 7;
		if (num == 0)
		{
			z0rek(0);
			z0iek -= 8;
		}
		z0uek[z0iek >> 3] |= (sbyte)(p0 << 7 - num);
		z0iek++;
	}

	public void z0eek(z0ZzZzdij p0)
	{
		if (z0iek != p0.z0tek())
		{
			throw new ArgumentException("BitVector sizes don't match");
		}
		int num = z0iek + 7 >> 3;
		for (int i = 0; i < num; i++)
		{
			z0uek[i] ^= p0.z0uek[i];
		}
	}

	public void z0eek(int p0, int p1)
	{
		if (p1 < 0 || p1 > 32)
		{
			throw new ArgumentException("Num bits must be between 0 and 32");
		}
		int num = p1;
		while (num > 0)
		{
			if ((z0iek & 7) == 0 && num >= 8)
			{
				int p2 = (p0 >> num - 8) & 0xFF;
				z0rek(p2);
				num -= 8;
			}
			else
			{
				int p3 = (p0 >> num - 1) & 1;
				z0tek(p3);
				num--;
			}
		}
	}

	public void z0rek(z0ZzZzdij p0)
	{
		int num = p0.z0tek();
		for (int i = 0; i < num; i++)
		{
			z0tek(p0.z0eek(i));
		}
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder(z0iek);
		for (int i = 0; i < z0iek; i++)
		{
			if (z0eek(i) == 0)
			{
				stringBuilder.Append('0');
				continue;
			}
			if (z0eek(i) == 1)
			{
				stringBuilder.Append('1');
				continue;
			}
			throw new ArgumentException("Byte isn't 0 or 1");
		}
		return stringBuilder.ToString();
	}

	public sbyte[] z0rek()
	{
		return z0uek;
	}

	public z0ZzZzdij()
	{
		z0iek = 0;
		z0uek = new sbyte[32];
	}

	public int z0tek()
	{
		return z0iek;
	}
}
