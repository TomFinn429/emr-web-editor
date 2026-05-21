using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using DCSoft.Drawing;
using DCSoft.WinForms;
using DCSoft.Writer.Controls;
using DCSoft.Writer.Security;
using DCSystem_Drawing;
using zzz;

namespace DCSoft.Writer.Dom;

[DebuggerDisplay("CheckBox:Group={GroupName} , Checked={Checked}")]
public abstract class XTextCheckBoxElementBase : XTextObjectElement
{
	internal sealed class z0vok : XTextCharElement
	{
		private new XTextCheckBoxElementBase z0rek;

		public XTextCheckBoxElementBase z0eek()
		{
			return z0rek;
		}

		public override bool z0ar(XTextDocument p0, bool p1)
		{
			return true;
		}

		public z0vok(XTextCheckBoxElementBase p0)
		{
			z0rek = p0;
		}

		public override z0ZzZzrzj z0aek()
		{
			return z0rek.z0aek();
		}

		public override XTextDocumentContentElement z0qek()
		{
			return z0rek.z0qek();
		}
	}

	internal sealed class z0cok : XTextContainerElement
	{
		private new int z0rek = -1;

		public new static bool z0tek;

		internal new XTextCheckBoxElementBase z0yek;

		public override void z0bt(XTextDocument p0)
		{
		}

		public override XTextDocument z0jr()
		{
			return z0yek.z0jr();
		}

		public override XTextDocumentContentElement z0qek()
		{
			return z0yek.z0qek();
		}

		public override z0ZzZzrzj z0aek()
		{
			return z0yek.z0aek();
		}

		public override bool z0sek()
		{
			return true;
		}

		public override void z0nu(XTextContainerElement p0)
		{
		}

		public override void z0mu(DocumentEventArgs p0)
		{
			if (p0.Style != DocumentEventStyles.MouseUp)
			{
				_ = p0.Style;
				_ = 4;
			}
			if (p0.Style == DocumentEventStyles.KeyPress && p0.KeyChar == ' ')
			{
				DocumentBehaviorOptions documentBehaviorOptions = z0yek.z0bu();
				if (documentBehaviorOptions == null || !documentBehaviorOptions.DesignMode)
				{
					if (z0yek.Enabled && z0yek.z0tek(p0: false))
					{
						p0.Handled = true;
					}
					return;
				}
			}
			z0yek.z0mu(p0);
		}

		public override string ToString()
		{
			return "CheckboxLayout#" + z0yek.ToString();
		}

		public z0cok(XTextCheckBoxElementBase p0)
		{
			z0tek = true;
			z0yek = p0;
			z0ntk = new XTextElementList();
			z0uik = p0.z0uik;
		}

		public void z0eek()
		{
			if (z0rek == z0yek.z0brk)
			{
				return;
			}
			z0rek = z0yek.z0brk;
			string caption = z0yek.Caption;
			if (caption != null && caption.Length > 0)
			{
				XTextDocument p = z0yek.z0jr();
				if (z0ntk == null)
				{
					z0ntk = new XTextElementList();
				}
				else
				{
					z0ntk.Clear();
				}
				string text = caption;
				foreach (char charValue in text)
				{
					z0vok z0vok = new z0vok(z0yek);
					z0vok.CharValue = charValue;
					z0vok.z0yek(p, this);
					z0vok.z0buk = z0yek.z0buk;
					z0ntk.Add(z0vok);
				}
			}
			else if (z0ntk != null && z0ntk.Count > 0)
			{
				z0ntk.Clear();
			}
		}

		public override XTextElement z0dek()
		{
			if (z0ntk != null && z0ntk.Count > 0)
			{
				return z0ntk[z0ntk.Count - 1];
			}
			return null;
		}

		public override void Dispose()
		{
			z0yek = null;
			base.Dispose();
		}

		public override XTextElement z0ie()
		{
			if (z0ntk != null && z0ntk.Count > 0)
			{
				return z0ntk[0];
			}
			return null;
		}

		public override XTextElement z0hy()
		{
			if (z0ntk != null && z0ntk.Count > 0)
			{
				return z0ntk[0];
			}
			return null;
		}

		public override XTextContainerElement z0ji()
		{
			return z0yek.z0ji();
		}

		public override bool z0ar(XTextDocument p0, bool p1)
		{
			return z0yek.z0ar(p0, p1);
		}

		public override XTextElement z0xt()
		{
			if (z0ntk != null && z0ntk.Count > 0)
			{
				return z0ntk[z0ntk.Count - 1];
			}
			return null;
		}

		public override int z0ue(z0eok_jiejie20260327142557 p0)
		{
			bool flag = true;
			if (p0.z0yek && !z0yek.Checked)
			{
				switch (z0yek.z0bek())
				{
				case PrintVisibilityModeWhenUnchecked.HiddenAll:
					return 0;
				case PrintVisibilityModeWhenUnchecked.HiddenCheckBoxOnly:
					flag = false;
					break;
				}
			}
			z0eek();
			int num = 0;
			if (flag && z0yek.CheckAlignLeft)
			{
				((zzz.z0ZzZzkuk<XTextElement>)p0.z0iek).z0pek((XTextElement)z0yek);
				num++;
			}
			if (z0ntk != null && z0ntk.Count > 0)
			{
				((zzz.z0ZzZzkuk<XTextElement>)p0.z0iek).z0tek((zzz.z0ZzZzkuk<XTextElement>)z0ntk);
				num += z0ntk.Count;
			}
			if (flag && !z0yek.CheckAlignLeft)
			{
				((zzz.z0ZzZzkuk<XTextElement>)p0.z0iek).z0pek((XTextElement)z0yek);
				num++;
			}
			return num;
		}
	}

	internal class z0zjj
	{
		public readonly bool z0eek = true;

		public readonly float z0rek;

		public readonly bool z0tek = true;

		public readonly bool z0yek;

		public readonly string z0uek;

		public readonly z0ZzZzedh z0iek;

		public z0zjj(XTextCheckBoxElementBase p0, z0ZzZzcxj p1)
		{
			if (p1 == (z0ZzZzcxj)3 && !p0.Checked && p0.z0bek() == PrintVisibilityModeWhenUnchecked.HiddenAll)
			{
				z0tek = false;
				z0yek = true;
				return;
			}
			if (!p0.CaptionFlowLayout)
			{
				z0uek = p0.Caption;
			}
			z0eek = true;
			z0iek = z0eek(p0);
			z0rek = z0ZzZzrpk.z0eek(new z0ZzZzxdh(z0iek.z0iek(), z0iek.z0yek()), GraphicsUnit.Pixel, GraphicsUnit.Document).z0rek();
			if (!z0ZzZzvxj.z0eek(p0.CheckboxVisibility, p1))
			{
				z0eek = false;
				z0rek = 0f;
				z0yek = true;
			}
			else if (p0.CheckBoxVisible)
			{
				if (!p0.Checked && (p1 == (z0ZzZzcxj)3 || p1 == (z0ZzZzcxj)5) && p0.z0bek() != PrintVisibilityModeWhenUnchecked.Visible)
				{
					z0eek = false;
					z0rek = 0f;
					z0yek = true;
				}
				if (z0eek && (p1 == (z0ZzZzcxj)5 || p1 == (z0ZzZzcxj)3))
				{
					string text = (p0.Checked ? p0.PrintTextForChecked : p0.PrintTextForUnChecked);
					if (text != null)
					{
						if (text.Length >= 2 && text[0] == '"' && text[text.Length - 1] == '"')
						{
							text = text.Substring(1, text.Length - 2);
						}
						if (text.Length > 0)
						{
							if (p0.CheckAlignLeft)
							{
								z0uek = text + z0uek;
							}
							else
							{
								z0uek += text;
							}
							z0eek = false;
							z0rek = 0f;
							z0yek = true;
						}
					}
				}
			}
			else
			{
				if (!p0.CaptionFlowLayout)
				{
					z0uek = p0.Caption;
				}
				z0eek = false;
				z0rek = 0f;
			}
			if (string.IsNullOrEmpty(z0uek) && z0rek == 0f)
			{
				z0tek = false;
				z0yek = true;
			}
		}
	}

	[NonSerialized]
	private new z0cok z0srk;

	private new string z0ark;

	private new string z0qrk;

	private new string z0wrk;

	private new string z0erk;

	private new z0ZzZzevj z0rrk;

	internal static bool z0trk_jiejie20260327142557 = false;

	private new static readonly z0ZzZzovj z0yrk = z0ZzZzovj.z0iek;

	private new RenderVisibility z0urk = RenderVisibility.All;

	private new StringAlignment z0irk = StringAlignment.Center;

	private new EnableState z0ork = EnableState.Enabled;

	private new z0ZzZzuhh z0prk;

	private new CheckBoxVisualStyle z0mrk;

	internal new z0ZzZzukh z0nrk;

	private new int z0brk;

	private new PrintVisibilityModeWhenUnchecked z0vrk;

	private new CheckBoxControlStyle z0crk;

	[NonSerialized]
	private new object z0xrk;

	private new string z0zrk;

	[ThreadStatic]
	internal new static bool z0ltk;

	private new string z0ktk;

	[NonSerialized]
	private new int z0jtk;

	[DefaultValue(false)]
	public bool Multiline
	{
		get
		{
			return z0guk();
		}
		set
		{
			z0jrk(value);
		}
	}

	[DefaultValue(false)]
	[z0ZzZzbjh]
	public bool CanBeReferenced
	{
		get
		{
			return z0htk();
		}
		set
		{
			z0zek(value);
		}
	}

	[z0ZzZzbjh(MemberEffectLevel.ElementView)]
	[z0ZzZzuqh]
	public override string FormulaValue
	{
		get
		{
			if (Checked)
			{
				return CheckedValue;
			}
			return null;
		}
		set
		{
			bool flag = z0ZzZzafh.z0yek(value, Checked);
			if (flag != Checked)
			{
				EditorChecked = flag;
			}
		}
	}

	[DefaultValue(false)]
	public bool Readonly
	{
		get
		{
			return z0vtk();
		}
		set
		{
			z0oek(value);
		}
	}

	[z0ZzZzbjh(MemberEffectLevel.ElementLayout)]
	[DefaultValue(true)]
	public bool CheckAlignLeft
	{
		get
		{
			return z0wrk();
		}
		set
		{
			z0mrk(value);
		}
	}

	[z0ZzZzuqh]
	[DefaultValue(false)]
	public bool PrintBoxOnlyChecked
	{
		get
		{
			return PrintVisibilityWhenUnchecked == PrintVisibilityModeWhenUnchecked.HiddenCheckBoxOnly;
		}
		set
		{
			if (value)
			{
				PrintVisibilityWhenUnchecked = PrintVisibilityModeWhenUnchecked.HiddenCheckBoxOnly;
			}
			else
			{
				PrintVisibilityWhenUnchecked = PrintVisibilityModeWhenUnchecked.Visible;
			}
		}
	}

	[z0ZzZzuqh]
	public override bool Modified
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

	[DefaultValue(false)]
	[z0ZzZzbjh(MemberEffectLevel.ElementView)]
	public bool Checked
	{
		get
		{
			return z0yyk();
		}
		set
		{
			if (z0yyk() != value)
			{
				z0frk(value);
				base.z0hrk++;
			}
		}
	}

	[DefaultValue(PrintVisibilityModeWhenUnchecked.Visible)]
	public PrintVisibilityModeWhenUnchecked PrintVisibilityWhenUnchecked
	{
		get
		{
			return z0vrk;
		}
		set
		{
			z0vrk = value;
		}
	}

	[DefaultValue(null)]
	public string CheckedValue
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

	[DefaultValue(false)]
	public bool AutoHeightForMultiline
	{
		get
		{
			return z0trk();
		}
		set
		{
			base.z0uek(value);
		}
	}

	[DefaultValue(EnableState.Enabled)]
	public virtual EnableState EnableHighlight
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

	[z0ZzZzbjh]
	[DefaultValue(null)]
	public virtual string DataName
	{
		get
		{
			return z0zrk;
		}
		set
		{
			z0zrk = value;
		}
	}

	[DefaultValue(null)]
	public virtual string GroupName
	{
		get
		{
			return base.Name;
		}
		set
		{
			base.Name = value;
		}
	}

	[DefaultValue(RenderVisibility.All)]
	public RenderVisibility CheckboxVisibility
	{
		get
		{
			return z0urk;
		}
		set
		{
			z0urk = value;
			z0ktk();
		}
	}

	[z0ZzZzuqh]
	public bool InnerEditorChecked
	{
		set
		{
			z0eek(value);
		}
	}

	[DefaultValue(null)]
	public z0ZzZzevj ValueBinding
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

	[DefaultValue(false)]
	[z0ZzZzbjh(MemberEffectLevel.ElementView)]
	public bool DefaultCheckedForValueBinding
	{
		get
		{
			return z0ryk();
		}
		set
		{
			z0iek(value);
		}
	}

	[DefaultValue(true)]
	public bool CheckBoxVisible
	{
		get
		{
			return z0rtk();
		}
		set
		{
			z0ark(value);
			z0ltk = true;
			z0ktk();
		}
	}

	[DefaultValue(CheckBoxVisualStyle.Default)]
	public CheckBoxVisualStyle VisualStyle
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

	[DefaultValue(null)]
	public string PrintTextForChecked
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

	[DefaultValue(null)]
	public string PrintTextForUnChecked
	{
		get
		{
			return z0qrk;
		}
		set
		{
			z0qrk = value;
		}
	}

	[z0ZzZzbjh(MemberEffectLevel.ElementLayout)]
	[DefaultValue(StringAlignment.Center)]
	public StringAlignment CaptionAlign
	{
		get
		{
			return z0irk;
		}
		set
		{
			z0irk = value;
		}
	}

	[DefaultValue(false)]
	[z0ZzZzbjh(MemberEffectLevel.ElementLayout)]
	public bool CaptionFlowLayout
	{
		get
		{
			return z0vyk();
		}
		set
		{
			z0pek(value);
			z0brk++;
		}
	}

	[DefaultValue(null)]
	[z0ZzZzbjh(MemberEffectLevel.ElementLayout)]
	public string Caption
	{
		get
		{
			return z0ktk;
		}
		set
		{
			z0ktk = value;
			z0brk++;
			z0ktk();
		}
	}

	[z0ZzZzuqh]
	public string Value
	{
		get
		{
			if (Checked)
			{
				return CheckedValue;
			}
			return null;
		}
		set
		{
			if (value == CheckedValue)
			{
				Checked = true;
			}
			else
			{
				Checked = false;
			}
		}
	}

	[DefaultValue(null)]
	[z0ZzZzrqh("Item", typeof(z0ZzZzyhh))]
	public z0ZzZzuhh CheckedUserHistories
	{
		get
		{
			return z0prk;
		}
		set
		{
			z0prk = value;
		}
	}

	[z0ZzZzbjh]
	[DefaultValue(false)]
	public bool BringoutToSave
	{
		get
		{
			return z0jtk();
		}
		set
		{
			z0irk(value);
		}
	}

	[DefaultValue(false)]
	public bool Requried
	{
		get
		{
			return z0iyk();
		}
		set
		{
			z0qrk(value);
		}
	}

	[z0ZzZzuqh]
	public virtual bool EditorChecked
	{
		get
		{
			return Checked;
		}
		set
		{
			z0uek(value);
		}
	}

	[z0ZzZzuqh]
	public override string Text
	{
		get
		{
			return Caption;
		}
		set
		{
			Caption = value;
		}
	}

	public void z0eek(z0ZzZzukh p0)
	{
		z0nrk = p0;
	}

	public override void z0mr(z0ZzZzvxj p0)
	{
		z0cok z0cok = z0jrk();
		if (z0cok != null)
		{
			z0cok.z0eek();
			z0cok.z0mr(p0);
		}
		if (z0nek())
		{
			z0rek(p0: false);
			float p1 = Width;
			if (Width <= 0f)
			{
				p1 = ((z0jy() != null) ? ((XTextElement)z0jy()).z0ork() : ((XTextElement)z0jr().z0xyk()).z0ork());
			}
			bool p2 = false;
			z0ZzZzxdh z0ZzZzxdh = z0eek(p0, p1, ref p2);
			Multiline = p2;
			Width = z0ZzZzxdh.z0rek();
			Height = z0ZzZzxdh.z0tek();
			z0xi(p0: false);
			return;
		}
		if (z0pek() && AutoHeightForMultiline)
		{
			float p3 = Width;
			if (Width <= 0f)
			{
				p3 = ((z0jy() != null) ? ((XTextElement)z0jy()).z0ork() : ((XTextElement)z0jr().z0xyk()).z0ork());
			}
			bool p4 = false;
			z0ZzZzxdh z0ZzZzxdh2 = z0eek(p0, p3, ref p4);
			Width = z0ZzZzxdh2.z0rek();
			Height = z0ZzZzxdh2.z0tek();
		}
		else if (!z0pek() || Width <= 0f || Height <= 0f)
		{
			bool p5 = false;
			z0ZzZzxdh z0ZzZzxdh3 = z0eek(p0, 10000f, ref p5);
			Width = z0ZzZzxdh3.z0rek();
			Height = z0ZzZzxdh3.z0tek();
			if (z0cok != null && z0cok.z0crk())
			{
				Height = Math.Max(Height, z0cok.z0be()[0].Height);
			}
		}
		z0xi(p0: false);
	}

	public new XTextElementList z0eek()
	{
		if (z0jr() == null)
		{
			return null;
		}
		if (string.IsNullOrEmpty(z0tek()))
		{
			return new XTextElementList(this);
		}
		XTextElementList xTextElementList = null;
		for (XTextContainerElement xTextContainerElement = z0ji(); xTextContainerElement != null; xTextContainerElement = xTextContainerElement.z0ji())
		{
			if (xTextContainerElement is XTextSectionElement)
			{
				xTextElementList = ((XTextSectionElement)xTextContainerElement).z0yek().z0eek(this);
				if (xTextElementList != null && xTextElementList.Count > 0)
				{
					break;
				}
			}
			else if (xTextContainerElement is XTextDocument)
			{
				xTextElementList = ((XTextDocument)xTextContainerElement).z0mok().z0eek(this);
				break;
			}
		}
		if (xTextElementList == null || xTextElementList.Count == 0)
		{
			xTextElementList = new XTextElementList();
			xTextElementList.Add(this);
		}
		return xTextElementList;
	}

	public string z0eek(char p0 = ',')
	{
		if (z0jr() == null)
		{
			return null;
		}
		XTextElementList xTextElementList = z0eek();
		if (xTextElementList.Count == 1 && Checked && string.IsNullOrEmpty(CheckedValue))
		{
			return "true";
		}
		StringBuilder stringBuilder = new StringBuilder();
		using (zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = xTextElementList.z0ltk())
		{
			while (z0bpk.MoveNext())
			{
				XTextCheckBoxElementBase xTextCheckBoxElementBase = (XTextCheckBoxElementBase)z0bpk.Current;
				if (!xTextCheckBoxElementBase.Checked)
				{
					continue;
				}
				if (xTextCheckBoxElementBase.CheckedValue != null && xTextCheckBoxElementBase.CheckedValue.Length > 0)
				{
					if (stringBuilder.Length > 0)
					{
						stringBuilder.Append(p0);
					}
					stringBuilder.Append(xTextCheckBoxElementBase.CheckedValue);
				}
				if (xTextCheckBoxElementBase is XTextRadioBoxElement)
				{
					break;
				}
			}
		}
		return stringBuilder.ToString();
	}

	public override bool z0ui()
	{
		return false;
	}

	internal new string z0rek()
	{
		return z0zek();
	}

	private static z0ZzZzrfh z0eek(XTextCheckBoxElementBase p0)
	{
		switch (z0rek(p0))
		{
		case CheckBoxVisualStyle.SystemCheckBox:
			if (p0.Checked)
			{
				return z0yrk.z0eek();
			}
			return z0yrk.z0tek();
		case CheckBoxVisualStyle.SystemRadioBox:
			if (p0.Checked)
			{
				return z0yrk.z0uek();
			}
			return z0yrk.z0yek();
		case CheckBoxVisualStyle.CheckBox:
			if (p0.Checked)
			{
				return z0yrk.BmpCheckBoxChecked;
			}
			return z0yrk.BmpCheckBoxUnchecked;
		default:
			if (p0.Checked)
			{
				return z0yrk.BmpRadioBoxChecked;
			}
			return z0yrk.BmpRadioBoxUnchecked;
		}
	}

	public override void Dispose()
	{
		base.Dispose();
		if (z0srk != null)
		{
			z0srk.Dispose();
			z0srk = null;
		}
		z0ktk = null;
		z0xrk = null;
		z0zrk = null;
		if (z0nrk != null)
		{
			z0nrk.Clear();
			z0nrk = null;
		}
		z0wrk = null;
		z0qrk = null;
		z0ark = null;
		z0rrk = null;
		z0erk = null;
	}

	public override string ToString()
	{
		if (XTextElement.z0euk)
		{
			return z0ti();
		}
		if (z0oi() == CheckBoxControlStyle.CheckBox)
		{
			return "CheckBox:" + Checked;
		}
		return "Radio:" + Checked;
	}

	public virtual void z0pi(object p0, ContentChangedEventArgs p1)
	{
		if (!p1.LoadingDocument)
		{
			Modified = true;
		}
		if (!p1.LoadingDocument)
		{
			z0jr().z0rik()?.z0rw(this, p1: true);
		}
		if (z0bu().EnableElementEvents && z0jr().z0puk())
		{
			p1.Element = this;
			z0cu()?.z0eek(p1);
			if (z0ji() != null)
			{
				z0ji().z0zi(p1);
			}
		}
	}

	public new string z0tek()
	{
		if (!string.IsNullOrEmpty(base.Name))
		{
			return base.Name;
		}
		if (ValueBinding != null && !ValueBinding.IsEmptyBinding)
		{
			return ValueBinding.DataSource + "#" + ValueBinding.BindingPath;
		}
		return ID;
	}

	public new z0ZzZzxdh z0yek()
	{
		int num = z0krk()?.z0iek() ?? 20;
		return z0ZzZzrpk.z0eek(new z0ZzZzxdh(num, num), GraphicsUnit.Pixel, GraphicsUnit.Document);
	}

	public override void z0et(ResizeableType p0)
	{
		base.z0et(p0);
	}

	public new z0ZzZzukh z0uek()
	{
		return z0nrk;
	}

	public new EnableState z0iek()
	{
		EnableState enableState = EnableHighlight;
		if (enableState == EnableState.Default && z0jr() != null)
		{
			enableState = z0iu().DefaultInputFieldHighlight;
		}
		if (enableState == EnableState.Default)
		{
			enableState = EnableState.Enabled;
		}
		return enableState;
	}

	public new void z0eek(bool p0)
	{
		if (Checked != p0)
		{
			ContentChangingEventArgs e = new ContentChangingEventArgs();
			e.Document = z0jr();
			e.Tag = this;
			z0eek(this, e);
			if (!e.Cancel)
			{
				Checked = p0;
				ContentChangedEventArgs e2 = new ContentChangedEventArgs();
				e2.Document = z0jr();
				e2.Tag = this;
				z0pi(this, e2);
				z0jo();
			}
		}
	}

	private void z0rek(bool p0)
	{
		z0cek(p0);
	}

	public new CheckBoxVisualStyle z0oek()
	{
		return z0rek(this);
	}

	public override void z0ye(ElementEventArgs p0)
	{
		z0ri();
		base.z0ye(p0);
	}

	public new bool z0pek()
	{
		return Multiline;
	}

	internal static XTextElement z0eek(XTextElement p0)
	{
		if (p0 is z0vok)
		{
			z0cok z0cok = (z0cok)p0.z0ji();
			if (z0cok != null)
			{
				return z0cok.z0yek;
			}
		}
		return p0;
	}

	public override XTextElement z0lr(bool p0)
	{
		XTextCheckBoxElementBase xTextCheckBoxElementBase = (XTextCheckBoxElementBase)base.z0lr(p0);
		if (z0nrk != null)
		{
			xTextCheckBoxElementBase.z0nrk = z0nrk.z0rek();
		}
		if (z0rrk != null)
		{
			xTextCheckBoxElementBase.z0rrk = z0rrk.Clone();
		}
		xTextCheckBoxElementBase.z0jtk = -1;
		xTextCheckBoxElementBase.z0srk = null;
		if (z0prk != null)
		{
			xTextCheckBoxElementBase.z0prk = new z0ZzZzuhh();
			foreach (z0ZzZzyhh item in z0prk)
			{
				xTextCheckBoxElementBase.z0prk.Add(item.z0lrk());
			}
		}
		return xTextCheckBoxElementBase;
	}

	public new object z0mek()
	{
		return z0xrk;
	}

	private bool z0tek(bool p0)
	{
		if (base.Enabled && !Readonly && z0jr().z0xek().z0pm(this, (z0ZzZzbcj)239))
		{
			if (z0cu() != null && z0cu().z0ook() != FormViewMode.Strict && p0)
			{
				z0qek().z0frk().z0tek(this);
			}
			z0uek(!Checked);
			return true;
		}
		return false;
	}

	private z0ZzZzxdh z0eek(z0ZzZzvxj p0, float p1, ref bool p2)
	{
		z0jr();
		z0ZzZzcdh z0ZzZzcdh = z0ZzZzrpk.z0eek(new z0ZzZzcdh(20, 20), GraphicsUnit.Pixel, GraphicsUnit.Document);
		z0ZzZzxdh result = new z0ZzZzxdh(z0ZzZzcdh.z0rek(), z0ZzZzcdh.z0tek());
		z0zjj z0zjj = new z0zjj(this, p0.z0byk);
		if (!z0zjj.z0eek)
		{
			result.z0eek(0f);
		}
		if (z0zjj.z0uek != null && z0zjj.z0uek.Length > 0)
		{
			z0ZzZzrzj z0ZzZzrzj = z0aek();
			z0ZzZzxdh z0ZzZzxdh = p0.z0eek(z0zjj.z0uek, z0ZzZzrzj, (int)(p1 - result.z0rek()), p0.z0yyk.z0pek());
			if (!Multiline && z0zjj.z0uek.Length > 3)
			{
				z0ZzZzxdh.z0eek(z0ZzZzxdh.z0rek() * 1.04f);
			}
			result.z0eek(result.z0rek() + z0ZzZzxdh.z0rek() + 10f);
			float num = p0.z0eek(z0ZzZzrzj);
			if (z0ZzZzxdh.z0tek() > num)
			{
				result.z0rek(z0ZzZzxdh.z0tek());
				p2 = true;
			}
			else
			{
				result.z0rek(num);
				p2 = false;
			}
		}
		if (z0zjj.z0eek && z0zjj.z0rek > 0f && z0zjj.z0rek > result.z0tek())
		{
			result.z0rek(z0zjj.z0rek);
		}
		return result;
	}

	public override void z0oy(ElementEventArgs p0)
	{
		z0ri();
		base.z0oy(p0);
	}

	public new void z0yek(bool p0)
	{
		z0ork(p0);
	}

	public new void z0eek(object p0)
	{
		z0xrk = p0;
	}

	private static CheckBoxVisualStyle z0rek(XTextCheckBoxElementBase p0)
	{
		if (p0.VisualStyle == CheckBoxVisualStyle.Default || !z0ZzZzxcj.z0eek(193))
		{
			if (p0.z0oi() == CheckBoxControlStyle.CheckBox)
			{
				return CheckBoxVisualStyle.CheckBox;
			}
			if (p0.z0oi() == CheckBoxControlStyle.RadioBox)
			{
				return CheckBoxVisualStyle.RadioBox;
			}
			return CheckBoxVisualStyle.CheckBox;
		}
		if (p0.VisualStyle == CheckBoxVisualStyle.SystemDefault)
		{
			if (p0.z0oi() == CheckBoxControlStyle.CheckBox)
			{
				return CheckBoxVisualStyle.SystemCheckBox;
			}
			if (p0.z0oi() == CheckBoxControlStyle.RadioBox)
			{
				return CheckBoxVisualStyle.SystemRadioBox;
			}
			return CheckBoxVisualStyle.SystemCheckBox;
		}
		if (p0.VisualStyle == CheckBoxVisualStyle.CheckBox)
		{
			return CheckBoxVisualStyle.CheckBox;
		}
		if (p0.VisualStyle == CheckBoxVisualStyle.RadioBox)
		{
			return CheckBoxVisualStyle.RadioBox;
		}
		if (p0.VisualStyle == CheckBoxVisualStyle.SystemCheckBox)
		{
			return CheckBoxVisualStyle.SystemCheckBox;
		}
		if (p0.VisualStyle == CheckBoxVisualStyle.SystemRadioBox)
		{
			return CheckBoxVisualStyle.SystemRadioBox;
		}
		return CheckBoxVisualStyle.CheckBox;
	}

	public override object z0lek()
	{
		if (z0ji() == null)
		{
			return null;
		}
		if (z0iek() == EnableState.Disabled)
		{
			return null;
		}
		XTextElementList xTextElementList = z0eek();
		if (xTextElementList == null || xTextElementList.Count <= 1)
		{
			return null;
		}
		Color p = Color.Transparent;
		DocumentViewOptions documentViewOptions = z0iu();
		using (zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = xTextElementList.z0ltk())
		{
			while (z0bpk.MoveNext())
			{
				if (((XTextCheckBoxElementBase)z0bpk.Current).z0fek())
				{
					p = documentViewOptions.FieldFocusedBackColor;
					break;
				}
			}
		}
		if (p.A == 0)
		{
			XTextElement xTextElement = z0eek(z0jr().z0etk());
			if (xTextElement != null && xTextElementList.Contains(xTextElement))
			{
				p = documentViewOptions.FieldHoverBackColor;
			}
		}
		if (p.A != 0)
		{
			z0ZzZzwxj z0ZzZzwxj = new z0ZzZzwxj();
			using zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = xTextElementList.z0ltk();
			while (z0bpk.MoveNext())
			{
				XTextCheckBoxElementBase xTextCheckBoxElementBase = (XTextCheckBoxElementBase)z0bpk.Current;
				XTextDocumentContentElement xTextDocumentContentElement = xTextCheckBoxElementBase.z0qek();
				if (xTextDocumentContentElement != null)
				{
					z0ZzZzkkh z0ZzZzkkh = null;
					z0ZzZzkkh = ((!xTextCheckBoxElementBase.CaptionFlowLayout || xTextCheckBoxElementBase.z0srk == null || xTextCheckBoxElementBase.z0srk.z0xek() <= 0) ? new z0ZzZzkkh(xTextDocumentContentElement, ((XTextElement)xTextCheckBoxElementBase).z0jrk(), 1) : ((!CheckAlignLeft) ? new z0ZzZzkkh(xTextDocumentContentElement, xTextCheckBoxElementBase.z0srk.z0dtk().z0jrk(), xTextCheckBoxElementBase.z0srk.z0xek() + 1) : new z0ZzZzkkh(xTextDocumentContentElement, ((XTextElement)xTextCheckBoxElementBase).z0jrk(), xTextCheckBoxElementBase.z0srk.z0xek() + 1)));
					z0ZzZzqxj z0ZzZzqxj = new z0ZzZzqxj(xTextCheckBoxElementBase, z0ZzZzkkh, p);
					z0ZzZzqxj.z0eek(z0aek().z0bek);
					z0ZzZzwxj.Add(z0ZzZzqxj);
				}
			}
			return z0ZzZzwxj;
		}
		return null;
	}

	public override bool z0fek()
	{
		if (z0uik == null)
		{
			return false;
		}
		XTextDocumentContentElement xTextDocumentContentElement = z0qek();
		if (xTextDocumentContentElement == null)
		{
			return false;
		}
		return z0eek(xTextDocumentContentElement.z0zek()) == this;
	}

	protected XTextCheckBoxElementBase()
	{
		CheckAlignLeft = true;
		CheckBoxVisible = true;
	}

	public override void z0qi(bool p0)
	{
		z0cuk = p0;
	}

	public new void z0uek(bool p0)
	{
		if (Checked == p0)
		{
			return;
		}
		XTextDocument xTextDocument = z0jr();
		z0ZzZzpxj z0ZzZzpxj = xTextDocument.z0xek();
		if (z0ZzZzpxj != null && !z0ZzZzpxj.z0np(this))
		{
			return;
		}
		if (!p0 && z0trk_jiejie20260327142557 && this is XTextRadioBoxElement)
		{
			XTextElementList xTextElementList = z0eek();
			bool flag = false;
			using (zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = xTextElementList.z0ltk())
			{
				while (z0bpk.MoveNext())
				{
					XTextCheckBoxElementBase xTextCheckBoxElementBase = (XTextCheckBoxElementBase)z0bpk.Current;
					if (xTextCheckBoxElementBase.Checked && xTextCheckBoxElementBase != this)
					{
						flag = true;
						break;
					}
				}
			}
			if (!flag)
			{
				return;
			}
		}
		XTextElementList xTextElementList2 = new XTextElementList();
		if (p0 && z0oi() == CheckBoxControlStyle.RadioBox)
		{
			xTextElementList2 = z0eek();
			for (int num = xTextElementList2.Count - 1; num >= 0; num--)
			{
				XTextCheckBoxElementBase xTextCheckBoxElementBase2 = (XTextCheckBoxElementBase)xTextElementList2[num];
				if (z0ZzZzpxj == null || !z0ZzZzpxj.z0np(xTextCheckBoxElementBase2))
				{
					xTextElementList2.RemoveAt(num);
				}
				else if (xTextCheckBoxElementBase2 != this && !xTextCheckBoxElementBase2.Checked)
				{
					xTextElementList2.RemoveAt(num);
				}
			}
			if (xTextElementList2.Contains(this))
			{
				xTextElementList2.z0cek(this);
				xTextElementList2.Add(this);
			}
		}
		else
		{
			xTextElementList2.Add(this);
		}
		ContentChangingEventArgs e = new ContentChangingEventArgs();
		e.Document = xTextDocument;
		e.Tag = this;
		e.Element = this;
		using (zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = xTextElementList2.z0ltk())
		{
			while (z0bpk.MoveNext())
			{
				((XTextCheckBoxElementBase)z0bpk.Current).z0eek(this, e);
				if (e.Cancel)
				{
					return;
				}
			}
		}
		z0ZzZzyhh z0ZzZzyhh = null;
		if (xTextDocument.z0hi().EnablePermission)
		{
			z0ZzZzyhh = xTextDocument.z0syk()?.z0eek();
		}
		if (xTextDocument.z0ytk())
		{
			using (zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = xTextElementList2.z0ltk())
			{
				while (z0bpk.MoveNext())
				{
					XTextCheckBoxElementBase xTextCheckBoxElementBase3 = (XTextCheckBoxElementBase)z0bpk.Current;
					xTextDocument.z0imk().z0eek("InnerEditorChecked", xTextCheckBoxElementBase3.Checked, !xTextCheckBoxElementBase3.Checked, xTextCheckBoxElementBase3);
					xTextCheckBoxElementBase3.Checked = !xTextCheckBoxElementBase3.Checked;
					if (z0ZzZzyhh != null)
					{
						xTextCheckBoxElementBase3.z0eek(z0ZzZzyhh);
					}
				}
			}
			xTextDocument.z0nuk();
		}
		else
		{
			using zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = xTextElementList2.z0ltk();
			while (z0bpk.MoveNext())
			{
				XTextCheckBoxElementBase xTextCheckBoxElementBase4 = (XTextCheckBoxElementBase)z0bpk.Current;
				xTextCheckBoxElementBase4.Checked = !xTextCheckBoxElementBase4.Checked;
				if (z0ZzZzyhh != null)
				{
					xTextCheckBoxElementBase4.z0eek(z0ZzZzyhh);
				}
			}
		}
		z0ZzZzqbj z0ZzZzqbj = z0uyk();
		using (zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = xTextElementList2.z0ltk())
		{
			while (z0bpk.MoveNext())
			{
				XTextCheckBoxElementBase xTextCheckBoxElementBase5 = (XTextCheckBoxElementBase)z0bpk.Current;
				ContentChangedEventArgs e2 = new ContentChangedEventArgs();
				e2.Document = xTextDocument;
				e2.Element = this;
				e2.Tag = this;
				((z0ZzZzxnj)z0ZzZzqbj)?.z0tek(p0: false);
				try
				{
					xTextCheckBoxElementBase5.z0pi(xTextCheckBoxElementBase5, e2);
				}
				finally
				{
					((z0ZzZzxnj)z0ZzZzqbj)?.z0tek(p0: false);
				}
				xTextCheckBoxElementBase5.z0jo();
			}
		}
		xTextDocument.Modified = true;
		xTextDocument.OnDocumentContentChanged();
		if (z0cu() != null)
		{
			z0cu().z0eek(ID, base.Name, Checked ? CheckedValue : string.Empty, this);
		}
	}

	private new bool z0nek()
	{
		return z0syk();
	}

	public new PrintVisibilityModeWhenUnchecked z0bek()
	{
		if (z0vrk != PrintVisibilityModeWhenUnchecked.Visible && z0ZzZzxcj.z0eek(192))
		{
			return z0vrk;
		}
		return PrintVisibilityModeWhenUnchecked.Visible;
	}

	public override XTextElement z0ie()
	{
		if (CaptionFlowLayout && !CheckAlignLeft && z0srk != null)
		{
			XTextElement xTextElement = z0srk.z0dtk();
			if (xTextElement != null)
			{
				return xTextElement;
			}
		}
		return this;
	}

	public void z0eek(string p0)
	{
		z0ark = p0;
	}

	public virtual void z0ii(CheckBoxControlStyle p0)
	{
		z0crk = p0;
	}

	internal static void z0eek(XTextElementList p0, XTextDocument p1)
	{
		if (p1 != null)
		{
			DocumentSecurityOptions documentSecurityOptions = p1.z0hi();
			if (documentSecurityOptions != null && documentSecurityOptions.EnableLogicDelete)
			{
				z0eek(p0);
			}
		}
	}

	public override void z0mu(DocumentEventArgs p0)
	{
		bool designMode = z0bu().DesignMode;
		if (p0.Style == DocumentEventStyles.MouseClick)
		{
			if (designMode)
			{
				base.z0mu(p0);
			}
			else if (base.Enabled)
			{
				if (z0tek(p0: true))
				{
					p0.Handled = true;
					return;
				}
				base.z0mu(p0);
			}
			p0.Handled = true;
		}
		else if (p0.Style == DocumentEventStyles.MouseMove)
		{
			if (z0cu() != null)
			{
				if (!z0pek())
				{
					p0.Cursor = z0ZzZzbwh.z0krk;
				}
				else
				{
					base.z0mu(p0);
				}
				p0.Handled = true;
			}
		}
		else if (p0.Style == DocumentEventStyles.MouseDown)
		{
			base.z0mu(p0);
			if (base.Enabled && !designMode)
			{
				p0.Handled = true;
			}
		}
		else
		{
			base.z0mu(p0);
		}
	}

	public new bool z0vek()
	{
		return z0vrk();
	}

	internal void z0eek(string p0, string p1)
	{
		if (z0prk == null)
		{
			z0prk = new z0ZzZzuhh();
		}
		z0ZzZzyhh z0ZzZzyhh = new z0ZzZzyhh();
		z0ZzZzyhh.z0eek(Checked);
		z0ZzZzyhh.z0tek(p0);
		z0ZzZzyhh.z0uek(p1);
		if (z0jr() != null)
		{
			z0ZzZzyhh.z0tek(z0jr().z0jpk());
		}
		else
		{
			z0ZzZzyhh.z0tek(DateTime.Now);
		}
		z0prk.Add(z0ZzZzyhh);
	}

	private void z0eek(z0ZzZzyhh p0)
	{
		if (p0 == null)
		{
			return;
		}
		if (z0prk != null && z0prk.Count > 0)
		{
			z0ZzZzyhh z0ZzZzyhh = z0prk[z0prk.Count - 1];
			if (z0ZzZzyhh.z0wrk == p0 && z0ZzZzyhh.z0vek() != Checked)
			{
				z0prk.RemoveAt(z0prk.Count - 1);
				return;
			}
		}
		z0ZzZzyhh z0ZzZzyhh2 = p0.z0lrk();
		z0ZzZzyhh2.z0wrk = p0;
		z0ZzZzyhh2.z0eek(Checked);
		z0ZzZzyhh2.z0tek(z0jr().z0jpk());
		z0ZzZzyhh2.z0eek(p0.z0rek());
		z0ZzZzyhh2.z0tek(p0.z0zek());
		z0ZzZzyhh2.z0uek(p0.z0yek());
		z0ZzZzyhh2.z0eek(p0.z0mek());
		if (z0prk == null)
		{
			z0prk = new z0ZzZzuhh();
		}
		z0prk.Add(z0ZzZzyhh2);
	}

	internal static void z0eek(XTextElementList p0)
	{
	}

	public override string z0iy()
	{
		switch (z0iu().DefaultAdornTextType)
		{
		case InputFieldAdornTextType.Default:
			return null;
		case InputFieldAdornTextType.DataSource:
			if (ValueBinding != null && !ValueBinding.IsEmptyBinding)
			{
				return ValueBinding.DataSource + "#" + ValueBinding.BindingPath;
			}
			return null;
		case InputFieldAdornTextType.ToolTip:
			return base.ToolTip;
		case InputFieldAdornTextType.ID:
			return ID;
		case InputFieldAdornTextType.Name:
			return base.Name;
		default:
			return null;
		}
	}

	internal new void z0cek()
	{
		z0rek(p0: true);
	}

	public override string z0ti()
	{
		if (CheckAlignLeft)
		{
			return z0rek() + Caption;
		}
		return Caption + z0rek();
	}

	public override void z0nw(z0ZzZzuzj p0)
	{
		base.z0nw(p0);
		p0.z0eek(z0ktk);
		p0.z0eek((byte)z0mrk);
		p0.z0eek((byte)z0urk);
		p0.z0eek(CheckBoxVisible);
		p0.z0eek((byte)z0crk);
		p0.z0eek(z0zrk);
	}

	private string z0rek(string p0)
	{
		if (p0 == null || string.IsNullOrEmpty(p0))
		{
			return p0;
		}
		if (p0.Length > 2 && p0[0] == '"' && p0[p0.Length - 1] == '"')
		{
			return p0.Substring(1, p0.Length - 2);
		}
		return p0;
	}

	public override bool z0hr()
	{
		if (CaptionFlowLayout)
		{
			base.z0xek();
			z0cok z0cok = z0jrk();
			if (z0cok != null)
			{
				z0cok.z0eek();
				z0ZzZzplh z0ZzZzplh = z0qek().z0frk();
				int num = z0ZzZzplh.z0bek(z0cok.z0dtk());
				int num2 = z0ZzZzplh.z0bek(z0cok.z0zek());
				int num3 = z0ZzZzplh.z0bek(this);
				if (num >= 0 && num2 >= 0)
				{
					if (num3 < num)
					{
						z0ZzZzplh.z0tek(num3, num2 - num3 + 1);
					}
					else if (num3 > num2)
					{
						z0ZzZzplh.z0tek(num, num3 - num + 1);
					}
					else
					{
						z0ZzZzplh.z0tek(num2, num2 - num + 1);
					}
					return true;
				}
			}
			return false;
		}
		return base.z0hr();
	}

	public override void z0ri()
	{
		XTextDocument xTextDocument = z0jr();
		if (string.IsNullOrEmpty(GroupName) || xTextDocument.z0htk() == null || z0iu().FieldFocusedBackColor.A == 0)
		{
			return;
		}
		using zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = z0eek().z0ltk();
		while (z0bpk.MoveNext())
		{
			XTextCheckBoxElementBase xTextCheckBoxElementBase = (XTextCheckBoxElementBase)z0bpk.Current;
			if (xTextCheckBoxElementBase.CaptionFlowLayout && xTextCheckBoxElementBase.z0srk != null && xTextCheckBoxElementBase.z0srk.z0xek() > 0)
			{
				((XTextElement)xTextDocument).z0uyk()?.z0tek(xTextCheckBoxElementBase.z0srk.z0be());
			}
			xTextDocument.z0htk()?.z0co(xTextCheckBoxElementBase);
			xTextCheckBoxElementBase.z0jo();
		}
	}

	public new string z0xek()
	{
		return z0ark;
	}

	public new string z0zek()
	{
		if (!Checked && z0bek() != PrintVisibilityModeWhenUnchecked.Visible)
		{
			return "  ";
		}
		string text = (Checked ? z0rek(PrintTextForChecked) : z0rek(PrintTextForUnChecked));
		if (!string.IsNullOrEmpty(text))
		{
			return text;
		}
		if (!string.IsNullOrEmpty(PrintTextForChecked))
		{
			if (Checked)
			{
				return PrintTextForChecked;
			}
			return string.Empty;
		}
		bool flag = z0oi() == CheckBoxControlStyle.CheckBox;
		if (VisualStyle == CheckBoxVisualStyle.CheckBox || VisualStyle == CheckBoxVisualStyle.SystemCheckBox)
		{
			flag = true;
		}
		else if (VisualStyle == CheckBoxVisualStyle.RadioBox || VisualStyle == CheckBoxVisualStyle.SystemRadioBox)
		{
			flag = false;
		}
		if (flag)
		{
			if (Checked)
			{
				return "■";
			}
			return "□";
		}
		if (Checked)
		{
			return "●";
		}
		return "○";
	}

	public new CheckBoxVisualStyle z0lrk()
	{
		return z0oek();
	}

	public override void z0rt(ElementLoadEventArgs p0)
	{
		base.z0rt(p0);
		if (ValueBinding != null && ValueBinding.z0yek())
		{
			z0ZzZzrlh z0ZzZzrlh = new z0ZzZzrlh();
			z0ZzZzrlh.z0rek(p0: true);
			z0eek(z0ZzZzrlh);
		}
	}

	public virtual int z0eek(z0ZzZzrlh p0)
	{
		return XTextDocument.z0mpk().z0xb(this, p0);
	}

	internal z0zjj z0eek(z0ZzZzcxj p0)
	{
		return new z0zjj(this, p0);
	}

	public new z0ZzZzrfh z0krk()
	{
		return z0eek(this);
	}

	public override XTextElement z0hy()
	{
		if (CaptionFlowLayout && !CheckAlignLeft && z0srk != null)
		{
			XTextElement xTextElement = z0srk.z0dtk();
			if (xTextElement != null)
			{
				return xTextElement;
			}
		}
		return this;
	}

	private new z0cok z0jrk()
	{
		if (CaptionFlowLayout)
		{
			string caption = Caption;
			if (caption != null && caption.Length > 0)
			{
				if (z0srk == null)
				{
					z0srk = new z0cok(this);
				}
				z0srk.z0oek(this);
				return z0srk;
			}
		}
		else if (z0srk != null)
		{
			XTextElement item = z0jr()?.z0etk();
			if (z0srk.z0be().Contains(item))
			{
				z0jr().z0hrk((XTextElement)null);
			}
			z0srk.Dispose();
			z0srk = null;
		}
		return null;
	}

	public override ResizeableType z0wt()
	{
		if (z0pek())
		{
			if (AutoHeightForMultiline)
			{
				return ResizeableType.Width;
			}
			return ResizeableType.WidthAndHeight;
		}
		return ResizeableType.FixSize;
	}

	public override string z0gy()
	{
		if (CaptionFlowLayout)
		{
			return string.Empty;
		}
		return Text;
	}

	public override void z0wi(string p0)
	{
	}

	public virtual void z0eek(object p0, ContentChangingEventArgs p1)
	{
	}

	internal new bool z0hrk()
	{
		if (z0prk != null)
		{
			return z0prk.Count > 0;
		}
		return false;
	}

	public override void z0ko(ElementEventArgs p0)
	{
		if (!string.IsNullOrEmpty(GroupName))
		{
			z0ri();
		}
		else
		{
			z0jr().z0htk().z0qp(this);
		}
		base.z0ko(p0);
	}

	public override z0ZzZzonj z0qt()
	{
		if (z0prk != null && z0prk.Count > 0 && z0hi().ShowPermissionTip)
		{
			StringBuilder stringBuilder = new StringBuilder();
			foreach (z0ZzZzyhh item in z0prk)
			{
				if (stringBuilder.Length > 0)
				{
					stringBuilder.Append(Environment.NewLine);
				}
				if (item.z0vek())
				{
					stringBuilder.Append($"{item.z0cek()}被{item.z0yek()}勾选。");
				}
				else
				{
					stringBuilder.Append($"{item.z0cek()}被{item.z0yek()}去掉勾选。");
				}
			}
			return z0yek(stringBuilder.ToString());
		}
		z0ZzZzonj z0ZzZzonj = base.z0qt();
		if (z0ZzZzonj == null && !string.IsNullOrEmpty(base.ToolTip))
		{
			z0ZzZzonj = new z0ZzZzonj(this, base.ToolTip);
			z0ZzZzonj.z0eek(ToolTipContentType.ElementToolTip);
		}
		return z0ZzZzonj;
	}

	public override VerticalAlignStyle z0ay()
	{
		return VerticalAlignStyle.Bottom;
	}

	public new string z0grk()
	{
		if (!string.IsNullOrEmpty(ID))
		{
			return ID;
		}
		return base.Name;
	}

	public override void z0fy(z0ZzZzdxj p0)
	{
		p0.z0eek(z0ti());
	}

	public virtual CheckBoxControlStyle z0oi()
	{
		return z0crk;
	}

	internal new void z0eek(int p0)
	{
		z0jtk = p0;
	}

	public override void z0vw(z0ZzZzvxj p0)
	{
		z0zjj z0zjj = new z0zjj(this, p0.z0byk);
		if (!z0zjj.z0tek)
		{
			return;
		}
		z0ZzZzbdh z0ZzZzbdh = z0qyk();
		if (z0zjj.z0eek && z0zjj.z0iek != null)
		{
			float num = z0ZzZzbdh.z0oek() + 4f;
			if (!CheckAlignLeft)
			{
				num = z0ZzZzbdh.z0mek() - z0zjj.z0rek - 4f;
			}
			XTextDocument.z0axk = true;
			z0ZzZzdpk.z0eek(p0.z0gyk, z0zjj.z0iek, (int)num, (int)(z0ZzZzbdh.z0pek() + (z0ZzZzbdh.z0iek() - z0zjj.z0rek) / 2f));
			XTextDocument.z0axk = false;
			if (p0.z0wtk && z0prk != null && z0prk.Count > 0)
			{
				p0.z0gyk.z0rek(z0ZzZzidh.z0cek, new z0ZzZzbdh(num, z0ZzZzbdh.z0pek(), z0zjj.z0rek, z0zjj.z0rek));
			}
		}
		if (z0zjj.z0uek == null || z0zjj.z0uek.Length <= 0)
		{
			return;
		}
		z0ZzZzrzj z0ZzZzrzj = z0aek();
		using z0ZzZzlsh z0ZzZzlsh = p0.z0yyk.z0pek().z0eek();
		float num2 = p0.z0eek(z0ZzZzrzj);
		z0ZzZzbdh p1 = p0.z0drk();
		if (z0zjj.z0rek > 0f)
		{
			p1.z0tek(p1.z0uek() - z0zjj.z0rek);
			if (CheckAlignLeft)
			{
				p1.z0eek(p1.z0tek() + z0zjj.z0rek);
			}
		}
		z0ZzZzlsh.z0rek(CaptionAlign);
		z0ZzZzlsh.z0eek(StringAlignment.Near);
		if (z0pek())
		{
			z0ZzZzdpk.z0eek(z0ZzZzlsh, p1: true);
			z0ZzZzlsh.z0eek(StringAlignment.Center);
		}
		else
		{
			z0ZzZzdpk.z0eek(z0ZzZzlsh, p1: false);
			switch (z0ptk().z0cek())
			{
			case VerticalAlignStyle.Middle:
				p1.z0rek(p1.z0yek() + (p1.z0iek() - num2) / 2f);
				break;
			case VerticalAlignStyle.Bottom:
				p1.z0rek(p1.z0yek() + (p1.z0iek() - num2));
				break;
			}
			p1.z0yek(num2);
			p1.z0rek(p1.z0yek() + p0.z0yyk.z0uek().z0tek());
		}
		Color p2 = z0yek(z0ZzZzrzj.z0bek);
		p0.z0gyk.z0eek(z0zjj.z0uek, z0ZzZzrzj.z0pek, p2, p1, z0ZzZzlsh);
		if (z0ZzZzrzj.z0uyk)
		{
			p0.z0yyk.z0eek(this, p0, p2, new z0ZzZzbdh(p0.z0gtk.z0oek(), p1.z0pek(), p0.z0gtk.z0uek(), p1.z0iek()));
		}
	}

	public override bool z0yi()
	{
		bool flag = z0cuk;
		if (flag && (!Checked & (z0bek() == PrintVisibilityModeWhenUnchecked.HiddenAll)))
		{
			z0ZzZzmcj z0ZzZzmcj = z0jr()?.z0qtk();
			if (z0ZzZzmcj != null && (z0ZzZzmcj.Printing || z0ZzZzmcj.PrintPreviewing))
			{
				return false;
			}
		}
		return flag;
	}

	public override void z0bw_jiejie20260327142557(z0ygj p0)
	{
		if (p0.z0pek)
		{
			p0.z0eek(z0ti());
		}
		else
		{
			p0.z0eek(Caption);
		}
	}

	internal virtual int z0eek(XTextContainerElement.z0eok_jiejie20260327142557 p0)
	{
		return z0jrk()?.z0ue(p0) ?? 0;
	}

	internal new int z0frk()
	{
		return z0jtk;
	}

	public override void z0ei(ElementEventArgs p0)
	{
		if (!string.IsNullOrEmpty(GroupName))
		{
			z0ri();
		}
		else if (z0jr().z0htk() != null)
		{
			z0jr().z0htk().z0qp(this);
		}
		base.z0ei(p0);
	}

	public new bool z0drk()
	{
		return Requried;
	}
}
