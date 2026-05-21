using System;
using System.Diagnostics;

namespace zzz;

[DebuggerTypeProxy(typeof(z0ZzZzkik))]
[DebuggerDisplay("Count={ Count }")]
public class z0ZzZzlkh : zzz.z0ZzZzkuk<z0ZzZzzlh>
{
	public z0ZzZzlkh(int p0)
		: base(p0)
	{
	}

	public z0ZzZzlkh()
	{
	}

	internal void z0eek()
	{
		z0ZzZzzlh[] array = z0krk();
		for (int num = base.Count - 1; num >= 0; num--)
		{
			array[num].z0kyk();
		}
		z0vrk();
	}

	internal z0ZzZzzlh z0eek(z0ZzZzzlh p0)
	{
		if (p0 == null)
		{
			return null;
		}
		int num = IndexOf(p0);
		if (num > 0)
		{
			return base[num - 1];
		}
		return null;
	}

	public int z0rek(z0ZzZzzlh p0)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("line");
		}
		int z0tuk = p0.z0tuk;
		if (z0tuk >= 0 && z0tuk < base.Count && base[z0tuk] == p0)
		{
			return z0tuk;
		}
		return IndexOf(p0);
	}

	public bool z0tek(z0ZzZzzlh p0)
	{
		if (p0 != null && p0.z0tuk >= 0 && p0.z0tuk < base.Count)
		{
			return base[p0.z0tuk] == p0;
		}
		return false;
	}

	public void z0eek(int p0, z0ZzZzzlh p1)
	{
		base[p0] = p1;
	}

	public z0ZzZzzlh z0rek()
	{
		if (base.Count > 0)
		{
			return base[base.Count - 1];
		}
		return null;
	}
}
