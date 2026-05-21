using System;

namespace zzz;

public class z0ZzZzkmk : IDisposable
{
	private static readonly byte[] z0rek = new byte[4] { 0, 1, 1, 7 };

	private z0ZzZznfh z0tek = new z0ZzZznfh();

	public static readonly z0ZzZzkmk z0yek = new z0ZzZzkmk();

	public z0ZzZzkmk(z0ZzZzpdh p0, z0ZzZzpdh p1, z0ZzZzpdh p2, z0ZzZzpdh p3, bool p4)
	{
		z0tek = z0eek(p0, p1, p2, p3, p4);
	}

	protected z0ZzZzkmk()
	{
	}

	public static z0ZzZznfh z0eek(z0ZzZzpdh p0, z0ZzZzpdh p1, z0ZzZzpdh p2, z0ZzZzpdh p3, bool p4)
	{
		byte[] array = (byte[])z0rek.Clone();
		if (p4)
		{
			array[3] |= 6;
		}
		return new z0ZzZznfh(new z0ZzZzpdh[4] { p0, p1, p2, p3 }, array);
	}

	public static z0ZzZznfh z0eek(float p0, float p1, float p2, float p3, float p4, float p5)
	{
		return z0eek(new z0ZzZzpdh(p0, p1), new z0ZzZzpdh(p2, p3), new z0ZzZzpdh(p2 + p4, p3 + p5), new z0ZzZzpdh(p0 + p4, p1 + p5), p4: true);
	}

	public void z0eek(z0ZzZzjpk p0, z0ZzZzudh p1, z0ZzZztfh p2)
	{
		if (p2 != null)
		{
			p0.z0eek(p2, z0tek);
		}
		if (p1 != null)
		{
			p0.z0eek(p1, z0tek);
		}
	}

	public static z0ZzZznfh z0eek(z0ZzZzpdh p0, z0ZzZzpdh p1, float p2, float p3)
	{
		return z0eek(p0, p1, new z0ZzZzpdh(p1.z0rek() + p2, p1.z0tek() + p3), new z0ZzZzpdh(p0.z0rek() + p2, p0.z0tek() + p3), p4: true);
	}

	public void Dispose()
	{
		if (z0tek != null)
		{
			z0tek.Dispose();
			z0tek = null;
		}
	}
}
