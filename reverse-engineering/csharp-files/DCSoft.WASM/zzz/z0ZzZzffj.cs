using System;
using System.Collections.Generic;

namespace zzz;

internal class z0ZzZzffj : z0ZzZztfj
{
	private new readonly short[] z0tek;

	private readonly z0ZzZzdfj[] z0yek;

	private readonly short[] z0uek;

	internal z0ZzZzffj(z0ZzZzudj p0, z0ZzZzxfj p1, z0ZzZzjgj p2)
		: base(p0, p1, p2)
	{
		z0tek = p2.z0uek(256);
		int count = new HashSet<short>(z0tek).Count;
		z0yek = new z0ZzZzdfj[count];
		int p3 = (int)p2.z0uek() + count * 8;
		int num = count * 8 - 6;
		z0ZzZzdfj z0ZzZzdfj2 = z0eek(p2, p3);
		int num2 = z0ZzZzdfj2.z0eek(num);
		z0yek[0] = z0ZzZzdfj2;
		num -= 8;
		int num3 = 1;
		while (num3 < count)
		{
			z0ZzZzdfj z0ZzZzdfj3 = z0eek(p2, p3);
			z0yek[num3] = z0ZzZzdfj3;
			num2 = Math.Max(num2, z0ZzZzdfj3.z0eek(num));
			num3++;
			num -= 8;
		}
		z0uek = p2.z0uek(num2);
	}

	protected override z0ZzZzhfj z0sdk()
	{
		return (z0ZzZzhfj)2;
	}

	private z0ZzZzdfj z0eek(z0ZzZzjgj p0, int p1)
	{
		short p2 = p0.z0yek();
		short p3 = p0.z0yek();
		short p4 = p0.z0yek();
		int num = (int)p0.z0uek();
		short num2 = p0.z0yek();
		return new z0ZzZzdfj(p2, p3, p4, num2, (num2 - (p1 - num)) / 2);
	}

	internal override int z0adk()
	{
		return 518 + 8 * z0yek.Length + z0uek.Length * 2;
	}

	internal override int z0qdk(int p0)
	{
		byte b = (byte)(p0 >> 8);
		byte num = (byte)(p0 & 0xFF);
		z0ZzZzdfj z0ZzZzdfj2 = z0yek[z0tek[b] / 8];
		int num2 = num - z0ZzZzdfj2.z0yek();
		if (num2 < 0 || num2 >= z0ZzZzdfj2.z0eek())
		{
			return 0;
		}
		num2 += z0ZzZzdfj2.z0tek();
		if (num2 < 0 || num2 >= z0uek.Length)
		{
			return 0;
		}
		int num3 = (ushort)z0uek[num2];
		if (num3 != 0)
		{
			return (num3 + z0ZzZzdfj2.z0uek()) % 65536;
		}
		return num3;
	}

	internal override void z0wdk(z0ZzZzjgj p0)
	{
		base.z0wdk(p0);
		p0.z0eek(z0tek);
		z0ZzZzdfj[] array = z0yek;
		foreach (z0ZzZzdfj z0ZzZzdfj2 in array)
		{
			p0.z0eek(z0ZzZzdfj2.z0yek());
			p0.z0eek(z0ZzZzdfj2.z0eek());
			p0.z0eek(z0ZzZzdfj2.z0uek());
			p0.z0eek(z0ZzZzdfj2.z0rek());
		}
		p0.z0eek(z0uek);
	}
}
