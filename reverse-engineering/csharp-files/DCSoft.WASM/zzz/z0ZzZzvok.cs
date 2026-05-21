using DCSystem_Drawing;

namespace zzz;

public static class z0ZzZzvok
{
	public static Color z0eek(Color p0, Color p1, int p2, int p3)
	{
		p3 %= p2;
		if (p2 <= 1 || p3 == 0)
		{
			return p0;
		}
		int red = p0.R + (p1.R - p0.R) * p3 / (p2 - 1);
		int green = p0.G + (p1.G - p0.G) * p3 / (p2 - 1);
		int blue = p0.B + (p1.B - p0.B) * p3 / (p2 - 1);
		return Color.FromArgb(p0.A, red, green, blue);
	}

	public static Color z0eek(Color p0, float p1, int p2, int p3)
	{
		Color p4 = z0eek(p0, p1);
		return z0eek(p0, p4, p2, p3);
	}

	public static Color z0eek(Color p0, float p1)
	{
		if (p1 > 1f)
		{
			p1 = 1f;
		}
		if (p1 < -1f)
		{
			p1 = -1f;
		}
		if (p1 == 0f)
		{
			return p0;
		}
		float num = (int)p0.R;
		float num2 = (int)p0.G;
		float num3 = (int)p0.B;
		if (p1 < 0f)
		{
			p1 = 1f + p1;
			num *= p1;
			num2 *= p1;
			num3 *= p1;
		}
		else
		{
			num = (255f - num) * p1 + num;
			num2 = (255f - num2) * p1 + num2;
			num3 = (255f - num3) * p1 + num3;
		}
		return Color.FromArgb(p0.A, (int)num, (int)num2, (int)num3);
	}
}
