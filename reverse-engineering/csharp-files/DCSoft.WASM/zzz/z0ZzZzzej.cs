using System;
using DCSystem_Drawing;
using DCSystem_Drawing.Drawing2D;

namespace zzz;

[z0ZzZziqh]
public class z0ZzZzzej : z0ZzZzcuk
{
	private Color z0lrk_jiejie20260327142557 = Color.Black;

	private float z0krk;

	private bool z0jrk = true;

	private bool z0hrk;

	private int z0grk;

	private float z0frk = 1f;

	private bool z0drk = true;

	[NonSerialized]
	private float z0srk;

	private DashStyle z0ark;

	public string z0eek()
	{
		return z0ZzZzlok.z0eek(z0iek(), Color.Black);
	}

	public float z0eek(float p0)
	{
		if (z0hrk && z0jrk && z0srk > 0f)
		{
			return (float)Math.Ceiling(p0 / z0srk) * z0srk;
		}
		return p0;
	}

	public bool z0rek()
	{
		if (!z0hrk && z0grk == 0)
		{
			return z0krk == 0f;
		}
		return false;
	}

	public void z0eek(DashStyle p0)
	{
		z0ark = p0;
	}

	public void z0eek(int p0)
	{
		z0grk = p0;
	}

	public z0ZzZzudh z0tek()
	{
		z0ZzZzudh obj = new z0ZzZzudh(z0lrk_jiejie20260327142557, z0frk);
		obj.z0eek(z0vek());
		return obj;
	}

	public void DCReadString(string text)
	{
		z0ZzZzmik.z0eek(this, text);
	}

	public void z0rek(float p0)
	{
		z0frk = p0;
	}

	public bool z0yek()
	{
		return z0drk;
	}

	public void z0tek(float p0)
	{
		z0krk = p0;
	}

	public bool z0uek()
	{
		return z0hrk;
	}

	public Color z0iek()
	{
		return z0lrk_jiejie20260327142557;
	}

	public void z0eek(float p0, GraphicsUnit p1, float p2)
	{
		if (z0uek())
		{
			if (z0mek() > 0 && p0 > 0f)
			{
				z0srk = p2 * (p0 - 2f) / (float)z0mek();
			}
			else
			{
				z0srk = p2 * z0ZzZzrpk.z0tek(z0xek(), p1);
			}
		}
	}

	public float z0oek()
	{
		return z0frk;
	}

	public z0ZzZzzej z0pek()
	{
		return (z0ZzZzzej)MemberwiseClone();
	}

	public int z0mek()
	{
		return z0grk;
	}

	public void z0eek(bool p0)
	{
		z0hrk = p0;
	}

	public void z0eek(string p0)
	{
		z0eek(z0ZzZzlok.z0eek(p0, Color.Black));
	}

	public void z0rek(bool p0)
	{
		z0drk = p0;
	}

	public bool z0nek()
	{
		if (z0hrk && z0jrk)
		{
			return z0srk > 0f;
		}
		return false;
	}

	public void z0tek(bool p0)
	{
		z0jrk = p0;
	}

	public float z0yek(float p0)
	{
		if (z0hrk && z0jrk && z0srk > 0f)
		{
			float num = p0 / z0srk;
			num = ((!((double)(float)((double)num - Math.Floor(num)) > 0.05)) ? ((float)Math.Floor(num)) : ((float)Math.Ceiling(num)));
			return num * z0srk;
		}
		return p0;
	}

	public string DCWriteString()
	{
		return z0ZzZzmik.z0rek(this, p1: true);
	}

	public void z0eek(Color p0)
	{
		z0lrk_jiejie20260327142557 = p0;
	}

	public bool z0bek()
	{
		return z0iek().A == 0;
	}

	public DashStyle z0vek()
	{
		return z0ark;
	}

	public bool z0cek()
	{
		return z0jrk;
	}

	public float z0xek()
	{
		return z0krk;
	}

	public float z0zek()
	{
		return z0srk;
	}
}
