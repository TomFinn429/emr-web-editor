using System;
using System.Collections.Generic;

namespace zzz;

internal sealed class z0ZzZzmyk<T>
{
	private ICollection<T> z0rek;

	public z0ZzZzmyk(ICollection<T> p0)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("collection");
		}
		z0rek = p0;
	}

	public T[] z0eek()
	{
		T[] array = new T[z0rek.Count];
		z0rek.CopyTo(array, 0);
		return array;
	}
}
