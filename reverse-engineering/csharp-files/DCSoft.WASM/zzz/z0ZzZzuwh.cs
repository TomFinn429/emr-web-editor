using System;
using System.Globalization;
using System.IO;
using System.Text;

namespace zzz;

internal static class z0ZzZzuwh
{
	private sealed class z0jgj
	{
		private readonly Encoding z0tek;

		private int z0yek;

		private readonly int z0uek;

		private readonly char[] z0iek;

		private byte[] z0oek;

		private int z0pek;

		private void z0eek()
		{
			if (z0yek > 0)
			{
				z0pek += z0tek.GetChars(z0oek, 0, z0yek, z0iek, z0pek);
				z0yek = 0;
			}
		}

		internal void z0eek(byte p0)
		{
			if (z0oek == null)
			{
				z0oek = new byte[z0uek];
			}
			z0oek[z0yek++] = p0;
		}

		internal string z0rek()
		{
			if (z0yek > 0)
			{
				z0eek();
			}
			if (z0pek <= 0)
			{
				return "";
			}
			return new string(z0iek, 0, z0pek);
		}

		internal z0jgj(int p0, Encoding p1)
		{
			z0uek = p0;
			z0tek = p1;
			z0iek = new char[p0];
		}

		internal void z0eek(char p0)
		{
			if (z0yek > 0)
			{
				z0eek();
			}
			z0iek[z0pek++] = p0;
		}
	}

	private static int z0eek(string p0, int p1)
	{
		string text = p0.Substring(p1);
		for (int i = 0; i < text.Length; i++)
		{
			switch (text[i])
			{
			case '"':
			case '&':
			case '\'':
			case '<':
				return p1 + i;
			}
		}
		return -1;
	}

	internal static string z0eek(string p0)
	{
		if (string.IsNullOrEmpty(p0))
		{
			return p0;
		}
		if (z0eek(p0, 0) == -1)
		{
			return p0;
		}
		StringWriter stringWriter = new StringWriter(CultureInfo.InvariantCulture);
		z0eek(p0, stringWriter);
		return stringWriter.ToString();
	}

	internal static string z0rek(string p0)
	{
		if (!string.IsNullOrEmpty(p0))
		{
			return z0ZzZzpeh.z0iek(p0);
		}
		return p0;
	}

	internal static void z0eek(string p0, TextWriter p1)
	{
		if (p0 != null)
		{
			ArgumentNullException.ThrowIfNull(p1, "output");
			z0rek(p0, p1);
		}
	}

	internal static string z0tek(string p0)
	{
		if (!string.IsNullOrEmpty(p0))
		{
			return z0ZzZzpeh.z0uek(p0);
		}
		return p0;
	}

	private static byte[] z0eek(byte[] p0, int p1, int p2)
	{
		if (!z0rek(p0, p1, p2))
		{
			return null;
		}
		int num = 0;
		int num2 = 0;
		for (int i = 0; i < p2; i++)
		{
			char c = (char)p0[p1 + i];
			if (c == ' ')
			{
				num++;
			}
			else if (!z0ZzZziwh.z0eek(c))
			{
				num2++;
			}
		}
		if (num == 0 && num2 == 0)
		{
			if (p1 == 0 && p0.Length == p2)
			{
				return p0;
			}
			byte[] array = new byte[p2];
			Buffer.BlockCopy(p0, p1, array, 0, p2);
			return array;
		}
		byte[] array2 = new byte[p2 + num2 * 2];
		int num3 = 0;
		for (int j = 0; j < p2; j++)
		{
			byte b = p0[p1 + j];
			char c2 = (char)b;
			if (z0ZzZziwh.z0eek(c2))
			{
				array2[num3++] = b;
				continue;
			}
			if (c2 == ' ')
			{
				array2[num3++] = 43;
				continue;
			}
			array2[num3++] = 37;
			array2[num3++] = (byte)z0ZzZzywh.z0rek(b >> 4);
			array2[num3++] = (byte)z0ZzZzywh.z0rek(b);
		}
		return array2;
	}

	internal static byte[] z0eek(byte[] p0, int p1, int p2, bool p3)
	{
		byte[] array = z0eek(p0, p1, p2);
		if (!p3 || array == null || array != p0)
		{
			return array;
		}
		return (byte[])array.Clone();
	}

	private static bool z0rek(byte[] p0, int p1, int p2)
	{
		if (p0 == null && p2 == 0)
		{
			return false;
		}
		ArgumentNullException.ThrowIfNull(p0, "bytes");
		if (p1 < 0 || p1 > p0.Length)
		{
			throw new ArgumentOutOfRangeException("offset");
		}
		if (p2 < 0 || p1 + p2 > p0.Length)
		{
			throw new ArgumentOutOfRangeException("count");
		}
		return true;
	}

	internal static string z0eek(string p0, Encoding p1)
	{
		if (p0 == null)
		{
			return null;
		}
		int length = p0.Length;
		z0jgj z0jgj = new z0jgj(length, p1);
		for (int i = 0; i < length; i++)
		{
			char c = p0[i];
			switch (c)
			{
			case '+':
				c = ' ';
				break;
			case '%':
				if (i >= length - 2)
				{
					break;
				}
				if (p0[i + 1] == 'u' && i < length - 5)
				{
					int num = z0ZzZzywh.z0eek(p0[i + 2]);
					int num2 = z0ZzZzywh.z0eek(p0[i + 3]);
					int num3 = z0ZzZzywh.z0eek(p0[i + 4]);
					int num4 = z0ZzZzywh.z0eek(p0[i + 5]);
					if ((num | num2 | num3 | num4) != 255)
					{
						c = (char)((num << 12) | (num2 << 8) | (num3 << 4) | num4);
						i += 5;
						z0jgj.z0eek(c);
						continue;
					}
				}
				else
				{
					int num5 = z0ZzZzywh.z0eek(p0[i + 1]);
					int num6 = z0ZzZzywh.z0eek(p0[i + 2]);
					if ((num5 | num6) != 255)
					{
						byte p2 = (byte)((num5 << 4) | num6);
						i += 2;
						z0jgj.z0eek(p2);
						continue;
					}
				}
				break;
			}
			if ((c & 0xFF80) == 0)
			{
				z0jgj.z0eek((byte)c);
			}
			else
			{
				z0jgj.z0eek(c);
			}
		}
		return z0ZzZzowh.z0eek(z0jgj.z0rek());
	}

	private static void z0rek(string p0, TextWriter p1)
	{
		int num = z0eek(p0, 0);
		if (num == -1)
		{
			p1.Write(p0);
			return;
		}
		p1.Write(p0.Substring(0, num));
		string text = p0.Substring(num);
		foreach (char c in text)
		{
			if (c <= '<')
			{
				switch (c)
				{
				case '<':
					p1.Write("&lt;");
					break;
				case '"':
					p1.Write("&quot;");
					break;
				case '\'':
					p1.Write("&#39;");
					break;
				case '&':
					p1.Write("&amp;");
					break;
				default:
					p1.Write(c);
					break;
				}
			}
			else
			{
				p1.Write(c);
			}
		}
	}
}
