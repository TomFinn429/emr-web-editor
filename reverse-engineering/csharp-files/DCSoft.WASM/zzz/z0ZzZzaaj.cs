using System.Collections;
using System.Collections.Generic;
using DCSoft;

namespace zzz;

internal class z0ZzZzaaj<T> : zzz.z0ZzZzsaj<object>
{
	internal z0ZzZzaaj(IEnumerable p0, DCFunc<T, object> p1)
		: base(z0rek(p0, p1))
	{
	}

	private static IEnumerable<object> z0eek(IEnumerable<T> p0, DCFunc<T, object> p1)
	{
		List<object> list = new List<object>();
		foreach (T item in p0)
		{
			list.Add(p1(item));
		}
		return list;
	}

	protected override void z0mfk(z0ZzZzpgj p0, object p1, int p2)
	{
		p0.z0eek(p1, p2);
	}

	internal z0ZzZzaaj(IEnumerable<T> p0, DCFunc<T, object> p1)
		: base(z0eek(p0, p1))
	{
	}

	private static IEnumerable<object> z0rek(IEnumerable p0, DCFunc<T, object> p1)
	{
		List<object> list = new List<object>();
		foreach (T item in p0)
		{
			list.Add(p1(item));
		}
		return list;
	}
}
