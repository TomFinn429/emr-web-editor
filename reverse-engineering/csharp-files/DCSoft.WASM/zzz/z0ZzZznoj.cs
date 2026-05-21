using System;
using System.Collections.Generic;

namespace zzz;

public class z0ZzZznoj<T> : IDisposable where T : class
{
	private Dictionary<int, int> z0yek = new Dictionary<int, int>();

	private List<WeakReference<T>> z0uek = new List<WeakReference<T>>();

	private Dictionary<int, List<int>> z0iek;

	public void Dispose()
	{
		z0tek();
		z0uek = null;
		z0yek = null;
		z0iek = null;
	}

	public void z0tek()
	{
		if (z0uek != null)
		{
			for (int num = z0uek.Count - 1; num >= 0; num--)
			{
				z0uek[num].SetTarget(null);
			}
			z0uek.Clear();
			z0uek = new List<WeakReference<T>>();
		}
		if (z0yek != null)
		{
			z0yek.Clear();
			z0yek = new Dictionary<int, int>();
		}
		if (z0iek != null)
		{
			z0iek.Clear();
			z0iek = new Dictionary<int, List<int>>();
		}
	}

	public T z0eek(int p0)
	{
		if (p0 >= 0 && z0uek != null && p0 < z0uek.Count)
		{
			T result = null;
			if (z0uek[p0].TryGetTarget(out result))
			{
				return result;
			}
		}
		return null;
	}

	public int z0rek(T p0)
	{
		if (p0 == null)
		{
			return -1;
		}
		int hashCode = p0.GetHashCode();
		int num = 0;
		if (z0yek.TryGetValue(hashCode, out num))
		{
			T val = null;
			if (z0uek[num].TryGetTarget(out val) && val == p0)
			{
				return num;
			}
			if (z0iek == null)
			{
				z0iek = new Dictionary<int, List<int>>();
			}
			List<int> list = null;
			if (!z0iek.TryGetValue(hashCode, out list))
			{
				list = new List<int>();
				z0iek[hashCode] = list;
			}
			foreach (int item in list)
			{
				if (z0uek[item].TryGetTarget(out val) && val == p0)
				{
					return item;
				}
			}
			num = z0uek.Count;
			z0uek.Add(new WeakReference<T>(p0));
			list.Add(num);
			return num;
		}
		num = z0uek.Count;
		z0uek.Add(new WeakReference<T>(p0));
		z0yek[hashCode] = num;
		return num;
	}
}
