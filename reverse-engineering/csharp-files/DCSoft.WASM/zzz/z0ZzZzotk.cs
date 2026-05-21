using System;
using DCSoft.Drawing;
using DCSystem_Drawing;

namespace zzz;

public class z0ZzZzotk : ICloneable
{
	private z0ZzZzbdh z0iek = z0ZzZzbdh.z0xek;

	private z0ZzZzntk z0oek_jiejie20260327142557 = new z0ZzZzntk();

	private z0ZzZzptk z0pek = new z0ZzZzptk();

	public z0ZzZzbdh z0eek()
	{
		return z0iek;
	}

	public z0ZzZzntk z0rek()
	{
		return z0oek_jiejie20260327142557;
	}

	private object z0tek()
	{
		z0ZzZzotk z0ZzZzotk2 = new z0ZzZzotk();
		z0ZzZzotk2.z0pek = z0pek.z0mek();
		z0ZzZzotk2.z0iek = z0iek;
		foreach (z0ZzZzmtk item in z0oek_jiejie20260327142557)
		{
			z0ZzZzotk2.z0oek_jiejie20260327142557.Add(item.z0eek());
		}
		return z0ZzZzotk2;
	}

	object ICloneable.Clone()
	{
		//ILSpy generated this explicit interface implementation from .override directive in z0tek
		return this.z0tek();
	}

	public void z0eek(z0ZzZzntk p0)
	{
		z0oek_jiejie20260327142557 = p0;
	}

	public z0ZzZzxdh z0eek(z0ZzZzjpk p0)
	{
		if (z0rek().Count == 0)
		{
			return new z0ZzZzxdh(0f, 0f);
		}
		if (p0 == null)
		{
			return z0ZzZzxdh.z0yek;
		}
		z0ZzZzxdh z0ZzZzxdh2 = p0.z0eek("###", z0yek().z0yek_jiejie20260327142557(), 10000);
		float num = z0ZzZzxdh2.z0rek();
		float num2 = z0ZzZzxdh2.z0rek();
		float num3 = (float)((double)z0ZzZzxdh2.z0tek() * 1.2);
		float num4 = 0f;
		foreach (z0ZzZzmtk item in z0rek())
		{
			float num5 = num;
			if (item.z0yek() != null)
			{
				num5 = p0.z0eek(item.z0yek(), z0yek().z0yek_jiejie20260327142557(), 10000).z0rek();
			}
			if (num5 < num)
			{
				num5 = num;
			}
			num4 = num4 + num5 + z0yek().z0pek() * 2f;
			if (num2 < num5)
			{
				num2 = num5;
			}
		}
		if (z0yek().z0oek() == DirectionStyles.Top || z0yek().z0oek() == DirectionStyles.Bottom)
		{
			return new z0ZzZzxdh((float)(int)num4 + z0yek().z0pek() * 3f, (int)(num3 * 2f));
		}
		float num6 = (int)(num2 + z0yek().z0pek() * 2f);
		if (z0yek().z0tek() > 0f && num6 > z0yek().z0tek())
		{
			num6 = z0yek().z0tek();
		}
		return new z0ZzZzxdh(num6, (int)((double)num3 * 1.5 * (double)z0rek().Count));
	}

	public void z0rek(z0ZzZzjpk p0)
	{
		if (z0rek() == null || z0rek().Count == 0 || p0 == null)
		{
			return;
		}
		z0ZzZzxdh z0ZzZzxdh2 = p0.z0eek("###", z0yek().z0yek_jiejie20260327142557(), 10000);
		float num = z0ZzZzxdh2.z0rek();
		float num2 = Math.Max((int)((double)z0ZzZzxdh2.z0tek() * 1.2), z0yek().z0pek());
		float num3 = 0f;
		foreach (z0ZzZzmtk item in z0rek())
		{
			if (item.z0yek() == null)
			{
				item.z0cek = num;
			}
			else
			{
				item.z0cek = Math.Max(num, p0.z0eek(item.z0yek(), z0yek().z0yek_jiejie20260327142557(), 10000).z0rek());
			}
			num3 = ((z0yek().z0oek() != DirectionStyles.Top && z0yek().z0oek() != DirectionStyles.Bottom) ? Math.Max(num3, item.z0cek + z0yek().z0pek() * 2f) : (num3 + item.z0cek + z0yek().z0pek() * 2f));
		}
		if (z0yek().z0oek() == DirectionStyles.Top || z0yek().z0oek() == DirectionStyles.Bottom)
		{
			int num4 = 0;
			if (num3 > z0eek().z0uek())
			{
				num4 = (int)((num3 - z0eek().z0uek()) / (float)z0rek().Count);
				num3 = z0eek().z0uek();
			}
			float num5 = (int)(z0eek().z0uek() - num3) / 2;
			float p1 = (z0eek().z0iek() - num2) / 2f;
			foreach (z0ZzZzmtk item2 in z0rek())
			{
				item2.z0bek = new z0ZzZzbdh(num5, p1, (int)(item2.z0cek + z0yek().z0pek() - (float)num4), num2);
				num5 += item2.z0mek().z0uek();
			}
		}
		else
		{
			int num6 = (int)(z0eek().z0uek() - num3) / 2;
			if (num3 > z0eek().z0uek())
			{
				num6 = 0;
				num3 = z0eek().z0uek();
			}
			float num7 = 0f;
			float num8 = num2;
			if ((double)z0eek().z0iek() > (double)(num2 * (float)z0rek().Count) * 1.5)
			{
				num7 = (int)((double)z0eek().z0iek() - (double)(num2 * (float)z0rek().Count) * 1.5) / 2;
				num8 = (int)((double)num2 * 1.5);
			}
			else
			{
				num7 = z0yek().z0pek() / 2f;
				num8 = (z0eek().z0iek() - z0yek().z0pek()) / (float)z0rek().Count;
			}
			foreach (z0ZzZzmtk item3 in z0rek())
			{
				item3.z0bek = new z0ZzZzbdh(num6, num7, (int)num3, num2);
				num7 += num8;
			}
		}
		foreach (z0ZzZzmtk item4 in z0rek())
		{
			z0ZzZzbdh z0ZzZzbdh2 = item4.z0mek();
			item4.z0vek = new z0ZzZzbdh(z0ZzZzbdh2.z0oek(), z0ZzZzbdh2.z0pek() + (z0ZzZzbdh2.z0iek() - z0yek().z0pek()) / 2f, z0yek().z0pek(), z0yek().z0pek());
			item4.z0zek = new z0ZzZzbdh((float)((double)z0ZzZzbdh2.z0oek() + (double)z0yek().z0pek() * 1.2), z0ZzZzbdh2.z0pek(), (float)((double)z0ZzZzbdh2.z0uek() - (double)z0yek().z0pek() * 1.2), z0ZzZzbdh2.z0iek());
		}
	}

	public void z0eek(z0ZzZzjpk p0, z0ZzZzbdh p1)
	{
		if (p0 == null || z0rek() == null || z0rek().Count == 0)
		{
			return;
		}
		if (z0yek().z0iek() != null && z0yek().z0iek().z0nek())
		{
			using z0ZzZztfh p2 = z0yek().z0iek().z0eek(z0iek);
			p0.z0rek(p2, z0iek);
		}
		using z0ZzZzlsh z0ZzZzlsh2 = new z0ZzZzlsh();
		z0ZzZzlsh2.z0rek(StringAlignment.Near);
		z0ZzZzlsh2.z0eek(StringAlignment.Center);
		z0ZzZzlsh2.z0eek((z0ZzZzksh)4096);
		foreach (z0ZzZzmtk item in z0rek())
		{
			if (!p1.z0bek())
			{
				z0ZzZzbdh p3 = item.z0mek();
				p3.z0tek(z0iek.z0oek(), z0iek.z0pek());
				if (!p1.z0tek(p3))
				{
					continue;
				}
			}
			z0ZzZzfmk z0ZzZzfmk2 = new z0ZzZzfmk();
			z0ZzZzfmk2.z0eek(item.z0tek());
			z0ZzZzbdh p4 = item.z0oek();
			p4.z0tek(z0iek.z0oek(), z0iek.z0pek());
			z0ZzZzfmk2.z0eek(p4);
			if (z0ZzZzfmk2.z0oek() == ShapeTypes.Cross || z0ZzZzfmk2.z0oek() == ShapeTypes.XCross)
			{
				z0ZzZzfmk2.z0eek(new z0ZzZzudh(item.z0iek(), item.z0pek()));
				z0ZzZzfmk2.z0eek(p0);
			}
			else
			{
				z0ZzZzfmk2.z0eek(new z0ZzZzudh(Color.Black));
				z0ZzZzfmk2.z0eek(new z0ZzZzzdh(item.z0iek()));
				z0ZzZzfmk2.z0rek(p0);
			}
			z0ZzZzfmk2.z0uek();
			if (item.z0yek() != null)
			{
				z0ZzZzbdh p5 = item.z0uek();
				p5.z0tek(z0iek.z0oek(), z0iek.z0pek());
				p0.z0eek(item.z0yek(), z0yek().z0yek_jiejie20260327142557(), Color.Black, p5, z0ZzZzlsh2);
			}
		}
	}

	public void z0eek(z0ZzZzptk p0)
	{
		if (p0 == null)
		{
			z0pek = new z0ZzZzptk();
		}
		else
		{
			z0pek = p0;
		}
	}

	public z0ZzZzbdh z0rek(z0ZzZzjpk p0, z0ZzZzbdh p1)
	{
		z0ZzZzxdh z0ZzZzxdh2 = new z0ZzZzxdh(z0yek().z0uek(), z0yek().z0uek());
		if (z0yek().z0nek())
		{
			z0ZzZzxdh2 = z0eek(p0);
		}
		if ((z0yek().z0oek() == DirectionStyles.Left || z0yek().z0oek() == DirectionStyles.Right) && z0yek().z0tek() > 0f && z0ZzZzxdh2.z0rek() > z0yek().z0tek())
		{
			z0ZzZzxdh2.z0eek(z0yek().z0tek());
		}
		float num = z0ZzZzxdh2.z0rek() + z0yek().z0pek();
		float num2 = z0ZzZzxdh2.z0tek() + z0yek().z0pek();
		switch (z0yek().z0oek())
		{
		case DirectionStyles.Left:
			z0eek(new z0ZzZzbdh(p1.z0oek(), p1.z0pek(), z0ZzZzxdh2.z0rek(), p1.z0iek()));
			return new z0ZzZzbdh(p1.z0oek() + num, p1.z0pek(), p1.z0uek() - num, p1.z0iek());
		case DirectionStyles.Top:
			z0eek(new z0ZzZzbdh(p1.z0oek(), p1.z0pek(), p1.z0uek(), z0ZzZzxdh2.z0tek()));
			return new z0ZzZzbdh(p1.z0oek(), p1.z0pek() + num2, p1.z0uek(), p1.z0iek() - num2);
		case DirectionStyles.Right:
			z0eek(new z0ZzZzbdh(Math.Max(p1.z0oek(), p1.z0mek() - z0ZzZzxdh2.z0rek()), p1.z0pek(), z0ZzZzxdh2.z0rek(), p1.z0iek()));
			return new z0ZzZzbdh(p1.z0oek(), p1.z0pek(), p1.z0uek() - num, p1.z0iek());
		case DirectionStyles.Bottom:
			z0eek(new z0ZzZzbdh(p1.z0oek(), Math.Max(p1.z0pek(), p1.z0nek() - z0ZzZzxdh2.z0tek()), p1.z0uek(), z0ZzZzxdh2.z0tek()));
			return new z0ZzZzbdh(p1.z0oek(), p1.z0pek(), p1.z0uek(), p1.z0iek() - num2);
		default:
			throw new Exception("错误的Dock值");
		}
	}

	public void z0eek(z0ZzZzbdh p0)
	{
		z0iek = p0;
	}

	public z0ZzZzptk z0yek()
	{
		return z0pek;
	}

	public z0ZzZzotk z0uek()
	{
		return (z0ZzZzotk)((ICloneable)this).Clone();
	}
}
