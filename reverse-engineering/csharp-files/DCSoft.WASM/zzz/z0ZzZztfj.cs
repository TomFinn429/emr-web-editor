using System;

namespace zzz;

internal abstract class z0ZzZztfj : z0ZzZzjfj
{
	private new readonly short z0rek;

	private readonly int z0yek;

	internal override int z0adk()
	{
		return 6 + z0yek;
	}

	internal override void z0wdk(z0ZzZzjgj p0)
	{
		base.z0wdk(p0);
		p0.z0eek((short)z0adk());
		p0.z0eek(z0rek);
	}

	protected z0ZzZztfj(z0ZzZzudj p0, z0ZzZzxfj p1, z0ZzZzjgj p2)
		: base(p0, p1)
	{
		z0yek = Math.Max(p2.z0rek() - 6, 0);
		z0rek = p2.z0yek();
	}

	protected new int z0eek()
	{
		return z0yek;
	}
}
