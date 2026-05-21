using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using DCSoft.Common;
using DCSoft.Drawing;
using DCSoft.Writer;
using DCSoft.Writer.Dom;
using DCSystem_Drawing;
using DCSystem_Drawing.Drawing2D;

namespace zzz;

internal class z0ZzZzdtk : z0ZzZzggh
{
	private class z0kyk : z0ZzZzfgh
	{
		public override void z0sj(z0ZzZzggh p0, object p1)
		{
			p0.GetProvider(typeof(XTextElement)).z0sj(p0, p1);
			XTextObjectElement xTextObjectElement = (XTextObjectElement)p1;
			if (xTextObjectElement.Attributes != null && xTextObjectElement.Attributes.Count > 0)
			{
				p0.WritePropertyValueInstance("Attributes", xTextObjectElement.Attributes);
			}
			p0.WritePropertyValue("Enabled", xTextObjectElement.Enabled, defaultValue: true);
			p0.WritePropertyValue("Name", xTextObjectElement.Name);
			p0.WritePropertyValue("OffsetX", xTextObjectElement.OffsetX);
			p0.WritePropertyValue("OffsetY", xTextObjectElement.OffsetY);
			p0.WritePropertyValue("PrintVisibility", xTextObjectElement.PrintVisibility, ElementVisibility.Visible);
			p0.WritePropertyValue("StringTag", xTextObjectElement.StringTag);
			p0.WritePropertyValue("Tooltip", xTextObjectElement.ToolTip);
			p0.WritePropertyValue("ZOrderStyle", xTextObjectElement.ZOrderStyle, ElementZOrderStyle.Normal);
		}
	}

	private sealed class z0qyk : z0ZzZzfgh
	{
		public override void z0sj(z0ZzZzggh p0, object p1)
		{
			p0.GetProvider(typeof(XTextContainerElement)).z0sj(p0, p1);
			XTextTableRowElement xTextTableRowElement = (XTextTableRowElement)p1;
			p0.WritePropertyValue("CanSplitByPageLine", xTextTableRowElement.CanSplitByPageLine, defaultValue: true);
			p0.WritePropertyValue("HeaderStyle", xTextTableRowElement.HeaderStyle);
			p0.WritePropertyValue("NewPage", xTextTableRowElement.NewPage);
			p0.WritePropertyValue("PrintCellBackground", xTextTableRowElement.PrintCellBackground, defaultValue: true);
			p0.WritePropertyValue("PrintCellBorder", xTextTableRowElement.PrintCellBorder, defaultValue: true);
			p0.WritePropertyValue("SpecifyHeight", xTextTableRowElement.SpecifyHeight);
		}
	}

	private sealed class z0ayk : z0ZzZzfgh
	{
		public override void z0sj(z0ZzZzggh p0, object p1)
		{
			p0.GetProvider(typeof(XTextContainerElement)).z0sj(p0, p1);
			XTextTableElement xTextTableElement = (XTextTableElement)p1;
			p0.WritePropertyValue("Alignment", xTextTableElement.z0frk(), DCTableAlignment.Default);
			if (xTextTableElement.z0srk() != null && xTextTableElement.z0srk().Count > 0)
			{
				p0.WritePropertyValueInstance("Columns", xTextTableElement.z0srk());
			}
			p0.WritePropertyValue("CompressOwnerLineSpacing", xTextTableElement.CompressOwnerLineSpacing);
			p0.WritePropertyValue("HoldWholeLine", xTextTableElement.z0mek(), defaultValue: true);
			p0.WritePropertyValue("LeftIndent", xTextTableElement.z0qtk());
			p0.WritePropertyValue("PrintBothBorderWhenJumpPrint", xTextTableElement.PrintBothBorderWhenJumpPrint);
			p0.WritePropertyValue("ShowCellNoneBorder", xTextTableElement.z0dtk(), DCBooleanValue.Inherit);
		}
	}

	private sealed class z0syk : z0ZzZzfgh
	{
		public override void z0sj(z0ZzZzggh p0, object p1)
		{
			p0.GetProvider(typeof(XTextContentElement)).z0sj(p0, p1);
			XTextTableCellElement xTextTableCellElement = (XTextTableCellElement)p1;
			p0.WritePropertyValue("AutoFixFontSizeMode", xTextTableCellElement.AutoFixFontSizeMode, ContentAutoFixFontSizeMode.None);
			p0.WritePropertyValue("BorderPrintedWhenJumpPrint", xTextTableCellElement.BorderPrintedWhenJumpPrint);
			p0.WritePropertyValue("ColSpan", xTextTableCellElement.ColSpan, 1);
			p0.WritePropertyValue("MirrorViewForCrossPage", xTextTableCellElement.MirrorViewForCrossPage);
			p0.WritePropertyValue("RowSpan", xTextTableCellElement.RowSpan, 1);
			p0.WritePropertyValue("SlantSplitLineStyle", xTextTableCellElement.SlantSplitLineStyle, RectangleSlantSplitStyle.None);
			p0.WritePropertyValue("StressBorder", xTextTableCellElement.z0rek());
		}
	}

	private class z0fyk : z0ZzZzfgh
	{
		public override void z0sj(z0ZzZzggh p0, object p1)
		{
			p0.GetProvider(typeof(XTextContainerElement)).z0sj(p0, p1);
			XTextInputFieldElement xTextInputFieldElement = (XTextInputFieldElement)p1;
			p0.WritePropertyValue("AdornTextType", xTextInputFieldElement.z0rek(), InputFieldAdornTextType.Default);
			p0.WritePropertyValue("FormButtonStyle", xTextInputFieldElement.z0iek(), FormButtonStyle.Auto);
			p0.WritePropertyValue("ShowFormButton", xTextInputFieldElement.z0krk(), DCBooleanValue.Inherit);
			p0.WritePropertyValue("ShowInputFieldStateTag", xTextInputFieldElement.z0frk(), DCBooleanValue.Inherit);
			p0.WritePropertyValue("Alignment", xTextInputFieldElement.Alignment, StringAlignment.Near);
			p0.WritePropertyValue("BackgroundText", xTextInputFieldElement.BackgroundText);
			p0.WritePropertyValue("BorderTextPosition", ((XTextInputFieldElementBase)xTextInputFieldElement).z0oek(), (z0ZzZzscj)1);
			p0.WritePropertyValue("BorderVisible", xTextInputFieldElement.BorderVisible, DCVisibleState.Default);
			if (xTextInputFieldElement.DisplayFormat != null && !p0.IsEmptyInstance(xTextInputFieldElement.DisplayFormat))
			{
				p0.WritePropertyValueInstance("DisplayFormat", xTextInputFieldElement.DisplayFormat);
			}
			p0.WritePropertyValue("EnableHighlight", xTextInputFieldElement.EnableHighlight, EnableState.Enabled);
			p0.WritePropertyValue("EnableValueValidate", xTextInputFieldElement.EnableValueValidate, defaultValue: true);
			p0.WritePropertyValue("InnerValue", xTextInputFieldElement.InnerValue);
			p0.WritePropertyValue("LabelText", xTextInputFieldElement.LabelText);
			p0.WritePropertyValue("Name", xTextInputFieldElement.Name);
			p0.WritePropertyValue("PrintBackgroundText", ((XTextInputFieldElementBase)xTextInputFieldElement).z0cek(), DCBooleanValue.Inherit);
			p0.WritePropertyValue("SpecifyWidth", xTextInputFieldElement.SpecifyWidth);
			p0.WritePropertyValue("UnitText", xTextInputFieldElement.UnitText);
			p0.WritePropertyValue("ViewEncryptType", xTextInputFieldElement.ViewEncryptType, ContentViewEncryptType.None);
			p0.WritePropertyValue("BackgroundTextColorString", xTextInputFieldElement.BackgroundTextColorString);
			p0.WritePropertyValue("BackgroundTextItalic", ((XTextFieldElementBase)xTextInputFieldElement).z0drk(), DCBooleanValueHasDefault.Default);
			p0.WritePropertyValue("BorderElementColor", xTextInputFieldElement.BorderElementColor, Color.Empty);
			p0.WritePropertyValue("BorderElementColorValue", xTextInputFieldElement.BorderElementColorValue);
			p0.WritePropertyValue("EndBorderText", xTextInputFieldElement.EndBorderText);
			p0.WritePropertyValue("EndingLineBreak", xTextInputFieldElement.EndingLineBreak);
			p0.WritePropertyValue("StartBorderText", xTextInputFieldElement.StartBorderText);
			p0.WritePropertyValue("TextColorString", xTextInputFieldElement.TextColorString);
		}
	}

	internal sealed class z0jyk : z0ZzZzfgh
	{
		public override void z0sj(z0ZzZzggh p0, object p1)
		{
			XTextSignImageElement xTextSignImageElement = (XTextSignImageElement)p1;
			p0.WritePropertyValue("OffsetX", xTextSignImageElement.OffsetX);
			p0.WritePropertyValue("OffsetY", xTextSignImageElement.OffsetY);
			p0.WritePropertyValue("ZOrderStyle", xTextSignImageElement.ZOrderStyle.ToString());
			p0.WritePropertyValue("Width", xTextSignImageElement.Width);
			p0.WritePropertyValue("Height", xTextSignImageElement.Height);
		}
	}

	internal class z0dyk : z0ZzZzfgh
	{
		public override void z0sj(z0ZzZzggh p0, object p1)
		{
			XTextStringElement xTextStringElement = (XTextStringElement)p1;
			z0eek((z0ZzZzdtk)p0, ((XTextElement)xTextStringElement).z0pek(), xTextStringElement);
			p0.WritePropertyValue("Text", xTextStringElement.Text);
			p0.WritePropertyValue("WhiteSpaceLength", xTextStringElement.z0eek());
		}
	}

	internal class z0lyk : z0ZzZzfgh
	{
		public override void z0sj(z0ZzZzggh p0, object p1)
		{
			XTextElement xTextElement = (XTextElement)p1;
			z0eek((z0ZzZzdtk)p0, xTextElement.z0pek(), xTextElement);
			p0.WritePropertyValue("ID", xTextElement.ID);
		}
	}

	internal class z0gyk : z0ZzZzfgh
	{
		public override void z0sj(z0ZzZzggh p0, object p1)
		{
			XTextElementList xTextElementList = (XTextElementList)p1;
			if (xTextElementList == null || xTextElementList.Count <= 0)
			{
				return;
			}
			XTextElementList xTextElementList2 = xTextElementList.z0pek();
			for (int num = xTextElementList2.Count - 1; num >= 0; num--)
			{
				if (xTextElementList2[num] is XTextSignImageElement)
				{
					xTextElementList2.RemoveAt(num);
				}
			}
			using (zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = z0ZzZzafh.z0yek(xTextElementList2, p1: false).z0ltk())
			{
				while (z0bpk.MoveNext())
				{
					XTextElement current = z0bpk.Current;
					if (!(current is XTextSignImageElement))
					{
						p0.WritePropertyValueInstance("Item", current);
					}
				}
			}
			xTextElementList2.Clear();
		}
	}

	internal class z0hyk : z0ZzZzfgh
	{
		public override void z0sj(z0ZzZzggh p0, object p1)
		{
			p0.GetProvider(typeof(XTextElement)).z0sj(p0, p1);
			XTextContainerElement xTextContainerElement = (XTextContainerElement)p1;
			if (xTextContainerElement.Attributes != null)
			{
				p0.WritePropertyValueInstance("Attributes", xTextContainerElement.Attributes);
			}
			if (xTextContainerElement.z0crk())
			{
				p0.WritePropertyValueInstance("Elements", xTextContainerElement.z0be());
			}
			p0.WritePropertyValue("ToolTip", xTextContainerElement.ToolTip);
		}
	}

	internal sealed class z0ztk : z0ZzZzfgh
	{
		public override void z0sj(z0ZzZzggh p0, object p1)
		{
			p0.GetProvider(typeof(XTextContainerElement)).z0sj(p0, p1);
			XTextDocument xTextDocument = (XTextDocument)p1;
			p0.WritePropertyValue("EditorVersionString", xTextDocument.z0mmk());
			p0.WritePropertyValue("FileFormat", xTextDocument.z0ftk());
			p0.WritePropertyValue("FileName", xTextDocument.z0amk());
			if (xTextDocument.z0ipk() != null)
			{
				p0.WritePropertyValueInstance("Info", xTextDocument.z0ipk());
			}
			p0.WritePropertyValue("LocalExcludeKeywords", xTextDocument.z0tuk());
			p0.WritePropertyValue("MeasureMode", Convert.ToInt32(xTextDocument.z0fnk()).ToString());
			if (xTextDocument.PageSettings != null)
			{
				p0.WritePropertyValueInstance("PageSettings", xTextDocument.PageSettings);
			}
			if (xTextDocument.z0nmk() != null)
			{
				p0.WritePropertyValueInstance("RepeatedImages", xTextDocument.z0nmk());
			}
		}
	}

	private static readonly Encoding z0rek;

	private XTextDocument z0tek;

	private int z0yek;

	private Stream z0uek;

	internal Dictionary<Type, Dictionary<int, byte[]>> z0iek;

	private static z0ZzZzdgh z0oek;

	public override bool IsForSignContent => true;

	public override void WritePropertyValue(string name, DateTime v)
	{
		if (v != DateTime.MinValue || v != DateTime.MaxValue || v != z0ZzZzkfh.z0wrk)
		{
			z0eek(name);
			byte[] bytes = BitConverter.GetBytes(v.Ticks);
			z0uek.Write(bytes, 0, bytes.Length);
		}
	}

	public override void WritePropertyValue(string name, char v, char defaultValue = '\0')
	{
		if (v != defaultValue)
		{
			z0eek(name + ":" + v);
		}
	}

	public override void WritePropertyValues(object instance)
	{
		if (instance == null)
		{
			throw new ArgumentNullException("instance");
		}
		z0ZzZzfgh provider = GetProvider(instance.GetType());
		if (provider != null)
		{
			provider.z0eek = z0yek;
			provider.z0sj(this, instance);
		}
	}

	public override void WritePropertyValue(string name, int v, int defaultValue = 0)
	{
		if (v != defaultValue)
		{
			z0eek(name);
			byte[] bytes = BitConverter.GetBytes(v);
			z0uek.Write(bytes, 0, bytes.Length);
		}
	}

	public override void WritePropertyValue(string name, bool v, bool defaultValue = false)
	{
		if (v != defaultValue)
		{
			z0eek(name);
			z0uek.WriteByte(v ? ((byte)1) : ((byte)0));
		}
	}

	public override void WritePropertyValue(string name, z0ZzZzpmk v)
	{
		if (v != null && v.HasContent)
		{
			z0eek(name);
			byte[] imageData = v.ImageData;
			z0uek.Write(imageData, 0, imageData.Length);
		}
	}

	public override void WriteStartDocument()
	{
		base.WriteStartDocument();
		z0eek("<Document>");
	}

	private void z0eek(string p0)
	{
		if (p0 != null && p0.Length > 0)
		{
			byte[] bytes = z0rek.GetBytes(p0);
			z0uek.Write(bytes, 0, bytes.Length);
		}
	}

	public override void WritePropertyValue(string name, z0ZzZzimk v)
	{
		if (v != null)
		{
			z0eek(name);
			z0eek(v.Name);
			z0eek(v.Size.ToString());
			byte[] bytes = BitConverter.GetBytes(Convert.ToInt32(v.Style));
			z0uek.Write(bytes, 0, bytes.Length);
		}
	}

	public override void WriteStartInstance(string name, object instance)
	{
		if (instance == null)
		{
			return;
		}
		z0eek("<" + instance.GetType().Name + "-" + name + ">");
		if (instance is XTextElement)
		{
			string iD = ((XTextElement)instance).ID;
			if (iD != null && iD.Length > 0)
			{
				z0eek("<id=" + iD + "/>");
			}
		}
		base.WriteStartInstance(name, instance);
	}

	public override void WritePropertyValue(string name, Color c, Color defaultValue)
	{
		if (c != defaultValue)
		{
			z0eek(name);
			byte[] bytes = BitConverter.GetBytes(c.ToArgb());
			z0uek.Write(bytes, 0, bytes.Length);
		}
	}

	public override void WriteEndDocument()
	{
		base.WriteEndDocument();
		z0eek("</Document>");
	}

	public override void WritePropertyValue(string name, string v)
	{
		if (v != null && v.Length > 0)
		{
			z0eek(name);
			z0eek(v);
		}
	}

	public z0ZzZzdtk(XTextDocument p0, Stream p1, int p2)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("document");
		}
		if (p1 == null)
		{
			throw new ArgumentNullException("stream");
		}
		z0tek = p0;
		z0uek = p1;
		z0yek = p2;
	}

	public override void WritePropertyValue(string name, byte[] v)
	{
		if (v != null && v.Length != 0)
		{
			z0eek(name);
			z0uek.Write(v, 0, v.Length);
		}
	}

	public override void WritePropertyValue(string name, DateTime v, DateTime defaultValue)
	{
		if (v != defaultValue)
		{
			z0eek(name);
			byte[] bytes = BitConverter.GetBytes(v.Ticks);
			z0uek.Write(bytes, 0, bytes.Length);
		}
	}

	public override void WritePropertyValueInstance(string name, object instance)
	{
		if (instance != null)
		{
			z0ZzZzfgh provider = GetProvider(instance.GetType());
			if (provider != null)
			{
				z0eek(name);
				provider.z0eek = z0yek;
				provider.z0sj(this, instance);
			}
		}
	}

	private static void z0eek(z0ZzZzggh p0, DocumentContentStyle p1, object p2)
	{
		XTextElement xTextElement = (XTextElement)p2;
		bool num = xTextElement is XTextParagraphFlagElement;
		bool flag = xTextElement is XTextStringElement || xTextElement is XTextCharElement || xTextElement is XTextLabelElement || xTextElement is XTextPageInfoElement || xTextElement is XTextNewMedicalExpressionElement;
		bool isForSignContent = p0.IsForSignContent;
		if (num || !isForSignContent)
		{
			p0.WritePropertyValue("Align", p1.Align, DocumentContentAlignment.Left);
		}
		if (!num || !isForSignContent)
		{
			p0.WritePropertyValue("BackgroundColor", p1.BackgroundColor, Color.Transparent);
		}
		if (flag || !isForSignContent)
		{
			p0.WritePropertyValue("Bold", p1.Bold);
		}
		if (!num || !isForSignContent)
		{
			p0.WritePropertyValue("BorderBottom", p1.BorderBottom);
			p0.WritePropertyValue("BorderBottomColor", p1.BorderBottomColor, Color.Black);
			p0.WritePropertyValue("BorderLeft", p1.BorderLeft);
			p0.WritePropertyValue("BorderLeftColor", p1.BorderLeftColor, Color.Black);
			p0.WritePropertyValue("BorderTop", p1.BorderTop);
			p0.WritePropertyValue("BorderTopColor", p1.BorderTopColor, Color.Black);
			p0.WritePropertyValue("BorderRight", p1.BorderRight);
			p0.WritePropertyValue("BorderRightColor", p1.BorderRightColor, Color.Black);
			p0.WritePropertyValue("BorderWidth", p1.BorderWidth);
			p0.WritePropertyValue("BorderStyle", p1.BorderStyle, DashStyle.Solid);
		}
		if (num || !isForSignContent)
		{
			p0.WritePropertyValue("BulletedString", p1.BulletedString);
		}
		if (flag || !isForSignContent)
		{
			p0.WritePropertyValue("CharacterCircle", p1.CharacterCircle, CharacterCircleStyles.None);
		}
		if (!num || !isForSignContent)
		{
			p0.WritePropertyValue("Color", p1.Color, Color.Black);
		}
		if (flag || !isForSignContent)
		{
			p0.WritePropertyValue("EmphasisMark", p1.EmphasisMark);
		}
		if (num || !isForSignContent)
		{
			p0.WritePropertyValue("FirstLineIndent", p1.FirstLineIndent);
			p0.WritePropertyValue("FixedSpacing", p1.FixedSpacing);
		}
		if (!num || !isForSignContent)
		{
			p0.WritePropertyValue("FontName", p1.FontName);
			p0.WritePropertyValue("FontSize", p1.FontSize, 9f);
			p0.WritePropertyValue("FontStyle", p1.FontStyle, FontStyle.Regular);
		}
		if (num || !isForSignContent)
		{
			p0.WritePropertyValue("LeftIndent", p1.LeftIndent);
			p0.WritePropertyValue("LetterSpacing", p1.LetterSpacing);
			p0.WritePropertyValue("LineSpacingStyle", p1.LineSpacingStyle, LineSpacingStyle.SpaceSingle);
		}
		if (flag || !isForSignContent)
		{
			p0.WritePropertyValue("Multiline", p1.Multiline);
		}
		if (!num || !isForSignContent)
		{
			p0.WritePropertyValue("PaddingLeft", p1.PaddingLeft);
			p0.WritePropertyValue("PaddingTop", p1.PaddingTop);
			p0.WritePropertyValue("PaddingRight", p1.PaddingRight);
			p0.WritePropertyValue("PaddingBottom", p1.PaddingBottom);
		}
		if (num || !isForSignContent)
		{
			p0.WritePropertyValue("ParagraphListStyle", p1.ParagraphListStyle, ParagraphListStyle.None);
		}
		p0.WritePropertyValue("ParagraphMultiLevel", p1.ParagraphMultiLevel);
		p0.WritePropertyValue("ParagraphOutlineLevel", p1.ParagraphOutlineLevel);
		if (!num || !isForSignContent)
		{
			p0.WritePropertyValue("PrintBackColor", p1.PrintBackColor, Color.Empty);
			p0.WritePropertyValue("PrintColor", p1.PrintColor, Color.Transparent);
		}
		p0.WritePropertyValue("ProtectType", p1.ProtectType, ContentProtectType.None);
		if (num || !isForSignContent)
		{
			p0.WritePropertyValue("SpacingBeforeParagraph", p1.SpacingBeforeParagraph);
			p0.WritePropertyValue("SpacingAfterParagraph", p1.SpacingAfterParagraph);
		}
		if (flag || !isForSignContent)
		{
			p0.WritePropertyValue("Strikeout", p1.Strikeout);
			p0.WritePropertyValue("Subscript", p1.Subscript);
			p0.WritePropertyValue("Superscript", p1.Superscript);
		}
		if (!num || !isForSignContent)
		{
			p0.WritePropertyValue("TitleLevel", p1.TitleLevel);
		}
		if (flag || !isForSignContent)
		{
			p0.WritePropertyValue("Underline", p1.Underline);
			p0.WritePropertyValue("UnderlineColor", p1.UnderlineColor);
			p0.WritePropertyValue("UnderlineStyle", p1.UnderlineStyle, TextUnderlineStyle.Single);
		}
		if (p1.VerticalAlign != VerticalAlignStyle.Top)
		{
			p0.WritePropertyValue("VerticalAlign", p1.VerticalAlign, VerticalAlignStyle.Top);
		}
		if (p1.Visibility != RenderVisibility.All)
		{
			p0.WritePropertyValue("Visibility", p1.Visibility, RenderVisibility.All);
		}
		if (p1.VisibleInDirectory)
		{
			p0.WritePropertyValue("VisibleInDirectory", p1.VisibleInDirectory);
		}
	}

	public override z0ZzZzfgh GetProvider(Type t)
	{
		return z0oek.z0eek(t);
	}

	public override void WritePropertyValue(string name, double v, double defaultValue = 0.0)
	{
		if (v != defaultValue)
		{
			z0eek(name + ":" + v);
			byte[] bytes = BitConverter.GetBytes(v);
			z0uek.Write(bytes, 0, bytes.Length);
		}
	}

	public override bool IsEmptyInstance(object instance)
	{
		if (instance is ValueValidateStyle)
		{
			return ((ValueValidateStyle)instance).IsEmpty;
		}
		if (instance is z0ZzZzsok)
		{
			return ((z0ZzZzsok)instance).IsEmpty;
		}
		if (instance is z0ZzZzevj)
		{
			return ((z0ZzZzevj)instance).IsEmptyBinding;
		}
		if (instance is z0ZzZzsvj)
		{
			return ((z0ZzZzsvj)instance).IsEmpty;
		}
		return false;
	}

	static z0ZzZzdtk()
	{
		z0oek = new z0ZzZzdgh();
		z0rek = Encoding.UTF8;
		z0ZzZzchh.z0eek(z0oek);
		z0oek.z0eek(typeof(XTextStringElement), new z0dyk());
		z0oek.z0eek(typeof(XTextElementList), new z0gyk());
		z0oek.z0eek(typeof(XTextContainerElement), new z0hyk());
		z0oek.z0eek(typeof(XTextElement), new z0lyk());
		z0oek.z0eek(typeof(XTextDocument), new z0ztk());
		z0oek.z0eek(typeof(XTextSignImageElement), new z0jyk());
		z0oek.z0eek(typeof(XTextTableElement), new z0ayk());
		z0oek.z0eek(typeof(XTextTableRowElement), new z0qyk());
		z0oek.z0eek(typeof(XTextTableCellElement), new z0syk());
		z0oek.z0eek(typeof(XTextImageElement), new z0kyk());
		z0oek.z0eek(typeof(XTextInputFieldElement), new z0fyk());
	}

	public override void WriteEndInstance()
	{
		object currentInstance = GetCurrentInstance();
		if (currentInstance != null)
		{
			z0eek("</" + currentInstance.GetType().Name + ">");
		}
		base.WriteEndInstance();
	}

	public override void WritePropertyValue(string name, long v, long defaultValue = 0L)
	{
		if (v != defaultValue)
		{
			z0eek(name);
			byte[] bytes = BitConverter.GetBytes(v);
			z0uek.Write(bytes, 0, bytes.Length);
		}
	}

	public override void WritePropertyValue(string name, Enum v, Enum defaultValue)
	{
		if (v != defaultValue)
		{
			z0eek(name);
			byte[] bytes = BitConverter.GetBytes(Convert.ToInt32(v));
			z0uek.Write(bytes, 0, bytes.Length);
		}
	}

	public override void WritePropertyValue(string name, decimal v, decimal defaultValue)
	{
		if (v != defaultValue)
		{
			z0eek(name);
			z0eek(v.ToString());
		}
	}

	private static void z0eek(z0ZzZzdtk p0, int p1, XTextElement p2)
	{
		XTextDocument xTextDocument = p2.z0jr();
		if (p0.z0iek == null)
		{
			p0.z0iek = new Dictionary<Type, Dictionary<int, byte[]>>();
		}
		if (p1 < 0)
		{
			p1 = -1;
		}
		Dictionary<int, byte[]> dictionary = null;
		if (!p0.z0iek.ContainsKey(p2.GetType()))
		{
			dictionary = new Dictionary<int, byte[]>();
			p0.z0iek[p2.GetType()] = dictionary;
			MemoryStream memoryStream = new MemoryStream();
			z0ZzZzdtk obj = new z0ZzZzdtk(p2.z0jr(), memoryStream, 2);
			obj.WriteStartDocument();
			obj.WriteStartInstance("Element", p2);
			z0eek(obj, (DocumentContentStyle)p2.z0jr().z0gnk().Default, p2);
			memoryStream.Close();
			dictionary[-1] = memoryStream.ToArray();
			z0ZzZzzok styles = xTextDocument.z0gnk().Styles;
			for (int i = 0; i < styles.Count; i++)
			{
				DocumentContentStyle documentContentStyle = (DocumentContentStyle)styles[i];
				MemoryStream memoryStream2 = new MemoryStream();
				z0ZzZzdtk z0ZzZzdtk2 = new z0ZzZzdtk(p2.z0jr(), memoryStream2, 2);
				z0ZzZzdtk2.WriteStartDocument();
				z0ZzZzdtk2.WriteStartInstance("Element", p2);
				z0eek(z0ZzZzdtk2, documentContentStyle, p2);
				if (documentContentStyle.CreatorIndex >= 0)
				{
					z0ZzZzyhh z0ZzZzyhh2 = xTextDocument.z0syk().z0tek(documentContentStyle.CreatorIndex);
					if (z0ZzZzyhh2 != null)
					{
						z0ZzZzdtk2.WritePropertyValueInstance("Creator", z0ZzZzyhh2);
					}
				}
				if (documentContentStyle.DeleterIndex >= 0)
				{
					z0ZzZzyhh z0ZzZzyhh3 = xTextDocument.z0syk().z0tek(documentContentStyle.DeleterIndex);
					if (z0ZzZzyhh3 != null)
					{
						z0ZzZzdtk2.WritePropertyValueInstance("Deleter", z0ZzZzyhh3);
					}
				}
				if (documentContentStyle.CommentIndex >= 0)
				{
					DocumentComment documentComment = xTextDocument.Comments.z0eek(documentContentStyle.CommentIndex);
					if (documentComment != null)
					{
						z0ZzZzdtk2.WritePropertyValueInstance("Comment", documentComment);
					}
				}
				memoryStream2.Close();
				byte[] array = memoryStream2.ToArray();
				dictionary[i] = array;
			}
		}
		else
		{
			dictionary = p0.z0iek[p2.GetType()];
		}
		if (dictionary.ContainsKey(p1))
		{
			byte[] v = dictionary[p1];
			p0.WritePropertyValue("Style", v);
		}
	}

	public override void WritePropertyValue(string name, byte v, byte defaultValue = 0)
	{
		if (v != defaultValue)
		{
			z0eek(name);
			z0uek.WriteByte(v);
		}
	}

	public override void WritePropertyValue(string name, float v, float defaultValue = 0f)
	{
		if (v != defaultValue)
		{
			z0eek(name);
			byte[] bytes = BitConverter.GetBytes(v);
			z0uek.Write(bytes, 0, bytes.Length);
		}
	}
}
