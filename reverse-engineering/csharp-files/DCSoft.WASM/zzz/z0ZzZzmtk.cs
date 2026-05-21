using System;
using DCSoft.Drawing;
using DCSystem_Drawing;

namespace zzz;

public class z0ZzZzmtk : ICloneable
{
	private string z0nek;

	internal z0ZzZzbdh z0bek = z0ZzZzbdh.z0xek;

	internal z0ZzZzbdh z0vek = z0ZzZzbdh.z0xek;

	internal float z0cek;

	private int z0xek = 1;

	internal z0ZzZzbdh z0zek = z0ZzZzbdh.z0xek;

	private Color z0lrk = Color.Black;

	private ShapeTypes z0krk;

	public void z0eek(int p0)
	{
		z0xek = p0;
	}

	public void z0eek(Color p0)
	{
		z0lrk = p0;
	}

	public z0ZzZzmtk z0eek()
	{
		return (z0ZzZzmtk)((ICloneable)this).Clone();
	}

	private object z0rek()
	{
		z0ZzZzmtk obj = new z0ZzZzmtk();
		obj.z0lrk = z0lrk;
		obj.z0krk = z0krk;
		obj.z0bek = z0bek;
		obj.z0vek = z0vek;
		obj.z0zek = z0zek;
		obj.z0nek = z0nek;
		obj.z0cek = z0cek;
		obj.z0eek(z0pek());
		return obj;
	}

	object ICloneable.Clone()
	{
		//ILSpy generated this explicit interface implementation from .override directive in z0rek
		return this.z0rek();
	}

	public ShapeTypes z0tek()
	{
		return z0krk;
	}

	public void z0eek(string p0)
	{
		z0nek = p0;
	}

	public void z0eek(ShapeTypes p0)
	{
		z0krk = p0;
	}

	public string z0yek()
	{
		return z0nek;
	}

	internal z0ZzZzbdh z0uek()
	{
		return z0zek;
	}

	public Color z0iek()
	{
		return z0lrk;
	}

	internal z0ZzZzbdh z0oek()
	{
		return z0vek;
	}

	public int z0pek()
	{
		return z0xek;
	}

	internal z0ZzZzbdh z0mek()
	{
		return z0bek;
	}
}
