using System;
using System.Collections.Generic;

namespace zzz;

public static class z0ZzZzzik
{
	public static string z0eek(string p0)
	{
		if (p0 != null && p0.Length > 0)
		{
			int num = p0.IndexOf("?>", 0, Math.Min(100, p0.Length), StringComparison.Ordinal);
			num = ((num > 0) ? (num + 2) : 0);
			int num2 = p0.IndexOf('<', num, Math.Min(100, p0.Length - num));
			if (num2 > 0)
			{
				return p0.Substring(num2).Trim();
			}
		}
		return p0;
	}

	public static z0ZzZzoah z0eek(z0ZzZzoah p0, string p1, int p2)
	{
		if (p2 != 0 && p2 != 1 && p2 != 2)
		{
			throw new ArgumentException("Create参数无效");
		}
		if (p0 == null)
		{
			throw new ArgumentNullException("RootNode");
		}
		if (p1 == null)
		{
			throw new ArgumentNullException("strPath");
		}
		if (z0ZzZzcah.z0eek(p1))
		{
			if (p2 == 0 || p2 == 1)
			{
				foreach (z0ZzZzoah item in p0.z0tek())
				{
					if (item.z0th() == p1)
					{
						return item;
					}
				}
			}
			if (p2 == 1 || p2 == 2)
			{
				z0ZzZzsah z0ZzZzsah2 = p0.z0wg().z0rek(p1);
				p0.z0if(z0ZzZzsah2);
				return z0ZzZzsah2;
			}
		}
		z0ZzZzoah z0ZzZzoah3 = null;
		if (p2 == 0 || p2 == 1)
		{
			z0ZzZzoah3 = p0.z0eek(p1);
			if (z0ZzZzoah3 != null)
			{
				return z0ZzZzoah3;
			}
			if (p2 == 0)
			{
				return null;
			}
		}
		string[] array = p1.Split('/');
		for (int i = 0; i < array.Length; i++)
		{
			string text = array[i];
			text = text.Trim();
			if (text.StartsWith("@"))
			{
				text = text.Substring(1);
				text = text.Trim();
			}
			if (!z0ZzZzcah.z0eek(text))
			{
				return null;
			}
		}
		z0ZzZzfah z0ZzZzfah2 = p0.z0wg();
		for (int j = 0; j < array.Length; j++)
		{
			string text2 = array[j];
			text2 = text2.Trim();
			if (text2.StartsWith("@"))
			{
				if (p0.z0sg() == null)
				{
					return null;
				}
				string text3 = text2.Substring(1);
				text3 = text3.Trim();
				z0ZzZzoah3 = p0.z0sg().z0eek_jiejie20260327142557(text3);
				if (z0ZzZzoah3 == null)
				{
					z0ZzZzoah3 = z0ZzZzfah2.z0uek(text3);
					p0.z0sg().z0oek((z0ZzZzbsh)z0ZzZzoah3);
					break;
				}
				continue;
			}
			bool flag = false;
			if (j != array.Length - 1 || p2 == 1)
			{
				foreach (z0ZzZzoah item2 in p0.z0tek())
				{
					if (item2.z0th() == text2)
					{
						z0ZzZzoah3 = item2;
						p0 = z0ZzZzoah3;
						flag = true;
						break;
					}
				}
			}
			if (!flag)
			{
				z0ZzZzoah3 = z0ZzZzfah2.z0rek(text2);
				p0.z0if(z0ZzZzoah3);
				p0 = z0ZzZzoah3;
			}
		}
		return z0ZzZzoah3;
	}

	public static z0ZzZzoah z0eek(this z0ZzZzoah p0, string p1)
	{
		return z0ZzZzegh.z0eek.z0rlk(p0, p1);
	}

	public static List<z0ZzZzoah> z0rek(this z0ZzZzoah p0, string p1)
	{
		return z0ZzZzegh.z0eek.z0elk(p0, p1);
	}
}
