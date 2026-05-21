using System;
using System.Collections.Generic;
using DCSoft.Drawing;
using DCSystem_Drawing;

namespace zzz;

public class z0ZzZzemk : ICloneable, IDisposable
{
	private XBrushStyleConst z0lrk = XBrushStyleConst.Solid;

	private float z0krk;

	private z0ZzZzpmk z0jrk;

	private Color z0hrk = Color.Black;

	private bool z0grk = true;

	private float z0frk;

	private static Dictionary<XBrushStyleConst, z0ZzZzedh> z0drk;

	private Color z0srk_jiejie20260327142557 = Color.Transparent;

	public Color z0eek()
	{
		return z0srk_jiejie20260327142557;
	}

	public Color z0rek()
	{
		return z0hrk;
	}

	public float z0tek()
	{
		return z0frk;
	}

	public bool z0yek()
	{
		return z0grk;
	}

	public z0ZzZztfh z0uek()
	{
		return z0eek(0f, 0f, 100f, 100f, GraphicsUnit.Pixel);
	}

	public void z0eek(bool p0)
	{
		z0grk = p0;
	}

	public z0ZzZztfh z0eek(float p0, float p1, float p2, float p3, GraphicsUnit p4)
	{
		if (z0lrk == XBrushStyleConst.Disabled)
		{
			return null;
		}
		if (z0lrk == XBrushStyleConst.Black)
		{
			return new z0ZzZzzdh(Color.Black);
		}
		if (z0lrk == XBrushStyleConst.White)
		{
			return new z0ZzZzzdh(Color.White);
		}
		if (z0jrk != null && z0jrk.Value != null)
		{
			z0ZzZzdsh z0ZzZzdsh2 = new z0ZzZzdsh(z0jrk.Value);
			if (z0grk)
			{
				z0ZzZzdsh2.z0eek((z0ZzZzddh)0);
			}
			else
			{
				z0ZzZzdsh2.z0eek((z0ZzZzddh)4);
			}
			float num = (float)z0ZzZzrpk.z0eek(p4, GraphicsUnit.Pixel);
			z0ZzZzdsh2.z0eek(z0krk, z0frk);
			z0ZzZzdsh2.z0rek(num, num);
			return z0ZzZzdsh2;
		}
		if (z0lrk == XBrushStyleConst.Solid)
		{
			return new z0ZzZzzdh(z0srk_jiejie20260327142557);
		}
		if (z0lrk < XBrushStyleConst.GradientHorizontal)
		{
			_ = z0lrk;
			return new z0ZzZzvfh((z0ZzZzcfh)z0lrk, z0srk_jiejie20260327142557, z0hrk);
		}
		if (z0lrk < (XBrushStyleConst)2000)
		{
			return new z0ZzZzxfh(new z0ZzZzbdh(p0, p1, p2, p3), z0srk_jiejie20260327142557, z0hrk, (z0ZzZzzfh)(z0lrk - 1000));
		}
		if (z0drk == null)
		{
			z0drk = new Dictionary<XBrushStyleConst, z0ZzZzedh>();
			z0ZzZzrfh z0ZzZzrfh2 = z0ZzZzapk.z0vek;
			z0ZzZzrfh2.z0eek(Color.Red);
			z0drk[XBrushStyleConst.BackImage1] = z0ZzZzrfh2;
			z0ZzZzrfh2 = z0ZzZzapk.z0iek;
			z0ZzZzrfh2.z0eek(Color.Red);
			z0drk[XBrushStyleConst.BackImage2] = z0ZzZzrfh2;
			z0ZzZzrfh2 = z0ZzZzapk.z0rek;
			z0ZzZzrfh2.z0eek(Color.Red);
			z0drk[XBrushStyleConst.BackImage3] = z0ZzZzrfh2;
			z0ZzZzrfh2 = z0ZzZzapk.z0krk;
			z0ZzZzrfh2.z0eek(Color.Red);
			z0drk[XBrushStyleConst.BackImage4] = z0ZzZzrfh2;
			z0ZzZzrfh2 = z0ZzZzapk.z0lrk;
			z0ZzZzrfh2.z0eek(Color.Red);
			z0drk[XBrushStyleConst.BackImage5] = z0ZzZzrfh2;
			z0ZzZzrfh2 = z0ZzZzapk.z0oek;
			z0ZzZzrfh2.z0eek(Color.Red);
			z0drk[XBrushStyleConst.BackImage6] = z0ZzZzrfh2;
			z0ZzZzrfh2 = z0ZzZzapk.z0yek;
			z0ZzZzrfh2.z0eek(Color.Red);
			z0drk[XBrushStyleConst.BackImage7] = z0ZzZzrfh2;
			z0ZzZzrfh2 = z0ZzZzapk.z0mek;
			z0ZzZzrfh2.z0eek(Color.Red);
			z0drk[XBrushStyleConst.BackImage8] = z0ZzZzrfh2;
			z0ZzZzrfh2 = z0ZzZzapk.z0zek;
			z0ZzZzrfh2.z0eek(Color.Red);
			z0drk[XBrushStyleConst.BackImage9] = z0ZzZzrfh2;
			z0ZzZzrfh2 = z0ZzZzapk.z0tek;
			z0ZzZzrfh2.z0eek(Color.Red);
			z0drk[XBrushStyleConst.BackImage10] = z0ZzZzrfh2;
			z0ZzZzrfh2 = z0ZzZzapk.z0bek;
			z0ZzZzrfh2.z0eek(Color.Red);
			z0drk[XBrushStyleConst.BackImage11] = z0ZzZzrfh2;
			z0ZzZzrfh2 = z0ZzZzapk.z0pek;
			z0ZzZzrfh2.z0eek(Color.Red);
			z0drk[XBrushStyleConst.BackImage12] = z0ZzZzrfh2;
			z0ZzZzrfh2 = z0ZzZzapk.z0uek;
			z0ZzZzrfh2.z0eek(Color.Red);
			z0drk[XBrushStyleConst.BackImage13] = z0ZzZzrfh2;
		}
		if (z0drk.ContainsKey(z0lrk))
		{
			z0ZzZzdsh z0ZzZzdsh3 = new z0ZzZzdsh(z0drk[z0lrk]);
			if (z0yek())
			{
				z0ZzZzdsh3.z0eek((z0ZzZzddh)0);
			}
			else
			{
				z0ZzZzdsh3.z0eek((z0ZzZzddh)4);
			}
			float num2 = (float)z0ZzZzrpk.z0eek(p4, GraphicsUnit.Pixel);
			z0ZzZzdsh3.z0eek(z0krk, z0frk);
			z0ZzZzdsh3.z0rek(num2, num2);
			return z0ZzZzdsh3;
		}
		return new z0ZzZzzdh(z0eek());
	}

	public void z0eek(string p0)
	{
		z0hrk = z0ZzZzlok.z0eek(p0, Color.Black);
	}

	public float z0iek()
	{
		return z0krk;
	}

	public z0ZzZzpmk z0oek()
	{
		return z0jrk;
	}

	public void z0eek(z0ZzZzpmk p0)
	{
		z0jrk = p0;
	}

	public void z0rek(string p0)
	{
		z0srk_jiejie20260327142557 = z0ZzZzlok.z0eek(p0, Color.Transparent);
	}

	public bool z0pek()
	{
		if (z0lrk == XBrushStyleConst.Disabled)
		{
			return false;
		}
		if (z0jrk != null && z0jrk.Value != null)
		{
			return false;
		}
		return z0lrk == XBrushStyleConst.Solid;
	}

	public void z0eek(Color p0)
	{
		z0srk_jiejie20260327142557 = p0;
	}

	public string z0mek()
	{
		return z0ZzZzlok.z0eek(z0rek(), Color.Black);
	}

	public void z0eek(float p0)
	{
		z0frk = p0;
	}

	public bool z0nek()
	{
		return z0lrk != XBrushStyleConst.Disabled;
	}

	public z0ZzZzemk z0bek()
	{
		return (z0ZzZzemk)((ICloneable)this).Clone();
	}

	public z0ZzZzemk()
	{
	}

	public z0ZzZztfh z0eek(z0ZzZzbdh p0)
	{
		return z0eek(p0.z0oek(), p0.z0pek(), p0.z0uek(), p0.z0iek(), GraphicsUnit.Pixel);
	}

	public void z0rek(Color p0)
	{
		z0hrk = p0;
	}

	public void Dispose()
	{
		if (z0jrk != null)
		{
			z0jrk.Dispose();
			z0jrk = null;
		}
	}

	public string z0vek()
	{
		return z0ZzZzlok.z0eek(z0eek(), Color.Transparent);
	}

	public z0ZzZzemk(Color p0)
	{
		z0srk_jiejie20260327142557 = p0;
	}

	public void z0rek(float p0)
	{
		z0krk = p0;
	}

	public z0ZzZztfh z0eek(z0ZzZzbdh p0, GraphicsUnit p1)
	{
		return z0eek(p0.z0oek(), p0.z0pek(), p0.z0uek(), p0.z0iek(), p1);
	}

	public void z0eek(XBrushStyleConst p0)
	{
		z0lrk = p0;
	}

	public XBrushStyleConst z0cek()
	{
		return z0lrk;
	}

	private object z0xek()
	{
		z0ZzZzemk z0ZzZzemk2 = new z0ZzZzemk();
		z0ZzZzemk2.z0grk = z0grk;
		z0ZzZzemk2.z0srk_jiejie20260327142557 = z0srk_jiejie20260327142557;
		z0ZzZzemk2.z0hrk = z0hrk;
		z0ZzZzemk2.z0lrk = z0lrk;
		z0ZzZzemk2.z0krk = z0krk;
		z0ZzZzemk2.z0frk = z0frk;
		if (z0jrk != null)
		{
			z0ZzZzemk2.z0jrk = z0jrk.Clone();
		}
		return z0ZzZzemk2;
	}

	object ICloneable.Clone()
	{
		//ILSpy generated this explicit interface implementation from .override directive in z0xek
		return this.z0xek();
	}
}
