using System.ComponentModel;

namespace DCSoft.Writer.Security;

public class UserLoginInfo
{
	private string z0eek;

	private string z0rek;

	private string z0tek;

	private int z0yek;

	private string z0uek;

	private string z0iek;

	private string z0oek;

	[DefaultValue(null)]
	public string Name
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

	[DefaultValue(null)]
	public string Description
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

	public string Name2
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

	[DefaultValue(0)]
	public int PermissionLevel
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

	[DefaultValue(null)]
	public string Tag
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

	[DefaultValue(null)]
	public string ID
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

	public string ClientName
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
}
