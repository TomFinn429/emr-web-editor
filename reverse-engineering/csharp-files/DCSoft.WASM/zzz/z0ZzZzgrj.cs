using System;
using DCSoft.Drawing;
using DCSoft.Printing;
using DCSystem_Drawing;

namespace zzz;

public class z0ZzZzgrj
{
	private z0ZzZzxpk z0hrk;

	private z0ZzZzerj z0grk;

	private Color z0frk = Color.White;

	private z0ZzZzlrj z0drk;

	private float z0srk = 1f;

	private z0ZzZzxej z0ark = (z0ZzZzxej)1;

	private float z0qrk = 1f;

	private z0ZzZzpmk z0wrk;

	private bool z0erk = true;

	protected z0ZzZzsmk z0rrk;

	private string z0trk;

	private Color z0yrk = Color.Transparent;

	private bool z0urk = true;

	private z0ZzZzvpk z0irk;

	private z0ZzZzjrj z0ork;

	private int z0prk = 60;

	protected float z0eek()
	{
		float num = z0lrk();
		if ((double)num <= 0.01)
		{
			return 1f;
		}
		if (num < 0.2f)
		{
			num = 0.2f;
		}
		if (num > 5f)
		{
			num = 5f;
		}
		return num;
	}

	public void z0eek(bool p0)
	{
		z0urk = p0;
	}

	public string z0rek()
	{
		return z0trk;
	}

	public void z0eek(Color p0)
	{
		z0frk = p0;
	}

	public void z0eek(z0ZzZzjrj p0)
	{
		z0ork = p0;
		if (p0 != null)
		{
			z0grk = p0.z0eek();
		}
	}

	public virtual z0ZzZzrrj z0rp(z0ZzZzwrj p0, z0ZzZzjpk p1, z0ZzZzndh p2, bool p3)
	{
		z0ZzZzrrj z0ZzZzrrj2 = new z0ZzZzrrj();
		z0ZzZzrrj2.z0eek(p0);
		z0ZzZzrrj2.z0yek(p0.z0xek());
		z0ZzZzrrj2.z0eek(p0.z0xek());
		int num = 0;
		int num2 = 0;
		if (p3)
		{
			num = (int)p0.z0hrk();
			num2 = (int)p0.z0frk();
		}
		float p4 = z0pek();
		float p5 = z0eek();
		p1.z0eek(GraphicsUnit.Document);
		z0ZzZzndh z0ZzZzndh2 = z0ZzZzndh.z0cek;
		if (z0trk != null)
		{
			p1.z0eek(z0trk, z0ZzZzimk.z0oek, z0ZzZzyfh.z0oek, 20f, 20f, z0ZzZzlsh.z0rek());
		}
		if (z0krk() != null)
		{
			using z0ZzZzudh p6 = z0krk().z0iek();
			p1.z0zek();
			p1.z0rek();
			p1.z0eek(p4, p5);
			p1.z0rek(num, num2);
			z0ZzZzndh p7 = new z0ZzZzndh((int)(0f + z0krk().PaddingLeft), (int)(0f + z0krk().PaddingTop), (int)(p0.z0rrk() - z0krk().PaddingLeft - z0krk().PaddingRight), (int)(p0.z0crk() - z0krk().PaddingTop - z0krk().PaddingBottom));
			p1.z0eek(p6, p7);
		}
		if (z0xek())
		{
			if (p0.z0prk() > 0f)
			{
				p1.z0zek();
				p1.z0rek();
				z0ZzZzndh2 = new z0ZzZzndh(0, 0, (int)Math.Ceiling(p0.z0oek()), (int)Math.Ceiling(p0.z0prk()));
				z0ZzZzrrj2.z0eek(Math.Min(z0ZzZzrrj2.z0eek(), num2));
				p1.z0eek(p4, p5);
				p1.z0rek(num, num2);
				p1.z0eek(z0eek(new z0ZzZzbdh(z0ZzZzndh2.z0pek(), z0ZzZzndh2.z0mek(), z0ZzZzndh2.z0iek() + 1, z0ZzZzndh2.z0oek() + 1)));
				z0ZzZzkrj z0ZzZzkrj2 = new z0ZzZzkrj(p1, z0ZzZzndh2, z0ork, p0, p0.z0yek() ? PageContentPartyStyle.HeaderForFirstPage : PageContentPartyStyle.Header, null);
				z0ZzZzkrj2.z0eek(z0tek());
				z0ZzZzkrj2.z0rek(z0ZzZzndh2);
				z0ZzZzkrj2.z0eek(z0ZzZzndh2.z0eek());
				z0ZzZzkrj2.z0eek(p0.z0vek());
				z0ZzZzkrj2.z0rek(z0jrk().Count);
				z0ZzZzkrj2.z0rek(z0ZzZzndh2);
				if (p0.z0trk().z0eek(p0.z0brk()))
				{
					z0ork.z0rek(z0ZzZzkrj2);
				}
			}
			p1.z0rek();
			p1.z0zek();
			if (!p0.z0krk().z0bek())
			{
				p1.z0zek();
				p1.z0rek();
				z0ZzZzrrj2.z0eek(Math.Min(p0.z0krk().z0pek(), z0ZzZzrrj2.z0eek()));
				z0ZzZzndh2 = new z0ZzZzndh((int)p0.z0krk().z0oek() - 1, (int)p0.z0krk().z0pek() - 1, (int)p0.z0krk().z0uek() + 1, (int)p0.z0krk().z0iek() + 1);
				p1.z0eek(p4, p5);
				p1.z0rek(num, (float)num2 - p0.z0krk().z0pek());
				p1.z0eek(z0eek(new z0ZzZzbdh(z0ZzZzndh2.z0pek(), z0ZzZzndh2.z0mek(), z0ZzZzndh2.z0iek() + 1, z0ZzZzndh2.z0oek() + 1)));
				z0ZzZzkrj z0ZzZzkrj3 = new z0ZzZzkrj(p1, z0ZzZzndh2, z0ork, p0, PageContentPartyStyle.Header, null);
				z0ZzZzkrj3.z0rek(z0ZzZzndh2);
				z0ZzZzkrj3.z0eek(z0ZzZzndh2.z0eek());
				z0ZzZzkrj3.z0eek(p0.z0vek());
				z0ZzZzkrj3.z0rek(z0jrk().Count);
				z0ZzZzkrj3.z0rek(z0ZzZzndh2);
				z0ork.z0rek(z0ZzZzkrj3);
			}
		}
		z0ZzZzndh2 = new z0ZzZzndh(0, (int)Math.Floor(p0.z0irk()), (int)Math.Ceiling(p0.z0oek()), (int)Math.Ceiling(p0.z0xek()));
		if (!p2.z0vek())
		{
			z0ZzZzndh2 = z0ZzZzndh.z0tek(z0ZzZzndh2, p2);
		}
		if (!z0ZzZzndh2.z0vek())
		{
			p1.z0eek(p4, p5);
			p1.z0rek(num, (float)num2 - p0.z0irk() + p0.z0prk() + p0.z0krk().z0iek());
			z0ZzZzpdh[] array = new z0ZzZzpdh[2]
			{
				new z0ZzZzpdh(p0.z0bek(), p0.z0irk()),
				new z0ZzZzpdh(p0.z0bek() + p0.z0oek(), p0.z0irk() + p0.z0xek())
			};
			p1.z0jrk().z0eek(array);
			z0rrk = new z0ZzZzsmk();
			z0rrk.z0rek(new z0ZzZzbdh(array[0].z0rek(), array[0].z0tek(), array[1].z0rek() - array[0].z0rek(), array[1].z0tek() - array[0].z0tek()));
			z0rrk.z0eek(new z0ZzZzbdh(p0.z0bek(), p0.z0irk(), p0.z0oek(), p0.z0xek()));
			z0ZzZzrrj2.z0eek(Math.Min(z0ZzZzrrj2.z0eek(), array[0].z0tek()));
			z0ZzZzbdh p8 = z0ZzZzdpk.z0eek(p1, z0ZzZzndh2.z0pek(), z0ZzZzndh2.z0mek(), z0ZzZzndh2.z0iek(), z0ZzZzndh2.z0oek());
			p8.z0tek(-4f, -4f);
			p8.z0tek(p8.z0uek() + 8f);
			p8.z0yek(p8.z0iek() + 8f);
			p1.z0eek(z0eek(p8));
			z0ZzZzkrj z0ZzZzkrj4 = new z0ZzZzkrj(p1, z0ZzZzndh2, z0ork, p0, PageContentPartyStyle.Body, null);
			z0ZzZzkrj4.z0eek(p0.z0vek());
			z0ZzZzkrj4.z0rek(z0jrk().Count);
			z0ZzZzkrj4.z0rek(z0ZzZzndh2);
			z0ZzZzkrj4.z0eek(z0ZzZzndh2.z0eek());
			z0ork.z0rek(z0ZzZzkrj4);
		}
		if (z0uek() && p0.z0wrk() > 0f)
		{
			p1.z0rek();
			p1.z0zek();
			float num3 = p0.z0tek();
			z0ZzZzndh2 = new z0ZzZzndh(0, (int)Math.Floor(num3 - p0.z0wrk()), (int)Math.Ceiling(p0.z0oek()), (int)Math.Ceiling(p0.z0wrk()));
			int num4 = 0;
			num4 = ((!p3) ? ((int)(p0.z0crk() - p0.z0mek_jiejie20260327142557() - p0.z0frk())) : ((int)(p0.z0crk() - p0.z0mek_jiejie20260327142557())));
			p1.z0eek(p4, p5);
			p1.z0rek(num, num4);
			p1.z0eek(z0eek(new z0ZzZzbdh(z0ZzZzndh2.z0pek(), z0ZzZzndh2.z0mek(), z0ZzZzndh2.z0iek() + 1, z0ZzZzndh2.z0oek() + 1)));
			z0ZzZzkrj z0ZzZzkrj5 = new z0ZzZzkrj(p1, z0ZzZzndh2, z0ork, p0, (!p0.z0yek()) ? PageContentPartyStyle.Footer : PageContentPartyStyle.FooterForFirstPage, null);
			z0ZzZzkrj5.z0rek(z0ZzZzndh2);
			z0ZzZzkrj5.z0eek(z0ZzZzndh2.z0eek());
			z0ZzZzkrj5.z0eek(p0.z0vek());
			z0ZzZzkrj5.z0rek(z0jrk().Count);
			if (p0.z0trk().z0eek(p0.z0brk()))
			{
				z0ork.z0rek(z0ZzZzkrj5);
			}
		}
		return z0ZzZzrrj2;
	}

	public z0ZzZzlrj z0tek()
	{
		return z0drk;
	}

	public Color z0yek()
	{
		return z0frk;
	}

	public void z0eek(float p0)
	{
		z0qrk = p0;
	}

	public z0ZzZzrfh z0eek(int p0, bool p1)
	{
		return z0eek(z0grk[p0], p1);
	}

	public bool z0uek()
	{
		return z0urk;
	}

	public float z0iek_jiejie20260327142557()
	{
		return z0srk;
	}

	protected virtual z0ZzZzcpk z0oek()
	{
		return new z0ZzZzcpk();
	}

	public void z0eek(int p0)
	{
		z0prk = p0;
	}

	public void z0eek(z0ZzZzpmk p0)
	{
		z0wrk = p0;
	}

	protected float z0pek()
	{
		float num = z0iek_jiejie20260327142557();
		if ((double)num <= 0.01)
		{
			return 1f;
		}
		if (num < 0.2f)
		{
			num = 0.2f;
		}
		if (num > 5f)
		{
			num = 5f;
		}
		return num;
	}

	public void z0eek(z0ZzZzvpk p0)
	{
		z0irk = p0;
	}

	public void z0eek(string p0)
	{
		z0trk = p0;
	}

	public z0ZzZzxej z0mek()
	{
		return z0ark;
	}

	public void z0eek(z0ZzZzxpk p0)
	{
		z0hrk = p0;
	}

	public z0ZzZzxpk z0nek()
	{
		return z0hrk;
	}

	public void z0eek(z0ZzZzwrj p0, z0ZzZzjpk p1, bool p2)
	{
		if (z0frk.A != 0)
		{
			p1.z0eek(z0frk);
		}
		p1.z0eek(GraphicsUnit.Document);
		z0ZzZzarj z0ZzZzarj2 = new z0ZzZzarj(p0, p1: true);
		z0ZzZzcpk obj = z0oek();
		obj.z0tek(p2);
		obj.z0rek(z0cek());
		obj.z0eek(Color.Transparent);
		obj.z0tek(z0yrk);
		obj.z0eek(1);
		obj.z0yek((int)(z0ZzZzarj2.z0bek() * z0iek_jiejie20260327142557()));
		obj.z0iek((int)(z0ZzZzarj2.z0pek() * z0lrk()));
		obj.z0tek((int)(z0ZzZzarj2.z0cek() * z0iek_jiejie20260327142557()));
		obj.z0uek((int)(z0ZzZzarj2.z0mek() * z0lrk()));
		obj.z0eek(z0krk());
		obj.z0rek(new z0ZzZzndh(0, 0, (int)(z0ZzZzarj2.z0xek() * z0iek_jiejie20260327142557()), (int)(z0ZzZzarj2.z0nek() * z0lrk())));
		obj.z0eek(p1, z0ZzZzndh.z0cek);
		z0rp(p0, p1, z0ZzZzndh.z0eek(p0.z0eek()), p3: true);
		if (z0ark != (z0ZzZzxej)1 && z0nek() != null)
		{
			p1.z0zek();
			p1.z0rek();
			z0nek().z0eek(p1, new z0ZzZzbdh(0f, 0f, p0.z0rrk(), p0.z0crk()), p2: true, z0ZzZzbdh.z0xek);
		}
	}

	public z0ZzZzrfh z0eek(z0ZzZzwrj p0, bool p1)
	{
		XPageSettings xPageSettings = p0.z0trk();
		double num = z0ZzZzrpk.z0eek(GraphicsUnit.Document, GraphicsUnit.Pixel);
		int num2 = (int)(Math.Ceiling((double)xPageSettings.z0drk() / num) * (double)z0iek_jiejie20260327142557());
		int num3 = (int)(Math.Ceiling((double)xPageSettings.z0qrk() / num) * (double)z0lrk());
		if (num2 <= 0 || num3 <= 0)
		{
			return null;
		}
		z0ZzZzrfh z0ZzZzrfh2 = new z0ZzZzrfh(num2, num3);
		using z0ZzZzjpk p2 = z0ZzZzjpk.z0eek(z0ZzZzrfh2);
		z0eek(p0, p2, p1);
		return z0ZzZzrfh2;
	}

	public Color z0bek()
	{
		return z0yrk;
	}

	public z0ZzZzjrj z0vek()
	{
		return z0ork;
	}

	public void z0eek(z0ZzZzxej p0)
	{
		z0ark = p0;
	}

	public int z0cek()
	{
		return z0prk;
	}

	public bool z0xek()
	{
		return z0erk;
	}

	public void z0eek(z0ZzZzerj p0)
	{
		z0grk = p0;
	}

	protected z0ZzZzbdh z0eek(z0ZzZzbdh p0)
	{
		float num = z0pek();
		float num2 = z0eek();
		if (num != 1f)
		{
			p0.z0eek(p0.z0tek() * num);
			p0.z0tek(p0.z0uek() * num);
		}
		if (num2 != 1f)
		{
			p0.z0rek(p0.z0yek() * num2);
			p0.z0yek(p0.z0iek() * num2);
		}
		return p0;
	}

	public z0ZzZzpmk z0zek()
	{
		return z0wrk;
	}

	public float z0lrk()
	{
		return z0qrk;
	}

	public z0ZzZzvpk z0krk()
	{
		return z0irk;
	}

	public void z0rek(Color p0)
	{
		z0yrk = p0;
	}

	public void z0rek(bool p0)
	{
		z0erk = p0;
	}

	public void z0eek(z0ZzZzlrj p0)
	{
		z0drk = p0;
	}

	public z0ZzZzerj z0jrk()
	{
		return z0grk;
	}

	public void z0rek(float p0)
	{
		z0srk = p0;
	}
}
