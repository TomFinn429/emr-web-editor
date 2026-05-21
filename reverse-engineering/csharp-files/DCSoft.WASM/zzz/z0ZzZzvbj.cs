using System;
using System.Collections;
using System.Reflection;
using System.Text;
using DCSoft.Writer.Data;

namespace zzz;

public class z0ZzZzvbj
{
	private bool z0frk_jiejie20260327142557 = true;

	private string z0drk;

	[NonSerialized]
	private object z0srk_jiejie20260327142557;

	private bool z0ark = true;

	public static readonly z0ZzZzvbj z0qrk = new z0ZzZzvbj();

	[NonSerialized]
	private object z0wrk;

	private z0ZzZzbbj z0erk;

	private string z0rrk;

	private string z0trk;

	private int z0yrk = z0zrk++;

	[NonSerialized]
	private object z0urk;

	private string z0irk_jiejie20260327142557;

	private bool z0ork;

	internal bool z0prk;

	private string z0mrk;

	private z0ZzZzvbj z0nrk;

	private DataSourceTreeNodeType z0brk = DataSourceTreeNodeType.Auto;

	private z0ZzZzcbj z0vrk;

	[NonSerialized]
	private PropertyInfo z0crk;

	[NonSerialized]
	private object z0xrk;

	private static int z0zrk = 0;

	public virtual z0ZzZzvbj z0eek(string p0, bool p1)
	{
		if (z0eek())
		{
			return null;
		}
		if (string.IsNullOrEmpty(p0))
		{
			throw new ArgumentNullException("name");
		}
		if (z0nek() != null && z0nek().Count > 0)
		{
			foreach (z0ZzZzvbj item in z0nek())
			{
				if (item.z0lrk() == p0)
				{
					return item;
				}
			}
		}
		if (p1)
		{
			return z0rv(p0);
		}
		return null;
	}

	public virtual DataSourceTreeNodeType z0tv()
	{
		return z0brk;
	}

	public bool z0eek()
	{
		return this == z0qrk;
	}

	public string z0rek()
	{
		return z0mrk;
	}

	public virtual z0ZzZzvbj z0rek(string p0, bool p1)
	{
		if (z0eek())
		{
			return null;
		}
		if (p0 == ".")
		{
			return this;
		}
		z0ZzZzcbj z0ZzZzcbj2 = new z0ZzZzcbj();
		z0eek(p0, z0ZzZzcbj2, p2: true, p1);
		if (z0ZzZzcbj2.Count > 0)
		{
			return z0ZzZzcbj2[0];
		}
		return null;
	}

	private void z0eek(string p0, z0ZzZzcbj p1, bool p2, bool p3)
	{
		if (string.IsNullOrEmpty(p0))
		{
			p1.Add(this);
			return;
		}
		string p4 = null;
		string p5 = null;
		z0eek(p0, ref p4, ref p5);
		IList list = z0nek();
		bool flag = false;
		if (list != null && list.Count > 0)
		{
			foreach (z0ZzZzvbj item in list)
			{
				if (item.z0lrk() == p4)
				{
					flag = true;
					if (string.IsNullOrEmpty(p5))
					{
						p1.Add(item);
					}
					else
					{
						item.z0eek(p5, p1, p2, p3);
					}
					if (p2 && p1.Count > 0)
					{
						return;
					}
				}
			}
		}
		if (!(!flag && p3) || (p2 && p1.Count > 0))
		{
			return;
		}
		z0ZzZzvbj z0ZzZzvbj3 = z0rv(p4);
		if (z0ZzZzvbj3 != null)
		{
			if (string.IsNullOrEmpty(p5))
			{
				p1.Add(z0ZzZzvbj3);
			}
			else
			{
				z0ZzZzvbj3.z0eek(p5, p1, p2, p3);
			}
		}
	}

	public object z0tek()
	{
		object obj = z0uv_jiejie20260327142557();
		if (obj != null && obj is z0ZzZzoah)
		{
			if (obj is z0ZzZzsah)
			{
				return ((z0ZzZzsah)obj).z0eg();
			}
			return ((z0ZzZzoah)obj).z0rh();
		}
		return obj;
	}

	public void z0eek(object p0)
	{
		z0wrk = p0;
	}

	public bool z0yek()
	{
		return z0frk_jiejie20260327142557;
	}

	public void z0eek(z0ZzZzcbj p0)
	{
		z0vrk = p0;
	}

	public bool z0uek()
	{
		if (z0tv() == DataSourceTreeNodeType.Entry)
		{
			return false;
		}
		if (z0pv() is string)
		{
			return false;
		}
		if (z0pv() is IList)
		{
			if (z0ov() != null)
			{
				return z0ov().z0eek(z0pv().GetType());
			}
			return z0ZzZznok.GetCollectionItemType(z0pv().GetType(), checkAddMethod: false) != null;
		}
		return false;
	}

	public void z0eek(string p0)
	{
		z0drk = p0;
	}

	public string z0iek()
	{
		return z0trk;
	}

	internal virtual void z0eek(z0ZzZzvbj p0)
	{
		z0nrk = p0;
	}

	public virtual void z0oek()
	{
		z0srk_jiejie20260327142557 = null;
		if (z0nek() == null || z0nek().Count <= 0)
		{
			return;
		}
		foreach (z0ZzZzvbj item in z0nek())
		{
			item.z0oek();
		}
	}

	public void z0eek(bool p0)
	{
		z0frk_jiejie20260327142557 = p0;
	}

	public void z0eek(int p0)
	{
		z0yrk = p0;
	}

	public bool z0pek()
	{
		return z0ork;
	}

	public virtual void z0iv(string p0)
	{
		if (z0rrk != p0)
		{
			z0rrk = p0;
			z0crk = null;
		}
	}

	public virtual z0ZzZzvbj z0ev()
	{
		if (z0eek())
		{
			return null;
		}
		return z0nrk;
	}

	public void z0rek(string p0)
	{
		z0trk = p0;
	}

	public void z0tek(string p0)
	{
		z0irk_jiejie20260327142557 = p0;
	}

	public virtual void z0yv(object p0)
	{
		if (z0urk != p0)
		{
			z0urk = p0;
			z0crk = null;
		}
	}

	public virtual object z0pv()
	{
		return z0urk;
	}

	public void z0mek()
	{
		object obj = z0uv_jiejie20260327142557();
		if (!(obj is IList))
		{
			return;
		}
		IList list = (IList)obj;
		z0eek(new z0ZzZzcbj());
		foreach (object item in list)
		{
			z0ZzZzvbj z0ZzZzvbj2 = new z0ZzZzvbj();
			z0ZzZzvbj2.z0eek(z0ov());
			z0ZzZzvbj2.z0eek(this);
			z0ZzZzvbj2.z0tek("Item");
			z0ZzZzvbj2.z0yv(item);
			z0ZzZzvbj2.z0bv_jiejie20260327142557(DataSourceTreeNodeType.Entry);
			z0ZzZzvbj2.z0rek(list.IsReadOnly);
			z0nek().Add(z0ZzZzvbj2);
		}
	}

	public virtual void z0bv_jiejie20260327142557(DataSourceTreeNodeType p0)
	{
		if (z0brk != p0)
		{
			z0brk = p0;
			z0crk = null;
		}
	}

	public virtual object z0uv_jiejie20260327142557()
	{
		if (z0eek())
		{
			return null;
		}
		if (z0tv() == DataSourceTreeNodeType.Text)
		{
			return z0hrk();
		}
		if (z0pv() is string)
		{
			return z0pv().ToString();
		}
		if (z0pv() is z0ZzZzoah)
		{
			z0ZzZzoah z0ZzZzoah2 = (z0ZzZzoah)z0pv();
			if (string.IsNullOrEmpty(z0mv()))
			{
				return z0ZzZzoah2;
			}
			if (z0ZzZzoah2.z0tek() != null)
			{
				foreach (z0ZzZzoah item in z0ZzZzoah2.z0tek())
				{
					if (item.z0th() == z0mv())
					{
						return item;
					}
				}
			}
			return null;
		}
		if (z0pv() is IDictionary && z0tv() != DataSourceTreeNodeType.Entry)
		{
			IDictionary dictionary = (IDictionary)z0pv();
			if (!string.IsNullOrEmpty(z0mv()))
			{
				if (dictionary.Contains(z0mv()))
				{
					return dictionary[z0mv()];
				}
				return null;
			}
			return z0pv();
		}
		if (z0hrk() == null)
		{
			return z0krk();
		}
		return z0hrk();
	}

	public void z0yek(string p0)
	{
		z0mrk = p0;
	}

	private void z0eek(string p0, ref string p1, ref string p2)
	{
		int num = p0.IndexOf(z0ov().z0tek());
		if (num > 0 && string.IsNullOrEmpty(z0lrk()))
		{
			p1 = p0.Substring(0, num);
			p2 = p0.Substring(num + 1);
		}
		else
		{
			p1 = p0;
			p2 = null;
		}
	}

	public z0ZzZzcbj z0nek()
	{
		if (z0eek())
		{
			return null;
		}
		return z0vrk;
	}

	public virtual bool z0bek()
	{
		if (z0prk)
		{
			return true;
		}
		if (z0eek())
		{
			return true;
		}
		if (z0tv() == DataSourceTreeNodeType.Text)
		{
			return false;
		}
		if (z0pv() is z0ZzZzoah)
		{
			z0ZzZzoah z0ZzZzoah2 = (z0ZzZzoah)z0pv();
			if (string.IsNullOrEmpty(z0mv()))
			{
				return false;
			}
			if (z0ZzZzoah2.z0tek() != null)
			{
				foreach (z0ZzZzoah item in z0ZzZzoah2.z0tek())
				{
					if (item.z0th() == z0mv())
					{
						return false;
					}
				}
			}
			return true;
		}
		if (z0pv() is IDictionary && z0tv() != DataSourceTreeNodeType.Entry)
		{
			IDictionary dictionary = (IDictionary)z0pv();
			if (!string.IsNullOrEmpty(z0mv()))
			{
				if (dictionary.Contains(z0mv()))
				{
					return false;
				}
				return true;
			}
			return false;
		}
		return DBNull.Value.Equals(z0hrk());
	}

	public void z0rek(bool p0)
	{
		z0ork = p0;
	}

	public void z0rek(object p0)
	{
		z0xrk = p0;
	}

	public virtual string z0mv()
	{
		return z0rrk;
	}

	public virtual object z0vek()
	{
		return z0srk_jiejie20260327142557;
	}

	public bool z0cek()
	{
		return z0crk != null;
	}

	public int z0xek()
	{
		return z0yrk;
	}

	public virtual z0ZzZzbbj z0ov()
	{
		if (z0eek())
		{
			return null;
		}
		return z0erk;
	}

	public virtual void z0zek()
	{
		if (z0nek() == null || z0nek().Count <= 0)
		{
			return;
		}
		foreach (z0ZzZzvbj item in z0nek())
		{
			item.z0eek(this);
			item.z0eek(z0ov());
			item.z0zek();
		}
	}

	public virtual z0ZzZzvbj z0tek(bool p0)
	{
		if (z0eek())
		{
			return null;
		}
		z0ZzZzvbj z0ZzZzvbj2 = (z0ZzZzvbj)MemberwiseClone();
		z0ZzZzvbj2.z0vrk = null;
		if (p0 && z0vrk != null && z0vrk.Count > 0)
		{
			z0ZzZzvbj2.z0vrk = new z0ZzZzcbj();
			foreach (z0ZzZzvbj item in z0vrk)
			{
				z0ZzZzvbj2.z0vrk.Add(item.z0tek(p0: true));
			}
		}
		return z0ZzZzvbj2;
	}

	public string z0lrk()
	{
		return z0irk_jiejie20260327142557;
	}

	public string z0krk()
	{
		return z0drk;
	}

	public void z0jrk()
	{
		object obj = z0uv_jiejie20260327142557();
		if (obj == null)
		{
			z0eek((z0ZzZzcbj)null);
			return;
		}
		if (obj is z0ZzZzoah)
		{
			z0ZzZzoah z0ZzZzoah2 = (z0ZzZzoah)obj;
			z0eek(new z0ZzZzcbj());
			if (z0ZzZzoah2.z0sg() != null && z0ZzZzoah2.z0sg().Count > 0)
			{
				foreach (z0ZzZzbsh item in z0ZzZzoah2.z0sg())
				{
					z0ZzZzvbj z0ZzZzvbj2 = new z0ZzZzvbj();
					z0ZzZzvbj2.z0eek(z0ov());
					z0ZzZzvbj2.z0eek(this);
					z0ZzZzvbj2.z0tek(item.z0th());
					z0ZzZzvbj2.z0yv(item);
					z0ZzZzvbj2.z0bv_jiejie20260327142557(DataSourceTreeNodeType.Xml);
					z0nek().Add(z0ZzZzvbj2);
				}
			}
			if (z0ZzZzoah2.z0tek() == null || z0ZzZzoah2.z0tek().z0sf() <= 0)
			{
				return;
			}
			{
				foreach (z0ZzZzoah item2 in z0ZzZzoah2.z0tek())
				{
					if (item2 is z0ZzZzsah)
					{
						z0ZzZzvbj z0ZzZzvbj3 = new z0ZzZzvbj();
						z0ZzZzvbj3.z0eek(z0ov());
						z0ZzZzvbj3.z0eek(this);
						z0ZzZzvbj3.z0tek(item2.z0th());
						z0ZzZzvbj3.z0yv(item2);
						z0ZzZzvbj3.z0bv_jiejie20260327142557(DataSourceTreeNodeType.Xml);
						z0nek().Add(z0ZzZzvbj3);
					}
				}
				return;
			}
		}
		if (obj is IDictionary && z0tv() != DataSourceTreeNodeType.Entry)
		{
			z0eek(new z0ZzZzcbj());
			{
				foreach (object key in ((IDictionary)z0pv()).Keys)
				{
					z0ZzZzvbj z0ZzZzvbj4 = new z0ZzZzvbj();
					z0ZzZzvbj4.z0eek(z0ov());
					z0ZzZzvbj4.z0eek(this);
					z0ZzZzvbj4.z0tek(Convert.ToString(key));
					z0ZzZzvbj4.z0yv(obj);
					z0ZzZzvbj4.z0iv(z0ZzZzvbj4.z0lrk());
					z0ZzZzvbj4.z0bv_jiejie20260327142557(DataSourceTreeNodeType.Auto);
					z0nek().Add(z0ZzZzvbj4);
				}
				return;
			}
		}
		z0eek(new z0ZzZzcbj());
	}

	internal virtual void z0eek(z0ZzZzbbj p0)
	{
		z0erk = p0;
	}

	public virtual z0ZzZzvbj z0rv(string p0)
	{
		if (z0eek())
		{
			return null;
		}
		if (!z0ark)
		{
			return null;
		}
		if (string.IsNullOrEmpty(p0))
		{
			throw new ArgumentNullException("name");
		}
		if (z0tv() == DataSourceTreeNodeType.Text)
		{
			return null;
		}
		if (z0nek() == null)
		{
			z0eek(new z0ZzZzcbj());
		}
		object obj = z0uv_jiejie20260327142557();
		if (obj is z0ZzZzoah)
		{
			if (obj is z0ZzZzsah)
			{
				z0ZzZzsah z0ZzZzsah2 = (z0ZzZzsah)obj;
				z0ZzZzfah z0ZzZzfah2 = z0ZzZzsah2.z0wg();
				if (p0[0] == '@')
				{
					string p1 = p0.Substring(1);
					z0ZzZzbsh z0ZzZzbsh2 = z0ZzZzsah2.z0sg().z0eek_jiejie20260327142557(p1);
					if (z0ZzZzbsh2 == null)
					{
						z0ZzZzbsh2 = z0ZzZzfah2.z0uek(p1);
						z0ZzZzsah2.z0sg().z0oek(z0ZzZzbsh2);
					}
					z0ZzZzvbj z0ZzZzvbj2 = new z0ZzZzvbj();
					z0ZzZzvbj2.z0eek(z0ov());
					z0ZzZzvbj2.z0eek(this);
					z0ZzZzvbj2.z0tek(p0);
					z0ZzZzvbj2.z0yv(z0ZzZzbsh2);
					z0ZzZzvbj2.z0eek((object)z0ZzZzbsh2.z0rh());
					z0ZzZzvbj2.z0bv_jiejie20260327142557(DataSourceTreeNodeType.Xml);
					z0nek().Add(z0ZzZzvbj2);
					return z0ZzZzvbj2;
				}
				z0ZzZzsah z0ZzZzsah3 = null;
				foreach (z0ZzZzoah item in ((z0ZzZzoah)z0ZzZzsah2).z0tek())
				{
					if (item.z0th() == p0)
					{
						z0ZzZzsah3 = (z0ZzZzsah)item;
						break;
					}
				}
				z0ZzZzvbj z0ZzZzvbj3 = new z0ZzZzvbj();
				if (z0ZzZzsah3 == null)
				{
					z0ZzZzsah3 = z0ZzZzfah2.z0rek(p0);
					z0ZzZzsah2.z0if(z0ZzZzsah3);
					z0ZzZzvbj3.z0prk = true;
				}
				z0ZzZzvbj3.z0eek(z0ov());
				z0ZzZzvbj3.z0eek(this);
				z0ZzZzvbj3.z0tek(p0);
				z0ZzZzvbj3.z0yv(z0ZzZzsah3);
				z0ZzZzvbj3.z0bv_jiejie20260327142557(DataSourceTreeNodeType.Xml);
				z0ZzZzvbj3.z0eek((object)z0ZzZzsah3.z0rh());
				z0nek().Add(z0ZzZzvbj3);
				return z0ZzZzvbj3;
			}
		}
		else if (z0tv() == DataSourceTreeNodeType.List)
		{
			if (z0nek() == null || z0nek().Count == 0)
			{
				z0mek();
				if (z0nek() != null && z0nek().Count > 0)
				{
					return z0nek()[0].z0eek(p0, p1: false);
				}
			}
		}
		else if (obj is IDictionary && z0tv() != DataSourceTreeNodeType.Entry)
		{
			IDictionary dictionary = (IDictionary)obj;
			z0ZzZzvbj z0ZzZzvbj4 = new z0ZzZzvbj();
			z0ZzZzvbj4.z0eek(z0ov());
			z0ZzZzvbj4.z0eek(this);
			z0ZzZzvbj4.z0tek(p0);
			z0ZzZzvbj4.z0yv(dictionary);
			z0ZzZzvbj4.z0iv(p0);
			z0ZzZzvbj4.z0rek(dictionary.IsReadOnly);
			z0ZzZzvbj4.z0bv_jiejie20260327142557(DataSourceTreeNodeType.Auto);
			z0nek().Add(z0ZzZzvbj4);
			return z0ZzZzvbj4;
		}
		return null;
	}

	public virtual string z0nv()
	{
		StringBuilder stringBuilder = new StringBuilder();
		z0ZzZzvbj z0ZzZzvbj2 = this;
		while (z0ZzZzvbj2 != null && !(z0ZzZzvbj2 is z0ZzZzbbj))
		{
			if (stringBuilder.Length > 0)
			{
				stringBuilder.Insert(0, "/");
			}
			stringBuilder.Insert(0, z0ZzZzvbj2.z0lrk());
			z0ZzZzvbj2 = z0ZzZzvbj2.z0ev();
		}
		return stringBuilder.ToString();
	}

	public object z0hrk()
	{
		return z0wrk;
	}

	public virtual void z0tek(object p0)
	{
		z0srk_jiejie20260327142557 = p0;
	}

	public object z0grk()
	{
		return z0xrk;
	}
}
