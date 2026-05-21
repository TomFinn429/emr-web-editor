using System;
using System.Collections;
using System.Globalization;
using System.IO;
using System.Text;

namespace zzz;

internal class z0ZzZzpgj
{
	private int z0mek;

	private static readonly CultureInfo z0nek = CultureInfo.InvariantCulture;

	private readonly bool z0bek;

	private static readonly Encoding z0vek = Encoding.UTF8;

	private z0ZzZzuxk z0cek;

	private static readonly byte[] z0xek = new byte[2] { 254, 255 };

	private readonly int z0zek;

	private static readonly Encoding z0lrk = Encoding.BigEndianUnicode;

	internal int z0eek()
	{
		return z0mek;
	}

	internal static z0ZzZzpgj z0eek(z0ZzZzuxk p0)
	{
		return new z0ZzZzpgj(p0, p1: true, p0.z0uek(), 0);
	}

	internal void z0rek()
	{
		z0tek(new byte[2] { 60, 60 }, 2);
	}

	internal void z0tek()
	{
		z0eek((byte)93);
	}

	internal z0ZzZzqsj z0eek(z0ZzZzssj p0)
	{
		z0ZzZzqsj result = null;
		if (p0 != null)
		{
			long p1 = z0tek(0);
			int num = p0.z0rek();
			z0eek("{0} 0 obj\r\n", new object[1] { num });
			if (!z0bek)
			{
				throw new NotSupportedException();
			}
			result = new z0ZzZzesj(num, 0, p1);
			z0eek(p0.z0eek(), num);
			z0eek("\r\nendobj\r\n");
		}
		return result;
	}

	internal void z0yek()
	{
		z0eek((byte)91);
	}

	internal void z0eek(string p0, params object[] p1)
	{
		z0eek(string.Format(z0nek, p0, p1));
	}

	internal void z0eek(byte p0)
	{
		z0cek.z0eek(p0);
		z0mek++;
	}

	private void z0eek(byte[] p0, int p1)
	{
		using MemoryStream memoryStream = new MemoryStream();
		memoryStream.Write(z0xek, 0, 2);
		memoryStream.Write(p0, 0, p0.Length);
		z0rek(memoryStream.ToArray(), p1);
	}

	internal void z0eek(int p0)
	{
		int num = p0 + z0zek;
		if (z0cek.z0uek() != num)
		{
			z0cek.z0rek(num);
		}
	}

	internal void z0rek(int p0)
	{
		z0eek(p0.ToString(z0nek));
	}

	internal void z0eek(string p0)
	{
		byte[] bytes = z0vek.GetBytes(p0);
		int p1 = bytes.Length;
		z0tek(bytes, p1);
	}

	internal void z0uek()
	{
		z0tek(new byte[4] { 62, 62, 13, 10 }, 4);
	}

	internal void z0eek(byte[] p0)
	{
		int p1 = p0.Length;
		z0tek(p0, p1);
	}

	internal int z0iek()
	{
		return z0cek.z0uek() - z0zek;
	}

	internal void z0oek()
	{
		z0cek.z0oek();
		z0cek.Dispose();
		z0cek = null;
	}

	internal void z0eek(double p0)
	{
		int num = z0cek.z0eek(p0);
		z0mek += num;
	}

	private z0ZzZzpgj(z0ZzZzuxk p0, bool p1, int p2, int p3)
	{
		z0cek = p0;
		z0bek = p1;
		z0mek = p3;
		z0zek = p2;
	}

	internal void z0eek(object p0, int p1)
	{
		if (p0 is z0ZzZzlgj z0ZzZzlgj2)
		{
			z0ZzZzlgj2.z0nfk(this, p1);
		}
		else if (p0 is z0ZzZziwj z0ZzZziwj2)
		{
			z0eek(z0ZzZziwj2.z0uek(), p1);
		}
		else if (p0 is int)
		{
			z0rek((int)p0);
		}
		else if (p0 is double)
		{
			z0eek((double)p0);
		}
		else if (p0 is string text)
		{
			byte[] bytes = z0lrk.GetBytes(text);
			z0eek(bytes, p1);
		}
		else if (p0 is byte[] p2)
		{
			z0rek(p2, p1);
		}
		else if (p0 is IEnumerable p3)
		{
			new z0ZzZzdaj(p3).z0nfk(this, p1);
		}
		else if (p0 is DateTimeOffset { Offset: var offset } dateTimeOffset)
		{
			int num = Convert.ToInt32(offset.TotalMinutes);
			string text2;
			if (num == 0)
			{
				text2 = $"D:{dateTimeOffset:yyyyMMddHHmmss}Z";
			}
			else
			{
				bool flag = num > 0;
				if (!flag)
				{
					num = -num;
				}
				text2 = $"D:{dateTimeOffset:yyyyMMddHHmmss}{(flag ? '+' : '-')}{num / 60:00}'{num % 60:00}'";
			}
			z0rek(z0vek.GetBytes(text2), p1);
		}
		else if (p0 is bool)
		{
			z0eek(((bool)p0) ? "true" : "false");
		}
		else
		{
			if (p0 != null)
			{
				throw new NotSupportedException();
			}
			z0eek("null");
		}
	}

	internal int z0tek(int p0)
	{
		int num = z0eek();
		int num2 = ((num > p0) ? (num - p0) : num);
		z0eek(num2);
		return num2;
	}

	internal void z0rek(byte[] p0, int p1)
	{
		int num = p0.Length;
		int num2 = num * 2 + 2;
		byte[] array = new byte[num2];
		array[0] = 60;
		array[num2 - 1] = 62;
		int i = 0;
		int num3 = 0;
		for (; i < num; i++)
		{
			byte num4 = p0[i];
			int num5 = num4 >> 4;
			array[++num3] = (byte)((num5 > 9) ? (num5 + 55) : (num5 + 48));
			num5 = num4 & 0xF;
			array[++num3] = (byte)((num5 > 9) ? (num5 + 55) : (num5 + 48));
		}
		int p2 = array.Length;
		z0tek(array, p2);
	}

	internal static byte[] z0rek(string p0)
	{
		if (p0 == null)
		{
			return null;
		}
		int length = p0.Length;
		byte[] array = new byte[length];
		for (int i = 0; i < length; i++)
		{
			array[i] = (byte)p0[i];
		}
		return array;
	}

	private void z0tek(byte[] p0, int p1)
	{
		z0cek.z0eek(p0, 0, p1);
		z0mek += p1;
	}

	internal void z0pek()
	{
		z0eek((byte)32);
	}
}
