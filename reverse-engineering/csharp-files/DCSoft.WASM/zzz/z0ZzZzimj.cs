using System;
using System.Windows.Forms;

namespace zzz;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false)]
public sealed class z0ZzZzimj : Attribute
{
	private string z0eek;

	private object z0rek;

	private bool z0tek_jiejie20260327142557;

	private string z0yek;

	private int z0uek;

	private Type z0iek;

	private string z0oek;

	private Keys z0pek;

	private int z0mek = 10;

	public object DefaultResultValue
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

	public Type ReturnValueType
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

	public bool CanModifyContent
	{
		get
		{
			return z0tek_jiejie20260327142557;
		}
		set
		{
			z0tek_jiejie20260327142557 = value;
		}
	}

	public string Description
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

	public Keys ShortcutKey
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

	public string Name
	{
		get
		{
			return z0eek;
		}
		set
		{
			z0eek = value;
		}
	}

	public string ImageResource
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

	public int Priority
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

	public int FunctionID
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

	public z0ZzZzimj(string p0)
	{
		z0eek = p0;
	}

	public z0ZzZzimj()
	{
	}
}
