using System.Collections.Generic;

namespace zzz;

public class z0ZzZzutk : List<z0ZzZzytk>
{
	public double z0eek()
	{
		double num = 0.0;
		using List<z0ZzZzytk>.Enumerator enumerator = GetEnumerator();
		while (enumerator.MoveNext())
		{
			z0ZzZzytk current = enumerator.Current;
			if (!z0ZzZzbok.z0eek(current.z0eek()))
			{
				num += current.z0eek();
			}
		}
		return num;
	}
}
