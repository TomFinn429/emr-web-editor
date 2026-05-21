using System;
using System.ComponentModel;
using System.Diagnostics;
using DCSoft.Drawing;
using DCSoft.WinForms;
using DCSystem_Drawing;
using zzz;

namespace DCSoft.Writer.Dom;

[DebuggerDisplay("TDBarcode:{Name}")]
[z0ZzZziqh("XTDBarcodeField")]
public sealed class XTextTDBarcodeElement : XTextLabelElementBase
{
	private new DCTBErroeCorrectionLevelType z0rek = DCTBErroeCorrectionLevelType.M;

	private new DCTDBarcodeType z0tek;

	private new VerticalAlignStyle z0yek = VerticalAlignStyle.Bottom;

	[z0ZzZzbjh(MemberEffectLevel.ElementView)]
	[DefaultValue(DCTDBarcodeType.QR)]
	public DCTDBarcodeType BarcodeType
	{
		get
		{
			return z0tek;
		}
		set
		{
			z0tek = value;
		}
	}

	[DefaultValue(DCTBErroeCorrectionLevelType.M)]
	[z0ZzZzbjh(MemberEffectLevel.ElementView)]
	public DCTBErroeCorrectionLevelType ErroeCorrectionLevel
	{
		get
		{
			return z0rek;
		}
		set
		{
			z0rek = value;
		}
	}

	[DefaultValue(VerticalAlignStyle.Bottom)]
	[z0ZzZzbjh(MemberEffectLevel.ElementView)]
	public VerticalAlignStyle VAlign
	{
		get
		{
			return z0yek;
		}
		set
		{
			z0yek = value;
		}
	}

	public override bool z0wy()
	{
		return false;
	}

	private static sbyte[][] z0eek(sbyte[][] p0)
	{
		int num = p0[0].Length;
		int num2 = p0.Length;
		int num3 = 0;
		int num4 = Math.Min(num, num2) / 2 - 2;
		for (int i = 0; i < num4; i++)
		{
			bool flag = false;
			for (int j = 0; j < num; j++)
			{
				if (p0[i][j] == 0 || p0[num2 - i - 1][j] == 0)
				{
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				for (int k = 0; k < num2; k++)
				{
					if (p0[k][i] == 0 || p0[k][num - i - 1] == 0)
					{
						flag = true;
						break;
					}
				}
			}
			if (flag)
			{
				num3 = Math.Max(num3, i - 1);
				break;
			}
		}
		if (num3 > 0)
		{
			sbyte[][] array = new sbyte[num2 - num3 * 2][];
			for (int l = 0; l < array.Length; l++)
			{
				sbyte[] array2 = (array[l] = new sbyte[num - num3 * 2]);
				Array.Copy(p0[l + num3], num3, array2, 0, array2.Length);
			}
			return array;
		}
		return p0;
	}

	public XTextTDBarcodeElement()
	{
		Width = 100f;
		Height = 100f;
	}

	public static object z0eek(DCTDBarcodeType p0, DCTBErroeCorrectionLevelType p1, string p2, ref int p3, ref int p4, int p5)
	{
		if (string.IsNullOrEmpty(p2))
		{
			return null;
		}
		z0ZzZzyij z0ZzZzyij = new z0ZzZzyij();
		z0ZzZzmuj p6 = null;
		if (p0 == DCTDBarcodeType.QR)
		{
			p6 = z0ZzZzmuj.z0yek;
			switch (p1)
			{
			case DCTBErroeCorrectionLevelType.L:
				z0ZzZzyij.z0eek(z0ZzZzhij.z0uek);
				break;
			case DCTBErroeCorrectionLevelType.M:
				z0ZzZzyij.z0eek(z0ZzZzhij.z0tek);
				break;
			case DCTBErroeCorrectionLevelType.Q:
				z0ZzZzyij.z0eek(z0ZzZzhij.z0oek);
				break;
			case DCTBErroeCorrectionLevelType.H:
				z0ZzZzyij.z0eek(z0ZzZzhij.z0iek);
				break;
			}
		}
		z0ZzZzcdh z0ZzZzcdh = new z0ZzZzcdh(0, 0);
		z0ZzZzcdh = ((p5 != 0) ? z0ZzZzyij.z0eek(p2, p6, p3, p4) : z0ZzZzyij.z0eek(p2, p6, 0, 0));
		p3 = z0ZzZzcdh.z0rek();
		p4 = z0ZzZzcdh.z0tek();
		if (p5 == 0)
		{
			return z0ZzZzyij.z0rek(p2, p6, p3, p4);
		}
		_ = 1;
		return null;
	}

	public override void z0sy(ElementMouseEventArgs p0)
	{
		base.z0sy(p0);
		if (p0.Button == (z0ZzZzqeh)1 && z0bu().DesignMode && z0jr().z0yyk().z0eek("ElementProperties", p1: true, this) != null)
		{
			p0.Handled = true;
		}
	}

	public override void z0et(ResizeableType p0)
	{
	}

	private static void z0eek(z0ZzZzvxj p0, sbyte[][] p1, z0ZzZzbdh p2)
	{
		if (p1 == null)
		{
			return;
		}
		sbyte[][] array = z0eek(p1);
		int num = array[0].Length;
		int num2 = array.Length;
		z0ZzZzbdh p3 = z0ZzZzjmk.z0eek(p2, (float)num * 1f / (float)num2);
		if (p3.z0bek() || !p0.z0nek().z0tek(p3))
		{
			return;
		}
		for (int i = 0; i < num2; i++)
		{
			for (int j = 0; j < num; j++)
			{
				if (array[i][j] == 0)
				{
					z0ZzZzbdh p4 = new z0ZzZzbdh(p3.z0oek() + p3.z0uek() * (float)j / (float)num, p3.z0pek() + p3.z0iek() * (float)i / (float)num2, 0f + p3.z0uek() / (float)num, 0f + p3.z0iek() / (float)num2);
					if (p0.z0gyk.z0lrk() != null)
					{
						p0.z0gyk.z0lrk().z0eek(Color.Black, p4.z0oek(), p4.z0pek(), p4.z0uek(), p4.z0iek());
					}
					else if (p0.z0duk != null)
					{
						p0.z0gyk.z0frk().z0chk(Color.Black, p4.z0oek(), p4.z0pek(), p4.z0uek(), p4.z0iek());
					}
					else
					{
						p0.z0gyk.z0rek(Color.Black, p4);
					}
				}
			}
		}
	}

	public override void z0vw(z0ZzZzvxj p0)
	{
		string text = z0eek(p0.z0oek());
		if (!string.IsNullOrEmpty(text))
		{
			int p2;
			int p1 = (p2 = Math.Min(z0jr().z0grk(z0ork()), z0jr().z0grk(z0si())));
			sbyte[][] p3 = (sbyte[][])z0eek(BarcodeType, ErroeCorrectionLevel, text, ref p2, ref p1, 0);
			z0eek(p0, p3, p0.z0gtk);
		}
	}

	public override VerticalAlignStyle z0ay()
	{
		return VAlign;
	}

	public override ResizeableType z0wt()
	{
		return ResizeableType.WidthAndHeight;
	}

	public override string z0ge()
	{
		return "TDBarcode:" + ID;
	}
}
