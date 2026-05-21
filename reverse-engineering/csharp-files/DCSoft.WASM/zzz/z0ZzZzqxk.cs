using System;
using System.Collections.Generic;
using DCSystem_Drawing;
using DCSystem_Drawing.Drawing2D;

namespace zzz;

internal class z0ZzZzqxk : IDisposable
{
	private z0ZzZzldh z0vek;

	private z0ZzZzfxk z0cek;

	private z0ZzZzkdh z0xek;

	private z0ZzZzgdh z0zek;

	private DashCap z0lrk;

	private float[] z0krk;

	private DashStyle z0jrk;

	private double z0hrk = 10.0;

	private z0ZzZzldh z0grk;

	private double z0frk;

	private static IDictionary<DashStyle, float[]> z0drk;

	private double z0srk;

	internal z0ZzZzqxk(Color p0)
		: this(p0, 1.0)
	{
	}

	internal void z0eek(DashStyle p0)
	{
		if (p0 != DashStyle.Custom && p0 != DashStyle.Solid)
		{
			z0krk = z0drk[p0];
		}
		z0jrk = p0;
	}

	internal DashStyle z0eek()
	{
		return z0jrk;
	}

	internal void z0eek(z0ZzZzgdh p0)
	{
		z0zek = p0;
	}

	internal void z0eek(DashCap p0)
	{
		z0lrk = p0;
	}

	internal void z0eek(z0ZzZzkdh p0)
	{
		z0xek = p0;
	}

	internal z0ZzZzldh z0rek()
	{
		return z0grk;
	}

	internal float[] z0tek()
	{
		if (z0jrk != DashStyle.Solid)
		{
			return z0krk;
		}
		return null;
	}

	internal void z0eek(z0ZzZzldh p0)
	{
		z0grk = p0;
	}

	internal double z0yek()
	{
		return z0frk;
	}

	internal z0ZzZzkdh z0uek()
	{
		return z0xek;
	}

	internal void z0rek(z0ZzZzldh p0)
	{
		z0vek = p0;
	}

	internal void z0eek(double p0)
	{
		z0hrk = p0;
	}

	internal z0ZzZzqxk(z0ZzZzfxk p0, double p1)
	{
		z0cek = p0;
		z0srk = ((p1 < 0.0) ? 0.0 : p1);
	}

	static z0ZzZzqxk()
	{
		z0drk = new Dictionary<DashStyle, float[]>();
		z0drk.Add(DashStyle.Dot, new float[2] { 1f, 1f });
		z0drk.Add(DashStyle.DashDotDot, new float[6] { 3f, 1f, 1f, 1f, 1f, 1f });
		z0drk.Add(DashStyle.DashDot, new float[4] { 3f, 1f, 1f, 1f });
		z0drk.Add(DashStyle.Dash, new float[2] { 3f, 1f });
	}

	internal z0ZzZzgdh z0iek()
	{
		return z0zek;
	}

	internal double z0oek()
	{
		return z0hrk;
	}

	internal DashCap z0pek()
	{
		return z0lrk;
	}

	internal z0ZzZzfxk z0mek()
	{
		return z0cek;
	}

	public void Dispose()
	{
		if (z0cek != null)
		{
			z0cek.Dispose();
		}
	}

	internal void z0eek(float[] p0)
	{
		z0jrk = DashStyle.Custom;
		z0krk = p0;
	}

	internal void z0rek(double p0)
	{
		z0frk = p0;
	}

	internal z0ZzZzldh z0nek()
	{
		return z0vek;
	}

	internal double z0bek()
	{
		return z0srk;
	}

	internal z0ZzZzqxk(Color p0, double p1)
		: this(new z0ZzZzwxk(p0), p1)
	{
	}
}
