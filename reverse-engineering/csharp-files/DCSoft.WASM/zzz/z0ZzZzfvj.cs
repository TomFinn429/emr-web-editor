using System;
using System.ComponentModel;

namespace zzz;

public class z0ZzZzfvj : z0ZzZzcuk
{
	private bool z0rek;

	private string z0tek;

	private string z0yek;

	private bool z0uek;

	private bool z0iek = true;

	[NonSerialized]
	private object z0oek;

	private string z0pek;

	private z0ZzZzikh z0mek;

	[DefaultValue((z0ZzZzikh)0)]
	public z0ZzZzikh NextTarget
	{
		get
		{
			return z0mek;
		}
		set
		{
			z0mek = value;
		}
	}

	[DefaultValue(true)]
	public bool AutoUpdateTargetElement
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
	public string NextTargetID
	{
		get
		{
			return z0yek;
		}
		set
		{
			z0yek = value;
		}
	}

	[DefaultValue(false)]
	public bool IsRoot
	{
		get
		{
			return z0uek;
		}
		set
		{
			z0uek = value;
			z0oek = null;
		}
	}

	[DefaultValue(null)]
	public string UserFlag
	{
		get
		{
			return z0pek;
		}
		set
		{
			z0pek = value;
		}
	}

	[DefaultValue(null)]
	[z0ZzZzuqh]
	public object DataBoundItem
	{
		get
		{
			return z0oek;
		}
		set
		{
			z0oek = value;
		}
	}

	[DefaultValue(false)]
	public bool AutoSetFirstItems
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

	[DefaultValue(null)]
	public string ProviderName
	{
		get
		{
			return z0tek;
		}
		set
		{
			z0tek = value;
			z0oek = null;
		}
	}

	public z0ZzZzfvj z0eek()
	{
		return (z0ZzZzfvj)MemberwiseClone();
	}

	public string DCWriteString()
	{
		return z0ZzZzmik.z0rek(this, p1: true);
	}

	public void DCReadString(string text)
	{
		z0ZzZzmik.z0eek(this, text);
	}
}
