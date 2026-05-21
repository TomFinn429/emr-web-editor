using System;
using DCSystem_Drawing;

namespace zzz;

public struct z0ZzZzypk
{
	private readonly int z0tek;

	private readonly int z0yek;

	private readonly int z0uek;

	public z0ZzZzypk(Color p0)
	{
		int r = p0.R;
		int g = p0.G;
		int b = p0.B;
		int num = Math.Max(Math.Max(r, g), b);
		int num2 = Math.Min(Math.Min(r, g), b);
		int num3 = num + num2;
		z0uek = (num3 * 240 + 255) / 510;
		int num4 = num - num2;
		if (num4 == 0)
		{
			z0yek = 0;
			z0tek = 160;
			return;
		}
		if (z0uek <= 120)
		{
			z0yek = (num4 * 240 + num3 / 2) / num3;
		}
		else
		{
			z0yek = (num4 * 240 + (510 - num3) / 2) / (510 - num3);
		}
		int num5 = ((num - r) * 40 + num4 / 2) / num4;
		int num6 = ((num - g) * 40 + num4 / 2) / num4;
		int num7 = ((num - b) * 40 + num4 / 2) / num4;
		if (r == num)
		{
			z0tek = num7 - num6;
		}
		else if (g == num)
		{
			z0tek = 80 + num5 - num7;
		}
		else
		{
			z0tek = 160 + num6 - num5;
		}
		if (z0tek < 0)
		{
			z0tek += 240;
		}
		if (z0tek > 240)
		{
			z0tek -= 240;
		}
	}

	public Color z0eek(float p0)
	{
		int num = 0;
		int num2 = z0eek(-333, p1: true);
		return z0eek(z0tek, num2 - (int)((float)(num2 - num) * p0), z0yek);
	}

	public Color z0rek(float p0)
	{
		int num = z0uek;
		int num2 = z0eek(500, p1: true);
		return z0eek(z0tek, num + (int)((float)(num2 - num) * p0), z0yek);
	}

	private int z0eek(int p0, bool p1)
	{
		return z0eek(z0uek, p0, p1);
	}

	private int z0eek(int p0, int p1, bool p2)
	{
		if (p1 == 0)
		{
			return p0;
		}
		if (p2)
		{
			if (p1 > 0)
			{
				return (int)((p0 * (1000 - p1) + 241L * (long)p1) / 1000);
			}
			return p0 * (p1 + 1000) / 1000;
		}
		int num = p0;
		num += (int)((long)p1 * 240L / 1000);
		if (num < 0)
		{
			num = 0;
		}
		if (num > 240)
		{
			num = 240;
		}
		return num;
	}

	private Color z0eek(int p0, int p1, int p2)
	{
		byte red;
		byte green;
		byte blue;
		if (p2 == 0)
		{
			red = (green = (blue = (byte)(p1 * 255 / 240)));
			if (p0 != 160)
			{
			}
		}
		else
		{
			int num = ((p1 > 120) ? (p1 + p2 - (p1 * p2 + 120) / 240) : ((p1 * (240 + p2) + 120) / 240));
			int p3 = 2 * p1 - num;
			red = (byte)((z0rek(p3, num, p0 + 80) * 255 + 120) / 240);
			green = (byte)((z0rek(p3, num, p0) * 255 + 120) / 240);
			blue = (byte)((z0rek(p3, num, p0 - 80) * 255 + 120) / 240);
		}
		return Color.FromArgb(red, green, blue);
	}

	private int z0rek(int p0, int p1, int p2)
	{
		if (p2 < 0)
		{
			p2 += 240;
		}
		if (p2 > 240)
		{
			p2 -= 240;
		}
		if (p2 < 40)
		{
			return p0 + ((p1 - p0) * p2 + 20) / 40;
		}
		if (p2 < 120)
		{
			return p1;
		}
		if (p2 < 160)
		{
			return p0 + ((p1 - p0) * (160 - p2) + 20) / 40;
		}
		return p0;
	}
}
