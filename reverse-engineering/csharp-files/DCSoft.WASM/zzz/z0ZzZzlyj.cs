using System;
using System.Collections;

namespace zzz;

internal class z0ZzZzlyj
{
	private object z0rek;

	public object z0eek()
	{
		if (z0rek is IEnumerable)
		{
			IEnumerable obj = (IEnumerable)z0rek;
			ArrayList arrayList = new ArrayList();
			foreach (object item in obj)
			{
				arrayList.Add(item);
			}
			return arrayList.ToArray();
		}
		if (z0rek is z0ZzZzzrj)
		{
			z0ZzZzzrj z0ZzZzzrj2 = (z0ZzZzzrj)z0rek;
			object[] array = new object[z0ZzZzzrj2.z0rek()];
			for (int i = 0; i < z0ZzZzzrj2.z0rek(); i++)
			{
				array[i] = z0ZzZzzrj2.z0eek(i);
			}
			return array;
		}
		if (z0rek is z0ZzZzktj)
		{
			return ((z0ZzZzktj)z0rek).z0tek();
		}
		return z0rek;
	}

	public z0ZzZzlyj(object p0)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("instance");
		}
		z0rek = p0;
	}
}
