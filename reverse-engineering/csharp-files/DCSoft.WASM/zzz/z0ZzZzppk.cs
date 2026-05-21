using System;
using System.Collections.Generic;
using DCSystem_Drawing;
using DCSystem_Drawing.Drawing2D;

namespace zzz;

public class z0ZzZzppk : IDisposable
{
	private class z0pvk : IComparer<z0mvk_jiejie20260327142557>
	{
		public static readonly z0pvk z0eek = new z0pvk();

		public int Compare(z0mvk_jiejie20260327142557 x, z0mvk_jiejie20260327142557 y)
		{
			if (x.z0lrk != y.z0lrk)
			{
				if (x.z0lrk)
				{
					return -1;
				}
				return 1;
			}
			int num = x.z0iek - y.z0iek;
			if (num == 0)
			{
				num = x.z0nek - y.z0nek;
			}
			return num;
		}
	}

	public class z0mvk_jiejie20260327142557
	{
		public float z0tek = 1f;

		public float z0yek = 0f / 0f;

		public float z0uek = 0f / 0f;

		public int z0iek;

		public Color z0oek = z0cek;

		private static readonly List<z0mvk_jiejie20260327142557> z0pek = new List<z0mvk_jiejie20260327142557>();

		public DashStyle z0mek;

		public int z0nek;

		public string z0bek;

		public float z0vek = 0f / 0f;

		private static readonly Color z0cek = Color.Black;

		public long z0xek;

		public float z0zek = 0f / 0f;

		public bool z0lrk;

		public static long z0rek(bool p0, Color p1, DashStyle p2, float p3, int p4)
		{
			if (p0)
			{
				return -2147483648L;
			}
			return (((long)((ulong)p1._value << 4) + (long)p2 << 8) + (int)(p3 * 2f) << 1) + p4;
		}

		private z0mvk_jiejie20260327142557()
		{
		}

		public static void z0eek(List<z0mvk_jiejie20260327142557> p0)
		{
			z0pek.AddRange(p0);
		}

		public static z0mvk_jiejie20260327142557 z0rek()
		{
			if (z0pek.Count > 0)
			{
				int num = z0pek.Count - 1;
				z0mvk_jiejie20260327142557 result = z0pek[num];
				z0pek.RemoveAt(num);
				return result;
			}
			return new z0mvk_jiejie20260327142557();
		}
	}

	private int z0rek = -1;

	private bool z0tek;

	private static int z0yek = 0;

	private static int z0uek = 0;

	private List<z0mvk_jiejie20260327142557> z0iek = new List<z0mvk_jiejie20260327142557>();

	private static int z0oek = 0;

	private static readonly int z0pek = Color.White.ToArgb();

	private List<z0mvk_jiejie20260327142557> z0mek = new List<z0mvk_jiejie20260327142557>();

	public void z0eek(z0ZzZzbdh p0, bool p1, bool p2, bool p3, bool p4, Color p5, float p6, DashStyle p7, int p8, bool p9)
	{
		if (!(p0.z0uek() <= 0f) && !(p0.z0iek() <= 0f))
		{
			if (p1)
			{
				z0eek(p0.z0oek(), p0.z0pek(), p0.z0oek(), p0.z0nek(), p5, p6, p7, p8, p9);
			}
			if (p2)
			{
				z0eek(p0.z0oek(), p0.z0pek(), p0.z0mek(), p0.z0pek(), p5, p6, p7, p8, p9);
			}
			if (p3)
			{
				z0eek(p0.z0mek(), p0.z0pek(), p0.z0mek(), p0.z0nek(), p5, p6, p7, p8, p9);
			}
			if (p4)
			{
				z0eek(p0.z0oek(), p0.z0nek(), p0.z0mek(), p0.z0nek(), p5, p6, p7, p8, p9);
			}
		}
	}

	public void Dispose()
	{
		if (z0iek != null)
		{
			z0mvk_jiejie20260327142557.z0eek(z0iek);
			z0iek.Clear();
			z0iek = null;
		}
		if (z0mek != null)
		{
			z0mvk_jiejie20260327142557.z0eek(z0mek);
			z0mek.Clear();
			z0mek = null;
		}
	}

	private static int z0eek(z0mvk_jiejie20260327142557[] p0, int p1, int p2)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("items");
		}
		if (p1 < 0)
		{
			throw new ArgumentOutOfRangeException("startIndex=" + p1);
		}
		if (p2 < 0)
		{
			throw new ArgumentOutOfRangeException("length=" + p2);
		}
		if (p1 + p2 > p0.Length)
		{
			throw new ArgumentOutOfRangeException("startIndex+length>=" + p0.Length);
		}
		if (p2 == 0)
		{
			return 0;
		}
		int num = 0;
		int num2 = p1 + p2 - 1;
		for (int i = p1; i <= num2; i++)
		{
			if (p0[i] == null)
			{
				num++;
			}
			else if (num > 0)
			{
				p0[i - num] = p0[i];
				p0[i] = null;
			}
		}
		return p2 - num;
	}

	public void z0eek(float p0, float p1, float p2, float p3, Color p4, float p5, DashStyle p6, int p7, bool p8)
	{
		z0oek++;
		if (p7 != 0)
		{
			z0tek = true;
		}
		long num = z0mvk_jiejie20260327142557.z0rek(p8, p4, p6, p5, p7);
		if (p1 == p3)
		{
			if (p0 > p2)
			{
				float num2 = p0;
				p0 = p2;
				p2 = num2;
			}
			z0mvk_jiejie20260327142557 z0mvk_jiejie20260327142557 = null;
			List<z0mvk_jiejie20260327142557> list = z0iek;
			if (p8 || p4 == Color.White)
			{
				float num3 = -1f;
				for (int num4 = list.Count - 1; num4 >= 0; num4--)
				{
					z0mvk_jiejie20260327142557 z0mvk_jiejie202603271425572 = list[num4];
					if (z0mvk_jiejie202603271425572.z0vek == p1 && z0mvk_jiejie202603271425572.z0iek == p7 && !z0mvk_jiejie202603271425572.z0lrk && z0mvk_jiejie202603271425572.z0oek != Color.White)
					{
						if (z0mvk_jiejie202603271425572.z0uek <= p0 && z0mvk_jiejie202603271425572.z0yek >= p2)
						{
							z0uek++;
							return;
						}
					}
					else if (z0mvk_jiejie202603271425572.z0vek < p1)
					{
						if (num3 > 0f)
						{
							if (z0mvk_jiejie202603271425572.z0vek < num3)
							{
								break;
							}
						}
						else
						{
							num3 = z0mvk_jiejie202603271425572.z0vek;
						}
					}
				}
			}
			for (int num5 = list.Count - 1; num5 >= 0; num5--)
			{
				z0mvk_jiejie20260327142557 z0mvk_jiejie202603271425573 = list[num5];
				if (z0mvk_jiejie202603271425573.z0vek == p1 && z0mvk_jiejie202603271425573.z0iek == p7)
				{
					z0mvk_jiejie20260327142557 = z0mvk_jiejie202603271425573;
					break;
				}
			}
			if (z0mvk_jiejie20260327142557 != null)
			{
				if (z0mvk_jiejie20260327142557.z0xek == num)
				{
					if (z0mvk_jiejie20260327142557.z0yek == p0)
					{
						z0mvk_jiejie20260327142557.z0yek = p2;
						z0uek++;
						return;
					}
					if (z0mvk_jiejie20260327142557.z0uek <= p0 && p2 <= z0mvk_jiejie20260327142557.z0yek)
					{
						z0uek++;
						return;
					}
				}
				else if (z0mvk_jiejie20260327142557.z0uek <= p0 && p2 <= z0mvk_jiejie20260327142557.z0yek)
				{
					if (p8)
					{
						z0uek++;
						return;
					}
					if (p4 == Color.White && z0mvk_jiejie20260327142557.z0oek != Color.White)
					{
						z0uek++;
						return;
					}
				}
			}
			z0mvk_jiejie20260327142557 z0mvk_jiejie202603271425574 = z0mvk_jiejie20260327142557.z0rek();
			z0mvk_jiejie202603271425574.z0uek = p0;
			z0mvk_jiejie202603271425574.z0yek = p2;
			z0mvk_jiejie202603271425574.z0vek = p1;
			z0mvk_jiejie202603271425574.z0zek = p3;
			z0mvk_jiejie202603271425574.z0oek = p4;
			z0mvk_jiejie202603271425574.z0tek = p5;
			z0mvk_jiejie202603271425574.z0mek = p6;
			z0mvk_jiejie202603271425574.z0iek = p7;
			z0mvk_jiejie202603271425574.z0lrk = p8;
			z0mvk_jiejie202603271425574.z0xek = num;
			list.Add(z0mvk_jiejie202603271425574);
			return;
		}
		if (p1 > p3)
		{
			float num6 = p1;
			p1 = p3;
			p3 = num6;
		}
		List<z0mvk_jiejie20260327142557> list2 = z0mek;
		z0mvk_jiejie20260327142557 z0mvk_jiejie202603271425575 = null;
		if (z0rek >= 0)
		{
			int num7 = Math.Max(0, z0rek - 2);
			for (int num8 = Math.Min(list2.Count - 1, z0rek + 4); num8 >= num7; num8--)
			{
				z0mvk_jiejie20260327142557 z0mvk_jiejie202603271425576 = list2[num8];
				if (z0mvk_jiejie202603271425576.z0uek == p0 && z0mvk_jiejie202603271425576.z0iek == p7)
				{
					z0yek++;
					z0mvk_jiejie202603271425575 = z0mvk_jiejie202603271425576;
					break;
				}
			}
		}
		if (z0mvk_jiejie202603271425575 == null)
		{
			for (int num9 = list2.Count - 1; num9 >= 0; num9--)
			{
				z0mvk_jiejie20260327142557 z0mvk_jiejie202603271425577 = list2[num9];
				if (z0mvk_jiejie202603271425577.z0uek == p0 && z0mvk_jiejie202603271425577.z0iek == p7)
				{
					z0mvk_jiejie202603271425575 = z0mvk_jiejie202603271425577;
					z0rek = num9;
					break;
				}
			}
		}
		if (z0mvk_jiejie202603271425575 != null)
		{
			if (z0mvk_jiejie202603271425575.z0xek == num)
			{
				if (z0mvk_jiejie202603271425575.z0zek == p1)
				{
					z0mvk_jiejie202603271425575.z0zek = p3;
					z0uek++;
					return;
				}
				if (z0mvk_jiejie202603271425575.z0vek <= p1 && p3 <= z0mvk_jiejie202603271425575.z0zek)
				{
					z0uek++;
					return;
				}
			}
			if (z0mvk_jiejie202603271425575.z0vek <= p1 && p3 <= z0mvk_jiejie202603271425575.z0zek)
			{
				if (p8)
				{
					z0uek++;
					return;
				}
				if (p4 == Color.White && !z0mvk_jiejie202603271425575.z0lrk)
				{
					z0uek++;
					return;
				}
				if (z0mvk_jiejie202603271425575.z0lrk && z0mvk_jiejie202603271425575.z0vek == p1 && z0mvk_jiejie202603271425575.z0zek == p3 && !p8)
				{
					z0mvk_jiejie202603271425575.z0oek = p4;
					z0mvk_jiejie202603271425575.z0tek = p5;
					z0mvk_jiejie202603271425575.z0mek = p6;
					z0mvk_jiejie202603271425575.z0iek = p7;
					z0mvk_jiejie202603271425575.z0lrk = p8;
					z0mvk_jiejie202603271425575.z0xek = num;
					z0uek++;
					return;
				}
			}
			else if (p8 && z0mvk_jiejie202603271425575.z0vek <= p1 && p3 <= z0mvk_jiejie202603271425575.z0zek)
			{
				z0uek++;
				return;
			}
		}
		z0mvk_jiejie20260327142557 z0mvk_jiejie202603271425578 = z0mvk_jiejie20260327142557.z0rek();
		z0mvk_jiejie202603271425578.z0vek = p1;
		z0mvk_jiejie202603271425578.z0zek = p3;
		z0mvk_jiejie202603271425578.z0uek = p0;
		z0mvk_jiejie202603271425578.z0yek = p2;
		z0mvk_jiejie202603271425578.z0oek = p4;
		z0mvk_jiejie202603271425578.z0tek = p5;
		z0mvk_jiejie202603271425578.z0mek = p6;
		z0mvk_jiejie202603271425578.z0iek = p7;
		z0mvk_jiejie202603271425578.z0lrk = p8;
		z0mvk_jiejie202603271425578.z0xek = num;
		list2.Add(z0mvk_jiejie202603271425578);
	}

	public z0mvk_jiejie20260327142557[] z0eek(ref int p0, z0ZzZzbdh p1)
	{
		z0mvk_jiejie20260327142557[] array = z0iek.ToArray();
		int num = z0eek(array, p1, p2: true);
		if (z0tek)
		{
			for (int i = 0; i < num; i++)
			{
				array[i].z0nek = i;
			}
			Array.Sort(array, 0, num, z0pvk.z0eek);
		}
		z0mvk_jiejie20260327142557[] array2 = z0mek.ToArray();
		int num2 = z0eek(array2, p1, p2: false);
		if (z0tek)
		{
			for (int j = 0; j < num2; j++)
			{
				array2[j].z0nek = j;
			}
			Array.Sort(array2, 0, num2, z0pvk.z0eek);
		}
		z0mvk_jiejie20260327142557[] array3 = new z0mvk_jiejie20260327142557[num + num2];
		Array.Copy(array, array3, num);
		Array.Copy(array2, 0, array3, num, num2);
		p0 = num + num2;
		return array3;
	}

	private static int z0eek(z0mvk_jiejie20260327142557[] p0, bool p1)
	{
		int num = p0.Length;
		int num2 = 0;
		for (int num3 = num - 1; num3 >= 0; num3--)
		{
			z0mvk_jiejie20260327142557 z0mvk_jiejie20260327142557 = p0[num3];
			if (z0mvk_jiejie20260327142557.z0lrk || z0mvk_jiejie20260327142557.z0oek.ToArgb() == z0pek)
			{
				foreach (z0mvk_jiejie20260327142557 z0mvk_jiejie202603271425572 in p0)
				{
					if (z0mvk_jiejie202603271425572 == null || z0mvk_jiejie20260327142557 == z0mvk_jiejie202603271425572 || z0mvk_jiejie202603271425572.z0lrk || z0mvk_jiejie202603271425572.z0tek <= 0f)
					{
						continue;
					}
					if (p1)
					{
						if (z0mvk_jiejie20260327142557.z0vek == z0mvk_jiejie202603271425572.z0vek && z0mvk_jiejie202603271425572.z0uek <= z0mvk_jiejie20260327142557.z0uek && z0mvk_jiejie202603271425572.z0yek >= z0mvk_jiejie20260327142557.z0yek)
						{
							num2++;
							p0[num3] = null;
							break;
						}
					}
					else if (z0mvk_jiejie20260327142557.z0uek == z0mvk_jiejie202603271425572.z0uek && z0mvk_jiejie202603271425572.z0vek <= z0mvk_jiejie20260327142557.z0vek && z0mvk_jiejie202603271425572.z0zek >= z0mvk_jiejie20260327142557.z0zek)
					{
						num2++;
						p0[num3] = null;
						break;
					}
				}
				_ = 0;
			}
		}
		if (num2 > 0)
		{
			num = z0eek(p0, 0, num);
		}
		return num;
	}

	private static int z0eek(z0mvk_jiejie20260327142557[] p0, z0ZzZzbdh p1, bool p2)
	{
		int num = p0.Length;
		num = z0eek(p0, p2);
		float num2 = p1.z0pek() - 8f;
		float num3 = p1.z0oek() - 8f;
		float num4 = p1.z0mek() + 16f;
		float num5 = p1.z0nek() + 16f;
		bool flag = false;
		for (int num6 = num - 1; num6 > 0; num6--)
		{
			z0mvk_jiejie20260327142557 z0mvk_jiejie20260327142557 = p0[num6];
			if (p2)
			{
				if (z0mvk_jiejie20260327142557.z0vek < num2 || z0mvk_jiejie20260327142557.z0vek > num5)
				{
					p0[num6] = null;
					flag = true;
				}
				else
				{
					for (int num7 = num6 - 1; num7 >= 0; num7--)
					{
						z0mvk_jiejie20260327142557 z0mvk_jiejie202603271425572 = p0[num7];
						if (z0mvk_jiejie20260327142557.z0vek == z0mvk_jiejie202603271425572.z0vek && z0mvk_jiejie20260327142557.z0uek <= z0mvk_jiejie202603271425572.z0yek && z0mvk_jiejie20260327142557.z0yek >= z0mvk_jiejie202603271425572.z0uek)
						{
							if (z0mvk_jiejie20260327142557.z0xek == z0mvk_jiejie202603271425572.z0xek)
							{
								if (z0mvk_jiejie20260327142557.z0uek < z0mvk_jiejie202603271425572.z0uek)
								{
									z0mvk_jiejie202603271425572.z0uek = z0mvk_jiejie20260327142557.z0uek;
								}
								if (z0mvk_jiejie20260327142557.z0yek > z0mvk_jiejie202603271425572.z0yek)
								{
									z0mvk_jiejie202603271425572.z0yek = z0mvk_jiejie20260327142557.z0yek;
								}
								flag = true;
								p0[num6] = null;
							}
							else if (z0mvk_jiejie202603271425572.z0uek < z0mvk_jiejie20260327142557.z0uek)
							{
								z0mvk_jiejie202603271425572.z0yek = z0mvk_jiejie20260327142557.z0uek;
							}
							else if (z0mvk_jiejie202603271425572.z0yek > z0mvk_jiejie20260327142557.z0yek)
							{
								z0mvk_jiejie202603271425572.z0uek = z0mvk_jiejie20260327142557.z0yek;
							}
							break;
						}
					}
				}
			}
			else if (z0mvk_jiejie20260327142557.z0uek < num3 || z0mvk_jiejie20260327142557.z0uek > num4)
			{
				flag = true;
				p0[num6] = null;
			}
			else
			{
				for (int num8 = num6 - 1; num8 >= 0; num8--)
				{
					z0mvk_jiejie20260327142557 z0mvk_jiejie202603271425573 = p0[num8];
					if (z0mvk_jiejie20260327142557.z0uek == z0mvk_jiejie202603271425573.z0uek && z0mvk_jiejie20260327142557.z0vek <= z0mvk_jiejie202603271425573.z0zek && z0mvk_jiejie20260327142557.z0zek >= z0mvk_jiejie202603271425573.z0vek)
					{
						if (z0mvk_jiejie20260327142557.z0xek == z0mvk_jiejie202603271425573.z0xek)
						{
							if (z0mvk_jiejie20260327142557.z0vek < z0mvk_jiejie202603271425573.z0vek)
							{
								z0mvk_jiejie202603271425573.z0vek = z0mvk_jiejie20260327142557.z0vek;
							}
							if (z0mvk_jiejie20260327142557.z0zek > z0mvk_jiejie202603271425573.z0zek)
							{
								z0mvk_jiejie202603271425573.z0zek = z0mvk_jiejie20260327142557.z0zek;
							}
							flag = true;
							p0[num6] = null;
						}
						else if (z0mvk_jiejie202603271425573.z0vek < z0mvk_jiejie20260327142557.z0vek)
						{
							z0mvk_jiejie202603271425573.z0zek = z0mvk_jiejie20260327142557.z0vek;
						}
						else if (z0mvk_jiejie202603271425573.z0zek > z0mvk_jiejie20260327142557.z0zek)
						{
							z0mvk_jiejie202603271425573.z0vek = z0mvk_jiejie20260327142557.z0zek;
						}
						break;
					}
				}
			}
		}
		if (flag)
		{
			num = z0eek(p0, 0, num);
		}
		return num;
	}
}
