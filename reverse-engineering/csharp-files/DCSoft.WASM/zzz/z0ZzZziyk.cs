using System;
using System.Text;

namespace zzz;

public class z0ZzZziyk
{
	private byte[] z0pek;

	private Encoding z0vek_jiejie20260327142557 = Encoding.UTF8;

	private int z0cek;

	private int z0xek;

	private bool z0lrk;

	private byte z0krk;

	internal static readonly byte[] z0jrk = Array.Empty<byte>();

	public void z0eek(Encoding p0)
	{
		z0vek_jiejie20260327142557 = p0;
	}

	private void z0eek(int p0)
	{
		if (!z0lrk)
		{
			return;
		}
		switch (p0)
		{
		case 1:
			z0pek[z0xek - 1] = (byte)(z0pek[z0xek - 1] ^ z0krk);
			break;
		case 2:
			z0pek[z0xek - 2] = (byte)(z0pek[z0xek - 2] ^ z0krk);
			z0pek[z0xek - 1] = (byte)(z0pek[z0xek - 1] ^ (z0krk + 13));
			break;
		default:
		{
			byte b = z0krk;
			for (int i = z0xek - p0; i < z0xek; i++)
			{
				z0pek[i] ^= b;
				b += 13;
			}
			break;
		}
		}
		z0krk += 59;
	}

	private void z0rek(int p0)
	{
		if (z0xek + p0 >= z0cek)
		{
			byte[] array = new byte[(int)Math.Max((double)(z0xek + p0) * 1.5, 32.0)];
			if (z0pek != null)
			{
				Buffer.BlockCopy(z0pek, 0, array, 0, z0xek);
			}
			z0pek = array;
			z0cek = array.Length;
		}
	}

	public void z0eek()
	{
		z0xek = 1;
		if (z0lrk)
		{
			z0krk = (byte)new Random().Next(0, 1000);
			z0pek[z0xek++] = z0krk;
		}
	}

	public unsafe static long z0eek(byte[] p0, int p1, int p2)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("bs");
		}
		if (p2 < 0)
		{
			throw new ArgumentOutOfRangeException("length<0");
		}
		if (p1 < 0 || p1 >= p0.Length)
		{
			throw new ArgumentOutOfRangeException("startIndex#" + p0.Length);
		}
		if (p1 + p2 >= p0.Length)
		{
			throw new ArgumentOutOfRangeException("startIndex+length>=" + p0.Length);
		}
		fixed (byte* ptr = p0)
		{
			long num = 5381L;
			byte* ptr2 = ptr + p1;
			for (byte* ptr3 = ptr2 + p2; ptr2 < ptr3; ptr2++)
			{
				num = ((num << 5) + num) ^ *ptr2;
			}
			return num;
		}
	}

	public void z0eek(byte p0)
	{
		z0rek(1);
		z0pek[z0xek++] = p0;
		z0eek(1);
	}

	public void z0rek()
	{
		z0pek = null;
		z0cek = 0;
		z0xek = 0;
	}

	public unsafe virtual void z0eek(float p0)
	{
		int p1 = *(int*)(&p0);
		z0tek(p1);
	}

	public long z0tek()
	{
		return z0eek(z0pek, 0, z0xek);
	}

	public void z0eek(string p0)
	{
		if (p0 == null)
		{
			z0eek((byte[])null);
		}
		else if (p0.Length == 0)
		{
			z0eek(z0jrk);
		}
		else
		{
			z0eek(z0yek().GetBytes(p0));
		}
	}

	public void z0eek(byte[] p0)
	{
		if (p0 == null)
		{
			z0rek(1);
			z0pek[z0xek++] = 0;
			z0eek(1);
			return;
		}
		if (p0.Length == 0)
		{
			z0rek(1);
			z0pek[z0xek++] = 1;
			z0eek(1);
			return;
		}
		if (p0.Length < 32)
		{
			z0rek(p0.Length + 1);
			z0pek[z0xek++] = (byte)((p0.Length << 3) + 2);
			z0eek(1);
		}
		else if (p0.Length < 255)
		{
			z0rek(p0.Length + 2);
			z0pek[z0xek++] = 3;
			z0eek(1);
			z0pek[z0xek++] = (byte)p0.Length;
			z0eek(1);
		}
		else if (p0.Length < 32767)
		{
			z0rek(p0.Length + 3);
			z0pek[z0xek++] = 4;
			z0eek(1);
			z0pek[z0xek++] = (byte)p0.Length;
			z0pek[z0xek++] = (byte)(p0.Length >> 8);
			z0eek(2);
		}
		else
		{
			z0rek(p0.Length + 5);
			z0pek[z0xek++] = 5;
			z0eek(1);
			z0pek[z0xek++] = (byte)p0.Length;
			z0pek[z0xek++] = (byte)(p0.Length >> 8);
			z0pek[z0xek++] = (byte)(p0.Length >> 16);
			z0pek[z0xek++] = (byte)(p0.Length >> 24);
			z0eek(4);
		}
		Array.Copy(p0, 0, z0pek, z0xek, p0.Length);
		z0xek += p0.Length;
		z0eek(p0.Length);
	}

	public z0ZzZziyk(bool p0 = false)
	{
		byte b = 0;
		z0lrk = p0;
		if (p0)
		{
			b |= 1;
		}
		z0rek(2);
		z0pek[z0xek++] = b;
		if (p0)
		{
			z0krk = (byte)new Random().Next(0, 1000);
			z0pek[z0xek++] = z0krk;
		}
	}

	public void z0tek(int p0)
	{
		z0rek(4);
		z0pek[z0xek++] = (byte)p0;
		z0pek[z0xek++] = (byte)(p0 >> 8);
		z0pek[z0xek++] = (byte)(p0 >> 16);
		z0pek[z0xek++] = (byte)(p0 >> 24);
		z0eek(4);
	}

	public Encoding z0yek()
	{
		return z0vek_jiejie20260327142557;
	}

	public void z0eek(short p0)
	{
		z0rek(2);
		z0pek[z0xek++] = (byte)p0;
		z0pek[z0xek++] = (byte)(p0 >> 8);
		z0eek(2);
	}

	public void z0eek(bool p0)
	{
		z0rek(1);
		z0pek[z0xek++] = (p0 ? ((byte)1) : ((byte)0));
		z0eek(1);
	}
}
