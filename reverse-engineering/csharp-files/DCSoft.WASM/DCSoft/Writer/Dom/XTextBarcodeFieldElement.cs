using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using DCSystem_Drawing;
using zzz;

namespace DCSoft.Writer.Dom;

[DebuggerDisplay("Barcode:{Name}")]
[z0ZzZziqh("XBarcodeField")]
public sealed class XTextBarcodeFieldElement : XTextShapeInputFieldElement
{
	[NonSerialized]
	private new z0ZzZzwrk z0rek;

	private new StringAlignment z0tek = StringAlignment.Center;

	private new string z0yek;

	private new z0ZzZzrrk z0uek = (z0ZzZzrrk)30;

	private new bool z0iek = true;

	private new float z0oek = 7f;

	[z0ZzZzbjh(MemberEffectLevel.ElementLayout)]
	[DefaultValue((z0ZzZzrrk)30)]
	public z0ZzZzrrk BarcodeStyle
	{
		get
		{
			return z0uek;
		}
		set
		{
			z0uek = value;
			z0rek = null;
		}
	}

	[z0ZzZzbjh(MemberEffectLevel.ElementView)]
	[DefaultValue(true)]
	public bool ShowText
	{
		get
		{
			return z0iek;
		}
		set
		{
			z0iek = value;
			z0rek = null;
		}
	}

	[z0ZzZzuqh]
	[z0ZzZzbjh(MemberEffectLevel.DOM)]
	public override string FormulaValue
	{
		get
		{
			return Text;
		}
		set
		{
			Text = z0uek(value);
			z0jo();
		}
	}

	[DefaultValue(7f)]
	[z0ZzZzbjh(MemberEffectLevel.ElementLayout)]
	public float MinBarWidth
	{
		get
		{
			return z0oek;
		}
		set
		{
			z0oek = value;
		}
	}

	[z0ZzZzbjh(MemberEffectLevel.ElementView)]
	[DefaultValue(StringAlignment.Center)]
	public StringAlignment TextAlignment
	{
		get
		{
			return z0tek;
		}
		set
		{
			z0tek = value;
			z0rek = null;
		}
	}

	public override void z0vw(z0ZzZzvxj p0)
	{
		z0ro(p0: true);
		z0ZzZzrzj z0ZzZzrzj = z0aek();
		z0ZzZzbdh z0ZzZzbdh = z0qyk();
		float num = 0f;
		if (ShowText)
		{
			num = z0ZzZzrzj.z0pek.z0eek(p0.z0gyk);
		}
		List<z0ZzZzbdh> list = z0rek.z0eek(new z0ZzZzbdh(z0ZzZzbdh.z0oek(), z0ZzZzbdh.z0pek(), z0ZzZzbdh.z0uek(), z0ZzZzbdh.z0iek() - num));
		if (list != null && list.Count > 0)
		{
			foreach (z0ZzZzbdh item in list)
			{
				p0.z0gyk.z0rek(z0ZzZzrzj.z0bek, item);
			}
			if (ShowText && !string.IsNullOrEmpty(z0rek.z0eek()))
			{
				z0ZzZzlsh z0ZzZzlsh = new z0ZzZzlsh();
				z0ZzZzlsh.z0rek(StringAlignment.Center);
				z0ZzZzlsh.z0eek(StringAlignment.Center);
				z0ZzZzlsh.z0eek((z0ZzZzksh)4096);
				p0.z0gyk.z0eek(z0rek.z0eek(), new z0ZzZzimk(), z0ZzZzrzj.z0bek, new z0ZzZzbdh(z0ZzZzbdh.z0oek(), z0ZzZzbdh.z0nek() - num, z0ZzZzbdh.z0uek(), num), z0ZzZzlsh);
			}
		}
		else if (!string.IsNullOrEmpty(z0rek.z0mek()))
		{
			z0ZzZzlsh z0ZzZzlsh2 = new z0ZzZzlsh();
			z0ZzZzlsh2.z0eek((z0ZzZzksh)4096);
			z0ZzZzlsh2.z0rek(StringAlignment.Center);
			z0ZzZzlsh2.z0eek(StringAlignment.Center);
			p0.z0gyk.z0eek(z0rek.z0mek(), z0ZzZzrzj.z0pek, z0ZzZzrzj.z0bek, new z0ZzZzbdh(z0ZzZzbdh.z0oek(), z0ZzZzbdh.z0nek() - num, z0ZzZzbdh.z0uek(), num), z0ZzZzlsh2);
		}
	}

	public XTextBarcodeFieldElement()
	{
		Height = 125f;
	}

	public override XTextElement z0lr(bool p0)
	{
		XTextBarcodeFieldElement obj = (XTextBarcodeFieldElement)base.z0lr(p0);
		obj.z0rek = null;
		return obj;
	}

	public override void Dispose()
	{
		base.Dispose();
		z0rek = null;
		z0yek = null;
	}

	public override void z0ro(bool p0)
	{
		if (z0rek == null)
		{
			z0rek = new z0ZzZzwrk();
			z0rek.z0eek(z0kek() - 1);
		}
		if (z0rek.z0yek() != z0kek())
		{
			z0rek.z0eek(Text);
			z0rek.z0eek(BarcodeStyle);
			z0rek.z0eek(ShowText);
			z0rek.z0eek(z0jr().z0xek(3f));
			z0rek.z0eek(z0kek());
			z0xi(p0: true);
		}
		if (p0)
		{
			z0rek.z0eek(ShowText);
			z0rek.z0eek(MinBarWidth);
			z0rek.z0eek(z0aek().z0pek);
		}
		if (p0 && z0ao())
		{
			if (z0rek.z0vek())
			{
				Width = z0rek.z0pek();
				if (Height == 0f)
				{
					Height = z0jr().z0xek(40f);
				}
			}
			z0xi(p0: false);
		}
		if (Width <= 0f)
		{
			Width = 100f;
		}
	}

	public new string z0eek()
	{
		return z0yek;
	}

	public new void z0eek(string p0)
	{
		z0yek = p0;
	}

	public override string z0pe()
	{
		return "barcode";
	}

	public override string z0ge()
	{
		return "Barcode:" + ID;
	}
}
