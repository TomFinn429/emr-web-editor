using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using DCSoft.Common;
using DCSoft.Data;
using DCSoft.Drawing;
using DCSoft.Printing;
using DCSoft.WASM;
using DCSoft.Writer;
using DCSoft.Writer.Data;
using DCSoft.Writer.Dom;
using DCSoft.Writer.Security;
using DCSystem_Drawing;
using DCSystem_Drawing.Drawing2D;

namespace zzz;

internal static class z0ZzZzcoj
{
	public static List<string> z0vek;

	private static Dictionary<int, int> z0frk;

	internal static bool z0wrk;

	private static readonly string z0irk;

	private static readonly string[] z0zrk;

	private static Dictionary<int, int> z0jtk;

	private static DateTimeFormatInfo z0atk;

	[CompilerGenerated]
	internal static bool z0tek(object p0)
	{
		if (!(p0 is byte) && !(p0 is sbyte) && !(p0 is short) && !(p0 is ushort) && !(p0 is int) && !(p0 is uint) && !(p0 is long) && !(p0 is ulong) && !(p0 is float) && !(p0 is double))
		{
			return p0 is decimal;
		}
		return true;
	}

	static z0ZzZzcoj()
	{
		z0vek = null;
		z0atk = null;
		z0wrk = false;
		z0zrk = new string[28]
		{
			"yyyy-MM-ddTHH:mm:ss+zzz", "yyyy-MM-ddTHH:mm:sszzz", "yyyy-MM-ddTHH:mm:sszz", "yyyy-MM-ddTHH:mm:ssz", "yyyy-MM-ddTHH:mm:ss.FFFFFFFzzzzzz", "yyyy-MM-ddTHH:mm:ss.FFFFFFF", "yyyy-MM-ddTHH:mm:ss.FFFFFFFZ", "HH:mm:ss.FFFFFFF", "HH:mm:ss.FFFFFFFZ", "HH:mm:ss.FFFFFFFzzzzzz",
			"yyyy-MM-dd", "yyyy-MM-ddZ", "yyyy-MM-ddzzzzzz", "yyyy-MM", "yyyy-MMZ", "yyyy-MMzzzzzz", "yyyy", "yyyyZ", "yyyyzzzzzz", "--MM-dd",
			"--MM-ddZ", "--MM-ddzzzzzz", "---dd", "---ddZ", "---ddzzzzzz", "--MM--", "--MM--Z", "--MM--zzzzzz"
		};
		z0frk = null;
		z0jtk = null;
		z0irk = "dcwriterxml20230629:";
	}

	public static void z0tek(ContentChangingEventArgs p0)
	{
	}

	public static bool z0tek(XTextLabelElement p0)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("element");
		}
		if (p0.ContactAction == LabelTextContactActionMode.Disable)
		{
			return false;
		}
		if (string.IsNullOrEmpty(p0.AttributeNameForContactAction))
		{
			return false;
		}
		XTextDocument xTextDocument = p0.z0jr();
		if (xTextDocument == null)
		{
			return false;
		}
		try
		{
			z0jtk = null;
			z0frk = null;
			p0.PageTexts.Clear();
			if (p0.ContactAction == LabelTextContactActionMode.TableRow)
			{
				XTextElementList xTextElementList = xTextDocument.z0xyk().z0rek<XTextTableRowElement>();
				for (int i = 0; i < xTextDocument.z0suk().Count; i++)
				{
					StringBuilder stringBuilder = new StringBuilder();
					string text = null;
					for (int num = xTextElementList.Count - 1; num >= 0; num--)
					{
						XTextTableRowElement xTextTableRowElement = (XTextTableRowElement)xTextElementList[num];
						if (z0yek(xTextTableRowElement) == i || z0tek(xTextTableRowElement) == i)
						{
							if (z0yek(xTextTableRowElement) == z0tek(xTextTableRowElement))
							{
								xTextElementList.RemoveAt(num);
							}
							string text2 = xTextTableRowElement.z0zwk(p0.AttributeNameForContactAction);
							if (!string.IsNullOrEmpty(text2) && (text == null || text != text2))
							{
								text = text2;
								if (stringBuilder.Length > 0 && !string.IsNullOrEmpty(p0.LinkTextForContactAction))
								{
									stringBuilder.Insert(0, p0.LinkTextForContactAction);
								}
								stringBuilder.Insert(0, text2);
							}
						}
					}
					p0.PageTexts.SetPageText(i, stringBuilder.ToString());
				}
				return true;
			}
			if (p0.ContactAction == LabelTextContactActionMode.FirstTableRowInPage)
			{
				XTextElementList xTextElementList2 = xTextDocument.z0xyk().z0rek<XTextTableRowElement>();
				for (int j = 0; j < xTextDocument.z0suk().Count; j++)
				{
					foreach (XTextTableRowElement item in xTextElementList2.z0xrk())
					{
						if (z0yek(item) == j)
						{
							string text3 = item.z0zwk(p0.AttributeNameForContactAction);
							if (!string.IsNullOrEmpty(text3))
							{
								p0.PageTexts.SetPageText(j, text3);
								break;
							}
						}
					}
				}
				return true;
			}
			if (p0.ContactAction == LabelTextContactActionMode.LastTableRowInPage)
			{
				XTextElementList xTextElementList3 = xTextDocument.z0xyk().z0rek<XTextTableRowElement>();
				for (int k = 0; k < xTextDocument.z0suk().Count; k++)
				{
					for (int num2 = xTextElementList3.Count - 1; num2 >= 0; num2--)
					{
						XTextTableRowElement xTextTableRowElement3 = (XTextTableRowElement)xTextElementList3[num2];
						if (z0yek(xTextTableRowElement3) == k)
						{
							string text4 = xTextTableRowElement3.z0zwk(p0.AttributeNameForContactAction);
							if (!string.IsNullOrEmpty(text4))
							{
								p0.PageTexts.SetPageText(k, text4);
								break;
							}
						}
					}
				}
				return true;
			}
			if (p0.ContactAction == LabelTextContactActionMode.Normal)
			{
				XTextElementList xTextElementList4 = xTextDocument.z0xyk().z0eek();
				if (xTextElementList4 == null || xTextElementList4.Count == 0)
				{
					return false;
				}
				XTextSectionElement xTextSectionElement = (XTextSectionElement)xTextElementList4[0];
				if (xTextSectionElement == null)
				{
					return false;
				}
				int num3 = xTextSectionElement.z0je();
				int num4 = xTextSectionElement.z0juk();
				string linkTextForContactAction = p0.LinkTextForContactAction;
				string text5 = xTextSectionElement.z0zwk(p0.AttributeNameForContactAction);
				string text6 = text5;
				if (num4 > num3)
				{
					for (int l = num3; l <= num4; l++)
					{
						p0.SetPageLabelText(l, text6);
					}
					num3 = num4;
				}
				for (XTextSectionElement xTextSectionElement2 = (XTextSectionElement)xTextElementList4.z0xek(xTextSectionElement); xTextSectionElement2 != null; xTextSectionElement2 = (XTextSectionElement)xTextElementList4.z0xek(xTextSectionElement2))
				{
					if (xTextSectionElement2.z0je() != num3)
					{
						p0.SetPageLabelText(num3, text6);
						num3 = xTextSectionElement2.z0je();
						num4 = xTextSectionElement2.z0juk();
						text6 = string.Empty;
						text5 = string.Empty;
					}
					string text7 = xTextSectionElement2.z0zwk(p0.AttributeNameForContactAction);
					if (!string.IsNullOrEmpty(text6))
					{
						if (!(text7 == text5))
						{
							text6 = text6 + linkTextForContactAction + text7;
							text5 = text7;
						}
					}
					else
					{
						text6 = text7;
						text5 = text7;
					}
					if (xTextSectionElement2.z0juk() > xTextSectionElement2.z0je())
					{
						for (int m = xTextSectionElement2.z0je(); m <= xTextSectionElement2.z0juk(); m++)
						{
							string text8 = ((m == xTextSectionElement2.z0je()) ? text6 : text7);
							p0.SetPageLabelText(m, text8);
						}
						num3 = xTextSectionElement2.z0juk();
						text5 = (text6 = text7);
					}
				}
				if (!string.IsNullOrEmpty(text6))
				{
					p0.SetPageLabelText(num3, text6);
				}
				return true;
			}
			if (p0.ContactAction == LabelTextContactActionMode.FirstSectionInPage)
			{
				z0ZzZzlkh z0ZzZzlkh2 = xTextDocument.z0xyk().z0tek();
				for (int n = 0; n < xTextDocument.z0suk().Count; n++)
				{
					z0ZzZzwrj z0ZzZzwrj2 = xTextDocument.z0suk()[n];
					foreach (z0ZzZzzlh item2 in z0ZzZzlkh2.z0xrk())
					{
						if (item2.z0qtk() || item2.z0rtk() || item2.z0dtk() != z0ZzZzwrj2)
						{
							continue;
						}
						XTextSectionElement xTextSectionElement3 = item2[0].z0eek<XTextSectionElement>(p0: true);
						if (xTextSectionElement3 != null)
						{
							string text9 = xTextSectionElement3.z0zwk(p0.AttributeNameForContactAction);
							if (!string.IsNullOrEmpty(text9))
							{
								p0.PageTexts.SetPageText(n, text9);
								break;
							}
						}
					}
				}
				return true;
			}
			if (p0.ContactAction == LabelTextContactActionMode.LastSectionInPage)
			{
				z0ZzZzlkh z0ZzZzlkh3 = xTextDocument.z0xyk().z0tek();
				for (int num5 = 0; num5 < xTextDocument.z0suk().Count; num5++)
				{
					z0ZzZzwrj z0ZzZzwrj3 = xTextDocument.z0suk()[num5];
					for (int num6 = z0ZzZzlkh3.Count - 1; num6 >= 0; num6--)
					{
						z0ZzZzzlh z0ZzZzzlh2 = z0ZzZzlkh3[num6];
						if (!z0ZzZzzlh2.z0qtk() && !z0ZzZzzlh2.z0rtk() && z0ZzZzzlh2.z0dtk() == z0ZzZzwrj3)
						{
							XTextSectionElement xTextSectionElement4 = z0ZzZzzlh2[0].z0eek<XTextSectionElement>(p0: true);
							if (xTextSectionElement4 != null)
							{
								string text10 = xTextSectionElement4.z0zwk(p0.AttributeNameForContactAction);
								if (!string.IsNullOrEmpty(text10))
								{
									p0.PageTexts.SetPageText(num5, text10);
									break;
								}
							}
						}
					}
				}
				return true;
			}
		}
		catch (Exception ex)
		{
			z0ZzZzqok.z0rek.z0dh(ex.ToString());
		}
		return false;
	}

	public static int z0tek(XTextContainerElement p0, JsonElement p1)
	{
		z0ZzZzevj valueBinding = p0.ValueBinding;
		if (valueBinding != null && valueBinding.z0eek() && !valueBinding.IsEmptyBinding)
		{
			JsonElement p2 = z0tek(p1, valueBinding.DataSource);
			if (p0 is XTextInputFieldElement xTextInputFieldElement)
			{
				string text = null;
				string text2 = null;
				if (!string.IsNullOrEmpty(valueBinding.BindingPath))
				{
					text2 = z0tek(p2, valueBinding.BindingPath).z0yek();
				}
				text = (string.IsNullOrEmpty(valueBinding.BindingPathForText) ? text2 : z0tek(p2, valueBinding.BindingPathForText).z0yek());
				xTextInputFieldElement.z0zek(text);
				xTextInputFieldElement.InnerValue = text2;
				return 0;
			}
			if (!(p0 is XTextTableRowElement))
			{
				string p3 = z0tek(p2, valueBinding.BindingPath).z0yek();
				p0.z0zek(p3);
			}
		}
		return 0;
	}

	public static string z0tek(byte[] p0)
	{
		if (p0 == null || p0.Length <= 4)
		{
			return string.Empty;
		}
		if (p0[0] == 133)
		{
			return z0ZzZzroj.z0eek(p0);
		}
		return z0ZzZzpmk.StaticGetEmitImageSource(p0);
	}

	internal static z0ZzZzclh z0tek(JsonElement p0, XTextDocument p1 = null)
	{
		z0ZzZzclh z0ZzZzclh2 = new z0ZzZzclh();
		List<string> list = new List<string>();
		List<JsonElement> list2 = new List<JsonElement>();
		List<JsonElement> list3 = new List<JsonElement>();
		bool flag = false;
		z0ZzZzwmk p2 = null;
		bool flag2 = false;
		bool flag3 = false;
		string text = "xml";
		List<int> list4 = null;
		XTextDocument xTextDocument = null;
		bool flag4 = false;
		bool flag5 = false;
		bool flag6 = false;
		if (p0.ValueKind != JsonValueKind.Object)
		{
			if (p1 != null)
			{
				XTextDocument xTextDocument2 = p1.z0lr(p0: true) as XTextDocument;
				z0ZzZzclh2.Add(xTextDocument2);
			}
		}
		else
		{
			if (p0.TryGetProperty("UseBase64", out var p3))
			{
				flag2 = p3.z0yek(p1: false);
			}
			if (p0.TryGetProperty("Format", out p3) || p0.TryGetProperty("format", out p3))
			{
				text = p3.z0yek();
			}
			foreach (JsonProperty item in p0.EnumerateObject())
			{
				switch (item.Name.ToLower())
				{
				case "files":
					if (item.Value.ValueKind != JsonValueKind.Array)
					{
						break;
					}
					foreach (JsonElement item2 in item.Value.EnumerateArray())
					{
						if (item2.ValueKind == JsonValueKind.String)
						{
							string p5 = item2.GetString();
							XTextDocument xTextDocument3 = new XTextDocument();
							if (flag2)
							{
								xTextDocument3.z0grk(p5, text);
							}
							else
							{
								xTextDocument3.z0lrk(p5, text);
							}
							z0ZzZzclh2.Add(xTextDocument3);
						}
						else
						{
							if (item2.ValueKind != JsonValueKind.Array)
							{
								continue;
							}
							int arrayLength = item2.GetArrayLength();
							if (arrayLength == 0)
							{
								continue;
							}
							bool flag7 = arrayLength == 1;
							XTextDocument xTextDocument4 = new XTextDocument();
							bool flag8 = false;
							foreach (JsonElement item3 in item2.EnumerateArray())
							{
								if (item3.ValueKind != JsonValueKind.String)
								{
									continue;
								}
								string text2 = item3.GetString();
								if (flag7)
								{
									if (flag2)
									{
										xTextDocument4.z0grk(text2, text);
									}
									else
									{
										xTextDocument4.z0lrk(text2, text);
									}
									z0ZzZzclh2.Add(xTextDocument4);
									break;
								}
								if (!flag8)
								{
									if (flag2)
									{
										xTextDocument4.z0grk(text2, text);
									}
									else
									{
										xTextDocument4.z0lrk(text2, text);
									}
									xTextDocument4.z0xyk().z0be().Clear();
									using (zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = xTextDocument4.z0ve().z0ltk())
									{
										while (z0bpk.MoveNext())
										{
											XTextElement current7 = z0bpk.Current;
											if (current7.z0pek() >= xTextDocument4.z0gnk().Styles.Count)
											{
												current7.z0oek(-1);
											}
										}
									}
									flag8 = true;
								}
								XTextSubDocumentElement xTextSubDocumentElement = new XTextSubDocumentElement();
								xTextSubDocumentElement.z0iek(xTextDocument4.z0xyk());
								if (flag2)
								{
									xTextSubDocumentElement.LoadDocumentFromBase64String(text2, text);
								}
								else
								{
									xTextSubDocumentElement.LoadDocumentFromString(text2, text);
								}
								if ((xTextSubDocumentElement.z0be().Count != 1 || !(xTextSubDocumentElement.z0be()[0] is XTextParagraphFlagElement)) && xTextSubDocumentElement.z0be() != null && xTextSubDocumentElement.z0be().Count != 0)
								{
									xTextDocument4.z0xyk().z0be().Add(xTextSubDocumentElement);
								}
							}
							if (!flag7 && xTextDocument4.z0xyk().z0be().Count > 0)
							{
								z0ZzZzclh2.Add(xTextDocument4);
							}
						}
					}
					break;
				case "watermark":
					p2 = z0ZzZzboj.z0mek(item.Value);
					flag4 = true;
					break;
				case "insertlasttablerowtopagebottom":
					flag = item.z0yek(p1: false);
					break;
				case "usebase64":
					flag2 = item.z0yek(p1: false);
					break;
				case "commitusertrace":
					flag3 = item.z0yek(p1: false);
					break;
				case "bindingdataxmls":
					if (item.Value.ValueKind != JsonValueKind.Array)
					{
						break;
					}
					foreach (JsonElement item4 in item.Value.EnumerateArray())
					{
						if (item4.ValueKind == JsonValueKind.String)
						{
							list.Add(item4.GetString());
						}
					}
					break;
				case "bindingdatas":
					if (item.Value.ValueKind != JsonValueKind.Array)
					{
						break;
					}
					foreach (JsonElement item5 in item.Value.EnumerateArray())
					{
						if (item5.ValueKind == JsonValueKind.Object)
						{
							list2.Add(item5);
						}
					}
					break;
				case "bindingdatasforunifiedheaderfooter":
					if (item.Value.ValueKind == JsonValueKind.Object)
					{
						list3.Add(item.Value);
					}
					break;
				case "pageindexs":
					if (item.Value.ValueKind == JsonValueKind.Array)
					{
						foreach (JsonElement item6 in item.Value.EnumerateArray())
						{
							if (item6.ValueKind == JsonValueKind.Number)
							{
								list4.Add(item6.GetInt32());
							}
						}
					}
					else if (item.Value.ValueKind == JsonValueKind.String)
					{
						list4 = z0tek(item.Value.GetString());
					}
					break;
				case "unifiedheaderfooterfile":
					if (item.Value.ValueKind == JsonValueKind.String)
					{
						string p4 = item.Value.GetString();
						xTextDocument = new XTextDocument();
						if (flag2)
						{
							xTextDocument.z0grk(p4, text);
						}
						else
						{
							xTextDocument.z0lrk(p4, text);
						}
					}
					break;
				case "forcelocalpageindex":
					if (item.Value.ValueKind == JsonValueKind.Null || item.Value.ValueKind == JsonValueKind.Undefined)
					{
						flag5 = false;
						break;
					}
					flag6 = item.z0yek(p1: false);
					flag5 = true;
					break;
				}
			}
			if (z0ZzZzclh2.Count == 0 && p1 != null)
			{
				XTextDocument xTextDocument5 = p1.z0lr(p0: true) as XTextDocument;
				z0ZzZzclh2.Add(xTextDocument5);
			}
		}
		XPageSettings xPageSettings = null;
		for (int i = 0; i < z0ZzZzclh2.Count; i++)
		{
			XTextDocument xTextDocument6 = z0ZzZzclh2[i];
			if (i == 0)
			{
				xPageSettings = xTextDocument6.PageSettings.z0wtk();
			}
			else if (xPageSettings != null && xTextDocument6.PageSettings.z0yrk() != xPageSettings.z0yrk())
			{
				float num = (float)xPageSettings.z0ntk() / (float)xTextDocument6.PageSettings.z0ntk();
				using (zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = xTextDocument6.z0rek<XTextTableElement>().z0ltk())
				{
					while (z0bpk.MoveNext())
					{
						using zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk2 = ((XTextTableElement)z0bpk.Current).z0srk().z0ltk();
						while (z0bpk2.MoveNext())
						{
							((XTextTableColumnElement)z0bpk2.Current).Width *= num;
						}
					}
				}
				xTextDocument6.PageSettings.z0eek(xPageSettings.z0yrk());
				xTextDocument6.PageSettings.z0eek(xTextDocument6.PageSettings.z0ctk() * num);
				xTextDocument6.PageSettings.z0pek(xTextDocument6.PageSettings.z0iek() * num);
			}
			if (xTextDocument != null && list3.Count == 1)
			{
				JsonElement jsonElement = list3[0];
				bool flag9 = false;
				foreach (JsonProperty item7 in jsonElement.EnumerateObject())
				{
					string name = item7.Name;
					if (item7.Value.ValueKind == JsonValueKind.String)
					{
						xTextDocument.z0bek(name, (object)item7.Value.GetString());
						flag9 = true;
					}
					else if (item7.Value.ValueKind == JsonValueKind.Object || item7.Value.ValueKind == JsonValueKind.Array)
					{
						string p6 = z0ZzZzboj.z0iek(item7.Value);
						xTextDocument.z0jrk(name, p6);
						flag9 = true;
					}
				}
				if (flag9)
				{
					xTextDocument.z0kmk();
				}
			}
			if (z0ZzZzclh2.Count == list2.Count)
			{
				JsonElement jsonElement2 = list2[i];
				bool flag10 = false;
				foreach (JsonProperty item8 in jsonElement2.EnumerateObject())
				{
					string name2 = item8.Name;
					if (item8.Value.ValueKind == JsonValueKind.String)
					{
						xTextDocument6.z0bek(name2, (object)item8.Value.GetString());
						flag10 = true;
					}
					else if (item8.Value.ValueKind == JsonValueKind.Object || item8.Value.ValueKind == JsonValueKind.Array)
					{
						string p7 = z0ZzZzboj.z0iek(item8.Value);
						xTextDocument6.z0jrk(name2, p7);
						flag10 = true;
					}
				}
				if (flag10)
				{
					xTextDocument6.z0kmk();
				}
			}
			else if (z0ZzZzclh2.Count == list.Count && list[i].StartsWith("<"))
			{
				string text3 = list[i];
				text3 = "<a>" + text3 + "</a>";
				z0ZzZzfah z0ZzZzfah2 = new z0ZzZzfah();
				try
				{
					z0ZzZzfah2.z0eek(text3);
				}
				catch (Exception)
				{
					z0ZzZzfah2 = null;
				}
				if (z0ZzZzfah2 != null)
				{
					z0ZzZzoah z0ZzZzoah2 = ((z0ZzZzoah)z0ZzZzfah2).z0iek();
					if (!z0ZzZzoah2.z0rek())
					{
						xTextDocument6.z0jrk(z0ZzZzoah2.z0ph(), z0ZzZzoah2.z0eg());
					}
					else
					{
						foreach (z0ZzZzoah item9 in z0ZzZzoah2.z0tek())
						{
							string p8 = item9.z0ph();
							string p9 = item9.z0uek();
							xTextDocument6.z0jrk(p8, p9);
						}
					}
					xTextDocument6.z0kmk();
				}
			}
			if (xTextDocument != null)
			{
				xTextDocument6.z0pyk().z0be().Clear();
				xTextDocument6.z0lik().z0be().Clear();
				XTextElementList p10 = xTextDocument.z0pyk().z0be().z0nek();
				XTextElementList p11 = xTextDocument.z0lik().z0be().z0nek();
				xTextDocument6.z0cek(p10);
				xTextDocument6.z0cek(p11);
				((zzz.z0ZzZzkuk<XTextElement>)xTextDocument6.z0pyk().z0be()).z0tek((zzz.z0ZzZzkuk<XTextElement>)p10);
				((zzz.z0ZzZzkuk<XTextElement>)xTextDocument6.z0lik().z0be()).z0tek((zzz.z0ZzZzkuk<XTextElement>)p11);
			}
			if (flag3)
			{
				xTextDocument6.z0eu();
			}
			if (flag4)
			{
				xTextDocument6.PageSettings.z0eek(p2);
			}
			if (flag)
			{
				xTextDocument6.z0vek(p0: false);
				z0tek(xTextDocument6);
			}
			if (flag5)
			{
				using zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = xTextDocument6.z0lik().z0rek<XTextPageInfoElement>().z0ltk();
				while (z0bpk.MoveNext())
				{
					XTextPageInfoElement xTextPageInfoElement = (XTextPageInfoElement)z0bpk.Current;
					if (xTextPageInfoElement.ValueType == PageInfoValueType.PageIndex || xTextPageInfoElement.ValueType == PageInfoValueType.LocalPageIndex)
					{
						xTextPageInfoElement.ValueType = (flag6 ? PageInfoValueType.LocalPageIndex : PageInfoValueType.PageIndex);
					}
					else
					{
						xTextPageInfoElement.ValueType = ((!flag6) ? PageInfoValueType.NumOfPages : PageInfoValueType.LocalNumOfPages);
					}
					if (xTextPageInfoElement.FormatString != null && xTextPageInfoElement.FormatString.Length > 0)
					{
						if (flag6)
						{
							xTextPageInfoElement.FormatString = xTextPageInfoElement.FormatString.Replace("[%PageIndex%]", "[%LocalPageIndex%]");
							xTextPageInfoElement.FormatString = xTextPageInfoElement.FormatString.Replace("[%NumOfPages%]", "[%LocalNumOfPages%]");
						}
						else
						{
							xTextPageInfoElement.FormatString = xTextPageInfoElement.FormatString.Replace("[%LocalPageIndex%]", "[%PageIndex%]");
							xTextPageInfoElement.FormatString = xTextPageInfoElement.FormatString.Replace("[%LocalNumOfPages%]", "[%NumOfPages%]");
						}
					}
				}
			}
			xTextDocument6.z0vek(p0: false);
		}
		return z0ZzZzclh2;
	}

	private static int z0tek(XTextTableRowElement p0)
	{
		int num = -1;
		if (z0jtk == null)
		{
			z0jtk = new Dictionary<int, int>();
		}
		if (z0jtk.ContainsKey(p0.z0grk()))
		{
			num = z0jtk[p0.z0grk()];
		}
		else
		{
			num = p0.z0juk();
			z0jtk[p0.z0grk()] = num;
		}
		return num;
	}

	internal static List<int> z0tek(string p0)
	{
		if (p0 == null || p0.Length == 0)
		{
			return null;
		}
		List<int> list = new List<int>();
		int i = -2147483648;
		int num = -2147483648;
		string[] array = p0.Split(',');
		for (int j = 0; j < array.Length; j++)
		{
			string[] array2 = array[j].Split('-');
			if (array2.Length == 2 && int.TryParse(array2[0], out i) && int.TryParse(array2[1], out num))
			{
				for (int num2 = ((i < num) ? 1 : (-1)); (i <= num && num2 == 1) || (i >= num && num2 == -1); i += num2)
				{
					if (!list.Contains(i))
					{
						list.Add(i);
					}
				}
			}
			else if (array2.Length == 1 && int.TryParse(array2[0], out i) && !list.Contains(i))
			{
				list.Add(i);
			}
		}
		if (list.Count == 0)
		{
			return null;
		}
		return list;
	}

	public static XTextTableCellElement z0tek(XTextTableCellElement p0, TableRowCloneType p1)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("srcElement");
		}
		XTextTableCellElement xTextTableCellElement = null;
		switch (p1)
		{
		case TableRowCloneType.Default:
			xTextTableCellElement = (XTextTableCellElement)p0.z0lr(p0: false);
			break;
		case TableRowCloneType.Complete:
			xTextTableCellElement = (XTextTableCellElement)p0.z0lr(p0: true);
			break;
		case TableRowCloneType.ContentWithClearField:
		{
			xTextTableCellElement = (XTextTableCellElement)p0.z0lr(p0: true);
			using (zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = xTextTableCellElement.z0be().z0ltk())
			{
				while (z0bpk.MoveNext())
				{
					XTextElement current = z0bpk.Current;
					if (current is XTextContainerElement)
					{
						((XTextContainerElement)current).z0rrk();
					}
					if (current is XTextFieldElementBase)
					{
						((XTextFieldElementBase)current).z0be().Clear();
						if (current is XTextInputFieldElementBase)
						{
							((XTextInputFieldElementBase)current).InnerValue = null;
						}
					}
				}
			}
			break;
		}
		case TableRowCloneType.ClearDirectContentAndFieldContent:
		{
			xTextTableCellElement = (XTextTableCellElement)p0.z0lr(p0: true);
			for (int num = xTextTableCellElement.z0be().Count - 1; num >= 0; num--)
			{
				XTextElement xTextElement = xTextTableCellElement.z0be()[num];
				if (xTextElement is XTextFieldElementBase)
				{
					XTextFieldElementBase obj = (XTextFieldElementBase)xTextElement;
					obj.z0be().Clear();
					if (obj is XTextInputFieldElementBase)
					{
						((XTextInputFieldElementBase)xTextElement).InnerValue = null;
					}
				}
				else if (xTextElement is XTextCharElement || xTextElement is XTextObjectElement)
				{
					xTextTableCellElement.z0be().RemoveAt(num);
					xTextElement.Dispose();
				}
			}
			break;
		}
		}
		if (xTextTableCellElement != null)
		{
			foreach (XTextElement item in new z0ZzZzkxj(xTextTableCellElement, p1: true))
			{
				if (item is XTextContainerElement)
				{
					((XTextContainerElement)item).Modified = false;
				}
				else if (item is XTextCheckBoxElementBase)
				{
					((XTextCheckBoxElementBase)item).Modified = false;
				}
				else if (item is z0ZzZznxj)
				{
					z0ZzZznxj z0ZzZznxj2 = (z0ZzZznxj)item;
					if (p1 == TableRowCloneType.ContentWithClearField)
					{
						z0ZzZznxj2.z0qy();
					}
					z0ZzZznxj2.Modified = false;
				}
			}
			if (p1 == TableRowCloneType.ClearDirectContentAndFieldContent)
			{
				for (int num2 = xTextTableCellElement.z0be().Count - 1; num2 >= 0; num2--)
				{
					XTextElement xTextElement3 = xTextTableCellElement.z0be()[num2];
					if (xTextElement3 is XTextParagraphFlagElement && xTextElement3.z0ke() != null && xTextElement3.z0ke() is XTextParagraphFlagElement)
					{
						xTextTableCellElement.z0be().RemoveAt(num2);
						xTextElement3.Dispose();
					}
				}
			}
		}
		if (p0.z0pu_jiejie20260327142557().CloneWithoutLogicDeletedContent)
		{
			z0ZzZzafh.z0uek(xTextTableCellElement.z0be());
		}
		xTextTableCellElement.RowSpan = 1;
		xTextTableCellElement.z0nu(p0.z0krk());
		xTextTableCellElement.z0rek((XTextTableCellElement)null);
		if (xTextTableCellElement.z0utk != null)
		{
			((XTextContentElement)xTextTableCellElement).z0oek().z0pek = null;
			((XTextContentElement)xTextTableCellElement).z0oek().z0mek = null;
		}
		xTextTableCellElement.z0gu();
		if (p0.z0be().Count > 0)
		{
			xTextTableCellElement.z0be().LastElement.z0oek(p0.z0be().LastElement.z0pek());
			if (xTextTableCellElement.z0be().LastElement is XTextParagraphFlagElement)
			{
				((XTextParagraphFlagElement)xTextTableCellElement.z0be().LastElement).z0rek(p0: false);
			}
		}
		return xTextTableCellElement;
	}

	internal static z0ZzZzcdh z0yek(byte[] p0)
	{
		if (p0 == null || p0.Length < 2)
		{
			throw new ArgumentException("无效的JPEG二进制数据（空或长度不足）");
		}
		if (p0[0] != 255 || p0[1] != 216)
		{
			throw new ArgumentException("不是有效的JPEG文件（缺少SOI标记）");
		}
		int i = 2;
		int num = p0.Length;
		while (i < num - 2)
		{
			for (; i < num && p0[i] == 255; i++)
			{
			}
			if (i >= num)
			{
				break;
			}
			byte b = p0[i];
			i++;
			if (b != 192 && b != 194)
			{
				if (i + 1 >= num)
				{
					throw new InvalidOperationException("JPEG标记段长度解析失败");
				}
				int num2 = (p0[i] << 8) | p0[i + 1];
				i += num2;
				continue;
			}
			if (i + 6 >= num)
			{
				throw new InvalidOperationException("JPEG SOF段数据不完整");
			}
			i += 3;
			int num3 = (p0[i] << 8) | p0[i + 1];
			i += 2;
			int num4 = (p0[i] << 8) | p0[i + 1];
			if (num3 <= 0 || num4 <= 0)
			{
				throw new InvalidOperationException("解析到无效的JPEG尺寸");
			}
			return new z0ZzZzcdh(num4, num3);
		}
		throw new InvalidOperationException("未在JPEG数据中找到尺寸信息");
	}

	internal static void z0tek(XAttributeList p0, string p1, string p2)
	{
		XAttribute xAttribute = p0.z0eek(p1);
		if (xAttribute == null)
		{
			xAttribute = new XAttribute(p1, p2);
			p0.Add(xAttribute);
		}
		else
		{
			xAttribute.z0rek(p2);
		}
	}

	internal static void z0tek(z0ZzZzvbj p0, string p1, ref string p2, ref string p3)
	{
		int num = p1.IndexOf(p0.z0ov().z0tek());
		if (num > 0 && string.IsNullOrEmpty(p0.z0lrk()))
		{
			p2 = p1.Substring(0, num);
			p3 = p1.Substring(num + 1);
		}
		else
		{
			p2 = p1;
			p3 = null;
		}
	}

	private static int z0yek(string p0)
	{
		int num = 0;
		int num2 = 0;
		while ((num2 = p0.IndexOf('{', num2)) != -1)
		{
			if (num2 + 1 < p0.Length && p0[num2 + 1] != '{')
			{
				num++;
			}
			num2++;
		}
		return num;
	}

	public static void z0tek(ContentChangedEventArgs p0)
	{
	}

	public static void z0eek(XTextContainerElement p0, bool p1, bool p2, Action<XTextElement> p3)
	{
		if (p3 == null)
		{
			throw new ArgumentNullException("handler");
		}
		if (p0 == null)
		{
			throw new ArgumentNullException("rootElement");
		}
		if (p0.z0ntk != null && p0.z0ntk.Count != 0)
		{
			if (p2)
			{
				p3(p0);
			}
			z0rek(p0, p3, p1);
		}
	}

	public static byte[] z0tek(this XTextDocument p0, string p1, bool p2)
	{
		if (p2)
		{
			MemoryStream memoryStream = new MemoryStream();
			using (GZipStream gZipStream = new GZipStream(memoryStream, CompressionMode.Compress))
			{
				p0.z0ipk().z0rek(p0.z0jpk());
				p0.z0bek(gZipStream, p1, p2: false, null);
				gZipStream.Close();
			}
			byte[] result = memoryStream.ToArray();
			memoryStream.Close();
			memoryStream = null;
			return result;
		}
		z0ZzZztoj z0ZzZztoj2 = new z0ZzZztoj();
		using (GZipStream gZipStream2 = new GZipStream(z0ZzZztoj2, CompressionMode.Compress))
		{
			p0.z0ipk().z0rek(p0.z0jpk());
			p0.z0bek(gZipStream2, p1, p2: false, null);
			gZipStream2.Close();
		}
		z0ZzZztoj2.Close();
		return null;
	}

	public static string z0tek(z0ZzZzzwh p0)
	{
		return p0 switch
		{
			(z0ZzZzzwh)0 => "none", 
			(z0ZzZzzwh)1 => "copy", 
			(z0ZzZzzwh)2 => "move", 
			(z0ZzZzzwh)3 => "copyMove", 
			(z0ZzZzzwh)4 => "link", 
			(z0ZzZzzwh)(-2147483645) => "all", 
			_ => "none", 
		};
	}

	internal static bool z0tek(XTextContainerElement p0)
	{
		using (zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = p0.z0be().z0ltk())
		{
			while (z0bpk.MoveNext())
			{
				if (!z0bpk.Current.z0wtk())
				{
					return false;
				}
			}
		}
		return true;
	}

	public static void z0tek(XTextElement p0, XTextDocument p1, int p2 = 1)
	{
		string iD = p0.ID;
		if (iD != null && iD.Length > 0 && p1.z0ki(iD) != null)
		{
			int num = 0;
			string text = null;
			int num2 = iD.LastIndexOf("_");
			if (num2 == -1)
			{
				num = p2;
				text = p0.ID;
			}
			else
			{
				string text2 = p0.ID.Substring(num2 + 1);
				text = p0.ID.Substring(0, num2);
				int num3 = -2147483648;
				if (int.TryParse(text2, out num3))
				{
					num3 += p2;
					num = num3;
				}
				else
				{
					num = p2;
					text = p0.ID;
				}
			}
			while (p0.z0jr().z0ki(text + "_" + num) != null || (z0vek != null && z0vek.Contains(text + "_" + num)))
			{
				num++;
			}
			p0.ID = text + "_" + num;
			if (z0vek == null)
			{
				z0vek = new List<string>();
			}
			z0vek.Add(p0.ID);
		}
		if (p0 is XTextTableElement)
		{
			using (zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = ((XTextTableElement)p0).z0stk().z0ltk())
			{
				while (z0bpk.MoveNext())
				{
					z0tek((XTextTableRowElement)z0bpk.Current, p1, p2);
				}
				return;
			}
		}
		if (p0 is XTextTableRowElement)
		{
			using (zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = ((XTextTableRowElement)p0).z0rek().z0ltk())
			{
				while (z0bpk.MoveNext())
				{
					z0tek((XTextTableCellElement)z0bpk.Current, p1, p2);
				}
				return;
			}
		}
		if (!(p0 is XTextContainerElement))
		{
			return;
		}
		using zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = ((XTextContainerElement)p0).z0be().z0ltk();
		while (z0bpk.MoveNext())
		{
			z0tek(z0bpk.Current, p1, p2);
		}
	}

	public static string z0yek(this XTextDocument p0, string p1, bool p2)
	{
		p0.z0ipk().z0rek(p0.z0jpk());
		if (p2)
		{
			StringWriter stringWriter = new StringWriter();
			p0.z0bek(stringWriter, p1, p2: false, null);
			string result = stringWriter.ToString();
			stringWriter.Close();
			return result;
		}
		z0ZzZzuoj z0ZzZzuoj2 = new z0ZzZzuoj();
		p0.z0bek(z0ZzZzuoj2, p1, p2: false, null);
		z0ZzZzuoj2.Close();
		return null;
	}

	internal static z0ZzZzcgh z0tek(z0ZzZzcgh p0)
	{
		if (p0 == null)
		{
			return null;
		}
		z0ZzZzcgh z0ZzZzcgh2 = new z0ZzZzcgh();
		XTextElementList xTextElementList = new XTextElementList();
		foreach (z0ZzZzvgh item in p0)
		{
			if (!xTextElementList.Contains(item.z0nek()[0]))
			{
				z0ZzZzcgh2.Add(item);
				xTextElementList.Add(item.z0nek()[0]);
				continue;
			}
			foreach (z0ZzZzvgh item2 in z0ZzZzcgh2)
			{
				if (item2.z0nek()[0] == item.z0nek()[0])
				{
					item2.z0eek(item2.z0oek() + Environment.NewLine + item.z0oek());
					item2.z0rek(item.z0mek());
					item2.z0eek(item.z0pek());
					item2.z0eek(item.z0yek());
					item2.z0eek(item.z0eek());
					item2.z0tek(item.z0rek());
					item2.z0pek(item.z0bek());
					break;
				}
			}
		}
		return z0ZzZzcgh2;
	}

	internal static void z0tek(z0ZzZzvbj p0, string p1, z0ZzZzcbj p2, bool p3, bool p4)
	{
		if (string.IsNullOrEmpty(p1))
		{
			p2.Add(p0);
			return;
		}
		string p5 = null;
		string p6 = null;
		z0tek(p0, p1, ref p5, ref p6);
		IList list = p0.z0nek();
		bool flag = false;
		if (list != null && list.Count > 0)
		{
			foreach (z0ZzZzvbj item in list)
			{
				if (item.z0lrk() == p5)
				{
					flag = true;
					if (string.IsNullOrEmpty(p6))
					{
						p2.Add(item);
					}
					else
					{
						z0tek(item, p6, p2, p3, p4);
					}
					if (p3 && p2.Count > 0)
					{
						return;
					}
				}
			}
		}
		if (!(!flag && p4) || (p3 && p2.Count > 0))
		{
			return;
		}
		z0ZzZzvbj z0ZzZzvbj3 = z0tek(p0, p5);
		if (z0ZzZzvbj3 != null)
		{
			if (string.IsNullOrEmpty(p6))
			{
				p2.Add(z0ZzZzvbj3);
			}
			else
			{
				z0tek(z0ZzZzvbj3, p6, p2, p3, p4);
			}
		}
	}

	public static byte[] z0uek(this XTextDocument p0, string p1, bool p2)
	{
		if (p2)
		{
			MemoryStream memoryStream = new MemoryStream();
			p0.z0bek(memoryStream, p1, p2: false, null);
			byte[] result = memoryStream.ToArray();
			memoryStream.Close();
			memoryStream = null;
			return result;
		}
		z0ZzZztoj z0ZzZztoj2 = new z0ZzZztoj();
		p0.z0bek(z0ZzZztoj2, p1, p2: false, null);
		z0ZzZztoj2.Close();
		return null;
	}

	internal static z0ZzZzvbj z0tek(XTextElement p0, string p1, string p2, z0ZzZzrlh p3)
	{
		XTextDocument xTextDocument = p0.z0jr();
		if (xTextDocument == null || !xTextDocument.z0bu().EnableDataBinding)
		{
			return null;
		}
		z0ZzZzvbj z0ZzZzvbj2 = z0tek(p0, p1);
		if (z0ZzZzvbj2 != null && !z0ZzZzvbj2.z0eek())
		{
			string p4 = z0ZzZzvbj2.z0ov().z0eek(p2);
			z0ZzZzvbj z0ZzZzvbj3 = z0ZzZzvbj2.z0rek(p4, p1: true);
			if (z0ZzZzvbj3 == null)
			{
				z0ZzZzvbj3 = z0ZzZzvbj.z0qrk;
			}
			return z0ZzZzvbj3;
		}
		return z0ZzZzvbj.z0qrk;
	}

	internal static void z0tek(XTextDocument p0, z0ZzZzgbj p1, bool p2 = true)
	{
		DocumentViewOptions documentViewOptions = p0.z0iu();
		if (p1.BackgroundTextOutputMode == DCBackgroundTextOutputMode.None)
		{
			documentViewOptions.PrintBackgroundText = false;
			documentViewOptions.PreserveBackgroundTextWhenPrint = false;
		}
		else
		{
			documentViewOptions.PrintBackgroundText = true;
			documentViewOptions.PreserveBackgroundTextWhenPrint = true;
		}
		bool flag = !documentViewOptions.PreserveBackgroundTextWhenPrint && !documentViewOptions.PrintBackgroundText;
		bool flag2 = !documentViewOptions.IgnoreFieldBorderWhenPrint;
		XTextElementList xTextElementList = new XTextElementList();
		XTextElementList xTextElementList2 = new XTextElementList();
		XTextElementList xTextElementList3 = new XTextElementList();
		XTextElementList xTextElementList4 = new XTextElementList();
		z0tek(p0, xTextElementList2, xTextElementList, xTextElementList3, xTextElementList4);
		foreach (XTextCharElement item in xTextElementList4.z0xrk())
		{
			if (item.z0tek() == 32)
			{
				item.CharValue = '\u2002';
			}
		}
		foreach (XTextObjectElement item2 in xTextElementList.z0xrk())
		{
			if (item2.PrintVisibility == ElementVisibility.None)
			{
				item2.Visible = false;
				continue;
			}
			if (item2.PrintVisibility == ElementVisibility.Hidden)
			{
				DocumentContentStyle documentContentStyle = item2.z0xrk();
				DocumentContentStyle documentContentStyle2 = item2.z0xrk();
				DocumentContentStyle documentContentStyle3 = item2.z0xrk();
				DocumentContentStyle documentContentStyle4 = item2.z0xrk();
				Color color = (item2.z0xrk().BackgroundColor2 = Color.White);
				Color color2 = (documentContentStyle4.BackgroundColor = color);
				Color color4 = (documentContentStyle3.Color = color2);
				Color printBackColor = (documentContentStyle2.PrintColor = color4);
				documentContentStyle.PrintBackColor = printBackColor;
			}
			if (!(item2 is XTextHorizontalLineElement))
			{
				continue;
			}
			XTextHorizontalLineElement xTextHorizontalLineElement = item2 as XTextHorizontalLineElement;
			if (xTextHorizontalLineElement.LineLengthInCM > 0f)
			{
				float num = z0ZzZzrpk.z0eek(p0.PageSettings.z0prk(), GraphicsUnit.Document, GraphicsUnit.Millimeter);
				if (xTextHorizontalLineElement.LineLengthInCM > num / 10f)
				{
					xTextHorizontalLineElement.LineLengthInCM = num / 10f;
				}
			}
		}
		foreach (XTextContainerElement item3 in xTextElementList2.z0xrk())
		{
			if (item3.PrintVisibility == ElementVisibility.None)
			{
				item3.Visible = false;
				continue;
			}
			if (item3.PrintVisibility == ElementVisibility.Hidden)
			{
				DocumentContentStyle documentContentStyle5 = ((XTextElement)item3).z0xrk();
				DocumentContentStyle documentContentStyle6 = ((XTextElement)item3).z0xrk();
				DocumentContentStyle documentContentStyle7 = ((XTextElement)item3).z0xrk();
				DocumentContentStyle documentContentStyle8 = ((XTextElement)item3).z0xrk();
				Color color = (((XTextElement)item3).z0xrk().BackgroundColor2 = Color.White);
				Color color2 = (documentContentStyle8.BackgroundColor = color);
				Color color4 = (documentContentStyle7.Color = color2);
				Color printBackColor = (documentContentStyle6.PrintColor = color4);
				documentContentStyle5.PrintBackColor = printBackColor;
				if (item3 is XTextInputFieldElement xTextInputFieldElement)
				{
					xTextInputFieldElement.z0iek(p0: true);
					color4 = (xTextInputFieldElement.BackgroundTextColor = Color.White);
					printBackColor = (xTextInputFieldElement.BorderElementColor = color4);
					xTextInputFieldElement.TextColor = printBackColor;
				}
			}
			if (!(item3 is XTextInputFieldElement))
			{
				continue;
			}
			XTextInputFieldElement xTextInputFieldElement2 = item3 as XTextInputFieldElement;
			if (xTextInputFieldElement2.z0be().z0srk<XTextSignImageElement>() != null)
			{
				continue;
			}
			if (documentViewOptions.FieldBorderPrintVisibility == DCRenderVisibility.None)
			{
				DocumentViewOptions viewOptions = p1.DocumentOptions.ViewOptions;
				bool ignoreFieldBorderWhenPrint = (documentViewOptions.IgnoreFieldBorderWhenPrint = true);
				viewOptions.IgnoreFieldBorderWhenPrint = ignoreFieldBorderWhenPrint;
				string startBorderText = (xTextInputFieldElement2.EndBorderText = "");
				xTextInputFieldElement2.StartBorderText = startBorderText;
			}
			else if (documentViewOptions.FieldBorderPrintVisibility == DCRenderVisibility.Hidden)
			{
				DocumentViewOptions viewOptions2 = p1.DocumentOptions.ViewOptions;
				bool ignoreFieldBorderWhenPrint = (documentViewOptions.IgnoreFieldBorderWhenPrint = false);
				viewOptions2.IgnoreFieldBorderWhenPrint = ignoreFieldBorderWhenPrint;
				string text2 = '\u2002'.ToString();
				string startBorderText = (xTextInputFieldElement2.EndBorderText = text2);
				xTextInputFieldElement2.StartBorderText = startBorderText;
			}
			else if (documentViewOptions.FieldBorderPrintVisibility == DCRenderVisibility.Visible)
			{
				DocumentViewOptions viewOptions3 = p1.DocumentOptions.ViewOptions;
				bool ignoreFieldBorderWhenPrint = (documentViewOptions.IgnoreFieldBorderWhenPrint = false);
				viewOptions3.IgnoreFieldBorderWhenPrint = ignoreFieldBorderWhenPrint;
			}
			bool flag6 = z0tek(xTextInputFieldElement2);
			bool flag7 = xTextInputFieldElement2.z0so();
			if (flag && !flag7 && (xTextInputFieldElement2.z0be().Count == 0 || (flag6 && !p0.z0vtk().SecurityOptions.ShowLogicDeletedContent)))
			{
				if (xTextInputFieldElement2.SpecifyWidth == 0f && !string.IsNullOrEmpty(xTextInputFieldElement2.BackgroundText))
				{
					xTextInputFieldElement2.Visible = false;
					xTextInputFieldElement2.PrintVisibility = ElementVisibility.None;
				}
				else
				{
					xTextInputFieldElement2.BackgroundTextColor = Color.FromArgb(254, 254, 254);
					xTextInputFieldElement2.TextColor = Color.FromArgb(254, 254, 254);
				}
			}
			else if ((p1.BackgroundTextOutputMode == DCBackgroundTextOutputMode.None && ((XTextContainerElement)xTextInputFieldElement2).z0xek() == 0 && Math.Abs(xTextInputFieldElement2.SpecifyWidth) > 0f) || (((XTextContainerElement)xTextInputFieldElement2).z0xek() == 0 && string.IsNullOrEmpty(xTextInputFieldElement2.BackgroundText) && xTextInputFieldElement2.z0aek().z0htk))
			{
				if (p2)
				{
					XTextCharElement element = new XTextCharElement(' ', xTextInputFieldElement2);
					xTextInputFieldElement2.z0be().Add(element);
				}
			}
			else if (p1.BackgroundTextOutputMode == DCBackgroundTextOutputMode.Underline && string.IsNullOrEmpty(xTextInputFieldElement2.Text))
			{
				xTextInputFieldElement2.BackgroundTextColor = Color.FromArgb(254, 254, 254);
				((XTextElement)xTextInputFieldElement2).z0xrk().BorderBottom = true;
				((XTextElement)xTextInputFieldElement2).z0xrk().BorderWidth = 1f;
			}
			else if (p1.BackgroundTextOutputMode == DCBackgroundTextOutputMode.Whitespace && (xTextInputFieldElement2.z0be().Count == 0 || (flag6 && !p0.z0vtk().SecurityOptions.ShowLogicDeletedContent)))
			{
				xTextInputFieldElement2.BackgroundTextColor = Color.FromArgb(254, 254, 254);
				xTextInputFieldElement2.TextColor = Color.White;
			}
			if (flag2 && (xTextInputFieldElement2.FieldSettings == null || xTextInputFieldElement2.FieldSettings.z0nek() == InputFieldEditStyle.Text) && !((XTextInputFieldElementBase)xTextInputFieldElement2).z0yek() && !p0.z0pyk().z0be().Contains(xTextInputFieldElement2))
			{
				xTextInputFieldElement2.StartBorderText = '\u2002'.ToString();
				xTextInputFieldElement2.EndBorderText = '\u2002'.ToString();
			}
		}
		List<int> list = new List<int>();
		for (int num2 = p0.z0gnk().Styles.Count - 1; num2 >= 0; num2--)
		{
			z0ZzZzcok z0ZzZzcok2 = p0.z0gnk().Styles[num2];
			if (!z0ZzZzcok2.Underline && z0ZzZzcok2.BackgroundColor == Color.Transparent)
			{
				list.Add(num2);
			}
		}
		if (list.Count > 0)
		{
			foreach (XTextParagraphFlagElement item4 in xTextElementList3.z0xrk())
			{
				if (item4.z0xrk().ParagraphListStyle == ParagraphListStyle.ListNumberStyleArabic3)
				{
					item4.z0xrk().ParagraphListStyle = ParagraphListStyle.ListNumberStyle;
				}
				XTextElementList xTextElementList5 = item4.z0ji().z0be();
				int num3 = xTextElementList5.z0bek(item4);
				if (num3 > 0)
				{
					int num4 = num3 - 1;
					while (num4 >= 0 && xTextElementList5[num4] is XTextCharElement { z0bek: '\u2002' } xTextCharElement2 && (xTextCharElement2.z0buk < 0 || list.Contains(xTextCharElement2.z0buk)))
					{
						xTextElementList5.RemoveAt(num4);
						num4--;
					}
				}
			}
		}
		z0ZzZzzej z0ZzZzzej2 = p0.z0xyk().z0ju();
		if (z0ZzZzzej2 != null && z0ZzZzzej2.z0uek() && z0ZzZzzej2.z0yek() && (((XTextContainerElement)p0.z0xyk()).z0zek() is XTextTableElement || (((XTextContainerElement)p0.z0xyk()).z0zek() is XTextParagraphFlagElement && ((XTextContainerElement)p0.z0xyk()).z0zek().z0ke() is XTextTableElement)))
		{
			XTextParagraphFlagElement xTextParagraphFlagElement2 = new XTextParagraphFlagElement();
			xTextParagraphFlagElement2.z0bt(p0);
			XTextStringElement xTextStringElement = new XTextStringElement();
			xTextStringElement.z0bt(p0);
			xTextStringElement.Text = "  ";
			p0.z0xyk().z0be().Add(xTextStringElement);
			p0.z0xyk().z0be().Add(xTextParagraphFlagElement2);
		}
		p0.z0se();
	}

	public static Dictionary<string, object> z0tek(string[] p0)
	{
		if (p0 != null && p0.Length != 0)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			for (int i = 0; i < p0.Length; i += 2)
			{
				string text = p0[i];
				string text2 = p0[i + 1];
				if (text2 == null || text2.Length == 0)
				{
					continue;
				}
				if (text == null || text.Length == 0)
				{
					dictionary[z0ZzZzvwh.z0iek] = text2;
					continue;
				}
				text = text.Trim().ToLower();
				switch (text)
				{
				case "text/plain":
					if (text2.StartsWith(z0irk, StringComparison.Ordinal))
					{
						dictionary[z0ZzZztcj.z0tek()] = text2.Substring(z0irk.Length);
						break;
					}
					dictionary[z0ZzZzvwh.z0eek] = text2;
					dictionary[z0ZzZzvwh.z0iek] = text2;
					break;
				case "text/rtf":
					dictionary[z0ZzZzvwh.z0yek] = text2;
					break;
				case "text/html":
					dictionary[z0ZzZzvwh.z0uek] = text2;
					break;
				case "image/png":
				case "image/jpg":
				case "image/jpeg":
				case "image/bmp":
				case "image/gif":
				{
					byte[] array = z0ZzZzpmk.ParseEmitImageSource(text2);
					if (array != null)
					{
						dictionary[z0ZzZzvwh.z0rek] = new z0ZzZzrfh(array);
					}
					break;
				}
				case "html format":
					dictionary[z0ZzZzvwh.z0uek] = text2;
					break;
				case "rich text format":
					dictionary[z0ZzZzvwh.z0yek] = text2;
					break;
				default:
					dictionary[text] = text2;
					break;
				}
			}
			if (dictionary.ContainsKey(z0ZzZzvwh.z0uek))
			{
				string text3 = (string)dictionary[z0ZzZzvwh.z0uek];
				int num = text3.IndexOf("<!--NX2023:", 0, 30);
				if (num >= 0)
				{
					int num2 = text3.IndexOf("**-->");
					if (num2 > 0)
					{
						if (dictionary.ContainsKey(z0ZzZztcj.z0tek()))
						{
							text3 = text3.Substring(num2 + 3);
							dictionary[z0ZzZzvwh.z0uek] = text3;
						}
						else
						{
							string p1 = text3.Substring(num + 11, num2 - num - 11);
							p1 = z0ZzZztwh.z0rek(p1);
							text3 = text3.Substring(num2 + 5);
							dictionary[z0ZzZzvwh.z0uek] = text3;
							dictionary[z0ZzZztcj.z0tek()] = p1;
						}
					}
				}
			}
			return dictionary;
		}
		return null;
	}

	public static void z0tek(XTextTableRowElement p0, z0ZzZzbdh p1, z0ZzZzvxj p2)
	{
		string p3 = "$DCADVISE$";
		if (!p0.z0qr(p3))
		{
			return;
		}
		string[] array = p0.z0zwk(p3).Split(' ');
		if (array.Length != 3)
		{
			return;
		}
		z0ZzZzudh z0ZzZzudh2 = new z0ZzZzudh(Color.Black);
		DashStyle p4 = DashStyle.Solid;
		if (Enum.TryParse<DashStyle>(array[0], true, out p4))
		{
			z0ZzZzudh2.z0eek(p4);
		}
		z0ZzZzudh2.z0eek(z0ZzZzlok.z0eek(array[1], Color.Black));
		float p5 = 1f;
		if (float.TryParse(array[2].Replace("px", ""), out p5))
		{
			z0ZzZzudh2.z0eek(p5);
		}
		bool flag = false;
		XTextTableCellElement xTextTableCellElement = p0.z0rek()[0] as XTextTableCellElement;
		if (xTextTableCellElement != null && xTextTableCellElement.z0nek())
		{
			flag = true;
		}
		if (!flag)
		{
			z0ZzZzpdh p6 = new z0ZzZzpdh(p1.z0tek(), p1.z0yek() + p1.z0iek() / 2f);
			z0ZzZzpdh p7 = new z0ZzZzpdh(p1.z0tek() + p1.z0uek(), p1.z0yek() + p1.z0iek() / 2f);
			p2.z0gyk.z0eek(z0ZzZzudh2, p6, p7);
		}
		else
		{
			float num = p1.z0yek() + ((XTextElement)xTextTableCellElement).z0xrk().PaddingTop;
			float num2 = xTextTableCellElement.GridLine.z0zek();
			for (float num3 = p1.z0nek() + 1f; num + num2 <= num3; num += num2)
			{
				float p8 = num + num2 / 2f;
				z0ZzZzpdh p9 = new z0ZzZzpdh(p1.z0tek(), p8);
				z0ZzZzpdh p10 = new z0ZzZzpdh(p1.z0tek() + p1.z0uek(), p8);
				p2.z0gyk.z0eek(z0ZzZzudh2, p9, p10);
			}
		}
		z0ZzZzudh2.Dispose();
	}

	private static void z0tek(DateTimeFormatInfo p0, DCBooleanValue p1)
	{
		if (p0 == null)
		{
			return;
		}
		string text = "eXl5eS9NL2QNCnl5eXktTS1kDQp5eXl5Lk0uZA0KeXl5eS9NTS9kZA0KeXl5eS1NTS1kZA0KeXl5eS5NTS5kZA0KeXkvTS9kDQp5eS1NLWQNCnl5Lk0uZA0KeXkvTU0vZGQ=";
		string text2 = "eXl5eSflubQnTSfmnIgnZCfml6UnDQp5eXl5J+W5tCdNJ+aciCdkJ+aXpScsIGRkZGQNCmRkZGQsIHl5eXkn5bm0J00n5pyIJ2Qn5pelJw0KeXl5eeW5tE1NTWTml6UNCnl5eXnlubRNTU1k5pelLCBkZGRk";
		string text3 = "eXl5eSflubQnTSfmnIgnZCfml6UnIEg6bW0NCnl5eXkn5bm0J00n5pyIJ2Qn5pelJyBISDptbQ0KeXl5eSflubQnTSfmnIgnZCfml6UnIHR0IGg6bW0NCnl5eXkn5bm0J00n5pyIJ2Qn5pelJyB0dCBoaDptbQ0KeXl5eSflubQnTSfmnIgnZCfml6UnLCBkZGRkIEg6bW0NCnl5eXkn5bm0J00n5pyIJ2Qn5pelJywgZGRkZCBISDptbQ0KeXl5eSflubQnTSfmnIgnZCfml6UnLCBkZGRkIHR0IGg6bW0NCnl5eXkn5bm0J00n5pyIJ2Qn5pelJywgZGRkZCB0dCBoaDptbQ0KZGRkZCwgeXl5eSflubQnTSfmnIgnZCfml6UnIEg6bW0NCmRkZGQsIHl5eXkn5bm0J00n5pyIJ2Qn5pelJyBISDptbQ0KZGRkZCwgeXl5eSflubQnTSfmnIgnZCfml6UnIHR0IGg6bW0NCmRkZGQsIHl5eXkn5bm0J00n5pyIJ2Qn5pelJyB0dCBoaDptbQ0KeXl5eeW5tE1NTWTml6UgSDptbQ0KeXl5eeW5tE1NTWTml6UgSEg6bW0NCnl5eXnlubRNTU1k5pelIHR0IGg6bW0NCnl5eXnlubRNTU1k5pelIHR0IGhoOm1tDQp5eXl55bm0TU1NZOaXpSwgZGRkZCBIOm1tDQp5eXl55bm0TU1NZOaXpSwgZGRkZCBISDptbQ0KeXl5eeW5tE1NTWTml6UsIGRkZGQgdHQgaDptbQ0KeXl5eeW5tE1NTWTml6UsIGRkZGQgdHQgaGg6bW0=";
		string text4 = "eXl5eSflubQnTSfmnIgnZCfml6UnIEg6bW06c3MNCnl5eXkn5bm0J00n5pyIJ2Qn5pelJyBISDptbTpzcw0KeXl5eSflubQnTSfmnIgnZCfml6UnIHR0IGg6bW06c3MNCnl5eXkn5bm0J00n5pyIJ2Qn5pelJyB0dCBoaDptbTpzcw0KeXl5eSflubQnTSfmnIgnZCfml6UnLCBkZGRkIEg6bW06c3MNCnl5eXkn5bm0J00n5pyIJ2Qn5pelJywgZGRkZCBISDptbTpzcw0KeXl5eSflubQnTSfmnIgnZCfml6UnLCBkZGRkIHR0IGg6bW06c3MNCnl5eXkn5bm0J00n5pyIJ2Qn5pelJywgZGRkZCB0dCBoaDptbTpzcw0KZGRkZCwgeXl5eSflubQnTSfmnIgnZCfml6UnIEg6bW06c3MNCmRkZGQsIHl5eXkn5bm0J00n5pyIJ2Qn5pelJyBISDptbTpzcw0KZGRkZCwgeXl5eSflubQnTSfmnIgnZCfml6UnIHR0IGg6bW06c3MNCmRkZGQsIHl5eXkn5bm0J00n5pyIJ2Qn5pelJyB0dCBoaDptbTpzcw0KeXl5eeW5tE1NTWTml6UgSDptbTpzcw0KeXl5eeW5tE1NTWTml6UgSEg6bW06c3MNCnl5eXnlubRNTU1k5pelIHR0IGg6bW06c3MNCnl5eXnlubRNTU1k5pelIHR0IGhoOm1tOnNzDQp5eXl55bm0TU1NZOaXpSwgZGRkZCBIOm1tOnNzDQp5eXl55bm0TU1NZOaXpSwgZGRkZCBISDptbTpzcw0KeXl5eeW5tE1NTWTml6UsIGRkZGQgdHQgaDptbTpzcw0KeXl5eeW5tE1NTWTml6UsIGRkZGQgdHQgaGg6bW06c3M=";
		string[] array = Encoding.UTF8.GetString(Convert.FromBase64String(text)).Split("\r\n");
		string[] array2 = Encoding.UTF8.GetString(Convert.FromBase64String(text2)).Split("\r\n");
		string[] array3 = Encoding.UTF8.GetString(Convert.FromBase64String(text3)).Split("\r\n");
		string[] array4 = Encoding.UTF8.GetString(Convert.FromBase64String(text4)).Split("\r\n");
		p0.SetAllDateTimePatterns(array, 'd');
		p0.SetAllDateTimePatterns(array2, 'D');
		p0.SetAllDateTimePatterns(array3, 't');
		p0.SetAllDateTimePatterns(array4, 'T');
		if (p1 == DCBooleanValue.Inherit)
		{
			return;
		}
		List<string> list = new List<string>();
		List<string> list2 = new List<string>();
		List<string> list3 = new List<string>();
		List<string> list4 = new List<string>();
		List<string> list5 = new List<string>();
		List<string> list6 = new List<string>();
		List<string> list7 = new List<string>();
		for (int i = 0; i < p0.AbbreviatedDayNames.Length; i++)
		{
			if (p1 == DCBooleanValue.True)
			{
				list.Add(p0.AbbreviatedDayNames[i].ToUpper());
			}
			else
			{
				list.Add(p0.AbbreviatedDayNames[i].ToLower());
			}
		}
		for (int j = 0; j < p0.AbbreviatedMonthGenitiveNames.Length; j++)
		{
			if (p1 == DCBooleanValue.True)
			{
				list2.Add(p0.AbbreviatedMonthGenitiveNames[j].ToUpper());
			}
			else
			{
				list2.Add(p0.AbbreviatedMonthGenitiveNames[j].ToLower());
			}
		}
		for (int k = 0; k < p0.AbbreviatedMonthNames.Length; k++)
		{
			if (p1 == DCBooleanValue.True)
			{
				list3.Add(p0.AbbreviatedMonthNames[k].ToUpper());
			}
			else
			{
				list3.Add(p0.AbbreviatedMonthNames[k].ToLower());
			}
		}
		for (int l = 0; l < p0.DayNames.Length; l++)
		{
			if (p1 == DCBooleanValue.True)
			{
				list4.Add(p0.DayNames[l].ToUpper());
			}
			else
			{
				list4.Add(p0.DayNames[l].ToLower());
			}
		}
		for (int m = 0; m < p0.MonthGenitiveNames.Length; m++)
		{
			if (p1 == DCBooleanValue.True)
			{
				list5.Add(p0.MonthGenitiveNames[m].ToUpper());
			}
			else
			{
				list5.Add(p0.MonthGenitiveNames[m].ToLower());
			}
		}
		for (int n = 0; n < p0.MonthNames.Length; n++)
		{
			if (p1 == DCBooleanValue.True)
			{
				list6.Add(p0.MonthNames[n].ToUpper());
			}
			else
			{
				list6.Add(p0.MonthNames[n].ToLower());
			}
		}
		for (int num = 0; num < p0.ShortestDayNames.Length; num++)
		{
			if (p1 == DCBooleanValue.True)
			{
				list7.Add(p0.ShortestDayNames[num].ToUpper());
			}
			else
			{
				list7.Add(p0.ShortestDayNames[num].ToLower());
			}
		}
		p0.AbbreviatedDayNames = list.ToArray();
		p0.AbbreviatedMonthGenitiveNames = list2.ToArray();
		p0.AbbreviatedMonthNames = list3.ToArray();
		p0.DayNames = list4.ToArray();
		p0.MonthGenitiveNames = list5.ToArray();
		p0.MonthNames = list6.ToArray();
		p0.ShortestDayNames = list7.ToArray();
	}

	private static JsonElement z0tek(JsonElement p0, string p1)
	{
		if (p1 == null || p1.Length == 0)
		{
			return p0;
		}
		if (p0.ValueKind != JsonValueKind.Object)
		{
			return p0;
		}
		do
		{
			int num = p1.IndexOf('.');
			string text = p1.Trim();
			if (num > 0)
			{
				text = p1.Substring(0, num).Trim();
				p1 = p1.Substring(num + 1).Trim();
			}
			else
			{
				p1 = null;
			}
			JsonElement.ObjectEnumerator objectEnumerator = p0.EnumerateObject();
			while (objectEnumerator.MoveNext())
			{
				JsonProperty current = objectEnumerator.Current;
				if (current.NameEquals(text))
				{
					if (p1 == null)
					{
						return current.Value;
					}
					p0 = current.Value;
					break;
				}
			}
		}
		while (p1 != null);
		return default(JsonElement);
	}

	private static int z0tek(Type p0)
	{
		if (p0 == typeof(byte))
		{
			return 1;
		}
		if (p0 == typeof(sbyte))
		{
			return 1;
		}
		if (p0 == typeof(char))
		{
			return 2;
		}
		if (p0 == typeof(bool))
		{
			return 1;
		}
		if (p0 == typeof(short))
		{
			return 2;
		}
		if (p0 == typeof(ushort))
		{
			return 2;
		}
		if (p0 == typeof(int))
		{
			return 4;
		}
		if (p0 == typeof(uint))
		{
			return 4;
		}
		if (p0 == typeof(long))
		{
			return 8;
		}
		if (p0 == typeof(ulong))
		{
			return 8;
		}
		if (p0 == typeof(float))
		{
			return 4;
		}
		if (p0 == typeof(double))
		{
			return 8;
		}
		if (p0 == typeof(DateTime))
		{
			return 8;
		}
		if (p0 == typeof(decimal))
		{
			return 16;
		}
		_ = p0 == typeof(string);
		return 4;
	}

	private static int z0yek(XTextTableRowElement p0)
	{
		int num = -1;
		if (z0frk == null)
		{
			z0frk = new Dictionary<int, int>();
		}
		if (z0frk.ContainsKey(p0.z0grk()))
		{
			num = z0frk[p0.z0grk()];
		}
		else
		{
			num = p0.z0je();
			z0frk[p0.z0grk()] = num;
		}
		return num;
	}

	[CompilerGenerated]
	internal static bool z0uek(string p0)
	{
		if (p0 != null)
		{
			return p0.Trim().Length > 0;
		}
		return false;
	}

	internal static bool z0tek(XTextDocument p0)
	{
		XTextTableElement xTextTableElement = z0yek(p0);
		if (xTextTableElement == null || ((XTextElement)xTextTableElement).z0atk() != PageContentPartyStyle.Body)
		{
			return false;
		}
		XTextTableRowElement xTextTableRowElement = (XTextTableRowElement)xTextTableElement.z0stk().LastElement;
		float num = 0f;
		for (int num2 = p0.z0suk().Count - 1; num2 >= 0; num2--)
		{
			z0ZzZzwrj z0ZzZzwrj2 = p0.z0suk()[num2];
			float num3 = z0ZzZzwrj2.z0irk();
			if (((XTextElement)xTextTableRowElement).z0ltk() + xTextTableRowElement.Height >= num3 + 2f)
			{
				float num4 = z0ZzZzwrj2.z0urk();
				if (z0ZzZzwrj2.z0krk().z0iek() > 0f)
				{
					num4 -= z0ZzZzwrj2.z0krk().z0iek();
				}
				float num5 = num4 + num3 - (((XTextElement)xTextTableRowElement).z0ltk() + xTextTableRowElement.Height);
				XTextElementList xTextElementList = new XTextElementList();
				while ((double)num5 > (double)num * 1.1)
				{
					XTextTableRowElement xTextTableRowElement2 = xTextTableRowElement.z0zek();
					xTextTableRowElement2.NewPage = false;
					xTextTableRowElement2.z0nu(xTextTableElement);
					xTextTableRowElement2.z0bt(p0);
					xTextTableRowElement2.z0nu(xTextTableElement);
					z0ZzZzafh.z0rek(p0, xTextTableRowElement2.z0rek(), p2: false);
					using (zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = xTextTableRowElement2.z0rek().z0ltk())
					{
						while (z0bpk.MoveNext())
						{
							((XTextTableCellElement)z0bpk.Current).z0ct();
						}
					}
					xTextTableRowElement2.z0hrk();
					num = xTextTableRowElement2.Height;
					if (num5 < num - 1f)
					{
						break;
					}
					xTextElementList.Add(xTextTableRowElement2);
					num5 -= num;
				}
				if (xTextElementList.Count <= 0)
				{
					break;
				}
				using (zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = xTextElementList.z0ltk())
				{
					while (z0bpk.MoveNext())
					{
						XTextTableRowElement xTextTableRowElement3 = (XTextTableRowElement)z0bpk.Current;
						xTextTableRowElement3.z0nu(xTextTableElement);
						xTextTableRowElement3.z0bt(p0);
						xTextTableElement.z0stk().Add(xTextTableRowElement3);
					}
				}
				p0.z0xyk().z0ork();
				p0.z0krk();
				return true;
			}
		}
		return false;
	}

	internal static XTextTableElement z0yek(XTextDocument p0)
	{
		for (int num = p0.z0xyk().z0be().Count - 1; num >= 0; num--)
		{
			XTextElement xTextElement = p0.z0xyk().z0be()[num];
			if (xTextElement is XTextTableElement)
			{
				return (XTextTableElement)xTextElement;
			}
			if (!(xTextElement is XTextParagraphFlagElement) && (!(xTextElement is XTextCharElement) || !XTextCharElement.z0tek(((XTextCharElement)xTextElement).z0bek)))
			{
				break;
			}
		}
		return null;
	}

	public static string z0tek(z0ZzZzyhh p0, z0ZzZzyhh p1)
	{
		if (p0.z0rek() == p1.z0rek())
		{
			return z0yek(z0ZzZziok.z0mok()) switch
			{
				0 => z0ZzZziok.z0mok(), 
				1 => string.Format(z0ZzZziok.z0mok(), p1.z0yek()), 
				2 => string.Format(z0ZzZziok.z0mok(), p0.z0rek(), p1.z0rek()), 
				_ => z0ZzZziok.z0mok(), 
			};
		}
		return z0yek(z0ZzZziok.z0mik()) switch
		{
			0 => z0ZzZziok.z0mik(), 
			1 => string.Format(z0ZzZziok.z0mik(), p1.z0yek()), 
			2 => string.Format(z0ZzZziok.z0mik(), p0.z0rek(), p1.z0rek()), 
			_ => z0ZzZziok.z0mik(), 
		};
	}

	internal static z0ZzZzbbj z0uek(XTextDocument p0)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("document");
		}
		if (p0.z0lrk() is z0ZzZzbbj)
		{
			return (z0ZzZzbbj)p0.z0lrk();
		}
		z0ZzZzbbj z0ZzZzbbj2 = p0.z0utk() as z0ZzZzbbj;
		if (z0ZzZzbbj2 == null)
		{
			z0ZzZzbbj2 = new z0ZzZzbbj();
			if (p0.z0gpk() != null)
			{
				foreach (DocumentParameter item in p0.z0gpk())
				{
					z0ZzZzbbj2.z0eek(item.z0eek(), item.z0bek());
				}
			}
			if (p0.z0hmk() != null)
			{
				foreach (DocumentParameter item2 in p0.z0hmk())
				{
					z0ZzZzbbj2.z0eek(item2.z0eek(), item2.z0bek());
				}
			}
			p0.z0vek(z0ZzZzbbj2);
		}
		return z0ZzZzbbj2;
	}

	public static DateTime z0iek(string p0)
	{
		if (p0 == null || p0.Length == 0)
		{
			return z0ZzZzkfh.z0wrk;
		}
		return DateTime.ParseExact(p0, z0zrk, DateTimeFormatInfo.InvariantInfo, DateTimeStyles.AllowLeadingWhite | DateTimeStyles.AllowTrailingWhite);
	}

	internal static z0ZzZzvbj z0tek(z0ZzZzvbj p0, string p1)
	{
		if (p0.z0eek())
		{
			return null;
		}
		if (string.IsNullOrEmpty(p1))
		{
			throw new ArgumentNullException("name");
		}
		if (p0.z0tv() == DataSourceTreeNodeType.Text)
		{
			return null;
		}
		if (p0.z0nek() == null)
		{
			p0.z0eek(new z0ZzZzcbj());
		}
		object obj = p0.z0uv_jiejie20260327142557();
		if (obj is z0ZzZzoah)
		{
			if (obj is z0ZzZzsah)
			{
				z0ZzZzsah z0ZzZzsah2 = (z0ZzZzsah)obj;
				z0ZzZzfah z0ZzZzfah2 = z0ZzZzsah2.z0wg();
				if (p1[0] == '@')
				{
					string p2 = p1.Substring(1);
					z0ZzZzbsh z0ZzZzbsh2 = z0ZzZzsah2.z0sg().z0eek_jiejie20260327142557(p2);
					if (z0ZzZzbsh2 == null)
					{
						z0ZzZzbsh2 = z0ZzZzfah2.z0uek(p2);
						z0ZzZzsah2.z0sg().z0oek(z0ZzZzbsh2);
					}
					z0ZzZzvbj z0ZzZzvbj2 = new z0ZzZzvbj();
					z0ZzZzvbj2.z0eek(p0.z0ov());
					z0ZzZzvbj2.z0eek(p0);
					z0ZzZzvbj2.z0tek(p1);
					z0ZzZzvbj2.z0yv(z0ZzZzbsh2);
					z0ZzZzvbj2.z0eek((object)z0ZzZzbsh2.z0rh());
					z0ZzZzvbj2.z0bv_jiejie20260327142557(DataSourceTreeNodeType.Xml);
					p0.z0nek().Add(z0ZzZzvbj2);
					return z0ZzZzvbj2;
				}
				z0ZzZzsah z0ZzZzsah3 = null;
				foreach (z0ZzZzoah item in ((z0ZzZzoah)z0ZzZzsah2).z0tek())
				{
					if (item.z0th() == p1)
					{
						z0ZzZzsah3 = (z0ZzZzsah)item;
						break;
					}
				}
				z0ZzZzvbj z0ZzZzvbj3 = new z0ZzZzvbj();
				if (z0ZzZzsah3 == null)
				{
					z0ZzZzsah3 = z0ZzZzfah2.z0rek(p1);
					z0ZzZzsah2.z0if(z0ZzZzsah3);
					z0ZzZzvbj3.z0prk = true;
				}
				z0ZzZzvbj3.z0eek(p0.z0ov());
				z0ZzZzvbj3.z0eek(p0);
				z0ZzZzvbj3.z0tek(p1);
				z0ZzZzvbj3.z0yv(z0ZzZzsah3);
				z0ZzZzvbj3.z0bv_jiejie20260327142557(DataSourceTreeNodeType.Xml);
				z0ZzZzvbj3.z0eek((object)z0ZzZzsah3.z0rh());
				p0.z0nek().Add(z0ZzZzvbj3);
				return z0ZzZzvbj3;
			}
		}
		else if (p0.z0tv() == DataSourceTreeNodeType.List)
		{
			if (p0.z0nek() == null || p0.z0nek().Count == 0)
			{
				p0.z0mek();
				if (p0.z0nek() != null && p0.z0nek().Count > 0)
				{
					return p0.z0nek()[0].z0eek(p1, p1: false);
				}
			}
		}
		else if (obj is IDictionary && p0.z0tv() != DataSourceTreeNodeType.Entry)
		{
			IDictionary dictionary = (IDictionary)obj;
			z0ZzZzvbj z0ZzZzvbj4 = new z0ZzZzvbj();
			z0ZzZzvbj4.z0eek(p0.z0ov());
			z0ZzZzvbj4.z0eek(p0);
			z0ZzZzvbj4.z0tek(p1);
			z0ZzZzvbj4.z0yv(dictionary);
			z0ZzZzvbj4.z0iv(p1);
			z0ZzZzvbj4.z0rek(dictionary.IsReadOnly);
			z0ZzZzvbj4.z0bv_jiejie20260327142557(DataSourceTreeNodeType.Auto);
			p0.z0nek().Add(z0ZzZzvbj4);
			return z0ZzZzvbj4;
		}
		return null;
	}

	public static void z0tek(XTextDocument p0, XTextContainerElement p1, string p2)
	{
		z0ZzZzdxj z0ZzZzdxj2 = new z0ZzZzdxj();
		z0ZzZzdxj2.z0tek(p0: false);
		z0ZzZzdxj2.z0eek(p0: false);
		z0ZzZzdxj2.z0yek(p0: false);
		z0ZzZzdxj2.z0rek(p0: false);
		z0ZzZzdxj2.z0uek(p0: false);
		if (p1.z0yek(z0ZzZzdxj2) == p2)
		{
			return;
		}
		DocumentContentStyle documentContentStyle = p1.z0aek().z0yek();
		documentContentStyle.CreatorIndex = -1;
		documentContentStyle.DeleterIndex = -1;
		DocumentSecurityOptions securityOptions = p0.z0vtk().SecurityOptions;
		if (!securityOptions.EnablePermission || p0.z0muk() == null)
		{
			int styleIndex = p0.z0gnk().GetStyleIndex(documentContentStyle);
			p1.z0hrk(p2);
			using zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = p1.z0be().z0ltk();
			while (z0bpk.MoveNext())
			{
				XTextElement current = z0bpk.Current;
				if (!current.z0wtk())
				{
					current.z0oek(styleIndex);
				}
			}
			return;
		}
		z0ZzZzyhh z0ZzZzyhh2 = new z0ZzZzyhh();
		z0ZzZzyhh2.z0tek(p0.z0muk().z0zek());
		z0ZzZzyhh2.z0uek(p0.z0muk().z0yek());
		z0ZzZzyhh2.z0rek(p0.z0muk().z0tek());
		z0ZzZzyhh2.z0eek(p0.z0muk().z0rek());
		z0ZzZzyhh2.z0tek(DateTime.Now);
		z0ZzZzyhh2.z0eek(p0.z0muk().z0mek());
		z0ZzZzyhh2.z0iek(p0.z0muk().z0uek());
		z0ZzZzyhh2.z0rek(p0.z0syk().Count);
		int deleterIndex = z0ZzZzyhh2.z0pek();
		p0.z0syk().Add(z0ZzZzyhh2);
		if (securityOptions.EnableLogicDelete)
		{
			zzz.z0ZzZzjik<int, int> z0ZzZzjik2 = new zzz.z0ZzZzjik<int, int>();
			using zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = p1.z0be().z0ltk();
			while (z0bpk.MoveNext())
			{
				XTextElement current2 = z0bpk.Current;
				if (current2.z0xrk().DeleterIndex == -1)
				{
					if (!z0ZzZzjik2.z0yek().Contains(current2.z0pek()))
					{
						DocumentContentStyle documentContentStyle2 = current2.z0aek().z0yek();
						documentContentStyle2.DeleterIndex = deleterIndex;
						int styleIndex2 = p0.z0gnk().GetStyleIndex(documentContentStyle2);
						z0ZzZzjik2.z0rek(current2.z0pek(), styleIndex2);
						current2.z0oek(styleIndex2);
					}
					else
					{
						current2.z0oek(z0ZzZzjik2.z0tek(current2.z0pek()));
					}
				}
			}
		}
		else
		{
			p1.z0be().Clear();
		}
		documentContentStyle.CreatorIndex = z0ZzZzyhh2.z0pek();
		int styleIndex3 = p0.z0gnk().GetStyleIndex(documentContentStyle);
		XTextElementList xTextElementList = new XTextElementList();
		if (securityOptions.EnableLogicDelete)
		{
			using zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = p1.z0be().z0ltk();
			while (z0bpk.MoveNext())
			{
				XTextElement current3 = z0bpk.Current;
				if (current3.z0wtk())
				{
					xTextElementList.Add(current3);
				}
			}
		}
		XTextElementList xTextElementList2 = p1.z0zek(p2);
		if (xTextElementList2 != null && xTextElementList2.Count > 0)
		{
			using zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = xTextElementList2.z0ltk();
			while (z0bpk.MoveNext())
			{
				z0bpk.Current.z0oek(styleIndex3);
			}
		}
		p1.z0be().z0eek(0, xTextElementList);
		p1.z0oe();
	}

	internal static Tuple<string, XTextCharElement[]> z0iek(XTextDocument p0)
	{
		if (p0 == null)
		{
			return null;
		}
		return z0tek(p0.z0xyk().z0frk());
	}

	internal static void z0tek(XTextInputFieldElement p0, JsonElement p1)
	{
		if (p0 == null || p1.ValueKind != JsonValueKind.Object)
		{
			return;
		}
		foreach (JsonProperty item in p1.EnumerateObject())
		{
			switch (item.Name.ToLower())
			{
			case "elementid":
				p0.ID = z0ZzZzboj.z0xek(item.Value);
				break;
			case "inputprompt":
				p0.ToolTip = z0ZzZzboj.z0xek(item.Value);
				break;
			case "checkinfo":
				if (item.Value.ValueKind != JsonValueKind.Object)
				{
					break;
				}
				if (p0.ValidateStyle == null)
				{
					p0.ValidateStyle = new ValueValidateStyle();
				}
				foreach (JsonProperty item2 in item.Value.EnumerateObject())
				{
					switch (item2.Name.ToLower())
					{
					case "alertmax":
						p0.ValidateStyle.CheckMaxValue = z0ZzZzboj.z0rek(item2.Value, p1: false);
						break;
					case "alertmin":
						p0.ValidateStyle.CheckMinValue = z0ZzZzboj.z0rek(item2.Value, p1: false);
						break;
					case "textmax":
						p0.ValidateStyle.MaxLength = item2.z0yek(0);
						break;
					case "textmin":
						p0.ValidateStyle.MinLength = item2.z0yek(0);
						break;
					case "required":
						p0.ValidateStyle.Required = z0ZzZzboj.z0rek(item2.Value, p1: false);
						break;
					case "requiredtip":
						p0.ValidateStyle.CustomMessage = z0ZzZzboj.z0xek(item2.Value);
						break;
					case "datatype":
					{
						string text2 = item2.Value.GetString().ToLower();
						if (!(text2 == "date"))
						{
							if (text2 == "num")
							{
								p0.ValidateStyle.ValueType = ValueTypeStyle.Numeric;
							}
						}
						else
						{
							p0.ValidateStyle.ValueType = ValueTypeStyle.Date;
						}
						break;
					}
					case "elementclinicalmin":
						p0.ValidateStyle.MinValue = item2.z0yek(0f);
						break;
					case "elementclinicalmax":
						p0.ValidateStyle.MaxValue = item2.z0yek(0f);
						break;
					}
				}
				break;
			case "elementname":
				p0.Name = z0ZzZzboj.z0xek(item.Value);
				break;
			case "readonly":
				p0.UserEditable = z0ZzZzboj.z0rek(item.Value, p1: true);
				break;
			case "deleteable":
				p0.Deleteable = z0ZzZzboj.z0rek(item.Value, p1: true);
				break;
			case "inputtype":
			{
				if (item.Value.ValueKind != JsonValueKind.String)
				{
					break;
				}
				if (p0.FieldSettings == null)
				{
					p0.FieldSettings = new InputFieldSettings();
				}
				string text3 = item.Value.GetString().ToLower();
				switch (text3)
				{
				case "multipleselect":
				case "select":
					p0.FieldSettings.z0eek(InputFieldEditStyle.DropdownList);
					if (text3 == "multipleselect")
					{
						p0.FieldSettings.z0eek(p0: true);
					}
					break;
				case "date":
					p0.FieldSettings.z0eek(InputFieldEditStyle.Date);
					break;
				case "num":
					p0.FieldSettings.z0eek(InputFieldEditStyle.Numeric);
					break;
				}
				break;
			}
			case "items":
				if (p0.FieldSettings == null)
				{
					p0.FieldSettings = new InputFieldSettings();
					p0.FieldSettings.z0eek(new z0ZzZzsvj());
					p0.FieldSettings.z0zek().Items = new z0ZzZzdvj();
				}
				if (p0.FieldSettings.z0zek() == null)
				{
					p0.FieldSettings.z0eek(new z0ZzZzsvj());
					p0.FieldSettings.z0zek().Items = new z0ZzZzdvj();
				}
				if (p0.FieldSettings.z0zek().Items == null)
				{
					p0.FieldSettings.z0zek().Items = new z0ZzZzdvj();
				}
				p0.FieldSettings.z0zek().Items = new z0ZzZzdvj();
				if (item.Value.ValueKind != JsonValueKind.Array)
				{
					break;
				}
				foreach (JsonElement item3 in item.Value.EnumerateArray())
				{
					if (item3.ValueKind != JsonValueKind.Object)
					{
						continue;
					}
					bool flag = false;
					string strText = null;
					string strValue = null;
					foreach (JsonProperty item4 in item3.EnumerateObject())
					{
						string text = item4.Name.ToLower();
						if (!(text == "text"))
						{
							if (text == "value")
							{
								strValue = z0ZzZzboj.z0xek(item4.Value);
								flag = true;
							}
						}
						else
						{
							strText = z0ZzZzboj.z0xek(item4.Value);
							flag = true;
						}
					}
					if (flag)
					{
						p0.FieldSettings.z0zek().Items.Add(new ListItem(strText, strValue));
					}
				}
				break;
			default:
				if (item.Value.ValueKind != JsonValueKind.Array && item.Value.ValueKind != JsonValueKind.Object)
				{
					p0.z0dr(item.Name, z0ZzZzboj.z0xek(item.Value));
				}
				break;
			case "cascade":
				break;
			}
		}
	}

	internal static int z0tek(XTextTableElement p0, z0ZzZzrlh p1)
	{
		if (((XTextContainerElement)p0).z0ftk() == null)
		{
			return 0;
		}
		if (!(((XTextContainerElement)p0).z0ftk() is z0ZzZzvbj z0ZzZzvbj2) || z0ZzZzvbj2.z0eek() || !z0ZzZzvbj2.z0yek())
		{
			return 0;
		}
		if (z0ZzZzvbj2.z0nek() != null)
		{
			z0ZzZzvbj2.z0nek().Clear();
		}
		if (z0ZzZzvbj2.z0nek() == null || z0ZzZzvbj2.z0nek().Count == 0)
		{
			z0ZzZzvbj2.z0jrk();
		}
		int num = 0;
		XTextElementList xTextElementList = new XTextElementList();
		z0ZzZzvbj z0ZzZzvbj3 = null;
		int num2 = -1;
		using (zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = p0.z0srk().z0ltk())
		{
			while (z0bpk.MoveNext())
			{
				XTextTableColumnElement xTextTableColumnElement = (XTextTableColumnElement)z0bpk.Current;
				z0ZzZzvbj3 = z0tek(xTextTableColumnElement, xTextTableColumnElement.ValueBinding, p1);
				if (z0ZzZzvbj3 == null)
				{
					using (zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk2 = xTextTableColumnElement.z0eek().z0ltk())
					{
						while (z0bpk2.MoveNext())
						{
							XTextTableCellElement xTextTableCellElement = (XTextTableCellElement)z0bpk2.Current;
							xTextTableCellElement.z0cek(z0tek(xTextTableCellElement, xTextTableCellElement.ValueBinding, p1));
						}
					}
					continue;
				}
				num2 = xTextTableColumnElement.z0rek();
				break;
			}
		}
		if (z0ZzZzvbj3 != null && num2 >= 0)
		{
			z0ZzZzcbj z0ZzZzcbj2 = z0tek(z0ZzZzvbj2, z0ZzZzvbj3.z0lrk(), p2: false);
			if (z0ZzZzcbj2 == null || z0ZzZzcbj2.Count == 0)
			{
				return 0;
			}
			int num3 = num2;
			Dictionary<int, string> dictionary = new Dictionary<int, string>();
			foreach (z0ZzZzvbj item in z0ZzZzcbj2)
			{
				if (num3 >= p0.z0drk())
				{
					break;
				}
				if (item.z0nek() == null || item.z0nek().Count == 0)
				{
					item.z0jrk();
				}
				using (zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = (p0.z0srk()[num3] as XTextTableColumnElement).z0eek().z0ltk())
				{
					while (z0bpk.MoveNext())
					{
						XTextTableCellElement xTextTableCellElement2 = (XTextTableCellElement)z0bpk.Current;
						string text = null;
						if (num3 == num2)
						{
							if (xTextTableCellElement2.z0pr() && p0.z0jr().z0bek(xTextTableCellElement2.ValueBinding))
							{
								text = ((xTextTableCellElement2.ValueBinding != null) ? xTextTableCellElement2.ValueBinding.BindingPath : null);
								if (!dictionary.ContainsKey(xTextTableCellElement2.z0pek()))
								{
									dictionary.Add(xTextTableCellElement2.z0pek(), text);
								}
							}
							else if (!dictionary.ContainsKey(xTextTableCellElement2.z0pek()))
							{
								dictionary.Add(xTextTableCellElement2.z0pek(), null);
							}
						}
						else
						{
							text = dictionary[xTextTableCellElement2.z0pek()];
						}
						if (text == null || text.Length <= 0)
						{
							continue;
						}
						xTextTableCellElement2.z0cek(item.z0rek(text, p1: false));
						if (xTextTableCellElement2.z0ftk() != null && xTextTableCellElement2.z0ftk() is z0ZzZzvbj)
						{
							xTextElementList.Add(xTextTableCellElement2);
							string[] array = ((z0ZzZzvbj)xTextTableCellElement2.z0ftk()).z0nv().Split('/');
							if (array.Length == 2)
							{
								xTextTableCellElement2.z0dr("DCBINDINGHINT", array[0] + "_" + array[1]);
							}
							else if (array.Length == 3)
							{
								string p2 = array[0] + "_" + array[1] + (xTextTableCellElement2.z0drk().z0rek() - num2) + "_" + array[2];
								xTextTableCellElement2.z0dr("DCBINDINGHINT", p2);
							}
						}
					}
				}
				num3++;
			}
		}
		using (zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = xTextElementList.z0ltk())
		{
			while (z0bpk.MoveNext())
			{
				XTextTableCellElement xTextTableCellElement3 = (XTextTableCellElement)z0bpk.Current;
				if (xTextTableCellElement3.z0ftk() != null)
				{
					string p3 = Convert.ToString(((z0ZzZzvbj)xTextTableCellElement3.z0ftk()).z0tek());
					z0tek(xTextTableCellElement3, p3, p1.z0eek());
					num++;
				}
			}
		}
		p0.z0oe();
		return num;
	}

	internal static void z0tek(z0ZzZzdbj p0, FilterValueEventArgs p1)
	{
		XTextElementList xTextElementList = ((XTextTableElement)(p1.Value as XTextElementList)[0]).z0zek();
		XTextTableCellElement obj = xTextElementList[0] as XTextTableCellElement;
		int num = obj.z0pek();
		int num2 = obj.z0xek();
		XTextTableCellElement xTextTableCellElement = ((p0.z0yok() != null) ? p0.z0yok() : (p0.z0kok().z0irk()[0] as XTextTableCellElement));
		int num3 = xTextTableCellElement.z0pek();
		int num4 = xTextTableCellElement.z0xek();
		XTextTableElement xTextTableElement = xTextTableCellElement.z0gr();
		xTextTableCellElement.z0be().Clear();
		using (zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = obj.z0be().z0ltk())
		{
			while (z0bpk.MoveNext())
			{
				XTextElement current = z0bpk.Current;
				xTextTableCellElement.z0be().Add(current.z0lr(p0: true));
			}
		}
		xTextTableCellElement.z0oe();
		for (int i = 1; i < xTextElementList.Count; i++)
		{
			XTextTableCellElement xTextTableCellElement2 = xTextElementList[i] as XTextTableCellElement;
			int num5 = xTextTableCellElement2.z0pek() - num;
			int num6 = xTextTableCellElement2.z0xek() - num2;
			XTextTableCellElement xTextTableCellElement3 = xTextTableElement.z0nek(num3 + num5, num4 + num6, p2: false);
			if (xTextTableCellElement3 == null)
			{
				continue;
			}
			xTextTableCellElement3.z0be().Clear();
			using (zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = xTextTableCellElement2.z0be().z0ltk())
			{
				while (z0bpk.MoveNext())
				{
					XTextElement current2 = z0bpk.Current;
					xTextTableCellElement3.z0be().Add(current2.z0lr(p0: true));
				}
			}
			xTextTableCellElement3.z0oe();
		}
	}

	public static string z0tek(ValueFormatStyle p0, string p1, string p2, object p3)
	{
		if (p3 == null || DBNull.Value.Equals(p3))
		{
			return p2;
		}
		if (p1 == null)
		{
			p1 = string.Empty;
		}
		switch (p0)
		{
		case ValueFormatStyle.None:
			return Convert.ToString(p3);
		case ValueFormatStyle.Currency:
		{
			decimal num9 = default(decimal);
			bool flag4 = false;
			if (p3 is string)
			{
				string text9 = (string)p3;
				if (z0uek(text9))
				{
					try
					{
						flag4 = decimal.TryParse(text9, out num9);
					}
					catch
					{
					}
				}
			}
			else if (z0tek(p3) || p3 is bool)
			{
				num9 = Convert.ToDecimal(p3);
				flag4 = true;
			}
			if (flag4)
			{
				if (z0uek(p1))
				{
					return num9.ToString(p1);
				}
				return num9.ToString();
			}
			if (z0wrk)
			{
				return p3.ToString();
			}
			return p2;
		}
		case ValueFormatStyle.DateTime:
		{
			DateTime result3 = DateTime.MinValue;
			bool flag3 = false;
			if (p3 is string)
			{
				string text5 = (string)p3;
				if (text5 != null && text5.Length > 0)
				{
					flag3 = DateTime.TryParse(text5, out result3);
					if (!flag3)
					{
						flag3 = DateTime.TryParseExact(text5, p1, null, DateTimeStyles.AllowWhiteSpaces, out result3);
						if (!flag3)
						{
							text5 = text5.Trim();
							if (z0ZzZzwik.z0tek(text5))
							{
								result3 = ((!p1.Contains("y")) ? z0ZzZzwik.z0rek(text5, DateTime.MinValue) : z0ZzZzwik.z0eek(text5, DateTime.MinValue));
								flag3 = true;
							}
						}
					}
				}
			}
			else if (p3 is DateTime)
			{
				result3 = (DateTime)p3;
				flag3 = true;
			}
			else if (z0tek(p3))
			{
				result3 = new DateTime(Convert.ToInt64(p3));
				flag3 = true;
			}
			else
			{
				result3 = Convert.ToDateTime(p3);
				flag3 = true;
			}
			if (flag3)
			{
				if (p1 != null && p1.Length > 0)
				{
					if (z0atk == null)
					{
						z0atk = new DateTimeFormatInfo();
						z0atk.DateSeparator = "/";
						z0tek(z0atk, WriterControlForWASM.z0qtk);
					}
					if (p1 == "f")
					{
						p1 = "t";
					}
					else if (p1 == "F")
					{
						p1 = "T";
					}
					string text6 = result3.ToString(p1, z0atk);
					if (text6.Contains("星期", StringComparison.Ordinal))
					{
						string text7 = string.Empty;
						switch (result3.DayOfWeek)
						{
						case DayOfWeek.Sunday:
							text7 = "星期天";
							break;
						case DayOfWeek.Monday:
							text7 = "星期一";
							break;
						case DayOfWeek.Tuesday:
							text7 = "星期二";
							break;
						case DayOfWeek.Wednesday:
							text7 = "星期三";
							break;
						case DayOfWeek.Thursday:
							text7 = "星期四";
							break;
						case DayOfWeek.Friday:
							text7 = "星期五";
							break;
						case DayOfWeek.Saturday:
							text7 = "星期六";
							break;
						}
						text6 = text6.Replace("星期", text7);
					}
					return text6;
				}
				return result3.ToLongDateString();
			}
			if (z0wrk && p3 is string)
			{
				return (string)p3;
			}
			return p2;
		}
		case ValueFormatStyle.Numeric:
		{
			double p4 = 0.0;
			bool flag2 = false;
			if (p3 is string)
			{
				string text = (string)p3;
				if (z0uek(text))
				{
					flag2 = ((!(p1 == "c")) ? double.TryParse(text, out p4) : double.TryParse(text.Replace(",", string.Empty).Replace("￥", string.Empty).Replace("€", string.Empty)
						.Replace("$", string.Empty)
						.Replace("¥", string.Empty)
						.Replace("¤", string.Empty), out p4));
				}
			}
			else if (z0tek(p3))
			{
				p4 = Convert.ToDouble(p3);
				flag2 = true;
			}
			else
			{
				try
				{
					p4 = Convert.ToDouble(p3);
					flag2 = true;
				}
				catch
				{
				}
			}
			if (flag2 && !z0ZzZzbok.z0eek(p4))
			{
				if (p1.Length > 0)
				{
					if (p1 == "c")
					{
						return "¥" + p4.ToString("0.00");
					}
					return p4.ToString(p1);
				}
				return p4.ToString();
			}
			if (z0wrk && p3 is string)
			{
				return (string)p3;
			}
			return p2;
		}
		case ValueFormatStyle.Percent:
		{
			double num6 = 0.0;
			int num7 = 0;
			int num8 = 100;
			if (p3 is string)
			{
				string text8 = (string)p3;
				if (text8 == null || text8.Length <= 0)
				{
					if (z0wrk)
					{
						return (string)p3;
					}
					return p2;
				}
				if (text8.IndexOf('%') > 0)
				{
					num8 = 1;
					text8 = text8.Replace("%", string.Empty);
				}
				if (!double.TryParse(text8, out num6))
				{
					num6 = z0ZzZzbok.z0rek;
				}
			}
			else if (z0tek(p3))
			{
				num6 = Convert.ToDouble(p3);
			}
			else
			{
				try
				{
					num6 = Convert.ToDouble(p3);
				}
				catch
				{
					if (z0wrk)
					{
						return p3.ToString();
					}
					return p2;
				}
			}
			if (!int.TryParse(p1, out num7))
			{
				num7 = 0;
			}
			if (num7 < 0)
			{
				num7 = 0;
			}
			if (!z0ZzZzbok.z0eek(num6))
			{
				num6 = Math.Round(num6 * (double)num8, num7);
				if (num7 == 0)
				{
					return num6 + "%";
				}
				return num6.ToString("0." + new string('0', num7)) + "%";
			}
			if (z0wrk)
			{
				return p3.ToString();
			}
			return p2;
		}
		case ValueFormatStyle.SpecifyLength:
		{
			int num10 = 0;
			string text10 = Convert.ToString(p3);
			if (int.TryParse(p1, out num10) && num10 > 0)
			{
				int num11 = 0;
				string text11 = text10;
				for (int i = 0; i < text11.Length; i++)
				{
					num11 = ((text11[i] <= 'ÿ') ? (num11 + 1) : (num11 + 2));
				}
				if (num11 < num10)
				{
					return p3?.ToString() + new string(' ', num10 - num11);
				}
			}
			return text10;
		}
		case ValueFormatStyle.String:
		{
			string text2 = Convert.ToString(p3);
			if (!z0uek(text2))
			{
				return text2;
			}
			if (!z0uek(p1))
			{
				return text2;
			}
			p1 = p1.Trim();
			if (string.Compare(p1, "trim", true) == 0)
			{
				return text2.Trim();
			}
			if (string.Compare(p1, "HtmlEncode", StringComparison.OrdinalIgnoreCase) == 0)
			{
				return z0ZzZztwh.z0yek(text2);
			}
			if (string.Compare(p1, "HtmlDecode", StringComparison.OrdinalIgnoreCase) == 0)
			{
				return z0ZzZztwh.z0rek(text2);
			}
			if (string.Compare(p1, "UrlEncode", StringComparison.OrdinalIgnoreCase) == 0)
			{
				return z0ZzZztwh.z0tek(text2);
			}
			if (string.Compare(p1, "UrlDecode", StringComparison.OrdinalIgnoreCase) == 0)
			{
				return z0ZzZztwh.z0uek(text2);
			}
			if (string.Compare(p1, "HtmlAttributeEncode", StringComparison.OrdinalIgnoreCase) == 0)
			{
				return z0ZzZztwh.z0eek(text2);
			}
			if (string.Compare(p1, "lower", StringComparison.OrdinalIgnoreCase) == 0)
			{
				return text2.ToLower();
			}
			if (string.Compare(p1, "upper", StringComparison.OrdinalIgnoreCase) == 0)
			{
				return text2.ToUpper();
			}
			p1 = p1.ToLower();
			if (p1.StartsWith("left"))
			{
				int num2 = p1.IndexOf(',');
				if (num2 > 0)
				{
					string text3 = p1.Substring(num2 + 1);
					int num3 = 0;
					if (int.TryParse(text3, out num3) && num3 > 0 && text2.Length > num3)
					{
						return text2.Substring(0, num3);
					}
				}
				return text2;
			}
			if (p1.StartsWith("right"))
			{
				int num4 = p1.IndexOf(',');
				if (num4 > 0)
				{
					string text4 = p1.Substring(num4 + 1);
					int num5 = 0;
					if (int.TryParse(text4, out num5) && num5 > 0 && text2.Length > num5)
					{
						return text2.Substring(text2.Length - num5, num5);
					}
				}
				return text2;
			}
			return text2;
		}
		case ValueFormatStyle.Boolean:
		{
			if (p1 == null)
			{
				return Convert.ToString(p3);
			}
			int num = p1.IndexOf(',');
			string result = p1;
			string result2 = string.Empty;
			if (num >= 0)
			{
				result = p1.Substring(0, num);
				result2 = p1.Substring(num + 1);
			}
			bool flag = false;
			if (p3 is string)
			{
				bool.TryParse((string)p3, out flag);
			}
			else if (p3 is bool)
			{
				flag = (bool)p3;
			}
			else
			{
				try
				{
					flag = Convert.ToBoolean(p3);
				}
				catch
				{
					if (z0wrk)
					{
						return p3.ToString();
					}
					return p2;
				}
			}
			if (flag)
			{
				return result;
			}
			return result2;
		}
		default:
			return Convert.ToString(p3);
		}
	}

	public static bool z0tek(string p0, string p1)
	{
		if (p0 == p1)
		{
			return true;
		}
		if (string.IsNullOrEmpty(p0) && string.IsNullOrEmpty(p1))
		{
			return true;
		}
		return string.Equals(p0, p1, StringComparison.Ordinal);
	}

	internal static z0ZzZzcbj z0tek(z0ZzZzvbj p0, string p1, bool p2)
	{
		if (p0.z0eek())
		{
			return null;
		}
		if (p1 == ".")
		{
			return new z0ZzZzcbj { p0 };
		}
		z0ZzZzcbj z0ZzZzcbj2 = new z0ZzZzcbj();
		z0tek(p0, p1, z0ZzZzcbj2, p3: false, p2);
		return z0ZzZzcbj2;
	}

	internal static z0ZzZzvbj z0tek(XTextElement p0, z0ZzZzevj p1, z0ZzZzrlh p2, string p3 = null)
	{
		if (p1 == null)
		{
			return null;
		}
		if (!p0.z0jr().z0bek(p1))
		{
			return null;
		}
		if (string.IsNullOrEmpty(p3))
		{
			return z0tek(p0, p1.DataSource, p1.BindingPath, p2);
		}
		return z0tek(p0, p1.DataSource, p3, p2);
	}

	private static void z0tek(XTextContainerElement p0, XTextElementList p1, XTextElementList p2, XTextElementList p3, XTextElementList p4)
	{
		foreach (XTextElement item in p0.z0be().z0xrk())
		{
			if (item is XTextObjectElement)
			{
				p2.z0hrk(item);
			}
			else if (item is XTextParagraphFlagElement)
			{
				p3.z0hrk(item);
			}
			else if (item is XTextCharElement)
			{
				p4.z0hrk(item);
			}
			else if (item is XTextCharElement)
			{
				p4.z0hrk(item);
			}
			else if (item is XTextContainerElement)
			{
				p1.z0hrk(item);
				XTextContainerElement xTextContainerElement = (XTextContainerElement)item;
				if (xTextContainerElement.z0crk())
				{
					z0tek(xTextContainerElement, p1, p2, p3, p4);
				}
			}
		}
	}

	internal static z0ZzZzvbj z0tek(XTextElement p0, string p1)
	{
		XTextDocument xTextDocument = p0.z0jr();
		if (xTextDocument == null || !xTextDocument.z0bu().EnableDataBinding)
		{
			return null;
		}
		z0ZzZzvbj result = null;
		if (string.IsNullOrEmpty(p1))
		{
			for (XTextContainerElement xTextContainerElement = p0.z0ji(); xTextContainerElement != null; xTextContainerElement = xTextContainerElement.z0ji())
			{
				if (xTextContainerElement.z0ftk() != null)
				{
					result = (z0ZzZzvbj)xTextContainerElement.z0ftk();
					break;
				}
				if (xTextContainerElement == xTextDocument)
				{
					result = z0uek(xTextDocument);
					break;
				}
			}
		}
		else
		{
			result = ((z0ZzZzvbj)z0uek(xTextDocument)).z0eek(p1, p1: false);
		}
		return result;
	}

	internal static Tuple<string, XTextCharElement[]> z0tek(XTextElementList p0)
	{
		if (p0 == null || p0.Count == 0)
		{
			return null;
		}
		StringBuilder stringBuilder = new StringBuilder();
		zzz.z0ZzZzkuk<XTextCharElement> z0ZzZzkuk2 = new zzz.z0ZzZzkuk<XTextCharElement>();
		foreach (XTextElement item in p0.z0xrk())
		{
			if (item is XTextCharElement xTextCharElement && !xTextCharElement.z0oek() && xTextCharElement.z0aek().z0jyk < 0)
			{
				if (XTextCharElement.z0tek((int)xTextCharElement.CharValue))
				{
					stringBuilder.Append('?');
					z0ZzZzkuk2.Add(xTextCharElement);
				}
				else
				{
					stringBuilder.Append(xTextCharElement.CharValue);
					z0ZzZzkuk2.Add(xTextCharElement);
				}
			}
		}
		if (stringBuilder.Length > 0)
		{
			return new Tuple<string, XTextCharElement[]>(stringBuilder.ToString(), z0ZzZzkuk2.ToArray());
		}
		return null;
	}

	public static void z0tek(Type[] p0)
	{
		List<string> list = new List<string>();
		List<Assembly> list2 = new List<Assembly>();
		List<FieldInfo> list3 = new List<FieldInfo>();
		int num = 0;
		for (int i = 0; i < p0.Length; i++)
		{
			Assembly assembly = p0[i].Assembly;
			if (list2.Contains(assembly))
			{
				continue;
			}
			list2.Add(assembly);
			Type[] types = assembly.GetTypes();
			foreach (Type type in types)
			{
				if (type.IsInterface || type.IsEnum)
				{
					continue;
				}
				FieldInfo[] fields = type.GetFields(BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
				if (fields == null || fields.Length == 0)
				{
					continue;
				}
				FieldInfo[] array = fields;
				foreach (FieldInfo fieldInfo in array)
				{
					if (list3.Contains(fieldInfo))
					{
						continue;
					}
					list3.Add(fieldInfo);
					StringBuilder stringBuilder = new StringBuilder();
					Type fieldType = fieldInfo.FieldType;
					if (fieldInfo.DeclaringType == null)
					{
						stringBuilder.Append(fieldInfo.Name);
					}
					else
					{
						stringBuilder.Append(fieldInfo.DeclaringType?.ToString() + "!" + fieldInfo.Name);
					}
					if (fieldType.IsGenericType)
					{
						stringBuilder.Append("{" + fieldType.Name + "}");
					}
					else
					{
						stringBuilder.Append("{" + fieldType.FullName + "}");
					}
					object obj = null;
					try
					{
						obj = fieldInfo.GetValue(null);
					}
					catch (Exception ex)
					{
						stringBuilder.Append("=" + ex.Message);
						list.Add(stringBuilder.ToString());
						continue;
					}
					stringBuilder.Append('=');
					if (obj == null)
					{
						stringBuilder.Append("[NULL]");
					}
					else if (obj is string)
					{
						string text = (string)obj;
						if (text.Length == 0)
						{
							stringBuilder.Append("[EMPTY]");
						}
						else if (text.Length < 200)
						{
							stringBuilder.Append(z0ZzZznok.z0eek(text));
						}
						else
						{
							stringBuilder.Append(z0ZzZznok.z0eek(text.Substring(0, 200)));
						}
						stringBuilder.Append("<<" + text.Length + ">>");
						num += stringBuilder.Length;
					}
					else if (obj is byte || obj is bool || obj is short || obj is ushort || obj is int || obj is uint || obj is long || obj is ulong || obj is float || obj is double || obj is Enum || obj is DateTime || obj is decimal || obj is char || fieldType.IsValueType)
					{
						stringBuilder.Append(obj.ToString());
						num += z0tek(fieldType);
					}
					else if (obj is Array)
					{
						Array array2 = (Array)obj;
						Type elementType = fieldType.GetElementType();
						if (elementType == null)
						{
							stringBuilder.Append("[" + array2.Length + "]");
						}
						else
						{
							stringBuilder.Append(elementType.Name + "[" + array2.Length + "]");
							int num2 = z0tek(elementType);
							stringBuilder.Append("<<" + z0ZzZzmuk.z0eek(num2 * array2.Length) + ">>");
							num += num2 * array2.Length;
						}
					}
					else
					{
						try
						{
							string text2 = obj.ToString();
							if (text2 == null)
							{
								stringBuilder.Append("[STRNULL]");
							}
							else
							{
								stringBuilder.Append("(" + text2.Length + ")");
								if (text2.Length > 50)
								{
									stringBuilder.Append(text2.Substring(0, 50));
								}
								else
								{
									stringBuilder.Append(text2);
								}
							}
						}
						catch (Exception ex2)
						{
							stringBuilder.Append(ex2.GetType().Name + ":" + ex2.Message);
						}
					}
					z0ZzZzqok.z0rek.z0sh(stringBuilder.ToString());
				}
			}
		}
		z0ZzZzqok.z0rek.z0sh("总大小:" + num + ",(" + z0ZzZzmuk.z0eek(num) + ")");
	}

	internal static void z0tek(XTextElement p0, bool p1)
	{
		p0.Modified = p1;
		if (p1 || !(p0 is XTextContainerElement))
		{
			return;
		}
		using zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = (p0 as XTextContainerElement).z0be().z0ltk();
		while (z0bpk.MoveNext())
		{
			XTextElement current = z0bpk.Current;
			current.Modified = false;
			if (current is XTextContainerElement)
			{
				z0tek(current, p1: false);
			}
		}
	}

	public static string z0tek(z0ZzZzrfh p0)
	{
		if (p0 == null)
		{
			return string.Empty;
		}
		if (p0.z0rek() != null && p0.z0rek().Length != 0)
		{
			return z0ZzZzroj.z0eek(p0.z0rek());
		}
		return p0.z0yek();
	}

	[CompilerGenerated]
	internal static void z0rek(XTextContainerElement p0, Action<XTextElement> p1, bool p2)
	{
		XTextElementList xTextElementList = p0.z0be();
		if (xTextElementList == null || xTextElementList.Count == 0)
		{
			return;
		}
		XTextElement[] array = ((zzz.z0ZzZzkuk<XTextElement>)xTextElementList).z0krk();
		int count = xTextElementList.Count;
		for (int i = 0; i < count; i++)
		{
			XTextElement xTextElement = array[i];
			p1(xTextElement);
			if (p2 && xTextElement is XTextContainerElement)
			{
				z0rek((XTextContainerElement)xTextElement, p1, p2: true);
			}
		}
	}

	public static string z0iek(this XTextDocument p0, string p1, bool p2)
	{
		if (p2)
		{
			MemoryStream memoryStream = new MemoryStream();
			p0.z0vek(memoryStream, p1);
			byte[] array = memoryStream.ToArray();
			memoryStream.Close();
			memoryStream = null;
			return Convert.ToBase64String(array);
		}
		z0ZzZztoj z0ZzZztoj2 = new z0ZzZztoj(p0: true);
		p0.z0vek(z0ZzZztoj2, p1);
		z0ZzZztoj2.Close();
		return null;
	}

	internal static bool z0tek(XTextContainerElement p0, string p1, bool p2)
	{
		int num = -1;
		int num2 = -1;
		if (p0.z0crk() && p0.z0be()[0].z0dy() != null)
		{
			num = ((XTextElement)p0.z0be()[0].z0dy()).z0pek();
			DocumentContentStyle documentContentStyle = p0.z0be()[0].z0dy().z0aek().z0yek();
			documentContentStyle.CreatorIndex = -1;
			documentContentStyle.DeleterIndex = -1;
			documentContentStyle.CommentIndex = -1;
			bool flag = (documentContentStyle.BorderRight = false);
			bool flag3 = (documentContentStyle.BorderLeft = flag);
			bool borderBottom = (documentContentStyle.BorderTop = flag3);
			documentContentStyle.BorderBottom = borderBottom;
			num2 = p0.z0jr().z0gnk().GetStyleIndex(documentContentStyle);
		}
		else
		{
			num = ((XTextElement)p0.z0dy()).z0pek();
			DocumentContentStyle documentContentStyle2 = p0.z0aek().z0yek();
			documentContentStyle2.CreatorIndex = -1;
			documentContentStyle2.DeleterIndex = -1;
			documentContentStyle2.CommentIndex = -1;
			bool flag = (documentContentStyle2.BorderRight = false);
			bool flag3 = (documentContentStyle2.BorderLeft = flag);
			bool borderBottom = (documentContentStyle2.BorderTop = flag3);
			documentContentStyle2.BorderBottom = borderBottom;
			num2 = p0.z0jr().z0gnk().GetStyleIndex(documentContentStyle2);
		}
		int num3 = p1?.IndexOf(',') ?? (-1);
		if (p1 != null && p1.StartsWith("data:image/") && num3 > 0)
		{
			try
			{
				string p3 = p1.Substring(num3 + 1);
				XTextImageElement xTextImageElement = new XTextImageElement();
				xTextImageElement.z0rek(p3, p1: true);
				XTextContainerElement xTextContainerElement = p0;
				if (xTextImageElement.z0frk().HasContent)
				{
					XTextElementList xTextElementList = p0.z0nek<XTextInputFieldElement>();
					if (xTextElementList != null && xTextElementList.Count == 1)
					{
						xTextContainerElement = xTextElementList[0] as XTextInputFieldElement;
					}
					if (xTextContainerElement is XTextTableCellElement && xTextImageElement.Width > ((XTextElement)xTextContainerElement).z0ork())
					{
						float num4 = xTextImageElement.Width / xTextImageElement.Height;
						xTextImageElement.Width = ((XTextElement)xTextContainerElement).z0ork();
						xTextImageElement.Height = xTextImageElement.Width / num4;
					}
					else if (xTextContainerElement is XTextInputFieldElement && xTextImageElement.Width > ((XTextElement)xTextContainerElement.z0ji()).z0ork())
					{
						float num5 = xTextImageElement.Width / xTextImageElement.Height;
						xTextImageElement.Width = ((XTextElement)xTextContainerElement.z0ji()).z0ork();
						xTextImageElement.Height = xTextImageElement.Width / num5;
					}
					xTextContainerElement.z0be().Clear();
					xTextContainerElement.z0be().Add(xTextImageElement);
					if (xTextContainerElement is XTextTableCellElement)
					{
						XTextParagraphFlagElement xTextParagraphFlagElement = new XTextParagraphFlagElement();
						xTextParagraphFlagElement.z0xrk().Align = DocumentContentAlignment.Center;
						xTextContainerElement.z0be().Add(xTextParagraphFlagElement);
					}
				}
			}
			catch
			{
			}
		}
		else if (p0 is XTextTableCellElement && p0.z0be().Count <= 2 && p0.z0be()[0] is XTextInputFieldElement)
		{
			XTextInputFieldElement xTextInputFieldElement = p0.z0be()[0] as XTextInputFieldElement;
			if (xTextInputFieldElement.FieldSettings != null && xTextInputFieldElement.FieldSettings.z0nek() == InputFieldEditStyle.DropdownList && xTextInputFieldElement.FieldSettings.z0zek() != null && xTextInputFieldElement.FieldSettings.z0zek().Items != null)
			{
				string text = null;
				using (zzz.z0ZzZzkuk<ListItem>.z0bpk z0bpk = xTextInputFieldElement.FieldSettings.z0zek().Items.z0ltk())
				{
					while (z0bpk.MoveNext())
					{
						ListItem current = z0bpk.Current;
						if (current.Value == p1)
						{
							text = current.Text;
							break;
						}
					}
				}
				if (text != null)
				{
					xTextInputFieldElement.z0cek(text, num2, num);
					xTextInputFieldElement.InnerValue = p1;
				}
				else
				{
					xTextInputFieldElement.z0cek(p1, num2, num);
				}
			}
			else
			{
				xTextInputFieldElement.z0cek(p1, num2, num);
			}
		}
		else if (p0.z0be().Count <= 2 && p0.z0be()[0] is XTextCheckBoxElementBase)
		{
			XTextCheckBoxElementBase xTextCheckBoxElementBase = p0.z0be()[0] as XTextCheckBoxElementBase;
			if (p1 != null && (p1 == xTextCheckBoxElementBase.CheckedValue || p1.ToLower() == "true"))
			{
				xTextCheckBoxElementBase.Checked = true;
			}
			else if (p1 != null && (p1 != xTextCheckBoxElementBase.CheckedValue || p1.ToLower() == "false"))
			{
				xTextCheckBoxElementBase.Checked = false;
			}
		}
		else
		{
			p0.z0cek(p1, num2, num);
		}
		p0.z0zek(p0.z0kek());
		p0.Modified = true;
		return true;
	}

	public static bool z0yek(XTextContainerElement p0)
	{
		if (p0 == null || p0.z0be() == null || p0.z0be().Count == 0)
		{
			return true;
		}
		if (!WriterControlForWASM.z0nuk)
		{
			return false;
		}
		bool result = true;
		using (zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = p0.z0be().z0ltk())
		{
			while (z0bpk.MoveNext())
			{
				XTextElement current = z0bpk.Current;
				if (current is XTextContainerElement)
				{
					if (!z0yek((XTextContainerElement)current))
					{
						result = false;
						break;
					}
					continue;
				}
				result = false;
				break;
			}
		}
		return result;
	}

	public static bool z0tek(StringBuilder p0)
	{
		int length = p0.Length;
		p0.Append(z0ZzZzjrk.z0tek);
		p0.Append(z0ZzZzzek.z0qtk);
		p0.Append(z0ZzZzkrk.z0zrk);
		p0.Append(z0ZzZzzek.z0ryk);
		p0.Append(z0ZzZzlrk.z0otk);
		p0.Append(z0ZzZzzek.z0rrk);
		p0.Append(z0ZzZzlrk.z0dyk);
		p0.Append(z0ZzZzkrk.z0gtk);
		p0.Append(z0ZzZzkrk.z0prk);
		p0.Append(z0ZzZzzek.z0itk);
		p0.Append(z0ZzZzzek.z0byk);
		if (p0.Length > length)
		{
			p0.Remove(p0.Length - 1, 1);
		}
		return p0.Length != length;
	}
}
