using System;
using System.Collections.Generic;
using System.Text;

namespace zzz;

public abstract class z0ZzZzvik
{
	[NonSerialized]
	protected int z0oek;

	[NonSerialized]
	private bool z0pek;

	[NonSerialized]
	[z0ZzZzuqh]
	public bool z0mek;

	[NonSerialized]
	private bool z0nek;

	protected z0ZzZzxik z0bek = new z0ZzZzxik();

	public bool z0eek()
	{
		return z0nek;
	}

	public void z0eek(bool p0)
	{
		z0pek = p0;
	}

	public static int z0eek(z0ZzZzvik p0, z0ZzZzvik p1)
	{
		if (p0 == null)
		{
			return 0;
		}
		if (p0 == p1)
		{
			return 0;
		}
		if (p0.z0rek())
		{
			return 0;
		}
		int num = 0;
		p0.z0oek = 0;
		if (p1 == null)
		{
			foreach (z0ZzZzcik item in new List<z0ZzZzcik>(p0.z0bek.Keys))
			{
				if (object.Equals(item.z0uek(), p0.z0bek[item]))
				{
					p0.z0bek.Remove(item);
					p0.z0vn(item);
					p0.z0mek = true;
					num++;
				}
			}
		}
		else
		{
			foreach (z0ZzZzcik item2 in new List<z0ZzZzcik>(p0.z0bek.Keys))
			{
				foreach (z0ZzZzcik key in p1.z0bek.Keys)
				{
					if (item2 == key && object.Equals(p0.z0bek[item2], p1.z0bek[item2]))
					{
						p0.z0bek.Remove(item2);
						p0.z0mek = true;
						p0.z0vn(item2);
						num++;
					}
				}
			}
		}
		return num;
	}

	public static bool z0eek(z0ZzZzvik p0, string p1)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("instance");
		}
		if (string.IsNullOrEmpty(p1))
		{
			throw new ArgumentNullException("propertyName");
		}
		p0.z0tek();
		foreach (z0ZzZzcik key in p0.z0bek.Keys)
		{
			if (string.Compare(key.z0yek(), p1, StringComparison.Ordinal) == 0)
			{
				p0.z0oek = 0;
				p0.z0bek.Remove(key);
				p0.z0mek = true;
				p0.z0vn(key);
				return true;
			}
		}
		return false;
	}

	public bool z0rek()
	{
		return z0pek;
	}

	public static int z0eek(z0ZzZzvik p0, z0ZzZzvik p1, bool p2)
	{
		if (p0 == p1)
		{
			return 0;
		}
		if (p0 == null || p1 == null)
		{
			return 0;
		}
		int num = 0;
		p1.z0oek = 0;
		foreach (z0ZzZzcik key in p0.z0yek().Keys)
		{
			if (!p1.z0yek().ContainsKey(key))
			{
				object obj = p0.z0eek(key);
				if (obj is ICloneable)
				{
					obj = ((ICloneable)obj).Clone();
				}
				if (p0.z0pek || p1.z0pek)
				{
					p1.z0yek()[key] = obj;
					p1.z0mek = true;
					p1.z0vn(key);
				}
				else
				{
					p1.z0eek(key, obj);
				}
				num++;
			}
			else if (p2)
			{
				bool flag = p1.z0pek;
				p1.z0pek = p0.z0pek;
				p1.z0yek()[key] = p0.z0yek()[key];
				p1.z0mek = true;
				p1.z0pek = flag;
				p1.z0vn(key);
				num++;
			}
		}
		return num;
	}

	private void z0tek()
	{
		if (z0nek)
		{
			throw new InvalidOperationException("属性值被锁定了");
		}
	}

	protected Dictionary<z0ZzZzcik, object> z0yek()
	{
		z0bek.z0eek(this);
		return z0bek;
	}

	protected virtual object z0eek(z0ZzZzcik p0)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("property");
		}
		z0bek.z0eek(this);
		object result = null;
		if (z0bek.TryGetValue(p0, out result))
		{
			return result;
		}
		return p0.z0uek();
	}

	public static void z0rek(z0ZzZzvik p0, z0ZzZzvik p1)
	{
		if (p0 == p1 || p0 == null || p1 == null)
		{
			return;
		}
		p1.z0yek().Clear();
		p1.z0oek = 0;
		foreach (KeyValuePair<z0ZzZzcik, object> item in p0.z0bek)
		{
			object obj = item.Value;
			if (obj is ICloneable)
			{
				obj = ((ICloneable)obj).Clone();
			}
			p1.z0bek.Add(item.Key, obj);
		}
		p1.z0mek = true;
	}

	public virtual int z0uek()
	{
		if (z0oek == 0)
		{
			int num = 0;
			foreach (KeyValuePair<z0ZzZzcik, object> item in z0bek)
			{
				num += item.Key.GetHashCode();
				if (item.Value != null)
				{
					num += item.Value.GetHashCode();
				}
			}
			z0oek = num;
		}
		return z0oek;
	}

	public virtual void z0eek(z0ZzZzcik p0, object p1)
	{
		if (z0cn())
		{
			if (z0bek.ContainsKey(p0) && p0.z0eek(p1))
			{
				z0bek.Remove(p0);
			}
			else
			{
				z0bek[p0] = p1;
			}
			return;
		}
		z0tek();
		if (p0 == null)
		{
			throw new ArgumentNullException("property");
		}
		if (!p0.z0rek().IsInstanceOfType(this))
		{
			throw new ArgumentException("need " + p0.z0rek().FullName);
		}
		z0oek = 0;
		z0bek.z0eek(this);
		if (!z0pek && p0.z0eek(p1))
		{
			if (!z0bek.ContainsKey(p0))
			{
				return;
			}
			z0bek.Remove(p0);
		}
		else
		{
			z0bek[p0] = p1;
		}
		z0vn(p0);
		z0mek = true;
	}

	public static int z0eek(z0ZzZzvik p0)
	{
		return p0?.z0bek.Count ?? 0;
	}

	protected virtual void z0vn(z0ZzZzcik p0)
	{
	}

	public void z0rek(bool p0)
	{
		z0nek = p0;
	}

	protected virtual bool z0cn()
	{
		return false;
	}

	public static bool z0rek(z0ZzZzvik p0, string p1)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("instance");
		}
		if (p1 == null || p1.Trim().Length == 0)
		{
			throw new ArgumentNullException("propertyName");
		}
		if (p0.z0bek != null && p0.z0bek.Count > 0)
		{
			p1 = p1.Trim();
			foreach (z0ZzZzcik key in p0.z0bek.Keys)
			{
				if (string.Compare(key.z0yek(), p1, StringComparison.OrdinalIgnoreCase) == 0)
				{
					return true;
				}
			}
		}
		return false;
	}

	public static string z0rek(z0ZzZzvik p0)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("instance");
		}
		StringBuilder stringBuilder = new StringBuilder();
		foreach (z0ZzZzcik key in p0.z0bek.Keys)
		{
			if (stringBuilder.Length > 0)
			{
				stringBuilder.Append(";");
			}
			stringBuilder.Append(key.z0yek() + ":" + p0.z0bek[key]);
		}
		return stringBuilder.ToString();
	}

	protected void z0iek()
	{
		if (z0bek == null)
		{
			return;
		}
		foreach (object value in z0bek.Values)
		{
			if (value is IDisposable)
			{
				((IDisposable)value).Dispose();
			}
		}
		z0bek.Clear();
		z0vn(null);
	}

	public static void z0rek(z0ZzZzvik p0, z0ZzZzvik p1, bool p2)
	{
		if (p0 == p1 || p0 == null || p1 == null)
		{
			return;
		}
		p1.z0oek = 0;
		foreach (z0ZzZzcik key in p0.z0bek.Keys)
		{
			if (key == null)
			{
				throw new NullReferenceException("p");
			}
			if (p2 || !p1.z0bek.ContainsKey(key))
			{
				object obj = p0.z0bek[key];
				if (obj is ICloneable)
				{
					obj = ((ICloneable)obj).Clone();
				}
				p1.z0bek[key] = obj;
				p1.z0mek = true;
			}
		}
	}
}
