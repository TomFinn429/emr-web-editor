namespace zzz;

internal static class z0ZzZzwij
{
	private static readonly int[][] z0uek = new int[5][]
	{
		new int[5] { 1, 1, 1, 1, 1 },
		new int[5] { 1, 0, 0, 0, 1 },
		new int[5] { 1, 0, 1, 0, 1 },
		new int[5] { 1, 0, 0, 0, 1 },
		new int[5] { 1, 1, 1, 1, 1 }
	};

	private static readonly int[][] z0iek = new int[7][]
	{
		new int[1],
		new int[1],
		new int[1],
		new int[1],
		new int[1],
		new int[1],
		new int[1]
	};

	private static readonly int[][] z0oek = new int[15][]
	{
		new int[2] { 8, 0 },
		new int[2] { 8, 1 },
		new int[2] { 8, 2 },
		new int[2] { 8, 3 },
		new int[2] { 8, 4 },
		new int[2] { 8, 5 },
		new int[2] { 8, 7 },
		new int[2] { 8, 8 },
		new int[2] { 7, 8 },
		new int[2] { 5, 8 },
		new int[2] { 4, 8 },
		new int[2] { 3, 8 },
		new int[2] { 2, 8 },
		new int[2] { 1, 8 },
		new int[2] { 0, 8 }
	};

	private static readonly int[][] z0pek = new int[40][]
	{
		new int[7] { -1, -1, -1, -1, -1, -1, -1 },
		new int[7] { 6, 18, -1, -1, -1, -1, -1 },
		new int[7] { 6, 22, -1, -1, -1, -1, -1 },
		new int[7] { 6, 26, -1, -1, -1, -1, -1 },
		new int[7] { 6, 30, -1, -1, -1, -1, -1 },
		new int[7] { 6, 34, -1, -1, -1, -1, -1 },
		new int[7] { 6, 22, 38, -1, -1, -1, -1 },
		new int[7] { 6, 24, 42, -1, -1, -1, -1 },
		new int[7] { 6, 26, 46, -1, -1, -1, -1 },
		new int[7] { 6, 28, 50, -1, -1, -1, -1 },
		new int[7] { 6, 30, 54, -1, -1, -1, -1 },
		new int[7] { 6, 32, 58, -1, -1, -1, -1 },
		new int[7] { 6, 34, 62, -1, -1, -1, -1 },
		new int[7] { 6, 26, 46, 66, -1, -1, -1 },
		new int[7] { 6, 26, 48, 70, -1, -1, -1 },
		new int[7] { 6, 26, 50, 74, -1, -1, -1 },
		new int[7] { 6, 30, 54, 78, -1, -1, -1 },
		new int[7] { 6, 30, 56, 82, -1, -1, -1 },
		new int[7] { 6, 30, 58, 86, -1, -1, -1 },
		new int[7] { 6, 34, 62, 90, -1, -1, -1 },
		new int[7] { 6, 28, 50, 72, 94, -1, -1 },
		new int[7] { 6, 26, 50, 74, 98, -1, -1 },
		new int[7] { 6, 30, 54, 78, 102, -1, -1 },
		new int[7] { 6, 28, 54, 80, 106, -1, -1 },
		new int[7] { 6, 32, 58, 84, 110, -1, -1 },
		new int[7] { 6, 30, 58, 86, 114, -1, -1 },
		new int[7] { 6, 34, 62, 90, 118, -1, -1 },
		new int[7] { 6, 26, 50, 74, 98, 122, -1 },
		new int[7] { 6, 30, 54, 78, 102, 126, -1 },
		new int[7] { 6, 26, 52, 78, 104, 130, -1 },
		new int[7] { 6, 30, 56, 82, 108, 134, -1 },
		new int[7] { 6, 34, 60, 86, 112, 138, -1 },
		new int[7] { 6, 30, 58, 86, 114, 142, -1 },
		new int[7] { 6, 34, 62, 90, 118, 146, -1 },
		new int[7] { 6, 30, 54, 78, 102, 126, 150 },
		new int[7] { 6, 24, 50, 76, 102, 128, 154 },
		new int[7] { 6, 28, 54, 80, 106, 132, 158 },
		new int[7] { 6, 32, 58, 84, 110, 136, 162 },
		new int[7] { 6, 26, 54, 82, 110, 138, 166 },
		new int[7] { 6, 30, 58, 86, 114, 142, 170 }
	};

	private static readonly int[][] z0nek = new int[1][] { new int[8] };

	private static readonly int[][] z0vek = new int[7][]
	{
		new int[7] { 1, 1, 1, 1, 1, 1, 1 },
		new int[7] { 1, 0, 0, 0, 0, 0, 1 },
		new int[7] { 1, 0, 1, 1, 1, 0, 1 },
		new int[7] { 1, 0, 1, 1, 1, 0, 1 },
		new int[7] { 1, 0, 1, 1, 1, 0, 1 },
		new int[7] { 1, 0, 0, 0, 0, 0, 1 },
		new int[7] { 1, 1, 1, 1, 1, 1, 1 }
	};

	private static void z0eek(int p0, int p1, z0ZzZzbuj p2)
	{
		if (z0uek[0].Length != 5 || z0uek.Length != 5)
		{
			throw new z0ZzZziij("Bad position adjustment");
		}
		for (int i = 0; i < 5; i++)
		{
			for (int j = 0; j < 5; j++)
			{
				if (!z0rek(p2.z0eek(p0 + j, p1 + i)))
				{
					throw new z0ZzZziij();
				}
				p2.z0eek(p0 + j, p1 + i, z0uek[i][j]);
			}
		}
	}

	public static int z0eek(int p0)
	{
		int num = 0;
		while (p0 != 0)
		{
			p0 = z0ZzZztij.z0eek(p0, 1);
			num++;
		}
		return num;
	}

	private static void z0eek(z0ZzZzbuj p0)
	{
		if (p0.z0eek(8, p0.z0rek() - 8) == 0)
		{
			throw new z0ZzZziij();
		}
		p0.z0eek(8, p0.z0rek() - 8, 1);
	}

	public static int z0eek(int p0, int p1)
	{
		int num = z0eek(p1);
		p0 <<= num - 1;
		while (z0eek(p0) >= num)
		{
			p0 ^= p1 << z0eek(p0) - num;
		}
		return p0;
	}

	private static void z0rek(int p0, int p1, z0ZzZzbuj p2)
	{
		if (z0nek[0].Length != 8 || z0nek.Length != 1)
		{
			throw new z0ZzZziij("Bad horizontal separation pattern");
		}
		for (int i = 0; i < 8; i++)
		{
			if (!z0rek(p2.z0eek(p0 + i, p1)))
			{
				throw new z0ZzZziij();
			}
			p2.z0eek(p0 + i, p1, z0nek[0][i]);
		}
	}

	private static void z0rek(z0ZzZzbuj p0)
	{
		int num = z0vek[0].Length;
		z0tek(0, 0, p0);
		z0tek(p0.z0tek() - num, 0, p0);
		z0tek(0, p0.z0tek() - num, p0);
		int num2 = z0nek[0].Length;
		z0rek(0, num2 - 1, p0);
		z0rek(p0.z0tek() - num2, num2 - 1, p0);
		z0rek(0, p0.z0tek() - num2, p0);
		int num3 = z0iek.Length;
		z0yek(num3, 0, p0);
		z0yek(p0.z0rek() - num3 - 1, 0, p0);
		z0yek(num3, p0.z0rek() - num3, p0);
	}

	public static void z0eek(z0ZzZzhij p0, int p1, z0ZzZzdij p2)
	{
		if (!z0ZzZzeij.z0rek(p1))
		{
			throw new z0ZzZziij("Invalid mask pattern");
		}
		int p3 = (p0.z0rek() << 3) | p1;
		p2.z0eek(p3, 5);
		int p4 = z0eek(p3, 1335);
		p2.z0eek(p4, 10);
		z0ZzZzdij z0ZzZzdij2 = new z0ZzZzdij();
		z0ZzZzdij2.z0eek(21522, 15);
		p2.z0eek(z0ZzZzdij2);
		if (p2.z0tek() != 15)
		{
			throw new z0ZzZziij("should not happen but we got: " + p2.z0tek());
		}
	}

	private static bool z0rek(int p0)
	{
		return p0 == -1;
	}

	public static void z0eek(z0ZzZzhij p0, int p1, z0ZzZzbuj p2)
	{
		z0ZzZzdij z0ZzZzdij2 = new z0ZzZzdij();
		z0eek(p0, p1, z0ZzZzdij2);
		for (int i = 0; i < z0ZzZzdij2.z0tek(); i++)
		{
			int p3 = z0ZzZzdij2.z0eek(z0ZzZzdij2.z0tek() - 1 - i);
			int p4 = z0oek[i][0];
			int p5 = z0oek[i][1];
			p2.z0eek(p4, p5, p3);
			if (i < 8)
			{
				int p6 = p2.z0tek() - i - 1;
				int p7 = 8;
				p2.z0eek(p6, p7, p3);
			}
			else
			{
				int p8 = 8;
				int p9 = p2.z0rek() - 7 + (i - 8);
				p2.z0eek(p8, p9, p3);
			}
		}
	}

	public static void z0eek(z0ZzZzdij p0, z0ZzZzhij p1, int p2, int p3, z0ZzZzbuj p4)
	{
		z0tek(p4);
		z0rek(p2, p4);
		z0eek(p1, p3, p4);
		z0tek(p2, p4);
		z0eek(p0, p3, p4);
	}

	public static void z0tek(z0ZzZzbuj p0)
	{
		p0.z0eek(-1);
	}

	private static void z0eek(int p0, z0ZzZzbuj p1)
	{
		if (p0 < 2)
		{
			return;
		}
		int num = p0 - 1;
		int[] array = z0pek[num];
		int num2 = z0pek[num].Length;
		for (int i = 0; i < num2; i++)
		{
			for (int j = 0; j < num2; j++)
			{
				int num3 = array[i];
				int num4 = array[j];
				if (num4 != -1 && num3 != -1 && z0rek(p1.z0eek(num4, num3)))
				{
					z0eek(num4 - 2, num3 - 2, p1);
				}
			}
		}
	}

	public static void z0rek(int p0, z0ZzZzbuj p1)
	{
		z0rek(p1);
		z0eek(p1);
		z0eek(p0, p1);
		z0yek(p1);
	}

	public static void z0tek(int p0, z0ZzZzbuj p1)
	{
		if (p0 < 7)
		{
			return;
		}
		z0ZzZzdij z0ZzZzdij2 = new z0ZzZzdij();
		z0eek(p0, z0ZzZzdij2);
		int num = 17;
		for (int i = 0; i < 6; i++)
		{
			for (int j = 0; j < 3; j++)
			{
				int p2 = z0ZzZzdij2.z0eek(num);
				num--;
				p1.z0eek(i, p1.z0rek() - 11 + j, p2);
				p1.z0eek(p1.z0rek() - 11 + j, i, p2);
			}
		}
	}

	private static void z0tek(int p0, int p1, z0ZzZzbuj p2)
	{
		if (z0vek[0].Length != 7 || z0vek.Length != 7)
		{
			throw new z0ZzZziij("Bad position detection pattern");
		}
		for (int i = 0; i < 7; i++)
		{
			for (int j = 0; j < 7; j++)
			{
				if (!z0rek(p2.z0eek(p0 + j, p1 + i)))
				{
					throw new z0ZzZziij();
				}
				p2.z0eek(p0 + j, p1 + i, z0vek[i][j]);
			}
		}
	}

	private static void z0yek(z0ZzZzbuj p0)
	{
		for (int i = 8; i < p0.z0tek() - 8; i++)
		{
			int p1 = (i + 1) % 2;
			if (!z0tek(p0.z0eek(i, 6)))
			{
				throw new z0ZzZziij();
			}
			if (z0rek(p0.z0eek(i, 6)))
			{
				p0.z0eek(i, 6, p1);
			}
			if (!z0tek(p0.z0eek(6, i)))
			{
				throw new z0ZzZziij();
			}
			if (z0rek(p0.z0eek(6, i)))
			{
				p0.z0eek(6, i, p1);
			}
		}
	}

	private static void z0yek(int p0, int p1, z0ZzZzbuj p2)
	{
		if (z0iek[0].Length != 1 || z0iek.Length != 7)
		{
			throw new z0ZzZziij("Bad vertical separation pattern");
		}
		for (int i = 0; i < 7; i++)
		{
			if (!z0rek(p2.z0eek(p0, p1 + i)))
			{
				throw new z0ZzZziij();
			}
			p2.z0eek(p0, p1 + i, z0iek[i][0]);
		}
	}

	private static bool z0tek(int p0)
	{
		if (p0 != -1 && p0 != 0)
		{
			return p0 == 1;
		}
		return true;
	}

	public static void z0eek(z0ZzZzdij p0, int p1, z0ZzZzbuj p2)
	{
		int num = 0;
		int num2 = -1;
		int num3 = p2.z0tek() - 1;
		int i = p2.z0rek() - 1;
		while (num3 > 0)
		{
			if (num3 == 6)
			{
				num3--;
			}
			for (; i >= 0 && i < p2.z0rek(); i += num2)
			{
				for (int j = 0; j < 2; j++)
				{
					int num4 = num3 - j;
					if (z0rek(p2.z0eek(num4, i)))
					{
						int num5;
						if (num < p0.z0tek())
						{
							num5 = p0.z0eek(num);
							num++;
						}
						else
						{
							num5 = 0;
						}
						if (p1 != -1 && z0ZzZzqij.z0eek(p1, num4, i))
						{
							num5 ^= 1;
						}
						p2.z0eek(num4, i, num5);
					}
				}
			}
			num2 = -num2;
			i += num2;
			num3 -= 2;
		}
		if (num != p0.z0tek())
		{
			throw new z0ZzZziij("Not all bits consumed: " + num + "/" + p0.z0tek());
		}
	}

	public static void z0eek(int p0, z0ZzZzdij p1)
	{
		p1.z0eek(p0, 6);
		int p2 = z0eek(p0, 7973);
		p1.z0eek(p2, 12);
		if (p1.z0tek() != 18)
		{
			throw new z0ZzZziij("should not happen but we got: " + p1.z0tek());
		}
	}
}
