using System;
using DCSoft.Drawing;
using DCSystem_Drawing;
using zzz;

namespace DCSoft.Writer.Dom;

public class XTextFieldBorderElement : XTextElement
{
	private class z0zmk
	{
		public float z0eek;

		public float z0rek;

		public float z0tek;

		public float z0yek;

		public float z0uek;

		public float z0iek;

		public z0ZzZzbdh z0oek;
	}

	internal new float z0hrk;

	private new z0zmk z0grk;

	private new static z0ZzZzlsh z0frk = null;

	public static float z0drk_jiejie20260327142557 = 4f;

	private new static readonly float z0ark = 49f;

	[z0ZzZzuqh]
	public override string Text
	{
		get
		{
			if (z0uik is XTextInputFieldElementBase xTextInputFieldElementBase)
			{
				if (((XTextFieldElementBase)xTextInputFieldElementBase).z0ark == this)
				{
					return xTextInputFieldElementBase.z0jrk();
				}
				if (xTextInputFieldElementBase.z0wrk == this)
				{
					return xTextInputFieldElementBase.z0srk();
				}
			}
			return null;
		}
		set
		{
			throw new NotSupportedException("XTextFieldBorderElement.set_Text");
		}
	}

	private Color z0eek(DocumentViewOptions p0)
	{
		XTextFieldElementBase xTextFieldElementBase = (XTextFieldElementBase)z0ji();
		Color result = xTextFieldElementBase.BorderElementColor;
		if (result.A == 0)
		{
			result = Color.Blue;
			if (p0.FieldBorderColor.A != 0)
			{
				result = p0.FieldBorderColor;
			}
			else if (xTextFieldElementBase.z0sek())
			{
				result = p0.ReadonlyFieldBorderColor;
			}
			else if (xTextFieldElementBase is XTextInputFieldElement)
			{
				result = (((XTextInputFieldElementBase)(XTextInputFieldElement)xTextFieldElementBase).z0krk() ? p0.NormalFieldBorderColor : p0.UnEditableFieldBorderColor);
			}
		}
		if (result.A == 0)
		{
			result = Color.Blue;
		}
		return result;
	}

	public override z0ZzZzpdh z0zw()
	{
		float num = 0f;
		float num2 = 0f;
		if (z0kik == null)
		{
			return new z0ZzZzpdh(z0xik, z0wik);
		}
		z0ZzZzpdh z0ZzZzpdh = z0kik.z0yek();
		num = z0xik + z0ZzZzpdh.z0rek();
		num2 = z0wik + z0ZzZzpdh.z0tek();
		return new z0ZzZzpdh(num, num2);
	}

	public override void z0mu(DocumentEventArgs p0)
	{
		if (p0.Style == DocumentEventStyles.MouseClick)
		{
			if (z0oek() != FormButtonStyle.None && p0.Button == (z0ZzZzqeh)1)
			{
				z0ZzZzbdh z0ZzZzbdh = z0lrk();
				z0jo();
				if (z0ZzZzbdh.z0eek(p0.ViewX, p0.ViewY))
				{
					z0jr().z0yyk().z0eek(z0ji(), p1: false, ValueEditorActiveMode.F2, p3: false, p4: true);
					p0.Cursor = z0ZzZzbwh.z0krk;
					p0.Handled = true;
					p0.CancelBubble = true;
				}
			}
		}
		else if ((p0.Style == DocumentEventStyles.MouseMove || p0.Style == DocumentEventStyles.MouseDown || p0.Style == DocumentEventStyles.MouseUp) && z0oek() != FormButtonStyle.None && z0lrk().z0eek(p0.ViewX, p0.ViewY))
		{
			p0.Cursor = z0ZzZzbwh.z0krk;
			p0.Handled = true;
			p0.CancelBubble = true;
		}
	}

	public Color z0eek()
	{
		return z0eek(z0iu());
	}

	public void z0eek(float p0)
	{
		if (p0 == 3.125f)
		{
			if (z0grk != null)
			{
				z0grk.z0eek = 3.125f;
			}
		}
		else
		{
			z0jrk().z0eek = p0;
		}
	}

	public override bool z0ar(XTextDocument p0, bool p1)
	{
		if (z0uik == null)
		{
			return false;
		}
		return z0uik.z0ar(p0, p1);
	}

	public override string z0ge()
	{
		string text = z0gy();
		if (string.IsNullOrEmpty(text))
		{
			return "[FieldBorder]" + z0mek();
		}
		return text;
	}

	internal XTextFieldBorderElement(XTextFieldElementBase parent)
	{
		z0yek(((XTextElement)parent).z0drk(), parent);
	}

	public XTextFieldElementBase z0rek()
	{
		return z0uik as XTextFieldElementBase;
	}

	public void z0rek(float p0)
	{
		if (p0 == 0f)
		{
			if (z0grk != null)
			{
				z0grk.z0yek = 0f;
			}
		}
		else
		{
			z0jrk().z0yek = p0;
		}
	}

	public override void z0mt(float p0)
	{
		z0hrk = p0;
	}

	public float z0tek()
	{
		if (z0grk != null)
		{
			return z0grk.z0eek;
		}
		return 3.125f;
	}

	public new float z0yek()
	{
		if (z0grk != null)
		{
			return z0grk.z0iek;
		}
		return 0f;
	}

	public new float z0uek()
	{
		if (z0grk != null)
		{
			return z0grk.z0rek;
		}
		return 3.125f;
	}

	internal new float z0iek()
	{
		return z0ark;
	}

	private new FormButtonStyle z0oek()
	{
		if (z0ji() is XTextInputFieldElement xTextInputFieldElement && ((XTextFieldElementBase)xTextInputFieldElement).z0ark == this)
		{
			return xTextInputFieldElement.z0ark();
		}
		return FormButtonStyle.None;
	}

	public override float z0pt()
	{
		return z0hrk;
	}

	internal new string z0pek()
	{
		if (z0ji() is XTextInputFieldElementBase xTextInputFieldElementBase)
		{
			if (z0mek() == (z0ZzZzzvj)0)
			{
				return xTextInputFieldElementBase.z0srk();
			}
			return xTextInputFieldElementBase.z0jrk();
		}
		return null;
	}

	public void z0eek(bool p0)
	{
		z0vek(p0);
	}

	public override XTextElement z0ku()
	{
		return z0ji();
	}

	public override float z0he()
	{
		if (z0kik == null)
		{
			return 0f;
		}
		return z0xik + z0kik.z0xtk();
	}

	public void z0tek(float p0)
	{
		if (p0 == 3.125f)
		{
			if (z0grk != null)
			{
				z0grk.z0rek = 3.125f;
			}
		}
		else
		{
			z0jrk().z0rek = p0;
		}
	}

	public override void z0bt(XTextDocument p0)
	{
		z0rik = p0;
	}

	public new z0ZzZzzvj z0mek()
	{
		if (((XTextFieldElementBase)z0uik).z0wrk == this)
		{
			return (z0ZzZzzvj)0;
		}
		return (z0ZzZzzvj)1;
	}

	public new void z0yek(float p0)
	{
		if (p0 == 0f)
		{
			if (z0grk != null)
			{
				z0grk.z0tek = 0f;
			}
		}
		else
		{
			z0jrk().z0tek = p0;
		}
	}

	internal new void z0uek(float p0)
	{
		if (base.Width != p0)
		{
			z0fik = p0;
		}
	}

	internal new bool z0nek()
	{
		if (z0ji() is XTextInputFieldElementBase xTextInputFieldElementBase)
		{
			if (z0mek() == (z0ZzZzzvj)0)
			{
				string text = xTextInputFieldElementBase.z0srk();
				if (text != null)
				{
					return text.Length > 0;
				}
				return false;
			}
			string text2 = xTextInputFieldElementBase.z0jrk();
			if (text2 != null)
			{
				return text2.Length > 0;
			}
			return false;
		}
		return false;
	}

	public new float z0bek()
	{
		if (z0grk != null)
		{
			return z0grk.z0uek;
		}
		return 0f;
	}

	public override float z0lu()
	{
		return Math.Max(Width, 12.5f);
	}

	public override XTextDocument z0ee_jiejie20260327142557(bool p0)
	{
		return null;
	}

	internal new string z0vek()
	{
		if (z0uik is XTextFieldElementBase xTextFieldElementBase)
		{
			if (this == xTextFieldElementBase.z0wrk)
			{
				return xTextFieldElementBase.z0oek();
			}
			if (this == xTextFieldElementBase.z0ark)
			{
				return xTextFieldElementBase.z0nek();
			}
		}
		return null;
	}

	public new float z0cek()
	{
		if (z0grk != null)
		{
			return z0grk.z0tek;
		}
		return 0f;
	}

	public void z0eek(z0ZzZzbdh p0)
	{
		if (p0.z0bek())
		{
			if (z0grk != null)
			{
				z0grk.z0oek = z0ZzZzbdh.z0xek;
			}
		}
		else
		{
			z0jrk().z0oek = p0;
		}
	}

	public override void z0vw(z0ZzZzvxj p0)
	{
		XTextDocument xTextDocument = z0jr();
		XTextFieldElementBase xTextFieldElementBase = z0rek();
		if (xTextFieldElementBase == null)
		{
			return;
		}
		bool p1 = false;
		if (p0.z0byk == (z0ZzZzcxj)5)
		{
			if (z0ZzZzafh.z0iek(Text) || z0ZzZzafh.z0iek(z0vek()))
			{
				XTextCharElement.z0zek = true;
				p1 = true;
			}
			if (p0.z0nrk)
			{
				return;
			}
		}
		DocumentViewOptions documentViewOptions = p0.z0rtk;
		float num = p0.z0gtk.z0oek();
		float p2 = p0.z0gtk.z0pek();
		z0ZzZzbdh z0ZzZzbdh = new z0ZzZzbdh(num, p2, z0fik + z0hrk, Height);
		if (p0.z0mtk)
		{
			z0ZzZzbdh.z0eek(z0ZzZzbdh.z0tek() + 3f);
			z0ZzZzbdh.z0tek(z0ZzZzbdh.z0uek() - 3f);
		}
		p0.z0yyk.z0eek(this, p0, z0ZzZzbdh);
		z0ZzZzbdh.z0tek(Width);
		z0ZzZzbdh.z0rek(z0ZzZzbdh.z0yek() + p0.z0ark);
		if (p0.z0mtk)
		{
			p0.z0mtk = false;
			z0ZzZzbdh.z0eek(z0ZzZzbdh.z0tek() + 3f);
			z0ZzZzbdh.z0tek(z0ZzZzbdh.z0uek() - 3f);
		}
		int num2 = 0;
		num2 = ((xTextFieldElementBase.z0wrk != this) ? 1 : 0);
		bool showFieldBorderTextInTheMiddle = documentViewOptions.ShowFieldBorderTextInTheMiddle;
		switch (num2)
		{
		case 0:
			if (showFieldBorderTextInTheMiddle)
			{
				z0ZzZzbdh.z0eek(z0ZzZzbdh.z0mek() - z0uek());
			}
			z0ZzZzbdh.z0tek(z0uek());
			break;
		case 1:
			if (!showFieldBorderTextInTheMiddle)
			{
				z0ZzZzbdh.z0eek(z0ZzZzbdh.z0mek() - z0uek());
			}
			z0ZzZzbdh.z0tek(z0uek());
			break;
		}
		FormButtonStyle formButtonStyle = z0oek();
		if (formButtonStyle != FormButtonStyle.None && (!documentViewOptions.ShowFormButton || p0.z0byk != 0))
		{
			formButtonStyle = FormButtonStyle.None;
		}
		bool flag = false;
		if (documentViewOptions.ShowFieldBorderElement && p0.z0byk == (z0ZzZzcxj)0)
		{
			flag = true;
		}
		float num3 = 0f;
		if (formButtonStyle != FormButtonStyle.None)
		{
			num3 = xTextDocument.z0xek(16f);
		}
		DCRenderVisibility dCRenderVisibility = documentViewOptions.z0eek_jiejie20260327142557();
		if (!flag && p0.z0byk == (z0ZzZzcxj)3 && dCRenderVisibility == DCRenderVisibility.Visible)
		{
			flag = true;
		}
		z0ZzZzrzj z0ZzZzrzj = z0aek();
		z0ZzZzbdh z0ZzZzbdh2 = new z0ZzZzbdh(num + z0zek(), z0ZzZzbdh.z0pek(), 0f, z0yek() * 1.5f);
		switch (num2)
		{
		case 0:
			if (showFieldBorderTextInTheMiddle)
			{
				z0ZzZzbdh2.z0eek(num);
			}
			else
			{
				z0ZzZzbdh2.z0tek(3.125f, 0f);
			}
			break;
		case 1:
			if (formButtonStyle == FormButtonStyle.None)
			{
				if (showFieldBorderTextInTheMiddle)
				{
					z0ZzZzbdh2.z0eek(num + Width - z0bek());
				}
				else
				{
					z0ZzZzbdh2.z0eek(num + Width - z0uek() - z0bek());
				}
			}
			else if (showFieldBorderTextInTheMiddle)
			{
				z0ZzZzbdh2.z0eek(num + Width - z0bek());
			}
			else
			{
				z0ZzZzbdh2.z0eek(num);
			}
			break;
		}
		if (z0yek() <= 0f)
		{
			z0ZzZzbdh2.z0rek(z0ZzZzbdh.z0pek());
		}
		string text = Text;
		if (text != null && text.Length > 0)
		{
			z0ZzZzbdh2.z0tek(z0bek());
			if (z0frk == null)
			{
				z0frk = new z0ZzZzlsh(p0.z0suk);
				z0frk.z0rek(StringAlignment.Center);
				z0frk.z0eek(z0frk.z0yek() | (z0ZzZzksh)4096);
			}
			p0.z0gyk.z0eek(text, z0eek(xTextFieldElementBase, z0ZzZzrzj.z0pek, p1), z0ZzZzrzj.z0bek, new z0ZzZzbdh(z0ZzZzbdh2.z0oek(), z0ZzZzbdh2.z0pek() + z0cek(), z0ZzZzbdh2.z0uek(), z0ZzZzbdh2.z0iek() - z0cek()), z0frk);
		}
		if (formButtonStyle != FormButtonStyle.None)
		{
			bool p3 = false;
			if (xTextFieldElementBase.z0de())
			{
				p3 = true;
			}
			z0ZzZzbdh z0ZzZzbdh3 = new z0ZzZzbdh(z0ZzZzbdh.z0mek() - num3 - 1f - z0uek(), z0ZzZzbdh2.z0pek(), num3, num3);
			if (showFieldBorderTextInTheMiddle)
			{
				z0ZzZzbdh3.z0eek(z0ZzZzbdh.z0oek() + 1f);
			}
			if (z0ZzZzbdh3.z0iek() > z0ZzZzbdh.z0iek() - 1f)
			{
				z0ZzZzbdh3.z0yek(z0ZzZzbdh.z0iek() - 1f);
			}
			if (z0ji() is XTextInputFieldElementBase)
			{
				switch (((XTextInputFieldElementBase)z0ji()).z0oek())
				{
				case (z0ZzZzscj)0:
					z0ZzZzbdh3.z0rek(z0ZzZzbdh.z0pek());
					break;
				case (z0ZzZzscj)1:
					z0ZzZzbdh3.z0rek(z0ZzZzbdh.z0pek() + (z0ZzZzbdh.z0iek() - z0ZzZzbdh3.z0iek()) / 2f);
					break;
				case (z0ZzZzscj)2:
					z0ZzZzbdh3.z0rek(z0ZzZzbdh.z0nek() - z0ZzZzbdh3.z0iek() - 3f);
					break;
				case (z0ZzZzscj)4:
					z0ZzZzbdh3.z0rek(z0ZzZzbdh.z0pek());
					break;
				case (z0ZzZzscj)3:
					z0ZzZzbdh3.z0rek(z0ZzZzbdh.z0nek() - z0ZzZzbdh3.z0iek() - 3f);
					break;
				}
				if (z0ZzZzbdh3.z0nek() > z0ZzZzbdh.z0nek() - 5f)
				{
					z0ZzZzbdh3.z0rek(z0ZzZzbdh.z0nek() - z0ZzZzbdh3.z0iek() - 5f);
				}
			}
			z0eek(z0ZzZzbdh3);
			z0ZzZzwpk.z0eek(p0.z0gyk, z0ZzZzbdh3, formButtonStyle, p3);
		}
		if (!flag)
		{
			return;
		}
		z0ZzZzbdh p4 = z0ZzZzbdh;
		Color color = z0eek(p0.z0rtk);
		if (string.IsNullOrEmpty(z0vek()))
		{
			bool flag2 = true;
			if (xTextFieldElementBase is XTextInputFieldElementBase)
			{
				XTextInputFieldElementBase xTextInputFieldElementBase = (XTextInputFieldElementBase)xTextFieldElementBase;
				if (xTextInputFieldElementBase.BorderVisible == DCVisibleState.Hidden)
				{
					flag2 = false;
				}
				else if (xTextInputFieldElementBase.BorderVisible == DCVisibleState.Default && !documentViewOptions.ShowFieldBorderElement)
				{
					flag2 = false;
				}
			}
			if (flag2)
			{
				if (p0.z0byk == (z0ZzZzcxj)3)
				{
					if (dCRenderVisibility != DCRenderVisibility.Visible)
					{
						flag2 = false;
					}
				}
				else if (p0.z0byk != 0)
				{
					flag2 = false;
				}
			}
			if (flag2)
			{
				bool flag3 = false;
				if (p0.z0byk == (z0ZzZzcxj)3 && dCRenderVisibility == DCRenderVisibility.Visible)
				{
					flag3 = true;
				}
				else
				{
					flag3 = !p0.z0cyk || p0.z0eek(xTextFieldElementBase) || p0.z0kuk.z0drk(xTextFieldElementBase);
					if (!flag3 && xTextFieldElementBase is XTextInputFieldElement && ((XTextInputFieldElement)xTextFieldElementBase).BorderVisible == DCVisibleState.AlwaysVisible)
					{
						flag3 = true;
					}
				}
				if (flag3)
				{
					z0ZzZzpdh[] array = new z0ZzZzpdh[4];
					float num4 = p4.z0uek() * 0.2f;
					switch (num2)
					{
					case 0:
						array[0].z0eek(p4.z0mek());
						array[0].z0rek(p4.z0pek());
						array[1].z0eek(p4.z0oek() + num4);
						array[1].z0rek(p4.z0pek());
						array[2].z0eek(p4.z0oek() + num4);
						array[2].z0rek(p4.z0nek());
						array[3].z0eek(p4.z0mek());
						array[3].z0rek(p4.z0nek());
						if (showFieldBorderTextInTheMiddle)
						{
							float num5 = z0zek();
							ref z0ZzZzpdh reference = ref array[0];
							reference.z0eek(reference.z0rek() + num5);
							ref z0ZzZzpdh reference2 = ref array[1];
							reference2.z0eek(reference2.z0rek() + num5);
							ref z0ZzZzpdh reference3 = ref array[2];
							reference3.z0eek(reference3.z0rek() + num5);
							ref z0ZzZzpdh reference4 = ref array[3];
							reference4.z0eek(reference4.z0rek() + num5);
						}
						break;
					case 1:
						array[0].z0eek(p4.z0oek());
						array[0].z0rek(p4.z0pek());
						array[1].z0eek(p4.z0mek() - num4);
						array[1].z0rek(p4.z0pek());
						array[2].z0eek(p4.z0mek() - num4);
						array[2].z0rek(p4.z0nek());
						array[3].z0eek(p4.z0oek());
						array[3].z0rek(p4.z0nek());
						break;
					}
					using z0ZzZzudh p5 = new z0ZzZzudh(color);
					p0.z0gyk.z0eek(p5, array);
				}
			}
		}
		else
		{
			using z0ZzZzlsh z0ZzZzlsh = p0.z0yyk.z0nek().z0eek();
			z0ZzZzlsh.z0rek(StringAlignment.Near);
			z0ZzZzlsh.z0eek(StringAlignment.Near);
			z0ZzZzlsh.z0eek((z0ZzZzksh)4096);
			if (z0ji() is XTextInputFieldElementBase xTextInputFieldElementBase2)
			{
				switch (xTextInputFieldElementBase2.z0oek())
				{
				case (z0ZzZzscj)0:
					z0ZzZzlsh.z0eek(StringAlignment.Near);
					break;
				case (z0ZzZzscj)1:
					z0ZzZzlsh.z0eek(StringAlignment.Center);
					break;
				case (z0ZzZzscj)2:
					z0ZzZzlsh.z0eek(StringAlignment.Far);
					break;
				case (z0ZzZzscj)4:
					if (xTextFieldElementBase.z0jrk() == this)
					{
						z0ZzZzlsh.z0eek(StringAlignment.Far);
					}
					else
					{
						z0ZzZzlsh.z0eek(StringAlignment.Near);
					}
					break;
				case (z0ZzZzscj)3:
					if (xTextFieldElementBase.z0jrk() == this)
					{
						z0ZzZzlsh.z0eek(StringAlignment.Near);
					}
					else
					{
						z0ZzZzlsh.z0eek(StringAlignment.Far);
					}
					break;
				}
			}
			p0.z0gyk.z0eek(z0vek(), z0eek(xTextFieldElementBase, xTextFieldElementBase.z0aek().z0pek, p1), color, p4, z0ZzZzlsh);
		}
		if (p0.z0byk != 0 || !(z0ji() is XTextInputFieldElement xTextInputFieldElement) || ((XTextFieldElementBase)xTextInputFieldElement).z0tek() != this || !xTextInputFieldElement.z0tek())
		{
			return;
		}
		float num6 = z0jr().z0xek(4f);
		z0ZzZzbdh p6 = new z0ZzZzbdh(z0ZzZzbdh.z0mek() - num6, z0ZzZzbdh.z0nek() - num6, num6, num6);
		Color empty = Color.Empty;
		empty = (xTextInputFieldElement.z0sek() ? documentViewOptions.TagColorForReadonlyField : ((((XTextContainerElement)xTextInputFieldElement).z0frk() != null) ? documentViewOptions.TagColorForValueInvalidateField : ((!xTextInputFieldElement.Modified) ? documentViewOptions.TagColorForNormalField : documentViewOptions.TagColorForModifiedField)));
		if (empty.A == 0)
		{
			return;
		}
		using z0ZzZzzdh p7 = new z0ZzZzzdh(empty);
		p0.z0gyk.z0rek(p7, p6);
	}

	public new void z0iek(float p0)
	{
		if (p0 == 0f)
		{
			if (z0grk != null)
			{
				z0grk.z0uek = 0f;
			}
		}
		else
		{
			z0jrk().z0uek = p0;
		}
	}

	internal new void z0xek()
	{
		if (!z0krk())
		{
			if (z0uik is XTextFieldElementBase xTextFieldElementBase && !xTextFieldElementBase.z0fi() && string.IsNullOrEmpty(Text) && string.IsNullOrEmpty(z0vek()))
			{
				z0fik = 12.5f;
			}
			else
			{
				z0fik = z0tek();
			}
		}
	}

	public override float z0ut()
	{
		return z0fik + z0hrk;
	}

	public new float z0zek()
	{
		if (z0grk != null)
		{
			return z0grk.z0yek;
		}
		return 0f;
	}

	public override void z0mr(z0ZzZzvxj p0)
	{
		z0oek(0f);
		z0yek(0f);
		z0rek(0f);
		z0ZzZzxdh z0ZzZzxdh = z0ZzZzxdh.z0yek;
		DocumentViewOptions documentViewOptions = p0.z0rtk;
		z0tek(documentViewOptions.FieldBorderElementPixelWidth * p0.z0otk);
		FormButtonStyle formButtonStyle = z0oek();
		string text = Text;
		string text2 = z0vek();
		DCRenderVisibility dCRenderVisibility = documentViewOptions.z0eek_jiejie20260327142557();
		if (!string.IsNullOrEmpty(text) || !string.IsNullOrEmpty(text2))
		{
			if (!string.IsNullOrEmpty(text2))
			{
				bool flag = true;
				if (p0.z0byk == (z0ZzZzcxj)3)
				{
					if (dCRenderVisibility == DCRenderVisibility.Hidden || dCRenderVisibility == DCRenderVisibility.Visible)
					{
						flag = true;
					}
					else if (documentViewOptions.IgnoreFieldBorderWhenPrint)
					{
						flag = false;
					}
				}
				else if (!documentViewOptions.ShowFieldBorderElement)
				{
					flag = false;
				}
				if (flag)
				{
					z0ZzZzrzj z0ZzZzrzj = z0aek();
					z0ZzZzxdh z0ZzZzxdh2 = z0ZzZzlcj.z0rek(p0.z0gyk.z0vek(), text2, z0ZzZzrzj.z0btk);
					z0tek(z0ZzZzxdh2.z0rek());
					Height = p0.z0eek(z0ZzZzrzj);
					z0rek(z0ZzZzxdh2.z0rek());
					z0ZzZzxdh.z0rek(Height);
				}
			}
			float num = z0uek();
			if (z0ZzZzxdh.z0tek() <= 0f)
			{
				Height = 1f;
			}
			else
			{
				Height = z0ZzZzxdh.z0tek();
			}
			z0eek(0f);
			if (text != null && text.Length > 0)
			{
				z0ZzZzrzj z0ZzZzrzj2 = z0aek();
				z0ZzZzxdh z0ZzZzxdh3 = z0ZzZzlcj.z0rek(p0.z0gyk.z0vek(), text, z0eek(z0rek(), z0ZzZzrzj2.z0pek, p2: false).Value);
				z0iek(z0ZzZzxdh3.z0rek());
				z0oek(p0.z0eek(z0ZzZzrzj2));
				num += z0ZzZzxdh3.z0rek();
				Height = Math.Max(Height, z0yek());
			}
			if (formButtonStyle != FormButtonStyle.None && documentViewOptions.ShowFormButton)
			{
				num += p0.z0otk * 18f;
			}
			Width = num;
		}
		else
		{
			float num2 = z0uek();
			if (formButtonStyle != FormButtonStyle.None && documentViewOptions.ShowFormButton)
			{
				num2 += p0.z0otk * 18f;
			}
			Width = num2;
		}
		z0xi(p0: false);
		z0eek(Width);
	}

	public new z0ZzZzbdh z0lrk()
	{
		if (z0grk != null)
		{
			return z0grk.z0oek;
		}
		return z0ZzZzbdh.z0xek;
	}

	public new void z0oek(float p0)
	{
		if (p0 == 0f)
		{
			if (z0grk != null)
			{
				z0grk.z0iek = 0f;
			}
		}
		else
		{
			z0jrk().z0iek = p0;
		}
	}

	public override string z0gy()
	{
		if (z0jr() != null && z0bu().OutputFieldBorderTextToContentText)
		{
			if (z0mek() == (z0ZzZzzvj)0)
			{
				return z0vek() + Text;
			}
			return Text + z0vek();
		}
		return Text;
	}

	public new bool z0krk()
	{
		return z0urk();
	}

	public override float z0cw()
	{
		if (z0kik == null)
		{
			return z0wik;
		}
		return z0wik + z0kik.z0xrk();
	}

	public override XTextDocument z0jr()
	{
		if (z0rik != null)
		{
			return z0rik;
		}
		if (z0uik != null)
		{
			return ((XTextElement)z0uik).z0drk();
		}
		return null;
	}

	public override void Dispose()
	{
		base.Dispose();
		z0grk = null;
	}

	private new z0zmk z0jrk()
	{
		if (z0grk == null)
		{
			z0grk = new z0zmk();
		}
		return z0grk;
	}

	private static z0ZzZzimk z0eek(XTextFieldElementBase p0, z0ZzZzimk p1, bool p2)
	{
		if (p0.LableUnitTextBold == DCBooleanValueHasDefault.True)
		{
			if (!p1.Bold)
			{
				z0ZzZzimk z0ZzZzimk = p1.Clone();
				z0ZzZzimk.Bold = true;
				if (p2)
				{
					return z0ZzZzafh.z0yek(z0ZzZzimk);
				}
				return z0ZzZzimk;
			}
		}
		else if (p0.LableUnitTextBold == DCBooleanValueHasDefault.False && p1.Bold)
		{
			z0ZzZzimk z0ZzZzimk2 = p1.Clone();
			z0ZzZzimk2.Bold = false;
			if (p2)
			{
				return z0ZzZzafh.z0yek(z0ZzZzimk2);
			}
			return z0ZzZzimk2;
		}
		return p1;
	}

	public override bool z0zy(z0ZzZzzhh p0)
	{
		if (base.z0zy(p0) && (!string.IsNullOrEmpty(Text) || !string.IsNullOrEmpty(z0vek())))
		{
			return true;
		}
		return false;
	}

	public override string ToString()
	{
		if (z0mek() == (z0ZzZzzvj)0)
		{
			return "【";
		}
		if (z0mek() == (z0ZzZzzvj)1)
		{
			return "】";
		}
		return "FieldBorder";
	}
}
