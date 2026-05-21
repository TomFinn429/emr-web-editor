using System.Collections.Generic;
using System.Reflection;
using DCSoft.Writer.Dom;

namespace zzz;

[DefaultMember("Item")]
internal class z0ZzZzbkh : List<z0ZzZznkh>
{
	public z0ZzZznkh z0eek(XTextElement p0)
	{
		using (List<z0ZzZznkh>.Enumerator enumerator = GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				z0ZzZznkh current = enumerator.Current;
				if (current.z0tek() == p0)
				{
					return current;
				}
			}
		}
		return null;
	}

	public z0ZzZzbkh z0eek()
	{
		z0ZzZzbkh z0ZzZzbkh2 = new z0ZzZzbkh();
		using List<z0ZzZznkh>.Enumerator enumerator = GetEnumerator();
		while (enumerator.MoveNext())
		{
			z0ZzZznkh current = enumerator.Current;
			z0ZzZzbkh2.Add(current);
		}
		return z0ZzZzbkh2;
	}
}
