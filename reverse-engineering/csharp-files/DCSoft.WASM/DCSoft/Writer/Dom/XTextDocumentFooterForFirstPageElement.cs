using System.Diagnostics;
using DCSoft.Drawing;
using zzz;

namespace DCSoft.Writer.Dom;

[DebuggerDisplay("FooterForFirstPage :{ PreviewString }")]
[z0ZzZziqh("XTextFooterForFirstPage")]
public sealed class XTextDocumentFooterForFirstPageElement : XTextDocumentContentElement
{
	public override string z0hu()
	{
		return "FooterForFirstPage:" + base.z0hu();
	}

	public override string z0ge()
	{
		return "FooterForFirstPage";
	}

	public override PageContentPartyStyle z0du()
	{
		return PageContentPartyStyle.FooterForFirstPage;
	}

	public override string z0xr()
	{
		string text = "FooterForFirstPage";
		if (z0jr() != null)
		{
			text = text + ":" + z0jr().z0zrk();
		}
		return text;
	}

	public override PageContentPartyStyle z0fu()
	{
		return PageContentPartyStyle.FooterForFirstPage;
	}

	public override z0ZzZzzej z0ju()
	{
		return null;
	}
}
