using System.Collections.Generic;

namespace zzz;

public class z0ZzZzyuk<TKey1, TKey2, TValue>
{
	private struct z0uvk
	{
		public readonly TKey1 z0eek;

		public readonly TKey2 z0rek;

		public z0uvk(TKey1 p0, TKey2 p1)
		{
			z0eek = p0;
			z0rek = p1;
		}
	}

	private class z0sck : IEqualityComparer<z0uvk>
	{
		private zzz.z0ZzZzyuk<TKey1, TKey2, TValue> z0eek;

		public int GetHashCode(z0uvk obj)
		{
			return z0eek.z0owk(obj.z0eek, obj.z0rek);
		}

		public z0sck(zzz.z0ZzZzyuk<TKey1, TKey2, TValue> p0)
		{
			z0eek = p0;
		}

		public bool Equals(z0uvk x, z0uvk y)
		{
			return z0eek.z0iwk(x.z0eek, x.z0rek, y.z0eek, y.z0rek);
		}
	}

	private Dictionary<z0uvk, TValue> z0oek;

	public z0ZzZzyuk()
	{
		z0oek = new Dictionary<z0uvk, TValue>(new z0sck(this));
	}

	protected virtual bool z0iwk(TKey1 p0, TKey2 p1, TKey1 p2, TKey2 p3)
	{
		if (Comparer<TKey1>.Default.Compare(p0, p2) == 0)
		{
			return Comparer<TKey2>.Default.Compare(p1, p3) == 0;
		}
		return false;
	}

	public IEnumerable<TValue> z0yek()
	{
		return z0oek.Values;
	}

	public int z0uek()
	{
		return z0oek.Count;
	}

	public bool z0eek(TKey1 p0, TKey2 p1, out TValue p2)
	{
		return z0oek.TryGetValue(new z0uvk(p0, p1), out p2);
	}

	public void z0iek()
	{
		z0oek.Clear();
		z0oek = new Dictionary<z0uvk, TValue>(new z0sck(this));
	}

	protected virtual int z0owk(TKey1 p0, TKey2 p1)
	{
		return p0.GetHashCode() + p1.GetHashCode();
	}

	public void z0rek(TKey1 p0, TKey2 p1, TValue p2)
	{
		z0oek.Add(new z0uvk(p0, p1), p2);
	}

	public bool z0tek(TKey1 p0, TKey2 p1)
	{
		return z0oek.ContainsKey(new z0uvk(p0, p1));
	}
}
