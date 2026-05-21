using System;
using System.Collections.Generic;
using System.ComponentModel;
using DCSystem_Drawing;
using DCSystem_Drawing.Drawing2D;

namespace zzz;

public class z0ZzZznmk : ICloneable
{
	private static Dictionary<string, z0ZzZzudh> z0uek = new Dictionary<string, z0ZzZzudh>();

	private z0ZzZzgdh z0iek;

	private z0ZzZzldh z0oek;

	private float z0pek = 10f;

	private z0ZzZzldh z0mek;

	private DashCap z0nek;

	private Color z0bek = Color.Black;

	private DashStyle z0vek;

	private float z0cek = 1f;

	[NonSerialized]
	private z0ZzZzudh z0xek;

	private z0ZzZzkdh z0zek = (z0ZzZzkdh)1;

	public Color Color
	{
		get
		{
			return z0bek;
		}
		set
		{
			z0bek = value;
			z0xek = null;
		}
	}

	[DefaultValue((z0ZzZzgdh)0)]
	public z0ZzZzgdh Alignment
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

	[DefaultValue((z0ZzZzkdh)1)]
	public z0ZzZzkdh LineJoin
	{
		get
		{
			return z0zek;
		}
		set
		{
			z0zek = value;
			z0xek = null;
		}
	}

	[DefaultValue(1f)]
	public float Width
	{
		get
		{
			return z0cek;
		}
		set
		{
			z0cek = value;
			z0xek = null;
		}
	}

	[DefaultValue(DashStyle.Solid)]
	public DashStyle DashStyle
	{
		get
		{
			return z0vek;
		}
		set
		{
			if (value != DashStyle.Custom)
			{
				z0vek = value;
				z0xek = null;
			}
		}
	}

	[z0ZzZzyqh("Color")]
	[DefaultValue(null)]
	public string ColorString
	{
		get
		{
			return z0ZzZzlok.z0eek(Color, Color.Black);
		}
		set
		{
			Color = z0ZzZzlok.z0eek(value, Color.Black);
			z0xek = null;
		}
	}

	[z0ZzZzuqh]
	public z0ZzZzudh Value
	{
		get
		{
			if (z0xek == null)
			{
				string text = Color.ToArgb() + DashCap.ToString() + Width + DashStyle.ToString() + StartCap.ToString() + EndCap.ToString() + MiterLimit + Alignment;
				if (z0uek.ContainsKey(text))
				{
					z0xek = z0uek[text];
				}
				else
				{
					if (z0uek.Count > 100)
					{
						foreach (z0ZzZzudh value in z0uek.Values)
						{
							value.Dispose();
						}
						z0uek.Clear();
					}
					z0ZzZzudh z0ZzZzudh2 = z0yek();
					z0uek[text] = z0ZzZzudh2;
					z0xek = z0ZzZzudh2;
				}
			}
			return z0xek;
		}
	}

	[DefaultValue((z0ZzZzldh)0)]
	public z0ZzZzldh EndCap
	{
		get
		{
			return z0oek;
		}
		set
		{
			if (value != (z0ZzZzldh)9)
			{
				z0oek = value;
				z0xek = null;
			}
		}
	}

	[DefaultValue((z0ZzZzldh)0)]
	public z0ZzZzldh StartCap
	{
		get
		{
			return z0mek;
		}
		set
		{
			if (value != (z0ZzZzldh)9)
			{
				z0mek = value;
				z0xek = null;
			}
		}
	}

	[DefaultValue(DashCap.Flat)]
	public DashCap DashCap
	{
		get
		{
			return z0nek;
		}
		set
		{
			z0nek = value;
			z0xek = null;
		}
	}

	[DefaultValue(10f)]
	public float MiterLimit
	{
		get
		{
			return z0pek;
		}
		set
		{
			if (z0pek != value)
			{
				z0pek = value;
				z0xek = null;
			}
		}
	}

	public z0ZzZznmk(Color p0, float p1, DashStyle p2)
	{
		z0bek = p0;
		z0cek = p1;
		z0vek = p2;
	}

	public z0ZzZznmk()
	{
	}

	public z0ZzZznmk(Color p0, float p1)
	{
		z0bek = p0;
		z0cek = p1;
	}

	public void z0eek()
	{
	}

	public z0ZzZznmk z0rek()
	{
		return (z0ZzZznmk)((ICloneable)this).Clone();
	}

	private object z0tek()
	{
		return (z0ZzZznmk)MemberwiseClone();
	}

	object ICloneable.Clone()
	{
		//ILSpy generated this explicit interface implementation from .override directive in z0tek
		return this.z0tek();
	}

	public z0ZzZzudh z0yek()
	{
		z0ZzZzudh obj = new z0ZzZzudh(Color, Width);
		obj.z0eek(DashStyle);
		obj.z0eek(DashCap);
		return obj;
	}

	public z0ZzZznmk(Color p0)
	{
		z0bek = p0;
	}
}
