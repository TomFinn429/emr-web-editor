using System;

namespace zzz;

internal abstract class z0ZzZzfej : z0ZzZzfsj
{
	private new readonly z0ZzZzjwj z0rek;

	protected abstract z0ZzZznsj z0lfk(z0ZzZzdsj p0);

	internal static z0ZzZzfej z0eek(object p0, z0ZzZzmsj p1, string p2)
	{
		throw new NotSupportedException();
	}

	protected z0ZzZzfej()
		: base(-1)
	{
	}

	protected internal override object z0ngk(z0ZzZzdsj p0)
	{
		return z0lfk(p0);
	}

	protected virtual z0ZzZzeaj z0zgk(z0ZzZzdsj p0)
	{
		z0ZzZzeaj obj = new z0ZzZzeaj(p0);
		obj.z0yek("Type", "XObject");
		obj.z0tek_jiejie20260327142557("Metadata", z0rek);
		return obj;
	}
}
