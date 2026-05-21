using System.ComponentModel;
using zzz;

namespace DCSoft.Writer.Dom;

public class SpecifyPageIndexInfo
{
	private int z0rek = -1;

	private int z0tek = 1;

	[z0ZzZztqh]
	[DefaultValue(-1)]
	public int SpecifyPageIndex
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
	[DefaultValue(1)]
	public int RawPageIndex
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

	public SpecifyPageIndexInfo z0eek()
	{
		return (SpecifyPageIndexInfo)MemberwiseClone();
	}
}
