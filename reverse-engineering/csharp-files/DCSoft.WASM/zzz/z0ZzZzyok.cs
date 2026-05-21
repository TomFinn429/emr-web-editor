using System;
using System.Collections.Generic;
using System.IO;
using DCSoft.Printing;
using DCSoft.Writer;
using DCSoft.Writer.Dom;
using DCSystem_Drawing;

namespace zzz;

internal class z0ZzZzyok
{
	[ThreadStatic]
	public static bool z0pek_jiejie20260327142557;

	private List<int> z0mek;

	public z0ZzZzrfh[] z0nek_jiejie20260327142557;

	private z0ZzZzclh z0bek = new z0ZzZzclh();

	private bool z0vek;

	private static bool z0cek;

	public z0ZzZzrfh[] z0tek()
	{
		using (z0ZzZzbpk z0ZzZzbpk2 = new z0ZzZzbpk(new MemoryStream()))
		{
			z0ZzZzbpk2.z0pek = new List<z0ZzZzrfh>();
			z0ZzZzbpk2.z0eek(z0cek);
			z0cek = false;
			z0ZzZzjpk p = z0ZzZzjpk.z0eek(z0ZzZzbpk2);
			z0tek(p, z0ZzZzbpk2, (z0ZzZzcxj)5);
			if (z0ZzZzbpk2.z0pek.Count > 0)
			{
				return z0ZzZzbpk2.z0pek.ToArray();
			}
		}
		return null;
	}

	public void z0eek(List<int> p0)
	{
		z0mek = p0;
	}

	private IList<z0ZzZzwrj> z0tek(z0ZzZzerj p0)
	{
		if (z0mek != null)
		{
			List<z0ZzZzwrj> list = new List<z0ZzZzwrj>();
			{
				foreach (int item in z0mek)
				{
					if (item >= 0 && item < p0.Count)
					{
						list.Add(p0[item]);
					}
				}
				return list;
			}
		}
		return p0;
	}

	public void z0tek(z0ZzZzjpk p0, z0ZzZzbpk p1, z0ZzZzcxj p2)
	{
		if (p1 == null)
		{
			throw new ArgumentNullException("pdfGraphics");
		}
		bool flag = z0pek_jiejie20260327142557;
		z0pek_jiejie20260327142557 = false;
		z0ZzZzclh z0ZzZzclh2 = z0yek();
		XTextDocument xTextDocument = z0ZzZzclh2.z0rek();
		z0ZzZzvxj z0ZzZzvxj2 = null;
		z0ZzZzvxj2 = ((p1 == null) ? new z0ZzZzvxj(xTextDocument, p0, z0ZzZzbdh.z0xek) : new z0ZzZzvxj(xTextDocument, p0, z0ZzZzbdh.z0xek, (z0ZzZzcxj)5));
		z0ZzZzvxj2.z0nrk = p1.z0pek != null;
		Dictionary<DocumentViewOptions, Color> dictionary = new Dictionary<DocumentViewOptions, Color>();
		Dictionary<XTextDocument, byte[]> dictionary2 = null;
		if (z0vek)
		{
			dictionary2 = new Dictionary<XTextDocument, byte[]>();
		}
		foreach (XTextDocument item in z0ZzZzclh2)
		{
			if (dictionary2 != null)
			{
				dictionary2[item] = item.z0mrk("xml");
			}
			z0ZzZzvxj2.z0eek(item);
			if (p1 != null)
			{
				item.z0qtk().Printing = true;
				item.z0qtk().RenderMode = DocumentRenderMode.PDF;
			}
			else
			{
				item.z0qtk().Printing = flag;
				item.z0qtk().RenderMode = DocumentRenderMode.Paint;
			}
			if (flag)
			{
				item.z0juk();
			}
			else if (!item.z0mzk)
			{
				item.z0vek(p0: false);
			}
			item.z0srk(p0: false);
		}
		try
		{
			z0ZzZzerj z0ZzZzerj2 = z0ZzZzclh2.z0eek();
			for (int num = z0ZzZzerj2.Count - 1; num > 0; num--)
			{
				if (z0ZzZzerj2[num].z0ark())
				{
					z0ZzZzerj2.RemoveAt(num);
				}
			}
			for (int num2 = z0ZzZzerj2.Count - 1; num2 > 0; num2--)
			{
				z0ZzZzerj2[num2].z0eek(num2);
			}
			IList<z0ZzZzwrj> list = z0tek(z0ZzZzerj2);
			if (p1 != null)
			{
				p1.z0rek(xTextDocument.z0ipk().z0zek());
				p1.z0eek("DCWriter");
			}
			Dictionary<XPageSettings, byte[]> dictionary3 = new Dictionary<XPageSettings, byte[]>();
			XTextDocument xTextDocument2 = null;
			for (int i = 0; i < list.Count; i++)
			{
				p0.z0zek();
				z0ZzZzwrj z0ZzZzwrj2 = list[i];
				z0ZzZzarj z0ZzZzarj2 = new z0ZzZzarj(z0ZzZzwrj2, p1: true);
				XTextDocument xTextDocument3 = (XTextDocument)z0ZzZzwrj2.z0srk();
				z0ZzZzvxj2.z0eek(xTextDocument3);
				xTextDocument3.z0qtk().RenderMode = DocumentRenderMode.PDF;
				if (xTextDocument3 != xTextDocument2 && p1.z0iek() != null)
				{
					xTextDocument2 = xTextDocument3;
					p1.z0iek().z0xhk(xTextDocument3.ID, xTextDocument3.z0ipk().z0trk(), "DCWriter" + XTextDocument.z0srk(), xTextDocument3.z0zrk(), xTextDocument3.z0ipk().z0nrk(), xTextDocument3.z0ipk().z0wrk(), null);
					if (z0ZzZzbej.z0yek)
					{
						p1.z0iek().z0zhk("dcwriter-native.xml", dictionary2[xTextDocument3]);
					}
				}
				XPageSettings xPageSettings = z0ZzZzwrj2.z0trk();
				if (p1 != null)
				{
					p1.z0eek(GraphicsUnit.Document);
					p1.z0eek(z0ZzZzarj2.z0xek(), z0ZzZzarj2.z0nek());
				}
				if (p1 != null && xPageSettings.z0eek(z0ZzZzwrj2.z0brk(), p1: true) && z0nek_jiejie20260327142557 != null)
				{
					int num3 = z0ZzZzclh2.IndexOf(xTextDocument3);
					if (num3 >= 0 && num3 < z0nek_jiejie20260327142557.Length && z0nek_jiejie20260327142557[num3] != null)
					{
						z0ZzZzrfh z0ZzZzrfh2 = z0nek_jiejie20260327142557[num3];
						p1.z0eek(z0ZzZzrfh2, new z0ZzZzbdh(0f, 0f, z0ZzZzarj2.z0xek(), z0ZzZzarj2.z0nek()), z0ZzZzrfh2.z0eek());
					}
				}
				if (p1 != null)
				{
					p1.z0rek(0f, 0f);
				}
				else
				{
					p0.z0rek(0f, 0f);
				}
				z0ZzZzwrj2.z0eek(i);
				xTextDocument3.z0bek(z0ZzZzerj2);
				xTextDocument3.z0bek(z0ZzZzwrj2);
				z0ZzZzvxj2.z0rek(z0ZzZzwrj2.z0brk());
				z0ZzZzvxj2.z0eek(z0ZzZzerj2.Count);
				z0ZzZzvxj2.z0eek(z0ZzZzwrj2);
				float num4 = 0f;
				bool flag2 = true;
				if (!xPageSettings.z0eek(z0ZzZzwrj2.z0brk()))
				{
					flag2 = false;
				}
				XTextDocumentContentElement xTextDocumentContentElement = (z0ZzZzwrj2.z0yek() ? ((XTextDocumentContentElement)xTextDocument3.z0cyk()) : ((XTextDocumentContentElement)xTextDocument3.z0pyk()));
				XTextDocumentContentElement xTextDocumentContentElement2 = (z0ZzZzwrj2.z0yek() ? ((XTextDocumentContentElement)xTextDocument3.z0guk()) : ((XTextDocumentContentElement)xTextDocument3.z0lik()));
				if (xPageSettings.z0mek())
				{
					if (p1 != null)
					{
						p1.z0rek(0f - xTextDocument3.z0it() + z0ZzZzarj2.z0bek(), 0f - xTextDocument3.z0yt() + z0ZzZzarj2.z0vek());
					}
					else
					{
						p0.z0rek(0f - xTextDocument3.z0it() + z0ZzZzarj2.z0bek(), 0f - xTextDocument3.z0yt() + z0ZzZzarj2.z0vek());
					}
					z0ZzZzvxj2.z0tek(new z0ZzZzbdh(xTextDocument3.z0it(), xTextDocument3.z0yt(), xTextDocument3.Width, xTextDocumentContentElement.Height));
					z0ZzZzvxj2.z0rek(z0ZzZzvxj2.z0drk());
					z0ZzZzvxj2.z0uek(z0ZzZzvxj2.z0drk());
					z0ZzZzvxj2.z0eek(xTextDocumentContentElement);
					z0ZzZzbdh z0ZzZzbdh2 = xTextDocumentContentElement.z0qyk();
					if (flag2 && xTextDocumentContentElement.z0fi())
					{
						xTextDocumentContentElement.z0vw(z0ZzZzvxj2);
						if (xTextDocumentContentElement.z0fi() && xTextDocument3.z0rnk())
						{
							z0ZzZzudh z0ZzZzudh2 = new z0ZzZzudh(Color.Black, xTextDocument3.z0iu().HeaderBottomLineWidth);
							if (p1 != null)
							{
								p1.z0eek(z0ZzZzudh2, z0ZzZzbdh2.z0oek(), z0ZzZzbdh2.z0nek(), z0ZzZzbdh2.z0mek(), z0ZzZzbdh2.z0nek());
							}
							else
							{
								p0.z0eek(z0ZzZzudh2, z0ZzZzbdh2.z0oek(), z0ZzZzbdh2.z0nek(), z0ZzZzbdh2.z0mek(), z0ZzZzbdh2.z0nek());
							}
							z0ZzZzudh2.Dispose();
						}
					}
					num4 = z0ZzZzbdh2.z0nek() + z0ZzZzarj2.z0vek();
				}
				num4 = Math.Max(num4, z0ZzZzarj2.z0pek());
				if (z0ZzZzwrj2.z0krk().z0iek() > 0f)
				{
					if (p1 != null)
					{
						p1.z0rek(0f - xTextDocument3.z0it() + z0ZzZzarj2.z0bek(), 0f - xTextDocument3.z0xyk().z0yt() + num4 - z0ZzZzwrj2.z0krk().z0pek());
					}
					else
					{
						p0.z0rek(0f - xTextDocument3.z0it() + z0ZzZzarj2.z0bek(), 0f - xTextDocument3.z0xyk().z0yt() + num4 - z0ZzZzwrj2.z0krk().z0pek());
					}
					z0ZzZzvxj2.z0eek(xTextDocument3.z0xyk());
					z0ZzZzvxj2.z0tek(new z0ZzZzbdh(xTextDocument3.z0it(), z0ZzZzwrj2.z0krk().z0pek(), xTextDocument3.Width, z0ZzZzwrj2.z0krk().z0iek()));
					z0ZzZzvxj2.z0rek(z0ZzZzvxj2.z0drk());
					z0ZzZzvxj2.z0uek(z0ZzZzvxj2.z0nek());
					z0ZzZzvxj2.z0eek(z0ZzZzwrj2);
					xTextDocument3.z0xyk().z0vw(z0ZzZzvxj2);
					num4 += z0ZzZzwrj2.z0krk().z0iek() + xTextDocument3.z0jrk(XTextTableElement.z0utk);
				}
				z0ZzZzbdh p3 = z0ZzZzbdh.z0xek;
				if (!xTextDocument3.z0xyk().z0xrk())
				{
					p3 = new z0ZzZzbdh(xTextDocument3.z0it(), num4, xTextDocument3.Width, z0ZzZzwrj2.z0xek());
					p3.z0yek(z0ZzZzwrj2.z0urk());
					if (p1 != null)
					{
						p1.z0rek(0f - xTextDocument3.z0it() + z0ZzZzarj2.z0bek(), 0f - xTextDocument3.z0yt() + num4 - z0ZzZzwrj2.z0irk());
					}
					else
					{
						p0.z0rek(0f - xTextDocument3.z0it() + z0ZzZzarj2.z0bek(), 0f - xTextDocument3.z0yt() + num4 - z0ZzZzwrj2.z0irk());
					}
					z0ZzZzvxj2.z0eek(xTextDocument3.z0xyk());
					z0ZzZzvxj2.z0tek(new z0ZzZzbdh(xTextDocument3.z0it(), xTextDocument3.z0yt(), xTextDocument3.Width, xTextDocument3.z0xyk().Height));
					z0ZzZzvxj2.z0rek(new z0ZzZzbdh(xTextDocument3.z0it(), z0ZzZzwrj2.z0irk(), xTextDocument3.Width, z0ZzZzwrj2.z0xek()));
					z0ZzZzbdh p4 = new z0ZzZzbdh(xTextDocument3.z0it(), z0ZzZzwrj2.z0irk(), xTextDocument3.Width, z0ZzZzwrj2.z0urk());
					if (z0ZzZzwrj2.z0krk().z0iek() > 0f)
					{
						p4.z0yek(p4.z0iek() - z0ZzZzwrj2.z0krk().z0iek());
					}
					z0ZzZzvxj2.z0uek(p4);
					z0ZzZzvxj2.z0eek(z0ZzZzwrj2);
					xTextDocument3.z0xyk().z0vw(z0ZzZzvxj2);
				}
				z0ZzZzfpk z0ZzZzfpk2 = xTextDocument3.PageSettings.z0trk();
				if (z0ZzZzfpk2 != null)
				{
					if (i == list.Count - 1)
					{
						if (!string.IsNullOrEmpty(z0ZzZzfpk2.z0mek()))
						{
							z0ZzZzfpk2.z0rek(p1: new z0ZzZzbdh(0f, z0ZzZzwrj2.z0qrk(), z0ZzZzwrj2.z0oek(), z0ZzZzwrj2.z0urk() - z0ZzZzwrj2.z0xek()), p0: z0ZzZzvxj2.z0gyk, p2: z0ZzZzbdh.z0xek);
						}
					}
					else if (!string.IsNullOrEmpty(z0ZzZzfpk2.z0rek()))
					{
						z0ZzZzfpk2.z0eek(p1: new z0ZzZzbdh(0f, z0ZzZzwrj2.z0qrk(), z0ZzZzwrj2.z0oek(), z0ZzZzwrj2.z0urk() - z0ZzZzwrj2.z0xek()), p0: z0ZzZzvxj2.z0gyk, p2: z0ZzZzbdh.z0xek);
					}
				}
				if (xTextDocumentContentElement2.z0fi() && xPageSettings.z0mek())
				{
					float num5 = Math.Max(z0ZzZzarj2.z0mek(), z0ZzZzarj2.z0tek() + z0ZzZzwrj2.z0wrk());
					num5 = 0f - xTextDocument3.z0yt() + z0ZzZzarj2.z0nek() - num5;
					if (p1 != null)
					{
						p1.z0rek(0f - xTextDocument3.z0it() + z0ZzZzarj2.z0bek(), num5);
					}
					else
					{
						p0.z0rek(0f - xTextDocument3.z0it() + z0ZzZzarj2.z0bek(), num5);
					}
					z0ZzZzvxj2.z0tek(new z0ZzZzbdh(xTextDocument3.z0it(), xTextDocument3.z0yt(), xTextDocument3.Width, xTextDocumentContentElement2.Height));
					z0ZzZzvxj2.z0uek(z0ZzZzvxj2.z0drk());
					z0ZzZzvxj2.z0rek(z0ZzZzvxj2.z0drk());
					z0ZzZzvxj2.z0eek(xTextDocumentContentElement2);
					if (flag2)
					{
						xTextDocumentContentElement2.z0vw(z0ZzZzvxj2);
					}
				}
				if (xTextDocument3.PageSettings.z0krk_jiejie20260327142557() != null && xTextDocument3.PageSettings.z0krk_jiejie20260327142557().HasVisibleBorder)
				{
					z0ZzZzbdh p5 = z0ZzZzurj.z0eek(xTextDocument3.PageSettings.z0krk_jiejie20260327142557(), z0ZzZzwrj2, p3);
					if (!p5.z0bek())
					{
						using z0ZzZzudh p6 = xTextDocument3.PageSettings.z0krk_jiejie20260327142557().z0iek();
						if (p1 != null)
						{
							p1.z0rek(0f, 0f);
							p1.z0rek(p6, p5);
						}
						else
						{
							p0.z0rek(0f, 0f);
							p0.z0rek(p6, p5);
						}
					}
				}
				if (z0ZzZzarj2.z0zek() && xPageSettings.z0otk())
				{
					z0ZzZzudh p7 = xPageSettings.z0oek();
					if (p1 != null)
					{
						p1.z0rek(0f, 0f);
						p1.z0eek(p7, z0ZzZzarj2.z0iek(), z0ZzZzarj2.z0eek(), z0ZzZzarj2.z0yek(), z0ZzZzarj2.z0lrk());
					}
					else
					{
						p0.z0rek(0f, 0f);
						p0.z0eek(p7, z0ZzZzarj2.z0iek(), z0ZzZzarj2.z0eek(), z0ZzZzarj2.z0yek(), z0ZzZzarj2.z0lrk());
					}
				}
				if (p1 != null)
				{
					p1.z0rek(0f, 0f);
				}
				else
				{
					p0.z0rek(0f, 0f);
				}
				z0ZzZzvxj2.z0gyk.z0rek();
				z0ZzZzvxj2.z0rek(new z0ZzZzbdh(0f, 0f, z0ZzZzarj2.z0xek(), z0ZzZzarj2.z0nek()));
				DocumentPaintEventArgs e = new DocumentPaintEventArgs(z0ZzZzvxj2);
				e.ViewBounds = new z0ZzZzbdh(0f, 0f, (int)z0ZzZzarj2.z0xek(), (int)z0ZzZzarj2.z0nek());
				e.Bounds = e.ViewBounds;
				e.ClientViewBounds = e.Bounds;
				e.PageClipRectangle = e.ViewBounds;
				e.Element = xTextDocument3;
				bool p8 = z0ZzZzvxj2.z0gyk.z0pek();
				z0ZzZzvxj2.z0gyk.z0rek(p0: false);
				xTextDocument3.z0bek(e);
				z0ZzZzvxj2.z0gyk.z0rek(p8);
				xTextDocument3.z0qtk().RenderMode = DocumentRenderMode.Paint;
			}
			dictionary3?.Clear();
			dictionary2?.Clear();
		}
		finally
		{
			foreach (KeyValuePair<DocumentViewOptions, Color> item2 in dictionary)
			{
				item2.Key.BackgroundTextColor = item2.Value;
			}
			foreach (XTextDocument item3 in z0yek())
			{
				item3.z0srk(p0: false);
				item3.z0qtk().RenderMode = DocumentRenderMode.Paint;
				item3.z0qtk().Printing = false;
				item3.z0bek((z0ZzZzerj)null);
			}
		}
	}

	public void z0rek(Stream p0, Dictionary<byte[], z0ZzZzedh> p1)
	{
		try
		{
			if (z0vek)
			{
				z0ZzZznfh.z0vek = true;
			}
			using z0ZzZzbpk z0ZzZzbpk2 = new z0ZzZzbpk(p0, z0vek);
			z0ZzZzbpk2.z0bek = p1;
			z0ZzZzbpk2.z0eek(z0cek);
			z0cek = false;
			z0ZzZzjpk p2 = z0ZzZzjpk.z0eek(z0ZzZzbpk2);
			z0tek(p2, z0ZzZzbpk2, (z0ZzZzcxj)5);
		}
		finally
		{
			z0ZzZznfh.z0vek = false;
		}
	}

	public z0ZzZzclh z0yek()
	{
		return z0bek;
	}

	public bool z0uek()
	{
		return z0vek;
	}

	public static void z0tek(bool p0)
	{
		z0cek = p0;
	}

	public void z0tek(z0ZzZzclh p0)
	{
		z0bek = p0;
	}

	public List<int> z0iek()
	{
		return z0mek;
	}

	public void z0yek(bool p0)
	{
		z0vek = p0;
	}

	public static bool z0oek()
	{
		return z0cek;
	}

	public void z0tek(z0ZzZzbej p0)
	{
		using z0ZzZzbpk z0ZzZzbpk2 = new z0ZzZzbpk(p0);
		z0vek = true;
		z0ZzZzbpk2.z0eek(z0cek);
		z0cek = false;
		z0ZzZzjpk p1 = z0ZzZzjpk.z0eek(z0ZzZzbpk2);
		z0tek(p1, z0ZzZzbpk2, (z0ZzZzcxj)5);
	}
}
