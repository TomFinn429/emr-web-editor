using System;

namespace zzz;

internal sealed class z0ZzZzssh : z0ZzZzrsh
{
	private int z0tek;

	private int z0yek;

	private byte[] z0uek;

	private int z0iek;

	private static readonly byte[] z0pek = z0rek();

	private int z0mek_jiejie20260327142557;

	private int z0vek;

	private void z0eek(ReadOnlySpan<char> p0, Span<byte> p1, out int p2, out int p3)
	{
		int num = 0;
		int num2 = 0;
		int num3 = z0iek;
		int num4 = z0yek;
		while (true)
		{
			if ((uint)num2 < (uint)p0.Length && (uint)num < (uint)p1.Length)
			{
				char c = p0[num2];
				if (c != '=')
				{
					num2++;
					if (z0ZzZzzsh.z0iek(c))
					{
						continue;
					}
					int num5;
					if (c > 'z' || (num5 = z0pek[(uint)c]) == 255)
					{
						throw new z0ZzZzeah();
					}
					num3 = (num3 << 6) | num5;
					num4 += 6;
					if (num4 >= 8)
					{
						p1[num++] = (byte)((num3 >> num4 - 8) & 0xFF);
						num4 -= 8;
						if (num == p1.Length)
						{
							break;
						}
					}
					continue;
				}
			}
			if ((uint)num2 >= (uint)p0.Length || p0[num2] != '=')
			{
				break;
			}
			num4 = 0;
			do
			{
				num2++;
			}
			while ((uint)num2 < (uint)p0.Length && p0[num2] == '=');
			while ((uint)num2 < (uint)p0.Length)
			{
				if (!z0ZzZzzsh.z0iek(p0[num2++]))
				{
					throw new z0ZzZzeah();
				}
			}
			break;
		}
		z0iek = num3;
		z0yek = num4;
		p3 = num;
		p2 = num2;
	}

	private static byte[] z0rek()
	{
		byte[] array = new byte[123];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = 255;
		}
		for (int j = 0; j < "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/".Length; j++)
		{
			array[(uint)"ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/"[j]] = (byte)j;
		}
		return array;
	}

	internal override void z0ld(Array p0, int p1, int p2)
	{
		z0uek = (byte[])p0;
		z0mek_jiejie20260327142557 = p1;
		z0vek = p1;
		z0tek = p1 + p2;
	}

	internal override int z0zf()
	{
		return z0vek - z0mek_jiejie20260327142557;
	}

	internal override void z0xf()
	{
		z0yek = 0;
		z0iek = 0;
	}

	internal override int z0cf(string p0, int p1, int p2)
	{
		ArgumentNullException.ThrowIfNull(p0, "str");
		if (p2 < 0)
		{
			throw new ArgumentOutOfRangeException("len");
		}
		if (p1 < 0)
		{
			throw new ArgumentOutOfRangeException("startPos");
		}
		if (p0.Length - p1 < p2)
		{
			throw new ArgumentOutOfRangeException("len");
		}
		if (p2 == 0)
		{
			return 0;
		}
		z0eek(p0.AsSpan(p1, p2), z0uek.AsSpan(z0vek, z0tek - z0vek), out var p3, out var p4);
		z0vek += p4;
		return p3;
	}

	internal override int z0vf(char[] p0, int p1, int p2)
	{
		ArgumentNullException.ThrowIfNull(p0, "chars");
		if (p2 < 0)
		{
			throw new ArgumentOutOfRangeException("len");
		}
		if (p1 < 0)
		{
			throw new ArgumentOutOfRangeException("startPos");
		}
		if (p0.Length - p1 < p2)
		{
			throw new ArgumentOutOfRangeException("len");
		}
		if (p2 == 0)
		{
			return 0;
		}
		z0eek(p0.AsSpan(p1, p2), z0uek.AsSpan(z0vek, z0tek - z0vek), out var p3, out var p4);
		z0vek += p4;
		return p3;
	}

	internal override bool z0bf()
	{
		return z0vek == z0tek;
	}
}
