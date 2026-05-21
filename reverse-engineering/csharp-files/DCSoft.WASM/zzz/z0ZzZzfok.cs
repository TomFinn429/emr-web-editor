using System.Collections.Generic;
using System.Reflection;

namespace zzz;

[DefaultMember("Item")]
public class z0ZzZzfok : List<z0ZzZzgok>
{
	public z0ZzZzgok z0eek(string p0)
	{
		z0ZzZzgok z0ZzZzgok2 = new z0ZzZzgok();
		z0ZzZzgok2.z0eek(p0);
		Add(z0ZzZzgok2);
		return z0ZzZzgok2;
	}

	public z0ZzZzgok z0rek(string p0)
	{
		using (Enumerator enumerator = GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				z0ZzZzgok current = enumerator.Current;
				if (string.Compare(current.z0rek(), p0, true) == 0)
				{
					return current;
				}
			}
		}
		return null;
	}
}
