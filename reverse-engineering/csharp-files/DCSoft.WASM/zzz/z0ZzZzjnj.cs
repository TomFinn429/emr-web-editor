using System;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using DCSoft.Drawing;
using DCSoft.Writer;
using DCSoft.Writer.Commands;
using DCSoft.Writer.Controls;
using DCSoft.Writer.Dom;
using DCSystem_Drawing;

namespace zzz;

internal sealed class z0ZzZzjnj : z0ZzZzcmj
{
	[CompilerGenerated]
	private sealed class z0wuk
	{
		public Color z0rek;

		public z0ZzZzjnj z0tek;

		public z0ZzZzomj z0yek;

		public string z0uek;

		public object z0iek;

		internal void z0eek_jiejie20260327142557(Color p0)
		{
			if (p0 != z0rek)
			{
				z0yek.Parameter = p0;
				z0tek.z0eek(z0iek, z0yek, z0uek);
			}
		}
	}

	[z0ZzZzimj("ParagraphListStyle", ReturnValueType = typeof(bool))]
	private void z0eek(object p0, z0ZzZzomj p1)
	{
		z0rek(p0, p1, "ParagraphListStyle");
	}

	private void z0eek(object p0, z0ZzZzomj p1, string p2)
	{
		if (p1.Mode == (z0ZzZzmmj)2)
		{
			p1.Enabled = false;
			if (p1.EditorControl == null)
			{
				return;
			}
			if (p2 == "InsertComment")
			{
				if (p1.EditorControl.z0ork() && !p1.EditorControl.z0ttk())
				{
					return;
				}
				if (!p1.EditorControl.z0cuk().BehaviorOptions.InsertCommentBindingUserTrack)
				{
					if (p1.Document.z0cuk().z0qrk() != 0)
					{
						p1.Enabled = true;
					}
					else if (p1.Document.z0cuk().z0nek() < p1.Document.z0ryk().Count - 1)
					{
						p1.Enabled = true;
					}
					return;
				}
			}
			DocumentContentStyle documentContentStyle = z0eek(p1.Document);
			p1.Enabled = p1.EditorControl != null && p1.DocumentControler != null && p1.DocumentControler.z0in().CanModifySelection;
			if (!p1.Enabled && p2 == "ContentProtect")
			{
				p1.Enabled = true;
			}
			if (!p1.Enabled)
			{
				return;
			}
			switch (p2)
			{
			case "Visibility":
				p1.Enabled = p1.DocumentControler != null && p1.Document.z0cuk().z0qrk() != 0 && p1.DocumentControler.z0in().CanModifySelection;
				break;
			case "ContentProtect":
				p1.Enabled = p1.DocumentControler != null && p1.DocumentControler.z0tm(p0: false);
				if (p1.Enabled && p1.Document.z0cuk().z0qrk() == 0)
				{
					p1.Enabled = false;
				}
				if (p1.Enabled)
				{
					p1.Checked = p1.Document.z0xpk().ProtectType != ContentProtectType.None;
				}
				break;
			case "TitleLevel":
				if (p1.Enabled && p1.Document.z0cuk().z0qrk() == 0)
				{
					p1.Enabled = false;
				}
				break;
			case "TextSurroundings":
			{
				XTextElement xTextElement2 = p1.Document.z0wyk();
				p1.Enabled = false;
				if (xTextElement2 != null && p1.DocumentControler.z0np(xTextElement2) && (xTextElement2 is XTextObjectElement || xTextElement2 is XTextShapeInputFieldElement))
				{
					p1.Enabled = true;
					p1.Checked = xTextElement2.z0aek().z0xyk == ContentLayoutAlign.Surroundings;
				}
				break;
			}
			case "EmbedInText":
			{
				XTextElement xTextElement = p1.Document.z0wyk();
				p1.Enabled = false;
				if (xTextElement != null && p1.DocumentControler.z0np(xTextElement) && (xTextElement is XTextObjectElement || xTextElement is XTextShapeInputFieldElement))
				{
					p1.Enabled = true;
					p1.Checked = xTextElement.z0aek().z0xyk == ContentLayoutAlign.EmbedInText;
				}
				break;
			}
			case "CharacterCircle":
				p1.Checked = documentContentStyle.CharacterCircle != CharacterCircleStyles.None;
				break;
			case "Bold":
				p1.Checked = documentContentStyle.Bold;
				break;
			case "EmphasisMark":
				p1.Checked = documentContentStyle.EmphasisMark;
				break;
			case "FixedSpacing":
				p1.Checked = documentContentStyle.FixedSpacing;
				break;
			case "BorderBottom":
				p1.Checked = documentContentStyle.BorderBottom;
				break;
			case "BorderLeft":
				p1.Checked = documentContentStyle.BorderLeft;
				break;
			case "BorderRight":
				p1.Checked = documentContentStyle.BorderRight;
				break;
			case "BorderTop":
				p1.Checked = documentContentStyle.BorderTop;
				break;
			case "Italic":
				p1.Checked = documentContentStyle.Italic;
				break;
			case "Strikeout":
				p1.Checked = documentContentStyle.Strikeout;
				break;
			case "Subscript":
				p1.Checked = documentContentStyle.Subscript;
				break;
			case "Superscript":
				p1.Checked = documentContentStyle.Superscript;
				break;
			case "Underline":
				p1.Checked = documentContentStyle.Underline;
				break;
			default:
				p1.Enabled = false;
				break;
			case "InsertComment":
				break;
			case "LetterSpacing":
				break;
			case "UnderlineStyle":
				break;
			}
		}
		else
		{
			if (p1.Mode != (z0ZzZzmmj)5)
			{
				return;
			}
			z0ZzZzhkh z0ZzZzhkh2 = p1.Document.z0cuk();
			p1.Result = false;
			DocumentContentStyle documentContentStyle2 = z0eek(p1.Document);
			DocumentContentStyle documentContentStyle3 = p1.Document.CreateDocumentContentStyle();
			documentContentStyle3.z0eek(p0: true);
			bool flag = true;
			bool p3 = false;
			switch (p2)
			{
			case "InsertComment":
			{
				if (z0ZzZzhkh2.z0qrk() == 0)
				{
					z0ZzZzhkh2 = p1.Document.z0jrk().z0rek(z0ZzZzhkh2.z0nek(), 1);
				}
				DocumentComment documentComment = null;
				if (p1.Parameter is DocumentComment)
				{
					documentComment = (DocumentComment)p1.Parameter;
				}
				else
				{
					documentComment = new DocumentComment();
					documentComment.z0pek(Convert.ToString(p1.Parameter));
				}
				if (!(p1.Parameter is DocumentComment))
				{
					z0ZzZznbj z0ZzZznbj2 = (z0ZzZznbj)p1.Host.z0tek().z0eek(typeof(z0ZzZznbj));
					if (z0ZzZznbj2 == null)
					{
						documentComment.z0eek(Environment.UserName);
					}
					else
					{
						documentComment.z0eek(z0ZzZznbj2.z0uek());
						documentComment.z0rek(z0ZzZznbj2.z0eek());
					}
					documentComment.z0eek(p1.Document.z0jpk());
					documentComment.z0eek(p1.Document.z0buk());
					DocumentOptions documentOptions = p1.Document.z0vu();
					documentComment.z0eek(documentOptions.BehaviorOptions.InsertCommentBindingUserTrack);
					if (documentOptions.SecurityOptions.EnablePermission && p1.Document.z0syk().z0eek() != null)
					{
						documentComment.z0tek(p1.Document.z0syk().z0yek());
						documentComment.z0eek(p1.Document.z0syk().z0eek().z0yek());
						documentComment.z0rek(p1.Document);
					}
				}
				documentComment.z0eek(p1.Document.z0buk());
				z0ZzZzwcj z0ZzZzwcj2 = p1.Document.Comments.z0eek(p0: false);
				z0ZzZzwcj2.Add(documentComment);
				if (p1.Document.z0uik())
				{
					p1.Document.z0imk().z0eek("Comments", p1.Document.Comments, z0ZzZzwcj2, p1.Document);
				}
				p1.Document.Comments = z0ZzZzwcj2;
				documentContentStyle3.CommentIndex = documentComment.z0tek();
				flag = p1.EditorControl.z0oyk() != FunctionControlVisibility.Hide;
				break;
			}
			case "ContentProtect":
			{
				ContentProtectType contentProtectType = p1.Document.z0xpk().ProtectType;
				if (p1.Parameter is ContentProtectType)
				{
					contentProtectType = (ContentProtectType)p1.Parameter;
				}
				else if (p1.Parameter is string)
				{
					contentProtectType = (ContentProtectType)z0ZzZzafh.z0yek(p1.Parameter, contentProtectType);
				}
				else if (p1.Parameter is bool)
				{
					contentProtectType = (((bool)p1.Parameter) ? ContentProtectType.Range : ContentProtectType.None);
				}
				documentContentStyle3.ProtectType = contentProtectType;
				flag = false;
				p1.RefreshLevel = (z0ZzZzwmj)2;
				break;
			}
			case "Visibility":
			{
				p3 = true;
				RenderVisibility visibility = documentContentStyle2.Visibility;
				if (p1.Parameter is string)
				{
					try
					{
						visibility = (RenderVisibility)Enum.Parse(typeof(RenderVisibility), (string)p1.Parameter);
					}
					catch (Exception ex)
					{
						z0ZzZzqok.z0rek.z0dh(ex.Message);
					}
				}
				else if (p1.Parameter is RenderVisibility)
				{
					visibility = (RenderVisibility)p1.Parameter;
				}
				_ = p1.ShowUI;
				documentContentStyle3.Visibility = visibility;
				flag = false;
				break;
			}
			case "TitleLevel":
			{
				int titleLevel = documentContentStyle2.TitleLevel;
				if (p1.Parameter is int || p1.Parameter is short || p1.Parameter is long)
				{
					titleLevel = (int)p1.Parameter;
				}
				_ = p1.ShowUI;
				documentContentStyle3.TitleLevel = titleLevel;
				flag = false;
				break;
			}
			case "TextSurroundings":
			{
				XTextElement xTextElement3 = p1.Document.z0wyk();
				ContentLayoutAlign contentLayoutAlign = ContentLayoutAlign.EmbedInText;
				contentLayoutAlign = (z0ZzZzafh.z0yek(p1.Parameter, p1: true) ? ContentLayoutAlign.Surroundings : ContentLayoutAlign.EmbedInText);
				if (xTextElement3.z0aek().z0xyk != contentLayoutAlign)
				{
					documentContentStyle3.LayoutAlign = contentLayoutAlign;
					flag = true;
					break;
				}
				return;
			}
			case "EmbedInText":
			{
				XTextElement xTextElement4 = p1.Document.z0wyk();
				ContentLayoutAlign contentLayoutAlign2 = ContentLayoutAlign.EmbedInText;
				contentLayoutAlign2 = ((!z0ZzZzafh.z0yek(p1.Parameter, p1: true)) ? ContentLayoutAlign.Surroundings : ContentLayoutAlign.EmbedInText);
				if (xTextElement4.z0aek().z0xyk != contentLayoutAlign2)
				{
					documentContentStyle3.LayoutAlign = contentLayoutAlign2;
					flag = true;
					break;
				}
				return;
			}
			case "CharacterCircle":
				documentContentStyle3.CharacterCircle = (CharacterCircleStyles)z0ZzZzafh.z0yek(p1.Parameter, (documentContentStyle2.CharacterCircle == CharacterCircleStyles.None) ? CharacterCircleStyles.Circle : CharacterCircleStyles.None);
				_ = p1.ShowUI;
				flag = true;
				break;
			case "Bold":
				documentContentStyle3.Bold = z0ZzZzafh.z0yek(p1.Parameter, !documentContentStyle2.Bold);
				flag = true;
				break;
			case "EmphasisMark":
				documentContentStyle3.EmphasisMark = z0ZzZzafh.z0yek(p1.Parameter, !documentContentStyle2.EmphasisMark);
				flag = true;
				break;
			case "FixedSpacing":
				documentContentStyle3.FixedSpacing = z0ZzZzafh.z0yek(p1.Parameter, !documentContentStyle2.FixedSpacing);
				flag = true;
				break;
			case "BorderBottom":
				documentContentStyle3.BorderBottom = z0ZzZzafh.z0yek(p1.Parameter, !documentContentStyle2.BorderBottom);
				flag = false;
				break;
			case "BorderLeft":
				documentContentStyle3.BorderLeft = z0ZzZzafh.z0yek(p1.Parameter, !documentContentStyle2.BorderLeft);
				flag = false;
				break;
			case "BorderRight":
				documentContentStyle3.BorderRight = z0ZzZzafh.z0yek(p1.Parameter, !documentContentStyle2.BorderRight);
				break;
			case "BorderTop":
				documentContentStyle3.BorderTop = z0ZzZzafh.z0yek(p1.Parameter, !documentContentStyle2.BorderTop);
				flag = false;
				break;
			case "Italic":
				documentContentStyle3.Italic = z0ZzZzafh.z0yek(p1.Parameter, !documentContentStyle2.Italic);
				flag = true;
				break;
			case "Strikeout":
				documentContentStyle3.Strikeout = z0ZzZzafh.z0yek(p1.Parameter, !documentContentStyle2.Strikeout);
				flag = false;
				break;
			case "Subscript":
				documentContentStyle3.Subscript = z0ZzZzafh.z0yek(p1.Parameter, !documentContentStyle2.Subscript);
				documentContentStyle3.Superscript = false;
				flag = true;
				break;
			case "Superscript":
				documentContentStyle3.Subscript = false;
				documentContentStyle3.Superscript = z0ZzZzafh.z0yek(p1.Parameter, !documentContentStyle2.Superscript);
				flag = true;
				break;
			case "Underline":
				documentContentStyle3.Underline = z0ZzZzafh.z0yek(p1.Parameter, !documentContentStyle2.Underline);
				flag = false;
				break;
			case "UnderlineStyle":
				if (p1.Parameter is object[])
				{
					object[] array = (object[])p1.Parameter;
					if (array.Length == 2)
					{
						if (array[0] is TextUnderlineStyle)
						{
							documentContentStyle3.UnderlineStyle = (TextUnderlineStyle)array[0];
						}
						if (array[1] is string)
						{
							documentContentStyle3.UnderlineColor = (string)array[1];
						}
					}
					if (documentContentStyle3.UnderlineStyle == TextUnderlineStyle.None)
					{
						documentContentStyle3.Underline = false;
					}
					else
					{
						documentContentStyle3.Underline = true;
					}
				}
				flag = false;
				break;
			case "Color":
				documentContentStyle3.Color = z0eek(p1.Parameter, documentContentStyle2.Color);
				flag = false;
				break;
			case "PrintColor":
				documentContentStyle3.PrintColor = z0eek(p1.Parameter, documentContentStyle2.Color);
				flag = false;
				break;
			case "PrintBackColor":
				documentContentStyle3.PrintBackColor = z0eek(p1.Parameter, documentContentStyle2.Color);
				flag = false;
				break;
			case "BackColor":
				documentContentStyle3.BackgroundColor = z0eek(p1.Parameter, documentContentStyle2.BackgroundColor);
				flag = false;
				break;
			case "Font":
				if (p1.Parameter is z0ZzZzsdh)
				{
					documentContentStyle3.Font = new z0ZzZzimk((z0ZzZzsdh)p1.Parameter);
				}
				else if (p1.Parameter is z0ZzZzimk)
				{
					documentContentStyle3.Font = ((z0ZzZzimk)p1.Parameter).Clone();
				}
				flag = true;
				break;
			case "FontName":
				if (p1.Parameter is string)
				{
					documentContentStyle3.FontName = (string)p1.Parameter;
					p1.Document.z0onk().z0tek().FontName = documentContentStyle3.FontName;
				}
				flag = true;
				break;
			case "FontSize":
				if (p1.Parameter is string)
				{
					documentContentStyle3.FontSize = z0ZzZzdpj.z0eek((string)p1.Parameter, p1.Document.z0dik().FontSize);
				}
				else if (p1.Parameter is float || p1.Parameter is double || p1.Parameter is int)
				{
					documentContentStyle3.FontSize = Convert.ToSingle(p1.Parameter);
				}
				p1.Document.z0onk().z0tek().FontSize = documentContentStyle3.FontSize;
				flag = true;
				break;
			case "LetterSpacing":
			{
				float letterSpacing = z0ZzZzafh.z0yek(p1.Parameter, (int)documentContentStyle2.LetterSpacing);
				_ = p1.ShowUI;
				documentContentStyle3.LetterSpacing = letterSpacing;
				p1.Document.z0onk().z0tek().LetterSpacing = documentContentStyle3.LetterSpacing;
				flag = true;
				break;
			}
			default:
				throw new NotSupportedException(p2);
			}
			z0ZzZzvik.z0eek(documentContentStyle3, p1.Document.z0onk().z0tek(), p2: true);
			z0ZzZzvik.z0eek(documentContentStyle3, p1.Document.z0onk().z0iek(), p2: true);
			if (z0ZzZzhkh2.z0qrk() == 0)
			{
				XTextContainerElement p4 = null;
				int p5 = 0;
				p1.Document.z0ryk().z0tek(out p4, out p5);
				if (p4 is XTextInputFieldElement && p4.z0be().Count == 0 && p5 == 0)
				{
					z0ZzZzhkh2 = new z0ZzZzhkh(z0ZzZzhkh2.z0cek());
					z0ZzZzhkh2.z0grk().Add(((XTextFieldElementBase)(XTextInputFieldElement)p4).z0jrk());
				}
			}
			p1.Document.z0ytk();
			bool flag2 = z0ZzZzhkh2.z0rek(documentContentStyle3, flag, p3, p1.Name);
			p1.Result = flag2;
			if (flag2)
			{
				if (flag && (p2 == "InsertComment" || p2 == "LetterSpacing"))
				{
					p1.EditorControl.z0iyk();
					p1.Document.z0imk().z0eek((z0ZzZzbzj)1);
				}
				p1.RefreshLevel = (z0ZzZzwmj)1;
				p1.Document.z0nuk();
				p1.Document.OnSelectionChanged();
				p1.Document.OnDocumentContentChanged();
			}
		}
	}

	private Color z0eek(object p0, Color p1)
	{
		Color result = p1;
		if (p0 is Color)
		{
			result = (Color)p0;
		}
		else if (p0 is int)
		{
			result = Color.FromArgb((int)p0);
		}
		else if (p0 is string)
		{
			try
			{
				result = z0ZzZzlok.z0eek((string)p0, Color.Empty);
			}
			catch (Exception ex)
			{
				z0ZzZzqok.z0rek.z0dh(ex.Message);
			}
		}
		return result;
	}

	private static void z0eek(DocumentContentStyle p0, XTextDocument p1)
	{
		if (p0.ParagraphListStyle == ParagraphListStyle.None)
		{
			p0.FirstLineIndent = 0f;
			p0.LeftIndent = 0f;
			return;
		}
		DocumentContentStyle documentContentStyle = p1.z0onk().z0uek();
		int num = 1;
		using (zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = p1.z0cuk().z0ork().z0ltk())
		{
			while (z0bpk.MoveNext())
			{
				XTextParagraphFlagElement xTextParagraphFlagElement = (XTextParagraphFlagElement)z0bpk.Current;
				num = Math.Max(num, xTextParagraphFlagElement.z0oek());
			}
		}
		using z0ZzZzjpk p2 = p1.z0ru();
		DocumentContentStyle obj = (DocumentContentStyle)documentContentStyle.Clone();
		obj.ParagraphListStyle = p0.ParagraphListStyle;
		z0ZzZzxdh z0ZzZzxdh2 = XTextParagraphListItemElement.z0eek(obj, p2, num);
		if (z0ZzZzxdh2.z0rek() > 0f)
		{
			if (documentContentStyle.FirstLineIndent < 0f)
			{
				p0.LeftIndent = documentContentStyle.LeftIndent + documentContentStyle.FirstLineIndent;
			}
			else
			{
				p0.LeftIndent = documentContentStyle.LeftIndent;
			}
			p0.LeftIndent += z0ZzZzxdh2.z0rek();
			p0.FirstLineIndent = 0f - z0ZzZzxdh2.z0rek();
		}
	}

	private void z0rek(object p0, z0ZzZzomj p1, string p2)
	{
		if (p1.Mode == (z0ZzZzmmj)2)
		{
			if (p1.EditorControl == null)
			{
				p1.Enabled = false;
				return;
			}
			DocumentContentStyle documentContentStyle = p1.Document.z0onk().z0uek();
			p1.Enabled = p1.DocumentControler != null && p1.DocumentControler.z0in().CanModifyParagraphs;
			switch (p2)
			{
			case "AlignLeft":
				p1.Checked = documentContentStyle.Align == DocumentContentAlignment.Left;
				break;
			case "AlignCenter":
				p1.Checked = documentContentStyle.Align == DocumentContentAlignment.Center;
				break;
			case "AlignRight":
				p1.Checked = documentContentStyle.Align == DocumentContentAlignment.Right;
				break;
			case "AlignJustify":
				p1.Checked = documentContentStyle.Align == DocumentContentAlignment.Justify;
				break;
			case "AlignDistribute":
				p1.Checked = documentContentStyle.Align == DocumentContentAlignment.Distribute;
				break;
			case "BorderBottom":
				p1.Checked = documentContentStyle.BorderBottom;
				break;
			case "BorderLeft":
				p1.Checked = documentContentStyle.BorderLeft;
				break;
			case "BorderRight":
				p1.Checked = documentContentStyle.BorderRight;
				break;
			case "BorderTop":
				p1.Checked = documentContentStyle.BorderTop;
				break;
			case "BulletedList":
				p1.Checked = documentContentStyle.IsBulletedList;
				break;
			case "NumberedList":
				p1.Checked = documentContentStyle.IsListNumberStyle;
				break;
			case "FirstLineIndent":
				p1.Checked = documentContentStyle.FirstLineIndent > 1f;
				break;
			case "ParagraphListStyle":
				p1.Enabled = true;
				break;
			case "IncreaseFirstLineIndent":
				p1.Enabled = true;
				break;
			default:
				p1.Enabled = false;
				break;
			case "LayoutDirection":
				break;
			}
		}
		else
		{
			if (p1.Mode != (z0ZzZzmmj)5)
			{
				return;
			}
			p1.Result = false;
			DocumentContentStyle documentContentStyle2 = p1.Document.z0onk().z0uek();
			DocumentContentStyle documentContentStyle3 = p1.Document.CreateDocumentContentStyle();
			documentContentStyle3.z0eek(p0: true);
			switch (p2)
			{
			case "AlignCenter":
				documentContentStyle3.Align = DocumentContentAlignment.Center;
				p1.RefreshLevel = (z0ZzZzwmj)2;
				break;
			case "AlignJustify":
				documentContentStyle3.Align = DocumentContentAlignment.Justify;
				p1.RefreshLevel = (z0ZzZzwmj)2;
				break;
			case "AlignLeft":
				documentContentStyle3.Align = DocumentContentAlignment.Left;
				p1.RefreshLevel = (z0ZzZzwmj)2;
				break;
			case "AlignRight":
				documentContentStyle3.Align = DocumentContentAlignment.Right;
				p1.RefreshLevel = (z0ZzZzwmj)2;
				break;
			case "AlignDistribute":
				documentContentStyle3.Align = DocumentContentAlignment.Distribute;
				p1.RefreshLevel = (z0ZzZzwmj)2;
				break;
			case "BorderBottom":
				documentContentStyle3.BorderBottom = z0ZzZzafh.z0yek(p1.Parameter, !documentContentStyle2.BorderBottom);
				break;
			case "BorderLeft":
				documentContentStyle3.BorderLeft = z0ZzZzafh.z0yek(p1.Parameter, !documentContentStyle2.BorderLeft);
				break;
			case "BorderRight":
				documentContentStyle3.BorderRight = z0ZzZzafh.z0yek(p1.Parameter, !documentContentStyle2.BorderRight);
				break;
			case "BorderTop":
				documentContentStyle3.BorderTop = z0ZzZzafh.z0yek(p1.Parameter, !documentContentStyle2.BorderTop);
				break;
			case "LayoutDirection":
				return;
			case "ParagraphListStyle":
			{
				bool flag3 = false;
				ParagraphListStyle paragraphListStyle = p1.Document.z0onk().z0uek().ParagraphListStyle;
				if (p1.Parameter is ParagraphListStyle)
				{
					paragraphListStyle = (ParagraphListStyle)p1.Parameter;
					flag3 = true;
				}
				else if (p1.Parameter is string)
				{
					try
					{
						paragraphListStyle = (ParagraphListStyle)Enum.Parse(typeof(ParagraphListStyle), (string)p1.Parameter);
						flag3 = true;
					}
					catch
					{
					}
				}
				if (!flag3)
				{
					return;
				}
				documentContentStyle3.ParagraphListStyle = paragraphListStyle;
				z0eek(documentContentStyle3, p1.Document);
				p1.RefreshLevel = (z0ZzZzwmj)2;
				break;
			}
			case "BulletedList":
			{
				bool flag2 = z0ZzZzafh.z0yek(p1.Parameter, !documentContentStyle2.IsBulletedList);
				if (flag2 != documentContentStyle2.IsBulletedList)
				{
					if (flag2)
					{
						documentContentStyle3.ParagraphListStyle = ParagraphListStyle.BulletedList;
					}
					else
					{
						documentContentStyle3.ParagraphListStyle = ParagraphListStyle.None;
					}
				}
				z0eek(documentContentStyle3, p1.Document);
				p1.RefreshLevel = (z0ZzZzwmj)2;
				break;
			}
			case "NumberedList":
			{
				bool flag = z0ZzZzafh.z0yek(p1.Parameter, !documentContentStyle2.IsListNumberStyle);
				if (flag != documentContentStyle2.IsListNumberStyle)
				{
					if (flag)
					{
						documentContentStyle3.ParagraphListStyle = ParagraphListStyle.ListNumberStyle;
					}
					else
					{
						documentContentStyle3.ParagraphListStyle = ParagraphListStyle.None;
					}
				}
				z0eek(documentContentStyle3, p1.Document);
				p1.RefreshLevel = (z0ZzZzwmj)2;
				break;
			}
			case "FirstLineIndent":
			{
				bool p3 = false;
				if (!z0ZzZzafh.z0yek(p1.Parameter, ref p3))
				{
					p3 = !(documentContentStyle2.FirstLineIndent > 1f);
				}
				if (p3)
				{
					documentContentStyle3.FirstLineIndent = 100f;
					documentContentStyle3.LeftIndent = 0f;
				}
				else
				{
					documentContentStyle3.FirstLineIndent = 0f;
					documentContentStyle3.LeftIndent = 0f;
				}
				p1.RefreshLevel = (z0ZzZzwmj)2;
				break;
			}
			case "IncreaseFirstLineIndent":
				if (z0ZzZzafh.z0yek(p1.Parameter, p1: true))
				{
					documentContentStyle3.FirstLineIndent += 100f;
					if (documentContentStyle3.FirstLineIndent > 180f)
					{
						documentContentStyle3.LeftIndent += 100f;
					}
				}
				else
				{
					documentContentStyle3.FirstLineIndent -= 100f;
					if (documentContentStyle3.FirstLineIndent < 0f)
					{
						documentContentStyle3.FirstLineIndent = 0f;
					}
					if (documentContentStyle3.FirstLineIndent < 80f)
					{
						documentContentStyle3.LeftIndent = 0f;
					}
				}
				p1.RefreshLevel = (z0ZzZzwmj)2;
				break;
			default:
				throw new NotSupportedException(p2);
			}
			p1.Document.z0ytk();
			XTextElementList xTextElementList = p1.Document.z0cuk().z0rek(documentContentStyle3);
			p1.Document.z0nuk();
			p1.Document.OnSelectionChanged();
			p1.Document.OnDocumentContentChanged();
			if (xTextElementList != null && xTextElementList.Count > 0)
			{
				p1.Result = true;
			}
		}
	}

	[z0ZzZzimj("FirstLineIndent", ReturnValueType = typeof(bool))]
	private void z0rek(object p0, z0ZzZzomj p1)
	{
		z0rek(p0, p1, "FirstLineIndent");
	}

	private bool z0eek(z0ZzZzbpj p0, z0ZzZzomj p1, XTextElement p2)
	{
		z0ZzZzrzj z0ZzZzrzj2 = p2.z0aek();
		p0.z0eek(z0ZzZzrzj2.z0nek);
		p0.z0uek(z0ZzZzrzj2.z0myk);
		p0.z0tek(z0ZzZzrzj2.z0grk);
		p0.z0yek(z0ZzZzrzj2.z0trk);
		p0.z0eek(z0ZzZzrzj2.z0erk);
		p0.z0eek(z0ZzZzrzj2.z0guk);
		p0.z0eek(z0ZzZzrzj2.z0rrk);
		p0.z0uek(z0ZzZzrzj2.z0wyk);
		p0.z0iek(z0ZzZzrzj2.z0etk);
		p0.z0tek(z0ZzZzrzj2.z0mrk);
		p0.z0rek(z0ZzZzrzj2.z0ark);
		p0.z0pek(p0: false);
		p0.z0rek(p0: false);
		p0.z0eek(StyleApplyRanges.Text);
		p0.z0uek();
		return true;
	}

	[z0ZzZzimj("BorderLeft", ReturnValueType = typeof(bool))]
	private void z0tek(object p0, z0ZzZzomj p1)
	{
		z0rek(p0, p1, "BorderLeft");
	}

	internal static DocumentContentStyle z0eek(XTextDocument p0)
	{
		return p0?.z0onk().z0tek();
	}

	private XTextSubDocumentElement z0eek(XTextElement p0)
	{
		if (p0 != null)
		{
			if (p0 is XTextSubDocumentElement)
			{
				return p0 as XTextSubDocumentElement;
			}
			return z0eek(p0.z0ji());
		}
		return null;
	}

	[z0ZzZzimj("Color", ReturnValueType = typeof(bool), FunctionID = 62)]
	private void z0yek(object p0, z0ZzZzomj p1)
	{
		z0tek(p0, p1, "Color");
	}

	[z0ZzZzimj("Header4")]
	private void z0uek(object p0, z0ZzZzomj p1)
	{
		z0ZzZzlmj p2 = z0ZzZzlmj.z0bek();
		z0eek(p1, p2);
	}

	[z0ZzZzimj("BackColor", ReturnValueType = typeof(bool), FunctionID = 63)]
	private void z0iek(object p0, z0ZzZzomj p1)
	{
		z0tek(p0, p1, "BackColor");
	}

	[z0ZzZzimj("Header2WithMultiNumberlist")]
	private void z0oek(object p0, z0ZzZzomj p1)
	{
		z0ZzZzlmj p2 = z0ZzZzlmj.z0pek();
		z0eek(p1, p2);
	}

	[z0ZzZzimj("HeaderFormat")]
	private void z0pek(object p0, z0ZzZzomj p1)
	{
		if (p1.Mode == (z0ZzZzmmj)2)
		{
			p1.Enabled = true;
		}
		else if (p1.Parameter is z0ZzZzlmj p2)
		{
			z0eek(p1, p2);
		}
	}

	[z0ZzZzimj("BorderTop", ReturnValueType = typeof(bool))]
	private void z0mek(object p0, z0ZzZzomj p1)
	{
		z0rek(p0, p1, "BorderTop");
	}

	[z0ZzZzimj("Header2")]
	private void z0nek(object p0, z0ZzZzomj p1)
	{
		z0ZzZzlmj p2 = z0ZzZzlmj.z0rek();
		z0eek(p1, p2);
	}

	[z0ZzZzimj("EmbedInText", ReturnValueType = typeof(bool))]
	private void z0bek(object p0, z0ZzZzomj p1)
	{
		z0eek(p0, p1, "EmbedInText");
	}

	private void z0tek(object p0, z0ZzZzomj p1, string p2)
	{
		if (p1.Mode == (z0ZzZzmmj)2)
		{
			p1.Enabled = p1.DocumentControler != null && p1.DocumentControler.z0in().CanModifySelection;
			if (p2 == "PrintColor" && p1.Enabled)
			{
				p1.Enabled = p1.Document.z0cuk().z0qrk() != 0;
			}
		}
		else
		{
			if (p1.Mode != (z0ZzZzmmj)5)
			{
				return;
			}
			p1.Result = false;
			DocumentContentStyle documentContentStyle = z0eek(p1.Document);
			Color color = documentContentStyle.Color;
			if (p2 == "PrintColor")
			{
				color = documentContentStyle.PrintColor;
				if (p1.Parameter != null)
				{
					color = z0eek(p1.Parameter, Color.Black);
				}
			}
			else if (p2 == "PrintBackColor")
			{
				color = documentContentStyle.PrintBackColor;
				if (p1.Parameter != null)
				{
					color = z0eek(p1.Parameter, Color.Empty);
				}
			}
			else if (p2 == "BackColor")
			{
				color = documentContentStyle.BackgroundColor;
				if (p1.Parameter != null)
				{
					color = z0eek(p1.Parameter, Color.Transparent);
				}
			}
			else if (p1.Parameter != null)
			{
				color = z0eek(p1.Parameter, Color.Black);
			}
			if (p1.ShowUI)
			{
				Color z0rek = Color.Black;
				if (p2 == "Color")
				{
					z0rek = Color.Black;
				}
				else if (p2 == "BackColor")
				{
					z0rek = Color.Transparent;
				}
				p1.EditorControl.z0lh().z0nz(z0rek, delegate(Color color2)
				{
					if (color2 != z0rek)
					{
						p1.Parameter = color2;
						z0eek(p0, p1, p2);
					}
				});
			}
			else
			{
				p1.Parameter = color;
				z0eek(p0, p1, p2);
			}
		}
	}

	[z0ZzZzimj("BorderBackgroundFormat", ReturnValueType = typeof(bool))]
	private void z0vek(object p0, z0ZzZzomj p1)
	{
		if (p1.Mode == (z0ZzZzmmj)2)
		{
			StyleApplyRanges styleApplyRanges = z0eek(p1);
			p1.Enabled = styleApplyRanges != StyleApplyRanges.None;
		}
		else
		{
			if (p1.Mode != (z0ZzZzmmj)5)
			{
				return;
			}
			StyleApplyRanges styleApplyRanges2 = z0eek(p1);
			p1.Result = false;
			XTextElement xTextElement = null;
			if (Math.Abs(p1.Document.z0cuk().z0qrk()) == 1)
			{
				xTextElement = p1.Document.z0cuk().z0grk()[0];
				if (!(xTextElement is XTextObjectElement) && !(xTextElement is XTextShapeInputFieldElement))
				{
					xTextElement = null;
				}
			}
			if (xTextElement != null && !p1.DocumentControler.z0np(xTextElement))
			{
				return;
			}
			z0ZzZzbpj z0ZzZzbpj2 = p1.Parameter as z0ZzZzbpj;
			if (z0ZzZzbpj2 == null && !p1.ShowUI)
			{
				return;
			}
			if (z0ZzZzbpj2 == null)
			{
				z0ZzZzbpj2 = new z0ZzZzbpj();
				if (p1.Document.z0cuk().z0qrk() != 0)
				{
					if (p1.Document.z0cuk().z0yek() == ContentRangeMode.Cell)
					{
						z0eek(z0ZzZzbpj2, p1);
						z0ZzZzbpj2.z0eek(StyleApplyRanges.Cell);
					}
					else
					{
						z0eek(z0ZzZzbpj2, p1, p1.Document.z0cuk().z0grk()[0]);
						if ((styleApplyRanges2 & StyleApplyRanges.Text) == StyleApplyRanges.Text)
						{
							z0ZzZzbpj2.z0eek(StyleApplyRanges.Text);
						}
						else if ((styleApplyRanges2 & StyleApplyRanges.Field) == StyleApplyRanges.Field)
						{
							z0ZzZzbpj2.z0eek(StyleApplyRanges.Field);
						}
						else if ((styleApplyRanges2 & StyleApplyRanges.Paragraph) == StyleApplyRanges.Paragraph)
						{
							z0ZzZzbpj2.z0eek(StyleApplyRanges.Paragraph);
						}
						else if ((styleApplyRanges2 & StyleApplyRanges.Cell) == StyleApplyRanges.Cell)
						{
							z0ZzZzbpj2.z0eek(StyleApplyRanges.Cell);
						}
					}
				}
				else if ((styleApplyRanges2 & StyleApplyRanges.Field) == StyleApplyRanges.Field)
				{
					z0ZzZzbpj2.z0eek(StyleApplyRanges.Field);
					z0eek(z0ZzZzbpj2, p1, p1.Document.z0bek(typeof(XTextInputFieldElement)));
					z0ZzZzbpj2.z0eek(StyleApplyRanges.Field);
				}
				else if ((styleApplyRanges2 & StyleApplyRanges.Cell) == StyleApplyRanges.Cell)
				{
					z0ZzZzbpj2.z0eek(StyleApplyRanges.Cell);
					z0eek(z0ZzZzbpj2, p1);
				}
				else if ((styleApplyRanges2 & StyleApplyRanges.Paragraph) == StyleApplyRanges.Paragraph)
				{
					z0ZzZzbpj2.z0eek(StyleApplyRanges.Paragraph);
					z0eek(z0ZzZzbpj2, p1, p1.Document.z0itk().z0dy());
				}
				else if ((styleApplyRanges2 & StyleApplyRanges.Section) == StyleApplyRanges.Section)
				{
					z0ZzZzbpj2.z0eek(StyleApplyRanges.Section);
					z0eek(z0ZzZzbpj2, p1, p1.Document.z0bek(typeof(XTextSectionElement)));
				}
			}
			p1.Result = false;
			if (z0ZzZzbpj2.z0rek() == StyleApplyRanges.Text)
			{
				z0eek(z0ZzZzbpj2, p1, p1.Document.z0cuk().z0grk());
				return;
			}
			if (z0ZzZzbpj2.z0rek() == StyleApplyRanges.Cell)
			{
				z0eek(z0ZzZzbpj2, p1, p2: false);
				return;
			}
			if (z0ZzZzbpj2.z0rek() == StyleApplyRanges.Paragraph)
			{
				z0eek(z0ZzZzbpj2, p1, p1.Document.z0cuk().z0ork());
				return;
			}
			XTextElement xTextElement2 = p1.Document.z0itk();
			XTextElementList xTextElementList = new XTextElementList();
			while (xTextElement2 != null)
			{
				if (p1.DocumentControler.z0np(xTextElement2))
				{
					if (z0ZzZzbpj2.z0rek() == StyleApplyRanges.Field && xTextElement2 is XTextInputFieldElement)
					{
						xTextElementList.Add(xTextElement2);
						break;
					}
					if (z0ZzZzbpj2.z0rek() == StyleApplyRanges.Row && xTextElement2 is XTextTableRowElement)
					{
						xTextElementList.Add(xTextElement2);
						break;
					}
					if (z0ZzZzbpj2.z0rek() == StyleApplyRanges.Table && xTextElement2 is XTextTableElement)
					{
						xTextElementList.Add(xTextElement2);
						break;
					}
					if (z0ZzZzbpj2.z0rek() == StyleApplyRanges.Section && xTextElement2 is XTextSectionElement)
					{
						xTextElementList.Add(xTextElement2);
						break;
					}
				}
				xTextElement2 = xTextElement2.z0ji();
			}
			if (xTextElementList.Count > 0)
			{
				z0eek(z0ZzZzbpj2, p1, xTextElementList);
			}
		}
	}

	[z0ZzZzimj("DeleteCommentWithoutValidatePermission", ReturnValueType = typeof(bool))]
	private void z0cek(object p0, z0ZzZzomj p1)
	{
		if (p1.Mode == (z0ZzZzmmj)2)
		{
			p1.Enabled = false;
			if (p1.EditorControl != null && (!p1.EditorControl.z0ork() || p1.EditorControl.z0ttk()))
			{
				p1.Enabled = true;
			}
		}
		else if (p1.Mode == (z0ZzZzmmj)5)
		{
			p1.Result = z0eek(p1, p1: true);
		}
	}

	private bool z0eek(DocumentComment p0, z0ZzZzomj p1)
	{
		if (p0 == null)
		{
			return false;
		}
		if (string.IsNullOrEmpty(p0.z0eek()))
		{
			return true;
		}
		if (p1.EditorControl.z0cuk().BehaviorOptions.ValidateUserIDWhenEditDeleteComment)
		{
			z0ZzZznbj z0ZzZznbj2 = (z0ZzZznbj)p1.Host.z0tek().z0eek(typeof(z0ZzZznbj));
			if (z0ZzZznbj2 == null || z0ZzZznbj2.z0eek() != p0.z0eek())
			{
				if (p1.ShowUI)
				{
					z0ZzZzfpj.z0tek(p1.EditorControl, string.Format(z0ZzZziok.z0etk(), p0.z0eek()));
				}
				return false;
			}
		}
		return true;
	}

	[z0ZzZzimj("AlignCenter", ReturnValueType = typeof(bool))]
	private void z0xek(object p0, z0ZzZzomj p1)
	{
		z0rek(p0, p1, "AlignCenter");
	}

	[z0ZzZzimj("Padding", ReturnValueType = typeof(bool))]
	private void z0zek(object p0, z0ZzZzomj p1)
	{
		if (p1.Mode == (z0ZzZzmmj)2)
		{
			XTextElementList xTextElementList = z0rek(p1.Document);
			p1.Enabled = xTextElementList != null && xTextElementList.Count > 0;
		}
		else
		{
			if (p1.Mode != (z0ZzZzmmj)5)
			{
				return;
			}
			p1.Result = false;
			XTextElementList xTextElementList2 = z0rek(p1.Document);
			if (xTextElementList2 == null || xTextElementList2.Count == 0)
			{
				return;
			}
			bool flag = false;
			z0ZzZzmmk z0ZzZzmmk2 = null;
			if (p1.Parameter is z0ZzZzmmk)
			{
				z0ZzZzmmk2 = (z0ZzZzmmk)p1.Parameter;
				flag = true;
			}
			else if (p1.Parameter is string)
			{
				z0ZzZzmmk2 = new z0ZzZzmmk();
				if (z0ZzZzmmk.z0eek((string)p1.Parameter, z0ZzZzmmk2))
				{
					flag = true;
				}
			}
			if (!flag)
			{
				DocumentContentStyle documentContentStyle = xTextElementList2[0].z0aek().z0jrk;
				z0ZzZzmmk2 = new z0ZzZzmmk(documentContentStyle.PaddingLeft, documentContentStyle.PaddingTop, documentContentStyle.PaddingRight, documentContentStyle.PaddingBottom);
			}
			if (flag && z0ZzZzmmk2 != null)
			{
				DocumentContentStyle documentContentStyle2 = new DocumentContentStyle();
				documentContentStyle2.z0eek(p0: true);
				documentContentStyle2.PaddingLeft = z0ZzZzmmk2.Left;
				documentContentStyle2.PaddingTop = z0ZzZzmmk2.Top;
				documentContentStyle2.PaddingRight = z0ZzZzmmk2.Right;
				documentContentStyle2.PaddingBottom = z0ZzZzmmk2.Bottom;
				p1.Document.z0ytk();
				p1.Result = z0ZzZzhkh.z0rek(documentContentStyle2, documentContentStyle2, documentContentStyle2, p1.Document, xTextElementList2, p5: true, p1.Name, p7: true);
				p1.Document.z0nuk();
				p1.Document.OnSelectionChanged();
				p1.Document.OnDocumentContentChanged();
			}
		}
	}

	[z0ZzZzimj("Header4WithMultiNumberlist")]
	private void z0lrk(object p0, z0ZzZzomj p1)
	{
		z0ZzZzlmj p2 = z0ZzZzlmj.z0oek();
		z0eek(p1, p2);
	}

	[z0ZzZzimj("FontSize", ReturnValueType = typeof(bool), FunctionID = 60)]
	private void z0krk(object p0, z0ZzZzomj p1)
	{
		p1.EnableSetUITextAsParamter = true;
		if (p1.Mode == (z0ZzZzmmj)0)
		{
			return;
		}
		if (p1.Mode == (z0ZzZzmmj)2)
		{
			if (p1.Document == null)
			{
				p1.Enabled = false;
				return;
			}
			p1.Enabled = p1.DocumentControler != null && p1.DocumentControler.z0in().CanModifySelection;
			if (p1.Parameter == null)
			{
				float num = z0eek(p1.Document).FontSize;
				if (num <= 0f)
				{
					num = p1.Document.z0vmk().Size;
				}
				p1.Parameter = z0ZzZzdpj.z0eek(num, p1.EditorControl.z0cuk().BehaviorOptions.EnableChineseFontSizeName);
			}
			p1.SetParameterToUIText = true;
		}
		else if (p1.Mode == (z0ZzZzmmj)5)
		{
			z0eek(p0, p1, "FontSize");
			if (p1.EditorControl != null)
			{
				p1.EditorControl.z0cok();
			}
		}
	}

	[z0ZzZzimj("Superscript", ReturnValueType = typeof(bool), FunctionID = 64)]
	private void z0jrk(object p0, z0ZzZzomj p1)
	{
		z0eek(p0, p1, "Superscript");
	}

	[z0ZzZzimj("SectionBorderBackgroundFormat", ReturnValueType = typeof(bool), DefaultResultValue = false)]
	private void z0hrk(object p0, z0ZzZzomj p1)
	{
		if (p1.Mode == (z0ZzZzmmj)2)
		{
			p1.Enabled = false;
			if (p1.Document != null)
			{
				XTextSectionElement xTextSectionElement = (XTextSectionElement)p1.Document.z0bek(typeof(XTextSectionElement));
				if (xTextSectionElement != null && p1.DocumentControler.z0np(xTextSectionElement))
				{
					p1.Enabled = true;
				}
			}
		}
		else
		{
			if (p1.Mode != (z0ZzZzmmj)5)
			{
				return;
			}
			p1.Result = false;
			XTextSectionElement xTextSectionElement2 = (XTextSectionElement)p1.Document.z0bek(typeof(XTextSectionElement));
			if (xTextSectionElement2 == null || !p1.DocumentControler.z0np(xTextSectionElement2))
			{
				return;
			}
			DocumentContentStyle documentContentStyle = p1.Parameter as DocumentContentStyle;
			if (documentContentStyle != null || p1.ShowUI)
			{
				if (documentContentStyle == null)
				{
					documentContentStyle = xTextSectionElement2.z0aek().z0yek();
				}
				p1.Result = false;
				DocumentContentStyle documentContentStyle2 = xTextSectionElement2.z0aek().z0yek();
				z0ZzZzvik.z0eek(documentContentStyle, documentContentStyle2, p2: true);
				int styleIndex = p1.Document.z0gnk().GetStyleIndex(documentContentStyle2);
				if (p1.Document.z0ytk())
				{
					p1.Document.z0imk().z0eek(xTextSectionElement2, ((XTextElement)xTextSectionElement2).z0pek(), styleIndex);
					p1.Document.z0nuk();
				}
				xTextSectionElement2.z0oek(styleIndex);
				p1.Document.Modified = true;
				p1.Document.OnSelectionChanged();
				p1.Document.OnDocumentContentChanged();
				p1.RefreshLevel = (z0ZzZzwmj)0;
				xTextSectionElement2.z0jo();
				p1.Result = true;
			}
		}
	}

	[z0ZzZzimj("Header6WithMultiNumberlist")]
	private void z0grk(object p0, z0ZzZzomj p1)
	{
		z0ZzZzlmj p2 = z0ZzZzlmj.z0tek();
		z0eek(p1, p2);
	}

	[z0ZzZzimj("TextSurroundings", ReturnValueType = typeof(bool))]
	private void z0frk(object p0, z0ZzZzomj p1)
	{
		z0eek(p0, p1, "TextSurroundings");
	}

	[z0ZzZzimj("FontName", ReturnValueType = typeof(bool), FunctionID = 59)]
	private void z0drk(object p0, z0ZzZzomj p1)
	{
		p1.EnableSetUITextAsParamter = true;
		if (p1.Mode == (z0ZzZzmmj)0)
		{
			return;
		}
		if (p1.Mode == (z0ZzZzmmj)2)
		{
			if (p1.Document == null)
			{
				p1.Enabled = false;
				return;
			}
			p1.Enabled = p1.DocumentControler != null && p1.DocumentControler.z0in().CanModifySelection;
			if (p1.Parameter == null)
			{
				string text = p1.Document.z0onk().z0tek().FontName;
				if (text == null || text.Length == 0)
				{
					text = p1.Document.z0vmk().Name;
				}
				p1.Parameter = text;
			}
			p1.SetParameterToUIText = true;
		}
		else if (p1.Mode == (z0ZzZzmmj)5)
		{
			z0eek(p0, p1, "FontName");
			p1.RefreshLevel = (z0ZzZzwmj)1;
			if (p1.EditorControl != null)
			{
				p1.EditorControl.z0cok();
			}
		}
	}

	[z0ZzZzimj("BorderRight", ReturnValueType = typeof(bool))]
	private void z0srk(object p0, z0ZzZzomj p1)
	{
		z0rek(p0, p1, "BorderRight");
	}

	[z0ZzZzimj("InsertComment", ReturnValueType = typeof(bool))]
	private void z0ark(object p0, z0ZzZzomj p1)
	{
		if (p1.Mode == (z0ZzZzmmj)2)
		{
			p1.Enabled = false;
			if (p1.EditorControl == null || (p1.EditorControl.z0ork() && !p1.EditorControl.z0ttk()))
			{
				return;
			}
			if (!p1.EditorControl.z0cuk().BehaviorOptions.InsertCommentBindingUserTrack)
			{
				if (p1.Document.z0cuk().z0qrk() != 0)
				{
					p1.Enabled = true;
				}
				else if (p1.Document.z0ryk().Count > 1)
				{
					p1.Enabled = true;
				}
			}
			else
			{
				p1.Enabled = p1.EditorControl != null && p1.DocumentControler != null && p1.DocumentControler.z0in().CanModifySelection;
			}
		}
		else
		{
			if (p1.Mode != (z0ZzZzmmj)5)
			{
				return;
			}
			z0ZzZzhkh z0ZzZzhkh2 = p1.Document.z0cuk();
			if (z0ZzZzhkh2.z0qrk() == 0)
			{
				z0ZzZzhkh2 = ((z0ZzZzhkh2.z0nek() != p1.Document.z0ryk().Count - 1) ? p1.Document.z0jrk().z0rek(z0ZzZzhkh2.z0nek(), 1) : p1.Document.z0jrk().z0rek(z0ZzZzhkh2.z0nek() - 1, 1));
			}
			p1.Result = false;
			DocumentContentStyle documentContentStyle = p1.Document.CreateDocumentContentStyle();
			documentContentStyle.z0eek(p0: true);
			DocumentComment documentComment = null;
			if (p1.Parameter is DocumentComment)
			{
				documentComment = (DocumentComment)p1.Parameter;
			}
			else
			{
				documentComment = new DocumentComment();
				documentComment.z0pek(Convert.ToString(p1.Parameter));
			}
			if (p1.Parameter is DocumentComment)
			{
				DocumentComment documentComment2 = (DocumentComment)p1.Parameter;
				if (documentComment2.z0mrk() == z0ZzZzkfh.z0wrk)
				{
					documentComment2.z0eek(p1.Document.z0jpk());
				}
			}
			else
			{
				z0ZzZznbj z0ZzZznbj2 = (z0ZzZznbj)p1.Host.z0tek().z0eek(typeof(z0ZzZznbj));
				if (z0ZzZznbj2 == null)
				{
					documentComment.z0eek(Environment.UserName);
				}
				else
				{
					documentComment.z0eek(z0ZzZznbj2.z0uek());
					documentComment.z0rek(z0ZzZznbj2.z0eek());
				}
				documentComment.z0eek(p1.Document.z0jpk());
				documentComment.z0eek(p1.Document.z0buk());
				DocumentOptions documentOptions = p1.Document.z0vu();
				documentComment.z0eek(documentOptions.BehaviorOptions.InsertCommentBindingUserTrack);
				if (documentOptions.SecurityOptions.EnablePermission && p1.Document.z0syk().z0eek() != null)
				{
					documentComment.z0tek(p1.Document.z0syk().z0yek());
					documentComment.z0eek(p1.Document.z0syk().z0eek().z0yek());
					documentComment.z0rek(p1.Document);
				}
			}
			documentComment.z0eek(p1.Document.z0buk());
			z0ZzZzwcj z0ZzZzwcj2 = p1.Document.Comments.z0eek(p0: false);
			z0ZzZzwcj2.Add(documentComment);
			p1.Document.z0ytk();
			if (p1.Document.z0uik())
			{
				p1.Document.z0imk().z0eek("Comments", p1.Document.Comments, z0ZzZzwcj2, p1.Document);
			}
			p1.Document.Comments = z0ZzZzwcj2;
			documentContentStyle.CommentIndex = documentComment.z0tek();
			bool flag = false;
			flag = p1.EditorControl.z0oyk() != FunctionControlVisibility.Hide;
			z0ZzZzvik.z0eek(documentContentStyle, p1.Document.z0onk().z0tek(), p2: true);
			z0ZzZzvik.z0eek(documentContentStyle, p1.Document.z0onk().z0iek(), p2: true);
			p1.Result = z0ZzZzhkh2.z0rek(documentContentStyle, flag, p2: false, p1.Name);
			if (flag)
			{
				p1.EditorControl.z0yrk(p0: false);
				p1.Document.z0imk().z0eek((z0ZzZzbzj)1);
			}
			p1.Document.z0nuk();
			p1.Document.OnSelectionChanged();
			p1.Document.OnDocumentContentChanged();
		}
	}

	private XTextElementList z0rek(XTextDocument p0)
	{
		if (p0 == null)
		{
			return null;
		}
		if (p0.z0cuk() != null && p0.z0cuk().z0qrk() != 0)
		{
			XTextElementList xTextElementList = new XTextElementList();
			z0ZzZzpxj z0ZzZzpxj2 = p0.z0xek();
			z0ZzZzpxj2.z0mp();
			try
			{
				using (zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = p0.z0cuk().z0grk().z0ltk())
				{
					while (z0bpk.MoveNext())
					{
						XTextElement current = z0bpk.Current;
						if ((current is XTextObjectElement || current is XTextShapeInputFieldElement) && z0ZzZzpxj2.z0np(current))
						{
							((zzz.z0ZzZzkuk<XTextElement>)xTextElementList).z0pek(current);
						}
					}
				}
				if (p0.z0cuk().z0irk() != null)
				{
					using zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = p0.z0cuk().z0irk().z0ltk();
					while (z0bpk.MoveNext())
					{
						XTextTableCellElement xTextTableCellElement = (XTextTableCellElement)z0bpk.Current;
						if (!xTextTableCellElement.z0bek() && z0ZzZzpxj2.z0np(xTextTableCellElement))
						{
							((zzz.z0ZzZzkuk<XTextElement>)xTextElementList).z0pek((XTextElement)xTextTableCellElement);
						}
					}
				}
			}
			finally
			{
				z0ZzZzpxj2.z0on();
			}
			return xTextElementList;
		}
		XTextContainerElement p1 = null;
		int p2 = 0;
		p0.z0ryk().z0tek(out p1, out p2);
		while (p1 != null)
		{
			if (p1 is XTextShapeInputFieldElement || p1 is XTextTableCellElement)
			{
				XTextElementList xTextElementList2 = new XTextElementList();
				((zzz.z0ZzZzkuk<XTextElement>)xTextElementList2).z0pek((XTextElement)p1);
				return xTextElementList2;
			}
			p1 = p1.z0ji();
		}
		return null;
	}

	[z0ZzZzimj("Header3")]
	private void z0qrk(object p0, z0ZzZzomj p1)
	{
		z0ZzZzlmj p2 = z0ZzZzlmj.z0iek();
		z0eek(p1, p2);
	}

	[z0ZzZzimj("BorderBottom", ReturnValueType = typeof(bool))]
	private void z0wrk(object p0, z0ZzZzomj p1)
	{
		z0rek(p0, p1, "BorderBottom");
	}

	[z0ZzZzimj("Visibility", ReturnValueType = typeof(bool))]
	private void z0erk(object p0, z0ZzZzomj p1)
	{
		z0eek(p0, p1, "Visibility");
	}

	[z0ZzZzimj("FormatBrush", ReturnValueType = typeof(bool), DefaultResultValue = false, FunctionID = 57)]
	private void z0rrk(object p0, z0ZzZzomj p1)
	{
		if (p1.Mode == (z0ZzZzmmj)2)
		{
			p1.Enabled = false;
			if (p1.EditorControl != null && !p1.EditorControl.z0ork())
			{
				p1.Enabled = true;
				p1.Checked = p1.EditorControl.z0ypk().z0fok != null;
			}
		}
		else if (p1.Mode == (z0ZzZzmmj)5)
		{
			p1.Result = false;
			p1.RefreshLevel = (z0ZzZzwmj)1;
			p1.EditorControl.z0zyk();
			p1.EditorControl.z0ypk().z0fok = p1.Document.z0onk().z0rek();
			p1.Result = true;
		}
	}

	[z0ZzZzimj("DeleteAllComment")]
	private void z0trk(object p0, z0ZzZzomj p1)
	{
		if (p1.Mode == (z0ZzZzmmj)2)
		{
			p1.Enabled = false;
			if (p1.EditorControl != null && (!p1.EditorControl.z0ork() || p1.EditorControl.z0ttk()))
			{
				p1.Enabled = p1.Document.Comments.Count > 0;
			}
		}
		else if (p1.Mode == (z0ZzZzmmj)5)
		{
			p1.Parameter = p1.Document.Comments;
			p1.Result = z0eek(p1, p1: false);
		}
	}

	[z0ZzZzimj("Subscript", ReturnValueType = typeof(bool), FunctionID = 64)]
	private void z0yrk(object p0, z0ZzZzomj p1)
	{
		z0eek(p0, p1, "Subscript");
	}

	[z0ZzZzimj("Italic", ShortcutKey = (Keys.I | Keys.Control), ReturnValueType = typeof(bool), FunctionID = 61)]
	private void z0urk(object p0, z0ZzZzomj p1)
	{
		z0eek(p0, p1, "Italic");
	}

	[z0ZzZzimj("PrintBackColor", ReturnValueType = typeof(bool))]
	private void z0irk(object p0, z0ZzZzomj p1)
	{
		z0tek(p0, p1, "PrintBackColor");
	}

	[z0ZzZzimj("Font", ReturnValueType = typeof(bool), FunctionID = 59)]
	private void z0ork(object p0, z0ZzZzomj p1)
	{
		if (p1.Mode == (z0ZzZzmmj)2)
		{
			p1.Enabled = p1.DocumentControler != null && p1.DocumentControler.z0in().CanModifySelection;
		}
		else if (p1.Mode == (z0ZzZzmmj)5)
		{
			DocumentContentStyle documentContentStyle = z0eek(p1.Document);
			z0ZzZzimk z0ZzZzimk2 = new z0ZzZzimk();
			if (p1.Parameter == null)
			{
				z0ZzZzimk2 = documentContentStyle.Font;
			}
			else if (!(p1.Parameter is string))
			{
				z0ZzZzimk2 = ((p1.Parameter is z0ZzZzimk) ? ((z0ZzZzimk)p1.Parameter).Clone() : ((!(p1.Parameter is z0ZzZzsdh)) ? documentContentStyle.Font : new z0ZzZzimk((z0ZzZzsdh)p1.Parameter)));
			}
			else
			{
				z0ZzZzimk2 = documentContentStyle.Font.Clone();
				z0ZzZzimk2.z0eek((string)p1.Parameter);
			}
			p1.Parameter = z0ZzZzimk2;
			z0eek(p0, p1, "Font");
		}
	}

	[z0ZzZzimj("DeleteComment", ReturnValueType = typeof(bool))]
	private void z0prk(object p0, z0ZzZzomj p1)
	{
		if (p1.Mode == (z0ZzZzmmj)2)
		{
			p1.Enabled = false;
			if (p1.EditorControl != null && (!p1.EditorControl.z0ork() || p1.EditorControl.z0ttk()))
			{
				p1.Enabled = true;
			}
		}
		else if (p1.Mode == (z0ZzZzmmj)5)
		{
			p1.Result = z0eek(p1, p1: true);
		}
	}

	[z0ZzZzimj("ClearFormat", ReturnValueType = typeof(bool), DefaultResultValue = false, FunctionID = 58)]
	private void z0mrk(object p0, z0ZzZzomj p1)
	{
		if (p1.Mode == (z0ZzZzmmj)2)
		{
			p1.Enabled = false;
			if (p1.Document != null)
			{
				XTextElementList xTextElementList = z0eek(p1.Document, p1: true, p2: true, p3: true, (z0ZzZztcj)p1.DocumentControler);
				if (xTextElementList != null && xTextElementList.Count > 0)
				{
					p1.Enabled = true;
				}
			}
		}
		else
		{
			if (p1.Mode != (z0ZzZzmmj)5)
			{
				return;
			}
			p1.Result = false;
			XTextElementList xTextElementList2 = z0eek(p1.Document, p1: true, p2: true, p3: true, (z0ZzZztcj)p1.DocumentControler);
			if (xTextElementList2 == null || xTextElementList2.Count <= 0)
			{
				return;
			}
			p1.EditorControl.z0iuk();
			p1.Document.z0ytk();
			DocumentContentStyle documentContentStyle = (DocumentContentStyle)p1.Document.z0gnk().Default.Clone();
			documentContentStyle.z0eek(p0: true);
			if (p1.Document.z0hi().EnablePermission)
			{
				documentContentStyle.CreatorIndex = p1.Document.z0syk().z0yek();
			}
			p1.Result = z0ZzZzhkh.z0rek(documentContentStyle, documentContentStyle, documentContentStyle, p1.Document, xTextElementList2, p5: true, p1.Name, p7: true);
			p1.Document.z0nuk();
			if ((bool)p1.Result)
			{
				p1.Document.OnSelectionChanged();
				p1.Document.OnDocumentContentChanged();
				if (p1.EditorControl != null)
				{
					p1.EditorControl.z0nuk();
				}
			}
		}
	}

	private static XTextElementList z0eek(XTextDocument p0, bool p1, bool p2, bool p3, z0ZzZztcj p4)
	{
		if (p4 == null)
		{
			p4 = (z0ZzZztcj)p0.z0xek();
		}
		if (p4 == null)
		{
			return null;
		}
		XTextElementList xTextElementList = new XTextElementList();
		p4.z0mp();
		try
		{
			if (p1 && p0 != null && p0.z0cuk().z0qrk() != 0)
			{
				using zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = p0.z0cuk().z0grk().z0ltk();
				while (z0bpk.MoveNext())
				{
					XTextElement current = z0bpk.Current;
					if (p4.z0np(current))
					{
						((zzz.z0ZzZzkuk<XTextElement>)xTextElementList).z0pek(current);
					}
				}
			}
			if (p2)
			{
				if (p0.z0cuk().z0qrk() == 0)
				{
					XTextParagraphFlagElement xTextParagraphFlagElement = p0.z0mtk();
					if (xTextParagraphFlagElement != null && p4.z0np(xTextParagraphFlagElement))
					{
						((zzz.z0ZzZzkuk<XTextElement>)xTextElementList).z0pek((XTextElement)xTextParagraphFlagElement);
					}
				}
				else
				{
					using zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = p0.z0cuk().z0krk().z0ltk();
					while (z0bpk.MoveNext())
					{
						XTextElement current2 = z0bpk.Current;
						if (p4.z0np(current2))
						{
							((zzz.z0ZzZzkuk<XTextElement>)xTextElementList).z0pek(current2);
						}
					}
				}
			}
			if (p3)
			{
				if (p0.z0cuk().z0irk() != null && p0.z0cuk().z0irk().Count > 0)
				{
					using zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = p0.z0cuk().z0irk().z0ltk();
					while (z0bpk.MoveNext())
					{
						XTextTableCellElement xTextTableCellElement = (XTextTableCellElement)z0bpk.Current;
						if (!xTextTableCellElement.z0bek() && p4.z0np(xTextTableCellElement))
						{
							((zzz.z0ZzZzkuk<XTextElement>)xTextElementList).z0pek((XTextElement)xTextTableCellElement);
						}
					}
				}
				else
				{
					XTextElement xTextElement = p0.z0itk();
					if (xTextElement != null)
					{
						XTextTableCellElement xTextTableCellElement2 = xTextElement.z0brk();
						if (xTextTableCellElement2 != null && !xTextTableCellElement2.z0bek() && p4.z0np(xTextTableCellElement2))
						{
							((zzz.z0ZzZzkuk<XTextElement>)xTextElementList).z0pek((XTextElement)xTextTableCellElement2);
						}
					}
				}
			}
		}
		finally
		{
			p4.z0on();
		}
		if (xTextElementList.Count > 0)
		{
			return xTextElementList;
		}
		return null;
	}

	[z0ZzZzimj("ContentProtect", ReturnValueType = typeof(bool))]
	private void z0nrk(object p0, z0ZzZzomj p1)
	{
		z0eek(p0, p1, "ContentProtect");
	}

	[z0ZzZzimj("Header5WithMultiNumberlist")]
	private void z0brk(object p0, z0ZzZzomj p1)
	{
		z0ZzZzlmj p2 = z0ZzZzlmj.z0frk();
		z0eek(p1, p2);
	}

	[z0ZzZzimj("UpdateDirectoryField")]
	private void z0vrk(object p0, z0ZzZzomj p1)
	{
		if (p1.Mode == (z0ZzZzmmj)2)
		{
			p1.Enabled = false;
			if (p1.Document != null && (XTextDirectoryFieldElement)p1.Document.z0bek(typeof(XTextDirectoryFieldElement)) != null)
			{
				p1.Enabled = true;
			}
		}
		else if (p1.Mode == (z0ZzZzmmj)5)
		{
			((XTextDirectoryFieldElement)p1.Document.z0bek(typeof(XTextDirectoryFieldElement)))?.z0rek(p0: true);
		}
	}

	[z0ZzZzimj("BulletedList", ReturnValueType = typeof(bool))]
	private void z0crk(object p0, z0ZzZzomj p1)
	{
		z0rek(p0, p1, "BulletedList");
	}

	[z0ZzZzimj("AlignRight", ReturnValueType = typeof(bool))]
	private void z0xrk(object p0, z0ZzZzomj p1)
	{
		z0rek(p0, p1, "AlignRight");
	}

	[z0ZzZzimj("AlignDistribute", ReturnValueType = typeof(bool))]
	private void z0zrk(object p0, z0ZzZzomj p1)
	{
		z0rek(p0, p1, "AlignDistribute");
	}

	private void z0eek(z0ZzZzbpj p0, z0ZzZzomj p1, XTextElementList p2)
	{
		p1.Document.z0ytk();
		bool flag = false;
		z0ZzZzpxj documentControler = p1.DocumentControler;
		try
		{
			documentControler.z0mp();
			using zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = p2.z0ltk();
			while (z0bpk.MoveNext())
			{
				XTextElement current = z0bpk.Current;
				if (!documentControler.z0np(current))
				{
					continue;
				}
				DocumentContentStyle documentContentStyle = current.z0aek().z0yek();
				if (!p0.z0eek(documentContentStyle))
				{
					continue;
				}
				flag = true;
				int styleIndex = p1.Document.z0gnk().GetStyleIndex(documentContentStyle);
				if (styleIndex == current.z0pek())
				{
					continue;
				}
				if (p1.Document.z0uik())
				{
					p1.Document.z0imk().z0eek(current, current.z0pek(), styleIndex);
				}
				current.z0oek(styleIndex);
				XTextElement xTextElement = current.z0ku();
				if (xTextElement != null)
				{
					if (p1.Document.z0uik())
					{
						p1.Document.z0imk().z0eek(xTextElement, xTextElement.z0pek(), styleIndex);
					}
					xTextElement.z0oek(styleIndex);
					xTextElement.z0jo();
				}
				current.z0jy().z0tek(p0: true);
				current.z0jo();
				current.z0rrk();
			}
		}
		finally
		{
			documentControler.z0on();
		}
		p1.Document.z0nuk();
		if (flag)
		{
			p1.Result = true;
			p1.Document.Modified = true;
			p1.Document.OnDocumentContentChanged();
		}
	}

	[z0ZzZzimj("PrintColor", ReturnValueType = typeof(bool))]
	private void z0ltk(object p0, z0ZzZzomj p1)
	{
		z0tek(p0, p1, "PrintColor");
	}

	[z0ZzZzimj("Bold", ShortcutKey = (Keys.B | Keys.Control), ReturnValueType = typeof(bool), FunctionID = 61)]
	private void z0ktk(object p0, z0ZzZzomj p1)
	{
		z0eek(p0, p1, "Bold");
	}

	[z0ZzZzimj("NumberedList", ReturnValueType = typeof(bool))]
	private void z0jtk(object p0, z0ZzZzomj p1)
	{
		z0rek(p0, p1, "NumberedList");
	}

	[z0ZzZzimj("AlignLeft", ReturnValueType = typeof(bool))]
	private void z0htk(object p0, z0ZzZzomj p1)
	{
		z0rek(p0, p1, "AlignLeft");
	}

	public static void z0eek(z0ZzZzbpj p0, z0ZzZzomj p1, bool p2)
	{
		XTextElementList xTextElementList = new XTextElementList();
		if (p0.z0hrk() != null)
		{
			using zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = p0.z0hrk().z0ltk();
			while (z0bpk.MoveNext())
			{
				XTextElement current = z0bpk.Current;
				if (current is XTextTableCellElement)
				{
					xTextElementList.Add(current);
				}
			}
		}
		if (xTextElementList.Count == 0)
		{
			if (p1.Parameter is XTextTableCellElement)
			{
				xTextElementList.Add((XTextTableCellElement)p1.Parameter);
			}
			else if (p1.Parameter is XTextElementList)
			{
				xTextElementList = (XTextElementList)p1.Parameter;
			}
			else
			{
				z0ZzZzhkh z0ZzZzhkh2 = p1.Document.z0cuk();
				if (z0ZzZzhkh2.z0yek() == ContentRangeMode.Cell)
				{
					xTextElementList = z0ZzZzhkh2.z0irk();
				}
				else if (p1.Document.z0itk() != null && p1.Document.z0itk().z0brk() != null)
				{
					xTextElementList.Add(p1.Document.z0itk().z0brk());
				}
			}
		}
		if (xTextElementList.Count == 0)
		{
			return;
		}
		int p3 = 0;
		int p4 = 0;
		int p5 = 0;
		int p6 = 0;
		if (p0.z0rek() == StyleApplyRanges.Cell)
		{
			z0eek(xTextElementList, ref p3, ref p4, ref p5, ref p6);
		}
		else
		{
			XTextTableElement xTextTableElement = ((XTextTableCellElement)xTextElementList[0]).z0gr();
			xTextElementList = xTextTableElement.z0zek();
			p3 = 0;
			p4 = 0;
			p5 = xTextTableElement.z0stk().Count;
			p6 = xTextTableElement.z0srk().Count;
		}
		p1.Document.z0ytk();
		bool flag = false;
		z0ZzZztcj z0ZzZztcj2 = (z0ZzZztcj)p1.DocumentControler;
		using (zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = xTextElementList.z0ltk())
		{
			while (z0bpk.MoveNext())
			{
				XTextTableCellElement xTextTableCellElement = (XTextTableCellElement)z0bpk.Current;
				if (xTextTableCellElement.z0bek() || !z0ZzZztcj2.z0np(xTextTableCellElement))
				{
					continue;
				}
				DocumentContentStyle documentContentStyle = xTextTableCellElement.z0aek().z0yek();
				bool flag2 = false;
				bool borderTop = documentContentStyle.BorderTop;
				borderTop = ((xTextTableCellElement.z0pek() != p3) ? p0.z0eek() : p0.z0oek());
				if (borderTop != documentContentStyle.BorderTop)
				{
					documentContentStyle.BorderTop = borderTop;
					flag2 = true;
				}
				borderTop = documentContentStyle.BorderLeft;
				borderTop = ((xTextTableCellElement.z0xek() != p4) ? p0.z0lrk() : p0.z0krk());
				if (borderTop != documentContentStyle.BorderLeft)
				{
					documentContentStyle.BorderLeft = borderTop;
					flag2 = true;
				}
				borderTop = documentContentStyle.BorderRight;
				borderTop = ((xTextTableCellElement.z0xek() + xTextTableCellElement.ColSpan != p6) ? p0.z0lrk() : p0.z0cek());
				if (borderTop != documentContentStyle.BorderRight)
				{
					documentContentStyle.BorderRight = borderTop;
					flag2 = true;
				}
				borderTop = documentContentStyle.BorderBottom;
				borderTop = ((xTextTableCellElement.z0pek() + xTextTableCellElement.RowSpan != p5) ? p0.z0eek() : p0.z0jrk());
				if (borderTop != documentContentStyle.BorderBottom)
				{
					documentContentStyle.BorderBottom = borderTop;
					flag2 = true;
				}
				if (!p2)
				{
					if (documentContentStyle.BorderLeftColor.ToArgb() != p0.z0zek().ToArgb())
					{
						documentContentStyle.BorderLeftColor = p0.z0zek();
						flag2 = true;
					}
					if (documentContentStyle.BorderTopColor.ToArgb() != p0.z0bek().ToArgb())
					{
						documentContentStyle.BorderTopColor = p0.z0bek();
						flag2 = true;
					}
					if (documentContentStyle.BorderRightColor.ToArgb() != p0.z0grk().ToArgb())
					{
						documentContentStyle.BorderRightColor = p0.z0grk();
						flag2 = true;
					}
					if (documentContentStyle.BorderBottomColor.ToArgb() != p0.z0mek().ToArgb())
					{
						documentContentStyle.BorderBottomColor = p0.z0mek();
						flag2 = true;
					}
					if (documentContentStyle.BorderStyle != p0.z0pek())
					{
						documentContentStyle.BorderStyle = p0.z0pek();
						flag2 = true;
					}
					if (documentContentStyle.BorderWidth != p0.z0iek())
					{
						documentContentStyle.BorderWidth = p0.z0iek();
						flag2 = true;
					}
					if (!documentContentStyle.BackgroundColor.IsEmpty && documentContentStyle.BackgroundColor.ToArgb() != p0.z0vek().ToArgb())
					{
						documentContentStyle.BackgroundColor = p0.z0vek();
						flag2 = true;
					}
				}
				if (!flag2)
				{
					continue;
				}
				flag = true;
				if (xTextTableCellElement.z0ji().z0brk())
				{
					documentContentStyle.CreatorIndex = p1.Document.z0syk().z0yek();
					documentContentStyle.DeleterIndex = -1;
				}
				int styleIndex = p1.Document.z0gnk().GetStyleIndex(documentContentStyle);
				if (styleIndex != ((XTextElement)xTextTableCellElement).z0pek())
				{
					if (p1.Document.z0uik())
					{
						p1.Document.z0imk().z0eek(xTextTableCellElement, ((XTextElement)xTextTableCellElement).z0pek(), styleIndex);
					}
					xTextTableCellElement.z0oek(styleIndex);
					xTextTableCellElement.z0jo();
					((XTextElement)xTextTableCellElement).z0rrk();
					ContentChangedEventArgs e = new ContentChangedEventArgs();
					e.Document = p1.Document;
					e.Element = xTextTableCellElement;
					xTextTableCellElement.z0zi(e);
				}
			}
		}
		p1.Document.z0nuk();
		if (flag)
		{
			p1.Document.Modified = true;
			p1.Document.OnDocumentContentChanged();
			p1.Result = true;
		}
	}

	[z0ZzZzimj("Header5")]
	private void z0gtk(object p0, z0ZzZzomj p1)
	{
		z0ZzZzlmj p2 = z0ZzZzlmj.z0vek();
		z0eek(p1, p2);
	}

	[z0ZzZzimj("UnderlineStyle", ReturnValueType = typeof(bool), FunctionID = 61)]
	private void z0ftk(object p0, z0ZzZzomj p1)
	{
		if (p1.Mode == (z0ZzZzmmj)2)
		{
			z0eek(p0, p1, "UnderlineStyle");
		}
		else
		{
			if (p1.Mode != (z0ZzZzmmj)5)
			{
				return;
			}
			DocumentContentStyle documentContentStyle = z0eek(p1.Document);
			TextUnderlineStyle textUnderlineStyle = TextUnderlineStyle.Single;
			Color color = documentContentStyle.Color;
			if (p1.Parameter is TextUnderlineStyle)
			{
				textUnderlineStyle = (TextUnderlineStyle)p1.Parameter;
			}
			else if (p1.Parameter is string && !string.IsNullOrEmpty((string)p1.Parameter))
			{
				string text = (string)p1.Parameter;
				int num = text.IndexOf(';');
				if (num > 0)
				{
					textUnderlineStyle = (TextUnderlineStyle)z0ZzZzafh.z0yek(text.Substring(0, num).Trim(), textUnderlineStyle);
					color = z0eek(text.Substring(num + 1), color);
				}
				else
				{
					textUnderlineStyle = (TextUnderlineStyle)z0ZzZzafh.z0yek(text, textUnderlineStyle);
				}
			}
			else if (p1.ShowUI && p1.Parameter != null)
			{
				string.IsNullOrEmpty((string)p1.Parameter);
			}
			p1.Parameter = new object[2]
			{
				textUnderlineStyle,
				z0ZzZzlok.z0eek(color)
			};
			z0eek(p0, p1, "UnderlineStyle");
		}
	}

	[z0ZzZzimj("Header1")]
	private void z0dtk(object p0, z0ZzZzomj p1)
	{
		z0ZzZzlmj p2 = z0ZzZzlmj.z0uek();
		z0eek(p1, p2);
	}

	[z0ZzZzimj("InputFieldUnderLine", ReturnValueType = typeof(bool), DefaultResultValue = false)]
	private void z0stk(object p0, z0ZzZzomj p1)
	{
		if (p1.Mode == (z0ZzZzmmj)2)
		{
			p1.Enabled = false;
			if (p1.EditorControl != null && !p1.EditorControl.z0ork() && p1.EditorControl.z0dtk() != null && p1.DocumentControler.z0np(p1.EditorControl.z0dtk()))
			{
				p1.Enabled = true;
			}
		}
		else
		{
			if (p1.Mode != (z0ZzZzmmj)5)
			{
				return;
			}
			p1.Result = false;
			bool flag = false;
			z0ZzZzkmj z0ZzZzkmj2 = new z0ZzZzkmj();
			XTextInputFieldElement xTextInputFieldElement = p1.EditorControl.z0dtk();
			DocumentContentStyle documentContentStyle = null;
			if (xTextInputFieldElement == null)
			{
				return;
			}
			documentContentStyle = ((XTextElement)xTextInputFieldElement).z0xrk();
			if (p1.Parameter is bool)
			{
				flag = (bool)p1.Parameter;
			}
			else if (p1.Parameter is z0ZzZzkmj)
			{
				flag = true;
				z0ZzZzkmj2 = (z0ZzZzkmj)p1.Parameter;
			}
			if (flag)
			{
				documentContentStyle.BorderTop = false;
				documentContentStyle.BorderLeft = false;
				documentContentStyle.BorderRight = false;
				documentContentStyle.BorderBottom = true;
				documentContentStyle.BorderBottomColor = z0ZzZzkmj2.z0eek();
				documentContentStyle.BorderStyle = z0ZzZzkmj2.z0uek();
				documentContentStyle.BorderWidth = z0ZzZzkmj2.z0iek();
			}
			else
			{
				documentContentStyle.BorderTop = false;
				documentContentStyle.BorderLeft = false;
				documentContentStyle.BorderRight = false;
				documentContentStyle.BorderBottom = false;
			}
			p1.Document.z0ytk();
			if (xTextInputFieldElement != null)
			{
				if (z0ZzZzkmj2.z0rek())
				{
					xTextInputFieldElement.SpecifyWidth = z0ZzZzafh.z0yek(p1.Document, (decimal)z0ZzZzkmj2.z0tek());
				}
				xTextInputFieldElement.z0yek(documentContentStyle);
				xTextInputFieldElement.z0oe();
			}
			p1.Document.z0nuk();
			p1.Document.OnDocumentContentChanged();
			p1.Result = true;
		}
	}

	protected override z0ZzZzvmj z0qz()
	{
		z0ZzZzvmj obj = new z0ZzZzvmj();
		z0ZzZzcmj.z0rek(obj, "AlignCenter", z0xek);
		z0ZzZzcmj.z0rek(obj, "AlignDistribute", z0zrk);
		z0ZzZzcmj.z0rek(obj, "AlignJustify", z0ptk);
		z0ZzZzcmj.z0rek(obj, "AlignLeft", z0htk);
		z0ZzZzcmj.z0rek(obj, "AlignRight", z0xrk);
		z0ZzZzcmj.z0rek(obj, "BackColor", z0iek);
		z0ZzZzcmj.z0rek(obj, "Bold", z0ktk, Keys.B | Keys.Control);
		z0ZzZzcmj.z0rek(obj, "BorderBackgroundFormat", z0vek);
		z0ZzZzcmj.z0rek(obj, "BorderBottom", z0wrk);
		z0ZzZzcmj.z0rek(obj, "BorderLeft", z0tek);
		z0ZzZzcmj.z0rek(obj, "BorderRight", z0srk);
		z0ZzZzcmj.z0rek(obj, "BorderTop", z0mek);
		z0ZzZzcmj.z0rek(obj, "BulletedList", z0crk);
		z0ZzZzcmj.z0rek(obj, "CharacterCircle", z0qtk);
		z0ZzZzcmj.z0rek(obj, "ClearFormat", z0mrk);
		z0ZzZzcmj.z0rek(obj, "Color", z0yek);
		z0ZzZzcmj.z0rek(obj, "ContentProtect", z0nrk);
		z0ZzZzcmj.z0rek(obj, "DeleteAllComment", z0trk);
		z0ZzZzcmj.z0rek(obj, "DeleteComment", z0prk);
		z0ZzZzcmj.z0rek(obj, "DeleteCommentWithoutValidatePermission", z0cek);
		z0ZzZzcmj.z0rek(obj, "EditComment", z0otk);
		z0ZzZzcmj.z0rek(obj, "EmbedInText", z0bek);
		z0ZzZzcmj.z0rek(obj, "EmphasisMark", z0wtk);
		z0ZzZzcmj.z0rek(obj, "FirstLineIndent", z0rek);
		z0ZzZzcmj.z0rek(obj, "FixedSpacing", z0itk);
		z0ZzZzcmj.z0rek(obj, "Font", z0ork);
		z0ZzZzcmj.z0rek(obj, "FontName", z0drk);
		z0ZzZzcmj.z0rek(obj, "FontSize", z0krk);
		z0ZzZzcmj.z0rek(obj, "FormatBrush", z0rrk);
		z0ZzZzcmj.z0rek(obj, "Header1", z0dtk);
		z0ZzZzcmj.z0rek(obj, "Header1WithMultiNumberlist", z0atk);
		z0ZzZzcmj.z0rek(obj, "Header2", z0nek);
		z0ZzZzcmj.z0rek(obj, "Header2WithMultiNumberlist", z0oek);
		z0ZzZzcmj.z0rek(obj, "Header3", z0qrk);
		z0ZzZzcmj.z0rek(obj, "Header3WithMultiNumberlist", z0etk);
		z0ZzZzcmj.z0rek(obj, "Header4", z0uek);
		z0ZzZzcmj.z0rek(obj, "Header4WithMultiNumberlist", z0lrk);
		z0ZzZzcmj.z0rek(obj, "Header5", z0gtk);
		z0ZzZzcmj.z0rek(obj, "Header5WithMultiNumberlist", z0brk);
		z0ZzZzcmj.z0rek(obj, "Header6", z0mtk);
		z0ZzZzcmj.z0rek(obj, "Header6WithMultiNumberlist", z0grk);
		z0ZzZzcmj.z0rek(obj, "HeaderFormat", z0pek);
		z0ZzZzcmj.z0rek(obj, "IncreaseFirstLineIndent", z0ytk);
		z0ZzZzcmj.z0rek(obj, "InputFieldUnderLine", z0stk);
		z0ZzZzcmj.z0rek(obj, "InsertComment", z0ark);
		z0ZzZzcmj.z0rek(obj, "Italic", z0urk, Keys.I | Keys.Control);
		z0ZzZzcmj.z0rek(obj, "LayoutDirection", z0ttk);
		z0ZzZzcmj.z0rek(obj, "LetterSpacing", z0btk);
		z0ZzZzcmj.z0rek(obj, "NumberedList", z0jtk);
		z0ZzZzcmj.z0rek(obj, "Padding", z0zek);
		z0ZzZzcmj.z0rek(obj, "ParagraphFormat", z0vtk);
		z0ZzZzcmj.z0rek(obj, "ParagraphListStyle", z0eek);
		z0ZzZzcmj.z0rek(obj, "PrintBackColor", z0irk);
		z0ZzZzcmj.z0rek(obj, "PrintColor", z0ltk);
		z0ZzZzcmj.z0rek(obj, "SectionBorderBackgroundFormat", z0hrk);
		z0ZzZzcmj.z0rek(obj, "Strikeout", z0rtk);
		z0ZzZzcmj.z0rek(obj, "Subscript", z0yrk);
		z0ZzZzcmj.z0rek(obj, "Superscript", z0jrk);
		z0ZzZzcmj.z0rek(obj, "TextSurroundings", z0frk);
		z0ZzZzcmj.z0rek(obj, "TitleLevel", z0ntk);
		z0ZzZzcmj.z0rek(obj, "Underline", z0utk, Keys.U | Keys.Control);
		z0ZzZzcmj.z0rek(obj, "UnderlineStyle", z0ftk);
		z0ZzZzcmj.z0rek(obj, "UpdateDirectoryField", z0vrk);
		z0ZzZzcmj.z0rek(obj, "Visibility", z0erk);
		return obj;
	}

	private bool z0eek(z0ZzZzbpj p0, z0ZzZzomj p1)
	{
		z0ZzZzhkh z0ZzZzhkh2 = p1.Document.z0cuk();
		XTextElementList xTextElementList = new XTextElementList();
		if (z0ZzZzhkh2.z0yek() == ContentRangeMode.Cell)
		{
			xTextElementList = z0ZzZzhkh2.z0irk();
		}
		else
		{
			XTextTableCellElement xTextTableCellElement = p1.Document.z0itk().z0brk();
			if (xTextTableCellElement != null)
			{
				xTextElementList.Add(xTextTableCellElement);
			}
		}
		if (xTextElementList.Count > 0)
		{
			int p2 = 0;
			int p3 = 0;
			int p4 = 0;
			int p5 = 0;
			z0eek(xTextElementList, ref p2, ref p3, ref p4, ref p5);
			p0.z0eek(p0: true);
			p0.z0uek(p0: true);
			p0.z0iek(p0: true);
			p0.z0tek(p0: true);
			p0.z0rek(p4 - p2 > 1);
			p0.z0pek(p5 - p3 > 1);
			using (zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = xTextElementList.z0ltk())
			{
				while (z0bpk.MoveNext())
				{
					XTextTableCellElement xTextTableCellElement2 = (XTextTableCellElement)z0bpk.Current;
					z0ZzZzrzj z0ZzZzrzj2 = xTextTableCellElement2.z0aek();
					if (xTextTableCellElement2.z0pek() == p2)
					{
						if (!z0ZzZzrzj2.z0wyk)
						{
							p0.z0uek(p0: false);
						}
					}
					else if (xTextTableCellElement2.z0pek() < p4 && !z0ZzZzrzj2.z0wyk)
					{
						p0.z0pek(p0: false);
					}
					if (xTextTableCellElement2.z0pek() + xTextTableCellElement2.RowSpan == p4 && !z0ZzZzrzj2.z0mrk)
					{
						p0.z0tek(p0: false);
					}
					if (xTextTableCellElement2.z0xek() == p3)
					{
						if (!z0ZzZzrzj2.z0rrk)
						{
							p0.z0eek(p0: false);
						}
					}
					else if (xTextTableCellElement2.z0xek() < p5 && !z0ZzZzrzj2.z0rrk)
					{
						p0.z0rek(p0: false);
					}
					if (xTextTableCellElement2.z0xek() + xTextTableCellElement2.ColSpan == p5 && !z0ZzZzrzj2.z0etk)
					{
						p0.z0iek(p0: false);
					}
				}
			}
			p0.z0uek();
			z0ZzZzrzj z0ZzZzrzj3 = xTextElementList[0].z0aek();
			p0.z0eek(z0ZzZzrzj3.z0nek);
			p0.z0uek(z0ZzZzrzj3.z0myk);
			p0.z0tek(z0ZzZzrzj3.z0grk);
			p0.z0yek(z0ZzZzrzj3.z0trk);
			p0.z0eek(z0ZzZzrzj3.z0guk);
			p0.z0eek(z0ZzZzrzj3.z0erk);
			p0.z0rek(z0ZzZzrzj3.z0ark);
			return true;
		}
		return false;
	}

	[z0ZzZzimj("Header1WithMultiNumberlist")]
	private void z0atk(object p0, z0ZzZzomj p1)
	{
		z0ZzZzlmj p2 = z0ZzZzlmj.z0zek();
		z0eek(p1, p2);
	}

	public static void z0eek(XTextElementList p0, ref int p1, ref int p2, ref int p3, ref int p4)
	{
		p1 = 10000;
		p2 = 10000;
		p3 = 0;
		p4 = 0;
		using zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = p0.z0ltk();
		while (z0bpk.MoveNext())
		{
			XTextTableCellElement xTextTableCellElement = (XTextTableCellElement)z0bpk.Current;
			if (xTextTableCellElement.z0pek() < p1)
			{
				p1 = xTextTableCellElement.z0pek();
			}
			if (xTextTableCellElement.z0xek() < p2)
			{
				p2 = xTextTableCellElement.z0xek();
			}
			if (xTextTableCellElement.z0pek() + xTextTableCellElement.RowSpan > p3)
			{
				p3 = xTextTableCellElement.z0pek() + xTextTableCellElement.RowSpan;
			}
			if (xTextTableCellElement.z0xek() + xTextTableCellElement.ColSpan > p4)
			{
				p4 = xTextTableCellElement.z0xek() + xTextTableCellElement.ColSpan;
			}
		}
	}

	[z0ZzZzimj("CharacterCircle", ReturnValueType = typeof(bool), FunctionID = 66)]
	private void z0qtk(object p0, z0ZzZzomj p1)
	{
		z0eek(p0, p1, "CharacterCircle");
	}

	[z0ZzZzimj("EmphasisMark", ReturnValueType = typeof(bool), FunctionID = 65)]
	private void z0wtk(object p0, z0ZzZzomj p1)
	{
		z0eek(p0, p1, "EmphasisMark");
	}

	[z0ZzZzimj("Header3WithMultiNumberlist")]
	private void z0etk(object p0, z0ZzZzomj p1)
	{
		z0ZzZzlmj p2 = z0ZzZzlmj.z0yek();
		z0eek(p1, p2);
	}

	[z0ZzZzimj("Strikeout", ReturnValueType = typeof(bool))]
	private void z0rtk(object p0, z0ZzZzomj p1)
	{
		z0eek(p0, p1, "Strikeout");
	}

	private StyleApplyRanges z0eek(z0ZzZzomj p0)
	{
		StyleApplyRanges styleApplyRanges = StyleApplyRanges.None;
		if (p0.EditorControl == null)
		{
			return styleApplyRanges;
		}
		if (p0.EditorControl != null && p0.EditorControl.z0ork())
		{
			return styleApplyRanges;
		}
		if (p0.Document.z0cuk().z0yek() == ContentRangeMode.Content && p0.Document.z0cuk().z0qrk() != 0 && p0.DocumentControler.z0in().CanModifySelection)
		{
			return styleApplyRanges | StyleApplyRanges.Text | StyleApplyRanges.Paragraph;
		}
		if (p0.DocumentControler.z0in().CanModifyParagraphs)
		{
			styleApplyRanges |= StyleApplyRanges.Paragraph;
		}
		if (p0.Document.z0cuk().z0yek() == ContentRangeMode.Cell)
		{
			styleApplyRanges |= StyleApplyRanges.Cell;
		}
		for (XTextElement xTextElement = p0.Document.z0itk(); xTextElement != null; xTextElement = xTextElement.z0ji())
		{
			if (p0.DocumentControler.z0np(xTextElement))
			{
				if (xTextElement is XTextObjectElement)
				{
					styleApplyRanges |= StyleApplyRanges.Text;
				}
				else if (xTextElement is XTextInputFieldElement)
				{
					styleApplyRanges |= StyleApplyRanges.Field;
				}
				else if (xTextElement is XTextTableCellElement)
				{
					styleApplyRanges = styleApplyRanges | StyleApplyRanges.Cell | StyleApplyRanges.Row | StyleApplyRanges.Table;
				}
				else if (xTextElement is XTextSectionElement)
				{
					styleApplyRanges |= StyleApplyRanges.Section;
				}
			}
		}
		return styleApplyRanges;
	}

	[z0ZzZzimj("LayoutDirection")]
	private void z0ttk(object p0, z0ZzZzomj p1)
	{
		z0rek(p0, p1, "LayoutDirection");
	}

	[z0ZzZzimj("IncreaseFirstLineIndent", ReturnValueType = typeof(bool))]
	private void z0ytk(object p0, z0ZzZzomj p1)
	{
		z0rek(p0, p1, "IncreaseFirstLineIndent");
	}

	private bool z0eek(z0ZzZzomj p0, bool p1)
	{
		z0ZzZzwcj z0ZzZzwcj2 = null;
		if (p0.Parameter is DocumentComment)
		{
			z0ZzZzwcj2 = new z0ZzZzwcj();
			z0ZzZzwcj2.Add((DocumentComment)p0.Parameter);
		}
		else if (p0.Parameter is z0ZzZzwcj)
		{
			z0ZzZzwcj2 = (z0ZzZzwcj)p0.Parameter;
			z0ZzZzwcj2 = z0ZzZzwcj2.z0eek(p0: false);
		}
		z0ZzZzecj z0ZzZzecj2 = (z0ZzZzecj)p0.EditorControl.z0tik();
		if (z0ZzZzwcj2 == null && z0ZzZzecj2.CurrentComment != null)
		{
			z0ZzZzwcj2 = new z0ZzZzwcj();
			z0ZzZzwcj2.Add(z0ZzZzecj2.CurrentComment);
		}
		if (z0ZzZzwcj2 == null || z0ZzZzwcj2.Count == 0)
		{
			return false;
		}
		if (p1)
		{
			for (int num = z0ZzZzwcj2.Count - 1; num >= 0; num--)
			{
				DocumentComment documentComment = z0ZzZzwcj2[num];
				if (documentComment.z0jrk() && !p0.EditorControl.z0uek() && p0.Host.z0oek() != null && !p0.Host.z0oek().z0eek(p0.Document, documentComment.z0urk(), -1))
				{
					if (p0.ShowUI)
					{
						z0ZzZzfpj.z0tek(p0.EditorControl, string.Format(z0ZzZziok.z0etk(), documentComment.z0eek()));
					}
					z0ZzZzwcj2.RemoveAt(num);
				}
				else if (!z0eek(documentComment, p0))
				{
					z0ZzZzwcj2.RemoveAt(num);
				}
			}
		}
		if (z0ZzZzwcj2.Count == 0)
		{
			return false;
		}
		z0ZzZzwcj comments = p0.Document.Comments;
		z0ZzZzwcj z0ZzZzwcj3 = p0.Document.Comments.z0eek(p0: false);
		foreach (DocumentComment item in z0ZzZzwcj2)
		{
			XTextElement p2 = item.z0vrk();
			XTextSubDocumentElement xTextSubDocumentElement = z0eek(p2);
			if (xTextSubDocumentElement != null && !xTextSubDocumentElement.Modified)
			{
				xTextSubDocumentElement.Modified = true;
			}
			z0ZzZzwcj3.Remove(item);
		}
		if (p0.Document.z0ytk())
		{
			p0.Document.z0imk().z0eek("Comments", p0.Document.Comments, z0ZzZzwcj3, p0.Document);
			if (z0ZzZzwcj3.Count == 0)
			{
				p0.Document.z0imk().z0eek((z0ZzZzbzj)3);
			}
			else
			{
				p0.Document.z0imk().z0eek((z0ZzZzbzj)6);
			}
			p0.Document.z0nuk();
		}
		p0.Document.Comments = z0ZzZzwcj3;
		z0ZzZzecj2.CurrentComment = null;
		z0ZzZzecj2.z0eb(comments, z0ZzZzwcj3);
		if (z0ZzZzwcj3.Count == 0)
		{
			p0.EditorControl.z0iyk();
		}
		else
		{
			z0ZzZzecj2.Refreshview();
			p0.EditorControl.z0ypk().z0hz();
		}
		p0.Document.Modified = true;
		p0.Document.OnDocumentContentChanged();
		return true;
	}

	[z0ZzZzimj("Underline", ShortcutKey = (Keys.U | Keys.Control), ReturnValueType = typeof(bool), FunctionID = 61)]
	private void z0utk(object p0, z0ZzZzomj p1)
	{
		z0eek(p0, p1, "Underline");
	}

	private void z0eek(z0ZzZzomj p0, z0ZzZzlmj p1)
	{
		if (p0.Mode == (z0ZzZzmmj)2)
		{
			p0.Enabled = false;
			if (p0.Document == null)
			{
				return;
			}
			DocumentContentStyle documentContentStyle = p0.Document.z0onk().z0uek();
			p0.Enabled = p0.DocumentControler != null && p0.DocumentControler.z0in().CanModifyParagraphs;
			if (p0.Enabled)
			{
				if (p1.z0lrk())
				{
					p0.Checked = documentContentStyle.ParagraphOutlineLevel == p1.z0mek() && documentContentStyle.ParagraphMultiLevel;
				}
				else
				{
					p0.Checked = documentContentStyle.ParagraphOutlineLevel == p1.z0mek();
				}
			}
		}
		else
		{
			if (p0.Mode != (z0ZzZzmmj)5)
			{
				return;
			}
			DocumentContentStyle documentContentStyle2 = new DocumentContentStyle();
			documentContentStyle2.z0eek(p0: true);
			documentContentStyle2.ParagraphOutlineLevel = p1.z0mek();
			documentContentStyle2.ParagraphMultiLevel = p1.z0lrk();
			documentContentStyle2.LeftIndent = p1.z0nek();
			documentContentStyle2.FirstLineIndent = p1.z0grk();
			documentContentStyle2.ParagraphListStyle = p1.z0xek();
			documentContentStyle2.LineSpacingStyle = p1.z0hrk();
			documentContentStyle2.LineSpacing = p1.z0srk();
			documentContentStyle2.FontSize = p1.z0cek();
			documentContentStyle2.VisibleInDirectory = p1.z0drk();
			if (!string.IsNullOrEmpty(p1.z0eek()))
			{
				documentContentStyle2.FontName = p1.z0eek();
			}
			documentContentStyle2.FontStyle = p1.z0krk();
			DocumentContentStyle documentContentStyle3 = new DocumentContentStyle();
			documentContentStyle3.FontSize = p1.z0cek();
			documentContentStyle3.FontStyle = p1.z0krk();
			if (!string.IsNullOrEmpty(p1.z0eek()))
			{
				documentContentStyle3.FontName = p1.z0eek();
			}
			z0ZzZzplh z0ZzZzplh2 = p0.Document.z0ryk();
			XTextElementList xTextElementList = new XTextElementList();
			if (p0.Document.z0cuk().z0qrk() == 0)
			{
				xTextElementList.Add(p0.Document.z0mtk());
			}
			else
			{
				using zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = p0.Document.z0cuk().z0grk().z0ltk();
				while (z0bpk.MoveNext())
				{
					XTextElement current = z0bpk.Current;
					XTextParagraphFlagElement xTextParagraphFlagElement = z0ZzZzplh2.z0pek(current);
					if (!xTextElementList.Contains(xTextParagraphFlagElement))
					{
						xTextElementList.Add(xTextParagraphFlagElement);
					}
				}
			}
			XTextElementList xTextElementList2 = new XTextElementList();
			using (zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = xTextElementList.z0ltk())
			{
				while (z0bpk.MoveNext())
				{
					XTextParagraphFlagElement xTextParagraphFlagElement2 = (XTextParagraphFlagElement)z0bpk.Current;
					XTextElement item = xTextParagraphFlagElement2.z0ie();
					int num = p0.Document.z0ryk().IndexOf(item);
					int num2 = p0.Document.z0ryk().IndexOf(xTextParagraphFlagElement2);
					for (int i = num; i <= num2; i++)
					{
						((zzz.z0ZzZzkuk<XTextElement>)xTextElementList2).z0pek(z0ZzZzplh2[i]);
					}
				}
			}
			p0.Document.z0ytk();
			bool flag = z0ZzZzhkh.z0rek(documentContentStyle3, documentContentStyle2, null, p0.Document, xTextElementList2, p5: true, p0.Name, p7: true);
			if (p0.Document.z0uik())
			{
				p0.Document.z0imk().z0eek((z0ZzZzbzj)7);
			}
			p0.Document.z0nuk();
			p0.Document.Modified = true;
			p0.Document.OnSelectionChanged();
			p0.Document.OnDocumentContentChanged();
			p0.RefreshLevel = (z0ZzZzwmj)2;
			p0.Result = flag;
			p0.EditorControl.z0nuk();
		}
	}

	[z0ZzZzimj("FixedSpacing", ReturnValueType = typeof(bool))]
	private void z0itk(object p0, z0ZzZzomj p1)
	{
		z0eek(p0, p1, "FixedSpacing");
	}

	[z0ZzZzimj("EditComment")]
	private void z0otk(object p0, z0ZzZzomj p1)
	{
		if (p1.Mode == (z0ZzZzmmj)2)
		{
			p1.Enabled = false;
			if (p1.EditorControl != null && p1.EditorControl != null && (!p1.EditorControl.z0ork() || p1.EditorControl.z0ttk()))
			{
				p1.Enabled = true;
			}
		}
		else
		{
			if (p1.Mode != (z0ZzZzmmj)5)
			{
				return;
			}
			p1.Result = false;
			if (p1.EditorControl.z0ork() && !p1.EditorControl.z0ttk())
			{
				return;
			}
			DocumentComment currentComment = p1.EditorControl.z0tik().CurrentComment;
			if (currentComment == null)
			{
				return;
			}
			if (currentComment.z0jrk() && !p1.EditorControl.z0uek() && p1.Host.z0oek() != null && !p1.Host.z0oek().z0rek(p1.Document, currentComment.z0urk(), -1))
			{
				if (p1.ShowUI)
				{
					z0ZzZzfpj.z0tek(p1.EditorControl, string.Format(z0ZzZziok.z0etk(), currentComment.z0eek()));
				}
			}
			else if (z0eek(currentComment, p1) && p1.ShowUI)
			{
				p1.EditorControl.z0qj("EditComment", currentComment);
			}
		}
	}

	[z0ZzZzimj("AlignJustify", ReturnValueType = typeof(bool))]
	private void z0ptk(object p0, z0ZzZzomj p1)
	{
		z0rek(p0, p1, "AlignJustify");
	}

	[z0ZzZzimj("Header6")]
	private void z0mtk(object p0, z0ZzZzomj p1)
	{
		z0ZzZzlmj p2 = z0ZzZzlmj.z0jrk();
		z0eek(p1, p2);
	}

	[z0ZzZzimj("TitleLevel", ReturnValueType = typeof(bool))]
	private void z0ntk(object p0, z0ZzZzomj p1)
	{
		z0eek(p0, p1, "TitleLevel");
	}

	[z0ZzZzimj("LetterSpacing", ReturnValueType = typeof(bool))]
	private void z0btk(object p0, z0ZzZzomj p1)
	{
		z0eek(p0, p1, "LetterSpacing");
	}

	[z0ZzZzimj("ParagraphFormat", ReturnValueType = typeof(bool))]
	private void z0vtk(object p0, z0ZzZzomj p1)
	{
		if (p1.Mode == (z0ZzZzmmj)2)
		{
			p1.Enabled = p1.DocumentControler != null && p1.DocumentControler.z0in().CanModifySelection;
		}
		else if (p1.Mode == (z0ZzZzmmj)5)
		{
			p1.Result = false;
			z0ZzZzdmj z0ZzZzdmj2 = p1.Parameter as z0ZzZzdmj;
			if (z0ZzZzdmj2 == null)
			{
				z0ZzZzdmj2 = new z0ZzZzdmj();
				z0ZzZzdmj2.z0eek(p1.Document.z0onk().z0uek());
			}
			DocumentContentStyle documentContentStyle = new DocumentContentStyle();
			documentContentStyle.z0eek(p0: true);
			z0ZzZzdmj2.z0rek(documentContentStyle);
			p1.Document.z0ytk();
			XTextElementList xTextElementList = p1.Document.z0cuk().z0rek(documentContentStyle);
			if (xTextElementList != null && xTextElementList.Count > 0)
			{
				p1.Result = true;
			}
			p1.Document.z0nuk();
			p1.Document.OnSelectionChanged();
			p1.Document.OnDocumentContentChanged();
			p1.EditorControl.z0ftk();
			p1.RefreshLevel = (z0ZzZzwmj)2;
		}
	}
}
