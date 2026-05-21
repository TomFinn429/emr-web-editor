using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using DCSoft;

namespace zzz;

internal class z0ZzZzdsj
{
	[CompilerGenerated]
	private sealed class z0iyk_jiejie20260327142557
	{
		public static DCFunc<object, z0ZzZzmwj> z0rek;

		public static readonly z0iyk_jiejie20260327142557 z0tek = new z0iyk_jiejie20260327142557();

		internal z0ZzZzmwj z0eek(object p0)
		{
			throw new NotSupportedException();
		}
	}

	[CompilerGenerated]
	private sealed class z0vuk<T> where T : z0ZzZzfsj
	{
		public object z0rek;

		public DCFunc<object, T> z0tek;

		public z0ZzZzdsj z0yek_jiejie20260327142557;

		internal T z0eek()
		{
			object obj = z0yek_jiejie20260327142557.z0uek(z0rek);
			if (obj != null)
			{
				return z0tek(obj);
			}
			return null;
		}
	}

	[CompilerGenerated]
	private sealed class z0cuk
	{
		public string z0rek;

		public z0ZzZzmsj z0tek;

		internal z0ZzZzfej z0eek(object p0)
		{
			return z0ZzZzfej.z0eek(p0, z0tek, z0rek);
		}
	}

	private readonly Dictionary<z0ZzZzzhj, int> z0xek = new Dictionary<z0ZzZzzhj, int>();

	private int z0zek;

	private readonly Guid z0lrk = Guid.NewGuid();

	private readonly Dictionary<z0ZzZzzhj, z0ZzZzfsj> z0krk = new Dictionary<z0ZzZzzhj, z0ZzZzfsj>();

	private readonly IDictionary<int, z0ZzZzogj> z0jrk = new Dictionary<int, z0ZzZzogj>();

	private DCFunc<z0ZzZzssj, z0ZzZzqsj> z0hrk;

	private bool z0grk;

	private z0ZzZzugj z0frk;

	private Guid z0drk;

	private readonly HashSet<z0ZzZzfsj> z0srk = new HashSet<z0ZzZzfsj>();

	private readonly HashSet<z0ZzZzfsj> z0erk = new HashSet<z0ZzZzfsj>();

	private readonly Dictionary<int, WeakReference> z0rrk_jiejie20260327142557 = new Dictionary<int, WeakReference>();

	private void z0uek(z0ZzZztgj p0)
	{
	}

	internal void z0uek(z0ZzZzugj p0)
	{
		int p1 = z0uek();
		z0frk = p0;
		z0frk.z0eek(p1);
	}

	internal z0ZzZzwsj z0uek(z0ZzZznsj p0)
	{
		return z0iek(p0);
	}

	internal int z0uek()
	{
		if (z0frk != null)
		{
			return z0frk.z0eek();
		}
		return z0zek;
	}

	internal bool z0iek()
	{
		return z0drk != Guid.Empty;
	}

	internal z0ZzZzdsj(z0ZzZzpgj p0)
	{
	}

	internal T z0eek<T>(int p0, DCFunc<T> p1) where T : z0ZzZzfsj
	{
		if (z0rrk_jiejie20260327142557.TryGetValue(p0, out var weakReference))
		{
			T val = weakReference.Target as T;
			if (weakReference.IsAlive)
			{
				if (val == null)
				{
					z0ZzZzlxk.z0yek();
				}
				return val;
			}
			z0rrk_jiejie20260327142557.Remove(p0);
		}
		T val2 = p1();
		if (val2 != null)
		{
			val2.z0eek(p0);
			z0uek(p0, val2);
		}
		return val2;
	}

	private z0ZzZzwsj z0uek(Guid p0, z0ZzZzfsj p1)
	{
		int num = p1.z0rek();
		z0ZzZzzhj z0ZzZzzhj2 = z0iek(p1, p0);
		if (!z0xek.TryGetValue(z0ZzZzzhj2, out var num2))
		{
			bool flag = z0iek();
			if (!z0grk && p1.z0gsk(flag))
			{
				num2 = z0uek(p1, p0).z0rek();
			}
			else
			{
				num2 = ((flag || num == -1) ? z0cek() : num);
				z0xek.Add(z0ZzZzzhj2, num2);
				if (num == -1)
				{
					z0iek(p1, num2);
				}
				if (!z0uek(p1, num2))
				{
					return null;
				}
			}
		}
		return new z0ZzZzwsj(num2);
	}

	internal object z0uek(object p0)
	{
		if (!(p0 is z0ZzZzwsj))
		{
			return p0;
		}
		throw new NotSupportedException();
	}

	private object z0uek(int p0, string p1)
	{
		if (z0iek(p0) is z0ZzZzssj z0ZzZzssj2)
		{
			return z0ZzZzssj2.z0eek();
		}
		throw new NotSupportedException();
	}

	internal void z0oek()
	{
		z0grk = true;
		try
		{
			foreach (z0ZzZzfsj value in z0krk.Values)
			{
				z0uek(value, value.z0rek());
			}
			foreach (z0ZzZzfsj item in z0srk)
			{
				z0uek(item, item.z0rek());
			}
			z0bek();
			z0krk.Clear();
			z0srk.Clear();
			z0hrk = null;
		}
		finally
		{
			z0grk = false;
		}
	}

	public void z0pek()
	{
		z0jrk.Clear();
		z0rrk_jiejie20260327142557.Clear();
		z0erk.Clear();
		z0xek.Clear();
		z0srk.Clear();
		z0krk.Clear();
		z0frk = null;
		z0hrk = null;
	}

	internal z0ZzZzwsj z0uek(z0ZzZzeaj p0, byte[] p1)
	{
		return z0uek(new z0ZzZzkgj(p1).z0eek(p0));
	}

	private z0ZzZzwsj z0iek(object p0)
	{
		int num = z0uek() + 1;
		z0uek(num);
		int p1 = num;
		if (z0hrk == null)
		{
			z0uek(new z0ZzZzssj(p1, 0, p0), p1: true);
		}
		else
		{
			z0hrk(new z0ZzZzssj(p1, 0, p0));
		}
		return new z0ZzZzwsj(p1);
	}

	internal z0ZzZzugj z0mek()
	{
		return z0frk;
	}

	internal z0ZzZzmwj z0oek(object p0)
	{
		return z0rek(p0, (DCFunc<object, z0ZzZzmwj>)delegate
		{
			throw new NotSupportedException();
		});
	}

	internal z0ZzZzwsj z0uek(byte[] p0)
	{
		return z0uek(new z0ZzZzeaj(this), p0);
	}

	internal IEnumerator<z0ZzZzssj> z0nek()
	{
		foreach (int key in z0jrk.Keys)
		{
			if (z0jrk[key] is z0ZzZzssj z0ZzZzssj2)
			{
				yield return z0ZzZzssj2;
			}
		}
	}

	internal void z0uek(z0ZzZzogj p0, bool p1)
	{
		int num = p0.z0rek();
		if (p1 || !z0jrk.ContainsKey(num))
		{
			z0jrk[num] = p0;
			z0uek(num);
		}
	}

	private void z0uek(z0ZzZzogj p0)
	{
		int num = p0.z0rek();
		if (!z0jrk.TryGetValue(num, out var _))
		{
			z0ZzZzlxk.z0yek();
		}
		z0jrk[num] = p0;
	}

	internal void z0uek(int p0)
	{
		if (z0frk == null)
		{
			z0zek = Math.Max(z0zek, p0);
		}
		else
		{
			z0frk.z0eek(p0);
		}
	}

	private void z0bek()
	{
		z0xek.Clear();
	}

	internal z0ZzZzogj z0iek(int p0)
	{
		if (!z0jrk.TryGetValue(p0, out var z0ZzZzogj2))
		{
			return null;
		}
		if (z0ZzZzogj2 is z0ZzZzesj p1)
		{
			return z0tek(p1, (z0ZzZzesj p2) => z0uek(p2));
		}
		return z0ZzZzogj2;
	}

	internal z0ZzZzfej z0uek(object p0, z0ZzZzmsj p1, string p2)
	{
		return z0rek(p0, (object p3) => z0ZzZzfej.z0eek(p3, p1, p2));
	}

	private z0ZzZzksj z0uek(z0ZzZzesj p0)
	{
		throw new NotSupportedException();
	}

	internal int z0uek(z0ZzZzfsj p0)
	{
		return z0uek(p0, p1: false);
	}

	internal void z0uek(int p0, int p1)
	{
		if (p0 == 0 || !z0jrk.ContainsKey(p0))
		{
			z0jrk[p0] = new z0ZzZzpdj(p0, p1);
			z0uek(p0);
		}
	}

	private int z0iek(z0ZzZzfsj p0)
	{
		z0ZzZzzhj z0ZzZzzhj2 = z0iek(p0, z0lrk);
		if (!z0xek.TryGetValue(z0ZzZzzhj2, out var num))
		{
			num = p0.z0rek();
			if (num == -1)
			{
				num = z0cek();
			}
			z0xek.Add(z0ZzZzzhj2, num);
		}
		return num;
	}

	internal void z0vek()
	{
		z0krk.Clear();
		z0srk.Clear();
		z0hrk = null;
		z0grk = false;
	}

	internal object z0oek(int p0)
	{
		return z0uek(p0, (string)null);
	}

	private z0ZzZzfsj z0uek(z0ZzZzfsj p0, Guid p1)
	{
		bool flag = z0iek();
		z0ZzZzfsj z0ZzZzfsj2;
		if (p0.z0rek() != -1)
		{
			z0ZzZzjsj z0ZzZzjsj2 = new z0ZzZzjsj(p1, p0.z0rek());
			if (!z0krk.TryGetValue(z0ZzZzjsj2, out z0ZzZzfsj2))
			{
				z0ZzZzfsj2 = p0.z0jsk(this, flag);
				int num = z0ZzZzfsj2.z0rek();
				z0krk.Add(z0ZzZzjsj2, z0ZzZzfsj2);
				if (flag || !z0rrk_jiejie20260327142557.ContainsKey(num))
				{
					z0uek(num, z0ZzZzfsj2);
				}
			}
			else if (flag)
			{
				p0.z0hsk(z0ZzZzfsj2);
			}
		}
		else
		{
			z0ZzZzfsj2 = p0.z0jsk(this, flag);
			z0srk.Add(z0ZzZzfsj2);
			z0uek(z0ZzZzfsj2.z0rek(), z0ZzZzfsj2);
		}
		z0iek(z0ZzZzfsj2);
		return z0ZzZzfsj2;
	}

	internal int z0cek()
	{
		int num = z0uek() + 1;
		z0uek(num);
		return num;
	}

	internal T z0rek<T>(object p0, DCFunc<object, T> p1) where T : z0ZzZzfsj
	{
		if (p0 == null)
		{
			return null;
		}
		if (p0 is z0ZzZzwsj z0ZzZzwsj2)
		{
			return z0eek(z0ZzZzwsj2.z0eek(), delegate
			{
				object obj = z0uek(p0);
				return (obj != null) ? p1(obj) : null;
			});
		}
		return p1(p0);
	}

	internal void z0iek(z0ZzZzugj p0)
	{
		if (p0 != null)
		{
			z0uek(p0.z0uek().z0uek());
			z0uek(p0);
		}
	}

	private z0ZzZzogj z0tek(z0ZzZzesj p0, DCFunc<z0ZzZzesj, z0ZzZzksj> p1)
	{
		if (p0 != null)
		{
			try
			{
				if (p0.z0eek() == 0L)
				{
					z0ZzZzpdj z0ZzZzpdj2 = new z0ZzZzpdj(p0.z0rek(), ((z0ZzZzogj)p0).z0eek());
					z0uek(z0ZzZzpdj2);
					return z0ZzZzpdj2;
				}
				return p1(p0);
			}
			catch
			{
			}
		}
		return null;
	}

	internal z0ZzZzdsj(z0ZzZzpgj p0, DCFunc<z0ZzZzssj, z0ZzZzqsj> p1)
		: this(p0)
	{
		z0hrk = p1;
	}

	internal z0ZzZzwsj z0oek(z0ZzZzfsj p0)
	{
		if (p0 != null)
		{
			return z0uek(z0iek() ? z0drk : z0lrk, p0);
		}
		return null;
	}

	internal bool z0uek(z0ZzZzfsj p0, int p1)
	{
		object obj = p0.z0ngk(this);
		if (obj == null)
		{
			return false;
		}
		z0ZzZzssj z0ZzZzssj2 = new z0ZzZzssj(p1, 0, obj);
		if (z0hrk == null)
		{
			z0uek(z0ZzZzssj2, p1: true);
		}
		else
		{
			z0hrk(z0ZzZzssj2);
		}
		return true;
	}

	[CompilerGenerated]
	private z0ZzZzksj z0iek(z0ZzZzesj p0)
	{
		return z0uek(p0);
	}

	private void z0uek(int p0, z0ZzZzfsj p1)
	{
		z0rrk_jiejie20260327142557.Add(p0, new WeakReference(p1));
	}

	private static z0ZzZzzhj z0iek(z0ZzZzfsj p0, Guid p1)
	{
		if (p0 != null)
		{
			int num = p0.z0rek();
			if (num == -1)
			{
				return new z0ZzZztgj(p0);
			}
			return new z0ZzZzjsj(p1, num);
		}
		return null;
	}

	internal int z0uek(z0ZzZzfsj p0, bool p1)
	{
		if (p0 == null)
		{
			return 0;
		}
		int num = p0.z0rek();
		if (!z0erk.Contains(p0) && (num == -1 || !z0jrk.ContainsKey(num)))
		{
			int num2 = z0uek() + 1;
			z0uek(num2);
			num = num2;
			p0.z0eek(num);
			if (p1 || z0hrk == null)
			{
				z0uek(num, p0);
				z0erk.Add(p0);
			}
			else
			{
				z0oek(p0);
			}
		}
		return num;
	}

	internal z0ZzZzwsj z0uek(z0ZzZzrgj p0)
	{
		return z0iek(p0);
	}

	private int z0uek(z0ZzZzjsj p0)
	{
		if (!z0xek.TryGetValue(p0, out var result))
		{
			return -1;
		}
		return result;
	}

	private void z0iek(z0ZzZzfsj p0, int p1)
	{
		z0uek(new z0ZzZztgj(p0));
	}

	internal z0ZzZzwsj z0yek(int p0, DCFunc<z0ZzZzfsj> p1)
	{
		Guid p2 = (z0iek() ? z0drk : z0lrk);
		int num = z0uek(new z0ZzZzjsj(p2, p0));
		if (num == -1)
		{
			return z0oek(p1());
		}
		return new z0ZzZzwsj(num);
	}
}
