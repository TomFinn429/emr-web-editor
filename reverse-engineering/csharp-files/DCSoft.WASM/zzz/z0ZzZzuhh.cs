using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace zzz;

[DebuggerDisplay("Count={ Count }")]
[DebuggerTypeProxy(typeof(z0ZzZzkik))]
public class z0ZzZzuhh : List<z0ZzZzyhh>, ICloneable
{
	private class z0hgj : IComparer<z0ZzZzyhh>
	{
		public int Compare(z0ZzZzyhh x, z0ZzZzyhh y)
		{
			return x.z0pek() - y.z0pek();
		}
	}

	[NonSerialized]
	[z0ZzZzuqh]
	public bool z0mek = true;

	public int z0eek(int p0)
	{
		return z0tek(p0)?.z0rek() ?? (-2147483648);
	}

	public z0ZzZzyhh z0eek()
	{
		if (base.Count > 0)
		{
			return base[base.Count - 1];
		}
		return null;
	}

	public void z0rek()
	{
		for (int i = 0; i < base.Count; i++)
		{
			base[i].z0rek(i);
		}
	}

	private object z0tek()
	{
		z0ZzZzuhh z0ZzZzuhh2 = new z0ZzZzuhh();
		z0ZzZzuhh2.z0mek = z0mek;
		using Enumerator enumerator = GetEnumerator();
		while (enumerator.MoveNext())
		{
			z0ZzZzyhh current = enumerator.Current;
			z0ZzZzuhh2.Add(current.z0lrk());
		}
		return z0ZzZzuhh2;
	}

	object ICloneable.Clone()
	{
		//ILSpy generated this explicit interface implementation from .override directive in z0tek
		return this.z0tek();
	}

	public int z0yek()
	{
		return base.Count - 1;
	}

	public string z0rek(int p0)
	{
		return z0tek(p0)?.z0zek();
	}

	public z0ZzZzuhh z0uek()
	{
		return (z0ZzZzuhh)((ICloneable)this).Clone();
	}

	public string z0iek()
	{
		if (base.Count > 0)
		{
			return base[base.Count - 1].z0zek();
		}
		return null;
	}

	public z0ZzZzyhh z0tek(int p0)
	{
		if (p0 < 0 || base.Count == 0)
		{
			return null;
		}
		if (p0 >= 0 && p0 < base.Count)
		{
			return base[p0];
		}
		return base[0];
	}

	public int z0oek()
	{
		if (base.Count > 0)
		{
			return base[base.Count - 1].z0rek();
		}
		return -1;
	}

	public void z0pek()
	{
		Sort(new z0hgj());
	}
}
