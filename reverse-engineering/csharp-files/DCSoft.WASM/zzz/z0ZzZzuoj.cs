using System;
using System.IO;
using System.Text;

namespace zzz;

internal class z0ZzZzuoj : TextWriter, z0ZzZzhqh.z0xnk
{
	private int z0yek;

	private char[] z0uek = new char[21504];

	private z0ZzZztoj z0iek = new z0ZzZztoj();

	public override Encoding Encoding => System.Text.Encoding.UTF8;

	public override void Close()
	{
		Flush();
		z0iek.Close();
		z0iek = null;
		z0yek = 0;
		z0uek = null;
	}

	public override void Write(string str)
	{
		if (str == null || str.Length == 0)
		{
			return;
		}
		int length = str.Length;
		int num = 0;
		while (num < length)
		{
			int num2 = 21504 - z0yek;
			if (num2 > length - num)
			{
				num2 = length - num;
			}
			str.CopyTo(num, z0uek, z0yek, num2);
			num += num2;
			z0yek += num2;
			if (z0yek >= 21504)
			{
				Flush();
			}
		}
	}

	public char[] z0eek()
	{
		return z0uek;
	}

	public override void Write(char value)
	{
		if (z0yek < 21503)
		{
			z0uek[z0yek++] = value;
			if (z0yek == 21504)
			{
				Flush();
			}
		}
		else
		{
			Flush();
			z0uek[z0yek++] = value;
		}
	}

	public void z0fkk(byte[] p0, int p1, int p2)
	{
		if (p0 == null || p0.Length == 0 || p1 < 0 || p1 + p2 > p0.Length || p2 <= 0)
		{
			return;
		}
		Flush();
		if (!z0iek.z0pek)
		{
			z0iek.Flush();
			z0iek.z0pek = true;
			z0iek.Write(p0, p1, p2);
			z0iek.Flush();
			z0iek.z0pek = false;
			return;
		}
		int num = 16125;
		if (num >= p2)
		{
			z0yek = Convert.ToBase64CharArray(p0, p1, p2, z0uek, 0);
			return;
		}
		int num2 = p1 + p2;
		for (int i = p1; i < num2; i += num)
		{
			z0yek = Convert.ToBase64CharArray(p0, i, Math.Min(num, num2 - i), z0uek, 0);
			Flush();
		}
	}

	public z0ZzZztoj z0rek()
	{
		return z0iek;
	}

	public override void Write(char[] chrs, int startIndex, int length)
	{
		if (chrs == null)
		{
			throw new ArgumentNullException("chrs");
		}
		if (length <= 0)
		{
			return;
		}
		int num = startIndex + length;
		int num2 = startIndex;
		while (num2 < num)
		{
			int num3 = 21504 - z0yek;
			if (num3 > num - num2)
			{
				num3 = num - num2;
			}
			Array.Copy(chrs, num2, z0uek, z0yek, num3);
			num2 += num3;
			z0yek += num3;
			if (z0yek >= 21504)
			{
				Flush();
			}
		}
	}

	public override void Flush()
	{
		z0iek.z0eek(z0uek, z0yek, Encoding);
		z0yek = 0;
	}
}
