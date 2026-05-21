using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Text;

namespace zzz;

[DebuggerTypeProxy(typeof(z0ZzZzlyj))]
[DefaultMember("Item")]
[DebuggerDisplay("Count={ Count }")]
public class z0ZzZzztj : IEnumerable<z0ZzZzxtj>, IEnumerable
{
	private List<z0ZzZzxtj> z0yek = new List<z0ZzZzxtj>();

	public z0ZzZzxtj z0eek(string p0)
	{
		using (IEnumerator<z0ZzZzxtj> enumerator = GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				z0ZzZzxtj current = enumerator.Current;
				if (current.z0iek() == p0)
				{
					return current;
				}
			}
		}
		return null;
	}

	public string z0eek(int p0)
	{
		return z0rek(p0)?.z0iek();
	}

	public z0ZzZzxtj z0rek(string p0)
	{
		return z0eek(z0tek(), p0, z0ZzZzltj.z0rik);
	}

	public void z0eek(z0ZzZzxtj p0)
	{
		z0yek.Add(p0);
	}

	public IEnumerator<z0ZzZzxtj> GetEnumerator()
	{
		return z0yek.GetEnumerator();
	}

	private IEnumerator z0eek()
	{
		return z0yek.GetEnumerator();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		//ILSpy generated this explicit interface implementation from .override directive in z0eek
		return this.z0eek();
	}

	public int z0tek(string p0)
	{
		using (IEnumerator<z0ZzZzxtj> enumerator = GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				z0ZzZzxtj current = enumerator.Current;
				if (current.z0iek() == p0)
				{
					return current.z0uek();
				}
			}
		}
		return -1;
	}

	public void z0rek()
	{
		z0yek.Clear();
	}

	public int z0tek()
	{
		return z0yek.Count;
	}

	public z0ZzZzxtj z0eek(string p0, Encoding p1)
	{
		return z0eek(z0tek(), p0, p1);
	}

	public z0ZzZzxtj z0rek(int p0)
	{
		using (IEnumerator<z0ZzZzxtj> enumerator = GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				z0ZzZzxtj current = enumerator.Current;
				if (current.z0uek() == p0)
				{
					return current;
				}
			}
		}
		return null;
	}

	public z0ZzZzxtj z0eek(int p0, string p1, Encoding p2)
	{
		if (z0eek(p1) == null)
		{
			z0ZzZzxtj z0ZzZzxtj2 = new z0ZzZzxtj(p0, p1);
			if (p2 != null)
			{
				z0ZzZzxtj2.z0tek(z0ZzZzxtj.z0eek(p2));
			}
			z0yek.Add(z0ZzZzxtj2);
			return z0ZzZzxtj2;
		}
		return z0eek(p1);
	}
}
