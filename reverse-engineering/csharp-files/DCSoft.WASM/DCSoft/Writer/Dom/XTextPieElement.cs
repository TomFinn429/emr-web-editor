using System;
using System.ComponentModel;
using DCSoft.WinForms;
using DCSystem_Drawing;
using zzz;

namespace DCSoft.Writer.Dom;

[z0ZzZziqh("XPie")]
public class XTextPieElement : XTextObjectElement
{
	private new string z0yek;

	private new string z0uek;

	[NonSerialized]
	private new bool z0iek = true;

	private new string z0oek;

	private new ResizeableType z0pek = ResizeableType.WidthAndHeight;

	private new string z0mek;

	private new DCPieDataItemList z0nek;

	private new string z0bek;

	private new string z0vek;

	private new string z0cek;

	private new z0ZzZzztk z0xek = new z0ZzZzztk();

	[NonSerialized]
	private new z0ZzZzlyk z0zek;

	private new string z0lrk;

	[DefaultValue(null)]
	public string DataFieldNameForText
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
	public bool StateInvalidate
	{
		get
		{
			return z0iek;
		}
		set
		{
			z0iek = value;
		}
	}

	[DefaultValue(null)]
	public string DataFieldNameForFillColorString
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

	[DefaultValue(null)]
	public string DataFieldNameForValue
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

	[DefaultValue(null)]
	public string DataFieldNameForLink
	{
		get
		{
			return z0uek;
		}
		set
		{
			z0uek = value;
		}
	}

	[DefaultValue(null)]
	public string DataSourceName
	{
		get
		{
			return z0mek;
		}
		set
		{
			z0mek = value;
		}
	}

	[DefaultValue(null)]
	public z0ZzZzztk PieDocumentStyle
	{
		get
		{
			if (z0xek == null)
			{
				z0xek = new z0ZzZzztk();
			}
			return z0xek;
		}
		set
		{
			z0xek = value;
		}
	}

	[DefaultValue(null)]
	public string DataFieldNameForSeriesName
	{
		get
		{
			return z0cek;
		}
		set
		{
			z0cek = value;
		}
	}

	[DefaultValue(null)]
	public string DataFieldNameForGroupName
	{
		get
		{
			return z0lrk;
		}
		set
		{
			z0lrk = value;
		}
	}

	[DefaultValue(null)]
	public string DataFieldNameForTipText
	{
		get
		{
			return z0vek;
		}
		set
		{
			z0vek = value;
		}
	}

	[z0ZzZzrqh("DataItem", typeof(DCPieDataItem))]
	[DefaultValue(null)]
	public DCPieDataItemList DataItems
	{
		get
		{
			return z0nek;
		}
		set
		{
			z0nek = value;
		}
	}

	private new z0ZzZzlyk z0eek()
	{
		if (z0zek == null)
		{
			z0zek = new z0ZzZzlyk();
		}
		z0zek.z0eek(PieDocumentStyle);
		if (z0zek.z0yek() == null)
		{
			z0zek.z0eek(new z0ZzZzjyk());
		}
		if (StateInvalidate)
		{
			StateInvalidate = false;
			z0zek.z0yek().Clear();
			StateInvalidate = true;
			if (DataItems != null && DataItems.Count > 0)
			{
				foreach (DCPieDataItem dataItem in DataItems)
				{
					z0ZzZzkyk z0ZzZzkyk = new z0ZzZzkyk();
					z0ZzZzkyk.z0eek(z0zek);
					z0ZzZzkyk.z0yek(dataItem.Text);
					z0ZzZzkyk.z0eek(dataItem.Value);
					z0ZzZzkyk.z0tek(dataItem.Link);
					z0zek.z0yek().Add(z0ZzZzkyk);
				}
			}
		}
		return z0zek;
	}

	public override z0ZzZzpmk z0ny()
	{
		z0ZzZzxdh z0ZzZzxdh = z0ZzZzrpk.z0eek(new z0ZzZzxdh(Width, Height), GraphicsUnit.Document, GraphicsUnit.Pixel);
		z0ZzZzrfh p = new z0ZzZzrfh((int)z0ZzZzxdh.z0rek(), (int)z0ZzZzxdh.z0tek());
		using (z0ZzZzadh z0ZzZzadh = z0ZzZzadh.z0eek(p))
		{
			z0ZzZzadh.z0eek(GraphicsUnit.Document);
			z0ZzZzadh.z0eek(Color.Transparent);
			z0ZzZzbdh z0ZzZzbdh = new z0ZzZzbdh(0f, 0f, Width, Height);
			z0ZzZzlyk z0ZzZzlyk = z0eek();
			if (z0ZzZzbdh.z0rek(z0ZzZzlyk.z0eek(), z0ZzZzbdh))
			{
				z0ZzZzlyk.z0eek(z0ZzZzbdh);
				StateInvalidate = true;
			}
			z0ZzZzjpk p2 = new z0ZzZzjpk(z0ZzZzadh);
			if (StateInvalidate)
			{
				z0ZzZzlyk.z0iek(p2);
			}
			z0ZzZzlyk.z0eek(p2, z0ZzZzbdh);
		}
		return new z0ZzZzpmk(p);
	}

	public new void z0rek()
	{
		AddDataItem("第一块", 43.0);
		AddDataItem("第二块", 25.0);
		AddDataItem("第三块", 35.0);
		AddDataItem("第四块", 45.0);
	}

	public XTextPieElement()
	{
		Width = 400f;
		Height = 400f;
		PieDocumentStyle.z0vek().z0rek(50f);
		PieDocumentStyle.z0pek().z0eek(120f);
		PieDocumentStyle.z0pek().z0eek(p0: true);
	}

	public override ResizeableType z0wt()
	{
		if (z0yek())
		{
			return ResizeableType.FixSize;
		}
		return z0pek;
	}

	internal new virtual bool z0tek()
	{
		return true;
	}

	public override void z0vw(z0ZzZzvxj p0)
	{
		z0ZzZzlyk z0ZzZzlyk = z0eek();
		if (z0ZzZzbdh.z0rek(z0ZzZzlyk.z0eek(), p0.z0drk()))
		{
			z0ZzZzlyk.z0eek(p0.z0drk());
			StateInvalidate = true;
		}
		if (StateInvalidate)
		{
			z0ZzZzlyk.z0iek(p0.z0gyk);
		}
		if (p0.z0duk != null)
		{
			p0.z0duk.z0mhk(ID, z0ZzZzbdh.z0xek, null, 0f, FontStyle.Regular, p5: true);
			z0ZzZzlyk.z0eek(p0.z0gyk, p0.z0nek());
			p0.z0duk.z0thk();
		}
		else
		{
			z0ZzZzlyk.z0eek(p0.z0gyk, p0.z0nek());
		}
	}

	public void AddDataItem(string text, double Value)
	{
		if (z0nek == null)
		{
			z0nek = new DCPieDataItemList();
		}
		DCPieDataItem dCPieDataItem = new DCPieDataItem();
		dCPieDataItem.Text = text;
		dCPieDataItem.Value = Value;
		z0nek.Add(dCPieDataItem);
		z0iek = true;
	}

	public override void z0et(ResizeableType p0)
	{
		z0pek = p0;
	}
}
