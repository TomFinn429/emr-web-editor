using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using DCSoft.Drawing;
using DCSoft.WinForms;
using DCSoft.Writer;
using DCSoft.Writer.Dom;
using DCSystem_Drawing;

namespace zzz;

[DebuggerTypeProxy(typeof(z0ZzZzkik))]
[DebuggerDisplay("Count={ Count }")]
public class z0ZzZzzlh : XTextElementList
{
	private int z0dyk_jiejie20260327142557;

	private float z0syk;

	internal XTextContentElement z0ayk;

	private DocumentContentAlignment z0qyk;

	private float z0wyk = -1f;

	private int z0eyk_jiejie20260327142557;

	private XTextParagraphFlagElement z0ryk;

	private float z0tyk = -1234568f;

	private float z0yyk;

	private VerticalAlignStyle z0uyk = VerticalAlignStyle.Bottom;

	private float z0iyk;

	private float z0oyk = -1234568f;

	internal float z0pyk;

	private float z0myk;

	private float z0byk;

	internal float z0vyk;

	private static float z0cyk = 3.125f;

	public static float z0xyk = 0f;

	internal int z0zyk;

	private float z0luk;

	private float z0kuk;

	internal z0ZzZzwrj z0guk;

	public static bool z0fuk = true;

	public static readonly z0ZzZzzlh[] z0duk = Array.Empty<z0ZzZzzlh>();

	private float z0suk;

	private float z0auk;

	[ThreadStatic]
	private static XTextElement[] z0quk = null;

	private XTextElement z0wuk;

	internal XTextDocument z0euk;

	[ThreadStatic]
	private static XTextCharElement[] z0ruk = null;

	internal int z0tuk = -1;

	private void z0eek(XTextElement p0)
	{
		if (p0 is XTextTableElement || p0 is XTextSectionElement || p0 is XTextPageBreakElement)
		{
			z0wuk = p0;
		}
	}

	public void z0eek(float p0)
	{
		if (z0suk != p0)
		{
			z0suk = p0;
			z0yek(p0: true);
		}
	}

	public bool z0eek()
	{
		if (z0jrk_jiejie20260327142557())
		{
			z0ntk().z0hr();
			return true;
		}
		XTextDocumentContentElement xTextDocumentContentElement = base[0].z0qek();
		int num = xTextDocumentContentElement.z0frk().IndexOf(base.z0grk());
		int num2 = xTextDocumentContentElement.z0frk().IndexOf(base.z0lrk());
		if (num >= 0 && num2 >= 0)
		{
			xTextDocumentContentElement.z0frk().z0iek(p0: true);
			bool num3 = xTextDocumentContentElement.z0uek(num, num2 - num + 1);
			if (num3)
			{
				z0ZzZzdbj obj = xTextDocumentContentElement.z0cu();
				if (obj == null)
				{
					return num3;
				}
				obj.z0eek(ScrollToViewStyle.Top);
			}
			return num3;
		}
		return false;
	}

	public z0ZzZzzlh z0rek()
	{
		if (z0ayk != null && z0ayk.z0qek() != null)
		{
			z0ZzZzlkh z0ZzZzlkh2 = z0ayk.z0qek().z0rrk();
			if (z0ZzZzlkh2 != null && z0ZzZzlkh2.Count > 0)
			{
				int num = z0tuk;
				if (num < 0 || num >= z0ZzZzlkh2.Count || z0ZzZzlkh2[num] != this)
				{
					num = z0ZzZzlkh2.IndexOf(this);
				}
				if (num >= 0 && num < z0ZzZzlkh2.Count - 1)
				{
					return z0ZzZzlkh2[num + 1];
				}
			}
		}
		return null;
	}

	public void z0rek(float p0)
	{
		z0syk = p0;
	}

	internal bool z0tek()
	{
		return base.z0pek(8);
	}

	public z0ZzZzpdh z0yek()
	{
		if (z0oyk == -1234568f || z0tyk == -1234568f)
		{
			if (z0euk == null)
			{
				z0oyk = z0syk;
				z0tyk = z0kuk;
			}
			else if (z0ayk == null)
			{
				z0oyk = z0syk + z0euk.z0it();
				z0tyk = z0kuk + z0euk.z0yt();
			}
			else
			{
				z0ZzZzpdh z0ZzZzpdh2 = z0ayk.z0zw();
				z0oyk = z0syk + z0ZzZzpdh2.z0rek();
				z0tyk = z0kuk + z0ZzZzpdh2.z0tek();
			}
		}
		return new z0ZzZzpdh(z0oyk, z0tyk);
	}

	internal bool z0uek_jiejie20260327142557()
	{
		return base.z0pek(256);
	}

	internal bool z0iek()
	{
		return base.z0pek(512);
	}

	private bool z0eek(int p0, int p1, float p2, float p3, bool p4, bool p5)
	{
		if (p1 == 0)
		{
			return false;
		}
		XTextDocument xTextDocument = z0srk();
		bool flag = xTextDocument.z0gnk().z0pek;
		bool flag2 = z0etk();
		XTextParagraphFlagElement xTextParagraphFlagElement = base[0] as XTextParagraphFlagElement;
		z0ZzZzrzj z0ZzZzrzj2 = z0ryk?.z0aek();
		bool flag3 = xTextDocument.z0kyk();
		float num = 100000000f;
		XTextElementList xTextElementList = null;
		if (flag2)
		{
			if (z0ZzZzrzj2.z0cyk == LineSpacingStyle.SpaceSpecify)
			{
				num = z0ZzZzrzj2.z0eek(0f, 0f, GraphicsUnit.Document);
			}
			xTextElementList = this;
		}
		else
		{
			if (!z0jrk_jiejie20260327142557() && !z0qtk() && z0grk() != null && z0ZzZzrzj2.z0cyk == LineSpacingStyle.SpaceSpecify)
			{
				num = z0ZzZzrzj2.z0eek(0f, 0f, GraphicsUnit.Document);
			}
			XTextElementList xTextElementList2 = z0urk();
			if (p0 == 0 && p1 == xTextElementList2.Count)
			{
				xTextElementList = xTextElementList2;
			}
			else
			{
				xTextElementList = new XTextElementList(p1);
				for (int i = 0; i < p1; i++)
				{
					((zzz.z0ZzZzkuk<XTextElement>)xTextElementList).z0pek(xTextElementList2[i + p0]);
				}
			}
			if (base.LastElement is XTextLineBreakElement xTextLineBreakElement)
			{
				xTextLineBreakElement.z0eek(SafeGet(base.Count - 2));
			}
		}
		if (z0ruk == null || z0ruk.Length < xTextElementList.Count)
		{
			z0ruk = new XTextCharElement[xTextElementList.Count];
		}
		XTextCharElement[] array = z0ruk;
		XTextElement[] array2 = ((zzz.z0ZzZzkuk<XTextElement>)xTextElementList).z0krk();
		for (int num2 = xTextElementList.Count - 1; num2 >= 0; num2--)
		{
			array[num2] = array2[num2] as XTextCharElement;
		}
		float num3 = -1f;
		float num4 = 10f;
		if (z0crk())
		{
			num4 = xTextDocument.z0dik().z0iek();
		}
		List<XTextElement> list = null;
		int num5 = p1;
		if (!flag2 && p4)
		{
			for (int num6 = p1 - 1; num6 >= 0; num6--)
			{
				XTextCharElement xTextCharElement = array[num6];
				if (xTextCharElement == null || xTextCharElement.z0bek != ' ')
				{
					break;
				}
				num5--;
				xTextCharElement.z0lrk = 0f;
			}
			if ((double)num5 < (double)p1 * 0.8)
			{
				num5 = p1;
			}
		}
		DocumentContentAlignment documentContentAlignment = z0ZzZzrzj2.z0tuk;
		float num7 = 0f;
		float num8 = 1f;
		if (z0ayk is XTextTableCellElement)
		{
			num8 = ((XTextContentElement)(XTextTableCellElement)z0ayk).z0drk();
		}
		if (flag2)
		{
			num7 = xTextParagraphFlagElement.z0bi() + z0ZzZzrzj2.z0mtk;
			if (xTextParagraphFlagElement.z0vi() > num4)
			{
				num4 = xTextParagraphFlagElement.z0vi();
			}
		}
		else
		{
			for (int j = 0; j < num5; j++)
			{
				XTextElement xTextElement = array2[j];
				if (array[j] == null)
				{
					if (xTextElement is XTextFieldBorderElement)
					{
						XTextFieldBorderElement xTextFieldBorderElement = (XTextFieldBorderElement)xTextElement;
						if (string.IsNullOrEmpty(xTextFieldBorderElement.Text) && string.IsNullOrEmpty(xTextFieldBorderElement.z0vek()))
						{
							XTextElement xTextElement2 = null;
							xTextElement2 = ((xTextFieldBorderElement.z0mek() != 0) ? xTextElementList.SafeGet(j - 1) : xTextElementList.SafeGet(j + 1));
							if (xTextElement2 is XTextFieldBorderElement)
							{
								xTextElement2 = null;
								for (int num9 = j - 1; num9 >= 0; num9--)
								{
									if (!(xTextElementList[num9] is XTextFieldBorderElement))
									{
										xTextElement2 = xTextElementList[num9];
										break;
									}
								}
								if (xTextElement2 == null)
								{
									for (int k = j + 1; k < xTextElementList.Count; k++)
									{
										if (!(xTextElementList[k] is XTextFieldBorderElement))
										{
											xTextElement2 = xTextElementList[k];
											break;
										}
									}
								}
							}
							if (xTextElement2 is XTextObjectElement && xTextElement2.z0ci() != ElementZOrderStyle.Normal)
							{
								xTextElement2 = null;
								if (xTextFieldBorderElement.z0mek() == (z0ZzZzzvj)0)
								{
									for (int l = j + 2; l < xTextElementList.Count; l++)
									{
										XTextElement xTextElement3 = xTextElementList[l];
										if (xTextElement3 is XTextFieldBorderElement)
										{
											break;
										}
										if (!(xTextElement3 is XTextObjectElement) || xTextElement3.z0ci() == ElementZOrderStyle.Normal)
										{
											xTextElement2 = xTextElement3;
											break;
										}
									}
								}
								else
								{
									for (int num10 = j - 2; num10 >= 0; num10--)
									{
										XTextElement xTextElement4 = xTextElementList[num10];
										if (xTextElement4 is XTextFieldBorderElement)
										{
											break;
										}
										if (!(xTextElement4 is XTextObjectElement) || xTextElement4.z0ci() == ElementZOrderStyle.Normal)
										{
											xTextElement2 = xTextElement4;
											break;
										}
									}
								}
							}
							if (xTextElement2 == null || xTextElement2 is XTextFieldBorderElement)
							{
								xTextFieldBorderElement.Height = num8 * xTextFieldBorderElement.z0iek();
							}
							else
							{
								xTextFieldBorderElement.Height = num8 * Math.Max(xTextElement2.Height, xTextFieldBorderElement.z0iek());
							}
						}
					}
					else if (xTextElement is XTextPageBreakElement)
					{
						xTextElement.Width = z0jyk_jiejie20260327142557() - 20f;
						if (xTextElement.Height == 0f)
						{
							xTextElement.Height = num8 * z0ftk();
						}
					}
					else if (j > 1)
					{
						if (xTextElement is XTextLineBreakElement)
						{
							((XTextLineBreakElement)xTextElement).z0eek(array2[j - 1]);
						}
						else if (xTextElement is XTextParagraphFlagElement && DocumentBehaviorOptions.z0rrk)
						{
							XTextElement xTextElement5 = array2[j - 1];
							if (xTextElement5 is XTextFieldBorderElement)
							{
								if (j > 2)
								{
									XTextElement xTextElement6 = base[j - 2];
									if (xTextElement.Height > xTextElement6.Height && (double)xTextElement6.Height > 0.1)
									{
										xTextElement.Height = xTextElement6.Height;
									}
								}
							}
							else if (xTextElement.Height > xTextElement5.Height && (double)xTextElement5.Height > 0.1)
							{
								xTextElement.Height = xTextElement5.Height;
							}
						}
					}
				}
				z0ZzZzrzj z0ZzZzrzj3 = xTextElement.z0ruk;
				if (z0ZzZzrzj3 == null)
				{
					z0ZzZzrzj3 = xTextElement.z0aek();
				}
				num7 = ((!flag) ? (num7 + xTextElement.z0bi()) : (num7 + xTextElement.z0bi() + z0ZzZzrzj3.z0mtk));
				xTextElement.z0mt(0f);
				if (z0ZzZzrzj3.z0xyk == ContentLayoutAlign.EmbedInText)
				{
					if (xTextElement.z0vi() > num4)
					{
						num4 = xTextElement.z0vi();
					}
					continue;
				}
				if (list == null)
				{
					list = new List<XTextElement>();
				}
				list.Add(xTextElement);
			}
			for (int num11 = xTextElementList.Count - 1; num11 >= num5; num11--)
			{
				if (array2[num11].z0ruk == null)
				{
					array2[num11].z0btk();
				}
			}
			if (num5 > 1 && flag)
			{
				num7 -= xTextElementList[num5 - 1].z0ruk.z0mtk;
			}
			if (num4 > num)
			{
				num4 = num;
			}
		}
		num3 = (float)Math.Ceiling(num4 + z0cyk);
		if (num3 > z0wyk)
		{
			z0yek(num3);
		}
		float num12 = z0vyk;
		num12 = ((!(z0suk > 0f)) ? (z0cyk + z0byk) : (z0cyk + z0byk + (z0suk - num3) / 2f));
		if (!flag2)
		{
			if (z0mtk())
			{
				num12 = z0cyk;
			}
			else if (z0rtk())
			{
				num12 = z0cyk;
			}
		}
		z0vyk = num12;
		bool flag4 = p1 > 1;
		if (flag4)
		{
			if (documentContentAlignment == DocumentContentAlignment.Distribute)
			{
				flag4 = true;
			}
			else if (xTextElementList.z0bek(p5))
			{
				flag4 = false;
			}
			else if (z0ayk.z0zek().z0uek() == this)
			{
				flag4 = false;
			}
			else if (z0wuk is XTextTableElement || z0wuk is XTextSectionElement)
			{
				flag4 = false;
			}
			else
			{
				XTextElementList xTextElementList3 = z0ayk.z0trk();
				if (xTextElementList3.SafeGet(xTextElementList3.z0vek(xTextElementList.LastElement) + 1) is XTextPageBreakElement)
				{
					flag4 = false;
				}
			}
		}
		DocumentContentAlignment documentContentAlignment2 = z0qyk;
		if (!flag2)
		{
			if (z0jrk_jiejie20260327142557())
			{
				XTextTableElement xTextTableElement = z0ntk();
				if (xTextTableElement.z0frk() == DCTableAlignment.Left)
				{
					documentContentAlignment2 = DocumentContentAlignment.Left;
				}
				else if (xTextTableElement.z0frk() == DCTableAlignment.Center)
				{
					documentContentAlignment2 = DocumentContentAlignment.Center;
				}
				else if (xTextTableElement.z0frk() == DCTableAlignment.Right)
				{
					documentContentAlignment2 = DocumentContentAlignment.Right;
				}
			}
			int count = xTextElementList.Count;
			if (flag)
			{
				for (int m = 0; m < count; m++)
				{
					XTextElement obj = array2[m];
					obj.z0mt(obj.z0ruk.z0mtk);
				}
			}
		}
		if (flag4)
		{
			float num13 = Math.Abs(p2 - p3) - num7;
			if (num13 > 0f)
			{
				if (num13 > 0f)
				{
					if (z0quk == null || z0quk.Length < num5)
					{
						z0quk = new XTextElement[num5];
					}
					XTextElement[] array3 = z0quk;
					int num14 = 0;
					int num15 = 0;
					for (int n = 0; n < num5 && array[n] != null; n++)
					{
						char c = array[n].z0bek;
						if (c != ' ' && c != '\t')
						{
							break;
						}
						num15 = n + 1;
					}
					if (num15 == -1)
					{
						p0 = 0;
					}
					bool flag5 = xTextDocument.z0gnk().z0vek;
					for (int num16 = num15; num16 < num5 - 1; num16++)
					{
						XTextElement xTextElement7 = array2[num16];
						if (flag5 && xTextElement7.z0ruk.z0wuk)
						{
							continue;
						}
						if (array[num16] != null)
						{
							XTextCharElement xTextCharElement2 = array[num16];
							if (!xTextCharElement2.z0oek() && xTextCharElement2.z0bek != '\t' && !z0ZzZzjzj.z0tek(xTextCharElement2.z0bek))
							{
								if (num16 == p1 - 1 && num14 > 0)
								{
									break;
								}
								array3[num14++] = xTextElement7;
							}
							continue;
						}
						if (xTextElement7 is XTextFieldBorderElement)
						{
							if (((XTextFieldBorderElement)xTextElement7).z0mek() == (z0ZzZzzvj)0)
							{
								continue;
							}
						}
						else if (xTextElement7 is XTextParagraphFlagElement)
						{
							continue;
						}
						array3[num14++] = xTextElement7;
					}
					if (num14 > 1 && array3[num14 - 1] == array2[num5 - 2] && array2[num5 - 1] is XTextParagraphFlagElement)
					{
						array3[num14 - 1] = null;
						num14--;
					}
					if (num14 > 0)
					{
						float num17 = num13 / (float)num14;
						if (flag)
						{
							for (int num18 = num14 - 1; num18 >= 0; num18--)
							{
								XTextElement obj2 = array3[num18];
								obj2.z0mt(obj2.z0aek().z0mtk + num17);
							}
						}
						else
						{
							for (int num19 = num14 - 1; num19 >= 0; num19--)
							{
								array3[num19].z0mt(num17);
							}
						}
						Array.Clear(array3, 0, num14);
					}
					num13 = 0f;
				}
				documentContentAlignment2 = DocumentContentAlignment.Justify;
			}
		}
		VerticalAlignStyle verticalAlignStyle = (z0uyk = z0vrk());
		if (!z0rrk() && !flag2 && verticalAlignStyle != VerticalAlignStyle.Top)
		{
			XTextLabelElement xTextLabelElement = null;
			int count2 = xTextElementList.Count;
			for (int num20 = 0; num20 < count2; num20++)
			{
				XTextElement xTextElement8 = array2[num20];
				if (xTextElement8 is XTextObjectElement)
				{
					if (!(xTextElement8 is XTextLabelElement))
					{
						xTextLabelElement = null;
						verticalAlignStyle = ((XTextObjectElement)xTextElement8).z0ay();
						break;
					}
					xTextLabelElement = (XTextLabelElement)xTextElement8;
				}
				if (xTextElement8 is XTextShapeInputFieldElement)
				{
					xTextLabelElement = null;
					verticalAlignStyle = ((XTextShapeInputFieldElement)xTextElement8).z0fw();
				}
			}
			if (xTextLabelElement != null)
			{
				verticalAlignStyle = xTextLabelElement.z0ay();
			}
		}
		z0uyk = verticalAlignStyle;
		float num21 = 0f;
		if (!flag2)
		{
			int count3 = xTextElementList.Count;
			for (int num22 = 0; num22 < count3; num22++)
			{
				XTextElement xTextElement9 = array2[num22];
				if (array[num22] != null)
				{
					if (num21 < xTextElement9.z0aik)
					{
						num21 = xTextElement9.z0aik;
					}
				}
				else if (xTextElement9 is XTextLabelElement)
				{
					if (num21 < xTextElement9.z0vi())
					{
						num21 = xTextElement9.z0vi();
					}
				}
				else if (xTextElement9 is XTextFieldBorderElement)
				{
					XTextFieldBorderElement xTextFieldBorderElement2 = (XTextFieldBorderElement)xTextElement9;
					if (num21 < xTextFieldBorderElement2.z0yek())
					{
						num21 = xTextFieldBorderElement2.z0yek();
					}
				}
			}
		}
		float num23 = Math.Abs(p2 - p3);
		p2 = Math.Min(p2, p3);
		float num24 = p2;
		switch (documentContentAlignment2)
		{
		case DocumentContentAlignment.Left:
			num24 = p2;
			break;
		case DocumentContentAlignment.Center:
			num24 = p2 + (num23 - num7) / 2f;
			if (num24 < p2)
			{
				num24 = p2;
			}
			break;
		case DocumentContentAlignment.Right:
			num24 = p2 + (num23 - num7);
			if (num24 < p2)
			{
				num24 = p2;
			}
			break;
		default:
			num24 = p2;
			break;
		}
		if (flag2)
		{
			if (xTextParagraphFlagElement.z0uek(num24, num12) && flag3)
			{
				xTextDocument.z0xek(xTextParagraphFlagElement);
			}
		}
		else
		{
			float num25 = num12;
			float num26 = verticalAlignStyle switch
			{
				VerticalAlignStyle.Top => num12, 
				VerticalAlignStyle.Middle => num12 + (num4 - num21) / 2f, 
				VerticalAlignStyle.Bottom => num12 + num4 - num21, 
				_ => num12 + num4 - num21, 
			} + num21;
			for (int num27 = 0; num27 < p1; num27++)
			{
				XTextElement xTextElement10 = array2[num27];
				float p6 = num24;
				float num28 = num12;
				float num29 = 0f;
				bool flag6 = array[num27] != null;
				if (list == null || !list.Contains(xTextElement10))
				{
					if (flag6)
					{
						num29 = num26 - xTextElement10.z0aik;
					}
					else if (xTextElement10 is XTextLabelElement)
					{
						num29 = num26 - xTextElement10.z0vi();
					}
					else
					{
						num29 = verticalAlignStyle switch
						{
							VerticalAlignStyle.Top => num12, 
							VerticalAlignStyle.Middle => num12 + (num4 - xTextElement10.z0vi()) / 2f, 
							VerticalAlignStyle.Bottom => num28 + num4 - xTextElement10.z0vi(), 
							_ => num28 + num4 - xTextElement10.z0vi(), 
						};
						if (xTextElement10 is XTextFieldBorderElement)
						{
							XTextFieldBorderElement xTextFieldBorderElement3 = (XTextFieldBorderElement)xTextElement10;
							if (xTextFieldBorderElement3.z0yek() > 0f)
							{
								xTextFieldBorderElement3.z0yek(num26 - xTextFieldBorderElement3.z0yek() - num29);
							}
						}
					}
				}
				else
				{
					num29 = num12;
				}
				if (xTextElement10.z0uek(p6, num29) && flag3 && !flag6)
				{
					xTextDocument.z0xek(xTextElement10);
				}
				num24 = ((!flag6) ? (num24 + (xTextElement10.z0bi() + xTextElement10.z0pt())) : (num24 + xTextElement10.z0ut()));
				if (list != null && list.Contains(xTextElement10))
				{
					xTextElement10.z0pyk().z0tek(z0stk(), z0zrk());
					if (z0ayk.z0oek()?.z0pek != null)
					{
						z0ayk.z0oek().z0pek[xTextElement10] = this;
					}
				}
			}
		}
		Array.Clear(array, 0, xTextElementList.Count);
		return true;
	}

	public bool z0oek()
	{
		return base.z0pek(128);
	}

	public new float z0pek()
	{
		float num = 0f;
		foreach (XTextElement item in base.z0xrk())
		{
			num += item.Width;
		}
		return num;
	}

	public void z0eek(int p0)
	{
		z0zyk = p0;
	}

	public new XTextSectionElement z0mek()
	{
		return z0wuk as XTextSectionElement;
	}

	public new float z0nek()
	{
		return z0syk + z0yyk;
	}

	public new bool z0bek()
	{
		if (z0ryk != null && Contains(z0ryk.z0iek()))
		{
			return true;
		}
		return false;
	}

	public void z0rek(int p0)
	{
		z0dyk_jiejie20260327142557 = p0;
	}

	public new float z0vek()
	{
		return z0auk;
	}

	public new VerticalAlignStyle z0cek()
	{
		return z0uyk;
	}

	internal new bool z0xek()
	{
		return z0wuk != null;
	}

	public new DocumentContentAlignment z0zek()
	{
		return z0qyk;
	}

	public new float z0lrk()
	{
		return z0xrk() + z0pyk;
	}

	private void z0rek(XTextElement p0)
	{
		if (!z0ayk.z0ork())
		{
			return;
		}
		XTextContentElement xTextContentElement = z0ayk;
		z0yek(-1f);
		XTextElement[] obj = xTextContentElement.z0oek()?.z0mek;
		z0ZzZzbdh p1 = new z0ZzZzbdh(z0stk() + z0itk(), z0zrk(), p0.Width, z0qrk());
		if (p0 is XTextParagraphFlagElement)
		{
			p1.z0tek(p0.Width / 4f);
		}
		XTextElement[] array = obj;
		foreach (XTextElement xTextElement in array)
		{
			if (Contains(xTextElement) || xTextElement == p0)
			{
				continue;
			}
			z0ZzZzzlh z0ZzZzzlh2 = xTextElement.z0ptk();
			if (z0ZzZzzlh2 == null && z0ayk.z0oek().z0pek.ContainsKey(xTextElement))
			{
				z0ZzZzzlh2 = z0ayk.z0oek().z0pek[xTextElement];
			}
			if (z0ZzZzzlh2 == null)
			{
				continue;
			}
			if (xTextContentElement.z0oek().z0pek.ContainsKey(xTextElement))
			{
				z0ZzZzzlh2 = xTextContentElement.z0oek().z0pek[xTextElement];
			}
			z0ZzZzbdh z0ZzZzbdh2 = xTextElement.z0pyk();
			z0ZzZzbdh2.z0tek(z0ZzZzzlh2.z0stk(), z0ZzZzzlh2.z0zrk());
			if (!z0ZzZzbdh2.z0tek(p1))
			{
				continue;
			}
			if (xTextContentElement.z0nrk())
			{
				foreach (z0ZzZzgkh item in xTextContentElement.z0yek())
				{
					z0ZzZzzlh z0ZzZzzlh3 = item.z0ptk();
					if (z0ZzZzzlh3 != null && xTextContentElement.z0zek().z0uek(z0ZzZzzlh3))
					{
						z0ZzZzzlh3.z0tek(p0: true);
					}
				}
			}
			z0ZzZzgkh z0ZzZzgkh2 = new z0ZzZzgkh(xTextElement);
			xTextContentElement.z0eek(z0ZzZzgkh2);
			z0ZzZzgkh2.z0yek(this);
			Add(z0ZzZzgkh2);
			z0oyk += z0ZzZzgkh2.Width;
		}
	}

	internal void z0eek(bool p0)
	{
		z0oek(4, p0);
	}

	public new z0ZzZzbdh z0krk()
	{
		return new z0ZzZzbdh(z0xtk(), z0xrk(), z0yyk, z0pyk);
	}

	public void z0tek(float p0)
	{
		if (z0pyk != p0)
		{
			z0pyk = p0;
			z0yek(p0: true);
		}
	}

	public bool z0jrk_jiejie20260327142557()
	{
		return z0wuk is XTextTableElement;
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder();
		foreach (XTextElement item in base.z0xrk())
		{
			stringBuilder.Append(item.ToString());
		}
		return stringBuilder.ToString();
	}

	private void z0yek(float p0)
	{
		z0wyk = p0;
	}

	private void z0rek(bool p0)
	{
		z0oek(64, p0);
	}

	public new int z0hrk()
	{
		return z0zyk;
	}

	public new XTextParagraphFlagElement z0grk()
	{
		return z0ryk;
	}

	internal void z0tek(bool p0)
	{
		z0oek(256, p0);
	}

	internal new void z0frk()
	{
		XTextElement[] array = ((zzz.z0ZzZzkuk<XTextElement>)this).z0krk();
		for (int num = base.Count - 1; num >= 0; num--)
		{
			if (array[num].z0kik == this)
			{
				array[num].z0kik = null;
			}
		}
		z0oyk = -1234568f;
		z0tyk = -1234568f;
		z0qyk = DocumentContentAlignment.Left;
		z0iek(p0: true);
		z0wyk = -1f;
		z0vyk = 0f;
		z0zyk = 0;
		z0uek_jiejie20260327142557(p0: false);
		z0rek(p0: false);
		z0pyk = 0f;
		z0oek(p0: true);
		z0dyk_jiejie20260327142557 = 0;
		z0tek(p0: false);
		z0pek(p0: true);
		z0yek(p0: false);
		z0syk = 0f;
		z0myk = 0f;
		z0ayk = null;
		z0euk = null;
		z0guk = null;
		z0auk = 0f;
		z0iyk = 0f;
		z0wuk = null;
		z0ryk = null;
		z0eyk_jiejie20260327142557 = 0;
		z0uyk = VerticalAlignStyle.Bottom;
		z0luk = 0f;
		z0byk = 0f;
		z0suk = 0f;
		z0kuk = 0f;
		z0eek(VerticalAlignStyle.Bottom);
		z0yyk = 0f;
	}

	public new float z0drk()
	{
		return z0ytk();
	}

	internal void z0yek(bool p0)
	{
		z0oek(512, p0);
	}

	internal void z0uek_jiejie20260327142557(float p0)
	{
		z0myk = p0;
	}

	public virtual XTextDocument z0srk()
	{
		return z0euk;
	}

	public new float z0ark()
	{
		return z0kuk + z0pyk;
	}

	internal void z0eek(float p0, float p1)
	{
		if (p0 != 0f)
		{
			z0syk += p0;
			if (z0oyk != -1234568f)
			{
				z0oyk += p0;
			}
		}
		if (p1 != 0f)
		{
			z0kuk += p1;
			if (z0tyk != -1234568f)
			{
				z0tyk += p1;
			}
		}
	}

	private new float z0qrk()
	{
		if (z0euk == null)
		{
			return 0f;
		}
		if (base.Count == 1 && base[0] is XTextParagraphFlagElement)
		{
			XTextElement xTextElement = base[0];
			float num = Math.Max(xTextElement.Height, z0euk.z0dik().z0mek());
			if (xTextElement.z0aek().z0cyk == LineSpacingStyle.SpaceSpecify)
			{
				num = Math.Min(num, xTextElement.z0aek().z0itk);
			}
			return num + z0cyk;
		}
		float num2 = 0f;
		XTextElement[] array = ((zzz.z0ZzZzkuk<XTextElement>)this).z0krk();
		int count = base.Count;
		for (int i = 0; i < count; i++)
		{
			XTextElement xTextElement2 = array[i];
			if (!(xTextElement2 is z0ZzZzgkh) && xTextElement2.z0aek().z0xyk == ContentLayoutAlign.EmbedInText)
			{
				num2 = Math.Max(xTextElement2.Height, num2);
			}
		}
		num2 = Math.Max(num2, z0srk().z0dik().z0mek());
		if (!z0jrk_jiejie20260327142557() && !z0qtk() && z0grk() != null)
		{
			z0ZzZzrzj z0ZzZzrzj2 = z0grk().z0aek();
			if (z0ZzZzrzj2.z0cyk == LineSpacingStyle.SpaceSpecify)
			{
				num2 = Math.Min(num2, z0ZzZzrzj2.z0itk);
			}
		}
		return num2 + z0cyk;
	}

	public new float z0wrk()
	{
		if (z0wyk < 0f)
		{
			z0yek(z0qrk());
		}
		return z0wyk;
	}

	internal void z0erk()
	{
		z0tyk = -1234568f;
		z0oyk = -1234568f;
	}

	internal bool z0rrk()
	{
		return base.z0pek(16);
	}

	internal float z0trk()
	{
		return z0myk;
	}

	internal static bool z0eek(z0ZzZzzlh p0, z0ZzZzzlh p1)
	{
		if (((zzz.z0ZzZzkuk<XTextElement>)p0).z0wtk != ((zzz.z0ZzZzkuk<XTextElement>)p1).z0wtk)
		{
			return false;
		}
		if (p1.z0uek_jiejie20260327142557())
		{
			return false;
		}
		if (p0.z0auk != p1.z0auk)
		{
			return false;
		}
		XTextElement[] array = ((zzz.z0ZzZzkuk<XTextElement>)p0).z0atk;
		XTextElement[] array2 = ((zzz.z0ZzZzkuk<XTextElement>)p1).z0atk;
		for (int num = p0.Count - 1; num >= 0; num--)
		{
			XTextElement xTextElement = array[num];
			if (xTextElement != array2[num])
			{
				return false;
			}
			if (xTextElement.z0ao())
			{
				return false;
			}
		}
		return true;
	}

	private bool z0yrk()
	{
		return base.z0pek(64);
	}

	public new XTextElementList z0urk()
	{
		return this;
	}

	public float z0irk()
	{
		return z0luk;
	}

	internal new bool z0ork()
	{
		return false;
	}

	private void z0uek_jiejie20260327142557(bool p0)
	{
		z0oek(32, p0);
	}

	public new float z0prk()
	{
		return z0iyk;
	}

	public int z0mrk()
	{
		return z0eyk_jiejie20260327142557;
	}

	public new float z0nrk()
	{
		float num = z0jyk_jiejie20260327142557();
		if (base.LastElement is XTextParagraphFlagElement)
		{
			num += z0srk().z0xek(7f);
		}
		return num;
	}

	internal bool z0brk()
	{
		if (z0wuk is XTextSectionElement xTextSectionElement && !xTextSectionElement.z0rek())
		{
			return true;
		}
		return false;
	}

	internal z0ZzZzzlh(XTextContentElement p0, int p1)
		: base(p1)
	{
		z0ayk = p0;
		z0tek(p0: true);
		z0iek(p0: true);
		z0pek(p0: true);
		z0oek(p0: true);
	}

	public new VerticalAlignStyle z0vrk()
	{
		return VerticalAlignStyle.Bottom;
	}

	private bool z0crk()
	{
		if (z0ayk != null && z0ayk.z0aek().z0atk == ContentGridLineType.ExtentToBottom)
		{
			return true;
		}
		return false;
	}

	public new float z0xrk()
	{
		if (z0tyk == -1234568f)
		{
			if (z0euk == null)
			{
				z0tyk = z0kuk;
			}
			else if (z0ayk == null)
			{
				z0tyk = z0kuk + z0euk.z0yt();
			}
			else
			{
				z0tyk = z0kuk + z0ayk.z0cw();
			}
		}
		return z0tyk;
	}

	internal void z0iek(bool p0)
	{
		z0oek(8, p0);
	}

	public new float z0zrk()
	{
		return z0kuk;
	}

	public new void z0ltk()
	{
		z0yek(-1f);
	}

	public new void z0oek(bool p0)
	{
		z0oek(128, p0);
	}

	public new bool z0ktk()
	{
		XTextElement xTextElement = base.z0krk().z0hy();
		if (xTextElement is XTextParagraphListItemElement)
		{
			int num = IndexOf(xTextElement);
			if (num >= 0)
			{
				xTextElement = SafeGet(num + 1);
			}
		}
		XTextElement xTextElement2 = base.LastElement.z0xt();
		if (xTextElement != null && xTextElement2 != null && xTextElement.z0jrk() >= 0 && xTextElement2.z0jrk() >= 0)
		{
			z0ZzZzhkh z0ZzZzhkh2 = xTextElement.z0qek()?.z0oek();
			if (z0ZzZzhkh2 != null && z0ZzZzhkh2.z0qrk() != 0 && z0ZzZzhkh2.z0bek().z0eek(xTextElement.z0jrk(), xTextElement2.z0jrk()))
			{
				return true;
			}
		}
		return false;
	}

	internal bool z0rek(float p0, float p1)
	{
		if (p0 >= z0syk && p0 <= z0syk + z0yyk && p1 >= z0kuk)
		{
			return p1 <= z0kuk + z0pyk;
		}
		return false;
	}

	public void z0tek(int p0)
	{
		z0eyk_jiejie20260327142557 = p0;
	}

	internal bool z0jtk()
	{
		z0yek(p0: false);
		if (base.Count == 0)
		{
			return false;
		}
		int num = 0;
		z0yek(-1f);
		bool flag = z0etk();
		bool result = false;
		if (flag)
		{
			if (z0eek(0, 1, z0vek(), z0jyk_jiejie20260327142557() - z0prk(), p4: true, p5: false))
			{
				result = true;
			}
		}
		else if (!z0yrk())
		{
			if (z0eek(0, z0urk().Count, z0vek(), z0jyk_jiejie20260327142557() - z0prk(), p4: true, p5: false))
			{
				result = true;
			}
		}
		else
		{
			int count = Count;
			float p = z0vek();
			for (int i = 0; i < count; i++)
			{
				XTextElement xTextElement = this[i];
				if (xTextElement is z0ZzZzgkh)
				{
					float num2 = ((z0ZzZzgkh)xTextElement).z0rek().z0nrk().z0oek();
					if (z0eek(num, i - num, p, num2, p4: false, p5: false))
					{
						result = true;
					}
					num = i + 1;
					p = num2 + xTextElement.Width + xTextElement.z0pt();
				}
				else if (i == base.Count - 1 && i - num >= 0 && z0eek(num, i - num + 1, p, z0jyk_jiejie20260327142557() - z0prk(), p4: true, p5: false))
				{
					result = true;
				}
			}
			z0mek(LastElement.z0it() + LastElement.Width);
		}
		z0suk = z0ayk.z0eek(this);
		float num3 = z0luk + z0byk + z0xyk;
		if (z0suk > 0f)
		{
			num3 += z0suk;
		}
		else
		{
			num3 += z0wrk() + z0cyk;
			num3 = (float)Math.Ceiling(num3);
		}
		if (z0ayk != null && z0ayk.z0mrk() > 0f)
		{
			num3 = z0ayk.z0mrk();
		}
		if (!flag && z0ztk())
		{
			num3 += z0euk.z0iu().EmphasisMarkSize * 2f;
		}
		bool flag2 = z0euk.z0qxk != null && z0euk.z0qxk.z0cek();
		z0tek(num3);
		if (!flag)
		{
			if (z0qtk())
			{
				XTextSectionElement xTextSectionElement = z0mek();
				if (flag2 || xTextSectionElement.CompressOwnerLineSpacing)
				{
					xTextSectionElement.z0nt(0f);
					z0tek(xTextSectionElement.Height);
				}
				xTextSectionElement.z0lrk();
				float num4 = base.LastElement.z0mek();
				if (z0yyk < num4)
				{
					z0yyk = num4;
				}
			}
			else if (z0jrk_jiejie20260327142557())
			{
				XTextTableElement xTextTableElement = z0ntk();
				if (flag2 || xTextTableElement.CompressOwnerLineSpacing)
				{
					xTextTableElement.z0nt(0f);
					z0tek(xTextTableElement.Height);
				}
				xTextTableElement.z0rrk();
				float num5 = base.LastElement.z0mek();
				if (z0yyk < num5)
				{
					z0yyk = num5;
				}
			}
			else if (z0rtk())
			{
				z0hyk().z0nt(0f);
				z0tek(z0hyk().Height);
			}
			else if (base.LastElement is XTextParagraphFlagElement)
			{
				XTextParagraphFlagElement xTextParagraphFlagElement = (XTextParagraphFlagElement)base.LastElement;
				if (xTextParagraphFlagElement.Height < 40f && z0ytk() > xTextParagraphFlagElement.Height + 5f)
				{
					xTextParagraphFlagElement.Height = Math.Min(z0srk().z0ack.z0tek(), z0ytk() - xTextParagraphFlagElement.z0yt() - 4f);
				}
			}
		}
		z0wtk();
		z0yek(p0: false);
		z0erk();
		return result;
	}

	public new void z0htk()
	{
		if (z0jrk_jiejie20260327142557())
		{
			z0ntk().z0sr();
		}
		else
		{
			base.z0grk().z0sr();
		}
	}

	public new float z0gtk()
	{
		return z0byk;
	}

	public void z0iek(float p0)
	{
		if (z0luk != p0)
		{
			z0luk = p0;
			z0yek(p0: true);
		}
	}

	public float z0ftk()
	{
		return 50f;
	}

	internal void z0tek(float p0, float p1)
	{
		z0oyk = z0syk + p0;
		z0tyk = z0kuk + p1;
	}

	public void z0eek(z0ZzZzwrj p0)
	{
		z0guk = p0;
	}

	public new z0ZzZzwrj z0dtk()
	{
		return z0guk;
	}

	public float z0stk()
	{
		return z0syk;
	}

	public new float z0atk()
	{
		return z0vyk;
	}

	internal void z0oek(float p0)
	{
		z0tyk = p0;
		z0yyk = p0;
	}

	public new bool z0qtk()
	{
		return z0wuk is XTextSectionElement;
	}

	internal z0ZzZzzlh()
	{
		z0iek(p0: true);
		z0pek(p0: true);
		z0oek(p0: true);
	}

	internal new void z0wtk()
	{
		if (z0ayk == null)
		{
			return;
		}
		z0eek(p0: false);
		z0ZzZzzej z0ZzZzzej2 = z0ayk.z0ju();
		if (z0ZzZzzej2 == null)
		{
			return;
		}
		if (!z0ZzZzzej2.z0nek())
		{
			if (!(z0wuk is XTextTableElement { CompressOwnerLineSpacing: not false }) && z0wuk is XTextSectionElement xTextSectionElement)
			{
				_ = xTextSectionElement.CompressOwnerLineSpacing;
			}
			return;
		}
		z0eek(p0: true);
		float num = z0ZzZzzej2.z0yek(z0ytk());
		if (z0ytk() == num)
		{
			return;
		}
		float num2 = (num - z0ytk()) / 2f;
		if (!z0jrk_jiejie20260327142557() && !z0qtk())
		{
			z0vyk += num2;
		}
		z0tek(num);
		if (!(num2 > 0f))
		{
			return;
		}
		XTextElement[] array = ((zzz.z0ZzZzkuk<XTextElement>)this).z0krk();
		int count = base.Count;
		if (!(z0wuk is XTextTableElement) && !(z0wuk is XTextSectionElement))
		{
			for (int i = 0; i < count; i++)
			{
				array[i].z0wik += num2;
			}
			return;
		}
		for (int j = 0; j < count; j++)
		{
			XTextElement xTextElement = array[j];
			if (!(xTextElement is XTextTableElement) && !(xTextElement is XTextSectionElement))
			{
				xTextElement.z0nt(xTextElement.z0yt() + num2);
			}
		}
	}

	private bool z0etk()
	{
		if (z0fuk)
		{
			return base.z0zek() != null;
		}
		return false;
	}

	public bool z0rtk()
	{
		return z0wuk is XTextPageBreakElement;
	}

	internal XTextElement z0ttk()
	{
		if (base.Count > 1)
		{
			XTextElement result = base[base.Count - 1];
			RemoveAt(base.Count - 1);
			return result;
		}
		return null;
	}

	public void z0pek(float p0)
	{
		z0iyk = p0;
	}

	public float z0ytk()
	{
		return z0pyk;
	}

	internal float z0utk()
	{
		return z0tyk;
	}

	public float z0itk()
	{
		float num = 0f;
		if (base.Count > 0)
		{
			for (int num2 = base.Count - 1; num2 >= 0; num2--)
			{
				num += base[num2].Width;
			}
		}
		return num;
	}

	internal bool z0eek(XTextElement p0, XTextElement p1)
	{
		if ((z0wuk is XTextTableElement || z0wuk is XTextSectionElement) && !XTextContentElement.z0eek(p0))
		{
			return false;
		}
		z0ZzZzrzj z0ZzZzrzj2 = p0.z0ruk;
		bool flag = false;
		bool flag2 = false;
		if (p0 is XTextCharElement)
		{
			flag2 = true;
			if (z0ZzZzrzj2.z0iyk)
			{
				z0uek_jiejie20260327142557(p0: true);
			}
		}
		else if (p0 is XTextParagraphFlagElement)
		{
			flag2 = true;
			flag = true;
		}
		else if (!z0yrk() && p0 is z0ZzZzgkh)
		{
			z0rek(p0: true);
		}
		if (!flag2)
		{
			z0iek(p0: false);
			z0pek(p0: false);
		}
		float num = p0.z0bi();
		bool num2 = base.Count == 0;
		if (num2)
		{
			z0yek(-1f);
			z0oyk = 0f;
		}
		if (flag2 || (!(p0 is XTextTableElement) && !(p0 is XTextSectionElement)))
		{
			z0rek(p0);
		}
		if (!flag2 && p0 is XTextFieldBorderElement)
		{
			XTextFieldBorderElement xTextFieldBorderElement = (XTextFieldBorderElement)p0;
			if (xTextFieldBorderElement.z0ji() is XTextInputFieldElementBase)
			{
				((XTextInputFieldElementBase)xTextFieldBorderElement.z0ji()).z0uek();
				num = p0.z0bi();
			}
		}
		if (num2)
		{
			XTextParagraphFlagElement xTextParagraphFlagElement = z0ryk;
			bool flag3 = false;
			((zzz.z0ZzZzkuk<XTextElement>)this).z0pek(p0);
			z0eek(p0);
			z0oyk += num;
			if (flag2 || (!(p0 is XTextTableElement) && !(p0 is XTextSectionElement)))
			{
				if (xTextParagraphFlagElement != null)
				{
					z0ZzZzrzj z0ZzZzrzj3 = xTextParagraphFlagElement.z0aek();
					if (p0 == xTextParagraphFlagElement.z0iek())
					{
						flag3 = true;
						z0auk = z0ZzZzrzj3.z0hyk + z0ZzZzrzj3.z0pyk;
					}
					else if (p1 is XTextTableElement || p1 is XTextSectionElement)
					{
						z0auk = z0ZzZzrzj3.z0hyk + z0ZzZzrzj3.z0pyk;
					}
					else
					{
						z0auk = z0ZzZzrzj3.z0hyk;
					}
				}
				else
				{
					z0auk = 0f;
				}
			}
			p0.z0xik = z0auk;
			if (flag3)
			{
				if (xTextParagraphFlagElement.z0yek() != ParagraphListStyle.None)
				{
					XTextParagraphListItemElement xTextParagraphListItemElement = new XTextParagraphListItemElement();
					xTextParagraphListItemElement.z0yek(this);
					float height = (xTextParagraphListItemElement.Width = p0.z0aek().z0pek.GetHeight(GraphicsUnit.Document));
					xTextParagraphListItemElement.Height = height;
					using (z0ZzZzjpk p2 = p0.z0ru())
					{
						xTextParagraphListItemElement.z0eek(p2);
					}
					xTextParagraphListItemElement.z0bt(p0.z0jr());
					xTextParagraphListItemElement.z0oek(p0.z0pek());
					Insert(0, xTextParagraphListItemElement);
					z0eek(xTextParagraphListItemElement);
					z0oyk += xTextParagraphListItemElement.Width;
					xTextParagraphFlagElement.z0eek(xTextParagraphListItemElement);
				}
				else if (xTextParagraphFlagElement.z0lrk() != null)
				{
					xTextParagraphFlagElement.z0lrk().Dispose();
					xTextParagraphFlagElement.z0eek((XTextParagraphListItemElement)null);
				}
			}
			if (z0ZzZzrzj2.z0xyk == ContentLayoutAlign.Surroundings && p0 is XTextObjectElement && z0ayk.z0tek(p0))
			{
				z0ayk.z0oek().z0pek[p0] = this;
			}
			return true;
		}
		float num3 = z0ZzZzrzj2.z0mtk;
		if (!flag && z0oyk + num + num3 > z0yyk - z0auk - z0iyk + 0.1f)
		{
			bool flag4 = true;
			if (base.Count == 1 && base[0] is XTextFieldBorderElement && ((XTextFieldBorderElement)base[0]).Width < 5f)
			{
				flag4 = false;
			}
			if (flag4 && p0 is XTextFieldBorderElement)
			{
				XTextFieldBorderElement xTextFieldBorderElement2 = (XTextFieldBorderElement)p0;
				if (xTextFieldBorderElement2.z0mek() == (z0ZzZzzvj)1 && !xTextFieldBorderElement2.z0nek())
				{
					flag4 = false;
				}
			}
			if (flag4)
			{
				return false;
			}
		}
		XTextElement lastElement = base.LastElement;
		p0.z0xik = lastElement.z0it() + lastElement.z0bi();
		if (flag && DocumentBehaviorOptions.z0rrk)
		{
			if (lastElement is XTextFieldBorderElement)
			{
				if (base.Count > 2)
				{
					XTextElement xTextElement = base[base.Count - 2];
					if (p0.Height > xTextElement.Height && (double)xTextElement.Height > 0.1)
					{
						p0.Height = xTextElement.Height;
					}
				}
			}
			else if (p0.Height > lastElement.Height && (double)lastElement.Height > 0.1)
			{
				p0.Height = lastElement.Height;
			}
		}
		((zzz.z0ZzZzkuk<XTextElement>)this).z0pek(p0);
		if (p0 is XTextCharElement)
		{
			XTextCharElement xTextCharElement = (XTextCharElement)p0;
			if (xTextCharElement.z0bek == '\t')
			{
				xTextCharElement.z0pek();
				num = xTextCharElement.z0bi();
			}
		}
		else
		{
			z0eek(p0);
		}
		z0oyk += num + num3;
		if (!flag2 && p0 is XTextObjectElement && z0ayk.z0tek(p0))
		{
			z0ayk.z0oek().z0pek[p0] = this;
		}
		return true;
	}

	public int z0otk()
	{
		return z0dyk_jiejie20260327142557;
	}

	public XTextContentElement z0ptk()
	{
		return z0ayk;
	}

	internal new void z0pek(bool p0)
	{
		z0oek(16, p0);
	}

	public void z0mek(float p0)
	{
		z0yyk = p0;
	}

	public bool z0mtk()
	{
		if (!z0lyk())
		{
			if (z0wuk is XTextTableElement && ((XTextTableElement)z0wuk).CompressOwnerLineSpacing)
			{
				return true;
			}
			if (z0wuk is XTextSectionElement && ((XTextSectionElement)z0wuk).CompressOwnerLineSpacing)
			{
				return true;
			}
		}
		return false;
	}

	internal XTextTableElement z0ntk()
	{
		return z0wuk as XTextTableElement;
	}

	public bool z0btk()
	{
		if (base.Count == 1)
		{
			return base[0] is XTextParagraphFlagElement;
		}
		return false;
	}

	public void z0nek(float p0)
	{
		z0kuk = p0;
	}

	public void z0eek(DocumentContentAlignment p0)
	{
		z0qyk = p0;
	}

	public void z0bek(float p0)
	{
		if (z0byk != p0)
		{
			z0byk = p0;
			z0yek(p0: true);
		}
	}

	internal void z0vtk()
	{
		XTextElement[] array = ((zzz.z0ZzZzkuk<XTextElement>)this).z0krk();
		for (int num = base.Count - 1; num >= 0; num--)
		{
			array[num].z0kik = this;
		}
	}

	public float z0ctk()
	{
		return z0suk;
	}

	public float z0xtk()
	{
		if (z0oyk == -1234568f)
		{
			if (z0euk == null)
			{
				z0oyk = z0syk;
			}
			else if (z0ayk == null)
			{
				z0oyk = z0syk + z0euk.z0it();
			}
			else
			{
				z0oyk = z0syk + z0ayk.z0he();
			}
		}
		return z0oyk;
	}

	public void z0eek(VerticalAlignStyle p0)
	{
	}

	private bool z0ztk()
	{
		return base.z0pek(32);
	}

	public void z0vek(float p0)
	{
		z0auk = p0;
	}

	internal bool z0lyk()
	{
		return base.z0pek(4);
	}

	internal void z0kyk()
	{
		base.z0vrk();
		z0ayk = null;
		z0euk = null;
		z0guk = null;
		z0wuk = null;
		z0ryk = null;
	}

	public float z0jyk_jiejie20260327142557()
	{
		return z0yyk;
	}

	internal XTextPageBreakElement z0hyk()
	{
		return z0wuk as XTextPageBreakElement;
	}

	internal ContentLayoutDirectionStyle z0gyk()
	{
		return ContentLayoutDirectionStyle.LeftToRight;
	}

	public void z0eek(XTextParagraphFlagElement p0)
	{
		z0ryk = p0;
		if (z0ryk != null && base.z0krk() is XTextParagraphListItemElement)
		{
			z0ryk.z0eek((XTextParagraphListItemElement)base.z0krk());
		}
	}

	public z0ZzZzzlh z0fyk()
	{
		if (z0ayk != null && z0ayk.z0qek() != null)
		{
			z0ZzZzlkh z0ZzZzlkh2 = z0ayk.z0qek().z0rrk();
			if (z0ZzZzlkh2 != null && z0ZzZzlkh2.Count > 0)
			{
				int num = z0ZzZzlkh2.IndexOf(this);
				if (num > 0)
				{
					return z0ZzZzlkh2[num - 1];
				}
			}
		}
		return null;
	}
}
