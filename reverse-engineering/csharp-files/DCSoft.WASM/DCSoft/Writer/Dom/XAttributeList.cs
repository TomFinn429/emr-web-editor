using System;
using System.Diagnostics;
using System.Reflection;
using System.Text;
using zzz;

namespace DCSoft.Writer.Dom;

[DebuggerTypeProxy(typeof(z0ZzZzkik))]
[DefaultMember("Item")]
[DebuggerDisplay("Count={ Count }")]
public class XAttributeList : zzz.z0ZzZzkuk<XAttribute>, ICloneable, z0ZzZzcuk
{
	public void DCReadString(string text)
	{
		Clear();
		foreach (z0ZzZzqyk item in new z0ZzZzsyk(text))
		{
			Add(new XAttribute(item.z0eek(), item.z0rek()));
		}
	}

	public XAttributeList z0eek()
	{
		return (XAttributeList)((ICloneable)this).Clone();
	}

	public XAttribute z0eek(string p0)
	{
		using (z0bpk z0bpk = z0ltk())
		{
			while (z0bpk.MoveNext())
			{
				XAttribute current = z0bpk.Current;
				if (current.Name == p0)
				{
					return current;
				}
			}
		}
		return null;
	}

	public string DCWriteString()
	{
		z0ZzZzayk z0ZzZzayk = new z0ZzZzayk();
		using (z0bpk z0bpk = z0ltk())
		{
			while (z0bpk.MoveNext())
			{
				XAttribute current = z0bpk.Current;
				z0ZzZzayk.z0eek(current.Name, current.Value);
			}
		}
		return z0ZzZzayk.ToString();
	}

	public XAttributeList(int capacity)
		: base(capacity)
	{
	}

	public void z0rek(string p0)
	{
		XAttribute xAttribute = z0eek(p0);
		if (xAttribute != null)
		{
			Remove(xAttribute);
		}
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder();
		using (z0bpk z0bpk = z0ltk())
		{
			while (z0bpk.MoveNext())
			{
				XAttribute current = z0bpk.Current;
				stringBuilder.Append(current.Name + "=" + current.Value);
				if (stringBuilder.Length > 250)
				{
					break;
				}
			}
		}
		stringBuilder.Insert(0, base.Count + " Items:");
		return stringBuilder.ToString();
	}

	public XAttributeList()
	{
	}

	public bool z0tek(string p0)
	{
		return z0eek(p0) != null;
	}

	public void z0eek(string p0, string p1)
	{
		XAttribute xAttribute = z0eek(p0);
		if (string.IsNullOrEmpty(p1))
		{
			if (xAttribute != null)
			{
				Remove(xAttribute);
			}
		}
		else if (xAttribute == null)
		{
			xAttribute = new XAttribute(p0, p1);
			Add(xAttribute);
		}
		else
		{
			int index = IndexOf(xAttribute);
			base[index] = new XAttribute(p0, p1);
		}
	}

	private object z0rek()
	{
		XAttributeList xAttributeList = new XAttributeList(base.Count);
		using z0bpk z0bpk = z0ltk();
		while (z0bpk.MoveNext())
		{
			XAttribute current = z0bpk.Current;
			xAttributeList.Add(current.Clone());
		}
		return xAttributeList;
	}

	object ICloneable.Clone()
	{
		//ILSpy generated this explicit interface implementation from .override directive in z0rek
		return this.z0rek();
	}

	public string z0yek(string p0)
	{
		return z0eek(p0)?.Value;
	}
}
