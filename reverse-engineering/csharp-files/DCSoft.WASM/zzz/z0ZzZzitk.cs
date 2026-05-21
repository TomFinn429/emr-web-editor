using System;
using DCSystem_Drawing;

namespace zzz;

public class z0ZzZzitk : ICloneable
{
	private bool z0bek;

	private z0ZzZzimk z0vek = new z0ZzZzimk();

	private Color z0cek = Color.Black;

	private Color z0xek = Color.Black;

	private Color z0zek = z0ZzZzhsh.z0yek;

	public Color z0eek()
	{
		return z0zek;
	}

	public Color z0rek()
	{
		return z0xek;
	}

	public void z0eek(bool p0)
	{
		z0bek = p0;
	}

	public string z0tek()
	{
		return z0ZzZzlok.z0eek(z0rek(), Color.Black);
	}

	public void z0eek(string p0)
	{
		z0rek(z0ZzZzlok.z0eek(p0, z0ZzZzhsh.z0yek));
	}

	public bool z0yek()
	{
		return z0bek;
	}

	public string z0uek()
	{
		return z0ZzZzlok.z0eek(z0eek(), z0ZzZzhsh.z0yek);
	}

	public z0ZzZzimk z0iek()
	{
		return z0vek;
	}

	public Color z0oek()
	{
		return z0cek;
	}

	public void z0eek(z0ZzZzimk p0)
	{
		if (p0 == null)
		{
			z0vek = new z0ZzZzimk();
		}
		else
		{
			z0vek = p0;
		}
	}

	public string z0pek()
	{
		return z0ZzZzlok.z0eek(z0oek(), Color.Black);
	}

	public void z0rek(string p0)
	{
		z0eek(z0ZzZzlok.z0eek(p0, Color.Black));
	}

	public void z0eek(Color p0)
	{
		z0xek = p0;
	}

	public z0ZzZzitk z0mek()
	{
		return (z0ZzZzitk)((ICloneable)this).Clone();
	}

	public void z0tek(string p0)
	{
		z0rek(z0ZzZzlok.z0eek(p0, Color.Black));
	}

	private object z0nek()
	{
		z0ZzZzitk z0ZzZzitk2 = (z0ZzZzitk)MemberwiseClone();
		if (z0vek != null)
		{
			z0ZzZzitk2.z0vek = z0vek.Clone();
		}
		return z0ZzZzitk2;
	}

	object ICloneable.Clone()
	{
		//ILSpy generated this explicit interface implementation from .override directive in z0nek
		return this.z0nek();
	}

	public void z0rek(Color p0)
	{
		z0zek = p0;
	}

	public void z0tek(Color p0)
	{
		z0cek = p0;
	}
}
