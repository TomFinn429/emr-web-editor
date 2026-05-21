using System;
using System.ComponentModel;
using System.Globalization;
using DCSoft.Data;

namespace zzz;

public class z0ZzZzsok : ICloneable, z0ZzZzcuk
{
	public delegate string z0nmk(ValueFormatStyle style, string format, string noneText, object Value);

	private string z0rek;

	private string z0tek;

	public static z0nmk z0yek;

	private ValueFormatStyle z0uek;

	private static readonly DateTimeFormatInfo z0iek;

	[DefaultValue(null)]
	public string Format
	{
		get
		{
			return z0tek;
		}
		set
		{
			z0tek = value;
		}
	}

	[DefaultValue(ValueFormatStyle.None)]
	public ValueFormatStyle Style
	{
		get
		{
			return z0uek;
		}
		set
		{
			z0uek = value;
		}
	}

	public bool IsEmpty
	{
		get
		{
			if (z0uek == ValueFormatStyle.None)
			{
				return true;
			}
			if (z0tek != null && z0tek.Length > 0)
			{
				return false;
			}
			if (z0rek != null && z0rek.Length > 0)
			{
				return false;
			}
			return true;
		}
	}

	[DefaultValue(null)]
	public string NoneText
	{
		get
		{
			return z0rek;
		}
		set
		{
			z0rek = value;
		}
	}

	public z0ZzZzsok Clone()
	{
		return (z0ZzZzsok)((ICloneable)this).Clone();
	}

	private object z0eek()
	{
		return (z0ZzZzsok)MemberwiseClone();
	}

	object ICloneable.Clone()
	{
		//ILSpy generated this explicit interface implementation from .override directive in z0eek
		return this.z0eek();
	}

	internal static bool z0eek(string p0)
	{
		if (p0 != null)
		{
			return p0.Trim().Length > 0;
		}
		return false;
	}

	public string Execute(object Value)
	{
		if (z0uek == ValueFormatStyle.None)
		{
			if (Value == null || DBNull.Value.Equals(Value))
			{
				return null;
			}
			return Convert.ToString(Value);
		}
		return z0yek(z0uek, z0tek, z0rek, Value);
	}

	public void DCReadString(string text)
	{
		z0ZzZzmik.z0eek(this, text);
	}

	public string DCWriteString()
	{
		return z0ZzZzmik.z0rek(this, p1: true);
	}

	static z0ZzZzsok()
	{
		z0iek = new DateTimeFormatInfo();
		z0iek.DateSeparator = "/";
	}
}
