using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace zzz;

internal class z0ZzZzeaj : z0ZzZzrgj, z0ZzZzlgj
{
	private readonly z0ZzZzdsj z0uek;

	private void z0tek_jiejie20260327142557(string p0, z0ZzZznsj p1)
	{
		if (p1 != null && z0uek != null)
		{
			Add(p0, z0uek.z0uek(p1));
		}
	}

	internal void z0tek_jiejie20260327142557(string p0, z0ZzZzfsj p1, z0ZzZzfsj p2)
	{
		if (p1 != null && !p1.Equals(p2))
		{
			Add(p0, z0uek.z0oek(p1));
		}
	}

	internal void z0tek_jiejie20260327142557(string p0, z0ZzZziwj p1, z0ZzZziwj p2)
	{
		if (p1 != null && !p1.Equals(p2))
		{
			Add(p0, p1.z0uek());
		}
	}

	internal z0ZzZzeaj(z0ZzZzdsj p0)
	{
		z0uek = p0;
	}

	internal void z0tek_jiejie20260327142557(string p0, z0ZzZzfsj p1)
	{
		z0tek_jiejie20260327142557(p0, p1, null);
	}

	internal void z0tek_jiejie20260327142557(string p0, z0ZzZzraj p1)
	{
		z0tek_jiejie20260327142557(p0, (z0ZzZznsj)p1);
	}

	internal void z0tek_jiejie20260327142557(string p0, object p1)
	{
		if (p1 != null)
		{
			Add(p0, p1);
		}
	}

	internal void z0eek<T>(string p0, T? p1) where T : struct
	{
		if (p1.HasValue)
		{
			Add(p0, p1.Value);
		}
	}

	internal z0ZzZzdsj z0tek_jiejie20260327142557()
	{
		return z0uek;
	}

	internal void z0tek_jiejie20260327142557(string p0, string p1)
	{
		if (p1 != null)
		{
			Add(p0, Encoding.ASCII.GetBytes(p1));
		}
	}

	internal void z0rek(string p0, IEnumerable<double> p1)
	{
		if (p1 != null)
		{
			Add(p0, new z0ZzZzqaj(p1));
		}
	}

	internal void z0tek_jiejie20260327142557(string p0, object p1, object p2)
	{
		if ((p1 == null && p2 != null) || (p1 != null && !p1.Equals(p2)))
		{
			Add(p0, p1);
		}
	}

	internal void z0tek_jiejie20260327142557(string p0, z0ZzZziwj p1)
	{
		if (p1 != null)
		{
			Add(p0, p1.z0uek());
		}
	}

	private void z0tek_jiejie20260327142557(z0ZzZzpgj p0, int p1)
	{
		p0.z0rek();
		using (Enumerator enumerator = GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				KeyValuePair<string, object> current = enumerator.Current;
				if (current.Value is z0ZzZznsj)
				{
					throw new InvalidOperationException();
				}
				((z0ZzZzlgj)new z0ZzZzhwj(current.Key)).z0nfk(p0, p1);
				p0.z0pek();
				p0.z0eek(current.Value, p1);
				p0.z0pek();
			}
		}
		p0.z0uek();
	}

	void z0ZzZzlgj.z0nfk(z0ZzZzpgj p0, int p1)
	{
		//ILSpy generated this explicit interface implementation from .override directive in z0tek_jiejie20260327142557
		this.z0tek_jiejie20260327142557(p0, p1);
	}

	internal void z0tek_jiejie20260327142557(CultureInfo p0)
	{
		if (p0 != CultureInfo.InvariantCulture)
		{
			Add("Lang", z0ZzZzpgj.z0rek(p0.Name));
		}
	}

	internal void z0yek(string p0, string p1)
	{
		if (!string.IsNullOrEmpty(p1))
		{
			Add(p0, new z0ZzZzhwj(p1));
		}
	}
}
