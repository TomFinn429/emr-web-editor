using System.Diagnostics;
using DCSoft.Drawing;
using zzz;

namespace DCSoft.Writer.Dom;

[z0ZzZziqh("XTextHeaderForFirstPage")]
[DebuggerDisplay("HeaderForFirstPage :{ PreviewString }")]
public sealed class XTextDocumentHeaderForFirstPageElement : XTextDocumentContentElement
{
	public override PageContentPartyStyle z0fu()
	{
		return PageContentPartyStyle.HeaderForFirstPage;
	}

	public override string z0hu()
	{
		return "HeaderForFirstPage:" + base.z0hu();
	}

	public override PageContentPartyStyle z0du()
	{
		return PageContentPartyStyle.HeaderForFirstPage;
	}

	public override string z0ge()
	{
		return "HeaderForFirstPage";
	}

	public override z0ZzZzzej z0ju()
	{
		return null;
	}

	public override string z0xr()
	{
		string text = "HeaderForFirstPage";
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
			z0ntk.Add(xTextParagraphFlagElement);
			xTextParagraphFlagElement.z0yek(z0rik, this);
		}
	}
}
