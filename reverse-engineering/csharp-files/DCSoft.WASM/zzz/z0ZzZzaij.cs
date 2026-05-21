using System;
using System.Collections;
using System.IO;

namespace zzz;

internal static class z0ZzZzaij
{
	private static readonly int[] z0uek = new int[96]
	{
		-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
		-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
		-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
		-1, -1, 36, -1, -1, -1, 37, 38, -1, -1,
		-1, -1, 39, 40, -1, 41, 42, 43, 0, 1,
		2, 3, 4, 5, 6, 7, 8, 9, 44, -1,
		-1, -1, -1, -1, -1, 10, 11, 12, 13, 14,
		15, 16, 17, 18, 19, 20, 21, 22, 23, 24,
		25, 26, 27, 28, 29, 30, 31, 32, 33, 34,
		35, -1, -1, -1, -1, -1
	};

	internal static int z0eek(int p0)
	{
		if (p0 < z0uek.Length)
		{
			return z0uek[p0];
		}
		return -1;
	}

	public static z0ZzZzgij z0eek(string p0, string p1)
	{
		if ("Shift_JIS".Equals(p1))
		{
			if (!z0eek(p0))
			{
				return z0ZzZzgij.z0pek;
			}
			return z0ZzZzgij.z0oek;
		}
		bool flag = false;
		bool flag2 = false;
		foreach (char c in p0)
		{
			if (c >= '0' && c <= '9')
			{
				flag = true;
				continue;
			}
			if (z0eek(c) != -1)
			{
				flag2 = true;
				continue;
			}
			return z0ZzZzgij.z0pek;
		}
		if (flag2)
		{
			return z0ZzZzgij.z0mek;
		}
		if (flag)
		{
			return z0ZzZzgij.z0yek;
		}
		return z0ZzZzgij.z0pek;
	}

	internal static void z0eek(int p0, int p1, int p2, int p3, int[] p4, int[] p5)
	{
		if (p3 >= p2)
		{
			throw new z0ZzZziij("Block ID too large");
		}
		int num = p0 % p2;
		int num2 = p2 - num;
		int num3 = p0 / p2;
		int num4 = num3 + 1;
		int num5 = p1 / p2;
		int num6 = num5 + 1;
		int num7 = num3 - num5;
		int num8 = num4 - num6;
		if (num7 != num8)
		{
			throw new z0ZzZziij("EC bytes mismatch");
		}
		if (p2 != num2 + num)
		{
			throw new z0ZzZziij("RS blocks mismatch");
		}
		if (p0 != (num5 + num7) * num2 + (num6 + num8) * num)
		{
			throw new z0ZzZziij("Total bytes mismatch");
		}
		if (p3 < num2)
		{
			p4[0] = num5;
			p5[0] = num7;
		}
		else
		{
			p4[0] = num6;
			p5[0] = num8;
		}
	}

	private static int z0eek(z0ZzZzdij p0, z0ZzZzhij p1, int p2, z0ZzZzbuj p3)
	{
		int num = 2147483647;
		int result = -1;
		for (int i = 0; i < 8; i++)
		{
			z0ZzZzwij.z0eek(p0, p1, p2, i, p3);
			int num2 = z0eek(p3);
			if (num2 < num)
			{
				num = num2;
				result = i;
			}
		}
		return result;
	}

	private static void z0eek(z0ZzZzvuj p0, z0ZzZzdij p1)
	{
		p1.z0eek(z0ZzZzgij.z0rek.z0eek(), 4);
		p1.z0eek(p0.z0eek(), 8);
	}

	private static void z0eek(int p0, z0ZzZzhij p1, z0ZzZzgij p2, z0ZzZzeij p3)
	{
		p3.z0eek(p1);
		p3.z0eek(p2);
		for (int i = 1; i <= 40; i++)
		{
			z0ZzZzfij z0ZzZzfij2 = z0ZzZzfij.z0eek(i);
			int num = z0ZzZzfij2.z0eek();
			z0ZzZzfij.z0emk z0emk = z0ZzZzfij2.z0eek(p1);
			int num2 = z0emk.z0rek();
			int p4 = z0emk.z0yek();
			int num3 = num - num2;
			if (num3 >= p0 + 3)
			{
				p3.z0eek(i);
				p3.z0tek(num);
				p3.z0oek(num3);
				p3.z0uek(p4);
				p3.z0yek(num2);
				p3.z0pek(z0ZzZzfij2.z0tek());
				return;
			}
		}
		throw new z0ZzZziij("Cannot find proper rs block info (input data too big?)");
	}

	private static int z0eek(z0ZzZzbuj p0)
	{
		return 0 + z0ZzZzqij.z0eek(p0) + z0ZzZzqij.z0tek(p0) + z0ZzZzqij.z0rek(p0) + z0ZzZzqij.z0yek(p0);
	}

	internal static void z0eek(string p0, z0ZzZzdij p1, string p2)
	{
		sbyte[] array;
		try
		{
			array = z0ZzZztij.z0eek(z0ZzZzqik.z0iek(p2).GetBytes(p0));
		}
		catch (IOException ex)
		{
			throw new z0ZzZziij(ex.ToString());
		}
		for (int i = 0; i < array.Length; i++)
		{
			p1.z0eek(array[i], 8);
		}
	}

	internal static void z0eek(string p0, z0ZzZzgij p1, z0ZzZzdij p2, string p3)
	{
		if (p1.Equals(z0ZzZzgij.z0yek))
		{
			z0eek(p0, p2);
			return;
		}
		if (p1.Equals(z0ZzZzgij.z0mek))
		{
			z0tek(p0, p2);
			return;
		}
		if (p1.Equals(z0ZzZzgij.z0pek))
		{
			z0eek(p0, p2, p3);
			return;
		}
		if (p1.Equals(z0ZzZzgij.z0oek))
		{
			z0rek(p0, p2);
			return;
		}
		throw new z0ZzZziij("Invalid mode: " + p1);
	}

	internal static void z0eek(int p0, z0ZzZzdij p1)
	{
		int num = p0 << 3;
		if (p1.z0tek() > num)
		{
			throw new z0ZzZziij("data bits cannot fit in the QR Code" + p1.z0tek() + " > " + num);
		}
		for (int i = 0; i < 4; i++)
		{
			if (p1.z0tek() >= num)
			{
				break;
			}
			p1.z0tek(0);
		}
		int num2 = p1.z0tek() % 8;
		if (num2 > 0)
		{
			int num3 = 8 - num2;
			for (int j = 0; j < num3; j++)
			{
				p1.z0tek(0);
			}
		}
		if (p1.z0tek() % 8 != 0)
		{
			throw new z0ZzZziij("Number of bits is not a multiple of 8");
		}
		int num4 = p0 - p1.z0eek();
		for (int k = 0; k < num4; k++)
		{
			if (k % 2 == 0)
			{
				p1.z0eek(236, 8);
			}
			else
			{
				p1.z0eek(17, 8);
			}
		}
		if (p1.z0tek() != num)
		{
			throw new z0ZzZziij("Bits size does not equal capacity");
		}
	}

	internal static void z0eek(z0ZzZzdij p0, int p1, int p2, int p3, z0ZzZzdij p4)
	{
		if (p0.z0eek() != p2)
		{
			throw new z0ZzZziij("Number of bits and data bytes does not match");
		}
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		ArrayList arrayList = ArrayList.Synchronized(new ArrayList(p3));
		for (int i = 0; i < p3; i++)
		{
			int[] array = new int[1];
			int[] array2 = new int[1];
			z0eek(p1, p2, p3, i, array, array2);
			z0ZzZznuj z0ZzZznuj2 = new z0ZzZznuj();
			z0ZzZznuj2.z0eek(p0.z0rek(), num, array[0]);
			z0ZzZznuj z0ZzZznuj3 = z0eek(z0ZzZznuj2, array2[0]);
			arrayList.Add(new z0ZzZzsij(z0ZzZznuj2, z0ZzZznuj3));
			num2 = Math.Max(num2, z0ZzZznuj2.z0eek());
			num3 = Math.Max(num3, z0ZzZznuj3.z0eek());
			num += array[0];
		}
		if (p2 != num)
		{
			throw new z0ZzZziij("Data bytes does not match offset");
		}
		for (int j = 0; j < num2; j++)
		{
			for (int k = 0; k < arrayList.Count; k++)
			{
				z0ZzZznuj z0ZzZznuj4 = ((z0ZzZzsij)arrayList[k]).z0eek();
				if (j < z0ZzZznuj4.z0eek())
				{
					p4.z0eek(z0ZzZznuj4.z0eek(j), 8);
				}
			}
		}
		for (int l = 0; l < num3; l++)
		{
			for (int m = 0; m < arrayList.Count; m++)
			{
				z0ZzZznuj z0ZzZznuj5 = ((z0ZzZzsij)arrayList[m]).z0rek();
				if (l < z0ZzZznuj5.z0eek())
				{
					p4.z0eek(z0ZzZznuj5.z0eek(l), 8);
				}
			}
		}
		if (p1 != p4.z0eek())
		{
			throw new z0ZzZziij("Interleaving error: " + p1 + " and " + p4.z0eek() + " differ.");
		}
	}

	internal static void z0eek(string p0, z0ZzZzdij p1)
	{
		int length = p0.Length;
		int num = 0;
		while (num < length)
		{
			int num2 = p0[num] - 48;
			if (num + 2 < length)
			{
				int num3 = p0[num + 1] - 48;
				int num4 = p0[num + 2] - 48;
				p1.z0eek(num2 * 100 + num3 * 10 + num4, 10);
				num += 3;
			}
			else if (num + 1 < length)
			{
				int num5 = p0[num + 1] - 48;
				p1.z0eek(num2 * 10 + num5, 7);
				num += 2;
			}
			else
			{
				p1.z0eek(num2, 4);
				num++;
			}
		}
	}

	internal static void z0rek(string p0, z0ZzZzdij p1)
	{
		sbyte[] array;
		try
		{
			array = z0ZzZztij.z0eek(z0ZzZzqik.z0iek("Shift_JIS").GetBytes(p0));
		}
		catch (IOException ex)
		{
			throw new z0ZzZziij(ex.ToString());
		}
		int num = array.Length;
		for (int i = 0; i < num; i += 2)
		{
			int num2 = array[i] & 0xFF;
			int num3 = array[i + 1] & 0xFF;
			int num4 = (num2 << 8) | num3;
			int num5 = -1;
			if (num4 >= 33088 && num4 <= 40956)
			{
				num5 = num4 - 33088;
			}
			else if (num4 >= 57408 && num4 <= 60351)
			{
				num5 = num4 - 49472;
			}
			if (num5 == -1)
			{
				throw new z0ZzZziij("Invalid byte sequence");
			}
			int p2 = (num5 >> 8) * 192 + (num5 & 0xFF);
			p1.z0eek(p2, 13);
		}
	}

	internal static void z0eek(int p0, int p1, z0ZzZzgij p2, z0ZzZzdij p3)
	{
		int num = p2.z0eek(z0ZzZzfij.z0eek(p1));
		if (p0 > (1 << num) - 1)
		{
			throw new z0ZzZziij(p0 + "is bigger than" + ((1 << num) - 1));
		}
		p3.z0eek(p0, num);
	}

	internal static void z0eek(z0ZzZzgij p0, z0ZzZzdij p1)
	{
		p1.z0eek(p0.z0eek(), 4);
	}

	internal static z0ZzZznuj z0eek(z0ZzZznuj p0, int p1)
	{
		int num = p0.z0eek();
		int[] array = new int[num + p1];
		for (int i = 0; i < num; i++)
		{
			array[i] = p0.z0eek(i);
		}
		new z0ZzZzlij(z0ZzZzxuj.z0pek).z0eek(array, p1);
		z0ZzZznuj z0ZzZznuj2 = new z0ZzZznuj(p1);
		for (int j = 0; j < p1; j++)
		{
			z0ZzZznuj2.z0eek(j, array[num + j]);
		}
		return z0ZzZznuj2;
	}

	private static bool z0eek(string p0)
	{
		sbyte[] array;
		try
		{
			array = z0ZzZztij.z0eek(z0ZzZzqik.z0iek("Shift_JIS").GetBytes(p0));
		}
		catch (IOException)
		{
			return false;
		}
		int num = array.Length;
		if (num % 2 != 0)
		{
			return false;
		}
		for (int i = 0; i < num; i += 2)
		{
			int num2 = array[i] & 0xFF;
			if ((num2 < 129 || num2 > 159) && (num2 < 224 || num2 > 235))
			{
				return false;
			}
		}
		return true;
	}

	public static void z0eek(string p0, z0ZzZzhij p1, Hashtable p2, z0ZzZzeij p3)
	{
		string text = ((p2 == null) ? null : ((string)p2[z0ZzZzkij.z0eek]));
		if (text == null)
		{
			text = "UTF-8";
		}
		z0ZzZzgij z0ZzZzgij2 = z0eek(p0, text);
		z0ZzZzdij z0ZzZzdij2 = new z0ZzZzdij();
		z0eek(p0, z0ZzZzgij2, z0ZzZzdij2, text);
		z0eek(z0ZzZzdij2.z0eek(), p1, z0ZzZzgij2, p3);
		z0ZzZzdij z0ZzZzdij3 = new z0ZzZzdij();
		if (z0ZzZzgij2 == z0ZzZzgij.z0pek && !"UTF-8".Equals(text))
		{
			z0ZzZzvuj z0ZzZzvuj2 = z0ZzZzvuj.z0eek(text);
			if (z0ZzZzvuj2 != null)
			{
				z0eek(z0ZzZzvuj2, z0ZzZzdij3);
			}
		}
		z0eek(z0ZzZzgij2, z0ZzZzdij3);
		z0eek(z0ZzZzgij2.Equals(z0ZzZzgij.z0pek) ? z0ZzZzdij2.z0eek() : p0.Length, p3.z0rek(), z0ZzZzgij2, z0ZzZzdij3);
		z0ZzZzdij3.z0rek(z0ZzZzdij2);
		z0eek(p3.z0oek(), z0ZzZzdij3);
		z0ZzZzdij z0ZzZzdij4 = new z0ZzZzdij();
		z0eek(z0ZzZzdij3, p3.z0yek(), p3.z0oek(), p3.z0uek(), z0ZzZzdij4);
		z0ZzZzbuj z0ZzZzbuj2 = new z0ZzZzbuj(p3.z0pek(), p3.z0pek());
		p3.z0iek(z0eek(z0ZzZzdij4, p3.z0eek(), p3.z0rek(), z0ZzZzbuj2));
		z0ZzZzwij.z0eek(z0ZzZzdij4, p3.z0eek(), p3.z0rek(), p3.z0mek(), z0ZzZzbuj2);
		p3.z0eek(z0ZzZzbuj2);
		if (!p3.z0iek())
		{
			throw new z0ZzZziij("Invalid QR code: " + p3.ToString());
		}
	}

	internal static void z0tek(string p0, z0ZzZzdij p1)
	{
		int length = p0.Length;
		int num = 0;
		while (num < length)
		{
			int num2 = z0eek(p0[num]);
			if (num2 == -1)
			{
				throw new z0ZzZziij();
			}
			if (num + 1 < length)
			{
				int num3 = z0eek(p0[num + 1]);
				if (num3 == -1)
				{
					throw new z0ZzZziij();
				}
				p1.z0eek(num2 * 45 + num3, 11);
				num += 2;
			}
			else
			{
				p1.z0eek(num2, 6);
				num++;
			}
		}
	}
}
