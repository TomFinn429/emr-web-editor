using System;

namespace zzz;

internal static class z0ZzZzolj
{
	private static z0ZzZzaxk z0eek(z0ZzZzxfh p0)
	{
		throw new NotSupportedException("CreateFromLinearGradientBrush");
	}

	internal static z0ZzZzqxk z0eek(z0ZzZzudh p0)
	{
		z0ZzZzqxk obj = new z0ZzZzqxk(z0eek(p0.z0mek()), p0.z0oek());
		obj.z0eek(p0.z0eek());
		obj.z0eek(p0.z0tek());
		return obj;
	}

	internal static z0ZzZzfxk z0eek(z0ZzZztfh p0)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("brush");
		}
		if (p0 is z0ZzZzzdh z0ZzZzzdh2)
		{
			return new z0ZzZzwxk(z0ZzZzzdh2.z0eek);
		}
		if (p0 is z0ZzZzvfh z0ZzZzvfh2)
		{
			return new z0ZzZzsxk(z0ZzZzvfh2.z0rek, z0ZzZzvfh2.z0tek, z0ZzZzvfh2.z0eek_jiejie20260327142557);
		}
		if (p0 is z0ZzZzxfh p1)
		{
			return z0eek(p1);
		}
		throw new NotSupportedException("ConvertBrush:" + p0.GetType().Name);
	}
}
