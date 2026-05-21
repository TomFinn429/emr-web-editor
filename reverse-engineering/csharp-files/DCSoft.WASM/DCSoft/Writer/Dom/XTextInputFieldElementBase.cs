using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using DCSoft.Data;
using DCSystem_Drawing;
using zzz;

namespace DCSoft.Writer.Dom;

[z0ZzZziqh("XInputFieldBase")]
[DebuggerDisplay("Base Input Name:{Name}")]
[Obfuscation(Exclude = true, ApplyToMembers = false)]
public abstract class XTextInputFieldElementBase : XTextFieldElementBase, z0ZzZztxj
{
	private new float z0wrk;

	private new z0ZzZzsok z0erk;

	private new EnableState z0rrk = EnableState.Enabled;

	[NonSerialized]
	private new int z0trk;

	[NonSerialized]
	[z0ZzZzuqh]
	public new static EventHandler z0yrk;

	private new string z0urk;

	private new string z0irk;

	private new string z0ork;

	[NonSerialized]
	private new int z0prk = -1;

	private new z0ZzZzukh z0mrk;

	private new string z0nrk;

	private new MoveFocusHotKeys z0brk = MoveFocusHotKeys.Default;

	[z0ZzZzbjh]
	[DefaultValue(0)]
	public int TabIndex
	{
		get
		{
			if (z0utk != null)
			{
				return ((z0cpk)z0utk).z0vek;
			}
			return 0;
		}
		set
		{
			if (value == 0)
			{
				if (z0utk != null)
				{
					((z0cpk)z0utk).z0vek = value;
				}
			}
			else
			{
				base.z0lrk().z0vek = value;
			}
		}
	}

	[z0ZzZzbjh(MemberEffectLevel.ElementLayout)]
	[DefaultValue(ContentViewEncryptType.None)]
	public ContentViewEncryptType ViewEncryptType
	{
		get
		{
			if (z0utk != null)
			{
				return ((z0cpk)z0utk).z0frk;
			}
			return ContentViewEncryptType.None;
		}
		set
		{
			if (value == ContentViewEncryptType.None)
			{
				if (z0utk != null)
				{
					((z0cpk)z0utk).z0frk = ContentViewEncryptType.None;
				}
			}
			else
			{
				base.z0lrk().z0frk = value;
			}
		}
	}

	[DefaultValue(EnableState.Enabled)]
	[z0ZzZzbjh(MemberEffectLevel.ElementView)]
	public virtual EnableState EnableHighlight
	{
		get
		{
			return z0rrk;
		}
		set
		{
			z0rrk = value;
		}
	}

	[z0ZzZzbjh(MemberEffectLevel.ElementLayout)]
	[DefaultValue(null)]
	public string BackgroundText
	{
		get
		{
			return z0irk;
		}
		set
		{
			z0irk = value;
			base.z0qrk = null;
		}
	}

	[DefaultValue(null)]
	public string Name
	{
		get
		{
			return z0ork;
		}
		set
		{
			z0ork = value;
		}
	}

	[z0ZzZzbjh(MemberEffectLevel.ElementLayout)]
	[DefaultValue(null)]
	public string UnitText
	{
		get
		{
			if (z0utk != null)
			{
				return ((z0cpk)z0utk).z0oek;
			}
			return null;
		}
		set
		{
			if (value == null || value.Length == 0)
			{
				if (z0utk != null)
				{
					((z0cpk)z0utk).z0oek = value;
				}
			}
			else
			{
				base.z0lrk().z0oek = value;
			}
		}
	}

	[DefaultValue(0f)]
	[z0ZzZzbjh(MemberEffectLevel.ElementLayout)]
	public float SpecifyWidth
	{
		get
		{
			return z0wrk;
		}
		set
		{
			z0wrk = value;
		}
	}

	[z0ZzZzbjh(MemberEffectLevel.ElementLayout)]
	[DefaultValue(StringAlignment.Near)]
	public StringAlignment Alignment
	{
		get
		{
			if (z0utk != null)
			{
				return ((z0cpk)z0utk).z0hrk;
			}
			return StringAlignment.Near;
		}
		set
		{
			if (value == StringAlignment.Near)
			{
				if (z0utk != null)
				{
					((z0cpk)z0utk).z0hrk = value;
				}
			}
			else
			{
				base.z0lrk().z0hrk = value;
			}
		}
	}

	[DefaultValue(DCVisibleState.Default)]
	[z0ZzZzbjh(MemberEffectLevel.ElementLayout)]
	public DCVisibleState BorderVisible
	{
		get
		{
			if (z0utk != null)
			{
				return ((z0cpk)z0utk).z0jrk;
			}
			return DCVisibleState.Default;
		}
		set
		{
			if (value == DCVisibleState.Default)
			{
				if (z0utk != null)
				{
					((z0cpk)z0utk).z0jrk = value;
				}
			}
			else
			{
				base.z0lrk().z0jrk = value;
			}
		}
	}

	[z0ZzZzbjh]
	[DefaultValue(true)]
	public bool TabStop
	{
		get
		{
			return z0yyk();
		}
		set
		{
			z0frk(value);
		}
	}

	[DefaultValue(true)]
	[z0ZzZzbjh]
	public bool UserEditable
	{
		get
		{
			return z0vrk();
		}
		set
		{
			z0ork(value);
		}
	}

	[z0ZzZzbjh(MemberEffectLevel.ElementLayout)]
	[DefaultValue(null)]
	public string LabelText
	{
		get
		{
			if (z0utk != null)
			{
				return ((z0cpk)z0utk).z0drk;
			}
			return null;
		}
		set
		{
			if (value == null || value.Length == 0)
			{
				if (z0utk != null)
				{
					((z0cpk)z0utk).z0drk = null;
				}
			}
			else
			{
				base.z0lrk().z0drk = value;
			}
		}
	}

	[z0ZzZzbjh(MemberEffectLevel.DOM)]
	[DefaultValue(null)]
	public string InnerValue
	{
		get
		{
			return z0urk;
		}
		set
		{
			z0urk = value;
		}
	}

	[DefaultValue(null)]
	[z0ZzZzbjh(MemberEffectLevel.ElementLayout)]
	public z0ZzZzsok DisplayFormat
	{
		get
		{
			return z0erk;
		}
		set
		{
			z0erk = value;
		}
	}

	[DefaultValue(null)]
	[z0ZzZzrqh("Expression", typeof(z0ZzZzykh))]
	public z0ZzZzukh EventExpressions
	{
		get
		{
			return z0mrk;
		}
		set
		{
			z0mrk = value;
		}
	}

	[z0ZzZzuqh]
	[z0ZzZzbjh(MemberEffectLevel.ElementLayout)]
	public override string FormulaValue
	{
		get
		{
			if (string.IsNullOrEmpty(InnerValue))
			{
				return Text;
			}
			return InnerValue;
		}
		set
		{
			base.FormulaValue = z0my(value, p1: false);
		}
	}

	[DefaultValue(null)]
	public string DefaultEventExpression
	{
		get
		{
			return z0nrk;
		}
		set
		{
			z0nrk = value;
		}
	}

	[DefaultValue(MoveFocusHotKeys.Default)]
	[z0ZzZzbjh]
	public MoveFocusHotKeys MoveFocusHotKey
	{
		get
		{
			return z0brk;
		}
		set
		{
			z0brk = value;
		}
	}

	public new bool z0eek()
	{
		return base.ContentReadonly == ContentReadonlyState.True;
	}

	public new DCFastInputMode z0rek()
	{
		if (z0utk != null)
		{
			return ((z0cpk)z0utk).z0nek;
		}
		return DCFastInputMode.NextField;
	}

	public new float z0tek()
	{
		if (z0wrk == 0f)
		{
			return 0f;
		}
		if (z0wrk < 0f)
		{
			if (z0ZzZzccj.z0rek(167))
			{
				return z0wrk;
			}
			return 0f;
		}
		return z0wrk;
	}

	public void z0eek(DCBooleanValue p0)
	{
		if (p0 == DCBooleanValue.Inherit)
		{
			if (z0utk != null)
			{
				((z0cpk)z0utk).z0mek = p0;
			}
		}
		else
		{
			base.z0lrk().z0mek = p0;
		}
	}

	public override void z0oe()
	{
		if (z0ntk != null)
		{
			z0ntk.z0nek(p0: false);
			z0ZzZzafh.z0yek(z0ntk, p1: false, z0rik, this, p4: true);
		}
		z0ZzZzmxj z0ZzZzmxj = z0jr().z0htk();
		if (base.z0qrk != null && z0ZzZzmxj != null)
		{
			XTextElement[] array = base.z0qrk;
			foreach (XTextElement p in array)
			{
				z0ZzZzmxj.z0qp(p);
			}
		}
		base.z0eek((XTextElement[])null);
		string text = Text;
		string text2 = z0eek(text);
		if (text != text2)
		{
			z0zek(text2);
			InnerValue = text2;
		}
		base.z0oe();
	}

	public override bool z0eo(bool p0)
	{
		if (base.z0eo(p0))
		{
			return true;
		}
		return false;
	}

	public new bool z0yek()
	{
		if (!string.IsNullOrEmpty(base.StartBorderText))
		{
			return true;
		}
		if (!string.IsNullOrEmpty(LabelText))
		{
			return true;
		}
		return false;
	}

	internal new virtual bool z0uek()
	{
		if (z0wrk == 0f)
		{
			return false;
		}
		float num = Math.Abs(z0tek());
		if (num > 0f)
		{
			XTextContentElement xTextContentElement = z0jy();
			if (xTextContentElement == null || z0trk != xTextContentElement.z0itk)
			{
				if (xTextContentElement != null)
				{
					z0trk = xTextContentElement.z0itk;
				}
				float num2 = 0f;
				if (base.z0wrk == null)
				{
					z0krk();
				}
				if ((z0ntk == null || z0ntk.Count == 0) && (z0irk == null || z0irk.Length == 0))
				{
					if (base.z0wrk == null)
					{
						z0krk();
					}
					num2 = num - base.z0wrk.z0tek() - base.z0ark.z0tek();
				}
				else
				{
					XTextElementList xTextElementList = new XTextElementList(z0be().Count + 2);
					z0eok_jiejie20260327142557 z0eok_jiejie20260327142557 = new z0eok_jiejie20260327142557(((XTextElement)this).z0drk(), xTextElementList, p2: true);
					z0eok_jiejie20260327142557.z0bek = true;
					z0ue(z0eok_jiejie20260327142557);
					z0eok_jiejie20260327142557.Dispose();
					if (xTextElementList.Count > 0 && (xTextElementList[0] == base.z0wrk || xTextElementList[xTextElementList.Count - 1] == base.z0ark))
					{
						float num3 = 0f;
						using (zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = xTextElementList.z0ltk())
						{
							while (z0bpk.MoveNext())
							{
								XTextElement current = z0bpk.Current;
								num3 = ((!(current is XTextFieldBorderElement) || current.z0ji() != this) ? (num3 + current.Width) : (num3 + ((XTextFieldBorderElement)current).z0tek()));
							}
						}
						num2 = num - num3;
					}
				}
				base.z0wrk.z0eek(p0: true);
				base.z0ark.z0eek(p0: true);
				if (num2 > 0f)
				{
					switch (z0zek())
					{
					case StringAlignment.Near:
						base.z0wrk.z0uek(base.z0wrk.z0tek());
						base.z0ark.z0uek(base.z0ark.z0tek() + num2);
						break;
					case StringAlignment.Center:
						base.z0wrk.z0uek(base.z0wrk.z0tek() + num2 / 2f);
						base.z0ark.z0uek(base.z0ark.z0tek() + num2 / 2f);
						break;
					case StringAlignment.Far:
						base.z0wrk.z0uek(base.z0wrk.z0tek() + num2);
						base.z0ark.z0uek(base.z0ark.z0tek());
						break;
					}
				}
				else
				{
					base.z0wrk.z0uek(base.z0wrk.z0tek());
					base.z0ark.z0uek(base.z0ark.z0tek());
				}
			}
		}
		return false;
	}

	public new virtual z0ZzZzukh z0iek()
	{
		z0ZzZzukh z0ZzZzukh = null;
		if (!string.IsNullOrEmpty(DefaultEventExpression))
		{
			z0ZzZzukh = new z0ZzZzukh();
			z0ZzZzykh z0ZzZzykh = new z0ZzZzykh();
			z0ZzZzykh.z0eek(DefaultEventExpression);
			z0ZzZzukh.Add(z0ZzZzykh);
			if (EventExpressions != null)
			{
				z0ZzZzukh.AddRange(EventExpressions);
			}
			return z0ZzZzukh;
		}
		return EventExpressions;
	}

	public new z0ZzZzscj z0oek()
	{
		if (z0utk != null)
		{
			return ((z0cpk)z0utk).z0iek;
		}
		return (z0ZzZzscj)1;
	}

	private void z0eek(XTextElement[] p0, float p1, z0ZzZzvxj p2, bool p3)
	{
		if (p1 >= 1f)
		{
			p1 = 1f;
		}
		p1 = (float)Math.Round(p1, 3);
		foreach (XTextElement xTextElement in p0)
		{
			if (xTextElement is XTextCharElement)
			{
				XTextCharElement xTextCharElement = (XTextCharElement)xTextElement;
				if (xTextCharElement.z0nek() != p1)
				{
					xTextCharElement.z0rek(p1);
					p2.z0hyk = xTextCharElement;
					xTextCharElement.z0mr(p2);
				}
			}
			else if (xTextElement is XTextParagraphFlagElement)
			{
				XTextParagraphFlagElement xTextParagraphFlagElement = (XTextParagraphFlagElement)xTextElement;
				if (xTextParagraphFlagElement.z0pek() != p1)
				{
					xTextParagraphFlagElement.z0eek(p1);
					p2.z0hyk = xTextParagraphFlagElement;
					xTextParagraphFlagElement.z0mr(p2);
				}
			}
		}
		z0prk().z0lrk = p1;
	}

	public override bool z0do(SetContainerTextArgs p0)
	{
		if (!p0.IgnoreDisplayFormat)
		{
			p0.NewText = z0eek(p0.NewText);
		}
		if (z0utk != null)
		{
			z0cpk obj = (z0cpk)z0utk;
			obj.z0srk = 0;
			obj.z0yek = 0;
		}
		bool num = base.z0do(p0);
		if (num)
		{
			if (z0eo(p0: false) && z0jr() != null && z0jr().z0yyk() != null)
			{
				z0jr().z0yyk().z0grk(p0: true);
			}
			if (z0jr() != null && (z0pu_jiejie20260327142557().ValueValidateMode == DocumentValueValidateMode.LostFocus || z0pu_jiejie20260327142557().ValueValidateMode == DocumentValueValidateMode.Dynamic) && z0br() != null)
			{
				z0br().ContentVersion = z0kek() - 1;
				z0krk(p0: false);
			}
		}
		return num;
	}

	public virtual string z0my(string p0, bool p1)
	{
		return p0;
	}

	public override bool z0qo()
	{
		return !z0sek();
	}

	public override void z0zi(ContentChangedEventArgs p0)
	{
		z0ZzZzsok z0ZzZzsok = z0erk;
		try
		{
			z0erk = null;
			base.z0zi(p0);
		}
		finally
		{
			z0erk = z0ZzZzsok;
		}
	}

	public new bool z0pek()
	{
		return z0wrk();
	}

	public new virtual bool z0mek()
	{
		return z0frk() != null;
	}

	public void z0eek(object p0)
	{
		if (p0 == null)
		{
			if (z0itk != null)
			{
				z0itk.z0tek = p0;
			}
			return;
		}
		if (z0itk == null)
		{
			z0itk = new z0ZzZzqcj();
		}
		z0itk.z0tek = p0;
	}

	public new EnableState z0nek()
	{
		EnableState enableState = z0rrk;
		switch (enableState)
		{
		case EnableState.Enabled:
			return EnableState.Enabled;
		case EnableState.Default:
			if (z0rik != null)
			{
				enableState = z0iu().DefaultInputFieldHighlight;
			}
			break;
		}
		if (enableState == EnableState.Default)
		{
			enableState = EnableState.Enabled;
		}
		return enableState;
	}

	public virtual string z0uy(string p0)
	{
		return p0;
	}

	public new virtual string z0eek(string p0)
	{
		z0ZzZzsok z0ZzZzsok = z0frk();
		if (z0ZzZzsok != null && !z0ZzZzsok.IsEmpty)
		{
			p0 = z0ZzZzsok.Execute(p0);
		}
		return p0;
	}

	public override string z0xr()
	{
		if (!string.IsNullOrEmpty(ID))
		{
			return "Field[" + ID + "]";
		}
		if (!string.IsNullOrEmpty(Name))
		{
			return "Field[" + Name + "]";
		}
		return "Field";
	}

	public override XTextElement z0lr(bool p0)
	{
		XTextInputFieldElementBase xTextInputFieldElementBase = (XTextInputFieldElementBase)base.z0lr(p0);
		if (z0erk != null)
		{
			xTextInputFieldElementBase.z0erk = z0erk.Clone();
		}
		if (z0mrk != null)
		{
			xTextInputFieldElementBase.z0mrk = z0mrk.z0rek();
		}
		((XTextFieldElementBase)xTextInputFieldElementBase).z0qrk = null;
		return xTextInputFieldElementBase;
	}

	public override void z0ko(ElementEventArgs p0)
	{
		if (z0iu().FieldHoverBackColor.A != 0)
		{
			if (z0jr().z0htk() != null)
			{
				z0jr().z0htk().z0co(this);
			}
			z0jo();
		}
		base.z0ko(p0);
	}

	public override bool z0wo(z0ZzZzgcj p0, int p1)
	{
		if (z0sek() && !z0jr().z0xek().z0wm())
		{
			if (p0 != null && p0.Count > 0)
			{
				p0.z0eek(this, z0ZzZziok.z0nek(), p0[0].z0rek());
			}
			return true;
		}
		if (z0be() == null || z0be().Count == 0)
		{
			return false;
		}
		return base.z0wo(p0, p1);
	}

	internal new bool z0bek()
	{
		return z0pek();
	}

	public virtual void z0eek(bool p0)
	{
		if (z0jr() != null && z0jr().z0rik() != null && z0jr().z0bek((XTextElement)this))
		{
			z0jr().z0rik().z0sw(this, z0iek(), "ContentChanged", p0);
		}
	}

	private void z0eek(bool p0, bool p1)
	{
		if (p0)
		{
			for (XTextElement xTextElement = z0ji(); xTextElement != null; xTextElement = xTextElement.z0ji())
			{
				if (xTextElement is XTextContentElement)
				{
					XTextContentElement xTextContentElement = (XTextContentElement)xTextElement;
					if (xTextContentElement is XTextDocumentContentElement)
					{
						XTextDocumentContentElement obj = (XTextDocumentContentElement)xTextContentElement;
						XTextContentElement.z0lgj z0lgj = new XTextContentElement.z0lgj();
						z0lgj.z0tek(p0: false);
						z0lgj.z0uek(p0: true);
						obj.z0rek(z0lgj);
					}
					else
					{
						XTextContentElement.z0lgj z0lgj2 = new XTextContentElement.z0lgj();
						z0lgj2.z0tek(p0: false);
						z0lgj2.z0uek(p0: true);
						z0lgj2.z0eek(p0: true);
						xTextContentElement.z0au(z0lgj2);
					}
				}
			}
		}
		if (p1)
		{
			XTextContentElement xTextContentElement2 = z0jy();
			xTextContentElement2.z0eek(xTextContentElement2.z0trk().IndexOf(base.z0jrk()), xTextContentElement2.z0trk().IndexOf(base.z0tek()), p2: false);
		}
	}

	public new string z0vek()
	{
		if (!string.IsNullOrEmpty(ID))
		{
			return ID;
		}
		return Name;
	}

	public new DCBooleanValue z0cek()
	{
		if (z0utk != null)
		{
			return ((z0cpk)z0utk).z0mek;
		}
		return DCBooleanValue.Inherit;
	}

	public void z0rek(bool p0)
	{
		if (p0)
		{
			base.ContentReadonly = ContentReadonlyState.True;
		}
		else
		{
			base.ContentReadonly = ContentReadonlyState.False;
		}
	}

	public void z0tek(bool p0)
	{
		z0mrk(p0);
	}

	public new XTextInputFieldElementBase z0xek()
	{
		XTextInputFieldElementBase xTextInputFieldElementBase = this;
		do
		{
			xTextInputFieldElementBase = z0jr().z0tek<XTextInputFieldElementBase>(xTextInputFieldElementBase, p1: false, p2: true);
		}
		while (xTextInputFieldElementBase != null && !xTextInputFieldElementBase.TabStop);
		return xTextInputFieldElementBase;
	}

	internal bool z0rek(bool p0, bool p1)
	{
		if (z0tek() >= 0f || z0be().Count == 0)
		{
			return false;
		}
		float num = 0f;
		XTextElementList xTextElementList = new XTextElementList();
		z0eok_jiejie20260327142557 z0eok_jiejie20260327142557 = new z0eok_jiejie20260327142557(z0jr(), xTextElementList, p2: true);
		base.z0eek(z0eok_jiejie20260327142557);
		z0eok_jiejie20260327142557.Dispose();
		z0cpk z0cpk = base.z0lrk();
		int num2 = z0cpk.z0srk;
		z0cpk.z0srk = 0;
		for (int num3 = xTextElementList.Count - 1; num3 >= 0; num3--)
		{
			num += xTextElementList[num3].Width;
			if (num >= z0cpk.z0wrk && num3 < xTextElementList.Count - 1)
			{
				z0cpk.z0srk = num3;
				break;
			}
		}
		if (z0cpk.z0srk != num2)
		{
			z0eek(p0, p1);
			return true;
		}
		return false;
	}

	public override void z0yr(MoveFocusHotKeys p0)
	{
	}

	public override void z0ye(ElementEventArgs p0)
	{
		if (z0iu().FieldFocusedBackColor.A != 0 && z0jr().z0htk() != null)
		{
			z0jr().z0htk().z0co(this);
			z0jo();
		}
		base.z0ye(p0);
	}

	public override string z0ho()
	{
		return z0irk;
	}

	private new StringAlignment z0zek()
	{
		return Alignment;
	}

	public new object z0lrk()
	{
		return z0itk?.z0uek;
	}

	public new bool z0krk()
	{
		return UserEditable;
	}

	public override void z0oy(ElementEventArgs p0)
	{
		if (z0iu().FieldFocusedBackColor.A != 0 && z0jr().z0htk() != null)
		{
			z0jr().z0htk().z0co(this);
			z0jo();
		}
		base.z0oy(p0);
	}

	public new string z0jrk()
	{
		string unitText = UnitText;
		if (unitText != null && unitText.Length > 0 && z0ZzZzccj.z0rek(163))
		{
			return unitText;
		}
		return null;
	}

	public override void Dispose()
	{
		base.Dispose();
		z0irk = null;
		z0erk = null;
		z0nrk = null;
		if (z0mrk != null)
		{
			z0mrk.Clear();
			z0mrk = null;
		}
		z0urk = null;
		z0ork = null;
	}

	public new bool z0hrk()
	{
		return z0yek(typeof(XTextInputFieldElementBase), p1: false) == null;
	}

	public override int z0ue(z0eok_jiejie20260327142557 p0)
	{
		if (z0rik == null)
		{
			return 0;
		}
		p0.z0cek = true;
		if (!p0.z0krk && z0prk == z0qtk && z0rik.z0bek(this))
		{
			XTextElementList xTextElementList = p0.z0iek;
			XTextElementList xTextElementList2 = z0be();
			int count = xTextElementList.Count;
			if (xTextElementList2.Count > 0)
			{
				xTextElementList.z0yrk(xTextElementList.Count + xTextElementList2.Count + 2);
				((zzz.z0ZzZzkuk<XTextElement>)xTextElementList).z0mek((XTextElement)base.z0wrk);
				z0drk(p0: true);
				((zzz.z0ZzZzkuk<XTextElement>)xTextElementList).z0tek((zzz.z0ZzZzkuk<XTextElement>)xTextElementList2);
				((zzz.z0ZzZzkuk<XTextElement>)xTextElementList).z0mek((XTextElement)base.z0ark);
			}
			else
			{
				xTextElementList.z0yrk(xTextElementList.Count + 2 + ((base.z0qrk != null) ? base.z0qrk.Length : 0));
				((zzz.z0ZzZzkuk<XTextElement>)xTextElementList).z0mek((XTextElement)base.z0wrk);
				z0drk(p0: false);
				if (base.z0qrk != null)
				{
					xTextElementList.z0trk(base.z0qrk);
				}
				((zzz.z0ZzZzkuk<XTextElement>)xTextElementList).z0mek((XTextElement)base.z0ark);
			}
			if (!p0.z0krk)
			{
				if (count == xTextElementList.Count)
				{
					z0uek(-1);
				}
				else
				{
					z0uek(count);
				}
			}
			return xTextElementList.Count - count;
		}
		z0eok_jiejie20260327142557 z0eok_jiejie20260327142557 = null;
		if (!p0.z0rek)
		{
			z0eok_jiejie20260327142557 = p0;
			p0 = XTextSectionElement.z0eek(this, p0);
			if (z0eok_jiejie20260327142557 == p0)
			{
				z0eok_jiejie20260327142557 = null;
			}
		}
		z0drk(p0: false);
		XTextElementList xTextElementList3 = p0.z0iek;
		int num = -1;
		if (p0.z0uek != null)
		{
			if (z0utk != null)
			{
				z0utk.z0nek = null;
			}
			if (z0bek() && z0tek() != 0f)
			{
				num = xTextElementList3.Count;
				p0.z0uek.Add(this);
			}
		}
		bool flag = p0.z0krk;
		_ = p0.z0hrk;
		bool flag2 = p0.z0jrk;
		bool flag3 = true;
		if (flag2)
		{
			flag3 = false;
			if (p0.z0eek(z0cek()) || p0.z0nek)
			{
				flag3 = true;
				flag2 = false;
			}
		}
		float num2 = z0wrk;
		if (num2 < 0f && !p0.z0xek)
		{
			num2 = 0f;
		}
		bool flag4 = p0.z0tek;
		bool flag5 = flag4;
		StringAlignment alignment = Alignment;
		if (!flag4)
		{
			bool flag6 = base.z0oek() != null;
			if (flag6 && flag2 && p0.z0lrk == DCRenderVisibility.None)
			{
				flag6 = false;
			}
			flag4 = !string.IsNullOrEmpty(z0srk()) || flag6 || num2 != 0f;
			if (!flag4 && num2 != 0f && (alignment == StringAlignment.Near || alignment == StringAlignment.Center))
			{
				flag4 = true;
			}
		}
		if (!flag5)
		{
			bool flag7 = base.z0nek() != null;
			if (flag7 && flag2 && p0.z0lrk == DCRenderVisibility.None)
			{
				flag7 = false;
			}
			flag5 = z0drk() || flag7 || num2 != 0f;
			if (!flag5 && num2 != 0f && (alignment == StringAlignment.Center || alignment == StringAlignment.Far))
			{
				flag5 = true;
			}
		}
		if (p0.z0bek && num2 >= 0f)
		{
			if (flag4)
			{
				if (base.z0wrk == null)
				{
					z0krk();
				}
				((zzz.z0ZzZzkuk<XTextElement>)xTextElementList3).z0pek((XTextElement)base.z0wrk);
			}
			int count2 = xTextElementList3.Count;
			if (z0ntk != null && z0ntk.Count > 0)
			{
				base.z0eek(p0);
			}
			if (xTextElementList3.Count == count2 && (!p0.z0yek || p0.z0oek || p0.z0nek))
			{
				if (base.z0qrk == null)
				{
					base.z0yek();
				}
				if (base.z0qrk.Length != 0)
				{
					xTextElementList3.z0trk(base.z0qrk);
				}
			}
			if (flag5)
			{
				if (base.z0wrk == null)
				{
					z0krk();
				}
				((zzz.z0ZzZzkuk<XTextElement>)xTextElementList3).z0pek((XTextElement)base.z0ark);
			}
			if (num >= 0)
			{
				z0prk().z0nek = xTextElementList3.z0mek(num);
			}
			if (z0eok_jiejie20260327142557 != null)
			{
				z0eok_jiejie20260327142557.z0cek = p0.z0cek;
				z0eok_jiejie20260327142557.z0uek = p0.z0uek;
				z0eok_jiejie20260327142557.z0zek = p0.z0zek;
			}
			return 0;
		}
		int count3 = xTextElementList3.Count;
		if (base.z0wrk == null)
		{
			z0krk();
		}
		XTextFieldBorderElement xTextFieldBorderElement = base.z0wrk;
		XTextFieldBorderElement xTextFieldBorderElement2 = base.z0ark;
		if (flag4)
		{
			((zzz.z0ZzZzkuk<XTextElement>)xTextElementList3).z0pek((XTextElement)xTextFieldBorderElement);
		}
		float num3 = 0f;
		if (num2 < 0f)
		{
			num3 = Math.Abs(num2);
			if (flag4)
			{
				num3 -= xTextFieldBorderElement.z0tek();
			}
			if (flag5)
			{
				num3 -= xTextFieldBorderElement2.z0tek();
			}
		}
		if (flag2)
		{
			if (num3 > 0f && flag)
			{
				if (z0utk != null)
				{
					((z0cpk)z0utk).z0wrk = 0f;
				}
				z0eek(p0, num3, -1);
			}
			else
			{
				base.z0eek(p0);
			}
		}
		else
		{
			bool flag8 = false;
			if (z0ntk != null && z0ntk.Count > 0)
			{
				flag8 = z0ntk.z0yek(0).z0cuk;
				if (!flag8)
				{
					foreach (XTextElement item in z0be().z0xrk())
					{
						if (item.z0cuk)
						{
							flag8 = true;
							break;
						}
					}
				}
			}
			if (flag8)
			{
				z0drk(p0: true);
				if (num3 > 0f && flag)
				{
					if (z0utk != null)
					{
						((z0cpk)z0utk).z0wrk = 0f;
					}
					z0eek(p0, num3, -1);
				}
				else
				{
					int count4 = xTextElementList3.Count;
					base.z0eek(p0);
					float num4 = Math.Abs(num2);
					if (flag4)
					{
						num4 -= base.z0wrk.z0tek();
					}
					if (flag5)
					{
						num4 -= base.z0ark.z0tek();
					}
					z0yek(p0: false);
					if ((double)num4 > 0.1)
					{
						int count5 = xTextElementList3.Count;
						for (int i = count4; i < count5; i++)
						{
							num4 -= xTextElementList3[i].Width;
							if (num4 < 0f)
							{
								z0yek(p0: true);
								break;
							}
						}
					}
				}
				if (z0qrk() && p0.z0iek is z0ZzZzplh)
				{
					((z0ZzZzplh)p0.z0iek).z0htk = true;
				}
			}
			else if (flag3)
			{
				if (base.z0qrk == null)
				{
					base.z0yek();
				}
				XTextElement[] array = base.z0qrk;
				if (array != null && array.Length != 0)
				{
					xTextElementList3.z0trk(array);
					z0drk(p0: true);
				}
			}
		}
		if (flag5)
		{
			((zzz.z0ZzZzkuk<XTextElement>)xTextElementList3).z0pek((XTextElement)xTextFieldBorderElement2);
		}
		else if (flag2 && base.EndingLineBreak)
		{
			((zzz.z0ZzZzkuk<XTextElement>)xTextElementList3).z0pek((XTextElement)new z0ZzZzfkh(this));
		}
		if (flag4)
		{
			xTextFieldBorderElement.z0xek();
		}
		if (flag5)
		{
			xTextFieldBorderElement2.z0xek();
		}
		if (flag4 && z0wrk > 0f && flag2 && p0.z0lrk == DCRenderVisibility.None)
		{
			int num5 = (xTextElementList3.z0pek(count3, base.z0wrk) ? count3 : xTextElementList3.IndexOf(base.z0wrk));
			if (num5 >= 0)
			{
				int num6 = xTextElementList3.z0rrk(base.z0ark, num5);
				if (num6 > num5)
				{
					float num7 = 0f;
					for (int j = num5 + 1; j < num6; j++)
					{
						num7 += xTextElementList3[j].Width;
					}
					if (num7 > z0wrk)
					{
						if (string.IsNullOrEmpty(UnitText))
						{
							xTextElementList3.RemoveAt(num6);
						}
						if (string.IsNullOrEmpty(LabelText))
						{
							xTextElementList3.RemoveAt(num5);
						}
					}
				}
			}
		}
		if (!p0.z0krk)
		{
			if (xTextElementList3.Count == count3)
			{
				z0uek(-1);
			}
			else
			{
				z0uek(count3);
			}
		}
		count3 = xTextElementList3.Count - count3;
		if (num >= 0)
		{
			z0prk().z0nek = xTextElementList3.z0mek(num);
		}
		if (!p0.z0krk && z0rik.z0bek(this))
		{
			z0prk = -1;
			if (xTextElementList3.z0yek(xTextElementList3.Count - count3) == base.z0wrk && xTextElementList3.LastElement == base.z0ark)
			{
				IList<XTextElement> list2;
				if (z0ntk.Count <= 0 && base.z0qrk != null)
				{
					IList<XTextElement> list = base.z0qrk;
					list2 = list;
				}
				else
				{
					IList<XTextElement> list = z0ntk;
					list2 = list;
				}
				IList<XTextElement> list3 = list2;
				if (list3 != null && count3 == list3.Count + 2)
				{
					z0prk = z0qtk;
					if (list3.Count > 0)
					{
						int num8 = xTextElementList3.Count - list3.Count - 1;
						for (int num9 = list3.Count - 1; num9 >= 0; num9--)
						{
							if (xTextElementList3.z0yek(num9 + num8) != list3[num9])
							{
								z0prk = -1;
								break;
							}
						}
					}
				}
			}
		}
		if (z0eok_jiejie20260327142557 != null)
		{
			z0eok_jiejie20260327142557.z0cek = p0.z0cek;
			z0eok_jiejie20260327142557.z0uek = p0.z0uek;
			z0eok_jiejie20260327142557.z0zek = p0.z0zek;
		}
		return count3;
	}

	internal void z0eek(z0ZzZzvxj p0)
	{
		XTextElement[] array = z0utk?.z0nek;
		if (array == null || array.Length == 0)
		{
			return;
		}
		float num = z0tek();
		if (num <= 0f || !z0bek())
		{
			return;
		}
		base.z0jrk().Width = z0jr().z0xek(XTextFieldBorderElement.z0drk_jiejie20260327142557);
		base.z0tek().Width = base.z0jrk().Width;
		XTextElement[] array2 = array;
		foreach (XTextElement xTextElement in array2)
		{
			if (xTextElement is XTextCharElement)
			{
				XTextCharElement xTextCharElement = (XTextCharElement)xTextElement;
				if (xTextCharElement.z0nek() != 1f)
				{
					xTextCharElement.z0rek(1f);
					p0.z0hyk = xTextCharElement;
					xTextCharElement.z0mr(p0);
				}
			}
			else if (xTextElement is XTextParagraphFlagElement)
			{
				XTextParagraphFlagElement xTextParagraphFlagElement = (XTextParagraphFlagElement)xTextElement;
				xTextParagraphFlagElement.z0eek(1f);
				p0.z0hyk = xTextParagraphFlagElement;
				xTextParagraphFlagElement.z0mr(p0);
			}
		}
		z0prk().z0lrk = 1f;
		float num2 = 1f;
		float num3 = 0f;
		float num4 = 0f;
		array2 = array;
		foreach (XTextElement xTextElement2 in array2)
		{
			num3 += xTextElement2.Width;
			if (xTextElement2 is XTextCharElement)
			{
				num4 += xTextElement2.Width;
			}
		}
		float num5 = num3 - num;
		if (num5 > 0f && num4 > 0f)
		{
			num2 = (num4 - num5) / num4;
			if (num2 < 0.3f)
			{
				num2 = 0.3f;
			}
		}
		XTextTableCellElement.z0mrk = true;
		if ((double)num2 < 1.0)
		{
			z0eek(array, num2, p0, p3: true);
		}
		z0prk().z0lrk = num2;
	}

	public new object z0grk()
	{
		return z0itk?.z0tek;
	}

	public new void z0yek(bool p0)
	{
		z0ark(p0);
	}

	public void z0rek(object p0)
	{
		if (p0 == null)
		{
			if (z0itk != null)
			{
				z0itk.z0uek = p0;
			}
		}
		else if (z0itk == null)
		{
			z0itk = new z0ZzZzqcj();
		}
		z0itk.z0uek = p0;
	}

	public override void z0nw(z0ZzZzuzj p0)
	{
		base.z0nw(p0);
		p0.z0eek(z0irk);
		p0.z0eek(LabelText);
		p0.z0eek(UnitText);
		p0.z0eek(z0ork);
	}

	internal bool z0eek(XTextElement p0, bool p1, bool p2)
	{
		if (z0xu())
		{
			return false;
		}
		if (p0 == this)
		{
			return false;
		}
		if (z0tek() >= 0f)
		{
			return false;
		}
		XTextElementList xTextElementList = new XTextElementList();
		z0eok_jiejie20260327142557 z0eok_jiejie20260327142557 = new z0eok_jiejie20260327142557(z0jr(), xTextElementList, p2: false);
		z0ue(z0eok_jiejie20260327142557);
		z0eok_jiejie20260327142557.Dispose();
		if (xTextElementList.Contains(p0))
		{
			XTextElementList xTextElementList2 = new XTextElementList();
			z0eok_jiejie20260327142557 z0eok_jiejie202603271425572 = new z0eok_jiejie20260327142557(z0jr(), xTextElementList2, p2: true);
			z0ue(z0eok_jiejie202603271425572);
			if (!xTextElementList2.Contains(p0))
			{
				xTextElementList2.Clear();
				base.z0eek(z0eok_jiejie202603271425572);
				int num = xTextElementList2.IndexOf(p0);
				if (num >= 0)
				{
					z0cpk z0cpk = base.z0lrk();
					int num2 = z0cpk.z0srk;
					if (num < z0cpk.z0srk)
					{
						z0cpk.z0srk = num;
					}
					else if (num > z0cpk.z0yek)
					{
						float num3 = 0f;
						z0cpk.z0srk = 0;
						for (int num4 = num; num4 >= 0; num4--)
						{
							num3 += xTextElementList2[num4].Width;
							if (num3 > z0cpk.z0wrk && num4 != num)
							{
								z0cpk.z0srk = num4 + 1;
								break;
							}
						}
					}
					if (num2 == z0cpk.z0srk)
					{
						return false;
					}
					z0eek(p1, p2);
					return true;
				}
			}
			z0eok_jiejie202603271425572.Dispose();
		}
		return false;
	}

	public override XTextElementList z0go(string p0, DocumentContentStyle p1)
	{
		string p2 = z0eek(p0);
		return base.z0go(p2, p1);
	}

	public new z0ZzZzsok z0frk()
	{
		if (z0erk != null && !z0erk.IsEmpty && z0ZzZzccj.z0rek(182))
		{
			return z0erk;
		}
		return null;
	}

	public override void z0bw_jiejie20260327142557(z0ygj p0)
	{
		if (!p0.z0pek)
		{
			p0.z0pek = true;
			if (z0crk())
			{
				base.z0bw_jiejie20260327142557(p0);
			}
			else if (p0.z0yek && z0irk != null)
			{
				p0.z0eek(z0irk);
			}
			return;
		}
		if (p0.z0uek)
		{
			p0.z0eek(base.z0oek());
		}
		p0.z0eek(z0srk());
		if (z0crk())
		{
			base.z0bw_jiejie20260327142557(p0);
		}
		else if (p0.z0yek && z0irk != null)
		{
			p0.z0eek(z0irk);
		}
		p0.z0eek(z0jrk());
		if (p0.z0uek)
		{
			p0.z0eek(base.z0nek());
		}
	}

	public override string z0iy()
	{
		if (((XTextContainerElement)this).z0hrk() && !ValueBinding.IsEmptyBinding)
		{
			return ValueBinding.DataSource + "#" + ValueBinding.BindingPath;
		}
		return null;
	}

	public new bool z0drk()
	{
		if (!string.IsNullOrEmpty(UnitText))
		{
			return z0ZzZzxcj.z0eek(163);
		}
		return false;
	}

	public override bool z0so()
	{
		if (z0cek() == DCBooleanValue.False)
		{
			return false;
		}
		if (z0cek() == DCBooleanValue.True)
		{
			return true;
		}
		if (z0jr() != null)
		{
			return z0iu().PrintBackgroundText;
		}
		return true;
	}

	public override bool z0vr()
	{
		return TabStop;
	}

	public new string z0srk()
	{
		string labelText = LabelText;
		if (labelText != null && labelText.Length > 0 && z0ZzZzccj.z0rek(162))
		{
			return labelText;
		}
		return null;
	}

	protected XTextInputFieldElementBase()
	{
		base.EnableValueValidate = true;
		TabStop = true;
		UserEditable = true;
	}

	public void z0eek(DCFastInputMode p0)
	{
		if (p0 == DCFastInputMode.NextField)
		{
			if (z0utk != null)
			{
				((z0cpk)z0utk).z0nek = p0;
			}
		}
		else
		{
			base.z0lrk().z0nek = p0;
		}
	}

	public override object z0lek()
	{
		EnableState enableState = z0nek();
		if (enableState == EnableState.Disabled)
		{
			return null;
		}
		XTextDocument xTextDocument = z0rik;
		if (xTextDocument == null)
		{
			return null;
		}
		XTextFieldBorderElement xTextFieldBorderElement = base.z0wrk;
		if (xTextFieldBorderElement == null)
		{
			z0krk();
			xTextFieldBorderElement = base.z0wrk;
		}
		XTextFieldBorderElement xTextFieldBorderElement2 = base.z0ark;
		if (xTextFieldBorderElement == null || xTextFieldBorderElement2 == null)
		{
			return null;
		}
		if (xTextFieldBorderElement.z0tuk < 0 || xTextFieldBorderElement2.z0tuk < 0)
		{
			return null;
		}
		XTextDocumentContentElement xTextDocumentContentElement = z0qek();
		if (xTextDocumentContentElement == null)
		{
			return null;
		}
		z0ZzZzplh z0ZzZzplh = xTextDocumentContentElement.z0frk();
		if (z0ZzZzplh.SafeGet(xTextFieldBorderElement.z0tuk) != xTextFieldBorderElement || z0ZzZzplh.SafeGet(xTextFieldBorderElement2.z0tuk) != xTextFieldBorderElement2)
		{
			return null;
		}
		bool heightClass = false;
		DocumentViewOptions documentViewOptions = xTextDocument.z0iu();
		Color p = Color.Transparent;
		if (((XTextContainerElement)this).z0frk() != null)
		{
			p = documentViewOptions.FieldInvalidateValueBackColor;
			heightClass = true;
		}
		if (p.A == 0 && enableState == EnableState.Enabled)
		{
			if (z0fek() && documentViewOptions.FieldFocusedBackColor.A != 0)
			{
				p = documentViewOptions.FieldFocusedBackColor;
			}
			else if (xTextDocument.z0drk(this) && documentViewOptions.FieldHoverBackColor.A != 0)
			{
				p = documentViewOptions.FieldHoverBackColor;
			}
			else
			{
				Color color = documentViewOptions.FieldBackColor;
				if (z0sek() && documentViewOptions.ReadonlyFieldBackColor.A != 0)
				{
					color = documentViewOptions.ReadonlyFieldBackColor;
				}
				if (color.A != 0)
				{
					switch (enableState)
					{
					case EnableState.Disabled:
						return null;
					case EnableState.Default:
					{
						for (XTextElement xTextElement = z0ji(); xTextElement != null; xTextElement = xTextElement.z0ji())
						{
							if (xTextElement is XTextInputFieldElementBase)
							{
								return null;
							}
						}
						break;
					}
					}
					p = color;
				}
			}
		}
		Color p2 = Color.Empty;
		if (((XTextContainerElement)this).z0frk() != null)
		{
			heightClass = true;
			p2 = documentViewOptions.FieldInvalidateValueForeColor;
		}
		if (p.A != 0 || p2.A != 0)
		{
			return new z0ZzZzqxj(this, new z0ZzZzkkh(xTextDocumentContentElement, xTextFieldBorderElement, xTextFieldBorderElement2), p, p2, HighlightActiveStyle.Static)
			{
				HeightClass = heightClass
			};
		}
		return null;
	}

	public new virtual bool z0ark()
	{
		if (z0irk != null)
		{
			return z0irk.Length > 0;
		}
		return false;
	}

	public override void z0rt(ElementLoadEventArgs p0)
	{
		base.z0rt(p0);
		if (p0.UpdateValueBinding && z0pr())
		{
			z0ZzZzevj valueBinding = ValueBinding;
			if (valueBinding != null && valueBinding.z0yek())
			{
				z0ZzZzrlh z0ZzZzrlh = new z0ZzZzrlh();
				z0ZzZzrlh.z0rek(p0: true);
				XTextDocument.z0mpk()?.z0xb(this, z0ZzZzrlh);
			}
		}
		z0ZzZzsok z0ZzZzsok = z0erk;
		if (z0ZzZzsok == null || z0ZzZzsok.IsEmpty)
		{
			return;
		}
		if (z0ntk != null && z0ntk.Count > 0 && z0ZzZzsok.Style == ValueFormatStyle.DateTime)
		{
			string format = z0ZzZzsok.Format;
			if (format != null && format.Length == z0ntk.Count)
			{
				bool flag = true;
				for (int num = format.Length - 1; num >= 0; num--)
				{
					if (!(z0ntk[num] is XTextCharElement { z0cuk: not false } xTextCharElement) || xTextCharElement.z0aek().z0jyk >= 0)
					{
						flag = false;
						break;
					}
					char charValue = xTextCharElement.CharValue;
					char c = format[num];
					if (charValue != c)
					{
						if (c != 'y' && c != 'Y' && c != 'h' && c != 'H' && c != 'm' && c != 'M' && c != 'd' && c != 'D' && c != 's' && c != 'S')
						{
							flag = false;
							break;
						}
						if (charValue < '0' || charValue > '9')
						{
							flag = false;
							break;
						}
					}
				}
				if (flag)
				{
					return;
				}
			}
		}
		string text = Text;
		string text2 = z0eek(text);
		if ((!string.IsNullOrEmpty(text2) || !string.IsNullOrEmpty(text)) && text2 != text)
		{
			string text3 = z0urk;
			z0cek(text2, (DocumentContentStyle)null, p2: true);
			z0urk = text3;
		}
	}

	public override void z0ei(ElementEventArgs p0)
	{
		if (z0iu().FieldHoverBackColor.A != 0 && z0jr().z0htk() != null)
		{
			z0jr().z0htk().z0co(this);
			z0jo();
		}
		base.z0ei(p0);
	}

	public void z0eek(EnableState p0)
	{
	}

	public new bool z0qrk()
	{
		return z0rtk();
	}

	public override MoveFocusHotKeys z0wr()
	{
		MoveFocusHotKeys moveFocusHotKeys = MoveFocusHotKey;
		if (moveFocusHotKeys == MoveFocusHotKeys.Default && z0jr() != null)
		{
			moveFocusHotKeys = z0bu().MoveFocusHotKey;
		}
		if (moveFocusHotKeys == MoveFocusHotKeys.Default)
		{
			moveFocusHotKeys = MoveFocusHotKeys.None;
		}
		return moveFocusHotKeys;
	}

	public new bool z0eek(XTextElement p0)
	{
		ContentViewEncryptType viewEncryptType = ViewEncryptType;
		if (viewEncryptType == ContentViewEncryptType.None)
		{
			return false;
		}
		if (p0 == null)
		{
			return false;
		}
		ContentViewEncryptType contentViewEncryptType = viewEncryptType;
		if (p0 is XTextFieldBorderElement)
		{
			return false;
		}
		if (((XTextFieldElementBase)this).z0eek(p0))
		{
			return false;
		}
		switch (contentViewEncryptType)
		{
		case ContentViewEncryptType.Partial:
		{
			int count = z0be().Count;
			if (count <= 1)
			{
				return true;
			}
			int num = z0be().IndexOf(p0);
			if (count == 2 && num == 1)
			{
				return true;
			}
			if (num == 0 || num == count - 1)
			{
				return false;
			}
			return true;
		}
		case ContentViewEncryptType.Both:
			return true;
		default:
			return false;
		}
	}

	public override void z0rr(ContentChangedEventArgs p0)
	{
		if (z0jr().z0puk() && z0yrk != null)
		{
			EventHandler eventHandler = z0yrk;
			z0yrk = null;
			eventHandler(this, p0);
		}
		z0eek(p0.LoadingDocument);
		if (z0jr().z0htk() != null)
		{
			z0jr().z0htk().z0co(this);
		}
		base.z0rr(p0);
	}

	private void z0eek(z0eok_jiejie20260327142557 p0, float p1, int p2)
	{
		z0yek(p0: false);
		z0cpk z0cpk = base.z0lrk();
		z0cpk.z0wrk = p1;
		XTextElementList xTextElementList = new XTextElementList();
		z0eok_jiejie20260327142557 z0eok_jiejie20260327142557 = new z0eok_jiejie20260327142557(p0.z0hrk, xTextElementList, p0.z0krk);
		base.z0eek(z0eok_jiejie20260327142557);
		z0eok_jiejie20260327142557.Dispose();
		z0drk(xTextElementList.Count > 0);
		float num = 0f;
		using (zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = xTextElementList.z0ltk())
		{
			while (z0bpk.MoveNext())
			{
				XTextElement current = z0bpk.Current;
				num += current.Width;
			}
		}
		XTextElementList xTextElementList2 = p0.z0iek;
		if (num > p1)
		{
			z0yek(p0: true);
			num = 0f;
			int num2 = 0;
			for (int num3 = xTextElementList.Count - 1; num3 >= 0; num3--)
			{
				num += xTextElementList[num3].Width;
				if (num > p1)
				{
					num2 = num3 + 1;
					if (num2 >= xTextElementList.Count)
					{
						num2 = xTextElementList.Count - 1;
					}
					break;
				}
			}
			if (p2 < 0)
			{
				p2 = z0cpk.z0srk;
			}
			if (p2 > num2)
			{
				p2 = num2;
			}
			if (p2 < 0)
			{
				p2 = 0;
			}
			num = 0f;
			for (int i = z0cpk.z0srk; i < xTextElementList.Count; i++)
			{
				num += xTextElementList[i].Width;
				if (i == p2)
				{
					((zzz.z0ZzZzkuk<XTextElement>)xTextElementList2).z0pek(xTextElementList[i]);
					continue;
				}
				if (num > p1)
				{
					break;
				}
				((zzz.z0ZzZzkuk<XTextElement>)xTextElementList2).z0pek(xTextElementList[i]);
			}
		}
		else
		{
			((zzz.z0ZzZzkuk<XTextElement>)xTextElementList2).z0tek((zzz.z0ZzZzkuk<XTextElement>)xTextElementList);
		}
		z0cpk.z0yek = xTextElementList.IndexOf(xTextElementList2.LastElement);
	}

	public void z0eek(z0ZzZzscj p0)
	{
		if (p0 == (z0ZzZzscj)1)
		{
			if (z0utk != null)
			{
				((z0cpk)z0utk).z0iek = p0;
			}
		}
		else
		{
			base.z0lrk().z0iek = p0;
		}
	}
}
