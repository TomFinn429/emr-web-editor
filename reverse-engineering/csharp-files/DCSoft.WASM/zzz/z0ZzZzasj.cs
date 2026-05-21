using System.Collections;
using System.Collections.Generic;

namespace zzz;

internal class z0ZzZzasj<T> : z0ZzZzfsj, IList<T>, ICollection<T>, IEnumerable<T>, IEnumerable where T : z0ZzZzfsj
{
	private readonly List<T> z0nek;

	public int Count => z0nek.Count;

	public T this[int index]
	{
		get
		{
			return z0nek[index];
		}
		set
		{
			z0nek[index] = value;
		}
	}

	protected internal override object z0ngk(z0ZzZzdsj p0)
	{
		return new z0ZzZzwaj(z0nek, p0);
	}

	private bool z0eek(T p0)
	{
		return z0nek.Contains(p0);
	}

	bool ICollection<T>.Contains(T p0)
	{
		//ILSpy generated this explicit interface implementation from .override directive in z0eek
		return this.z0eek(p0);
	}

	private bool z0rek(T p0)
	{
		return z0nek.Remove(p0);
	}

	bool ICollection<T>.Remove(T p0)
	{
		//ILSpy generated this explicit interface implementation from .override directive in z0rek
		return this.z0rek(p0);
	}

	public void Add(T item)
	{
		z0nek.Add(item);
	}

	private void z0iek()
	{
		z0nek.Clear();
	}

	void ICollection<T>.Clear()
	{
		//ILSpy generated this explicit interface implementation from .override directive in z0iek
		this.z0iek();
	}

	private int z0tek(T p0)
	{
		return z0nek.IndexOf(p0);
	}

	int IList<T>.IndexOf(T p0)
	{
		//ILSpy generated this explicit interface implementation from .override directive in z0tek
		return this.z0tek(p0);
	}

	private bool z0oek()
	{
		return ((ICollection<T>)z0nek).IsReadOnly;
	}

	bool ICollection<T>.get_IsReadOnly()
	{
		//ILSpy generated this explicit interface implementation from .override directive in z0oek
		return this.z0oek();
	}

	internal z0ZzZzasj(z0ZzZzdsj p0)
	{
		z0nek = new List<T>();
	}

	private IEnumerator z0pek()
	{
		return ((IEnumerable)z0nek).GetEnumerator();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		//ILSpy generated this explicit interface implementation from .override directive in z0pek
		return this.z0pek();
	}

	private void z0yek(T[] p0, int p1)
	{
		z0nek.CopyTo(p0, p1);
	}

	void ICollection<T>.CopyTo(T[] p0, int p1)
	{
		//ILSpy generated this explicit interface implementation from .override directive in z0yek
		this.z0yek(p0, p1);
	}

	private void z0uek(int p0, T p1)
	{
		z0nek.Insert(p0, p1);
	}

	void IList<T>.Insert(int p0, T p1)
	{
		//ILSpy generated this explicit interface implementation from .override directive in z0uek
		this.z0uek(p0, p1);
	}

	private void z0iek(int p0)
	{
		z0nek.RemoveAt(p0);
	}

	void IList<T>.RemoveAt(int p0)
	{
		//ILSpy generated this explicit interface implementation from .override directive in z0iek
		this.z0iek(p0);
	}

	private IEnumerator<T> z0mek()
	{
		return z0nek.GetEnumerator();
	}

	IEnumerator<T> IEnumerable<T>.GetEnumerator()
	{
		//ILSpy generated this explicit interface implementation from .override directive in z0mek
		return this.z0mek();
	}
}
