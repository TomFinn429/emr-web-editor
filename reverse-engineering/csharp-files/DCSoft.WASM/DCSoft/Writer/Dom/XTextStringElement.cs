using System;
using System.Text;
using DCSoft.Common;
using zzz;

namespace DCSoft.Writer.Dom;

public class XTextStringElement : XTextContainerElement
{
	public class z0qxk : z0ZzZzeqh
	{
		internal StringBuilder z0eek;

		internal XTextStringElement z0rek;

		public void z0ib(z0ZzZzhqh p0)
		{
			if (z0rek != null)
			{
				z0eek = z0rek.z0krk;
			}
			if (z0eek == null || z0eek.Length <= 0)
			{
				return;
			}
			int length = z0eek.Length;
			for (int i = 0; i < length; i++)
			{
				if (!XTextCharElement.z0tek(z0eek[i]))
				{
					continue;
				}
				StringBuilder stringBuilder = new StringBuilder();
				for (int j = 0; j < length; j++)
				{
					char c = z0eek[j];
					if (XTextCharElement.z0tek(c))
					{
						if (stringBuilder.Length > 0)
						{
							p0.z0yg(stringBuilder.ToString());
							stringBuilder = new StringBuilder();
						}
						p0.z0xg(c);
					}
					else
					{
						stringBuilder.Append(c);
					}
				}
				if (stringBuilder.Length > 0)
				{
					p0.z0yg(stringBuilder.ToString());
				}
				return;
			}
			p0.z0yg(z0eek.ToString());
		}

		public void z0ob(z0ZzZzcah p0)
		{
			z0eek = new StringBuilder(p0.z0ra());
			p0.z0ua();
		}
	}

	[NonSerialized]
	[z0ZzZzuqh]
	public new XTextParagraphFlagElement z0cek;

	[NonSerialized]
	private new XTextCharElement z0xek;

	private new z0qxk z0zek;

	private new StringBuilder z0krk = new StringBuilder();

	private new int z0jrk;

	[NonSerialized]
	private new bool z0hrk;

	private new bool z0grk;

	[NonSerialized]
	private new XTextCharElement z0frk;

	[z0ZzZzuqh]
	public override XAttributeList Attributes
	{
		get
		{
			return null;
		}
		set
		{
			base.Attributes = value;
		}
	}

	[z0ZzZzuqh]
	public override z0ZzZzevj ValueBinding
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	[z0ZzZzuqh]
	public override string ToolTip
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	[z0ZzZzuqh]
	public override string ContentReadonlyExpression
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	[z0ZzZzuqh]
	public override PropertyExpressionInfoList PropertyExpressions
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	[z0ZzZzuqh]
	public override string Text
	{
		get
		{
			if (z0eek() > 0)
			{
				return z0ZzZzafh.z0uek(z0eek());
			}
			return z0krk.ToString();
		}
		set
		{
			string text = value;
			if (text != null && text.Length > 0 && text.StartsWith("{{DCSPACES}}", StringComparison.Ordinal))
			{
				text = text.Substring("{{DCSPACES}}".Length);
				int count = 0;
				text = ((!int.TryParse(text, out count)) ? string.Empty : new string(' ', count));
			}
			z0krk = new StringBuilder(text);
			if (!XTextElementList.z0jrk())
			{
				z0ntk?.z0vrk();
			}
		}
	}

	[z0ZzZzuqh]
	public override bool Deleteable
	{
		get
		{
			return true;
		}
		set
		{
		}
	}

	[z0ZzZzuqh]
	public override CopySourceInfo CopySource
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	[z0ZzZzuqh]
	public override bool AcceptTab
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	[z0ZzZzuqh]
	public override string ValueExpression
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	[z0ZzZzuqh]
	public override ValueValidateStyle ValidateStyle
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	[z0ZzZzuqh]
	public override bool Visible
	{
		get
		{
			return true;
		}
		set
		{
		}
	}

	[z0ZzZzuqh]
	public override string VisibleExpression
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	[z0ZzZzuqh]
	public override ElementVisibility PrintVisibility
	{
		get
		{
			return ElementVisibility.Visible;
		}
		set
		{
		}
	}

	[z0ZzZzuqh]
	public override bool HiddenPrintWhenEmpty
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public int z0eek()
	{
		return z0jrk;
	}

	internal char z0rek()
	{
		if (z0xek != null)
		{
			return z0xek.z0bek;
		}
		return '\0';
	}

	public override ElementType z0at()
	{
		return ElementType.Text;
	}

	public bool z0eek(XTextCharElement p0)
	{
		if (p0 != null)
		{
			if (z0krk.Length == 0)
			{
				return true;
			}
			return z0buk == p0.z0buk;
		}
		return false;
	}

	public override void z0st(bool p0)
	{
	}

	public void z0eek(bool p0)
	{
		z0grk = p0;
	}

	public override bool z0dt()
	{
		return false;
	}

	public string z0rek(bool p0)
	{
		string empty = string.Empty;
		if (!p0 || z0be().Count == 0)
		{
			return Text;
		}
		StringBuilder stringBuilder = new StringBuilder();
		XTextDocumentContentElement xTextDocumentContentElement = z0be()[0].z0qek();
		using (zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = z0be().z0ltk())
		{
			while (z0bpk.MoveNext())
			{
				XTextCharElement xTextCharElement = (XTextCharElement)z0bpk.Current;
				if (xTextDocumentContentElement.z0rek(xTextCharElement))
				{
					xTextCharElement.z0rek(stringBuilder);
				}
			}
		}
		return stringBuilder.ToString();
	}

	public XTextCharElement z0tek()
	{
		return z0frk;
	}

	internal new bool z0yek()
	{
		if (z0eek() > 0)
		{
			return false;
		}
		return z0krk.Length == 0;
	}

	public new int z0uek()
	{
		if (z0jrk > 0)
		{
			return z0jrk;
		}
		return z0krk.Length;
	}

	public void z0rek(XTextCharElement p0)
	{
		z0xek = p0;
	}

	public void z0tek(XTextCharElement p0)
	{
		if (z0krk.Length == 0)
		{
			z0buk = p0.z0buk;
			z0yek(p0);
		}
		z0xek = p0;
		p0.z0rek(z0krk);
	}

	internal new char z0iek()
	{
		if (z0frk != null)
		{
			return z0frk.z0bek;
		}
		return '\0';
	}

	public new void z0oek()
	{
		bool flag = true;
		string text = Text;
		string text2 = text;
		for (int i = 0; i < text2.Length; i++)
		{
			if (text2[i] != ' ')
			{
				flag = false;
				break;
			}
		}
		if (flag)
		{
			z0jrk = text.Length;
		}
	}

	public new z0qxk z0pek()
	{
		if (z0zek == null)
		{
			z0zek = new z0qxk();
		}
		z0zek.z0rek = this;
		return z0zek;
	}

	public XTextStringElement()
		: base(0)
	{
	}

	public void z0tek(bool p0)
	{
		z0hrk = p0;
	}

	public void z0eek(XTextCharElement p0, string p1)
	{
		if (z0krk.Length == 0)
		{
			z0oek(((XTextElement)p0).z0pek());
			z0yek(p0);
		}
		z0xek = p0;
		if (p1 != null)
		{
			z0krk.Append(p1);
		}
	}

	public new bool z0mek()
	{
		return z0grk;
	}

	public override string ToString()
	{
		if (z0krk.Length > 20)
		{
			return z0krk.ToString(0, 20);
		}
		return z0krk.ToString();
	}

	public XTextStringElement(string txt)
	{
		Text = txt;
	}

	public override XTextElementList z0be()
	{
		return base.z0be();
	}

	public void z0eek(int p0)
	{
		z0jrk = p0;
	}

	public new bool z0nek()
	{
		if (z0krk.Length <= 0)
		{
			return z0be().Count > 0;
		}
		return true;
	}

	public override void z0ft(string p0)
	{
	}

	internal void z0yek(XTextCharElement p0)
	{
		z0frk = p0;
		z0rik = p0.z0jr();
		z0uik = p0.z0ji();
	}

	public new XTextCharElement z0bek()
	{
		return z0xek;
	}

	public override bool z0gt()
	{
		return false;
	}

	public override string z0ht()
	{
		return null;
	}

	public override XTextParagraphFlagElement z0dy()
	{
		return z0cek;
	}

	public void z0eek(z0qxk p0)
	{
		z0zek = p0;
		if (z0zek != null)
		{
			z0zek.z0rek = this;
			z0krk = z0zek.z0eek;
		}
	}

	public new bool z0vek()
	{
		return z0hrk;
	}

	public override void z0te(XTextElementList p0)
	{
		base.z0te(p0);
	}

	public override void z0jt(bool p0)
	{
	}
}
