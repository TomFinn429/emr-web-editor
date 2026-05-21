using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using DCSystem_Drawing;
using DCSystem_Drawing.Drawing2D;

namespace zzz;

public class z0ZzZzfjh
{
	private class z0ymk
	{
		public bool z0eek;

		public string z0rek;
	}

	public delegate string z0jnk(string fontName, string text);

	private class z0fpk : z0ZzZzfik
	{
		private new static readonly string z0eek = "0123456789ABCDEF";

		public static readonly z0fpk z0rek = new z0fpk();

		public z0fpk()
			: base(null, p1: true)
		{
		}

		protected override string z0cwk(int p0)
		{
			char[] array = new char[7] { '#', '\0', '\0', '\0', '\0', '\0', '\0' };
			for (int i = 0; i < 6; i++)
			{
				array[6 - i] = z0eek[p0 & 0xF];
				p0 >>= 4;
			}
			return new string(array);
		}
	}

	private class z0ohj : IEqualityComparer<Dictionary<string, string>>
	{
		public int GetHashCode(Dictionary<string, string> obj)
		{
			int num = 0;
			foreach (KeyValuePair<string, string> item in obj)
			{
				num += item.Key.GetHashCode() + item.Value.GetHashCode();
			}
			return num;
		}

		public bool Equals(Dictionary<string, string> x, Dictionary<string, string> y)
		{
			if (x == y)
			{
				return true;
			}
			if (x.Count != y.Count)
			{
				return false;
			}
			Dictionary<string, string>.Enumerator enumerator = x.GetEnumerator();
			Dictionary<string, string>.Enumerator enumerator2 = y.GetEnumerator();
			while (true)
			{
				bool flag = enumerator.MoveNext();
				bool flag2 = enumerator2.MoveNext();
				if (flag != flag2)
				{
					return false;
				}
				if (!flag)
				{
					break;
				}
				if (enumerator.Current.Key != enumerator2.Current.Key || enumerator.Current.Value != enumerator2.Current.Value)
				{
					return false;
				}
			}
			return true;
		}
	}

	[NonSerialized]
	internal z0ZzZzhqh z0irk;

	private string z0ork;

	private string z0prk = "xs_";

	private Dictionary<string, string> z0mrk;

	private bool z0nrk;

	private z0ZzZzfik z0brk;

	[NonSerialized]
	private Encoding z0vrk = Encoding.Default;

	private z0ZzZzjok z0crk = (z0ZzZzjok)4;

	[NonSerialized]
	private z0ZzZzsdh z0xrk;

	private static readonly string[] z0zrk = new string[6] { "solid", "dashed", "dotted", "dotted", "dotted", "solid" };

	private int z0ltk;

	private bool z0ktk = true;

	private static readonly int z0jtk = Color.Black.ToArgb();

	private z0ZzZzyjh z0htk;

	private bool z0gtk;

	private bool z0ftk;

	private StringWriter z0dtk = new StringWriter();

	protected readonly Dictionary<Dictionary<string, string>, int> z0stk = new Dictionary<Dictionary<string, string>, int>(new z0ohj());

	private static readonly int z0atk = Color.White.ToArgb();

	private bool z0qtk;

	public static bool z0wtk = false;

	private Stack<z0ymk> z0etk;

	private bool z0rtk;

	private static string[] z0ttk = null;

	private Dictionary<float, string> z0ytk = new Dictionary<float, string>();

	private string z0utk = string.Empty;

	private float z0itk = 7.5f;

	public z0jnk z0otk;

	private string z0ptk;

	public void z0yek(bool p0, bool p1, bool p2, bool p3, Color p4, int p5, DashStyle p6, bool p7 = false)
	{
		if ((!p0 && !p1 && !p2 && !p3) || p5 <= 0 || p4.A == 0)
		{
			return;
		}
		if (p7)
		{
			p4 = Color.Black;
		}
		string p8 = z0yek(p5, p4, p6);
		if (p0 && p1 && p2 && p3)
		{
			z0yek("border", p8);
			z0uek(z0pek() + p5);
			z0uek(z0pek() + p5);
			return;
		}
		if (p0)
		{
			z0yek("border-left", p8);
		}
		if (p1)
		{
			z0yek("border-top", p8);
			z0uek(z0pek() + p5);
		}
		if (p2)
		{
			z0yek("border-right", p8);
		}
		if (p3)
		{
			z0yek("border-bottom", p8);
			z0uek(z0pek() + p5);
		}
	}

	public virtual void z0zq()
	{
		if (z0ytk != null)
		{
			z0ytk.Clear();
			z0ytk = null;
		}
		if (z0mrk != null)
		{
			z0mrk.Clear();
			z0mrk = null;
		}
		z0ork = null;
		z0xrk = null;
		if (z0etk != null)
		{
			z0etk.Clear();
			z0etk = null;
		}
		z0ptk = null;
		z0dtk = null;
		z0brk = null;
		z0prk = null;
		if (z0stk != null)
		{
			z0stk.Clear();
		}
		if (z0irk != null)
		{
			z0irk.z0kf();
			z0irk = null;
		}
		if (z0brk != null)
		{
			z0brk.Dispose();
			z0brk = null;
		}
	}

	public void z0yek(string p0)
	{
		z0irk.z0yg(p0);
	}

	public void z0yek(string p0, int p1, int p2)
	{
		if (p1 != p2)
		{
			z0irk.z0eek(p0, z0ZzZzqik.z0rek(p1));
		}
	}

	public void z0yek(string p0, int p1)
	{
		z0irk.z0eek(p0, z0ZzZzqik.z0rek(p1));
	}

	public string z0yek()
	{
		StringWriter stringWriter = new StringWriter();
		z0ZzZzhqh z0ZzZzhqh2 = new z0ZzZzhqh(stringWriter);
		if (z0vek())
		{
			z0ZzZzhqh2.z0eek((z0ZzZzesh)1);
			z0ZzZzhqh2.z0eek(' ');
			z0ZzZzhqh2.z0rek(3);
		}
		else
		{
			z0ZzZzhqh2.z0eek((z0ZzZzesh)0);
		}
		z0ZzZzhqh2.z0ug();
		z0ZzZzhqh2.z0og("<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Transitional//EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd\">");
		z0ZzZzhqh2.z0eek("html");
		z0ZzZzhqh2.z0eek("xmlns", "http://www.w3.org/1999/xhtml");
		z0ZzZzhqh2.z0eek("head");
		string text = z0rrk();
		if (text != null && text.Length > 0)
		{
			((z0ZzZzdqh)z0ZzZzhqh2).z0rek("title", text);
		}
		z0ZzZzhqh2.z0eek("meta");
		z0ZzZzhqh2.z0eek("http-equiv", "Content-Type");
		z0ZzZzhqh2.z0eek("content", "text/html;charset=" + z0hrk().BodyName);
		z0ZzZzhqh2.z0bg();
		z0ZzZzhqh2.z0bg();
		string text2 = z0srk();
		if (text2 != null && text2.Length > 0)
		{
			z0ZzZzhqh2.z0eek("style");
			z0ZzZzhqh2.z0og(Environment.NewLine);
			z0ZzZzhqh2.z0yg(text2);
			z0ZzZzhqh2.z0og(Environment.NewLine);
			z0ZzZzhqh2.z0bg();
		}
		z0ZzZzhqh2.z0eek("body");
		if (z0erk())
		{
			z0ZzZzhqh2.z0eek("contenteditable", "true");
		}
		StringBuilder stringBuilder = new StringBuilder();
		if (z0nek() != null)
		{
			stringBuilder.Append("font-size:" + z0nek().z0yek() + "pt;");
		}
		if (z0qrk() != null && z0qrk().Length > 0)
		{
			stringBuilder.Append("background-image:url(" + z0ZzZztwh.z0eek(z0qrk()) + ");background-attachment:fixed;background-repeat:no-repeat;background-position:top center;");
		}
		z0ZzZzhqh2.z0eek("style", stringBuilder.ToString());
		z0ZzZzhqh2.z0og(Environment.NewLine);
		string text3 = z0bek();
		if (text3.StartsWith("<div>") && text3.EndsWith("</div>"))
		{
			text3 = text3.Substring(5, text3.Length - 11).Trim();
		}
		z0ZzZzhqh2.z0og(text3);
		z0ZzZzhqh2.z0bg();
		z0ZzZzhqh2.z0bg();
		z0ZzZzhqh2.z0vg();
		z0ZzZzhqh2.z0kf();
		return z0mek(stringWriter.ToString());
	}

	public void z0yek(string p0, Color p1, int p2, DashStyle p3)
	{
		if (p0 != null && p0.Length != 0 && p2 > 0)
		{
			string p4 = z0yek(p2, p1, p3);
			z0yek("border-" + p0, p4);
			if (string.Compare(p0, "top", true) == 0 || string.Compare(p0, "bottom", true) == 0)
			{
				z0uek(z0pek() + p2);
			}
		}
	}

	public void z0yek(z0ZzZzimk p0, string p1)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("font");
		}
		if (z0otk != null && p1 != null)
		{
			string text = z0otk(p0.Name, p1);
			if (text != null && text.Length > 0)
			{
				z0yek("font-family", text);
			}
			else
			{
				z0yek("font-family", p0.z0uek());
			}
		}
		else
		{
			z0yek("font-family", p0.z0uek());
		}
		z0yek("font-size", p0.Size + "pt");
		if (p0.Italic)
		{
			z0yek("font-style", "italic");
		}
		else if (z0krk())
		{
			z0yek("font-style", "normal");
		}
		if (p0.Bold)
		{
			z0yek("font-weight", "bold");
		}
		else if (z0krk())
		{
			z0yek("font-weight", "normal");
		}
		if (p0.Underline)
		{
			z0yek("text-decoration", "underline");
		}
		else if (p0.Strikeout)
		{
			z0yek("text-decoration", "line-through");
		}
		else if (z0krk())
		{
			z0yek("text-decoration", "none");
		}
	}

	public void z0yek(bool p0)
	{
		z0nrk = p0;
	}

	public void z0uek(string p0)
	{
		z0irk.z0og(p0);
	}

	public bool z0uek()
	{
		return z0ftk;
	}

	public static string z0yek(Color p0)
	{
		if (p0.A == 0)
		{
			return "transparent";
		}
		int num = p0.ToArgb();
		if (num == z0jtk)
		{
			return "black";
		}
		if (num == z0atk)
		{
			return "white";
		}
		if (p0.A == 255)
		{
			return z0fpk.z0rek.z0eek(num);
		}
		return z0ZzZzifh.z0eek(p0);
	}

	public virtual void z0iek()
	{
		z0etk = null;
		z0irk.z0vg();
	}

	public void z0oek()
	{
		z0ptk = null;
		z0mrk = new Dictionary<string, string>();
		z0uek(0);
	}

	public int z0pek()
	{
		if (z0urk_jiejie20260327142557())
		{
			return z0ltk;
		}
		return 0;
	}

	public void z0yek(float p0)
	{
		z0itk = p0;
	}

	public z0ZzZztjh z0mek()
	{
		if (z0trk() == (z0ZzZzjok)5 && z0ark_jiejie20260327142557() == (z0ZzZzyjh)0)
		{
			return (z0ZzZztjh)0;
		}
		return (z0ZzZztjh)1;
	}

	public z0ZzZzsdh z0nek()
	{
		return z0xrk;
	}

	public void z0yek(string p0, bool p1)
	{
		if (p1)
		{
			z0irk.z0eek(p0, "true");
		}
		else
		{
			z0irk.z0eek(p0, "false");
		}
	}

	public virtual void z0uek(bool p0)
	{
		z0gtk = p0;
	}

	public void z0iek(string p0)
	{
		z0utk = p0;
	}

	public string z0uek(float p0)
	{
		if (p0 == 0f)
		{
			return "0px";
		}
		int num = (int)p0;
		if ((float)num == p0 && num >= 0 && num < 100)
		{
			return z0iek(num);
		}
		string text = null;
		if (!z0ytk.TryGetValue(p0, out text))
		{
			text = p0 + "px";
			z0ytk[p0] = text;
		}
		return text;
	}

	public virtual string z0bek()
	{
		if (z0irk == null || z0dtk == null)
		{
			return null;
		}
		z0irk.z0lf();
		string p = z0dtk.ToString();
		return z0mek(p);
	}

	public void z0oek(string p0)
	{
		if (p0 != null)
		{
			p0 = z0ZzZztwh.z0yek(p0);
			if (z0uek())
			{
				string[] array = z0pek(p0);
				foreach (string text in array)
				{
					if (text[0] == ' ')
					{
						z0irk.z0eek("span");
						int num = text.Length;
						if (num > 4)
						{
							num -= 2;
						}
						z0irk.z0eek("style", "width:" + Convert.ToString(z0grk() * (float)num));
						z0irk.z0mg();
					}
					else
					{
						string text2 = null;
						text2 = text.Replace(Environment.NewLine, "<br />");
						z0irk.z0yg(text2);
					}
				}
			}
			else
			{
				p0 = p0.Replace(" ", "&ensp;");
				p0 = p0.Replace(Environment.NewLine, "<br />");
				if (p0.Length == 0)
				{
					z0irk.z0yg(" ");
				}
				else
				{
					z0irk.z0og(p0);
				}
			}
		}
		else
		{
			z0irk.z0yg(" ");
		}
	}

	public virtual void z0hw()
	{
		z0etk = new Stack<z0ymk>();
		z0irk.z0ug();
	}

	private string[] z0pek(string p0)
	{
		ArrayList arrayList = new ArrayList();
		StringBuilder stringBuilder = new StringBuilder();
		bool flag = false;
		foreach (char c in p0)
		{
			bool num = c == ' ';
			if (num != flag && stringBuilder.Length > 0)
			{
				arrayList.Add(stringBuilder.ToString());
				stringBuilder = new StringBuilder();
			}
			flag = num;
			stringBuilder.Append(c);
		}
		if (stringBuilder.Length > 0)
		{
			arrayList.Add(stringBuilder.ToString());
		}
		return (string[])arrayList.ToArray(typeof(string));
	}

	public virtual bool z0vek()
	{
		return z0gtk;
	}

	public string z0cek()
	{
		return z0ZzZzqik.z0eek(z0yek(), '\u007f', '\uffff');
	}

	public void z0iek(bool p0)
	{
		z0qtk = p0;
	}

	public virtual void z0xek()
	{
		z0irk.z0mg();
		z0lrk().Pop();
	}

	protected static string z0yek(DashStyle p0)
	{
		if (p0 >= DashStyle.Solid && p0 <= DashStyle.Custom)
		{
			return z0zrk[(int)p0];
		}
		return "solid";
	}

	public void z0yek(string p0, string p1)
	{
		if (z0mrk == null)
		{
			throw new InvalidOperationException("Can not set style");
		}
		z0mrk[p0] = p1;
	}

	public virtual string z0zek()
	{
		if (z0mrk == null)
		{
			throw new InvalidOperationException("StyleString is null");
		}
		Dictionary<string, string> dictionary = z0mrk;
		z0mrk = null;
		if (dictionary.Count == 0)
		{
			if (z0ptk != null && z0ptk.Length > 0)
			{
				z0lrk(z0ptk);
				z0ptk = null;
			}
			return null;
		}
		bool flag = z0lw();
		if (flag && z0lrk().Peek().z0eek)
		{
			flag = false;
		}
		if (flag)
		{
			int num = 0;
			if (!z0stk.TryGetValue(dictionary, out num))
			{
				num = z0stk.Count;
				z0stk.Add(dictionary, num);
			}
			string text = z0yek(num);
			if (z0ptk != null && z0ptk.Length > 0)
			{
				text = text + " " + z0ptk;
				z0ptk = null;
			}
			z0lrk(text);
			return text;
		}
		StringBuilder stringBuilder = new StringBuilder();
		z0tek(dictionary, stringBuilder);
		z0uek("style", stringBuilder.ToString());
		if (z0ptk != null && z0ptk.Length > 0)
		{
			z0lrk(z0ptk);
			z0ptk = null;
		}
		return null;
	}

	public void z0eek<ET>(string p0, ET p1) where ET : Enum
	{
		z0irk.z0eek(p0, zzz.z0ZzZzcyk<ET>.z0rek(p1));
	}

	public void z0yek(Encoding p0)
	{
		z0vrk = p0;
	}

	public void z0yek(int p0, int p1, int p2, int p3)
	{
		if (p0 != 0)
		{
			z0yek("margin-left", p0.ToString());
		}
		if (p1 != 0)
		{
			z0yek("margin-top", p1.ToString());
		}
		if (p2 != 0)
		{
			z0yek("margin-right", p2.ToString());
		}
		if (p3 != 0)
		{
			z0yek("margin-bottom", p3.ToString());
		}
	}

	public void z0rek<ET>(string p0, ET p1, ET p2) where ET : Enum
	{
		if (p1.CompareTo(p2) != 0)
		{
			z0irk.z0eek(p0, zzz.z0ZzZzcyk<ET>.z0rek(p1));
		}
	}

	private Stack<z0ymk> z0lrk()
	{
		if (z0etk == null)
		{
			z0etk = new Stack<z0ymk>();
		}
		return z0etk;
	}

	public void z0yek(z0ZzZzsdh p0)
	{
		z0xrk = p0;
	}

	public void z0yek(z0ZzZzyjh p0)
	{
		z0htk = p0;
	}

	public string z0yek(int p0)
	{
		if (z0brk == null)
		{
			z0brk = new z0ZzZzfik(z0prk);
		}
		return z0brk.z0eek(p0);
	}

	public bool z0krk()
	{
		return z0nrk;
	}

	public StringBuilder z0jrk()
	{
		if (z0dtk == null)
		{
			return null;
		}
		return z0dtk.GetStringBuilder();
	}

	protected string z0mek(string p0)
	{
		if (p0.StartsWith("<html", StringComparison.Ordinal))
		{
			return p0;
		}
		return z0ZzZzzik.z0eek(p0);
	}

	public void z0nek(string p0)
	{
		z0ptk = p0;
	}

	public Encoding z0hrk()
	{
		if (z0vrk == null)
		{
			z0vrk = Encoding.Default;
		}
		return z0vrk;
	}

	public void z0uek(int p0, int p1, int p2, int p3)
	{
		if (p0 != 0 || p1 != 0 || p2 != 0 || p3 != 0)
		{
			z0yek("padding", p1 + " " + p2 + " " + p3 + " " + p0);
		}
	}

	public float z0grk()
	{
		return z0itk;
	}

	public void z0bek(string p0)
	{
		z0prk = p0;
		z0brk = null;
	}

	protected string z0yek(int p0, Color p1, DashStyle p2)
	{
		string text = z0yek(p2);
		return p0 + "px " + text + " " + z0uek(p1);
	}

	public void z0oek(bool p0)
	{
		z0ftk = p0;
	}

	public void z0uek(int p0)
	{
		if (z0urk_jiejie20260327142557())
		{
			z0ltk = p0;
		}
		else
		{
			z0ltk = 0;
		}
	}

	public void z0uek(string p0, string p1)
	{
		if (p1 == null)
		{
			z0irk.z0eek(p0, string.Empty);
		}
		else
		{
			z0irk.z0eek(p0, p1);
		}
	}

	public void z0uek(string p0, bool p1 = false)
	{
		if (p1)
		{
			z0yek("background-image", "url(" + p0 + ")!important");
		}
		else
		{
			z0yek("background-image", "url(" + p0 + ")");
		}
		z0yek("-webkit-print-color-adjust", "exact");
	}

	public string z0frk()
	{
		if (z0prk == null || z0prk.Length == 0)
		{
			return "xs_";
		}
		return z0prk;
	}

	public void z0vek(string p0)
	{
		if (z0mrk != null)
		{
			z0mrk.Remove(p0);
		}
	}

	private void z0tek(Dictionary<string, string> p0, StringBuilder p1)
	{
		bool flag = true;
		foreach (KeyValuePair<string, string> item in p0)
		{
			if (!flag)
			{
				p1.Append(';');
			}
			flag = false;
			p1.Append(item.Key);
			p1.Append(':');
			p1.Append(item.Value);
		}
	}

	public bool z0drk()
	{
		return z0mrk != null;
	}

	public void z0yek(Stream p0)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("stream");
		}
		byte[] bytes = z0hrk().GetBytes(z0yek());
		p0.Write(bytes, 0, bytes.Length);
	}

	public void z0iek(string p0, bool p1 = false)
	{
		if (p0 != null && p0.Length != 0)
		{
			if (!p0.StartsWith("data:image"))
			{
				p0 = "data:image/png;base64," + p0;
			}
			if (p1)
			{
				z0yek("background-image", "url(" + p0 + ")!important");
			}
			else
			{
				z0yek("background-image", "url(" + p0 + ")");
			}
			z0yek("-webkit-print-color-adjust", "exact");
		}
	}

	public string z0srk()
	{
		if (z0stk == null || z0stk.Count == 0)
		{
			return string.Empty;
		}
		StringBuilder stringBuilder = new StringBuilder();
		foreach (KeyValuePair<Dictionary<string, string>, int> item in z0stk)
		{
			string text = z0yek(item.Value);
			stringBuilder.Append('.');
			stringBuilder.Append(text);
			stringBuilder.Append('{');
			z0tek(item.Key, stringBuilder);
			stringBuilder.Append('}');
			stringBuilder.AppendLine();
		}
		stringBuilder.AppendLine();
		return stringBuilder.ToString();
	}

	public string z0iek(int p0)
	{
		if (z0ttk == null)
		{
			string[] array = new string[100];
			for (int i = 0; i < 100; i++)
			{
				array[i] = i + "px";
			}
			z0ttk = array;
		}
		if (p0 >= 0 && p0 < 100)
		{
			return z0ttk[p0];
		}
		return p0 + "px";
	}

	public z0ZzZzyjh z0ark_jiejie20260327142557()
	{
		return z0htk;
	}

	public void z0yek(string p0, float p1)
	{
		z0irk.z0eek(p0, p1.ToString());
	}

	public void z0yek(z0ZzZzhqh p0)
	{
		if (z0irk != null)
		{
			z0irk.z0kf();
		}
		z0irk = p0;
	}

	public void z0pek(bool p0)
	{
		z0ktk = p0;
	}

	public virtual bool z0lw()
	{
		return z0rtk;
	}

	public string z0qrk()
	{
		return z0ork;
	}

	public virtual void z0cek(string p0)
	{
		z0irk.z0eek(p0);
		z0ymk z0ymk = new z0ymk();
		z0ymk.z0rek = p0;
		z0lrk().Push(z0ymk);
	}

	public virtual void z0jw(bool p0)
	{
		z0rtk = p0;
	}

	public virtual void z0wrk()
	{
		if (z0mrk == null)
		{
			throw new InvalidOperationException("StyleString is null");
		}
		Dictionary<string, string> p = z0mrk;
		z0mrk = null;
		StringBuilder stringBuilder = new StringBuilder();
		z0tek(p, stringBuilder);
		z0uek("style", stringBuilder.ToString());
	}

	public string z0uek(Color p0)
	{
		return z0yek(p0);
	}

	public bool z0erk()
	{
		return z0qtk;
	}

	public string z0rrk()
	{
		return z0utk;
	}

	public virtual void z0kw()
	{
		z0dtk = new StringWriter();
		if (z0irk == null || z0irk.z0yek() is StringWriter)
		{
			z0irk = new z0ZzZzhqh(z0dtk);
		}
		if (z0irk != null)
		{
			z0ZzZzhqh z0ZzZzhqh2 = z0irk;
			if (z0vek())
			{
				z0ZzZzhqh2.z0eek((z0ZzZzesh)1);
				z0ZzZzhqh2.z0rek(3);
				z0ZzZzhqh2.z0eek(' ');
			}
			else
			{
				z0ZzZzhqh2.z0eek((z0ZzZzesh)0);
			}
		}
	}

	public z0ZzZzjok z0trk()
	{
		return z0crk;
	}

	public void z0yek(z0ZzZzjok p0)
	{
		z0crk = p0;
	}

	public virtual void z0yrk()
	{
		z0irk.z0bg();
		z0lrk().Pop();
	}

	public bool z0urk_jiejie20260327142557()
	{
		return z0ktk;
	}

	public void z0yek(string p0, Color p1, int p2, DashStyle p3, bool p4 = false)
	{
		if (p4)
		{
			p1 = Color.Black;
		}
		if (p2 > 0 && p1.A != 0)
		{
			string p5 = z0yek(p2, p1, p3);
			if (p0 == null || p0.Length == 0)
			{
				z0yek("border", p5);
			}
			else
			{
				z0yek("border-" + p0, p5);
			}
			if (string.Compare(p0, "top", true) == 0 || string.Compare(p0, "bottom", true) == 0)
			{
				z0uek(z0pek() + p2);
			}
		}
	}

	public void z0iek(string p0, string p1)
	{
		if (p1 != null && p1.Length > 0)
		{
			z0irk.z0eek(p0, p1);
		}
	}

	public z0ZzZzfjh()
	{
		z0irk = new z0ZzZzhqh(z0dtk);
	}

	public void z0xek(string p0)
	{
		z0ork = p0;
	}

	public void z0yek(char p0)
	{
		z0irk.z0xg(p0);
	}

	public void z0zek(string p0)
	{
		z0irk.z0ng(p0);
	}

	public void z0lrk(string p0)
	{
		if (p0 == null || p0.Length == 0)
		{
			throw new ArgumentNullException("v");
		}
		if (z0lw())
		{
			z0lrk().Peek().z0eek = true;
		}
		z0irk.z0eek("class", p0);
	}

	public void z0yek(TextWriter p0)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("writer");
		}
		p0.Write(z0yek());
	}
}
