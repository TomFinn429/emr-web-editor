using System.Collections.Generic;

namespace zzz;

internal class z0ZzZztjj : z0ZzZzkkj
{
	private new readonly IEnumerable<z0ZzZzjkj> z0eek;

	protected override void z0msk(z0ZzZzsgj p0)
	{
		base.z0msk(p0);
		double num = z0isk() / 8.0;
		foreach (z0ZzZzjkj item in z0eek)
		{
			p0.z0oek(new z0ZzZziwj((double)item.z0eek() * num, (double)item.z0rek() * num, (double)item.z0tek() * num, (double)item.z0yek() * num));
		}
	}

	internal z0ZzZztjj(z0ZzZzsxk p0, IEnumerable<z0ZzZzjkj> p1)
		: base(p0)
	{
		z0eek = p1;
	}
}
