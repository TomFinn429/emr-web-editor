using System;
using DCSystem_Drawing;

namespace zzz;

internal class z0ZzZzrkj : z0ZzZztzk
{
	private new readonly z0ZzZzaxk z0eek;

	internal z0ZzZzrkj(z0ZzZzaxk p0)
	{
		z0eek = p0;
	}

	internal override bool z0lak(z0ZzZzmlj p0, z0ZzZzbjj p1)
	{
		z0ZzZzgxk z0ZzZzgxk2 = z0eek.z0eek();
		if (((z0ZzZzrxk)z0eek).z0rek() == (z0ZzZzddh)4 || z0eek.z0tek() != null || (z0ZzZzgxk2 != null && z0ZzZzgxk2.z0rek().Length > 1))
		{
			return false;
		}
		z0ZzZziwj z0ZzZziwj2 = z0ZzZzgsj.z0rek(z0ZzZzjej.z0rek(z0ZzZztzk.z0eek(z0eek)).z0eek(p1.z0fak()));
		z0ZzZziwj obj = z0ZzZznlj.z0eek(z0eek.z0yek());
		double num = obj.z0oek();
		double num2 = obj.z0yek();
		double num3 = obj.z0eek();
		double num4 = obj.z0rek();
		double num5 = z0ZzZziwj2.z0oek() - num;
		double num6 = z0ZzZziwj2.z0yek() - num2;
		double num7 = Math.Floor(num5 / num3);
		double num8 = Math.Floor(num6 / num4);
		if (Math.Abs(num5 - num7 * num3 - num3) < 0.1)
		{
			num7 += 1.0;
		}
		if (Math.Abs(num6 - num8 * num4 - num4) < 0.1)
		{
			num8 += 1.0;
		}
		double num9 = num7 * num3 + num;
		double num10 = num8 * num4 + num2;
		Color[] array = z0eek.z0rek();
		if (z0ZzZziwj2.z0iek() - num9 - num3 < 0.1 && z0ZzZziwj2.z0mek() - num10 - num4 < 0.1)
		{
			Color p2 = array[0];
			Color p3 = array[1];
			byte a = p2.A;
			if (a == p3.A)
			{
				p0.z0yek((double)(int)a / 255.0);
			}
			z0ZzZzsgj z0ZzZzsgj2 = p0.z0tek();
			p0.z0pek();
			p1.z0dak(z0ZzZzsgj2);
			z0ZzZzsgj2.z0rek(z0ZzZzjej.z0rek(new z0ZzZzjej(num3, 0.0, 0.0, num4, num9, num10), z0ZzZztzk.z0eek(p0, z0eek)));
			z0ZzZzsgj2.z0rek(p0.z0rek().z0eek(p2, p3));
			p0.z0yek();
			return true;
		}
		return false;
	}

	internal override z0ZzZzshj z0usk(z0ZzZzmlj p0)
	{
		z0ZzZztkj z0ZzZztkj2 = z0ZzZztkj.z0eek(z0eek, p0.z0mek(), z0ZzZztzk.z0eek(p0, z0eek));
		return new z0ZzZzshj(z0ZzZztkj2.z0csk(), z0ZzZztkj2.z0tsk(p0));
	}
}
