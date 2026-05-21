using System;
using System.Collections.Generic;
using System.Text;
using DCSoft.Chart;
using DCSystem_Drawing;

namespace zzz;

public class z0ZzZzbtk : ICloneable
{
	private static readonly string z0mek = "#3891a7;#feb80a;#c32d2e;#84aa33;#964305;#475a8d";

	private static readonly string z0nek = "#98c723;#59b0b9;#deae00;#b77bb4;#e0773c;#a98d63";

	private string z0bek;

	private List<z0ZzZzymk> z0vek = new List<z0ZzZzymk>();

	private static readonly string z0cek = "#ff388c;#e40059;#9c007f;#68007f;#005bd3;#00349e";

	private static readonly string z0xek = "#4e67c8;#5eccf3;#a7ea52;#5dceaf;#ff8021;#f14124";

	private ColorThemeType z0zek;

	private static readonly string z0lrk = "#31b6fd;#4584d3;#5bd078;#a5d028;#f5c040;#05e0db";

	private int z0krk = 1;

	private static readonly string z0jrk = "#50742f;#268868;#33bd56;#4bc5b9;#3163ca;#4b14aa";

	private static readonly string z0hrk = "#3294f7;#f7c916;#e25b00;#32CD32;#a17a9d;#54b2b2";

	private static readonly string z0grk = "#53548a;#438086;#a04da3;#c4652d;#8b5d3d;#5c92b5";

	private static readonly string z0frk = "#7fd13b;#ea157a;#feb80a;#00addc;#738ac8;#1ab39f";

	private float z0drk = 0.5f;

	private static readonly string z0srk = "#fda023;#aa2b1e;#71685c;#64a73b;#eb5605;#b9ca1a";

	public ColorThemeType z0rek()
	{
		return z0zek;
	}

	public static List<z0ZzZzymk> z0rek(string p0)
	{
		string[] array = p0.Trim().Split(';');
		List<z0ZzZzymk> list = new List<z0ZzZzymk>();
		for (int i = 0; i < array.Length; i++)
		{
			list.Add(new z0ZzZzymk(z0ZzZzifh.z0eek(array[i])));
		}
		return list;
	}

	public void z0rek(ColorThemeType p0)
	{
		z0zek = p0;
		switch (z0zek)
		{
		case ColorThemeType.Default:
			z0eek(z0rek(z0hrk));
			break;
		case ColorThemeType.Air:
			z0eek(z0rek(z0xek));
			break;
		case ColorThemeType.Through:
			z0eek(z0rek(z0frk));
			break;
		case ColorThemeType.Summer:
			z0eek(z0rek(z0mek));
			break;
		case ColorThemeType.Pin:
			z0eek(z0rek(z0srk));
			break;
		case ColorThemeType.Wave:
			z0eek(z0rek(z0lrk));
			break;
		case ColorThemeType.City:
			z0eek(z0rek(z0grk));
			break;
		case ColorThemeType.Compose:
			z0eek(z0rek(z0nek));
			break;
		case ColorThemeType.Energy:
			z0eek(z0rek(z0cek));
			break;
		case ColorThemeType.Dance:
			z0eek(z0rek(z0jrk));
			break;
		}
	}

	public void z0rek(float p0)
	{
		z0drk = p0;
	}

	public z0ZzZzbtk(ColorThemeType p0)
	{
		z0rek(p0);
	}

	public List<z0ZzZzymk> z0tek()
	{
		return z0vek;
	}

	public string z0yek()
	{
		StringBuilder stringBuilder = new StringBuilder();
		foreach (z0ZzZzymk item in z0tek())
		{
			if (stringBuilder.Length > 0)
			{
				stringBuilder.Append(';');
			}
			stringBuilder.Append('#').Append(item.Value.ToArgb().ToString("X6"));
		}
		return stringBuilder.ToString();
	}

	public float z0uek()
	{
		return z0drk;
	}

	public void z0rek(int p0)
	{
		z0krk = p0;
	}

	public z0ZzZzbtk()
	{
	}

	public void z0eek(List<z0ZzZzymk> p0)
	{
		z0vek = p0;
		if (z0vek == null)
		{
			z0vek = new List<z0ZzZzymk>();
		}
		StringBuilder stringBuilder = new StringBuilder();
		foreach (z0ZzZzymk item in z0vek)
		{
			stringBuilder.Append(item.Value.ToString()).Append(';');
		}
		if (stringBuilder.Length > 0)
		{
			stringBuilder.Length--;
		}
		z0bek = stringBuilder.ToString();
	}

	public void z0tek(string p0)
	{
		z0vek = new List<z0ZzZzymk>();
		if (p0 != null && p0.Length > 0)
		{
			z0vek = z0rek(p0);
		}
	}

	public Color z0tek(int p0)
	{
		if (z0tek() == null || z0tek().Count == 0)
		{
			return Color.Black;
		}
		p0 %= z0tek().Count * z0iek();
		int p1 = Math.Abs(p0 / z0tek().Count);
		p0 = Math.Abs(p0 % z0tek().Count);
		return z0ZzZzvok.z0eek(z0tek()[p0].Value, z0uek(), z0iek(), p1);
	}

	public int z0iek()
	{
		return z0krk;
	}

	private object z0oek()
	{
		z0ZzZzbtk z0ZzZzbtk2 = new z0ZzZzbtk();
		z0ZzZzbtk2.z0rek(z0rek());
		z0ZzZzbtk2.z0eek(new List<z0ZzZzymk>());
		if (z0tek() != null)
		{
			foreach (z0ZzZzymk item in z0tek())
			{
				z0ZzZzbtk2.z0tek().Add(item.Clone());
			}
		}
		z0ZzZzbtk2.z0rek(z0iek());
		return z0ZzZzbtk2;
	}

	object ICloneable.Clone()
	{
		//ILSpy generated this explicit interface implementation from .override directive in z0oek
		return this.z0oek();
	}

	public z0ZzZzbtk z0pek()
	{
		return (z0ZzZzbtk)((ICloneable)this).Clone();
	}
}
