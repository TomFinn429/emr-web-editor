using System;
using System.Collections.Generic;
using DCSoft.Printing;
using DCSoft.Writer.Dom;

namespace zzz;

public class z0ZzZzszj : IDisposable
{
	internal List<XTextTableRowElement> z0nek = new List<XTextTableRowElement>();

	private XTextElementList z0bek = new XTextElementList();

	public bool z0vek;

	public bool z0cek;

	public XPageSettings z0xek;

	public int z0zek;

	private XTextElement z0lrk;

	internal List<XTextTableCellElement> z0krk = new List<XTextTableCellElement>();

	internal Dictionary<XTextTableElement, XTextElement[]> z0jrk = new Dictionary<XTextTableElement, XTextElement[]>();

	public bool z0hrk;

	internal float z0grk;

	public XTextElement z0frk;

	private XTextElementList z0drk = new XTextElementList();

	internal z0ZzZzlkh z0srk;

	internal bool z0ark;

	public float z0qrk = 50f;

	public float z0wrk;

	private List<XTextPageBreakElement> z0erk;

	public bool z0rrk;

	public bool z0trk;

	public bool z0yrk;

	public int z0urk;

	public PageViewMode z0irk;

	public float z0ork;

	public void Dispose()
	{
		if (z0nek != null)
		{
			z0nek.Clear();
			z0nek = null;
		}
		if (z0krk != null)
		{
			z0krk.Clear();
			z0krk = null;
		}
		z0srk = null;
		z0xek = null;
		if (z0jrk != null)
		{
			z0jrk.Clear();
			z0jrk = null;
		}
		z0frk = null;
		z0drk = null;
		z0erk = null;
		z0lrk = null;
		z0bek = null;
	}

	public z0ZzZzzlh z0rek()
	{
		if (z0lrk == null)
		{
			return null;
		}
		return z0lrk.z0ptk();
	}

	public XTextElementList z0tek()
	{
		return z0bek;
	}

	internal void z0rek(XTextTableCellElement p0)
	{
		if (p0 != null && !z0yrk)
		{
			float num = p0.z0cw();
			if (p0.z0bek())
			{
				p0 = p0.z0hrk();
				num = p0.z0cw();
			}
			if (num < z0oek() - 10f && num + p0.Height > z0oek() + 10f && ((XTextContentElement)p0).z0wrk() && z0srk.z0tek(((XTextContentElement)p0).z0zek().z0yek()) && num + ((XTextContentElement)p0).z0zek()[0].z0zrk() + ((XTextContentElement)p0).z0hrk() > z0oek() + 3f && !z0krk.Contains(p0))
			{
				z0krk.Add(p0);
			}
		}
	}

	public void z0rek(XTextElementList p0)
	{
		z0bek = p0;
	}

	public z0ZzZzszj z0yek()
	{
		return (z0ZzZzszj)MemberwiseClone();
	}

	internal XTextElement[] z0rek(XTextTableElement p0)
	{
		XTextElement[] array = null;
		if (!z0jrk.TryGetValue(p0, out array))
		{
			array = p0.z0jtk();
			z0jrk[p0] = array;
		}
		return array;
	}

	public void z0eek(List<XTextPageBreakElement> p0)
	{
		z0erk = p0;
	}

	internal void z0tek(XTextElementList p0)
	{
		z0drk = p0;
	}

	public void z0uek()
	{
		if (z0jrk != null)
		{
			z0jrk.Clear();
			z0jrk = null;
		}
		z0drk = null;
		z0erk = null;
		z0xek = null;
		z0lrk = null;
		z0bek = null;
	}

	internal XTextElementList z0iek()
	{
		return z0drk;
	}

	public float z0oek()
	{
		return z0grk;
	}

	internal void z0rek(XTextTableRowElement p0)
	{
		if (p0 == null || z0yrk || z0nek.Contains(p0))
		{
			return;
		}
		z0nek.Add(p0);
		float num = p0.z0cw();
		bool flag = z0grk - num < 100f;
		for (int num2 = p0.z0rek().Count - 1; num2 >= 0; num2--)
		{
			XTextTableCellElement xTextTableCellElement = (XTextTableCellElement)p0.z0rek()[num2];
			if (z0tek() == null || !z0tek().Contains(xTextTableCellElement))
			{
				float num3 = num;
				if (xTextTableCellElement.z0bek())
				{
					xTextTableCellElement = xTextTableCellElement.z0hrk();
					num3 = xTextTableCellElement.z0cw();
					flag = false;
				}
				if (((XTextContentElement)xTextTableCellElement).z0wrk() && z0srk.z0tek(((XTextContentElement)xTextTableCellElement).z0zek().z0yek()))
				{
					z0ZzZzzlh[] array = ((XTextContentElement)xTextTableCellElement).z0zek();
					float num4 = array[0].z0zrk();
					float num5 = xTextTableCellElement.Height - array.z0uek().z0ark();
					if (z0grk >= num3 + num4 && z0grk <= num3 + xTextTableCellElement.Height - num5)
					{
						if (flag)
						{
							z0ZzZzzlh[] array2 = array;
							foreach (z0ZzZzzlh z0ZzZzzlh2 in array2)
							{
								if (z0grk >= num3 + z0ZzZzzlh2.z0zrk() + 3f && z0grk < num3 + z0ZzZzzlh2.z0zrk() + z0ZzZzzlh2.z0ytk() - 3f)
								{
									if (!(z0grk - num3 - z0ZzZzzlh2.z0zrk() > num5) || !(num3 + z0ZzZzzlh2.z0zrk() + z0ZzZzzlh2.z0ytk() - z0grk > num4))
									{
										break;
									}
									if (p0 == p0.z0gr().z0stk().z0krk())
									{
										z0grk = p0.z0gr().z0ptk().z0xrk();
									}
									else
									{
										z0grk = num3;
									}
									z0bek?.Clear();
									z0lrk = p0;
									return;
								}
							}
						}
						if (!z0krk.Contains(xTextTableCellElement))
						{
							z0krk.Add(xTextTableCellElement);
						}
					}
				}
			}
		}
	}

	public XTextElement z0pek()
	{
		return z0lrk;
	}

	public List<XTextPageBreakElement> z0mek()
	{
		return z0erk;
	}

	public void z0rek(XTextElement p0)
	{
		z0lrk = p0;
		if (p0 != null && !z0bek.Contains(p0))
		{
			p0.z0jy();
			z0bek.Add(p0);
		}
	}

	public void z0rek(float p0)
	{
		if (z0grk > p0)
		{
			z0grk = p0;
			z0trk = true;
		}
	}

	public void z0rek(XTextElement[] p0)
	{
		z0drk.z0tek(p0);
	}
}
