using DCSoft.Common;
using DCSoft.Writer;
using DCSoft.Writer.Dom;

namespace zzz;

internal class z0ZzZzanj : z0ZzZzsnj
{
	private string z0frk;

	private InputFieldSettings z0drk;

	private string z0srk;

	private string z0ark;

	private z0ZzZzevj z0qrk;

	private bool z0wrk;

	private string z0erk;

	private z0ZzZzukh z0rrk;

	private ContentReadonlyState z0trk = ContentReadonlyState.False;

	private string z0yrk;

	private XAttributeList z0urk;

	private string z0irk;

	private ElementType z0ork = ElementType.All;

	private bool z0prk = true;

	private string z0mrk;

	private EnableState z0nrk = EnableState.Enabled;

	private float z0brk;

	private ValueValidateStyle z0vrk;

	private string z0crk;

	internal bool z0xrk = true;

	private z0ZzZzsok z0zrk;

	public override bool z0az(XTextElement p0)
	{
		XTextInputFieldElement xTextInputFieldElement = (XTextInputFieldElement)p0;
		z0irk = xTextInputFieldElement.ID;
		z0crk = xTextInputFieldElement.Name;
		z0trk = xTextInputFieldElement.ContentReadonly;
		z0prk = xTextInputFieldElement.UserEditable;
		z0vrk = xTextInputFieldElement.ValidateStyle;
		z0qrk = xTextInputFieldElement.ValueBinding;
		z0drk = xTextInputFieldElement.FieldSettings;
		z0urk = xTextInputFieldElement.Attributes;
		z0zrk = xTextInputFieldElement.DisplayFormat;
		z0erk = xTextInputFieldElement.ToolTip;
		z0srk = xTextInputFieldElement.BackgroundText;
		z0brk = xTextInputFieldElement.SpecifyWidth;
		z0eek(xTextInputFieldElement.AcceptChildElementTypes2);
		z0eek(xTextInputFieldElement.EnableHighlight);
		if (xTextInputFieldElement.EventExpressions != null)
		{
			foreach (z0ZzZzykh eventExpression in xTextInputFieldElement.EventExpressions)
			{
				if (eventExpression.z0iek() == "ContentChanged" && eventExpression.z0rek() == (z0ZzZzikh)0)
				{
					z0rek(eventExpression.z0yek());
					break;
				}
			}
		}
		if (xTextInputFieldElement.EventExpressions != null)
		{
			z0eek(xTextInputFieldElement.EventExpressions.z0rek());
		}
		return true;
	}

	public new ValueValidateStyle z0eek()
	{
		return z0vrk;
	}

	public void z0eek(string p0)
	{
		z0ark = p0;
	}

	public ContentReadonlyState z0rek()
	{
		return z0trk;
	}

	public bool z0tek()
	{
		return z0prk;
	}

	public override XTextElement z0sz(XTextDocument p0)
	{
		XTextInputFieldElement xTextInputFieldElement = new XTextInputFieldElement();
		xTextInputFieldElement.z0te(new XTextElementList());
		xTextInputFieldElement.z0bt(p0);
		z0dz(p0, xTextInputFieldElement, p2: false);
		if (!string.IsNullOrEmpty(z0grk()))
		{
			xTextInputFieldElement.z0zek(z0grk());
		}
		if (!string.IsNullOrEmpty(z0lrk()))
		{
			xTextInputFieldElement.InnerValue = z0lrk();
		}
		return xTextInputFieldElement;
	}

	public void z0eek(z0ZzZzsok p0)
	{
		z0zrk = p0;
	}

	public void z0eek(bool p0)
	{
		z0wrk = p0;
	}

	public void z0rek(bool p0)
	{
		z0prk = p0;
	}

	public void z0eek(InputFieldSettings p0)
	{
		z0drk = p0;
	}

	public string z0yek()
	{
		return z0crk;
	}

	public void z0eek(XAttributeList p0)
	{
		z0urk = p0;
	}

	public InputFieldSettings z0uek()
	{
		return z0drk;
	}

	public void z0rek(string p0)
	{
		z0frk = p0;
	}

	public void z0eek(EnableState p0)
	{
		z0nrk = p0;
	}

	public void z0tek(string p0)
	{
		z0srk = p0;
	}

	public void z0eek(z0ZzZzukh p0)
	{
		z0rrk = p0;
	}

	public void z0eek(ValueValidateStyle p0)
	{
		z0vrk = p0;
	}

	public override bool z0dz(XTextDocument p0, XTextElement p1, bool p2)
	{
		XTextInputFieldElement xTextInputFieldElement = (XTextInputFieldElement)p1;
		if (z0crk != null)
		{
			z0crk = z0crk.Trim();
		}
		bool flag = false;
		if (xTextInputFieldElement.ID != z0oek())
		{
			if (p2 && p0.z0uik())
			{
				p0.z0imk().z0eek("ID", xTextInputFieldElement.ID, z0oek(), xTextInputFieldElement);
			}
			xTextInputFieldElement.ID = z0oek();
			flag = true;
		}
		if (xTextInputFieldElement.EnableHighlight != z0mek())
		{
			if (p2 && p0.z0uik())
			{
				p0.z0imk().z0eek("EnableHighlight", xTextInputFieldElement.EnableHighlight, z0mek(), xTextInputFieldElement);
			}
			xTextInputFieldElement.EnableHighlight = z0mek();
			flag = true;
		}
		z0ZzZzukh z0ZzZzukh2 = z0iek();
		if (!string.IsNullOrEmpty(z0zek()))
		{
			if (z0ZzZzukh2 == null)
			{
				z0ZzZzukh2 = new z0ZzZzukh();
			}
			z0ZzZzykh z0ZzZzykh2 = null;
			foreach (z0ZzZzykh item in z0ZzZzukh2)
			{
				if (item.z0iek() == "ContentChanged" && item.z0rek() == (z0ZzZzikh)0)
				{
					z0ZzZzykh2 = item;
					break;
				}
			}
			if (z0ZzZzykh2 == null)
			{
				z0ZzZzykh2 = new z0ZzZzykh();
				z0ZzZzykh2.z0yek("ContentChanged");
				z0ZzZzykh2.z0eek((z0ZzZzikh)0);
				z0ZzZzukh2.Add(z0ZzZzykh2);
			}
			z0ZzZzykh2.z0eek(z0zek());
		}
		if (z0ZzZzukh2 != xTextInputFieldElement.EventExpressions)
		{
			if (p2 && p0.z0uik())
			{
				p0.z0imk().z0eek("EventExpressions", xTextInputFieldElement.EventExpressions, z0ZzZzukh2, xTextInputFieldElement);
			}
			xTextInputFieldElement.EventExpressions = z0ZzZzukh2;
			flag = true;
		}
		if (xTextInputFieldElement.AcceptChildElementTypes2 != z0hrk())
		{
			if (p2 && p0.z0uik())
			{
				p0.z0imk().z0eek("AcceptChildElementTypes2", xTextInputFieldElement.AcceptChildElementTypes2, z0hrk(), xTextInputFieldElement);
			}
			xTextInputFieldElement.AcceptChildElementTypes2 = z0hrk();
			flag = true;
		}
		if (xTextInputFieldElement.Name != z0yek())
		{
			if (p2 && p0.z0uik())
			{
				p0.z0imk().z0eek("Name", xTextInputFieldElement.Name, z0yek(), xTextInputFieldElement);
			}
			xTextInputFieldElement.Name = z0yek();
			flag = true;
		}
		if (xTextInputFieldElement.SpecifyWidth != z0xek())
		{
			if (p2 && p0.z0uik())
			{
				p0.z0imk().z0eek("SpecifyWidth", xTextInputFieldElement.SpecifyWidth, z0xek(), xTextInputFieldElement);
			}
			xTextInputFieldElement.SpecifyWidth = z0xek();
			flag = true;
		}
		if (xTextInputFieldElement.ToolTip != z0jrk())
		{
			if (p2 && p0.z0uik())
			{
				p0.z0imk().z0eek("ToolTip", xTextInputFieldElement.ToolTip, z0jrk(), xTextInputFieldElement);
			}
			xTextInputFieldElement.ToolTip = z0jrk();
			flag = true;
		}
		if (xTextInputFieldElement.BackgroundText != z0bek())
		{
			if (p2 && p0.z0uik())
			{
				p0.z0imk().z0eek("BackgroundText", xTextInputFieldElement.BackgroundText, z0bek(), xTextInputFieldElement);
			}
			xTextInputFieldElement.BackgroundText = z0bek();
			flag = true;
		}
		if (xTextInputFieldElement.ContentReadonly != z0rek())
		{
			if (p2 && p0.z0uik())
			{
				p0.z0imk().z0eek("ContentReadonly", xTextInputFieldElement.ContentReadonly, z0rek(), xTextInputFieldElement);
			}
			xTextInputFieldElement.ContentReadonly = z0rek();
			flag = true;
		}
		if (xTextInputFieldElement.UserEditable != z0tek())
		{
			if (p2 && p0.z0uik())
			{
				p0.z0imk().z0eek("UserEditable", xTextInputFieldElement.UserEditable, z0tek(), xTextInputFieldElement);
			}
			xTextInputFieldElement.UserEditable = z0tek();
			flag = true;
		}
		if (xTextInputFieldElement.ValidateStyle != z0eek())
		{
			if (p2 && p0.z0uik())
			{
				p0.z0imk().z0eek("ValidateStyle", xTextInputFieldElement.ValidateStyle, z0eek(), xTextInputFieldElement);
			}
			xTextInputFieldElement.ValidateStyle = z0eek();
			flag = true;
		}
		bool flag2 = false;
		if (xTextInputFieldElement.ValueBinding != z0pek())
		{
			if (p2 && p0.z0uik())
			{
				p0.z0imk().z0eek("ValueBinding", xTextInputFieldElement.ValueBinding, z0pek(), xTextInputFieldElement);
			}
			xTextInputFieldElement.ValueBinding = z0pek();
			flag2 = true;
			flag = true;
		}
		if (xTextInputFieldElement.FieldSettings != z0uek())
		{
			if (p2 && p0.z0uik())
			{
				p0.z0imk().z0eek("FieldSettings", xTextInputFieldElement.FieldSettings, z0uek(), xTextInputFieldElement);
			}
			xTextInputFieldElement.FieldSettings = z0uek();
			flag = true;
		}
		if (xTextInputFieldElement.Attributes != z0krk())
		{
			if (p2 && p0.z0uik())
			{
				p0.z0imk().z0eek("Attributes", xTextInputFieldElement.Attributes, z0krk(), xTextInputFieldElement);
			}
			xTextInputFieldElement.Attributes = z0krk();
			flag = true;
		}
		if (xTextInputFieldElement.DisplayFormat != z0nek())
		{
			if (p2 && p0.z0uik())
			{
				p0.z0imk().z0eek("DisplayFormat", xTextInputFieldElement.DisplayFormat, z0nek(), xTextInputFieldElement);
			}
			xTextInputFieldElement.DisplayFormat = z0nek();
			flag = true;
		}
		if (flag2 && xTextInputFieldElement.ValueBinding != null)
		{
			xTextInputFieldElement.z0cek(new z0ZzZzrlh(null, p1: false));
		}
		if (flag)
		{
			ContentChangedEventArgs e = new ContentChangedEventArgs();
			e.Document = xTextInputFieldElement.z0jr();
			e.Element = xTextInputFieldElement;
			e.LoadingDocument = false;
			xTextInputFieldElement.z0zi(e);
		}
		return flag;
	}

	public void z0yek(string p0)
	{
		z0irk = p0;
	}

	public z0ZzZzukh z0iek()
	{
		return z0rrk;
	}

	public string z0oek()
	{
		return z0irk;
	}

	public z0ZzZzevj z0pek()
	{
		return z0qrk;
	}

	public EnableState z0mek()
	{
		return z0nrk;
	}

	public void z0eek(z0ZzZzevj p0)
	{
		z0qrk = p0;
	}

	public void z0eek(ElementType p0)
	{
		z0ork = p0;
	}

	public void z0uek(string p0)
	{
		z0erk = p0;
	}

	public z0ZzZzsok z0nek()
	{
		return z0zrk;
	}

	public void z0iek(string p0)
	{
		z0yrk = p0;
	}

	public string z0bek()
	{
		return z0srk;
	}

	public bool z0vek()
	{
		return z0wrk;
	}

	public z0ZzZzanj()
	{
	}

	public string z0cek()
	{
		return z0yrk;
	}

	public float z0xek()
	{
		return z0brk;
	}

	public void z0oek(string p0)
	{
		z0mrk = p0;
	}

	public string z0zek()
	{
		return z0frk;
	}

	public void z0pek(string p0)
	{
		z0crk = p0;
	}

	public void z0eek(float p0)
	{
		z0brk = p0;
	}

	public void z0eek(ContentReadonlyState p0)
	{
		z0trk = p0;
	}

	public string z0lrk()
	{
		return z0mrk;
	}

	public XAttributeList z0krk()
	{
		return z0urk;
	}

	public string z0jrk()
	{
		return z0erk;
	}

	public ElementType z0hrk()
	{
		return z0ork;
	}

	public z0ZzZzanj(XTextInputFieldElement p0)
	{
		if (p0 != null)
		{
			z0az(p0);
		}
	}

	public string z0grk()
	{
		return z0ark;
	}
}
