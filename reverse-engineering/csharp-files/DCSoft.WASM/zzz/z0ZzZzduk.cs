using System;
using System.Collections;

namespace zzz;

public class z0ZzZzduk : IDisposable
{
	public EventHandler z0uek;

	private int z0iek;

	private readonly Hashtable z0oek = new Hashtable();

	private object z0pek;

	public EventHandler z0mek;

	public void Dispose()
	{
		z0tek();
	}

	public void z0eek(object p0)
	{
		z0pek = p0;
	}

	public virtual void z0eek()
	{
		z0iek = 1;
		if (z0mek != null)
		{
			z0mek(this, EventArgs.Empty);
		}
	}

	public Hashtable z0rek()
	{
		return z0oek;
	}

	public virtual void z0tek()
	{
		if (z0iek == 1)
		{
			z0iek = 0;
			if (z0uek != null)
			{
				z0uek(this, EventArgs.Empty);
			}
		}
	}

	public object z0yek()
	{
		return z0pek;
	}
}
