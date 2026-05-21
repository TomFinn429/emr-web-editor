using System;
using System.Collections.Generic;

namespace zzz;

public class z0ZzZzmgh : z0ZzZzogh, IDisposable
{
	private bool z0rek;

	protected List<z0ZzZzogh> z0tek = new List<z0ZzZzogh>();

	public virtual void z0yo(z0ZzZzpgh p0)
	{
		foreach (z0ZzZzogh item in z0tek)
		{
			item.z0io(p0: true);
			item.z0yo(p0);
		}
	}

	public virtual void z0eek(z0ZzZzogh p0)
	{
		p0.z0io(p0: true);
		z0tek.Add(p0);
	}

	public void z0io(bool p0)
	{
		z0rek = p0;
	}

	public virtual void z0to(z0ZzZzpgh p0)
	{
		for (int num = z0tek.Count - 1; num >= 0; num--)
		{
			z0ZzZzogh obj = z0tek[num];
			obj.z0io(p0: true);
			obj.z0to(p0);
		}
	}

	public virtual void Dispose()
	{
		if (z0tek == null)
		{
			return;
		}
		foreach (z0ZzZzogh item in z0tek)
		{
			item.Dispose();
		}
		z0tek.Clear();
		z0tek = null;
	}

	public bool z0oo()
	{
		return z0rek;
	}
}
