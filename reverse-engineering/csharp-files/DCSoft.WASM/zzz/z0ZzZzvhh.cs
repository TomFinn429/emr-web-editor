using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using DCSoft.Drawing;
using DCSoft.Printing;
using DCSoft.Writer;
using DCSoft.Writer.Dom;
using DCSystem_Drawing;
using DCSystem_Drawing.Drawing2D;

namespace zzz;

public class z0ZzZzvhh : z0ZzZzrcj, z0ZzZzjgh
{
	private XTextElement z0cek;

	private Encoding z0xek_jiejie20260327142557 = z0ZzZzjtj.z0srk;

	private bool z0zek;

	private z0ZzZzjtj z0lrk;

	internal bool z0krk = true;

	private bool z0jrk = true;

	private bool z0hrk;

	private z0ZzZzrzj z0grk;

	private void z0rek(z0ZzZzrzj p0, bool p1)
	{
		if (p0.z0erk <= 0f || (!p0.z0rrk && !p0.z0wyk && !p0.z0etk && !p0.z0mrk))
		{
			return;
		}
		z0nek().z0tek("brdrcf" + Convert.ToString(z0nek().z0uek().z0rek(p0.z0rtk) + 1));
		if (p1)
		{
			if (p0.z0rrk)
			{
				z0nek().z0tek("brdrl");
			}
			if (p0.z0wyk)
			{
				z0nek().z0tek("brdrt");
			}
			if (p0.z0etk)
			{
				z0nek().z0tek("brdrr");
			}
			if (p0.z0mrk)
			{
				z0nek().z0tek("brdrb");
			}
			if (p0.z0lyk > 0f)
			{
				z0nek().z0tek("brsp" + z0rek(p0.z0lyk));
			}
		}
		else if (p0.z0rrk || p0.z0wyk || p0.z0etk || p0.z0mrk)
		{
			z0nek().z0tek("chbrdr");
		}
		switch (p0.z0guk)
		{
		case DashStyle.Dash:
			z0nek().z0tek("brdrdash");
			break;
		case DashStyle.DashDot:
			z0nek().z0tek("brdrdashd");
			break;
		case DashStyle.DashDotDot:
			z0nek().z0tek("brdrdashdd");
			break;
		case DashStyle.Dot:
			z0nek().z0tek("brdrdot");
			break;
		}
		if (p0.z0erk == 1f)
		{
			z0nek().z0tek("brdrs");
		}
		else
		{
			z0nek().z0tek("brdrth");
		}
	}

	public static XTextElementList z0rek(XTextElementList p0, bool p1, bool p2)
	{
		if (p0 == null || p0.Count == 0)
		{
			return null;
		}
		XTextElementList xTextElementList = new XTextElementList();
		using (zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = p0.z0ltk())
		{
			while (z0bpk.MoveNext())
			{
				XTextElement current = z0bpk.Current;
				if (!p2 || !current.z0wtk())
				{
					xTextElementList.Add(current);
				}
			}
		}
		XTextElementList xTextElementList2 = new XTextElementList();
		XTextDocument p3 = p0[0].z0jr();
		XTextParagraphElement xTextParagraphElement = new XTextParagraphElement();
		xTextParagraphElement.z0rek(p0: true);
		xTextParagraphElement.z0bt(p3);
		xTextElementList2.Add(xTextParagraphElement);
		using (zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = xTextElementList.z0ltk())
		{
			while (z0bpk.MoveNext())
			{
				XTextElement current2 = z0bpk.Current;
				XTextParagraphElement xTextParagraphElement2 = (XTextParagraphElement)xTextElementList2[xTextElementList2.Count - 1];
				if (current2 is XTextParagraphFlagElement)
				{
					xTextParagraphElement2.z0rek(p0: false);
					xTextParagraphElement2.z0oek(current2.z0pek());
					((zzz.z0ZzZzkuk<XTextElement>)xTextParagraphElement2.z0be()).z0pek(current2);
					xTextParagraphElement2 = new XTextParagraphElement();
					xTextParagraphElement2.z0bt(p3);
					xTextElementList2.Add(xTextParagraphElement2);
				}
				else
				{
					((zzz.z0ZzZzkuk<XTextElement>)xTextParagraphElement2.z0be()).z0pek(current2);
				}
			}
		}
		if (((XTextParagraphElement)xTextElementList2[xTextElementList2.Count - 1]).z0be().Count == 0)
		{
			xTextElementList2.RemoveAt(xTextElementList2.Count - 1);
		}
		return xTextElementList2;
	}

	public void z0os()
	{
		z0nek().z0eek(new z0ZzZzfyj());
		z0nek().z0eek(new z0ZzZzdyj());
		z0nek().z0eek(new z0ZzZzfyj());
		int tickCount = Environment.TickCount;
		foreach (XTextDocument item in base.z0tek())
		{
			DocumentOptions documentOptions = item.z0vtk();
			z0nek().z0mek().z0eek(item.z0dik().FontName, z0xek_jiejie20260327142557);
			z0nek().z0uek().z0eek(Color.Black);
			z0nek().z0uek().z0eek(Color.White);
			z0nek().z0uek().z0eek(item.z0dik().Color);
			z0nek().z0uek().z0eek(documentOptions.ViewOptions.BackgroundTextColor);
			using (zzz.z0ZzZzkuk<z0ZzZzcok>.z0bpk z0bpk = item.z0gnk().Styles.z0ltk())
			{
				while (z0bpk.MoveNext())
				{
					DocumentContentStyle documentContentStyle = (DocumentContentStyle)z0bpk.Current;
					if (!string.IsNullOrEmpty(documentContentStyle.FontName))
					{
						z0nek().z0mek().z0eek(documentContentStyle.FontName, z0ZzZzltj.z0rik);
					}
					z0nek().z0uek().z0eek(documentContentStyle.Color);
					z0nek().z0uek().z0eek(documentContentStyle.BackgroundColor);
					z0nek().z0uek().z0eek(documentContentStyle.BorderLeftColor);
					z0nek().z0uek().z0eek(documentContentStyle.BorderTopColor);
					z0nek().z0uek().z0eek(documentContentStyle.BorderRightColor);
					z0nek().z0uek().z0eek(documentContentStyle.BorderBottomColor);
					z0nek().z0uek().z0eek(documentContentStyle.PrintColor);
				}
			}
			using zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk2 = item.z0be().z0ltk();
			while (z0bpk2.MoveNext())
			{
				XTextElement current2 = z0bpk2.Current;
				XTextDocumentContentElement xTextDocumentContentElement = current2 as XTextDocumentContentElement;
				if (xTextDocumentContentElement == null && documentOptions.BehaviorOptions.WeakMode)
				{
					throw new InvalidCastException(current2.GetType().Name + "->XTextDocumentContentElement");
				}
				z0ZzZzjyj z0ZzZzjyj2 = new z0ZzZzjyj();
				z0ZzZzjyj2.z0tek(z0nek().z0oek().Count + 1);
				z0ZzZzjyj2.z0rek(tickCount++);
				z0nek().z0oek().Add(z0ZzZzjyj2);
				if (xTextDocumentContentElement.z0nek() != null)
				{
					z0eek(xTextDocumentContentElement.z0nek().z0bek(), z0ZzZzjyj2, 0);
					if (z0ZzZzjyj2.z0tek().Count == 0)
					{
						z0nek().z0oek().Remove(z0ZzZzjyj2);
					}
				}
				if (xTextDocumentContentElement.z0srk() == null)
				{
					continue;
				}
				foreach (List<XTextParagraphFlagElement> item2 in xTextDocumentContentElement.z0srk())
				{
					z0ZzZzjyj z0ZzZzjyj3 = new z0ZzZzjyj();
					z0ZzZzjyj3.z0tek(z0nek().z0oek().Count + 1);
					z0ZzZzjyj3.z0rek(tickCount++);
					z0nek().z0oek().Add(z0ZzZzjyj3);
					z0eek(item2, z0ZzZzjyj3, 0);
					if (z0ZzZzjyj3.z0tek().Count == 0)
					{
						z0nek().z0oek().Remove(z0ZzZzjyj3);
					}
				}
			}
		}
	}

	private void z0rek(XTextPageBreakElement p0)
	{
		z0tek("page");
	}

	private void z0rek(XTextParagraphFlagElement p0)
	{
		if (p0.z0brk() != null && p0.z0ji() != p0.z0brk())
		{
			z0rek("\n", p0.z0aek());
		}
	}

	public new XTextElement z0rek()
	{
		return z0cek;
	}

	public new bool z0tek()
	{
		return z0hrk;
	}

	public new void z0yek()
	{
	}

	private void z0rek(XTextLabelElementBase p0)
	{
		z0rek(p0.Text, p0.z0aek());
		z0pek();
	}

	private void z0rek(XTextHorizontalLineElement p0)
	{
		using z0ZzZzpmk z0ZzZzpmk2 = p0.z0ny();
		z0rek(z0ZzZzpmk2, z0ZzZzpmk2.Width, z0ZzZzpmk2.Height, null, p0.z0aek());
	}

	private void z0rek(XTextDocument p0)
	{
		p0.z0qtk().RenderMode = DocumentRenderMode.RTF;
		z0ws(p0);
		z0eek(new z0ZzZzbdh(0f, 0f, p0.z0xyk().Width, p0.z0xyk().Height));
		z0rek(p0.z0xyk());
		z0as();
	}

	public void z0is(XTextElement p0)
	{
		if (p0 is XTextDocument)
		{
			z0rek((XTextDocument)p0);
		}
		else if (p0 is XTextDocumentContentElement)
		{
			z0rek((XTextDocumentContentElement)p0);
		}
		else if (p0 is XTextContentElement)
		{
			z0rek((XTextContentElement)p0);
		}
		else if (p0 is XTextSignImageElement)
		{
			z0rek((XTextSignImageElement)p0);
		}
		else if (p0 is XTextPageInfoElement)
		{
			z0rek((XTextPageInfoElement)p0);
		}
		else if (p0 is XTextPageBreakElement)
		{
			z0rek((XTextPageBreakElement)p0);
		}
		else if (p0 is XTextLineBreakElement)
		{
			z0rek((XTextLineBreakElement)p0);
		}
		else if (p0 is XTextImageElement)
		{
			z0rek((XTextImageElement)p0);
		}
		else if (p0 is XTextHorizontalLineElement)
		{
			z0rek((XTextHorizontalLineElement)p0);
		}
		else if (p0 is XTextCheckBoxElementBase)
		{
			z0rek((XTextCheckBoxElementBase)p0);
		}
		else if (p0 is z0ZzZzolh)
		{
			z0rek((z0ZzZzolh)p0);
		}
		else if (p0 is XTextParagraphElement)
		{
			z0rek((XTextParagraphElement)p0);
		}
		else if (p0 is XTextTDBarcodeElement)
		{
			z0rek((XTextTDBarcodeElement)p0);
		}
		else if (p0 is XTextStringElement)
		{
			z0rek((XTextStringElement)p0);
		}
		else if (p0 is XTextTableCellElement)
		{
			z0rek((XTextTableCellElement)p0);
		}
		else if (p0 is XTextTableElement)
		{
			z0rek((XTextTableElement)p0);
		}
		else if (p0 is XTextShapeInputFieldElement)
		{
			z0rek((XTextShapeInputFieldElement)p0);
		}
		else if (p0 is XTextInputFieldElementBase)
		{
			z0rek((XTextInputFieldElementBase)p0);
		}
		else if (p0 is XTextContainerElement)
		{
			z0rek((XTextContainerElement)p0);
		}
		else if (p0 is XTextFieldBorderElement)
		{
			z0rek((XTextFieldBorderElement)p0);
		}
		else if (p0 is XTextLabelElementBase)
		{
			z0rek((XTextLabelElementBase)p0);
		}
		else if (p0 is XTextCharElement)
		{
			z0rek((XTextCharElement)p0);
		}
		else if (p0 is XTextParagraphFlagElement)
		{
			z0rek((XTextParagraphFlagElement)p0);
		}
	}

	private void z0rek(XTextElementList p0)
	{
		z0eek(p0);
	}

	void z0ZzZzjgh.z0eek(XTextElementList p0)
	{
		//ILSpy generated this explicit interface implementation from .override directive in z0rek
		this.z0rek(p0);
	}

	private void z0rek(XTextContainerElement p0)
	{
		XTextElementList xTextElementList = z0rek(p0.z0be(), z0fs(), z0qs());
		if (xTextElementList == null || xTextElementList.Count <= 0)
		{
			return;
		}
		using zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = xTextElementList.z0ltk();
		while (z0bpk.MoveNext())
		{
			XTextElement current = z0bpk.Current;
			if (p0 is XTextTableCellElement && current is XTextParagraphElement)
			{
				((XTextParagraphElement)current).z0tek = (XTextTableCellElement)p0;
			}
			z0is(current);
		}
	}

	public void z0us()
	{
		XTextDocument xTextDocument = base.z0yek();
		z0os();
		z0ws(xTextDocument);
		if (z0bek())
		{
			XPageSettings pageSettings = xTextDocument.PageSettings;
			if (xTextDocument.PageSettings.z0rrk())
			{
				z0nek().z0tek("titlepg");
				if (pageSettings.z0pek() > 0 && xTextDocument.z0cyk().z0fi())
				{
					z0nek().z0nek();
					z0eek(new z0ZzZzbdh(0f, 0f, xTextDocument.Width, xTextDocument.z0cyk().Height));
					z0is(xTextDocument.z0cyk());
					z0nek().z0eek();
				}
				if ((pageSettings.z0utk() > 0) & xTextDocument.z0guk().z0fi())
				{
					z0nek().z0hrk();
					z0eek(new z0ZzZzbdh(0f, 0f, xTextDocument.Width, xTextDocument.z0guk().Height));
					z0is(xTextDocument.z0guk());
					z0nek().z0iek();
				}
			}
			if (pageSettings.z0pek() > 0 && xTextDocument.z0pyk().z0fi())
			{
				z0nek().z0vek();
				z0eek(new z0ZzZzbdh(0f, 0f, xTextDocument.Width, xTextDocument.z0pyk().Height));
				z0is(xTextDocument.z0pyk());
				z0nek().z0eek();
			}
			if ((pageSettings.z0utk() > 0) & xTextDocument.z0lik().z0fi())
			{
				z0nek().z0krk();
				z0eek(new z0ZzZzbdh(0f, 0f, xTextDocument.Width, xTextDocument.z0lik().Height));
				z0is(xTextDocument.z0lik());
				z0nek().z0iek();
			}
		}
		foreach (XTextDocument item in base.z0tek())
		{
			z0krk = true;
			z0is(item.z0xyk());
		}
		z0as();
	}

	private XTextDocument z0uek()
	{
		return z0eek();
	}

	XTextDocument z0ZzZzjgh.z0eek()
	{
		//ILSpy generated this explicit interface implementation from .override directive in z0uek
		return this.z0uek();
	}

	public override void z0ys(XTextElement p0)
	{
		z0is(p0);
	}

	private void z0rek(XTextImageElement p0)
	{
		z0ZzZzxdh p1 = new z0ZzZzxdh(p0.Width, p0.Height);
		p1 = z0ZzZzrpk.z0eek(p1, GraphicsUnit.Document, GraphicsUnit.Pixel);
		if (p0.z0brk() != null)
		{
			using (z0ZzZzpmk p2 = p0.z0ny())
			{
				z0rek(p2, (int)p1.z0rek(), (int)p1.z0tek(), null, p0.z0aek());
				return;
			}
		}
		z0ZzZzpmk z0ZzZzpmk2 = p0.z0prk();
		if (z0ZzZzpmk2 != null && z0ZzZzpmk2.HasContent)
		{
			z0rek(z0ZzZzpmk2, (int)p1.z0rek(), (int)p1.z0tek(), p0.z0frk().ImageData, p0.z0aek());
		}
	}

	private void z0rek(XTextParagraphElement p0)
	{
		if (!p0.z0eek() && p0.z0rek() != null)
		{
			z0rek(p0.z0aek(), p0.z0rek());
			if (p0.z0tek != null)
			{
				z0tek("intbl");
				int num = p0.z0tek.z0gr().z0irk();
				if (num > 1)
				{
					z0tek("itap" + num);
				}
			}
		}
		using (zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = p0.z0be().z0ltk())
		{
			while (z0bpk.MoveNext())
			{
				XTextElement current = z0bpk.Current;
				z0is(current);
			}
		}
		if (!p0.z0eek())
		{
			z0yek();
		}
	}

	private void z0tek(XTextDocument p0)
	{
		z0eek(p0);
	}

	void z0ZzZzjgh.z0eek(XTextDocument p0)
	{
		//ILSpy generated this explicit interface implementation from .override directive in z0tek
		this.z0tek(p0);
	}

	private void z0rek(XTextTableCellElement p0)
	{
		z0krk = true;
		z0rek((XTextContainerElement)p0);
	}

	private void z0rek(XTextLineBreakElement p0)
	{
		z0vek();
	}

	public void z0rek(string p0)
	{
		z0nek().z0jrk();
		z0nek().z0pek().z0eek("bkmkstart", p1: true);
		z0nek().z0tek("f0");
		z0nek().z0rek(p0);
		z0nek().z0xek();
	}

	private void z0rek(XTextTDBarcodeElement p0)
	{
		z0ZzZzxdh p1 = new z0ZzZzxdh(p0.Width, p0.Height);
		p1 = z0ZzZzrpk.z0eek(p1, GraphicsUnit.Document, GraphicsUnit.Pixel);
		using z0ZzZzpmk p2 = p0.z0ny();
		z0rek(p2, (int)p1.z0rek(), (int)p1.z0tek(), null, p0.z0aek());
	}

	private void z0rek(z0ZzZzhyj p0, z0ZzZzrzj p1, int p2)
	{
		p0.z0rek(z0ZzZzlmk.z0yek(p1.z0brk));
		p0.z0rek(1);
		if (p1.z0kuk)
		{
			p0.z0eek((z0ZzZzbrj)23);
			return;
		}
		if (p2 >= 0)
		{
			StringBuilder stringBuilder = new StringBuilder();
			StringBuilder stringBuilder2 = new StringBuilder();
			for (int i = 0; i <= p2; i++)
			{
				stringBuilder.Append((char)i);
				stringBuilder.Append('.');
				stringBuilder2.Append((char)(1 + i * 2));
			}
			p0.z0rek(stringBuilder.ToString());
			p0.z0tek(stringBuilder2.ToString());
		}
		switch (p1.z0brk)
		{
		case ParagraphListStyle.ListNumberStyle:
			p0.z0eek((z0ZzZzbrj)0);
			break;
		case ParagraphListStyle.ListNumberStyleArabic1:
			p0.z0eek((z0ZzZzbrj)48);
			break;
		case ParagraphListStyle.ListNumberStyleArabic2:
			p0.z0eek((z0ZzZzbrj)46);
			break;
		case ParagraphListStyle.ListNumberStyleArabic3:
			p0.z0eek((z0ZzZzbrj)0);
			break;
		case ParagraphListStyle.BulletedList:
			p0.z0eek((z0ZzZzbrj)23);
			break;
		case ParagraphListStyle.ListNumberStyleSimpChinNum2:
			p0.z0eek((z0ZzZzbrj)26);
			break;
		case ParagraphListStyle.ListNumberStyleSimpChinNum1:
			p0.z0eek((z0ZzZzbrj)27);
			break;
		case ParagraphListStyle.ListNumberStyleTradChinNum2:
			p0.z0eek((z0ZzZzbrj)37);
			break;
		case ParagraphListStyle.ListNumberStyleTradChinNum1:
			p0.z0eek((z0ZzZzbrj)38);
			break;
		case ParagraphListStyle.ListNumberStyleZodiac1:
			p0.z0eek((z0ZzZzbrj)30);
			break;
		case ParagraphListStyle.ListNumberStyleZodiac2:
			p0.z0eek((z0ZzZzbrj)31);
			break;
		case ParagraphListStyle.ListNumberStyleLowercaseLetter:
			p0.z0eek((z0ZzZzbrj)4);
			break;
		case ParagraphListStyle.ListNumberStyleLowercaseRoman:
			p0.z0eek((z0ZzZzbrj)2);
			break;
		case ParagraphListStyle.ListNumberStyleUppercaseLetter:
			p0.z0eek((z0ZzZzbrj)3);
			break;
		case ParagraphListStyle.ListNumberStyleUppercaseRoman:
			p0.z0eek((z0ZzZzbrj)1);
			break;
		default:
			p0.z0eek((z0ZzZzbrj)0);
			break;
		}
		if (p1.z0kuk && z0nek().z0mek().z0eek("Wingdings") == null)
		{
			z0nek().z0mek().z0rek("Wingdings").z0tek(2);
		}
	}

	public void z0rek(string p0, bool p1)
	{
		z0nek().z0eek(p0, p1);
	}

	private void z0rek(XTextInputFieldElementBase p0)
	{
		string text = p0.z0srk();
		if (!string.IsNullOrEmpty(p0.StartBorderText))
		{
			text = p0.StartBorderText + text;
		}
		else if (p0.BorderVisible == DCVisibleState.AlwaysVisible)
		{
			text = "[" + text;
		}
		DocumentOptions documentOptions = p0.z0jr()?.z0vtk();
		if ((documentOptions != null && documentOptions.ViewOptions.IgnoreFieldBorderWhenPrint) || documentOptions == null)
		{
			text = string.Empty;
		}
		if (!string.IsNullOrEmpty(text))
		{
			z0rek(text, p0.z0aek());
		}
		if (p0.z0be().Count == 0)
		{
			if (p0.z0bu().OutputBackgroundTextToRTF)
			{
				string text2 = p0.z0ho();
				if (!string.IsNullOrEmpty(text2))
				{
					((DocumentContentStyle)(p0.z0jr()?.z0dik().Clone())).Color = p0.z0iu().BackgroundTextColor;
					z0rek(text2, p0.z0aek());
					z0pek();
				}
			}
		}
		else if (p0.z0ji() is XTextDocumentBodyElement || p0.z0ji() is XTextDocumentFooterElement || p0.z0ji() is XTextDocumentHeaderElement)
		{
			z0rek((XTextContainerElement)p0);
		}
		else
		{
			using zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = p0.z0be().z0ltk();
			while (z0bpk.MoveNext())
			{
				XTextElement current = z0bpk.Current;
				z0is(current);
			}
		}
		string text3 = p0.z0jrk();
		if (!string.IsNullOrEmpty(p0.EndBorderText))
		{
			text3 += p0.EndBorderText;
		}
		else if (p0.BorderVisible == DCVisibleState.AlwaysVisible)
		{
			text3 += "]";
		}
		if ((documentOptions != null && documentOptions.ViewOptions.IgnoreFieldBorderWhenPrint) || documentOptions == null)
		{
			text3 = string.Empty;
		}
		if (!string.IsNullOrEmpty(text3))
		{
			z0rek(text3, p0.z0aek());
		}
	}

	public virtual void z0ts()
	{
		z0lrk.z0zek();
	}

	public virtual bool z0rs(TextWriter p0)
	{
		z0lrk = new z0ZzZzjtj(p0, z0ss());
		z0lrk.z0eek(p0: false);
		return true;
	}

	public void z0es(Encoding p0)
	{
		z0xek_jiejie20260327142557 = p0;
	}

	private void z0rek(z0ZzZzolh p0)
	{
		z0rek(p0.Name);
		z0yek(p0.Name);
	}

	public void z0rek(z0ZzZzjtj p0)
	{
		z0lrk = p0;
	}

	public void z0tek(string p0)
	{
		z0nek().z0tek(p0);
	}

	private void z0rek(XTextContentElement p0)
	{
		zzz.z0ZzZzjik<XTextParagraphFlagElement, List<XTextElementList>> z0ZzZzjik2 = p0.z0eek(z0fs(), z0qs(), z0ZzZzndh.z0cek, p3: false);
		XTextTableCellElement xTextTableCellElement = ((XTextElement)p0).z0brk();
		if (p0 is XTextTableCellElement)
		{
			xTextTableCellElement = (XTextTableCellElement)p0;
		}
		foreach (XTextParagraphFlagElement item in z0ZzZzjik2.z0yek())
		{
			z0ZzZzrzj p1 = item.z0aek();
			List<XTextElementList> list = z0ZzZzjik2.z0tek(item);
			z0rek(p1, item);
			if ((p0 is XTextDocumentHeaderElement || p0 is XTextDocumentHeaderForFirstPageElement) && p0.z0fi() && p0.z0jr().z0rnk() && item == p0.z0be().LastElement)
			{
				z0tek("s15");
				z0tek("brdrb");
				z0tek("brdrs");
				z0tek("brdrw15");
				z0tek("brsp20");
				z0tek("brdrcf" + z0nek().z0uek().z0tek(Color.Black));
			}
			if (xTextTableCellElement != null)
			{
				z0tek("intbl");
				int num = xTextTableCellElement.z0gr().z0irk();
				if (num > 1)
				{
					z0tek("itap" + num);
				}
			}
			bool flag = false;
			foreach (XTextElementList item2 in list)
			{
				XTextElementList xTextElementList = z0ZzZzafh.z0yek(item2, z0fs());
				if (!(xTextElementList.z0krk() is XTextTableElement) && flag)
				{
					z0rek(p1, item);
				}
				using (zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = xTextElementList.z0ltk())
				{
					while (z0bpk.MoveNext())
					{
						XTextElement current2 = z0bpk.Current;
						z0is(current2);
					}
				}
				if (xTextElementList.z0krk() is XTextTableElement && xTextTableCellElement == null && ((XTextElement)item).z0pek() >= 0)
				{
					flag = true;
				}
			}
		}
	}

	private void z0rek(XTextTableElement p0)
	{
		int num = 1;
		for (XTextElement xTextElement = p0.z0ji(); xTextElement != null; xTextElement = xTextElement.z0ji())
		{
			if (xTextElement is XTextTableCellElement)
			{
				num++;
			}
		}
		int num2 = 0;
		if (z0rek() != null && !(z0rek() is XTextTableElement))
		{
			z0nek().z0tek("par");
		}
		z0nek().z0jrk();
		XTextElementList p1 = null;
		XTextElementList p2 = null;
		if (z0fs())
		{
			p0.z0pek(out p1, out p2);
		}
		else
		{
			p1 = p0.z0stk();
		}
		using (zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = p1.z0ltk())
		{
			while (z0bpk.MoveNext())
			{
				XTextTableRowElement xTextTableRowElement = (XTextTableRowElement)z0bpk.Current;
				if (!xTextTableRowElement.z0yi() || !z0rek(xTextTableRowElement, base.z0rek()))
				{
					continue;
				}
				bool p3 = p1.LastElement == xTextTableRowElement;
				XTextElementList xTextElementList = xTextTableRowElement.z0rek();
				if (z0fs())
				{
					xTextElementList = new XTextElementList();
					using zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk2 = p2.z0ltk();
					while (z0bpk2.MoveNext())
					{
						XTextTableCellElement xTextTableCellElement = (XTextTableCellElement)z0bpk2.Current;
						if (xTextTableCellElement.z0krk() == xTextTableRowElement)
						{
							xTextElementList.Add(xTextTableCellElement);
						}
					}
				}
				z0nek().z0eek(Environment.NewLine);
				num2++;
				if (num > 1)
				{
					for (int i = 0; i < xTextElementList.Count; i++)
					{
						XTextTableCellElement xTextTableCellElement2 = (XTextTableCellElement)xTextElementList[i];
						if (xTextTableCellElement2.z0yi())
						{
							z0tek("intbl");
							z0tek("itap" + num);
							z0rek(xTextTableCellElement2);
							z0tek("nestcell");
						}
						else if (xTextTableCellElement2.z0hrk().z0krk() != xTextTableCellElement2.z0krk())
						{
							z0tek("nestcell");
							i = i + xTextTableCellElement2.z0hrk().ColSpan - 1;
						}
					}
					z0nek().z0jrk();
					z0tek("nesttableprops");
					z0tek("trowd");
					z0rek(p0, xTextTableRowElement, xTextElementList, p3);
					z0tek("nestrow");
					z0nek().z0xek();
					continue;
				}
				z0tek("trowd");
				z0rek(p0, xTextTableRowElement, xTextElementList, p3);
				for (int j = 0; j < xTextElementList.Count; j++)
				{
					XTextTableCellElement xTextTableCellElement3 = (XTextTableCellElement)xTextElementList[j];
					if (xTextTableCellElement3.z0yi())
					{
						z0tek("intbl");
						z0rek(xTextTableCellElement3);
						z0tek("cell");
					}
					else if (xTextTableCellElement3.z0drk().Visible && xTextTableCellElement3.z0hrk().z0krk() != xTextTableCellElement3.z0krk())
					{
						z0tek("cell");
						j = j + xTextTableCellElement3.z0hrk().ColSpan - 1;
					}
				}
				z0tek("row");
			}
		}
		z0nek().z0xek();
		z0tek("pard");
		z0rek((XTextElement)p0);
	}

	public void z0rek(string p0, z0ZzZzrzj p1)
	{
		z0nek().z0tek("plain");
		int num = 0;
		string z0tyk = p1.z0tyk;
		num = z0nek().z0mek().z0tek(z0tyk);
		if (num >= 0)
		{
			z0nek().z0tek("f" + num);
		}
		if (p1.z0gyk)
		{
			z0nek().z0tek("b");
		}
		if (p1.z0vtk_jiejie20260327142557)
		{
			z0nek().z0tek("i");
		}
		if (p1.z0uyk)
		{
			z0nek().z0tek("ul");
		}
		if (p1.z0yyk)
		{
			z0nek().z0tek("strike");
		}
		z0nek().z0tek("fs" + Convert.ToInt32(p1.z0wtk * 2f));
		num = z0nek().z0uek().z0rek(p1.z0ark);
		if (num >= 0)
		{
			z0nek().z0tek("chcbpat" + Convert.ToString(num + 1));
		}
		Color p2 = p1.z0ztk;
		if (p2.A == 0)
		{
			p2 = p1.z0bek;
		}
		if (!p1.z0xtk.IsEmpty)
		{
			p2 = p1.z0xtk;
		}
		num = z0nek().z0uek().z0rek(p2);
		if (num >= 0)
		{
			z0nek().z0tek("cf" + Convert.ToString(num + 1));
		}
		if (p1.z0gtk)
		{
			z0nek().z0tek("sub");
		}
		if (p1.z0euk)
		{
			z0nek().z0tek("super");
		}
		z0nek().z0rek(p0);
		if (p1.z0gtk)
		{
			z0nek().z0tek("sub0");
		}
		if (p1.z0euk)
		{
			z0nek().z0tek("super0");
		}
		if (p1.z0gyk)
		{
			z0nek().z0tek("b0");
		}
		if (p1.z0vtk_jiejie20260327142557)
		{
			z0nek().z0tek("i0");
		}
		if (p1.z0uyk)
		{
			z0nek().z0tek("ul0");
		}
		if (p1.z0yyk)
		{
			z0nek().z0tek("strike0");
		}
		z0rek(p1, p1: false);
	}

	public void z0rek(z0ZzZzrzj p0, XTextParagraphFlagElement p1)
	{
		if (z0krk)
		{
			z0krk = false;
			z0nek().z0pek().z0yek(Environment.NewLine);
		}
		else
		{
			z0nek().z0tek("par");
		}
		if (z0grk != null)
		{
			if (z0grk.z0brk != ParagraphListStyle.None)
			{
				z0nek().z0tek("pard");
			}
			else
			{
				z0nek().z0tek("pard");
			}
		}
		else
		{
			z0nek().z0tek("pard");
		}
		z0nek().z0tek("plain");
		if (p1.z0cek() >= 0)
		{
			z0nek().z0tek("ls" + p1.z0cek());
		}
		int num = p1.z0eek();
		if (num < 0)
		{
			num = p0.z0ttk;
		}
		if (num >= 0)
		{
			z0nek().z0tek("outlinelevel" + num);
			if (p0.z0fyk)
			{
				z0nek().z0tek("ilvl" + Convert.ToString(num));
			}
		}
		z0rek(p0, p1: true);
		if (p0.z0tuk == DocumentContentAlignment.Left)
		{
			z0nek().z0tek("ql");
		}
		if (p0.z0tuk == DocumentContentAlignment.Center)
		{
			z0nek().z0tek("qc");
		}
		else if (p0.z0tuk == DocumentContentAlignment.Right)
		{
			z0nek().z0tek("qr");
		}
		else if (p0.z0tuk == DocumentContentAlignment.Justify)
		{
			z0nek().z0tek("qj");
		}
		else if (p0.z0tuk == DocumentContentAlignment.Distribute)
		{
			z0nek().z0tek("qd");
		}
		if (p0.z0pyk != 0f)
		{
			z0nek().z0tek("fi" + z0rek(p0.z0pyk));
		}
		else
		{
			z0nek().z0tek("fi0");
		}
		if (p0.z0hyk != 0f)
		{
			z0nek().z0tek("li" + z0rek(p0.z0hyk));
		}
		else
		{
			z0nek().z0tek("li0");
		}
		if ((double)p0.z0irk > 0.1)
		{
			z0tek("sb" + z0rek(p0.z0irk));
		}
		if ((double)p0.z0zyk > 0.1)
		{
			z0tek("sa" + z0rek(p0.z0zyk));
		}
		switch (p0.z0cyk)
		{
		case LineSpacingStyle.SpaceSingle:
			z0tek("slmult0");
			break;
		case LineSpacingStyle.SpaceSpecify:
			z0tek("sl" + z0rek(p0.z0itk));
			break;
		case LineSpacingStyle.SpaceMultiple:
			z0tek("slmult1");
			z0tek("sl" + Convert.ToInt32(240f * p0.z0itk));
			break;
		case LineSpacingStyle.Space1pt5:
			z0tek("slmult1");
			z0tek("sl" + Convert.ToInt32(360.0));
			break;
		case LineSpacingStyle.SpaceDouble:
			z0tek("slmult1");
			z0tek("sl" + Convert.ToInt32(480));
			break;
		}
		z0grk = p0;
	}

	private bool z0rek(XTextTableRowElement p0, z0ZzZzbdh p1)
	{
		if (p1.z0bek())
		{
			return true;
		}
		z0ZzZzbdh p2 = p0.z0qyk();
		z0ZzZzbdh z0ZzZzbdh2 = z0ZzZzbdh.z0tek(p1, p2);
		if (!z0ZzZzbdh2.z0bek() && z0ZzZzbdh2.z0iek() > 4f)
		{
			return true;
		}
		return false;
	}

	public void z0ws(XTextDocument p0)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("document");
		}
		z0nek().z0eek(p0: false);
		z0nek().z0rek()["title"] = p0.z0ipk().z0mek();
		z0nek().z0rek()["subject"] = p0.z0ipk().z0mrk();
		z0nek().z0rek()["author"] = p0.z0ipk().z0trk();
		z0nek().z0rek()["creatim"] = p0.z0ipk().z0nrk();
		z0nek().z0rek()["comment"] = p0.z0ipk().z0ark();
		z0nek().z0rek()["operator"] = p0.z0ipk().z0ork();
		z0nek().z0lrk();
		XPageSettings pageSettings = p0.PageSettings;
		z0nek().z0tek("paperw" + z0rek(pageSettings.z0drk()));
		z0nek().z0tek("paperh" + z0rek(pageSettings.z0qrk()));
		if (pageSettings.z0ork())
		{
			z0nek().z0tek("landscape");
		}
		z0nek().z0tek("margl" + z0rek(pageSettings.z0vtk()));
		z0nek().z0tek("margr" + z0rek(pageSettings.z0xrk()));
		int num = 0;
		if (z0tek())
		{
			num = 80;
		}
		if (z0bek())
		{
			float num2 = pageSettings.z0bek();
			if (base.z0yek().z0pyk().z0fi())
			{
				num2 = Math.Max(num2, pageSettings.z0atk() + base.z0yek().z0pyk().Height);
			}
			float num3 = pageSettings.z0qtk();
			if (base.z0yek().z0lik().z0fi())
			{
				num3 = Math.Max(pageSettings.BottomMargin, pageSettings.z0stk());
			}
			z0nek().z0tek("margt" + z0rek(num2 - (float)num));
			z0nek().z0tek("margb" + z0rek(num3 - (float)num));
			if (pageSettings.z0utk() > 0)
			{
				z0nek().z0tek("footery" + z0rek(pageSettings.z0stk() - (float)num));
			}
			if (pageSettings.z0pek() > 0)
			{
				z0nek().z0tek("headery" + z0rek(pageSettings.z0atk() - (float)num));
			}
		}
		else
		{
			z0nek().z0tek("margt" + z0rek(pageSettings.z0bek() - (float)num));
			z0nek().z0tek("margb" + z0rek(pageSettings.z0qtk() - (float)num));
		}
	}

	public void z0iek()
	{
		z0nek().z0jrk();
	}

	public new int z0oek()
	{
		return z0nek().z0pek().z0iek();
	}

	private void z0rek(XTextCharElement p0)
	{
		if (!p0.z0oek() || p0.z0jr() == null || p0.z0bu().OutputBackgroundTextToRTF)
		{
			z0ZzZzrzj z0ZzZzrzj2 = p0.z0aek();
			string p1 = p0.z0ti();
			if (p0.z0oek())
			{
				XTextInputFieldElement xTextInputFieldElement = (XTextInputFieldElement)p0.z0ji();
				z0ZzZzrzj2.z0xtk = ((XTextFieldElementBase)xTextInputFieldElement).z0eek();
				z0rek(p1, z0ZzZzrzj2);
				z0pek();
				z0ZzZzrzj2.z0xtk = Color.Empty;
			}
			else
			{
				z0ZzZzrzj2.z0xtk = Color.Empty;
				z0rek(p1, z0ZzZzrzj2);
				z0pek();
			}
		}
	}

	public void z0yek(string p0)
	{
		z0nek().z0jrk();
		z0nek().z0pek().z0eek("bkmkend", p1: true);
		z0nek().z0tek("f0");
		z0nek().z0rek(p0);
		z0nek().z0xek();
	}

	public void z0pek()
	{
	}

	private void z0rek(XTextFieldBorderElement p0)
	{
		XTextInputFieldElementBase xTextInputFieldElementBase = (XTextInputFieldElementBase)p0.z0ji();
		string text = xTextInputFieldElementBase.z0srk();
		string text2 = xTextInputFieldElementBase.z0jrk();
		DocumentOptions documentOptions = xTextInputFieldElementBase.z0jr().z0vtk();
		DocumentContentStyle documentContentStyle = xTextInputFieldElementBase.z0aek().z0yek();
		documentContentStyle.Color = documentOptions.ViewOptions.FieldBorderColor;
		string p1 = string.Empty;
		if (p0 == ((XTextFieldElementBase)xTextInputFieldElementBase).z0jrk())
		{
			string text3 = string.Empty;
			string text4 = string.Empty;
			if (text != null && text.Length > 0)
			{
				text3 = text;
			}
			if (xTextInputFieldElementBase.StartBorderText != null && xTextInputFieldElementBase.StartBorderText.Length > 0)
			{
				text4 = xTextInputFieldElementBase.StartBorderText;
				if ((documentOptions != null && documentOptions.ViewOptions.IgnoreFieldBorderWhenPrint) || documentOptions == null)
				{
					text4 = string.Empty;
				}
			}
			p1 = text4 + text3;
		}
		else if (p0 == ((XTextFieldElementBase)xTextInputFieldElementBase).z0tek())
		{
			string text5 = string.Empty;
			string text6 = string.Empty;
			if (text2 != null && text2.Length > 0)
			{
				text5 = text2;
			}
			if (xTextInputFieldElementBase.EndBorderText != null && xTextInputFieldElementBase.EndBorderText.Length > 0)
			{
				text6 = xTextInputFieldElementBase.EndBorderText;
				if ((documentOptions != null && documentOptions.ViewOptions.IgnoreFieldBorderWhenPrint) || documentOptions == null)
				{
					text6 = string.Empty;
				}
			}
			p1 = text5 + text6;
		}
		z0rek(p1, documentContentStyle.z0eek_jiejie20260327142557());
	}

	public bool z0qs()
	{
		return z0zek;
	}

	private void z0rek(XTextStringElement p0)
	{
		if (!p0.z0mek() || p0.z0jr() == null || p0.z0bu().OutputBackgroundTextToRTF)
		{
			z0ZzZzrzj z0ZzZzrzj2 = p0.z0aek();
			string p1 = p0.z0rek(z0fs());
			if (p0.z0mek())
			{
				XTextInputFieldElement xTextInputFieldElement = (XTextInputFieldElement)p0.z0ji();
				z0ZzZzrzj2.z0xtk = ((XTextFieldElementBase)xTextInputFieldElement).z0eek();
				z0rek(p1, z0ZzZzrzj2);
				z0pek();
				z0ZzZzrzj2.z0xtk = Color.Empty;
			}
			else
			{
				z0ZzZzrzj2.z0xtk = Color.Empty;
				z0rek(p1, z0ZzZzrzj2);
				z0pek();
			}
		}
	}

	private void z0rek(XTextTableElement p0, XTextTableRowElement p1, XTextElementList p2, bool p3)
	{
		z0nek().z0tek("trgaph108");
		if (p1.z0cek() != 0f)
		{
			z0nek().z0tek("trrh" + z0rek((int)((double)p1.z0cek() - 12.5)));
		}
		float num = 0f;
		using (zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = p2.z0ltk())
		{
			while (z0bpk.MoveNext())
			{
				XTextTableCellElement xTextTableCellElement = (XTextTableCellElement)z0bpk.Current;
				num += xTextTableCellElement.Width;
			}
		}
		float num2 = 0f;
		XTextTableCellElement xTextTableCellElement2 = (XTextTableCellElement)p2[0];
		for (int i = 0; i < xTextTableCellElement2.z0xek(); i++)
		{
			num2 += p0.z0srk()[i].Width;
		}
		z0nek().z0tek("trwWidth" + z0rek(num));
		if (p1.z0pek())
		{
			z0tek("trhdr");
		}
		if (p3)
		{
			z0tek("lastrow");
		}
		float num3 = 0f;
		for (int j = 0; j < p2.Count; j++)
		{
			XTextTableCellElement xTextTableCellElement3 = (XTextTableCellElement)p2[j];
			z0nek().z0pek().z0yek(Environment.NewLine);
			if (xTextTableCellElement3.z0yi())
			{
				if (xTextTableCellElement3.RowSpan > 1)
				{
					z0tek("clvmgf");
				}
				z0tek(xTextTableCellElement3);
				if (xTextTableCellElement3.z0yi())
				{
					z0ZzZzrzj z0ZzZzrzj2 = xTextTableCellElement3.z0aek();
					if (z0ZzZzrzj2.z0srk == VerticalAlignStyle.Top)
					{
						z0nek().z0tek("clvertalt");
					}
					else if (z0ZzZzrzj2.z0srk == VerticalAlignStyle.Middle)
					{
						z0nek().z0tek("clvertalc");
					}
					else if (z0ZzZzrzj2.z0srk == VerticalAlignStyle.Bottom)
					{
						z0nek().z0tek("clvertalb");
					}
					int num4 = z0nek().z0uek().z0rek(z0ZzZzrzj2.z0ark);
					if (num4 >= 0)
					{
						z0tek("clcbpat" + Convert.ToString(num4 + 1));
					}
					z0tek("clpadt" + z0rek(z0ZzZzrzj2.z0ryk));
					z0tek("clpadft3");
					z0tek("clpadl" + z0rek(z0ZzZzrzj2.z0quk));
					z0tek("clpadfl3");
					z0tek("clpadr" + z0rek(z0ZzZzrzj2.z0ptk));
					z0tek("clpadfr3");
					z0tek("clpadb" + z0rek(z0ZzZzrzj2.z0xrk));
					z0tek("clpadfb3");
				}
				num3 += xTextTableCellElement3.Width;
				z0nek().z0tek("cellx" + z0rek(xTextTableCellElement3.z0it() - num2 + xTextTableCellElement3.Width));
				z0tek("clwWidth" + z0rek(xTextTableCellElement3.Width));
			}
			else if (xTextTableCellElement3.z0drk().Visible && xTextTableCellElement3.z0hrk().z0krk() != xTextTableCellElement3.z0krk())
			{
				z0tek("clvmrg");
				z0tek(xTextTableCellElement3);
				z0tek("cellx" + z0rek(xTextTableCellElement3.z0it() - num2 + xTextTableCellElement3.z0hrk().Width));
				j = j + xTextTableCellElement3.z0hrk().ColSpan - 1;
			}
		}
	}

	private void z0rek(XTextDocumentContentElement p0)
	{
		z0krk = true;
		z0eek(new z0ZzZzbdh(0f, 0f, p0.z0jr().Width, p0.Height));
		z0rek((XTextContentElement)p0);
		z0krk = false;
	}

	private void z0rek(XTextPageInfoElement p0)
	{
		int num = z0oek();
		z0iek();
		z0tek("field");
		z0iek();
		z0rek("fldinst", p1: true);
		z0iek();
		if (p0.ValueType == PageInfoValueType.PageIndex || p0.ValueType == PageInfoValueType.LocalPageIndex)
		{
			z0nek().z0eek("PAGE");
		}
		else
		{
			z0nek().z0eek("NUMPAGES");
		}
		z0mek();
		z0mek();
		z0iek();
		z0tek("fldrslt");
		z0iek();
		z0rek(p0.z0rek(), p0.z0aek());
		z0pek();
		z0mek();
		z0mek();
		z0mek();
		num = z0oek() - num;
	}

	private void z0tek(XTextTableCellElement p0)
	{
		z0ZzZzrzj z0ZzZzrzj2 = p0.z0aek();
		if (!(z0ZzZzrzj2.z0erk > 0f))
		{
			return;
		}
		int num = z0rek(z0ZzZzrzj2.z0erk);
		if (num < 1)
		{
			num = 1;
		}
		if (num > 75)
		{
			num = 75;
		}
		if (z0ZzZzrzj2.z0rrk && z0ZzZzrzj2.z0myk.A != 0)
		{
			z0tek("clbrdrl");
			if (num != 1)
			{
				z0tek("brdrw" + num);
			}
			z0tek("brdrcf" + z0nek().z0uek().z0tek(z0ZzZzrzj2.z0nek));
			z0nek().z0eek(z0ZzZzrzj2.z0guk);
		}
		if (z0ZzZzrzj2.z0wyk && z0ZzZzrzj2.z0myk.A != 0)
		{
			z0tek("clbrdrt");
			if (num != 1)
			{
				z0tek("brdrw" + num);
			}
			z0tek("brdrcf" + z0nek().z0uek().z0tek(z0ZzZzrzj2.z0myk));
			z0nek().z0eek(z0ZzZzrzj2.z0guk);
		}
		if (z0ZzZzrzj2.z0etk && z0ZzZzrzj2.z0grk.A != 0)
		{
			z0tek("clbrdrr");
			if (num != 1)
			{
				z0tek("brdrw" + num);
			}
			z0tek("brdrcf" + z0nek().z0uek().z0tek(z0ZzZzrzj2.z0grk));
			z0nek().z0eek(z0ZzZzrzj2.z0guk);
		}
		if (z0ZzZzrzj2.z0mrk && z0ZzZzrzj2.z0trk.A != 0)
		{
			z0tek("clbrdrb");
			if (num != 1)
			{
				z0tek("brdrw" + num);
			}
			z0tek("brdrcf" + z0nek().z0uek().z0tek(z0ZzZzrzj2.z0trk));
			z0nek().z0eek(z0ZzZzrzj2.z0guk);
		}
	}

	public void z0rek(z0ZzZzpmk p0, int p1, int p2, byte[] p3, z0ZzZzrzj p4)
	{
		if (p3 != null || p0 != null)
		{
			if (p3 == null)
			{
				p3 = p0.z0rek();
			}
			z0nek().z0jrk();
			z0nek().z0tek("pict");
			z0nek().z0tek("jpegblip");
			z0nek().z0tek("picscalex" + Convert.ToInt32((double)p1 * 100.0 / (double)p0.Size.z0rek()));
			z0nek().z0tek("picscaley" + Convert.ToInt32((double)p2 * 100.0 / (double)p0.Size.z0tek()));
			z0nek().z0tek("picwgoal" + Convert.ToString(p0.Size.z0rek() * 15));
			z0nek().z0tek("pichgoal" + Convert.ToString(p0.Size.z0tek() * 15));
			z0nek().z0pek().z0eek(p3);
			z0nek().z0xek();
		}
	}

	public void z0as()
	{
		z0lrk.z0yek();
	}

	private void z0rek(XTextShapeInputFieldElement p0)
	{
		if (p0.EditMode)
		{
			z0rek((XTextInputFieldElementBase)p0);
			return;
		}
		z0ZzZzxdh p1 = new z0ZzZzxdh(p0.Width, p0.Height);
		p1 = z0ZzZzrpk.z0eek(p1, GraphicsUnit.Document, GraphicsUnit.Pixel);
		using z0ZzZzpmk p2 = p0.z0ny();
		z0rek(p2, (int)p1.z0rek(), (int)p1.z0tek(), null, p0.z0aek());
	}

	public void z0mek()
	{
		z0nek().z0xek();
	}

	public z0ZzZzjtj z0nek()
	{
		return z0lrk;
	}

	public void z0rek(bool p0)
	{
		z0jrk = p0;
	}

	private void z0rek(XTextCheckBoxElementBase p0)
	{
		string empty = string.Empty;
		empty = ((p0.z0lrk() == CheckBoxVisualStyle.CheckBox || p0.z0lrk() == CheckBoxVisualStyle.SystemCheckBox) ? ((!p0.Checked) ? "□" : "■") : ((!p0.Checked) ? "○" : "●"));
		string p1 = (p0.CheckAlignLeft ? (empty + p0.Text) : (p0.Text + empty));
		z0rek(p1, p0.z0aek());
	}

	public int z0rek(float p0)
	{
		return z0ZzZzrpk.z0eek(p0, GraphicsUnit.Document);
	}

	public void z0rek(XTextElement p0)
	{
		z0cek = p0;
	}

	public Encoding z0ss()
	{
		return z0xek_jiejie20260327142557;
	}

	public void z0tek(bool p0)
	{
		z0hrk = p0;
	}

	public bool z0bek()
	{
		return z0jrk;
	}

	public void z0vek()
	{
		z0nek().z0tek("line");
	}

	public void z0ds(bool p0)
	{
		z0zek = p0;
	}

	private void z0rek(XTextSignImageElement p0)
	{
		z0ZzZzxdh p1 = new z0ZzZzxdh(p0.Width, p0.Height);
		p1 = z0ZzZzrpk.z0eek(p1, GraphicsUnit.Document, GraphicsUnit.Pixel);
		using z0ZzZzpmk p2 = p0.z0ny();
		z0rek(p2, (int)p1.z0rek(), (int)p1.z0tek(), null, p0.z0aek());
	}

	private void z0eek(List<XTextParagraphFlagElement> p0, z0ZzZzjyj p1, int p2)
	{
		if (p0 == null || p0.Count == 0)
		{
			return;
		}
		int p3 = 0;
		int num = -1;
		foreach (XTextParagraphFlagElement item in p0)
		{
			if (item.z0tek() >= 0)
			{
				item.z0eek(p2);
			}
			else
			{
				item.z0eek(-1);
			}
			if (item.z0zek() == 1)
			{
				num++;
				if (num > 0)
				{
					p1 = new z0ZzZzjyj();
					p1.z0tek(z0nek().z0oek().Count + 1);
					z0nek().z0oek().Add(p1);
					p3 = 0;
				}
				z0ZzZzhyj z0ZzZzhyj2 = p1.z0yek(p2);
				z0ZzZzhyj2.z0rek(1);
				z0rek(z0ZzZzhyj2, item.z0aek(), p2);
				if (item.z0aek().z0kuk && z0nek().z0mek().z0eek("Wingdings") == null)
				{
					z0nek().z0mek().z0rek("Wingdings").z0tek(2);
				}
				bool flag = false;
				foreach (z0ZzZzgyj item2 in z0nek().z0tek())
				{
					if (item2.z0eek() == p1.z0uek())
					{
						p3 = item2.z0tek();
						flag = true;
						break;
					}
				}
				if (!flag)
				{
					z0ZzZzgyj z0ZzZzgyj2 = new z0ZzZzgyj();
					z0ZzZzgyj2.z0rek_jiejie20260327142557(z0nek().z0tek().Count + 1);
					z0ZzZzgyj2.z0tek(p1.z0uek());
					z0nek().z0tek().Add(z0ZzZzgyj2);
					p3 = z0ZzZzgyj2.z0tek();
				}
			}
			item.z0tek(p3);
			z0eek(item.z0bek(), p1, p2 + 1);
		}
	}
}
