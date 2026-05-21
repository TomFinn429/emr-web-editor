using System.Collections.Generic;

namespace zzz;

public class z0ZzZzvej : List<z0ZzZzcej>
{
	private bool z0uek;

	public z0ZzZzvej z0eek()
	{
		z0ZzZzvej z0ZzZzvej2 = new z0ZzZzvej();
		z0ZzZzvej2.z0uek = z0uek;
		using Enumerator enumerator = GetEnumerator();
		while (enumerator.MoveNext())
		{
			z0ZzZzcej current = enumerator.Current;
			z0ZzZzvej2.Add(current.z0rek());
		}
		return z0ZzZzvej2;
	}

	public bool z0rek()
	{
		return z0uek;
	}

	public z0ZzZzcej z0eek(int p0, z0ZzZzbdh p1)
	{
		z0ZzZzcej z0ZzZzcej2 = new z0ZzZzcej();
		z0ZzZzcej2.z0eek(p0);
		z0ZzZzcej2.z0eek(p1);
		Add(z0ZzZzcej2);
		return z0ZzZzcej2;
	}

	public z0ZzZzbdh z0tek()
	{
		z0ZzZzbdh z0ZzZzbdh2 = z0ZzZzbdh.z0xek;
		using Enumerator enumerator = GetEnumerator();
		while (enumerator.MoveNext())
		{
			z0ZzZzcej current = enumerator.Current;
			z0ZzZzbdh2 = ((!z0ZzZzbdh2.z0bek()) ? z0ZzZzbdh.z0yek(z0ZzZzbdh2, current.z0eek()) : current.z0eek());
		}
		return z0ZzZzbdh2;
	}

	public void z0eek(bool p0)
	{
		z0uek = p0;
	}

	public bool z0yek()
	{
		if (!z0rek())
		{
			return false;
		}
		using (Enumerator enumerator = GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				z0ZzZzcej current = enumerator.Current;
				if (current.z0tek() >= 0 && !current.z0eek().z0bek())
				{
					return true;
				}
			}
		}
		return false;
	}
}
