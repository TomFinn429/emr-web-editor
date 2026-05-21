using System;

namespace zzz;

internal class z0ZzZzkaj
{
	private bool z0tek;

	private z0ZzZzzdj z0yek;

	private readonly double z0uek;

	private readonly z0ZzZzngj z0iek;

	private z0ZzZzzdj z0eek(string p0)
	{
		z0ZzZzcdj z0ZzZzcdj2 = (z0ZzZzcdj)0;
		if (z0tek)
		{
			z0ZzZzcdj2 |= (z0ZzZzcdj)2;
		}
		z0ZzZzcdj2 |= (z0ZzZzcdj)1;
		return z0iek.z0eek(p0, z0ZzZzcdj2);
	}

	internal z0ZzZzzdj z0rek(string p0)
	{
		if (string.IsNullOrEmpty(p0.Trim()))
		{
			return z0eek(p0);
		}
		z0yek = null;
		int num = 0;
		string[] array = p0.Split('\t');
		if (z0tek)
		{
			Array.Reverse(array);
		}
		string[] array2 = array;
		foreach (string text in array2)
		{
			if (string.IsNullOrEmpty(text))
			{
				num++;
				continue;
			}
			z0eek(text, num);
			num = 1;
		}
		return z0yek;
	}

	private void z0eek(string p0, int p1)
	{
		z0ZzZzzdj z0ZzZzzdj2 = z0eek(p0);
		if (z0uek != 0.0)
		{
			z0ZzZzndj z0ZzZzndj2 = z0ZzZzzdj2.z0eek()[0];
			double num = ((z0yek != null) ? z0yek.z0yek() : 0.0);
			double num2 = (double)((int)(num / z0uek) + p1) * z0uek - num;
			z0ZzZzzdj2.z0eek()[0] = new z0ZzZzndj(z0ZzZzndj2.z0eek(), z0ZzZzndj2.z0tek(), 0.0 - num2);
		}
		if (z0yek == null)
		{
			z0yek = z0ZzZzzdj2;
		}
		else
		{
			z0yek.z0eek(z0ZzZzzdj2);
		}
	}

	internal z0ZzZzkaj(z0ZzZzngj p0, double p1, bool p2, bool p3)
	{
		z0iek = p0;
		z0uek = p1;
		z0tek = p2;
	}
}
