using System;
using System.Collections.Generic;
using System.Text;

namespace zzz;

public sealed class z0ZzZzuck
{
	private string z0etk;

	private string z0rtk;

	private int z0ttk;

	private static int z0ytk = 1;

	private int z0utk = 1;

	private int z0itk;

	[NonSerialized]
	private int z0otk;

	private object z0ptk;

	private int z0mtk;

	private string z0ntk;

	private long z0ctk = z0ork();

	private long z0xtk = z0ork();

	private int z0ztk;

	private string z0jyk;

	public int z0hyk;

	private string z0gyk;

	private int z0fyk;

	public int z0dyk = z0ytk++;

	private string z0syk;

	public static readonly z0ZzZzuck z0ayk = z0gtk();

	private string z0qyk_jiejie20260327142557;

	private long z0wyk;

	private byte z0eyk;

	internal int z0ryk;

	internal string z0tyk;

	private int z0yyk;

	private bool z0iyk;

	private int z0oyk;

	public bool z0pyk;

	private string z0myk;

	private int z0nyk;

	private long z0byk;

	private DateTime z0vyk = z0ZzZzuyk.z0eek();

	private string z0cyk;

	internal long z0xyk;

	private object z0zyk;

	private int z0luk;

	public DateTime z0eek()
	{
		return z0vyk;
	}

	public long z0rek()
	{
		return z0wyk;
	}

	public bool z0tek()
	{
		if (z0xyk != 0L)
		{
			return (z0xyk & 0x1000) == 4096;
		}
		return (z0ryk & 0x2000) == 8192;
	}

	public long z0yek()
	{
		return z0ctk;
	}

	public bool z0eek(object p0, int p1, int p2, DateTime p3, string p4)
	{
		z0dyk = z0ytk++;
		if (p0 == null)
		{
			return false;
		}
		try
		{
			object[] array = (object[])p0;
			if (array.Length >= 26)
			{
				z0yyk = (int)array[0];
				z0eyk = (byte)array[1];
				z0ntk = (string)array[2];
				if (array[3] != null)
				{
					z0itk = (int)array[3];
				}
				z0cyk = (string)array[4];
				z0ctk = ((DateTime)array[5]).Ticks;
				z0myk = (string)array[6];
				z0etk = (string)array[7];
				z0qyk_jiejie20260327142557 = (string)array[8];
				z0xtk = ((DateTime)array[9]).Ticks;
				z0ryk = Convert.ToInt32(array[10]);
				z0xyk = Convert.ToInt64(array[11]);
				z0fyk = (int)array[12];
				z0wyk = ((DateTime)array[13]).Ticks;
				z0jyk = (string)array[14];
				z0gyk = (string)array[15];
				z0ztk = (int)array[16];
				z0luk = (int)array[17];
				if (z0luk == 0 && z0jyk != null)
				{
					z0luk = z0jyk.GetHashCode();
				}
				z0ttk = (int)array[18];
				z0otk = (int)array[19];
				z0rtk = (string)array[20];
				z0byk = (long)array[21];
				z0syk = (string)array[22];
				z0ptk = new z0ZzZzwok((string)array[23]);
				z0mtk = (int)array[24];
				z0iyk = (bool)array[25];
				z0oyk = 2;
				if (array.Length > 26)
				{
					z0oyk = (int)array[26];
				}
				if (array.Length > 27)
				{
					z0oyk = (int)array[26];
					if (z0oyk == 100)
					{
						List<int> list = new List<int>((int[])array[27]);
						list.Sort();
						z0zyk = list.ToArray();
					}
					else
					{
						z0zyk = null;
					}
				}
				if (array.Length > 28)
				{
					z0nyk = (int)array[28];
				}
				if (array.Length > 29)
				{
					z0hyk = (int)array[29];
				}
				if (array.Length > 30)
				{
					z0utk = (int)array[30];
				}
				else
				{
					z0utk = 1;
				}
				return true;
			}
		}
		catch (Exception ex)
		{
			z0ZzZzqok.z0rek.z0dh(ex.Message);
		}
		return true;
	}

	public z0ZzZzpck z0uek()
	{
		if (this == z0ayk)
		{
			return z0ZzZzpck.z0eek();
		}
		return z0ZzZzpck.z0eek(z0rrk(), 0, 1, p3: false, null, 0f, p6: false);
	}

	public bool z0iek()
	{
		return z0iyk;
	}

	public bool z0oek()
	{
		return z0frk() == 1;
	}

	public bool z0pek()
	{
		if (z0xyk != 0L)
		{
			return (z0xyk & 0x200000) == 2097152;
		}
		return (z0ryk & 0x800000) == 8388608;
	}

	public bool z0mek()
	{
		if (z0xyk != 0L)
		{
			return (z0xyk & 1) == 1;
		}
		return (z0ryk & 0x8000000) == 134217728;
	}

	public string z0nek()
	{
		StringBuilder stringBuilder = new StringBuilder();
		z0ZzZzwok z0ZzZzwok2 = new z0ZzZzwok(new int[15]
		{
			-491192266, 1528049501, 1361381430, -171968177, 546544315, 1445687915, 1547709024, -1461344024, 1463717003, 1581333842,
			89088566, 1593857369, 1752891969, -1864462128, -1348577357
		});
		stringBuilder.Append(string.Format(z0ZzZzwok2.z0tek(), z0trk(), z0xek(), z0ZzZzick.z0eek(z0yyk)));
		if (z0oyk == 0)
		{
			string text = z0ZzZzzek.z0mrk;
			byte[] array = Convert.FromBase64String(text);
			for (int i = 0; i < 11; i++)
			{
				array[i] = (byte)(array[i] ^ (182 + i));
			}
			text = Encoding.UTF8.GetString(array);
			stringBuilder.Append(text);
		}
		else if (z0oyk == 1)
		{
			string text2 = z0ZzZzzek.z0luk;
			byte[] array2 = Convert.FromBase64String(text2);
			for (int j = 0; j < 11; j++)
			{
				array2[j] = (byte)(array2[j] ^ (133 + j));
			}
			text2 = Encoding.UTF8.GetString(array2);
			stringBuilder.Append(text2);
		}
		else if (z0oyk == 2)
		{
			string z0qyk = z0ZzZzzek.z0qyk;
			byte[] array3 = Convert.FromBase64String(z0qyk);
			for (int k = 0; k < 11; k++)
			{
				array3[k] = (byte)(array3[k] ^ (127 + k));
			}
			z0qyk = Encoding.UTF8.GetString(array3);
			stringBuilder.Append(z0qyk);
		}
		else
		{
			string text3 = z0ZzZzkrk.z0uek;
			byte[] array4 = Convert.FromBase64String(text3);
			for (int l = 0; l < 14; l++)
			{
				array4[l] = (byte)(array4[l] ^ (128 + l));
			}
			text3 = Encoding.UTF8.GetString(array4);
			stringBuilder.Append(text3);
		}
		if ((z0xyk & 0x40000000) == 1073741824 && z0nyk > 0)
		{
			string text4 = z0ZzZzzek.z0vrk;
			byte[] array5 = Convert.FromBase64String(text4);
			for (int m = 0; m < 20; m++)
			{
				array5[m] = (byte)(array5[m] ^ (215 + m));
			}
			text4 = Encoding.UTF8.GetString(array5);
			stringBuilder.Append(string.Format(text4, z0nyk.ToString()));
		}
		if ((z0xyk & 0x2000000) == 33554432)
		{
			string text5 = z0ZzZzlrk.z0gyk;
			byte[] array6 = Convert.FromBase64String(text5);
			for (int n = 0; n < 26; n++)
			{
				array6[n] = (byte)(array6[n] ^ (111 + n));
			}
			text5 = Encoding.UTF8.GetString(array6);
			stringBuilder.Append(string.Format(text5, z0eek(new DateTime(z0wyk))));
		}
		if ((z0xyk & 4) == 4)
		{
			string text6 = z0ZzZzlrk.z0pek;
			byte[] array7 = Convert.FromBase64String(text6);
			for (int num = 0; num < 20; num++)
			{
				array7[num] = (byte)(array7[num] ^ (110 + num));
			}
			text6 = Encoding.UTF8.GetString(array7);
			stringBuilder.Append(string.Format(text6, z0eek(new DateTime(z0ftk()))));
		}
		string text7 = z0ZzZzkrk.z0rrk;
		byte[] array8 = Convert.FromBase64String(text7);
		for (int num2 = 0; num2 < 14; num2++)
		{
			array8[num2] = (byte)(array8[num2] ^ (165 + num2));
		}
		text7 = Encoding.UTF8.GetString(array8);
		stringBuilder.Append(string.Format(text7, z0prk().ToString()));
		if (z0frk() == 2)
		{
			string text8 = z0ZzZzlrk.z0ptk;
			byte[] array9 = Convert.FromBase64String(text8);
			for (int num3 = 0; num3 < 13; num3++)
			{
				array9[num3] = (byte)(array9[num3] ^ (249 + num3));
			}
			text8 = Encoding.UTF8.GetString(array9);
			stringBuilder.Append(text8);
		}
		else if (z0frk() == 1)
		{
			string text9 = z0ZzZzkrk.z0ork;
			byte[] array10 = Convert.FromBase64String(text9);
			for (int num4 = 0; num4 < 16; num4++)
			{
				array10[num4] = (byte)(array10[num4] ^ (123 + num4));
			}
			text9 = Encoding.UTF8.GetString(array10);
			stringBuilder.Append(text9);
		}
		else if (z0frk() == 4)
		{
			z0ZzZzwok z0ZzZzwok3 = new z0ZzZzwok(new int[7] { -727187434, 1144721487, 139133994, 35935237, 1561803856, 928791574, 2041273642 });
			stringBuilder.Append(z0ZzZzwok3.z0tek());
		}
		if ((z0xyk & 2) == 2)
		{
			stringBuilder.Append(z0ZzZzzek.z0iek + z0syk + z0ZzZzkrk.z0srk);
		}
		if (z0zek())
		{
			stringBuilder.Append('$');
		}
		return stringBuilder.ToString();
	}

	public string z0bek()
	{
		return z0jyk;
	}

	public bool z0vek()
	{
		if (z0xyk != 0L)
		{
			return (z0xyk & 0x100000) == 1048576;
		}
		return (z0ryk & 0x400000) == 4194304;
	}

	public int z0cek()
	{
		return z0utk;
	}

	public string z0xek()
	{
		if (z0xyk != 0L && (z0xyk & 0x100) == 256)
		{
			return z0cyk;
		}
		if ((z0ryk & 0x400) == 1024)
		{
			return z0cyk;
		}
		string text = z0ZzZzlrk.z0grk;
		byte[] array = Convert.FromBase64String(text);
		for (int i = 0; i < 66; i++)
		{
			array[i] = (byte)(array[i] ^ (124 + i));
		}
		text = Encoding.UTF8.GetString(array);
		if (z0myk == text)
		{
			return string.Empty;
		}
		byte[] array2 = Convert.FromBase64String(z0ZzZzzek.z0trk);
		for (int j = 0; j < 36; j++)
		{
			array2[j] = (byte)(array2[j] ^ (246 + j));
		}
		return Encoding.UTF8.GetString(array2);
	}

	public bool z0zek()
	{
		if (z0frk() == 2)
		{
			return false;
		}
		if (z0mtk == 3 || z0mtk == 4)
		{
			return z0itk != z0ttk + 2;
		}
		return z0itk != z0ttk;
	}

	public string z0lrk()
	{
		return z0gyk;
	}

	public bool z0krk()
	{
		if (z0xyk != 0L)
		{
			return (z0xyk & 0x20000) == 131072;
		}
		return (z0ryk & 0x40000) == 262144;
	}

	public bool z0jrk()
	{
		if (z0xyk != 0L)
		{
			return (z0xyk & 0x1000000) == 16777216;
		}
		return (z0ryk & 0x2000000) == 33554432;
	}

	public int z0hrk()
	{
		return z0luk;
	}

	public bool z0grk()
	{
		if (z0xyk != 0L)
		{
			return (z0xyk & 0x10000) == 65536;
		}
		return (z0ryk & 0x20000) == 131072;
	}

	internal int z0frk()
	{
		return z0otk;
	}

	public string z0drk()
	{
		return z0syk;
	}

	internal bool z0eek(int p0, long p1)
	{
		if (z0xyk != 0L && (z0xyk & p1) == p1)
		{
			return true;
		}
		if (z0ryk != 0 && (z0ryk & p0) == p0)
		{
			return true;
		}
		return false;
	}

	public int z0srk()
	{
		if (z0xtk == 0L)
		{
			return 2147483647;
		}
		return (int)(new DateTime(z0xtk) - z0ZzZzuyk.z0eek()).TotalDays;
	}

	public string z0ark()
	{
		return z0ntk;
	}

	public int z0qrk()
	{
		return z0nyk;
	}

	public long z0wrk()
	{
		return z0byk;
	}

	private static string z0eek(DateTime p0)
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(p0.Year);
		stringBuilder.Append('-');
		stringBuilder.Append(p0.Month);
		stringBuilder.Append('-');
		stringBuilder.Append(p0.Day);
		return stringBuilder.ToString();
	}

	public bool z0erk()
	{
		if (z0xyk != 0L)
		{
			return (z0xyk & 0x20) == 32;
		}
		return (z0ryk & 0x40) == 64;
	}

	private object z0rrk()
	{
		return new object[60]
		{
			z0atk(),
			z0krk(),
			z0grk(),
			z0ark(),
			z0zyk,
			z0xek(),
			z0zek(),
			z0srk(),
			z0yek(),
			z0mrk(),
			z0tek(),
			z0irk(),
			z0wtk(),
			z0jtk(),
			z0stk(),
			z0jrk(),
			z0htk(),
			z0ftk(),
			z0tyk,
			z0vrk(),
			z0crk(),
			z0oek(),
			z0eek(),
			z0vek(),
			z0brk(),
			z0pek(),
			z0urk(),
			z0dtk(),
			z0ltk_jiejie20260327142557(),
			z0qtk(),
			z0qrk(),
			z0rek(),
			z0hyk,
			z0pyk,
			z0lrk(),
			z0zrk(),
			z0erk(),
			z0hrk(),
			z0yrk(),
			z0frk(),
			z0ktk(),
			z0xrk(),
			z0wrk(),
			z0drk(),
			z0nek(),
			z0trk(),
			z0nrk(),
			z0mek(),
			z0iek(),
			z0yek(),
			this == z0ayk,
			z0bek(),
			z0dyk,
			z0cek(),
			null,
			null,
			null,
			null,
			null,
			null
		};
	}

	public string z0trk()
	{
		return z0ZzZzwok.z0rek(z0ptk);
	}

	public bool z0yrk()
	{
		if (z0xyk != 0L)
		{
			return (z0xyk & 0x200) == 512;
		}
		return (z0ryk & 4) == 4;
	}

	public int z0urk()
	{
		return z0fyk;
	}

	public string z0irk()
	{
		return z0etk;
	}

	private static long z0ork()
	{
		byte[] array = Convert.FromBase64String(z0ZzZzzek.z0dyk);
		for (int i = 0; i < 12; i++)
		{
			array[i] = (byte)(array[i] ^ (232 + i));
		}
		return BitConverter.ToInt64(Convert.FromBase64String(Encoding.UTF8.GetString(array)), 0);
	}

	public z0ZzZzcck z0prk()
	{
		return new z0ZzZzcck(z0fyk);
	}

	public string z0mrk()
	{
		return z0myk;
	}

	public int z0nrk()
	{
		return z0mtk;
	}

	public bool z0brk()
	{
		if (z0xtk == 0L)
		{
			return false;
		}
		if ((new DateTime(z0xtk) - z0ZzZzuyk.z0eek()).TotalDays < 31.0)
		{
			return true;
		}
		return false;
	}

	internal int z0vrk()
	{
		return z0ryk;
	}

	internal long z0crk()
	{
		return z0xyk;
	}

	public static List<string> z0eek(string p0)
	{
		List<string> list = new List<string>();
		if (p0 != null && p0.Length > 0)
		{
			string[] array = p0.Split(',', '，');
			if (array != null && array.Length != 0)
			{
				string[] array2 = array;
				for (int i = 0; i < array2.Length; i++)
				{
					string text = array2[i].Trim();
					if (text.Length > 0)
					{
						list.Add(text);
					}
				}
			}
		}
		return list;
	}

	public bool z0xrk()
	{
		if (z0xyk != 0L)
		{
			return (z0xyk & 0x80000) == 524288;
		}
		return (z0ryk & 0x200000) == 2097152;
	}

	public int z0zrk()
	{
		return z0ztk;
	}

	public int z0ltk_jiejie20260327142557()
	{
		return z0oyk;
	}

	public string z0ktk()
	{
		return z0rtk;
	}

	public bool z0jtk()
	{
		if (z0xyk != 0L)
		{
			return (z0xyk & 0x4000000) == 67108864;
		}
		return false;
	}

	public bool z0htk()
	{
		if (z0xyk != 0L)
		{
			return (z0xyk & 0x2000) == 8192;
		}
		return (z0ryk & 0x8000) == 32768;
	}

	internal void z0rek(string p0)
	{
		if (p0 != null && p0.Length > 0)
		{
			if (string.IsNullOrEmpty(z0tyk))
			{
				z0tyk = p0;
			}
			else
			{
				z0tyk = z0tyk + Convert.ToChar(124) + p0;
			}
		}
	}

	private static z0ZzZzuck z0gtk()
	{
		return new z0ZzZzuck
		{
			z0ryk = 0,
			z0xyk = 0L,
			z0dyk = -1,
			z0ptk = new z0ZzZzwok(z0ZzZztck.z0rek)
		};
	}

	public long z0ftk()
	{
		return z0xtk;
	}

	public bool z0dtk()
	{
		if (z0xyk != 0L)
		{
			return (z0xyk & 0x10000000) == 268435456;
		}
		return (z0ryk & 0x100000) == 1048576;
	}

	public bool z0eek(int p0)
	{
		return (z0yyk & p0) == p0;
	}

	public bool z0stk()
	{
		if (z0xyk != 0L)
		{
			return (z0xyk & 0x800) == 2048;
		}
		return (z0ryk & 0x200) == 512;
	}

	public int z0atk()
	{
		return z0yyk;
	}

	public string z0qtk()
	{
		if (z0yrk())
		{
			return string.Format(z0ZzZztck.z0oek, z0trk());
		}
		return z0ZzZztck.z0iek;
	}

	public string z0wtk()
	{
		return z0qyk_jiejie20260327142557;
	}
}
