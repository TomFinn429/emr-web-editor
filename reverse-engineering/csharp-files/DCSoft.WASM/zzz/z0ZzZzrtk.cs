using System;
using System.Runtime.CompilerServices;
using DCSoft.Chart;
using DCSoft.Drawing;
using DCSystem_Drawing;
using DCSystem_Drawing.Drawing2D;

namespace zzz;

public class z0ZzZzrtk : z0ZzZzxtk
{
	private z0ZzZzutk z0krk = new z0ZzZzutk();

	private string z0jrk;

	private ChartStyleConsts z0hrk;

	private ShapeTypes z0grk = ShapeTypes.Circle;

	private DashStyle z0frk;

	private int z0drk = 2;

	private string z0srk;

	internal z0ZzZzwtk z0ark;

	private static int z0qrk;

	private int z0wrk = 10;

	[NonSerialized]
	private object z0erk;

	[CompilerGenerated]
	private object z0rrk;

	private Color z0trk = Color.Transparent;

	internal ChartStyleConsts z0yrk = ChartStyleConsts.Bar;

	[CompilerGenerated]
	public object z0eek_jiejie20260327142557()
	{
		return z0rrk;
	}

	public z0ZzZzutk z0rek()
	{
		return z0krk;
	}

	internal z0ZzZzudh z0tek()
	{
		z0ZzZzudh obj = new z0ZzZzudh(z0mek(), z0drk);
		obj.z0eek(z0frk);
		return obj;
	}

	public string z0yek()
	{
		return z0ZzZzlok.z0eek(z0pek(), Color.Transparent);
	}

	public int z0uek()
	{
		return z0drk;
	}

	public void z0eek_jiejie20260327142557(string p0)
	{
		z0jrk = p0;
	}

	public void z0eek_jiejie20260327142557(ChartStyleConsts p0)
	{
		z0hrk = p0;
	}

	public DashStyle z0iek()
	{
		return z0frk;
	}

	public string z0oek()
	{
		return z0jrk;
	}

	[CompilerGenerated]
	public void z0eek_jiejie20260327142557(object p0)
	{
		z0rrk = p0;
	}

	public Color z0mwk()
	{
		return z0mek();
	}

	public Color z0pek()
	{
		return z0trk;
	}

	public string z0pwk()
	{
		return z0srk;
	}

	public void z0rek(string p0)
	{
		z0srk = p0;
	}

	internal Color z0mek()
	{
		z0ZzZzstk z0ZzZzstk2 = z0xek();
		if (z0ZzZzstk2 == null)
		{
			if (z0trk.A != 0)
			{
				return z0trk;
			}
			if (z0ark != null)
			{
				return z0ark.z0eek().z0yrk().z0tek(z0ark.z0yek().IndexOf(this));
			}
			return z0ark.z0eek().z0yrk().z0tek(z0qrk);
		}
		return z0ZzZzstk2.z0frk();
	}

	public void z0tek(string p0)
	{
		z0eek_jiejie20260327142557(z0ZzZzlok.z0eek(p0, Color.Transparent));
	}

	public int z0nek()
	{
		return z0wrk;
	}

	public void z0eek_jiejie20260327142557(Color p0)
	{
		z0trk = p0;
	}

	public void z0eek_jiejie20260327142557(z0ZzZzutk p0)
	{
		z0krk = p0;
	}

	public z0ZzZzrtk z0bek()
	{
		z0ZzZzrtk z0ZzZzrtk2 = (z0ZzZzrtk)MemberwiseClone();
		if (z0krk != null && z0krk.Count > 0)
		{
			z0ZzZzrtk2.z0krk = new z0ZzZzutk();
			foreach (z0ZzZzytk item in z0krk)
			{
				z0ZzZzrtk2.z0krk.Add(item.z0cek());
			}
		}
		else
		{
			z0ZzZzrtk2.z0krk = null;
		}
		return z0ZzZzrtk2;
	}

	public ShapeTypes z0vek()
	{
		return z0grk;
	}

	internal z0ZzZzzdh z0cek()
	{
		return new z0ZzZzzdh(z0mek());
	}

	public void z0eek_jiejie20260327142557(DashStyle p0)
	{
		z0frk = p0;
	}

	public z0ZzZzrtk()
	{
		z0qrk++;
	}

	internal z0ZzZzstk z0xek()
	{
		foreach (z0ZzZzstk item in z0ark.z0eek().z0mek())
		{
			if (z0pwk() == item.z0mek())
			{
				return item;
			}
		}
		return null;
	}

	public void z0eek_jiejie20260327142557(ShapeTypes p0)
	{
		z0grk = p0;
	}

	public ChartStyleConsts z0zek()
	{
		return z0hrk;
	}

	public void z0eek_jiejie20260327142557(int p0)
	{
		z0wrk = p0;
	}

	public string z0lrk()
	{
		return z0srk;
	}

	public void z0rek(int p0)
	{
		z0drk = p0;
	}
}
