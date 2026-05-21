using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using DCSoft.Writer.Data;
using DCSoft.Writer.Dom;
using zzz;

namespace DCSoft.Writer.HtmlForms;

public class DCFormHtmlWriter
{
	private int z0tek = 500;

	private Dictionary<string, string> z0yek;

	public static readonly string z0uek = "FormDocument_HiddenName";

	private void z0rek(z0ZzZzhqh p0, string p1, string p2)
	{
		if (p2 != null && p2.Length > 0)
		{
			p0.z0eek(p1, p2);
		}
	}

	private string z0rek(string p0)
	{
		if (p0 != null && p0.Length > 0)
		{
			int num = p0.IndexOf("?>", 0, Math.Min(100, p0.Length));
			num = ((num > 0) ? (num + 2) : 0);
			int num2 = p0.IndexOf('<', num, Math.Min(100, p0.Length - num));
			if (num2 > 0)
			{
				return p0.Substring(num2).Trim();
			}
		}
		return p0;
	}

	public string z0rek(XTextDocument p0)
	{
		StringWriter stringWriter = new StringWriter();
		z0ZzZzhqh z0ZzZzhqh = new z0ZzZzhqh(stringWriter);
		z0ZzZzhqh.z0eek((z0ZzZzesh)0);
		z0ZzZzhqh.z0ug();
		z0ZzZzhqh.z0eek("html");
		z0ZzZzhqh.z0eek("head");
		string text = z0rek(p0.z0tok(), p0.ID, p0.z0amk());
		if (text != null && text.Length > 0)
		{
			((z0ZzZzdqh)z0ZzZzhqh).z0rek("title", text);
		}
		z0ZzZzhqh.z0eek("meta");
		z0ZzZzhqh.z0eek("name", "viewport");
		z0ZzZzhqh.z0eek("charset", "utf-8");
		z0ZzZzhqh.z0eek("content", "width=device-width, user-scalable=yes, initial-scale=1.0, maximum-scale=5.0, minimum-scale=1.0");
		z0ZzZzhqh.z0bg();
		z0ZzZzhqh.z0eek("style");
		z0ZzZzhqh.z0yg("label{vertical-align:middle;}");
		z0ZzZzhqh.z0mg();
		z0ZzZzhqh.z0mg();
		z0ZzZzhqh.z0eek("body");
		z0ZzZzhqh.z0eek("form");
		z0ZzZzhqh.z0eek("method", "post");
		z0ZzZzhqh.z0eek("action", "");
		z0ZzZzhqh.z0eek("input");
		z0ZzZzhqh.z0eek("type", "submit");
		z0ZzZzhqh.z0eek("value", "提交");
		z0ZzZzhqh.z0bg();
		DCFormDocument dCFormDocument = new DCFormDocument();
		dCFormDocument.z0yek(p0);
		z0rek(dCFormDocument, z0ZzZzhqh);
		z0ZzZzhqh.z0mg();
		z0ZzZzhqh.z0mg();
		z0ZzZzhqh.z0mg();
		z0ZzZzhqh.z0vg();
		z0ZzZzhqh.z0kf();
		string p1 = stringWriter.ToString();
		return z0rek(p1);
	}

	private void z0rek(DCFormElementList p0, z0ZzZzhqh p1, string p2)
	{
		foreach (DCFormElement item in p0)
		{
			if (item is DCFormLabelElement)
			{
				z0rek(p1, (DCFormLabelElement)item, p2);
			}
			else if (item is DCFormInputElement)
			{
				z0rek(p1, (DCFormInputElement)item, p2);
			}
			else if (item is DCFormCheckBoxElementBase)
			{
				z0rek(p1, (DCFormCheckBoxElementBase)item, p2);
			}
			else if (item is DCFormButtonElement)
			{
				z0rek(p1, (DCFormButtonElement)item, p2);
			}
			else if (item is DCFormImageElement)
			{
				z0rek(p1, (DCFormImageElement)item, p2);
			}
			else if (item is DCFormGroupElement)
			{
				z0rek(p1, (DCFormGroupElement)item, p2);
			}
		}
	}

	public int z0rek()
	{
		return z0tek;
	}

	private string z0rek(string p0, char p1 = '_')
	{
		if (p0 == null || p0.Length == 0)
		{
			throw new ArgumentNullException("txt");
		}
		if (!z0rek(p1))
		{
			throw new ArgumentOutOfRangeException("replaceChar=" + p1);
		}
		int length = p0.Length;
		for (int i = 0; i < length; i++)
		{
			char p2 = p0[i];
			if (z0rek(p2))
			{
				continue;
			}
			StringBuilder stringBuilder = new StringBuilder();
			if (i > 0)
			{
				stringBuilder.Append(p0, 0, i);
			}
			stringBuilder.Append(p1);
			for (int j = i + 1; j < length; j++)
			{
				p2 = p0[j];
				if (z0rek(p2))
				{
					stringBuilder.Append(p2);
				}
				else
				{
					stringBuilder.Append(p1);
				}
			}
			return stringBuilder.ToString();
		}
		return p0;
	}

	public void z0rek(int p0)
	{
		z0tek = p0;
	}

	public int z0eek(Dictionary<string, string> p0, XTextDocument p1)
	{
		DCFormDocument dCFormDocument = new DCFormDocument();
		dCFormDocument.z0yek(p1);
		int result = dCFormDocument.z0eek(p0, p1);
		p1.z0vek(p0: false);
		p1.z0hyk();
		return result;
	}

	private void z0rek(z0ZzZzhqh p0, DCFormGroupElement p1, string p2)
	{
		p0.z0eek("div");
		p0.z0eek("type", p1.GetType().Name);
		p0.z0eek("id", "Element_" + p1.z0tek());
		if (p1.z0cek() != null && p1.z0cek().Length > 0)
		{
			((z0ZzZzdqh)p0).z0rek("span", p1.z0cek());
		}
		p0.z0eek("input");
		p0.z0eek("type", "button");
		p0.z0eek("style", "float:right");
		p0.z0eek("value", "添加");
		p0.z0bg();
		p0.z0eek("input");
		p0.z0eek("type", "button");
		p0.z0eek("style", "float:right");
		p0.z0eek("value", "删除");
		p0.z0bg();
		for (int i = 0; i < p1.z0rek().Count; i++)
		{
			z0ZzZzijh z0ZzZzijh = p1.z0rek()[i];
			p0.z0eek("div");
			p0.z0eek("hr");
			p0.z0bg();
			string text = p1.z0eek(i);
			p0.z0eek("group", text);
			z0rek(z0ZzZzijh.z0rek(), p0, text);
			p0.z0mg();
		}
		p0.z0mg();
	}

	private void z0rek(z0ZzZzhqh p0, DCFormInputElement p1, string p2)
	{
		string text = z0rek(p2, ((DCFormElement)p1).z0tek());
		string p3 = z0rek(p2, ((DCFormElement)p1).z0lrk());
		p0.z0eek("div");
		p0.z0eek("type", p1.GetType().Name);
		p0.z0eek("id", "Element_" + text);
		p0.z0eek("style", "border-top:1px solid gray");
		string text2 = z0rek(p1.z0rek(), p1.z0pek(), ((DCFormElement)p1).z0cek(), ((DCFormElement)p1).z0lrk());
		if (text2 != null && text2.Length > 0)
		{
			p0.z0eek("label");
			p0.z0eek("style", "width:100px;display:inline-block");
			z0rek(p0, "for", text);
			p0.z0yg(text2);
			p0.z0mg();
		}
		if (p1.z0frk_jiejie20260327142557() == InputFieldEditStyle.DropdownList)
		{
			p0.z0eek("select");
			p0.z0eek("innerid", ((DCFormElement)p1).z0mek().ToString());
			z0rek(p0, "id", text);
			z0rek(p0, "name", p3);
			z0rek(p0, "title", ((DCFormElement)p1).z0cek());
			if (p1.z0hrk() != null && p1.z0hrk().Count > 0)
			{
				using zzz.z0ZzZzkuk<ListItem>.z0bpk z0bpk = p1.z0hrk().z0ltk();
				while (z0bpk.MoveNext())
				{
					ListItem current = z0bpk.Current;
					p0.z0eek("option");
					if (current.Value == p1.z0lrk())
					{
						p0.z0eek("selected", "true");
					}
					z0rek(p0, "value", current.Value);
					if (current.Text != null)
					{
						p0.z0yg(current.Text);
					}
					p0.z0mg();
				}
			}
			p0.z0mg();
		}
		else if (p1.z0oek())
		{
			p0.z0eek("br");
			p0.z0bg();
			p0.z0eek("textarea");
			p0.z0eek("innerid", ((DCFormElement)p1).z0mek().ToString());
			z0rek(p0, "name", p3);
			z0rek(p0, "id", text);
			z0rek(p0, "title", ((DCFormElement)p1).z0cek());
			p0.z0eek("style", "width:100%");
			p0.z0yg(p1.z0grk());
			p0.z0mg();
		}
		else
		{
			p0.z0eek("input");
			p0.z0eek("innerid", ((DCFormElement)p1).z0mek().ToString());
			z0rek(p0, "name", p3);
			z0rek(p0, "id", text);
			p0.z0eek("style", "width:200px");
			z0rek(p0, "title", ((DCFormElement)p1).z0cek());
			z0rek(p0, "placeholder", p1.z0pek());
			string p4 = "text";
			switch (p1.z0frk_jiejie20260327142557())
			{
			case InputFieldEditStyle.Date:
				p4 = "date";
				break;
			case InputFieldEditStyle.DateTime:
				p4 = "datetime";
				break;
			case InputFieldEditStyle.DateTimeWithoutSecond:
				p4 = "datetime";
				break;
			case InputFieldEditStyle.Numeric:
				p4 = "number";
				break;
			case InputFieldEditStyle.Time:
				p4 = "time";
				break;
			}
			p0.z0eek("type", p4);
			z0rek(p0, "value", p1.z0grk());
			p0.z0bg();
		}
		if (p1.z0tek() != null && p1.z0tek().Length > 0)
		{
			p0.z0eek("span");
			p0.z0eek("style", "width:100px");
			p0.z0yg(p1.z0tek());
			p0.z0mg();
		}
		p0.z0mg();
	}

	private bool z0rek(char p0)
	{
		if (!char.IsLetterOrDigit(p0))
		{
			return p0 == '_';
		}
		return true;
	}

	private string z0rek(string p0, string p1)
	{
		if (p0 == null || p0.Length == 0)
		{
			if (p1 == null || p1.Length == 0)
			{
				return null;
			}
			return p1;
		}
		if (p1 == null || p1.Length == 0)
		{
			return null;
		}
		return p0 + p1;
	}

	private string z0rek(params string[] p0)
	{
		if (p0 != null && p0.Length != 0)
		{
			foreach (string text in p0)
			{
				if (text != null && text.Length > 0)
				{
					return text;
				}
			}
		}
		return null;
	}

	private void z0rek(z0ZzZzhqh p0, DCFormButtonElement p1, string p2)
	{
		p0.z0eek("br");
		p0.z0bg();
		p0.z0eek("input");
		p0.z0eek("type", "button");
		p0.z0eek("innerid", p1.z0mek().ToString());
		z0rek(p0, "id", z0rek(p2, ((DCFormElement)p1).z0tek()));
		z0rek(p0, "value", p1.z0rek());
		if (p1.z0tek() != null && p1.z0tek().Length > 0)
		{
			if (z0yek == null)
			{
				z0yek = new Dictionary<string, string>();
			}
			string text = p1.z0iek();
			if (text == null || text.Length > 0)
			{
				text = p1.z0vek();
			}
			if (text == null || text.Length > 0)
			{
				text = "ButtonClick_" + z0yek.Count;
			}
			text = z0rek(text, '_');
			if (z0yek.ContainsKey(text))
			{
				for (int i = 0; i < 10; i++)
				{
					string text2 = text + "_" + i;
					if (!z0yek.ContainsKey(text2))
					{
						text = text2;
						break;
					}
				}
			}
			z0yek[text] = p1.z0tek();
		}
		p0.z0bg();
	}

	private void z0rek(z0ZzZzhqh p0, DCFormImageElement p1, string p2)
	{
		p0.z0eek("img");
		z0rek(p0, "id", z0rek(p2, ((DCFormElement)p1).z0tek()));
		z0rek(p0, "title", p1.z0cek());
		z0rek(p0, "alt", p1.z0iek());
		string p3 = p1.z0rek();
		z0rek(p0, "src", p3);
		p0.z0bg();
	}

	private void z0rek(z0ZzZzhqh p0, DCFormLabelElement p1, string p2)
	{
		p0.z0eek("h2");
		p0.z0eek("style", "border:1px solid black");
		p0.z0yg(p1.z0mq());
		p0.z0mg();
	}

	private void z0rek(z0ZzZzhqh p0, DCFormCheckBoxElementBase p1, string p2)
	{
		string text = z0rek(p2, p1.z0lrk());
		p0.z0eek("div");
		p0.z0eek("type", p1.GetType().Name);
		p0.z0eek("id", "Element_" + text);
		p0.z0eek("style", "border-top:1px solid gray");
		if (p1.z0eek().Count == 1)
		{
			z0ZzZzujh z0ZzZzujh = p1.z0eek()[0];
			p0.z0eek("input");
			p0.z0eek("type", (p1 is DCFormCheckBoxElement) ? "checkbox" : "radio");
			p0.z0eek("innerid", z0ZzZzujh.z0iek().ToString());
			z0rek(p0, "id", z0rek(p2, z0ZzZzujh.z0tek()));
			z0rek(p0, "name", text);
			z0rek(p0, "value", z0ZzZzujh.z0yek());
			z0rek(p0, "title", z0ZzZzujh.z0nek());
			if (z0ZzZzujh.z0pek())
			{
				p0.z0eek("checked", "true");
			}
			p0.z0bg();
			p0.z0eek("label");
			z0rek(p0, "for", z0rek(p2, z0ZzZzujh.z0tek()));
			if (z0ZzZzujh.z0bek() != null)
			{
				p0.z0yg(z0ZzZzujh.z0bek());
			}
			p0.z0mg();
		}
		else
		{
			p0.z0eek("div");
			string text2 = z0rek(new string[2]
			{
				p1.z0cek(),
				p1.z0iek()
			});
			if (text2 != null && text2.Length > 0)
			{
				p0.z0yg(text2);
			}
			p0.z0mg();
			int num = z0tek / 2 - 20;
			for (int i = 0; i < p1.z0eek().Count; i++)
			{
				if (i > 0 && i % 2 == 0)
				{
					p0.z0eek("br");
					p0.z0bg();
				}
				z0ZzZzujh z0ZzZzujh2 = p1.z0eek()[i];
				p0.z0eek("input");
				p0.z0eek("type", (p1 is DCFormCheckBoxElement) ? "checkbox" : "radio");
				p0.z0eek("innerid", z0ZzZzujh2.z0iek().ToString());
				z0rek(p0, "id", z0rek(p2, z0ZzZzujh2.z0tek()));
				z0rek(p0, "name", text);
				z0rek(p0, "value", z0ZzZzujh2.z0yek());
				z0rek(p0, "title", z0ZzZzujh2.z0nek());
				if (z0ZzZzujh2.z0pek())
				{
					p0.z0eek("checked", "true");
				}
				p0.z0bg();
				p0.z0eek("label");
				z0rek(p0, "for", z0rek(p2, z0ZzZzujh2.z0tek()));
				p0.z0eek("style", "display:inline-block;width:" + num + "px");
				p0.z0yg(z0ZzZzujh2.z0bek());
				p0.z0bg();
			}
		}
		p0.z0mg();
	}

	public void z0rek(DCFormDocument p0, z0ZzZzhqh p1)
	{
		p1.z0eek("div");
		p1.z0eek("style", "border:1px solid black");
		p1.z0eek("h1");
		if (p0.z0cek() != null)
		{
			p1.z0yg(p0.z0cek());
		}
		else if (p0.z0oek() != null)
		{
			p1.z0yg(p0.z0oek());
		}
		p1.z0mg();
		z0rek(p0.z0xq(), p1, null);
		p1.z0mg();
		if (z0yek == null)
		{
			return;
		}
		p1.z0eek("script");
		p1.z0eek("language", "javascipt");
		foreach (KeyValuePair<string, string> item in z0yek)
		{
			p1.z0yg("function " + item.Key + "( eventObj ){" + Environment.NewLine + item.Value + Environment.NewLine + "}");
		}
		p1.z0mg();
		z0yek = null;
	}
}
