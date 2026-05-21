using System;

namespace zzz;

internal sealed class z0ZzZzfij
{
	internal sealed class z0emk
	{
		private z0wmk[] z0uek;

		private int z0iek;

		internal z0emk(int p0, z0wmk p1)
		{
			z0iek = p0;
			z0uek = new z0wmk[1] { p1 };
		}

		public int z0eek()
		{
			return z0iek;
		}

		public int z0rek()
		{
			return z0iek * z0yek();
		}

		public z0wmk[] z0tek()
		{
			return z0uek;
		}

		internal z0emk(int p0, z0wmk p1, z0wmk p2)
		{
			z0iek = p0;
			z0uek = new z0wmk[2] { p1, p2 };
		}

		public int z0yek()
		{
			int num = 0;
			for (int i = 0; i < z0uek.Length; i++)
			{
				num += z0uek[i].z0eek_jiejie20260327142557();
			}
			return num;
		}
	}

	internal sealed class z0wmk
	{
		private int z0tek;

		private int z0yek;

		public int z0eek_jiejie20260327142557()
		{
			return z0yek;
		}

		internal z0wmk(int p0, int p1)
		{
			z0yek = p0;
			z0tek = p1;
		}

		public int z0rek()
		{
			return z0tek;
		}
	}

	private int z0uek;

	private static readonly z0ZzZzfij[] z0iek = z0yek();

	private int z0oek;

	private int[] z0pek;

	private z0emk[] z0mek;

	public override string ToString()
	{
		return Convert.ToString(z0oek);
	}

	public int z0eek()
	{
		return z0uek;
	}

	public int z0rek()
	{
		return z0oek;
	}

	public static z0ZzZzfij z0eek(int p0)
	{
		if (p0 < 1 || p0 > 40)
		{
			throw new ArgumentException();
		}
		return z0iek[p0 - 1];
	}

	private z0ZzZzfij(int p0, int[] p1, z0emk p2, z0emk p3, z0emk p4, z0emk p5)
	{
		z0oek = p0;
		z0pek = p1;
		z0mek = new z0emk[4] { p2, p3, p4, p5 };
		int num = 0;
		int num2 = p2.z0eek();
		z0wmk[] array = p2.z0tek();
		foreach (z0wmk z0wmk in array)
		{
			num += z0wmk.z0eek_jiejie20260327142557() * (z0wmk.z0rek() + num2);
		}
		z0uek = num;
	}

	public z0emk z0eek(z0ZzZzhij p0)
	{
		return z0mek[p0.z0eek()];
	}

	public int z0tek()
	{
		return 17 + 4 * z0oek;
	}

	private static z0ZzZzfij[] z0yek()
	{
		return new z0ZzZzfij[40]
		{
			new z0ZzZzfij(1, new int[0], new z0emk(7, new z0wmk(1, 19)), new z0emk(10, new z0wmk(1, 16)), new z0emk(13, new z0wmk(1, 13)), new z0emk(17, new z0wmk(1, 9))),
			new z0ZzZzfij(2, new int[2] { 6, 18 }, new z0emk(10, new z0wmk(1, 34)), new z0emk(16, new z0wmk(1, 28)), new z0emk(22, new z0wmk(1, 22)), new z0emk(28, new z0wmk(1, 16))),
			new z0ZzZzfij(3, new int[2] { 6, 22 }, new z0emk(15, new z0wmk(1, 55)), new z0emk(26, new z0wmk(1, 44)), new z0emk(18, new z0wmk(2, 17)), new z0emk(22, new z0wmk(2, 13))),
			new z0ZzZzfij(4, new int[2] { 6, 26 }, new z0emk(20, new z0wmk(1, 80)), new z0emk(18, new z0wmk(2, 32)), new z0emk(26, new z0wmk(2, 24)), new z0emk(16, new z0wmk(4, 9))),
			new z0ZzZzfij(5, new int[2] { 6, 30 }, new z0emk(26, new z0wmk(1, 108)), new z0emk(24, new z0wmk(2, 43)), new z0emk(18, new z0wmk(2, 15), new z0wmk(2, 16)), new z0emk(22, new z0wmk(2, 11), new z0wmk(2, 12))),
			new z0ZzZzfij(6, new int[2] { 6, 34 }, new z0emk(18, new z0wmk(2, 68)), new z0emk(16, new z0wmk(4, 27)), new z0emk(24, new z0wmk(4, 19)), new z0emk(28, new z0wmk(4, 15))),
			new z0ZzZzfij(7, new int[3] { 6, 22, 38 }, new z0emk(20, new z0wmk(2, 78)), new z0emk(18, new z0wmk(4, 31)), new z0emk(18, new z0wmk(2, 14), new z0wmk(4, 15)), new z0emk(26, new z0wmk(4, 13), new z0wmk(1, 14))),
			new z0ZzZzfij(8, new int[3] { 6, 24, 42 }, new z0emk(24, new z0wmk(2, 97)), new z0emk(22, new z0wmk(2, 38), new z0wmk(2, 39)), new z0emk(22, new z0wmk(4, 18), new z0wmk(2, 19)), new z0emk(26, new z0wmk(4, 14), new z0wmk(2, 15))),
			new z0ZzZzfij(9, new int[3] { 6, 26, 46 }, new z0emk(30, new z0wmk(2, 116)), new z0emk(22, new z0wmk(3, 36), new z0wmk(2, 37)), new z0emk(20, new z0wmk(4, 16), new z0wmk(4, 17)), new z0emk(24, new z0wmk(4, 12), new z0wmk(4, 13))),
			new z0ZzZzfij(10, new int[3] { 6, 28, 50 }, new z0emk(18, new z0wmk(2, 68), new z0wmk(2, 69)), new z0emk(26, new z0wmk(4, 43), new z0wmk(1, 44)), new z0emk(24, new z0wmk(6, 19), new z0wmk(2, 20)), new z0emk(28, new z0wmk(6, 15), new z0wmk(2, 16))),
			new z0ZzZzfij(11, new int[3] { 6, 30, 54 }, new z0emk(20, new z0wmk(4, 81)), new z0emk(30, new z0wmk(1, 50), new z0wmk(4, 51)), new z0emk(28, new z0wmk(4, 22), new z0wmk(4, 23)), new z0emk(24, new z0wmk(3, 12), new z0wmk(8, 13))),
			new z0ZzZzfij(12, new int[3] { 6, 32, 58 }, new z0emk(24, new z0wmk(2, 92), new z0wmk(2, 93)), new z0emk(22, new z0wmk(6, 36), new z0wmk(2, 37)), new z0emk(26, new z0wmk(4, 20), new z0wmk(6, 21)), new z0emk(28, new z0wmk(7, 14), new z0wmk(4, 15))),
			new z0ZzZzfij(13, new int[3] { 6, 34, 62 }, new z0emk(26, new z0wmk(4, 107)), new z0emk(22, new z0wmk(8, 37), new z0wmk(1, 38)), new z0emk(24, new z0wmk(8, 20), new z0wmk(4, 21)), new z0emk(22, new z0wmk(12, 11), new z0wmk(4, 12))),
			new z0ZzZzfij(14, new int[4] { 6, 26, 46, 66 }, new z0emk(30, new z0wmk(3, 115), new z0wmk(1, 116)), new z0emk(24, new z0wmk(4, 40), new z0wmk(5, 41)), new z0emk(20, new z0wmk(11, 16), new z0wmk(5, 17)), new z0emk(24, new z0wmk(11, 12), new z0wmk(5, 13))),
			new z0ZzZzfij(15, new int[4] { 6, 26, 48, 70 }, new z0emk(22, new z0wmk(5, 87), new z0wmk(1, 88)), new z0emk(24, new z0wmk(5, 41), new z0wmk(5, 42)), new z0emk(30, new z0wmk(5, 24), new z0wmk(7, 25)), new z0emk(24, new z0wmk(11, 12), new z0wmk(7, 13))),
			new z0ZzZzfij(16, new int[4] { 6, 26, 50, 74 }, new z0emk(24, new z0wmk(5, 98), new z0wmk(1, 99)), new z0emk(28, new z0wmk(7, 45), new z0wmk(3, 46)), new z0emk(24, new z0wmk(15, 19), new z0wmk(2, 20)), new z0emk(30, new z0wmk(3, 15), new z0wmk(13, 16))),
			new z0ZzZzfij(17, new int[4] { 6, 30, 54, 78 }, new z0emk(28, new z0wmk(1, 107), new z0wmk(5, 108)), new z0emk(28, new z0wmk(10, 46), new z0wmk(1, 47)), new z0emk(28, new z0wmk(1, 22), new z0wmk(15, 23)), new z0emk(28, new z0wmk(2, 14), new z0wmk(17, 15))),
			new z0ZzZzfij(18, new int[4] { 6, 30, 56, 82 }, new z0emk(30, new z0wmk(5, 120), new z0wmk(1, 121)), new z0emk(26, new z0wmk(9, 43), new z0wmk(4, 44)), new z0emk(28, new z0wmk(17, 22), new z0wmk(1, 23)), new z0emk(28, new z0wmk(2, 14), new z0wmk(19, 15))),
			new z0ZzZzfij(19, new int[4] { 6, 30, 58, 86 }, new z0emk(28, new z0wmk(3, 113), new z0wmk(4, 114)), new z0emk(26, new z0wmk(3, 44), new z0wmk(11, 45)), new z0emk(26, new z0wmk(17, 21), new z0wmk(4, 22)), new z0emk(26, new z0wmk(9, 13), new z0wmk(16, 14))),
			new z0ZzZzfij(20, new int[4] { 6, 34, 62, 90 }, new z0emk(28, new z0wmk(3, 107), new z0wmk(5, 108)), new z0emk(26, new z0wmk(3, 41), new z0wmk(13, 42)), new z0emk(30, new z0wmk(15, 24), new z0wmk(5, 25)), new z0emk(28, new z0wmk(15, 15), new z0wmk(10, 16))),
			new z0ZzZzfij(21, new int[5] { 6, 28, 50, 72, 94 }, new z0emk(28, new z0wmk(4, 116), new z0wmk(4, 117)), new z0emk(26, new z0wmk(17, 42)), new z0emk(28, new z0wmk(17, 22), new z0wmk(6, 23)), new z0emk(30, new z0wmk(19, 16), new z0wmk(6, 17))),
			new z0ZzZzfij(22, new int[5] { 6, 26, 50, 74, 98 }, new z0emk(28, new z0wmk(2, 111), new z0wmk(7, 112)), new z0emk(28, new z0wmk(17, 46)), new z0emk(30, new z0wmk(7, 24), new z0wmk(16, 25)), new z0emk(24, new z0wmk(34, 13))),
			new z0ZzZzfij(23, new int[5] { 6, 30, 54, 74, 102 }, new z0emk(30, new z0wmk(4, 121), new z0wmk(5, 122)), new z0emk(28, new z0wmk(4, 47), new z0wmk(14, 48)), new z0emk(30, new z0wmk(11, 24), new z0wmk(14, 25)), new z0emk(30, new z0wmk(16, 15), new z0wmk(14, 16))),
			new z0ZzZzfij(24, new int[5] { 6, 28, 54, 80, 106 }, new z0emk(30, new z0wmk(6, 117), new z0wmk(4, 118)), new z0emk(28, new z0wmk(6, 45), new z0wmk(14, 46)), new z0emk(30, new z0wmk(11, 24), new z0wmk(16, 25)), new z0emk(30, new z0wmk(30, 16), new z0wmk(2, 17))),
			new z0ZzZzfij(25, new int[5] { 6, 32, 58, 84, 110 }, new z0emk(26, new z0wmk(8, 106), new z0wmk(4, 107)), new z0emk(28, new z0wmk(8, 47), new z0wmk(13, 48)), new z0emk(30, new z0wmk(7, 24), new z0wmk(22, 25)), new z0emk(30, new z0wmk(22, 15), new z0wmk(13, 16))),
			new z0ZzZzfij(26, new int[5] { 6, 30, 58, 86, 114 }, new z0emk(28, new z0wmk(10, 114), new z0wmk(2, 115)), new z0emk(28, new z0wmk(19, 46), new z0wmk(4, 47)), new z0emk(28, new z0wmk(28, 22), new z0wmk(6, 23)), new z0emk(30, new z0wmk(33, 16), new z0wmk(4, 17))),
			new z0ZzZzfij(27, new int[5] { 6, 34, 62, 90, 118 }, new z0emk(30, new z0wmk(8, 122), new z0wmk(4, 123)), new z0emk(28, new z0wmk(22, 45), new z0wmk(3, 46)), new z0emk(30, new z0wmk(8, 23), new z0wmk(26, 24)), new z0emk(30, new z0wmk(12, 15), new z0wmk(28, 16))),
			new z0ZzZzfij(28, new int[6] { 6, 26, 50, 74, 98, 122 }, new z0emk(30, new z0wmk(3, 117), new z0wmk(10, 118)), new z0emk(28, new z0wmk(3, 45), new z0wmk(23, 46)), new z0emk(30, new z0wmk(4, 24), new z0wmk(31, 25)), new z0emk(30, new z0wmk(11, 15), new z0wmk(31, 16))),
			new z0ZzZzfij(29, new int[6] { 6, 30, 54, 78, 102, 126 }, new z0emk(30, new z0wmk(7, 116), new z0wmk(7, 117)), new z0emk(28, new z0wmk(21, 45), new z0wmk(7, 46)), new z0emk(30, new z0wmk(1, 23), new z0wmk(37, 24)), new z0emk(30, new z0wmk(19, 15), new z0wmk(26, 16))),
			new z0ZzZzfij(30, new int[6] { 6, 26, 52, 78, 104, 130 }, new z0emk(30, new z0wmk(5, 115), new z0wmk(10, 116)), new z0emk(28, new z0wmk(19, 47), new z0wmk(10, 48)), new z0emk(30, new z0wmk(15, 24), new z0wmk(25, 25)), new z0emk(30, new z0wmk(23, 15), new z0wmk(25, 16))),
			new z0ZzZzfij(31, new int[6] { 6, 30, 56, 82, 108, 134 }, new z0emk(30, new z0wmk(13, 115), new z0wmk(3, 116)), new z0emk(28, new z0wmk(2, 46), new z0wmk(29, 47)), new z0emk(30, new z0wmk(42, 24), new z0wmk(1, 25)), new z0emk(30, new z0wmk(23, 15), new z0wmk(28, 16))),
			new z0ZzZzfij(32, new int[6] { 6, 34, 60, 86, 112, 138 }, new z0emk(30, new z0wmk(17, 115)), new z0emk(28, new z0wmk(10, 46), new z0wmk(23, 47)), new z0emk(30, new z0wmk(10, 24), new z0wmk(35, 25)), new z0emk(30, new z0wmk(19, 15), new z0wmk(35, 16))),
			new z0ZzZzfij(33, new int[6] { 6, 30, 58, 86, 114, 142 }, new z0emk(30, new z0wmk(17, 115), new z0wmk(1, 116)), new z0emk(28, new z0wmk(14, 46), new z0wmk(21, 47)), new z0emk(30, new z0wmk(29, 24), new z0wmk(19, 25)), new z0emk(30, new z0wmk(11, 15), new z0wmk(46, 16))),
			new z0ZzZzfij(34, new int[6] { 6, 34, 62, 90, 118, 146 }, new z0emk(30, new z0wmk(13, 115), new z0wmk(6, 116)), new z0emk(28, new z0wmk(14, 46), new z0wmk(23, 47)), new z0emk(30, new z0wmk(44, 24), new z0wmk(7, 25)), new z0emk(30, new z0wmk(59, 16), new z0wmk(1, 17))),
			new z0ZzZzfij(35, new int[7] { 6, 30, 54, 78, 102, 126, 150 }, new z0emk(30, new z0wmk(12, 121), new z0wmk(7, 122)), new z0emk(28, new z0wmk(12, 47), new z0wmk(26, 48)), new z0emk(30, new z0wmk(39, 24), new z0wmk(14, 25)), new z0emk(30, new z0wmk(22, 15), new z0wmk(41, 16))),
			new z0ZzZzfij(36, new int[7] { 6, 24, 50, 76, 102, 128, 154 }, new z0emk(30, new z0wmk(6, 121), new z0wmk(14, 122)), new z0emk(28, new z0wmk(6, 47), new z0wmk(34, 48)), new z0emk(30, new z0wmk(46, 24), new z0wmk(10, 25)), new z0emk(30, new z0wmk(2, 15), new z0wmk(64, 16))),
			new z0ZzZzfij(37, new int[7] { 6, 28, 54, 80, 106, 132, 158 }, new z0emk(30, new z0wmk(17, 122), new z0wmk(4, 123)), new z0emk(28, new z0wmk(29, 46), new z0wmk(14, 47)), new z0emk(30, new z0wmk(49, 24), new z0wmk(10, 25)), new z0emk(30, new z0wmk(24, 15), new z0wmk(46, 16))),
			new z0ZzZzfij(38, new int[7] { 6, 32, 58, 84, 110, 136, 162 }, new z0emk(30, new z0wmk(4, 122), new z0wmk(18, 123)), new z0emk(28, new z0wmk(13, 46), new z0wmk(32, 47)), new z0emk(30, new z0wmk(48, 24), new z0wmk(14, 25)), new z0emk(30, new z0wmk(42, 15), new z0wmk(32, 16))),
			new z0ZzZzfij(39, new int[7] { 6, 26, 54, 82, 110, 138, 166 }, new z0emk(30, new z0wmk(20, 117), new z0wmk(4, 118)), new z0emk(28, new z0wmk(40, 47), new z0wmk(7, 48)), new z0emk(30, new z0wmk(43, 24), new z0wmk(22, 25)), new z0emk(30, new z0wmk(10, 15), new z0wmk(67, 16))),
			new z0ZzZzfij(40, new int[7] { 6, 30, 58, 86, 114, 142, 170 }, new z0emk(30, new z0wmk(19, 118), new z0wmk(6, 119)), new z0emk(28, new z0wmk(18, 47), new z0wmk(31, 48)), new z0emk(30, new z0wmk(34, 24), new z0wmk(34, 25)), new z0emk(30, new z0wmk(20, 15), new z0wmk(61, 16)))
		};
	}
}
