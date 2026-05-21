using System;
using System.ComponentModel;
using System.Diagnostics;
using DCSoft.WinForms;
using DCSystem_Drawing;
using DCSystem_Drawing.Drawing2D;
using zzz;

namespace DCSoft.Writer.Dom;

[z0ZzZziqh("HorizontalLine")]
[DebuggerDisplay("HorizontalLine")]
public class XTextHorizontalLineElement : XTextObjectElement
{
	private new float z0eek;

	private new float z0rek = 1f;

	private new DashStyle z0tek;

	[z0ZzZzyqh]
	[DefaultValue(DashStyle.Solid)]
	public DashStyle LineStyle
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

	[z0ZzZzyqh]
	[DefaultValue(0f)]
	public float LineLengthInCM
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

	[DefaultValue(1f)]
	public float LineSize
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

	public override string z0ge()
	{
		return "HR:" + ID;
	}

	public override string z0pe()
	{
		return "hr";
	}

	public override ResizeableType z0wt()
	{
		return ResizeableType.Height;
	}

	public XTextHorizontalLineElement()
	{
		Height = 20f;
	}

	public override void z0et(ResizeableType p0)
	{
	}

	public override void z0vw(z0ZzZzvxj p0)
	{
		z0ZzZzbdh z0ZzZzbdh = p0.z0drk();
		if (LineLengthInCM > 0f)
		{
			float num = z0ZzZzrpk.z0tek(LineLengthInCM, GraphicsUnit.Document);
			if (num < z0ZzZzbdh.z0uek())
			{
				z0ZzZzbdh.z0eek(z0ZzZzbdh.z0tek() + (z0ZzZzbdh.z0uek() - num) / 2f);
				z0ZzZzbdh.z0tek(num);
			}
		}
		float num2 = Math.Min(LineSize, z0ZzZzbdh.z0iek());
		z0ZzZzbdh.z0rek(z0ZzZzbdh.z0yek() + (z0ZzZzbdh.z0iek() - num2) / 2f);
		z0ZzZzbdh.z0yek(num2);
		if (p0.z0gyk != null)
		{
			z0ZzZzrzj z0ZzZzrzj = z0aek();
			if (num2 == 1f)
			{
				p0.z0gyk.z0eek(z0yek(z0ZzZzrzj.z0bek), 1f, LineStyle, z0ZzZzbdh.z0oek(), z0ZzZzbdh.z0pek(), z0ZzZzbdh.z0mek(), z0ZzZzbdh.z0pek());
			}
			else
			{
				p0.z0gyk.z0eek(z0yek(z0ZzZzrzj.z0bek), z0ZzZzrpk.z0eek(num2, GraphicsUnit.Pixel, p0.z0gyk.z0vek()), LineStyle, z0ZzZzbdh.z0oek(), z0ZzZzbdh.z0pek(), z0ZzZzbdh.z0mek(), z0ZzZzbdh.z0pek());
			}
		}
		z0xi(p0: false);
	}

	public override void z0fy(z0ZzZzdxj p0)
	{
		p0.z0iek();
		p0.z0eek("----");
		p0.z0rek();
	}

	public override void z0mr(z0ZzZzvxj p0)
	{
		z0xi(p0: false);
	}

	public override void z0nw(z0ZzZzuzj p0)
	{
		base.z0nw(p0);
		p0.z0eek(z0rek);
		p0.z0eek((byte)z0tek);
		p0.z0eek(z0eek);
	}
}
