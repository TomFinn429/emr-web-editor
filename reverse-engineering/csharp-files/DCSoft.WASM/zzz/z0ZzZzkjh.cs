using System.ComponentModel;
using DCSystem_Drawing;
using DCSystem_Drawing.Drawing2D;

namespace zzz;

public class z0ZzZzkjh
{
	private bool z0eek;

	private DashStyle z0rek;

	private bool z0tek = true;

	private Color z0yek = Color.Gray;

	[DefaultValue(false)]
	public bool ShowGridLine
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

	[z0ZzZzyqh]
	[DefaultValue("Gray")]
	public string GridLineColorValue
	{
		get
		{
			return z0ZzZzifh.z0eek(GridLineColor);
		}
		set
		{
			GridLineColor = z0ZzZzifh.z0eek(value);
		}
	}

	[DefaultValue(DashStyle.Solid)]
	public DashStyle LineStyle
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

	[z0ZzZzuqh]
	public Color GridLineColor
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
	public bool PrintGridLine
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

	public z0ZzZzkjh Clone()
	{
		return (z0ZzZzkjh)MemberwiseClone();
	}
}
