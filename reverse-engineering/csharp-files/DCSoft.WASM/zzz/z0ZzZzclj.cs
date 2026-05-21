using System;
using System.Collections.Generic;

namespace zzz;

internal abstract class z0ZzZzclj
{
	private readonly IDictionary<double, z0ZzZzbqj> z0rek = new Dictionary<double, z0ZzZzbqj>();

	protected abstract z0ZzZzbqj z0nsk(double p0);

	internal z0ZzZzbqj z0eek(double p0)
	{
		double num = Math.Round(p0, 4);
		if (!z0rek.TryGetValue(num, out var z0ZzZzbqj2))
		{
			z0ZzZzbqj2 = z0nsk(num);
			z0rek.Add(num, z0ZzZzbqj2);
		}
		return z0ZzZzbqj2;
	}
}
