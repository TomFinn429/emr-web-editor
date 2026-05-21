using System;

namespace zzz;

internal struct z0ZzZzjsj : z0ZzZzzhj, IEquatable<z0ZzZzjsj>
{
	private readonly int z0eek;

	private readonly Guid z0rek;

	public z0ZzZzjsj(Guid p0, int p1)
	{
		z0eek = p1;
		z0rek = p0;
	}

	public bool Equals(z0ZzZzjsj other)
	{
		if (z0eek == other.z0eek)
		{
			return z0rek == other.z0rek;
		}
		return false;
	}
}
