using System;
using System.Collections.Generic;
using System.Globalization;

namespace zzz;

public class z0ZzZzdpj
{
	private static z0ZzZzdpj[] z0uek;

	private float z0iek = 9f;

	private static z0ZzZzdpj[] z0oek;

	private string z0pek;

	public override string ToString()
	{
		return z0pek;
	}

	public float z0eek()
	{
		return z0iek;
	}

	public static z0ZzZzdpj[] z0rek()
	{
		if (z0oek == null)
		{
			List<z0ZzZzdpj> list = new List<z0ZzZzdpj>();
			if (CultureInfo.CurrentUICulture.TwoLetterISOLanguageName == "zh")
			{
				list.Add(new z0ZzZzdpj("初号", 42f));
				list.Add(new z0ZzZzdpj("小初", 36f));
				list.Add(new z0ZzZzdpj("一号", 26.25f));
				list.Add(new z0ZzZzdpj("小一", 24f));
				list.Add(new z0ZzZzdpj("二号", 21.75f));
				list.Add(new z0ZzZzdpj("小二", 18f));
				list.Add(new z0ZzZzdpj("三号", 15.75f));
				list.Add(new z0ZzZzdpj("小三", 15f));
				list.Add(new z0ZzZzdpj("四号", 14.25f));
				list.Add(new z0ZzZzdpj("小四", 12f));
				list.Add(new z0ZzZzdpj("五号", 10.5f));
				list.Add(new z0ZzZzdpj("小五", 9f));
				list.Add(new z0ZzZzdpj("六号", 7.5f));
				list.Add(new z0ZzZzdpj("小六", 6.75f));
				list.Add(new z0ZzZzdpj("七号", 5.25f));
				list.Add(new z0ZzZzdpj("八号", 4.5f));
			}
			list.Add(new z0ZzZzdpj(8f));
			list.Add(new z0ZzZzdpj(9f));
			list.Add(new z0ZzZzdpj(10f));
			list.Add(new z0ZzZzdpj(11f));
			list.Add(new z0ZzZzdpj(12f));
			list.Add(new z0ZzZzdpj(14f));
			list.Add(new z0ZzZzdpj(16f));
			list.Add(new z0ZzZzdpj(18f));
			list.Add(new z0ZzZzdpj(20f));
			list.Add(new z0ZzZzdpj(22f));
			list.Add(new z0ZzZzdpj(24f));
			list.Add(new z0ZzZzdpj(26f));
			list.Add(new z0ZzZzdpj(28f));
			list.Add(new z0ZzZzdpj(36f));
			list.Add(new z0ZzZzdpj(48f));
			list.Add(new z0ZzZzdpj(72f));
			z0oek = list.ToArray();
		}
		return z0oek;
	}

	public z0ZzZzdpj(string p0, float p1)
	{
		z0pek = p0;
		z0iek = p1;
	}

	public static float z0eek(string p0, float p1)
	{
		z0ZzZzdpj[] array = z0rek();
		foreach (z0ZzZzdpj z0ZzZzdpj2 in array)
		{
			if (string.Compare(p0, z0ZzZzdpj2.z0yek(), true) == 0)
			{
				return z0ZzZzdpj2.z0eek();
			}
		}
		float result = 0f;
		if (float.TryParse(p0, out result))
		{
			return result;
		}
		return p1;
	}

	public static z0ZzZzdpj[] z0tek()
	{
		if (z0uek == null)
		{
			z0uek = new List<z0ZzZzdpj>
			{
				new z0ZzZzdpj(8f),
				new z0ZzZzdpj(9f),
				new z0ZzZzdpj(10f),
				new z0ZzZzdpj(11f),
				new z0ZzZzdpj(12f),
				new z0ZzZzdpj(14f),
				new z0ZzZzdpj(16f),
				new z0ZzZzdpj(18f),
				new z0ZzZzdpj(20f),
				new z0ZzZzdpj(22f),
				new z0ZzZzdpj(24f),
				new z0ZzZzdpj(26f),
				new z0ZzZzdpj(28f),
				new z0ZzZzdpj(36f),
				new z0ZzZzdpj(48f),
				new z0ZzZzdpj(72f)
			}.ToArray();
		}
		return z0uek;
	}

	public void z0eek(string p0)
	{
		z0pek = p0;
	}

	public void z0eek(float p0)
	{
		z0iek = p0;
	}

	public z0ZzZzdpj(float p0)
	{
		z0pek = p0.ToString();
		z0iek = p0;
	}

	public string z0yek()
	{
		return z0pek;
	}

	public static string z0eek(float p0, bool p1)
	{
		if (p1)
		{
			z0ZzZzdpj[] array = z0rek();
			foreach (z0ZzZzdpj z0ZzZzdpj2 in array)
			{
				if ((double)Math.Abs(p0 - z0ZzZzdpj2.z0eek()) < 0.01)
				{
					return z0ZzZzdpj2.z0yek();
				}
			}
		}
		else
		{
			z0ZzZzdpj[] array = z0tek();
			foreach (z0ZzZzdpj z0ZzZzdpj3 in array)
			{
				if ((double)Math.Abs(p0 - z0ZzZzdpj3.z0eek()) < 0.01)
				{
					return z0ZzZzdpj3.z0yek();
				}
			}
		}
		return p0.ToString();
	}
}
