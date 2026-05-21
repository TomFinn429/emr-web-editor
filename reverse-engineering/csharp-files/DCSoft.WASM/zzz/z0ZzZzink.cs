using System;
using System.Reflection;

namespace zzz;

[DefaultMember("Item")]
internal class z0ZzZzink : zzz.z0ZzZzkuk<z0ZzZzunk>, IDisposable
{
	private new z0ZzZzunk z0oek;

	public new static bool z0pek = true;

	public int z0eek(string p0)
	{
		if (base.Count == 0)
		{
			return -1;
		}
		for (int num = base.Count - 1; num >= 0; num--)
		{
			if (base[num].z0rek() == p0)
			{
				return num;
			}
		}
		return -1;
	}

	public void z0eek(string p0, string p1)
	{
		int num = z0eek(p0);
		if (num >= 0)
		{
			base[num] = new z0ZzZzunk(p0, p1);
		}
		else
		{
			Add(new z0ZzZzunk(p0, p1));
		}
	}

	internal int z0eek(string p0, int p1)
	{
		z0ZzZzunk[] array = z0krk();
		for (int num = p1 - 1; num >= 0; num--)
		{
			if (array[num].z0mek == p0)
			{
				return num;
			}
		}
		return -1;
	}

	public void z0rek(string p0)
	{
		z0oek = null;
		int num = z0eek(p0);
		if (num > 0)
		{
			RemoveAt(num);
		}
	}

	public string z0tek(string p0)
	{
		if (base.Count > 0)
		{
			for (int num = base.Count - 1; num >= 0; num--)
			{
				if (base[num].z0rek() == p0)
				{
					return base[num].z0yek();
				}
			}
		}
		return null;
	}

	public bool z0yek(string p0)
	{
		z0oek = z0iek(p0);
		return z0oek != null;
	}

	public string z0uek(string p0)
	{
		if (z0oek != null && z0oek.z0eek() == p0)
		{
			return z0oek.z0yek();
		}
		return z0iek(p0)?.z0yek();
	}

	public z0ZzZzunk z0iek(string p0)
	{
		if (base.Count == 0)
		{
			return null;
		}
		string text = p0;
		if (z0pek)
		{
			text = p0.ToLower();
		}
		for (int num = base.Count - 1; num >= 0; num--)
		{
			if (base[num].z0rek() == text)
			{
				return base[num];
			}
		}
		return null;
	}

	public void Dispose()
	{
		base.z0zrk();
		using (zzz.z0ZzZzkuk<z0ZzZzunk>.z0bpk z0bpk = z0ltk())
		{
			while (z0bpk.MoveNext())
			{
				z0bpk.Current.Dispose();
			}
		}
		Clear();
		z0oek = null;
	}
}
