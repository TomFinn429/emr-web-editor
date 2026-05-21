using DCSoft.WinForms;
using DCSystem_Drawing;
using DCSystem_Drawing.Drawing2D;

namespace zzz;

public class z0ZzZzqpj
{
	public static Color z0oek = Color.LightGray;

	private ResizeableType z0pek = ResizeableType.WidthAndHeight;

	private readonly z0ZzZzndh[] z0mek = new z0ZzZzndh[8];

	private bool z0nek = true;

	private bool z0bek = true;

	public static Color z0vek = Color.White;

	private bool z0cek;

	private z0ZzZzndh z0xek = z0ZzZzndh.z0cek;

	public static Color z0zek = Color.LightGray;

	private DashStyle z0lrk = DashStyle.Dash;

	private bool z0krk = true;

	public static int z0jrk = 6;

	public static Color z0hrk = Color.Blue;

	public void z0eek(z0ZzZzndh p0)
	{
		z0xek = p0;
		z0eek();
	}

	public void z0eek(z0ZzZzjpk p0)
	{
		if (p0 == null)
		{
			return;
		}
		if (z0bek)
		{
			using z0ZzZzudh z0ZzZzudh2 = new z0ZzZzudh(Color.Black);
			z0ZzZzudh2.z0eek(z0tek());
			p0.z0eek(z0ZzZzudh2, z0xek);
		}
		z0eek(p0, z0mek[0], z0iek(), (z0ZzZzapj)0, z0uek(), z0rek());
		z0eek(p0, z0mek[1], z0iek(), (z0ZzZzapj)1, z0uek(), z0rek());
		z0eek(p0, z0mek[2], z0iek(), (z0ZzZzapj)2, z0uek(), z0rek());
		z0eek(p0, z0mek[3], z0iek(), (z0ZzZzapj)3, z0uek(), z0rek());
		z0eek(p0, z0mek[4], z0iek(), (z0ZzZzapj)4, z0uek(), z0rek());
		z0eek(p0, z0mek[5], z0iek(), (z0ZzZzapj)5, z0uek(), z0rek());
		z0eek(p0, z0mek[6], z0iek(), (z0ZzZzapj)6, z0uek(), z0rek());
		z0eek(p0, z0mek[7], z0iek(), (z0ZzZzapj)7, z0uek(), z0rek());
	}

	public z0ZzZzqpj()
	{
	}

	public void z0eek(bool p0)
	{
		z0krk = p0;
	}

	public static void z0eek(z0ZzZzjpk p0, z0ZzZzndh p1, bool p2, z0ZzZzapj p3, ResizeableType p4, bool p5)
	{
		bool flag = z0eek(p3, p4, p5);
		Color blue = Color.Blue;
		blue = ((!flag) ? Color.White : ((!p2) ? Color.Black : Color.Blue));
		using (z0ZzZzzdh p6 = new z0ZzZzzdh(blue))
		{
			p0.z0eek(p6, p1);
		}
		blue = ((!flag) ? Color.Black : ((!p2) ? Color.Blue : Color.White));
		using z0ZzZzudh p7 = new z0ZzZzudh(blue);
		p0.z0eek(p7, p1.z0pek(), p1.z0mek(), p1.z0iek(), p1.z0oek(), 0f);
	}

	public void z0eek(DashStyle p0)
	{
		z0lrk = p0;
	}

	public void z0eek()
	{
		if (z0cek)
		{
			z0mek[0] = new z0ZzZzndh(z0xek.z0yek(), z0xek.z0uek(), z0jrk, z0jrk);
			z0mek[1] = new z0ZzZzndh(z0xek.z0yek() + (z0xek.z0iek() - z0jrk) / 2, z0xek.z0uek(), z0jrk, z0jrk);
			z0mek[2] = new z0ZzZzndh(z0xek.z0nek() - z0jrk, z0xek.z0uek(), z0jrk, z0jrk);
			z0mek[3] = new z0ZzZzndh(z0xek.z0nek() - z0jrk, z0xek.z0uek() + (z0xek.z0oek() - z0jrk) / 2, z0jrk, z0jrk);
			z0mek[4] = new z0ZzZzndh(z0xek.z0nek() - z0jrk, z0xek.z0bek() - z0jrk, z0jrk, z0jrk);
			z0mek[5] = new z0ZzZzndh(z0xek.z0yek() + (z0xek.z0iek() - z0jrk) / 2, z0xek.z0bek() - z0jrk, z0jrk, z0jrk);
			z0mek[6] = new z0ZzZzndh(z0xek.z0yek(), z0xek.z0bek() - z0jrk, z0jrk, z0jrk);
			z0mek[7] = new z0ZzZzndh(z0xek.z0yek(), z0xek.z0uek() + (z0xek.z0oek() - z0jrk) / 2, z0jrk, z0jrk);
		}
		else
		{
			z0mek[0] = new z0ZzZzndh(z0xek.z0yek() - z0jrk, z0xek.z0uek() - z0jrk, z0jrk, z0jrk);
			z0mek[1] = new z0ZzZzndh(z0xek.z0yek() + (z0xek.z0iek() - z0jrk) / 2, z0xek.z0uek() - z0jrk, z0jrk, z0jrk);
			z0mek[2] = new z0ZzZzndh(z0xek.z0nek(), z0xek.z0uek() - z0jrk, z0jrk, z0jrk);
			z0mek[3] = new z0ZzZzndh(z0xek.z0nek(), z0xek.z0uek() + (z0xek.z0oek() - z0jrk) / 2, z0jrk, z0jrk);
			z0mek[4] = new z0ZzZzndh(z0xek.z0nek(), z0xek.z0bek(), z0jrk, z0jrk);
			z0mek[5] = new z0ZzZzndh(z0xek.z0yek() + (z0xek.z0iek() - z0jrk) / 2, z0xek.z0bek(), z0jrk, z0jrk);
			z0mek[6] = new z0ZzZzndh(z0xek.z0yek() - z0jrk, z0xek.z0bek(), z0jrk, z0jrk);
			z0mek[7] = new z0ZzZzndh(z0xek.z0yek() - z0jrk, z0xek.z0uek() + (z0xek.z0oek() - z0jrk) / 2, z0jrk, z0jrk);
		}
	}

	public static z0ZzZzodh z0eek(z0ZzZzndh p0, z0ZzZzapj p1)
	{
		int p2 = p0.z0pek();
		int p3 = p0.z0mek();
		switch (p1)
		{
		case (z0ZzZzapj)0:
			p2 = p0.z0pek();
			p3 = p0.z0mek();
			break;
		case (z0ZzZzapj)1:
			p2 = p0.z0pek() + p0.z0iek() / 2;
			p3 = p0.z0mek();
			break;
		case (z0ZzZzapj)2:
			p2 = p0.z0nek();
			p3 = p0.z0mek();
			break;
		case (z0ZzZzapj)3:
			p2 = p0.z0nek();
			p3 = p0.z0mek() + p0.z0oek() / 2;
			break;
		case (z0ZzZzapj)4:
			p2 = p0.z0nek();
			p3 = p0.z0bek();
			break;
		case (z0ZzZzapj)5:
			p2 = p0.z0pek() + p0.z0iek() / 2;
			p3 = p0.z0bek();
			break;
		case (z0ZzZzapj)6:
			p2 = p0.z0pek();
			p3 = p0.z0bek();
			break;
		case (z0ZzZzapj)7:
			p2 = p0.z0yek();
			p3 = p0.z0mek() + p0.z0oek() / 2;
			break;
		}
		return new z0ZzZzodh(p2, p3);
	}

	public bool z0rek()
	{
		return z0nek;
	}

	public static z0ZzZznwh z0eek(z0ZzZzapj p0)
	{
		return p0 switch
		{
			(z0ZzZzapj)(-1) => z0ZzZzbwh.z0krk, 
			(z0ZzZzapj)0 => z0ZzZzbwh.z0wrk, 
			(z0ZzZzapj)1 => z0ZzZzbwh.z0tek, 
			(z0ZzZzapj)2 => z0ZzZzbwh.z0hrk, 
			(z0ZzZzapj)3 => z0ZzZzbwh.z0mek, 
			(z0ZzZzapj)4 => z0ZzZzbwh.z0wrk, 
			(z0ZzZzapj)5 => z0ZzZzbwh.z0tek, 
			(z0ZzZzapj)6 => z0ZzZzbwh.z0hrk, 
			(z0ZzZzapj)7 => z0ZzZzbwh.z0mek, 
			_ => z0ZzZzbwh.z0vek, 
		};
	}

	public DashStyle z0tek()
	{
		return z0lrk;
	}

	public static z0ZzZzndh z0eek(int p0, int p1, z0ZzZzapj p2, z0ZzZzndh p3)
	{
		if (p2 == (z0ZzZzapj)(-1))
		{
			p3.z0rek(p0, p1);
		}
		if (p2 == (z0ZzZzapj)0 || p2 == (z0ZzZzapj)7 || p2 == (z0ZzZzapj)6)
		{
			p3.z0rek(p0, 0);
			p3.z0tek(p3.z0iek() - p0);
		}
		if (p2 == (z0ZzZzapj)0 || p2 == (z0ZzZzapj)1 || p2 == (z0ZzZzapj)2)
		{
			p3.z0rek(0, p1);
			p3.z0yek(p3.z0oek() - p1);
		}
		if (p2 == (z0ZzZzapj)2 || p2 == (z0ZzZzapj)3 || p2 == (z0ZzZzapj)4)
		{
			p3.z0tek(p3.z0iek() + p0);
		}
		if (p2 == (z0ZzZzapj)4 || p2 == (z0ZzZzapj)5 || p2 == (z0ZzZzapj)6)
		{
			p3.z0yek(p3.z0oek() + p1);
		}
		return p3;
	}

	public z0ZzZzndh z0yek()
	{
		return z0xek;
	}

	public z0ZzZzqpj(z0ZzZzndh p0, bool p1)
	{
		z0xek = p0;
		z0cek = p1;
		z0eek();
	}

	public ResizeableType z0uek()
	{
		return z0pek;
	}

	private static bool z0eek(z0ZzZzapj p0, ResizeableType p1, bool p2)
	{
		switch (p0)
		{
		case (z0ZzZzapj)(-1):
			return p2;
		case (z0ZzZzapj)0:
			if (p2)
			{
				return p1 == ResizeableType.WidthAndHeight;
			}
			return false;
		case (z0ZzZzapj)1:
			if (p2)
			{
				if (p1 != ResizeableType.WidthAndHeight)
				{
					return p1 == ResizeableType.Height;
				}
				return true;
			}
			return false;
		case (z0ZzZzapj)2:
			if (p2)
			{
				return p1 == ResizeableType.WidthAndHeight;
			}
			return false;
		case (z0ZzZzapj)3:
			if (p1 != ResizeableType.WidthAndHeight)
			{
				return p1 == ResizeableType.Width;
			}
			return true;
		case (z0ZzZzapj)4:
			return p1 == ResizeableType.WidthAndHeight;
		case (z0ZzZzapj)5:
			if (p1 != ResizeableType.Height)
			{
				return p1 == ResizeableType.WidthAndHeight;
			}
			return true;
		case (z0ZzZzapj)6:
			if (p2)
			{
				return p1 == ResizeableType.WidthAndHeight;
			}
			return false;
		case (z0ZzZzapj)7:
			if (p2)
			{
				if (p1 != ResizeableType.WidthAndHeight)
				{
					return p1 == ResizeableType.Width;
				}
				return true;
			}
			return false;
		default:
			return false;
		}
	}

	public z0ZzZzapj z0eek(int p0, int p1)
	{
		if (z0uek() == ResizeableType.FixSize && z0xek.z0eek(p0, p1))
		{
			return (z0ZzZzapj)(-1);
		}
		for (int i = 0; i < 8; i++)
		{
			if (z0mek[i].z0eek(p0, p1))
			{
				if (z0rek((z0ZzZzapj)i))
				{
					return (z0ZzZzapj)i;
				}
				return (z0ZzZzapj)(-2);
			}
		}
		if (z0xek.z0eek(p0, p1) && z0rek())
		{
			return (z0ZzZzapj)(-1);
		}
		return (z0ZzZzapj)(-2);
	}

	private bool z0rek(z0ZzZzapj p0)
	{
		return z0eek(p0, z0uek(), z0rek());
	}

	public bool z0iek()
	{
		return z0krk;
	}

	public void z0eek(ResizeableType p0)
	{
		z0pek = p0;
	}

	public void z0rek(bool p0)
	{
		z0nek = p0;
	}
}
