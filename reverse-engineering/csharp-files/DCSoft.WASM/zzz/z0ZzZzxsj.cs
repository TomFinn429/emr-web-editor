using System.Collections.Generic;

namespace zzz;

internal class z0ZzZzxsj
{
	private readonly z0ZzZzsgj z0uek;

	private void z0eek(IList<z0ZzZzzdj> p0, z0ZzZzddj p1, z0ZzZzlaj p2, bool p3, z0ZzZzbsj p4)
	{
		int num = p0?.Count ?? 0;
		if (num <= 0)
		{
			return;
		}
		z0ZzZzngj z0ZzZzngj2 = p1.z0tek();
		bool flag = z0ZzZzngj2.z0pek();
		double num2 = p1.z0eek();
		z0tek();
		z0ZzZzwdj z0ZzZzwdj2 = z0ZzZzngj2.z0iek();
		double num3 = z0tek(z0ZzZzwdj2).z0ldk(num2);
		double num4 = z0ZzZzwdj2.z0rek(num2);
		double num5 = p2.z0xfk(num);
		z0ZzZzjaj z0ZzZzjaj2 = p4.z0zfk(num5, num3, num);
		num5 -= num4;
		p2.z0cfk();
		bool num6 = z0ZzZzngj2.z0tek();
		z0uek.z0rek();
		z0uek.z0rek(z0ZzZzngj2.z0eek(), num2);
		double p5 = num2 / 30.0;
		if (num6)
		{
			z0uek.z0yek(p5);
			z0uek.z0rek((z0ZzZzzwj)2);
		}
		double num7 = 0.0;
		IList<z0ZzZzvsj> list = new List<z0ZzZzvsj>();
		bool flag2 = z0ZzZzngj2.z0uek() || z0ZzZzngj2.z0rek();
		int num8 = z0ZzZzjaj2.z0eek();
		double p6 = num5 - num3 * (double)num8;
		for (int i = num8; i < z0ZzZzjaj2.z0rek(); i++)
		{
			z0ZzZzzdj z0ZzZzzdj2 = p0[i];
			double num9 = p2.z0vfk(z0ZzZzzdj2);
			if (flag)
			{
				z0uek.z0rek(num9, num5 - num3 * (double)i);
			}
			else
			{
				z0uek.z0tek(num9 - num7, p6);
			}
			p6 = 0.0 - num3;
			if (!z0ZzZzzdj2.z0rek())
			{
				p2.z0eek(z0ZzZzzdj2, p3);
				if (flag2)
				{
					double num10 = z0ZzZzwdj2.z0tek(num2);
					double p7 = num9 + p2.z0rek().z0eek(z0ZzZzzdj2);
					double num11 = num5 - num3 * (double)i;
					if (z0ZzZzngj2.z0uek())
					{
						double p8 = num11 - num10 / 2.0;
						list.Add(new z0ZzZzvsj(new z0ZzZzywj(num9, p8), new z0ZzZzywj(p7, p8)));
					}
					if (z0ZzZzngj2.z0rek())
					{
						double p9 = num11 + num4 / 2.0 - num10;
						list.Add(new z0ZzZzvsj(new z0ZzZzywj(num9, p9), new z0ZzZzywj(p7, p9)));
					}
				}
			}
			num7 = (flag ? 0.0 : num9);
		}
		z0uek.z0pek();
		if (list.Count != 0)
		{
			z0uek.z0yek(p1.z0yek());
			foreach (z0ZzZzvsj item in list)
			{
				z0uek.z0rek(item.z0eek(), item.z0rek());
			}
		}
		z0yek();
	}

	internal void z0rek(IList<z0ZzZzzdj> p0, z0ZzZzddj p1, z0ZzZziwj p2, z0ZzZzcwj p3, bool p4, z0ZzZzbsj p5)
	{
		z0eek(p0, p1, new z0ZzZzzsj(z0uek, z0tek(p1, p3), p2), p4, p5);
	}

	protected virtual z0ZzZzcsj z0tek(z0ZzZzddj p0, z0ZzZzcwj p1)
	{
		return new z0ZzZzcsj(p0, p1);
	}

	protected virtual void z0tek()
	{
		z0uek.z0mek();
	}

	protected virtual void z0yek()
	{
		z0uek.z0tek();
	}

	internal z0ZzZzxsj(z0ZzZzsgj p0)
	{
		z0uek = p0;
	}

	protected virtual z0ZzZzxhj z0tek(z0ZzZzwdj p0)
	{
		return new z0ZzZzhsj(p0);
	}
}
