using System.ComponentModel;
using DCSoft.WinForms;
using DCSystem_Drawing;
using zzz;

namespace DCSoft.Writer.Dom;

public abstract class XTextBlockElement : XTextObjectElement
{
	private new static z0ZzZzlsh z0eek;

	private new string z0rek;

	private new ResizeableType z0tek = ResizeableType.WidthAndHeight;

	[DefaultValue(null)]
	public override string Text
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

	public override void z0et(ResizeableType p0)
	{
		z0tek = p0;
	}

	public override string z0gy()
	{
		return z0rek;
	}

	public override void z0mr(z0ZzZzvxj p0)
	{
		if (z0eek == null)
		{
			z0eek = new z0ZzZzlsh(z0ZzZzlsh.z0uek());
		}
		z0ZzZzrzj z0ZzZzrzj = z0aek();
		string text = Text;
		if (string.IsNullOrEmpty(text))
		{
			text = "  ";
		}
		z0ZzZzxdh z0ZzZzxdh = z0ZzZzxdh.z0yek;
		Width = p0.z0eek(text, z0ZzZzrzj, 10000, z0eek).z0rek();
		Height = p0.z0eek(z0ZzZzrzj);
		z0xi(p0: false);
	}

	public override ResizeableType z0wt()
	{
		if (z0yek())
		{
			return ResizeableType.FixSize;
		}
		return z0tek;
	}

	public override void z0vw(z0ZzZzvxj p0)
	{
		if (Text != null && Text.Length > 0)
		{
			z0ZzZzrzj z0ZzZzrzj = z0aek();
			z0ZzZzbdh p1 = z0qyk();
			Color black = Color.Black;
			if (p0.z0byk == (z0ZzZzcxj)0)
			{
				z0ZzZzqxj z0ZzZzqxj = ((z0jr().z0htk() == null) ? null : z0jr().z0htk().z0zo(this, null));
				black = ((z0ZzZzqxj == null || z0ZzZzqxj.z0uek().A == 0) ? z0ZzZzrzj.z0bek : z0ZzZzqxj.z0uek());
			}
			else
			{
				black = z0yek(z0ZzZzrzj.z0bek);
			}
			p0.z0gyk.z0eek(Text, z0ZzZzrzj.z0pek, black, p1, z0eek);
		}
	}
}
