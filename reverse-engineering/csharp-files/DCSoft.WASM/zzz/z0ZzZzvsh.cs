using System;
using System.Collections;
using System.Reflection;

namespace zzz;

[DefaultMember("Item")]
public sealed class z0ZzZzvsh : z0ZzZzuah, ICollection, IEnumerable
{
	public z0ZzZzbsh z0eek_jiejie20260327142557(z0ZzZzbsh p0)
	{
		int num = base.z0tek.z0eek();
		for (int i = 0; i < num; i++)
		{
			if (base.z0tek.z0eek(i) == p0)
			{
				z0ef(i);
				return p0;
			}
		}
		return null;
	}

	private int z0eek_jiejie20260327142557()
	{
		return base.Count;
	}

	int ICollection.get_Count()
	{
		//ILSpy generated this explicit interface implementation from .override directive in z0eek_jiejie20260327142557
		return this.z0eek_jiejie20260327142557();
	}

	public void z0rek()
	{
		int num = Count;
		while (num > 0)
		{
			num--;
			z0eek_jiejie20260327142557(num);
		}
	}

	public z0ZzZzbsh z0eek_jiejie20260327142557(int p0)
	{
		if (p0 < 0 || p0 >= Count)
		{
			return null;
		}
		return (z0ZzZzbsh)z0ef(p0);
	}

	internal override z0ZzZzoah z0rf(int p0, z0ZzZzoah p1)
	{
		z0ZzZzoah result = base.z0rf(p0, p1);
		z0pek((z0ZzZzbsh)p1);
		return result;
	}

	public z0ZzZzbsh z0eek_jiejie20260327142557(string p0)
	{
		int num = z0ZzZzyah.z0eek(p0);
		for (int i = 0; i < base.z0tek.z0eek(); i++)
		{
			z0ZzZzbsh z0ZzZzbsh2 = (z0ZzZzbsh)base.z0tek.z0eek(i);
			if (num == z0ZzZzbsh2.z0yek() && p0 == z0ZzZzbsh2.z0th())
			{
				return z0ZzZzbsh2;
			}
		}
		return null;
	}

	internal z0ZzZzbsh z0rek(z0ZzZzbsh p0)
	{
		z0ZzZzoah obj = base.z0wf(p0);
		z0pek(p0);
		return (z0ZzZzbsh)obj;
	}

	internal new int z0tek(z0ZzZzbsh p0)
	{
		int num = z0eek(p0.z0ph(), p0.z0ag());
		if (num != -1)
		{
			z0ZzZzbsh p1 = (z0ZzZzbsh)base.z0tek.z0eek(num);
			base.z0ef(num);
			z0iek(p1);
		}
		return num;
	}

	internal new int z0yek(z0ZzZzbsh p0)
	{
		for (int i = 0; i < base.z0tek.z0eek(); i++)
		{
			z0ZzZzbsh z0ZzZzbsh2 = (z0ZzZzbsh)base.z0tek.z0eek(i);
			if (z0ZzZzbsh2.z0yek() == p0.z0yek() && z0ZzZzbsh2.z0ph() == p0.z0ph() && z0ZzZzbsh2.z0ag() == p0.z0ag())
			{
				return i;
			}
		}
		return -1;
	}

	internal static void z0uek(z0ZzZzbsh p0)
	{
		p0.z0tek().z0sg().z0eek_jiejie20260327142557(p0);
	}

	internal override z0ZzZzoah z0ef(int p0)
	{
		z0ZzZzoah z0ZzZzoah2 = base.z0ef(p0);
		z0iek((z0ZzZzbsh)z0ZzZzoah2);
		return z0ZzZzoah2;
	}

	internal z0ZzZzvsh(z0ZzZzoah p0)
		: base(p0)
	{
	}

	internal override z0ZzZzoah z0wf(z0ZzZzoah p0)
	{
		z0tek((z0ZzZzbsh)p0);
		z0ZzZzoah result = base.z0wf(p0);
		z0pek((z0ZzZzbsh)p0);
		return result;
	}

	private new object z0tek()
	{
		return this;
	}

	object ICollection.get_SyncRoot()
	{
		//ILSpy generated this explicit interface implementation from .override directive in z0tek
		return this.z0tek();
	}

	internal void z0iek(z0ZzZzbsh p0)
	{
		if (base.z0yek is z0ZzZzsah z0ZzZzsah2 && base.z0yek.z0wg() != null)
		{
			z0ZzZzyah z0ZzZzyah2 = base.z0yek.z0wg().z0eek(z0ZzZzsah2.z0yek());
			if (z0ZzZzyah2 != null && z0ZzZzyah2.z0oek() == p0.z0rek().z0oek() && z0ZzZzyah2.z0yek() == p0.z0rek().z0yek())
			{
				base.z0yek.z0wg().z0eek(p0.z0rh(), z0ZzZzsah2);
			}
		}
	}

	public z0ZzZzbsh z0oek(z0ZzZzbsh p0)
	{
		z0ZzZzfah z0ZzZzfah2 = p0.z0wg();
		if (z0ZzZzfah2 == null || !z0ZzZzfah2.z0yek())
		{
			if (z0ZzZzfah2 != null && z0ZzZzfah2 != base.z0yek.z0wg())
			{
				throw new ArgumentException("NamedNode_Context");
			}
			if (p0.z0tek() != null)
			{
				z0uek(p0);
			}
			z0wf(p0);
		}
		else
		{
			base.z0eek(p0, z0ZzZzfah2);
			z0pek(p0);
		}
		return p0;
	}

	private new bool z0yek()
	{
		return false;
	}

	bool ICollection.get_IsSynchronized()
	{
		//ILSpy generated this explicit interface implementation from .override directive in z0yek
		return this.z0yek();
	}

	public z0ZzZzbsh z0eek_jiejie20260327142557(string p0, string p1)
	{
		int num = z0ZzZzyah.z0eek(p0);
		for (int i = 0; i < base.z0tek.z0eek(); i++)
		{
			z0ZzZzbsh z0ZzZzbsh2 = (z0ZzZzbsh)base.z0tek.z0eek(i);
			if (num == z0ZzZzbsh2.z0yek() && p0 == z0ZzZzbsh2.z0ph() && p1 == z0ZzZzbsh2.z0ag())
			{
				return z0ZzZzbsh2;
			}
		}
		return null;
	}

	internal void z0pek(z0ZzZzbsh p0)
	{
		if (base.z0yek is z0ZzZzsah z0ZzZzsah2 && base.z0yek.z0wg() != null)
		{
			z0ZzZzyah z0ZzZzyah2 = base.z0yek.z0wg().z0eek(z0ZzZzsah2.z0yek());
			if (z0ZzZzyah2 != null && z0ZzZzyah2.z0oek() == p0.z0rek().z0oek() && z0ZzZzyah2.z0yek() == p0.z0rek().z0yek())
			{
				base.z0yek.z0wg().z0rek(p0.z0rh(), z0ZzZzsah2);
			}
		}
	}

	public z0ZzZzbsh z0rek(int p0)
	{
		try
		{
			return (z0ZzZzbsh)base.z0tek.z0eek(p0);
		}
		catch (ArgumentOutOfRangeException)
		{
			throw new IndexOutOfRangeException();
		}
	}

	internal void z0rek(string p0, string p1)
	{
		z0ZzZzsah p2 = base.z0yek as z0ZzZzsah;
		z0ZzZzfah obj = base.z0yek.z0wg();
		obj.z0eek(p0, p2);
		obj.z0rek(p1, p2);
	}

	private void z0eek_jiejie20260327142557(Array p0, int p1)
	{
		int num = 0;
		int count = Count;
		while (num < count)
		{
			p0.SetValue(base.z0tek.z0eek(num), p1);
			num++;
			p1++;
		}
	}

	void ICollection.CopyTo(Array p0, int p1)
	{
		//ILSpy generated this explicit interface implementation from .override directive in z0eek_jiejie20260327142557
		this.z0eek_jiejie20260327142557(p0, p1);
	}
}
