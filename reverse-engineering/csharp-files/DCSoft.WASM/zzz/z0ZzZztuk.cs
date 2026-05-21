using System;
using System.Collections.Generic;

namespace zzz;

public class z0ZzZztuk
{
	private readonly Dictionary<Type, object> z0tek = new Dictionary<Type, object>();

	private void z0eek(Type p0, object p1)
	{
		if (p1 != null && !p0.IsInstanceOfType(p1))
		{
			throw new InvalidCastException(p1.GetType().FullName + "!=" + p0.FullName);
		}
	}

	public void z0rek(Type p0, object p1)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("serviceType");
		}
		z0eek(p0, p1);
		z0tek[p0] = p1;
	}

	public object z0eek(Type p0)
	{
		if (z0tek.ContainsKey(p0))
		{
			return z0tek[p0];
		}
		foreach (object value in z0tek.Values)
		{
			if (p0.IsInstanceOfType(value))
			{
				return value;
			}
		}
		return null;
	}
}
