using System;
using System.Text.Json.Nodes;
using DCSoft.Writer.Dom;

namespace DCSoft.Writer.HtmlForms;

public sealed class DCFormButtonElement : DCFormElement
{
	private new float z0uek;

	private new string z0iek;

	private new string z0oek;

	private new float z0pek;

	public new float z0eek()
	{
		return z0pek;
	}

	public DCFormButtonElement(XTextButtonElement element)
		: base(element)
	{
		if (element == null)
		{
			throw new ArgumentNullException("element");
		}
		z0iek = element.Text;
		z0oek = element.ScriptTextForClick;
		z0pek = element.z0xyk();
		z0uek = element.z0utk();
		z0uek(element.Name);
	}

	public override string ToString()
	{
		return "Button:" + z0vek();
	}

	public new string z0rek()
	{
		return z0iek;
	}

	public new void z0eek(string p0)
	{
		z0iek = p0;
	}

	public override void z0pq(JsonObject p0, bool p1 = false)
	{
		base.z0pq(p0, p1);
		p0.Add("Text", z0rek());
		p0.Add("ScriptTextForClick", z0tek());
		p0.Add("PixelWidth", z0eek().ToString());
		p0.Add("PixelHeight", z0yek().ToString());
	}

	public new string z0tek()
	{
		return z0oek;
	}

	public new float z0yek()
	{
		return z0uek;
	}

	public DCFormButtonElement()
	{
	}

	public new void z0rek(string p0)
	{
		z0oek = p0;
	}

	public void z0eek(float p0)
	{
		z0uek = p0;
	}

	public void z0rek(float p0)
	{
		z0pek = p0;
	}
}
