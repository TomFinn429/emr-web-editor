using System.Collections.Generic;

namespace zzz;

public class z0ZzZzooj : z0ZzZzegh
{
	public override z0ZzZzoah z0rlk(z0ZzZzoah p0, string p1)
	{
		if (p0 == null || !p0.z0rek() || p1 == null || p1.Length == 0)
		{
			return null;
		}
		foreach (z0ZzZzoah item in p0.z0tek())
		{
			if (z0eek(item, p1))
			{
				return item;
			}
			if (item.z0rek())
			{
				z0ZzZzoah z0ZzZzoah3 = z0rlk(item, p1);
				if (z0ZzZzoah3 != null)
				{
					return z0ZzZzoah3;
				}
			}
		}
		return base.z0rlk(p0, p1);
	}

	private new bool z0eek(z0ZzZzoah p0, string p1)
	{
		bool result = false;
		if (p1 == p0.z0th())
		{
			return true;
		}
		if (!p1.Contains(p0.z0th()))
		{
			return false;
		}
		string[] array = p1.Split('/');
		z0ZzZzoah z0ZzZzoah2 = p0;
		for (int num = array.Length - 1; num >= 0; num--)
		{
			string text = array[num];
			if (z0ZzZzoah2.z0th() != text)
			{
				return false;
			}
			z0ZzZzoah2 = z0ZzZzoah2.z0oek;
		}
		return result;
	}

	public override List<z0ZzZzoah> z0elk(z0ZzZzoah p0, string p1)
	{
		if (p0 == null || !p0.z0rek() || p1 == null || p1.Length == 0)
		{
			return null;
		}
		List<z0ZzZzoah> list = new List<z0ZzZzoah>();
		foreach (z0ZzZzoah item in p0.z0tek())
		{
			if (z0eek(item, p1))
			{
				list.Add(item);
			}
			else if (item.z0rek())
			{
				List<z0ZzZzoah> list2 = z0elk(item, p1);
				if (list2 != null && list2.Count > 0)
				{
					list.AddRange(list2);
				}
			}
		}
		if (list.Count == 0)
		{
			return null;
		}
		return list;
	}
}
