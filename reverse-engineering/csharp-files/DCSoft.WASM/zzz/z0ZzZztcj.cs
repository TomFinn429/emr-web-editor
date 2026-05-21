using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using DCSoft.Drawing;
using DCSoft.WASM;
using DCSoft.Writer;
using DCSoft.Writer.Controls;
using DCSoft.Writer.Dom;

namespace zzz;

public class z0ZzZztcj : z0ZzZzpxj
{
	private class z0jxk : IDisposable
	{
		public Dictionary<z0iok, bool> z0eek = new Dictionary<z0iok, bool>();

		public void Dispose()
		{
			if (z0eek != null)
			{
				z0eek.Clear();
				z0eek = null;
			}
		}
	}

	internal struct z0iok
	{
		public XTextElement z0eek;

		public z0ZzZzbcj z0rek;

		public bool z0tek;

		public readonly int z0yek;

		public z0iok(XTextElement p0, z0ZzZzbcj p1, bool p2 = false)
		{
			z0eek = p0;
			z0rek = p1;
			z0tek = p2;
			z0yek = z0eek.GetHashCode() + 2 * (int)z0rek + z0tek.GetHashCode();
		}

		public override int GetHashCode()
		{
			return z0yek;
		}

		public override bool Equals(object obj)
		{
			z0iok z0iok = (z0iok)obj;
			if (z0eek == z0iok.z0eek && z0rek == z0iok.z0rek)
			{
				return z0tek == z0iok.z0tek;
			}
			return false;
		}
	}

	private FormViewMode z0mek;

	private XTextDocument z0nek;

	private readonly string z0bek = z0ZzZziok.z0sok();

	private bool z0vek;

	private bool z0cek;

	public static readonly string[] z0xek_jiejie20260327142557 = new string[7]
	{
		"FileNameW",
		z0ZzZzvwh.z0yek,
		z0ZzZzvwh.z0rek,
		z0ZzZzvwh.z0iek,
		z0ZzZzvwh.z0uek,
		z0tek(),
		"DCWriterCommand"
	};

	private int z0zek;

	private static int[] z0lrk = null;

	private bool z0krk;

	private z0ZzZzlfh z0jrk;

	private z0ZzZzycj z0hrk;

	private bool z0frk;

	[NonSerialized]
	private z0ZzZzdbj z0drk;

	private DocumentBehaviorOptions z0srk;

	private DateTime z0ark = DateTime.MinValue;

	private static int z0qrk = -1;

	private z0ZzZzhcj z0wrk;

	private z0jxk z0erk;

	private int z0rrk;

	public void z0mn(z0ZzZzdbj p0)
	{
		z0drk = p0;
	}

	public z0ZzZzkeh z0eek(bool p0)
	{
		z0ZzZzkeh z0ZzZzkeh2 = z0wn_jiejie20260327142557(z0ip().CreationDataFormats, p0 || z0dm().z0pu_jiejie20260327142557().CopyInTextFormatOnly, z0dm().z0pu_jiejie20260327142557().ClearFieldValueWhenCopy, z0dm().z0pu_jiejie20260327142557().CopyWithoutInputFieldStructure, p4: true);
		if (z0ZzZzkeh2 != null)
		{
			if (z0dm().z0vtk().BehaviorOptions.DataObjectRange == WriterDataObjectRange.OS && z0zek > 51200 && (DateTime.Now - z0ark).TotalMilliseconds < 500.0)
			{
				return null;
			}
			z0ark = DateTime.Now;
			z0ip().z0eek(z0ZzZzkeh2);
			return z0ZzZzkeh2;
		}
		return null;
	}

	public virtual XTextElementList z0pn(string p0, bool p1, InputValueSource p2, DocumentContentStyle p3, DocumentContentStyle p4)
	{
		bool flag = z0hm();
		if (z0ip() != null)
		{
			FilterValueEventArgs e = new FilterValueEventArgs(p2, InputValueType.Text, p0);
			z0ip().z0eek(e);
			if (e.Cancel)
			{
				return null;
			}
			p0 = e.Value as string;
		}
		if (string.IsNullOrEmpty(p0))
		{
			return null;
		}
		if (p3 == null)
		{
			p3 = z0dm().z0onk().z0iek();
		}
		if (p4 == null)
		{
			p4 = (DocumentContentStyle)z0dm().z0onk().z0uek().Clone();
			p4.FontName = p3.FontName;
			p4.FontSize = p3.FontSize;
			p4.Italic = p3.Italic;
			p4.Bold = p3.Bold;
			p4.Underline = p3.Underline;
			p4.Strikeout = p3.Strikeout;
			p4.Color = p3.Color;
			if (p4.ParagraphOutlineLevel >= 0)
			{
				_ = p4.ParagraphListStyle;
			}
		}
		XTextContainerElement xTextContainerElement = (XTextContainerElement)z0dm().z0bek(typeof(XTextContainerElement));
		if (xTextContainerElement is XTextInputFieldElement)
		{
			XTextElement xTextElement = z0dm().z0itk();
			if (xTextElement is XTextFieldBorderElement && ((XTextFieldBorderElement)xTextElement).z0mek() == (z0ZzZzzvj)0)
			{
				xTextContainerElement = xTextContainerElement.z0ji();
			}
		}
		if (p2 == InputValueSource.UI && p0 == "\t" && !xTextContainerElement.AcceptTab)
		{
			return null;
		}
		p0 = z0eek(xTextContainerElement, p0);
		if (string.IsNullOrEmpty(p0))
		{
			return null;
		}
		XTextElementList xTextElementList = z0dm().z0bek(p0, p4, p3, xTextContainerElement.z0brk());
		if (xTextElementList == null || xTextElementList.Count == 0)
		{
			return null;
		}
		XTextCharElement xTextCharElement = null;
		if (flag)
		{
			XTextElement xTextElement2 = null;
			xTextElement2 = ((z0yek().z0qrk() != 0) ? z0yek().z0uek() : z0dm().z0itk());
			if (xTextElement2 != null && xTextElement2.z0ptk() != null)
			{
				z0ZzZzzlh z0ZzZzzlh2 = xTextElement2.z0ptk();
				if (z0ZzZzzlh2.z0bek())
				{
					using zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = ((zzz.z0ZzZzkuk<XTextElement>)z0ZzZzzlh2).z0ltk();
					while (z0bpk.MoveNext())
					{
						XTextElement current = z0bpk.Current;
						if (current.z0wtk())
						{
							xTextCharElement = null;
							break;
						}
						if (current is XTextCharElement)
						{
							char c = ((XTextCharElement)current).z0mek();
							if (c >= 'a' && c <= 'z')
							{
								if (xTextCharElement == null)
								{
									xTextCharElement = (XTextCharElement)current;
								}
							}
							else if (!char.IsLetter(c))
							{
								xTextCharElement = null;
								break;
							}
						}
						else if (xTextCharElement == null)
						{
							break;
						}
						if (current == xTextElement2)
						{
							break;
						}
					}
				}
				if (xTextCharElement != null && !z0np(xTextCharElement))
				{
					xTextCharElement = null;
				}
			}
		}
		if (p1)
		{
			z0dm().z0ytk();
		}
		if (z0eek().z0urk())
		{
			if (z0oek_jiejie20260327142557().z0tek(p0: true, p1: false, p2: false) > 0)
			{
				z0dm().Modified = true;
			}
		}
		else if (z0ip() != null && !z0ip().z0duk() && z0oek_jiejie20260327142557().z0mek(p0: true) > 0)
		{
			z0dm().Modified = true;
		}
		if (xTextElementList.Count == 1 && xTextElementList[0] is XTextParagraphFlagElement && (z0dm().z0grk() || z0dm().z0eok()))
		{
			XTextParagraphFlagElement obj = (XTextParagraphFlagElement)xTextElementList[0];
			DocumentContentStyle style = new DocumentContentStyle
			{
				Align = DocumentContentAlignment.Left
			};
			obj.z0oek(z0dm().z0gnk().GetStyleIndex(style));
		}
		DocumentContentStyle documentContentStyle = z0dm().z0onk().z0tek();
		DocumentContentStyle p5 = z0dm().z0onk().z0iek();
		XTextDocumentContentElement.z0xrk = true;
		int num = 0;
		try
		{
			z0ZzZzzxj z0ZzZzzxj2 = new z0ZzZzzxj();
			z0ZzZzzxj2.z0eek(xTextElementList);
			z0ZzZzzxj2.z0tek(p0: true);
			z0ZzZzzxj2.z0rek(p2 == InputValueSource.UI);
			num = z0dm().z0bek(z0ZzZzzxj2);
		}
		finally
		{
			XTextDocumentContentElement.z0xrk = false;
		}
		if (p2 == InputValueSource.UI && p0 != null && p0.Length == 1)
		{
			z0oek_jiejie20260327142557().z0irk();
		}
		if (xTextCharElement != null && !z0ZzZzeik.z0eek(p0[0]) && xTextCharElement != null)
		{
			char c2 = char.ToUpper(xTextCharElement.z0mek());
			char c3 = xTextCharElement.z0mek();
			xTextCharElement.CharValue = c2;
			if (p1 && z0dm().z0imk().z0iek())
			{
				z0dm().z0imk().z0eek("CharValue", c3, c2, xTextCharElement);
			}
			xTextCharElement.z0oe();
			z0dm().OnSelectionChanged();
		}
		if (p1)
		{
			z0dm().z0nuk();
		}
		if (z0dm().z0zyk() && documentContentStyle != z0dm().z0onk().z0tek())
		{
			z0dm().z0onk().z0eek(documentContentStyle);
			z0dm().z0onk().z0rek(z0dm());
			z0dm().z0onk().z0rek(p5);
		}
		z0dm().Modified = true;
		if (num > 0)
		{
			z0dm().OnDocumentContentChanged();
			return xTextElementList;
		}
		return null;
	}

	public void z0on()
	{
		z0rrk--;
		if (z0rrk <= 0)
		{
			z0rrk = 0;
			z0srk = null;
			z0erk?.Dispose();
			z0erk = null;
		}
	}

	public z0ZzZzycj z0in()
	{
		if (z0hrk != null && (z0hrk.z0rek() != z0dm().z0kek() || z0hrk.z0eek() != z0dm().z0cuk().z0pek()))
		{
			z0hrk = null;
		}
		if (z0hrk == null)
		{
			z0hrk = new z0ZzZzycj();
			z0hrk.z0rek(z0dm().z0kek());
			z0hrk.z0eek(z0dm().z0cuk().z0pek());
			z0hrk.z0eek(this);
			z0hrk.CanModifySelection = z0tm(p0: true);
			z0hrk.CanModifyParagraphs = z0un();
			z0hrk.z0eek(z0vp());
		}
		return z0hrk;
	}

	public virtual bool z0un()
	{
		using (zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = z0yek().z0ork().z0ltk())
		{
			while (z0bpk.MoveNext())
			{
				XTextElement current = z0bpk.Current;
				if (z0np(current))
				{
					return true;
				}
			}
		}
		return false;
	}

	public virtual bool z0eek(XTextElementList p0)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("elements");
		}
		XTextElement xTextElement = p0.z0grk();
		XTextElement item = p0.z0lrk();
		XTextDocumentContentElement xTextDocumentContentElement = xTextElement.z0qek();
		if (xTextDocumentContentElement != null)
		{
			int num = xTextDocumentContentElement.z0frk().IndexOf(xTextElement);
			int num2 = xTextDocumentContentElement.z0frk().IndexOf(item);
			if (num >= 0 && num2 >= num)
			{
				xTextDocumentContentElement.z0uek(num, num2 - num + 1);
				return true;
			}
		}
		return false;
	}

	public void z0yn(XTextDocument p0)
	{
		z0nek = p0;
	}

	public void z0tn()
	{
		z0hrk = null;
	}

	public virtual XTextImageElement z0eek(z0ZzZzpmk p0, bool p1, InputValueSource p2)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("img");
		}
		if (z0ip() != null)
		{
			FilterValueEventArgs e = new FilterValueEventArgs(p2, InputValueType.Image, p0.Value);
			z0ip().z0eek(e);
			if (e.Cancel)
			{
				return null;
			}
			if (!(e.Value is z0ZzZzedh value))
			{
				return null;
			}
			p0.Value = value;
		}
		XTextImageElement xTextImageElement = new XTextImageElement();
		xTextImageElement.z0bt(z0dm());
		xTextImageElement.z0rek(p0);
		xTextImageElement.z0eek(p0: false);
		z0ZzZzafh.z0yek(z0dm(), xTextImageElement, xTextImageElement.z0oek(), null);
		if (p1)
		{
			z0dm().z0ytk();
		}
		if (z0eek().z0urk())
		{
			z0oek_jiejie20260327142557().z0tek(p0: true, p1: false, p2: false);
		}
		z0dm().z0frk(xTextImageElement);
		z0dm().Modified = true;
		if (p1)
		{
			z0dm().z0nuk();
		}
		z0dm().OnDocumentContentChanged();
		return xTextImageElement;
	}

	public bool z0rn()
	{
		return z0eek().z0wrk();
	}

	public virtual void z0en(InsertObjectEventArgs p0)
	{
		if (p0 == null || p0.DataObject == null)
		{
			p0.Result = false;
			return;
		}
		p0.get_DetectForDragContent();
		string text = p0.SpecifyFormat;
		if (text != null)
		{
			text = text.Trim();
			if (text.Length == 0)
			{
				text = null;
			}
		}
		if (text != null && !p0.DataObject.z0jj(text))
		{
			p0.Result = false;
			return;
		}
		if (text == z0tek() || text == null)
		{
			if (p0.DataObject.z0jj(z0tek()))
			{
				if (z0ZzZzafh.z0yek(p0.AllowDataFormats, WriterDataFormats.XML))
				{
					z0eek(p0);
					return;
				}
				p0.RejectFormats.Add(z0tek().ToString());
			}
			if (text != null)
			{
				p0.Result = false;
				return;
			}
		}
		z0ZzZzyyk z0ZzZzyyk2 = new z0ZzZzyyk(p0.DataObject);
		if (text == "DCWriterCommand" || text == null)
		{
			if (p0.DataObject.z0jj("DCWriterCommand"))
			{
				if (z0ZzZzafh.z0yek(p0.AllowDataFormats, WriterDataFormats.CommandFormat))
				{
					string p1 = Convert.ToString(p0.DataObject.z0fj("DCWriterCommand"));
					object obj = z0dm().z0yyk().z0hrk(p1);
					p0.Result = obj != null;
					return;
				}
				p0.RejectFormats.Add("DCWriterCommand".ToString());
			}
			if (text != null)
			{
				p0.Result = false;
				return;
			}
		}
		if (text == "FileNameW" || text == null)
		{
			if (z0ZzZzyyk2.z0bek())
			{
				if (!z0ZzZzafh.z0yek(p0.AllowDataFormats, WriterDataFormats.FileSource))
				{
					p0.RejectFormats.Add("FileNames");
				}
				else
				{
					string text2 = z0ZzZzyyk2.z0rek();
					string text3 = text2.ToLower().Trim();
					if (text3.EndsWith(".bmp") || text3.EndsWith(".png") || text3.EndsWith(".jpg") || text3.EndsWith(".jpeg") || text3.EndsWith(".gif") || text3.EndsWith(".emf"))
					{
						if (z0ip() != null)
						{
							FilterValueEventArgs e = new FilterValueEventArgs(InputValueSource.Clipboard, InputValueType.FileName, text3);
							z0ip().z0eek(e);
							if (e.Cancel)
							{
								p0.Result = false;
								return;
							}
							text3 = e.Value as string;
							if (string.IsNullOrEmpty(text3))
							{
								p0.Result = false;
								return;
							}
						}
						z0ZzZzpmk z0ZzZzpmk2 = new z0ZzZzpmk();
						if (z0ZzZzpmk2.Load(text2) > 0 && z0an(typeof(XTextImageElement)))
						{
							XTextImageElement xTextImageElement = z0eek(z0ZzZzpmk2, p1: true, p0.InputSource);
							p0.Result = xTextImageElement != null;
							if (p0.Result)
							{
								p0.NewElements = new XTextElementList(xTextImageElement);
							}
							if (p0.Result && p0.AutoSelectContent)
							{
								z0eek(new XTextElementList(xTextImageElement));
							}
						}
						else
						{
							p0.Result = false;
						}
						return;
					}
				}
			}
			if (text != null)
			{
				p0.Result = false;
				return;
			}
		}
		if (text == z0ZzZzvwh.z0rek || text == null)
		{
			if (z0ZzZzyyk2.z0nek())
			{
				if (z0ZzZzafh.z0yek(p0.AllowDataFormats, WriterDataFormats.Image))
				{
					if (!z0eek(p0.DataObject, p0.ShowUI))
					{
						p0.Result = false;
						return;
					}
					z0ZzZzedh z0ZzZzedh2 = z0ZzZzyyk2.z0iek();
					if (z0ZzZzedh2 != null && z0an(typeof(XTextImageElement)))
					{
						z0ZzZzpmk p2 = new z0ZzZzpmk(z0ZzZzedh2);
						XTextImageElement xTextImageElement2 = z0eek(p2, p1: true, p0.InputSource);
						p0.Result = xTextImageElement2 != null;
						if (p0.Result)
						{
							p0.NewElements = new XTextElementList(xTextImageElement2);
						}
						if (p0.Result && p0.AutoSelectContent)
						{
							z0eek(new XTextElementList(xTextImageElement2));
						}
					}
					else
					{
						p0.Result = false;
					}
					return;
				}
				p0.RejectFormats.Add("Image");
			}
			if (text != null)
			{
				p0.Result = false;
				return;
			}
		}
		if (text == z0ZzZzvwh.z0yek || text == null)
		{
			if (z0ZzZzyyk2.z0tek())
			{
				if (z0ZzZzafh.z0yek(p0.AllowDataFormats, WriterDataFormats.RTF) && z0ZzZzxcj.z0eek(3))
				{
					if (!z0eek(p0.DataObject, p0.ShowUI))
					{
						p0.Result = false;
					}
					else if (z0up())
					{
						string text4 = z0ZzZzyyk2.z0mek();
						if (text4 != null)
						{
							int num = text4.LastIndexOf("}");
							if (num > 0 && num != text4.Length - 1)
							{
								text4 = text4.Substring(0, num + 1);
							}
						}
						XTextElementList xTextElementList = z0rek(text4, p1: true, p0.InputSource, p0);
						p0.Result = xTextElementList != null && xTextElementList.Count > 0;
						if (p0.Result)
						{
							p0.NewElements = xTextElementList;
						}
						if (p0.Result && p0.AutoSelectContent)
						{
							z0eek(xTextElementList);
						}
					}
					else
					{
						p0.Result = false;
					}
					return;
				}
				p0.RejectFormats.Add("RTF");
			}
			if (text != null)
			{
				p0.Result = false;
				return;
			}
		}
		if (text == z0ZzZzvwh.z0uek || text == null)
		{
			if (z0ZzZzyyk2.z0oek())
			{
				if (z0ZzZzafh.z0yek(p0.AllowDataFormats, WriterDataFormats.Html) && z0ZzZzxcj.z0eek(2))
				{
					if (!z0eek(p0.DataObject, p0.ShowUI))
					{
						p0.Result = false;
					}
					else if (z0up())
					{
						string p3 = z0ZzZzyyk2.z0yek();
						XTextElementList xTextElementList2 = z0eek(p3, p1: true, p0.InputSource, p0);
						p0.Result = xTextElementList2 != null && xTextElementList2.Count > 0;
						if (p0.Result)
						{
							p0.NewElements = xTextElementList2;
						}
						if (p0.Result && p0.AutoSelectContent)
						{
							z0eek(xTextElementList2);
						}
					}
					else
					{
						p0.Result = false;
					}
					return;
				}
				p0.RejectFormats.Add("Html");
			}
			if (text != null)
			{
				p0.Result = false;
				return;
			}
		}
		if (text == z0ZzZzvwh.z0iek || text == null)
		{
			if (z0ZzZzyyk2.z0uek())
			{
				if (z0ZzZzafh.z0yek(p0.AllowDataFormats, WriterDataFormats.Text))
				{
					if (!z0eek(p0.DataObject, p0.ShowUI))
					{
						p0.Result = false;
					}
					else if (z0up())
					{
						string text5 = z0ZzZzyyk2.z0eek();
						if (p0.CheckMaxTextLengthForCopyPaste)
						{
							text5 = z0dm().z0bek(text5, p0.ShowUI);
							if (string.IsNullOrEmpty(text5))
							{
								return;
							}
						}
						XTextElementList xTextElementList3 = z0pn(text5, p1: true, p0.InputSource, null, null);
						p0.Result = xTextElementList3 != null && xTextElementList3.Count > 0;
						if (p0.Result)
						{
							p0.NewElements = xTextElementList3;
						}
						if (p0.Result && p0.AutoSelectContent)
						{
							z0eek(xTextElementList3);
						}
					}
					else
					{
						p0.Result = false;
					}
					return;
				}
				p0.RejectFormats.Add("Text");
			}
			p0.Result = false;
		}
		else
		{
			p0.Result = false;
		}
	}

	private XTextDocumentContentElement z0eek()
	{
		return z0dm().z0jrk();
	}

	public z0ZzZzkeh z0wn_jiejie20260327142557(WriterDataFormats p0, bool p1, bool p2, bool p3, bool p4)
	{
		z0zek = 0;
		z0ZzZzhkh z0ZzZzhkh2 = z0yek();
		if (z0ZzZzhkh2 != null && z0ZzZzhkh2.z0qrk() != 0)
		{
			z0ZzZzkeh z0ZzZzkeh2 = z0ip().z0ypk().z0quk().z0bk();
			string text = z0ZzZzhkh2.z0wrk();
			if (text != null && text.Length > 0)
			{
				text = z0ZzZzqik.z0yek(text);
				if (text.Length > 1024)
				{
					text = text.Substring(0, 1024);
				}
				z0ip().z0ypk().z0quk().z0ck(z0ZzZzkeh2, text);
				z0zek += Encoding.UTF8.GetByteCount(text);
			}
			z0ZzZzkeh2.z0gj(z0ZzZzkfh.z0bek, z0dm().z0ipk().z0grk());
			if (z0ip() != null)
			{
				z0ZzZzkeh2.z0gj(z0ZzZzkfh.z0ark, ((IntPtr)z0ip().z0hhk()).ToString());
			}
			if (z0ZzZzafh.z0yek(p0, WriterDataFormats.Text) || p1)
			{
				string text2 = (p4 ? z0ZzZzhkh2.z0srk() : z0ZzZzhkh2.z0wrk());
				z0ZzZzkeh2.z0gj(z0ZzZzvwh.z0iek, text2);
				z0zek += Encoding.UTF8.GetByteCount(text2);
			}
			if (p1)
			{
				return z0ZzZzkeh2;
			}
			if (z0ZzZzafh.z0yek(p0, WriterDataFormats.RTF))
			{
				string text3 = z0ZzZzhkh2.z0rek(p4);
				if (text3 != null && text3.Length > 0)
				{
					z0ZzZzkeh2.z0gj(z0ZzZzvwh.z0yek, text3);
					z0zek += Encoding.UTF8.GetByteCount(text3);
				}
			}
			if (z0ZzZzafh.z0yek(p0, WriterDataFormats.Image) && z0ZzZzhkh2.z0qrk() == 1 && z0ZzZzhkh2.z0yek() == ContentRangeMode.Content && z0ZzZzhkh2.z0grk()[0] is XTextImageElement)
			{
				XTextImageElement xTextImageElement = (XTextImageElement)z0ZzZzhkh2.z0grk()[0];
				if (xTextImageElement.z0frk().Value != null)
				{
					z0ZzZzkeh2.z0gj(z0ZzZzvwh.z0rek, xTextImageElement.z0frk().Value);
					z0zek += xTextImageElement.z0frk().ByteSize;
				}
			}
			string text4 = null;
			if (z0ZzZzafh.z0yek(p0, WriterDataFormats.XML))
			{
				using XTextDocument xTextDocument = z0ZzZzhkh2.z0tek(p4);
				if (p2)
				{
					using zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = xTextDocument.z0nek<XTextInputFieldElementBase>().z0ltk();
					while (z0bpk.MoveNext())
					{
						XTextInputFieldElementBase obj = (XTextInputFieldElementBase)z0bpk.Current;
						obj.z0zek((string)null);
						obj.InnerValue = null;
					}
				}
				if (p3)
				{
					z0ZzZzafh.z0iek(xTextDocument.z0be());
				}
				StringWriter stringWriter = new StringWriter();
				xTextDocument.z0vek(stringWriter, z0ZzZzkfh.z0uek);
				string text5 = stringWriter.ToString();
				z0zek += Encoding.UTF8.GetByteCount(text5);
				z0ZzZzkeh2.z0gj(z0tek(), text5);
				text4 = text5;
			}
			if (z0ZzZzafh.z0yek(p0, WriterDataFormats.Html))
			{
				z0ZzZzrjh obj2 = new z0ZzZzrjh();
				obj2.z0zek().Add(z0dm());
				obj2.Options.IndentHtmlCode = true;
				obj2.Options.KeepLineBreak = true;
				obj2.Options.UseClassAttribute = false;
				obj2.z0rek(p0: true);
				obj2.Options.ExcludeLogicDeleted = p4;
				obj2.Options.OutputHeaderFooter = false;
				obj2.Options.ViewStyle = (z0ZzZzlgh)0;
				obj2.Options.ContentEncoding = Encoding.UTF8;
				obj2.Options.Chartset = "text/plain;charset=utf-8";
				obj2.Options.DocumentOptions = z0dm().z0vtk().z0rek();
				obj2.z0oek();
				string text6 = ((z0ZzZzfjh)obj2).z0cek();
				if (text6 != null && text6.Length > 0)
				{
					z0zek += Encoding.UTF8.GetByteCount(text6);
					if (text4 != null && text4.Length > 0 && text4.Length < 1048576)
					{
						text6 = "<!--NX2023:" + z0ZzZztwh.z0yek(text4) + "**-->" + text6;
					}
					z0ZzZzkeh2.z0gj(z0ZzZzvwh.z0uek, text6);
				}
			}
			return z0ZzZzkeh2;
		}
		return null;
	}

	public bool z0qn(bool p0)
	{
		if (z0eek().z0urk())
		{
			z0mm();
			z0hn(p0);
			return true;
		}
		return false;
	}

	private void z0eek(InsertObjectEventArgs p0)
	{
		if (!p0.DataObject.z0jj(z0tek()))
		{
			p0.Result = false;
			return;
		}
		if (!z0ZzZzafh.z0yek(p0.AllowDataFormats, WriterDataFormats.XML))
		{
			p0.RejectFormats.Add(z0tek());
			p0.Result = false;
			return;
		}
		if (!z0up())
		{
			p0.Result = false;
			return;
		}
		XTextDocument xTextDocument = null;
		XTextElementList xTextElementList = null;
		if (p0.z0yek != null)
		{
			xTextDocument = p0.z0yek;
			xTextElementList = p0.z0jrk;
			p0.z0yek = null;
			p0.z0jrk = null;
		}
		else
		{
			string text = (string)p0.DataObject.z0fj(z0tek());
			if (string.IsNullOrEmpty(text))
			{
				p0.Result = false;
				return;
			}
			text = z0ZzZzzik.z0eek(text);
			z0ZzZzihh z0ZzZzihh2 = z0ZzZzhbj.JSProvider?.z0wlk(text);
			xTextDocument = new XTextDocument();
			if (z0ZzZzihh2 == null)
			{
				StringReader p1 = new StringReader(text);
				xTextDocument.z0bek(p1, z0ZzZzkfh.z0uek, p2: true);
			}
			else
			{
				xTextDocument.z0bek(z0ZzZzihh2, null);
			}
			if (!z0ln(xTextDocument, p1: true))
			{
				xTextDocument.Dispose();
				p0.Result = false;
				return;
			}
			xTextElementList = xTextDocument.z0xyk().z0be().z0pek();
			xTextDocument.z0ynk();
			if (xTextElementList == null || xTextElementList.Count == 0)
			{
				xTextDocument.Dispose();
				p0.Result = false;
				return;
			}
			if (z0ip() != null)
			{
				FilterValueEventArgs e = new FilterValueEventArgs(InputValueSource.Clipboard, InputValueType.Dom, xTextElementList);
				z0ip().z0eek(e);
				if (e.Cancel)
				{
					p0.Result = false;
					return;
				}
				xTextElementList = e.Value as XTextElementList;
				if (xTextElementList == null || xTextElementList.Count == 0)
				{
					p0.Result = false;
					return;
				}
			}
			if (p0.CheckMaxTextLengthForCopyPaste && !z0dm().z0bek(xTextElementList, p0.ShowUI))
			{
				return;
			}
			if (xTextElementList.LastElement is XTextParagraphFlagElement)
			{
				if (((XTextParagraphFlagElement)xTextElementList.LastElement).z0vek())
				{
					xTextElementList.RemoveAt(xTextElementList.Count - 1);
				}
				else
				{
					int num = 0;
					using (zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = xTextElementList.z0ltk())
					{
						while (z0bpk.MoveNext())
						{
							if (z0bpk.Current is XTextParagraphFlagElement)
							{
								num++;
								if (num > 1)
								{
									break;
								}
							}
						}
					}
					if (num == 1)
					{
						xTextElementList.RemoveAt(xTextElementList.Count - 1);
					}
				}
				if (xTextElementList.Count == 0)
				{
					p0.Result = false;
					return;
				}
			}
		}
		if (p0.get_DetectForDragContent())
		{
			p0.Result = z0eek(p0.CurrentElement, xTextElementList, p2: false, p3: true) > 0;
			xTextDocument.Dispose();
			xTextElementList.Clear();
			return;
		}
		z0dm().z0ytk();
		if (z0eek().z0urk())
		{
			z0oek_jiejie20260327142557().z0tek(p0: true, p1: false, p2: false);
		}
		z0dm().z0cek(xTextElementList);
		z0dm().z0xek(xTextElementList);
		p0.Result = z0eek(null, xTextElementList, p2: false, p3: false) > 0;
		if (p0.Result)
		{
			p0.NewElements = xTextElementList;
		}
		if (p0.Result && p0.AutoSelectContent)
		{
			z0eek(xTextElementList);
		}
		z0dm().z0nuk();
		z0dm().OnDocumentContentChanged();
	}

	private bool z0eek(XTextElement p0)
	{
		bool result = false;
		for (XTextElement xTextElement = p0.z0ji(); xTextElement != null; xTextElement = xTextElement.z0ji())
		{
			if (xTextElement is XTextInputFieldElementBase)
			{
				result = true;
				break;
			}
		}
		return result;
	}

	public bool z0an(Type p0)
	{
		return z0gm(p0, (z0ZzZzbcj)255);
	}

	public bool z0sn()
	{
		z0ZzZzkeh z0ZzZzkeh2 = z0wn_jiejie20260327142557(z0ip().CreationDataFormats, p1: true, z0dm().z0pu_jiejie20260327142557().ClearFieldValueWhenCopy, z0dm().z0pu_jiejie20260327142557().CopyWithoutInputFieldStructure, p4: true);
		if (z0ZzZzkeh2 != null)
		{
			z0ip().z0eek(z0ZzZzkeh2);
			return true;
		}
		return false;
	}

	public bool z0dn(XTextElement p0)
	{
		if (p0 != null)
		{
			p0.z0bt(z0dm());
			z0dm().z0ytk();
			if (p0.z0ao())
			{
				using z0ZzZzjpk p1 = z0dm().z0ru();
				z0ZzZzvxj z0ZzZzvxj2 = z0dm().z0bek(p1, (z0ZzZzcxj)0);
				z0ZzZzvxj2.z0hyk = p0;
				p0.z0mr(z0ZzZzvxj2);
			}
			bool result = z0dm().z0frk(p0);
			z0dm().z0nuk();
			z0dm().OnDocumentContentChanged();
			return result;
		}
		return false;
	}

	public virtual bool z0fn(XTextContainerElement p0, int p1, XTextElement p2, z0ZzZzbcj p3)
	{
		CanInsertElementEventArgs e = new CanInsertElementEventArgs(p0, p1, p2, p3);
		z0eek(e);
		return e.Result;
	}

	public virtual void z0eek(CanInsertElementEventArgs p0)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("args");
		}
		if (p0.Container == null)
		{
			throw new ArgumentNullException("args.Container");
		}
		if (p0.Element == null)
		{
			throw new ArgumentNullException("args.Element");
		}
		p0.Flags = z0eek(p0.Flags);
		if (z0rek())
		{
			p0.Result = z0qm(p0.Container, p0.Element, p0.Flags);
			return;
		}
		if (z0eek(p0.Flags, (z0ZzZzbcj)1) && z0kn())
		{
			if (p0.SetMessage)
			{
				p0.Message = z0ZzZziok.z0nok();
			}
			p0.Result = false;
			return;
		}
		if (z0eek(p0.Flags, (z0ZzZzbcj)32) && !z0wm())
		{
			XTextDocumentContentElement xTextDocumentContentElement = p0.Container.z0qek();
			if (xTextDocumentContentElement != null && xTextDocumentContentElement.z0frk().z0uek() >= 0)
			{
				XTextElement xTextElement = p0.Container.z0be().SafeGet(p0.Index);
				if (xTextElement != null && !xTextDocumentContentElement.z0frk().z0iek(xTextElement))
				{
					xTextElement = xTextElement.z0hy();
				}
				int p1 = xTextDocumentContentElement.z0frk().z0lrk(xTextElement);
				if (xTextDocumentContentElement.z0frk().z0tek(p1))
				{
					if (p0.SetMessage)
					{
						p0.Message = z0ZzZziok.z0euk();
					}
					z0eek(p0.Element, p0.Message, ContentProtectedReason.Lock);
					p0.Result = false;
					return;
				}
			}
		}
		if (z0eek(p0.Flags, (z0ZzZzbcj)16) && (z0bp() == FormViewMode.Normal || z0bp() == FormViewMode.Strict) && !z0eek(p0.Container) && !(p0.Container is XTextInputFieldElementBase))
		{
			if (p0.SetMessage)
			{
				p0.Message = z0ZzZziok.z0tok();
			}
			z0eek(p0.Element, p0.Message, ContentProtectedReason.FormViewMode);
			p0.Result = false;
			return;
		}
		if (!z0qm(p0.Container, p0.Element, p0.Flags))
		{
			if (p0.SetMessage)
			{
				p0.Message = string.Format(z0ZzZziok.z0irk(), p0.Container.z0hyk(), p0.Element.z0hyk());
			}
			p0.Result = false;
			return;
		}
		if (!z0eek(p0.Container, p0.Index))
		{
			if (p0.SetMessage)
			{
				p0.Message = z0bek;
			}
			p0.Result = false;
			return;
		}
		XTextContainerElement xTextContainerElement = p0.Container;
		if (!z0wm() && z0eek(p0.Flags, (z0ZzZzbcj)4) && xTextContainerElement.z0sek())
		{
			if (p0.SetMessage)
			{
				p0.Message = z0ZzZziok.z0nek();
			}
			p0.Result = false;
			return;
		}
		while (xTextContainerElement != null)
		{
			if (xTextContainerElement is XTextInputFieldElementBase)
			{
				XTextInputFieldElementBase xTextInputFieldElementBase = (XTextInputFieldElementBase)xTextContainerElement;
				if (z0eek(p0.Flags, (z0ZzZzbcj)2) && !xTextInputFieldElementBase.z0krk() && !z0wm())
				{
					if (p0.SetMessage)
					{
						p0.Message = string.Format(z0ZzZziok.z0otk(), xTextInputFieldElementBase.z0vek());
					}
					p0.Result = false;
					return;
				}
			}
			xTextContainerElement = xTextContainerElement.z0ji();
		}
		p0.Result = true;
	}

	public z0ZzZzhcj z0gn()
	{
		if (z0wrk != null)
		{
			z0ZzZzhcj result = z0wrk;
			z0wrk = null;
			return result;
		}
		return null;
	}

	public virtual bool z0hn(bool p0)
	{
		bool flag = false;
		int num = -1;
		z0dm().z0ntk();
		z0ip().z0zyk();
		if (!z0eek().z0urk())
		{
			XTextElement xTextElement = z0dm().z0itk();
			if (xTextElement is XTextFieldBorderElement)
			{
				XTextFieldElementBase xTextFieldElementBase = (XTextFieldElementBase)xTextElement.z0ji();
				if (xTextFieldElementBase.z0jrk() == xTextElement && xTextFieldElementBase.z0be().Count > 0)
				{
					z0dm().z0ryk().z0tek(z0dm().z0ryk().IndexOf(xTextElement) + 1, p1: false);
				}
				else if (xTextFieldElementBase.z0tek() == xTextElement && xTextFieldElementBase.z0be().Count > 0)
				{
					if (!z0dm().z0bu().AllowDeleteJumpOutOfField)
					{
						z0rek(p0: true);
						return false;
					}
					int num2 = 0;
					while (num2++ < 4 && xTextElement is XTextFieldBorderElement)
					{
						XTextElement xTextElement2 = z0dm().z0ryk().z0xek(xTextElement);
						if (xTextElement2 == null)
						{
							break;
						}
						XTextFieldElementBase xTextFieldElementBase2 = (XTextFieldElementBase)xTextElement.z0ji();
						if (xTextFieldElementBase2 == null)
						{
							break;
						}
						bool flag2 = z0eek(xTextFieldElementBase2);
						if (xTextFieldElementBase2.z0jrk() == xTextElement && !flag2 && !z0dm().z0ryk().Contains(xTextFieldElementBase2))
						{
							if (!z0dm().z0ryk().z0tek(z0dm().z0ryk().IndexOf(xTextElement2), p1: false))
							{
								break;
							}
							xTextElement = z0dm().z0itk();
							xTextElement2 = z0dm().z0ryk().z0xek(xTextElement);
						}
						else if (xTextFieldElementBase2.z0tek() == xTextElement)
						{
							if (!z0dm().z0ryk().z0tek(z0dm().z0ryk().IndexOf(xTextElement2), p1: false))
							{
								break;
							}
							xTextElement = z0dm().z0itk();
							xTextElement2 = z0dm().z0ryk().z0xek(xTextElement);
						}
					}
				}
			}
		}
		if (!z0eek().z0urk() && z0eek(z0oek_jiejie20260327142557().z0ork(), p1: false))
		{
			return true;
		}
		z0dm().z0ytk();
		num = ((!z0eek().z0urk()) ? z0oek_jiejie20260327142557().z0mek(p0: true) : z0oek_jiejie20260327142557().z0tek(p0: true, p1: false, p2: false));
		z0dm().z0nuk();
		if (num >= 0)
		{
			if (num > 0)
			{
				num--;
			}
			z0dm().OnDocumentContentChanged();
			flag = true;
		}
		if (z0dm().z0jyk() && p0)
		{
			z0dm().z0vek((z0ZzZzgcj)null);
		}
		z0dm().z0bek((z0ZzZzgcj)null);
		if (!flag)
		{
			bool flag3 = true;
			if (z0oek_jiejie20260327142557().z0ork() is XTextFieldBorderElement && z0ip().z0ook() == FormViewMode.Strict)
			{
				XTextFieldBorderElement xTextFieldBorderElement = (XTextFieldBorderElement)z0oek_jiejie20260327142557().z0ork();
				if (xTextFieldBorderElement.z0mek() == (z0ZzZzzvj)1 && xTextFieldBorderElement.z0ji().z0yek(typeof(XTextFieldElementBase), p1: false) == null)
				{
					flag3 = false;
				}
			}
			if (flag3)
			{
				z0rek(p0: true);
			}
		}
		return flag;
	}

	private bool z0rek()
	{
		if (z0ip() != null && z0ip().z0hik())
		{
			return true;
		}
		return false;
	}

	public bool z0jn(bool p0)
	{
		XTextElement xTextElement = z0dm().z0itk();
		if (xTextElement == null)
		{
			return false;
		}
		XTextParagraphFlagElement xTextParagraphFlagElement = xTextElement.z0dy();
		if (xTextParagraphFlagElement != null && xTextElement == xTextParagraphFlagElement.z0iek() && z0pm(xTextParagraphFlagElement, (z0ZzZzbcj)255))
		{
			DocumentContentStyle documentContentStyle = xTextParagraphFlagElement.z0aek().z0yek();
			documentContentStyle.z0eek(p0: true);
			bool flag = false;
			bool flag2 = false;
			if (p0)
			{
				XTextContentElement xTextContentElement = xTextParagraphFlagElement.z0jy();
				float num = 0f;
				num = ((xTextContentElement != null) ? (((XTextElement)xTextContentElement).z0ork() - 100f) : (((XTextElement)z0dm().z0xyk()).z0ork() - 100f));
				if (num < 0f)
				{
					num = 0f;
				}
				float num2 = documentContentStyle.FirstLineIndent;
				float num3 = documentContentStyle.LeftIndent;
				if (documentContentStyle.FirstLineIndent >= 90f)
				{
					num3 += 100f;
				}
				else
				{
					num2 += 100f;
				}
				if (num3 > num)
				{
					num3 = num;
				}
				if (num2 > num)
				{
					num2 = num;
				}
				if (num3 + num2 > num)
				{
					num2 = 0f;
					num3 = num;
				}
				if (documentContentStyle.FirstLineIndent != num2)
				{
					documentContentStyle.FirstLineIndent = num2;
					flag = true;
				}
				if (documentContentStyle.LeftIndent != num3)
				{
					documentContentStyle.LeftIndent = num3;
					flag = true;
				}
			}
			else if (documentContentStyle.ParagraphListStyle != ParagraphListStyle.None)
			{
				flag = true;
				if (documentContentStyle.IsListNumberStyle)
				{
					flag2 = true;
				}
				documentContentStyle.ParagraphListStyle = ParagraphListStyle.None;
				documentContentStyle.LeftIndent = 0f;
				documentContentStyle.FirstLineIndent = 0f;
				if (documentContentStyle.ParagraphOutlineLevel >= 0)
				{
					documentContentStyle = (DocumentContentStyle)z0dm().z0dik().Clone();
				}
			}
			else if (documentContentStyle.Align == DocumentContentAlignment.Right)
			{
				flag = true;
				documentContentStyle.Align = DocumentContentAlignment.Center;
			}
			else if (documentContentStyle.Align == DocumentContentAlignment.Center)
			{
				flag = true;
				documentContentStyle.Align = DocumentContentAlignment.Left;
			}
			else if (documentContentStyle.FirstLineIndent + documentContentStyle.LeftIndent < 30f && documentContentStyle.FirstLineIndent != 0f)
			{
				documentContentStyle.FirstLineIndent = 0f;
				documentContentStyle.LeftIndent = 0f;
				flag = true;
			}
			else if (documentContentStyle.FirstLineIndent > 0f)
			{
				documentContentStyle.FirstLineIndent -= 100f;
				if (documentContentStyle.FirstLineIndent < 0f)
				{
					documentContentStyle.FirstLineIndent = 0f;
				}
				if (documentContentStyle.FirstLineIndent < 5f)
				{
					documentContentStyle.FirstLineIndent = 0f;
				}
				flag = true;
			}
			else
			{
				float leftIndent = documentContentStyle.LeftIndent;
				documentContentStyle.LeftIndent -= 100f;
				if (documentContentStyle.LeftIndent < 0f)
				{
					documentContentStyle.LeftIndent = 0f;
				}
				flag = leftIndent != documentContentStyle.LeftIndent;
			}
			if (flag)
			{
				z0dm().z0bek((z0ZzZzdcj)null);
				documentContentStyle.CreatorIndex = z0dm().z0syk().z0yek();
				int styleIndex = z0dm().z0gnk().GetStyleIndex(documentContentStyle);
				if (z0dm().z0ytk())
				{
					z0dm().z0imk().z0eek(xTextParagraphFlagElement, ((XTextElement)xTextParagraphFlagElement).z0pek(), styleIndex);
				}
				xTextParagraphFlagElement.z0oek(styleIndex);
				xTextParagraphFlagElement.z0rrk();
				XTextElementList xTextElementList = new XTextElementList();
				xTextElementList.Add(xTextParagraphFlagElement.z0iek());
				xTextElementList.Add(xTextParagraphFlagElement.z0dek());
				if (flag2)
				{
					xTextParagraphFlagElement.z0qek().z0rek(p0: true);
					xTextParagraphFlagElement.z0qek().z0rek(p0: false, p1: true);
					if (z0dm().z0uik())
					{
						z0dm().z0imk().z0eek((z0ZzZzbzj)7);
					}
				}
				z0ZzZzafh.z0rek(z0dm(), new XTextElementList(xTextParagraphFlagElement), p2: false);
				xTextParagraphFlagElement.z0xi(p0: true);
				xTextParagraphFlagElement.z0jy().z0eek(xTextElementList, p1: true, p2: false);
				z0ip().z0vik();
				z0dm().OnSelectionChanged();
				z0dm().z0nuk();
				z0ip().z0ftk();
				z0ip().z0nuk();
				return true;
			}
		}
		return false;
	}

	public bool z0kn()
	{
		if (z0rrk > 0)
		{
			return z0vek;
		}
		if (z0ip() != null)
		{
			return z0ip().z0ork();
		}
		return false;
	}

	public virtual bool z0ln(XTextDocument p0, bool p1)
	{
		DocumentBehaviorOptions documentBehaviorOptions = z0pek();
		InsertDocumentWithCheckMRIDType insertDocumentWithCheckMRID = documentBehaviorOptions.InsertDocumentWithCheckMRID;
		if (insertDocumentWithCheckMRID == InsertDocumentWithCheckMRIDType.ForbitWhenFail || insertDocumentWithCheckMRID == InsertDocumentWithCheckMRIDType.WarringWhenFail || insertDocumentWithCheckMRID == InsertDocumentWithCheckMRIDType.PromptForbitWhenFail)
		{
			if (p0.z0ipk().z0drk())
			{
				return true;
			}
			if (!string.IsNullOrEmpty(z0dm().z0ipk().z0grk()) && z0dm().z0ipk().z0grk() != p0.z0ipk().z0grk())
			{
				switch (insertDocumentWithCheckMRID)
				{
				case InsertDocumentWithCheckMRIDType.ForbitWhenFail:
					return false;
				case InsertDocumentWithCheckMRIDType.PromptForbitWhenFail:
				{
					string text2 = documentBehaviorOptions.CustomPromptForbitCheckMRID;
					if (string.IsNullOrEmpty(text2))
					{
						text2 = z0ZzZziok.z0iek();
					}
					text2 = string.Format(text2, z0dm().z0ipk().z0grk(), p0.z0ipk().z0grk());
					if (p1)
					{
						z0ZzZzfpj.z0yek(z0ip(), text2);
					}
					return false;
				}
				default:
					if (p1)
					{
						string text = documentBehaviorOptions.CustomWarringCheckMRID;
						if (string.IsNullOrEmpty(text))
						{
							text = z0ZzZziok.z0vtk();
						}
						text = string.Format(text, z0dm().z0ipk().z0grk(), p0.z0ipk().z0grk());
						return z0ZzZzfpj.z0eek(z0ip(), text);
					}
					return false;
				}
			}
		}
		return true;
	}

	public virtual void z0zm(CanInsertObjectEventArgs p0)
	{
		if (p0 == null || p0.DataObject == null || p0.Handled)
		{
			return;
		}
		if (z0kn())
		{
			p0.Result = false;
			p0.Handled = true;
			return;
		}
		string text = p0.SpecifyFormat;
		if (text != null)
		{
			text = text.Trim();
			if (text.Length == 0)
			{
				text = null;
			}
		}
		if (text != null && !p0.DataObject.z0jj(text))
		{
			p0.Result = false;
			p0.Handled = true;
			return;
		}
		if (z0dm() == null)
		{
			p0.Result = false;
			p0.Handled = true;
			return;
		}
		XTextDocumentContentElement xTextDocumentContentElement = z0dm().z0jrk();
		XTextContainerElement p1 = null;
		int num = p0.SpecifyPosition;
		if (num < 0 || num >= xTextDocumentContentElement.z0frk().Count)
		{
			XTextElement xTextElement = z0dm().z0itk();
			if (xTextElement == null)
			{
				p0.Result = false;
				p0.Handled = true;
				return;
			}
			num = xTextDocumentContentElement.z0frk().IndexOf(xTextElement);
		}
		XTextElement xTextElement2 = xTextDocumentContentElement.z0frk()[num];
		XTextElement xTextElement3 = ((XTextElementList)xTextDocumentContentElement.z0frk()).z0pek(xTextElement2);
		if (xTextElement3 != null && xTextElement2.z0aek().z0otk == ContentProtectType.Range && xTextElement3.z0aek().z0otk == ContentProtectType.Range)
		{
			p0.Result = false;
			p0.Handled = true;
			return;
		}
		int p2 = 0;
		xTextDocumentContentElement.z0frk().z0tek(num, out p1, out p2, xTextDocumentContentElement.z0frk().z0frk());
		if (!z0eek(p1, p2, typeof(XTextElement), p0.AccessFlags))
		{
			p0.Result = false;
			p0.Handled = true;
			return;
		}
		z0ZzZzyyk z0ZzZzyyk2 = new z0ZzZzyyk(p0.DataObject);
		if (text == "FileNameW" || text == null)
		{
			if (z0ZzZzyyk2.z0bek() && z0ZzZzafh.z0yek(p0.AllowDataFormats, WriterDataFormats.FileSource))
			{
				string text2 = z0ZzZzyyk2.z0rek().ToLower().Trim();
				if (text2.EndsWith(".bmp") || text2.EndsWith(".png") || text2.EndsWith(".jpg") || text2.EndsWith(".jpeg") || text2.EndsWith(".gif") || text2.EndsWith(".emf"))
				{
					p0.Result = z0eek(p1, p2, typeof(XTextImageElement), p0.AccessFlags);
					p0.Handled = true;
					return;
				}
			}
			if (text != null)
			{
				p0.Result = false;
				p0.Handled = true;
				return;
			}
		}
		if (text == z0ZzZzvwh.z0yek || text == null)
		{
			if (z0ZzZzyyk2.z0tek() && z0ZzZzafh.z0yek(p0.AllowDataFormats, WriterDataFormats.RTF))
			{
				p0.Result = true;
				p0.Handled = true;
				return;
			}
			if (text != null)
			{
				p0.Result = false;
				p0.Handled = true;
				return;
			}
		}
		if (text == z0ZzZzvwh.z0rek || text == null)
		{
			if (z0ZzZzyyk2.z0nek() && z0ZzZzafh.z0yek(p0.AllowDataFormats, WriterDataFormats.Image))
			{
				p0.Result = z0eek(p1, p2, typeof(XTextImageElement), p0.AccessFlags);
				p0.Handled = true;
				return;
			}
			if (text != null)
			{
				p0.Result = false;
				p0.Handled = true;
				return;
			}
		}
		if (text == z0ZzZzvwh.z0iek || text == null)
		{
			if (z0ZzZzyyk2.z0uek() && z0ZzZzafh.z0yek(p0.AllowDataFormats, WriterDataFormats.Text))
			{
				p0.Result = true;
				p0.Handled = true;
				return;
			}
			if (text != null)
			{
				p0.Result = false;
				p0.Handled = true;
				return;
			}
		}
		if (text == "DCWriterCommand" || text == null)
		{
			if (z0ZzZzyyk2.z0rek("DCWriterCommand") && z0ZzZzafh.z0yek(p0.AllowDataFormats, WriterDataFormats.CommandFormat))
			{
				p0.Result = true;
				p0.Handled = true;
				return;
			}
			if (text != null)
			{
				p0.Result = false;
				p0.Handled = true;
				return;
			}
		}
		if (text == z0tek() || text == null)
		{
			if (p0.DataObject.z0jj(z0tek()) && z0ZzZzafh.z0yek(p0.AllowDataFormats, WriterDataFormats.XML))
			{
				p0.Result = true;
				p0.Handled = true;
				return;
			}
			if (text != null)
			{
				p0.Result = false;
				p0.Handled = true;
				return;
			}
		}
		if (p0.AllowDataFormats == WriterDataFormats.All)
		{
			p0.Result = true;
		}
		else
		{
			p0.Result = false;
		}
	}

	public bool z0xm()
	{
		return true;
	}

	public static string z0tek()
	{
		return z0ZzZzkfh.z0zek;
	}

	public virtual bool z0eek(z0ZzZzkeh p0, bool p1)
	{
		string text = null;
		if (p0.z0jj(z0ZzZzkfh.z0bek))
		{
			text = Convert.ToString(p0.z0fj(z0ZzZzkfh.z0bek));
		}
		DocumentBehaviorOptions documentBehaviorOptions = z0pek();
		if (string.IsNullOrEmpty(text) && documentBehaviorOptions.DisableCheckMRIDWhenMRIDIsEmptyForOuterDataObject)
		{
			return true;
		}
		InsertDocumentWithCheckMRIDType insertDocumentWithCheckMRID = documentBehaviorOptions.InsertDocumentWithCheckMRID;
		if ((insertDocumentWithCheckMRID == InsertDocumentWithCheckMRIDType.ForbitWhenFail || insertDocumentWithCheckMRID == InsertDocumentWithCheckMRIDType.WarringWhenFail || insertDocumentWithCheckMRID == InsertDocumentWithCheckMRIDType.PromptForbitWhenFail) && !string.IsNullOrEmpty(z0dm().z0ipk().z0grk()) && z0dm().z0ipk().z0grk() != text)
		{
			switch (insertDocumentWithCheckMRID)
			{
			case InsertDocumentWithCheckMRIDType.ForbitWhenFail:
				return false;
			case InsertDocumentWithCheckMRIDType.PromptForbitWhenFail:
			{
				string text3 = documentBehaviorOptions.CustomPromptForbitCheckMRID;
				if (string.IsNullOrEmpty(text3))
				{
					text3 = z0ZzZziok.z0iek();
				}
				text3 = string.Format(text3, z0dm().z0ipk().z0grk(), text);
				if (p1)
				{
					z0ZzZzfpj.z0yek(z0ip(), text3);
				}
				return false;
			}
			default:
				if (p1)
				{
					string text2 = documentBehaviorOptions.CustomWarringCheckMRID;
					if (string.IsNullOrEmpty(text2))
					{
						text2 = z0ZzZziok.z0vtk();
					}
					text2 = string.Format(text2, z0dm().z0ipk().z0grk(), text);
					return z0ZzZzfpj.z0eek(z0ip(), text2);
				}
				return false;
			}
		}
		return true;
	}

	public virtual bool z0cm(XTextElement p0, z0ZzZzbcj p1)
	{
		z0wrk = null;
		ElementStateDetectEventArgs e = new ElementStateDetectEventArgs(p0, p1);
		z0rm(e);
		return e.Result;
	}

	public XTextElementList z0vm(string p0)
	{
		return z0pn(p0, p1: true, InputValueSource.Unknow, null, null);
	}

	public void z0eek(z0ZzZzlfh p0)
	{
		z0jrk = p0;
	}

	public virtual bool z0bm(XTextContainerElement p0, int p1, Type p2)
	{
		CanInsertElementEventArgs e = new CanInsertElementEventArgs(p0, p1, p2, (z0ZzZzbcj)255);
		z0rek(e);
		return e.Result;
	}

	private bool z0eek(XTextElement p0, bool p1)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("element");
		}
		XTextFieldElementBase xTextFieldElementBase = null;
		if (p0 is XTextFieldBorderElement)
		{
			xTextFieldElementBase = p0.z0ji() as XTextFieldElementBase;
		}
		if (p0.z0ji() is XTextFieldElementBase)
		{
			XTextFieldElementBase xTextFieldElementBase2 = (XTextFieldElementBase)p0.z0ji();
			if (xTextFieldElementBase2.z0eek(p0))
			{
				xTextFieldElementBase = xTextFieldElementBase2;
			}
		}
		if (xTextFieldElementBase == null)
		{
			return false;
		}
		bool flag = false;
		if (xTextFieldElementBase.z0be().Count == 0)
		{
			flag = true;
		}
		else if (xTextFieldElementBase.z0eek(p0) && !z0dm().z0vtk().SecurityOptions.ShowLogicDeletedContent)
		{
			flag = true;
		}
		else
		{
			flag = true;
			int num = z0dm().z0syk().z0yek();
			using zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = xTextFieldElementBase.z0be().z0ltk();
			while (z0bpk.MoveNext())
			{
				XTextElement current = z0bpk.Current;
				if (current.z0aek() != null)
				{
					int z0jyk = current.z0aek().z0jyk;
					if (z0jyk < 0)
					{
						flag = false;
						break;
					}
					if (z0jyk != num)
					{
						z0dm().z0cek()?.Add(new z0ZzZzhcj(current, z0ZzZziok.z0eyk(), ContentProtectedReason.LogicDeleteAgain));
						flag = false;
						break;
					}
				}
			}
		}
		if (!flag)
		{
			return false;
		}
		if (!z0lm(xTextFieldElementBase))
		{
			if (!p1)
			{
				z0ym(z0dm().z0cek());
			}
			return false;
		}
		if (p1)
		{
			return true;
		}
		XTextInputFieldElement xTextInputFieldElement = xTextFieldElementBase.z0ji() as XTextInputFieldElement;
		XTextDocumentContentElement xTextDocumentContentElement = xTextFieldElementBase.z0qek();
		int num2 = xTextDocumentContentElement.z0frk().IndexOf(xTextFieldElementBase.z0jrk());
		if (num2 < 0)
		{
			xTextDocumentContentElement.z0frk().IndexOf(xTextFieldElementBase);
		}
		if (xTextFieldElementBase.z0le(p0: true))
		{
			if (num2 >= 0)
			{
				bool flag2 = false;
				if (xTextInputFieldElement != null && z0eek(xTextInputFieldElement))
				{
					int num3 = xTextDocumentContentElement.z0frk().z0lrk(((XTextFieldElementBase)xTextInputFieldElement).z0tek());
					if (num3 > 0)
					{
						xTextDocumentContentElement.z0frk().z0tek(num3, p1: false);
						flag2 = true;
					}
				}
				if (!flag2)
				{
					xTextDocumentContentElement.z0frk().z0tek(num2, p1: false);
				}
			}
			return true;
		}
		return false;
	}

	public bool z0nm()
	{
		z0ZzZzkeh z0ZzZzkeh2 = z0wn_jiejie20260327142557(z0ip().CreationDataFormats, p1: true, p2: true, z0dm().z0pu_jiejie20260327142557().CopyWithoutInputFieldStructure, p4: true);
		if (z0ZzZzkeh2 != null)
		{
			z0ip().z0eek(z0ZzZzkeh2);
			return true;
		}
		return false;
	}

	private bool z0eek(XTextFieldElementBase p0)
	{
		XTextDocumentContentElement xTextDocumentContentElement = p0.z0qek();
		if (xTextDocumentContentElement != null && xTextDocumentContentElement.z0frk() != null)
		{
			z0ZzZzplh z0ZzZzplh2 = xTextDocumentContentElement.z0frk();
			int num = z0ZzZzplh2.z0lrk(p0.z0tek());
			int num2 = z0ZzZzplh2.z0lrk(p0.z0jrk());
			if (num == num2 + 1)
			{
				return true;
			}
			if (num2 < num - 1 && z0ZzZzplh2[num2 + 1] is XTextCharElement && ((XTextCharElement)z0ZzZzplh2[num2 + 1]).z0oek())
			{
				return true;
			}
		}
		return false;
	}

	public bool z0mm()
	{
		z0ZzZzkeh z0ZzZzkeh2 = z0wn_jiejie20260327142557(z0ip().CreationDataFormats, z0dm().z0pu_jiejie20260327142557().CopyInTextFormatOnly, z0dm().z0pu_jiejie20260327142557().ClearFieldValueWhenCopy, z0dm().z0pu_jiejie20260327142557().CopyWithoutInputFieldStructure, p4: true);
		if (z0ZzZzkeh2 != null)
		{
			if (z0dm().z0vtk().BehaviorOptions.DataObjectRange == WriterDataObjectRange.OS && z0zek > 51200 && (DateTime.Now - z0ark).TotalMilliseconds < 500.0)
			{
				return false;
			}
			z0ark = DateTime.Now;
			z0ip().z0eek(z0ZzZzkeh2);
			return true;
		}
		return false;
	}

	private void z0eek(ElementStateDetectEventArgs p0)
	{
		XTextElement element = p0.Element;
		XTextElement xTextElement = element.z0ji();
		z0ZzZzbcj flags = p0.Flags;
		while (xTextElement != null)
		{
			if (xTextElement is XTextFieldElementBase)
			{
				XTextFieldElementBase xTextFieldElementBase = (XTextFieldElementBase)xTextElement;
				if (xTextFieldElementBase.z0jrk() == element || xTextFieldElementBase.z0tek() == element)
				{
					if (p0.SetMessage)
					{
						p0.Message = z0ZzZziok.z0huk();
					}
					p0.ProtectedReason = ContentProtectedReason.UnDeleteable;
					z0eek(p0.Element, p0.Message, p0.ProtectedReason);
					p0.Result = false;
					break;
				}
				if (xTextFieldElementBase.z0eek(element))
				{
					if (p0.SetMessage)
					{
						p0.Message = z0ZzZziok.z0xtk();
					}
					p0.ProtectedReason = ContentProtectedReason.UnDeleteable;
					z0eek(p0.Element, p0.Message, p0.ProtectedReason);
					p0.Result = false;
					break;
				}
			}
			if (xTextElement is XTextInputFieldElementBase)
			{
				XTextInputFieldElementBase xTextInputFieldElementBase = (XTextInputFieldElementBase)xTextElement;
				if (z0eek(flags, (z0ZzZzbcj)2) && !xTextInputFieldElementBase.z0krk() && !z0wm())
				{
					if (p0.SetMessage)
					{
						p0.Message = string.Format(z0ZzZziok.z0otk(), xTextInputFieldElementBase.z0vek());
					}
					p0.ProtectedReason = ContentProtectedReason.ContainerReadonly;
					z0eek(p0.Element, p0.Message, p0.ProtectedReason);
					p0.Result = false;
					break;
				}
			}
			z0uek();
			xTextElement = xTextElement.z0ji();
		}
	}

	public virtual bool z0pm(XTextElement p0, z0ZzZzbcj p1)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("element");
		}
		if (z0erk != null)
		{
			z0iok z0iok = new z0iok(p0, p1);
			bool result = false;
			if (z0erk.z0eek.TryGetValue(z0iok, out result))
			{
				return result;
			}
		}
		ElementStateDetectEventArgs e = new ElementStateDetectEventArgs(p0, p1);
		z0im(e);
		if (z0erk != null)
		{
			z0erk.z0eek[new z0iok(p0, p1)] = e.Result;
		}
		return e.Result;
	}

	public int z0om(XTextElementList p0)
	{
		if (p0 != null && p0.Count > 0)
		{
			z0ZzZzafh.z0yek(p0, p1: true, z0dm(), p0[0].z0ji(), p4: false);
			return z0eek(null, p0, p2: true, p3: false);
		}
		return 0;
	}

	private void z0rek(bool p0)
	{
		if (!z0dm().z0bu().AllowDeleteJumpOutOfField || z0dm().z0ryk().z0prk() != 0)
		{
			return;
		}
		bool flag = true;
		bool flag2 = true;
		if (z0ip().z0ook() == FormViewMode.Strict)
		{
			if (z0oek_jiejie20260327142557().z0krk_jiejie20260327142557() is XTextFieldBorderElement && z0oek_jiejie20260327142557().z0krk_jiejie20260327142557().z0ji() is XTextInputFieldElementBase xTextInputFieldElementBase && xTextInputFieldElementBase.z0hrk())
			{
				flag = false;
			}
			if (z0oek_jiejie20260327142557().z0ork() is XTextFieldBorderElement && z0oek_jiejie20260327142557().z0ork().z0ji() is XTextInputFieldElementBase xTextInputFieldElementBase2 && xTextInputFieldElementBase2.z0hrk())
			{
				flag2 = false;
			}
		}
		z0ZzZzzlh z0ZzZzzlh2 = z0dm().z0ryk().z0lrk();
		if (z0ZzZzzlh2 != null && z0ZzZzzlh2.z0gyk() == ContentLayoutDirectionStyle.RightToLeft)
		{
			if (p0)
			{
				if (flag)
				{
					z0dm().z0ryk().z0grk();
				}
			}
			else if (flag2)
			{
				z0dm().z0ryk().z0tek();
			}
		}
		else if (p0)
		{
			if (flag2)
			{
				z0dm().z0ryk().z0tek();
			}
		}
		else if (flag)
		{
			z0dm().z0ryk().z0grk();
		}
	}

	public virtual void z0im(ElementStateDetectEventArgs p0)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("args");
		}
		if (p0.Element == null)
		{
			throw new ArgumentNullException("args.Element");
		}
		if (p0.Flags == (z0ZzZzbcj)0)
		{
			p0.Result = true;
			return;
		}
		p0.Flags = z0eek(p0.Flags);
		if (z0rek())
		{
			p0.Result = true;
			return;
		}
		if (z0eek(p0.Flags, (z0ZzZzbcj)1) && z0kn())
		{
			if (p0.SetMessage)
			{
				p0.Message = z0ZzZziok.z0nok();
			}
			z0eek(p0.Element, p0.Message, ContentProtectedReason.ControlReadonly);
			p0.Result = false;
			return;
		}
		if (z0eek(p0.Flags, (z0ZzZzbcj)16) && (z0bp() == FormViewMode.Normal || z0bp() == FormViewMode.Strict) && !(p0.Element is XTextCheckBoxElement) && !(p0.Element is XTextInputFieldElementBase) && !(p0.Element is XTextRadioBoxElement) && !z0eek(p0.Element))
		{
			if (p0.SetMessage)
			{
				p0.Message = z0ZzZziok.z0tok();
			}
			z0eek(p0.Element, p0.Message, ContentProtectedReason.FormViewMode);
			p0.Result = false;
			return;
		}
		if (z0eek(p0.Flags, (z0ZzZzbcj)32) && !z0wm())
		{
			XTextDocumentContentElement xTextDocumentContentElement = p0.Element.z0qek();
			if (xTextDocumentContentElement != null)
			{
				int num = 0;
				if (p0.Element is XTextParagraphFlagElement)
				{
					num = p0.Element.z0jrk();
				}
				else
				{
					XTextElement xTextElement = p0.Element.z0xt();
					if (xTextElement == null)
					{
						p0.Result = false;
						return;
					}
					num = xTextElement.z0jrk();
				}
				if (xTextDocumentContentElement.z0frk().z0uek() >= 0 && xTextDocumentContentElement.z0frk().z0tek(num))
				{
					if (p0.SetMessage)
					{
						p0.Message = z0ZzZziok.z0euk();
					}
					z0eek(p0.Element, p0.Message, ContentProtectedReason.Lock);
					p0.Result = false;
					return;
				}
			}
		}
		if (z0eek(p0.Flags, (z0ZzZzbcj)8))
		{
			z0ZzZzrzj z0ZzZzrzj2 = p0.Element.z0aek();
			if (!z0wm())
			{
				z0ZzZzivj z0ZzZzivj2 = z0iek().z0oek();
				if (z0ZzZzivj2 != null && !z0ZzZzivj2.z0rek(z0dm(), z0ZzZzrzj2.z0nrk, z0ZzZzrzj2.z0jyk))
				{
					if (p0.SetMessage)
					{
						if (!string.IsNullOrEmpty(z0iek().z0oek().z0eek()))
						{
							p0.Message = z0iek().z0oek().z0eek();
						}
						else
						{
							p0.Message = z0ZzZziok.z0gok();
						}
					}
					if (z0ZzZzrzj2.z0jyk >= 0)
					{
						z0eek(p0.Element, p0.Message, ContentProtectedReason.LogicDeleteAgain);
					}
					else
					{
						z0eek(p0.Element, p0.Message, ContentProtectedReason.Permission);
					}
					p0.Result = false;
					return;
				}
			}
		}
		if (!z0wm() && z0eek(p0.Flags, (z0ZzZzbcj)64))
		{
			ContentProtectType z0otk = p0.Element.z0aek().z0otk;
			if (z0otk == ContentProtectType.Content || z0otk == ContentProtectType.Range)
			{
				if (p0.SetMessage)
				{
					p0.Message = z0bek;
				}
				z0eek(p0.Element, p0.Message, ContentProtectedReason.ContentProtectStyle);
				p0.Result = false;
				return;
			}
		}
		bool flag = false;
		if (!z0wm())
		{
			if (p0.Element is XTextObjectElement)
			{
				if (!((XTextObjectElement)p0.Element).z0yek())
				{
					p0.Result = true;
					return;
				}
				if (z0eek(p0.Flags, (z0ZzZzbcj)4))
				{
					if (p0.SetMessage)
					{
						p0.Message = z0ZzZziok.z0nek();
					}
					z0eek(p0.Element, p0.Message, ContentProtectedReason.ContainerReadonly);
					p0.Result = false;
					return;
				}
			}
			if (p0.Element is XTextShapeInputFieldElement)
			{
				XTextShapeInputFieldElement xTextShapeInputFieldElement = (XTextShapeInputFieldElement)p0.Element;
				if (!xTextShapeInputFieldElement.EditMode)
				{
					if (!xTextShapeInputFieldElement.z0sek())
					{
						p0.Result = true;
						return;
					}
					if (z0eek(p0.Flags, (z0ZzZzbcj)4))
					{
						if (p0.SetMessage)
						{
							p0.Message = z0ZzZziok.z0nek();
						}
						z0eek(p0.Element, p0.Message, ContentProtectedReason.ContainerReadonly);
						p0.Result = false;
						return;
					}
				}
			}
			if (!flag)
			{
				XTextContainerElement xTextContainerElement = null;
				if (p0.ForContent && p0.Element is XTextContainerElement)
				{
					xTextContainerElement = (XTextContainerElement)p0.Element;
				}
				if (xTextContainerElement == null)
				{
					xTextContainerElement = p0.Element.z0ji();
				}
				if (xTextContainerElement != null && xTextContainerElement.z0sek() && z0eek(p0.Flags, (z0ZzZzbcj)4))
				{
					if (p0.SetMessage)
					{
						p0.Message = z0ZzZziok.z0nek();
					}
					z0eek(p0.Element, p0.Message, ContentProtectedReason.ContainerReadonly);
					p0.Result = false;
					return;
				}
				if ((xTextContainerElement == null || xTextContainerElement.ContentReadonly != ContentReadonlyState.False) && p0.Element.z0ji() != null && p0.Element.z0ji().z0sek() && z0eek(p0.Flags, (z0ZzZzbcj)128))
				{
					if (p0.SetMessage)
					{
						p0.Message = z0ZzZziok.z0nek();
					}
					z0eek(p0.Element, p0.Message, ContentProtectedReason.ContainerReadonly);
					p0.Result = false;
					return;
				}
			}
		}
		XTextElement xTextElement2 = p0.Element;
		bool flag2 = false;
		while (xTextElement2 != null && !(xTextElement2 is XTextDocument))
		{
			if (xTextElement2 is XTextContainerElement && z0eek(p0.Flags, (z0ZzZzbcj)4) && !flag2)
			{
				flag2 = true;
				if (!((XTextContainerElement)xTextElement2).z0qo() && !z0wm())
				{
					if (p0.SetMessage)
					{
						p0.Message = z0ZzZziok.z0nek();
					}
					p0.Result = false;
					z0eek(p0.Element, p0.Message, ContentProtectedReason.ContainerReadonly);
					return;
				}
			}
			if (xTextElement2 is XTextInputFieldElementBase && xTextElement2 != p0.Element)
			{
				XTextInputFieldElementBase xTextInputFieldElementBase = (XTextInputFieldElementBase)xTextElement2;
				if (((XTextFieldElementBase)xTextInputFieldElementBase).z0jrk() != p0.Element && ((XTextFieldElementBase)xTextInputFieldElementBase).z0tek() != p0.Element && z0eek(p0.Flags, (z0ZzZzbcj)2) && !xTextInputFieldElementBase.z0krk() && !z0wm())
				{
					if (p0.SetMessage)
					{
						p0.Message = string.Format(z0ZzZziok.z0otk(), xTextInputFieldElementBase.z0vek());
					}
					z0eek(p0.Element, p0.Message, ContentProtectedReason.ContainerReadonly);
					p0.Result = false;
					return;
				}
			}
			xTextElement2 = xTextElement2.z0ji();
		}
		p0.Result = true;
	}

	public void z0um(bool p0)
	{
		z0frk = p0;
	}

	public void z0ym(z0ZzZzgcj p0)
	{
		if (z0wrk != null)
		{
			p0?.Add(z0wrk);
			z0wrk = null;
		}
	}

	private int z0eek(XTextElement p0, XTextElementList p1, bool p2, bool p3)
	{
		if (p1 == null || p1.Count == 0)
		{
			return 0;
		}
		z0em(p1);
		if (!p3 && p2)
		{
			z0dm().z0ytk();
		}
		z0ZzZzzxj z0ZzZzzxj2 = new z0ZzZzzxj();
		z0ZzZzzxj2.z0eek(p0);
		z0ZzZzzxj2.z0eek(p1);
		z0ZzZzzxj2.z0yek(p0: true);
		z0ZzZzzxj2.z0eek(p3);
		if (!p3)
		{
			if (WriterControlForWASM.z0zyk.Length > 0 && WriterControlForWASM.z0zyk.Contains(":"))
			{
				string[] array = WriterControlForWASM.z0zyk.Split(';');
				z0ZzZzjjh z0ZzZzjjh2 = new z0ZzZzjjh(z0dm(), new z0ZzZzkbk(), null);
				using zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = p1.z0pek(typeof(XTextCharElement)).z0ltk();
				while (z0bpk.MoveNext())
				{
					XTextCharElement xTextCharElement = (XTextCharElement)z0bpk.Current;
					string[] array2 = array;
					for (int i = 0; i < array2.Length; i++)
					{
						string[] array3 = array2[i].Split(":");
						if (array3.Length == 2)
						{
							string p4 = array3[0].ToLower();
							string p5 = array3[1];
							z0ZzZzjjh2.z0tek(null, xTextCharElement.z0xrk(), p4, p5, xTextCharElement);
						}
					}
				}
			}
			if (z0dm().z0vtk().BehaviorOptions.AutoFixElementIDWhenInsertElements)
			{
				z0dm().z0vtk().BehaviorOptions.AutoFixElementIDWhenInsertElements = false;
				XTextElementList p6 = p1.z0pek(typeof(XTextObjectElement));
				XTextElementList p7 = p1.z0pek(typeof(XTextContainerElement));
				XTextElementList xTextElementList = new XTextElementList();
				xTextElementList.z0tek(p6);
				xTextElementList.z0tek(p7);
				using (zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = xTextElementList.z0ltk())
				{
					while (z0bpk.MoveNext())
					{
						XTextElement current = z0bpk.Current;
						if (!(current is XTextCharElement) && current.ID != null && current.ID.Length != 0)
						{
							z0ZzZzcoj.z0tek(current, z0dm());
						}
					}
				}
				z0dm().z0vtk().BehaviorOptions.AutoFixElementIDWhenInsertElements = true;
				if (z0ZzZzcoj.z0vek != null)
				{
					z0ZzZzcoj.z0vek.Clear();
					z0ZzZzcoj.z0vek = null;
				}
			}
		}
		int result = z0dm().z0bek(z0ZzZzzxj2);
		if (!p3)
		{
			z0dm().Modified = true;
			if (p2)
			{
				z0dm().z0nuk();
			}
		}
		return result;
	}

	public virtual bool z0tm(bool p0)
	{
		if (z0rek())
		{
			return true;
		}
		if (z0kn())
		{
			return false;
		}
		z0ZzZzbcj z0ZzZzbcj2 = (z0ZzZzbcj)255;
		if (!p0)
		{
			z0ZzZzbcj2 = (z0ZzZzbcj)z0ZzZzmpk.z0eek((int)z0ZzZzbcj2, 64, p2: false);
		}
		if (z0yek().z0qrk() == 0)
		{
			if (p0 && !z0wm())
			{
				XTextElement xTextElement = z0dm().z0itk();
				if (xTextElement == null)
				{
					return false;
				}
				XTextElement xTextElement2 = ((XTextElementList)z0dm().z0ryk()).z0pek(xTextElement);
				if (xTextElement2 != null && xTextElement2.z0jy() == xTextElement.z0jy())
				{
					if (xTextElement2.z0aek().z0otk == ContentProtectType.Range && xTextElement.z0aek().z0otk == ContentProtectType.Range)
					{
						return false;
					}
				}
				else if (xTextElement.z0aek().z0otk == ContentProtectType.Range)
				{
					return false;
				}
			}
			XTextContainerElement p1 = null;
			int p2 = 0;
			z0dm().z0ryk().z0tek(out p1, out p2);
			if (p1 != null && !z0wm() && p1.z0sek())
			{
				return false;
			}
			if (p1 is XTextInputFieldElementBase)
			{
				return ((XTextInputFieldElementBase)p1).z0krk();
			}
			z0ZzZzbcj2 &= (z0ZzZzbcj)(-129);
			return z0am(p1, z0ZzZzbcj2);
		}
		using (zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = z0yek().z0grk().z0ltk())
		{
			while (z0bpk.MoveNext())
			{
				XTextElement current = z0bpk.Current;
				if (z0pm(current, z0ZzZzbcj2))
				{
					return true;
				}
			}
		}
		return false;
	}

	public virtual void z0rm(ElementStateDetectEventArgs p0)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("args");
		}
		if (p0.ResetLastContentProtectedInfo)
		{
			z0wrk = null;
		}
		XTextElement xTextElement = p0.Element;
		if (xTextElement == null)
		{
			throw new ArgumentNullException("element");
		}
		if (xTextElement is XTextTableCellElement)
		{
			XTextTableCellElement xTextTableCellElement = (XTextTableCellElement)xTextElement;
			if (xTextTableCellElement.z0hrk() != null)
			{
				xTextElement = xTextTableCellElement.z0hrk();
			}
		}
		z0ZzZzrzj z0ZzZzrzj2 = xTextElement.z0aek();
		p0.Flags = z0eek(p0.Flags);
		if (p0.Flags == (z0ZzZzbcj)0)
		{
			p0.Result = true;
			return;
		}
		if (z0rek())
		{
			p0.Result = true;
			return;
		}
		z0ZzZzbcj flags = p0.Flags;
		if ((z0ZzZzrzj2.z0otk == ContentProtectType.Range || z0ZzZzrzj2.z0otk == ContentProtectType.Content) && z0eek(flags, (z0ZzZzbcj)64) && !z0wm())
		{
			if (p0.SetMessage)
			{
				p0.Message = z0bek;
			}
			p0.ProtectedReason = ContentProtectedReason.ContentProtectStyle;
			z0eek(p0.Element, p0.Message, p0.ProtectedReason);
			p0.Result = false;
			return;
		}
		if (z0eek(flags, (z0ZzZzbcj)1) && z0kn())
		{
			if (p0.SetMessage)
			{
				p0.Message = z0ZzZziok.z0nok();
			}
			p0.ProtectedReason = ContentProtectedReason.ControlReadonly;
			z0eek(p0.Element, p0.Message, p0.ProtectedReason);
			p0.Result = false;
			return;
		}
		if (z0eek(flags, (z0ZzZzbcj)32) && !z0wm())
		{
			XTextDocumentContentElement xTextDocumentContentElement = xTextElement.z0qek();
			if (xTextDocumentContentElement == null || xTextElement.z0hy() == null)
			{
				p0.Result = false;
				return;
			}
			if (xTextDocumentContentElement.z0frk().z0uek() >= 0 && xTextDocumentContentElement.z0frk().z0tek(xTextElement.z0hy().z0jrk()))
			{
				if (p0.SetMessage)
				{
					p0.Message = z0ZzZziok.z0euk();
				}
				p0.ProtectedReason = ContentProtectedReason.Lock;
				z0eek(p0.Element, p0.Message, p0.ProtectedReason);
				p0.Result = false;
				return;
			}
		}
		if ((z0bp() == FormViewMode.Normal || z0bp() == FormViewMode.Strict) && (flags & (z0ZzZzbcj)2) == (z0ZzZzbcj)2 && !z0eek(xTextElement))
		{
			if (p0.SetMessage)
			{
				p0.Message = z0ZzZziok.z0tok();
			}
			p0.ProtectedReason = ContentProtectedReason.FormViewMode;
			z0eek(p0.Element, p0.Message, p0.ProtectedReason);
			p0.Result = false;
			return;
		}
		if (!z0wm() && z0eek(p0.Flags, (z0ZzZzbcj)8) && z0iek().z0oek() != null && !z0iek().z0oek().z0eek(z0dm(), z0ZzZzrzj2.z0nrk, z0ZzZzrzj2.z0jyk))
		{
			if (p0.SetMessage)
			{
				if (!string.IsNullOrEmpty(z0iek().z0oek().z0eek()))
				{
					p0.Message = z0iek().z0oek().z0eek();
				}
				else
				{
					p0.Message = z0ZzZziok.z0gok();
				}
			}
			if (z0ZzZzrzj2.z0jyk >= 0)
			{
				p0.ProtectedReason = ContentProtectedReason.LogicDeleteAgain;
			}
			else
			{
				p0.ProtectedReason = ContentProtectedReason.Permission;
			}
			z0eek(p0.Element, p0.Message, p0.ProtectedReason);
			p0.Result = false;
			return;
		}
		if (xTextElement is z0ZzZzixj && !z0wm() && !((z0ZzZzixj)xTextElement).Deleteable && z0ZzZzxcj.z0eek(177))
		{
			if (p0.SetMessage)
			{
				string text = xTextElement.ID;
				if (xTextElement is XTextCheckBoxElementBase)
				{
					text = ((XTextCheckBoxElementBase)xTextElement).z0grk();
				}
				else if (xTextElement is XTextInputFieldElementBase)
				{
					text = ((XTextInputFieldElementBase)xTextElement).z0vek();
				}
				p0.Message = string.Format(z0ZzZziok.z0qok(), text);
			}
			p0.ProtectedReason = ContentProtectedReason.UnDeleteable;
			z0eek(p0.Element, p0.Message, p0.ProtectedReason);
			p0.Result = false;
			return;
		}
		if (xTextElement is XTextParagraphFlagElement && xTextElement.z0jy().z0trk().LastElement == xTextElement)
		{
			if (p0.SetMessage)
			{
				p0.Message = z0ZzZziok.z0jik();
			}
			p0.ProtectedReason = ContentProtectedReason.UnDeleteable;
			z0eek(p0.Element, p0.Message, p0.ProtectedReason);
			p0.Result = false;
			return;
		}
		if (z0uek() && !(xTextElement is XTextCharElement))
		{
			_ = xTextElement is XTextParagraphFlagElement;
		}
		XTextContainerElement xTextContainerElement = xTextElement.z0ji();
		if (!z0wm() && z0eek(flags, (z0ZzZzbcj)4) && xTextContainerElement != null && xTextContainerElement.z0sek())
		{
			if (p0.SetMessage)
			{
				p0.Message = z0ZzZziok.z0nek();
			}
			p0.ProtectedReason = ContentProtectedReason.ContainerReadonly;
			z0eek(p0.Element, p0.Message, p0.ProtectedReason);
			p0.Result = false;
			return;
		}
		if (p0.z0eek() && p0.z0tek() != null)
		{
			p0.Result = p0.z0tek().Result;
			p0.Element = p0.z0tek().Element;
			p0.Message = p0.z0tek().Message;
			p0.ProtectedReason = p0.z0tek().ProtectedReason;
		}
		else
		{
			z0eek(p0);
		}
		if (p0.z0eek() && p0.z0tek() == null)
		{
			p0.z0eek(p0.z0rek());
		}
		if (p0.Result)
		{
			p0.Result = true;
		}
	}

	public virtual void z0em(XTextElementList p0)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("list");
		}
		if (p0.Count == 0)
		{
			return;
		}
		using z0ZzZzjpk p1 = z0dm().z0ru();
		using zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = p0.z0ltk();
		while (z0bpk.MoveNext())
		{
			XTextElement current = z0bpk.Current;
			current.z0bt(z0dm());
			current.z0li();
			z0ZzZzvxj z0ZzZzvxj2 = z0dm().z0bek(p1, (z0ZzZzcxj)0);
			z0ZzZzvxj2.z0hyk = current;
			current.z0mr(z0ZzZzvxj2);
			if (current is XTextImageElement)
			{
				XTextImageElement xTextImageElement = (XTextImageElement)current;
				z0ZzZzafh.z0yek(z0dm(), xTextImageElement, xTextImageElement.z0oek(), null);
			}
			else if (current is XTextTableElement)
			{
				z0ZzZzafh.z0yek(z0dm(), (XTextTableElement)current);
			}
		}
	}

	public bool z0wm()
	{
		return z0cek;
	}

	private z0ZzZzhkh z0yek()
	{
		return z0dm().z0cuk();
	}

	public bool z0uek()
	{
		return false;
	}

	public virtual bool z0qm(XTextElement p0, XTextElement p1, z0ZzZzbcj p2)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("parentElement");
		}
		if (p1 == null)
		{
			throw new ArgumentNullException("element");
		}
		return z0xp(p0, p1.GetType(), p2);
	}

	public virtual bool z0am(XTextElement p0, z0ZzZzbcj p1)
	{
		if (z0erk != null)
		{
			z0iok z0iok = new z0iok(p0, p1, p2: true);
			bool result = false;
			if (z0erk.z0eek.TryGetValue(z0iok, out result))
			{
				return result;
			}
		}
		ElementStateDetectEventArgs e = new ElementStateDetectEventArgs(p0, p1);
		e.ForContent = true;
		z0im(e);
		if (z0erk != null)
		{
			z0erk.z0eek[new z0iok(p0, p1, p2: true)] = e.Result;
		}
		return e.Result;
	}

	public XTextElementList z0sm(string p0)
	{
		return z0rek(p0, p1: true, InputValueSource.Unknow, null);
	}

	public XTextDocument z0dm()
	{
		return z0nek;
	}

	public virtual bool z0fm(bool p0)
	{
		if (z0kn())
		{
			return false;
		}
		z0ip().z0zyk();
		z0dm().z0ntk();
		int num = -1;
		z0dm().z0ytk();
		if (!z0eek().z0urk())
		{
			XTextElement xTextElement = z0dm().z0itk();
			XTextElement p1 = ((XTextElementList)z0dm().z0ryk()).z0pek(xTextElement);
			p1 = XTextCheckBoxElementBase.z0eek(p1);
			p1 = z0dm().z0ryk().z0nek(xTextElement);
			p1 = XTextCheckBoxElementBase.z0eek(p1);
			if (xTextElement == z0dm().z0ryk().LastElement && p1 == null)
			{
				if (xTextElement is XTextParagraphFlagElement && z0jn(p0: false))
				{
					z0dm().z0nuk();
					return true;
				}
				z0dm().z0nuk();
				return false;
			}
			if (p1 != null)
			{
				if (p1 is XTextFieldBorderElement)
				{
					XTextFieldElementBase xTextFieldElementBase = (XTextFieldElementBase)p1.z0ji();
					if (xTextFieldElementBase.z0jrk() == p1)
					{
						if (!z0eek(xTextFieldElementBase))
						{
							if (z0ip().z0ook() == FormViewMode.Strict && xTextFieldElementBase.z0yek(typeof(XTextInputFieldElementBase), p1: false) == null)
							{
								z0dm().z0ntk();
								return false;
							}
							z0rek(p0: false);
							z0dm().z0ntk();
							return false;
						}
						bool num2 = z0eek(p1, p1: false);
						if (!num2)
						{
							z0rek(p0: false);
						}
						z0dm().z0ntk();
						return num2;
					}
				}
				int num3 = 0;
				while (p1 is XTextFieldBorderElement && num3++ <= 4)
				{
					XTextFieldElementBase xTextFieldElementBase2 = (XTextFieldElementBase)p1.z0ji();
					if (xTextFieldElementBase2 == null)
					{
						break;
					}
					bool flag = z0eek(xTextFieldElementBase2);
					if (xTextFieldElementBase2.z0tek() == p1 && !flag && !z0dm().z0ryk().Contains(xTextFieldElementBase2))
					{
						z0ZzZzqbj z0ZzZzqbj2 = z0drk?.z0ypk();
						bool p2 = z0ZzZzqbj2?.z0hrk() ?? true;
						try
						{
							z0ZzZzqbj2?.z0jrk(p0: false);
							if (z0dm().z0ryk().z0tek(z0dm().z0ryk().IndexOf(p1), p1: false))
							{
								xTextElement = z0dm().z0itk();
								p1 = ((XTextElementList)z0dm().z0ryk()).z0pek(xTextElement);
								continue;
							}
						}
						finally
						{
							z0ZzZzqbj2?.z0jrk(p2);
						}
						break;
					}
					if (xTextFieldElementBase2.z0jrk() != p1 || flag || z0dm().z0ryk().Contains(xTextFieldElementBase2) || !z0dm().z0ryk().z0tek(z0dm().z0ryk().IndexOf(p1), p1: false))
					{
						break;
					}
					xTextElement = z0dm().z0itk();
					p1 = ((XTextElementList)z0dm().z0ryk()).z0pek(xTextElement);
				}
			}
			if (p1 != null)
			{
				z0wrk = null;
				if (z0eek(p1, p1: false))
				{
					z0dm().z0ntk();
					return true;
				}
				if (z0dm().z0jyk())
				{
					if (p0)
					{
						z0dm().z0vek((z0ZzZzgcj)null);
					}
					z0dm().z0bek((z0ZzZzgcj)null);
					z0rek(p0: false);
					return false;
				}
			}
			if (z0jn(p0: false))
			{
				return true;
			}
		}
		z0dm().z0bek((z0ZzZzgcj)null);
		z0ZzZzqbj z0ZzZzqbj3 = z0ip().z0ypk();
		if (z0eek().z0urk())
		{
			z0oek_jiejie20260327142557().z0zek().z0yek();
			_ = 1;
			int p3 = z0oek_jiejie20260327142557().z0zek().z0lrk();
			try
			{
				z0ZzZzqbj3.z0aok = true;
				num = z0oek_jiejie20260327142557().z0tek(p0: true, p1: false, p2: false);
			}
			finally
			{
				z0ZzZzqbj3.z0aok = false;
			}
			if (num > 0)
			{
				z0oek_jiejie20260327142557().z0tek(p3, 0);
				z0ZzZzqbj3.z0duk();
			}
			else
			{
				z0ZzZzqbj3.z0qrk();
			}
		}
		else
		{
			try
			{
				z0ZzZzqbj3.z0aok = true;
				num = z0oek_jiejie20260327142557().z0oek(p0: true);
				if (num < 0)
				{
					z0rek(p0: false);
				}
			}
			finally
			{
				z0ZzZzqbj3.z0aok = false;
			}
			if (num > 0)
			{
				z0ZzZzqbj3.z0duk();
			}
			else
			{
				z0ZzZzqbj3.z0qrk();
			}
		}
		bool result = false;
		if (num >= 0)
		{
			z0dm().z0nuk();
			z0dm().z0emk();
			z0dm().OnDocumentContentChanged();
			result = true;
		}
		else
		{
			z0dm().z0nuk();
		}
		if (z0dm().z0jyk() && p0)
		{
			z0dm().z0vek((z0ZzZzgcj)null);
		}
		z0dm().z0bek((z0ZzZzgcj)null);
		return result;
	}

	public virtual bool z0gm(Type p0, z0ZzZzbcj p1)
	{
		if ((p1 & (z0ZzZzbcj)1) == (z0ZzZzbcj)1 && z0kn())
		{
			return false;
		}
		XTextContainerElement p2 = null;
		int p3 = 0;
		z0dm().z0ryk().z0tek(z0dm().z0cuk().z0nek(), out p2, out p3, z0dm().z0ryk().z0frk());
		if (p2 == null)
		{
			return false;
		}
		return z0eek(p2, p3, p0, p1);
	}

	public virtual void z0rek(CanInsertElementEventArgs p0)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("args");
		}
		if (p0.Container == null)
		{
			throw new ArgumentNullException("args.Container");
		}
		if (p0.ElementType == null)
		{
			throw new ArgumentNullException("args.ElementType");
		}
		if (z0rek())
		{
			p0.Result = z0xp(p0.Container, p0.ElementType, p0.Flags);
			return;
		}
		if (!z0eek(p0.Container, p0.Index))
		{
			if (p0.SetMessage)
			{
				p0.Message = z0bek;
			}
			z0eek(p0.Element, p0.Message, ContentProtectedReason.ContentProtectStyle);
			p0.Result = false;
			return;
		}
		p0.Flags = z0eek(p0.Flags);
		if (z0eek(p0.Flags, (z0ZzZzbcj)1) && z0kn())
		{
			if (p0.SetMessage)
			{
				p0.Message = z0ZzZziok.z0nok();
			}
			z0eek(p0.Element, p0.Message, ContentProtectedReason.ControlReadonly);
			p0.Result = false;
			return;
		}
		if (z0eek(p0.Flags, (z0ZzZzbcj)16) && (z0bp() == FormViewMode.Normal || z0bp() == FormViewMode.Strict) && !z0eek(p0.Container) && !(p0.Container is XTextInputFieldElementBase))
		{
			if (p0.SetMessage)
			{
				p0.Message = z0ZzZziok.z0tok();
			}
			z0eek(p0.Element, p0.Message, ContentProtectedReason.FormViewMode);
			p0.Result = false;
			return;
		}
		if (p0.Container.z0wtk())
		{
			if (p0.SetMessage)
			{
				p0.Message = z0ZzZziok.z0eyk();
			}
			z0eek(p0.Element, p0.Message, ContentProtectedReason.LogicDeleteAgain);
			p0.Result = false;
			return;
		}
		if (z0eek(p0.Flags, (z0ZzZzbcj)32))
		{
			XTextDocumentContentElement xTextDocumentContentElement = p0.Container.z0qek();
			if (xTextDocumentContentElement.z0frk().z0uek() >= 0)
			{
				int p1 = xTextDocumentContentElement.z0frk().z0tek(p0.Container, p0.Index, p2: false);
				if (xTextDocumentContentElement.z0frk().z0tek(p1))
				{
					if (p0.SetMessage)
					{
						p0.Message = z0ZzZziok.z0euk();
					}
					z0eek(p0.Element, p0.Message, ContentProtectedReason.Lock);
					p0.Result = false;
					return;
				}
			}
		}
		if (!z0wm() && z0eek(p0.Flags, (z0ZzZzbcj)4) && p0.Container.z0sek())
		{
			if (p0.SetMessage)
			{
				p0.Message = z0ZzZziok.z0nek();
			}
			z0eek(p0.Element, p0.Message, ContentProtectedReason.ContainerReadonly);
			p0.Result = false;
			return;
		}
		XTextContainerElement xTextContainerElement = p0.Container;
		if (!z0xp(p0.Container, p0.ElementType, p0.Flags))
		{
			if (p0.SetMessage)
			{
				p0.Message = string.Format(z0ZzZziok.z0irk(), p0.Container.z0hyk(), z0ZzZzafh.z0uek(p0.ElementType));
			}
			z0eek(p0.Element, p0.Message, ContentProtectedReason.ContainerReadonly);
			p0.Result = false;
			return;
		}
		if (xTextContainerElement.z0sek() && !z0wm())
		{
			if (p0.SetMessage)
			{
				p0.Message = z0ZzZziok.z0nek();
			}
			z0eek(p0.Element, p0.Message, ContentProtectedReason.ContainerReadonly);
			p0.Result = false;
			return;
		}
		while (xTextContainerElement != null)
		{
			if (xTextContainerElement is XTextInputFieldElementBase)
			{
				XTextInputFieldElementBase xTextInputFieldElementBase = (XTextInputFieldElementBase)xTextContainerElement;
				if (z0eek(p0.Flags, (z0ZzZzbcj)2) && !xTextInputFieldElementBase.z0krk() && !z0wm())
				{
					if (p0.SetMessage)
					{
						p0.Message = string.Format(z0ZzZziok.z0otk(), xTextInputFieldElementBase.z0vek());
					}
					z0eek(p0.Element, p0.Message, ContentProtectedReason.ContainerReadonly);
					p0.Result = false;
					return;
				}
			}
			z0uek();
			xTextContainerElement = xTextContainerElement.z0ji();
		}
		p0.Result = true;
	}

	public bool z0hm()
	{
		bool result = z0frk;
		z0frk = false;
		return result;
	}

	public z0ZzZzlfh z0iek()
	{
		if (z0jrk != null)
		{
			return z0jrk;
		}
		if (z0ip() != null)
		{
			return z0ip().z0pek();
		}
		return z0ZzZzlfh.z0iek();
	}

	public void z0jm()
	{
		z0wrk = null;
		z0hrk = null;
	}

	private z0ZzZzplh z0oek_jiejie20260327142557()
	{
		return z0dm().z0ryk();
	}

	public virtual XTextSignElement z0km()
	{
		z0dm().z0ytk();
		XTextSignElement xTextSignElement = new XTextSignElement();
		xTextSignElement.z0bt(z0dm());
		using (z0ZzZzjpk p = z0dm().z0ru())
		{
			z0ZzZzvxj z0ZzZzvxj2 = z0dm().z0bek(p, (z0ZzZzcxj)0);
			z0ZzZzvxj2.z0hyk = xTextSignElement;
			xTextSignElement.z0mr(z0ZzZzvxj2);
		}
		z0dm().z0xyk().z0uek(z0dm().z0xyk().z0frk().Count - 1, 0);
		z0dm().z0frk(xTextSignElement);
		z0dm().z0nuk();
		z0dm().OnDocumentContentChanged();
		return xTextSignElement;
	}

	public virtual bool z0eek(XTextContainerElement p0, int p1, Type p2, z0ZzZzbcj p3)
	{
		CanInsertElementEventArgs e = new CanInsertElementEventArgs(p0, p1, p2, p3);
		z0rek(e);
		return e.Result;
	}

	public bool z0lm(XTextElement p0)
	{
		return z0cm(p0, (z0ZzZzbcj)255);
	}

	private string z0eek(string p0, string p1)
	{
		if (string.IsNullOrEmpty(p0) || string.IsNullOrEmpty(p1))
		{
			return p0;
		}
		StringBuilder stringBuilder = new StringBuilder();
		foreach (char c in p0)
		{
			if (p1.Contains(c))
			{
				stringBuilder.Append(c);
			}
		}
		return stringBuilder.ToString();
	}

	public void z0zp()
	{
		z0wrk = null;
		z0hrk = null;
	}

	public virtual bool z0xp(XTextElement p0, Type p1, z0ZzZzbcj p2)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("parentElement");
		}
		if (p1 == null)
		{
			throw new ArgumentNullException("elementType");
		}
		if (p0 is XTextContainerElement)
		{
			ElementType elementType = ((XTextContainerElement)p0).z0at();
			if (elementType != ElementType.All)
			{
				ElementType elementType2 = z0ZzZzafh.z0yek(p1);
				if (elementType2 == ElementType.None && elementType == ElementType.None)
				{
					return false;
				}
				if (elementType2 != ElementType.None && (elementType & elementType2) != elementType2)
				{
					return false;
				}
			}
		}
		if (typeof(XTextTableRowElement).IsAssignableFrom(p1))
		{
			return p0 is XTextTableElement;
		}
		if (typeof(XTextSectionElement).IsAssignableFrom(p1))
		{
			return p0 is XTextDocumentBodyElement;
		}
		if (typeof(XTextTableCellElement).IsAssignableFrom(p1))
		{
			return p0 is XTextTableRowElement;
		}
		if (p0 is XTextTableElement)
		{
			if (!p1.Equals(typeof(XTextTableRowElement)) && !p1.IsSubclassOf(typeof(XTextTableRowElement)) && !p1.Equals(typeof(XTextTableColumnElement)))
			{
				return p1.IsSubclassOf(typeof(XTextTableColumnElement));
			}
			return true;
		}
		if (p0 is XTextTableRowElement)
		{
			if (!p1.Equals(typeof(XTextTableCellElement)))
			{
				return p1.IsSubclassOf(typeof(XTextTableCellElement));
			}
			return true;
		}
		if (p0 is XTextInputFieldElementBase)
		{
			XTextInputFieldElementBase xTextInputFieldElementBase = (XTextInputFieldElementBase)p0;
			if (!z0wm() && xTextInputFieldElementBase.z0sek() && z0eek(p2, (z0ZzZzbcj)4))
			{
				return false;
			}
		}
		else if (typeof(XTextDocumentContentElement).IsAssignableFrom(p1))
		{
			return p0 is XTextDocument;
		}
		return true;
	}

	public virtual bool z0cp(XTextContainerElement p0)
	{
		return false;
	}

	public virtual bool z0vp()
	{
		if (z0kn())
		{
			return false;
		}
		if (z0yek().z0qrk() == 0)
		{
			return true;
		}
		return z0oek_jiejie20260327142557().z0tek(p0: false, p1: true, p2: false) != 0;
	}

	public virtual XTextElementList z0eek(string p0, bool p1, InputValueSource p2, InsertObjectEventArgs p3)
	{
		if (z0ip() != null)
		{
			FilterValueEventArgs e = new FilterValueEventArgs(p2, InputValueType.Html, p0);
			z0ip().z0eek(e);
			if (e.Cancel)
			{
				return null;
			}
			p0 = e.Value as string;
			if (string.IsNullOrEmpty(p0))
			{
				return null;
			}
		}
		if (string.IsNullOrEmpty(p0))
		{
			throw new ArgumentNullException("htmlText");
		}
		z0ZzZzgjh obj = new z0ZzZzgjh();
		z0ZzZzohh p4 = new z0ZzZzohh
		{
			EnableDocumentSetting = false,
			ImportTemplateGenerateParagraph = false,
			FastMode = true
		};
		XTextDocument xTextDocument = new XTextDocument();
		obj.z0xd(new StringReader(p0), xTextDocument, p4);
		XTextElementList xTextElementList = xTextDocument.z0xyk().z0be().z0pek();
		XTextContainerElement xTextContainerElement = (XTextContainerElement)z0dm().z0bek(typeof(XTextContainerElement));
		z0dm().z0bek(xTextElementList, xTextContainerElement.z0brk(), xTextContainerElement.z0brk());
		if (xTextElementList != null && xTextElementList.Count > 0)
		{
			for (int num = xTextElementList.Count - 1; num >= 0; num--)
			{
				if (xTextElementList[num] is XTextDocumentFooterElement || xTextElementList[num] is XTextDocumentHeaderElement)
				{
					xTextElementList.RemoveAt(num);
				}
			}
			if (xTextElementList.Count > 0 && z0ip() != null)
			{
				FilterValueEventArgs e2 = new FilterValueEventArgs(p2, InputValueType.Dom, xTextElementList);
				z0ip().z0eek(e2);
				if (e2.Cancel)
				{
					return null;
				}
				xTextElementList = e2.Value as XTextElementList;
				if (xTextElementList == null || xTextElementList.Count == 0)
				{
					return null;
				}
			}
			if (p3 != null && p3.CheckMaxTextLengthForCopyPaste && !z0dm().z0bek(xTextElementList, p3.ShowUI))
			{
				return null;
			}
			z0dm().z0xek(xTextElementList);
			if (p1)
			{
				z0dm().z0ytk();
			}
			if (z0eek().z0urk())
			{
				z0oek_jiejie20260327142557().z0tek(p0: true, p1: false, p2: false);
			}
			z0eek(xTextElementList, p1: false);
			if (p1)
			{
				z0dm().z0nuk();
			}
			z0dm().OnDocumentContentChanged();
			return xTextElementList;
		}
		return null;
	}

	public FormViewMode z0bp()
	{
		if (z0drk != null)
		{
			return z0drk.z0ook();
		}
		return z0mek;
	}

	public virtual bool z0np(XTextElement p0)
	{
		return z0pm(p0, (z0ZzZzbcj)255);
	}

	public void z0mp()
	{
		if (z0rrk == 0)
		{
			z0erk = new z0jxk();
			z0vek = z0ip() != null && z0ip().z0ork();
			z0krk = z0dm().z0bu().EnabledElementEvent;
			z0srk = z0dm().z0bu();
			z0dm().z0bik();
		}
		z0rrk++;
	}

	public void z0pp(bool p0)
	{
		z0cek = p0;
	}

	public virtual XTextLineBreakElement z0op()
	{
		z0dm().z0ytk();
		XTextLineBreakElement xTextLineBreakElement = new XTextLineBreakElement();
		xTextLineBreakElement.z0bt(z0dm());
		DocumentContentStyle documentContentStyle = z0dm().z0onk()?.z0iek();
		if (documentContentStyle != null)
		{
			xTextLineBreakElement.z0xrk().FontName = documentContentStyle.FontName;
			xTextLineBreakElement.z0xrk().FontSize = documentContentStyle.FontSize;
			xTextLineBreakElement.z0xrk().FontStyle = documentContentStyle.FontStyle;
			xTextLineBreakElement.z0xrk().Color = documentContentStyle.Color;
			xTextLineBreakElement.z0ftk();
		}
		using (z0ZzZzjpk p = z0dm().z0ru())
		{
			z0ZzZzvxj z0ZzZzvxj2 = z0dm().z0bek(p, (z0ZzZzcxj)0);
			z0ZzZzvxj2.z0hyk = xTextLineBreakElement;
			xTextLineBreakElement.z0mr(z0ZzZzvxj2);
		}
		z0dm().z0frk(xTextLineBreakElement);
		z0dm().z0nuk();
		z0dm().OnDocumentContentChanged();
		return xTextLineBreakElement;
	}

	private DocumentBehaviorOptions z0pek()
	{
		if (z0rrk > 0)
		{
			return z0srk;
		}
		return z0dm().z0vtk().BehaviorOptions;
	}

	private int z0eek(XTextElementList p0, bool p1)
	{
		return z0eek(null, p0, p1, p3: false);
	}

	private bool z0eek(XTextContainerElement p0, int p1)
	{
		if (z0wm())
		{
			return true;
		}
		if (p0 is XTextTableElement || p0 is XTextTableRowElement)
		{
			return true;
		}
		XTextElement xTextElement = p0.z0be().SafeGet(p1);
		if (xTextElement != null)
		{
			if (!(xTextElement is XTextParagraphFlagElement))
			{
				xTextElement = xTextElement.z0ie();
			}
			XTextElement xTextElement2 = ((XTextElementList)p0.z0qek().z0frk()).z0pek(xTextElement);
			if (xTextElement2 != null && xTextElement2.z0jy() == xTextElement.z0jy())
			{
				if (xTextElement2.z0aek().z0otk == ContentProtectType.Range && xTextElement.z0aek().z0otk == ContentProtectType.Range)
				{
					return false;
				}
			}
			else if (xTextElement.z0aek().z0otk == ContentProtectType.Range)
			{
				return false;
			}
		}
		else if (p0.z0aek().z0otk == ContentProtectType.Range)
		{
			return false;
		}
		return true;
	}

	private z0ZzZzbcj z0eek(z0ZzZzbcj p0)
	{
		if (z0lrk == null || z0qrk != z0ZzZzxcj.z0eek())
		{
			z0lrk = new int[300];
			for (int i = 0; i < z0lrk.Length; i++)
			{
				z0lrk[i] = -1;
			}
			z0qrk = z0ZzZzxcj.z0eek();
		}
		int num = z0lrk[(int)p0];
		if (num >= 0)
		{
			return (z0ZzZzbcj)num;
		}
		z0lrk[(int)p0] = (int)p0;
		return p0;
	}

	public z0ZzZzdbj z0ip()
	{
		return z0drk;
	}

	public bool z0up()
	{
		return z0gm(typeof(XTextElement), (z0ZzZzbcj)255);
	}

	public virtual XTextElementList z0rek(string p0, bool p1, InputValueSource p2, InsertObjectEventArgs p3)
	{
		if (z0ip() != null)
		{
			FilterValueEventArgs e = new FilterValueEventArgs(p2, InputValueType.RTF, p0);
			z0ip().z0eek(e);
			if (e.Cancel)
			{
				return null;
			}
			p0 = e.Value as string;
			if (string.IsNullOrEmpty(p0))
			{
				return null;
			}
		}
		if (string.IsNullOrEmpty(p0))
		{
			throw new ArgumentNullException("rtfText");
		}
		z0ZzZzphh obj = z0ZzZznhh.z0eek().z0eek(z0ZzZzkfh.z0nek);
		z0ZzZzohh p4 = new z0ZzZzohh
		{
			EnableDocumentSetting = false,
			ImportTemplateGenerateParagraph = false,
			FastMode = true
		};
		XTextDocument xTextDocument = new XTextDocument();
		obj.z0xd(new StringReader(p0), xTextDocument, p4);
		XTextElementList xTextElementList = xTextDocument.z0xyk().z0be();
		if (xTextElementList.LastElement is XTextParagraphFlagElement && ((XTextParagraphFlagElement)xTextElementList.LastElement).z0vek())
		{
			xTextElementList.RemoveAt(xTextElementList.Count - 1);
		}
		xTextElementList = xTextElementList.z0pek();
		XTextContainerElement xTextContainerElement = (XTextContainerElement)z0dm().z0bek(typeof(XTextContainerElement));
		z0dm().z0bek(xTextElementList, xTextContainerElement.z0brk(), xTextContainerElement.z0brk());
		if (xTextElementList != null && xTextElementList.Count > 0)
		{
			for (int num = xTextElementList.Count - 1; num >= 0; num--)
			{
				if (xTextElementList[num] is XTextDocumentFooterElement || xTextElementList[num] is XTextDocumentHeaderElement)
				{
					xTextElementList.RemoveAt(num);
				}
			}
			if (xTextElementList.Count > 0 && z0ip() != null)
			{
				FilterValueEventArgs e2 = new FilterValueEventArgs(p2, InputValueType.Dom, xTextElementList);
				z0ip().z0eek(e2);
				if (e2.Cancel)
				{
					return null;
				}
				xTextElementList = e2.Value as XTextElementList;
				if (xTextElementList == null || xTextElementList.Count == 0)
				{
					return null;
				}
			}
			if (p3 != null && p3.CheckMaxTextLengthForCopyPaste && !z0dm().z0bek(xTextElementList, p3.ShowUI))
			{
				return null;
			}
			z0dm().z0xek(xTextElementList);
			if (p1)
			{
				z0dm().z0ytk();
			}
			if (z0eek().z0urk())
			{
				z0oek_jiejie20260327142557().z0tek(p0: true, p1: false, p2: false);
			}
			z0eek(xTextElementList, p1: false);
			if (p1)
			{
				z0dm().z0nuk();
			}
			z0dm().OnDocumentContentChanged();
			return xTextElementList;
		}
		return null;
	}

	private string z0eek(XTextContainerElement p0, string p1)
	{
		if (p0 == null || p1 == null || p1.Length == 0)
		{
			return p1;
		}
		for (XTextContainerElement xTextContainerElement = p0; xTextContainerElement != null; xTextContainerElement = xTextContainerElement.z0ji())
		{
			string limitedInputChars = xTextContainerElement.LimitedInputChars;
			if (limitedInputChars != null && limitedInputChars.Length > 0)
			{
				if (!z0ZzZzxcj.z0eek(151))
				{
					return p1;
				}
				p1 = z0eek(p1, limitedInputChars);
			}
		}
		return p1;
	}

	public bool z0yp()
	{
		if (z0eek().z0wrk())
		{
			return z0in().z0tek();
		}
		return false;
	}

	private void z0eek(XTextElement p0, string p1, ContentProtectedReason p2)
	{
		z0wrk = new z0ZzZzhcj(p0, p1, p2);
	}

	private bool z0eek(z0ZzZzbcj p0, z0ZzZzbcj p1)
	{
		return (p0 & p1) == p1;
	}

	public bool z0tp(XTextElement p0, z0ZzZzbcj p1)
	{
		if (z0rek())
		{
			return true;
		}
		if (p0 is XTextFieldBorderElement)
		{
			p0 = p0.z0ji();
			ElementStateDetectEventArgs e = new ElementStateDetectEventArgs(p0, p1);
			z0rm(e);
			return e.Result;
		}
		ElementStateDetectEventArgs e2 = new ElementStateDetectEventArgs(p0, p1);
		z0rm(e2);
		return e2.Result;
	}
}
