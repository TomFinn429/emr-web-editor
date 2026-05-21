using System;
using System.ComponentModel;
using DCSoft.Chart;
using DCSystem_Drawing;

namespace zzz;

public class z0ZzZzhyk : ICloneable
{
	private Color z0nek = Color.Black;

	private bool z0bek = true;

	private Color z0vek = Color.Black;

	private PieLabelType z0cek = PieLabelType.OutLabel;

	private int z0xek = 20;

	private int z0zek = 2;

	private Color z0lrk = z0ZzZzhsh.z0yek;

	private z0ZzZzimk z0krk = new z0ZzZzimk();

	[DefaultValue(true)]
	public bool Visible
	{
		get
		{
			return z0bek;
		}
		set
		{
			z0bek = value;
		}
	}

	public void z0eek(int p0)
	{
		z0xek = p0;
	}

	public z0ZzZzimk z0eek()
	{
		return z0krk;
	}

	public void z0eek(z0ZzZzimk p0)
	{
		if (p0 == null)
		{
			z0krk = new z0ZzZzimk();
		}
		else
		{
			z0krk = p0;
		}
	}

	public Color z0rek()
	{
		return z0nek;
	}

	public int z0tek()
	{
		return z0zek;
	}

	public z0ZzZzhyk z0yek()
	{
		return (z0ZzZzhyk)((ICloneable)this).Clone();
	}

	public void z0eek(Color p0)
	{
		z0vek = p0;
	}

	public void z0rek(Color p0)
	{
		z0lrk = p0;
	}

	public int z0uek()
	{
		return z0xek;
	}

	private object z0iek()
	{
		z0ZzZzhyk obj = new z0ZzZzhyk();
		obj.z0bek = z0bek;
		obj.z0krk = z0krk.Clone();
		obj.z0lrk = z0lrk;
		obj.z0vek = z0vek;
		obj.z0nek = z0nek;
		obj.z0cek = z0cek;
		obj.z0eek(z0uek());
		obj.z0rek(z0tek());
		return obj;
	}

	object ICloneable.Clone()
	{
		//ILSpy generated this explicit interface implementation from .override directive in z0iek
		return this.z0iek();
	}

	public Color z0oek()
	{
		return z0lrk;
	}

	public PieLabelType z0pek()
	{
		return z0cek;
	}

	public void z0eek(PieLabelType p0)
	{
		z0cek = p0;
	}

	public void z0rek(int p0)
	{
		z0zek = p0;
	}

	public Color z0mek()
	{
		return z0vek;
	}

	public void z0tek(Color p0)
	{
		if (p0.ToArgb() != Color.Empty.ToArgb())
		{
			z0nek = p0;
		}
	}
}
