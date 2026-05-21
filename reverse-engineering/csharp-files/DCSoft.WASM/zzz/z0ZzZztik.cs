using System;
using System.Collections.Generic;

namespace zzz;

public abstract class z0ZzZztik<TContent, TSubContent> : IDisposable
{
	private class z0pck : IEqualityComparer<long>
	{
		private zzz.z0ZzZztik<TContent, TSubContent> z0eek;

		internal int z0rek;

		internal long z0tek = -1L;

		public z0pck(zzz.z0ZzZztik<TContent, TSubContent> p0)
		{
			z0eek = p0;
		}

		public int GetHashCode(long obj)
		{
			if (z0tek == obj)
			{
				return z0rek;
			}
			int p = (int)(obj >> 32);
			int p2 = (int)obj & 0xFFFFFFF;
			return z0eek.z0twk(p2, p);
		}

		public bool Equals(long x, long y)
		{
			int num = (int)(x >> 32);
			int p = (int)x & 0xFFFFFFF;
			int num2 = (int)(y >> 32);
			int p2 = (int)y & 0xFFFFFFF;
			if (num != num2)
			{
				return false;
			}
			return z0eek.z0ywk(p, p2, num);
		}
	}

	protected Dictionary<long, TSubContent> z0rek;

	protected TContent z0tek;

	private z0pck z0yek;

	protected abstract int z0twk(int p0, int p1);

	public z0ZzZztik()
	{
		z0yek = new z0pck(this);
		z0rek = new Dictionary<long, TSubContent>(z0yek);
	}

	protected abstract bool z0ywk(int p0, int p1, int p2);

	protected abstract TSubContent z0uwk(int p0, int p1);

	public virtual TSubContent z0eek(int p0, int p1)
	{
		if (z0rek == null)
		{
			throw new ObjectDisposedException(GetType().Name);
		}
		long num = ((long)p1 << 32) + p0;
		TSubContent val = default(TSubContent);
		z0yek.z0tek = num;
		z0yek.z0rek = z0twk(p0, p1);
		if (!z0rek.TryGetValue(num, out val))
		{
			val = z0uwk(p0, p1);
			z0rek.Add(num, val);
		}
		return val;
	}

	public virtual void Dispose()
	{
		if (z0rek != null)
		{
			z0rek.Clear();
			z0rek = null;
		}
		z0yek = null;
		z0tek = default(TContent);
	}
}
