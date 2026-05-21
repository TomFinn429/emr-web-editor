using System;
using System.ComponentModel;
using DCSoft.Drawing;
using DCSoft.WinForms;
using DCSystem_Drawing.Drawing2D;
using zzz;

namespace DCSoft.Writer.Dom;

public abstract class XTextShapeInputFieldElement : XTextInputFieldElementBase
{
	private new bool z0yek = true;

	[NonSerialized]
	private new bool z0uek;

	[NonSerialized]
	private new z0ZzZzndh z0iek = z0ZzZzndh.z0cek;

	private new bool z0oek = true;

	private new ResizeableType z0pek = ResizeableType.WidthAndHeight;

	internal new float z0mek;

	[z0ZzZzuqh]
	[DefaultValue(false)]
	public bool EditMode
	{
		get
		{
			if (Enabled)
			{
				return z0uek;
			}
			return false;
		}
		set
		{
			z0uek = value;
		}
	}

	[DefaultValue(true)]
	public bool Enabled
	{
		get
		{
			return z0yek;
		}
		set
		{
			z0yek = value;
		}
	}

	[z0ZzZzuqh]
	public virtual ResizeableType Resizeable
	{
		get
		{
			return z0pek;
		}
		set
		{
			z0pek = value;
		}
	}

	public virtual bool EnableEditMode => true;

	[DefaultValue(true)]
	public bool AutoExitEditMode
	{
		get
		{
			return z0oek;
		}
		set
		{
			z0oek = value;
		}
	}

	public override void z0mt(float p0)
	{
		z0mek = p0;
	}

	public override void z0mr(z0ZzZzvxj p0)
	{
		z0xi(p0: true);
		z0ro(p0: true);
		base.z0mr(p0);
	}

	public override void z0jo()
	{
		if (EditMode)
		{
			base.z0jo();
		}
		else if (z0jr() != null)
		{
			z0jr().z0krk(this);
		}
	}

	public virtual void z0dw(DocumentEventArgs p0)
	{
		z0eek(!EditMode, p1: true);
		p0.Handled = true;
	}

	public override XTextElement z0dek()
	{
		if (EditMode)
		{
			return base.z0dek();
		}
		return this;
	}

	public override void z0mu(DocumentEventArgs p0)
	{
		if (p0.Style == DocumentEventStyles.DefaultEditMethod)
		{
			z0dw(p0);
		}
		else if (p0.Style == DocumentEventStyles.MouseDown)
		{
			if (!Enabled || EditMode)
			{
				return;
			}
			if (p0.MouseClicks == 2)
			{
				z0dw(p0);
			}
			else if (z0rek())
			{
				z0ZzZzapj z0ZzZzapj = z0eek(p0.X, p0.Y);
				if (z0ZzZzapj >= (z0ZzZzapj)0)
				{
					z0eek(z0ZzZzapj);
					p0.Handled = true;
					if (z0jr().z0yyk() != null)
					{
						z0jr().z0yyk().z0vik();
					}
				}
			}
			else
			{
				int p1 = ((XTextElement)this).z0jrk();
				p1 = z0jr().z0ryk().z0tek(p1, (z0ZzZzfxj)2, p2: true);
				if (p1 == ((XTextElement)this).z0jrk())
				{
					z0jr().z0ryk().z0tek(p1, 1);
				}
				else
				{
					z0jr().z0ryk().z0tek(p1, 0);
				}
				p0.Handled = true;
			}
		}
		else if (p0.Style == DocumentEventStyles.MouseMove)
		{
			if (Enabled && !EditMode && z0rek())
			{
				z0ZzZzapj z0ZzZzapj2 = z0tek().z0eek(p0.X, p0.Y);
				if (z0ZzZzapj2 >= (z0ZzZzapj)0)
				{
					p0.Cursor = z0ZzZzqpj.z0eek(z0ZzZzapj2);
					base.z0mu(p0);
				}
			}
		}
		else
		{
			base.z0mu(p0);
		}
	}

	public new virtual void z0eek()
	{
	}

	public override int z0ue(z0eok_jiejie20260327142557 p0)
	{
		if (EditMode)
		{
			return base.z0ue(p0);
		}
		z0ro(p0: true);
		p0.z0iek.Add(this);
		return 1;
	}

	public virtual VerticalAlignStyle z0fw()
	{
		return VerticalAlignStyle.Top;
	}

	public override float z0cw()
	{
		if (EditMode && ((XTextFieldElementBase)this).z0jrk() != null)
		{
			return ((XTextFieldElementBase)this).z0jrk().z0cw();
		}
		if (z0kik == null)
		{
			return 0f;
		}
		return z0wik + z0kik.z0xrk();
	}

	public override void z0oy(ElementEventArgs p0)
	{
		base.z0oy(p0);
		if (!AutoExitEditMode || !EditMode || p0.WriterControl == null || !p0.WriterControl.z0uyk())
		{
			return;
		}
		XTextElement item = z0jr().z0itk();
		if (z0eek(p0: false, p1: false))
		{
			int num = z0qek().z0frk().IndexOf(item);
			if (num < 0)
			{
				num = z0qek().z0frk().IndexOf(this);
			}
			if (num >= 0)
			{
				z0qek().z0uek(num, 0);
			}
		}
	}

	public virtual void z0ro(bool p0)
	{
	}

	protected new void z0eek(z0ZzZzvxj p0)
	{
		if (p0.z0byk == (z0ZzZzcxj)0 && p0.z0eyk && z0rek() && Enabled)
		{
			z0ZzZzqpj z0ZzZzqpj = z0tek();
			z0ZzZzqpj.z0eek(new z0ZzZzndh((int)((XTextElement)this).z0zrk(), (int)((XTextElement)this).z0ltk(), z0ZzZzqpj.z0yek().z0iek(), z0ZzZzqpj.z0yek().z0oek()));
			z0ZzZzqpj.z0eek(p0.z0gyk);
		}
	}

	public override float z0ut()
	{
		return z0fik + z0mek;
	}

	public override float z0pt()
	{
		return z0mek;
	}

	public new bool z0rek()
	{
		if (Resizeable == ResizeableType.FixSize)
		{
			return false;
		}
		XTextDocumentContentElement xTextDocumentContentElement = z0qek();
		if (xTextDocumentContentElement.z0rek(this))
		{
			return xTextDocumentContentElement.z0oek().z0tek() == 1;
		}
		return false;
	}

	public override XTextElement z0ie()
	{
		if (EditMode)
		{
			return base.z0ie();
		}
		return this;
	}

	public virtual bool z0eek(bool p0, bool p1)
	{
		if (p0 && !EnableEditMode)
		{
			return false;
		}
		if (EditMode != p0)
		{
			XTextDocumentContentElement xTextDocumentContentElement = z0qek();
			bool flag = false;
			if (EditMode)
			{
				flag = z0fek();
			}
			else if (xTextDocumentContentElement.z0rek(this) || xTextDocumentContentElement.z0zek() == this)
			{
				flag = true;
			}
			EditMode = p0;
			if (EditMode != p0)
			{
				return false;
			}
			int p2 = xTextDocumentContentElement.z0oek().z0nek();
			XTextElement item = xTextDocumentContentElement.z0zek();
			if (z0jr().z0htk() != null)
			{
				z0jr().z0htk().z0co(this);
			}
			XTextContentElement xTextContentElement = z0jy();
			int num = 0;
			int num2 = 0;
			if (EditMode)
			{
				num = xTextContentElement.z0trk().IndexOf(this);
				num2 = num + 1;
			}
			else
			{
				num = xTextContentElement.z0trk().IndexOf(((XTextFieldElementBase)this).z0jrk());
				num2 = xTextContentElement.z0trk().IndexOf(((XTextFieldElementBase)this).z0tek());
			}
			if (!EditMode)
			{
				z0xi(p0: true);
				z0ro(p0: true);
			}
			xTextContentElement.z0bek(p0: true);
			xTextContentElement.z0eek(num - 1, num2 + 1, p2: false);
			if (flag)
			{
				if (EditMode)
				{
					z0sr();
				}
				else if (p1)
				{
					xTextDocumentContentElement.z0uek(xTextDocumentContentElement.z0frk().IndexOf(this), 0);
				}
			}
			else if (p1)
			{
				int num3 = xTextDocumentContentElement.z0frk().IndexOf(item);
				if (num3 >= 0)
				{
					xTextDocumentContentElement.z0uek(num3, 0);
				}
				else
				{
					p2 = xTextDocumentContentElement.z0frk().z0nek(p2);
					xTextDocumentContentElement.z0uek(p2, 0);
				}
			}
			return true;
		}
		return false;
	}

	public override void z0sr()
	{
		if (EditMode)
		{
			base.z0sr();
			return;
		}
		XTextElement xTextElement = z0ie();
		if (xTextElement != null)
		{
			int p = xTextElement.z0jrk();
			z0qek().z0frk().z0tek(p, p1: false);
		}
	}

	private void z0eek(object p0, z0ZzZzrpj p1)
	{
		_ = (z0ZzZzapj)p1.z0rek().z0jrk();
	}

	public bool z0eek(z0ZzZzapj p0)
	{
		z0ZzZzypj z0ZzZzypj = new z0ZzZzypj(z0uyk());
		z0ZzZzypj.z0rek(p0);
		z0ZzZzypj.z0eek((z0ZzZzupj)4);
		z0ZzZzypj.z0rrk = z0eek;
		XTextDocumentContentElement xTextDocumentContentElement = z0qek();
		if (z0ZzZzypj.z0lrk() && z0iek.z0iek() > 0 && z0iek.z0oek() > 0 && ((float)z0iek.z0iek() != Width || (float)z0iek.z0oek() != Height))
		{
			z0ZzZzxdh z0ZzZzxdh = new z0ZzZzxdh(Width, Height);
			z0jo();
			EditorSize = new z0ZzZzxdh(z0iek.z0iek(), z0iek.z0oek());
			z0xi(p0: true);
			z0ro(p0: true);
			z0eek();
			z0jo();
			xTextDocumentContentElement.z0uek(((XTextElement)this).z0jrk(), 1);
			if (z0jr().z0ytk())
			{
				z0jr().z0imk().z0eek((z0ZzZzqlh)2, z0ZzZzxdh, new z0ZzZzxdh(Width, Height), this);
				z0jr().z0nuk();
			}
			z0jy().z0eek(z0jy().z0trk().IndexOf(this));
			z0jr().Modified = true;
			return true;
		}
		return false;
	}

	public override void z0tt(z0ZzZzvxj p0)
	{
		if (EditMode)
		{
			base.z0tt(p0);
			return;
		}
		p0.z0yyk.z0eek(this, p0);
		z0vw(p0);
		z0eek(p0);
		z0ZzZzbdh p1 = z0qyk();
		p1.z0tek(p1.z0uek() - 1f);
		p1.z0yek(p1.z0iek() - 1f);
		p0.z0yyk.z0rek(this, p0, p1);
	}

	public override float z0he()
	{
		if (EditMode && ((XTextFieldElementBase)this).z0jrk() != null)
		{
			return ((XTextFieldElementBase)this).z0jrk().z0he();
		}
		if (z0kik == null)
		{
			return 0f;
		}
		return z0xik + z0kik.z0xtk();
	}

	public virtual z0ZzZzapj z0eek(int p0, int p1)
	{
		return z0tek()?.z0eek(p0, p1) ?? ((z0ZzZzapj)(-2));
	}

	public new virtual z0ZzZzqpj z0tek()
	{
		z0ZzZzqpj.z0jrk = XTextObjectElement.z0xek;
		z0ZzZzqpj z0ZzZzqpj = new z0ZzZzqpj(new z0ZzZzndh(0, 0, (int)Width, (int)Height), p1: true);
		z0ZzZzqpj.z0rek(p0: true);
		z0ZzZzqpj.z0eek(DashStyle.Solid);
		if (z0jr().z0xek().z0pm(this, (z0ZzZzbcj)255))
		{
			z0ZzZzqpj.z0eek(Resizeable);
		}
		else
		{
			z0ZzZzqpj.z0eek(ResizeableType.FixSize);
		}
		z0ZzZzqpj.z0eek(p0: true);
		if (z0ZzZzqpj.z0uek() != ResizeableType.FixSize && z0ji().z0brk())
		{
			if (z0aek().z0jyk >= 0)
			{
				z0ZzZzqpj.z0eek(ResizeableType.FixSize);
			}
			else if (z0ntk() > z0jr().z0syk().z0oek())
			{
				z0ZzZzqpj.z0eek(ResizeableType.FixSize);
			}
		}
		return z0ZzZzqpj;
	}
}
