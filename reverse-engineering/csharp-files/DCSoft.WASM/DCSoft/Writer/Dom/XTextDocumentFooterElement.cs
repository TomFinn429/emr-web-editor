using System.Diagnostics;
using DCSoft.Drawing;
using zzz;

namespace DCSoft.Writer.Dom;

[DebuggerDisplay("Footer :{ PreviewString }")]
[z0ZzZziqh("XTextFooter")]
public sealed class XTextDocumentFooterElement : XTextDocumentContentElement
{
	public override string z0xr()
	{
		string text = "Footer";
		if (z0jr() != null)
		{
			text = text + ":" + z0jr().z0zrk();
		}
		return text;
	}

	public override z0ZzZzzej z0ju()
	{
		return null;
	}

	public override string z0ge()
	{
		return "Footer";
	}

	public override PageContentPartyStyle z0fu()
	{
		return PageContentPartyStyle.Footer;
	}

	public override PageContentPartyStyle z0du()
	{
		return PageContentPartyStyle.Footer;
	}

	public override string z0hu()
	{
		return "Footer:" + base.z0hu();
	}
}
