using System;
using System.Collections.Generic;
using System.ComponentModel;
using DCSoft.Drawing;
using DCSystem_Drawing;
using DCSystem_Drawing.Drawing2D;

namespace zzz;

public class z0ZzZzcok : z0ZzZzvik, IDisposable
{
	private static readonly z0ZzZzcik z0pek = z0ZzZzcik.z0eek(15, "BorderRight", typeof(bool), typeof(z0ZzZzcok), false);

	private new static readonly z0ZzZzcik z0mek = z0ZzZzcik.z0eek(3, "BackgroundColor2", typeof(Color), typeof(z0ZzZzcok), Color.Black);

	private static readonly z0ZzZzcik z0nek = z0ZzZzcik.z0eek(51, "MarginTop", typeof(float), typeof(z0ZzZzcok), 0f);

	private static readonly z0ZzZzcik z0cek = z0ZzZzcik.z0eek(31, "FontName", typeof(string), typeof(z0ZzZzcok), null);

	private static readonly z0ZzZzcik z0xek = z0ZzZzcik.z0eek(79, "Underline", typeof(bool), typeof(z0ZzZzcok), false);

	private static readonly z0ZzZzcik z0zek = z0ZzZzcik.z0eek(39, "LayoutAlign", typeof(ContentLayoutAlign), typeof(z0ZzZzcok), ContentLayoutAlign.EmbedInText);

	private static readonly z0ZzZzcik z0hrk = z0ZzZzcik.z0eek(72, "SpacingBeforeParagraph", typeof(float), typeof(z0ZzZzcok), 0f);

	private static readonly z0ZzZzcik z0frk = z0ZzZzcik.z0eek(69, "RTFLineSpacing", typeof(float), typeof(z0ZzZzcok), 0f);

	private static readonly z0ZzZzcik z0drk = z0ZzZzcik.z0eek(44, "LetterSpacing", typeof(float), typeof(z0ZzZzcok), 0f);

	private static readonly z0ZzZzcik z0srk = z0ZzZzcik.z0eek(30, "FixedSpacing", typeof(bool), typeof(z0ZzZzcok), false);

	private static readonly z0ZzZzcik z0ark = z0ZzZzcik.z0eek(76, "Superscript", typeof(bool), typeof(z0ZzZzcok), false);

	private static readonly z0ZzZzcik z0qrk = z0ZzZzcik.z0eek(10, "Bold", typeof(bool), typeof(z0ZzZzcok), false);

	private static readonly z0ZzZzcik z0wrk = z0ZzZzcik.z0eek(11, "BorderBottom", typeof(bool), typeof(z0ZzZzcok), false);

	private static readonly z0ZzZzcik z0erk = z0ZzZzcik.z0eek(1, "Align", typeof(DocumentContentAlignment), typeof(z0ZzZzcok), DocumentContentAlignment.Left);

	private static readonly z0ZzZzcik z0trk = z0ZzZzcik.z0eek(75, "Subscript", typeof(bool), typeof(z0ZzZzcok), false);

	private static readonly z0ZzZzcik z0prk = z0ZzZzcik.z0eek(13, "BorderLeft", typeof(bool), typeof(z0ZzZzcok), false);

	private static readonly z0ZzZzcik z0mrk = z0ZzZzcik.z0eek(86, "VisibleInDirectory", typeof(bool), typeof(z0ZzZzcok), true);

	private static readonly z0ZzZzcik z0vrk = z0ZzZzcik.z0eek(57, "PaddingTop", typeof(float), typeof(z0ZzZzcok), 0f);

	private static readonly z0ZzZzcik z0ktk = z0ZzZzcik.z0eek(52, "Multiline", typeof(bool), typeof(z0ZzZzcok), false);

	private static readonly z0ZzZzcik z0htk = z0ZzZzcik.z0eek(49, "MarginLeft", typeof(float), typeof(z0ZzZzcok), 0f);

	private static readonly z0ZzZzcik z0qtk = z0ZzZzcik.z0eek(50, "MarginRight", typeof(float), typeof(z0ZzZzcok), 0f);

	private static readonly z0ZzZzcik z0rtk = z0ZzZzcik.z0eek(55, "PaddingLeft", typeof(float), typeof(z0ZzZzcok), 0f);

	private static readonly z0ZzZzcik z0ytk = z0ZzZzcik.z0eek(46, "LineSpacingStyle", typeof(LineSpacingStyle), typeof(z0ZzZzcok), LineSpacingStyle.SpaceSingle);

	private static readonly z0ZzZzcik z0utk = z0ZzZzcik.z0eek(43, "LeftIndent", typeof(float), typeof(z0ZzZzcok), 0f);

	private static readonly z0ZzZzcik z0itk = z0ZzZzcik.z0eek(83, "VerticalAlign", typeof(VerticalAlignStyle), typeof(z0ZzZzcok), VerticalAlignStyle.Top);

	private static readonly z0ZzZzcik z0ptk = z0ZzZzcik.z0eek(38, "Italic", typeof(bool), typeof(z0ZzZzcok), false);

	public static readonly z0ZzZzcik z0btk = z0ZzZzcik.z0eek(2, "BackgroundColor", typeof(Color), typeof(z0ZzZzcok), Color.Transparent);

	private static readonly z0ZzZzcik z0ctk = z0ZzZzcik.z0eek(17, "BorderSpacing", typeof(float), typeof(z0ZzZzcok), 0f);

	private static readonly z0ZzZzcik z0xtk = z0ZzZzcik.z0eek(14, "BorderLeftColor", typeof(Color), typeof(z0ZzZzcok), Color.Black);

	private static readonly z0ZzZzcik z0lyk = z0ZzZzcik.z0eek(60, "ParagraphListStyle", typeof(ParagraphListStyle), typeof(z0ZzZzcok), ParagraphListStyle.None);

	private static readonly z0ZzZzcik z0kyk = z0ZzZzcik.z0eek(71, "SpacingAfterParagraph", typeof(float), typeof(z0ZzZzcok), 0f);

	private static readonly z0ZzZzcik z0jyk = z0ZzZzcik.z0eek(12, "BorderBottomColor", typeof(Color), typeof(z0ZzZzcok), Color.Black);

	private static readonly z0ZzZzcik z0hyk = z0ZzZzcik.z0eek(66, "RightToLeft", typeof(bool), typeof(z0ZzZzcok), false);

	private static readonly z0ZzZzcik z0gyk = z0ZzZzcik.z0eek(62, "ParagraphOutlineLevel", typeof(int), typeof(z0ZzZzcok), -1);

	private static readonly z0ZzZzcik z0fyk = z0ZzZzcik.z0eek(22, "CharacterCircle", typeof(CharacterCircleStyles), typeof(z0ZzZzcok), CharacterCircleStyles.None);

	private static readonly z0ZzZzcik z0ayk = z0ZzZzcik.z0eek(20, "BorderTopColor", typeof(Color), typeof(z0ZzZzcok), Color.Black);

	private static readonly z0ZzZzcik z0qyk = z0ZzZzcik.z0eek(56, "PaddingRight", typeof(float), typeof(z0ZzZzcok), 0f);

	private static readonly z0ZzZzcik z0eyk = z0ZzZzcik.z0eek(80, "UnderlineColor", typeof(string), typeof(z0ZzZzcok), null);

	internal static readonly z0ZzZzcik z0yyk = z0ZzZzcik.z0eek(23, "Color", typeof(Color), typeof(z0ZzZzcok), Color.Black);

	public static float z0uyk = z0ZzZzimk.DefaultFontSize;

	private static readonly z0ZzZzcik z0iyk = z0ZzZzcik.z0eek(81, "UnderlineStyle", typeof(TextUnderlineStyle), typeof(z0ZzZzcok), TextUnderlineStyle.Single);

	private static readonly z0ZzZzcik z0oyk = z0ZzZzcik.z0eek(84, "Visibility", typeof(RenderVisibility), typeof(z0ZzZzcok), RenderVisibility.All);

	[NonSerialized]
	private z0ZzZzcok z0pyk;

	private static readonly z0ZzZzcik z0nyk = z0ZzZzcik.z0eek(28, "EmphasisMark", typeof(bool), typeof(z0ZzZzcok), false);

	public static string z0byk = z0ZzZzimk.DefaultFontName;

	private static readonly z0ZzZzcik z0zyk = z0ZzZzcik.z0eek(18, "BorderStyle", typeof(DashStyle), typeof(z0ZzZzcok), DashStyle.Solid);

	private int z0luk = -1;

	private static readonly z0ZzZzcik z0kuk = z0ZzZzcik.z0eek(45, "LineSpacing", typeof(float), typeof(z0ZzZzcok), 0f);

	private static readonly z0ZzZzcik z0juk = z0ZzZzcik.z0eek(48, "MarginBottom", typeof(float), typeof(z0ZzZzcok), 0f);

	private static readonly z0ZzZzcik z0huk = z0ZzZzcik.z0eek(61, "ParagraphMultiLevel", typeof(bool), typeof(z0ZzZzcok), false);

	private static readonly z0ZzZzcik z0duk = z0ZzZzcik.z0eek(74, "Strikeout", typeof(bool), typeof(z0ZzZzcok), false);

	private static readonly z0ZzZzcik z0quk = z0ZzZzcik.z0eek(29, "FirstLineIndent", typeof(float), typeof(z0ZzZzcok), 0f);

	private static readonly z0ZzZzcik z0wuk = z0ZzZzcik.z0eek(16, "BorderRightColor", typeof(Color), typeof(z0ZzZzcok), Color.Black);

	private static readonly z0ZzZzcik z0ruk = z0ZzZzcik.z0eek(32, "FontSize", typeof(float), typeof(z0ZzZzcok), 0f);

	private static readonly z0ZzZzcik z0tuk = z0ZzZzcik.z0eek(19, "BorderTop", typeof(bool), typeof(z0ZzZzcok), false);

	private static readonly z0ZzZzcik z0yuk = z0ZzZzcik.z0eek(54, "PaddingBottom", typeof(float), typeof(z0ZzZzcok), 0f);

	private static readonly z0ZzZzcik z0ouk = z0ZzZzcik.z0eek(21, "BorderWidth", typeof(float), typeof(z0ZzZzcok), 0f);

	[DefaultValue(RenderVisibility.All)]
	public RenderVisibility Visibility
	{
		get
		{
			return (RenderVisibility)z0eek(z0oyk);
		}
		set
		{
			z0eek(z0oyk, value);
		}
	}

	[z0ZzZzuqh]
	public Color BackgroundColor
	{
		get
		{
			return (Color)z0eek(z0btk);
		}
		set
		{
			z0eek(z0btk, value);
		}
	}

	[DefaultValue(TextUnderlineStyle.Single)]
	public TextUnderlineStyle UnderlineStyle
	{
		get
		{
			return (TextUnderlineStyle)z0eek(z0iyk);
		}
		set
		{
			z0eek(z0iyk, value);
		}
	}

	[z0ZzZzuqh]
	public FontStyle FontStyle
	{
		get
		{
			if (z0bek == null)
			{
				return FontStyle.Regular;
			}
			FontStyle fontStyle = FontStyle.Regular;
			object obj = null;
			if (z0bek.TryGetValue(z0qrk, out obj) && (bool)obj)
			{
				fontStyle |= FontStyle.Bold;
			}
			if (z0bek.TryGetValue(z0ptk, out obj) && (bool)obj)
			{
				fontStyle |= FontStyle.Italic;
			}
			if (z0bek.TryGetValue(z0xek, out obj) && (bool)obj)
			{
				fontStyle |= FontStyle.Underline;
			}
			if (z0bek.TryGetValue(z0duk, out obj) && (bool)obj)
			{
				fontStyle |= FontStyle.Strikeout;
			}
			return fontStyle;
		}
		set
		{
			Bold = (value & FontStyle.Bold) == FontStyle.Bold;
			Italic = (value & FontStyle.Italic) == FontStyle.Italic;
			Underline = (value & FontStyle.Underline) == FontStyle.Underline;
			Strikeout = (value & FontStyle.Strikeout) == FontStyle.Strikeout;
		}
	}

	[DefaultValue(false)]
	public bool Subscript
	{
		get
		{
			return (bool)z0eek(z0trk);
		}
		set
		{
			z0eek(z0trk, value);
		}
	}

	[z0ZzZzuqh]
	public Color BorderBottomColor
	{
		get
		{
			return (Color)z0eek(z0jyk);
		}
		set
		{
			z0eek(z0jyk, value);
		}
	}

	[DefaultValue(0f)]
	public float FontSize
	{
		get
		{
			return (float)z0eek(z0ruk);
		}
		set
		{
			z0eek(z0ruk, value);
		}
	}

	[DefaultValue(null)]
	public string UnderlineColor
	{
		get
		{
			return (string)z0eek(z0eyk);
		}
		set
		{
			z0eek(z0eyk, value);
		}
	}

	[DefaultValue(0f)]
	public float MarginLeft
	{
		get
		{
			return (float)z0eek(z0htk);
		}
		set
		{
			z0eek(z0htk, value);
		}
	}

	[DefaultValue(ContentLayoutAlign.EmbedInText)]
	public ContentLayoutAlign LayoutAlign
	{
		get
		{
			return (ContentLayoutAlign)z0eek(z0zek);
		}
		set
		{
			z0eek(z0zek, value);
		}
	}

	public bool IsBulletedList => z0ZzZzlmk.z0eek(ParagraphListStyle);

	[DefaultValue(0f)]
	public float PaddingLeft
	{
		get
		{
			return (float)z0eek(z0rtk);
		}
		set
		{
			z0eek(z0rtk, value);
		}
	}

	[z0ZzZzyqh("BackgroundColor")]
	[DefaultValue(null)]
	public string BackgroundColorString
	{
		get
		{
			return z0ZzZzlok.z0eek(BackgroundColor, Color.Transparent);
		}
		set
		{
			BackgroundColor = z0ZzZzlok.z0eek(value, Color.Transparent);
		}
	}

	[DefaultValue(false)]
	public bool Bold
	{
		get
		{
			return (bool)z0eek(z0qrk);
		}
		set
		{
			z0eek(z0qrk, value);
		}
	}

	[DefaultValue(null)]
	public string FontName
	{
		get
		{
			string text = (string)z0eek(z0cek);
			if (string.IsNullOrEmpty(text))
			{
				return z0ZzZzimk.DefaultFontName;
			}
			return text;
		}
		set
		{
			if (value != null)
			{
				value = string.Intern(value);
			}
			z0eek(z0cek, value);
		}
	}

	[DefaultValue(ParagraphListStyle.None)]
	public ParagraphListStyle ParagraphListStyle
	{
		get
		{
			return (ParagraphListStyle)z0eek(z0lyk);
		}
		set
		{
			z0eek(z0lyk, value);
		}
	}

	[DefaultValue(false)]
	public bool Underline
	{
		get
		{
			return (bool)z0eek(z0xek);
		}
		set
		{
			z0eek(z0xek, value);
		}
	}

	[z0ZzZzuqh]
	public Color BorderRightColor
	{
		get
		{
			return (Color)z0eek(z0wuk);
		}
		set
		{
			z0eek(z0wuk, value);
		}
	}

	public bool IsListNumberStyle => z0ZzZzlmk.z0tek(ParagraphListStyle);

	[DefaultValue(false)]
	public bool FixedSpacing
	{
		get
		{
			return (bool)z0eek(z0srk);
		}
		set
		{
			z0eek(z0srk, value);
		}
	}

	[DefaultValue(0f)]
	public float PaddingBottom
	{
		get
		{
			return (float)z0eek(z0yuk);
		}
		set
		{
			z0eek(z0yuk, value);
		}
	}

	[DefaultValue(0f)]
	public float RTFLineSpacing
	{
		get
		{
			return (float)z0eek(z0frk);
		}
		set
		{
			z0eek(z0frk, value);
		}
	}

	[DefaultValue(null)]
	[z0ZzZzyqh("BorderRightColor")]
	public string BorderRightColorString
	{
		get
		{
			return z0ZzZzlok.z0eek(BorderRightColor, Color.Black);
		}
		set
		{
			BorderRightColor = z0ZzZzlok.z0eek(value, Color.Black);
		}
	}

	[DefaultValue(VerticalAlignStyle.Top)]
	public VerticalAlignStyle VerticalAlign
	{
		get
		{
			return (VerticalAlignStyle)z0eek(z0itk);
		}
		set
		{
			z0eek(z0itk, value);
		}
	}

	[DefaultValue(LineSpacingStyle.SpaceSingle)]
	public LineSpacingStyle LineSpacingStyle
	{
		get
		{
			return (LineSpacingStyle)z0eek(z0ytk);
		}
		set
		{
			z0eek(z0ytk, value);
		}
	}

	[DefaultValue(DocumentContentAlignment.Left)]
	public DocumentContentAlignment Align
	{
		get
		{
			return (DocumentContentAlignment)z0eek(z0erk);
		}
		set
		{
			z0eek(z0erk, value);
		}
	}

	[DefaultValue(0f)]
	public float LetterSpacing
	{
		get
		{
			return (float)z0eek(z0drk);
		}
		set
		{
			z0eek(z0drk, Math.Max(0f, value));
		}
	}

	public string BulletedString => z0ZzZzlmk.z0rek(ParagraphListStyle);

	[z0ZzZzuqh]
	public Color Color
	{
		get
		{
			return (Color)z0eek(z0yyk);
		}
		set
		{
			z0eek(z0yyk, value);
		}
	}

	[z0ZzZzuqh]
	public Color BorderTopColor
	{
		get
		{
			return (Color)z0eek(z0ayk);
		}
		set
		{
			z0eek(z0ayk, value);
		}
	}

	[DefaultValue(false)]
	public bool ParagraphMultiLevel
	{
		get
		{
			return (bool)z0eek(z0huk);
		}
		set
		{
			z0eek(z0huk, value);
		}
	}

	[DefaultValue(false)]
	public bool EmphasisMark
	{
		get
		{
			return (bool)z0eek(z0nyk);
		}
		set
		{
			z0eek(z0nyk, value);
		}
	}

	public virtual bool IsEmpty
	{
		get
		{
			if (z0bek != null)
			{
				return z0bek.Count == 0;
			}
			return true;
		}
	}

	[z0ZzZzyqh("Color")]
	[DefaultValue(null)]
	public string ColorString
	{
		get
		{
			return z0ZzZzlok.z0eek(Color, Color.Black);
		}
		set
		{
			Color = z0ZzZzlok.z0eek(value, Color.Black);
		}
	}

	[DefaultValue(false)]
	public bool BorderTop
	{
		get
		{
			return (bool)z0eek(z0tuk);
		}
		set
		{
			z0eek(z0tuk, value);
		}
	}

	[z0ZzZzuqh]
	public Color BorderLeftColor
	{
		get
		{
			return (Color)z0eek(z0xtk);
		}
		set
		{
			z0eek(z0xtk, value);
		}
	}

	[DefaultValue(-1)]
	public int ParagraphOutlineLevel
	{
		get
		{
			return (int)z0eek(z0gyk);
		}
		set
		{
			z0eek(z0gyk, value);
		}
	}

	[DefaultValue(false)]
	public bool BorderBottom
	{
		get
		{
			return (bool)z0eek(z0wrk);
		}
		set
		{
			z0eek(z0wrk, value);
		}
	}

	[DefaultValue(false)]
	public bool BorderRight
	{
		get
		{
			return (bool)z0eek(z0pek);
		}
		set
		{
			z0eek(z0pek, value);
		}
	}

	[DefaultValue(CharacterCircleStyles.None)]
	public CharacterCircleStyles CharacterCircle
	{
		get
		{
			return (CharacterCircleStyles)z0eek(z0fyk);
		}
		set
		{
			z0eek(z0fyk, value);
		}
	}

	[z0ZzZzyqh("BackgroundColor2")]
	[DefaultValue(null)]
	public string BackgroundColor2String
	{
		get
		{
			return z0ZzZzlok.z0eek(BackgroundColor2, Color.Black);
		}
		set
		{
			BackgroundColor2 = z0ZzZzlok.z0eek(value, Color.Black);
		}
	}

	[DefaultValue(0f)]
	public float BorderSpacing
	{
		get
		{
			return (float)z0eek(z0ctk);
		}
		set
		{
			z0eek(z0ctk, value);
		}
	}

	[DefaultValue(0f)]
	public float MarginTop
	{
		get
		{
			return (float)z0eek(z0nek);
		}
		set
		{
			z0eek(z0nek, value);
		}
	}

	[z0ZzZzuqh]
	public Color BorderColor
	{
		get
		{
			return BorderLeftColor;
		}
		set
		{
			BorderLeftColor = value;
			BorderTopColor = value;
			BorderRightColor = value;
			BorderBottomColor = value;
		}
	}

	public bool HasVisibleBackground
	{
		get
		{
			if (BackgroundColor.A == 0)
			{
				return false;
			}
			return true;
		}
	}

	[DefaultValue(DashStyle.Solid)]
	public DashStyle BorderStyle
	{
		get
		{
			return (DashStyle)z0eek(z0zyk);
		}
		set
		{
			z0eek(z0zyk, value);
		}
	}

	[DefaultValue(0f)]
	public float SpacingBeforeParagraph
	{
		get
		{
			return (float)z0eek(z0hrk);
		}
		set
		{
			z0eek(z0hrk, Math.Max(0f, value));
		}
	}

	[DefaultValue(0f)]
	public float FirstLineIndent
	{
		get
		{
			float result = (float)z0eek(z0quk);
			_ = 0f;
			return result;
		}
		set
		{
			z0eek(z0quk, value);
		}
	}

	[z0ZzZzyqh("BorderBottomColor")]
	[DefaultValue(null)]
	public string BorderBottomColorString
	{
		get
		{
			return z0ZzZzlok.z0eek(BorderBottomColor, Color.Black);
		}
		set
		{
			BorderBottomColor = z0ZzZzlok.z0eek(value, Color.Black);
		}
	}

	[DefaultValue(0f)]
	public float MarginRight
	{
		get
		{
			return (float)z0eek(z0qtk);
		}
		set
		{
			z0eek(z0qtk, value);
		}
	}

	[DefaultValue(false)]
	public bool BorderLeft
	{
		get
		{
			return (bool)z0eek(z0prk);
		}
		set
		{
			z0eek(z0prk, value);
		}
	}

	public bool HasVisibleBorder
	{
		get
		{
			if (!BorderLeft && !BorderTop && !BorderRight && !BorderBottom)
			{
				return false;
			}
			if (BorderTopColor.A == 0 && BorderLeftColor.A == 0 && BorderRightColor.A == 0 && BorderBottomColor.A == 0)
			{
				return false;
			}
			if (BorderWidth == 0f)
			{
				return false;
			}
			return true;
		}
	}

	[DefaultValue(0f)]
	public float PaddingRight
	{
		get
		{
			return (float)z0eek(z0qyk);
		}
		set
		{
			z0eek(z0qyk, value);
		}
	}

	[DefaultValue(0f)]
	public float BorderWidth
	{
		get
		{
			return (float)z0eek(z0ouk);
		}
		set
		{
			z0eek(z0ouk, value);
		}
	}

	[DefaultValue(0f)]
	public float PaddingTop
	{
		get
		{
			return (float)z0eek(z0vrk);
		}
		set
		{
			z0eek(z0vrk, value);
		}
	}

	[z0ZzZzuqh]
	public z0ZzZzimk Font
	{
		get
		{
			z0ZzZzimk z0ZzZzimk2 = new z0ZzZzimk();
			foreach (KeyValuePair<z0ZzZzcik, object> item in z0bek)
			{
				if (item.Key == z0cek)
				{
					z0ZzZzimk2.Name = (string)item.Value;
				}
				else if (item.Key == z0ruk)
				{
					float num = (float)item.Value;
					if (num > 0f)
					{
						z0ZzZzimk2.Size = num;
					}
				}
				else if (item.Key == z0qrk)
				{
					z0ZzZzimk2.Bold = (bool)item.Value;
				}
				else if (item.Key == z0ptk)
				{
					z0ZzZzimk2.Italic = (bool)item.Value;
				}
				else if (item.Key == z0xek)
				{
					z0ZzZzimk2.Underline = (bool)item.Value;
				}
				else if (item.Key == z0duk)
				{
					z0ZzZzimk2.Strikeout = (bool)item.Value;
				}
			}
			return z0ZzZzimk2;
		}
		set
		{
			if (value != null)
			{
				FontName = value.Name;
				FontSize = value.Size;
				Bold = value.Bold;
				Italic = value.Italic;
				Underline = value.Underline;
				Strikeout = value.Strikeout;
			}
		}
	}

	[DefaultValue(false)]
	public bool Strikeout
	{
		get
		{
			return (bool)z0eek(z0duk);
		}
		set
		{
			z0eek(z0duk, value);
		}
	}

	[DefaultValue(0f)]
	public float MarginBottom
	{
		get
		{
			return (float)z0eek(z0juk);
		}
		set
		{
			z0eek(z0juk, value);
		}
	}

	[z0ZzZzuqh]
	public Color BackgroundColor2
	{
		get
		{
			return (Color)z0eek(z0mek);
		}
		set
		{
			z0eek(z0mek, value);
		}
	}

	[DefaultValue(true)]
	public bool VisibleInDirectory
	{
		get
		{
			return (bool)z0eek(z0mrk);
		}
		set
		{
			z0eek(z0mrk, value);
		}
	}

	[DefaultValue(false)]
	public bool Multiline
	{
		get
		{
			return (bool)z0eek(z0ktk);
		}
		set
		{
			z0eek(z0ktk, value);
		}
	}

	[DefaultValue(0f)]
	public float SpacingAfterParagraph
	{
		get
		{
			return (float)z0eek(z0kyk);
		}
		set
		{
			z0eek(z0kyk, Math.Max(0f, value));
		}
	}

	[DefaultValue(0f)]
	public float LineSpacing
	{
		get
		{
			return (float)z0eek(z0kuk);
		}
		set
		{
			z0eek(z0kuk, Math.Max(0f, value));
		}
	}

	[z0ZzZztqh]
	[DefaultValue(-1)]
	public int Index
	{
		get
		{
			return z0luk;
		}
		set
		{
			z0luk = value;
		}
	}

	[z0ZzZzyqh("BorderLeftColor")]
	[DefaultValue(null)]
	public string BorderLeftColorString
	{
		get
		{
			return z0ZzZzlok.z0eek(BorderLeftColor, Color.Black);
		}
		set
		{
			BorderLeftColor = z0ZzZzlok.z0eek(value, Color.Black);
		}
	}

	[DefaultValue(false)]
	public bool Italic
	{
		get
		{
			return (bool)z0eek(z0ptk);
		}
		set
		{
			z0eek(z0ptk, value);
		}
	}

	[DefaultValue(false)]
	public bool Superscript
	{
		get
		{
			return (bool)z0eek(z0ark);
		}
		set
		{
			z0eek(z0ark, value);
		}
	}

	[z0ZzZzyqh("BorderTopColor")]
	[DefaultValue(null)]
	public string BorderTopColorString
	{
		get
		{
			return z0ZzZzlok.z0eek(BorderTopColor, Color.Black);
		}
		set
		{
			BorderTopColor = z0ZzZzlok.z0eek(value, Color.Black);
		}
	}

	[DefaultValue(false)]
	public bool RightToLeft
	{
		get
		{
			return (bool)z0eek(z0hyk);
		}
		set
		{
			z0eek(z0hyk, value);
		}
	}

	[DefaultValue(0f)]
	public float LeftIndent
	{
		get
		{
			return (float)z0eek(z0utk);
		}
		set
		{
			if (value < 0f)
			{
				value = 0f;
			}
			z0eek(z0utk, value);
		}
	}

	public void z0eek(float p0, float p1, float p2, float p3)
	{
		z0ZzZzxik z0ZzZzxik2 = z0bek;
		if (p0 == 0f)
		{
			z0ZzZzxik2.Remove(z0rtk);
		}
		else
		{
			z0ZzZzxik2[z0rtk] = p0;
		}
		if (p1 == 0f)
		{
			z0ZzZzxik2.Remove(z0vrk);
		}
		else
		{
			z0ZzZzxik2[z0vrk] = p1;
		}
		if (p2 == 0f)
		{
			z0ZzZzxik2.Remove(z0qyk);
		}
		else
		{
			z0ZzZzxik2[z0qyk] = p2;
		}
		if (p3 == 0f)
		{
			z0ZzZzxik2.Remove(z0yuk);
		}
		else
		{
			z0ZzZzxik2[z0yuk] = p3;
		}
	}

	public void z0eek(DocumentContentAlignment p0)
	{
		if (p0 == DocumentContentAlignment.Left)
		{
			z0bek.Remove(z0erk);
		}
		else
		{
			z0bek[z0erk] = p0;
		}
	}

	public void z0eek(string p0)
	{
		if (string.IsNullOrEmpty(p0))
		{
			z0bek.Remove(z0cek);
		}
		else
		{
			z0bek[z0cek] = p0;
		}
	}

	public new virtual void z0eek()
	{
	}

	public override string ToString()
	{
		return z0ZzZzvik.z0rek(this);
	}

	public new static void z0rek()
	{
	}

	public void z0tek()
	{
		z0bek.Remove(z0prk);
		z0bek.Remove(z0tuk);
		z0bek.Remove(z0pek);
		z0bek.Remove(z0wrk);
		z0bek.Remove(z0xtk);
		z0bek.Remove(z0ayk);
		z0bek.Remove(z0wuk);
		z0bek.Remove(z0jyk);
		z0bek.Remove(z0zyk);
		z0bek.Remove(z0ouk);
	}

	public z0ZzZzbdh z0eek(z0ZzZzbdh p0)
	{
		return new z0ZzZzbdh(p0.z0oek() + PaddingLeft, p0.z0pek() + PaddingTop, p0.z0uek() - PaddingLeft - PaddingRight, p0.z0iek() - PaddingTop - PaddingBottom);
	}

	public void z0eek(float p0, DashStyle p1, Color p2)
	{
		z0ZzZzxik obj = z0bek;
		obj[z0prk] = true;
		obj[z0tuk] = true;
		obj[z0pek] = true;
		obj[z0wrk] = true;
		obj[z0ouk] = p0;
		obj[z0zyk] = p1;
		obj[z0xtk] = p2;
		obj[z0ayk] = p2;
		obj[z0wuk] = p2;
		obj[z0jyk] = p2;
	}

	public virtual z0ZzZzcok Clone()
	{
		z0ZzZzcok z0ZzZzcok2 = (z0ZzZzcok)MemberwiseClone();
		z0ZzZzcok2.z0bek = new z0ZzZzxik();
		z0ZzZzcok2.z0rek(p0: false);
		z0ZzZzvik.z0rek(this, z0ZzZzcok2);
		return z0ZzZzcok2;
	}

	public new z0ZzZzcok z0yek()
	{
		return z0pyk;
	}

	public void z0eek(z0ZzZzjpk p0, z0ZzZzbdh p1)
	{
		float borderWidth = BorderWidth;
		DashStyle borderStyle = BorderStyle;
		z0eek(p0, p1, BorderLeft, BorderLeftColor, borderWidth, borderStyle, BorderTop, BorderTopColor, borderWidth, borderStyle, BorderRight, BorderRightColor, borderWidth, borderStyle, BorderBottom, BorderBottomColor, borderWidth, borderStyle);
	}

	public int z0eek(z0ZzZzcok p0)
	{
		if (p0 == null)
		{
			throw new ArgumentNullException("defaultStyle");
		}
		bool flag = false;
		foreach (z0ZzZzcik key in ((z0ZzZzvik)p0).z0yek().Keys)
		{
			if (base.z0yek().ContainsKey(key))
			{
				object obj = ((z0ZzZzvik)p0).z0yek()[key];
				object obj2 = base.z0yek()[key];
				if (obj == obj2)
				{
					base.z0yek().Remove(key);
					flag = true;
				}
			}
		}
		if (flag)
		{
			z0vn(null);
		}
		return base.z0yek().Count;
	}

	public new z0ZzZzlsh z0uek()
	{
		z0ZzZzlsh z0ZzZzlsh2 = new z0ZzZzlsh();
		switch (Align)
		{
		case DocumentContentAlignment.Left:
			z0ZzZzlsh2.z0rek(StringAlignment.Near);
			break;
		case DocumentContentAlignment.Center:
			z0ZzZzlsh2.z0rek(StringAlignment.Center);
			break;
		case DocumentContentAlignment.Right:
			z0ZzZzlsh2.z0rek(StringAlignment.Far);
			break;
		case DocumentContentAlignment.Justify:
			z0ZzZzlsh2.z0rek(StringAlignment.Center);
			break;
		}
		switch (VerticalAlign)
		{
		case VerticalAlignStyle.Top:
			z0ZzZzlsh2.z0eek(StringAlignment.Near);
			break;
		case VerticalAlignStyle.Middle:
			z0ZzZzlsh2.z0eek(StringAlignment.Center);
			break;
		case VerticalAlignStyle.Bottom:
			z0ZzZzlsh2.z0eek(StringAlignment.Far);
			break;
		}
		z0ZzZzksh z0ZzZzksh2 = z0ZzZzlsh2.z0yek();
		if (!Multiline)
		{
			z0ZzZzksh2 |= (z0ZzZzksh)4096;
		}
		if (RightToLeft)
		{
			z0ZzZzksh2 |= (z0ZzZzksh)1;
		}
		z0ZzZzlsh2.z0eek(z0ZzZzksh2);
		return z0ZzZzlsh2;
	}

	public void z0eek(bool p0, bool p1, bool p2, bool p3, Color p4, Color p5, Color p6, Color p7, float p8, DashStyle p9)
	{
		_ = z0bek.Count;
		if (!p0)
		{
			z0bek.Remove(z0prk);
		}
		else
		{
			z0bek[z0prk] = p0;
		}
		if (!p1)
		{
			z0bek.Remove(z0tuk);
		}
		else
		{
			z0bek[z0tuk] = p1;
		}
		if (!p2)
		{
			z0bek.Remove(z0pek);
		}
		else
		{
			z0bek[z0pek] = p2;
		}
		if (!p3)
		{
			z0bek.Remove(z0wrk);
		}
		else
		{
			z0bek[z0wrk] = p3;
		}
		if (p4 == Color.Black)
		{
			z0bek.Remove(z0xtk);
		}
		else
		{
			z0bek[z0xtk] = p4;
		}
		if (p5 == Color.Black)
		{
			z0bek.Remove(z0ayk);
		}
		else
		{
			z0bek[z0ayk] = p5;
		}
		if (p6 == Color.Black)
		{
			z0bek.Remove(z0wuk);
		}
		else
		{
			z0bek[z0wuk] = p6;
		}
		if (p7 == Color.Black)
		{
			z0bek.Remove(z0jyk);
		}
		else
		{
			z0bek[z0jyk] = p7;
		}
		if (p8 == 0f)
		{
			z0bek.Remove(z0ouk);
		}
		else
		{
			z0bek[z0ouk] = p8;
		}
		if (p9 == DashStyle.Solid)
		{
			z0bek.Remove(z0zyk);
		}
		else
		{
			z0bek[z0zyk] = p9;
		}
	}

	public new z0ZzZzudh z0iek()
	{
		z0ZzZzudh obj = new z0ZzZzudh(BorderTopColor, BorderWidth);
		obj.z0eek(BorderStyle);
		return obj;
	}

	public void z0rek(z0ZzZzcok p0)
	{
		z0pyk = p0;
	}

	public static void z0eek(z0ZzZzjpk p0, z0ZzZzudh p1, z0ZzZzbdh p2, bool p3, bool p4, bool p5, bool p6)
	{
		if (p3 && p4 && p5 && p6)
		{
			p0.z0eek(p1, p2.z0oek(), p2.z0pek(), p2.z0uek(), p2.z0iek(), 0f);
			return;
		}
		if (p3)
		{
			p0.z0eek(p1, p2.z0oek(), p2.z0nek(), p2.z0oek(), p2.z0pek());
		}
		if (p4)
		{
			p0.z0eek(p1, p2.z0oek(), p2.z0pek(), p2.z0mek(), p2.z0pek());
		}
		if (p5)
		{
			p0.z0eek(p1, p2.z0mek(), p2.z0pek(), p2.z0mek(), p2.z0nek());
		}
		if (p6)
		{
			p0.z0eek(p1, p2.z0oek(), p2.z0nek(), p2.z0mek(), p2.z0nek());
		}
	}

	public z0ZzZzcok CloneEnableDefaultValue()
	{
		z0ZzZzcok obj = Clone();
		obj.z0eek(p0: false);
		return obj;
	}

	public static void z0eek(z0ZzZzjpk p0, z0ZzZzbdh p1, bool p2, Color p3, float p4, DashStyle p5, bool p6, Color p7, float p8, DashStyle p9, bool p10, Color p11, float p12, DashStyle p13, bool p14, Color p15, float p16, DashStyle p17)
	{
		if (p3 == p7 && p7 == p11 && p11 == p15 && p4 == p8 && p8 == p12 && p12 == p16 && p5 == p9 && p9 == p13 && p13 == p17 && p2 && p6 && p10 && p14)
		{
			if (p3.A != 0 && p4 > 0f)
			{
				using (z0ZzZzudh z0ZzZzudh2 = new z0ZzZzudh(p3, p4))
				{
					z0ZzZzudh2.z0eek(p5);
					p0.z0eek(z0ZzZzudh2, p1.z0oek(), p1.z0pek(), p1.z0uek(), p1.z0iek(), 0f);
					return;
				}
			}
			return;
		}
		if (p2 && p3.A != 0 && p4 > 0f)
		{
			using z0ZzZzudh z0ZzZzudh3 = new z0ZzZzudh(p3, p4);
			z0ZzZzudh3.z0eek(p5);
			p0.z0eek(z0ZzZzudh3, p1.z0oek(), p1.z0pek(), p1.z0oek(), p1.z0nek());
		}
		if (p6 && p7.A != 0 && p8 > 0f)
		{
			using z0ZzZzudh z0ZzZzudh4 = new z0ZzZzudh(p7, p8);
			z0ZzZzudh4.z0eek(p9);
			p0.z0eek(z0ZzZzudh4, p1.z0oek(), p1.z0pek(), p1.z0mek(), p1.z0pek());
		}
		if (p10 && p11.A != 0 && p12 > 0f)
		{
			using z0ZzZzudh z0ZzZzudh5 = new z0ZzZzudh(p11, p12);
			z0ZzZzudh5.z0eek(p13);
			p0.z0eek(z0ZzZzudh5, p1.z0mek(), p1.z0pek(), p1.z0mek(), p1.z0nek());
		}
		if (p14 && p15.A != 0 && p16 > 0f)
		{
			using (z0ZzZzudh z0ZzZzudh6 = new z0ZzZzudh(p15, p16))
			{
				z0ZzZzudh6.z0eek(p17);
				p0.z0eek(z0ZzZzudh6, p1.z0oek(), p1.z0nek(), p1.z0mek(), p1.z0nek());
			}
		}
	}

	public new void z0oek()
	{
		z0bek.Remove(z0yyk);
	}

	public string z0eek(int p0)
	{
		return z0ZzZzlmk.z0rek(p0, ParagraphListStyle);
	}

	public bool z0tek(z0ZzZzcok p0)
	{
		if (z0bek.Count != p0.z0bek.Count)
		{
			return false;
		}
		if (((z0ZzZzvik)this).z0uek() != ((z0ZzZzvik)p0).z0uek())
		{
			return false;
		}
		foreach (KeyValuePair<z0ZzZzcik, object> item in z0bek)
		{
			object objB = null;
			if (p0.z0bek.TryGetValue(item.Key, out objB))
			{
				if (!object.Equals(item.Value, objB))
				{
					return false;
				}
				continue;
			}
			return false;
		}
		return true;
	}

	public z0ZzZztfh z0eek(z0ZzZzbdh p0, GraphicsUnit p1)
	{
		z0ZzZzemk obj = new z0ZzZzemk();
		obj.z0eek(BackgroundColor);
		obj.z0rek(BackgroundColor2);
		return obj.z0eek(p0, p1);
	}

	public virtual void Dispose()
	{
		base.z0iek();
		if (z0pyk != null)
		{
			z0pyk.Dispose();
			z0pyk = null;
		}
	}
}
