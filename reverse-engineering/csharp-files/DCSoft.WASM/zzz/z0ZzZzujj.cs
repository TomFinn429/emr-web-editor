using System;
using System.Collections.Generic;
using DCSoft;

namespace zzz;

internal abstract class z0ZzZzujj<T> : z0ZzZzygj where T : IDisposable
{
	private readonly Dictionary<z0ZzZzojj, T> z0rek = new Dictionary<z0ZzZzojj, T>();

	protected T z0eek(z0ZzZzojj p0, DCFunc<T> p1)
	{
		if (!z0rek.TryGetValue(p0, out var val))
		{
			val = p1();
			z0rek.Add(p0, val);
		}
		return val;
	}

	protected override void z0ygk(bool p0)
	{
		if (!p0)
		{
			return;
		}
		foreach (KeyValuePair<z0ZzZzojj, T> item in z0rek)
		{
			item.Value.Dispose();
		}
	}
}
