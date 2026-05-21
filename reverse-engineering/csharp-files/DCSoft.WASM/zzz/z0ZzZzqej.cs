using System;

namespace zzz;

internal abstract class z0ZzZzqej
{
	internal static z0ZzZzqej z0eek(z0ZzZzbdh p0, z0ZzZzjdh p1)
	{
		bool flag = p1.z0iek();
		if (flag)
		{
			return new z0ZzZzdej(p0);
		}
		float[] array = p1.z0yek();
		if (z0eek(array[0] - 1f) && z0eek(array[1]) && z0eek(array[2]) && z0eek(array[3] - 1f))
		{
			p0.z0tek(array[4], array[5]);
			return new z0ZzZzdej(p0);
		}
		z0ZzZzpdh[] p2 = z0eek(p0);
		p1.z0eek(p2);
		if (flag || z0eek(p1))
		{
			return new z0ZzZzdej(z0eek(p2));
		}
		byte[] p3 = new byte[4] { 0, 1, 1, 129 };
		return new z0ZzZzeej(p2, p3, p2: true);
	}

	internal static bool z0eek(z0ZzZzjdh p0)
	{
		float[] array = p0.z0yek();
		if (!z0eek(array[0]) || !z0eek(array[3]))
		{
			if (z0eek(array[1]))
			{
				return z0eek(array[2]);
			}
			return false;
		}
		return true;
	}

	protected static z0ZzZzbdh z0eek(z0ZzZzpdh[] p0)
	{
		float num = 3.4028235E+38f;
		float num2 = 3.4028235E+38f;
		float num3 = -3.4028235E+38f;
		float num4 = -3.4028235E+38f;
		for (int i = 0; i < p0.Length; i++)
		{
			z0ZzZzpdh z0ZzZzpdh2 = p0[i];
			num = Math.Min(num, z0ZzZzpdh2.z0rek());
			num2 = Math.Min(num2, z0ZzZzpdh2.z0tek());
			num3 = Math.Max(num3, z0ZzZzpdh2.z0rek());
			num4 = Math.Max(num4, z0ZzZzpdh2.z0tek());
		}
		return z0ZzZzbdh.z0eek(num, num2, num3, num4);
	}

	internal abstract z0ZzZzqej z0igk(z0ZzZzjdh p0);

	protected static z0ZzZzpdh[] z0eek(z0ZzZzbdh p0)
	{
		return new z0ZzZzpdh[4]
		{
			new z0ZzZzpdh(p0.z0oek(), p0.z0pek()),
			new z0ZzZzpdh(p0.z0mek(), p0.z0pek()),
			new z0ZzZzpdh(p0.z0mek(), p0.z0nek()),
			new z0ZzZzpdh(p0.z0oek(), p0.z0nek())
		};
	}

	internal abstract z0ZzZzqej z0mgk(z0ZzZzqej p0);

	internal abstract z0ZzZzbdh z0ogk(z0ZzZzjdh p0);

	internal abstract void z0pgk(z0ZzZzmlj p0);

	internal abstract z0ZzZzqej z0ugk();

	private static bool z0eek(double p0)
	{
		return Math.Abs(p0) < 1E-06;
	}
}
