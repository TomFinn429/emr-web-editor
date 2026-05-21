using System;
using System.IO;
using System.Text;

namespace zzz;

internal class z0ZzZztoj : Stream
{
	private long z0tek;

	private byte[] z0yek;

	private int z0uek;

	internal static readonly char[] z0iek = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/=".ToCharArray();

	private byte[] z0oek;

	internal bool z0pek;

	private int z0mek;

	private int z0nek;

	public override bool CanWrite => true;

	public override long Length => z0tek;

	public override long Position
	{
		get
		{
			return z0tek;
		}
		set
		{
			throw new NotImplementedException();
		}
	}

	public override bool CanSeek => false;

	public override bool CanRead => false;

	public z0ZzZztoj(bool p0)
	{
		z0pek = p0;
		z0nek = (p0 ? 49152 : 65536);
		z0oek = new byte[z0nek];
		z0ZzZzroj.z0uek();
	}

	public override void WriteByte(byte value)
	{
		if (z0mek < z0nek - 1)
		{
			z0oek[z0mek++] = value;
			if (z0mek == z0nek)
			{
				Flush();
			}
		}
		else
		{
			Flush();
			z0oek[z0mek++] = value;
		}
		z0tek++;
	}

	public z0ZzZztoj()
	{
		z0oek = new byte[65536];
		z0nek = z0oek.Length;
		z0ZzZzroj.z0uek();
	}

	public override void SetLength(long value)
	{
		throw new NotImplementedException();
	}

	private static void z0eek(byte[] p0)
	{
		z0ZzZzroj.z0rek(p0);
	}

	public static int z0eek(int p0)
	{
		return (p0 + 2) / 3 * 4;
	}

	public override void Write(byte[] bs, int startIndex, int length)
	{
		if (bs == null)
		{
			throw new ArgumentNullException("bs");
		}
		if (length <= 0)
		{
			return;
		}
		int num = startIndex + length;
		int num2 = startIndex;
		int num3 = z0nek;
		if (z0pek)
		{
			num3 -= num3 % 3;
		}
		while (num2 < num)
		{
			int num4 = num3 - z0mek;
			if (num4 > num - num2)
			{
				num4 = num - num2;
			}
			Buffer.BlockCopy(bs, num2, z0oek, z0mek, num4);
			num2 += num4;
			z0mek += num4;
			if (z0mek >= num3)
			{
				Flush();
			}
		}
		z0tek += length;
	}

	public override int Read(byte[] buffer, int offset, int count)
	{
		throw new NotImplementedException();
	}

	public override long Seek(long offset, SeekOrigin origin)
	{
		throw new NotImplementedException();
	}

	public void z0eek(char[] p0, int p1, Encoding p2)
	{
		if (z0pek)
		{
			throw new NotSupportedException("WriteChars");
		}
		Flush();
		int byteCount = p2.GetByteCount(p0, 0, p1);
		if (byteCount > z0nek)
		{
			byte[] bytes = p2.GetBytes(p0, 0, p1);
			Write(bytes, 0, bytes.Length);
			bytes = null;
		}
		else
		{
			p2.GetBytes(p0, 0, p1, z0oek, 0);
			z0mek = byteCount;
			z0tek += byteCount;
			Flush();
		}
	}

	public override void Close()
	{
		Flush();
		z0mek = 0;
		z0oek = null;
		z0yek = null;
	}

	private unsafe int z0eek()
	{
		int num = (z0mek + 2) / 3 * 4;
		if (z0yek == null || z0yek.Length < num)
		{
			z0yek = new byte[num];
		}
		int num2 = z0mek % 3;
		int num3 = z0mek - num2;
		int num4 = 0;
		byte[] array = z0oek;
		fixed (char* ptr = z0iek)
		{
			int i;
			for (i = 0; i < num3; i += 3)
			{
				z0yek[num4] = (byte)ptr[(array[i] & 0xFC) >> 2];
				z0yek[num4 + 1] = (byte)ptr[((array[i] & 3) << 4) | ((array[i + 1] & 0xF0) >> 4)];
				z0yek[num4 + 2] = (byte)ptr[((array[i + 1] & 0xF) << 2) | ((array[i + 2] & 0xC0) >> 6)];
				z0yek[num4 + 3] = (byte)ptr[array[i + 2] & 0x3F];
				num4 += 4;
			}
			i = num3;
			switch (num2)
			{
			case 2:
				z0yek[num4] = (byte)ptr[(array[i] & 0xFC) >> 2];
				z0yek[num4 + 1] = (byte)ptr[((array[i] & 3) << 4) | ((array[i + 1] & 0xF0) >> 4)];
				z0yek[num4 + 2] = (byte)ptr[(array[i + 1] & 0xF) << 2];
				z0yek[num4 + 3] = (byte)ptr[64];
				num4 += 4;
				break;
			case 1:
				z0yek[num4] = (byte)ptr[(array[i] & 0xFC) >> 2];
				z0yek[num4 + 1] = (byte)ptr[(array[i] & 3) << 4];
				z0yek[num4 + 2] = (byte)ptr[64];
				z0yek[num4 + 3] = (byte)ptr[64];
				num4 += 4;
				break;
			}
		}
		return num;
	}

	public override void Flush()
	{
		if (z0mek > 0)
		{
			if (z0pek)
			{
				z0rek();
			}
			else
			{
				if (z0mek == z0nek)
				{
					z0eek(z0oek);
				}
				else
				{
					byte[] array = new byte[z0mek];
					Buffer.BlockCopy(z0oek, 0, array, 0, z0mek);
					z0eek(array);
					array = null;
				}
				z0uek += z0mek;
			}
		}
		z0mek = 0;
	}

	private void z0rek()
	{
		int num = z0eek();
		if (num == z0yek.Length)
		{
			z0eek(z0yek);
		}
		else
		{
			byte[] array = new byte[num];
			Buffer.BlockCopy(z0yek, 0, array, 0, num);
			z0eek(array);
			array = null;
		}
		z0uek += z0yek.Length;
	}
}
