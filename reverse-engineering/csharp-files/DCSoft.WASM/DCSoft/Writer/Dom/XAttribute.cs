using System;
using System.ComponentModel;

namespace DCSoft.Writer.Dom;

public class XAttribute : ICloneable
{
	private string z0tek;

	private string z0yek;

	public static XAttribute z0uek = new XAttribute();

	[DefaultValue(null)]
	public string Value => z0yek;

	[DefaultValue(null)]
	public string Name => z0tek;

	private object z0eek()
	{
		return MemberwiseClone();
	}

	object ICloneable.Clone()
	{
		//ILSpy generated this explicit interface implementation from .override directive in z0eek
		return this.z0eek();
	}

	public XAttribute(string name, string Value)
	{
		z0tek = name;
		z0yek = Value;
	}

	public XAttribute()
	{
	}

	internal void z0eek(string p0)
	{
		z0tek = p0;
	}

	internal void z0rek(string p0)
	{
		z0yek = p0;
	}

	public XAttribute Clone()
	{
		return (XAttribute)((ICloneable)this).Clone();
	}

	public override string ToString()
	{
		return Name + "=" + Value;
	}
}
