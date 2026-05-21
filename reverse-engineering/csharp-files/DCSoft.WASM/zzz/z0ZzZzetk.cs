using System;
using DCSoft.Chart;
using DCSystem_Drawing;

namespace zzz;

internal class z0ZzZzetk
{
	private z0ZzZznmk z0nek = new z0ZzZznmk();

	private float z0bek = 45f;

	private z0ZzZznmk z0vek = new z0ZzZznmk();

	private float z0cek;

	private z0ZzZzemk z0xek = new z0ZzZzemk();

	protected z0ZzZzbdh z0zek = z0ZzZzbdh.z0xek;

	public z0ZzZzbdh z0eek()
	{
		return z0zek;
	}

	public float z0rek()
	{
		if (z0cek == 0f)
		{
			return 0f;
		}
		return 0f - (float)((double)z0cek * Math.Sin((double)z0bek * Math.PI / 180.0));
	}

	public void z0eek(z0ZzZzjpk p0, z0ZzZzbdh p1, z0ZzZzudh p2)
	{
		if (p2 == null || p0 == null)
		{
			return;
		}
		if (z0cek == 0f || z0xek == null)
		{
			z0ZzZzbdh z0ZzZzbdh2 = z0zek;
			if (!p1.z0bek())
			{
				z0ZzZzbdh2 = z0ZzZzbdh.z0tek(z0zek, p1);
			}
			if (!z0ZzZzbdh2.z0bek())
			{
				p0.z0rek(p2, z0zek);
			}
			return;
		}
		float num = z0uek();
		float num2 = z0rek();
		z0ZzZznfh z0ZzZznfh2 = null;
		z0ZzZznfh2 = z0ZzZzkmk.z0eek(z0zek.z0oek(), z0zek.z0pek(), z0zek.z0oek(), z0zek.z0nek(), num, num2);
		p0.z0eek(p2, z0ZzZznfh2);
		z0ZzZznfh2 = z0ZzZzkmk.z0eek(z0zek.z0oek(), z0zek.z0nek(), z0zek.z0mek(), z0zek.z0nek(), num, num2);
		p0.z0eek(p2, z0ZzZznfh2);
		z0ZzZzbdh p3 = z0zek;
		p3.z0tek((int)num, (int)num2);
		if (!p1.z0bek())
		{
			p3 = z0ZzZzbdh.z0tek(p3, p1);
		}
		p3 = z0zek;
		p3.z0tek((int)num, (int)num2);
		p0.z0rek(p2, p3);
	}

	public void z0eek(float p0)
	{
		z0cek = p0;
	}

	public void z0eek(z0ZzZzbdh p0)
	{
		z0zek = p0;
	}

	public z0ZzZznmk z0tek()
	{
		return z0vek;
	}

	public void z0rek(float p0)
	{
		z0bek = p0;
	}

	public z0ZzZznmk z0yek()
	{
		return z0nek;
	}

	public double z0eek(double p0, double p1)
	{
		return (double)z0zek.z0nek() - (double)z0zek.z0iek() * p0 * p1;
	}

	public double z0rek(double p0, double p1)
	{
		return (double)z0zek.z0oek() + (double)z0zek.z0uek() * p0 * p1;
	}

	public float z0uek()
	{
		if (z0cek == 0f)
		{
			return 0f;
		}
		return (float)((double)z0cek * Math.Cos((double)z0bek * Math.PI / 180.0));
	}

	public void z0eek(z0ZzZznmk p0)
	{
		if (p0 == null)
		{
			z0vek = new z0ZzZznmk();
		}
		else
		{
			z0vek = p0;
		}
	}

	public void z0eek(z0ZzZzbdh p0, z0ZzZzjpk p1, Color p2, z0ZzZzbdh p3, float p4, bool p5)
	{
		if (!p3.z0bek())
		{
			p3.z0rek(3f, 3f);
		}
		if (z0cek == 0f)
		{
			if (p3.z0bek() || p3.z0tek(p0))
			{
				using (z0ZzZzzdh p6 = new z0ZzZzzdh(p2))
				{
					p1.z0eek(p6, p0.z0oek(), p0.z0pek(), p0.z0uek(), p0.z0iek());
				}
				z0ZzZznmk z0ZzZznmk2 = z0tek().z0rek();
				if (z0ZzZznmk2.Color == Color.Transparent)
				{
					z0ZzZznmk2.Color = z0ZzZzvok.z0eek(p2, -0.3f);
				}
				using z0ZzZzudh p7 = z0ZzZznmk2.z0yek();
				p1.z0eek(p7, p0.z0oek(), p0.z0pek(), p0.z0uek(), p0.z0iek(), 0f);
				return;
			}
			return;
		}
		z0ZzZzvtk z0ZzZzvtk2 = null;
		if (p5)
		{
			float num = (float)((double)p0.z0iek() * Math.Cos((double)p4 * Math.PI / 180.0));
			float num2 = (float)((double)z0cek * Math.Cos((double)z0bek * Math.PI / 180.0));
			if (num > num2)
			{
				num = num2;
			}
			z0ZzZzvtk2 = new z0ZzZzvtk(new z0ZzZzbdh(p0.z0mek(), p0.z0pek(), num, p0.z0iek()), p0.z0uek());
			z0ZzZzvtk2.z0eek(p0: true);
		}
		else
		{
			float num3 = (float)((double)p0.z0uek() * Math.Sin((double)p4 * Math.PI / 180.0));
			float num4 = (float)((double)z0cek * Math.Sin((double)z0bek * Math.PI / 180.0));
			if (num3 > num4)
			{
				num3 = num4;
			}
			z0ZzZzvtk2 = new z0ZzZzvtk(new z0ZzZzbdh(p0.z0oek(), p0.z0pek() - num3, p0.z0uek(), num3), p0.z0iek());
			z0ZzZzvtk2.z0eek(p0: false);
		}
		if (p3.z0bek() || p3.z0tek(z0ZzZzvtk2.z0yek()))
		{
			z0ZzZznmk z0ZzZznmk3 = z0tek().z0rek();
			if (z0ZzZznmk3.Color == Color.Transparent)
			{
				z0ZzZznmk3.Color = z0ZzZzvok.z0eek(p2, -0.3f);
			}
			using z0ZzZzudh p8 = z0ZzZznmk3.z0yek();
			z0ZzZzvtk2.z0eek(p1, p8, p2, z0ZzZzvok.z0eek(p2, -0.15f));
		}
	}

	public void z0eek(z0ZzZzbdh p0, z0ZzZzjpk p1, Color p2, z0ZzZzbdh p3, float p4, ChartViewStyle p5)
	{
		using z0ZzZzzdh p6 = new z0ZzZzzdh(p2);
		z0ZzZznmk z0ZzZznmk2 = z0tek().z0rek();
		if (z0ZzZznmk2.Color == Color.Transparent)
		{
			z0ZzZznmk2.Color = z0ZzZzvok.z0eek(p2, -0.3f);
		}
		using z0ZzZzudh p7 = z0ZzZznmk2.z0yek();
		z0eek(p0.z0oek(), p0.z0pek(), p0.z0uek(), p0.z0iek(), p1, p7, p6, p3, p4, p5);
	}

	public void z0eek(z0ZzZzpdh p0, z0ZzZzpdh p1, z0ZzZzjpk p2, Color p3)
	{
		z0eek(p0.z0rek(), p0.z0tek(), p1.z0rek(), p1.z0tek(), p2, p3);
	}

	public void z0eek(float p0, float p1, float p2, float p3, z0ZzZzjpk p4, z0ZzZzudh p5, z0ZzZzzdh p6, z0ZzZzbdh p7, float p8, ChartViewStyle p9)
	{
		z0ZzZzbdh z0ZzZzbdh2 = new z0ZzZzbdh(p0, p1, p2, p3);
		if (!p7.z0bek())
		{
			p7.z0rek(3f, 3f);
		}
		if (z0cek == 0f)
		{
			if (!p7.z0bek() && !p7.z0tek(z0ZzZzbdh2))
			{
				return;
			}
			z0ZzZznfh z0ZzZznfh2 = new z0ZzZznfh();
			float num = 0f;
			if (p9 == ChartViewStyle.Bar)
			{
				num = z0ZzZzbdh2.z0uek() * p8;
				if (num > z0ZzZzbdh2.z0iek())
				{
					num = z0ZzZzbdh2.z0iek();
				}
				z0ZzZzbdh2.z0yek(z0ZzZzbdh2.z0iek() - num);
				z0ZzZzbdh2.z0tek(0f, num);
				if (num > 0f)
				{
					z0ZzZznfh2.z0eek(z0ZzZzbdh2.z0oek(), z0ZzZzbdh2.z0pek() - num, num * 2f, num * 2f, 180f, 90f);
				}
				z0ZzZznfh2.z0tek(z0ZzZzbdh2.z0oek() + num, z0ZzZzbdh2.z0pek() - num, z0ZzZzbdh2.z0mek() - num, z0ZzZzbdh2.z0pek() - num);
				if (num > 0f)
				{
					z0ZzZznfh2.z0eek(z0ZzZzbdh2.z0mek() - num * 2f, z0ZzZzbdh2.z0pek() - num, num * 2f, num * 2f, 270f, 90f);
				}
				z0ZzZznfh2.z0tek(z0ZzZzbdh2.z0mek(), z0ZzZzbdh2.z0pek(), z0ZzZzbdh2.z0mek(), z0ZzZzbdh2.z0nek());
				z0ZzZznfh2.z0tek(z0ZzZzbdh2.z0mek(), z0ZzZzbdh2.z0nek(), z0ZzZzbdh2.z0oek(), z0ZzZzbdh2.z0nek());
				z0ZzZznfh2.z0tek(z0ZzZzbdh2.z0oek(), z0ZzZzbdh2.z0nek(), z0ZzZzbdh2.z0oek(), z0ZzZzbdh2.z0pek());
			}
			else
			{
				num = z0ZzZzbdh2.z0iek() * p8;
				if (num > z0ZzZzbdh2.z0uek())
				{
					num = z0ZzZzbdh2.z0uek();
				}
				z0ZzZzbdh2.z0tek(z0ZzZzbdh2.z0uek() - num);
				if (num > 0f)
				{
					z0ZzZznfh2.z0eek(z0ZzZzbdh2.z0mek() - num, z0ZzZzbdh2.z0pek(), num * 2f, num * 2f, 270f, 90f);
				}
				z0ZzZznfh2.z0tek(z0ZzZzbdh2.z0mek() + num, z0ZzZzbdh2.z0pek() + num, z0ZzZzbdh2.z0mek() + num, z0ZzZzbdh2.z0nek() - num);
				if (num > 0f)
				{
					z0ZzZznfh2.z0eek(z0ZzZzbdh2.z0mek() - num, z0ZzZzbdh2.z0nek() - num * 2f, num * 2f, num * 2f, 0f, 90f);
				}
				z0ZzZznfh2.z0tek(z0ZzZzbdh2.z0mek(), z0ZzZzbdh2.z0nek(), z0ZzZzbdh2.z0oek(), z0ZzZzbdh2.z0nek());
				z0ZzZznfh2.z0tek(z0ZzZzbdh2.z0oek(), z0ZzZzbdh2.z0nek(), z0ZzZzbdh2.z0oek(), z0ZzZzbdh2.z0pek());
				z0ZzZznfh2.z0tek(z0ZzZzbdh2.z0oek(), z0ZzZzbdh2.z0pek(), z0ZzZzbdh2.z0mek(), z0ZzZzbdh2.z0pek());
			}
			z0ZzZznfh2.z0uek();
			if (p6 != null)
			{
				p4.z0eek(p6, z0ZzZznfh2);
			}
			if (p5 != null)
			{
				p4.z0eek(p5, z0ZzZznfh2);
			}
			return;
		}
		if (!p7.z0bek())
		{
			z0ZzZzbdh p10 = z0ZzZzbdh2;
			p10.z0tek(z0uek(), z0rek());
			p10 = z0ZzZzbdh.z0yek(z0ZzZzbdh2, p10);
			p10.z0rek(3f, 3f);
			if (!p7.z0tek(p10))
			{
				return;
			}
		}
		z0ZzZzctk z0ZzZzctk2 = new z0ZzZzctk(z0ZzZzbdh2, z0uek(), 0f - z0rek());
		if (p6 == null)
		{
			return;
		}
		using z0ZzZzzdh p11 = new z0ZzZzzdh(z0ZzZzvok.z0eek(p6.z0eek, -0.3f));
		z0ZzZzctk2.z0eek(p4, p5, p6, p11);
	}

	public z0ZzZzemk z0iek()
	{
		if (z0xek == null)
		{
			z0xek = new z0ZzZzemk();
		}
		return z0xek;
	}

	public void z0eek(int p0, z0ZzZzjpk p1, z0ZzZzudh p2)
	{
		float num = z0uek();
		float num2 = z0rek();
		p1.z0eek(p2, new z0ZzZzpdh[3]
		{
			new z0ZzZzpdh(z0zek.z0oek(), p0),
			new z0ZzZzpdh(z0zek.z0oek() + num, (float)p0 + num2),
			new z0ZzZzpdh(z0zek.z0mek() + num, (float)p0 + num2)
		});
	}

	public float z0oek()
	{
		return z0cek;
	}

	public void z0eek(float p0, float p1, float p2, float p3, z0ZzZzjpk p4, Color p5)
	{
		if (z0cek == 0f)
		{
			p4.z0tek(p5, p0, p1, p2, p3);
			return;
		}
		using z0ZzZzzdh p6 = new z0ZzZzzdh(p5);
		using z0ZzZznfh p7 = z0ZzZzkmk.z0eek(new z0ZzZzpdh(p0, p1), new z0ZzZzpdh(p2, p3), z0uek(), z0rek());
		p4.z0eek(p6, p7);
		if (z0nek != null)
		{
			z0ZzZznmk z0ZzZznmk2 = z0tek().z0rek();
			if (z0ZzZznmk2.Color == Color.Transparent)
			{
				z0ZzZznmk2.Color = z0ZzZzvok.z0eek(p5, -0.3f);
			}
			using z0ZzZzudh p8 = z0ZzZznmk2.z0yek();
			p4.z0eek(p8, p7);
			return;
		}
	}

	public void z0eek(float p0, float p1, float p2, float p3, z0ZzZzjpk p4, z0ZzZzudh p5, z0ZzZzzdh p6, z0ZzZzbdh p7)
	{
		z0ZzZzbdh z0ZzZzbdh2 = new z0ZzZzbdh(p0, p1, p2, p3);
		if (!p7.z0bek())
		{
			p7.z0rek(3f, 3f);
		}
		if (z0cek == 0f)
		{
			if (p7.z0bek() || p7.z0tek(z0ZzZzbdh2))
			{
				if (p6 != null)
				{
					p4.z0eek(p6, p0, p1, p2, p3);
				}
				if (p5 != null)
				{
					p4.z0eek(p5, p0, p1, p2, p3, 0f);
				}
			}
			return;
		}
		if (!p7.z0bek())
		{
			z0ZzZzbdh p8 = z0ZzZzbdh2;
			p8.z0tek(z0uek(), z0rek());
			p8 = z0ZzZzbdh.z0yek(z0ZzZzbdh2, p8);
			p8.z0rek(3f, 3f);
			if (!p7.z0tek(p8))
			{
				return;
			}
		}
		z0ZzZzctk z0ZzZzctk2 = new z0ZzZzctk(z0ZzZzbdh2, z0uek(), 0f - z0rek());
		if (p6 == null)
		{
			return;
		}
		using z0ZzZzzdh p9 = new z0ZzZzzdh(z0ZzZzvok.z0eek(p6.z0eek, -0.3f));
		z0ZzZzctk2.z0eek(p4, p5, p6, p9);
	}

	public float z0pek()
	{
		return z0bek;
	}

	public z0ZzZzbdh z0mek()
	{
		if (z0cek == 0f)
		{
			return z0zek;
		}
		z0ZzZzbdh p = z0zek;
		p.z0tek((int)z0uek(), (int)z0rek());
		return z0ZzZzbdh.z0yek(p, z0zek);
	}

	public void z0eek(z0ZzZzjpk p0, z0ZzZzbdh p1)
	{
		if (z0xek == null)
		{
			return;
		}
		if (z0cek == 0f)
		{
			z0ZzZzbdh p2 = z0zek;
			if (!p1.z0bek())
			{
				p2 = z0ZzZzbdh.z0tek(z0zek, p1);
			}
			if (!p2.z0bek() && z0xek != null)
			{
				z0ZzZztfh z0ZzZztfh2 = z0xek.z0eek(z0zek, p0.z0vek());
				if (z0ZzZztfh2 != null)
				{
					p0.z0rek(z0ZzZztfh2, p2);
					z0ZzZztfh2.Dispose();
				}
			}
			return;
		}
		float num = z0uek();
		float num2 = z0rek();
		z0ZzZznfh z0ZzZznfh2 = null;
		if (z0xek.z0pek())
		{
			using z0ZzZztfh p3 = z0xek.z0eek(z0zek, p0.z0vek());
			z0ZzZznfh2 = z0ZzZzkmk.z0eek(z0zek.z0oek(), z0zek.z0pek(), z0zek.z0oek(), z0zek.z0nek(), num, num2);
			p0.z0eek(p3, z0ZzZznfh2);
		}
		if (z0xek.z0pek())
		{
			z0ZzZznfh2 = z0ZzZzkmk.z0eek(z0zek.z0oek(), z0zek.z0nek(), z0zek.z0mek(), z0zek.z0nek(), num, num2);
			using z0ZzZzzdh p4 = new z0ZzZzzdh(z0ZzZzdpk.z0eek(z0xek.z0eek(), 30f));
			p0.z0eek(p4, z0ZzZznfh2);
		}
		z0ZzZzbdh z0ZzZzbdh2 = z0zek;
		z0ZzZzbdh2.z0tek((int)num, (int)num2);
		if (!p1.z0bek() && z0xek.z0pek())
		{
			z0ZzZzbdh2 = z0ZzZzbdh.z0tek(z0ZzZzbdh2, p1);
		}
		if (z0ZzZzbdh2.z0bek() || !(z0ZzZzbdh2.z0uek() > 0f) || !(z0ZzZzbdh2.z0iek() > 0f) || !z0xek.z0nek())
		{
			return;
		}
		using z0ZzZztfh p5 = z0xek.z0eek(z0ZzZzbdh2, p0.z0vek());
		p0.z0rek(p5, z0ZzZzbdh2);
	}

	public void z0rek(int p0, z0ZzZzjpk p1, z0ZzZzudh p2)
	{
		float num = z0uek();
		float num2 = z0rek();
		p1.z0eek(p2, new z0ZzZzpdh[3]
		{
			new z0ZzZzpdh(p0, z0zek.z0nek()),
			new z0ZzZzpdh((float)p0 + num, z0zek.z0nek() + num2),
			new z0ZzZzpdh((float)p0 + num, z0zek.z0pek() + num2)
		});
	}

	public void z0rek(z0ZzZznmk p0)
	{
		z0nek = p0;
	}

	public void z0eek(z0ZzZzemk p0)
	{
		z0xek = p0;
	}

	public void z0eek(z0ZzZzbdh p0, z0ZzZzjpk p1, Color p2, z0ZzZzbdh p3)
	{
		using z0ZzZzzdh p4 = new z0ZzZzzdh(p2);
		z0ZzZznmk z0ZzZznmk2 = z0tek().z0rek();
		if (z0ZzZznmk2.Color == Color.Transparent)
		{
			z0ZzZznmk2.Color = z0ZzZzvok.z0eek(p2, -0.3f);
		}
		using z0ZzZzudh p5 = z0ZzZznmk2.z0yek();
		z0eek(p0.z0oek(), p0.z0pek(), p0.z0uek(), p0.z0iek(), p1, p5, p4, p3);
	}
}
