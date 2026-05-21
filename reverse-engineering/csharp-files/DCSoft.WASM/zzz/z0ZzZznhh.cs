using System;
using System.Collections.Generic;

namespace zzz;

public sealed class z0ZzZznhh : List<z0ZzZzphh>
{
	private class z0epk : IComparer<z0ZzZzphh>
	{
		public int Compare(z0ZzZzphh x, z0ZzZzphh y)
		{
			int num = x.z0dq() - y.z0dq();
			if (num == 0)
			{
				num = string.Compare(x.z0js(), y.z0js());
			}
			return num;
		}
	}

	private static readonly z0ZzZznhh z0yek = new z0ZzZznhh();

	public static z0ZzZznhh z0eek()
	{
		return z0yek;
	}

	public z0ZzZzphh z0rek()
	{
		using (Enumerator enumerator = GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				z0ZzZzphh current = enumerator.Current;
				if (current.z0eek())
				{
					return current;
				}
			}
		}
		return z0ZzZzwgh.z0eek();
	}

	public z0ZzZzphh z0tek()
	{
		return z0eek("rtf");
	}

	public z0ZzZzphh z0eek(string p0)
	{
		if (!string.IsNullOrEmpty(p0))
		{
			using Enumerator enumerator = GetEnumerator();
			while (enumerator.MoveNext())
			{
				z0ZzZzphh current = enumerator.Current;
				if (string.Compare(current.z0js(), p0, true) == 0)
				{
					return current;
				}
			}
		}
		return z0rek();
	}

	public int z0eek(z0ZzZzphh p0)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("ser");
		}
		int num = IndexOf(p0);
		if (num >= 0)
		{
			return num;
		}
		Add(p0);
		Sort(new z0epk());
		return IndexOf(p0);
	}
}
