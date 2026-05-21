using System.Collections.Generic;

namespace zzz;

internal class z0ZzZzkgj : z0ZzZzqgj
{
	private readonly byte[] z0rek;

	internal override byte[] z0qsk()
	{
		return z0rek;
	}

	internal new z0ZzZzraj z0eek(z0ZzZzeaj p0)
	{
		base.z0eek(p0);
		return new z0ZzZzraj(p0, z0rek);
	}

	internal z0ZzZzkgj(IList<z0ZzZzaqj> p0, byte[] p1)
		: base(p0)
	{
		z0rek = p1;
	}

	internal z0ZzZzkgj(byte[] p0)
		: this(new z0ZzZzaqj[1]
		{
			new z0ZzZzqqj(null)
		}, z0ZzZzlfj.z0eek(p0))
	{
	}
}
