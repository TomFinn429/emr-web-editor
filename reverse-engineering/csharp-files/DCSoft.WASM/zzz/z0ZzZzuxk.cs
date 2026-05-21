using System;
using System.Globalization;
using System.IO;

namespace zzz;

internal class z0ZzZzuxk : IDisposable
{
	private int z0nek;

	private int z0bek;

	private int z0vek;

	private int z0cek_jiejie20260327142557;

	private static readonly byte[] z0xek = Array.Empty<byte>();

	private bool z0zek;

	private static readonly CultureInfo z0lrk = CultureInfo.InvariantCulture;

	private int z0krk;

	private Stream z0jrk;

	private z0ZzZzrik z0hrk;

	private byte[] z0grk;

	public void z0eek(short[] p0)
	{
		if (z0nek + p0.Length * 2 > z0krk)
		{
			return;
		}
		short num = 0;
		int num2 = p0.Length;
		if (z0vek == 0)
		{
			for (int i = 0; i < num2; i++)
			{
				num = z0grk[z0nek++];
				num <<= 8;
				num += z0grk[z0nek++];
				p0[i] = num;
			}
		}
		else
		{
			for (int j = 0; j < num2; j++)
			{
				num = z0grk[z0vek + z0nek++];
				num <<= 8;
				num += z0grk[z0vek + z0nek++];
				p0[j] = num;
			}
		}
	}

	public int z0eek()
	{
		if (z0nek + 4 <= z0krk)
		{
			int num = z0vek + z0nek;
			int result = (((z0grk[num] << 8) + z0grk[num + 1] << 8) + z0grk[num + 2] << 8) + z0grk[num + 3];
			z0nek += 4;
			return result;
		}
		return 0;
	}

	public byte[] z0rek()
	{
		if (z0zek)
		{
			byte[] array = new byte[z0krk];
			Buffer.BlockCopy(z0grk, z0vek, array, 0, z0krk);
			return array;
		}
		if (z0krk == z0bek)
		{
			return z0grk;
		}
		byte[] array2 = new byte[z0krk];
		Buffer.BlockCopy(z0grk, 0, array2, 0, z0krk);
		return array2;
	}

	public int z0tek()
	{
		return z0krk;
	}

	public void z0eek(int p0)
	{
		if (z0nek + p0 < z0krk)
		{
			z0nek += p0;
		}
	}

	public int z0yek()
	{
		if (z0nek < z0krk)
		{
			return z0grk[z0vek + z0nek++];
		}
		return -1;
	}

	public void z0eek(byte[] p0, int p1, int p2)
	{
		if (z0zek)
		{
			throw new Exception("subreader");
		}
		if (p2 <= 0)
		{
			return;
		}
		z0uek(p2);
		if (p2 <= 8)
		{
			int num = p2;
			while (--num >= 0)
			{
				z0grk[z0nek + num] = p0[p1 + num];
			}
		}
		else
		{
			Buffer.BlockCopy(p0, p1, z0grk, z0nek, p2);
		}
		z0nek += p2;
		if (z0nek > z0krk)
		{
			z0krk = z0nek;
		}
	}

	public void z0eek(Stream p0)
	{
		z0jrk = p0;
	}

	public int z0uek()
	{
		return z0nek;
	}

	public z0ZzZzuxk()
	{
		z0grk = new byte[256];
		z0bek = z0grk.Length;
	}

	public void z0rek(int p0)
	{
		z0nek = p0;
	}

	internal void z0eek(short p0)
	{
		z0uek(2);
		z0grk[z0vek + z0nek++] = (byte)((p0 & 0xFF00) >> 8);
		z0grk[z0vek + z0nek++] = (byte)(p0 & 0xFF);
		if (z0nek > z0krk)
		{
			z0krk = z0nek;
		}
	}

	public short z0iek()
	{
		if (z0nek + 2 <= z0krk)
		{
			int num = z0vek + z0nek;
			short result = (short)((z0grk[num] << 8) + z0grk[num + 1]);
			z0nek += 2;
			return result;
		}
		return 0;
	}

	public void z0oek()
	{
		if (z0krk > 0 && z0jrk != null)
		{
			z0jrk.Write(z0grk, z0vek, z0krk);
		}
	}

	public z0ZzZzzck z0tek(int p0)
	{
		int num = p0;
		if (z0nek + p0 > z0krk)
		{
			num = z0krk - z0nek;
		}
		if (num > 0)
		{
			z0ZzZzzck result = new z0ZzZzzck(z0grk, z0vek + z0nek, num);
			z0nek += num;
			return result;
		}
		return default(z0ZzZzzck);
	}

	public int z0pek()
	{
		if (z0nek + 2 <= z0krk)
		{
			return (z0grk[z0vek + z0nek++] << 8) + z0grk[z0vek + z0nek++];
		}
		return 0;
	}

	public z0ZzZzuxk(byte[] p0)
	{
		z0grk = p0;
		z0bek = p0.Length;
		z0krk = p0.Length;
	}

	private z0ZzZzuxk(int p0)
	{
	}

	public long z0mek()
	{
		if (z0nek + 8 <= z0krk)
		{
			return (long)(((((((((ulong)z0grk[z0nek++] << 8) + z0grk[z0vek + z0nek++] << 8) + z0grk[z0vek + z0nek++] << 8) + z0grk[z0vek + z0nek++] << 8) + z0grk[z0vek + z0nek++] << 8) + z0grk[z0vek + z0nek++] << 8) + z0grk[z0vek + z0nek++] << 8) + z0grk[z0vek + z0nek++]);
		}
		return 0L;
	}

	internal unsafe void z0yek(int p0)
	{
		z0uek(4);
		fixed (byte* ptr = &z0grk[z0vek + z0nek])
		{
			*ptr = (byte)((p0 & 0xFF000000u) >> 24);
			ptr[1] = (byte)((p0 & 0xFF0000) >> 16);
			ptr[2] = (byte)((p0 & 0xFF00) >> 8);
			ptr[3] = (byte)(p0 & 0xFF);
		}
		z0nek += 4;
		if (z0nek > z0krk)
		{
			z0krk = z0nek;
		}
	}

	public void z0eek(z0ZzZzzck p0)
	{
		if (z0zek)
		{
			throw new Exception("subreader");
		}
		if (p0.z0tek > 0)
		{
			z0uek(p0.z0tek);
			Buffer.BlockCopy(p0.z0eek, p0.z0rek, z0grk, z0nek, p0.z0tek);
			z0nek += p0.z0tek;
			if (z0nek > z0krk)
			{
				z0krk = z0nek;
			}
		}
	}

	public void z0eek(byte p0)
	{
		if (z0zek)
		{
			throw new Exception("subreader");
		}
		if (z0nek + 1 > z0bek)
		{
			z0uek(1);
		}
		z0grk[z0nek++] = p0;
		if (z0nek > z0krk)
		{
			z0krk = z0nek;
		}
	}

	public void z0uek(int p0)
	{
		if (z0zek)
		{
			throw new Exception("subreader");
		}
		if (z0nek + p0 > z0bek)
		{
			if (z0grk == null)
			{
				throw new ObjectDisposedException("_Buffer");
			}
			int num = (int)((double)(z0nek + p0) * 1.5);
			byte[] array = new byte[num];
			Buffer.BlockCopy(z0grk, 0, array, 0, z0bek);
			z0grk = array;
			z0bek = num;
		}
	}

	public z0ZzZzuxk z0iek(int p0)
	{
		if (p0 < 0)
		{
			throw new ArgumentOutOfRangeException("length=" + p0);
		}
		if (z0grk == null)
		{
			throw new ObjectDisposedException("CreateSubReader");
		}
		if (z0zek)
		{
			if (z0vek + p0 > z0cek_jiejie20260327142557)
			{
				throw new ArgumentOutOfRangeException("s+l=" + Convert.ToString(z0vek + p0));
			}
		}
		else if (z0nek + p0 > z0krk)
		{
			throw new ArgumentNullException("s+l=" + z0nek + p0);
		}
		z0ZzZzuxk z0ZzZzuxk2 = new z0ZzZzuxk(1);
		if (z0zek)
		{
			z0ZzZzuxk2.z0cek_jiejie20260327142557 = z0cek_jiejie20260327142557;
		}
		else
		{
			z0ZzZzuxk2.z0cek_jiejie20260327142557 = z0krk;
		}
		z0ZzZzuxk2.z0zek = true;
		z0ZzZzuxk2.z0grk = z0grk;
		z0ZzZzuxk2.z0vek = z0vek + z0nek;
		z0ZzZzuxk2.z0krk = p0;
		z0nek += p0;
		return z0ZzZzuxk2;
	}

	public byte[] z0oek(int p0)
	{
		if (p0 == 0)
		{
			return z0xek;
		}
		if (p0 <= 0)
		{
			throw new ArgumentOutOfRangeException("length:" + p0);
		}
		int num = p0;
		if (z0nek + p0 > z0krk)
		{
			num = z0krk - z0nek;
		}
		if (num > 0)
		{
			lock (this)
			{
				if (z0hrk == null)
				{
					z0hrk = new z0ZzZzrik(z0grk);
				}
				byte[] array = z0hrk.z0eek(z0vek + z0nek, num);
				z0nek += num;
				if (p0 > array.Length)
				{
					byte[] array2 = new byte[p0];
					Array.Copy(array, array2, array.Length);
					return array2;
				}
				return array;
			}
		}
		return null;
	}

	public void Dispose()
	{
		z0grk = null;
		z0krk = 0;
		z0nek = 0;
		z0bek = 0;
		z0jrk = null;
		if (z0hrk != null)
		{
			z0hrk.Dispose();
			z0hrk = null;
		}
	}

	public unsafe int z0eek(double p0)
	{
		if (z0zek)
		{
			throw new Exception("subreader");
		}
		if (p0 > -1.5E-05 && p0 < 1.5E-05)
		{
			z0uek(2);
			int num = z0vek + z0nek;
			z0grk[num] = 32;
			z0grk[num + 1] = 48;
			z0nek += 2;
			if (z0nek > z0krk)
			{
				z0krk = z0nek;
			}
			return 2;
		}
		if (p0 > 0.999985 && p0 < 1.000015)
		{
			z0uek(2);
			int num2 = z0vek + z0nek;
			z0grk[num2] = 32;
			z0grk[num2 + 1] = 49;
			z0nek += 2;
			if (z0nek > z0krk)
			{
				z0krk = z0nek;
			}
			return 2;
		}
		z0uek(25);
		int num3 = 0;
		fixed (byte* ptr = &z0grk[z0vek + z0nek])
		{
			byte* ptr2 = ptr;
			*(ptr2++) = 32;
			if (p0 < 0.0)
			{
				*(ptr2++) = 45;
				p0 = 0.0 - p0;
			}
			if (p0 < 1.0)
			{
				int num4 = (int)(p0 * 100000.0);
				*ptr2 = 48;
				ptr2[1] = 46;
				ptr2[2] = (byte)(num4 / 10000 + 48);
				ptr2 += 3;
				if (num4 % 10000 != 0)
				{
					*(ptr2++) = (byte)(num4 / 1000 % 10 + 48);
					if (num4 % 1000 != 0)
					{
						*(ptr2++) = (byte)(num4 / 100 % 10 + 48);
						if (num4 % 100 != 0)
						{
							*(ptr2++) = (byte)(num4 / 10 % 10 + 48);
							if (num4 % 10 != 0)
							{
								*(ptr2++) = (byte)(num4 % 10 + 48);
							}
						}
					}
				}
			}
			else if (p0 <= 32767.0)
			{
				p0 += 5E-05;
				int num5 = (int)(p0 * 10000.0);
				if (num5 >= 100000000)
				{
					*(ptr2++) = (byte)(num5 / 100000000 % 10 + 48);
				}
				if (num5 >= 10000000)
				{
					*(ptr2++) = (byte)(num5 / 10000000 % 10 + 48);
				}
				if (num5 >= 1000000)
				{
					*(ptr2++) = (byte)(num5 / 1000000 % 10 + 48);
				}
				if (num5 >= 100000)
				{
					*(ptr2++) = (byte)(num5 / 100000 % 10 + 48);
				}
				if (num5 >= 10000)
				{
					*(ptr2++) = (byte)(num5 / 10000 % 10 + 48);
				}
				if (num5 % 10000 != 0)
				{
					*(ptr2++) = 46;
					*(ptr2++) = (byte)(num5 / 1000 % 10 + 48);
					if (num5 % 1000 != 0)
					{
						*(ptr2++) = (byte)(num5 / 100 % 10 + 48);
						if (num5 % 100 != 0)
						{
							*(ptr2++) = (byte)(num5 / 10 % 10 + 48);
							if (num5 % 10 != 0)
							{
								*(ptr2++) = (byte)(num5 % 10 + 48);
							}
						}
					}
				}
			}
			else
			{
				string text = ((float)p0).ToString("0.################", z0lrk);
				int length = text.Length;
				_ = new byte[length];
				for (int i = 0; i < length; i++)
				{
					*(ptr2++) = (byte)text[i];
				}
			}
			num3 = (int)(ptr2 - ptr);
		}
		z0nek += num3;
		if (z0nek > z0krk)
		{
			z0krk = z0nek;
		}
		return num3;
	}
}
