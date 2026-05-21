using System.Collections.Generic;

namespace zzz;

public class z0ZzZzfyj : List<z0ZzZzgyj>
{
	public z0ZzZzgyj z0eek(int p0)
	{
		using (List<z0ZzZzgyj>.Enumerator enumerator = GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				z0ZzZzgyj current = enumerator.Current;
				if (current.z0tek() == p0)
				{
					return current;
				}
			}
		}
		return null;
	}
}
