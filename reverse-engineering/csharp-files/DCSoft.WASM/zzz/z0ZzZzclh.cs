using System.Collections.Generic;
using System.Diagnostics;
using DCSoft.Writer.Dom;

namespace zzz;

[DebuggerDisplay("Count={ Count }")]
[DebuggerTypeProxy(typeof(z0ZzZzkik))]
public class z0ZzZzclh : List<XTextDocument>
{
	public z0ZzZzclh()
	{
	}

	public z0ZzZzerj z0eek()
	{
		z0ZzZzerj z0ZzZzerj2 = new z0ZzZzerj();
		using (Enumerator enumerator = GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				XTextDocument current = enumerator.Current;
				z0ZzZzerj2.AddRange(current.z0suk());
			}
		}
		for (int i = 0; i < z0ZzZzerj2.Count; i++)
		{
			z0ZzZzerj2[i].z0eek(i);
		}
		return z0ZzZzerj2;
	}

	public z0ZzZzclh(XTextDocument p0)
	{
		Add(p0);
	}

	public XTextDocument z0rek()
	{
		if (base.Count > 0)
		{
			return base[0];
		}
		return null;
	}
}
