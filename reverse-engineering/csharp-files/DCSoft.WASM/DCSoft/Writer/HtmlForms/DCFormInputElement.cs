using System;
using System.Text.Json.Nodes;
using DCSoft.Common;
using DCSoft.Writer.Data;
using DCSoft.Writer.Dom;
using DCSystem_Drawing;
using zzz;

namespace DCSoft.Writer.HtmlForms;

public sealed class DCFormInputElement : DCFormElement
{
	private string z0drk;

	private bool z0srk;

	private z0ZzZzdvj z0ark;

	private new int z0qrk;

	private float z0wrk;

	private string z0erk;

	private ValueValidateStyle z0rrk;

	private string z0trk;

	private string z0yrk;

	private bool z0urk = true;

	private string z0irk;

	private string z0ork;

	private bool z0prk;

	private string z0mrk;

	private bool z0nrk;

	private StringAlignment z0brk;

	private string z0vrk;

	private bool z0crk;

	private string z0xrk_jiejie20260327142557;

	private DCFormElementList z0zrk;

	private InputFieldEditStyle z0ltk;

	private z0ZzZzsok z0ktk;

	public new string z0eek()
	{
		return z0yrk;
	}

	public void z0eek(float p0)
	{
		z0wrk = p0;
	}

	public override DCFormElementList z0xq()
	{
		return z0zrk;
	}

	public new string z0rek()
	{
		return z0trk;
	}

	public new string z0tek()
	{
		return z0xrk_jiejie20260327142557;
	}

	public new string z0yek()
	{
		return z0ork;
	}

	public new bool z0uek()
	{
		return z0prk;
	}

	public DCFormInputElement(XTextInputFieldElement field)
		: base(field)
	{
		if (field == null)
		{
			throw new ArgumentNullException("field");
		}
		base.z0uek(field.Name);
		z0ZzZzevj valueBinding = field.ValueBinding;
		if (valueBinding != null)
		{
			base.z0eek(valueBinding.DataSource);
			base.z0rek(valueBinding.BindingPath);
		}
		z0oek(field.BackgroundText);
		z0eek(field.z0jr().z0krk(((XTextInputFieldElementBase)field).z0tek()));
		if (field.FieldSettings != null)
		{
			z0eek(field.FieldSettings.z0nek());
			if (field.FieldSettings.z0zek() != null)
			{
				z0drk = field.FieldSettings.z0zek().SourceName;
				z0ark = field.FieldSettings.z0zek().Items;
			}
		}
		z0eek(field.DisplayFormat);
		z0eek(field.Alignment);
		z0trk = ((XTextInputFieldElementBase)field).z0srk();
		z0xrk_jiejie20260327142557 = ((XTextInputFieldElementBase)field).z0jrk();
		if (field.ValidateStyle != null && field.ValidateStyle.Required)
		{
			z0prk = true;
		}
		z0nrk = field.z0sek();
		z0qrk = field.MaxInputLength;
		z0vrk = field.InnerValue;
		z0erk = field.Text;
		z0yrk = field.VisibleExpression;
		z0ork = field.ValueExpression;
		z0crk = field.FieldSettings != null && field.FieldSettings.z0yek();
		z0urk = field.UserEditable;
		z0rrk = field.ValidateStyle;
		z0mrk = field.DefaultEventExpression;
	}

	public new string z0iek()
	{
		return z0mrk;
	}

	public new void z0eek(string p0)
	{
		z0xrk_jiejie20260327142557 = p0;
	}

	public new bool z0oek()
	{
		return z0srk;
	}

	public void z0eek(z0ZzZzdvj p0)
	{
		z0ark = p0;
	}

	public new void z0eek(int p0)
	{
		z0qrk = p0;
	}

	public new string z0pek()
	{
		return z0irk;
	}

	public override string z0mq()
	{
		return z0vrk;
	}

	public new StringAlignment z0mek()
	{
		return z0brk;
	}

	public new int z0nek()
	{
		return z0qrk;
	}

	public new bool z0bek()
	{
		return z0nrk;
	}

	public new void z0eek(bool p0)
	{
		z0nrk = p0;
	}

	public new z0ZzZzsok z0vek()
	{
		return z0ktk;
	}

	public new string z0cek()
	{
		return z0drk;
	}

	public new float z0xek()
	{
		return z0wrk;
	}

	public new ValueValidateStyle z0zek()
	{
		return z0rrk;
	}

	public override void z0cq(DCFormElementList p0)
	{
		z0zrk = p0;
	}

	public new void z0rek(bool p0)
	{
		z0urk = p0;
	}

	public void z0eek(ValueValidateStyle p0)
	{
		z0rrk = p0;
	}

	public void z0eek(z0ZzZzsok p0)
	{
		z0ktk = p0;
	}

	public new void z0rek(string p0)
	{
		z0vrk = p0;
	}

	public new string z0lrk()
	{
		return z0erk;
	}

	public new void z0tek(string p0)
	{
		z0drk = p0;
	}

	public void z0tek(bool p0)
	{
		z0srk = p0;
	}

	public override int z0oq(string p0, XTextDocument p1)
	{
		XTextInputFieldElement xTextInputFieldElement = base.z0qrk as XTextInputFieldElement;
		if (xTextInputFieldElement == null && p1 != null)
		{
			xTextInputFieldElement = p1.z0ki(base.z0vek()) as XTextInputFieldElement;
		}
		if (xTextInputFieldElement != null && xTextInputFieldElement.z0cek(p0, (z0ZzZzbcj)255, p2: true, p3: false))
		{
			return 1;
		}
		return 0;
	}

	public bool z0krk()
	{
		return z0urk;
	}

	public bool z0jrk()
	{
		return z0crk;
	}

	public override void z0pq(JsonObject p0, bool p1 = false)
	{
		base.z0pq(p0, p1);
		p0.Add("Alignment", z0mek().ToString());
		p0.Add("BackgroundText", z0pek());
		if (z0vek() != null && !z0vek().IsEmpty)
		{
			p0.Add("DisplayFormatStyle", z0vek().Style.ToString());
			p0.Add("DisplayFormatString", z0vek().Format);
		}
		p0.Add("EditType", z0frk_jiejie20260327142557().ToString());
		p0.Add("LabelText", z0rek());
		p0.Add("UnitText", z0tek());
		p0.Add("Value", z0grk());
		z0ZzZzdxj z0ZzZzdxj = new z0ZzZzdxj();
		z0ZzZzdxj.z0tek(p0: false);
		z0ZzZzdxj.z0eek(p0: false);
		z0ZzZzdxj.z0yek(p0: false);
		z0ZzZzdxj.z0rek(p0: false);
		z0ZzZzdxj.z0uek(p0: false);
		string text = base.z0qrk.z0yek(z0ZzZzdxj);
		p0.Add("Text", text);
		p0.Add("IsMultiSelect", z0jrk());
		p0.Add("ValueExpression", z0yek());
		p0.Add("VisibleExpression", z0eek());
		p0.Add("DefaultEventExpression", z0iek());
		p0.Add("UserEditable", z0krk());
		if (base.z0qrk is XTextInputFieldElement { ValueBinding: not null } xTextInputFieldElement)
		{
			JsonObject jsonObject = new JsonObject();
			jsonObject.Add("DataSource", xTextInputFieldElement.ValueBinding.DataSource);
			jsonObject.Add("BindingPath", xTextInputFieldElement.ValueBinding.BindingPath);
			jsonObject.Add("BindingPathForText", xTextInputFieldElement.ValueBinding.BindingPathForText);
			jsonObject.Add("ProcessState", xTextInputFieldElement.ValueBinding.ProcessState.ToString());
			jsonObject.Add("Enabled", xTextInputFieldElement.ValueBinding.z0eek());
			jsonObject.Add("AutoUpdate", xTextInputFieldElement.ValueBinding.z0yek());
			p0.Add("ValueBinding", jsonObject);
		}
		p0.Add("ListSourceName", z0cek());
		p0.Add("Required", z0uek());
		p0.Add("MaxLength", z0nek().ToString());
		p0.Add("SpecifyPixelWidth", z0xek().ToString());
		if (z0ark != null && z0ark.Count > 0)
		{
			JsonArray jsonArray = new JsonArray();
			using (zzz.z0ZzZzkuk<ListItem>.z0bpk z0bpk = z0ark.z0ltk())
			{
				while (z0bpk.MoveNext())
				{
					ListItem current = z0bpk.Current;
					JsonObject jsonObject2 = new JsonObject();
					jsonObject2.Add("Text", current.Text);
					jsonObject2.Add("Value", current.Value);
					jsonObject2.Add("TextInList", current.TextInList);
					jsonArray.Add(jsonObject2);
				}
			}
			p0.Add("ListItems", jsonArray);
		}
		if (z0xq() != null && z0xq().Count > 0)
		{
			JsonArray jsonArray2 = new JsonArray();
			foreach (DCFormElement item in z0xq())
			{
				JsonObject jsonObject3 = new JsonObject();
				item.z0pq(jsonObject3, p1);
				jsonArray2.Add(jsonObject3);
			}
			p0.Add("ChildNodes", jsonArray2);
		}
		if (z0rrk == null)
		{
			p0.Add("ValidateStyle", null);
		}
		else
		{
			JsonObject jsonObject4 = new JsonObject();
			jsonObject4.Add("BinaryLength", z0rrk.BinaryLength);
			jsonObject4.Add("CheckDecimalDigits", z0rrk.CheckDecimalDigits);
			jsonObject4.Add("CheckMaxValue", z0rrk.CheckMaxValue);
			jsonObject4.Add("CheckMinValue", z0rrk.CheckMinValue);
			jsonObject4.Add("CustomMessage", z0rrk.CustomMessage);
			jsonObject4.Add("DateTimeMaxValue", z0rrk.DateTimeMaxValue.ToString("yyyy-MM-dd HH:mm:ss"));
			jsonObject4.Add("DateTimeMinValue", z0rrk.DateTimeMinValue.ToString("yyyy-MM-dd HH:mm:ss"));
			jsonObject4.Add("ExcludeKeywords", z0rrk.ExcludeKeywords);
			jsonObject4.Add("IncludeKeywords", z0rrk.IncludeKeywords);
			jsonObject4.Add("Level", z0rrk.Level.ToString());
			jsonObject4.Add("MaxDecimalDigits", z0rrk.MaxDecimalDigits);
			jsonObject4.Add("MaxLength", z0rrk.MaxLength);
			if (!double.IsNaN(z0rrk.MaxValue))
			{
				jsonObject4.Add("MaxValue", z0rrk.MaxValue);
			}
			else
			{
				jsonObject4.Add("MaxValue", null);
			}
			jsonObject4.Add("Message", z0rrk.Message);
			jsonObject4.Add("MinLength", z0rrk.MinLength);
			if (!double.IsNaN(z0rrk.MinValue))
			{
				jsonObject4.Add("MinValue", z0rrk.MinValue);
			}
			else
			{
				jsonObject4.Add("MinValue", null);
			}
			jsonObject4.Add("Range", z0rrk.Range);
			jsonObject4.Add("RegExpression", z0rrk.RegExpression);
			jsonObject4.Add("Required", z0rrk.Required);
			jsonObject4.Add("RequiredInvalidateFlag", z0rrk.RequiredInvalidateFlag);
			jsonObject4.Add("ValueName", z0rrk.ValueName);
			jsonObject4.Add("ValueType", z0rrk.ValueType.ToString());
			p0.Add("ValidateStyle", jsonObject4);
		}
		p0.Add("RuntimeContentReadonly", z0bek());
	}

	public new void z0yek(string p0)
	{
		z0erk = p0;
	}

	public new void z0uek(string p0)
	{
		z0mrk = p0;
	}

	public new z0ZzZzdvj z0hrk()
	{
		return z0ark;
	}

	public void z0iek(string p0)
	{
		z0iek(p0);
	}

	public string z0grk()
	{
		return z0vrk;
	}

	public void z0oek(string p0)
	{
		z0irk = p0;
	}

	public InputFieldEditStyle z0frk_jiejie20260327142557()
	{
		return z0ltk;
	}

	public override void z0nq(string p0)
	{
		z0vrk = p0;
	}

	public void z0yek(bool p0)
	{
		z0prk = p0;
	}

	public DCFormInputElement()
	{
	}

	public void z0eek(InputFieldEditStyle p0)
	{
		z0ltk = p0;
	}

	public void z0pek(string p0)
	{
		z0yrk = p0;
	}

	public void z0mek(string p0)
	{
		z0ork = p0;
	}

	public void z0eek(StringAlignment p0)
	{
		z0brk = p0;
	}

	public void z0uek(bool p0)
	{
		z0crk = p0;
	}
}
