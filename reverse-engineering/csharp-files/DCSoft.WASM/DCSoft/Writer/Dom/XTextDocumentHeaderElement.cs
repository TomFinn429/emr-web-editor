using System.Diagnostics;
using DCSoft.Drawing;
using zzz;

namespace DCSoft.Writer.Dom;

[z0ZzZziqh("XTextHeader")]
[DebuggerDisplay("Header :{ PreviewString }")]
public sealed class XTextDocumentHeaderElement : XTextDocumentContentElement
{
	public override z0ZzZzzej z0ju()
	{
		return null;
	}

	public override PageContentPartyStyle z0du()
	{
		return PageContentPartyStyle.Header;
	}

	public override PageContentPartyStyle z0fu()
	{
		return PageContentPartyStyle.Header;
	}

	public override string z0hu()
	{
		return "Header:" + base.z0hu();
	}

	public override string z0xr()
	{
		string text = "Header";
		if (z0jr() != null)
		{
			text = text + ":" + z0jr().z0zrk();
		}
		return text;
	}

	public override void z0gu()
	{
		if (z0jr() != null && (z0be().Count == 0 || !(z0be().LastElement is XTextParagraphFlagElement)))
		{
			XTextParagraphFlagElement xTextParagraphFlagElement = new XTextParagraphFlagElement();
			xTextParagraphFlagElement.z0rek(p0: true);
			DocumentContentStyle documentContentStyle = new DocumentContentStyle();
			documentContentStyle.Align = DocumentContentAlignment.Center;
			xTextParagraphFlagElement.z0oek(z0jr().z0gnk().GetStyleIndex(documentContentStyle));
			z0ou(xTextParagraphFlagElement);
		}
	}

	public override string z0ge()
	{
		return "Header";
	}
}
