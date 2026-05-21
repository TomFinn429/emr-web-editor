using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;
using zzz;

namespace DCSoft.Writer.Dom;

[DebuggerTypeProxy(typeof(z0ZzZzkik))]
[DebuggerDisplay("Count={Count}")]
public class XTextElementList : zzz.z0ZzZzkuk<XTextElement>, ICloneable
{
	internal new static readonly XTextElementList z0ark = new XTextElementList();

	[ThreadStatic]
	internal new static bool z0qrk = false;

	[NonSerialized]
	protected new short z0wrk = 2;

	internal XTextParagraphFlagElement z0oek(XTextElement p0)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("element");
		}
		int i = z0bek(p0);
		if (i >= 0)
		{
			for (int count = base.Count; i < count; i++)
			{
				if (base[i] is XTextParagraphFlagElement)
				{
					return (XTextParagraphFlagElement)base[i];
				}
			}
		}
		return null;
	}

	private void z0oek(XTextElementList p0, XTextElementList p1, Type p2)
	{
		bool flag = p2.Equals(typeof(XTextCharElement));
		using z0bpk z0bpk = p0.z0ltk();
		while (z0bpk.MoveNext())
		{
			XTextElement current = z0bpk.Current;
			if (flag || !(current is XTextCharElement))
			{
				if (p2.IsInstanceOfType(current))
				{
					p1.Add(current);
				}
				if (current is XTextContainerElement)
				{
					z0oek(current.z0be(), p1, p2);
				}
			}
		}
	}

	public new XTextElement z0pek(XTextElement p0)
	{
		int num = z0bek(p0);
		if (num > 0)
		{
			return base[num - 1];
		}
		return null;
	}

	private object z0oek()
	{
		XTextElementList xTextElementList = null;
		xTextElementList = ((this is z0ZzZzzlh) ? new z0ZzZzzlh() : ((!(this is z0ZzZzplh)) ? new XTextElementList() : new z0ZzZzplh(null)));
		((zzz.z0ZzZzkuk<XTextElement>)xTextElementList).z0tek((zzz.z0ZzZzkuk<XTextElement>)this);
		return xTextElementList;
	}

	object ICloneable.Clone()
	{
		//ILSpy generated this explicit interface implementation from .override directive in z0oek
		return this.z0oek();
	}

	internal XTextParagraphFlagElement z0oek(int p0)
	{
		return z0vek<XTextParagraphFlagElement>(p0);
	}

	public new int z0mek(XTextElement p0)
	{
		for (int num = z0wtk - 1; num >= 0; num--)
		{
			if (z0atk[num] == p0)
			{
				return num;
			}
		}
		return -1;
	}

	protected bool z0pek(int p0)
	{
		return (z0wrk & p0) != 0;
	}

	public XTextElementList z0oek(int p0, int p1)
	{
		if (p1 < 0)
		{
			p1 = 0;
		}
		if (p0 < 0)
		{
			p0 = 0;
		}
		if (p0 >= base.Count)
		{
			p0 = base.Count - 1;
		}
		int num = p0 + p1 - 1;
		if (num >= base.Count)
		{
			num = base.Count - 1;
		}
		XTextElementList xTextElementList = new XTextElementList();
		for (int i = p0; i <= num; i++)
		{
			xTextElementList.Add(base[i]);
		}
		return xTextElementList;
	}

	internal bool z0nek(XTextElement p0)
	{
		if (SafeGet(p0.z0xuk) == p0)
		{
			return true;
		}
		for (int num = z0wtk - 1; num >= 0; num--)
		{
			if (z0atk[num] == p0)
			{
				return true;
			}
		}
		return false;
	}

	public int z0bek(XTextElement p0)
	{
		if (p0 == null)
		{
			return -1;
		}
		if (SafeGet(p0.z0tuk) == p0)
		{
			return p0.z0tuk;
		}
		if (SafeGet(p0.z0muk) == p0)
		{
			return p0.z0muk;
		}
		if (SafeGet(p0.z0xuk) == p0)
		{
			return p0.z0xuk;
		}
		return base.z0cek(p0);
	}

	public XTextElementList z0pek(int p0, int p1)
	{
		if (p0 < 0)
		{
			throw new ArgumentException("startIndex=" + p0);
		}
		XTextElementList xTextElementList = new XTextElementList();
		int num = Math.Min(base.Count - 1, p0 + p1 - 1);
		for (int i = p0; i <= num; i++)
		{
			xTextElementList.Add(base[i]);
		}
		return xTextElementList;
	}

	internal void z0oek(bool p0)
	{
	}

	public void z0eek(int p0, IEnumerable<XTextElement> p1)
	{
		z0frk(p0, p1);
	}

	internal int z0vek(XTextElement p0)
	{
		if (SafeGet(p0.z0xuk) == p0)
		{
			return p0.z0xuk;
		}
		return IndexOf(p0);
	}

	public void z0rek<ElementType>(Action<ElementType> p0) where ElementType : XTextElement
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("handler");
		}
		XTextElement[] array = base.z0krk();
		int count = base.Count;
		for (int i = 0; i < count; i++)
		{
			if (array[i] is ElementType)
			{
				p0((ElementType)array[i]);
			}
			if (array[i] is XTextContainerElement xTextContainerElement && xTextContainerElement.z0crk())
			{
				xTextContainerElement.z0be().z0rek(p0);
			}
		}
	}

	public XTextElementList z0mek(int p0, int p1)
	{
		if (p1 == 0)
		{
			return new XTextElementList();
		}
		zzz.z0ZzZzkuk<XTextElement> z0ZzZzkuk = z0yrk(p0, p1);
		XTextElementList xTextElementList = new XTextElementList(z0ZzZzkuk.Count);
		((zzz.z0ZzZzkuk<XTextElement>)xTextElementList).z0tek(z0ZzZzkuk);
		return xTextElementList;
	}

	internal void z0tek(IEnumerable<XTextElement> p0)
	{
		AddRange(p0);
	}

	public XTextElementList z0pek()
	{
		XTextElementList xTextElementList = null;
		xTextElementList = ((this is z0ZzZzzlh) ? new z0ZzZzzlh() : ((this is z0ZzZzplh) ? new z0ZzZzplh(null) : ((this == null) ? ((XTextElementList)Activator.CreateInstance(GetType())) : new XTextElementList())));
		z0nek(xTextElementList);
		return xTextElementList;
	}

	public void z0yek(int p0, IEnumerable<XTextElement> p1)
	{
		z0frk(p0, p1);
		z0nek(p0: false);
		z0srk();
	}

	internal int z0oek(XTextElement p0, int p1)
	{
		if (p1 >= 0 && p1 < z0wtk && z0atk[p1] == p0)
		{
			return p1;
		}
		return IndexOf(p0);
	}

	internal bool z0mek()
	{
		if (z0wtk == 1)
		{
			return z0atk[0] is XTextParagraphFlagElement;
		}
		return false;
	}

	internal XTextElement[] z0mek(int p0)
	{
		if (p0 >= base.Count)
		{
			return null;
		}
		XTextElement[] array = new XTextElement[base.Count - p0];
		int count = base.Count;
		for (int i = p0; i < count; i++)
		{
			array[i - p0] = base[i];
		}
		return array;
	}

	internal void z0oek(ElementEnumerateEventHandler p0, bool p1, bool p2)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("handler");
		}
		ElementEnumerateEventArgs p3 = new ElementEnumerateEventArgs();
		z0oek(p0, p3, p1, p2);
	}

	internal void z0oek(XTextElementList p0, XTextContainerElement p1, XTextDocument p2)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("newList");
		}
		int count = base.Count;
		if (count == 0)
		{
			p0.Clear();
			return;
		}
		XTextElement[] array = base.z0krk();
		XTextElement[] array2 = new XTextElement[count];
		for (int num = count - 1; num >= 0; num--)
		{
			XTextElement xTextElement = array[num].z0lr(p0: true);
			xTextElement.z0yek(p2, p1);
			array2[num] = xTextElement;
		}
		p0.z0zek(array2);
	}

	public XTextElementList z0nek()
	{
		XTextElementList xTextElementList = new XTextElementList();
		using z0bpk z0bpk = z0ltk();
		while (z0bpk.MoveNext())
		{
			XTextElement current = z0bpk.Current;
			xTextElementList.Add(current.z0lr(p0: true));
		}
		return xTextElementList;
	}

	public bool z0bek()
	{
		return z0pek(2);
	}

	public bool z0pek(XTextElement p0, int p1)
	{
		if (p1 >= 0 && p1 < z0wtk)
		{
			return z0atk[p1] == p0;
		}
		return false;
	}

	internal bool z0vek()
	{
		return z0pek(1);
	}

	public XTextElementList(XTextElement element)
		: base(new XTextElement[1] { element }, p1: true)
	{
		if (element == null)
		{
			throw new ArgumentNullException("element");
		}
	}

	public bool z0cek()
	{
		if (base.Count > 0)
		{
			XTextElement xTextElement = base[base.Count - 1];
			if (xTextElement is XTextParagraphFlagElement)
			{
				return true;
			}
			if (z0ZzZzjzj.z0tek(xTextElement))
			{
				return true;
			}
		}
		return false;
	}

	public void z0oek(XTextElement p0, XTextElementList p1)
	{
		int num = IndexOf(p0);
		if (num < 0)
		{
			return;
		}
		using (z0bpk z0bpk = p1.z0ltk())
		{
			while (z0bpk.MoveNext())
			{
				_ = z0bpk.Current;
			}
		}
		z0yek(num, p1);
	}

	internal bool z0xek()
	{
		if (z0wtk > 0)
		{
			return z0atk[z0wtk - 1] is XTextParagraphFlagElement;
		}
		return false;
	}

	public XTextElementList()
	{
	}

	public int z0nek(int p0)
	{
		if (p0 <= 0)
		{
			return 0;
		}
		if (p0 >= base.Count)
		{
			return base.Count - 1;
		}
		return p0;
	}

	internal void z0pek(bool p0)
	{
		z0oek(1, p0);
	}

	public new void Insert(int index, XTextElement element)
	{
		base.Insert(index, element);
		if (element is XTextStringElement)
		{
			z0nek(p0: false);
		}
		z0srk();
	}

	internal XTextParagraphFlagElement z0zek()
	{
		return base.z0grk() as XTextParagraphFlagElement;
	}

	public XTextElement z0mek(XTextElement p0, int p1)
	{
		int num = z0bek(p0);
		if (num < 0)
		{
			return null;
		}
		num += p1;
		if (num >= 0 && num < base.Count)
		{
			return base[num];
		}
		return null;
	}

	private void z0oek(ElementEnumerateEventHandler p0, ElementEnumerateEventArgs p1, bool p2, bool p3)
	{
		if (p1.ReverseMode)
		{
			for (int num = base.Count - 1; num >= 0; num--)
			{
				XTextElement xTextElement = base[num];
				if (p3 || (!(xTextElement is XTextCharElement) && !(xTextElement is XTextParagraphFlagElement)))
				{
					p1.z0pek = xTextElement;
					p1.CancelChild = false;
					p0(null, p1);
					p1.z0eek();
					if (p1.Cancel)
					{
						break;
					}
					if (!p1.CancelChild && p2 && xTextElement is XTextContainerElement)
					{
						XTextElementList xTextElementList = xTextElement.z0be();
						if (xTextElementList != null && xTextElementList.Count > 0)
						{
							xTextElementList.z0oek(p0, p1, p2, p3);
							if (p1.Cancel)
							{
								break;
							}
						}
					}
					p1.CancelChild = false;
				}
			}
			return;
		}
		int count = base.Count;
		for (int i = 0; i < count; i++)
		{
			XTextElement xTextElement2 = base[i];
			if (!p3 && (xTextElement2 is XTextCharElement || xTextElement2 is XTextParagraphFlagElement))
			{
				continue;
			}
			p1.z0pek = xTextElement2;
			p1.CancelChild = false;
			p0(null, p1);
			p1.z0eek();
			if (p1.Cancel)
			{
				break;
			}
			if (!p1.CancelChild && p2 && xTextElement2 is XTextContainerElement)
			{
				XTextElementList xTextElementList2 = xTextElement2.z0be();
				if (xTextElementList2 != null && xTextElementList2.Count > 0)
				{
					xTextElementList2.z0oek(p0, p1, p2, p3);
					if (p1.Cancel)
					{
						break;
					}
				}
			}
			p1.CancelChild = false;
		}
	}

	private void z0pek(XTextElementList p0, XTextElementList p1, Type p2)
	{
		if (p0 == null)
		{
			return;
		}
		int count = p0.Count;
		for (int i = 0; i < count; i++)
		{
			XTextElement xTextElement = p0.z0yek(i);
			if (!(xTextElement is XTextCharElement) && !(xTextElement is XTextParagraphFlagElement))
			{
				if (p2.IsInstanceOfType(xTextElement))
				{
					p1.Add(xTextElement);
				}
				if (xTextElement is XTextContainerElement)
				{
					z0pek(xTextElement.z0be(), p1, p2);
				}
			}
		}
	}

	public XTextElement z0lrk()
	{
		for (int num = base.Count - 1; num >= 0; num--)
		{
			XTextElement xTextElement = base[num].z0dek();
			if (xTextElement != null)
			{
				return xTextElement;
			}
		}
		return null;
	}

	public bool z0nek(int p0, int p1)
	{
		if (p0 == p1)
		{
			return false;
		}
		XTextElement element = base[p0];
		RemoveAt(p0);
		Insert(p1, element);
		return true;
	}

	public new XTextElement z0krk()
	{
		if (base.Count > 0)
		{
			return base[0];
		}
		return null;
	}

	public bool z0oek(XTextElement p0, XTextElement p1)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("未指定元素");
		}
		if (p1 == null)
		{
			throw new ArgumentNullException("未指定新元素");
		}
		int num = IndexOf(p0);
		if (num >= 0)
		{
			Insert(num, p1);
			return true;
		}
		return false;
	}

	internal void z0oek(int p0, XTextElement p1)
	{
		base.Insert(p0, p1);
	}

	internal void z0uek<ArgType>(ArgType p0, Func<XTextElement, ArgType, bool> p1)
	{
		if (p1 == null)
		{
			throw new ArgumentNullException("handler");
		}
		if (base.Count != 0)
		{
			z0iek(this, p0, p1);
		}
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder();
		using (z0bpk z0bpk = z0ltk())
		{
			while (z0bpk.MoveNext())
			{
				XTextElement current = z0bpk.Current;
				stringBuilder.Append(current.ToString());
			}
		}
		return stringBuilder.ToString();
	}

	public XTextElementList(int capacity)
		: base(capacity)
	{
	}

	public new void z0cek(XTextElement p0)
	{
		Remove(p0);
		z0srk();
	}

	internal static bool z0jrk()
	{
		return z0qrk;
	}

	public string z0hrk()
	{
		if (base.Count == 0)
		{
			return string.Empty;
		}
		XTextElement.z0ygj z0ygj = new XTextElement.z0ygj(base[0].z0jr());
		using (z0bpk z0bpk = z0ltk())
		{
			while (z0bpk.MoveNext())
			{
				z0bpk.Current.z0bw_jiejie20260327142557(z0ygj);
			}
		}
		return z0ygj.ToString();
	}

	public bool z0pek(XTextElement p0, XTextElement p1)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("未指定元素");
		}
		if (p1 == null)
		{
			throw new ArgumentNullException("未指定新元素");
		}
		int num = IndexOf(p0);
		if (num >= 0)
		{
			Insert(num + 1, p1);
			return true;
		}
		return false;
	}

	public XTextElement z0oek(Type p0)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("t");
		}
		using (z0bpk z0bpk = z0ltk())
		{
			while (z0bpk.MoveNext())
			{
				XTextElement current = z0bpk.Current;
				if (p0.IsInstanceOfType(current))
				{
					return current;
				}
			}
		}
		return null;
	}

	public new XTextElement z0xek(XTextElement p0)
	{
		int z0muk = p0.z0muk;
		if (z0muk >= 0 && z0muk < base.Count && base[z0muk] == p0)
		{
			if (z0muk < base.Count - 1)
			{
				return base[z0muk + 1];
			}
			return null;
		}
		int num = z0bek(p0);
		if (num >= 0 && num < base.Count - 1)
		{
			return base[num + 1];
		}
		return null;
	}

	public void z0oek(XTextElementList p0)
	{
		if (p0 == null || p0.Count <= 0)
		{
			return;
		}
		bool flag = false;
		int num = IndexOf(p0[0]);
		int num2 = IndexOf(p0.LastElement);
		if (num < 0 || num2 < 0)
		{
			return;
		}
		if (num2 - num + 1 == p0.Count)
		{
			flag = true;
			int num3 = num;
			using z0bpk z0bpk = p0.z0ltk();
			while (z0bpk.MoveNext())
			{
				if (z0bpk.Current != base[num3])
				{
					flag = false;
					break;
				}
				num3++;
			}
		}
		if (flag)
		{
			z0irk(num, p0.Count);
		}
		else
		{
			for (int num4 = p0.Count - 1; num4 >= 0; num4--)
			{
				z0cek(p0[num4]);
			}
		}
		z0srk();
	}

	internal void z0bek(int p0)
	{
		RemoveAt(p0);
	}

	internal static void z0mek(bool p0)
	{
		z0qrk = p0;
	}

	public bool z0zek(XTextElement p0)
	{
		if (p0 == null)
		{
			return false;
		}
		if (SafeGet(p0.z0xuk) == p0)
		{
			return true;
		}
		if (SafeGet(p0.z0tuk) == p0)
		{
			return true;
		}
		if (SafeGet(p0.z0muk) == p0)
		{
			return true;
		}
		for (int num = z0wtk - 1; num >= 0; num--)
		{
			if (z0atk[num] == p0)
			{
				return true;
			}
		}
		return false;
	}

	public new XTextElement z0grk()
	{
		using (z0bpk z0bpk = z0ltk())
		{
			while (z0bpk.MoveNext())
			{
				XTextElement current = z0bpk.Current;
				if (current is XTextTableElement)
				{
					XTextTableElement xTextTableElement = (XTextTableElement)current;
					if (xTextTableElement.z0zrk() != null)
					{
						return xTextTableElement.z0zrk().z0ie();
					}
				}
				else
				{
					if (current is XTextSectionElement)
					{
						return ((XTextSectionElement)current).z0be().z0grk();
					}
					if (current is XTextParagraphFlagElement || current is XTextCharElement)
					{
						return current;
					}
				}
				XTextElement xTextElement = current.z0ie();
				if (xTextElement != null)
				{
					return xTextElement;
				}
			}
		}
		return null;
	}

	public void z0oek(XTextElement[] p0)
	{
		if (p0 != null && p0.Length != 0)
		{
			AddRange(p0);
			z0srk();
		}
	}

	internal void z0frk()
	{
		z0nrk();
		z0pek(p0: true);
	}

	public void z0drk()
	{
		XTextElement[] array = base.z0krk();
		for (int num = base.Count - 1; num >= 0; num--)
		{
			array[num].z0kik = null;
		}
	}

	public override bool Contains(XTextElement item)
	{
		if (item == null)
		{
			return false;
		}
		for (int num = z0wtk - 1; num >= 0; num--)
		{
			if (z0atk[num] == item)
			{
				return true;
			}
		}
		return false;
	}

	internal int z0lrk(XTextElement p0)
	{
		if (SafeGet(p0.z0tuk) == p0)
		{
			return p0.z0tuk;
		}
		return IndexOf(p0);
	}

	protected void z0oek(int p0, bool p1)
	{
		if (p1)
		{
			z0wrk = (short)(z0wrk | p0);
		}
		else
		{
			z0wrk = (short)(z0wrk & ~p0);
		}
	}

	public new void Add(XTextElement element)
	{
		if (z0qrk)
		{
			base.Add(element);
			return;
		}
		base.Add(element);
		if (element is XTextStringElement || element is XTextTextElement)
		{
			z0nek(p0: false);
		}
		z0srk();
	}

	public void z0nek(bool p0)
	{
		z0oek(2, p0);
	}

	internal void z0krk(XTextElement p0)
	{
		Remove(p0);
	}

	public void z0jrk(XTextElement p0)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("element");
		}
		Type type = p0.GetType();
		for (int num = base.Count - 1; num >= 0; num--)
		{
			if (base[num].GetType() == type)
			{
				base[num] = p0;
				return;
			}
		}
		Add(p0);
	}

	public void z0hrk(XTextElement p0)
	{
		base.Add(p0);
	}

	internal int z0grk(XTextElement p0)
	{
		if (SafeGet(p0.z0xuk) == p0)
		{
			return p0.z0xuk;
		}
		if (SafeGet(p0.z0tuk) == p0)
		{
			return p0.z0tuk;
		}
		if (SafeGet(p0.z0muk) == p0)
		{
			return p0.z0muk;
		}
		return base.z0cek(p0);
	}

	public void z0oek(z0ZzZzvxj p0)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("args");
		}
		int count = base.Count;
		XTextElement[] array = base.z0krk();
		for (int i = 0; i < count; i++)
		{
			array[i].z0mr(p0);
		}
	}

	private void z0srk()
	{
	}

	internal virtual void z0vek(int p0)
	{
		if (p0 < base.Count)
		{
			z0irk(p0, base.Count - p0);
		}
	}

	public XTextElementList z0pek(Type p0)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("elementType");
		}
		if (!typeof(XTextElement).IsAssignableFrom(p0))
		{
			throw new InvalidCastException(p0.FullName);
		}
		XTextElementList xTextElementList = new XTextElementList();
		if (p0 == typeof(XTextCharElement) || p0 == typeof(XTextParagraphFlagElement))
		{
			z0oek(this, xTextElementList, p0);
		}
		else
		{
			z0pek(this, xTextElementList, p0);
		}
		return xTextElementList;
	}

	[CompilerGenerated]
	internal static void z0iek<ArgType>(XTextElementList p0, ArgType p1, Func<XTextElement, ArgType, bool> p2)
	{
		XTextElement[] array = ((zzz.z0ZzZzkuk<XTextElement>)p0).z0krk();
		int count = p0.Count;
		for (int i = 0; i < count; i++)
		{
			XTextElement xTextElement = array[i];
			if (!(xTextElement is XTextCharElement) && !(xTextElement is XTextParagraphFlagElement))
			{
				if (!p2(xTextElement, p1))
				{
					break;
				}
				if (xTextElement is XTextContainerElement xTextContainerElement && xTextContainerElement.z0crk())
				{
					z0iek(xTextContainerElement.z0be(), p1, p2);
				}
			}
		}
	}

	internal static bool z0pek(XTextElementList p0)
	{
		if (p0 == null || p0.Count == 0)
		{
			return false;
		}
		if (p0.Count == 1 && p0[0] is XTextParagraphFlagElement && ((XTextParagraphFlagElement)p0[0]).z0buk == -1)
		{
			return false;
		}
		return true;
	}

	public bool z0pek(int p0, XTextElement p1)
	{
		if (p0 >= 0 && p0 < z0wtk)
		{
			return z0atk[p0] == p1;
		}
		return false;
	}

	internal bool z0bek(bool p0)
	{
		if (base.Count > 0)
		{
			XTextElement lastElement = base.LastElement;
			if (lastElement is XTextParagraphFlagElement)
			{
				return true;
			}
			if (z0ZzZzjzj.z0tek(lastElement))
			{
				return true;
			}
			if (p0)
			{
				lastElement = base[0];
				if (lastElement is XTextParagraphFlagElement)
				{
					return true;
				}
				if (z0ZzZzjzj.z0tek(lastElement))
				{
					return true;
				}
			}
		}
		return false;
	}

	internal XTextElementList(XTextElement[] items, bool a)
		: base(items, a)
	{
	}
}
