using System;
using DCSoft.Chart;
using DCSoft.Drawing;
using DCSystem_Drawing;

namespace zzz;

public class z0ZzZzytk
{
	private ShapeTypes z0jrk = ShapeTypes.Default;

	private string z0hrk;

	private int z0grk = -2147483648;

	internal double z0frk;

	private ChartStyleConsts z0drk;

	[NonSerialized]
	private z0ZzZznfh z0srk;

	[NonSerialized]
	private z0ZzZzbdh z0ark = z0ZzZzbdh.z0xek;

	private double z0qrk;

	private string z0wrk;

	private string z0erk;

	internal z0ZzZzrtk z0rrk;

	[NonSerialized]
	private z0ZzZzpdh z0trk = z0ZzZzpdh.z0yek;

	private z0ZzZzpdh z0yrk = z0ZzZzpdh.z0yek;

	private Color z0urk = Color.Transparent;

	private string z0irk;

	public void z0eek(string p0)
	{
		z0hrk = p0;
	}

	public double z0eek()
	{
		return z0qrk;
	}

	public void z0eek(double p0)
	{
		p0 = p0;
	}

	public ShapeTypes z0rek()
	{
		return z0jrk;
	}

	public string z0tek()
	{
		return z0wrk;
	}

	public ChartStyleConsts z0yek()
	{
		return z0drk;
	}

	public string z0uek()
	{
		return z0ZzZzlok.z0eek(z0pek(), Color.Transparent);
	}

	public string z0iek()
	{
		return z0irk;
	}

	public void z0rek(string p0)
	{
		z0irk = p0;
	}

	internal bool z0oek()
	{
		if (!z0ZzZzbok.z0eek(z0qrk))
		{
			return z0qrk != 0.0;
		}
		return false;
	}

	public void z0eek(ChartStyleConsts p0)
	{
		z0drk = p0;
	}

	public void z0eek(Color p0)
	{
		z0urk = p0;
	}

	internal void z0eek(z0ZzZznfh p0)
	{
		z0srk = p0;
	}

	public Color z0pek()
	{
		return z0urk;
	}

	public int z0mek()
	{
		if (z0rrk != null)
		{
			return z0rrk.z0rek().IndexOf(this);
		}
		return 0;
	}

	internal z0ZzZzpdh z0nek()
	{
		return z0yrk;
	}

	internal void z0eek(z0ZzZzbdh p0)
	{
		z0ark = p0;
	}

	public string z0bek()
	{
		return z0erk;
	}

	internal z0ZzZzbdh z0vek()
	{
		return z0ark;
	}

	public void z0tek(string p0)
	{
		z0wrk = p0;
	}

	public z0ZzZzytk z0cek()
	{
		return (z0ZzZzytk)MemberwiseClone();
	}

	internal void z0eek(z0ZzZzpdh p0)
	{
		z0yrk = p0;
	}

	internal void z0eek(float p0, float p1)
	{
		if (!z0ark.z0bek())
		{
			z0ark.z0tek(p0, p1);
			return;
		}
		z0yrk.z0eek(z0yrk.z0rek() + p0);
		z0yrk.z0rek(z0yrk.z0tek() + p1);
	}

	public void z0yek(string p0)
	{
		z0eek(z0ZzZzlok.z0eek(p0, Color.Transparent));
	}

	public void z0eek(ShapeTypes p0)
	{
		z0jrk = p0;
	}

	public void z0eek(int p0)
	{
		z0grk = p0;
	}

	public int z0xek()
	{
		return z0grk;
	}

	internal z0ZzZznfh z0zek()
	{
		return z0srk;
	}

	internal z0ZzZzpdh z0lrk_jiejie20260327142557()
	{
		return z0trk;
	}

	public string z0krk()
	{
		return z0hrk;
	}

	public void z0uek(string p0)
	{
		z0erk = p0;
	}

	internal void z0rek(z0ZzZzpdh p0)
	{
		z0trk = p0;
	}
}
