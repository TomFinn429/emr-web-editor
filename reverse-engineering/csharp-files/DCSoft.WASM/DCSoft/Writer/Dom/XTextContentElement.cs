using System;
using System.Collections.Generic;
using System.ComponentModel;
using DCSoft.Drawing;
using DCSoft.Printing;
using DCSoft.WinForms;
using DCSystem_Drawing;
using DCSystem_Drawing.Drawing2D;
using zzz;

namespace DCSoft.Writer.Dom;

public abstract class XTextContentElement : XTextContainerElement
{
	internal class z0qpk : z0apk_jiejie20260327142557
	{
		public new RectangleSlantSplitStyle z0eek;

		public new z0ZzZzzej z0rek;

		public new MoveFocusHotKeys z0tek = MoveFocusHotKeys.Tab;

		public float z0yek;

		public new z0ZzZzrfh z0uek;

		public new ContentAlignment z0iek = ContentAlignment.TopRight;

		public new List<z0ZzZzgkh> z0oek;

		public new Dictionary<XTextElement, z0ZzZzzlh> z0pek;

		public new XTextElement[] z0mek;

		public new RenderVisibility z0nek = RenderVisibility.All;

		public new RenderVisibility z0bek = RenderVisibility.All;

		public override z0apk_jiejie20260327142557 z0vwk()
		{
			z0qpk z0qpk = (z0qpk)base.z0vwk();
			z0qpk.z0pek = null;
			z0qpk.z0oek = null;
			z0qpk.z0mek = null;
			if (z0rek != null)
			{
				z0qpk.z0rek = z0rek.z0pek();
			}
			return z0qpk;
		}

		public override void z0bwk()
		{
			base.z0bwk();
			z0rek = null;
			if (z0pek != null)
			{
				z0pek.Clear();
				z0pek = null;
			}
			if (z0oek != null)
			{
				z0oek.Clear();
				z0oek = null;
			}
			if (z0mek != null)
			{
				Array.Clear(z0mek);
				z0mek = null;
			}
			if (z0uek != null)
			{
				z0uek.Dispose();
				z0uek = null;
			}
		}
	}

	internal class z0lgj
	{
		private int z0iek = -1;

		private bool z0oek = true;

		private bool z0pek;

		private bool z0mek;

		private bool z0nek;

		public bool z0bek;

		private bool z0vek = true;

		public void z0eek(bool p0)
		{
			z0oek = p0;
		}

		public bool z0eek()
		{
			return z0nek;
		}

		public void z0rek(bool p0)
		{
			z0mek = p0;
		}

		public bool z0rek()
		{
			return z0pek;
		}

		public void z0tek(bool p0)
		{
			z0vek = p0;
		}

		public bool z0tek()
		{
			return z0mek;
		}

		public void z0yek(bool p0)
		{
			z0pek = p0;
		}

		public void z0eek(int p0)
		{
			z0iek = p0;
		}

		public void z0uek(bool p0)
		{
			z0nek = p0;
		}

		public bool z0yek()
		{
			return z0oek;
		}

		public bool z0uek()
		{
			return z0vek;
		}
	}

	private new static readonly z0ZzZzwzj z0gtk;

	internal new static XTextElementList z0dtk;

	[NonSerialized]
	private new float z0stk;

	[NonSerialized]
	private new z0ZzZzwzj z0atk;

	private new static readonly float[] z0qtk;

	internal new static int z0wtk;

	protected new z0ZzZzzlh[] z0etk;

	private new static List<XTextInputFieldElementBase> z0rtk;

	[ThreadStatic]
	private new static z0ZzZzlsh z0ttk;

	internal new static bool z0ytk;

	[NonSerialized]
	protected new XTextElementList z0utk;

	[NonSerialized]
	internal new int z0itk;

	[z0ZzZzuqh]
	public override string Text
	{
		get
		{
			z0ygj z0ygj = new z0ygj(z0rik, p1: true);
			z0bw_jiejie20260327142557(z0ygj);
			return z0ygj.ToString();
		}
		set
		{
			base.Text = value;
		}
	}

	[z0ZzZzbjh(MemberEffectLevel.ElementLayout)]
	[DefaultValue(null)]
	public virtual z0ZzZzzej GridLine
	{
		get
		{
			return ((z0qpk)base.z0utk)?.z0rek;
		}
		set
		{
			if (value == null)
			{
				if (base.z0utk != null)
				{
					((z0qpk)base.z0utk).z0rek = null;
				}
			}
			else
			{
				z0vrk().z0rek = value;
			}
		}
	}

	public override ElementType AcceptChildElementTypes2
	{
		get
		{
			if (base.z0utk != null)
			{
				return base.z0utk.z0tek;
			}
			return ElementType.All;
		}
		set
		{
			if (value == ElementType.All)
			{
				if (base.z0utk != null)
				{
					base.z0utk.z0tek = value;
				}
			}
			else
			{
				base.z0prk().z0tek = value;
			}
		}
	}

	[DefaultValue(0f)]
	public float SpecifyFixedLineHeight
	{
		get
		{
			if (base.z0utk != null)
			{
				return ((z0qpk)base.z0utk).z0yek;
			}
			return 0f;
		}
		set
		{
			if (value == 0f)
			{
				if (base.z0utk != null)
				{
					((z0qpk)base.z0utk).z0yek = value;
				}
			}
			else
			{
				z0vrk().z0yek = value;
			}
		}
	}

	private DCBooleanValueHasDefault z0eek()
	{
		if (z0syk())
		{
			if (z0guk())
			{
				return DCBooleanValueHasDefault.True;
			}
			return DCBooleanValueHasDefault.False;
		}
		return DCBooleanValueHasDefault.Default;
	}

	internal static bool z0eek(XTextElement p0)
	{
		if (p0 is XTextFieldBorderElement)
		{
			XTextFieldBorderElement xTextFieldBorderElement = (XTextFieldBorderElement)p0;
			if (string.IsNullOrEmpty(xTextFieldBorderElement.z0vek()))
			{
				XTextFieldElementBase xTextFieldElementBase = (XTextFieldElementBase)p0.z0ji();
				if (xTextFieldBorderElement == xTextFieldElementBase.z0tek() && p0.z0bu().CompressLayoutForFieldBorder)
				{
					return true;
				}
			}
		}
		else if (p0 is XTextParagraphFlagElement && p0.z0bu().ParagraphFlagFollowTableOrSection)
		{
			return true;
		}
		return false;
	}

	private bool z0rek()
	{
		z0ZzZzerj z0ZzZzerj = z0rik?.z0suk();
		if (z0ZzZzerj != null && z0ZzZzerj.Count > 0)
		{
			float num = z0cw();
			float num2 = num + Height;
			foreach (z0ZzZzwrj item in z0ZzZzerj)
			{
				if (item.z0irk() > num && item.z0irk() < num2)
				{
					return true;
				}
			}
		}
		return false;
	}

	public XTextElement[] z0tek()
	{
		return ((z0qpk)base.z0utk)?.z0mek;
	}

	public virtual void z0eek(XTextElementList p0)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("elements");
		}
		if (p0.Count == 0)
		{
			return;
		}
		foreach (XTextElement item in p0.z0xrk())
		{
			item.z0nu(this);
			item.z0bt(z0jr());
		}
		if (z0be().z0lrk() is XTextParagraphFlagElement)
		{
			z0be().z0yek(z0be().Count - 1, p0);
		}
		else
		{
			((zzz.z0ZzZzkuk<XTextElement>)z0be()).z0tek((zzz.z0ZzZzkuk<XTextElement>)p0);
		}
		base.z0oek();
	}

	protected XTextContentElement(bool needRefreshPage)
	{
		z0mek(needRefreshPage);
	}

	public override void z0vw(z0ZzZzvxj p0)
	{
		if (z0etk == null || z0etk.Length == 0)
		{
			return;
		}
		bool flag = false;
		try
		{
			if (p0.z0gyk.z0cek())
			{
				z0ZzZzbdh z0ZzZzbdh = p0.z0gtk;
				if (!p0.z0nek().z0bek())
				{
					z0ZzZzbdh = z0ZzZzbdh.z0tek(p0.z0nek(), z0ZzZzbdh);
				}
				if (!z0ZzZzbdh.z0bek() && !p0.z0hrk().z0bek())
				{
					z0ZzZzbdh = z0ZzZzbdh.z0tek(z0ZzZzbdh, p0.z0hrk());
				}
				if (!z0ZzZzbdh.z0bek())
				{
					if (this is XTextDocumentContentElement)
					{
						z0ZzZzbdh.z0eek(z0ZzZzbdh.z0tek() - 2000f);
						z0ZzZzbdh.z0tek(z0ZzZzbdh.z0uek() + 4000f);
					}
					else
					{
						DCBooleanValueHasDefault dCBooleanValueHasDefault = z0eek();
						if (dCBooleanValueHasDefault == DCBooleanValueHasDefault.Default)
						{
							dCBooleanValueHasDefault = DCBooleanValueHasDefault.True;
							if (((z0qpk)base.z0utk)?.z0mek != null && ((z0qpk)base.z0utk).z0mek.Length != 0)
							{
								dCBooleanValueHasDefault = DCBooleanValueHasDefault.False;
							}
							else
							{
								z0ZzZzzlh[] array = z0etk;
								if (array != null && array.Length != 0)
								{
									if (array[0].z0zrk() < 0f)
									{
										dCBooleanValueHasDefault = DCBooleanValueHasDefault.False;
									}
									if (array[array.Length - 1].z0ark() > z0aik)
									{
										dCBooleanValueHasDefault = DCBooleanValueHasDefault.False;
									}
									if (dCBooleanValueHasDefault == DCBooleanValueHasDefault.True)
									{
										for (int num = array.Length - 1; num >= 0; num--)
										{
											if (array[num].z0jyk_jiejie20260327142557() > z0fik)
											{
												dCBooleanValueHasDefault = DCBooleanValueHasDefault.False;
												break;
											}
										}
									}
								}
							}
							z0eek(dCBooleanValueHasDefault);
						}
						if (dCBooleanValueHasDefault == DCBooleanValueHasDefault.True)
						{
							z0ZzZzbdh = z0ZzZzbdh.z0xek;
						}
					}
					z0ZzZzrzj z0ZzZzrzj = null;
					using (zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = z0trk().z0ltk())
					{
						while (z0bpk.MoveNext())
						{
							XTextElement current = z0bpk.Current;
							if (current is XTextCharElement)
							{
								z0ZzZzrzj = current.z0aek();
								break;
							}
						}
					}
					if (z0ZzZzrzj == null)
					{
						p0.z0gyk.z0frk().z0mhk(ID, z0ZzZzbdh, null, 0f, FontStyle.Regular, p5: false);
					}
					else
					{
						p0.z0gyk.z0frk().z0mhk(ID, z0ZzZzbdh, (z0ZzZzrzj.z0tyk == null || z0ZzZzrzj.z0tyk.Length == 0) ? z0ZzZzimk.DefaultFontName : z0ZzZzrzj.z0tyk, z0ZzZzrzj.z0wtk, z0ZzZzrzj.z0prk, p5: false);
					}
					flag = true;
				}
			}
			z0eek(p0);
		}
		catch (Exception ex)
		{
			if (XTextDocument.z0wbk)
			{
				z0ZzZzqok.z0rek.z0dh(ex.ToString());
			}
			string text = ex.ToString();
			z0ZzZzqok.z0rek.z0sh("DCWriter内部错误:" + text);
			DocumentViewOptions documentViewOptions = z0iu();
			if (documentViewOptions == null || documentViewOptions.ShowRedErrorMessageForPaint)
			{
				p0.z0gyk.z0rek();
				using z0ZzZzlsh z0ZzZzlsh = new z0ZzZzlsh();
				z0ZzZzlsh.z0rek(StringAlignment.Near);
				z0ZzZzlsh.z0eek(StringAlignment.Near);
				p0.z0gyk.z0eek(text, z0ZzZzimk.z0eek(), Color.Red, new z0ZzZzbdh(0f, 0f, Width, Height), z0ZzZzlsh);
				return;
			}
		}
		finally
		{
			if (flag)
			{
				p0.z0gyk.z0frk().z0thk();
			}
		}
	}

	internal new List<z0ZzZzgkh> z0yek()
	{
		return ((z0qpk)base.z0utk)?.z0oek;
	}

	public new float z0uek()
	{
		if (base.z0utk != null)
		{
			return ((z0qpk)base.z0utk).z0lrk;
		}
		return 1f;
	}

	public new int z0iek()
	{
		if (z0etk != null)
		{
			return z0etk.Length;
		}
		return 0;
	}

	[DevLog("2023-6-7", "袁永福", "DCWRITER-4121", "修改背景文字打印")]
	internal void z0eek(object p0)
	{
		if (z0etk == null || z0etk.Length == 0)
		{
			return;
		}
		z0ZzZzvxj z0ZzZzvxj = (z0ZzZzvxj)p0;
		z0ZzZzbdh p1 = z0ZzZzvxj.z0nek();
		z0ZzZzbdh p2 = z0ZzZzvxj.z0gtk;
		p2.z0tek(z0lu());
		p1 = z0ZzZzbdh.z0tek(p1, p2);
		if (p1.z0bek())
		{
			return;
		}
		bool flag = z0ZzZzvxj.z0hrk().z0bek();
		XTextDocument xTextDocument = z0jr();
		bool flag2 = z0ZzZzvxj.z0dtk;
		bool flag3 = z0ZzZzvxj.z0ptk;
		bool flag4 = z0ZzZzvxj.z0trk;
		bool flag5 = z0ZzZzvxj.z0wtk;
		bool p3 = z0ZzZzvxj.z0fuk;
		XTextDocumentContentElement xTextDocumentContentElement = z0ZzZzvxj.z0mek();
		if (xTextDocumentContentElement == null)
		{
			xTextDocumentContentElement = z0qek();
		}
		bool flag6 = xTextDocumentContentElement is XTextDocumentBodyElement;
		bool flag7 = this is XTextTableCellElement && z0ZzZzvxj.z0eek((XTextTableCellElement)this);
		z0ZzZzhkh z0ZzZzhkh = xTextDocumentContentElement.z0oek();
		ContentRangeMode contentRangeMode = z0ZzZzhkh.z0yek();
		z0ZzZzbdh z0ZzZzbdh = p1;
		if (!flag)
		{
			z0ZzZzbdh = z0ZzZzbdh.z0tek(z0ZzZzbdh, z0ZzZzvxj.z0hrk());
		}
		if (z0ZzZzvxj.z0byk == (z0ZzZzcxj)0 && base.z0utk != null && ((z0qpk)base.z0utk).z0uek != null)
		{
			z0qpk z0qpk = (z0qpk)base.z0utk;
			z0ZzZzrfh z0ZzZzrfh = z0qpk.z0uek;
			if (z0ZzZzrfh.z0uek())
			{
				z0ZzZzbdh z0ZzZzbdh2 = z0ZzZzjmk.z0eek(z0py(), xTextDocument.z0jrk(z0ZzZzrfh.z0iek()), xTextDocument.z0jrk(((z0ZzZzedh)z0ZzZzrfh).z0yek()), z0qpk.z0iek);
				if (p1.z0tek(z0ZzZzbdh2))
				{
					z0ZzZzvxj.z0gyk.z0eek(z0ZzZzrfh, z0ZzZzbdh2);
				}
			}
		}
		int num = z0etk.Length;
		z0ZzZzzlh[] array = z0etk;
		float num2 = p2.z0oek();
		float num3 = p2.z0pek();
		for (int i = 0; i < num; i++)
		{
			z0ZzZzzlh z0ZzZzzlh = array[i];
			float num4 = z0ZzZzzlh.z0stk() + num2;
			float num5 = z0ZzZzzlh.z0zrk() + num3;
			float num6 = z0ZzZzzlh.z0jyk_jiejie20260327142557();
			float num7 = z0ZzZzzlh.z0ytk();
			if (num5 + num7 < p1.z0pek() - 1f)
			{
				continue;
			}
			if (num5 > p1.z0nek() + 2f)
			{
				break;
			}
			if (z0ZzZzzlh.LastElement is XTextParagraphFlagElement)
			{
				num6 += z0ZzZzzlh.LastElement.z0lu();
			}
			bool flag8 = true;
			z0ZzZzbdh z0ZzZzbdh3 = new z0ZzZzbdh(num4, num5, num6, num7);
			z0ZzZzbdh z0ZzZzbdh4 = z0ZzZzbdh.z0tek(p1, z0ZzZzbdh3);
			if (z0ZzZzbdh4.z0bek())
			{
				flag8 = false;
			}
			else if (z0ZzZzzlh.z0rrk() && z0ZzZzvxj.z0byk != 0 && z0ZzZzvxj.z0byk != (z0ZzZzcxj)2 && z0ZzZzbdh4.z0iek() < num7 * 0.4f)
			{
				flag8 = false;
			}
			else if (z0ZzZzvxj.z0byk != 0 && z0ZzZzbdh4.z0iek() <= 5f)
			{
				flag8 = false;
			}
			if (!flag8)
			{
				continue;
			}
			if (flag6 && z0ZzZzvxj.z0lrk() != null && num5 > z0ZzZzvxj.z0stk - 4f)
			{
				break;
			}
			if (flag6 && !flag)
			{
				z0ZzZzbdh z0ZzZzbdh5 = z0ZzZzbdh.z0tek(z0ZzZzvxj.z0hrk(), z0ZzZzbdh3);
				if (z0ZzZzbdh5.z0iek() < 10f && (double)z0ZzZzbdh5.z0iek() < (double)num7 * 0.2)
				{
					continue;
				}
			}
			z0ZzZzhmk z0ZzZzhmk = null;
			if (z0ZzZzvxj.z0eyk && z0ZzZzvxj.z0yrk)
			{
				z0ZzZzhmk = new z0ZzZzhmk();
			}
			z0ZzZzbdh p4 = z0ZzZzbdh3;
			float num8 = p4.z0mek() + 20f;
			p4.z0eek(num2);
			p4.z0tek(num8 - p4.z0oek());
			p4 = z0ZzZzbdh.z0tek(p4, z0ZzZzbdh);
			p4.z0tek(p4.z0uek() + 2f);
			p4.z0eek(p4.z0tek() - 2f);
			if (z0ZzZzzlh.z0qtk())
			{
				p4.z0rek(p4.z0yek() - 1.5f);
				p4.z0yek(p4.z0iek() + 3f);
			}
			int num9 = z0ZzZzvxj.z0gyk.z0yek();
			if (p4.z0pek() != num5 || p4.z0iek() != num7)
			{
				z0ZzZzvxj.z0gyk.z0eek(p4);
			}
			int count = z0ZzZzzlh.Count;
			XTextElement[] array2 = ((zzz.z0ZzZzkuk<XTextElement>)z0ZzZzzlh).z0krk();
			for (int j = 0; j < count; j++)
			{
				XTextElement xTextElement = array2[j];
				bool flag9 = xTextElement is XTextCharElement;
				bool flag10 = !flag9 && xTextElement is XTextFieldBorderElement;
				bool flag11 = flag9 || flag10 || xTextElement is XTextParagraphFlagElement || xTextElement is XTextFieldBorderElement;
				if (!flag11 && (xTextElement is z0ZzZzgkh || xTextElement.z0ci() != ElementZOrderStyle.Normal))
				{
					continue;
				}
				if (z0ZzZzvxj.z0byk == (z0ZzZzcxj)3 || z0ZzZzvxj.z0byk == (z0ZzZzcxj)2)
				{
					if (z0ZzZzvxj.z0ytk)
					{
						if (xTextElement is XTextParagraphListItemElement)
						{
							XTextElement p5 = z0ZzZzzlh.z0xek(xTextElement);
							if (!z0ZzZzhkh.z0yek(p5))
							{
								continue;
							}
						}
						else if (!z0ZzZzhkh.z0yek(xTextElement))
						{
							continue;
						}
					}
					if (flag9)
					{
						if (((XTextCharElement)xTextElement).z0oek() && !(xTextElement.z0ji() as XTextInputFieldElementBase).z0so())
						{
							continue;
						}
					}
					else if (xTextElement is XTextObjectElement && ((XTextObjectElement)xTextElement).PrintVisibility != ElementVisibility.Visible)
					{
						continue;
					}
				}
				else if (z0ZzZzvxj.z0byk == (z0ZzZzcxj)5 && flag9 && ((XTextCharElement)xTextElement).z0oek() && !(xTextElement.z0ji() as XTextInputFieldElementBase).z0so())
				{
					continue;
				}
				z0ZzZzrzj z0ZzZzrzj = xTextElement.z0aek();
				if (!flag11 && !z0ZzZzvxj.z0eek(z0ZzZzrzj.z0dyk))
				{
					continue;
				}
				if (flag11)
				{
					if (xTextElement.z0fik <= 0f)
					{
						continue;
					}
				}
				else if (xTextElement.Width <= 0f)
				{
					continue;
				}
				float p6;
				float p7;
				float num10;
				if (flag9)
				{
					p6 = num4 + xTextElement.z0xik;
					p7 = num5 + xTextElement.z0wik;
					num10 = xTextElement.z0fik;
				}
				else
				{
					p6 = num4 + xTextElement.z0it();
					p7 = num5 + xTextElement.z0yt();
					num10 = xTextElement.z0lu();
				}
				z0ZzZzbdh z0ZzZzbdh6 = new z0ZzZzbdh(p6, num5 + z0ZzZzzlh.z0vyk, num10 + xTextElement.z0pt(), z0ZzZzzlh.z0pyk - z0ZzZzzlh.z0vyk);
				z0ZzZzbdh p8 = z0ZzZzbdh.z0tek(p1, z0ZzZzbdh6);
				if (p8.z0bek())
				{
					continue;
				}
				if (z0ZzZzvxj.z0wyk && !(xTextElement is XTextTableElement))
				{
					xTextDocument.z0vek(p8);
				}
				bool flag12 = false;
				if (flag2 && z0srk() && flag9 && xTextElement.z0ji() is XTextInputFieldElementBase && ((XTextInputFieldElementBase)xTextElement.z0ji()).z0eek(xTextElement))
				{
					flag12 = true;
				}
				z0ZzZzvxj.z0hyk = xTextElement;
				z0ZzZzvxj.z0luk = z0ZzZzrzj;
				z0ZzZzbdh z0ZzZzbdh7 = (z0ZzZzvxj.z0gtk = new z0ZzZzbdh(p6, p7, num10, xTextElement.Height));
				if (!flag11)
				{
					z0ZzZzbdh7.z0eek(z0ZzZzbdh7.z0tek() + z0ZzZzrzj.z0ryk);
					z0ZzZzbdh7.z0rek(z0ZzZzbdh7.z0yek() + z0ZzZzrzj.z0ptk);
					z0ZzZzbdh7.z0tek(xTextElement.z0ork());
					z0ZzZzbdh7.z0yek(xTextElement.z0si());
					z0ZzZzvxj.z0tek(z0ZzZzbdh7);
				}
				if (flag5 && z0ZzZzvxj.z0yyk.z0eek(xTextElement, z0ZzZzvxj, p2: true, p3))
				{
					z0ZzZzvxj.z0yyk.z0ark = true;
				}
				bool flag13 = true;
				if (!flag3 && !flag9 && xTextElement is XTextParagraphFlagElement)
				{
					flag13 = false;
					if (z0ZzZzrzj.z0jyk >= 0)
					{
						flag13 = true;
					}
				}
				if (flag13)
				{
					if (flag12)
					{
						z0ZzZzvxj.z0yyk.z0eek(xTextElement, z0ZzZzvxj);
						z0ZzZzvxj.z0gyk.DrawString("*", z0ZzZzrzj.z0btk, z0ZzZzyfh.z0eek(z0ZzZzrzj.z0bek), z0ZzZzbdh7, z0ttk);
					}
					else
					{
						if (!flag11 && !(xTextElement is XTextSectionElement))
						{
							z0ZzZzvxj.z0gyk.z0eek(p4);
						}
						if (xTextElement.z0cuk)
						{
							z0ZzZzvxj.z0iyk = this;
							if (z0ZzZzvxj.z0guk != null)
							{
								if (flag9 || xTextElement is XTextFieldBorderElement)
								{
									z0ZzZzvxj.z0guk.z0bek();
								}
								else
								{
									z0ZzZzvxj.z0guk.z0tek();
								}
							}
							if (flag10 && j > 0 && array2[j - 1] is XTextTableElement)
							{
								z0ZzZzvxj.z0mtk = true;
							}
							xTextElement.z0tt(z0ZzZzvxj);
						}
					}
				}
				if (flag5)
				{
					z0ZzZzvxj.z0yyk.z0ark = false;
					z0ZzZzvxj.z0gtk = z0ZzZzbdh7;
					z0ZzZzvxj.z0yyk.z0eek(xTextElement, z0ZzZzvxj, p2: false, p3);
				}
				if (z0ZzZzhmk != null)
				{
					bool flag14 = false;
					if (flag7)
					{
						flag14 = false;
					}
					else if (contentRangeMode != ContentRangeMode.Cell)
					{
						flag14 = z0ZzZzhkh.z0rek(xTextElement);
					}
					if (flag14 && !(xTextElement is z0ZzZzlzj))
					{
						if (xTextElement.z0aek().z0xyk == ContentLayoutAlign.Surroundings)
						{
							z0ZzZzbdh6.z0yek(Math.Max(z0ZzZzbdh6.z0iek(), xTextElement.Height));
						}
						if (xTextDocumentContentElement.z0oek().z0iek() == xTextElement)
						{
							z0ZzZzbdh z0ZzZzbdh8 = z0ZzZzbdh6;
							z0ZzZzbdh8.z0tek(xTextElement.Width);
							z0ZzZzhmk.z0eek(z0ZzZzbdh8.z0oek(), num5, z0ZzZzbdh8.z0uek(), num7 - 3.125f);
						}
						else
						{
							z0ZzZzhmk.z0eek(z0ZzZzbdh6.z0oek(), num5, z0ZzZzbdh6.z0uek(), num7 - 3.125f);
						}
					}
				}
				if (flag4 && (z0ZzZzrzj.z0otk == ContentProtectType.Content || z0ZzZzrzj.z0otk == ContentProtectType.Range))
				{
					z0ZzZzhmk.z0eek(z0ZzZzbdh6);
				}
			}
			z0ZzZzvxj.z0guk?.z0tek();
			z0eek(z0ZzZzvxj, z0ZzZzzlh);
			if (z0ZzZzvxj.z0gyk.z0yek() != num9)
			{
				z0ZzZzvxj.z0gyk.z0rek();
			}
			if (z0ZzZzhmk != null && !z0ZzZzhmk.z0rek() && xTextDocument.z0yyk() != null)
			{
				z0ZzZzbdh z0ZzZzbdh9 = z0ZzZzbdh.z0xek;
				z0ZzZzbdh9 = ((!(this is XTextTableCellElement)) ? z0ZzZzhmk.z0eek() : z0ZzZzbdh.z0tek(z0qyk(), z0ZzZzhmk.z0eek()));
				xTextDocument.z0yyk().z0eek(z0ZzZzndh.z0eek(z0ZzZzbdh9));
			}
		}
		if (z0ork())
		{
			XTextElement[] array3 = z0tek();
			foreach (XTextElement xTextElement2 in array3)
			{
				z0ZzZzbdh z0ZzZzbdh10 = xTextElement2.z0qyk();
				z0ZzZzbdh z0ZzZzbdh11 = z0ZzZzbdh10;
				if (!z0ZzZzbdh.z0tek(p1, z0ZzZzbdh10).z0bek())
				{
					if (z0ZzZzvxj.z0wyk)
					{
						xTextDocument.z0vek(z0ZzZzbdh10);
					}
					z0ZzZzvxj.z0hyk = xTextElement2;
					z0ZzZzvxj.z0luk = xTextElement2.z0aek();
					z0ZzZzvxj.z0gtk = z0ZzZzbdh10;
					z0ZzZzvxj.z0tek(z0ZzZzvxj.z0luk.z0eek(z0ZzZzbdh10));
					if (flag5)
					{
						z0ZzZzvxj.z0yyk.z0eek(xTextElement2, z0ZzZzvxj, p2: true, p3);
					}
					xTextElement2.z0tt(z0ZzZzvxj);
					if (flag5)
					{
						z0ZzZzvxj.z0yyk.z0eek(xTextElement2, z0ZzZzvxj, p2: true, p3);
					}
					if (z0ZzZzvxj.z0byk == (z0ZzZzcxj)0 && z0ZzZzvxj.z0eyk && xTextDocumentContentElement.z0rek(xTextElement2))
					{
						xTextDocument.z0yyk().z0eek(z0ZzZzndh.z0eek(z0ZzZzbdh10));
					}
				}
			}
		}
		if ((!(this is XTextDocumentBodyElement) || z0ZzZzvxj.z0krk() != PageViewMode.Page) && z0nek())
		{
			z0ZzZzbdh z0ZzZzbdh12 = z0ZzZzvxj.z0nek();
			z0ZzZzbdh z0ZzZzbdh13 = z0myk_jiejie20260327142557();
			z0ZzZzbdh12 = z0ZzZzbdh.z0tek(z0ZzZzvxj.z0nek(), z0myk_jiejie20260327142557());
			z0ZzZzbdh12.z0eek(z0ZzZzbdh13.z0tek());
			z0ZzZzbdh12.z0tek(z0ZzZzbdh13.z0uek());
			if (z0ZzZzbdh12.z0nek() > z0ZzZzbdh13.z0nek())
			{
				z0ZzZzbdh12.z0rek(z0ZzZzbdh13.z0nek() - z0ZzZzbdh12.z0iek());
				z0ZzZzbdh12.z0yek(z0ZzZzbdh13.z0nek() - z0ZzZzbdh12.z0pek());
			}
			z0ZzZzvxj z0ZzZzvxj2 = z0ZzZzvxj.z0cek();
			z0ZzZzvxj2.z0rek(z0ZzZzbdh12);
			z0er(z0ZzZzvxj2);
		}
		z0xek(z0ZzZzvxj);
	}

	public override void z0fy(z0ZzZzdxj p0)
	{
		XTextElementList xTextElementList = z0be();
		if (xTextElementList == null || xTextElementList.Count <= 0)
		{
			return;
		}
		XTextElement xTextElement = xTextElementList.LastElement;
		if (!(xTextElement is XTextParagraphFlagElement))
		{
			xTextElement = null;
		}
		foreach (XTextElement item in xTextElementList.z0xrk())
		{
			if (item != xTextElement && (p0.z0yek() || item.z0yi()) && p0.z0eek(item.z0pek()))
			{
				item.z0fy(p0);
			}
		}
	}

	internal new z0qpk z0oek()
	{
		return (z0qpk)base.z0utk;
	}

	private void z0eek(bool p0)
	{
		z0frk(p0);
	}

	public bool z0eek(int p0)
	{
		return z0eek(p0, -1, p2: false);
	}

	public void z0eek(ContentAlignment p0, z0ZzZzrfh p1)
	{
		if (p1 == null)
		{
			z0qpk z0qpk = (z0qpk)base.z0utk;
			if (z0qpk != null)
			{
				z0qpk.z0uek = null;
			}
			return;
		}
		z0qpk z0qpk2 = (z0qpk)base.z0utk;
		if (z0qpk2 == null)
		{
			z0qpk2 = (z0qpk)(base.z0utk = new z0qpk());
		}
		z0qpk2.z0uek = p1;
		z0qpk2.z0iek = p0;
	}

	public new bool z0pek()
	{
		return z0vrk();
	}

	public override bool z0hr()
	{
		XTextDocumentContentElement xTextDocumentContentElement = z0qek();
		int num = xTextDocumentContentElement.z0frk().IndexOf(z0ie());
		int num2 = xTextDocumentContentElement.z0frk().IndexOf(z0dek()) - 1;
		if (num2 >= num)
		{
			return xTextDocumentContentElement.z0uek(num, num2 - num + 1);
		}
		return false;
	}

	public override void z0rt(ElementLoadEventArgs p0)
	{
		z0etk = null;
		z0utk = null;
		if (base.z0utk != null)
		{
			((z0qpk)base.z0utk).z0oek = null;
			((z0qpk)base.z0utk).z0mek = null;
			((z0qpk)base.z0utk).z0pek = null;
			z0ZzZzzej z0ZzZzzej = ((z0qpk)base.z0utk).z0rek;
			if (z0ZzZzzej != null && z0ZzZzzej.z0rek())
			{
				((z0qpk)base.z0utk).z0rek = null;
			}
		}
		base.z0rt(p0);
		z0gu();
	}

	internal bool z0eek(float p0)
	{
		z0iek(p0: false);
		z0ZzZzzlh[] array = z0zek();
		if (array == null || array.Length == 0)
		{
			return false;
		}
		float num = z0cw();
		float num2 = num + Height;
		if (p0 < 0f)
		{
			z0ZzZzerj z0ZzZzerj = z0jr().z0suk();
			for (int num3 = z0ZzZzerj.Count - 2; num3 >= 0; num3--)
			{
				float num4 = z0ZzZzerj[num3].z0qrk();
				if (num4 > num && num4 < num2)
				{
					p0 = num4;
					break;
				}
				if (num4 < num)
				{
					return false;
				}
			}
			z0ZzZzzlh[] array2 = array;
			foreach (z0ZzZzzlh obj in array2)
			{
				obj.z0nek(obj.z0trk());
			}
		}
		int num5 = 0;
		bool result = false;
		float num6 = array[0].z0zrk();
		float num7 = Height - array[array.Length - 1].z0ark();
		if (num6 <= 0f && num7 <= 0f)
		{
			return false;
		}
		float num8 = z0cw();
		int num9 = array.Length;
		for (int j = num5; j < num9; j++)
		{
			z0ZzZzzlh z0ZzZzzlh = array[j];
			float num10 = num8 + z0ZzZzzlh.z0zrk();
			if (!(p0 >= num10 + 5f) || !(p0 <= num10 + z0ZzZzzlh.z0ytk() - 3f))
			{
				continue;
			}
			if (p0 - num10 - num7 < num10 + z0ZzZzzlh.z0ytk() - p0 - num6)
			{
				float num11 = Math.Min(p0 - num10, num7);
				for (int k = j; k < num9; k++)
				{
					z0ZzZzzlh obj2 = array[k];
					obj2.z0nek(obj2.z0zrk() + num11);
					obj2.z0erk();
					result = true;
				}
			}
			else
			{
				float num12 = Math.Min(num10 + z0ZzZzzlh.z0ytk() - p0, num6);
				for (int l = 0; l <= j; l++)
				{
					z0ZzZzzlh obj3 = array[l];
					obj3.z0nek(obj3.z0zrk() - num12);
					obj3.z0erk();
					result = true;
				}
			}
			z0iek(p0: true);
			break;
		}
		return result;
	}

	public virtual void z0ly()
	{
		z0rek(p0: false);
		Height = z0hrk();
	}

	public new XTextElementList z0mek()
	{
		return z0utk;
	}

	public virtual bool z0eek(int p0, int p1, bool p2)
	{
		return z0wu(p0, p1, p2, p3: true);
	}

	protected internal new bool z0nek()
	{
		z0ZzZzzej z0ZzZzzej = z0ju();
		if (z0ZzZzzej != null && z0ZzZzzej.z0uek())
		{
			return z0ZzZzzej.z0zek() > 0f;
		}
		return false;
	}

	public virtual PageContentPartyStyle z0fu()
	{
		if (z0jr() == null)
		{
			return PageContentPartyStyle.Body;
		}
		XTextDocument xTextDocument = z0jr();
		for (XTextElement xTextElement = this; xTextElement != null; xTextElement = xTextElement.z0ji())
		{
			if (xTextElement is XTextDocumentContentElement)
			{
				if (xTextElement == xTextDocument.z0xyk())
				{
					return PageContentPartyStyle.Body;
				}
				if (xTextElement == xTextDocument.z0pyk())
				{
					return PageContentPartyStyle.Header;
				}
				if (xTextElement == xTextDocument.z0lik())
				{
					return PageContentPartyStyle.Footer;
				}
				if (xTextElement == xTextDocument.z0cyk())
				{
					return PageContentPartyStyle.HeaderForFirstPage;
				}
				if (xTextElement == xTextDocument.z0guk())
				{
					return PageContentPartyStyle.FooterForFirstPage;
				}
			}
		}
		return PageContentPartyStyle.Body;
	}

	internal float z0eek(z0ZzZzzlh p0)
	{
		z0ZzZzrzj z0ZzZzrzj = p0.z0grk().z0aek();
		float result = 0f;
		if (z0ZzZzrzj.z0cyk != LineSpacingStyle.SpaceExactly)
		{
			result = ((!(z0mrk() > 0f)) ? z0ZzZzrzj.z0eek(p0.z0wrk(), p0.z0ftk() * z0drk(), GraphicsUnit.Document) : z0mrk());
			if (p0.z0xek())
			{
				result = 0f;
			}
		}
		return result;
	}

	protected XTextContentElement()
	{
		z0nek(p0: true);
	}

	internal void z0rek(bool p0)
	{
		z0ark(p0);
	}

	private void z0eek(z0ZzZzvxj p0, z0ZzZzzlh p1)
	{
		z0ZzZzwzj z0ZzZzwzj = z0yrk();
		if (z0ZzZzwzj == null || z0ZzZzwzj.Count == 0)
		{
			return;
		}
		if (p0.z0byk == (z0ZzZzcxj)3 && p0.z0ytk)
		{
			for (int num = z0ZzZzwzj.Count - 1; num >= 0; num--)
			{
				z0ZzZzqzj z0ZzZzqzj = z0ZzZzwzj[num];
				bool flag = false;
				using (zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = z0ZzZzqzj.z0rek().z0ltk())
				{
					while (z0bpk.MoveNext())
					{
						XTextElement current = z0bpk.Current;
						if (z0qek().z0oek().z0yek(current))
						{
							flag = true;
							break;
						}
					}
				}
				if (!flag)
				{
					z0ZzZzwzj.RemoveAt(num);
				}
			}
		}
		if (z0ZzZzwzj != null && z0ZzZzwzj.Count <= 0)
		{
			return;
		}
		z0ZzZzbdh z0ZzZzbdh = z0qyk();
		foreach (z0ZzZzqzj item in z0ZzZzwzj)
		{
			if (item.z0tek() != p1)
			{
				continue;
			}
			z0ZzZzbdh z0ZzZzbdh2 = item.z0eek();
			z0ZzZzbdh2.z0tek(z0ZzZzbdh.z0oek(), z0ZzZzbdh.z0pek());
			if (z0ZzZzbdh.z0tek(z0ZzZzbdh2, p0.z0nek()).z0iek() > 5f && (p0.z0hrk().z0bek() || !(z0ZzZzbdh.z0tek(p0.z0hrk(), z0ZzZzbdh2).z0iek() < 2f)))
			{
				z0ZzZzadh z0ZzZzadh = p0.z0gyk.z0lrk();
				if (z0ZzZzadh != null)
				{
					z0ZzZzbdh z0ZzZzbdh3 = z0ZzZzadh.z0irk;
					z0ZzZzadh.z0irk = z0ZzZzbdh.z0xek;
					item.z0yek().z0eek(p0.z0gyk, z0ZzZzbdh2);
					z0ZzZzadh.z0irk = z0ZzZzbdh3;
				}
				else if (p0.z0gyk.z0uek() != null)
				{
					item.z0yek().z0eek(p0.z0gyk, z0ZzZzbdh2);
				}
			}
		}
	}

	public override void Dispose()
	{
		base.Dispose();
		if (z0utk != null)
		{
			z0utk.z0vrk();
			z0utk = null;
		}
		z0grk();
		if (z0atk != null)
		{
			z0atk.Clear();
			z0atk.Capacity = 0;
			z0atk = null;
		}
	}

	private new bool z0bek()
	{
		if (this is XTextSectionElement)
		{
			return ((XTextSectionElement)this).z0rek();
		}
		return false;
	}

	internal new void z0vek()
	{
		if (z0utk != null && z0ntk != null && ((zzz.z0ZzZzkuk<XTextElement>)z0utk).z0krk() == ((zzz.z0ZzZzkuk<XTextElement>)z0ntk).z0krk())
		{
			z0utk.z0frk();
			z0utk.z0dtk();
		}
	}

	internal void z0rek(float p0)
	{
		if (p0 == 1f)
		{
			if (base.z0utk != null)
			{
				((z0qpk)base.z0utk).z0lrk = p0;
			}
		}
		else
		{
			z0vrk().z0lrk = p0;
		}
	}

	internal virtual bool z0zt(z0ZzZzazj p0)
	{
		z0eek(DCBooleanValueHasDefault.Default);
		p0.z0grk = null;
		z0itk++;
		z0oek(p0: false);
		z0uek(p0: false);
		XTextDocument xTextDocument = z0jr();
		if (xTextDocument == null)
		{
			p0.z0rek(p0: false);
			return false;
		}
		if (xTextDocument.z0mzk)
		{
			throw new Exception(z0ZzZziok.z0vuk());
		}
		if (z0bek())
		{
			p0.z0rek(p0: false);
			return false;
		}
		z0yek(p0: true);
		xTextDocument.z0wik();
		XTextElementList xTextElementList = z0be();
		bool flag = xTextElementList.Count == 1 && xTextElementList[0] is XTextParagraphFlagElement && xTextElementList[0].z0buk < 0;
		p0.z0lrk = ((XTextElement)this).z0ork();
		XTextDocumentContentElement xTextDocumentContentElement = z0qek();
		if (xTextDocumentContentElement is XTextDocumentBodyElement)
		{
			((XTextDocumentBodyElement)xTextDocumentContentElement).z0yek();
		}
		List<XTextInputFieldElementBase> list = ((z0qpk)base.z0utk)?.z0krk;
		if (list != null && list.Count > 0)
		{
			using z0ZzZzjpk p1 = z0ru();
			z0ZzZzvxj p2 = z0jr().z0bek(p1, (z0ZzZzcxj)0);
			foreach (XTextInputFieldElementBase item3 in list)
			{
				item3.z0eek(p2);
			}
		}
		z0ZzZzzej z0ZzZzzej = z0ju();
		if (z0ZzZzzej != null)
		{
			if (z0ZzZzzej != xTextDocument.z0qxk)
			{
				z0ZzZzzej.z0eek(xTextDocument.z0bek(xTextDocument.PageSettings), GraphicsUnit.Document, z0drk());
			}
			z0ZzZzrzj z0ZzZzrzj = z0aek();
			z0oek(z0ZzZzzej.z0nek());
			if (z0zrk() && z0ZzZzrzj.z0xrk > 0f && z0ZzZzrzj.z0quk > 0f && xTextDocument.z0bu().IgnoreTopBottomPaddingWhenGridLineLayout)
			{
				z0uek(p0: true);
			}
		}
		if (!z0urk())
		{
			z0ZzZzrzj z0ZzZzrzj2 = z0aek();
			if (z0ZzZzrzj2.z0quk == 0f && z0ZzZzrzj2.z0xrk == 0f)
			{
				z0uek(p0: true);
			}
		}
		XTextElement xTextElement = p0.z0iek();
		XTextElement xTextElement2 = p0.z0yek();
		VerticalAlignStyle verticalAlignStyle = p0.z0rek();
		p0.z0krk = 0;
		z0atk = null;
		z0nek(p0: false);
		bool flag2 = true;
		if (Width == 0f)
		{
			if (this is XTextDocumentContentElement)
			{
				Width = xTextDocument.PageSettings.z0prk();
			}
		}
		else if (Width < 0f)
		{
			Width = xTextDocument.PageSettings.z0prk();
		}
		XTextElementList xTextElementList2 = z0trk();
		if (xTextElementList2.Count == 0)
		{
			z0grk();
			p0.z0rek(p0: false);
			return flag2;
		}
		z0ZzZzlkh z0ZzZzlkh = p0.z0eek();
		if (z0etk != null)
		{
			z0ZzZzlkh.z0zek(z0etk);
		}
		else
		{
			z0ZzZzlkh.z0nrk();
		}
		XTextElement xTextElement3 = ((xTextElementList2.Count == 1) ? xTextElementList2[0] : null);
		if (xTextElement3 != null && xTextElement3.z0buk >= 0)
		{
			xTextElement3 = null;
		}
		bool flag3 = xTextElement == null || z0ZzZzlkh.Count == 0;
		int[] array = null;
		float[] array2 = null;
		if (XTextDocument.z0yxk)
		{
			p0.z0xek = false;
		}
		else if (z0ZzZzlkh.Count > 0 && !p0.z0bek)
		{
			int count = z0ZzZzlkh.Count;
			array = new int[count * 2];
			array2 = new float[count * 2];
			for (int i = 0; i < count; i++)
			{
				z0ZzZzzlh z0ZzZzzlh = z0ZzZzlkh.z0yek(i);
				array2[i * 2] = z0ZzZzzlh.z0trk();
				array2[i * 2 + 1] = z0ZzZzzlh.z0ytk();
				array[i * 2] = z0ZzZzzlh.z0hrk();
				array[i * 2 + 1] = z0ZzZzzlh.z0otk();
			}
		}
		int num = -1;
		if (xTextElement2 != null)
		{
			num = xTextElementList2.z0bek(xTextElement2);
		}
		int num2 = 0;
		int num3 = 0;
		int num4 = z0ZzZzlkh.Count - 1;
		if (!XTextDocument.z0yxk)
		{
			if (xTextElement3 == null)
			{
				if (xTextElement == null)
				{
					xTextElement = xTextElementList2[0];
				}
				else
				{
					num2 = xTextElementList2.z0bek(xTextElement);
				}
			}
			else
			{
				xTextElement = xTextElement3;
				num2 = 0;
			}
			if (num2 < 0)
			{
				throw new Exception("未找到起始元素");
			}
			if (xTextElement3 == null && num2 > 0)
			{
				for (int num5 = num2; num5 >= 0; num5--)
				{
					z0ZzZzzlh z0ZzZzzlh2 = xTextElementList2[num5].z0kik;
					if (z0ZzZzzlh2 != null)
					{
						num3 = z0ZzZzlkh.IndexOf(z0ZzZzzlh2);
						if (num3 >= 0)
						{
							num3--;
							if (num3 < 0)
							{
								num3 = 0;
							}
							break;
						}
					}
				}
				if (num3 < 0)
				{
					num3 = 0;
				}
			}
			int count2 = z0ZzZzlkh.Count;
			if (num >= 0)
			{
				for (int j = num; j < count2; j++)
				{
					if (xTextElementList2[j].z0ptk() == null)
					{
						continue;
					}
					num4 = z0ZzZzlkh.IndexOf(xTextElementList2[j].z0ptk());
					if (num4 < 0)
					{
						continue;
					}
					for (int k = num4; k < count2; k++)
					{
						if (z0ZzZzlkh[k].LastElement is XTextParagraphFlagElement)
						{
							num4 = k;
							break;
						}
					}
					num4 = Math.Min(num4 + 2, count2 - 1);
					break;
				}
			}
			if (xTextElement.z0ptk() != null)
			{
				z0ZzZzzlh z0ZzZzzlh3 = xTextElement.z0ptk();
				if (num2 == 0)
				{
					if (z0ZzZzlkh.Count > 0)
					{
						z0ZzZzzlh z0ZzZzzlh4 = z0ZzZzlkh[0];
						bool flag4 = true;
						foreach (XTextElement item4 in ((zzz.z0ZzZzkuk<XTextElement>)z0ZzZzzlh4).z0xrk())
						{
							if (xTextElementList2.z0bek(item4) >= 0)
							{
								flag4 = false;
								break;
							}
						}
						if (flag4)
						{
							xTextElement.z0yek((z0ZzZzzlh)null);
							z0ZzZzlkh.Clear();
							if (base.z0utk != null)
							{
								((z0qpk)base.z0utk).z0oek = null;
							}
						}
					}
				}
				else
				{
					foreach (XTextElement item5 in ((zzz.z0ZzZzkuk<XTextElement>)z0ZzZzzlh3).z0xrk())
					{
						int num6 = xTextElementList2.z0vek(item5);
						if (num6 >= 0 && num2 > num6)
						{
							num2 = num6;
							xTextElement = item5;
						}
					}
				}
			}
			else
			{
				num2 = 0;
			}
		}
		else
		{
			xTextElement = xTextElementList2.z0krk();
		}
		z0aek();
		List<XTextElement> list2 = null;
		z0ZzZzzlh z0ZzZzzlh5 = null;
		XTextElement[] array3 = ((z0qpk)base.z0utk)?.z0mek;
		z0ZzZzlkh z0ZzZzlkh2 = zzz.z0ZzZzgik<z0ZzZzlkh>.z0iek.z0yek();
		z0ZzZzlkh2.z0rek(zzz.z0ZzZzgik<z0ZzZzzlh[]>.z0iek.z0yek(), 0);
		z0ZzZzzlh z0ZzZzzlh6 = null;
		if (xTextElement3 == null)
		{
			if (xTextElementList2.z0zek() == null)
			{
				list2 = zzz.z0ZzZzgik<List<XTextElement>>.z0iek.z0yek();
			}
			z0ZzZzzlh p3 = xTextElementList2[num2].z0ptk();
			z0ZzZzzlh z0ZzZzzlh7 = z0ZzZzlkh.z0eek(p3);
			if (z0ZzZzzlh7 != null && xTextDocument.z0xck != null)
			{
				int num7 = xTextElementList2.z0vek(z0ZzZzzlh7.LastElement);
				if (num7 >= 0)
				{
					XTextParagraphFlagElement xTextParagraphFlagElement = xTextElementList2.z0oek(num7);
					if (xTextParagraphFlagElement != null && z0ZzZzzlh7.z0grk() != xTextParagraphFlagElement)
					{
						xTextParagraphFlagElement.z0eek((XTextParagraphListItemElement)null);
						XTextParagraphFlagElement xTextParagraphFlagElement2 = z0ZzZzzlh7.z0grk();
						for (int num8 = z0ZzZzlkh.z0rek(z0ZzZzzlh7) - 1; num8 >= 0; num8--)
						{
							z0ZzZzzlh z0ZzZzzlh8 = z0ZzZzlkh[num8];
							if (z0ZzZzzlh8.z0grk() != xTextParagraphFlagElement2)
							{
								break;
							}
							z0ZzZzzlh8.z0eek(xTextParagraphFlagElement);
						}
						z0ZzZzzlh7.z0eek(xTextParagraphFlagElement);
					}
				}
			}
			z0ZzZzzlh6 = z0eek(p0, z0ZzZzzlh7);
		}
		else
		{
			z0ZzZzzlh6 = z0eek(p0, null);
		}
		if (((z0qpk)base.z0utk)?.z0mek != null)
		{
			((z0qpk)base.z0utk).z0pek = new Dictionary<XTextElement, z0ZzZzzlh>();
		}
		z0ZzZzlkh2.Add(z0ZzZzzlh6);
		if (xTextElement3 != null)
		{
			z0ZzZzzlh6.z0rek(new XTextElement[1] { xTextElement3 }, 1);
		}
		else
		{
			if (z0ZzZzzlh6.Capacity == 0)
			{
				p0.z0eek(z0ZzZzzlh6);
			}
			z0ZzZzjxj z0ZzZzjxj = p0.z0nek;
			z0ZzZzjxj.z0eek(xTextElementList2, num2, xTextElementList2.Count - num2);
			bool flag5 = true;
			DCWordBreakStyle wordBreak = z0bu().WordBreak;
			bool flag6 = false;
			while (true)
			{
				z0ZzZzzlh p7;
				z0ZzZzzlh[] array5;
				int num17;
				int num18;
				if (z0ZzZzjxj.z0yek() > 0)
				{
					bool flag7 = false;
					XTextElement p4 = z0ZzZzjxj.z0eek();
					XTextElement xTextElement4 = z0ZzZzjxj.z0tek();
					xTextElement4.z0btk();
					if (xTextElement4 is XTextObjectElement && xTextElement4 is XTextHorizontalLineElement)
					{
						xTextElement4.Width = ((XTextElement)this).z0ork() - 10f;
					}
					if (z0ZzZzzlh6.Count == 0)
					{
						if (xTextElement4 is XTextCharElement)
						{
							XTextCharElement xTextCharElement = (XTextCharElement)xTextElement4;
							if (xTextCharElement.z0bek == '\t')
							{
								xTextCharElement.z0pek();
							}
						}
						z0ZzZzzlh6.z0eek(xTextElement4, p4);
						if (z0ZzZzjzj.z0yek(xTextElement4))
						{
							flag7 = true;
							if (z0ZzZzjxj.z0yek() > 0 && z0eek(z0ZzZzjxj.z0uek()))
							{
								flag7 = false;
							}
						}
						else if (z0ZzZzjzj.z0tek(xTextElement4))
						{
							flag7 = true;
						}
					}
					else
					{
						bool flag8 = z0ZzZzjzj.z0yek(xTextElement4);
						if (xTextElement4 is XTextTableElement && z0ZzZzzlh6.Count == 1 && z0ZzZzzlh6[0] is XTextFieldBorderElement)
						{
							XTextFieldBorderElement xTextFieldBorderElement = (XTextFieldBorderElement)z0ZzZzzlh6[0];
							flag8 = ((!string.IsNullOrEmpty(xTextFieldBorderElement.Text) || !string.IsNullOrEmpty(xTextFieldBorderElement.z0vek())) ? true : false);
						}
						if (flag8)
						{
							z0ZzZzjxj.z0eek(xTextElement4);
							flag7 = true;
						}
						else if (!z0ZzZzzlh6.z0eek(xTextElement4, p4))
						{
							z0ZzZzjxj.z0eek(xTextElement4);
							flag7 = true;
							bool flag9 = false;
							if (z0ZzZzzlh6.Count > 1 && !z0ZzZzjzj.z0rek(z0ZzZzzlh6.LastElement))
							{
								flag9 = true;
								if (z0ZzZzzlh6.Count == 2 && z0ZzZzzlh6[0] is XTextParagraphListItemElement)
								{
									flag9 = false;
								}
							}
							if (flag9)
							{
								XTextElement xTextElement5 = z0ZzZzzlh6.z0ttk();
								if (xTextElement5 != null)
								{
									z0ZzZzjxj.z0eek(xTextElement5);
									list2.Add(xTextElement5);
								}
							}
							else
							{
								bool flag10 = false;
								if (!z0ZzZzjzj.z0eek(xTextElement4) || !z0ZzZzjzj.z0rek(z0ZzZzzlh6.LastElement))
								{
									flag10 = true;
									if (z0ZzZzzlh6.Count == 2 && z0ZzZzzlh6[0] is XTextParagraphListItemElement)
									{
										flag10 = false;
									}
								}
								if (flag10)
								{
									XTextElement xTextElement6 = z0ZzZzzlh6.z0ttk();
									if (xTextElement6 != null)
									{
										z0ZzZzjxj.z0eek(xTextElement6);
										list2.Add(xTextElement6);
										if (!z0ZzZzjzj.z0eek(xTextElement6) && z0ZzZzzlh6.Count > 2)
										{
											xTextElement6 = z0ZzZzzlh6.z0ttk();
											if (xTextElement6 != null)
											{
												z0ZzZzjxj.z0eek(xTextElement6);
												list2.Add(xTextElement6);
											}
										}
									}
								}
								XTextCharElement xTextCharElement2 = z0ZzZzjxj.z0uek() as XTextCharElement;
								bool flag11 = false;
								if (wordBreak == DCWordBreakStyle.Normal && xTextCharElement2 != null)
								{
									if (z0ZzZzjzj.z0tek(xTextCharElement2.z0bek))
									{
										flag11 = true;
									}
									if (z0ZzZzugh.z0eek(xTextCharElement2.z0bek))
									{
										flag11 = true;
									}
								}
								if (flag11)
								{
									float num9 = 0f;
									float num10 = z0ZzZzzlh6.z0itk();
									int num11 = 0;
									int num12 = -1;
									if (z0ZzZzugh.z0eek(xTextCharElement2.z0bek))
									{
										int num13 = z0ZzZzzlh6.Count - 1;
										while (num13 >= 0 && z0ZzZzzlh6[num13] is XTextCharElement)
										{
											char p5 = ((XTextCharElement)z0ZzZzzlh6[num13]).z0bek;
											bool flag12 = false;
											if (z0ZzZzugh.z0tek(p5))
											{
												break;
											}
											if (z0ZzZzugh.z0eek(p5))
											{
												flag12 = true;
											}
											if (!flag12)
											{
												break;
											}
											num9 += z0ZzZzzlh6[num13].Width;
											num11++;
											num12 = num13;
											if (num11 > 7)
											{
												break;
											}
											num13--;
										}
									}
									else
									{
										int num14 = z0ZzZzzlh6.Count - 1;
										while (num14 >= 0)
										{
											if (z0ZzZzzlh6[num14] is XTextCharElement)
											{
												char p6 = ((XTextCharElement)z0ZzZzzlh6[num14]).z0bek;
												bool flag13 = false;
												if (z0ZzZzjzj.z0tek(p6))
												{
													flag13 = true;
												}
												if (!flag13)
												{
													break;
												}
												num9 += z0ZzZzzlh6[num14].Width;
												num11++;
												num12 = num14;
												num14--;
												continue;
											}
											if (z0ZzZzzlh6[num14] is XTextParagraphListItemElement)
											{
												num12 = 0;
											}
											break;
										}
									}
									if (num12 > z0ZzZzzlh6.Count / 3 && num9 < num10 / 3f)
									{
										for (int num15 = z0ZzZzzlh6.Count - 1; num15 >= num12; num15--)
										{
											XTextElement xTextElement7 = z0ZzZzzlh6[num15];
											z0ZzZzzlh6.RemoveAt(num15);
											z0ZzZzjxj.z0eek(xTextElement7);
											list2.Add(xTextElement7);
										}
									}
								}
							}
						}
						else if (z0ZzZzjzj.z0tek(xTextElement4))
						{
							flag7 = true;
						}
					}
					if (array3 != null && z0ZzZzzlh6.z0xek())
					{
						XTextElement[] array4 = array3;
						foreach (XTextElement xTextElement8 in array4)
						{
							z0ZzZzzlh z0ZzZzzlh9 = xTextElement8.z0ptk();
							if (z0ZzZzzlh9 == null && ((z0qpk)base.z0utk).z0pek.ContainsKey(xTextElement8))
							{
								z0ZzZzzlh9 = ((z0qpk)base.z0utk).z0pek[xTextElement8];
							}
							if (z0ZzZzzlh9 != null)
							{
								float num16 = z0ZzZzzlh9.z0zrk() + xTextElement8.z0yt() + xTextElement8.Height;
								if (z0ZzZzzlh6.z0zrk() < num16)
								{
									z0ZzZzzlh6.z0nek(num16);
								}
							}
						}
					}
					if (xTextElement4 is XTextCharElement { z0bek: '\t' } xTextCharElement3)
					{
						xTextCharElement3.z0pek();
					}
					if (!flag7)
					{
						continue;
					}
					if (flag5)
					{
						flag5 = false;
					}
					else if (z0ZzZzlkh.Count > 0 && (num <= 0 || xTextElementList2.z0grk(xTextElement4) > num) && num4 >= 0)
					{
						p7 = z0ZzZzlkh2.z0rek();
						array5 = z0ZzZzlkh.z0krk();
						num17 = num4;
						while (num17 >= num3 && !array5[num17].z0uek_jiejie20260327142557())
						{
							if (!p0.z0xek || !z0ZzZzzlh.z0eek(p7, array5[num17]))
							{
								num17--;
								continue;
							}
							goto IL_0cea;
						}
						num18 = z0ZzZzlkh.Count - 1;
						while (num18 >= num4 && !z0ZzZzlkh[num18].z0uek_jiejie20260327142557())
						{
							if (!p0.z0xek || !z0ZzZzzlh.z0eek(p7, z0ZzZzlkh[num18]))
							{
								num18--;
								continue;
							}
							goto IL_0d4f;
						}
					}
					if (z0ZzZzjxj.z0yek() > 0)
					{
						if (z0ZzZzzlh6 != null && z0ZzZzzlh6.Count > 0)
						{
							z0ZzZzzlh6.z0mek(p0.z0lrk);
							z0eek(z0ZzZzzlh6, p0.z0bek);
							p0.z0rek(z0ZzZzzlh6);
						}
						z0ZzZzzlh6 = z0eek(p0, z0ZzZzlkh2.z0rek());
						p0.z0eek(z0ZzZzzlh6);
						z0ZzZzlkh2.Add(z0ZzZzzlh6);
						continue;
					}
					z0ZzZzjxj.z0rek();
					flag6 = true;
					if (z0ZzZzzlh6 != null && z0ZzZzzlh6.Count > 0)
					{
						z0eek(z0ZzZzzlh6, p0.z0bek);
					}
				}
				if (!flag6)
				{
					z0ZzZzjxj.z0rek();
				}
				p0.z0rek(z0ZzZzzlh6);
				break;
				IL_0d4f:
				z0ZzZzzlh5 = z0ZzZzlkh[num18];
				z0eek(p7, p0.z0bek);
				p0.z0rek(p7);
				break;
				IL_0cea:
				z0ZzZzzlh5 = array5[num17];
				z0eek(p7, p0.z0bek);
				p0.z0rek(p7);
				break;
			}
		}
		p0.z0grk = null;
		bool flag14 = false;
		bool flag15 = false;
		if (p0.z0frk)
		{
			z0ZzZzzlh6 = z0ZzZzlkh2[0];
			z0ZzZzlkh2.z0yrk(p0: true);
			z0ZzZzlkh.Add(z0ZzZzzlh6);
			z0ZzZzzlh6.z0vtk();
			z0ZzZzzlh6.z0tek(p0: false);
			p0.z0rek(p0: true);
			xTextDocumentContentElement.z0tek(z0ZzZzlkh.Count);
			z0etk = z0ZzZzlkh.ToArray();
			p0.z0eek(z0ZzZzlkh);
			_ = z0etk[z0etk.Length - 1];
			return flag2;
		}
		z0ZzZzlkh z0ZzZzlkh3 = null;
		if (!z0ZzZzdbj.z0bpk)
		{
			z0ZzZzlkh3 = new z0ZzZzlkh();
			z0ZzZzlkh3.z0rek(zzz.z0ZzZzgik<z0ZzZzzlh[]>.z0iek.z0yek(), 0);
		}
		if (flag && z0ZzZzlkh2.Count == 1)
		{
			z0ZzZzzlh6.z0jtk();
			z0ZzZzzlh6[0].z0kik = z0ZzZzzlh6;
			if (z0ZzZzlkh.Count > 0)
			{
				z0ZzZzlkh3?.z0tek(z0ZzZzlkh);
				z0ZzZzlkh.Clear();
			}
			z0ZzZzlkh.Add(z0ZzZzzlh6);
			flag14 = true;
		}
		else
		{
			if (z0ZzZzlkh2.Count > 0)
			{
				z0ZzZzzlh lastElement = z0ZzZzlkh2.LastElement;
				if (lastElement.Count == 0)
				{
					z0ZzZzlkh2.RemoveAt(z0ZzZzlkh2.Count - 1);
					if (z0ZzZzlkh2.Count > 0)
					{
						z0rek(z0ZzZzlkh2.LastElement);
					}
				}
				else
				{
					z0rek(lastElement);
				}
			}
			int num19 = 0;
			_ = xTextDocument.z0qxk;
			if (xTextElement.z0ptk() != null)
			{
				num19 = z0ZzZzlkh.IndexOf(xTextElement.z0ptk());
			}
			if (num19 < 0)
			{
				num19 = 0;
			}
			if (z0ZzZzzlh5 == null && z0ZzZzlkh2.Count > 1 && z0ZzZzlkh.Count > 0)
			{
				z0ZzZzzlh lastElement2 = z0ZzZzlkh2.LastElement;
				for (int num20 = z0ZzZzlkh.Count - 1; num20 >= 0; num20--)
				{
					if (z0ZzZzzlh.z0eek(lastElement2, z0ZzZzlkh[num20]))
					{
						z0ZzZzzlh5 = z0ZzZzlkh[num20];
						break;
					}
				}
			}
			if (z0ZzZzzlh5 == null && z0ZzZzlkh2.Count == 1 && z0ZzZzlkh.Count > 0 && ((XTextElementList)z0ZzZzlkh.z0rek()).z0krk() == ((XTextElementList)z0ZzZzlkh2[0]).z0krk())
			{
				z0ZzZzzlh5 = z0ZzZzlkh.z0rek();
			}
			if (z0ZzZzzlh5 == null)
			{
				flag15 = true;
				flag14 = true;
				if (z0ZzZzlkh.Count > 0)
				{
					if (num19 == 0)
					{
						z0ZzZzlkh3?.z0tek(z0ZzZzlkh);
						zzz.z0ZzZzguk<z0ZzZzzlh>.z0uek(z0ZzZzlkh);
						z0ZzZzlkh.Clear();
					}
					else
					{
						for (int num21 = z0ZzZzlkh.Count - 1; num21 >= num19; num21--)
						{
							z0ZzZzzlh z0ZzZzzlh10 = z0ZzZzlkh[num21];
							z0ZzZzlkh3?.Add(z0ZzZzzlh10);
							zzz.z0ZzZzguk<z0ZzZzzlh>.z0tek(z0ZzZzzlh10);
							z0ZzZzlkh.RemoveAt(num21);
						}
					}
				}
				z0ZzZzlkh.z0tek(z0ZzZzlkh2);
				for (int num22 = z0ZzZzlkh2.Count - 1; num22 >= 0; num22--)
				{
					z0ZzZzlkh2[num22].z0vtk();
				}
			}
			else
			{
				if (xTextElement.z0ptk() == null)
				{
					_ = z0ZzZzlkh[0];
				}
				int num23 = z0ZzZzlkh.IndexOf(z0ZzZzzlh5);
				if (num23 - num19 + 1 != z0ZzZzlkh2.Count)
				{
					flag15 = true;
					flag14 = true;
				}
				else
				{
					int count3 = z0ZzZzlkh2.Count;
					for (int m = 0; m < count3; m++)
					{
						z0ZzZzzlh z0ZzZzzlh11 = z0ZzZzlkh2[m];
						z0ZzZzzlh z0ZzZzzlh12 = z0ZzZzlkh[m + num19];
						if (z0ZzZzzlh11.z0ytk() != z0ZzZzzlh12.z0ytk())
						{
							flag15 = true;
							break;
						}
					}
				}
				if (z0ZzZzlkh2.z0rek().z0zrk() != z0ZzZzzlh5.z0zrk())
				{
					flag14 = true;
				}
				if (!flag15 && z0ZzZzlkh2.Count > 1)
				{
					num23--;
					z0ZzZzlkh2.RemoveAt(z0ZzZzlkh2.Count - 1);
				}
				if (!flag15)
				{
					for (int n = 0; n < z0ZzZzlkh2.Count; n++)
					{
						z0ZzZzzlh z0ZzZzzlh13 = z0ZzZzlkh2[n];
						z0ZzZzlkh3?.Add(z0ZzZzzlh13);
						z0ZzZzzlh13.z0eek(z0ZzZzlkh[n + num19].z0dtk());
						z0ZzZzzlh13.z0vtk();
						z0ZzZzzlh z0ZzZzzlh14 = z0ZzZzlkh[n + num19];
						z0ZzZzlkh3?.Add(z0ZzZzzlh14);
						z0ZzZzlkh.z0eek(n + num19, z0ZzZzzlh13);
						zzz.z0ZzZzguk<z0ZzZzzlh>.z0tek(z0ZzZzzlh14);
					}
				}
				else
				{
					for (int num24 = num23; num24 >= num19; num24--)
					{
						if (num24 >= 0)
						{
							if (z0ZzZzlkh3 != null && xTextDocument.z0yyk() != null)
							{
								z0ZzZzzlh item = z0ZzZzlkh[num24];
								z0ZzZzlkh3.Add(item);
							}
							zzz.z0ZzZzguk<z0ZzZzzlh>.z0tek(z0ZzZzlkh[num24]);
							z0ZzZzlkh.RemoveAt(num24);
						}
					}
					for (int num25 = 0; num25 < z0ZzZzlkh2.Count; num25++)
					{
						if (z0ZzZzlkh3 != null && xTextDocument.z0yyk() != null)
						{
							z0ZzZzzlh item2 = z0ZzZzlkh2[num25];
							z0ZzZzlkh3.Add(item2);
						}
						z0ZzZzlkh2[num25].z0vtk();
						z0ZzZzlkh.Insert(num25 + num19, z0ZzZzlkh2[num25]);
					}
				}
			}
		}
		z0etk = z0ZzZzlkh.ToArray();
		_ = z0etk[z0etk.Length - 1];
		if (flag14 && !xTextDocument.z0snk())
		{
			z0lrk();
		}
		if ((verticalAlignStyle != VerticalAlignStyle.Top || flag14) && Height > 0f)
		{
			z0eek(verticalAlignStyle, p1: false, p2: false);
		}
		if (z0nrk())
		{
			List<z0ZzZzgkh> list3 = ((z0qpk)base.z0utk).z0oek;
			for (int num26 = list3.Count - 1; num26 >= 0; num26--)
			{
				z0ZzZzgkh z0ZzZzgkh = list3[num26];
				if (!z0ZzZzlkh.Contains(z0ZzZzgkh.z0ptk()))
				{
					list3.RemoveAt(num26);
				}
			}
			if (list3.Count == 0)
			{
				((z0qpk)base.z0utk).z0oek = null;
			}
		}
		PageContentPartyStyle p8 = z0fu();
		if (!p0.z0uek())
		{
			z0ZzZzdbj z0ZzZzdbj = xTextDocument.z0cu();
			if (z0ZzZzdbj != null && !flag3 && z0ZzZzlkh3 != null)
			{
				using (zzz.z0ZzZzkuk<z0ZzZzzlh>.z0bpk z0bpk = z0ZzZzlkh3.z0ltk())
				{
					while (z0bpk.MoveNext())
					{
						z0ZzZzzlh current3 = z0bpk.Current;
						z0ZzZzdbj.z0eek(current3, p8);
					}
				}
				foreach (z0ZzZzzlh item6 in z0ZzZzlkh2.z0xrk())
				{
					z0ZzZzdbj.z0eek(item6, p8);
				}
			}
		}
		if (z0ZzZzlkh3 != null)
		{
			zzz.z0ZzZzgik<z0ZzZzzlh[]>.z0iek.z0tek(z0ZzZzlkh3.z0krk());
			z0ZzZzlkh3.Clear();
		}
		zzz.z0ZzZzgik<z0ZzZzzlh[]>.z0iek.z0tek(z0ZzZzlkh2.z0krk());
		z0ZzZzlkh2.z0vrk();
		zzz.z0ZzZzgik<z0ZzZzlkh>.z0iek.z0tek(z0ZzZzlkh2);
		if (list2 != null && list2.Count > 0)
		{
			List<z0ZzZzzlh> list4 = new List<z0ZzZzzlh>();
			foreach (XTextElement item7 in list2)
			{
				z0ZzZzzlh z0ZzZzzlh15 = item7.z0ptk();
				if (z0ZzZzzlh15 != null && z0ZzZzlkh.Contains(z0ZzZzzlh15) && !list4.Contains(z0ZzZzzlh15))
				{
					list4.Add(item7.z0ptk());
				}
			}
			if (list4.Count > 0)
			{
				foreach (z0ZzZzzlh item8 in list4)
				{
					item8.z0eek(0f);
					z0eek(item8, p0.z0bek);
				}
			}
		}
		if (list2 != null)
		{
			list2.Clear();
			zzz.z0ZzZzgik<List<XTextElement>>.z0iek.z0tek(list2);
		}
		if (base.z0utk != null)
		{
			((z0qpk)base.z0utk).z0pek = null;
		}
		if (this is XTextDocumentBodyElement && z0ZzZzlkh.Count > 0 && z0ZzZzlkh.LastElement.z0jrk_jiejie20260327142557())
		{
			z0ZzZzzlh lastElement3 = z0ZzZzlkh.LastElement;
			lastElement3.z0tek(lastElement3.z0ntk().z0yt() + lastElement3.z0ntk().Height);
		}
		flag15 = false;
		if (!p0.z0xek && this is XTextDocumentContentElement)
		{
			flag15 = true;
		}
		else if (array2 == null)
		{
			flag15 = true;
		}
		else if (array2.Length != z0ZzZzlkh.Count * 2)
		{
			flag15 = true;
		}
		else
		{
			for (int num27 = 0; num27 < z0ZzZzlkh.Count; num27++)
			{
				z0ZzZzzlh z0ZzZzzlh16 = z0ZzZzlkh[num27];
				if (z0ZzZzzlh16.z0trk() != array2[num27 * 2])
				{
					flag15 = true;
					break;
				}
				if (z0ZzZzzlh16.z0ytk() != array2[num27 * 2 + 1])
				{
					flag15 = true;
					break;
				}
				z0ZzZzzlh16.z0eek(array[num27 * 2]);
				z0ZzZzzlh16.z0rek(array[num27 * 2 + 1]);
			}
		}
		if (xTextElement3 == null)
		{
			int count4 = z0ZzZzlkh.Count;
			z0ZzZzzlh[] array6 = z0ZzZzlkh.z0krk();
			for (int num28 = 0; num28 < count4; num28++)
			{
				array6[num28].z0tek(p0: false);
			}
		}
		else
		{
			z0ZzZzlkh[0].z0tek(p0: false);
		}
		if (!p0.z0uek())
		{
			z0uyk()?.z0mrk()?.z0rek();
		}
		if (!flag15 && !p0.z0uek())
		{
			z0cu()?.z0lh()?.z0jlk();
		}
		p0.z0eek(z0ZzZzlkh);
		if (z0etk != null)
		{
			xTextDocumentContentElement.z0tek(z0etk.Length);
		}
		if (flag15)
		{
			if (!p0.z0uek() && xTextDocument.z0cu() != null && !flag3)
			{
				xTextDocument.z0cu().z0eek(z0qyk(), p8);
			}
			if (flag2)
			{
				z0rrk();
			}
			p0.z0rek(p0: true);
			return flag2;
		}
		if (flag2)
		{
			if (z0qrk())
			{
				z0eek(-1f);
			}
			z0rrk();
		}
		p0.z0rek(p0: true);
		return false;
	}

	internal override z0apk_jiejie20260327142557 z0fo()
	{
		return new z0qpk();
	}

	internal void z0eek(z0ZzZzvxj p0, Color p1, bool p2, bool p3, bool p4, float p5, float p6, float p7, DashStyle p8, bool p9)
	{
		if (z0nek() || !p0.z0rek())
		{
			return;
		}
		z0ZzZzzlh[] array = z0etk;
		if (array == null || array.Length == 0)
		{
			return;
		}
		float num = z0mrk();
		z0ZzZzbdh z0ZzZzbdh = p0.z0drk();
		if (!p0.z0hrk().z0bek())
		{
			if (this is XTextDocumentBodyElement)
			{
				float num2 = Math.Max(z0ZzZzbdh.z0nek(), p0.z0hrk().z0nek());
				z0ZzZzbdh.z0rek(Math.Max(z0ZzZzbdh.z0yek(), p0.z0hrk().z0pek()));
				z0ZzZzbdh.z0yek(num2 - z0ZzZzbdh.z0pek());
				z0ZzZzbdh.z0yek(z0ZzZzbdh.z0iek() + 3f);
			}
			else if (p0.z0lrk() != null)
			{
				float num3 = Math.Min(z0ZzZzbdh.z0nek(), p0.z0lrk().z0qrk());
				if (p0.z0byk == (z0ZzZzcxj)3)
				{
					num3 = Math.Min(num3, p0.z0lrk().z0qrk());
				}
				z0ZzZzbdh.z0rek(Math.Max(z0ZzZzbdh.z0yek(), p0.z0lrk().z0irk()));
				z0ZzZzbdh.z0yek(num3 - z0ZzZzbdh.z0pek());
				z0ZzZzbdh.z0yek(z0ZzZzbdh.z0iek() + 3f);
			}
		}
		z0ZzZzrzj z0ZzZzrzj = z0aek();
		z0ZzZzbdh.z0eek(z0ZzZzbdh.z0tek() - z0ZzZzrzj.z0ryk);
		z0ZzZzbdh.z0tek(z0ZzZzbdh.z0uek() + z0ZzZzrzj.z0ryk + z0ZzZzrzj.z0ptk);
		List<float> list = new List<float>();
		List<int> list2 = new List<int>();
		if (p6 > 0f)
		{
			float num4 = z0ZzZzbdh.z0pek() + p6;
			float num5 = z0ZzZzbdh.z0nek();
			if (!p2 && array.Length != 0)
			{
				z0ZzZzzlh z0ZzZzzlh = array[0];
				num4 = ((XTextElement)this).z0ltk() + z0ZzZzzlh.z0zrk() + z0ZzZzzlh.z0ytk();
			}
			if (!p3 && array.Length != 0)
			{
				z0ZzZzzlh z0ZzZzzlh2 = array[array.Length - 1];
				num5 = ((XTextElement)this).z0ltk() + z0ZzZzzlh2.z0zrk() + z0ZzZzzlh2.z0ytk();
			}
			if (!p0.z0hrk().z0bek())
			{
				num4 = Math.Max(num4, p0.z0hrk().z0pek());
				num5 = Math.Min(num5, p0.z0hrk().z0nek());
			}
			num5 = Math.Min(num5, z0ZzZzbdh.z0nek());
			if ((double)(z0ZzZzbdh.z0nek() - num5) < 0.2 * (double)p6)
			{
				num5 -= p6 * 0.5f;
			}
			for (float num6 = num4; num6 <= num5; num6 += p6)
			{
				list.Add(num6);
			}
		}
		else
		{
			float num7 = -1f;
			float num8 = -1f;
			if (p2 && array.Length != 0)
			{
				z0ZzZzzlh z0ZzZzzlh3 = array[0];
				float num9 = p5;
				if (num9 <= 0f)
				{
					num9 = z0ZzZzzlh3.z0ytk();
				}
				if (num > 0f)
				{
					num9 = num;
				}
				for (float num10 = z0ZzZzzlh3.z0xrk(); num10 >= p0.z0drk().z0pek() + num9 * 0.5f; num10 -= num9)
				{
					list.Add(num10);
				}
			}
			z0ZzZzzlh[] array2 = array;
			foreach (z0ZzZzzlh z0ZzZzzlh4 in array2)
			{
				if (z0ZzZzzlh4.Count == 1 && (((XTextElementList)z0ZzZzzlh4).z0krk() is XTextPageBreakElement || ((XTextElementList)z0ZzZzzlh4).z0krk() is XTextHorizontalLineElement))
				{
					num7 = -1f;
					num8 = -1f;
					continue;
				}
				float num11 = Math.Min(p0.z0gtk.z0nek() - 30f, p0.z0nek().z0nek());
				if (p4)
				{
					num11 = p0.z0drk().z0nek() + 5f;
				}
				if (p0.z0lrk() != null)
				{
					num11 = p0.z0lrk().z0irk() + p0.z0lrk().z0xek() + 1f;
				}
				float num12 = z0ZzZzzlh4.z0xrk() + z0ZzZzzlh4.z0ytk();
				if (num > 0f)
				{
					num12 = z0ZzZzzlh4.z0xrk() + z0ZzZzzlh4.z0ytk();
				}
				if (num12 > num11)
				{
					break;
				}
				num7 = num12;
				if (num12 >= p0.z0nek().z0pek() && num12 <= num11)
				{
					if (list.Count > 0)
					{
						num8 = num12 - list[list.Count - 1];
					}
					if (z0ZzZzzlh4.z0jrk_jiejie20260327142557() || z0ZzZzzlh4.z0qtk())
					{
						list2.Add(list.Count);
					}
					list.Add(num12);
				}
			}
			if (p3)
			{
				z0stk = 0f;
				z0ZzZzzlh z0ZzZzzlh5 = array[array.Length - 1];
				XTextDocument xTextDocument = z0jr();
				z0ZzZzerj z0ZzZzerj = xTextDocument.z0suk();
				for (int num13 = array.Length - 1; num13 >= 0; num13--)
				{
					z0ZzZzzlh z0ZzZzzlh6 = array[num13];
					if (z0ZzZzerj.IndexOf(z0ZzZzzlh6.z0dtk()) <= z0ZzZzerj.IndexOf(p0.z0lrk()))
					{
						z0ZzZzzlh5 = z0ZzZzzlh6;
						break;
					}
				}
				float num14 = num7;
				float num15 = xTextDocument.z0ppk();
				if (num15 == 0f)
				{
					num15 = ((DocumentContentStyle)xTextDocument.z0gnk().Default).z0mek();
				}
				if (num8 > 0f)
				{
					num15 = num8;
				}
				else if (z0ZzZzzlh5 != null && !z0ZzZzzlh5.z0jrk_jiejie20260327142557() && !z0ZzZzzlh5.z0qtk())
				{
					num14 = z0ZzZzzlh5.z0xrk() + z0ZzZzzlh5.z0ytk();
					if (num8 <= 0f)
					{
						num15 = z0ZzZzzlh5.z0ytk();
					}
				}
				if (p5 > 0f)
				{
					num15 = p5;
				}
				if (num > 0f)
				{
					num15 = num;
				}
				if (num15 < 10f)
				{
					num15 = p0.z0eek(xTextDocument.z0gnk().Default.Font);
				}
				z0stk = num15;
				xTextDocument.z0cek(z0stk);
				float num16 = (float)((double)z0ZzZzbdh.z0nek() - (double)num15 * 0.8);
				if (this is XTextDocumentBodyElement)
				{
					num16 = z0ZzZzbdh.z0nek();
				}
				num14 += num15;
				if (list.Count > 0)
				{
					num14 = list[list.Count - 1];
				}
				for (; num14 < num16; num14 += num15)
				{
					list.Add(num14);
				}
			}
		}
		if (p9 || list.Count <= 0)
		{
			return;
		}
		if (p7 != 0f)
		{
			for (int j = 0; j < list.Count; j++)
			{
				list[j] += p7;
			}
		}
		if (list.Count >= 1 && !(this is XTextDocumentBodyElement))
		{
			float num17 = z0aek().z0qyk;
			if (list.Count > 1)
			{
				num17 = list[list.Count - 1] - list[list.Count - 2];
			}
			if (num17 < 20f)
			{
				num17 = 20f;
			}
			if ((double)(z0ZzZzbdh.z0nek() - list[list.Count - 1]) < (double)num17 * 0.8)
			{
				z0ZzZzrzj z0ZzZzrzj2 = z0aek();
				if (z0ZzZzrzj2.z0wrk && z0ZzZzrzj2.z0mrk)
				{
					list.RemoveAt(list.Count - 1);
				}
			}
		}
		if (list.Count == 0)
		{
			return;
		}
		z0ZzZzudh z0ZzZzudh = new z0ZzZzudh(p1, 1f);
		if (p0.z0zrk)
		{
			z0ZzZzudh.z0eek(Color.Black);
		}
		_ = this is XTextDocumentBodyElement;
		z0ZzZzudh.z0eek(p8);
		float num18 = p0.z0lrk().z0irk();
		float num19 = p0.z0lrk().z0qrk();
		for (int k = 0; k < list.Count; k++)
		{
			float num20 = list[k];
			if (!(num20 < num18 + 1f) && !(num20 > num19 - 1f) && !list2.Contains(k) && (p0.z0byk != (z0ZzZzcxj)3 || (!(Math.Abs(num20 - p0.z0nek().z0pek()) < 10f) && !(Math.Abs(num20 - p0.z0nek().z0nek()) < 10f))))
			{
				p0.z0gyk.z0eek(z0ZzZzudh, z0ZzZzbdh.z0oek(), num20, z0ZzZzbdh.z0mek(), num20);
			}
		}
		z0ZzZzudh.Dispose();
	}

	public virtual bool z0wu(int p0, int p1, bool p2, bool p3)
	{
		if (z0xu())
		{
			return false;
		}
		if (z0bek())
		{
			return false;
		}
		bool flag = p0 != -10000;
		z0mek(p0: false);
		XTextElementList xTextElementList = z0trk();
		p0 = xTextElementList.z0nek(p0);
		XTextDocument xTextDocument = z0jr();
		bool flag2 = true;
		XTextElement xTextElement = xTextElementList[p0];
		if (xTextElement.z0ptk() != null && xTextElement.z0ptk().IndexOf(xTextElement) == 0)
		{
			int num = z0zek().z0yek(xTextElement.z0ptk());
			if (num > 0)
			{
				z0ZzZzzlh z0ZzZzzlh = z0zek()[num - 1];
				if (((XTextElementList)z0ZzZzzlh).z0cek())
				{
					XTextElement lastElement = z0ZzZzzlh.LastElement;
					if (xTextElementList.Contains(lastElement))
					{
						flag2 = false;
					}
				}
			}
		}
		if (flag2 && p0 > 0)
		{
			p0--;
		}
		p0 = xTextElementList.z0nek(p0);
		if (z0frk())
		{
			List<XTextElement> list = null;
			int count = xTextElementList.Count;
			XTextElement[] array = ((zzz.z0ZzZzkuk<XTextElement>)xTextElementList).z0krk();
			for (int i = 0; i < count; i++)
			{
				if (z0rek(array[i]))
				{
					if (list == null)
					{
						list = new List<XTextElement>();
					}
					list.Add(array[i]);
				}
			}
			if (list != null)
			{
				z0vrk().z0mek = list.ToArray();
			}
			else if (base.z0utk != null)
			{
				((z0qpk)base.z0utk).z0pek = null;
			}
		}
		XTextElement p4 = xTextElementList.SafeGet(p1);
		float height = Height;
		z0ZzZzazj z0ZzZzazj = new z0ZzZzazj(xTextElementList[p0], p4, z0cr());
		z0ZzZzazj.z0xek = flag;
		if (z0zt(z0ZzZzazj))
		{
			((XTextContentElement)z0qek()).z0rek(0);
			bool flag3 = !xTextDocument.z0frk();
			if (this is XTextTableCellElement)
			{
				if (z0rek())
				{
					flag3 = true;
				}
				XTextTableCellElement xTextTableCellElement = (XTextTableCellElement)this;
				if (xTextTableCellElement.RowSpan != 1 || !(xTextTableCellElement.z0krk().z0cek() < 0f))
				{
					for (XTextElement xTextElement2 = this; xTextElement2 != null; xTextElement2 = xTextElement2.z0ji())
					{
						if (xTextElement2 is XTextTableCellElement)
						{
							XTextTableCellElement xTextTableCellElement2 = (XTextTableCellElement)xTextElement2;
							XTextTableElement xTextTableElement = xTextTableCellElement2.z0gr();
							if (xTextTableElement.z0ptk() == null)
							{
								return false;
							}
							if (xTextTableCellElement2 != this)
							{
								height = xTextTableCellElement2.Height;
							}
							if (xTextTableCellElement2 != this)
							{
								xTextTableCellElement2.Height = 0f;
								xTextTableCellElement2.Width = 0f;
							}
							xTextTableElement.z0vek(p0: true);
							if (xTextTableCellElement2.Height != height || xTextTableElement.z0wtk)
							{
								xTextTableElement.z0ptk().z0jtk();
								xTextTableElement.z0ptk().z0tek(p0: true);
								xTextTableElement.z0jy().z0brk();
								flag3 = true;
							}
							xTextTableElement.z0wtk = false;
						}
						else if (xTextElement2 is XTextSectionElement)
						{
							XTextSectionElement xTextSectionElement = (XTextSectionElement)xTextElement2;
							if (xTextSectionElement.z0ptk() == null)
							{
								return false;
							}
							if (xTextSectionElement != this)
							{
								height = xTextSectionElement.Height;
							}
							if (xTextSectionElement != this)
							{
								xTextSectionElement.z0ct();
								if (height != xTextSectionElement.Height)
								{
									xTextSectionElement.z0ptk().z0jtk();
									xTextSectionElement.z0ptk().z0tek(p0: true);
									flag3 = true;
								}
							}
						}
					}
					if (flag3)
					{
						flag3 = true;
						z0qek().z0eek(z0qek().z0cr(), p1: true, p2: true);
					}
				}
			}
			else if (this is XTextSectionElement)
			{
				if (z0ptk() == null)
				{
					return false;
				}
				if (!(((XTextSectionElement)this).SpecifyHeight < 0f))
				{
					XTextDocumentBodyElement xTextDocumentBodyElement = (XTextDocumentBodyElement)z0ji();
					z0ptk().z0jtk();
					z0ptk().z0tek(p0: true);
					if (xTextDocumentBodyElement != this)
					{
						height = xTextDocumentBodyElement.Height;
					}
					xTextDocumentBodyElement.z0eek(VerticalAlignStyle.Top, p1: true, p2: false);
					xTextDocumentBodyElement.z0ly();
					if (xTextDocumentBodyElement.Height != height)
					{
						flag3 = true;
					}
					if (flag3)
					{
						flag3 = true;
						z0qek().z0eek(z0qek().z0cr(), p1: true, p2: true);
					}
				}
			}
			else
			{
				flag3 = true;
				if (!xTextDocument.z0frk())
				{
					flag3 = true;
				}
			}
			z0mek(flag3);
			if (flag3)
			{
				xTextDocument.z0krk(p0: false);
				if (!p2)
				{
					xTextDocument?.z0krk();
					if (xTextDocument.z0yyk() != null && !xTextDocument.z0yyk().z0jyk())
					{
						xTextDocument.z0yyk().z0fpk();
						if (p3)
						{
							xTextDocument.z0yyk().z0vik();
						}
						((XTextElement)xTextDocument).z0uyk().z0hz();
					}
				}
			}
		}
		else if (!p2 && xTextDocument != null)
		{
			if (!xTextDocument.z0frk())
			{
				xTextDocument.z0krk();
			}
			if (xTextDocument != null && xTextDocument.z0yyk() != null && !xTextDocument.z0yyk().z0jyk() && p3)
			{
				xTextDocument.z0yyk().z0vik();
			}
		}
		z0ZzZzazj.z0tek();
		zzz.z0ZzZzguk<z0ZzZzzlh>.z0iek(5);
		return true;
	}

	private bool z0rek(XTextElement p0)
	{
		if (p0 is XTextObjectElement)
		{
			XTextObjectElement xTextObjectElement = (XTextObjectElement)p0;
			z0ZzZzrzj z0ZzZzrzj = xTextObjectElement.z0aek();
			if (z0ZzZzrzj == null)
			{
				xTextObjectElement.z0yek(z0rik);
				z0ZzZzrzj = xTextObjectElement.z0aek();
			}
			if (z0ZzZzrzj.z0xyk == ContentLayoutAlign.Surroundings && xTextObjectElement.z0ci() == ElementZOrderStyle.Normal)
			{
				return true;
			}
		}
		return false;
	}

	public override void z0li()
	{
		base.z0li();
		z0gu();
	}

	internal virtual void z0au(z0lgj p0)
	{
		if (!p0.z0tek())
		{
			z0uyk()?.z0mrk()?.z0uek();
		}
		if (p0.z0yek())
		{
			z0ze(z0kgj.z0eek(z0jr(), !p0.z0rek()));
		}
		XTextDocument xTextDocument = z0jr();
		if (xTextDocument != null && !xTextDocument.z0snk())
		{
			((XTextElement)xTextDocument).z0rrk();
			xTextDocument.z0wik();
		}
		if (base.z0utk != null)
		{
			((z0qpk)base.z0utk).z0mek = null;
		}
		z0atk = null;
		z0irk();
		if (!p0.z0eek())
		{
			z0gu();
		}
		if (p0.z0uek())
		{
			for (XTextElement xTextElement = z0ji(); xTextElement != null; xTextElement = xTextElement.z0ji())
			{
				if (xTextElement is XTextContentElement)
				{
					XTextContentElement obj = (XTextContentElement)xTextElement;
					if (p0.z0rek())
					{
						p0.z0eek(p0: false);
					}
					obj.z0au(p0);
				}
			}
		}
		if (p0.z0bek)
		{
			z0eek(this);
		}
	}

	protected internal new float z0cek()
	{
		float num = 0f;
		z0ZzZzzlh[] array = z0zek();
		if (array.Length != 0)
		{
			num = array[array.Length - 1].z0ark() - array[0].z0zrk();
		}
		if (z0ork())
		{
			XTextElement[] array2 = z0tek();
			for (int i = 0; i < array2.Length; i++)
			{
				z0ZzZzbdh z0ZzZzbdh = array2[i].z0nrk();
				if (num < z0ZzZzbdh.z0nek() + 1f)
				{
					num = z0ZzZzbdh.z0nek() + 1f;
				}
			}
		}
		if (z0jr()?.z0qxk == null && !z0urk())
		{
			z0ZzZzrzj z0ZzZzrzj = z0aek();
			num = num + z0ZzZzrzj.z0quk + z0ZzZzrzj.z0xrk;
		}
		return num;
	}

	public void z0eek(z0ZzZzszj p0)
	{
		if (z0etk == null || z0etk.Length == 0)
		{
			return;
		}
		z0ZzZzzlh z0ZzZzzlh = z0etk.z0uek();
		if (!(this is XTextDocumentBodyElement) && z0ZzZzzlh.z0xrk() + z0ZzZzzlh.z0ytk() <= p0.z0oek())
		{
			if (!XTextDocument.z0pbk)
			{
				p0.z0frk = this;
				p0.z0cek = true;
				return;
			}
			bool flag = true;
			if (p0.z0mek() != null && p0.z0mek().Count > 0)
			{
				foreach (XTextPageBreakElement item in p0.z0mek())
				{
					if (!item.z0eek && item.z0zu(this))
					{
						flag = false;
						break;
					}
				}
			}
			if (flag)
			{
				p0.z0frk = this;
				p0.z0cek = true;
				if (this is XTextSectionElement && z0xw() is XTextSectionElement { NewPage: not false } xTextSectionElement)
				{
					xTextSectionElement.z0rek(p0: true);
				}
				return;
			}
		}
		DocumentBehaviorOptions documentBehaviorOptions = z0bu();
		z0ZzZzzlh z0ZzZzzlh2 = null;
		float num = ((XTextElement)this).z0ltk();
		z0ZzZzzlh[] array = z0etk;
		if (array == null || array.Length == 0)
		{
			return;
		}
		int num2 = 0;
		if (!p0.z0yrk)
		{
			for (int num3 = array.Length - 1; num3 >= 0; num3--)
			{
				if (array[num3].z0zrk() + num < p0.z0ork)
				{
					num2 = num3;
					break;
				}
			}
		}
		int num4 = array.Length;
		z0ZzZzzlh[] array2 = array;
		for (int i = num2; i < num4; i++)
		{
			z0ZzZzzlh z0ZzZzzlh3 = array2[i];
			if (p0.z0grk >= num + z0ZzZzzlh3.z0ark() && (p0.z0yrk || !z0ZzZzzlh3.z0xek()))
			{
				continue;
			}
			if (XTextDocument.z0pbk && !p0.z0yrk)
			{
				if (((XTextElementList)z0ZzZzzlh3).z0krk() is XTextSectionElement)
				{
					XTextSectionElement xTextSectionElement2 = (XTextSectionElement)((XTextElementList)z0ZzZzzlh3).z0krk();
					if (xTextSectionElement2.NewPage && !xTextSectionElement2.z0rek() && !xTextSectionElement2.z0tek())
					{
						xTextSectionElement2.z0rek(p0: true);
						if ((i != 0 || !(this is XTextDocumentBodyElement)) && !(Math.Abs(xTextSectionElement2.z0cw() - p0.z0ork) < 30f))
						{
							p0.z0rek(num + z0ZzZzzlh3.z0zrk());
							p0.z0rek(xTextSectionElement2);
							p0.z0vek = true;
							if (xTextSectionElement2.InsertEmptyPageForNewPage)
							{
								p0.z0hrk = true;
							}
							return;
						}
					}
				}
				if (z0ZzZzzlh3.z0brk() && z0ZzZzzlh3.z0mek().z0ae())
				{
					z0ZzZzzlh3.z0mek().z0eek(p0);
					break;
				}
				if (z0ZzZzzlh3.z0jrk_jiejie20260327142557() && z0ZzZzzlh3.z0ntk().z0ae())
				{
					z0ZzZzzlh3.z0ntk().z0nek(p0);
					break;
				}
			}
			if (Math.Abs(p0.z0oek() - num - z0ZzZzzlh3.z0zrk()) < 2f)
			{
				z0ZzZzzlh2 = z0ZzZzzlh3;
				break;
			}
			if (!(p0.z0oek() > num + z0ZzZzzlh3.z0zrk()))
			{
				break;
			}
			z0ZzZzzlh2 = z0ZzZzzlh3;
			if (z0ZzZzzlh2[0] is XTextPageBreakElement)
			{
				XTextPageBreakElement xTextPageBreakElement = (XTextPageBreakElement)z0ZzZzzlh2[0];
				if (!xTextPageBreakElement.z0eek)
				{
					xTextPageBreakElement.z0eek = true;
					if (documentBehaviorOptions.PageLineUnderPageBreak)
					{
						int num5 = (int)(z0ZzZzzlh2.z0xrk() + z0ZzZzzlh2.z0ytk());
						p0.z0rek(xTextPageBreakElement);
						if (array[array.Length - 1] == z0ZzZzzlh3)
						{
							float num6 = z0qyk().z0nek();
							if (num6 - p0.z0oek() < 50f)
							{
								num5 = (int)num6;
								p0.z0rek(this);
							}
						}
						p0.z0rek(num5);
					}
					else
					{
						p0.z0rek((int)z0ZzZzzlh2.z0xrk());
					}
					p0.z0rek(xTextPageBreakElement);
					p0.z0vek = true;
					return;
				}
			}
			if (array[array.Length - 1] == z0ZzZzzlh3 && p0.z0oek() > z0ZzZzzlh3.z0lrk())
			{
				z0ZzZzzlh2 = null;
				p0.z0frk = this;
				p0.z0cek = true;
				break;
			}
			if (p0.z0oek() < num + z0ZzZzzlh2.z0zrk() + z0ZzZzzlh2.z0ytk())
			{
				break;
			}
		}
		if (z0ZzZzzlh2 == null)
		{
			if (!p0.z0cek)
			{
				p0.z0ark = true;
			}
			return;
		}
		if (p0.z0oek() > z0ZzZzzlh2.z0lrk())
		{
			if (z0ZzZzzlh2 == array[array.Length - 1])
			{
				z0ZzZzbdh z0ZzZzbdh = z0qyk();
				if (p0.z0oek() >= z0ZzZzbdh.z0nek())
				{
					p0.z0rek(z0ZzZzbdh.z0nek());
					p0.z0rek(this);
				}
				else if (z0ZzZzbdh.z0nek() - p0.z0oek() < z0jr().z0xek(15f))
				{
					goto IL_0463;
				}
			}
			p0.z0frk = this;
			p0.z0cek = true;
			return;
		}
		goto IL_0463;
		IL_0463:
		if (z0ZzZzzlh2.z0ntk() != null)
		{
			XTextTableElement xTextTableElement = z0ZzZzzlh2.z0ntk();
			xTextTableElement.z0nek(p0);
			if (p0.z0oek() == xTextTableElement.z0cw())
			{
				p0.z0rek(xTextTableElement.z0ptk().z0xrk());
			}
		}
		else if (z0ZzZzzlh2.z0brk())
		{
			XTextSectionElement xTextSectionElement3 = z0ZzZzzlh2.z0mek();
			xTextSectionElement3.z0eek(p0);
			if (p0.z0oek() == xTextSectionElement3.z0cw())
			{
				p0.z0rek(xTextSectionElement3.z0ptk().z0xrk());
			}
		}
		else
		{
			int num7 = array.z0yek(z0ZzZzzlh2);
			float num8 = 0f;
			if (num7 > 0)
			{
				z0ZzZzzlh z0ZzZzzlh4 = array[num7 - 1];
				num8 = (z0ZzZzzlh4.z0xrk() + z0ZzZzzlh4.z0ytk() + z0ZzZzzlh2.z0xrk()) / 2f;
			}
			else
			{
				num8 = z0ZzZzzlh2.z0xrk();
			}
			XTextElement xTextElement = z0ZzZzzlh2[0];
			if (xTextElement is XTextParagraphListItemElement && z0ZzZzzlh2.Count > 1)
			{
				xTextElement = z0ZzZzzlh2[1];
			}
			if (xTextElement != null)
			{
				p0.z0rek(xTextElement);
			}
			if (num8 - p0.z0ork > p0.z0qrk)
			{
				p0.z0rek(num8);
				z0ZzZzbdh z0ZzZzbdh2 = z0qyk();
				if (p0.z0oek() - z0ZzZzbdh2.z0pek() < z0jr().z0xek(15f))
				{
					p0.z0rek(z0ZzZzbdh2.z0pek());
					p0.z0rek(this);
				}
				if (num7 == 0)
				{
					p0.z0ark = true;
				}
			}
		}
		if ((p0.z0yrk && !documentBehaviorOptions.SpecifyDebugMode) || ((z0qpk)base.z0utk)?.z0mek == null)
		{
			return;
		}
		XTextElement[] array3 = ((z0qpk)base.z0utk).z0mek;
		foreach (XTextElement xTextElement2 in array3)
		{
			float num9 = xTextElement2.z0ptk().z0xrk();
			if (p0.z0oek() > num9 && p0.z0oek() < num9 + xTextElement2.z0yt() + xTextElement2.Height)
			{
				p0.z0rek(num9);
				p0.z0rek(xTextElement2);
				break;
			}
		}
	}

	internal new bool z0xek()
	{
		return z0rtk();
	}

	public new z0ZzZzzlh[] z0zek()
	{
		return z0etk;
	}

	internal new void z0lrk()
	{
		if (z0etk == null || z0etk.Length == 0)
		{
			return;
		}
		if (z0ntk.z0mek())
		{
			z0etk[0].z0erk();
			return;
		}
		int num = z0etk.Length;
		z0ZzZzzlh[] array = z0etk;
		for (int i = 0; i < num; i++)
		{
			z0ZzZzzlh z0ZzZzzlh = array[i];
			z0ZzZzzlh.z0erk();
			if (z0ZzZzzlh.z0jrk_jiejie20260327142557())
			{
				z0ZzZzzlh.z0ntk().z0rrk();
			}
			else if (z0ZzZzzlh.z0qtk())
			{
				z0ZzZzzlh.z0mek().z0lrk();
			}
		}
	}

	public new XTextElementList z0krk()
	{
		XTextElementList xTextElementList = new XTextElementList();
		if (z0utk != null && z0utk.Count > 0)
		{
			foreach (XTextElement item in z0utk.z0xrk())
			{
				if (item is XTextParagraphFlagElement)
				{
					xTextElementList.Add(item);
				}
			}
		}
		return xTextElementList;
	}

	internal new bool z0jrk()
	{
		return z0ryk();
	}

	public int z0eek(bool p0, bool p1, bool p2, bool p3, bool p4, bool p5)
	{
		return z0eek(p0, p1, p2, p3, p4, p5, p6: false);
	}

	public override bool z0ai(XTextElement p0)
	{
		if (p0 == z0be().LastElement)
		{
			return false;
		}
		base.z0oek();
		return base.z0ai(p0);
	}

	private void z0eek(z0ZzZzjpk p0, z0ZzZzudh p1, z0ZzZzbdh p2, float p3, float p4)
	{
		if (p3 >= p2.z0pek() && p3 <= p2.z0nek() && z0jr().z0bek(p3, p4))
		{
			p0.z0eek(p1, p2.z0oek(), p3, p2.z0mek(), p3);
		}
	}

	public new float z0hrk()
	{
		XTextDocument xTextDocument = z0rik;
		if (xTextDocument == null)
		{
			return 0f;
		}
		float num = 0f;
		z0ZzZzzlh[] array = z0etk;
		num = ((array == null || array.Length == 0) ? 0f : ((array.Length != 1) ? (array[array.Length - 1].z0ark() - array[0].z0zrk()) : array[0].z0pyk));
		if (z0ork())
		{
			XTextElement[] array2 = ((z0qpk)base.z0utk).z0mek;
			for (int i = 0; i < array2.Length; i++)
			{
				z0ZzZzbdh z0ZzZzbdh = array2[i].z0nrk();
				if (num < z0ZzZzbdh.z0nek() + 1f)
				{
					num = z0ZzZzbdh.z0nek() + 1f;
				}
			}
		}
		if (this is XTextTableCellElement || this is XTextSectionElement)
		{
			z0ZzZzzej z0qxk = xTextDocument.z0qxk;
			if (z0qxk != null && z0qxk.z0cek())
			{
				return num;
			}
		}
		if (xTextDocument.z0qxk == null && !z0urk())
		{
			z0ZzZzrzj z0ZzZzrzj = z0aek();
			num = num + z0ZzZzrzj.z0quk + z0ZzZzrzj.z0xrk;
		}
		return num;
	}

	internal new void z0grk()
	{
		if (z0etk == null)
		{
			return;
		}
		if (z0etk.Length != 0)
		{
			z0ZzZzzlh[] array = z0etk;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].Clear();
			}
			Array.Clear(z0etk);
		}
		z0etk = null;
	}

	public override void z0bw_jiejie20260327142557(z0ygj p0)
	{
		XTextElementList xTextElementList = z0be();
		if (xTextElementList == null || xTextElementList.Count <= 0)
		{
			return;
		}
		XTextElement xTextElement = xTextElementList.LastElement;
		if (!(xTextElement is XTextParagraphFlagElement))
		{
			xTextElement = null;
		}
		int count = xTextElementList.Count;
		XTextElement[] array = ((zzz.z0ZzZzkuk<XTextElement>)xTextElementList).z0krk();
		for (int i = 0; i < count; i++)
		{
			XTextElement xTextElement2 = array[i];
			if (xTextElement2 != xTextElement && (p0.z0oek || xTextElement2.z0yi()) && (xTextElement2.z0aek() == null || xTextElement2.z0aek().z0jyk < 0))
			{
				xTextElement2.z0bw_jiejie20260327142557(p0);
			}
		}
	}

	private new bool z0frk()
	{
		return z0yyk();
	}

	internal new float z0drk()
	{
		if (base.z0utk != null)
		{
			return ((z0qpk)base.z0utk).z0lrk;
		}
		return 1f;
	}

	public virtual void z0tek(bool p0)
	{
		if (p0 && z0atk != null && z0atk.Count > 0 && z0jr().z0yyk() != null)
		{
			z0ZzZzbdh z0ZzZzbdh = z0ZzZzbdh.z0xek;
			foreach (z0ZzZzqzj item in z0atk)
			{
				z0ZzZzbdh = ((!z0ZzZzbdh.z0bek()) ? z0ZzZzbdh.z0yek(item.z0eek(), z0ZzZzbdh) : item.z0eek());
			}
			z0jr().z0yyk().z0eek(z0ZzZzbdh, z0qek().z0du());
		}
		z0atk = null;
	}

	public override float z0si()
	{
		if (z0urk())
		{
			return Height;
		}
		z0ZzZzrzj z0ZzZzrzj = z0aek();
		return Height - z0ZzZzrzj.z0quk - z0ZzZzrzj.z0xrk;
	}

	private new bool z0srk()
	{
		return base.z0wrk();
	}

	public new bool z0ark()
	{
		if (z0etk != null && z0etk.Length != 0)
		{
			z0ZzZzzlh z0ZzZzzlh = z0etk[0];
			if (z0ZzZzzlh.z0jrk_jiejie20260327142557())
			{
				z0ZzZzzlh.z0ntk().z0hr();
				return true;
			}
			XTextDocumentContentElement xTextDocumentContentElement = z0qek();
			int num = xTextDocumentContentElement.z0frk().IndexOf(((XTextElementList)z0ZzZzzlh).z0grk());
			int num2 = xTextDocumentContentElement.z0frk().IndexOf(((XTextElementList)z0ZzZzzlh).z0lrk());
			if (num >= 0 && num2 >= 0)
			{
				xTextDocumentContentElement.z0frk().z0iek(p0: true);
				bool num3 = xTextDocumentContentElement.z0uek(num, num2 - num + 1);
				if (num3)
				{
					z0cu().z0eek(ScrollToViewStyle.Top);
				}
				return num3;
			}
		}
		return false;
	}

	public override void z0di(float p0)
	{
		if (z0urk())
		{
			Height = p0;
			return;
		}
		z0ZzZzrzj z0ZzZzrzj = z0aek();
		Height = p0 + z0ZzZzrzj.z0quk + z0ZzZzrzj.z0xrk;
	}

	public virtual VerticalAlignStyle z0cr()
	{
		return VerticalAlignStyle.Top;
	}

	static XTextContentElement()
	{
		z0dtk = null;
		z0rtk = null;
		z0qtk = Array.Empty<float>();
		z0ytk = true;
		z0wtk = 0;
		z0gtk = new z0ZzZzwzj();
		z0ttk = new z0ZzZzlsh();
		z0ttk.z0rek(StringAlignment.Center);
		z0ttk.z0eek(StringAlignment.Center);
	}

	internal new bool z0qrk()
	{
		return z0lyk();
	}

	internal z0ZzZzzlh z0eek(float p0, float p1, bool p2)
	{
		z0ZzZzzlh[] array = z0zek();
		if (array == null || array.Length == 0)
		{
			return null;
		}
		float p3 = p0 - ((XTextElement)this).z0zrk();
		float num = p1 - ((XTextElement)this).z0ltk();
		z0ZzZzzlh z0ZzZzzlh = null;
		if (p2)
		{
			z0ZzZzzlh[] array2 = array;
			int num2 = 0;
			int num3 = array.Length - 1;
			while (num2 < num3 - 8)
			{
				int num4 = (num2 + num3) / 2;
				z0ZzZzzlh z0ZzZzzlh2 = array2[num4];
				if (num < z0ZzZzzlh2.z0zrk())
				{
					num3 = num4;
					continue;
				}
				if (num > z0ZzZzzlh2.z0zrk() + z0ZzZzzlh2.z0drk())
				{
					num2 = num4;
					continue;
				}
				if (z0ZzZzzlh2.z0rek(p3, num))
				{
					z0ZzZzzlh = z0ZzZzzlh2;
				}
				break;
			}
			if (z0ZzZzzlh == null)
			{
				for (int i = num2; i <= num3; i++)
				{
					if (array2[i].z0rek(p3, num))
					{
						z0ZzZzzlh = array2[i];
						break;
					}
				}
			}
		}
		else
		{
			int num5 = array.Length;
			for (int j = 0; j < num5; j++)
			{
				z0ZzZzzlh z0ZzZzzlh3 = array[j];
				if (z0ZzZzzlh3.z0zrk() + z0ZzZzzlh3.z0drk() > num)
				{
					if (j > 0)
					{
						z0ZzZzzlh z0ZzZzzlh4 = array[j - 1];
						float num6 = (z0ZzZzzlh4.z0zrk() + z0ZzZzzlh4.z0drk() + z0ZzZzzlh3.z0zrk()) / 2f;
						z0ZzZzzlh = ((!(num > num6)) ? z0ZzZzzlh4 : z0ZzZzzlh3);
					}
					else
					{
						z0ZzZzzlh = z0ZzZzzlh3;
					}
					break;
				}
			}
		}
		if (z0ZzZzzlh == null && z0ork())
		{
			XTextElement[] array3 = z0tek();
			foreach (XTextElement xTextElement in array3)
			{
				z0ZzZzzlh z0ZzZzzlh5 = xTextElement.z0ptk();
				if (new z0ZzZzbdh(z0ZzZzzlh5.z0stk() + xTextElement.z0it(), z0ZzZzzlh5.z0zrk() + xTextElement.z0yt(), xTextElement.Width, xTextElement.Height).z0eek(p3, num))
				{
					z0ZzZzzlh = z0ZzZzzlh5;
					break;
				}
			}
		}
		if (!p2 && z0ZzZzzlh == null)
		{
			z0ZzZzzlh = array.z0uek();
		}
		return z0ZzZzzlh;
	}

	public virtual z0ZzZzzej z0ju()
	{
		z0ZzZzzej z0ZzZzzej = z0rik?.z0qxk;
		if (z0ZzZzzej != null)
		{
			return z0ZzZzzej;
		}
		return GridLine;
	}

	internal new bool z0wrk()
	{
		if (z0etk != null)
		{
			return z0etk.Length != 0;
		}
		return false;
	}

	public new void z0erk()
	{
	}

	internal new void z0rrk()
	{
		z0ZzZzzlh[] array = z0etk;
		if (array == null || array.Length == 0)
		{
			return;
		}
		z0ZzZzerj z0ZzZzerj = z0rik.z0suk();
		if (z0ZzZzerj == null || z0ZzZzerj.Count == 0)
		{
			return;
		}
		float num = ((XTextElement)this).z0ltk();
		int count = z0ZzZzerj.Count;
		int num2 = z0ZzZzerj.z0eek(num, 0);
		int num3 = array.Length;
		for (int i = 0; i < num3; i++)
		{
			z0ZzZzzlh z0ZzZzzlh = array[i];
			z0ZzZzzlh.z0eek((z0ZzZzwrj)null);
			float num4 = num + z0ZzZzzlh.z0zrk();
			float num5 = num4 + z0ZzZzzlh.z0ytk();
			z0ZzZzwrj z0ZzZzwrj = z0ZzZzerj[num2];
			if (num4 > z0ZzZzwrj.z0irk() - 1f && num5 < z0ZzZzwrj.z0qrk() + 1f)
			{
				z0ZzZzzlh.z0eek(z0ZzZzwrj);
				continue;
			}
			if (num4 > z0ZzZzwrj.z0qrk() - 1f)
			{
				num2 = Math.Min(num2 + 1, z0ZzZzerj.Count - 1);
			}
			for (int j = num2; j < count; j++)
			{
				z0ZzZzwrj z0ZzZzwrj2 = z0ZzZzerj[j];
				float num6 = z0ZzZzwrj2.z0qrk();
				if (!(num4 < num6 - 2f))
				{
					continue;
				}
				z0ZzZzzlh.z0eek(z0ZzZzwrj2);
				num2 = j;
				if (num5 < num6 + 2f)
				{
					break;
				}
				for (int k = j + 1; k < count; k++)
				{
					if (z0ZzZzerj[k].z0irk() > num5)
					{
						num2 = k - 1;
						break;
					}
				}
				break;
			}
		}
	}

	internal bool z0tek(XTextElement p0)
	{
		XTextElement[] array = ((z0qpk)base.z0utk)?.z0mek;
		if (array != null)
		{
			return Array.IndexOf(array, p0) >= 0;
		}
		return false;
	}

	public new XTextElementList z0trk()
	{
		if (z0utk == null || z0utk.z0vek())
		{
			if (XTextContainerElement.z0btk)
			{
				z0we();
			}
			z0eek(p0: false);
			base.z0oek();
			if (base.z0utk != null)
			{
				((z0qpk)base.z0utk).z0oek = null;
			}
			XTextDocument xTextDocument = z0jr();
			xTextDocument?.z0zpk();
			XTextElementList xTextElementList = z0be();
			bool flag = false;
			if (base.z0ark())
			{
				flag = true;
				XTextElement[] array = ((zzz.z0ZzZzkuk<XTextElement>)xTextElementList).z0krk();
				for (int num = xTextElementList.Count - 1; num >= 0; num--)
				{
					if (!array[num].z0cuk)
					{
						flag = false;
						break;
					}
				}
				if (flag)
				{
					if (z0utk == null)
					{
						z0utk = new XTextElementList();
					}
					xTextElementList.z0hrk(z0utk);
				}
			}
			if (z0utk == null)
			{
				if (z0dtk != null)
				{
					z0utk = new XTextElementList();
				}
				else
				{
					z0utk = new XTextElementList(xTextElementList.Count);
				}
			}
			else
			{
				z0utk.z0pek(p0: false);
			}
			if (z0bek())
			{
				return z0utk;
			}
			XTextElementList xTextElementList2 = z0utk;
			if (flag)
			{
				if (base.z0utk != null)
				{
					((z0qpk)base.z0utk).z0krk = null;
				}
				z0pek(p0: false);
				int num2 = 0;
				int count = xTextElementList2.Count;
				XTextElement[] array2 = ((zzz.z0ZzZzkuk<XTextElement>)xTextElementList2).z0krk();
				for (int i = 0; i < count; i++)
				{
					XTextElement obj = array2[i];
					obj.z0xuk = i;
					if (obj is XTextParagraphFlagElement xTextParagraphFlagElement)
					{
						xTextParagraphFlagElement.z0eek(array2[num2]);
						num2 = i + 1;
					}
				}
				if (base.z0utk != null)
				{
					((z0qpk)base.z0utk).z0mek = null;
				}
			}
			else
			{
				z0eok_jiejie20260327142557 z0eok_jiejie20260327142557 = new z0eok_jiejie20260327142557(xTextDocument, (z0dtk == null) ? xTextElementList2 : z0dtk, p2: true);
				z0eok_jiejie20260327142557.z0cek = false;
				if (xTextElementList.Count > 1)
				{
					if (z0rtk == null)
					{
						z0eok_jiejie20260327142557.z0uek = new List<XTextInputFieldElementBase>();
					}
					else
					{
						z0eok_jiejie20260327142557.z0uek = z0rtk;
						z0rtk = null;
					}
				}
				if (base.z0utk != null)
				{
					((z0qpk)base.z0utk).z0krk = null;
				}
				z0ue(z0eok_jiejie20260327142557);
				if (z0dtk != null)
				{
					xTextElementList2.Clear();
					((zzz.z0ZzZzkuk<XTextElement>)xTextElementList2).z0tek((zzz.z0ZzZzkuk<XTextElement>)z0dtk);
					z0dtk.z0nrk();
				}
				if (z0eok_jiejie20260327142557.z0uek != null)
				{
					if (z0eok_jiejie20260327142557.z0uek.Count > 0)
					{
						((z0qpk)base.z0prk()).z0krk = z0eok_jiejie20260327142557.z0uek;
					}
					else
					{
						z0rtk = z0eok_jiejie20260327142557.z0uek;
						z0eok_jiejie20260327142557.z0uek = null;
					}
				}
				z0pek(z0eok_jiejie20260327142557.z0cek);
				if (xTextElementList.Count > 0 && !(xTextElementList2.LastElement is XTextParagraphFlagElement))
				{
					XTextElement lastElement = xTextElementList.LastElement;
					if (((zzz.z0ZzZzkuk<XTextElement>)xTextElementList2).z0xek(lastElement) < 0)
					{
						lastElement.z0cuk = true;
						((zzz.z0ZzZzkuk<XTextElement>)xTextElementList2).z0pek(lastElement);
					}
				}
				int num3 = 0;
				int count2 = xTextElementList2.Count;
				XTextElement[] array3 = ((zzz.z0ZzZzkuk<XTextElement>)xTextElementList2).z0krk();
				List<XTextElement> list = null;
				z0kr();
				bool flag2 = base.z0zrk() || base.z0xrk();
				for (int j = 0; j < count2; j++)
				{
					XTextElement xTextElement = array3[j];
					xTextElement.z0xuk = j;
					if (xTextElement is XTextParagraphFlagElement xTextParagraphFlagElement2)
					{
						xTextParagraphFlagElement2.z0eek(array3[num3]);
						num3 = j + 1;
					}
					else
					{
						if (!flag2 || !(xTextElement is XTextObjectElement))
						{
							continue;
						}
						z0eek(p0: true);
						if (z0rek(xTextElement))
						{
							if (list == null)
							{
								list = new List<XTextElement>();
							}
							list.Add(xTextElement);
						}
					}
				}
				if (list != null)
				{
					z0vrk().z0mek = list.ToArray();
				}
				else if (base.z0utk != null)
				{
					((z0qpk)base.z0utk).z0mek = null;
				}
				z0eok_jiejie20260327142557.Dispose();
			}
		}
		return z0utk;
	}

	internal new void z0yek(bool p0)
	{
		base.z0mek(p0);
	}

	internal new virtual z0ZzZzwzj z0yrk()
	{
		if (z0atk == z0gtk)
		{
			return null;
		}
		z0ZzZzzlh[] array = z0etk;
		if (array == null || array.Length == 0)
		{
			throw new InvalidOperationException("432:this._PrivateLines=null");
		}
		if (z0atk == null)
		{
			z0ZzZzwzj z0ZzZzwzj = new z0ZzZzwzj();
			int num = array.Length;
			for (int i = 0; i < num; i++)
			{
				z0ZzZzzlh z0ZzZzzlh = array[i];
				if (z0ZzZzzlh == null)
				{
					throw new InvalidOperationException("345:line=null");
				}
				if (z0ZzZzzlh.z0jrk_jiejie20260327142557() || z0ZzZzzlh.z0qtk() || z0ZzZzzlh.z0grk() == null)
				{
					continue;
				}
				z0ZzZzrzj z0ZzZzrzj = null;
				if (z0ZzZzzlh.z0grk().z0aek().z0lrk)
				{
					z0ZzZzrzj = z0ZzZzzlh.z0grk().z0aek();
				}
				z0ZzZzqzj z0ZzZzqzj = null;
				XTextElement xTextElement = null;
				z0ZzZzqzj z0ZzZzqzj2 = null;
				int count = z0ZzZzzlh.Count;
				XTextElement[] array2 = ((zzz.z0ZzZzkuk<XTextElement>)z0ZzZzzlh).z0krk();
				for (int j = 0; j < count; j++)
				{
					XTextElement xTextElement2 = array2[j];
					XTextElement xTextElement3 = null;
					if (xTextElement2 is XTextCharElement)
					{
						if (xTextElement != null && xTextElement.z0yek(xTextElement2) && xTextElement.z0buk == xTextElement2.z0buk)
						{
							((zzz.z0ZzZzkuk<XTextElement>)z0ZzZzqzj2?.z0rek()).z0pek(xTextElement2);
							continue;
						}
						xTextElement = xTextElement2;
						xTextElement3 = xTextElement2;
					}
					else
					{
						xTextElement = null;
						xTextElement3 = xTextElement2.z0ji();
					}
					z0ZzZzrzj z0ZzZzrzj2 = null;
					while (xTextElement3 != null && xTextElement3 != this)
					{
						if (xTextElement3.z0aek().z0wrk)
						{
							z0ZzZzrzj2 = xTextElement3.z0aek();
							break;
						}
						xTextElement3 = xTextElement3.z0ji();
					}
					if (z0ZzZzrzj2 == null)
					{
						z0ZzZzrzj2 = z0ZzZzrzj;
					}
					if (z0ZzZzrzj2 == null)
					{
						z0ZzZzqzj = null;
					}
					else if (z0ZzZzqzj == null || !z0ZzZzqzj.z0yek().z0eek(z0ZzZzrzj2))
					{
						z0ZzZzqzj = new z0ZzZzqzj();
						z0ZzZzqzj.z0rek().Add(xTextElement2);
						z0ZzZzqzj.z0eek(z0ZzZzzlh);
						z0ZzZzqzj.z0eek(z0ZzZzrzj2);
						z0ZzZzwzj.Add(z0ZzZzqzj);
					}
					else
					{
						z0ZzZzqzj.z0rek().Add(xTextElement2);
					}
					z0ZzZzqzj2 = z0ZzZzqzj;
				}
			}
			if (z0ZzZzwzj.Count > 0)
			{
				foreach (z0ZzZzqzj item in z0ZzZzwzj)
				{
					z0ZzZzbdh p = z0ZzZzbdh.z0xek;
					z0ZzZzbdh z0ZzZzbdh = z0qyk();
					using (zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = item.z0rek().z0ltk())
					{
						while (z0bpk.MoveNext())
						{
							XTextElement current2 = z0bpk.Current;
							p = ((!p.z0bek()) ? z0ZzZzbdh.z0yek(p, current2.z0qyk()) : current2.z0qyk());
						}
					}
					p.z0tek(0f - z0ZzZzbdh.z0oek(), 0f - z0ZzZzbdh.z0pek());
					item.z0eek(p);
				}
				z0atk = z0ZzZzwzj;
			}
			else
			{
				z0atk = z0gtk;
			}
		}
		return z0atk;
	}

	internal new bool z0urk()
	{
		return z0vtk();
	}

	public virtual string z0nr()
	{
		return null;
	}

	internal new void z0irk()
	{
		if (z0utk != null)
		{
			z0utk.z0frk();
			if (((zzz.z0ZzZzkuk<XTextElement>)z0utk).z0krk() == ((zzz.z0ZzZzkuk<XTextElement>)z0ntk).z0krk())
			{
				z0utk.z0dtk();
			}
		}
	}

	public new bool z0ork()
	{
		return ((z0qpk)base.z0utk)?.z0mek != null;
	}

	internal new bool z0prk()
	{
		return z0ttk();
	}

	private void z0rek(z0ZzZzzlh p0)
	{
		float p1 = z0eek(p0);
		p0.z0eek(p1);
		if (p0.z0iek() && !p0.z0jrk_jiejie20260327142557())
		{
			p0.z0jtk();
		}
	}

	internal new float z0mrk()
	{
		float specifyFixedLineHeight = SpecifyFixedLineHeight;
		if (specifyFixedLineHeight > 0f)
		{
			return specifyFixedLineHeight;
		}
		z0ZzZzrzj z0ZzZzrzj = z0aek();
		if (z0ZzZzrzj.z0cek > 0f)
		{
			return z0ZzZzrzj.z0cek;
		}
		return 0f;
	}

	public void z0eek(XTextElementList p0, bool p1, bool p2)
	{
		if (p0 == null || p0.Count == 0)
		{
			return;
		}
		int num = 2147483647;
		int num2 = -1;
		using (z0ZzZzjpk p3 = z0ru())
		{
			z0ZzZzvxj p4 = z0jr().z0bek(p3, (z0ZzZzcxj)0);
			XTextElementList xTextElementList = z0trk();
			foreach (XTextElement item in p0.z0xrk())
			{
				int num3 = xTextElementList.z0bek(item);
				if (num3 < 0)
				{
					throw new Exception("Element no in content");
				}
				if (num > num3)
				{
					num = num3;
				}
				if (item.z0ao() || item.z0ark())
				{
					item.z0jo();
				}
				if (item.z0ao())
				{
					item.z0mr(p4);
					item.z0jo();
				}
				item.z0hrk(p0: false);
				if (num3 > 0 && num3 > num2)
				{
					num2 = num3;
				}
			}
			z0jr().z0gnk().z0eek(p3);
		}
		z0eek(num, num2, p2);
		if (!p1)
		{
			z0qek().z0frk().z0uek(p0: true);
			z0qek().z0frk().z0tek(num, p1: false);
		}
	}

	internal new bool z0nrk()
	{
		List<z0ZzZzgkh> list = ((z0qpk)base.z0utk)?.z0oek;
		if (list != null)
		{
			return list.Count > 0;
		}
		return false;
	}

	internal new void z0brk()
	{
		for (XTextElement xTextElement = this; xTextElement != null; xTextElement = xTextElement.z0ji())
		{
			if (xTextElement is XTextContentElement)
			{
				((XTextContentElement)xTextElement).z0rek(p0: true);
			}
		}
	}

	internal new z0qpk z0vrk()
	{
		if (base.z0utk == null)
		{
			base.z0utk = new z0qpk();
		}
		return (z0qpk)base.z0utk;
	}

	private z0ZzZzzlh z0eek(z0ZzZzazj p0, z0ZzZzzlh p1)
	{
		if (z0utk == null || z0utk.Count == 0)
		{
			return null;
		}
		XTextDocument xTextDocument = z0jr();
		z0ZzZzrzj z0ZzZzrzj = z0aek();
		z0ZzZzzlh z0ZzZzzlh = new z0ZzZzzlh();
		XTextElement xTextElement = z0utk[0];
		int num = 0;
		if (p1 != null)
		{
			xTextElement = p1.LastElement;
			if (xTextElement != null)
			{
				num = z0utk.z0rrk(xTextElement, p0.z0krk);
				if (num >= 0)
				{
					p0.z0krk = num - 1;
					if (p0.z0krk < 0)
					{
						p0.z0krk = 0;
					}
					num++;
					xTextElement = z0utk.SafeGet(num);
				}
			}
		}
		if (xTextElement == null)
		{
			xTextElement = z0trk().z0krk();
			num = 0;
			p0.z0krk = 0;
		}
		if (num < 0)
		{
			num = 0;
			p0.z0krk = 0;
		}
		int num2 = 0;
		if (p0.z0grk != null && z0utk.SafeGet(p0.z0grk.z0xuk) == p0.z0grk)
		{
			num2 = p0.z0grk.z0xuk;
		}
		if (num2 > num)
		{
			z0ZzZzzlh.z0eek(p0.z0grk);
		}
		else
		{
			z0ZzZzzlh.z0eek(z0utk.z0oek(num));
			p0.z0grk = z0ZzZzzlh.z0grk();
		}
		float num3 = z0mrk();
		z0ZzZzrzj z0ZzZzrzj2 = z0ZzZzzlh.z0grk().z0aek();
		if (num3 <= 0f)
		{
			if (p1 == null || p1.z0grk() != z0ZzZzzlh.z0grk())
			{
				z0ZzZzzlh.z0bek(z0ZzZzrzj2.z0irk * z0drk());
			}
			else
			{
				z0ZzZzzlh.z0bek(0f);
			}
		}
		z0ZzZzzlh.z0eek(z0ZzZzrzj2.z0tuk);
		z0ZzZzzlh.z0rek(z0ZzZzrzj.z0ryk);
		if (p1 == null)
		{
			if (z0ju() == null && !z0urk())
			{
				z0ZzZzzlh.z0nek(z0ZzZzrzj.z0quk);
			}
			else
			{
				z0ZzZzzlh.z0nek(0f);
			}
		}
		else
		{
			float num4 = 0f;
			if (num3 > 0f)
			{
				num4 = num3;
				p1.z0eek(num4);
			}
			else
			{
				float num5 = p1.z0ftk() * z0drk();
				num4 = p1.z0grk().z0aek().z0eek(p1.z0wrk(), num5, GraphicsUnit.Document);
				if (p1.z0jrk_jiejie20260327142557())
				{
					num4 = (float)((double)p1.z0ntk().Height + (double)num5 * 0.1);
				}
				else if (p1.z0qtk())
				{
					num4 = (float)((double)p1.z0mek().Height + (double)num5 * 0.1);
				}
				else if (z0ZzZzrzj2.z0cyk == LineSpacingStyle.SpaceExactly)
				{
					p1.z0eek(0f);
				}
				else
				{
					p1.z0eek(num4);
				}
			}
			if (p1.z0grk() != z0ZzZzzlh.z0grk())
			{
				p1.z0iek(p1.z0grk().z0aek().z0zyk * z0drk());
			}
			if (p1.z0rtk())
			{
				p1.z0eek(0f);
				p1.z0bek(0f);
				p1.z0iek(0f);
				p1.z0yek(p0: false);
			}
			if (p1.z0mtk())
			{
				p1.z0eek(0f);
				p1.z0bek(0f);
				p1.z0iek(0f);
				p1.z0yek(p0: false);
			}
			if (p1.z0iek())
			{
				p1.z0jtk();
			}
			p1.z0wtk();
			z0ZzZzzlh.z0nek(p1.z0zrk() + p1.z0ytk());
		}
		z0ZzZzzlh.z0uek_jiejie20260327142557(z0ZzZzzlh.z0zrk());
		z0ZzZzzlh.z0mek(p0.z0lrk);
		z0ZzZzzlh.z0tek(Math.Max(xTextDocument.z0dik().z0mek(), xTextElement.Height));
		if (num3 > 0f)
		{
			z0ZzZzzlh.z0tek(num3);
		}
		z0ZzZzzlh.z0ayk = this;
		z0ZzZzzlh.z0euk = xTextDocument;
		return z0ZzZzzlh;
	}

	public override void z0ct()
	{
		XTextDocument xTextDocument = z0jr();
		if (xTextDocument == null)
		{
			return;
		}
		Width = xTextDocument.PageSettings.z0prk();
		z0grk();
		if (z0utk != null)
		{
			foreach (XTextElement item in z0utk.z0xrk())
			{
				item.z0yek((z0ZzZzzlh)null);
			}
		}
		z0ZzZzazj z0ZzZzazj = new z0ZzZzazj(null, null, z0cr());
		z0zt(z0ZzZzazj);
		z0ZzZzazj.z0tek();
	}

	public void z0eek(z0ZzZzzlh p0, z0ZzZzzlh p1)
	{
		if (p0 == p1 && p0 != null)
		{
			p0.z0tek(p0: true);
			return;
		}
		int num = z0zek().z0yek(p0);
		if (num < 0)
		{
			num = 0;
		}
		int num2 = z0zek().z0yek(p1);
		if (num2 < 0)
		{
			num2 = z0zek().Length - 1;
		}
		for (int i = num; i <= num2; i++)
		{
			z0zek()[i].z0tek(p0: true);
		}
	}

	internal new void z0uek(bool p0)
	{
		base.z0oek(p0);
	}

	private void z0eek(DCBooleanValueHasDefault p0)
	{
		switch (p0)
		{
		case DCBooleanValueHasDefault.Default:
			z0cek(p0: false);
			break;
		case DCBooleanValueHasDefault.True:
			z0cek(p0: true);
			z0jrk(p0: true);
			break;
		case DCBooleanValueHasDefault.False:
			z0cek(p0: true);
			z0jrk(p0: false);
			break;
		}
	}

	internal new void z0iek(bool p0)
	{
		z0urk(p0);
	}

	public float z0eek(z0ZzZzwrj p0)
	{
		z0ZzZzrzj z0ZzZzrzj = z0aek();
		z0ZzZzjpk p1 = new z0ZzZzjpk(new z0ZzZzadh());
		z0ZzZzvxj z0ZzZzvxj = new z0ZzZzvxj(null, p1, z0ZzZzbdh.z0xek);
		z0ZzZzvxj.z0eek(p0);
		z0ZzZzvxj.z0tek(z0ZzZzrzj.z0eek(z0qyk()));
		z0stk = 0f;
		z0eek(z0ZzZzvxj, Color.Empty, p2: false, p3: true, p4: true, 0f, z0mrk(), z0ZzZzrzj.z0eyk, z0ZzZzrzj.z0mek, p9: true);
		return z0stk;
	}

	public zzz.z0ZzZzjik<XTextParagraphFlagElement, List<XTextElementList>> z0eek(bool p0, bool p1, z0ZzZzndh p2, bool p3)
	{
		if (z0etk == null || z0etk.Length == 0)
		{
			return null;
		}
		Dictionary<int, int> dictionary = null;
		if (p1)
		{
			dictionary = z0jr().z0gnk().z0tek();
			if (dictionary.Count == 0)
			{
				dictionary = null;
			}
		}
		int num = 0;
		zzz.z0ZzZzjik<XTextParagraphFlagElement, List<XTextElementList>> z0ZzZzjik = new zzz.z0ZzZzjik<XTextParagraphFlagElement, List<XTextElementList>>();
		if (p3)
		{
			z0gu();
			XTextElementList xTextElementList = new XTextElementList();
			using zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = z0be().z0ltk();
			while (z0bpk.MoveNext())
			{
				XTextElement current = z0bpk.Current;
				if (dictionary == null || !dictionary.ContainsKey(current.z0pek()))
				{
					((zzz.z0ZzZzkuk<XTextElement>)xTextElementList).z0pek(current);
					if (current is XTextParagraphFlagElement)
					{
						List<XTextElementList> list = new List<XTextElementList>();
						list.Add(xTextElementList);
						z0ZzZzjik.z0rek((XTextParagraphFlagElement)current, list);
						xTextElementList = new XTextElementList();
					}
					else
					{
						_ = current is XTextSectionElement;
					}
				}
			}
			return z0ZzZzjik;
		}
		for (int i = 0; i < z0zek().Length; i++)
		{
			z0ZzZzzlh z0ZzZzzlh = z0zek()[i];
			if (!(z0ZzZzzlh.LastElement is XTextParagraphFlagElement))
			{
				continue;
			}
			List<XTextElementList> list2 = new List<XTextElementList>();
			for (int j = num; j <= i; j++)
			{
				z0ZzZzzlh z0ZzZzzlh2 = z0zek()[j];
				if (!p2.z0vek() && !p2.z0rek(z0ZzZzndh.z0eek(z0ZzZzzlh2.z0krk())))
				{
					continue;
				}
				if (p0 || dictionary != null)
				{
					bool flag = true;
					if (p0)
					{
						flag = z0ZzZzzlh2.z0ktk();
					}
					if (flag && dictionary != null)
					{
						flag = false;
						using zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = ((zzz.z0ZzZzkuk<XTextElement>)z0ZzZzzlh2).z0ltk();
						while (z0bpk.MoveNext())
						{
							XTextElement current2 = z0bpk.Current;
							if (!dictionary.ContainsKey(current2.z0pek()))
							{
								flag = true;
								break;
							}
						}
					}
					if (!flag)
					{
						continue;
					}
				}
				list2.Add(z0ZzZzzlh2);
			}
			if (list2.Count > 0)
			{
				z0ZzZzjik.z0rek((XTextParagraphFlagElement)z0ZzZzzlh.LastElement, list2);
			}
			num = i + 1;
		}
		return z0ZzZzjik;
	}

	public override bool z0fi()
	{
		if (z0ntk == null || z0ntk.Count == 0)
		{
			return false;
		}
		if (z0ntk.Count == 1 && z0ntk[0] is XTextParagraphFlagElement)
		{
			return false;
		}
		return true;
	}

	internal new void z0crk()
	{
		if (z0etk == null || z0etk.Length == 0 || !z0qrk())
		{
			return;
		}
		z0iek(p0: false);
		z0ZzZzzlh[] array = z0etk;
		foreach (z0ZzZzzlh z0ZzZzzlh in array)
		{
			if (z0ZzZzzlh.z0zrk() != z0ZzZzzlh.z0trk())
			{
				z0ZzZzzlh.z0nek(z0ZzZzzlh.z0trk());
				z0ZzZzzlh.z0erk();
			}
		}
	}

	private void z0eek(z0ZzZzzlh p0, bool p1)
	{
		p0.z0tek(p0: false);
		p0.z0ltk();
		if (p0.z0jrk_jiejie20260327142557())
		{
			p0.z0jtk();
			XTextTableElement xTextTableElement = p0.z0ntk();
			if (p1 || xTextTableElement.z0jyk || XTextDocument.z0yxk)
			{
				xTextTableElement.z0ct();
				p0.z0jtk();
			}
		}
		else if (p0.z0qtk())
		{
			p0.z0jtk();
			XTextSectionElement xTextSectionElement = p0.z0mek();
			if (p1 || xTextSectionElement.z0jrk() || XTextDocument.z0yxk)
			{
				xTextSectionElement.z0ct();
				p0.z0jtk();
			}
		}
		else
		{
			p0.z0jtk();
		}
	}

	internal new void z0oek(bool p0)
	{
		z0erk(p0);
	}

	public int z0eek(bool p0, bool p1, bool p2, bool p3, bool p4, bool p5, bool p6)
	{
		int num = 0;
		for (int num2 = z0be().Count - 1; num2 >= 0; num2--)
		{
			XTextElement xTextElement = z0be()[num2];
			if (xTextElement is XTextParagraphFlagElement)
			{
				if (!p2)
				{
					break;
				}
				num++;
			}
			else if (xTextElement is XTextLineBreakElement)
			{
				if (!p5)
				{
					break;
				}
				num++;
			}
			else if (xTextElement is XTextPageBreakElement)
			{
				if (!p4)
				{
					break;
				}
				num++;
			}
			else
			{
				if (!(xTextElement is XTextCharElement))
				{
					break;
				}
				char c = ((XTextCharElement)xTextElement).z0bek;
				if (p3 && c == '\u3000')
				{
					num++;
				}
				else if (p0 && c == ' ')
				{
					num++;
				}
				else
				{
					if (!p1 || c != '\t')
					{
						break;
					}
					num++;
				}
			}
		}
		if (num > 0)
		{
			if (num >= z0be().Count)
			{
				num--;
			}
			if (num > 0 && !(z0be()[z0be().Count - num - 1] is XTextParagraphFlagElement) && z0be()[z0be().Count - num] is XTextParagraphFlagElement)
			{
				num--;
			}
		}
		if (num > 0)
		{
			if (!p6)
			{
				XTextDocumentContentElement xTextDocumentContentElement = z0qek();
				XTextElement item = xTextDocumentContentElement.z0zek();
				XTextElement xTextElement2 = ((XTextElementList)xTextDocumentContentElement.z0frk()).z0pek(z0be().SafeGet(z0be().Count - num - 1));
				z0be().z0irk(z0be().Count - num, num);
				z0oe();
				if (!xTextDocumentContentElement.z0frk().Contains(item) && xTextDocumentContentElement.z0frk().Contains(xTextElement2))
				{
					xTextDocumentContentElement.z0frk().z0oek(xTextElement2);
				}
			}
			return num;
		}
		return 0;
	}

	protected internal int z0rek(int p0)
	{
		if (z0etk != null && z0etk.Length != 0)
		{
			z0ZzZzzlh[] array = z0etk;
			int num = array.Length;
			for (int i = 0; i < num; i++)
			{
				z0ZzZzzlh z0ZzZzzlh = array[i];
				z0ZzZzzlh.z0zyk = p0;
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
						int num2 = p0;
						XTextElement[] array3 = ((zzz.z0ZzZzkuk<XTextElement>)xTextTableRowElement.z0rek()).z0krk();
						int count2 = xTextTableRowElement.z0rek().Count;
						for (int k = 0; k < count2; k++)
						{
							XTextTableCellElement xTextTableCellElement = (XTextTableCellElement)array3[k];
							if (xTextTableCellElement.z0yi())
							{
								int num3 = ((XTextContentElement)xTextTableCellElement).z0rek(p0);
								if (num2 < num3)
								{
									num2 = num3;
								}
							}
						}
						p0 = num2;
					}
				}
				else
				{
					p0 = ((!z0ZzZzzlh.z0qtk()) ? (p0 + 1) : z0ZzZzzlh.z0mek().z0rek(p0));
				}
			}
			return p0;
		}
		return 0;
	}

	private new void z0pek(bool p0)
	{
		z0mrk(p0);
	}

	public new bool z0xrk()
	{
		if (z0ntk != null)
		{
			return z0ntk.Count == 0;
		}
		return true;
	}

	public new void z0mek(bool p0)
	{
		z0ork(p0);
	}

	public override XTextElement z0lr(bool p0)
	{
		XTextContentElement obj = (XTextContentElement)base.z0lr(p0);
		obj.z0utk = null;
		obj.z0etk = null;
		obj.z0atk = null;
		obj.z0nek(p0: true);
		if (p0)
		{
			z0yi();
		}
		return obj;
	}

	public virtual void z0gu()
	{
		if (z0ntk == null)
		{
			z0ntk = new XTextElementList();
		}
		if (!z0ntk.z0xek())
		{
			XTextParagraphFlagElement xTextParagraphFlagElement = new XTextParagraphFlagElement();
			xTextParagraphFlagElement.z0rek(p0: true);
			xTextParagraphFlagElement.z0iek(this);
			if (z0ntk.Capacity == 0)
			{
				z0ntk.z0rek(new XTextElement[1] { xTextParagraphFlagElement }, 1);
			}
			else
			{
				((zzz.z0ZzZzkuk<XTextElement>)z0ntk).z0pek((XTextElement)xTextParagraphFlagElement);
			}
			base.z0oek();
		}
	}

	private static void z0eek(XTextContentElement p0)
	{
		p0.z0irk();
		if (((XTextContainerElement)p0).z0utk != null)
		{
			((z0qpk)((XTextContainerElement)p0).z0utk).z0mek = null;
		}
		((XTextContainerElement)p0).z0qtk++;
		p0.z0we();
		XTextElement[] array = ((zzz.z0ZzZzkuk<XTextElement>)p0.z0be()).z0krk();
		int count = p0.z0be().Count;
		for (int i = 0; i < count; i++)
		{
			XTextElement xTextElement = array[i];
			if (!(xTextElement is XTextContainerElement))
			{
				continue;
			}
			if (xTextElement is XTextTableElement)
			{
				XTextTableElement obj = (XTextTableElement)xTextElement;
				obj.z0jyk = true;
				foreach (XTextElement item in obj.z0stk().z0xrk())
				{
					foreach (XTextTableCellElement item2 in item.z0be().z0xrk())
					{
						item2.z0nek(p0: true);
						z0eek(item2);
					}
				}
			}
			else if (xTextElement is XTextSectionElement)
			{
				((XTextSectionElement)xTextElement).z0nek(p0: true);
				z0eek((XTextSectionElement)xTextElement);
			}
		}
	}

	internal virtual void z0su()
	{
		z0utk = new XTextElementList(1);
		((zzz.z0ZzZzkuk<XTextElement>)z0utk).z0pek(z0ntk[0]);
	}

	internal new bool z0zrk()
	{
		return z0cyk();
	}

	internal void z0eek(z0ZzZzgkh p0)
	{
		List<z0ZzZzgkh> list = z0vrk().z0oek;
		if (list == null)
		{
			list = new List<z0ZzZzgkh>();
			z0vrk().z0oek = list;
		}
		list.Add(p0);
	}

	public virtual void z0qu()
	{
		if (base.z0utk != null)
		{
			((z0qpk)base.z0utk).z0krk = null;
		}
		z0utk = null;
		z0etk = null;
		z0be().Clear();
		if (z0jr() != null)
		{
			base.z0oek();
			z0be().Add(z0jr().z0uek<XTextParagraphFlagElement>());
		}
		z0bek(p0: true);
		z0ct();
	}

	internal new void z0nek(bool p0)
	{
		base.z0iek(p0);
	}

	public new Dictionary<XTextCharElement, XTextParagraphFlagElement> z0ltk()
	{
		Dictionary<XTextCharElement, XTextParagraphFlagElement> dictionary = new Dictionary<XTextCharElement, XTextParagraphFlagElement>();
		XTextParagraphFlagElement xTextParagraphFlagElement = null;
		for (int num = z0trk().Count - 1; num >= 0; num--)
		{
			XTextElement xTextElement = z0utk[num];
			if (xTextElement is XTextParagraphFlagElement)
			{
				xTextParagraphFlagElement = (XTextParagraphFlagElement)xTextElement;
			}
			else if (xTextElement is XTextCharElement)
			{
				dictionary[(XTextCharElement)xTextElement] = xTextParagraphFlagElement;
			}
		}
		return dictionary;
	}

	private new bool z0ktk()
	{
		if (z0ntk != null && z0ntk.Count == 1)
		{
			return z0ntk[0] is XTextParagraphFlagElement;
		}
		return false;
	}

	public new bool z0jtk()
	{
		if (z0ntk != null)
		{
			return z0ntk.z0mek();
		}
		return false;
	}

	public new virtual void z0bek(bool p0)
	{
		z0lgj z0lgj = new z0lgj();
		z0lgj.z0tek(p0);
		z0lgj.z0uek(p0: false);
		z0lgj.z0eek(p0: true);
		z0lgj.z0bek = true;
		z0au(z0lgj);
	}

	internal virtual bool z0eek(VerticalAlignStyle p0, bool p1, bool p2, bool p3 = false, float[] p4 = null)
	{
		z0ZzZzzlh[] array = z0etk;
		if (array == null || array.Length == 0)
		{
			return false;
		}
		if (Height == 0f)
		{
			return false;
		}
		z0atk = null;
		_ = this is XTextDocumentContentElement;
		XTextDocument xTextDocument = z0jr();
		float[] array2 = p4;
		if (array2 == z0qtk)
		{
			array2 = null;
		}
		else if (array2 != null)
		{
			for (int i = 0; i < array.Length; i++)
			{
				z0ZzZzzlh z0ZzZzzlh = array[i];
				array2[i * 2] = z0ZzZzzlh.z0trk();
				array2[i * 2 + 1] = z0ZzZzzlh.z0ytk();
			}
		}
		else if (z0ytk && !xTextDocument.z0qtk().Printing && !xTextDocument.z0qtk().PrintPreviewing && xTextDocument.z0kyk())
		{
			array2 = new float[array.Length * 2];
			for (int j = 0; j < array.Length; j++)
			{
				z0ZzZzzlh z0ZzZzzlh2 = array[j];
				array2[j * 2] = z0ZzZzzlh2.z0trk();
				array2[j * 2 + 1] = z0ZzZzzlh2.z0ytk();
			}
		}
		float num = 0f;
		int num2 = array.Length;
		z0ZzZzzlh[] array3 = array;
		for (int k = 0; k < num2; k++)
		{
			z0ZzZzzlh z0ZzZzzlh3 = array3[k];
			if (p3 && p2)
			{
				if (z0ZzZzzlh3.z0jrk_jiejie20260327142557())
				{
					z0ZzZzzlh3.z0ntk().z0mek(p0: false, p1: true);
					z0ZzZzzlh3.z0jtk();
				}
				else if (z0ZzZzzlh3.z0qtk())
				{
					XTextSectionElement xTextSectionElement = z0ZzZzzlh3.z0mek();
					xTextSectionElement.z0eek(VerticalAlignStyle.Top, p1, p2, p3);
					xTextSectionElement.z0ly();
					z0ZzZzzlh3.z0jtk();
				}
			}
			num += z0ZzZzzlh3.z0ytk();
		}
		float num3 = 0f;
		float num4 = 0f;
		float num5 = 0f;
		z0ZzZzzej z0ZzZzzej = z0ju();
		if (z0ZzZzzej != null && (!z0ZzZzzej.z0uek() || z0ZzZzzej.z0zek() <= 0f))
		{
			z0ZzZzzej = null;
		}
		if (z0ZzZzzej == null && !z0urk())
		{
			z0ZzZzrzj z0ZzZzrzj = z0aek();
			num4 = z0ZzZzrzj.z0quk;
			num5 = z0ZzZzrzj.z0xrk;
		}
		switch (p0)
		{
		case VerticalAlignStyle.Top:
			num3 = num4;
			break;
		case VerticalAlignStyle.Middle:
			num3 = (Height - num4 - num5 - num) / 2f;
			if (z0ZzZzzej != null)
			{
				num3 = (float)Math.Round(num3 / z0ZzZzzej.z0zek()) * z0ZzZzzej.z0zek();
			}
			num3 = num4 + Math.Max(0f, num3);
			break;
		case VerticalAlignStyle.Bottom:
			num3 = Height - num4 - num5 - num;
			if (z0ZzZzzej != null)
			{
				num3 = (float)Math.Round(num3 / z0ZzZzzej.z0zek()) * z0ZzZzzej.z0zek();
			}
			num3 = num4 + Math.Max(0f, num3);
			break;
		}
		XTextElement[] array4 = ((z0qpk)base.z0utk)?.z0mek;
		bool flag = false;
		for (int l = 0; l < num2; l++)
		{
			z0ZzZzzlh z0ZzZzzlh4 = array3[l];
			if ((z0ZzZzzlh4.z0jrk_jiejie20260327142557() || z0ZzZzzlh4.z0qtk() || z0ZzZzzlh4.z0rtk()) && array4 != null)
			{
				XTextElement[] array5 = array4;
				foreach (XTextElement xTextElement in array5)
				{
					z0ZzZzzlh z0ZzZzzlh5 = xTextElement.z0ptk();
					if (array.z0yek(z0ZzZzzlh5) < array.z0yek(z0ZzZzzlh4))
					{
						float num6 = z0ZzZzzlh5.z0zrk() + xTextElement.z0yt() + xTextElement.Height;
						if (num3 < num6)
						{
							num3 = num6;
						}
					}
				}
			}
			z0ZzZzzlh4.z0uek_jiejie20260327142557(num3);
			z0ZzZzzlh4.z0nek(num3);
			num3 += z0ZzZzzlh4.z0ytk();
			z0ZzZzzlh4.z0erk();
		}
		bool flag2 = false;
		if (p3)
		{
			flag2 = flag;
		}
		else if (p2)
		{
			for (int n = 0; n < num2; n++)
			{
				z0ZzZzzlh z0ZzZzzlh6 = array3[n];
				if (z0ZzZzzlh6.z0jrk_jiejie20260327142557())
				{
					XTextTableElement xTextTableElement = z0ZzZzzlh6.z0ntk();
					float[] array6 = ((array2 == null) ? z0qtk : new float[100]);
					foreach (XTextTableRowElement item in xTextTableElement.z0stk().z0xrk())
					{
						if (!item.z0cuk)
						{
							continue;
						}
						foreach (XTextTableCellElement item2 in item.z0rek().z0xrk())
						{
							if (item2.z0yi() && ((XTextContentElement)item2).z0iek() > 0)
							{
								int num7 = ((XTextContentElement)item2).z0iek();
								if (array6 != z0qtk && array6.Length < num7 * 2)
								{
									array6 = new float[num7 * 2];
								}
								if (item2.z0eek(item2.z0aek().z0srk, p1, p2, p3: false, array6))
								{
									flag2 = true;
								}
							}
						}
					}
					array6 = null;
				}
				else if (z0ZzZzzlh6.z0qtk() && z0ZzZzzlh6.z0mek().z0eek(VerticalAlignStyle.Top, p1, p2))
				{
					flag2 = true;
				}
			}
		}
		if (!flag2 && array2 != null)
		{
			for (int num8 = 0; num8 < array.Length; num8++)
			{
				z0ZzZzzlh z0ZzZzzlh7 = array[num8];
				if (z0ZzZzzlh7.z0trk() == array2[num8 * 2] && z0ZzZzzlh7.z0ytk() == array2[num8 * 2 + 1])
				{
					continue;
				}
				foreach (XTextElement item3 in ((zzz.z0ZzZzkuk<XTextElement>)z0ZzZzzlh7).z0xrk())
				{
					xTextDocument.z0xek(item3);
				}
				flag2 = true;
			}
		}
		array2 = null;
		if (flag2 || z0xek())
		{
			z0ly();
		}
		return flag2;
	}

	internal new void z0htk()
	{
		base.z0mek(p0: true);
		if (z0etk != null && z0etk.Length != 0)
		{
			z0ZzZzzlh z0ZzZzzlh = z0etk[z0etk.Length - 1];
			base.z0mek(z0ZzZzzlh.z0ark() > Height + 0.1f || z0ZzZzzlh.z0nek() > Width + 0.1f);
		}
	}

	protected internal virtual void z0er(z0ZzZzvxj p0)
	{
		if (!p0.z0rek() || this is XTextDocumentBodyElement)
		{
			return;
		}
		z0ZzZzzej z0ZzZzzej = z0ju();
		if ((z0ZzZzzej != null && !(this is XTextDocumentBodyElement) && z0ZzZzzej == z0jr().z0qxk) || z0ZzZzzej == null || !z0ZzZzzej.z0uek() || z0ZzZzzej.z0zek() <= 0f || (p0.z0byk == (z0ZzZzcxj)3 && !z0ZzZzzej.z0yek()) || z0etk == null || z0etk.Length == 0)
		{
			return;
		}
		z0ZzZzbdh p1 = p0.z0nek();
		z0ZzZzbdh z0ZzZzbdh = z0myk_jiejie20260327142557();
		z0ZzZzrzj z0ZzZzrzj = z0aek();
		z0ZzZzbdh.z0eek(z0ZzZzbdh.z0tek() - z0ZzZzrzj.z0ryk);
		z0ZzZzbdh.z0tek(z0ZzZzbdh.z0uek() + (z0ZzZzrzj.z0ryk + z0ZzZzrzj.z0ptk));
		if (p1.z0pek() < z0ZzZzbdh.z0pek())
		{
			p1.z0yek(p1.z0nek() - z0ZzZzbdh.z0pek());
			p1.z0rek(z0ZzZzbdh.z0pek());
		}
		p1.z0eek(z0ZzZzbdh.z0tek());
		p1.z0tek(z0ZzZzbdh.z0uek());
		float num = ((XTextElement)this).z0ltk();
		float num2 = Math.Max(z0ZzZzbdh.z0nek(), p1.z0nek());
		float num3 = Math.Max(z0ZzZzbdh.z0pek(), p1.z0pek() + 2f);
		if (!p0.z0hrk().z0bek())
		{
			num2 = Math.Min(num2, p0.z0hrk().z0nek());
			num3 = Math.Max(num3, p0.z0hrk().z0pek());
		}
		float num4 = z0ZzZzzej.z0zek();
		if (!(this is XTextDocumentBodyElement) && z0ZzZzrzj.z0wrk && z0ZzZzrzj.z0mrk && z0ZzZzrzj.z0trk.A > 0 && p0.z0lrk() != null)
		{
			num2 = Math.Min(num2, p0.z0stk);
		}
		float num5 = 3.4028235E+38f;
		if (p0.z0lrk() != null)
		{
			num5 = p0.z0stk;
			if (this is XTextDocumentBodyElement)
			{
				num5 = Math.Max(num5, num2);
			}
		}
		z0ZzZzudh z0ZzZzudh = z0ZzZzzej.z0tek();
		if (p0.z0zrk)
		{
			z0ZzZzudh.z0eek(Color.Black);
		}
		float num6 = num + z0etk[0].z0zrk();
		while (num6 >= num3 && num6 > z0ZzZzbdh.z0pek() + 10f)
		{
			if (num6 >= num3 && num6 <= p1.z0nek() + 5f)
			{
				z0eek(p0.z0gyk, z0ZzZzudh, p1, num6, num4);
			}
			num6 -= num4;
		}
		float num7 = num + z0etk[z0etk.Length - 1].z0ark();
		bool generateLongBmp = z0jr().z0qtk().GenerateLongBmp;
		bool flag = p0.z0byk == (z0ZzZzcxj)0 && z0iu().ShowCellNoneBorder;
		Color p2 = Color.FromArgb(z0ZzZzzej.z0iek().A / 5, z0ZzZzzej.z0iek());
		z0ZzZzzlh[] array = z0zek();
		foreach (z0ZzZzzlh z0ZzZzzlh in array)
		{
			if (!generateLongBmp && p0.z0krk() == PageViewMode.Page && z0ZzZzzlh.z0dtk() != null && z0ZzZzzlh.z0dtk().z0irk() > p0.z0lrk().z0irk())
			{
				break;
			}
			float num8 = num + z0ZzZzzlh.z0zrk();
			float num9 = num + z0ZzZzzlh.z0ark();
			if (num9 >= num3 && num9 <= p1.z0nek() + 5f)
			{
				if (num + z0ZzZzzlh.z0zrk() + z0ZzZzzlh.z0atk() >= num5)
				{
					break;
				}
				if (p0.z0lrk() != null && num9 > p0.z0lrk().z0qrk() + 0.1f)
				{
					num9 = p0.z0lrk().z0qrk();
					num9 = z0ZzZzzej.z0eek(num9 - p0.z0lrk().z0irk()) + p0.z0lrk().z0irk();
				}
				num7 = num9;
				if (p0.z0lrk() != null && (double)(num2 - num9) < (double)num4 * 0.2)
				{
					break;
				}
				z0eek(p0.z0gyk, z0ZzZzudh, p1, num9, num4);
				if (flag && z0ZzZzzlh.z0ytk() > num4 + 5f && !z0ZzZzzlh.z0jrk_jiejie20260327142557() && !z0ZzZzzlh.z0qtk())
				{
					z0ZzZzudh z0ZzZzudh2 = new z0ZzZzudh(p2);
					for (float num10 = num9 - num4; num10 > num8 + 5f; num10 -= num4)
					{
						if (num10 >= p1.z0pek() && num10 <= p1.z0nek())
						{
							p0.z0gyk.z0eek(z0ZzZzudh2, p1.z0oek(), num10, p1.z0mek(), num10);
						}
					}
					z0ZzZzudh2.Dispose();
				}
			}
			if (num9 >= p1.z0nek() + 5f)
			{
				if (p1.z0nek() > num + z0ZzZzzlh.z0zrk())
				{
					if (this is XTextDocumentBodyElement && p0.z0krk() == PageViewMode.Page)
					{
						if (p0.z0lrk() != null && num9 > p0.z0lrk().z0qrk())
						{
							num9 = p0.z0lrk().z0irk() + z0ZzZzzej.z0eek(p0.z0lrk().z0xek());
						}
					}
					else
					{
						num7 = num9;
					}
					num7 = num9;
				}
				else if (num9 < num2)
				{
					num7 = num9;
				}
				break;
			}
			num7 = num9;
		}
		for (float num11 = num7; num11 < p1.z0nek(); num11 += num4)
		{
			if (!((double)(num2 - num11) < (double)num4 * 0.8) || (this is XTextDocumentBodyElement && p0.z0krk() == PageViewMode.Page))
			{
				z0eek(p0.z0gyk, z0ZzZzudh, p1, num11, num4);
			}
		}
		z0ZzZzudh.Dispose();
	}
}
