using System.Collections.Generic;

namespace zzz;

internal abstract class z0ZzZzdlj : z0ZzZzdkj
{
	private new readonly IList<z0ZzZzuwj> z0rek;

	private new readonly z0ZzZzhqj z0tek;

	private static readonly z0ZzZzuwj[] z0yek = new z0ZzZzuwj[1]
	{
		new z0ZzZzuwj(0.0, 1.0)
	};

	protected z0ZzZzdlj(z0ZzZzedh p0)
		: base(p0)
	{
		z0tek = (z0ZzZzhqj)1;
		z0rek = z0eek();
	}

	protected abstract z0ZzZzaqj z0hak();

	internal override z0ZzZzfej z0aak()
	{
		byte[] array = z0gak();
		z0ZzZzcqj z0ZzZzcqj2 = null;
		int num = z0tek();
		int p = z0rek();
		return new z0ZzZzcqj(p6: (array != null) ? new z0ZzZzcqj(num, p, new z0ZzZzjqj((z0ZzZzhqj)0), 8, z0yek, new z0ZzZzkgj(new z0ZzZzaqj[1]
		{
			new z0ZzZzqqj((z0ZzZzeqj)12, 1, 8, num)
		}, z0ZzZzlfj.z0eek(array)), null) : null, p0: num, p1: p, p2: new z0ZzZzjqj(z0tek), p3: 8, p4: z0rek, p5: new z0ZzZzkgj(new z0ZzZzaqj[1] { z0hak() }, z0jak()));
	}

	protected abstract byte[] z0jak();

	protected abstract byte[] z0gak();

	protected static z0ZzZzuwj[] z0eek()
	{
		return new z0ZzZzuwj[3]
		{
			new z0ZzZzuwj(0.0, 1.0),
			new z0ZzZzuwj(0.0, 1.0),
			new z0ZzZzuwj(0.0, 1.0)
		};
	}

	protected z0ZzZzdlj(int p0, int p1, z0ZzZzhqj p2, IList<z0ZzZzuwj> p3)
		: base(p0, p1)
	{
		z0tek = p2;
		z0rek = p3;
	}
}
