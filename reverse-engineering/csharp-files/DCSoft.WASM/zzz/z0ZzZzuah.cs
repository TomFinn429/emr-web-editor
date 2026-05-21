using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

namespace zzz;

public class z0ZzZzuah : IEnumerable
{
	[DefaultMember("Item")]
	internal struct z0qhj
	{
		private sealed class z0ahj : IEnumerator
		{
			private int z0eek = -1;

			private readonly object z0rek;

			public object Current
			{
				get
				{
					if (z0eek != 0)
					{
						throw new InvalidOperationException();
					}
					return z0rek;
				}
			}

			public bool MoveNext()
			{
				if (z0eek < 0)
				{
					z0eek = 0;
					return true;
				}
				z0eek = 1;
				return false;
			}

			public void Reset()
			{
				z0eek = -1;
			}

			public z0ahj(object p0)
			{
				z0rek = p0;
			}
		}

		private object z0tek;

		public int z0eek()
		{
			if (z0tek == null)
			{
				return 0;
			}
			if (z0tek is List<object> list)
			{
				return list.Count;
			}
			return 1;
		}

		public object z0eek(int p0)
		{
			if (z0tek == null)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			if (z0tek is List<object> list)
			{
				return list[p0];
			}
			if (p0 != 0)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			return z0tek;
		}

		public void z0eek(object p0)
		{
			if (z0tek == null)
			{
				if (p0 == null)
				{
					List<object> list = new List<object>();
					list.Add(null);
					z0tek = list;
				}
				else
				{
					z0tek = p0;
				}
			}
			else if (z0tek is List<object> list2)
			{
				list2.Add(p0);
			}
			else
			{
				List<object> list3 = new List<object>();
				list3.Add(z0tek);
				list3.Add(p0);
				z0tek = list3;
			}
		}

		public void z0rek(int p0)
		{
			if (z0tek == null)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			if (z0tek is List<object> list)
			{
				list.RemoveAt(p0);
				return;
			}
			if (p0 != 0)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			z0tek = null;
		}

		public void z0eek(int p0, object p1)
		{
			if (z0tek == null)
			{
				if (p0 != 0)
				{
					throw new ArgumentOutOfRangeException("index");
				}
				z0eek(p1);
				return;
			}
			if (z0tek is List<object> list)
			{
				list.Insert(p0, p1);
				return;
			}
			switch (p0)
			{
			case 0:
			{
				List<object> list2 = new List<object>();
				list2.Add(p1);
				list2.Add(z0tek);
				z0tek = list2;
				break;
			}
			case 1:
			{
				List<object> list2 = new List<object>();
				list2.Add(z0tek);
				list2.Add(p1);
				z0tek = list2;
				break;
			}
			default:
				throw new ArgumentOutOfRangeException("index");
			}
		}

		public IEnumerator z0rek()
		{
			if (z0tek == null)
			{
				return z0ZzZzfah.z0btk;
			}
			if (z0tek is List<object> list)
			{
				return list.GetEnumerator();
			}
			return new z0ahj(z0tek);
		}
	}

	internal z0qhj z0tek;

	internal z0ZzZzoah z0yek;

	public virtual int Count => z0tek.z0eek();

	internal z0ZzZzoah z0eek(int p0, z0ZzZzoah p1)
	{
		z0ZzZzoah result = z0ef(p0);
		z0rf(p0, p1);
		return result;
	}

	internal virtual z0ZzZzoah z0wf(z0ZzZzoah p0)
	{
		z0tek.z0eek(p0);
		p0.z0gg(z0yek);
		return p0;
	}

	internal z0ZzZzuah(z0ZzZzoah p0)
	{
		z0yek = p0;
	}

	internal int z0eek(string p0, string p1)
	{
		int count = Count;
		for (int i = 0; i < count; i++)
		{
			z0ZzZzoah z0ZzZzoah2 = (z0ZzZzoah)z0tek.z0eek(i);
			if (z0ZzZzoah2.z0ph() == p0 && z0ZzZzoah2.z0ag() == p1)
			{
				return i;
			}
		}
		return -1;
	}

	internal int z0eek(string p0)
	{
		int count = Count;
		for (int i = 0; i < count; i++)
		{
			z0ZzZzoah z0ZzZzoah2 = (z0ZzZzoah)z0tek.z0eek(i);
			if (p0 == z0ZzZzoah2.z0th())
			{
				return i;
			}
		}
		return -1;
	}

	public virtual z0ZzZzoah z0rek(string p0)
	{
		int num = z0eek(p0);
		if (num >= 0)
		{
			return z0ef(num);
		}
		return null;
	}

	internal virtual z0ZzZzoah z0ef(int p0)
	{
		z0ZzZzoah obj = (z0ZzZzoah)z0tek.z0eek(p0);
		z0tek.z0rek(p0);
		obj.z0gg(null);
		return obj;
	}

	internal virtual z0ZzZzoah z0rf(int p0, z0ZzZzoah p1)
	{
		z0tek.z0eek(p0, p1);
		p1.z0gg(z0yek);
		return p1;
	}

	internal virtual z0ZzZzoah z0eek(z0ZzZzoah p0, z0ZzZzfah p1)
	{
		z0tek.z0eek(p0);
		p0.z0gg(z0yek);
		return p0;
	}

	public virtual IEnumerator GetEnumerator()
	{
		return z0tek.z0rek();
	}
}
