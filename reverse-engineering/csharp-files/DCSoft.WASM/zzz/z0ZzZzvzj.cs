using System;
using System.Collections.Generic;
using DCSoft.Writer;
using DCSoft.Writer.Dom;

namespace zzz;

internal class z0ZzZzvzj : z0ZzZzmgh
{
	private int z0uek;

	private int z0iek;

	protected XTextDocument z0oek;

	private int z0pek;

	private int z0mek;

	public override void Dispose()
	{
		base.Dispose();
		z0oek = null;
	}

	private void z0eek(z0ZzZzpgh p0, bool p1)
	{
		try
		{
			if (((XTextElement)z0oek).z0uyk() != null)
			{
				((XTextElement)z0oek).z0uyk().z0jrk(p0: false);
			}
			XTextElementList xTextElementList = z0oek.z0imk().z0rek();
			xTextElementList.Clear();
			z0oek.z0imk().z0oek.Clear();
			z0oek.z0imk().z0yek_jiejie20260327142557().Clear();
			z0oek.z0imk().z0rek((z0ZzZzbzj)0);
			if (p1)
			{
				base.z0to(p0);
			}
			else
			{
				base.z0yo(p0);
			}
			if ((z0oek.z0imk().z0tek() & (z0ZzZzbzj)3) == (z0ZzZzbzj)3)
			{
				if (z0eek().z0yyk() != null)
				{
					z0eek().z0yyk().z0iyk();
					return;
				}
			}
			else
			{
				if ((z0oek.z0imk().z0tek() & (z0ZzZzbzj)1) == (z0ZzZzbzj)1 && z0eek().z0yyk() != null)
				{
					z0eek().z0yyk().z0eek(p0: false, p1: false);
				}
				if ((z0oek.z0imk().z0tek() & (z0ZzZzbzj)2) == (z0ZzZzbzj)2)
				{
					if (z0eek().z0yyk() != null)
					{
						z0eek().z0yyk().z0eek(p0: false, p1: true);
					}
				}
				else if ((z0oek.z0imk().z0tek() & (z0ZzZzbzj)6) == (z0ZzZzbzj)6)
				{
					z0eek().z0ank()?.Refreshview();
				}
				if ((z0oek.z0imk().z0tek() & (z0ZzZzbzj)5) == (z0ZzZzbzj)5 && ((XTextElement)z0eek()).z0uyk() != null)
				{
					((XTextElement)z0eek()).z0uyk().z0hz();
				}
				if ((z0oek.z0imk().z0tek() & (z0ZzZzbzj)8) == (z0ZzZzbzj)8 && z0eek().z0rik() != null)
				{
					z0eek().z0rik().z0pw();
				}
				if ((z0oek.z0imk().z0tek() & (z0ZzZzbzj)7) == (z0ZzZzbzj)7)
				{
					XTextDocumentContentElement xTextDocumentContentElement = z0eek().z0xyk();
					if (xTextElementList != null && xTextElementList.Count > 0)
					{
						xTextDocumentContentElement = xTextElementList[0].z0qek();
					}
					if (xTextDocumentContentElement == null && z0eek().z0imk().z0oek != null)
					{
						foreach (XTextContentElement key in z0eek().z0imk().z0oek.Keys)
						{
							xTextDocumentContentElement = key.z0qek();
							if (xTextDocumentContentElement != null)
							{
								break;
							}
						}
					}
					if (xTextDocumentContentElement == null)
					{
						xTextDocumentContentElement = z0eek().z0xyk();
					}
					xTextDocumentContentElement.z0rek(p0: false, p1: true);
					if (z0eek().z0yyk() != null)
					{
						z0eek().z0yyk().z0nuk();
					}
				}
			}
			XTextElementList xTextElementList2 = new XTextElementList();
			Dictionary<XTextContentElement, int> dictionary = new Dictionary<XTextContentElement, int>();
			if (z0eek().z0imk().z0oek.Count > 0)
			{
				XTextDocumentContentElement xTextDocumentContentElement2 = null;
				foreach (XTextContentElement key2 in z0eek().z0imk().z0oek.Keys)
				{
					xTextDocumentContentElement2 = key2.z0qek();
					key2.z0bek(p0: false);
					dictionary[key2] = z0eek().z0imk().z0oek[key2];
				}
				xTextDocumentContentElement2.z0bek(p0: false);
			}
			if (xTextElementList.Count > 0)
			{
				using (zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = xTextElementList.z0ltk())
				{
					while (z0bpk.MoveNext())
					{
						XTextElement current2 = z0bpk.Current;
						XTextContentElement xTextContentElement = current2.z0jy();
						if (xTextContentElement == null)
						{
							continue;
						}
						if (current2 is XTextSectionElement)
						{
							xTextContentElement = current2.z0ji().z0jy();
						}
						if (dictionary.ContainsKey(xTextContentElement))
						{
							int num = xTextContentElement.z0trk().IndexOf(current2);
							if (num < 0 || num >= dictionary[xTextContentElement])
							{
								continue;
							}
							for (int num2 = dictionary[xTextContentElement]; num2 >= num; num2--)
							{
								XTextElement xTextElement = xTextContentElement.z0trk()[num2];
								if (xTextElement.z0ptk() != null)
								{
									xTextElement.z0ptk().z0tek(p0: true);
								}
							}
							dictionary[xTextContentElement] = num;
							continue;
						}
						xTextContentElement.z0bek(p0: true);
						current2.z0ie().z0yek(p0: true, p1: true);
						int num3 = xTextContentElement.z0trk().IndexOf(current2.z0hy());
						if (num3 < 0)
						{
							num3 = xTextContentElement.z0trk().IndexOf(current2);
						}
						if (current2 is XTextParagraphFlagElement && num3 >= 0)
						{
							int num4 = xTextContentElement.z0trk().IndexOf(current2);
							bool flag = false;
							if (num4 < 0)
							{
								flag = true;
								num4 = xTextContentElement.z0trk().Count - 1;
							}
							for (int i = num3; i <= num4; i++)
							{
								XTextElement xTextElement2 = xTextContentElement.z0trk()[i];
								if (flag && xTextElement2.z0iek(current2) && xTextElement2.z0tr() > current2.z0tr())
								{
									break;
								}
								if (xTextElement2.z0ptk() != null)
								{
									xTextElement2.z0ptk().z0tek(p0: true);
								}
							}
						}
						if (num3 >= 0)
						{
							dictionary[xTextContentElement] = num3;
						}
					}
				}
				if (dictionary.Count == 0)
				{
					XTextDocumentContentElement xTextDocumentContentElement3 = null;
					using (zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = xTextElementList.z0ltk())
					{
						while (z0bpk.MoveNext())
						{
							XTextElement current3 = z0bpk.Current;
							XTextContentElement xTextContentElement2 = current3.z0jy();
							if (xTextContentElement2 == null)
							{
								continue;
							}
							if (current3 is XTextSectionElement)
							{
								xTextContentElement2 = current3.z0ji().z0jy();
							}
							if (!dictionary.ContainsKey(xTextContentElement2))
							{
								xTextDocumentContentElement3 = xTextContentElement2.z0qek();
								xTextContentElement2.z0bek(p0: false);
								dictionary[xTextContentElement2] = 0;
								z0ZzZzzlh[] array = xTextContentElement2.z0zek();
								for (int j = 0; j < array.Length; j++)
								{
									array[j].z0tek(p0: true);
								}
							}
						}
					}
					xTextDocumentContentElement3?.z0bek(p0: false);
				}
				using z0ZzZzjpk p2 = z0eek().z0ru();
				z0ZzZzvxj p3 = z0eek().z0bek(p2, (z0ZzZzcxj)0);
				using zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = xTextElementList.z0ltk();
				while (z0bpk.MoveNext())
				{
					XTextElement current4 = z0bpk.Current;
					XTextContentElement xTextContentElement3 = current4.z0jy();
					if (xTextContentElement3 == null)
					{
						continue;
					}
					if (current4 is XTextSectionElement)
					{
						xTextContentElement3 = current4.z0ji().z0jy();
					}
					if (xTextContentElement3.z0trk().IndexOf(current4.z0hy()) >= 0)
					{
						if (current4.z0ao() || current4.z0ark())
						{
							xTextElementList2.Add(current4);
						}
						if (current4.z0ao())
						{
							current4.z0mr(p3);
						}
					}
				}
			}
			XTextDocumentContentElement xTextDocumentContentElement4 = z0eek().z0xyk();
			foreach (XTextContentElement key3 in dictionary.Keys)
			{
				xTextDocumentContentElement4 = key3.z0qek();
				int p4 = dictionary[key3];
				_ = 0;
				key3.z0eek(p4, -1, p2: true);
			}
			xTextDocumentContentElement4?.z0rek(p0: false, p1: true);
			if (!z0eek().z0frk())
			{
				z0eek().z0krk();
				if (z0eek().z0yyk() != null)
				{
					z0eek().z0yyk().z0fpk();
					z0eek().z0yyk().z0ypk().z0hz();
				}
			}
			xTextDocumentContentElement4.z0frk().z0uek(p0: true);
			xTextDocumentContentElement4.z0frk().z0tek(p0: false);
			if (p1)
			{
				xTextDocumentContentElement4.z0uek(z0iek, 0);
			}
			else
			{
				xTextDocumentContentElement4.z0uek(z0mek, 0);
			}
			using (zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = xTextElementList2.z0ltk())
			{
				while (z0bpk.MoveNext())
				{
					XTextElement current6 = z0bpk.Current;
					current6.z0hrk(p0: true);
					current6.z0jo();
				}
			}
			if (z0eek().z0imk().z0yek_jiejie20260327142557().Count <= 0)
			{
				return;
			}
			using (zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = z0eek().z0imk().z0yek_jiejie20260327142557().z0ltk())
			{
				while (z0bpk.MoveNext())
				{
					XTextContainerElement xTextContainerElement = (XTextContainerElement)z0bpk.Current;
					ContentChangedEventArgs e = new ContentChangedEventArgs();
					e.EventSource = ContentChangedEventSource.UndoRedo;
					e.Document = z0eek();
					e.Element = xTextContainerElement;
					xTextContainerElement.z0zi(e);
				}
			}
			z0eek().OnDocumentContentChanged();
		}
		finally
		{
			if (((XTextElement)z0oek).z0uyk() != null)
			{
				((XTextElement)z0oek).z0uyk().z0jrk(p0: true);
			}
		}
	}

	public override void z0to(z0ZzZzpgh p0)
	{
		z0eek(p0, p1: true);
	}

	public override void z0yo(z0ZzZzpgh p0)
	{
		z0eek(p0, p1: false);
	}

	public void z0eek(int p0)
	{
		z0pek = p0;
	}

	public void z0rek(int p0)
	{
		z0iek = p0;
	}

	public z0ZzZzvzj(XTextDocument p0)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("doc");
		}
		z0oek = p0;
	}

	public new void z0tek(int p0)
	{
		z0mek = p0;
	}

	public XTextDocument z0eek()
	{
		return z0oek;
	}

	public void z0yek(int p0)
	{
		z0uek = p0;
	}
}
