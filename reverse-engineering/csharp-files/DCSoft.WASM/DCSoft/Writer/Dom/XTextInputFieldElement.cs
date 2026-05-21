using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Text;
using DCSoft.Drawing;
using DCSoft.Writer.Controls;
using DCSoft.Writer.Data;
using DCSystem_Drawing;
using zzz;

namespace DCSoft.Writer.Dom;

[z0ZzZziqh("XInputField")]
[DebuggerDisplay("Input Name:{ID}")]
public class XTextInputFieldElement : XTextInputFieldElementBase
{
	private new ValueEditorActiveMode z0wrk = ValueEditorActiveMode.Program | ValueEditorActiveMode.F2 | ValueEditorActiveMode.MouseDblClick;

	internal new static bool z0erk = false;

	internal new static bool z0rrk = true;

	private new static readonly FormButtonStyle[] z0trk = z0mek();

	private new InputFieldSettings z0urk;

	[DefaultValue(ValueEditorActiveMode.Program | ValueEditorActiveMode.F2 | ValueEditorActiveMode.MouseDblClick)]
	[z0ZzZzbjh]
	public ValueEditorActiveMode EditorActiveMode
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
	public InputFieldSettings FieldSettings
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

	public int UserFlags
	{
		get
		{
			if (z0utk != null)
			{
				return ((z0cpk)z0utk).z0rek;
			}
			return 0;
		}
		set
		{
			if (value == 0)
			{
				if (z0utk != null)
				{
					((z0cpk)z0utk).z0rek = 0;
				}
			}
			else
			{
				((XTextFieldElementBase)this).z0lrk().z0rek = value;
			}
		}
	}

	public new void z0eek(DCBooleanValue p0)
	{
		if (p0 == DCBooleanValue.Inherit)
		{
			if (z0utk != null)
			{
				((z0cpk)z0utk).z0eek = p0;
			}
		}
		else
		{
			((XTextFieldElementBase)this).z0lrk().z0eek = p0;
		}
	}

	public new bool z0eek()
	{
		return z0vtk();
	}

	public new void z0eek(bool p0)
	{
		if (z0urk == null)
		{
			z0urk = new InputFieldSettings();
		}
		z0urk.z0eek(p0);
	}

	public override void z0fy(z0ZzZzdxj p0)
	{
		p0.z0eek();
		if (p0.z0tek())
		{
			string startBorderText = base.StartBorderText;
			if (!string.IsNullOrEmpty(startBorderText))
			{
				p0.z0eek(startBorderText);
			}
			else
			{
				p0.z0eek('[');
			}
		}
		if (p0.z0pek())
		{
			p0.z0eek(base.LabelText);
		}
		int num = p0.z0eek();
		if (z0ntk != null && z0ntk.Count > 0)
		{
			base.z0fy(p0);
		}
		if (num == p0.z0eek() && p0.z0oek())
		{
			p0.z0eek(base.BackgroundText);
		}
		if (p0.z0pek())
		{
			p0.z0eek(base.UnitText);
		}
		if (p0.z0tek())
		{
			string endBorderText = base.EndBorderText;
			if (!string.IsNullOrEmpty(endBorderText))
			{
				p0.z0eek(endBorderText);
			}
			else
			{
				p0.z0eek(']');
			}
		}
	}

	public new InputFieldAdornTextType z0rek()
	{
		if (z0utk != null)
		{
			return ((z0cpk)z0utk).z0krk;
		}
		return InputFieldAdornTextType.Default;
	}

	public new void z0rek(bool p0)
	{
		z0wrk(p0);
	}

	public override string z0my(string p0, bool p1)
	{
		z0ZzZzdvj z0ZzZzdvj = z0eek(null, z0jr() != null && z0bu().RaiseQueryListItemsWhenUserEditText, p0);
		if (z0ZzZzdvj != null)
		{
			if (FieldSettings.z0yek())
			{
				List<string> list = new List<string>();
				using (zzz.z0ZzZzkuk<ListItem>.z0bpk z0bpk = z0ZzZzdvj.z0ltk())
				{
					while (z0bpk.MoveNext())
					{
						ListItem current = z0bpk.Current;
						if (!string.IsNullOrEmpty(current.Value))
						{
							list.Add(current.Value);
						}
						else
						{
							list.Add(current.Text);
						}
					}
				}
				string text = FieldSettings.z0cek();
				string[] array = null;
				if (z0jr() != null)
				{
					array = z0ZzZzdfh.z0rek().z0eek(z0jr().z0yyk(), this, list, text, FieldSettings.z0tek(), p0);
				}
				if (array == null || array.Length == 0)
				{
					return string.Empty;
				}
				StringBuilder stringBuilder = new StringBuilder();
				using (zzz.z0ZzZzkuk<ListItem>.z0bpk z0bpk = z0ZzZzdvj.z0ltk())
				{
					while (z0bpk.MoveNext())
					{
						ListItem current2 = z0bpk.Current;
						string text2 = (string.IsNullOrEmpty(current2.Value) ? current2.Text : current2.Value);
						bool flag = false;
						string[] array2 = array;
						for (int i = 0; i < array2.Length; i++)
						{
							if (array2[i] == text2)
							{
								flag = true;
								break;
							}
						}
						if (flag)
						{
							if (stringBuilder.Length > 0 && !string.IsNullOrEmpty(text))
							{
								stringBuilder.Append(text);
							}
							stringBuilder.Append(current2.Text);
						}
					}
				}
				return stringBuilder.ToString();
			}
			string text3 = z0ZzZzdvj.z0rek(p0);
			if (text3 == null && !p1)
			{
				text3 = p0;
			}
			return text3;
		}
		return base.z0eek(p0);
	}

	public override string z0pe()
	{
		return "field";
	}

	public override z0ZzZzbdh z0py()
	{
		XTextElement xTextElement = null;
		XTextElement xTextElement2 = null;
		if (base.z0wrk != null && base.z0wrk.z0ptk() != null && ((XTextFieldElementBase)this).z0ark != null && ((XTextFieldElementBase)this).z0ark.z0ptk() != null)
		{
			xTextElement = base.z0wrk;
			xTextElement2 = ((XTextFieldElementBase)this).z0ark;
		}
		else
		{
			z0ZzZzplh z0ZzZzplh = z0qek()?.z0frk();
			if (z0ZzZzplh != null && z0tuk >= 0 && z0tuk < z0ZzZzplh.Count)
			{
				XTextElement xTextElement3 = z0ZzZzplh[z0tuk];
				XTextElement[] array = ((XTextFieldElementBase)this).z0qrk;
				if (array != null && array.Length != 0 && array.z0tek(xTextElement3))
				{
					xTextElement = xTextElement3;
					xTextElement2 = array[array.Length - 1];
				}
				else if (xTextElement3.z0zu(this))
				{
					xTextElement = xTextElement3;
					xTextElement2 = xTextElement3;
					for (int i = z0tuk + 1; i < z0ZzZzplh.Count; i++)
					{
						XTextElement xTextElement4 = z0ZzZzplh[i];
						if (!xTextElement4.z0zu(this))
						{
							break;
						}
						xTextElement2 = xTextElement4;
					}
				}
			}
		}
		if (xTextElement != null && xTextElement2 != null)
		{
			z0ZzZzbdh p = xTextElement.z0py();
			z0ZzZzbdh p2 = xTextElement2.z0py();
			return z0ZzZzbdh.z0yek(p, p2);
		}
		return z0ZzZzbdh.z0xek;
	}

	public new bool z0tek()
	{
		switch (z0frk())
		{
		case DCBooleanValue.True:
			return true;
		case DCBooleanValue.False:
			return false;
		default:
			if (z0jr() != null)
			{
				return z0iu().ShowInputFieldStateTag;
			}
			return true;
		}
	}

	public void z0eek(z0ZzZzfvj p0)
	{
		if (p0 == null)
		{
			if (z0utk != null)
			{
				((z0cpk)z0utk).z0qrk = null;
			}
		}
		else
		{
			((XTextFieldElementBase)this).z0lrk().z0qrk = p0;
		}
	}

	public override void z0rt(ElementLoadEventArgs p0)
	{
		if (z0urk != null)
		{
			z0urk.z0pek();
		}
		if (z0nek() != null && z0nek().IsRoot)
		{
			z0rik?.z0mik()?.z0rek(this);
		}
		base.z0rt(p0);
	}

	public new bool z0yek()
	{
		return z0otk();
	}

	public new virtual void z0tek(bool p0)
	{
		string innerValue = base.InnerValue;
		bool flag = z0erk;
		z0erk = false;
		string text = Text;
		if (FieldSettings != null)
		{
			if (FieldSettings.z0eek() == InputFieldEditStyle.Date || FieldSettings.z0eek() == InputFieldEditStyle.DateTime)
			{
				DateTime result = z0jr().z0jpk();
				bool flag2 = false;
				if (base.z0frk() != null && !string.IsNullOrEmpty(base.z0frk().Format))
				{
					flag2 = DateTime.TryParseExact(text, base.z0frk().Format, null, DateTimeStyles.AssumeLocal, out result);
				}
				else if (z0rrk)
				{
					flag2 = DateTime.TryParse(text, out result);
				}
				if (flag2)
				{
					if (z0bu().DisplayFormatToInnerValue && base.z0frk() != null && !base.z0frk().IsEmpty)
					{
						base.InnerValue = base.z0frk().Execute(result);
					}
					else if (FieldSettings.z0eek() == InputFieldEditStyle.Date)
					{
						base.InnerValue = result.ToString(z0ZzZzkfh.z0trk);
					}
					else if (FieldSettings.z0eek() == InputFieldEditStyle.Time)
					{
						base.InnerValue = result.ToString("HH:mm:ss");
					}
					else if (FieldSettings.z0eek() == InputFieldEditStyle.DateTimeWithoutSecond)
					{
						base.InnerValue = result.ToString(z0ZzZzkfh.z0mek);
					}
					else
					{
						base.InnerValue = result.ToString(z0ZzZzkfh.z0qrk);
					}
				}
				else
				{
					base.InnerValue = text;
				}
			}
			else if (FieldSettings.z0eek() == InputFieldEditStyle.Text)
			{
				base.InnerValue = text;
			}
			else if (FieldSettings.z0eek() == InputFieldEditStyle.DropdownList && z0rrk)
			{
				if (z0ntk == null || z0ntk.Count == 0)
				{
					base.InnerValue = z0uy(null);
				}
				else
				{
					StringBuilder stringBuilder = new StringBuilder(z0ntk.Count);
					XTextElement[] array = ((zzz.z0ZzZzkuk<XTextElement>)z0ntk).z0krk();
					int count = z0ntk.Count;
					bool flag3 = true;
					for (int i = 0; i < count; i++)
					{
						XTextElement xTextElement = array[i];
						if (xTextElement is XTextCharElement)
						{
							if (xTextElement.z0buk < 0 || xTextElement.z0aek().z0jyk < 0)
							{
								((XTextCharElement)xTextElement).z0rek(stringBuilder);
								continue;
							}
							flag3 = false;
							break;
						}
						flag3 = false;
						break;
					}
					if (flag3)
					{
						base.InnerValue = z0uy(stringBuilder.ToString());
					}
					else
					{
						base.InnerValue = z0uy(text);
					}
				}
			}
			else
			{
				base.InnerValue = text;
			}
		}
		else
		{
			base.InnerValue = text;
		}
		if (flag && innerValue != base.InnerValue && z0jr().z0uik())
		{
			z0ZzZzhlh p1 = new z0ZzZzhlh((z0ZzZzqlh)6, innerValue, base.InnerValue, this);
			z0jr().z0bek(p1);
		}
		if (!p0)
		{
			return;
		}
		for (XTextElement xTextElement2 = z0ji(); xTextElement2 != null; xTextElement2 = xTextElement2.z0ji())
		{
			if (xTextElement2 is XTextInputFieldElement)
			{
				((XTextInputFieldElement)xTextElement2).z0tek(p0: false);
			}
		}
	}

	public new bool z0uek()
	{
		return z0zyk();
	}

	public void z0rek(DCBooleanValue p0)
	{
		if (p0 == DCBooleanValue.Inherit)
		{
			if (z0utk != null)
			{
				((z0cpk)z0utk).z0pek = p0;
			}
		}
		else
		{
			((XTextFieldElementBase)this).z0lrk().z0pek = p0;
		}
	}

	public void z0eek(InputFieldEditStyle p0)
	{
		if (z0urk == null)
		{
			z0urk = new InputFieldSettings();
		}
		z0urk.z0eek(p0);
	}

	public void z0eek(Type p0)
	{
		z0eek(z0ZzZzwnj.z0eek(p0));
	}

	internal Color z0eek(Color p0, z0ZzZzrzj p1, bool p2, DocumentViewOptions p3 = null)
	{
		Color textColor = base.TextColor;
		if (textColor.A != 0)
		{
			p0 = textColor;
		}
		if (p3 == null)
		{
			p3 = z0iu();
		}
		if (p3.EnableFieldTextColor && z0eek())
		{
			p0 = ((textColor.A == 0) ? p3.FieldTextColor : textColor);
			if (p2)
			{
				if (p3.FieldTextPrintColor.A != 0)
				{
					p0 = p3.FieldTextPrintColor;
				}
				if (p1 != null && p1.z0ztk.A != 0)
				{
					p0 = p1.z0ztk;
				}
			}
		}
		return p0;
	}

	public override string ToString()
	{
		return "[" + base.LabelText + Text + base.UnitText + "]";
	}

	public new FormButtonStyle z0iek()
	{
		if (z0utk != null)
		{
			return ((z0cpk)z0utk).z0bek;
		}
		return FormButtonStyle.Auto;
	}

	public override void z0ye(ElementEventArgs p0)
	{
		base.z0ye(p0);
		if (!z0ZzZzafh.z0yek((int)z0srk(), 8) || z0qek().z0oek().z0qrk() != 0 || z0cu() == null)
		{
			return;
		}
		z0ZzZzznj z0ZzZzznj = z0cu().z0mtk();
		if (z0ZzZzznj.z0yx() != null && z0ZzZzznj.z0yx().z0tek() == this && z0ZzZzznj.z0yx().z0uek() == ElementValueEditorEditStyle.Modal)
		{
			return;
		}
		InputFieldEditStyle inputFieldEditStyle = InputFieldEditStyle.Text;
		if (FieldSettings != null)
		{
			inputFieldEditStyle = FieldSettings.z0eek();
		}
		if (FieldSettings != null && z0cu() != null && inputFieldEditStyle == InputFieldEditStyle.DropdownList)
		{
			if (FieldSettings.z0uek())
			{
				z0jr().z0yyk().z0rek(this, p1: false, ValueEditorActiveMode.GotFocus, p3: true, p4: true);
			}
			else if (FieldSettings.z0zek() != null && !FieldSettings.z0zek().IsEmpty)
			{
				z0jr().z0yyk().z0rek(this, p1: false, ValueEditorActiveMode.GotFocus, p3: true, p4: true);
			}
		}
		else if (inputFieldEditStyle == InputFieldEditStyle.Date || inputFieldEditStyle == InputFieldEditStyle.DateTime || inputFieldEditStyle == InputFieldEditStyle.DateTimeWithoutSecond || inputFieldEditStyle == InputFieldEditStyle.Numeric || inputFieldEditStyle == InputFieldEditStyle.Time)
		{
			z0jr().z0yyk().z0rek(this, p1: false, ValueEditorActiveMode.GotFocus, p3: true, p4: true);
		}
	}

	public new InputFieldEditStyle z0oek()
	{
		if (z0urk == null)
		{
			return InputFieldEditStyle.Text;
		}
		return z0urk.z0nek();
	}

	public new void z0eek(string p0)
	{
		if (p0 == null || p0.Length == 0)
		{
			if (z0utk != null)
			{
				((z0cpk)z0utk).z0ark = null;
			}
		}
		else
		{
			((XTextFieldElementBase)this).z0lrk().z0ark = p0;
		}
	}

	public override void z0oy(ElementEventArgs p0)
	{
		base.z0oy(p0);
		if (z0cu() != null)
		{
			z0cu().z0zyk();
		}
	}

	public new bool z0pek()
	{
		return z0ryk();
	}

	public void z0eek(FormButtonStyle p0)
	{
		if (p0 == FormButtonStyle.Auto)
		{
			if (z0utk != null)
			{
				((z0cpk)z0utk).z0bek = p0;
			}
		}
		else
		{
			((XTextFieldElementBase)this).z0lrk().z0bek = p0;
		}
	}

	public z0ZzZzdvj z0eek(string p0, bool p1, string p2)
	{
		if (z0jr() == null)
		{
			return null;
		}
		z0ZzZzgvj p3 = null;
		if (z0jr().z0xmk() != null)
		{
			p3 = (z0ZzZzgvj)z0jr().z0xmk().z0tek().z0eek(typeof(z0ZzZzgvj));
		}
		return z0ZzZzsvj.z0eek(z0jr().z0yyk(), this, z0jr().z0xmk(), (FieldSettings == null) ? null : FieldSettings.z0zek(), p3, null, p0, p1, p2);
	}

	public override void z0rr(ContentChangedEventArgs p0)
	{
		if (p0.LoadingDocument)
		{
			base.z0rr(p0);
		}
		else if (!p0.OnlyStyleChanged)
		{
			if (p0.EventSource != ContentChangedEventSource.ValueEditor && z0vek() && p0.EventSource != ContentChangedEventSource.UndoRedo)
			{
				z0tek(p0: false);
			}
			base.z0rr(p0);
			z0jr().z0mik().z0eek(this, p1: false);
		}
	}

	private new static FormButtonStyle[] z0mek()
	{
		FormButtonStyle[] array = new FormButtonStyle[7];
		array[2] = FormButtonStyle.DateTimePicker;
		array[3] = FormButtonStyle.DateTimePicker;
		array[4] = FormButtonStyle.DateTimePicker;
		array[1] = FormButtonStyle.ComboBoxButton;
		array[6] = FormButtonStyle.None;
		array[0] = FormButtonStyle.None;
		array[5] = FormButtonStyle.DateTimePicker;
		return array;
	}

	public new void z0yek(bool p0)
	{
		base.z0iek(p0);
	}

	public new z0ZzZzfvj z0nek()
	{
		return ((z0cpk)z0utk)?.z0qrk;
	}

	public new virtual bool z0bek()
	{
		return false;
	}

	public new void z0uek(bool p0)
	{
		z0lrk(p0);
	}

	public new void z0iek(bool p0)
	{
		base.z0oek(p0);
	}

	public XTextInputFieldElement()
	{
		z0oek(p0: true);
		z0iek(p0: true);
		z0uek(p0: true);
	}

	public new bool z0vek()
	{
		return z0guk();
	}

	public new InputFieldAdornTextType z0cek()
	{
		InputFieldAdornTextType inputFieldAdornTextType = z0rek();
		if (inputFieldAdornTextType == InputFieldAdornTextType.Default && z0jr() != null)
		{
			inputFieldAdornTextType = z0iu().DefaultAdornTextType;
		}
		return inputFieldAdornTextType;
	}

	public void z0rek(string p0)
	{
		if (z0urk == null)
		{
			z0urk = new InputFieldSettings();
		}
		z0urk.z0eek(p0);
	}

	internal void z0eek(string p0, string p1)
	{
		if (!(p0 != p1))
		{
			return;
		}
		List<string> list = ((z0cpk)z0utk)?.z0zek;
		if (list == null)
		{
			list = new List<string>();
			((XTextFieldElementBase)this).z0lrk().z0zek = list;
		}
		for (int num = list.Count - 2; num >= 0; num -= 2)
		{
			if (list[num] == p0)
			{
				return;
			}
		}
		list.Add(p0);
		list.Add(p1);
	}

	public new string z0xek()
	{
		return ((z0cpk)z0utk)?.z0tek;
	}

	public new string z0zek()
	{
		if (z0urk == null)
		{
			return ",";
		}
		return z0urk.z0oek();
	}

	public override void Dispose()
	{
		base.Dispose();
		z0urk = null;
		z0urk = null;
	}

	public new void z0lrk()
	{
		if (FieldSettings == null)
		{
			FieldSettings = new InputFieldSettings();
		}
		if (FieldSettings.z0zek() == null)
		{
			FieldSettings.z0eek(new z0ZzZzsvj());
		}
		if (FieldSettings.z0zek().Items == null)
		{
			FieldSettings.z0zek().Items = new z0ZzZzdvj();
		}
	}

	public new DCBooleanValue z0krk()
	{
		if (z0utk != null)
		{
			return ((z0cpk)z0utk).z0eek;
		}
		return DCBooleanValue.Inherit;
	}

	public override string z0iy()
	{
		switch (z0cek())
		{
		case InputFieldAdornTextType.Default:
			return null;
		case InputFieldAdornTextType.DataSource:
			if (((XTextContainerElement)this).z0hrk() && !ValueBinding.IsEmptyBinding)
			{
				if (string.IsNullOrEmpty(ValueBinding.DataSource))
				{
					return ValueBinding.BindingPath;
				}
				return ValueBinding.DataSource + "#" + ValueBinding.BindingPath;
			}
			return null;
		case InputFieldAdornTextType.ToolTip:
			return ToolTip;
		case InputFieldAdornTextType.ValidateMessage:
			if (((XTextContainerElement)this).z0frk() != null)
			{
				return ((XTextContainerElement)this).z0frk().z0uek();
			}
			return null;
		case InputFieldAdornTextType.ID:
			return ID;
		case InputFieldAdornTextType.Name:
			return base.Name;
		case InputFieldAdornTextType.TabIndex:
			return base.TabIndex.ToString();
		default:
			return null;
		}
	}

	public new void z0oek(bool p0)
	{
		z0jrk(p0);
	}

	public bool z0tek(string p0)
	{
		int[] p1 = z0ZzZzwik.z0rek(p0);
		string p2 = z0ZzZzdfh.z0rek().z0rd(z0jr().z0yyk(), this, p1, p3: true);
		return z0cek(p2, (z0ZzZzbcj)0, p2: true, p3: true);
	}

	public new string z0jrk()
	{
		if (FieldSettings != null && FieldSettings.z0zek() != null)
		{
			return FieldSettings.z0zek().SourceName;
		}
		return null;
	}

	public override void z0nw(z0ZzZzuzj p0)
	{
		base.z0nw(p0);
		p0.z0eek((byte)z0iek());
		if (z0urk == null)
		{
			p0.z0eek(0);
			return;
		}
		p0.z0eek(1);
		p0.z0eek((byte)z0urk.z0nek());
		p0.z0eek(z0urk.z0zek()?.SourceName);
	}

	public new void z0yek(string p0)
	{
		if (p0 == null || p0.Length == 0)
		{
			if (z0utk != null)
			{
				((z0cpk)z0utk).z0tek = null;
			}
		}
		else
		{
			((XTextFieldElementBase)this).z0lrk().z0tek = p0;
		}
	}

	public new virtual bool z0hrk()
	{
		if (z0jr() != null && z0jr().z0yyk() != null)
		{
			return z0jr().z0yyk().z0eek(this, p1: false, ValueEditorActiveMode.Program, p3: false, p4: false);
		}
		return false;
	}

	public override string z0ge()
	{
		string text = "Field:" + ID + " " + base.Name;
		if (!string.IsNullOrEmpty(base.BackgroundText))
		{
			text = text + "[" + base.BackgroundText + "]";
		}
		return text;
	}

	public new Type z0grk()
	{
		return z0ZzZzwnj.GetControlType(z0drk(), typeof(z0ZzZznnj));
	}

	public new void z0uek(string p0)
	{
		z0lrk();
		FieldSettings.z0zek().SourceName = p0;
	}

	public new DCBooleanValue z0frk()
	{
		if (z0utk != null)
		{
			return ((z0cpk)z0utk).z0pek;
		}
		return DCBooleanValue.Inherit;
	}

	public new string z0drk()
	{
		return ((z0cpk)z0utk)?.z0ark;
	}

	internal new ValueEditorActiveMode z0srk()
	{
		ValueEditorActiveMode valueEditorActiveMode = EditorActiveMode;
		if (valueEditorActiveMode == ValueEditorActiveMode.Default)
		{
			valueEditorActiveMode = ((z0jr() != null) ? z0bu().DefaultEditorActiveMode : ValueEditorActiveMode.None);
		}
		if (valueEditorActiveMode != ValueEditorActiveMode.None && z0jr() != null && z0bu().FastInputMode)
		{
			valueEditorActiveMode |= ValueEditorActiveMode.GotFocus;
		}
		return valueEditorActiveMode;
	}

	public new FormButtonStyle z0ark()
	{
		FormButtonStyle result = FormButtonStyle.None;
		if (z0iek() != FormButtonStyle.Auto)
		{
			result = z0iek();
		}
		else if (!z0yek())
		{
			result = FormButtonStyle.None;
		}
		else if (z0xek() != null && z0xek().Length > 0)
		{
			result = FormButtonStyle.FloatButton;
		}
		else if (!string.IsNullOrEmpty(z0drk()))
		{
			result = FormButtonStyle.None;
		}
		else if (z0urk == null)
		{
			result = FormButtonStyle.None;
		}
		else
		{
			bool flag = false;
			switch (z0krk())
			{
			case DCBooleanValue.True:
				flag = true;
				break;
			case DCBooleanValue.False:
				flag = false;
				break;
			default:
			{
				DocumentViewOptions documentViewOptions = z0iu();
				if (documentViewOptions != null && documentViewOptions.ShowFormButton)
				{
					flag = true;
				}
				break;
			}
			}
			if (flag)
			{
				int num = (int)z0urk.z0eek();
				if (num >= 0 && num < 7)
				{
					result = z0trk[num];
				}
			}
		}
		return result;
	}

	internal string z0iek(string p0)
	{
		List<string> list = z0pek_jiejie20260327142557()?.z0zek;
		if (list != null)
		{
			for (int num = list.Count - 2; num >= 0; num -= 2)
			{
				if (list[num] == p0)
				{
					return list[num + 1];
				}
			}
		}
		return p0;
	}

	public override string z0uy(string p0)
	{
		bool p1 = false;
		if (z0jr() != null)
		{
			p1 = z0bu().RaiseQueryListItemsWhenUserEditText;
		}
		z0ZzZzdvj z0ZzZzdvj = z0eek(null, p1, null);
		if (z0ZzZzdvj == null)
		{
			return z0iek(p0);
		}
		if (z0ZzZzdvj.Count > 0)
		{
			if (FieldSettings.z0yek())
			{
				List<string> list = new List<string>();
				using (zzz.z0ZzZzkuk<ListItem>.z0bpk z0bpk = z0ZzZzdvj.z0ltk())
				{
					while (z0bpk.MoveNext())
					{
						ListItem current = z0bpk.Current;
						if (!string.IsNullOrEmpty(current.Text))
						{
							list.Add(current.Text);
						}
						else
						{
							list.Add(current.Value);
						}
					}
				}
				string text = FieldSettings.z0cek();
				string[] array = null;
				array = z0ZzZzdfh.z0rek().z0eek(z0jr().z0yyk(), this, list, text, FieldSettings.z0tek(), p0);
				if (array == null || array.Length == 0)
				{
					return string.Empty;
				}
				StringBuilder stringBuilder = new StringBuilder();
				using (zzz.z0ZzZzkuk<ListItem>.z0bpk z0bpk = z0ZzZzdvj.z0ltk())
				{
					while (z0bpk.MoveNext())
					{
						ListItem current2 = z0bpk.Current;
						string text2 = (string.IsNullOrEmpty(current2.Text) ? current2.Value : current2.Text);
						bool flag = false;
						for (int i = 0; i < array.Length; i++)
						{
							if (array[i] == text2)
							{
								array[i] = null;
								flag = true;
								break;
							}
						}
						if (flag)
						{
							if (stringBuilder.Length > 0 && !string.IsNullOrEmpty(text))
							{
								stringBuilder.Append(text);
							}
							if (string.IsNullOrEmpty(current2.Value))
							{
								stringBuilder.Append(current2.Text);
							}
							else
							{
								stringBuilder.Append(current2.Value);
							}
						}
					}
				}
				return stringBuilder.ToString();
			}
			string text3 = z0ZzZzdvj.z0eek(p0);
			if (text3 == null)
			{
				text3 = p0;
			}
			return text3;
		}
		return p0;
	}

	public new bool z0qrk()
	{
		if (z0urk == null)
		{
			return false;
		}
		return z0urk.z0yek();
	}

	public void z0eek(InputFieldAdornTextType p0)
	{
		if (p0 == InputFieldAdornTextType.Default)
		{
			if (z0utk != null)
			{
				((z0cpk)z0utk).z0krk = p0;
			}
		}
		else
		{
			((XTextFieldElementBase)this).z0lrk().z0krk = p0;
		}
	}

	public override XTextElement z0lr(bool p0)
	{
		XTextInputFieldElement xTextInputFieldElement = (XTextInputFieldElement)base.z0lr(p0);
		if (z0urk != null)
		{
			xTextInputFieldElement.z0urk = z0urk.z0rek();
		}
		return xTextInputFieldElement;
	}

	public override XTextElementList z0yy(string p0, DocumentContentStyle p1, bool p2)
	{
		XTextElementList xTextElementList = base.z0yy(p0, p1, p2);
		if (xTextElementList != null && xTextElementList.Count > 0)
		{
			z0tek(p0: true);
		}
		return xTextElementList;
	}
}
