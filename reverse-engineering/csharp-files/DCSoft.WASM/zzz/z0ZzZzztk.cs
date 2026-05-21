using System;
using DCSoft.Chart;
using DCSystem_Drawing;

namespace zzz;

public class z0ZzZzztk : ICloneable
{
	protected float z0krk;

	private int z0jrk = 30;

	private z0ZzZzptk z0hrk = new z0ZzZzptk();

	protected float z0grk;

	private ColorThemeType z0frk;

	private z0ZzZznmk z0drk = new z0ZzZznmk();

	protected DrawingStyle z0srk;

	private z0ZzZzstk z0ark = new z0ZzZzstk();

	protected bool z0qrk = true;

	private z0ZzZzbtk z0wrk;

	private double z0erk = 0.78;

	private z0ZzZzhyk z0rrk = new z0ZzZzhyk();

	private int z0trk;

	public void z0eek(z0ZzZznmk p0)
	{
		if (p0 == null)
		{
			z0drk = new z0ZzZznmk();
		}
		else
		{
			z0drk = p0;
		}
	}

	public z0ZzZzztk z0eek()
	{
		return (z0ZzZzztk)((ICloneable)this).Clone();
	}

	public int z0rek()
	{
		return z0jrk;
	}

	public float z0tek()
	{
		return z0grk;
	}

	public void z0eek(z0ZzZzptk p0)
	{
		if (p0 == null)
		{
			z0hrk = new z0ZzZzptk();
		}
		else
		{
			z0hrk = p0;
		}
	}

	public void z0eek(double p0)
	{
		z0erk = p0;
		if (z0erk > 1.0)
		{
			z0erk = 1.0;
		}
		if (z0erk < 0.0)
		{
			z0erk = 0.0;
		}
	}

	public double z0yek()
	{
		return z0erk;
	}

	public z0ZzZzhyk z0uek()
	{
		return z0rrk;
	}

	public void z0eek(int p0)
	{
		z0trk = p0;
	}

	public ColorThemeType z0iek()
	{
		return z0frk;
	}

	public void z0eek(z0ZzZzhyk p0)
	{
		if (p0 == null)
		{
			z0rrk = new z0ZzZzhyk();
		}
		else
		{
			z0rrk = p0;
		}
	}

	public bool z0oek()
	{
		return z0qrk;
	}

	public void z0eek(ColorThemeType p0)
	{
		z0frk = p0;
	}

	public void z0eek(float p0)
	{
		z0krk = p0 % 360f;
		if (z0krk < 0f)
		{
			z0krk += 360f;
		}
	}

	public z0ZzZzztk()
	{
		z0drk.Color = Color.Transparent;
	}

	public void z0eek(z0ZzZzbtk p0)
	{
		z0wrk = p0;
	}

	public z0ZzZzstk z0pek()
	{
		return z0ark;
	}

	public z0ZzZzbtk z0mek()
	{
		return z0wrk;
	}

	private object z0nek()
	{
		z0ZzZzztk z0ZzZzztk2 = (z0ZzZzztk)MemberwiseClone();
		if (z0wrk != null)
		{
			z0ZzZzztk2.z0wrk = z0wrk.z0pek();
		}
		z0ZzZzztk2.z0rek(z0tek());
		if (z0ark != null)
		{
			z0ZzZzztk2.z0ark = z0ark.z0lrk();
		}
		if (z0drk != null)
		{
			z0ZzZzztk2.z0drk = z0drk.z0rek();
		}
		if (z0hrk != null)
		{
			z0ZzZzztk2.z0hrk = z0hrk.z0mek();
		}
		if (z0rrk != null)
		{
			z0ZzZzztk2.z0rrk = z0rrk.z0yek();
		}
		return z0ZzZzztk2;
	}

	object ICloneable.Clone()
	{
		//ILSpy generated this explicit interface implementation from .override directive in z0nek
		return this.z0nek();
	}

	public void z0rek(float p0)
	{
		if (p0 > 1f || p0 < 0f)
		{
			z0grk = 0f;
		}
		else
		{
			z0grk = p0;
		}
	}

	public float z0bek()
	{
		return z0krk;
	}

	public void z0eek(DrawingStyle p0)
	{
		z0srk = p0;
	}

	public void z0eek(z0ZzZzstk p0)
	{
		if (p0 == null)
		{
			z0ark = new z0ZzZzstk();
		}
		else
		{
			z0ark = p0;
		}
	}

	public z0ZzZzptk z0vek()
	{
		return z0hrk;
	}

	internal z0ZzZzbtk z0cek()
	{
		if (z0iek() == ColorThemeType.Custom)
		{
			if (z0mek() != null)
			{
				return z0mek();
			}
			z0ZzZzbtk obj = new z0ZzZzbtk();
			obj.z0rek(ColorThemeType.Default);
			return obj;
		}
		z0ZzZzbtk obj2 = new z0ZzZzbtk();
		obj2.z0rek(z0iek());
		return obj2;
	}

	public DrawingStyle z0xek()
	{
		return z0srk;
	}

	public z0ZzZznmk z0zek()
	{
		return z0drk;
	}

	public int z0lrk()
	{
		return z0trk;
	}

	public void z0rek(int p0)
	{
		z0jrk = p0;
	}

	public void z0eek(bool p0)
	{
		z0qrk = p0;
	}
}
