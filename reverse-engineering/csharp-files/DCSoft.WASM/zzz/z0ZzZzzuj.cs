using System;
using System.Text;

namespace zzz;

internal sealed class z0ZzZzzuj
{
	private int[] z0yek;

	private z0ZzZzxuj z0uek;

	internal z0ZzZzzuj z0eek(z0ZzZzzuj p0)
	{
		if (!z0uek.Equals(p0.z0uek))
		{
			throw new ArgumentException("GF256Polys do not have same GF256 field");
		}
		if (z0rek())
		{
			return p0;
		}
		if (p0.z0rek())
		{
			return this;
		}
		int[] array = z0yek;
		int[] array2 = p0.z0yek;
		if (array.Length > array2.Length)
		{
			int[] array3 = array;
			array = array2;
			array2 = array3;
		}
		int[] array4 = new int[array2.Length];
		int num = array2.Length - array.Length;
		Array.Copy(array2, 0, array4, 0, num);
		for (int i = num; i < array2.Length; i++)
		{
			array4[i] = z0ZzZzxuj.z0rek(array[i - num], array2[i]);
		}
		return new z0ZzZzzuj(z0uek, array4);
	}

	internal int z0eek()
	{
		return z0yek.Length - 1;
	}

	internal int z0eek(int p0)
	{
		return z0yek[z0yek.Length - 1 - p0];
	}

	internal z0ZzZzzuj z0eek(int p0, int p1)
	{
		if (p0 < 0)
		{
			throw new ArgumentException();
		}
		if (p1 == 0)
		{
			return z0uek.z0eek();
		}
		int num = z0yek.Length;
		int[] array = new int[num + p0];
		for (int i = 0; i < num; i++)
		{
			array[i] = z0uek.z0eek(z0yek[i], p1);
		}
		return new z0ZzZzzuj(z0uek, array);
	}

	internal z0ZzZzzuj z0rek(z0ZzZzzuj p0)
	{
		if (!z0uek.Equals(p0.z0uek))
		{
			throw new ArgumentException("GF256Polys do not have same GF256 field");
		}
		if (z0rek() || p0.z0rek())
		{
			return z0uek.z0eek();
		}
		int[] array = z0yek;
		int num = array.Length;
		int[] array2 = p0.z0yek;
		int num2 = array2.Length;
		int[] array3 = new int[num + num2 - 1];
		for (int i = 0; i < num; i++)
		{
			int p1 = array[i];
			for (int j = 0; j < num2; j++)
			{
				array3[i + j] = z0ZzZzxuj.z0rek(array3[i + j], z0uek.z0eek(p1, array2[j]));
			}
		}
		return new z0ZzZzzuj(z0uek, array3);
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder(8 * z0eek());
		for (int num = z0eek(); num >= 0; num--)
		{
			int num2 = z0eek(num);
			if (num2 != 0)
			{
				if (num2 < 0)
				{
					stringBuilder.Append(" - ");
					num2 = -num2;
				}
				else if (stringBuilder.Length > 0)
				{
					stringBuilder.Append(" + ");
				}
				if (num == 0 || num2 != 1)
				{
					int num3 = z0uek.z0rek(num2);
					switch (num3)
					{
					case 0:
						stringBuilder.Append('1');
						break;
					case 1:
						stringBuilder.Append('a');
						break;
					default:
						stringBuilder.Append("a^");
						stringBuilder.Append(num3);
						break;
					}
				}
				switch (num)
				{
				case 1:
					stringBuilder.Append('x');
					break;
				default:
					stringBuilder.Append("x^");
					stringBuilder.Append(num);
					break;
				case 0:
					break;
				}
			}
		}
		return stringBuilder.ToString();
	}

	internal z0ZzZzzuj(z0ZzZzxuj p0, int[] p1)
	{
		if (p1 == null || p1.Length == 0)
		{
			throw new ArgumentException();
		}
		z0uek = p0;
		int num = p1.Length;
		if (num > 1 && p1[0] == 0)
		{
			int i;
			for (i = 1; i < num && p1[i] == 0; i++)
			{
			}
			if (i == num)
			{
				z0yek = p0.z0eek().z0yek;
				return;
			}
			z0yek = new int[num - i];
			Array.Copy(p1, i, z0yek, 0, z0yek.Length);
		}
		else
		{
			z0yek = p1;
		}
	}

	internal bool z0rek()
	{
		return z0yek[0] == 0;
	}

	internal int[] z0tek()
	{
		return z0yek;
	}

	internal z0ZzZzzuj[] z0tek(z0ZzZzzuj p0)
	{
		if (!z0uek.Equals(p0.z0uek))
		{
			throw new ArgumentException("GF256Polys do not have same GF256 field");
		}
		if (p0.z0rek())
		{
			throw new ArgumentException("Divide by 0");
		}
		z0ZzZzzuj z0ZzZzzuj2 = z0uek.z0eek();
		z0ZzZzzuj z0ZzZzzuj3 = this;
		int p1 = p0.z0eek(p0.z0eek());
		int p2 = z0uek.z0tek(p1);
		while (z0ZzZzzuj3.z0eek() >= p0.z0eek() && !z0ZzZzzuj3.z0rek())
		{
			int p3 = z0ZzZzzuj3.z0eek() - p0.z0eek();
			int p4 = z0uek.z0eek(z0ZzZzzuj3.z0eek(z0ZzZzzuj3.z0eek()), p2);
			z0ZzZzzuj p5 = p0.z0eek(p3, p4);
			z0ZzZzzuj p6 = z0uek.z0tek(p3, p4);
			z0ZzZzzuj2 = z0ZzZzzuj2.z0eek(p6);
			z0ZzZzzuj3 = z0ZzZzzuj3.z0eek(p5);
		}
		return new z0ZzZzzuj[2] { z0ZzZzzuj2, z0ZzZzzuj3 };
	}
}
