using System;
using DCSystem_Drawing;
using DCSystem_Drawing.Drawing2D;

namespace zzz;

public sealed class z0ZzZzudh : IDisposable
{
	private readonly bool z0bek;

	private DashCap z0vek;

	private float z0cek = 1f;

	private bool z0xek;

	private DashStyle z0zek;

	private Color z0lrk = Color.Black;

	private z0ZzZzmfh z0krk;

	private z0ZzZzmfh z0jrk;

	public void z0eek(z0ZzZzmfh p0)
	{
		z0jrk = p0;
	}

	public z0ZzZzudh(z0ZzZztfh p0, float p1)
	{
		if (p0 is z0ZzZzzdh)
		{
			z0lrk = ((z0ZzZzzdh)p0).z0eek;
		}
		z0cek = p1;
	}

	public DashCap z0eek()
	{
		z0yek();
		return z0vek;
	}

	public z0ZzZzmfh z0rek()
	{
		return z0krk;
	}

	public void z0eek(DashStyle p0)
	{
		z0uek();
		z0yek();
		z0zek = p0;
	}

	public DashStyle z0tek()
	{
		z0yek();
		return z0zek;
	}

	public void z0eek(float p0)
	{
		z0uek();
		z0yek();
		z0cek = p0;
	}

	private void z0yek()
	{
		if (z0xek)
		{
			throw new ObjectDisposedException(GetType().Name);
		}
	}

	public z0ZzZzudh(Color p0, float p1)
	{
		z0lrk = p0;
		z0cek = p1;
	}

	internal z0ZzZzudh(Color p0, bool p1)
	{
		z0lrk = p0;
		z0bek = p1;
	}

	private void z0uek()
	{
		if (z0bek)
		{
			throw new InvalidOperationException("对象是永恒的");
		}
	}

	public z0ZzZzudh z0iek()
	{
		return (z0ZzZzudh)MemberwiseClone();
	}

	public void z0rek(z0ZzZzmfh p0)
	{
		z0krk = p0;
	}

	public float z0oek()
	{
		z0yek();
		return z0cek;
	}

	public z0ZzZzudh(Color p0)
	{
		z0lrk = p0;
	}

	public z0ZzZzmfh z0pek()
	{
		return z0jrk;
	}

	public void z0eek(DashCap p0)
	{
		z0uek();
		z0yek();
		z0vek = p0;
	}

	public void Dispose()
	{
		z0uek();
		z0xek = true;
	}

	public bool z0eek(z0ZzZzudh p0)
	{
		if (this == p0)
		{
			return true;
		}
		if (z0lrk == p0.z0lrk && z0cek == p0.z0cek)
		{
			return z0zek == p0.z0zek;
		}
		return false;
	}

	public void z0eek(Color p0)
	{
		z0uek();
		z0yek();
		z0lrk = p0;
	}

	public z0ZzZzzdh z0mek()
	{
		return new z0ZzZzzdh(z0lrk);
	}

	public z0ZzZzudh(Color p0, float p1, DashStyle p2)
	{
		z0lrk = p0;
		z0cek = p1;
		z0zek = p2;
	}

	public Color z0nek()
	{
		z0yek();
		return z0lrk;
	}
}
