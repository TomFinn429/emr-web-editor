using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace zzz;

internal class z0ZzZzkbk : z0ZzZzznk
{
	private new bool z0nek;

	private new Dictionary<string, z0ZzZzlvk> z0bek;

	public new static bool z0vek = true;

	internal z0ZzZzhbk z0cek;

	private string z0xek = "gb2312";

	private string z0zek;

	private new string z0lrk;

	internal Dictionary<string, z0ZzZzevk> z0krk;

	public new void z0eek(string p0)
	{
		z0xek = p0;
	}

	public override string z0vak()
	{
		return "html";
	}

	public new string z0eek()
	{
		return z0xek;
	}

	public new z0ZzZzgbk z0rek()
	{
		z0ZzZzgbk z0ZzZzgbk2 = new z0ZzZzgbk();
		z0eek(z0ZzZzgbk2);
		return z0ZzZzgbk2;
	}

	public new z0ZzZzqbk z0tek()
	{
		return base.z0tek.z0srk<z0ZzZzqbk>();
	}

	private new bool z0rek(string p0)
	{
		switch (p0)
		{
		default:
			return p0 == "xml";
		case "head":
		case "body":
		case "script":
		case "style":
		case "frameset":
		case "noframes":
		case "noscript":
		case "#comment":
			return true;
		}
	}

	public new string z0tek(string p0)
	{
		string text = p0;
		if (text.IndexOf("://") > 0 || string.IsNullOrEmpty(z0mek()))
		{
			return z0ZzZzjbk.z0eek(text);
		}
		text = new Uri(new Uri(z0lrk), text).AbsoluteUri;
		return z0ZzZzjbk.z0eek(text);
	}

	public new string z0yek()
	{
		return z0zek;
	}

	public void z0yek(string p0)
	{
		z0lrk = p0;
		z0uek();
	}

	public bool z0eek(byte[] p0)
	{
		bool flag = false;
		z0eek(Encoding.UTF8.WebName);
		string text = Encoding.GetEncoding(z0eek()).GetString(p0);
		text = text.Replace("charset=unicode", "charset=utf-8");
		try
		{
			return z0uek(text);
		}
		catch (z0ZzZzbnk)
		{
			text = Encoding.GetEncoding(z0eek()).GetString(p0);
			return z0uek(text);
		}
	}

	public z0ZzZzkbk()
	{
		base.z0lrk = this;
	}

	internal override bool z0rqk(z0ZzZznvk p0)
	{
		if (base.z0bek == null)
		{
			base.z0bek = new z0ZzZzink();
		}
		else
		{
			base.z0bek.Clear();
		}
		base.z0tek.Clear();
		z0ZzZzhbk z0ZzZzhbk2 = new z0ZzZzqbk();
		z0ZzZzhbk2.z0eek(this, this);
		base.z0tek.Add(z0ZzZzhbk2);
		z0ZzZzhbk2 = new z0ZzZzmnk();
		z0ZzZzhbk2.z0eek(this, this);
		((z0ZzZzmnk)z0ZzZzhbk2).z0eek(p0: false);
		base.z0tek.Add(z0ZzZzhbk2);
		z0eek(p0);
		bool result = z0dqk(p0);
		FixDom();
		return result;
	}

	private new void z0uek()
	{
		if (z0lrk != null)
		{
			z0lrk = z0lrk.Trim();
			while (z0lrk.EndsWith("/") || z0lrk.EndsWith("\\"))
			{
				z0lrk = z0lrk.Substring(0, z0lrk.Length - 1).Trim();
			}
		}
	}

	public new string z0iek()
	{
		z0ZzZzqbk z0ZzZzqbk2 = z0tek();
		if (z0ZzZzqbk2 != null)
		{
			z0ZzZzbvk z0ZzZzbvk2 = z0ZzZzqbk2.z0oqk().z0srk<z0ZzZzbvk>();
			if (z0ZzZzbvk2 != null)
			{
				return z0ZzZzbvk2.z0hqk();
			}
		}
		return z0zek;
	}

	internal override bool z0xak(string p0)
	{
		return true;
	}

	public bool z0eek(TextReader p0)
	{
		string text = p0.ReadToEnd();
		if (text == null)
		{
			return false;
		}
		text = text.Trim();
		if (text.StartsWith("Version:"))
		{
			StringReader stringReader = new StringReader(text);
			for (int i = 0; i < 10; i++)
			{
				string text2 = stringReader.ReadLine();
				if (text2 == null)
				{
					break;
				}
				if (!text2.StartsWith("SourceURL:"))
				{
					continue;
				}
				string text3 = text2.Substring(10);
				if (string.IsNullOrEmpty(text3))
				{
					break;
				}
				if (text3.EndsWith("/"))
				{
					z0lrk = text3;
				}
				else
				{
					int num = text3.LastIndexOf("/");
					z0lrk = text3.Substring(0, num + 1);
					if (string.Compare(z0lrk, "http://", true) == 0 || string.Compare(z0lrk, "https://", true) == 0 || string.Compare(z0lrk, "ftp://", true) == 0)
					{
						z0lrk = text3;
					}
				}
				z0uek();
				break;
			}
			byte[] bytes = Encoding.Default.GetBytes(text);
			text = Encoding.UTF8.GetString(bytes).Replace("\ufffd?", "<");
		}
		z0eek(Encoding.Default.WebName);
		z0nek = true;
		z0ZzZznvk z0ZzZznvk2 = new z0ZzZznvk(text, this);
		z0ZzZznvk2.z0eek(p0: false);
		bool result = z0rqk(z0ZzZznvk2);
		z0nek = false;
		return result;
	}

	public override bool z0uqk(z0ZzZzhbk p0)
	{
		if (p0 == this)
		{
			return true;
		}
		if (z0rek(p0.z0vak()))
		{
			return base.z0uqk(p0);
		}
		using (zzz.z0ZzZzkuk<z0ZzZzhbk>.z0bpk z0bpk = base.z0tek.z0ltk())
		{
			while (z0bpk.MoveNext())
			{
				z0ZzZzhbk current = z0bpk.Current;
				if (current is z0ZzZzznk && ((z0ZzZzznk)current).z0iqk(p0))
				{
					return true;
				}
			}
		}
		return false;
	}

	public bool z0uek(string p0)
	{
		z0nek = true;
		z0ZzZznvk z0ZzZznvk2 = new z0ZzZznvk(p0, this);
		bool result = z0rqk(z0ZzZznvk2);
		z0ZzZznvk2.Dispose();
		z0nek = false;
		return result;
	}

	public bool z0eek(Stream p0)
	{
		base.z0oek().Clear();
		z0oqk().Clear();
		MemoryStream memoryStream = new MemoryStream();
		byte[] array = new byte[1024];
		while (true)
		{
			int num = p0.Read(array, 0, array.Length);
			if (num <= 0)
			{
				break;
			}
			memoryStream.Write(array, 0, num);
		}
		memoryStream.Close();
		array = memoryStream.ToArray();
		return z0eek(array);
	}

	public override void Dispose()
	{
		base.Dispose();
		if (z0bek != null)
		{
			foreach (KeyValuePair<string, z0ZzZzlvk> item in z0bek)
			{
				item.Value.Dispose();
			}
			z0bek.Clear();
			z0bek = null;
		}
		z0lrk = null;
		z0xek = null;
		z0zek = null;
	}

	public override string z0jqk()
	{
		if (z0pek() == null)
		{
			return null;
		}
		StringBuilder stringBuilder = new StringBuilder();
		z0pek().z0eqk(stringBuilder);
		return z0ZzZztwh.z0rek(stringBuilder.ToString());
	}

	public new Dictionary<string, z0ZzZzlvk> z0oek()
	{
		if (z0bek == null)
		{
			z0bek = new Dictionary<string, z0ZzZzlvk>();
			using zzz.z0ZzZzkuk<z0ZzZzhbk>.z0bpk z0bpk = z0rek().z0ltk();
			while (z0bpk.MoveNext())
			{
				z0ZzZzhbk current = z0bpk.Current;
				if (!(current is z0ZzZzrvk))
				{
					continue;
				}
				z0ZzZzrvk z0ZzZzrvk2 = (z0ZzZzrvk)current;
				if (z0ZzZzrvk2.z0eek() == null)
				{
					continue;
				}
				foreach (z0ZzZzlvk item in z0ZzZzrvk2.z0eek())
				{
					z0bek[item.z0eek()] = item;
				}
			}
		}
		return z0bek;
	}

	public z0ZzZzmnk z0pek()
	{
		return base.z0tek.z0srk<z0ZzZzmnk>();
	}

	internal z0ZzZzhbk z0eek(string p0, z0ZzZzznk p1)
	{
		if (p0 == null || p0.Length == 0)
		{
			return null;
		}
		z0ZzZzhbk z0ZzZzhbk2 = null;
		switch (p0)
		{
		case "html":
			z0ZzZzhbk2 = ((p1 != null && p1 != this) ? ((z0ZzZzznk)new z0ZzZzlbk()) : ((z0ZzZzznk)this));
			break;
		case "head":
			if (p1 is z0ZzZzkbk)
			{
				z0ZzZzhbk2 = z0tek();
				if (z0ZzZzhbk2 == null)
				{
					z0ZzZzhbk2 = new z0ZzZzqbk();
				}
			}
			break;
		case "body":
			if (p1 is z0ZzZzkbk)
			{
				z0ZzZzhbk2 = z0pek();
				if (z0ZzZzhbk2 == null)
				{
					z0ZzZzhbk2 = new z0ZzZzmnk();
				}
				((z0ZzZzmnk)z0ZzZzhbk2).z0eek(p0: true);
			}
			else
			{
				z0ZzZzhbk2 = new z0ZzZzlbk();
			}
			break;
		case "ie:devicerect":
			z0ZzZzhbk2 = new z0ZzZztbk();
			break;
		case "ie:headerfooter":
			z0ZzZzhbk2 = new z0ZzZzybk();
			break;
		case "ie:layoutrect":
			z0ZzZzhbk2 = new z0ZzZzubk();
			break;
		case "ie:templateprinter":
			z0ZzZzhbk2 = new z0ZzZzibk();
			break;
		case "h1":
			z0ZzZzhbk2 = new z0ZzZzwbk(1);
			break;
		case "h2":
			z0ZzZzhbk2 = new z0ZzZzwbk(2);
			break;
		case "h3":
			z0ZzZzhbk2 = new z0ZzZzwbk(3);
			break;
		case "h4":
			z0ZzZzhbk2 = new z0ZzZzwbk(4);
			break;
		case "h5":
			z0ZzZzhbk2 = new z0ZzZzwbk(5);
			break;
		case "h6":
			z0ZzZzhbk2 = new z0ZzZzwbk(6);
			break;
		case "input":
			z0ZzZzhbk2 = new z0ZzZzmbk();
			break;
		case "textarea":
			z0ZzZzhbk2 = new z0ZzZzpvk();
			break;
		case "select":
			z0ZzZzhbk2 = new z0ZzZzqvk();
			break;
		case "option":
			z0ZzZzhbk2 = new z0ZzZzgvk();
			break;
		case "form":
			z0ZzZzhbk2 = new z0ZzZzdbk();
			break;
		case "a":
			z0ZzZzhbk2 = new z0ZzZzrnk();
			break;
		case "b":
			z0ZzZzhbk2 = new z0ZzZzonk();
			break;
		case "pre":
			z0ZzZzhbk2 = new z0ZzZzsvk();
			break;
		case "span":
			z0ZzZzhbk2 = new z0ZzZzwvk();
			break;
		case "div":
			z0ZzZzhbk2 = new z0ZzZzlbk();
			break;
		case "p":
			z0ZzZzhbk2 = new z0ZzZzdvk();
			break;
		case "br":
			z0ZzZzhbk2 = new z0ZzZznnk();
			break;
		case "applet":
			z0ZzZzhbk2 = new z0ZzZztnk();
			break;
		case "#text":
			z0ZzZzhbk2 = new z0ZzZzmvk();
			break;
		case "object":
			z0ZzZzhbk2 = new z0ZzZzjvk();
			break;
		case "script":
			z0ZzZzhbk2 = new z0ZzZzavk();
			break;
		case "link":
			z0ZzZzhbk2 = new z0ZzZzvbk();
			break;
		case "font":
			z0ZzZzhbk2 = new z0ZzZzfbk();
			break;
		case "meta":
			z0ZzZzhbk2 = new z0ZzZzzbk();
			break;
		case "gbsound":
			z0ZzZzhbk2 = new z0ZzZzpnk();
			break;
		case "param":
			z0ZzZzhbk2 = new z0ZzZzfvk();
			break;
		case "#comment":
			z0ZzZzhbk2 = new z0ZzZzxnk();
			break;
		case "hr":
			z0ZzZzhbk2 = new z0ZzZzebk();
			break;
		case "table":
			z0ZzZzhbk2 = new z0ZzZzuvk();
			break;
		case "tbody":
			z0ZzZzhbk2 = new z0ZzZzivk();
			break;
		case "tr":
			z0ZzZzhbk2 = new z0ZzZzvvk();
			break;
		case "td":
			z0ZzZzhbk2 = new z0ZzZzovk();
			break;
		case "col":
			z0ZzZzhbk2 = new z0ZzZzvnk();
			break;
		case "style":
			z0ZzZzhbk2 = new z0ZzZzrvk();
			break;
		case "img":
			z0ZzZzhbk2 = new z0ZzZzpbk();
			break;
		case "title":
			z0ZzZzhbk2 = new z0ZzZzbvk();
			break;
		case "ul":
			z0ZzZzhbk2 = new z0ZzZzcvk();
			break;
		case "li":
			z0ZzZzhbk2 = new z0ZzZzbbk();
			break;
		case "ol":
			z0ZzZzhbk2 = new z0ZzZzhvk();
			break;
		case "map":
			z0ZzZzhbk2 = new z0ZzZzcbk();
			break;
		case "area":
			z0ZzZzhbk2 = new z0ZzZzynk();
			break;
		case "hta:application":
			z0ZzZzhbk2 = new z0ZzZzrbk();
			break;
		case "frameset":
			z0ZzZzhbk2 = new z0ZzZzabk();
			break;
		case "frame":
			z0ZzZzhbk2 = new z0ZzZzsbk();
			break;
		case "label":
			z0ZzZzhbk2 = new z0ZzZznbk();
			break;
		case "marquee":
			z0ZzZzhbk2 = new z0ZzZzxbk();
			break;
		case "iframe":
			z0ZzZzhbk2 = new z0ZzZzobk();
			break;
		case "xml":
			z0ZzZzhbk2 = new z0ZzZzzvk();
			break;
		case "sup":
			z0ZzZzhbk2 = new z0ZzZzyvk();
			break;
		case "sub":
			z0ZzZzhbk2 = new z0ZzZztvk();
			break;
		case "nobr":
			z0ZzZzhbk2 = new z0ZzZzkvk();
			break;
		case "colgroup":
			z0ZzZzhbk2 = new z0ZzZzcnk();
			break;
		default:
			z0ZzZzhbk2 = new z0ZzZzxvk(p0);
			break;
		}
		z0ZzZzhbk2?.z0eek(this, p1);
		return z0ZzZzhbk2;
	}

	public string z0mek()
	{
		return z0lrk;
	}

	public z0ZzZzhbk z0iek(string p0)
	{
		if (z0pek() != null)
		{
			return z0pek().z0eek(p0);
		}
		return null;
	}
}
