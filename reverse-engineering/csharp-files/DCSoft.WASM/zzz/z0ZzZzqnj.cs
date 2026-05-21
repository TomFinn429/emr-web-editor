using System;
using DCSoft.Drawing;
using DCSoft.Writer.Dom;
using DCSystem_Drawing;
using DCSystem_Drawing.Drawing2D;

namespace zzz;

[z0ZzZziqh]
internal class z0ZzZzqnj : z0ZzZzsnj, ICloneable
{
	private DashStyle z0xek;

	private int z0zek = 1;

	private string z0lrk;

	private float z0krk = 10f;

	private Color z0jrk = Color.Black;

	private int z0hrk = 3;

	private float z0grk = 10f;

	private float z0frk = 15f;

	private float z0drk = 15f;

	private int z0srk = 3;

	private float z0ark;

	private float z0qrk;

	public new float z0eek()
	{
		return z0qrk;
	}

	public DashStyle z0rek()
	{
		return z0xek;
	}

	public Color z0tek()
	{
		return z0jrk;
	}

	public void z0eek(float p0)
	{
		z0ark = p0;
	}

	public void z0eek(string p0)
	{
		z0lrk = p0;
	}

	private object z0yek()
	{
		return (z0ZzZzqnj)MemberwiseClone();
	}

	object ICloneable.Clone()
	{
		//ILSpy generated this explicit interface implementation from .override directive in z0yek
		return this.z0yek();
	}

	public float z0uek()
	{
		return z0frk;
	}

	public float z0iek()
	{
		return z0drk;
	}

	public void z0rek(float p0)
	{
		z0krk = p0;
	}

	public void z0tek(float p0)
	{
		z0qrk = p0;
	}

	public void z0eek(int p0)
	{
		z0hrk = p0;
	}

	public float z0oek()
	{
		return z0krk;
	}

	public int z0pek()
	{
		return z0srk;
	}

	public override XTextElement z0sz(XTextDocument p0)
	{
		if (z0bek() <= 0 || z0pek() <= 0)
		{
			return null;
		}
		XTextTableElement xTextTableElement = new XTextTableElement();
		z0dz(p0, xTextTableElement, p2: false);
		return xTextTableElement;
	}

	public override bool z0dz(XTextDocument p0, XTextElement p1, bool p2)
	{
		XTextTableElement xTextTableElement = (XTextTableElement)p1;
		xTextTableElement.CompressOwnerLineSpacing = false;
		xTextTableElement.z0bt(p0);
		DocumentContentStyle documentContentStyle = new DocumentContentStyle();
		documentContentStyle.BorderColor = z0tek();
		documentContentStyle.BorderWidth = z0mek();
		documentContentStyle.BorderStyle = z0rek();
		documentContentStyle.BorderLeft = true;
		documentContentStyle.BorderTop = true;
		documentContentStyle.BorderRight = true;
		documentContentStyle.BorderBottom = true;
		documentContentStyle.PaddingBottom = z0nek();
		documentContentStyle.PaddingLeft = z0iek();
		documentContentStyle.PaddingRight = z0uek();
		documentContentStyle.PaddingTop = z0oek();
		documentContentStyle.VerticalAlign = VerticalAlignStyle.Top;
		int styleIndex = p0.z0gnk().GetStyleIndex(documentContentStyle);
		float num = z0eek();
		if (num <= 0f)
		{
			num = (p0.PageSettings.z0prk() - 30f) / (float)z0pek();
		}
		float specifyHeight = z0vek();
		float num2 = ((DocumentContentStyle)p0.z0gnk().Default).z0mek();
		for (int i = 0; i < z0pek(); i++)
		{
			XTextTableColumnElement xTextTableColumnElement = xTextTableElement.z0vek();
			xTextTableColumnElement.Width = num;
			xTextTableElement.z0ou(xTextTableColumnElement);
		}
		for (int j = 0; j < z0bek(); j++)
		{
			XTextTableRowElement xTextTableRowElement = xTextTableElement.z0nrk();
			xTextTableRowElement.SpecifyHeight = specifyHeight;
			xTextTableRowElement.Height = num2;
			xTextTableRowElement.z0nt((float)j * num2);
			xTextTableElement.z0ou(xTextTableRowElement);
			for (int k = 0; k < z0pek(); k++)
			{
				XTextTableCellElement xTextTableCellElement = xTextTableElement.z0urk();
				xTextTableCellElement.z0oek(styleIndex);
				xTextTableCellElement.z0ot(num * (float)k);
				xTextTableCellElement.z0nt(0f);
				xTextTableRowElement.z0ou(xTextTableCellElement);
				xTextTableCellElement.z0ou(new XTextParagraphFlagElement());
			}
		}
		xTextTableElement.ID = z0cek();
		return true;
	}

	public int z0mek()
	{
		return z0zek;
	}

	public float z0nek()
	{
		return z0grk;
	}

	public void z0yek(float p0)
	{
		z0drk = p0;
	}

	public void z0eek(Color p0)
	{
		z0jrk = p0;
	}

	public void z0rek(int p0)
	{
		z0zek = p0;
	}

	public int z0bek()
	{
		return z0hrk;
	}

	public void z0tek(int p0)
	{
		z0srk = p0;
	}

	public void z0eek(DashStyle p0)
	{
		z0xek = p0;
	}

	public void z0uek(float p0)
	{
		z0grk = p0;
	}

	public float z0vek()
	{
		return z0ark;
	}

	public void z0iek(float p0)
	{
		z0frk = p0;
	}

	public string z0cek()
	{
		return z0lrk;
	}

	public override bool z0az(XTextElement p0)
	{
		return false;
	}
}
