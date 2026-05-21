using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;

namespace zzz;

[DefaultMember("Item")]
[DebuggerTypeProxy(typeof(z0ZzZzlyj))]
[DebuggerDisplay("Count={ Count }")]
internal class z0ZzZzqyj : List<z0ZzZzsyj>
{
	public z0ZzZzsyj z0eek(string p0)
	{
		using (List<z0ZzZzsyj>.Enumerator enumerator = GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				z0ZzZzsyj current = enumerator.Current;
				if (current.z0ijk() == p0)
				{
					return current;
				}
			}
		}
		return null;
	}
}
