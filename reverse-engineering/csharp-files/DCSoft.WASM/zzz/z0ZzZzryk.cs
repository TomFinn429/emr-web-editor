using System;
using System.Text;

namespace zzz;

public class z0ZzZzryk : IComparable
{
	private int z0pek = 1;

	private int z0mek;

	private int z0nek = 1;

	private static StringBuilder z0bek = new StringBuilder(10);

	private bool z0vek;

	private static readonly char[] z0cek = "0ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();

	private string z0xek;

	private int z0zek;

	public static bool z0eek(string p0)
	{
		if (p0 == null || p0.Length > 8)
		{
			return false;
		}
		int num = 0;
		int num2 = 0;
		bool result = true;
		int length = p0.Length;
		for (int i = 0; i < length; i++)
		{
			char c = p0[i];
			if ((c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z'))
			{
				if (num2 > 0)
				{
					return false;
				}
				num++;
				if (num > 3)
				{
					return false;
				}
				continue;
			}
			if (c >= '0' && c <= '9')
			{
				if (num == 0)
				{
					return false;
				}
				num2++;
				if (num2 > 5)
				{
					return false;
				}
				continue;
			}
			return false;
		}
		if (num == 0 || num2 == 0)
		{
			return false;
		}
		return result;
	}

	public static int z0rek(string p0)
	{
		if (string.IsNullOrEmpty(p0))
		{
			return 1;
		}
		int num = 0;
		foreach (char c in p0)
		{
			if (char.IsNumber(c))
			{
				num = num * 10 + c - 48;
			}
		}
		return num;
	}

	public int z0eek()
	{
		return z0nek;
	}

	public static void z0eek(int p0, StringBuilder p1)
	{
		if (p0 < 26)
		{
			p1.Append(z0cek[p0]);
			return;
		}
		while (true)
		{
			int num = p0 % 26;
			if (num == 0)
			{
				p1.Insert(0, 'Z');
				num = 26;
			}
			else
			{
				p1.Insert(0, z0cek[num]);
			}
			if (p0 > 26)
			{
				p0 = (p0 - num) / 26;
				continue;
			}
			break;
		}
	}

	public z0ZzZzryk(int p0, int p1)
	{
		z0pek = p0;
		z0nek = p1;
	}

	public bool z0eek(int p0, int p1)
	{
		if (p0 >= z0pek && p0 <= z0pek + z0mek && p1 >= z0nek)
		{
			return p1 <= z0nek + z0zek;
		}
		return false;
	}

	public void z0eek(int p0)
	{
		z0mek = p0;
	}

	public void z0rek(int p0)
	{
		z0zek = p0;
	}

	public int CompareTo(object obj)
	{
		if (obj is z0ZzZzryk z0ZzZzryk2)
		{
			if (z0oek() < z0ZzZzryk2.z0oek())
			{
				return -1;
			}
			if (z0oek() == z0ZzZzryk2.z0oek())
			{
				return z0eek() - z0ZzZzryk2.z0eek();
			}
			return 1;
		}
		return 0;
	}

	public static string z0rek(int p0, int p1)
	{
		z0eek(p1, z0bek);
		z0bek.Append(p0);
		string result = z0bek.ToString();
		z0bek.Clear();
		return result;
	}

	public string z0rek()
	{
		return z0xek;
	}

	public z0ZzZzryk()
	{
	}

	public void z0tek(int p0)
	{
		z0nek = p0;
	}

	public bool z0tek()
	{
		return z0vek;
	}

	public void z0tek(string p0)
	{
		z0xek = p0;
	}

	public int z0yek()
	{
		return z0mek;
	}

	public override string ToString()
	{
		return z0iek();
	}

	public int z0uek()
	{
		return z0zek;
	}

	public void z0yek(int p0)
	{
		z0pek = p0;
	}

	public string z0iek()
	{
		if (z0zek == 0 && z0mek == 0 && !z0vek)
		{
			string text = z0rek(z0pek, z0nek);
			if (z0rek() != null && z0rek().Length > 0)
			{
				text = z0rek() + "!" + text;
			}
			return text;
		}
		int num = Math.Min(z0pek, z0pek + z0mek);
		int num2 = Math.Min(z0nek, z0nek + z0zek);
		int p = num + Math.Abs(z0mek);
		int p2 = num2 + Math.Abs(z0zek);
		string text2 = z0rek(num, num2) + ":" + z0rek(p, p2);
		if (z0rek() != null && z0rek().Length > 0)
		{
			text2 = z0rek() + "!" + text2;
		}
		return text2;
	}

	public static bool z0yek(string p0)
	{
		if (string.IsNullOrEmpty(p0))
		{
			return false;
		}
		int num = p0.IndexOf('!');
		if (num >= 0)
		{
			p0 = p0.Substring(num + 1);
		}
		num = p0.IndexOf(':');
		if (num > 0)
		{
			string p1 = p0.Substring(0, num).Trim();
			string p2 = p0.Substring(num + 1).Trim();
			if (z0eek(p1) && z0eek(p2))
			{
				return true;
			}
			return false;
		}
		return z0eek(p0);
	}

	public int z0oek()
	{
		return z0pek;
	}

	public void z0uek(string p0)
	{
		if (string.IsNullOrEmpty(p0))
		{
			return;
		}
		int num = p0.IndexOf('!');
		if (num >= 0)
		{
			z0tek(p0.Substring(0, num).Trim());
			p0 = p0.Substring(num + 1);
		}
		num = p0.IndexOf(':');
		if (num >= 0)
		{
			z0vek = true;
			string p1 = p0.Substring(0, num).Trim();
			string p2 = p0.Substring(num + 1).Trim();
			z0pek = z0rek(p1);
			z0nek = z0iek(p1);
			int num2 = z0rek(p2);
			int num3 = z0iek(p2);
			z0mek = Math.Abs(num2 - z0pek);
			z0zek = Math.Abs(num3 - z0nek);
			if (z0pek > num2)
			{
				z0pek = num2;
			}
			if (z0nek > num3)
			{
				z0nek = num3;
			}
		}
		else
		{
			z0vek = false;
			z0pek = z0rek(p0);
			z0nek = z0iek(p0);
			z0zek = 0;
			z0mek = 0;
		}
	}

	public static int z0iek(string p0)
	{
		if (string.IsNullOrEmpty(p0))
		{
			return 1;
		}
		int num = 0;
		p0 = p0.ToUpper();
		string text = p0;
		foreach (char c in text)
		{
			if (char.IsLetter(c))
			{
				num = num * 26 + c - 65 + 1;
			}
		}
		return num;
	}

	public z0ZzZzryk(string p0)
	{
		z0uek(p0);
	}
}
