using System;
using System.Collections;
using System.Diagnostics;
using System.Reflection;

namespace zzz;

[Obfuscation(Exclude = true, ApplyToMembers = false)]
public class z0ZzZzkik
{
	private readonly object z0eek;

	[DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
	public object Items
	{
		get
		{
			if (z0eek is IEnumerable)
			{
				ArrayList arrayList = new ArrayList();
				foreach (object item in (IEnumerable)z0eek)
				{
					arrayList.Add(item);
				}
				return arrayList.ToArray();
			}
			return z0eek;
		}
	}

	public z0ZzZzkik(object p0)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("instance");
		}
		z0eek = p0;
	}
}
