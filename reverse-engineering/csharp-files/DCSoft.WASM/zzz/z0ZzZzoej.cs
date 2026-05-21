using System.IO;

namespace zzz;

internal class z0ZzZzoej
{
	private uint z0rek;

	private uint z0yek = 1u;

	internal void z0eek(Stream p0)
	{
		z0eek();
		p0.WriteByte((byte)((z0rek & 0xFF00) >> 8));
		p0.WriteByte((byte)(z0rek & 0xFF));
		p0.WriteByte((byte)((z0yek & 0xFF00) >> 8));
		p0.WriteByte((byte)(z0yek & 0xFF));
	}

	internal void z0eek(byte[] p0)
	{
		z0eek(p0, 0, p0.Length);
	}

	private void z0eek()
	{
		z0rek %= 65521u;
		z0yek %= 65521u;
	}

	internal void z0eek(byte[] p0, int p1, int p2)
	{
		int num = p2;
		int num2 = p1;
		while (num > 0)
		{
			z0eek();
			int num3 = ((num < 5550) ? num : 5550);
			num -= num3;
			while (num3 >= 16)
			{
				z0yek += p0[num2++];
				z0rek += z0yek;
				z0yek += p0[num2++];
				z0rek += z0yek;
				z0yek += p0[num2++];
				z0rek += z0yek;
				z0yek += p0[num2++];
				z0rek += z0yek;
				z0yek += p0[num2++];
				z0rek += z0yek;
				z0yek += p0[num2++];
				z0rek += z0yek;
				z0yek += p0[num2++];
				z0rek += z0yek;
				z0yek += p0[num2++];
				z0rek += z0yek;
				z0yek += p0[num2++];
				z0rek += z0yek;
				z0yek += p0[num2++];
				z0rek += z0yek;
				z0yek += p0[num2++];
				z0rek += z0yek;
				z0yek += p0[num2++];
				z0rek += z0yek;
				z0yek += p0[num2++];
				z0rek += z0yek;
				z0yek += p0[num2++];
				z0rek += z0yek;
				z0yek += p0[num2++];
				z0rek += z0yek;
				z0yek += p0[num2++];
				z0rek += z0yek;
				num3 -= 16;
			}
			if (num3 != 0)
			{
				do
				{
					z0yek += p0[num2++];
					z0rek += z0yek;
				}
				while (--num3 != 0);
			}
		}
	}
}
