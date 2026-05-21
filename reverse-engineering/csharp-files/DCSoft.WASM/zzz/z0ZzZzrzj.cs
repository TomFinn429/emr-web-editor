using System;
using System.Collections.Generic;
using DCSoft.Drawing;
using DCSoft.Writer;
using DCSoft.Writer.Dom;
using DCSystem_Drawing;
using DCSystem_Drawing.Drawing2D;

namespace zzz;

public class z0ZzZzrzj : IDisposable
{
	public readonly z0ZzZzimk z0pek;

	public readonly DashStyle z0mek;

	public readonly Color z0nek = Color.Black;

	public readonly Color z0bek = Color.Black;

	public readonly string z0vek;

	public readonly float z0cek;

	public readonly bool z0xek;

	public readonly float z0zek;

	public readonly bool z0lrk;

	public readonly int z0krk = Color.Black.ToArgb();

	public readonly DocumentContentStyle z0jrk;

	public readonly bool z0hrk = true;

	public readonly Color z0grk = Color.Black;

	public readonly int z0frk = Color.Black.ToArgb();

	internal string z0drk;

	public readonly VerticalAlignStyle z0srk;

	public readonly Color z0ark = Color.Transparent;

	public readonly bool z0qrk;

	public readonly bool z0wrk;

	public readonly float z0erk;

	public readonly bool z0rrk;

	public readonly Color z0trk = Color.Black;

	public readonly CharacterCircleStyles z0yrk;

	public readonly bool z0urk;

	public readonly float z0irk;

	internal DCBooleanValue z0ork = DCBooleanValue.Inherit;

	public readonly FontStyle z0prk;

	public readonly bool z0mrk;

	public readonly int z0nrk = -1;

	public readonly ParagraphListStyle z0brk;

	public readonly string z0vrk = z0ZzZzimk.z0tek(z0ZzZzimk.DefaultFontName);

	public readonly Color z0crk = Color.Empty;

	public readonly float z0xrk;

	public readonly Color z0zrk = Color.Black;

	public readonly TextUnderlineStyle z0ltk = TextUnderlineStyle.Single;

	internal string z0ktk;

	public readonly bool z0jtk;

	public readonly bool z0htk;

	public readonly bool z0gtk;

	public readonly int z0ftk = Color.Black.ToArgb();

	public readonly bool z0dtk;

	public readonly float z0stk;

	public readonly ContentGridLineType z0atk;

	public readonly z0ZzZzumk z0qtk;

	public readonly float z0wtk = z0ZzZzimk.DefaultFontSize;

	public readonly bool z0etk;

	public readonly Color z0rtk = Color.Black;

	public readonly int z0ttk = -1;

	public float z0ytk;

	public readonly bool z0utk;

	public readonly float z0itk;

	public readonly ContentProtectType z0otk;

	public readonly float z0ptk;

	public readonly float z0mtk;

	private static readonly z0ZzZzsdh z0ntk = new z0ZzZzsdh("宋体", 12f);

	public readonly z0ZzZzsdh z0btk;

	public readonly bool z0vtk_jiejie20260327142557;

	public readonly int z0ctk = Color.Black.ToArgb();

	public Color z0xtk = Color.Empty;

	public readonly Color z0ztk = Color.Transparent;

	public readonly float z0lyk;

	public readonly int z0kyk = Color.Black.ToArgb();

	public readonly int z0jyk = -1;

	public readonly float z0hyk;

	public readonly bool z0gyk;

	public readonly bool z0fyk;

	public readonly RenderVisibility z0dyk = RenderVisibility.All;

	public readonly bool z0syk = true;

	public readonly Color z0ayk = Color.Black;

	public readonly float z0qyk;

	public readonly bool z0wyk;

	public readonly float z0eyk;

	public readonly float z0ryk;

	public readonly string z0tyk = z0ZzZzimk.DefaultFontName;

	public readonly bool z0yyk;

	public readonly bool z0uyk;

	public readonly bool z0iyk;

	public readonly float z0oyk_jiejie20260327142557;

	public readonly float z0pyk;

	public readonly Color z0myk = Color.Black;

	public readonly Color z0nyk = Color.Transparent;

	public readonly float z0byk;

	public readonly int z0vyk = -1;

	public readonly LineSpacingStyle z0cyk;

	public readonly ContentLayoutAlign z0xyk;

	public readonly float z0zyk;

	internal z0ZzZzlcj.z0uhj z0luk;

	public readonly bool z0kuk;

	public readonly bool z0juk = true;

	public readonly Color z0huk = Color.Black;

	public readonly DashStyle z0guk;

	public readonly int z0fuk = Color.Black.ToArgb();

	public readonly bool z0duk;

	public readonly float z0suk;

	public readonly int z0auk = -1;

	public readonly float z0quk;

	public readonly bool z0wuk;

	public readonly bool z0euk;

	public readonly bool z0ruk;

	public readonly DocumentContentAlignment z0tuk;

	public readonly z0ZzZznwh z0yuk;

	public static void z0eek(z0ZzZzjpk p0, z0ZzZzbdh p1, bool p2, Color p3, float p4, DashStyle p5, bool p6, Color p7, float p8, DashStyle p9, bool p10, Color p11, float p12, DashStyle p13, bool p14, Color p15, float p16, DashStyle p17)
	{
		if (p3 == p7 && p7 == p11 && p11 == p15 && p4 == p8 && p8 == p12 && p12 == p16 && p5 == p9 && p9 == p13 && p13 == p17 && p2 && p6 && p10 && p14)
		{
			if (p3.A != 0 && p4 > 0f)
			{
				using (z0ZzZzudh p18 = z0ZzZzdpk.z0eek(p3, p4, p5))
				{
					p0.z0eek(p18, p1.z0oek(), p1.z0pek(), p1.z0uek(), p1.z0iek(), 0f);
					return;
				}
			}
			return;
		}
		if (p2 && p3.A != 0 && p4 > 0f)
		{
			using z0ZzZzudh z0ZzZzudh2 = new z0ZzZzudh(p3, p4);
			z0ZzZzudh2.z0eek(p5);
			p0.z0eek(z0ZzZzudh2, p1.z0oek(), p1.z0pek(), p1.z0oek(), p1.z0nek());
		}
		if (p6 && p7.A != 0 && p8 > 0f)
		{
			z0ZzZzudh z0ZzZzudh3 = new z0ZzZzudh(p7, p8);
			z0ZzZzudh3.z0eek(p9);
			p0.z0eek(z0ZzZzudh3, p1.z0oek(), p1.z0pek(), p1.z0mek(), p1.z0pek());
			z0ZzZzudh3.Dispose();
		}
		if (p10 && p11.A != 0 && p12 > 0f)
		{
			z0ZzZzudh z0ZzZzudh4 = new z0ZzZzudh(p11, p12);
			z0ZzZzudh4.z0eek(p13);
			p0.z0eek(z0ZzZzudh4, p1.z0mek(), p1.z0pek(), p1.z0mek(), p1.z0nek());
			z0ZzZzudh4.Dispose();
		}
		if (p14 && p15.A != 0 && p16 > 0f)
		{
			z0ZzZzudh z0ZzZzudh5 = new z0ZzZzudh(p15, p16);
			z0ZzZzudh5.z0eek(p17);
			p0.z0eek(z0ZzZzudh5, p1.z0oek(), p1.z0nek(), p1.z0mek(), p1.z0nek());
			z0ZzZzudh5.Dispose();
		}
	}

	public float z0eek(z0ZzZzjpk p0)
	{
		if (z0ytk == 0f)
		{
			z0rek(z0ZzZzlcj.z0rek(p0, this));
		}
		return z0ytk;
	}

	public z0ZzZzudh z0eek()
	{
		z0ZzZzudh obj = new z0ZzZzudh(z0myk, z0erk);
		obj.z0eek(z0guk);
		return obj;
	}

	internal z0ZzZzrzj(z0ZzZzrzj p0, string p1, float p2, Color p3)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("rs");
		}
		z0kyk = p0.z0kyk;
		z0fuk = p0.z0fuk;
		z0krk = p0.z0krk;
		z0ftk = p0.z0ftk;
		z0frk = p0.z0frk;
		z0ctk = p0.z0ctk;
		z0juk = p0.z0juk;
		z0hrk = p0.z0hrk;
		z0htk = p0.z0htk;
		z0tuk = p0.z0tuk;
		z0ark = p0.z0ark;
		z0ayk = p0.z0ayk;
		z0gyk = p0.z0gyk;
		z0mrk = p0.z0mrk;
		z0trk = p0.z0trk;
		z0rtk = p0.z0rtk;
		z0rrk = p0.z0rrk;
		z0nek = p0.z0nek;
		z0etk = p0.z0etk;
		z0grk = p0.z0grk;
		z0lyk = p0.z0lyk;
		z0guk = p0.z0guk;
		z0wyk = p0.z0wyk;
		z0myk = p0.z0myk;
		z0erk = p0.z0erk;
		z0vek = p0.z0vek;
		z0yrk = p0.z0yrk;
		z0bek = p0.z0bek;
		z0xtk = p0.z0xtk;
		z0vyk = p0.z0vyk;
		z0nrk = p0.z0nrk;
		z0yuk = p0.z0yuk;
		z0qyk = p0.z0qyk;
		z0jyk = p0.z0jyk;
		z0iyk = p0.z0iyk;
		z0pyk = p0.z0pyk;
		z0wuk = p0.z0wuk;
		z0pek = p0.z0pek;
		z0qtk = p0.z0qtk;
		z0rek(p0.z0ytk);
		z0tyk = p0.z0tyk;
		z0vrk = p0.z0vrk;
		z0wtk = p0.z0wtk;
		z0prk = p0.z0prk;
		z0btk = new z0ZzZzsdh(z0vrk, z0wtk, z0prk, GraphicsUnit.Point);
		z0zrk = p0.z0zrk;
		z0eyk = p0.z0eyk;
		z0mek = p0.z0mek;
		z0atk = p0.z0atk;
		z0utk = p0.z0utk;
		z0urk = p0.z0urk;
		z0lrk = p0.z0lrk;
		z0duk = p0.z0duk;
		z0wrk = p0.z0wrk;
		z0xek = p0.z0xek;
		z0kuk = p0.z0kuk;
		z0ruk = p0.z0ruk;
		z0vtk_jiejie20260327142557 = p0.z0vtk_jiejie20260327142557;
		z0xyk = p0.z0xyk;
		z0hyk = p0.z0hyk;
		z0mtk = p0.z0mtk;
		z0itk = p0.z0itk;
		z0cyk = p0.z0cyk;
		z0jtk = p0.z0jtk;
		z0xrk = p0.z0xrk;
		z0ryk = p0.z0ryk;
		z0ptk = p0.z0ptk;
		z0quk = p0.z0quk;
		z0brk = p0.z0brk;
		z0fyk = p0.z0fyk;
		z0ttk = p0.z0ttk;
		z0crk = p0.z0crk;
		z0dtk = p0.z0dtk;
		z0ztk = p0.z0ztk;
		z0otk = p0.z0otk;
		z0qrk = p0.z0qrk;
		z0oyk_jiejie20260327142557 = p0.z0oyk_jiejie20260327142557;
		z0nyk = p0.z0nyk;
		z0zyk = p0.z0zyk;
		z0irk = p0.z0irk;
		z0cek = p0.z0cek;
		z0yyk = p0.z0yyk;
		z0gtk = p0.z0gtk;
		z0euk = p0.z0euk;
		z0auk = p0.z0auk;
		z0uyk = p0.z0uyk;
		z0huk = p0.z0huk;
		z0ltk = p0.z0ltk;
		z0srk = p0.z0srk;
		z0dyk = p0.z0dyk;
		z0syk = p0.z0syk;
		z0bek = p3;
		z0ctk = p3.ToArgb();
		z0tyk = p1;
		z0wtk = p2;
		z0pek = new z0ZzZzimk(p1, p2, p0.z0prk);
	}

	public void Dispose()
	{
		z0ktk = null;
		z0drk = null;
	}

	internal z0ZzZzimk z0eek(float p0)
	{
		z0ZzZzimk z0ZzZzimk2 = z0pek;
		if (p0 != 1f)
		{
			z0ZzZzimk2 = z0ZzZzimk2.Clone();
			z0ZzZzimk2.Size *= p0;
		}
		return z0ZzZzimk2;
	}

	public DocumentContentStyle z0rek()
	{
		return z0jrk.z0uek();
	}

	public bool z0tek()
	{
		if (!z0etk)
		{
			return false;
		}
		if (z0erk <= 0f)
		{
			return false;
		}
		if (z0myk.A == 0)
		{
			return false;
		}
		return true;
	}

	public float z0eek(float p0, float p1, GraphicsUnit p2)
	{
		LineSpacingStyle lineSpacingStyle = z0cyk;
		if (lineSpacingStyle == LineSpacingStyle.SpaceSpecify)
		{
			return z0itk;
		}
		if (lineSpacingStyle == LineSpacingStyle.SpaceSpecify)
		{
			return p0 + p1 * 0.1f;
		}
		float result = 0f;
		switch (lineSpacingStyle)
		{
		case LineSpacingStyle.SpaceSingle:
			result = p0 + p1 * 0.1f;
			break;
		case LineSpacingStyle.Space1pt5:
			result = p0 + p1 * 0.6f;
			break;
		case LineSpacingStyle.SpaceDouble:
			result = p0 + p1 * 1.1f;
			break;
		case LineSpacingStyle.SpaceMultiple:
			result = p0 + p1 * (z0itk - 1f + 0.1f);
			break;
		case LineSpacingStyle.SpaceExactly:
			result = Math.Max(p0, p1);
			break;
		}
		return result;
	}

	public DocumentContentStyle z0yek()
	{
		return (DocumentContentStyle)z0jrk.Clone();
	}

	public bool z0uek()
	{
		if (!z0mrk)
		{
			return false;
		}
		if (z0erk <= 0f)
		{
			return false;
		}
		if (z0myk.A == 0)
		{
			return false;
		}
		return true;
	}

	public string z0eek(int p0)
	{
		return z0ZzZzlmk.z0rek(p0, z0brk);
	}

	internal z0ZzZzrzj(DocumentContentStyle p0)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("style");
		}
		z0jrk = p0;
		if (p0.z0xek != null)
		{
			z0ZzZzrzj z0ZzZzrzj2 = p0.z0xek;
			z0kyk = z0ZzZzrzj2.z0kyk;
			z0fuk = z0ZzZzrzj2.z0fuk;
			z0krk = z0ZzZzrzj2.z0krk;
			z0ftk = z0ZzZzrzj2.z0ftk;
			z0frk = z0ZzZzrzj2.z0frk;
			z0ctk = z0ZzZzrzj2.z0ctk;
			z0juk = z0ZzZzrzj2.z0juk;
			z0hrk = z0ZzZzrzj2.z0hrk;
			z0htk = z0ZzZzrzj2.z0htk;
			z0tuk = z0ZzZzrzj2.z0tuk;
			z0ark = z0ZzZzrzj2.z0ark;
			z0ayk = z0ZzZzrzj2.z0ayk;
			z0gyk = z0ZzZzrzj2.z0gyk;
			z0mrk = z0ZzZzrzj2.z0mrk;
			z0trk = z0ZzZzrzj2.z0trk;
			z0rtk = z0ZzZzrzj2.z0rtk;
			z0rrk = z0ZzZzrzj2.z0rrk;
			z0nek = z0ZzZzrzj2.z0nek;
			z0etk = z0ZzZzrzj2.z0etk;
			z0grk = z0ZzZzrzj2.z0grk;
			z0lyk = z0ZzZzrzj2.z0lyk;
			z0guk = z0ZzZzrzj2.z0guk;
			z0wyk = z0ZzZzrzj2.z0wyk;
			z0myk = z0ZzZzrzj2.z0myk;
			z0erk = z0ZzZzrzj2.z0erk;
			z0vek = z0ZzZzrzj2.z0vek;
			z0yrk = z0ZzZzrzj2.z0yrk;
			z0bek = z0ZzZzrzj2.z0bek;
			z0xtk = z0ZzZzrzj2.z0xtk;
			z0vyk = z0ZzZzrzj2.z0vyk;
			z0nrk = z0ZzZzrzj2.z0nrk;
			z0yuk = z0ZzZzrzj2.z0yuk;
			z0qyk = z0ZzZzrzj2.z0qyk;
			z0jyk = z0ZzZzrzj2.z0jyk;
			z0iyk = z0ZzZzrzj2.z0iyk;
			z0pyk = z0ZzZzrzj2.z0pyk;
			z0wuk = z0ZzZzrzj2.z0wuk;
			z0pek = z0ZzZzrzj2.z0pek;
			z0qtk = z0ZzZzrzj2.z0qtk;
			z0rek(z0ZzZzrzj2.z0ytk);
			z0tyk = z0ZzZzimk.z0eek(z0ZzZzrzj2.z0tyk, p1: false);
			z0vrk = z0ZzZzrzj2.z0vrk;
			z0wtk = z0ZzZzrzj2.z0wtk;
			z0prk = z0ZzZzrzj2.z0prk;
			z0btk = z0ZzZzrzj2.z0btk;
			z0zrk = z0ZzZzrzj2.z0zrk;
			z0eyk = z0ZzZzrzj2.z0eyk;
			z0mek = z0ZzZzrzj2.z0mek;
			z0atk = z0ZzZzrzj2.z0atk;
			z0utk = z0ZzZzrzj2.z0utk;
			z0urk = z0ZzZzrzj2.z0urk;
			z0lrk = z0ZzZzrzj2.z0lrk;
			z0duk = z0ZzZzrzj2.z0duk;
			z0wrk = z0ZzZzrzj2.z0wrk;
			z0xek = z0ZzZzrzj2.z0xek;
			z0kuk = z0ZzZzrzj2.z0kuk;
			z0ruk = z0ZzZzrzj2.z0ruk;
			z0vtk_jiejie20260327142557 = z0ZzZzrzj2.z0vtk_jiejie20260327142557;
			z0xyk = z0ZzZzrzj2.z0xyk;
			z0hyk = z0ZzZzrzj2.z0hyk;
			z0mtk = z0ZzZzrzj2.z0mtk;
			z0itk = z0ZzZzrzj2.z0itk;
			z0cyk = z0ZzZzrzj2.z0cyk;
			z0suk = z0ZzZzrzj2.z0suk;
			z0stk = z0ZzZzrzj2.z0stk;
			z0zek = z0ZzZzrzj2.z0zek;
			z0byk = z0ZzZzrzj2.z0byk;
			z0jtk = z0ZzZzrzj2.z0jtk;
			z0xrk = z0ZzZzrzj2.z0xrk;
			z0ryk = z0ZzZzrzj2.z0ryk;
			z0ptk = z0ZzZzrzj2.z0ptk;
			z0quk = z0ZzZzrzj2.z0quk;
			z0brk = z0ZzZzrzj2.z0brk;
			z0fyk = z0ZzZzrzj2.z0fyk;
			z0ttk = z0ZzZzrzj2.z0ttk;
			z0crk = z0ZzZzrzj2.z0crk;
			z0dtk = z0ZzZzrzj2.z0dtk;
			z0ztk = z0ZzZzrzj2.z0ztk;
			z0dtk = z0ZzZzrzj2.z0dtk;
			z0otk = z0ZzZzrzj2.z0otk;
			z0qrk = z0ZzZzrzj2.z0qrk;
			z0oyk_jiejie20260327142557 = z0ZzZzrzj2.z0oyk_jiejie20260327142557;
			z0nyk = z0ZzZzrzj2.z0nyk;
			z0zyk = z0ZzZzrzj2.z0zyk;
			z0irk = z0ZzZzrzj2.z0irk;
			z0cek = z0ZzZzrzj2.z0cek;
			z0yyk = z0ZzZzrzj2.z0yyk;
			z0gtk = z0ZzZzrzj2.z0gtk;
			z0euk = z0ZzZzrzj2.z0euk;
			z0auk = z0ZzZzrzj2.z0auk;
			z0uyk = z0ZzZzrzj2.z0uyk;
			z0huk = z0ZzZzrzj2.z0huk;
			z0ltk = z0ZzZzrzj2.z0ltk;
			z0srk = z0ZzZzrzj2.z0srk;
			z0dyk = z0ZzZzrzj2.z0dyk;
			z0syk = z0ZzZzrzj2.z0syk;
			return;
		}
		bool flag = z0ZzZzccj.z0rek(61);
		foreach (KeyValuePair<z0ZzZzcik, object> item in p0.z0nek())
		{
			switch (item.Key.z0eek())
			{
			case 1:
				z0tuk = (DocumentContentAlignment)item.Value;
				break;
			case 2:
				if (z0ZzZzccj.z0rek(63))
				{
					z0ark = (Color)item.Value;
					z0utk = true;
				}
				break;
			case 3:
				if (z0ZzZzccj.z0rek(63))
				{
					z0ayk = (Color)item.Value;
				}
				break;
			case 10:
				if (flag)
				{
					z0gyk = (bool)item.Value;
					if (z0gyk)
					{
						z0prk |= FontStyle.Bold;
					}
				}
				break;
			case 11:
				z0mrk = (bool)item.Value;
				break;
			case 12:
				z0trk = (Color)item.Value;
				break;
			case 13:
				z0rrk = (bool)item.Value;
				break;
			case 14:
				z0nek = (Color)item.Value;
				z0rtk = z0nek;
				break;
			case 15:
				z0etk = (bool)item.Value;
				break;
			case 16:
				z0grk = (Color)item.Value;
				break;
			case 17:
				z0lyk = (float)item.Value;
				break;
			case 18:
				z0guk = (DashStyle)item.Value;
				break;
			case 19:
				z0wyk = (bool)item.Value;
				break;
			case 20:
				z0myk = (Color)item.Value;
				break;
			case 21:
				z0erk = (float)item.Value;
				break;
			case 22:
				if (z0ZzZzccj.z0rek(66))
				{
					z0yrk = (CharacterCircleStyles)item.Value;
				}
				break;
			case 23:
				if (z0ZzZzccj.z0rek(62))
				{
					z0urk = true;
					z0bek = (Color)item.Value;
				}
				else
				{
					z0bek = Color.Black;
				}
				z0huk = z0bek;
				break;
			case 24:
				if (z0ZzZzccj.z0rek(149))
				{
					z0vyk = (int)item.Value;
				}
				break;
			case 25:
				if (z0ZzZzccj.z0rek(134))
				{
					z0nrk = (int)item.Value;
				}
				break;
			case 26:
			{
				string text = (string)item.Value;
				if (text != null && text.Length > 0)
				{
					switch (text.Trim().ToLower())
					{
					case "appstarting":
						z0yuk = z0ZzZzbwh.z0nek;
						break;
					case "arrow":
						z0yuk = z0ZzZzbwh.z0krk;
						break;
					case "cross":
						z0yuk = z0ZzZzbwh.z0grk;
						break;
					case "hand":
						z0yuk = z0ZzZzbwh.z0ark;
						break;
					case "help":
						z0yuk = z0ZzZzbwh.z0yek;
						break;
					case "hsplit":
						z0yuk = z0ZzZzbwh.z0xek;
						break;
					case "ibeam":
						z0yuk = z0ZzZzbwh.z0qrk;
						break;
					case "no":
						z0yuk = z0ZzZzbwh.z0cek;
						break;
					case "nomove2d":
						z0yuk = z0ZzZzbwh.z0erk;
						break;
					case "nomovehoriz":
						z0yuk = z0ZzZzbwh.z0jrk;
						break;
					case "nomovevert":
						z0yuk = z0ZzZzbwh.z0frk;
						break;
					case "paneast":
						z0yuk = z0ZzZzbwh.z0iek;
						break;
					case "panne":
						z0yuk = z0ZzZzbwh.z0eek;
						break;
					case "pannorth":
						z0yuk = z0ZzZzbwh.z0zek;
						break;
					case "pannw":
						z0yuk = z0ZzZzbwh.z0lrk;
						break;
					case "panse":
						z0yuk = z0ZzZzbwh.z0bek;
						break;
					case "pansouth":
						z0yuk = z0ZzZzbwh.z0pek;
						break;
					case "pansw":
						z0yuk = z0ZzZzbwh.z0rrk;
						break;
					case "panwest":
						z0yuk = z0ZzZzbwh.z0rek_jiejie20260327142557;
						break;
					case "sizeall":
						z0yuk = z0ZzZzbwh.z0oek;
						break;
					case "sizenesw":
						z0yuk = z0ZzZzbwh.z0hrk;
						break;
					case "sizens":
						z0yuk = z0ZzZzbwh.z0tek;
						break;
					case "sizenwse":
						z0yuk = z0ZzZzbwh.z0wrk;
						break;
					case "sizewe":
						z0yuk = z0ZzZzbwh.z0mek;
						break;
					case "uparrow":
						z0yuk = z0ZzZzbwh.z0drk;
						break;
					case "vsplit":
						z0yuk = z0ZzZzbwh.z0srk;
						break;
					case "waitcursor":
						z0yuk = z0ZzZzbwh.z0uek;
						break;
					}
				}
				break;
			}
			case 27:
				if (z0ZzZzccj.z0rek(134))
				{
					z0jyk = (int)item.Value;
				}
				break;
			case 28:
				if (flag && z0ZzZzccj.z0rek(65))
				{
					z0iyk = (bool)item.Value;
				}
				break;
			case 29:
				if (z0ZzZzccj.z0rek(79))
				{
					z0pyk = (float)item.Value;
				}
				break;
			case 30:
				z0wuk = (bool)item.Value;
				break;
			case 31:
				if (flag)
				{
					z0tyk = (string)item.Value;
					z0vrk = z0ZzZzimk.z0tek(z0tyk);
				}
				break;
			case 32:
				if (flag && z0ZzZzccj.z0rek(60))
				{
					z0wtk = (float)item.Value;
					if (z0wtk <= 0f)
					{
						z0wtk = 1f;
					}
				}
				break;
			case 33:
				z0zrk = (Color)item.Value;
				break;
			case 34:
				z0eyk = (float)item.Value;
				break;
			case 35:
				z0mek = (DashStyle)item.Value;
				break;
			case 36:
				z0atk = (ContentGridLineType)item.Value;
				break;
			case 38:
				if (flag)
				{
					z0vtk_jiejie20260327142557 = (bool)item.Value;
					if (z0vtk_jiejie20260327142557)
					{
						z0prk |= FontStyle.Italic;
					}
				}
				break;
			case 39:
				z0xyk = (ContentLayoutAlign)item.Value;
				if (z0xyk == ContentLayoutAlign.Surroundings && !z0ZzZzccj.z0rek(73))
				{
					z0xyk = ContentLayoutAlign.EmbedInText;
				}
				break;
			case 43:
				z0hyk = (float)item.Value;
				break;
			case 44:
				z0mtk = (float)item.Value;
				break;
			case 45:
				if (z0ZzZzccj.z0rek(80))
				{
					z0itk = (float)item.Value;
				}
				break;
			case 46:
				if (z0ZzZzccj.z0rek(80))
				{
					z0cyk = (LineSpacingStyle)item.Value;
				}
				break;
			case 48:
				z0suk = (float)item.Value;
				break;
			case 49:
				z0stk = (float)item.Value;
				break;
			case 50:
				z0zek = (float)item.Value;
				break;
			case 51:
				z0byk = (float)item.Value;
				break;
			case 52:
				z0jtk = (bool)item.Value;
				break;
			case 54:
				z0xrk = (float)item.Value;
				break;
			case 55:
				z0ryk = (float)item.Value;
				break;
			case 56:
				z0ptk = (float)item.Value;
				break;
			case 57:
				z0quk = (float)item.Value;
				break;
			case 60:
			{
				ParagraphListStyle paragraphListStyle = (ParagraphListStyle)item.Value;
				if (z0ZzZzlmk.z0eek(paragraphListStyle))
				{
					if (z0ZzZzccj.z0rek(82))
					{
						z0kuk = true;
						if (paragraphListStyle != ParagraphListStyle.BulletedList && !z0ZzZzccj.z0rek(83))
						{
							paragraphListStyle = ParagraphListStyle.BulletedList;
						}
					}
					else
					{
						z0kuk = false;
						paragraphListStyle = ParagraphListStyle.None;
					}
				}
				else if (z0ZzZzlmk.z0tek(paragraphListStyle))
				{
					if (z0ZzZzccj.z0rek(81))
					{
						z0ruk = p0.IsListNumberStyle;
						if (paragraphListStyle != ParagraphListStyle.ListNumberStyle && !z0ZzZzccj.z0rek(83))
						{
							paragraphListStyle = ParagraphListStyle.ListNumberStyle;
						}
					}
					else
					{
						z0ruk = false;
						paragraphListStyle = ParagraphListStyle.None;
					}
				}
				z0brk = paragraphListStyle;
				z0vek = z0ZzZzlmk.z0rek(paragraphListStyle);
				break;
			}
			case 61:
				z0fyk = (bool)item.Value;
				break;
			case 62:
				z0ttk = (int)item.Value;
				break;
			case 63:
				z0crk = (Color)item.Value;
				z0dtk = z0crk.A > 0;
				break;
			case 64:
				z0ztk = (Color)item.Value;
				break;
			case 65:
				if (z0ZzZzccj.z0rek(135))
				{
					z0otk = (ContentProtectType)item.Value;
				}
				break;
			case 66:
				z0qrk = (bool)item.Value;
				break;
			case 69:
				z0oyk_jiejie20260327142557 = (float)item.Value;
				break;
			case 71:
				if (z0ZzZzccj.z0rek(78))
				{
					z0zyk = (float)item.Value;
				}
				break;
			case 72:
				if (z0ZzZzccj.z0rek(78))
				{
					z0irk = (float)item.Value;
				}
				break;
			case 73:
				z0cek = (float)item.Value;
				break;
			case 74:
				if (flag)
				{
					z0yyk = (bool)item.Value;
					if (z0yyk)
					{
						z0prk |= FontStyle.Strikeout;
					}
				}
				break;
			case 75:
				if (flag && z0ZzZzccj.z0rek(64))
				{
					z0gtk = (bool)item.Value;
				}
				break;
			case 76:
				if (flag && z0ZzZzccj.z0rek(64))
				{
					z0euk = (bool)item.Value;
				}
				break;
			case 77:
				if (z0ZzZzccj.z0rek(85))
				{
					z0auk = (int)item.Value;
				}
				break;
			case 79:
				if (flag)
				{
					z0uyk = (bool)item.Value;
					if (z0uyk)
					{
						z0prk |= FontStyle.Underline;
					}
				}
				break;
			case 80:
				if (flag)
				{
					z0huk = z0ZzZzlok.z0eek((string)item.Value, p0.Color);
				}
				break;
			case 81:
				if (flag)
				{
					z0ltk = (TextUnderlineStyle)item.Value;
				}
				break;
			case 83:
				z0srk = (VerticalAlignStyle)item.Value;
				break;
			case 84:
				z0dyk = (RenderVisibility)item.Value;
				break;
			case 86:
				z0syk = (bool)item.Value;
				break;
			}
			if (z0vrk == "宋体" && z0wtk == 12f && z0prk == FontStyle.Regular)
			{
				z0btk = z0ntk;
			}
			else
			{
				z0btk = new z0ZzZzsdh(z0vrk, z0wtk, z0prk, GraphicsUnit.Point);
			}
		}
		z0rek(p0.z0iek());
		if (z0erk > 0f && (z0rrk || z0wyk || z0etk || z0mrk) && (z0myk.A != 0 || z0nek.A != 0 || z0grk.A != 0 || z0trk.A != 0))
		{
			z0wrk = true;
		}
		if (z0mrk && z0trk.A != 0 && z0erk > 0f)
		{
			z0xek = true;
		}
		z0duk = z0ark.A != 0;
		z0qtk = new z0ZzZzumk(z0vrk, z0wtk, z0prk, GraphicsUnit.Point);
		z0pek = new z0ZzZzimk(z0vrk, z0wtk, z0prk, GraphicsUnit.Point);
		if (z0ztk.A == 0)
		{
			z0nyk = z0bek;
		}
		else
		{
			z0nyk = z0ztk;
		}
		z0lrk = z0rrk && z0wyk && z0etk && z0mrk;
		z0ctk = z0bek.ToArgb();
		z0kyk = z0trk.ToArgb();
		z0fuk = z0rtk.ToArgb();
		z0krk = z0nek.ToArgb();
		z0ftk = z0grk.ToArgb();
		z0frk = z0myk.ToArgb();
		z0hrk = z0nek == z0myk && z0myk == z0grk && z0grk == z0trk;
		z0juk = z0nek == z0myk && z0myk == z0grk && z0grk == z0trk && z0rrk == z0wyk && z0wyk == z0etk && z0etk == z0mrk;
		z0htk = z0rrk && z0wyk && z0etk && z0mrk && z0erk > 0f && z0nek.A > 0 && z0nek == z0myk && z0myk == z0grk && z0grk == z0trk;
	}

	internal void z0rek(float p0)
	{
		_ = 0f;
		z0ytk = p0;
	}

	public void z0eek(z0ZzZzjpk p0, z0ZzZzbdh p1)
	{
		float num = z0erk;
		DashStyle dashStyle = z0guk;
		z0eek(p0, p1, z0rrk, z0nek, num, dashStyle, z0wyk, z0myk, num, dashStyle, z0etk, z0grk, num, dashStyle, z0mrk, z0trk, num, dashStyle);
	}

	public z0ZzZzbdh z0eek(z0ZzZzbdh p0)
	{
		return new z0ZzZzbdh(p0.z0oek() + z0ryk, p0.z0pek() + z0quk, p0.z0uek() - z0ryk - z0ptk, p0.z0iek() - z0quk - z0xrk);
	}

	public bool z0iek()
	{
		if (!z0wyk)
		{
			return false;
		}
		if (z0erk <= 0f)
		{
			return false;
		}
		if (z0myk.A == 0)
		{
			return false;
		}
		return true;
	}

	public bool z0eek(z0ZzZzrzj p0)
	{
		if (p0 == null)
		{
			return false;
		}
		if (p0 == this)
		{
			return true;
		}
		if (p0.z0rrk == z0rrk && p0.z0wyk == z0wyk && p0.z0etk == z0etk && p0.z0mrk == z0mrk && p0.z0nek == z0nek && p0.z0myk == z0myk && p0.z0grk == z0grk && p0.z0trk == z0trk && p0.z0erk == z0erk && p0.z0guk == z0guk)
		{
			return true;
		}
		return false;
	}

	public bool z0oek()
	{
		if (!z0rrk)
		{
			return false;
		}
		if (z0erk <= 0f)
		{
			return false;
		}
		if (z0myk.A == 0)
		{
			return false;
		}
		return true;
	}
}
