using System;
using System.Reflection;
using DCSoft.Writer.Security;
using DCSystem_Drawing;
using zzz;

namespace DCSoft.Writer;

public class DocumentOptions : ICloneable
{
	private DocumentViewOptions z0yek = new DocumentViewOptions();

	private DocumentBehaviorOptions z0uek = new DocumentBehaviorOptions();

	[NonSerialized]
	private z0ZzZzqbj z0iek;

	private DocumentEditOptions z0oek = new DocumentEditOptions();

	private DocumentSecurityOptions z0pek = new DocumentSecurityOptions();

	public DocumentViewOptions ViewOptions
	{
		get
		{
			if (z0yek == null)
			{
				z0yek = new DocumentViewOptions();
			}
			return z0yek;
		}
		set
		{
			z0yek = value;
		}
	}

	public DocumentBehaviorOptions BehaviorOptions
	{
		get
		{
			if (z0uek == null)
			{
				z0uek = new DocumentBehaviorOptions();
			}
			return z0uek;
		}
		set
		{
			z0uek = value;
		}
	}

	public DocumentEditOptions EditOptions
	{
		get
		{
			if (z0oek == null)
			{
				z0oek = new DocumentEditOptions();
			}
			return z0oek;
		}
		set
		{
			z0oek = value;
		}
	}

	public DocumentSecurityOptions SecurityOptions
	{
		get
		{
			if (z0pek == null)
			{
				z0pek = new DocumentSecurityOptions();
			}
			return z0pek;
		}
		set
		{
			z0pek = value;
		}
	}

	internal void z0eek()
	{
		z0uek = null;
		z0oek = null;
		z0pek = null;
		z0yek = null;
		z0iek = null;
	}

	internal void z0eek(z0ZzZzqbj p0)
	{
		z0iek = p0;
	}

	public DocumentOptions z0rek()
	{
		return (DocumentOptions)((ICloneable)this).Clone();
	}

	private bool z0eek(string p0, ref PropertyInfo p1, ref object p2)
	{
		int num = p0.IndexOf('.');
		if (num > 0)
		{
			string text = p0.Substring(0, num).Trim();
			string text2 = p0.Substring(num + 1).Trim();
			PropertyInfo property = GetType().GetProperty(text, BindingFlags.IgnoreCase | BindingFlags.Instance | BindingFlags.Public);
			if (property != null)
			{
				object value = property.GetValue(this, null);
				if (value != null)
				{
					PropertyInfo property2 = value.GetType().GetProperty(text2, BindingFlags.IgnoreCase | BindingFlags.Instance | BindingFlags.Public);
					if (property2 != null)
					{
						p1 = property2;
						p2 = value;
						return true;
					}
				}
			}
		}
		return false;
	}

	public bool z0eek(string p0, string p1)
	{
		if (string.IsNullOrEmpty(p0))
		{
			throw new ArgumentNullException("name");
		}
		PropertyInfo p2 = null;
		object p3 = null;
		if (z0eek(p0, ref p2, ref p3))
		{
			if (!string.IsNullOrEmpty(p1) && p2.PropertyType.Equals(typeof(Color)))
			{
				Color color = z0ZzZzlok.z0eek(p1, Color.Black);
				p2.SetValue(p3, color, null);
				return true;
			}
			return z0ZzZzmik.z0eek(p3, p2.Name, p1, p3: false);
		}
		return false;
	}

	public string z0eek(string p0)
	{
		if (string.IsNullOrEmpty(p0))
		{
			throw new ArgumentNullException("name");
		}
		PropertyInfo p1 = null;
		object p2 = null;
		if (z0eek(p0, ref p1, ref p2))
		{
			object value = p1.GetValue(p2, null);
			if (value == null || DBNull.Value.Equals(value))
			{
				return null;
			}
			if (value is Color)
			{
				return z0ZzZzlok.z0eek((Color)value);
			}
			if (value is DateTime)
			{
				return z0ZzZzuyk.z0rek((DateTime)value);
			}
			return value.ToString();
		}
		return null;
	}

	private object z0tek()
	{
		DocumentOptions documentOptions = new DocumentOptions();
		if (z0oek != null)
		{
			documentOptions.z0oek = z0oek.Clone();
		}
		if (z0yek != null)
		{
			documentOptions.z0yek = z0yek.Clone();
		}
		if (z0uek != null)
		{
			documentOptions.z0uek = z0uek.Clone();
		}
		if (z0pek != null)
		{
			documentOptions.z0pek = z0pek.Clone();
		}
		return documentOptions;
	}

	object ICloneable.Clone()
	{
		//ILSpy generated this explicit interface implementation from .override directive in z0tek
		return this.z0tek();
	}
}
