using System;
using System.Collections.Generic;
using System.Reflection;

namespace zzz;

[DefaultMember("Item")]
public class z0ZzZzjik<TKey, TValue>
{
	private class z0cvk<TKey2, TValue2>
	{
		public TValue2 z0eek;

		public TKey2 z0rek;
	}

	private readonly List<z0cvk<TKey, TValue>> z0uek = new List<z0cvk<TKey, TValue>>();

	private z0cvk<TKey, TValue> z0eek(TKey p0)
	{
		foreach (z0cvk<TKey, TValue> item in z0uek)
		{
			ref TKey reference = ref item.z0rek;
			object obj = p0;
			if (reference.Equals(obj))
			{
				return item;
			}
		}
		return null;
	}

	public void z0rek(TKey p0, TValue p1)
	{
		z0cvk<TKey, TValue> z0cvk = z0eek(p0);
		if (z0cvk == null)
		{
			z0cvk = new z0cvk<TKey, TValue>();
			z0cvk.z0rek = p0;
			z0cvk.z0eek = p1;
			z0uek.Add(z0cvk);
		}
		else
		{
			z0cvk.z0eek = p1;
		}
	}

	public List<TKey> z0yek()
	{
		List<TKey> list = new List<TKey>();
		foreach (z0cvk<TKey, TValue> item in z0uek)
		{
			list.Add(item.z0rek);
		}
		return list;
	}

	public TValue z0tek(TKey p0)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("keyValue");
		}
		z0cvk<TKey, TValue> z0cvk = z0eek(p0);
		if (z0cvk == null)
		{
			return default(TValue);
		}
		return z0cvk.z0eek;
	}
}
