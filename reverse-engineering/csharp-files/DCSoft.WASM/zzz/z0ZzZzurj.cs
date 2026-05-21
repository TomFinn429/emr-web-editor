using DCSoft.Drawing;

namespace zzz;

public static class z0ZzZzurj
{
	public static z0ZzZzbdh z0eek(z0ZzZzvpk p0, z0ZzZzwrj p1, z0ZzZzbdh p2)
	{
		z0ZzZzarj z0ZzZzarj2 = new z0ZzZzarj(p1, p1: true);
		if (p0.z0eek() == PageBorderRangeTypes.Page)
		{
			float num = p0.PaddingLeft;
			if (num <= 0f)
			{
				num = z0ZzZzarj2.z0bek() / 2f;
			}
			float num2 = p0.PaddingTop;
			if (num2 <= 0f)
			{
				num2 = z0ZzZzarj2.z0pek() / 2f;
			}
			float num3 = p0.PaddingRight;
			if (num3 <= 0f)
			{
				num3 = z0ZzZzarj2.z0cek() / 2f;
			}
			float num4 = p0.PaddingBottom;
			if (num4 <= 0f)
			{
				num4 = z0ZzZzarj2.z0mek() / 2f;
			}
			return new z0ZzZzbdh(num, num2, z0ZzZzarj2.z0xek() - num - num3, z0ZzZzarj2.z0nek() - num2 - num4);
		}
		if (p0.z0eek() == PageBorderRangeTypes.Body)
		{
			z0ZzZzbdh result = new z0ZzZzbdh(z0ZzZzarj2.z0bek(), z0ZzZzarj2.z0pek(), z0ZzZzarj2.z0xek() - z0ZzZzarj2.z0bek() - z0ZzZzarj2.z0cek(), z0ZzZzarj2.z0nek() - z0ZzZzarj2.z0pek() - z0ZzZzarj2.z0mek());
			if (!p2.z0bek())
			{
				result = p2;
				result.z0rek(p2.z0yek());
				result.z0yek(p2.z0iek());
			}
			return result;
		}
		return z0ZzZzbdh.z0xek;
	}
}
