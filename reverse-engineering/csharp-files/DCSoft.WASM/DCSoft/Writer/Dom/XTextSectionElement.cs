using System;
using System.ComponentModel;
using System.Diagnostics;
using DCSystem_Drawing;
using zzz;

namespace DCSoft.Writer.Dom;

[z0ZzZziqh("XTextSection")]
[DebuggerDisplay("Section {ID}:{ PreviewString }")]
public class XTextSectionElement : XTextContentElement, z0ZzZztxj
{
	private class z0jhj : z0ZzZzhxj
	{
		public override void z0dj(WriterMouseEventArgs p0)
		{
			if (p0.Button == (z0ZzZzqeh)1 && z0eek(p0.X, p0.Y))
			{
				p0.Handled = true;
				XTextSectionElement xTextSectionElement = (XTextSectionElement)z0nek();
				if (xTextSectionElement.IsCollapsed)
				{
					xTextSectionElement.Expand();
				}
				else
				{
					xTextSectionElement.Collapse();
				}
				xTextSectionElement.z0sr();
			}
		}

		public z0jhj(XTextSectionElement p0)
		{
			z0eek(z0ZzZzbwh.z0krk);
			z0eek(p0);
			z0ZzZzbdh z0ZzZzbdh = p0.z0qyk();
			if (p0.z0rek())
			{
				z0eek(p0.z0jr().z0mnk().BmpCollapse);
			}
			else
			{
				z0eek(p0.z0jr().z0mnk().BmpExpand);
			}
			z0tek(z0ZzZzrpk.z0eek(z0tek().z0iek(), GraphicsUnit.Pixel, GraphicsUnit.Document));
			z0eek(z0pek());
			z0rek(z0ZzZzbdh.z0oek() - z0pek());
			z0yek(z0ZzZzbdh.z0pek() + 10f);
			z0eek(p0.Title);
			z0eek(z0ZzZzbwh.z0krk);
		}
	}

	public class z0jpk
	{
		private Color z0tek = Color.Black;

		private string z0yek;

		public void z0eek(string p0)
		{
			z0yek = p0;
		}

		public string z0eek()
		{
			return z0yek;
		}

		public Color z0rek()
		{
			return z0tek;
		}

		public void z0eek(Color p0)
		{
			z0tek = p0;
		}
	}

	public delegate void z0gpk(int pageIndex, XTextSectionElement element, int left, int top, int width, int height);

	internal new static bool z0oek = false;

	internal new static bool z0pek = false;

	internal new static bool z0mek = false;

	private new float z0nek;

	private new string z0bek;

	private new static readonly Color z0vek = Color.FromArgb(128, 128, 128);

	private new bool z0cek;

	public new static z0gpk z0xek = null;

	private new string z0zek;

	[NonSerialized]
	private new z0ZzZzkcj z0lrk;

	internal new static bool z0krk = false;

	private new Color z0jrk = z0vek;

	[DefaultValue(false)]
	public bool InsertEmptyPageForNewPage
	{
		get
		{
			return z0cek;
		}
		set
		{
			z0cek = value;
		}
	}

	[DefaultValue(false)]
	[z0ZzZzbjh]
	public bool IsCollapsed
	{
		get
		{
			return z0iyk();
		}
		set
		{
			z0qrk(value);
		}
	}

	[DefaultValue(false)]
	public bool NewPage
	{
		get
		{
			return z0dtk();
		}
		set
		{
			z0prk(value);
			if (value)
			{
				XTextDocument.z0pbk = true;
			}
		}
	}

	[DefaultValue(0f)]
	[z0ZzZzbjh(MemberEffectLevel.DocumentLayout)]
	public float SpecifyHeight
	{
		get
		{
			return z0nek;
		}
		set
		{
			z0nek = value;
		}
	}

	[DefaultValue(null)]
	[z0ZzZzbjh]
	public string Title
	{
		get
		{
			return z0bek;
		}
		set
		{
			z0bek = value;
		}
	}

	[DefaultValue(true)]
	public bool ExpendForDataBinding
	{
		get
		{
			return z0zyk();
		}
		set
		{
			z0wrk(value);
		}
	}

	[DefaultValue(null)]
	public string ForeColorValueForCollapsed
	{
		get
		{
			return z0ZzZzlok.z0eek(ForeColorForCollapsed, Color.FromArgb(128, 128, 128));
		}
		set
		{
			ForeColorForCollapsed = z0ZzZzlok.z0eek(value, Color.FromArgb(128, 128, 128));
		}
	}

	[DefaultValue(true)]
	[z0ZzZzbjh]
	public override bool AcceptTab
	{
		get
		{
			return base.AcceptTab;
		}
		set
		{
			base.AcceptTab = value;
		}
	}

	[z0ZzZzuqh]
	[z0ZzZzbjh]
	public Color ForeColorForCollapsed
	{
		get
		{
			return z0jrk;
		}
		set
		{
			z0jrk = value;
		}
	}

	[z0ZzZzbjh(MemberEffectLevel.DocumentLayout)]
	[DefaultValue(false)]
	public virtual bool CompressOwnerLineSpacing
	{
		get
		{
			return z0syk();
		}
		set
		{
			z0cek(value);
		}
	}

	[z0ZzZzbjh]
	[DefaultValue(false)]
	public bool EnableCollapse
	{
		get
		{
			return z0luk();
		}
		set
		{
			z0nrk(value);
		}
	}

	[DefaultValue(null)]
	[z0ZzZzbjh]
	public string Name
	{
		get
		{
			return z0zek;
		}
		set
		{
			z0zek = value;
		}
	}

	public override string z0ge()
	{
		return "Section:" + ID + " " + Title;
	}

	internal static z0eok_jiejie20260327142557 z0eek(XTextContainerElement p0, z0eok_jiejie20260327142557 p1)
	{
		if (z0eek(p0))
		{
			return new z0eok_jiejie20260327142557(p1, p1: true)
			{
				z0rek = true
			};
		}
		return p1;
	}

	public override XTextElement z0hy()
	{
		if (z0rek())
		{
			return this;
		}
		return base.z0ie();
	}

	public virtual string z0zr()
	{
		return null;
	}

	public override XTextElement z0dek()
	{
		return this;
	}

	private new int z0eek(XTextElementList p0)
	{
		int num = 0;
		for (int num2 = p0.Count - 1; num2 >= 0; num2--)
		{
			if (p0[num2] is XTextSectionElement)
			{
				XTextSectionElement xTextSectionElement = (XTextSectionElement)p0[num2];
				p0.z0bek(num2);
				p0.z0eek(num2, xTextSectionElement.z0be());
				num++;
			}
			else if (p0[num2] is XTextContainerElement)
			{
				num += z0eek(p0[num2].z0be());
			}
		}
		return num;
	}

	public override XTextElement z0ie()
	{
		return this;
	}

	internal new static bool z0eek(XTextElement p0)
	{
		if (z0krk && z0mek)
		{
			for (XTextElement xTextElement = p0; xTextElement != null; xTextElement = xTextElement.z0ji())
			{
				if (xTextElement is XTextSectionElement && ((XTextSectionElement)xTextElement).z0sek())
				{
					return true;
				}
			}
		}
		return false;
	}

	public XTextSectionElement()
	{
		AcceptTab = true;
		ExpendForDataBinding = true;
		z0mek = true;
	}

	public bool z0eek()
	{
		if (!EnableCollapse)
		{
			return false;
		}
		return ((XTextElement)this).z0drk()?.z0bu().EnableCollapseSection ?? true;
	}

	public override string z0gy()
	{
		if (z0be().Count == 0)
		{
			return Title;
		}
		string text = Text;
		if (!string.IsNullOrEmpty(text))
		{
			text += Environment.NewLine;
		}
		return text;
	}

	internal override bool z0ae()
	{
		if (z0rek())
		{
			return false;
		}
		return base.z0ae();
	}

	public override XTextContentElement z0jy()
	{
		XTextElement xTextElement = this;
		if (z0rek())
		{
			xTextElement = z0ji();
		}
		while (xTextElement != null)
		{
			if (xTextElement is XTextContentElement)
			{
				return (XTextContentElement)xTextElement;
			}
			xTextElement = xTextElement.z0ji();
		}
		return null;
	}

	private bool z0eek(z0ZzZzvxj p0, z0ZzZzbdh p1)
	{
		if (p0.z0byk == (z0ZzZzcxj)0)
		{
			DocumentViewOptions documentViewOptions = z0iu();
			if (documentViewOptions.ShowCellNoneBorder)
			{
				z0ZzZzrzj z0ZzZzrzj = z0aek();
				if (!z0ZzZzrzj.z0rrk || !z0ZzZzrzj.z0wyk || !z0ZzZzrzj.z0etk || !z0ZzZzrzj.z0mrk)
				{
					using (z0ZzZzudh p2 = new z0ZzZzudh(documentViewOptions.NoneBorderColor))
					{
						bool p3 = !z0ZzZzrzj.z0rrk;
						bool p4 = !z0ZzZzrzj.z0wyk;
						bool p5 = !z0ZzZzrzj.z0etk;
						bool p6 = !z0ZzZzrzj.z0mrk;
						if (z0ZzZzbdh.z0tek(p1, p0.z0nek()).z0iek() < 6f && p0.z0lrk() != null && p1.z0pek() - p0.z0lrk().z0irk() < 1f)
						{
							return true;
						}
						z0ZzZzbdh z0ZzZzbdh = p0.z0gyk.z0lrk().z0irk;
						p0.z0gyk.z0lrk().z0irk = z0ZzZzbdh.z0xek;
						z0ZzZzcok.z0eek(p0.z0gyk, p2, p1, p3, p4, p5, p6);
						p0.z0gyk.z0lrk().z0irk = z0ZzZzbdh;
						return true;
					}
				}
			}
		}
		return false;
	}

	internal static void z0eek(bool p0)
	{
		z0oek = p0;
	}

	public bool z0rek()
	{
		if (IsCollapsed && z0eek())
		{
			return true;
		}
		return false;
	}

	public override bool z0ky()
	{
		return z0eek();
	}

	public override string z0hu()
	{
		string text = ID;
		if (string.IsNullOrEmpty(Title))
		{
			text = text + " " + Title + " ";
		}
		return text + base.z0hu();
	}

	public override bool z0hr()
	{
		if (z0rek())
		{
			z0qek().z0sr();
			return z0qek().z0uek(((XTextElement)this).z0jrk(), 1);
		}
		if (z0be().Count == 0)
		{
			return false;
		}
		int p = z0be().z0grk().z0jrk();
		int p2 = z0be().z0lrk().z0jrk();
		z0qek().z0sr();
		return z0qek().z0tek(p, p2);
	}

	internal new bool z0tek()
	{
		return z0otk();
	}

	public override string z0pe()
	{
		return "section";
	}

	public new z0ZzZzkcj z0yek()
	{
		if (z0lrk == null || z0lrk.z0tek() != this)
		{
			z0lrk = new z0ZzZzkcj(this);
		}
		return z0lrk;
	}

	public override void z0sr()
	{
		if (z0jr() == null || z0fek())
		{
			return;
		}
		XTextElement xTextElement = z0trk().z0grk();
		if (z0rek())
		{
			xTextElement = this;
		}
		if (xTextElement is XTextTableElement)
		{
			XTextTableElement xTextTableElement = (XTextTableElement)xTextElement;
			if (xTextTableElement.z0zrk() != null)
			{
				xTextElement = xTextTableElement.z0zrk().z0ie();
			}
		}
		if (xTextElement != null)
		{
			XTextDocumentContentElement xTextDocumentContentElement = z0qek();
			if (z0jr().z0jrk() != xTextDocumentContentElement)
			{
				xTextDocumentContentElement.z0sr();
			}
			xTextDocumentContentElement.z0uek(xTextElement.z0jrk(), 0);
			if (z0jr().z0yyk() != null)
			{
				z0jr().z0yyk().z0syk();
			}
		}
	}

	public virtual bool Collapse()
	{
		if (z0eek() && !IsCollapsed)
		{
			if (z0cu() != null)
			{
				WriterSectionElementCancelEventArgs e = new WriterSectionElementCancelEventArgs(z0cu(), z0jr(), this);
				z0cu().z0eek(e);
				if (e.Cancel)
				{
					return false;
				}
			}
			IsCollapsed = true;
			z0grk();
			foreach (XTextElement item in new z0ZzZzkxj(z0be())
			{
				ExcludeCharElement = false,
				ExcludeParagraphFlag = false
			})
			{
				item.z0tuk = -1;
			}
			if (z0jr().z0dtk() == (z0ZzZzzcj)3)
			{
				using (z0ZzZzjpk p = z0ru())
				{
					z0ZzZzvxj z0ZzZzvxj = z0jr().z0bek(p, (z0ZzZzcxj)0);
					z0ZzZzvxj.z0hyk = this;
					z0mr(z0ZzZzvxj);
				}
				z0qek().z0bek(p0: true);
				z0nek(p0: false);
				if (z0cu() != null)
				{
					WriterSectionElementEventArgs p2 = new WriterSectionElementEventArgs(z0cu(), z0jr(), this);
					z0cu().z0eek(p2);
				}
			}
			return true;
		}
		return false;
	}

	public virtual bool Expand()
	{
		if (z0eek() && IsCollapsed)
		{
			if (z0cu() != null)
			{
				WriterSectionElementCancelEventArgs e = new WriterSectionElementCancelEventArgs(z0cu(), z0jr(), this);
				z0cu().z0rek(e);
				if (e.Cancel)
				{
					return false;
				}
			}
			z0lt();
			IsCollapsed = false;
			z0uu(p0: false);
			if (z0cu() != null)
			{
				WriterSectionElementEventArgs p = new WriterSectionElementEventArgs(z0cu(), z0jr(), this);
				z0cu().z0rek(p);
				z0cu().z0kpk();
			}
			return true;
		}
		return false;
	}

	public new bool z0uek()
	{
		if (z0krk && z0sek())
		{
			return true;
		}
		return false;
	}

	public override void z0fy(z0ZzZzdxj p0)
	{
		p0.z0iek();
		base.z0fy(p0);
	}

	public override void z0nw(z0ZzZzuzj p0)
	{
		base.z0nw(p0);
		p0.z0eek(z0zek);
		p0.z0eek(z0bek);
	}

	internal new void z0rek(bool p0)
	{
		z0lrk(p0);
	}

	public override void z0ly()
	{
		if (SpecifyHeight < 0f)
		{
			Height = 0f - SpecifyHeight;
		}
		else if (SpecifyHeight > 0f)
		{
			Height = Math.Max(SpecifyHeight, z0hrk());
		}
		else
		{
			base.z0ly();
		}
	}

	internal new int z0iek()
	{
		return z0eek(z0be());
	}

	public override void z0mr(z0ZzZzvxj p0)
	{
		Width = z0jr().z0xyk().Width;
		if (z0rek())
		{
			z0ZzZzimk p1 = z0jr().z0vmk();
			Height = z0ZzZzlcj.z0rek(p0.z0itk_jiejie20260327142557, p1) + 10f;
		}
		else
		{
			base.z0mr(p0);
		}
	}

	internal override bool z0zt(z0ZzZzazj p0)
	{
		bool flag = false;
		if (z0uek())
		{
			z0kgj z0kgj = z0kgj.z0eek(z0jr(), p1: true);
			z0kgj.z0rek = true;
			z0ze(z0kgj);
			if (z0utk != null)
			{
				z0utk.z0frk();
			}
			flag = base.z0zt(p0);
		}
		else
		{
			flag = base.z0zt(p0);
		}
		if (Height != z0hrk())
		{
			Height = z0hrk();
			if (z0ptk() != null)
			{
				z0ptk().z0tek(p0: true);
			}
		}
		return flag;
	}

	public override XTextElement z0xt()
	{
		if (z0rek())
		{
			return this;
		}
		return base.z0dek();
	}

	public override void z0ct()
	{
		z0nek(p0: false);
		if (!z0eek() || !IsCollapsed)
		{
			if (z0bu().ParagraphFlagFollowTableOrSection)
			{
				Width = z0jr().z0xyk().Width - 10f;
			}
			else
			{
				Width = z0jr().z0xyk().Width;
			}
			base.z0ct();
		}
	}

	public virtual z0jpk z0kt_jiejie20260327142557()
	{
		z0jpk z0jpk = new z0jpk();
		string text = Title;
		if (string.IsNullOrEmpty(text))
		{
			text = Text;
			if (text != null && text.Length > 100)
			{
				text = text.Substring(0, 100);
			}
		}
		z0jpk.z0eek(text);
		z0jpk.z0eek(ForeColorForCollapsed);
		return z0jpk;
	}

	public override int z0ue(z0eok_jiejie20260327142557 p0)
	{
		if (z0rek())
		{
			return 0;
		}
		if (z0uek())
		{
			z0eok_jiejie20260327142557 z0eok_jiejie20260327142557 = new z0eok_jiejie20260327142557(p0, p1: true);
			z0eok_jiejie20260327142557.z0rek = true;
			int result = base.z0ue(z0eok_jiejie20260327142557);
			p0.z0cek = z0eok_jiejie20260327142557.z0cek;
			p0.z0uek = z0eok_jiejie20260327142557.z0uek;
			p0.z0zek = z0eok_jiejie20260327142557.z0zek;
			z0eok_jiejie20260327142557.Dispose();
			return result;
		}
		return base.z0ue(p0);
	}

	public override void z0tt(z0ZzZzvxj p0)
	{
		XTextDocument xTextDocument = z0jr();
		if (z0rek())
		{
			z0jpk z0jpk = z0kt_jiejie20260327142557();
			z0ZzZzbdh p1 = p0.z0gtk;
			if (!string.IsNullOrEmpty(z0jpk.z0eek()))
			{
				using z0ZzZzlsh z0ZzZzlsh = new z0ZzZzlsh();
				z0ZzZzlsh.z0rek(StringAlignment.Near);
				z0ZzZzlsh.z0eek(StringAlignment.Center);
				z0ZzZzlsh.z0eek((z0ZzZzksh)4096);
				p0.z0gyk.z0eek(z0jpk.z0eek(), xTextDocument.z0vmk(), z0jpk.z0rek(), new z0ZzZzbdh(p1.z0oek(), p1.z0pek() + 6f, p1.z0uek(), p1.z0iek()), z0ZzZzlsh);
			}
			using (z0ZzZzudh p2 = new z0ZzZzudh(z0jpk.z0rek()))
			{
				p0.z0gyk.z0rek(p2, p1);
			}
			xTextDocument.z0frk(p1.z0nek());
			return;
		}
		DocumentViewOptions documentViewOptions = xTextDocument.z0iu();
		z0ZzZzbdh z0ZzZzbdh = p0.z0gtk;
		z0ZzZzbdh z0ZzZzbdh2 = z0ZzZzbdh;
		if (!p0.z0hrk().z0bek())
		{
			z0ZzZzbdh2.z0nek();
			z0ZzZzbdh2 = z0ZzZzbdh.z0tek(p0.z0hrk(), z0ZzZzbdh);
			p0.z0hrk().z0nek();
		}
		if (p0.z0pyk)
		{
			p0.z0yyk.z0eek(this, p0);
		}
		bool flag = false;
		if (documentViewOptions.ShowGridLine)
		{
			flag = true;
			if ((p0.z0byk == (z0ZzZzcxj)3 || p0.z0byk == (z0ZzZzcxj)2) && !documentViewOptions.PrintGridLine)
			{
				flag = false;
			}
		}
		bool flag2 = z0eek(p0, z0ZzZzbdh2);
		if (z0uek())
		{
			z0eek(p0: true);
			z0ZzZzvxj p3 = new z0ZzZzvxj(p0, (z0ZzZzcxj)2);
			z0vw(p3);
		}
		else
		{
			z0vw(p0);
		}
		if (p0.z0byk == (z0ZzZzcxj)3 && z0xek != null)
		{
			z0ZzZzbej z0ZzZzbej = p0.z0gyk.z0uek().z0iek();
			if (z0ZzZzbej != null)
			{
				z0ZzZzndh z0ZzZzndh = z0ZzZzbej.z0shk(z0ZzZzbdh2.z0oek(), z0ZzZzbdh2.z0pek(), z0ZzZzbdh2.z0uek(), z0ZzZzbdh2.z0iek());
				z0xek(p0.z0oek(), this, z0ZzZzndh.z0pek(), z0ZzZzndh.z0mek(), z0ZzZzndh.z0iek(), z0ZzZzndh.z0oek());
			}
		}
		if (flag)
		{
			z0ZzZzbdh p4 = (p0.z0gtk = z0qyk());
			p0.z0tek(z0aek().z0eek(p4));
			z0eek(p0, documentViewOptions.GridLineColor, p2: false, p3: true, p4: true, documentViewOptions.SpecifyExtenGridLineStep, 0f, 0f, documentViewOptions.GridLineStyle, p9: false);
		}
		base.z0xek(p0);
		if (p0.z0eek(documentViewOptions.SectionBorderVisibility))
		{
			z0ZzZzbdh p5 = z0ZzZzbdh.z0tek(z0ZzZzbdh2, p0.z0nek());
			if (p5.z0iek() > 10f)
			{
				object p6 = p0.z0gyk.z0bek();
				p0.z0gyk.z0rek();
				p0.z0yyk.z0rek(this, p0, z0ZzZzbdh2);
				p0.z0gyk.z0eek(p6);
				if (z0aek().z0xek)
				{
					z0jr().z0frk(p5.z0nek());
				}
				if (!flag2)
				{
					z0eek(p0, p5);
				}
			}
		}
		if (!z0pek || p0.z0byk != 0 || !z0sek())
		{
			return;
		}
		z0ZzZzbdh p7 = z0ZzZzbdh;
		if (!p0.z0nek().z0bek())
		{
			p7 = z0ZzZzbdh.z0tek(p7, p0.z0nek());
			if (!p7.z0bek())
			{
				p0.z0gyk.z0rek(new z0ZzZzzdh(Color.FromArgb(140, 255, 255, 255)), p7);
			}
		}
	}

	public virtual void z0lt()
	{
	}

	public override z0ZzZzhxj z0vt()
	{
		if (z0eek())
		{
			return new z0jhj(this);
		}
		return null;
	}
}
