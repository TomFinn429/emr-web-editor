using System;
using System.ComponentModel;
using DCSystem_Drawing;
using DCSystem_Drawing.Drawing2D;

namespace zzz;

public class z0ZzZztpk : ICloneable
{
	private float z0rek;

	private Color z0tek = Color.Black;

	private DashStyle z0yek_jiejie20260327142557;

	private bool z0uek;

	private int z0iek = 1;

	[DefaultValue(0f)]
	public float Step
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

	[z0ZzZzyqh]
	[DefaultValue("Black")]
	public string ColorValue
	{
		get
		{
			return z0ZzZzlok.z0eek(Color, Color.Black);
		}
		set
		{
			z0tek = z0ZzZzlok.z0eek(value, Color.Black);
		}
	}

	[DefaultValue(false)]
	public bool Visible
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

	[DefaultValue(1)]
	public int LineWidth
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

	[DefaultValue(DashStyle.Solid)]
	public DashStyle DashStyle
	{
		get
		{
			return z0yek_jiejie20260327142557;
		}
		set
		{
			z0yek_jiejie20260327142557 = value;
		}
	}

	[z0ZzZzuqh]
	public Color Color
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

	private object z0eek()
	{
		return MemberwiseClone();
	}

	object ICloneable.Clone()
	{
		//ILSpy generated this explicit interface implementation from .override directive in z0eek
		return this.z0eek();
	}
}
