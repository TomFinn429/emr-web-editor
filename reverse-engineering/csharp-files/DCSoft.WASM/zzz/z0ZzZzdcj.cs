using DCSoft.Drawing;
using DCSoft.Writer;
using DCSoft.Writer.Dom;
using DCSystem_Drawing;

namespace zzz;

public class z0ZzZzdcj
{
	private DocumentContentStyle z0oek;

	private DocumentContentStyle z0pek;

	private DocumentContentStyle z0mek;

	private DocumentContentStyle z0nek;

	public DocumentContentStyle z0eek()
	{
		return z0mek;
	}

	public void z0eek(DocumentContentStyle p0)
	{
		z0oek = p0;
	}

	public void z0rek(DocumentContentStyle p0)
	{
		z0nek = p0;
	}

	public z0ZzZzdcj z0rek()
	{
		z0ZzZzdcj z0ZzZzdcj2 = new z0ZzZzdcj();
		if (z0mek != null)
		{
			z0ZzZzdcj2.z0mek = (DocumentContentStyle)z0mek.Clone();
		}
		if (z0oek != null)
		{
			z0ZzZzdcj2.z0oek = (DocumentContentStyle)z0oek.Clone();
		}
		if (z0pek != null)
		{
			z0ZzZzdcj2.z0pek = (DocumentContentStyle)z0pek.Clone();
		}
		if (z0nek != null)
		{
			z0ZzZzdcj2.z0rek((DocumentContentStyle)z0iek().Clone());
		}
		return z0ZzZzdcj2;
	}

	public void z0tek(DocumentContentStyle p0)
	{
		z0mek = p0;
	}

	public DocumentContentStyle z0tek()
	{
		return z0oek;
	}

	public void z0yek()
	{
		if (z0oek != null)
		{
			z0oek.Dispose();
			z0oek = null;
		}
		if (z0nek != null)
		{
			z0nek.Dispose();
			z0nek = null;
		}
		if (z0pek != null)
		{
			z0pek.Dispose();
			z0pek = null;
		}
		if (z0mek != null)
		{
			z0mek.Dispose();
			z0mek = null;
		}
	}

	internal void z0eek(XTextDocument p0)
	{
		XTextParagraphFlagElement xTextParagraphFlagElement = p0.z0mtk();
		if (xTextParagraphFlagElement == null)
		{
			z0pek = new DocumentContentStyle();
			return;
		}
		z0pek = xTextParagraphFlagElement.z0aek().z0yek();
		z0pek.z0rek(p0: false);
		z0pek.LayoutAlign = ContentLayoutAlign.EmbedInText;
		z0pek.ProtectType = ContentProtectType.None;
		z0pek.Visibility = RenderVisibility.All;
		z0pek.TitleLevel = -1;
		z0pek.CreatorIndex = -1;
		z0pek.DeleterIndex = -1;
		z0pek.z0rek(p0: true);
	}

	public void z0rek(XTextDocument p0)
	{
		if (z0oek == null)
		{
			z0oek = (DocumentContentStyle)p0.z0xpk().Clone();
			z0oek.z0rek(p0: false);
			if (p0.z0qok() is XTextHorizontalLineElement)
			{
				z0oek.Color = Color.Black;
			}
			z0oek.LayoutAlign = ContentLayoutAlign.EmbedInText;
			z0oek.ProtectType = ContentProtectType.None;
			z0oek.Visibility = RenderVisibility.All;
			XTextElement xTextElement = p0.z0ryk().SafeGet(p0.z0cuk().z0lrk() - 1);
			XTextElement xTextElement2 = p0.z0ryk().SafeGet(p0.z0cuk().z0drk());
			if (z0oek.CommentIndex >= 0)
			{
				if (xTextElement != null && xTextElement.z0aek().z0vyk < 0)
				{
					z0oek.CommentIndex = -1;
				}
				if (xTextElement2 != null && xTextElement2.z0aek().z0vyk < 0)
				{
					z0oek.CommentIndex = -1;
				}
				if (xTextElement == null)
				{
					z0oek.CommentIndex = -1;
				}
			}
		}
		z0rek((DocumentContentStyle)z0oek.Clone());
		_ = p0.z0qok() is XTextObjectElement;
		if (z0oek.HasVisibleBorder)
		{
			XTextElement xTextElement3 = p0.z0qok();
			if (!(xTextElement3 is XTextCharElement))
			{
				XTextElement xTextElement4 = p0.z0ryk().z0xek(xTextElement3);
				if (xTextElement4 == null || !(xTextElement4 is XTextCharElement) || !xTextElement4.z0aek().z0wrk)
				{
					z0nek.BorderLeft = false;
					z0nek.BorderTop = false;
					z0nek.BorderRight = false;
					z0nek.BorderBottom = false;
					z0nek.BorderWidth = 0f;
					z0nek.BorderColor = Color.Black;
				}
			}
		}
		z0oek.z0eek(p0: true);
		z0oek.CreatorIndex = -1;
		z0oek.DeleterIndex = -1;
		z0nek.z0eek(p0: true);
		z0nek.CreatorIndex = -1;
		z0nek.DeleterIndex = -1;
		z0eek(p0);
		XTextTableCellElement xTextTableCellElement = p0.z0bnk();
		if (xTextTableCellElement == null)
		{
			z0mek = null;
		}
		else
		{
			z0mek = xTextTableCellElement.z0aek().z0yek();
			z0mek.z0rek(p0: false);
			z0mek.LayoutAlign = ContentLayoutAlign.EmbedInText;
			z0mek.ProtectType = ContentProtectType.None;
			z0mek.CreatorIndex = -1;
			z0mek.DeleterIndex = -1;
			z0mek.z0rek(p0: true);
		}
		if (z0mek != null)
		{
			z0mek.z0rek(p0: false);
		}
		if (z0oek != null)
		{
			z0oek.z0rek(p0: false);
		}
		if (z0nek != null)
		{
			z0nek.z0rek(p0: false);
		}
		if (z0pek != null)
		{
			z0pek.z0rek(p0: false);
		}
	}

	public void z0yek(DocumentContentStyle p0)
	{
		z0pek = p0;
	}

	public DocumentContentStyle z0uek()
	{
		return z0pek;
	}

	public DocumentContentStyle z0iek()
	{
		return z0nek;
	}
}
