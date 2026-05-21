using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DCSoft.Drawing;
using DCSoft.Writer;
using DCSoft.Writer.Dom;

namespace zzz;

internal sealed class z0ZzZzlnj : z0ZzZzcmj
{
	[z0ZzZzimj("Cut", ReturnValueType = typeof(bool), FunctionID = 52)]
	private void z0eek(object p0, z0ZzZzomj p1)
	{
		if (p1.Mode == (z0ZzZzmmj)2)
		{
			p1.Enabled = p1.DocumentControler != null && p1.DocumentControler.z0yp();
		}
		else if (p1.Mode == (z0ZzZzmmj)5)
		{
			p1.Result = false;
			p1.Result = p1.DocumentControler.z0qn(p1.ShowUI);
			p1.RefreshLevel = (z0ZzZzwmj)2;
		}
	}

	[z0ZzZzimj("DeleteLine", ReturnValueType = typeof(bool))]
	private void z0rek(object p0, z0ZzZzomj p1)
	{
		if (p1.Mode == (z0ZzZzmmj)2)
		{
			p1.Enabled = p1.EditorControl != null && !p1.EditorControl.z0ork();
		}
		else
		{
			if (p1.Mode != (z0ZzZzmmj)5)
			{
				return;
			}
			p1.Result = false;
			z0ZzZzzlh z0ZzZzzlh2 = null;
			z0ZzZzplh z0ZzZzplh2 = p1.Document.z0ryk();
			if (p1.Parameter is XTextElement)
			{
				XTextElement xTextElement = (XTextElement)p1.Parameter;
				z0ZzZzzlh2 = xTextElement.z0ptk();
				if (xTextElement.z0ie() != null)
				{
					z0ZzZzzlh2 = xTextElement.z0ie().z0ptk();
				}
			}
			else
			{
				z0ZzZzzlh2 = z0ZzZzplh2.z0lrk();
			}
			if (z0ZzZzzlh2 == null)
			{
				return;
			}
			XTextContentElement xTextContentElement = z0ZzZzzlh2[0].z0jy();
			z0ZzZzhkh z0ZzZzhkh2 = new z0ZzZzhkh(z0ZzZzzlh2[0].z0qek());
			int num = z0ZzZzplh2.IndexOf(z0ZzZzzlh2[0]);
			XTextElement lastElement = z0ZzZzzlh2.LastElement;
			int num2 = z0ZzZzplh2.IndexOf(lastElement);
			if (lastElement is XTextParagraphFlagElement && xTextContentElement.z0be().LastElement == lastElement)
			{
				num2--;
			}
			if (num2 < num)
			{
				return;
			}
			num = z0ZzZzplh2.z0tek(num, (z0ZzZzfxj)1, p2: false);
			for (num2 = z0ZzZzplh2.z0tek(num2, (z0ZzZzfxj)0, p2: false); num <= num2 && !p1.DocumentControler.z0tp(z0ZzZzplh2[num], (z0ZzZzbcj)255); num++)
			{
			}
			while (num2 >= num && !p1.DocumentControler.z0tp(z0ZzZzplh2[num2], (z0ZzZzbcj)255))
			{
				num2--;
			}
			if (num2 >= num)
			{
				z0ZzZzhkh2.z0tek(num, num2 - num + 1);
				p1.Document.z0ytk();
				int num3 = z0ZzZzplh2.z0tek(p0: true, p1: false, p2: false, z0ZzZzhkh2);
				p1.Document.z0nuk();
				if (num3 > 0)
				{
					z0ZzZzplh2.z0tek(num, p1: false);
				}
				p1.Result = num3 > 0;
				p1.RefreshLevel = (z0ZzZzwmj)2;
			}
		}
	}

	[z0ZzZzimj("ClearCurrentFieldValue", ReturnValueType = typeof(bool))]
	private void z0tek(object p0, z0ZzZzomj p1)
	{
		if (p1.Mode == (z0ZzZzmmj)2)
		{
			p1.Enabled = false;
			if (p1.EditorControl != null && (XTextInputFieldElement)p1.Document.z0bek(typeof(XTextInputFieldElement)) != null)
			{
				p1.Enabled = true;
			}
		}
		else
		{
			if (p1.Mode != (z0ZzZzmmj)5)
			{
				return;
			}
			p1.Result = false;
			XTextInputFieldElement xTextInputFieldElement = (XTextInputFieldElement)p1.Document.z0bek(typeof(XTextInputFieldElement));
			if (xTextInputFieldElement == null || !p1.DocumentControler.z0pm(xTextInputFieldElement, (z0ZzZzbcj)255))
			{
				return;
			}
			p1.Document.z0ytk();
			bool flag = false;
			p1.Document.z0ryk().z0tek(xTextInputFieldElement.z0hy().z0jrk() + 1, p1: false);
			if (xTextInputFieldElement.z0cek(null, (z0ZzZzbcj)255, p2: false, p3: true))
			{
				flag = true;
			}
			string innerValue = xTextInputFieldElement.InnerValue;
			if (!string.IsNullOrEmpty(innerValue))
			{
				if (p1.Document.z0uik())
				{
					p1.Document.z0imk().z0eek("InnerValue", innerValue, null, xTextInputFieldElement);
				}
				xTextInputFieldElement.InnerValue = null;
				flag = true;
			}
			p1.Document.z0nuk();
			p1.Result = flag;
		}
	}

	[z0ZzZzimj("CopyAsText", ReturnValueType = typeof(bool), FunctionID = 51)]
	private void z0yek(object p0, z0ZzZzomj p1)
	{
		if (p1.Mode == (z0ZzZzmmj)2)
		{
			p1.Enabled = p1.DocumentControler != null && p1.DocumentControler.z0rn();
		}
		else if (p1.Mode == (z0ZzZzmmj)5)
		{
			p1.Result = p1.DocumentControler.z0sn();
			p1.RefreshLevel = (z0ZzZzwmj)2;
		}
	}

	[z0ZzZzimj("DeleteField", ReturnValueType = typeof(bool))]
	private void z0uek(object p0, z0ZzZzomj p1)
	{
		if (p1.Document == null)
		{
			p1.Enabled = false;
			return;
		}
		XTextElement xTextElement = p1.Document.z0itk();
		if (p1.Parameter is XTextElement)
		{
			xTextElement = (XTextElement)p1.Parameter;
		}
		while (xTextElement != null && !(xTextElement is XTextFieldElementBase))
		{
			xTextElement = xTextElement.z0ji();
		}
		if (p1.Mode == (z0ZzZzmmj)2)
		{
			if (xTextElement == null)
			{
				p1.Enabled = false;
			}
			else
			{
				p1.Enabled = p1.DocumentControler != null && p1.DocumentControler.z0lm(xTextElement);
			}
		}
		else if (p1.Mode == (z0ZzZzmmj)5)
		{
			p1.Result = false;
			XTextFieldElementBase obj = (XTextFieldElementBase)xTextElement;
			int p2 = obj.z0jrk().z0jrk();
			if (obj.z0le(p0: true))
			{
				p1.Document.z0ryk().z0tek(p2, 0);
				p1.RefreshLevel = (z0ZzZzwmj)2;
				p1.Result = true;
			}
		}
	}

	[z0ZzZzimj("Copy", ReturnValueType = typeof(bool), FunctionID = 51)]
	private void z0iek(object p0, z0ZzZzomj p1)
	{
		if (p1.Mode == (z0ZzZzmmj)2)
		{
			p1.Enabled = p1.DocumentControler != null && p1.DocumentControler.z0rn();
		}
		else
		{
			if (p1.Mode != (z0ZzZzmmj)5)
			{
				return;
			}
			if (p1.ShowUI)
			{
				try
				{
					p1.Result = p1.DocumentControler.z0mm();
					p1.RefreshLevel = (z0ZzZzwmj)2;
					return;
				}
				catch (Exception ex)
				{
					z0ZzZzfpj.z0yek(null, ex.ToString());
					return;
				}
			}
			p1.Result = p1.DocumentControler.z0mm();
			p1.RefreshLevel = (z0ZzZzwmj)2;
		}
	}

	[z0ZzZzimj("InsertMode", ShortcutKey = Keys.Insert, ReturnValueType = typeof(bool))]
	private void z0oek(object p0, z0ZzZzomj p1)
	{
		if (p1.Mode == (z0ZzZzmmj)2)
		{
			p1.Enabled = p1.EditorControl != null;
			p1.Checked = p1.EditorControl != null && p1.EditorControl.z0duk();
		}
		else if (p1.Mode == (z0ZzZzmmj)5)
		{
			bool flag = z0ZzZzafh.z0yek(p1.Parameter, !p1.EditorControl.z0duk());
			if (flag != p1.EditorControl.z0duk())
			{
				p1.EditorControl.z0ark(flag);
				p1.EditorControl.z0vik();
				p1.EditorControl.z0eek(EventArgs.Empty);
			}
			p1.Result = p1.EditorControl.z0duk();
		}
	}

	[z0ZzZzimj("SetDefaultStyle", ReturnValueType = typeof(bool))]
	private void z0pek(object p0, z0ZzZzomj p1)
	{
		if (p1.Mode == (z0ZzZzmmj)2)
		{
			p1.Enabled = false;
			if (p1.Document != null && !p1.EditorControl.z0ork())
			{
				p1.Enabled = true;
			}
		}
		else
		{
			if (p1.Mode != (z0ZzZzmmj)5)
			{
				return;
			}
			p1.Result = false;
			DocumentContentStyle documentContentStyle = null;
			if (p1.Parameter is string)
			{
				documentContentStyle = new DocumentContentStyle();
				documentContentStyle.z0eek(p0: true);
				z0ZzZzsyk obj = new z0ZzZzsyk((string)p1.Parameter);
				bool flag = false;
				foreach (z0ZzZzqyk item in obj)
				{
					z0ZzZzcik z0ZzZzcik2 = z0ZzZzcik.z0eek(typeof(DocumentContentStyle), item.z0eek());
					if (z0ZzZzcik2 == null)
					{
						continue;
					}
					Type type = z0ZzZzcik2.z0tek();
					try
					{
						if (type.Equals(typeof(string)))
						{
							documentContentStyle.z0eek(z0ZzZzcik2, item.z0rek());
						}
						else
						{
							object p2 = Convert.ChangeType(item.z0rek(), type);
							documentContentStyle.z0eek(z0ZzZzcik2, p2);
						}
						flag = true;
					}
					catch
					{
					}
				}
				if (!flag)
				{
					documentContentStyle = null;
				}
			}
			else if (p1.Parameter is DocumentContentStyle)
			{
				documentContentStyle = (DocumentContentStyle)p1.Parameter;
			}
			if (documentContentStyle != null)
			{
				p1.Document.z0bek(documentContentStyle, p1: true);
				p1.RefreshLevel = (z0ZzZzwmj)2;
				p1.Result = true;
			}
		}
	}

	[z0ZzZzimj("HeaderBottomLineVisible", ReturnValueType = typeof(bool), DefaultResultValue = true)]
	private void z0mek(object p0, z0ZzZzomj p1)
	{
		if (p1.Mode == (z0ZzZzmmj)2)
		{
			p1.Enabled = p1.Document != null;
			if (p1.Document != null)
			{
				p1.Checked = p1.Document.z0ipk().ShowHeaderBottomLine != DCBooleanValue.False;
			}
		}
		else
		{
			if (p1.Mode != (z0ZzZzmmj)5)
			{
				return;
			}
			DCBooleanValue dCBooleanValue = DCBooleanValue.True;
			dCBooleanValue = ((p1.Document.z0ipk().ShowHeaderBottomLine == DCBooleanValue.True) ? DCBooleanValue.False : DCBooleanValue.True);
			if (p1.Parameter is bool)
			{
				dCBooleanValue = ((!(bool)p1.Parameter) ? DCBooleanValue.False : DCBooleanValue.True);
			}
			else if (p1.Parameter is DCBooleanValue)
			{
				dCBooleanValue = (DCBooleanValue)p1.Parameter;
			}
			if (p1.Document.z0ipk().ShowHeaderBottomLine != dCBooleanValue)
			{
				if (p1.Document.z0ytk())
				{
					p1.Document.z0imk().z0eek("ShowHeaderBottomLine", p1.Document.z0ipk().ShowHeaderBottomLine, dCBooleanValue, p1.Document.z0ipk());
					p1.Document.z0nuk();
				}
				p1.Document.z0ipk().ShowHeaderBottomLine = dCBooleanValue;
				p1.Document.Modified = true;
				((XTextElement)p1.Document).z0rrk();
				p1.Document.OnDocumentContentChanged();
				p1.RefreshLevel = (z0ZzZzwmj)1;
				if (p1.EditorControl != null)
				{
					p1.EditorControl.z0ypk().z0hz();
				}
			}
		}
	}

	[z0ZzZzimj("Redo", ShortcutKey = (Keys.Y | Keys.Control), ReturnValueType = typeof(bool))]
	private void z0nek(object p0, z0ZzZzomj p1)
	{
		if (p1.Mode == (z0ZzZzmmj)2)
		{
			p1.Enabled = false;
			if (p1.Document != null)
			{
				p1.Enabled = !p1.DocumentControler.z0kn() && p1.Document.z0imk() != null && p1.Document.z0imk().z0yek() && p1.Document.z0bu().EnableLogUndo;
			}
		}
		else if (p1.Mode == (z0ZzZzmmj)5)
		{
			p1.Result = false;
			z0ZzZzpgh p2 = new z0ZzZzpgh();
			p1.EditorControl.z0zyk();
			p1.EditorControl.z0iuk();
			p1.Document.z0qtk().ExecutingRedo = true;
			try
			{
				p1.Result = p1.Document.z0imk().z0eek(p2);
			}
			finally
			{
				p1.Document.z0qtk().ExecutingRedo = false;
			}
			p1.RefreshLevel = (z0ZzZzwmj)2;
		}
	}

	[z0ZzZzimj("Undo", ShortcutKey = (Keys.Z | Keys.Control), ReturnValueType = typeof(bool))]
	private void z0bek(object p0, z0ZzZzomj p1)
	{
		if (p1.Mode == (z0ZzZzmmj)2)
		{
			p1.Enabled = false;
			if (p1.Document != null)
			{
				p1.Enabled = !p1.DocumentControler.z0kn() && p1.Document.z0imk() != null && p1.Document.z0imk().z0pek() && p1.Document.z0bu().EnableLogUndo;
			}
		}
		else if (p1.Mode == (z0ZzZzmmj)5)
		{
			p1.Result = false;
			z0ZzZzpgh p2 = new z0ZzZzpgh();
			p1.EditorControl.z0zyk();
			p1.EditorControl.z0iuk();
			p1.Document.z0qtk().ExecutingUndo = true;
			try
			{
				p1.Result = p1.Document.z0imk().z0rek(p2);
			}
			finally
			{
				p1.Document.z0qtk().ExecutingUndo = false;
			}
			p1.RefreshLevel = (z0ZzZzwmj)2;
		}
	}

	[z0ZzZzimj("SearchReplace", ShortcutKey = (Keys.F | Keys.Control))]
	private void z0vek(object p0, z0ZzZzomj p1)
	{
		if (p1.Mode == (z0ZzZzmmj)2)
		{
			p1.Enabled = p1.EditorControl != null && p1.Document != null;
		}
		else if (p1.Mode == (z0ZzZzmmj)5)
		{
			z0eek(p1, p1: true);
		}
	}

	[z0ZzZzimj("PasteAsText", ReturnValueType = typeof(bool), FunctionID = 53)]
	private void z0cek(object p0, z0ZzZzomj p1)
	{
		if (p1.Mode == (z0ZzZzmmj)2)
		{
			p1.Enabled = false;
			if (p1.EditorControl != null && p1.DocumentControler.z0up())
			{
				p1.Enabled = true;
			}
		}
		else if (p1.Mode == (z0ZzZzmmj)5)
		{
			p1.Result = false;
			p1.Result = p1.EditorControl.z0eek(z0ZzZzvwh.z0iek, p1.ShowUI);
			p1.RefreshLevel = (z0ZzZzwmj)2;
		}
	}

	[z0ZzZzimj("Paste", ReturnValueType = typeof(bool), FunctionID = 53)]
	private void z0xek(object p0, z0ZzZzomj p1)
	{
		if (p1.Mode == (z0ZzZzmmj)2)
		{
			p1.Enabled = false;
			if (p1.EditorControl != null && p1.DocumentControler.z0up())
			{
				p1.Enabled = true;
			}
		}
		else if (p1.Mode == (z0ZzZzmmj)5)
		{
			p1.Result = false;
			p1.Result = p1.EditorControl.z0eek((string)null, p1.ShowUI);
			p1.RefreshLevel = (z0ZzZzwmj)2;
		}
	}

	protected override z0ZzZzvmj z0qz()
	{
		z0ZzZzvmj obj = new z0ZzZzvmj();
		z0ZzZzcmj.z0rek(obj, "Backspace", z0srk, Keys.Back);
		z0ZzZzcmj.z0rek(obj, "ClearAllFieldValue", z0drk);
		z0ZzZzcmj.z0rek(obj, "ClearBodyContent", z0erk);
		z0ZzZzcmj.z0rek(obj, "ClearCurrentFieldValue", z0tek);
		z0ZzZzcmj.z0rek(obj, "ClearUndo", z0qrk);
		z0ZzZzcmj.z0rek(obj, "Copy", z0iek);
		z0ZzZzcmj.z0rek(obj, "CopyAsText", z0yek);
		z0ZzZzcmj.z0rek(obj, "CopyWithClearFieldValue", z0wrk);
		z0ZzZzcmj.z0rek(obj, "Cut", z0eek);
		z0ZzZzcmj.z0rek(obj, "Delete", z0hrk, Keys.Delete);
		z0ZzZzcmj.z0rek(obj, "DeleteAbsolute", z0zek);
		z0ZzZzcmj.z0rek(obj, "DeleteField", z0uek);
		z0ZzZzcmj.z0rek(obj, "DeleteLine", z0rek);
		z0ZzZzcmj.z0rek(obj, "DeleteRedundant", z0grk);
		z0ZzZzcmj.z0rek(obj, "ExecuteElementDefaultMethod", z0lrk, Keys.F2);
		z0ZzZzcmj.z0rek(obj, "FieldSpecifyWidth", z0jrk);
		z0ZzZzcmj.z0rek(obj, "HeaderBottomLineVisible", z0mek);
		z0ZzZzcmj.z0rek(obj, "InsertMode", z0oek, Keys.Insert);
		z0ZzZzcmj.z0rek(obj, "Paste", z0xek);
		z0ZzZzcmj.z0rek(obj, "PasteAsText", z0cek);
		z0ZzZzcmj.z0rek(obj, "Redo", z0nek, Keys.Y | Keys.Control);
		z0ZzZzcmj.z0rek(obj, "Search", z0frk);
		z0ZzZzcmj.z0rek(obj, "SearchReplace", z0vek, Keys.F | Keys.Control);
		z0ZzZzcmj.z0rek(obj, "SetDefaultStyle", z0pek);
		z0ZzZzcmj.z0rek(obj, "SignDocument", z0krk);
		z0ZzZzcmj.z0rek(obj, "SpecifyPaste", z0ark);
		z0ZzZzcmj.z0rek(obj, "Undo", z0bek, Keys.Z | Keys.Control);
		return obj;
	}

	[z0ZzZzimj("DeleteAbsolute", ReturnValueType = typeof(bool))]
	private void z0zek(object p0, z0ZzZzomj p1)
	{
		if (p1.Mode == (z0ZzZzmmj)2)
		{
			p1.Enabled = p1.Document != null;
		}
		else if (p1.Mode == (z0ZzZzmmj)5)
		{
			p1.Result = false;
			bool flag = false;
			bool p2 = p1.EditorControl.z0hik();
			bool enableLogicDelete = p1.Document.z0hi().EnableLogicDelete;
			try
			{
				p1.EditorControl.z0srk(p0: true);
				p1.Document.z0hi().EnableLogicDelete = false;
				flag = p1.DocumentControler.z0hn(p1.ShowUI);
			}
			finally
			{
				p1.EditorControl.z0srk(p2);
				p1.Document.z0hi().EnableLogicDelete = enableLogicDelete;
			}
			p1.Result = flag;
			p1.RefreshLevel = (z0ZzZzwmj)2;
		}
	}

	[z0ZzZzimj("ExecuteElementDefaultMethod", ShortcutKey = Keys.F2)]
	private void z0lrk(object p0, z0ZzZzomj p1)
	{
		if (p1.Mode == (z0ZzZzmmj)2)
		{
			p1.Enabled = false;
			if (p1.EditorControl != null && !p1.EditorControl.z0ork())
			{
				p1.Enabled = true;
			}
		}
		else if (p1.Mode == (z0ZzZzmmj)5)
		{
			p1.EditorControl.z0tek(p1.EditorControl.z0ipk());
		}
	}

	[z0ZzZzimj("SignDocument", ReturnValueType = typeof(XTextSignElement))]
	private void z0krk(object p0, z0ZzZzomj p1)
	{
		if (p1.Mode == (z0ZzZzmmj)2)
		{
			p1.Enabled = false;
			if (p1.DocumentControler != null && p1.DocumentControler.z0an(typeof(XTextSignElement)) && p1.Document.z0oik() == PageContentPartyStyle.Body && p1.Document.z0hi().EnablePermission)
			{
				p1.Enabled = true;
			}
		}
		else if (p1.Mode == (z0ZzZzmmj)5)
		{
			p1.Result = p1.DocumentControler.z0km();
			p1.RefreshLevel = (z0ZzZzwmj)2;
		}
	}

	[z0ZzZzimj("FieldSpecifyWidth", ReturnValueType = typeof(bool))]
	private void z0jrk(object p0, z0ZzZzomj p1)
	{
		if (p1.Mode == (z0ZzZzmmj)2)
		{
			if (p1.Document == null)
			{
				p1.Enabled = false;
				p1.Checked = false;
				return;
			}
			XTextInputFieldElementBase xTextInputFieldElementBase = (XTextInputFieldElementBase)p1.Document.z0bek(typeof(XTextInputFieldElementBase));
			if (xTextInputFieldElementBase == null || !p1.DocumentControler.z0np(xTextInputFieldElementBase))
			{
				p1.Enabled = false;
				return;
			}
			p1.Enabled = true;
			p1.Checked = xTextInputFieldElementBase.SpecifyWidth > 0f;
		}
		else
		{
			if (p1.Mode != (z0ZzZzmmj)5)
			{
				return;
			}
			p1.Result = false;
			XTextInputFieldElementBase xTextInputFieldElementBase2 = (XTextInputFieldElementBase)p1.Document.z0bek(typeof(XTextInputFieldElementBase));
			if (xTextInputFieldElementBase2 == null || !p1.DocumentControler.z0np(xTextInputFieldElementBase2))
			{
				return;
			}
			float num = 0f;
			XTextElementList xTextElementList = new XTextElementList();
			XTextContainerElement.z0eok_jiejie20260327142557 z0eok_jiejie20260327142557 = new XTextContainerElement.z0eok_jiejie20260327142557(xTextInputFieldElementBase2.z0jr(), xTextElementList, p2: true);
			xTextInputFieldElementBase2.z0ue(z0eok_jiejie20260327142557);
			z0eok_jiejie20260327142557.Dispose();
			float num2 = 0f;
			if (num2 < p1.Document.z0xek(XTextFieldBorderElement.z0drk_jiejie20260327142557) * 4f)
			{
				using zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = xTextElementList.z0ltk();
				while (z0bpk.MoveNext())
				{
					XTextElement current = z0bpk.Current;
					num2 = ((!(current is XTextFieldBorderElement)) ? (num2 + current.Width) : (num2 + p1.Document.z0xek(XTextFieldBorderElement.z0drk_jiejie20260327142557)));
				}
			}
			if (!(p1.Parameter is bool))
			{
				num = ((xTextInputFieldElementBase2.SpecifyWidth != 0f) ? 0f : num2);
			}
			else if ((bool)p1.Parameter)
			{
				num = num2;
			}
			if (xTextInputFieldElementBase2.SpecifyWidth != num)
			{
				if (p1.Document.z0ytk())
				{
					p1.Document.z0imk().z0eek("SpecifyWidth", xTextInputFieldElementBase2.SpecifyWidth, num, xTextInputFieldElementBase2);
					p1.Document.z0nuk();
				}
				xTextInputFieldElementBase2.SpecifyWidth = num;
				p1.Document.Modified = true;
				p1.Document.OnDocumentContentChanged();
				p1.Result = true;
			}
		}
	}

	[z0ZzZzimj("Delete", ShortcutKey = Keys.Delete, ReturnValueType = typeof(bool))]
	private void z0hrk(object p0, z0ZzZzomj p1)
	{
		if (p1.Mode == (z0ZzZzmmj)2)
		{
			p1.Enabled = p1.DocumentControler != null && p1.DocumentControler.z0in().z0tek();
		}
		else if (p1.Mode == (z0ZzZzmmj)5)
		{
			p1.Result = false;
			bool flag = false;
			flag = p1.DocumentControler.z0hn(p1.ShowUI);
			p1.Result = flag;
			p1.RefreshLevel = (z0ZzZzwmj)2;
		}
	}

	[z0ZzZzimj("DeleteRedundant", ReturnValueType = typeof(int))]
	private void z0grk(object p0, z0ZzZzomj p1)
	{
		if (p1.Mode == (z0ZzZzmmj)2)
		{
			p1.Enabled = p1.Document != null && p1.Document.z0jrk() != null && !p1.DocumentControler.z0kn();
		}
		else if (p1.Mode == (z0ZzZzmmj)5)
		{
			p1.Result = 0;
			XTextContentElement xTextContentElement = p1.Document.z0jrk();
			if (p1.Parameter is XTextContentElement)
			{
				xTextContentElement = (XTextContentElement)p1.Parameter;
			}
			int num = xTextContentElement.z0eek(p0: true, p1: true, p2: true, p3: true, p4: true, p5: true);
			if (num > 0)
			{
				p1.Result = num;
				p1.RefreshLevel = (z0ZzZzwmj)2;
			}
		}
	}

	[z0ZzZzimj("Search")]
	private void z0frk(object p0, z0ZzZzomj p1)
	{
		if (p1.Mode == (z0ZzZzmmj)2)
		{
			p1.Enabled = p1.EditorControl != null && p1.Document != null;
		}
		else if (p1.Mode == (z0ZzZzmmj)5)
		{
			z0eek(p1, p1: false);
		}
	}

	private void z0eek(z0ZzZzomj p0, bool p1)
	{
		p0.Result = -1;
		z0ZzZzsmj z0ZzZzsmj2 = p0.Parameter as z0ZzZzsmj;
		p0.Result = -1;
		if (z0ZzZzsmj2 != null)
		{
			z0ZzZzvpj z0ZzZzvpj2 = new z0ZzZzvpj(p0.Document);
			if (z0ZzZzsmj2.z0cek())
			{
				int num = z0ZzZzvpj2.z0eek(z0ZzZzsmj2);
				p0.Result = num;
				p0.RefreshLevel = (z0ZzZzwmj)0;
			}
			else
			{
				int num2 = z0ZzZzvpj2.z0eek(z0ZzZzsmj2, p1: true, -1);
				p0.Result = num2;
				p0.RefreshLevel = (z0ZzZzwmj)0;
			}
		}
	}

	[z0ZzZzimj("ClearAllFieldValue", ReturnValueType = typeof(bool))]
	private void z0drk(object p0, z0ZzZzomj p1)
	{
		if (p1.Mode == (z0ZzZzmmj)2)
		{
			p1.Enabled = p1.EditorControl != null && !p1.EditorControl.z0ork();
		}
		else
		{
			if (p1.Mode != (z0ZzZzmmj)5)
			{
				return;
			}
			p1.Result = false;
			bool flag = false;
			XTextElementList xTextElementList = p1.Document.z0xyk().z0nek<XTextInputFieldElement>();
			if (xTextElementList == null || xTextElementList.Count <= 0)
			{
				return;
			}
			p1.Document.z0ytk();
			using (zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = xTextElementList.z0ltk())
			{
				while (z0bpk.MoveNext())
				{
					XTextInputFieldElement xTextInputFieldElement = (XTextInputFieldElement)z0bpk.Current;
					if (!p1.DocumentControler.z0pm(xTextInputFieldElement, (z0ZzZzbcj)255))
					{
						continue;
					}
					bool flag2 = false;
					if (xTextInputFieldElement.z0cek(null, (z0ZzZzbcj)255, p2: false, p3: true))
					{
						flag2 = true;
					}
					string innerValue = xTextInputFieldElement.InnerValue;
					if (!string.IsNullOrEmpty(innerValue))
					{
						if (p1.Document.z0uik())
						{
							p1.Document.z0imk().z0eek("InnerValue", innerValue, null, xTextInputFieldElement);
						}
						xTextInputFieldElement.InnerValue = null;
						flag2 = true;
					}
					if (flag2)
					{
						flag = true;
					}
				}
			}
			p1.Document.z0nuk();
			p1.Document.Modified = true;
			p1.Result = flag;
		}
	}

	[z0ZzZzimj("Backspace", ShortcutKey = Keys.Back, ReturnValueType = typeof(bool))]
	private void z0srk(object p0, z0ZzZzomj p1)
	{
		if (p1.Mode == (z0ZzZzmmj)2)
		{
			p1.Enabled = p1.EditorControl != null;
		}
		else
		{
			if (p1.Mode != (z0ZzZzmmj)5)
			{
				return;
			}
			p1.Result = false;
			if (p1.Document.z0cuk().z0yek() == ContentRangeMode.Cell)
			{
				List<XTextTableRowElement> list = new List<XTextTableRowElement>();
				List<XTextTableColumnElement> list2 = new List<XTextTableColumnElement>();
				XTextElementList xTextElementList = p1.Document.z0cuk().z0irk();
				bool flag = true;
				bool flag2 = true;
				XTextTableElement xTextTableElement = ((XTextTableCellElement)xTextElementList[0]).z0gr();
				for (int i = 0; i < xTextElementList.Count; i++)
				{
					XTextTableCellElement xTextTableCellElement = (XTextTableCellElement)xTextElementList[i];
					if (xTextTableCellElement.z0gr() != xTextTableElement)
					{
						flag = false;
						flag2 = false;
						break;
					}
					if (xTextTableCellElement.z0drk() != null && !list2.Contains(xTextTableCellElement.z0drk()))
					{
						list2.Add(xTextTableCellElement.z0drk());
						XTextTableColumnElement xTextTableColumnElement = xTextTableCellElement.z0drk();
						int num = 0;
						for (int j = i; j < xTextElementList.Count; j++)
						{
							if (((XTextTableCellElement)xTextElementList[j]).z0drk() == xTextTableColumnElement)
							{
								num++;
								if (num == xTextTableElement.z0stk().Count)
								{
									break;
								}
							}
						}
						if (num != xTextTableElement.z0stk().Count)
						{
							flag2 = false;
						}
					}
					if (xTextTableCellElement.z0krk() != null && !list.Contains(xTextTableCellElement.z0krk()))
					{
						list.Add(xTextTableCellElement.z0krk());
						XTextTableRowElement xTextTableRowElement = xTextTableCellElement.z0krk();
						int num2 = 0;
						for (int k = i; k < xTextElementList.Count; k++)
						{
							if (xTextElementList[k].z0ji() == xTextTableRowElement)
							{
								num2++;
								if (num2 == xTextTableRowElement.z0rek().Count)
								{
									break;
								}
							}
						}
						if (num2 != xTextTableRowElement.z0rek().Count)
						{
							flag = false;
						}
					}
					if (!flag && !flag2)
					{
						break;
					}
				}
				if (flag)
				{
					p1.Result = p1.EditorControl.z0eek("Table_DeleteRow", p1);
					p1.RefreshLevel = (z0ZzZzwmj)2;
				}
				else if (flag2)
				{
					p1.Result = p1.EditorControl.z0eek("Table_DeleteColumn", p1);
					p1.RefreshLevel = (z0ZzZzwmj)2;
				}
				else if (p1.ShowUI)
				{
					z0ZzZzroj.z0vek(p1.EditorControl.z0tj());
				}
				else
				{
					p1.Result = p1.EditorControl.z0eek("Table_DeleteRow", p1);
					p1.RefreshLevel = (z0ZzZzwmj)2;
				}
			}
			else if (p1.EditorControl.z0erk().z0fm(p1.ShowUI))
			{
				p1.Result = true;
				p1.RefreshLevel = (z0ZzZzwmj)2;
			}
		}
	}

	[z0ZzZzimj("SpecifyPaste", ReturnValueType = typeof(bool), FunctionID = 54)]
	private void z0ark(object p0, z0ZzZzomj p1)
	{
		if (p1.Mode == (z0ZzZzmmj)2)
		{
			p1.Enabled = false;
			if (p1.EditorControl != null && p1.DocumentControler.z0up())
			{
				p1.Enabled = true;
			}
		}
		else if (p1.Mode == (z0ZzZzmmj)5)
		{
			p1.Result = false;
			string text = p1.Parameter as string;
			if (!string.IsNullOrEmpty(text))
			{
				p1.Result = p1.EditorControl.z0eek(text, p1.ShowUI);
				p1.RefreshLevel = (z0ZzZzwmj)2;
			}
		}
	}

	[z0ZzZzimj("ClearUndo")]
	private void z0qrk(object p0, z0ZzZzomj p1)
	{
		if (p1.Mode == (z0ZzZzmmj)2)
		{
			p1.Enabled = p1.Document != null;
		}
		else if (p1.Mode == (z0ZzZzmmj)5)
		{
			p1.Result = false;
			if (p1.Document != null && p1.Document.z0imk() != null)
			{
				p1.Document.z0mrk();
				p1.Document.z0imk().Clear();
				p1.RefreshLevel = (z0ZzZzwmj)2;
				p1.Result = true;
			}
		}
	}

	[z0ZzZzimj("CopyWithClearFieldValue", ReturnValueType = typeof(bool), FunctionID = 51)]
	private void z0wrk(object p0, z0ZzZzomj p1)
	{
		if (p1.Mode == (z0ZzZzmmj)2)
		{
			p1.Enabled = p1.DocumentControler != null && p1.DocumentControler.z0rn();
		}
		else if (p1.Mode == (z0ZzZzmmj)5)
		{
			p1.Result = p1.DocumentControler.z0nm();
			p1.RefreshLevel = (z0ZzZzwmj)2;
		}
	}

	[z0ZzZzimj("ClearBodyContent")]
	private void z0erk(object p0, z0ZzZzomj p1)
	{
		if (p1.Mode == (z0ZzZzmmj)2)
		{
			p1.Enabled = p1.EditorControl != null && !p1.EditorControl.z0ork();
		}
		else if (p1.Mode == (z0ZzZzmmj)5)
		{
			p1.Result = false;
			if (p1.EditorControl != null && !p1.EditorControl.z0ork())
			{
				p1.Document.Comments.Clear();
				p1.Document.z0imk().Clear();
				p1.Document.z0xyk().z0be().Clear();
				p1.EditorControl.z0iyk();
				p1.Document.Modified = true;
				p1.Document.OnDocumentContentChanged();
				p1.Document.OnSelectionChanged();
				p1.RefreshLevel = (z0ZzZzwmj)2;
				p1.Result = true;
			}
		}
	}
}
