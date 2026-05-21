using System.ComponentModel;
using DCSoft.Chart;
using DCSoft.Drawing;
using DCSystem_Drawing;
using zzz;

namespace DCSoft.Writer.Dom;

public class DCChartDataItem
{
	private string z0eek;

	private ShapeTypes z0rek = ShapeTypes.Default;

	private int z0tek = 10;

	private ChartStyleConsts z0yek;

	private string z0uek;

	private Color z0iek = Color.Transparent;

	private double z0oek;

	private string z0pek;

	private string z0mek;

	private string z0nek;

	[z0ZzZztqh]
	[DefaultValue(null)]
	public string ColorValue
	{
		get
		{
			return z0ZzZzlok.z0eek(Color, Color.Transparent);
		}
		set
		{
			Color = z0ZzZzlok.z0eek(value, Color.Transparent);
		}
	}

	[z0ZzZztqh]
	[DefaultValue(null)]
	public string GroupName
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
	public string SeriesName
	{
		get
		{
			return z0nek;
		}
		set
		{
			z0nek = value;
		}
	}

	public Color Color
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

	[DefaultValue(null)]
	[z0ZzZztqh]
	public string TipText
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

	[z0ZzZztqh]
	[DefaultValue(0.0)]
	public double Value
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

	[z0ZzZztqh]
	[DefaultValue(ShapeTypes.Default)]
	public ShapeTypes SymbolType
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
	public string Link
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

	[z0ZzZztqh]
	[DefaultValue(null)]
	public string Text
	{
		get
		{
			return z0mek;
		}
		set
		{
			z0mek = value;
		}
	}

	[z0ZzZztqh]
	[DefaultValue(ChartStyleConsts.Default)]
	public ChartStyleConsts ChartStyle
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

	[DefaultValue(10)]
	[z0ZzZztqh]
	public int SymbolSize
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
}
