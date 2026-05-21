using System;
using DCSoft.Writer;
using DCSoft.Writer.Dom;

namespace zzz;

public class z0ZzZzvpj
{
	private bool z0yek = true;

	private bool z0uek;

	private z0ZzZzplh z0iek;

	private XTextDocument z0oek;

	public int z0eek(z0ZzZzsmj p0)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("args");
		}
		if (p0.z0yek())
		{
			return 0;
		}
		bool p1 = false;
		bool flag = true;
		int p2 = -1;
		int p3;
		while (true)
		{
			p2 = z0eek(p0, p1: true, p2);
			p3 = z0eek().z0vok();
			if (p2 >= 0)
			{
				if (flag)
				{
					flag = false;
					if (p0.z0oek())
					{
						z0eek().z0ytk();
					}
					if (z0eek().z0yyk() != null)
					{
						p1 = z0eek().z0yyk().z0duk();
						z0eek().z0yyk().z0ark(p0: false);
					}
				}
				int num = z0rek().z0zek().z0lrk();
				if (string.IsNullOrEmpty(p0.z0bek()))
				{
					if (!z0eek().z0xek().z0hn(p0: true))
					{
						p2 = ((!p0.z0rek()) ? (p2 - p0.z0mek().Length - 1) : (p2 + p0.z0mek().Length + 1));
						continue;
					}
				}
				else
				{
					bool flag2 = true;
					XTextInputFieldElement xTextInputFieldElement = null;
					if (!p0.z0krk())
					{
						foreach (XTextElement item in z0rek().z0zek())
						{
							if (item != null && item.z0ji() is XTextInputFieldElement)
							{
								if (xTextInputFieldElement == null)
								{
									xTextInputFieldElement = item.z0ji() as XTextInputFieldElement;
									if (xTextInputFieldElement.z0be().Count > 0)
									{
										flag2 = false;
										break;
									}
								}
								else if (item.z0ji() != xTextInputFieldElement)
								{
									flag2 = false;
									break;
								}
								continue;
							}
							flag2 = false;
							break;
						}
					}
					if (!p0.z0krk() && flag2 && xTextInputFieldElement != null)
					{
						int num2 = xTextInputFieldElement.BackgroundText.IndexOf(p0.z0bek());
						if (num2 >= 0)
						{
							xTextInputFieldElement.BackgroundText = xTextInputFieldElement.BackgroundText.Substring(0, num2) + p0.z0bek() + xTextInputFieldElement.BackgroundText.Substring(num2 + p0.z0bek().Length);
						}
						xTextInputFieldElement.z0oe();
						p2 = ((!p0.z0rek()) ? (p2 - p0.z0mek().Length - 1) : (p2 + p0.z0mek().Length + 1));
					}
					else
					{
						XTextElementList xTextElementList = z0eek().z0xek().z0pn(p0.z0bek(), p0.z0oek(), InputValueSource.Unknow, null, null);
						if (xTextElementList == null || xTextElementList.Count == 0)
						{
							p2 = ((!p0.z0rek()) ? (p2 - p0.z0mek().Length - 1) : (p2 + p0.z0mek().Length + 1));
							continue;
						}
					}
				}
				if (p2 >= 0)
				{
					p0.z0pek().Add(num);
					z0rek().z0tek(num, p0.z0bek().Length);
				}
				if (z0eek().z0yyk() != null)
				{
					z0eek().z0yyk().z0ark(p1);
				}
				if (p0.z0oek())
				{
					z0eek().z0nuk();
				}
			}
			else
			{
				p2 = -1;
			}
			break;
		}
		z0eek().z0xek(p3);
		return p2;
	}

	public void z0eek(z0ZzZzplh p0)
	{
		z0iek = p0;
	}

	public XTextDocument z0eek()
	{
		return z0oek;
	}

	public void z0eek(bool p0)
	{
		z0yek = p0;
	}

	public z0ZzZzplh z0rek()
	{
		return z0iek;
	}

	public int z0eek(z0ZzZzsmj p0, XTextElementList p1, bool p2, int p3)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("args");
		}
		if (p1 == null)
		{
			throw new ArgumentNullException("elements");
		}
		if (p1.Count == 0)
		{
			return -1;
		}
		if (string.IsNullOrEmpty(p0.z0mek()))
		{
			return -1;
		}
		if (p1 == null)
		{
			p1 = z0rek();
		}
		int length = p0.z0mek().Length;
		int num = -1;
		if (p0.z0rek())
		{
			if (p3 < 0)
			{
				p3 = 0;
			}
			int count = p1.Count;
			for (int i = p3; i < count; i++)
			{
				XTextElement xTextElement = p1[i];
				if (!(xTextElement is XTextCharElement) || (p0.z0uek() != null && !xTextElement.z0zu(p0.z0uek())))
				{
					continue;
				}
				char p4 = ((XTextCharElement)xTextElement).z0mek();
				if (!z0eek(p4, p0.z0mek()[0], p0.z0nek()))
				{
					continue;
				}
				if (length == 1)
				{
					num = i;
					break;
				}
				if (count - i < length)
				{
					continue;
				}
				int num2 = 1;
				while (num2 < length)
				{
					XTextElement xTextElement2 = p1[i + num2];
					if (!(xTextElement2 is XTextCharElement) || xTextElement2.z0wtk() || !z0eek(((XTextCharElement)xTextElement2).z0mek(), p0.z0mek()[num2], p0.z0nek()))
					{
						break;
					}
					if (num2 != length - 1)
					{
						num2++;
						continue;
					}
					goto IL_012b;
				}
				continue;
				IL_012b:
				num = i;
				break;
			}
		}
		else
		{
			if (p3 < 0)
			{
				p3 = p1.Count - 1;
			}
			char p5 = p0.z0mek()[p0.z0mek().Length - 1];
			int num3 = p3;
			while (num3 >= 0)
			{
				XTextElement xTextElement3 = p1[num3];
				if (xTextElement3 is XTextCharElement && (p0.z0uek() == null || xTextElement3.z0zu(p0.z0uek())))
				{
					char p6 = ((XTextCharElement)xTextElement3).z0mek();
					if (z0eek(p6, p5, p0.z0nek()) && !xTextElement3.z0wtk())
					{
						if (length == 1)
						{
							num = num3;
							break;
						}
						if (num3 >= length - 1)
						{
							int num4 = length - 2;
							while (num4 >= 0)
							{
								XTextElement xTextElement4 = p1[num3 - length + num4 + 1];
								if (!(xTextElement4 is XTextCharElement) || !z0eek(((XTextCharElement)xTextElement4).z0mek(), p0.z0mek()[num4], p0.z0nek()))
								{
									break;
								}
								if (num4 != 0)
								{
									num4--;
									continue;
								}
								goto IL_0234;
							}
						}
					}
				}
				num3--;
				continue;
				IL_0234:
				num = num3 - length + 1;
				break;
			}
		}
		if (p2)
		{
			if (num >= 0)
			{
				XTextElement item = p1[num];
				int num5 = z0rek().IndexOf(item);
				if (num5 >= 0 && !z0rek().z0tek(num5, p0.z0mek().Length))
				{
				}
			}
		}
		else if (num >= 0)
		{
			if (p0.z0rek())
			{
				z0rek().z0tek(num + p0.z0mek().Length, p1: false);
			}
			else
			{
				z0rek().z0tek(num, p1: false);
			}
		}
		if (p0.z0xek() && !p0.z0cek() && num >= 0)
		{
			z0rek().z0drk().ClearTextHighlight();
			using zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = z0rek().z0pek(num, p0.z0mek().Length).z0ltk();
			while (z0bpk.MoveNext())
			{
				XTextElement current = z0bpk.Current;
				if (current is XTextCharElement)
				{
					z0rek().z0drk().SetCharElementHighlight((XTextCharElement)current, p0.z0zek(), p0.z0vek(), supportPrint: false, supportPDF: false);
				}
			}
		}
		return num;
	}

	public bool z0tek()
	{
		return z0yek;
	}

	public int z0rek(z0ZzZzsmj p0)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("args");
		}
		if (p0.z0yek())
		{
			return 0;
		}
		int num = 0;
		z0ZzZzsmj p1 = p0.z0eek();
		z0eek().z0ytk();
		while (z0eek(p1) >= 0)
		{
			num++;
		}
		z0eek().z0nuk();
		return num;
	}

	public void z0eek(XTextDocument p0)
	{
		z0oek = p0;
		if (z0oek != null)
		{
			z0iek = z0oek.z0ryk();
		}
	}

	private bool z0eek(char p0, char p1, bool p2)
	{
		if (p0 == p1)
		{
			return true;
		}
		if (p2)
		{
			int num = -1;
			if (p0 >= 'a' && p0 <= 'z')
			{
				num = p0 - 97;
			}
			else if (p0 >= 'A' && p0 <= 'Z')
			{
				num = p0 - 65;
			}
			int num2 = -1;
			if (p1 >= 'a' && p1 <= 'z')
			{
				num2 = p1 - 97;
			}
			else if (p1 >= 'A' && p1 <= 'Z')
			{
				num2 = p1 - 65;
			}
			if (num >= 0)
			{
				return num == num2;
			}
			return false;
		}
		return false;
	}

	public int z0tek(z0ZzZzsmj p0)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("args");
		}
		if (string.IsNullOrEmpty(p0.z0mek()))
		{
			return -1;
		}
		p0.z0pek().Clear();
		z0ZzZzplh z0ZzZzplh2 = z0rek();
		int length = p0.z0mek().Length;
		int count = z0ZzZzplh2.Count;
		for (int i = 0; i < count; i++)
		{
			XTextElement xTextElement = z0ZzZzplh2[i];
			if (!(xTextElement is XTextCharElement) || (p0.z0uek() != null && !xTextElement.z0zu(p0.z0uek())))
			{
				continue;
			}
			if (p0.z0krk() && xTextElement.z0ji() is XTextFieldElementBase)
			{
				XTextFieldElementBase xTextFieldElementBase = (XTextFieldElementBase)xTextElement.z0ji();
				if (xTextFieldElementBase.z0eek(xTextElement))
				{
					i = z0ZzZzplh2.IndexOf(xTextFieldElementBase.z0tek());
					continue;
				}
			}
			char p1 = ((XTextCharElement)xTextElement).z0mek();
			if (!z0eek(p1, p0.z0mek()[0], p0.z0nek()) || xTextElement.z0wtk())
			{
				continue;
			}
			if (length == 1)
			{
				p0.z0pek().Add(i);
			}
			else
			{
				if (count - i < length)
				{
					continue;
				}
				for (int j = 1; j < length; j++)
				{
					XTextElement xTextElement2 = z0ZzZzplh2[i + j];
					if (!(xTextElement2 is XTextCharElement) || !z0eek(((XTextCharElement)xTextElement2).z0mek(), p0.z0mek()[j], p0.z0nek()))
					{
						break;
					}
					if (j == length - 1)
					{
						p0.z0pek().Add(i);
						break;
					}
				}
			}
		}
		if (p0.z0xek() && p0.z0iek() > 0 && !p0.z0cek())
		{
			bool flag = z0ZzZzplh2.z0drk().ClearTextHighlight();
			foreach (int item in p0.z0pek())
			{
				using zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = z0ZzZzplh2.z0pek(item, p0.z0mek().Length).z0ltk();
				while (z0bpk.MoveNext())
				{
					XTextElement current2 = z0bpk.Current;
					if (current2 is XTextCharElement)
					{
						z0ZzZzplh2.z0drk().SetCharElementHighlight((XTextCharElement)current2, p0.z0zek(), p0.z0vek(), supportPrint: false, supportPDF: false);
						flag = true;
					}
				}
			}
			if (flag)
			{
				z0eek().z0cu()?.z0hz();
			}
		}
		return p0.z0iek();
	}

	public z0ZzZzvpj(XTextDocument p0)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("document");
		}
		z0eek(p0);
	}

	public int z0eek(z0ZzZzsmj p0, bool p1, int p2)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("args");
		}
		if (p0.z0yek())
		{
			XTextElement xTextElement = z0eek().z0ki(p0.z0mek());
			if (xTextElement != null)
			{
				int num = xTextElement.z0hy().z0jrk();
				if (p1)
				{
					if (p1)
					{
						xTextElement.z0sr();
					}
				}
				else if (p0.z0rek())
				{
					z0rek().z0tek(num + p0.z0mek().Length, p1: false);
				}
				else
				{
					z0rek().z0tek(num, p1: false);
				}
				return num;
			}
			return -1;
		}
		if (string.IsNullOrEmpty(p0.z0mek()))
		{
			return -1;
		}
		z0ZzZzplh z0ZzZzplh2 = z0rek();
		int length = p0.z0mek().Length;
		int num2 = -1;
		bool p3 = p0.z0nek();
		bool flag = p0.z0krk();
		string text = p0.z0mek();
		if (p0.z0rek())
		{
			while (true)
			{
				if (p2 < 0)
				{
					p2 = z0ZzZzplh2.z0zek().z0drk();
				}
				if (z0eek().z0vok() < 0)
				{
					z0eek().z0xek(p2);
					z0uek = false;
				}
				int count = z0ZzZzplh2.Count;
				char p4 = text[0];
				int i;
				for (i = p2; i < count; i++)
				{
					XTextElement xTextElement2 = z0ZzZzplh2[i];
					if (!(xTextElement2 is XTextCharElement) || (p0.z0uek() != null && !xTextElement2.z0zu(p0.z0uek())))
					{
						continue;
					}
					if (flag && xTextElement2.z0ji() is XTextFieldElementBase)
					{
						XTextFieldElementBase xTextFieldElementBase = (XTextFieldElementBase)xTextElement2.z0ji();
						if (xTextFieldElementBase.z0eek(xTextElement2))
						{
							i = z0ZzZzplh2.z0bek(xTextFieldElementBase.z0tek());
							continue;
						}
					}
					char p5 = ((XTextCharElement)xTextElement2).z0mek();
					if (!z0eek(p5, p4, p3) || xTextElement2.z0wtk())
					{
						continue;
					}
					if (length == 1)
					{
						num2 = i;
						break;
					}
					if (count - i < length)
					{
						continue;
					}
					int num3 = 1;
					while (num3 < length)
					{
						XTextElement xTextElement3 = z0ZzZzplh2[i + num3];
						if (!(xTextElement3 is XTextCharElement) || !z0eek(((XTextCharElement)xTextElement3).z0mek(), text[num3], p3))
						{
							break;
						}
						if (num3 != length - 1)
						{
							num3++;
							continue;
						}
						goto IL_01f9;
					}
				}
				if (num2 >= 0)
				{
					break;
				}
				if (!z0uek)
				{
					bool flag2 = true;
					if (z0tek() && z0eek().z0bu().PromptJumpBackForSearch)
					{
						flag2 = z0ZzZzfeh.z0eek(null, z0ZzZziok.z0ztk(), z0ZzZziok.z0lyk(), (z0ZzZzdeh)4, (z0ZzZzaeh)2) == (z0ZzZzxwh)6;
					}
					if (flag2)
					{
						z0uek = true;
						p2 = 0;
						continue;
					}
				}
				return num2;
				IL_01f9:
				num2 = i;
				break;
			}
		}
		else
		{
			while (true)
			{
				if (p2 < 0)
				{
					p2 = z0ZzZzplh2.z0zek().z0lrk();
				}
				if (z0eek().z0vok() < 0)
				{
					z0eek().z0xek(p2);
					z0uek = false;
				}
				char p6 = text[text.Length - 1];
				int num4;
				for (num4 = p2 - 1; num4 >= 0; num4--)
				{
					XTextElement xTextElement4 = z0ZzZzplh2[num4];
					if (!(xTextElement4 is XTextCharElement) || (p0.z0uek() != null && !xTextElement4.z0zu(p0.z0uek())))
					{
						continue;
					}
					if (flag && xTextElement4.z0ji() is XTextFieldElementBase)
					{
						XTextFieldElementBase xTextFieldElementBase2 = (XTextFieldElementBase)xTextElement4.z0ji();
						if (xTextFieldElementBase2.z0eek(xTextElement4))
						{
							num4 = z0ZzZzplh2.z0bek(xTextFieldElementBase2.z0jrk());
							continue;
						}
					}
					char p7 = ((XTextCharElement)xTextElement4).z0mek();
					if (!z0eek(p7, p6, p3) || xTextElement4.z0wtk())
					{
						continue;
					}
					if (length == 1)
					{
						num2 = num4;
						break;
					}
					if (num4 < length - 1)
					{
						continue;
					}
					int num5 = length - 2;
					while (num5 >= 0)
					{
						XTextElement xTextElement5 = z0ZzZzplh2[num4 - length + num5 + 1];
						if (!(xTextElement5 is XTextCharElement) || !z0eek(((XTextCharElement)xTextElement5).z0mek(), text[num5], p3))
						{
							break;
						}
						if (num5 != 0)
						{
							num5--;
							continue;
						}
						goto IL_03a7;
					}
				}
				if (num2 >= 0 || z0uek)
				{
					break;
				}
				if (z0tek())
				{
					_ = z0eek().z0bu().PromptJumpBackForSearch;
				}
				if (1 == 0)
				{
					break;
				}
				z0uek = true;
				p2 = z0ZzZzplh2.Count - 1;
				continue;
				IL_03a7:
				num2 = num4 - length + 1;
				break;
			}
		}
		if (p1)
		{
			if (num2 >= 0)
			{
				int p8 = z0eek().z0vok();
				if (z0ZzZzplh2.z0tek(num2, p0.z0mek().Length))
				{
					z0eek().z0xek(p8);
				}
			}
		}
		else if (num2 >= 0)
		{
			if (p0.z0rek())
			{
				z0rek().z0tek(num2 + p0.z0mek().Length, p1: false);
			}
			else
			{
				z0rek().z0tek(num2, p1: false);
			}
		}
		if (p0.z0xek() && !p0.z0cek() && num2 >= 0)
		{
			z0rek().z0drk().ClearTextHighlight();
			using zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = z0rek().z0pek(num2, p0.z0mek().Length).z0ltk();
			while (z0bpk.MoveNext())
			{
				XTextElement current = z0bpk.Current;
				if (current is XTextCharElement)
				{
					z0rek().z0drk().SetCharElementHighlight((XTextCharElement)current, p0.z0zek(), p0.z0vek(), supportPrint: false, supportPDF: false);
				}
			}
		}
		return num2;
	}
}
