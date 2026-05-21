using System.ComponentModel;

namespace DCSoft.Writer.Dom;

public class PageLabelText
{
	private string z0rek;

	private int z0tek;

	[DefaultValue(null)]
	public string Text
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

	[DefaultValue(0)]
	public int PageIndex
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

	public PageLabelText z0eek()
	{
		return (PageLabelText)MemberwiseClone();
	}
}
