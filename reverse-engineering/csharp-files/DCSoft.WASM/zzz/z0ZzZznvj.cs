using System;
using DCSystem_Drawing;

namespace zzz;

public class z0ZzZznvj : z0ZzZzeqh
{
	private bool z0uek;

	private string z0iek;

	private object z0oek;

	public z0ZzZznvj(object p0)
	{
		z0oek = p0;
	}

	public z0ZzZznvj z0eek()
	{
		return (z0ZzZznvj)MemberwiseClone();
	}

	public z0ZzZznvj()
	{
	}

	public string z0rek()
	{
		return z0iek;
	}

	public bool z0tek()
	{
		return z0uek;
	}

	public void z0eek(object p0)
	{
		z0oek = p0;
	}

	public object z0yek()
	{
		return z0oek;
	}

	private bool z0eek(Type p0)
	{
		if (p0 == typeof(string) || p0 == typeof(DateTime) || p0 == typeof(Color) || p0.IsPrimitive || p0.IsEnum)
		{
			return true;
		}
		return false;
	}

	public void z0eek(bool p0)
	{
		z0uek = p0;
	}

	public override string ToString()
	{
		return z0rek() + ":" + z0yek();
	}

	public void z0eek(string p0)
	{
		z0iek = p0;
	}

	public void z0ob(z0ZzZzcah p0)
	{
		p0.z0ia();
	}

	public void z0ib(z0ZzZzhqh p0)
	{
		if (z0yek() == null || DBNull.Value.Equals(z0yek()))
		{
			return;
		}
		if (z0yek() is z0ZzZzsah && z0tek() && !string.IsNullOrEmpty(z0iek))
		{
			p0.z0eek("TypeName", z0iek);
			p0.z0eek("AutoConvertToXMLElement", "true");
			((z0ZzZzsah)z0yek()).z0eh(p0);
			return;
		}
		Type type = z0oek.GetType();
		if (z0yek() is z0ZzZzfah)
		{
			p0.z0eek("TypeName", "DCSystemXml.XmlDocument");
			((z0ZzZzfah)z0yek()).z0eh(p0);
			return;
		}
		if (z0yek() is z0ZzZzsah)
		{
			p0.z0eek("TypeName", "DCSystemXml.XmlElement");
			((z0ZzZzsah)z0yek()).z0eh(p0);
			return;
		}
		z0iek = z0ZzZzwnj.z0eek(type);
		p0.z0eek("TypeName", z0iek);
		if (z0eek(type))
		{
			if (z0tek())
			{
				p0.z0eek("AutoConvertToXMLElement", "true");
			}
			string empty = string.Empty;
			empty = ((type == typeof(string)) ? ((string)z0oek) : ((!(z0oek is DateTime)) ? z0oek.ToString() : ((DateTime)z0oek).ToString()));
			p0.z0yg(empty);
		}
	}
}
