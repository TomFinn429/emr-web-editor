using System;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace zzz;

[DebuggerNonUserCode]
public sealed class z0ZzZzxck
{
	private Encoding z0oek = Encoding.UTF8;

	private Stream z0pek;

	private bool z0mek;

	public long z0eek()
	{
		byte[] array = new byte[8];
		if (z0pek.Read(array, 0, array.Length) == array.Length)
		{
			return BitConverter.ToInt64(array, 0);
		}
		z0mek = true;
		return 0L;
	}

	public string z0rek()
	{
		byte[] array = new byte[4];
		int num = z0pek.Read(array, 0, array.Length);
		if (num == array.Length)
		{
			num = BitConverter.ToInt32(array, 0);
			array = new byte[num];
			num = z0pek.Read(array, 0, num);
			if (num == array.Length)
			{
				return z0oek.GetString(array);
			}
			z0mek = true;
		}
		else
		{
			z0mek = true;
		}
		return null;
	}

	public z0ZzZzxck(Stream p0)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException(z0ZzZzlrk.z0xek);
		}
		z0pek = p0;
	}

	public bool z0tek()
	{
		return z0mek;
	}

	public int z0yek()
	{
		byte[] array = new byte[4];
		if (z0pek.Read(array, 0, array.Length) == array.Length)
		{
			return BitConverter.ToInt32(array, 0);
		}
		z0mek = true;
		return 0;
	}

	public short z0uek()
	{
		byte[] array = new byte[2];
		if (z0pek.Read(array, 0, array.Length) == array.Length)
		{
			return BitConverter.ToInt16(array, 0);
		}
		z0mek = true;
		return 0;
	}

	public int z0iek()
	{
		int num = z0pek.ReadByte();
		if (num == -1)
		{
			z0mek = true;
		}
		return num;
	}
}
