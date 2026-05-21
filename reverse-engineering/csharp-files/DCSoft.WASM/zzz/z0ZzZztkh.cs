using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using DCSoft.Common;
using DCSoft.WASM;
using DCSoft.Writer;
using DCSoft.Writer.Dom;
using DCSystem_Drawing;

namespace zzz;

internal class z0ZzZztkh : z0ZzZzpkh, IDisposable
{
	internal class z0bmk
	{
		internal class z0vmk
		{
			public PropertyInfo z0eek;

			public object z0rek;

			public object z0tek;

			public MemberEffectLevel z0yek;

			public object z0uek;
		}

		private List<z0vmk> z0yek = new List<z0vmk>();

		public bool z0uek;

		public void z0eek()
		{
			foreach (z0vmk item in z0yek)
			{
				item.z0eek.SetValue(item.z0tek, item.z0rek, null);
			}
		}

		public bool z0rek()
		{
			return z0yek.Count > 0;
		}

		public z0bmk()
		{
		}

		public z0bmk(bool p0)
		{
			z0uek = p0;
		}

		public void z0tek()
		{
			if (z0yek == null)
			{
				return;
			}
			foreach (z0vmk item in z0yek)
			{
				item.z0eek = null;
				item.z0rek = null;
				item.z0uek = null;
				item.z0tek = null;
			}
			z0yek.Clear();
			z0yek = null;
		}

		public void z0eek(MemberEffectLevel p0, object p1, PropertyInfo p2, object p3, object p4)
		{
			z0vmk z0vmk = new z0vmk();
			z0vmk.z0yek = p0;
			z0vmk.z0eek = p2;
			z0vmk.z0tek = p1;
			z0vmk.z0rek = p3;
			z0vmk.z0uek = p4;
			z0yek.Add(z0vmk);
		}
	}

	private enum z0vpk
	{
		z0eek,
		z0rek
	}

	private Dictionary<string, string[]> z0pek;

	private z0ZzZzbkh z0mek;

	private XTextDocument z0nek;

	private static readonly Dictionary<Type, Dictionary<string, PropertyInfo>> z0bek = new Dictionary<Type, Dictionary<string, PropertyInfo>>();

	private bool z0vek;

	private bool z0cek = true;

	[NonSerialized]
	private Dictionary<string, XTextElement> z0xek;

	[NonSerialized]
	private Dictionary<string, XTextElement> z0zek;

	private static object[] z0lrk = null;

	public List<string> z0krk;

	private List<XTextElement> z0jrk;

	private static object[] z0hrk = null;

	private bool z0grk;

	private Dictionary<string, XTextElementList> z0frk;

	private Dictionary<string, object> z0drk;

	private z0vpk z0srk;

	private Stack<z0ZzZznkh> z0ark = new Stack<z0ZzZznkh>();

	private bool[] z0qrk;

	internal z0ZzZzbkh z0tek()
	{
		if (z0mek == null)
		{
			z0mek = new z0ZzZzbkh();
		}
		return z0mek;
	}

	internal XTextElement z0tek(string p0)
	{
		if (p0 == null || p0.Length == 0)
		{
			return null;
		}
		if (z0zek == null)
		{
			return z0nek.z0cek(p0, p1: true);
		}
		XTextElement xTextElement = null;
		if (!z0zek.TryGetValue(p0, out xTextElement))
		{
			xTextElement = z0nek.z0cek(p0, p1: true);
			z0zek[p0] = xTextElement;
		}
		return xTextElement;
	}

	internal void z0tek(z0ZzZzbkh p0)
	{
		z0mek = p0;
	}

	public bool z0yek()
	{
		if (!XTextDocument.z0wbk)
		{
			return z0cek;
		}
		return true;
	}

	public void z0mw_jiejie20260327142557(XTextElement p0, ElementLoadEventArgs p1 = null)
	{
		foreach (z0ZzZznkh item in z0tek())
		{
			if (item.z0tek() == p0)
			{
				z0tek().Remove(item);
				break;
			}
		}
		if (z0mek == null)
		{
			z0mek = new z0ZzZzbkh();
		}
		bool p2 = p1?.z0yek ?? z0ZzZzccj.z0rek(127);
		bool p3 = p1?.z0uek ?? z0ZzZzccj.z0rek(126);
		z0tek(p0, p2, p3, p3: false);
	}

	internal XTextElement z0yek(string p0)
	{
		if (p0 == null || p0.Length == 0)
		{
			return null;
		}
		if (z0xek == null)
		{
			return z0nek.z0cek(p0, p1: false);
		}
		XTextElement xTextElement = null;
		if (!z0xek.TryGetValue(p0, out xTextElement))
		{
			xTextElement = z0nek.z0cek(p0, p1: false);
			z0xek[p0] = xTextElement;
		}
		return xTextElement;
	}

	public void z0pw()
	{
		z0mek = new z0ZzZzbkh();
		bool p = z0ZzZzxcj.z0eek(127);
		bool p2 = z0ZzZzxcj.z0eek(126);
		z0tek(z0aw(), p, p2, p3: true);
	}

	private void z0eek(XTextContainerElement p0, Dictionary<string, object> p1, bool p2)
	{
		p0.z0kr();
		IList<XTextElement> z0ytk = p0.z0ytk;
		if (z0ytk != null && z0ytk.Count > 0)
		{
			int count = z0ytk.Count;
			for (int i = 0; i < count; i++)
			{
				XTextElement xTextElement = z0ytk[i];
				if (xTextElement is XTextContainerElement { ID: var iD } xTextContainerElement)
				{
					if (iD != null && iD.Length > 0)
					{
						z0rek(p1, iD, xTextElement);
					}
					if (xTextContainerElement is XTextInputFieldElementBase xTextInputFieldElementBase)
					{
						string text = ((!string.IsNullOrEmpty(xTextInputFieldElementBase.ID)) ? xTextInputFieldElementBase.ID : xTextInputFieldElementBase.Name);
						if (text != null && text.Length > 0)
						{
							z0rek(p1, text, xTextInputFieldElementBase);
						}
					}
					z0eek(xTextContainerElement, p1, p2: false);
				}
				else if (xTextElement is XTextCheckBoxElementBase { ID: var iD2 } xTextCheckBoxElementBase)
				{
					if (iD2 != null && iD2.Length > 0)
					{
						z0rek(p1, iD2, xTextElement);
					}
					string name = xTextCheckBoxElementBase.Name;
					if (name != null && name.Length > 0)
					{
						z0rek(p1, name, xTextCheckBoxElementBase);
					}
				}
			}
		}
		if (!p2)
		{
			return;
		}
		foreach (string key in p1.Keys)
		{
			if (p1[key] is zzz.z0ZzZzkuk<XTextElement> z0ZzZzkuk2)
			{
				p1[key] = z0ZzZzkuk2.ToArray();
				z0ZzZzkuk2.Clear();
			}
		}
	}

	public bool z0uek(string p0)
	{
		if (z0drk == null)
		{
			z0drk = new Dictionary<string, object>();
			z0eek(z0nek, z0drk, p2: true);
		}
		return z0drk.ContainsKey(p0);
	}

	public void z0ow(XTextDocument p0)
	{
		if (z0nek != p0)
		{
			z0nek = p0;
			if (z0nek != null && z0nek.z0vtk() != null)
			{
				z0cek = z0nek.z0vtk().BehaviorOptions.DebugMode;
			}
		}
	}

	internal XTextElementList z0iek(string p0)
	{
		if (z0nek != null)
		{
			if (z0drk == null)
			{
				z0drk = new Dictionary<string, object>();
				z0eek(z0nek, z0drk, p2: true);
			}
			object obj = null;
			if (z0drk.TryGetValue(p0, out obj))
			{
				if (obj is XTextElement)
				{
					return new XTextElementList((XTextElement)obj);
				}
				if (obj is XTextElementList)
				{
					return (XTextElementList)obj;
				}
				if (obj is XTextElement[])
				{
					XTextElement[] p1 = obj as XTextElement[];
					XTextElementList xTextElementList = new XTextElementList();
					xTextElementList.z0oek(p1);
					return xTextElementList;
				}
				return (XTextElementList)obj;
			}
		}
		return null;
	}

	private void z0uek()
	{
		if (!z0vek)
		{
			z0vek = true;
			z0pw();
			z0yek(p0: true);
			z0yek(p0: false);
		}
	}

	public int z0tek(z0bmk p0)
	{
		int num = 0;
		z0cek = z0aw().z0vtk().BehaviorOptions.DebugMode;
		z0uek();
		if (z0tek().Count > 0)
		{
			try
			{
				z0pek = new Dictionary<string, string[]>();
				z0xek = new Dictionary<string, XTextElement>();
				z0zek = new Dictionary<string, XTextElement>();
				z0frk = new Dictionary<string, XTextElementList>();
				z0srk = z0vpk.z0rek;
				List<z0ZzZznkh> list = new List<z0ZzZznkh>();
				foreach (z0ZzZznkh item in z0tek())
				{
					item.z0rek(p0: false);
					item.z0yek();
					if (item.z0jrk)
					{
						list.Add(item);
					}
				}
				if (p0 == null)
				{
					p0 = new z0bmk();
				}
				foreach (z0ZzZznkh item2 in list)
				{
					num++;
					z0tek(item2, null, 0, p0, p4: false);
				}
			}
			finally
			{
				if (z0pek != null)
				{
					z0pek.Clear();
					z0pek = null;
				}
				if (z0zek != null)
				{
					z0zek.Clear();
					z0zek = null;
				}
				if (z0xek != null)
				{
					z0xek.Clear();
					z0xek = null;
				}
				if (z0frk != null)
				{
					z0frk.Clear();
					z0frk = null;
				}
				z0srk = z0vpk.z0eek;
			}
		}
		if (num > 0)
		{
			z0aw().z0krk(p0: false);
		}
		return num;
	}

	public void z0iw(bool p0)
	{
		if (p0)
		{
			if (z0xek == null)
			{
				z0xek = new Dictionary<string, XTextElement>();
			}
			if (z0frk == null)
			{
				z0frk = new Dictionary<string, XTextElementList>();
			}
			return;
		}
		if (z0xek != null)
		{
			z0xek.Clear();
			z0xek = null;
		}
		if (z0frk != null)
		{
			z0frk.Clear();
			z0frk = null;
		}
	}

	private XTextElement z0tek(XTextElement p0, z0ZzZzykh p1)
	{
		if (p1 == null)
		{
			throw new ArgumentNullException("info");
		}
		XTextDocument xTextDocument = p0.z0jr();
		XTextElement xTextElement = null;
		if (p0.z0yek(typeof(XTextSectionElement), p1: true) is XTextSubDocumentElement xTextSubDocumentElement)
		{
			xTextElement = xTextSubDocumentElement.z0ki(p1.z0tek());
			if (xTextElement != null)
			{
				return xTextElement;
			}
		}
		if (p1.z0rek() == (z0ZzZzikh)0)
		{
			xTextElement = xTextDocument.z0bek(p0, typeof(XTextFieldElementBase), p2: true);
		}
		else if (p1.z0rek() == (z0ZzZzikh)1)
		{
			for (XTextElement xTextElement2 = p0.z0ji(); xTextElement2 != null; xTextElement2 = xTextElement2.z0ji())
			{
				if (xTextElement2 is XTextContentElement)
				{
					xTextElement = ((XTextContentElement)xTextElement2).z0ki(p1.z0tek());
					if (xTextElement != null)
					{
						break;
					}
				}
			}
			if (xTextElement == null)
			{
				xTextElement = xTextDocument.z0ki(p1.z0tek());
			}
		}
		return xTextElement;
	}

	public bool z0iek()
	{
		return z0grk;
	}

	public string z0uw(XTextElement p0)
	{
		foreach (z0ZzZznkh item in z0tek())
		{
			if (item.z0tek() == p0 && !string.IsNullOrEmpty(item.z0iek()))
			{
				return item.z0iek();
			}
		}
		return null;
	}

	public int z0yw()
	{
		XTextDocument xTextDocument = z0aw();
		if (xTextDocument == null)
		{
			return 0;
		}
		if (!xTextDocument.z0bu().EnableExpression)
		{
			return 0;
		}
		z0cek = xTextDocument.z0bu().DebugMode;
		int num = 0;
		z0uek();
		if (z0tek().Count > 0)
		{
			if (!xTextDocument.z0snk() && xTextDocument.z0cu() != null)
			{
				xTextDocument.z0cu().z0atk();
			}
			try
			{
				List<z0ZzZznkh> list = new List<z0ZzZznkh>();
				foreach (z0ZzZznkh item in z0tek())
				{
					item.z0rek(p0: false);
					list.Add(item);
				}
				z0bmk p = new z0bmk();
				z0frk = new Dictionary<string, XTextElementList>();
				z0pek = new Dictionary<string, string[]>();
				foreach (z0ZzZznkh item2 in list)
				{
					if (z0tek(item2, null, 0, p, p4: false))
					{
						num++;
					}
				}
				z0pek.Clear();
				z0pek = null;
			}
			finally
			{
				if (z0frk != null)
				{
					z0frk.Clear();
					z0frk = null;
				}
				if (!xTextDocument.z0snk() && xTextDocument.z0cu() != null)
				{
					xTextDocument.z0cu().z0cyk();
					xTextDocument.z0xek(p0: true);
				}
			}
		}
		return num;
	}

	private void z0tek(XTextElement p0, bool p1, bool p2, bool p3)
	{
		PropertyExpressionInfoList propertyExpressionInfoList = p0.z0jek();
		if (propertyExpressionInfoList != null && propertyExpressionInfoList.Count > 0)
		{
			foreach (PropertyExpressionInfo item in propertyExpressionInfoList)
			{
				if ((p1 || z0ZzZznkh.z0uek(item.Name) || z0ZzZznkh.z0oek(item.Name)) && (p2 || !z0ZzZznkh.z0uek(item.Name)) && item.Expression != null && item.Expression.Length > 0)
				{
					z0ZzZznkh z0ZzZznkh2 = new z0ZzZznkh(this);
					z0ZzZznkh2.z0eek(p0);
					z0ZzZznkh2.z0pek(item.Name);
					z0ZzZznkh2.z0tek(item.Expression);
					z0ZzZznkh2.z0eek(item.AllowChainReaction);
					z0mek.Add(z0ZzZznkh2);
				}
			}
		}
		if (!p3 || !(p0 is XTextContainerElement))
		{
			return;
		}
		IList<XTextElement> list = ((XTextContainerElement)p0).z0xe();
		if (list == null || list.Count <= 0)
		{
			return;
		}
		int count = list.Count;
		for (int i = 0; i < count; i++)
		{
			XTextElement xTextElement = list[i];
			if (xTextElement is XTextContainerElement)
			{
				z0tek(xTextElement, p1, p2, p3: true);
			}
			else if (xTextElement is XTextObjectElement)
			{
				z0tek(xTextElement, p1, p2, p3: false);
			}
		}
	}

	internal string z0tek(string p0, int p1, int p2, string p3)
	{
		if (string.IsNullOrEmpty(p0))
		{
			return p0;
		}
		z0uek();
		bool flag = false;
		StringBuilder stringBuilder = new StringBuilder();
		string[] array = z0oek(p0);
		for (int i = 0; i < array.Length; i++)
		{
			if (i % 2 == 0)
			{
				stringBuilder.Append(array[i]);
				continue;
			}
			string text = array[i];
			if (z0ZzZzryk.z0yek(text))
			{
				z0ZzZzryk z0ZzZzryk2 = new z0ZzZzryk(text);
				if (!string.IsNullOrEmpty(p3) && string.Compare(z0ZzZzryk2.z0rek(), p3, true) != 0)
				{
					stringBuilder.Append("[" + text + "]");
					continue;
				}
				if (z0ZzZzryk2.z0oek() + z0ZzZzryk2.z0yek() - 1 >= p1)
				{
					if (p2 > 0)
					{
						if (z0ZzZzryk2.z0oek() - 1 >= p1)
						{
							z0ZzZzryk2.z0yek(z0ZzZzryk2.z0oek() + p2);
							flag = true;
						}
						else
						{
							z0ZzZzryk2.z0eek(z0ZzZzryk2.z0yek() + p2);
							flag = true;
						}
					}
					else if (z0ZzZzryk2.z0oek() - 1 > p1)
					{
						z0ZzZzryk2.z0yek(z0ZzZzryk2.z0oek() + p2);
						flag = true;
					}
					else if (z0ZzZzryk2.z0yek() > 0)
					{
						z0ZzZzryk2.z0eek(z0ZzZzryk2.z0yek() + p2);
						flag = true;
					}
				}
				stringBuilder.Append("[" + z0ZzZzryk2.z0iek() + "]");
			}
			else
			{
				stringBuilder.Append("[" + text + "]");
			}
		}
		if (flag)
		{
			return stringBuilder.ToString();
		}
		return p0;
	}

	internal bool z0tek(XTextElement p0)
	{
		int z0buk = p0.z0buk;
		if (z0buk < 0)
		{
			return false;
		}
		if (z0qrk == null)
		{
			z0qrk = z0nek.z0gnk().z0eek();
		}
		if (z0buk < z0qrk.Length && z0qrk[z0buk])
		{
			return true;
		}
		return false;
	}

	public void z0tek(bool p0)
	{
		z0cek = p0;
	}

	public bool z0tw()
	{
		if (z0ark != null)
		{
			return z0ark.Count > 0;
		}
		return false;
	}

	[CompilerGenerated]
	internal static void z0rek(Dictionary<string, object> p0, string p1, XTextElement p2)
	{
		object obj = null;
		if (p0.TryGetValue(p1, out obj))
		{
			if (obj is zzz.z0ZzZzkuk<XTextElement>)
			{
				((zzz.z0ZzZzkuk<XTextElement>)obj).Add(p2);
				return;
			}
			p0[p1] = new zzz.z0ZzZzkuk<XTextElement>
			{
				(XTextElement)obj,
				p2
			};
		}
		else
		{
			p0[p1] = p2;
		}
	}

	public int z0rw(XTextElement p0, bool p1)
	{
		if (!z0aw().z0bu().EnableExpression)
		{
			return 0;
		}
		if (p0 == null)
		{
			return 0;
		}
		z0uek();
		if (z0ark == null)
		{
			z0ark = new Stack<z0ZzZznkh>();
		}
		if (z0ark.Count > WriterControlForWASM.z0auk)
		{
			return 0;
		}
		if (z0ark.Count == 0)
		{
			foreach (z0ZzZznkh item in z0tek())
			{
				item.z0rek(p0: false);
			}
		}
		if (z0ark.Count > 0 && !z0ark.Peek().z0mek())
		{
			return 0;
		}
		int result = 0;
		z0bmk p2 = new z0bmk();
		z0ZzZzbkh z0ZzZzbkh2 = z0tek().z0eek();
		int num = 0;
		try
		{
			List<XTextElement> list = new List<XTextElement>();
			for (int i = 0; i < z0ZzZzbkh2.Count; i++)
			{
				z0ZzZznkh z0ZzZznkh2 = z0ZzZzbkh2[i];
				if (!z0ZzZznkh2.z0tek(p0))
				{
					continue;
				}
				if (p1)
				{
					z0ZzZznkh2.z0rek(p0: false);
				}
				bool flag = false;
				if (z0ZzZznkh2.z0tek() == null)
				{
					flag = true;
				}
				else
				{
					XTextContainerElement xTextContainerElement = z0ZzZznkh2.z0tek().z0ji();
					if (!list.Contains(xTextContainerElement))
					{
						if (z0ZzZznkh2.z0tek().z0ar(z0aw(), p1: false))
						{
							if (!list.Contains(xTextContainerElement))
							{
								list.Add(xTextContainerElement);
							}
						}
						else
						{
							flag = true;
						}
					}
					else if (!xTextContainerElement.z0be().Contains(z0ZzZznkh2.z0tek()))
					{
						flag = true;
					}
				}
				if (flag)
				{
					if (i < z0ZzZzbkh2.Count)
					{
						z0ZzZzbkh2.RemoveAt(i);
					}
					i--;
				}
				else
				{
					if (z0ark.Contains(z0ZzZznkh2) && z0ZzZznkh.z0uek(z0ZzZznkh2.z0uek()))
					{
						continue;
					}
					z0ark.Push(z0ZzZznkh2);
					try
					{
						if (num == 0 && z0aw().z0cu() != null)
						{
							z0aw().z0cu().z0atk();
							if (z0jrk == null)
							{
								z0jrk = new List<XTextElement>();
							}
						}
						num++;
						if (z0tek(z0ZzZznkh2, p0, z0ark.Count - 1, p2, p4: true) && (z0ZzZznkh2.z0tek() is XTextCheckBoxElementBase || string.Equals(z0ZzZznkh2.z0uek(), "Checked", StringComparison.OrdinalIgnoreCase)))
						{
							z0rw(z0ZzZznkh2.z0tek(), p1: false);
						}
					}
					finally
					{
						z0ZzZznkh2.z0rek(p0: true);
						z0ark.Pop();
					}
				}
			}
			return result;
		}
		finally
		{
			if (num > 0 && z0aw().z0cu() != null)
			{
				z0aw().z0cu().z0pek(p0: true);
				if (!z0aw().z0cu().z0jyk())
				{
					if (z0jrk != null && z0jrk.Count > 0)
					{
						foreach (XTextElement item2 in z0jrk)
						{
							item2.z0jo();
						}
						z0jrk.Clear();
					}
					z0jrk = null;
				}
			}
		}
	}

	private int z0tek(XTextDocument p0, XTextTableElement p1, int p2, int p3, bool p4, bool p5)
	{
		z0uek();
		int num = 0;
		XTextElementList xTextElementList = p0.z0nek<XTextTableElement>();
		using zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = xTextElementList.z0ltk();
		while (z0bpk.MoveNext())
		{
			XTextTableElement xTextTableElement = (XTextTableElement)z0bpk.Current;
			string text = null;
			if (xTextTableElement != p1)
			{
				text = xTextTableElement.ID;
				if (string.IsNullOrEmpty(text))
				{
					text = "Table" + Convert.ToString(xTextElementList.IndexOf(xTextTableElement) + 1);
				}
			}
			XTextElement[] array = ((zzz.z0ZzZzkuk<XTextElement>)xTextTableElement.z0stk()).z0krk();
			int count = xTextTableElement.z0stk().Count;
			for (int i = 0; i < count; i++)
			{
				XTextElement xTextElement = array[i];
				if (!xTextElement.z0cuk)
				{
					continue;
				}
				XTextElement[] array2 = ((zzz.z0ZzZzkuk<XTextElement>)xTextElement.z0be()).z0krk();
				int count2 = xTextElement.z0be().Count;
				for (int j = 0; j < count2; j++)
				{
					XTextTableCellElement xTextTableCellElement = (XTextTableCellElement)array2[j];
					if (!xTextTableCellElement.z0yi() || string.IsNullOrEmpty(xTextTableCellElement.ValueExpression))
					{
						continue;
					}
					string text2 = null;
					text2 = ((!p4) ? z0yek(xTextTableCellElement.ValueExpression, p2, p3, text) : z0tek(xTextTableCellElement.ValueExpression, p2, p3, text));
					if (text2 != xTextTableCellElement.ValueExpression)
					{
						if (xTextTableElement != p1 && p5 && p0.z0uik())
						{
							p0.z0imk().z0eek("ValueExpression", xTextTableCellElement.ValueExpression, text2, xTextTableCellElement);
						}
						xTextTableCellElement.ValueExpression = text2;
						num++;
					}
				}
			}
		}
		return num;
	}

	public void z0yek(bool p0)
	{
		z0grk = p0;
	}

	public int z0ew(XTextDocument p0, XTextTableElement p1, int p2, int p3)
	{
		return z0tek(p0, p1, p2, p3, p4: true, p5: true);
	}

	[CompilerGenerated]
	internal static int z0tek(XTextElement p0, object[] p1)
	{
		int result = 0;
		for (XTextContainerElement z0uik = p0.z0uik; z0uik != null; z0uik = z0uik.z0uik)
		{
			p1[result++] = z0uik;
		}
		return result;
	}

	internal string[] z0oek(string p0)
	{
		if (z0pek == null)
		{
			return z0ZzZznik.AnalyseVariableString(p0, "[", "]");
		}
		string[] array = null;
		if (!z0pek.TryGetValue(p0, out array))
		{
			array = z0ZzZznik.AnalyseVariableString(p0, "[", "]");
			z0pek[p0] = array;
		}
		return array;
	}

	public XTextElement z0tek(string p0, XTextElement p1)
	{
		if (p0 == null || p0.Length == 0)
		{
			return null;
		}
		if (z0nek != null)
		{
			if (z0drk == null)
			{
				z0drk = new Dictionary<string, object>();
				z0eek(z0nek, z0drk, p2: true);
			}
			object obj = null;
			if (z0drk.TryGetValue(p0, out obj))
			{
				if (obj is XTextElement)
				{
					return (XTextElement)obj;
				}
				if (obj is XTextElement[] array)
				{
					if (p1 != null)
					{
						if (z0lrk == null)
						{
							z0lrk = new object[200];
							z0hrk = new object[200];
						}
						int num = z0tek(p1, z0lrk);
						XTextElement xTextElement = null;
						int num2 = 0;
						int num3 = -1;
						for (int num4 = array.Length - 1; num4 >= 0; num4--)
						{
							XTextElement xTextElement2 = array[num4];
							if (xTextElement2.z0uik == p1.z0uik)
							{
								xTextElement = xTextElement2;
								break;
							}
							int num5 = z0tek(xTextElement2, z0hrk);
							if (num2 < num5)
							{
								num2 = num5;
							}
							int num6 = num - 1;
							int num7 = num5 - 1;
							while (num6 >= 0 && num7 >= 0)
							{
								if (z0lrk[num6] != z0hrk[num7])
								{
									if (num6 < num - 2 && (num3 < 0 || num3 > num6))
									{
										num3 = num6;
										xTextElement = xTextElement2;
									}
									break;
								}
								num6--;
								num7--;
							}
						}
						Array.Clear(z0lrk, 0, num);
						Array.Clear(z0hrk, 0, num2);
						if (xTextElement != null)
						{
							return xTextElement;
						}
					}
					return array[0];
				}
			}
		}
		return null;
	}

	private static PropertyInfo z0tek(Type p0, string p1)
	{
		p1 = p1.ToLower();
		Dictionary<string, PropertyInfo> dictionary = null;
		if (!z0bek.TryGetValue(p0, out dictionary))
		{
			dictionary = new Dictionary<string, PropertyInfo>();
			z0bek[p0] = dictionary;
		}
		PropertyInfo result = null;
		if (dictionary.TryGetValue(p1.ToLower(), out result))
		{
			return result;
		}
		result = p0.GetProperty(p1, BindingFlags.IgnoreCase | BindingFlags.Instance | BindingFlags.Public);
		dictionary[p1.ToLower()] = result;
		return result;
	}

	private object z0tek(XTextElement p0, string p1)
	{
		if (string.IsNullOrEmpty(p1))
		{
			return null;
		}
		DocumentBehaviorOptions documentBehaviorOptions = z0aw().z0bu();
		if (!documentBehaviorOptions.EnableExpression)
		{
			return false;
		}
		if (!z0aw().z0bek(p0))
		{
			return false;
		}
		object obj = null;
		string p2 = null;
		string text = p1.Replace("[value]", "value");
		text = text.Replace("[VALUE]", "value");
		obj = z0tek(text, p0, ref p2);
		if (documentBehaviorOptions.DebugMode)
		{
			string p3 = string.Format("执行“{0}”的数值表达式“{1}”，其结果为“{2}”。", (p0 == null) ? "NULL" : p0.z0xr(), p1, obj);
			z0ZzZzqok.z0rek.z0sh(p3);
			if (!string.IsNullOrEmpty(p2))
			{
				z0ZzZzqok.z0rek.z0sh(p2);
			}
		}
		return obj;
	}

	public int z0ww(XTextDocument p0, XTextTableElement p1, int p2, int p3)
	{
		return z0tek(p0, p1, p2, p3, p4: false, p5: true);
	}

	private object z0tek(string p0, XTextElement p1, ref string p2)
	{
		z0ZzZzmkh z0ZzZzmkh2 = new z0ZzZzmkh(p0, p1, null, this);
		object result = z0ZzZzmkh2.z0eek();
		p2 = z0ZzZzmkh2.z0uek();
		return result;
	}

	internal string z0yek(string p0, int p1, int p2, string p3)
	{
		if (string.IsNullOrEmpty(p0))
		{
			return p0;
		}
		bool flag = false;
		StringBuilder stringBuilder = new StringBuilder();
		string[] array = z0ZzZznik.AnalyseVariableString(p0, "[", "]");
		for (int i = 0; i < array.Length; i++)
		{
			if (i % 2 == 0)
			{
				stringBuilder.Append(array[i]);
				continue;
			}
			string text = array[i];
			if (z0ZzZzryk.z0yek(text))
			{
				z0ZzZzryk z0ZzZzryk2 = new z0ZzZzryk(text);
				if (!string.IsNullOrEmpty(p3) && string.Compare(z0ZzZzryk2.z0rek(), p3, true) != 0)
				{
					stringBuilder.Append("[" + text + "]");
					continue;
				}
				if (z0ZzZzryk2.z0eek() + z0ZzZzryk2.z0yek() - 1 >= p1)
				{
					if (p2 > 0)
					{
						if (z0ZzZzryk2.z0eek() - 1 >= p1)
						{
							z0ZzZzryk2.z0tek(z0ZzZzryk2.z0eek() + p2);
							flag = true;
						}
						else
						{
							z0ZzZzryk2.z0rek(z0ZzZzryk2.z0uek() + p2);
							flag = true;
						}
					}
					else if (z0ZzZzryk2.z0eek() - 1 > p1)
					{
						z0ZzZzryk2.z0tek(z0ZzZzryk2.z0eek() + p2);
						flag = true;
					}
					else if (z0ZzZzryk2.z0uek() > 0)
					{
						z0ZzZzryk2.z0rek(z0ZzZzryk2.z0uek() + p2);
						flag = true;
					}
				}
				stringBuilder.Append("[" + z0ZzZzryk2.z0iek() + "]");
			}
			else
			{
				stringBuilder.Append("[" + text + "]");
			}
		}
		if (flag)
		{
			return stringBuilder.ToString();
		}
		return p0;
	}

	private bool z0tek(z0ZzZznkh p0, XTextElement p1, int p2, z0bmk p3, bool p4)
	{
		if (p0.z0rek())
		{
			return false;
		}
		if (string.IsNullOrEmpty(p0.z0uek()))
		{
			return false;
		}
		z0uek();
		XTextElement xTextElement = p0.z0tek();
		if (xTextElement == null)
		{
			return false;
		}
		PropertyInfo propertyInfo = z0tek(xTextElement.GetType(), p0.z0uek());
		if (propertyInfo == null)
		{
			return false;
		}
		MemberEffectLevel memberEffectLevel = MemberEffectLevel.DOM;
		if (xTextElement is XTextRadioBoxElement && propertyInfo.Name == "Checked")
		{
			memberEffectLevel = MemberEffectLevel.ElementView;
			propertyInfo = z0tek(xTextElement.GetType(), "EditorChecked");
		}
		object obj = null;
		try
		{
			obj = p0.z0eek(p1, p2, z0yek());
		}
		catch (Exception ex)
		{
			z0ZzZzqok.z0rek.z0dh(ex.ToString());
			return false;
		}
		if (!xTextElement.z0ar(z0aw(), p1: false))
		{
			return false;
		}
		if (z0srk == z0vpk.z0eek)
		{
			z0ZzZzbjh z0ZzZzbjh2 = (z0ZzZzbjh)Attribute.GetCustomAttribute(propertyInfo, typeof(z0ZzZzbjh), false);
			if (z0ZzZzbjh2 != null)
			{
				memberEffectLevel = z0ZzZzbjh2.z0eek();
			}
		}
		object obj2 = null;
		Type propertyType = propertyInfo.PropertyType;
		if (obj is string && propertyInfo.PropertyType.Equals(typeof(Color)))
		{
			obj2 = z0ZzZzifh.z0eek((string)obj);
		}
		else if (propertyType == typeof(DCBooleanValue) && obj is bool)
		{
			obj2 = ((!(bool)obj) ? ((object)DCBooleanValue.False) : ((object)DCBooleanValue.True));
		}
		else if (propertyType == typeof(ElementVisibility) && obj is bool)
		{
			obj2 = ((!(bool)obj) ? ((object)ElementVisibility.None) : ((object)ElementVisibility.Visible));
		}
		else if (propertyType == typeof(ElementVisibility) && obj is int num)
		{
			obj2 = num switch
			{
				1 => ElementVisibility.Hidden, 
				2 => ElementVisibility.None, 
				_ => ElementVisibility.Visible, 
			};
		}
		else if (propertyType == typeof(bool) && obj is string)
		{
			obj2 = z0ZzZzafh.z0yek((string)obj, (bool)propertyInfo.GetValue(xTextElement, null));
		}
		else if (propertyType == typeof(ValueValidateStyle) && obj is string)
		{
			string text = obj as string;
			ValueValidateStyle valueValidateStyle = new ValueValidateStyle();
			if (text != null && text.Length > 0)
			{
				valueValidateStyle.DCReadString(text);
			}
			obj2 = valueValidateStyle;
		}
		else
		{
			try
			{
				obj2 = z0ZzZzmik.z0eek(obj, propertyInfo.PropertyType);
			}
			catch
			{
				return false;
			}
		}
		object value = propertyInfo.GetValue(xTextElement, null);
		if (propertyType == typeof(string) && string.IsNullOrEmpty((string)value) && string.IsNullOrEmpty((string)obj2))
		{
			return false;
		}
		XTextInputFieldElement xTextInputFieldElement = null;
		InputFieldSettings inputFieldSettings = null;
		DocumentBehaviorOptions documentBehaviorOptions = ((z0nek != null) ? z0nek.z0bu() : null);
		bool enableExpression = true;
		string text2 = null;
		if (xTextElement is XTextInputFieldElement)
		{
			if (documentBehaviorOptions != null)
			{
				enableExpression = documentBehaviorOptions.EnableExpression;
				z0nek.z0bu().EnableExpression = false;
			}
			xTextInputFieldElement = xTextElement as XTextInputFieldElement;
			text2 = xTextInputFieldElement.InnerValue;
			if (xTextInputFieldElement.FieldSettings != null)
			{
				inputFieldSettings = xTextInputFieldElement.FieldSettings.z0rek();
				xTextInputFieldElement.FieldSettings = null;
			}
		}
		propertyInfo.SetValue(xTextElement, obj2, null);
		if (xTextInputFieldElement != null)
		{
			if (inputFieldSettings != null)
			{
				xTextInputFieldElement.FieldSettings = inputFieldSettings;
			}
			if (xTextInputFieldElement.z0oek() == InputFieldEditStyle.DropdownList && (xTextElement == p1 || p0.z0eek((object)xTextElement)) && text2 != null)
			{
				xTextInputFieldElement.InnerValue = text2;
			}
			if (documentBehaviorOptions != null)
			{
				z0nek.z0bu().EnableExpression = enableExpression;
			}
		}
		if (p3.z0uek)
		{
			p3.z0eek(memberEffectLevel, xTextElement, propertyInfo, value, obj2);
		}
		z0nek.z0vik();
		bool flag = false;
		if (p4)
		{
			foreach (z0ZzZznkh item in z0tek())
			{
				if (item.z0eek((object)xTextElement))
				{
					flag = true;
					break;
				}
			}
		}
		if (z0ZzZznkh.z0oek(propertyInfo.Name))
		{
			if (xTextElement is XTextContainerElement)
			{
				((XTextContainerElement)xTextElement).z0jrk(p0: true);
			}
			for (XTextContainerElement xTextContainerElement = xTextElement.z0ji(); xTextContainerElement != null; xTextContainerElement = xTextContainerElement.z0ji())
			{
				if (!xTextContainerElement.Visible)
				{
					return true;
				}
				if (xTextContainerElement is XTextDocumentContentElement)
				{
					break;
				}
			}
			if (xTextElement is XTextContainerElement)
			{
				xTextElement.z0qi(((XTextContainerElement)xTextElement).z0ur(XTextContainerElement.z0kgj.z0eek(z0aw(), p1: true)));
			}
			flag = true;
		}
		if (z0srk == z0vpk.z0eek)
		{
			if (z0nek.z0cu() != null)
			{
				WriterAfterExecuteEventExpressionEventArgs p5 = new WriterAfterExecuteEventExpressionEventArgs(z0nek.z0cu(), z0nek, p1, xTextElement, propertyInfo.Name);
				z0nek.z0cu().z0eek(p5);
			}
			switch (memberEffectLevel)
			{
			case MemberEffectLevel.DOM:
				xTextElement.z0uyk()?.z0ouk();
				break;
			case MemberEffectLevel.ElementView:
				if (z0jrk == null)
				{
					xTextElement.z0jo();
				}
				else
				{
					z0jrk.Add(xTextElement);
				}
				xTextElement.z0ri();
				break;
			case MemberEffectLevel.ElementLayout:
				xTextElement.z0oe();
				break;
			case MemberEffectLevel.ParentElementLayout:
				if (xTextElement.z0ji() != null)
				{
					xTextElement.z0ji().z0oe();
				}
				break;
			case MemberEffectLevel.ContentElementLayout:
				xTextElement.z0jy()?.z0oe();
				break;
			case MemberEffectLevel.DocumentLayout:
				if (xTextElement.z0cu() == null)
				{
					xTextElement.z0jr().z0vek(p0: true);
					break;
				}
				xTextElement.z0jr().z0vek(p0: true);
				xTextElement.z0cu().z0fpk();
				break;
			}
		}
		if (flag && p4)
		{
			foreach (z0ZzZznkh item2 in z0tek())
			{
				if (item2 != p0)
				{
					item2.z0pek();
				}
			}
			z0rw(xTextElement, p1: true);
		}
		return true;
	}

	public int z0qw(XTextElementList p0, Dictionary<string, string> p1)
	{
		if (p0 == null || p0.Count == 0)
		{
			return 0;
		}
		if (p1 == null || p1.Count == 0)
		{
			return 0;
		}
		int num = 0;
		foreach (XTextElement item in new z0ZzZzkxj(p0)
		{
			ExcludeCharElement = true,
			ExcludeParagraphFlag = true
		})
		{
			if (!(item is z0ZzZzbxj))
			{
				continue;
			}
			PropertyExpressionInfoList propertyExpressions = ((z0ZzZzbxj)item).PropertyExpressions;
			if (propertyExpressions == null || propertyExpressions.Count <= 0)
			{
				continue;
			}
			foreach (PropertyExpressionInfo item2 in propertyExpressions)
			{
				string[] array = z0ZzZznik.AnalyseVariableString(item2.Expression, "[", "]");
				StringBuilder stringBuilder = new StringBuilder();
				bool flag = false;
				for (int i = 0; i < array.Length; i++)
				{
					string text = array[i];
					if (i % 2 == 0)
					{
						stringBuilder.Append(text);
						continue;
					}
					bool flag2 = false;
					foreach (string key in p1.Keys)
					{
						string text2 = p1[key];
						if (text == text2)
						{
							stringBuilder.Append("[" + key + "]");
							flag2 = true;
							flag = true;
							break;
						}
					}
					if (!flag2)
					{
						stringBuilder.Append("[" + text + "]");
					}
				}
				if (flag)
				{
					item2.Expression = stringBuilder.ToString();
					num++;
					z0mw_jiejie20260327142557(item);
				}
			}
		}
		return num;
	}

	public XTextDocument z0aw()
	{
		return z0nek;
	}

	public bool z0sw(XTextElement p0, z0ZzZzukh p1, string p2, bool p3)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("sourceElement");
		}
		if (p1 == null || p1.Count == 0)
		{
			return false;
		}
		if (p2 == null)
		{
			throw new ArgumentNullException("eventName");
		}
		DocumentBehaviorOptions documentBehaviorOptions = z0aw().z0bu();
		if (!documentBehaviorOptions.EnableExpression)
		{
			return false;
		}
		z0cek = documentBehaviorOptions.DebugMode;
		bool result = false;
		bool flag = false;
		XTextDocumentContentElement xTextDocumentContentElement = p0.z0qek();
		XTextElement xTextElement = null;
		int num = -1;
		if (xTextDocumentContentElement != null)
		{
			xTextElement = xTextDocumentContentElement.z0zek();
			if (xTextElement != null)
			{
				num = xTextDocumentContentElement.z0frk().IndexOf(xTextElement);
			}
		}
		if (!p3)
		{
			z0aw().z0yyk();
		}
		foreach (z0ZzZzykh item in p1)
		{
			if (string.Compare(item.z0iek(), p2, true) != 0 || string.IsNullOrEmpty(item.z0yek()))
			{
				continue;
			}
			XTextElement xTextElement2 = z0tek(p0, item);
			if (xTextElement2 == null)
			{
				if (documentBehaviorOptions.DebugMode)
				{
					string p4 = string.Format("执行元素“{0}”包含的数值表达式时未找到目标“{1}”。", p0.z0xr(), (item.z0rek() == (z0ZzZzikh)1) ? item.z0tek() : "Next");
					z0ZzZzqok.z0rek.z0sh(p4);
				}
				continue;
			}
			if (xTextElement2.z0zu(p0))
			{
				if (documentBehaviorOptions.DebugMode)
				{
					string p5 = string.Format("执行元素“{0}”包含的数值表达式时不得包含所属下级元素“{1}”。", p0.z0xr(), (item.z0rek() == (z0ZzZzikh)1) ? item.z0tek() : "Next");
					z0ZzZzqok.z0rek.z0sh(p5);
				}
				continue;
			}
			string text = item.z0uek();
			if (string.IsNullOrEmpty(text))
			{
				text = "Visible";
			}
			text = text.Trim().ToUpper();
			object obj = null;
			try
			{
				obj = z0tek(p0, item.z0yek());
			}
			catch (Exception ex)
			{
				if (documentBehaviorOptions.DebugMode)
				{
					string p6 = string.Format("源自“{0}”的数值表达式“{1}”执行结果为“{2}”。", (p0 == null) ? "NULL" : p0.z0xr(), item.z0yek(), ex.Message);
					z0ZzZzqok.z0rek.z0sh(p6);
				}
				if (!(text == "VISIBLE"))
				{
					continue;
				}
				obj = true;
			}
			if (!(text == "VISIBLE"))
			{
				if (!(text == "TEXT") || !(xTextElement2 is XTextContainerElement))
				{
					continue;
				}
				string p7 = Convert.ToString(obj);
				XTextContainerElement xTextContainerElement = (XTextContainerElement)xTextElement2;
				if (p3)
				{
					xTextContainerElement.z0zek(p7);
					xTextContainerElement.z0li();
					continue;
				}
				xTextContainerElement.z0cek(p7, (z0ZzZzbcj)0, p2: false, p3: true);
				xTextContainerElement.z0li();
				if (z0nek.z0cu() != null)
				{
					WriterAfterExecuteEventExpressionEventArgs p8 = new WriterAfterExecuteEventExpressionEventArgs(z0nek.z0cu(), z0nek, p0, xTextElement2, text);
					z0nek.z0cu().z0eek(p8);
				}
				continue;
			}
			bool flag2 = z0ZzZzmik.z0eek(obj, xTextElement2.Visible);
			if (p3)
			{
				xTextElement2.Visible = flag2;
				continue;
			}
			xTextElement2.z0or(flag2, p1: false, p2: false);
			if (z0nek.z0cu() != null)
			{
				WriterAfterExecuteEventExpressionEventArgs p9 = new WriterAfterExecuteEventExpressionEventArgs(z0nek.z0cu(), z0nek, p0, xTextElement2, text);
				z0nek.z0cu().z0eek(p9);
			}
			if (xTextElement2.z0jy().z0pek())
			{
				flag = true;
			}
		}
		if (!p3)
		{
			if (xTextElement != null)
			{
				int num2 = xTextDocumentContentElement.z0frk().IndexOf(xTextElement);
				if (num2 != num && num2 >= 0)
				{
					xTextDocumentContentElement.z0frk().z0tek(num2, 0);
				}
			}
			z0aw().z0yyk();
			if (flag)
			{
				z0aw().z0krk();
				if (z0aw().z0yyk() != null)
				{
					z0aw().z0yyk().z0fpk();
					z0aw().z0yyk().z0vik();
					((XTextElement)z0aw()).z0uyk().z0hz();
				}
			}
			else if (z0aw().z0yyk() != null)
			{
				z0aw().z0yyk().z0vik();
			}
		}
		return result;
	}

	public void Dispose()
	{
		z0qrk = null;
		if (z0drk != null)
		{
			foreach (object value in z0drk.Values)
			{
				if (value is zzz.z0ZzZzkuk<XTextElement>)
				{
					((zzz.z0ZzZzkuk<XTextElement>)value).z0vrk();
				}
			}
			z0drk.Clear();
			z0drk = null;
		}
		if (z0frk != null)
		{
			z0frk.Clear();
			z0frk = null;
		}
		if (z0pek != null)
		{
			z0pek.Clear();
			z0pek = null;
		}
		if (z0xek != null)
		{
			z0xek.Clear();
			z0xek = null;
		}
		if (z0zek != null)
		{
			z0zek.Clear();
			z0zek = null;
		}
		z0nek = null;
		if (z0jrk != null)
		{
			z0jrk.Clear();
			z0jrk = null;
		}
		if (z0mek != null)
		{
			foreach (z0ZzZznkh item in z0mek)
			{
				item.Dispose();
			}
			z0mek.Clear();
			z0mek = null;
		}
		if (z0ark != null)
		{
			z0ark.Clear();
			z0ark = null;
		}
		if (z0krk != null)
		{
			z0krk.Clear();
			z0krk = null;
		}
	}
}
