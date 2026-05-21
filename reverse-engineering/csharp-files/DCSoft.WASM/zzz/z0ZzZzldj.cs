using System;
using System.Collections.Generic;

namespace zzz;

internal class z0ZzZzldj : z0ZzZzbfj
{
	private new readonly bool z0eek;

	private new readonly string z0rek;

	private new readonly bool z0tek;

	private new readonly z0ZzZzzfj z0yek;

	internal override bool z0ddk()
	{
		return z0tek;
	}

	internal override bool z0fdk()
	{
		return z0eek;
	}

	internal override double z0gdk(int p0)
	{
		return z0yek.z0uek(p0);
	}

	internal override z0ZzZzvfj z0hdk()
	{
		z0ZzZzidj z0ZzZzidj2 = z0yek.z0krk();
		z0eek();
		z0ZzZzyqj z0ZzZzyqj2 = (z0yek() ? ((z0ZzZzyqj)4) : ((z0ZzZzyqj)32));
		z0ZzZzawj z0ZzZzawj2 = z0yek.z0uek()?.z0rek() ?? default(z0ZzZzawj);
		if (z0ZzZzawj2.z0tek() == (z0ZzZzwwj)9)
		{
			z0ZzZzyqj2 |= (z0ZzZzyqj)1;
		}
		z0ZzZzewj z0ZzZzewj2 = z0ZzZzawj2.z0rek();
		if (z0ZzZzewj2 != (z0ZzZzewj)11 && z0ZzZzewj2 != (z0ZzZzewj)12 && z0ZzZzewj2 != (z0ZzZzewj)13)
		{
			z0ZzZzyqj2 |= (z0ZzZzyqj)2;
		}
		if (z0ZzZzawj2.z0eek() == (z0ZzZzqwj)3)
		{
			z0ZzZzyqj2 |= (z0ZzZzyqj)8;
		}
		if (z0iek())
		{
			z0ZzZzyqj2 |= (z0ZzZzyqj)64;
		}
		z0ZzZzqdj z0ZzZzqdj2 = z0yek.z0xek();
		int p;
		if (z0ZzZzqdj2 != null)
		{
			p = z0ZzZzqdj2.z0eek();
		}
		else
		{
			z0ZzZzfaj z0ZzZzfaj2 = z0yek.z0oek();
			p = ((z0ZzZzfaj2 != null) ? Math.Max(0, z0ZzZzfaj2.z0eek().Length - 1) : 0);
		}
		return new z0ZzZzvfj(z0eek(), z0ZzZzyqj2, z0ZzZzidj2?.z0rek() ?? 0f, z0uek(), p);
	}

	internal override byte[] z0jdk(IDictionary<int, string> p0)
	{
		return z0yek.z0tek(p0);
	}

	protected override void z0ygk(bool p0)
	{
		if (z0yek != null && z0ZzZzlxk.z0yek(z0yek))
		{
			z0yek.Dispose();
		}
	}

	internal override string z0kdk()
	{
		return z0rek;
	}

	internal z0ZzZzldj(string p0, z0ZzZziqj p1, z0ZzZzzfj p2, bool p3)
		: base(p0, p1, new z0ZzZzwdj(p2))
	{
		z0yek = p2;
		z0eek = p3;
		z0ZzZzidj z0ZzZzidj2 = p2.z0krk();
		z0tek = z0iek() && z0ZzZzidj2 != null && Math.Abs(z0ZzZzidj2.z0rek()) < 1E-45f;
		z0rek = z0tek();
		z0ZzZztdj z0ZzZztdj2 = p2.z0bek();
		if (z0ZzZztdj2 != null && !string.IsNullOrEmpty(z0ZzZztdj2.z0rek()) && z0ZzZztdj2.z0rek() != z0ZzZztdj2.z0tek() && !string.IsNullOrEmpty(z0ZzZztdj2.z0eek()))
		{
			z0rek = z0ZzZztdj2.z0eek();
		}
	}
}
