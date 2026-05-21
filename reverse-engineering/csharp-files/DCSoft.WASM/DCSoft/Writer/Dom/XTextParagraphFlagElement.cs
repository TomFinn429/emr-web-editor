using System;
using System.Collections.Generic;
using System.Text;
using DCSoft.Drawing;
using DCSystem_Drawing.Drawing2D;
using zzz;

namespace DCSoft.Writer.Dom;

[z0ZzZziqh("XParagraphFlag")]
public sealed class XTextParagraphFlagElement : XTextElement
{
	internal class z0vxk
	{
		public XTextParagraphFlagElement z0tek;

		public int z0yek;

		public XTextParagraphListItemElement z0uek;

		public int z0iek = -1;

		public int z0oek = -1;

		public int z0pek;

		public float z0mek = 1f;

		public List<XTextParagraphFlagElement> z0nek_jiejie20260327142557;

		public int z0bek = -1;

		public void z0eek()
		{
			z0uek = null;
			z0tek = null;
			if (z0nek_jiejie20260327142557 != null)
			{
				z0nek_jiejie20260327142557.Clear();
				z0nek_jiejie20260327142557 = null;
			}
		}

		public z0vxk z0rek()
		{
			z0vxk obj = (z0vxk)MemberwiseClone();
			obj.z0uek = null;
			obj.z0tek = null;
			obj.z0nek_jiejie20260327142557 = null;
			return obj;
		}
	}

	internal new z0vxk z0grk;

	private new bool z0frk = true;

	[NonSerialized]
	private new XTextElement z0srk;

	[z0ZzZzuqh]
	public override bool Visible
	{
		get
		{
			return z0frk;
		}
		set
		{
			z0frk = value;
		}
	}

	[z0ZzZzuqh]
	public override string Text
	{
		get
		{
			return Environment.NewLine;
		}
		set
		{
		}
	}

	public int z0eek()
	{
		if (z0grk != null)
		{
			return z0grk.z0oek;
		}
		return -1;
	}

	public override XTextElement z0hy()
	{
		return this;
	}

	internal XTextParagraphFlagElement z0rek()
	{
		return z0grk?.z0tek;
	}

	public int z0tek()
	{
		return z0aek()?.z0ttk ?? (-1);
	}

	public override int z0je()
	{
		z0ZzZzzlh z0ZzZzzlh = z0ptk();
		if (z0ZzZzzlh != null && z0ZzZzzlh.z0dtk() != null)
		{
			if (z0jr() == null)
			{
				return z0ZzZzzlh.z0dtk().z0brk();
			}
			return z0jr().z0suk().IndexOf(z0ZzZzzlh.z0dtk());
		}
		return -1;
	}

	public override XTextElement z0ie()
	{
		if (z0srk == null)
		{
			return this;
		}
		return z0srk;
	}

	internal new ParagraphListStyle z0yek()
	{
		return z0aek()?.z0brk ?? ParagraphListStyle.None;
	}

	public override XTextParagraphFlagElement z0dy()
	{
		return this;
	}

	public override void z0tt(z0ZzZzvxj p0)
	{
		if (p0.z0byk == (z0ZzZzcxj)0)
		{
			p0.z0yyk.z0eek(this, p0, p0.z0gtk);
			z0ZzZzrfh z0ZzZzrfh = null;
			z0ZzZzbdh z0ZzZzbdh = p0.z0gtk;
			z0ZzZzrfh = p0.z0utk;
			p0.z0rek(InterpolationMode.NearestNeighbor);
			XTextDocument.z0axk = true;
			p0.z0gyk.z0eek(z0ZzZzrfh, z0ZzZzbdh.z0oek(), z0ZzZzbdh.z0nek() - p0.z0srk.z0tek());
			XTextDocument.z0axk = false;
		}
	}

	internal new z0vxk z0uek()
	{
		if (z0grk == null)
		{
			z0grk = new z0vxk();
		}
		return z0grk;
	}

	public new XTextElement z0iek()
	{
		return z0srk;
	}

	public new int z0oek()
	{
		if (z0grk != null)
		{
			return z0grk.z0yek;
		}
		return 0;
	}

	internal new float z0pek()
	{
		if (z0grk != null)
		{
			return z0grk.z0mek;
		}
		return 1f;
	}

	public void z0eek(XTextElement p0)
	{
		z0srk = p0;
	}

	internal void z0eek(XTextParagraphFlagElement p0)
	{
		List<XTextParagraphFlagElement> list = z0uek().z0nek_jiejie20260327142557;
		if (list == null)
		{
			list = new List<XTextParagraphFlagElement>();
			z0grk.z0nek_jiejie20260327142557 = list;
		}
		list.Add(p0);
		p0.z0uek().z0tek = this;
	}

	public override void z0fy(z0ZzZzdxj p0)
	{
		p0.z0rek();
	}

	internal new bool z0mek()
	{
		return z0yrk();
	}

	public new bool z0nek()
	{
		List<XTextParagraphFlagElement> list = z0grk?.z0nek_jiejie20260327142557;
		if (list != null)
		{
			return list.Count > 0;
		}
		return false;
	}

	public new List<XTextParagraphFlagElement> z0bek()
	{
		return z0grk?.z0nek_jiejie20260327142557;
	}

	public override float z0lu()
	{
		return XTextDocument.z0jxk;
	}

	public void z0eek(int p0)
	{
		if (p0 == -1)
		{
			if (z0grk != null)
			{
				z0grk.z0oek = p0;
			}
		}
		else
		{
			z0uek().z0oek = p0;
		}
	}

	public void z0rek(int p0)
	{
		if (p0 == 0)
		{
			if (z0grk != null)
			{
				z0grk.z0yek = p0;
			}
		}
		else
		{
			z0uek().z0yek = p0;
		}
	}

	public override string z0ge()
	{
		if (z0aek() == null)
		{
			return "<P>";
		}
		return "<P>" + z0aek().z0tuk;
	}

	internal void z0eek(float p0)
	{
		if (p0 == 1f)
		{
			if (z0grk != null)
			{
				z0grk.z0mek = p0;
			}
		}
		else
		{
			z0uek().z0mek = p0;
		}
	}

	public override XTextElement z0lr(bool p0)
	{
		XTextParagraphFlagElement xTextParagraphFlagElement = (XTextParagraphFlagElement)base.z0lr(p0);
		if (z0grk != null)
		{
			xTextParagraphFlagElement.z0grk = z0grk.z0rek();
		}
		if (xTextParagraphFlagElement.z0grk != null)
		{
			xTextParagraphFlagElement.z0grk.z0bek = -1;
			xTextParagraphFlagElement.z0grk.z0oek = -1;
		}
		return xTextParagraphFlagElement;
	}

	public new bool z0vek()
	{
		if (z0grk() && !z0jrk())
		{
			if (((XTextElement)this).z0pek() < 0)
			{
				return true;
			}
			if (z0tek() < 0)
			{
				return true;
			}
		}
		return false;
	}

	public override string z0gy()
	{
		return Environment.NewLine;
	}

	public void z0eek(bool p0)
	{
		z0zrk(p0);
	}

	public override bool z0or(bool p0, bool p1, bool p2)
	{
		return false;
	}

	public new int z0cek()
	{
		if (z0grk != null)
		{
			return z0grk.z0bek;
		}
		return -1;
	}

	public void z0rek(bool p0)
	{
		z0bek(p0);
	}

	public void z0eek(XTextParagraphListItemElement p0)
	{
		if (p0 == null)
		{
			if (z0grk != null)
			{
				z0grk.z0uek = null;
			}
		}
		else
		{
			z0uek().z0uek = p0;
		}
	}

	public override string z0xr()
	{
		return "[P]";
	}

	internal void z0tek(bool p0)
	{
		z0yrk(p0);
	}

	public new string z0xek()
	{
		XTextElementList xTextElementList = z0qek()?.z0frk();
		if (xTextElementList != null)
		{
			int num = xTextElementList.z0bek(this);
			if (num > 0)
			{
				StringBuilder stringBuilder = new StringBuilder();
				for (int num2 = num - 1; num2 >= 0; num2--)
				{
					XTextElement xTextElement = xTextElementList[num2];
					if (xTextElement is XTextParagraphFlagElement)
					{
						break;
					}
					if (!xTextElement.z0wtk())
					{
						stringBuilder.Insert(0, xTextElement.Text);
					}
				}
				if (z0grk?.z0uek != null)
				{
					stringBuilder.Insert(0, z0grk.z0uek.Text);
				}
				return stringBuilder.ToString();
			}
		}
		return string.Empty;
	}

	public new int z0zek()
	{
		if (z0grk != null)
		{
			return z0grk.z0pek;
		}
		return 0;
	}

	public override string ToString()
	{
		if (XTextElement.z0euk)
		{
			return Environment.NewLine;
		}
		return "[P]";
	}

	public new XTextParagraphListItemElement z0lrk()
	{
		return z0grk?.z0uek;
	}

	public override void z0mr(z0ZzZzvxj p0)
	{
		XTextDocument xTextDocument = z0rik;
		if (xTextDocument == null)
		{
			return;
		}
		Width = xTextDocument.z0ack.z0rek();
		if (!XTextTableCellElement.z0mrk)
		{
			if (z0buk < 0)
			{
				z0aik = xTextDocument.z0ack.z0tek();
				return;
			}
			float num = z0aek().z0ytk;
			if (num == 0f)
			{
				num = xTextDocument.z0ack.z0tek();
			}
			z0aik = num;
			return;
		}
		float num2 = xTextDocument.z0ack.z0tek();
		float num3 = ((z0grk == null) ? 1f : z0grk.z0mek);
		if (num3 == 1f)
		{
			num2 = z0aek().z0ytk;
			z0aek();
			_ = z0aek().z0jrk?.z0xek;
			if (num2 == 0f)
			{
				num2 = xTextDocument.z0ack.z0tek();
			}
		}
		else
		{
			z0ZzZzimk p1 = z0oek(num3);
			num2 = p0.z0eek(p1);
		}
		Height = num2;
	}

	public new int z0krk()
	{
		if (z0grk != null)
		{
			return z0grk.z0iek;
		}
		return -1;
	}

	public new bool z0jrk()
	{
		return z0duk();
	}

	public void z0tek(int p0)
	{
		if (p0 == -1)
		{
			if (z0grk != null)
			{
				z0grk.z0bek = p0;
			}
		}
		else
		{
			z0uek().z0bek = p0;
		}
	}

	public override void z0sr()
	{
		XTextDocumentContentElement xTextDocumentContentElement = z0qek();
		xTextDocumentContentElement.z0sr();
		int num = xTextDocumentContentElement.z0frk().IndexOf(this);
		if (num >= 0)
		{
			xTextDocumentContentElement.z0uek(num, 0);
			if (z0jr().z0yyk() != null)
			{
				z0jr().z0yyk().z0syk();
			}
		}
	}

	public override void z0bw_jiejie20260327142557(z0ygj p0)
	{
		p0.z0tek();
	}

	public override void Dispose()
	{
		base.Dispose();
		if (z0grk != null)
		{
			z0grk.z0eek();
			z0grk = null;
		}
		z0srk = null;
	}

	public new bool z0hrk()
	{
		XTextContentElement xTextContentElement = z0jy();
		if (xTextContentElement != null && xTextContentElement.z0trk().LastElement == this)
		{
			return true;
		}
		return false;
	}

	public new void z0yek(int p0)
	{
		if (p0 == -1)
		{
			if (z0grk != null)
			{
				z0grk.z0iek = p0;
			}
		}
		else
		{
			z0uek().z0iek = p0;
		}
	}

	public new void z0uek(int p0)
	{
		if (p0 == 0)
		{
			if (z0grk != null)
			{
				z0grk.z0pek = p0;
			}
		}
		else
		{
			z0uek().z0pek = p0;
		}
		z0rek(p0: false);
	}
}
