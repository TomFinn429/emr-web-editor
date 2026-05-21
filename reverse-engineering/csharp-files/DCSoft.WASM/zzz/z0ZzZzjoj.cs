using System;

namespace zzz;

public static class z0ZzZzjoj
{
	private static readonly int[] z0tek = new int[48]
	{
		32, 1, 2, 3, 4, 5, 4, 5, 6, 7,
		8, 9, 8, 9, 10, 11, 12, 13, 12, 13,
		14, 15, 16, 17, 16, 17, 18, 19, 20, 21,
		20, 21, 22, 23, 24, 25, 24, 25, 26, 27,
		28, 29, 28, 29, 30, 31, 32, 1
	};

	private static readonly int[] z0yek = new int[32]
	{
		16, 7, 20, 21, 29, 12, 28, 17, 1, 15,
		23, 26, 5, 18, 31, 10, 2, 8, 24, 14,
		32, 27, 3, 9, 19, 13, 30, 6, 22, 11,
		4, 25
	};

	private static readonly int[] z0uek = new int[48]
	{
		14, 17, 11, 24, 1, 5, 3, 28, 15, 6,
		21, 10, 23, 19, 12, 4, 26, 8, 16, 7,
		27, 20, 13, 2, 41, 52, 31, 37, 47, 55,
		30, 40, 51, 45, 33, 48, 44, 49, 39, 56,
		34, 53, 46, 42, 50, 36, 29, 32
	};

	private static readonly int[,,] z0iek = new int[8, 4, 16]
	{
		{
			{
				14, 4, 13, 1, 2, 15, 11, 8, 3, 10,
				6, 12, 5, 9, 0, 7
			},
			{
				0, 15, 7, 4, 14, 2, 13, 1, 10, 6,
				12, 11, 9, 5, 3, 8
			},
			{
				4, 1, 14, 8, 13, 6, 2, 11, 15, 12,
				9, 7, 3, 10, 5, 0
			},
			{
				15, 12, 8, 2, 4, 9, 1, 7, 5, 11,
				3, 14, 10, 0, 6, 13
			}
		},
		{
			{
				15, 1, 8, 14, 6, 11, 3, 4, 9, 7,
				2, 13, 12, 0, 5, 10
			},
			{
				3, 13, 4, 7, 15, 2, 8, 14, 12, 0,
				1, 10, 6, 9, 11, 5
			},
			{
				0, 14, 7, 11, 10, 4, 13, 1, 5, 8,
				12, 6, 9, 3, 2, 15
			},
			{
				13, 8, 10, 1, 3, 15, 4, 2, 11, 6,
				7, 12, 0, 5, 14, 9
			}
		},
		{
			{
				10, 0, 9, 14, 6, 3, 15, 5, 1, 13,
				12, 7, 11, 4, 2, 8
			},
			{
				13, 7, 0, 9, 3, 4, 6, 10, 2, 8,
				5, 14, 12, 11, 15, 1
			},
			{
				13, 6, 4, 9, 8, 15, 3, 0, 11, 1,
				2, 12, 5, 10, 14, 7
			},
			{
				1, 10, 13, 0, 6, 9, 8, 7, 4, 15,
				14, 3, 11, 5, 2, 12
			}
		},
		{
			{
				7, 13, 14, 3, 0, 6, 9, 10, 1, 2,
				8, 5, 11, 12, 4, 15
			},
			{
				13, 8, 11, 5, 6, 15, 0, 3, 4, 7,
				2, 12, 1, 10, 14, 9
			},
			{
				10, 6, 9, 0, 12, 11, 7, 13, 15, 1,
				3, 14, 5, 2, 8, 4
			},
			{
				3, 15, 0, 6, 10, 1, 13, 8, 9, 4,
				5, 11, 12, 7, 2, 14
			}
		},
		{
			{
				2, 12, 4, 1, 7, 10, 11, 6, 8, 5,
				3, 15, 13, 0, 14, 9
			},
			{
				14, 11, 2, 12, 4, 7, 13, 1, 5, 0,
				15, 10, 3, 9, 8, 6
			},
			{
				4, 2, 1, 11, 10, 13, 7, 8, 15, 9,
				12, 5, 6, 3, 0, 14
			},
			{
				11, 8, 12, 7, 1, 14, 2, 13, 6, 15,
				0, 9, 10, 4, 5, 3
			}
		},
		{
			{
				12, 1, 10, 15, 9, 2, 6, 8, 0, 13,
				3, 4, 14, 7, 5, 11
			},
			{
				10, 15, 4, 2, 7, 12, 9, 5, 6, 1,
				13, 14, 0, 11, 3, 8
			},
			{
				9, 14, 15, 5, 2, 8, 12, 3, 7, 0,
				4, 10, 1, 13, 11, 6
			},
			{
				4, 3, 2, 12, 9, 5, 15, 10, 11, 14,
				1, 7, 6, 0, 8, 13
			}
		},
		{
			{
				4, 11, 2, 14, 15, 0, 8, 13, 3, 12,
				9, 7, 5, 10, 6, 1
			},
			{
				13, 0, 11, 7, 4, 9, 1, 10, 14, 3,
				5, 12, 2, 15, 8, 6
			},
			{
				1, 4, 11, 13, 12, 3, 7, 14, 10, 15,
				6, 8, 0, 5, 9, 2
			},
			{
				6, 11, 13, 8, 1, 4, 10, 7, 9, 5,
				0, 15, 14, 2, 3, 12
			}
		},
		{
			{
				13, 2, 8, 4, 6, 15, 11, 1, 10, 9,
				3, 14, 5, 0, 12, 7
			},
			{
				1, 15, 13, 8, 10, 3, 7, 4, 12, 5,
				6, 11, 0, 14, 9, 2
			},
			{
				7, 11, 4, 1, 9, 12, 14, 2, 0, 6,
				10, 13, 15, 3, 5, 8
			},
			{
				2, 1, 14, 7, 4, 10, 8, 13, 15, 12,
				9, 0, 3, 5, 6, 11
			}
		}
	};

	private static readonly int[] z0oek = new int[16]
	{
		1, 1, 2, 2, 2, 2, 2, 2, 1, 2,
		2, 2, 2, 2, 2, 1
	};

	private static readonly int[] z0pek = new int[56]
	{
		57, 49, 41, 33, 25, 17, 9, 1, 58, 50,
		42, 34, 26, 18, 10, 2, 59, 51, 43, 35,
		27, 19, 11, 3, 60, 52, 44, 36, 63, 55,
		47, 39, 31, 23, 15, 7, 62, 54, 46, 38,
		30, 22, 14, 6, 61, 53, 45, 37, 29, 21,
		13, 5, 28, 20, 12, 4
	};

	private static readonly int[] z0mek = new int[64]
	{
		58, 50, 42, 34, 26, 18, 10, 2, 60, 52,
		44, 36, 28, 20, 12, 4, 62, 54, 46, 38,
		30, 22, 14, 6, 64, 56, 48, 40, 32, 24,
		16, 8, 57, 49, 41, 33, 25, 17, 9, 1,
		59, 51, 43, 35, 27, 19, 11, 3, 61, 53,
		45, 37, 29, 21, 13, 5, 63, 55, 47, 39,
		31, 23, 15, 7
	};

	private static readonly int[] z0nek = new int[64]
	{
		40, 8, 48, 16, 56, 24, 64, 32, 39, 7,
		47, 15, 55, 23, 63, 31, 38, 6, 46, 14,
		54, 22, 62, 30, 37, 5, 45, 13, 53, 21,
		61, 29, 36, 4, 44, 12, 52, 20, 60, 28,
		35, 3, 43, 11, 51, 19, 59, 27, 34, 2,
		42, 10, 50, 18, 58, 26, 33, 1, 41, 9,
		49, 17, 57, 25
	};

	private static ulong z0eek(byte[] p0, int p1)
	{
		ulong num = 0uL;
		for (int i = 0; i < 8; i++)
		{
			num = (num << 8) | p0[p1 + i];
		}
		return num;
	}

	private static ulong z0eek(ulong p0, int[] p1, int p2)
	{
		ulong num = 0uL;
		for (int i = 0; i < p1.Length; i++)
		{
			int num2 = p2 - p1[i];
			num <<= 1;
			num |= (p0 >> num2) & 1;
		}
		return num;
	}

	public static byte[] z0eek(byte[] p0)
	{
		int num = p0[p0.Length - 1];
		if (num < 1 || num > 8)
		{
			throw new Exception("Invalid padding");
		}
		for (int i = p0.Length - num; i < p0.Length; i++)
		{
			if (p0[i] != num)
			{
				throw new Exception("Invalid padding");
			}
		}
		byte[] array = new byte[p0.Length - num];
		Buffer.BlockCopy(p0, 0, array, 0, array.Length);
		return array;
	}

	private static ulong[] z0rek(byte[] p0)
	{
		ulong num = z0eek(z0eek(p0, 0), z0pek, 64);
		uint num2 = (uint)((num >> 28) & 0xFFFFFFF);
		uint num3 = (uint)(num & 0xFFFFFFF);
		ulong[] array = new ulong[16];
		for (int i = 0; i < 16; i++)
		{
			num2 = ((num2 << z0oek[i]) | (num2 >> 28 - z0oek[i])) & 0xFFFFFFF;
			num3 = ((num3 << z0oek[i]) | (num3 >> 28 - z0oek[i])) & 0xFFFFFFF;
			ulong p1 = ((ulong)num2 << 28) | num3;
			array[i] = z0eek(p1, z0uek, 56);
		}
		return array;
	}

	private static uint z0eek(uint p0, ulong p1)
	{
		ulong num = 0uL;
		for (int i = 0; i < 48; i++)
		{
			num <<= 1;
			num |= (p0 >> 32 - z0tek[i]) & 1;
		}
		num ^= p1;
		uint num2 = 0u;
		for (int j = 0; j < 8; j++)
		{
			int num3 = (int)((num >> 42 - 6 * j) & 0x3F);
			int num4 = (num3 >> 5 << 1) | (num3 & 1);
			int num5 = (num3 >> 1) & 0xF;
			num2 = (num2 << 4) | (uint)z0iek[j, num4, num5];
		}
		uint num6 = 0u;
		for (int k = 0; k < 32; k++)
		{
			num6 <<= 1;
			num6 |= (num2 >> 32 - z0yek[k]) & 1;
		}
		return num6;
	}

	public static ulong z0eek(ulong p0, ulong[] p1)
	{
		p0 = z0eek(p0, z0mek, 64);
		uint num = (uint)(p0 >> 32);
		uint num2 = (uint)(p0 & 0xFFFFFFFFu);
		for (int i = 0; i < 16; i++)
		{
			uint num3 = num2;
			num2 = num ^ z0eek(num2, p1[i]);
			num = num3;
		}
		return z0eek(((ulong)num2 << 32) | num, z0nek, 64);
	}

	public static byte[] z0eek(byte[] p0, byte[] p1, byte[] p2)
	{
		byte[] array = new byte[p0.Length];
		ulong[] p3 = z0rek(p1);
		ulong num = z0eek(p2, 0);
		for (int i = 0; i < p0.Length; i += 8)
		{
			ulong num2 = z0eek(p0, i);
			z0eek(z0rek(num2, p3) ^ num, array, i);
			num = num2;
		}
		return z0eek(array);
	}

	public static byte[] z0rek(byte[] p0, byte[] p1, byte[] p2)
	{
		p0 = z0rek(p0, 8);
		byte[] array = new byte[p0.Length];
		ulong[] p3 = z0rek(p1);
		ulong num = z0eek(p2, 0);
		for (int i = 0; i < p0.Length; i += 8)
		{
			z0eek(num = z0eek(z0eek(p0, i) ^ num, p3), array, i);
		}
		return array;
	}

	public static ulong z0rek(ulong p0, ulong[] p1)
	{
		p0 = z0eek(p0, z0mek, 64);
		uint num = (uint)(p0 >> 32);
		uint num2 = (uint)(p0 & 0xFFFFFFFFu);
		for (int num3 = 15; num3 >= 0; num3--)
		{
			uint num4 = num2;
			num2 = num ^ z0eek(num2, p1[num3]);
			num = num4;
		}
		return z0eek(((ulong)num2 << 32) | num, z0nek, 64);
	}

	private static void z0eek(ulong p0, byte[] p1, int p2)
	{
		for (int num = 7; num >= 0; num--)
		{
			p1[p2 + num] = (byte)(p0 & 0xFF);
			p0 >>= 8;
		}
	}

	public static byte[] z0rek(byte[] p0, int p1)
	{
		int num = p1 - p0.Length % p1;
		byte[] array = new byte[p0.Length + num];
		Buffer.BlockCopy(p0, 0, array, 0, p0.Length);
		for (int i = p0.Length; i < array.Length; i++)
		{
			array[i] = (byte)num;
		}
		return array;
	}
}
