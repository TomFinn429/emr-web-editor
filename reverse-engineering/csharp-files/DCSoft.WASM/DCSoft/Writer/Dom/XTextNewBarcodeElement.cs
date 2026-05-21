using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using DCSystem_Drawing;
using zzz;

namespace DCSoft.Writer.Dom;

[DebuggerDisplay("NewBarcode:{Name}")]
[z0ZzZziqh("NewBarcode")]
public sealed class XTextNewBarcodeElement : XTextLabelElementBase
{
	private new DCBarcodeStyle z0eek = DCBarcodeStyle.Code128C;

	private new bool z0rek = true;

	private new StringAlignment z0tek = StringAlignment.Center;

	[DefaultValue(StringAlignment.Center)]
	[z0ZzZzbjh(MemberEffectLevel.ElementView)]
	public StringAlignment TextAlignment
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

	[DefaultValue(true)]
	[z0ZzZzbjh(MemberEffectLevel.ElementView)]
	public bool ShowText
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

	[z0ZzZzbjh(MemberEffectLevel.ElementLayout)]
	[DefaultValue(DCBarcodeStyle.Code128C)]
	public DCBarcodeStyle BarcodeStyle2
	{
		get
		{
			return z0eek;
		}
		set
		{
			z0eek = value;
		}
	}

	public override string z0ge()
	{
		return "Barcode:" + ID;
	}

	public override void z0sy(ElementMouseEventArgs p0)
	{
		base.z0sy(p0);
		if (p0.Button == (z0ZzZzqeh)1 && z0jr().z0bu().DesignMode && z0jr().z0yyk().z0eek("ElementProperties", p1: true, this) != null)
		{
			p0.Handled = true;
		}
	}

	public override bool z0wy()
	{
		return false;
	}

	public override string z0pe()
	{
		return "barcode";
	}

	public override void z0vw(z0ZzZzvxj p0)
	{
		z0ZzZzwrk z0ZzZzwrk = new z0ZzZzwrk();
		z0ZzZzwrk.z0rek(p0: true);
		z0ZzZzwrk.z0eek(z0eek(p0.z0oek()));
		z0ZzZzwrk.z0eek((z0ZzZzrrk)BarcodeStyle2);
		z0ZzZzwrk.z0eek(z0rek);
		z0ZzZzrzj z0ZzZzrzj = z0aek();
		z0ZzZzwrk.z0eek(z0ZzZzrzj.z0pek);
		z0ZzZzwrk.z0eek(z0tek);
		z0ZzZzbdh z0ZzZzbdh = z0qyk();
		float num = 0f;
		if (z0rek)
		{
			num = z0ZzZzrzj.z0pek.z0eek(p0.z0gyk);
		}
		List<z0ZzZzbdh> list = z0ZzZzwrk.z0eek(new z0ZzZzbdh(z0ZzZzbdh.z0oek(), z0ZzZzbdh.z0pek(), z0ZzZzbdh.z0uek(), z0ZzZzbdh.z0iek() - num));
		if (list != null && list.Count > 0)
		{
			Color p1 = z0ZzZzrzj.z0bek;
			foreach (z0ZzZzbdh item in list)
			{
				if (p0.z0guk != null)
				{
					p0.z0guk.z0eek(p1, item.z0oek(), item.z0pek(), item.z0uek(), item.z0iek());
				}
				else if (p0.z0duk != null)
				{
					p0.z0duk.z0chk(p1, item.z0oek(), item.z0pek(), item.z0uek(), item.z0iek());
				}
				else
				{
					p0.z0gyk.z0rek(p1, item);
				}
			}
			if (z0rek && !string.IsNullOrEmpty(z0ZzZzwrk.z0eek()))
			{
				z0ZzZzlsh z0ZzZzlsh = new z0ZzZzlsh();
				z0ZzZzlsh.z0rek(z0tek);
				z0ZzZzlsh.z0eek(StringAlignment.Center);
				z0ZzZzlsh.z0eek((z0ZzZzksh)4096);
				p0.z0gyk.z0eek(z0ZzZzwrk.z0eek(), z0ZzZzrzj.z0pek, z0ZzZzrzj.z0bek, new z0ZzZzbdh(z0ZzZzbdh.z0oek(), z0ZzZzbdh.z0nek() - num, z0ZzZzbdh.z0uek(), num), z0ZzZzlsh);
			}
		}
		else if (!string.IsNullOrEmpty(z0ZzZzwrk.z0mek()))
		{
			z0ZzZzlsh z0ZzZzlsh2 = new z0ZzZzlsh();
			z0ZzZzlsh2.z0eek((z0ZzZzksh)4096);
			z0ZzZzlsh2.z0rek(StringAlignment.Near);
			z0ZzZzlsh2.z0eek(StringAlignment.Center);
			p0.z0gyk.z0eek(z0ZzZzwrk.z0mek(), z0ZzZzrzj.z0pek, z0ZzZzrzj.z0bek, new z0ZzZzbdh(z0ZzZzbdh.z0oek(), z0ZzZzbdh.z0nek() - num, z0ZzZzbdh.z0uek(), num), z0ZzZzlsh2);
		}
	}

	public XTextNewBarcodeElement()
	{
		Height = 150f;
		Width = 400f;
	}
}
