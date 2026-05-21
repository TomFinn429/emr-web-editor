using System;
using DCSoft.WinForms;
using DCSystem_Drawing;
using zzz;

namespace DCSoft.Writer.Dom;

[z0ZzZziqh("XChart")]
public class XTextChartElement : XTextObjectElement
{
	private new string z0zek;

	private new string z0lrk;

	private new string z0krk;

	[NonSerialized]
	private new bool z0jrk = true;

	[NonSerialized]
	private new z0ZzZzwtk z0hrk;

	private new string z0grk;

	private new DCChartDataItemList z0frk;

	private new string z0drk;

	private new string z0srk;

	private new ResizeableType z0ark = ResizeableType.WidthAndHeight;

	private new z0ZzZzqtk z0qrk = new z0ZzZzqtk();

	private new string z0wrk;

	public new void z0eek(bool p0)
	{
		z0jrk = p0;
	}

	private new z0ZzZzwtk z0eek()
	{
		if (z0hrk == null)
		{
			z0hrk = new z0ZzZzwtk();
			z0eek(p0: true);
		}
		z0hrk.z0eek(z0tek());
		if (z0hrk.z0yek() == null)
		{
			z0hrk.z0eek(new z0ZzZzttk());
		}
		if (z0nek())
		{
			z0eek(p0: false);
			z0hrk.z0yek().Clear();
			z0hrk.z0eek(p0: true);
			if (z0bek() != null && z0bek().Count > 0)
			{
				foreach (DCChartDataItemList item in z0bek().z0eek())
				{
					z0ZzZzrtk z0ZzZzrtk = new z0ZzZzrtk();
					z0hrk.z0yek().Add(z0ZzZzrtk);
					z0ZzZzrtk.z0rek(item.z0rek);
					z0ZzZzrtk.z0eek_jiejie20260327142557(new z0ZzZzutk());
					foreach (DCChartDataItem item2 in item)
					{
						z0ZzZzytk z0ZzZzytk = new z0ZzZzytk();
						z0ZzZzytk.z0rrk = z0ZzZzrtk;
						z0ZzZzytk.z0rek(item2.GroupName);
						z0ZzZzytk.z0eek(item2.ChartStyle);
						z0ZzZzytk.z0eek(item2.Color);
						z0ZzZzytk.z0eek(item2.Value);
						z0ZzZzytk.z0eek(item2.Link);
						z0ZzZzytk.z0eek(item2.SymbolType);
						z0ZzZzytk.z0eek(item2.SymbolSize);
						z0ZzZzytk.z0uek(item2.Text);
						z0ZzZzytk.z0tek(item2.TipText);
						z0ZzZzrtk.z0rek().Add(z0ZzZzytk);
					}
				}
			}
		}
		return z0hrk;
	}

	public void z0eek(string p0)
	{
		z0drk = p0;
	}

	public void z0rek(string p0)
	{
		z0zek = p0;
	}

	internal new virtual bool z0rek()
	{
		return true;
	}

	public new z0ZzZzqtk z0tek()
	{
		if (z0qrk == null)
		{
			z0qrk = new z0ZzZzqtk();
		}
		return z0qrk;
	}

	public new string z0yek()
	{
		return z0wrk;
	}

	public override z0ZzZzpmk z0ny()
	{
		z0ZzZzxdh z0ZzZzxdh = z0ZzZzrpk.z0eek(new z0ZzZzxdh(Width, Height), GraphicsUnit.Document, GraphicsUnit.Pixel);
		z0ZzZzrfh p = new z0ZzZzrfh((int)z0ZzZzxdh.z0rek(), (int)z0ZzZzxdh.z0tek());
		using (z0ZzZzadh z0ZzZzadh = z0ZzZzadh.z0eek(p))
		{
			z0ZzZzadh.z0eek(GraphicsUnit.Document);
			z0ZzZzadh.z0eek(Color.Transparent);
			z0ZzZzbdh z0ZzZzbdh = new z0ZzZzbdh(0f, 0f, Width, Height);
			z0eek(p0: true);
			z0ZzZzwtk z0ZzZzwtk = z0eek();
			z0ZzZzwtk.z0eek(z0ZzZzbdh);
			z0ZzZzwtk.z0eek(p0: true);
			z0ZzZzjpk p2 = new z0ZzZzjpk(z0ZzZzadh);
			z0ZzZzwtk.z0eek(p2);
			z0ZzZzwtk.z0eek(p2, z0ZzZzbdh);
		}
		return new z0ZzZzpmk(p);
	}

	public new string z0uek()
	{
		return z0srk;
	}

	public override void z0et(ResizeableType p0)
	{
		z0ark = p0;
	}

	public override ResizeableType z0wt()
	{
		if (((XTextObjectElement)this).z0yek())
		{
			return ResizeableType.FixSize;
		}
		return z0ark;
	}

	public new string z0iek()
	{
		return z0zek;
	}

	public void z0tek(string p0)
	{
		z0srk = p0;
	}

	public new string z0oek()
	{
		return z0krk;
	}

	public new void z0yek(string p0)
	{
		z0grk = p0;
	}

	public new string z0pek()
	{
		return z0drk;
	}

	public new void z0uek(string p0)
	{
		z0wrk = p0;
	}

	public new string z0mek()
	{
		return z0grk;
	}

	public void z0iek(string p0)
	{
		z0krk = p0;
	}

	public void z0eek(z0ZzZzqtk p0)
	{
		z0qrk = p0;
	}

	public new bool z0nek()
	{
		return z0jrk;
	}

	public new DCChartDataItemList z0bek()
	{
		return z0frk;
	}

	public override void Dispose()
	{
		base.Dispose();
		if (z0hrk != null)
		{
			z0hrk = null;
		}
	}

	public override void z0mu(DocumentEventArgs p0)
	{
		if (p0.Style == DocumentEventStyles.MouseMove && this != null && z0hrk != null)
		{
			z0ZzZzytk z0ZzZzytk = z0hrk.z0eek(p0.ViewX, p0.ViewY);
			if (z0ZzZzytk != null && z0ZzZzytk.z0tek() != null && z0ZzZzytk.z0tek().Length > 0)
			{
				p0.Tooltip = z0ZzZzytk.z0tek();
			}
		}
		base.z0mu(p0);
	}

	public void z0oek(string p0)
	{
		z0tek().z0jrk().z0tek(p0);
	}

	public void z0eek(string p0, string p1, string p2, double p3)
	{
		if (z0frk == null)
		{
			z0frk = new DCChartDataItemList();
		}
		DCChartDataItem dCChartDataItem = new DCChartDataItem();
		dCChartDataItem.SeriesName = p0;
		dCChartDataItem.GroupName = p1;
		dCChartDataItem.Text = p2;
		dCChartDataItem.Value = p3;
		z0frk.Add(dCChartDataItem);
		z0jrk = true;
	}

	public override void z0vw(z0ZzZzvxj p0)
	{
		z0ZzZzwtk z0ZzZzwtk = z0eek();
		if (z0ZzZzbdh.z0rek(z0ZzZzwtk.z0pek(), p0.z0drk()))
		{
			z0ZzZzwtk.z0eek(p0.z0drk());
			z0ZzZzwtk.z0eek(p0: true);
		}
		if (z0ZzZzwtk.z0iek() || z0nek())
		{
			z0ZzZzwtk.z0eek(p0.z0gyk);
		}
		if (p0.z0duk != null)
		{
			z0ZzZzbdh z0ZzZzbdh = p0.z0gtk;
			if (!p0.z0nek().z0bek())
			{
				z0ZzZzbdh = z0ZzZzbdh.z0tek(z0ZzZzbdh, p0.z0nek());
			}
			z0ZzZzbdh.z0rek(1f, 1f);
			z0ZzZzrzj z0ZzZzrzj = z0aek();
			p0.z0duk.z0mhk(ID, z0ZzZzbdh, z0ZzZzrzj.z0tyk, z0ZzZzrzj.z0wtk, z0ZzZzrzj.z0prk, p5: true);
			p0.z0duk.z0whk();
			z0ZzZzwtk.z0eek(p0.z0gyk, p0.z0nek());
			p0.z0duk.z0thk();
		}
		else
		{
			z0ZzZzwtk.z0eek(p0.z0gyk, p0.z0nek());
		}
	}

	public XTextChartElement()
	{
		Width = 400f;
		Height = 400f;
		z0tek().z0erk().z0rek(50f);
		z0tek().z0nek(180);
		z0tek().z0vek(30);
		z0tek().z0pek(100);
		z0tek().z0bek(30);
		z0tek().z0jrk().z0eek(120f);
		z0tek().z0jrk().z0eek(p0: true);
	}

	public void z0eek(DCChartDataItemList p0)
	{
		z0frk = p0;
	}

	public void z0pek(string p0)
	{
		z0lrk = p0;
	}

	public override XTextElement z0lr(bool p0)
	{
		XTextChartElement obj = (XTextChartElement)base.z0lr(p0);
		obj.z0hrk = null;
		obj.z0eek(p0: true);
		return obj;
	}

	public new void z0vek()
	{
		z0eek("序列1", "类别1", "43", 43.0);
		z0eek("序列1", "类别2", "25", 25.0);
		z0eek("序列1", "类别3", "35", 35.0);
		z0eek("序列1", "类别4", "45", 45.0);
		z0eek("序列2", "类别1", "24", 24.0);
		z0eek("序列2", "类别2", "44", 44.0);
		z0eek("序列2", "类别3", "18", 18.0);
		z0eek("序列2", "类别4", "28", 28.0);
		z0eek("序列3", "类别1", "20", 20.0);
		z0eek("序列3", "类别2", "20", 20.0);
		z0eek("序列3", "类别3", "30", 30.0);
		z0eek("序列3", "类别4", "50", 50.0);
	}

	public new string z0cek()
	{
		return z0lrk;
	}

	public new string z0xek()
	{
		return z0tek().z0jrk().z0iek();
	}
}
