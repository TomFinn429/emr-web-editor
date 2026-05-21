using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using DCSoft.Chart;
using DCSoft.Common;
using DCSoft.Data;
using DCSoft.Drawing;
using DCSoft.Printing;
using DCSoft.WASM;
using DCSoft.Writer;
using DCSoft.Writer.Commands;
using DCSoft.Writer.Data;
using DCSoft.Writer.Dom;
using DCSoft.Writer.MedicalExpression;
using DCSystem_Drawing;
using DCSystem_Drawing.Drawing2D;
using Microsoft.JSInterop;

namespace zzz;

public static class z0ZzZzboj
{
	private class z0vck : JsonNamingPolicy
	{
		public override string ConvertName(string name)
		{
			return name;
		}
	}

	private class z0jck : JsonConverter<byte[]>
	{
		public override byte[] Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			byte[] result = null;
			if (reader.TryGetBytesFromBase64(out result))
			{
				return result;
			}
			return null;
		}

		public override void Write(Utf8JsonWriter writer, byte[] value, JsonSerializerOptions options)
		{
			if (value == null || value.Length == 0)
			{
				writer.WriteNullValue();
			}
			else
			{
				writer.WriteBase64StringValue(value);
			}
		}
	}

	private class z0fck : JsonConverter<Color>
	{
		public override Color Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			string text = reader.GetString();
			if (text == null || text.Length == 0)
			{
				return Color.Empty;
			}
			return z0ZzZzlok.z0eek(text, Color.Empty);
		}

		public override void Write(Utf8JsonWriter writer, Color value, JsonSerializerOptions options)
		{
			if (value.A != 255)
			{
				writer.WriteStringValue(z0ZzZzlok.z0eek(value));
			}
			else
			{
				writer.WriteStringValue(z0ZzZzifh.z0eek(value));
			}
		}
	}

	private class z0wck : JsonConverter<DateTime>
	{
		public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			string text = reader.GetString();
			if (text == null)
			{
				return DateTime.MinValue;
			}
			return DateTime.Parse(text);
		}

		public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
		{
			writer.WriteStringValue(z0ZzZzuyk.z0rek(value));
		}
	}

	public static readonly JsonSerializerOptions z0lrk;

	private static readonly List<int> z0krk;

	private static void z0rek(XTextLabelElementBase p0, JsonElement p1, XTextElementList p2)
	{
		string text = null;
		bool flag = false;
		JsonElement p3;
		if (p1.ValueKind == JsonValueKind.String)
		{
			text = p1.GetString();
			flag = true;
		}
		else if (p1.ValueKind == JsonValueKind.Object && p1.TryGetProperty(p0.ValueBinding.BindingPath, out p3))
		{
			text = z0xek(p3);
			flag = true;
		}
		if (flag)
		{
			p0.Text = text;
			p2.Add(p0);
		}
	}

	public static JsonObject z0rek(z0ZzZzvgh p0)
	{
		if (p0 == null)
		{
			return null;
		}
		p0.z0pek();
		JsonObject jsonObject = new JsonObject();
		jsonObject.Add("UserID", p0.z0rek());
		jsonObject.Add("UserName", p0.z0mek());
		jsonObject.Add("SaveTime", p0.z0eek());
		jsonObject.Add("InfoType", p0.z0pek().ToString());
		jsonObject.Add("PermissionLevel", p0.z0yek());
		jsonObject.Add("CommentText", p0.z0uek());
		jsonObject.Add("Text", p0.z0iek());
		jsonObject.Add("StdTitle", p0.z0oek());
		jsonObject.Add("Tag", p0.z0tek());
		jsonObject.Add("Description", p0.z0vek());
		if (p0.z0bek() != null && p0.z0bek().Length > 0)
		{
			jsonObject.Add("ClientName", p0.z0bek());
		}
		return jsonObject;
	}

	public static JumpPrintInfo z0rek(JsonElement p0)
	{
		if (p0.ValueKind != JsonValueKind.Object)
		{
			return null;
		}
		JumpPrintInfo jumpPrintInfo = new JumpPrintInfo();
		bool flag = false;
		foreach (JsonProperty item in p0.EnumerateObject())
		{
			float num = 0f;
			int num2 = -2147483648;
			string text = z0xek(item.Value);
			switch (item.Name.ToLower())
			{
			case "enabled":
				jumpPrintInfo.Enabled = item.z0yek(p1: false);
				flag = true;
				break;
			case "mode":
				jumpPrintInfo.Mode = item.z0rek(JumpPrintMode.Normal);
				flag = true;
				break;
			case "pageindex":
				if (int.TryParse(text, out num2))
				{
					jumpPrintInfo.PageIndex = num2;
					flag = true;
				}
				break;
			case "position":
				if (float.TryParse(item.z0uek(), out num))
				{
					jumpPrintInfo.Position = num;
					flag = true;
				}
				break;
			case "endpageindex":
				if (int.TryParse(text, out num2))
				{
					jumpPrintInfo.EndPageIndex = num2;
					flag = true;
				}
				break;
			case "endposition":
				if (float.TryParse(item.z0uek(), out num))
				{
					jumpPrintInfo.EndPosition = num;
					flag = true;
				}
				flag = true;
				break;
			}
		}
		if (flag)
		{
			return jumpPrintInfo;
		}
		return null;
	}

	public static PageLabelTextList z0tek(JsonElement p0)
	{
		PageLabelTextList pageLabelTextList = new PageLabelTextList();
		if (p0.ValueKind == JsonValueKind.Array)
		{
			foreach (JsonElement item in p0.EnumerateArray())
			{
				if (item.ValueKind == JsonValueKind.Object)
				{
					JsonElement property = item.GetProperty("PageIndex");
					JsonElement property2 = item.GetProperty("PageIndexText");
					if (property.ValueKind == JsonValueKind.Number && property2.ValueKind == JsonValueKind.String)
					{
						PageLabelText pageLabelText = new PageLabelText();
						pageLabelText.PageIndex = property.GetInt32();
						pageLabelText.Text = property2.GetString();
						pageLabelTextList.Add(pageLabelText);
					}
				}
			}
		}
		if (pageLabelTextList.Count > 0)
		{
			return pageLabelTextList;
		}
		return null;
	}

	public static DCContentLockInfo z0yek(JsonElement p0)
	{
		DCContentLockInfo dCContentLockInfo = new DCContentLockInfo();
		bool flag = false;
		if (p0.ValueKind != JsonValueKind.Object)
		{
			return null;
		}
		foreach (JsonProperty item in p0.EnumerateObject())
		{
			string text = item.Name.ToLower();
			string text2 = z0xek(item.Value);
			DateTime result = DateTime.MinValue;
			switch (text)
			{
			case "owneruserid":
				dCContentLockInfo.OwnerUserID = text2;
				flag = true;
				break;
			case "creationtime":
				if (DateTime.TryParse(text2, out result))
				{
					dCContentLockInfo.CreationTime = result;
					flag = true;
				}
				break;
			case "authoriseduseridlist":
				dCContentLockInfo.AuthorisedUserIDList = text2;
				flag = true;
				break;
			}
		}
		if (flag)
		{
			return dCContentLockInfo;
		}
		return null;
	}

	public static void z0rek(JsonElement p0, z0ZzZzimk p1, float p2)
	{
		foreach (JsonProperty item in p0.EnumerateObject())
		{
			string text = item.Name.ToLower();
			string text2 = z0xek(item.Value);
			switch (text)
			{
			case "fontfamily":
				p1.Name = text2;
				break;
			case "fontsize":
				p1.Size = z0ZzZzdpj.z0eek(text2, p2);
				break;
			case "bold":
				p1.Bold = item.z0yek(p1: false);
				break;
			case "italic":
				p1.Italic = item.z0yek(p1: false);
				break;
			case "underline":
				p1.Underline = item.z0yek(p1: false);
				break;
			case "strikeout":
				p1.Strikeout = item.z0yek(p1: false);
				break;
			}
		}
	}

	public static JsonObject z0rek(XTextSubDocumentElement p0)
	{
		if (p0 == null)
		{
			return null;
		}
		if (((XTextElement)p0).z0xrk() == null)
		{
			p0.z0yek(new DocumentContentStyle());
		}
		return new JsonObject
		{
			{
				"BackgroundColor",
				z0ZzZzifh.z0eek(((XTextElement)p0).z0xrk().BackgroundColor)
			},
			{
				"Attributes",
				z0rek(p0.Attributes)
			},
			{ "EnableCollapse", p0.EnableCollapse },
			{ "NewPage", p0.NewPage },
			{
				"ContentReadonly",
				p0.ContentReadonly.ToString()
			},
			{ "Title", p0.Title },
			{ "ToolTip", p0.ToolTip },
			{
				"IsLogicDeleted",
				p0.z0wtk()
			},
			{ "ID", p0.ID },
			{
				"TitleLevel",
				((XTextElement)p0).z0xrk().TitleLevel
			},
			{
				"EnablePermission",
				p0.EnablePermission.ToString()
			},
			{
				"BorderWidth",
				((XTextElement)p0).z0xrk().BorderWidth
			},
			{
				"BorderTop",
				((XTextElement)p0).z0xrk().BorderTop
			},
			{
				"BorderTopColor",
				z0ZzZzifh.z0eek(((XTextElement)p0).z0xrk().BorderTopColor)
			},
			{
				"BorderLeft",
				((XTextElement)p0).z0xrk().BorderLeft
			},
			{
				"BorderLeftColor",
				z0ZzZzifh.z0eek(((XTextElement)p0).z0xrk().BorderLeftColor)
			},
			{
				"BorderRight",
				((XTextElement)p0).z0xrk().BorderRight
			},
			{
				"BorderRightColor",
				z0ZzZzifh.z0eek(((XTextElement)p0).z0xrk().BorderRightColor)
			},
			{
				"BorderBottom",
				((XTextElement)p0).z0xrk().BorderBottom
			},
			{
				"BorderBottomColor",
				z0ZzZzifh.z0eek(((XTextElement)p0).z0xrk().BorderBottomColor)
			}
		};
	}

	public static bool z0rek(object p0, bool p1)
	{
		bool result = p1;
		if (p0 == null)
		{
			return p1;
		}
		if (p0 is string && bool.TryParse((string)p0, out result))
		{
			return result;
		}
		if (p0 is JsonElement jsonElement)
		{
			if (jsonElement.ValueKind == JsonValueKind.True || (jsonElement.ValueKind == JsonValueKind.String && jsonElement.GetString().ToLower() == "true"))
			{
				return true;
			}
			if (jsonElement.ValueKind == JsonValueKind.False || (jsonElement.ValueKind == JsonValueKind.String && jsonElement.GetString().ToLower() == "false"))
			{
				return false;
			}
		}
		return result;
	}

	public static DCPieDataItemList z0uek(JsonElement p0)
	{
		DCPieDataItemList dCPieDataItemList = new DCPieDataItemList();
		if (p0.ValueKind != JsonValueKind.Array)
		{
			return null;
		}
		foreach (JsonElement item in p0.EnumerateArray())
		{
			if (item.ValueKind != JsonValueKind.Object)
			{
				continue;
			}
			string text = null;
			double num = 0.0 / 0.0;
			string colorValue = null;
			foreach (JsonProperty item2 in item.EnumerateObject())
			{
				string text2 = item2.Name.ToLower();
				string text3 = z0xek(item2.Value);
				switch (text2)
				{
				case "text":
					if (item2.Value.ValueKind == JsonValueKind.String)
					{
						text = text3;
					}
					break;
				case "value":
					if (!double.TryParse(text3, out num))
					{
						num = 0.0 / 0.0;
					}
					break;
				case "color":
					if (item2.Value.ValueKind == JsonValueKind.String)
					{
						colorValue = text3;
					}
					break;
				}
			}
			if (text != null && text.Length > 0 && num != -2147483648.0)
			{
				DCPieDataItem dCPieDataItem = new DCPieDataItem();
				dCPieDataItem.Text = text;
				dCPieDataItem.Value = num;
				dCPieDataItem.ColorValue = colorValue;
				dCPieDataItemList.Add(dCPieDataItem);
			}
		}
		if (dCPieDataItemList.Count > 0)
		{
			return dCPieDataItemList;
		}
		return null;
	}

	public static JsonNode z0rek(DocumentContentStyle p0)
	{
		if (p0 == null)
		{
			return null;
		}
		return new JsonObject
		{
			{ "TitleLevel", p0.TitleLevel },
			{ "Bold", p0.Bold },
			{
				"ColorString",
				z0rek(p0.Color)
			},
			{
				"PrintColorString",
				z0rek(p0.PrintColor)
			},
			{
				"PrintBackColorString",
				z0rek(p0.PrintBackColor)
			},
			{
				"VerticalAlign",
				p0.VerticalAlign.ToString()
			},
			{
				"Align",
				p0.Align.ToString()
			},
			{ "BorderTop", p0.BorderTop },
			{ "BorderRight", p0.BorderRight },
			{ "BorderLeft", p0.BorderLeft },
			{ "BorderBottom", p0.BorderBottom },
			{
				"BorderBottomColorString",
				z0rek(p0.BorderBottomColor)
			},
			{
				"BorderRightColorString",
				z0rek(p0.BorderRightColor)
			},
			{
				"BorderLeftColorString",
				z0rek(p0.BorderLeftColor)
			},
			{
				"BorderTopColorString",
				z0rek(p0.BorderTopColor)
			},
			{
				"BorderStyle",
				p0.BorderStyle.ToString()
			},
			{ "BorderWidth", p0.BorderWidth },
			{
				"BorderSpacing",
				float.IsNaN(p0.BorderSpacing) ? 0f : p0.BorderSpacing
			},
			{ "PaddingBottom", p0.PaddingBottom },
			{ "PaddingLeft", p0.PaddingLeft },
			{ "PaddingRight", p0.PaddingRight },
			{ "PaddingTop", p0.PaddingTop },
			{
				"BackgroundColorString",
				z0rek(p0.BackgroundColor)
			},
			{ "LineSpacing", p0.LineSpacing },
			{ "LeftIndent", p0.LeftIndent },
			{
				"LineSpacingStyle",
				p0.LineSpacingStyle.ToString()
			},
			{ "SpacingAfterParagraph", p0.SpacingAfterParagraph },
			{ "SpacingBeforeParagraph", p0.SpacingBeforeParagraph },
			{ "FirstLineIndent", p0.FirstLineIndent },
			{ "ParagraphOutlineLevel", p0.ParagraphOutlineLevel },
			{ "ParagraphMultiLevel", p0.ParagraphMultiLevel },
			{
				"ParagraphListStyle",
				p0.ParagraphListStyle.ToString()
			},
			{
				"FontStyle",
				p0.FontStyle.ToString()
			},
			{
				"FontHeight",
				p0.z0iek()
			},
			{ "FontName", p0.FontName },
			{ "FontSize", p0.FontSize },
			{
				"LayoutAlign",
				p0.LayoutAlign.ToString()
			},
			{
				"CharacterCircle",
				p0.CharacterCircle.ToString()
			},
			{ "Underline", p0.Underline },
			{ "Italic", p0.Italic },
			{ "Strikeout", p0.Strikeout },
			{ "CreatorIndex", p0.CreatorIndex },
			{ "DeleterIndex", p0.DeleterIndex },
			{ "CommentIndex", p0.CommentIndex },
			{ "Index", p0.Index },
			{ "UnderlineColor", p0.UnderlineColor },
			{
				"UnderlineStyle",
				p0.UnderlineStyle.ToString()
			}
		};
	}

	public static JsonNode z0rek(z0ZzZzzlh p0)
	{
		if (p0 == null)
		{
			return null;
		}
		JsonObject obj = new JsonObject
		{
			{
				"Bottom",
				p0.z0ark()
			},
			{
				"AbsBottom",
				p0.z0lrk()
			},
			{
				"AbsTop",
				p0.z0xrk()
			},
			{
				"Top",
				p0.z0zrk()
			},
			{
				"GlobalIndex",
				p0.z0hrk()
			},
			{
				"Height",
				p0.z0ytk()
			},
			{
				"IndexInPage",
				p0.z0otk()
			},
			{
				"IsCharOrParagraphFlagOnly",
				p0.z0rrk()
			},
			{
				"IsTableOrSectionOrPageBreakLine",
				p0.z0xek()
			}
		};
		int num = -1;
		if (p0.z0dtk() != null)
		{
			num = p0.z0dtk().z0brk();
		}
		else if (((XTextElementList)p0).z0krk() != null)
		{
			num = ((XTextElementList)p0).z0krk().z0je();
		}
		obj.Add("OwnerPageIndex", num);
		return obj;
	}

	public static string z0iek(JsonElement p0)
	{
		StringWriter stringWriter = new StringWriter();
		z0ZzZzhqh z0ZzZzhqh2 = new z0ZzZzhqh(stringWriter);
		if (p0.ValueKind == JsonValueKind.Object)
		{
			z0ZzZzhqh2.z0eek("a");
			foreach (JsonProperty item in p0.EnumerateObject())
			{
				string text = z0xek(item.Value);
				if (text != null)
				{
					z0ZzZzhqh2.z0eek(item.Name);
					z0ZzZzhqh2.z0yg(text);
					z0ZzZzhqh2.z0bg();
				}
				else
				{
					if (item.Value.ValueKind != JsonValueKind.Array)
					{
						continue;
					}
					foreach (JsonElement item2 in item.Value.EnumerateArray())
					{
						z0ZzZzhqh2.z0eek(item.Name);
						foreach (JsonProperty item3 in item2.EnumerateObject())
						{
							string text2 = z0xek(item3.Value);
							if (text2 != null)
							{
								z0ZzZzhqh2.z0eek(item3.Name);
								z0ZzZzhqh2.z0yg(text2);
								z0ZzZzhqh2.z0bg();
							}
						}
						z0ZzZzhqh2.z0bg();
					}
				}
			}
			z0ZzZzhqh2.z0mg();
			return stringWriter.ToString();
		}
		if (p0.ValueKind == JsonValueKind.Array)
		{
			z0ZzZzhqh2.z0eek("NewDataSet");
			foreach (JsonElement item4 in p0.EnumerateArray())
			{
				z0ZzZzhqh2.z0eek("DataTable");
				foreach (JsonProperty item5 in item4.EnumerateObject())
				{
					string text3 = z0xek(item5.Value);
					if (text3 != null)
					{
						z0ZzZzhqh2.z0eek(item5.Name);
						z0ZzZzhqh2.z0yg(text3);
						z0ZzZzhqh2.z0bg();
					}
				}
				z0ZzZzhqh2.z0bg();
			}
			z0ZzZzhqh2.z0mg();
			string result = stringWriter.ToString();
			z0ZzZzhqh2.z0kf();
			return result;
		}
		return null;
	}

	public static z0ZzZzfah z0oek(JsonElement p0)
	{
		z0ZzZzfah z0ZzZzfah2 = new z0ZzZzfah();
		if (p0.ValueKind == JsonValueKind.Object)
		{
			z0ZzZzoah p1 = z0ZzZzfah2.z0rek("a");
			z0ZzZzfah2.z0if(p1);
			p1 = ((z0ZzZzoah)z0ZzZzfah2).z0iek();
			z0ZzZzysh z0ZzZzysh2 = new z0ZzZzysh();
			foreach (JsonProperty item in p0.EnumerateObject())
			{
				string p2 = z0ZzZzysh2.z0nf(item.Name);
				string text = z0xek(item.Value);
				if (text != null)
				{
					z0ZzZzoah z0ZzZzoah2 = z0ZzZzfah2.z0rek(p2);
					z0ZzZzoah2.z0rg(z0ZzZzysh2.z0nf(text));
					p1.z0if(z0ZzZzoah2);
				}
				else
				{
					if (item.Value.ValueKind != JsonValueKind.Array)
					{
						continue;
					}
					foreach (JsonElement item2 in item.Value.EnumerateArray())
					{
						if (item2.ValueKind != JsonValueKind.Object)
						{
							continue;
						}
						z0ZzZzoah z0ZzZzoah3 = z0ZzZzfah2.z0rek(p2);
						foreach (JsonProperty item3 in item2.EnumerateObject())
						{
							string text2 = z0xek(item3.Value);
							if (text2 != null)
							{
								z0ZzZzoah z0ZzZzoah4 = z0ZzZzfah2.z0rek(item.Name);
								z0ZzZzoah4.z0rg(text2);
								z0ZzZzoah3.z0if(z0ZzZzoah4);
							}
						}
						p1.z0if(z0ZzZzoah3);
					}
				}
			}
			z0ZzZzysh2.z0rek();
			z0ZzZzysh2 = null;
			return z0ZzZzfah2;
		}
		if (p0.ValueKind == JsonValueKind.Array)
		{
			z0ZzZzoah z0ZzZzoah5 = z0ZzZzfah2.z0rek("NewDataSet");
			z0ZzZzysh z0ZzZzysh3 = new z0ZzZzysh();
			foreach (JsonElement item4 in p0.EnumerateArray())
			{
				z0ZzZzoah z0ZzZzoah6 = z0ZzZzfah2.z0rek("DataTable");
				foreach (JsonProperty item5 in item4.EnumerateObject())
				{
					string text3 = z0ZzZzysh3.z0nf(z0xek(item5.Value));
					if (text3 != null)
					{
						z0ZzZzoah z0ZzZzoah7 = z0ZzZzfah2.z0rek(z0ZzZzysh3.z0nf(item5.Name));
						z0ZzZzoah7.z0rg(text3);
						z0ZzZzoah6.z0if(z0ZzZzoah7);
					}
				}
				z0ZzZzoah5.z0if(z0ZzZzoah6);
			}
			z0ZzZzysh3.z0rek();
			z0ZzZzysh3 = null;
			z0ZzZzfah2.z0if(z0ZzZzoah5);
			return z0ZzZzfah2;
		}
		return null;
	}

	public static ValueValidateStyle z0rek(JsonElement p0, ValueValidateStyle p1)
	{
		ValueValidateStyle valueValidateStyle = ((p1 != null) ? p1 : new ValueValidateStyle());
		if (p1 == null)
		{
			valueValidateStyle.DateTimeMinValue = DateTime.MinValue;
			valueValidateStyle.DateTimeMaxValue = DateTime.MinValue;
		}
		if (p0.ValueKind == JsonValueKind.String)
		{
			valueValidateStyle.DCReadString(p0.GetString());
			return valueValidateStyle;
		}
		if (p0.ValueKind == JsonValueKind.Null)
		{
			return null;
		}
		if (p0.ValueKind != JsonValueKind.Object)
		{
			return null;
		}
		foreach (JsonProperty item in p0.EnumerateObject())
		{
			string text = item.Name.ToLower();
			string text2 = z0xek(item.Value);
			double num = 0.0 / 0.0;
			int num2 = -2147483648;
			DateTime result = DateTime.MinValue;
			switch (text)
			{
			case "valuetype":
				valueValidateStyle.ValueType = item.z0rek(ValueTypeStyle.Text);
				break;
			case "maxdecimaldigits":
				if (int.TryParse(text2, out num2))
				{
					valueValidateStyle.MaxDecimalDigits = num2;
				}
				break;
			case "maxlength":
				if (int.TryParse(text2, out num2))
				{
					valueValidateStyle.MaxLength = num2;
				}
				break;
			case "minlength":
				if (int.TryParse(text2, out num2))
				{
					valueValidateStyle.MinLength = num2;
				}
				break;
			case "maxvalue":
				if (double.TryParse(text2, out num))
				{
					valueValidateStyle.MaxValue = num;
				}
				break;
			case "minvalue":
				if (double.TryParse(text2, out num))
				{
					valueValidateStyle.MinValue = num;
				}
				break;
			case "checkdecimaldigits":
				valueValidateStyle.CheckDecimalDigits = item.z0yek(valueValidateStyle.CheckDecimalDigits);
				break;
			case "checkmaxvalue":
				valueValidateStyle.CheckMaxValue = item.z0yek(valueValidateStyle.CheckMaxValue);
				break;
			case "checkminvalue":
				valueValidateStyle.CheckMinValue = item.z0yek(valueValidateStyle.CheckMinValue);
				break;
			case "required":
				valueValidateStyle.Required = item.z0yek(valueValidateStyle.Required);
				break;
			case "datetimemaxvalue":
				if (DateTime.TryParse(text2, out result))
				{
					valueValidateStyle.DateTimeMaxValue = result;
				}
				break;
			case "datetimeminvalue":
				if (DateTime.TryParse(text2, out result))
				{
					valueValidateStyle.DateTimeMinValue = result;
				}
				break;
			case "binarylength":
				valueValidateStyle.BinaryLength = item.z0yek(valueValidateStyle.BinaryLength);
				break;
			case "excludekeywords":
				valueValidateStyle.ExcludeKeywords = text2;
				break;
			case "includekeywords":
				valueValidateStyle.IncludeKeywords = text2;
				break;
			case "regexpression":
				valueValidateStyle.RegExpression = text2;
				break;
			case "range":
				valueValidateStyle.Range = text2;
				break;
			case "valuename":
				valueValidateStyle.ValueName = text2;
				break;
			case "requiredinvalidateflag":
				valueValidateStyle.RequiredInvalidateFlag = item.z0yek(p1: false);
				break;
			case "custommessage":
				valueValidateStyle.CustomMessage = text2;
				break;
			case "message":
				valueValidateStyle.Message = text2;
				break;
			case "level":
				valueValidateStyle.Level = item.z0rek(ValueValidateLevel.Info);
				break;
			}
		}
		return valueValidateStyle;
	}

	public static void z0rek(JsonElement p0, XTextChartElement p1)
	{
		p1.z0eek(new z0ZzZzqtk());
		p1.z0tek().z0eek(new z0ZzZzptk());
		if (p0.ValueKind != JsonValueKind.Object)
		{
			return;
		}
		foreach (JsonProperty item in p0.EnumerateObject())
		{
			string text = item.Name.ToLower();
			string text2 = z0xek(item.Value);
			int p2 = -2147483648;
			switch (text)
			{
			case "legendvisible":
				p1.z0tek().z0erk().z0rek(item.z0yek(p1: true));
				break;
			case "gridysplitnum":
				if (int.TryParse(text2, out p2))
				{
					p1.z0tek().z0rek(p2);
				}
				break;
			case "paddingtop":
				if (int.TryParse(text2, out p2))
				{
					p1.z0tek().z0vek(p2);
				}
				break;
			case "paddingbottom":
				if (int.TryParse(text2, out p2))
				{
					p1.z0tek().z0pek(p2);
				}
				break;
			case "paddingleft":
				if (int.TryParse(text2, out p2))
				{
					p1.z0tek().z0nek(p2);
				}
				break;
			case "paddingright":
				if (int.TryParse(text2, out p2))
				{
					p1.z0tek().z0bek(p2);
				}
				break;
			case "viewstyle":
				p1.z0tek().z0eek(item.z0rek(ChartViewStyle.Line));
				break;
			case "yaxises":
				if (item.Value.ValueKind != JsonValueKind.Array)
				{
					break;
				}
				foreach (JsonElement item2 in item.Value.EnumerateArray())
				{
					if (item2.ValueKind != JsonValueKind.Object)
					{
						continue;
					}
					z0ZzZzstk z0ZzZzstk2 = new z0ZzZzstk();
					bool flag2 = false;
					foreach (JsonProperty item3 in item2.EnumerateObject())
					{
						string text5 = item3.Name.ToLower();
						string text6 = z0xek(item3.Value);
						double p3 = 0.0 / 0.0;
						switch (text5)
						{
						case "color":
							z0ZzZzstk2.z0yek(text6);
							flag2 = true;
							break;
						case "gridstep":
							if (double.TryParse(text6, out p3))
							{
								z0ZzZzstk2.z0tek(p3);
								flag2 = true;
							}
							break;
						case "leftside":
							z0ZzZzstk2.z0rek(item3.z0yek(p1: true));
							flag2 = true;
							break;
						case "maxvalue":
							if (double.TryParse(text6, out p3))
							{
								z0ZzZzstk2.z0eek(p3);
								flag2 = true;
							}
							break;
						case "minvalue":
							if (double.TryParse(text6, out p3))
							{
								z0ZzZzstk2.z0rek(p3);
								flag2 = true;
							}
							break;
						case "name":
							z0ZzZzstk2.z0eek(text6);
							flag2 = true;
							break;
						case "visible":
							z0ZzZzstk2.z0eek(item3.z0yek(p1: true));
							flag2 = true;
							break;
						}
					}
					if (flag2)
					{
						if (p1.z0tek().z0mek() == null)
						{
							p1.z0tek().z0eek(new z0ZzZzatk());
						}
						p1.z0tek().z0mek().Add(z0ZzZzstk2);
					}
				}
				break;
			case "values":
				if (item.Value.ValueKind != JsonValueKind.Array)
				{
					break;
				}
				foreach (JsonElement item4 in item.Value.EnumerateArray())
				{
					if (item4.ValueKind != JsonValueKind.Object)
					{
						continue;
					}
					DCChartDataItem dCChartDataItem = new DCChartDataItem();
					bool flag = false;
					foreach (JsonProperty item5 in item4.EnumerateObject())
					{
						string text3 = item5.Name.ToLower();
						string text4 = z0xek(item5.Value);
						double value = 0.0 / 0.0;
						switch (text3)
						{
						case "seriesname":
							dCChartDataItem.SeriesName = text4;
							flag = true;
							break;
						case "groupname":
							dCChartDataItem.GroupName = text4;
							flag = true;
							break;
						case "symboltype":
							dCChartDataItem.SymbolType = item.z0rek(ShapeTypes.Default);
							flag = true;
							break;
						case "value":
							if (double.TryParse(text4, out value))
							{
								dCChartDataItem.Value = value;
								flag = true;
							}
							break;
						}
					}
					if (flag)
					{
						if (p1.z0bek() == null)
						{
							p1.z0eek(new DCChartDataItemList());
						}
						p1.z0bek().Add(dCChartDataItem);
					}
				}
				break;
			}
		}
	}

	public static JsonObject z0rek(CopySourceInfo p0)
	{
		if (p0 == null)
		{
			return null;
		}
		return new JsonObject
		{
			{
				"DescPropertyName",
				p0.z0iek()
			},
			{
				"IgnoreChildElements",
				p0.z0yek()
			},
			{
				"SourceID",
				p0.z0tek()
			},
			{
				"SourcePropertyName",
				p0.z0eek()
			}
		};
	}

	private static void z0rek(XTextTableRowElement p0, JsonElement p1, XTextElementList p2, WriterControlForWASM p3 = null)
	{
		bool flag = false;
		if (p1.ValueKind != JsonValueKind.Array)
		{
			return;
		}
		z0ZzZzzbj z0ZzZzzbj2 = new z0ZzZzzbj();
		XTextTableElement xTextTableElement = p0.z0gr();
		xTextTableElement.z0xek(p0: true);
		z0ZzZzzbj2.z0eek(xTextTableElement);
		z0ZzZzzbj2.z0cb(xTextTableElement);
		XTextTableRowElement xTextTableRowElement = xTextTableElement.z0stk().LastElement.z0lr(p0: true) as XTextTableRowElement;
		xTextTableElement.z0stk().z0cek(xTextTableElement.z0stk().LastElement);
		XTextElementList xTextElementList = new XTextElementList();
		foreach (JsonElement item in p1.EnumerateArray())
		{
			bool flag2 = false;
			if (item.ValueKind != JsonValueKind.Object)
			{
				continue;
			}
			XTextTableRowElement xTextTableRowElement2 = xTextTableRowElement.z0lr(p0: true) as XTextTableRowElement;
			xTextTableRowElement2.z0yek(xTextTableElement.z0jr(), xTextTableElement);
			using (zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = xTextTableRowElement2.z0rek().z0ltk())
			{
				while (z0bpk.MoveNext())
				{
					XTextTableCellElement xTextTableCellElement = (XTextTableCellElement)z0bpk.Current;
					if (xTextTableCellElement.ValueBinding == null || string.IsNullOrEmpty(xTextTableCellElement.ValueBinding.BindingPath) || !item.TryGetProperty(xTextTableCellElement.ValueBinding.BindingPath, out var jsonElement))
					{
						continue;
					}
					if (p3 != null && jsonElement.ValueKind == JsonValueKind.Array)
					{
						XTextElementList xTextElementList2 = p3.z0bek(xTextTableCellElement, jsonElement, p2: false);
						if (xTextElementList2 == null || xTextElementList2.Count <= 0)
						{
							continue;
						}
						int p4 = ((XTextElement)xTextTableCellElement.z0oek<XTextParagraphFlagElement>())?.z0pek() ?? (-1);
						xTextTableCellElement.z0be().Clear();
						xTextTableCellElement.z0be().z0tek(xTextElementList2);
						XTextParagraphFlagElement xTextParagraphFlagElement = new XTextParagraphFlagElement();
						xTextParagraphFlagElement.z0oek(p4);
						xTextTableCellElement.z0be().Add(xTextParagraphFlagElement);
						using (zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk2 = xTextTableCellElement.z0nek<XTextParagraphFlagElement>().z0ltk())
						{
							while (z0bpk2.MoveNext())
							{
								z0bpk2.Current.z0oek(p4);
							}
						}
						flag2 = true;
					}
					else if (p3 != null && jsonElement.ValueKind == JsonValueKind.Object)
					{
						JsonElement rootElement = JsonSerializer.SerializeToElement(p3.z0bek(xTextTableCellElement));
						JsonElement columnBindingNewPage = JsonSerializer.SerializeToElement(false);
						p3.WriteDataFromDataSourceToDocument2(jsonElement, rootElement, columnBindingNewPage);
						flag2 = true;
					}
					else
					{
						string text = z0xek(jsonElement);
						if (text != null)
						{
							z0ZzZzzbj2.z0eek(xTextTableCellElement, text, p2: false);
							flag2 = true;
						}
					}
				}
			}
			if (flag2)
			{
				xTextElementList.Add(xTextTableRowElement2);
				flag = true;
			}
		}
		if (!flag)
		{
			z0ZzZzzbj2.z0rek(xTextTableElement);
		}
		else
		{
			bool flag3 = false;
			int num = -1;
			using (zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = xTextElementList.z0ltk())
			{
				while (z0bpk.MoveNext())
				{
					XTextTableRowElement xTextTableRowElement3 = (XTextTableRowElement)z0bpk.Current;
					int num2 = xTextElementList.IndexOf(xTextTableRowElement3);
					using zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk2 = xTextTableRowElement3.z0rek().z0ltk();
					while (z0bpk2.MoveNext())
					{
						XTextTableCellElement xTextTableCellElement2 = (XTextTableCellElement)z0bpk2.Current;
						if (xTextTableCellElement2.ValueExpression == null || xTextTableCellElement2.ValueExpression.Length == 0)
						{
							continue;
						}
						if (!flag3)
						{
							num = num2;
							flag3 = true;
							break;
						}
						if (num != -1)
						{
							XTextTableRowElement obj = xTextElementList[num] as XTextTableRowElement;
							int index = xTextTableRowElement3.z0rek().IndexOf(xTextTableCellElement2);
							if (obj.z0rek()[index] is XTextTableCellElement { ValueExpression: not null } xTextTableCellElement3 && xTextTableCellElement3.ValueExpression.Length > 0)
							{
								string text2 = (num + 1).ToString();
								string text3 = (num2 + 1).ToString();
								string valueExpression = xTextTableCellElement3.ValueExpression.Replace(text2, text3);
								xTextTableCellElement2.ValueExpression = valueExpression;
							}
						}
					}
				}
			}
			Dictionary<string, int> dictionary = new Dictionary<string, int>();
			int num3 = 1;
			using (zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = xTextElementList.z0ltk())
			{
				while (z0bpk.MoveNext())
				{
					XTextTableRowElement xTextTableRowElement4 = (XTextTableRowElement)z0bpk.Current;
					int num4 = xTextElementList.IndexOf(xTextTableRowElement4);
					using (zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk2 = xTextTableRowElement4.z0rek().z0ltk())
					{
						while (z0bpk2.MoveNext())
						{
							XTextTableCellElement xTextTableCellElement4 = (XTextTableCellElement)z0bpk2.Current;
							using (zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk3 = xTextTableCellElement4.z0rek<XTextCheckBoxElementBase>().z0ltk())
							{
								while (z0bpk3.MoveNext())
								{
									XTextCheckBoxElementBase xTextCheckBoxElementBase = (XTextCheckBoxElementBase)z0bpk3.Current;
									if (xTextCheckBoxElementBase.Name == null || xTextCheckBoxElementBase.Name.Length == 0)
									{
										continue;
									}
									int num5 = -1;
									if (dictionary.TryGetValue(xTextCheckBoxElementBase.Name, out num5))
									{
										if (num4 != num5)
										{
											xTextCheckBoxElementBase.Name += num4;
										}
									}
									else
									{
										dictionary.Add(xTextCheckBoxElementBase.Name, num4);
									}
								}
							}
							if (!xTextTableElement.z0jr().z0vtk().BehaviorOptions.AutoFixElementIDWhenInsertElements)
							{
								continue;
							}
							xTextTableElement.z0jr().z0vtk().BehaviorOptions.AutoFixElementIDWhenInsertElements = false;
							using (zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk3 = xTextTableCellElement4.z0rek<XTextInputFieldElement>().z0ltk())
							{
								while (z0bpk3.MoveNext())
								{
									z0ZzZzcoj.z0tek((XTextInputFieldElement)z0bpk3.Current, xTextTableElement.z0jr(), num3);
								}
							}
							xTextTableElement.z0jr().z0vtk().BehaviorOptions.AutoFixElementIDWhenInsertElements = true;
							if (z0ZzZzcoj.z0vek != null)
							{
								z0ZzZzcoj.z0vek.Clear();
								z0ZzZzcoj.z0vek = null;
							}
						}
					}
					num3++;
				}
			}
			xTextTableElement.z0stk().AddRange(xTextElementList);
			p2.Add(xTextTableElement);
		}
		xTextTableElement.z0pek((string)null);
	}

	public static CopySourceInfo z0pek(JsonElement p0)
	{
		CopySourceInfo copySourceInfo = new CopySourceInfo();
		bool flag = false;
		if (p0.ValueKind != JsonValueKind.Object)
		{
			return null;
		}
		foreach (JsonProperty item in p0.EnumerateObject())
		{
			string text = item.Name.ToLower();
			string p1 = z0xek(item.Value);
			switch (text)
			{
			case "descpropertyname":
				copySourceInfo.z0eek(p1);
				flag = true;
				break;
			case "ignorechildelements":
				copySourceInfo.z0eek(item.z0yek(p1: true));
				flag = true;
				break;
			case "sourceid":
				copySourceInfo.z0tek(p1);
				flag = true;
				break;
			case "sourcepropertyname":
				copySourceInfo.z0rek(p1);
				flag = true;
				break;
			}
		}
		if (flag)
		{
			return copySourceInfo;
		}
		return null;
	}

	private static void z0rek(XTextTableElement p0, JsonElement p1, XTextElementList p2)
	{
		if (p1.ValueKind != JsonValueKind.Object)
		{
			return;
		}
		new XTextElementList();
		z0ZzZzzbj z0ZzZzzbj2 = new z0ZzZzzbj();
		int num = -1;
		string text = null;
		JsonElement p3;
		using (zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = p0.z0srk().z0ltk())
		{
			while (z0bpk.MoveNext())
			{
				XTextTableColumnElement xTextTableColumnElement = (XTextTableColumnElement)z0bpk.Current;
				if (num == -1 && xTextTableColumnElement.ValueBinding != null && xTextTableColumnElement.ValueBinding.BindingPath != null && xTextTableColumnElement.ValueBinding.BindingPath.Length > 0)
				{
					num = p0.z0srk().IndexOf(xTextTableColumnElement);
					text = xTextTableColumnElement.ValueBinding.BindingPath;
					break;
				}
				using zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk2 = xTextTableColumnElement.z0eek().z0ltk();
				while (z0bpk2.MoveNext())
				{
					XTextTableCellElement xTextTableCellElement = (XTextTableCellElement)z0bpk2.Current;
					if (xTextTableCellElement.ValueBinding != null && xTextTableCellElement.ValueBinding.BindingPath != null && xTextTableCellElement.ValueBinding.BindingPath.Length > 0 && p1.TryGetProperty(xTextTableCellElement.ValueBinding.BindingPath, out p3))
					{
						string text2 = z0xek(p3);
						if (text2 != null)
						{
							z0ZzZzzbj2.z0eek(xTextTableCellElement, text2, p2: false);
						}
					}
				}
			}
		}
		if (num == -1 || text == null || !p1.TryGetProperty(text, out p3) || p3.ValueKind != JsonValueKind.Array)
		{
			return;
		}
		int num2 = num;
		p3.GetArrayLength();
		foreach (JsonElement item in p3.EnumerateArray())
		{
			if (num2 > p0.z0drk() - 1)
			{
				break;
			}
			if (item.ValueKind != JsonValueKind.Object)
			{
				continue;
			}
			using (zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = (p0.z0srk()[num2] as XTextTableColumnElement).z0eek().z0ltk())
			{
				while (z0bpk.MoveNext())
				{
					XTextTableCellElement xTextTableCellElement2 = (XTextTableCellElement)z0bpk.Current;
					int p4 = p0.z0stk().IndexOf(xTextTableCellElement2.z0krk());
					XTextTableCellElement xTextTableCellElement3 = p0.z0nek(p4, num, p2: false);
					if (xTextTableCellElement3 != null && xTextTableCellElement3.ValueBinding != null && xTextTableCellElement3.ValueBinding.BindingPath != null && xTextTableCellElement3.ValueBinding.BindingPath.Length > 0 && item.TryGetProperty(xTextTableCellElement3.ValueBinding.BindingPath, out var p5))
					{
						string text3 = z0xek(p5);
						if (text3 != null)
						{
							z0ZzZzzbj2.z0eek(xTextTableCellElement2, text3, p2: false);
						}
					}
				}
			}
			num2++;
		}
		p0.z0oe();
	}

	public static JsonNode z0rek(PageLabelTextList p0)
	{
		if (p0 == null || p0.Count == 0)
		{
			return null;
		}
		JsonArray jsonArray = new JsonArray();
		foreach (PageLabelText item in p0)
		{
			JsonObject jsonObject = new JsonObject();
			jsonObject.Add("PageIndex", item.PageIndex);
			jsonObject.Add("PageIndexText", item.Text);
			jsonArray.Add(jsonObject);
		}
		return jsonArray;
	}

	public static JsonObject z0rek(XTextTableCellElement p0)
	{
		JsonObject obj = new JsonObject
		{
			{
				"TableID",
				p0.z0gr().ID
			},
			{ "ID", p0.ID },
			{
				"Width",
				p0.Width.ToString()
			},
			{
				"Height",
				p0.Height.ToString()
			},
			{
				"ValueBinding",
				z0rek(p0.ValueBinding)
			},
			{
				"Attributes",
				z0rek(p0.Attributes)
			},
			{ "Visible", p0.Visible },
			{ "RowSpan", p0.RowSpan },
			{ "ColSpan", p0.ColSpan },
			{
				"RowIndex",
				p0.z0pek()
			},
			{
				"ColIndex",
				p0.z0xek()
			},
			{ "Text", p0.Text },
			{ "Deleteable", p0.Deleteable },
			{
				"ContentReadonly",
				p0.ContentReadonly.ToString()
			},
			{
				"CloneType",
				p0.CloneType.ToString()
			},
			{
				"SlantSplitLineStyle",
				p0.SlantSplitLineStyle.ToString()
			},
			{
				"Style",
				z0tek(((XTextElement)p0).z0xrk())
			},
			{
				"MoveFocusHotKey",
				p0.MoveFocusHotKey.ToString()
			},
			{
				"EnablePermission",
				p0.EnablePermission.ToString()
			},
			{ "ValueExpression", p0.ValueExpression }
		};
		if (((XTextElement)p0).z0xrk() == null)
		{
			p0.z0yek(new DocumentContentStyle());
		}
		obj.Add("Align", ((XTextElement)p0).z0xrk().Align.ToString());
		obj.Add("VerticalAlign", ((XTextElement)p0).z0xrk().VerticalAlign.ToString());
		return obj;
	}

	public static void z0rek(IJSRuntime p0)
	{
		if (p0 == null || z0krk.Contains(p0.GetHashCode()))
		{
			return;
		}
		z0krk.Add(p0.GetHashCode());
		MethodInfo method = p0.GetType().GetMethod("get_JsonSerializerOptions", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
		if (method == null)
		{
			method = p0.GetType().GetMethod("ReadJsonSerializerOptions", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
		}
		if (!(method != null))
		{
			return;
		}
		JsonSerializerOptions jsonSerializerOptions = (JsonSerializerOptions)method.Invoke(p0, null);
		if (jsonSerializerOptions != null)
		{
			FieldInfo field = jsonSerializerOptions.GetType().GetField("_isImmutable", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
			if (field == null)
			{
				field = jsonSerializerOptions.GetType().GetField("_isReadOnly", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
			}
			if (field != null)
			{
				field.SetValue(jsonSerializerOptions, false);
				jsonSerializerOptions.Converters.Add(new z0fck());
				jsonSerializerOptions.Converters.Add(new JsonStringEnumConverter(new z0vck()));
				jsonSerializerOptions.Converters.Add(new z0wck());
				z0ZzZzxij.z0eek(jsonSerializerOptions);
				jsonSerializerOptions.PropertyNameCaseInsensitive = true;
				jsonSerializerOptions.PropertyNamingPolicy = null;
				field?.SetValue(jsonSerializerOptions, true);
			}
		}
	}

	public static z0ZzZzwmk z0mek(JsonElement p0)
	{
		if (p0.ValueKind != JsonValueKind.Object)
		{
			return null;
		}
		bool flag = false;
		z0ZzZzwmk z0ZzZzwmk2 = new z0ZzZzwmk();
		foreach (JsonProperty item in p0.EnumerateObject())
		{
			string text = item.Name.ToLower();
			string text2 = z0xek(item.Value);
			float num = 0f / 0f;
			int alpha = -2147483648;
			switch (text)
			{
			case "type":
				z0ZzZzwmk2.Type = z0eek(text2, WatermarkType.Text);
				flag = true;
				break;
			case "text":
				z0ZzZzwmk2.Text = text2;
				flag = true;
				break;
			case "repeat":
				z0ZzZzwmk2.Repeat = z0rek(text2, p1: true);
				flag = true;
				break;
			case "imagedatabase64string":
				z0ZzZzwmk2.Image = new z0ZzZzpmk();
				try
				{
					z0ZzZzwmk2.Image.LoadBase64String(text2);
					flag = true;
				}
				catch
				{
					flag = false;
				}
				break;
			case "font":
				z0ZzZzwmk2.Font = new z0ZzZzimk();
				z0ZzZzwmk2.Font.z0eek(text2);
				flag = true;
				break;
			case "densityforrepeat":
				if (float.TryParse(text2, out num))
				{
					z0ZzZzwmk2.DensityForRepeat = num;
					flag = true;
				}
				break;
			case "colorvalue":
				z0ZzZzwmk2.ColorValue = text2;
				flag = true;
				break;
			case "backcolorvalue":
				z0ZzZzwmk2.BackColorValue = text2;
				flag = true;
				break;
			case "angle":
				if (float.TryParse(text2, out num))
				{
					z0ZzZzwmk2.Angle = num;
					flag = true;
				}
				break;
			case "alpha":
				if (int.TryParse(text2, out alpha))
				{
					z0ZzZzwmk2.Alpha = alpha;
					flag = true;
				}
				break;
			}
		}
		if (!flag)
		{
			return null;
		}
		return z0ZzZzwmk2;
	}

	public static JsonNode z0rek(PropertyExpressionInfoList p0)
	{
		if (p0 == null || p0.Count == 0)
		{
			return null;
		}
		JsonObject jsonObject = new JsonObject();
		List<string> list = new List<string>();
		foreach (PropertyExpressionInfo item in p0)
		{
			if (!list.Contains(item.Name) && item.Name != null && item.Name.Length > 0)
			{
				jsonObject.Add(item.Name, item.Expression);
				list.Add(item.Name);
			}
		}
		return jsonObject;
	}

	public static JsonNode z0rek(DCPieDataItemList p0)
	{
		if (p0 == null || p0.Count == 0)
		{
			return null;
		}
		JsonArray jsonArray = new JsonArray();
		foreach (DCPieDataItem item in p0)
		{
			JsonObject jsonObject = new JsonObject();
			jsonObject.Add("Text", item.Text);
			jsonObject.Add("Value", item.Value);
			jsonObject.Add("Color", item.ColorValue);
			jsonArray.Add(jsonObject);
		}
		return jsonArray;
	}

	public static JsonNode z0rek(MedicalExpressionValueList p0)
	{
		if (p0 == null || p0.Count == 0)
		{
			return null;
		}
		JsonObject jsonObject = new JsonObject();
		List<string> list = new List<string>();
		foreach (z0ZzZzjuk item in p0)
		{
			if (!string.IsNullOrEmpty(item.Name) && !list.Contains(item.Name))
			{
				jsonObject.Add(item.Name, item.Value);
				list.Add(item.Name);
			}
		}
		return jsonObject;
	}

	public static void z0rek(JsonElement p0, XTextSubDocumentElement p1)
	{
		if (p1 == null)
		{
			return;
		}
		if (((XTextElement)p1).z0xrk() == null)
		{
			p1.z0yek(new DocumentContentStyle());
		}
		foreach (JsonProperty item in p0.EnumerateObject())
		{
			string text = item.Name.ToLower();
			string text2 = z0xek(item.Value);
			float borderWidth = 0f;
			int titleLevel = -2147483648;
			switch (text)
			{
			case "backgroundcolor":
				((XTextElement)p1).z0xrk().BackgroundColor = item.z0iek();
				break;
			case "attributes":
				p1.Attributes = z0cek(item.Value);
				break;
			case "enablecollapse":
				p1.EnableCollapse = item.z0yek(p1: true);
				break;
			case "newpage":
				p1.NewPage = item.z0yek(p1: true);
				break;
			case "contentreadonly":
				p1.ContentReadonly = item.z0rek(ContentReadonlyState.Inherit);
				break;
			case "title":
				p1.Title = text2;
				break;
			case "tooltip":
				p1.ToolTip = text2;
				break;
			case "id":
				p1.ID = text2;
				break;
			case "titlelevel":
				if (int.TryParse(item.z0uek(), out titleLevel))
				{
					((XTextElement)p1).z0xrk().TitleLevel = titleLevel;
				}
				break;
			case "enablepermission":
				p1.EnablePermission = item.z0rek(DCBooleanValue.Inherit);
				break;
			case "borderwidth":
				if (float.TryParse(item.z0uek(), out borderWidth))
				{
					((XTextElement)p1).z0xrk().BorderWidth = borderWidth;
				}
				break;
			case "bordertop":
				((XTextElement)p1).z0xrk().BorderTop = item.z0yek(p1: true);
				break;
			case "bordertopcolor":
				((XTextElement)p1).z0xrk().BorderTopColor = item.z0iek();
				break;
			case "borderleft":
				((XTextElement)p1).z0xrk().BorderLeft = item.z0yek(p1: true);
				break;
			case "borderleftcolor":
				((XTextElement)p1).z0xrk().BorderLeftColor = item.z0iek();
				break;
			case "borderright":
				((XTextElement)p1).z0xrk().BorderRight = item.z0yek(p1: true);
				break;
			case "borderrightcolor":
				((XTextElement)p1).z0xrk().BorderRightColor = item.z0iek();
				break;
			case "borderbottom":
				((XTextElement)p1).z0xrk().BorderBottom = item.z0yek(p1: true);
				break;
			case "borderbottomcolor":
				((XTextElement)p1).z0xrk().BorderBottomColor = item.z0iek();
				break;
			}
		}
	}

	public static string z0rek(object p0)
	{
		if (p0 == null)
		{
			return null;
		}
		return JsonSerializer.Serialize(p0, p0.GetType(), z0lrk);
	}

	public static z0ZzZzevj z0rek(JsonElement p0, z0ZzZzevj p1)
	{
		z0ZzZzevj z0ZzZzevj2 = ((p1 != null) ? p1.Clone() : new z0ZzZzevj());
		if (p0.ValueKind == JsonValueKind.String)
		{
			z0ZzZzevj2.DCReadString(p0.GetString());
			return z0ZzZzevj2;
		}
		if (p0.ValueKind != JsonValueKind.Object)
		{
			return p1;
		}
		bool flag = false;
		foreach (JsonProperty item in p0.EnumerateObject())
		{
			switch (item.Name.ToLower())
			{
			case "datasource":
				z0ZzZzevj2.DataSource = item.z0uek();
				flag = true;
				break;
			case "bindingpath":
				z0ZzZzevj2.BindingPath = item.z0uek();
				flag = true;
				break;
			case "bindingpathfortext":
				z0ZzZzevj2.BindingPathForText = item.z0uek();
				flag = true;
				break;
			case "enabled":
				z0ZzZzevj2.z0tek(item.z0yek(p1: false));
				flag = true;
				break;
			case "processstate":
				z0ZzZzevj2.ProcessState = item.z0rek(DCProcessStates.Always);
				flag = true;
				break;
			case "autoupdate":
				z0ZzZzevj2.z0yek(item.z0yek(p1: false));
				flag = true;
				break;
			case "readonly":
				z0ZzZzevj2.z0eek(item.z0yek(p1: false));
				flag = true;
				break;
			}
		}
		if (flag)
		{
			return z0ZzZzevj2;
		}
		return null;
	}

	private static JsonNode z0rek(XTextTableElement p0, out string p1)
	{
		p1 = p0.ValueBinding.DataSource;
		JsonArray jsonArray = new JsonArray();
		z0ZzZzdxj z0ZzZzdxj2 = new z0ZzZzdxj();
		z0ZzZzdxj2.z0tek(p0: false);
		z0ZzZzdxj2.z0yek(p0: false);
		z0ZzZzdxj2.z0eek(p0: false);
		z0ZzZzdxj2.z0rek(p0: false);
		z0ZzZzdxj2.z0uek(p0: false);
		XTextElementList xTextElementList = new XTextElementList();
		if (p0.z0jr() != null)
		{
			using zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = p0.z0jr().z0rek<XTextTableElement>().z0ltk();
			while (z0bpk.MoveNext())
			{
				XTextTableElement xTextTableElement = (XTextTableElement)z0bpk.Current;
				if (xTextTableElement.ValueBinding != null && xTextTableElement.ValueBinding.DataSource != null && xTextTableElement.ValueBinding.DataSource == p1)
				{
					xTextElementList.Add(xTextTableElement);
				}
			}
		}
		else
		{
			xTextElementList.Add(p0);
		}
		using zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = xTextElementList.z0ltk();
		while (z0bpk.MoveNext())
		{
			XTextTableElement obj = (XTextTableElement)z0bpk.Current;
			JsonObject jsonObject = new JsonObject();
			JsonArray jsonArray2 = new JsonArray();
			XTextTableColumnElement xTextTableColumnElement = null;
			using (zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk2 = obj.z0srk().z0ltk())
			{
				while (z0bpk2.MoveNext())
				{
					XTextTableColumnElement xTextTableColumnElement2 = (XTextTableColumnElement)z0bpk2.Current;
					if (xTextTableColumnElement == null && xTextTableColumnElement2.ValueBinding != null && !string.IsNullOrEmpty(xTextTableColumnElement2.ValueBinding.BindingPath))
					{
						xTextTableColumnElement = xTextTableColumnElement2;
					}
					JsonObject jsonObject2 = ((xTextTableColumnElement != null) ? new JsonObject() : null);
					bool flag = false;
					using (zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk3 = xTextTableColumnElement2.z0eek().z0ltk())
					{
						while (z0bpk3.MoveNext())
						{
							XTextTableCellElement xTextTableCellElement = (XTextTableCellElement)z0bpk3.Current;
							flag = false;
							if (xTextTableCellElement.z0bek() || xTextTableCellElement.z0wtk())
							{
								continue;
							}
							string text = xTextTableCellElement.z0yek(z0ZzZzdxj2);
							if (xTextTableCellElement.z0be().Count > 0 && xTextTableCellElement.z0be().Count <= 2 && xTextTableCellElement.z0be()[0] is XTextImageElement)
							{
								XTextImageElement xTextImageElement = xTextTableCellElement.z0be()[0] as XTextImageElement;
								text = (((xTextImageElement.z0frk() != null && xTextImageElement.z0frk().HasContent) || xTextImageElement.SaveContentInFile) ? ("data:image/png;base64," + xTextImageElement.z0frk().ImageDataBase64String) : xTextImageElement.z0mek());
							}
							if (xTextTableColumnElement == null)
							{
								if (xTextTableCellElement.ValueBinding != null && !string.IsNullOrEmpty(xTextTableCellElement.ValueBinding.BindingPath))
								{
									jsonObject.Add(xTextTableCellElement.ValueBinding.BindingPath, text);
								}
								continue;
							}
							int index = xTextTableColumnElement2.z0eek().IndexOf(xTextTableCellElement);
							if (xTextTableColumnElement.z0eek()[index] is XTextTableCellElement { ValueBinding: not null } xTextTableCellElement2 && !string.IsNullOrEmpty(xTextTableCellElement2.ValueBinding.BindingPath))
							{
								jsonObject2.Add(xTextTableCellElement2.ValueBinding.BindingPath, text);
								flag = true;
							}
						}
					}
					if (flag)
					{
						jsonArray2.Add(jsonObject2);
					}
				}
			}
			if (xTextTableColumnElement == null)
			{
				return null;
			}
			jsonObject.Add(xTextTableColumnElement.ValueBinding.BindingPath, jsonArray2);
			jsonArray.Add(jsonObject);
		}
		return jsonArray;
	}

	public static string z0rek(Color p0)
	{
		if (p0 == Color.Black)
		{
			return "#000000FF";
		}
		if (p0 == Color.White)
		{
			return "#FFFFFFFF";
		}
		if (p0 == Color.Transparent)
		{
			return "#FFFFFF00";
		}
		if (p0 == Color.Empty)
		{
			return "#00000000";
		}
		return $"#{p0.R:X2}{p0.G:X2}{p0.B:X2}{p0.A:X2}";
	}

	public static JsonNode z0rek(string p0)
	{
		z0ZzZzfah z0ZzZzfah2 = new z0ZzZzfah();
		try
		{
			z0ZzZzfah2.z0eek(p0);
		}
		catch (Exception)
		{
			return null;
		}
		if (!((z0ZzZzoah)z0ZzZzfah2).z0rek())
		{
			return null;
		}
		z0ZzZzoah z0ZzZzoah2 = ((z0ZzZzoah)z0ZzZzfah2).z0tek().z0eek(0);
		if (!z0ZzZzoah2.z0rek())
		{
			return null;
		}
		if (z0ZzZzoah2.z0th() == "a")
		{
			JsonObject jsonObject = new JsonObject();
			{
				foreach (z0ZzZzoah item in z0ZzZzoah2.z0tek())
				{
					jsonObject.Add(item.z0th(), item.z0eg());
				}
				return jsonObject;
			}
		}
		if (z0ZzZzoah2.z0th() == "NewDataSet")
		{
			JsonArray jsonArray = new JsonArray();
			{
				foreach (z0ZzZzoah item2 in z0ZzZzoah2.z0tek())
				{
					if (item2.z0th() != "DataTable" || !item2.z0rek())
					{
						continue;
					}
					JsonObject jsonObject2 = new JsonObject();
					foreach (z0ZzZzoah item3 in item2.z0tek())
					{
						jsonObject2.Add(item3.z0th(), item3.z0eg());
					}
					jsonArray.Add(jsonObject2);
				}
				return jsonArray;
			}
		}
		return null;
	}

	public static void z0rek(JsonElement p0, DocumentContentStyle p1)
	{
		foreach (JsonProperty item in p0.EnumerateObject())
		{
			string text = item.Name.ToLower();
			float borderWidth = 0f;
			switch (text)
			{
			case "borderleft":
			case "leftborder":
				p1.BorderLeft = item.z0yek(p1: true);
				break;
			case "bordertop":
			case "topborder":
				p1.BorderTop = item.z0yek(p1: true);
				break;
			case "borderbottom":
			case "bottomborder":
				p1.BorderBottom = item.z0yek(p1: true);
				break;
			case "borderright":
			case "rightborder":
				p1.BorderRight = item.z0yek(p1: true);
				break;
			case "borderstyle":
				p1.BorderStyle = item.z0rek(DashStyle.Solid);
				break;
			case "borderwidth":
				if (float.TryParse(item.z0uek(), out borderWidth))
				{
					p1.BorderWidth = borderWidth;
				}
				break;
			case "borderleftcolor":
				p1.BorderLeftColor = item.z0iek();
				break;
			case "borderrightcolor":
				p1.BorderRightColor = item.z0iek();
				break;
			case "bordertopcolor":
				p1.BorderTopColor = item.z0iek();
				break;
			case "borderbottomcolor":
				p1.BorderBottomColor = item.z0iek();
				break;
			}
		}
	}

	public static Color z0tek(string p0)
	{
		if (p0 != null && p0.StartsWith("#") && p0.Length == 9)
		{
			return Color.FromArgb(Convert.ToInt32(p0.Substring(7, 2), 16), Convert.ToInt32(p0.Substring(1, 2), 16), Convert.ToInt32(p0.Substring(3, 2), 16), Convert.ToInt32(p0.Substring(5, 2), 16));
		}
		return z0ZzZzifh.z0eek(p0);
	}

	public static JsonNode z0rek(XAttributeList p0)
	{
		if (p0 == null || p0.Count == 0)
		{
			return null;
		}
		JsonObject jsonObject = new JsonObject();
		List<string> list = new List<string>();
		using zzz.z0ZzZzkuk<XAttribute>.z0bpk z0bpk = p0.z0ltk();
		while (z0bpk.MoveNext())
		{
			XAttribute current = z0bpk.Current;
			if (!string.IsNullOrEmpty(current.Name) && !list.Contains(current.Name))
			{
				jsonObject.Add(current.Name, current.Value);
				list.Add(current.Name);
			}
		}
		return jsonObject;
	}

	private static void z0rek(XTextCheckBoxElementBase p0, JsonElement p1, XTextElementList p2)
	{
		new z0ZzZzzbj();
		string text = null;
		bool flag = false;
		JsonElement p3;
		if (p1.ValueKind == JsonValueKind.String)
		{
			text = p1.GetString();
			flag = true;
		}
		else if (p1.ValueKind == JsonValueKind.Object && p1.TryGetProperty(p0.ValueBinding.BindingPath, out p3))
		{
			text = z0xek(p3);
			flag = true;
		}
		if (!flag)
		{
			return;
		}
		if (p0.Name != null && p0.Name.Length > 0)
		{
			XTextElementList xTextElementList = p0.z0eek();
			if (xTextElementList == null || xTextElementList.Count <= 0)
			{
				return;
			}
			using zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = xTextElementList.z0ltk();
			while (z0bpk.MoveNext())
			{
				XTextElement current = z0bpk.Current;
				if (current is XTextCheckBoxElement)
				{
					z0ZzZzzuk obj = new z0ZzZzzuk(text, ',');
					XTextCheckBoxElement xTextCheckBoxElement = (XTextCheckBoxElement)current;
					bool flag2 = obj.z0tek(xTextCheckBoxElement.CheckedValue);
					if (xTextCheckBoxElement.EditorChecked != flag2)
					{
						xTextCheckBoxElement.EditorChecked = flag2;
					}
					p2.Add(current);
				}
				else if (current is XTextRadioBoxElement)
				{
					XTextRadioBoxElement xTextRadioBoxElement = (XTextRadioBoxElement)current;
					bool flag3 = xTextRadioBoxElement.CheckedValue == text;
					if (xTextRadioBoxElement.EditorChecked != flag3)
					{
						xTextRadioBoxElement.EditorChecked = flag3;
					}
					p2.Add(current);
				}
			}
			return;
		}
		if (p0.CheckedValue == text)
		{
			p0.EditorChecked = true;
		}
		else
		{
			p0.EditorChecked = false;
		}
		p2.Add(p0);
	}

	public static JsonObject z0rek(DocumentComment p0, z0ZzZzwcj p1)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("instance");
		}
		JsonObject jsonObject = new JsonObject();
		jsonObject.Add("Text", p0.z0nek());
		jsonObject.Add("Author", p0.z0krk());
		jsonObject.Add("AuthorID", p0.z0eek());
		jsonObject.Add("Index", p0.z0tek());
		jsonObject.Add("BackColor", z0ZzZzifh.z0eek(p0.z0frk()));
		jsonObject.Add("ForeColor", z0ZzZzifh.z0eek(p0.z0vek()));
		jsonObject.Add("BorderColor", z0ZzZzifh.z0eek(p0.z0brk()));
		jsonObject.Add("IsInternal", p0.z0uek().ToString());
		jsonObject.Add("Attributes", z0rek(p0.z0lrk()));
		jsonObject.Add("CreationTime", p0.z0mrk().ToString("yyyy-MM-dd HH:mm:ss"));
		if (p1 != null && p1.Count > 0)
		{
			jsonObject.Add("IndexByList", p1.IndexOf(p0));
		}
		return jsonObject;
	}

	static z0ZzZzboj()
	{
		z0krk = new List<int>();
		z0lrk = null;
		z0lrk = new JsonSerializerOptions();
		z0lrk.PropertyNameCaseInsensitive = true;
		z0lrk.WriteIndented = false;
		z0lrk.PropertyNamingPolicy = null;
		z0lrk.Converters.Add(new z0wck());
		z0lrk.Converters.Add(new z0fck());
		z0lrk.Converters.Add(new z0jck());
		z0ZzZzxij.z0eek(z0lrk);
		JsonStringEnumConverter jsonStringEnumConverter = new JsonStringEnumConverter(new z0vck());
		z0lrk.Converters.Add(jsonStringEnumConverter);
	}

	public static z0ZzZzzej z0nek(JsonElement p0)
	{
		if (p0.ValueKind != JsonValueKind.Object)
		{
			return null;
		}
		bool flag = false;
		z0ZzZzzej z0ZzZzzej2 = new z0ZzZzzej();
		foreach (JsonProperty item in p0.EnumerateObject())
		{
			string text = item.Name.ToLower();
			string text2 = z0xek(item.Value);
			int p1 = -2147483648;
			float p2 = 0f / 0f;
			switch (text)
			{
			case "aligntogridline":
				z0ZzZzzej2.z0tek(z0rek(item.Value, p1: true));
				flag = true;
				break;
			case "color":
				z0ZzZzzej2.z0eek(z0ZzZzlok.z0eek(text2, Color.Black));
				flag = true;
				break;
			case "gridnuminonepage":
				if (int.TryParse(text2, out p1))
				{
					z0ZzZzzej2.z0eek(p1);
					flag = true;
				}
				break;
			case "gridspanincm":
				if (float.TryParse(text2, out p2))
				{
					z0ZzZzzej2.z0tek(p2);
					flag = true;
				}
				break;
			case "linestyle":
				z0ZzZzzej2.z0eek(z0eek(text2, DashStyle.Solid));
				flag = true;
				break;
			case "linewidth":
				if (float.TryParse(text2, out p2))
				{
					z0ZzZzzej2.z0rek(p2);
					flag = true;
				}
				break;
			case "printable":
				z0ZzZzzej2.z0rek(z0rek(item.Value, p1: false));
				flag = true;
				break;
			case "visible":
				z0ZzZzzej2.z0eek(z0rek(item.Value, p1: false));
				flag = true;
				break;
			}
		}
		if (flag)
		{
			return z0ZzZzzej2;
		}
		return null;
	}

	public static DocumentComment z0rek(JsonElement p0, DocumentComment p1)
	{
		if (p1 == null)
		{
			throw new ArgumentNullException("instance");
		}
		foreach (JsonProperty item in p0.EnumerateObject())
		{
			string p2 = z0xek(item.Value);
			switch (item.Name.ToLower())
			{
			case "text":
				p1.z0pek(p2);
				break;
			case "author":
				p1.z0eek(p2);
				break;
			case "authorid":
				p1.z0rek(p2);
				break;
			case "backcolor":
				p1.z0rek(z0ZzZzifh.z0eek(p2));
				break;
			case "forecolor":
				p1.z0tek(z0ZzZzifh.z0eek(p2));
				break;
			case "bordercolor":
				p1.z0eek(z0ZzZzifh.z0eek(p2));
				break;
			case "attributes":
				p1.z0eek(z0cek(item.Value));
				break;
			}
		}
		return p1;
	}

	public static JsonNode z0rek(z0ZzZzdvj p0)
	{
		if (p0 == null)
		{
			return null;
		}
		JsonArray jsonArray = new JsonArray();
		using zzz.z0ZzZzkuk<ListItem>.z0bpk z0bpk = p0.z0ltk();
		while (z0bpk.MoveNext())
		{
			ListItem current = z0bpk.Current;
			JsonObject jsonObject = new JsonObject();
			jsonObject.Add("Text", current.Text);
			jsonObject.Add("TextInList", current.TextInList);
			jsonObject.Add("Value", current.Value);
			jsonObject.Add("Group", current.Group);
			jsonObject.Add("Tag", current.Tag);
			jsonObject.Add("ID", current.z0uek());
			jsonArray.Add(jsonObject);
		}
		return jsonArray;
	}

	private static void z0rek(XTextTableElement p0, JsonElement p1, XTextElementList p2, bool p3)
	{
		if (p0 == null || p1.ValueKind != JsonValueKind.Array || p1.GetArrayLength() == 0)
		{
			return;
		}
		XTextTableElement xTextTableElement = null;
		DataSourceBindingDescriptionList dataSourceBindingDescriptionList = p0.z0jr().z0ctk();
		XTextElementList xTextElementList = new XTextElementList();
		foreach (DataSourceBindingDescription item in dataSourceBindingDescriptionList)
		{
			if (!(item.Element is XTextTableElement) || !item.DataSource.StartsWith(p0.ValueBinding.DataSource))
			{
				continue;
			}
			if (xTextTableElement == null)
			{
				xTextTableElement = item.Element as XTextTableElement;
				xTextElementList.Add(xTextTableElement);
				xTextTableElement.CompressOwnerLineSpacing = true;
				continue;
			}
			if (item.Element.z0ke() is XTextPageBreakElement)
			{
				item.Element.z0ke().z0ji().z0ai(item.Element.z0ke());
			}
			item.Element.z0ji().z0ai(item.Element);
		}
		if (xTextTableElement == null)
		{
			return;
		}
		XTextElementList xTextElementList2 = xTextTableElement.z0gtk();
		int num = -1;
		using (zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = xTextElementList2.z0ltk())
		{
			while (z0bpk.MoveNext())
			{
				XTextTableCellElement xTextTableCellElement = (XTextTableCellElement)z0bpk.Current;
				if (xTextTableCellElement.ValueBinding != null && xTextTableCellElement.ValueBinding.BindingPath != null && xTextTableCellElement.ValueBinding.BindingPath.Length > 0)
				{
					if (num == -1 && xTextTableCellElement.z0drk() != null && xTextTableCellElement.z0drk().ValueBinding != null)
					{
						num = xTextTableCellElement.z0drk().z0rek();
					}
					z0tek(xTextTableCellElement);
				}
				else if (num >= 0 && xTextTableCellElement.z0drk() != null && xTextTableCellElement.z0drk().z0rek() >= num)
				{
					z0tek(xTextTableCellElement);
				}
			}
		}
		XTextElement xTextElement = xTextTableElement.z0xw();
		XTextTableElement xTextTableElement2 = xTextTableElement.z0lr(p0: true) as XTextTableElement;
		xTextTableElement.z0ji().z0be().z0cek(xTextTableElement);
		foreach (JsonElement item2 in p1.EnumerateArray())
		{
			XTextTableElement xTextTableElement3 = xTextTableElement2.z0lr(p0: true) as XTextTableElement;
			z0rek(xTextTableElement3, item2, p2);
			p2.Add(xTextTableElement3);
			xTextElement.z0ji().z0be().z0oek(xTextElement, xTextTableElement3);
			if (p3)
			{
				xTextElement.z0ji().z0be().z0oek(xTextElement, new XTextPageBreakElement());
			}
		}
		if (xTextElement.z0ke() is XTextPageBreakElement)
		{
			xTextElement.z0ji().z0be().z0cek(xTextElement.z0ke());
		}
	}

	public static z0ZzZzsok z0bek(JsonElement p0)
	{
		z0ZzZzsok z0ZzZzsok2 = new z0ZzZzsok();
		bool flag = false;
		if (p0.ValueKind == JsonValueKind.String)
		{
			z0ZzZzsok2.DCReadString(p0.GetString());
			return z0ZzZzsok2;
		}
		if (p0.ValueKind != JsonValueKind.Object)
		{
			return null;
		}
		foreach (JsonProperty item in p0.EnumerateObject())
		{
			string text = item.Name.ToLower();
			string text2 = ((item.Value.ValueKind == JsonValueKind.String) ? item.Value.GetString() : null);
			switch (text)
			{
			case "format":
				z0ZzZzsok2.Format = text2;
				flag = true;
				break;
			case "nonetext":
				z0ZzZzsok2.NoneText = text2;
				flag = true;
				break;
			case "style":
				z0ZzZzsok2.Style = item.z0rek(ValueFormatStyle.None);
				flag = true;
				break;
			}
		}
		if (flag)
		{
			return z0ZzZzsok2;
		}
		return null;
	}

	public static JsonNode z0rek(z0ZzZzevj p0)
	{
		if (p0 == null || p0.IsEmptyBinding)
		{
			return null;
		}
		JsonObject jsonObject = new JsonObject();
		if (!string.IsNullOrEmpty(p0.DataSource))
		{
			jsonObject.Add("DataSource", p0.DataSource);
		}
		if (!string.IsNullOrEmpty(p0.BindingPath))
		{
			jsonObject.Add("BindingPath", p0.BindingPath);
		}
		if (!string.IsNullOrEmpty(p0.BindingPathForText))
		{
			jsonObject.Add("BindingPathForText", p0.BindingPathForText);
		}
		if (p0.ProcessState != DCProcessStates.Always)
		{
			jsonObject.Add("ProcessState", p0.ProcessState.ToString());
		}
		if (!p0.z0eek())
		{
			jsonObject.Add("Enabled", p0.z0eek());
		}
		if (!p0.z0yek())
		{
			jsonObject.Add("AutoUpdate", p0.z0yek());
		}
		if (p0.z0rek())
		{
			jsonObject.Add("Readonly", p0.z0rek());
		}
		return jsonObject;
	}

	internal static void z0tek(XTextTableCellElement p0)
	{
		int p1 = -1;
		if (p0.z0be().Count <= 2 && p0.z0be()[0] is XTextInputFieldElement)
		{
			(p0.z0be()[0] as XTextInputFieldElement).z0be().Clear();
		}
		else if (p0.z0be().Count > 2 || !(p0.z0be()[0] is XTextCheckBoxElementBase))
		{
			if (p0.z0be().Count > 0)
			{
				p0.z0be()[0].z0pek();
				p1 = ((XTextElement)p0.z0be()[0].z0dy()).z0pek();
			}
			p0.z0be().Clear();
			XTextParagraphFlagElement xTextParagraphFlagElement = new XTextParagraphFlagElement();
			xTextParagraphFlagElement.z0oek(p1);
			p0.z0be().Add(xTextParagraphFlagElement);
		}
	}

	public static JsonObject z0rek(DCContentLockInfo p0)
	{
		if (p0 == null)
		{
			return null;
		}
		return new JsonObject
		{
			{ "OwnerUserID", p0.OwnerUserID },
			{
				"CreationTime",
				p0.CreationTime.ToString("yyyy-MM-dd HH:mm:ss")
			},
			{ "AuthorisedUserIDList", p0.AuthorisedUserIDList }
		};
	}

	public static PropertyExpressionInfoList z0vek(JsonElement p0)
	{
		PropertyExpressionInfoList propertyExpressionInfoList = new PropertyExpressionInfoList();
		if (p0.ValueKind == JsonValueKind.String)
		{
			propertyExpressionInfoList.DCReadString(p0.GetString());
			return propertyExpressionInfoList;
		}
		if (p0.ValueKind == JsonValueKind.Object)
		{
			foreach (JsonProperty item in p0.EnumerateObject())
			{
				string expression = item.z0uek();
				PropertyExpressionInfo propertyExpressionInfo = new PropertyExpressionInfo();
				propertyExpressionInfo.Name = item.Name;
				propertyExpressionInfo.Expression = expression;
				propertyExpressionInfoList.Add(propertyExpressionInfo);
			}
		}
		if (p0.ValueKind == JsonValueKind.Array)
		{
			foreach (JsonElement item2 in p0.EnumerateArray())
			{
				if (item2.ValueKind == JsonValueKind.Object)
				{
					JsonElement property = item2.GetProperty("Name");
					string expression2 = z0xek(item2.GetProperty("Expression"));
					if (property.ValueKind == JsonValueKind.String)
					{
						PropertyExpressionInfo propertyExpressionInfo2 = new PropertyExpressionInfo();
						propertyExpressionInfo2.Name = property.GetString();
						propertyExpressionInfo2.Expression = expression2;
						propertyExpressionInfoList.Add(propertyExpressionInfo2);
					}
				}
			}
		}
		if (propertyExpressionInfoList.Count > 0)
		{
			return propertyExpressionInfoList;
		}
		return null;
	}

	private static void z0rek(XTextImageElement p0, JsonElement p1, XTextElementList p2)
	{
		string text = null;
		bool flag = false;
		JsonElement p3;
		if (p1.ValueKind == JsonValueKind.String)
		{
			text = p1.GetString();
			flag = true;
		}
		else if (p1.ValueKind == JsonValueKind.Object && p1.TryGetProperty(p0.ValueBinding.BindingPath, out p3))
		{
			text = z0xek(p3);
			flag = true;
		}
		if (!flag)
		{
			return;
		}
		int num = text?.IndexOf(',') ?? (-1);
		if (text == null || !text.StartsWith("data:image/") || num <= 0)
		{
			return;
		}
		try
		{
			bool flag2 = false;
			float num2 = 0f;
			float num3 = 0f;
			if (text.Contains("$imagewidthheight$"))
			{
				string[] array = text.Split("$imagewidthheight$");
				if (array.Length == 2)
				{
					text = array[0];
					string[] array2 = array[1].Split('h');
					string text2 = array2[1];
					if (float.TryParse(array2[0].Split('w')[1], out num2) && float.TryParse(text2, out num3) && num2 > 0f && num3 > 0f)
					{
						flag2 = true;
					}
				}
			}
			string p4 = text.Substring(num + 1);
			p0.z0rek(p4, !flag2);
			if (flag2)
			{
				p0.Width = num2;
				p0.Height = num3;
				p0.KeepWidthHeightRate = false;
			}
			p2.Add(p0);
		}
		catch
		{
		}
	}

	private static void z0rek(XTextInputFieldElement p0, JsonElement p1, XTextElementList p2)
	{
		z0ZzZzzbj z0ZzZzzbj2 = new z0ZzZzzbj();
		if (p1.ValueKind == JsonValueKind.String)
		{
			string p3 = z0xek(p1);
			z0ZzZzzbj2.z0eek(p0, p3, p2: false);
			p2.Add(p0);
		}
		else
		{
			if (p1.ValueKind != JsonValueKind.Object)
			{
				return;
			}
			string text = p0.Text;
			string text2 = p0.InnerValue;
			bool flag = false;
			bool flag2 = false;
			if (!string.IsNullOrEmpty(p0.ValueBinding.BindingPathForText) && p1.TryGetProperty(p0.ValueBinding.BindingPathForText, out var p4))
			{
				text = z0xek(p4);
				flag = true;
			}
			if (p1.TryGetProperty(p0.ValueBinding.BindingPath, out p4))
			{
				if (p4.ValueKind == JsonValueKind.Object && p4.TryGetProperty("Text", out var p5) && p4.TryGetProperty("Value", out var p6))
				{
					text = z0xek(p5);
					text2 = z0xek(p6);
					flag = true;
					flag2 = true;
				}
				else
				{
					text2 = z0xek(p4);
					flag2 = true;
				}
			}
			if (flag2 || flag)
			{
				if (((flag2 && !flag) || (text2 != null && text2.Length > 0 && (text == null || text.Length == 0))) && (p0.FieldSettings == null || p0.FieldSettings.z0nek() == InputFieldEditStyle.Text) && string.IsNullOrEmpty(p0.ValueBinding.BindingPathForText))
				{
					text = text2.ToString();
					flag = true;
				}
				z0ZzZzzbj2.z0eek(p0, flag ? text : null, flag2 ? text2 : null, p3: false);
				p2.Add(p0);
			}
		}
	}

	public static void z0rek(XTextElement p0, JsonElement p1, XTextElementList p2, bool p3, WriterControlForWASM p4 = null)
	{
		if (p0 is XTextInputFieldElement)
		{
			z0rek((XTextInputFieldElement)p0, p1, p2);
		}
		else if (p0 is XTextCheckBoxElementBase)
		{
			z0rek((XTextCheckBoxElementBase)p0, p1, p2);
		}
		else if (p0 is XTextImageElement)
		{
			z0rek((XTextImageElement)p0, p1, p2);
		}
		else if (p0 is XTextLabelElementBase)
		{
			z0rek((XTextLabelElementBase)p0, p1, p2);
		}
		else if (p0 is XTextTableRowElement)
		{
			z0rek((XTextTableRowElement)p0, p1, p2, p4);
		}
		else if (p0 is XTextTableElement)
		{
			z0rek((XTextTableElement)p0, p1, p2, p3);
		}
	}

	public static void z0rek(WriterControlForWASM p0, JsonElement p1, z0ZzZzbpj p2)
	{
		if (p1.ValueKind != JsonValueKind.Object || p2 == null)
		{
			return;
		}
		string text = null;
		Color transparent = Color.Transparent;
		foreach (JsonProperty item in p1.EnumerateObject())
		{
			switch (item.Name.ToLower())
			{
			case "applyrange":
				p2.z0eek(item.z0rek(StyleApplyRanges.Text));
				break;
			case "bordersettingsstyle":
				p2.z0eek(item.z0rek(BorderSettingsStyle.None));
				break;
			case "borderstyle":
				p2.z0eek(item.z0rek(DashStyle.Solid));
				break;
			case "borderwidth":
				p2.z0eek(item.z0yek(1f));
				break;
			case "backgroundcolor":
				text = item.z0uek();
				if (text != null && text.Length != 0)
				{
					transparent = z0tek(text);
					if (p2.z0vek() != transparent)
					{
						p2.z0rek(transparent);
					}
				}
				break;
			case "borderbottomcolor":
				text = item.z0uek();
				if (text != null && text.Length != 0)
				{
					transparent = z0tek(text);
					if (p2.z0mek() != transparent)
					{
						p2.z0yek(transparent);
					}
				}
				break;
			case "borderleftcolor":
				text = item.z0uek();
				if (text != null && text.Length != 0)
				{
					transparent = z0tek(text);
					if (p2.z0zek() != transparent)
					{
						p2.z0eek(transparent);
					}
				}
				break;
			case "borderrightcolor":
				text = item.z0uek();
				if (text != null && text.Length != 0)
				{
					transparent = z0tek(text);
					if (p2.z0grk() != transparent)
					{
						p2.z0tek(transparent);
					}
				}
				break;
			case "bordertopcolor":
				text = item.z0uek();
				if (text != null && text.Length != 0)
				{
					transparent = z0tek(text);
					if (p2.z0bek() != transparent)
					{
						p2.z0uek(transparent);
					}
				}
				break;
			case "elements":
			{
				XTextElement xTextElement = null;
				if (item.Value.ValueKind == JsonValueKind.String)
				{
					xTextElement = p0.z0nrk().z0ki(item.Value.GetString());
					if (xTextElement != null)
					{
						if (p2.z0hrk() == null)
						{
							p2.z0eek(new XTextElementList());
						}
						p2.z0hrk().Add(xTextElement);
					}
				}
				else if (item.Value.ValueKind == JsonValueKind.Number)
				{
					xTextElement = p0.z0vek(item.Value.GetInt32());
					if (xTextElement != null)
					{
						if (p2.z0hrk() == null)
						{
							p2.z0eek(new XTextElementList());
						}
						p2.z0hrk().Add(xTextElement);
					}
				}
				else
				{
					if (item.Value.ValueKind != JsonValueKind.Array)
					{
						break;
					}
					foreach (JsonElement item2 in item.Value.EnumerateArray())
					{
						if (item2.ValueKind == JsonValueKind.String)
						{
							xTextElement = p0.z0nrk().z0ki(item2.GetString());
						}
						else if (item2.ValueKind == JsonValueKind.Number)
						{
							xTextElement = p0.z0vek(item2.GetInt32());
						}
						if (xTextElement != null)
						{
							if (p2.z0hrk() == null)
							{
								p2.z0eek(new XTextElementList());
							}
							p2.z0hrk().Add(xTextElement);
						}
					}
				}
				break;
			}
			case "enabledbackgroundcolor":
				p2.z0yek(item.z0yek(p1: true));
				break;
			case "enabledbordersettings":
				p2.z0oek(item.z0yek(p1: true));
				break;
			case "middlehorizontalborder":
				p2.z0pek(item.z0yek(p1: true));
				break;
			case "centerverticalborder":
				p2.z0rek(item.z0yek(p1: true));
				break;
			case "borderleft":
			case "leftborder":
				p2.z0eek(item.z0yek(p1: true));
				break;
			case "rightborder":
			case "borderright":
				p2.z0iek(item.z0yek(p1: true));
				break;
			case "bordertop":
			case "topborder":
				p2.z0uek(item.z0yek(p1: true));
				break;
			case "borderbottom":
			case "bottomborder":
				p2.z0tek(item.z0yek(p1: true));
				break;
			}
		}
	}

	public static XAttributeList z0cek(JsonElement p0)
	{
		XAttributeList xAttributeList = new XAttributeList();
		if (p0.ValueKind == JsonValueKind.String)
		{
			xAttributeList.DCReadString(p0.GetString());
			return xAttributeList;
		}
		if (p0.ValueKind == JsonValueKind.Object)
		{
			foreach (JsonProperty item3 in p0.EnumerateObject())
			{
				string value = z0xek(item3.Value);
				XAttribute item = new XAttribute(item3.Name, value);
				xAttributeList.Add(item);
			}
		}
		if (p0.ValueKind == JsonValueKind.Array)
		{
			foreach (JsonElement item4 in p0.EnumerateArray())
			{
				if (item4.ValueKind == JsonValueKind.Object)
				{
					JsonElement property = item4.GetProperty("Name");
					string value2 = z0xek(item4.GetProperty("Value"));
					if (property.ValueKind == JsonValueKind.String)
					{
						XAttribute item2 = new XAttribute(property.GetString(), value2);
						xAttributeList.Add(item2);
					}
				}
			}
		}
		if (xAttributeList.Count > 0)
		{
			return xAttributeList;
		}
		return null;
	}

	public static JsonNode z0tek(XTextTableElement p0, out string p1)
	{
		if (p0.ValueBinding != null && !string.IsNullOrEmpty(p0.ValueBinding.DataSource))
		{
			return z0rek(p0, out p1);
		}
		JsonNode jsonNode = null;
		XTextTableRowElement xTextTableRowElement = null;
		using (zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = p0.z0stk().z0ltk())
		{
			while (z0bpk.MoveNext())
			{
				XTextTableRowElement xTextTableRowElement2 = (XTextTableRowElement)z0bpk.Current;
				if (!xTextTableRowElement2.HeaderStyle && xTextTableRowElement2.ValueBinding != null && !string.IsNullOrEmpty(xTextTableRowElement2.ValueBinding.DataSource))
				{
					xTextTableRowElement = xTextTableRowElement2;
					break;
				}
			}
		}
		if (xTextTableRowElement == null)
		{
			p1 = null;
			return null;
		}
		p1 = xTextTableRowElement.ValueBinding.DataSource;
		JsonArray jsonArray = new JsonArray();
		z0ZzZzdxj z0ZzZzdxj2 = new z0ZzZzdxj();
		z0ZzZzdxj2.z0tek(p0: false);
		z0ZzZzdxj2.z0yek(p0: true);
		z0ZzZzdxj2.z0eek(p0: false);
		z0ZzZzdxj2.z0rek(p0: false);
		z0ZzZzdxj2.z0uek(p0: false);
		byte[] array = null;
		string text = null;
		using (zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = p0.z0stk().z0ltk())
		{
			while (z0bpk.MoveNext())
			{
				XTextTableRowElement xTextTableRowElement3 = (XTextTableRowElement)z0bpk.Current;
				if (xTextTableRowElement3.HeaderStyle || xTextTableRowElement3.z0drk() < xTextTableRowElement.z0drk())
				{
					continue;
				}
				JsonObject jsonObject = new JsonObject();
				bool flag = false;
				XTextElement[] array2 = ((zzz.z0ZzZzkuk<XTextElement>)xTextTableRowElement3.z0rek()).z0krk();
				int count = xTextTableRowElement3.z0rek().Count;
				for (int i = 0; i < count; i++)
				{
					XTextTableCellElement xTextTableCellElement = (XTextTableCellElement)array2[i];
					if (xTextTableCellElement.z0bek() || xTextTableCellElement.z0wtk())
					{
						continue;
					}
					XTextTableCellElement xTextTableCellElement2 = (XTextTableCellElement)xTextTableRowElement.z0rek()[i];
					XTextInputFieldElement xTextInputFieldElement = xTextTableCellElement2.z0oek<XTextInputFieldElement>();
					XTextCheckBoxElementBase xTextCheckBoxElementBase = null;
					JsonObject jsonObject2 = null;
					if ((xTextTableCellElement2.ValueBinding == null || string.IsNullOrEmpty(xTextTableCellElement2.ValueBinding.BindingPath)) && (xTextInputFieldElement == null || xTextInputFieldElement.ValueBinding == null || string.IsNullOrEmpty(xTextInputFieldElement.ValueBinding.BindingPath)))
					{
						continue;
					}
					XTextContainerElement xTextContainerElement = ((xTextTableCellElement2.ValueBinding != null && !string.IsNullOrEmpty(xTextTableCellElement2.ValueBinding.BindingPath)) ? ((XTextContainerElement)xTextTableCellElement) : ((XTextContainerElement)xTextInputFieldElement));
					string text2 = xTextContainerElement.z0yek(z0ZzZzdxj2);
					XTextElementList xTextElementList = xTextTableCellElement.z0nek<XTextInputFieldElement>();
					XTextElementList xTextElementList2 = xTextTableCellElement.z0nek<XTextObjectElement>();
					if (xTextTableCellElement2.ValueBinding != null && !string.IsNullOrEmpty(xTextTableCellElement2.ValueBinding.BindingPath) && (xTextElementList.Count > 1 || xTextElementList2.Count > 1))
					{
						XTextDocument xTextDocument = new XTextDocument();
						using (zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk2 = xTextTableCellElement.z0be().z0ltk())
						{
							while (z0bpk2.MoveNext())
							{
								XTextElement xTextElement = z0bpk2.Current.z0lr(p0: true);
								xTextElement.z0bt(xTextDocument);
								xTextDocument.z0xyk().z0be().Add(xTextElement);
							}
						}
						if (xTextDocument.z0qrk() > 0 || (xTextDocument.z0gpk() != null && xTextDocument.z0gpk().Count > 0))
						{
							if (jsonObject2 == null)
							{
								jsonObject2 = new JsonObject();
							}
							foreach (DocumentParameter item in xTextDocument.z0gpk())
							{
								if (item.z0bek() is string)
								{
									jsonObject2.Add(item.z0eek(), (string)item.z0bek());
								}
							}
						}
						xTextDocument.Dispose();
					}
					else if (xTextContainerElement.z0be().Count > 0 && xTextContainerElement.z0be()[0] is XTextImageElement)
					{
						XTextImageElement xTextImageElement = null;
						using (zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk2 = xTextContainerElement.z0rek<XTextImageElement>().z0ltk())
						{
							while (z0bpk2.MoveNext())
							{
								XTextImageElement xTextImageElement2 = (XTextImageElement)z0bpk2.Current;
								if (!xTextImageElement2.z0wtk())
								{
									xTextImageElement = xTextImageElement2;
									break;
								}
							}
						}
						if (xTextImageElement != null)
						{
							if ((xTextImageElement.z0frk() == null || !xTextImageElement.z0frk().HasContent) && !xTextImageElement.SaveContentInFile)
							{
								text2 = xTextImageElement.z0mek();
							}
							else if (xTextImageElement.z0ork() == array)
							{
								text2 = text;
							}
							else
							{
								text2 = z0ZzZzpmk.StaticGetEmitImageSource(xTextImageElement.z0ork());
								array = xTextImageElement.z0ork();
								text = text2;
							}
						}
						else
						{
							text2 = xTextTableCellElement.Text;
						}
					}
					else if (xTextContainerElement.z0be().Count > 0 && xTextContainerElement.z0be().Count <= 2 && xTextContainerElement.z0be()[0] is XTextCheckBoxElementBase)
					{
						xTextCheckBoxElementBase = xTextTableCellElement.z0be()[0] as XTextCheckBoxElementBase;
						XTextElementList xTextElementList3 = xTextCheckBoxElementBase.z0eek();
						if (xTextCheckBoxElementBase.z0jr() != null && xTextCheckBoxElementBase.Name != null && xTextCheckBoxElementBase.Name.Length > 0 && xTextElementList3.Count > 0)
						{
							string text3 = string.Empty;
							using (zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk2 = xTextElementList3.z0ltk())
							{
								while (z0bpk2.MoveNext())
								{
									XTextCheckBoxElementBase xTextCheckBoxElementBase2 = (XTextCheckBoxElementBase)z0bpk2.Current;
									if (xTextCheckBoxElementBase2.Checked && xTextCheckBoxElementBase2.CheckedValue != null)
									{
										text3 = text3 + xTextCheckBoxElementBase2.CheckedValue + ",";
									}
								}
							}
							text2 = ((text3.Length > 0) ? text3.Substring(0, text3.Length - 1) : text3);
						}
						else
						{
							text2 = xTextCheckBoxElementBase.Checked.ToString();
						}
					}
					else if (xTextContainerElement is XTextTableCellElement && xTextContainerElement.z0be().Count > 0 && xTextContainerElement.z0be().Count <= 2 && xTextContainerElement.z0be()[0] is XTextInputFieldElement)
					{
						XTextInputFieldElement xTextInputFieldElement2 = xTextContainerElement.z0be()[0] as XTextInputFieldElement;
						if (xTextInputFieldElement2.z0be().Count <= 0 || !(xTextInputFieldElement2.z0be()[0] is XTextImageElement))
						{
							text2 = ((xTextInputFieldElement2.FieldSettings == null || xTextInputFieldElement2.FieldSettings.z0nek() != InputFieldEditStyle.DropdownList) ? xTextInputFieldElement2.z0yek(z0ZzZzdxj2) : xTextInputFieldElement2.InnerValue);
						}
						else
						{
							XTextImageElement xTextImageElement3 = null;
							using (zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk2 = xTextInputFieldElement2.z0rek<XTextImageElement>().z0ltk())
							{
								while (z0bpk2.MoveNext())
								{
									XTextImageElement xTextImageElement4 = (XTextImageElement)z0bpk2.Current;
									if (!xTextImageElement4.z0wtk())
									{
										xTextImageElement3 = xTextImageElement4;
										break;
									}
								}
							}
							if (xTextImageElement3 != null)
							{
								if ((xTextImageElement3.z0frk() == null || !xTextImageElement3.z0frk().HasContent) && !xTextImageElement3.SaveContentInFile)
								{
									text2 = xTextImageElement3.z0mek();
								}
								else if (xTextImageElement3.z0ork() == array)
								{
									text2 = text;
								}
								else
								{
									text2 = z0ZzZzpmk.StaticGetEmitImageSource(xTextImageElement3.z0ork());
									array = xTextImageElement3.z0ork();
									text = text2;
								}
							}
							else
							{
								text2 = xTextInputFieldElement2.z0yek(z0ZzZzdxj2);
							}
						}
					}
					string text4 = ((xTextTableCellElement2.ValueBinding != null && !string.IsNullOrEmpty(xTextTableCellElement2.ValueBinding.BindingPath)) ? xTextTableCellElement2.ValueBinding.BindingPath : xTextInputFieldElement.ValueBinding.BindingPath);
					if (jsonObject.TryGetPropertyValue(text4, out jsonNode))
					{
						continue;
					}
					if (jsonObject2 != null)
					{
						jsonObject.Add(text4, jsonObject2);
					}
					else if (xTextCheckBoxElementBase != null)
					{
						bool flag2 = false;
						if (bool.TryParse(text2, out flag2))
						{
							jsonObject.Add(text4, flag2);
						}
						else
						{
							jsonObject.Add(text4, text2);
						}
					}
					else
					{
						jsonObject.Add(text4, text2);
					}
					flag = true;
				}
				if (flag)
				{
					jsonArray.Add(jsonObject);
				}
			}
		}
		text = null;
		array = null;
		z0ZzZzdxj2.Dispose();
		return jsonArray;
	}

	public static string z0xek(JsonElement p0)
	{
		string result = null;
		switch (p0.ValueKind)
		{
		case JsonValueKind.String:
			result = p0.GetString()?.Replace("<br/>", Environment.NewLine);
			break;
		case JsonValueKind.Null:
			return null;
		case JsonValueKind.False:
			return "false";
		case JsonValueKind.True:
			return "true";
		case JsonValueKind.Number:
			result = p0.GetSingle().ToString();
			break;
		case JsonValueKind.Undefined:
			return null;
		case JsonValueKind.Object:
			return null;
		case JsonValueKind.Array:
			return null;
		}
		return result;
	}

	public static JsonObject z0rek(JumpPrintInfo p0)
	{
		if (p0 == null)
		{
			return new JsonObject();
		}
		return new JsonObject
		{
			{ "Enabled", p0.Enabled },
			{
				"Mode",
				p0.Mode.ToString()
			},
			{ "PageIndex", p0.PageIndex },
			{ "Position", p0.Position },
			{ "EndPageIndex", p0.EndPageIndex },
			{ "EndPosition", p0.EndPosition }
		};
	}

	public static void z0rek(JsonElement p0, z0ZzZzvpk p1)
	{
		if (p0.ValueKind != JsonValueKind.Object || p1 == null)
		{
			return;
		}
		string text = null;
		Color transparent = Color.Transparent;
		foreach (JsonProperty item in p0.EnumerateObject())
		{
			switch (item.Name.ToLower())
			{
			case "borderrange":
				p1.z0eek(item.z0rek(PageBorderRangeTypes.Page));
				break;
			case "borderstyle":
				p1.BorderStyle = item.z0rek(DashStyle.Solid);
				break;
			case "borderwidth":
				p1.BorderWidth = item.z0yek(1f);
				break;
			case "backgroundcolor":
				text = item.z0uek();
				if (text != null && text.Length != 0)
				{
					transparent = z0tek(text);
					if (p1.BackgroundColor != transparent)
					{
						p1.BackgroundColor = transparent;
					}
				}
				break;
			case "borderbottomcolor":
				text = item.z0uek();
				if (text != null && text.Length != 0)
				{
					transparent = z0tek(text);
					if (p1.BorderBottomColor != transparent)
					{
						p1.BorderBottomColor = transparent;
					}
				}
				break;
			case "borderleftcolor":
				text = item.z0uek();
				if (text != null && text.Length != 0)
				{
					transparent = z0tek(text);
					if (p1.BorderLeftColor != transparent)
					{
						p1.BorderLeftColor = transparent;
					}
				}
				break;
			case "borderrightcolor":
				text = item.z0uek();
				if (text != null && text.Length != 0)
				{
					transparent = z0tek(text);
					if (p1.BorderRightColor != transparent)
					{
						p1.BorderRightColor = transparent;
					}
				}
				break;
			case "bordertopcolor":
				text = item.z0uek();
				if (text != null && text.Length != 0)
				{
					transparent = z0tek(text);
					if (p1.BorderTopColor != transparent)
					{
						p1.BorderTopColor = transparent;
					}
				}
				break;
			case "borderleft":
			case "leftborder":
				p1.BorderLeft = item.z0yek(p1: false);
				break;
			case "borderright":
			case "rightborder":
				p1.BorderRight = item.z0yek(p1: false);
				break;
			case "bordertop":
			case "topborder":
				p1.BorderTop = item.z0yek(p1: false);
				break;
			case "borderbottom":
			case "bottomborder":
				p1.BorderBottom = item.z0yek(p1: false);
				break;
			}
		}
	}

	public static z0ZzZzdvj z0zek(JsonElement p0)
	{
		z0ZzZzdvj z0ZzZzdvj2 = new z0ZzZzdvj();
		if (p0.ValueKind != JsonValueKind.Array)
		{
			return null;
		}
		foreach (JsonElement item in p0.EnumerateArray())
		{
			if (item.ValueKind != JsonValueKind.Object)
			{
				continue;
			}
			ListItem listItem = new ListItem();
			foreach (JsonProperty item2 in item.EnumerateObject())
			{
				string text = item2.Name.ToLower();
				string text2 = ((item2.Value.ValueKind == JsonValueKind.String) ? item2.Value.GetString() : null);
				switch (text)
				{
				case "text":
					listItem.Text = text2;
					break;
				case "value":
					listItem.Value = text2;
					break;
				case "textinlist":
					listItem.TextInList = text2;
					break;
				case "group":
					listItem.Group = text2;
					break;
				case "tag":
					listItem.Tag = text2;
					break;
				case "id":
					listItem.z0eek(text2);
					break;
				}
			}
			z0ZzZzdvj2.Add(listItem);
		}
		if (z0ZzZzdvj2.Count > 0)
		{
			return z0ZzZzdvj2;
		}
		return null;
	}

	public static JsonNode z0rek(z0ZzZzzej p0)
	{
		if (p0 == null)
		{
			return null;
		}
		return new JsonObject
		{
			{
				"AlignToGridLine",
				p0.z0cek()
			},
			{
				"Color",
				z0ZzZzlok.z0eek(p0.z0iek())
			},
			{
				"GridNumInOnePage",
				p0.z0mek()
			},
			{
				"GridSpanInCM",
				p0.z0xek()
			},
			{
				"LineStyle",
				p0.z0vek().ToString()
			},
			{
				"LineWidth",
				p0.z0oek()
			},
			{
				"Printable",
				p0.z0yek()
			},
			{
				"Visible",
				p0.z0uek()
			}
		};
	}

	public static T z0eek<T>(string p0, T p1) where T : Enum
	{
		if (p0 == null || p0.Length == 0 || p0 == "null")
		{
			return p1;
		}
		try
		{
			return zzz.z0ZzZzcyk<T>.z0eek(p0);
		}
		catch (Exception)
		{
			return p1;
		}
	}

	public static JsonObject z0tek(DocumentContentStyle p0)
	{
		if (p0 == null)
		{
			return null;
		}
		return new JsonObject
		{
			{ "BorderLeft", p0.BorderLeft },
			{ "BorderTop", p0.BorderTop },
			{ "BorderBottom", p0.BorderBottom },
			{ "BorderRight", p0.BorderRight },
			{ "borderwidth", p0.BorderWidth },
			{
				"BorderStyle",
				p0.BorderStyle.ToString()
			},
			{
				"BorderLeftColor",
				z0ZzZzifh.z0eek(p0.BorderLeftColor)
			},
			{
				"BorderRightColor",
				z0ZzZzifh.z0eek(p0.BorderRightColor)
			},
			{
				"BorderTopColor",
				z0ZzZzifh.z0eek(p0.BorderTopColor)
			},
			{
				"BorderBottomColor",
				z0ZzZzifh.z0eek(p0.BorderBottomColor)
			}
		};
	}

	public static DocumentContentStyle z0rek(JsonElement p0, DocumentContentStyle p1, out bool p2)
	{
		p2 = false;
		Color black = Color.Black;
		if (p0.ValueKind != JsonValueKind.Object)
		{
			return null;
		}
		DocumentContentStyle documentContentStyle = ((p1 != null) ? ((DocumentContentStyle)p1.Clone()) : new DocumentContentStyle());
		foreach (JsonProperty item in p0.EnumerateObject())
		{
			string text = item.Name.ToLower();
			string text2 = z0xek(item.Value);
			int num = -2147483648;
			float num2 = 0f / 0f;
			switch (text)
			{
			case "strikeout":
				documentContentStyle.Strikeout = z0rek(item.Value, p1: false);
				if (p1.Strikeout != documentContentStyle.Strikeout)
				{
					p2 = true;
				}
				break;
			case "underline":
				documentContentStyle.Underline = z0rek(item.Value, p1: false);
				if (p1.Underline != documentContentStyle.Underline)
				{
					p2 = true;
				}
				break;
			case "italic":
				documentContentStyle.Italic = z0rek(item.Value, p1: false);
				if (p1.Italic != documentContentStyle.Italic)
				{
					p2 = true;
				}
				break;
			case "titlelevel":
				if (int.TryParse(text2, out num))
				{
					documentContentStyle.TitleLevel = num;
					if (p1.TitleLevel != documentContentStyle.TitleLevel)
					{
						p2 = true;
					}
				}
				break;
			case "bold":
				documentContentStyle.Bold = z0rek(item.Value, p1: false);
				if (p1.Bold != documentContentStyle.Bold)
				{
					p2 = true;
				}
				break;
			case "colorstring":
				if (text2 != null && text2.Length != 0)
				{
					black = z0tek(text2);
					if (documentContentStyle.Color != black)
					{
						documentContentStyle.Color = black;
						p2 = true;
					}
				}
				break;
			case "printcolorstring":
				if (text2 != null && text2.Length != 0)
				{
					black = z0tek(text2);
					if (documentContentStyle.PrintColor != black)
					{
						documentContentStyle.PrintColor = black;
						p2 = true;
					}
				}
				break;
			case "printbackcolorstring":
				if (text2 != null && text2.Length != 0)
				{
					black = z0tek(text2);
					if (documentContentStyle.PrintBackColor != black)
					{
						documentContentStyle.PrintBackColor = black;
						p2 = true;
					}
				}
				break;
			case "verticalalign":
				documentContentStyle.VerticalAlign = z0eek(text2, VerticalAlignStyle.Top);
				if (p1.VerticalAlign != documentContentStyle.VerticalAlign)
				{
					p2 = true;
				}
				break;
			case "align":
				documentContentStyle.Align = z0eek(text2, DocumentContentAlignment.Left);
				if (p1.Align != documentContentStyle.Align)
				{
					p2 = true;
				}
				break;
			case "bordertop":
				documentContentStyle.BorderTop = z0rek(item.Value, p1: false);
				if (p1.BorderTop != documentContentStyle.BorderTop)
				{
					p2 = true;
				}
				break;
			case "borderleft":
				documentContentStyle.BorderLeft = z0rek(item.Value, p1: false);
				if (p1.BorderLeft != documentContentStyle.BorderLeft)
				{
					p2 = true;
				}
				break;
			case "borderright":
				documentContentStyle.BorderRight = z0rek(item.Value, p1: false);
				if (p1.BorderRight != documentContentStyle.BorderRight)
				{
					p2 = true;
				}
				break;
			case "borderbottom":
				documentContentStyle.BorderBottom = z0rek(item.Value, p1: false);
				if (p1.BorderBottom != documentContentStyle.BorderBottom)
				{
					p2 = true;
				}
				break;
			case "borderrightcolorstring":
				if (text2 != null && text2.Length != 0)
				{
					black = z0tek(text2);
					if (documentContentStyle.BorderRightColor != black)
					{
						documentContentStyle.BorderRightColor = black;
						p2 = true;
					}
				}
				break;
			case "borderleftcolorstring":
				if (text2 != null && text2.Length != 0)
				{
					black = z0tek(text2);
					if (documentContentStyle.BorderLeftColor != black)
					{
						documentContentStyle.BorderLeftColor = black;
						p2 = true;
					}
				}
				break;
			case "bordertopcolorstring":
				if (text2 != null && text2.Length != 0)
				{
					black = z0tek(text2);
					if (documentContentStyle.BorderTopColor != black)
					{
						documentContentStyle.BorderTopColor = black;
						p2 = true;
					}
				}
				break;
			case "borderbottomcolorstring":
				if (text2 != null && text2.Length != 0)
				{
					black = z0tek(text2);
					if (documentContentStyle.BorderBottomColor != black)
					{
						documentContentStyle.BorderBottomColor = black;
						p2 = true;
					}
				}
				break;
			case "borderrightcolor":
				if (text2 != null && text2.Length != 0)
				{
					black = z0tek(text2);
					if (documentContentStyle.BorderRightColor != black)
					{
						documentContentStyle.BorderRightColor = black;
						p2 = true;
					}
				}
				break;
			case "borderleftcolor":
				if (text2 != null && text2.Length != 0)
				{
					black = z0tek(text2);
					if (documentContentStyle.BorderLeftColor != black)
					{
						documentContentStyle.BorderLeftColor = black;
						p2 = true;
					}
				}
				break;
			case "bordertopcolor":
				if (text2 != null && text2.Length != 0)
				{
					black = z0tek(text2);
					if (documentContentStyle.BorderTopColor != black)
					{
						documentContentStyle.BorderTopColor = black;
						p2 = true;
					}
				}
				break;
			case "borderbottomcolor":
				if (text2 != null && text2.Length != 0)
				{
					black = z0tek(text2);
					if (documentContentStyle.BorderBottomColor != black)
					{
						documentContentStyle.BorderBottomColor = black;
						p2 = true;
					}
				}
				break;
			case "borderstyle":
				documentContentStyle.BorderStyle = z0eek(text2, DashStyle.Solid);
				if (p1.BorderStyle != documentContentStyle.BorderStyle)
				{
					p2 = true;
				}
				break;
			case "borderwidth":
				if (float.TryParse(text2, out num2))
				{
					documentContentStyle.BorderWidth = num2;
					if (p1.BorderWidth != documentContentStyle.BorderWidth)
					{
						p2 = true;
					}
				}
				break;
			case "borderspacing":
				if (float.TryParse(text2, out num2))
				{
					documentContentStyle.BorderSpacing = num2;
					if (p1.BorderSpacing != documentContentStyle.BorderSpacing)
					{
						p2 = true;
					}
				}
				break;
			case "paddingbottom":
				if (float.TryParse(text2, out num2))
				{
					documentContentStyle.PaddingBottom = num2;
					if (p1.PaddingBottom != documentContentStyle.PaddingBottom)
					{
						p2 = true;
					}
				}
				break;
			case "paddingleft":
				if (float.TryParse(text2, out num2))
				{
					documentContentStyle.PaddingLeft = num2;
					if (p1.PaddingLeft != documentContentStyle.PaddingLeft)
					{
						p2 = true;
					}
				}
				break;
			case "paddingright":
				if (float.TryParse(text2, out num2))
				{
					documentContentStyle.PaddingRight = num2;
					if (p1.PaddingRight != documentContentStyle.PaddingRight)
					{
						p2 = true;
					}
				}
				break;
			case "paddingtop":
				if (float.TryParse(text2, out num2))
				{
					documentContentStyle.PaddingTop = num2;
					if (p1.PaddingTop != documentContentStyle.PaddingTop)
					{
						p2 = true;
					}
				}
				break;
			case "backgroundcolorstring":
				if (text2 != null && text2.Length != 0)
				{
					black = z0tek(text2);
					if (documentContentStyle.BackgroundColor != black)
					{
						documentContentStyle.BackgroundColor = black;
						p2 = true;
					}
				}
				break;
			case "linespacing":
				if (float.TryParse(text2, out num2))
				{
					documentContentStyle.LineSpacing = num2;
					if (p1.LineSpacing != documentContentStyle.LineSpacing)
					{
						p2 = true;
					}
				}
				break;
			case "leftindent":
				if (float.TryParse(text2, out num2))
				{
					documentContentStyle.LeftIndent = num2;
					if (p1.LeftIndent != documentContentStyle.LeftIndent)
					{
						p2 = true;
					}
				}
				break;
			case "linespacingstyle":
				documentContentStyle.LineSpacingStyle = z0eek(text2, LineSpacingStyle.SpaceSingle);
				if (p1.LineSpacingStyle != documentContentStyle.LineSpacingStyle)
				{
					p2 = true;
				}
				break;
			case "spacingafterparagraph":
				if (float.TryParse(text2, out num2))
				{
					documentContentStyle.SpacingAfterParagraph = num2;
					if (p1.SpacingAfterParagraph != documentContentStyle.SpacingAfterParagraph)
					{
						p2 = true;
					}
				}
				break;
			case "spacingbeforeparagraph":
				if (float.TryParse(text2, out num2))
				{
					documentContentStyle.SpacingBeforeParagraph = num2;
					if (p1.SpacingBeforeParagraph != documentContentStyle.SpacingBeforeParagraph)
					{
						p2 = true;
					}
				}
				break;
			case "firstlineindent":
				if (float.TryParse(text2, out num2))
				{
					documentContentStyle.FirstLineIndent = num2;
					if (p1.FirstLineIndent != documentContentStyle.FirstLineIndent)
					{
						p2 = true;
					}
				}
				break;
			case "paragraphoutlinelevel":
				if (int.TryParse(text2, out num))
				{
					documentContentStyle.ParagraphOutlineLevel = num;
					if (p1.ParagraphOutlineLevel != documentContentStyle.ParagraphOutlineLevel)
					{
						p2 = true;
					}
				}
				break;
			case "paragraphmultilevel":
				documentContentStyle.ParagraphMultiLevel = z0rek(item.Value, p1: false);
				if (p1.ParagraphMultiLevel != documentContentStyle.ParagraphMultiLevel)
				{
					p2 = true;
				}
				break;
			case "paragraphliststyle":
				documentContentStyle.ParagraphListStyle = z0eek(text2, ParagraphListStyle.None);
				if (p1.ParagraphListStyle != documentContentStyle.ParagraphListStyle)
				{
					p2 = true;
				}
				break;
			case "fontstyle":
				documentContentStyle.FontStyle = z0eek(text2, FontStyle.Regular);
				if (p1.FontStyle != documentContentStyle.FontStyle)
				{
					p2 = true;
				}
				break;
			case "fontname":
				documentContentStyle.FontName = text2;
				if (p1.FontName != documentContentStyle.FontName)
				{
					p2 = true;
				}
				break;
			case "fontsize":
				if (float.TryParse(text2, out num2))
				{
					documentContentStyle.FontSize = num2;
					if (p1.FontSize != documentContentStyle.FontSize)
					{
						p2 = true;
					}
				}
				break;
			case "layoutalign":
				documentContentStyle.LayoutAlign = z0eek(text2, ContentLayoutAlign.EmbedInText);
				if (p1.LayoutAlign != documentContentStyle.LayoutAlign)
				{
					p2 = true;
				}
				break;
			case "underlinestyle":
				documentContentStyle.UnderlineStyle = z0eek(text2, TextUnderlineStyle.Single);
				if (p1.UnderlineStyle != documentContentStyle.UnderlineStyle)
				{
					p2 = true;
				}
				break;
			case "underlinecolor":
				if (text2 != null && text2.Length != 0 && documentContentStyle.UnderlineColor != text2)
				{
					documentContentStyle.UnderlineColor = text2;
					p2 = true;
				}
				break;
			case "charactercircle":
				documentContentStyle.CharacterCircle = z0eek(text2, CharacterCircleStyles.None);
				if (p1.CharacterCircle != documentContentStyle.CharacterCircle)
				{
					p2 = true;
				}
				break;
			}
		}
		return documentContentStyle;
	}

	public static JsonNode z0rek(z0ZzZzsok p0)
	{
		if (p0 == null)
		{
			return null;
		}
		JsonObject jsonObject = new JsonObject();
		if (!string.IsNullOrEmpty(p0.NoneText))
		{
			jsonObject.Add("NoneText", p0.NoneText);
		}
		if (!string.IsNullOrEmpty(p0.Format))
		{
			jsonObject.Add("Format", p0.Format);
		}
		if (p0.Style != ValueFormatStyle.None)
		{
			jsonObject.Add("Style", p0.Style.ToString());
		}
		return jsonObject;
	}

	public static JsonNode z0rek(ValueValidateStyle p0)
	{
		if (p0 == null)
		{
			return null;
		}
		JsonObject jsonObject = new JsonObject();
		if (p0.BinaryLength)
		{
			jsonObject.Add("BinaryLength", p0.BinaryLength);
		}
		if (p0.CheckDecimalDigits)
		{
			jsonObject.Add("CheckDecimalDigits", p0.CheckDecimalDigits);
		}
		if (p0.CheckMaxValue)
		{
			jsonObject.Add("CheckMaxValue", p0.CheckMaxValue);
		}
		if (p0.CheckMinValue)
		{
			jsonObject.Add("CheckMinValue", p0.CheckMinValue);
		}
		if (!string.IsNullOrEmpty(p0.CustomMessage))
		{
			jsonObject.Add("CustomMessage", p0.CustomMessage);
		}
		if (p0.IsDateOrTimeType())
		{
			if (p0.DateTimeMaxValue != ValueValidateStyle.NullDateTime)
			{
				jsonObject.Add("DateTimeMaxValue", p0.DateTimeMaxValue.ToString("yyyy-MM-dd HH:mm:ss"));
			}
			if (p0.DateTimeMinValue != ValueValidateStyle.NullDateTime)
			{
				jsonObject.Add("DateTimeMinValue", p0.DateTimeMinValue.ToString("yyyy-MM-dd HH:mm:ss"));
			}
		}
		if (!string.IsNullOrEmpty(p0.ExcludeKeywords))
		{
			jsonObject.Add("ExcludeKeywords", p0.ExcludeKeywords);
		}
		if (!string.IsNullOrEmpty(p0.IncludeKeywords))
		{
			jsonObject.Add("IncludeKeywords", p0.IncludeKeywords);
		}
		if (p0.Level != ValueValidateLevel.Error)
		{
			jsonObject.Add("Level", p0.Level.ToString());
		}
		if (p0.MaxDecimalDigits != 0)
		{
			jsonObject.Add("MaxDecimalDigits", p0.MaxDecimalDigits);
		}
		if (p0.MaxLength != 0)
		{
			jsonObject.Add("MaxLength", p0.MaxLength);
		}
		if (!double.IsNaN(p0.MaxValue))
		{
			jsonObject.Add("MaxValue", double.IsNaN(p0.MaxValue) ? null : ((JsonNode)p0.MaxValue));
		}
		if (!string.IsNullOrEmpty(p0.Message))
		{
			jsonObject.Add("Message", p0.Message);
		}
		if (p0.MinLength != 0)
		{
			jsonObject.Add("MinLength", p0.MinLength);
		}
		if (!double.IsNaN(p0.MinValue))
		{
			jsonObject.Add("MinValue", double.IsNaN(p0.MinValue) ? null : ((JsonNode)p0.MinValue));
		}
		if (!string.IsNullOrEmpty(p0.Range))
		{
			jsonObject.Add("Range", p0.Range);
		}
		if (!string.IsNullOrEmpty(p0.RegExpression))
		{
			jsonObject.Add("RegExpression", p0.RegExpression);
		}
		if (p0.Required)
		{
			jsonObject.Add("Required", p0.Required);
		}
		if (!string.IsNullOrEmpty(p0.ValueName))
		{
			jsonObject.Add("ValueName", p0.ValueName);
		}
		if (p0.ValueType != ValueTypeStyle.Text)
		{
			jsonObject.Add("ValueType", p0.ValueType.ToString());
		}
		return jsonObject;
	}
}
