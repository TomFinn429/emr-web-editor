using System;

namespace zzz;

internal abstract class z0ZzZzukj : z0ZzZzwzk
{
	protected abstract void z0osk(z0ZzZzsgj p0, z0ZzZzjej p1);

	protected virtual double z0pak()
	{
		return 0.0;
	}

	public z0ZzZzywj z0iak(z0ZzZzywj p0, z0ZzZzywj p1)
	{
		double num = z0pak();
		if (num != 0.0)
		{
			double num2 = p1.z0eek() - p0.z0eek();
			double num3 = p1.z0rek() - p0.z0rek();
			double num4 = Math.Sqrt(num2 * num2 + num3 * num3);
			if (num4 != 0.0)
			{
				return new z0ZzZzywj(p0.z0eek() + num * num2 / num4, p0.z0rek() + num * num3 / num4);
			}
			return p0;
		}
		return p0;
	}

	public void z0uak(z0ZzZzsgj p0, z0ZzZzywj p1, z0ZzZzywj p2)
	{
		if (z0oak())
		{
			double num = p2.z0eek() - p1.z0eek();
			double num2 = p2.z0rek() - p1.z0rek();
			double num3 = Math.Sqrt(num * num + num2 * num2);
			if (num3 != 0.0)
			{
				num /= num3;
				num2 /= num3;
				z0osk(p0, new z0ZzZzjej(num, num2, 0.0 - num2, num, p1.z0eek(), p1.z0rek()));
			}
		}
	}

	protected virtual bool z0oak()
	{
		return true;
	}
}
