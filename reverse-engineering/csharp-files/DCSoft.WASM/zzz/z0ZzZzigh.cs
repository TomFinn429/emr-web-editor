using System.ComponentModel;
using DCSoft.Drawing;
using DCSystem_Drawing;

namespace zzz;

public class z0ZzZzigh
{
	private Color z0rek = Color.Blue;

	private Color z0tek = Color.Transparent;

	private TextUnderlineStyle z0yek = TextUnderlineStyle.Single;

	private Color z0uek = Color.Red;

	private bool z0iek = true;

	private int z0oek = 1;

	private int z0pek = 1;

	[DefaultValue(TextUnderlineStyle.Single)]
	public TextUnderlineStyle UnderLineStyle
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

	[DefaultValue(1)]
	public int DeleteLineNum
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

	public Color DeleteLineColor
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

	[DefaultValue(true)]
	public bool Enabled
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

	public Color BackgroundColor
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

	[DefaultValue(1)]
	public int UnderLineColorNum
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

	public Color UnderLineColor
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

	public z0ZzZzigh z0eek()
	{
		return (z0ZzZzigh)MemberwiseClone();
	}
}
