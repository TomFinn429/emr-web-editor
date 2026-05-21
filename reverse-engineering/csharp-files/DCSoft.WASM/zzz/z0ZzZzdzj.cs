using System.Collections.Generic;
using System.Diagnostics;

namespace zzz;

[DebuggerDisplay("Count={ Count }")]
[DebuggerTypeProxy(typeof(z0ZzZzkik))]
public class z0ZzZzdzj : List<z0ZzZzfzj>
{
	private z0ZzZzfzj z0eek(int p0)
	{
		using (Enumerator enumerator = GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				z0ZzZzfzj current = enumerator.Current;
				if (current.z0tek() == p0)
				{
					return current;
				}
			}
		}
		return null;
	}

	public z0ZzZzpmk z0rek(int p0)
	{
		return z0eek(p0)?.z0eek();
	}

	public z0ZzZzdzj z0eek()
	{
		z0ZzZzdzj z0ZzZzdzj2 = new z0ZzZzdzj();
		using Enumerator enumerator = GetEnumerator();
		while (enumerator.MoveNext())
		{
			z0ZzZzfzj current = enumerator.Current;
			z0ZzZzdzj2.Add(current.z0rek());
		}
		return z0ZzZzdzj2;
	}

	public void z0eek(int p0, z0ZzZzpmk p1)
	{
		z0ZzZzfzj z0ZzZzfzj2 = z0eek(p0);
		if (p1 == null)
		{
			if (z0ZzZzfzj2 != null)
			{
				Remove(z0ZzZzfzj2);
			}
			return;
		}
		if (z0ZzZzfzj2 == null)
		{
			z0ZzZzfzj2 = new z0ZzZzfzj();
			z0ZzZzfzj2.z0eek(p0);
			Add(z0ZzZzfzj2);
		}
		z0ZzZzfzj2.z0eek(p1);
	}
}
