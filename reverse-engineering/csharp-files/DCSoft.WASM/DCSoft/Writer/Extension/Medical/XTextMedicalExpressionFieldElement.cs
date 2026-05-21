using System;
using System.ComponentModel;
using System.Diagnostics;
using DCSoft.Drawing;
using DCSoft.Writer.Dom;
using DCSoft.Writer.MedicalExpression;
using zzz;

namespace DCSoft.Writer.Extension.Medical;

[z0ZzZziqh("XMedicalExpressionField")]
[DebuggerDisplay("Medical expression:{Name}")]
public class XTextMedicalExpressionFieldElement : XTextShapeInputFieldElement
{
	[z0ZzZzuqh]
	public new string z0eek;

	[NonSerialized]
	private new z0ZzZznjh z0rek;

	private new bool z0tek = true;

	private new VerticalAlignStyle z0yek = VerticalAlignStyle.Middle;

	private new DCMedicalExpressionStyle z0uek = DCMedicalExpressionStyle.FourValues;

	[DefaultValue(null)]
	public string InnerSerializeText
	{
		get
		{
			return Text;
		}
		set
		{
			z0eek = value;
		}
	}

	[DefaultValue(DCMedicalExpressionStyle.FourValues)]
	public DCMedicalExpressionStyle ExpressionStyle
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

	[DefaultValue(VerticalAlignStyle.Middle)]
	public virtual VerticalAlignStyle VAlign
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

	[DefaultValue(true)]
	public bool EditValueInDialog
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

	public override void z0ro(bool p0)
	{
		if (z0rek == null)
		{
			z0rek = new z0ZzZznjh();
			z0rek.z0eek(z0kek() - 1);
		}
		if (z0rek.z0eek() != z0kek())
		{
			z0rek.z0eek(z0kek());
			z0rek.z0eek(ExpressionStyle);
			string text = Text;
			if (text != null && text.Length > 0)
			{
				string[] array = text.Split(',', ';', '，');
				z0rek.z0eek(new MedicalExpressionValueList());
				if (z0rek.z0pek() == DCMedicalExpressionStyle.PermanentTeethBitmap)
				{
					for (int i = 0; i < array.Length; i++)
					{
						switch (array[i])
						{
						case "18":
							z0rek.z0iek().Value1 = "8";
							break;
						case "17":
							z0rek.z0iek().Value2 = "7";
							break;
						case "16":
							z0rek.z0iek().Value3 = "6";
							break;
						case "15":
							z0rek.z0iek().Value4 = "5";
							break;
						case "14":
							z0rek.z0iek().Value5 = "4";
							break;
						case "13":
							z0rek.z0iek().Value6 = "3";
							break;
						case "12":
							z0rek.z0iek().Value7 = "2";
							break;
						case "11":
							z0rek.z0iek().Value8 = "1";
							break;
						case "21":
							z0rek.z0iek().Value9 = "1";
							break;
						case "22":
							z0rek.z0iek().Value10 = "2";
							break;
						case "23":
							z0rek.z0iek().Value11 = "3";
							break;
						case "24":
							z0rek.z0iek().Value12 = "4";
							break;
						case "25":
							z0rek.z0iek().Value13 = "5";
							break;
						case "26":
							z0rek.z0iek().Value14 = "6";
							break;
						case "27":
							z0rek.z0iek().Value15 = "7";
							break;
						case "28":
							z0rek.z0iek().Value16 = "8";
							break;
						case "48":
							z0rek.z0iek().Value17 = "8";
							break;
						case "47":
							z0rek.z0iek().Value18 = "7";
							break;
						case "46":
							z0rek.z0iek().Value19 = "6";
							break;
						case "45":
							z0rek.z0iek().Value20 = "5";
							break;
						case "44":
							z0rek.z0iek().Value21 = "4";
							break;
						case "43":
							z0rek.z0iek().Value22 = "3";
							break;
						case "42":
							z0rek.z0iek().Value23 = "2";
							break;
						case "41":
							z0rek.z0iek().Value24 = "1";
							break;
						case "31":
							z0rek.z0iek().Value25 = "1";
							break;
						case "32":
							z0rek.z0iek().Value26 = "2";
							break;
						case "33":
							z0rek.z0iek().Value27 = "3";
							break;
						case "34":
							z0rek.z0iek().Value28 = "4";
							break;
						case "35":
							z0rek.z0iek().Value29 = "5";
							break;
						case "36":
							z0rek.z0iek().Value30 = "6";
							break;
						case "37":
							z0rek.z0iek().Value31 = "7";
							break;
						case "38":
							z0rek.z0iek().Value32 = "8";
							break;
						}
					}
				}
				else if (z0rek.z0pek() == DCMedicalExpressionStyle.DeciduousTeech)
				{
					for (int j = 0; j < array.Length; j++)
					{
						switch (array[j])
						{
						case "15":
							z0rek.z0iek().Value1 = "V";
							break;
						case "14":
							z0rek.z0iek().Value2 = "IV";
							break;
						case "13":
							z0rek.z0iek().Value3 = "III";
							break;
						case "12":
							z0rek.z0iek().Value4 = "II";
							break;
						case "11":
							z0rek.z0iek().Value5 = "I";
							break;
						case "21":
							z0rek.z0iek().Value6 = "I";
							break;
						case "22":
							z0rek.z0iek().Value7 = "II";
							break;
						case "23":
							z0rek.z0iek().Value8 = "III";
							break;
						case "24":
							z0rek.z0iek().Value9 = "IV";
							break;
						case "25":
							z0rek.z0iek().Value10 = "V";
							break;
						case "45":
							z0rek.z0iek().Value11 = "V";
							break;
						case "44":
							z0rek.z0iek().Value12 = "IV";
							break;
						case "43":
							z0rek.z0iek().Value13 = "III";
							break;
						case "42":
							z0rek.z0iek().Value14 = "II";
							break;
						case "41":
							z0rek.z0iek().Value15 = "I";
							break;
						case "31":
							z0rek.z0iek().Value16 = "I";
							break;
						case "32":
							z0rek.z0iek().Value17 = "II";
							break;
						case "33":
							z0rek.z0iek().Value18 = "III";
							break;
						case "34":
							z0rek.z0iek().Value19 = "IV";
							break;
						case "35":
							z0rek.z0iek().Value20 = "V";
							break;
						}
					}
				}
				else
				{
					if (array.Length != 0)
					{
						z0rek.z0iek().Value1 = array[0];
					}
					if (array.Length > 1)
					{
						z0rek.z0iek().Value2 = array[1];
					}
					if (array.Length > 2)
					{
						z0rek.z0iek().Value3 = array[2];
					}
					if (array.Length > 3)
					{
						z0rek.z0iek().Value4 = array[3];
					}
					if (array.Length > 4)
					{
						z0rek.z0iek().Value5 = array[4];
					}
					if (array.Length > 5)
					{
						z0rek.z0iek().Value6 = array[5];
					}
					if (array.Length > 6)
					{
						z0rek.z0iek().Value7 = array[6];
					}
					if (array.Length > 7)
					{
						z0rek.z0iek().Value8 = array[7];
					}
					if (array.Length > 8)
					{
						z0rek.z0iek().Value9 = array[8];
					}
				}
			}
			z0xi(p0: true);
		}
		z0ZzZzrzj z0ZzZzrzj = z0aek();
		if (p0)
		{
			z0rek.z0eek(z0ZzZzrzj.z0pek);
			z0rek.z0eek(z0ZzZzrzj.z0bek);
		}
		if (!p0 || !z0ao())
		{
			return;
		}
		using z0ZzZzjpk p1 = z0ru();
		z0rek.z0eek(z0ZzZzrzj.z0pek);
		z0rek.z0eek(z0ZzZzrzj.z0bek);
		z0ZzZzxdh z0ZzZzxdh = z0rek.z0eek(p1);
		z0xi(p0: false);
		if (Width == 0f)
		{
			Width = z0ZzZzxdh.z0rek();
			Height = z0ZzZzxdh.z0tek();
		}
	}

	public override void z0dw(DocumentEventArgs p0)
	{
		if (!z0jr().z0xek().z0np(this))
		{
			p0.Handled = true;
		}
	}

	public override XTextElement z0lr(bool p0)
	{
		XTextMedicalExpressionFieldElement obj = (XTextMedicalExpressionFieldElement)base.z0lr(p0);
		obj.z0rek = null;
		obj.z0eek = null;
		return obj;
	}

	public override void z0vw(z0ZzZzvxj p0)
	{
		z0ro(p0: true);
		z0rek.z0eek(p0.z0gyk, z0myk_jiejie20260327142557());
	}

	public override VerticalAlignStyle z0fw()
	{
		return VAlign;
	}
}
