using System;

namespace zzz;

public abstract class z0ZzZzdqh : IDisposable
{
	public abstract void z0cg();

	public void Dispose()
	{
		z0eek(p0: true);
	}

	public abstract void z0ng(string p0);

	public abstract void z0bg();

	public abstract void z0lf();

	public abstract void z0ig(string p0);

	public abstract void z0pg(string p0, string p1);

	public abstract void z0vg();

	protected virtual void z0eek(bool p0)
	{
		if (p0 && z0jf() != (z0ZzZznsh)5)
		{
			z0kf();
		}
	}

	public void z0eek(string p0)
	{
		z0hf(null, p0, null);
	}

	public abstract z0ZzZznsh z0jf();

	public void z0eek(string p0, string p1, string p2)
	{
		z0tek(p0, p1);
		if (!string.IsNullOrEmpty(p2))
		{
			z0yg(p2);
		}
		z0bg();
	}

	public void z0eek(string p0, string p1)
	{
		if (p1 != null && p1.Length > 0)
		{
			z0eek(p0, null, p1);
		}
	}

	public abstract void z0zg(string p0);

	public abstract void z0yg(string p0);

	public abstract void z0xg(char p0);

	public void z0rek(string p0, string p1)
	{
		z0eek(p0, null, p1);
	}

	public abstract void z0hf(string p0, string p1, string p2);

	public virtual void z0kf()
	{
	}

	public abstract void z0mg();

	public abstract void z0og(string p0);

	public void z0tek(string p0, string p1)
	{
		z0hf(null, p0, p1);
	}

	public abstract void z0ug();
}
