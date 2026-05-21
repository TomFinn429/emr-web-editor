using System;
using System.Collections.Generic;
using System.Text;
using DCSystem_Drawing;

namespace zzz;

public sealed class z0ZzZzpij
{
	private class z0onk
	{
		private readonly GraphicsUnit z0eek;

		private readonly int z0rek_jiejie20260327142557;

		private readonly FontStyle z0tek;

		private readonly string z0yek;

		public override bool Equals(object obj)
		{
			if (this == obj)
			{
				return true;
			}
			z0onk z0onk = (z0onk)obj;
			if (z0yek == z0onk.z0yek && z0tek == z0onk.z0tek)
			{
				return z0eek == z0onk.z0eek;
			}
			return false;
		}

		public override int GetHashCode()
		{
			return z0rek_jiejie20260327142557;
		}

		public z0onk(string p0, FontStyle p1, GraphicsUnit p2)
		{
			z0yek = p0;
			z0tek = p1;
			z0eek = p2;
			z0rek_jiejie20260327142557 = (int)(p0.GetHashCode() + 10 * (int)z0tek + z0eek);
		}
	}

	public delegate z0ZzZzpij z0snk(string strFontName, FontStyle style);

	private class z0cmk
	{
		private byte[] z0pek;

		private int z0mek;

		private Encoding z0nek;

		public float z0eek()
		{
			float result = BitConverter.ToSingle(z0pek, z0mek);
			z0mek += 4;
			return result;
		}

		public int z0rek()
		{
			return z0pek[z0mek++] | (z0pek[z0mek++] << 8) | (z0pek[z0mek++] << 16) | (z0pek[z0mek++] << 24);
		}

		public byte z0tek()
		{
			return z0pek[z0mek++];
		}

		public short z0yek()
		{
			return (short)(z0pek[z0mek++] | (z0pek[z0mek++] << 8));
		}

		public unsafe int[] z0eek(int p0)
		{
			int[] array = new int[p0];
			fixed (byte* ptr = &z0pek[z0mek])
			{
				fixed (int* ptr2 = array)
				{
					int* ptr3 = ptr2;
					if (BitConverter.IsLittleEndian)
					{
						ushort* ptr4 = (ushort*)ptr;
						ushort* ptr5 = ptr4 + p0;
						while (ptr4 < ptr5)
						{
							*(ptr3++) = *(ptr4++);
						}
					}
					else
					{
						byte* ptr6 = ptr;
						for (int i = 0; i < p0; i++)
						{
							*(ptr3++) = *(ptr6++) | (*(ptr6++) << 8);
						}
					}
				}
			}
			z0mek += p0 * 2;
			return array;
		}

		public void z0uek()
		{
			z0pek = null;
			z0nek = null;
		}

		public string z0iek()
		{
			int num = z0oek();
			if (num == 0)
			{
				return string.Empty;
			}
			string result = z0nek.GetString(z0pek, z0mek, num);
			z0mek += num;
			return result;
		}

		private int z0oek()
		{
			int num = 0;
			int num2 = 0;
			byte b;
			do
			{
				if (num2 == 35)
				{
					throw new FormatException("Format_Bad7BitInt32");
				}
				b = z0tek();
				num |= (b & 0x7F) << num2;
				num2 += 7;
			}
			while ((b & 0x80) != 0);
			return num;
		}

		public short[] z0rek(int p0)
		{
			short[] array = new short[p0];
			if (BitConverter.IsLittleEndian)
			{
				Buffer.BlockCopy(z0pek, z0mek, array, 0, p0 * 2);
				z0mek += p0 * 2;
			}
			else
			{
				for (int i = 0; i < p0; i++)
				{
					array[i] = (short)(z0pek[z0mek++] | (z0pek[z0mek++] << 8));
				}
			}
			return array;
		}

		public z0cmk(byte[] p0, Encoding p1)
		{
			z0pek = p0;
			z0nek = p1;
		}
	}

	private static Dictionary<string, string> z0iek;

	private readonly float z0oek;

	[ThreadStatic]
	private static bool z0pek;

	private readonly GraphicsUnit z0mek = GraphicsUnit.Point;

	public static z0snk z0nek;

	public float z0bek;

	private readonly float z0vek;

	private readonly char z0cek;

	public string z0xek;

	internal string z0zek;

	internal int[] z0lrk;

	private static readonly double z0krk;

	public readonly FontStyle z0jrk;

	public readonly float z0hrk;

	private short[] z0grk;

	private static HashSet<string> z0frk;

	private static z0ZzZzpij[] z0drk;

	private readonly float[] z0srk;

	private readonly bool z0ark;

	public readonly float z0qrk;

	public string z0wrk;

	public static readonly z0ZzZzpij z0erk;

	private static z0ZzZzpij z0rrk;

	internal float z0trk = 1f;

	private readonly bool z0yrk;

	static z0ZzZzpij()
	{
		z0frk = new HashSet<string>();
		z0iek = null;
		z0erk = new z0ZzZzpij();
		z0nek = null;
		z0rrk = null;
		z0drk = null;
		z0pek = false;
		z0krk = 96.0;
	}

	public int[] z0eek()
	{
		return z0lrk;
	}

	public static z0ZzZzpij z0eek(string p0, byte[] p1)
	{
		z0cmk z0cmk = new z0cmk(p1, Encoding.UTF8);
		z0ZzZzpij z0ZzZzpij2 = new z0ZzZzpij(z0cmk);
		z0cmk.z0uek();
		z0ZzZzpij2.z0wrk = p0;
		z0ZzZzqok.z0rek.z0sh("加载字体信息:" + z0ZzZzpij2.z0wrk + " , " + z0ZzZzpij2.z0jrk);
		return z0ZzZzpij2;
	}

	public z0ZzZzxdh z0eek(char p0, float p1, GraphicsUnit p2)
	{
		if (this == z0erk)
		{
			z0pek = true;
			return z0ZzZzxdh.z0yek;
		}
		int num = z0eek(z0lrk, p0);
		if (num < 0 && z0ark && p0 > '⌨')
		{
			num = z0eek(z0lrk, 34945);
		}
		if (num >= 0)
		{
			z0pek = false;
			float num2 = z0srk[(int)p2] * p1;
			return new z0ZzZzxdh((float)z0grk[num] * num2 / z0oek, z0bek * num2);
		}
		z0pek = true;
		return z0ZzZzxdh.z0yek;
	}

	private z0ZzZzpij()
	{
	}

	public bool z0rek()
	{
		return (z0jrk & FontStyle.Italic) == FontStyle.Italic;
	}

	public bool z0eek(char p0)
	{
		if (this != z0erk)
		{
			return z0eek(z0lrk, p0) >= 0;
		}
		return false;
	}

	public bool z0tek()
	{
		return z0pek;
	}

	public bool z0eek(string p0)
	{
		if (string.IsNullOrEmpty(p0))
		{
			return true;
		}
		if (this == z0erk)
		{
			return false;
		}
		for (int num = p0.Length - 1; num >= 0; num--)
		{
			if (z0eek(z0lrk, p0[num]) < 0)
			{
				return false;
			}
		}
		return true;
	}

	public float z0rek(char p0, float p1, GraphicsUnit p2)
	{
		if (this == z0erk)
		{
			z0pek = true;
			return 0f;
		}
		int num = z0eek(z0lrk, p0);
		if (num < 0 && z0ark && p0 > '⌨')
		{
			num = z0eek(z0lrk, 34945);
		}
		if (num >= 0)
		{
			z0pek = false;
			return p1 * (float)z0grk[num] * z0srk[(int)p2] / z0oek;
		}
		z0pek = true;
		return 0f;
	}

	private static int z0eek(int[] p0, int p1)
	{
		if (p0 != null && p0.Length != 0 && p0.Length % 2 == 0)
		{
			int num = 0;
			int num2 = p0.Length >> 1;
			while (num2 > num)
			{
				int num3 = num + num2 >> 1;
				int num4 = num3 << 1;
				if (num3 == num)
				{
					if (p1 < p0[num4] || p1 > p0[num4 + 1])
					{
						break;
					}
					return num3;
				}
				if (p1 < p0[num4])
				{
					num2 = num3;
					continue;
				}
				if (p1 <= p0[num4 + 1])
				{
					return num3;
				}
				num = num3;
			}
		}
		return -1;
	}

	public float z0eek(float p0, GraphicsUnit p1)
	{
		return p0 * z0vek * z0srk[(int)p1] / z0oek;
	}

	private z0ZzZzpij(z0cmk p0)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("reader");
		}
		int num = p0.z0yek();
		if (num > 0)
		{
			z0lrk = p0.z0eek(num);
			z0grk = p0.z0rek(num / 2);
		}
		z0wrk = p0.z0iek();
		z0bek = p0.z0eek();
		z0cek = (char)p0.z0rek();
		z0jrk = (FontStyle)p0.z0tek();
		z0mek = (GraphicsUnit)p0.z0tek();
		z0mek = GraphicsUnit.Point;
		z0oek = p0.z0eek();
		z0qrk = p0.z0eek();
		z0hrk = p0.z0eek();
		z0srk = z0uek();
		int num2 = z0eek(z0lrk, 34945);
		if (num2 >= 0)
		{
			z0ark = true;
			z0vek = z0grk[num2];
			return;
		}
		z0ark = false;
		num2 = z0eek(z0lrk, 72);
		if (num2 >= 0)
		{
			z0vek = z0grk[num2] * 2;
		}
	}

	public bool z0yek()
	{
		return (z0jrk & FontStyle.Bold) == FontStyle.Bold;
	}

	public bool z0eek(FontStyle p0)
	{
		if ((p0 & FontStyle.Bold) == FontStyle.Bold)
		{
			return z0yrk;
		}
		return false;
	}

	public float z0rek(float p0, GraphicsUnit p1)
	{
		if (this == z0erk)
		{
			return 0f;
		}
		return z0bek * p0 * z0srk[(int)p1];
	}

	public static z0ZzZzpij z0eek(string p0, FontStyle p1, GraphicsUnit p2 = GraphicsUnit.Point)
	{
		if (z0rrk != null && z0rrk.z0wrk == p0 && z0rrk.z0jrk == p1)
		{
			return z0rrk;
		}
		if (z0nek == null)
		{
			throw new NotSupportedException("EventGetInstance");
		}
		return z0rrk = z0nek(p0, p1);
	}

	public static void z0eek(string[] p0)
	{
		if (p0 != null && p0.Length != 0)
		{
			z0frk = new HashSet<string>(p0);
		}
	}

	public static string z0rek(string p0)
	{
		if (p0 != null && p0.Length > 0)
		{
			if (z0iek == null)
			{
				return p0;
			}
			if (z0iek.ContainsKey(p0))
			{
				return p0;
			}
		}
		return z0ZzZzimk.DefaultFontName;
	}

	private float[] z0uek()
	{
		float num = z0eek(z0mek);
		float[] array = new float[7];
		array[1] = num / z0eek(GraphicsUnit.Display);
		array[5] = num / z0eek(GraphicsUnit.Document);
		array[4] = num / z0eek(GraphicsUnit.Inch);
		array[6] = num / z0eek(GraphicsUnit.Millimeter);
		array[2] = num / z0eek(GraphicsUnit.Pixel);
		array[3] = num / z0eek(GraphicsUnit.Point);
		return array;
	}

	private static float z0eek(GraphicsUnit p0)
	{
		return p0 switch
		{
			GraphicsUnit.Display => 1f / (float)z0krk, 
			GraphicsUnit.Document => 0.0033333334f, 
			GraphicsUnit.Inch => 1f, 
			GraphicsUnit.Millimeter => 0.03937008f, 
			GraphicsUnit.Pixel => 1f / (float)z0krk, 
			GraphicsUnit.Point => 1f / 72f, 
			_ => throw new NotSupportedException("Not support " + p0), 
		};
	}

	public static bool z0tek(string p0)
	{
		if (p0 != null && p0.Length > 0)
		{
			return z0frk.Contains(p0);
		}
		return false;
	}
}
