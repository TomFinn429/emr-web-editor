using System;
using System.Runtime.CompilerServices;
using DCSoft.Printing;
using DCSoft.Writer.Controls;
using DCSoft.Writer.Dom;
using DCSystem_Drawing;

namespace zzz;

public class z0ZzZzynj : z0ZzZzmwh
{
	internal delegate void z0rok(z0ZzZzodh[] ps);

	[CompilerGenerated]
	private sealed class z0tik
	{
		public XTextDocument z0tek;

		public z0ZzZzynj z0yek;

		internal void z0eek(z0ZzZzodh[] p0)
		{
			int num = (int)z0ZzZzrpk.z0eek((float)(p0[1].z0rek() - z0yek.z0yrk.z0pek()) / z0yek.z0uek(), GraphicsUnit.Pixel, GraphicsUnit.Document);
			if (num < 0)
			{
				num = 0;
			}
			DocumentContentStyle documentContentStyle = z0yek.z0oek().z0aek().z0yek();
			documentContentStyle.z0eek(p0: true);
			if (documentContentStyle.LeftIndent == (float)num)
			{
				return;
			}
			z0ZzZzbdh z0ZzZzbdh2 = z0yek.z0oek().z0jy().z0myk_jiejie20260327142557();
			if (num >= 0 && (double)num < (double)z0ZzZzbdh2.z0uek() * 0.8)
			{
				documentContentStyle.LeftIndent = num;
				documentContentStyle.FirstLineIndent = Math.Max(documentContentStyle.FirstLineIndent, 0f - documentContentStyle.LeftIndent);
				z0tek.z0ytk();
				XTextElementList xTextElementList = z0tek.z0cuk().z0rek(documentContentStyle);
				if (xTextElementList != null && xTextElementList.Count > 0)
				{
					z0tek.z0nuk();
					z0tek.Modified = true;
					z0tek.OnSelectionChanged();
					z0tek.OnDocumentContentChanged();
					z0yek.z0hz();
				}
				else
				{
					z0tek.z0nuk();
				}
			}
		}

		internal void z0rek(z0ZzZzodh[] p0)
		{
			DocumentContentStyle documentContentStyle = z0yek.z0oek().z0aek().z0yek();
			int num = (int)(z0ZzZzrpk.z0eek((float)(p0[1].z0rek() - z0yek.z0yrk.z0pek()) / z0yek.z0uek(), GraphicsUnit.Pixel, GraphicsUnit.Document) - documentContentStyle.LeftIndent);
			documentContentStyle.z0eek(p0: true);
			if (documentContentStyle.FirstLineIndent == (float)num)
			{
				return;
			}
			z0ZzZzbdh z0ZzZzbdh2 = z0yek.z0oek().z0jy().z0myk_jiejie20260327142557();
			if ((float)num >= 0f - documentContentStyle.LeftIndent && (double)num < (double)z0ZzZzbdh2.z0uek() * 0.8)
			{
				documentContentStyle.FirstLineIndent = num;
				z0tek.z0ytk();
				XTextElementList xTextElementList = z0tek.z0cuk().z0rek(documentContentStyle);
				if (xTextElementList != null && xTextElementList.Count > 0)
				{
					z0tek.z0nuk();
					z0tek.Modified = true;
					z0tek.OnSelectionChanged();
					z0tek.OnDocumentContentChanged();
					z0yek.z0hz();
				}
				else
				{
					z0tek.z0nuk();
				}
			}
		}
	}

	[CompilerGenerated]
	private sealed class z0uik
	{
		public z0tik z0tek;

		public int z0yek;

		internal void z0eek(z0ZzZzodh[] p0)
		{
			int num = (int)z0ZzZzrpk.z0eek((z0tek.z0yek.z0hrk.z0mek() - (float)p0[1].z0rek()) / z0tek.z0yek.z0uek());
			bool flag = false;
			if (num > 0 && z0tek.z0yek.z0zek.RightMargin != num && (double)(num + z0tek.z0yek.z0zek.LeftMargin) < (double)z0yek * 0.8)
			{
				flag = true;
			}
			if (flag)
			{
				if (z0tek.z0tek.z0ytk())
				{
					z0tek.z0tek.z0imk().z0eek("RightMargin", z0tek.z0yek.z0zek.RightMargin, num, z0tek.z0yek.z0zek);
					z0tek.z0tek.z0imk().z0eek((z0ZzZzbzj)2);
					z0tek.z0tek.z0nuk();
				}
				z0tek.z0yek.z0zek.RightMargin = num;
				((z0ZzZzspj)z0tek.z0yek.z0vek.z0ypk()).z0uek();
				z0tek.z0yek.z0vek.z0eek(p0: false, p1: true);
				z0tek.z0tek.Modified = true;
				z0tek.z0tek.OnDocumentContentChanged();
				z0tek.z0yek.z0hz();
			}
		}

		internal void z0rek(z0ZzZzodh[] p0)
		{
			int num = (int)z0ZzZzrpk.z0eek(((float)p0[1].z0rek() - z0tek.z0yek.z0hrk.z0tek()) / z0tek.z0yek.z0uek());
			bool flag = false;
			if (num > 0 && z0tek.z0yek.z0zek.LeftMargin != num && (double)(num + z0tek.z0yek.z0zek.RightMargin) < (double)z0yek * 0.8)
			{
				flag = true;
			}
			if (flag)
			{
				if (z0tek.z0tek.z0ytk())
				{
					z0tek.z0tek.z0imk().z0eek("LeftMargin", z0tek.z0yek.z0zek.LeftMargin, num, z0tek.z0yek.z0zek);
					z0tek.z0tek.z0imk().z0eek((z0ZzZzbzj)2);
					z0tek.z0tek.z0nuk();
				}
				z0tek.z0yek.z0zek.LeftMargin = num;
				((z0ZzZzspj)z0tek.z0yek.z0vek.z0ypk()).z0uek();
				z0tek.z0yek.z0vek.z0eek(p0: false, p1: true);
				z0tek.z0tek.Modified = true;
				z0tek.z0tek.OnDocumentContentChanged();
				z0tek.z0yek.z0hz();
			}
		}
	}

	[CompilerGenerated]
	private sealed class z0iik
	{
		public z0tik z0tek;

		public float z0yek;

		internal void z0eek(z0ZzZzodh[] p0)
		{
			int num = (int)z0ZzZzrpk.z0eek((z0tek.z0yek.z0hrk.z0nek() - (float)p0[1].z0tek()) / z0tek.z0yek.z0eek());
			bool flag = false;
			if (num > 0 && z0tek.z0yek.z0zek.BottomMargin != num && (double)(num + z0tek.z0yek.z0zek.TopMargin) < (double)z0yek * 0.8)
			{
				flag = true;
			}
			if (flag)
			{
				if (z0tek.z0tek.z0ytk())
				{
					z0tek.z0tek.z0imk().z0eek("BottomMargin", z0tek.z0yek.z0zek.BottomMargin, num, z0tek.z0yek.z0zek);
					z0tek.z0tek.z0imk().z0eek((z0ZzZzbzj)2);
					z0tek.z0tek.z0nuk();
				}
				z0tek.z0yek.z0zek.BottomMargin = num;
				((z0ZzZzspj)z0tek.z0yek.z0vek.z0ypk()).z0uek();
				z0tek.z0yek.z0vek.z0eek(p0: false, p1: true);
				z0tek.z0tek.Modified = true;
				z0tek.z0tek.OnDocumentContentChanged();
				z0tek.z0yek.z0hz();
			}
		}

		internal void z0rek(z0ZzZzodh[] p0)
		{
			int num = (int)z0ZzZzrpk.z0eek(((float)p0[1].z0tek() - z0tek.z0yek.z0hrk.z0yek()) / z0tek.z0yek.z0eek());
			bool flag = false;
			if (num > 0 && z0tek.z0yek.z0zek.TopMargin != num && (double)(num + z0tek.z0yek.z0zek.BottomMargin) < (double)z0yek * 0.8)
			{
				flag = true;
			}
			if (flag)
			{
				if (z0tek.z0tek.z0ytk())
				{
					z0tek.z0tek.z0imk().z0eek("TopMargin", z0tek.z0yek.z0zek.TopMargin, num, z0tek.z0yek.z0zek);
					z0tek.z0tek.z0imk().z0eek((z0ZzZzbzj)2);
					z0tek.z0tek.z0nuk();
				}
				z0tek.z0yek.z0zek.TopMargin = num;
				((z0ZzZzspj)z0tek.z0yek.z0vek.z0ypk()).z0uek();
				z0tek.z0yek.z0vek.z0eek(p0: false, p1: true);
				z0tek.z0tek.Modified = true;
				z0tek.z0tek.OnDocumentContentChanged();
				z0tek.z0yek.z0hz();
			}
		}
	}

	[CompilerGenerated]
	private sealed class z0oik
	{
		public z0rok z0rek;

		public z0ZzZzypj z0tek;

		internal void z0eek(object p0, EventArgs p1)
		{
			z0ZzZzodh[] ps = new z0ZzZzodh[2]
			{
				z0tek.z0tek(),
				z0tek.z0hrk()
			};
			z0rek(ps);
		}
	}

	public new static z0ZzZzudh z0bek = new z0ZzZzudh(Color.FromArgb(128, 128, 128));

	private new z0ZzZzdbj z0vek;

	public new static z0ZzZzzdh z0cek = new z0ZzZzzdh(Color.FromArgb(177, 202, 235));

	private new float z0xek = 1f;

	internal new XPageSettings z0zek;

	internal new static z0ZzZzrfh z0lrk = null;

	private new z0ZzZzwrj z0krk;

	private new XTextParagraphFlagElement z0jrk;

	private new z0ZzZzbdh z0hrk = z0ZzZzbdh.z0xek;

	public new static readonly Color z0grk = Color.FromArgb(155, 187, 227);

	internal new z0ZzZzunj z0frk = (z0ZzZzunj)1;

	public int z0drk;

	public static z0ZzZzzdh z0srk = new z0ZzZzzdh(Color.FromArgb(90, 97, 108));

	public static z0ZzZzudh z0ark = new z0ZzZzudh(Color.FromArgb(213, 226, 243));

	private new z0ZzZzndh z0qrk = z0ZzZzndh.z0cek;

	internal static z0ZzZzrfh z0wrk = null;

	private z0ZzZzbdh z0erk = z0ZzZzbdh.z0xek;

	private bool z0trk;

	private new z0ZzZzndh z0yrk = z0ZzZzndh.z0cek;

	private z0ZzZzndh z0urk = z0ZzZzndh.z0cek;

	private z0ZzZzndh z0irk = z0ZzZzndh.z0cek;

	private new z0ZzZzndh z0ork = z0ZzZzndh.z0cek;

	internal z0ZzZzypj z0prk;

	public string z0mrk;

	public new int z0nrk;

	public void z0eek(object p0, EventArgs p1)
	{
		z0eek(p0: false);
	}

	protected override bool z0fz()
	{
		return true;
	}

	internal void z0eek(z0ZzZzdbj p0)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("ctl");
		}
		z0vek = p0;
	}

	protected override void z0gz(bool p0)
	{
	}

	private new void z0eek(z0ZzZzadh p0, z0ZzZzndh p1)
	{
		if (z0zek == null)
		{
			return;
		}
		float num = z0uek();
		if (z0xek != num)
		{
			z0eek(p0: false);
		}
		z0trk = true;
		float num2 = (float)(z0ZzZzrpk.z0eek(GraphicsUnit.Pixel, GraphicsUnit.Inch) / 100.0) * num;
		float num3 = z0ZzZzrpk.z0eek(10, GraphicsUnit.Millimeter, GraphicsUnit.Pixel);
		num3 *= num;
		z0hrk = new z0ZzZzbdh(z0irk.z0pek(), z0irk.z0mek() + 6, z0irk.z0iek(), z0irk.z0oek() - 12);
		float num4 = (z0zek.z0ork() ? z0zek.z0jtk() : z0zek.z0ntk());
		z0erk.z0eek(z0hrk.z0oek() + (float)z0zek.LeftMargin * num2);
		z0erk.z0rek(z0hrk.z0pek() + 1f);
		z0erk.z0tek((num4 - (float)z0zek.LeftMargin - (float)z0zek.RightMargin) * num2);
		z0erk.z0yek(z0hrk.z0iek() - 2f);
		z0ZzZzndh p2 = new z0ZzZzndh((int)z0hrk.z0oek(), (int)z0hrk.z0pek(), (int)z0hrk.z0uek(), (int)z0hrk.z0iek());
		p0.z0eek(z0cek, p2);
		p0.z0rek(z0ZzZzyfh.z0iek, z0erk);
		p0.z0eek(z0ark, p2);
		using (z0ZzZzlsh z0ZzZzlsh2 = new z0ZzZzlsh(z0ZzZzlsh.z0uek()))
		{
			z0ZzZzlsh2.z0rek(StringAlignment.Near);
			z0ZzZzlsh2.z0eek(StringAlignment.Center);
			z0ZzZzlsh2.z0eek((z0ZzZzksh)4096);
			for (int i = 0; i < 10000; i++)
			{
				float num5 = (float)z0irk.z0pek() + num3 * (float)i;
				if (num5 >= z0hrk.z0mek())
				{
					break;
				}
				string p3 = z0ZzZzqik.z0rek(i);
				z0ZzZzxdh z0ZzZzxdh2 = p0.z0eek(p3, z0xek(), 1000, z0ZzZzlsh2);
				float p4 = num5 - z0ZzZzxdh2.z0rek() / 2f;
				if (i == 0)
				{
					p4 = num5 + 1f;
				}
				p0.z0eek(p3, z0xek(), z0srk, p4, z0erk.z0pek() + (float)(int)Math.Ceiling(z0ZzZzxdh2.z0tek() / 2f) - 1f, z0ZzZzlsh2);
				p0.z0eek(z0bek, num5, z0erk.z0nek() + 2f, num5, z0frk() - 2);
			}
		}
		if (z0jrk != null)
		{
			GraphicsUnit p5 = GraphicsUnit.Document;
			int num6 = z0wrk.z0iek();
			int num7 = ((z0ZzZzedh)z0wrk).z0yek();
			XTextContentElement xTextContentElement = z0jrk.z0jy();
			z0ZzZzrzj z0ZzZzrzj2 = z0jrk.z0aek();
			z0ZzZzbdh z0ZzZzbdh2 = xTextContentElement.z0myk_jiejie20260327142557();
			z0yrk.z0eek((int)(z0erk.z0oek() + z0ZzZzrpk.z0eek(z0ZzZzbdh2.z0oek(), p5, GraphicsUnit.Pixel) * num));
			z0yrk.z0tek((int)(z0ZzZzrpk.z0eek(z0ZzZzbdh2.z0uek(), p5, GraphicsUnit.Pixel) * num));
			float num8 = z0erk.z0oek() + z0ZzZzrpk.z0eek(z0ZzZzbdh2.z0oek() + z0ZzZzrzj2.z0pyk + z0ZzZzrzj2.z0hyk, p5, GraphicsUnit.Pixel) * num;
			z0ork = new z0ZzZzndh((int)(num8 - (float)(num6 / 2)), (int)(z0erk.z0pek() - (float)(num7 / 2) - 1f), num6, num7);
			if (p1.z0rek(z0ork))
			{
				p0.z0eek(z0wrk, z0ork);
			}
			num8 = z0erk.z0oek() + z0ZzZzrpk.z0eek(z0ZzZzbdh2.z0oek() + z0ZzZzrzj2.z0hyk, p5, GraphicsUnit.Pixel) * num;
			z0qrk = new z0ZzZzndh((int)(num8 - (float)(num6 / 2)), (int)(z0erk.z0nek() - (float)(num7 / 2) + 1f), num6, num7);
			if (p1.z0rek(z0qrk))
			{
				p0.z0eek(z0lrk, z0qrk);
			}
		}
	}

	private new void z0eek(string p0)
	{
		z0mrk = p0;
	}

	public z0ZzZzynj()
	{
		z0ZzZzopj.z0eek(this);
	}

	public override void z0hz()
	{
		z0vek.z0lh()?.RuleInvalidateView(base.z0nek());
	}

	private new float z0eek()
	{
		if (z0vek != null && z0vek.z0lh() != null)
		{
			return z0vek.z0vtk();
		}
		return 1f;
	}

	private new bool z0rek()
	{
		if (z0vek == null)
		{
			return true;
		}
		if (z0vek.z0ook() == FormViewMode.Normal || z0vek.z0ook() == FormViewMode.Strict)
		{
			return true;
		}
		return z0vek.z0sok();
	}

	internal new void z0eek(bool p0)
	{
		if (z0vek.z0ypk() == null)
		{
			return;
		}
		z0zek = null;
		z0krk = z0vek.z0lrk();
		if (z0krk == null)
		{
			z0krk = z0vek.z0apk().z0iek();
		}
		if (z0krk == null)
		{
			return;
		}
		z0zek = z0krk.z0trk();
		int num = z0iek();
		if (z0frk == (z0ZzZzunj)1)
		{
			z0xek = z0uek();
			z0ZzZzndh z0ZzZzndh2 = z0krk.z0erk();
			z0ZzZzndh2.z0eek(0);
			z0ZzZzndh2.z0tek((int)(z0ZzZzrpk.z0eek(z0zek.z0drk(), GraphicsUnit.Document, GraphicsUnit.Pixel) * z0uek()));
			z0ZzZzndh z0ZzZzndh3 = new z0ZzZzndh(z0ZzZzndh2.z0pek(), (z0frk() - num) / 2, z0ZzZzndh2.z0iek(), num);
			z0irk = z0ZzZzndh3;
			z0hz();
		}
		else if (z0frk == (z0ZzZzunj)0)
		{
			z0xek = z0eek();
			z0ZzZzndh z0ZzZzndh4 = z0krk.z0erk();
			z0ZzZzndh4.z0rek(0);
			z0ZzZzndh z0ZzZzndh5 = new z0ZzZzndh((base.z0mek() - num) / 2, z0ZzZzndh4.z0mek(), num, z0ZzZzndh4.z0oek());
			z0irk = z0ZzZzndh5;
			if (z0bek().z0rek(z0irk) || z0trk)
			{
				z0hz();
			}
		}
	}

	protected override void z0jz(z0ZzZzreh p0)
	{
		z0trk = false;
		z0yek();
		if (z0frk == (z0ZzZzunj)1)
		{
			z0eek(p0.z0eek(), p0.z0tek());
		}
		else if (z0frk == (z0ZzZzunj)0 && ((z0ZzZzqrj)z0mek().z0ypk()).z0uek() != PageViewMode.CompressPage)
		{
			z0rek(p0.z0eek(), p0.z0tek());
		}
	}

	internal void z0tek()
	{
		z0vek = null;
		z0prk = null;
		z0krk = null;
		z0jrk = null;
		z0mrk = null;
	}

	public new static void z0yek()
	{
		if (z0wrk == null)
		{
			z0wrk = z0ZzZzgfh.z0oek;
			z0lrk = z0ZzZzgfh.z0bek;
		}
	}

	private new float z0uek()
	{
		if (z0vek != null && z0vek.z0lh() != null)
		{
			return z0vek.z0vtk();
		}
		return 1f;
	}

	protected override void z0kz(EventArgs p0)
	{
		base.z0kz(p0);
		z0eek(p0: false);
	}

	internal new int z0iek()
	{
		return 24;
	}

	public new XTextParagraphFlagElement z0oek()
	{
		return z0jrk;
	}

	private void z0eek(z0rok p0)
	{
		z0ZzZzypj z0tek = new z0ZzZzypj(this);
		z0tek.z0eek((z0ZzZzupj)4);
		z0tek.z0rrk = z0eek;
		z0tek.z0trk = delegate
		{
			z0ZzZzodh[] ps = new z0ZzZzodh[2]
			{
				z0tek.z0tek(),
				z0tek.z0hrk()
			};
			p0(ps);
		};
		z0prk = z0tek;
	}

	private new bool z0pek()
	{
		if (z0oek() == null)
		{
			return true;
		}
		return !z0vek.z0ruk().z0xek().z0un();
	}

	public new z0ZzZzdbj z0mek()
	{
		return z0vek;
	}

	public override void z0lz_jiejie20260327142557()
	{
		base.z0lz_jiejie20260327142557();
		z0tek();
	}

	internal void z0eek(z0ZzZzweh p0, z0ZzZzepj p1)
	{
		if (((z0ZzZzqrj)z0mek().z0ypk()).z0uek() == PageViewMode.CompressPage)
		{
			return;
		}
		switch (p1)
		{
		case (z0ZzZzepj)1:
			if (z0prk != null && z0prk.z0eek(p0))
			{
				return;
			}
			break;
		case (z0ZzZzepj)2:
			if (z0prk != null)
			{
				z0prk.z0rek(p0);
				z0prk = null;
				z0vek.z0lh().z0qlk();
				return;
			}
			break;
		}
		z0ZzZznwh z0ZzZznwh2 = z0ZzZzdbj.z0juk();
		string p2 = null;
		if (z0zek == null)
		{
			return;
		}
		XTextDocument z0tek = z0vek.z0ruk();
		if (z0frk == (z0ZzZzunj)1)
		{
			int num = (int)z0ZzZzrpk.z0eek(200.0, GraphicsUnit.Document, GraphicsUnit.Pixel);
			if (!z0ork.z0vek() && z0ork.z0eek(p0.z0rek(), p0.z0tek()))
			{
				if (z0pek())
				{
					z0eek((string)null);
					return;
				}
				p2 = z0ZzZziok.z0buk();
				if (p1 == (z0ZzZzepj)0 && p0.z0yek() == (z0ZzZzqeh)1)
				{
					z0urk = new z0ZzZzndh(z0yrk.z0pek(), 1, z0yrk.z0iek() - num, 1);
					z0eek(delegate(z0ZzZzodh[] array)
					{
						DocumentContentStyle documentContentStyle = z0oek().z0aek().z0yek();
						int num6 = (int)(z0ZzZzrpk.z0eek((float)(array[1].z0rek() - z0yrk.z0pek()) / z0uek(), GraphicsUnit.Pixel, GraphicsUnit.Document) - documentContentStyle.LeftIndent);
						documentContentStyle.z0eek(p0: true);
						if (documentContentStyle.FirstLineIndent != (float)num6)
						{
							z0ZzZzbdh z0ZzZzbdh2 = z0oek().z0jy().z0myk_jiejie20260327142557();
							if ((float)num6 >= 0f - documentContentStyle.LeftIndent && (double)num6 < (double)z0ZzZzbdh2.z0uek() * 0.8)
							{
								documentContentStyle.FirstLineIndent = num6;
								z0tek.z0ytk();
								XTextElementList xTextElementList = z0tek.z0cuk().z0rek(documentContentStyle);
								if (xTextElementList != null && xTextElementList.Count > 0)
								{
									z0tek.z0nuk();
									z0tek.Modified = true;
									z0tek.OnSelectionChanged();
									z0tek.OnDocumentContentChanged();
									z0hz();
								}
								else
								{
									z0tek.z0nuk();
								}
							}
						}
					});
				}
			}
			else if (!z0qrk.z0vek() && z0qrk.z0eek(p0.z0rek(), p0.z0tek()))
			{
				if (z0pek())
				{
					z0eek((string)null);
					return;
				}
				p2 = z0ZzZziok.z0uik();
				if (p1 == (z0ZzZzepj)0 && p0.z0yek() == (z0ZzZzqeh)1)
				{
					z0urk = new z0ZzZzndh(z0yrk.z0pek(), 1, z0yrk.z0iek() - num, 1);
					z0eek(delegate(z0ZzZzodh[] array)
					{
						int num6 = (int)z0ZzZzrpk.z0eek((float)(array[1].z0rek() - z0yrk.z0pek()) / z0uek(), GraphicsUnit.Pixel, GraphicsUnit.Document);
						if (num6 < 0)
						{
							num6 = 0;
						}
						DocumentContentStyle documentContentStyle = z0oek().z0aek().z0yek();
						documentContentStyle.z0eek(p0: true);
						if (documentContentStyle.LeftIndent != (float)num6)
						{
							z0ZzZzbdh z0ZzZzbdh2 = z0oek().z0jy().z0myk_jiejie20260327142557();
							if (num6 >= 0 && (double)num6 < (double)z0ZzZzbdh2.z0uek() * 0.8)
							{
								documentContentStyle.LeftIndent = num6;
								documentContentStyle.FirstLineIndent = Math.Max(documentContentStyle.FirstLineIndent, 0f - documentContentStyle.LeftIndent);
								z0tek.z0ytk();
								XTextElementList xTextElementList = z0tek.z0cuk().z0rek(documentContentStyle);
								if (xTextElementList != null && xTextElementList.Count > 0)
								{
									z0tek.z0nuk();
									z0tek.Modified = true;
									z0tek.OnSelectionChanged();
									z0tek.OnDocumentContentChanged();
									z0hz();
								}
								else
								{
									z0tek.z0nuk();
								}
							}
						}
					});
				}
			}
			else if ((float)p0.z0tek() >= z0erk.z0pek() && (float)p0.z0tek() <= z0erk.z0nek())
			{
				if (z0rek())
				{
					z0eek((string)null);
					return;
				}
				int z0yek = (z0zek.z0ork() ? z0zek.z0jtk() : z0zek.z0ntk());
				if (Math.Abs((float)p0.z0rek() - z0erk.z0oek()) < 2f)
				{
					z0ZzZznwh2 = z0ZzZzdbj.z0kuk();
					switch (p1)
					{
					case (z0ZzZzepj)1:
						p2 = z0ZzZziok.z0yuk();
						break;
					case (z0ZzZzepj)0:
					{
						if (p0.z0yek() != (z0ZzZzqeh)1)
						{
							break;
						}
						int num2 = (int)z0ZzZzrpk.z0eek((double)z0zek.RightMargin * 3.0, GraphicsUnit.Document, GraphicsUnit.Pixel);
						z0urk = new z0ZzZzndh(z0irk.z0pek(), 1, z0irk.z0iek() - num2, 1);
						z0eek(delegate(z0ZzZzodh[] array)
						{
							int num6 = (int)z0ZzZzrpk.z0eek(((float)array[1].z0rek() - z0hrk.z0tek()) / z0uek());
							bool flag = false;
							if (num6 > 0 && z0zek.LeftMargin != num6 && (double)(num6 + z0zek.RightMargin) < (double)z0yek * 0.8)
							{
								flag = true;
							}
							if (flag)
							{
								if (z0tek.z0ytk())
								{
									z0tek.z0imk().z0eek("LeftMargin", z0zek.LeftMargin, num6, z0zek);
									z0tek.z0imk().z0eek((z0ZzZzbzj)2);
									z0tek.z0nuk();
								}
								z0zek.LeftMargin = num6;
								((z0ZzZzspj)z0vek.z0ypk()).z0uek();
								z0vek.z0eek(p0: false, p1: true);
								z0tek.Modified = true;
								z0tek.OnDocumentContentChanged();
								z0hz();
							}
						});
						break;
					}
					}
				}
				else if (Math.Abs((float)p0.z0rek() - z0erk.z0mek()) < 2f)
				{
					z0ZzZznwh2 = z0ZzZzdbj.z0kuk();
					switch (p1)
					{
					case (z0ZzZzepj)1:
						p2 = z0ZzZziok.z0brk();
						break;
					case (z0ZzZzepj)0:
					{
						if (p0.z0yek() != (z0ZzZzqeh)1)
						{
							break;
						}
						int num3 = (int)z0ZzZzrpk.z0eek((double)z0zek.LeftMargin * 3.0, GraphicsUnit.Document, GraphicsUnit.Pixel);
						z0urk = new z0ZzZzndh(z0irk.z0pek() + num3, 1, z0irk.z0iek() - num3, 1);
						z0eek(delegate(z0ZzZzodh[] array)
						{
							int num6 = (int)z0ZzZzrpk.z0eek((z0hrk.z0mek() - (float)array[1].z0rek()) / z0uek());
							bool flag = false;
							if (num6 > 0 && z0zek.RightMargin != num6 && (double)(num6 + z0zek.LeftMargin) < (double)z0yek * 0.8)
							{
								flag = true;
							}
							if (flag)
							{
								if (z0tek.z0ytk())
								{
									z0tek.z0imk().z0eek("RightMargin", z0zek.RightMargin, num6, z0zek);
									z0tek.z0imk().z0eek((z0ZzZzbzj)2);
									z0tek.z0nuk();
								}
								z0zek.RightMargin = num6;
								((z0ZzZzspj)z0vek.z0ypk()).z0uek();
								z0vek.z0eek(p0: false, p1: true);
								z0tek.Modified = true;
								z0tek.OnDocumentContentChanged();
								z0hz();
							}
						});
						break;
					}
					}
				}
			}
		}
		else if (z0frk == (z0ZzZzunj)0)
		{
			if (z0rek())
			{
				z0eek((string)null);
				return;
			}
			float z0yek2 = (z0zek.z0ork() ? z0zek.z0ntk() : z0zek.z0jtk());
			if ((float)p0.z0rek() >= z0erk.z0oek() && (float)p0.z0rek() <= z0erk.z0mek())
			{
				if (Math.Abs((float)p0.z0tek() - z0erk.z0pek()) < 2f)
				{
					z0ZzZznwh2 = z0ZzZzdbj.z0wok();
					switch (p1)
					{
					case (z0ZzZzepj)1:
						p2 = z0ZzZziok.z0ork();
						break;
					case (z0ZzZzepj)0:
					{
						if (p0.z0yek() != (z0ZzZzqeh)1)
						{
							break;
						}
						int num4 = (int)z0ZzZzrpk.z0eek((double)z0zek.BottomMargin * 3.0, GraphicsUnit.Document, GraphicsUnit.Pixel);
						z0urk = new z0ZzZzndh(1, z0irk.z0mek(), 1, z0irk.z0oek() - num4);
						z0eek(delegate(z0ZzZzodh[] array)
						{
							int num6 = (int)z0ZzZzrpk.z0eek(((float)array[1].z0tek() - z0hrk.z0yek()) / z0eek());
							bool flag = false;
							if (num6 > 0 && z0zek.TopMargin != num6 && (double)(num6 + z0zek.BottomMargin) < (double)z0yek2 * 0.8)
							{
								flag = true;
							}
							if (flag)
							{
								if (z0tek.z0ytk())
								{
									z0tek.z0imk().z0eek("TopMargin", z0zek.TopMargin, num6, z0zek);
									z0tek.z0imk().z0eek((z0ZzZzbzj)2);
									z0tek.z0nuk();
								}
								z0zek.TopMargin = num6;
								((z0ZzZzspj)z0vek.z0ypk()).z0uek();
								z0vek.z0eek(p0: false, p1: true);
								z0tek.Modified = true;
								z0tek.OnDocumentContentChanged();
								z0hz();
							}
						});
						break;
					}
					}
				}
				else if (Math.Abs((float)p0.z0tek() - z0erk.z0nek()) < 2f)
				{
					z0ZzZznwh2 = z0ZzZzdbj.z0wok();
					switch (p1)
					{
					case (z0ZzZzepj)1:
						p2 = z0ZzZziok.z0fok();
						break;
					case (z0ZzZzepj)0:
					{
						if (p0.z0yek() != (z0ZzZzqeh)1)
						{
							break;
						}
						int num5 = (int)z0ZzZzrpk.z0eek((double)z0zek.TopMargin * 3.0, GraphicsUnit.Document, GraphicsUnit.Pixel);
						z0urk = new z0ZzZzndh(1, z0irk.z0mek() + num5, 1, z0irk.z0oek() - num5);
						z0eek(delegate(z0ZzZzodh[] array)
						{
							int num6 = (int)z0ZzZzrpk.z0eek((z0hrk.z0nek() - (float)array[1].z0tek()) / z0eek());
							bool flag = false;
							if (num6 > 0 && z0zek.BottomMargin != num6 && (double)(num6 + z0zek.TopMargin) < (double)z0yek2 * 0.8)
							{
								flag = true;
							}
							if (flag)
							{
								if (z0tek.z0ytk())
								{
									z0tek.z0imk().z0eek("BottomMargin", z0zek.BottomMargin, num6, z0zek);
									z0tek.z0imk().z0eek((z0ZzZzbzj)2);
									z0tek.z0nuk();
								}
								z0zek.BottomMargin = num6;
								((z0ZzZzspj)z0vek.z0ypk()).z0uek();
								z0vek.z0eek(p0: false, p1: true);
								z0tek.Modified = true;
								z0tek.OnDocumentContentChanged();
								z0hz();
							}
						});
						break;
					}
					}
				}
			}
		}
		if (z0dx() != z0ZzZznwh2)
		{
			z0fx(z0ZzZznwh2);
		}
		if (p1 == (z0ZzZzepj)1)
		{
			z0eek(p2);
		}
	}

	public override void z0zx(bool p0)
	{
		z0hz();
	}

	private void z0rek(z0ZzZzadh p0, z0ZzZzndh p1)
	{
		if (z0zek == null)
		{
			return;
		}
		float num = z0eek();
		if (z0xek != num)
		{
			z0eek(p0: false);
		}
		z0trk = true;
		float num2 = (float)(z0ZzZzrpk.z0eek(GraphicsUnit.Pixel, GraphicsUnit.Inch) / 100.0) * num;
		float num3 = (float)z0ZzZzrpk.z0eek(10.0, GraphicsUnit.Millimeter, GraphicsUnit.Pixel);
		num3 *= num;
		z0hrk = new z0ZzZzbdh(z0irk.z0pek() + 6, z0irk.z0mek(), z0irk.z0iek() - 12, z0irk.z0oek());
		float num4 = (z0zek.z0ork() ? z0zek.z0ntk() : z0zek.z0jtk());
		z0erk.z0eek(z0hrk.z0oek() + 1f);
		z0erk.z0rek(z0hrk.z0pek() + (float)z0zek.TopMargin * num2);
		z0erk.z0tek(z0hrk.z0uek() - 2f);
		z0erk.z0yek((num4 - (float)z0zek.TopMargin - (float)z0zek.BottomMargin) * num2);
		p0.z0rek(z0cek, z0hrk);
		p0.z0rek(z0ZzZzyfh.z0iek, z0erk);
		p0.z0eek(z0ark, z0hrk.z0oek(), z0hrk.z0pek(), z0hrk.z0uek(), z0hrk.z0iek(), 0f);
		using z0ZzZzlsh z0ZzZzlsh2 = new z0ZzZzlsh(z0ZzZzlsh.z0uek());
		z0ZzZzlsh2.z0rek(StringAlignment.Near);
		z0ZzZzlsh2.z0eek(StringAlignment.Center);
		z0ZzZzlsh2.z0eek((z0ZzZzksh)4098);
		z0ZzZzteh z0ZzZzteh2 = z0tek_jiejie20260327142557();
		for (int i = 0; i < 10000; i++)
		{
			float num5 = (float)z0irk.z0mek() + num3 * (float)i;
			if (num5 >= z0hrk.z0nek() * num)
			{
				break;
			}
			string p2 = z0ZzZzqik.z0rek(i);
			z0ZzZzxdh z0ZzZzxdh2 = p0.z0eek(p2, z0xek(), 1000, z0ZzZzlsh2);
			float p3 = num5 - z0ZzZzxdh2.z0tek() / 2f;
			if (i == 0)
			{
				p3 = num5 + 1f;
			}
			p0.z0eek(p2, z0xek(), z0srk, z0erk.z0oek() + (z0erk.z0uek() - z0ZzZzxdh2.z0rek()) / 2f, p3, z0ZzZzlsh2);
			if (z0ZzZzteh2 == (z0ZzZzteh)1)
			{
				p0.z0eek(z0bek, z0erk.z0oek() - 2f, num5, 2f, num5);
			}
			else
			{
				p0.z0eek(z0bek, z0erk.z0mek() + 2f, num5, base.z0mek() - 2, num5);
			}
		}
	}

	public new void z0nek()
	{
		z0krk = null;
		z0jrk = null;
		z0zek = null;
	}

	private void z0eek(object p0, z0ZzZzrpj p1)
	{
		int num = z0vek.z0ypk().z0rek().IndexOf(z0krk);
		if (num < 0)
		{
			num = 0;
		}
		if (z0frk == (z0ZzZzunj)1)
		{
			int num2 = p1.z0yek().z0rek();
			if (!z0urk.z0vek())
			{
				if (num2 < z0urk.z0yek())
				{
					num2 = z0urk.z0yek();
				}
				else if (num2 > z0urk.z0nek())
				{
					num2 = z0urk.z0nek();
				}
			}
			num2 = (int)((float)num2 / z0uek());
			z0vek.z0lh().z0mz(num, num2, 0, num2, z0krk.z0erk().z0oek(), 0);
		}
		else
		{
			if (z0frk != 0)
			{
				return;
			}
			int num3 = p1.z0yek().z0tek();
			if (!z0urk.z0vek())
			{
				if (num3 < z0urk.z0uek())
				{
					num3 = z0urk.z0uek();
				}
				else if (num3 > z0urk.z0bek())
				{
					num3 = z0urk.z0bek();
				}
			}
			num3 = (int)((float)num3 / z0eek());
			z0vek.z0lh().z0mz(num, 0, num3, z0krk.z0erk().z0iek(), num3, 0);
		}
	}

	public void z0eek(XTextParagraphFlagElement p0)
	{
		if (z0jrk != p0)
		{
			z0jrk = p0;
			z0hz();
		}
	}
}
