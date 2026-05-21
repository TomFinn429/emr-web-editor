using System;
using System.ComponentModel;
using zzz;

namespace DCSoft.Writer.Data;

[z0ZzZziqh]
public class ListItem : ICloneable
{
	private DateTime z0iek = z0ZzZzkfh.z0wrk;

	private string z0oek;

	private string z0pek;

	private string z0mek;

	private bool z0nek;

	private string z0bek;

	private string z0vek;

	private string z0cek;

	private int z0xek;

	private string z0zek;

	[DefaultValue(null)]
	public string Value
	{
		get
		{
			return z0cek;
		}
		set
		{
			if (z0cek != value)
			{
				z0cek = value;
				z0rek();
			}
		}
	}

	[DefaultValue(null)]
	public virtual string EntryID
	{
		get
		{
			return z0oek;
		}
		set
		{
			if (z0oek != value)
			{
				z0oek = value;
				z0rek();
			}
		}
	}

	[DefaultValue(false)]
	public bool LonelyChecked
	{
		get
		{
			return z0nek;
		}
		set
		{
			z0nek = value;
		}
	}

	[DefaultValue(null)]
	public string Group
	{
		get
		{
			return z0vek;
		}
		set
		{
			if (z0vek != value)
			{
				z0vek = value;
				z0rek();
			}
		}
	}

	[DefaultValue(null)]
	public string TextInList
	{
		get
		{
			return z0bek;
		}
		set
		{
			z0bek = value;
		}
	}

	[DefaultValue(typeof(DateTime), "1980-1-1")]
	public DateTime CheckedTime
	{
		get
		{
			return z0iek;
		}
		set
		{
			z0iek = value;
		}
	}

	[DefaultValue(null)]
	public string Tag
	{
		get
		{
			return z0zek;
		}
		set
		{
			if (z0zek != value)
			{
				z0zek = value;
				z0rek();
			}
		}
	}

	[DefaultValue(0)]
	public int ListIndex
	{
		get
		{
			return z0xek;
		}
		set
		{
			if (z0xek != value)
			{
				z0xek = value;
				z0rek();
			}
		}
	}

	[DefaultValue(null)]
	public string Text
	{
		get
		{
			return z0mek;
		}
		set
		{
			if (z0mek != value)
			{
				z0mek = value;
				z0rek();
			}
		}
	}

	public string z0eek()
	{
		if (z0cek != null && z0cek.Length > 0)
		{
			return z0cek;
		}
		return z0mek;
	}

	public override string ToString()
	{
		return Text + "=" + Value;
	}

	private void z0rek()
	{
	}

	public ListItem z0tek()
	{
		return (ListItem)((ICloneable)this).Clone();
	}

	private object z0yek()
	{
		return MemberwiseClone();
	}

	object ICloneable.Clone()
	{
		//ILSpy generated this explicit interface implementation from .override directive in z0yek
		return this.z0yek();
	}

	public ListItem()
	{
	}

	internal ListItem(string strText, string strValue)
	{
		z0mek = strText;
		z0cek = strValue;
	}

	public virtual void z0eek(string p0)
	{
		if (z0pek != p0)
		{
			z0pek = p0;
			z0rek();
		}
	}

	public virtual string z0uek()
	{
		return z0pek;
	}
}
