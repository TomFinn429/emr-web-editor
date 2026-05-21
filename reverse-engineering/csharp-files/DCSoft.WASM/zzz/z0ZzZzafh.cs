using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using DCSoft.Drawing;
using DCSoft.Writer;
using DCSoft.Writer.Dom;
using DCSystem_Drawing;

namespace zzz;

public static class z0ZzZzafh
{
	private static Dictionary<Type, string> z0nek;

	private static readonly string[] z0bek;

	private static readonly string z0cek;

	private static readonly string z0xek;

	internal static nint z0lrk;

	private static readonly string z0krk;

	public static z0ZzZzsdh z0jrk;

	private static readonly int z0hrk;

	private static DateTime z0grk;

	private static readonly string z0frk;

	public static string z0drk;

	public static object z0yek(object p0, object p1)
	{
		if (p0 == null || DBNull.Value.Equals(p0))
		{
			return p1;
		}
		Type type = p1.GetType();
		try
		{
			if (type.Equals(p0.GetType()))
			{
				return p0;
			}
			if (p0 is string)
			{
				return Enum.Parse(type, (string)p0);
			}
			return Enum.ToObject(type, p0);
		}
		catch
		{
			return p1;
		}
	}

	internal static void z0yek(Type p0, string p1)
	{
		z0yek();
		z0nek[p0] = p1;
	}

	internal static string z0yek(object p0)
	{
		if (p0 == null)
		{
			return null;
		}
		if (p0 is z0ZzZzwok)
		{
			return ((z0ZzZzwok)p0).z0tek();
		}
		if (p0 is string)
		{
			return (string)p0;
		}
		return p0.ToString();
	}

	public static z0ZzZzzlh z0yek(this z0ZzZzzlh[] p0)
	{
		if (p0 != null && p0.Length != 0)
		{
			return p0[0];
		}
		return null;
	}

	public static bool z0yek(XTextElementList p0, bool[] p1)
	{
		bool result = false;
		for (int num = p0.Count - 1; num >= 0; num--)
		{
			XTextElement xTextElement = p0[num];
			if (!(xTextElement is XTextDocumentContentElement))
			{
				int z0buk = xTextElement.z0buk;
				if (z0buk >= 0 && z0buk < p1.Length && p1[z0buk])
				{
					p0.RemoveAt(num);
					result = true;
					continue;
				}
			}
			if (xTextElement is XTextContainerElement && xTextElement.z0be() != null && z0yek(xTextElement.z0be(), p1))
			{
				result = true;
			}
		}
		return result;
	}

	public static float z0yek(XTextDocument p0, decimal p1)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("document");
		}
		return (float)z0ZzZzrpk.z0eek(Convert.ToDouble(p1) * 10.0, GraphicsUnit.Millimeter, GraphicsUnit.Document);
	}

	public static XTextElementList z0yek(XTextElementList p0, bool p1, z0ZzZzzhh p2, bool p3, XTextContainerElement p4 = null)
	{
		XTextElementList xTextElementList = new XTextElementList();
		if (p0.Count == 0)
		{
			return xTextElementList;
		}
		XTextStringElement xTextStringElement = null;
		z0ZzZzvnj z0ZzZzvnj2 = p2?.z0eek();
		int count = p0.Count;
		List<XTextStringElement> list = new List<XTextStringElement>();
		bool flag = true;
		for (int i = 0; i < count; i++)
		{
			XTextElement xTextElement = p0[i];
			if ((z0ZzZzvnj2 != null && z0ZzZzvnj2.ContentRenderMode != (z0ZzZzfbj)8 && ((xTextElement.z0ptk() != null && !xTextElement.z0ptk().z0oek()) || ((xTextElement is XTextCharElement || xTextElement is XTextParagraphFlagElement || xTextElement is XTextObjectElement) && xTextElement.z0ptk() == null))) || (p3 && xTextElement.z0wtk()) || (p1 && !xTextElement.z0de()))
			{
				continue;
			}
			if (xTextElement is XTextCharElement)
			{
				XTextCharElement xTextCharElement = (XTextCharElement)xTextElement;
				string p5 = xTextCharElement.ToString();
				bool flag2 = false;
				XTextInputFieldElement xTextInputFieldElement = null;
				if (xTextCharElement.z0ji() is XTextInputFieldElement)
				{
					flag2 = ((XTextFieldElementBase)(XTextInputFieldElement)xTextCharElement.z0ji()).z0rek((XTextElement)xTextCharElement);
				}
				if (z0ZzZzvnj2 != null && xTextCharElement.z0ji() is XTextInputFieldElement)
				{
					XTextInputFieldElement xTextInputFieldElement2 = (XTextInputFieldElement)xTextCharElement.z0ji();
					xTextInputFieldElement = xTextInputFieldElement2;
					if (z0ZzZzvnj2.EnableEncryptView && xTextInputFieldElement2.z0eek(xTextCharElement))
					{
						p5 = "*";
					}
					else if (flag2)
					{
						switch (z0ZzZzvnj2.BackgroundTextOutputMode)
						{
						case DCBackgroundTextOutputMode.None:
							p5 = null;
							break;
						case DCBackgroundTextOutputMode.Whitespace:
							p5 = ((xTextCharElement.z0mek() <= 'Ā') ? " " : "  ");
							break;
						case DCBackgroundTextOutputMode.Underline:
							p5 = ((xTextCharElement.z0mek() <= 'Ā') ? "_" : "__");
							break;
						}
					}
				}
				if (xTextStringElement != null && xTextStringElement.z0eek(xTextCharElement) && xTextStringElement.z0iek(xTextCharElement) && xTextStringElement.z0mek() == flag2)
				{
					xTextStringElement.z0eek(xTextCharElement, p5);
					continue;
				}
				xTextStringElement = new XTextStringElement();
				list.Add(xTextStringElement);
				xTextStringElement.z0oek(xTextCharElement);
				if (z0ZzZzvnj2 != null && z0ZzZzvnj2.ForPrint)
				{
					xTextStringElement.z0tek(p0: true);
				}
				if (flag2 && xTextInputFieldElement != null)
				{
					xTextStringElement.z0oek(((XTextElement)xTextInputFieldElement).z0pek());
				}
				xTextStringElement.z0eek(flag2);
				xTextElementList.Add(xTextStringElement);
				xTextStringElement.z0eek(xTextCharElement, p5);
			}
			else
			{
				if (xTextElement is XTextContainerElement)
				{
					flag = false;
				}
				xTextStringElement = null;
				xTextElementList.Add(xTextElement);
			}
		}
		if (list.Count > 0)
		{
			if (flag)
			{
				int num = p0.Count - 1;
				XTextParagraphFlagElement xTextParagraphFlagElement = null;
				for (int num2 = list.Count - 1; num2 >= 0; num2--)
				{
					XTextStringElement xTextStringElement2 = list[num2];
					XTextCharElement xTextCharElement2 = xTextStringElement2.z0bek();
					while (num > 0)
					{
						XTextElement xTextElement2 = p0[num];
						num--;
						if (xTextElement2 == xTextCharElement2)
						{
							break;
						}
						if (xTextElement2 is XTextParagraphFlagElement)
						{
							xTextParagraphFlagElement = (xTextStringElement2.z0cek = (XTextParagraphFlagElement)xTextElement2);
							break;
						}
					}
					if (xTextStringElement2.z0cek == null)
					{
						xTextStringElement2.z0cek = xTextParagraphFlagElement;
						if (xTextStringElement2.z0cek == null)
						{
							num = -1;
						}
					}
				}
			}
			foreach (XTextStringElement item in list)
			{
				if (item.z0cek != null)
				{
					continue;
				}
				Dictionary<XTextCharElement, XTextParagraphFlagElement> dictionary = list[0].z0tek().z0jy().z0ltk();
				if (dictionary == null || dictionary.Count <= 0)
				{
					break;
				}
				foreach (XTextStringElement item2 in list)
				{
					if (item2.z0cek == null && !dictionary.TryGetValue(item2.z0bek(), out item2.z0cek))
					{
						dictionary.TryGetValue(item2.z0tek(), out item2.z0cek);
					}
				}
				break;
			}
		}
		if (xTextElementList.LastElement is XTextParagraphFlagElement && ((XTextParagraphFlagElement)xTextElementList.LastElement).z0vek())
		{
			xTextElementList.RemoveAt(xTextElementList.Count - 1);
		}
		using zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = xTextElementList.z0ltk();
		while (z0bpk.MoveNext())
		{
			XTextElement current2 = z0bpk.Current;
			if (current2 is XTextStringElement)
			{
				((XTextStringElement)current2).z0oek();
			}
		}
		return xTextElementList;
	}

	[CompilerGenerated]
	internal static string z0yek(XTextElementList p0)
	{
		StringBuilder stringBuilder = new StringBuilder();
		int num = Math.Min(100, p0.Count);
		for (int i = 0; i < num; i++)
		{
			if (stringBuilder.Length >= 30)
			{
				break;
			}
			XTextElement xTextElement = p0[i];
			if (xTextElement is XTextCharElement)
			{
				((XTextCharElement)xTextElement).z0rek(stringBuilder);
			}
		}
		if (stringBuilder.Length > 0)
		{
			return stringBuilder.ToString();
		}
		return null;
	}

	public static ElementType z0yek(Type p0)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("elementType");
		}
		if (typeof(XTextCharElement).IsAssignableFrom(p0))
		{
			return ElementType.Text;
		}
		if (typeof(XTextParagraphFlagElement).IsAssignableFrom(p0))
		{
			return ElementType.ParagraphFlag;
		}
		if (typeof(XTextInputFieldElementBase).IsAssignableFrom(p0))
		{
			return ElementType.InputField;
		}
		if (typeof(XTextFieldElementBase).IsAssignableFrom(p0))
		{
			return ElementType.Field;
		}
		if (typeof(XTextImageElement).IsAssignableFrom(p0))
		{
			return ElementType.Image;
		}
		if (typeof(XTextObjectElement).IsAssignableFrom(p0))
		{
			return ElementType.Object;
		}
		if (typeof(XTextCheckBoxElementBase).IsAssignableFrom(p0))
		{
			return ElementType.CheckRadioBox;
		}
		if (typeof(XTextDocument).IsAssignableFrom(p0))
		{
			return ElementType.Document;
		}
		if (typeof(XTextLineBreakElement).IsAssignableFrom(p0))
		{
			return ElementType.LineBreak;
		}
		if (typeof(XTextPageBreakElement).IsAssignableFrom(p0))
		{
			return ElementType.PageBreak;
		}
		if (typeof(XTextTableCellElement).IsAssignableFrom(p0))
		{
			return ElementType.TableCell;
		}
		if (typeof(XTextTableRowElement).IsAssignableFrom(p0))
		{
			return ElementType.TableRow;
		}
		if (typeof(XTextTableElement).IsAssignableFrom(p0))
		{
			return ElementType.Table;
		}
		if (typeof(XTextTableColumnElement).IsAssignableFrom(p0))
		{
			return ElementType.TableColumn;
		}
		return ElementType.None;
	}

	internal static XTextElement z0yek(XTextElement p0, XTextElement p1)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("element1");
		}
		if (p1 == null)
		{
			throw new ArgumentNullException("element2");
		}
		if (p0 == p1)
		{
			return p0;
		}
		XTextElementList xTextElementList = new XTextElementList();
		for (XTextElement xTextElement = p0; xTextElement != null; xTextElement = xTextElement.z0ji())
		{
			xTextElementList.Add(xTextElement);
		}
		for (XTextElement xTextElement = p1; xTextElement != null; xTextElement = xTextElement.z0ji())
		{
			if (xTextElementList.Contains(xTextElement))
			{
				return xTextElement;
			}
		}
		return null;
	}

	internal static XTextInputFieldElementBase z0yek(XTextElement p0)
	{
		while (p0 != null)
		{
			if (p0 is XTextInputFieldElementBase)
			{
				return (XTextInputFieldElementBase)p0;
			}
			p0 = p0.z0ji();
		}
		return null;
	}

	public static void z0eek<ArgType>(XTextContainerElement p0, ArgType p1, Action<XTextContentElement, ArgType> p2)
	{
		int count = p0.z0be().Count;
		XTextElement[] array = ((zzz.z0ZzZzkuk<XTextElement>)p0.z0be()).z0krk();
		for (int i = 0; i < count; i++)
		{
			if (!(array[i] is XTextContainerElement xTextContainerElement))
			{
				continue;
			}
			if (xTextContainerElement is XTextContentElement)
			{
				p2((XTextContentElement)xTextContainerElement, p1);
				if (xTextContainerElement.z0crk())
				{
					z0eek(xTextContainerElement, p1, p2);
				}
			}
			else if (xTextContainerElement is XTextTableElement xTextTableElement)
			{
				XTextElement[] array2 = ((zzz.z0ZzZzkuk<XTextElement>)xTextTableElement.z0stk()).z0krk();
				int count2 = xTextTableElement.z0stk().Count;
				for (int j = 0; j < count2; j++)
				{
					XTextTableRowElement obj = (XTextTableRowElement)array2[j];
					XTextElement[] array3 = ((zzz.z0ZzZzkuk<XTextElement>)obj.z0rek()).z0krk();
					int count3 = obj.z0rek().Count;
					for (int k = 0; k < count3; k++)
					{
						XTextTableCellElement xTextTableCellElement = (XTextTableCellElement)array3[k];
						p2(xTextTableCellElement, p1);
						if (((XTextContainerElement)xTextTableCellElement).z0crk())
						{
							z0eek(xTextTableCellElement, p1, p2);
						}
					}
				}
			}
			else if (xTextContainerElement.z0crk())
			{
				z0eek(xTextContainerElement, p1, p2);
			}
		}
	}

	private static void z0yek()
	{
		if (z0nek == null && z0nek == null)
		{
			z0nek = new Dictionary<Type, string>
			{
				[typeof(XTextBlockElement)] = z0ZzZziok.z0ttk(),
				[typeof(XTextDocumentBodyElement)] = z0ZzZziok.z0wuk(),
				[typeof(XTextCharElement)] = z0ZzZziok.z0zuk(),
				[typeof(XTextCheckBoxElement)] = z0ZzZziok.z0qyk(),
				[typeof(XTextRadioBoxElement)] = z0ZzZziok.z0krk(),
				[typeof(DocumentComment)] = z0ZzZziok.z0xek(),
				[typeof(XTextDocument)] = z0ZzZziok.z0srk(),
				[typeof(XTextDocumentFooterElement)] = z0ZzZziok.z0itk(),
				[typeof(XTextDocumentHeaderElement)] = z0ZzZziok.z0erk(),
				[typeof(XTextDocumentFooterForFirstPageElement)] = z0ZzZziok.z0rik(),
				[typeof(XTextDocumentHeaderForFirstPageElement)] = z0ZzZziok.z0vok(),
				[typeof(XTextHorizontalLineElement)] = z0ZzZziok.z0zek(),
				[typeof(XTextImageElement)] = z0ZzZziok.z0ltk(),
				[typeof(XTextInputFieldElement)] = z0ZzZziok.z0uyk(),
				[typeof(XTextLabelElement)] = z0ZzZziok.z0iok(),
				[typeof(XTextLineBreakElement)] = z0ZzZziok.z0jok(),
				[typeof(XTextPageBreakElement)] = z0ZzZziok.z0duk(),
				[typeof(XTextPageInfoElement)] = z0ZzZziok.z0oik(),
				[typeof(XTextParagraphFlagElement)] = z0ZzZziok.z0grk(),
				[typeof(XTextSignElement)] = z0ZzZziok.z0prk(),
				[typeof(XTextTableElement)] = z0ZzZziok.z0pyk(),
				[typeof(XTextTableRowElement)] = z0ZzZziok.z0hrk(),
				[typeof(XTextTableCellElement)] = z0ZzZziok.z0vik(),
				[typeof(XTextTableColumnElement)] = z0ZzZziok.z0dyk()
			};
		}
	}

	public static z0ZzZzzlh z0uek(this z0ZzZzzlh[] p0)
	{
		if (p0 == null || p0.Length == 0)
		{
			return null;
		}
		return p0[p0.Length - 1];
	}

	internal static int z0yek(XTextElementList p0, XTextElement p1)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("elements");
		}
		if (p1 == null)
		{
			throw new ArgumentNullException("element");
		}
		if (p0.SafeGet(p1.z0tuk) == p1)
		{
			return p1.z0tuk;
		}
		if (p0.SafeGet(p1.z0xuk) == p1)
		{
			return p1.z0xuk;
		}
		return p0.IndexOf(p1);
	}

	public static string z0uek(XTextElement p0)
	{
		if (p0 is XTextObjectElement)
		{
			return ((XTextObjectElement)p0).Name;
		}
		if (p0 is XTextInputFieldElementBase)
		{
			return ((XTextInputFieldElementBase)p0).Name;
		}
		return null;
	}

	internal static XTextElementList z0iek(XTextElement p0)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("GetParentList.element");
		}
		XTextElementList xTextElementList = new XTextElementList();
		for (XTextContainerElement xTextContainerElement = p0.z0ji(); xTextContainerElement != null; xTextContainerElement = xTextContainerElement.z0ji())
		{
			((zzz.z0ZzZzkuk<XTextElement>)xTextElementList).z0pek((XTextElement)xTextContainerElement);
		}
		return xTextElementList;
	}

	public static bool z0uek(XTextElementList p0)
	{
		bool result = false;
		for (int num = p0.Count - 1; num >= 0; num--)
		{
			XTextElement xTextElement = p0[num];
			if (!(xTextElement is XTextDocumentContentElement))
			{
				z0ZzZzrzj z0ZzZzrzj2 = xTextElement.z0aek();
				if (z0ZzZzrzj2 != null && z0ZzZzrzj2.z0jyk >= 0)
				{
					p0.RemoveAt(num);
					result = true;
					continue;
				}
			}
			if (xTextElement.z0be() != null && z0uek(xTextElement.z0be()))
			{
				result = true;
			}
		}
		return result;
	}

	public static XTextDocument z0yek(XTextDocument p0, XTextElementList p1, bool p2)
	{
		if (p1 == null)
		{
			return null;
		}
		XTextDocument xTextDocument = null;
		xTextDocument = ((p0 != null) ? ((XTextDocument)p0.z0lr(p0: false)) : new XTextDocument());
		xTextDocument.z0gnk().Styles.Clear();
		xTextDocument.z0gnk().Default = p0.z0gnk().Default.Clone();
		xTextDocument.Comments.Clear();
		xTextDocument.z0syk().Clear();
		if (xTextDocument.z0imk() != null)
		{
			xTextDocument.z0imk().Clear();
		}
		if (p1.Count == 0)
		{
			return xTextDocument;
		}
		using (zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = p1.z0ltk())
		{
			while (z0bpk.MoveNext())
			{
				XTextElement current = z0bpk.Current;
				if (current is XTextContainerElement)
				{
					((XTextContainerElement)current).z0li();
				}
			}
		}
		XTextElementList xTextElementList = p1;
		if (p2)
		{
			xTextElementList = xTextElementList.z0nek();
		}
		if (xTextElementList.Count > 0)
		{
			xTextElementList[0].z0bt(p0);
		}
		xTextDocument.z0cek(xTextElementList);
		xTextDocument.z0xyk().z0be().Clear();
		((zzz.z0ZzZzkuk<XTextElement>)xTextDocument.z0xyk().z0be()).z0tek((zzz.z0ZzZzkuk<XTextElement>)xTextElementList);
		xTextDocument.z0xyk().z0gu();
		xTextDocument.z0prk();
		xTextDocument.z0bek((z0ZzZzdbj)null);
		xTextDocument.z0bek((z0ZzZzpxj)null);
		xTextDocument.z0bek((z0ZzZzdcj)null);
		xTextDocument.z0hrk((XTextElement)null);
		xTextDocument.z0bek((z0ZzZzmxj)null);
		if (xTextDocument.z0imk() != null)
		{
			xTextDocument.z0nuk();
			xTextDocument.z0imk().Clear();
		}
		xTextDocument.z0li();
		return xTextDocument;
	}

	public static string z0yek(string p0)
	{
		if (p0 != null)
		{
			p0 = p0.Trim();
			int num = p0.IndexOf('?');
			if (num > 0)
			{
				p0 = p0.Substring(0, num).Trim();
			}
		}
		if (p0 != null && p0.Length > 0)
		{
			return p0;
		}
		return null;
	}

	public static string z0yek(byte[] p0)
	{
		if (p0 == null || p0.Length == 0)
		{
			return null;
		}
		return z0pek(Encoding.UTF8.GetString(p0, 0, Math.Max(p0.Length, 1000)));
	}

	public static int z0yek(int p0, int p1, int p2)
	{
		if ((p0 & p1) == 0)
		{
			if ((p0 & p2) == 0)
			{
				return 0;
			}
			return 1;
		}
		return 2;
	}

	public static z0ZzZzsdh z0yek(z0ZzZzsdh p0)
	{
		return new z0ZzZzsdh("SimSun-ExtB", p0.z0yek(), p0.z0mek());
	}

	public static string z0oek(XTextElement p0)
	{
		string text = p0.GetType().Name;
		if (!(p0 is XTextCharElement) && !(p0 is XTextParagraphFlagElement))
		{
			if (!string.IsNullOrEmpty(p0.ID))
			{
				text = text + "[" + p0.ID + "]";
			}
			else if (p0 is XTextInputFieldElementBase)
			{
				string name = ((XTextInputFieldElementBase)p0).Name;
				if (!string.IsNullOrEmpty(name))
				{
					text = text + "[" + name + "]";
				}
			}
		}
		return text;
	}

	public static void z0uek(string p0)
	{
		if (XTextDocument.z0wbk)
		{
			z0ZzZzqok.z0rek.z0sh("DC Memory[" + p0 + "]: " + Convert.ToInt32((double)GC.GetTotalMemory(false) / 1048576.0) + " MB ,Total alloc:" + z0ZzZzmuk.z0eek(GC.GetTotalAllocatedBytes()));
		}
	}

	public static bool z0yek(XTextElementList p0, int p1, int p2)
	{
		if (p0 == null || p0.Count == 0)
		{
			return false;
		}
		if (p1 > p2)
		{
			throw new ArgumentOutOfRangeException("startIndex>endIndex");
		}
		if (p1 < 0)
		{
			p1 = 0;
		}
		if (p1 >= p0.Count)
		{
			p1 = p0.Count - 1;
		}
		if (p2 < 0)
		{
			p2 = 0;
		}
		if (p2 >= p0.Count)
		{
			p2 = p0.Count - 1;
		}
		for (int i = p1; i <= p2; i++)
		{
			XTextElement xTextElement = p0[i];
			if (xTextElement is XTextPageBreakElement)
			{
				return true;
			}
			if (xTextElement is XTextContainerElement && z0yek(xTextElement.z0be(), 0, xTextElement.z0be().Count - 1))
			{
				return true;
			}
		}
		return false;
	}

	internal static int z0uek(XTextElement p0, XTextElement p1)
	{
		if (p0 == p1)
		{
			return 0;
		}
		if (p0 == null || p1 == null)
		{
			return 0;
		}
		if (p0.z0ji() == p1)
		{
			return -1;
		}
		if (p0 == p1.z0ji())
		{
			return 1;
		}
		List<XTextElement> list = new List<XTextElement>();
		XTextElement xTextElement;
		for (xTextElement = p0; xTextElement != null; xTextElement = xTextElement.z0ji())
		{
			list.Add(xTextElement);
		}
		xTextElement = p1.z0ji();
		XTextElement xTextElement2 = p1;
		while (xTextElement != null)
		{
			int num = list.IndexOf(xTextElement);
			if (num == 0)
			{
				return 1;
			}
			if (num >= 0)
			{
				int num2 = list[num - 1].z0tr();
				int num3 = xTextElement2.z0tr();
				return num2 - num3;
			}
			xTextElement2 = xTextElement;
			xTextElement = xTextElement.z0ji();
		}
		return 0;
	}

	public static bool z0yek(object p0, bool p1)
	{
		if (p0 == null || DBNull.Value.Equals(p0))
		{
			return p1;
		}
		if (p0 is bool)
		{
			return (bool)p0;
		}
		string text = Convert.ToString(p0);
		text = text.Trim();
		if (text.Equals("true", StringComparison.CurrentCultureIgnoreCase) || text == "1")
		{
			return true;
		}
		if (text.Equals("false", StringComparison.CurrentCultureIgnoreCase) || text == "0")
		{
			return false;
		}
		return p1;
	}

	internal static XTextElementList z0pek(XTextElement p0)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("element");
		}
		XTextElementList xTextElementList = new XTextElementList();
		for (XTextContainerElement xTextContainerElement = p0.z0ji(); xTextContainerElement != null; xTextContainerElement = xTextContainerElement.z0ji())
		{
			if (xTextContainerElement.z0ie() != p0)
			{
				xTextElementList.Add(xTextContainerElement);
			}
			else if (xTextContainerElement is XTextTableCellElement)
			{
				xTextElementList.Add(xTextContainerElement);
			}
		}
		return xTextElementList;
	}

	internal static bool z0yek(XTextContainerElement p0)
	{
		if (p0 == null)
		{
			return false;
		}
		z0ZzZzzok styles = p0.z0jr().z0gnk().Styles;
		bool[] array = new bool[styles.Count];
		for (int num = styles.Count - 1; num >= 0; num--)
		{
			array[num] = ((DocumentContentStyle)styles[num]).DeleterIndex >= 0;
		}
		return z0yek(p0.z0be(), array);
	}

	public static string z0uek(Type p0)
	{
		z0yek();
		if (z0nek.ContainsKey(p0))
		{
			return z0nek[p0];
		}
		return p0.Name;
	}

	public static string z0yek(int p0)
	{
		return z0ZzZzmuk.z0eek(p0);
	}

	public static int z0yek(int p0, int p1, int p2, int p3)
	{
		return p3 switch
		{
			0 => p0 & ~(p1 | p2), 
			1 => (p0 & ~p1) | p2, 
			_ => p0 | p1, 
		};
	}

	internal static int z0yek(this z0ZzZzzlh[] p0, z0ZzZzzlh p1)
	{
		return Array.IndexOf(p0, p1);
	}

	public static List<int> z0yek(XTextDocument p0)
	{
		if (p0 == null)
		{
			return null;
		}
		z0ZzZzhkh z0ZzZzhkh2 = p0.z0xyk().z0oek();
		float num = 3.4028235E+38f;
		float num2 = -3.4028235E+38f;
		using (zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = z0ZzZzhkh2.z0grk().z0ltk())
		{
			while (z0bpk.MoveNext())
			{
				XTextElement current = z0bpk.Current;
				float num3 = current.z0ltk();
				if (num3 > 0f)
				{
					num = Math.Min(num, num3);
					num2 = Math.Max(num2, num3 + current.Height);
				}
			}
		}
		if (z0ZzZzhkh2.z0irk() != null)
		{
			using zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = z0ZzZzhkh2.z0irk().z0ltk();
			while (z0bpk.MoveNext())
			{
				XTextTableCellElement xTextTableCellElement = (XTextTableCellElement)z0bpk.Current;
				float num4 = ((XTextElement)xTextTableCellElement).z0ltk();
				if (num4 > 0f)
				{
					num = Math.Min(num, num4);
					num2 = Math.Max(num2, num4 + xTextTableCellElement.Height);
				}
			}
		}
		if (num != 3.4028235E+38f)
		{
			List<int> list = new List<int>();
			for (int i = 0; i < p0.z0suk().Count; i++)
			{
				z0ZzZzwrj z0ZzZzwrj2 = p0.z0suk()[i];
				if (z0ZzZzwrj2.z0irk() < num2 - 2f && z0ZzZzwrj2.z0qrk() > num + 2f)
				{
					list.Add(z0ZzZzwrj2.z0brk());
				}
			}
			return list;
		}
		return null;
	}

	public static bool z0iek(string p0)
	{
		if (p0 != null && p0.Length > 0)
		{
			for (int num = p0.Length - 1; num >= 0; num--)
			{
				char c = p0[num];
				if (char.IsHighSurrogate(c) || z0xek.Contains(c))
				{
					return true;
				}
			}
		}
		return false;
	}

	internal static bool z0uek(this z0ZzZzzlh[] p0, z0ZzZzzlh p1)
	{
		return Array.IndexOf(p0, p1) >= 0;
	}

	public static bool z0yek(string p0, string p1)
	{
		if (p0 == p1)
		{
			return true;
		}
		bool flag = string.IsNullOrEmpty(p0);
		bool flag2 = string.IsNullOrEmpty(p1);
		if (flag && flag2)
		{
			return true;
		}
		return false;
	}

	public static void z0yek(XTextElementList p0, ElementEnumerateEventHandler p1)
	{
		if (p1 == null)
		{
			throw new ArgumentNullException("handler");
		}
		ElementEnumerateEventArgs p2 = new ElementEnumerateEventArgs();
		z0yek(p0, p1, p2, p3: true);
	}

	internal static bool z0oek(string p0)
	{
		if (string.IsNullOrEmpty(p0))
		{
			return false;
		}
		if (string.Compare(p0, "EditComment", true) != 0 && string.Compare(p0, "InsertComment", true) != 0 && string.Compare(p0, "DeleteAllComment", true) != 0)
		{
			return string.Compare(p0, "DeleteComment", true) == 0;
		}
		return true;
	}

	internal static float z0yek(float p0, float p1)
	{
		float num = p1 * (float)(int)Math.Ceiling((double)p0 / (double)p1) - p0;
		if (num == 0f)
		{
			num = p1;
		}
		return num;
	}

	public static bool z0rek(XTextDocument p0, IEnumerable<XTextElement> p1, bool p2)
	{
		bool result = false;
		using z0ZzZzjpk p3 = p0.z0ru();
		z0ZzZzvxj z0ZzZzvxj2 = p0.z0bek(p3, (z0ZzZzcxj)0);
		foreach (XTextElement item in p1)
		{
			if (!p2 || item.z0ao())
			{
				z0ZzZzvxj2.z0hyk = item;
				item.z0bt(p0);
				float width = item.Width;
				item.z0mr(z0ZzZzvxj2);
				if (width != item.Width)
				{
					result = true;
				}
			}
		}
		return result;
	}

	public static string z0mek(XTextElement p0)
	{
		if (p0 == null)
		{
			return null;
		}
		if (p0 is XTextCheckBoxElementBase)
		{
			return ((XTextCheckBoxElementBase)p0).Text;
		}
		if (p0 is XTextLabelElementBase)
		{
			return ((XTextLabelElementBase)p0).Text;
		}
		if (p0 is XTextPageInfoElement)
		{
			return ((XTextPageInfoElement)p0).z0rek();
		}
		if (p0 is z0ZzZzlzj)
		{
			return p0.Text;
		}
		if (p0 is XTextContentElement xTextContentElement)
		{
			XTextElementList xTextElementList = xTextContentElement.z0mek();
			if (xTextElementList != null && xTextElementList.Count > 0)
			{
				return z0yek(xTextElementList);
			}
		}
		if (p0 is XTextContainerElement xTextContainerElement)
		{
			XTextElementList xTextElementList2 = xTextContainerElement.z0be();
			if (xTextElementList2 != null && xTextElementList2.Count > 0)
			{
				return z0yek(xTextElementList2);
			}
		}
		return null;
	}

	public static bool z0yek(WriterDataFormats p0, WriterDataFormats p1)
	{
		return (p0 & p1) == p1;
	}

	public static XTextContainerElement z0iek(XTextElement p0, XTextElement p1)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("element1");
		}
		if (p1 == null)
		{
			throw new ArgumentNullException("element2");
		}
		if (p0.z0iek(p1))
		{
			return p0.z0ji();
		}
		for (XTextElement xTextElement = p0; xTextElement != null; xTextElement = xTextElement.z0ji())
		{
			for (XTextElement xTextElement2 = p1; xTextElement2 != null; xTextElement2 = xTextElement2.z0ji())
			{
				if (xTextElement == xTextElement2)
				{
					return xTextElement as XTextContainerElement;
				}
			}
		}
		return null;
	}

	public static z0ZzZzimk z0yek(z0ZzZzimk p0)
	{
		return new z0ZzZzimk("SimSun-ExtB", p0.Size, p0.Style);
	}

	public static string z0yek(IEnumerable p0, char p1)
	{
		if (p0 == null)
		{
			return null;
		}
		StringBuilder stringBuilder = new StringBuilder();
		foreach (object item in p0)
		{
			if (item != null)
			{
				if (stringBuilder.Length > 0)
				{
					stringBuilder.Append(p1);
				}
				stringBuilder.Append(Convert.ToString(item));
			}
		}
		return stringBuilder.ToString();
	}

	public static bool z0yek(XTextElementList p0, bool p1, XTextDocument p2, XTextContainerElement p3, bool p4)
	{
		if (p0 == null || p0.Count == 0)
		{
			return false;
		}
		if (p4 && p0.z0bek())
		{
			return false;
		}
		if (p0.z0zek() != null)
		{
			p0[0].z0yek(p2, p3);
			return true;
		}
		XTextElement[] array = ((zzz.z0ZzZzkuk<XTextElement>)p0).z0krk();
		p0.z0nek(p0: true);
		int count = p0.Count;
		bool flag = false;
		if (!p1)
		{
			for (int num = count - 1; num >= 0; num--)
			{
				if (array[num] is XTextTextElement || array[num] is XTextStringElement)
				{
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				return false;
			}
		}
		bool flag2 = false;
		bool flag3 = false;
		if (p2 != null)
		{
			DocumentBehaviorOptions documentBehaviorOptions = p2.z0bu();
			flag2 = documentBehaviorOptions.AutoClearInvalidateCharacter;
			flag3 = documentBehaviorOptions.ParseCrLfAsLineBreakElement;
		}
		zzz.z0ZzZzkuk<XTextElement> z0ZzZzkuk2 = new zzz.z0ZzZzkuk<XTextElement>(p0.Count);
		for (int i = 0; i < count; i++)
		{
			XTextElement xTextElement = array[i];
			if (xTextElement is XTextTextElement || xTextElement is XTextStringElement)
			{
				if (xTextElement is XTextTextElement)
				{
					((XTextTextElement)xTextElement).z0eek();
				}
				xTextElement.z0drk(p0: false);
				string text = xTextElement.Text;
				if (text != null && text.Length > 0)
				{
					int z0buk = xTextElement.z0buk;
					if (text.IndexOf(z0krk, StringComparison.Ordinal) < 0)
					{
						int length = text.Length;
						z0ZzZzkuk2.z0yrk(z0ZzZzkuk2.Count + length);
						for (int j = 0; j < length; j++)
						{
							char c = text[j];
							if (c >= ' ')
							{
								z0ZzZzkuk2.z0mek(new XTextCharElement(c, p3, p2, z0buk));
								if (XTextCharElement.z0tek((int)c) && j < length - 1)
								{
									char p5 = text[++j];
									if (XTextCharElement.z0rek((int)p5))
									{
										((XTextCharElement)z0ZzZzkuk2.LastElement).z0rek((ushort)p5);
									}
								}
								continue;
							}
							switch (c)
							{
							case '\r':
								if (flag3)
								{
									XTextLineBreakElement xTextLineBreakElement = new XTextLineBreakElement();
									xTextLineBreakElement.z0yek(p3, p2, z0buk);
									z0ZzZzkuk2.z0mek(xTextLineBreakElement);
								}
								else
								{
									XTextParagraphFlagElement xTextParagraphFlagElement = new XTextParagraphFlagElement();
									xTextParagraphFlagElement.z0yek(p3, p2, z0buk);
									z0ZzZzkuk2.z0mek(xTextParagraphFlagElement);
								}
								break;
							default:
								if (flag2 && (c <= '\b' || c == '\u001f'))
								{
									z0ZzZzkuk2.z0mek(new XTextCharElement(' ', p3, p2, z0buk));
								}
								else
								{
									z0ZzZzkuk2.z0mek(new XTextCharElement(c, p3, p2, z0buk));
								}
								break;
							case '\n':
								break;
							}
						}
					}
					else
					{
						string[] array2 = z0ZzZznik.AnalyseVariableString(text, z0krk, z0frk);
						for (int k = 0; k < array2.Length; k++)
						{
							string text2 = array2[k];
							if (k % 2 != 0)
							{
								if (text2 == z0cek)
								{
									XTextPageInfoElement xTextPageInfoElement = new XTextPageInfoElement();
									xTextPageInfoElement.ValueType = PageInfoValueType.PageIndex;
									xTextPageInfoElement.z0yek(p3, p2, z0buk);
									z0ZzZzkuk2.Add(xTextPageInfoElement);
									text2 = null;
								}
								else
								{
									text2 = z0krk + text2 + z0frk;
								}
							}
							if (text2 == null || text2.Length <= 0)
							{
								continue;
							}
							int length2 = text2.Length;
							for (int l = 0; l < length2; l++)
							{
								char c2 = text2[l];
								if (flag2 && c2 <= '\b')
								{
									XTextCharElement item = new XTextCharElement(' ', p3, p2, z0buk);
									z0ZzZzkuk2.Add(item);
									continue;
								}
								switch (c2)
								{
								case '\r':
									if (flag3)
									{
										XTextLineBreakElement xTextLineBreakElement2 = new XTextLineBreakElement();
										xTextLineBreakElement2.z0yek(p3, p2, z0buk);
										z0ZzZzkuk2.Add(xTextLineBreakElement2);
									}
									else
									{
										XTextParagraphFlagElement xTextParagraphFlagElement2 = new XTextParagraphFlagElement();
										xTextParagraphFlagElement2.z0yek(p3, p2, z0buk);
										z0ZzZzkuk2.Add(xTextParagraphFlagElement2);
									}
									break;
								default:
								{
									XTextCharElement item2 = new XTextCharElement(c2, p3, p2, z0buk);
									z0ZzZzkuk2.Add(item2);
									break;
								}
								case '\n':
									break;
								}
							}
						}
					}
				}
				flag = true;
			}
			else
			{
				if (p1 && xTextElement is XTextContainerElement)
				{
					z0yek(((XTextContainerElement)xTextElement).z0be(), p1, p2, (XTextContainerElement)xTextElement, p4);
				}
				z0ZzZzkuk2.Add(xTextElement);
			}
		}
		if (flag)
		{
			z0ZzZzkuk2.z0qrk(p0, p1: true);
		}
		return flag;
	}

	public static long z0uek()
	{
		return (long)(DateTime.Now - z0grk).TotalMilliseconds;
	}

	private static void z0yek(XTextElementList p0, ElementEnumerateEventHandler p1, ElementEnumerateEventArgs p2, bool p3)
	{
		if (p2.ReverseMode)
		{
			return;
		}
		foreach (XTextElement item in p0.z0xrk())
		{
			XTextElement xTextElement = (p2.z0pek = item);
			p2.CancelChild = false;
			p1(null, p2);
			p2.z0eek();
			if (p2.Cancel)
			{
				break;
			}
			if (!p2.CancelChild && p3 && xTextElement is XTextContainerElement)
			{
				z0yek(((XTextContainerElement)xTextElement).z0be(), p1, p2, p3);
				if (p2.Cancel)
				{
					break;
				}
			}
			p2.CancelChild = false;
		}
	}

	public static int[] z0uek(byte[] p0)
	{
		if (p0 == null || p0.Length == 0)
		{
			throw new ArgumentNullException("bs");
		}
		if (p0.Length % 4 != 0)
		{
			throw new ArgumentException("bs.Length =" + p0.Length);
		}
		int[] array = new int[p0.Length / 4];
		Buffer.BlockCopy(p0, 0, array, 0, p0.Length);
		return array;
	}

	public static bool z0yek(object p0, ref bool p1)
	{
		if (p0 == null || DBNull.Value.Equals(p0))
		{
			return false;
		}
		if (p0 is bool)
		{
			p1 = (bool)p0;
			return true;
		}
		string text = Convert.ToString(p0);
		text = text.Trim();
		if (text.Equals("true", StringComparison.CurrentCultureIgnoreCase) || text == "1")
		{
			p1 = true;
			return true;
		}
		if (text.Equals("false", StringComparison.CurrentCultureIgnoreCase) || text == "0")
		{
			p1 = false;
			return true;
		}
		return false;
	}

	public static bool z0yek(int p0, int p1)
	{
		return (p0 & p1) == p1;
	}

	public static string z0pek(string p0)
	{
		if (string.IsNullOrEmpty(p0))
		{
			return null;
		}
		int num = Math.Min(p0.Length, 300);
		for (int i = 0; i < num; i++)
		{
			char c = p0[i];
			if (char.IsWhiteSpace(c) || c <= '\n' || c >= '\u007f')
			{
				continue;
			}
			switch (c)
			{
			case '{':
			{
				int num2 = p0.IndexOf("Type", i, 200, StringComparison.Ordinal);
				if (num2 >= 0 && p0.IndexOf("\"DCDocument2022\"", num2 + 1, 200, StringComparison.Ordinal) > 0)
				{
					return "json";
				}
				num2 = p0.IndexOf("{\\rtf", i, 200, StringComparison.Ordinal);
				if (num2 >= 0)
				{
					return "rtf";
				}
				break;
			}
			case '<':
				if (p0.IndexOf("<XTextDocument", i, 200, StringComparison.Ordinal) >= 0)
				{
					return "xml";
				}
				if (p0.IndexOf("<DCDocument2022", i, 200, StringComparison.Ordinal) >= 0)
				{
					return "xml2022";
				}
				if (p0.IndexOf("<html", i, 200, StringComparison.OrdinalIgnoreCase) >= 0)
				{
					return "html";
				}
				break;
			}
			break;
		}
		return null;
	}

	static z0ZzZzafh()
	{
		z0xek = "";
		z0grk = DateTime.Today;
		z0lrk = IntPtr.Zero;
		z0bek = null;
		z0drk = string.Empty;
		z0nek = null;
		z0jrk = new z0ZzZzsdh(z0ZzZzimk.DefaultFontName, 12f);
		z0krk = "[%";
		z0frk = "%]";
		z0cek = "pageindex";
		z0hrk = z0ZzZzccj.z0qrk++;
		z0bek = new string[30];
		for (int i = 0; i < z0bek.Length; i++)
		{
			z0bek[i] = new string(' ', i);
		}
	}

	public static int z0yek(object p0, int p1)
	{
		if (p0 == null || DBNull.Value.Equals(p0))
		{
			return p1;
		}
		int result = p1;
		if (p0 is string)
		{
			if (!int.TryParse((string)p0, out result))
			{
				return p1;
			}
		}
		else if (p0 is int || p0 is float || p0 is double || p0 is long || p0 is short || p0 is byte || p0 is uint)
		{
			result = Convert.ToInt32(p0);
		}
		return result;
	}

	public static void z0yek(XTextDocument p0, XTextTableElement p1)
	{
		if (p0.z0pu_jiejie20260327142557().FixWidthWhenInsertTable)
		{
			XTextContainerElement p2 = null;
			int p3 = 0;
			p0.z0ryk().z0tek(out p2, out p3);
			p2 = p2.z0jy();
			float num = Math.Min(((XTextElement)p2).z0ork(), p1.z0htk());
			using (zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = p1.z0srk().z0ltk())
			{
				while (z0bpk.MoveNext())
				{
					if (((XTextTableColumnElement)z0bpk.Current).z0uek())
					{
						num = ((XTextElement)p2).z0ork();
						break;
					}
				}
			}
			if (num != p1.z0htk())
			{
				p1.z0pek(num);
			}
			return;
		}
		float minTableColumnWidth = p0.z0iu().MinTableColumnWidth;
		using zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = p1.z0srk().z0ltk();
		while (z0bpk.MoveNext())
		{
			XTextTableColumnElement xTextTableColumnElement = (XTextTableColumnElement)z0bpk.Current;
			if (xTextTableColumnElement.z0uek())
			{
				xTextTableColumnElement.Width = minTableColumnWidth;
			}
		}
	}

	public static void z0yek(XTextDocument p0, XTextElement p1, bool p2, XTextContainerElement p3)
	{
		if (p0.z0pu_jiejie20260327142557().FixSizeWhenInsertImage)
		{
			if (p3 == null)
			{
				int p4 = 0;
				p0.z0ryk().z0tek(out p3, out p4);
			}
			p3 = p3.z0jy();
			z0ZzZzxdh p5 = new z0ZzZzxdh(p1.Width, p1.Height);
			float p6 = 100000f;
			if (p3.z0qek().z0fu() == PageContentPartyStyle.Body && p0.z0npk() != null)
			{
				p6 = p0.z0npk().z0urk() - 10f;
			}
			p5 = z0ZzZzmpk.z0eek(new z0ZzZzxdh(((XTextElement)p3).z0ork() - p0.z0xek(2f), p6), p5, p2);
			p1.Width = p5.z0rek();
			p1.Height = p5.z0tek();
		}
	}

	public static XTextElementList z0yek(XTextElementList p0, bool p1, XTextContainerElement p2 = null)
	{
		return z0yek(p0, p1, null, p3: false, p2);
	}

	internal static bool z0yek(string p0, bool p1)
	{
		if (string.IsNullOrEmpty(p0))
		{
			return p1;
		}
		if (p0.Equals("true", StringComparison.OrdinalIgnoreCase) || p0.Equals("yes", StringComparison.OrdinalIgnoreCase) || p0 == "1")
		{
			return true;
		}
		if (p0.Equals("false", StringComparison.OrdinalIgnoreCase) || p0.Equals("no", StringComparison.OrdinalIgnoreCase) || p0.Equals("null", StringComparison.OrdinalIgnoreCase) || p0.Equals("undefined", StringComparison.OrdinalIgnoreCase) || p0 == "0")
		{
			return false;
		}
		double num = 0.0;
		if (double.TryParse(p0, out num))
		{
			return num != 0.0;
		}
		return p1;
	}

	public static bool z0tek<T>(this T[] p0, T p1)
	{
		if (p0 == null || p0.Length == 0)
		{
			return false;
		}
		for (int num = p0.Length - 1; num >= 0; num--)
		{
			if (object.Equals(p0[num], p1))
			{
				return true;
			}
		}
		return false;
	}

	public static string z0yek(string p0, int p1)
	{
		if (string.IsNullOrEmpty(p0))
		{
			return string.Empty;
		}
		if (p0.Length > p1)
		{
			return p0.Substring(0, p1);
		}
		return p0;
	}

	public static void z0iek(XTextElementList p0)
	{
		if (p0 == null || p0.Count == 0)
		{
			return;
		}
		for (int i = 0; i < p0.Count; i++)
		{
			XTextElement xTextElement = p0[i];
			if (xTextElement is XTextInputFieldElement)
			{
				XTextInputFieldElement xTextInputFieldElement = (XTextInputFieldElement)xTextElement;
				p0.RemoveAt(i);
				p0.z0yek(i, xTextInputFieldElement.z0be());
			}
			else if (xTextElement is XTextContainerElement)
			{
				z0iek(xTextElement.z0be());
			}
		}
	}

	public static string z0uek(int p0)
	{
		if (p0 < 0)
		{
			throw new ArgumentOutOfRangeException("len+" + p0);
		}
		if (p0 == 0)
		{
			return string.Empty;
		}
		if (p0 < 30)
		{
			return z0bek[p0];
		}
		return new string(' ', p0);
	}

	public static int z0iek(this z0ZzZzzlh[] p0, z0ZzZzzlh p1)
	{
		if (p1 == null)
		{
			throw new ArgumentNullException("line");
		}
		int z0tuk = p1.z0tuk;
		if (z0tuk >= 0 && z0tuk < p0.Length && p0[z0tuk] == p1)
		{
			return z0tuk;
		}
		return Array.IndexOf(p0, p1);
	}
}
