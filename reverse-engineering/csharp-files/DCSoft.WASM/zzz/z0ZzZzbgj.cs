using System.Collections.Generic;

namespace zzz;

internal abstract class z0ZzZzbgj : z0ZzZzygj
{
	private readonly z0ZzZzbhj z0uek;

	private readonly IDictionary<zzz.z0ZzZzkxk<string, z0ZzZziqj, z0ZzZzvgj>, z0ZzZzngj> z0iek = new Dictionary<zzz.z0ZzZzkxk<string, z0ZzZziqj, z0ZzZzvgj>, z0ZzZzngj>();

	protected bool z0tek(string p0, bool p1, bool p2)
	{
		if (z0uek.z0eek().z0yek() != null)
		{
			return z0uek.z0eek().z0yek().z0rek(p0, p1, p2);
		}
		return true;
	}

	protected bool z0eek(zzz.z0ZzZzkxk<string, z0ZzZziqj, z0ZzZzvgj> p0, out z0ZzZzngj p1)
	{
		return z0iek.TryGetValue(p0, out p1);
	}

	protected z0ZzZzbgj(z0ZzZzbhj p0)
	{
		z0uek = p0;
	}

	protected void z0rek(zzz.z0ZzZzkxk<string, z0ZzZziqj, z0ZzZzvgj> p0, z0ZzZzngj p1)
	{
		z0iek.Add(p0, p1);
	}

	protected override void z0ygk(bool p0)
	{
		if (!p0)
		{
			return;
		}
		foreach (z0ZzZzngj value in z0iek.Values)
		{
			value.Dispose();
		}
		z0iek.Clear();
	}

	internal void z0tek()
	{
		lock (GetType())
		{
			foreach (z0ZzZzngj value in z0iek.Values)
			{
				value.z0yek();
			}
		}
	}

	protected z0ZzZzbhj z0yek()
	{
		return z0uek;
	}
}
