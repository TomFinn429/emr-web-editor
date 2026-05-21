using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;

namespace zzz;

[DefaultMember("Item")]
[DebuggerTypeProxy(typeof(z0ZzZzkik))]
[DebuggerDisplay("Count={ Count }")]
public class z0ZzZzguj : List<z0ZzZzhuj>
{
	public z0ZzZzguj z0eek()
	{
		z0ZzZzguj z0ZzZzguj2 = new z0ZzZzguj();
		using Enumerator enumerator = GetEnumerator();
		while (enumerator.MoveNext())
		{
			z0ZzZzhuj current = enumerator.Current;
			z0ZzZzguj2.Add(current);
		}
		return z0ZzZzguj2;
	}

	public z0ZzZzhuj z0eek(string p0)
	{
		using (Enumerator enumerator = GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				z0ZzZzhuj current = enumerator.Current;
				if (current.z0yek() == p0)
				{
					return current;
				}
			}
		}
		return null;
	}
}
