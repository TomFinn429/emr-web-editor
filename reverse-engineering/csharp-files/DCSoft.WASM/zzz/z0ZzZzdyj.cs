using System.Collections.Generic;

namespace zzz;

public class z0ZzZzdyj : List<z0ZzZzjyj>
{
	public z0ZzZzjyj z0eek(int p0)
	{
		using (List<z0ZzZzjyj>.Enumerator enumerator = GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				z0ZzZzjyj current = enumerator.Current;
				if (current.z0uek() == p0)
				{
					return current;
				}
			}
		}
		return null;
	}
}
