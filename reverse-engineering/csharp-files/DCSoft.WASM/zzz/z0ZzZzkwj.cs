using System;
using System.Collections.Generic;

namespace zzz;

internal class z0ZzZzkwj
{
	private readonly double z0uek;

	private readonly double[] z0iek;

	internal double z0eek()
	{
		return z0uek;
	}

	internal static z0ZzZzkwj z0rek()
	{
		return new z0ZzZzkwj(null, 0.0);
	}

	private z0ZzZzkwj(double[] p0, double p1)
	{
		z0iek = p0;
		z0uek = p1;
	}

	internal static z0ZzZzkwj z0eek(double[] p0, double p1)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("dashPattern");
		}
		if (p0.Length == 0)
		{
			throw new ArgumentOutOfRangeException("dashPattern", "IncorrectDashPatternArraySize");
		}
		double num = 0.0;
		foreach (double num2 in p0)
		{
			num += num2;
		}
		if (num == 0.0)
		{
			throw new ArgumentOutOfRangeException("dashPattern", "IncorrectDashPattern");
		}
		return new z0ZzZzkwj(p0, p1);
	}

	internal double[] z0tek()
	{
		return z0iek;
	}

	internal static z0ZzZzkwj z0eek(double p0, double p1, double p2)
	{
		if (p0 < 0.0)
		{
			throw new ArgumentOutOfRangeException("dashLength", "IncorrectDashLength");
		}
		if (p1 < 0.0)
		{
			throw new ArgumentOutOfRangeException("gapLength", "IncorrectGapLength");
		}
		if (p0 + p1 == 0.0)
		{
			throw new ArgumentOutOfRangeException("IncorrectDashPattern");
		}
		return new z0ZzZzkwj(new double[2] { p0, p1 }, p2);
	}

	internal IList<object> z0yek()
	{
		int num = ((z0iek != null) ? z0iek.Length : 0);
		List<object> list = new List<object>(num);
		for (int i = 0; i < num; i++)
		{
			list.Add(z0iek[i]);
		}
		return new List<object> { list, z0uek };
	}
}
