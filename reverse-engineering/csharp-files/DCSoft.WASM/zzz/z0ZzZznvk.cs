using System;
using System.Collections.Generic;
using System.Text;

namespace zzz;

internal class z0ZzZznvk : IDisposable
{
	private class z0lck : IEqualityComparer<z0zvk>
	{
		public bool Equals(z0zvk x, z0zvk y)
		{
			if (x.z0rek == y.z0rek)
			{
				return x.z0tek == y.z0tek;
			}
			return false;
		}

		public int GetHashCode(z0zvk obj)
		{
			return obj.z0eek;
		}
	}

	private struct z0zvk
	{
		public int z0eek;

		public string z0rek;

		public string z0tek;

		public z0zvk(string p0, string p1)
		{
			z0rek = p0;
			z0tek = p1;
			z0eek = p0.GetHashCode() + p1.GetHashCode();
		}
	}

	private int z0xek;

	private Dictionary<string, string> z0zek = new Dictionary<string, string>();

	private z0ZzZzuik z0krk;

	private int z0jrk;

	private z0ZzZzuik z0hrk;

	private int z0frk;

	private string z0drk;

	private bool z0srk = true;

	private static readonly string z0ark = "abcdefghijklmnopqrstuvwxyz0123456789:_.-";

	private Dictionary<string, z0ZzZzmvk> z0qrk;

	private z0ZzZzkbk z0wrk;

	private int z0erk;

	private string z0rrk;

	private static readonly int[] z0trk = z0nek();

	private static readonly string z0yrk = "</";

	private Dictionary<z0zvk, z0ZzZzunk> z0urk;

	public char z0eek()
	{
		if (z0xek < z0erk - 1)
		{
			return z0rrk[z0xek + 1];
		}
		return '\0';
	}

	public void z0eek(char p0)
	{
		while (z0xek < z0erk)
		{
			if (z0rrk[z0xek] == p0)
			{
				z0xek++;
				break;
			}
			z0xek++;
		}
	}

	internal z0ZzZzunk z0eek(string p0, string p1)
	{
		z0frk++;
		z0ZzZzunk z0ZzZzunk2 = null;
		z0zvk z0zvk = new z0zvk(p0, p1);
		if (!z0urk.TryGetValue(z0zvk, out z0ZzZzunk2))
		{
			z0ZzZzunk2 = new z0ZzZzunk(p0, p0, p1);
			z0urk[z0zvk] = z0ZzZzunk2;
		}
		return z0ZzZzunk2;
	}

	public static Dictionary<string, string> z0eek(string p0)
	{
		if (p0 == null || p0.Length == 0)
		{
			return null;
		}
		string[] array = p0.Split(';');
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		string[] array2 = array;
		foreach (string text in array2)
		{
			int num = text.IndexOf('=');
			string text2 = null;
			string text3 = null;
			if (num > 0)
			{
				text2 = text.Substring(0, num);
				text3 = text.Substring(num + 1);
			}
			else
			{
				text2 = text;
				text3 = string.Empty;
			}
			text2 = text2.Trim();
			text3 = text3.Trim();
			dictionary[text2] = text3;
		}
		return dictionary;
	}

	public z0ZzZzmvk z0rek(string p0)
	{
		if (z0qrk == null)
		{
			return new z0ZzZzmvk(p0);
		}
		z0jrk++;
		z0ZzZzmvk z0ZzZzmvk2 = null;
		if (!z0qrk.TryGetValue(p0, out z0ZzZzmvk2))
		{
			z0ZzZzmvk2 = new z0ZzZzmvk(p0);
			z0qrk.Add(p0, z0ZzZzmvk2);
		}
		return z0ZzZzmvk2;
	}

	public void z0rek(char p0)
	{
		while (z0xek >= 0 && z0rrk[z0xek] != p0)
		{
			z0xek--;
		}
	}

	public void z0rek()
	{
		while (z0xek < z0erk)
		{
			char c = z0rrk[z0xek];
			if (c == ' ' || c == '\r' || c == '\n' || c == '\t')
			{
				z0xek++;
				continue;
			}
			break;
		}
	}

	public bool z0tek(string p0)
	{
		if (z0xek + p0.Length < z0erk && string.CompareOrdinal(z0drk, z0xek, p0, 0, p0.Length) == 0)
		{
			return true;
		}
		return false;
	}

	public string z0tek()
	{
		if (z0xek >= z0erk)
		{
			return null;
		}
		int num = -1;
		while (z0xek < z0erk)
		{
			if (z0rrk[z0xek] == '<')
			{
				char c = z0eek();
				if (c == '\0')
				{
					if (num < 0)
					{
						num = z0xek;
					}
					z0xek++;
					break;
				}
				if ((c != '>' && c != '<' && !z0ZzZzqik.z0uek(c)) || c == '!')
				{
					break;
				}
			}
			if (num < 0)
			{
				num = z0xek;
			}
			z0xek++;
		}
		if (num >= 0)
		{
			return z0hrk.z0eek(num, z0xek - num);
		}
		return null;
	}

	public string z0yek(string p0)
	{
		string result = z0oek(z0yrk + p0);
		z0eek('>');
		return result;
	}

	public z0ZzZzkbk z0yek()
	{
		return z0wrk;
	}

	public void z0uek()
	{
		z0xek++;
	}

	public char z0iek()
	{
		return z0rrk[z0xek];
	}

	public void z0eek(bool p0)
	{
		z0srk = p0;
	}

	public string z0oek()
	{
		if (z0xek >= z0erk)
		{
			return null;
		}
		int i = z0xek;
		string result = null;
		int num;
		for (num = z0erk; i < num; i++)
		{
			char c = z0drk[i];
			if ((c >= '\u007f' || z0trk[(uint)c] != 1) && i > z0xek)
			{
				result = z0krk.z0eek(z0xek, i - z0xek);
				z0xek = i;
				return result;
			}
		}
		if (i == num)
		{
			result = z0drk.Substring(z0xek);
			z0xek = z0rrk.Length;
		}
		return result;
	}

	public string z0pek()
	{
		int num = 0;
		int num2 = 0;
		string text = null;
		int num3 = z0erk;
		for (int i = z0xek; i < num3; i++)
		{
			char c = z0rrk[i];
			if (c == ' ' || c == '\t' || c == '\r' || c == '\n')
			{
				continue;
			}
			num = i;
			switch (c)
			{
			case '>':
				text = z0hrk.z0eek(num + 1, i - num);
				z0xek = i;
				break;
			case '"':
			case '\'':
				num2 = z0rrk.IndexOf(c, num + 1);
				if (num2 < 0)
				{
					num2 = num3;
				}
				text = z0hrk.z0eek(num + 1, num2 - num - 1);
				z0xek = num2 + 1;
				break;
			default:
			{
				for (int j = i + 1; j < num3; j++)
				{
					if (z0ZzZzqik.z0uek(z0rrk[j]) || z0rrk[j] == '>')
					{
						num2 = j;
						break;
					}
				}
				if (num2 == 0)
				{
					num2 = z0rrk.Length - 1;
				}
				text = z0hrk.z0eek(num, num2 - num);
				z0xek = num2;
				break;
			}
			}
			return text;
		}
		z0xek = num3;
		return null;
	}

	public string z0uek(string p0)
	{
		if (p0 == null)
		{
			return p0;
		}
		if (p0.Length == 0)
		{
			return string.Empty;
		}
		string result = null;
		if (!z0zek.TryGetValue(p0, out result))
		{
			result = p0;
			z0zek[p0] = p0;
		}
		return result;
	}

	public char z0mek()
	{
		if (z0xek < z0erk - 1)
		{
			return z0rrk[z0xek + 1];
		}
		return '\0';
	}

	public string z0eek(int p0)
	{
		if (z0cek())
		{
			return null;
		}
		if (p0 > z0erk)
		{
			p0 = z0erk;
		}
		if (p0 < z0xek)
		{
			p0 = z0xek;
		}
		if (p0 == z0xek)
		{
			return null;
		}
		string result = z0rrk.Substring(z0xek, p0 - z0xek);
		z0xek = p0;
		return result;
	}

	private static int[] z0nek()
	{
		int[] array = new int[127];
		for (char c = '\0'; c < array.Length; c = (char)(c + 1))
		{
			if ((c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z') || (c >= '0' && c <= '9') || c == ':' || c == '_' || c == '.' || c == '-')
			{
				array[(uint)c] = 1;
			}
			else if (z0ZzZzqik.z0uek(c))
			{
				array[(uint)c] = 2;
			}
			else
			{
				array[(uint)c] = 0;
			}
		}
		return array;
	}

	public void z0rek(int p0)
	{
		z0xek += p0;
	}

	public void Dispose()
	{
		if (z0qrk != null)
		{
			z0qrk.Clear();
			z0qrk = null;
		}
		if (z0krk != null)
		{
			z0krk.Dispose();
			z0krk = null;
		}
		if (z0hrk != null)
		{
			z0hrk.Dispose();
			z0hrk = null;
		}
		z0rrk = null;
		z0drk = null;
		if (z0zek != null)
		{
			z0zek.Clear();
			z0zek = null;
		}
		if (z0urk != null)
		{
			z0urk.Clear();
			z0urk = null;
		}
	}

	public bool z0bek_jiejie20260327142557()
	{
		return z0srk;
	}

	public string z0iek(string p0)
	{
		StringBuilder stringBuilder = new StringBuilder();
		for (int i = z0xek; i < z0erk && p0.IndexOf(z0drk[i]) >= 0; i++)
		{
			stringBuilder.Append(z0drk[i]);
		}
		if (stringBuilder.Length == 0)
		{
			return null;
		}
		return stringBuilder.ToString();
	}

	public string z0vek()
	{
		return z0iek(z0ark);
	}

	public string z0oek(string p0)
	{
		p0 = p0.ToLower();
		int num = z0drk.IndexOf(p0, z0xek);
		return z0eek((num >= 0) ? num : z0erk);
	}

	internal z0ZzZznvk(string p0, z0ZzZzkbk p1)
	{
		if (p0 == null)
		{
			p0 = string.Empty;
		}
		z0wrk = p1;
		z0rrk = p0;
		z0xek = 0;
		z0erk = z0rrk.Length;
		z0drk = z0rrk.ToLower();
		z0krk = new z0ZzZzuik(z0drk);
		z0hrk = new z0ZzZzuik(z0rrk);
		if (z0ZzZzkbk.z0vek)
		{
			z0urk = new Dictionary<z0zvk, z0ZzZzunk>(new z0lck());
			z0qrk = new Dictionary<string, z0ZzZzmvk>();
		}
	}

	public bool z0cek()
	{
		return z0xek >= z0erk;
	}
}
