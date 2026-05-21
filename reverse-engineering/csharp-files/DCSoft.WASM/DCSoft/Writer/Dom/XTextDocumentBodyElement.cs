using System;
using System.Collections.Generic;
using System.Diagnostics;
using DCSoft.Drawing;
using DCSystem_Drawing;
using zzz;

namespace DCSoft.Writer.Dom;

[z0ZzZziqh("XTextBody")]
[DebuggerDisplay("Body :{ PreviewString }")]
public sealed class XTextDocumentBodyElement : XTextDocumentContentElement
{
	private class z0nvk : IComparable<z0nvk>
	{
		public bool z0rek;

		public float z0tek;

		public float z0yek;

		public override string ToString()
		{
			return z0yek + " -> " + z0tek;
		}

		public bool z0eek(float p0)
		{
			if (p0 >= z0yek + 2f)
			{
				return p0 <= z0tek - 2f;
			}
			return false;
		}

		public int CompareTo(z0nvk other)
		{
			if (z0yek > other.z0yek)
			{
				return 1;
			}
			if (z0yek == other.z0yek)
			{
				return 0;
			}
			return -1;
		}
	}

	private class z0bvk : List<z0nvk>
	{
		private Dictionary<int, bool> z0rek = new Dictionary<int, bool>();

		private bool z0tek;

		public bool z0eek(float p0)
		{
			if (z0rek == null)
			{
				z0rek = new Dictionary<int, bool>();
			}
			if (z0rek.ContainsKey((int)p0))
			{
				return z0rek[(int)p0];
			}
			bool flag = false;
			if (z0tek)
			{
				for (int num = base.Count - 1; num >= 0; num--)
				{
					if (base[num].z0eek(p0))
					{
						flag = true;
						break;
					}
				}
			}
			else
			{
				int num2 = 0;
				int num3 = base.Count - 1;
				while (num2 < num3)
				{
					if (num3 < num2 + 8)
					{
						for (int i = num2; i <= num3; i++)
						{
							if (base[i].z0eek(p0))
							{
								flag = true;
								break;
							}
						}
						z0rek[(int)p0] = flag;
						return flag;
					}
					int num4 = (num2 + num3) / 2;
					z0nvk z0nvk = base[num4];
					if (p0 >= z0nvk.z0yek - 2f && p0 <= z0nvk.z0yek + 2f)
					{
						flag = false;
						break;
					}
					if (z0nvk.z0eek(p0))
					{
						flag = true;
						break;
					}
					if (p0 < z0nvk.z0yek + 1f)
					{
						num3 = num4;
					}
					else
					{
						num2 = num4;
					}
					if (num3 - num2 == 1)
					{
						break;
					}
				}
			}
			z0rek[(int)p0] = flag;
			return flag;
		}

		public void z0eek()
		{
			Clear();
			if (z0rek != null)
			{
				z0rek.Clear();
				z0rek = null;
			}
		}

		public z0bvk(XTextDocumentBodyElement p0)
		{
			if (!((XTextContentElement)p0).z0wrk())
			{
				return;
			}
			if (p0.z0jr().z0qxk != null && p0.z0iu().ShowGlobalGridLineInTableAndSection)
			{
				z0tek = false;
				z0ZzZzzlh[] array = ((XTextContentElement)p0).z0zek();
				foreach (z0ZzZzzlh z0ZzZzzlh in array)
				{
					z0nvk z0nvk = new z0nvk();
					z0nvk.z0yek = z0ZzZzzlh.z0xrk();
					z0nvk.z0tek = z0nvk.z0yek + z0ZzZzzlh.z0ytk();
					z0nvk.z0rek = false;
					Add(z0nvk);
				}
				return;
			}
			z0ZzZzlkh z0ZzZzlkh = ((XTextDocumentContentElement)p0).z0tek();
			float num = 0f;
			bool flag = false;
			zzz.z0ZzZzyuk<int, int, z0nvk> z0ZzZzyuk = new zzz.z0ZzZzyuk<int, int, z0nvk>();
			float num2 = p0.z0cw();
			foreach (z0ZzZzzlh item in z0ZzZzlkh.z0xrk())
			{
				bool flag2 = item.z0jrk_jiejie20260327142557() || item.z0brk();
				if (flag2)
				{
					z0tek = true;
				}
				if (item.z0ayk == p0)
				{
					z0nvk z0nvk2 = new z0nvk();
					z0nvk2.z0yek = num2 + item.z0zrk();
					z0nvk2.z0tek = z0nvk2.z0yek + item.z0ytk();
					z0nvk2.z0rek = flag2;
					Add(z0nvk2);
					continue;
				}
				float num3 = item.z0xrk();
				float num4 = num3 + item.z0ytk();
				if (num3 < num)
				{
					flag = true;
				}
				num = num3;
				if (!z0ZzZzyuk.z0tek((int)num3, (int)num4))
				{
					z0nvk z0nvk3 = new z0nvk
					{
						z0yek = num3,
						z0tek = num4,
						z0rek = flag2
					};
					Add(z0nvk3);
					z0ZzZzyuk.z0rek((int)num3, (int)num4, z0nvk3);
				}
			}
			z0ZzZzyuk.z0iek();
			if (flag)
			{
				Sort();
			}
		}
	}

	[NonSerialized]
	private new z0bvk z0iek;

	[z0ZzZzuqh]
	public override z0ZzZzzej GridLine
	{
		get
		{
			if (z0jr() != null)
			{
				return z0jr().PageSettings.z0dtk();
			}
			return null;
		}
		set
		{
		}
	}

	[z0ZzZzuqh]
	public XTextElementList Sections
	{
		get
		{
			XTextElementList xTextElementList = new XTextElementList();
			using zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = z0be().z0ltk();
			while (z0bpk.MoveNext())
			{
				XTextElement current = z0bpk.Current;
				if (current is XTextSectionElement)
				{
					xTextElementList.Add(current);
				}
			}
			return xTextElementList;
		}
	}

	public z0ZzZzzlh z0eek(int p0, int p1)
	{
		z0ZzZzwrj z0ZzZzwrj = z0jr().z0suk().z0rek(p0);
		if (z0ZzZzwrj != null)
		{
			zzz.z0ZzZzkuk<z0ZzZzzlh> z0ZzZzkuk = new zzz.z0ZzZzkuk<z0ZzZzzlh>();
			z0ZzZzzlh[] array = ((XTextContentElement)this).z0zek();
			foreach (z0ZzZzzlh z0ZzZzzlh in array)
			{
				if (z0ZzZzzlh.z0qtk() && !z0ZzZzzlh.z0mek().IsCollapsed)
				{
					z0ZzZzkuk.AddRange(z0ZzZzzlh.z0mek().z0zek());
				}
				else
				{
					z0ZzZzkuk.Add(z0ZzZzzlh);
				}
			}
			int count = z0ZzZzkuk.Count;
			for (int j = 0; j < count; j++)
			{
				z0ZzZzzlh z0ZzZzzlh2 = z0ZzZzkuk[j];
				if (z0ZzZzzlh2.z0xrk() > z0ZzZzwrj.z0irk() - 2f || z0ZzZzzlh2.z0lrk() > z0ZzZzwrj.z0irk() + 2f)
				{
					z0ZzZzzlh z0ZzZzzlh3 = z0ZzZzkuk.SafeGet(j + p1);
					if (z0ZzZzzlh3 == null || !(z0ZzZzzlh3.z0xrk() < z0ZzZzwrj.z0qrk() - 2f))
					{
						break;
					}
					return z0ZzZzzlh3;
				}
			}
		}
		return null;
	}

	public XTextElementList z0eek()
	{
		XTextElementList xTextElementList = new XTextElementList();
		if (z0ntk != null && z0ntk.Count > 0)
		{
			int count = z0ntk.Count;
			for (int i = 0; i < count; i++)
			{
				if (z0ntk[i] is XTextSectionElement)
				{
					((zzz.z0ZzZzkuk<XTextElement>)xTextElementList).z0pek(z0ntk[i]);
				}
			}
		}
		return xTextElementList;
	}

	public void ExecuteLayout()
	{
		z0ct();
	}

	public float GetRemainSpacingInLastPage()
	{
		z0ZzZzwrj z0ZzZzwrj = z0jr().z0suk().z0tek();
		return z0ZzZzwrj.z0irk() + z0ZzZzwrj.z0urk() - z0xtk();
	}

	private static void z0eek(XTextContentElement p0)
	{
		if (!p0.z0wrk())
		{
			return;
		}
		z0ZzZzpdh z0ZzZzpdh = p0.z0zw();
		float p1 = z0ZzZzpdh.z0rek();
		float p2 = z0ZzZzpdh.z0tek();
		z0ZzZzzlh[] array = p0.z0zek();
		int num = p0.z0zek().Length;
		for (int i = 0; i < num; i++)
		{
			z0ZzZzzlh z0ZzZzzlh = array[i];
			z0ZzZzzlh.z0tek(p1, p2);
			if (z0ZzZzzlh.z0jrk_jiejie20260327142557())
			{
				XTextTableElement xTextTableElement = z0ZzZzzlh.z0ntk();
				XTextElement[] array2 = ((zzz.z0ZzZzkuk<XTextElement>)xTextTableElement.z0stk()).z0krk();
				int count = xTextTableElement.z0stk().Count;
				for (int j = 0; j < count; j++)
				{
					XTextTableRowElement xTextTableRowElement = (XTextTableRowElement)array2[j];
					if (!xTextTableRowElement.z0cuk)
					{
						continue;
					}
					XTextElement[] array3 = ((zzz.z0ZzZzkuk<XTextElement>)xTextTableRowElement.z0rek()).z0krk();
					int count2 = xTextTableRowElement.z0rek().Count;
					for (int k = 0; k < count2; k++)
					{
						XTextTableCellElement xTextTableCellElement = (XTextTableCellElement)array3[k];
						if (xTextTableCellElement.z0yi())
						{
							z0eek(xTextTableCellElement);
						}
					}
				}
			}
			else if (z0ZzZzzlh.z0qtk())
			{
				z0eek(z0ZzZzzlh.z0mek());
			}
		}
	}

	public override string z0ge()
	{
		return "Body";
	}

	private void z0eek(z0ZzZzvxj p0)
	{
		if (!p0.z0rek() || !z0eek(p0.z0byk))
		{
			return;
		}
		z0ZzZzzej z0ZzZzzej = z0ju();
		if (z0ZzZzzej == null || !z0ZzZzzej.z0uek() || z0ZzZzzej.z0zek() <= 0f || p0.z0iek() == PageContentPartyStyle.HeaderRows)
		{
			return;
		}
		z0ZzZzbdh z0ZzZzbdh = p0.z0nek();
		z0ZzZzbdh z0ZzZzbdh2 = p0.z0hrk();
		if (!p0.z0hrk().z0bek())
		{
			z0ZzZzbdh = z0ZzZzbdh.z0yek(z0ZzZzbdh, p0.z0hrk());
		}
		else
		{
			z0ZzZzbdh2 = z0ZzZzbdh;
		}
		z0ZzZzbdh = z0ZzZzbdh.z0tek(z0qyk(), z0ZzZzbdh);
		if (z0ZzZzbdh.z0bek())
		{
			return;
		}
		List<float[]> list = null;
		if (z0cek())
		{
			list = new List<float[]>();
			using (zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = z0be().z0ltk())
			{
				while (z0bpk.MoveNext())
				{
					XTextElement current = z0bpk.Current;
					if (!(current is XTextTableElement) || !current.z0yi())
					{
						continue;
					}
					using zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk2 = current.z0be().z0ltk();
					while (z0bpk2.MoveNext())
					{
						XTextTableRowElement xTextTableRowElement = (XTextTableRowElement)z0bpk2.Current;
						if (!xTextTableRowElement.z0yi() || !xTextTableRowElement.HeaderStyle)
						{
							continue;
						}
						float num = ((XTextElement)xTextTableRowElement).z0ltk();
						if (list.Count > 0)
						{
							float[] array = list[list.Count - 1];
							if ((double)num <= (double)array[1] + 0.1)
							{
								array[1] = num + xTextTableRowElement.Height + 0.2f;
								continue;
							}
						}
						list.Add(new float[2]
						{
							num - 0.1f,
							num + xTextTableRowElement.Height + 0.2f
						});
					}
				}
			}
			if (list.Count == 0)
			{
				list = null;
			}
		}
		z0bvk z0bvk = null;
		bool flag = z0ZzZzzej != null && z0ZzZzzej == z0jr().z0qxk;
		if (!flag)
		{
			z0bvk = z0tek();
		}
		float num2 = z0ZzZzzej.z0zek();
		float num3 = 0f;
		object p1 = p0.z0gyk.z0bek();
		p0.z0gyk.z0rek();
		using (z0ZzZzudh z0ZzZzudh = z0ZzZzzej.z0tek())
		{
			if (p0.z0zrk)
			{
				z0ZzZzudh.z0eek(Color.Black);
			}
			bool specifyDebugMode = z0bu().SpecifyDebugMode;
			float num4 = z0jr().z0umk();
			float num5 = z0ZzZzbdh2.z0nek();
			float num6 = z0ZzZzbdh.z0pek();
			for (; num3 < num5; num3 += num2)
			{
				if (!(num3 >= num6))
				{
					continue;
				}
				if (list != null)
				{
					int num7 = list.Count - 1;
					while (num7 >= 0)
					{
						float[] array2 = list[num7];
						if (!(num3 >= array2[0]) || !(num3 <= array2[1]))
						{
							num7--;
							continue;
						}
						goto IL_02f3;
					}
				}
				if (flag || !z0bvk.z0eek(num3))
				{
					p0.z0gyk.z0eek(z0ZzZzudh, z0ZzZzbdh.z0oek(), num3 + num4, z0ZzZzbdh.z0mek(), num3 + num4);
					if (specifyDebugMode)
					{
						p0.z0gyk.z0eek(num3.ToString(), z0ZzZzimk.z0eek(), Color.Blue, z0ZzZzbdh.z0oek() - 100f, num3);
					}
				}
				IL_02f3:;
			}
		}
		list?.Clear();
		p0.z0gyk.z0eek(p1);
	}

	internal new void z0rek()
	{
		z0eek(this);
	}

	private new z0bvk z0tek()
	{
		if (z0iek == null)
		{
			z0iek = new z0bvk(this);
		}
		return z0iek;
	}

	public override void z0vw(z0ZzZzvxj p0)
	{
		if (((XTextContentElement)this).z0wrk())
		{
			if ((p0.z0byk == (z0ZzZzcxj)0 || p0.z0byk == (z0ZzZzcxj)2) && z0iu().ShowLineNumber)
			{
				z0rek(p0);
			}
			p0.z0brk = z0frk();
			z0ZzZzvxj p1 = p0.z0cek();
			z0eek(p0);
			base.z0vw(p1);
			if (z0jr().z0wck && p0.z0rtk.ShowPageLine)
			{
				p0.z0gyk.z0rek();
			}
		}
	}

	public z0ZzZzlkh GetLinesInPageIndex(int pageIndex)
	{
		pageIndex--;
		if (pageIndex >= 0 && pageIndex < z0jr().z0suk().Count)
		{
			return GetLinesInPage(z0jr().z0suk()[pageIndex]);
		}
		return null;
	}

	public override PageContentPartyStyle z0fu()
	{
		return PageContentPartyStyle.Body;
	}

	private void z0rek(z0ZzZzvxj p0)
	{
		z0ZzZzbdh z0ZzZzbdh = p0.z0nek();
		z0ZzZzbdh p1 = new z0ZzZzbdh(-150f, z0ZzZzbdh.z0pek(), 150f, z0ZzZzbdh.z0iek());
		if (!p0.z0eek(p1))
		{
			return;
		}
		z0ZzZzbdh z0ZzZzbdh2 = p0.z0nek();
		List<z0ZzZzbdh> list = new List<z0ZzZzbdh>();
		z0ZzZzzlh[] array = ((XTextContentElement)this).z0zek();
		foreach (z0ZzZzzlh z0ZzZzzlh in array)
		{
			z0ZzZzbdh z0ZzZzbdh3 = z0eek(z0ZzZzzlh, p0);
			if (z0ZzZzbdh3.z0bek())
			{
				continue;
			}
			if (z0ZzZzbdh3.z0pek() > z0ZzZzbdh2.z0nek() + 1f)
			{
				break;
			}
			if (z0ZzZzzlh.z0qtk() && !z0ZzZzzlh.z0mek().IsCollapsed)
			{
				z0ZzZzzlh[] array2 = z0ZzZzzlh.z0mek().z0zek();
				foreach (z0ZzZzzlh p2 in array2)
				{
					z0ZzZzbdh z0ZzZzbdh4 = z0eek(p2, p0);
					if (!z0ZzZzbdh4.z0bek())
					{
						if (z0ZzZzbdh4.z0pek() > z0ZzZzbdh2.z0nek() + 1f)
						{
							break;
						}
						list.Add(z0ZzZzbdh4);
					}
				}
			}
			else
			{
				if (z0ZzZzzlh.z0rtk())
				{
					break;
				}
				list.Add(z0ZzZzbdh3);
			}
		}
		using z0ZzZzlsh z0ZzZzlsh = new z0ZzZzlsh();
		z0ZzZzlsh.z0rek(StringAlignment.Center);
		z0ZzZzlsh.z0eek(StringAlignment.Center);
		z0ZzZzlsh.z0eek((z0ZzZzksh)4096);
		z0ZzZzimk font = z0jr().z0gnk().Default.Font;
		for (int k = 0; k < list.Count; k++)
		{
			z0ZzZzbdh p3 = list[k];
			if (p3.z0nek() >= z0ZzZzbdh.z0pek() - 1f && p3.z0pek() < z0ZzZzbdh2.z0nek() - 1f)
			{
				p0.z0gyk.z0eek(Convert.ToString(k + 1), font, Color.Black, p3, z0ZzZzlsh);
			}
		}
	}

	public bool z0eek(z0ZzZzcxj p0)
	{
		z0ZzZzzej z0ZzZzzej = z0ju();
		if (z0ZzZzzej != null && z0ZzZzzej.z0uek() && z0ZzZzzej.z0zek() > 0f)
		{
			if (!z0ZzZzzej.z0yek() && p0 == (z0ZzZzcxj)3)
			{
				return false;
			}
			return true;
		}
		bool result = false;
		DocumentViewOptions documentViewOptions = z0iu();
		if (documentViewOptions != null && documentViewOptions.ShowGridLine)
		{
			result = true;
			if ((p0 == (z0ZzZzcxj)3 || p0 == (z0ZzZzcxj)2) && !documentViewOptions.PrintGridLine)
			{
				result = false;
			}
		}
		return result;
	}

	public override void Dispose()
	{
		base.Dispose();
		z0yek();
	}

	private z0ZzZzbdh z0eek(z0ZzZzzlh p0, z0ZzZzvxj p1)
	{
		z0ZzZzbdh z0ZzZzbdh = new z0ZzZzbdh(-150f, p0.z0xrk(), 150f, p0.z0ytk());
		if (!p1.z0hrk().z0bek())
		{
			z0ZzZzbdh p2 = p1.z0hrk();
			if (p1.z0lrk() != null)
			{
				p2.z0yek(p1.z0lrk().z0xek());
			}
			if (z0ZzZzbdh.z0tek(p2, z0ZzZzbdh).z0iek() < 2f)
			{
				return z0ZzZzbdh.z0xek;
			}
			float num = Math.Min(p2.z0nek(), z0ZzZzbdh.z0nek());
			float num2 = Math.Max(p2.z0pek(), z0ZzZzbdh.z0pek());
			z0ZzZzbdh.z0rek(num2);
			z0ZzZzbdh.z0yek(num - num2);
		}
		return z0ZzZzbdh;
	}

	public override PageContentPartyStyle z0du()
	{
		return PageContentPartyStyle.Body;
	}

	internal new void z0yek()
	{
		if (z0iek != null)
		{
			z0iek.z0eek();
			z0iek = null;
		}
	}

	public override z0ZzZzpdh z0zw()
	{
		XTextDocument xTextDocument = z0jr();
		if (xTextDocument == null)
		{
			return new z0ZzZzpdh(0f, 0f);
		}
		return new z0ZzZzpdh(xTextDocument.z0it(), xTextDocument.z0iik() + xTextDocument.z0yt());
	}

	public override string z0xr()
	{
		string text = "Body";
		if (z0jr() != null)
		{
			text = text + ":" + z0jr().z0zrk();
		}
		return text;
	}

	public new XTextTableElement z0uek()
	{
		if (z0ntk != null && z0ntk.Count > 0)
		{
			int num = Math.Min(100, z0ntk.Count);
			for (int i = 0; i < num; i++)
			{
				if (z0ntk[i] is XTextTableElement xTextTableElement && xTextTableElement.z0yi() && xTextTableElement.Width >= Width - 1000f && xTextTableElement.Height > 5000f)
				{
					return xTextTableElement;
				}
			}
		}
		return null;
	}

	public z0ZzZzlkh GetLinesInPage(z0ZzZzwrj page)
	{
		z0ZzZzlkh z0ZzZzlkh = new z0ZzZzlkh();
		using zzz.z0ZzZzkuk<z0ZzZzzlh>.z0bpk z0bpk = z0rrk().z0ltk();
		while (z0bpk.MoveNext())
		{
			z0ZzZzzlh current = z0bpk.Current;
			if (current.z0dtk() == page)
			{
				z0ZzZzlkh.Add(current);
			}
		}
		return z0ZzZzlkh;
	}

	public override float z0cw()
	{
		XTextDocument xTextDocument = z0jr();
		if (xTextDocument == null)
		{
			return 0f;
		}
		return xTextDocument.z0iik() + xTextDocument.z0yt();
	}

	public override string z0hu()
	{
		return "Body:" + base.z0hu();
	}

	public override z0ZzZzzej z0ju()
	{
		if (z0jr() != null)
		{
			return z0jr().PageSettings.z0dtk();
		}
		return null;
	}
}
