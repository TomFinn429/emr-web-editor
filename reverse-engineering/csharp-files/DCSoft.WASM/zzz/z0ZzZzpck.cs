using System;
using System.Text;

namespace zzz;

public sealed class z0ZzZzpck
{
	public readonly long z0oek;

	public readonly bool z0pek;

	internal static readonly z0ZzZzpck z0mek = new z0ZzZzpck(100);

	public readonly bool z0bek;

	public readonly long z0vek = z0yek();

	public readonly string z0cek;

	public readonly bool z0xek;

	public readonly bool z0zek;

	public readonly int z0lrk;

	public readonly string z0krk;

	public readonly bool z0jrk;

	public readonly z0ZzZzwok z0grk;

	public readonly int z0frk;

	public readonly z0ZzZzwok z0drk;

	public readonly z0ZzZzwok z0srk;

	public int z0ark = 1;

	public readonly bool z0qrk;

	public readonly bool z0wrk;

	public static readonly DateTime z0erk = z0ZzZzuyk.z0eek();

	public readonly DateTime z0rrk = z0ZzZzuyk.z0eek();

	public readonly string z0trk;

	public int z0yrk;

	public readonly bool z0urk;

	public z0ZzZzrck z0irk = (z0ZzZzrck)20031;

	public z0ZzZzwok z0ork;

	public readonly long z0prk;

	public readonly int z0mrk;

	public readonly bool z0nrk;

	public int z0vrk;

	public readonly int z0xrk;

	public readonly string z0zrk;

	public int z0ltk;

	private static readonly z0ZzZzpck z0ktk = new z0ZzZzpck(0);

	public readonly int z0jtk;

	public object z0htk;

	public readonly int z0gtk;

	public readonly string z0ftk;

	public bool z0dtk;

	public readonly z0ZzZzwok z0stk;

	public readonly bool z0atk;

	public readonly bool z0qtk = true;

	public readonly bool z0wtk;

	public readonly int z0etk;

	private object z0rtk;

	public readonly bool z0ttk_jiejie20260327142557;

	public z0ZzZzwok z0ytk;

	public bool z0utk;

	public readonly long z0itk;

	public readonly bool z0otk;

	public readonly bool z0ptk;

	public z0ZzZzwok z0mtk;

	public readonly bool z0ntk;

	public readonly bool z0btk;

	public readonly bool z0vtk;

	public readonly string z0ctk;

	internal int z0xtk;

	public readonly long z0ztk;

	public readonly string z0lyk;

	public readonly int z0kyk;

	public bool z0eek(int p0)
	{
		if (z0gtk > 0 && p0 >= z0gtk)
		{
			return false;
		}
		return true;
	}

	public static z0ZzZzpck z0eek(object p0, int p1, int p2, bool p3, string p4, float p5, bool p6)
	{
		if (p0 is string)
		{
			return z0eek();
		}
		return new z0ZzZzpck(p0, p1, p2, p3, p4, p5, p6);
	}

	internal z0ZzZzpck(int p0)
	{
		switch (p0)
		{
		case 0:
			z0etk = 0;
			z0ztk = 0L;
			z0nrk = true;
			z0qtk = false;
			z0atk = true;
			z0lrk = 16777215;
			z0zek = false;
			z0vrk = -1;
			z0drk = new z0ZzZzwok(new int[3] { 2073886729, 306590978, 690112010 });
			z0ytk = z0drk;
			z0mrk = 2;
			z0mtk = z0drk;
			break;
		case 100:
			z0etk = 0;
			z0ztk = 0L;
			z0nrk = true;
			z0qtk = false;
			z0atk = true;
			z0lrk = 16777215;
			z0zek = true;
			z0vrk = -1;
			z0drk = new z0ZzZzwok(new int[15]
			{
				-2090467272, -796000278, -739342905, -1761744759, -141306420, -337731624, -1728186723, 459803107, 704667923, -1154414750,
				134572475, 1980629606, 24322091, 303529505, -2145517187
			});
			z0ytk = z0drk;
			z0mrk = 2;
			z0mtk = z0drk;
			z0ztk = 4L;
			z0prk = z0ZzZzuyk.z0eek().AddSeconds(600.0).Ticks;
			z0kyk = 268435455;
			break;
		case 1:
		{
			string text = z0ZzZzzek.z0mek;
			byte[] array = Convert.FromBase64String(text);
			for (int i = 0; i < 7; i++)
			{
				array[i] = (byte)(array[i] ^ (146 + i));
			}
			text = Encoding.UTF8.GetString(array);
			z0lrk = 16777215;
			z0ytk = new z0ZzZzwok(text);
			z0zek = true;
			z0prk = z0ZzZzuyk.z0eek().AddSeconds(30.0).Ticks;
			break;
		}
		}
	}

	public static z0ZzZzpck z0eek()
	{
		return z0ktk;
	}

	public bool z0rek()
	{
		return (z0kyk & 4) == 4;
	}

	public object z0tek()
	{
		return z0rtk;
	}

	private static long z0yek()
	{
		byte[] array = Convert.FromBase64String(z0ZzZzlrk.z0ntk);
		for (int i = 0; i < 12; i++)
		{
			array[i] = (byte)(array[i] ^ (238 + i));
		}
		return BitConverter.ToInt64(Convert.FromBase64String(Encoding.UTF8.GetString(array)), 0);
	}

	private object z0eek(object p0)
	{
		int[] array = (int[])p0;
		if (array != null)
		{
			int[] array2 = new int[array.Length];
			Array.Copy(array, array2, array.Length);
			return array2;
		}
		return null;
	}

	public bool z0uek()
	{
		return (z0kyk & 8) == 8;
	}

	internal z0ZzZzpck()
	{
	}

	public bool z0iek()
	{
		if ((z0ztk & 4) == 4)
		{
			new DateTime(z0prk);
			if (z0ZzZzuyk.z0eek().Ticks > z0prk)
			{
				z0htk = null;
				return false;
			}
		}
		return true;
	}

	private z0ZzZzpck(object p0, int p1, int p2, bool p3, string p4, float p5, bool p6)
	{
		object[] array = (object[])p0;
		z0lrk = (int)array[0];
		z0wtk = (bool)array[1];
		z0urk = (bool)array[2];
		z0zrk = (string)array[3];
		z0rtk = z0eek(array[4]);
		z0ytk = z0ZzZzwok.z0eek(array[5]);
		z0ptk = (bool)array[6];
		z0jtk = (int)array[7];
		z0vek = (long)array[8];
		z0trk = (string)array[9];
		z0qrk = (bool)array[10];
		z0ctk = (string)array[11];
		z0srk = z0ZzZzwok.z0eek(array[12]);
		z0ntk = (bool)array[13];
		z0btk = (bool)array[14];
		z0ttk_jiejie20260327142557 = (bool)array[15];
		z0dtk = (bool)array[16];
		z0prk = (long)array[17];
		z0krk = (string)array[18];
		z0etk = (int)array[19];
		z0ztk = (long)array[20];
		z0bek = (bool)array[21];
		z0rrk = (DateTime)array[22];
		z0otk = (bool)array[23];
		z0qtk = (bool)array[24];
		z0xek = (bool)array[25];
		z0kyk = (int)array[26];
		z0vtk = (bool)array[27];
		z0mrk = (int)array[28];
		z0stk = z0ZzZzwok.z0eek(array[29]);
		z0gtk = (int)array[30];
		z0itk = (long)array[31];
		z0ltk = (int)array[32];
		z0utk = (bool)array[33];
		z0lyk = (string)array[34];
		z0frk = (int)array[35];
		z0pek = (bool)array[36];
		z0yrk = (int)array[37];
		z0zek = (bool)array[38];
		z0xtk = (int)array[39];
		z0ftk = (string)array[40];
		z0atk = (bool)array[41];
		z0oek = (long)array[42];
		z0cek = (string)array[43];
		z0mtk = z0ZzZzwok.z0eek(array[44]);
		z0drk = z0ZzZzwok.z0eek(array[45]);
		z0xrk = (int)array[46];
		z0jrk = (bool)array[47];
		z0wrk = (bool)array[48];
		z0vek = (long)array[49];
		z0nrk = (bool)array[50];
		z0grk = z0ZzZzwok.z0eek(array[51]);
		z0vrk = (int)array[52];
		z0ark = (int)array[53];
	}
}
