using System.ComponentModel;

namespace zzz;

public class z0ZzZzjuk
{
	private string z0eek;

	private string z0rek;

	[DefaultValue(null)]
	public string Value
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

	[DefaultValue(null)]
	[z0ZzZztqh]
	public string Name
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

	public z0ZzZzjuk()
	{
	}

	public z0ZzZzjuk Clone()
	{
		return (z0ZzZzjuk)MemberwiseClone();
	}

	public z0ZzZzjuk(string p0, string p1)
	{
		z0rek = p0;
		z0eek = p1;
	}
}
