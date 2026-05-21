using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;

namespace zzz;

[DefaultMember("Item")]
[DebuggerTypeProxy(typeof(z0ZzZzlyj))]
public class z0ZzZzxrj : List<z0ZzZzcrj>
{
	public int z0eek(string p0, int p1)
	{
		z0ZzZzcrj z0ZzZzcrj2 = new z0ZzZzcrj();
		z0ZzZzcrj2.z0eek(p0);
		z0ZzZzcrj2.z0eek(p1);
		Add(z0ZzZzcrj2);
		return base.Count - 1;
	}

	public z0ZzZzxrj z0eek()
	{
		z0ZzZzxrj z0ZzZzxrj2 = new z0ZzZzxrj();
		using List<z0ZzZzcrj>.Enumerator enumerator = GetEnumerator();
		while (enumerator.MoveNext())
		{
			z0ZzZzcrj current = enumerator.Current;
			z0ZzZzcrj z0ZzZzcrj2 = new z0ZzZzcrj();
			z0ZzZzcrj2.z0eek(current.z0eek());
			z0ZzZzcrj2.z0eek(current.z0rek());
			z0ZzZzxrj2.Add(z0ZzZzcrj2);
		}
		return z0ZzZzxrj2;
	}

	public z0ZzZzcrj z0eek(int p0)
	{
		return base[p0];
	}

	public void z0rek(string p0, int p1)
	{
		using (List<z0ZzZzcrj>.Enumerator enumerator = GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				z0ZzZzcrj current = enumerator.Current;
				if (current.z0eek() == p0)
				{
					current.z0eek(p1);
					return;
				}
			}
		}
		z0ZzZzcrj z0ZzZzcrj2 = new z0ZzZzcrj();
		z0ZzZzcrj2.z0eek(p0);
		z0ZzZzcrj2.z0eek(p1);
		Add(z0ZzZzcrj2);
	}

	public bool z0eek(string p0)
	{
		using (List<z0ZzZzcrj>.Enumerator enumerator = GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				if (enumerator.Current.z0eek() == p0)
				{
					return true;
				}
			}
		}
		return false;
	}

	public int z0rek(string p0)
	{
		using (List<z0ZzZzcrj>.Enumerator enumerator = GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				z0ZzZzcrj current = enumerator.Current;
				if (current.z0eek() == p0)
				{
					return current.z0rek();
				}
			}
		}
		return -2147483648;
	}

	public void z0tek(string p0)
	{
		for (int num = base.Count - 1; num >= 0; num--)
		{
			if (base[num].z0eek() == p0)
			{
				RemoveAt(num);
			}
		}
	}
}
