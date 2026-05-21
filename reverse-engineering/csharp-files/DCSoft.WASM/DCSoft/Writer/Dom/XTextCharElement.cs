using System;
using System.Diagnostics;
using System.Text;
using DCSoft.Drawing;
using DCSystem_Drawing;
using DCSystem_Drawing.Drawing2D;
using zzz;

namespace DCSoft.Writer.Dom;

[DebuggerDisplay("Char:{CharValue}")]
public class XTextCharElement : XTextElement
{
	internal new char z0bek;

	public new static readonly string z0cek = new string('\u2002', 1);

	internal new static bool z0zek = false;

	internal new float z0lrk;

	[NonSerialized]
	internal new float z0hrk = 1f;

	[NonSerialized]
	private new ushort z0frk;

	private new static int z0srk = 0;

	public char CharValue
	{
		get
		{
			return z0bek;
		}
		set
		{
			z0bek = value;
		}
	}

	[z0ZzZzuqh]
	public override string Text
	{
		get
		{
			if (z0tek((int)z0bek))
			{
				return z0yek();
			}
			return z0ZzZzqik.z0yek(z0bek);
		}
		set
		{
			if (value != null && value.Length > 0)
			{
				z0bek = value[0];
			}
		}
	}

	public static bool z0rek(char p0)
	{
		if (z0ZzZzugh.z0eek(p0))
		{
			return z0uek();
		}
		return true;
	}

	public override string z0ge()
	{
		return "Char:" + Text;
	}

	public override void z0mt(float p0)
	{
		z0lrk = p0;
	}

	internal static bool z0rek(int p0)
	{
		if (p0 >= 56320)
		{
			return p0 <= 57343;
		}
		return false;
	}

	public override string z0gy()
	{
		if (z0tek((int)z0bek))
		{
			return z0yek();
		}
		return z0bek.ToString();
	}

	internal static void z0rek()
	{
		z0srk = 0;
	}

	public void z0rek(float p0)
	{
		if (float.IsNaN(p0))
		{
			p0 = 1f;
		}
		z0hrk = p0;
	}

	public int z0tek()
	{
		return z0bek;
	}

	public override void z0bw_jiejie20260327142557(z0ygj p0)
	{
		if (z0tek((int)z0bek))
		{
			p0.z0eek(z0bek);
			p0.z0eek((char)z0frk);
		}
		else
		{
			p0.z0eek(z0bek);
		}
	}

	internal new string z0yek()
	{
		return new string(new char[2]
		{
			z0bek,
			(char)z0frk
		});
	}

	public void z0rek(bool p0)
	{
		z0vek(p0);
	}

	public override void z0fy(z0ZzZzdxj p0)
	{
		if (z0tek((int)z0bek))
		{
			p0.z0eek(z0bek);
			p0.z0eek((char)z0frk);
		}
		else
		{
			p0.z0eek(z0bek);
		}
	}

	internal XTextCharElement(char c, XTextContainerElement parent, XTextDocument document, int styleIndex)
	{
		z0bek = c;
		z0uik = parent;
		z0rik = document;
		z0buk = styleIndex;
	}

	public XTextCharElement()
	{
	}

	public override void z0mr(z0ZzZzvxj p0)
	{
		if (z0bek == '\u200d' || z0bek == '\u200c')
		{
			Width = 0f;
			Height = z0aek().z0btk.z0eek(p0.z0guk);
			return;
		}
		char c = z0bek;
		switch (c)
		{
		case '\u2003':
			c = '袁';
			break;
		case '\u2002':
			c = 'n';
			break;
		default:
			if (z0tek((int)c))
			{
				c = '袁';
			}
			break;
		}
		z0ZzZzrzj z0ZzZzrzj = z0aek();
		if (z0ZzZzrzj == null)
		{
			return;
		}
		z0irk(p0: false);
		z0ZzZzxdh z0ZzZzxdh = p0.z0xtk.z0rek(c, p0.z0guk, p0.z0ntk, z0ZzZzrzj, z0hrk);
		if (z0ZzZzlcj.z0xek != null)
		{
			z0irk(p0: true);
		}
		if (z0ZzZzxdh.z0rek() == 0f && c > '♂')
		{
			z0ZzZzxdh = p0.z0xtk.z0rek('袁', p0.z0guk, p0.z0ntk, z0ZzZzrzj, z0hrk);
		}
		if (z0ZzZzxdh.z0rek() > 0f && z0ZzZzugh.z0eek(z0bek))
		{
			if (z0uek())
			{
				if (z0ZzZzugh.z0rek(z0bek))
				{
					z0ZzZzxdh.z0eek(0f);
				}
				else if (z0ZzZzxdh.z0rek() <= 0f)
				{
					z0ZzZzimk p1 = z0ZzZzrzj.z0eek(z0hrk).Clone();
					z0ZzZzxdh z0ZzZzxdh2 = z0ZzZzlcj.z0rek(p0.z0gyk, z0bek.ToString(), p1, 10000, z0ZzZzlsh.z0uek());
					z0ZzZzxdh2.z0eek((int)z0ZzZzrpk.z0eek((double)z0ZzZzxdh2.z0rek(), p0.z0ntk));
					z0ZzZzxdh2.z0rek((int)z0ZzZzrpk.z0eek((double)z0ZzZzxdh2.z0tek(), p0.z0ntk));
					z0ZzZzxdh = p0.z0xtk.z0rek(c, p0.z0guk, p0.z0ntk, z0ZzZzrzj, z0hrk);
					z0ZzZzxdh.z0eek(z0ZzZzxdh2.z0rek());
				}
			}
			else
			{
				z0ZzZzxdh.z0eek(10f);
			}
		}
		z0fik = z0ZzZzxdh.z0rek();
		z0aik = z0ZzZzxdh.z0tek();
		if (z0ZzZzrzj.z0yrk != CharacterCircleStyles.None)
		{
			if (z0fik > z0aik)
			{
				z0fik *= 1.4f;
			}
			else
			{
				z0fik = z0aik * 1.4f;
			}
			z0aik = z0fik;
		}
		if (z0ZzZzrzj.z0euk || z0ZzZzrzj.z0gtk)
		{
			z0fik *= 0.6f;
		}
		z0xi(p0: false);
	}

	public override string z0xr()
	{
		if (z0tek((int)z0bek))
		{
			string[] obj = new string[9]
			{
				"[",
				z0tuk.ToString(),
				"]",
				z0yek(),
				"[H:",
				null,
				null,
				null,
				null
			};
			int num = z0bek;
			obj[5] = num.ToString();
			obj[6] = ",L:";
			obj[7] = z0frk.ToString();
			obj[8] = "]";
			return string.Concat(obj);
		}
		return "[" + z0tuk + "]" + z0bek + " [" + z0tek() + "]";
	}

	public override void z0tt(z0ZzZzvxj p0)
	{
		p0.z0xrk = null;
		z0ZzZzbdh p1 = p0.z0gtk;
		p1.z0tek(z0fik + z0lrk);
		if (p0.z0pyk)
		{
			p0.z0yyk.z0eek(this, p0, p1);
		}
		if (p0.z0duk != null)
		{
			z0rek(p0);
		}
		else if (z0bek == '\u2003' || z0bek == '\u2002' || z0bek == '\u00a0' || z0bek == '\u2009' || z0bek == '\u200d' || z0bek == '\u200c' || z0bek == ' ' || z0bek == '\b')
		{
			z0ZzZzrzj z0ZzZzrzj = z0aek();
			if (z0ZzZzrzj.z0uyk || z0ZzZzrzj.z0yyk || z0ZzZzrzj.z0iyk)
			{
				z0rek(p0);
			}
		}
		else
		{
			z0rek(p0);
		}
	}

	internal XTextCharElement(char c, XTextContainerElement parent)
	{
		z0bek = c;
		if (parent != null)
		{
			z0uik = parent;
			z0rik = ((XTextElement)parent).z0drk();
		}
	}

	private new static bool z0uek()
	{
		if (z0srk == 0)
		{
			z0ZzZzpck z0ZzZzpck = (z0ZzZzpck)XTextDocument.z0dnk();
			if (z0ZzZzpck.z0zek && !z0ZzZzpck.z0uek())
			{
				z0srk = -1;
			}
			else
			{
				z0srk = 1;
			}
		}
		return z0srk == 1;
	}

	public static bool z0tek(char p0)
	{
		if (p0 == ' ' || p0 == '\b')
		{
			return true;
		}
		if (p0 > 'ὀ')
		{
			if (p0 != '\u2003' && p0 != '\u2002' && p0 != '\u2009' && p0 != '\u200d')
			{
				return p0 == '\u200c';
			}
			return true;
		}
		return p0 == '\u00a0';
	}

	internal new ushort z0iek()
	{
		return z0frk;
	}

	public XTextCharElement(char c, int styleIndex)
	{
		z0bek = c;
		z0buk = styleIndex;
	}

	public override float z0ut()
	{
		return z0fik + z0lrk;
	}

	internal void z0rek(ushort p0)
	{
		z0frk = p0;
	}

	internal static bool z0tek(int p0)
	{
		if (p0 >= 55296)
		{
			return p0 <= 56319;
		}
		return false;
	}

	public override void z0mu(DocumentEventArgs p0)
	{
		if (z0ji() is XTextFieldElementBase)
		{
			((XTextFieldElementBase)z0ji()).z0eek(this);
		}
		else if (p0.Style != DocumentEventStyles.LostFocus && p0.Style != DocumentEventStyles.GotFocus && p0.Style != DocumentEventStyles.LostFocusExt)
		{
			base.z0mu(p0);
		}
	}

	internal void z0eek(zzz.z0ZzZzkuk<char> p0)
	{
		if (z0tek((int)z0bek))
		{
			p0.Add(z0bek);
			p0.Add((char)z0frk);
		}
		else if (z0bek >= '\b')
		{
			p0.Add(z0bek);
		}
	}

	public new bool z0oek()
	{
		return z0urk();
	}

	internal new void z0pek()
	{
		if (z0bek == '\t')
		{
			Width = z0ZzZzafh.z0yek(z0it() - z0jr().z0it(), z0jr().z0dik().TabWidth);
		}
	}

	public static bool z0rek(string p0)
	{
		if (p0.Length != 1)
		{
			if (p0.Length == 2)
			{
				return z0tek((int)p0[0]);
			}
			return false;
		}
		return true;
	}

	public override string ToString()
	{
		if (z0tek((int)z0bek))
		{
			return z0yek();
		}
		return z0bek.ToString();
	}

	private void z0rek(z0ZzZzvxj p0)
	{
		char c = z0bek;
		if (c == '\u0001')
		{
			return;
		}
		bool flag = p0.z0duk == null && z0tek(z0bek);
		z0ZzZzrzj z0ZzZzrzj = p0.z0luk;
		float num = 0f;
		string text = null;
		if (z0ZzZzugh.z0eek(z0bek) && z0uek())
		{
			z0ZzZzplh z0ZzZzplh = p0.z0brk;
			if (z0ZzZzplh == null)
			{
				z0ZzZzplh = ((p0.z0mek() == null) ? z0qek().z0frk() : p0.z0mek().z0frk());
			}
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append(z0bek);
			int num2 = z0ZzZzplh.z0bek(this);
			if (num2 >= 0)
			{
				int num3 = Math.Min(z0ZzZzplh.Count, num2 + 10);
				for (int i = num2 + 1; i < num3 && z0ZzZzplh[i] is XTextCharElement xTextCharElement; i++)
				{
					if (!z0ZzZzugh.z0eek(xTextCharElement.z0bek))
					{
						break;
					}
					if (xTextCharElement.z0fik != 0f)
					{
						break;
					}
					stringBuilder.Append(xTextCharElement.z0bek);
					if (stringBuilder.Length == 6)
					{
						break;
					}
				}
				if (stringBuilder.Length > 1)
				{
					text = stringBuilder.ToString();
				}
			}
			num = z0aik * -0.12f;
		}
		z0ZzZzbdh z0ZzZzbdh = p0.z0gtk;
		z0ZzZzbdh z0ZzZzbdh2 = z0ZzZzbdh;
		z0ZzZzbdh2.z0rek(z0ZzZzbdh2.z0yek() + p0.z0ark);
		z0ZzZzbdh2.z0yek(z0ZzZzbdh2.z0iek() * 1.5f);
		z0ZzZzbdh2.z0tek(z0ZzZzbdh2.z0uek() * 1.5f);
		Color color = z0ZzZzrzj.z0bek;
		if (p0.z0wyk)
		{
			color = z0ZzZzrzj.z0nyk;
		}
		DCBooleanValueHasDefault dCBooleanValueHasDefault = DCBooleanValueHasDefault.Default;
		if (z0oek())
		{
			if (!p0.z0mrk)
			{
				return;
			}
			if (z0uik is XTextFieldElementBase xTextFieldElementBase)
			{
				color = xTextFieldElementBase.z0eek(p0.z0rtk);
				dCBooleanValueHasDefault = xTextFieldElementBase.z0drk();
			}
		}
		else if (z0uik is XTextInputFieldElement)
		{
			color = ((XTextInputFieldElement)z0uik).z0eek(color, z0ZzZzrzj, p0.z0byk == (z0ZzZzcxj)3 || p0.z0byk == (z0ZzZzcxj)2, p0.z0rtk);
		}
		if (p0.z0byk == (z0ZzZzcxj)0)
		{
			z0ZzZzqxj z0ZzZzqxj = null;
			if (p0.z0ryk == this)
			{
				z0ZzZzqxj = p0.z0qyk;
			}
			else
			{
				z0ZzZzqxj = p0.z0xrk;
				if (z0ZzZzqxj == null && p0.z0vtk != null)
				{
					z0ZzZzqxj = p0.z0vtk.z0zo(this, p0);
				}
			}
			if (z0ZzZzqxj != null && z0ZzZzqxj.z0uek().A != 0)
			{
				color = z0ZzZzqxj.z0uek();
			}
		}
		bool flag2 = true;
		string text2 = null;
		if (z0tek((int)c))
		{
			text2 = z0yek();
			flag2 = false;
			z0zek = true;
		}
		if (text != null)
		{
			text2 = text;
			flag2 = false;
		}
		Color color2 = color;
		if (p0.z0zrk && color.A != 0)
		{
			color2 = Color.Black;
		}
		if (z0rik.z0cbk != null)
		{
			XTextDocument.z0ipk z0ipk = null;
			z0rik.z0cbk.TryGetValue(this, out z0ipk);
			if (z0ipk != null)
			{
				if (p0.z0byk == (z0ZzZzcxj)3 && !z0ipk.z0yek)
				{
					z0ipk = null;
				}
				if (z0ipk != null)
				{
					if (z0ipk.z0rek.A != 0)
					{
						color2 = z0ipk.z0rek;
					}
					if (z0ipk.z0tek.A != 0)
					{
						z0ZzZzbdh p1 = z0qyk();
						p1.z0tek(p1.z0uek() + z0lrk);
						using z0ZzZzzdh p2 = new z0ZzZzzdh(z0ipk.z0tek);
						p0.z0gyk.z0rek(p2, p1);
					}
				}
			}
		}
		bool flag3 = false;
		if (z0jtk())
		{
			flag3 = true;
		}
		else if (z0hrk != 1f || z0ZzZzrzj.z0euk || z0ZzZzrzj.z0gtk)
		{
			flag3 = true;
		}
		else if (dCBooleanValueHasDefault == DCBooleanValueHasDefault.True && !z0ZzZzrzj.z0vtk_jiejie20260327142557)
		{
			flag3 = true;
		}
		else if (dCBooleanValueHasDefault == DCBooleanValueHasDefault.False && z0ZzZzrzj.z0vtk_jiejie20260327142557)
		{
			flag3 = true;
		}
		else if (z0ZzZzrzj.z0uyk || z0ZzZzrzj.z0yyk)
		{
			flag3 = true;
		}
		z0ZzZzimk z0ZzZzimk = z0ZzZzrzj.z0pek;
		if (flag3)
		{
			z0ZzZzimk = z0ZzZzimk.Clone();
			z0ZzZzimk.Size *= z0hrk;
			switch (dCBooleanValueHasDefault)
			{
			case DCBooleanValueHasDefault.True:
				z0ZzZzimk.Italic = true;
				break;
			case DCBooleanValueHasDefault.False:
				z0ZzZzimk.Italic = false;
				break;
			}
			z0ZzZzimk.Underline = false;
			z0ZzZzimk.Strikeout = false;
			if (z0ZzZzrzj.z0gtk || z0ZzZzrzj.z0euk)
			{
				z0ZzZzimk.Size *= 0.5f;
			}
			if (z0jtk())
			{
				string text3 = z0ZzZzlcj.z0tek(z0bek);
				if (text3 != null)
				{
					z0ZzZzimk.Name = text3;
				}
			}
		}
		z0ZzZzlsh p3 = p0.z0wrk;
		if (z0ZzZzrzj.z0gtk || z0ZzZzrzj.z0euk)
		{
			z0ZzZzimk.Strikeout = false;
			float num4 = p0.z0eek(z0ZzZzimk);
			flag2 = false;
			text2 = z0ZzZzqik.z0yek(c);
			if (z0tek((int)c))
			{
				text2 = z0yek();
			}
			if (z0ZzZzrzj.z0euk)
			{
				if (p0.z0byk == (z0ZzZzcxj)5 || p0.z0byk == (z0ZzZzcxj)3)
				{
					if (!flag)
					{
						p0.z0gyk.z0eek(text2, z0ZzZzimk, color2, z0ZzZzbdh2.z0oek(), z0ZzZzbdh2.z0pek() - num4 * 0.1f, p3);
					}
					if (z0ZzZzrzj.z0yyk)
					{
						float num5 = z0ZzZzbdh2.z0pek() + num4 * 0.38f;
						p0.z0gyk.z0tek(color2, z0ZzZzbdh2.z0oek(), num5, z0ZzZzbdh2.z0oek() + z0fik + z0lrk, num5);
					}
				}
				else
				{
					if (!flag)
					{
						p0.z0gyk.z0eek(text2, z0ZzZzimk, color2, z0ZzZzbdh2.z0oek(), z0ZzZzbdh2.z0pek() + num4 * 0.4f, p3);
					}
					if (z0ZzZzrzj.z0yyk)
					{
						float num6 = z0ZzZzbdh2.z0pek() + num4 * 0.38f;
						p0.z0gyk.z0tek(color2, z0ZzZzbdh2.z0oek(), num6, z0ZzZzbdh2.z0oek() + z0fik + z0lrk, num6);
					}
				}
			}
			else if (p0.z0byk == (z0ZzZzcxj)5 || p0.z0byk == (z0ZzZzcxj)3)
			{
				p0.z0gyk.z0eek(text2, z0ZzZzimk, color2, z0ZzZzbdh2.z0oek(), (float)Math.Floor(z0ZzZzbdh2.z0pek() + num4 * 1f), p3);
				if (z0ZzZzrzj.z0yyk)
				{
					float num7 = z0ZzZzbdh2.z0pek() + num4 * 1.5f;
					p0.z0gyk.z0tek(color2, z0ZzZzbdh2.z0oek(), num7, z0ZzZzbdh2.z0oek() + z0fik + z0lrk, num7);
				}
			}
			else
			{
				float num8 = (float)Math.Floor(z0ZzZzbdh2.z0nek() - num4 * 1.5f);
				p0.z0gyk.z0eek(text2, z0ZzZzimk, color2, z0ZzZzbdh2.z0oek(), num8, p3);
				if (z0ZzZzrzj.z0yyk)
				{
					float num9 = num8 - num4 * 0.03f;
					p0.z0gyk.z0tek(color2, z0ZzZzbdh2.z0oek(), num9, z0ZzZzbdh2.z0oek() + z0fik + z0lrk, num9);
				}
			}
		}
		else if (z0ZzZzrzj.z0yrk == CharacterCircleStyles.None)
		{
			if (!flag)
			{
				if (!flag2)
				{
					if (p0.z0byk == (z0ZzZzcxj)5 || p0.z0byk == (z0ZzZzcxj)3)
					{
						p0.z0gyk.z0eek(text2, z0ZzZzimk, color2, new z0ZzZzbdh(z0ZzZzbdh2.z0oek(), z0ZzZzbdh2.z0pek() + num, z0ZzZzbdh2.z0uek(), z0ZzZzbdh2.z0iek()), p0.z0wrk);
					}
					else
					{
						p0.z0gyk.z0eek(text2, z0ZzZzimk, color2, new z0ZzZzbdh(z0ZzZzbdh2.z0oek(), z0ZzZzbdh2.z0pek() + num, z0ZzZzbdh2.z0uek(), z0ZzZzbdh2.z0iek()), p0.z0wrk);
					}
				}
				else
				{
					if (p0.z0guk != null)
					{
						if (flag3)
						{
							p0.z0guk.z0eek(c, z0ZzZzimk.z0yek(), color2, z0ZzZzbdh2.z0oek(), z0ZzZzbdh2.z0pek() + num, 0f);
						}
						else
						{
							p0.z0guk.z0eek(c, z0ZzZzrzj.z0btk, color2, z0ZzZzbdh2.z0oek(), z0ZzZzbdh2.z0pek() + num, z0ZzZzrzj.z0ytk);
						}
					}
					else if (p0.z0duk != null)
					{
						if (flag3)
						{
							p0.z0duk.z0dgk(c, z0buk, z0ZzZzimk.Name, z0ZzZzimk.Size, z0ZzZzimk.Style, color2, z0ZzZzbdh2.z0oek(), z0ZzZzbdh2.z0pek() + num, 0f, this);
						}
						else
						{
							p0.z0duk.z0dgk(c, z0buk, z0ZzZzrzj.z0vrk, z0ZzZzrzj.z0wtk, z0ZzZzrzj.z0prk, color2, z0ZzZzbdh2.z0oek(), z0ZzZzbdh2.z0pek() + num, z0ZzZzrzj.z0ytk, this);
						}
					}
					else
					{
						p0.z0gyk.z0eek(z0ZzZzqik.z0yek(c), z0ZzZzimk, color2, new z0ZzZzbdh(z0ZzZzbdh2.z0oek(), z0ZzZzbdh2.z0pek() + num, z0ZzZzbdh2.z0uek(), z0ZzZzbdh2.z0iek()), p0.z0wrk);
					}
					if (z0ZzZzrzj.z0yyk)
					{
						float num10 = z0ZzZzbdh2.z0pek() + p0.z0eek(z0ZzZzimk) / 2f;
						p0.z0gyk.z0tek(color2, z0ZzZzbdh2.z0oek(), num10, z0ZzZzbdh2.z0oek() + z0fik + z0lrk, num10);
					}
				}
			}
			if (z0ZzZzrzj.z0yyk)
			{
				float num11 = z0ZzZzbdh2.z0pek() + p0.z0eek(z0ZzZzimk) / 2f;
				p0.z0gyk.z0tek(color2, z0ZzZzbdh2.z0oek(), num11, z0ZzZzbdh2.z0oek() + z0fik + z0lrk, num11);
			}
		}
		else
		{
			z0ZzZzbdh z0ZzZzbdh3 = z0ZzZzjmk.z0tek(z0ZzZzbdh);
			float num12 = z0ZzZzbdh3.z0uek() * 0.1f;
			z0ZzZzbdh3.z0tek(num12, num12);
			z0ZzZzbdh3.z0tek(z0ZzZzbdh3.z0uek() - num12 * 2f);
			z0ZzZzbdh3.z0yek(z0ZzZzbdh3.z0iek() - num12 * 2f);
			if (!flag)
			{
				using z0ZzZzlsh z0ZzZzlsh = p0.z0suk.z0eek();
				z0ZzZzlsh.z0rek(StringAlignment.Center);
				z0ZzZzlsh.z0eek(StringAlignment.Center);
				p0.z0eek(flag2 ? z0ZzZzqik.z0yek(c) : text2, z0ZzZzrzj, z0ZzZzimk, color2, z0ZzZzbdh3, z0ZzZzlsh);
			}
			if (z0ZzZzrzj.z0yyk)
			{
				float num13 = z0ZzZzbdh2.z0pek() + num12 * 2f + p0.z0eek(z0ZzZzimk) / 2f;
				p0.z0gyk.z0tek(color2, z0ZzZzbdh2.z0oek(), num13, z0ZzZzbdh2.z0oek() + z0fik + z0lrk, num13);
			}
			switch (z0ZzZzrzj.z0yrk)
			{
			case CharacterCircleStyles.Circle:
				p0.z0gyk.z0tek(z0ZzZzrzj.z0bek, z0ZzZzbdh3);
				break;
			case CharacterCircleStyles.Rectangle:
				p0.z0gyk.z0rek(z0ZzZzrzj.z0bek, z0ZzZzbdh3.z0oek(), z0ZzZzbdh3.z0pek(), z0ZzZzbdh3.z0uek(), z0ZzZzbdh3.z0iek());
				break;
			}
		}
		if (z0ZzZzrzj.z0uyk)
		{
			p0.z0yyk.z0eek(this, p0, color, z0ZzZzbdh);
		}
		if (!z0ZzZzrzj.z0iyk)
		{
			return;
		}
		p0.z0gyk.z0rek();
		float num14 = p0.z0rrk;
		z0ZzZzbdh p4 = new z0ZzZzbdh(z0ZzZzbdh2.z0oek() + (z0fik - num14) / 2f, z0qyk().z0nek() + 1f, num14, num14);
		SmoothingMode p5 = p0.z0gyk.z0mek();
		p0.z0gyk.z0eek(SmoothingMode.HighQuality);
		if (color.ToArgb() == Color.Black.ToArgb())
		{
			p0.z0gyk.z0eek(z0ZzZzyfh.z0uek, p4);
		}
		else
		{
			using z0ZzZzzdh p6 = new z0ZzZzzdh(color);
			p0.z0gyk.z0eek(p6, p4);
		}
		p0.z0gyk.z0eek(p5);
	}

	public new char z0mek()
	{
		return z0bek;
	}

	internal void z0rek(StringBuilder p0)
	{
		if (z0tek((int)z0bek))
		{
			p0.Append(z0bek);
			p0.Append((char)z0frk);
		}
		else if (z0bek >= '\b')
		{
			p0.Append(z0bek);
		}
	}

	public override float z0pt()
	{
		return z0lrk;
	}

	public new float z0nek()
	{
		return z0hrk;
	}
}
