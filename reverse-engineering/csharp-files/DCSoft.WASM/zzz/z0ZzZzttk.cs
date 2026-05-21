using System.Collections.Generic;
using System.Reflection;

namespace zzz;

[DefaultMember("Item")]
public class z0ZzZzttk : List<z0ZzZzrtk>
{
	public z0ZzZzttk z0eek()
	{
		z0ZzZzttk obj = new z0ZzZzttk();
		obj.AddRange(this);
		return obj;
	}

	public z0ZzZzrtk z0eek(string p0)
	{
		using (List<z0ZzZzrtk>.Enumerator enumerator = GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				z0ZzZzrtk current = enumerator.Current;
				if (current.z0lrk() == p0)
				{
					return current;
				}
			}
		}
		return null;
	}
}
