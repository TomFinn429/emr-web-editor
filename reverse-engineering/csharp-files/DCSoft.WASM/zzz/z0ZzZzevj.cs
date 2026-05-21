using System;
using System.ComponentModel;
using DCSoft.Writer;

namespace zzz;

public class z0ZzZzevj : ICloneable, z0ZzZzcuk
{
	private int z0mek = 1;

	private string z0nek;

	private string z0bek;

	private string z0cek;

	private string z0xek;

	[z0ZzZzyqh]
	[DefaultValue(null)]
	public string BindingPathForText
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

	[DefaultValue(null)]
	public string DataSource
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

	public bool IsEmptyBinding
	{
		get
		{
			if (string.IsNullOrEmpty(z0nek) && string.IsNullOrEmpty(z0cek))
			{
				return string.IsNullOrEmpty(z0bek);
			}
			return false;
		}
	}

	[DefaultValue(null)]
	public string BindingPath
	{
		get
		{
			return z0cek;
		}
		set
		{
			z0cek = value;
		}
	}

	[DefaultValue(DCProcessStates.Always)]
	public DCProcessStates ProcessState
	{
		get
		{
			return (DCProcessStates)z0ZzZzafh.z0yek(z0mek, 8, 16);
		}
		set
		{
			z0mek = z0ZzZzafh.z0yek(z0mek, 8, 16, (int)value);
		}
	}

	[DefaultValue(null)]
	public string WriteTextBindingPath
	{
		get
		{
			return z0xek;
		}
		set
		{
			z0xek = value;
		}
	}

	public bool z0eek()
	{
		return (z0mek & 1) != 0;
	}

	public z0ZzZzevj(string p0, string p1)
	{
		z0nek = p0;
		z0cek = p1;
	}

	public override string ToString()
	{
		return z0ZzZzmik.z0rek(this, p1: true);
	}

	public string DCWriteString()
	{
		return z0ZzZzmik.z0rek(this, p1: true);
	}

	public bool z0rek()
	{
		return (z0mek & 4) != 0;
	}

	public z0ZzZzevj()
	{
	}

	public z0ZzZzevj Clone()
	{
		return (z0ZzZzevj)((ICloneable)this).Clone();
	}

	private object z0tek()
	{
		return (z0ZzZzevj)MemberwiseClone();
	}

	object ICloneable.Clone()
	{
		//ILSpy generated this explicit interface implementation from .override directive in z0tek
		return this.z0tek();
	}

	public void DCReadString(string text)
	{
		z0ZzZzmik.z0eek(this, text);
	}

	public bool z0yek()
	{
		return (z0mek & 2) != 0;
	}

	public bool z0uek()
	{
		return (z0mek & 4) != 0;
	}

	public void z0eek(bool p0)
	{
		z0mek = (p0 ? (z0mek | 4) : (z0mek & -5));
	}

	public void z0rek(bool p0)
	{
		z0mek = (p0 ? (z0mek | 4) : (z0mek & -5));
	}

	public void z0tek(bool p0)
	{
		z0mek = (p0 ? (z0mek | 1) : (z0mek & -2));
	}

	public void z0yek(bool p0)
	{
		z0mek = (p0 ? (z0mek | 2) : (z0mek & -3));
	}
}
