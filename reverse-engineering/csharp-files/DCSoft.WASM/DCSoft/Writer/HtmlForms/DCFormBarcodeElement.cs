using System.Text.Json.Nodes;
using DCSoft.Writer.Dom;
using DCSystem_Drawing;

namespace DCSoft.Writer.HtmlForms;

public class DCFormBarcodeElement : DCFormElement
{
	private new DCBarcodeStyle z0uek = DCBarcodeStyle.Code128C;

	private new bool z0iek = true;

	private new string z0oek;

	private new StringAlignment z0pek = StringAlignment.Center;

	public new string z0eek()
	{
		return z0oek;
	}

	public new bool z0rek()
	{
		return z0iek;
	}

	internal DCFormBarcodeElement(XTextNewBarcodeElement lbl)
		: base(lbl)
	{
		z0eek(lbl.BarcodeStyle2);
		z0eek(lbl.TextAlignment);
		z0eek(lbl.ShowText);
		z0eek(lbl.Text);
	}

	public void z0eek(DCBarcodeStyle p0)
	{
		z0uek = p0;
	}

	public new void z0eek(bool p0)
	{
		z0iek = p0;
	}

	public override int z0oq(string p0, XTextDocument p1)
	{
		if (z0qrk is XTextNewBarcodeElement xTextNewBarcodeElement && p0 != xTextNewBarcodeElement.Text)
		{
			xTextNewBarcodeElement.Text = p0;
			return 1;
		}
		return 0;
	}

	public DCFormBarcodeElement()
	{
	}

	public override void z0pq(JsonObject p0, bool p1 = false)
	{
		base.z0pq(p0, p1);
		p0.Add("Text", z0eek());
		p0.Add("TextAlignment", z0yek().ToString());
		p0.Add("ShowText", z0rek());
		p0.Add("BarcodeStyle", z0tek().ToString());
	}

	public new void z0eek(string p0)
	{
		z0oek = p0;
	}

	public new DCBarcodeStyle z0tek()
	{
		return z0uek;
	}

	public void z0eek(StringAlignment p0)
	{
		z0pek = p0;
	}

	public new StringAlignment z0yek()
	{
		return z0pek;
	}
}
