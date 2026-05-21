using System;
using System.Diagnostics;
using DCSoft.Writer.Data;

namespace zzz;

[DebuggerTypeProxy(typeof(z0ZzZzkik))]
[z0ZzZziqh("ListItems")]
public class z0ZzZzdvj : zzz.z0ZzZzkuk<ListItem>, ICloneable
{
	[NonSerialized]
	private new bool z0yek = true;

	public string z0eek(string p0)
	{
		foreach (ListItem item in z0xrk())
		{
			if (item.Text == p0)
			{
				return item.Value;
			}
		}
		return null;
	}

	public bool z0eek()
	{
		return z0yek;
	}

	private object z0rek()
	{
		z0ZzZzdvj z0ZzZzdvj2 = new z0ZzZzdvj();
		using z0bpk z0bpk = z0ltk();
		while (z0bpk.MoveNext())
		{
			ListItem current = z0bpk.Current;
			z0ZzZzdvj2.Add(current.z0tek());
		}
		return z0ZzZzdvj2;
	}

	object ICloneable.Clone()
	{
		//ILSpy generated this explicit interface implementation from .override directive in z0rek
		return this.z0rek();
	}

	public z0ZzZzdvj z0tek()
	{
		return (z0ZzZzdvj)((ICloneable)this).Clone();
	}

	public void z0eek(bool p0)
	{
		z0yek = p0;
	}

	public override string ToString()
	{
		if (base.Count == 0)
		{
			return string.Empty;
		}
		return string.Format(z0ZzZziok.z0ntk(), base.Count);
	}

	public string z0rek(string p0)
	{
		using (z0bpk z0bpk = z0ltk())
		{
			while (z0bpk.MoveNext())
			{
				ListItem current = z0bpk.Current;
				if (current.Value == p0)
				{
					return current.Text;
				}
			}
		}
		return null;
	}
}
