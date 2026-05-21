using System;
using DCSystem_Drawing;

namespace zzz;

public abstract class z0ZzZzcxk : IDisposable
{
	private z0ZzZzadh z0tek;

	public z0ZzZzxdh z0eek_jiejie20260327142557(string p0, z0ZzZzsdh p1, float p2, z0ZzZzlsh p3, GraphicsUnit p4)
	{
		if (p4 == GraphicsUnit.Pixel)
		{
			float num = z0tek.z0pek();
			if ((double)Math.Abs(num - 96f) > 0.01)
			{
				p2 = z0ZzZzoxk.z0eek(p2, 96f, num);
				return z0ZzZzoxk.z0eek(z0rek(p0, p1, p2, p3, p4), num, 96f);
			}
		}
		return z0rek(p0, p1, p2, p3, p4);
	}

	protected z0ZzZzcxk()
	{
		z0tek = z0ZzZzadh.z0eek(new z0ZzZzrfh(1, 1));
	}

	public z0ZzZzxdh z0rek(string p0, z0ZzZzsdh p1, float p2, z0ZzZzlsh p3, GraphicsUnit p4)
	{
		return z0mak(p0, p1, new z0ZzZzxdh(p2, 999999f), p3, p4);
	}

	public virtual void Dispose()
	{
		if (z0tek != null)
		{
			z0tek.Dispose();
			z0tek = null;
		}
	}

	public abstract z0ZzZzxdh z0mak(string p0, z0ZzZzsdh p1, z0ZzZzxdh p2, z0ZzZzlsh p3, GraphicsUnit p4);

	public z0ZzZzxdh z0eek_jiejie20260327142557(string p0, z0ZzZzpej p1, float p2, z0ZzZzlsh p3, GraphicsUnit p4)
	{
		if (p4 == GraphicsUnit.Pixel)
		{
			float num = z0tek.z0pek();
			if ((double)Math.Abs(num - 96f) > 0.01)
			{
				p2 = z0ZzZzoxk.z0eek(p2, 96f, num);
				return z0ZzZzoxk.z0eek(z0rek(p0, p1, p2, p3, p4), num, 96f);
			}
		}
		return z0rek(p0, p1, p2, p3, p4);
	}

	protected z0ZzZzadh z0eek_jiejie20260327142557()
	{
		return z0tek;
	}

	public z0ZzZzxdh z0rek(string p0, z0ZzZzpej p1, float p2, z0ZzZzlsh p3, GraphicsUnit p4)
	{
		return z0nak(p0, p1, new z0ZzZzxdh(p2, 999999f), p3, p4);
	}

	public abstract z0ZzZzxdh z0nak(string p0, z0ZzZzpej p1, z0ZzZzxdh p2, z0ZzZzlsh p3, GraphicsUnit p4);
}
