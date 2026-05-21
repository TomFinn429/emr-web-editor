using System;
using System.Collections.Generic;
using System.Text;
using DCSoft.Writer.Data;

namespace zzz;

public class z0ZzZzbbj : z0ZzZzvbj
{
	[NonSerialized]
	[z0ZzZzuqh]
	public new z0ZzZzqvj z0yek;

	private new string z0uek = "Item";

	private new bool z0iek;

	private new char z0oek = '/';

	public override void z0bv_jiejie20260327142557(DataSourceTreeNodeType p0)
	{
	}

	public virtual bool z0eek(Type p0)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("t");
		}
		return z0ZzZznok.GetCollectionItemType(p0, checkAddMethod: false) != null;
	}

	public override string z0nv()
	{
		return null;
	}

	public void z0eek(char p0)
	{
		z0oek = p0;
	}

	public void z0eek(string p0, object p1)
	{
		z0ZzZzvbj z0ZzZzvbj2 = new z0ZzZzvbj();
		z0ZzZzvbj2.z0tek(p0);
		z0ZzZzvbj2.z0yv(p1);
		z0ZzZzvbj2.z0bv_jiejie20260327142557(DataSourceTreeNodeType.Auto);
		z0ZzZzvbj2.z0eek((z0ZzZzvbj)this);
		z0ZzZzvbj2.z0eek(this);
		z0nek().Add(z0ZzZzvbj2);
	}

	public override string z0mv()
	{
		return null;
	}

	public override object z0pv()
	{
		return null;
	}

	public new virtual string z0eek(string p0)
	{
		string[] array = z0rek(p0);
		if (array != null && array.Length != 0)
		{
			StringBuilder stringBuilder = new StringBuilder();
			string[] array2 = array;
			foreach (string text in array2)
			{
				if (stringBuilder.Length > 0)
				{
					stringBuilder.Append(z0tek());
					if (z0rek())
					{
						stringBuilder.Append(z0eek());
						stringBuilder.Append(z0tek());
					}
				}
				if (z0rek())
				{
					stringBuilder.Append(text);
				}
				else
				{
					stringBuilder.Append(text);
				}
			}
			return stringBuilder.ToString();
		}
		return null;
	}

	public new string z0eek()
	{
		return z0uek;
	}

	public z0ZzZzbbj()
	{
		z0eek(new z0ZzZzcbj());
	}

	public override z0ZzZzbbj z0ov()
	{
		return this;
	}

	public override void z0iv(string p0)
	{
	}

	public override object z0uv_jiejie20260327142557()
	{
		return null;
	}

	public new bool z0rek()
	{
		return z0iek;
	}

	public override void z0yv(object p0)
	{
	}

	public override DataSourceTreeNodeType z0tv()
	{
		return DataSourceTreeNodeType.Auto;
	}

	public new char z0tek()
	{
		return z0oek;
	}

	public override z0ZzZzvbj z0rv(string p0)
	{
		if (z0yek != null)
		{
			z0ZzZzavj z0ZzZzavj2 = new z0ZzZzavj(this, p0);
			z0yek(this, z0ZzZzavj2);
			if (z0ZzZzavj2.z0eek() != null)
			{
				z0ZzZzvbj z0ZzZzvbj2 = new z0ZzZzvbj();
				z0ZzZzvbj2.z0tek(p0);
				z0ZzZzvbj2.z0yv(z0ZzZzavj2.z0eek());
				z0ZzZzvbj2.z0bv_jiejie20260327142557(DataSourceTreeNodeType.Auto);
				z0nek().Add(z0ZzZzvbj2);
				return z0ZzZzvbj2;
			}
		}
		return null;
	}

	public new void z0eek(bool p0)
	{
		z0iek = p0;
	}

	public new virtual string[] z0rek(string p0)
	{
		if (p0 == null || p0.Length == 0)
		{
			return null;
		}
		string[] array = p0.Split(z0tek());
		List<string> list = new List<string>();
		string[] array2 = array;
		for (int i = 0; i < array2.Length; i++)
		{
			string text = array2[i].Trim();
			if (text.Length > 0)
			{
				list.Add(text);
			}
		}
		return list.ToArray();
	}

	public override z0ZzZzvbj z0ev()
	{
		return null;
	}

	public new void z0tek(string p0)
	{
		z0uek = p0;
	}
}
