using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using DCSoft.WinForms;
using DCSoft.Writer.Dom;

namespace zzz;

internal class z0ZzZzmij : z0ZzZzxlh
{
	[CompilerGenerated]
	private sealed class z0oyk
	{
		public static Func<XTextElement, DataSourceBindingDescriptionList, bool> z0rek;

		public static readonly z0oyk z0tek = new z0oyk();

		internal bool z0eek(XTextElement p0, DataSourceBindingDescriptionList p1)
		{
			z0ZzZzevj z0ZzZzevj2 = null;
			if (p0 is XTextCheckBoxElementBase xTextCheckBoxElementBase)
			{
				z0ZzZzevj2 = xTextCheckBoxElementBase.ValueBinding;
			}
			else if (p0 is XTextContainerElement)
			{
				z0ZzZzevj2 = ((XTextContainerElement)p0).ValueBinding;
			}
			else if (p0 is XTextLabelElementBase)
			{
				z0ZzZzevj2 = ((XTextLabelElementBase)p0).ValueBinding;
			}
			if (z0ZzZzevj2 != null && !z0ZzZzevj2.IsEmptyBinding)
			{
				DataSourceBindingDescription dataSourceBindingDescription = new DataSourceBindingDescription
				{
					DataSource = z0ZzZzevj2.DataSource
				};
				if (string.IsNullOrEmpty(z0ZzZzevj2.BindingPath))
				{
					dataSourceBindingDescription.BindingPath = z0ZzZzevj2.BindingPathForText;
				}
				else
				{
					dataSourceBindingDescription.BindingPath = z0ZzZzevj2.BindingPath;
				}
				dataSourceBindingDescription.ElementID = p0.ID;
				dataSourceBindingDescription.Element = p0;
				dataSourceBindingDescription.AutoUpdate = z0ZzZzevj2.z0yek();
				dataSourceBindingDescription.Readonly = z0ZzZzevj2.z0rek();
				p1.Add(dataSourceBindingDescription);
			}
			return true;
		}
	}

	[CompilerGenerated]
	private sealed class z0kik
	{
		public int z0rek;

		internal bool z0eek(XTextElement p0, List<string> p1)
		{
			z0ZzZzevj z0ZzZzevj2 = null;
			if (p0 is XTextCheckBoxElementBase xTextCheckBoxElementBase)
			{
				z0ZzZzevj2 = xTextCheckBoxElementBase.ValueBinding;
			}
			else if (p0 is XTextContainerElement)
			{
				z0ZzZzevj2 = ((XTextContainerElement)p0).ValueBinding;
			}
			else if (p0 is XTextLabelElementBase)
			{
				z0ZzZzevj2 = ((XTextLabelElementBase)p0).ValueBinding;
			}
			if (z0ZzZzevj2 != null)
			{
				string dataSource = z0ZzZzevj2.DataSource;
				if (dataSource != null && dataSource.Length > 0)
				{
					bool flag = false;
					for (int num = p1.Count - 1; num >= 0; num--)
					{
						if (string.Equals(p1[num], dataSource, StringComparison.OrdinalIgnoreCase))
						{
							flag = true;
							break;
						}
					}
					if (!flag)
					{
						p1.Add(dataSource);
						z0rek = z0rek + dataSource.Length + 1;
					}
				}
			}
			return true;
		}
	}

	public override string z0okk(XTextDocument p0)
	{
		DataSourceBindingDescriptionList dataSourceBindingDescriptionList = z0ykk(p0);
		z0ZzZzkok z0ZzZzkok2 = new z0ZzZzkok(p0: true);
		if (dataSourceBindingDescriptionList != null)
		{
			z0ZzZzkok2.z0yek();
			z0ZzZzkok2.z0eek("DCDataSourceBindingDescriptions");
			foreach (DataSourceBindingDescription item in dataSourceBindingDescriptionList)
			{
				z0ZzZzkok2.z0eek("Binding");
				z0ZzZzkok2.z0eek("DataSource", item.DataSource);
				z0ZzZzkok2.z0eek("BindingPath", item.BindingPath);
				z0ZzZzkok2.z0eek("ElementID", item.ElementID);
				z0ZzZzkok2.z0eek("FormatString", item.FormatString);
				z0ZzZzkok2.z0eek("AutoUpdate", item.AutoUpdate.ToString());
				z0ZzZzkok2.z0eek("Readonly", item.Readonly.ToString());
				z0ZzZzkok2.z0rek();
			}
			z0ZzZzkok2.z0rek();
			z0ZzZzkok2.z0tek();
		}
		return z0ZzZzkok2.z0eek();
	}

	public override void z0ikk(XTextDocument p0, XTextSubDocumentElement p1, bool p2)
	{
		if (p1 == null)
		{
			throw new ArgumentNullException("newSubDoc");
		}
		if (p0.z0itk().z0ji() is XTextDocumentBodyElement)
		{
			p0.z0xek().z0dn(p1);
			return;
		}
		if (p0.z0itk().z0ji() is XTextDocumentHeaderElement || p0.z0itk().z0ji() is XTextDocumentFooterElement || p0.z0itk().z0ji() is XTextDocumentFooterForFirstPageElement || p0.z0itk().z0ji() is XTextDocumentHeaderForFirstPageElement)
		{
			throw new Exception("Can't insert inside header or footer");
		}
		XTextElement xTextElement = p0.z0itk();
		while (((XTextElement)xTextElement.z0ji()).z0qrk() != "XTextDocumentBodyElement" && ((XTextElement)xTextElement.z0ji()).z0qrk() != "XTextDocumentHeaderElement" && ((XTextElement)xTextElement.z0ji()).z0qrk() != "XTextDocumentFooterElement" && ((XTextElement)xTextElement.z0ji()).z0qrk() != "XTextDocumentBodyElement" && ((XTextElement)xTextElement.z0ji()).z0qrk() != "XTextDocumentFooterForFirstPageElement" && ((XTextElement)xTextElement.z0ji()).z0qrk() != "XTextDocumentHeaderForFirstPageElement")
		{
			xTextElement = xTextElement.z0ji();
		}
		if (xTextElement.z0ji() is XTextDocumentBodyElement)
		{
			if (p2)
			{
				xTextElement.z0ji().z0be().z0oek(xTextElement, p1);
			}
			else
			{
				xTextElement.z0ji().z0be().z0pek(xTextElement, p1);
			}
			p1.z0nu(p0.z0xyk());
			p1.z0li();
			p1.z0oe();
			p1.z0ark();
			if (p0.z0yyk() != null)
			{
				p0.z0yyk().z0eek(ScrollToViewStyle.Middle);
			}
			return;
		}
		throw new Exception("Can't insert inside header or footer");
	}

	public override string z0ukk(XTextDocument p0, string p1, bool p2, bool p3, bool p4, bool p5)
	{
		if (!p2 && !p3)
		{
			return string.Empty;
		}
		if (!p4 && !p5)
		{
			return string.Empty;
		}
		XTextElementList xTextElementList = p0.z0nek<XTextCheckBoxElementBase>();
		StringBuilder stringBuilder = new StringBuilder();
		using (zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = xTextElementList.z0ltk())
		{
			while (z0bpk.MoveNext())
			{
				XTextCheckBoxElementBase xTextCheckBoxElementBase = (XTextCheckBoxElementBase)z0bpk.Current;
				if (xTextCheckBoxElementBase.Checked && (p2 || !(xTextCheckBoxElementBase is XTextCheckBoxElement)) && (p3 || !(xTextCheckBoxElementBase is XTextRadioBoxElement)))
				{
					if (stringBuilder.Length > 0 && p1 != null)
					{
						stringBuilder.Append(p1);
					}
					if (p4)
					{
						stringBuilder.Append(xTextCheckBoxElementBase.ID);
					}
					if (p1 != null)
					{
						stringBuilder.Append(p1);
					}
					if (p5)
					{
						stringBuilder.Append(xTextCheckBoxElementBase.Name);
					}
				}
			}
		}
		return stringBuilder.ToString();
	}

	public override DataSourceBindingDescriptionList z0ykk(XTextDocument p0)
	{
		DataSourceBindingDescriptionList dataSourceBindingDescriptionList = new DataSourceBindingDescriptionList();
		p0.z0mek(p0: false, dataSourceBindingDescriptionList, delegate(XTextElement xTextElement, DataSourceBindingDescriptionList dataSourceBindingDescriptionList2)
		{
			z0ZzZzevj z0ZzZzevj2 = null;
			if (xTextElement is XTextCheckBoxElementBase xTextCheckBoxElementBase)
			{
				z0ZzZzevj2 = xTextCheckBoxElementBase.ValueBinding;
			}
			else if (xTextElement is XTextContainerElement)
			{
				z0ZzZzevj2 = ((XTextContainerElement)xTextElement).ValueBinding;
			}
			else if (xTextElement is XTextLabelElementBase)
			{
				z0ZzZzevj2 = ((XTextLabelElementBase)xTextElement).ValueBinding;
			}
			if (z0ZzZzevj2 != null && !z0ZzZzevj2.IsEmptyBinding)
			{
				DataSourceBindingDescription dataSourceBindingDescription = new DataSourceBindingDescription
				{
					DataSource = z0ZzZzevj2.DataSource
				};
				if (string.IsNullOrEmpty(z0ZzZzevj2.BindingPath))
				{
					dataSourceBindingDescription.BindingPath = z0ZzZzevj2.BindingPathForText;
				}
				else
				{
					dataSourceBindingDescription.BindingPath = z0ZzZzevj2.BindingPath;
				}
				dataSourceBindingDescription.ElementID = xTextElement.ID;
				dataSourceBindingDescription.Element = xTextElement;
				dataSourceBindingDescription.AutoUpdate = z0ZzZzevj2.z0yek();
				dataSourceBindingDescription.Readonly = z0ZzZzevj2.z0rek();
				dataSourceBindingDescriptionList2.Add(dataSourceBindingDescription);
			}
			return true;
		});
		return dataSourceBindingDescriptionList;
	}

	public override bool z0tkk(XTextDocument p0, XTextElement p1, string p2)
	{
		if (p1 == null)
		{
			throw new ArgumentNullException("element");
		}
		if (p1 is XTextContainerElement xTextContainerElement)
		{
			return xTextContainerElement.z0cek(p2, (z0ZzZzbcj)0, p2: true, p3: true);
		}
		if (p1 is XTextLabelElement)
		{
			XTextLabelElement xTextLabelElement = (XTextLabelElement)p1;
			if (xTextLabelElement.Text != p2)
			{
				xTextLabelElement.Text = p2;
				if (xTextLabelElement.z0wy())
				{
					xTextLabelElement.z0oe();
				}
				else
				{
					xTextLabelElement.z0jo();
				}
			}
			return true;
		}
		if (p1 is XTextCheckBoxElementBase)
		{
			XTextCheckBoxElementBase xTextCheckBoxElementBase = (XTextCheckBoxElementBase)p1;
			if (xTextCheckBoxElementBase.Caption != p2)
			{
				xTextCheckBoxElementBase.Caption = p2;
				xTextCheckBoxElementBase.z0oe();
			}
			return true;
		}
		p1.Text = p2;
		return true;
	}

	public override string z0rkk(XTextDocument p0)
	{
		List<string> list = new List<string>();
		int z0rek = 0;
		p0.z0mek(p0: false, list, delegate(XTextElement xTextElement, List<string> list2)
		{
			z0ZzZzevj z0ZzZzevj2 = null;
			if (xTextElement is XTextCheckBoxElementBase xTextCheckBoxElementBase)
			{
				z0ZzZzevj2 = xTextCheckBoxElementBase.ValueBinding;
			}
			else if (xTextElement is XTextContainerElement)
			{
				z0ZzZzevj2 = ((XTextContainerElement)xTextElement).ValueBinding;
			}
			else if (xTextElement is XTextLabelElementBase)
			{
				z0ZzZzevj2 = ((XTextLabelElementBase)xTextElement).ValueBinding;
			}
			if (z0ZzZzevj2 != null)
			{
				string dataSource = z0ZzZzevj2.DataSource;
				if (dataSource != null && dataSource.Length > 0)
				{
					bool flag = false;
					for (int num2 = list2.Count - 1; num2 >= 0; num2--)
					{
						if (string.Equals(list2[num2], dataSource, StringComparison.OrdinalIgnoreCase))
						{
							flag = true;
							break;
						}
					}
					if (!flag)
					{
						list2.Add(dataSource);
						z0rek = z0rek + dataSource.Length + 1;
					}
				}
			}
			return true;
		});
		if (list.Count > 0)
		{
			StringBuilder stringBuilder = new StringBuilder(z0rek - 1);
			for (int num = list.Count - 1; num >= 0; num--)
			{
				stringBuilder.Append(list[num]);
				if (num > 0)
				{
					stringBuilder.Append(',');
				}
			}
			string result = stringBuilder.ToString();
			stringBuilder.Clear();
			return result;
		}
		return string.Empty;
	}

	public override void z0ekk(XTextDocument p0, XTextSubDocumentElement p1)
	{
		if (p1 == null)
		{
			throw new ArgumentNullException("newSubDoc");
		}
		bool flag = false;
		for (int num = p0.z0xyk().z0be().Count - 1; num >= 0; num--)
		{
			if (p0.z0xyk().z0be()[num] is XTextSubDocumentElement)
			{
				p0.z0xyk().z0be().Insert(num + 1, p1);
				flag = true;
				break;
			}
		}
		if (!flag)
		{
			p0.z0xyk().z0be().Insert(0, p1);
		}
		p1.z0iek(p0.z0xyk());
		p1.z0li();
		p1.z0oe();
		p1.z0ark();
		if (p0.z0yyk() != null)
		{
			p0.z0yyk().z0eek(ScrollToViewStyle.Middle);
		}
	}

	public override bool z0wkk(XTextDocument p0, XTextElementList p1, bool p2)
	{
		if (p1 == null || p1.Count == 0)
		{
			return true;
		}
		int maxTextLengthForPaste = p0.z0bu().MaxTextLengthForPaste;
		if (maxTextLengthForPaste == 0)
		{
			return true;
		}
		int num = Math.Abs(maxTextLengthForPaste);
		int num2 = 0;
		XTextElementList xTextElementList = new XTextElementList();
		foreach (XTextElement item in new z0ZzZzkxj(p1)
		{
			ExcludeCharElement = false
		})
		{
			if (!(item is XTextCharElement))
			{
				continue;
			}
			num2++;
			if (num2 <= num)
			{
				continue;
			}
			if (maxTextLengthForPaste > 0)
			{
				if (p2)
				{
					z0ZzZzfpj.z0tek(p0.z0yyk(), string.Format(z0ZzZziok.z0iik(), maxTextLengthForPaste));
				}
				return false;
			}
			xTextElementList.Add(item);
		}
		if (xTextElementList.Count > 0)
		{
			using zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = xTextElementList.z0ltk();
			while (z0bpk.MoveNext())
			{
				XTextElement current = z0bpk.Current;
				if (p1.Contains(current))
				{
					p1.z0cek(current);
				}
				else if (current.z0ji() != null && current.z0ji().z0be().Contains(current))
				{
					current.z0ji().z0be().z0cek(current);
				}
			}
		}
		return true;
	}

	public override string z0qkk(XTextDocument p0, string p1, bool p2)
	{
		if (string.IsNullOrEmpty(p1))
		{
			return p1;
		}
		int maxTextLengthForPaste = p0.z0bu().MaxTextLengthForPaste;
		if (maxTextLengthForPaste > 0)
		{
			if (p1.Length >= maxTextLengthForPaste)
			{
				if (p2)
				{
					z0ZzZzfpj.z0tek(p0.z0yyk(), string.Format(z0ZzZziok.z0iik(), maxTextLengthForPaste));
				}
				return null;
			}
		}
		else if (maxTextLengthForPaste < 0)
		{
			int num = Math.Abs(maxTextLengthForPaste);
			if (p1.Length > num)
			{
				p1 = p1.Substring(0, num);
				return p1;
			}
		}
		return p1;
	}

	public override void z0akk(XTextDocument p0, XTextElementList p1)
	{
		if (!p0.z0bu().AutoClearTextFormatWhenPasteOrInsertContent)
		{
			return;
		}
		int styleIndex = p0.z0gnk().GetStyleIndex(p0.z0onk().z0tek());
		int styleIndex2 = p0.z0gnk().GetStyleIndex(p0.z0onk().z0uek());
		int styleIndex3 = p0.z0gnk().GetStyleIndex(p0.z0onk().z0eek());
		foreach (XTextElement item in new z0ZzZzkxj(p1)
		{
			ExcludeCharElement = false,
			ExcludeParagraphFlag = false
		})
		{
			if (item is XTextParagraphFlagElement)
			{
				item.z0oek(styleIndex2);
			}
			else if (item is XTextTableCellElement)
			{
				item.z0oek(styleIndex3);
			}
			else if (item is XTextCharElement)
			{
				if (item.z0xrk().Subscript)
				{
					item.z0oek(styleIndex);
					item.z0xrk().Subscript = true;
				}
				else if (item.z0xrk().Superscript)
				{
					item.z0oek(styleIndex);
					item.z0xrk().Superscript = true;
				}
				else
				{
					item.z0oek(styleIndex);
				}
			}
			else
			{
				item.z0oek(styleIndex);
			}
		}
	}
}
