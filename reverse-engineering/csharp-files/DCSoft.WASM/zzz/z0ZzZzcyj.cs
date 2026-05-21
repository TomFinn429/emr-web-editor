using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;

namespace zzz;

[DefaultMember("Item")]
[DebuggerTypeProxy(typeof(z0ZzZzlyj))]
internal class z0ZzZzcyj
{
	private List<z0ZzZzvyj> z0rek = new List<z0ZzZzvyj>();

	public void z0eek(string p0, string p1)
	{
		foreach (z0ZzZzvyj item in z0rek)
		{
			if (item.z0eek() == p0)
			{
				if (p1 == null)
				{
					z0rek.Remove(item);
				}
				else
				{
					item.z0rek(p1);
				}
				return;
			}
		}
		if (p1 != null)
		{
			z0ZzZzvyj z0ZzZzvyj2 = new z0ZzZzvyj();
			z0ZzZzvyj2.z0eek(p0);
			z0ZzZzvyj2.z0rek(p1);
			z0rek.Add(z0ZzZzvyj2);
		}
	}

	public string z0eek(string p0)
	{
		foreach (z0ZzZzvyj item in z0rek)
		{
			if (item.z0eek() == p0)
			{
				return item.z0rek();
			}
		}
		return null;
	}
}
