using System;
using System.Text;
using DCSoft.Common;
using DCSoft.Writer;
using DCSoft.Writer.Dom;
using DCSoft.Writer.Security;

namespace zzz;

internal sealed class z0ZzZzffh : z0ZzZzdfh
{
	public override z0ZzZznnj z0nd(XTextElement p0)
	{
		if (p0 is XTextInputFieldElement xTextInputFieldElement)
		{
			if (!xTextInputFieldElement.z0yek())
			{
				return null;
			}
			z0ZzZznnj z0ZzZznnj2 = ((XTextElement)xTextInputFieldElement).z0irk();
			if (z0ZzZznnj2 != null)
			{
				return z0ZzZznnj2;
			}
			if (!string.IsNullOrEmpty(xTextInputFieldElement.z0drk()))
			{
				Type controlType = z0ZzZzwnj.GetControlType(xTextInputFieldElement.z0drk(), typeof(z0ZzZznnj));
				if (controlType != null)
				{
					return (z0ZzZznnj)Activator.CreateInstance(controlType);
				}
			}
			if (xTextInputFieldElement.FieldSettings != null)
			{
				if (xTextInputFieldElement.FieldSettings.z0nek() == InputFieldEditStyle.Date)
				{
					return new z0ZzZzrbj();
				}
				if (xTextInputFieldElement.FieldSettings.z0nek() == InputFieldEditStyle.DateTime)
				{
					return new z0ZzZzwbj();
				}
				if (xTextInputFieldElement.FieldSettings.z0nek() == InputFieldEditStyle.DateTimeWithoutSecond)
				{
					return new z0ZzZzebj();
				}
				if (xTextInputFieldElement.FieldSettings.z0nek() == InputFieldEditStyle.Time)
				{
					return new z0ZzZzubj();
				}
				if (xTextInputFieldElement.FieldSettings.z0nek() == InputFieldEditStyle.DropdownList)
				{
					return new z0ZzZztbj();
				}
				if (xTextInputFieldElement.FieldSettings.z0nek() == InputFieldEditStyle.Numeric)
				{
					return new z0ZzZzybj();
				}
			}
		}
		return null;
	}

	static z0ZzZzffh()
	{
		z0ZzZzqck.z0eek();
		z0ZzZzafh.z0drk = typeof(z0ZzZzffh).Assembly.GetName().Version.ToString();
	}

	public override bool z0md_jiejie20260327142557(z0ZzZzdbj p0)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("ctl");
		}
		for (XTextElement xTextElement = p0.z0ipk(); xTextElement != null; xTextElement = xTextElement.z0ji())
		{
			if (xTextElement is XTextContainerElement && ((XTextContainerElement)xTextElement).z0gtk())
			{
				return true;
			}
		}
		return false;
	}

	public override bool z0pd(string p0)
	{
		return z0ZzZzftk.z0eek(p0);
	}

	public override bool z0od(XTextElement p0, DCCASignMode p1)
	{
		return z0ZzZzftk.z0eek(p0, p1);
	}

	public override bool z0id(z0ZzZzqbj p0, UserLoginInfo p1, bool p2)
	{
		if (p1 == null)
		{
			throw new ArgumentNullException("loginInfo");
		}
		if (p0 == null)
		{
			throw new ArgumentNullException("ctl");
		}
		XTextDocument xTextDocument = p0.z0qtk();
		if (xTextDocument == null)
		{
			throw new ArgumentNullException("ctl.Document");
		}
		if (xTextDocument.z0syk().z0eek() != null && xTextDocument.z0syk().z0eek().z0eek())
		{
			xTextDocument.z0syk().z0eek().z0tek(xTextDocument.z0jpk());
		}
		DocumentSecurityOptions securityOptions = p0.z0crk().SecurityOptions;
		if (securityOptions != null && securityOptions.AutoEnablePermissionWhenUserLogin)
		{
			securityOptions.EnablePermission = true;
			securityOptions.EnableLogicDelete = true;
			securityOptions.ShowLogicDeletedContent = true;
			securityOptions.ShowPermissionMark = true;
			securityOptions.ShowPermissionTip = true;
		}
		z0ZzZzyhh z0ZzZzyhh2 = new z0ZzZzyhh();
		z0ZzZzyhh2.z0tek(p1.ID);
		z0ZzZzyhh2.z0uek(p1.Name);
		z0ZzZzyhh2.z0rek(p1.Name2);
		z0ZzZzyhh2.z0eek(p1.PermissionLevel);
		z0ZzZzyhh2.z0tek(z0ZzZzkfh.z0wrk);
		z0ZzZzyhh2.z0iek(p1.Description);
		z0ZzZzyhh2.z0yek(p1.Tag);
		z0ZzZzyhh2.z0eek(p1.ClientName);
		z0ZzZzyhh2.z0jrk = xTextDocument.z0jpk();
		xTextDocument.z0syk().Add(z0ZzZzyhh2);
		xTextDocument.z0syk().z0mek = false;
		if (xTextDocument.z0imk() != null)
		{
			xTextDocument.z0imk().z0po();
			xTextDocument.z0imk().Clear();
		}
		if (p2)
		{
			p0.z0xyk();
		}
		else
		{
			xTextDocument.OnSelectionChanged();
		}
		return true;
	}

	public override bool z0ud(z0ZzZzdbj p0, DCSignInputInfo p1)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("ctl");
		}
		if (!(p0.z0ruk().z0wyk() is XTextSignImageElement xTextSignImageElement))
		{
			return false;
		}
		XTextContainerElement xTextContainerElement = xTextSignImageElement.z0yek();
		if (xTextContainerElement == null)
		{
			xTextContainerElement = xTextSignImageElement.z0yek();
		}
		if (xTextContainerElement != null && p0.z0erk().z0np(xTextContainerElement))
		{
			return xTextContainerElement.z0cek(p1);
		}
		return false;
	}

	public override bool z0yd(XTextElement p0, DCCASignMode p1)
	{
		return z0ZzZzftk.z0eek(p0, p1);
	}

	public override bool z0td(XTextElement p0, DCSignInputInfo p1)
	{
		return z0ZzZzftk.z0eek(p0, p1);
	}

	public override string z0rd(z0ZzZzdbj p0, XTextInputFieldElement p1, int[] p2, bool p3)
	{
		return z0ZzZztbj.z0eek(p0, p1, p2, p3);
	}

	public override void z0ed(XTextElement p0, DocumentEventArgs p1)
	{
		z0ZzZzsxj.z0rek(p0, p1);
	}

	public override void z0wd(XTextElement p0)
	{
		z0ZzZzftk.z0eek(p0);
	}

	public override void z0qd()
	{
	}

	public override void z0ad(XTextElement p0)
	{
		z0ZzZzftk.z0eek(p0);
	}

	public override z0ZzZzphh z0sd()
	{
		return new z0ZzZzgjh();
	}

	public override string z0dd(z0ZzZzdbj p0, string p1)
	{
		if (string.IsNullOrEmpty(p1))
		{
			return p1;
		}
		string text = p1;
		string autoTranslateSourceString = p0.z0cuk().BehaviorOptions.AutoTranslateSourceString;
		string autoTranslateDescString = p0.z0cuk().BehaviorOptions.AutoTranslateDescString;
		if (!string.IsNullOrEmpty(autoTranslateSourceString) && !string.IsNullOrEmpty(autoTranslateDescString) && autoTranslateSourceString.Length == autoTranslateDescString.Length)
		{
			StringBuilder stringBuilder = new StringBuilder();
			foreach (char c in p1)
			{
				int num = autoTranslateSourceString.IndexOf(c);
				if (num >= 0)
				{
					stringBuilder.Append(autoTranslateDescString[num]);
				}
				else
				{
					stringBuilder.Append(c);
				}
			}
			text = stringBuilder.ToString();
		}
		if (p0 != null)
		{
			WriterBeforeUIKeyboardInputStringEventArgs e = new WriterBeforeUIKeyboardInputStringEventArgs(p0, p0.z0ruk(), null, p1, text);
			p0.z0eek(e);
			if (e.Cancel)
			{
				return null;
			}
			text = e.OutputString;
		}
		return text;
	}

	public override Type z0fd(string p0, Type p1)
	{
		return base.z0fd(p0, p1);
	}
}
