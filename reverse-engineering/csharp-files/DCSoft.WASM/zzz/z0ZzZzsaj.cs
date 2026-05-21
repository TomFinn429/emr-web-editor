using System.Collections;
using System.Collections.Generic;

namespace zzz;

internal abstract class z0ZzZzsaj<T> : z0ZzZzlgj, IEnumerable
{
	private readonly IEnumerable<T> z0eek;

	protected z0ZzZzsaj(IEnumerable<T> p0)
	{
		z0eek = p0;
	}

	protected abstract void z0mfk(z0ZzZzpgj p0, T p1, int p2);

	public void z0nfk(z0ZzZzpgj p0, int p1)
	{
		p0.z0yek();
		using (IEnumerator<T> enumerator = z0eek.GetEnumerator())
		{
			if (enumerator.MoveNext())
			{
				z0mfk(p0, enumerator.Current, p1);
			}
			while (enumerator.MoveNext())
			{
				p0.z0pek();
				z0mfk(p0, enumerator.Current, p1);
			}
		}
		p0.z0tek();
	}

	public IEnumerator GetEnumerator()
	{
		return z0eek.GetEnumerator();
	}

	protected z0ZzZzsaj(IEnumerable p0)
	{
		List<T> list = new List<T>();
		foreach (T item in p0)
		{
			list.Add(item);
		}
		z0eek = list;
	}
}
