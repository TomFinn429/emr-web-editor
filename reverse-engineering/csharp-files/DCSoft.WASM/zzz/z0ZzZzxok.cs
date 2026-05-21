using System;

namespace zzz;

public class z0ZzZzxok : IDisposable
{
	protected z0ZzZzcok z0tek;

	private static readonly string z0yek = "FontSize";

	protected z0ZzZzzok z0uek = new z0ZzZzzok();

	[z0ZzZzrqh("Style", typeof(z0ZzZzcok))]
	[z0ZzZzuqh]
	public virtual z0ZzZzzok Styles
	{
		get
		{
			return z0uek;
		}
		set
		{
			z0uek = value;
			z0nn();
		}
	}

	[z0ZzZzyqh("Default", typeof(z0ZzZzcok))]
	public virtual z0ZzZzcok Default
	{
		get
		{
			return z0tek;
		}
		set
		{
			z0tek = value;
			z0nn();
		}
	}

	public int GetStyleIndexByString(string styleString)
	{
		z0ZzZzcok z0ZzZzcok2 = CreateStyleInstance();
		z0ZzZzsyk.z0eek(z0ZzZzcok2, styleString);
		return GetStyleIndex(z0ZzZzcok2);
	}

	public void HandleAfterLoad()
	{
		z0ZzZzcok obj = CreateStyleInstance();
		obj.FontSize = 9f;
		obj.FontName = z0ZzZzcok.z0byk;
		foreach (z0ZzZzcok item in Styles.z0xrk())
		{
			z0ZzZzvik.z0rek(Default, item, p2: false);
			if (!z0ZzZzvik.z0rek(item, z0yek))
			{
				item.FontSize = 9f;
			}
		}
		z0rek();
	}

	public z0ZzZzcok GetStyle(int styleIndex)
	{
		return z0uek.z0eek(styleIndex, z0tek);
	}

	public virtual void z0nn()
	{
		if (z0tek != null)
		{
			z0tek.z0rek(null);
		}
		using zzz.z0ZzZzkuk<z0ZzZzcok>.z0bpk z0bpk = Styles.z0ltk();
		while (z0bpk.MoveNext())
		{
			z0bpk.Current.z0rek(null);
		}
	}

	public z0ZzZzxok z0eek()
	{
		z0ZzZzxok z0ZzZzxok2 = (z0ZzZzxok)MemberwiseClone();
		z0ZzZzxok2.z0tek = z0tek.Clone();
		z0ZzZzxok2.z0uek = new z0ZzZzzok();
		foreach (z0ZzZzcok item in z0uek.z0xrk())
		{
			z0ZzZzxok2.z0uek.Add(item.Clone());
		}
		z0ZzZzxok2.z0nn();
		return z0ZzZzxok2;
	}

	public virtual z0ZzZzcok CreateStyleInstance()
	{
		return new z0ZzZzcok();
	}

	public void Clear()
	{
		z0tek = CreateStyleInstance();
		z0tek.FontName = z0ZzZzimk.DefaultFontName;
		z0tek.FontSize = z0ZzZzimk.DefaultFontSize;
		z0uek.Clear();
		z0bn();
	}

	public virtual void z0bn()
	{
	}

	public z0ZzZzxok()
	{
		z0tek = CreateStyleInstance();
	}

	public void z0rek()
	{
		z0tek.Index = -1;
		for (int i = 0; i < Styles.Count; i++)
		{
			Styles[i].Index = i;
		}
	}

	public virtual void Dispose()
	{
		if (z0tek != null)
		{
			z0tek.Dispose();
			z0tek = null;
		}
		if (z0uek == null)
		{
			return;
		}
		using (zzz.z0ZzZzkuk<z0ZzZzcok>.z0bpk z0bpk = z0uek.z0ltk())
		{
			while (z0bpk.MoveNext())
			{
				z0bpk.Current.Dispose();
			}
		}
		z0uek = null;
	}

	public z0ZzZzcok z0eek(int p0)
	{
		z0ZzZzcok style = GetStyle(p0);
		if (style == null || style == z0tek)
		{
			return z0tek;
		}
		return style;
	}

	public int GetStyleIndex(z0ZzZzcok style)
	{
		if (style == null || z0ZzZzvik.z0eek(style) == 0)
		{
			return -1;
		}
		if (style == z0tek || z0tek.z0tek(style))
		{
			return -1;
		}
		int num = Styles.z0eek(style);
		if (num < 0)
		{
			z0ZzZzcok z0ZzZzcok2 = style.Clone();
			if (z0ZzZzcok2.z0eek(Default) <= 0)
			{
				return -1;
			}
			z0ZzZzvik.z0rek(Default, z0ZzZzcok2, p2: false);
			num = Styles.z0eek(z0ZzZzcok2);
			if (num < 0)
			{
				Styles.Add(z0ZzZzcok2);
				z0ZzZzcok2.z0eek();
				num = Styles.Count - 1;
				Styles.z0eek();
			}
			z0nn();
			z0bn();
		}
		return num;
	}
}
