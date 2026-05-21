using System;
using System.Collections.Generic;
using DCSystem_Drawing;

namespace zzz;

public static class z0ZzZzjmk
{
	public static z0ZzZzpdh[] z0eek(z0ZzZzbdh p0)
	{
		return new z0ZzZzpdh[4]
		{
			new z0ZzZzpdh(p0.z0tek(), p0.z0yek()),
			new z0ZzZzpdh(p0.z0mek(), p0.z0yek()),
			new z0ZzZzpdh(p0.z0mek(), p0.z0nek()),
			new z0ZzZzpdh(p0.z0oek(), p0.z0nek())
		};
	}

	public static z0ZzZzpdh z0rek(z0ZzZzbdh p0)
	{
		return new z0ZzZzpdh(p0.z0oek() + p0.z0uek() / 2f, p0.z0pek() + p0.z0iek() / 2f);
	}

	public static z0ZzZzbdh z0eek(z0ZzZzbdh p0, float p1, float p2, StringAlignment p3, StringAlignment p4)
	{
		float p5 = p0.z0oek();
		float p6 = p0.z0pek();
		switch (p3)
		{
		case StringAlignment.Near:
			p5 = p0.z0oek();
			break;
		case StringAlignment.Center:
			p5 = p0.z0oek() + (p0.z0uek() - p1) / 2f;
			break;
		case StringAlignment.Far:
			p5 = p0.z0mek() - p1;
			break;
		}
		switch (p4)
		{
		case StringAlignment.Near:
			p6 = p0.z0pek();
			break;
		case StringAlignment.Center:
			p6 = p0.z0pek() + (p0.z0iek() - p2) / 2f;
			break;
		case StringAlignment.Far:
			p6 = p0.z0nek() - p2;
			break;
		}
		return new z0ZzZzbdh(p5, p6, p1, p2);
	}

	public static z0ZzZzpdh z0eek(z0ZzZzpdh p0, z0ZzZzbdh p1)
	{
		if (!p1.z0bek())
		{
			if (p0.z0rek() < p1.z0oek())
			{
				p0.z0eek(p1.z0oek());
			}
			if (p0.z0rek() >= p1.z0mek())
			{
				p0.z0eek(p1.z0mek());
			}
			if (p0.z0tek() < p1.z0pek())
			{
				p0.z0rek(p1.z0pek());
			}
			if (p0.z0tek() >= p1.z0nek())
			{
				p0.z0rek(p1.z0nek());
			}
		}
		return p0;
	}

	public static z0ZzZzbdh z0eek(z0ZzZzbdh p0, float p1, float p2, ContentAlignment p3)
	{
		z0ZzZzbdh result = new z0ZzZzbdh(0f, 0f, p1, p2);
		switch (p3)
		{
		case ContentAlignment.BottomCenter:
			result.z0eek(p0.z0oek() + (p0.z0uek() - result.z0uek()) / 2f);
			result.z0rek(p0.z0nek() - result.z0iek());
			break;
		case ContentAlignment.BottomLeft:
			result.z0eek(p0.z0oek());
			result.z0rek(p0.z0nek() - result.z0iek());
			break;
		case ContentAlignment.BottomRight:
			result.z0eek(p0.z0mek() - result.z0uek());
			result.z0rek(p0.z0nek() - result.z0iek());
			break;
		case ContentAlignment.MiddleCenter:
			result.z0eek(p0.z0oek() + (p0.z0uek() - result.z0uek()) / 2f);
			result.z0rek(p0.z0pek() + (p0.z0iek() - result.z0iek()) / 2f);
			break;
		case ContentAlignment.MiddleLeft:
			result.z0eek(p0.z0oek());
			result.z0rek(p0.z0pek() + (p0.z0iek() - result.z0iek()) / 2f);
			break;
		case ContentAlignment.MiddleRight:
			result.z0eek(p0.z0mek() - result.z0uek());
			result.z0rek(p0.z0pek() + (p0.z0iek() - result.z0iek()) / 2f);
			break;
		case ContentAlignment.TopCenter:
			result.z0eek(p0.z0oek() + (p0.z0uek() - result.z0uek()) / 2f);
			result.z0rek(p0.z0pek());
			break;
		case ContentAlignment.TopLeft:
			result.z0eek(p0.z0oek());
			result.z0rek(p0.z0pek());
			break;
		case ContentAlignment.TopRight:
			result.z0eek(p0.z0mek() - result.z0uek());
			result.z0rek(p0.z0pek());
			break;
		default:
			result.z0eek(p0.z0oek());
			result.z0rek(p0.z0pek());
			break;
		}
		return result;
	}

	public static z0ZzZzpdh[] z0eek(z0ZzZzpdh p0, z0ZzZzbdh p1, double p2)
	{
		z0ZzZzpdh[] array = z0eek(p1);
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = z0ZzZzmpk.z0eek(p0, array[i], p2);
		}
		return array;
	}

	public static z0ZzZzbdh z0eek(z0ZzZzbdh p0, float p1)
	{
		if (p0.z0uek() == 0f || p0.z0iek() == 0f)
		{
			return z0ZzZzbdh.z0xek;
		}
		if (p1 <= 0f)
		{
			return z0ZzZzbdh.z0xek;
		}
		if (p1 > p0.z0uek() / p0.z0iek())
		{
			z0ZzZzbdh result = new z0ZzZzbdh(p0.z0oek(), p0.z0pek(), p0.z0uek(), p0.z0uek() / p1);
			result.z0rek(p0.z0pek() + (p0.z0iek() - result.z0iek()) / 2f);
			return result;
		}
		z0ZzZzbdh result2 = new z0ZzZzbdh(p0.z0oek(), p0.z0pek(), p0.z0iek() * p1, p0.z0iek());
		result2.z0eek(p0.z0oek() + (p0.z0uek() - result2.z0uek()) / 2f);
		return result2;
	}

	public static z0ZzZzbdh z0eek(z0ZzZzpdh[] p0)
	{
		if (p0 != null && p0.Length > 1)
		{
			float num = p0[0].z0rek();
			float num2 = p0[0].z0rek();
			float num3 = p0[0].z0tek();
			float num4 = p0[0].z0tek();
			for (int i = 0; i < p0.Length; i++)
			{
				if (num < p0[i].z0rek())
				{
					num = p0[i].z0rek();
				}
				if (num2 > p0[i].z0rek())
				{
					num2 = p0[i].z0rek();
				}
				if (num3 < p0[i].z0tek())
				{
					num3 = p0[i].z0tek();
				}
				if (num4 > p0[i].z0tek())
				{
					num4 = p0[i].z0tek();
				}
			}
			return new z0ZzZzbdh(num2, num4, num - num2, num3 - num4);
		}
		return z0ZzZzbdh.z0xek;
	}

	public static z0ZzZzbdh z0tek(z0ZzZzbdh p0)
	{
		if (p0.z0uek() == p0.z0iek())
		{
			return p0;
		}
		if (p0.z0uek() > p0.z0iek())
		{
			return new z0ZzZzbdh(p0.z0oek() + (p0.z0uek() - p0.z0iek()) / 2f, p0.z0pek(), p0.z0iek(), p0.z0iek());
		}
		return new z0ZzZzbdh(p0.z0oek(), p0.z0pek() + (p0.z0iek() - p0.z0uek()) / 2f, p0.z0uek(), p0.z0uek());
	}

	public static z0ZzZzndh z0eek(z0ZzZzodh p0, z0ZzZzodh p1)
	{
		return z0eek(p0.z0rek(), p0.z0tek(), p1.z0rek(), p1.z0tek());
	}

	public static z0ZzZzndh z0eek(int p0, int p1, int p2, int p3)
	{
		z0ZzZzndh z0cek = z0ZzZzndh.z0cek;
		if (p0 < p2)
		{
			z0cek.z0eek(p0);
			z0cek.z0tek(p2 - p0);
		}
		else
		{
			z0cek.z0eek(p2);
			z0cek.z0tek(p0 - p2);
		}
		if (p1 < p3)
		{
			z0cek.z0rek(p1);
			z0cek.z0yek(p3 - p1);
		}
		else
		{
			z0cek.z0rek(p3);
			z0cek.z0yek(p1 - p3);
		}
		if (z0cek.z0iek() < 1)
		{
			z0cek.z0tek(1);
		}
		if (z0cek.z0oek() < 1)
		{
			z0cek.z0yek(1);
		}
		return z0cek;
	}

	public static int z0eek(z0ZzZzbdh p0, float p1, float p2)
	{
		if (p0.z0eek(p1, p2))
		{
			return 0;
		}
		if (p2 < p0.z0pek())
		{
			if (p1 < p0.z0oek())
			{
				return 1;
			}
			if (p1 < p0.z0mek())
			{
				return 2;
			}
			return 3;
		}
		if (p2 < p0.z0nek())
		{
			if (p1 < p0.z0oek())
			{
				return 8;
			}
			if (p1 < p0.z0mek())
			{
				return 0;
			}
			return 4;
		}
		if (p1 < p0.z0oek())
		{
			return 7;
		}
		if (p1 < p0.z0mek())
		{
			return 6;
		}
		return 5;
	}

	public static z0ZzZzodh z0eek(z0ZzZzodh p0, z0ZzZzndh p1)
	{
		if (!p1.z0vek())
		{
			if (p0.z0rek() < p1.z0pek())
			{
				p0.z0eek(p1.z0pek());
			}
			if (p0.z0rek() >= p1.z0nek())
			{
				p0.z0eek(p1.z0nek());
			}
			if (p0.z0tek() < p1.z0mek())
			{
				p0.z0rek(p1.z0mek());
			}
			if (p0.z0tek() >= p1.z0bek())
			{
				p0.z0rek(p1.z0bek());
			}
		}
		return p0;
	}

	public static z0ZzZzbdh[] z0eek(z0ZzZzbdh[] p0)
	{
		if (p0 == null || p0.Length <= 1)
		{
			return p0;
		}
		List<z0ZzZzbdh> list = new List<z0ZzZzbdh>();
		for (int i = 0; i < p0.Length; i++)
		{
			z0ZzZzbdh z0ZzZzbdh2 = p0[i];
			if (z0ZzZzbdh2.z0bek())
			{
				continue;
			}
			z0ZzZzbdh z0ZzZzbdh3 = z0ZzZzbdh2;
			bool flag = true;
			for (int j = 0; j < list.Count; j++)
			{
				z0ZzZzbdh z0ZzZzbdh4 = list[j];
				if (z0ZzZzbdh4.z0eek(z0ZzZzbdh3))
				{
					flag = false;
					break;
				}
				if (z0ZzZzbdh3.z0eek(z0ZzZzbdh4))
				{
					list[j] = z0ZzZzbdh3;
					flag = false;
					break;
				}
				if (z0ZzZzbdh3.z0pek() == z0ZzZzbdh4.z0pek() && z0ZzZzbdh3.z0iek() == z0ZzZzbdh4.z0iek())
				{
					if (z0ZzZzbdh3.z0tek(z0ZzZzbdh4) || z0ZzZzbdh3.z0oek() == z0ZzZzbdh4.z0mek() || z0ZzZzbdh3.z0oek() == z0ZzZzbdh4.z0mek() + 1f || z0ZzZzbdh3.z0mek() == z0ZzZzbdh4.z0oek() || z0ZzZzbdh3.z0mek() == z0ZzZzbdh4.z0oek() - 1f)
					{
						list[j] = z0ZzZzbdh.z0yek(z0ZzZzbdh3, z0ZzZzbdh4);
						flag = false;
						break;
					}
				}
				else if (z0ZzZzbdh3.z0oek() == z0ZzZzbdh4.z0oek() && z0ZzZzbdh3.z0uek() == z0ZzZzbdh4.z0uek() && (z0ZzZzbdh3.z0tek(z0ZzZzbdh4) || z0ZzZzbdh3.z0pek() == z0ZzZzbdh4.z0nek() || z0ZzZzbdh3.z0pek() == z0ZzZzbdh4.z0nek() + 1f || z0ZzZzbdh3.z0nek() == z0ZzZzbdh4.z0pek() || z0ZzZzbdh3.z0nek() == z0ZzZzbdh4.z0pek() - 1f))
				{
					list[j] = z0ZzZzbdh.z0yek(z0ZzZzbdh3, z0ZzZzbdh4);
					flag = false;
					break;
				}
			}
			if (flag)
			{
				list.Add(z0ZzZzbdh3);
			}
		}
		return list.ToArray();
	}

	public static z0ZzZzbdh z0eek(z0ZzZzbdh p0, float p1, float p2, float p3, float p4)
	{
		float num = p1 + (p0.z0tek() - p1) * p3;
		float num2 = p2 + (p0.z0yek() - p2) * p4;
		float num3 = p1 + (p0.z0mek() - p1) * p3;
		float num4 = p2 + (p0.z0nek() - p2) * p4;
		return new z0ZzZzbdh(num, num2, num3 - num, num4 - num2);
	}

	public static float z0eek(float p0, float p1, z0ZzZzbdh p2)
	{
		float result = 0f;
		switch (z0eek(p2, p0, p1))
		{
		case 0:
		{
			result = Math.Min(p0 - p2.z0oek(), p2.z0mek() - p0);
			float num = Math.Min(p1 - p2.z0pek(), p2.z0nek() - p1);
			result = 0f - Math.Min(result, num);
			break;
		}
		case 1:
			result = (float)Math.Sqrt((p0 - p2.z0oek()) * (p0 - p2.z0oek()) + (p1 - p2.z0pek()) * (p1 - p2.z0pek()));
			break;
		case 2:
			result = p2.z0pek() - p1;
			break;
		case 3:
			result = (float)Math.Sqrt((p0 - p2.z0mek()) * (p0 - p2.z0mek()) + (p1 - p2.z0pek()) * (p1 - p2.z0pek()));
			break;
		case 4:
			result = p0 - p2.z0mek();
			break;
		case 5:
			result = (float)Math.Sqrt((p0 - p2.z0mek()) * (p0 - p2.z0mek()) + (p1 - p2.z0nek()) * (p1 - p2.z0nek()));
			break;
		case 6:
			result = p1 - p2.z0nek();
			break;
		case 7:
			result = (float)Math.Sqrt((p0 - p2.z0oek()) * (p0 - p2.z0oek()) + (p1 - p2.z0nek()) * (p1 - p2.z0nek()));
			break;
		case 8:
			result = p2.z0oek() - p0;
			break;
		}
		return result;
	}
}
