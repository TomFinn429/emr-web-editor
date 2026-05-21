using System;
using System.Collections.Generic;
using System.Text;
using DCSoft.Writer.Dom;

namespace zzz;

public class z0ZzZzick
{
	private int z0bek;

	private string z0cek;

	public static DateTime z0xek = z0ZzZzook.z0uek;

	public static bool z0zek = true;

	internal int z0krk = z0frk;

	public static readonly z0ZzZzick z0jrk = new z0ZzZzick();

	private List<string> z0hrk;

	private z0ZzZzpck z0grk = z0ZzZzpck.z0mek;

	public static int z0frk = 8;

	public static void z0eek(object p0)
	{
	}

	public string z0eek()
	{
		if (z0hrk != null && z0hrk.Count > 0)
		{
			StringBuilder stringBuilder = new StringBuilder();
			foreach (string item in z0hrk)
			{
				if (stringBuilder.Length > 0)
				{
					stringBuilder.Append(Convert.ToChar(124));
				}
				stringBuilder.Append(item);
			}
			return stringBuilder.ToString();
		}
		return null;
	}

	public int z0rek()
	{
		return z0krk;
	}

	private z0ZzZzick()
	{
	}

	public List<z0ZzZzuck> z0eek(string p0, bool p1)
	{
		if (string.IsNullOrEmpty(p0))
		{
			return null;
		}
		StringBuilder stringBuilder = new StringBuilder();
		bool flag = false;
		string text = p0;
		foreach (char c in text)
		{
			if (z0eek(c) >= 0)
			{
				flag = true;
				stringBuilder.Append(char.ToUpper(c));
				continue;
			}
			if (flag)
			{
				stringBuilder.Append(',');
			}
			flag = false;
		}
		if (stringBuilder.Length == 0)
		{
			return null;
		}
		p0 = stringBuilder.ToString();
		try
		{
			z0hrk = null;
			z0ZzZzuck[] array = z0ZzZzock.z0eek(p0, p1, null, string.Empty, 0, string.Empty, string.Empty);
			if (array != null)
			{
				List<z0ZzZzuck> list = new List<z0ZzZzuck>();
				z0ZzZzuck[] array2 = array;
				foreach (z0ZzZzuck z0ZzZzuck2 in array2)
				{
					list.Add(z0ZzZzuck2);
				}
				return list;
			}
		}
		catch (Exception ex)
		{
			z0eek(ex.Message);
		}
		return null;
	}

	public static string z0tek()
	{
		byte[] array = Convert.FromBase64String(z0ZzZzzek.z0vek);
		for (int i = 0; i < 6; i++)
		{
			array[i] = (byte)(array[i] ^ (158 + i));
		}
		return Encoding.UTF8.GetString(array).Substring(4);
	}

	internal static string z0eek(int p0)
	{
		List<string> list = new List<string>();
		if ((p0 & 2) == 2)
		{
			string text = z0ZzZzzek.z0uek;
			byte[] array = Convert.FromBase64String(text);
			for (int i = 0; i < 12; i++)
			{
				array[i] = (byte)(array[i] ^ (173 + i));
			}
			text = Encoding.UTF8.GetString(array);
			list.Add(text);
		}
		if ((p0 & 4) == 4)
		{
			string z0brk = z0ZzZzkrk.z0brk;
			byte[] array2 = Convert.FromBase64String(z0brk);
			for (int j = 0; j < 19; j++)
			{
				array2[j] = (byte)(array2[j] ^ (176 + j));
			}
			z0brk = Encoding.UTF8.GetString(array2);
			list.Add(z0brk);
		}
		if ((p0 & 8) == 8)
		{
			string z0ctk = z0ZzZzzek.z0ctk;
			byte[] array3 = Convert.FromBase64String(z0ctk);
			for (int k = 0; k < 15; k++)
			{
				array3[k] = (byte)(array3[k] ^ (136 + k));
			}
			z0ctk = Encoding.UTF8.GetString(array3);
			list.Add(z0ctk);
		}
		if ((p0 & 0x10) == 16)
		{
			string z0eyk = z0ZzZzlrk.z0eyk;
			byte[] array4 = Convert.FromBase64String(z0eyk);
			for (int l = 0; l < 9; l++)
			{
				array4[l] = (byte)(array4[l] ^ (136 + l));
			}
			z0eyk = Encoding.UTF8.GetString(array4);
			list.Add(z0eyk);
		}
		if ((p0 & 0x40) == 64)
		{
			z0ZzZzwok z0ZzZzwok2 = new z0ZzZzwok(new int[5] { 919732239, 1831950958, 1534672756, 997090622, 1502171216 });
			list.Add(z0ZzZzwok2.z0tek());
		}
		if ((p0 & 0x80) == 128)
		{
			z0ZzZzwok z0ZzZzwok3 = new z0ZzZzwok(new int[5] { -1787625457, -409873922, -305750274, -1695562860, 1344874777 });
			list.Add(z0ZzZzwok3.z0tek());
		}
		return z0ZzZzyck.z0eek(list, z0ZzZzlrk.z0ttk);
	}

	public z0ZzZzpck z0yek()
	{
		if (z0grk != null && z0grk.z0zek)
		{
			if (!z0grk.z0iek())
			{
				z0grk = z0ZzZzpck.z0eek();
				z0ZzZzccj.z0eek(z0grk, this);
			}
			else
			{
				if (z0grk != z0ZzZzpck.z0mek || string.IsNullOrEmpty(XTextDocument.z0ebk))
				{
					return z0grk;
				}
				z0grk = null;
				z0cek = null;
			}
		}
		if (z0cek != XTextDocument.z0ebk)
		{
			z0cek = XTextDocument.z0ebk;
			z0hrk = null;
			z0grk = z0ZzZzpck.z0eek();
			List<z0ZzZzuck> list = new List<z0ZzZzuck>();
			List<z0ZzZzuck> list2 = z0eek(z0cek, p1: false);
			if (list2 != null && list2.Count > 0)
			{
				bool flag = false;
				foreach (z0ZzZzuck item in list2)
				{
					if (!item.z0eek(z0rek()))
					{
						flag = true;
					}
					else if (z0eek(item, p1: false))
					{
						z0grk = item.z0uek();
						z0ZzZzccj.z0eek(z0grk, this);
						break;
					}
				}
				if (list.Count == 0 && flag)
				{
					z0eek(z0ZzZztck.z0eek + z0eek(z0rek()));
				}
			}
		}
		if (z0grk == null)
		{
			z0grk = z0ZzZzpck.z0mek;
		}
		return z0grk;
	}

	private bool z0eek(z0ZzZzuck p0, bool p1)
	{
		if (p0 == null)
		{
			return false;
		}
		if (p0 == z0ZzZzuck.z0ayk)
		{
			return true;
		}
		p0.z0tyk = null;
		if (p0.z0nrk() <= 3)
		{
			string text = z0ZzZztck.z0yek;
			p0.z0rek(text);
			z0eek(text);
			if (p1)
			{
				throw new Exception(text);
			}
			return false;
		}
		if (typeof(z0ZzZzuck).Name == z0ZzZzlrk.z0lyk && z0xek != DateTime.MinValue)
		{
			DateTime dateTime = z0xek.AddDays(10.0);
			if (z0ZzZzuyk.z0eek() > dateTime)
			{
				string p2 = string.Format(z0ZzZztck.z0pek, dateTime.ToLongDateString());
				p0.z0rek(p2);
				z0eek(p2);
				if (p1)
				{
					throw new z0ZzZznck(p2);
				}
				return false;
			}
		}
		if (p0.z0eek(32, 4L) && p0.z0ftk() < z0ZzZzuyk.z0eek().Ticks)
		{
			string p3 = z0ZzZztck.z0uek + z0ZzZzzek.z0ztk + new DateTime(p0.z0ftk()).ToLongDateString();
			p0.z0rek(p3);
			z0eek(p3);
			if (p1)
			{
				throw new z0ZzZznck(p3);
			}
			return false;
		}
		if (p0.z0eek(67108864, 33554432L) && z0ZzZzook.z0yek() > p0.z0rek())
		{
			string p4 = z0ZzZztck.z0tek + new DateTime(p0.z0rek()).ToLongDateString();
			p0.z0rek(p4);
			z0eek(p4);
			return false;
		}
		return true;
	}

	private void z0eek(string p0)
	{
		if (p0 != null && p0.Length > 0)
		{
			if (z0hrk == null)
			{
				z0hrk = new List<string>();
			}
			if (!z0hrk.Contains(p0))
			{
				z0hrk.Add(p0);
			}
		}
	}

	public void z0rek(int p0)
	{
		if (p0 >= 0 && z0krk != p0)
		{
			z0krk = p0;
			z0uek();
		}
	}

	private static int z0eek(char p0)
	{
		int result = -1;
		if (p0 >= '0' && p0 <= '9')
		{
			result = p0 - 48;
		}
		else if (p0 >= 'a' && p0 <= 'f')
		{
			result = p0 - 97 + 10;
		}
		else if (p0 >= 'A' && p0 <= 'F')
		{
			result = p0 - 65 + 10;
		}
		return result;
	}

	public void z0uek()
	{
		z0grk = null;
		z0bek++;
		z0hrk = null;
	}
}
