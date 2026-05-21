using System;
using System.Collections;

namespace zzz;

internal sealed class z0ZzZzrij : z0ZzZzuij
{
	private static z0ZzZzbuj z0eek(z0ZzZzeij p0, int p1, int p2)
	{
		z0ZzZzbuj z0ZzZzbuj2 = p0.z0tek();
		int num = z0ZzZzbuj2.z0tek();
		int num2 = z0ZzZzbuj2.z0rek();
		int num3 = num + 8;
		int num4 = num2 + 8;
		int num5 = Math.Max(p1, num3);
		int num6 = Math.Max(p2, num4);
		int num7 = Math.Min(num5 / num3, num6 / num4);
		int num8 = (num5 - num * num7) / 2;
		int num9 = (num6 - num2 * num7) / 2;
		z0ZzZzbuj z0ZzZzbuj3 = new z0ZzZzbuj(num5, num6);
		sbyte[][] array = z0ZzZzbuj3.z0eek();
		sbyte[] array2 = new sbyte[num5];
		for (int i = 0; i < num9; i++)
		{
			z0eek(array[i], (sbyte)z0ZzZztij.z0eek(255L));
		}
		sbyte[][] array3 = z0ZzZzbuj2.z0eek();
		for (int j = 0; j < num2; j++)
		{
			for (int k = 0; k < num8; k++)
			{
				array2[k] = (sbyte)z0ZzZztij.z0eek(255L);
			}
			int num10 = num8;
			for (int l = 0; l < num; l++)
			{
				sbyte b = (sbyte)((array3[j][l] == 1) ? 0 : z0ZzZztij.z0eek(255L));
				for (int m = 0; m < num7; m++)
				{
					array2[num10 + m] = b;
				}
				num10 += num7;
			}
			num10 = num8 + num * num7;
			for (int n = num10; n < num5; n++)
			{
				array2[n] = (sbyte)z0ZzZztij.z0eek(255L);
			}
			num10 = num9 + j * num7;
			for (int num11 = 0; num11 < num7; num11++)
			{
				Array.Copy(array2, 0, array[num10 + num11], 0, num5);
			}
		}
		for (int num12 = num9 + num2 * num7; num12 < num6; num12++)
		{
			z0eek(array[num12], (sbyte)z0ZzZztij.z0eek(255L));
		}
		return z0ZzZzbuj3;
	}

	public z0ZzZzcdh z0eek(string p0, z0ZzZzmuj p1, int p2, int p3, Hashtable p4)
	{
		if (p0 == null || p0.Length == 0)
		{
			throw new ArgumentException("Found empty contents");
		}
		if (p1 != z0ZzZzmuj.z0yek)
		{
			throw new ArgumentException("Can only encode QR_CODE, but got " + p1);
		}
		if (p2 < 0 || p3 < 0)
		{
			throw new ArgumentException("Requested dimensions are too small: " + p2 + "x" + p3);
		}
		z0ZzZzhij p5 = z0ZzZzhij.z0uek;
		if (p4 != null)
		{
			z0ZzZzhij z0ZzZzhij2 = (z0ZzZzhij)p4[z0ZzZzkij.z0rek_jiejie20260327142557];
			if (z0ZzZzhij2 != null)
			{
				p5 = z0ZzZzhij2;
			}
		}
		z0ZzZzeij z0ZzZzeij2 = new z0ZzZzeij();
		z0ZzZzaij.z0eek(p0, p5, p4, z0ZzZzeij2);
		return z0rek(z0ZzZzeij2, p2, p3);
	}

	public z0ZzZzbuj z0pkk(string p0, z0ZzZzmuj p1, int p2, int p3, Hashtable p4)
	{
		if (p0 == null || p0.Length == 0)
		{
			throw new ArgumentException("Found empty contents");
		}
		if (p1 != z0ZzZzmuj.z0yek)
		{
			throw new ArgumentException("Can only encode QR_CODE, but got " + p1);
		}
		if (p2 < 0 || p3 < 0)
		{
			throw new ArgumentException("Requested dimensions are too small: " + p2 + "x" + p3);
		}
		z0ZzZzhij p5 = z0ZzZzhij.z0uek;
		if (p4 != null)
		{
			z0ZzZzhij z0ZzZzhij2 = (z0ZzZzhij)p4[z0ZzZzkij.z0rek_jiejie20260327142557];
			if (z0ZzZzhij2 != null)
			{
				p5 = z0ZzZzhij2;
			}
		}
		z0ZzZzeij z0ZzZzeij2 = new z0ZzZzeij();
		z0ZzZzaij.z0eek(p0, p5, p4, z0ZzZzeij2);
		return z0eek(z0ZzZzeij2, p2, p3);
	}

	private static void z0eek(sbyte[] p0, sbyte p1)
	{
		for (int i = 0; i < p0.Length; i++)
		{
			p0[i] = p1;
		}
	}

	private static z0ZzZzcdh z0rek(z0ZzZzeij p0, int p1, int p2)
	{
		z0ZzZzbuj obj = p0.z0tek();
		int num = obj.z0tek();
		int num2 = obj.z0rek();
		int num3 = num + 8;
		int num4 = num2 + 8;
		int num5 = Math.Max(p1, num3);
		int num6 = Math.Max(p2, num4);
		int num7 = Math.Min(num5 / num3, num6 / num4);
		if (num7 <= 0)
		{
			num7 = 1;
		}
		return new z0ZzZzcdh(num * num7, num2 * num7);
	}
}
