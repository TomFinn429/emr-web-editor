using System;
using System.IO;

namespace zzz;

internal abstract class z0ZzZzdkj
{
	private readonly int z0yek;

	public static Func<byte[], byte[]> z0uek;

	private readonly int z0iek;

	internal static z0ZzZzdkj z0rek(z0ZzZzrfh p0, bool p1, long p2, bool p3, byte[] p4)
	{
		if (p0.z0pek().Equals(z0ZzZzrdh.z0bek) || p4 != null)
		{
			return new z0ZzZzfkj(z0rek(p0, p4), p0.z0iek(), ((z0ZzZzedh)p0).z0yek());
		}
		if (z0uek == null)
		{
			throw new NotSupportedException("DCWriter5-PDF:" + p0.z0pek().z0iek);
		}
		byte[] array = z0uek(p0.z0eek());
		if (array == null || array.Length == 0)
		{
			throw new NotSupportedException("DCWriter5-PDF:" + p0.z0pek().z0iek);
		}
		return new z0ZzZzfkj(array, p0.z0iek(), ((z0ZzZzedh)p0).z0yek());
	}

	internal int z0rek()
	{
		return z0yek;
	}

	internal abstract z0ZzZzfej z0aak();

	protected z0ZzZzdkj(int p0, int p1)
	{
		z0iek = p0;
		z0yek = p1;
	}

	protected static byte[] z0eek(Action<Stream> p0)
	{
		using MemoryStream memoryStream = new MemoryStream();
		p0(memoryStream);
		return memoryStream.ToArray();
	}

	protected z0ZzZzdkj(z0ZzZzedh p0)
		: this(p0.z0iek(), p0.z0yek())
	{
	}

	protected static byte[] z0rek(z0ZzZzrfh p0, byte[] p1)
	{
		if (p1 != null && p1.Length != 0 && z0ZzZzpuk.z0uek(p1))
		{
			return p1;
		}
		if (z0uek == null)
		{
			return p0.z0eek();
		}
		return z0uek(p0.z0eek());
	}

	internal abstract int z0kak();

	internal int z0tek()
	{
		return z0iek;
	}
}
