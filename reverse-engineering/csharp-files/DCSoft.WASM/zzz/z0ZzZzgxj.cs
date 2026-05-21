using System;
using System.Collections.Generic;
using DCSoft.Writer;
using DCSoft.Writer.Dom;

namespace zzz;

internal class z0ZzZzgxj
{
	private class z0rnk : IComparer<z0ZzZzhxj>
	{
		public static z0rnk z0eek = new z0rnk();

		public int Compare(z0ZzZzhxj x, z0ZzZzhxj y)
		{
			if (x.z0eek() == y.z0eek())
			{
				return x.z0uek() - y.z0uek();
			}
			return y.z0eek() - x.z0eek();
		}
	}

	private bool z0iek = true;

	private z0ZzZzqbj z0oek;

	private List<z0ZzZzhxj> z0pek;

	private bool z0mek_jiejie20260327142557 = true;

	private XTextElementList z0nek;

	public void z0eek(DocumentEventArgs p0)
	{
		if (z0pek == null || z0pek.Count == 0 || (p0.Style != DocumentEventStyles.MouseMove && p0.Style != DocumentEventStyles.MouseDown))
		{
			return;
		}
		z0pek.Sort(z0rnk.z0eek);
		for (int num = z0pek.Count - 1; num >= 0; num--)
		{
			z0ZzZzhxj z0ZzZzhxj2 = z0pek[num];
			if (z0ZzZzhxj2.z0eek(p0.X, p0.Y))
			{
				p0.Cursor = z0ZzZzhxj2.z0iek();
				p0.Handled = true;
				if (p0.Style == DocumentEventStyles.MouseMove && !string.IsNullOrEmpty(z0ZzZzhxj2.z0rek()))
				{
					z0oek.z0uek(z0ZzZzhxj2.z0rek());
				}
				break;
			}
		}
		if (p0.Style != DocumentEventStyles.MouseDown)
		{
			return;
		}
		WriterMouseEventArgs e = new WriterMouseEventArgs(z0oek.z0xek(), p0.X, p0.Y, p0.MouseClicks, p0.Button, p0.WheelDelta);
		for (int num2 = z0pek.Count - 1; num2 >= 0; num2--)
		{
			z0ZzZzhxj z0ZzZzhxj3 = z0pek[num2];
			z0ZzZzhxj3.z0dj(e);
			if (e.Handled)
			{
				p0.Handled = true;
				p0.Cursor = z0ZzZzhxj3.z0iek();
				break;
			}
		}
	}

	public void z0eek()
	{
		z0oek = null;
		z0tek();
	}

	public void z0rek()
	{
		z0mek_jiejie20260327142557 = true;
	}

	public z0ZzZzgxj(z0ZzZzqbj p0)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("ctl");
		}
		z0oek = p0;
	}

	public void z0eek(z0ZzZzvxj p0, XTextDocumentContentElement p1)
	{
		z0yek();
		using zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = z0nek.z0ltk();
		while (z0bpk.MoveNext())
		{
			XTextElement current = z0bpk.Current;
			if (!current.z0zu(p1))
			{
				continue;
			}
			z0ZzZzhxj z0ZzZzhxj2 = current.z0vt();
			if (z0ZzZzhxj2 == null)
			{
				continue;
			}
			z0ZzZzhxj2.z0lj(p0);
			if (z0pek == null)
			{
				z0pek = new List<z0ZzZzhxj>();
			}
			bool flag = false;
			for (int num = z0pek.Count - 1; num >= 0; num--)
			{
				if (z0pek[num].z0nek() == current)
				{
					z0pek[num] = z0ZzZzhxj2;
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				z0pek.Add(z0ZzZzhxj2);
			}
		}
	}

	private void z0eek(XTextContainerElement p0)
	{
		IList<XTextElement> list = p0.z0xe();
		if (list == null)
		{
			return;
		}
		foreach (XTextElement item in list)
		{
			if (!item.z0yi())
			{
				continue;
			}
			if (item.z0ky())
			{
				z0nek.Add(item);
			}
			if (!(item is XTextContainerElement))
			{
				continue;
			}
			XTextContainerElement xTextContainerElement = (XTextContainerElement)item;
			if (xTextContainerElement.z0crk())
			{
				if (xTextContainerElement is XTextTableElement xTextTableElement)
				{
					xTextTableElement.z0uek(z0eek);
				}
				else
				{
					z0eek(xTextContainerElement);
				}
			}
		}
	}

	public void z0tek()
	{
		if (z0nek != null)
		{
			z0nek.Clear();
		}
		if (z0pek != null)
		{
			z0pek.Clear();
		}
	}

	public void z0yek()
	{
		if (!z0iek && z0mek_jiejie20260327142557)
		{
			z0mek_jiejie20260327142557 = false;
			if (z0nek == null || z0nek.Count <= 0)
			{
				return;
			}
			using zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = z0nek.z0ltk();
			while (z0bpk.MoveNext())
			{
				z0bpk.Current.z0jo();
			}
			return;
		}
		if (!z0iek || ((z0ZzZzspj)z0oek).z0hrk())
		{
			return;
		}
		z0iek = false;
		if (z0nek != null && z0nek.Count > 0)
		{
			using (zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = z0nek.z0ltk())
			{
				while (z0bpk.MoveNext())
				{
					z0bpk.Current.z0jo();
				}
			}
			z0nek.Clear();
		}
		z0nek = new XTextElementList();
		z0eek(z0oek.z0qtk());
		z0nek.z0ork();
		z0pek = null;
	}

	public z0ZzZzhxj z0eek(XTextElement p0)
	{
		if (p0 is XTextCharElement || p0 is XTextTableCellElement || p0 is XTextParagraphFlagElement)
		{
			return null;
		}
		if (z0pek != null)
		{
			foreach (z0ZzZzhxj item in z0pek)
			{
				if (item.z0nek() == p0)
				{
					return item;
				}
			}
		}
		return p0.z0vt();
	}

	public void z0uek()
	{
		z0iek = true;
		z0mek_jiejie20260327142557 = true;
	}
}
