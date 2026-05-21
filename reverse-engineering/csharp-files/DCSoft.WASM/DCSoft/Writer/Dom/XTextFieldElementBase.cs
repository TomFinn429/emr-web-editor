using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using DCSoft.Drawing;
using DCSystem_Drawing;
using zzz;

namespace DCSoft.Writer.Dom;

[z0ZzZziqh("XField")]
[DebuggerDisplay("Field")]
public abstract class XTextFieldElementBase : XTextContainerElement
{
	internal class z0cpk : z0apk_jiejie20260327142557
	{
		public new DCBooleanValue z0eek = DCBooleanValue.Inherit;

		public new int z0rek;

		public new string z0tek;

		public int z0yek;

		public new string z0uek;

		public new z0ZzZzscj z0iek = (z0ZzZzscj)1;

		public new string z0oek;

		public new DCBooleanValue z0pek = DCBooleanValue.Inherit;

		public new DCBooleanValue z0mek = DCBooleanValue.Inherit;

		public new DCFastInputMode z0nek = DCFastInputMode.NextField;

		public new FormButtonStyle z0bek = FormButtonStyle.Auto;

		public new int z0vek;

		public new DCBooleanValueHasDefault z0cek = DCBooleanValueHasDefault.Default;

		public new Color z0xek = Color.Transparent;

		public new List<string> z0zek;

		public new Color z0lrk = Color.Transparent;

		public new InputFieldAdornTextType z0krk;

		public new DCVisibleState z0jrk = DCVisibleState.Default;

		public StringAlignment z0hrk;

		public Color z0grk = Color.Empty;

		public ContentViewEncryptType z0frk;

		public string z0drk;

		public int z0srk;

		public string z0ark;

		public z0ZzZzfvj z0qrk;

		public float z0wrk;

		public string z0erk;

		public DCBooleanValueHasDefault z0rrk = DCBooleanValueHasDefault.Default;

		public override void z0bwk()
		{
			base.z0bwk();
			z0uek = null;
			z0erk = null;
			z0drk = null;
			z0oek = null;
			z0ark = null;
			z0qrk = null;
			z0tek = null;
			if (z0zek != null)
			{
				z0zek.Clear();
				z0zek = null;
			}
		}

		public override z0apk_jiejie20260327142557 z0vwk()
		{
			z0cpk z0cpk = (z0cpk)base.z0vwk();
			if (z0qrk != null)
			{
				z0cpk.z0qrk = z0qrk.z0eek();
			}
			z0cpk.z0zek = null;
			return z0cpk;
		}
	}

	private new static readonly XTextElementList z0srk = new XTextElementList();

	[NonSerialized]
	protected internal new XTextFieldBorderElement z0ark;

	[NonSerialized]
	protected new XTextElement[] z0qrk;

	[NonSerialized]
	protected internal new XTextFieldBorderElement z0wrk;

	[z0ZzZzbjh(MemberEffectLevel.ElementView)]
	public Color BorderElementColor
	{
		get
		{
			if (z0utk != null)
			{
				return ((z0cpk)z0utk).z0grk;
			}
			return Color.Empty;
		}
		set
		{
			if (value == Color.Empty)
			{
				if (z0utk != null)
				{
					((z0cpk)z0utk).z0grk = value;
				}
			}
			else
			{
				z0lrk().z0grk = value;
			}
		}
	}

	[z0ZzZzbjh]
	[DefaultValue(DCBooleanValueHasDefault.Default)]
	public DCBooleanValueHasDefault LableUnitTextBold
	{
		get
		{
			if (z0utk != null)
			{
				return ((z0cpk)z0utk).z0cek;
			}
			return DCBooleanValueHasDefault.Default;
		}
		set
		{
			if (value == DCBooleanValueHasDefault.Default)
			{
				if (z0utk != null)
				{
					((z0cpk)z0utk).z0cek = value;
				}
			}
			else
			{
				z0lrk().z0cek = value;
			}
		}
	}

	[z0ZzZzbjh(MemberEffectLevel.ElementView)]
	public Color TextColor
	{
		get
		{
			if (z0utk != null)
			{
				return ((z0cpk)z0utk).z0xek;
			}
			return Color.Transparent;
		}
		set
		{
			if (value == Color.Transparent)
			{
				if (z0utk != null)
				{
					((z0cpk)z0utk).z0xek = value;
				}
			}
			else
			{
				z0lrk().z0xek = value;
			}
		}
	}

	[DefaultValue(null)]
	[z0ZzZzbjh(MemberEffectLevel.ElementLayout)]
	[z0ZzZzyqh]
	public string EndBorderText
	{
		get
		{
			if (z0utk != null)
			{
				return ((z0cpk)z0utk).z0erk;
			}
			return null;
		}
		set
		{
			if (value == null || value.Length == 0)
			{
				if (z0utk != null)
				{
					((z0cpk)z0utk).z0erk = null;
				}
			}
			else
			{
				z0lrk().z0erk = value;
			}
		}
	}

	[DefaultValue(false)]
	[z0ZzZzbjh]
	public bool EndingLineBreak
	{
		get
		{
			return z0cyk();
		}
		set
		{
			z0erk(value);
		}
	}

	[DefaultValue(null)]
	[z0ZzZzyqh]
	public string BorderElementColorValue
	{
		get
		{
			if (BorderElementColor.IsEmpty)
			{
				return null;
			}
			return z0ZzZzifh.z0eek(BorderElementColor);
		}
		set
		{
			if (string.IsNullOrEmpty(value))
			{
				BorderElementColor = Color.Empty;
			}
			else
			{
				BorderElementColor = z0ZzZzifh.z0eek(value);
			}
		}
	}

	[z0ZzZzbjh(MemberEffectLevel.ElementView)]
	public Color BackgroundTextColor
	{
		get
		{
			if (z0utk != null)
			{
				return ((z0cpk)z0utk).z0lrk;
			}
			return Color.Transparent;
		}
		set
		{
			if (value == Color.Transparent)
			{
				if (z0utk != null)
				{
					((z0cpk)z0utk).z0lrk = value;
				}
			}
			else
			{
				z0lrk().z0lrk = value;
			}
		}
	}

	[z0ZzZzyqh("TextColor")]
	[DefaultValue(null)]
	public string TextColorString
	{
		get
		{
			if (TextColor.A == 0)
			{
				return null;
			}
			return z0ZzZzlok.z0eek(TextColor);
		}
		set
		{
			if (string.IsNullOrEmpty(value))
			{
				TextColor = Color.Transparent;
			}
			else
			{
				TextColor = z0ZzZzlok.z0eek(value, Color.Transparent);
			}
		}
	}

	public override ElementType AcceptChildElementTypes2
	{
		get
		{
			if (z0utk != null)
			{
				return z0utk.z0tek;
			}
			return ElementType.All;
		}
		set
		{
			if (value == ElementType.All)
			{
				if (z0utk != null)
				{
					z0utk.z0tek = value;
				}
			}
			else
			{
				z0prk().z0tek = value;
			}
		}
	}

	[DefaultValue(null)]
	[z0ZzZzyqh("BackgroundTextColor")]
	public string BackgroundTextColorString
	{
		get
		{
			return z0ZzZzlok.z0eek(BackgroundTextColor, Color.Transparent);
		}
		set
		{
			BackgroundTextColor = z0ZzZzlok.z0eek(value, Color.Transparent);
		}
	}

	[DefaultValue(null)]
	[z0ZzZzyqh]
	[z0ZzZzbjh(MemberEffectLevel.ElementLayout)]
	public string StartBorderText
	{
		get
		{
			if (z0utk != null)
			{
				return ((z0cpk)z0utk).z0uek;
			}
			return null;
		}
		set
		{
			if (string.IsNullOrEmpty(value))
			{
				if (z0utk != null)
				{
					((z0cpk)z0utk).z0uek = null;
				}
			}
			else
			{
				z0lrk().z0uek = value;
			}
		}
	}

	public virtual bool z0so()
	{
		if (z0rik == null)
		{
			return true;
		}
		return z0iu().PrintBackgroundText;
	}

	public Color z0eek()
	{
		Color backgroundTextColor = BackgroundTextColor;
		if (backgroundTextColor.A == 0 && z0jr() != null)
		{
			return z0iu().BackgroundTextColor;
		}
		return backgroundTextColor;
	}

	public override XTextElement z0dek()
	{
		XTextElement xTextElement = z0ark;
		if (xTextElement == null)
		{
			return base.z0dek();
		}
		return xTextElement;
	}

	internal Color z0eek(DocumentViewOptions p0)
	{
		Color backgroundTextColor = BackgroundTextColor;
		if (backgroundTextColor.A == 0)
		{
			return p0.BackgroundTextColor;
		}
		return backgroundTextColor;
	}

	public virtual string z0ho()
	{
		return null;
	}

	internal override z0apk_jiejie20260327142557 z0fo()
	{
		return new z0cpk();
	}

	public void z0eek(DCBooleanValueHasDefault p0)
	{
		if (p0 == DCBooleanValueHasDefault.Default)
		{
			if (z0utk != null)
			{
				((z0cpk)z0utk).z0rrk = p0;
			}
		}
		else
		{
			z0lrk().z0rrk = p0;
		}
	}

	public XTextElementList z0rek()
	{
		XTextElementList xTextElementList = new XTextElementList();
		if (z0jrk() != null)
		{
			((zzz.z0ZzZzkuk<XTextElement>)xTextElementList).z0pek((XTextElement)z0jrk());
		}
		if (z0be().Count == 0)
		{
			if (z0qrk != null && z0qrk.Length != 0)
			{
				xTextElementList.z0trk(z0qrk);
			}
		}
		else
		{
			((zzz.z0ZzZzkuk<XTextElement>)xTextElementList).z0tek((zzz.z0ZzZzkuk<XTextElement>)z0be());
		}
		if (z0tek() != null)
		{
			((zzz.z0ZzZzkuk<XTextElement>)xTextElementList).z0pek((XTextElement)z0tek());
		}
		return xTextElementList;
	}

	public void z0eek(Color p0)
	{
	}

	public override int z0ue(z0eok_jiejie20260327142557 p0)
	{
		XTextElementList xTextElementList = p0.z0iek;
		XTextDocument xTextDocument = z0jr();
		int num = 0;
		bool flag = false;
		if (xTextDocument.z0tyk() && xTextDocument.z0iu().IgnoreFieldBorderWhenPrint)
		{
			flag = true;
		}
		XTextFieldBorderElement xTextFieldBorderElement = z0jrk();
		XTextFieldBorderElement xTextFieldBorderElement2 = z0tek();
		if (!flag && xTextFieldBorderElement != null)
		{
			xTextElementList.Add(xTextFieldBorderElement);
			num++;
		}
		int num2 = base.z0ue(p0);
		z0drk(num2 > 0);
		num += num2;
		if (!flag && xTextFieldBorderElement2 != null)
		{
			xTextElementList.Add(xTextFieldBorderElement2);
			num++;
		}
		xTextFieldBorderElement?.z0xek();
		xTextFieldBorderElement2?.z0xek();
		return num;
	}

	public override void z0mr(z0ZzZzvxj p0)
	{
		base.z0mr(p0);
		z0krk();
		if (z0wrk != null)
		{
			z0wrk.z0mr(p0);
		}
		if (z0ark != null)
		{
			z0ark.z0mr(p0);
		}
		z0yek();
		XTextElement[] array = z0qrk;
		if (array != null && array.Length != 0)
		{
			for (int num = array.Length - 1; num >= 0; num--)
			{
				array[num].z0mr(p0);
			}
		}
	}

	public void z0eek(XTextFieldBorderElement p0)
	{
		z0wrk = p0;
	}

	public XTextFieldBorderElement z0tek()
	{
		z0krk();
		if (z0ark != null)
		{
			z0ark.z0nu(this);
		}
		return z0ark;
	}

	internal new void z0yek()
	{
		((XTextElement)this).z0drk(p0: false);
		if (z0qrk != null)
		{
			return;
		}
		string text = z0ho();
		if (!string.IsNullOrEmpty(text))
		{
			XTextDocument document = z0rik;
			XTextElementList xTextElementList = z0srk;
			xTextElementList.Clear();
			xTextElementList.z0yrk(text.Length);
			string text2 = text;
			foreach (char c in text2)
			{
				if (c != '\r' || c != '\n')
				{
					XTextCharElement xTextCharElement = new XTextCharElement(c, this, document, z0buk);
					xTextCharElement.z0rek(p0: true);
					((zzz.z0ZzZzkuk<XTextElement>)xTextElementList).z0mek((XTextElement)xTextCharElement);
				}
			}
			z0qrk = xTextElementList.ToArray();
			xTextElementList.Clear();
		}
		else
		{
			z0qrk = XTextElement.z0zuk;
		}
	}

	public override void z0bt(XTextDocument p0)
	{
		if (z0rik != p0)
		{
			base.z0bt(p0);
			if (z0wrk != null)
			{
				z0wrk.z0bt(p0);
			}
			if (z0ark != null)
			{
				z0ark.z0bt(p0);
			}
		}
	}

	public override bool z0zy(z0ZzZzzhh p0)
	{
		if (z0jrk() != null && z0jrk().z0zy(p0))
		{
			return true;
		}
		if (z0tek() != null && z0tek().z0zy(p0))
		{
			return true;
		}
		if (!base.z0zy(p0))
		{
			if (z0be().Count == 0 && z0qrk != null && p0.z0eek().ForPrint && (z0so() || z0iu().PreserveBackgroundTextWhenPrint))
			{
				XTextElement[] array = z0qrk;
				for (int i = 0; i < array.Length; i++)
				{
					if (array[i].z0zy(p0))
					{
						return true;
					}
				}
			}
			return false;
		}
		return true;
	}

	internal new void z0uek()
	{
		((XTextElement)z0wrk)?.z0iek(z0buk);
		((XTextElement)z0ark)?.z0iek(z0buk);
		XTextElement[] array = z0qrk;
		if (array != null && array.Length != 0)
		{
			for (int num = array.Length - 1; num >= 0; num--)
			{
				array[num].z0iek(z0buk);
			}
		}
	}

	protected internal int z0eek(z0eok_jiejie20260327142557 p0)
	{
		return base.z0ue(p0);
	}

	public override float z0cw()
	{
		if (z0jrk() == null)
		{
			return 0f;
		}
		return z0jrk().z0cw();
	}

	public override void z0jo()
	{
		if (z0ji() == null || z0xu() || !z0yi())
		{
			return;
		}
		XTextDocument xTextDocument = z0jr();
		if (xTextDocument == null || xTextDocument.z0yyk() == null || z0qek() == null)
		{
			return;
		}
		z0ZzZzbdh p = z0ZzZzbdh.z0xek;
		XTextFieldBorderElement xTextFieldBorderElement = z0wrk;
		XTextFieldBorderElement xTextFieldBorderElement2 = z0ark;
		if (xTextFieldBorderElement != null && xTextFieldBorderElement2 != null && xTextFieldBorderElement.z0kik != null && xTextFieldBorderElement2.z0kik != null && xTextFieldBorderElement.z0kik.Count > 0 && xTextFieldBorderElement2.z0kik.Count > 0)
		{
			if (xTextFieldBorderElement.z0kik != xTextFieldBorderElement2.z0kik)
			{
				p = z0ZzZzbdh.z0yek(xTextFieldBorderElement.z0ptk().z0krk(), xTextFieldBorderElement2.z0ptk().z0krk());
				xTextDocument.z0yyk().z0eek(z0ZzZzndh.z0rek(p), z0qek().z0fu());
				return;
			}
			p = z0ZzZzbdh.z0yek(xTextFieldBorderElement.z0qyk(), xTextFieldBorderElement2.z0qyk());
		}
		XTextElementList xTextElementList = new XTextElementList();
		z0eok_jiejie20260327142557 z0eok_jiejie20260327142557 = new z0eok_jiejie20260327142557(xTextDocument, xTextElementList, p2: false);
		XTextContainerElement.z0btk = false;
		z0ue(z0eok_jiejie20260327142557);
		z0eok_jiejie20260327142557.Dispose();
		XTextContainerElement.z0btk = true;
		z0ZzZzzlh z0ZzZzzlh = null;
		foreach (XTextElement item in xTextElementList.z0xrk())
		{
			if (item.z0ptk() == null || item.z0ptk().Count <= 0)
			{
				continue;
			}
			z0ZzZzbdh z0ZzZzbdh = item.z0qyk();
			if (item.z0ptk() != z0ZzZzzlh)
			{
				z0ZzZzzlh = item.z0ptk();
				if (z0ZzZzzlh != null)
				{
					z0ZzZzbdh.z0rek(z0ZzZzzlh.z0xrk());
					z0ZzZzbdh.z0yek(z0ZzZzzlh.z0ytk());
				}
			}
			p = ((!p.z0bek()) ? z0ZzZzbdh.z0yek(p, z0ZzZzbdh) : z0ZzZzbdh);
		}
		xTextDocument.z0yyk()?.z0eek(z0ZzZzndh.z0rek(p), z0qek().z0fu());
	}

	public override void z0xi(bool p0)
	{
		base.z0xi(p0);
		if (z0wrk != null)
		{
			z0wrk.z0xi(p0);
		}
		if (z0ark != null)
		{
			z0ark.z0xi(p0);
		}
	}

	public new void z0iek()
	{
		if (z0qrk != null)
		{
			XTextElement[] array = z0qrk;
			for (int i = 0; i < array.Length; i++)
			{
				((XTextCharElement)array[i]).z0hrk = 1f;
			}
		}
	}

	public new string z0oek()
	{
		string startBorderText = StartBorderText;
		if (startBorderText != null && startBorderText.Length > 0 && z0ZzZzxcj.z0eek(165))
		{
			return startBorderText;
		}
		return null;
	}

	public override bool z0ao()
	{
		return base.z0ao();
	}

	public override bool z0hr()
	{
		XTextDocumentContentElement xTextDocumentContentElement = z0qek();
		if (xTextDocumentContentElement == null)
		{
			return false;
		}
		z0xek();
		int num = xTextDocumentContentElement.z0frk().z0bek(z0jrk());
		int num2 = xTextDocumentContentElement.z0frk().z0bek(z0tek());
		if (num >= 0 && num2 > 0)
		{
			z0jr().z0btk();
			xTextDocumentContentElement.z0uek(num, num2 - num + 1);
			if (xTextDocumentContentElement.z0frk().z0bek(z0jrk()) != num && num2 != xTextDocumentContentElement.z0frk().z0bek(z0tek()))
			{
				num = xTextDocumentContentElement.z0frk().z0bek(z0jrk());
				num2 = xTextDocumentContentElement.z0frk().z0bek(z0tek());
				if (num >= 0 && num2 > 0)
				{
					xTextDocumentContentElement.z0uek(num, num2 - num + 1);
				}
			}
			return true;
		}
		return base.z0hr();
	}

	public override XTextElement z0ie()
	{
		XTextElement xTextElement = z0wrk;
		if (xTextElement == null)
		{
			return base.z0ie();
		}
		return xTextElement;
	}

	public void z0eek(string p0)
	{
	}

	public override XTextElement z0lr(bool p0)
	{
		XTextFieldElementBase obj = (XTextFieldElementBase)base.z0lr(p0);
		obj.z0wrk = null;
		obj.z0ark = null;
		obj.z0qrk = null;
		return obj;
	}

	public override bool z0zu(XTextElement p0)
	{
		if (p0 == z0wrk || p0 == z0ark)
		{
			return true;
		}
		return base.z0zu(p0);
	}

	internal z0cpk z0pek_jiejie20260327142557()
	{
		return (z0cpk)z0utk;
	}

	public void z0rek(XTextFieldBorderElement p0)
	{
		z0ark = p0;
	}

	public virtual bool z0eek(XTextElement p0)
	{
		if (p0 is XTextCharElement)
		{
			return ((XTextCharElement)p0).z0oek();
		}
		return false;
	}

	protected void z0eek(XTextElement[] p0)
	{
		z0qrk = p0;
	}

	public new float z0mek()
	{
		return z0jrk()?.z0cw() ?? 0f;
	}

	public override void Dispose()
	{
		base.Dispose();
		z0zek();
		if (z0wrk != null)
		{
			z0wrk.Dispose();
			z0wrk = null;
		}
		if (z0ark != null)
		{
			z0ark.Dispose();
			z0ark = null;
		}
	}

	public new string z0nek()
	{
		string endBorderText = EndBorderText;
		if (endBorderText != null && endBorderText.Length > 0 && z0ZzZzxcj.z0eek(165))
		{
			return endBorderText;
		}
		return null;
	}

	public override XTextDocument z0jr()
	{
		return z0rik;
	}

	protected new XTextElement[] z0bek()
	{
		return z0qrk;
	}

	public override int z0je()
	{
		if (z0jrk() == null)
		{
			return -1;
		}
		return z0jrk().z0je();
	}

	internal new void z0vek()
	{
		if (z0wrk != null)
		{
			((XTextElement)z0wrk).z0oek(z0buk);
		}
		if (z0ark != null)
		{
			((XTextElement)z0ark).z0oek(z0buk);
		}
	}

	internal new void z0cek()
	{
		int p = z0buk;
		if (z0wrk != null)
		{
			((XTextElement)z0wrk).z0oek(p);
		}
		if (z0ark != null)
		{
			((XTextElement)z0ark).z0oek(p);
		}
		if (z0qrk != null)
		{
			XTextElement[] array = z0qrk;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].z0oek(p);
			}
		}
	}

	public new virtual bool z0xek()
	{
		XTextDocumentContentElement xTextDocumentContentElement = z0qek();
		if (xTextDocumentContentElement != null && xTextDocumentContentElement.z0frk().z0bek(z0jrk()) >= xTextDocumentContentElement.z0oek().z0lrk() && xTextDocumentContentElement.z0frk().z0bek(z0tek()) <= xTextDocumentContentElement.z0oek().z0drk())
		{
			return true;
		}
		return false;
	}

	private new void z0zek()
	{
		if (z0qrk != null)
		{
			XTextElement[] array = z0qrk;
			z0qrk = null;
			for (int num = array.Length - 1; num >= 0; num--)
			{
				array[num].Dispose();
			}
			Array.Clear(array);
		}
	}

	public override void z0li()
	{
		base.z0li();
		XTextDocument p = z0rik;
		if (z0wrk != null)
		{
			z0wrk.z0yek(p, this);
		}
		if (z0ark != null)
		{
			z0ark.z0yek(p, this);
		}
		if (z0qrk != null)
		{
			XTextElement[] array = z0qrk;
			for (int num = array.Length - 1; num >= 0; num--)
			{
				XTextElement obj = array[num];
				obj.z0yek(p, this);
				obj.z0buk = z0buk;
			}
		}
	}

	internal new z0cpk z0lrk()
	{
		if (z0utk == null)
		{
			z0utk = new z0cpk();
		}
		return (z0cpk)z0utk;
	}

	public bool z0rek(XTextElement p0)
	{
		if (z0ntk == null || z0ntk.Count == 0)
		{
			return true;
		}
		return false;
	}

	public override float z0he()
	{
		if (z0jrk() == null)
		{
			return 0f;
		}
		return z0jrk().z0he();
	}

	protected new virtual void z0krk()
	{
		if (z0wrk == null)
		{
			z0wrk = new XTextFieldBorderElement(this);
		}
		z0wrk.z0buk = z0buk;
		if (z0ark == null)
		{
			z0ark = new XTextFieldBorderElement(this);
		}
		z0ark.z0buk = z0buk;
	}

	public override void z0sr()
	{
		if (!z0ar(z0jr(), p1: false))
		{
			return;
		}
		if (z0jrk() != null)
		{
			XTextDocumentContentElement xTextDocumentContentElement = z0qek();
			if (z0jr().z0jrk() != xTextDocumentContentElement)
			{
				xTextDocumentContentElement.z0sr();
			}
			int num = z0jrk().z0jrk() + 1;
			xTextDocumentContentElement.z0frk().z0tek(num, p1: false);
			if (num != z0jrk().z0jrk() + 1)
			{
				num = z0jrk().z0jrk() + 1;
				xTextDocumentContentElement.z0frk().z0tek(num, p1: false);
			}
			if (z0jr().z0yyk() != null && z0jr().z0yyk().z0dpk())
			{
				z0jr().z0yyk().z0syk();
			}
		}
		else
		{
			base.z0sr();
		}
	}

	public new XTextFieldBorderElement z0jrk()
	{
		z0krk();
		if (z0wrk != null)
		{
			z0wrk.z0nu(this);
		}
		return z0wrk;
	}

	public new bool z0hrk()
	{
		XTextDocumentContentElement xTextDocumentContentElement = z0qek();
		int num = xTextDocumentContentElement.z0frk().IndexOf(z0jrk());
		int num2 = xTextDocumentContentElement.z0frk().IndexOf(z0tek());
		if (num >= 0 && num2 > 0)
		{
			xTextDocumentContentElement.z0uek(num + 1, num2 - num - 1);
			return true;
		}
		return base.z0hr();
	}

	public new string z0grk()
	{
		return Text;
	}

	public override void z0lo()
	{
		base.z0lo();
		z0uek();
	}

	public virtual bool z0tek(XTextElement p0)
	{
		XTextElement[] array = z0qrk;
		if (array != null && array.Length != 0)
		{
			return array.z0tek(p0);
		}
		return false;
	}

	public new float z0frk()
	{
		return z0jrk()?.z0he() ?? 0f;
	}

	public new DCBooleanValueHasDefault z0drk()
	{
		if (z0utk != null)
		{
			return ((z0cpk)z0utk).z0rrk;
		}
		return DCBooleanValueHasDefault.Default;
	}
}
