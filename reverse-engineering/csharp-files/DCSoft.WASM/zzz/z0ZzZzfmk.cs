using System;
using DCSoft.Drawing;
using DCSystem_Drawing;

namespace zzz;

public class z0ZzZzfmk
{
	private float z0mek;

	private z0ZzZzudh z0nek;

	private z0ZzZzbdh z0bek = z0ZzZzbdh.z0xek;

	private z0ZzZztfh z0vek;

	private ShapeTypes z0cek;

	public void z0eek(z0ZzZzbdh p0)
	{
		z0bek = p0;
	}

	public float z0eek()
	{
		return z0mek;
	}

	public z0ZzZztfh z0rek()
	{
		return z0vek;
	}

	public void z0eek(z0ZzZzudh p0)
	{
		z0nek = p0;
	}

	public z0ZzZznfh z0tek()
	{
		_ = z0ZzZzbdh.z0xek;
		switch (z0cek)
		{
		case ShapeTypes.Default:
			return z0eek(z0bek, z0mek);
		case ShapeTypes.Rectangle:
			return z0eek(z0bek, z0mek);
		case ShapeTypes.Square:
			return z0eek(z0pek(), z0mek);
		case ShapeTypes.Ellipse:
		{
			_ = z0bek;
			z0ZzZznfh obj6 = new z0ZzZznfh();
			obj6.z0rek(z0bek);
			return obj6;
		}
		case ShapeTypes.Circle:
		{
			z0ZzZznfh obj5 = new z0ZzZznfh();
			obj5.z0rek(z0pek());
			return obj5;
		}
		case ShapeTypes.Diamond:
			return z0rek(z0bek);
		case ShapeTypes.TriangleUp:
			return z0eek(z0bek, 0);
		case ShapeTypes.TriangleRight:
			return z0eek(z0bek, 1);
		case ShapeTypes.TriangleDown:
			return z0eek(z0bek, 2);
		case ShapeTypes.TriangleLeft:
			return z0eek(z0bek, 3);
		case ShapeTypes.Cross:
		{
			z0ZzZznfh obj4 = new z0ZzZznfh();
			obj4.z0tek(z0bek.z0oek(), z0bek.z0pek() + z0bek.z0iek() / 2f, z0bek.z0mek(), z0bek.z0pek() + z0bek.z0iek() / 2f);
			obj4.z0tek(z0bek.z0oek() + z0bek.z0uek() / 2f, z0bek.z0pek(), z0bek.z0oek() + z0bek.z0uek() / 2f, z0bek.z0nek());
			return obj4;
		}
		case ShapeTypes.XCross:
		{
			z0ZzZznfh obj3 = new z0ZzZznfh();
			obj3.z0tek(z0bek.z0oek(), z0bek.z0pek(), z0bek.z0mek(), z0bek.z0nek());
			obj3.z0tek(z0bek.z0mek(), z0bek.z0pek(), z0bek.z0oek(), z0bek.z0nek());
			return obj3;
		}
		case ShapeTypes.CircleXCross:
		{
			z0ZzZzbdh p2 = z0pek();
			float num = (int)((double)(p2.z0uek() / 2f) * Math.Sin(Math.PI / 4.0));
			z0ZzZznfh obj2 = new z0ZzZznfh();
			float num2 = z0bek.z0oek() + z0bek.z0uek() / 2f;
			float num3 = z0bek.z0pek() + z0bek.z0iek() / 2f;
			obj2.z0tek(num2 - num, num3 - num, num2 + num, num3 + num);
			obj2.z0tek(num2 + num, num3 - num, num2 - num, num3 + num);
			obj2.z0rek(p2);
			return obj2;
		}
		case ShapeTypes.CircleCross:
		{
			z0ZzZzbdh p = z0pek();
			z0ZzZznfh obj = new z0ZzZznfh();
			obj.z0tek(p.z0oek(), p.z0pek() + p.z0iek() / 2f, p.z0mek(), p.z0pek() + p.z0iek() / 2f);
			obj.z0tek(p.z0oek() + p.z0uek() / 2f, p.z0pek(), p.z0oek() + p.z0uek() / 2f, p.z0nek());
			obj.z0rek(p);
			return obj;
		}
		default:
			return null;
		}
	}

	public z0ZzZzfmk()
	{
	}

	public void z0eek(z0ZzZztfh p0)
	{
		z0vek = p0;
	}

	public void z0eek(z0ZzZzjpk p0)
	{
		if (z0nek == null || p0 == null)
		{
			return;
		}
		switch (z0cek)
		{
		case ShapeTypes.Cross:
			p0.z0eek(z0nek, z0bek.z0oek(), z0bek.z0pek() + z0bek.z0iek() / 2f, z0bek.z0mek(), z0bek.z0pek() + z0bek.z0iek() / 2f);
			p0.z0eek(z0nek, z0bek.z0oek() + z0bek.z0uek() / 2f, z0bek.z0pek(), z0bek.z0oek() + z0bek.z0uek() / 2f, z0bek.z0nek());
			break;
		case ShapeTypes.XCross:
			p0.z0eek(z0nek, z0bek.z0oek(), z0bek.z0pek(), z0bek.z0mek(), z0bek.z0nek());
			p0.z0eek(z0nek, z0bek.z0mek(), z0bek.z0pek(), z0bek.z0oek(), z0bek.z0nek());
			break;
		case ShapeTypes.CircleXCross:
		{
			z0ZzZzbdh p2 = z0pek();
			float num = (int)((double)(p2.z0uek() / 2f) * Math.Sin(Math.PI / 4.0));
			new z0ZzZznfh();
			float num2 = z0bek.z0oek() + z0bek.z0uek() / 2f;
			float num3 = z0bek.z0pek() + z0bek.z0iek() / 2f;
			p0.z0eek(z0nek, num2 - num, num3 - num, num2 + num, num3 + num);
			p0.z0eek(z0nek, num2 + num, num3 - num, num2 - num, num3 + num);
			p0.z0eek(z0nek, p2);
			break;
		}
		case ShapeTypes.CircleCross:
		{
			z0ZzZzbdh p1 = z0pek();
			p0.z0eek(z0nek, p1.z0oek(), p1.z0pek() + p1.z0iek() / 2f, p1.z0mek(), p1.z0pek() + p1.z0iek() / 2f);
			p0.z0eek(z0nek, p1.z0oek() + p1.z0uek() / 2f, p1.z0pek(), p1.z0oek() + p1.z0uek() / 2f, p1.z0nek());
			p0.z0eek(z0nek, p1);
			break;
		}
		default:
		{
			z0ZzZznfh z0ZzZznfh2 = z0tek();
			if (z0ZzZznfh2 != null)
			{
				p0.z0eek(z0nek, z0ZzZznfh2);
				z0ZzZznfh2.Dispose();
			}
			break;
		}
		}
	}

	public z0ZzZzbdh z0yek()
	{
		return z0bek;
	}

	public void z0eek(ShapeTypes p0)
	{
		z0cek = p0;
	}

	public static z0ZzZznfh z0eek(z0ZzZzbdh p0, float p1)
	{
		z0ZzZznfh z0ZzZznfh2 = new z0ZzZznfh();
		if (p1 <= 0f)
		{
			z0ZzZznfh2.z0eek(p0);
			return z0ZzZznfh2;
		}
		z0ZzZznfh2.z0eek(p0.z0oek(), p0.z0pek(), p1, p1, 270f, -90f);
		z0ZzZznfh2.z0tek(p0.z0oek(), p0.z0pek() + p1 / 2f, p0.z0oek(), p0.z0nek() - p1 / 2f);
		z0ZzZznfh2.z0eek(p0.z0oek(), p0.z0nek() - p1, p1, p1, 180f, -90f);
		z0ZzZznfh2.z0tek(p0.z0oek() + p1 / 2f, p0.z0nek(), p0.z0mek() - p1 / 2f, p0.z0nek());
		z0ZzZznfh2.z0eek(p0.z0mek() - p1, p0.z0nek() - p1, p1, p1, 90f, -90f);
		z0ZzZznfh2.z0tek(p0.z0mek(), p0.z0nek() - p1 / 2f, p0.z0mek(), p0.z0pek() + p1 / 2f);
		z0ZzZznfh2.z0eek(p0.z0mek() - p1, p0.z0pek(), p1, p1, 0f, -90f);
		z0ZzZznfh2.z0tek(p0.z0mek() - p1 / 2f, p0.z0pek(), p0.z0oek() + p1 / 2f, p0.z0pek());
		z0ZzZznfh2.z0uek();
		return z0ZzZznfh2;
	}

	public void z0eek(z0ZzZzadh p0)
	{
		if (z0vek == null || p0 == null)
		{
			return;
		}
		switch (z0cek)
		{
		case ShapeTypes.CircleXCross:
		{
			z0ZzZzbdh p1 = z0pek();
			p0.z0eek(z0vek, p1);
			return;
		}
		case ShapeTypes.CircleCross:
		{
			z0ZzZzbdh p2 = z0pek();
			p0.z0eek(z0vek, p2);
			return;
		}
		case ShapeTypes.Cross:
		case ShapeTypes.XCross:
			return;
		}
		z0ZzZznfh z0ZzZznfh2 = z0tek();
		if (z0ZzZznfh2 != null)
		{
			p0.z0eek(z0vek, z0ZzZznfh2);
			z0ZzZznfh2.Dispose();
		}
	}

	public z0ZzZzfmk(z0ZzZzbdh p0, ShapeTypes p1, Color p2, Color p3)
	{
		z0bek = p0;
		z0cek = p1;
		z0nek = new z0ZzZzudh(p2);
		z0vek = new z0ZzZzzdh(p3);
	}

	public void z0uek()
	{
		if (z0nek != null)
		{
			z0nek.Dispose();
			z0nek = null;
		}
		if (z0vek != null)
		{
			z0vek.Dispose();
			z0vek = null;
		}
	}

	public static z0ZzZznfh z0rek(z0ZzZzbdh p0)
	{
		float num = p0.z0uek() / 2f;
		float num2 = p0.z0iek() / 2f;
		z0ZzZznfh obj = new z0ZzZznfh();
		obj.z0tek(p0.z0oek() + num, p0.z0pek(), p0.z0mek(), p0.z0pek() + num2);
		obj.z0tek(p0.z0mek(), p0.z0pek() + num2, p0.z0oek() + num, p0.z0nek());
		obj.z0tek(p0.z0oek() + num, p0.z0nek(), p0.z0oek(), p0.z0pek() + num2);
		obj.z0tek(p0.z0oek(), p0.z0pek() + num2, p0.z0oek() + num, p0.z0pek());
		return obj;
	}

	public void z0rek(z0ZzZzjpk p0)
	{
		if (p0 != null)
		{
			if (z0vek != null)
			{
				z0tek(p0);
			}
			if (z0nek != null)
			{
				z0eek(p0);
			}
		}
	}

	public void z0rek(z0ZzZzadh p0)
	{
		if (p0 != null)
		{
			if (z0vek != null)
			{
				z0eek(p0);
			}
			if (z0nek != null)
			{
				z0tek(p0);
			}
		}
	}

	public z0ZzZzudh z0iek()
	{
		return z0nek;
	}

	public static z0ZzZznfh z0eek(z0ZzZzbdh p0, int p1)
	{
		if (p1 < 0 || p1 > 3)
		{
			throw new ArgumentOutOfRangeException("direction", "0->3");
		}
		z0ZzZznfh z0ZzZznfh2 = new z0ZzZznfh();
		float num = p0.z0uek() / 2f;
		float num2 = p0.z0iek() / 2f;
		switch (p1)
		{
		case 0:
			z0ZzZznfh2.z0tek(p0.z0oek() + num, p0.z0pek(), p0.z0mek(), p0.z0nek());
			z0ZzZznfh2.z0tek(p0.z0mek(), p0.z0nek(), p0.z0oek(), p0.z0nek());
			z0ZzZznfh2.z0tek(p0.z0oek(), p0.z0nek(), p0.z0oek() + num, p0.z0pek());
			break;
		case 1:
			z0ZzZznfh2.z0tek(p0.z0oek(), p0.z0pek(), p0.z0mek(), p0.z0pek() + num2);
			z0ZzZznfh2.z0tek(p0.z0mek(), p0.z0pek() + num2, p0.z0oek(), p0.z0nek());
			z0ZzZznfh2.z0tek(p0.z0oek(), p0.z0nek(), p0.z0oek(), p0.z0pek());
			break;
		case 2:
			z0ZzZznfh2.z0tek(p0.z0oek(), p0.z0pek(), p0.z0mek(), p0.z0pek());
			z0ZzZznfh2.z0tek(p0.z0mek(), p0.z0pek(), p0.z0oek() + num, p0.z0nek());
			z0ZzZznfh2.z0tek(p0.z0oek() + num, p0.z0nek(), p0.z0oek(), p0.z0pek());
			break;
		case 3:
			z0ZzZznfh2.z0tek(p0.z0oek(), p0.z0pek() + num2, p0.z0mek(), p0.z0pek());
			z0ZzZznfh2.z0tek(p0.z0mek(), p0.z0pek(), p0.z0mek(), p0.z0nek());
			z0ZzZznfh2.z0tek(p0.z0mek(), p0.z0nek(), p0.z0oek(), p0.z0pek() + num2);
			break;
		}
		return z0ZzZznfh2;
	}

	public ShapeTypes z0oek()
	{
		return z0cek;
	}

	public void z0eek(float p0)
	{
		z0mek = p0;
	}

	public void z0tek(z0ZzZzadh p0)
	{
		if (z0nek == null || p0 == null)
		{
			return;
		}
		switch (z0cek)
		{
		case ShapeTypes.Cross:
			p0.z0eek(z0nek, z0bek.z0oek(), z0bek.z0pek() + z0bek.z0iek() / 2f, z0bek.z0mek(), z0bek.z0pek() + z0bek.z0iek() / 2f);
			p0.z0eek(z0nek, z0bek.z0oek() + z0bek.z0uek() / 2f, z0bek.z0pek(), z0bek.z0oek() + z0bek.z0uek() / 2f, z0bek.z0nek());
			break;
		case ShapeTypes.XCross:
			p0.z0eek(z0nek, z0bek.z0oek(), z0bek.z0pek(), z0bek.z0mek(), z0bek.z0nek());
			p0.z0eek(z0nek, z0bek.z0mek(), z0bek.z0pek(), z0bek.z0oek(), z0bek.z0nek());
			break;
		case ShapeTypes.CircleXCross:
		{
			z0ZzZzbdh p2 = z0pek();
			float num = (int)((double)(p2.z0uek() / 2f) * Math.Sin(Math.PI / 4.0));
			new z0ZzZznfh();
			float num2 = z0bek.z0oek() + z0bek.z0uek() / 2f;
			float num3 = z0bek.z0pek() + z0bek.z0iek() / 2f;
			p0.z0eek(z0nek, num2 - num, num3 - num, num2 + num, num3 + num);
			p0.z0eek(z0nek, num2 + num, num3 - num, num2 - num, num3 + num);
			p0.z0eek(z0nek, p2);
			break;
		}
		case ShapeTypes.CircleCross:
		{
			z0ZzZzbdh p1 = z0pek();
			p0.z0eek(z0nek, p1.z0oek(), p1.z0pek() + p1.z0iek() / 2f, p1.z0mek(), p1.z0pek() + p1.z0iek() / 2f);
			p0.z0eek(z0nek, p1.z0oek() + p1.z0uek() / 2f, p1.z0pek(), p1.z0oek() + p1.z0uek() / 2f, p1.z0nek());
			p0.z0eek(z0nek, p1);
			break;
		}
		default:
		{
			z0ZzZznfh z0ZzZznfh2 = z0tek();
			if (z0ZzZznfh2 != null)
			{
				p0.z0eek(z0nek, z0ZzZznfh2);
				z0ZzZznfh2.Dispose();
			}
			break;
		}
		}
	}

	private z0ZzZzbdh z0pek()
	{
		if (z0bek.z0uek() > z0bek.z0iek())
		{
			return new z0ZzZzbdh(z0bek.z0oek() + (z0bek.z0uek() - z0bek.z0iek()) / 2f, z0bek.z0pek(), z0bek.z0iek(), z0bek.z0iek());
		}
		return new z0ZzZzbdh(z0bek.z0oek(), z0bek.z0pek() + (z0bek.z0iek() - z0bek.z0uek()) / 2f, z0bek.z0uek(), z0bek.z0uek());
	}

	public void z0tek(z0ZzZzjpk p0)
	{
		if (z0vek == null || p0 == null)
		{
			return;
		}
		switch (z0cek)
		{
		case ShapeTypes.CircleXCross:
		{
			z0ZzZzbdh p1 = z0pek();
			p0.z0eek(z0vek, p1);
			return;
		}
		case ShapeTypes.CircleCross:
		{
			z0ZzZzbdh p2 = z0pek();
			p0.z0eek(z0vek, p2);
			return;
		}
		case ShapeTypes.Cross:
		case ShapeTypes.XCross:
			return;
		}
		z0ZzZznfh z0ZzZznfh2 = z0tek();
		if (z0ZzZznfh2 != null)
		{
			p0.z0eek(z0vek, z0ZzZznfh2);
			z0ZzZznfh2.Dispose();
		}
	}
}
