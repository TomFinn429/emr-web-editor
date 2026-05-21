using System;
using System.ComponentModel;
using DCSystem_Drawing;

namespace zzz;

public class z0ZzZzbmk : ICloneable
{
	private bool z0yek;

	private string z0uek = z0ZzZzimk.DefaultFontName;

	private bool z0iek;

	private float z0oek = z0ZzZzimk.DefaultFontSize;

	private bool z0pek;

	private Color z0mek = Color.Black;

	private bool z0nek;

	private ContentAlignment z0bek = ContentAlignment.MiddleCenter;

	private bool z0vek;

	private bool z0cek;

	[z0ZzZzyqh("Color")]
	[DefaultValue("Black")]
	public string ColorString
	{
		get
		{
			return z0ZzZzlok.z0eek(z0mek, Color.Black);
		}
		set
		{
			z0mek = z0ZzZzlok.z0eek(value, Color.Black);
		}
	}

	[DefaultValue(false)]
	public bool Strikeout
	{
		get
		{
			return z0cek;
		}
		set
		{
			z0cek = value;
		}
	}

	public z0ZzZzimk Font
	{
		get
		{
			return new z0ZzZzimk
			{
				Name = z0uek,
				Size = z0oek,
				Bold = z0vek,
				Underline = z0yek,
				Strikeout = z0cek,
				Italic = z0pek
			};
		}
		set
		{
			if (value != null)
			{
				z0uek = value.Name;
				z0oek = value.Size;
				z0vek = value.Bold;
				z0yek = value.Underline;
				z0cek = value.Strikeout;
				z0pek = value.Italic;
			}
		}
	}

	[DefaultValue(ContentAlignment.MiddleCenter)]
	public ContentAlignment Alignment
	{
		get
		{
			return z0bek;
		}
		set
		{
			z0bek = value;
		}
	}

	[DefaultValue(9f)]
	public float FontSize
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

	[DefaultValue(false)]
	public bool Italic
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

	[DefaultValue(false)]
	public bool Vertical
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

	[DefaultValue(false)]
	public bool Multiline
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

	[DefaultValue(false)]
	public bool Bold
	{
		get
		{
			return z0vek;
		}
		set
		{
			z0vek = value;
		}
	}

	[z0ZzZzhpk]
	public string FontName
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

	[z0ZzZzuqh]
	public Color Color
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

	[DefaultValue(false)]
	public bool Underline
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

	public z0ZzZzbmk(z0ZzZzsdh p0, Color p1)
	{
		z0uek = p0.z0pek();
		z0oek = p0.z0yek();
		z0vek = p0.z0eek();
		z0yek = p0.z0iek();
		z0pek = p0.z0tek();
		z0cek = p0.z0uek();
		z0mek = p1;
	}

	public void z0eek()
	{
	}

	public void z0eek(z0ZzZzjpk p0, string p1, z0ZzZzbdh p2)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("graphics");
		}
		if (string.IsNullOrEmpty(p1))
		{
			return;
		}
		using (new z0ZzZzzdh(z0mek))
		{
			using z0ZzZzlsh p3 = z0tek();
			p0.z0eek(p1, Font, z0mek, p2, p3);
		}
	}

	public z0ZzZzbmk Clone()
	{
		return (z0ZzZzbmk)MemberwiseClone();
	}

	private object z0rek()
	{
		return (z0ZzZzbmk)MemberwiseClone();
	}

	object ICloneable.Clone()
	{
		//ILSpy generated this explicit interface implementation from .override directive in z0rek
		return this.z0rek();
	}

	public z0ZzZzbmk(z0ZzZzsdh p0)
	{
		z0uek = p0.z0pek();
		z0oek = p0.z0yek();
		z0vek = p0.z0eek();
		z0yek = p0.z0iek();
		z0pek = p0.z0tek();
		z0cek = p0.z0uek();
	}

	public z0ZzZzlsh z0tek()
	{
		z0ZzZzlsh z0ZzZzlsh2 = new z0ZzZzlsh();
		switch (z0bek)
		{
		case ContentAlignment.TopLeft:
			z0ZzZzlsh2.z0rek(StringAlignment.Near);
			z0ZzZzlsh2.z0eek(StringAlignment.Near);
			break;
		case ContentAlignment.TopCenter:
			z0ZzZzlsh2.z0rek(StringAlignment.Center);
			z0ZzZzlsh2.z0eek(StringAlignment.Near);
			break;
		case ContentAlignment.TopRight:
			z0ZzZzlsh2.z0rek(StringAlignment.Far);
			z0ZzZzlsh2.z0eek(StringAlignment.Near);
			break;
		case ContentAlignment.MiddleLeft:
			z0ZzZzlsh2.z0rek(StringAlignment.Near);
			z0ZzZzlsh2.z0eek(StringAlignment.Center);
			break;
		case ContentAlignment.MiddleCenter:
			z0ZzZzlsh2.z0rek(StringAlignment.Center);
			z0ZzZzlsh2.z0eek(StringAlignment.Center);
			break;
		case ContentAlignment.MiddleRight:
			z0ZzZzlsh2.z0rek(StringAlignment.Far);
			z0ZzZzlsh2.z0eek(StringAlignment.Center);
			break;
		case ContentAlignment.BottomLeft:
			z0ZzZzlsh2.z0rek(StringAlignment.Near);
			z0ZzZzlsh2.z0eek(StringAlignment.Far);
			break;
		case ContentAlignment.BottomCenter:
			z0ZzZzlsh2.z0rek(StringAlignment.Center);
			z0ZzZzlsh2.z0eek(StringAlignment.Far);
			break;
		case ContentAlignment.BottomRight:
			z0ZzZzlsh2.z0rek(StringAlignment.Far);
			z0ZzZzlsh2.z0eek(StringAlignment.Far);
			break;
		}
		if (!z0iek)
		{
			z0ZzZzlsh2.z0eek(z0ZzZzlsh2.z0yek() | (z0ZzZzksh)4096);
		}
		if (z0nek)
		{
			z0ZzZzlsh2.z0eek(z0ZzZzlsh2.z0yek() | (z0ZzZzksh)2);
		}
		return z0ZzZzlsh2;
	}

	public void z0rek(z0ZzZzjpk p0, string p1, z0ZzZzbdh p2)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("graphics");
		}
		if (string.IsNullOrEmpty(p1))
		{
			return;
		}
		using z0ZzZzlsh z0ZzZzlsh2 = z0tek();
		z0ZzZzlsh2.z0eek(z0ZzZzlsh2.z0yek() | (z0ZzZzksh)2);
		p0.z0eek(p1, Font, Color, p2, z0ZzZzlsh2);
	}

	public z0ZzZzbmk()
	{
	}
}
