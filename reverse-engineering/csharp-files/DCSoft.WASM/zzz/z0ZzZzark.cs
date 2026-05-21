using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using DCSoft.Common;
using DCSoft.Drawing;
using DCSoft.Writer;
using DCSoft.Writer.Data;
using DCSoft.Writer.Dom;
using DCSystem_Drawing;

namespace zzz;

internal class z0ZzZzark
{
	private class z0vvk : IComparer<ListItem>
	{
		public int Compare(ListItem x, ListItem y)
		{
			int num = 0;
			int.TryParse(x.Tag, out num);
			int num2 = 0;
			int.TryParse(y.Tag, out num2);
			return num - num2;
		}
	}

	private z0ZzZzfah z0yek;

	private z0ZzZzfah z0uek;

	private bool z0iek;

	private XTextDocument z0oek;

	private Dictionary<string, byte[]> z0pek = new Dictionary<string, byte[]>();

	private string z0mek;

	private z0ZzZzfah z0nek;

	private z0ZzZzfah z0bek;

	private z0ZzZzfah z0vek;

	private List<string> z0cek = new List<string>();

	private string z0xek;

	private bool z0zek = true;

	private string z0lrk;

	private Stack<XTextContainerElement> z0krk = new Stack<XTextContainerElement>();

	private Dictionary<string, string> z0jrk = new Dictionary<string, string>();

	public string Password
	{
		get
		{
			return z0mek;
		}
		set
		{
			z0mek = value;
		}
	}

	public bool ThrowODTEncryptionedException
	{
		get
		{
			return z0zek;
		}
		set
		{
			z0zek = value;
		}
	}

	private bool z0rek(string p0, bool p1)
	{
		if (string.IsNullOrEmpty(p0))
		{
			return p1;
		}
		if (string.Compare(p0, "true", true) == 0)
		{
			return true;
		}
		if (string.Compare(p0, "false", true) == 0)
		{
			return false;
		}
		return p1;
	}

	private bool z0rek()
	{
		z0iek = false;
		z0yek = null;
		z0uek = null;
		z0vek = null;
		z0nek = null;
		z0xek = null;
		if (z0pek.ContainsKey("META-INF/manifest.xml"))
		{
			MemoryStream p = new MemoryStream(z0pek["META-INF/manifest.xml"]);
			z0ZzZzfah z0ZzZzfah2 = new z0ZzZzfah();
			z0ZzZzfah2.z0eek(p);
			if (!z0rek(z0ZzZzfah2))
			{
				z0iek = true;
				if (ThrowODTEncryptionedException)
				{
					throw new z0ZzZzsrk("ODT文档被加密了");
				}
				return false;
			}
			List<z0ZzZzoah> list = z0ZzZzzik.z0rek(z0ZzZzfah2, "//manifest:encryption-data");
			if (list != null && list.Count > 0)
			{
				z0iek = true;
				if (ThrowODTEncryptionedException)
				{
					throw new z0ZzZzsrk("ODT文档被加密了");
				}
				return false;
			}
		}
		foreach (string key in z0pek.Keys)
		{
			byte[] array = z0pek[key];
			if (array == null || array.Length == 0)
			{
				continue;
			}
			switch (key)
			{
			case "content.xml":
			{
				MemoryStream p7 = new MemoryStream(array);
				z0yek = new z0ZzZzfah();
				z0yek.z0eek(p7);
				break;
			}
			case "manifest.rdf":
			{
				MemoryStream p8 = new MemoryStream(array);
				z0bek = new z0ZzZzfah();
				z0bek.z0eek(p8);
				break;
			}
			case "meta.xml":
			{
				MemoryStream p4 = new MemoryStream(array);
				z0uek = new z0ZzZzfah();
				z0uek.z0eek(p4);
				z0ZzZzsah z0ZzZzsah2 = (z0ZzZzsah)z0rek(z0uek.z0uek(), "office:meta", p2: false);
				if (z0ZzZzsah2 == null)
				{
					break;
				}
				foreach (z0ZzZzoah item in ((z0ZzZzoah)z0ZzZzsah2).z0tek())
				{
					switch (item.z0ph())
					{
					case "creation-date":
						z0oek.z0ipk().z0tek(Convert.ToDateTime(item.z0eg()));
						break;
					case "generator":
						z0oek.z0ipk().z0xek(item.z0eg());
						break;
					case "creator":
						z0oek.z0ipk().z0bek(item.z0eg());
						break;
					case "title":
						z0oek.z0ipk().z0vek(item.z0eg());
						break;
					case "description":
						z0oek.z0ipk().z0cek(item.z0eg());
						break;
					case "subject":
						z0oek.z0ipk().z0cek(item.z0eg());
						break;
					case "print-date":
						z0oek.z0ipk().z0eek(Convert.ToDateTime(item.z0eg()));
						break;
					case "user-defined":
					{
						z0ZzZzsah obj = (z0ZzZzsah)item;
						string p5 = obj.z0eek("meta:name");
						string p6 = obj.z0eg();
						z0oek.z0dr(p5, p6);
						break;
					}
					}
				}
				break;
			}
			case "mimetype":
				z0xek = Encoding.Default.GetString(array);
				break;
			case "settings.xml":
			{
				MemoryStream p3 = new MemoryStream(array);
				z0vek = new z0ZzZzfah();
				z0vek.z0eek(p3);
				break;
			}
			case "styles.xml":
			{
				MemoryStream p2 = new MemoryStream(array);
				z0nek = new z0ZzZzfah();
				z0nek.z0eek(p2);
				break;
			}
			}
		}
		return true;
	}

	private int z0rek(string p0, string p1)
	{
		string.IsNullOrEmpty(p0);
		return -1;
	}

	public bool Load(Stream inputStream, XTextDocument sourceDocument, z0ZzZzohh opt)
	{
		if (inputStream == null)
		{
			throw new ArgumentNullException("inputStream");
		}
		byte[] p = z0ZzZzmuk.z0eek(inputStream);
		z0oek = sourceDocument;
		try
		{
			z0zek = true;
			return z0rek(p);
		}
		catch (z0ZzZzsrk)
		{
			throw new Exception("ODT加密了");
		}
	}

	internal static float z0rek(string p0)
	{
		GraphicsUnit graphicsUnit = GraphicsUnit.Document;
		float num = 0f / 0f;
		if (p0.Contains("in"))
		{
			graphicsUnit = GraphicsUnit.Inch;
			num = float.Parse(p0.Replace("in", ""));
		}
		else
		{
			if (!p0.Contains("cm"))
			{
				return z0rek(p0);
			}
			graphicsUnit = GraphicsUnit.Millimeter;
			num = float.Parse(p0.Replace("cm", "")) * 10f;
		}
		return z0ZzZzrpk.z0eek(num, graphicsUnit, GraphicsUnit.Document);
	}

	private XTextInputFieldElement z0rek(z0ZzZzsah p0, string p1, XTextElement p2)
	{
		XTextInputFieldElement xTextInputFieldElement = new XTextInputFieldElement();
		bool flag = false;
		int num = -1;
		Dictionary<int, XAttribute> dictionary = new Dictionary<int, XAttribute>();
		Dictionary<string, string> dictionary2 = new Dictionary<string, string>();
		Dictionary<string, string> dictionary3 = new Dictionary<string, string>();
		foreach (z0ZzZzoah item in ((z0ZzZzoah)p0).z0tek())
		{
			if (!(item.z0th() == "meta:property"))
			{
				continue;
			}
			string text = ((z0ZzZzsah)item).z0eek("meta:property-value");
			if (string.IsNullOrEmpty(text))
			{
				continue;
			}
			string text2 = "  {===}  ";
			int num2 = text.IndexOf(text2);
			if (num2 <= 0)
			{
				continue;
			}
			string text3 = text.Substring(0, num2).Trim();
			string text4 = text.Substring(num2 + text2.Length);
			if (text3.StartsWith("ListEntryName"))
			{
				int num3 = int.Parse(text3[text3.Length - 1].ToString());
				if (!dictionary.ContainsKey(num3))
				{
					dictionary.Add(num3, new XAttribute());
				}
				dictionary[num3].z0eek(text4);
			}
			else if (text3.StartsWith("ListEntryValue"))
			{
				int num4 = int.Parse(text3[text3.Length - 1].ToString());
				if (!dictionary.ContainsKey(num4))
				{
					dictionary.Add(num4, new XAttribute());
				}
				dictionary[num4].z0rek(text4);
			}
			else if (text3 == "RadioButtonCheckedIndex")
			{
				num = int.Parse(text4.Split(';')[1]) - 1;
			}
			else if (text3 == "RectRadioButton")
			{
				flag = text4.ToLower() == "true";
			}
			else if (text3.StartsWith("ListEntryUserdefName"))
			{
				dictionary3[text3.Substring("ListEntryUserdefName".Length)] = text4;
			}
			else if (text3.StartsWith("ListEntryUserdefValue"))
			{
				dictionary2[text3.Substring("ListEntryUserdefValue".Length)] = text4;
			}
		}
		if (dictionary.Count > 0)
		{
			for (int i = 0; i < dictionary.Count; i++)
			{
				XAttribute xAttribute = dictionary[i];
				XTextRadioBoxElement xTextRadioBoxElement = new XTextRadioBoxElement();
				xTextRadioBoxElement.Name = p1;
				xTextRadioBoxElement.ID = p1 + "_" + (i + 1);
				xTextRadioBoxElement.Caption = xAttribute.Name;
				xTextRadioBoxElement.CheckedValue = xAttribute.Value;
				if (flag)
				{
					xTextRadioBoxElement.VisualStyle = CheckBoxVisualStyle.CheckBox;
				}
				if (i == num)
				{
					xTextRadioBoxElement.Checked = true;
				}
				xTextRadioBoxElement.z0oek(p2);
				xTextInputFieldElement.z0be().Add(xTextRadioBoxElement);
			}
		}
		if (dictionary3.Count > 0)
		{
			foreach (string key in dictionary3.Keys)
			{
				if (dictionary2.ContainsKey(key))
				{
					string text5 = dictionary3[key];
					string p3 = dictionary2[key];
					if (!string.IsNullOrEmpty(text5))
					{
						xTextInputFieldElement.z0dr(text5, p3);
					}
				}
			}
		}
		return xTextInputFieldElement;
	}

	private void z0rek(z0ZzZzsah p0)
	{
		if (p0 == null)
		{
			return;
		}
		foreach (z0ZzZzoah item in ((z0ZzZzoah)p0).z0tek())
		{
			if (!(item.z0ph() == "style"))
			{
				continue;
			}
			z0ZzZzsah z0ZzZzsah2 = (z0ZzZzsah)item;
			if (!z0ZzZzsah2.z0rek("style:name"))
			{
				continue;
			}
			string text = z0ZzZzsah2.z0eek("style:name");
			string text2 = z0ZzZzsah2.z0eek("style:master-page-name");
			if (!string.IsNullOrEmpty(text2))
			{
				z0jrk[text] = text2;
			}
			foreach (z0ZzZzoah item2 in ((z0ZzZzoah)z0ZzZzsah2).z0tek())
			{
				if (!(item2 is z0ZzZzsah))
				{
					continue;
				}
				Dictionary<string, string> dictionary = new Dictionary<string, string>();
				foreach (z0ZzZzbsh item3 in item2.z0sg())
				{
					dictionary[item3.z0ph()] = item3.z0rh();
				}
				DocumentContentStyle documentContentStyle = z0eek(dictionary);
				documentContentStyle.Index = z0oek.z0gnk().Styles.Count;
				z0oek.z0gnk().Styles.Add(documentContentStyle);
			}
		}
	}

	private Color z0rek(string p0, Color p1)
	{
		if (string.IsNullOrEmpty(p0))
		{
			return p1;
		}
		return z0ZzZzlok.z0eek(p0, p1);
	}

	private DocumentContentStyle z0tek(string p0, string p1)
	{
		return null;
	}

	private bool z0rek(z0ZzZzfah p0)
	{
		bool result = true;
		foreach (z0ZzZzsah item in z0ZzZzzik.z0rek(p0.z0uek(), "manifest:file-entry"))
		{
			if ((z0ZzZzsah)z0rek(item, "manifest:encryption-data", p2: false) != null)
			{
				string text = item.z0eek("manifest:full-path");
				if (z0pek.ContainsKey(text))
				{
					return false;
				}
			}
		}
		return result;
	}

	private DocumentContentStyle z0eek(Dictionary<string, string> p0)
	{
		DocumentContentStyle documentContentStyle = new DocumentContentStyle();
		foreach (string key in p0.Keys)
		{
			string text = p0[key];
			switch (key)
			{
			case "margin-left":
				documentContentStyle.MarginLeft = z0rek(text);
				break;
			case "margin-top":
				documentContentStyle.MarginTop = z0rek(text);
				break;
			case "margin-right":
				documentContentStyle.MarginRight = z0rek(text);
				break;
			case "margin-bottom":
				documentContentStyle.MarginBottom = z0rek(text);
				break;
			case "text-align":
				if (string.Compare(text, "left", true) == 0)
				{
					documentContentStyle.Align = DocumentContentAlignment.Left;
				}
				else if (string.Compare(text, "center", true) == 0)
				{
					documentContentStyle.Align = DocumentContentAlignment.Center;
				}
				else if (string.Compare(text, "right", true) == 0)
				{
					documentContentStyle.Align = DocumentContentAlignment.Right;
				}
				else if (string.Compare(text, "justify", true) == 0)
				{
					documentContentStyle.Align = DocumentContentAlignment.Justify;
				}
				break;
			case "text-indent":
				documentContentStyle.FirstLineIndent = z0rek(text);
				break;
			case "number-lines":
				if (string.Compare(text, "true", true) == 0)
				{
					documentContentStyle.ParagraphListStyle = ParagraphListStyle.ListNumberStyle;
				}
				else
				{
					documentContentStyle.ParagraphListStyle = ParagraphListStyle.None;
				}
				break;
			case "line-height":
				if (string.Compare(text, "normal", true) != 0)
				{
					if (text.Contains("%"))
					{
						float lineSpacing = float.Parse(text.Replace("%", "")) / 100f;
						documentContentStyle.LineSpacingStyle = LineSpacingStyle.SpaceMultiple;
						documentContentStyle.LineSpacing = lineSpacing;
					}
					else
					{
						documentContentStyle.LineSpacingStyle = LineSpacingStyle.SpaceSpecify;
						documentContentStyle.LineSpacing = z0rek(text);
					}
				}
				break;
			case "vertical-align":
				if (string.Compare(text, "top", true) == 0)
				{
					documentContentStyle.VerticalAlign = VerticalAlignStyle.Top;
				}
				else if (string.Compare(text, "middle", true) == 0)
				{
					documentContentStyle.VerticalAlign = VerticalAlignStyle.Middle;
				}
				else if (string.Compare(text, "bottom", true) == 0)
				{
					documentContentStyle.VerticalAlign = VerticalAlignStyle.Bottom;
				}
				break;
			case "border-color":
				documentContentStyle.BorderColor = z0rek(text, Color.Black);
				break;
			case "padding":
				documentContentStyle.PaddingLeft = z0rek(text);
				documentContentStyle.PaddingTop = documentContentStyle.PaddingLeft;
				documentContentStyle.PaddingRight = documentContentStyle.PaddingLeft;
				documentContentStyle.PaddingBottom = documentContentStyle.PaddingLeft;
				break;
			case "padding-left":
				documentContentStyle.PaddingLeft = z0rek(text);
				break;
			case "padding-top":
				documentContentStyle.PaddingTop = z0rek(text);
				break;
			case "padding-right":
				documentContentStyle.PaddingRight = z0rek(text);
				break;
			case "padding-bottom":
				documentContentStyle.PaddingBottom = z0rek(text);
				break;
			case "font-family":
			case "font-name":
				documentContentStyle.FontName = text;
				if (text.StartsWith("楷体"))
				{
					documentContentStyle.FontName = "楷体";
				}
				break;
			case "font-size":
				documentContentStyle.FontSize = (float)z0ZzZzrpk.z0eek(text, GraphicsUnit.Point, 12.0);
				break;
			case "font-weight":
				if (string.Compare(text, "bold", true) == 0)
				{
					documentContentStyle.Bold = true;
				}
				break;
			case "color":
				documentContentStyle.Color = z0rek(text, Color.Black);
				break;
			case "text-underline-style":
				if (text == "solid")
				{
					documentContentStyle.Underline = true;
				}
				break;
			case "letter-spacing":
				if (text == "normal")
				{
					documentContentStyle.LetterSpacing = 0f;
				}
				else
				{
					documentContentStyle.LetterSpacing = z0rek(text);
				}
				break;
			case "font-style":
				if (string.Compare(text, "normal", true) == 0)
				{
					documentContentStyle.Italic = false;
				}
				else if (string.Compare(text, "italic", true) == 0)
				{
					documentContentStyle.Italic = true;
				}
				else if (string.Compare(text, "oblique", true) == 0)
				{
					documentContentStyle.Italic = true;
				}
				break;
			case "text-underline-type":
				if (string.Compare(text, "none", true) == 0)
				{
					documentContentStyle.Underline = false;
				}
				else if (string.Compare(text, "single", true) == 0)
				{
					documentContentStyle.Underline = true;
				}
				else if (string.Compare(text, "double", true) == 0)
				{
					documentContentStyle.Underline = true;
				}
				break;
			case "background-color":
				documentContentStyle.BackgroundColor = z0rek(text, Color.Transparent);
				break;
			default:
				if (documentContentStyle.Tags == null)
				{
					documentContentStyle.Tags = new Hashtable();
				}
				documentContentStyle.Tags[key] = text;
				break;
			case "border-left":
			case "border-top":
			case "border-right":
			case "border-bottom":
			case "justify-single-word":
			case "auto-text-indent":
			case "language-asian":
			case "border":
			case "font-size-asian":
				break;
			}
		}
		return documentContentStyle;
	}

	private void z0rek(XTextElement p0, z0ZzZzsah p1)
	{
		if (p0.Attributes == null)
		{
			p0.Attributes = new XAttributeList();
		}
		if (p0.z0jr() == null)
		{
			p0.z0bt(z0oek);
		}
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		Dictionary<string, string> dictionary2 = new Dictionary<string, string>();
		Dictionary<string, string> dictionary3 = new Dictionary<string, string>();
		Dictionary<string, string> dictionary4 = new Dictionary<string, string>();
		bool flag = false;
		string text = null;
		string text2 = null;
		string text3 = null;
		string text4 = null;
		foreach (z0ZzZzoah item in ((z0ZzZzoah)p1).z0tek())
		{
			if (!(item.z0th() == "meta:property"))
			{
				continue;
			}
			string text5 = ((z0ZzZzsah)item).z0eek("meta:property-value");
			if (string.IsNullOrEmpty(text5))
			{
				continue;
			}
			string text6 = "  {===}  ";
			int num = text5.IndexOf(text6);
			if (num <= 0)
			{
				continue;
			}
			string text7 = text5.Substring(0, num).Trim();
			string text8 = text5.Substring(num + text6.Length);
			if (text7.StartsWith("ListEntryName"))
			{
				dictionary3[text7.Substring("ListEntryName".Length)] = text8;
				continue;
			}
			if (text7.StartsWith("ListEntryValue"))
			{
				dictionary4[text7.Substring("ListEntryValue".Length)] = text8;
				continue;
			}
			if (text7.StartsWith("ListEntryUserdefName"))
			{
				dictionary2[text7.Substring("ListEntryUserdefName".Length)] = text8;
				continue;
			}
			if (text7.StartsWith("ListEntryUserdefValue"))
			{
				dictionary[text7.Substring("ListEntryUserdefValue".Length)] = text8;
				continue;
			}
			switch (text7)
			{
			case "IsMustFill":
				if (z0rek(text8, p1: false) && p0 is XTextInputFieldElement xTextInputFieldElement)
				{
					if (xTextInputFieldElement.ValidateStyle == null)
					{
						xTextInputFieldElement.ValidateStyle = new ValueValidateStyle();
					}
					xTextInputFieldElement.ValidateStyle.Required = true;
				}
				break;
			case "UseStubString":
				flag = z0rek(text8, p1: false);
				break;
			case "StubString":
				text = text8;
				break;
			case "BorderEndString":
				text4 = text8;
				break;
			case "BorderStartString":
				text3 = text8;
				break;
			case "HelpTip":
				text2 = text8;
				break;
			case "ControlHidden":
				p0.Visible = text8.ToLower() != "true";
				break;
			}
			p0.Attributes.z0eek(text7, text8);
			z0ZzZzdrk.z0eek(p0, text7);
		}
		if (dictionary3.Count > 0 && p0 is XTextInputFieldElement)
		{
			XTextInputFieldElement xTextInputFieldElement2 = (XTextInputFieldElement)p0;
			if (xTextInputFieldElement2.FieldSettings != null && xTextInputFieldElement2.FieldSettings.z0nek() == InputFieldEditStyle.DropdownList)
			{
				if (xTextInputFieldElement2.FieldSettings.z0zek() == null)
				{
					xTextInputFieldElement2.FieldSettings.z0eek(new z0ZzZzsvj());
				}
				if (xTextInputFieldElement2.FieldSettings.z0zek().Items == null)
				{
					xTextInputFieldElement2.FieldSettings.z0zek().Items = new z0ZzZzdvj();
				}
				foreach (string key in dictionary3.Keys)
				{
					string value = null;
					if (dictionary4.ContainsKey(key))
					{
						value = dictionary4[key];
					}
					ListItem listItem = new ListItem();
					listItem.Text = dictionary3[key];
					listItem.Value = value;
					listItem.Tag = key;
					xTextInputFieldElement2.FieldSettings.z0zek().Items.Add(listItem);
				}
				xTextInputFieldElement2.FieldSettings.z0zek().Items.z0oek(new z0vvk());
			}
		}
		if (dictionary2.Count > 0)
		{
			foreach (string key2 in dictionary2.Keys)
			{
				if (dictionary.ContainsKey(key2))
				{
					string text9 = dictionary2[key2];
					string p2 = dictionary[key2];
					if (!string.IsNullOrEmpty(text9))
					{
						p0.z0dr(text9, p2);
					}
				}
			}
		}
		if (!(p0 is XTextInputFieldElement))
		{
			return;
		}
		XTextInputFieldElement xTextInputFieldElement3 = (XTextInputFieldElement)p0;
		if (!string.IsNullOrEmpty(text))
		{
			if (flag)
			{
				xTextInputFieldElement3.BackgroundText = text;
			}
			else
			{
				xTextInputFieldElement3.Text = text;
			}
		}
		if (!string.IsNullOrEmpty(text2))
		{
			xTextInputFieldElement3.ToolTip = text2;
		}
		if (!string.IsNullOrEmpty(text3))
		{
			xTextInputFieldElement3.StartBorderText = text3;
		}
		if (!string.IsNullOrEmpty(text4))
		{
			xTextInputFieldElement3.EndBorderText = text4;
		}
	}

	private void z0rek(z0ZzZzsah p0, string p1)
	{
		foreach (z0ZzZzoah item in ((z0ZzZzoah)p0).z0tek())
		{
			XTextElement xTextElement = z0krk.Peek();
			if (item is z0ZzZzkqh)
			{
				string text = item.z0rh();
				if (!string.IsNullOrEmpty(text))
				{
					XTextStringElement xTextStringElement = new XTextStringElement();
					xTextStringElement.z0oek(xTextElement);
					xTextStringElement.Text = text;
					xTextStringElement.z0oek(z0rek(p1, "text-properties"));
					xTextElement.z0be().Add(xTextStringElement);
				}
			}
			else
			{
				if (!(item is z0ZzZzsah) || item.z0ph() == "sequence-decls")
				{
					continue;
				}
				z0ZzZzsah z0ZzZzsah2 = (z0ZzZzsah)item;
				string text2 = null;
				foreach (z0ZzZzbsh item2 in z0ZzZzsah2.z0sg())
				{
					if (item2.z0ph() == "style-name")
					{
						text2 = item2.z0rh();
						break;
					}
				}
				if (text2 != null && string.IsNullOrEmpty(z0lrk) && z0jrk.ContainsKey(text2))
				{
					z0lrk = z0jrk[text2];
				}
				switch (z0ZzZzsah2.z0ph())
				{
				case "section":
				{
					XTextSectionElement xTextSectionElement = new XTextSectionElement();
					xTextSectionElement.z0oek(xTextElement);
					xTextElement.z0be().Add(xTextSectionElement);
					xTextSectionElement.ID = z0ZzZzsah2.z0eek("text:name");
					xTextSectionElement.z0oek(z0rek(text2, "section-properties"));
					z0krk.Push(xTextSectionElement);
					z0rek(z0ZzZzsah2, text2);
					z0krk.Pop();
					break;
				}
				case "table":
				{
					XTextTableElement xTextTableElement = new XTextTableElement();
					xTextTableElement.z0oek(xTextElement);
					xTextElement.z0be().Add(xTextTableElement);
					xTextTableElement.ID = z0ZzZzsah2.z0eek("table:name");
					DocumentContentStyle documentContentStyle = z0tek(text2, "table-properties");
					if (documentContentStyle != null)
					{
						xTextTableElement.z0oek(documentContentStyle.Index);
						if (documentContentStyle.Tags != null && documentContentStyle.Tags.ContainsKey("protected") && z0rek(documentContentStyle.Tags["protected"].ToString(), p1: false))
						{
							xTextTableElement.ContentReadonly = ContentReadonlyState.True;
						}
					}
					foreach (z0ZzZzsah item3 in z0ZzZzzik.z0rek(z0ZzZzsah2, "table:table-column | table:table-columns/table:table-column"))
					{
						int num = 1;
						if (!int.TryParse(item3.z0eek("table:number-columns-repeated"), out num))
						{
							num = 1;
						}
						text2 = item3.z0eek("table:style-name");
						DocumentContentStyle documentContentStyle2 = z0tek(text2, "table-column-properties");
						for (int i = 0; i < num; i++)
						{
							XTextTableColumnElement xTextTableColumnElement = new XTextTableColumnElement();
							xTextTableColumnElement.z0oek(xTextElement);
							if (documentContentStyle2 != null)
							{
								xTextTableColumnElement.z0oek(documentContentStyle2.Index);
								if (documentContentStyle2.Tags != null && documentContentStyle2.Tags.ContainsKey("column-width"))
								{
									xTextTableColumnElement.Width = z0rek((string)documentContentStyle2.Tags["column-width"]);
								}
							}
							xTextTableColumnElement.z0oek(xTextTableElement);
							xTextTableElement.z0srk().Add(xTextTableColumnElement);
						}
					}
					foreach (z0ZzZzsah item4 in z0ZzZzzik.z0rek(z0ZzZzsah2, "table:table-row | table:table-header-rows/table:table-row"))
					{
						XTextTableRowElement xTextTableRowElement = new XTextTableRowElement();
						xTextTableRowElement.z0oek(xTextTableElement);
						xTextTableRowElement.HeaderStyle = item4.z0ih().z0ph() == "table-header-rows";
						text2 = item4.z0eek("table:style-name");
						DocumentContentStyle documentContentStyle3 = z0tek(text2, "table-row-properties");
						if (documentContentStyle3 != null)
						{
							xTextTableRowElement.z0oek(documentContentStyle3.Index);
						}
						foreach (z0ZzZzoah item5 in ((z0ZzZzoah)item4).z0tek())
						{
							if (item5.z0ph() == "table-cell")
							{
								z0ZzZzsah z0ZzZzsah4 = (z0ZzZzsah)item5;
								XTextTableCellElement xTextTableCellElement = new XTextTableCellElement();
								xTextTableCellElement.z0oek(xTextTableRowElement);
								text2 = z0ZzZzsah4.z0eek("table:style-name");
								DocumentContentStyle documentContentStyle4 = z0tek(text2, "table-cell-properties");
								if (documentContentStyle4 != null)
								{
									xTextTableCellElement.z0oek(documentContentStyle4.Index);
									if (documentContentStyle4.Tags != null && documentContentStyle4.Tags.ContainsKey("protect") && z0rek(documentContentStyle4.Tags["protect"].ToString(), p1: false))
									{
										xTextTableCellElement.ContentReadonly = ContentReadonlyState.True;
									}
									if (z0ZzZzsah4.z0rek("table:number-columns-spanned"))
									{
										xTextTableCellElement.z0tek(Convert.ToInt32(z0ZzZzsah4.z0eek("table:number-columns-spanned")));
									}
									if (z0ZzZzsah4.z0rek("table:number-rows-spanned"))
									{
										xTextTableCellElement.z0yek(Convert.ToInt32(z0ZzZzsah4.z0eek("table:number-rows-spanned")));
									}
								}
								z0krk.Push(xTextTableCellElement);
								z0rek(z0ZzZzsah4, text2);
								z0krk.Pop();
								xTextTableRowElement.z0rek().Add(xTextTableCellElement);
							}
							else if (item5.z0ph() == "covered-table-cell")
							{
								XTextTableCellElement xTextTableCellElement2 = new XTextTableCellElement();
								xTextTableCellElement2.z0oek(xTextTableRowElement);
								xTextTableRowElement.z0rek().Add(xTextTableCellElement2);
							}
						}
						xTextTableElement.z0stk().Add(xTextTableRowElement);
					}
					break;
				}
				case "p":
				{
					z0rek((z0ZzZzsah)item, text2);
					XTextParagraphFlagElement xTextParagraphFlagElement = new XTextParagraphFlagElement();
					xTextParagraphFlagElement.z0oek(xTextElement);
					xTextParagraphFlagElement.z0oek(z0rek(text2, "paragraph-properties"));
					xTextElement.z0be().Add(xTextParagraphFlagElement);
					break;
				}
				case "newcontrol-base":
					if (z0ZzZzsah2.z0eek("text:newcontrol-start") == "true")
					{
						z0ZzZzfrk z0ZzZzfrk2 = (z0ZzZzfrk)Convert.ToInt32(z0ZzZzsah2.z0eek("text:newcontrol-type"));
						string text6 = z0ZzZzsah2.z0eek("text:newcontrol-name");
						if (text6.EndsWith("_Start"))
						{
							text6 = text6.Substring(0, text6.Length - "_Start".Length);
						}
						switch (z0ZzZzfrk2)
						{
						case (z0ZzZzfrk)9:
							z0ZzZzfrk2 = (z0ZzZzfrk)9;
							break;
						case (z0ZzZzfrk)4:
							z0ZzZzfrk2 = (z0ZzZzfrk)4;
							break;
						case (z0ZzZzfrk)1:
							z0ZzZzfrk2 = (z0ZzZzfrk)2;
							break;
						}
						XTextElement xTextElement2 = null;
						switch (z0ZzZzfrk2)
						{
						case (z0ZzZzfrk)0:
						{
							XTextInputFieldElement xTextInputFieldElement2 = new XTextInputFieldElement();
							xTextInputFieldElement2.z0oek(xTextElement);
							xTextInputFieldElement2.z0dr("NsoElementTypeName", "Section");
							xTextInputFieldElement2.EnableHighlight = EnableState.Disabled;
							xTextInputFieldElement2.ID = text6;
							xTextElement2 = xTextInputFieldElement2;
							break;
						}
						case (z0ZzZzfrk)10:
						{
							XTextInputFieldElement xTextInputFieldElement = z0rek(z0ZzZzsah2, text6, xTextElement);
							xTextInputFieldElement.z0oek(xTextElement);
							xTextInputFieldElement.EnableHighlight = EnableState.Disabled;
							xTextElement2 = xTextInputFieldElement;
							break;
						}
						default:
							xTextElement2 = z0ZzZzdrk.z0eek(text6, null, z0ZzZzfrk2);
							break;
						}
						if (xTextElement2 == null)
						{
							break;
						}
						xTextElement2.z0oek(xTextElement);
						if (xTextElement2 is XTextInputFieldElement)
						{
							((XTextInputFieldElement)xTextElement2).EditorActiveMode = ValueEditorActiveMode.Program | ValueEditorActiveMode.F2 | ValueEditorActiveMode.MouseDblClick;
						}
						if (z0ZzZzfrk2 != (z0ZzZzfrk)5 && z0ZzZzfrk2 != (z0ZzZzfrk)10)
						{
							z0rek(xTextElement2, z0ZzZzsah2);
						}
						xTextElement.z0be().Add(xTextElement2);
						if (xTextElement2 is XTextInputFieldElement)
						{
							z0krk.Push((XTextContainerElement)xTextElement2);
							z0cek.Add(text6);
							if (z0ZzZzfrk2 != (z0ZzZzfrk)5 && z0ZzZzfrk2 != (z0ZzZzfrk)10)
							{
								z0rek(z0ZzZzsah2, text2);
							}
						}
					}
					else
					{
						if (!(z0ZzZzsah2.z0eek("text:newcontrol-end") == "true"))
						{
							break;
						}
						string text7 = z0ZzZzsah2.z0eek("text:newcontrol-name");
						if (text7 != null && text7.EndsWith("_End"))
						{
							text7 = text7.Substring(0, text7.Length - 4);
							if (z0cek.Contains(text7))
							{
								z0krk.Pop();
								z0cek.Remove(text7);
							}
						}
					}
					break;
				case "line-break":
				{
					XTextLineBreakElement xTextLineBreakElement = new XTextLineBreakElement();
					xTextLineBreakElement.z0oek(xTextElement);
					xTextElement.z0be().Add(xTextLineBreakElement);
					break;
				}
				case "a":
					z0rek(z0ZzZzsah2, text2);
					break;
				case "span":
					z0rek(z0ZzZzsah2, text2);
					break;
				case "tab":
				{
					XTextCharElement xTextCharElement = new XTextCharElement();
					xTextCharElement.z0oek(xTextElement);
					xTextCharElement.CharValue = '\t';
					xTextElement.z0be().Add(xTextCharElement);
					break;
				}
				case "s":
				{
					XTextStringElement xTextStringElement2 = new XTextStringElement();
					xTextStringElement2.z0oek(xTextElement);
					xTextStringElement2.Text = item.z0eg();
					xTextStringElement2.z0oek(z0rek(p1, "text-properties"));
					if (string.IsNullOrEmpty(xTextStringElement2.Text) && z0ZzZzsah2.z0rek("text:c"))
					{
						int num2 = Convert.ToInt32(z0ZzZzsah2.z0eek("text:c"));
						if (num2 > 0)
						{
							xTextStringElement2.Text = new string(' ', num2);
						}
					}
					if (item.z0th() == "text:s" && string.IsNullOrEmpty(xTextStringElement2.Text))
					{
						xTextStringElement2.Text = " ";
					}
					xTextElement.z0be().Add(xTextStringElement2);
					break;
				}
				case "frame":
				{
					XTextImageElement xTextImageElement = new XTextImageElement();
					xTextImageElement.z0oek(xTextElement);
					xTextImageElement.ID = z0ZzZzsah2.z0eek("draw:name");
					text2 = z0ZzZzsah2.z0eek("draw:style-name");
					xTextImageElement.z0oek(z0rek(text2, "graphic-properties"));
					if (z0ZzZzsah2.z0rek("svg:width"))
					{
						xTextImageElement.Width = z0rek(z0ZzZzsah2.z0eek("svg:width"));
					}
					if (z0ZzZzsah2.z0rek("svg:height"))
					{
						xTextImageElement.Height = z0rek(z0ZzZzsah2.z0eek("svg:height"));
					}
					if (z0ZzZzsah2.z0rek("svg:x") || z0ZzZzsah2.z0rek("svg:y"))
					{
						string text3 = z0ZzZzsah2.z0eek("svg:x");
						string text4 = z0ZzZzsah2.z0eek("svg:y");
						((XTextObjectElement)xTextImageElement).z0eek((object)(text3 + "|" + text4));
					}
					z0ZzZzsah z0ZzZzsah5 = (z0ZzZzsah)z0rek(z0ZzZzsah2, "draw:image", p2: false);
					if (z0ZzZzsah5 != null)
					{
						string text5 = z0ZzZzsah5.z0eek("xlink:href");
						if (!string.IsNullOrEmpty(text5) && z0pek.ContainsKey(text5))
						{
							xTextImageElement.z0rek(z0pek[text5]);
							xTextImageElement.z0bt(z0oek);
							xTextElement.z0be().Add(xTextImageElement);
						}
					}
					break;
				}
				case "page-number":
				{
					XTextPageInfoElement xTextPageInfoElement2 = new XTextPageInfoElement();
					xTextPageInfoElement2.z0oek(xTextElement);
					xTextPageInfoElement2.AutoHeight = true;
					xTextPageInfoElement2.z0oek(z0rek(text2, "text-properties"));
					if (z0ZzZzsah2.z0eek("text:select-page") == "current")
					{
						xTextPageInfoElement2.ValueType = PageInfoValueType.PageIndex;
					}
					xTextElement.z0be().Add(xTextPageInfoElement2);
					break;
				}
				case "page-count":
				{
					XTextPageInfoElement xTextPageInfoElement = new XTextPageInfoElement();
					xTextPageInfoElement.z0oek(xTextElement);
					xTextPageInfoElement.AutoHeight = true;
					xTextPageInfoElement.z0oek(z0rek(text2, "text-properties"));
					xTextPageInfoElement.ValueType = PageInfoValueType.NumOfPages;
					xTextElement.z0be().Add(xTextPageInfoElement);
					break;
				}
				}
			}
		}
	}

	private bool z0rek(byte[] p0)
	{
		MemoryStream p1 = new MemoryStream(p0);
		z0pek = z0rek(p1);
		if (z0oek == null)
		{
			z0oek = new XTextDocument();
		}
		z0oek.z0rpk();
		if (!z0rek())
		{
			return false;
		}
		if (z0yek.z0uek().z0ph() != "document-content")
		{
			return false;
		}
		z0ZzZzsah z0ZzZzsah2 = (z0ZzZzsah)z0rek(z0yek.z0uek(), "office:automatic-styles", p2: false);
		if (z0ZzZzsah2 != null)
		{
			z0oek.z0gnk().Styles.Clear();
			z0rek(z0ZzZzsah2);
		}
		z0ZzZzsah z0ZzZzsah3 = (z0ZzZzsah)z0rek(z0yek.z0uek(), "office:body", p2: false);
		if (z0ZzZzsah3 != null)
		{
			z0ZzZzsah z0ZzZzsah4 = (z0ZzZzsah)z0rek(z0ZzZzsah3, "office:text", p2: false);
			if (z0ZzZzsah4 != null)
			{
				z0oek.z0xyk().z0be().Clear();
				z0krk.Clear();
				z0krk.Push(z0oek.z0xyk());
				z0rek(z0ZzZzsah4, null);
			}
		}
		if (z0nek != null)
		{
			string.IsNullOrEmpty(z0lrk);
			z0ZzZzsah z0ZzZzsah5 = (z0ZzZzsah)z0ZzZzzik.z0eek(z0nek, "office:document-styles/office:master-styles/style:master-page[@style:name='" + z0lrk + "']");
			if (z0ZzZzsah5 == null)
			{
				z0ZzZzsah5 = (z0ZzZzsah)z0ZzZzzik.z0eek(z0nek, "office:document-styles/office:master-styles/style:master-page");
			}
			if (z0ZzZzsah5 != null)
			{
				string text = z0ZzZzsah5.z0eek("style:page-layout-name");
				if (!string.IsNullOrEmpty(text))
				{
					z0ZzZzsah z0ZzZzsah6 = (z0ZzZzsah)z0ZzZzzik.z0eek(z0nek, "office:document-styles/office:automatic-styles/style:page-layout[@style:name='" + text + "']");
					if (z0ZzZzsah6 != null)
					{
						z0ZzZzsah z0ZzZzsah7 = (z0ZzZzsah)z0rek(z0ZzZzsah6, "style:page-layout-properties", p2: false);
						if (z0ZzZzsah7 != null)
						{
							float num = 0f;
							float num2 = 0f;
							foreach (z0ZzZzbsh item in z0ZzZzsah7.z0sg())
							{
								switch (item.z0ph())
								{
								case "margin-left":
									z0oek.PageSettings.LeftMargin = (int)(z0rek(item.z0rh()) / 3f);
									break;
								case "margin-top":
									z0oek.PageSettings.TopMargin = (int)(z0rek(item.z0rh()) / 3f);
									break;
								case "margin-right":
									z0oek.PageSettings.RightMargin = (int)(z0rek(item.z0rh()) / 3f);
									break;
								case "margin-bottom":
									z0oek.PageSettings.LeftMargin = (int)(z0rek(item.z0rh()) / 3f);
									break;
								case "page-width":
									num = z0rek(item.z0rh()) / 3f;
									break;
								case "page-height":
									num2 = z0rek(item.z0rh()) / 3f;
									break;
								case "print-orientation":
									if (string.Compare(item.z0rh(), "landscape", true) == 0)
									{
										z0oek.PageSettings.z0pek(p0: true);
									}
									else
									{
										z0oek.PageSettings.z0pek(p0: false);
									}
									break;
								}
							}
							if (num > 0f && num2 > 0f)
							{
								z0oek.PageSettings.z0eek((int)num, (int)num2, p2: false);
							}
						}
					}
				}
				z0ZzZzsah p2 = (z0ZzZzsah)z0rek(z0nek.z0uek(), "office:automatic-styles", p2: false);
				z0rek(p2);
				z0ZzZzsah z0ZzZzsah8 = (z0ZzZzsah)z0ZzZzzik.z0eek(z0ZzZzsah5, "style:header");
				if (z0ZzZzsah8 != null)
				{
					z0oek.z0pyk().z0be().Clear();
					z0krk.Clear();
					z0krk.Push(z0oek.z0pyk());
					z0rek(z0ZzZzsah8, null);
				}
				z0ZzZzsah z0ZzZzsah9 = (z0ZzZzsah)z0ZzZzzik.z0eek(z0ZzZzsah5, "style:footer");
				if (z0ZzZzsah9 != null)
				{
					z0oek.z0lik().z0be().Clear();
					z0krk.Clear();
					z0krk.Push(z0oek.z0lik());
					z0rek(z0ZzZzsah9, null);
				}
			}
		}
		using (zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = z0oek.z0nek<XTextInputFieldElement>().z0ltk())
		{
			while (z0bpk.MoveNext())
			{
				XTextInputFieldElement xTextInputFieldElement = (XTextInputFieldElement)z0bpk.Current;
				if (!(xTextInputFieldElement.z0zwk("UseStubString") == "TRUE"))
				{
					continue;
				}
				if (!string.IsNullOrEmpty(xTextInputFieldElement.Text))
				{
					xTextInputFieldElement.BackgroundText = xTextInputFieldElement.Text;
					if (xTextInputFieldElement.z0be().z0krk() is XTextCharElement)
					{
						xTextInputFieldElement.BackgroundTextColor = xTextInputFieldElement.z0be()[0].z0aek().z0bek;
					}
					xTextInputFieldElement.z0be().Clear();
				}
				xTextInputFieldElement.Attributes.z0rek("UseStubString");
				xTextInputFieldElement.Attributes.z0rek("StubString");
			}
		}
		return true;
	}

	public static z0ZzZzoah z0rek(z0ZzZzsah p0, string p1, bool p2 = false)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("RootElement");
		}
		if (p1 == null)
		{
			throw new ArgumentNullException("strName");
		}
		foreach (z0ZzZzoah item in ((z0ZzZzoah)p0).z0tek())
		{
			if (item.z0th() == p1)
			{
				return item;
			}
		}
		if (p2)
		{
			z0ZzZzsah z0ZzZzsah2 = p0.z0wg().z0rek(p1);
			p0.z0if(z0ZzZzsah2);
			return z0ZzZzsah2;
		}
		return null;
	}

	public static Dictionary<string, byte[]> z0rek(Stream p0)
	{
		return z0ZzZzloj.z0rek(p0);
	}
}
