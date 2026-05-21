using System;
using System.Collections.Generic;
using System.Reflection;
using DCSoft.Writer.Dom;

namespace zzz;

public class z0ZzZzczj : z0ZzZzngh
{
	protected new XTextDocument z0uek;

	private new XTextElementList z0iek = new XTextElementList();

	internal new Dictionary<XTextContentElement, int> z0oek = new Dictionary<XTextContentElement, int>();

	private new z0ZzZzbzj z0pek;

	private XTextElementList z0mek = new XTextElementList();

	private new int z0nek;

	private int z0bek;

	private new int z0vek;

	private int z0cek;

	public void z0eek(XTextContentElement p0, int p1)
	{
		if (z0oek.ContainsKey(p0))
		{
			z0oek[p0] = Math.Min(z0oek[p0], p1);
		}
		else
		{
			z0oek[p0] = p1;
		}
	}

	public void z0eek(string p0, object p1, object p2, object p3)
	{
		if (string.IsNullOrEmpty(p0))
		{
			throw new ArgumentNullException("PropertyName");
		}
		if (p3 == null)
		{
			throw new ArgumentNullException("ObjectInstance");
		}
		Type type = p3.GetType();
		PropertyInfo property = type.GetProperty(p0, BindingFlags.IgnoreCase | BindingFlags.Instance | BindingFlags.Public);
		if (property == null)
		{
			throw new Exception(string.Format(z0ZzZziok.z0muk(), type.FullName + "!" + p0));
		}
		ParameterInfo[] indexParameters = property.GetIndexParameters();
		if (indexParameters != null && indexParameters.Length != 0)
		{
			throw new Exception(string.Format(z0ZzZziok.z0cok(), p0));
		}
		if (!property.CanWrite)
		{
			throw new Exception(string.Format(z0ZzZziok.z0bik(), p0));
		}
		Type propertyType = property.PropertyType;
		if (p1 != null)
		{
			Type type2 = p1.GetType();
			if (!type2.Equals(propertyType) && !type2.IsSubclassOf(propertyType))
			{
				throw new Exception("旧数据值类型不匹配");
			}
		}
		if (p2 != null)
		{
			Type type3 = p2.GetType();
			if (!type3.Equals(propertyType) && !type3.IsSubclassOf(propertyType))
			{
				throw new Exception("新数值类型不匹配");
			}
		}
		z0ZzZzjlh z0ZzZzjlh2 = new z0ZzZzjlh(p3, property, p1, p2);
		z0ZzZzjlh2.z0eek(z0uek);
		z0ZzZzjlh2.z0io(p0: true);
		Add(z0ZzZzjlh2);
	}

	public void z0eek(XTextTableRowElement p0, float p1)
	{
		if (p0 != null && p1 != p0.SpecifyHeight)
		{
			Add(new z0ZzZzhlh((z0ZzZzqlh)3, p1, p0.SpecifyHeight, p0));
		}
	}

	public new XTextDocument z0eek()
	{
		return z0uek;
	}

	public z0ZzZzczj(XTextDocument p0)
	{
		z0eek(p0);
	}

	internal new XTextElementList z0rek()
	{
		return z0mek;
	}

	public void z0eek(XTextContainerElement p0, int p1, XTextElementList p2, XTextElementList p3)
	{
		if (z0iek())
		{
			z0ZzZzglh z0ZzZzglh2 = new z0ZzZzglh(p0, p1, p2, p3);
			z0ZzZzglh2.z0eek(z0eek());
			z0ZzZzglh2.z0io(p0: true);
			Add(z0ZzZzglh2);
		}
	}

	public override void Clear()
	{
		base.Clear();
		if (z0iek != null)
		{
			z0iek.Clear();
		}
		if (z0oek != null)
		{
			z0oek.Clear();
		}
		if (z0mek != null)
		{
			z0mek.Clear();
		}
	}

	public new z0ZzZzbzj z0tek()
	{
		return z0pek;
	}

	public void z0eek(z0ZzZzbzj p0)
	{
		if (z0iek())
		{
			z0ZzZzklh undo = new z0ZzZzklh(p0);
			Add(undo);
		}
	}

	public void z0eek(z0ZzZzqlh p0, object p1, object p2, XTextElement p3)
	{
		z0ZzZzhlh z0ZzZzhlh2 = new z0ZzZzhlh(p0, p1, p2, p3);
		((z0ZzZzxzj)z0ZzZzhlh2).z0eek(z0uek);
		z0ZzZzhlh2.z0io(p0: true);
		Add(z0ZzZzhlh2);
	}

	protected override z0ZzZzmgh z0vo()
	{
		z0ZzZzvzj obj = new z0ZzZzvzj(z0uek);
		obj.z0rek(z0bek);
		obj.z0yek(z0vek);
		obj.z0tek(z0cek);
		obj.z0eek(z0nek);
		return obj;
	}

	public override void z0bo()
	{
		base.z0bo();
		z0mek.Clear();
	}

	public void z0eek(XTextElement p0, int p1, int p2)
	{
		z0ZzZzalh z0ZzZzalh2 = new z0ZzZzalh(p0, p1, p2);
		z0ZzZzalh2.z0eek(z0uek);
		z0ZzZzalh2.z0io(p0: true);
		Add(z0ZzZzalh2);
	}

	public void z0rek(z0ZzZzbzj p0)
	{
		z0pek = p0;
	}

	public void z0eek(XTextElement p0, bool p1, bool p2)
	{
		z0ZzZzzzj z0ZzZzzzj2 = new z0ZzZzzzj(p0, p1, p2);
		z0ZzZzzzj2.z0eek(z0uek);
		z0ZzZzzzj2.z0io(p0: true);
		Add(z0ZzZzzzj2);
	}

	public void z0eek(XTextContainerElement p0, int p1, XTextElementList p2)
	{
		if (z0iek())
		{
			z0ZzZzglh z0ZzZzglh2 = new z0ZzZzglh(p0, p1, p2, null);
			z0ZzZzglh2.z0eek(z0eek());
			z0ZzZzglh2.z0io(p0: true);
			Add(z0ZzZzglh2);
		}
	}

	protected override bool z0no()
	{
		return true;
	}

	public override bool z0mo()
	{
		if (base.z0mo())
		{
			z0mek.Clear();
			z0bek = z0eek().z0jrk().z0oek().z0nek();
			z0vek = z0eek().z0jrk().z0oek().z0qrk();
			return true;
		}
		return false;
	}

	public override void Dispose()
	{
		base.Dispose();
		Clear();
		z0iek = null;
		z0oek = null;
		z0mek = null;
	}

	public XTextElementList z0yek_jiejie20260327142557()
	{
		return z0iek;
	}

	public void z0eek(XTextDocument p0)
	{
		z0uek = p0;
	}

	public override bool z0po()
	{
		z0mek.Clear();
		if (z0eek() != null && z0eek().z0jrk() != null && z0eek().z0jrk().z0oek() != null)
		{
			z0cek = z0eek().z0jrk().z0oek().z0nek();
			z0nek = z0eek().z0jrk().z0oek().z0qrk();
		}
		else
		{
			z0cek = 0;
			z0nek = 0;
		}
		List<z0ZzZzogh> list = base.z0eek();
		if (list != null && list.Count > 0)
		{
			foreach (z0ZzZzogh item in list)
			{
				if (item is z0ZzZzxzj)
				{
					((z0ZzZzxzj)item).z0eek(z0eek());
				}
			}
		}
		return base.z0po();
	}
}
