using System;
using DCSoft.Common;
using DCSoft.Data;
using DCSoft.Writer;
using DCSoft.Writer.Dom;
using DCSoft.Writer.MedicalExpression;
using DCSystem_Drawing;

namespace zzz;

internal static class z0ZzZzdrk
{
	private static EnableState z0rek = EnableState.Enabled;

	internal static void z0eek(XTextElement p0, string p1)
	{
		if (p0 is XTextCheckBoxElementBase)
		{
			XTextCheckBoxElementBase xTextCheckBoxElementBase = (XTextCheckBoxElementBase)p0;
			if (p1 == "IsNullPrint")
			{
				if (string.Compare(xTextCheckBoxElementBase.z0zwk(p1), "true", true) == 0)
				{
					xTextCheckBoxElementBase.PrintVisibilityWhenUnchecked = PrintVisibilityModeWhenUnchecked.HiddenCheckBoxOnly;
				}
				else
				{
					xTextCheckBoxElementBase.PrintVisibilityWhenUnchecked = PrintVisibilityModeWhenUnchecked.Visible;
				}
			}
			if (p1 == "CheckOption")
			{
				xTextCheckBoxElementBase.ToolTip = xTextCheckBoxElementBase.z0zwk(p1);
			}
			if (p1 == "IsChecked")
			{
				xTextCheckBoxElementBase.Checked = z0ZzZzafh.z0yek((object)xTextCheckBoxElementBase.z0zwk("IsChecked"), p1: false);
				if (xTextCheckBoxElementBase.z0jr() != null)
				{
					xTextCheckBoxElementBase.z0jo();
				}
			}
			if (p1 == "PlaceHolder")
			{
				xTextCheckBoxElementBase.Caption = xTextCheckBoxElementBase.z0zwk("PlaceHolder");
				if (xTextCheckBoxElementBase.z0jr() != null)
				{
					xTextCheckBoxElementBase.z0oe();
				}
			}
			if (p1 == "IsCtrlHidden")
			{
				bool flag = !z0ZzZzafh.z0yek((object)xTextCheckBoxElementBase.z0zwk("IsCtrlHidden"), p1: false);
				if (xTextCheckBoxElementBase.Visible != flag)
				{
					xTextCheckBoxElementBase.Visible = flag;
					xTextCheckBoxElementBase.z0oe();
				}
			}
			if (p1 == "HelpTip")
			{
				xTextCheckBoxElementBase.ToolTip = xTextCheckBoxElementBase.z0zwk("HelpTip");
			}
			xTextCheckBoxElementBase.z0oe();
		}
		if (!(p0 is XTextInputFieldElement))
		{
			return;
		}
		XTextInputFieldElement xTextInputFieldElement = (XTextInputFieldElement)p0;
		if (p1 == "ControlName")
		{
			xTextInputFieldElement.Name = xTextInputFieldElement.z0zwk("ControlName");
		}
		if (p1 == "HelpTip")
		{
			xTextInputFieldElement.ToolTip = xTextInputFieldElement.z0zwk("HelpTip");
		}
		if (p1 == "IsDropDown")
		{
			xTextInputFieldElement.z0uek(z0ZzZzafh.z0yek((object)xTextInputFieldElement.z0zwk("IsDropDown"), p1: true));
		}
		if (p1 == "BorderEndString")
		{
			xTextInputFieldElement.EndBorderText = xTextInputFieldElement.z0zwk("BorderEndString");
		}
		if (p1 == "BorderStartString")
		{
			xTextInputFieldElement.StartBorderText = xTextInputFieldElement.z0zwk("BorderStartString");
		}
		if (p1 == "Edge")
		{
			if (z0ZzZzafh.z0yek((object)xTextInputFieldElement.z0zwk("Edge"), p1: true))
			{
				xTextInputFieldElement.BorderVisible = DCVisibleState.Default;
			}
			else
			{
				xTextInputFieldElement.BorderVisible = DCVisibleState.Hidden;
			}
		}
		if (p1 == "DeleteProtect")
		{
			if (z0ZzZzafh.z0yek((object)xTextInputFieldElement.z0zwk("DeleteProtect"), p1: false))
			{
				xTextInputFieldElement.Deleteable = false;
			}
			else
			{
				xTextInputFieldElement.Deleteable = true;
			}
		}
		if (p1 == "PlaceHolder")
		{
			string text = xTextInputFieldElement.z0zwk("PlaceHolder");
			if (string.IsNullOrEmpty(text))
			{
				text = null;
			}
			if (string.IsNullOrEmpty(xTextInputFieldElement.BackgroundText))
			{
				xTextInputFieldElement.BackgroundText = null;
			}
			if (text != xTextInputFieldElement.BackgroundText)
			{
				xTextInputFieldElement.BackgroundText = text;
				if (text == "牙齿公式")
				{
					XTextNewMedicalExpressionElement xTextNewMedicalExpressionElement = new XTextNewMedicalExpressionElement();
					xTextNewMedicalExpressionElement.ExpressionStyle = DCMedicalExpressionStyle.FourValuesGeneral;
					xTextNewMedicalExpressionElement.Values.Value1 = "1";
					xTextNewMedicalExpressionElement.Values.Value2 = "2";
					xTextNewMedicalExpressionElement.Values.Value3 = "3";
					xTextNewMedicalExpressionElement.Values.Value4 = "4";
					xTextNewMedicalExpressionElement.Width = 300f;
					xTextNewMedicalExpressionElement.Height = 200f;
					xTextInputFieldElement.z0be().Clear();
					xTextInputFieldElement.z0be().Add(xTextNewMedicalExpressionElement);
				}
				if (xTextInputFieldElement.z0jr() != null && xTextInputFieldElement.z0be().Count == 0)
				{
					xTextInputFieldElement.z0oe();
				}
			}
		}
		if (p1 == "DelFlag")
		{
			xTextInputFieldElement.Deleteable = !z0ZzZzafh.z0yek((object)xTextInputFieldElement.z0zwk("DelFlag"), p1: false);
		}
		if (p1 == "EditProtect")
		{
			if (z0ZzZzafh.z0yek((object)xTextInputFieldElement.z0zwk("EditProtect"), p1: false))
			{
				xTextInputFieldElement.ContentReadonly = ContentReadonlyState.True;
			}
			else
			{
				xTextInputFieldElement.ContentReadonly = ContentReadonlyState.Inherit;
			}
		}
		if (p1 == "MustFillContent")
		{
			if (xTextInputFieldElement.ValidateStyle == null)
			{
				xTextInputFieldElement.ValidateStyle = new ValueValidateStyle();
			}
			xTextInputFieldElement.ValidateStyle.Required = z0ZzZzafh.z0yek((object)xTextInputFieldElement.z0zwk("MustFillContent"), p1: false);
			xTextInputFieldElement.ValidateStyle.ContentVersion = -1;
			if (xTextInputFieldElement.ValidateStyle.Required)
			{
				xTextInputFieldElement.BackgroundTextColor = Color.Blue;
			}
			else
			{
				xTextInputFieldElement.BackgroundTextColor = Color.Empty;
			}
			xTextInputFieldElement.z0jo();
		}
		if (p1 == "ViewSecret")
		{
			if (z0ZzZzafh.z0yek((object)xTextInputFieldElement.z0zwk("ViewSecret"), p1: false))
			{
				xTextInputFieldElement.ViewEncryptType = ContentViewEncryptType.Partial;
			}
			else
			{
				xTextInputFieldElement.ViewEncryptType = ContentViewEncryptType.None;
			}
		}
		if (p1 == "IsEnterJumpNext")
		{
			if (z0ZzZzafh.z0yek((object)xTextInputFieldElement.z0zwk("IsEnterJumpNext"), p1: false))
			{
				xTextInputFieldElement.MoveFocusHotKey = MoveFocusHotKeys.Enter;
			}
			else
			{
				xTextInputFieldElement.MoveFocusHotKey = MoveFocusHotKeys.Default;
			}
		}
		if (p1 == "IsCtrlHidden")
		{
			bool flag2 = !z0ZzZzafh.z0yek((object)xTextInputFieldElement.z0zwk("IsCtrlHidden"), p1: false);
			if (xTextInputFieldElement.Visible != flag2)
			{
				xTextInputFieldElement.Visible = flag2;
				xTextInputFieldElement.z0oe();
			}
		}
		xTextInputFieldElement.z0oe();
	}

	internal static XTextElement z0eek(string p0, string p1, z0ZzZzfrk p2)
	{
		XTextElement xTextElement = null;
		switch (p2)
		{
		case (z0ZzZzfrk)1:
		{
			XTextInputFieldElement xTextInputFieldElement7 = new XTextInputFieldElement();
			xTextInputFieldElement7.z0dr("NsoElementTypeName", "NewControl");
			xTextInputFieldElement7.z0dr("NsoControlTypeName", "Combox");
			xTextInputFieldElement7.z0dr("Type", Convert.ToInt32(p2).ToString());
			xTextInputFieldElement7.ID = p0;
			xTextInputFieldElement7.BackgroundText = "XX";
			xTextInputFieldElement7.UserEditable = true;
			xTextInputFieldElement7.StartBorderText = "[";
			xTextInputFieldElement7.EndBorderText = "]";
			xTextInputFieldElement7.EditorActiveMode = ValueEditorActiveMode.F2 | ValueEditorActiveMode.MouseDblClick | ValueEditorActiveMode.MouseClick;
			xTextInputFieldElement7.AcceptChildElementTypes2 = ElementType.Text;
			xTextInputFieldElement7.EnableHighlight = z0rek;
			if (!string.IsNullOrEmpty(p1))
			{
				xTextInputFieldElement7.z0zek(p1);
			}
			xTextInputFieldElement7.FieldSettings = new InputFieldSettings();
			xTextInputFieldElement7.FieldSettings.z0eek(InputFieldEditStyle.DropdownList);
			return xTextInputFieldElement7;
		}
		case (z0ZzZzfrk)2:
		{
			XTextInputFieldElement xTextInputFieldElement8 = new XTextInputFieldElement();
			xTextInputFieldElement8.z0dr("NsoElementTypeName", "NewControl");
			xTextInputFieldElement8.z0dr("NsoControlTypeName", "ListBox");
			xTextInputFieldElement8.z0dr("Type", Convert.ToInt32(p2).ToString());
			xTextInputFieldElement8.ID = p0;
			xTextInputFieldElement8.BackgroundText = "XX";
			xTextInputFieldElement8.UserEditable = true;
			xTextInputFieldElement8.StartBorderText = "[";
			xTextInputFieldElement8.EndBorderText = "]";
			xTextInputFieldElement8.EditorActiveMode = ValueEditorActiveMode.F2 | ValueEditorActiveMode.MouseDblClick | ValueEditorActiveMode.MouseClick;
			xTextInputFieldElement8.AcceptChildElementTypes2 = ElementType.Text;
			xTextInputFieldElement8.EnableHighlight = z0rek;
			if (!string.IsNullOrEmpty(p1))
			{
				xTextInputFieldElement8.z0zek(p1);
			}
			xTextInputFieldElement8.FieldSettings = new InputFieldSettings();
			xTextInputFieldElement8.FieldSettings.z0eek(InputFieldEditStyle.DropdownList);
			return xTextInputFieldElement8;
		}
		case (z0ZzZzfrk)3:
		{
			XTextInputFieldElement xTextInputFieldElement2 = new XTextInputFieldElement();
			xTextInputFieldElement2.z0dr("NsoElementTypeName", "NewControl");
			xTextInputFieldElement2.z0dr("NsoControlTypeName", "TextBox");
			xTextInputFieldElement2.z0dr("Type", Convert.ToInt32(p2).ToString());
			xTextInputFieldElement2.ID = p0;
			xTextInputFieldElement2.BackgroundText = "XXXX";
			xTextInputFieldElement2.UserEditable = true;
			xTextInputFieldElement2.StartBorderText = "[";
			xTextInputFieldElement2.EndBorderText = "]";
			xTextInputFieldElement2.EditorActiveMode = ValueEditorActiveMode.MouseClick;
			xTextInputFieldElement2.AcceptChildElementTypes2 = ElementType.All;
			xTextInputFieldElement2.EnableHighlight = z0rek;
			if (!string.IsNullOrEmpty(p1))
			{
				xTextInputFieldElement2.z0zek(p1);
			}
			return xTextInputFieldElement2;
		}
		case (z0ZzZzfrk)5:
		{
			XTextCheckBoxElement xTextCheckBoxElement = new XTextCheckBoxElement();
			xTextCheckBoxElement.z0dr("Type", Convert.ToInt32(p2).ToString());
			xTextCheckBoxElement.ID = p0;
			xTextCheckBoxElement.Deleteable = true;
			xTextCheckBoxElement.Caption = p1;
			return xTextCheckBoxElement;
		}
		case (z0ZzZzfrk)4:
		{
			XTextInputFieldElement xTextInputFieldElement5 = new XTextInputFieldElement();
			xTextInputFieldElement5.z0dr("NsoElementTypeName", "NewControl");
			xTextInputFieldElement5.z0dr("NsoControlTypeName", "NumberBox");
			xTextInputFieldElement5.z0dr("Type", Convert.ToInt32(p2).ToString());
			xTextInputFieldElement5.FieldSettings = new InputFieldSettings();
			xTextInputFieldElement5.FieldSettings.z0eek(InputFieldEditStyle.Numeric);
			xTextInputFieldElement5.ID = p0;
			xTextInputFieldElement5.UserEditable = true;
			xTextInputFieldElement5.BackgroundText = "XX";
			xTextInputFieldElement5.StartBorderText = "[";
			xTextInputFieldElement5.EndBorderText = "]";
			xTextInputFieldElement5.EditorActiveMode = ValueEditorActiveMode.F2 | ValueEditorActiveMode.MouseDblClick | ValueEditorActiveMode.MouseClick;
			xTextInputFieldElement5.AcceptChildElementTypes2 = ElementType.Text;
			xTextInputFieldElement5.EnableHighlight = z0rek;
			if (!string.IsNullOrEmpty(p1))
			{
				xTextInputFieldElement5.z0zek(p1);
			}
			xTextInputFieldElement5.ValidateStyle = new ValueValidateStyle();
			xTextInputFieldElement5.ValidateStyle.ValueType = ValueTypeStyle.Numeric;
			xTextInputFieldElement5.ValidateStyle.CustomMessage = "请在控件中输入数值。";
			return xTextInputFieldElement5;
		}
		case (z0ZzZzfrk)8:
		{
			XTextInputFieldElement xTextInputFieldElement3 = new XTextInputFieldElement();
			xTextInputFieldElement3.z0dr("NsoElementTypeName", "NewControl");
			xTextInputFieldElement3.z0dr("NsoControlTypeName", "MultiListBox");
			xTextInputFieldElement3.z0dr("Type", Convert.ToInt32(p2).ToString());
			xTextInputFieldElement3.ID = p0;
			xTextInputFieldElement3.UserEditable = true;
			xTextInputFieldElement3.BackgroundText = "XX";
			xTextInputFieldElement3.StartBorderText = "[";
			xTextInputFieldElement3.EndBorderText = "]";
			xTextInputFieldElement3.EditorActiveMode = ValueEditorActiveMode.F2 | ValueEditorActiveMode.MouseDblClick | ValueEditorActiveMode.MouseClick;
			if (!string.IsNullOrEmpty(p1))
			{
				xTextInputFieldElement3.z0zek(p1);
			}
			xTextInputFieldElement3.AcceptChildElementTypes2 = ElementType.Text;
			xTextInputFieldElement3.FieldSettings = new InputFieldSettings();
			xTextInputFieldElement3.FieldSettings.z0eek(InputFieldEditStyle.DropdownList);
			xTextInputFieldElement3.FieldSettings.z0eek(p0: true);
			xTextInputFieldElement3.EnableHighlight = z0rek;
			return xTextInputFieldElement3;
		}
		case (z0ZzZzfrk)7:
		{
			XTextInputFieldElement xTextInputFieldElement6 = new XTextInputFieldElement();
			xTextInputFieldElement6.z0dr("NsoElementTypeName", "NewControl");
			xTextInputFieldElement6.z0dr("NsoControlTypeName", "MultiComBox");
			xTextInputFieldElement6.z0dr("Type", Convert.ToInt32(p2).ToString());
			xTextInputFieldElement6.ID = p0;
			xTextInputFieldElement6.BackgroundText = "XX";
			xTextInputFieldElement6.StartBorderText = "[";
			xTextInputFieldElement6.EndBorderText = "]";
			xTextInputFieldElement6.UserEditable = true;
			xTextInputFieldElement6.EditorActiveMode = ValueEditorActiveMode.F2 | ValueEditorActiveMode.MouseDblClick | ValueEditorActiveMode.MouseClick;
			if (!string.IsNullOrEmpty(p1))
			{
				xTextInputFieldElement6.z0zek(p1);
			}
			xTextInputFieldElement6.AcceptChildElementTypes2 = ElementType.Text;
			xTextInputFieldElement6.FieldSettings = new InputFieldSettings();
			xTextInputFieldElement6.FieldSettings.z0eek(InputFieldEditStyle.DropdownList);
			xTextInputFieldElement6.FieldSettings.z0eek(p0: true);
			xTextInputFieldElement6.EnableHighlight = z0rek;
			return xTextInputFieldElement6;
		}
		case (z0ZzZzfrk)9:
		{
			XTextInputFieldElement xTextInputFieldElement4 = new XTextInputFieldElement();
			xTextInputFieldElement4.z0dr("NsoElementTypeName", "NewControl");
			xTextInputFieldElement4.z0dr("NsoControlTypeName", "DateTimeBox");
			xTextInputFieldElement4.z0dr("Type", Convert.ToInt32(p2).ToString());
			xTextInputFieldElement4.ID = p0;
			xTextInputFieldElement4.UserEditable = true;
			xTextInputFieldElement4.StartBorderText = "[";
			xTextInputFieldElement4.EndBorderText = "]";
			xTextInputFieldElement4.EditorActiveMode = ValueEditorActiveMode.F2 | ValueEditorActiveMode.MouseDblClick | ValueEditorActiveMode.MouseClick;
			if (!string.IsNullOrEmpty(p1))
			{
				xTextInputFieldElement4.z0zek(p1);
			}
			xTextInputFieldElement4.AcceptChildElementTypes2 = ElementType.Text;
			xTextInputFieldElement4.DisplayFormat = new z0ZzZzsok();
			xTextInputFieldElement4.DisplayFormat.Style = ValueFormatStyle.DateTime;
			xTextInputFieldElement4.DisplayFormat.Format = z0ZzZzkfh.z0mek;
			xTextInputFieldElement4.BackgroundText = z0ZzZzkfh.z0mek;
			xTextInputFieldElement4.FieldSettings = new InputFieldSettings();
			xTextInputFieldElement4.FieldSettings.z0eek(InputFieldEditStyle.DateTime);
			xTextInputFieldElement4.EnableHighlight = z0rek;
			return xTextInputFieldElement4;
		}
		case (z0ZzZzfrk)10:
		{
			XTextRadioBoxElement xTextRadioBoxElement = new XTextRadioBoxElement();
			xTextRadioBoxElement.z0dr("Type", Convert.ToInt32(p2).ToString());
			xTextRadioBoxElement.ID = p0;
			xTextRadioBoxElement.Caption = p1;
			xTextRadioBoxElement.Deleteable = true;
			return xTextRadioBoxElement;
		}
		case (z0ZzZzfrk)6:
		{
			XTextInputFieldElement xTextInputFieldElement = new XTextInputFieldElement();
			xTextInputFieldElement.z0dr("NsoElementTypeName", "NewControl");
			xTextInputFieldElement.z0dr("NsoControlTypeName", "MultiCheckbox");
			xTextInputFieldElement.z0dr("Type", Convert.ToInt32(p2).ToString());
			xTextInputFieldElement.ID = p0;
			xTextInputFieldElement.BackgroundText = "XX";
			xTextInputFieldElement.StartBorderText = "[";
			xTextInputFieldElement.EndBorderText = "]";
			xTextInputFieldElement.UserEditable = true;
			xTextInputFieldElement.EditorActiveMode = ValueEditorActiveMode.F2 | ValueEditorActiveMode.MouseDblClick | ValueEditorActiveMode.MouseClick;
			if (!string.IsNullOrEmpty(p1))
			{
				xTextInputFieldElement.z0zek(p1);
			}
			xTextInputFieldElement.AcceptChildElementTypes2 = ElementType.Text;
			xTextInputFieldElement.EnableHighlight = z0rek;
			return xTextInputFieldElement;
		}
		default:
			return null;
		}
	}
}
