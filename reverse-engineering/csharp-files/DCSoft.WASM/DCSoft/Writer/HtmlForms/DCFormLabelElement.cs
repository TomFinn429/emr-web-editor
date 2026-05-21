using System.Text.Json.Nodes;
using DCSoft.Writer.Dom;

namespace DCSoft.Writer.HtmlForms;

public class DCFormLabelElement : DCFormElement
{
	private new string z0rek;

	internal DCFormLabelElement(XTextLabelElement lbl)
		: base(lbl)
	{
		z0tek(lbl.ToolTip);
		z0eek(lbl.Text);
	}

	public override void z0nq(string p0)
	{
		z0rek = p0;
	}

	public new string z0eek()
	{
		return z0rek;
	}

	public override string z0mq()
	{
		return z0rek;
	}

	public override void z0pq(JsonObject p0, bool p1 = false)
	{
		base.z0pq(p0, p1);
		p0.Add("Text", z0eek());
	}

	public new void z0eek(string p0)
	{
		z0rek = p0;
	}

	public DCFormLabelElement()
	{
	}
}
