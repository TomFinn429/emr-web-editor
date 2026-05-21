using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace zzz;

public class z0ZzZzqik
{
	private class z0yok
	{
		private int z0rek;

		private long z0tek;

		private readonly List<byte> z0yek = new List<byte>();

		private void z0eek(bool p0)
		{
			long num = z0tek;
			int num2 = z0rek % 8;
			if (num2 > 0)
			{
				long num3 = (1 << num2) - 1;
				z0tek &= num3;
				num >>= num2;
				z0rek -= num2;
			}
			if (z0rek == 32)
			{
				byte[] bytes = BitConverter.GetBytes((int)num);
				z0yek.Add(bytes[3]);
				z0yek.Add(bytes[2]);
				z0yek.Add(bytes[1]);
				z0yek.Add(bytes[0]);
				z0rek = 0;
			}
			else
			{
				while (z0rek > 0)
				{
					z0rek -= 8;
					byte b = (byte)((num >> z0rek) & 0xFF);
					z0yek.Add(b);
				}
			}
			z0rek = num2;
		}

		public void z0eek(int p0, int p1)
		{
			if (p0 > 0)
			{
				z0tek = (z0tek << p0) + p1;
				z0rek += p0;
				if (z0rek >= 32)
				{
					z0eek(p0: false);
				}
			}
		}

		public byte[] z0eek()
		{
			if (z0rek > 0)
			{
				z0eek(p0: true);
			}
			return z0yek.ToArray();
		}
	}

	private static readonly string[] z0oek;

	private static readonly char[] z0pek;

	private static readonly int[] z0mek;

	private static readonly string[] z0nek;

	private static readonly int[] z0bek;

	public static bool z0eek(string p0, bool p1)
	{
		if (string.IsNullOrEmpty(p0))
		{
			return p1;
		}
		if (p0.Equals("true", StringComparison.OrdinalIgnoreCase))
		{
			return true;
		}
		if (p0.Equals("false", StringComparison.OrdinalIgnoreCase))
		{
			return false;
		}
		return p1;
	}

	private static string[] z0eek()
	{
		string[] array = new string[200];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = i.ToString();
		}
		return array;
	}

	public static int z0eek(char p0)
	{
		if (p0 < '\u007f')
		{
			return z0mek[(uint)p0];
		}
		return -1;
	}

	static z0ZzZzqik()
	{
		z0oek = null;
		z0nek = z0eek();
		z0bek = z0rek();
		z0pek = "0123456789ABCDEF".ToCharArray();
		z0mek = z0tek();
		z0oek = new string[129];
		for (int i = 0; i < z0oek.Length; i++)
		{
			z0oek[i] = new string((char)i, 1);
		}
	}

	public static bool z0eek(string p0, string p1)
	{
		if (string.IsNullOrEmpty(p0) || string.IsNullOrEmpty(p1))
		{
			return false;
		}
		for (int num = p0.Length - 1; num >= 0; num--)
		{
			if (p1.Contains(p0[num]))
			{
				return true;
			}
		}
		return false;
	}

	public static int z0rek(char p0)
	{
		if (p0 < 'g')
		{
			return z0bek[(uint)p0];
		}
		return -1;
	}

	public static int z0tek(char p0)
	{
		if (p0 >= '0' && p0 <= '7')
		{
			return p0 - 48;
		}
		return -1;
	}

	public unsafe static byte[] z0eek(string p0)
	{
		if (string.IsNullOrEmpty(p0))
		{
			return null;
		}
		int length = p0.Length;
		byte[] array = new byte[length / 2];
		int num = 0;
		int num2 = 0;
		int num3 = -10000;
		fixed (char* ptr = p0)
		{
			char* ptr2 = ptr + length;
			char* ptr3 = ptr;
			bool flag = false;
			if (length % 2 == 0)
			{
				flag = true;
				while (ptr3 < ptr2)
				{
					char c = *(ptr3++);
					int num4 = ((c < 'g') ? z0bek[(uint)c] : (-1));
					if (num4 >= 0)
					{
						c = *(ptr3++);
						int num5 = ((c < 'g') ? z0bek[(uint)c] : (-1));
						if (num5 >= 0)
						{
							array[num++] = (byte)((num4 << 4) + num5);
							continue;
						}
						flag = false;
						break;
					}
					flag = false;
					break;
				}
			}
			if (!flag)
			{
				num = 0;
				num2 = 0;
				ptr3 = ptr;
				while (ptr3 <= ptr2)
				{
					int num6 = z0rek(*(ptr3++));
					if (num6 >= 0)
					{
						if (num2 % 2 == 0)
						{
							num3 = num6;
						}
						else
						{
							num3 = (num3 << 4) + num6;
							array[num++] = (byte)num3;
							num3 = -10000;
						}
						num2++;
					}
				}
			}
		}
		if (num3 != -10000)
		{
			array[num++] = (byte)num3;
		}
		if (num == array.Length)
		{
			return array;
		}
		byte[] array2 = new byte[num];
		Buffer.BlockCopy(array, 0, array2, 0, num - 1);
		return array2;
	}

	public static Encoding z0eek(int p0)
	{
		return z0ZzZzhbj.z0eek(p0);
	}

	public static string z0yek(char p0)
	{
		if (p0 >= '\0' && p0 < '\u0081')
		{
			return z0oek[(uint)p0];
		}
		return new string(p0, 1);
	}

	private static int[] z0rek()
	{
		int[] array = new int[103];
		for (int i = 0; i < array.Length; i++)
		{
			int num = -1;
			if (i >= 48 && i <= 57)
			{
				num = i - 48;
			}
			else if (i >= 65 && i <= 70)
			{
				num = i - 65 + 10;
			}
			else if (i >= 97 && i <= 102)
			{
				num = i - 97 + 10;
			}
			array[i] = num;
		}
		return array;
	}

	public static bool z0uek(char p0)
	{
		if (p0 != ' ' && p0 != '\r' && p0 != '\n')
		{
			return p0 == '\t';
		}
		return true;
	}

	public static string z0eek(float p0)
	{
		return z0rek((int)p0);
	}

	public static bool z0rek(string p0)
	{
		if (p0 != null && p0.Length > 0)
		{
			int length = p0.Length;
			for (int i = 0; i < length; i++)
			{
				char c = p0[i];
				if (c != ' ' && c != '\r' && c != '\t' && c != '\n')
				{
					return true;
				}
				char.IsWhiteSpace(c);
			}
		}
		return false;
	}

	public static string z0rek(int p0)
	{
		if (p0 == 0)
		{
			return "0";
		}
		if (p0 == 1)
		{
			return "1";
		}
		if (p0 >= 0 && p0 < 200)
		{
			return z0nek[p0];
		}
		return p0.ToString();
	}

	public static string z0eek(float p0, int p1 = 10)
	{
		if (p0 == 0f)
		{
			return "0";
		}
		if (p0 == 1f)
		{
			return "1";
		}
		int num = (int)p0;
		if (p0 >= 0f && p0 < 200f && p0 == (float)num)
		{
			return z0nek[(int)p0];
		}
		return p0.ToString();
	}

	public static bool z0tek(string p0)
	{
		if (string.IsNullOrEmpty(p0))
		{
			return true;
		}
		int length = p0.Length;
		for (int i = 0; i < length; i++)
		{
			if (!z0uek(p0[i]))
			{
				return false;
			}
		}
		return true;
	}

	public static string z0yek(string p0)
	{
		if (string.IsNullOrEmpty(p0))
		{
			return p0;
		}
		StringBuilder stringBuilder = new StringBuilder();
		bool flag = false;
		foreach (char c in p0)
		{
			if (z0uek(c) || c == '\u3000')
			{
				if (!flag)
				{
					flag = true;
					stringBuilder.Append(' ');
				}
			}
			else
			{
				flag = false;
				stringBuilder.Append(c);
			}
		}
		return stringBuilder.ToString();
	}

	private static int[] z0tek()
	{
		string text = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/";
		int[] array = new int[127];
		for (int i = 0; i < 127; i++)
		{
			array[i] = text.IndexOf((char)i);
		}
		return array;
	}

	public static byte[] z0uek(string p0)
	{
		if (string.IsNullOrEmpty(p0))
		{
			return null;
		}
		z0yok z0yok = new z0yok();
		int length = p0.Length;
		for (int i = 0; i < length; i++)
		{
			int num = z0eek(p0[i]);
			if (num >= 0)
			{
				z0yok.z0eek(6, num);
			}
		}
		return z0yok.z0eek();
	}

	public static string z0eek(string p0, char p1, char p2)
	{
		if (p0 != null && p0.Length == 0)
		{
			return p0;
		}
		int length = p0.Length;
		for (int i = 0; i < length; i++)
		{
			char c = p0[i];
			if (c < p1 || c > p2)
			{
				continue;
			}
			StringBuilder stringBuilder = new StringBuilder(p0.Length);
			if (i > 0)
			{
				stringBuilder.Append(p0, 0, i);
			}
			for (int j = i; j < length; j++)
			{
				int num = p0[j];
				if (num >= p1 && num <= p2)
				{
					stringBuilder.Append("&#x");
					stringBuilder.Append(num.ToString("X", NumberFormatInfo.InvariantInfo));
					stringBuilder.Append(';');
				}
				else
				{
					stringBuilder.Append((char)num);
				}
			}
			return stringBuilder.ToString();
		}
		return p0;
	}

	public static Encoding z0iek(string p0)
	{
		return z0ZzZzhbj.z0eek(p0);
	}

	public static string[] z0eek(string p0, char p1, char p2, bool p3 = false)
	{
		if (string.IsNullOrEmpty(p0))
		{
			return null;
		}
		List<string> list = new List<string>();
		int num = 0;
		int num2 = p0.Length - 1;
		for (int i = 0; i <= num2; i++)
		{
			char c = p0[i];
			if (c != p2 && i != num2)
			{
				continue;
			}
			if (i == num2 && c != p2)
			{
				i++;
			}
			int num3 = p0.IndexOf(p1, num, i - num);
			if (p3)
			{
				if (num3 >= 0)
				{
					list.Add(p0.Substring(num, num3 - num).Trim());
					list.Add(p0.Substring(num3 + 1, i - num3 - 1).Trim());
				}
				else
				{
					list.Add(p0.Substring(num, i - num).Trim());
					list.Add(string.Empty);
				}
			}
			else if (num3 >= 0)
			{
				list.Add(p0.Substring(num, num3 - num));
				list.Add(p0.Substring(num3 + 1, i - num3 - 1));
			}
			else
			{
				list.Add(p0.Substring(num, i - num));
				list.Add(string.Empty);
			}
			num = i + 1;
		}
		if (list.Count > 0)
		{
			return list.ToArray();
		}
		return null;
	}

	public static string z0eek(byte[] p0)
	{
		if (p0 == null || p0.Length == 0)
		{
			return null;
		}
		int num = p0.Length;
		char[] array = new char[num * 2];
		for (int i = 0; i < num; i++)
		{
			byte b = p0[i];
			array[i * 2] = z0pek[b >> 4];
			array[i * 2 + 1] = z0pek[b & 0xF];
		}
		return new string(array);
	}
}
