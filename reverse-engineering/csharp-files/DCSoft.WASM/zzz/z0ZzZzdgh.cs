using System;
using System.Collections.Generic;

namespace zzz;

public class z0ZzZzdgh
{
	private Dictionary<Type, z0ZzZzfgh> z0rek = new Dictionary<Type, z0ZzZzfgh>();

	private Dictionary<Type, z0ZzZzfgh> z0tek = new Dictionary<Type, z0ZzZzfgh>();

	private static z0ZzZzdgh z0yek = new z0ZzZzdgh();

	public static z0ZzZzdgh z0eek()
	{
		return z0yek;
	}

	public void z0eek(Type p0, z0ZzZzfgh p1)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("instanceType");
		}
		if (p1 == null)
		{
			throw new ArgumentNullException("provider");
		}
		z0rek[p0] = p1;
		z0tek.Clear();
	}

	public z0ZzZzfgh z0eek(Type p0)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("instanceType");
		}
		if (z0tek.ContainsKey(p0))
		{
			return z0tek[p0];
		}
		z0ZzZzfgh z0ZzZzfgh2 = null;
		if (z0rek.ContainsKey(p0))
		{
			z0ZzZzfgh2 = z0rek[p0];
		}
		else
		{
			Type baseType = p0.BaseType;
			while (baseType != null)
			{
				if (z0rek.ContainsKey(baseType))
				{
					z0ZzZzfgh2 = z0rek[baseType];
					break;
				}
				baseType = baseType.BaseType;
			}
		}
		z0tek[p0] = z0ZzZzfgh2;
		return z0ZzZzfgh2;
	}
}
