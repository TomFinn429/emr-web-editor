using System;
using DCSoft.Drawing;
using DCSoft.Printing;
using DCSystem_Drawing;
using DCSystem_Drawing.Drawing2D;

namespace zzz;

public class z0ZzZzqrj : z0ZzZzspj
{
	private new Color z0ark = Color.Black;

	private new static z0ZzZzimk z0qrk;

	private z0ZzZzsmk z0wrk;

	public new EventHandler z0erk;

	public new static bool z0rrk;

	private new HeaderFooterFlagVisible z0trk;

	private new int z0yrk = -1;

	private new bool z0irk;

	protected new z0ZzZzgpk z0ork;

	private new bool z0prk;

	private new PageViewMode z0mrk;

	private new bool z0nrk;

	private new Color z0brk = Color.Black;

	internal bool z0vrk;

	protected new int z0crk = 60;

	protected z0ZzZzerj z0xrk = new z0ZzZzerj();

	protected new Color z0zrk = z0ZzZzhsh.z0tek;

	private int z0ltk = -1;

	private z0ZzZzvpk z0ktk;

	private bool z0jtk;

	private z0ZzZzwrj z0htk;

	protected new z0ZzZzsmk z0eek()
	{
		return z0wrk;
	}

	public new z0ZzZzerj z0rek()
	{
		if (z0xrk == null)
		{
			return null;
		}
		return z0xrk.z0eek(z0krk(), z0bek());
	}

	public new void z0eek(bool p0)
	{
		z0nrk = p0;
	}

	public new bool z0tek()
	{
		return z0jtk;
	}

	public new void z0eek(int p0)
	{
		p0--;
		if (z0frk() != null && p0 >= 0 && p0 < z0frk().Count)
		{
			z0rek(z0frk()[p0]);
		}
	}

	public new bool z0yek()
	{
		return z0lrk().z0eek();
	}

	public new PageViewMode z0uek()
	{
		return z0mrk;
	}

	internal new void z0rek(bool p0)
	{
		if (p0)
		{
			z0mrk = PageViewMode.CompressPage;
		}
		else
		{
			z0mrk = PageViewMode.Page;
		}
		foreach (z0ZzZzwrj item in z0frk())
		{
			item.z0eek(0, 0, 0, 0);
		}
	}

	protected virtual bool z0jc()
	{
		return false;
	}

	public override void z0lz_jiejie20260327142557()
	{
		base.z0lz_jiejie20260327142557();
		z0xrk = null;
		z0htk = null;
		z0ktk = null;
		z0ork = null;
		z0wrk = null;
		z0erk = null;
	}

	public virtual bool z0ic()
	{
		if (z0xrk != null)
		{
			z0ZzZzwrj z0ZzZzwrj2 = null;
			z0ZzZzndh p = new z0ZzZzndh(0, 0, base.z0vek(), base.z0frk());
			int num = 0;
			foreach (z0ZzZzwrj item in z0xrk)
			{
				z0ZzZzndh z0ZzZzndh2 = z0ZzZzndh.z0tek(item.z0erk(), p);
				if (!z0ZzZzndh2.z0vek() && num < z0ZzZzndh2.z0oek())
				{
					z0ZzZzwrj2 = item;
					num = z0ZzZzndh2.z0oek();
				}
			}
			if (z0ZzZzwrj2 != z0htk)
			{
				z0htk = z0ZzZzwrj2;
				return true;
			}
		}
		return false;
	}

	public new int z0iek()
	{
		if (z0xrk != null)
		{
			return z0xrk.Count;
		}
		return 0;
	}

	public new int z0oek()
	{
		if (z0xek() == null)
		{
			return 0;
		}
		return z0xek().z0brk();
	}

	public new z0ZzZzvpk z0pek()
	{
		return z0ktk;
	}

	public new Color z0mek()
	{
		return z0ark;
	}

	public bool z0eek(z0ZzZzwrj p0)
	{
		if (z0htk != p0)
		{
			z0htk = p0;
			return true;
		}
		return false;
	}

	private void z0eek(string p0, z0ZzZzndh p1, z0ZzZzjpk p2, bool p3)
	{
		if (z0qrk == null)
		{
			z0qrk = new z0ZzZzimk(z0ZzZzimk.DefaultFontName, 10f);
		}
		using (z0ZzZzudh z0ZzZzudh2 = new z0ZzZzudh(Color.FromArgb(155, 187, 227)))
		{
			z0ZzZzudh2.z0eek(DashStyle.Dash);
			p2.z0eek(z0ZzZzudh2, p1);
		}
		if (!string.IsNullOrEmpty(p0))
		{
			z0ZzZzxdh z0ZzZzxdh2 = p2.z0eek(p0, z0qrk);
			z0ZzZzcdh z0ZzZzcdh2 = new z0ZzZzcdh((int)z0ZzZzxdh2.z0rek() + 10, (int)z0ZzZzxdh2.z0tek() + 10);
			z0ZzZzndh z0ZzZzndh2 = z0ZzZzndh.z0cek;
			z0eek(p6: (!p3) ? new z0ZzZzndh(p1.z0pek() + 10, p1.z0bek(), z0ZzZzcdh2.z0rek(), z0ZzZzcdh2.z0tek()) : new z0ZzZzndh(p1.z0pek() + 10, p1.z0mek() - z0ZzZzcdh2.z0tek(), z0ZzZzcdh2.z0rek(), z0ZzZzcdh2.z0tek()), p0: p2, p1: z0qrk, p2: p0, p3: Color.FromArgb(21, 66, 139), p4: Color.FromArgb(216, 232, 245), p5: Color.FromArgb(155, 187, 227));
		}
	}

	public override void z0fhk()
	{
		z0ZzZzhrj z0ZzZzhrj2 = (z0ZzZzhrj)base.z0ark;
		if (z0ZzZzhrj2 != null)
		{
			z0eek(z0xrk.z0eek());
			z0ZzZzhrj2.z0eek(z0ZzZzrpk.z0eek(((z0ZzZzspj)this).z0cek(), GraphicsUnit.Pixel) * 96.0 / 96.0);
		}
	}

	public new void z0eek(Color p0)
	{
		z0brk = p0;
	}

	protected virtual int z0qc()
	{
		return 0;
	}

	public virtual void z0ac()
	{
		if (z0erk != null)
		{
			z0erk(this, null);
		}
	}

	protected virtual void z0uc(z0ZzZzjrj p0, z0ZzZzkrj p1, z0ZzZzopk p2)
	{
		p0?.z0rek(p1);
	}

	public void z0eek(z0ZzZzvpk p0)
	{
		z0ktk = p0;
	}

	public new virtual HeaderFooterFlagVisible z0nek()
	{
		return z0trk;
	}

	public new int z0bek()
	{
		return z0yrk;
	}

	public new void z0rek(Color p0)
	{
		z0ark = p0;
	}

	public new bool z0vek()
	{
		return z0nrk;
	}

	public new virtual PageViewMode z0cek()
	{
		return z0uek();
	}

	public void z0tek(bool p0)
	{
		z0jtk = p0;
	}

	public virtual void z0vc(z0ZzZzgpk p0)
	{
		z0ork = p0;
	}

	public virtual void z0sc(int p0 = 0)
	{
		if (z0xrk == null || z0xrk.Count == 0 || z0irk)
		{
			return;
		}
		z0irk = true;
		try
		{
			z0prk = false;
			float num = (float)(1.0 / base.z0pek());
			PageViewMode pageViewMode = z0cek();
			if (pageViewMode != PageViewMode.Page && pageViewMode != PageViewMode.CompressPage)
			{
				return;
			}
			z0ZzZzgpk z0ZzZzgpk2 = z0rc();
			z0ZzZzerj z0ZzZzerj2 = z0rek();
			z0ZzZzcdh p1 = z0ZzZzcdh.z0yek_jiejie20260327142557;
			XPageSettings xPageSettings = null;
			bool flag = false;
			z0ZzZzarj z0ZzZzarj2 = null;
			z0ZzZzmdh z0dtk = null;
			foreach (z0ZzZzwrj item in z0ZzZzerj2)
			{
				z0ZzZzndh p2 = z0ZzZzndh.z0cek;
				if (pageViewMode == PageViewMode.CompressPage)
				{
					xPageSettings = item.z0trk();
					p1.z0eek((int)Math.Round(xPageSettings.z0ptk().z0rek() * num));
					z0ZzZzarj z0ZzZzarj3 = new z0ZzZzarj(item, p1: true);
					if (z0ZzZzerj2.Count == 1)
					{
						p1.z0rek((int)Math.Round((item.z0yrk() + item.z0xek() + item.z0wrk() + z0ZzZzarj3.z0tek() + 10f) * num));
					}
					else if (item == z0ZzZzerj2.z0iek())
					{
						p1.z0rek(4 + (int)Math.Round((item.z0yrk() + item.z0xek()) * num));
					}
					else if (item == z0ZzZzerj2.z0tek())
					{
						p1.z0rek(4 + (int)Math.Round((item.z0xek() + item.z0wrk() + z0ZzZzarj3.z0tek()) * num));
					}
					else
					{
						p1.z0rek(4 + (int)(item.z0xek() * num));
					}
				}
				else if (item.z0trk() != xPageSettings)
				{
					flag = !z0ZzZzarj.z0eek(item.z0trk());
					if (z0ZzZzgpk2 != null && z0ZzZzgpk2.z0yek())
					{
						flag = false;
					}
					z0ZzZzarj2 = new z0ZzZzarj(item, p1: true);
					z0ZzZzarj2.z0eek(num);
					z0dtk = new z0ZzZzmdh((int)z0ZzZzarj2.z0bek(), (int)z0ZzZzarj2.z0cek(), (int)z0ZzZzarj2.z0pek(), (int)z0ZzZzarj2.z0mek());
					xPageSettings = item.z0trk();
					z0ZzZzxdh z0ZzZzxdh2 = xPageSettings.z0ptk();
					p1 = new z0ZzZzcdh((int)Math.Round(z0ZzZzxdh2.z0rek() * num), (int)Math.Round(z0ZzZzxdh2.z0tek() * num));
				}
				p2.z0eek(p1);
				item.z0eek(p2);
				if (flag)
				{
					item.z0jtk = z0ZzZzarj2;
					item.z0dtk = z0dtk;
				}
				else
				{
					z0ZzZzarj z0ZzZzarj4 = new z0ZzZzarj(item, p1: true);
					z0ZzZzarj4.z0eek(num);
					item.z0jtk = z0ZzZzarj4;
					item.z0dtk = new z0ZzZzmdh((int)z0ZzZzarj4.z0bek(), (int)z0ZzZzarj4.z0cek(), (int)z0ZzZzarj4.z0pek(), (int)z0ZzZzarj4.z0mek());
				}
				if (pageViewMode == PageViewMode.CompressPage)
				{
					if (item != z0ZzZzerj2.z0iek())
					{
						item.z0eek(new z0ZzZzmdh(item.z0drk().z0yek(), item.z0drk().z0uek(), 0, item.z0drk().z0eek_jiejie20260327142557()));
					}
					if (item != z0ZzZzerj2.z0tek())
					{
						item.z0eek(new z0ZzZzmdh(item.z0drk().z0yek(), item.z0drk().z0uek(), item.z0drk().z0tek(), 0));
					}
				}
				if (z0ZzZzgpk2 == null || !z0ZzZzgpk2.z0yek())
				{
					continue;
				}
				if (z0rrk)
				{
					if (z0ZzZzgpk2.z0eek() >= item.z0ork())
					{
						z0prk = true;
						int num2 = (int)Math.Ceiling(z0ZzZzgpk2.z0eek() * num - item.z0ork() * num);
						item.z0rek(new z0ZzZzndh(item.z0erk().z0pek(), item.z0erk().z0mek(), item.z0erk().z0iek() + num2, item.z0erk().z0oek()));
						item.z0dtk.z0yek(item.z0dtk.z0uek() + num2);
					}
				}
				else
				{
					z0prk = true;
					int num3 = (int)Math.Ceiling(z0ZzZzgpk2.z0eek() * num);
					item.z0rek(new z0ZzZzndh(item.z0erk().z0pek(), item.z0erk().z0mek(), item.z0erk().z0iek() + num3, item.z0erk().z0oek()));
					item.z0dtk.z0yek(item.z0dtk.z0uek() + num3);
				}
			}
			float num4 = 0f;
			float num5 = 0f;
			foreach (z0ZzZzwrj item2 in z0ZzZzerj2)
			{
				num5 = num5 + 20f + (float)item2.z0vtk.z0oek();
				if (num4 < (float)item2.z0vtk.z0iek())
				{
					num4 = item2.z0vtk.z0iek();
				}
			}
			if (!z0tek())
			{
				num4 += 40f;
				num5 += 20f;
			}
			z0ZzZzhrj z0ZzZzhrj2 = (z0ZzZzhrj)base.z0drk();
			base.z0eek(z0frk().z0eek());
			z0ZzZzhrj2.z0eek(z0ZzZzerj2);
			z0ZzZzhrj2.z0eek(num, (!z0tek()) ? 20 : 0, 20, z0qc());
			num4 = 0f;
			num5 = 0f;
			foreach (z0ZzZzwrj item3 in z0ZzZzerj2)
			{
				num5 = num5 + 20f + (float)item3.z0erk().z0oek();
				if (num4 < (float)item3.z0erk().z0iek())
				{
					num4 = item3.z0erk().z0iek();
				}
			}
			num4 += 40f;
			num5 += 20f;
			int num6 = base.z0vek();
			int num7 = 0;
			num7 = ((!((float)num6 <= num4 + (float)p0)) ? ((int)(((float)num6 - num4 - (float)p0) / 2f)) : 0);
			z0ZzZzhrj2.z0eek(num7, 0, p2: false);
			z0fhk();
			int num8 = 0;
			num8 = ((!z0tek()) ? (20 + z0qc()) : z0qc());
			foreach (z0ZzZzwrj item4 in z0ZzZzerj2)
			{
				if (item4.z0erk().z0mek() > 0)
				{
					num8 = item4.z0erk().z0mek();
				}
				item4.z0eek(num7 + 20, num8, item4.z0erk().z0iek(), item4.z0erk().z0oek());
				num8 = ((pageViewMode != PageViewMode.CompressPage) ? (num8 + item4.z0erk().z0oek() + 20) : (num8 + item4.z0erk().z0oek() + 3));
			}
			if (z0tek())
			{
				num4 = 0f;
				num8 -= 20;
			}
			((z0ZzZzmwh)this).z0nrk = (int)num4 + 1;
			((z0ZzZzmwh)this).z0yrk = num8 + 1;
			if (z0ic())
			{
				z0ac();
			}
		}
		finally
		{
			z0irk = false;
		}
	}

	public new virtual z0ZzZzwrj z0xek()
	{
		return z0htk;
	}

	protected new virtual z0ZzZzcpk z0zek()
	{
		return new z0ZzZzcpk();
	}

	public void z0yek(bool p0)
	{
		z0lrk().z0eek(p0);
	}

	protected void z0eek(z0ZzZzjpk p0, z0ZzZzndh p1, JumpPrintInfo p2, Color p3)
	{
		if (p2 == null || !p2.Enabled || (p2.PageIndex < 0 && p2.EndPageIndex < 0))
		{
			return;
		}
		z0ZzZzhrj obj = (z0ZzZzhrj)base.z0ark;
		z0ZzZzwrj z0ZzZzwrj2 = null;
		float num = -2.1474836E+09f;
		float num2 = -2.1474836E+09f;
		foreach (z0ZzZzsmk item in obj)
		{
			if (item.z0vek() != PageContentPartyStyle.Body)
			{
				continue;
			}
			if ((p2.PageIndex != 0 || p2.Position != 0f) && p2.PageIndex >= 0 && item.z0cek() == z0frk().z0rek(p2.PageIndex))
			{
				num = item.z0xqk(0f, p2.Position + (float)(int)item.z0rek().z0pek()).z0tek();
				z0ZzZzwrj2 = z0frk().z0rek(p2.PageIndex);
				if (Math.Abs(p2.Position) < 1f && p2.PageIndex > 0)
				{
					num = (z0frk()[p2.PageIndex - 1].z0erk().z0bek() + z0frk()[p2.PageIndex].z0erk().z0mek()) / 2;
				}
			}
			if ((p2.EndPageIndex != 0 || p2.EndPosition != 0f) && p2.EndPageIndex >= 0 && item.z0cek() == z0frk().z0rek(p2.EndPageIndex))
			{
				num2 = item.z0xqk(0f, p2.EndPosition + (float)(int)item.z0rek().z0pek()).z0tek();
				if (p2.EndPosition < 1f && p2.EndPageIndex > 0)
				{
					num2 = (z0frk()[p2.EndPageIndex - 1].z0erk().z0bek() + z0frk()[p2.EndPageIndex].z0erk().z0mek()) / 2;
				}
			}
			if (num != -2.1474836E+09f && num2 != -2.1474836E+09f)
			{
				break;
			}
		}
		int num3 = z0frk()[0].z0erk().z0nek();
		if (num >= 0f)
		{
			z0ZzZzbdh z0ZzZzbdh2 = new z0ZzZzbdh(0f, 0f, num3, num);
			z0ZzZzbdh p4 = p1.z0eek();
			p4 = ((!p1.z0vek()) ? z0ZzZzbdh.z0tek(z0ZzZzbdh2, p4) : z0ZzZzbdh2);
			if (!p4.z0bek())
			{
				p0.z0rek();
				p0.z0eek(GraphicsUnit.Pixel);
				p0.z0zek();
				using (z0ZzZzzdh p5 = new z0ZzZzzdh(p3))
				{
					p0.z0rek(p5, p4);
				}
				using (z0ZzZzudh p6 = new z0ZzZzudh(Color.Blue, 2f))
				{
					p0.z0eek(p6, 0f, z0ZzZzbdh2.z0nek() - 1f, num3, z0ZzZzbdh2.z0nek() - 1f);
				}
				if (p2.Mode == JumpPrintMode.Offset)
				{
					z0ZzZzndh z0ZzZzndh2 = z0ZzZzwrj2.z0erk();
					float num4 = (float)z0ZzZzrpk.z0eek(10.0, GraphicsUnit.Millimeter, GraphicsUnit.Pixel);
					int num5 = z0ZzZzndh2.z0pek() + (int)Math.Min(num4, (double)z0ZzZzndh2.z0iek() * 0.3);
					p0.z0eek(z0ZzZzidh.z0cek, num5, z0ZzZzndh2.z0mek(), num5, num - 1f);
					z0ZzZzimk z0ZzZzimk2 = new z0ZzZzimk();
					float num6 = p0.z0eek(z0ZzZzimk2);
					for (int i = 0; i < 1000; i++)
					{
						float num7 = (float)z0ZzZzndh2.z0mek() + (float)i * num4;
						if (num7 > num)
						{
							break;
						}
						p0.z0eek(z0ZzZzidh.z0cek, num5, num7, (float)num5 + num4, num7);
						float num8 = (0f - num6) / 2f;
						if (i == 0)
						{
							num8 = 0f;
						}
						p0.z0eek(i + "CM", z0ZzZzimk2, Color.Red, (float)num5 + num4, num7 + num8);
					}
				}
			}
		}
		if (num2 == -2.1474836E+09f || !(num2 < (float)base.z0frk()))
		{
			return;
		}
		z0ZzZzbdh z0ZzZzbdh3 = new z0ZzZzbdh(0f, num2, num3, (float)base.z0frk() - num2);
		z0ZzZzbdh p7 = p1.z0eek();
		p7 = ((!p1.z0vek()) ? z0ZzZzbdh.z0tek(z0ZzZzbdh3, p7) : z0ZzZzbdh3);
		if (p7.z0bek())
		{
			return;
		}
		p0.z0rek();
		p0.z0eek(GraphicsUnit.Pixel);
		p0.z0zek();
		using (z0ZzZzzdh p8 = new z0ZzZzzdh(p3))
		{
			p0.z0rek(p8, p7);
		}
		using z0ZzZzudh p9 = new z0ZzZzudh(Color.Blue, 2f);
		p0.z0eek(p9, 0f, z0ZzZzbdh3.z0pek(), num3, z0ZzZzbdh3.z0pek());
	}

	public z0ZzZzqrj()
	{
		base.z0ark = new z0ZzZzhrj();
	}

	public new z0ZzZzhrj z0lrk()
	{
		return (z0ZzZzhrj)base.z0drk();
	}

	protected void z0eek(z0ZzZzopk p0, bool p1 = false)
	{
		z0ZzZzndh z0ZzZzndh2 = p0.z0eek();
		z0ZzZzndh2.z0yek(z0ZzZzndh2.z0oek() + 1);
		z0fhk();
		if (z0lrk() == null || z0lrk().z0yek() == 0)
		{
			return;
		}
		z0ZzZzhrj z0ZzZzhrj2 = (z0ZzZzhrj)base.z0drk();
		foreach (z0ZzZzwrj item in z0frk())
		{
			z0ZzZzndh z0ZzZzndh3 = item.z0erk();
			if (!z0ZzZzndh2.z0rek(new z0ZzZzndh(z0ZzZzndh3.z0pek(), z0ZzZzndh3.z0mek(), z0ZzZzndh3.z0iek() + 5, z0ZzZzndh3.z0oek() + 5)))
			{
				continue;
			}
			z0lx(item, p0.z0rek(), z0ZzZzndh2, p3: true);
			for (int num = z0ZzZzhrj2.z0yek() - 1; num >= 0; num--)
			{
				z0ZzZzsmk z0ZzZzsmk2 = z0ZzZzhrj2.z0rek(num);
				if (z0ZzZzsmk2.z0xek() && z0ZzZzsmk2.z0cek() == item)
				{
					z0ZzZzsmk2.z0vek();
					_ = 2;
					if (z0ZzZzsmk2.z0vek() == PageContentPartyStyle.Header && (z0nek() == HeaderFooterFlagVisible.Header || z0nek() == HeaderFooterFlagVisible.HeaderFooter))
					{
						z0eek(z0ZzZziok.z0rek("Header"), z0ZzZzsmk2.z0lrk(), p0.z0rek(), p3: false);
					}
					if (z0ZzZzsmk2.z0vek() == PageContentPartyStyle.Footer)
					{
						if (z0nek() == HeaderFooterFlagVisible.Footer || z0nek() == HeaderFooterFlagVisible.HeaderFooter)
						{
							z0eek(z0ZzZziok.z0rek("Footer"), z0ZzZzsmk2.z0lrk(), p0.z0rek(), p3: true);
						}
					}
					else if (z0ZzZzsmk2.z0vek() == PageContentPartyStyle.HeaderForFirstPage)
					{
						if (z0nek() == HeaderFooterFlagVisible.Header || z0nek() == HeaderFooterFlagVisible.HeaderFooter)
						{
							z0eek(z0ZzZziok.z0rek("HeaderForFirstPage"), z0ZzZzsmk2.z0lrk(), p0.z0rek(), p3: false);
						}
					}
					else if (z0ZzZzsmk2.z0vek() == PageContentPartyStyle.FooterForFirstPage && (z0nek() == HeaderFooterFlagVisible.Footer || z0nek() == HeaderFooterFlagVisible.HeaderFooter))
					{
						z0eek(z0ZzZziok.z0rek("FooterForFirstPage"), z0ZzZzsmk2.z0lrk(), p0.z0rek(), p3: true);
					}
					z0ZzZzndh p2 = new z0ZzZzndh((int)z0ZzZzsmk2.z0mek().z0oek(), (int)Math.Floor(z0ZzZzsmk2.z0mek().z0pek()), (int)z0ZzZzsmk2.z0mek().z0uek(), 0);
					p2.z0yek((int)Math.Ceiling(z0ZzZzsmk2.z0mek().z0nek() - (float)p2.z0mek()));
					if (p1 && z0ZzZzsmk2.z0vek() == PageContentPartyStyle.Body && !z0ZzZzsmk2.z0lrk().z0vek())
					{
						p2 = z0ZzZzsmk2.z0lrk();
					}
					p2 = z0ZzZzndh.z0tek(z0ZzZzndh2, p2);
					p2.z0vek();
					if (!p2.z0vek())
					{
						object p3 = p0.z0rek().z0bek();
						z0ZzZzopk z0ZzZzopk2 = z0eek(p0, z0ZzZzsmk2, p2: true);
						if (z0ZzZzopk2 != null)
						{
							z0ZzZzkrj z0ZzZzkrj2 = new z0ZzZzkrj(z0ZzZzopk2.z0rek(), z0ZzZzopk2.z0eek(), item.z0srk(), item, z0ZzZzsmk2.z0vek(), z0ZzZzsmk2);
							z0ZzZzkrj2.z0rek(z0ZzZzsmk2.z0uek());
							z0ZzZzkrj2.z0eek(z0ZzZzsmk2.z0rek());
							if (!z0ZzZzsmk2.z0iek().z0bek())
							{
								z0ZzZzkrj2.z0eek(z0ZzZzsmk2.z0iek());
							}
							if (z0vek())
							{
								z0ZzZzkrj2.z0eek((z0ZzZzxej)2);
							}
							else
							{
								z0ZzZzkrj2.z0eek((z0ZzZzxej)0);
							}
							if (z0vrk)
							{
								z0ZzZzkrj2.z0eek((z0ZzZzxej)1);
							}
							z0ZzZzkrj2.z0eek(item.z0brk());
							z0ZzZzkrj2.z0rek(z0frk().Count);
							z0ZzZzkrj2.z0eek(z0cek());
							if (item.z0srk() != null)
							{
								z0uc(item.z0srk(), z0ZzZzkrj2, p0);
							}
						}
						p0.z0rek().z0eek(p3);
						z0pc(p0, z0ZzZzsmk2);
					}
				}
			}
			object p4 = p0.z0rek().z0bek();
			z0ZzZzsmk z0ZzZzsmk3 = new z0ZzZzsmk();
			z0ZzZzsmk3.z0rek(item.z0erk().z0eek());
			z0ZzZzsmk3.z0eek(new z0ZzZzbdh(0f, 0f, item.z0rrk(), item.z0crk()));
			z0ZzZzopk z0ZzZzopk3 = z0eek(p0, z0ZzZzsmk3, p2: true);
			if (z0ZzZzopk3 != null)
			{
				z0ZzZzkrj z0ZzZzkrj3 = new z0ZzZzkrj(p0.z0rek(), z0ZzZzopk3.z0eek(), item.z0srk(), item, PageContentPartyStyle.Body, z0ZzZzsmk3);
				z0ZzZzkrj3.z0rek(new z0ZzZzndh(0, 0, (int)item.z0rrk(), (int)item.z0crk()));
				z0ZzZzkrj3.z0eek(new z0ZzZzbdh(0f, 0f, item.z0rrk(), item.z0crk()));
				z0ZzZzkrj3.z0eek((z0ZzZzxej)0);
				z0ZzZzkrj3.z0eek(z0uek());
				item.z0srk().z0eek(z0ZzZzkrj3);
				p0.z0rek().z0eek(p4);
			}
		}
	}

	protected void z0eek(z0ZzZzsmk p0)
	{
		if (z0wrk != p0)
		{
			z0wrk = p0;
		}
	}

	private void z0eek(z0ZzZzjpk p0, z0ZzZzimk p1, string p2, Color p3, Color p4, Color p5, z0ZzZzndh p6)
	{
		using (z0ZzZzzdh p7 = new z0ZzZzzdh(p4))
		{
			p0.z0eek(p7, p6);
		}
		if (p2 != null && p2.Length > 0)
		{
			using z0ZzZzlsh z0ZzZzlsh2 = new z0ZzZzlsh();
			z0ZzZzlsh2.z0rek(StringAlignment.Center);
			z0ZzZzlsh2.z0eek(StringAlignment.Center);
			z0ZzZzlsh2.z0eek((z0ZzZzksh)4096);
			p0.z0eek(p2, p1, p3, new z0ZzZzbdh(p6.z0pek(), p6.z0mek(), p6.z0iek(), p6.z0oek()), z0ZzZzlsh2);
		}
		using z0ZzZzudh p8 = new z0ZzZzudh(p5);
		p0.z0eek(p8, p6);
	}

	public void z0tek(Color p0)
	{
		if (z0zrk != p0)
		{
			z0zrk = p0;
			z0hz();
		}
	}

	public new void z0rek(int p0)
	{
		z0yrk = p0;
	}

	public void z0tek(int p0)
	{
		if (z0xrk == null || z0xrk.Count <= 0)
		{
			return;
		}
		foreach (z0ZzZzwrj item in z0xrk)
		{
			if (item.z0vek() == p0)
			{
				z0htk = item;
				break;
			}
		}
	}

	public new int z0krk()
	{
		return z0ltk;
	}

	public override void z0ghk(z0ZzZzndh p0)
	{
		p0 = z0rek(p0);
		if (p0.z0vek())
		{
			return;
		}
		if (!(base.z0ark is z0ZzZzhrj z0ZzZzhrj2))
		{
			base.z0ghk(p0);
			return;
		}
		foreach (z0ZzZzsmk item in z0ZzZzhrj2)
		{
			z0ZzZzndh p1 = z0ZzZzndh.z0tek(item.z0uek(), p0);
			if (!p1.z0vek())
			{
				p1 = ((z0ZzZzqmk)item).z0eek(p1);
				((z0ZzZzmwh)this).z0eek(p1);
			}
		}
	}

	public new Color z0jrk()
	{
		return z0zrk;
	}

	protected virtual void z0pc(z0ZzZzopk p0, z0ZzZzsmk p1)
	{
		if (!p1.z0oek() && p1.z0nek())
		{
			z0ZzZzndh z0ZzZzndh2 = p1.z0tek_jiejie20260327142557();
			using z0ZzZzzdh p2 = new z0ZzZzzdh(Color.FromArgb(140, z0jrk()));
			p0.z0rek().z0eek(p2, z0ZzZzndh2.z0pek(), z0ZzZzndh2.z0mek(), z0ZzZzndh2.z0iek() + 2, z0ZzZzndh2.z0oek() + 2);
		}
	}

	internal new bool z0hrk()
	{
		return z0mrk == PageViewMode.CompressPage;
	}

	public new virtual void z0rek(z0ZzZzwrj p0)
	{
		z0htk = p0;
	}

	public new bool z0grk()
	{
		return z0prk;
	}

	public new z0ZzZzerj z0frk()
	{
		return z0xrk;
	}

	public void z0eek(PageViewMode p0)
	{
		z0mrk = p0;
	}

	public new Color z0drk()
	{
		return z0brk;
	}

	public new int z0srk()
	{
		if (z0htk == null)
		{
			return 0;
		}
		return z0htk.z0vek();
	}

	protected override void z0jz(z0ZzZzreh p0)
	{
		base.z0jz(p0);
		z0eek(new z0ZzZzopk(p0.z0eek(), p0.z0tek()));
	}

	public bool z0yek(int p0)
	{
		if (z0krk() >= 0 && p0 < z0krk())
		{
			p0 = z0krk();
		}
		if (z0bek() >= 0 && p0 > z0bek())
		{
			p0 = z0bek();
		}
		if (z0frk() != null && p0 >= 0 && p0 < z0frk().Count)
		{
			z0ZzZzwrj z0ZzZzwrj2 = z0frk()[p0];
			z0htk = z0ZzZzwrj2;
			z0hz();
			return true;
		}
		return false;
	}

	protected virtual z0ZzZzcpk z0eek(z0ZzZzwrj p0, z0ZzZzjpk p1, z0ZzZzndh p2, bool p3)
	{
		if (p0 == null || !z0xrk.Contains(p0))
		{
			return null;
		}
		z0ZzZzndh p4 = p0.z0erk();
		z0ZzZzcpk z0ZzZzcpk2 = z0zek();
		z0ZzZzcpk2.z0eek(1);
		z0ZzZzcpk2.z0rek(p4);
		z0ZzZzndh z0ZzZzndh2 = z0ZzZzndh.z0cek;
		foreach (z0ZzZzsmk item in z0lrk())
		{
			if (item.z0cek() == p0 && (item.z0vek() == PageContentPartyStyle.HeaderRows || item.z0vek() == PageContentPartyStyle.Body))
			{
				z0ZzZzndh2 = ((!z0ZzZzndh2.z0vek()) ? z0ZzZzndh.z0yek(item.z0lrk(), z0ZzZzndh2) : item.z0lrk());
			}
		}
		z0ZzZzcpk2.z0eek(z0ZzZzndh2);
		z0ZzZzcpk2.z0eek(p0.z0dtk);
		if (p0.z0jtk != null && p0.z0trk().z0otk() && !p0.z0ark())
		{
			z0ZzZzcpk2.z0uek(p0.z0jtk.z0iek());
			z0ZzZzcpk2.z0rek(p0.z0jtk.z0eek());
			z0ZzZzcpk2.z0tek(p0.z0jtk.z0yek());
			z0ZzZzcpk2.z0yek(p0.z0jtk.z0lrk());
		}
		if (p0 == z0xek())
		{
			if (((z0ZzZzmwh)this).z0zek())
			{
				z0ZzZzcpk2.z0tek(z0mek());
				z0ZzZzcpk2.z0eek(1);
			}
			else
			{
				z0ZzZzcpk2.z0tek(Color.LightGray);
				z0ZzZzcpk2.z0eek(1);
			}
		}
		else
		{
			z0ZzZzcpk2.z0eek(1);
			z0ZzZzcpk2.z0tek(z0drk());
		}
		z0ZzZzcpk2.z0rek(p3);
		z0ZzZzcpk2.z0eek(z0jrk());
		z0ZzZzcpk2.z0eek(z0rc());
		if (z0rc() != null && z0rc().z0yek())
		{
			z0ZzZzcpk2.z0xrk = (int)((double)z0rc().z0eek() / base.z0pek());
		}
		z0ZzZzcpk2.z0eek(z0pek());
		if (p1.z0vek() != ((z0ZzZzspj)this).z0cek() && z0ZzZzcpk2.z0rek() != null)
		{
			z0ZzZzcpk2.z0eek((z0ZzZzvpk)z0ZzZzcpk2.z0rek().Clone());
			z0ZzZzcpk2.z0rek().BorderWidth = z0ZzZzrpk.z0eek(z0ZzZzcpk2.z0rek().BorderWidth, ((z0ZzZzspj)this).z0cek(), p1.z0vek());
		}
		if (p0.z0ark() || z0hrk())
		{
			z0ZzZzcpk2.z0rek(0);
		}
		else
		{
			z0ZzZzcpk2.z0rek(z0crk);
		}
		z0ZzZzcpk2.z0eek(z0jc());
		z0ZzZzcpk2.z0eek(base.z0xek());
		return z0ZzZzcpk2;
	}

	public void z0eek(z0ZzZzerj p0)
	{
		z0xrk = p0;
	}

	public virtual void z0eek(HeaderFooterFlagVisible p0)
	{
		z0trk = p0;
	}

	public virtual z0ZzZzgpk z0rc()
	{
		return z0ork;
	}

	protected virtual void z0lx(object p0, z0ZzZzjpk p1, z0ZzZzndh p2, bool p3)
	{
		z0ZzZzwrj z0ZzZzwrj2 = (z0ZzZzwrj)p0;
		if (z0ZzZzwrj2 != null && z0xrk.Contains(z0ZzZzwrj2))
		{
			z0eek(z0ZzZzwrj2, p1, p2, p3)?.z0eek(p1, p2);
		}
	}

	public void z0uek(int p0)
	{
		z0ltk = p0;
	}
}
