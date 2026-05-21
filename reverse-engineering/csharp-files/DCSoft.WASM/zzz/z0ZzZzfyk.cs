using System;
using DCSoft.Chart;

namespace zzz;

internal class z0ZzZzfyk
{
	private double z0oek;

	private double z0pek;

	private RangeCalculateStyle z0mek;

	private double z0nek = 1.0;

	private bool z0bek;

	private static void z0eek(double p0, ref int p1, ref double p2)
	{
		p1 = 0;
		if (p0 == 0.0)
		{
			p2 = 0.0;
			return;
		}
		p2 = Math.Abs(p0);
		while (p2 <= 10.0 || p2 > 100.0)
		{
			if (p2 <= 10.0)
			{
				p2 *= 10.0;
				p1--;
			}
			else
			{
				p2 /= 10.0;
				p1++;
			}
		}
		if (z0ZzZzbok.z0eek(p0))
		{
			p0 = 0.0;
		}
		p2 = (double)Math.Sign(p0) * p2;
	}

	private static int z0eek(ref double p0, ref double p1, RangeCalculateStyle p2)
	{
		double num = 0.0;
		int num2 = 0;
		int p3 = 0;
		if (p0 < p1)
		{
			num = p0;
			p0 = p1;
			p1 = num;
		}
		if (p1 == p0)
		{
			p1 = ((p1 > 0.0) ? 0.0 : p1);
			p0 = ((p0 < 0.0) ? 0.0 : p0);
		}
		if (p1 == 0.0 && p0 == 0.0)
		{
			p0 = 1.0;
		}
		num = Math.Abs(p0 - p1);
		z0eek(num, ref p3, ref num);
		num2 = ((num > 50.0) ? 10 : ((!(num > 20.0)) ? 2 : 5));
		double num3 = Math.Pow(10.0, p3);
		double num4 = p0 / num3;
		num4 /= (double)num2;
		num4 = Math.Ceiling(num4);
		num4 *= (double)num2;
		num4 = Math.Ceiling(num4);
		num4 *= num3;
		double num5 = p1 / num3;
		num5 /= (double)num2;
		num5 = (int)Math.Floor(num5);
		num5 *= (double)num2;
		num5 *= num3;
		num = Math.Abs(num4 - num5);
		num /= (double)num2 * num3;
		int result = (int)Math.Ceiling(num);
		switch (p2)
		{
		case RangeCalculateStyle.AutoMaxValue:
			p0 = num4;
			return result;
		case RangeCalculateStyle.AutoMinValue:
			p1 = num5;
			return result;
		case RangeCalculateStyle.AutoMaxMinValue:
			p0 = num4;
			p1 = num5;
			break;
		}
		return result;
	}

	public double z0eek()
	{
		return z0oek;
	}

	public void z0rek()
	{
		double p = z0oek;
		double p2 = z0pek;
		int num = z0eek(ref p, ref p2, z0yek());
		bool flag = false;
		if (z0oek == p)
		{
			p = ((!(p > 0.0)) ? (p * 0.99) : (p * 1.01));
			flag = true;
		}
		if (z0pek == p2)
		{
			p2 = ((!(p2 > 0.0)) ? (p2 * 1.01) : (p2 * 0.99));
			flag = true;
		}
		if (flag)
		{
			num = z0eek(ref p, ref p2, z0yek());
		}
		z0oek = p;
		z0pek = p2;
		z0nek = (p - p2) / (double)num;
	}

	public double z0tek()
	{
		return z0nek;
	}

	public RangeCalculateStyle z0yek()
	{
		return z0mek;
	}

	public z0ZzZzfyk(double p0, double p1, RangeCalculateStyle p2)
	{
		z0oek = p0;
		z0pek = p1;
		z0mek = p2;
	}

	public double z0uek()
	{
		return z0pek;
	}

	public bool z0iek()
	{
		return z0bek;
	}

	public void z0eek(bool p0)
	{
		z0bek = p0;
	}
}
