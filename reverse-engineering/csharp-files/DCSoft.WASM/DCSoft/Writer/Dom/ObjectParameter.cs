using System.ComponentModel;
using zzz;

namespace DCSoft.Writer.Dom;

public class ObjectParameter
{
	private string z0rek;

	private string z0tek;

	[DefaultValue(null)]
	public string Value
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

	[z0ZzZztqh]
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

	public ObjectParameter z0eek()
	{
		return (ObjectParameter)MemberwiseClone();
	}

	public override string ToString()
	{
		return Name + "=" + Value;
	}
}
