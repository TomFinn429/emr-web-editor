using System.Collections.Generic;

namespace zzz;

public class z0ZzZzatk : List<z0ZzZzstk>
{
	public z0ZzZzatk z0eek()
	{
		z0ZzZzatk z0ZzZzatk2 = new z0ZzZzatk();
		using List<z0ZzZzstk>.Enumerator enumerator = GetEnumerator();
		while (enumerator.MoveNext())
		{
			z0ZzZzstk current = enumerator.Current;
			z0ZzZzatk2.Add(current.z0lrk());
		}
		return z0ZzZzatk2;
	}

	public z0ZzZzstk z0eek(string p0)
	{
		if (base.Count == 0 || string.IsNullOrEmpty(p0))
		{
			return null;
		}
		for (int i = 0; i < base.Count; i++)
		{
			if (base[i].z0mek() == p0)
			{
				return base[i];
			}
		}
		return null;
	}
}
