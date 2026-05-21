using System;
using DCSoft.Drawing;
using DCSoft.Printing;
using DCSoft.Writer.Dom;
using DCSystem_Drawing;
using DCSystem_Drawing.Drawing2D;
using DCSystem_Drawing.Printing;

namespace zzz;

public class z0ZzZzocj : z0ZzZzgrj
{
	private new z0ZzZzbdh z0rek = z0ZzZzbdh.z0xek;

	internal new bool z0tek;

	internal new static bool z0yek = true;

	public override z0ZzZzrrj z0rp(z0ZzZzwrj p0, z0ZzZzjpk p1, z0ZzZzndh p2, bool p3)
	{
		z0rek = z0ZzZzbdh.z0xek;
		z0ZzZzrrj z0ZzZzrrj2 = new z0ZzZzrrj();
		z0ZzZzrrj2.z0eek(p0);
		z0ZzZzrrj2.z0yek(p0.z0xek());
		z0ZzZzrrj2.z0eek(p0.z0jrk());
		XTextDocument xTextDocument = (XTextDocument)z0vek();
		XPageSettings xPageSettings = p0.z0trk();
		if (xPageSettings == null)
		{
			xPageSettings = xTextDocument.PageSettings;
		}
		z0ZzZzarj z0ZzZzarj2 = new z0ZzZzarj(p0, p1: true);
		if (p3)
		{
			p2.z0eek(p2.z0yek() - (int)z0ZzZzarj2.z0bek());
			p2.z0tek(p2.z0iek() + (int)z0ZzZzarj2.z0bek() + (int)z0ZzZzarj2.z0cek());
		}
		if (xTextDocument.z0iik() > 0f && p0 == xTextDocument.z0suk().z0iek())
		{
			z0ZzZzrrj2.z0rek(p0.z0xek() - xTextDocument.z0iik());
			z0ZzZzrrj2.z0eek(xTextDocument.z0iik());
		}
		else
		{
			z0ZzZzrrj2.z0rek(p0.z0xek());
		}
		p1.z0eek(GraphicsUnit.Document);
		z0ZzZzndh z0ZzZzndh2 = z0ZzZzndh.z0cek;
		if (z0rek() != null)
		{
			p1.z0eek(z0rek(), z0ZzZzimk.z0oek, z0ZzZzyfh.z0oek, 20f, 20f, z0ZzZzlsh.z0rek());
		}
		if (xPageSettings.z0otk() && (z0ZzZzarj2.z0iek() > 0f || z0ZzZzarj2.z0eek() > 0f))
		{
			p1.z0eek(Color.Black, 1f, DashStyle.Dash, z0ZzZzarj2.z0iek(), z0ZzZzarj2.z0eek(), z0ZzZzarj2.z0yek(), z0ZzZzarj2.z0lrk());
		}
		float p4 = z0ZzZzarj2.z0vek();
		float num = Math.Max(xPageSettings.z0ztk(), p0.z0prk());
		int num2 = 0;
		p0.z0qtk = 0f;
		if (p0.z0prk() > 0f && p0.z0prk() > xPageSettings.z0ztk() - 10f)
		{
			num2 = (int)(p0.z0prk() - (xPageSettings.z0ztk() - 10f) + xTextDocument.z0jrk(XTextTableElement.z0utk));
			if (!z0yek)
			{
				num2 -= 10;
			}
			p0.z0qtk = 13f;
		}
		if (z0xek() || z0tek)
		{
			p1.z0zek();
			p1.z0rek();
			p1.z0eek(GraphicsUnit.Document);
			z0ZzZzndh2 = new z0ZzZzndh(-(int)z0ZzZzarj2.z0bek(), 0, (int)Math.Ceiling(p0.z0oek() + (float)(int)(z0ZzZzarj2.z0bek() + z0ZzZzarj2.z0cek())), (int)Math.Ceiling(num));
			p1.z0eek(z0pek(), z0eek());
			p1.z0rek((int)z0ZzZzarj2.z0bek(), p4);
			p1.z0eek(z0eek(new z0ZzZzbdh(z0ZzZzndh2.z0pek(), z0ZzZzndh2.z0mek(), z0ZzZzndh2.z0iek() + 1, z0ZzZzndh2.z0oek() + 2)));
			z0ZzZzkrj z0ZzZzkrj2 = new z0ZzZzkrj(p1, z0ZzZzndh2, xTextDocument, p0, p0.z0yek() ? PageContentPartyStyle.HeaderForFirstPage : PageContentPartyStyle.Header, null);
			z0ZzZzkrj2.z0eek(z0mek());
			z0ZzZzkrj2.z0rek(z0ZzZzndh2);
			z0ZzZzkrj2.z0eek(z0ZzZzndh2.z0eek());
			z0ZzZzkrj2.z0eek(z0tek());
			z0ZzZzkrj2.z0eek(p0.z0brk());
			if (xPageSettings.z0eek(p0.z0brk()))
			{
				if (z0tek() != null && z0mek() == (z0ZzZzxej)1 && z0tek().z0vek() == PrintRange.Selection && z0tek)
				{
					try
					{
						z0tek().z0rek(PrintRange.AllPages);
						((z0ZzZzjrj)xTextDocument).z0rek(z0ZzZzkrj2);
					}
					finally
					{
						z0tek().z0rek(PrintRange.Selection);
					}
				}
				else
				{
					((z0ZzZzjrj)xTextDocument).z0rek(z0ZzZzkrj2);
				}
				z0eek(xTextDocument, z0ZzZzkrj2.z0mek());
			}
			p1.z0rek();
			p1.z0zek();
			if (!p0.z0krk().z0bek())
			{
				p1.z0zek();
				p1.z0rek();
				p1.z0eek(GraphicsUnit.Document);
				z0ZzZzndh2 = new z0ZzZzndh((int)p0.z0krk().z0oek() - (int)z0ZzZzarj2.z0bek(), (int)p0.z0krk().z0pek() - 2, (int)p0.z0krk().z0uek() + (int)(z0ZzZzarj2.z0bek() + z0ZzZzarj2.z0cek()), (int)p0.z0krk().z0iek() + 4);
				z0ZzZzrrj2.z0eek(Math.Min(z0ZzZzrrj2.z0eek(), (int)z0ZzZzarj2.z0pek()));
				p1.z0eek(z0pek(), z0eek());
				p1.z0rek(z0ZzZzarj2.z0bek(), z0ZzZzarj2.z0pek() - p0.z0krk().z0pek() + (float)num2);
				p1.z0eek(z0eek(new z0ZzZzbdh(z0ZzZzndh2.z0pek(), z0ZzZzndh2.z0mek() - 1, z0ZzZzndh2.z0iek() + 1, z0ZzZzndh2.z0oek() + 2)));
				z0ZzZzkrj z0ZzZzkrj3 = new z0ZzZzkrj(p1, z0ZzZzndh2, xTextDocument, p0, PageContentPartyStyle.HeaderRows, null);
				z0ZzZzkrj3.z0rek(z0ZzZzndh2);
				z0ZzZzkrj3.z0eek(p0.z0vek());
				z0ZzZzkrj3.z0rek(z0jrk().Count);
				z0ZzZzkrj3.z0rek(z0ZzZzndh2);
				z0ZzZzkrj3.z0eek(z0ZzZzndh2.z0eek());
				z0ZzZzkrj3.z0eek(z0mek());
				z0ZzZzkrj3.z0eek(z0tek());
				((z0ZzZzjrj)xTextDocument).z0rek(z0ZzZzkrj3);
				z0eek(xTextDocument, z0ZzZzkrj2.z0mek());
				p1.z0rek();
				p1.z0zek();
				if (!z0yek)
				{
					num2 -= 3;
				}
			}
		}
		z0ZzZzndh2 = new z0ZzZzndh(-(int)z0ZzZzarj2.z0bek(), (int)Math.Floor(p0.z0irk()), (int)Math.Ceiling(p0.z0oek() + (float)(int)(z0ZzZzarj2.z0bek() + z0ZzZzarj2.z0cek())), (int)Math.Ceiling(p0.z0urk()));
		if (!p0.z0krk().z0bek())
		{
			z0ZzZzndh2.z0yek((int)((float)z0ZzZzndh2.z0oek() - p0.z0krk().z0iek()));
		}
		if (!p2.z0vek())
		{
			z0ZzZzndh2 = z0ZzZzndh.z0tek(z0ZzZzndh2, p2);
		}
		if (!z0ZzZzndh2.z0vek())
		{
			p1.z0eek(z0pek(), z0eek());
			p1.z0rek(z0ZzZzarj2.z0bek(), z0ZzZzarj2.z0pek() - p0.z0irk() + (float)num2 + p0.z0krk().z0iek());
			z0ZzZzpdh[] array = new z0ZzZzpdh[3]
			{
				new z0ZzZzpdh(p0.z0bek(), p0.z0irk()),
				new z0ZzZzpdh(p0.z0bek() + p0.z0oek(), p0.z0irk() + p0.z0xek()),
				new z0ZzZzpdh(p0.z0bek() + p0.z0oek(), p0.z0irk() + p0.z0urk())
			};
			p1.z0eek(array);
			z0ZzZzrrj2.z0eek(Math.Min(z0ZzZzrrj2.z0eek(), array[0].z0tek()));
			z0rrk = new z0ZzZzsmk();
			z0rrk.z0rek(new z0ZzZzbdh(array[0].z0rek(), array[0].z0tek(), array[1].z0rek() - array[0].z0rek(), array[1].z0tek() - array[0].z0tek()));
			z0rrk.z0eek(new z0ZzZzbdh(p0.z0bek(), p0.z0irk(), p0.z0oek(), p0.z0xek()));
			z0rrk.z0tek_jiejie20260327142557(new z0ZzZzndh((int)array[0].z0rek(), (int)array[0].z0tek(), (int)(array[2].z0rek() - array[0].z0rek()), (int)(array[2].z0tek() - array[0].z0tek())));
			z0ZzZzbdh p5 = z0ZzZzdpk.z0eek(p1, z0ZzZzndh2.z0pek(), z0ZzZzndh2.z0mek(), z0ZzZzndh2.z0iek(), z0ZzZzndh2.z0oek());
			p5.z0tek(-4f, -4f);
			p5.z0tek(p5.z0uek() + 8f);
			p5.z0yek(p5.z0iek() + 8f);
			p1.z0eek(z0eek(p5));
			z0ZzZzkrj z0ZzZzkrj4 = new z0ZzZzkrj(p1, z0ZzZzndh2, xTextDocument, p0, PageContentPartyStyle.Body, null);
			z0ZzZzkrj4.z0eek(z0mek());
			z0ZzZzkrj4.z0rek(z0ZzZzndh2);
			z0ZzZzkrj4.z0eek(z0ZzZzndh2.z0eek());
			float num3 = p0.z0urk();
			if (!p0.z0krk().z0bek())
			{
				num3 -= p0.z0krk().z0iek();
			}
			z0ZzZzkrj4.z0eek(new z0ZzZzbdh(z0ZzZzndh2.z0pek(), p0.z0irk(), Math.Max(z0ZzZzndh2.z0iek(), p0.z0oek()), num3));
			z0ZzZzkrj4.z0eek(z0tek());
			z0ZzZzkrj4.z0eek(p0.z0brk());
			((z0ZzZzjrj)xTextDocument).z0rek(z0ZzZzkrj4);
			z0eek(xTextDocument, z0ZzZzkrj4.z0mek());
		}
		if (z0uek())
		{
			p1.z0rek();
			p1.z0zek();
			p1.z0eek(GraphicsUnit.Document);
			float num4 = Math.Max(p0.z0wrk(), xPageSettings.z0frk());
			z0ZzZzndh2 = new z0ZzZzndh(-(int)z0ZzZzarj2.z0bek(), 0, (int)Math.Ceiling(p0.z0oek() + (float)(int)(z0ZzZzarj2.z0bek() + z0ZzZzarj2.z0cek())), (int)Math.Ceiling(num4));
			int num5 = 0;
			num5 = (int)(p0.z0crk() - z0ZzZzarj2.z0tek() - p0.z0wrk());
			p1.z0eek(z0pek(), z0eek());
			p1.z0rek(z0ZzZzarj2.z0bek(), num5);
			p1.z0eek(z0eek(new z0ZzZzbdh(z0ZzZzndh2.z0pek(), z0ZzZzndh2.z0mek(), z0ZzZzndh2.z0iek() + 1, z0ZzZzndh2.z0oek() + 1)));
			z0ZzZzkrj z0ZzZzkrj5 = new z0ZzZzkrj(p1, z0ZzZzndh2, xTextDocument, p0, (!p0.z0yek()) ? PageContentPartyStyle.Footer : PageContentPartyStyle.FooterForFirstPage, null);
			z0ZzZzkrj5.z0eek(z0mek());
			z0ZzZzkrj5.z0rek(z0ZzZzndh2);
			z0ZzZzkrj5.z0eek(z0ZzZzndh2.z0eek());
			z0ZzZzkrj5.z0eek(z0tek());
			if (xPageSettings.z0eek(p0.z0brk()))
			{
				if (z0tek() != null && z0mek() == (z0ZzZzxej)1 && z0tek().z0vek() == PrintRange.Selection && z0tek)
				{
					try
					{
						z0tek().z0rek(PrintRange.AllPages);
						((z0ZzZzjrj)xTextDocument).z0rek(z0ZzZzkrj5);
					}
					finally
					{
						z0tek().z0rek(PrintRange.Selection);
					}
				}
				else
				{
					((z0ZzZzjrj)xTextDocument).z0rek(z0ZzZzkrj5);
				}
				z0eek(xTextDocument, z0ZzZzkrj5.z0mek());
			}
		}
		if (z0krk() != null && z0krk().HasVisibleBorder)
		{
			z0ZzZzbdh p6 = z0ZzZzurj.z0eek(z0krk(), p0, z0rrk.z0lrk().z0eek());
			p1.z0zek();
			p1.z0rek();
			z0krk().z0eek(p1, p6);
		}
		if (!z0rek.z0bek())
		{
			z0ZzZzrrj2.z0eek(z0rek.z0pek());
			z0ZzZzrrj2.z0tek(z0rek.z0nek());
			z0ZzZzrrj2.z0rek(z0rek.z0iek());
		}
		if (z0xek() && z0uek())
		{
			p1.z0rek();
			p1.z0zek();
			p1.z0eek(GraphicsUnit.Document);
			p1.z0eek(z0pek(), z0eek());
			p1.z0eek(z0eek(new z0ZzZzbdh(0f, 0f, (int)z0ZzZzarj2.z0xek(), (int)z0ZzZzarj2.z0nek())));
			z0ZzZzkrj z0ZzZzkrj6 = new z0ZzZzkrj(p1, new z0ZzZzndh(0, 0, (int)z0ZzZzarj2.z0xek(), (int)z0ZzZzarj2.z0nek()), xTextDocument, p0, (!p0.z0yek()) ? PageContentPartyStyle.Footer : PageContentPartyStyle.FooterForFirstPage, null);
			z0ZzZzkrj6.z0eek(z0mek());
			z0ZzZzkrj6.z0rek(new z0ZzZzndh(0, 0, (int)z0ZzZzarj2.z0xek(), (int)z0ZzZzarj2.z0nek()));
			z0ZzZzkrj6.z0eek(new z0ZzZzbdh(0f, 0f, z0ZzZzarj2.z0xek(), z0ZzZzarj2.z0nek()));
			z0ZzZzkrj6.z0eek(z0tek());
			z0vek().z0eek(z0ZzZzkrj6);
		}
		return z0ZzZzrrj2;
	}

	private void z0eek(XTextDocument p0, z0ZzZzjpk p1)
	{
		z0ZzZzbdh z0ZzZzbdh2 = p0.z0huk();
		if (!z0ZzZzbdh2.z0bek())
		{
			z0ZzZzpdh[] array = new z0ZzZzpdh[1] { z0ZzZzbdh2.z0eek() };
			p1.z0eek(array);
			z0ZzZzbdh2 = new z0ZzZzbdh(array[0], z0ZzZzbdh2.z0rek());
			if (z0rek.z0bek())
			{
				z0rek = z0ZzZzbdh2;
			}
			else
			{
				z0rek = z0ZzZzbdh.z0yek(z0rek, z0ZzZzbdh2);
			}
		}
	}
}
