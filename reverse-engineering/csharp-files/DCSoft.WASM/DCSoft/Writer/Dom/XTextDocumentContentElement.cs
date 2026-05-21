using System;
using System.Collections.Generic;
using System.ComponentModel;
using DCSoft.Drawing;
using DCSoft.Writer.Controls;
using zzz;

namespace DCSoft.Writer.Dom;

public abstract class XTextDocumentContentElement : XTextContentElement
{
	[NonSerialized]
	private new XTextElement[] z0prk;

	private new bool z0mrk;

	[NonSerialized]
	private new z0ZzZzplh z0nrk;

	private new float z0brk;

	[NonSerialized]
	private new bool z0vrk;

	[NonSerialized]
	private new XTextElementList z0crk;

	[ThreadStatic]
	internal new static bool z0xrk;

	[NonSerialized]
	private new XTextParagraphFlagElement z0zrk;

	internal new int z0ltk;

	[NonSerialized]
	private new z0ZzZzhkh z0ktk;

	[NonSerialized]
	private new List<List<XTextParagraphFlagElement>> z0jtk;

	[NonSerialized]
	private new z0ZzZzlkh z0htk;

	[NonSerialized]
	private new DCBooleanValue z0gtk = DCBooleanValue.Inherit;

	[NonSerialized]
	private new WeakReference z0ftk;

	private new int z0dtk;

	[NonSerialized]
	private new bool z0stk = true;

	[z0ZzZzuqh]
	public override z0ZzZzzej GridLine
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	[z0ZzZzuqh]
	[DefaultValue(true)]
	public override bool AcceptTab
	{
		get
		{
			return true;
		}
		set
		{
		}
	}

	public int z0rek()
	{
		return -1;
	}

	public new void z0rek(bool p0)
	{
		z0stk = p0;
	}

	public new z0ZzZzlkh z0tek()
	{
		if (z0etk == null || z0etk.Length == 0)
		{
			return null;
		}
		z0ZzZzlkh z0ZzZzlkh = new z0ZzZzlkh(base.z0zek().Length);
		z0tek(this, z0ZzZzlkh);
		return z0ZzZzlkh;
	}

	public new void z0rek(int p0)
	{
	}

	private void z0rek(XTextContentElement p0, z0ZzZzlkh p1)
	{
		z0ZzZzzlh[] array = p0.z0zek();
		if (array == null || array.Length == 0)
		{
			return;
		}
		int num = array.Length;
		z0ZzZzzlh[] array2 = array;
		for (int i = 0; i < num; i++)
		{
			z0ZzZzzlh z0ZzZzzlh = array2[i];
			if (z0ZzZzzlh.z0jrk_jiejie20260327142557())
			{
				XTextElementList xTextElementList = z0ZzZzzlh.z0ntk().z0crk();
				int count = xTextElementList.Count;
				XTextElement[] array3 = ((zzz.z0ZzZzkuk<XTextElement>)xTextElementList).z0krk();
				for (int j = 0; j < count; j++)
				{
					XTextElement xTextElement = array3[j];
					if (!xTextElement.z0cuk)
					{
						continue;
					}
					XTextElementList xTextElementList2 = xTextElement.z0be();
					int count2 = xTextElementList2.Count;
					XTextElement[] array4 = ((zzz.z0ZzZzkuk<XTextElement>)xTextElementList2).z0krk();
					for (int k = 0; k < count2; k++)
					{
						XTextTableCellElement xTextTableCellElement = (XTextTableCellElement)array4[k];
						if (xTextTableCellElement.z0yi())
						{
							z0rek(xTextTableCellElement, p1);
						}
					}
				}
			}
			else if (z0ZzZzzlh.z0qtk())
			{
				XTextSectionElement p2 = z0ZzZzzlh.z0mek();
				z0rek(p2, p1);
			}
			else
			{
				z0ZzZzzlh.z0tuk = p1.Count;
				p1.Add(z0ZzZzzlh);
			}
		}
	}

	private new XTextTableCellElement z0yek()
	{
		return null;
	}

	internal void z0rek(z0ZzZzlkh p0 = null)
	{
		XTextDocument xTextDocument = z0rik;
		if (xTextDocument == null || xTextDocument.z0suk() == null || xTextDocument.z0suk().Count == 0)
		{
			return;
		}
		base.z0rek(1);
		z0ZzZzwrj z0ZzZzwrj = null;
		int num = 0;
		if (p0 != null && z0htk == null)
		{
			z0tek(p0);
		}
		z0ZzZzzlh[] array = z0rrk().z0krk();
		int count = z0rrk().Count;
		for (int i = 0; i < count; i++)
		{
			z0ZzZzzlh z0ZzZzzlh = array[i];
			if (z0ZzZzzlh.z0guk != z0ZzZzwrj)
			{
				z0ZzZzwrj = z0ZzZzzlh.z0guk;
				num = z0ZzZzzlh.z0hrk();
			}
			z0ZzZzzlh.z0rek(z0ZzZzzlh.z0hrk() - num + 1);
		}
		z0ZzZzwrj = null;
		num = 0;
		int num2 = 0;
		array = base.z0zek();
		count = base.z0zek().Length;
		for (int j = 0; j < count; j++)
		{
			z0ZzZzzlh z0ZzZzzlh2 = array[j];
			if (z0ZzZzzlh2.z0guk != z0ZzZzwrj)
			{
				z0ZzZzwrj = z0ZzZzzlh2.z0guk;
				num = num2;
			}
			z0ZzZzzlh2.z0tek(num2 - num + 1);
			num2++;
		}
	}

	public new z0ZzZzzlh z0uek()
	{
		return z0nrk?.z0lrk();
	}

	internal new bool z0iek()
	{
		return z0prk != null;
	}

	private void z0tek(XTextContentElement p0, z0ZzZzlkh p1)
	{
		if (p0.z0zek() == null)
		{
			return;
		}
		int num = p0.z0zek().Length;
		z0ZzZzzlh[] array = p0.z0zek();
		for (int i = 0; i < num; i++)
		{
			z0ZzZzzlh z0ZzZzzlh = array[i];
			p1.Add(z0ZzZzzlh);
			if (z0ZzZzzlh.z0qtk())
			{
				XTextSectionElement p2 = z0ZzZzzlh.z0mek();
				z0tek(p2, p1);
			}
			else
			{
				if (!z0ZzZzzlh.z0jrk_jiejie20260327142557())
				{
					continue;
				}
				XTextTableElement xTextTableElement = z0ZzZzzlh.z0ntk();
				if (xTextTableElement.z0srk() == null)
				{
					continue;
				}
				p1.z0yrk(p1.Count + xTextTableElement.z0stk().Count * xTextTableElement.z0srk().Count);
				foreach (XTextElement item in xTextTableElement.z0stk().z0xrk())
				{
					foreach (XTextTableCellElement item2 in item.z0be().z0xrk())
					{
						if (!item2.z0bek())
						{
							z0tek(item2, p1);
						}
					}
				}
			}
		}
	}

	private void z0tek(z0ZzZzlkh p0)
	{
		if (z0htk == null && p0 != null)
		{
			z0htk = p0;
			z0htk.Clear();
			z0rek(this, z0htk);
			for (int num = z0htk.Count - 1; num >= 0; num--)
			{
				z0htk[num].z0tuk = num;
			}
		}
	}

	public new z0ZzZzhkh z0oek()
	{
		if (z0ktk == null)
		{
			z0ktk = new z0ZzZzhkh(this);
		}
		return z0ktk;
	}

	private new int z0pek()
	{
		return 0;
	}

	private new void z0mek()
	{
		if (z0htk != null)
		{
			z0htk.Clear();
			z0ftk = new WeakReference(z0htk);
			z0htk = null;
		}
	}

	public new XTextParagraphFlagElement z0nek()
	{
		return z0zrk;
	}

	public override XTextElement z0lr(bool p0)
	{
		XTextDocumentContentElement obj = (XTextDocumentContentElement)base.z0lr(p0);
		obj.z0nrk = null;
		obj.z0htk = null;
		obj.z0crk = null;
		obj.z0ktk = null;
		obj.z0jtk = null;
		obj.z0zrk = null;
		obj.z0stk = true;
		obj.z0prk = null;
		return obj;
	}

	private new DocumentContentStyle z0bek()
	{
		return null;
	}

	internal void z0rek(XTextElement p0, XTextElement p1)
	{
		if (p0 == null && p1 == null)
		{
			return;
		}
		if (p0 == null)
		{
			p0 = p1;
		}
		if (p1 == null)
		{
			p1 = p0;
		}
		if (z0nrk == null || z0nrk.Count <= 0)
		{
			return;
		}
		int num = z0nrk.z0bek(p0);
		int num2 = z0nrk.z0bek(p1);
		bool flag = false;
		if (num < 0 || num2 < 0)
		{
			if (z0ZzZzafh.z0uek(p0, p1) > 0)
			{
				flag = true;
				XTextElement xTextElement = p0;
				p0 = p1;
				p1 = xTextElement;
			}
			z0ZzZzkxj z0ZzZzkxj = new z0ZzZzkxj(this);
			z0ZzZzkxj.ExcludeCharElement = false;
			z0ZzZzkxj.ExcludeParagraphFlag = false;
			int num3 = -1;
			bool flag2 = false;
			foreach (XTextElement item in z0ZzZzkxj)
			{
				if (num3 < 0)
				{
					if (item != z0nrk[0])
					{
						continue;
					}
					num3 = 0;
				}
				if (num < 0 && item == p0)
				{
					XTextElement xTextElement3 = z0nrk.SafeGet(num3 + 1);
					num = ((xTextElement3 == null || xTextElement3.z0jy() != z0nrk[num3].z0jy()) ? num3 : (num3 + 1));
					if (p0 == p1)
					{
						num2 = num;
						break;
					}
				}
				bool flag3 = item == z0nrk.SafeGet(num3 + 1);
				if (flag3)
				{
					num3++;
				}
				else if (item.z0jrk() >= 0 && item == z0nrk.SafeGet(item.z0jrk()))
				{
					flag3 = true;
					num3 = item.z0jrk();
				}
				if (num2 < 0)
				{
					if (!flag2 && item == p1)
					{
						flag2 = true;
					}
					if (flag2 && flag3)
					{
						num2 = num3;
					}
				}
				if (num >= 0 && num2 >= 0)
				{
					break;
				}
			}
			z0ZzZzkxj.Dispose();
		}
		if (num >= 0 && num2 >= 0)
		{
			if (flag)
			{
				z0uek(num2, num - num2);
			}
			else
			{
				z0uek(num, num2 - num);
			}
		}
	}

	private new XTextElement z0vek()
	{
		return null;
	}

	internal new bool z0cek()
	{
		if (z0gtk == DCBooleanValue.Inherit)
		{
			z0gtk = DCBooleanValue.False;
			int count = z0ntk.Count;
			XTextElement[] array = ((zzz.z0ZzZzkuk<XTextElement>)z0ntk).z0krk();
			for (int i = 0; i < count; i++)
			{
				XTextElement xTextElement = array[i];
				if (!(xTextElement is XTextTableElement))
				{
					continue;
				}
				foreach (XTextTableRowElement item in ((XTextTableElement)xTextElement).z0stk().z0xrk())
				{
					if (item.z0yi() && item.HeaderStyle)
					{
						z0gtk = DCBooleanValue.True;
						return true;
					}
				}
			}
		}
		return z0gtk == DCBooleanValue.True;
	}

	public new bool z0xek()
	{
		return z0stk;
	}

	internal bool z0rek(XTextTableCellElement p0, XTextTableCellElement p1)
	{
		if (z0frk().Count == 0)
		{
			return false;
		}
		if (p0 == null)
		{
			throw new ArgumentNullException("firstCell");
		}
		if (p1 == null)
		{
			p1 = p0;
		}
		if (!p0.z0yi() || !p1.z0yi() || p0.z0hy() == null || p1.z0hy() == null)
		{
			return false;
		}
		int p2 = z0oek().z0nek();
		int p3 = z0oek().z0qrk();
		z0frk().z0tek(ref p2, ref p3);
		z0ZzZztzj z0ZzZztzj = new z0ZzZztzj();
		z0ZzZztzj.z0eek(z0jr());
		z0ZzZztzj.z0eek(z0oek().z0nek());
		z0ZzZztzj.z0rek(z0oek().z0qrk());
		z0ZzZztzj.z0tek(p0.z0hy().z0jrk());
		z0ZzZztzj.z0yek(p1.z0xt().z0jrk() - p0.z0ie().z0jrk());
		z0jr().z0bek(z0ZzZztzj);
		if (z0ZzZztzj.z0yek())
		{
			return false;
		}
		if (z0oek().z0rek(p0, p1))
		{
			if (z0jr().z0yyk() != null)
			{
				z0jr().z0yyk().z0vik();
			}
			z0tek(z0frk().SafeGet(p2), z0frk().SafeGet(z0oek().z0nek()));
			z0jr().OnSelectionChanged();
			if (z0uyk() != null)
			{
				z0uyk().z0hz();
			}
			return true;
		}
		return false;
	}

	public new XTextElement z0zek()
	{
		if (z0rik == null)
		{
			return null;
		}
		if (z0nrk == null || z0nrk.Count == 0)
		{
			return null;
		}
		if (z0ktk == null)
		{
			return z0nrk[z0nrk.Count - 1];
		}
		return z0nrk.z0ork();
	}

	internal new void z0lrk()
	{
		z0mrk = false;
		z0gtk = DCBooleanValue.Inherit;
		XTextDocument xTextDocument = z0jr();
		if (xTextDocument == null)
		{
			return;
		}
		xTextDocument.z0bik();
		xTextDocument.z0wik();
		xTextDocument.z0lyk();
		z0nrk.Clear();
		if (z0ltk > 200)
		{
			z0nrk.Capacity = z0ltk + 30;
		}
		z0eok_jiejie20260327142557 z0eok_jiejie20260327142557 = new z0eok_jiejie20260327142557(z0jr(), z0nrk, p2: false);
		z0ue(z0eok_jiejie20260327142557);
		int count = z0nrk.Count;
		if (z0ltk > 0)
		{
			z0ltk = 0;
		}
		XTextElement[] array = ((zzz.z0ZzZzkuk<XTextElement>)z0nrk).z0krk();
		List<XTextElement> list = null;
		if (z0xrk)
		{
			for (int i = 0; i < count; i++)
			{
				array[i].z0tuk = i;
			}
		}
		else
		{
			z0prk = null;
			bool flag = false;
			if (z0eok_jiejie20260327142557.z0zek == DCBooleanValue.True)
			{
				flag = true;
			}
			else if (z0eok_jiejie20260327142557.z0zek == DCBooleanValue.False)
			{
				flag = false;
			}
			else
			{
				z0kr();
				flag = ((XTextContainerElement)this).z0zrk() || ((XTextContainerElement)this).z0xrk();
			}
			for (int j = 0; j < count; j++)
			{
				XTextElement xTextElement = array[j];
				xTextElement.z0tuk = j;
				if (!flag || !(xTextElement is XTextObjectElement))
				{
					continue;
				}
				z0mrk = true;
				ElementZOrderStyle elementZOrderStyle = ((XTextObjectElement)xTextElement).z0ci();
				if (elementZOrderStyle == ElementZOrderStyle.InFrontOfText || elementZOrderStyle == ElementZOrderStyle.UnderText)
				{
					if (list == null)
					{
						list = new List<XTextElement>();
					}
					list.Add(xTextElement);
				}
			}
			if (list != null)
			{
				z0prk = list.ToArray();
			}
			else
			{
				z0prk = null;
			}
		}
		z0eok_jiejie20260327142557.Dispose();
	}

	public override bool z0wu(int p0, int p1, bool p2, bool p3)
	{
		if (z0xu())
		{
			return false;
		}
		if (z0nrk != null && z0nrk.Count > 0 && z0mrk)
		{
			int count = z0nrk.Count;
			XTextElement[] array = ((zzz.z0ZzZzkuk<XTextElement>)z0nrk).z0krk();
			List<XTextElement> list = null;
			for (int i = 0; i < count; i++)
			{
				XTextElement xTextElement = array[i];
				if (!(xTextElement is XTextObjectElement))
				{
					continue;
				}
				ElementZOrderStyle elementZOrderStyle = ((XTextObjectElement)xTextElement).z0ci();
				if (elementZOrderStyle == ElementZOrderStyle.InFrontOfText || elementZOrderStyle == ElementZOrderStyle.UnderText)
				{
					if (list == null)
					{
						list = new List<XTextElement>();
					}
					list.Add(xTextElement);
				}
			}
			if (list != null)
			{
				z0prk = list.ToArray();
			}
			else
			{
				z0prk = null;
			}
		}
		return base.z0wu(p0, p1, p2, p3);
	}

	public z0ZzZzhkh z0rek(int p0, int p1)
	{
		z0ZzZzhkh z0ZzZzhkh = new z0ZzZzhkh(this);
		z0ZzZzhkh.z0tek(p0, p1);
		return z0ZzZzhkh;
	}

	public override void Dispose()
	{
		base.Dispose();
		if (z0nrk != null)
		{
			z0nrk.z0srk();
			z0nrk.Capacity = 0;
			z0nrk = null;
		}
		if (z0crk != null)
		{
			z0crk.Clear();
			z0crk.Capacity = 0;
			z0crk = null;
		}
		if (z0jtk != null)
		{
			z0jtk.Clear();
			z0jtk = null;
		}
		if (z0htk != null)
		{
			z0htk.z0eek();
			z0htk.Capacity = 0;
			z0htk = null;
		}
		z0zrk = null;
		if (z0ktk != null)
		{
			z0ktk.Dispose();
			z0ktk = null;
		}
	}

	public virtual bool z0rek(XTextElement p0)
	{
		if (z0ktk != null)
		{
			return z0ktk.z0rek(p0);
		}
		return false;
	}

	public override void z0vw(z0ZzZzvxj p0)
	{
		p0.z0gtk = z0qyk();
		p0.z0eek(this);
		p0.z0brk = z0frk();
		if (z0iek())
		{
			z0rek(ElementZOrderStyle.UnderText, p0);
			base.z0vw(p0);
			z0rek(ElementZOrderStyle.InFrontOfText, p0);
		}
		else
		{
			base.z0vw(p0);
		}
	}

	public override void z0uu(bool p0)
	{
		z0xi(p0: true);
		z0li();
		z0bek(p0: true);
		z0jo();
		using (z0ZzZzjpk p1 = z0ru())
		{
			z0ZzZzvxj z0ZzZzvxj = z0jr().z0bek(p1, (z0ZzZzcxj)0);
			z0ZzZzvxj.z0eyk = false;
			z0ZzZzvxj.z0hyk = this;
			if (p0)
			{
				z0ZzZzvxj.z0eek(p0: true);
			}
			else
			{
				z0ZzZzvxj.z0eek(p0: false);
			}
			z0mr(z0ZzZzvxj);
		}
		XTextElement.z0yek(this, !p0);
		((XTextContentElement)this).z0tek(p0: false);
		z0eek(-10000);
		z0jo();
		z0oek().z0erk();
	}

	public new XTextElementList z0krk()
	{
		if (z0crk == null)
		{
			z0crk = new XTextElementList();
			((zzz.z0ZzZzkuk<XTextElement>)z0crk).z0pek((XTextElement)this);
			z0rek(this, z0crk);
		}
		return z0crk;
	}

	public new XTextParagraphFlagElement z0jrk()
	{
		return z0frk().z0yrk();
	}

	public new bool z0hrk()
	{
		return z0vrk;
	}

	internal void z0rek(ref XTextElement p0, ref XTextElement p1)
	{
		if (z0nrk != null && z0ktk != null)
		{
			p0 = z0nrk.SafeGet(z0ktk.z0nek());
			p1 = z0nrk.SafeGet(z0ktk.z0nek() + z0ktk.z0qrk());
			if (p0 == null)
			{
				p0 = p1;
			}
			if (p1 == null)
			{
				p1 = p0;
			}
		}
	}

	public bool z0tek(int p0, int p1)
	{
		if (p0 >= 0 && p1 >= 0)
		{
			int num = z0frk().z0tek(p0, (z0ZzZzfxj)0, p2: true);
			int num2 = z0frk().z0tek(p1, (z0ZzZzfxj)1, p2: true);
			if (num != p0 || num2 != p1)
			{
				return z0qek().z0uek(num, 0);
			}
			return z0qek().z0uek(p0, p1 - p0 + 1);
		}
		return false;
	}

	internal override void z0su()
	{
		z0nrk = new z0ZzZzplh(this, 1);
		((zzz.z0ZzZzkuk<XTextElement>)z0nrk).z0pek(z0ntk[0]);
		z0nrk[0].z0tuk = 0;
		base.z0su();
	}

	internal new XTextElement[] z0grk()
	{
		return z0prk;
	}

	public override void z0sr()
	{
		XTextDocument xTextDocument = z0jr();
		if (xTextDocument != null && xTextDocument.z0yyk() != null)
		{
			xTextDocument.z0yyk().z0eek(this);
		}
		else if (xTextDocument.z0jrk() != this)
		{
			xTextDocument.z0bek(this);
		}
	}

	public override void z0rt(ElementLoadEventArgs p0)
	{
		if (z0nrk != null)
		{
			z0nrk.Clear();
		}
		if (z0crk != null)
		{
			z0crk.Clear();
			z0crk = null;
		}
		if (z0htk != null)
		{
			z0htk.Clear();
		}
		z0stk = true;
		base.z0rt(p0);
	}

	public void z0tek(ref XTextElement p0, ref XTextElement p1)
	{
		if (z0nrk != null && z0nrk.Count > 0 && z0ktk != null)
		{
			p0 = z0nrk.SafeGet(z0ktk.z0lrk());
			p1 = z0nrk.SafeGet(z0ktk.z0drk());
		}
	}

	public new z0ZzZzplh z0frk()
	{
		if (z0nrk == null)
		{
			z0nrk = new z0ZzZzplh(this);
		}
		if (z0nrk.Count == 0 && z0rik != null)
		{
			z0lrk();
			z0rek(p0: true, p1: true);
			if (z0ktk != null)
			{
				z0ktk.z0rek(z0nrk);
			}
		}
		return z0nrk;
	}

	private new DocumentContentStyle z0drk()
	{
		return null;
	}

	public virtual z0ZzZzkkh z0yek(int p0, int p1)
	{
		return new z0ZzZzkkh(this, p0, p1);
	}

	public new List<List<XTextParagraphFlagElement>> z0srk()
	{
		return z0jtk;
	}

	internal void z0tek(XTextElement p0, XTextElement p1)
	{
		p0 = XTextCheckBoxElementBase.z0eek(p0);
		p1 = XTextCheckBoxElementBase.z0eek(p1);
		if (p0 == p1)
		{
			return;
		}
		XTextDocument xTextDocument = z0jr();
		if (xTextDocument.z0kxk)
		{
			xTextDocument.z0kxk = false;
			return;
		}
		DocumentBehaviorOptions documentBehaviorOptions = z0bu();
		XTextElementList xTextElementList = ((p0 == null) ? new XTextElementList() : z0ZzZzafh.z0pek(p0));
		if (documentBehaviorOptions.WidelyRaiseFocusEvent)
		{
			xTextElementList = ((p0 == null) ? new XTextElementList() : z0ZzZzafh.z0iek(p0));
		}
		if (p0 != null)
		{
			xTextElementList.Insert(0, p0);
		}
		XTextElementList xTextElementList2 = ((p1 == null) ? new XTextElementList() : z0ZzZzafh.z0pek(p1));
		if (documentBehaviorOptions.WidelyRaiseFocusEvent)
		{
			xTextElementList2 = ((p1 == null) ? new XTextElementList() : z0ZzZzafh.z0iek(p1));
		}
		if (p1 != null)
		{
			xTextElementList2.Insert(0, p1);
		}
		bool flag = false;
		using (zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = xTextElementList.z0ltk())
		{
			while (z0bpk.MoveNext())
			{
				XTextElement current = z0bpk.Current;
				if (current is XTextTableElement)
				{
					flag = true;
				}
				if (!xTextElementList2.Contains(current) && !(current is XTextCharElement))
				{
					DocumentEventArgs e = new DocumentEventArgs(xTextDocument, current, DocumentEventStyles.LostFocus);
					current.z0mu(e);
					e.z0qrk = DocumentEventStyles.LostFocusExt;
					current.z0mu(e);
				}
			}
		}
		XTextTableElement xTextTableElement = null;
		using (zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = xTextElementList2.z0ltk())
		{
			while (z0bpk.MoveNext())
			{
				XTextElement current2 = z0bpk.Current;
				if (flag && current2 is XTextTableElement)
				{
					xTextTableElement = (XTextTableElement)current2;
				}
				if (!xTextElementList.Contains(current2) && !(current2 is XTextCharElement))
				{
					DocumentEventArgs p2 = new DocumentEventArgs(xTextDocument, current2, DocumentEventStyles.GotFocus);
					current2.z0mu(p2);
				}
			}
		}
		if (xTextTableElement != null && !((XTextElement)xTextTableElement).z0vek())
		{
			xTextTableElement.z0jo();
		}
	}

	internal void z0rek(z0lgj p0)
	{
		base.z0au(p0);
	}

	public bool z0uek(int p0, int p1)
	{
		XTextDocument xTextDocument = z0jr();
		if (xTextDocument == null)
		{
			return false;
		}
		if (xTextDocument.z0snk() && p0 == 0 && p1 == 0)
		{
			return false;
		}
		if (z0frk().Count == 0)
		{
			return false;
		}
		if (z0xu())
		{
			return false;
		}
		if (p0 < 0)
		{
			p0 = 0;
		}
		int p2 = z0oek().z0nek();
		int p3 = z0oek().z0qrk();
		z0frk().z0tek(ref p2, ref p3);
		if (z0oek().z0rek(p0, p1))
		{
			z0ZzZztzj z0ZzZztzj = new z0ZzZztzj();
			z0ZzZztzj.z0eek(xTextDocument);
			z0ZzZztzj.z0eek(z0oek().z0nek());
			z0ZzZztzj.z0rek(z0oek().z0qrk());
			z0ZzZztzj.z0tek(p0);
			z0ZzZztzj.z0yek(p1);
			xTextDocument.z0bek(z0ZzZztzj);
			if (z0ZzZztzj.z0yek())
			{
				return false;
			}
			p0 = z0ZzZztzj.z0uek();
			p1 = z0ZzZztzj.z0tek();
			z0bu();
			if (z0oek().z0tek(p0, p1))
			{
				if (xTextDocument.z0yyk() != null && !((z0ZzZzmwh)xTextDocument.z0yyk()).z0krk())
				{
					if (z0oek().z0vek())
					{
						xTextDocument.z0yyk().z0vik();
					}
					else
					{
						bool flag = false;
						if (z0uyk().z0eyk() == DragOperationState.Drag && xTextDocument.z0vtk().BehaviorOptions.ParagraphFlagFollowTableOrSection)
						{
							XTextElement xTextElement = z0zek();
							if (xTextElement is XTextParagraphFlagElement)
							{
								z0ZzZzzlh z0ZzZzzlh = xTextElement.z0ptk();
								if (z0ZzZzzlh != null && (z0ZzZzzlh.z0jrk_jiejie20260327142557() || z0ZzZzzlh.z0qtk()))
								{
									z0uyk().z0guk();
									flag = true;
								}
							}
						}
						if (!flag)
						{
							xTextDocument.z0yyk().z0vik();
						}
					}
				}
				if (!xTextDocument.z0snk())
				{
					z0tek(z0frk().SafeGet(p2), z0frk().SafeGet(z0oek().z0nek()));
				}
				xTextDocument.OnSelectionChanged();
				return true;
			}
		}
		return false;
	}

	internal new void z0ark()
	{
		z0mek();
	}

	internal new void z0qrk()
	{
		z0crk = null;
	}

	public new bool z0wrk()
	{
		if (z0oek().z0qrk() != 0)
		{
			using zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = z0oek().z0grk().z0ltk();
			while (z0bpk.MoveNext())
			{
				if (z0bpk.Current.z0aek().z0jyk < 0)
				{
					return true;
				}
			}
		}
		return false;
	}

	public override XTextDocument z0ee_jiejie20260327142557(bool p0)
	{
		XTextElementList p1 = z0be().z0nek();
		return z0ZzZzafh.z0yek(z0jr(), p1, p2: false);
	}

	public override void z0qu()
	{
		z0jr().z0lyk();
		z0be().Clear();
		z0be().Add(z0jr().z0uek<XTextParagraphFlagElement>());
		z0bek(p0: true);
		z0ct();
	}

	internal override bool z0zt(z0ZzZzazj p0)
	{
		z0dtk = 0;
		if (z0ZzZzdbj.z0bpk)
		{
			z0frk();
		}
		XTextContentElement.z0wtk = 0;
		bool result = base.z0zt(p0);
		zzz.z0ZzZzguk<z0ZzZzzlh>.z0iek(0);
		z0ZzZzlkh z0ZzZzlkh = z0htk;
		z0ZzZzlkh?.Clear();
		if (z0htk == null)
		{
			z0htk = new z0ZzZzlkh();
		}
		else
		{
			z0htk.Clear();
		}
		if (z0dtk > 0 && z0htk.Capacity < z0dtk)
		{
			z0htk.Capacity = z0dtk;
		}
		z0rek(this, z0htk);
		Height = base.z0cek();
		if (!(this is XTextDocumentHeaderElement))
		{
			_ = this is XTextDocumentFooterElement;
		}
		float num = Width;
		for (int num2 = base.z0zek().Length - 1; num2 >= 0; num2--)
		{
			z0ZzZzzlh z0ZzZzzlh = z0etk[num2];
			float num3 = z0ZzZzzlh.z0stk() + z0ZzZzzlh.z0nrk();
			if (num3 > num)
			{
				num = num3;
			}
		}
		if (z0iek())
		{
			float num4 = ((XTextElement)this).z0zrk();
			float num5 = ((XTextElement)this).z0ltk();
			float num6 = Height;
			XTextElement[] array = z0grk();
			for (int i = 0; i < array.Length; i++)
			{
				z0ZzZzbdh z0ZzZzbdh = array[i].z0qyk();
				if (num + num4 < z0ZzZzbdh.z0mek())
				{
					num = z0ZzZzbdh.z0mek() - num4;
				}
				if (num6 + num5 < z0ZzZzbdh.z0nek())
				{
					num6 = z0ZzZzbdh.z0nek() - num5;
				}
			}
			Height = num6;
		}
		z0brk = num;
		z0rek(z0ZzZzlkh);
		return result;
	}

	internal override void z0au(z0lgj p0)
	{
		XTextDocument xTextDocument = z0jr();
		if (xTextDocument != null)
		{
			if (p0.z0tek())
			{
				xTextDocument.z0unk().z0eek_jiejie20260327142557(p0: true);
				xTextDocument.z0euk();
			}
			else
			{
				xTextDocument.z0lyk();
			}
			z0crk = null;
			if (z0nrk == null)
			{
				z0nrk = new z0ZzZzplh(this);
			}
			else
			{
				z0nrk.Clear();
			}
			xTextDocument.z0wik();
			z0mek();
			base.z0au(p0);
			if (!p0.z0eek())
			{
				xTextDocument.z0htk()?.z0gp();
			}
			if (p0.z0tek())
			{
				xTextDocument.z0unk().z0eek_jiejie20260327142557(p0: false);
				xTextDocument.z0unk().z0eek_jiejie20260327142557();
			}
		}
	}

	private new int z0erk()
	{
		return 0;
	}

	private void z0rek(ElementZOrderStyle p0, object p1)
	{
		XTextDocumentContentElement xTextDocumentContentElement = z0qek();
		bool showPermissionMark = z0hi().ShowPermissionMark;
		bool showNewContentMarkForFirstHistory = z0hi().ShowNewContentMarkForFirstHistory;
		z0ZzZzvxj z0ZzZzvxj = ((z0ZzZzvxj)p1).z0cek();
		z0ZzZzbdh p2 = z0ZzZzvxj.z0nek();
		z0ZzZzbdh p3 = z0qyk();
		p3.z0tek(z0lu());
		p2 = z0ZzZzbdh.z0tek(p2, p3);
		XTextElement[] array = z0grk();
		foreach (XTextElement xTextElement in array)
		{
			if (xTextElement.z0ci() != p0 || !z0ZzZzvxj.z0eek(xTextElement.z0aek().z0dyk) || (z0ZzZzvxj.z0byk == (z0ZzZzcxj)3 && xTextElement is XTextObjectElement && ((XTextObjectElement)xTextElement).PrintVisibility != ElementVisibility.Visible))
			{
				continue;
			}
			z0ZzZzbdh z0ZzZzbdh = xTextElement.z0qyk();
			z0ZzZzbdh z0ZzZzbdh2 = z0ZzZzbdh;
			if (!p2.z0bek())
			{
				z0ZzZzbdh2 = z0ZzZzbdh.z0tek(p2, z0ZzZzbdh);
			}
			if (!z0ZzZzbdh2.z0bek())
			{
				if (z0ZzZzvxj.z0wyk)
				{
					z0jr().z0vek(z0ZzZzbdh);
				}
				z0ZzZzvxj.z0hyk = xTextElement;
				z0ZzZzvxj.z0luk = xTextElement.z0aek();
				z0ZzZzvxj.z0gtk = z0ZzZzbdh;
				z0ZzZzvxj.z0tek(z0ZzZzvxj.z0luk.z0eek(z0ZzZzbdh));
				if (showPermissionMark)
				{
					z0ZzZzvxj.z0yyk.z0eek(xTextElement, z0ZzZzvxj, p2: true, showNewContentMarkForFirstHistory);
				}
				xTextElement.z0tt(z0ZzZzvxj);
				if (showPermissionMark)
				{
					z0ZzZzvxj.z0yyk.z0eek(xTextElement, z0ZzZzvxj, p2: true, showNewContentMarkForFirstHistory);
				}
				if (z0ZzZzvxj.z0byk == (z0ZzZzcxj)0 && z0ZzZzvxj.z0eyk && xTextDocumentContentElement.z0rek(xTextElement))
				{
					z0jr().z0yyk().z0eek(z0ZzZzndh.z0eek(z0ZzZzbdh));
				}
			}
		}
	}

	private void z0rek(XTextContainerElement p0, XTextElementList p1)
	{
		using zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = p0.z0be().z0ltk();
		while (z0bpk.MoveNext())
		{
			XTextElement current = z0bpk.Current;
			if (!(current is XTextContainerElement))
			{
				continue;
			}
			if (current is XTextTableElement)
			{
				if (!current.z0cuk)
				{
					continue;
				}
				using zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk2 = ((XTextTableElement)current).z0stk().z0ltk();
				while (z0bpk2.MoveNext())
				{
					XTextTableRowElement xTextTableRowElement = (XTextTableRowElement)z0bpk2.Current;
					if (!xTextTableRowElement.z0cuk)
					{
						continue;
					}
					using zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk3 = xTextTableRowElement.z0rek().z0ltk();
					while (z0bpk3.MoveNext())
					{
						XTextTableCellElement xTextTableCellElement = (XTextTableCellElement)z0bpk3.Current;
						if (xTextTableCellElement.z0yi())
						{
							((zzz.z0ZzZzkuk<XTextElement>)p1).z0pek((XTextElement)xTextTableCellElement);
							z0rek(xTextTableCellElement, p1);
						}
					}
				}
			}
			else if (current is XTextContentElement)
			{
				if (current.z0cuk)
				{
					((zzz.z0ZzZzkuk<XTextElement>)p1).z0pek(current);
					z0rek((XTextContainerElement)current, p1);
				}
			}
			else if (current.z0cuk)
			{
				z0rek((XTextContainerElement)current, p1);
			}
		}
	}

	internal void z0tek(int p0)
	{
		z0dtk += p0;
	}

	public new z0ZzZzlkh z0rrk()
	{
		if (z0htk == null)
		{
			if (z0ftk != null && z0ftk.IsAlive)
			{
				z0htk = (z0ZzZzlkh)z0ftk.Target;
			}
			else
			{
				z0htk = new z0ZzZzlkh();
			}
			z0ftk = null;
			z0rek(this, z0htk);
		}
		return z0htk;
	}

	private new void z0tek(bool p0)
	{
		throw new NotSupportedException();
	}

	private new int z0trk()
	{
		return 0;
	}

	public new void z0yek(bool p0)
	{
		z0vrk = p0;
	}

	public void z0rek(bool p0, bool p1)
	{
		if (z0rik == null || (p0 && !z0stk))
		{
			return;
		}
		z0stk = false;
		z0jtk = new List<List<XTextParagraphFlagElement>>();
		if (z0zrk == null)
		{
			z0zrk = new XTextParagraphFlagElement();
		}
		else
		{
			z0zrk.z0uek().z0nek_jiejie20260327142557 = null;
		}
		z0zrk.z0tek(p0: true);
		if (z0frk().Count == 0)
		{
			return;
		}
		bool flag = false;
		foreach (DocumentContentStyle item in z0rik.z0gnk().Styles.z0xrk())
		{
			z0ZzZzrzj z0ZzZzrzj = item.z0eek_jiejie20260327142557();
			if (z0ZzZzrzj.z0ttk >= 0 || z0ZzZzrzj.z0brk != ParagraphListStyle.None)
			{
				flag = true;
				break;
			}
		}
		if (!flag)
		{
			return;
		}
		zzz.z0ZzZzsuk<XTextParagraphFlagElement> z0ZzZzsuk = new zzz.z0ZzZzsuk<XTextParagraphFlagElement>();
		z0ZzZzsuk.z0eek(z0zrk);
		XTextParagraphFlagElement xTextParagraphFlagElement = null;
		foreach (XTextElement item2 in z0frk().z0xrk())
		{
			if (!(item2 is XTextParagraphFlagElement))
			{
				continue;
			}
			XTextParagraphFlagElement xTextParagraphFlagElement2 = (XTextParagraphFlagElement)item2;
			if (xTextParagraphFlagElement2.z0grk != null)
			{
				xTextParagraphFlagElement2.z0grk.z0tek = null;
			}
			ParagraphListStyle paragraphListStyle = xTextParagraphFlagElement2.z0yek();
			if (xTextParagraphFlagElement2.z0tek() >= 0)
			{
				xTextParagraphFlagElement2.z0uek(0);
				if (xTextParagraphFlagElement2.z0grk != null)
				{
					xTextParagraphFlagElement2.z0grk.z0tek = null;
					xTextParagraphFlagElement2.z0grk.z0yek = 0;
					xTextParagraphFlagElement2.z0grk.z0nek_jiejie20260327142557?.Clear();
				}
				if (z0ZzZzsuk.z0uek() == 1)
				{
					z0ZzZzsuk.z0rek().z0eek(xTextParagraphFlagElement2);
				}
				else
				{
					while (z0ZzZzsuk.z0uek() > 0)
					{
						XTextParagraphFlagElement xTextParagraphFlagElement3 = z0ZzZzsuk.z0rek();
						if (z0ZzZzsuk.z0uek() == 1 || xTextParagraphFlagElement3.z0tek() < xTextParagraphFlagElement2.z0tek())
						{
							xTextParagraphFlagElement3.z0eek(xTextParagraphFlagElement2);
							break;
						}
						if (z0ZzZzsuk.z0uek() == 1)
						{
							break;
						}
						z0ZzZzsuk.z0tek();
					}
				}
				z0ZzZzsuk.z0eek(xTextParagraphFlagElement2);
			}
			if (xTextParagraphFlagElement2.z0rek() == null && paragraphListStyle != ParagraphListStyle.None)
			{
				List<XTextParagraphFlagElement> list = null;
				if (!xTextParagraphFlagElement2.z0jrk())
				{
					if (z0jtk.Count > 0)
					{
						list = z0jtk[z0jtk.Count - 1];
					}
					if (xTextParagraphFlagElement != null && (xTextParagraphFlagElement.z0rek() != null || xTextParagraphFlagElement.z0yek() != xTextParagraphFlagElement2.z0yek()))
					{
						list = null;
					}
				}
				if (list == null)
				{
					list = new List<XTextParagraphFlagElement>();
					z0jtk.Add(list);
				}
				list.Add(xTextParagraphFlagElement2);
			}
			xTextParagraphFlagElement = xTextParagraphFlagElement2;
		}
		z0ZzZzsuk.z0yek();
		z0ZzZzsuk = null;
		if (!p1)
		{
			return;
		}
		z0rek(z0zrk);
		foreach (List<XTextParagraphFlagElement> item3 in z0jtk)
		{
			for (int i = 0; i < item3.Count; i++)
			{
				XTextParagraphFlagElement xTextParagraphFlagElement4 = item3[i];
				xTextParagraphFlagElement4.z0uek(i + 1);
				xTextParagraphFlagElement4.z0rek(item3.Count);
			}
		}
	}

	private void z0rek(XTextParagraphFlagElement p0)
	{
		int num = 1;
		ParagraphListStyle paragraphListStyle = ParagraphListStyle.None;
		List<XTextParagraphFlagElement> list = new List<XTextParagraphFlagElement>();
		List<XTextParagraphFlagElement> list2 = p0.z0bek();
		if (list2 != null && list2.Count > 0)
		{
			foreach (XTextParagraphFlagElement item in p0.z0bek())
			{
				item.z0uek().z0tek = p0;
				if (z0ZzZzlmk.z0tek(item.z0yek()))
				{
					if (num == 0)
					{
						paragraphListStyle = item.z0yek();
					}
					if (item.z0yek() != paragraphListStyle || item.z0jrk())
					{
						num = 0;
						if (list.Count > 0)
						{
							foreach (XTextParagraphFlagElement item2 in list)
							{
								item2.z0rek(list.Count);
							}
						}
						list.Clear();
					}
					list.Add(item);
					paragraphListStyle = item.z0yek();
					item.z0uek(num + 1);
					num++;
				}
				if (item.z0nek())
				{
					z0rek(item);
				}
			}
		}
		if (list.Count > 0)
		{
			foreach (XTextParagraphFlagElement item3 in list)
			{
				item3.z0rek(list.Count + 1);
			}
		}
		list.Clear();
		list = null;
	}

	internal new int z0yrk()
	{
		if (z0nrk == null)
		{
			return -1;
		}
		return z0nrk.z0mek();
	}

	public override XTextDocumentContentElement z0qek()
	{
		return this;
	}

	public new bool z0urk()
	{
		if (z0ktk != null)
		{
			return z0oek().z0qrk() != 0;
		}
		return false;
	}

	public override float z0lu()
	{
		return z0brk;
	}

	public void z0eek(List<List<XTextParagraphFlagElement>> p0)
	{
		z0jtk = p0;
	}

	internal XTextElement z0rek(float p0, float p1, ElementZOrderStyle p2)
	{
		if (z0iek())
		{
			XTextElement[] array = z0grk();
			foreach (XTextElement xTextElement in array)
			{
				if (xTextElement.z0ci() == p2 && xTextElement.z0qyk().z0eek(p0, p1))
				{
					return xTextElement;
				}
			}
		}
		return null;
	}

	internal new void z0irk()
	{
		z0oek().z0ark();
	}

	public virtual PageContentPartyStyle z0du()
	{
		return PageContentPartyStyle.Body;
	}

	internal new void z0ork()
	{
		XTextDocument xTextDocument = z0jr();
		if (xTextDocument != null)
		{
			z0xrk = false;
			xTextDocument.z0gnk().z0oek();
			Width = xTextDocument.PageSettings.z0prk();
			base.z0grk();
			z0utk?.z0drk();
			z0ZzZzazj z0ZzZzazj = new z0ZzZzazj(null, null, z0cr());
			z0ZzZzazj.z0bek = true;
			z0ZzZzazj.z0xek = false;
			z0zt(z0ZzZzazj);
			z0ZzZzazj.z0tek();
			XTextContentElement.z0dtk?.z0ktk();
			zzz.z0ZzZzgik<z0ZzZzzlh[]>.z0iek.z0eek(null);
		}
	}
}
