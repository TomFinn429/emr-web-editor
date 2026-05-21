using System;
using System.Collections.Generic;

namespace zzz;

internal static class z0ZzZzuok
{
	public delegate object z0tpk();

	private static readonly Dictionary<Type, z0tpk> z0tek = new Dictionary<Type, z0tpk>();

	public static BaseType z0eek<BaseType>()
	{
		z0tpk z0tpk = null;
		if (z0tek.TryGetValue(typeof(BaseType), out z0tpk))
		{
			return (BaseType)z0tpk();
		}
		throw new NotSupportedException(typeof(BaseType).FullName);
	}

	public static void z0rek<BaseType>(z0tpk p0)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("handler");
		}
		z0tek[typeof(BaseType)] = p0;
	}
}
