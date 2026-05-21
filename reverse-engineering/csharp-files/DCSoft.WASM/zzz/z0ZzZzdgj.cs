using System.Collections.Generic;

namespace zzz;

internal class z0ZzZzdgj
{
	private bool z0yek = true;

	private readonly Dictionary<int, string> z0uek = new Dictionary<int, string>();

	internal z0ZzZzdgj()
	{
	}

	internal IDictionary<int, string> z0rek()
	{
		return z0uek;
	}

	internal void z0rek(bool p0)
	{
		z0yek = p0;
	}

	internal void z0eek(IDictionary<int, string> p0)
	{
		if (p0 is z0ZzZzmdj.z0shj z0shj)
		{
			if (!z0uek.ContainsKey(z0shj.z0cek))
			{
				z0uek.Add(z0shj.z0cek, z0shj.z0vek);
				z0rek(p0: true);
			}
			return;
		}
		_ = p0.Count;
		foreach (KeyValuePair<int, string> item in p0)
		{
			int key = item.Key;
			if (!z0uek.ContainsKey(key))
			{
				z0uek.Add(key, item.Value);
				z0yek = true;
			}
		}
	}

	internal bool z0tek()
	{
		return z0yek;
	}
}
