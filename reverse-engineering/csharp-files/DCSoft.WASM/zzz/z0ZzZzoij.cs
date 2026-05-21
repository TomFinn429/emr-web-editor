using System;
using System.Collections.Generic;
using DCSystem_Drawing;

namespace zzz;

public sealed class z0ZzZzoij
{
	private class z0ink
	{
		private readonly string z0eek;

		private readonly int z0rek;

		private readonly GraphicsUnit z0tek;

		private readonly FontStyle z0yek;

		public z0ink(string p0, FontStyle p1, GraphicsUnit p2)
		{
			z0eek = p0;
			z0yek = p1;
			z0tek = p2;
			z0rek = (int)(p0.GetHashCode() + 10 * (int)z0yek + z0tek);
		}

		public override string ToString()
		{
			return z0eek + "," + z0yek;
		}

		public override int GetHashCode()
		{
			return z0rek;
		}

		public override bool Equals(object obj)
		{
			if (this == obj)
			{
				return true;
			}
			z0ink z0ink = (z0ink)obj;
			if (z0eek == z0ink.z0eek && z0yek == z0ink.z0yek)
			{
				return z0tek == z0ink.z0tek;
			}
			return false;
		}
	}

	private class z0wgj : IComparable<z0wgj>
	{
		public int z0eek;

		public int z0rek;

		public int z0tek;

		public override string ToString()
		{
			return z0rek + "->" + z0eek + " Range:" + Convert.ToString(z0eek - z0rek) + " Width:" + z0tek;
		}

		public int CompareTo(z0wgj other)
		{
			return z0rek - other.z0rek;
		}
	}

	private readonly float z0rek;

	private readonly char z0tek;

	public readonly string z0yek;

	internal z0ZzZzzfj z0uek;

	internal readonly int[] z0iek;

	private readonly GraphicsUnit z0oek;

	private static readonly Dictionary<z0ink, z0ZzZzoij> z0pek = new Dictionary<z0ink, z0ZzZzoij>();

	public static readonly z0ZzZzoij z0mek = new z0ZzZzoij();

	private static readonly double z0nek = 96.0;

	private readonly float[] z0bek;

	private readonly short[] z0vek;

	private readonly float z0cek;

	public readonly FontStyle z0xek;

	private static float z0eek(GraphicsUnit p0)
	{
		return p0 switch
		{
			GraphicsUnit.Display => 1f / (float)z0nek, 
			GraphicsUnit.Document => 0.0033333334f, 
			GraphicsUnit.Inch => 1f, 
			GraphicsUnit.Millimeter => 0.03937008f, 
			GraphicsUnit.Pixel => 1f / (float)z0nek, 
			GraphicsUnit.Point => 1f / 72f, 
			_ => throw new NotSupportedException("Not support " + p0), 
		};
	}

	private float[] z0eek()
	{
		float num = z0eek(z0oek);
		float[] array = new float[7];
		array[1] = num / z0eek(GraphicsUnit.Display);
		array[5] = num / z0eek(GraphicsUnit.Document);
		array[4] = num / z0eek(GraphicsUnit.Inch);
		array[6] = num / z0eek(GraphicsUnit.Millimeter);
		array[2] = num / z0eek(GraphicsUnit.Pixel);
		array[3] = num / z0eek(GraphicsUnit.Point);
		return array;
	}

	public static z0ZzZzoij z0eek(string p0, FontStyle p1, GraphicsUnit p2 = GraphicsUnit.Point)
	{
		if (string.IsNullOrEmpty(p0))
		{
			throw new ArgumentNullException("fontName");
		}
		z0ink z0ink = new z0ink(p0, p1, p2);
		lock (z0pek)
		{
			z0ZzZzoij z0ZzZzoij2 = null;
			if (!z0pek.TryGetValue(z0ink, out z0ZzZzoij2))
			{
				z0ZzZzoij2 = new z0ZzZzoij(p0, p1, p2);
				if (z0ZzZzoij2.z0iek == null || z0ZzZzoij2.z0vek == null)
				{
					z0ZzZzoij2 = null;
				}
				if (z0ZzZzoij2.z0uek == null)
				{
					z0ZzZzoij2 = null;
				}
				z0pek[z0ink] = z0ZzZzoij2;
			}
			return z0ZzZzoij2;
		}
	}

	private z0ZzZzoij()
	{
	}

	private static List<z0wgj> z0eek(string p0, FontStyle p1, out z0ZzZzzfj p2)
	{
		p2 = null;
		z0ZzZzyfj z0ZzZzyfj2 = null;
		short[] array = null;
		z0ZzZzzfj z0ZzZzzfj2 = z0ZzZztlj.z0eek(new z0ZzZzpej(p0, 10f, p1));
		if (z0ZzZzzfj2 == null)
		{
			return null;
		}
		p2 = z0ZzZzzfj2;
		z0ZzZzzfj2.z0uek(0);
		z0ZzZzyfj2 = z0ZzZzzfj2.z0vek();
		array = z0ZzZzzfj2.z0mek().z0eek();
		if (z0ZzZzyfj2 == null || array == null)
		{
			return null;
		}
		List<z0wgj> list = new List<z0wgj>();
		foreach (z0ZzZzjfj item in z0ZzZzyfj2.z0eek())
		{
			if (!(item is z0ZzZzrfj))
			{
				continue;
			}
			z0ZzZzrfj z0ZzZzrfj2 = (z0ZzZzrfj)item;
			int num = z0ZzZzrfj2.z0eek().Length;
			for (int i = 0; i < num; i++)
			{
				int num2 = (ushort)z0ZzZzrfj2.z0eek()[i];
				int num3 = (ushort)z0ZzZzrfj2.z0rek()[i];
				z0wgj z0wgj = null;
				for (int j = num2; j <= num3; j++)
				{
					if (j < 0 || j == 65535)
					{
						continue;
					}
					int num4 = z0ZzZzrfj2.z0eek(j, i);
					if (num4 > 0)
					{
						int num5 = array[num4];
						if (z0wgj == null || z0wgj.z0tek != num5)
						{
							z0wgj = new z0wgj();
							z0wgj.z0rek = j;
							z0wgj.z0tek = num5;
							list.Add(z0wgj);
						}
						z0wgj.z0eek = j;
					}
					else
					{
						z0wgj = null;
					}
				}
			}
		}
		list.Sort();
		for (int num6 = list.Count - 2; num6 >= 0; num6--)
		{
			z0wgj z0wgj2 = list[num6];
			z0wgj z0wgj3 = list[num6 + 1];
			if (z0wgj2.z0rek == z0wgj3.z0rek && z0wgj2.z0eek == z0wgj3.z0eek)
			{
				list.RemoveAt(num6 + 1);
			}
			else if (z0wgj2.z0eek == z0wgj3.z0rek && z0wgj2.z0tek == z0wgj3.z0tek)
			{
				z0wgj2.z0eek = z0wgj3.z0eek;
				list.RemoveAt(num6 + 1);
			}
		}
		return list;
	}

	private z0ZzZzoij(string p0, FontStyle p1, GraphicsUnit p2 = GraphicsUnit.Point)
	{
		if (string.IsNullOrEmpty(p0))
		{
			throw new ArgumentNullException("strFontName");
		}
		z0yek = p0;
		z0xek = p1;
		z0oek = p2;
		z0bek = z0eek();
		List<z0wgj> list = z0eek(z0yek, p1, out z0uek);
		if (z0uek == null)
		{
			z0ZzZzqok.z0rek.z0sh("不支持的字体:" + z0yek + "," + p1);
		}
		else
		{
			if (list == null)
			{
				return;
			}
			z0rek = (float)z0uek.z0ork.z0eek(1.0);
			z0cek = (float)z0uek.z0ork.z0uek;
			if (list == null || list.Count <= 0)
			{
				return;
			}
			z0iek = new int[list.Count * 2];
			z0vek = new short[list.Count];
			for (int i = 0; i < list.Count; i++)
			{
				z0wgj z0wgj = list[i];
				z0iek[i * 2] = z0wgj.z0rek;
				z0iek[i * 2 + 1] = z0wgj.z0eek;
				if (z0tek < z0wgj.z0eek)
				{
					z0tek = (char)z0wgj.z0eek;
				}
				z0vek[i] = (short)z0wgj.z0tek;
			}
		}
	}

	public float z0eek(float p0, GraphicsUnit p1)
	{
		if (this == z0mek)
		{
			return 0f;
		}
		return z0rek * p0 * z0bek[(int)p1];
	}
}
