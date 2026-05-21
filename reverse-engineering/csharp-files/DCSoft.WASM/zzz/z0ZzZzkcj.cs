using System;
using System.Collections.Generic;
using DCSoft.Writer.Dom;

namespace zzz;

public class z0ZzZzkcj
{
	private List<z0ZzZzkcj> z0iek;

	private int z0oek = 1;

	private Dictionary<string, XTextElementList> z0pek;

	private Dictionary<string, XTextElementList> z0mek;

	private XTextContainerElement z0nek;

	public z0ZzZzkcj(XTextContainerElement p0)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("rootElement");
		}
		z0nek = p0;
		if (p0 is XTextDocument)
		{
			return;
		}
		z0ZzZzkcj z0ZzZzkcj2 = p0.z0jr()?.z0mok();
		if (z0ZzZzkcj2 != null)
		{
			if (z0ZzZzkcj2.z0iek == null)
			{
				z0ZzZzkcj2.z0iek = new List<z0ZzZzkcj>();
			}
			z0ZzZzkcj2.z0iek.Add(this);
		}
	}

	public void z0eek()
	{
		z0rek();
		if (z0iek == null)
		{
			return;
		}
		foreach (z0ZzZzkcj item in z0iek)
		{
			item.z0rek();
		}
	}

	internal XTextElementList z0eek(string p0, Type p1)
	{
		XTextElementList xTextElementList = new XTextElementList();
		if (string.IsNullOrEmpty(p0))
		{
			return xTextElementList;
		}
		foreach (XTextElement item in new z0ZzZzkxj(z0nek)
		{
			ExcludeCharElement = true,
			ExcludeParagraphFlag = true
		})
		{
			if (p1.IsInstanceOfType(item))
			{
				XTextCheckBoxElementBase xTextCheckBoxElementBase = (XTextCheckBoxElementBase)item;
				if (p0 == xTextCheckBoxElementBase.z0tek())
				{
					xTextElementList.Add(xTextCheckBoxElementBase);
				}
			}
		}
		return xTextElementList;
	}

	public void z0rek()
	{
		z0oek++;
		z0mek = null;
		z0pek = null;
	}

	public XTextContainerElement z0tek()
	{
		return z0nek;
	}

	private void z0yek()
	{
		if (z0mek != null)
		{
			return;
		}
		z0oek++;
		z0mek = new Dictionary<string, XTextElementList>();
		z0pek = new Dictionary<string, XTextElementList>();
		using zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = z0nek.z0nek<XTextCheckBoxElementBase>().z0ltk();
		while (z0bpk.MoveNext())
		{
			XTextCheckBoxElementBase xTextCheckBoxElementBase = (XTextCheckBoxElementBase)z0bpk.Current;
			xTextCheckBoxElementBase.z0eek(z0oek);
			string text = xTextCheckBoxElementBase.z0tek();
			if (string.IsNullOrEmpty(text))
			{
				text = string.Empty;
			}
			Dictionary<string, XTextElementList> dictionary = null;
			if (xTextCheckBoxElementBase is XTextCheckBoxElement)
			{
				dictionary = z0mek;
			}
			else if (xTextCheckBoxElementBase is XTextRadioBoxElement)
			{
				dictionary = z0pek;
			}
			if (dictionary.ContainsKey(text))
			{
				dictionary[text].Add(xTextCheckBoxElementBase);
				continue;
			}
			XTextElementList xTextElementList = (dictionary[text] = new XTextElementList());
			xTextElementList.Add(xTextCheckBoxElementBase);
		}
	}

	public XTextElementList z0eek(XTextCheckBoxElementBase p0)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("element");
		}
		if (p0.z0frk() != z0oek)
		{
			z0rek();
		}
		z0yek();
		string text = p0.z0tek();
		if (text == null)
		{
			text = string.Empty;
		}
		Dictionary<string, XTextElementList> dictionary = null;
		if (p0 is XTextCheckBoxElement)
		{
			dictionary = z0mek;
		}
		else if (p0 is XTextRadioBoxElement)
		{
			dictionary = z0pek;
		}
		XTextElementList xTextElementList = null;
		if (dictionary.ContainsKey(text))
		{
			xTextElementList = dictionary[text];
		}
		if (xTextElementList != null)
		{
			xTextElementList = xTextElementList.z0pek();
		}
		return xTextElementList;
	}

	public void z0uek()
	{
		z0nek = null;
		if (z0iek != null)
		{
			List<z0ZzZzkcj> list = z0iek;
			z0iek = null;
			foreach (z0ZzZzkcj item in list)
			{
				item.z0uek();
			}
			list.Clear();
		}
		if (z0mek != null)
		{
			foreach (XTextElementList value in z0mek.Values)
			{
				value.Clear();
			}
			z0mek.Clear();
			z0mek = null;
		}
		if (z0pek == null)
		{
			return;
		}
		foreach (XTextElementList value2 in z0pek.Values)
		{
			value2.Clear();
		}
		z0pek.Clear();
		z0pek = null;
	}
}
