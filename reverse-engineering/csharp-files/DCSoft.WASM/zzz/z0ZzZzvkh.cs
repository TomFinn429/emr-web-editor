using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Xml;
using DCSoft.Drawing;
using DCSoft.Printing;
using DCSoft.Writer;
using DCSoft.Writer.Data;
using DCSoft.Writer.Dom;
using DCSystem_Drawing;
using DCSystem_Drawing.Printing;

namespace zzz;

internal class z0ZzZzvkh : z0ZzZzphh
{
	private XAttributeList z0tek;

	private static int z0yek = -1;

	private static int z0uek = -1;

	private List<XmlNode> z0iek;

	public override bool z0xd(TextReader p0, XTextDocument p1, z0ZzZzohh p2)
	{
		XmlDocument xmlDocument = new XmlDocument();
		xmlDocument.PreserveWhitespace = true;
		xmlDocument.Load(p0);
		if (xmlDocument.DocumentElement.Name == "Doc")
		{
			return z0eek(p1, xmlDocument.DocumentElement);
		}
		throw new NotSupportedException(xmlDocument.DocumentElement.Name);
	}

	public override string z0ls()
	{
		return ".xml";
	}

	private void z0eek(XTextDocument p0, XmlNode p1)
	{
	}

	private void z0eek(XTextContainerElement p0, XmlNode p1)
	{
		foreach (XmlNode childNode in p1.ChildNodes)
		{
			switch (childNode.Name.ToLower())
			{
			case "paragraph":
			{
				XTextParagraphElement xTextParagraphElement = new XTextParagraphElement();
				xTextParagraphElement.z0bt(p0.z0jr());
				z0eek(xTextParagraphElement, childNode);
				p0.z0be().z0tek(xTextParagraphElement.z0be());
				XTextParagraphFlagElement xTextParagraphFlagElement = new XTextParagraphFlagElement();
				if (childNode.Attributes.GetNamedItem("xCfg") != null)
				{
					xTextParagraphFlagElement.z0oek(z0eek(p0.z0jr(), childNode, xTextParagraphFlagElement));
					z0uek = ((XTextElement)xTextParagraphFlagElement).z0pek();
				}
				else
				{
					xTextParagraphFlagElement.z0oek(z0uek);
				}
				p0.z0be().Add(xTextParagraphFlagElement);
				if (xTextParagraphElement.z0zek() is XTextTableElement)
				{
					XTextTableElement xTextTableElement = xTextParagraphElement.z0zek() as XTextTableElement;
					int num = -1;
					if (xTextTableElement.z0zwk("tag") != null && int.TryParse(xTextTableElement.z0zwk("tag"), out num))
					{
						z0uek = num;
						xTextTableElement.Attributes.z0rek("tag");
					}
				}
				break;
			}
			case "font":
			{
				DocumentContentStyle documentContentStyle = (p0.z0jr().z0gnk().GetStyle(z0yek) as DocumentContentStyle).Clone() as DocumentContentStyle;
				bool flag = false;
				foreach (XmlAttribute attribute in childNode.Attributes)
				{
					switch (attribute.Name.ToLower())
					{
					case "cfg":
						if (attribute.Value == "1")
						{
							documentContentStyle.Bold = true;
							flag = true;
						}
						else if (attribute.Value == "404")
						{
							documentContentStyle.Underline = true;
							flag = true;
						}
						else if (attribute.Value == "0")
						{
							documentContentStyle = new DocumentContentStyle();
							flag = true;
						}
						break;
					case "color":
						documentContentStyle.Color = z0rek(attribute.Value);
						flag = true;
						break;
					case "size":
						documentContentStyle.FontSize = z0rek(attribute.Value, documentContentStyle.FontSize);
						flag = true;
						break;
					}
				}
				if (flag)
				{
					z0yek = p0.z0jr().z0gnk().GetStyleIndex(documentContentStyle);
				}
				break;
			}
			case "revise":
			{
				DocumentContentStyle documentContentStyle2 = (p0.z0jr().z0gnk().GetStyle(z0yek) as DocumentContentStyle).Clone() as DocumentContentStyle;
				XmlAttribute xmlAttribute5 = childNode.Attributes["add"];
				XmlAttribute xmlAttribute6 = childNode.Attributes["del"];
				bool num3 = xmlAttribute5 != null && xmlAttribute5.Value != null && xmlAttribute5.Value.Length > 0;
				bool flag2 = xmlAttribute6 != null && xmlAttribute6.Value != null && xmlAttribute6.Value.Length > 0;
				bool flag3 = !num3 && !flag2;
				if (num3)
				{
					z0ZzZzyhh z0ZzZzyhh2 = new z0ZzZzyhh();
					z0ZzZzyhh2.z0tek(xmlAttribute5.Value);
					p0.z0jr().z0syk().Add(z0ZzZzyhh2);
					int creatorIndex = p0.z0jr().z0syk().Count - 1;
					documentContentStyle2.CreatorIndex = creatorIndex;
					documentContentStyle2.DeleterIndex = -1;
				}
				else if (flag2)
				{
					z0ZzZzyhh z0ZzZzyhh3 = new z0ZzZzyhh();
					z0ZzZzyhh3.z0tek(xmlAttribute6.Value);
					p0.z0jr().z0syk().Add(z0ZzZzyhh3);
					int deleterIndex = p0.z0jr().z0syk().Count - 1;
					documentContentStyle2.DeleterIndex = deleterIndex;
					documentContentStyle2.CreatorIndex = -1;
				}
				else if (flag3)
				{
					documentContentStyle2.CreatorIndex = -1;
					documentContentStyle2.DeleterIndex = -1;
				}
				z0yek = p0.z0jr().z0gnk().GetStyleIndex(documentContentStyle2);
				break;
			}
			case "#text":
			{
				XTextStringElement xTextStringElement = new XTextStringElement();
				xTextStringElement.z0bt(p0.z0jr());
				XTextElementList xTextElementList = xTextStringElement.z0zek(childNode.Value.TrimStart().TrimEnd());
				using (zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = xTextElementList.z0ltk())
				{
					while (z0bpk.MoveNext())
					{
						z0bpk.Current.z0oek(z0yek);
					}
				}
				p0.z0be().z0tek(xTextElementList);
				break;
			}
			case "space":
			{
				new XTextElementList();
				XmlNode namedItem = childNode.Attributes.GetNamedItem("count");
				int num2 = 1;
				if (namedItem != null)
				{
					int.TryParse(namedItem.Value, out num2);
				}
				for (int i = 0; i < num2; i++)
				{
					XTextCharElement xTextCharElement = new XTextCharElement();
					xTextCharElement.CharValue = ' ';
					xTextCharElement.z0bt(p0.z0jr());
					xTextCharElement.z0oek(z0yek);
					p0.z0be().Add(xTextCharElement);
				}
				break;
			}
			case "element":
			{
				XTextInputFieldElement xTextInputFieldElement = new XTextInputFieldElement();
				xTextInputFieldElement.z0bt(p0.z0jr());
				string text3 = null;
				string text4 = null;
				foreach (XmlAttribute attribute2 in childNode.Attributes)
				{
					switch (attribute2.Name.ToLower())
					{
					case "id":
						xTextInputFieldElement.ID = attribute2.Value;
						break;
					case "name":
						xTextInputFieldElement.Name = attribute2.Value;
						break;
					case "hint":
						xTextInputFieldElement.ToolTip = attribute2.Value;
						xTextInputFieldElement.BackgroundText = attribute2.Value;
						break;
					case "sourceclass":
						if (xTextInputFieldElement.ValueBinding == null)
						{
							xTextInputFieldElement.ValueBinding = new z0ZzZzevj();
						}
						xTextInputFieldElement.ValueBinding.DataSource = attribute2.Value;
						break;
					case "sourceid":
						if (xTextInputFieldElement.ValueBinding == null)
						{
							xTextInputFieldElement.ValueBinding = new z0ZzZzevj();
						}
						xTextInputFieldElement.ValueBinding.BindingPath = attribute2.Value;
						break;
					case "inputmode":
						if (attribute2.Value == "2")
						{
							if (xTextInputFieldElement.FieldSettings == null)
							{
								xTextInputFieldElement.FieldSettings = new InputFieldSettings();
							}
							xTextInputFieldElement.FieldSettings.z0eek(InputFieldEditStyle.DropdownList);
						}
						break;
					case "linkstr":
						if (xTextInputFieldElement.FieldSettings == null)
						{
							xTextInputFieldElement.FieldSettings = new InputFieldSettings();
						}
						xTextInputFieldElement.FieldSettings.z0eek(attribute2.Value);
						break;
					case "items":
						text3 = attribute2.Value;
						break;
					case "optionid":
						text4 = attribute2.Value;
						break;
					}
				}
				xTextInputFieldElement.z0oek(z0yek);
				z0eek((XTextContainerElement)xTextInputFieldElement, childNode);
				if (text4 != null && text4.Length > 0 && z0iek != null && z0iek.Count > 0 && xTextInputFieldElement.FieldSettings != null && xTextInputFieldElement.FieldSettings.z0nek() == InputFieldEditStyle.DropdownList)
				{
					foreach (XmlNode item in z0iek)
					{
						if (item.Attributes["id"] == null || item.Attributes["id"].Value != text4)
						{
							continue;
						}
						XmlNodeList xmlNodeList = item.SelectNodes("Item");
						if (xmlNodeList == null || xmlNodeList.Count <= 0)
						{
							break;
						}
						if (xTextInputFieldElement.FieldSettings.z0zek() == null)
						{
							xTextInputFieldElement.FieldSettings.z0eek(new z0ZzZzsvj());
							xTextInputFieldElement.FieldSettings.z0zek().Items = new z0ZzZzdvj();
						}
						foreach (XmlNode item2 in xmlNodeList)
						{
							string strValue = ((item2["id"] != null) ? item2["id"].Value : null);
							string innerText = item2.InnerText;
							xTextInputFieldElement.FieldSettings.z0zek().Items.Add(new ListItem(innerText, strValue));
						}
						break;
					}
					if (text3 != null && text3.Length > 0 && text3.Split(';').Length > 1)
					{
						xTextInputFieldElement.FieldSettings.z0eek(p0: true);
						xTextInputFieldElement.InnerValue = text3.Replace(";", xTextInputFieldElement.FieldSettings.z0oek());
					}
				}
				p0.z0be().Add(xTextInputFieldElement);
				break;
			}
			case "hint":
				if (p0 is XTextInputFieldElement)
				{
					z0eek((XTextInputFieldElement)p0, childNode);
				}
				break;
			case "table":
			{
				XTextTableElement xTextTableElement2 = new XTextTableElement();
				xTextTableElement2.z0bt(p0.z0jr());
				z0eek(xTextTableElement2, childNode);
				xTextTableElement2.z0cek(p0: true);
				p0.z0be().Add(xTextTableElement2);
				break;
			}
			case "lf":
			{
				XTextLineBreakElement xTextLineBreakElement = new XTextLineBreakElement();
				xTextLineBreakElement.z0bt(p0.z0jr());
				p0.z0be().Add(xTextLineBreakElement);
				break;
			}
			case "checkbox":
			{
				XTextCheckBoxElement xTextCheckBoxElement = new XTextCheckBoxElement();
				foreach (XmlAttribute attribute3 in childNode.Attributes)
				{
					string text2 = attribute3.Name.ToLower();
					if (!(text2 == "name"))
					{
						if (text2 == "id")
						{
							xTextCheckBoxElement.ID = attribute3.Value;
						}
					}
					else
					{
						xTextCheckBoxElement.Name = attribute3.Value;
					}
				}
				xTextCheckBoxElement.z0bt(p0.z0jr());
				xTextCheckBoxElement.z0oek(z0yek);
				p0.z0be().Add(xTextCheckBoxElement);
				break;
			}
			case "image":
			{
				XTextImageElement xTextImageElement = new XTextImageElement();
				xTextImageElement.z0bt(p0.z0jr());
				foreach (XmlAttribute attribute4 in childNode.Attributes)
				{
					switch (attribute4.Name.ToLower())
					{
					case "id":
						xTextImageElement.ID = attribute4.Value;
						break;
					case "width":
						xTextImageElement.Width = z0eek(attribute4.Value, 100f);
						break;
					case "height":
						xTextImageElement.Height = z0eek(attribute4.Value, 100f);
						break;
					case "md5":
					{
						string text = z0eek(attribute4.Value);
						if (text != null && text.Length > 0)
						{
							xTextImageElement.z0rek(text, p1: false);
						}
						break;
					}
					}
				}
				p0.z0be().Add(xTextImageElement);
				break;
			}
			}
		}
	}

	private int z0eek(XTextDocument p0, XmlNode p1, XTextElement p2)
	{
		string text = null;
		string text2 = null;
		bool flag = false;
		DocumentContentStyle documentContentStyle = new DocumentContentStyle();
		foreach (XmlAttribute attribute in p1.Attributes)
		{
			switch (attribute.Name.ToLower())
			{
			case "specificindentvalue":
				documentContentStyle.FirstLineIndent = z0eek(attribute.Value, (int)documentContentStyle.LeftIndent);
				break;
			case "xcfg":
				text = attribute.Value;
				flag = true;
				break;
			case "ecfg":
				text2 = attribute.Value;
				flag = true;
				break;
			case "borderstyle":
				if (attribute.Value == "1")
				{
					bool flag2 = (documentContentStyle.BorderRight = false);
					bool flag4 = (documentContentStyle.BorderLeft = flag2);
					bool borderTop = (documentContentStyle.BorderBottom = flag4);
					documentContentStyle.BorderTop = borderTop;
					flag = true;
				}
				break;
			case "toppadding":
				documentContentStyle.PaddingTop = z0eek(attribute.Value, documentContentStyle.PaddingTop);
				flag = true;
				break;
			case "bottompadding":
				documentContentStyle.PaddingBottom = z0eek(attribute.Value, documentContentStyle.PaddingBottom);
				flag = true;
				break;
			case "leftpadding":
				documentContentStyle.PaddingLeft = z0eek(attribute.Value, documentContentStyle.PaddingLeft);
				flag = true;
				break;
			case "rightpadding":
				documentContentStyle.PaddingRight = z0eek(attribute.Value, documentContentStyle.PaddingRight);
				flag = true;
				break;
			}
		}
		if (!flag)
		{
			return -1;
		}
		switch (text)
		{
		case "2":
			documentContentStyle.Align = DocumentContentAlignment.Center;
			break;
		case "4":
			documentContentStyle.Align = DocumentContentAlignment.Right;
			break;
		case "6":
			documentContentStyle.Align = DocumentContentAlignment.Left;
			break;
		case "12":
			documentContentStyle.Align = DocumentContentAlignment.Center;
			documentContentStyle.LineSpacingStyle = LineSpacingStyle.Space1pt5;
			break;
		case "16":
			documentContentStyle.Align = DocumentContentAlignment.Left;
			documentContentStyle.LineSpacingStyle = LineSpacingStyle.Space1pt5;
			break;
		case "116":
			documentContentStyle.Align = DocumentContentAlignment.Left;
			break;
		}
		if (p2 is XTextTableCellElement)
		{
			if (text2 == "1")
			{
				documentContentStyle.VerticalAlign = VerticalAlignStyle.Middle;
			}
			else if (text2 == "2")
			{
				documentContentStyle.VerticalAlign = VerticalAlignStyle.Bottom;
			}
		}
		return p0.z0gnk().GetStyleIndex(documentContentStyle);
	}

	public z0ZzZzvkh()
	{
		z0eek(Encoding.UTF8);
	}

	private float z0eek(string p0, float p1)
	{
		float num = float.Parse(p0);
		if (!float.IsNaN(num))
		{
			num = z0ZzZzrpk.z0eek(num * 10f, GraphicsUnit.Millimeter, GraphicsUnit.Document);
			return (int)Math.Round(num, 0);
		}
		return p1;
	}

	private int z0eek(string p0, int p1)
	{
		float num = float.Parse(p0);
		if (!float.IsNaN(num))
		{
			num = z0ZzZzrpk.z0eek(num * 10f, GraphicsUnit.Millimeter, GraphicsUnit.Document);
			return (int)Math.Round(num / 3f, 0);
		}
		return p1;
	}

	private void z0rek(XTextDocument p0, XmlNode p1)
	{
		XmlNode xmlNode = p1.SelectSingleNode("Section");
		if (xmlNode == null)
		{
			throw new Exception("Sections节点下找不到Section节点");
		}
		foreach (XmlAttribute attribute in xmlNode.Attributes)
		{
			switch (attribute.Name.ToLower())
			{
			case "width":
				p0.PageSettings.z0eek(PaperKind.Custom);
				p0.PageSettings.z0oek(z0eek(attribute.Value, p0.PageSettings.z0ntk()));
				break;
			case "height":
				p0.PageSettings.z0eek(PaperKind.Custom);
				p0.PageSettings.z0rek(z0eek(attribute.Value, p0.PageSettings.z0jtk()));
				break;
			case "padding":
			{
				int num = z0eek(attribute.Value, p0.PageSettings.LeftMargin);
				XPageSettings pageSettings = p0.PageSettings;
				XPageSettings pageSettings2 = p0.PageSettings;
				XPageSettings pageSettings3 = p0.PageSettings;
				int num2 = (p0.PageSettings.BottomMargin = num);
				int num4 = (pageSettings3.TopMargin = num2);
				int leftMargin = (pageSettings2.RightMargin = num4);
				pageSettings.LeftMargin = leftMargin;
				break;
			}
			}
		}
		foreach (XmlNode childNode in xmlNode.ChildNodes)
		{
			switch (childNode.Name.ToLower())
			{
			case "header":
				foreach (XmlAttribute attribute2 in childNode.Attributes)
				{
					string text = attribute2.Name.ToLower();
					if (!(text == "topmargin"))
					{
						if (text == "bottomborderstyle")
						{
							if (attribute2.Value == "1")
							{
								p0.z0vtk().ViewOptions.ShowHeaderBottomLine = true;
							}
							else
							{
								p0.z0vtk().ViewOptions.ShowHeaderBottomLine = false;
							}
						}
					}
					else
					{
						p0.PageSettings.z0mek(z0eek(attribute2.Value, p0.PageSettings.z0pek()));
					}
				}
				p0.z0pyk().z0be().Clear();
				z0eek(p0.z0pyk(), childNode);
				break;
			case "footer":
				foreach (XmlAttribute attribute3 in childNode.Attributes)
				{
					if (attribute3.Name.ToLower() == "bottommargin")
					{
						p0.PageSettings.z0iek(z0eek(attribute3.Value, p0.PageSettings.z0utk()));
					}
				}
				p0.z0lik().z0be().Clear();
				z0eek(p0.z0lik(), childNode);
				break;
			case "body":
				p0.z0xyk().z0be().Clear();
				z0eek(p0.z0xyk(), childNode);
				break;
			}
		}
	}

	private float z0rek(string p0, float p1)
	{
		float num = float.Parse(p0);
		if (!float.IsNaN(num))
		{
			num = z0ZzZzrpk.z0eek(num * 10f, GraphicsUnit.Millimeter, GraphicsUnit.Pixel);
			return num * 0.75f;
		}
		return p1;
	}

	private void z0eek(XTextInputFieldElement p0, XmlNode p1)
	{
		string text = string.Empty;
		foreach (XmlNode childNode in p1.ChildNodes)
		{
			string text2 = childNode.Name.ToLower();
			if (!(text2 == "font"))
			{
				if (text2 == "#text")
				{
					text += childNode.Value.TrimEnd();
				}
				continue;
			}
			XmlNode namedItem = childNode.Attributes.GetNamedItem("color");
			if (namedItem != null)
			{
				p0.BackgroundTextColor = z0rek(namedItem.Value);
			}
		}
		p0.BackgroundText = text;
	}

	public override z0ZzZzmhh z0bd()
	{
		return (z0ZzZzmhh)5;
	}

	public override string z0js()
	{
		return "ThinkEditorXML";
	}

	private bool z0eek(XTextDocument p0, XmlElement p1)
	{
		z0ZzZzimk font = p0.z0vmk();
		Color color = p0.z0dik().Color;
		p0.z0rpk();
		p0.z0bek(MeasureMode.Default);
		p0.PageSettings.LeftMargin = 50;
		p0.PageSettings.TopMargin = 50;
		p0.PageSettings.RightMargin = 50;
		p0.PageSettings.BottomMargin = 50;
		p0.z0dik().Font = font;
		p0.z0dik().Color = color;
		p0.z0irk(p1.GetAttribute("version"));
		p0.z0bek((z0ZzZzzcj)1);
		foreach (XmlNode childNode in p1.ChildNodes)
		{
			if (!(childNode.Name == "Resources"))
			{
				continue;
			}
			XmlNode xmlNode2 = childNode.SelectSingleNode("ImageRes");
			if (xmlNode2 != null)
			{
				foreach (XmlNode item in xmlNode2.SelectNodes("ImageData"))
				{
					if (z0tek == null)
					{
						z0tek = new XAttributeList();
					}
					z0tek.z0eek(item.Attributes["md5"].Value, item.InnerText);
				}
			}
			XmlNode xmlNode4 = childNode.SelectSingleNode("OptionRes");
			if (xmlNode4 == null)
			{
				continue;
			}
			foreach (XmlNode item2 in xmlNode4.SelectNodes("Options/Option"))
			{
				if (z0iek == null)
				{
					z0iek = new List<XmlNode>();
				}
				z0iek.Add(item2);
			}
		}
		foreach (XmlNode childNode2 in p1.ChildNodes)
		{
			if (childNode2.Name == "Sections")
			{
				z0rek(p0, childNode2);
			}
		}
		p0.z0bek((z0ZzZzzcj)2);
		ElementLoadEventArgs p2 = new ElementLoadEventArgs(p0, "ThinkEditorXML");
		p0.z0rt(p2);
		return true;
	}

	private string z0eek(string p0)
	{
		if (z0tek == null || z0tek.Count == 0)
		{
			return null;
		}
		return z0tek.z0yek(p0);
	}

	public override string z0ks()
	{
		return "ThinkEditorXML文件|*.xml";
	}

	private void z0eek(XTextTableElement p0, XmlNode p1)
	{
		XmlNode? namedItem = p1.Attributes.GetNamedItem("rows");
		XmlNode namedItem2 = p1.Attributes.GetNamedItem("cols");
		if (namedItem == null || namedItem2 == null)
		{
			throw new Exception("没有找到表格行列属性");
		}
		int.Parse(namedItem.Value);
		int num = int.Parse(namedItem2.Value);
		XmlNodeList xmlNodeList = p1.SelectNodes("Row");
		foreach (XmlNode item in xmlNodeList)
		{
			XmlNodeList xmlNodeList2 = item.SelectNodes("Cell");
			if (xmlNodeList2.Count != num)
			{
				continue;
			}
			foreach (XmlNode item2 in xmlNodeList2)
			{
				XTextTableColumnElement xTextTableColumnElement = p0.z0vek();
				XmlNode namedItem3 = item2.Attributes.GetNamedItem("width");
				if (namedItem3 != null)
				{
					float num2 = float.Parse(namedItem3.Value);
					xTextTableColumnElement.Width = z0ZzZzrpk.z0eek(num2 * 10f, GraphicsUnit.Millimeter, GraphicsUnit.Document);
				}
				p0.z0srk().Add(xTextTableColumnElement);
			}
			break;
		}
		if (p0.z0srk() == null || p0.z0srk().Count == 0)
		{
			throw new Exception("表格合并过于复杂，先不处理");
		}
		foreach (XmlNode item3 in xmlNodeList)
		{
			XTextTableRowElement xTextTableRowElement = p0.z0nrk();
			xTextTableRowElement.z0iek(p0);
			foreach (XmlAttribute attribute in item3.Attributes)
			{
				if (attribute.Name.ToLower() == "height")
				{
					float num3 = float.Parse(attribute.Value);
					xTextTableRowElement.SpecifyHeight = z0ZzZzrpk.z0eek(num3 * 10f, GraphicsUnit.Millimeter, GraphicsUnit.Document);
				}
			}
			foreach (XmlNode item4 in item3.SelectNodes("Cell"))
			{
				XTextTableCellElement xTextTableCellElement = new XTextTableCellElement();
				xTextTableCellElement.z0iek(xTextTableRowElement);
				z0yek = -1;
				z0uek = -1;
				z0eek(xTextTableCellElement, item4);
				if (((XTextContainerElement)xTextTableCellElement).z0zek() is XTextParagraphFlagElement)
				{
					p0.z0dr("tag", ((XTextContainerElement)xTextTableCellElement).z0zek().z0pek().ToString());
				}
				foreach (XmlAttribute attribute2 in item4.Attributes)
				{
					string text = attribute2.Name.ToLower();
					if (!(text == "rowspan"))
					{
						if (text == "colspan")
						{
							xTextTableCellElement.ColSpan = int.Parse(attribute2.Value);
						}
					}
					else
					{
						xTextTableCellElement.RowSpan = int.Parse(attribute2.Value);
					}
				}
				xTextTableCellElement.z0oek(z0eek(p0.z0jr(), item4, xTextTableCellElement));
				xTextTableRowElement.z0rek().Add(xTextTableCellElement);
			}
			p0.z0stk().Add(xTextTableRowElement);
		}
	}

	public override int z0dq()
	{
		return 111;
	}

	private Color z0rek(string p0)
	{
		if (p0 == "0")
		{
			return Color.Black;
		}
		if (p0.Length == 6)
		{
			string text = p0.Substring(0, 2);
			string text2 = p0.Substring(2, 2);
			return Color.FromArgb(blue: int.Parse(p0.Substring(4, 2), NumberStyles.HexNumber), red: int.Parse(text, NumberStyles.HexNumber), green: int.Parse(text2, NumberStyles.HexNumber));
		}
		if (p0.Length == 4)
		{
			string text3 = p0.Substring(0, 2);
			return Color.FromArgb(blue: int.Parse(p0.Substring(2, 2), NumberStyles.HexNumber), red: int.Parse("00", NumberStyles.HexNumber), green: int.Parse(text3, NumberStyles.HexNumber));
		}
		return Color.Transparent;
	}

	public override bool z0zd(Stream p0, XTextDocument p1, z0ZzZzohh p2)
	{
		XmlDocument xmlDocument = new XmlDocument();
		xmlDocument.PreserveWhitespace = true;
		StreamReader streamReader = new StreamReader(p0);
		string text = streamReader.ReadToEnd();
		streamReader.Close();
		streamReader.Dispose();
		xmlDocument.LoadXml(text);
		p0.Close();
		if (xmlDocument.DocumentElement.Name == "Doc")
		{
			return z0eek(p1, xmlDocument.DocumentElement);
		}
		throw new NotSupportedException(xmlDocument.DocumentElement.Name);
	}
}
