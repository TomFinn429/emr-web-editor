using System;
using System.Collections.Generic;
using System.ComponentModel;
using DCSoft.Drawing;
using zzz;

namespace DCSoft.Writer.Dom;

[z0ZzZziqh("XDirectoryField")]
public class XTextDirectoryFieldElement : XTextInputFieldElementBase
{
	public class z0bjj
	{
		private XTextParagraphFlagElement z0oek;

		private int z0pek = -1;

		private string z0mek;

		private XTextLabelElement z0nek;

		private int z0bek = -1;

		private int z0vek;

		public void z0eek(XTextParagraphFlagElement p0)
		{
			z0oek = p0;
		}

		public void z0eek(string p0)
		{
			z0mek = p0;
		}

		public void z0eek(int p0)
		{
			z0vek = p0;
		}

		public int z0eek()
		{
			return z0vek;
		}

		public int z0rek()
		{
			return z0pek;
		}

		public int z0tek()
		{
			return z0bek;
		}

		public void z0rek(int p0)
		{
			z0bek = p0;
		}

		public XTextLabelElement z0yek()
		{
			return z0nek;
		}

		public void z0tek(int p0)
		{
			z0pek = p0;
		}

		public XTextParagraphFlagElement z0uek()
		{
			return z0oek;
		}

		public string z0iek()
		{
			return z0mek;
		}

		public void z0eek(XTextLabelElement p0)
		{
			z0nek = p0;
		}
	}

	private new bool z0tek = true;

	[NonSerialized]
	private new List<z0bjj> z0yek = new List<z0bjj>();

	private new int z0uek = 3;

	[DefaultValue(true)]
	public bool ShowPageIndex
	{
		get
		{
			return z0tek;
		}
		set
		{
			z0tek = value;
		}
	}

	[DefaultValue(3)]
	public int DisplayLevel
	{
		get
		{
			return z0uek;
		}
		set
		{
			z0uek = value;
		}
	}

	public override string z0ge()
	{
		return "Directory:" + ID;
	}

	public new void z0rek()
	{
		if (!ShowPageIndex)
		{
			return;
		}
		foreach (z0bjj item in z0yek)
		{
			XTextLabelElement xTextLabelElement = item.z0yek();
			if (xTextLabelElement == null)
			{
				continue;
			}
			string text = xTextLabelElement.Text;
			if (!string.IsNullOrEmpty(text) && item.z0uek() != null)
			{
				int num = text.LastIndexOf('.');
				if (num > 0)
				{
					text = text.Substring(0, num);
				}
				text += Convert.ToString(item.z0uek().z0je() + 1);
				xTextLabelElement.Text = text;
			}
		}
	}

	public new void z0rek(bool p0)
	{
		if (z0jr() == null)
		{
			return;
		}
		z0be().Clear();
		XTextDocumentContentElement xTextDocumentContentElement = z0qek();
		xTextDocumentContentElement.z0rek(p0: true, p1: true);
		z0yek = new List<z0bjj>();
		z0eek(xTextDocumentContentElement.z0nek(), z0yek, 0);
		float num = ((XTextElement)z0jy()).z0ork() - 10f;
		z0ZzZzsdh value = z0jr().z0vmk().Value;
		int tickCount = Environment.TickCount;
		using (z0ZzZzjpk z0ZzZzjpk = z0ru())
		{
			z0ZzZzxdh z0ZzZzxdh = z0ZzZzjpk.z0eek(".", value, 10000, z0ZzZzlsh.z0uek());
			int count = z0jr().z0suk().Count;
			int num2 = 0;
			foreach (z0bjj item in z0yek)
			{
				if (!item.z0uek().z0aek().z0syk)
				{
					continue;
				}
				item.z0uek().z0yek(tickCount++);
				num2++;
				XTextLabelElement xTextLabelElement = new XTextLabelElement();
				xTextLabelElement.Multiline = false;
				xTextLabelElement.ID = ID + "_Label_" + num2;
				string text = item.z0uek().z0xek();
				if (text != null)
				{
					int num3 = text.IndexOf('\r');
					if (num3 > 0)
					{
						text = text.Substring(0, num3);
					}
					num3 = text.IndexOf('\n');
					if (num3 > 0)
					{
						text = text.Substring(0, num3);
					}
				}
				string text2 = new string(' ', item.z0eek() * 3);
				if (ShowPageIndex)
				{
					text2 = text2 + "..." + count;
				}
				z0ZzZzxdh z0ZzZzxdh2 = z0ZzZzjpk.z0eek(text2, value, 10000, z0ZzZzlsh.z0uek());
				while (z0ZzZzjpk.z0eek(text, value, 10000, z0ZzZzlsh.z0uek()).z0rek() + z0ZzZzxdh2.z0rek() > num && text.Length > 2)
				{
					text = text.Substring(0, text.Length - 1);
				}
				if (ShowPageIndex)
				{
					text2 = new string(' ', item.z0eek() * 3) + text + count;
					int num4 = (int)Math.Floor((num - z0ZzZzjpk.z0eek(text2, value, 10000, z0ZzZzlsh.z0uek()).z0rek()) / z0ZzZzxdh.z0rek());
					if (num4 < 0)
					{
						num4 = 0;
					}
					text2 = new string(' ', item.z0eek() * 3) + text + new string('.', num4) + count;
					xTextLabelElement.Text = text2;
				}
				else
				{
					xTextLabelElement.Text = new string(' ', item.z0eek() * 3) + text;
				}
				xTextLabelElement.AutoSize = true;
				xTextLabelElement.z0bt(z0jr());
				xTextLabelElement.z0nu(this);
				xTextLabelElement.z0oek(((XTextElement)this).z0pek());
				xTextLabelElement.Alignment = DCContentAlignment.MiddleLeft;
				((XTextObjectElement)xTextLabelElement).z0eek(new z0ZzZzbuk());
				xTextLabelElement.z0iek().Reference = "#DCTopic_" + item.z0uek().z0krk();
				xTextLabelElement.z0iek().Title = text;
				((XTextObjectElement)xTextLabelElement).z0eek((object)item);
				xTextLabelElement.z0eek(item.z0uek().z0krk());
				item.z0eek(xTextLabelElement);
				z0be().Add(xTextLabelElement);
			}
		}
		if (p0)
		{
			z0oe();
			z0rek();
		}
	}

	public XTextDirectoryFieldElement()
	{
		base.ContentReadonly = ContentReadonlyState.False;
		EnableHighlight = EnableState.Disabled;
		base.BorderVisible = DCVisibleState.Hidden;
	}

	public override XTextElement z0lr(bool p0)
	{
		XTextDirectoryFieldElement obj = (XTextDirectoryFieldElement)base.z0lr(p0);
		obj.z0yek = null;
		return obj;
	}

	public override void z0rt(ElementLoadEventArgs p0)
	{
		base.z0rt(p0);
		XTextDocumentContentElement xTextDocumentContentElement = z0qek();
		xTextDocumentContentElement.z0rek(p0: true, p1: true);
		z0yek = new List<z0bjj>();
		z0eek(xTextDocumentContentElement.z0nek(), z0yek, 0);
		using zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = z0be().z0ltk();
		while (z0bpk.MoveNext())
		{
			XTextElement current = z0bpk.Current;
			if (!(current is XTextLabelElement))
			{
				continue;
			}
			XTextLabelElement xTextLabelElement = (XTextLabelElement)current;
			foreach (z0bjj item in z0yek)
			{
				if (item.z0yek() == null && item.z0uek().z0krk() == xTextLabelElement.z0rek())
				{
					item.z0eek(xTextLabelElement);
					break;
				}
			}
		}
	}

	private void z0eek(XTextParagraphFlagElement p0, List<z0bjj> p1, int p2)
	{
		List<XTextParagraphFlagElement> list = p0?.z0bek();
		if (list == null || list.Count == 0)
		{
			return;
		}
		foreach (XTextParagraphFlagElement item in list)
		{
			z0bjj z0bjj = new z0bjj();
			z0bjj.z0eek(item);
			z0bjj.z0eek(p2);
			item.Text = item.z0xek();
			p1.Add(z0bjj);
			if (item.z0nek() && p2 + 1 < DisplayLevel)
			{
				z0eek(item, p1, p2 + 1);
			}
		}
	}
}
