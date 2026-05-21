using System.ComponentModel;
using zzz;

namespace DCSoft.Writer.Dom;

public class PropertyExpressionInfo
{
	private string z0rek;

	private bool z0tek = true;

	private string z0yek;

	[DefaultValue(null)]
	public string Expression
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

	[DefaultValue(true)]
	[z0ZzZztqh]
	public bool AllowChainReaction
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
	[z0ZzZztqh]
	public string Name
	{
		get
		{
			return z0rek;
		}
		set
		{
			if (z0rek != value)
			{
				z0rek = value;
			}
		}
	}

	public PropertyExpressionInfo z0eek()
	{
		return (PropertyExpressionInfo)MemberwiseClone();
	}
}
