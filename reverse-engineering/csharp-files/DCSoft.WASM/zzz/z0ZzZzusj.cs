using System.Collections;
using System.Collections.Generic;

namespace zzz;

internal class z0ZzZzusj : z0ZzZzswj, IEnumerable<z0ZzZzgwj>, IEnumerable
{
	private new readonly int z0yek;

	private IList<z0ZzZzswj> z0iek;

	internal void z0eek(z0ZzZzgwj p0)
	{
		z0iek.Remove(p0);
	}

	internal z0ZzZzusj(z0ZzZzugj p0, z0ZzZziwj p1, z0ZzZziwj p2, int p3, IEnumerable<z0ZzZzgwj> p4)
		: base(p0, p1, p2, p3)
	{
		z0iek = new List<z0ZzZzswj>();
		foreach (z0ZzZzgwj item in p4)
		{
			z0iek.Add(item);
			item.z0eek(this);
		}
		z0yek = z0iek.Count;
	}

	private new IEnumerator z0eek()
	{
		return ((IEnumerable<z0ZzZzgwj>)this).GetEnumerator();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		//ILSpy generated this explicit interface implementation from .override directive in z0eek
		return this.z0eek();
	}

	protected internal override object z0ngk(z0ZzZzdsj p0)
	{
		object obj = base.z0ngk(p0);
		if (obj is z0ZzZzeaj z0ZzZzeaj2)
		{
			z0ZzZzeaj2.z0yek("Type", "Pages");
			z0ZzZzeaj2.Add("Count", z0iek.Count);
			z0ZzZzeaj2.Add("Kids", new z0ZzZzwaj(z0iek, p0));
		}
		return obj;
	}

	private new IEnumerator<z0ZzZzgwj> z0rek()
	{
		foreach (z0ZzZzswj item in z0iek)
		{
			if (!(item is z0ZzZzgwj z0ZzZzgwj2))
			{
				z0ZzZzusj z0ZzZzusj2 = item as z0ZzZzusj;
				if (z0ZzZzusj2 == null)
				{
					z0ZzZzlxk.z0yek();
				}
				foreach (z0ZzZzgwj item2 in (IEnumerable<z0ZzZzgwj>)z0ZzZzusj2)
				{
					yield return item2;
				}
			}
			else
			{
				yield return z0ZzZzgwj2;
			}
		}
	}

	IEnumerator<z0ZzZzgwj> IEnumerable<z0ZzZzgwj>.GetEnumerator()
	{
		//ILSpy generated this explicit interface implementation from .override directive in z0rek
		return this.z0rek();
	}
}
