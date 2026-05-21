using System.Collections.Generic;

namespace zzz;

internal class z0ZzZzsej : z0ZzZzqej
{
	private new readonly IList<z0ZzZzqej> z0eek;

	internal override z0ZzZzqej z0mgk(z0ZzZzqej p0)
	{
		z0eek.Add(p0);
		return this;
	}

	internal z0ZzZzsej(z0ZzZzqej p0, z0ZzZzqej p1)
		: this(new List<z0ZzZzqej>(2) { p0, p1 })
	{
	}

	internal override void z0pgk(z0ZzZzmlj p0)
	{
		foreach (z0ZzZzqej item in z0eek)
		{
			item.z0pgk(p0);
		}
	}

	internal override z0ZzZzbdh z0ogk(z0ZzZzjdh p0)
	{
		z0ZzZzbdh z0ZzZzbdh2 = z0eek[0].z0ogk(p0);
		foreach (z0ZzZzqej item in z0ZzZzlxk.z0yek(z0eek, 1))
		{
			z0ZzZzbdh2 = z0ZzZzbdh.z0tek(z0ZzZzbdh2, item.z0ogk(p0));
		}
		return z0ZzZzbdh2;
	}

	private z0ZzZzsej(IList<z0ZzZzqej> p0)
	{
		z0eek = p0;
	}

	internal override z0ZzZzqej z0igk(z0ZzZzjdh p0)
	{
		IList<z0ZzZzqej> list = new List<z0ZzZzqej>(z0eek.Count);
		foreach (z0ZzZzqej item in z0eek)
		{
			list.Add(item.z0igk(p0));
		}
		return new z0ZzZzsej(list);
	}

	internal override z0ZzZzqej z0ugk()
	{
		z0ZzZzsej z0ZzZzsej2 = new z0ZzZzsej(new List<z0ZzZzqej>());
		if (z0eek != null)
		{
			foreach (z0ZzZzqej item in z0eek)
			{
				z0ZzZzsej2.z0eek.Add(item.z0ugk());
			}
		}
		return z0ZzZzsej2;
	}
}
