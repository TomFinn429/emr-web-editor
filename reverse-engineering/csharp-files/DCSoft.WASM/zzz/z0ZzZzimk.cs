using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using DCSystem_Drawing;

namespace zzz;

public class z0ZzZzimk : ICloneable, IDisposable
{
	public delegate string z0knk(string fontName);

	[NonSerialized]
	public static z0ZzZzsdh z0oek;

	private string z0pek = DefaultFontName;

	private bool z0mek;

	private bool z0nek;

	private float z0bek = DefaultFontSize;

	private static z0ZzZzimk z0vek;

	private bool z0cek;

	[NonSerialized]
	public static string DefaultFontName;

	private bool z0xek;

	[NonSerialized]
	private z0ZzZzsdh z0zek;

	private static List<string> z0lrk;

	[NonSerialized]
	public static float DefaultFontSize;

	internal static string[] z0krk;

	public static z0knk z0jrk;

	private static readonly Dictionary<string, string> z0hrk;

	private GraphicsUnit z0grk_jiejie20260327142557 = GraphicsUnit.Point;

	[z0ZzZzuqh]
	[DefaultValue(FontStyle.Regular)]
	public FontStyle Style
	{
		get
		{
			FontStyle fontStyle = FontStyle.Regular;
			if (z0xek)
			{
				fontStyle = FontStyle.Bold;
			}
			if (z0cek)
			{
				fontStyle |= FontStyle.Italic;
			}
			if (z0nek)
			{
				fontStyle |= FontStyle.Underline;
			}
			if (z0mek)
			{
				fontStyle |= FontStyle.Strikeout;
			}
			return fontStyle;
		}
		set
		{
			if (Style != value)
			{
				z0xek = z0eek(value, FontStyle.Bold);
				z0cek = z0eek(value, FontStyle.Italic);
				z0nek = z0eek(value, FontStyle.Underline);
				z0mek = z0eek(value, FontStyle.Strikeout);
				z0zek = null;
			}
		}
	}

	[DefaultValue(false)]
	public bool Bold
	{
		get
		{
			return z0xek;
		}
		set
		{
			if (z0xek != value)
			{
				z0xek = value;
				z0zek = null;
			}
		}
	}

	[DefaultValue(false)]
	public bool Underline
	{
		get
		{
			return z0nek;
		}
		set
		{
			if (z0nek != value)
			{
				z0nek = value;
				z0zek = null;
			}
		}
	}

	[DefaultValue(9f)]
	public float Size
	{
		get
		{
			return z0bek;
		}
		set
		{
			if (z0bek != value)
			{
				z0bek = value;
				if (z0bek <= 0f)
				{
					z0bek = DefaultFontSize;
				}
				z0zek = null;
			}
		}
	}

	[DefaultValue(false)]
	public bool Italic
	{
		get
		{
			return z0cek;
		}
		set
		{
			if (z0cek != value)
			{
				z0cek = value;
				z0zek = null;
			}
		}
	}

	[DefaultValue(false)]
	public bool Strikeout
	{
		get
		{
			return z0mek;
		}
		set
		{
			if (z0mek != value)
			{
				z0mek = value;
				z0zek = null;
			}
		}
	}

	[z0ZzZzhpk]
	public string Name
	{
		get
		{
			return z0pek;
		}
		set
		{
			if (z0pek != value)
			{
				z0pek = value;
				if (string.IsNullOrEmpty(z0pek))
				{
					z0pek = DefaultFontName;
				}
				else
				{
					z0pek = string.Intern(z0pek);
				}
				z0zek = null;
			}
		}
	}

	[z0ZzZzuqh]
	public z0ZzZzsdh Value
	{
		get
		{
			if (z0zek == null)
			{
				z0zek = new z0ZzZzsdh(z0eek(z0pek, p1: false), z0bek, Style, z0grk_jiejie20260327142557);
			}
			return z0zek;
		}
		set
		{
			if (value == null)
			{
				value = z0oek;
			}
			if (!z0eek(value))
			{
				z0pek = value.z0pek();
				z0bek = value.z0yek();
				z0xek = value.z0eek();
				z0cek = value.z0tek();
				z0nek = value.z0iek();
				z0mek = value.z0uek();
				z0grk_jiejie20260327142557 = value.z0rek();
				z0zek = value;
			}
		}
	}

	[DefaultValue(GraphicsUnit.Point)]
	public GraphicsUnit Unit
	{
		get
		{
			return z0grk_jiejie20260327142557;
		}
		set
		{
			z0grk_jiejie20260327142557 = value;
		}
	}

	public static z0ZzZzimk z0eek()
	{
		if (z0vek == null)
		{
			z0vek = new z0ZzZzimk(DefaultFontName, DefaultFontSize);
		}
		return z0vek;
	}

	public void z0eek(string p0)
	{
		if (string.IsNullOrEmpty(p0))
		{
			return;
		}
		string[] array = p0.Split(',');
		if (array.Length < 1)
		{
			throw new ArgumentException("必须符合 name,size,style=Bold,Italic,Underline,Strikeout 样式");
		}
		string name = array[0];
		float num = 9f;
		if (array.Length >= 2 && !float.TryParse(array[1].Trim(), out num))
		{
			num = 9f;
		}
		if (num <= 0f)
		{
			num = 1f;
		}
		FontStyle fontStyle = FontStyle.Regular;
		bool flag = false;
		for (int i = 2; i < array.Length; i++)
		{
			string text = array[i].Trim().ToLower();
			if (!flag && text.StartsWith("style"))
			{
				int num2 = text.IndexOf('=');
				if (num2 > 0)
				{
					flag = true;
					text = text.Substring(num2 + 1);
				}
			}
			if (flag)
			{
				if (Enum.IsDefined(typeof(FontStyle), text.Trim()))
				{
					FontStyle fontStyle2 = (FontStyle)Enum.Parse(typeof(FontStyle), text.Trim(), true);
					fontStyle |= fontStyle2;
				}
				else if (Enum.IsDefined(typeof(GraphicsUnit), text.Trim()))
				{
					z0grk_jiejie20260327142557 = (GraphicsUnit)Enum.Parse(typeof(GraphicsUnit), text.Trim(), true);
				}
			}
		}
		Name = name;
		Size = num;
		Style = fontStyle;
	}

	public static string z0eek(string p0, bool p1)
	{
		if (string.IsNullOrEmpty(p0))
		{
			if (p1)
			{
				throw new ArgumentNullException("name");
			}
			return DefaultFontName;
		}
		string result = null;
		if (z0hrk.TryGetValue(p0, out result))
		{
			return result;
		}
		if (p0.Contains('('))
		{
			int num = p0.IndexOf('(');
			int num2 = p0.IndexOf(')', num);
			if (num >= 0 && num2 > 0)
			{
				string text = p0.Substring(num, num2 - num).Trim();
				z0hrk[p0] = text;
				return text;
			}
		}
		return p0;
	}

	public static void z0rek()
	{
	}

	public static void z0eek(string p0, float p1)
	{
		z0oek = new z0ZzZzsdh(p0, p1);
		DefaultFontName = string.Intern(p0);
		DefaultFontSize = p1;
		z0vek = null;
	}

	public float GetHeight(z0ZzZzadh g)
	{
		z0ZzZzsdh value = Value;
		if (value == null)
		{
			return 0f;
		}
		try
		{
			return value.z0eek(g);
		}
		catch (Exception)
		{
			if (z0tek())
			{
				return z0eek(value, g);
			}
			throw;
		}
	}

	public z0ZzZzimk(string p0, float p1)
	{
		z0pek = p0;
		z0bek = p1;
	}

	public void Dispose()
	{
		z0zek = null;
		z0pek = null;
	}

	public static bool z0rek(string p0)
	{
		if (z0krk != null && z0krk.Length != 0)
		{
			for (int num = z0krk.Length - 1; num >= 0; num--)
			{
				if (string.Equals(z0krk[num], p0, StringComparison.OrdinalIgnoreCase))
				{
					return true;
				}
			}
		}
		if (z0lrk != null)
		{
			for (int num2 = z0lrk.Count - 2; num2 >= 0; num2 -= 2)
			{
				if (string.Equals(z0lrk[num2], p0, StringComparison.OrdinalIgnoreCase))
				{
					return true;
				}
			}
		}
		return false;
	}

	public z0ZzZzimk()
	{
	}

	private bool z0eek(FontStyle p0, FontStyle p1)
	{
		return (p0 & p1) == p1;
	}

	internal bool z0tek()
	{
		return false;
	}

	public override string ToString()
	{
		ArrayList arrayList = new ArrayList();
		arrayList.Add(Name);
		arrayList.Add(Size.ToString());
		if (Style != FontStyle.Regular)
		{
			arrayList.Add("style=" + Style.ToString("G"));
		}
		if (z0grk_jiejie20260327142557 != GraphicsUnit.Point)
		{
			arrayList.Add(z0grk_jiejie20260327142557.ToString("G"));
		}
		return string.Join(", ", (string[])arrayList.ToArray(typeof(string)));
	}

	public z0ZzZzsdh z0yek()
	{
		return new z0ZzZzsdh(z0pek, z0bek, Style, z0grk_jiejie20260327142557);
	}

	static z0ZzZzimk()
	{
		z0krk = null;
		z0lrk = null;
		z0vek = null;
		z0jrk = null;
		z0hrk = new Dictionary<string, string>();
		z0oek = null;
		DefaultFontName = null;
		DefaultFontSize = 9f;
		z0eek("宋体", 9f);
	}

	public z0ZzZzimk(string p0, float p1, FontStyle p2, GraphicsUnit p3)
	{
		z0pek = p0;
		z0bek = p1;
		Style = p2;
		Unit = p3;
	}

	private static float z0eek(z0ZzZzsdh p0, z0ZzZzadh p1)
	{
		return p0.z0eek(p1);
	}

	public override int GetHashCode()
	{
		return ToString().GetHashCode();
	}

	public string z0uek()
	{
		if (string.IsNullOrEmpty(z0pek))
		{
			return DefaultFontName;
		}
		return z0pek;
	}

	public z0ZzZzimk Clone()
	{
		return (z0ZzZzimk)MemberwiseClone();
	}

	public float GetHeight(GraphicsUnit unit)
	{
		return z0ZzZzrpk.z0eek(Value.z0nek(), GraphicsUnit.Point, unit);
	}

	public bool z0eek(z0ZzZzsdh p0)
	{
		if (p0 == null)
		{
			return false;
		}
		if (z0pek != p0.z0pek())
		{
			return false;
		}
		if (z0bek != p0.z0yek())
		{
			return false;
		}
		if (z0xek != p0.z0eek())
		{
			return false;
		}
		if (z0cek != p0.z0tek())
		{
			return false;
		}
		if (z0nek != p0.z0iek())
		{
			return false;
		}
		if (z0mek != p0.z0uek())
		{
			return false;
		}
		if (z0grk_jiejie20260327142557 != p0.z0rek())
		{
			return false;
		}
		return true;
	}

	public float z0eek(z0ZzZzjpk p0)
	{
		z0ZzZzsdh value = Value;
		if (value == null)
		{
			return 0f;
		}
		if (p0.z0lrk() != null)
		{
			return value.z0eek(p0.z0lrk());
		}
		if (p0.z0oek() != null)
		{
			return value.z0eek(p0.z0oek());
		}
		return value.z0oek();
	}

	public static void z0eek(string p0, string p1)
	{
		if (p0 == null || p0.Length == 0)
		{
			throw new ArgumentNullException("originalFontName");
		}
		if (!(p0 == p1))
		{
			if (p1 == null || p1.Length == 0)
			{
				throw new ArgumentNullException("runtimeFontName");
			}
			if (z0lrk == null)
			{
				z0lrk = new List<string>();
			}
			if (!z0lrk.Contains(p0))
			{
				z0lrk.Add(p0);
				z0lrk.Add(p1);
			}
		}
	}

	public z0ZzZzimk(z0ZzZzsdh p0, bool p1 = false)
	{
		if (p0 != null)
		{
			Name = p0.z0pek();
			Size = p0.z0yek();
			Style = p0.z0mek();
			Unit = p0.z0rek();
			if (p1)
			{
				z0zek = p0;
			}
		}
	}

	public bool z0eek(z0ZzZzimk p0)
	{
		if (p0 == null)
		{
			return false;
		}
		if (this == p0)
		{
			return true;
		}
		if (z0pek != p0.z0pek)
		{
			return false;
		}
		if (z0bek != p0.z0bek)
		{
			return false;
		}
		if (z0xek != p0.z0xek)
		{
			return false;
		}
		if (z0cek != p0.z0cek)
		{
			return false;
		}
		if (z0nek != p0.z0nek)
		{
			return false;
		}
		if (z0mek != p0.z0mek)
		{
			return false;
		}
		if (z0grk_jiejie20260327142557 != p0.z0grk_jiejie20260327142557)
		{
			return false;
		}
		return true;
	}

	public z0ZzZzimk(string p0, float p1, FontStyle p2)
	{
		z0pek = p0;
		z0bek = p1;
		Style = p2;
	}

	private object z0iek()
	{
		return MemberwiseClone();
	}

	object ICloneable.Clone()
	{
		//ILSpy generated this explicit interface implementation from .override directive in z0iek
		return this.z0iek();
	}

	public float GetHeight()
	{
		return Value?.z0oek() ?? 0f;
	}

	public static string z0tek(string p0)
	{
		if (p0 == DefaultFontName)
		{
			return DefaultFontName;
		}
		string[] array = z0krk;
		if (array != null && array.Length != 0)
		{
			for (int num = array.Length - 1; num >= 0; num--)
			{
				if (string.Equals(array[num], p0, StringComparison.OrdinalIgnoreCase))
				{
					return array[num];
				}
			}
		}
		if (z0lrk != null)
		{
			for (int num2 = z0lrk.Count - 2; num2 >= 0; num2 -= 2)
			{
				if (string.Equals(z0lrk[num2], p0, StringComparison.OrdinalIgnoreCase))
				{
					return z0lrk[num2 + 1];
				}
			}
		}
		return DefaultFontName;
	}

	public override bool Equals(object obj)
	{
		if (obj == this)
		{
			return true;
		}
		if (!(obj is z0ZzZzimk))
		{
			return false;
		}
		z0ZzZzimk z0ZzZzimk2 = (z0ZzZzimk)obj;
		if (z0ZzZzimk2.z0xek == z0xek && z0ZzZzimk2.z0cek == z0cek && z0ZzZzimk2.z0mek == z0mek && z0ZzZzimk2.z0nek == z0nek && z0ZzZzimk2.z0bek == z0bek && z0ZzZzimk2.z0pek == z0pek)
		{
			return z0ZzZzimk2.z0grk_jiejie20260327142557 == z0grk_jiejie20260327142557;
		}
		return false;
	}
}
