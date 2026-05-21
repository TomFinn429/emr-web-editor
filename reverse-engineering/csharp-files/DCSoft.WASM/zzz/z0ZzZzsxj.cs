using System;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using DCSoft.Writer;
using DCSoft.Writer.Controls;
using DCSoft.Writer.Dom;

namespace zzz;

internal static class z0ZzZzsxj
{
	[CompilerGenerated]
	private sealed class z0huk
	{
		public XTextDocumentContentElement z0rek;

		public XTextObjectElement z0tek;

		public z0ZzZzapj z0yek;

		public z0ZzZzypj z0uek;

		public bool z0iek;

		internal void z0eek(object p0, EventArgs p1)
		{
			if (z0yek == (z0ZzZzapj)(-1))
			{
				if (!z0uek.z0yek().z0eek())
				{
					z0tek.z0jo();
					float num = z0tek.OffsetX + z0tek.z0jr().z0xek((float)z0uek.z0yek().z0rek());
					float num2 = z0tek.OffsetY + z0tek.z0jr().z0xek((float)z0uek.z0yek().z0tek());
					if (z0tek.z0jr().z0ytk())
					{
						z0tek.z0jr().z0imk().z0eek("InnerEditorOffset", new z0ZzZzpdh(z0tek.OffsetX, z0tek.OffsetY), new z0ZzZzpdh(num, num2), z0tek);
						z0tek.z0jr().z0nuk();
					}
					z0tek.OffsetX = num;
					z0tek.OffsetY = num2;
					z0tek.z0jo();
					z0tek.z0rrk();
					z0tek.z0jr().Modified = true;
					ContentChangedEventArgs e = new ContentChangedEventArgs
					{
						EventSource = ContentChangedEventSource.UndoRedo,
						Document = z0tek.z0jr()
					};
					XTextContainerElement xTextContainerElement = (XTextContainerElement)(e.Element = z0tek.z0ji());
					xTextContainerElement.z0zi(e);
					z0tek.z0jr().OnDocumentContentChanged();
					z0iek = true;
				}
				else
				{
					z0iek = false;
				}
			}
			else
			{
				if (z0tek.z0oek().z0iek() <= 0 || z0tek.z0oek().z0oek() <= 0)
				{
					return;
				}
				int num3 = z0tek.z0oek().z0iek();
				int num4 = z0tek.z0oek().z0oek();
				z0tek.z0eek(z0ZzZzndh.z0cek);
				if ((float)num3 == z0tek.Width && (float)num4 == z0tek.Height)
				{
					return;
				}
				z0ZzZzxdh z0ZzZzxdh2 = new z0ZzZzxdh(z0tek.Width, z0tek.Height);
				z0tek.z0jo();
				z0ZzZzxdh p2 = z0tek.z0bek();
				z0tek.EditorSize = new z0ZzZzxdh(num3, num4);
				z0ZzZzafh.z0rek(z0tek.z0jr(), new XTextElementList(z0tek), p2: false);
				if (z0ZzZzxdh.z0rek(p2, z0tek.z0bek()))
				{
					z0tek.z0cy();
					z0tek.z0jo();
					z0rek.z0uek(z0tek.z0jrk(), 1);
					if (z0tek.z0jr().z0ytk())
					{
						z0tek.z0jr().z0imk().z0eek((z0ZzZzqlh)2, z0ZzZzxdh2, new z0ZzZzxdh(z0tek.Width, z0tek.Height), z0tek);
						z0tek.z0jr().z0nuk();
					}
					z0tek.z0jy().z0eek(z0tek.z0jy().z0trk().IndexOf(z0tek));
					z0tek.z0jr().Modified = true;
					z0tek.z0rrk();
					ContentChangedEventArgs e2 = new ContentChangedEventArgs
					{
						EventSource = ContentChangedEventSource.UndoRedo,
						Document = z0tek.z0jr()
					};
					XTextContainerElement xTextContainerElement2 = (XTextContainerElement)(e2.Element = z0tek.z0ji());
					xTextContainerElement2.z0zi(e2);
					z0tek.z0jr().OnDocumentContentChanged();
					z0iek = true;
				}
			}
		}
	}

	[CompilerGenerated]
	private sealed class z0nuk
	{
		public XTextTableRowElement z0rek;

		public DocumentEventArgs z0tek_jiejie20260327142557;

		internal void z0eek(z0ZzZzodh[] p0)
		{
			z0tek_jiejie20260327142557.Handled = true;
			float p1 = z0rek.Height + (float)p0[1].z0tek() - (float)p0[0].z0tek();
			z0rek.z0eek(p1, p1: true);
		}
	}

	[CompilerGenerated]
	private sealed class z0jik
	{
		public XTextTableColumnElement z0rek;

		public XTextTableCellElement z0tek;

		public DocumentEventArgs z0yek;

		internal void z0eek(z0ZzZzodh[] p0)
		{
			z0yek.Handled = true;
			float p1 = z0rek.Width + (float)p0[1].z0rek() - (float)p0[0].z0rek();
			float num = p0[1].z0rek() - p0[0].z0rek();
			if ((z0ZzZzmwh.z0oek() & Keys.Control) == Keys.Control)
			{
				z0rek.z0eek(p1, p1: true, p2: false);
			}
			else
			{
				z0ZzZzhkh z0ZzZzhkh2 = z0tek.z0jr().z0cuk();
				XTextTableCellElement xTextTableCellElement = null;
				XTextTableCellElement xTextTableCellElement2 = null;
				if (z0ZzZzhkh2.z0yek() == ContentRangeMode.Cell)
				{
					XTextElementList xTextElementList = z0ZzZzhkh2.z0frk();
					if (xTextElementList != null && xTextElementList.Count == 1)
					{
						xTextTableCellElement2 = (XTextTableCellElement)xTextElementList[0];
						xTextTableCellElement = (XTextTableCellElement)xTextTableCellElement2.z0krk().z0rek()[z0rek.z0rek()];
						if (xTextTableCellElement.z0hrk() != null)
						{
							xTextTableCellElement = xTextTableCellElement.z0hrk();
						}
						if (xTextTableCellElement != null)
						{
							if (xTextTableCellElement.z0xek() + xTextTableCellElement.ColSpan == z0tek.z0gr().z0srk().Count)
							{
								xTextTableCellElement = null;
							}
							else if (z0tek.z0pek() < xTextTableCellElement.z0pek() || z0tek.z0pek() >= xTextTableCellElement.z0pek() + xTextTableCellElement.RowSpan)
							{
								xTextTableCellElement = null;
							}
							else if (z0rek != xTextTableCellElement.z0drk() && z0rek != xTextTableCellElement.z0uek())
							{
								xTextTableCellElement = null;
							}
						}
					}
				}
				if (xTextTableCellElement != null)
				{
					if (!xTextTableCellElement.z0rek(xTextTableCellElement.Width + num, p1: true))
					{
						z0rek.z0eek(p1, p1: true, p2: true);
					}
				}
				else
				{
					z0rek.z0eek(p1, p1: true, p2: true);
				}
				xTextTableCellElement2?.z0hr();
			}
			z0yek.Handled = true;
		}
	}

	[ThreadStatic]
	private static bool z0yek;

	private static void z0eek(object p0, z0ZzZzrpj p1)
	{
		XTextTableCellElement obj = (XTextTableCellElement)p1.z0tek();
		z0ZzZzbdh z0ZzZzbdh2 = obj.z0gr().z0qyk();
		obj.z0uyk().z0gc((int)z0ZzZzbdh2.z0oek(), p1.z0yek().z0tek(), (int)z0ZzZzbdh2.z0mek(), p1.z0yek().z0tek());
	}

	private static void z0eek(XTextTableCellElement p0, XTextTableRowElement p1, DocumentEventArgs p2)
	{
		if (p1.z0iek())
		{
			z0ZzZzdbj obj = p0.z0cu();
			obj.z0ypk().z0yek(p0);
			z0ZzZzspj.z0ook p3 = delegate(z0ZzZzodh[] array)
			{
				p2.Handled = true;
				float p4 = p1.Height + (float)array[1].z0tek() - (float)array[0].z0tek();
				p1.z0eek(p4, p1: true);
			};
			obj.z0ypk().z0eek(z0eek, p3, z0ZzZzndh.z0cek, p0);
			obj.z0ypk().z0yek((XTextElement)null);
			p2.Handled = true;
			p2.CancelBubble = true;
		}
	}

	private static void z0rek(object p0, z0ZzZzrpj p1)
	{
		XTextTableCellElement obj = (XTextTableCellElement)p1.z0tek();
		z0ZzZzbdh z0ZzZzbdh2 = obj.z0gr().z0qyk();
		obj.z0uyk().z0gc(p1.z0yek().z0rek(), (int)z0ZzZzbdh2.z0pek(), p1.z0yek().z0rek(), (int)z0ZzZzbdh2.z0nek());
	}

	private static void z0eek(XTextTableCellElement p0, XTextTableColumnElement p1, DocumentEventArgs p2)
	{
		if (!p0.z0gr().z0cek())
		{
			return;
		}
		((z0ZzZzqrj)p0.z0uyk()).z0lrk().z0eek(p0: true);
		z0ZzZzspj.z0ook p3 = delegate(z0ZzZzodh[] array)
		{
			p2.Handled = true;
			float p4 = p1.Width + (float)array[1].z0rek() - (float)array[0].z0rek();
			float num = array[1].z0rek() - array[0].z0rek();
			if ((z0ZzZzmwh.z0oek() & Keys.Control) == Keys.Control)
			{
				p1.z0eek(p4, p1: true, p2: false);
			}
			else
			{
				z0ZzZzhkh z0ZzZzhkh2 = p0.z0jr().z0cuk();
				XTextTableCellElement xTextTableCellElement = null;
				XTextTableCellElement xTextTableCellElement2 = null;
				if (z0ZzZzhkh2.z0yek() == ContentRangeMode.Cell)
				{
					XTextElementList xTextElementList = z0ZzZzhkh2.z0frk();
					if (xTextElementList != null && xTextElementList.Count == 1)
					{
						xTextTableCellElement2 = (XTextTableCellElement)xTextElementList[0];
						xTextTableCellElement = (XTextTableCellElement)xTextTableCellElement2.z0krk().z0rek()[p1.z0rek()];
						if (xTextTableCellElement.z0hrk() != null)
						{
							xTextTableCellElement = xTextTableCellElement.z0hrk();
						}
						if (xTextTableCellElement != null)
						{
							if (xTextTableCellElement.z0xek() + xTextTableCellElement.ColSpan == p0.z0gr().z0srk().Count)
							{
								xTextTableCellElement = null;
							}
							else if (p0.z0pek() < xTextTableCellElement.z0pek() || p0.z0pek() >= xTextTableCellElement.z0pek() + xTextTableCellElement.RowSpan)
							{
								xTextTableCellElement = null;
							}
							else if (p1 != xTextTableCellElement.z0drk() && p1 != xTextTableCellElement.z0uek())
							{
								xTextTableCellElement = null;
							}
						}
					}
				}
				if (xTextTableCellElement != null)
				{
					if (!xTextTableCellElement.z0rek(xTextTableCellElement.Width + num, p1: true))
					{
						p1.z0eek(p4, p1: true, p2: true);
					}
				}
				else
				{
					p1.z0eek(p4, p1: true, p2: true);
				}
				xTextTableCellElement2?.z0hr();
			}
			p2.Handled = true;
		};
		p0.z0uyk().z0eek(z0rek, p3, z0ZzZzndh.z0cek, p0);
		p2.Handled = true;
		p2.CancelBubble = true;
	}

	private static void z0eek(XTextObjectElement p0, DocumentEventArgs p1)
	{
		DocumentBehaviorOptions documentBehaviorOptions = p0.z0bu();
		bool designMode = documentBehaviorOptions.DesignMode;
		if (p1.Style == DocumentEventStyles.MouseDown && p0.Enabled)
		{
			z0ZzZzapj z0ZzZzapj2 = p0.z0eek(p1.X, p1.Y);
			if (p0.z0rek())
			{
				if (z0ZzZzapj2 >= (z0ZzZzapj)0)
				{
					z0eek(p0, z0ZzZzapj2);
					p1.Handled = true;
					if (p0.z0cu() != null)
					{
						p0.z0cu().z0vik();
					}
					return;
				}
				if (p0.z0ci() != ElementZOrderStyle.Normal && z0ZzZzapj2 == (z0ZzZzapj)(-1))
				{
					z0eek(p0, z0ZzZzapj2);
					p1.Handled = true;
					return;
				}
			}
		}
		if (p1.Style == DocumentEventStyles.MouseClick)
		{
			if (!(p0.Enabled || designMode))
			{
				return;
			}
			z0ZzZzapj z0ZzZzapj3 = p0.z0eek(p1.X, p1.Y);
			if (p0.z0rek() && z0ZzZzapj3 >= (z0ZzZzapj)0)
			{
				z0eek(p0, z0ZzZzapj3);
				p1.Handled = true;
				if (p0.z0cu() != null)
				{
					p0.z0cu().z0vik();
				}
				return;
			}
			if (p0.z0iek() != null && !p0.z0iek().IsEmpty && p0.z0cu() != null && documentBehaviorOptions.EnableHyperLink && (z0ZzZzmwh.z0oek() & Keys.Control) == Keys.Control)
			{
				p1.Cursor = z0ZzZzbwh.z0ark;
				WriterLinkEventArgs p2 = new WriterLinkEventArgs(p0.z0cu(), p0.z0jr(), p0, p0.z0iek().Reference, p0.z0iek().Target);
				p0.z0cu().z0eek(p2);
				p1.Handled = true;
				return;
			}
			p1.Handled = true;
			if (p0.z0mi() || p0.z0ui())
			{
				int p3 = p0.z0jrk();
				p3 = p0.z0jr().z0ryk().z0tek(p3, (z0ZzZzfxj)2, p2: true);
				if (p3 == p0.z0jrk())
				{
					p0.z0jr().z0ryk().z0tek(p3, 1);
				}
				else
				{
					p0.z0jr().z0ryk().z0tek(p3, 0);
				}
				p0.z0jr().z0cuk().z0rek();
				p1.AlreadSetSelection = true;
				if (z0ZzZzapj3 != (z0ZzZzapj)(-1))
				{
					p1.Handled = true;
					return;
				}
				p1.Handled = true;
				z0eek((XTextElement)p0, p1);
			}
		}
		else if (p1.Style == DocumentEventStyles.MouseMove)
		{
			if (!(p0.Enabled || designMode))
			{
				return;
			}
			if (p0.z0rek())
			{
				z0ZzZzapj z0ZzZzapj4 = p0.z0tek().z0eek(p1.X, p1.Y);
				if (z0ZzZzapj4 >= (z0ZzZzapj)0)
				{
					p1.Cursor = z0ZzZzqpj.z0eek(z0ZzZzapj4);
					z0eek((XTextElement)p0, p1);
					return;
				}
			}
			if (p0.z0iek() != null && !p0.z0iek().IsEmpty && documentBehaviorOptions.EnableHyperLink)
			{
				p1.Cursor = z0ZzZzbwh.z0ark;
			}
			p1.Handled = true;
		}
		else
		{
			z0eek((XTextElement)p0, p1);
		}
	}

	private static void z0eek(XTextSectionElement p0, DocumentEventArgs p1)
	{
		if (p0.z0rek())
		{
			p1.Cursor = z0ZzZzbwh.z0krk;
		}
		if (p1.Style == DocumentEventStyles.MouseDown && p1.Button == (z0ZzZzqeh)1 && p0.z0rek())
		{
			p0.z0hr();
			p1.Handled = true;
		}
		else if (p1.Style == DocumentEventStyles.MouseDblClick && p1.Button == (z0ZzZzqeh)1 && p0.z0eek() && p0.IsCollapsed)
		{
			p1.Handled = true;
			p0.Expand();
		}
		else
		{
			z0eek((XTextContainerElement)p0, p1);
		}
	}

	private static void z0eek(XTextTableCellElement p0, DocumentEventArgs p1)
	{
		if (p1.Style == DocumentEventStyles.MouseMove || p1.Style == DocumentEventStyles.MouseDown)
		{
			float num = p0.z0jr().z0xek((float)p0.z0bu().TableCellOperationDetectDistance);
			float num2 = Math.Max(num * 2f, p0.z0aek().z0ryk);
			z0ZzZzbcj z0ZzZzbcj2 = (z0ZzZzbcj)255;
			if ((p0.z0cu().z0ook() == FormViewMode.Normal || p0.z0cu().z0ook() == FormViewMode.Strict) && p0.z0gr().z0xrk())
			{
				z0ZzZzbcj2 &= (z0ZzZzbcj)(-17);
			}
			bool flag = false;
			z0ZzZzpxj z0ZzZzpxj2 = p0.z0jr().z0xek();
			if ((float)Math.Abs(p1.X) <= num2 && (float)Math.Abs(p1.X) > num)
			{
				if (z0ZzZzpxj2.z0pm(p0, z0ZzZzbcj2))
				{
					p1.Cursor = z0ZzZzdbj.z0mrk();
					if (p1.Style == DocumentEventStyles.MouseDown && p1.StrictMatch)
					{
						p0.z0hr();
						p1.Handled = true;
					}
				}
			}
			else if ((float)Math.Abs(p1.X) <= num)
			{
				XTextTableColumnElement p2 = p0.z0drk();
				p2 = (XTextTableColumnElement)p0.z0gr().z0srk().z0pek(p2);
				if (p2 == null)
				{
					return;
				}
				if (p0.z0gr().z0cek() && z0ZzZzpxj2.z0pm(p0, z0ZzZzbcj2))
				{
					p1.Cursor = z0ZzZzdbj.z0kuk();
					if (p1.Style == DocumentEventStyles.MouseDown && p1.StrictMatch && p2 != null)
					{
						flag = true;
						z0eek(p0, p2, p1);
					}
				}
			}
			else if ((float)Math.Abs(p1.Y) <= num)
			{
				XTextTableRowElement xTextTableRowElement = p0.z0frk();
				xTextTableRowElement = (XTextTableRowElement)xTextTableRowElement.z0ke();
				if (xTextTableRowElement != null && xTextTableRowElement.z0iek() && z0ZzZzpxj2.z0pm(p0, z0ZzZzbcj2))
				{
					p1.Cursor = z0ZzZzdbj.z0wok();
					if (p1.Style == DocumentEventStyles.MouseDown && p1.StrictMatch)
					{
						flag = true;
						z0eek(p0, xTextTableRowElement, p1);
					}
				}
			}
			else if (Math.Abs((float)p1.Y - p0.Height) <= num)
			{
				if (p0.z0frk().z0iek() && z0ZzZzpxj2.z0pm(p0, z0ZzZzbcj2))
				{
					p1.Cursor = z0ZzZzdbj.z0wok();
					if (p1.Style == DocumentEventStyles.MouseDown && p1.StrictMatch)
					{
						flag = true;
						z0eek(p0, p0.z0frk(), p1);
					}
				}
			}
			else if (Math.Abs((float)p1.X - p0.Width) <= num && p0.z0gr().z0cek() && z0ZzZzpxj2.z0pm(p0, z0ZzZzbcj2))
			{
				p1.Cursor = z0ZzZzdbj.z0kuk();
				if (p1.Style == DocumentEventStyles.MouseDown && p1.StrictMatch)
				{
					flag = true;
					z0eek(p0, p0.z0uek(), p1);
				}
			}
			if (!p1.Handled && !flag)
			{
				if (p1.Style == DocumentEventStyles.MouseMove && p1.Button == (z0ZzZzqeh)0 && p0.z0qek().z0oek().z0tek(p0))
				{
					p1.Cursor = z0ZzZzdbj.z0juk();
					p1.Handled = true;
				}
				else
				{
					z0eek((XTextContainerElement)p0, p1);
				}
			}
		}
		else
		{
			z0eek((XTextContainerElement)p0, p1);
		}
	}

	private static bool z0eek(XTextObjectElement p0, z0ZzZzapj p1)
	{
		bool z0iek = false;
		z0ZzZzypj z0uek = new z0ZzZzypj(p0.z0uyk());
		z0uek.z0rek(p1);
		z0uek.z0eek(p0);
		z0uek.z0eek((z0ZzZzupj)4);
		z0uek.z0rrk = z0tek;
		XTextDocumentContentElement z0rek = p0.z0qek();
		z0uek.z0trk = delegate
		{
			if (p1 == (z0ZzZzapj)(-1))
			{
				if (!z0uek.z0yek().z0eek())
				{
					p0.z0jo();
					float num = p0.OffsetX + p0.z0jr().z0xek((float)z0uek.z0yek().z0rek());
					float num2 = p0.OffsetY + p0.z0jr().z0xek((float)z0uek.z0yek().z0tek());
					if (p0.z0jr().z0ytk())
					{
						p0.z0jr().z0imk().z0eek("InnerEditorOffset", new z0ZzZzpdh(p0.OffsetX, p0.OffsetY), new z0ZzZzpdh(num, num2), p0);
						p0.z0jr().z0nuk();
					}
					p0.OffsetX = num;
					p0.OffsetY = num2;
					p0.z0jo();
					p0.z0rrk();
					p0.z0jr().Modified = true;
					ContentChangedEventArgs e = new ContentChangedEventArgs
					{
						EventSource = ContentChangedEventSource.UndoRedo,
						Document = p0.z0jr()
					};
					XTextContainerElement xTextContainerElement = (XTextContainerElement)(e.Element = p0.z0ji());
					xTextContainerElement.z0zi(e);
					p0.z0jr().OnDocumentContentChanged();
					z0iek = true;
				}
				else
				{
					z0iek = false;
				}
			}
			else if (p0.z0oek().z0iek() > 0 && p0.z0oek().z0oek() > 0)
			{
				int num3 = p0.z0oek().z0iek();
				int num4 = p0.z0oek().z0oek();
				p0.z0eek(z0ZzZzndh.z0cek);
				if ((float)num3 != p0.Width || (float)num4 != p0.Height)
				{
					z0ZzZzxdh z0ZzZzxdh2 = new z0ZzZzxdh(p0.Width, p0.Height);
					p0.z0jo();
					z0ZzZzxdh p2 = p0.z0bek();
					p0.EditorSize = new z0ZzZzxdh(num3, num4);
					z0ZzZzafh.z0rek(p0.z0jr(), new XTextElementList(p0), p2: false);
					if (z0ZzZzxdh.z0rek(p2, p0.z0bek()))
					{
						p0.z0cy();
						p0.z0jo();
						z0rek.z0uek(p0.z0jrk(), 1);
						if (p0.z0jr().z0ytk())
						{
							p0.z0jr().z0imk().z0eek((z0ZzZzqlh)2, z0ZzZzxdh2, new z0ZzZzxdh(p0.Width, p0.Height), p0);
							p0.z0jr().z0nuk();
						}
						p0.z0jy().z0eek(p0.z0jy().z0trk().IndexOf(p0));
						p0.z0jr().Modified = true;
						p0.z0rrk();
						ContentChangedEventArgs e2 = new ContentChangedEventArgs
						{
							EventSource = ContentChangedEventSource.UndoRedo,
							Document = p0.z0jr()
						};
						XTextContainerElement xTextContainerElement2 = (XTextContainerElement)(e2.Element = p0.z0ji());
						xTextContainerElement2.z0zi(e2);
						p0.z0jr().OnDocumentContentChanged();
						z0iek = true;
					}
				}
			}
		};
		z0uek.z0lrk();
		return z0iek;
	}

	private static void z0eek(XTextElement p0, DocumentEventArgs p1)
	{
		switch (p1.Style)
		{
		case DocumentEventStyles.GotFocus:
		{
			ElementEventArgs e12 = new ElementEventArgs(p0);
			p0.z0ye(e12);
			if (e12.Handled)
			{
				p1.Handled = true;
			}
			if (e12.CancelBubble)
			{
				p1.CancelBubble = true;
			}
			e12.Dispose();
			break;
		}
		case DocumentEventStyles.LostFocus:
		{
			ElementEventArgs e9 = new ElementEventArgs(p0);
			p0.z0oy(e9);
			if (e9.Handled)
			{
				p1.Handled = true;
			}
			if (e9.CancelBubble)
			{
				p1.CancelBubble = true;
			}
			e9.Dispose();
			break;
		}
		case DocumentEventStyles.MouseEnter:
		{
			ElementEventArgs e10 = new ElementEventArgs(p0);
			p0.z0ko(e10);
			if (e10.Handled)
			{
				p1.Handled = true;
			}
			if (e10.CancelBubble)
			{
				p1.CancelBubble = true;
			}
			e10.Dispose();
			break;
		}
		case DocumentEventStyles.MouseLeave:
		{
			ElementEventArgs e2 = new ElementEventArgs(p0);
			p0.z0ei(e2);
			if (e2.Handled)
			{
				p1.Handled = true;
			}
			if (e2.CancelBubble)
			{
				p1.CancelBubble = true;
			}
			e2.Dispose();
			break;
		}
		case DocumentEventStyles.MouseDown:
		{
			ElementMouseEventArgs e5 = new ElementMouseEventArgs(p1, p0);
			p0.z0uek(e5);
			if (e5.Handled)
			{
				p1.Handled = true;
			}
			if (e5.CancelBubble)
			{
				p1.CancelBubble = true;
			}
			e5.Dispose();
			break;
		}
		case DocumentEventStyles.MouseMove:
		{
			ElementMouseEventArgs e7 = new ElementMouseEventArgs(p1, p0);
			p0.z0oek(e7);
			if (e7.Handled)
			{
				p1.Handled = true;
			}
			if (e7.CancelBubble)
			{
				p1.CancelBubble = true;
			}
			e7.Dispose();
			break;
		}
		case DocumentEventStyles.MouseUp:
		{
			ElementMouseEventArgs e8 = new ElementMouseEventArgs(p1, p0);
			p0.z0iek(e8);
			if (e8.Handled)
			{
				p1.Handled = true;
			}
			if (e8.CancelBubble)
			{
				p1.CancelBubble = true;
			}
			e8.Dispose();
			break;
		}
		case DocumentEventStyles.MouseClick:
		{
			ElementMouseEventArgs e3 = new ElementMouseEventArgs(p1, p0);
			p0.z0yek(e3);
			if (e3.Handled)
			{
				p1.Handled = true;
			}
			if (e3.CancelBubble)
			{
				p1.CancelBubble = true;
			}
			e3.Dispose();
			break;
		}
		case DocumentEventStyles.MouseDblClick:
		{
			ElementMouseEventArgs e4 = new ElementMouseEventArgs(p1, p0);
			p0.z0sy(e4);
			if (e4.Handled)
			{
				p1.Handled = true;
			}
			if (e4.CancelBubble)
			{
				p1.CancelBubble = true;
			}
			e4.Dispose();
			break;
		}
		case DocumentEventStyles.KeyDown:
		{
			ElementKeyEventArgs e11 = new ElementKeyEventArgs(p1, p0);
			p0.z0iek(e11);
			if (e11.Handled)
			{
				p1.Handled = true;
			}
			if (e11.CancelBubble)
			{
				p1.CancelBubble = true;
			}
			e11.Dispose();
			break;
		}
		case DocumentEventStyles.KeyPress:
		{
			ElementKeyEventArgs e6 = new ElementKeyEventArgs(p1, p0);
			p0.z0uek(e6);
			if (e6.Handled)
			{
				p1.Handled = true;
			}
			if (e6.CancelBubble)
			{
				p1.CancelBubble = true;
			}
			e6.Dispose();
			break;
		}
		case DocumentEventStyles.KeyUp:
		{
			ElementKeyEventArgs e = new ElementKeyEventArgs(p1, p0);
			p0.z0yek(e);
			if (e.Handled)
			{
				p1.Handled = true;
			}
			if (e.CancelBubble)
			{
				p1.CancelBubble = true;
			}
			e.Dispose();
			break;
		}
		case DocumentEventStyles.ControlLostFoucs:
		case DocumentEventStyles.LostFocusExt:
		case DocumentEventStyles.ControlGotFoucs:
			break;
		}
	}

	private static void z0eek(XTextInputFieldElement p0, DocumentEventArgs p1)
	{
		if (p1.Style == DocumentEventStyles.DefaultEditMethod)
		{
			if (p0.z0cu().z0eek(p0, p1: false, ValueEditorActiveMode.F2, p3: true, p4: true))
			{
				p1.Handled = true;
			}
			return;
		}
		if (p1.Style == DocumentEventStyles.KeyDown && p1.KeyCode == Keys.Return && (p0.EditorActiveMode & ValueEditorActiveMode.Enter) == ValueEditorActiveMode.Enter)
		{
			p0.z0uyk().z0xek(p0: true);
			if (p0.z0cu().z0eek(p0, p1: false, ValueEditorActiveMode.Enter, p3: true, p4: true))
			{
				p1.Handled = true;
				return;
			}
		}
		z0eek((XTextInputFieldElementBase)p0, p1);
		if (z0yek || p0.z0jr() == null)
		{
			return;
		}
		z0yek = false;
		z0ZzZzmcj z0ZzZzmcj2 = p0.z0jr().z0qtk();
		if (p1.Style != DocumentEventStyles.LostFocus || z0ZzZzmcj2.ExecutingRedo || z0ZzZzmcj2.ExecutingUndo || !p0.Modified || p0.FieldSettings == null || !p0.UserEditable)
		{
			return;
		}
		InputFieldEditStyle inputFieldEditStyle = p0.FieldSettings.z0nek();
		if (inputFieldEditStyle != InputFieldEditStyle.Date && inputFieldEditStyle != InputFieldEditStyle.DateTime && inputFieldEditStyle != InputFieldEditStyle.DateTimeWithoutSecond && inputFieldEditStyle != InputFieldEditStyle.Time)
		{
			return;
		}
		string text = p0.Text;
		if (text == null || text.Length <= 0 || !z0ZzZzwik.z0tek(text))
		{
			return;
		}
		switch (inputFieldEditStyle)
		{
		case InputFieldEditStyle.Date:
		case InputFieldEditStyle.DateTime:
		case InputFieldEditStyle.DateTimeWithoutSecond:
		{
			DateTime dateTime2 = z0ZzZzwik.z0eek(text, DateTime.MinValue);
			if (dateTime2 != DateTime.MinValue)
			{
				switch (inputFieldEditStyle)
				{
				case InputFieldEditStyle.Date:
					p0.z0krk(dateTime2.ToString(z0ZzZzkfh.z0trk));
					break;
				case InputFieldEditStyle.DateTime:
					p0.z0krk(dateTime2.ToString(z0ZzZzkfh.z0qrk));
					break;
				case InputFieldEditStyle.DateTimeWithoutSecond:
					p0.z0krk(dateTime2.ToString(z0ZzZzkfh.z0mek));
					break;
				}
			}
			break;
		}
		case InputFieldEditStyle.Time:
		{
			DateTime dateTime = z0ZzZzwik.z0rek(text, DateTime.MinValue);
			if (dateTime != DateTime.MinValue)
			{
				p0.z0krk(dateTime.ToString(z0ZzZzkfh.z0iek));
			}
			break;
		}
		}
	}

	private static void z0tek(object p0, z0ZzZzrpj p1)
	{
		z0ZzZzapj z0ZzZzapj2 = (z0ZzZzapj)p1.z0rek().z0jrk();
		XTextObjectElement xTextObjectElement = (XTextObjectElement)p1.z0rek().z0pek();
		z0ZzZzndh p2 = z0ZzZzndh.z0eek(xTextObjectElement.z0qyk());
		z0ZzZzodh p3 = p1.z0pek();
		z0ZzZzodh p4 = p1.z0yek();
		z0ZzZzodh z0ZzZzodh2 = z0ZzZzqpj.z0eek(p2, z0ZzZzapj2);
		z0ZzZzsmk z0ZzZzsmk2 = xTextObjectElement.z0cu().z0eek((float)z0ZzZzodh2.z0rek(), (float)z0ZzZzodh2.z0tek());
		if (z0ZzZzsmk2 != null)
		{
			p3 = ((z0ZzZzqmk)z0ZzZzsmk2).z0eek(p3);
			p4 = ((z0ZzZzqmk)z0ZzZzsmk2).z0eek(p4);
			p2 = z0ZzZzqpj.z0eek(p4.z0rek() - p3.z0rek(), p4.z0tek() - p3.z0tek(), z0ZzZzapj2, z0ZzZzndh.z0eek(xTextObjectElement.z0qyk()));
			if (p2.z0iek() > (int)xTextObjectElement.z0jr().Width)
			{
				p2.z0tek((int)xTextObjectElement.z0jr().Width);
			}
			if ((double)xTextObjectElement.z0xy() > 0.1)
			{
				p2.z0yek((int)((float)p2.z0iek() / xTextObjectElement.z0xy()));
			}
			xTextObjectElement.z0eek(p2);
			xTextObjectElement.z0uyk().z0tek(p2.z0pek(), p2.z0mek(), p2.z0nek(), p2.z0bek(), (z0ZzZzupj)1);
		}
	}

	private static void z0eek(XTextInputFieldElementBase p0, DocumentEventArgs p1)
	{
		z0yek = false;
		z0ZzZzmcj z0ZzZzmcj2 = p0.z0jr().z0qtk();
		if (p1.Style == DocumentEventStyles.LostFocus && !z0ZzZzmcj2.ExecutingRedo && !z0ZzZzmcj2.ExecutingUndo && p0.Modified)
		{
			string p2 = p0.Text;
			if (p0 is XTextInputFieldElement)
			{
				XTextInputFieldElement xTextInputFieldElement = p0 as XTextInputFieldElement;
				if (xTextInputFieldElement.FieldSettings != null && xTextInputFieldElement.FieldSettings.z0nek() != InputFieldEditStyle.DropdownList && xTextInputFieldElement.FieldSettings.z0nek() != InputFieldEditStyle.Text)
				{
					p2 = xTextInputFieldElement.InnerValue;
				}
			}
			string text = p0.z0eek(p2);
			if (text != p0.Text)
			{
				SetContainerTextArgs setContainerTextArgs = new SetContainerTextArgs();
				setContainerTextArgs.IgnoreDisplayFormat = true;
				setContainerTextArgs.NewText = text;
				setContainerTextArgs.DisablePermission = false;
				setContainerTextArgs.AccessFlags = (z0ZzZzbcj)0;
				p0.z0do(setContainerTextArgs);
				z0yek = true;
			}
		}
		z0eek((XTextContainerElement)p0, p1);
	}

	private static void z0eek(XTextRulerElement p0, DocumentEventArgs p1)
	{
		bool designMode = p0.z0bu().DesignMode;
		if (!designMode)
		{
			p1.Cursor = z0ZzZzbwh.z0krk;
		}
		switch (p1.Style)
		{
		case DocumentEventStyles.MouseDblClick:
			if (p1.Button == (z0ZzZzqeh)1 && designMode && p0.z0jr() != null && p0.z0jr().z0yyk() != null)
			{
				return;
			}
			break;
		case DocumentEventStyles.MouseClick:
			if (p1.Button != (z0ZzZzqeh)1 || designMode)
			{
				break;
			}
			p1.Cursor = z0ZzZzbwh.z0krk;
			if (!p0.Enabled)
			{
				p1.Handled = true;
				p1.CancelBubble = true;
				return;
			}
			p0.z0jo();
			if (p0.z0jr() != null && p0.z0jr().z0xek().z0np(p0))
			{
				p0.z0bek = true;
				p0.z0cek = p1.ViewX;
				p0.z0oe();
			}
			else
			{
				p1.Handled = true;
				p1.CancelBubble = true;
			}
			return;
		case DocumentEventStyles.MouseDown:
			if (!designMode)
			{
				p1.Cursor = z0ZzZzbwh.z0krk;
				if (!p0.Enabled)
				{
					p1.Handled = true;
					p1.CancelBubble = true;
				}
				else if (p1.Button == (z0ZzZzqeh)1)
				{
					p0.z0jo();
					p0.z0jr().z0yyk();
					z0eek((XTextObjectElement)p0, p1);
					p1.Handled = true;
					p1.CancelBubble = true;
				}
				return;
			}
			break;
		case DocumentEventStyles.MouseEnter:
			if (!designMode && !p0.Enabled)
			{
				p1.Handled = true;
				p1.CancelBubble = true;
				return;
			}
			if (p1.Button == (z0ZzZzqeh)0)
			{
				p0.z0jo();
				z0eek((XTextObjectElement)p0, p1);
				p1.Handled = true;
				p1.CancelBubble = true;
				return;
			}
			break;
		case DocumentEventStyles.MouseLeave:
			if (!designMode && !p0.Enabled)
			{
				p1.Handled = true;
				p1.CancelBubble = true;
				return;
			}
			if (p1.Button == (z0ZzZzqeh)0)
			{
				p0.z0jo();
				z0eek((XTextObjectElement)p0, p1);
				p1.Handled = true;
				p1.CancelBubble = true;
				return;
			}
			break;
		}
		z0eek((XTextObjectElement)p0, p1);
		if (!designMode)
		{
			p1.Cursor = z0ZzZzbwh.z0krk;
		}
	}

	private static void z0eek(XTextShapeInputFieldElement p0, DocumentEventArgs p1)
	{
		if (p1.Style == DocumentEventStyles.DefaultEditMethod)
		{
			p0.z0dw(p1);
		}
		else if (p1.Style == DocumentEventStyles.MouseDown)
		{
			if (!p0.Enabled || p0.EditMode)
			{
				return;
			}
			if (p1.MouseClicks == 2)
			{
				p0.z0dw(p1);
			}
			else if (p0.z0rek())
			{
				z0ZzZzapj z0ZzZzapj2 = p0.z0eek(p1.X, p1.Y);
				if (z0ZzZzapj2 >= (z0ZzZzapj)0)
				{
					p0.z0eek(z0ZzZzapj2);
					p1.Handled = true;
					if (p0.z0cu() != null)
					{
						p0.z0cu().z0vik();
					}
				}
			}
			else
			{
				int p2 = ((XTextElement)p0).z0jrk();
				p2 = p0.z0jr().z0ryk().z0tek(p2, (z0ZzZzfxj)2, p2: true);
				if (p2 == ((XTextElement)p0).z0jrk())
				{
					p0.z0jr().z0ryk().z0tek(p2, 1);
				}
				else
				{
					p0.z0jr().z0ryk().z0tek(p2, 0);
				}
				p1.Handled = true;
			}
		}
		else if (p1.Style == DocumentEventStyles.MouseMove)
		{
			if (p0.Enabled && !p0.EditMode && p0.z0rek())
			{
				z0ZzZzapj z0ZzZzapj3 = p0.z0tek().z0eek(p1.X, p1.Y);
				if (z0ZzZzapj3 >= (z0ZzZzapj)0)
				{
					p1.Cursor = z0ZzZzqpj.z0eek(z0ZzZzapj3);
					z0eek((XTextInputFieldElementBase)p0, p1);
				}
			}
		}
		else
		{
			z0eek((XTextInputFieldElementBase)p0, p1);
		}
	}

	private static void z0eek(XTextContainerElement p0, DocumentEventArgs p1)
	{
		z0eek((XTextElement)p0, p1);
		if (p1.Style == DocumentEventStyles.LostFocusExt && p0.z0jr().z0apk() != null)
		{
			p0.z0jr().z0apk().z0vv(p0);
		}
	}

	public static void z0rek(XTextElement p0, DocumentEventArgs p1)
	{
		if (p0 is XTextTableCellElement)
		{
			z0eek((XTextTableCellElement)p0, p1);
		}
		else if (p0 is XTextSectionElement)
		{
			z0eek((XTextSectionElement)p0, p1);
		}
		else if (p0 is XTextInputFieldElement)
		{
			z0eek((XTextInputFieldElement)p0, p1);
		}
		else if (p0 is XTextShapeInputFieldElement)
		{
			z0eek((XTextShapeInputFieldElement)p0, p1);
		}
		else if (p0 is XTextInputFieldElementBase)
		{
			z0eek((XTextInputFieldElementBase)p0, p1);
		}
		else if (p0 is XTextContainerElement)
		{
			z0eek((XTextContainerElement)p0, p1);
		}
		else if (p0 is XTextRulerElement)
		{
			z0eek((XTextRulerElement)p0, p1);
		}
		else if (p0 is XTextObjectElement)
		{
			z0eek((XTextObjectElement)p0, p1);
		}
		else
		{
			z0eek(p0, p1);
		}
	}
}
