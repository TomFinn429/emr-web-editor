using System;

namespace zzz;

internal class z0ZzZzrfj : z0ZzZztfj
{
	private readonly short[] z0yek;

	private readonly short[] z0uek;

	private readonly int z0iek;

	private readonly short[] z0oek;

	private readonly short[] z0pek;

	private readonly int[] z0mek;

	private readonly short[] z0nek;

	internal override int z0adk()
	{
		return 6 + z0tek() + z0oek.Length * 2;
	}

	internal new short[] z0eek()
	{
		return z0nek;
	}

	internal new short[] z0rek()
	{
		return z0yek;
	}

	private short[] z0eek(z0ZzZzjgj p0)
	{
		short[] array = new short[z0iek];
		p0.z0pek().z0eek(array);
		return array;
	}

	private new int z0tek()
	{
		return 10 + z0iek * 8;
	}

	private int z0eek(int p0, bool p1)
	{
		bool flag = z0eek();
		for (int i = 0; i < z0iek; i++)
		{
			ushort num = (ushort)z0yek[i];
			ushort num2 = (ushort)z0nek[i];
			short num3 = z0pek[i];
			p1 = p1 && flag && num2 >= 61440;
			if (p1)
			{
				num2 -= 61440;
				num -= 61440;
			}
			if (p0 > num)
			{
				continue;
			}
			int num4 = p0 - num2;
			if (num4 < 0)
			{
				continue;
			}
			ushort num5 = (ushort)z0uek[i];
			if (num5 == 0)
			{
				if (p1)
				{
					num3 = (short)(num3 + 61440);
				}
				if (p0 != 0)
				{
					return (p0 + num3) % 65536;
				}
				return p0;
			}
			int num6 = num5 / 2 + num4 + i - z0iek;
			if (num6 < 0 || num6 >= z0oek.Length)
			{
				return 0;
			}
			return (ushort)(z0oek[num6] + num3);
		}
		return 0;
	}

	protected override z0ZzZzhfj z0sdk()
	{
		return (z0ZzZzhfj)4;
	}

	internal int z0eek(int p0, int p1)
	{
		int result = 0;
		short num = z0pek[p1];
		int num2 = p0 - (ushort)z0nek[p1];
		if (num2 >= 0)
		{
			ushort num3 = (ushort)z0uek[p1];
			if (num3 == 0)
			{
				result = ((p0 == 0) ? p0 : ((p0 + num) % 65536));
			}
			else
			{
				int num4 = num3 / 2 + num2 + p1 - z0iek;
				if (num4 >= 0 && num4 < z0oek.Length)
				{
					result = (ushort)z0oek[num4] + num;
				}
			}
		}
		return result;
	}

	internal z0ZzZzrfj(z0ZzZzudj p0, z0ZzZzxfj p1, z0ZzZzjgj p2)
		: base(p0, p1, p2)
	{
		z0iek = p2.z0yek() / 2;
		p2.z0yek();
		p2.z0yek();
		p2.z0yek();
		z0yek = z0eek(p2);
		p2.z0yek();
		z0nek = z0eek(p2);
		z0pek = z0eek(p2);
		z0uek = z0eek(p2);
		int num = (base.z0eek() - z0tek()) / 2;
		if (num < 0)
		{
			num = 0;
		}
		z0oek = new short[num];
		for (int i = 0; i < num; i++)
		{
			z0oek[i] = p2.z0yek();
		}
		z0mek = new int[z0iek];
		int num2 = 0;
		int num3 = 1;
		while (num2 < z0iek)
		{
			z0mek[num2] = (z0uek[num2] - (z0iek - num3) - 2) / 2;
			num2++;
			num3++;
		}
	}

	internal override void z0wdk(z0ZzZzjgj p0)
	{
		base.z0wdk(p0);
		short num = (short)(z0iek * 2);
		p0.z0eek(num);
		short num2 = Convert.ToInt16(2.0 * Math.Pow(2.0, Math.Floor(Math.Log(z0iek, 2.0))));
		p0.z0eek(num2);
		p0.z0eek(Convert.ToInt16(Math.Log(num2 / 2, 2.0)));
		p0.z0eek((short)(num - num2));
		p0.z0eek(z0yek);
		p0.z0eek((short)0);
		p0.z0eek(z0nek);
		p0.z0eek(z0pek);
		p0.z0eek(z0uek);
		p0.z0eek(z0oek);
	}

	internal override int z0qdk(int p0)
	{
		return z0eek(p0, p1: false);
	}
}
