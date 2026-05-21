using System.Collections.Generic;

namespace zzz;

internal class z0ZzZzfkj : z0ZzZzdlj
{
	private new readonly byte[] z0eek;

	private new readonly byte[] z0rek;

	internal z0ZzZzfkj(int p0, int p1, byte[] p2, byte[] p3)
		: this(p0, p1, p2, p3, (z0ZzZzhqj)1, z0ZzZzdlj.z0eek())
	{
	}

	protected override byte[] z0gak()
	{
		return z0eek;
	}

	private z0ZzZzfkj(int p0, int p1, byte[] p2, byte[] p3, z0ZzZzhqj p4, IList<z0ZzZzuwj> p5)
		: base(p0, p1, p4, p5)
	{
		z0rek = p2;
		z0eek = p3;
	}

	protected override z0ZzZzaqj z0hak()
	{
		return new z0ZzZzkqj(null);
	}

	internal z0ZzZzfkj(byte[] p0, int p1, int p2)
		: this(p1, p2, p0, null)
	{
	}

	protected override byte[] z0jak()
	{
		return z0rek;
	}

	internal override int z0kak()
	{
		return z0rek.Length;
	}
}
