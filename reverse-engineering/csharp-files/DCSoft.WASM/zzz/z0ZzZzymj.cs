using System;
using DCSoft.Writer.Dom;

namespace zzz;

public class z0ZzZzymj
{
	private z0ZzZztmj z0rek;

	private z0ZzZzbmj z0tek;

	[NonSerialized]
	private z0ZzZzdbj z0yek;

	public z0ZzZztmj CommandContainer
	{
		get
		{
			if (z0rek == null)
			{
				z0rek = new z0ZzZztmj();
			}
			return z0rek;
		}
		set
		{
			z0rek = value;
		}
	}

	public XTextDocument Document => z0yek?.z0ruk();

	public z0ZzZzdbj EditControl
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

	private z0ZzZzbmj z0eek()
	{
		if (z0ZzZzxvj.z0eek && z0ZzZzuyk.z0eek().Ticks % 10 > 9)
		{
			return null;
		}
		if (z0tek == null)
		{
			z0tek = z0ZzZzuok.z0eek<z0ZzZzbmj>();
		}
		if (z0tek != null)
		{
			z0tek.z0eek_jiejie20260327142557(this);
		}
		return z0tek;
	}

	public z0ZzZzrmj GetCommand(string name)
	{
		return CommandContainer.z0rek(name);
	}

	public bool IsCommandSupported(string commandName)
	{
		if (z0eek() != null)
		{
			return z0eek().z0wz(commandName);
		}
		return false;
	}

	public bool IsCommandChecked(string commandName)
	{
		if (z0eek() != null)
		{
			return z0eek().z0rz(commandName);
		}
		return false;
	}

	public object ExecuteCommand(string commandName, bool showUI, object parameter)
	{
		if (z0eek() != null)
		{
			return z0eek().z0yz(commandName, showUI, parameter);
		}
		return null;
	}

	public object z0eek(string p0, bool p1, object p2, bool p3)
	{
		if (z0eek() != null)
		{
			return z0eek().z0tz(p0, p1, p2, p3);
		}
		return null;
	}

	public void Start()
	{
		if (z0rek == null)
		{
			z0rek = z0ZzZzlfh.z0iek().z0yek();
			z0rek.z0rek().z0rek();
		}
		if (z0eek() != null)
		{
			z0eek().z0uz();
		}
	}

	public bool IsCommandEnabled(string commandName)
	{
		if (z0eek() != null)
		{
			return z0eek().z0ez(commandName);
		}
		return false;
	}
}
