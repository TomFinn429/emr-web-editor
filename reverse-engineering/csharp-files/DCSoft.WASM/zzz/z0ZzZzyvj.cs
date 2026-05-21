using System;
using System.Collections;

namespace zzz;

public class z0ZzZzyvj
{
	internal virtual object z0eek(z0ZzZztvj p0, object p1, object p2, bool p3)
	{
		return z0rek(p0, p1, p2, p3);
	}

	internal static object z0rek(z0ZzZztvj p0, object p1, object p2, bool p3)
	{
		if (p0 == null)
		{
			if (p3)
			{
				throw new ArgumentNullException("item");
			}
			return p2;
		}
		if (p1 == null)
		{
			if (p3)
			{
				throw new ArgumentNullException("instance");
			}
			return p2;
		}
		if (!p0.z0yek().IsInstanceOfType(p1))
		{
			if (p3)
			{
				throw new InvalidCastException(p1.GetType().FullName + "->" + p0.z0yek().FullName);
			}
			return p2;
		}
		if (string.IsNullOrEmpty(p0.z0tek()))
		{
			return p1;
		}
		if (p1 is IDictionary)
		{
			IDictionary dictionary = (IDictionary)p1;
			if (dictionary.Contains(p0.z0tek()))
			{
				return dictionary[p0.z0tek()];
			}
			return p2;
		}
		if (p1 is z0ZzZzoah)
		{
			z0ZzZzoah z0ZzZzoah2 = ((z0ZzZzoah)p1).z0eek(p0.z0tek());
			if (z0ZzZzoah2 == null)
			{
				return p2;
			}
			if (z0ZzZzoah2 is z0ZzZzsah)
			{
				return z0ZzZzoah2.z0eg();
			}
			return z0ZzZzoah2.z0rh();
		}
		if (p3)
		{
			return p0.z0rek().GetValue(p1);
		}
		try
		{
			return p0.z0rek().GetValue(p1);
		}
		catch
		{
			return p2;
		}
	}

	public static object z0eek(z0ZzZzrvj p0, object p1, object p2, bool p3, z0ZzZzyvj p4)
	{
		object obj = p1;
		for (int i = 0; i < p0.z0tek().Count; i++)
		{
			object obj2 = null;
			obj2 = ((p4 != null) ? p4.z0eek(p0.z0tek()[i], obj, null, p3) : z0rek(p0.z0tek()[i], obj, null, p3));
			if (obj2 == null)
			{
				return p2;
			}
			obj = obj2;
		}
		return obj;
	}
}
