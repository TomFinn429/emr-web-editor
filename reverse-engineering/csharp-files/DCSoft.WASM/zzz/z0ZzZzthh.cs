using System.Collections.Generic;

namespace zzz;

public class z0ZzZzthh : List<z0ZzZzrhh>
{
	public z0ZzZzthh z0eek()
	{
		z0ZzZzthh z0ZzZzthh2 = new z0ZzZzthh();
		using Enumerator enumerator = GetEnumerator();
		while (enumerator.MoveNext())
		{
			z0ZzZzrhh current = enumerator.Current;
			z0ZzZzthh2.Add(current.z0tek());
		}
		return z0ZzZzthh2;
	}

	public bool z0rek()
	{
		if (base.Count == 0)
		{
			return true;
		}
		using (Enumerator enumerator = GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				if (!string.IsNullOrEmpty(enumerator.Current.z0rek()))
				{
					return false;
				}
			}
		}
		return true;
	}
}
