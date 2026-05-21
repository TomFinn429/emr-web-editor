using System;
using DCSoft.Drawing;
using DCSoft.Printing;
using DCSoft.Writer.Dom;

namespace zzz;

internal class z0ZzZzncj : z0ZzZzhrj
{
	private new static readonly bool z0rek = true;

	public static void z0eek(z0ZzZzwrj p0)
	{
		if (p0.z0ark())
		{
			return;
		}
		if (p0.z0nrk())
		{
			XTextElement[] array = p0.z0uek();
			XTextTableRowElement xTextTableRowElement = (XTextTableRowElement)array[0];
			float num = 0f;
			XTextElement[] array2 = array;
			for (int i = 0; i < array2.Length; i++)
			{
				XTextTableRowElement xTextTableRowElement2 = (XTextTableRowElement)array2[i];
				num += xTextTableRowElement2.Height;
			}
			XTextDocumentContentElement xTextDocumentContentElement = xTextTableRowElement.z0qek();
			p0.z0eek(new z0ZzZzbdh(((XTextElement)xTextDocumentContentElement).z0zrk(), ((XTextElement)xTextTableRowElement).z0ltk(), xTextDocumentContentElement.Width, num));
		}
		else
		{
			p0.z0eek(z0ZzZzbdh.z0xek);
		}
	}

	public override void z0ep(z0ZzZzwrj p0, float p1, float p2)
	{
		if (p0.z0ark())
		{
			return;
		}
		float num = 30f;
		XPageSettings xPageSettings = p0.z0trk();
		XTextDocument xTextDocument = (XTextDocument)p0.z0srk();
		z0ZzZzarj z0ZzZzarj2 = new z0ZzZzarj(p0, p1: true);
		float num2 = (float)(int)p1 + z0ZzZzarj2.z0pek() * p2;
		num = Math.Min(num, z0ZzZzarj2.z0bek());
		num = Math.Min(num, z0ZzZzarj2.z0cek());
		z0ZzZzsmk z0ZzZzsmk2 = null;
		XTextDocumentContentElement xTextDocumentContentElement = xTextDocument.z0pyk();
		XTextDocumentContentElement xTextDocumentContentElement2 = xTextDocument.z0lik();
		if (xTextDocument.PageSettings.z0rrk() && p0 == xTextDocument.z0suk().z0iek())
		{
			xTextDocumentContentElement = xTextDocument.z0cyk();
			xTextDocumentContentElement2 = xTextDocument.z0guk();
		}
		float num3 = (xPageSettings.z0mek() ? xTextDocumentContentElement.Height : 0f);
		float num4 = (xPageSettings.z0mek() ? xTextDocumentContentElement2.Height : 0f);
		if (z0iek && z0rek().Count != 1)
		{
			if (p0 != z0rek().z0iek())
			{
				num3 = 0f;
			}
			if (p0 != z0rek().z0tek())
			{
				num4 = 0f;
			}
		}
		float p3 = p0.z0oek();
		float p4 = 0f;
		z0ZzZzgpk z0ZzZzgpk2 = null;
		z0ZzZzdbj z0ZzZzdbj2 = xTextDocument.z0yyk();
		if (z0ZzZzdbj2 != null)
		{
			z0ZzZzgpk2 = z0ZzZzdbj2.z0ypk().z0rc();
			if (z0ZzZzgpk2 != null && (xTextDocument.z0ank() == null || !xTextDocument.z0ank().z0wb()))
			{
				z0ZzZzgpk2 = null;
			}
			if (z0ZzZzgpk2 != null)
			{
				z0ZzZzgpk2 = z0ZzZzgpk2.z0iek();
			}
		}
		if (z0ZzZzqrj.z0rrk && z0ZzZzgpk2 != null && z0ZzZzgpk2.z0yek())
		{
			if (z0rek)
			{
				p4 = 0f - z0ZzZzarj2.z0bek() + num;
				p3 = p0.z0oek() + z0ZzZzarj2.z0bek() + Math.Max(z0ZzZzarj2.z0cek(), z0ZzZzgpk2.z0eek()) - num * 2f;
			}
		}
		else if (z0rek)
		{
			p4 = 0f - z0ZzZzarj2.z0bek() + num;
			p3 = p0.z0oek() + z0ZzZzarj2.z0bek() + z0ZzZzarj2.z0cek() - num * 2f;
		}
		float num5 = xPageSettings.z0ztk();
		if (z0iek && p0 != z0rek().z0iek() && z0rek().Count > 1)
		{
			num5 = 0f;
			num3 = 0f;
		}
		z0ZzZzsmk2 = new z0ZzZzsmk();
		PageContentPartyStyle pageContentPartyStyle = xTextDocument.z0oik();
		z0ZzZzsmk2.z0rek(pageContentPartyStyle == xTextDocumentContentElement.z0fu());
		z0ZzZzsmk2.z0eek(p0.z0brk());
		z0ZzZzsmk2.z0eek(xTextDocumentContentElement.z0fu());
		z0ZzZzsmk2.z0eek(p0);
		z0ZzZzsmk2.z0rek(p0.z0srk());
		z0ZzZzsmk2.z0srk = new z0ZzZzbdh(p4, 0f, p3, Math.Max(num5 - 1f, num3));
		if (num3 > num5)
		{
			num2 += (float)(int)((num3 - num5) * p2);
		}
		float num6 = z0ZzZzarj2.z0vek() * p2;
		if (z0iek && p0 != z0rek().z0iek() && z0rek().Count > 1)
		{
			num6 = 0f;
		}
		if (z0rek)
		{
			z0eek(z0ZzZzsmk2, p2, 20f + num * p2, p1 + num6);
		}
		else
		{
			z0eek(z0ZzZzsmk2, p2, z0ZzZzarj2.z0bek() * p2 + 20f, p1 + num6);
		}
		z0ZzZzsmk2.z0tek_jiejie20260327142557(z0ZzZzsmk2.z0tek_jiejie20260327142557());
		int num7 = 0;
		float num8 = 0f;
		z0ZzZzsmk z0ZzZzsmk3 = null;
		if (p0.z0nrk())
		{
			XTextElement[] array = p0.z0uek();
			z0ZzZzsmk3 = new z0ZzZzsmk();
			z0ZzZzsmk3.z0rek(p0: false);
			z0ZzZzsmk3.z0tek_jiejie20260327142557(p0: false);
			if (z0ZzZzdpk.z0eek(pageContentPartyStyle))
			{
				z0ZzZzsmk3.z0tek_jiejie20260327142557(p0: true);
			}
			XTextTableRowElement xTextTableRowElement = (XTextTableRowElement)array[0];
			XTextElement[] array2 = array;
			for (int i = 0; i < array2.Length; i++)
			{
				XTextTableRowElement xTextTableRowElement2 = (XTextTableRowElement)array2[i];
				num8 += xTextTableRowElement2.Height;
			}
			z0ZzZzsmk3.z0eek(p0.z0brk());
			z0ZzZzsmk3.z0eek(PageContentPartyStyle.HeaderRows);
			z0ZzZzsmk3.z0eek(p0);
			z0ZzZzsmk3.z0rek(p0.z0srk());
			z0ZzZzsmk3.z0eek(new z0ZzZzbdh(p4, ((XTextElement)xTextTableRowElement).z0ltk(), p3, num8));
			p0.z0eek(z0ZzZzsmk3.z0rek());
			if (num3 > num5 - 10f && num7 == 0)
			{
				num7 = 5;
			}
			if (z0rek)
			{
				num2 = z0eek(z0ZzZzsmk3, p2, 20f + num * p2, z0ZzZzsmk2.z0lrk().z0bek() + num7);
			}
			else
			{
				num2 = z0eek(z0ZzZzsmk3, p2, z0ZzZzarj2.z0bek() * p2 + 20f, z0ZzZzsmk2.z0lrk().z0bek() + num7);
			}
			z0ZzZzsmk3.z0tek_jiejie20260327142557(new z0ZzZzndh((int)z0ZzZzsmk3.z0grk.z0oek(), (int)z0ZzZzsmk3.z0grk.z0pek(), (int)z0ZzZzsmk3.z0grk.z0uek(), (int)(num8 * p2)));
		}
		bool num9 = p0 == xTextDocument.z0suk().z0tek();
		float p5 = p0.z0xek();
		float num10 = (z0iek ? (p0.z0xek() + 5f) : p0.z0urk());
		if (num9)
		{
			p5 = num10 - 5f;
		}
		else
		{
			_ = z0iek;
		}
		z0ZzZzsmk z0ZzZzsmk4 = new z0ZzZzsmk();
		z0ZzZzsmk4.z0rek(pageContentPartyStyle == PageContentPartyStyle.Body);
		z0ZzZzsmk4.z0eek(p0.z0brk());
		z0ZzZzsmk4.z0eek(PageContentPartyStyle.Body);
		z0ZzZzsmk4.z0eek(p0);
		z0ZzZzsmk4.z0rek(p0.z0srk());
		z0ZzZzsmk4.z0srk = new z0ZzZzbdh(p4, p0.z0irk(), p3, p5);
		if (num3 > num5 - 10f && num7 == 0)
		{
			num7 = 3;
		}
		if (num8 > 0f)
		{
			num7--;
		}
		if (z0rek)
		{
			num2 = z0eek(z0ZzZzsmk4, p2, 20f + num * p2, (float)(z0ZzZzsmk2.z0lrk().z0bek() + num7) + num8 * p2);
		}
		else
		{
			num2 = z0eek(z0ZzZzsmk4, p2, z0ZzZzarj2.z0bek() * p2 + 20f, (float)Math.Floor((float)(z0ZzZzsmk2.z0lrk().z0bek() + num7) + num8 * p2));
		}
		z0ZzZzsmk4.z0tek_jiejie20260327142557(new z0ZzZzndh((int)z0ZzZzsmk4.z0grk.z0oek(), (int)z0ZzZzsmk4.z0grk.z0pek(), (int)z0ZzZzsmk4.z0grk.z0uek(), (int)(num10 * p2 - num8 * p2)));
		if (z0iek)
		{
			z0ZzZzsmk4.z0tek_jiejie20260327142557(new z0ZzZzbdh(z0ZzZzsmk4.z0srk.z0oek(), z0ZzZzsmk4.z0srk.z0pek(), z0ZzZzsmk4.z0srk.z0uek(), p0.z0xek() - num8 + 4f));
		}
		else
		{
			z0ZzZzsmk4.z0tek_jiejie20260327142557(new z0ZzZzbdh(z0ZzZzsmk4.z0srk.z0oek(), z0ZzZzsmk4.z0srk.z0pek(), z0ZzZzsmk4.z0srk.z0uek(), p0.z0urk() - num8));
		}
		z0ZzZzsmk z0ZzZzsmk5 = new z0ZzZzsmk();
		z0ZzZzsmk5.z0rek(pageContentPartyStyle == xTextDocumentContentElement2.z0fu());
		z0ZzZzsmk5.z0eek(p0.z0brk());
		z0ZzZzsmk5.z0eek(xTextDocumentContentElement2.z0fu());
		z0ZzZzsmk5.z0eek(p0);
		z0ZzZzsmk5.z0rek(p0.z0srk());
		int num11 = 0;
		int num12 = (int)(z0ZzZzarj2.z0nek() * p2);
		if (z0iek && p0 != z0rek().z0tek() && z0rek().Count > 1)
		{
			z0ZzZzsmk5.z0srk = new z0ZzZzbdh(p4, 0f, p3, 0f);
			num11 = (int)(p1 + (float)num12);
		}
		else
		{
			z0ZzZzsmk5.z0srk = new z0ZzZzbdh(p4, 0f, p3, num4);
			if (z0iek)
			{
				num11 = (int)(z0ZzZzsmk4.z0grk.z0nek() + 3f);
			}
			else
			{
				float num13 = z0ZzZzarj2.z0tek() * p2;
				num11 = (int)(p1 + (float)num12 - num13 - num4 * p2);
				if (num11 < z0ZzZzsmk4.z0lrk().z0bek())
				{
					num11 = z0ZzZzsmk4.z0lrk().z0bek();
				}
			}
		}
		if (z0rek)
		{
			z0eek(z0ZzZzsmk5, p2, (int)(20f + num * p2), num11);
		}
		else
		{
			z0eek(z0ZzZzsmk5, p2, z0ZzZzarj2.z0bek() * p2 + 20f, num11);
		}
		z0ZzZzndh p6 = z0ZzZzsmk5.z0tek_jiejie20260327142557();
		if (p6.z0oek() < 25)
		{
			p6.z0yek(25);
		}
		z0ZzZzndh p7 = new z0ZzZzndh((int)z0ZzZzsmk5.z0grk.z0oek(), (int)(p1 + (float)num12 - z0ZzZzarj2.z0mek() * p2), (int)z0ZzZzsmk5.z0grk.z0uek(), (int)z0ZzZzsmk5.z0grk.z0iek());
		p7 = z0ZzZzndh.z0yek(p7, p6);
		if ((float)p7.z0bek() > z0ZzZzsmk5.z0mek().z0nek())
		{
			p7.z0yek((int)(z0ZzZzsmk5.z0mek().z0nek() - (float)p7.z0mek()));
		}
		z0ZzZzsmk5.z0tek_jiejie20260327142557(p7);
		bool flag = p0.z0trk().z0eek(p0.z0brk()) && xPageSettings.z0mek();
		switch (pageContentPartyStyle)
		{
		case PageContentPartyStyle.Header:
		case PageContentPartyStyle.HeaderForFirstPage:
			if (z0iek)
			{
				if (p0 == z0rek().z0iek() && z0ZzZzsmk2 != null && flag)
				{
					z0eek(z0ZzZzsmk2);
				}
				if (p0 == z0rek().z0tek() && z0ZzZzsmk3 != null)
				{
					z0eek(z0ZzZzsmk3);
				}
			}
			else
			{
				if (z0ZzZzsmk2 != null && flag)
				{
					z0eek(z0ZzZzsmk2);
				}
				if (z0ZzZzsmk3 != null)
				{
					z0eek(z0ZzZzsmk3);
				}
			}
			z0eek(z0ZzZzsmk4);
			if (z0ZzZzsmk5 != null && flag)
			{
				z0eek(z0ZzZzsmk5);
			}
			break;
		case PageContentPartyStyle.Body:
			z0eek(z0ZzZzsmk4);
			if (z0ZzZzsmk3 != null)
			{
				z0eek(z0ZzZzsmk3);
			}
			if (z0iek)
			{
				if (p0 == z0rek().z0iek() && z0ZzZzsmk2 != null && flag)
				{
					z0eek(z0ZzZzsmk2);
				}
				if (p0 == z0rek().z0tek() && z0ZzZzsmk5 != null && flag)
				{
					z0eek(z0ZzZzsmk5);
				}
			}
			else
			{
				if (z0ZzZzsmk2 != null && flag)
				{
					z0eek(z0ZzZzsmk2);
				}
				if (z0ZzZzsmk5 != null && flag)
				{
					z0eek(z0ZzZzsmk5);
				}
			}
			break;
		case PageContentPartyStyle.Footer:
		case PageContentPartyStyle.FooterForFirstPage:
			if (z0iek)
			{
				if (p0 == z0rek().z0tek() && z0ZzZzsmk5 != null && flag)
				{
					z0eek(z0ZzZzsmk5);
				}
				if (p0 == z0rek().z0iek() && z0ZzZzsmk2 != null && flag)
				{
					z0eek(z0ZzZzsmk2);
				}
			}
			else
			{
				if (z0ZzZzsmk5 != null && flag)
				{
					z0eek(z0ZzZzsmk5);
				}
				if (z0ZzZzsmk2 != null && flag)
				{
					z0eek(z0ZzZzsmk2);
				}
			}
			if (z0ZzZzsmk3 != null)
			{
				z0eek(z0ZzZzsmk3);
			}
			z0eek(z0ZzZzsmk4);
			break;
		case PageContentPartyStyle.HeaderRows:
			break;
		}
	}

	private float z0eek(z0ZzZzsmk p0, float p1, float p2, float p3)
	{
		z0ZzZzbdh z0grk = default(z0ZzZzbdh);
		z0grk.z0eek((int)p2);
		z0grk.z0rek(p3);
		z0grk.z0tek(p0.z0srk.z0uek() * p1);
		z0grk.z0yek(p0.z0srk.z0iek() * p1);
		p0.z0grk = z0grk;
		return z0grk.z0nek();
	}
}
