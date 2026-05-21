using System;
using System.Collections;
using System.Collections.Generic;

namespace zzz;

internal class z0ZzZzysj : IList<z0ZzZzgwj>, ICollection<z0ZzZzgwj>, IEnumerable<z0ZzZzgwj>, IEnumerable
{
	private class z0mxk : zzz.z0ZzZzegj<z0ZzZzgwj>
	{
		protected override z0ZzZzgwj z0aj(object p0)
		{
			return (z0ZzZzgwj)p0;
		}

		internal z0mxk()
		{
		}
	}

	private readonly z0ZzZzugj z0iek_jiejie20260327142557;

	private int z0oek = -1;

	private readonly z0mxk z0pek;

	public z0ZzZzgwj this[int index]
	{
		get
		{
			return z0pek[index];
		}
		set
		{
			throw new NotSupportedException();
		}
	}

	public int Count => z0pek.Count;

	private IEnumerator z0eek()
	{
		return z0pek.GetEnumerator();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		//ILSpy generated this explicit interface implementation from .override directive in z0eek
		return this.z0eek();
	}

	private void z0eek(z0ZzZzgwj p0)
	{
		throw new NotSupportedException();
	}

	void ICollection<z0ZzZzgwj>.Add(z0ZzZzgwj p0)
	{
		//ILSpy generated this explicit interface implementation from .override directive in z0eek
		this.z0eek(p0);
	}

	private void z0eek(int p0)
	{
		z0rek(p0 + 1);
	}

	void IList<z0ZzZzgwj>.RemoveAt(int p0)
	{
		//ILSpy generated this explicit interface implementation from .override directive in z0eek
		this.z0eek(p0);
	}

	internal z0ZzZzusj z0eek(z0ZzZzdsj p0, bool p1)
	{
		z0ZzZzugj p2 = z0iek_jiejie20260327142557;
		IEnumerable<z0ZzZzgwj> p3;
		if (!p1)
		{
			IEnumerable<z0ZzZzgwj> enumerable = new z0ZzZzgwj[0];
			p3 = enumerable;
		}
		else
		{
			IEnumerable<z0ZzZzgwj> enumerable = z0pek;
			p3 = enumerable;
		}
		z0ZzZzusj obj = new z0ZzZzusj(p2, null, null, 0, p3);
		((z0ZzZzogj)obj).z0eek(z0eek(p0));
		return obj;
	}

	private int z0eek(z0ZzZzdsj p0)
	{
		if (z0oek == -1)
		{
			int p1 = p0.z0uek() + 1;
			p0.z0uek(p1);
			z0oek = p1;
		}
		return z0oek;
	}

	private void z0rek()
	{
		while (z0pek.Count > 0)
		{
			z0rek(z0pek.Count);
		}
	}

	void ICollection<z0ZzZzgwj>.Clear()
	{
		//ILSpy generated this explicit interface implementation from .override directive in z0rek
		this.z0rek();
	}

	private bool z0rek(z0ZzZzgwj p0)
	{
		if (p0.z0eek() != null)
		{
			p0.z0eek().z0eek(p0);
		}
		return z0pek.Remove(p0);
	}

	private void z0eek(int p0, z0ZzZzgwj p1)
	{
		throw new NotSupportedException();
	}

	void IList<z0ZzZzgwj>.Insert(int p0, z0ZzZzgwj p1)
	{
		//ILSpy generated this explicit interface implementation from .override directive in z0eek
		this.z0eek(p0, p1);
	}

	public z0ZzZzysj(z0ZzZzugj p0)
	{
		z0iek_jiejie20260327142557 = p0;
		z0pek = new z0mxk();
	}

	private bool z0tek()
	{
		return false;
	}

	bool ICollection<z0ZzZzgwj>.get_IsReadOnly()
	{
		//ILSpy generated this explicit interface implementation from .override directive in z0tek
		return this.z0tek();
	}

	public z0ZzZzgwj z0rek(int p0, z0ZzZzgwj p1)
	{
		if (p1 != null)
		{
			z0pek.Insert(p0, p1);
		}
		return p1;
	}

	internal void z0rek(int p0)
	{
		int count = z0pek.Count;
		if (p0 < 1 || p0 > count)
		{
			throw new ArgumentOutOfRangeException("pageNumber", count.ToString());
		}
		z0rek(z0pek[p0 - 1]);
	}

	public bool Contains(z0ZzZzgwj item)
	{
		return z0pek.Contains(item);
	}

	private bool z0tek(z0ZzZzgwj p0)
	{
		return z0rek(p0);
	}

	bool ICollection<z0ZzZzgwj>.Remove(z0ZzZzgwj p0)
	{
		//ILSpy generated this explicit interface implementation from .override directive in z0tek
		return this.z0tek(p0);
	}

	private int z0yek(z0ZzZzgwj p0)
	{
		return z0pek.IndexOf(p0);
	}

	int IList<z0ZzZzgwj>.IndexOf(z0ZzZzgwj p0)
	{
		//ILSpy generated this explicit interface implementation from .override directive in z0yek
		return this.z0yek(p0);
	}

	public z0ZzZzgwj z0uek(z0ZzZzgwj p0)
	{
		if (p0 != null)
		{
			z0pek.Add(p0);
		}
		return p0;
	}

	private void z0eek(z0ZzZzgwj[] p0, int p1)
	{
		z0pek.CopyTo(p0, p1);
	}

	void ICollection<z0ZzZzgwj>.CopyTo(z0ZzZzgwj[] p0, int p1)
	{
		//ILSpy generated this explicit interface implementation from .override directive in z0eek
		this.z0eek(p0, p1);
	}

	private IEnumerator<z0ZzZzgwj> z0yek()
	{
		return z0pek.GetEnumerator();
	}

	IEnumerator<z0ZzZzgwj> IEnumerable<z0ZzZzgwj>.GetEnumerator()
	{
		//ILSpy generated this explicit interface implementation from .override directive in z0yek
		return this.z0yek();
	}
}
