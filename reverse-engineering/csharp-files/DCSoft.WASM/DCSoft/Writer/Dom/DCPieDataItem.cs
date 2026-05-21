using System.ComponentModel;
using DCSystem_Drawing;
using zzz;

namespace DCSoft.Writer.Dom;

[z0ZzZziqh("PieDataItem")]
public class DCPieDataItem
{
	private double z0eek;

	private Color z0rek = Color.Transparent;

	private string z0tek;

	private string z0yek;

	private string z0uek;

	[DefaultValue(0.0)]
	[z0ZzZztqh]
	public double Value
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

	[z0ZzZztqh]
	[DefaultValue(null)]
	public string Text
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

	[DefaultValue(null)]
	[z0ZzZztqh]
	public string TipText
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

	public Color Color
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
			return z0yek;
		}
		set
		{
			z0yek = value;
		}
	}
}
