using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using DCSoft.Writer.Data;

namespace zzz;

[DebuggerTypeProxy(typeof(z0ZzZzkik))]
[DefaultMember("Item")]
[DebuggerDisplay("Count={ Count }")]
public class z0ZzZzkvj : List<DocumentParameter>, ICloneable
{
	public DocumentParameter z0eek(string p0)
	{
		using (Enumerator enumerator = GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				DocumentParameter current = enumerator.Current;
				if (string.Compare(current.z0eek(), p0, true) == 0)
				{
					return current;
				}
			}
		}
		return null;
	}

	public object z0rek(string p0)
	{
		return z0eek(p0)?.z0bek();
	}

	public void z0eek(string p0, string p1)
	{
		z0ZzZzfah z0ZzZzfah2 = new z0ZzZzfah();
		if (string.IsNullOrEmpty(p1))
		{
			z0ZzZzfah2.z0eek("<a/>");
		}
		else
		{
			try
			{
				z0ZzZzfah2.z0eek(p1);
			}
			catch (Exception ex)
			{
				string text = "ERROR!!SetXmlValue:" + ex.Message + ",XML:" + Environment.NewLine + p1;
				z0ZzZzqok.z0rek.z0dh(text);
				throw new Exception(text);
			}
		}
		z0eek(p0, z0ZzZzfah2.z0uek());
	}

	public string z0tek_jiejie20260327142557(string p0)
	{
		object obj = z0rek(p0);
		if (obj is z0ZzZzoah)
		{
			return ((z0ZzZzoah)obj).z0uek();
		}
		return null;
	}

	public void z0eek(string p0, object p1)
	{
		DocumentParameter documentParameter = z0eek(p0);
		if (documentParameter == null)
		{
			documentParameter = new DocumentParameter();
			documentParameter.z0iek(p0);
			documentParameter.z0eek(p1);
			Add(documentParameter);
		}
		else
		{
			documentParameter.z0eek(p1);
		}
	}

	private object z0eek()
	{
		z0ZzZzkvj z0ZzZzkvj2 = new z0ZzZzkvj();
		using Enumerator enumerator = GetEnumerator();
		while (enumerator.MoveNext())
		{
			DocumentParameter current = enumerator.Current;
			z0ZzZzkvj2.Add(current.z0oek());
		}
		return z0ZzZzkvj2;
	}

	object ICloneable.Clone()
	{
		//ILSpy generated this explicit interface implementation from .override directive in z0eek
		return this.z0eek();
	}

	public bool z0yek(string p0)
	{
		return z0eek(p0) != null;
	}

	public void z0eek(z0ZzZzkvj p0)
	{
		if (p0 == null)
		{
			return;
		}
		using Enumerator enumerator = GetEnumerator();
		while (enumerator.MoveNext())
		{
			DocumentParameter current = enumerator.Current;
			p0.z0eek(current.z0eek(), current.z0bek());
		}
	}

	public z0ZzZzkvj z0rek()
	{
		return (z0ZzZzkvj)((ICloneable)this).Clone();
	}
}
