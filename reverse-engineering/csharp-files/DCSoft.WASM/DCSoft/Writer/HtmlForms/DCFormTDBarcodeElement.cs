using System.Text.Json.Nodes;
using DCSoft.Writer.Dom;

namespace DCSoft.Writer.HtmlForms;

public class DCFormTDBarcodeElement : DCFormElement
{
	private new DCTBErroeCorrectionLevelType z0tek;

	private new string z0yek;

	public new string z0eek()
	{
		return z0yek;
	}

	public new void z0eek(string p0)
	{
		z0yek = p0;
	}

	public new DCTBErroeCorrectionLevelType z0rek()
	{
		return z0tek;
	}

	public override void z0pq(JsonObject p0, bool p1 = false)
	{
		base.z0pq(p0, p1);
		p0.Add("Text", z0eek());
		p0.Add("ErrorCorrectionLevel", z0rek().ToString());
	}

	public void z0eek(DCTBErroeCorrectionLevelType p0)
	{
		z0tek = p0;
	}

	internal DCFormTDBarcodeElement(XTextTDBarcodeElement lbl)
		: base(lbl)
	{
		z0eek(lbl.Text);
		z0eek(lbl.ErroeCorrectionLevel);
	}

	public override int z0oq(string p0, XTextDocument p1)
	{
		if (z0qrk is XTextTDBarcodeElement xTextTDBarcodeElement && p0 != xTextTDBarcodeElement.Text)
		{
			xTextTDBarcodeElement.Text = p0;
			return 1;
		}
		return 0;
	}

	public DCFormTDBarcodeElement()
	{
	}
}
