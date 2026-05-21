using System.ComponentModel;
using DCSoft.Drawing;
using DCSystem_Drawing;

namespace zzz;

public class z0ZzZzdmk
{
	private int z0eek = 50;

	private Color z0rek_jiejie20260327142557 = Color.Black;

	private ShapeTypes z0tek;

	private Color z0yek = Color.White;

	public Color BackColor
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

	[DefaultValue(ShapeTypes.Rectangle)]
	public ShapeTypes Style
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

	[DefaultValue(50)]
	public int Size
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

	public Color BorderColor
	{
		get
		{
			return z0rek_jiejie20260327142557;
		}
		set
		{
			z0rek_jiejie20260327142557 = value;
		}
	}

	public void Draw(z0ZzZzadh g, float x, float y)
	{
		z0ZzZzfmk obj = new z0ZzZzfmk();
		obj.z0eek(new z0ZzZzbdh(x - (float)(z0eek / 2), y - (float)(z0eek / 2), z0eek, z0eek));
		obj.z0eek(new z0ZzZzudh(z0rek_jiejie20260327142557));
		obj.z0eek(new z0ZzZzzdh(z0yek));
		obj.z0rek(g);
		obj.z0uek();
	}
}
