using System;
using System.Collections.Generic;
using DCSoft.Writer;
using DCSoft.Writer.Dom;
using DCSystem_Drawing;

namespace zzz;

public class z0ZzZzmpj : IDisposable
{
	private class z0qok
	{
		public z0ZzZzbdh z0rek = z0ZzZzbdh.z0xek;

		public void z0eek()
		{
		}
	}

	private Dictionary<string, z0ZzZzxdh> z0yek = new Dictionary<string, z0ZzZzxdh>();

	private z0ZzZzimk z0uek = new z0ZzZzimk();

	private static z0ZzZzlsh z0iek;

	private Dictionary<XTextElement, z0qok> z0oek = new Dictionary<XTextElement, z0qok>();

	private XTextDocument z0pek;

	public z0ZzZzimk z0eek()
	{
		return z0uek;
	}

	public XTextDocument z0rek()
	{
		return z0pek;
	}

	public void z0eek(z0ZzZzvxj p0)
	{
		DocumentViewOptions documentViewOptions = z0pek.z0iu();
		XTextElementList xTextElementList = new XTextElementList();
		if (documentViewOptions.AdornTextVisibility == DCAdornTextVisibility.Actived)
		{
			for (XTextElement xTextElement = z0pek.z0itk(); xTextElement != null; xTextElement = xTextElement.z0ji())
			{
				xTextElementList.Add(xTextElement);
			}
		}
		else if (documentViewOptions.AdornTextVisibility == DCAdornTextVisibility.Both)
		{
			xTextElementList = ((XTextContainerElement)z0pek.z0jrk()).z0irk();
		}
		using zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = xTextElementList.z0ltk();
		while (z0bpk.MoveNext())
		{
			XTextElement current = z0bpk.Current;
			string runtimeAdornText = GetRuntimeAdornText(current);
			if (!string.IsNullOrEmpty(runtimeAdornText) && z0pek.z0cek(current))
			{
				z0qok z0qok = z0eek(p0.z0gyk, current, p0.z0hrk(), runtimeAdornText);
				if (z0qok != null && !z0qok.z0rek.z0bek() && z0qok.z0rek.z0tek(p0.z0nek()))
				{
					z0oek[current] = z0qok;
					z0eek(p0.z0gyk, runtimeAdornText, z0qok.z0rek);
				}
			}
		}
	}

	public z0ZzZzxdh z0eek(string p0)
	{
		if (string.IsNullOrEmpty(p0))
		{
			return z0ZzZzxdh.z0yek;
		}
		if (z0yek.ContainsKey(p0))
		{
			return z0yek[p0];
		}
		using z0ZzZzjpk p1 = z0pek.z0ru();
		return z0eek(p1, p0);
	}

	public z0ZzZzbdh z0eek(XTextElement p0)
	{
		if (p0 == null)
		{
			return z0ZzZzbdh.z0xek;
		}
		if (p0 is XTextFieldBorderElement)
		{
			p0 = p0.z0ji();
		}
		if (p0 == null)
		{
			return z0ZzZzbdh.z0xek;
		}
		if (z0oek.ContainsKey(p0))
		{
			return z0oek[p0].z0rek;
		}
		return z0ZzZzbdh.z0xek;
	}

	public z0ZzZzxdh z0eek(z0ZzZzjpk p0, string p1)
	{
		if (string.IsNullOrEmpty(p1))
		{
			return z0ZzZzxdh.z0yek;
		}
		if (z0yek.ContainsKey(p1))
		{
			return z0yek[p1];
		}
		if (p0 != null)
		{
			z0ZzZzxdh z0ZzZzxdh2 = z0ZzZzlcj.z0rek(p0, p1, z0eek(), 100000, z0iek);
			z0ZzZzxdh2.z0rek(p0.z0eek(z0eek()));
			z0ZzZzxdh2.z0eek(z0ZzZzxdh2.z0rek() + 10f);
			z0ZzZzxdh2.z0rek(z0ZzZzxdh2.z0tek() + 8f);
			z0yek[p1] = z0ZzZzxdh2;
			return z0ZzZzxdh2;
		}
		return z0ZzZzxdh.z0yek;
	}

	public z0ZzZzmpj(XTextDocument p0)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("document");
		}
		z0pek = p0;
		if (z0iek == null)
		{
			z0iek = z0ZzZzlsh.z0uek().z0eek();
			z0iek.z0eek((z0ZzZzksh)4096);
			z0iek.z0rek(StringAlignment.Center);
			z0iek.z0eek(StringAlignment.Center);
		}
	}

	private void z0eek(z0ZzZzjpk p0, string p1, z0ZzZzbdh p2)
	{
		if (!string.IsNullOrEmpty(p1) && !p2.z0bek())
		{
			p0.z0eek(z0rek().z0iu().AdornTextBackColor, p2, p2.z0iek() / 5f);
			p0.z0eek(p1, z0eek(), Color.Black, p2, z0iek);
			p0.z0eek(z0ZzZzidh.z0iek, p2, p2.z0iek() / 5f);
		}
	}

	public void z0eek(z0ZzZzimk p0)
	{
		z0uek = p0;
		z0yek.Clear();
	}

	public bool z0rek(XTextElement p0)
	{
		return z0oek.ContainsKey(p0);
	}

	public void Dispose()
	{
		z0pek = null;
		z0uek = null;
		if (z0oek != null)
		{
			foreach (z0qok value in z0oek.Values)
			{
				value.z0eek();
			}
			z0oek.Clear();
			z0oek = null;
		}
		if (z0yek != null)
		{
			z0yek.Clear();
			z0yek = null;
		}
	}

	public bool z0tek(XTextElement p0)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("element");
		}
		DocumentViewOptions documentViewOptions = z0pek.z0iu();
		if (documentViewOptions.AdornTextVisibility == DCAdornTextVisibility.Hidden)
		{
			return false;
		}
		if (documentViewOptions.AdornTextVisibility == DCAdornTextVisibility.Actived)
		{
			z0pek.z0itk();
		}
		if (!string.IsNullOrEmpty(p0.z0iy()))
		{
			return true;
		}
		return false;
	}

	protected virtual string GetRuntimeAdornText(XTextElement element)
	{
		string text = element.z0iy();
		if (!string.IsNullOrEmpty(text))
		{
			return text;
		}
		switch (z0pek.z0iu().DefaultAdornTextType)
		{
		case InputFieldAdornTextType.ID:
			return element.ID;
		case InputFieldAdornTextType.Name:
			if (element is XTextObjectElement)
			{
				return ((XTextObjectElement)element).Name;
			}
			if (element is XTextInputFieldElement)
			{
				return ((XTextInputFieldElement)element).Name;
			}
			break;
		case InputFieldAdornTextType.TabIndex:
			if (element is XTextInputFieldElementBase)
			{
				return ((XTextInputFieldElementBase)element).TabIndex.ToString();
			}
			break;
		case InputFieldAdornTextType.ToolTip:
			if (element is XTextContainerElement)
			{
				return ((XTextInputFieldElement)element).ToolTip;
			}
			if (element is XTextImageElement)
			{
				return ((XTextImageElement)element).z0vrk();
			}
			break;
		case InputFieldAdornTextType.ValidateMessage:
			if (element is XTextInputFieldElement)
			{
				XTextInputFieldElement xTextInputFieldElement = (XTextInputFieldElement)element;
				if (((XTextContainerElement)xTextInputFieldElement).z0frk() != null)
				{
					return ((XTextContainerElement)xTextInputFieldElement).z0frk().z0uek();
				}
			}
			break;
		case InputFieldAdornTextType.DataSource:
		{
			z0ZzZzevj z0ZzZzevj2 = null;
			if (element is XTextContainerElement)
			{
				z0ZzZzevj2 = ((XTextContainerElement)element).ValueBinding;
			}
			else if (element is XTextLabelElementBase)
			{
				z0ZzZzevj2 = ((XTextLabelElementBase)element).ValueBinding;
			}
			else if (element is XTextCheckBoxElementBase)
			{
				z0ZzZzevj2 = ((XTextCheckBoxElementBase)element).ValueBinding;
			}
			if (z0ZzZzevj2 != null && z0ZzZzevj2.z0eek() && !z0ZzZzevj2.IsEmptyBinding)
			{
				if (string.IsNullOrEmpty(z0ZzZzevj2.DataSource))
				{
					return z0ZzZzevj2.DataSource + "#" + z0ZzZzevj2.BindingPath;
				}
				return z0ZzZzevj2.BindingPath;
			}
			break;
		}
		}
		return null;
	}

	private z0qok z0eek(z0ZzZzjpk p0, XTextElement p1, z0ZzZzbdh p2, string p3)
	{
		if (string.IsNullOrEmpty(p3))
		{
			return null;
		}
		z0ZzZzxdh z0ZzZzxdh2 = z0eek(p0, p3);
		if (z0ZzZzxdh2.z0eek())
		{
			return null;
		}
		if (p1 is XTextFieldElementBase)
		{
			p1 = ((XTextFieldElementBase)p1).z0jrk();
		}
		z0ZzZzbdh z0ZzZzbdh2 = p1.z0qyk();
		z0ZzZzbdh z0ZzZzbdh3 = new z0ZzZzbdh(z0ZzZzbdh2.z0oek(), z0ZzZzbdh2.z0pek() - z0ZzZzxdh2.z0tek(), z0ZzZzxdh2.z0rek(), z0ZzZzxdh2.z0tek());
		if (!p2.z0bek() && z0ZzZzbdh3.z0pek() < p2.z0pek() - 2f)
		{
			z0ZzZzbdh3.z0rek(z0ZzZzbdh2.z0nek());
		}
		if (z0ZzZzbdh3.z0pek() < 0f)
		{
			z0ZzZzbdh3.z0rek(z0ZzZzbdh2.z0nek());
		}
		if (z0ZzZzbdh3.z0mek() > z0pek.z0it() + z0pek.z0xyk().Width)
		{
			z0ZzZzbdh3.z0eek(z0pek.z0it() + z0pek.z0xyk().Width - z0ZzZzbdh3.z0uek());
		}
		return new z0qok
		{
			z0rek = z0ZzZzbdh3
		};
	}

	public void z0tek()
	{
		z0oek.Clear();
		z0yek.Clear();
	}
}
