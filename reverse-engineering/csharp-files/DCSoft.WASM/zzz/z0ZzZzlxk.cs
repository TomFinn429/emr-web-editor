using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace zzz;

public static class z0ZzZzlxk
{
	[CompilerGenerated]
	private sealed class z0vyk<T1, T2>
	{
		public static Comparison<KeyValuePair<T1, T2>> z0rek;

		public static readonly z0vyk<T1, T2> z0tek = new z0vyk<T1, T2>();

		internal int z0eek(KeyValuePair<T1, T2> p0, KeyValuePair<T1, T2> p1)
		{
			return Comparer<T1>.Default.Compare(p0.Key, p1.Key);
		}
	}

	internal static bool z0yek(Enum p0, Enum p1)
	{
		long num = Convert.ToInt64(p0);
		long num2 = Convert.ToInt64(p1);
		return (num & num2) == num2;
	}

	internal static KeyValuePair<T1, T2>[] z0eek<T1, T2>(IDictionary<T1, T2> p0)
	{
		List<KeyValuePair<T1, T2>> list = new List<KeyValuePair<T1, T2>>();
		foreach (KeyValuePair<T1, T2> item in p0)
		{
			list.Add(item);
		}
		list.Sort((KeyValuePair<T1, T2> keyValuePair, KeyValuePair<T1, T2> keyValuePair2) => Comparer<T1>.Default.Compare(keyValuePair.Key, keyValuePair2.Key));
		return list.ToArray();
	}

	internal static void z0yek()
	{
		throw new ArgumentException("IncorrectPdfData");
	}

	internal static T[] z0rek<T>(IEnumerable<T> p0)
	{
		List<T> list = new List<T>();
		foreach (T item in p0)
		{
			list.Add(item);
		}
		return list.ToArray();
	}

	internal static IList z0yek(IEnumerable p0, int p1)
	{
		ArrayList arrayList = new ArrayList();
		int num = 0;
		foreach (object item in p0)
		{
			num++;
			if (num > p1)
			{
				arrayList.Add(item);
			}
		}
		return arrayList;
	}

	internal static bool z0yek(z0ZzZzzfj p0)
	{
		if (p0 != null)
		{
			return !p0.z0jrk;
		}
		return false;
	}

	internal static List<T> z0tek<T>(IEnumerable<T> p0)
	{
		List<T> list = new List<T>();
		foreach (T item in p0)
		{
			list.Add(item);
		}
		return list;
	}
}
