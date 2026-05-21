using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using DCSoft.Common;
using DCSoft.Drawing;
using DCSoft.Writer;
using DCSoft.Writer.Dom;
using DCSystem_Drawing;
using DCSystem_Drawing.Drawing2D;

namespace zzz;

public class z0ZzZzsjh : IDisposable
{
	public class z0exk
	{
		public JsonElement z0rek;

		public int z0tek;

		public XTextDocument z0yek;

		public XTextContainerElement z0uek;

		public void z0eek(XTextElement p0)
		{
			z0uek.z0be().Add(p0);
			p0.z0yek(z0yek, z0uek);
		}
	}

	private class z0bok : zzz.z0ZzZzkuk<char>
	{
		public string z0eek()
		{
			if (base.Count == 0)
			{
				return string.Empty;
			}
			return new string(z0atk, 0, base.Count);
		}
	}

	private Dictionary<string, float> z0oek = new Dictionary<string, float>();

	private XTextDocument z0pek;

	private List<int> z0mek;

	private bool z0nek = true;

	private static float z0eek(string p0, float p1)
	{
		StringBuilder stringBuilder = new StringBuilder();
		foreach (char c in p0)
		{
			if (!z0eek(c))
			{
				break;
			}
			stringBuilder.Append(c);
		}
		float result = 0f;
		if (float.TryParse(stringBuilder.ToString(), out result))
		{
			return result;
		}
		return p1;
	}

	private void z0eek(XTextContainerElement p0, string p1, JsonElement p2, int p3)
	{
		JsonElement.ObjectEnumerator objectEnumerator = p2.EnumerateObject();
		bool flag = false;
		if (p1 != null)
		{
			switch (p1.Length)
			{
			case 3:
			{
				char c = p1[2];
				if ((uint)c <= 103u)
				{
					if (c != 'b')
					{
						if (c != 'e')
						{
							if (c != 'g' || !(p1 == "img"))
							{
								break;
							}
							XTextImageElement xTextImageElement = new XTextImageElement();
							xTextImageElement.z0yek(z0pek, p0);
							p0.z0be().Add(xTextImageElement);
							while (objectEnumerator.MoveNext())
							{
								JsonElement value4 = objectEnumerator.Current.Value;
								switch (objectEnumerator.Current.Name)
								{
								case "src":
								{
									byte[] array = z0ZzZzpmk.ParseEmitImageSource(value4.z0yek());
									if (array != null && array.Length != 0)
									{
										xTextImageElement.z0rek(array);
									}
									break;
								}
								case "width":
									xTextImageElement.Width = z0rek(value4.z0yek(), xTextImageElement.Width);
									break;
								case "height":
									xTextImageElement.Height = z0rek(value4.z0yek(), xTextImageElement.Height);
									break;
								}
							}
							return;
						}
						if (!(p1 == "pre"))
						{
							break;
						}
						goto IL_029e;
					}
					if (!(p1 == "sub"))
					{
						break;
					}
				}
				else
				{
					if (c == 'l')
					{
						if (!(p1 == "col"))
						{
							break;
						}
						flag = true;
						XTextTableColumnElement xTextTableColumnElement = new XTextTableColumnElement();
						XTextTableElement xTextTableElement = (XTextTableElement)p0;
						xTextTableColumnElement.z0yek(z0pek, xTextTableElement);
						xTextTableElement.z0srk().Add(xTextTableColumnElement);
						while (objectEnumerator.MoveNext())
						{
							if (!(objectEnumerator.Current.Name == "StyleIndex"))
							{
								continue;
							}
							int @int = objectEnumerator.Current.Value.GetInt32();
							if (@int >= 0)
							{
								DocumentContentStyle documentContentStyle = z0pek.z0gnk().Styles[@int] as DocumentContentStyle;
								xTextTableColumnElement.z0oek(@int);
								if (documentContentStyle.z0zek > 0f)
								{
									xTextTableColumnElement.Width = documentContentStyle.z0zek;
								}
							}
						}
						return;
					}
					if (c != 'p')
					{
						if (c != 'v' || !(p1 == "div"))
						{
							break;
						}
						goto IL_046c;
					}
					if (!(p1 == "sup"))
					{
						break;
					}
				}
				goto IL_12e1;
			}
			case 5:
			{
				char c = p1[1];
				if ((uint)c <= 98u)
				{
					switch (c)
					{
					case 'a':
					{
						if (!(p1 == "table"))
						{
							break;
						}
						XTextTableElement xTextTableElement2 = new XTextTableElement();
						xTextTableElement2.z0yek(z0pek, p0);
						p0.z0be().Add(xTextTableElement2);
						flag = false;
						while (objectEnumerator.MoveNext())
						{
							JsonElement value6 = objectEnumerator.Current.Value;
							switch (objectEnumerator.Current.Name)
							{
							case "id":
								xTextTableElement2.ID = value6.z0yek();
								break;
							case "childNodes":
								if (value6.ValueKind == JsonValueKind.Array)
								{
									z0eek(xTextTableElement2, value6, p3);
								}
								break;
							case "tbody":
							case "colgroup":
								if (objectEnumerator.Current.Name == "colgroup")
								{
									flag = true;
								}
								if (value6.ValueKind == JsonValueKind.Array)
								{
									z0eek(xTextTableElement2, value6, p3);
								}
								break;
							case "col":
								z0eek(xTextTableElement2, p1, value6, p3);
								break;
							case "tr":
								z0eek(xTextTableElement2, p1, value6, p3);
								break;
							}
						}
						if (!flag)
						{
							z0rek(xTextTableElement2);
							z0eek(xTextTableElement2);
						}
						else
						{
							flag = false;
						}
						float num2 = z0pek.PageSettings.z0prk();
						float num3 = 0f;
						using (zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = xTextTableElement2.z0srk().z0ltk())
						{
							while (z0bpk.MoveNext())
							{
								XTextTableColumnElement xTextTableColumnElement2 = (XTextTableColumnElement)z0bpk.Current;
								num3 += xTextTableColumnElement2.Width;
							}
						}
						if (!(num3 > num2))
						{
							return;
						}
						float num4 = num2 / num3;
						using zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = xTextTableElement2.z0srk().z0ltk();
						while (z0bpk.MoveNext())
						{
							((XTextTableColumnElement)z0bpk.Current).Width *= num4;
						}
						return;
					}
					case 'b':
					{
						if (!(p1 == "tbody"))
						{
							break;
						}
						XTextTableElement p4 = (XTextTableElement)p0;
						while (objectEnumerator.MoveNext())
						{
							if (objectEnumerator.Current.Name == "childNodes")
							{
								z0eek(p4, objectEnumerator.Current.Value, p3);
								break;
							}
						}
						return;
					}
					}
					break;
				}
				if (c != 'n')
				{
					if (c != 't' || !(p1 == "#text"))
					{
						break;
					}
					goto IL_029e;
				}
				if (!(p1 == "input"))
				{
					break;
				}
				XTextElement xTextElement2 = null;
				string text2 = z0eek(p2, "type");
				if (text2 != null)
				{
					switch (text2.Trim().ToLower())
					{
					case "text":
						xTextElement2 = new XTextInputFieldElement();
						break;
					case "button":
						xTextElement2 = new XTextButtonElement();
						break;
					case "checkbox":
						xTextElement2 = new XTextCheckBoxElement();
						break;
					case "radio":
						xTextElement2 = new XTextRadioBoxElement();
						break;
					}
				}
				if (xTextElement2 == null)
				{
					return;
				}
				xTextElement2.z0yek(z0pek, p0);
				p0.z0be().Add(xTextElement2);
				while (objectEnumerator.MoveNext())
				{
					JsonElement value7 = objectEnumerator.Current.Value;
					switch (objectEnumerator.Current.Name)
					{
					case "width":
						if (xTextElement2 is XTextButtonElement)
						{
							xTextElement2.Width = z0rek(value7.z0yek(), xTextElement2.Width);
						}
						break;
					case "height":
						xTextElement2.Height = z0rek(value7.z0yek(), xTextElement2.Height);
						break;
					case "id":
						xTextElement2.ID = value7.z0yek();
						break;
					case "name":
						if (xTextElement2 is XTextInputFieldElement)
						{
							((XTextInputFieldElement)xTextElement2).Name = value7.z0yek();
						}
						else if (xTextElement2 is XTextButtonElement)
						{
							((XTextButtonElement)xTextElement2).Name = value7.z0yek();
						}
						else if (xTextElement2 is XTextCheckBoxElementBase)
						{
							((XTextCheckBoxElementBase)xTextElement2).Name = value7.z0yek();
						}
						break;
					case "palceholder":
						if (xTextElement2 is XTextInputFieldElement)
						{
							((XTextInputFieldElement)xTextElement2).BackgroundText = value7.z0yek();
						}
						break;
					case "maxlength":
						if (xTextElement2 is XTextInputFieldElement)
						{
							((XTextInputFieldElement)xTextElement2).MaxInputLength = value7.z0yek(0);
						}
						break;
					case "value":
						if (xTextElement2 is XTextInputFieldElement)
						{
							((XTextInputFieldElement)xTextElement2).Text = value7.z0yek();
						}
						else if (xTextElement2 is XTextCheckBoxElementBase)
						{
							((XTextCheckBoxElementBase)xTextElement2).Caption = value7.z0yek();
						}
						else if (xTextElement2 is XTextButtonElement)
						{
							((XTextButtonElement)xTextElement2).Text = value7.z0yek();
						}
						break;
					case "checked":
						if (xTextElement2 is XTextCheckBoxElementBase)
						{
							((XTextCheckBoxElementBase)xTextElement2).Checked = true;
						}
						break;
					case "readonly":
						if (xTextElement2 is XTextInputFieldElement)
						{
							((XTextInputFieldElement)xTextElement2).ContentReadonly = ContentReadonlyState.True;
						}
						else if (xTextElement2 is XTextCheckBoxElementBase)
						{
							((XTextCheckBoxElementBase)xTextElement2).Readonly = true;
						}
						break;
					case "required":
						if (xTextElement2 is XTextInputFieldElement xTextInputFieldElement3)
						{
							xTextInputFieldElement3.ValidateStyle = new ValueValidateStyle();
							xTextInputFieldElement3.ValidateStyle.Required = true;
						}
						else if (xTextElement2 is XTextCheckBoxElementBase xTextCheckBoxElementBase)
						{
							xTextCheckBoxElementBase.Requried = true;
						}
						break;
					}
				}
				return;
			}
			case 1:
			{
				char c = p1[0];
				if (c != 'b' && c != 'i')
				{
					if (c != 'p')
					{
						break;
					}
					XTextParagraphFlagElement xTextParagraphFlagElement = new XTextParagraphFlagElement();
					xTextParagraphFlagElement.z0yek(z0pek, p0);
					if (p3 >= 0)
					{
						xTextParagraphFlagElement.z0buk = p3;
					}
					while (objectEnumerator.MoveNext())
					{
						switch (objectEnumerator.Current.Name)
						{
						case "align":
						{
							string text = objectEnumerator.Current.Value.z0yek();
							if ("left".Equals(text, StringComparison.OrdinalIgnoreCase))
							{
								xTextParagraphFlagElement.z0xrk().Align = DocumentContentAlignment.Left;
							}
							else if ("center".Equals(text, StringComparison.OrdinalIgnoreCase))
							{
								xTextParagraphFlagElement.z0xrk().Align = DocumentContentAlignment.Center;
							}
							else if ("right".Equals(text, StringComparison.OrdinalIgnoreCase))
							{
								xTextParagraphFlagElement.z0xrk().Align = DocumentContentAlignment.Right;
							}
							else if ("justify".Equals(text, StringComparison.OrdinalIgnoreCase))
							{
								xTextParagraphFlagElement.z0xrk().Align = DocumentContentAlignment.Justify;
							}
							break;
						}
						case "childNodes":
							z0eek(p0, objectEnumerator.Current.Value, p3);
							break;
						case "TextContent":
							z0eek(p0, objectEnumerator.Current.Value.z0yek(), p3);
							break;
						}
					}
					xTextParagraphFlagElement.z0ftk();
					p0.z0be().Add(xTextParagraphFlagElement);
					return;
				}
				goto IL_12e1;
			}
			case 2:
			{
				char c = p1[1];
				if (c != 'd')
				{
					if (c != 'h')
					{
						if (c != 'r')
						{
							break;
						}
						if (!(p1 == "br"))
						{
							if (!(p1 == "tr"))
							{
								break;
							}
							XTextTableRowElement xTextTableRowElement = new XTextTableRowElement();
							xTextTableRowElement.z0yek(z0pek, p0);
							((XTextTableElement)p0).z0stk().Add(xTextTableRowElement);
							xTextTableRowElement.z0buk = p3;
							while (objectEnumerator.MoveNext())
							{
								JsonElement value2 = objectEnumerator.Current.Value;
								string name = objectEnumerator.Current.Name;
								if (!(name == "id"))
								{
									if (name == "childNodes" && value2.ValueKind == JsonValueKind.Array)
									{
										z0eek(xTextTableRowElement, value2, p3);
									}
								}
								else
								{
									xTextTableRowElement.ID = value2.z0yek();
								}
							}
							return;
						}
						bool flag2 = false;
						if (p2.TryGetProperty("dcpf", out var _))
						{
							flag2 = true;
						}
						XTextElement xTextElement = (flag2 ? ((XTextElement)new XTextParagraphFlagElement()) : ((XTextElement)new XTextLineBreakElement()));
						xTextElement.z0yek(z0pek, p0);
						p0.z0be().Add(xTextElement);
						return;
					}
					if (!(p1 == "th"))
					{
						break;
					}
				}
				else if (!(p1 == "td"))
				{
					break;
				}
				XTextTableCellElement xTextTableCellElement = new XTextTableCellElement();
				XTextTableRowElement xTextTableRowElement2 = (XTextTableRowElement)p0;
				if (p1 == "th")
				{
					xTextTableRowElement2.HeaderStyle = true;
				}
				xTextTableCellElement.z0yek(z0pek, xTextTableRowElement2);
				xTextTableRowElement2.z0rek().Add(xTextTableCellElement);
				xTextTableCellElement.z0buk = p3;
				while (objectEnumerator.MoveNext())
				{
					JsonElement value3 = objectEnumerator.Current.Value;
					switch (objectEnumerator.Current.Name)
					{
					case "id":
						xTextTableCellElement.ID = value3.z0yek();
						break;
					case "rowspan":
						xTextTableCellElement.RowSpan = value3.z0yek(1);
						break;
					case "colspan":
						xTextTableCellElement.ColSpan = value3.z0yek(1);
						break;
					case "childNodes":
						z0eek(xTextTableCellElement, value3, p3);
						break;
					case "TextContent":
						z0eek(xTextTableCellElement, value3.z0yek(), p3);
						break;
					}
				}
				for (int num = xTextTableCellElement.ColSpan; num > 1; num--)
				{
					XTextTableCellElement xTextTableCellElement2 = xTextTableCellElement.z0lr(p0: false) as XTextTableCellElement;
					xTextTableCellElement2.z0yek(z0pek, xTextTableRowElement2);
					xTextTableRowElement2.z0rek().Add(xTextTableCellElement2);
				}
				return;
			}
			case 4:
			{
				char c = p1[0];
				if (c != 's')
				{
					if (c != 't' || !(p1 == "text"))
					{
						break;
					}
				}
				else if (!(p1 == "span"))
				{
					break;
				}
				goto IL_046c;
			}
			case 8:
			{
				if (!(p1 == "textarea"))
				{
					break;
				}
				XTextInputFieldElement xTextInputFieldElement2 = new XTextInputFieldElement();
				xTextInputFieldElement2.z0yek(z0pek, p0);
				p0.z0be().Add(xTextInputFieldElement2);
				while (objectEnumerator.MoveNext())
				{
					JsonElement value5 = objectEnumerator.Current.Value;
					switch (objectEnumerator.Current.Name)
					{
					case "Value":
						xTextInputFieldElement2.Text = value5.z0yek();
						break;
					case "id":
						xTextInputFieldElement2.ID = value5.z0yek();
						break;
					case "name":
						xTextInputFieldElement2.Name = value5.z0yek();
						break;
					case "maxlength":
						xTextInputFieldElement2.MaxInputLength = value5.z0yek(0);
						break;
					case "placeholder":
						xTextInputFieldElement2.BackgroundText = value5.z0yek();
						break;
					case "readonly":
						xTextInputFieldElement2.ContentReadonly = ContentReadonlyState.True;
						break;
					case "required":
						xTextInputFieldElement2.ValidateStyle = new ValueValidateStyle();
						xTextInputFieldElement2.ValidateStyle.Required = true;
						break;
					}
				}
				return;
			}
			case 6:
				{
					if (!(p1 == "select"))
					{
						break;
					}
					XTextInputFieldElement xTextInputFieldElement = new XTextInputFieldElement();
					xTextInputFieldElement.FieldSettings = new InputFieldSettings();
					xTextInputFieldElement.FieldSettings.z0eek(InputFieldEditStyle.DropdownList);
					xTextInputFieldElement.UserEditable = false;
					xTextInputFieldElement.z0yek(z0pek, p0);
					while (objectEnumerator.MoveNext())
					{
						JsonElement value = objectEnumerator.Current.Value;
						switch (objectEnumerator.Current.Name)
						{
						case "id":
							xTextInputFieldElement.ID = value.z0yek();
							break;
						case "name":
							xTextInputFieldElement.Name = value.z0yek();
							break;
						case "childNodes":
						{
							if (value.ValueKind != JsonValueKind.Array)
							{
								break;
							}
							JsonElement.ArrayEnumerator arrayEnumerator = value.EnumerateArray();
							while (arrayEnumerator.MoveNext())
							{
								if (arrayEnumerator.Current.ValueKind == JsonValueKind.Object)
								{
									JsonElement.ObjectEnumerator objectEnumerator2 = arrayEnumerator.Current.EnumerateObject();
									while (objectEnumerator2.MoveNext())
									{
										_ = objectEnumerator2.Current.Name == "option";
									}
								}
							}
							break;
						}
						}
					}
					return;
				}
				IL_029e:
				if (!(p0 is XTextTableElement) && !(p0 is XTextTableRowElement))
				{
					z0eek(p0, z0eek(p2, "Value"), p3);
				}
				return;
				IL_046c:
				if (z0eek(p2, "dctype") == "XTextInputFieldElement")
				{
				}
				while (objectEnumerator.MoveNext())
				{
					string name = objectEnumerator.Current.Name;
					if (!(name == "childNodes"))
					{
						if (name == "TextContent")
						{
							z0eek(p0, objectEnumerator.Current.Value.z0yek(), p3);
						}
					}
					else
					{
						z0eek(p0, objectEnumerator.Current.Value, p3);
					}
				}
				return;
				IL_12e1:
				while (objectEnumerator.MoveNext())
				{
					if (!(objectEnumerator.Current.Name == "TextContent"))
					{
						continue;
					}
					string text3 = objectEnumerator.Current.Value.z0yek();
					if (text3 == null || text3.Length <= 0)
					{
						continue;
					}
					XTextElementList xTextElementList = z0pek.z0bek(text3, p3);
					using (zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = xTextElementList.z0ltk())
					{
						while (z0bpk.MoveNext())
						{
							XTextElement current = z0bpk.Current;
							switch (p1)
							{
							case "i":
								current.z0xrk().Italic = true;
								break;
							case "sub":
								current.z0xrk().Subscript = true;
								break;
							case "sup":
								current.z0xrk().Superscript = true;
								break;
							case "b":
								current.z0xrk().Bold = true;
								break;
							}
							current.z0yek(z0pek, p0);
						}
					}
					((zzz.z0ZzZzkuk<XTextElement>)p0.z0be()).z0tek((zzz.z0ZzZzkuk<XTextElement>)xTextElementList);
					xTextElementList.Clear();
				}
				return;
			}
		}
		while (objectEnumerator.MoveNext())
		{
			string name2 = objectEnumerator.Current.Name;
			if (name2 == "childNodes")
			{
				z0eek(p0, objectEnumerator.Current.Value, p3);
				break;
			}
			if (name2 == "TextContent")
			{
				z0eek(p0, objectEnumerator.Current.Value.z0yek(), p3);
			}
		}
	}

	private static bool z0eek(string p0, out DashStyle p1)
	{
		if (p0 == null || p0.Length == 0)
		{
			p1 = DashStyle.Custom;
			return false;
		}
		p0 = p0.Trim();
		if (string.Equals(p0, "solid", StringComparison.CurrentCultureIgnoreCase))
		{
			p1 = DashStyle.Solid;
			return true;
		}
		if (string.Equals(p0, "dashed", StringComparison.CurrentCultureIgnoreCase))
		{
			p1 = DashStyle.Dash;
			return true;
		}
		if (string.Equals(p0, "dotted", StringComparison.CurrentCultureIgnoreCase))
		{
			p1 = DashStyle.Dot;
			return true;
		}
		if (string.Equals(p0, "none", StringComparison.CurrentCultureIgnoreCase))
		{
			p1 = DashStyle.Custom;
			return true;
		}
		p1 = DashStyle.Custom;
		return false;
	}

	private static string z0eek(string p0)
	{
		return p0?.Trim();
	}

	private string z0eek(JsonElement p0, string p1)
	{
		JsonElement.ObjectEnumerator objectEnumerator = p0.EnumerateObject();
		while (objectEnumerator.MoveNext())
		{
			if (objectEnumerator.Current.Name == p1)
			{
				string text = null;
				text = ((objectEnumerator.Current.Value.ValueKind != JsonValueKind.String) ? objectEnumerator.Current.Value.z0yek() : objectEnumerator.Current.Value.GetString());
				objectEnumerator.Dispose();
				return text;
			}
		}
		objectEnumerator.Dispose();
		return null;
	}

	private float z0rek(string p0, float p1)
	{
		if (p0 == null || p0.Length == 0)
		{
			return p1;
		}
		return (float)z0ZzZzrpk.z0eek(p0, GraphicsUnit.Document, p1);
	}

	private void z0eek(XTextContainerElement p0, string p1, int p2)
	{
		if (p1 == null || p1.Length <= 0)
		{
			return;
		}
		XTextElementList xTextElementList = z0pek.z0bek(p1, p2);
		using (zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = xTextElementList.z0ltk())
		{
			while (z0bpk.MoveNext())
			{
				z0bpk.Current.z0yek(z0pek, p0);
			}
		}
		((zzz.z0ZzZzkuk<XTextElement>)p0.z0be()).z0tek((zzz.z0ZzZzkuk<XTextElement>)xTextElementList);
		xTextElementList.Clear();
	}

	public void z0eek(DocumentContentStyle p0, string p1)
	{
		if (p1 != null && p1.Length != 0)
		{
			z0ZzZzdjh.z0eek(p1)?.z0eek(p0);
		}
	}

	private static Color[] z0rek(string p0)
	{
		if (string.IsNullOrEmpty(p0))
		{
			return null;
		}
		p0 = p0.Trim();
		List<Color> list = new List<Color>();
		while (p0.Length > 0)
		{
			p0 = p0.Trim();
			if (p0.StartsWith("rgb(", StringComparison.CurrentCultureIgnoreCase))
			{
				int num = p0.IndexOf(')', 4);
				if (num > 0)
				{
					string p1 = p0.Substring(0, num + 1);
					Color p2 = Color.Black;
					if (z0eek(p1, out p2))
					{
						list.Add(p2);
					}
					p0 = p0.Substring(num + 1, p0.Length - num - 1).Trim();
					continue;
				}
			}
			string text = string.Empty;
			while (p0.Length > 0 && !char.IsWhiteSpace(p0[0]))
			{
				text += p0[0];
				p0 = p0.Substring(1, p0.Length - 1);
			}
			Color p3 = Color.Black;
			if (z0eek(text, out p3))
			{
				list.Add(p3);
			}
		}
		return list.ToArray();
	}

	private void z0eek(DocumentContentStyle p0, string p1, string p2)
	{
		switch (p1)
		{
		case "font-family":
			if (p2 == null || p2.Length <= 0)
			{
				return;
			}
			if (z0nek)
			{
				string text2 = z0uek(p2);
				if (text2 != null && text2.Length > 0)
				{
					p0.z0eek(text2);
				}
			}
			else
			{
				p0.z0eek(p2.Trim());
			}
			return;
		case "font-size":
			if (!p0.z0grk)
			{
				float p3 = 0f;
				if (z0eek(p2, out p3))
				{
					p0.FontSize = z0ZzZzrpk.z0eek(p3, GraphicsUnit.Document, GraphicsUnit.Point);
				}
			}
			return;
		case "font-style":
			if (p2 != null && p2.Length > 0 && p2 != "normal")
			{
				if (p2 == "italic" || p2 == "oblique")
				{
					p0.Italic = true;
				}
				else if (p2.Contains("italic", StringComparison.OrdinalIgnoreCase) || p2.Contains("oblique", StringComparison.OrdinalIgnoreCase))
				{
					p0.Italic = true;
				}
			}
			return;
		case "font-weight":
			if (p2 != null && p2.Length > 0 && p2 != "normal")
			{
				if (p2 == "bold" || p2 == "700")
				{
					p0.Bold = true;
				}
				else if (p2.Contains("bold", StringComparison.OrdinalIgnoreCase))
				{
					p0.Bold = true;
				}
				else if (p2.Contains("700", StringComparison.OrdinalIgnoreCase))
				{
					p0.Bold = true;
				}
			}
			return;
		case "text-decoration":
		{
			if (p2 == null || !(p2 != "none"))
			{
				return;
			}
			if (p2 == "underline")
			{
				p0.Underline = true;
				return;
			}
			if (p2 == "line-through")
			{
				p0.Strikeout = true;
				return;
			}
			string text = p2.Trim().ToLower();
			if (text == "underline")
			{
				p0.Underline = true;
			}
			else if (text == "line-through")
			{
				p0.Strikeout = true;
			}
			return;
		}
		case "word-wrap":
			return;
		case "word-break":
			return;
		case "direction":
			return;
		case null:
			return;
		}
		DashStyle p12;
		Color p13;
		float p14;
		switch (p1.Length)
		{
		case 5:
			switch (p1[0])
			{
			case 'w':
				if (p1 == "width")
				{
					float p8 = 0f;
					if (z0eek(p2, out p8))
					{
						p0.z0zek = p8;
					}
				}
				break;
			case 'c':
				if (p1 == "color")
				{
					Color p7 = Color.Empty;
					if (z0eek(p2, out p7))
					{
						p0.Color = p7;
					}
				}
				break;
			}
			break;
		case 6:
			switch (p1[0])
			{
			case 'h':
				if (p1 == "height")
				{
					float p20 = 0f;
					if (z0eek(p2, out p20))
					{
						p0.z0yrk = p20;
					}
				}
				break;
			case 'b':
				if (p1 == "border")
				{
					if (string.Equals(p2, "none", StringComparison.OrdinalIgnoreCase))
					{
						((z0ZzZzcok)p0).z0tek();
						break;
					}
					DashStyle p17 = DashStyle.Solid;
					Color p18 = Color.Empty;
					float p19 = 0f;
					z0eek(p2, ref p19, ref p17, ref p18);
					p0.z0eek(p19, p17, p18);
				}
				break;
			}
			break;
		case 10:
			switch (p1[2])
			{
			default:
				return;
			case 'c':
			{
				if (!(p1 == "background"))
				{
					return;
				}
				string[] array4 = z0tek(p2);
				if (array4 == null)
				{
					return;
				}
				string[] array5 = array4;
				foreach (string p36 in array5)
				{
					Color p37 = Color.Empty;
					if (z0yek(p36) == null && z0eek(p36, out p37))
					{
						p0.BackgroundColor = p37;
					}
				}
				return;
			}
			case 'r':
				break;
			case 'n':
				if (p1 == "font-style" && p2 != null && p2.Length > 0 && p2 != "normal")
				{
					if (p2 == "italic" || p2 == "oblique")
					{
						p0.Italic = true;
					}
					else if (p2.Contains("italic", StringComparison.OrdinalIgnoreCase) || p2.Contains("oblique", StringComparison.OrdinalIgnoreCase))
					{
						p0.Italic = true;
					}
				}
				return;
			case 'x':
				if (!(p1 == "text-align") || p2 == null || p2.Length <= 0)
				{
					return;
				}
				switch (p2)
				{
				case "justify":
					p0.z0eek(DocumentContentAlignment.Justify);
					return;
				case "left":
					p0.z0eek(DocumentContentAlignment.Left);
					return;
				case "center":
					p0.z0eek(DocumentContentAlignment.Center);
					return;
				case "right":
					p0.z0eek(DocumentContentAlignment.Right);
					return;
				}
				if (p2.IndexOf("left", StringComparison.OrdinalIgnoreCase) >= 0)
				{
					p0.z0eek(DocumentContentAlignment.Left);
				}
				else if (p2.IndexOf("right", StringComparison.OrdinalIgnoreCase) >= 0)
				{
					p0.z0eek(DocumentContentAlignment.Right);
				}
				else if (p2.Contains("center", StringComparison.OrdinalIgnoreCase))
				{
					p0.z0eek(DocumentContentAlignment.Center);
				}
				else if (p2.Contains("justify", StringComparison.OrdinalIgnoreCase))
				{
					p0.z0eek(DocumentContentAlignment.Justify);
				}
				return;
			}
			if (!(p1 == "border-top"))
			{
				break;
			}
			goto IL_0969;
		case 16:
			switch (p1[11])
			{
			case 'c':
				if (!(p1 == "background-color"))
				{
					if (p1 == "border-top-color")
					{
						Color p33 = Color.Black;
						if (z0eek(p2, out p33))
						{
							p0.BorderTop = true;
							p0.BorderTopColor = p33;
						}
					}
				}
				else
				{
					Color p34 = Color.Empty;
					if (z0eek(p2, out p34))
					{
						p0.BackgroundColor = p34;
					}
				}
				break;
			case 's':
			{
				if (!(p1 == "border-top-style"))
				{
					break;
				}
				DashStyle p32 = DashStyle.Solid;
				if (z0eek(p2, out p32))
				{
					p0.BorderStyle = p32;
					if (p32 == DashStyle.Custom)
					{
						p0.BorderStyle = DashStyle.Solid;
						p0.BorderWidth = 0f;
					}
					p0.BorderTop = true;
				}
				break;
			}
			case 'w':
				if (p1 == "border-top-width")
				{
					float p31 = 0f;
					if (z0rek(p2, ref p31))
					{
						p0.BorderWidth = p31;
						p0.BorderTop = true;
					}
				}
				break;
			}
			break;
		case 17:
			switch (p1[12])
			{
			case 's':
			{
				if (!(p1 == "border-left-style"))
				{
					break;
				}
				DashStyle p30 = DashStyle.Solid;
				if (z0eek(p2, out p30))
				{
					p0.BorderStyle = p30;
					if (p30 == DashStyle.Custom)
					{
						p0.BorderStyle = DashStyle.Solid;
						p0.BorderWidth = 0f;
					}
					p0.BorderLeft = true;
				}
				break;
			}
			case 'c':
				if (p1 == "border-left-color")
				{
					Color p29 = Color.Black;
					if (z0eek(p2, out p29))
					{
						p0.BorderLeft = true;
						p0.BorderLeftColor = p29;
					}
				}
				break;
			case 'w':
				if (p1 == "border-left-width")
				{
					float p28 = 0f;
					if (z0rek(p2, ref p28))
					{
						p0.BorderWidth = p28;
						p0.BorderLeft = true;
					}
				}
				break;
			}
			break;
		case 18:
			switch (p1[13])
			{
			case 's':
			{
				if (!(p1 == "border-right-style"))
				{
					break;
				}
				DashStyle p27 = DashStyle.Solid;
				if (z0eek(p2, out p27))
				{
					p0.BorderStyle = p27;
					if (p27 == DashStyle.Custom)
					{
						p0.BorderStyle = DashStyle.Solid;
						p0.BorderWidth = 0f;
					}
					p0.BorderRight = true;
				}
				break;
			}
			case 'c':
				if (p1 == "border-right-color")
				{
					Color p26 = Color.Black;
					if (z0eek(p2, out p26))
					{
						p0.BorderRight = true;
						p0.BorderRightColor = p26;
					}
				}
				break;
			case 'w':
				if (p1 == "border-right-width")
				{
					float p25 = 0f;
					if (z0rek(p2, ref p25))
					{
						p0.BorderWidth = p25;
						p0.BorderRight = true;
					}
				}
				break;
			}
			break;
		case 19:
			switch (p1[14])
			{
			case 's':
			{
				if (!(p1 == "border-bottom-style"))
				{
					break;
				}
				DashStyle p23 = DashStyle.Solid;
				if (z0eek(p2, out p23))
				{
					p0.BorderStyle = p23;
					if (p23 == DashStyle.Custom)
					{
						p0.BorderStyle = DashStyle.Solid;
						p0.BorderWidth = 0f;
					}
					p0.BorderBottom = true;
				}
				break;
			}
			case 'c':
				if (p1 == "border-bottom-color")
				{
					Color p22 = Color.Black;
					if (z0eek(p2, out p22))
					{
						p0.BorderBottom = true;
						p0.BorderBottomColor = p22;
					}
				}
				break;
			case 'w':
				if (p1 == "border-bottom-width")
				{
					float p21 = 0f;
					if (z0rek(p2, ref p21))
					{
						p0.BorderWidth = p21;
						p0.BorderBottom = true;
					}
				}
				break;
			}
			break;
		case 11:
			switch (p1[5])
			{
			case 'r':
				break;
			case 'f':
				if (p1 == "font-family")
				{
					string text6 = z0uek(p2);
					if (text6 != null)
					{
						p0.z0eek(text6);
					}
				}
				return;
			case 'w':
				if (p1 == "font-weight" && p2 != null && p2.Length > 0 && p2 != "normal")
				{
					if (p2 == "bold" || p2 == "700")
					{
						p0.Bold = true;
					}
					else if (p2.Contains("bold", StringComparison.OrdinalIgnoreCase))
					{
						p0.Bold = true;
					}
					else if (p2.Contains("700", StringComparison.OrdinalIgnoreCase))
					{
						p0.Bold = true;
					}
				}
				return;
			case 'h':
			{
				if (!(p1 == "line-height") || p2 == null)
				{
					return;
				}
				p2 = p2.Trim().ToLower();
				if (p2.EndsWith("%"))
				{
					string text4 = p2.Substring(0, p2.Length - 1);
					int num = 0;
					if (int.TryParse(text4, out num))
					{
						switch (num)
						{
						case 100:
							p0.LineSpacing = 0f;
							p0.LineSpacingStyle = LineSpacingStyle.SpaceSingle;
							break;
						case 150:
							p0.LineSpacingStyle = LineSpacingStyle.Space1pt5;
							break;
						case 200:
							p0.LineSpacingStyle = LineSpacingStyle.SpaceDouble;
							break;
						default:
							p0.LineSpacingStyle = LineSpacingStyle.SpaceMultiple;
							p0.LineSpacing = (float)num / 100f;
							break;
						}
					}
					return;
				}
				if (p2.EndsWith("em"))
				{
					string text5 = p2.Substring(0, p2.Length - 2);
					float num2 = 0f;
					if (float.TryParse(text5, out num2))
					{
						if (num2 == 1f)
						{
							p0.LineSpacing = 0f;
							p0.LineSpacingStyle = LineSpacingStyle.SpaceSingle;
						}
						else if ((double)num2 == 1.5)
						{
							p0.LineSpacingStyle = LineSpacingStyle.Space1pt5;
						}
						else if (num2 == 2f)
						{
							p0.LineSpacingStyle = LineSpacingStyle.SpaceDouble;
						}
						else
						{
							p0.LineSpacingStyle = LineSpacingStyle.SpaceMultiple;
							p0.LineSpacing = num2 / 1f;
						}
					}
					return;
				}
				float num3 = 0f;
				bool flag = !p2.Contains("px");
				if (float.TryParse(p2.Replace("px", ""), out num3))
				{
					if (num3 == 1f)
					{
						p0.LineSpacing = 0f;
						p0.LineSpacingStyle = LineSpacingStyle.SpaceSingle;
					}
					else if ((double)num3 == 1.5)
					{
						p0.LineSpacingStyle = LineSpacingStyle.Space1pt5;
					}
					else if (num3 == 2f)
					{
						p0.LineSpacingStyle = LineSpacingStyle.SpaceDouble;
					}
					else if (flag)
					{
						p0.LineSpacingStyle = LineSpacingStyle.SpaceMultiple;
						p0.LineSpacing = num3;
					}
					else
					{
						p0.LineSpacingStyle = LineSpacingStyle.SpaceSpecify;
						p0.LineSpacing = z0ZzZzrpk.z0eek(num3, GraphicsUnit.Pixel, GraphicsUnit.Document);
					}
				}
				return;
			}
			case 'i':
				if (p1 == "text-indent")
				{
					float p16 = 0f;
					if (z0eek(p2, out p16))
					{
						p0.FirstLineIndent = p16;
					}
				}
				return;
			case 'n':
				if (p1 == "padding-top")
				{
					float p15 = 0f;
					if (z0eek(p2, out p15))
					{
						p0.PaddingTop = p15;
					}
				}
				return;
			default:
				return;
			}
			if (!(p1 == "border-left"))
			{
				break;
			}
			goto IL_0969;
		case 12:
			switch (p1[7])
			{
			default:
				return;
			case 'r':
				break;
			case 'c':
				if (p1 == "border-color")
				{
					p0.BorderLeft = true;
					p0.BorderTop = true;
					p0.BorderRight = true;
					p0.BorderBottom = true;
					Color[] array2 = z0rek(p2);
					if (array2 != null && array2.Length == 1)
					{
						p0.BorderLeftColor = array2[0];
						p0.BorderTopColor = array2[0];
						p0.BorderRightColor = array2[0];
						p0.BorderBottomColor = array2[0];
					}
					else if (array2 != null && array2.Length == 2)
					{
						p0.BorderTopColor = array2[0];
						p0.BorderBottomColor = array2[0];
						p0.BorderLeftColor = array2[1];
						p0.BorderRightColor = array2[1];
					}
					else if (array2 != null && array2.Length == 3)
					{
						p0.BorderTopColor = array2[0];
						p0.BorderRightColor = array2[1];
						p0.BorderLeftColor = array2[1];
						p0.BorderBottomColor = array2[2];
					}
					else if (array2 != null && array2.Length >= 4)
					{
						p0.BorderTopColor = array2[0];
						p0.BorderRightColor = array2[1];
						p0.BorderBottomColor = array2[2];
						p0.BorderLeftColor = array2[3];
					}
				}
				return;
			case 'w':
				if (p1 == "border-width")
				{
					float p10 = 0f;
					if (z0rek(p2, ref p10))
					{
						p0.BorderWidth = p10;
						p0.BorderLeft = true;
						p0.BorderTop = true;
						p0.BorderRight = true;
						p0.BorderBottom = true;
					}
				}
				return;
			case 's':
			{
				if (!(p1 == "border-style"))
				{
					return;
				}
				DashStyle p11 = DashStyle.Solid;
				if (z0eek(p2, out p11))
				{
					p0.BorderStyle = p11;
					if (p11 == DashStyle.Custom)
					{
						p0.BorderStyle = DashStyle.Solid;
						p0.BorderWidth = 0f;
					}
					p0.BorderLeft = true;
					p0.BorderTop = true;
					p0.BorderRight = true;
					p0.BorderBottom = true;
				}
				return;
			}
			case '-':
				if (p1 == "padding-left")
				{
					float p9 = 0f;
					if (z0eek(p2, out p9))
					{
						p0.PaddingLeft = p9;
					}
				}
				return;
			}
			if (!(p1 == "border-right"))
			{
				break;
			}
			goto IL_0969;
		case 13:
			switch (p1[0])
			{
			default:
				return;
			case 'b':
				break;
			case 'p':
				if (p1 == "padding-right")
				{
					float p6 = 0f;
					if (z0eek(p2, out p6))
					{
						p0.PaddingRight = p6;
					}
				}
				return;
			}
			if (!(p1 == "border-bottom"))
			{
				break;
			}
			goto IL_0969;
		case 14:
			switch (p1[0])
			{
			case 'p':
				if (p1 == "padding-bottom")
				{
					float p5 = 0f;
					if (z0eek(p2, out p5))
					{
						p0.PaddingBottom = p5;
					}
				}
				break;
			case 'v':
				if (!(p1 == "vertical-align") || p2 == null || p2.Length <= 0)
				{
					break;
				}
				switch (p2)
				{
				case "top":
					p0.VerticalAlign = VerticalAlignStyle.Top;
					break;
				case "middle":
					p0.VerticalAlign = VerticalAlignStyle.Middle;
					break;
				case "bottom":
					p0.VerticalAlign = VerticalAlignStyle.Bottom;
					break;
				default:
					switch (p2.Trim().ToLower())
					{
					case "top":
						p0.VerticalAlign = VerticalAlignStyle.Top;
						break;
					case "middle":
						p0.VerticalAlign = VerticalAlignStyle.Middle;
						break;
					case "bottom":
						p0.VerticalAlign = VerticalAlignStyle.Bottom;
						break;
					}
					break;
				}
				break;
			case 'l':
				if (p1 == "letter-spacing")
				{
					float p4 = 0f;
					if (z0eek(p2, out p4))
					{
						p0.LetterSpacing = p4;
					}
				}
				break;
			}
			break;
		case 15:
		{
			if (!(p1 == "text-decoration") || p2 == null || !(p2 != "none"))
			{
				break;
			}
			if (p2 == "underline")
			{
				p0.Underline = true;
				break;
			}
			if (p2 == "line-through")
			{
				p0.Strikeout = true;
				break;
			}
			string text3 = p2.Trim().ToLower();
			if (text3 == "underline")
			{
				p0.Underline = true;
			}
			else if (text3 == "line-through")
			{
				p0.Strikeout = true;
			}
			break;
		}
		case 4:
		{
			if (!(p1 == "font"))
			{
				break;
			}
			string[] array3 = z0tek(p2);
			if (array3 == null)
			{
				break;
			}
			foreach (string text7 in array3)
			{
				float p35 = 0f;
				if (string.Equals(text7, "italic", StringComparison.OrdinalIgnoreCase))
				{
					p0.Italic = true;
					continue;
				}
				if (string.Equals(text7, "oblique", StringComparison.OrdinalIgnoreCase))
				{
					p0.Italic = true;
					continue;
				}
				if (string.Equals(text7, "bold", StringComparison.OrdinalIgnoreCase))
				{
					p0.Bold = true;
					continue;
				}
				if (string.Equals(text7, "bolder", StringComparison.OrdinalIgnoreCase))
				{
					p0.Bold = true;
					continue;
				}
				if (z0eek(text7, out p35))
				{
					p0.FontSize = z0ZzZzrpk.z0eek(p35, GraphicsUnit.Document, GraphicsUnit.Point);
					p0.z0grk = true;
					continue;
				}
				string text8 = z0uek(text7);
				if (text8 != null)
				{
					p0.z0eek(text8);
				}
			}
			break;
		}
		case 9:
			if (p1 == "font-size" && !p0.z0grk)
			{
				float p24 = 0f;
				if (z0eek(p2, out p24))
				{
					p0.FontSize = z0ZzZzrpk.z0eek(p24, GraphicsUnit.Document, GraphicsUnit.Point);
				}
			}
			break;
		case 7:
		{
			if (!(p1 == "padding"))
			{
				break;
			}
			float[] array = z0iek(p2);
			if (array != null)
			{
				if (array.Length >= 4)
				{
					p0.z0eek(array[3], array[0], array[1], array[2]);
				}
				else if (array.Length == 1)
				{
					p0.z0eek(array[0], array[0], array[0], array[0]);
				}
				else if (array.Length == 2)
				{
					p0.PaddingTop = array[0];
					p0.PaddingBottom = array[0];
					p0.PaddingLeft = array[1];
					p0.PaddingRight = array[1];
				}
				else if (array.Length == 3)
				{
					p0.PaddingTop = array[0];
					p0.PaddingRight = array[1];
					p0.PaddingLeft = array[1];
					p0.PaddingBottom = array[2];
				}
			}
			break;
		}
		case 8:
			break;
			IL_0969:
			if (string.Equals(p2, "none", StringComparison.OrdinalIgnoreCase))
			{
				switch (p1)
				{
				case "border-left":
					p0.BorderLeft = false;
					break;
				case "border-top":
					p0.BorderTop = false;
					break;
				case "border-right":
					p0.BorderRight = false;
					break;
				case "border-bottom":
					p0.BorderBottom = false;
					break;
				}
				break;
			}
			p12 = DashStyle.Solid;
			p13 = Color.Empty;
			p14 = 0f;
			z0eek(p2, ref p14, ref p12, ref p13);
			p0.BorderStyle = p12;
			p0.BorderWidth = p14;
			switch (p1)
			{
			case "border-left":
				p0.BorderLeft = true;
				p0.BorderLeftColor = p13;
				break;
			case "border-top":
				p0.BorderTop = true;
				p0.BorderTopColor = p13;
				break;
			case "border-right":
				p0.BorderRight = true;
				p0.BorderRightColor = p13;
				break;
			case "border-bottom":
				p0.BorderBottom = true;
				p0.BorderBottomColor = p13;
				break;
			}
			break;
		}
	}

	private static string[] z0tek(string p0)
	{
		if (p0 == null || p0.Length == 0)
		{
			return null;
		}
		List<string> list = new List<string>();
		z0bok z0bok = new z0bok();
		bool flag = false;
		char c = '\0';
		int length = p0.Length;
		for (int i = 0; i < length; i++)
		{
			char c2 = p0[i];
			if (flag)
			{
				if (c2 == ')')
				{
					flag = false;
				}
				z0bok.Add(c2);
			}
			else if (c2 == '"' || c2 == '\'')
			{
				if (c2 == c)
				{
					list.Add(z0bok.z0eek());
					z0bok.Clear();
					c = '\0';
					continue;
				}
				if (z0bok.Count > 0)
				{
					list.Add(z0bok.z0eek());
					z0bok.Clear();
				}
				c = c2;
			}
			else if (char.IsWhiteSpace(c2) && c == '\0')
			{
				if (z0bok.Count > 0)
				{
					list.Add(z0bok.z0eek());
					z0bok.Clear();
				}
			}
			else
			{
				z0bok.Add(c2);
				if (c2 == '(')
				{
					flag = true;
				}
			}
		}
		if (z0bok.Count > 0)
		{
			list.Add(z0bok.z0eek());
		}
		return list.ToArray();
	}

	public static void z0eek(XTextDocument p0, TextReader p1)
	{
		string p2 = p1.ReadToEnd();
		p1.Close();
		string p3 = z0ZzZzroj.z0jrk(p2);
		z0ZzZzsjh obj = new z0ZzZzsjh();
		obj.z0eek(p0, p3);
		obj.Dispose();
	}

	private static string z0yek(string p0)
	{
		if (p0 != null)
		{
			int num = p0.IndexOf("url(", StringComparison.CurrentCultureIgnoreCase);
			if (num >= 0)
			{
				p0 = p0.Substring(4);
				num = p0.IndexOf(')');
				if (num >= 0)
				{
					p0 = p0.Substring(0, num).Trim();
				}
				return p0;
			}
		}
		return null;
	}

	private void z0eek(XTextTableElement p0)
	{
		XTextDocument xTextDocument = p0.z0jr();
		XTextTableRowElement xTextTableRowElement = null;
		using (zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = p0.z0stk().z0ltk())
		{
			while (z0bpk.MoveNext())
			{
				XTextTableRowElement xTextTableRowElement2 = (XTextTableRowElement)z0bpk.Current;
				bool flag = false;
				using (zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk2 = xTextTableRowElement2.z0rek().z0ltk())
				{
					while (z0bpk2.MoveNext())
					{
						if (((XTextTableCellElement)z0bpk2.Current).ColSpan > 1)
						{
							flag = true;
							break;
						}
					}
				}
				if (!flag)
				{
					xTextTableRowElement = xTextTableRowElement2;
					break;
				}
			}
		}
		if (xTextTableRowElement == null || p0.z0drk() != xTextTableRowElement.z0vek())
		{
			return;
		}
		using zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = xTextTableRowElement.z0rek().z0ltk();
		while (z0bpk.MoveNext())
		{
			XTextTableCellElement xTextTableCellElement = (XTextTableCellElement)z0bpk.Current;
			if (((XTextElement)xTextTableCellElement).z0pek() >= 0)
			{
				DocumentContentStyle documentContentStyle = xTextDocument.z0gnk().Styles[((XTextElement)xTextTableCellElement).z0pek()] as DocumentContentStyle;
				if (documentContentStyle.z0zek > 0f)
				{
					int index = xTextTableRowElement.z0rek().IndexOf(xTextTableCellElement);
					(p0.z0srk()[index] as XTextTableColumnElement).Width = documentContentStyle.z0zek;
				}
			}
		}
	}

	public void z0eek(XTextDocument p0, string p1)
	{
		z0pek = p0;
		JsonDocument jsonDocument = JsonDocument.Parse(p1);
		if (jsonDocument != null)
		{
			JsonElement.ObjectEnumerator objectEnumerator = jsonDocument.RootElement.EnumerateObject();
			p0.z0duk();
			p0.z0gnk().Styles.Clear();
			while (objectEnumerator.MoveNext())
			{
				if (!(objectEnumerator.Current.Name == "Styles"))
				{
					continue;
				}
				z0mek = new List<int>();
				if (objectEnumerator.Current.Value.ValueKind != JsonValueKind.Array)
				{
					break;
				}
				JsonElement.ArrayEnumerator arrayEnumerator = objectEnumerator.Current.Value.EnumerateArray();
				while (arrayEnumerator.MoveNext())
				{
					if (arrayEnumerator.Current.ValueKind != JsonValueKind.Object)
					{
						continue;
					}
					DocumentContentStyle documentContentStyle = new DocumentContentStyle();
					JsonElement.ObjectEnumerator objectEnumerator2 = arrayEnumerator.Current.EnumerateObject();
					while (objectEnumerator2.MoveNext())
					{
						string name = objectEnumerator2.Current.Name;
						string text = objectEnumerator2.Current.Value.z0yek();
						if (name != null && name.Length > 0 && text != null && text.Length > 0)
						{
							z0eek(documentContentStyle, name, text);
						}
					}
					objectEnumerator2.Dispose();
					p0.z0gnk().Styles.Add(documentContentStyle);
				}
				arrayEnumerator.Dispose();
				break;
			}
			objectEnumerator.Reset();
			while (objectEnumerator.MoveNext())
			{
				if (objectEnumerator.Current.Name == "childNodes")
				{
					z0pek.z0xyk().z0be().Clear();
					z0eek(z0pek.z0xyk(), objectEnumerator.Current.Value, -1);
					break;
				}
			}
			z0pek.z0li();
		}
		jsonDocument.Dispose();
	}

	private bool z0eek(string p0, out float p1)
	{
		if (p0 == null || p0.Length == 0)
		{
			p1 = 0f;
			return false;
		}
		if (z0oek.TryGetValue(p0, out p1))
		{
			return true;
		}
		if (z0eek(p0[0]))
		{
			double num = z0ZzZzrpk.z0eek(p0, GraphicsUnit.Document, z0ZzZzbok.z0rek);
			if (!z0ZzZzbok.z0eek(num))
			{
				p1 = (float)num;
				z0oek[p0] = p1;
				return true;
			}
		}
		p1 = 0f;
		p0 = p0.Trim();
		if (p0.Length == 0)
		{
			return false;
		}
		if (z0eek(p0[0]))
		{
			double num2 = z0ZzZzrpk.z0eek(p0, GraphicsUnit.Document, z0ZzZzbok.z0rek);
			if (!z0ZzZzbok.z0eek(num2))
			{
				p1 = (float)num2;
				z0oek[p0] = p1;
				return true;
			}
		}
		return false;
	}

	private void z0eek(string p0, ref float p1, ref DashStyle p2, ref Color p3)
	{
		if (p0 == null || p0.Length <= 0)
		{
			return;
		}
		if (string.Equals(p0, "none", StringComparison.OrdinalIgnoreCase))
		{
			p1 = 0f;
			p2 = DashStyle.Solid;
			p3 = Color.Black;
			return;
		}
		string[] array = z0tek(p0);
		bool flag = false;
		bool flag2 = false;
		bool flag3 = false;
		if (array == null)
		{
			return;
		}
		string[] array2 = array;
		foreach (string p4 in array2)
		{
			if (!flag && z0rek(p4, ref p1))
			{
				flag = true;
			}
			else if (!flag2 && z0eek(p4, out p2))
			{
				if (p2 == DashStyle.Custom)
				{
					p2 = DashStyle.Solid;
					p1 = 0f;
					break;
				}
				flag2 = true;
			}
			else if (!flag3 && z0eek(p4, out p3))
			{
				flag3 = true;
			}
			if (flag3 && flag2 && flag3)
			{
				break;
			}
		}
	}

	private static bool z0rek(string p0, ref float p1)
	{
		if (p0 == null || p0.Length == 0)
		{
			return false;
		}
		if (string.Equals(p0, "1px", StringComparison.OrdinalIgnoreCase))
		{
			p1 = 1f;
			return true;
		}
		p0 = p0.Trim().ToLower();
		switch (p0)
		{
		case "medium":
		case "thin":
			p1 = 1f;
			return true;
		case "thick":
			p1 = 2f;
			return true;
		default:
			p1 = z0eek(p0, 1f);
			return true;
		}
	}

	private static bool z0eek(string p0, out Color p1)
	{
		return z0ZzZzifh.z0eek(p0, out p1);
	}

	private string z0uek(string p0)
	{
		if (p0 != null && p0.Length > 0)
		{
			p0 = p0.Trim();
			if (p0.Length > 2)
			{
				if (p0[0] == '"' && p0[p0.Length - 1] == '"')
				{
					p0 = p0.Substring(1, p0.Length - 2);
				}
				if (p0[0] == '\'' && p0[p0.Length - 1] == '\'')
				{
					p0 = p0.Substring(1, p0.Length - 2);
				}
				p0 = p0.Trim();
			}
			if (p0.Length > 0)
			{
				return p0;
			}
			return null;
		}
		return null;
	}

	private static bool z0eek(char p0)
	{
		if ((p0 < '0' || p0 > '9') && p0 != '.')
		{
			return p0 == '-';
		}
		return true;
	}

	private float[] z0iek(string p0)
	{
		List<float> list = new List<float>();
		string[] array = z0tek(p0);
		if (array != null)
		{
			string[] array2 = array;
			for (int i = 0; i < array2.Length; i++)
			{
				double num = z0ZzZzrpk.z0eek(array2[i], GraphicsUnit.Document, z0ZzZzbok.z0rek);
				if (!z0ZzZzbok.z0eek(num))
				{
					list.Add((float)num);
				}
			}
		}
		return list.ToArray();
	}

	public static void z0eek(XTextDocument p0, Stream p1)
	{
		StreamReader streamReader = new StreamReader(p1, Encoding.UTF8, true);
		string p2 = streamReader.ReadToEnd();
		streamReader.Close();
		string p3 = z0ZzZzroj.z0jrk(p2);
		z0ZzZzsjh obj = new z0ZzZzsjh();
		obj.z0eek(p0, p3);
		obj.Dispose();
	}

	private void z0rek(XTextTableElement p0)
	{
		XTextElementList xTextElementList = p0.z0stk();
		int num = 0;
		for (int i = 0; i < xTextElementList.Count; i++)
		{
			XTextTableRowElement xTextTableRowElement = xTextElementList[i] as XTextTableRowElement;
			num = Math.Max(num, xTextTableRowElement.z0rek().Count);
			foreach (XTextTableCellElement item in xTextTableRowElement.z0rek().z0xrk())
			{
				if (item.RowSpan <= 1)
				{
					continue;
				}
				int index = xTextTableRowElement.z0rek().IndexOf(item);
				for (int j = 1; j < item.RowSpan; j++)
				{
					XTextTableRowElement xTextTableRowElement2 = xTextElementList[i + j] as XTextTableRowElement;
					if (xTextTableRowElement2.z0vek() < num)
					{
						XTextTableCellElement element = p0.z0urk();
						xTextTableRowElement2.z0rek().Insert(index, element);
					}
				}
			}
		}
		XTextElementList xTextElementList2 = p0.z0srk();
		for (int k = xTextElementList2.Count; k < num; k++)
		{
			XTextTableColumnElement xTextTableColumnElement = p0.z0vek();
			xTextTableColumnElement.Width = 0f;
			xTextElementList2.Add(xTextTableColumnElement);
		}
		if (xTextElementList2.Count != num)
		{
			for (int l = xTextElementList2.Count; l < num; l++)
			{
				XTextTableColumnElement xTextTableColumnElement2 = p0.z0vek();
				xTextElementList2.Add(xTextTableColumnElement2);
				xTextTableColumnElement2.Width = 0f;
			}
		}
		int count = xTextElementList2.Count;
		for (int m = 0; m < count; m++)
		{
			XTextTableColumnElement xTextTableColumnElement3 = (XTextTableColumnElement)xTextElementList2[m];
			foreach (XTextTableRowElement item2 in xTextElementList.z0xrk())
			{
				if (m < item2.z0rek().Count)
				{
					XTextElement xTextElement = item2.z0rek()[m];
					if (xTextElement.z0fik > 0f && xTextTableColumnElement3.Width < xTextElement.z0fik)
					{
						xTextTableColumnElement3.Width = xTextElement.Width;
					}
				}
			}
		}
	}

	private void z0eek(XTextContainerElement p0, JsonElement p1, int p2)
	{
		if (p1.ValueKind != JsonValueKind.Array)
		{
			return;
		}
		JsonElement.ArrayEnumerator arrayEnumerator = p1.EnumerateArray();
		while (arrayEnumerator.MoveNext())
		{
			JsonElement current = arrayEnumerator.Current;
			if (current.ValueKind != JsonValueKind.Object)
			{
				continue;
			}
			string text = null;
			JsonElement.ObjectEnumerator objectEnumerator = current.EnumerateObject();
			int num = -1;
			while (objectEnumerator.MoveNext())
			{
				if (objectEnumerator.Current.Name == "nodeName")
				{
					text = objectEnumerator.Current.Value.z0yek();
					if (num >= 0)
					{
						break;
					}
				}
				else if (objectEnumerator.Current.Name == "StyleIndex")
				{
					num = objectEnumerator.Current.Value.z0yek(-1);
					if (text != null)
					{
						break;
					}
				}
			}
			if (num < 0)
			{
				num = p2;
			}
			objectEnumerator.Dispose();
			if (text != null)
			{
				z0eek(p0, text, current, num);
			}
		}
		arrayEnumerator.Dispose();
	}

	public void Dispose()
	{
		z0pek = null;
	}
}
