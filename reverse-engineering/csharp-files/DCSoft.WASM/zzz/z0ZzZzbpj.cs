using DCSoft.Writer.Commands;
using DCSoft.Writer.Dom;
using DCSystem_Drawing;
using DCSystem_Drawing.Drawing2D;

namespace zzz;

public class z0ZzZzbpj
{
	private bool z0frk = true;

	private bool z0drk = true;

	private Color z0srk = Color.Black;

	private Color z0ark = Color.Black;

	private bool z0qrk = true;

	private bool z0wrk = true;

	private Color z0erk = Color.Black;

	private bool z0rrk = true;

	private float z0trk = 1f;

	private bool z0yrk = true;

	private XTextElementList z0urk;

	private bool z0irk = true;

	private bool z0ork = true;

	private DashStyle z0prk;

	private Color z0mrk = Color.Transparent;

	private BorderSettingsStyle z0nrk;

	private StyleApplyRanges z0brk = StyleApplyRanges.Text;

	private Color z0vrk = Color.Black;

	public bool z0eek()
	{
		return z0yrk;
	}

	public void z0eek(bool p0)
	{
		z0wrk = p0;
	}

	public StyleApplyRanges z0rek()
	{
		return z0brk;
	}

	public void z0eek(Color p0)
	{
		z0ark = p0;
	}

	public bool z0tek()
	{
		return z0drk;
	}

	public BorderSettingsStyle z0yek()
	{
		return z0nrk;
	}

	public void z0uek()
	{
		if (z0krk() && z0oek() && z0cek() && z0jrk())
		{
			if (z0lrk() && z0eek())
			{
				z0eek(BorderSettingsStyle.Both);
			}
			else if (!z0lrk() && !z0eek())
			{
				z0eek(BorderSettingsStyle.Rectangle);
			}
			else
			{
				z0eek(BorderSettingsStyle.Custom);
			}
		}
		else if (!z0krk() && !z0oek() && !z0cek() && !z0jrk() && !z0lrk() && !z0eek())
		{
			z0eek(BorderSettingsStyle.None);
		}
		else
		{
			z0eek(BorderSettingsStyle.Custom);
		}
	}

	public void z0eek(BorderSettingsStyle p0)
	{
		z0nrk = p0;
	}

	public void z0rek(Color p0)
	{
		z0mrk = p0;
	}

	public void z0tek(Color p0)
	{
		z0vrk = p0;
	}

	public float z0iek()
	{
		return z0trk;
	}

	public bool z0oek()
	{
		return z0frk;
	}

	public bool z0eek(z0ZzZzcok p0)
	{
		bool result = false;
		if (z0irk)
		{
			if (p0.BorderLeft != z0krk())
			{
				p0.BorderLeft = z0krk();
				result = true;
			}
			if (p0.BorderTop != z0oek())
			{
				p0.BorderTop = z0oek();
				result = true;
			}
			if (p0.BorderRight != z0cek())
			{
				p0.BorderRight = z0cek();
				result = true;
			}
			if (p0.BorderBottom != z0jrk())
			{
				p0.BorderBottom = z0jrk();
				result = true;
			}
			if (p0.BorderTopColor != z0bek())
			{
				p0.BorderTopColor = z0bek();
				result = true;
			}
			if (p0.BorderLeftColor != z0zek())
			{
				p0.BorderLeftColor = z0zek();
				result = true;
			}
			if (p0.BorderRightColor != z0grk())
			{
				p0.BorderRightColor = z0grk();
				result = true;
			}
			if (p0.BorderBottomColor != z0mek())
			{
				p0.BorderBottomColor = z0mek();
				result = true;
			}
			if (p0.BorderStyle != z0pek())
			{
				p0.BorderStyle = z0pek();
				result = true;
			}
			if (p0.BorderWidth != z0iek())
			{
				p0.BorderWidth = z0iek();
				result = true;
			}
		}
		if (z0drk && p0.BackgroundColor != z0vek())
		{
			p0.BackgroundColor = z0vek();
			result = true;
		}
		return result;
	}

	public DashStyle z0pek()
	{
		return z0prk;
	}

	public void z0rek(bool p0)
	{
		z0ork = p0;
	}

	public void z0tek(bool p0)
	{
		z0qrk = p0;
	}

	public Color z0mek()
	{
		return z0erk;
	}

	public void z0yek(bool p0)
	{
		z0drk = p0;
	}

	public void z0nek()
	{
		z0uek(p0: true);
		z0pek(p0: true);
		z0tek(p0: true);
		z0eek(p0: true);
		z0rek(p0: true);
		z0iek(p0: true);
		z0yek(Color.Black);
		z0uek(Color.Black);
		z0tek(Color.Black);
		z0eek(Color.Black);
		z0eek(1f);
		z0eek(DashStyle.Solid);
		z0rek(Color.Transparent);
		z0eek(BorderSettingsStyle.None);
		z0eek(StyleApplyRanges.Text);
	}

	public Color z0bek()
	{
		return z0srk;
	}

	public void z0eek(DashStyle p0)
	{
		z0prk = p0;
	}

	public void z0uek(bool p0)
	{
		z0frk = p0;
	}

	public Color z0vek()
	{
		return z0mrk;
	}

	public void z0eek(float p0)
	{
		z0trk = p0;
	}

	public void z0eek(StyleApplyRanges p0)
	{
		z0brk = p0;
	}

	public void z0iek(bool p0)
	{
		z0rrk = p0;
	}

	public void z0oek(bool p0)
	{
		z0irk = p0;
	}

	public void z0yek(Color p0)
	{
		z0erk = p0;
	}

	public bool z0cek()
	{
		return z0rrk;
	}

	public bool z0xek()
	{
		return z0irk;
	}

	public Color z0zek()
	{
		return z0ark;
	}

	public void z0uek(Color p0)
	{
		z0srk = p0;
	}

	public bool z0lrk()
	{
		return z0ork;
	}

	public bool z0krk()
	{
		return z0wrk;
	}

	public bool z0jrk()
	{
		return z0qrk;
	}

	public void z0pek(bool p0)
	{
		z0yrk = p0;
	}

	public void z0eek(XTextElementList p0)
	{
		z0urk = p0;
	}

	public XTextElementList z0hrk()
	{
		return z0urk;
	}

	public Color z0grk()
	{
		return z0vrk;
	}
}
