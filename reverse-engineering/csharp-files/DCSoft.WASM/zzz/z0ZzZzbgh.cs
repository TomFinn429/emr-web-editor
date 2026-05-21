using System;
using System.Reflection;

namespace zzz;

public class z0ZzZzbgh : z0ZzZzogh, IDisposable
{
	protected object z0uek;

	private bool z0iek;

	protected PropertyInfo z0oek;

	protected object z0pek;

	protected object z0mek;

	public void Dispose()
	{
		z0oek = null;
		z0uek = null;
		z0pek = null;
		z0pek = null;
	}

	public PropertyInfo z0eek()
	{
		return z0oek;
	}

	public void z0io(bool p0)
	{
		z0iek = p0;
	}

	public virtual void z0yo(z0ZzZzpgh p0)
	{
		if (z0mek != null && z0oek != null)
		{
			z0oek.SetValue(z0mek, z0uek, null);
		}
	}

	public void z0eek(object p0)
	{
		z0pek = p0;
	}

	public object z0rek()
	{
		return z0pek;
	}

	public void z0rek(object p0)
	{
		z0mek = p0;
	}

	public object z0tek()
	{
		return z0uek;
	}

	public void z0tek(object p0)
	{
		z0uek = p0;
	}

	public virtual void z0to(z0ZzZzpgh p0)
	{
		if (z0mek != null && z0oek != null)
		{
			z0oek.SetValue(z0mek, z0pek, null);
		}
	}

	public bool z0oo()
	{
		return z0iek;
	}

	public void z0eek(PropertyInfo p0)
	{
		z0oek = p0;
	}

	public object z0yek()
	{
		return z0mek;
	}
}
