using System;
using DCSoft.Writer;
using DCSoft.Writer.Dom;

namespace zzz;

internal sealed class z0ZzZzckh : z0ZzZzcmj
{
	[z0ZzZzimj("InsertObject", DefaultResultValue = false)]
	public void z0eek_jiejie20260327142557(object p0, z0ZzZzomj p1)
	{
		if (p1.Mode == (z0ZzZzmmj)2)
		{
			p1.Enabled = false;
			if (p1.EditorControl != null && p1.Parameter != null)
			{
				z0ZzZzkeh z0ZzZzkeh2 = p1.Parameter as z0ZzZzkeh;
				if (z0ZzZzkeh2 == null)
				{
					z0ZzZzkeh2 = new z0ZzZzcwh();
					z0ZzZzkeh2.z0hj(p1.Parameter);
				}
				CanInsertObjectEventArgs e = new CanInsertObjectEventArgs(p1.Document);
				e.DataObject = z0ZzZzkeh2;
				p1.EditorControl.z0eek(e);
				p1.Enabled = e.Result;
			}
		}
		else
		{
			if (p1.Mode != (z0ZzZzmmj)5)
			{
				return;
			}
			p1.Result = false;
			if (p1.EditorControl != null && p1.Parameter != null)
			{
				z0ZzZzkeh z0ZzZzkeh3 = p1.Parameter as z0ZzZzkeh;
				if (z0ZzZzkeh3 == null)
				{
					z0ZzZzkeh3 = new z0ZzZzcwh();
					z0ZzZzkeh3.z0hj(p1.Parameter);
				}
				InsertObjectEventArgs e2 = new InsertObjectEventArgs(p1.Document);
				if (p1.EditorControl != null)
				{
					e2.AllowDataFormats = p1.EditorControl.AcceptDataFormats;
				}
				e2.DataObject = z0ZzZzkeh3;
				e2.ShowUI = p1.ShowUI;
				p1.EditorControl.z0eek(e2);
				p1.Result = e2.Result;
			}
		}
	}

	[z0ZzZzimj("InsertDateTimeString")]
	public void z0rek(object p0, z0ZzZzomj p1)
	{
		if (p1.Mode == (z0ZzZzmmj)2)
		{
			p1.Enabled = p1.z0tek() != null && p1.z0tek().IsCommandEnabled("InsertString");
		}
		else if (p1.Mode == (z0ZzZzmmj)5)
		{
			string text = p1.Document.z0jpk().ToString();
			if (!string.IsNullOrEmpty(text))
			{
				p1.EditorControl.z0eek("InsertString", p1: false, text);
			}
		}
	}

	[z0ZzZzimj("InsertListField")]
	private void z0tek(object p0, z0ZzZzomj p1)
	{
		if (p1.Mode == (z0ZzZzmmj)2)
		{
			p1.Enabled = p1.z0tek() != null && p1.z0tek().IsCommandEnabled("InsertInputField");
		}
		else if (p1.Mode == (z0ZzZzmmj)5)
		{
			XTextInputFieldElement xTextInputFieldElement = null;
			if (p1.Parameter is XTextInputFieldElement)
			{
				xTextInputFieldElement = p1.Parameter as XTextInputFieldElement;
			}
			else
			{
				xTextInputFieldElement = new XTextInputFieldElement();
				InputFieldSettings inputFieldSettings = new InputFieldSettings();
				inputFieldSettings.z0eek(InputFieldEditStyle.DropdownList);
				xTextInputFieldElement.FieldSettings = inputFieldSettings;
			}
			p1.Document.z0bek("lst", xTextInputFieldElement);
			if (xTextInputFieldElement != null)
			{
				p1.EditorControl.z0eek("InsertInputField", p1: false, xTextInputFieldElement);
			}
		}
	}

	[z0ZzZzimj("SetDefaultEventExpression", ReturnValueType = typeof(bool), DefaultResultValue = false)]
	public void z0yek(object p0, z0ZzZzomj p1)
	{
		if (p1.Mode == (z0ZzZzmmj)2)
		{
			p1.Enabled = false;
			if (p1.EditorControl != null)
			{
				XTextInputFieldElement xTextInputFieldElement = (XTextInputFieldElement)p1.EditorControl.z0rek(typeof(XTextInputFieldElement));
				if (xTextInputFieldElement != null && p1.DocumentControler.z0pm(xTextInputFieldElement, (z0ZzZzbcj)253))
				{
					p1.Enabled = true;
				}
			}
		}
		else
		{
			if (p1.Mode != (z0ZzZzmmj)5)
			{
				return;
			}
			p1.Result = false;
			XTextInputFieldElement xTextInputFieldElement2 = (XTextInputFieldElement)p1.EditorControl.z0rek(typeof(XTextInputFieldElement));
			if (xTextInputFieldElement2 == null || !p1.DocumentControler.z0pm(xTextInputFieldElement2, (z0ZzZzbcj)253))
			{
				return;
			}
			string text = null;
			if (p1.Parameter != null)
			{
				text = Convert.ToString(p1.Parameter);
			}
			if (string.IsNullOrEmpty(text))
			{
				text = xTextInputFieldElement2.DefaultEventExpression;
			}
			if (text != xTextInputFieldElement2.DefaultEventExpression)
			{
				if (p1.Document.z0ytk())
				{
					p1.Document.z0imk().z0eek("DefaultEventExpression", xTextInputFieldElement2.DefaultEventExpression, text, xTextInputFieldElement2);
					p1.Document.z0nuk();
				}
				xTextInputFieldElement2.DefaultEventExpression = text;
				p1.Result = true;
				p1.RefreshLevel = (z0ZzZzwmj)0;
				((XTextInputFieldElementBase)xTextInputFieldElement2).z0eek(p0: false);
				p1.Document.Modified = true;
				p1.Document.OnSelectionChanged();
				p1.Document.OnDocumentContentChanged();
			}
		}
	}

	[z0ZzZzimj("InsertDateTimeField")]
	private void z0uek_jiejie20260327142557(object p0, z0ZzZzomj p1)
	{
		if (p1.Mode == (z0ZzZzmmj)2)
		{
			p1.Enabled = p1.z0tek() != null && p1.z0tek().IsCommandEnabled("InsertInputField");
		}
		else if (p1.Mode == (z0ZzZzmmj)5)
		{
			XTextInputFieldElement xTextInputFieldElement = null;
			if (p1.Parameter is XTextInputFieldElement)
			{
				xTextInputFieldElement = p1.Parameter as XTextInputFieldElement;
			}
			else
			{
				xTextInputFieldElement = new XTextInputFieldElement();
				InputFieldSettings inputFieldSettings = new InputFieldSettings();
				inputFieldSettings.z0eek(InputFieldEditStyle.DateTime);
				xTextInputFieldElement.FieldSettings = inputFieldSettings;
			}
			p1.Document.z0bek("datetime", xTextInputFieldElement);
			if (xTextInputFieldElement != null)
			{
				p1.EditorControl.z0eek("InsertInputField", p1: false, xTextInputFieldElement);
			}
		}
	}

	[z0ZzZzimj("GetSurplusLinesOfSpeifyPage", ReturnValueType = typeof(int))]
	private void z0iek(object p0, z0ZzZzomj p1)
	{
		if (p1.Mode == (z0ZzZzmmj)2)
		{
			p1.Enabled = p1.EditorControl != null;
		}
		else if (p1.Mode == (z0ZzZzmmj)5)
		{
			p1.Result = 0;
			if (p1.EditorControl != null)
			{
				int p2 = z0ZzZzafh.z0yek(p1.Parameter, p1.Document.z0suk().Count);
				p1.Result = p1.EditorControl.z0eek(p2, 0f);
			}
		}
	}

	protected override z0ZzZzvmj z0qz()
	{
		z0ZzZzvmj obj = new z0ZzZzvmj();
		z0ZzZzcmj.z0rek(obj, "GetSurplusLinesOfSpeifyPage", z0iek);
		z0ZzZzcmj.z0rek(obj, "InsertDateTimeField", z0uek_jiejie20260327142557);
		z0ZzZzcmj.z0rek(obj, "InsertDateTimeString", z0rek);
		z0ZzZzcmj.z0rek(obj, "InsertListField", z0tek);
		z0ZzZzcmj.z0rek(obj, "InsertObject", z0eek_jiejie20260327142557);
		z0ZzZzcmj.z0rek(obj, "SetDefaultEventExpression", z0yek);
		return obj;
	}
}
