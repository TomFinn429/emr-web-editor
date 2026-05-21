using System;
using System.Text;

namespace zzz;

public class z0ZzZzydh : IDisposable
{
	[ThreadStatic]
	private static byte[] z0tek = new byte[1024];

	private static byte[] z0yek = new byte[51200];

	internal int z0uek;

	public static readonly byte[] z0iek = new byte[5120];

	private int z0oek;

	internal static byte[] z0pek = z0yek;

	private Encoding z0mek = Encoding.UTF8;

	internal byte[] z0nek;

	public void z0eek(int p0, int p1, int p2, int p3)
	{
		int num = z0uek;
		if (z0oek < num + 16)
		{
			z0rek(num + 16);
		}
		byte[] array = z0nek;
		array[num] = (byte)(p0 >> 24);
		array[num + 1] = (byte)(p0 >> 16);
		array[num + 2] = (byte)(p0 >> 8);
		array[num + 3] = (byte)p0;
		array[num + 4] = (byte)(p1 >> 24);
		array[num + 5] = (byte)(p1 >> 16);
		array[num + 6] = (byte)(p1 >> 8);
		array[num + 7] = (byte)p1;
		array[num + 8] = (byte)(p2 >> 24);
		array[num + 9] = (byte)(p2 >> 16);
		array[num + 10] = (byte)(p2 >> 8);
		array[num + 11] = (byte)p2;
		array[num + 12] = (byte)(p3 >> 24);
		array[num + 13] = (byte)(p3 >> 16);
		array[num + 14] = (byte)(p3 >> 8);
		array[num + 15] = (byte)p3;
		z0uek = num + 16;
	}

	public void z0eek(int p0, int p1)
	{
		int num = z0uek;
		if (z0oek < num + 8)
		{
			z0rek(num + 8);
		}
		byte[] array = z0nek;
		array[num] = (byte)(p0 >> 24);
		array[num + 1] = (byte)(p0 >> 16);
		array[num + 2] = (byte)(p0 >> 8);
		array[num + 3] = (byte)p0;
		array[num + 4] = (byte)(p1 >> 24);
		array[num + 5] = (byte)(p1 >> 16);
		array[num + 6] = (byte)(p1 >> 8);
		array[num + 7] = (byte)p1;
		z0uek = num + 8;
	}

	public void z0eek(byte p0)
	{
		if (z0uek == z0oek)
		{
			z0rek(z0uek + 1);
		}
		z0nek[z0uek++] = p0;
	}

	public void Dispose()
	{
		if (z0nek == z0pek)
		{
			z0yek = z0nek;
		}
		z0oek = 0;
		z0nek = null;
	}

	public void z0eek(short p0)
	{
		int num = z0uek;
		z0rek(num + 2);
		z0nek[num] = (byte)((p0 >> 8) & 0xFF);
		z0nek[num + 1] = (byte)(p0 & 0xFF);
		z0uek = num + 2;
	}

	public z0ZzZzydh()
	{
		if (z0yek == null)
		{
			z0nek = new byte[1024];
		}
		else
		{
			z0nek = z0yek;
			z0yek = null;
		}
		z0oek = z0nek.Length;
	}

	public void z0eek(z0ZzZzqdh p0)
	{
		z0eek((byte)p0);
	}

	public void z0eek(float p0)
	{
		int p1 = BitConverter.SingleToInt32Bits(p0);
		z0eek(p1);
	}

	public void z0eek(bool p0)
	{
		z0eek(p0 ? ((byte)1) : ((byte)0));
	}

	public void z0eek(string p0)
	{
		if (string.IsNullOrEmpty(p0))
		{
			z0rek(z0uek + 4);
			z0nek[z0uek] = 0;
			z0nek[z0uek + 1] = 0;
			z0nek[z0uek + 2] = 0;
			z0nek[z0uek + 3] = 0;
			z0uek += 4;
			return;
		}
		if (z0tek == null || z0tek.Length < p0.Length * 3)
		{
			z0tek = new byte[p0.Length * 3];
		}
		int bytes = z0mek.GetBytes(p0, 0, p0.Length, z0tek, 0);
		z0rek(z0uek + bytes + 4);
		z0eek(bytes);
		Buffer.BlockCopy(z0tek, 0, z0nek, z0uek, bytes);
		z0uek += bytes;
	}

	public void z0eek(int p0)
	{
		int num = z0uek;
		if (z0oek < num + 4)
		{
			z0rek(num + 4);
		}
		byte[] array = z0nek;
		array[num] = (byte)(p0 >> 24);
		array[num + 1] = (byte)(p0 >> 16);
		array[num + 2] = (byte)(p0 >> 8);
		array[num + 3] = (byte)p0;
		z0uek = num + 4;
	}

	public byte[] z0eek()
	{
		byte[] array = new byte[z0uek];
		Buffer.BlockCopy(z0nek, 0, array, 0, z0uek);
		return array;
	}

	public void z0eek(z0ZzZzydh p0)
	{
		z0rek(z0uek + p0.z0uek);
		Array.Copy(p0.z0nek, 0, z0nek, z0uek, p0.z0uek);
		z0uek += p0.z0uek;
	}

	public int z0rek()
	{
		return z0uek;
	}

	public z0ZzZzydh(byte[] p0)
	{
		if (p0 == null || p0.Length == 0)
		{
			throw new ArgumentNullException("bsBuffer");
		}
		z0nek = p0;
		z0oek = z0nek.Length;
	}

	public void z0eek(byte[] p0)
	{
		if (p0 == null || p0.Length == 0)
		{
			z0rek(z0uek + 2);
			z0nek[z0uek++] = 0;
			z0nek[z0uek++] = 0;
		}
		else
		{
			z0rek(z0uek + p0.Length + 4);
			z0eek(p0.Length);
			Buffer.BlockCopy(p0, 0, z0nek, z0uek, p0.Length);
			z0uek += p0.Length;
		}
	}

	public override string ToString()
	{
		return "Bytes " + z0uek;
	}

	private void z0rek(int p0)
	{
		if (z0oek < p0)
		{
			byte[] array = new byte[(int)((double)p0 * 1.5)];
			Buffer.BlockCopy(z0nek, 0, array, 0, z0uek);
			if (z0nek == z0pek)
			{
				z0pek = array;
			}
			z0nek = array;
			z0oek = array.Length;
		}
	}
}
