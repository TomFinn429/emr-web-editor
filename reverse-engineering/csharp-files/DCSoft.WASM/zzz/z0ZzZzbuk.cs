using System.ComponentModel;

namespace zzz;

public class z0ZzZzbuk
{
	private string z0rek;

	private string z0tek;

	private string z0yek;

	[DefaultValue(null)]
	public string Target
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

	public bool IsEmpty => string.IsNullOrEmpty(z0rek);

	[DefaultValue(null)]
	public string Title
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
	public string Reference
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

	public z0ZzZzbuk z0eek()
	{
		return (z0ZzZzbuk)MemberwiseClone();
	}
}
