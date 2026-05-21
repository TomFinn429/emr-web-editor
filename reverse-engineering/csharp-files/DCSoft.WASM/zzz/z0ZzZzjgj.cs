using System.Text;

namespace zzz;

internal class z0ZzZzjgj : z0ZzZzygj
{
	private z0ZzZzuxk z0cek;

	internal void z0eek(int p0)
	{
		z0cek.z0uek(3);
		z0cek.z0eek((byte)((p0 & 0xFF0000) >> 16));
		z0cek.z0eek((byte)((p0 & 0xFF00) >> 8));
		z0cek.z0eek((byte)(p0 & 0xFF));
	}

	internal z0ZzZzjgj()
	{
		z0cek = new z0ZzZzuxk();
	}

	internal void z0eek(short p0)
	{
		z0cek.z0uek(2);
		z0cek.z0eek((byte)((p0 & 0xFF00) >> 8));
		z0cek.z0eek((byte)(p0 & 0xFF));
	}

	internal void z0rek(int p0)
	{
		z0cek.z0eek(p0);
	}

	protected override void z0ygk(bool p0)
	{
		if (p0)
		{
			z0cek.Dispose();
			z0cek = null;
		}
	}

	internal byte[] z0eek()
	{
		return z0cek.z0rek();
	}

	internal z0ZzZzjgj z0tek(int p0)
	{
		return new z0ZzZzjgj(0)
		{
			z0cek = z0cek.z0iek(p0)
		};
	}

	internal void z0eek(short[] p0)
	{
		z0cek.z0uek(p0.Length * 2);
		foreach (short p1 in p0)
		{
			z0eek(p1);
		}
	}

	internal void z0eek(byte[] p0)
	{
		z0cek.z0eek(p0, 0, p0.Length);
	}

	internal int z0rek()
	{
		return z0cek.z0pek();
	}

	internal byte z0tek()
	{
		return (byte)z0cek.z0yek();
	}

	private z0ZzZzjgj(int p0)
	{
	}

	internal short z0yek()
	{
		return z0cek.z0iek();
	}

	internal byte[] z0yek(int p0)
	{
		return z0cek.z0oek(p0);
	}

	internal long z0uek()
	{
		return z0cek.z0uek();
	}

	internal float z0iek()
	{
		return (float)z0nek() / 65536f;
	}

	internal long z0oek()
	{
		return z0cek.z0mek();
	}

	public z0ZzZzuxk z0pek()
	{
		return z0cek;
	}

	internal short[] z0uek(int p0)
	{
		short[] array = new short[p0];
		for (int i = 0; i < p0; i++)
		{
			array[i] = z0cek.z0iek();
		}
		return array;
	}

	internal z0ZzZzjgj(byte[] p0)
	{
		z0cek = new z0ZzZzuxk(p0);
	}

	internal void z0eek(byte p0)
	{
		z0cek.z0eek(p0);
	}

	internal void z0eek(long p0)
	{
		z0cek.z0rek((int)p0);
	}

	internal int z0mek()
	{
		return z0cek.z0tek();
	}

	internal int z0nek()
	{
		return z0cek.z0eek();
	}

	internal void z0eek(string p0)
	{
		z0cek.z0uek(p0.Length);
		foreach (char c in p0)
		{
			z0cek.z0eek((byte)c);
		}
	}

	internal int z0bek()
	{
		return (z0cek.z0yek() << 16) + (z0cek.z0yek() << 8) + z0cek.z0yek();
	}

	internal string z0iek(int p0)
	{
		StringBuilder stringBuilder = new StringBuilder();
		for (int i = 0; i < p0; i++)
		{
			stringBuilder.Append((char)z0cek.z0yek());
		}
		return stringBuilder.ToString();
	}

	internal void z0oek(int p0)
	{
		z0cek.z0yek(p0);
	}

	internal byte[] z0vek()
	{
		z0cek.z0rek(0);
		int num = z0cek.z0tek();
		int num2 = num % 4;
		return z0cek.z0oek(num + ((num2 > 0) ? (4 - num2) : 0));
	}
}
