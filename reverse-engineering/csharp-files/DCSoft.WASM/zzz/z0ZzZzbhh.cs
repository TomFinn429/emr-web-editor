using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using DCSoft.Drawing;
using DCSoft.Printing;
using DCSoft.Writer;
using DCSoft.Writer.Dom;
using DCSystem_Drawing;
using DCSystem_Drawing.Printing;

namespace zzz;

public class z0ZzZzbhh : z0ZzZzkgh
{
	private bool z0tek = true;

	private bool z0yek = true;

	private z0ZzZzgtj z0uek = new z0ZzZzgtj();

	private string z0iek = z0ZzZzimk.DefaultFontName;

	private bool z0oek;

	public void z0eek(string p0)
	{
		z0iek = p0;
	}

	private void z0eek(z0ZzZzftj p0, XTextDocument p1, XTextElementList p2, z0ZzZzmrj p3)
	{
		if (p3 == null)
		{
			p3 = new z0ZzZzmrj();
		}
		foreach (z0ZzZzftj item in p0.z0uek())
		{
			if (item is z0ZzZzetj)
			{
				z0ZzZzetj z0ZzZzetj2 = (z0ZzZzetj)item;
				if (!z0ZzZzetj2.z0eek())
				{
					continue;
				}
				if (z0ZzZzetj2.z0rek() == (z0ZzZznrj)3)
				{
					XTextDocumentHeaderForFirstPageElement xTextDocumentHeaderForFirstPageElement = (XTextDocumentHeaderForFirstPageElement)p2.z0oek(typeof(XTextDocumentHeaderForFirstPageElement));
					if (xTextDocumentHeaderForFirstPageElement == null)
					{
						xTextDocumentHeaderForFirstPageElement = new XTextDocumentHeaderForFirstPageElement();
						p2.Add(xTextDocumentHeaderForFirstPageElement);
					}
					xTextDocumentHeaderForFirstPageElement.z0be().Clear();
					p1.PageSettings.z0mek((int)(z0ZzZzrpk.z0yek(z0uek.z0cek(), GraphicsUnit.Inch) * 100.0));
					z0eek(item, p1, xTextDocumentHeaderForFirstPageElement.z0be(), p3);
				}
				else
				{
					XTextDocumentHeaderElement xTextDocumentHeaderElement = (XTextDocumentHeaderElement)p2.z0oek(typeof(XTextDocumentHeaderElement));
					if (xTextDocumentHeaderElement == null)
					{
						xTextDocumentHeaderElement = new XTextDocumentHeaderElement();
						p2.Add(xTextDocumentHeaderElement);
					}
					xTextDocumentHeaderElement.z0be().Clear();
					p1.PageSettings.z0mek((int)(z0ZzZzrpk.z0yek(z0uek.z0cek(), GraphicsUnit.Inch) * 100.0));
					z0eek(item, p1, xTextDocumentHeaderElement.z0be(), p3);
				}
			}
			else if (item is z0ZzZzwtj)
			{
				z0ZzZzwtj z0ZzZzwtj2 = (z0ZzZzwtj)item;
				if (!z0ZzZzwtj2.z0rek())
				{
					continue;
				}
				if (z0ZzZzwtj2.z0eek() == (z0ZzZznrj)3)
				{
					XTextDocumentFooterForFirstPageElement xTextDocumentFooterForFirstPageElement = (XTextDocumentFooterForFirstPageElement)p2.z0oek(typeof(XTextDocumentFooterForFirstPageElement));
					if (xTextDocumentFooterForFirstPageElement == null)
					{
						xTextDocumentFooterForFirstPageElement = new XTextDocumentFooterForFirstPageElement();
						p2.Add(xTextDocumentFooterForFirstPageElement);
					}
					xTextDocumentFooterForFirstPageElement.z0be().Clear();
					p1.PageSettings.z0iek((int)(z0ZzZzrpk.z0yek(z0uek.z0grk(), GraphicsUnit.Inch) * 100.0));
					z0eek(item, p1, xTextDocumentFooterForFirstPageElement.z0be(), p3);
				}
				else
				{
					XTextDocumentFooterElement xTextDocumentFooterElement = (XTextDocumentFooterElement)p2.z0oek(typeof(XTextDocumentFooterElement));
					if (xTextDocumentFooterElement == null)
					{
						xTextDocumentFooterElement = new XTextDocumentFooterElement();
						p2.Add(xTextDocumentFooterElement);
					}
					xTextDocumentFooterElement.z0be().Clear();
					p1.PageSettings.z0iek((int)(z0ZzZzrpk.z0yek(z0uek.z0grk(), GraphicsUnit.Inch) * 100.0));
					z0eek(item, p1, xTextDocumentFooterElement.z0be(), p3);
				}
			}
			else if (item is z0ZzZzitj)
			{
				z0ZzZzitj z0ZzZzitj2 = (z0ZzZzitj)item;
				DocumentContentStyle style = z0eek(z0ZzZzitj2.z0tek(), GraphicsUnit.Document, z0uek);
				z0eek(item, p1, p2, z0ZzZzitj2.z0tek());
				if (!z0ZzZzitj2.z0eek() || z0ms())
				{
					XTextParagraphFlagElement xTextParagraphFlagElement = new XTextParagraphFlagElement();
					xTextParagraphFlagElement.z0oek(p1.z0gnk().GetStyleIndex(style));
					p2.Add(xTextParagraphFlagElement);
				}
			}
			else if (item is z0ZzZzctj)
			{
				z0ZzZzctj z0ZzZzctj2 = (z0ZzZzctj)item;
				if (z0ZzZzctj2.z0eek().z0rrk() || z0ZzZzctj2.z0rek() == null || z0ZzZzctj2.z0rek().Length <= 0)
				{
					continue;
				}
				if (p3 != null && p3.z0irk() >= 0 && z0ZzZzctj2.z0eek() != null)
				{
					z0ZzZzctj2.z0eek().z0oek(p3.z0irk());
				}
				DocumentContentStyle documentContentStyle = z0eek(z0ZzZzctj2.z0eek(), GraphicsUnit.Document, z0uek);
				string text = z0ZzZzctj2.z0rek();
				if (text.Length > 1 && (text[0] == '○' || text[0] == '□' || text[0] == '△' || text[0] == '◇'))
				{
					bool flag = false;
					int num = p0.z0uek().IndexOf(z0ZzZzctj2);
					if (num < p0.z0uek().Count - 1)
					{
						z0ZzZzftj z0ZzZzftj2 = p0.z0uek()[num + 1];
						if (z0ZzZzftj2 is z0ZzZzatj)
						{
							z0ZzZzatj z0ZzZzatj2 = (z0ZzZzatj)z0ZzZzftj2;
							if (z0ZzZzatj2.z0tek() != null && z0ZzZzatj2.z0tek().Contains("eq \\o\\ac"))
							{
								flag = true;
							}
						}
					}
					if (flag)
					{
						if (text[0] == '○')
						{
							documentContentStyle.CharacterCircle = CharacterCircleStyles.Circle;
						}
						else if (text[0] == '□' || text[0] == '△' || text[0] == '◇')
						{
							documentContentStyle.CharacterCircle = CharacterCircleStyles.Rectangle;
						}
						text = text.Substring(1);
					}
				}
				int styleIndex = p1.z0gnk().GetStyleIndex(documentContentStyle);
				((zzz.z0ZzZzkuk<XTextElement>)p2).z0tek((zzz.z0ZzZzkuk<XTextElement>)p1.z0bek(text, styleIndex));
			}
			else if (item is z0ZzZzrtj)
			{
				z0ZzZzrtj z0ZzZzrtj2 = (z0ZzZzrtj)item;
				XTextImageElement xTextImageElement = new XTextImageElement();
				xTextImageElement.z0bt(p1);
				xTextImageElement.z0rek(new z0ZzZzpmk(z0ZzZzrtj2.z0uek()));
				DocumentContentStyle style2 = z0eek(z0ZzZzrtj2.z0nek(), GraphicsUnit.Document, z0uek);
				xTextImageElement.z0oek(p1.z0gnk().GetStyleIndex(style2));
				xTextImageElement.Width = z0ZzZzrpk.z0eek(z0ZzZzrtj2.z0iek(), GraphicsUnit.Document);
				xTextImageElement.Height = z0ZzZzrpk.z0eek(z0ZzZzrtj2.z0rek(), GraphicsUnit.Document);
				z0ZzZzftj z0ZzZzftj3 = ((z0ZzZzftj)z0ZzZzrtj2).z0eek();
				int num2 = 0;
				while (z0ZzZzftj3 != null && num2++ < 4)
				{
					if (z0ZzZzftj3 is z0ZzZzotj)
					{
						z0ZzZzotj z0ZzZzotj2 = (z0ZzZzotj)z0ZzZzftj3;
						xTextImageElement.Width = z0ZzZzrpk.z0eek(z0ZzZzotj2.z0oek(), GraphicsUnit.Document);
						xTextImageElement.Height = z0ZzZzrpk.z0eek(z0ZzZzotj2.z0rek(), GraphicsUnit.Document);
						break;
					}
					z0ZzZzftj3 = z0ZzZzftj3.z0eek();
				}
				p2.Add(xTextImageElement);
			}
			else if (item is z0ZzZzytj)
			{
				z0ZzZzytj z0ZzZzytj2 = (z0ZzZzytj)item;
				if (z0ZzZzytj2.z0pek() != null && z0ZzZzytj2.z0pek().StartsWith(z0ZzZzkfh.z0frk))
				{
					Type type = Type.GetType(z0ZzZzytj2.z0pek().Substring(z0ZzZzkfh.z0frk.Length), true, true);
					if (type != null)
					{
						if (z0ZzZzytj2.z0mek() != null && z0ZzZzytj2.z0mek().Length != 0)
						{
							StringReader p4 = new StringReader(Encoding.UTF8.GetString(z0ZzZzytj2.z0mek()));
							XTextElement xTextElement = (XTextElement)new z0ZzZzehh().z0wq(p4);
							xTextElement?.z0bt(p1);
							p2.Add(xTextElement);
						}
						else
						{
							XTextElement xTextElement2 = (XTextElement)Activator.CreateInstance(type);
							xTextElement2.z0bt(p1);
							p2.Add(xTextElement2);
						}
					}
					continue;
				}
				foreach (z0ZzZzftj item2 in item.z0uek())
				{
					if (item2 is z0ZzZzdtj)
					{
						z0ZzZzdtj z0ZzZzdtj2 = (z0ZzZzdtj)item2;
						if (z0ZzZzdtj2.z0eek() == "result")
						{
							z0eek(z0ZzZzdtj2, p1, p2, p3.z0yrk());
							break;
						}
					}
				}
			}
			else if (item is z0ZzZzatj)
			{
				z0ZzZzatj z0ZzZzatj3 = (z0ZzZzatj)item;
				if (z0ZzZzatj3.z0eek() != null)
				{
					string text2 = z0ZzZzatj3.z0tek();
					if (text2 == "PAGE")
					{
						XTextPageInfoElement xTextPageInfoElement = new XTextPageInfoElement();
						xTextPageInfoElement.ValueType = PageInfoValueType.PageIndex;
						p2.Add(xTextPageInfoElement);
					}
					else if (text2 == "NUMPAGES")
					{
						XTextPageInfoElement xTextPageInfoElement2 = new XTextPageInfoElement();
						xTextPageInfoElement2.ValueType = PageInfoValueType.NumOfPages;
						p2.Add(xTextPageInfoElement2);
					}
					else
					{
						z0eek(z0ZzZzatj3.z0eek(), p1, p2, p3.z0yrk());
					}
				}
			}
			else if (item is z0ZzZzmtj)
			{
				z0ZzZzmtj z0ZzZzmtj2 = (z0ZzZzmtj)item;
				if (z0ZzZzmtj2.z0uek().Count == 0 || z0ZzZzmtj2.z0eek().Count == 0)
				{
					continue;
				}
				XTextTableElement xTextTableElement = new XTextTableElement();
				xTextTableElement.CompressOwnerLineSpacing = true;
				p2.Add(xTextTableElement);
				float num3 = 0f;
				foreach (z0ZzZzbtj item3 in z0ZzZzmtj2.z0eek())
				{
					XTextTableColumnElement xTextTableColumnElement = xTextTableElement.z0vek();
					xTextTableColumnElement.z0nu(xTextTableElement);
					xTextTableColumnElement.Width = z0ZzZzrpk.z0eek(item3.z0eek(), GraphicsUnit.Document);
					num3 += xTextTableColumnElement.Width;
					xTextTableElement.z0srk().Add(xTextTableColumnElement);
				}
				float num4 = p1.PageSettings.z0prk();
				if (num3 > num4 && (double)num3 < (double)num4 * 1.1)
				{
					float num5 = num4 / num3;
					using zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = xTextTableElement.z0srk().z0ltk();
					while (z0bpk.MoveNext())
					{
						((XTextTableColumnElement)z0bpk.Current).Width *= num5;
					}
				}
				foreach (z0ZzZzvtj item4 in z0ZzZzmtj2.z0uek())
				{
					XTextTableRowElement xTextTableRowElement = xTextTableElement.z0nrk();
					xTextTableRowElement.Height = z0ZzZzrpk.z0eek(item4.z0oek(), GraphicsUnit.Document);
					DocumentContentStyle documentContentStyle2 = new DocumentContentStyle();
					documentContentStyle2.BackgroundColor = item4.z0yek().z0ork();
					xTextTableRowElement.z0oek(p1.z0gnk().GetStyleIndex(documentContentStyle2));
					xTextTableElement.z0stk().Add(xTextTableRowElement);
					foreach (z0ZzZzntj item5 in ((z0ZzZzftj)item4).z0uek())
					{
						XTextTableCellElement xTextTableCellElement = xTextTableElement.z0urk();
						xTextTableRowElement.z0rek().Add(xTextTableCellElement);
						xTextTableCellElement.RowSpan = item5.z0mek();
						xTextTableCellElement.ColSpan = item5.z0iek();
						DocumentContentStyle documentContentStyle3 = z0eek(item5.z0tek(), GraphicsUnit.Document, z0uek);
						documentContentStyle3.PaddingLeft = z0ZzZzrpk.z0eek(item5.z0eek(), GraphicsUnit.Document);
						documentContentStyle3.PaddingTop = z0ZzZzrpk.z0eek(item5.z0xek(), GraphicsUnit.Document);
						documentContentStyle3.PaddingRight = z0ZzZzrpk.z0eek(item5.z0rek(), GraphicsUnit.Document);
						documentContentStyle3.PaddingBottom = z0ZzZzrpk.z0eek(item5.z0oek(), GraphicsUnit.Document);
						if (item5.z0zek() == (z0ZzZznyj)0)
						{
							documentContentStyle3.VerticalAlign = VerticalAlignStyle.Top;
						}
						else if (item5.z0zek() == (z0ZzZznyj)1)
						{
							documentContentStyle3.VerticalAlign = VerticalAlignStyle.Middle;
						}
						else if (item5.z0zek() == (z0ZzZznyj)2)
						{
							documentContentStyle3.VerticalAlign = VerticalAlignStyle.Bottom;
						}
						xTextTableCellElement.z0oek(p1.z0gnk().GetStyleIndex(documentContentStyle3));
						if (item5.z0bek() == null)
						{
							z0eek(item5, p1, xTextTableCellElement.z0be(), item5.z0tek());
						}
						xTextTableCellElement.z0gu();
					}
				}
				xTextTableElement.z0cek(p0: true);
				xTextTableElement.z0krk();
				using zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = xTextTableElement.z0zek().z0ltk();
				while (z0bpk.MoveNext())
				{
					XTextTableCellElement xTextTableCellElement2 = (XTextTableCellElement)z0bpk.Current;
					if (xTextTableCellElement2.z0bek())
					{
						xTextTableCellElement2.z0oek(((XTextElement)xTextTableCellElement2.z0hrk()).z0pek());
					}
				}
			}
			else if (item is z0ZzZzotj)
			{
				z0eek(item, p1, p2, p3.z0yrk());
			}
			else if (item is z0ZzZzptj)
			{
				z0eek(item, p1, p2, p3.z0yrk());
			}
			else if (item is z0ZzZzttj)
			{
				p2.Add(new XTextLineBreakElement());
			}
			else if (item is z0ZzZzutj)
			{
				p2.Add(new XTextPageBreakElement());
			}
			else if (item.z0uek() != null && item.z0uek().Count > 0)
			{
				z0eek(item, p1, p2, p3.z0yrk());
			}
		}
	}

	public void z0cs(bool p0)
	{
		z0yek = p0;
	}

	public bool z0eek()
	{
		return z0oek;
	}

	public void z0vs(bool p0)
	{
		z0tek = p0;
	}

	public virtual bool z0bs(TextReader p0)
	{
		z0uek.z0rek(p0);
		z0uek.z0rek(z0uek);
		return true;
	}

	public void z0ns_jiejie20260327142557(XTextDocument p0)
	{
		p0.z0rpk();
		z0eek(p0);
	}

	public static DocumentContentStyle z0eek(z0ZzZzmrj p0, GraphicsUnit p1, z0ZzZzgtj p2)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("format");
		}
		DocumentContentStyle documentContentStyle = new DocumentContentStyle();
		if (p2.z0drk() != null && p2.z0drk().ContainsKey(p0.z0irk()))
		{
			Dictionary<string, string> dictionary = p2.z0drk()[p0.z0irk()];
			if (dictionary != null && dictionary.ContainsKey("outlinelevel"))
			{
				string text = dictionary["outlinelevel"];
				if (!string.IsNullOrEmpty(text))
				{
					int titleLevel = Convert.ToInt32(text);
					documentContentStyle.TitleLevel = titleLevel;
				}
			}
		}
		if (p0.z0drk() >= 0)
		{
			documentContentStyle.ParagraphMultiLevel = true;
			documentContentStyle.ParagraphOutlineLevel = p0.z0drk();
		}
		if (p0.z0xek() >= 0)
		{
			p0.z0xek();
			_ = 4;
			z0ZzZzgyj z0ZzZzgyj2 = p2.z0srk().z0eek(p0.z0xek());
			if (z0ZzZzgyj2 != null)
			{
				z0ZzZzjyj z0ZzZzjyj2 = p2.z0ark().z0eek(z0ZzZzgyj2.z0eek());
				if (z0ZzZzjyj2 != null)
				{
					z0ZzZzhyj z0ZzZzhyj2 = z0ZzZzjyj2.z0uek(p0.z0drk());
					if (z0ZzZzhyj2 != null && z0ZzZzhyj2.z0eek() == (z0ZzZzbrj)255)
					{
						documentContentStyle.ParagraphListStyle = ParagraphListStyle.BulletedList;
					}
				}
			}
		}
		switch (p0.z0nrk_jiejie20260327142557())
		{
		case (z0ZzZzvrj)0:
			documentContentStyle.Align = DocumentContentAlignment.Left;
			break;
		case (z0ZzZzvrj)1:
			documentContentStyle.Align = DocumentContentAlignment.Center;
			break;
		case (z0ZzZzvrj)2:
			documentContentStyle.Align = DocumentContentAlignment.Right;
			break;
		case (z0ZzZzvrj)3:
			documentContentStyle.Align = DocumentContentAlignment.Justify;
			break;
		}
		documentContentStyle.BackgroundColor = p0.z0ork();
		if (p0.z0ork() == Color.White)
		{
			documentContentStyle.BackgroundColor = Color.Transparent;
		}
		documentContentStyle.Bold = p0.z0grk();
		documentContentStyle.BorderTopColor = p0.z0crk();
		documentContentStyle.BorderLeftColor = p0.z0crk();
		documentContentStyle.BorderRightColor = p0.z0crk();
		documentContentStyle.BorderBottomColor = p0.z0crk();
		documentContentStyle.BorderStyle = p0.z0prk();
		documentContentStyle.BorderLeft = p0.z0erk();
		documentContentStyle.BorderTop = p0.z0vek();
		documentContentStyle.BorderBottom = p0.z0cek();
		documentContentStyle.BorderRight = p0.z0qrk();
		documentContentStyle.BorderWidth = p0.z0brk();
		documentContentStyle.BorderSpacing = z0ZzZzrpk.z0eek(p0.z0krk(), p1);
		if (p0.z0erk() || p0.z0vek() || p0.z0qrk() || p0.z0cek())
		{
			if (p0.z0oek())
			{
				documentContentStyle.BorderWidth = 2f;
			}
			else
			{
				documentContentStyle.BorderWidth = 1f;
			}
		}
		documentContentStyle.FontName = p0.z0srk();
		documentContentStyle.FontSize = p0.z0urk();
		documentContentStyle.Italic = p0.z0tek();
		documentContentStyle.LeftIndent = z0ZzZzrpk.z0eek(p0.z0nek(), p1);
		if (p0.z0rek() == 0)
		{
			documentContentStyle.LineSpacingStyle = LineSpacingStyle.SpaceSingle;
		}
		else if (p0.z0rek() < 0)
		{
			documentContentStyle.LineSpacingStyle = LineSpacingStyle.SpaceSpecify;
			documentContentStyle.LineSpacing = z0ZzZzrpk.z0eek(p0.z0rek(), p1);
		}
		else if (p0.z0wrk())
		{
			documentContentStyle.LineSpacingStyle = LineSpacingStyle.SpaceMultiple;
			documentContentStyle.LineSpacing = (float)p0.z0rek() / 240f;
		}
		else
		{
			documentContentStyle.LineSpacingStyle = LineSpacingStyle.SpaceExactly;
		}
		if (p0.z0xek() >= 0)
		{
			z0ZzZzgyj z0ZzZzgyj3 = p2.z0srk().z0eek(p0.z0xek());
			if (z0ZzZzgyj3 != null)
			{
				z0ZzZzjyj z0ZzZzjyj3 = p2.z0ark().z0eek(z0ZzZzgyj3.z0eek());
				if (z0ZzZzjyj3 != null)
				{
					documentContentStyle.ParagraphListStyle = z0eek(z0ZzZzjyj3);
				}
			}
		}
		documentContentStyle.FirstLineIndent = z0ZzZzrpk.z0eek(p0.z0iek(), p1);
		documentContentStyle.SpacingBeforeParagraph = z0ZzZzrpk.z0eek(p0.z0frk(), p1);
		documentContentStyle.SpacingAfterParagraph = z0ZzZzrpk.z0eek(p0.z0eek(), p1);
		documentContentStyle.Strikeout = p0.z0pek();
		documentContentStyle.Subscript = p0.z0lrk();
		documentContentStyle.Superscript = p0.z0vrk();
		documentContentStyle.Color = p0.z0trk();
		documentContentStyle.Underline = p0.z0hrk();
		return documentContentStyle;
	}

	internal static ParagraphListStyle z0eek(z0ZzZzjyj p0)
	{
		Dictionary<ParagraphListStyle, string> dictionary = z0ZzZzlmk.z0iek;
		z0ZzZzhyj z0ZzZzhyj2 = p0.z0uek(0);
		if (z0ZzZzhyj2 == null)
		{
			return ParagraphListStyle.ListNumberStyle;
		}
		switch (z0ZzZzhyj2.z0eek())
		{
		case (z0ZzZzbrj)0:
			if (!string.IsNullOrEmpty(z0ZzZzhyj2.z0iek()))
			{
				string text2 = z0ZzZzhyj2.z0iek();
				if (dictionary[ParagraphListStyle.ListNumberStyleArabic1] == text2)
				{
					return ParagraphListStyle.ListNumberStyleArabic1;
				}
				if (dictionary[ParagraphListStyle.ListNumberStyleArabic2] == text2)
				{
					return ParagraphListStyle.ListNumberStyleArabic2;
				}
			}
			return ParagraphListStyle.ListNumberStyle;
		case (z0ZzZzbrj)48:
			return ParagraphListStyle.ListNumberStyleArabic1;
		case (z0ZzZzbrj)46:
			return ParagraphListStyle.ListNumberStyleArabic2;
		case (z0ZzZzbrj)22:
			return ParagraphListStyle.ListNumberStyle;
		case (z0ZzZzbrj)23:
		{
			string text = z0ZzZzhyj2.z0iek();
			if (text.Length >= 0)
			{
				return z0ZzZzlmk.z0eek(text[0]);
			}
			return ParagraphListStyle.BulletedList;
		}
		case (z0ZzZzbrj)26:
			return ParagraphListStyle.ListNumberStyleSimpChinNum2;
		case (z0ZzZzbrj)27:
			return ParagraphListStyle.ListNumberStyleSimpChinNum1;
		case (z0ZzZzbrj)37:
			return ParagraphListStyle.ListNumberStyleTradChinNum2;
		case (z0ZzZzbrj)38:
			return ParagraphListStyle.ListNumberStyleTradChinNum1;
		case (z0ZzZzbrj)39:
			return ParagraphListStyle.ListNumberStyleSimpChinNum1;
		case (z0ZzZzbrj)40:
			return ParagraphListStyle.ListNumberStyleTradChinNum1;
		case (z0ZzZzbrj)30:
			return ParagraphListStyle.ListNumberStyleZodiac1;
		case (z0ZzZzbrj)31:
			return ParagraphListStyle.ListNumberStyleZodiac2;
		case (z0ZzZzbrj)4:
			return ParagraphListStyle.ListNumberStyleLowercaseLetter;
		case (z0ZzZzbrj)2:
			return ParagraphListStyle.ListNumberStyleLowercaseRoman;
		case (z0ZzZzbrj)33:
			return ParagraphListStyle.ListNumberStyleTradChinNum1;
		case (z0ZzZzbrj)34:
			return ParagraphListStyle.ListNumberStyleTradChinNum2;
		case (z0ZzZzbrj)3:
			return ParagraphListStyle.ListNumberStyleUppercaseLetter;
		case (z0ZzZzbrj)1:
			return ParagraphListStyle.ListNumberStyleUppercaseRoman;
		case (z0ZzZzbrj)255:
			return ParagraphListStyle.BulletedList;
		default:
			return ParagraphListStyle.ListNumberStyle;
		}
	}

	public void z0eek(bool p0)
	{
		z0oek = p0;
	}

	public bool z0ms()
	{
		return z0yek;
	}

	public bool z0ps()
	{
		return z0tek;
	}

	public string z0rek()
	{
		return z0iek;
	}

	public void z0eek(XTextDocument p0)
	{
		p0.z0rpk();
		if (z0ps())
		{
			XPageSettings xPageSettings = new XPageSettings();
			xPageSettings.z0mek(z0uek.z0jrk());
			xPageSettings.z0pek(z0uek.z0mek());
			xPageSettings.LeftMargin = z0ZzZzrpk.z0eek(z0uek.z0lrk(), GraphicsUnit.Document) / 3;
			xPageSettings.TopMargin = z0ZzZzrpk.z0eek(z0uek.z0xek(), GraphicsUnit.Document) / 3;
			xPageSettings.RightMargin = z0ZzZzrpk.z0eek(z0uek.z0erk(), GraphicsUnit.Document) / 3;
			xPageSettings.BottomMargin = z0ZzZzrpk.z0eek(z0uek.z0qrk(), GraphicsUnit.Document) / 3;
			int p1 = z0ZzZzrpk.z0eek(z0uek.z0rrk(), GraphicsUnit.Document) / 3;
			int num = z0ZzZzrpk.z0eek(z0uek.z0uek(), GraphicsUnit.Document) / 3;
			xPageSettings.z0eek(PaperKind.Custom);
			xPageSettings.z0oek(p1);
			xPageSettings.z0rek(num);
			xPageSettings.z0eek(p1, num, z0uek.z0mek());
			p0.PageSettings = xPageSettings;
			p0.z0ipk().z0vek(z0uek.z0iek().z0uek());
			p0.z0ipk().z0bek(z0uek.z0iek().z0mek());
			if (z0uek.z0iek().z0pek() != DateTime.MinValue)
			{
				p0.z0ipk().z0tek(z0uek.z0iek().z0pek());
			}
			p0.z0ipk().z0cek(z0uek.z0iek().z0rek());
			if (z0uek.z0iek().z0yek() != DateTime.MinValue)
			{
				p0.z0ipk().z0eek(z0uek.z0iek().z0yek());
			}
			if (z0uek.z0iek().z0oek() != DateTime.MinValue)
			{
				p0.z0ipk().z0rek(z0uek.z0iek().z0oek());
			}
			p0.z0ipk().z0mek(z0uek.z0iek().z0nek());
		}
		p0.z0be().Clear();
		p0.z0bek((z0ZzZzzcj)1);
		z0eek(z0uek, p0, p0.z0be(), new z0ZzZzmrj());
		p0.z0bek((z0ZzZzzcj)2);
		p0.z0rt(new ElementLoadEventArgs(p0, z0ZzZzkfh.z0nek));
	}
}
