using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using DCSoft.Writer.Dom;

namespace zzz;

[DefaultMember("Item")]
public sealed class z0ZzZzblh : IEnumerable<z0ZzZznlh>, IEnumerable
{
	private List<z0ZzZznlh> z0yek = new List<z0ZzZznlh>();

	private IEnumerator z0eek()
	{
		return z0yek.GetEnumerator();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		//ILSpy generated this explicit interface implementation from .override directive in z0eek
		return this.z0eek();
	}

	internal z0ZzZzblh(XTextElementList p0)
	{
		int count = p0.Count;
		int num = p0[0].z0jrk();
		int num2 = num;
		for (int i = 1; i < count; i++)
		{
			int num3 = p0[i].z0jrk();
			if (num3 > num2 + 1)
			{
				z0yek.Add(new z0ZzZznlh(num, num2 - num));
				num = num3;
				num2 = num;
			}
			num2++;
		}
		if (num2 > num)
		{
			z0yek.Add(new z0ZzZznlh(num, num2 - num));
		}
	}

	public bool z0eek(int p0, int p1)
	{
		if (p0 > p1)
		{
			int num = p1;
			p1 = p0;
			p0 = num;
		}
		foreach (z0ZzZznlh item in z0yek)
		{
			if (p0 <= item.z0yek && p1 >= item.z0uek)
			{
				return true;
			}
		}
		return false;
	}

	public z0ZzZznlh z0eek(int p0)
	{
		return z0yek[p0];
	}

	internal void z0rek()
	{
		if (z0yek != null)
		{
			z0yek.Clear();
			z0yek = null;
		}
	}

	public int z0tek()
	{
		return z0yek.Count;
	}

	public IEnumerator<z0ZzZznlh> GetEnumerator()
	{
		return z0yek.GetEnumerator();
	}
}
