using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;

namespace zzz;

[DefaultMember("Item")]
[DebuggerTypeProxy(typeof(z0ZzZzkik))]
public class z0ZzZzvmj : List<z0ZzZzrmj>
{
	public int z0eek(z0ZzZzrmj p0)
	{
		z0ZzZzrmj z0ZzZzrmj2 = z0eek(p0.z0tek);
		if (z0ZzZzrmj2 != null)
		{
			Remove(z0ZzZzrmj2);
		}
		Add(p0);
		return base.Count - 1;
	}

	public z0ZzZzrmj z0eek(string p0)
	{
		if (p0 == null)
		{
			return null;
		}
		using (Enumerator enumerator = GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				z0ZzZzrmj current = enumerator.Current;
				if (string.Compare(current.z0tek, p0, true) == 0)
				{
					return current;
				}
			}
		}
		return null;
	}
}
