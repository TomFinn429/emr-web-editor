using zzz;

namespace DCSoft.Writer.Data;

public class ListSourceEventArgs
{
	private z0ZzZzlfh z0eek;

	private object z0rek;

	private z0ZzZzmvj z0tek;

	private z0ZzZzsvj z0yek;

	public z0ZzZzlfh Host
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

	public z0ZzZzmvj Services
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

	public object Value
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

	public z0ZzZzsvj Info
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

	public ListSourceEventArgs(z0ZzZzlfh host, z0ZzZzmvj services, z0ZzZzsvj info)
	{
		z0eek = host;
		z0tek = services;
		z0yek = info;
	}
}
