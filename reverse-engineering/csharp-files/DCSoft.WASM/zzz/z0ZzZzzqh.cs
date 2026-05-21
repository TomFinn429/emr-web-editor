using System;
using System.Runtime.CompilerServices;

namespace zzz;

internal class z0ZzZzzqh : z0ZzZzvqh
{
	[CompilerGenerated]
	private int z0yek;

	[CompilerGenerated]
	private string z0uek;

	[CompilerGenerated]
	private int z0iek;

	[CompilerGenerated]
	private void z0eek(int p0)
	{
		z0yek = p0;
	}

	internal z0ZzZzzqh(string p0, Exception p1, string p2, int p3, int p4)
		: base(p0, p1)
	{
		z0eek(p2);
		z0rek(p3);
		z0eek(p4);
	}

	[CompilerGenerated]
	private void z0eek(string p0)
	{
		z0uek = p0;
	}

	[CompilerGenerated]
	public int z0eek()
	{
		return z0yek;
	}

	[CompilerGenerated]
	private void z0rek(int p0)
	{
		z0iek = p0;
	}

	internal static z0ZzZzzqh z0eek(z0ZzZzmqh p0, string p1, string p2, Exception p3)
	{
		p2 = z0ZzZzcqh.z0eek(p0, p1, p2);
		int p4;
		int p5;
		if (p0 != null && p0.z0iq())
		{
			p4 = p0.z0tq();
			p5 = p0.z0rq();
		}
		else
		{
			p4 = 0;
			p5 = 0;
		}
		return new z0ZzZzzqh(p2, p3, p1, p4, p5);
	}

	internal static z0ZzZzzqh z0eek(z0ZzZzxqh p0, string p1, Exception p2)
	{
		return z0eek(p0 as z0ZzZzmqh, p0.z0bek(), p1, p2);
	}

	internal static z0ZzZzzqh z0eek(z0ZzZzxqh p0, string p1)
	{
		return z0eek(p0, p1, null);
	}

	[CompilerGenerated]
	public string z0rek()
	{
		return z0uek;
	}

	[CompilerGenerated]
	public int z0tek()
	{
		return z0iek;
	}
}
