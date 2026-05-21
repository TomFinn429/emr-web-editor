using System;
using DCSystem_Drawing;

namespace zzz;

public sealed class z0ZzZzzdh : z0ZzZztfh
{
	public readonly Color z0eek;

	public readonly uint z0rek;

	private readonly bool z0tek;

	public override bool z0kd(Color p0)
	{
		return z0eek == p0;
	}

	public override bool z0jd(z0ZzZztfh p0)
	{
		if (p0 is z0ZzZzzdh)
		{
			return ((z0ZzZzzdh)p0).z0rek == z0rek;
		}
		return false;
	}

	public z0ZzZzzdh(Color p0)
	{
		z0eek = p0;
		z0rek = p0._value;
	}

	internal z0ZzZzzdh(Color p0, bool p1)
	{
		z0eek = p0;
		z0rek = p0._value;
		z0tek = p1;
	}

	public override void Dispose()
	{
		if (z0tek)
		{
			throw new InvalidOperationException("对象是永恒的");
		}
		base.Dispose();
	}
}
