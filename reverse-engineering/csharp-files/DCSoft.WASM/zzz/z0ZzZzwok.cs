using System;
using System.Text;

namespace zzz;

public class z0ZzZzwok
{
	private readonly int z0uek = -1;

	private static int z0iek = 0;

	public static readonly z0ZzZzwok z0oek = new z0ZzZzwok();

	private static byte z0pek = (byte)Environment.TickCount;

	private static readonly bool z0mek = typeof(z0ZzZzwok).Namespace != "DCSoft";

	private string z0nek;

	private readonly byte[] z0bek;

	private readonly byte z0vek;

	private static byte[] z0cek = new byte[256];

	private static readonly Encoding z0xek = Encoding.UTF8;

	private int z0zek = -2147483648;

	private readonly int z0lrk = -1;

	private int z0eek()
	{
		if (z0iek + z0uek > z0cek.Length)
		{
			byte[] array = new byte[(int)(1.5 * (double)(z0iek + z0uek))];
			Array.Copy(z0cek, array, z0iek);
			z0cek = array;
		}
		Array.Copy(z0bek, 0, z0cek, z0iek, z0uek);
		int result = z0iek;
		z0iek += z0uek;
		return result;
	}

	public int z0rek()
	{
		if (z0zek == -2147483648)
		{
			if (z0uek <= 0)
			{
				z0zek = 0;
			}
			else
			{
				string text = z0tek();
				if (text != null)
				{
					z0zek = text.Length;
				}
				else
				{
					z0zek = 0;
				}
			}
		}
		return z0zek;
	}

	public z0ZzZzwok(object p0)
	{
		if (p0 is z0ZzZzwok)
		{
			z0ZzZzwok z0ZzZzwok2 = (z0ZzZzwok)p0;
			z0lrk = z0ZzZzwok2.z0lrk;
			z0vek = z0ZzZzwok2.z0vek;
			z0uek = z0ZzZzwok2.z0uek;
			z0bek = z0ZzZzwok2.z0bek;
			z0zek = z0ZzZzwok2.z0zek;
			return;
		}
		string text = z0rek(p0);
		if (text == null)
		{
			z0uek = -1;
			z0zek = 0;
			return;
		}
		if (text.Length == 0)
		{
			z0uek = 0;
			z0zek = 0;
			return;
		}
		z0zek = text.Length;
		z0vek = z0pek++;
		if (z0vek == 0)
		{
			z0vek = 110;
		}
		z0bek = z0xek.GetBytes(text);
		z0uek = z0bek.Length;
		for (int i = 0; i < z0uek; i++)
		{
			z0bek[i] = (byte)(z0bek[i] ^ (z0vek + i));
		}
	}

	public z0ZzZzwok(string p0, bool p1 = false)
	{
		if (p0 == null)
		{
			z0zek = 0;
			z0uek = -1;
			return;
		}
		if (p0.Length == 0)
		{
			z0zek = 0;
			z0uek = 0;
			return;
		}
		z0zek = p0.Length;
		z0vek = z0pek++;
		if (z0vek == 0)
		{
			z0vek = 110;
		}
		z0bek = z0xek.GetBytes(p0);
		z0uek = z0bek.Length;
		for (int i = 0; i < z0uek; i++)
		{
			z0bek[i] = (byte)(z0bek[i] ^ (z0vek + i));
		}
		if (p1)
		{
			z0lrk = z0eek();
			z0bek = null;
		}
	}

	public static z0ZzZzwok z0eek(object p0)
	{
		if (p0 == null)
		{
			return null;
		}
		if (p0 is z0ZzZzwok)
		{
			return (z0ZzZzwok)p0;
		}
		string text = Convert.ToString(p0);
		if (string.IsNullOrEmpty(text))
		{
			return z0oek;
		}
		return new z0ZzZzwok(text);
	}

	public string z0tek()
	{
		if (this == z0oek)
		{
			return string.Empty;
		}
		if (z0uek < 0)
		{
			return null;
		}
		if (z0uek == 0)
		{
			return string.Empty;
		}
		if (z0nek == null)
		{
			byte[] array = new byte[z0uek];
			if (z0lrk >= 0)
			{
				for (int i = 0; i < z0uek; i++)
				{
					array[i] = (byte)(z0cek[z0lrk + i] ^ (z0vek + i));
				}
			}
			else
			{
				for (int j = 0; j < z0uek; j++)
				{
					array[j] = (byte)(z0bek[j] ^ (z0vek + j));
				}
			}
			z0nek = z0xek.GetString(array);
		}
		return z0nek;
	}

	public bool z0yek()
	{
		return z0uek <= 0;
	}

	public z0ZzZzwok(int[] p0, bool p1 = false)
	{
		if (p0 != null && p0.Length != 0)
		{
			byte[] array = new byte[p0.Length * 4];
			for (int i = 0; i < p0.Length; i++)
			{
				Array.Copy(BitConverter.GetBytes(p0[i]), 0, array, i * 4, 4);
			}
			z0uek = BitConverter.ToInt16(array, 0);
			z0vek = array[2];
			z0bek = new byte[z0uek];
			Array.Copy(array, 3, z0bek, 0, z0uek);
			if (p1)
			{
				z0lrk = z0eek();
				z0bek = null;
			}
		}
	}

	public override string ToString()
	{
		if (z0mek)
		{
			return "ob";
		}
		return z0tek();
	}

	private z0ZzZzwok()
	{
	}

	public static string z0rek(object p0)
	{
		if (p0 == null)
		{
			return null;
		}
		if (p0 is z0ZzZzwok)
		{
			return ((z0ZzZzwok)p0).z0tek();
		}
		if (p0 is string)
		{
			return (string)p0;
		}
		return p0.ToString();
	}
}
