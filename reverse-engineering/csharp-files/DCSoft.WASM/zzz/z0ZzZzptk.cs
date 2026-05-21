using System;
using DCSoft.Drawing;
using DCSystem_Drawing;

namespace zzz;

public class z0ZzZzptk : ICloneable
{
	private int z0cek = 40;

	private float z0xek = 40f;

	private bool z0zek = true;

	private float z0lrk;

	private z0ZzZzimk z0krk = new z0ZzZzimk();

	private DirectionStyles z0jrk = DirectionStyles.Right;

	private z0ZzZzemk z0hrk = new z0ZzZzemk();

	private bool z0grk;

	private Color z0frk = Color.Black;

	public z0ZzZzptk()
	{
		z0hrk.z0eek(XBrushStyleConst.Disabled);
	}

	public bool z0eek()
	{
		return z0grk;
	}

	public void z0eek(bool p0)
	{
		z0zek = p0;
	}

	public string z0rek()
	{
		return z0ZzZzlok.z0eek(z0bek(), Color.Black);
	}

	internal void z0eek(DirectionStyles p0)
	{
		z0jrk = p0;
	}

	public void z0eek(int p0)
	{
		z0cek = p0;
	}

	public float z0tek()
	{
		return z0lrk;
	}

	public z0ZzZzimk z0yek_jiejie20260327142557()
	{
		return z0krk;
	}

	public void z0eek(Color p0)
	{
		z0frk = p0;
	}

	public int z0uek()
	{
		return z0cek;
	}

	public z0ZzZzemk z0iek()
	{
		return z0hrk;
	}

	internal DirectionStyles z0oek()
	{
		return z0jrk;
	}

	public void z0eek(z0ZzZzimk p0)
	{
		z0krk = p0;
	}

	public void z0eek(string p0)
	{
		z0eek(z0ZzZzlok.z0eek(p0, Color.Black));
	}

	public float z0pek()
	{
		return z0xek;
	}

	public z0ZzZzptk z0mek()
	{
		return (z0ZzZzptk)((ICloneable)this).Clone();
	}

	public bool z0nek()
	{
		return z0zek;
	}

	public void z0eek(float p0)
	{
		z0lrk = p0;
	}

	public void z0eek(z0ZzZzemk p0)
	{
		z0hrk = p0;
	}

	public void z0rek(bool p0)
	{
		z0grk = p0;
	}

	public Color z0bek()
	{
		return z0frk;
	}

	private object z0vek()
	{
		z0ZzZzptk z0ZzZzptk2 = (z0ZzZzptk)MemberwiseClone();
		if (z0krk != null)
		{
			z0ZzZzptk2.z0krk = z0krk.Clone();
		}
		if (z0hrk != null)
		{
			z0ZzZzptk2.z0hrk = z0hrk.z0bek();
		}
		return z0ZzZzptk2;
	}

	object ICloneable.Clone()
	{
		//ILSpy generated this explicit interface implementation from .override directive in z0vek
		return this.z0vek();
	}

	public void z0rek(float p0)
	{
		z0xek = p0;
	}
}
