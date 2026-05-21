using System;
using System.Collections.Generic;

namespace zzz;

internal class z0ZzZzgaj : z0ZzZzodj
{
	private new bool z0yek;

	private new IDictionary<int, z0ZzZzbdj> z0uek;

	private new int[] z0iek;

	internal static readonly string z0oek = "glyf";

	private readonly IDictionary<int, z0ZzZzbdj> z0pek = new Dictionary<int, z0ZzZzbdj>();

	protected override void z0ygk(bool p0)
	{
		base.z0ygk(p0);
		z0iek = null;
		z0pek.Clear();
		if (z0uek != null)
		{
			lock (this)
			{
				z0uek.Clear();
				z0uek = null;
			}
		}
	}

	private int[] z0rek(int p0)
	{
		lock (this)
		{
			int[] array = new int[p0 + 1];
			int num = 0;
			int i = 0;
			KeyValuePair<int, z0ZzZzbdj>[] array2 = z0ZzZzlxk.z0eek(z0uek);
			for (int j = 0; j < array2.Length; j++)
			{
				KeyValuePair<int, z0ZzZzbdj> keyValuePair = array2[j];
				for (int key = keyValuePair.Key; i <= key; i++)
				{
					array[i] = num;
				}
				num += z0tek(keyValuePair.Value.z0eek());
			}
			for (; i <= p0; i++)
			{
				array[i] = num;
			}
			return array;
		}
	}

	internal void z0rek(z0ZzZzzfj p0)
	{
		lock (this)
		{
			z0pek.Clear();
			z0ZzZzfaj z0ZzZzfaj2 = p0.z0oek();
			if (z0ZzZzfaj2 == null)
			{
				return;
			}
			z0ZzZzuxk z0ZzZzuxk2 = z0uek().z0pek();
			z0ZzZzuxk2.z0rek(0);
			int num = z0ZzZzuxk2.z0tek();
			z0iek = z0ZzZzfaj2.z0eek();
			int num2 = z0iek.Length - 1;
			List<int> list = new List<int>(z0iek);
			list.Sort();
			Dictionary<int, z0ZzZzbdj> dictionary = new Dictionary<int, z0ZzZzbdj>();
			int num3 = list[0];
			if (list[0] != z0iek[0])
			{
				z0yek = true;
			}
			int i = 0;
			int num4 = 1;
			for (; i < num2; i++)
			{
				int num5 = num3;
				int num6 = z0iek[num4];
				num3 = Math.Min(list[num4++], num);
				if (num3 != num6)
				{
					z0yek = true;
				}
				int num7 = num3 - num5;
				if (num7 >= 10)
				{
					z0ZzZzuxk2.z0rek(num5);
					z0ZzZzbdj z0ZzZzbdj2 = new z0ZzZzbdj(z0ZzZzuxk2, num7, num2);
					if (z0ZzZzbdj2.z0tek())
					{
						z0yek = true;
					}
					else
					{
						dictionary[num5] = z0ZzZzbdj2;
					}
				}
				else if (num7 != 0)
				{
					num3 = num5;
					z0yek = true;
				}
			}
			int num8 = z0iek[0];
			int num9 = 0;
			for (int j = 1; j <= num2; j++)
			{
				int num10 = z0iek[j];
				if (num10 - num8 != 0 && dictionary.TryGetValue(z0iek[num9], out var z0ZzZzbdj3))
				{
					z0pek.Add(num9, z0ZzZzbdj3);
				}
				num8 = num10;
				num9++;
			}
			z0uek = z0pek;
			z0iek = z0rek(num2);
			if (z0yek)
			{
				z0ZzZzfaj2.z0eek(z0iek);
				p0.z0xek()?.z0eek((short)num2);
			}
		}
	}

	private static int z0tek(int p0)
	{
		int num = p0 % 4;
		if (num != 0)
		{
			return p0 + 4 - num;
		}
		return p0;
	}

	protected override void z0bfk()
	{
		base.z0bfk();
		if (!z0yek)
		{
			return;
		}
		lock (this)
		{
			z0ZzZzjgj z0ZzZzjgj2 = z0yek();
			foreach (KeyValuePair<int, z0ZzZzbdj> item in z0uek)
			{
				z0ZzZzjgj2.z0eek((long)z0iek[item.Key]);
				item.Value.z0eek(z0ZzZzjgj2);
				int num = (int)z0ZzZzjgj2.z0uek();
				int num2 = z0tek(num);
				for (int i = num; i < num2; i++)
				{
					z0ZzZzjgj2.z0eek((byte)0);
				}
			}
		}
	}

	internal z0ZzZzgaj(z0ZzZzjgj p0)
		: base(z0oek, p0)
	{
	}

	internal void z0eek(z0ZzZzzfj p0, IDictionary<int, string> p1)
	{
		lock (this)
		{
			Dictionary<int, z0ZzZzbdj> dictionary = new Dictionary<int, z0ZzZzbdj>();
			if (p1 is z0ZzZzmdj.z0shj z0shj)
			{
				if (z0pek.TryGetValue(z0shj.z0cek, out var z0ZzZzbdj2))
				{
					if (z0ZzZzbdj2.z0rek() != null)
					{
						foreach (int item in z0ZzZzbdj2.z0rek())
						{
							if (!dictionary.ContainsKey(item) && z0pek.ContainsKey(item))
							{
								dictionary[item] = z0pek[item];
							}
						}
					}
					dictionary[z0shj.z0cek] = z0ZzZzbdj2;
				}
			}
			else
			{
				foreach (int key in p1.Keys)
				{
					if (!z0pek.TryGetValue(key, out var z0ZzZzbdj3))
					{
						continue;
					}
					if (z0ZzZzbdj3.z0rek() != null)
					{
						foreach (int item2 in z0ZzZzbdj3.z0rek())
						{
							if (!dictionary.ContainsKey(item2) && z0pek.ContainsKey(item2))
							{
								dictionary[item2] = z0pek[item2];
							}
						}
					}
					dictionary[key] = z0ZzZzbdj3;
				}
			}
			z0uek = dictionary;
			z0iek = z0rek(z0iek.Length - 1);
			p0.z0oek()?.z0eek(z0iek);
			z0yek = true;
		}
	}
}
