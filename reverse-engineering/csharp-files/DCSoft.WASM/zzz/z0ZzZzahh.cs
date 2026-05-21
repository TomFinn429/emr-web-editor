using System;
using System.Collections.Generic;
using DCSoft.Chart;
using DCSoft.Common;
using DCSoft.Data;
using DCSoft.Drawing;
using DCSoft.Printing;
using DCSoft.WinForms;
using DCSoft.Writer;
using DCSoft.Writer.Data;
using DCSoft.Writer.Dom;
using DCSoft.Writer.Extension.Medical;
using DCSoft.Writer.MedicalExpression;
using DCSoft.Writer.Security;
using DCSystem_Drawing;
using DCSystem_Drawing.Drawing2D;
using DCSystem_Drawing.Printing;

namespace zzz;

public class z0ZzZzahh : z0ZzZzkhh
{
	private List<zzz.z0ZzZzkuk<char>> z0yek = new List<zzz.z0ZzZzkuk<char>>();

	private char[] z0uek = new char[50];

	private z0ZzZzhqh z0iek;

	protected internal void z0rek(string p0, string p1, z0ZzZzhuj p2, bool p3, bool p4)
	{
		z0iek = z0eek();
		z0ZzZzhqh z0ZzZzhqh2 = z0eek();
		if (p2 == null)
		{
			return;
		}
		if (!p4)
		{
			Type type = p2.GetType();
			if (!(type == typeof(z0ZzZzhuj)))
			{
				if (type == typeof(z0ZzZzquj))
				{
					z0rek(p0, p1, (z0ZzZzquj)p2, p3, p4: true);
					return;
				}
				if (type == typeof(z0ZzZzauj))
				{
					z0rek(p0, p1, (z0ZzZzauj)p2, p3, p4: true);
					return;
				}
				if (type == typeof(z0ZzZzuuj))
				{
					z0rek(p0, p1, (z0ZzZzuuj)p2, p3, p4: true);
					return;
				}
				if (type == typeof(z0ZzZzeuj))
				{
					z0rek(p0, p1, (z0ZzZzeuj)p2, p3, p4: true);
					return;
				}
				if (type == typeof(z0ZzZziuj))
				{
					z0rek(p0, p1, (z0ZzZziuj)p2, p3, p4: true);
					return;
				}
				if (type == typeof(z0ZzZzwuj))
				{
					z0rek(p0, p1, (z0ZzZzwuj)p2, p3, p4: true);
					return;
				}
				if (type == typeof(z0ZzZzfuj))
				{
					z0rek(p0, p1, (z0ZzZzfuj)p2, p3, p4: true);
					return;
				}
				if (type == typeof(z0ZzZzxyj))
				{
					z0rek(p0, p1, (z0ZzZzxyj)p2, p3, p4: true);
					return;
				}
				if (type == typeof(z0ZzZzjuj))
				{
					z0rek(p0, p1, (z0ZzZzjuj)p2, p3, p4: true);
					return;
				}
				if (type == typeof(z0ZzZzkuj))
				{
					z0rek(p0, p1, (z0ZzZzkuj)p2, p3, p4: true);
					return;
				}
				if (type == typeof(z0ZzZzluj))
				{
					z0rek(p0, p1, (z0ZzZzluj)p2, p3, p4: true);
					return;
				}
				throw z0eek(p2);
			}
		}
		z0eek(p0, p1, p2, p3: false, null);
		if (p4)
		{
			z0eek("ShapeElement");
		}
		if (p2.z0eek() != -1)
		{
			z0ZzZzhqh2.z0eek("StyleIndex", p2.z0eek());
		}
		z0rek("LocalStyle", string.Empty, p2.z0pek(), p3: false, p4: false);
		if (!p2.z0rek_jiejie20260327142557())
		{
			z0rek("Visible", p2.z0rek_jiejie20260327142557());
		}
		z0tek("ID", p2.z0yek());
		base.z0rek((object?)p2);
	}

	private void z0rek(string p0, float p1)
	{
		z0iek.z0tek(p0, null);
		int p2 = z0ZzZzhqh.z0eek(z0uek, 0, p1, 1000);
		z0iek.z0eek(z0uek, 0, p2);
		z0iek.z0bg();
	}

	protected internal void z0rek(string p0, string p1, XTextButtonElement p2, bool p3, bool p4)
	{
		z0iek = z0eek();
		z0ZzZzhqh z0ZzZzhqh2 = z0eek();
		if (p2 != null)
		{
			if (!p4 && !(p2.GetType() == typeof(XTextButtonElement)))
			{
				throw z0eek(p2);
			}
			z0eek(p0, p1, p2, p3: false, null);
			if (p4)
			{
				z0eek("XTextButton");
			}
			if (((XTextElement)p2).z0pek() != -1)
			{
				z0ZzZzhqh2.z0eek("StyleIndex", ((XTextElement)p2).z0pek());
			}
			z0rek(z0ZzZzhqh2, p2.Attributes);
			z0tek("ID", p2.ID);
			z0tek("ToolTip", p2.ToolTip);
			if (p2.OffsetX != 0f)
			{
				z0rek("OffsetX", p2.OffsetX);
			}
			if (p2.OffsetY != 0f)
			{
				z0rek("OffsetY", p2.OffsetY);
			}
			if (p2.ZOrderStyle != ElementZOrderStyle.Normal)
			{
				z0ZzZzhqh2.z0eek("ZOrderStyle", null, z0rek(p2.ZOrderStyle));
			}
			z0rek(z0ZzZzhqh2, p2.PropertyExpressions);
			z0tek("ValueExpression", p2.ValueExpression);
			if (!p2.Visible)
			{
				z0rek("Visible", p2.Visible);
			}
			if (p2.PrintVisibility != ElementVisibility.Visible)
			{
				z0ZzZzhqh2.z0eek("PrintVisibility", null, z0rek(p2.PrintVisibility));
			}
			z0rek("LinkInfo", string.Empty, p2.z0iek(), p3: false, p4: false);
			if (p2.ContentReadonly != ContentReadonlyState.Inherit)
			{
				z0ZzZzhqh2.z0eek("ContentReadonly", null, z0rek(p2.ContentReadonly));
			}
			if (!p2.Deleteable)
			{
				z0rek("Deleteable", p2.Deleteable);
			}
			z0tek("Name", p2.Name);
			if (!p2.Enabled)
			{
				z0rek("Enabled", p2.Enabled);
			}
			z0tek("StringTag", p2.StringTag);
			if (p2.PrintAsText)
			{
				z0rek("PrintAsText", p2.PrintAsText);
			}
			if (p2.AutoSize)
			{
				z0rek("AutoSize", p2.AutoSize);
			}
			z0rek("Image", string.Empty, p2.Image, p3: false, p4: false);
			z0rek("ImageForDown", string.Empty, p2.ImageForDown, p3: false, p4: false);
			z0rek("ImageForMouseOver", string.Empty, p2.ImageForMouseOver, p3: false, p4: false);
			z0rek("Width", p2.Width);
			z0rek("Height", p2.Height);
			z0tek("Text", p2.Text);
			z0tek("ScriptTextForClick", p2.ScriptTextForClick);
			z0tek("CommandName", p2.CommandName);
			base.z0rek((object?)p2);
		}
	}

	protected internal void z0rek(string p0, string p1, z0ZzZzztk p2, bool p3, bool p4)
	{
		z0iek = z0eek();
		z0ZzZzhqh z0ZzZzhqh2 = z0eek();
		if (p2 != null)
		{
			if (!p4 && !(p2.GetType() == typeof(z0ZzZzztk)))
			{
				throw z0eek(p2);
			}
			z0eek(p0, p1, p2, p3: false, null);
			if (p4)
			{
				z0eek("PieDocumentStyle");
			}
			if (p2.z0rek() != 30)
			{
				z0rek("Thickness", p2.z0rek());
			}
			z0rek("ItemBorderStyle", string.Empty, p2.z0zek(), p3: false, p4: false);
			if (!p2.z0oek())
			{
				z0rek("EllipseStyle", p2.z0oek());
			}
			z0rek("LegendStyle", string.Empty, p2.z0vek(), p3: false, p4: false);
			z0rek("Caption", string.Empty, p2.z0pek(), p3: false, p4: false);
			z0rek("LabelStyle", string.Empty, p2.z0uek(), p3: false, p4: false);
			if (p2.z0lrk() != 0)
			{
				z0rek("PieHeight", p2.z0lrk());
			}
			if (p2.z0yek() != 0.78)
			{
				z0rek("PieOpacity", p2.z0yek());
			}
			if (p2.z0bek() != 0f)
			{
				z0rek("InitialAngle", p2.z0bek());
			}
			if (p2.z0iek() != ColorThemeType.Default)
			{
				z0ZzZzhqh2.z0eek("ColorTheme", null, z0rek(p2.z0iek()));
			}
			z0rek("CustomColorTheme", string.Empty, p2.z0mek(), p3: false, p4: false);
			if (p2.z0xek() != DrawingStyle.Default)
			{
				z0ZzZzhqh2.z0eek("DrawingStyle", null, z0rek(p2.z0xek()));
			}
			if (p2.z0tek() != 0f)
			{
				z0rek("SliceRelativeDisplacement", p2.z0tek());
			}
			base.z0rek((object?)p2);
		}
	}

	private string z0rek(ContentProtectType p0)
	{
		string text = null;
		return p0 switch
		{
			ContentProtectType.None => "None", 
			ContentProtectType.Content => "Content", 
			ContentProtectType.Range => "Range", 
			_ => throw z0ZzZzwhh.z0rek((long)p0, typeof(ContentProtectType)), 
		};
	}

	protected internal void z0rek(string p0, string p1, z0ZzZzwmk p2, bool p3, bool p4)
	{
		z0iek = z0eek();
		z0ZzZzhqh z0ZzZzhqh2 = z0eek();
		if (p2 != null)
		{
			if (!p4 && !(p2.GetType() == typeof(z0ZzZzwmk)))
			{
				throw z0eek(p2);
			}
			z0eek(p0, p1, p2, p3: false, null);
			if (p4)
			{
				z0eek("WatermarkInfo");
			}
			if (p2.Type != WatermarkType.None)
			{
				z0ZzZzhqh2.z0eek("Type", null, z0rek(p2.Type));
			}
			z0rek("Font", p2.Font);
			if (p2.ColorValue != "black")
			{
				z0tek("ColorValue", p2.ColorValue);
			}
			if (p2.BackColorValue != "white")
			{
				z0tek("BackColorValue", p2.BackColorValue);
			}
			if (p2.Alpha != 80)
			{
				z0rek("Alpha", p2.Alpha);
			}
			z0tek("Text", p2.Text);
			if (p2.Repeat)
			{
				z0rek("Repeat", p2.Repeat);
			}
			if (p2.DensityForRepeat != 1f)
			{
				z0rek("DensityForRepeat", p2.DensityForRepeat);
			}
			z0rek("Image", string.Empty, p2.Image, p3: false, p4: false);
			if (p2.Angle != 0f)
			{
				z0rek("Angle", p2.Angle);
			}
			base.z0rek((object?)p2);
		}
	}

	protected internal void z0rek(string p0, string p1, z0ZzZzzej p2, bool p3, bool p4)
	{
		z0iek = z0eek();
		z0ZzZzhqh z0ZzZzhqh2 = z0eek();
		if (p2 != null)
		{
			if (!p4 && !(p2.GetType() == typeof(z0ZzZzzej)))
			{
				throw z0eek(p2);
			}
			z0eek(p0, p1, p2, p3: false, null);
			if (p4)
			{
				z0eek("DCGridLineInfo");
			}
			if (p2.z0uek())
			{
				z0rek("Visible", p2.z0uek());
			}
			if (!p2.z0cek())
			{
				z0rek("AlignToGridLine", p2.z0cek());
			}
			z0tek("ColorValue", p2.z0eek());
			if (p2.z0oek() != 1f)
			{
				z0rek("LineWidth", p2.z0oek());
			}
			if (p2.z0mek() != 0)
			{
				z0rek("GridNumInOnePage", p2.z0mek());
			}
			if (p2.z0xek() != 0f)
			{
				z0rek("GridSpanInCM", p2.z0xek());
			}
			if (p2.z0vek() != DashStyle.Solid)
			{
				z0ZzZzhqh2.z0eek("LineStyle", null, z0rek(p2.z0vek()));
			}
			if (!p2.z0yek())
			{
				z0rek("Printable", p2.z0yek());
			}
			base.z0rek((object?)p2);
		}
	}

	private string z0rek(DCVisibleState p0)
	{
		string text = null;
		return p0 switch
		{
			DCVisibleState.Visible => "Visible", 
			DCVisibleState.Hidden => "Hidden", 
			DCVisibleState.Default => "Default", 
			DCVisibleState.AlwaysVisible => "AlwaysVisible", 
			_ => throw z0ZzZzwhh.z0rek((long)p0, typeof(DCVisibleState)), 
		};
	}

	protected internal void z0rek(string p0, string p1, ValueValidateStyle p2, bool p3, bool p4)
	{
		z0iek = z0eek();
		z0ZzZzhqh z0ZzZzhqh2 = z0eek();
		if (p2 == null)
		{
			return;
		}
		if (!p4 && !(p2.GetType() == typeof(ValueValidateStyle)))
		{
			throw z0eek(p2);
		}
		z0eek(p0, p1, p2, p3: false, null);
		if (p4)
		{
			z0eek("ValueValidateStyle");
		}
		if (p2.Level != ValueValidateLevel.Error)
		{
			z0ZzZzhqh2.z0eek("Level", null, z0rek(p2.Level));
		}
		z0tek("ValueName", p2.ValueName);
		if (p2.Required)
		{
			z0rek("Required", p2.Required);
		}
		if (p2.ValueType != ValueTypeStyle.Text)
		{
			z0ZzZzhqh2.z0eek("ValueType", null, z0rek(p2.ValueType));
		}
		if (p2.BinaryLength)
		{
			z0rek("BinaryLength", p2.BinaryLength);
		}
		if (p2.MaxLength != 0)
		{
			z0rek("MaxLength", p2.MaxLength);
		}
		if (p2.MinLength != 0)
		{
			z0rek("MinLength", p2.MinLength);
		}
		if (p2.CheckMaxValue)
		{
			z0rek("CheckMaxValue", p2.CheckMaxValue);
		}
		if (p2.CheckMinValue)
		{
			z0rek("CheckMinValue", p2.CheckMinValue);
		}
		if (p2.MaxValue != 0.0)
		{
			z0rek("MaxValue", p2.MaxValue);
		}
		if (p2.MinValue != 0.0)
		{
			z0rek("MinValue", p2.MinValue);
		}
		if (p2.CheckDecimalDigits)
		{
			z0rek("CheckDecimalDigits", p2.CheckDecimalDigits);
		}
		if (p2.MaxDecimalDigits != 0)
		{
			z0rek("MaxDecimalDigits", p2.MaxDecimalDigits);
		}
		if (p2.IsDateOrTimeType())
		{
			if (p2.DateTimeMaxValue.Ticks != 624511296000000000L)
			{
				z0rek("DateTimeMaxValue", z0ZzZzkhh.z0eek(p2.DateTimeMaxValue));
			}
			if (p2.DateTimeMinValue.Ticks != 624511296000000000L)
			{
				z0rek("DateTimeMinValue", z0ZzZzkhh.z0eek(p2.DateTimeMinValue));
			}
		}
		z0tek("Range", p2.Range);
		z0tek("RegExpression", p2.RegExpression);
		z0tek("IncludeKeywords", p2.IncludeKeywords);
		z0tek("ExcludeKeywords", p2.ExcludeKeywords);
		z0tek("CustomMessage", p2.CustomMessage);
		if (p2.RequiredInvalidateFlag)
		{
			z0rek("RequiredInvalidateFlag", p2.RequiredInvalidateFlag);
		}
		base.z0rek((object?)p2);
	}

	protected internal void z0rek(string p0, string p1, z0ZzZzvpk p2, bool p3, bool p4)
	{
		z0iek = z0eek();
		z0ZzZzhqh z0ZzZzhqh2 = z0eek();
		if (p2 != null)
		{
			if (!p4 && !(p2.GetType() == typeof(z0ZzZzvpk)))
			{
				throw z0eek(p2);
			}
			z0eek(p0, p1, p2, p3: false, null);
			if (p4)
			{
				z0eek("PageBorderBackgroundStyle");
			}
			if (p2.Index != -1)
			{
				z0ZzZzhqh2.z0eek("Index", p2.Index);
			}
			z0tek("BackgroundColor", p2.BackgroundColorString);
			z0tek("BackgroundColor2", p2.BackgroundColor2String);
			if (p2.Visibility != RenderVisibility.All)
			{
				z0rek("Visibility", string.Empty, z0rek(p2.Visibility));
			}
			z0tek("Color", p2.ColorString);
			z0tek("FontName", p2.FontName);
			if (p2.FontSize != 0f)
			{
				z0rek("FontSize", p2.FontSize);
			}
			if (p2.EmphasisMark)
			{
				z0rek("EmphasisMark", p2.EmphasisMark);
			}
			if (p2.Bold)
			{
				z0rek("Bold", p2.Bold);
			}
			if (p2.Italic)
			{
				z0rek("Italic", p2.Italic);
			}
			if (p2.Underline)
			{
				z0rek("Underline", p2.Underline);
			}
			if (p2.UnderlineStyle != TextUnderlineStyle.Single)
			{
				z0ZzZzhqh2.z0eek("UnderlineStyle", null, z0rek(p2.UnderlineStyle));
			}
			z0tek("UnderlineColor", p2.UnderlineColor);
			if (p2.Strikeout)
			{
				z0rek("Strikeout", p2.Strikeout);
			}
			if (p2.Superscript)
			{
				z0rek("Superscript", p2.Superscript);
			}
			if (p2.Subscript)
			{
				z0rek("Subscript", p2.Subscript);
			}
			if (p2.FixedSpacing)
			{
				z0rek("FixedSpacing", p2.FixedSpacing);
			}
			if (p2.SpacingAfterParagraph != 0f)
			{
				z0rek("SpacingAfterParagraph", p2.SpacingAfterParagraph);
			}
			if (p2.SpacingBeforeParagraph != 0f)
			{
				z0rek("SpacingBeforeParagraph", p2.SpacingBeforeParagraph);
			}
			if (p2.LineSpacingStyle != LineSpacingStyle.SpaceSingle)
			{
				z0ZzZzhqh2.z0eek("LineSpacingStyle", null, z0rek(p2.LineSpacingStyle));
			}
			if (p2.LetterSpacing != 0f)
			{
				z0rek("LetterSpacing", p2.LetterSpacing);
			}
			if (p2.LineSpacing != 0f)
			{
				z0rek("LineSpacing", p2.LineSpacing);
			}
			if (p2.RTFLineSpacing != 0f)
			{
				z0rek("RTFLineSpacing", p2.RTFLineSpacing);
			}
			if (p2.Align != DocumentContentAlignment.Left)
			{
				z0ZzZzhqh2.z0eek("Align", null, z0rek(p2.Align));
			}
			if (p2.VerticalAlign != VerticalAlignStyle.Top)
			{
				z0ZzZzhqh2.z0eek("VerticalAlign", null, z0rek(p2.VerticalAlign));
			}
			if (p2.FirstLineIndent != 0f)
			{
				z0rek("FirstLineIndent", p2.FirstLineIndent);
			}
			if (p2.LeftIndent != 0f)
			{
				z0rek("LeftIndent", p2.LeftIndent);
			}
			if (p2.RightToLeft)
			{
				z0rek("RightToLeft", p2.RightToLeft);
			}
			if (p2.Multiline)
			{
				z0rek("Multiline", p2.Multiline);
			}
			if (p2.LayoutAlign != ContentLayoutAlign.EmbedInText)
			{
				z0ZzZzhqh2.z0eek("LayoutAlign", null, z0rek(p2.LayoutAlign));
			}
			if (p2.CharacterCircle != CharacterCircleStyles.None)
			{
				z0ZzZzhqh2.z0eek("CharacterCircle", null, z0rek(p2.CharacterCircle));
			}
			z0tek("BorderLeftColor", p2.BorderLeftColorString);
			z0tek("BorderTopColor", p2.BorderTopColorString);
			z0tek("BorderRightColor", p2.BorderRightColorString);
			z0tek("BorderBottomColor", p2.BorderBottomColorString);
			if (p2.BorderStyle != DashStyle.Solid)
			{
				z0ZzZzhqh2.z0eek("BorderStyle", null, z0rek(p2.BorderStyle));
			}
			if (p2.BorderWidth != 0f)
			{
				z0rek("BorderWidth", p2.BorderWidth);
			}
			if (p2.BorderLeft)
			{
				z0rek("BorderLeft", p2.BorderLeft);
			}
			if (p2.BorderBottom)
			{
				z0rek("BorderBottom", p2.BorderBottom);
			}
			if (p2.BorderTop)
			{
				z0rek("BorderTop", p2.BorderTop);
			}
			if (p2.BorderRight)
			{
				z0rek("BorderRight", p2.BorderRight);
			}
			if (p2.BorderSpacing != 0f)
			{
				z0rek("BorderSpacing", p2.BorderSpacing);
			}
			if (p2.MarginLeft != 0f)
			{
				z0rek("MarginLeft", p2.MarginLeft);
			}
			if (p2.MarginTop != 0f)
			{
				z0rek("MarginTop", p2.MarginTop);
			}
			if (p2.MarginRight != 0f)
			{
				z0rek("MarginRight", p2.MarginRight);
			}
			if (p2.MarginBottom != 0f)
			{
				z0rek("MarginBottom", p2.MarginBottom);
			}
			if (p2.PaddingLeft != 0f)
			{
				z0rek("PaddingLeft", p2.PaddingLeft);
			}
			if (p2.PaddingTop != 0f)
			{
				z0rek("PaddingTop", p2.PaddingTop);
			}
			if (p2.PaddingRight != 0f)
			{
				z0rek("PaddingRight", p2.PaddingRight);
			}
			if (p2.PaddingBottom != 0f)
			{
				z0rek("PaddingBottom", p2.PaddingBottom);
			}
			if (p2.ParagraphMultiLevel)
			{
				z0rek("ParagraphMultiLevel", p2.ParagraphMultiLevel);
			}
			if (p2.ParagraphOutlineLevel != -1)
			{
				z0rek("ParagraphOutlineLevel", p2.ParagraphOutlineLevel);
			}
			if (!p2.VisibleInDirectory)
			{
				z0rek("VisibleInDirectory", p2.VisibleInDirectory);
			}
			if (p2.ParagraphListStyle != ParagraphListStyle.None)
			{
				z0ZzZzhqh2.z0eek("ParagraphListStyle", null, z0rek(p2.ParagraphListStyle));
			}
			if (p2.z0eek() != PageBorderRangeTypes.None)
			{
				z0ZzZzhqh2.z0eek("BorderRange", null, z0rek(p2.z0eek()));
			}
			base.z0rek((object?)p2);
		}
	}

	private string z0rek(InputFieldAdornTextType p0)
	{
		string text = null;
		return p0 switch
		{
			InputFieldAdornTextType.Default => "Default", 
			InputFieldAdornTextType.DataSource => "DataSource", 
			InputFieldAdornTextType.ToolTip => "ToolTip", 
			InputFieldAdornTextType.ValidateMessage => "ValidateMessage", 
			InputFieldAdornTextType.ID => "ID", 
			InputFieldAdornTextType.Name => "Name", 
			InputFieldAdornTextType.TabIndex => "TabIndex", 
			_ => throw z0ZzZzwhh.z0rek((long)p0, typeof(InputFieldAdornTextType)), 
		};
	}

	private string z0rek(DCDuplexType p0)
	{
		string text = null;
		return p0 switch
		{
			DCDuplexType.NoSpecify => "NoSpecify", 
			DCDuplexType.Default => "Default", 
			DCDuplexType.Horizontal => "Horizontal", 
			DCDuplexType.Simplex => "Simplex", 
			DCDuplexType.Vertical => "Vertical", 
			_ => throw z0ZzZzwhh.z0rek((long)p0, typeof(DCDuplexType)), 
		};
	}

	protected internal void z0rek(string p0, string p1, XTextLineBreakElement p2, bool p3, bool p4)
	{
		z0iek = z0eek();
		z0ZzZzhqh z0ZzZzhqh2 = z0eek();
		if (p2 != null)
		{
			if (!p4 && !(p2.GetType() == typeof(XTextLineBreakElement)))
			{
				throw z0eek(p2);
			}
			z0eek(p0, p1, p2, p3: false, null);
			if (p4)
			{
				z0eek("XLineBreak");
			}
			if (p2.z0pek() != -1)
			{
				z0ZzZzhqh2.z0eek("StyleIndex", p2.z0pek());
			}
			z0rek(z0ZzZzhqh2, p2.Attributes);
			z0tek("ID", p2.ID);
			base.z0rek((object?)p2);
		}
	}

	private string z0rek(ContentAlignment p0)
	{
		string text = null;
		return p0 switch
		{
			ContentAlignment.TopLeft => "TopLeft", 
			ContentAlignment.TopCenter => "TopCenter", 
			ContentAlignment.TopRight => "TopRight", 
			ContentAlignment.MiddleLeft => "MiddleLeft", 
			ContentAlignment.MiddleCenter => "MiddleCenter", 
			ContentAlignment.MiddleRight => "MiddleRight", 
			ContentAlignment.BottomLeft => "BottomLeft", 
			ContentAlignment.BottomCenter => "BottomCenter", 
			ContentAlignment.BottomRight => "BottomRight", 
			_ => throw z0ZzZzwhh.z0rek((long)p0, typeof(ContentAlignment)), 
		};
	}

	private string z0rek(DCSignRange p0)
	{
		string text = null;
		return p0 switch
		{
			DCSignRange.None => "None", 
			DCSignRange.Parent => "Parent", 
			DCSignRange.InputField => "InputField", 
			DCSignRange.TableCell => "TableCell", 
			DCSignRange.TableRow => "TableRow", 
			DCSignRange.Table => "Table", 
			DCSignRange.Section => "Section", 
			DCSignRange.Body => "Body", 
			DCSignRange.Document => "Document", 
			_ => throw z0ZzZzwhh.z0rek((long)p0, typeof(DCSignRange)), 
		};
	}

	protected internal void z0rek(string p0, string p1, XTextTableCellElement p2, bool p3, bool p4)
	{
		z0iek = z0eek();
		z0ZzZzhqh z0ZzZzhqh2 = z0eek();
		if (p2 != null)
		{
			if (!p4 && !(p2.GetType() == typeof(XTextTableCellElement)))
			{
				throw z0eek(p2);
			}
			z0eek(p0, p1, p2, p3: false, null);
			if (p4)
			{
				z0eek("XTextTableCell");
			}
			if (((XTextElement)p2).z0pek() != -1)
			{
				z0ZzZzhqh2.z0eek("StyleIndex", ((XTextElement)p2).z0pek());
			}
			if (p2.z0bek())
			{
				z0ZzZzhqh2.z0eek("C", "1");
			}
			z0rek(z0ZzZzhqh2, p2.Attributes);
			z0tek("ID", p2.ID);
			z0tek("LimitedInputChars", p2.LimitedInputChars);
			if (p2.HiddenPrintWhenEmpty)
			{
				z0rek("HiddenPrintWhenEmpty", p2.HiddenPrintWhenEmpty);
			}
			if (p2.MaxInputLength != 0)
			{
				z0rek("MaxInputLength", p2.MaxInputLength);
			}
			z0tek("DataName", p2.z0ht());
			if (p2.z0gt())
			{
				z0rek("CanBeReferenced", p2.z0gt());
			}
			if (p2.z0dt())
			{
				z0rek("BringoutToSave", p2.z0dt());
			}
			z0tek("ToolTip", p2.ToolTip);
			if (p2.AcceptTab)
			{
				z0rek("AcceptTab", p2.AcceptTab);
			}
			z0rek(z0ZzZzhqh2, p2.PropertyExpressions);
			if (p2.EnableValueValidate)
			{
				z0rek("EnableValueValidate", p2.EnableValueValidate);
			}
			z0rek("ValidateStyle", string.Empty, p2.ValidateStyle, p3: false, p4: false);
			z0rek("ValueBinding", string.Empty, p2.ValueBinding, p3: false, p4: false);
			z0tek("DefaultValueForValueBinding", ((XTextContainerElement)p2).z0nrk());
			z0tek("ContentReadonlyExpression", p2.ContentReadonlyExpression);
			z0tek("VisibleExpression", p2.VisibleExpression);
			z0tek("PrintVisibilityExpression", p2.PrintVisibilityExpression);
			z0tek("ValueExpression", p2.ValueExpression);
			if (p2.EnablePermission != DCBooleanValue.Inherit)
			{
				z0ZzZzhqh2.z0eek("EnablePermission", null, z0rek(p2.EnablePermission));
			}
			z0rek("ContentLock", string.Empty, p2.ContentLock, p3: false, p4: false);
			if (p2.ContentReadonly != ContentReadonlyState.Inherit)
			{
				z0ZzZzhqh2.z0eek("ContentReadonly", null, z0rek(p2.ContentReadonly));
			}
			z0rek("CopySource", string.Empty, p2.CopySource, p3: false, p4: false);
			z0rek(p2);
			if (p2.AcceptChildElementTypes2 != ElementType.All)
			{
				z0rek("AcceptChildElementTypes2", string.Empty, z0rek(p2.AcceptChildElementTypes2));
			}
			if (p2.PrintVisibility != ElementVisibility.Visible)
			{
				z0ZzZzhqh2.z0eek("PrintVisibility", null, z0rek(p2.PrintVisibility));
			}
			if (!p2.Visible)
			{
				z0rek("Visible", p2.Visible);
			}
			if (!p2.Deleteable)
			{
				z0rek("Deleteable", p2.Deleteable);
			}
			z0rek("GridLine", string.Empty, p2.GridLine, p3: false, p4: false);
			if (p2.SpecifyFixedLineHeight != 0f)
			{
				z0rek("SpecifyFixedLineHeight", p2.SpecifyFixedLineHeight);
			}
			if (!p2.z0mek())
			{
				z0rek("TabStop", p2.z0mek());
			}
			if (p2.BorderPrintedWhenJumpPrint)
			{
				z0rek("BorderPrintedWhenJumpPrint", p2.BorderPrintedWhenJumpPrint);
			}
			if (p2.z0rek())
			{
				z0rek("StressBorder", p2.z0rek());
			}
			if (p2.AutoFixFontSizeMode != ContentAutoFixFontSizeMode.None)
			{
				z0ZzZzhqh2.z0eek("AutoFixFontSizeMode", null, z0rek(p2.AutoFixFontSizeMode));
			}
			if (p2.z0wrk())
			{
				z0rek("AutoFixFontSize", p2.z0wrk());
			}
			if (p2.MoveFocusHotKey != MoveFocusHotKeys.Tab)
			{
				z0rek("MoveFocusHotKey", string.Empty, z0rek(p2.MoveFocusHotKey));
			}
			if (p2.SlantSplitLineStyle != RectangleSlantSplitStyle.None)
			{
				z0ZzZzhqh2.z0eek("SlantSplitLineStyle", null, z0rek(p2.SlantSplitLineStyle));
			}
			if (p2.RowSpan != 1)
			{
				z0rek("RowSpan", p2.RowSpan);
			}
			if (p2.ColSpan != 1)
			{
				z0rek("ColSpan", p2.ColSpan);
			}
			z0tek("Expression", p2.z0cek());
			if (p2.MirrorViewForCrossPage)
			{
				z0rek("MirrorViewForCrossPage", p2.MirrorViewForCrossPage);
			}
			if (p2.CloneType != TableRowCloneType.Default)
			{
				z0ZzZzhqh2.z0eek("CloneType", null, z0rek(p2.CloneType));
			}
			base.z0rek((object?)p2);
		}
	}

	private string z0rek(z0ZzZzrxj p0)
	{
		string text = null;
		return p0 switch
		{
			(z0ZzZzrxj)0 => "AutoDetect", 
			(z0ZzZzrxj)1 => "Control", 
			(z0ZzZzrxj)2 => "OCX", 
			(z0ZzZzrxj)3 => "NativeWinControl", 
			(z0ZzZzrxj)4 => "WPF", 
			(z0ZzZzrxj)5 => "DocumentImage", 
			(z0ZzZzrxj)6 => "InvalidateType", 
			_ => throw z0ZzZzwhh.z0rek((long)p0, typeof(z0ZzZzrxj)), 
		};
	}

	private string z0rek(DCGutterStyle p0)
	{
		string text = null;
		return p0 switch
		{
			DCGutterStyle.Left => "Left", 
			DCGutterStyle.Top => "Top", 
			DCGutterStyle.Right => "Right", 
			_ => throw z0ZzZzwhh.z0rek((long)p0, typeof(DCGutterStyle)), 
		};
	}

	protected internal void z0rek(string p0, string p1, XTextControlHostElement p2, bool p3, bool p4)
	{
		z0iek = z0eek();
		z0ZzZzhqh z0ZzZzhqh2 = z0eek();
		if (p2 == null)
		{
			return;
		}
		if (!p4)
		{
			Type type = p2.GetType();
			if (!(type == typeof(XTextControlHostElement)))
			{
				if (type == typeof(XTextMediaElement))
				{
					z0rek(p0, p1, (XTextMediaElement)p2, p3, p4: true);
					return;
				}
				throw z0eek(p2);
			}
		}
		z0eek(p0, p1, p2, p3: false, null);
		if (p4)
		{
			z0eek("XTextControlHost");
		}
		if (((XTextElement)p2).z0pek() != -1)
		{
			z0ZzZzhqh2.z0eek("StyleIndex", ((XTextElement)p2).z0pek());
		}
		z0rek(z0ZzZzhqh2, p2.Attributes);
		z0tek("ID", p2.ID);
		z0tek("ToolTip", p2.ToolTip);
		if (p2.OffsetX != 0f)
		{
			z0rek("OffsetX", p2.OffsetX);
		}
		if (p2.OffsetY != 0f)
		{
			z0rek("OffsetY", p2.OffsetY);
		}
		if (p2.ZOrderStyle != ElementZOrderStyle.Normal)
		{
			z0ZzZzhqh2.z0eek("ZOrderStyle", null, z0rek(p2.ZOrderStyle));
		}
		z0rek(z0ZzZzhqh2, p2.PropertyExpressions);
		z0tek("ValueExpression", p2.ValueExpression);
		if (!p2.Visible)
		{
			z0rek("Visible", p2.Visible);
		}
		if (p2.PrintVisibility != ElementVisibility.Visible)
		{
			z0ZzZzhqh2.z0eek("PrintVisibility", null, z0rek(p2.PrintVisibility));
		}
		z0rek("LinkInfo", string.Empty, ((XTextObjectElement)p2).z0iek(), p3: false, p4: false);
		if (p2.ContentReadonly != ContentReadonlyState.Inherit)
		{
			z0ZzZzhqh2.z0eek("ContentReadonly", null, z0rek(p2.ContentReadonly));
		}
		if (!p2.Deleteable)
		{
			z0rek("Deleteable", p2.Deleteable);
		}
		z0tek("Name", p2.Name);
		if (!p2.Enabled)
		{
			z0rek("Enabled", p2.Enabled);
		}
		z0tek("StringTag", p2.StringTag);
		if (p2.DelayLoadControl)
		{
			z0rek("DelayLoadControl", p2.DelayLoadControl);
		}
		if (p2.VAlign != VerticalAlignStyle.Top)
		{
			z0ZzZzhqh2.z0eek("VAlign", null, z0rek(p2.VAlign));
		}
		if (p2.z0ry() != 0)
		{
			z0ZzZzhqh2.z0eek("ControlType", null, z0rek(p2.z0ry()));
		}
		z0tek("TypeFullName", p2.TypeFullName);
		z0tek("ValuePropertyName", p2.ValuePropertyName);
		if (p2.z0uek() != (z0ZzZzgzj)2)
		{
			z0ZzZzhqh2.z0eek("HostMode", null, z0rek(p2.z0uek()));
		}
		if (p2.AllowUserResize != ResizeableType.WidthAndHeight)
		{
			z0ZzZzhqh2.z0eek("AllowUserResize", null, z0rek(p2.AllowUserResize));
		}
		ObjectParameterList parameters = p2.Parameters;
		if (parameters != null && parameters.Count > 0)
		{
			int count = parameters.Count;
			z0ZzZzhqh2.z0hf(null, "Parameters", null);
			for (int i = 0; i < count; i++)
			{
				z0rek("Parameter", string.Empty, parameters[i], p3: true, p4: false);
			}
			z0ZzZzhqh2.z0bg();
		}
		if (p2.z0yek())
		{
			z0rek("SavePreviewImage", p2.z0yek());
		}
		z0rek("PreviewImageData", string.Empty, z0ZzZzkhh.z0eek(p2.z0tek()));
		z0rek("Width", p2.Width);
		z0rek("Height", p2.Height);
		z0tek("OptionsPropertyName", p2.z0iek());
		z0tek("Text", p2.Text);
		base.z0rek((object?)p2);
	}

	protected internal void z0rek(string p0, string p1, z0ZzZzymk p2, bool p3, bool p4)
	{
		z0iek = z0eek();
		if (p2 != null)
		{
			if (!p4 && !(p2.GetType() == typeof(z0ZzZzymk)))
			{
				throw z0eek(p2);
			}
			z0eek(p0, p1, p2, p3: false, null);
			if (p4)
			{
				z0eek("XColorValue");
			}
			if (p2.StringValue != null)
			{
				base.z0rek(p2.StringValue);
			}
			base.z0rek((object?)p2);
		}
	}

	protected internal void z0rek(string p0, string p1, XPageSettings p2, bool p3, bool p4)
	{
		z0iek = z0eek();
		z0ZzZzhqh z0ZzZzhqh2 = z0eek();
		if (p2 != null)
		{
			if (!p4 && !(p2.GetType() == typeof(XPageSettings)))
			{
				throw z0eek(p2);
			}
			z0eek(p0, p1, p2, p3: false, null);
			if (p4)
			{
				z0eek("XPageSettings");
			}
			if (p2.z0grk() != 1)
			{
				z0rek("JointPrintNumber", p2.z0grk());
			}
			if (p2.z0zek() != 1f)
			{
				z0rek("PrintZoomRate", p2.z0zek());
			}
			if (!p2.z0nek())
			{
				z0rek("SwapGutter", p2.z0nek());
			}
			if (p2.z0erk() != 0f)
			{
				z0rek("GutterPosition", p2.z0erk());
			}
			if (p2.z0xtk() != DCGutterStyle.Left)
			{
				z0ZzZzhqh2.z0eek("GutterStyle", null, z0rek(p2.z0xtk()));
			}
			if (p2.z0otk())
			{
				z0rek("ShowGutterLine", p2.z0otk());
			}
			if (p2.z0itk())
			{
				z0rek("SwapLeftRightMargin", p2.z0itk());
			}
			if (!p2.z0mek())
			{
				z0rek("EnableHeaderFooter", p2.z0mek());
			}
			if (p2.z0ktk())
			{
				z0rek("HeaderFooterDifferentFirstPage", p2.z0ktk());
			}
			if (p2.z0zrk() != DCDuplexType.NoSpecify)
			{
				z0ZzZzhqh2.z0eek("SpecifyDuplex", null, z0rek(p2.z0zrk()));
			}
			if (p2.z0uek())
			{
				z0rek("PowerDocumentGridLine", p2.z0uek());
			}
			z0rek("DocumentGridLine", string.Empty, p2.DocumentGridLine, p3: false, p4: false);
			z0rek("TerminalText", string.Empty, p2.z0xek(), p3: false, p4: false);
			if (!p2.z0tek())
			{
				z0rek("AutoChoosePageSize", p2.z0tek());
			}
			z0tek("PageIndexsForHideHeaderFooter", p2.z0urk());
			z0rek("PageBorderBackground", string.Empty, p2.PageBorderBackground, p3: false, p4: false);
			if (p2.z0vek())
			{
				z0rek("ForPOSPrinter", p2.z0vek());
			}
			if (p2.z0gtk() != 0f)
			{
				z0rek("OffsetX", p2.z0gtk());
			}
			if (p2.z0srk() != 0f)
			{
				z0rek("OffsetY", p2.z0srk());
			}
			z0tek("PrinterName", p2.z0vrk());
			z0rek("Watermark", string.Empty, p2.z0jrk(), p3: false, p4: false);
			z0tek("PageIndexsForPrintBackgroundImage", p2.z0irk());
			z0tek("PageIndexsForShowBackgroundImage", p2.z0mtk());
			z0rek("EditTimeBackgroundImage", string.Empty, p2.z0ark(), p3: false, p4: false);
			z0tek("PaperSource", p2.z0cek());
			if (p2.z0yrk() != PaperKind.A4)
			{
				z0ZzZzhqh2.z0eek("PaperKind", null, z0rek(p2.z0yrk()));
			}
			if (p2.z0ltk())
			{
				z0rek("AutoPaperWidth", p2.z0ltk());
			}
			if (p2.z0yek())
			{
				z0rek("AutoFitPageSize", p2.z0yek());
			}
			if (p2.z0brk() != 1)
			{
				z0rek("Copies", p2.z0brk());
			}
			if (p2.z0pek() != 50)
			{
				z0rek("HeaderDistance", p2.z0pek());
			}
			if (p2.z0utk() != 50)
			{
				z0rek("FooterDistance", p2.z0utk());
			}
			if (p2.z0rtk() != 0)
			{
				z0rek("DesignerPaperWidth", p2.z0rtk());
			}
			if (p2.z0ntk() != 827)
			{
				z0rek("PaperWidth", p2.z0ntk());
			}
			if (p2.z0crk() != 0)
			{
				z0rek("DesignerPaperHeight", p2.z0crk());
			}
			if (p2.z0jtk() != 1169)
			{
				z0rek("PaperHeight", p2.z0jtk());
			}
			if (p2.LeftMargin != 100)
			{
				z0rek("LeftMargin", p2.LeftMargin);
			}
			if (p2.TopMargin != 100)
			{
				z0rek("TopMargin", p2.TopMargin);
			}
			if (p2.RightMargin != 100)
			{
				z0rek("RightMargin", p2.RightMargin);
			}
			if (p2.BottomMargin != 100)
			{
				z0rek("BottomMargin", p2.BottomMargin);
			}
			if (p2.z0ork())
			{
				z0rek("Landscape", p2.z0ork());
			}
			if (p2.z0ftk())
			{
				z0rek("StrictUsePageSize", p2.z0ftk());
			}
			base.z0rek((object?)p2);
		}
	}

	protected internal void z0rek(string p0, string p1, z0ZzZzbtk p2, bool p3, bool p4)
	{
		z0iek = z0eek();
		z0ZzZzhqh z0ZzZzhqh2 = z0eek();
		if (p2 == null)
		{
			return;
		}
		if (!p4 && !(p2.GetType() == typeof(z0ZzZzbtk)))
		{
			throw z0eek(p2);
		}
		z0eek(p0, p1, p2, p3: false, null);
		if (p4)
		{
			z0eek("ColorTheme");
		}
		if (p2.z0rek() != ColorThemeType.Default)
		{
			z0ZzZzhqh2.z0eek("ThemeType", null, z0rek(p2.z0rek()));
		}
		List<z0ZzZzymk> list = p2.z0tek();
		if (list != null && list.Count > 0)
		{
			int count = list.Count;
			z0ZzZzhqh2.z0hf(null, "Colors", null);
			for (int i = 0; i < count; i++)
			{
				z0rek("Color", string.Empty, list[i], p3: true, p4: false);
			}
			z0ZzZzhqh2.z0bg();
		}
		if (p2.z0iek() != 1)
		{
			z0rek("ShadeCount", p2.z0iek());
		}
		if (p2.z0uek() != 0.5f)
		{
			z0rek("LightCorrectionFactor", p2.z0uek());
		}
		base.z0rek((object?)p2);
	}

	private string z0rek(z0ZzZzgzj p0)
	{
		string text = null;
		return p0 switch
		{
			(z0ZzZzgzj)0 => "Disable", 
			(z0ZzZzgzj)1 => "Static", 
			(z0ZzZzgzj)2 => "Dynamic", 
			_ => throw z0ZzZzwhh.z0rek((long)p0, typeof(z0ZzZzgzj)), 
		};
	}

	protected internal void z0rek(string p0, string p1, InputFieldSettings p2, bool p3, bool p4)
	{
		z0iek = z0eek();
		z0ZzZzhqh z0ZzZzhqh2 = z0eek();
		if (p2 != null)
		{
			if (!p4 && !(p2.GetType() == typeof(InputFieldSettings)))
			{
				throw z0eek(p2);
			}
			z0eek(p0, p1, p2, p3: false, null);
			if (p4)
			{
				z0eek("InputFieldSettings");
			}
			if (p2.z0iek())
			{
				z0rek("GetValueOrderByTime", p2.z0iek());
			}
			if (p2.z0nek() != InputFieldEditStyle.Text)
			{
				z0ZzZzhqh2.z0eek("EditStyle", null, z0rek(p2.z0nek()));
			}
			if (p2.z0bek())
			{
				z0rek("MultiColumn", p2.z0bek());
			}
			if (p2.z0xek())
			{
				z0rek("RepulsionForGroup", p2.z0xek());
			}
			if (p2.z0yek())
			{
				z0rek("MultiSelect", p2.z0yek());
			}
			if (p2.z0uek())
			{
				z0rek("DynamicListItems", p2.z0uek());
			}
			z0rek("ListSource", string.Empty, p2.z0zek(), p3: false, p4: false);
			z0tek("ListValueFormatString", p2.z0tek());
			if (p2.z0oek() != ",")
			{
				z0tek("ListValueSeparatorChar", p2.z0oek());
			}
			base.z0rek((object?)p2);
		}
	}

	protected internal void z0rek(string p0, string p1, PageLabelText p2, bool p3, bool p4)
	{
		z0iek = z0eek();
		if (p2 != null)
		{
			if (!p4 && !(p2.GetType() == typeof(PageLabelText)))
			{
				throw z0eek(p2);
			}
			z0eek(p0, p1, p2, p3: false, null);
			if (p4)
			{
				z0eek("PageLabelText");
			}
			if (p2.PageIndex != 0)
			{
				z0rek("PageIndex", p2.PageIndex);
			}
			z0tek("Text", p2.Text);
			base.z0rek((object?)p2);
		}
	}

	private void z0rek(string p0, double p1)
	{
		z0iek.z0tek(p0, null);
		z0iek.z0og(z0ZzZzhah.z0rek(p1));
		z0iek.z0bg();
	}

	protected internal void z0rek(string p0, string p1, z0ZzZzsok p2, bool p3, bool p4)
	{
		z0iek = z0eek();
		z0ZzZzhqh z0ZzZzhqh2 = z0eek();
		if (p2 != null)
		{
			if (!p4 && !(p2.GetType() == typeof(z0ZzZzsok)))
			{
				throw z0eek(p2);
			}
			z0eek(p0, p1, p2, p3: false, null);
			if (p4)
			{
				z0eek("ValueFormater");
			}
			if (p2.Style != ValueFormatStyle.None)
			{
				z0ZzZzhqh2.z0eek("Style", null, z0rek(p2.Style));
			}
			z0tek("Format", p2.Format);
			z0tek("NoneText", p2.NoneText);
			base.z0rek((object?)p2);
		}
	}

	protected internal void z0rek(string p0, string p1, z0ZzZzqtk p2, bool p3, bool p4)
	{
		z0iek = z0eek();
		z0ZzZzhqh z0ZzZzhqh2 = z0eek();
		if (p2 == null)
		{
			return;
		}
		if (!p4 && !(p2.GetType() == typeof(z0ZzZzqtk)))
		{
			throw z0eek(p2);
		}
		z0eek(p0, p1, p2, p3: false, null);
		if (p4)
		{
			z0eek("ChartDocumentStyle");
		}
		z0eek("TextColorValue", p2.z0oek());
		if (p2.z0urk() != 0)
		{
			z0rek("PaddingLeft", p2.z0urk());
		}
		if (p2.z0drk() != 0)
		{
			z0rek("PaddingTop", p2.z0drk());
		}
		if (p2.z0zek() != 0)
		{
			z0rek("PaddingRight", p2.z0zek());
		}
		if (p2.z0lrk() != 0)
		{
			z0rek("PaddingBottom", p2.z0lrk());
		}
		if (p2.z0ork() != 1.0)
		{
			z0rek("BarOpacity", p2.z0ork());
		}
		if (p2.z0pek() != 50)
		{
			z0rek("BarWidth", p2.z0pek());
		}
		if (p2.z0vek() != 0)
		{
			z0rek("BarSpacing", p2.z0vek());
		}
		if (p2.z0ktk() != 20)
		{
			z0rek("BarGroupSpacing", p2.z0ktk());
		}
		if (p2.z0dtk() != ChartViewStyle.Bar)
		{
			z0ZzZzhqh2.z0eek("ViewStyle", null, z0rek(p2.z0dtk()));
		}
		if (p2.z0krk() != 10)
		{
			z0rek("GridYSplitNum", p2.z0krk());
		}
		z0rek("CustomColorThemeH", string.Empty, p2.z0yek(), p3: false, p4: false);
		z0rek("GridLineStyleH", string.Empty, p2.z0iek(), p3: false, p4: false);
		if (p2.z0irk() != 100)
		{
			z0rek("GridTextWidth", p2.z0irk());
		}
		if (p2.z0zrk() != 60)
		{
			z0rek("GridTextHeight", p2.z0zrk());
		}
		if (!p2.z0xek())
		{
			z0rek("GroupGridLine", p2.z0xek());
		}
		z0tek("GridValueFormat", p2.z0srk());
		z0rek("GridBackground", string.Empty, p2.z0wrk(), p3: false, p4: false);
		if (p2.z0ark() != AxisCompressStyle.AutoSize)
		{
			z0ZzZzhqh2.z0eek("AxisCompress", null, z0rek(p2.z0ark()));
		}
		if (p2.z0uek() != 0f)
		{
			z0rek("Thickness", p2.z0uek());
		}
		if (p2.z0rek() != 0)
		{
			z0rek("GridLineOffsetX", p2.z0rek());
		}
		if (p2.z0frk() != 0)
		{
			z0rek("GridLineOffsetY", p2.z0frk());
		}
		if (p2.z0cek() != 45f)
		{
			z0rek("Angle", p2.z0cek());
		}
		if (p2.z0nrk() != StringAlignment.Near)
		{
			z0ZzZzhqh2.z0eek("VerticalTextAlign", null, z0rek(p2.z0nrk()));
		}
		if (p2.z0nek() != StringAlignment.Center)
		{
			z0ZzZzhqh2.z0eek("HorizontalTextAlign", null, z0rek(p2.z0nek()));
		}
		if (p2.z0jtk())
		{
			z0rek("VerticalXLabel", p2.z0jtk());
		}
		z0rek("GridBorderLineStyle", string.Empty, p2.z0xrk(), p3: false, p4: false);
		z0ZzZzatk z0ZzZzatk2 = p2.z0mek();
		if (z0ZzZzatk2 != null && z0ZzZzatk2.Count > 0)
		{
			int count = z0ZzZzatk2.Count;
			z0ZzZzhqh2.z0hf(null, "YAxisCaptions", null);
			for (int i = 0; i < count; i++)
			{
				z0rek("ChartCaptionStyle", string.Empty, z0ZzZzatk2[i], p3: true, p4: false);
			}
			z0ZzZzhqh2.z0bg();
		}
		z0rek("XAxisCaption", string.Empty, p2.z0eek(), p3: false, p4: false);
		z0rek("Caption", string.Empty, p2.z0jrk(), p3: false, p4: false);
		z0rek("LegendStyle", string.Empty, p2.z0erk(), p3: false, p4: false);
		z0rek("GridLineStyle", string.Empty, p2.z0ltk(), p3: false, p4: false);
		z0rek("LabelStyle", string.Empty, p2.z0grk(), p3: false, p4: false);
		z0rek("Font", p2.z0gtk());
		if (p2.z0vrk() != 0f)
		{
			z0rek("RipenessRate", p2.z0vrk());
		}
		z0rek("BarBorderPen", string.Empty, p2.z0qrk(), p3: false, p4: false);
		if (p2.z0htk() != ColorThemeType.Default)
		{
			z0ZzZzhqh2.z0eek("ColorTheme", null, z0rek(p2.z0htk()));
		}
		z0rek("CustomColorTheme", string.Empty, p2.z0brk(), p3: false, p4: false);
		base.z0rek((object?)p2);
	}

	private string z0rek(RangeCalculateStyle p0)
	{
		string text = null;
		return p0 switch
		{
			RangeCalculateStyle.None => "None", 
			RangeCalculateStyle.AutoMaxValue => "AutoMaxValue", 
			RangeCalculateStyle.AutoMinValue => "AutoMinValue", 
			RangeCalculateStyle.AutoMaxMinValue => "AutoMaxMinValue", 
			_ => throw z0ZzZzwhh.z0rek((long)p0, typeof(RangeCalculateStyle)), 
		};
	}

	protected internal void z0rek(string p0, string p1, z0ZzZzcok p2, bool p3, bool p4)
	{
		z0iek = z0eek();
		z0ZzZzhqh z0ZzZzhqh2 = z0eek();
		if (p2 == null)
		{
			return;
		}
		if (!p4)
		{
			Type type = p2.GetType();
			if (!(type == typeof(z0ZzZzcok)))
			{
				if (type == typeof(z0ZzZzvpk))
				{
					z0rek(p0, p1, (z0ZzZzvpk)p2, p3, p4: true);
					return;
				}
				if (type == typeof(DocumentContentStyle))
				{
					z0rek(p0, p1, (DocumentContentStyle)p2, p3, p4: true);
					return;
				}
				throw z0eek(p2);
			}
		}
		z0eek(p0, p1, p2, p3: false, null);
		if (p4)
		{
			z0eek("ContentStyle");
		}
		if (p2.Index != -1)
		{
			z0ZzZzhqh2.z0eek("Index", p2.Index);
		}
		z0tek("BackgroundColor", p2.BackgroundColorString);
		z0tek("BackgroundColor2", p2.BackgroundColor2String);
		if (p2.Visibility != RenderVisibility.All)
		{
			z0rek("Visibility", string.Empty, z0rek(p2.Visibility));
		}
		z0tek("Color", p2.ColorString);
		z0tek("FontName", p2.FontName);
		if (p2.FontSize != 0f)
		{
			z0rek("FontSize", p2.FontSize);
		}
		if (p2.EmphasisMark)
		{
			z0rek("EmphasisMark", p2.EmphasisMark);
		}
		if (p2.Bold)
		{
			z0rek("Bold", p2.Bold);
		}
		if (p2.Italic)
		{
			z0rek("Italic", p2.Italic);
		}
		if (p2.Underline)
		{
			z0rek("Underline", p2.Underline);
		}
		if (p2.UnderlineStyle != TextUnderlineStyle.Single)
		{
			z0ZzZzhqh2.z0eek("UnderlineStyle", null, z0rek(p2.UnderlineStyle));
		}
		z0tek("UnderlineColor", p2.UnderlineColor);
		if (p2.Strikeout)
		{
			z0rek("Strikeout", p2.Strikeout);
		}
		if (p2.Superscript)
		{
			z0rek("Superscript", p2.Superscript);
		}
		if (p2.Subscript)
		{
			z0rek("Subscript", p2.Subscript);
		}
		if (p2.FixedSpacing)
		{
			z0rek("FixedSpacing", p2.FixedSpacing);
		}
		if (p2.SpacingAfterParagraph != 0f)
		{
			z0rek("SpacingAfterParagraph", p2.SpacingAfterParagraph);
		}
		if (p2.SpacingBeforeParagraph != 0f)
		{
			z0rek("SpacingBeforeParagraph", p2.SpacingBeforeParagraph);
		}
		if (p2.LineSpacingStyle != LineSpacingStyle.SpaceSingle)
		{
			z0ZzZzhqh2.z0eek("LineSpacingStyle", null, z0rek(p2.LineSpacingStyle));
		}
		if (p2.LetterSpacing != 0f)
		{
			z0rek("LetterSpacing", p2.LetterSpacing);
		}
		if (p2.LineSpacing != 0f)
		{
			z0rek("LineSpacing", p2.LineSpacing);
		}
		if (p2.RTFLineSpacing != 0f)
		{
			z0rek("RTFLineSpacing", p2.RTFLineSpacing);
		}
		if (p2.Align != DocumentContentAlignment.Left)
		{
			z0ZzZzhqh2.z0eek("Align", null, z0rek(p2.Align));
		}
		if (p2.VerticalAlign != VerticalAlignStyle.Top)
		{
			z0ZzZzhqh2.z0eek("VerticalAlign", null, z0rek(p2.VerticalAlign));
		}
		if (p2.FirstLineIndent != 0f)
		{
			z0rek("FirstLineIndent", p2.FirstLineIndent);
		}
		if (p2.LeftIndent != 0f)
		{
			z0rek("LeftIndent", p2.LeftIndent);
		}
		if (p2.RightToLeft)
		{
			z0rek("RightToLeft", p2.RightToLeft);
		}
		if (p2.Multiline)
		{
			z0rek("Multiline", p2.Multiline);
		}
		if (p2.LayoutAlign != ContentLayoutAlign.EmbedInText)
		{
			z0ZzZzhqh2.z0eek("LayoutAlign", null, z0rek(p2.LayoutAlign));
		}
		if (p2.CharacterCircle != CharacterCircleStyles.None)
		{
			z0ZzZzhqh2.z0eek("CharacterCircle", null, z0rek(p2.CharacterCircle));
		}
		z0tek("BorderLeftColor", p2.BorderLeftColorString);
		z0tek("BorderTopColor", p2.BorderTopColorString);
		z0tek("BorderRightColor", p2.BorderRightColorString);
		z0tek("BorderBottomColor", p2.BorderBottomColorString);
		if (p2.BorderStyle != DashStyle.Solid)
		{
			z0ZzZzhqh2.z0eek("BorderStyle", null, z0rek(p2.BorderStyle));
		}
		if (p2.BorderWidth != 0f)
		{
			z0rek("BorderWidth", p2.BorderWidth);
		}
		if (p2.BorderLeft)
		{
			z0rek("BorderLeft", p2.BorderLeft);
		}
		if (p2.BorderBottom)
		{
			z0rek("BorderBottom", p2.BorderBottom);
		}
		if (p2.BorderTop)
		{
			z0rek("BorderTop", p2.BorderTop);
		}
		if (p2.BorderRight)
		{
			z0rek("BorderRight", p2.BorderRight);
		}
		if (p2.BorderSpacing != 0f)
		{
			z0rek("BorderSpacing", p2.BorderSpacing);
		}
		if (p2.MarginLeft != 0f)
		{
			z0rek("MarginLeft", p2.MarginLeft);
		}
		if (p2.MarginTop != 0f)
		{
			z0rek("MarginTop", p2.MarginTop);
		}
		if (p2.MarginRight != 0f)
		{
			z0rek("MarginRight", p2.MarginRight);
		}
		if (p2.MarginBottom != 0f)
		{
			z0rek("MarginBottom", p2.MarginBottom);
		}
		if (p2.PaddingLeft != 0f)
		{
			z0rek("PaddingLeft", p2.PaddingLeft);
		}
		if (p2.PaddingTop != 0f)
		{
			z0rek("PaddingTop", p2.PaddingTop);
		}
		if (p2.PaddingRight != 0f)
		{
			z0rek("PaddingRight", p2.PaddingRight);
		}
		if (p2.PaddingBottom != 0f)
		{
			z0rek("PaddingBottom", p2.PaddingBottom);
		}
		if (p2.ParagraphMultiLevel)
		{
			z0rek("ParagraphMultiLevel", p2.ParagraphMultiLevel);
		}
		if (p2.ParagraphOutlineLevel != -1)
		{
			z0rek("ParagraphOutlineLevel", p2.ParagraphOutlineLevel);
		}
		if (!p2.VisibleInDirectory)
		{
			z0rek("VisibleInDirectory", p2.VisibleInDirectory);
		}
		if (p2.ParagraphListStyle != ParagraphListStyle.None)
		{
			z0ZzZzhqh2.z0eek("ParagraphListStyle", null, z0rek(p2.ParagraphListStyle));
		}
		base.z0rek((object?)p2);
	}

	protected internal void z0rek(string p0, string p1, z0ZzZzpmk p2, bool p3, bool p4)
	{
		z0iek = z0eek();
		if (p2 == null)
		{
			return;
		}
		if (!p4)
		{
			Type type = p2.GetType();
			if (!(type == typeof(z0ZzZzpmk)))
			{
				if (type == typeof(RepeatedImageValue))
				{
					z0rek(p0, p1, (RepeatedImageValue)p2, p3, p4: true);
					return;
				}
				throw z0eek(p2);
			}
		}
		z0eek(p0, p1, p2, p3: false, null);
		if (p4)
		{
			z0eek("XImageValue");
		}
		z0iek.z0eek("ImageDataBase64String", p2.ImageData);
		base.z0rek((object?)p2);
	}

	protected internal void z0rek(string p0, string p1, z0ZzZzjuj p2, bool p3, bool p4)
	{
		z0iek = z0eek();
		z0ZzZzhqh z0ZzZzhqh2 = z0eek();
		if (p2 == null)
		{
			return;
		}
		if (!p4)
		{
			Type type = p2.GetType();
			if (!(type == typeof(z0ZzZzjuj)))
			{
				if (type == typeof(z0ZzZzkuj))
				{
					z0rek(p0, p1, (z0ZzZzkuj)p2, p3, p4: true);
					return;
				}
				throw z0eek(p2);
			}
		}
		z0eek(p0, p1, p2, p3: false, null);
		if (p4)
		{
			z0eek("ShapeDocumentPage");
		}
		if (((z0ZzZzhuj)p2).z0eek() != -1)
		{
			z0ZzZzhqh2.z0eek("StyleIndex", ((z0ZzZzhuj)p2).z0eek());
		}
		z0rek("LocalStyle", string.Empty, ((z0ZzZzhuj)p2).z0pek(), p3: false, p4: false);
		if (!p2.z0rek_jiejie20260327142557())
		{
			z0rek("Visible", p2.z0rek_jiejie20260327142557());
		}
		z0tek("ID", ((z0ZzZzhuj)p2).z0yek());
		if (p2.z0rek() != 0f)
		{
			z0rek("Left", p2.z0rek());
		}
		if (p2.z0oek() != 0f)
		{
			z0rek("Top", p2.z0oek());
		}
		if (p2.z0mek() != 100f)
		{
			z0rek("Width", p2.z0mek());
		}
		if (((z0ZzZzeuj)p2).z0eek() != 100f)
		{
			z0rek("Height", ((z0ZzZzeuj)p2).z0eek());
		}
		if (!p2.z0xkk())
		{
			z0rek("Resizeable", p2.z0xkk());
		}
		z0tek("Text", p2.z0pek());
		z0ZzZzguj z0ZzZzguj2 = p2.z0djk();
		if (z0ZzZzguj2 != null && z0ZzZzguj2.Count > 0)
		{
			int count = z0ZzZzguj2.Count;
			z0ZzZzhqh2.z0hf(null, "Elements", null);
			for (int i = 0; i < count; i++)
			{
				z0rek("ShapeElement", string.Empty, z0ZzZzguj2[i], p3: true, p4: false);
			}
			z0ZzZzhqh2.z0bg();
		}
		base.z0rek((object?)p2);
	}

	protected internal void z0rek(string p0, string p1, z0ZzZzyhh p2, bool p3, bool p4)
	{
		z0iek = z0eek();
		z0ZzZzhqh z0ZzZzhqh2 = z0eek();
		if (p2 != null)
		{
			if (!p4 && !(p2.GetType() == typeof(z0ZzZzyhh)))
			{
				throw z0eek(p2);
			}
			z0eek(p0, p1, p2, p3: false, null);
			if (p4)
			{
				z0eek("UserHistoryInfo");
			}
			if (p2.z0pek() != 0)
			{
				z0ZzZzhqh2.z0eek("Index", p2.z0pek());
			}
			z0tek("ID", p2.z0zek());
			z0tek("Name", p2.z0yek());
			z0tek("Name2", p2.z0tek());
			z0rek("SavedTime", z0ZzZzkhh.z0eek(p2.z0xek()));
			if (p2.z0rek() != 0)
			{
				z0rek("PermissionLevel", p2.z0rek());
			}
			z0tek("Description", p2.z0uek());
			z0tek("ClientName", p2.z0mek());
			z0tek("Tag", p2.z0bek());
			if (p2.z0vek())
			{
				z0rek("CheckedValue", p2.z0vek());
			}
			base.z0rek((object?)p2);
		}
	}

	private string z0rek(PageBorderRangeTypes p0)
	{
		string text = null;
		return p0 switch
		{
			PageBorderRangeTypes.None => "None", 
			PageBorderRangeTypes.Page => "Page", 
			PageBorderRangeTypes.Body => "Body", 
			_ => throw z0ZzZzwhh.z0rek((long)p0, typeof(PageBorderRangeTypes)), 
		};
	}

	private string z0rek(PageInfoValueType p0)
	{
		string text = null;
		return p0 switch
		{
			PageInfoValueType.PageIndex => "PageIndex", 
			PageInfoValueType.NumOfPages => "NumOfPages", 
			PageInfoValueType.LocalPageIndex => "LocalPageIndex", 
			PageInfoValueType.LocalNumOfPages => "LocalNumOfPages", 
			_ => throw z0ZzZzwhh.z0rek((long)p0, typeof(PageInfoValueType)), 
		};
	}

	private string z0rek(DCBooleanValue p0)
	{
		string text = null;
		return p0 switch
		{
			DCBooleanValue.True => "True", 
			DCBooleanValue.False => "False", 
			DCBooleanValue.Inherit => "Inherit", 
			_ => throw z0ZzZzwhh.z0rek((long)p0, typeof(DCBooleanValue)), 
		};
	}

	private string z0rek(DashCap p0)
	{
		string text = null;
		return p0 switch
		{
			DashCap.Flat => "Flat", 
			DashCap.Round => "Round", 
			DashCap.Triangle => "Triangle", 
			_ => throw z0ZzZzwhh.z0rek((long)p0, typeof(DashCap)), 
		};
	}

	private void z0rek(string p0, bool p1)
	{
		z0iek.z0tek(p0, null);
		z0iek.z0og(p1 ? "true" : "false");
		z0iek.z0bg();
	}

	protected internal void z0rek(string p0, string p1, z0ZzZzevj p2, bool p3, bool p4)
	{
		z0iek = z0eek();
		z0ZzZzhqh z0ZzZzhqh2 = z0eek();
		if (p2 != null)
		{
			if (!p4 && !(p2.GetType() == typeof(z0ZzZzevj)))
			{
				throw z0eek(p2);
			}
			z0eek(p0, p1, p2, p3: false, null);
			if (p4)
			{
				z0eek("XDataBinding");
			}
			if (!p2.z0eek())
			{
				z0rek("Enabled", p2.z0eek());
			}
			z0tek("DataSource", p2.DataSource);
			z0tek("BindingPath", p2.BindingPath);
			z0tek("BindingPathForText", p2.BindingPathForText);
			z0tek("WriteTextBindingPath", p2.WriteTextBindingPath);
			if (p2.ProcessState != DCProcessStates.Always)
			{
				z0ZzZzhqh2.z0eek("ProcessState", null, z0rek(p2.ProcessState));
			}
			if (p2.z0yek())
			{
				z0rek("AutoUpdate", p2.z0yek());
			}
			if (p2.z0rek())
			{
				z0rek("Readonly", p2.z0rek());
			}
			base.z0rek((object?)p2);
		}
	}

	private string z0rek(ElementType p0)
	{
		string text = null;
		return p0 switch
		{
			ElementType.None => "None", 
			ElementType.Text => "Text", 
			ElementType.Field => "Field", 
			ElementType.InputField => "InputField", 
			ElementType.Table => "Table", 
			ElementType.TableRow => "TableRow", 
			ElementType.TableColumn => "TableColumn", 
			ElementType.TableCell => "TableCell", 
			ElementType.Object => "Object", 
			ElementType.LineBreak => "LineBreak", 
			ElementType.PageBreak => "PageBreak", 
			ElementType.ParagraphFlag => "ParagraphFlag", 
			ElementType.CheckRadioBox => "CheckRadioBox", 
			ElementType.Image => "Image", 
			ElementType.Document => "Document", 
			ElementType.Button => "Button", 
			ElementType.Container => "Container", 
			ElementType.All => "All", 
			_ => z0ZzZzkhh.z0eek((long)p0, z0ZzZzwhh.z0oek, z0ZzZzwhh.z0pek, "DCSoft.Writer.Dom.ElementType"), 
		};
	}

	private string z0rek(WatermarkType p0)
	{
		string text = null;
		return p0 switch
		{
			WatermarkType.None => "None", 
			WatermarkType.Image => "Image", 
			WatermarkType.Text => "Text", 
			_ => throw z0ZzZzwhh.z0rek((long)p0, typeof(WatermarkType)), 
		};
	}

	protected internal void z0rek(string p0, string p1, XTextInputFieldElement p2, bool p3, bool p4)
	{
		z0iek = z0eek();
		z0ZzZzhqh z0ZzZzhqh2 = z0eek();
		if (p2 == null)
		{
			return;
		}
		if (!p4 && !(p2.GetType() == typeof(XTextInputFieldElement)))
		{
			throw z0eek(p2);
		}
		z0eek(p0, p1, p2, p3: false, null);
		if (p4)
		{
			z0eek("XInputField");
		}
		if (((XTextElement)p2).z0pek() != -1)
		{
			z0ZzZzhqh2.z0eek("StyleIndex", ((XTextElement)p2).z0pek());
		}
		if (p2.z0uek())
		{
			z0rek("SensitiveData", p2.z0uek());
		}
		z0rek(z0ZzZzhqh2, p2.Attributes);
		z0tek("ID", p2.ID);
		z0tek("LimitedInputChars", p2.LimitedInputChars);
		if (p2.HiddenPrintWhenEmpty)
		{
			z0rek("HiddenPrintWhenEmpty", p2.HiddenPrintWhenEmpty);
		}
		if (p2.MaxInputLength != 0)
		{
			z0rek("MaxInputLength", p2.MaxInputLength);
		}
		z0tek("DataName", p2.z0ht());
		if (p2.z0gt())
		{
			z0rek("CanBeReferenced", p2.z0gt());
		}
		if (p2.z0dt())
		{
			z0rek("BringoutToSave", p2.z0dt());
		}
		z0tek("ToolTip", p2.ToolTip);
		if (p2.AcceptTab)
		{
			z0rek("AcceptTab", p2.AcceptTab);
		}
		z0rek(z0ZzZzhqh2, p2.PropertyExpressions);
		if (!p2.EnableValueValidate)
		{
			z0rek("EnableValueValidate", p2.EnableValueValidate);
		}
		z0rek("ValidateStyle", string.Empty, p2.ValidateStyle, p3: false, p4: false);
		z0rek("ValueBinding", string.Empty, p2.ValueBinding, p3: false, p4: false);
		z0tek("DefaultValueForValueBinding", p2.z0nrk());
		z0tek("ContentReadonlyExpression", p2.ContentReadonlyExpression);
		z0tek("VisibleExpression", p2.VisibleExpression);
		z0tek("PrintVisibilityExpression", p2.PrintVisibilityExpression);
		z0tek("ValueExpression", p2.ValueExpression);
		if (p2.UserFlags != 0)
		{
			z0rek("UserFlags", p2.UserFlags);
		}
		if (p2.EnablePermission != DCBooleanValue.Inherit)
		{
			z0ZzZzhqh2.z0eek("EnablePermission", null, z0rek(p2.EnablePermission));
		}
		z0rek("ContentLock", string.Empty, p2.ContentLock, p3: false, p4: false);
		if (p2.ContentReadonly != ContentReadonlyState.Inherit)
		{
			z0ZzZzhqh2.z0eek("ContentReadonly", null, z0rek(p2.ContentReadonly));
		}
		z0rek("CopySource", string.Empty, p2.CopySource, p3: false, p4: false);
		z0rek(p2);
		if (p2.AcceptChildElementTypes2 != ElementType.All)
		{
			z0rek("AcceptChildElementTypes2", string.Empty, z0rek(p2.AcceptChildElementTypes2));
		}
		if (p2.PrintVisibility != ElementVisibility.Visible)
		{
			z0ZzZzhqh2.z0eek("PrintVisibility", null, z0rek(p2.PrintVisibility));
		}
		if (!p2.Visible)
		{
			z0rek("Visible", p2.Visible);
		}
		if (!p2.Deleteable)
		{
			z0rek("Deleteable", p2.Deleteable);
		}
		if (p2.EndingLineBreak)
		{
			z0rek("EndingLineBreak", p2.EndingLineBreak);
		}
		z0tek("StartBorderText", p2.StartBorderText);
		z0tek("EndBorderText", p2.EndBorderText);
		if (p2.BorderElementColor != Color.Empty)
		{
			z0rek("BorderElementColor", p2.BorderElementColor);
		}
		z0tek("BorderElementColorValue", p2.BorderElementColorValue);
		z0tek("TextColor", p2.TextColorString);
		if (((XTextFieldElementBase)p2).z0drk() != DCBooleanValueHasDefault.Default)
		{
			z0ZzZzhqh2.z0eek("BackgroundTextItalic", null, z0rek(((XTextFieldElementBase)p2).z0drk()));
		}
		if (p2.LableUnitTextBold != DCBooleanValueHasDefault.Default)
		{
			z0ZzZzhqh2.z0eek("LableUnitTextBold", null, z0rek(p2.LableUnitTextBold));
		}
		z0tek("BackgroundTextColor", p2.BackgroundTextColorString);
		if (((XTextInputFieldElementBase)p2).z0oek() != (z0ZzZzscj)1)
		{
			z0ZzZzhqh2.z0eek("BorderTextPosition", null, z0rek(((XTextInputFieldElementBase)p2).z0oek()));
		}
		if (((XTextInputFieldElementBase)p2).z0rek() != DCFastInputMode.NextField)
		{
			z0ZzZzhqh2.z0eek("FastInputMode", null, z0rek(((XTextInputFieldElementBase)p2).z0rek()));
		}
		if (!p2.TabStop)
		{
			z0rek("TabStop", p2.TabStop);
		}
		if (p2.MoveFocusHotKey != MoveFocusHotKeys.Default)
		{
			z0rek("MoveFocusHotKey", string.Empty, z0rek(p2.MoveFocusHotKey));
		}
		if (p2.TabIndex != 0)
		{
			z0rek("TabIndex", p2.TabIndex);
		}
		if (p2.SpecifyWidth != 0f)
		{
			z0rek("SpecifyWidth", p2.SpecifyWidth);
		}
		if (p2.Alignment != StringAlignment.Near)
		{
			z0ZzZzhqh2.z0eek("Alignment", null, z0rek(p2.Alignment));
		}
		if (((XTextInputFieldElementBase)p2).z0pek())
		{
			z0rek("AutoFixFontSize", ((XTextInputFieldElementBase)p2).z0pek());
		}
		z0tek("DefaultEventExpression", p2.DefaultEventExpression);
		z0ZzZzukh eventExpressions = p2.EventExpressions;
		if (eventExpressions != null && eventExpressions.Count > 0)
		{
			int count = eventExpressions.Count;
			z0ZzZzhqh2.z0hf(null, "EventExpressions", null);
			for (int i = 0; i < count; i++)
			{
				z0rek("Expression", string.Empty, eventExpressions[i], p3: true, p4: false);
			}
			z0ZzZzhqh2.z0bg();
		}
		z0tek("UnitText", p2.UnitText);
		z0tek("LabelText", p2.LabelText);
		if (!p2.UserEditable)
		{
			z0rek("UserEditable", p2.UserEditable);
		}
		z0tek("Name", p2.Name);
		z0rek("DisplayFormat", string.Empty, p2.DisplayFormat, p3: false, p4: false);
		z0tek("InnerValue", p2.InnerValue);
		if (((XTextInputFieldElementBase)p2).z0cek() != DCBooleanValue.Inherit)
		{
			z0ZzZzhqh2.z0eek("PrintBackgroundText", null, z0rek(((XTextInputFieldElementBase)p2).z0cek()));
		}
		z0tek("BackgroundText", p2.BackgroundText);
		if (p2.ViewEncryptType != ContentViewEncryptType.None)
		{
			z0ZzZzhqh2.z0eek("ViewEncryptType", null, z0rek(p2.ViewEncryptType));
		}
		if (p2.BorderVisible != DCVisibleState.Default)
		{
			z0ZzZzhqh2.z0eek("BorderVisible", null, z0rek(p2.BorderVisible));
		}
		if (p2.EnableHighlight != EnableState.Enabled)
		{
			z0ZzZzhqh2.z0eek("EnableHighlight", null, z0rek(p2.EnableHighlight));
		}
		if (!p2.z0vek())
		{
			z0rek("EnableUserEditInnerValue", p2.z0vek());
		}
		if (p2.z0frk() != DCBooleanValue.Inherit)
		{
			z0ZzZzhqh2.z0eek("ShowInputFieldStateTag", null, z0rek(p2.z0frk()));
		}
		if (p2.z0pek())
		{
			z0rek("AutoSetSpellCodeInDropdownList", p2.z0pek());
		}
		if (p2.z0rek() != InputFieldAdornTextType.Default)
		{
			z0ZzZzhqh2.z0eek("AdornTextType", null, z0rek(p2.z0rek()));
		}
		z0tek("EditorControlTypeName", p2.z0xek());
		z0rek("LinkListBinding", string.Empty, p2.z0nek(), p3: false, p4: false);
		if (!p2.z0eek())
		{
			z0rek("EnableFieldTextColor", p2.z0eek());
		}
		if (p2.EditorActiveMode != (ValueEditorActiveMode.Program | ValueEditorActiveMode.F2 | ValueEditorActiveMode.MouseDblClick))
		{
			z0rek("EditorActiveMode", string.Empty, z0rek(p2.EditorActiveMode));
		}
		z0rek("FieldSettings", string.Empty, p2.FieldSettings, p3: false, p4: false);
		z0tek("CustomValueEditorTypeName", p2.z0drk());
		if (!p2.z0yek())
		{
			z0rek("EnableValueEditor", p2.z0yek());
		}
		if (p2.z0krk() != DCBooleanValue.Inherit)
		{
			z0ZzZzhqh2.z0eek("ShowFormButton", null, z0rek(p2.z0krk()));
		}
		if (p2.z0iek() != FormButtonStyle.Auto)
		{
			z0ZzZzhqh2.z0eek("FormButtonStyle", null, z0rek(p2.z0iek()));
		}
		base.z0rek((object?)p2);
	}

	protected internal void z0rek(string p0, string p1, z0ZzZzptk p2, bool p3, bool p4)
	{
		z0iek = z0eek();
		if (p2 != null)
		{
			if (!p4 && !(p2.GetType() == typeof(z0ZzZzptk)))
			{
				throw z0eek(p2);
			}
			z0eek(p0, p1, p2, p3: false, null);
			if (p4)
			{
				z0eek("ChartLegendStyle");
			}
			z0eek("TextColorValue", p2.z0rek());
			z0rek("Font", p2.z0yek_jiejie20260327142557());
			if (p2.z0uek() != 40)
			{
				z0rek("Size", p2.z0uek());
			}
			if (!p2.z0nek())
			{
				z0rek("AutoSize", p2.z0nek());
			}
			if (p2.z0tek() != 0f)
			{
				z0rek("MaxSize", p2.z0tek());
			}
			if (p2.z0pek() != 40f)
			{
				z0rek("SymbolSize", p2.z0pek());
			}
			z0rek("Background", string.Empty, p2.z0iek(), p3: false, p4: false);
			if (p2.z0eek())
			{
				z0rek("Visible", p2.z0eek());
			}
			base.z0rek((object?)p2);
		}
	}

	protected internal void z0rek(string p0, string p1, z0ZzZzjuk p2, bool p3, bool p4)
	{
		z0iek = z0eek();
		if (p2 != null)
		{
			if (!p4 && !(p2.GetType() == typeof(z0ZzZzjuk)))
			{
				throw z0eek(p2);
			}
			z0eek(p0, p1, p2, p3: false, null);
			if (p4)
			{
				z0eek("DCNameValueItem");
			}
			z0eek("Name", p2.Name);
			if (p2.Value != null)
			{
				base.z0rek(p2.Value);
			}
			base.z0rek((object?)p2);
		}
	}

	private string z0rek(AxisCompressStyle p0)
	{
		string text = null;
		return p0 switch
		{
			AxisCompressStyle.None => "None", 
			AxisCompressStyle.AutoCompress => "AutoCompress", 
			AxisCompressStyle.AutoSize => "AutoSize", 
			_ => throw z0ZzZzwhh.z0rek((long)p0, typeof(AxisCompressStyle)), 
		};
	}

	protected internal void z0rek(string p0, string p1, z0ZzZzluj p2, bool p3, bool p4)
	{
		z0iek = z0eek();
		z0ZzZzhqh z0ZzZzhqh2 = z0eek();
		if (p2 == null)
		{
			return;
		}
		if (!p4 && !(p2.GetType() == typeof(z0ZzZzluj)))
		{
			throw z0eek(p2);
		}
		z0eek(p0, p1, p2, p3: false, null);
		if (p4)
		{
			z0eek("ShapeDocument");
		}
		if (((z0ZzZzhuj)p2).z0eek() != -1)
		{
			z0ZzZzhqh2.z0eek("StyleIndex", ((z0ZzZzhuj)p2).z0eek());
		}
		z0rek("LocalStyle", string.Empty, ((z0ZzZzhuj)p2).z0pek(), p3: false, p4: false);
		if (!p2.z0rek_jiejie20260327142557())
		{
			z0rek("Visible", p2.z0rek_jiejie20260327142557());
		}
		z0tek("ID", ((z0ZzZzhuj)p2).z0yek());
		if (((z0ZzZzeuj)p2).z0rek() != 0f)
		{
			z0rek("Left", ((z0ZzZzeuj)p2).z0rek());
		}
		if (((z0ZzZzeuj)p2).z0oek() != 0f)
		{
			z0rek("Top", ((z0ZzZzeuj)p2).z0oek());
		}
		if (((z0ZzZzeuj)p2).z0mek() != 100f)
		{
			z0rek("Width", ((z0ZzZzeuj)p2).z0mek());
		}
		if (((z0ZzZzeuj)p2).z0eek() != 100f)
		{
			z0rek("Height", ((z0ZzZzeuj)p2).z0eek());
		}
		if (!p2.z0xkk())
		{
			z0rek("Resizeable", p2.z0xkk());
		}
		z0tek("Text", ((z0ZzZzeuj)p2).z0pek());
		z0ZzZzguj z0ZzZzguj2 = p2.z0djk();
		if (z0ZzZzguj2 != null && z0ZzZzguj2.Count > 0)
		{
			int count = z0ZzZzguj2.Count;
			z0ZzZzhqh2.z0hf(null, "Elements", null);
			for (int i = 0; i < count; i++)
			{
				z0rek("ShapeElement", string.Empty, z0ZzZzguj2[i], p3: true, p4: false);
			}
			z0ZzZzhqh2.z0bg();
		}
		if (p2.z0eek())
		{
			z0rek("LocalElementStyleMode", p2.z0eek());
		}
		z0tek("TextBackColorString", p2.z0oek());
		if (!p2.z0nek())
		{
			z0rek("AutoZoomFontSize", p2.z0nek());
		}
		if (!p2.z0cek())
		{
			z0rek("EditMode", p2.z0cek());
		}
		z0rek("DefaultFont", p2.z0rek());
		z0rek("ContentStyles", string.Empty, p2.z0bek(), p3: false, p4: false);
		base.z0rek((object?)p2);
	}

	private string z0rek(z0ZzZzrrk p0)
	{
		string text = null;
		return p0 switch
		{
			(z0ZzZzrrk)0 => "UNSPECIFIED", 
			(z0ZzZzrrk)1 => "UPCA", 
			(z0ZzZzrrk)2 => "UPCE", 
			(z0ZzZzrrk)3 => "SUPP2", 
			(z0ZzZzrrk)4 => "SUPP5", 
			(z0ZzZzrrk)5 => "EAN13", 
			(z0ZzZzrrk)6 => "EAN8", 
			(z0ZzZzrrk)7 => "Interleaved2of5", 
			(z0ZzZzrrk)8 => "Standard2of5", 
			(z0ZzZzrrk)9 => "I2of5", 
			(z0ZzZzrrk)10 => "Code39", 
			(z0ZzZzrrk)11 => "Code39Extended", 
			(z0ZzZzrrk)12 => "Code93", 
			(z0ZzZzrrk)13 => "Codabar", 
			(z0ZzZzrrk)14 => "PostNet", 
			(z0ZzZzrrk)15 => "BOOKLAND", 
			(z0ZzZzrrk)16 => "ISBN", 
			(z0ZzZzrrk)17 => "JAN13", 
			(z0ZzZzrrk)18 => "MSI_Mod10", 
			(z0ZzZzrrk)19 => "MSI_2Mod10", 
			(z0ZzZzrrk)20 => "MSI_Mod11", 
			(z0ZzZzrrk)21 => "MSI_Mod11_Mod10", 
			(z0ZzZzrrk)22 => "Modified_Plessey", 
			(z0ZzZzrrk)23 => "CODE11", 
			(z0ZzZzrrk)24 => "USD8", 
			(z0ZzZzrrk)25 => "UCC12", 
			(z0ZzZzrrk)26 => "UCC13", 
			(z0ZzZzrrk)27 => "LOGMARS", 
			(z0ZzZzrrk)28 => "Code128A", 
			(z0ZzZzrrk)29 => "Code128B", 
			(z0ZzZzrrk)30 => "Code128C", 
			_ => throw z0ZzZzwhh.z0rek((long)p0, typeof(z0ZzZzrrk)), 
		};
	}

	protected internal void z0rek(string p0, string p1, XTextElement p2, bool p3, bool p4)
	{
		z0iek = z0eek();
		if (p2 == null || p4)
		{
			return;
		}
		Type type = p2.GetType();
		if (type == typeof(XTextElement))
		{
			return;
		}
		if (type == typeof(XTextSignElement))
		{
			z0rek(p0, p1, (XTextSignElement)p2, p3, p4: true);
			return;
		}
		if (type == typeof(XTextPageBreakElement))
		{
			z0rek(p0, p1, (XTextPageBreakElement)p2, p3, p4: true);
			return;
		}
		if (type == typeof(XTextTableColumnElement))
		{
			z0rek(p0, p1, (XTextTableColumnElement)p2, p3, p4: true);
			return;
		}
		if (type == typeof(z0ZzZzolh))
		{
			z0rek(p0, p1, (z0ZzZzolh)p2, p3, p4: true);
			return;
		}
		if (type == typeof(XTextLineBreakElement))
		{
			z0rek(p0, p1, (XTextLineBreakElement)p2, p3, p4: true);
			return;
		}
		if (type == typeof(XTextNewMedicalExpressionElement))
		{
			z0rek(p0, p1, (XTextNewMedicalExpressionElement)p2, p3, p4: true);
			return;
		}
		if (type == typeof(XTextPieElement))
		{
			z0rek(p0, p1, (XTextPieElement)p2, p3, p4: true);
			return;
		}
		if (type == typeof(XTextChartElement))
		{
			z0rek(p0, p1, (XTextChartElement)p2, p3, p4: true);
			return;
		}
		if (type == typeof(XTextSignImageElement))
		{
			z0rek(p0, p1, (XTextSignImageElement)p2, p3, p4: true);
			return;
		}
		if (type == typeof(XTextCustomShapeElement))
		{
			z0rek(p0, p1, (XTextCustomShapeElement)p2, p3, p4: true);
			return;
		}
		if (type == typeof(XTextButtonElement))
		{
			z0rek(p0, p1, (XTextButtonElement)p2, p3, p4: true);
			return;
		}
		if (type == typeof(XTextTDBarcodeElement))
		{
			z0rek(p0, p1, (XTextTDBarcodeElement)p2, p3, p4: true);
			return;
		}
		if (type == typeof(XTextNewBarcodeElement))
		{
			z0rek(p0, p1, (XTextNewBarcodeElement)p2, p3, p4: true);
			return;
		}
		if (type == typeof(XTextLabelElement))
		{
			z0rek(p0, p1, (XTextLabelElement)p2, p3, p4: true);
			return;
		}
		if (type == typeof(XTextHorizontalLineElement))
		{
			z0rek(p0, p1, (XTextHorizontalLineElement)p2, p3, p4: true);
			return;
		}
		if (type == typeof(XTextControlHostElement))
		{
			z0rek(p0, p1, (XTextControlHostElement)p2, p3, p4: true);
			return;
		}
		if (type == typeof(XTextMediaElement))
		{
			z0rek(p0, p1, (XTextMediaElement)p2, p3, p4: true);
			return;
		}
		if (type == typeof(XTextPageInfoElement))
		{
			z0rek(p0, p1, (XTextPageInfoElement)p2, p3, p4: true);
			return;
		}
		if (type == typeof(XTextRadioBoxElement))
		{
			z0rek(p0, p1, (XTextRadioBoxElement)p2, p3, p4: true);
			return;
		}
		if (type == typeof(XTextCheckBoxElement))
		{
			z0rek(p0, p1, (XTextCheckBoxElement)p2, p3, p4: true);
			return;
		}
		if (type == typeof(XTextImageElement))
		{
			z0rek(p0, p1, (XTextImageElement)p2, p3, p4: true);
			return;
		}
		if (type == typeof(XTextParagraphFlagElement))
		{
			z0rek(p0, p1, (XTextParagraphFlagElement)p2, p3, p4: true);
			return;
		}
		if (type == typeof(z0ZzZzilh))
		{
			z0rek(p0, p1, (z0ZzZzilh)p2, p3, p4: true);
			return;
		}
		if (type == typeof(XTextMedicalExpressionFieldElement))
		{
			z0rek(p0, p1, (XTextMedicalExpressionFieldElement)p2, p3, p4: true);
			return;
		}
		if (type == typeof(XTextBarcodeFieldElement))
		{
			z0rek(p0, p1, (XTextBarcodeFieldElement)p2, p3, p4: true);
			return;
		}
		if (type == typeof(XTextDirectoryFieldElement))
		{
			z0rek(p0, p1, (XTextDirectoryFieldElement)p2, p3, p4: true);
			return;
		}
		if (type == typeof(XTextInputFieldElement))
		{
			z0rek(p0, p1, (XTextInputFieldElement)p2, p3, p4: true);
			return;
		}
		if (type == typeof(XTextTableRowElement))
		{
			z0rek(p0, p1, (XTextTableRowElement)p2, p3, p4: true);
			return;
		}
		if (type == typeof(XTextTableElement))
		{
			z0rek(p0, p1, (XTextTableElement)p2, p3, p4: true);
			return;
		}
		if (type == typeof(XTextSectionElement))
		{
			z0rek(p0, p1, (XTextSectionElement)p2, p3, p4: true);
			return;
		}
		if (type == typeof(XTextSubDocumentElement))
		{
			z0rek(p0, p1, (XTextSubDocumentElement)p2, p3, p4: true);
			return;
		}
		if (type == typeof(XTextTableCellElement))
		{
			z0rek(p0, p1, (XTextTableCellElement)p2, p3, p4: true);
			return;
		}
		if (type == typeof(XTextDocumentFooterForFirstPageElement))
		{
			z0rek(p0, p1, (XTextDocumentFooterForFirstPageElement)p2, p3, p4: true);
			return;
		}
		if (type == typeof(XTextDocumentHeaderForFirstPageElement))
		{
			z0rek(p0, p1, (XTextDocumentHeaderForFirstPageElement)p2, p3, p4: true);
			return;
		}
		if (type == typeof(XTextDocumentFooterElement))
		{
			z0rek(p0, p1, (XTextDocumentFooterElement)p2, p3, p4: true);
			return;
		}
		if (type == typeof(XTextDocumentHeaderElement))
		{
			z0rek(p0, p1, (XTextDocumentHeaderElement)p2, p3, p4: true);
			return;
		}
		if (type == typeof(XTextDocumentBodyElement))
		{
			z0rek(p0, p1, (XTextDocumentBodyElement)p2, p3, p4: true);
			return;
		}
		if (type == typeof(XTextDocument))
		{
			z0rek(p0, p1, (XTextDocument)p2, p3, p4: true);
			return;
		}
		throw z0eek(p2);
	}

	protected internal void z0rek(string p0, string p1, XTextBarcodeFieldElement p2, bool p3, bool p4)
	{
		z0iek = z0eek();
		z0ZzZzhqh z0ZzZzhqh2 = z0eek();
		if (p2 == null)
		{
			return;
		}
		if (!p4 && !(p2.GetType() == typeof(XTextBarcodeFieldElement)))
		{
			throw z0eek(p2);
		}
		z0eek(p0, p1, p2, p3: false, null);
		if (p4)
		{
			z0eek("XBarcodeField");
		}
		if (((XTextElement)p2).z0pek() != -1)
		{
			z0ZzZzhqh2.z0eek("StyleIndex", ((XTextElement)p2).z0pek());
		}
		z0rek(z0ZzZzhqh2, p2.Attributes);
		z0tek("ID", p2.ID);
		z0tek("LimitedInputChars", p2.LimitedInputChars);
		if (p2.HiddenPrintWhenEmpty)
		{
			z0rek("HiddenPrintWhenEmpty", p2.HiddenPrintWhenEmpty);
		}
		if (p2.MaxInputLength != 0)
		{
			z0rek("MaxInputLength", p2.MaxInputLength);
		}
		z0tek("DataName", p2.z0ht());
		if (p2.z0gt())
		{
			z0rek("CanBeReferenced", p2.z0gt());
		}
		if (p2.z0dt())
		{
			z0rek("BringoutToSave", p2.z0dt());
		}
		z0tek("ToolTip", p2.ToolTip);
		if (p2.AcceptTab)
		{
			z0rek("AcceptTab", p2.AcceptTab);
		}
		z0rek(z0ZzZzhqh2, p2.PropertyExpressions);
		if (p2.EnableValueValidate)
		{
			z0rek("EnableValueValidate", p2.EnableValueValidate);
		}
		z0rek("ValidateStyle", string.Empty, p2.ValidateStyle, p3: false, p4: false);
		z0rek("ValueBinding", string.Empty, p2.ValueBinding, p3: false, p4: false);
		z0tek("DefaultValueForValueBinding", p2.z0nrk());
		z0tek("ContentReadonlyExpression", p2.ContentReadonlyExpression);
		z0tek("VisibleExpression", p2.VisibleExpression);
		z0tek("PrintVisibilityExpression", p2.PrintVisibilityExpression);
		z0tek("ValueExpression", p2.ValueExpression);
		if (p2.EnablePermission != DCBooleanValue.Inherit)
		{
			z0ZzZzhqh2.z0eek("EnablePermission", null, z0rek(p2.EnablePermission));
		}
		z0rek("ContentLock", string.Empty, p2.ContentLock, p3: false, p4: false);
		if (p2.ContentReadonly != ContentReadonlyState.Inherit)
		{
			z0ZzZzhqh2.z0eek("ContentReadonly", null, z0rek(p2.ContentReadonly));
		}
		z0rek("CopySource", string.Empty, p2.CopySource, p3: false, p4: false);
		z0rek(p2);
		if (p2.AcceptChildElementTypes2 != ElementType.All)
		{
			z0rek("AcceptChildElementTypes2", string.Empty, z0rek(p2.AcceptChildElementTypes2));
		}
		if (p2.PrintVisibility != ElementVisibility.Visible)
		{
			z0ZzZzhqh2.z0eek("PrintVisibility", null, z0rek(p2.PrintVisibility));
		}
		if (!p2.Visible)
		{
			z0rek("Visible", p2.Visible);
		}
		if (!p2.Deleteable)
		{
			z0rek("Deleteable", p2.Deleteable);
		}
		if (p2.EndingLineBreak)
		{
			z0rek("EndingLineBreak", p2.EndingLineBreak);
		}
		z0tek("StartBorderText", p2.StartBorderText);
		z0tek("EndBorderText", p2.EndBorderText);
		z0rek("BorderElementColor", p2.BorderElementColor);
		z0tek("BorderElementColorValue", p2.BorderElementColorValue);
		z0tek("TextColor", p2.TextColorString);
		if (((XTextFieldElementBase)p2).z0drk() != DCBooleanValueHasDefault.Default)
		{
			z0ZzZzhqh2.z0eek("BackgroundTextItalic", null, z0rek(((XTextFieldElementBase)p2).z0drk()));
		}
		if (p2.LableUnitTextBold != DCBooleanValueHasDefault.Default)
		{
			z0ZzZzhqh2.z0eek("LableUnitTextBold", null, z0rek(p2.LableUnitTextBold));
		}
		z0tek("BackgroundTextColor", p2.BackgroundTextColorString);
		if (p2.z0oek() != (z0ZzZzscj)1)
		{
			z0ZzZzhqh2.z0eek("BorderTextPosition", null, z0rek(p2.z0oek()));
		}
		if (((XTextInputFieldElementBase)p2).z0rek() != DCFastInputMode.NextField)
		{
			z0ZzZzhqh2.z0eek("FastInputMode", null, z0rek(((XTextInputFieldElementBase)p2).z0rek()));
		}
		if (!p2.TabStop)
		{
			z0rek("TabStop", p2.TabStop);
		}
		if (p2.MoveFocusHotKey != MoveFocusHotKeys.Default)
		{
			z0rek("MoveFocusHotKey", string.Empty, z0rek(p2.MoveFocusHotKey));
		}
		if (p2.TabIndex != 0)
		{
			z0rek("TabIndex", p2.TabIndex);
		}
		if (p2.SpecifyWidth != 0f)
		{
			z0rek("SpecifyWidth", p2.SpecifyWidth);
		}
		if (p2.Alignment != StringAlignment.Near)
		{
			z0ZzZzhqh2.z0eek("Alignment", null, z0rek(p2.Alignment));
		}
		if (p2.z0pek())
		{
			z0rek("AutoFixFontSize", p2.z0pek());
		}
		z0tek("DefaultEventExpression", p2.DefaultEventExpression);
		z0ZzZzukh eventExpressions = p2.EventExpressions;
		if (eventExpressions != null && eventExpressions.Count > 0)
		{
			int count = eventExpressions.Count;
			z0ZzZzhqh2.z0hf(null, "EventExpressions", null);
			for (int i = 0; i < count; i++)
			{
				z0rek("Expression", string.Empty, eventExpressions[i], p3: true, p4: false);
			}
			z0ZzZzhqh2.z0bg();
		}
		z0tek("UnitText", p2.UnitText);
		z0tek("LabelText", p2.LabelText);
		if (!p2.UserEditable)
		{
			z0rek("UserEditable", p2.UserEditable);
		}
		z0tek("Name", p2.Name);
		z0rek("DisplayFormat", string.Empty, p2.DisplayFormat, p3: false, p4: false);
		z0tek("InnerValue", p2.InnerValue);
		if (p2.z0cek() != DCBooleanValue.Inherit)
		{
			z0ZzZzhqh2.z0eek("PrintBackgroundText", null, z0rek(p2.z0cek()));
		}
		z0tek("BackgroundText", p2.BackgroundText);
		if (p2.ViewEncryptType != ContentViewEncryptType.None)
		{
			z0ZzZzhqh2.z0eek("ViewEncryptType", null, z0rek(p2.ViewEncryptType));
		}
		if (p2.BorderVisible != DCVisibleState.Default)
		{
			z0ZzZzhqh2.z0eek("BorderVisible", null, z0rek(p2.BorderVisible));
		}
		if (p2.EnableHighlight != EnableState.Enabled)
		{
			z0ZzZzhqh2.z0eek("EnableHighlight", null, z0rek(p2.EnableHighlight));
		}
		if (!p2.AutoExitEditMode)
		{
			z0rek("AutoExitEditMode", p2.AutoExitEditMode);
		}
		if (!p2.Enabled)
		{
			z0rek("Enabled", p2.Enabled);
		}
		if (p2.Height != 125f)
		{
			z0rek("Height", p2.Height);
		}
		if (p2.BarcodeStyle != (z0ZzZzrrk)30)
		{
			z0ZzZzhqh2.z0eek("BarcodeStyle", null, z0rek(p2.BarcodeStyle));
		}
		if (p2.TextAlignment != StringAlignment.Center)
		{
			z0ZzZzhqh2.z0eek("TextAlignment", null, z0rek(p2.TextAlignment));
		}
		if (!p2.ShowText)
		{
			z0rek("ShowText", p2.ShowText);
		}
		if (p2.MinBarWidth != 7f)
		{
			z0rek("MinBarWidth", p2.MinBarWidth);
		}
		base.z0rek((object?)p2);
	}

	protected internal void z0rek(string p0, string p1, z0ZzZznmk p2, bool p3, bool p4)
	{
		z0iek = z0eek();
		z0ZzZzhqh z0ZzZzhqh2 = z0eek();
		if (p2 != null)
		{
			if (!p4 && !(p2.GetType() == typeof(z0ZzZznmk)))
			{
				throw z0eek(p2);
			}
			z0eek(p0, p1, p2, p3: false, null);
			if (p4)
			{
				z0eek("XPenStyle");
			}
			z0tek("Color", p2.ColorString);
			if (p2.Width != 1f)
			{
				z0rek("Width", p2.Width);
			}
			if (p2.DashStyle != DashStyle.Solid)
			{
				z0ZzZzhqh2.z0eek("DashStyle", null, z0rek(p2.DashStyle));
			}
			if (p2.DashCap != DashCap.Flat)
			{
				z0ZzZzhqh2.z0eek("DashCap", null, z0rek(p2.DashCap));
			}
			if (p2.LineJoin != (z0ZzZzkdh)1)
			{
				z0ZzZzhqh2.z0eek("LineJoin", null, z0rek(p2.LineJoin));
			}
			if (p2.StartCap != 0)
			{
				z0ZzZzhqh2.z0eek("StartCap", null, z0rek(p2.StartCap));
			}
			if (p2.EndCap != 0)
			{
				z0ZzZzhqh2.z0eek("EndCap", null, z0rek(p2.EndCap));
			}
			if (p2.MiterLimit != 10f)
			{
				z0rek("MiterLimit", p2.MiterLimit);
			}
			if (p2.Alignment != 0)
			{
				z0ZzZzhqh2.z0eek("Alignment", null, z0rek(p2.Alignment));
			}
			base.z0rek((object?)p2);
		}
	}

	protected internal void z0rek(string p0, string p1, XTextTDBarcodeElement p2, bool p3, bool p4)
	{
		z0iek = z0eek();
		z0ZzZzhqh z0ZzZzhqh2 = z0eek();
		if (p2 == null)
		{
			return;
		}
		if (!p4 && !(p2.GetType() == typeof(XTextTDBarcodeElement)))
		{
			throw z0eek(p2);
		}
		z0eek(p0, p1, p2, p3: false, null);
		if (p4)
		{
			z0eek("XTDBarcodeField");
		}
		if (((XTextElement)p2).z0pek() != -1)
		{
			z0ZzZzhqh2.z0eek("StyleIndex", ((XTextElement)p2).z0pek());
		}
		z0rek(z0ZzZzhqh2, p2.Attributes);
		z0tek("ID", p2.ID);
		z0tek("ToolTip", p2.ToolTip);
		if (p2.OffsetX != 0f)
		{
			z0rek("OffsetX", p2.OffsetX);
		}
		if (p2.OffsetY != 0f)
		{
			z0rek("OffsetY", p2.OffsetY);
		}
		if (p2.ZOrderStyle != ElementZOrderStyle.Normal)
		{
			z0ZzZzhqh2.z0eek("ZOrderStyle", null, z0rek(p2.ZOrderStyle));
		}
		z0rek(z0ZzZzhqh2, p2.PropertyExpressions);
		z0tek("ValueExpression", p2.ValueExpression);
		if (!p2.Visible)
		{
			z0rek("Visible", p2.Visible);
		}
		if (p2.PrintVisibility != ElementVisibility.Visible)
		{
			z0ZzZzhqh2.z0eek("PrintVisibility", null, z0rek(p2.PrintVisibility));
		}
		z0rek("LinkInfo", string.Empty, p2.z0iek(), p3: false, p4: false);
		if (p2.ContentReadonly != ContentReadonlyState.Inherit)
		{
			z0ZzZzhqh2.z0eek("ContentReadonly", null, z0rek(p2.ContentReadonly));
		}
		if (!p2.Deleteable)
		{
			z0rek("Deleteable", p2.Deleteable);
		}
		z0tek("Name", p2.Name);
		if (!p2.Enabled)
		{
			z0rek("Enabled", p2.Enabled);
		}
		z0tek("StringTag", p2.StringTag);
		z0rek("ValueBinding", string.Empty, p2.ValueBinding, p3: false, p4: false);
		z0rek("Width", p2.Width);
		z0rek("Height", p2.Height);
		z0tek("Text", p2.Text);
		PageLabelTextList pageTexts = p2.PageTexts;
		if (pageTexts != null && pageTexts.Count > 0)
		{
			int count = pageTexts.Count;
			z0ZzZzhqh2.z0hf(null, "PageTexts", null);
			for (int i = 0; i < count; i++)
			{
				z0rek("PageText", string.Empty, pageTexts[i], p3: true, p4: false);
			}
			z0ZzZzhqh2.z0bg();
		}
		if (p2.StrictMatchPageIndex)
		{
			z0rek("StrictMatchPageIndex", p2.StrictMatchPageIndex);
		}
		if (p2.VAlign != VerticalAlignStyle.Bottom)
		{
			z0ZzZzhqh2.z0eek("VAlign", null, z0rek(p2.VAlign));
		}
		if (p2.BarcodeType != DCTDBarcodeType.QR)
		{
			z0ZzZzhqh2.z0eek("BarcodeType", null, z0rek(p2.BarcodeType));
		}
		if (p2.ErroeCorrectionLevel != DCTBErroeCorrectionLevelType.M)
		{
			z0ZzZzhqh2.z0eek("ErroeCorrectionLevel", null, z0rek(p2.ErroeCorrectionLevel));
		}
		base.z0rek((object?)p2);
	}

	private string z0rek(ShapeTypes p0)
	{
		string text = null;
		return p0 switch
		{
			ShapeTypes.Rectangle => "Rectangle", 
			ShapeTypes.Square => "Square", 
			ShapeTypes.Ellipse => "Ellipse", 
			ShapeTypes.Circle => "Circle", 
			ShapeTypes.Diamond => "Diamond", 
			ShapeTypes.TriangleUp => "TriangleUp", 
			ShapeTypes.TriangleRight => "TriangleRight", 
			ShapeTypes.TriangleDown => "TriangleDown", 
			ShapeTypes.TriangleLeft => "TriangleLeft", 
			ShapeTypes.Cross => "Cross", 
			ShapeTypes.XCross => "XCross", 
			ShapeTypes.CircleCross => "CircleCross", 
			ShapeTypes.CircleXCross => "CircleXCross", 
			ShapeTypes.Default => "Default", 
			ShapeTypes.None => "None", 
			_ => throw z0ZzZzwhh.z0rek((long)p0, typeof(ShapeTypes)), 
		};
	}

	protected internal void z0rek(string p0, string p1, XTextSectionElement p2, bool p3, bool p4)
	{
		z0iek = z0eek();
		z0ZzZzhqh z0ZzZzhqh2 = z0eek();
		if (p2 == null)
		{
			return;
		}
		if (!p4)
		{
			Type type = p2.GetType();
			if (!(type == typeof(XTextSectionElement)))
			{
				if (type == typeof(XTextSubDocumentElement))
				{
					z0rek(p0, p1, (XTextSubDocumentElement)p2, p3, p4: true);
					return;
				}
				throw z0eek(p2);
			}
		}
		z0eek(p0, p1, p2, p3: false, null);
		if (p4)
		{
			z0eek("XTextSection");
		}
		if (((XTextElement)p2).z0pek() != -1)
		{
			z0ZzZzhqh2.z0eek("StyleIndex", ((XTextElement)p2).z0pek());
		}
		z0rek(z0ZzZzhqh2, p2.Attributes);
		z0tek("ID", p2.ID);
		z0tek("LimitedInputChars", p2.LimitedInputChars);
		if (p2.HiddenPrintWhenEmpty)
		{
			z0rek("HiddenPrintWhenEmpty", p2.HiddenPrintWhenEmpty);
		}
		if (p2.MaxInputLength != 0)
		{
			z0rek("MaxInputLength", p2.MaxInputLength);
		}
		z0tek("DataName", p2.z0ht());
		if (p2.z0gt())
		{
			z0rek("CanBeReferenced", p2.z0gt());
		}
		if (p2.z0dt())
		{
			z0rek("BringoutToSave", p2.z0dt());
		}
		z0tek("ToolTip", p2.ToolTip);
		if (p2.AcceptTab)
		{
			z0rek("AcceptTab", p2.AcceptTab);
		}
		z0rek(z0ZzZzhqh2, p2.PropertyExpressions);
		if (p2.EnableValueValidate)
		{
			z0rek("EnableValueValidate", p2.EnableValueValidate);
		}
		z0rek("ValidateStyle", string.Empty, p2.ValidateStyle, p3: false, p4: false);
		z0rek("ValueBinding", string.Empty, p2.ValueBinding, p3: false, p4: false);
		z0tek("DefaultValueForValueBinding", ((XTextContainerElement)p2).z0nrk());
		z0tek("ContentReadonlyExpression", p2.ContentReadonlyExpression);
		z0tek("VisibleExpression", p2.VisibleExpression);
		z0tek("PrintVisibilityExpression", p2.PrintVisibilityExpression);
		z0tek("ValueExpression", p2.ValueExpression);
		if (p2.EnablePermission != DCBooleanValue.Inherit)
		{
			z0ZzZzhqh2.z0eek("EnablePermission", null, z0rek(p2.EnablePermission));
		}
		z0rek("ContentLock", string.Empty, p2.ContentLock, p3: false, p4: false);
		if (p2.ContentReadonly != ContentReadonlyState.Inherit)
		{
			z0ZzZzhqh2.z0eek("ContentReadonly", null, z0rek(p2.ContentReadonly));
		}
		z0rek("CopySource", string.Empty, p2.CopySource, p3: false, p4: false);
		z0rek(p2);
		if (p2.AcceptChildElementTypes2 != ElementType.All)
		{
			z0rek("AcceptChildElementTypes2", string.Empty, z0rek(p2.AcceptChildElementTypes2));
		}
		if (p2.PrintVisibility != ElementVisibility.Visible)
		{
			z0ZzZzhqh2.z0eek("PrintVisibility", null, z0rek(p2.PrintVisibility));
		}
		if (!p2.Visible)
		{
			z0rek("Visible", p2.Visible);
		}
		if (!p2.Deleteable)
		{
			z0rek("Deleteable", p2.Deleteable);
		}
		z0rek("GridLine", string.Empty, p2.GridLine, p3: false, p4: false);
		if (p2.SpecifyFixedLineHeight != 0f)
		{
			z0rek("SpecifyFixedLineHeight", p2.SpecifyFixedLineHeight);
		}
		if (p2.NewPage)
		{
			z0rek("NewPage", p2.NewPage);
		}
		if (p2.InsertEmptyPageForNewPage)
		{
			z0rek("InsertEmptyPageForNewPage", p2.InsertEmptyPageForNewPage);
		}
		if (!p2.ExpendForDataBinding)
		{
			z0rek("ExpendForDataBinding", p2.ExpendForDataBinding);
		}
		z0tek("ForeColorValueForCollapsed", p2.ForeColorValueForCollapsed);
		if (p2.EnableCollapse)
		{
			z0rek("EnableCollapse", p2.EnableCollapse);
		}
		if (p2.IsCollapsed)
		{
			z0rek("IsCollapsed", p2.IsCollapsed);
		}
		z0tek("Title", p2.Title);
		if (p2.CompressOwnerLineSpacing)
		{
			z0rek("CompressOwnerLineSpacing", p2.CompressOwnerLineSpacing);
		}
		if (p2.SpecifyHeight != 0f)
		{
			z0rek("SpecifyHeight", p2.SpecifyHeight);
		}
		z0tek("Name", p2.Name);
		base.z0rek((object?)p2);
	}

	private string z0rek(z0ZzZzscj p0)
	{
		string text = null;
		return p0 switch
		{
			(z0ZzZzscj)0 => "Top", 
			(z0ZzZzscj)1 => "Middle", 
			(z0ZzZzscj)2 => "Bottom", 
			(z0ZzZzscj)3 => "LeftTopRightBottom", 
			(z0ZzZzscj)4 => "LeftBottomRightTop", 
			_ => throw z0ZzZzwhh.z0rek((long)p0, typeof(z0ZzZzscj)), 
		};
	}

	protected internal void z0rek(string p0, string p1, CopySourceInfo p2, bool p3, bool p4)
	{
		z0iek = z0eek();
		if (p2 != null)
		{
			if (!p4 && !(p2.GetType() == typeof(CopySourceInfo)))
			{
				throw z0eek(p2);
			}
			z0eek(p0, p1, p2, p3: false, null);
			if (p4)
			{
				z0eek("CopySourceInfo");
			}
			z0tek("SourceID", p2.z0tek());
			z0tek("SourcePropertyName", p2.z0eek());
			z0tek("DescPropertyName", p2.z0iek());
			if (!p2.z0yek())
			{
				z0rek("IgnoreChildElements", p2.z0yek());
			}
			base.z0rek((object?)p2);
		}
	}

	private string z0rek(ContentAutoFixFontSizeMode p0)
	{
		string text = null;
		return p0 switch
		{
			ContentAutoFixFontSizeMode.None => "None", 
			ContentAutoFixFontSizeMode.SingleLine => "SingleLine", 
			ContentAutoFixFontSizeMode.MultiLine => "MultiLine", 
			_ => throw z0ZzZzwhh.z0rek((long)p0, typeof(ContentAutoFixFontSizeMode)), 
		};
	}

	private string z0rek(VerticalAlignStyle p0)
	{
		string text = null;
		return p0 switch
		{
			VerticalAlignStyle.Top => "Top", 
			VerticalAlignStyle.Middle => "Middle", 
			VerticalAlignStyle.Bottom => "Bottom", 
			_ => throw z0ZzZzwhh.z0rek((long)p0, typeof(VerticalAlignStyle)), 
		};
	}

	protected internal void z0rek(string p0, string p1, XTextDocumentFooterForFirstPageElement p2, bool p3, bool p4)
	{
		z0iek = z0eek();
		z0ZzZzhqh z0ZzZzhqh2 = z0eek();
		if (p2 != null)
		{
			if (!p4 && !(p2.GetType() == typeof(XTextDocumentFooterForFirstPageElement)))
			{
				throw z0eek(p2);
			}
			z0eek(p0, p1, p2, p3: false, null);
			if (p4)
			{
				z0eek("XTextFooterForFirstPage");
			}
			if (p2.z0rek() != -1)
			{
				z0ZzZzhqh2.z0eek("StyleIndex", p2.z0rek());
			}
			z0rek(z0ZzZzhqh2, p2.Attributes);
			z0tek("ID", p2.ID);
			z0tek("LimitedInputChars", p2.LimitedInputChars);
			if (p2.HiddenPrintWhenEmpty)
			{
				z0rek("HiddenPrintWhenEmpty", p2.HiddenPrintWhenEmpty);
			}
			if (p2.MaxInputLength != 0)
			{
				z0rek("MaxInputLength", p2.MaxInputLength);
			}
			z0tek("DataName", p2.z0ht());
			if (p2.z0gt())
			{
				z0rek("CanBeReferenced", p2.z0gt());
			}
			if (p2.z0dt())
			{
				z0rek("BringoutToSave", p2.z0dt());
			}
			z0tek("ToolTip", p2.ToolTip);
			if (p2.AcceptTab)
			{
				z0rek("AcceptTab", p2.AcceptTab);
			}
			z0rek(z0ZzZzhqh2, p2.PropertyExpressions);
			if (p2.EnableValueValidate)
			{
				z0rek("EnableValueValidate", p2.EnableValueValidate);
			}
			z0rek("ValidateStyle", string.Empty, p2.ValidateStyle, p3: false, p4: false);
			z0rek("ValueBinding", string.Empty, p2.ValueBinding, p3: false, p4: false);
			z0tek("DefaultValueForValueBinding", ((XTextContainerElement)p2).z0nrk());
			z0tek("ContentReadonlyExpression", p2.ContentReadonlyExpression);
			z0tek("VisibleExpression", p2.VisibleExpression);
			z0tek("PrintVisibilityExpression", p2.PrintVisibilityExpression);
			z0tek("ValueExpression", p2.ValueExpression);
			if (p2.EnablePermission != DCBooleanValue.Inherit)
			{
				z0ZzZzhqh2.z0eek("EnablePermission", null, z0rek(p2.EnablePermission));
			}
			z0rek("ContentLock", string.Empty, p2.ContentLock, p3: false, p4: false);
			if (p2.ContentReadonly != ContentReadonlyState.Inherit)
			{
				z0ZzZzhqh2.z0eek("ContentReadonly", null, z0rek(p2.ContentReadonly));
			}
			z0rek("CopySource", string.Empty, p2.CopySource, p3: false, p4: false);
			z0rek(p2);
			if (p2.AcceptChildElementTypes2 != ElementType.All)
			{
				z0rek("AcceptChildElementTypes2", string.Empty, z0rek(p2.AcceptChildElementTypes2));
			}
			if (p2.PrintVisibility != ElementVisibility.Visible)
			{
				z0ZzZzhqh2.z0eek("PrintVisibility", null, z0rek(p2.PrintVisibility));
			}
			if (!p2.Visible)
			{
				z0rek("Visible", p2.Visible);
			}
			if (!p2.Deleteable)
			{
				z0rek("Deleteable", p2.Deleteable);
			}
			z0rek("GridLine", string.Empty, p2.GridLine, p3: false, p4: false);
			if (p2.SpecifyFixedLineHeight != 0f)
			{
				z0rek("SpecifyFixedLineHeight", p2.SpecifyFixedLineHeight);
			}
			base.z0rek((object?)p2);
		}
	}

	protected internal void z0rek(string p0, string p1, z0ZzZzwuj p2, bool p3, bool p4)
	{
		z0iek = z0eek();
		z0ZzZzhqh z0ZzZzhqh2 = z0eek();
		if (p2 != null)
		{
			if (!p4 && !(p2.GetType() == typeof(z0ZzZzwuj)))
			{
				throw z0eek(p2);
			}
			z0eek(p0, p1, p2, p3: false, null);
			if (p4)
			{
				z0eek("ShapePolygonElement");
			}
			if (((z0ZzZzhuj)p2).z0eek() != -1)
			{
				z0ZzZzhqh2.z0eek("StyleIndex", ((z0ZzZzhuj)p2).z0eek());
			}
			z0rek("LocalStyle", string.Empty, ((z0ZzZzhuj)p2).z0pek(), p3: false, p4: false);
			if (!p2.z0rek_jiejie20260327142557())
			{
				z0rek("Visible", p2.z0rek_jiejie20260327142557());
			}
			z0tek("ID", ((z0ZzZzhuj)p2).z0yek());
			if (((z0ZzZzeuj)p2).z0rek() != 0f)
			{
				z0rek("Left", ((z0ZzZzeuj)p2).z0rek());
			}
			if (p2.z0oek() != 0f)
			{
				z0rek("Top", p2.z0oek());
			}
			if (p2.z0mek() != 100f)
			{
				z0rek("Width", p2.z0mek());
			}
			if (((z0ZzZzeuj)p2).z0eek() != 100f)
			{
				z0rek("Height", ((z0ZzZzeuj)p2).z0eek());
			}
			if (!p2.z0xkk())
			{
				z0rek("Resizeable", p2.z0xkk());
			}
			z0tek("Text", p2.z0pek());
			z0tek("Points", p2.z0eek());
			base.z0rek((object?)p2);
		}
	}

	private new void z0rek(string p0, string p1)
	{
		if (p1 != null && p1.Length > 0)
		{
			z0iek.z0tek(p0, null);
			z0iek.z0og(p1);
			z0iek.z0bg();
		}
	}

	private string z0rek(DrawingStyle p0)
	{
		string text = null;
		return p0 switch
		{
			DrawingStyle.Default => "Default", 
			DrawingStyle.Crystal => "Crystal", 
			DrawingStyle.Nomal => "Nomal", 
			_ => throw z0ZzZzwhh.z0rek((long)p0, typeof(DrawingStyle)), 
		};
	}

	private string z0rek(DCProcessStates p0)
	{
		string text = null;
		return p0 switch
		{
			DCProcessStates.Always => "Always", 
			DCProcessStates.Once => "Once", 
			DCProcessStates.Never => "Never", 
			_ => throw z0ZzZzwhh.z0rek((long)p0, typeof(DCProcessStates)), 
		};
	}

	private string z0rek(ContentGridLineType p0)
	{
		string text = null;
		return p0 switch
		{
			ContentGridLineType.None => "None", 
			ContentGridLineType.Display => "Display", 
			ContentGridLineType.ExtentToBottom => "ExtentToBottom", 
			_ => throw z0ZzZzwhh.z0rek((long)p0, typeof(ContentGridLineType)), 
		};
	}

	private string z0rek(ResizeableType p0)
	{
		string text = null;
		return p0 switch
		{
			ResizeableType.FixSize => "FixSize", 
			ResizeableType.Width => "Width", 
			ResizeableType.Height => "Height", 
			ResizeableType.WidthAndHeight => "WidthAndHeight", 
			_ => throw z0ZzZzwhh.z0rek((long)p0, typeof(ResizeableType)), 
		};
	}

	protected internal void z0rek(string p0, string p1, DocumentComment p2, bool p3, bool p4)
	{
		z0iek = z0eek();
		z0ZzZzhqh z0ZzZzhqh2 = z0eek();
		if (p2 != null)
		{
			if (!p4 && !(p2.GetType() == typeof(DocumentComment)))
			{
				throw z0eek(p2);
			}
			z0eek(p0, p1, p2, p3: false, null);
			if (p4)
			{
				z0eek("Comment");
			}
			z0ZzZzhqh2.z0eek("Index", p2.z0tek());
			z0tek("ID", p2.z0ark());
			if (!p2.z0yrk())
			{
				z0rek("Visible", p2.z0yrk());
			}
			z0tek("Title", p2.z0grk());
			if (p2.z0jrk())
			{
				z0rek("BindingUserTrack", p2.z0jrk());
			}
			z0rek(z0ZzZzhqh2, p2.z0lrk());
			z0tek("AuthorID", p2.z0eek());
			z0tek("Author", p2.z0krk());
			if (p2.z0mrk().Ticks != 624511296000000000L)
			{
				z0rek("CreationTime", z0ZzZzkhh.z0eek(p2.z0mrk()));
			}
			z0tek("Text", p2.z0nek());
			if (p2.z0urk() != -1)
			{
				z0rek("CreatorIndex", p2.z0urk());
			}
			z0tek("BackColor", p2.z0srk());
			z0tek("ForeColor", p2.z0iek());
			z0tek("BorderColor", p2.z0prk());
			base.z0rek((object?)p2);
		}
	}

	protected internal void z0rek(string p0, string p1, XTextDocumentBodyElement p2, bool p3, bool p4)
	{
		z0iek = z0eek();
		z0ZzZzhqh z0ZzZzhqh2 = z0eek();
		if (p2 != null)
		{
			if (!p4 && !(p2.GetType() == typeof(XTextDocumentBodyElement)))
			{
				throw z0eek(p2);
			}
			z0eek(p0, p1, p2, p3: false, null);
			if (p4)
			{
				z0eek("XTextBody");
			}
			if (((XTextDocumentContentElement)p2).z0rek() != -1)
			{
				z0ZzZzhqh2.z0eek("StyleIndex", ((XTextDocumentContentElement)p2).z0rek());
			}
			z0rek(z0ZzZzhqh2, p2.Attributes);
			z0tek("ID", p2.ID);
			z0tek("LimitedInputChars", p2.LimitedInputChars);
			if (p2.HiddenPrintWhenEmpty)
			{
				z0rek("HiddenPrintWhenEmpty", p2.HiddenPrintWhenEmpty);
			}
			if (p2.MaxInputLength != 0)
			{
				z0rek("MaxInputLength", p2.MaxInputLength);
			}
			z0tek("DataName", p2.z0ht());
			if (p2.z0gt())
			{
				z0rek("CanBeReferenced", p2.z0gt());
			}
			if (p2.z0dt())
			{
				z0rek("BringoutToSave", p2.z0dt());
			}
			z0tek("ToolTip", p2.ToolTip);
			if (p2.AcceptTab)
			{
				z0rek("AcceptTab", p2.AcceptTab);
			}
			z0rek(z0ZzZzhqh2, p2.PropertyExpressions);
			if (p2.EnableValueValidate)
			{
				z0rek("EnableValueValidate", p2.EnableValueValidate);
			}
			z0rek("ValidateStyle", string.Empty, p2.ValidateStyle, p3: false, p4: false);
			z0rek("ValueBinding", string.Empty, p2.ValueBinding, p3: false, p4: false);
			z0tek("DefaultValueForValueBinding", ((XTextContainerElement)p2).z0nrk());
			z0tek("ContentReadonlyExpression", p2.ContentReadonlyExpression);
			z0tek("VisibleExpression", p2.VisibleExpression);
			z0tek("PrintVisibilityExpression", p2.PrintVisibilityExpression);
			z0tek("ValueExpression", p2.ValueExpression);
			if (p2.EnablePermission != DCBooleanValue.Inherit)
			{
				z0ZzZzhqh2.z0eek("EnablePermission", null, z0rek(p2.EnablePermission));
			}
			z0rek("ContentLock", string.Empty, p2.ContentLock, p3: false, p4: false);
			if (p2.ContentReadonly != ContentReadonlyState.Inherit)
			{
				z0ZzZzhqh2.z0eek("ContentReadonly", null, z0rek(p2.ContentReadonly));
			}
			z0rek("CopySource", string.Empty, p2.CopySource, p3: false, p4: false);
			z0rek(p2);
			if (p2.AcceptChildElementTypes2 != ElementType.All)
			{
				z0rek("AcceptChildElementTypes2", string.Empty, z0rek(p2.AcceptChildElementTypes2));
			}
			if (p2.PrintVisibility != ElementVisibility.Visible)
			{
				z0ZzZzhqh2.z0eek("PrintVisibility", null, z0rek(p2.PrintVisibility));
			}
			if (!p2.Visible)
			{
				z0rek("Visible", p2.Visible);
			}
			if (!p2.Deleteable)
			{
				z0rek("Deleteable", p2.Deleteable);
			}
			z0rek("GridLine", string.Empty, p2.GridLine, p3: false, p4: false);
			if (p2.SpecifyFixedLineHeight != 0f)
			{
				z0rek("SpecifyFixedLineHeight", p2.SpecifyFixedLineHeight);
			}
			base.z0rek((object?)p2);
		}
	}

	private string z0rek(LabelTextContactActionMode p0)
	{
		string text = null;
		return p0 switch
		{
			LabelTextContactActionMode.Disable => "Disable", 
			LabelTextContactActionMode.Normal => "Normal", 
			LabelTextContactActionMode.FirstSectionInPage => "FirstSectionInPage", 
			LabelTextContactActionMode.LastSectionInPage => "LastSectionInPage", 
			LabelTextContactActionMode.TableRow => "TableRow", 
			LabelTextContactActionMode.FirstTableRowInPage => "FirstTableRowInPage", 
			LabelTextContactActionMode.LastTableRowInPage => "LastTableRowInPage", 
			_ => throw z0ZzZzwhh.z0rek((long)p0, typeof(LabelTextContactActionMode)), 
		};
	}

	private string z0rek(CheckBoxControlStyle p0)
	{
		string text = null;
		return p0 switch
		{
			CheckBoxControlStyle.CheckBox => "CheckBox", 
			CheckBoxControlStyle.RadioBox => "RadioBox", 
			_ => throw z0ZzZzwhh.z0rek((long)p0, typeof(CheckBoxControlStyle)), 
		};
	}

	private string z0rek(ElementZOrderStyle p0)
	{
		string text = null;
		return p0 switch
		{
			ElementZOrderStyle.Normal => "Normal", 
			ElementZOrderStyle.UnderText => "UnderText", 
			ElementZOrderStyle.InFrontOfText => "InFrontOfText", 
			_ => throw z0ZzZzwhh.z0rek((long)p0, typeof(ElementZOrderStyle)), 
		};
	}

	protected internal void z0rek(string p0, string p1, z0ZzZziuj p2, bool p3, bool p4)
	{
		z0iek = z0eek();
		z0ZzZzhqh z0ZzZzhqh2 = z0eek();
		if (p2 != null)
		{
			if (!p4 && !(p2.GetType() == typeof(z0ZzZziuj)))
			{
				throw z0eek(p2);
			}
			z0eek(p0, p1, p2, p3: false, null);
			if (p4)
			{
				z0eek("ShapeZoomInElement");
			}
			if (((z0ZzZzhuj)p2).z0eek() != -1)
			{
				z0ZzZzhqh2.z0eek("StyleIndex", ((z0ZzZzhuj)p2).z0eek());
			}
			z0rek("LocalStyle", string.Empty, ((z0ZzZzhuj)p2).z0pek(), p3: false, p4: false);
			if (!p2.z0rek_jiejie20260327142557())
			{
				z0rek("Visible", p2.z0rek_jiejie20260327142557());
			}
			z0tek("ID", ((z0ZzZzhuj)p2).z0yek());
			if (((z0ZzZzeuj)p2).z0rek() != 0f)
			{
				z0rek("Left", ((z0ZzZzeuj)p2).z0rek());
			}
			if (p2.z0oek() != 0f)
			{
				z0rek("Top", p2.z0oek());
			}
			if (p2.z0mek() != 100f)
			{
				z0rek("Width", p2.z0mek());
			}
			if (p2.z0eek() != 100f)
			{
				z0rek("Height", p2.z0eek());
			}
			if (!p2.z0xkk())
			{
				z0rek("Resizeable", p2.z0xkk());
			}
			z0tek("Text", p2.z0pek());
			if (p2.z0rek() != 2f)
			{
				z0rek("ZoomInRate", p2.z0rek());
			}
			if (p2.z0eek_jiejie20260327142557())
			{
				z0rek("SmoothZoomIn", p2.z0eek_jiejie20260327142557());
			}
			base.z0rek((object?)p2);
		}
	}

	private void z0rek(z0ZzZzhqh p0, PropertyExpressionInfoList p1)
	{
		if (p1 == null || p1.Count <= 0)
		{
			return;
		}
		int count = p1.Count;
		p0.z0hf(null, "PropertyExpressions", null);
		for (int i = 0; i < count; i++)
		{
			PropertyExpressionInfo propertyExpressionInfo = p1[i];
			p0.z0eek("Item");
			p0.z0eek("Name", propertyExpressionInfo.Name);
			if (!propertyExpressionInfo.AllowChainReaction)
			{
				p0.z0eek("AllowChainReaction", propertyExpressionInfo.AllowChainReaction);
			}
			if (propertyExpressionInfo.Expression != null && propertyExpressionInfo.Expression.Length > 0)
			{
				p0.z0yg(propertyExpressionInfo.Expression);
			}
			p0.z0bg();
		}
		p0.z0bg();
	}

	protected internal void z0rek(string p0, string p1, z0ZzZzfvj p2, bool p3, bool p4)
	{
		z0iek = z0eek();
		z0ZzZzhqh z0ZzZzhqh2 = z0eek();
		if (p2 != null)
		{
			if (!p4 && !(p2.GetType() == typeof(z0ZzZzfvj)))
			{
				throw z0eek(p2);
			}
			z0eek(p0, p1, p2, p3: false, null);
			if (p4)
			{
				z0eek("LinkListBindingInfo");
			}
			z0tek("ProviderName", p2.ProviderName);
			z0tek("UserFlag", p2.UserFlag);
			if (p2.IsRoot)
			{
				z0rek("IsRoot", p2.IsRoot);
			}
			if (p2.NextTarget != 0)
			{
				z0ZzZzhqh2.z0eek("NextTarget", null, z0rek(p2.NextTarget));
			}
			z0tek("NextTargetID", p2.NextTargetID);
			if (!p2.AutoUpdateTargetElement)
			{
				z0rek("AutoUpdateTargetElement", p2.AutoUpdateTargetElement);
			}
			if (p2.AutoSetFirstItems)
			{
				z0rek("AutoSetFirstItems", p2.AutoSetFirstItems);
			}
			base.z0rek((object?)p2);
		}
	}

	protected internal void z0rek(string p0, string p1, XTextImageElement p2, bool p3, bool p4)
	{
		z0iek = z0eek();
		z0ZzZzhqh z0ZzZzhqh2 = z0eek();
		if (p2 == null)
		{
			return;
		}
		if (!p4 && !(p2.GetType() == typeof(XTextImageElement)))
		{
			throw z0eek(p2);
		}
		z0eek(p0, p1, p2, p3: false, null);
		if (p4)
		{
			z0eek("XImage");
		}
		if (((XTextElement)p2).z0pek() != -1)
		{
			z0ZzZzhqh2.z0eek("StyleIndex", ((XTextElement)p2).z0pek());
		}
		if (p2.z0iek() != -1)
		{
			z0ZzZzhqh2.z0eek("InnerRepeatImageIndex", p2.z0iek());
		}
		z0rek(z0ZzZzhqh2, p2.Attributes);
		if (p2.z0jr() == null || p2.z0jr().z0vtk() == null || p2.z0jr().z0vtk().BehaviorOptions.ImageCompressSaveMode != DCImageCompressSaveMode.True)
		{
			z0rek("CompressSaveMode", "false");
		}
		z0tek("ID", p2.ID);
		z0tek("ToolTip", p2.ToolTip);
		if (p2.OffsetX != 0f)
		{
			z0rek("OffsetX", p2.OffsetX);
		}
		if (p2.OffsetY != 0f)
		{
			z0rek("OffsetY", p2.OffsetY);
		}
		if (p2.ZOrderStyle != ElementZOrderStyle.Normal)
		{
			z0ZzZzhqh2.z0eek("ZOrderStyle", null, z0rek(p2.ZOrderStyle));
		}
		z0rek(z0ZzZzhqh2, p2.PropertyExpressions);
		z0tek("ValueExpression", p2.ValueExpression);
		if (!p2.Visible)
		{
			z0rek("Visible", p2.Visible);
		}
		if (p2.PrintVisibility != ElementVisibility.Visible)
		{
			z0ZzZzhqh2.z0eek("PrintVisibility", null, z0rek(p2.PrintVisibility));
		}
		z0rek("LinkInfo", string.Empty, ((XTextObjectElement)p2).z0iek(), p3: false, p4: false);
		if (p2.ContentReadonly != ContentReadonlyState.Inherit)
		{
			z0ZzZzhqh2.z0eek("ContentReadonly", null, z0rek(p2.ContentReadonly));
		}
		if (!p2.Deleteable)
		{
			z0rek("Deleteable", p2.Deleteable);
		}
		z0tek("Name", p2.Name);
		if (!p2.Enabled)
		{
			z0rek("Enabled", p2.Enabled);
		}
		z0tek("StringTag", p2.StringTag);
		z0rek("ValueBinding", string.Empty, p2.ValueBinding, p3: false, p4: false);
		z0tek("TransparentColorValue", p2.TransparentColorValue);
		if (!p2.EnableEditImageAdditionShape)
		{
			z0rek("EnableEditImageAdditionShape", p2.EnableEditImageAdditionShape);
		}
		if (p2.z0mrk())
		{
			z0rek("EnableRepeatedImage", p2.z0mrk());
		}
		if (p2.z0cek() != -1)
		{
			z0rek("ValueIndexOfRepeatedImage", p2.z0cek());
		}
		if (p2.VAlign != VerticalAlignStyle.Bottom)
		{
			z0ZzZzhqh2.z0eek("VAlign", null, z0rek(p2.VAlign));
		}
		z0tek("Title", p2.z0vrk());
		z0tek("Alt", p2.z0tek());
		if (!p2.KeepWidthHeightRate)
		{
			z0rek("KeepWidthHeightRate", p2.KeepWidthHeightRate);
		}
		z0tek("Source", p2.z0mek());
		if (!p2.SaveContentInFile)
		{
			z0rek("SaveContentInFile", p2.SaveContentInFile);
		}
		z0rek("Width", p2.Width);
		z0rek("Height", p2.Height);
		z0rek("AdditionShape", string.Empty, p2.z0brk(), p3: false, p4: false);
		if (p2.z0jrk())
		{
			z0rek("AdditionShapeFixSize", p2.z0jrk());
		}
		z0rek("Image", string.Empty, p2.z0frk(), p3: false, p4: false);
		z0ZzZzdzj z0ZzZzdzj2 = p2.z0hrk();
		if (z0ZzZzdzj2 != null && z0ZzZzdzj2.Count > 0)
		{
			int count = z0ZzZzdzj2.Count;
			z0ZzZzhqh2.z0hf(null, "PageImages", null);
			for (int i = 0; i < count; i++)
			{
				z0rek("Image", string.Empty, z0ZzZzdzj2[i], p3: true, p4: false);
			}
			z0ZzZzhqh2.z0bg();
		}
		if (!p2.SmoothZoom)
		{
			z0rek("SmoothZoom", p2.SmoothZoom);
		}
		z0tek("CustomAdditionShapeContent", p2.z0yrk());
		base.z0rek((object?)p2);
	}

	protected internal void z0rek(string p0, string p1, XTextTableColumnElement p2, bool p3, bool p4)
	{
		z0iek = z0eek();
		z0ZzZzhqh z0ZzZzhqh2 = z0eek();
		if (p2 != null)
		{
			if (!p4 && !(p2.GetType() == typeof(XTextTableColumnElement)))
			{
				throw z0eek(p2);
			}
			z0eek(p0, p1, p2, p3: false, null);
			if (p4)
			{
				z0eek("XTextTableColumn");
			}
			if (p2.z0pek() != -1)
			{
				z0ZzZzhqh2.z0eek("StyleIndex", p2.z0pek());
			}
			z0rek(z0ZzZzhqh2, p2.Attributes);
			z0tek("ID", p2.ID);
			if (!p2.Visible)
			{
				z0rek("Visible", p2.Visible);
			}
			z0rek("ValueBinding", string.Empty, p2.ValueBinding, p3: false, p4: false);
			z0rek("Width", p2.Width);
			base.z0rek((object?)p2);
		}
	}

	protected internal void z0rek(string p0, string p1, XTextRadioBoxElement p2, bool p3, bool p4)
	{
		z0iek = z0eek();
		z0ZzZzhqh z0ZzZzhqh2 = z0eek();
		if (p2 == null)
		{
			return;
		}
		if (!p4 && !(p2.GetType() == typeof(XTextRadioBoxElement)))
		{
			throw z0eek(p2);
		}
		z0eek(p0, p1, p2, p3: false, null);
		if (p4)
		{
			z0eek("XTextRadioBox");
		}
		if (((XTextElement)p2).z0pek() != -1)
		{
			z0ZzZzhqh2.z0eek("StyleIndex", ((XTextElement)p2).z0pek());
		}
		z0rek(z0ZzZzhqh2, p2.Attributes);
		z0tek("ID", p2.ID);
		z0tek("ToolTip", p2.ToolTip);
		if (p2.OffsetX != 0f)
		{
			z0rek("OffsetX", p2.OffsetX);
		}
		if (p2.OffsetY != 0f)
		{
			z0rek("OffsetY", p2.OffsetY);
		}
		if (p2.ZOrderStyle != ElementZOrderStyle.Normal)
		{
			z0ZzZzhqh2.z0eek("ZOrderStyle", null, z0rek(p2.ZOrderStyle));
		}
		z0rek(z0ZzZzhqh2, p2.PropertyExpressions);
		z0tek("ValueExpression", p2.ValueExpression);
		if (!p2.Visible)
		{
			z0rek("Visible", p2.Visible);
		}
		if (p2.PrintVisibility != ElementVisibility.Visible)
		{
			z0ZzZzhqh2.z0eek("PrintVisibility", null, z0rek(p2.PrintVisibility));
		}
		z0rek("LinkInfo", string.Empty, ((XTextObjectElement)p2).z0iek(), p3: false, p4: false);
		if (p2.ContentReadonly != ContentReadonlyState.Inherit)
		{
			z0ZzZzhqh2.z0eek("ContentReadonly", null, z0rek(p2.ContentReadonly));
		}
		if (!p2.Deleteable)
		{
			z0rek("Deleteable", p2.Deleteable);
		}
		z0tek("Name", p2.Name);
		if (!p2.Enabled)
		{
			z0rek("Enabled", p2.Enabled);
		}
		z0tek("StringTag", p2.StringTag);
		z0ZzZzuhh checkedUserHistories = p2.CheckedUserHistories;
		if (checkedUserHistories != null && checkedUserHistories.Count > 0)
		{
			int count = checkedUserHistories.Count;
			z0ZzZzhqh2.z0hf(null, "CheckedUserHistories", null);
			for (int i = 0; i < count; i++)
			{
				z0rek("Item", string.Empty, checkedUserHistories[i], p3: true, p4: false);
			}
			z0ZzZzhqh2.z0bg();
		}
		if (p2.Requried)
		{
			z0rek("Requried", p2.Requried);
		}
		z0tek("DataName", p2.DataName);
		if (p2.CanBeReferenced)
		{
			z0rek("CanBeReferenced", p2.CanBeReferenced);
		}
		if (p2.BringoutToSave)
		{
			z0rek("BringoutToSave", p2.BringoutToSave);
		}
		if (p2.CheckboxVisibility != RenderVisibility.All)
		{
			z0rek("CheckboxVisibility", string.Empty, z0rek(p2.CheckboxVisibility));
		}
		if (p2.PrintVisibilityWhenUnchecked != PrintVisibilityModeWhenUnchecked.Visible)
		{
			z0ZzZzhqh2.z0eek("PrintVisibilityWhenUnchecked", null, z0rek(p2.PrintVisibilityWhenUnchecked));
		}
		z0tek("PrintTextForChecked", p2.PrintTextForChecked);
		z0tek("PrintTextForUnChecked", p2.PrintTextForUnChecked);
		if (!p2.CheckAlignLeft)
		{
			z0rek("CheckAlignLeft", p2.CheckAlignLeft);
		}
		z0tek("Caption", p2.Caption);
		if (p2.CaptionFlowLayout)
		{
			z0rek("CaptionFlowLayout", p2.CaptionFlowLayout);
		}
		if (p2.CaptionAlign != StringAlignment.Center)
		{
			z0ZzZzhqh2.z0eek("CaptionAlign", null, z0rek(p2.CaptionAlign));
		}
		z0rek("ValueBinding", string.Empty, p2.ValueBinding, p3: false, p4: false);
		if (p2.AutoHeightForMultiline)
		{
			z0rek("AutoHeightForMultiline", p2.AutoHeightForMultiline);
		}
		z0rek("Width", p2.Width);
		z0rek("Height", p2.Height);
		z0tek("GroupName", p2.GroupName);
		if (p2.z0oi() != CheckBoxControlStyle.CheckBox)
		{
			z0ZzZzhqh2.z0eek("ControlStyle", null, z0rek(p2.z0oi()));
		}
		if (p2.Checked)
		{
			z0rek("Checked", p2.Checked);
		}
		if (p2.DefaultCheckedForValueBinding)
		{
			z0rek("DefaultCheckedForValueBinding", p2.DefaultCheckedForValueBinding);
		}
		z0tek("CheckedValue", p2.CheckedValue);
		if (p2.Readonly)
		{
			z0rek("Readonly", p2.Readonly);
		}
		if (p2.EnableHighlight != EnableState.Enabled)
		{
			z0ZzZzhqh2.z0eek("EnableHighlight", null, z0rek(p2.EnableHighlight));
		}
		z0ZzZzukh z0ZzZzukh2 = p2.z0uek();
		if (z0ZzZzukh2 != null && z0ZzZzukh2.Count > 0)
		{
			int count2 = z0ZzZzukh2.Count;
			z0ZzZzhqh2.z0hf(null, "EventExpressions", null);
			for (int j = 0; j < count2; j++)
			{
				z0rek("Expression", string.Empty, z0ZzZzukh2[j], p3: true, p4: false);
			}
			z0ZzZzhqh2.z0bg();
		}
		if (!p2.CheckBoxVisible)
		{
			z0rek("CheckBoxVisible", p2.CheckBoxVisible);
		}
		if (p2.VisualStyle != CheckBoxVisualStyle.Default)
		{
			z0ZzZzhqh2.z0eek("VisualStyle", null, z0rek(p2.VisualStyle));
		}
		if (p2.Multiline)
		{
			z0rek("Multiline", p2.Multiline);
		}
		base.z0rek((object?)p2);
	}

	protected internal void z0rek(string p0, string p1, ObjectParameter p2, bool p3, bool p4)
	{
		z0iek = z0eek();
		if (p2 != null)
		{
			if (!p4 && !(p2.GetType() == typeof(ObjectParameter)))
			{
				throw z0eek(p2);
			}
			z0eek(p0, p1, p2, p3: false, null);
			if (p4)
			{
				z0eek("ObjectParameter");
			}
			z0eek("Name", p2.Name);
			if (p2.Value != null)
			{
				base.z0rek(p2.Value);
			}
			base.z0rek((object?)p2);
		}
	}

	private string z0rek(DCTableAlignment p0)
	{
		string text = null;
		return p0 switch
		{
			DCTableAlignment.Default => "Default", 
			DCTableAlignment.Left => "Left", 
			DCTableAlignment.Center => "Center", 
			DCTableAlignment.Right => "Right", 
			_ => throw z0ZzZzwhh.z0rek((long)p0, typeof(DCTableAlignment)), 
		};
	}

	protected internal void z0rek(string p0, string p1, SpecifyPageIndexInfo p2, bool p3, bool p4)
	{
		z0iek = z0eek();
		z0ZzZzhqh z0ZzZzhqh2 = z0eek();
		if (p2 != null)
		{
			if (!p4 && !(p2.GetType() == typeof(SpecifyPageIndexInfo)))
			{
				throw z0eek(p2);
			}
			z0eek(p0, p1, p2, p3: false, null);
			if (p4)
			{
				z0eek("SpecifyPageIndexInfo");
			}
			if (p2.RawPageIndex != 1)
			{
				z0ZzZzhqh2.z0eek("RawPageIndex", p2.RawPageIndex);
			}
			if (p2.SpecifyPageIndex != -1)
			{
				z0ZzZzhqh2.z0eek("SpecifyPageIndex", p2.SpecifyPageIndex);
			}
			base.z0rek((object?)p2);
		}
	}

	protected internal void z0rek(string p0, string p1, XTextNewBarcodeElement p2, bool p3, bool p4)
	{
		z0iek = z0eek();
		z0ZzZzhqh z0ZzZzhqh2 = z0eek();
		if (p2 == null)
		{
			return;
		}
		if (!p4 && !(p2.GetType() == typeof(XTextNewBarcodeElement)))
		{
			throw z0eek(p2);
		}
		z0eek(p0, p1, p2, p3: false, null);
		if (p4)
		{
			z0eek("NewBarcode");
		}
		if (((XTextElement)p2).z0pek() != -1)
		{
			z0ZzZzhqh2.z0eek("StyleIndex", ((XTextElement)p2).z0pek());
		}
		z0rek(z0ZzZzhqh2, p2.Attributes);
		z0tek("ID", p2.ID);
		z0tek("ToolTip", p2.ToolTip);
		if (p2.OffsetX != 0f)
		{
			z0rek("OffsetX", p2.OffsetX);
		}
		if (p2.OffsetY != 0f)
		{
			z0rek("OffsetY", p2.OffsetY);
		}
		if (p2.ZOrderStyle != ElementZOrderStyle.Normal)
		{
			z0ZzZzhqh2.z0eek("ZOrderStyle", null, z0rek(p2.ZOrderStyle));
		}
		z0rek(z0ZzZzhqh2, p2.PropertyExpressions);
		z0tek("ValueExpression", p2.ValueExpression);
		if (!p2.Visible)
		{
			z0rek("Visible", p2.Visible);
		}
		if (p2.PrintVisibility != ElementVisibility.Visible)
		{
			z0ZzZzhqh2.z0eek("PrintVisibility", null, z0rek(p2.PrintVisibility));
		}
		z0rek("LinkInfo", string.Empty, p2.z0iek(), p3: false, p4: false);
		if (p2.ContentReadonly != ContentReadonlyState.Inherit)
		{
			z0ZzZzhqh2.z0eek("ContentReadonly", null, z0rek(p2.ContentReadonly));
		}
		if (!p2.Deleteable)
		{
			z0rek("Deleteable", p2.Deleteable);
		}
		z0tek("Name", p2.Name);
		if (!p2.Enabled)
		{
			z0rek("Enabled", p2.Enabled);
		}
		z0tek("StringTag", p2.StringTag);
		z0rek("ValueBinding", string.Empty, p2.ValueBinding, p3: false, p4: false);
		z0rek("Width", p2.Width);
		z0rek("Height", p2.Height);
		z0tek("Text", p2.Text);
		PageLabelTextList pageTexts = p2.PageTexts;
		if (pageTexts != null && pageTexts.Count > 0)
		{
			int count = pageTexts.Count;
			z0ZzZzhqh2.z0hf(null, "PageTexts", null);
			for (int i = 0; i < count; i++)
			{
				z0rek("PageText", string.Empty, pageTexts[i], p3: true, p4: false);
			}
			z0ZzZzhqh2.z0bg();
		}
		if (p2.StrictMatchPageIndex)
		{
			z0rek("StrictMatchPageIndex", p2.StrictMatchPageIndex);
		}
		if (p2.BarcodeStyle2 != DCBarcodeStyle.Code128C)
		{
			z0ZzZzhqh2.z0eek("BarcodeStyle2", null, z0rek(p2.BarcodeStyle2));
		}
		if (p2.TextAlignment != StringAlignment.Center)
		{
			z0ZzZzhqh2.z0eek("TextAlignment", null, z0rek(p2.TextAlignment));
		}
		if (!p2.ShowText)
		{
			z0rek("ShowText", p2.ShowText);
		}
		base.z0rek((object?)p2);
	}

	protected internal void z0rek(string p0, string p1, XTextMediaElement p2, bool p3, bool p4)
	{
		z0iek = z0eek();
		z0ZzZzhqh z0ZzZzhqh2 = z0eek();
		if (p2 == null)
		{
			return;
		}
		if (!p4 && !(p2.GetType() == typeof(XTextMediaElement)))
		{
			throw z0eek(p2);
		}
		z0eek(p0, p1, p2, p3: false, null);
		if (p4)
		{
			z0eek("XMedia");
		}
		if (((XTextElement)p2).z0pek() != -1)
		{
			z0ZzZzhqh2.z0eek("StyleIndex", ((XTextElement)p2).z0pek());
		}
		z0rek(z0ZzZzhqh2, p2.Attributes);
		z0tek("ID", p2.ID);
		z0tek("ToolTip", p2.ToolTip);
		if (p2.OffsetX != 0f)
		{
			z0rek("OffsetX", p2.OffsetX);
		}
		if (p2.OffsetY != 0f)
		{
			z0rek("OffsetY", p2.OffsetY);
		}
		if (p2.ZOrderStyle != ElementZOrderStyle.Normal)
		{
			z0ZzZzhqh2.z0eek("ZOrderStyle", null, z0rek(p2.ZOrderStyle));
		}
		z0rek(z0ZzZzhqh2, p2.PropertyExpressions);
		z0tek("ValueExpression", p2.ValueExpression);
		if (!p2.Visible)
		{
			z0rek("Visible", p2.Visible);
		}
		if (p2.PrintVisibility != ElementVisibility.Visible)
		{
			z0ZzZzhqh2.z0eek("PrintVisibility", null, z0rek(p2.PrintVisibility));
		}
		z0rek("LinkInfo", string.Empty, ((XTextObjectElement)p2).z0iek(), p3: false, p4: false);
		if (p2.ContentReadonly != ContentReadonlyState.Inherit)
		{
			z0ZzZzhqh2.z0eek("ContentReadonly", null, z0rek(p2.ContentReadonly));
		}
		if (!p2.Deleteable)
		{
			z0rek("Deleteable", p2.Deleteable);
		}
		z0tek("Name", p2.Name);
		if (!p2.Enabled)
		{
			z0rek("Enabled", p2.Enabled);
		}
		z0tek("StringTag", p2.StringTag);
		if (p2.DelayLoadControl)
		{
			z0rek("DelayLoadControl", p2.DelayLoadControl);
		}
		if (p2.VAlign != VerticalAlignStyle.Top)
		{
			z0ZzZzhqh2.z0eek("VAlign", null, z0rek(p2.VAlign));
		}
		if (p2.z0ry() != 0)
		{
			z0ZzZzhqh2.z0eek("ControlType", null, z0rek(p2.z0ry()));
		}
		z0tek("TypeFullName", p2.TypeFullName);
		z0tek("ValuePropertyName", p2.ValuePropertyName);
		if (p2.z0uek() != (z0ZzZzgzj)2)
		{
			z0ZzZzhqh2.z0eek("HostMode", null, z0rek(p2.z0uek()));
		}
		if (p2.AllowUserResize != ResizeableType.WidthAndHeight)
		{
			z0ZzZzhqh2.z0eek("AllowUserResize", null, z0rek(p2.AllowUserResize));
		}
		ObjectParameterList parameters = p2.Parameters;
		if (parameters != null && parameters.Count > 0)
		{
			int count = parameters.Count;
			z0ZzZzhqh2.z0hf(null, "Parameters", null);
			for (int i = 0; i < count; i++)
			{
				z0rek("Parameter", string.Empty, parameters[i], p3: true, p4: false);
			}
			z0ZzZzhqh2.z0bg();
		}
		if (p2.z0yek())
		{
			z0rek("SavePreviewImage", p2.z0yek());
		}
		z0rek("PreviewImageData", string.Empty, z0ZzZzkhh.z0eek(p2.z0tek()));
		z0rek("Width", p2.Width);
		z0rek("Height", p2.Height);
		z0tek("OptionsPropertyName", p2.z0iek());
		z0tek("Text", p2.Text);
		if (!p2.z0rek())
		{
			z0rek("CsMediaPlayer", p2.z0rek());
		}
		if (p2.LoopPlay)
		{
			z0rek("LoopPlay", p2.LoopPlay);
		}
		if (!p2.EnableMediaContextMenu)
		{
			z0rek("EnableMediaContextMenu", p2.EnableMediaContextMenu);
		}
		z0rek("Image", string.Empty, p2.Image, p3: false, p4: false);
		z0tek("FileName", p2.FileName);
		z0tek("FileSystemName", p2.FileSystemName);
		if (p2.PlayerUIMode != WindowsMediaPlayerUIMode.mini)
		{
			z0ZzZzhqh2.z0eek("PlayerUIMode", null, z0rek(p2.PlayerUIMode));
		}
		z0tek("FileContentType", p2.FileContentType);
		base.z0rek((object?)p2);
	}

	private string z0rek(WindowsMediaPlayerUIMode p0)
	{
		string text = null;
		return p0 switch
		{
			WindowsMediaPlayerUIMode.invisible => "invisible", 
			WindowsMediaPlayerUIMode.none => "none", 
			WindowsMediaPlayerUIMode.mini => "mini", 
			WindowsMediaPlayerUIMode.full => "full", 
			_ => throw z0ZzZzwhh.z0rek((long)p0, typeof(WindowsMediaPlayerUIMode)), 
		};
	}

	protected internal void z0rek(string p0, string p1, z0ZzZzolh p2, bool p3, bool p4)
	{
		z0iek = z0eek();
		z0ZzZzhqh z0ZzZzhqh2 = z0eek();
		if (p2 != null)
		{
			if (!p4 && !(p2.GetType() == typeof(z0ZzZzolh)))
			{
				throw z0eek(p2);
			}
			z0eek(p0, p1, p2, p3: false, null);
			if (p4)
			{
				z0eek("XBookMark");
			}
			if (p2.z0pek() != -1)
			{
				z0ZzZzhqh2.z0eek("StyleIndex", p2.z0pek());
			}
			z0rek(z0ZzZzhqh2, p2.Attributes);
			z0tek("ID", p2.ID);
			z0tek("Name", p2.Name);
			base.z0rek((object?)p2);
		}
	}

	private string z0rek(ChartStyleConsts p0)
	{
		string text = null;
		return p0 switch
		{
			ChartStyleConsts.Default => "Default", 
			ChartStyleConsts.Bar => "Bar", 
			ChartStyleConsts.Line => "Line", 
			ChartStyleConsts.Point => "Point", 
			_ => throw z0ZzZzwhh.z0rek((long)p0, typeof(ChartStyleConsts)), 
		};
	}

	protected internal void z0rek(string p0, string p1, DCContentLockInfo p2, bool p3, bool p4)
	{
		z0iek = z0eek();
		if (p2 != null)
		{
			if (!p4 && !(p2.GetType() == typeof(DCContentLockInfo)))
			{
				throw z0eek(p2);
			}
			z0eek(p0, p1, p2, p3: false, null);
			if (p4)
			{
				z0eek("DCContentLockInfo");
			}
			z0tek("OwnerUserID", p2.OwnerUserID);
			z0rek("CreationTime", z0ZzZzkhh.z0eek(p2.CreationTime));
			z0tek("AuthorisedUserIDList", p2.AuthorisedUserIDList);
			base.z0rek((object?)p2);
		}
	}

	protected internal void z0rek(string p0, string p1, z0ZzZzauj p2, bool p3, bool p4)
	{
		z0iek = z0eek();
		z0ZzZzhqh z0ZzZzhqh2 = z0eek();
		if (p2 == null)
		{
			return;
		}
		if (!p4)
		{
			Type type = p2.GetType();
			if (!(type == typeof(z0ZzZzauj)))
			{
				if (type == typeof(z0ZzZzuuj))
				{
					z0rek(p0, p1, (z0ZzZzuuj)p2, p3, p4: true);
					return;
				}
				throw z0eek(p2);
			}
		}
		z0eek(p0, p1, p2, p3: false, null);
		if (p4)
		{
			z0eek("ShapeLineElement");
		}
		if (((z0ZzZzhuj)p2).z0eek() != -1)
		{
			z0ZzZzhqh2.z0eek("StyleIndex", ((z0ZzZzhuj)p2).z0eek());
		}
		z0rek("LocalStyle", string.Empty, p2.z0pek(), p3: false, p4: false);
		if (!p2.z0rek_jiejie20260327142557())
		{
			z0rek("Visible", p2.z0rek_jiejie20260327142557());
		}
		z0tek("ID", ((z0ZzZzhuj)p2).z0yek());
		if (p2.z0eek() != 0f)
		{
			z0rek("X1", p2.z0eek());
		}
		if (p2.z0uek() != 0f)
		{
			z0rek("Y1", p2.z0uek());
		}
		if (p2.z0yek() != 0f)
		{
			z0rek("X2", p2.z0yek());
		}
		if (p2.z0rek() != 0f)
		{
			z0rek("Y2", p2.z0rek());
		}
		base.z0rek((object?)p2);
	}

	private string z0rek(XBrushStyleConst p0)
	{
		string text = null;
		return p0 switch
		{
			XBrushStyleConst.Disabled => "Disabled", 
			XBrushStyleConst.Solid => "Solid", 
			XBrushStyleConst.Horizontal => "Horizontal", 
			XBrushStyleConst.Vertical => "Vertical", 
			XBrushStyleConst.ForwardDiagonal => "ForwardDiagonal", 
			XBrushStyleConst.BackwardDiagonal => "BackwardDiagonal", 
			XBrushStyleConst.Cross => "Cross", 
			XBrushStyleConst.DiagonalCross => "DiagonalCross", 
			XBrushStyleConst.Percent05 => "Percent05", 
			XBrushStyleConst.Percent10 => "Percent10", 
			XBrushStyleConst.Percent20 => "Percent20", 
			XBrushStyleConst.Percent25 => "Percent25", 
			XBrushStyleConst.Percent30 => "Percent30", 
			XBrushStyleConst.Percent40 => "Percent40", 
			XBrushStyleConst.Percent50 => "Percent50", 
			XBrushStyleConst.Percent60 => "Percent60", 
			XBrushStyleConst.Percent70 => "Percent70", 
			XBrushStyleConst.Percent75 => "Percent75", 
			XBrushStyleConst.Percent80 => "Percent80", 
			XBrushStyleConst.Percent90 => "Percent90", 
			XBrushStyleConst.LightDownwardDiagonal => "LightDownwardDiagonal", 
			XBrushStyleConst.LightUpwardDiagonal => "LightUpwardDiagonal", 
			XBrushStyleConst.DarkDownwardDiagonal => "DarkDownwardDiagonal", 
			XBrushStyleConst.DarkUpwardDiagonal => "DarkUpwardDiagonal", 
			XBrushStyleConst.WideDownwardDiagonal => "WideDownwardDiagonal", 
			XBrushStyleConst.WideUpwardDiagonal => "WideUpwardDiagonal", 
			XBrushStyleConst.LightVertical => "LightVertical", 
			XBrushStyleConst.LightHorizontal => "LightHorizontal", 
			XBrushStyleConst.NarrowVertical => "NarrowVertical", 
			XBrushStyleConst.NarrowHorizontal => "NarrowHorizontal", 
			XBrushStyleConst.DarkVertical => "DarkVertical", 
			XBrushStyleConst.DarkHorizontal => "DarkHorizontal", 
			XBrushStyleConst.DashedDownwardDiagonal => "DashedDownwardDiagonal", 
			XBrushStyleConst.DashedUpwardDiagonal => "DashedUpwardDiagonal", 
			XBrushStyleConst.DashedHorizontal => "DashedHorizontal", 
			XBrushStyleConst.DashedVertical => "DashedVertical", 
			XBrushStyleConst.SmallConfetti => "SmallConfetti", 
			XBrushStyleConst.LargeConfetti => "LargeConfetti", 
			XBrushStyleConst.ZigZag => "ZigZag", 
			XBrushStyleConst.Wave => "Wave", 
			XBrushStyleConst.DiagonalBrick => "DiagonalBrick", 
			XBrushStyleConst.HorizontalBrick => "HorizontalBrick", 
			XBrushStyleConst.Weave => "Weave", 
			XBrushStyleConst.Plaid => "Plaid", 
			XBrushStyleConst.Divot => "Divot", 
			XBrushStyleConst.DottedGrid => "DottedGrid", 
			XBrushStyleConst.DottedDiamond => "DottedDiamond", 
			XBrushStyleConst.Shingle => "Shingle", 
			XBrushStyleConst.Trellis => "Trellis", 
			XBrushStyleConst.Sphere => "Sphere", 
			XBrushStyleConst.SmallGrid => "SmallGrid", 
			XBrushStyleConst.SmallCheckerBoard => "SmallCheckerBoard", 
			XBrushStyleConst.LargeCheckerBoard => "LargeCheckerBoard", 
			XBrushStyleConst.OutlinedDiamond => "OutlinedDiamond", 
			XBrushStyleConst.SolidDiamond => "SolidDiamond", 
			XBrushStyleConst.GradientBackwardDiagonal => "GradientBackwardDiagonal", 
			XBrushStyleConst.GradientForwardDiagonal => "GradientForwardDiagonal", 
			XBrushStyleConst.GradientHorizontal => "GradientHorizontal", 
			XBrushStyleConst.GradientVertical => "GradientVertical", 
			XBrushStyleConst.BackImage1 => "BackImage1", 
			XBrushStyleConst.BackImage2 => "BackImage2", 
			XBrushStyleConst.BackImage3 => "BackImage3", 
			XBrushStyleConst.BackImage4 => "BackImage4", 
			XBrushStyleConst.BackImage5 => "BackImage5", 
			XBrushStyleConst.BackImage6 => "BackImage6", 
			XBrushStyleConst.BackImage7 => "BackImage7", 
			XBrushStyleConst.BackImage8 => "BackImage8", 
			XBrushStyleConst.BackImage9 => "BackImage9", 
			XBrushStyleConst.BackImage10 => "BackImage10", 
			XBrushStyleConst.BackImage11 => "BackImage11", 
			XBrushStyleConst.BackImage12 => "BackImage12", 
			XBrushStyleConst.BackImage13 => "BackImage13", 
			XBrushStyleConst.Black => "Black", 
			XBrushStyleConst.White => "White", 
			_ => throw z0ZzZzwhh.z0rek((long)p0, typeof(XBrushStyleConst)), 
		};
	}

	protected internal void z0rek(string p0, string p1, z0ZzZzhyk p2, bool p3, bool p4)
	{
		z0iek = z0eek();
		z0ZzZzhqh z0ZzZzhqh2 = z0eek();
		if (p2 != null)
		{
			if (!p4 && !(p2.GetType() == typeof(z0ZzZzhyk)))
			{
				throw z0eek(p2);
			}
			z0eek(p0, p1, p2, p3: false, null);
			if (p4)
			{
				z0eek("PieLabelStyle");
			}
			if (!p2.Visible)
			{
				z0rek("Visible", p2.Visible);
			}
			z0rek("Font", p2.z0eek());
			z0rek("Color", p2.z0rek());
			z0rek("BackColor", p2.z0oek());
			z0rek("BorderColor", p2.z0mek());
			if (p2.z0uek() != 20)
			{
				z0rek("DownleadLength", p2.z0uek());
			}
			if (p2.z0tek() != 2)
			{
				z0rek("DownleadWidth", p2.z0tek());
			}
			if (p2.z0pek() != PieLabelType.OutLabel)
			{
				z0ZzZzhqh2.z0eek("EnumLableType", null, z0rek(p2.z0pek()));
			}
			base.z0rek((object?)p2);
		}
	}

	private string z0rek(ValueEditorActiveMode p0)
	{
		string text = null;
		return p0 switch
		{
			ValueEditorActiveMode.None => "None", 
			ValueEditorActiveMode.Default => "Default", 
			ValueEditorActiveMode.Program => "Program", 
			ValueEditorActiveMode.F2 => "F2", 
			ValueEditorActiveMode.GotFocus => "GotFocus", 
			ValueEditorActiveMode.MouseDblClick => "MouseDblClick", 
			ValueEditorActiveMode.MouseClick => "MouseClick", 
			ValueEditorActiveMode.MouseRightClick => "MouseRightClick", 
			ValueEditorActiveMode.Enter => "Enter", 
			_ => z0ZzZzkhh.z0eek((long)p0, z0ZzZzwhh.z0mek, z0ZzZzwhh.z0bek, "DCSoft.Writer.ValueEditorActiveMode"), 
		};
	}

	private string z0rek(DashStyle p0)
	{
		string text = null;
		return p0 switch
		{
			DashStyle.Solid => "Solid", 
			DashStyle.Dash => "Dash", 
			DashStyle.Dot => "Dot", 
			DashStyle.DashDot => "DashDot", 
			DashStyle.DashDotDot => "DashDotDot", 
			DashStyle.Custom => "Custom", 
			_ => throw z0ZzZzwhh.z0rek((long)p0, typeof(DashStyle)), 
		};
	}

	private bool z0rek(z0ZzZzhqh p0, XTextElement p1)
	{
		if (p1.z0pek() != -1)
		{
			p0.z0eek("StyleIndex", p1.z0pek());
		}
		if (p1 is XTextObjectElement xTextObjectElement)
		{
			z0rek(p0, xTextObjectElement.z0qrk);
			z0tek("ID", xTextObjectElement.ID);
			z0tek("ToolTip", xTextObjectElement.ToolTip);
			if (xTextObjectElement.OffsetX != 0f)
			{
				z0rek("OffsetX", xTextObjectElement.OffsetX);
			}
			if (xTextObjectElement.OffsetY != 0f)
			{
				z0rek("OffsetY", xTextObjectElement.OffsetY);
			}
			if (xTextObjectElement.ZOrderStyle != ElementZOrderStyle.Normal)
			{
				p0.z0eek("ZOrderStyle", null, z0rek(xTextObjectElement.ZOrderStyle));
			}
			z0rek(p0, xTextObjectElement.z0srk);
			z0tek("ValueExpression", xTextObjectElement.ValueExpression);
			if (!xTextObjectElement.Visible)
			{
				z0rek("Visible", xTextObjectElement.Visible);
			}
			if (xTextObjectElement.PrintVisibility != ElementVisibility.Visible)
			{
				p0.z0eek("PrintVisibility", null, z0rek(xTextObjectElement.PrintVisibility));
			}
			z0rek("LinkInfo", string.Empty, xTextObjectElement.z0iek(), p3: false, p4: false);
			if (xTextObjectElement.ContentReadonly != ContentReadonlyState.Inherit)
			{
				p0.z0eek("ContentReadonly", null, z0rek(xTextObjectElement.ContentReadonly));
			}
			if (!xTextObjectElement.Deleteable)
			{
				z0rek("Deleteable", xTextObjectElement.Deleteable);
			}
			z0tek("Name", xTextObjectElement.Name);
			if (!xTextObjectElement.Enabled)
			{
				z0rek("Enabled", xTextObjectElement.Enabled);
			}
			z0tek("StringTag", xTextObjectElement.StringTag);
			if (xTextObjectElement is XTextCheckBoxElementBase { CheckedUserHistories: var checkedUserHistories } xTextCheckBoxElementBase)
			{
				if (checkedUserHistories != null && checkedUserHistories.Count > 0)
				{
					int count = checkedUserHistories.Count;
					p0.z0hf(null, "CheckedUserHistories", null);
					for (int i = 0; i < count; i++)
					{
						z0rek("Item", string.Empty, checkedUserHistories[i], p3: true, p4: false);
					}
					p0.z0bg();
				}
				if (xTextCheckBoxElementBase.Requried)
				{
					z0rek("Requried", xTextCheckBoxElementBase.Requried);
				}
				z0tek("DataName", xTextCheckBoxElementBase.DataName);
				if (xTextCheckBoxElementBase.CanBeReferenced)
				{
					z0rek("CanBeReferenced", xTextCheckBoxElementBase.CanBeReferenced);
				}
				if (xTextCheckBoxElementBase.BringoutToSave)
				{
					z0rek("BringoutToSave", xTextCheckBoxElementBase.BringoutToSave);
				}
				if (xTextCheckBoxElementBase.CheckboxVisibility != RenderVisibility.All)
				{
					z0rek("CheckboxVisibility", string.Empty, z0rek(xTextCheckBoxElementBase.CheckboxVisibility));
				}
				if (xTextCheckBoxElementBase.PrintVisibilityWhenUnchecked != PrintVisibilityModeWhenUnchecked.Visible)
				{
					p0.z0eek("PrintVisibilityWhenUnchecked", null, z0rek(xTextCheckBoxElementBase.PrintVisibilityWhenUnchecked));
				}
				z0tek("PrintTextForChecked", xTextCheckBoxElementBase.PrintTextForChecked);
				z0tek("PrintTextForUnChecked", xTextCheckBoxElementBase.PrintTextForUnChecked);
				if (!xTextCheckBoxElementBase.CheckAlignLeft)
				{
					z0rek("CheckAlignLeft", xTextCheckBoxElementBase.CheckAlignLeft);
				}
				z0tek("Caption", xTextCheckBoxElementBase.Caption);
				if (xTextCheckBoxElementBase.CaptionFlowLayout)
				{
					z0rek("CaptionFlowLayout", xTextCheckBoxElementBase.CaptionFlowLayout);
				}
				if (xTextCheckBoxElementBase.CaptionAlign != StringAlignment.Center)
				{
					p0.z0eek("CaptionAlign", null, z0rek(xTextCheckBoxElementBase.CaptionAlign));
				}
				z0rek("ValueBinding", string.Empty, xTextCheckBoxElementBase.ValueBinding, p3: false, p4: false);
				if (xTextCheckBoxElementBase.AutoHeightForMultiline)
				{
					z0rek("AutoHeightForMultiline", xTextCheckBoxElementBase.AutoHeightForMultiline);
				}
				z0rek("Width", xTextCheckBoxElementBase.Width);
				z0rek("Height", xTextCheckBoxElementBase.Height);
				z0tek("GroupName", xTextCheckBoxElementBase.GroupName);
				if (xTextCheckBoxElementBase.z0oi() != CheckBoxControlStyle.CheckBox)
				{
					p0.z0eek("ControlStyle", null, z0rek(xTextCheckBoxElementBase.z0oi()));
				}
				if (xTextCheckBoxElementBase.Checked)
				{
					z0rek("Checked", xTextCheckBoxElementBase.Checked);
				}
				if (xTextCheckBoxElementBase.DefaultCheckedForValueBinding)
				{
					z0rek("DefaultCheckedForValueBinding", xTextCheckBoxElementBase.DefaultCheckedForValueBinding);
				}
				z0tek("CheckedValue", xTextCheckBoxElementBase.CheckedValue);
				if (xTextCheckBoxElementBase.Readonly)
				{
					z0rek("Readonly", xTextCheckBoxElementBase.Readonly);
				}
				if (xTextCheckBoxElementBase.EnableHighlight != EnableState.Enabled)
				{
					p0.z0eek("EnableHighlight", null, z0rek(xTextCheckBoxElementBase.EnableHighlight));
				}
				z0ZzZzukh z0nrk = xTextCheckBoxElementBase.z0nrk;
				if (z0nrk != null && z0nrk.Count > 0)
				{
					int count2 = z0nrk.Count;
					p0.z0hf(null, "EventExpressions", null);
					for (int j = 0; j < count2; j++)
					{
						z0rek("Expression", string.Empty, z0nrk[j], p3: true, p4: false);
					}
					p0.z0bg();
				}
				if (!xTextCheckBoxElementBase.CheckBoxVisible)
				{
					z0rek("CheckBoxVisible", xTextCheckBoxElementBase.CheckBoxVisible);
				}
				if (xTextCheckBoxElementBase.VisualStyle != CheckBoxVisualStyle.Default)
				{
					p0.z0eek("VisualStyle", null, z0rek(xTextCheckBoxElementBase.VisualStyle));
				}
				if (xTextCheckBoxElementBase.Multiline)
				{
					z0rek("Multiline", xTextCheckBoxElementBase.Multiline);
				}
			}
			else
			{
				if (xTextObjectElement is XTextImageElement xTextImageElement)
				{
					if (xTextImageElement.z0iek() != -1)
					{
						p0.z0eek("InnerRepeatImageIndex", xTextImageElement.z0iek());
					}
					z0rek("ValueBinding", string.Empty, xTextImageElement.ValueBinding, p3: false, p4: false);
					z0tek("TransparentColorValue", xTextImageElement.TransparentColorValue);
					if (!xTextImageElement.EnableEditImageAdditionShape)
					{
						z0rek("EnableEditImageAdditionShape", xTextImageElement.EnableEditImageAdditionShape);
					}
					if (xTextImageElement.z0mrk())
					{
						z0rek("EnableRepeatedImage", xTextImageElement.z0mrk());
					}
					if (xTextImageElement.z0cek() != -1)
					{
						z0rek("ValueIndexOfRepeatedImage", xTextImageElement.z0cek());
					}
					if (xTextImageElement.VAlign != VerticalAlignStyle.Bottom)
					{
						p0.z0eek("VAlign", null, z0rek(xTextImageElement.VAlign));
					}
					z0tek("Title", xTextImageElement.z0vrk());
					z0tek("Alt", xTextImageElement.z0tek());
					if (!xTextImageElement.KeepWidthHeightRate)
					{
						z0rek("KeepWidthHeightRate", xTextImageElement.KeepWidthHeightRate);
					}
					z0tek("Source", xTextImageElement.z0mek());
					if (!xTextImageElement.SaveContentInFile)
					{
						z0rek("SaveContentInFile", xTextImageElement.SaveContentInFile);
					}
					z0rek("Width", xTextImageElement.Width);
					z0rek("Height", xTextImageElement.Height);
					z0rek("AdditionShape", string.Empty, xTextImageElement.z0brk(), p3: false, p4: false);
					if (xTextImageElement.z0jrk())
					{
						z0rek("AdditionShapeFixSize", xTextImageElement.z0jrk());
					}
					z0rek("Image", string.Empty, xTextImageElement.z0frk(), p3: false, p4: false);
					z0ZzZzdzj z0ktk = xTextImageElement.z0ktk;
					if (z0ktk != null && z0ktk.Count > 0)
					{
						int count3 = z0ktk.Count;
						p0.z0hf(null, "PageImages", null);
						for (int k = 0; k < count3; k++)
						{
							z0rek("Image", string.Empty, z0ktk[k], p3: true, p4: false);
						}
						p0.z0bg();
					}
					if (!xTextImageElement.SmoothZoom)
					{
						z0rek("SmoothZoom", xTextImageElement.SmoothZoom);
					}
					z0tek("CustomAdditionShapeContent", xTextImageElement.z0yrk());
					return true;
				}
				if (xTextObjectElement is XTextButtonElement xTextButtonElement)
				{
					if (xTextButtonElement.PrintAsText)
					{
						z0rek("PrintAsText", xTextButtonElement.PrintAsText);
					}
					if (xTextButtonElement.AutoSize)
					{
						z0rek("AutoSize", xTextButtonElement.AutoSize);
					}
					z0rek("Image", string.Empty, xTextButtonElement.Image, p3: false, p4: false);
					z0rek("ImageForDown", string.Empty, xTextButtonElement.ImageForDown, p3: false, p4: false);
					z0rek("ImageForMouseOver", string.Empty, xTextButtonElement.ImageForMouseOver, p3: false, p4: false);
					z0rek("Width", xTextButtonElement.Width);
					z0rek("Height", xTextButtonElement.Height);
					z0tek("Text", xTextButtonElement.Text);
					z0tek("ScriptTextForClick", xTextButtonElement.ScriptTextForClick);
					z0tek("CommandName", xTextButtonElement.CommandName);
					return true;
				}
				if (xTextObjectElement is XTextLabelElementBase xTextLabelElementBase)
				{
					z0rek("ValueBinding", string.Empty, xTextLabelElementBase.ValueBinding, p3: false, p4: false);
					z0rek("Width", xTextLabelElementBase.Width);
					z0rek("Height", xTextLabelElementBase.Height);
					z0tek("Text", xTextLabelElementBase.Text);
					PageLabelTextList pageTexts = xTextLabelElementBase.PageTexts;
					if (pageTexts != null && pageTexts.Count > 0)
					{
						int count4 = pageTexts.Count;
						p0.z0hf(null, "PageTexts", null);
						for (int l = 0; l < count4; l++)
						{
							z0rek("PageText", string.Empty, pageTexts[l], p3: true, p4: false);
						}
						p0.z0bg();
					}
					if (xTextLabelElementBase.StrictMatchPageIndex)
					{
						z0rek("StrictMatchPageIndex", xTextLabelElementBase.StrictMatchPageIndex);
					}
					if (xTextLabelElementBase is XTextLabelElement xTextLabelElement)
					{
						if (xTextLabelElement.AllowUserEditCurrentPageLabelText)
						{
							z0rek("AllowUserEditCurrentPageLabelText", xTextLabelElement.AllowUserEditCurrentPageLabelText);
						}
						if (xTextLabelElement.z0rek() != -1)
						{
							z0rek("ReferencedTopicID", xTextLabelElement.z0rek());
						}
						if (xTextLabelElement.ContactAction != LabelTextContactActionMode.Disable)
						{
							p0.z0eek("ContactAction", null, z0rek(xTextLabelElement.ContactAction));
						}
						z0tek("AttributeNameForContactAction", xTextLabelElement.AttributeNameForContactAction);
						z0tek("LinkTextForContactAction", xTextLabelElement.LinkTextForContactAction);
						if (xTextLabelElement.Alignment != DCContentAlignment.MiddleCenter)
						{
							p0.z0eek("Alignment", null, z0rek(xTextLabelElement.Alignment));
						}
						if (!xTextLabelElement.Multiline)
						{
							z0rek("Multiline", xTextLabelElement.Multiline);
						}
						if (!xTextLabelElement.AutoSize)
						{
							z0rek("AutoSize", xTextLabelElement.AutoSize);
						}
						return true;
					}
					if (xTextLabelElementBase is XTextTDBarcodeElement xTextTDBarcodeElement)
					{
						if (xTextTDBarcodeElement.VAlign != VerticalAlignStyle.Bottom)
						{
							p0.z0eek("VAlign", null, z0rek(xTextTDBarcodeElement.VAlign));
						}
						if (xTextTDBarcodeElement.BarcodeType != DCTDBarcodeType.QR)
						{
							p0.z0eek("BarcodeType", null, z0rek(xTextTDBarcodeElement.BarcodeType));
						}
						if (xTextTDBarcodeElement.ErroeCorrectionLevel != DCTBErroeCorrectionLevelType.M)
						{
							p0.z0eek("ErroeCorrectionLevel", null, z0rek(xTextTDBarcodeElement.ErroeCorrectionLevel));
						}
						return true;
					}
					if (xTextLabelElementBase is XTextNewBarcodeElement xTextNewBarcodeElement)
					{
						if (xTextNewBarcodeElement.BarcodeStyle2 != DCBarcodeStyle.Code128C)
						{
							p0.z0eek("BarcodeStyle2", null, z0rek(xTextNewBarcodeElement.BarcodeStyle2));
						}
						if (xTextNewBarcodeElement.TextAlignment != StringAlignment.Center)
						{
							p0.z0eek("TextAlignment", null, z0rek(xTextNewBarcodeElement.TextAlignment));
						}
						if (!xTextNewBarcodeElement.ShowText)
						{
							z0rek("ShowText", xTextNewBarcodeElement.ShowText);
						}
						return true;
					}
				}
				else if (xTextObjectElement is XTextControlHostElement xTextControlHostElement)
				{
					if (xTextControlHostElement.DelayLoadControl)
					{
						z0rek("DelayLoadControl", xTextControlHostElement.DelayLoadControl);
					}
					if (xTextControlHostElement.VAlign != VerticalAlignStyle.Top)
					{
						p0.z0eek("VAlign", null, z0rek(xTextControlHostElement.VAlign));
					}
					if (xTextControlHostElement.z0ry() != 0)
					{
						p0.z0eek("ControlType", null, z0rek(xTextControlHostElement.z0ry()));
					}
					z0tek("TypeFullName", xTextControlHostElement.TypeFullName);
					z0tek("ValuePropertyName", xTextControlHostElement.ValuePropertyName);
					if (xTextControlHostElement.z0uek() != (z0ZzZzgzj)2)
					{
						p0.z0eek("HostMode", null, z0rek(xTextControlHostElement.z0uek()));
					}
					if (xTextControlHostElement.AllowUserResize != ResizeableType.WidthAndHeight)
					{
						p0.z0eek("AllowUserResize", null, z0rek(xTextControlHostElement.AllowUserResize));
					}
					ObjectParameterList parameters = xTextControlHostElement.Parameters;
					if (parameters != null && parameters.Count > 0)
					{
						int count5 = parameters.Count;
						p0.z0hf(null, "Parameters", null);
						for (int m = 0; m < count5; m++)
						{
							z0rek("Parameter", string.Empty, parameters[m], p3: true, p4: false);
						}
						p0.z0bg();
					}
					if (xTextControlHostElement.z0yek())
					{
						z0rek("SavePreviewImage", xTextControlHostElement.z0yek());
					}
					z0rek("PreviewImageData", string.Empty, z0ZzZzkhh.z0eek(xTextControlHostElement.z0tek()));
					z0rek("Width", xTextControlHostElement.Width);
					z0rek("Height", xTextControlHostElement.Height);
					z0tek("OptionsPropertyName", xTextControlHostElement.z0iek());
					z0tek("Text", xTextControlHostElement.Text);
					if (xTextControlHostElement is XTextMediaElement xTextMediaElement)
					{
						if (!xTextMediaElement.z0rek())
						{
							z0rek("CsMediaPlayer", xTextMediaElement.z0rek());
						}
						if (xTextMediaElement.LoopPlay)
						{
							z0rek("LoopPlay", xTextMediaElement.LoopPlay);
						}
						if (!xTextMediaElement.EnableMediaContextMenu)
						{
							z0rek("EnableMediaContextMenu", xTextMediaElement.EnableMediaContextMenu);
						}
						z0rek("Image", string.Empty, xTextMediaElement.Image, p3: false, p4: false);
						z0tek("FileName", xTextMediaElement.FileName);
						z0tek("FileSystemName", xTextMediaElement.FileSystemName);
						if (xTextMediaElement.PlayerUIMode != WindowsMediaPlayerUIMode.mini)
						{
							p0.z0eek("PlayerUIMode", null, z0rek(xTextMediaElement.PlayerUIMode));
						}
						z0tek("FileContentType", xTextMediaElement.FileContentType);
						return true;
					}
					if (xTextControlHostElement.GetType() == typeof(XTextControlHostElement))
					{
						return true;
					}
				}
				else if (!(xTextObjectElement is XTextNewMedicalExpressionElement) && !(xTextObjectElement is z0ZzZzjkh) && !(xTextObjectElement is XTextRulerElement) && !(xTextObjectElement is XTextBlankLineElement) && !(xTextObjectElement is XTextCustomShapeElement) && !(xTextObjectElement is XTextPageInfoElement))
				{
				}
			}
		}
		else if (p1 is XTextContainerElement xTextContainerElement)
		{
			if (xTextContainerElement is XTextInputFieldElementBase xTextInputFieldElementBase)
			{
				if (!(xTextInputFieldElementBase is XTextInputFieldElement) && xTextInputFieldElementBase is XTextShapeInputFieldElement xTextShapeInputFieldElement && !(xTextShapeInputFieldElement is XTextBarcodeFieldElement) && !(xTextShapeInputFieldElement is XTextMedicalExpressionFieldElement))
				{
				}
			}
			else if (xTextContainerElement is XTextContentElement xTextContentElement)
			{
				if (!(xTextContentElement is XTextTableCellElement) && xTextContentElement is XTextSectionElement xTextSectionElement && !(xTextSectionElement is XTextSubDocumentElement))
				{
				}
			}
			else
			{
				_ = xTextContainerElement is XTextTableElement;
			}
		}
		throw new NotSupportedException(p1.GetType().FullName);
	}

	protected internal void z0rek(string p0, string p1, PropertyExpressionInfo p2, bool p3, bool p4)
	{
		z0iek = z0eek();
		z0ZzZzhqh z0ZzZzhqh2 = z0eek();
		if (p2 != null)
		{
			if (!p4 && !(p2.GetType() == typeof(PropertyExpressionInfo)))
			{
				throw z0eek(p2);
			}
			z0eek(p0, p1, p2, p3: false, null);
			if (p4)
			{
				z0eek("PropertyExpressionInfo");
			}
			z0eek("Name", p2.Name);
			if (!p2.AllowChainReaction)
			{
				z0ZzZzhqh2.z0eek("AllowChainReaction", p2.AllowChainReaction);
			}
			if (p2.Expression != null)
			{
				base.z0rek(p2.Expression);
			}
			base.z0rek((object?)p2);
		}
	}

	protected internal void z0rek(string p0, string p1, DocumentContentStyle p2, bool p3, bool p4)
	{
		z0iek = z0eek();
		z0ZzZzhqh z0ZzZzhqh2 = z0eek();
		if (p2 != null)
		{
			if (!p4 && !(p2.GetType() == typeof(DocumentContentStyle)))
			{
				throw z0eek(p2);
			}
			z0eek(p0, p1, p2, p3: false, null);
			if (p4)
			{
				z0eek("DocumentContentStyle");
			}
			if (p2.Index != -1)
			{
				z0ZzZzhqh2.z0eek("Index", p2.Index);
			}
			z0tek("BackgroundColor", p2.BackgroundColorString);
			z0tek("BackgroundColor2", p2.BackgroundColor2String);
			if (p2.Visibility != RenderVisibility.All)
			{
				z0rek("Visibility", string.Empty, z0rek(p2.Visibility));
			}
			z0tek("Color", p2.ColorString);
			z0tek("FontName", p2.FontName);
			if (p2.FontSize != 0f)
			{
				z0rek("FontSize", p2.FontSize);
			}
			if (p2.EmphasisMark)
			{
				z0rek("EmphasisMark", p2.EmphasisMark);
			}
			if (p2.Bold)
			{
				z0rek("Bold", p2.Bold);
			}
			if (p2.Italic)
			{
				z0rek("Italic", p2.Italic);
			}
			if (p2.Underline)
			{
				z0rek("Underline", p2.Underline);
			}
			if (p2.UnderlineStyle != TextUnderlineStyle.Single)
			{
				z0ZzZzhqh2.z0eek("UnderlineStyle", null, z0rek(p2.UnderlineStyle));
			}
			z0tek("UnderlineColor", p2.UnderlineColor);
			if (p2.Strikeout)
			{
				z0rek("Strikeout", p2.Strikeout);
			}
			if (p2.Superscript)
			{
				z0rek("Superscript", p2.Superscript);
			}
			if (p2.Subscript)
			{
				z0rek("Subscript", p2.Subscript);
			}
			if (p2.FixedSpacing)
			{
				z0rek("FixedSpacing", p2.FixedSpacing);
			}
			if (p2.SpacingAfterParagraph != 0f)
			{
				z0rek("SpacingAfterParagraph", p2.SpacingAfterParagraph);
			}
			if (p2.SpacingBeforeParagraph != 0f)
			{
				z0rek("SpacingBeforeParagraph", p2.SpacingBeforeParagraph);
			}
			if (p2.LineSpacingStyle != LineSpacingStyle.SpaceSingle)
			{
				z0ZzZzhqh2.z0eek("LineSpacingStyle", null, z0rek(p2.LineSpacingStyle));
			}
			if (p2.LetterSpacing != 0f)
			{
				z0rek("LetterSpacing", p2.LetterSpacing);
			}
			if (p2.LineSpacing != 0f)
			{
				z0rek("LineSpacing", p2.LineSpacing);
			}
			if (p2.RTFLineSpacing != 0f)
			{
				z0rek("RTFLineSpacing", p2.RTFLineSpacing);
			}
			if (p2.Align != DocumentContentAlignment.Left)
			{
				z0ZzZzhqh2.z0eek("Align", null, z0rek(p2.Align));
			}
			if (p2.VerticalAlign != VerticalAlignStyle.Top)
			{
				z0ZzZzhqh2.z0eek("VerticalAlign", null, z0rek(p2.VerticalAlign));
			}
			if (p2.FirstLineIndent != 0f)
			{
				z0rek("FirstLineIndent", p2.FirstLineIndent);
			}
			if (p2.LeftIndent != 0f)
			{
				z0rek("LeftIndent", p2.LeftIndent);
			}
			if (p2.RightToLeft)
			{
				z0rek("RightToLeft", p2.RightToLeft);
			}
			if (p2.Multiline)
			{
				z0rek("Multiline", p2.Multiline);
			}
			if (p2.LayoutAlign != ContentLayoutAlign.EmbedInText)
			{
				z0ZzZzhqh2.z0eek("LayoutAlign", null, z0rek(p2.LayoutAlign));
			}
			if (p2.CharacterCircle != CharacterCircleStyles.None)
			{
				z0ZzZzhqh2.z0eek("CharacterCircle", null, z0rek(p2.CharacterCircle));
			}
			z0tek("BorderLeftColor", p2.BorderLeftColorString);
			z0tek("BorderTopColor", p2.BorderTopColorString);
			z0tek("BorderRightColor", p2.BorderRightColorString);
			z0tek("BorderBottomColor", p2.BorderBottomColorString);
			if (p2.BorderStyle != DashStyle.Solid)
			{
				z0ZzZzhqh2.z0eek("BorderStyle", null, z0rek(p2.BorderStyle));
			}
			if (p2.BorderWidth != 0f)
			{
				z0rek("BorderWidth", p2.BorderWidth);
			}
			if (p2.BorderLeft)
			{
				z0rek("BorderLeft", p2.BorderLeft);
			}
			if (p2.BorderBottom)
			{
				z0rek("BorderBottom", p2.BorderBottom);
			}
			if (p2.BorderTop)
			{
				z0rek("BorderTop", p2.BorderTop);
			}
			if (p2.BorderRight)
			{
				z0rek("BorderRight", p2.BorderRight);
			}
			if (p2.BorderSpacing != 0f)
			{
				z0rek("BorderSpacing", p2.BorderSpacing);
			}
			if (p2.MarginLeft != 0f)
			{
				z0rek("MarginLeft", p2.MarginLeft);
			}
			if (p2.MarginTop != 0f)
			{
				z0rek("MarginTop", p2.MarginTop);
			}
			if (p2.MarginRight != 0f)
			{
				z0rek("MarginRight", p2.MarginRight);
			}
			if (p2.MarginBottom != 0f)
			{
				z0rek("MarginBottom", p2.MarginBottom);
			}
			if (p2.PaddingLeft != 0f)
			{
				z0rek("PaddingLeft", p2.PaddingLeft);
			}
			if (p2.PaddingTop != 0f)
			{
				z0rek("PaddingTop", p2.PaddingTop);
			}
			if (p2.PaddingRight != 0f)
			{
				z0rek("PaddingRight", p2.PaddingRight);
			}
			if (p2.PaddingBottom != 0f)
			{
				z0rek("PaddingBottom", p2.PaddingBottom);
			}
			if (p2.ParagraphMultiLevel)
			{
				z0rek("ParagraphMultiLevel", p2.ParagraphMultiLevel);
			}
			if (p2.ParagraphOutlineLevel != -1)
			{
				z0rek("ParagraphOutlineLevel", p2.ParagraphOutlineLevel);
			}
			if (!p2.VisibleInDirectory)
			{
				z0rek("VisibleInDirectory", p2.VisibleInDirectory);
			}
			if (p2.ParagraphListStyle != ParagraphListStyle.None)
			{
				z0ZzZzhqh2.z0eek("ParagraphListStyle", null, z0rek(p2.ParagraphListStyle));
			}
			z0tek("PrintColor", p2.PrintColorString);
			z0tek("PrintBackColor", p2.PrintBackColorString);
			if (p2.LayoutDirection != ContentLayoutDirectionStyle.Default)
			{
				z0ZzZzhqh2.z0eek("LayoutDirection", null, z0rek(p2.LayoutDirection));
			}
			if (p2.CommentIndex != -1)
			{
				z0rek("CommentIndex", p2.CommentIndex);
			}
			if (p2.ProtectType != ContentProtectType.None)
			{
				z0ZzZzhqh2.z0eek("ProtectType", null, z0rek(p2.ProtectType));
			}
			if (p2.TitleLevel != -1)
			{
				z0rek("TitleLevel", p2.TitleLevel);
			}
			if (p2.GridLineType != ContentGridLineType.None)
			{
				z0ZzZzhqh2.z0eek("GridLineType", null, z0rek(p2.GridLineType));
			}
			if (p2.GridLineOffsetY != 0f)
			{
				z0rek("GridLineOffsetY", p2.GridLineOffsetY);
			}
			if (p2.GridLineStyle != DashStyle.Solid)
			{
				z0ZzZzhqh2.z0eek("GridLineStyle", null, z0rek(p2.GridLineStyle));
			}
			z0tek("GridLineColor", p2.GridLineColorString);
			if (p2.CreatorIndex != -1)
			{
				z0rek("CreatorIndex", p2.CreatorIndex);
			}
			z0tek("Cursor", p2.Cursor);
			if (p2.DeleterIndex != -1)
			{
				z0rek("DeleterIndex", p2.DeleterIndex);
			}
			base.z0rek((object?)p2);
		}
	}

	private string z0rek(ChartViewStyle p0)
	{
		string text = null;
		return p0 switch
		{
			ChartViewStyle.Bar => "Bar", 
			ChartViewStyle.CascadeBar => "CascadeBar", 
			ChartViewStyle.PercentBar => "PercentBar", 
			ChartViewStyle.HorizBar => "HorizBar", 
			ChartViewStyle.HorizCascadeBar => "HorizCascadeBar", 
			ChartViewStyle.HorizPercentBar => "HorizPercentBar", 
			ChartViewStyle.ColumnBar => "ColumnBar", 
			ChartViewStyle.CascadeColumnBar => "CascadeColumnBar", 
			ChartViewStyle.PercentColumnBar => "PercentColumnBar", 
			ChartViewStyle.HorizColumnBar => "HorizColumnBar", 
			ChartViewStyle.HorizCascadeColumnBar => "HorizCascadeColumnBar", 
			ChartViewStyle.HorizPercentColumnBar => "HorizPercentColumnBar", 
			ChartViewStyle.Line => "Line", 
			ChartViewStyle.Area => "Area", 
			ChartViewStyle.HorizLine => "HorizLine", 
			ChartViewStyle.HorizArea => "HorizArea", 
			ChartViewStyle.Point => "Point", 
			ChartViewStyle.HorizPoint => "HorizPoint", 
			_ => throw z0ZzZzwhh.z0rek((long)p0, typeof(ChartViewStyle)), 
		};
	}

	private string z0rek(DocumentContentAlignment p0)
	{
		string text = null;
		return p0 switch
		{
			DocumentContentAlignment.Left => "Left", 
			DocumentContentAlignment.Center => "Center", 
			DocumentContentAlignment.Right => "Right", 
			DocumentContentAlignment.Justify => "Justify", 
			DocumentContentAlignment.Distribute => "Distribute", 
			_ => throw z0ZzZzwhh.z0rek((long)p0, typeof(DocumentContentAlignment)), 
		};
	}

	protected internal void z0rek(string p0, string p1, XTextPageInfoElement p2, bool p3, bool p4)
	{
		z0iek = z0eek();
		z0ZzZzhqh z0ZzZzhqh2 = z0eek();
		if (p2 == null)
		{
			return;
		}
		if (!p4 && !(p2.GetType() == typeof(XTextPageInfoElement)))
		{
			throw z0eek(p2);
		}
		z0eek(p0, p1, p2, p3: false, null);
		if (p4)
		{
			z0eek("XPageInfo");
		}
		if (((XTextElement)p2).z0pek() != -1)
		{
			z0ZzZzhqh2.z0eek("StyleIndex", ((XTextElement)p2).z0pek());
		}
		z0rek(z0ZzZzhqh2, p2.Attributes);
		z0tek("ID", p2.ID);
		z0tek("ToolTip", p2.ToolTip);
		if (p2.OffsetX != 0f)
		{
			z0rek("OffsetX", p2.OffsetX);
		}
		if (p2.OffsetY != 0f)
		{
			z0rek("OffsetY", p2.OffsetY);
		}
		if (p2.ZOrderStyle != ElementZOrderStyle.Normal)
		{
			z0ZzZzhqh2.z0eek("ZOrderStyle", null, z0rek(p2.ZOrderStyle));
		}
		z0rek(z0ZzZzhqh2, p2.PropertyExpressions);
		z0tek("ValueExpression", p2.ValueExpression);
		if (!p2.Visible)
		{
			z0rek("Visible", p2.Visible);
		}
		if (p2.PrintVisibility != ElementVisibility.Visible)
		{
			z0ZzZzhqh2.z0eek("PrintVisibility", null, z0rek(p2.PrintVisibility));
		}
		z0rek("LinkInfo", string.Empty, p2.z0iek(), p3: false, p4: false);
		if (p2.ContentReadonly != ContentReadonlyState.Inherit)
		{
			z0ZzZzhqh2.z0eek("ContentReadonly", null, z0rek(p2.ContentReadonly));
		}
		if (!p2.Deleteable)
		{
			z0rek("Deleteable", p2.Deleteable);
		}
		z0tek("Name", p2.Name);
		if (!p2.Enabled)
		{
			z0rek("Enabled", p2.Enabled);
		}
		z0tek("StringTag", p2.StringTag);
		SpecifyPageIndexInfoList specifyPageIndexs = p2.SpecifyPageIndexs;
		if (specifyPageIndexs != null && specifyPageIndexs.Count > 0)
		{
			int count = specifyPageIndexs.Count;
			z0ZzZzhqh2.z0hf(null, "SpecifyPageIndexs", null);
			for (int i = 0; i < count; i++)
			{
				z0rek("Index", string.Empty, specifyPageIndexs[i], p3: true, p4: false);
			}
			z0ZzZzhqh2.z0bg();
		}
		z0rek("Width", p2.Width);
		if (p2.AutoHeight)
		{
			z0rek("AutoHeight", p2.AutoHeight);
		}
		z0rek("Height", p2.Height);
		if (p2.PageIndexFix != 0)
		{
			z0rek("PageIndexFix", p2.PageIndexFix);
		}
		if (!p2.ChangePageIndexMidway)
		{
			z0rek("ChangePageIndexMidway", p2.ChangePageIndexMidway);
		}
		if (p2.ValueType != PageInfoValueType.PageIndex)
		{
			z0ZzZzhqh2.z0eek("ValueType", null, z0rek(p2.ValueType));
		}
		if (p2.DisplayFormat != ParagraphListStyle.ListNumberStyle)
		{
			z0ZzZzhqh2.z0eek("DisplayFormat", null, z0rek(p2.DisplayFormat));
		}
		z0tek("FormatString", p2.FormatString);
		z0tek("SpecifyPageIndexTextList", p2.SpecifyPageIndexTextList);
		base.z0rek((object?)p2);
	}

	protected internal void z0rek(string p0, string p1, XTextNewMedicalExpressionElement p2, bool p3, bool p4)
	{
		z0iek = z0eek();
		z0ZzZzhqh z0ZzZzhqh2 = z0eek();
		if (p2 == null)
		{
			return;
		}
		if (!p4 && !(p2.GetType() == typeof(XTextNewMedicalExpressionElement)))
		{
			throw z0eek(p2);
		}
		z0eek(p0, p1, p2, p3: false, null);
		if (p4)
		{
			z0eek("XNewMedicalExpression");
		}
		if (((XTextElement)p2).z0pek() != -1)
		{
			z0ZzZzhqh2.z0eek("StyleIndex", ((XTextElement)p2).z0pek());
		}
		z0rek(z0ZzZzhqh2, p2.Attributes);
		z0tek("ID", p2.ID);
		z0tek("ToolTip", p2.ToolTip);
		if (p2.OffsetX != 0f)
		{
			z0rek("OffsetX", p2.OffsetX);
		}
		if (p2.OffsetY != 0f)
		{
			z0rek("OffsetY", p2.OffsetY);
		}
		if (p2.ZOrderStyle != ElementZOrderStyle.Normal)
		{
			z0ZzZzhqh2.z0eek("ZOrderStyle", null, z0rek(p2.ZOrderStyle));
		}
		z0rek(z0ZzZzhqh2, p2.PropertyExpressions);
		z0tek("ValueExpression", p2.ValueExpression);
		if (!p2.Visible)
		{
			z0rek("Visible", p2.Visible);
		}
		if (p2.PrintVisibility != ElementVisibility.Visible)
		{
			z0ZzZzhqh2.z0eek("PrintVisibility", null, z0rek(p2.PrintVisibility));
		}
		z0rek("LinkInfo", string.Empty, p2.z0iek(), p3: false, p4: false);
		if (p2.ContentReadonly != ContentReadonlyState.Inherit)
		{
			z0ZzZzhqh2.z0eek("ContentReadonly", null, z0rek(p2.ContentReadonly));
		}
		if (!p2.Deleteable)
		{
			z0rek("Deleteable", p2.Deleteable);
		}
		z0tek("Name", p2.Name);
		if (!p2.Enabled)
		{
			z0rek("Enabled", p2.Enabled);
		}
		z0tek("StringTag", p2.StringTag);
		z0tek("Text", p2.Text);
		MedicalExpressionValueList values = p2.Values;
		if (values != null && values.Count > 0)
		{
			int count = values.Count;
			z0ZzZzhqh2.z0hf(null, "Values", null);
			for (int i = 0; i < count; i++)
			{
				z0rek("Value", string.Empty, values[i], p3: true, p4: false);
			}
			z0ZzZzhqh2.z0bg();
		}
		if (p2.VAlign != VerticalAlignStyle.Middle)
		{
			z0ZzZzhqh2.z0eek("VAlign", null, z0rek(p2.VAlign));
		}
		z0rek("Width", p2.Width);
		z0rek("Height", p2.Height);
		if (p2.ExpressionStyle != DCMedicalExpressionStyle.FourValues)
		{
			z0ZzZzhqh2.z0eek("ExpressionStyle", null, z0rek(p2.ExpressionStyle));
		}
		if (p2.AutoSize)
		{
			z0rek("AutoSize", p2.AutoSize);
		}
		base.z0rek((object?)p2);
	}

	protected internal void z0rek(string p0, string p1, XTextHorizontalLineElement p2, bool p3, bool p4)
	{
		z0iek = z0eek();
		z0ZzZzhqh z0ZzZzhqh2 = z0eek();
		if (p2 != null)
		{
			if (!p4 && !(p2.GetType() == typeof(XTextHorizontalLineElement)))
			{
				throw z0eek(p2);
			}
			z0eek(p0, p1, p2, p3: false, null);
			if (p4)
			{
				z0eek("HorizontalLine");
			}
			if (((XTextElement)p2).z0pek() != -1)
			{
				z0ZzZzhqh2.z0eek("StyleIndex", ((XTextElement)p2).z0pek());
			}
			z0rek(z0ZzZzhqh2, p2.Attributes);
			z0tek("ID", p2.ID);
			z0tek("ToolTip", p2.ToolTip);
			if (p2.OffsetX != 0f)
			{
				z0rek("OffsetX", p2.OffsetX);
			}
			if (p2.OffsetY != 0f)
			{
				z0rek("OffsetY", p2.OffsetY);
			}
			if (p2.ZOrderStyle != ElementZOrderStyle.Normal)
			{
				z0ZzZzhqh2.z0eek("ZOrderStyle", null, z0rek(p2.ZOrderStyle));
			}
			z0rek(z0ZzZzhqh2, p2.PropertyExpressions);
			z0tek("ValueExpression", p2.ValueExpression);
			if (!p2.Visible)
			{
				z0rek("Visible", p2.Visible);
			}
			if (p2.PrintVisibility != ElementVisibility.Visible)
			{
				z0ZzZzhqh2.z0eek("PrintVisibility", null, z0rek(p2.PrintVisibility));
			}
			z0rek("LinkInfo", string.Empty, p2.z0iek(), p3: false, p4: false);
			if (p2.ContentReadonly != ContentReadonlyState.Inherit)
			{
				z0ZzZzhqh2.z0eek("ContentReadonly", null, z0rek(p2.ContentReadonly));
			}
			if (!p2.Deleteable)
			{
				z0rek("Deleteable", p2.Deleteable);
			}
			z0tek("Name", p2.Name);
			if (!p2.Enabled)
			{
				z0rek("Enabled", p2.Enabled);
			}
			z0tek("StringTag", p2.StringTag);
			if (p2.LineLengthInCM != 0f)
			{
				z0rek("LineLengthInCM", p2.LineLengthInCM);
			}
			if (p2.LineStyle != DashStyle.Solid)
			{
				z0ZzZzhqh2.z0eek("LineStyle", null, z0rek(p2.LineStyle));
			}
			if (p2.LineSize != 1f)
			{
				z0rek("LineSize", p2.LineSize);
			}
			if (p2.Height != 20f)
			{
				z0rek("Height", p2.Height);
			}
			base.z0rek((object?)p2);
		}
	}

	private string z0rek(EnableState p0)
	{
		string text = null;
		return p0 switch
		{
			EnableState.Default => "Default", 
			EnableState.Enabled => "Enabled", 
			EnableState.Disabled => "Disabled", 
			_ => throw z0ZzZzwhh.z0rek((long)p0, typeof(EnableState)), 
		};
	}

	private string z0rek(TableSubfieldMode p0)
	{
		string text = null;
		return p0 switch
		{
			TableSubfieldMode.None => "None", 
			TableSubfieldMode.LeftRightAndUpDown => "LeftRightAndUpDown", 
			TableSubfieldMode.UpDownAndLeftRight => "UpDownAndLeftRight", 
			_ => throw z0ZzZzwhh.z0rek((long)p0, typeof(TableSubfieldMode)), 
		};
	}

	private string z0rek(DCTBErroeCorrectionLevelType p0)
	{
		string text = null;
		return p0 switch
		{
			DCTBErroeCorrectionLevelType.L => "L", 
			DCTBErroeCorrectionLevelType.M => "M", 
			DCTBErroeCorrectionLevelType.Q => "Q", 
			DCTBErroeCorrectionLevelType.H => "H", 
			_ => throw z0ZzZzwhh.z0rek((long)p0, typeof(DCTBErroeCorrectionLevelType)), 
		};
	}

	protected internal void z0rek(string p0, string p1, z0ZzZzitk p2, bool p3, bool p4)
	{
		z0iek = z0eek();
		if (p2 != null)
		{
			if (!p4 && !(p2.GetType() == typeof(z0ZzZzitk)))
			{
				throw z0eek(p2);
			}
			z0eek(p0, p1, p2, p3: false, null);
			if (p4)
			{
				z0eek("ChartLabelStyle");
			}
			z0eek("ColorValue", p2.z0pek());
			z0eek("BackColorValue", p2.z0uek());
			z0eek("BorderColorValue", p2.z0tek());
			if (p2.z0yek())
			{
				z0rek("Visible", p2.z0yek());
			}
			z0rek("Font", p2.z0iek());
			base.z0rek((object?)p2);
		}
	}

	protected internal void z0rek(string p0, string p1, XTextSignElement p2, bool p3, bool p4)
	{
		z0iek = z0eek();
		z0ZzZzhqh z0ZzZzhqh2 = z0eek();
		if (p2 != null)
		{
			if (!p4 && !(p2.GetType() == typeof(XTextSignElement)))
			{
				throw z0eek(p2);
			}
			z0eek(p0, p1, p2, p3: false, null);
			if (p4)
			{
				z0eek("XTextLock");
			}
			if (p2.z0pek() != -1)
			{
				z0ZzZzhqh2.z0eek("StyleIndex", p2.z0pek());
			}
			z0rek(z0ZzZzhqh2, p2.Attributes);
			z0tek("ID", p2.ID);
			base.z0rek((object?)p2);
		}
	}

	protected internal void z0rek(string p0, string p1, XTextDocumentFooterElement p2, bool p3, bool p4)
	{
		z0iek = z0eek();
		z0ZzZzhqh z0ZzZzhqh2 = z0eek();
		if (p2 != null)
		{
			if (!p4 && !(p2.GetType() == typeof(XTextDocumentFooterElement)))
			{
				throw z0eek(p2);
			}
			z0eek(p0, p1, p2, p3: false, null);
			if (p4)
			{
				z0eek("XTextFooter");
			}
			if (p2.z0rek() != -1)
			{
				z0ZzZzhqh2.z0eek("StyleIndex", p2.z0rek());
			}
			z0rek(z0ZzZzhqh2, p2.Attributes);
			z0tek("ID", p2.ID);
			z0tek("LimitedInputChars", p2.LimitedInputChars);
			if (p2.HiddenPrintWhenEmpty)
			{
				z0rek("HiddenPrintWhenEmpty", p2.HiddenPrintWhenEmpty);
			}
			if (p2.MaxInputLength != 0)
			{
				z0rek("MaxInputLength", p2.MaxInputLength);
			}
			z0tek("DataName", p2.z0ht());
			if (p2.z0gt())
			{
				z0rek("CanBeReferenced", p2.z0gt());
			}
			if (p2.z0dt())
			{
				z0rek("BringoutToSave", p2.z0dt());
			}
			z0tek("ToolTip", p2.ToolTip);
			if (p2.AcceptTab)
			{
				z0rek("AcceptTab", p2.AcceptTab);
			}
			z0rek(z0ZzZzhqh2, p2.PropertyExpressions);
			if (p2.EnableValueValidate)
			{
				z0rek("EnableValueValidate", p2.EnableValueValidate);
			}
			z0rek("ValidateStyle", string.Empty, p2.ValidateStyle, p3: false, p4: false);
			z0rek("ValueBinding", string.Empty, p2.ValueBinding, p3: false, p4: false);
			z0tek("DefaultValueForValueBinding", ((XTextContainerElement)p2).z0nrk());
			z0tek("ContentReadonlyExpression", p2.ContentReadonlyExpression);
			z0tek("VisibleExpression", p2.VisibleExpression);
			z0tek("PrintVisibilityExpression", p2.PrintVisibilityExpression);
			z0tek("ValueExpression", p2.ValueExpression);
			if (p2.EnablePermission != DCBooleanValue.Inherit)
			{
				z0ZzZzhqh2.z0eek("EnablePermission", null, z0rek(p2.EnablePermission));
			}
			z0rek("ContentLock", string.Empty, p2.ContentLock, p3: false, p4: false);
			if (p2.ContentReadonly != ContentReadonlyState.Inherit)
			{
				z0ZzZzhqh2.z0eek("ContentReadonly", null, z0rek(p2.ContentReadonly));
			}
			z0rek("CopySource", string.Empty, p2.CopySource, p3: false, p4: false);
			z0rek(p2);
			if (p2.AcceptChildElementTypes2 != ElementType.All)
			{
				z0rek("AcceptChildElementTypes2", string.Empty, z0rek(p2.AcceptChildElementTypes2));
			}
			if (p2.PrintVisibility != ElementVisibility.Visible)
			{
				z0ZzZzhqh2.z0eek("PrintVisibility", null, z0rek(p2.PrintVisibility));
			}
			if (!p2.Visible)
			{
				z0rek("Visible", p2.Visible);
			}
			if (!p2.Deleteable)
			{
				z0rek("Deleteable", p2.Deleteable);
			}
			z0rek("GridLine", string.Empty, p2.GridLine, p3: false, p4: false);
			if (p2.SpecifyFixedLineHeight != 0f)
			{
				z0rek("SpecifyFixedLineHeight", p2.SpecifyFixedLineHeight);
			}
			base.z0rek((object?)p2);
		}
	}

	private string z0rek(z0ZzZzjvj p0)
	{
		string text = null;
		return p0 switch
		{
			(z0ZzZzjvj)0 => "Text", 
			(z0ZzZzjvj)1 => "Boolean", 
			(z0ZzZzjvj)2 => "Numeric", 
			(z0ZzZzjvj)3 => "Date", 
			(z0ZzZzjvj)4 => "Time", 
			(z0ZzZzjvj)5 => "DateTime", 
			(z0ZzZzjvj)6 => "Binary", 
			(z0ZzZzjvj)7 => "Object", 
			_ => throw z0ZzZzwhh.z0rek((long)p0, typeof(z0ZzZzjvj)), 
		};
	}

	private static void z0rek(z0ZzZzhqh p0, XAttributeList p1)
	{
		if (p1 != null && p1.Count > 0)
		{
			int count = p1.Count;
			p0.z0hf(null, "Attributes", null);
			for (int i = 0; i < count; i++)
			{
				XAttribute xAttribute = p1[i];
				p0.z0hf(null, "Attribute", null);
				((z0ZzZzdqh)p0).z0eek("Name", xAttribute.Name);
				((z0ZzZzdqh)p0).z0eek("Value", xAttribute.Value);
				p0.z0bg();
			}
			p0.z0bg();
		}
	}

	private void z0tek(string p0, string p1)
	{
		if (p1 != null && p1.Length > 0)
		{
			z0iek.z0eek(p0, null, p1);
		}
	}

	protected internal void z0rek(string p0, string p1, XTextDocument p2, bool p3, bool p4)
	{
		z0iek = z0eek();
		z0ZzZzhqh z0ZzZzhqh2 = z0eek();
		if (p2 == null)
		{
			return;
		}
		if (!p4 && !(p2.GetType() == typeof(XTextDocument)))
		{
			throw z0eek(p2);
		}
		z0eek(p0, p1, p2, p3: false, null);
		if (p4)
		{
			z0eek("XTextDocument");
		}
		if (p2.z0otk() != -1)
		{
			z0ZzZzhqh2.z0eek("StyleIndex", p2.z0otk());
		}
		z0eek("EditorVersionString", p2.z0mmk());
		z0rek(z0ZzZzhqh2, p2.Attributes);
		z0tek("ID", p2.ID);
		z0tek("LimitedInputChars", p2.LimitedInputChars);
		if (p2.HiddenPrintWhenEmpty)
		{
			z0rek("HiddenPrintWhenEmpty", p2.HiddenPrintWhenEmpty);
		}
		if (p2.MaxInputLength != 0)
		{
			z0rek("MaxInputLength", p2.MaxInputLength);
		}
		z0tek("DataName", p2.z0ht());
		if (p2.z0gt())
		{
			z0rek("CanBeReferenced", p2.z0gt());
		}
		if (p2.z0dt())
		{
			z0rek("BringoutToSave", p2.z0dt());
		}
		z0tek("ToolTip", p2.ToolTip);
		if (p2.AcceptTab)
		{
			z0rek("AcceptTab", p2.AcceptTab);
		}
		z0rek(z0ZzZzhqh2, p2.PropertyExpressions);
		if (p2.EnableValueValidate)
		{
			z0rek("EnableValueValidate", p2.EnableValueValidate);
		}
		z0rek("ValidateStyle", string.Empty, p2.ValidateStyle, p3: false, p4: false);
		z0rek("ValueBinding", string.Empty, p2.ValueBinding, p3: false, p4: false);
		z0tek("DefaultValueForValueBinding", ((XTextContainerElement)p2).z0nrk());
		z0tek("ContentReadonlyExpression", p2.ContentReadonlyExpression);
		z0tek("VisibleExpression", p2.VisibleExpression);
		z0tek("PrintVisibilityExpression", p2.PrintVisibilityExpression);
		z0tek("ValueExpression", p2.ValueExpression);
		if (p2.EnablePermission != DCBooleanValue.Inherit)
		{
			z0ZzZzhqh2.z0eek("EnablePermission", null, z0rek(p2.EnablePermission));
		}
		z0rek("ContentLock", string.Empty, p2.ContentLock, p3: false, p4: false);
		if (p2.ContentReadonly != ContentReadonlyState.Inherit)
		{
			z0ZzZzhqh2.z0eek("ContentReadonly", null, z0rek(p2.ContentReadonly));
		}
		z0rek("CopySource", string.Empty, p2.z0tmk(), p3: false, p4: false);
		z0rek(p2);
		if (p2.AcceptChildElementTypes2 != ElementType.All)
		{
			z0rek("AcceptChildElementTypes2", string.Empty, z0rek(p2.AcceptChildElementTypes2));
		}
		if (p2.PrintVisibility != ElementVisibility.Visible)
		{
			z0ZzZzhqh2.z0eek("PrintVisibility", null, z0rek(p2.PrintVisibility));
		}
		if (!p2.Visible)
		{
			z0rek("Visible", p2.Visible);
		}
		if (!p2.Deleteable)
		{
			z0rek("Deleteable", p2.Deleteable);
		}
		z0tek("LocalExcludeKeywords", p2.z0tuk());
		if (p2.z0ptk())
		{
			z0rek("DetectRepeatImageForSave", p2.z0ptk());
		}
		List<byte[]> list = p2.z0fyk();
		if (list != null && list.Count > 0)
		{
			int count = list.Count;
			z0ZzZzhqh2.z0hf(null, "InnerRepeatImageDataList", null);
			for (int i = 0; i < count; i++)
			{
				z0eek("Item", string.Empty, z0ZzZzkhh.z0eek(list[i]));
			}
			z0ZzZzhqh2.z0bg();
		}
		z0tek("FileName", p2.z0amk());
		z0tek("FileFormat", p2.z0ftk());
		if (p2.z0umk() != 0f)
		{
			z0rek("BodyGridLineOffset", p2.z0umk());
		}
		z0ZzZzuhh z0ZzZzuhh2 = p2.z0syk();
		if (z0ZzZzuhh2 != null && z0ZzZzuhh2.Count > 0)
		{
			int count2 = z0ZzZzuhh2.Count;
			z0ZzZzhqh2.z0hf(null, "UserHistories", null);
			for (int j = 0; j < count2; j++)
			{
				z0rek("History", string.Empty, z0ZzZzuhh2[j], p3: true, p4: false);
			}
			z0ZzZzhqh2.z0bg();
		}
		z0rek("ContentStyles", string.Empty, p2.z0gnk(), p3: false, p4: false);
		RepeatedImageValueList repeatedImageValueList = p2.z0nmk();
		if (repeatedImageValueList != null && repeatedImageValueList.Count > 0)
		{
			int count3 = repeatedImageValueList.Count;
			z0ZzZzhqh2.z0hf(null, "RepeatedImages", null);
			for (int k = 0; k < count3; k++)
			{
				z0rek("Image", string.Empty, repeatedImageValueList[k], p3: true, p4: false);
			}
			z0ZzZzhqh2.z0bg();
		}
		z0tek("SpecialTag", p2.z0tnk());
		if (p2.z0omk() != 0)
		{
			z0rek("DocumentContentVersion", p2.z0omk());
		}
		z0rek("Info", string.Empty, p2.z0ipk(), p3: false, p4: false);
		z0tek("BodyText", p2.z0xuk());
		z0ZzZzwcj comments = p2.Comments;
		if (comments != null && comments.Count > 0)
		{
			int count4 = comments.Count;
			z0ZzZzhqh2.z0hf(null, "Comments", null);
			for (int l = 0; l < count4; l++)
			{
				z0rek("Comment", string.Empty, comments[l], p3: true, p4: false);
			}
			z0ZzZzhqh2.z0bg();
		}
		if (p2.z0fnk() != MeasureMode.Default)
		{
			z0ZzZzhqh2.z0eek("MeasureMode", null, z0rek(p2.z0fnk()));
		}
		z0rek("PageSettings", string.Empty, p2.PageSettings, p3: false, p4: false);
		base.z0rek((object?)p2);
		if (z0yek.Count <= 0)
		{
			return;
		}
		foreach (zzz.z0ZzZzkuk<char> item in z0yek)
		{
			item.Clear();
		}
		z0yek.Clear();
	}

	private string z0rek(TableRowCloneType p0)
	{
		string text = null;
		return p0 switch
		{
			TableRowCloneType.Default => "Default", 
			TableRowCloneType.ContentWithClearField => "ContentWithClearField", 
			TableRowCloneType.Complete => "Complete", 
			TableRowCloneType.ClearDirectContentAndFieldContent => "ClearDirectContentAndFieldContent", 
			_ => throw z0ZzZzwhh.z0rek((long)p0, typeof(TableRowCloneType)), 
		};
	}

	protected internal void z0rek(string p0, string p1, XTextCheckBoxElement p2, bool p3, bool p4)
	{
		z0iek = z0eek();
		z0ZzZzhqh z0ZzZzhqh2 = z0eek();
		if (p2 == null)
		{
			return;
		}
		if (!p4 && !(p2.GetType() == typeof(XTextCheckBoxElement)))
		{
			throw z0eek(p2);
		}
		z0eek(p0, p1, p2, p3: false, null);
		if (p4)
		{
			z0eek("XTextCheckBox");
		}
		if (((XTextElement)p2).z0pek() != -1)
		{
			z0ZzZzhqh2.z0eek("StyleIndex", ((XTextElement)p2).z0pek());
		}
		z0rek(z0ZzZzhqh2, p2.Attributes);
		z0tek("ID", p2.ID);
		z0tek("ToolTip", p2.ToolTip);
		if (p2.OffsetX != 0f)
		{
			z0rek("OffsetX", p2.OffsetX);
		}
		if (p2.OffsetY != 0f)
		{
			z0rek("OffsetY", p2.OffsetY);
		}
		if (p2.ZOrderStyle != ElementZOrderStyle.Normal)
		{
			z0ZzZzhqh2.z0eek("ZOrderStyle", null, z0rek(p2.ZOrderStyle));
		}
		z0rek(z0ZzZzhqh2, p2.PropertyExpressions);
		z0tek("ValueExpression", p2.ValueExpression);
		if (!p2.Visible)
		{
			z0rek("Visible", p2.Visible);
		}
		if (p2.PrintVisibility != ElementVisibility.Visible)
		{
			z0ZzZzhqh2.z0eek("PrintVisibility", null, z0rek(p2.PrintVisibility));
		}
		z0rek("LinkInfo", string.Empty, ((XTextObjectElement)p2).z0iek(), p3: false, p4: false);
		if (p2.ContentReadonly != ContentReadonlyState.Inherit)
		{
			z0ZzZzhqh2.z0eek("ContentReadonly", null, z0rek(p2.ContentReadonly));
		}
		if (!p2.Deleteable)
		{
			z0rek("Deleteable", p2.Deleteable);
		}
		z0tek("Name", p2.Name);
		if (!p2.Enabled)
		{
			z0rek("Enabled", p2.Enabled);
		}
		z0tek("StringTag", p2.StringTag);
		z0ZzZzuhh checkedUserHistories = p2.CheckedUserHistories;
		if (checkedUserHistories != null && checkedUserHistories.Count > 0)
		{
			int count = checkedUserHistories.Count;
			z0ZzZzhqh2.z0hf(null, "CheckedUserHistories", null);
			for (int i = 0; i < count; i++)
			{
				z0rek("Item", string.Empty, checkedUserHistories[i], p3: true, p4: false);
			}
			z0ZzZzhqh2.z0bg();
		}
		if (p2.Requried)
		{
			z0rek("Requried", p2.Requried);
		}
		z0tek("DataName", p2.DataName);
		if (p2.CanBeReferenced)
		{
			z0rek("CanBeReferenced", p2.CanBeReferenced);
		}
		if (p2.BringoutToSave)
		{
			z0rek("BringoutToSave", p2.BringoutToSave);
		}
		if (p2.CheckboxVisibility != RenderVisibility.All)
		{
			z0rek("CheckboxVisibility", string.Empty, z0rek(p2.CheckboxVisibility));
		}
		if (p2.PrintVisibilityWhenUnchecked != PrintVisibilityModeWhenUnchecked.Visible)
		{
			z0ZzZzhqh2.z0eek("PrintVisibilityWhenUnchecked", null, z0rek(p2.PrintVisibilityWhenUnchecked));
		}
		z0tek("PrintTextForChecked", p2.PrintTextForChecked);
		z0tek("PrintTextForUnChecked", p2.PrintTextForUnChecked);
		if (!p2.CheckAlignLeft)
		{
			z0rek("CheckAlignLeft", p2.CheckAlignLeft);
		}
		z0tek("Caption", p2.Caption);
		if (p2.CaptionFlowLayout)
		{
			z0rek("CaptionFlowLayout", p2.CaptionFlowLayout);
		}
		if (p2.CaptionAlign != StringAlignment.Center)
		{
			z0ZzZzhqh2.z0eek("CaptionAlign", null, z0rek(p2.CaptionAlign));
		}
		z0rek("ValueBinding", string.Empty, p2.ValueBinding, p3: false, p4: false);
		if (p2.AutoHeightForMultiline)
		{
			z0rek("AutoHeightForMultiline", p2.AutoHeightForMultiline);
		}
		z0rek("Width", p2.Width);
		z0rek("Height", p2.Height);
		z0tek("GroupName", p2.GroupName);
		if (p2.z0oi() != CheckBoxControlStyle.CheckBox)
		{
			z0ZzZzhqh2.z0eek("ControlStyle", null, z0rek(p2.z0oi()));
		}
		if (p2.Checked)
		{
			z0rek("Checked", p2.Checked);
		}
		if (p2.DefaultCheckedForValueBinding)
		{
			z0rek("DefaultCheckedForValueBinding", p2.DefaultCheckedForValueBinding);
		}
		z0tek("CheckedValue", p2.CheckedValue);
		if (p2.Readonly)
		{
			z0rek("Readonly", p2.Readonly);
		}
		if (p2.EnableHighlight != EnableState.Enabled)
		{
			z0ZzZzhqh2.z0eek("EnableHighlight", null, z0rek(p2.EnableHighlight));
		}
		z0ZzZzukh z0ZzZzukh2 = p2.z0uek();
		if (z0ZzZzukh2 != null && z0ZzZzukh2.Count > 0)
		{
			int count2 = z0ZzZzukh2.Count;
			z0ZzZzhqh2.z0hf(null, "EventExpressions", null);
			for (int j = 0; j < count2; j++)
			{
				z0rek("Expression", string.Empty, z0ZzZzukh2[j], p3: true, p4: false);
			}
			z0ZzZzhqh2.z0bg();
		}
		if (!p2.CheckBoxVisible)
		{
			z0rek("CheckBoxVisible", p2.CheckBoxVisible);
		}
		if (p2.VisualStyle != CheckBoxVisualStyle.Default)
		{
			z0ZzZzhqh2.z0eek("VisualStyle", null, z0rek(p2.VisualStyle));
		}
		if (p2.Multiline)
		{
			z0rek("Multiline", p2.Multiline);
		}
		base.z0rek((object?)p2);
	}

	protected internal void z0rek(string p0, string p1, DCPieDataItem p2, bool p3, bool p4)
	{
		z0iek = z0eek();
		z0ZzZzhqh z0ZzZzhqh2 = z0eek();
		if (p2 != null)
		{
			if (!p4 && !(p2.GetType() == typeof(DCPieDataItem)))
			{
				throw z0eek(p2);
			}
			z0eek(p0, p1, p2, p3: false, null);
			if (p4)
			{
				z0eek("PieDataItem");
			}
			z0eek("Text", p2.Text);
			z0eek("TipText", p2.TipText);
			z0eek("Link", p2.Link);
			z0eek("ColorValue", p2.ColorValue);
			if (p2.Value != 0.0)
			{
				z0ZzZzhqh2.z0eek("Value", p2.Value);
			}
			base.z0rek((object?)p2);
		}
	}

	protected internal void z0rek(string p0, string p1, z0ZzZzfuj p2, bool p3, bool p4)
	{
		z0iek = z0eek();
		z0ZzZzhqh z0ZzZzhqh2 = z0eek();
		if (p2 != null)
		{
			if (!p4 && !(p2.GetType() == typeof(z0ZzZzfuj)))
			{
				throw z0eek(p2);
			}
			z0eek(p0, p1, p2, p3: false, null);
			if (p4)
			{
				z0eek("ShapeEllipseElement");
			}
			if (((z0ZzZzhuj)p2).z0eek() != -1)
			{
				z0ZzZzhqh2.z0eek("StyleIndex", ((z0ZzZzhuj)p2).z0eek());
			}
			z0rek("LocalStyle", string.Empty, ((z0ZzZzhuj)p2).z0pek(), p3: false, p4: false);
			if (!p2.z0rek_jiejie20260327142557())
			{
				z0rek("Visible", p2.z0rek_jiejie20260327142557());
			}
			z0tek("ID", ((z0ZzZzhuj)p2).z0yek());
			if (p2.z0rek() != 0f)
			{
				z0rek("Left", p2.z0rek());
			}
			if (p2.z0oek() != 0f)
			{
				z0rek("Top", p2.z0oek());
			}
			if (p2.z0mek() != 100f)
			{
				z0rek("Width", p2.z0mek());
			}
			if (p2.z0eek() != 100f)
			{
				z0rek("Height", p2.z0eek());
			}
			if (!p2.z0xkk())
			{
				z0rek("Resizeable", p2.z0xkk());
			}
			z0tek("Text", p2.z0pek());
			base.z0rek((object?)p2);
		}
	}

	protected internal void z0rek(string p0, string p1, XTextTableRowElement p2, bool p3, bool p4)
	{
		z0iek = z0eek();
		z0ZzZzhqh z0ZzZzhqh2 = z0eek();
		if (p2 != null)
		{
			if (!p4 && !(p2.GetType() == typeof(XTextTableRowElement)))
			{
				throw z0eek(p2);
			}
			z0eek(p0, p1, p2, p3: false, null);
			if (p4)
			{
				z0eek("XTextTableRow");
			}
			if (((XTextElement)p2).z0pek() != -1)
			{
				z0ZzZzhqh2.z0eek("StyleIndex", ((XTextElement)p2).z0pek());
			}
			z0rek(z0ZzZzhqh2, p2.Attributes);
			z0tek("ID", p2.ID);
			z0tek("LimitedInputChars", p2.LimitedInputChars);
			if (p2.HiddenPrintWhenEmpty)
			{
				z0rek("HiddenPrintWhenEmpty", p2.HiddenPrintWhenEmpty);
			}
			if (p2.MaxInputLength != 0)
			{
				z0rek("MaxInputLength", p2.MaxInputLength);
			}
			z0tek("DataName", p2.z0ht());
			if (p2.z0gt())
			{
				z0rek("CanBeReferenced", p2.z0gt());
			}
			if (p2.z0dt())
			{
				z0rek("BringoutToSave", p2.z0dt());
			}
			z0tek("ToolTip", p2.ToolTip);
			if (p2.AcceptTab)
			{
				z0rek("AcceptTab", p2.AcceptTab);
			}
			z0rek(z0ZzZzhqh2, p2.PropertyExpressions);
			if (p2.EnableValueValidate)
			{
				z0rek("EnableValueValidate", p2.EnableValueValidate);
			}
			z0rek("ValidateStyle", string.Empty, p2.ValidateStyle, p3: false, p4: false);
			z0rek("ValueBinding", string.Empty, p2.ValueBinding, p3: false, p4: false);
			z0tek("DefaultValueForValueBinding", p2.z0nrk());
			z0tek("ContentReadonlyExpression", p2.ContentReadonlyExpression);
			z0tek("VisibleExpression", p2.VisibleExpression);
			z0tek("PrintVisibilityExpression", p2.PrintVisibilityExpression);
			z0tek("ValueExpression", p2.ValueExpression);
			if (p2.EnablePermission != DCBooleanValue.Inherit)
			{
				z0ZzZzhqh2.z0eek("EnablePermission", null, z0rek(p2.EnablePermission));
			}
			z0rek("ContentLock", string.Empty, p2.ContentLock, p3: false, p4: false);
			if (p2.ContentReadonly != ContentReadonlyState.Inherit)
			{
				z0ZzZzhqh2.z0eek("ContentReadonly", null, z0rek(p2.ContentReadonly));
			}
			z0rek("CopySource", string.Empty, p2.CopySource, p3: false, p4: false);
			z0rek(p2);
			if (p2.PrintVisibility != ElementVisibility.Visible)
			{
				z0ZzZzhqh2.z0eek("PrintVisibility", null, z0rek(p2.PrintVisibility));
			}
			if (!p2.Visible)
			{
				z0rek("Visible", p2.Visible);
			}
			if (!p2.Deleteable)
			{
				z0rek("Deleteable", p2.Deleteable);
			}
			z0tek("GroupName", p2.z0lrk());
			if (p2.z0uek() != 1)
			{
				z0rek("DataSourceRowSpan", p2.z0uek());
			}
			if (p2.z0jrk() != 1)
			{
				z0rek("CloneMultipleBaseForBindingDataSource", p2.z0jrk());
			}
			if (p2.z0yek())
			{
				z0rek("GenerateByValueBingding", p2.z0yek());
			}
			if (p2.NewPage)
			{
				z0rek("NewPage", p2.NewPage);
			}
			if (!p2.PrintCellBorder)
			{
				z0rek("PrintCellBorder", p2.PrintCellBorder);
			}
			if (!p2.PrintCellBackground)
			{
				z0rek("PrintCellBackground", p2.PrintCellBackground);
			}
			if (p2.AllowInsertRowDownUseHotKey != DCInsertRowDownUseHotKeys.EnableOnlyForLastRow)
			{
				z0ZzZzhqh2.z0eek("AllowInsertRowDownUseHotKey", null, z0rek(p2.AllowInsertRowDownUseHotKey));
			}
			if (p2.z0bek())
			{
				z0rek("AllowUserPressTabKeyToInsertRowDown", p2.z0bek());
			}
			if (p2.AllowUserToResizeHeight != DCBooleanValue.Inherit)
			{
				z0ZzZzhqh2.z0eek("AllowUserToResizeHeight", null, z0rek(p2.AllowUserToResizeHeight));
			}
			if (!p2.CanSplitByPageLine)
			{
				z0rek("CanSplitByPageLine", p2.CanSplitByPageLine);
			}
			if (!p2.ExpendForDataBinding)
			{
				z0rek("ExpendForDataBinding", p2.ExpendForDataBinding);
			}
			if (p2.SpecifyHeight != 0f)
			{
				z0rek("SpecifyHeight", p2.SpecifyHeight);
			}
			if (p2.HeaderStyle)
			{
				z0rek("HeaderStyle", p2.HeaderStyle);
			}
			if (p2.CloneType != TableRowCloneType.Default)
			{
				z0ZzZzhqh2.z0eek("CloneType", null, z0rek(p2.CloneType));
			}
			base.z0rek((object?)p2);
		}
	}

	protected internal void z0rek(string p0, z0ZzZzimk p1)
	{
		z0iek = z0eek();
		z0ZzZzhqh z0ZzZzhqh2 = z0eek();
		if (p1 != null)
		{
			z0eek(p0, null, p1, p3: false);
			if (p1.Name != "宋体")
			{
				z0tek("Name", p1.Name);
			}
			if (p1.Size != 9f)
			{
				z0rek("Size", p1.Size);
			}
			if (p1.Unit != GraphicsUnit.Point)
			{
				z0ZzZzhqh2.z0eek("Unit", null, z0rek(p1.Unit));
			}
			if (p1.Bold)
			{
				z0rek("Bold", p1.Bold);
			}
			if (p1.Italic)
			{
				z0rek("Italic", p1.Italic);
			}
			if (p1.Underline)
			{
				z0rek("Underline", p1.Underline);
			}
			if (p1.Strikeout)
			{
				z0rek("Strikeout", p1.Strikeout);
			}
			base.z0rek((object?)p1);
		}
	}

	protected internal void z0rek(string p0, string p1, z0ZzZzquj p2, bool p3, bool p4)
	{
		z0iek = z0eek();
		z0ZzZzhqh z0ZzZzhqh2 = z0eek();
		if (p2 != null)
		{
			if (!p4 && !(p2.GetType() == typeof(z0ZzZzquj)))
			{
				throw z0eek(p2);
			}
			z0eek(p0, p1, p2, p3: false, null);
			if (p4)
			{
				z0eek("ShapeLinesElement");
			}
			if (((z0ZzZzhuj)p2).z0eek() != -1)
			{
				z0ZzZzhqh2.z0eek("StyleIndex", ((z0ZzZzhuj)p2).z0eek());
			}
			z0rek("LocalStyle", string.Empty, p2.z0pek(), p3: false, p4: false);
			if (!p2.z0rek_jiejie20260327142557())
			{
				z0rek("Visible", p2.z0rek_jiejie20260327142557());
			}
			z0tek("ID", ((z0ZzZzhuj)p2).z0yek());
			z0tek("Points", p2.z0rek());
			base.z0rek((object?)p2);
		}
	}

	private string z0rek(MeasureMode p0)
	{
		string text = null;
		return p0 switch
		{
			MeasureMode.Default => "Default", 
			MeasureMode.RichTextBoxCompatibility => "RichTextBoxCompatibility", 
			MeasureMode.OldCompatibility => "OldCompatibility", 
			_ => throw z0ZzZzwhh.z0rek((long)p0, typeof(MeasureMode)), 
		};
	}

	private string z0rek(DCContentAlignment p0)
	{
		string text = null;
		return p0 switch
		{
			DCContentAlignment.TopLeft => "TopLeft", 
			DCContentAlignment.TopCenter => "TopCenter", 
			DCContentAlignment.TopRight => "TopRight", 
			DCContentAlignment.MiddleLeft => "MiddleLeft", 
			DCContentAlignment.MiddleCenter => "MiddleCenter", 
			DCContentAlignment.MiddleRight => "MiddleRight", 
			DCContentAlignment.BottomLeft => "BottomLeft", 
			DCContentAlignment.BottomCenter => "BottomCenter", 
			DCContentAlignment.BottomRight => "BottomRight", 
			_ => throw z0ZzZzwhh.z0rek((long)p0, typeof(DCContentAlignment)), 
		};
	}

	private string z0rek(ValueTypeStyle p0)
	{
		string text = null;
		return p0 switch
		{
			ValueTypeStyle.Text => "Text", 
			ValueTypeStyle.Integer => "Integer", 
			ValueTypeStyle.Numeric => "Numeric", 
			ValueTypeStyle.Date => "Date", 
			ValueTypeStyle.Time => "Time", 
			ValueTypeStyle.DateTime => "DateTime", 
			ValueTypeStyle.RegExpress => "RegExpress", 
			_ => throw z0ZzZzwhh.z0rek((long)p0, typeof(ValueTypeStyle)), 
		};
	}

	protected internal void z0rek(string p0, string p1, z0ZzZzxyj p2, bool p3, bool p4)
	{
		z0iek = z0eek();
		z0ZzZzhqh z0ZzZzhqh2 = z0eek();
		if (p2 == null)
		{
			return;
		}
		if (!p4)
		{
			Type type = p2.GetType();
			if (!(type == typeof(z0ZzZzxyj)))
			{
				if (type == typeof(z0ZzZzjuj))
				{
					z0rek(p0, p1, (z0ZzZzjuj)p2, p3, p4: true);
					return;
				}
				if (type == typeof(z0ZzZzkuj))
				{
					z0rek(p0, p1, (z0ZzZzkuj)p2, p3, p4: true);
					return;
				}
				if (type == typeof(z0ZzZzluj))
				{
					z0rek(p0, p1, (z0ZzZzluj)p2, p3, p4: true);
					return;
				}
				throw z0eek(p2);
			}
		}
		z0eek(p0, p1, p2, p3: false, null);
		if (p4)
		{
			z0eek("ShapeContainerElement");
		}
		if (((z0ZzZzhuj)p2).z0eek() != -1)
		{
			z0ZzZzhqh2.z0eek("StyleIndex", ((z0ZzZzhuj)p2).z0eek());
		}
		z0rek("LocalStyle", string.Empty, ((z0ZzZzhuj)p2).z0pek(), p3: false, p4: false);
		if (!p2.z0rek_jiejie20260327142557())
		{
			z0rek("Visible", p2.z0rek_jiejie20260327142557());
		}
		z0tek("ID", ((z0ZzZzhuj)p2).z0yek());
		if (p2.z0rek() != 0f)
		{
			z0rek("Left", p2.z0rek());
		}
		if (p2.z0oek() != 0f)
		{
			z0rek("Top", p2.z0oek());
		}
		if (p2.z0mek() != 100f)
		{
			z0rek("Width", p2.z0mek());
		}
		if (((z0ZzZzeuj)p2).z0eek() != 100f)
		{
			z0rek("Height", ((z0ZzZzeuj)p2).z0eek());
		}
		if (!p2.z0xkk())
		{
			z0rek("Resizeable", p2.z0xkk());
		}
		z0tek("Text", p2.z0pek());
		z0ZzZzguj z0ZzZzguj2 = p2.z0djk();
		if (z0ZzZzguj2 != null && z0ZzZzguj2.Count > 0)
		{
			int count = z0ZzZzguj2.Count;
			z0ZzZzhqh2.z0hf(null, "Elements", null);
			for (int i = 0; i < count; i++)
			{
				z0rek("ShapeElement", string.Empty, z0ZzZzguj2[i], p3: true, p4: false);
			}
			z0ZzZzhqh2.z0bg();
		}
		base.z0rek((object?)p2);
	}

	protected internal void z0rek(string p0, string p1, XTextMedicalExpressionFieldElement p2, bool p3, bool p4)
	{
		z0iek = z0eek();
		z0ZzZzhqh z0ZzZzhqh2 = z0eek();
		if (p2 == null)
		{
			return;
		}
		if (!p4 && !(p2.GetType() == typeof(XTextMedicalExpressionFieldElement)))
		{
			throw z0eek(p2);
		}
		z0eek(p0, p1, p2, p3: false, null);
		if (p4)
		{
			z0eek("XMedicalExpressionField");
		}
		if (((XTextElement)p2).z0pek() != -1)
		{
			z0ZzZzhqh2.z0eek("StyleIndex", ((XTextElement)p2).z0pek());
		}
		z0rek(z0ZzZzhqh2, p2.Attributes);
		z0tek("ID", p2.ID);
		z0tek("LimitedInputChars", p2.LimitedInputChars);
		if (p2.HiddenPrintWhenEmpty)
		{
			z0rek("HiddenPrintWhenEmpty", p2.HiddenPrintWhenEmpty);
		}
		if (p2.MaxInputLength != 0)
		{
			z0rek("MaxInputLength", p2.MaxInputLength);
		}
		z0tek("DataName", p2.z0ht());
		if (p2.z0gt())
		{
			z0rek("CanBeReferenced", p2.z0gt());
		}
		if (p2.z0dt())
		{
			z0rek("BringoutToSave", p2.z0dt());
		}
		z0tek("ToolTip", p2.ToolTip);
		if (p2.AcceptTab)
		{
			z0rek("AcceptTab", p2.AcceptTab);
		}
		z0rek(z0ZzZzhqh2, p2.PropertyExpressions);
		if (p2.EnableValueValidate)
		{
			z0rek("EnableValueValidate", p2.EnableValueValidate);
		}
		z0rek("ValidateStyle", string.Empty, p2.ValidateStyle, p3: false, p4: false);
		z0rek("ValueBinding", string.Empty, p2.ValueBinding, p3: false, p4: false);
		z0tek("DefaultValueForValueBinding", p2.z0nrk());
		z0tek("ContentReadonlyExpression", p2.ContentReadonlyExpression);
		z0tek("VisibleExpression", p2.VisibleExpression);
		z0tek("PrintVisibilityExpression", p2.PrintVisibilityExpression);
		z0tek("ValueExpression", p2.ValueExpression);
		if (p2.EnablePermission != DCBooleanValue.Inherit)
		{
			z0ZzZzhqh2.z0eek("EnablePermission", null, z0rek(p2.EnablePermission));
		}
		z0rek("ContentLock", string.Empty, p2.ContentLock, p3: false, p4: false);
		if (p2.ContentReadonly != ContentReadonlyState.Inherit)
		{
			z0ZzZzhqh2.z0eek("ContentReadonly", null, z0rek(p2.ContentReadonly));
		}
		z0rek("CopySource", string.Empty, p2.CopySource, p3: false, p4: false);
		z0rek(p2);
		if (p2.AcceptChildElementTypes2 != ElementType.All)
		{
			z0rek("AcceptChildElementTypes2", string.Empty, z0rek(p2.AcceptChildElementTypes2));
		}
		if (p2.PrintVisibility != ElementVisibility.Visible)
		{
			z0ZzZzhqh2.z0eek("PrintVisibility", null, z0rek(p2.PrintVisibility));
		}
		if (!p2.Visible)
		{
			z0rek("Visible", p2.Visible);
		}
		if (!p2.Deleteable)
		{
			z0rek("Deleteable", p2.Deleteable);
		}
		if (p2.EndingLineBreak)
		{
			z0rek("EndingLineBreak", p2.EndingLineBreak);
		}
		z0tek("StartBorderText", p2.StartBorderText);
		z0tek("EndBorderText", p2.EndBorderText);
		z0rek("BorderElementColor", p2.BorderElementColor);
		z0tek("BorderElementColorValue", p2.BorderElementColorValue);
		z0tek("TextColor", p2.TextColorString);
		if (((XTextFieldElementBase)p2).z0drk() != DCBooleanValueHasDefault.Default)
		{
			z0ZzZzhqh2.z0eek("BackgroundTextItalic", null, z0rek(((XTextFieldElementBase)p2).z0drk()));
		}
		if (p2.LableUnitTextBold != DCBooleanValueHasDefault.Default)
		{
			z0ZzZzhqh2.z0eek("LableUnitTextBold", null, z0rek(p2.LableUnitTextBold));
		}
		z0tek("BackgroundTextColor", p2.BackgroundTextColorString);
		if (p2.z0oek() != (z0ZzZzscj)1)
		{
			z0ZzZzhqh2.z0eek("BorderTextPosition", null, z0rek(p2.z0oek()));
		}
		if (((XTextInputFieldElementBase)p2).z0rek() != DCFastInputMode.NextField)
		{
			z0ZzZzhqh2.z0eek("FastInputMode", null, z0rek(((XTextInputFieldElementBase)p2).z0rek()));
		}
		if (!p2.TabStop)
		{
			z0rek("TabStop", p2.TabStop);
		}
		if (p2.MoveFocusHotKey != MoveFocusHotKeys.Default)
		{
			z0rek("MoveFocusHotKey", string.Empty, z0rek(p2.MoveFocusHotKey));
		}
		if (p2.TabIndex != 0)
		{
			z0rek("TabIndex", p2.TabIndex);
		}
		if (p2.SpecifyWidth != 0f)
		{
			z0rek("SpecifyWidth", p2.SpecifyWidth);
		}
		if (p2.Alignment != StringAlignment.Near)
		{
			z0ZzZzhqh2.z0eek("Alignment", null, z0rek(p2.Alignment));
		}
		if (p2.z0pek())
		{
			z0rek("AutoFixFontSize", p2.z0pek());
		}
		z0tek("DefaultEventExpression", p2.DefaultEventExpression);
		z0ZzZzukh eventExpressions = p2.EventExpressions;
		if (eventExpressions != null && eventExpressions.Count > 0)
		{
			int count = eventExpressions.Count;
			z0ZzZzhqh2.z0hf(null, "EventExpressions", null);
			for (int i = 0; i < count; i++)
			{
				z0rek("Expression", string.Empty, eventExpressions[i], p3: true, p4: false);
			}
			z0ZzZzhqh2.z0bg();
		}
		z0tek("UnitText", p2.UnitText);
		z0tek("LabelText", p2.LabelText);
		if (!p2.UserEditable)
		{
			z0rek("UserEditable", p2.UserEditable);
		}
		z0tek("Name", p2.Name);
		z0rek("DisplayFormat", string.Empty, p2.DisplayFormat, p3: false, p4: false);
		z0tek("InnerValue", p2.InnerValue);
		if (p2.z0cek() != DCBooleanValue.Inherit)
		{
			z0ZzZzhqh2.z0eek("PrintBackgroundText", null, z0rek(p2.z0cek()));
		}
		z0tek("BackgroundText", p2.BackgroundText);
		if (p2.ViewEncryptType != ContentViewEncryptType.None)
		{
			z0ZzZzhqh2.z0eek("ViewEncryptType", null, z0rek(p2.ViewEncryptType));
		}
		if (p2.BorderVisible != DCVisibleState.Default)
		{
			z0ZzZzhqh2.z0eek("BorderVisible", null, z0rek(p2.BorderVisible));
		}
		if (p2.EnableHighlight != EnableState.Enabled)
		{
			z0ZzZzhqh2.z0eek("EnableHighlight", null, z0rek(p2.EnableHighlight));
		}
		if (!p2.AutoExitEditMode)
		{
			z0rek("AutoExitEditMode", p2.AutoExitEditMode);
		}
		if (!p2.Enabled)
		{
			z0rek("Enabled", p2.Enabled);
		}
		if (p2.VAlign != VerticalAlignStyle.Middle)
		{
			z0ZzZzhqh2.z0eek("VAlign", null, z0rek(p2.VAlign));
		}
		if (!p2.EditValueInDialog)
		{
			z0rek("EditValueInDialog", p2.EditValueInDialog);
		}
		z0rek("Width", p2.Width);
		z0rek("Height", p2.Height);
		base.z0rek((object?)p2);
	}

	protected internal void z0rek(string p0, string p1, DocumentContentStyleContainer p2, bool p3, bool p4)
	{
		z0iek = z0eek();
		z0ZzZzhqh z0ZzZzhqh2 = z0eek();
		if (p2 == null)
		{
			return;
		}
		if (!p4 && !(p2.GetType() == typeof(DocumentContentStyleContainer)))
		{
			throw z0eek(p2);
		}
		z0eek(p0, p1, p2, p3: false, null);
		if (p4)
		{
			z0eek("DocumentContentStyleContainer");
		}
		z0rek("Default", string.Empty, p2.Default, p3: false, p4: false);
		z0ZzZzzok styles = p2.Styles;
		if (styles != null && styles.Count > 0)
		{
			int count = styles.Count;
			z0ZzZzhqh2.z0hf(null, "Styles", null);
			for (int i = 0; i < count; i++)
			{
				z0rek("Style", string.Empty, (DocumentContentStyle)styles[i], p3: true, p4: false);
			}
			z0ZzZzhqh2.z0bg();
		}
		base.z0rek((object?)p2);
	}

	protected internal void z0rek(string p0, string p1, RepeatedImageValue p2, bool p3, bool p4)
	{
		z0iek = z0eek();
		z0ZzZzhqh z0ZzZzhqh2 = z0eek();
		if (p2 != null)
		{
			if (!p4 && !(p2.GetType() == typeof(RepeatedImageValue)))
			{
				throw z0eek(p2);
			}
			z0eek(p0, p1, p2, p3: false, null);
			if (p4)
			{
				z0eek("RepeatedImageValue");
			}
			if (p2.ReferenceCount != 0)
			{
				z0ZzZzhqh2.z0eek("ReferenceCount", p2.ReferenceCount);
			}
			if (p2.ValueIndex != 0)
			{
				z0ZzZzhqh2.z0eek("ValueIndex", p2.ValueIndex);
			}
			z0tek("ImageDataBase64String", p2.ImageDataBase64String);
			base.z0rek((object?)p2);
		}
	}

	private string z0rek(ValueFormatStyle p0)
	{
		string text = null;
		return p0 switch
		{
			ValueFormatStyle.None => "None", 
			ValueFormatStyle.Numeric => "Numeric", 
			ValueFormatStyle.Currency => "Currency", 
			ValueFormatStyle.DateTime => "DateTime", 
			ValueFormatStyle.String => "String", 
			ValueFormatStyle.SpecifyLength => "SpecifyLength", 
			ValueFormatStyle.Boolean => "Boolean", 
			ValueFormatStyle.Percent => "Percent", 
			_ => throw z0ZzZzwhh.z0rek((long)p0, typeof(ValueFormatStyle)), 
		};
	}

	public new void z0rek(object p0)
	{
		z0iek = z0eek();
		z0rek();
		if (p0 == null)
		{
			base.z0rek("XTextDocument", string.Empty);
			return;
		}
		z0tek();
		z0rek("XTextDocument", string.Empty, (XTextDocument)p0, p3: true, p4: false);
	}

	protected internal void z0rek(string p0, string p1, XTextDocumentHeaderForFirstPageElement p2, bool p3, bool p4)
	{
		z0iek = z0eek();
		z0ZzZzhqh z0ZzZzhqh2 = z0eek();
		if (p2 != null)
		{
			if (!p4 && !(p2.GetType() == typeof(XTextDocumentHeaderForFirstPageElement)))
			{
				throw z0eek(p2);
			}
			z0eek(p0, p1, p2, p3: false, null);
			if (p4)
			{
				z0eek("XTextHeaderForFirstPage");
			}
			if (p2.z0rek() != -1)
			{
				z0ZzZzhqh2.z0eek("StyleIndex", p2.z0rek());
			}
			z0rek(z0ZzZzhqh2, p2.Attributes);
			z0tek("ID", p2.ID);
			z0tek("LimitedInputChars", p2.LimitedInputChars);
			if (p2.HiddenPrintWhenEmpty)
			{
				z0rek("HiddenPrintWhenEmpty", p2.HiddenPrintWhenEmpty);
			}
			if (p2.MaxInputLength != 0)
			{
				z0rek("MaxInputLength", p2.MaxInputLength);
			}
			z0tek("DataName", p2.z0ht());
			if (p2.z0gt())
			{
				z0rek("CanBeReferenced", p2.z0gt());
			}
			if (p2.z0dt())
			{
				z0rek("BringoutToSave", p2.z0dt());
			}
			z0tek("ToolTip", p2.ToolTip);
			if (p2.AcceptTab)
			{
				z0rek("AcceptTab", p2.AcceptTab);
			}
			z0rek(z0ZzZzhqh2, p2.PropertyExpressions);
			if (p2.EnableValueValidate)
			{
				z0rek("EnableValueValidate", p2.EnableValueValidate);
			}
			z0rek("ValidateStyle", string.Empty, p2.ValidateStyle, p3: false, p4: false);
			z0rek("ValueBinding", string.Empty, p2.ValueBinding, p3: false, p4: false);
			z0tek("DefaultValueForValueBinding", ((XTextContainerElement)p2).z0nrk());
			z0tek("ContentReadonlyExpression", p2.ContentReadonlyExpression);
			z0tek("VisibleExpression", p2.VisibleExpression);
			z0tek("PrintVisibilityExpression", p2.PrintVisibilityExpression);
			z0tek("ValueExpression", p2.ValueExpression);
			if (p2.EnablePermission != DCBooleanValue.Inherit)
			{
				z0ZzZzhqh2.z0eek("EnablePermission", null, z0rek(p2.EnablePermission));
			}
			z0rek("ContentLock", string.Empty, p2.ContentLock, p3: false, p4: false);
			if (p2.ContentReadonly != ContentReadonlyState.Inherit)
			{
				z0ZzZzhqh2.z0eek("ContentReadonly", null, z0rek(p2.ContentReadonly));
			}
			z0rek("CopySource", string.Empty, p2.CopySource, p3: false, p4: false);
			z0rek(p2);
			if (p2.AcceptChildElementTypes2 != ElementType.All)
			{
				z0rek("AcceptChildElementTypes2", string.Empty, z0rek(p2.AcceptChildElementTypes2));
			}
			if (p2.PrintVisibility != ElementVisibility.Visible)
			{
				z0ZzZzhqh2.z0eek("PrintVisibility", null, z0rek(p2.PrintVisibility));
			}
			if (!p2.Visible)
			{
				z0rek("Visible", p2.Visible);
			}
			if (!p2.Deleteable)
			{
				z0rek("Deleteable", p2.Deleteable);
			}
			z0rek("GridLine", string.Empty, p2.GridLine, p3: false, p4: false);
			if (p2.SpecifyFixedLineHeight != 0f)
			{
				z0rek("SpecifyFixedLineHeight", p2.SpecifyFixedLineHeight);
			}
			base.z0rek((object?)p2);
		}
	}

	private string z0rek(ColorThemeType p0)
	{
		string text = null;
		return p0 switch
		{
			ColorThemeType.Default => "Default", 
			ColorThemeType.Air => "Air", 
			ColorThemeType.Through => "Through", 
			ColorThemeType.Summer => "Summer", 
			ColorThemeType.Pin => "Pin", 
			ColorThemeType.Wave => "Wave", 
			ColorThemeType.City => "City", 
			ColorThemeType.Compose => "Compose", 
			ColorThemeType.Energy => "Energy", 
			ColorThemeType.Dance => "Dance", 
			ColorThemeType.Custom => "Custom", 
			_ => throw z0ZzZzwhh.z0rek((long)p0, typeof(ColorThemeType)), 
		};
	}

	protected internal void z0rek(string p0, string p1, XTextChartElement p2, bool p3, bool p4)
	{
		z0iek = z0eek();
		z0ZzZzhqh z0ZzZzhqh2 = z0eek();
		if (p2 == null)
		{
			return;
		}
		if (!p4 && !(p2.GetType() == typeof(XTextChartElement)))
		{
			throw z0eek(p2);
		}
		z0eek(p0, p1, p2, p3: false, null);
		if (p4)
		{
			z0eek("XChart");
		}
		if (((XTextElement)p2).z0pek() != -1)
		{
			z0ZzZzhqh2.z0eek("StyleIndex", ((XTextElement)p2).z0pek());
		}
		z0rek(z0ZzZzhqh2, p2.Attributes);
		z0tek("ID", p2.ID);
		z0tek("ToolTip", p2.ToolTip);
		if (p2.OffsetX != 0f)
		{
			z0rek("OffsetX", p2.OffsetX);
		}
		if (p2.OffsetY != 0f)
		{
			z0rek("OffsetY", p2.OffsetY);
		}
		if (p2.ZOrderStyle != ElementZOrderStyle.Normal)
		{
			z0ZzZzhqh2.z0eek("ZOrderStyle", null, z0rek(p2.ZOrderStyle));
		}
		z0rek(z0ZzZzhqh2, p2.PropertyExpressions);
		z0tek("ValueExpression", p2.ValueExpression);
		if (!p2.Visible)
		{
			z0rek("Visible", p2.Visible);
		}
		if (p2.PrintVisibility != ElementVisibility.Visible)
		{
			z0ZzZzhqh2.z0eek("PrintVisibility", null, z0rek(p2.PrintVisibility));
		}
		z0rek("LinkInfo", string.Empty, ((XTextObjectElement)p2).z0iek(), p3: false, p4: false);
		if (p2.ContentReadonly != ContentReadonlyState.Inherit)
		{
			z0ZzZzhqh2.z0eek("ContentReadonly", null, z0rek(p2.ContentReadonly));
		}
		if (!p2.Deleteable)
		{
			z0rek("Deleteable", p2.Deleteable);
		}
		z0tek("Name", p2.Name);
		if (!p2.Enabled)
		{
			z0rek("Enabled", p2.Enabled);
		}
		z0tek("StringTag", p2.StringTag);
		z0rek("Width", p2.Width);
		z0rek("Height", p2.Height);
		z0tek("DataSourceName", p2.z0iek());
		z0tek("DataFieldNameForSeriesName", p2.z0cek());
		z0tek("DataFieldNameForGroupName", p2.z0yek());
		z0tek("DataFieldNameForText", p2.z0mek());
		z0tek("DataFieldNameForValue", p2.z0pek());
		z0tek("DataFieldNameForLink", p2.z0oek());
		z0tek("DataFieldNameForTipText", p2.z0uek());
		DCChartDataItemList dCChartDataItemList = p2.z0bek();
		if (dCChartDataItemList != null && dCChartDataItemList.Count > 0)
		{
			int count = dCChartDataItemList.Count;
			z0ZzZzhqh2.z0hf(null, "DataItems", null);
			for (int i = 0; i < count; i++)
			{
				z0rek("DataItem", string.Empty, dCChartDataItemList[i], p3: true, p4: false);
			}
			z0ZzZzhqh2.z0bg();
		}
		z0rek("ChartStyle", string.Empty, p2.z0tek(), p3: false, p4: false);
		base.z0rek((object?)p2);
	}

	protected internal void z0rek(string p0, string p1, z0ZzZzfzj p2, bool p3, bool p4)
	{
		z0iek = z0eek();
		if (p2 != null)
		{
			if (!p4 && !(p2.GetType() == typeof(z0ZzZzfzj)))
			{
				throw z0eek(p2);
			}
			z0eek(p0, p1, p2, p3: false, null);
			if (p4)
			{
				z0eek("PageImageInfo");
			}
			if (p2.z0tek() != 0)
			{
				z0rek("PageIndex", p2.z0tek());
			}
			z0rek("Image", string.Empty, p2.z0eek(), p3: false, p4: false);
			base.z0rek((object?)p2);
		}
	}

	protected internal void z0rek(string p0, string p1, XTextPieElement p2, bool p3, bool p4)
	{
		z0iek = z0eek();
		z0ZzZzhqh z0ZzZzhqh2 = z0eek();
		if (p2 == null)
		{
			return;
		}
		if (!p4 && !(p2.GetType() == typeof(XTextPieElement)))
		{
			throw z0eek(p2);
		}
		z0eek(p0, p1, p2, p3: false, null);
		if (p4)
		{
			z0eek("XPie");
		}
		if (((XTextElement)p2).z0pek() != -1)
		{
			z0ZzZzhqh2.z0eek("StyleIndex", ((XTextElement)p2).z0pek());
		}
		z0rek(z0ZzZzhqh2, p2.Attributes);
		z0tek("ID", p2.ID);
		z0tek("ToolTip", p2.ToolTip);
		if (p2.OffsetX != 0f)
		{
			z0rek("OffsetX", p2.OffsetX);
		}
		if (p2.OffsetY != 0f)
		{
			z0rek("OffsetY", p2.OffsetY);
		}
		if (p2.ZOrderStyle != ElementZOrderStyle.Normal)
		{
			z0ZzZzhqh2.z0eek("ZOrderStyle", null, z0rek(p2.ZOrderStyle));
		}
		z0rek(z0ZzZzhqh2, p2.PropertyExpressions);
		z0tek("ValueExpression", p2.ValueExpression);
		if (!p2.Visible)
		{
			z0rek("Visible", p2.Visible);
		}
		if (p2.PrintVisibility != ElementVisibility.Visible)
		{
			z0ZzZzhqh2.z0eek("PrintVisibility", null, z0rek(p2.PrintVisibility));
		}
		z0rek("LinkInfo", string.Empty, p2.z0iek(), p3: false, p4: false);
		if (p2.ContentReadonly != ContentReadonlyState.Inherit)
		{
			z0ZzZzhqh2.z0eek("ContentReadonly", null, z0rek(p2.ContentReadonly));
		}
		if (!p2.Deleteable)
		{
			z0rek("Deleteable", p2.Deleteable);
		}
		z0tek("Name", p2.Name);
		if (!p2.Enabled)
		{
			z0rek("Enabled", p2.Enabled);
		}
		z0tek("StringTag", p2.StringTag);
		z0rek("Width", p2.Width);
		z0rek("Height", p2.Height);
		z0tek("DataSourceName", p2.DataSourceName);
		z0tek("DataFieldNameForSeriesName", p2.DataFieldNameForSeriesName);
		z0tek("DataFieldNameForGroupName", p2.DataFieldNameForGroupName);
		z0tek("DataFieldNameForFillColorString", p2.DataFieldNameForFillColorString);
		z0tek("DataFieldNameForText", p2.DataFieldNameForText);
		z0tek("DataFieldNameForValue", p2.DataFieldNameForValue);
		z0tek("DataFieldNameForLink", p2.DataFieldNameForLink);
		z0tek("DataFieldNameForTipText", p2.DataFieldNameForTipText);
		DCPieDataItemList dataItems = p2.DataItems;
		if (dataItems != null && dataItems.Count > 0)
		{
			int count = dataItems.Count;
			z0ZzZzhqh2.z0hf(null, "DataItems", null);
			for (int i = 0; i < count; i++)
			{
				z0rek("DataItem", string.Empty, dataItems[i], p3: true, p4: false);
			}
			z0ZzZzhqh2.z0bg();
		}
		z0rek("PieDocumentStyle", string.Empty, p2.PieDocumentStyle, p3: false, p4: false);
		base.z0rek((object?)p2);
	}

	private string z0rek(ContentViewEncryptType p0)
	{
		string text = null;
		return p0 switch
		{
			ContentViewEncryptType.None => "None", 
			ContentViewEncryptType.Partial => "Partial", 
			ContentViewEncryptType.Both => "Both", 
			_ => throw z0ZzZzwhh.z0rek((long)p0, typeof(ContentViewEncryptType)), 
		};
	}

	private string z0rek(ContentLayoutDirectionStyle p0)
	{
		string text = null;
		return p0 switch
		{
			ContentLayoutDirectionStyle.Default => "Default", 
			ContentLayoutDirectionStyle.LeftToRight => "LeftToRight", 
			ContentLayoutDirectionStyle.RightToLeft => "RightToLeft", 
			ContentLayoutDirectionStyle.Invalidate => "Invalidate", 
			_ => throw z0ZzZzwhh.z0rek((long)p0, typeof(ContentLayoutDirectionStyle)), 
		};
	}

	protected internal void z0rek(string p0, string p1, XTextCustomShapeElement p2, bool p3, bool p4)
	{
		z0iek = z0eek();
		z0ZzZzhqh z0ZzZzhqh2 = z0eek();
		if (p2 != null)
		{
			if (!p4 && !(p2.GetType() == typeof(XTextCustomShapeElement)))
			{
				throw z0eek(p2);
			}
			z0eek(p0, p1, p2, p3: false, null);
			if (p4)
			{
				z0eek("XCustomShape");
			}
			if (((XTextElement)p2).z0pek() != -1)
			{
				z0ZzZzhqh2.z0eek("StyleIndex", ((XTextElement)p2).z0pek());
			}
			z0rek(z0ZzZzhqh2, p2.Attributes);
			z0tek("ID", p2.ID);
			z0tek("ToolTip", p2.ToolTip);
			if (p2.OffsetX != 0f)
			{
				z0rek("OffsetX", p2.OffsetX);
			}
			if (p2.OffsetY != 0f)
			{
				z0rek("OffsetY", p2.OffsetY);
			}
			if (p2.ZOrderStyle != ElementZOrderStyle.Normal)
			{
				z0ZzZzhqh2.z0eek("ZOrderStyle", null, z0rek(p2.ZOrderStyle));
			}
			z0rek(z0ZzZzhqh2, p2.PropertyExpressions);
			z0tek("ValueExpression", p2.ValueExpression);
			if (!p2.Visible)
			{
				z0rek("Visible", p2.Visible);
			}
			if (p2.PrintVisibility != ElementVisibility.Visible)
			{
				z0ZzZzhqh2.z0eek("PrintVisibility", null, z0rek(p2.PrintVisibility));
			}
			z0rek("LinkInfo", string.Empty, p2.z0iek(), p3: false, p4: false);
			if (p2.ContentReadonly != ContentReadonlyState.Inherit)
			{
				z0ZzZzhqh2.z0eek("ContentReadonly", null, z0rek(p2.ContentReadonly));
			}
			if (!p2.Deleteable)
			{
				z0rek("Deleteable", p2.Deleteable);
			}
			z0tek("Name", p2.Name);
			if (!p2.Enabled)
			{
				z0rek("Enabled", p2.Enabled);
			}
			z0tek("StringTag", p2.StringTag);
			z0rek("Width", p2.Width);
			z0rek("Height", p2.Height);
			if (p2.z0eek() != 0)
			{
				z0rek("ChartPageIndex", p2.z0eek());
			}
			z0tek("DrawContentHandlerName", p2.z0tek());
			base.z0rek((object?)p2);
		}
	}

	private string z0rek(CharacterCircleStyles p0)
	{
		string text = null;
		return p0 switch
		{
			CharacterCircleStyles.None => "None", 
			CharacterCircleStyles.Circle => "Circle", 
			CharacterCircleStyles.Rectangle => "Rectangle", 
			_ => throw z0ZzZzwhh.z0rek((long)p0, typeof(CharacterCircleStyles)), 
		};
	}

	private string z0rek(DCTDBarcodeType p0)
	{
		string text = null;
		if (p0 == DCTDBarcodeType.QR)
		{
			return "QR";
		}
		throw z0ZzZzwhh.z0rek((long)p0, typeof(DCTDBarcodeType));
	}

	protected internal void z0rek(string p0, string p1, XTextDocumentHeaderElement p2, bool p3, bool p4)
	{
		z0iek = z0eek();
		z0ZzZzhqh z0ZzZzhqh2 = z0eek();
		if (p2 != null)
		{
			if (!p4 && !(p2.GetType() == typeof(XTextDocumentHeaderElement)))
			{
				throw z0eek(p2);
			}
			z0eek(p0, p1, p2, p3: false, null);
			if (p4)
			{
				z0eek("XTextHeader");
			}
			if (p2.z0rek() != -1)
			{
				z0ZzZzhqh2.z0eek("StyleIndex", p2.z0rek());
			}
			z0rek(z0ZzZzhqh2, p2.Attributes);
			z0tek("ID", p2.ID);
			z0tek("LimitedInputChars", p2.LimitedInputChars);
			if (p2.HiddenPrintWhenEmpty)
			{
				z0rek("HiddenPrintWhenEmpty", p2.HiddenPrintWhenEmpty);
			}
			if (p2.MaxInputLength != 0)
			{
				z0rek("MaxInputLength", p2.MaxInputLength);
			}
			z0tek("DataName", p2.z0ht());
			if (p2.z0gt())
			{
				z0rek("CanBeReferenced", p2.z0gt());
			}
			if (p2.z0dt())
			{
				z0rek("BringoutToSave", p2.z0dt());
			}
			z0tek("ToolTip", p2.ToolTip);
			if (p2.AcceptTab)
			{
				z0rek("AcceptTab", p2.AcceptTab);
			}
			z0rek(z0ZzZzhqh2, p2.PropertyExpressions);
			if (p2.EnableValueValidate)
			{
				z0rek("EnableValueValidate", p2.EnableValueValidate);
			}
			z0rek("ValidateStyle", string.Empty, p2.ValidateStyle, p3: false, p4: false);
			z0rek("ValueBinding", string.Empty, p2.ValueBinding, p3: false, p4: false);
			z0tek("DefaultValueForValueBinding", ((XTextContainerElement)p2).z0nrk());
			z0tek("ContentReadonlyExpression", p2.ContentReadonlyExpression);
			z0tek("VisibleExpression", p2.VisibleExpression);
			z0tek("PrintVisibilityExpression", p2.PrintVisibilityExpression);
			z0tek("ValueExpression", p2.ValueExpression);
			if (p2.EnablePermission != DCBooleanValue.Inherit)
			{
				z0ZzZzhqh2.z0eek("EnablePermission", null, z0rek(p2.EnablePermission));
			}
			z0rek("ContentLock", string.Empty, p2.ContentLock, p3: false, p4: false);
			if (p2.ContentReadonly != ContentReadonlyState.Inherit)
			{
				z0ZzZzhqh2.z0eek("ContentReadonly", null, z0rek(p2.ContentReadonly));
			}
			z0rek("CopySource", string.Empty, p2.CopySource, p3: false, p4: false);
			z0rek(p2);
			if (p2.AcceptChildElementTypes2 != ElementType.All)
			{
				z0rek("AcceptChildElementTypes2", string.Empty, z0rek(p2.AcceptChildElementTypes2));
			}
			if (p2.PrintVisibility != ElementVisibility.Visible)
			{
				z0ZzZzhqh2.z0eek("PrintVisibility", null, z0rek(p2.PrintVisibility));
			}
			if (!p2.Visible)
			{
				z0rek("Visible", p2.Visible);
			}
			if (!p2.Deleteable)
			{
				z0rek("Deleteable", p2.Deleteable);
			}
			z0rek("GridLine", string.Empty, p2.GridLine, p3: false, p4: false);
			if (p2.SpecifyFixedLineHeight != 0f)
			{
				z0rek("SpecifyFixedLineHeight", p2.SpecifyFixedLineHeight);
			}
			base.z0rek((object?)p2);
		}
	}

	private string z0rek(DCBarcodeStyle p0)
	{
		string text = null;
		return p0 switch
		{
			DCBarcodeStyle.UNSPECIFIED => "UNSPECIFIED", 
			DCBarcodeStyle.UPCA => "UPCA", 
			DCBarcodeStyle.UPCE => "UPCE", 
			DCBarcodeStyle.SUPP2 => "SUPP2", 
			DCBarcodeStyle.SUPP5 => "SUPP5", 
			DCBarcodeStyle.EAN13 => "EAN13", 
			DCBarcodeStyle.EAN8 => "EAN8", 
			DCBarcodeStyle.Interleaved2of5 => "Interleaved2of5", 
			DCBarcodeStyle.Standard2of5 => "Standard2of5", 
			DCBarcodeStyle.I2of5 => "I2of5", 
			DCBarcodeStyle.Code39 => "Code39", 
			DCBarcodeStyle.Code39Extended => "Code39Extended", 
			DCBarcodeStyle.Code93 => "Code93", 
			DCBarcodeStyle.Codabar => "Codabar", 
			DCBarcodeStyle.PostNet => "PostNet", 
			DCBarcodeStyle.BOOKLAND => "BOOKLAND", 
			DCBarcodeStyle.ISBN => "ISBN", 
			DCBarcodeStyle.JAN13 => "JAN13", 
			DCBarcodeStyle.MSI_Mod10 => "MSI_Mod10", 
			DCBarcodeStyle.MSI_2Mod10 => "MSI_2Mod10", 
			DCBarcodeStyle.MSI_Mod11 => "MSI_Mod11", 
			DCBarcodeStyle.MSI_Mod11_Mod10 => "MSI_Mod11_Mod10", 
			DCBarcodeStyle.Modified_Plessey => "Modified_Plessey", 
			DCBarcodeStyle.CODE11 => "CODE11", 
			DCBarcodeStyle.USD8 => "USD8", 
			DCBarcodeStyle.UCC12 => "UCC12", 
			DCBarcodeStyle.UCC13 => "UCC13", 
			DCBarcodeStyle.LOGMARS => "LOGMARS", 
			DCBarcodeStyle.Code128A => "Code128A", 
			DCBarcodeStyle.Code128B => "Code128B", 
			DCBarcodeStyle.Code128C => "Code128C", 
			_ => throw z0ZzZzwhh.z0rek((long)p0, typeof(DCBarcodeStyle)), 
		};
	}

	private string z0rek(CheckBoxVisualStyle p0)
	{
		string text = null;
		return p0 switch
		{
			CheckBoxVisualStyle.Default => "Default", 
			CheckBoxVisualStyle.CheckBox => "CheckBox", 
			CheckBoxVisualStyle.RadioBox => "RadioBox", 
			CheckBoxVisualStyle.SystemDefault => "SystemDefault", 
			CheckBoxVisualStyle.SystemCheckBox => "SystemCheckBox", 
			CheckBoxVisualStyle.SystemRadioBox => "SystemRadioBox", 
			_ => throw z0ZzZzwhh.z0rek((long)p0, typeof(CheckBoxVisualStyle)), 
		};
	}

	private string z0rek(ContentReadonlyState p0)
	{
		string text = null;
		return p0 switch
		{
			ContentReadonlyState.True => "True", 
			ContentReadonlyState.False => "False", 
			ContentReadonlyState.Inherit => "Inherit", 
			_ => throw z0ZzZzwhh.z0rek((long)p0, typeof(ContentReadonlyState)), 
		};
	}

	private string z0rek(DCCASignMode p0)
	{
		string text = null;
		return p0 switch
		{
			DCCASignMode.Default => "Default", 
			DCCASignMode.Normal => "Normal", 
			DCCASignMode.SignHand => "SignHand", 
			_ => throw z0ZzZzwhh.z0rek((long)p0, typeof(DCCASignMode)), 
		};
	}

	protected internal void z0rek(string p0, string p1, XTextSubDocumentElement p2, bool p3, bool p4)
	{
		z0iek = z0eek();
		z0ZzZzhqh z0ZzZzhqh2 = z0eek();
		if (p2 != null)
		{
			if (!p4 && !(p2.GetType() == typeof(XTextSubDocumentElement)))
			{
				throw z0eek(p2);
			}
			z0eek(p0, p1, p2, p3: false, null);
			if (p4)
			{
				z0eek("XTextSubDocument");
			}
			if (((XTextElement)p2).z0pek() != -1)
			{
				z0ZzZzhqh2.z0eek("StyleIndex", ((XTextElement)p2).z0pek());
			}
			z0rek(z0ZzZzhqh2, p2.Attributes);
			z0tek("ID", p2.ID);
			z0tek("LimitedInputChars", p2.LimitedInputChars);
			if (p2.HiddenPrintWhenEmpty)
			{
				z0rek("HiddenPrintWhenEmpty", p2.HiddenPrintWhenEmpty);
			}
			if (p2.MaxInputLength != 0)
			{
				z0rek("MaxInputLength", p2.MaxInputLength);
			}
			z0tek("DataName", p2.z0ht());
			if (p2.z0gt())
			{
				z0rek("CanBeReferenced", p2.z0gt());
			}
			if (p2.z0dt())
			{
				z0rek("BringoutToSave", p2.z0dt());
			}
			z0tek("ToolTip", p2.ToolTip);
			if (p2.AcceptTab)
			{
				z0rek("AcceptTab", p2.AcceptTab);
			}
			z0rek(z0ZzZzhqh2, p2.PropertyExpressions);
			if (p2.EnableValueValidate)
			{
				z0rek("EnableValueValidate", p2.EnableValueValidate);
			}
			z0rek("ValidateStyle", string.Empty, p2.ValidateStyle, p3: false, p4: false);
			z0rek("ValueBinding", string.Empty, p2.ValueBinding, p3: false, p4: false);
			z0tek("DefaultValueForValueBinding", ((XTextContainerElement)p2).z0nrk());
			z0tek("ContentReadonlyExpression", p2.ContentReadonlyExpression);
			z0tek("VisibleExpression", p2.VisibleExpression);
			z0tek("PrintVisibilityExpression", p2.PrintVisibilityExpression);
			z0tek("ValueExpression", p2.ValueExpression);
			if (p2.EnablePermission != DCBooleanValue.Inherit)
			{
				z0ZzZzhqh2.z0eek("EnablePermission", null, z0rek(p2.EnablePermission));
			}
			z0rek("ContentLock", string.Empty, p2.ContentLock, p3: false, p4: false);
			if (p2.ContentReadonly != ContentReadonlyState.Inherit)
			{
				z0ZzZzhqh2.z0eek("ContentReadonly", null, z0rek(p2.ContentReadonly));
			}
			z0rek("CopySource", string.Empty, p2.CopySource, p3: false, p4: false);
			z0rek(p2);
			if (p2.AcceptChildElementTypes2 != ElementType.All)
			{
				z0rek("AcceptChildElementTypes2", string.Empty, z0rek(p2.AcceptChildElementTypes2));
			}
			if (p2.PrintVisibility != ElementVisibility.Visible)
			{
				z0ZzZzhqh2.z0eek("PrintVisibility", null, z0rek(p2.PrintVisibility));
			}
			if (!p2.Visible)
			{
				z0rek("Visible", p2.Visible);
			}
			if (!p2.Deleteable)
			{
				z0rek("Deleteable", p2.Deleteable);
			}
			z0rek("GridLine", string.Empty, p2.GridLine, p3: false, p4: false);
			if (p2.SpecifyFixedLineHeight != 0f)
			{
				z0rek("SpecifyFixedLineHeight", p2.SpecifyFixedLineHeight);
			}
			if (p2.NewPage)
			{
				z0rek("NewPage", p2.NewPage);
			}
			if (p2.InsertEmptyPageForNewPage)
			{
				z0rek("InsertEmptyPageForNewPage", p2.InsertEmptyPageForNewPage);
			}
			if (!p2.ExpendForDataBinding)
			{
				z0rek("ExpendForDataBinding", p2.ExpendForDataBinding);
			}
			z0tek("ForeColorValueForCollapsed", p2.ForeColorValueForCollapsed);
			if (p2.EnableCollapse)
			{
				z0rek("EnableCollapse", p2.EnableCollapse);
			}
			if (p2.IsCollapsed)
			{
				z0rek("IsCollapsed", p2.IsCollapsed);
			}
			z0tek("Title", p2.Title);
			if (p2.CompressOwnerLineSpacing)
			{
				z0rek("CompressOwnerLineSpacing", p2.CompressOwnerLineSpacing);
			}
			if (p2.SpecifyHeight != 0f)
			{
				z0rek("SpecifyHeight", p2.SpecifyHeight);
			}
			z0tek("Name", p2.Name);
			z0tek("DocumentID", p2.DocumentID);
			if (p2.Printed)
			{
				z0rek("Printed", p2.Printed);
			}
			if (p2.PrintedPageIndex != -1)
			{
				z0rek("PrintedPageIndex", p2.PrintedPageIndex);
			}
			if (p2.PrintPositionInPage != 0f)
			{
				z0rek("PrintPositionInPage", p2.PrintPositionInPage);
			}
			if (p2.Locked)
			{
				z0rek("Locked", p2.Locked);
			}
			z0rek("DocumentInfo", string.Empty, p2.DocumentInfo, p3: false, p4: false);
			z0tek("FileName", p2.FileName);
			z0tek("FileFormat", p2.FileFormat);
			if (!p2.ImportUserTrack)
			{
				z0rek("ImportUserTrack", p2.ImportUserTrack);
			}
			if (p2.DelayLoadWhenExpand)
			{
				z0rek("DelayLoadWhenExpand", p2.DelayLoadWhenExpand);
			}
			if (p2.ContentLoaded)
			{
				z0rek("ContentLoaded", p2.ContentLoaded);
			}
			base.z0rek((object?)p2);
		}
	}

	private string z0rek(InputFieldEditStyle p0)
	{
		string text = null;
		return p0 switch
		{
			InputFieldEditStyle.Text => "Text", 
			InputFieldEditStyle.DropdownList => "DropdownList", 
			InputFieldEditStyle.Date => "Date", 
			InputFieldEditStyle.DateTime => "DateTime", 
			InputFieldEditStyle.DateTimeWithoutSecond => "DateTimeWithoutSecond", 
			InputFieldEditStyle.Time => "Time", 
			InputFieldEditStyle.Numeric => "Numeric", 
			_ => throw z0ZzZzwhh.z0rek((long)p0, typeof(InputFieldEditStyle)), 
		};
	}

	private string z0rek(z0ZzZzikh p0)
	{
		string text = null;
		return p0 switch
		{
			(z0ZzZzikh)0 => "NextElement", 
			(z0ZzZzikh)1 => "Custom", 
			(z0ZzZzikh)2 => "None", 
			_ => throw z0ZzZzwhh.z0rek((long)p0, typeof(z0ZzZzikh)), 
		};
	}

	private string z0rek(z0ZzZzldh p0)
	{
		string text = null;
		return p0 switch
		{
			(z0ZzZzldh)0 => "Flat", 
			(z0ZzZzldh)1 => "Square", 
			(z0ZzZzldh)2 => "Round", 
			(z0ZzZzldh)3 => "Triangle", 
			(z0ZzZzldh)4 => "NoAnchor", 
			(z0ZzZzldh)5 => "SquareAnchor", 
			(z0ZzZzldh)6 => "RoundAnchor", 
			(z0ZzZzldh)7 => "DiamondAnchor", 
			(z0ZzZzldh)8 => "ArrowAnchor", 
			(z0ZzZzldh)9 => "Custom", 
			(z0ZzZzldh)10 => "AnchorMask", 
			_ => throw z0ZzZzwhh.z0rek((long)p0, typeof(z0ZzZzldh)), 
		};
	}

	protected internal void z0rek(string p0, string p1, z0ZzZzfpk p2, bool p3, bool p4)
	{
		z0iek = z0eek();
		if (p2 != null)
		{
			if (!p4 && !(p2.GetType() == typeof(z0ZzZzfpk)))
			{
				throw z0eek(p2);
			}
			z0eek(p0, p1, p2, p3: false, null);
			if (p4)
			{
				z0eek("DocumentTerminalTextInfo");
			}
			z0tek("Text", p2.z0mek());
			z0tek("TextInMiddlePage", p2.z0rek());
			z0rek("Font", p2.z0uek());
			z0tek("ColorValue", p2.z0pek());
			if (p2.z0bek() != 2f)
			{
				z0rek("MinHeightInCMUnit", p2.z0bek());
			}
			base.z0rek((object?)p2);
		}
	}

	private string z0rek(z0ZzZzkdh p0)
	{
		string text = null;
		return p0 switch
		{
			(z0ZzZzkdh)0 => "Miter", 
			(z0ZzZzkdh)1 => "Bevel", 
			(z0ZzZzkdh)2 => "Round", 
			(z0ZzZzkdh)3 => "MiterClipped", 
			_ => throw z0ZzZzwhh.z0rek((long)p0, typeof(z0ZzZzkdh)), 
		};
	}

	protected internal void z0rek(string p0, string p1, DocumentParameter p2, bool p3, bool p4)
	{
		z0iek = z0eek();
		z0ZzZzhqh z0ZzZzhqh2 = z0eek();
		if (p2 != null)
		{
			if (!p4 && !(p2.GetType() == typeof(DocumentParameter)))
			{
				throw z0eek(p2);
			}
			z0eek(p0, p1, p2, p3: false, null);
			if (p4)
			{
				z0eek("DocumentParameter");
			}
			z0eek("Name", p2.z0eek());
			z0eek("Description", p2.z0pek());
			z0eek("TypeName", p2.z0iek());
			if (p2.z0tek() != (z0ZzZzjvj)7)
			{
				z0ZzZzhqh2.z0eek("ValueType", z0rek(p2.z0tek()));
			}
			z0eek("SourceColumn", p2.z0mek());
			z0eek("DefaultValue", p2.z0nek());
			z0eek("ValueTypeFullName", p2.z0uek());
			base.z0rek((object?)p2);
		}
	}

	private string z0rek(RectangleSlantSplitStyle p0)
	{
		string text = null;
		return p0 switch
		{
			RectangleSlantSplitStyle.None => "None", 
			RectangleSlantSplitStyle.TopLeftOneLine => "TopLeftOneLine", 
			RectangleSlantSplitStyle.TopLeftTwoLines => "TopLeftTwoLines", 
			RectangleSlantSplitStyle.TopRightOneLine => "TopRightOneLine", 
			RectangleSlantSplitStyle.TopRightTwoLines => "TopRightTwoLines", 
			RectangleSlantSplitStyle.BottomRightOneLine => "BottomRightOneLine", 
			RectangleSlantSplitStyle.BottomRigthTwoLines => "BottomRigthTwoLines", 
			RectangleSlantSplitStyle.BottomLeftOneLine => "BottomLeftOneLine", 
			RectangleSlantSplitStyle.BottomLeftTwoLines => "BottomLeftTwoLines", 
			_ => throw z0ZzZzwhh.z0rek((long)p0, typeof(RectangleSlantSplitStyle)), 
		};
	}

	private string z0rek(GraphicsUnit p0)
	{
		string text = null;
		return p0 switch
		{
			GraphicsUnit.World => "World", 
			GraphicsUnit.Display => "Display", 
			GraphicsUnit.Pixel => "Pixel", 
			GraphicsUnit.Point => "Point", 
			GraphicsUnit.Inch => "Inch", 
			GraphicsUnit.Document => "Document", 
			GraphicsUnit.Millimeter => "Millimeter", 
			_ => throw z0ZzZzwhh.z0rek((long)p0, typeof(GraphicsUnit)), 
		};
	}

	protected internal void z0rek(string p0, string p1, DCChartDataItem p2, bool p3, bool p4)
	{
		z0iek = z0eek();
		z0ZzZzhqh z0ZzZzhqh2 = z0eek();
		if (p2 != null)
		{
			if (!p4 && !(p2.GetType() == typeof(DCChartDataItem)))
			{
				throw z0eek(p2);
			}
			z0eek(p0, p1, p2, p3: false, null);
			if (p4)
			{
				z0eek("ChartDataItem");
			}
			z0eek("SeriesName", p2.SeriesName);
			z0eek("GroupName", p2.GroupName);
			z0eek("Text", p2.Text);
			z0eek("TipText", p2.TipText);
			z0eek("Link", p2.Link);
			z0eek("ColorValue", p2.ColorValue);
			if (p2.ChartStyle != ChartStyleConsts.Default)
			{
				z0ZzZzhqh2.z0eek("ChartStyle", z0rek(p2.ChartStyle));
			}
			if (p2.SymbolType != ShapeTypes.Default)
			{
				z0ZzZzhqh2.z0eek("SymbolType", z0rek(p2.SymbolType));
			}
			if (p2.SymbolSize != 10)
			{
				z0ZzZzhqh2.z0eek("SymbolSize", p2.SymbolSize);
			}
			if (p2.Value != 0.0)
			{
				z0ZzZzhqh2.z0eek("Value", p2.Value);
			}
			base.z0rek((object?)p2);
		}
	}

	protected internal void z0rek(string p0, string p1, XTextSignImageElement p2, bool p3, bool p4)
	{
		z0iek = z0eek();
		z0ZzZzhqh z0ZzZzhqh2 = z0eek();
		if (p2 != null)
		{
			if (!p4 && !(p2.GetType() == typeof(XTextSignImageElement)))
			{
				throw z0eek(p2);
			}
			z0eek(p0, p1, p2, p3: false, null);
			if (p4)
			{
				z0eek("XSignImage");
			}
			if (((XTextElement)p2).z0pek() != -1)
			{
				z0ZzZzhqh2.z0eek("StyleIndex", ((XTextElement)p2).z0pek());
			}
			z0eek("SignUserName", p2.SignUserName);
			z0eek("SignClientName", p2.SignClientName);
			z0eek("SignMessage", p2.SignMessage);
			z0eek("SignErrorMessage", p2.SignErrorMessage);
			if (p2.DefaultSignMode != DCCASignMode.Normal)
			{
				z0ZzZzhqh2.z0eek("DefaultSignMode", z0rek(p2.DefaultSignMode));
			}
			z0eek("SignProviderName", p2.SignProviderName);
			z0ZzZzhqh2.z0eek("SignTime", z0ZzZzkhh.z0eek(p2.SignTime));
			if (p2.UseInnerSignProvider)
			{
				z0ZzZzhqh2.z0eek("UseInnerSignProvider", p2.UseInnerSignProvider);
			}
			if (p2.SignRange != DCSignRange.Parent)
			{
				z0ZzZzhqh2.z0eek("SignRange", z0rek(p2.SignRange));
			}
			z0rek(z0ZzZzhqh2, p2.Attributes);
			z0tek("ID", p2.ID);
			z0tek("ToolTip", p2.ToolTip);
			if (p2.OffsetX != 0f)
			{
				z0rek("OffsetX", p2.OffsetX);
			}
			if (p2.OffsetY != 0f)
			{
				z0rek("OffsetY", p2.OffsetY);
			}
			if (p2.ZOrderStyle != ElementZOrderStyle.Normal)
			{
				z0ZzZzhqh2.z0eek("ZOrderStyle", null, z0rek(p2.ZOrderStyle));
			}
			z0rek(z0ZzZzhqh2, p2.PropertyExpressions);
			z0tek("ValueExpression", p2.ValueExpression);
			if (!p2.Visible)
			{
				z0rek("Visible", p2.Visible);
			}
			if (p2.PrintVisibility != ElementVisibility.Visible)
			{
				z0ZzZzhqh2.z0eek("PrintVisibility", null, z0rek(p2.PrintVisibility));
			}
			z0rek("LinkInfo", string.Empty, ((XTextObjectElement)p2).z0iek(), p3: false, p4: false);
			if (p2.ContentReadonly != ContentReadonlyState.Inherit)
			{
				z0ZzZzhqh2.z0eek("ContentReadonly", null, z0rek(p2.ContentReadonly));
			}
			if (!p2.Deleteable)
			{
				z0rek("Deleteable", p2.Deleteable);
			}
			z0tek("Name", p2.Name);
			if (!p2.Enabled)
			{
				z0rek("Enabled", p2.Enabled);
			}
			z0tek("StringTag", p2.StringTag);
			z0rek("Width", p2.Width);
			z0rek("Height", p2.Height);
			z0tek("SignUserID", p2.SignUserID);
			z0rek("LastVerifyResult", string.Empty, z0ZzZzkhh.z0eek(p2.LastVerifyResult));
			z0rek("DataForSelfCheck", string.Empty, z0ZzZzkhh.z0eek(p2.DataForSelfCheck));
			z0rek("ImageData", string.Empty, z0ZzZzkhh.z0eek(p2.ImageData));
			z0tek("Title", p2.Title);
			base.z0rek((object?)p2);
		}
	}

	protected internal void z0rek(string p0, string p1, z0ZzZzeuj p2, bool p3, bool p4)
	{
		z0iek = z0eek();
		z0ZzZzhqh z0ZzZzhqh2 = z0eek();
		if (p2 == null)
		{
			return;
		}
		if (!p4)
		{
			Type type = p2.GetType();
			if (!(type == typeof(z0ZzZzeuj)))
			{
				if (type == typeof(z0ZzZziuj))
				{
					z0rek(p0, p1, (z0ZzZziuj)p2, p3, p4: true);
					return;
				}
				if (type == typeof(z0ZzZzwuj))
				{
					z0rek(p0, p1, (z0ZzZzwuj)p2, p3, p4: true);
					return;
				}
				if (type == typeof(z0ZzZzfuj))
				{
					z0rek(p0, p1, (z0ZzZzfuj)p2, p3, p4: true);
					return;
				}
				if (type == typeof(z0ZzZzxyj))
				{
					z0rek(p0, p1, (z0ZzZzxyj)p2, p3, p4: true);
					return;
				}
				if (type == typeof(z0ZzZzjuj))
				{
					z0rek(p0, p1, (z0ZzZzjuj)p2, p3, p4: true);
					return;
				}
				if (type == typeof(z0ZzZzkuj))
				{
					z0rek(p0, p1, (z0ZzZzkuj)p2, p3, p4: true);
					return;
				}
				if (type == typeof(z0ZzZzluj))
				{
					z0rek(p0, p1, (z0ZzZzluj)p2, p3, p4: true);
					return;
				}
				throw z0eek(p2);
			}
		}
		z0eek(p0, p1, p2, p3: false, null);
		if (p4)
		{
			z0eek("ShapeRectangleElement");
		}
		if (((z0ZzZzhuj)p2).z0eek() != -1)
		{
			z0ZzZzhqh2.z0eek("StyleIndex", ((z0ZzZzhuj)p2).z0eek());
		}
		z0rek("LocalStyle", string.Empty, ((z0ZzZzhuj)p2).z0pek(), p3: false, p4: false);
		if (!p2.z0rek_jiejie20260327142557())
		{
			z0rek("Visible", p2.z0rek_jiejie20260327142557());
		}
		z0tek("ID", ((z0ZzZzhuj)p2).z0yek());
		if (p2.z0rek() != 0f)
		{
			z0rek("Left", p2.z0rek());
		}
		if (p2.z0oek() != 0f)
		{
			z0rek("Top", p2.z0oek());
		}
		if (p2.z0mek() != 100f)
		{
			z0rek("Width", p2.z0mek());
		}
		if (p2.z0eek() != 100f)
		{
			z0rek("Height", p2.z0eek());
		}
		if (!p2.z0xkk())
		{
			z0rek("Resizeable", p2.z0xkk());
		}
		z0tek("Text", p2.z0pek());
		base.z0rek((object?)p2);
	}

	private string z0rek(DCMedicalExpressionStyle p0)
	{
		string text = null;
		return p0 switch
		{
			DCMedicalExpressionStyle.FourValuesGeneral => "FourValuesGeneral", 
			DCMedicalExpressionStyle.FourValues => "FourValues", 
			DCMedicalExpressionStyle.FourValues1 => "FourValues1", 
			DCMedicalExpressionStyle.FourValues2 => "FourValues2", 
			DCMedicalExpressionStyle.FourValues4 => "FourValues4", 
			DCMedicalExpressionStyle.FourValues5 => "FourValues5", 
			DCMedicalExpressionStyle.ThreeValues => "ThreeValues", 
			DCMedicalExpressionStyle.Pupil => "Pupil", 
			DCMedicalExpressionStyle.LightPositioning => "LightPositioning", 
			DCMedicalExpressionStyle.FetalHeart => "FetalHeart", 
			DCMedicalExpressionStyle.PermanentTeethBitmap => "PermanentTeethBitmap", 
			DCMedicalExpressionStyle.DeciduousTeech => "DeciduousTeech", 
			DCMedicalExpressionStyle.PainIndex => "PainIndex", 
			DCMedicalExpressionStyle.PDTeech => "PDTeech", 
			DCMedicalExpressionStyle.DiseasedTeethBotton => "DiseasedTeethBotton", 
			DCMedicalExpressionStyle.DiseasedTeethTop => "DiseasedTeethTop", 
			DCMedicalExpressionStyle.Fraction => "Fraction", 
			DCMedicalExpressionStyle.ElectricPulpTestingTeeth => "ElectricPulpTestingTeeth", 
			DCMedicalExpressionStyle.StationaryBridgeTeeth => "StationaryBridgeTeeth", 
			DCMedicalExpressionStyle.ThreeValues2 => "ThreeValues2", 
			DCMedicalExpressionStyle.StrabismusSymbol => "StrabismusSymbol", 
			DCMedicalExpressionStyle.ManyValues => "ManyValues", 
			DCMedicalExpressionStyle.AdvancedTeech => "AdvancedTeech", 
			_ => throw z0ZzZzwhh.z0rek((long)p0, typeof(DCMedicalExpressionStyle)), 
		};
	}

	private string z0rek(TextUnderlineStyle p0)
	{
		string text = null;
		return p0 switch
		{
			TextUnderlineStyle.None => "None", 
			TextUnderlineStyle.Single => "Single", 
			TextUnderlineStyle.Thick => "Thick", 
			TextUnderlineStyle.Dash => "Dash", 
			TextUnderlineStyle.Dot => "Dot", 
			TextUnderlineStyle.DashDot => "DashDot", 
			TextUnderlineStyle.DashDotDot => "DashDotDot", 
			TextUnderlineStyle.Double => "Double", 
			TextUnderlineStyle.Wavy => "Wavy", 
			TextUnderlineStyle.WavyDouble => "WavyDouble", 
			TextUnderlineStyle.WavyHeavy => "WavyHeavy", 
			_ => throw z0ZzZzwhh.z0rek((long)p0, typeof(TextUnderlineStyle)), 
		};
	}

	private string z0rek(StringAlignment p0)
	{
		string text = null;
		return p0 switch
		{
			StringAlignment.Near => "Near", 
			StringAlignment.Center => "Center", 
			StringAlignment.Far => "Far", 
			_ => throw z0ZzZzwhh.z0rek((long)p0, typeof(StringAlignment)), 
		};
	}

	protected internal void z0rek(string p0, string p1, DocumentInfo p2, bool p3, bool p4)
	{
		z0iek = z0eek();
		z0ZzZzhqh z0ZzZzhqh2 = z0eek();
		if (p2 != null)
		{
			if (!p4 && !(p2.GetType() == typeof(DocumentInfo)))
			{
				throw z0eek(p2);
			}
			z0eek(p0, p1, p2, p3: false, null);
			if (p4)
			{
				z0eek("DocumentInfo");
			}
			z0rek("SubDocumentSettings", string.Empty, p2.z0frk(), p3: false, p4: false);
			if (p2.z0lrk())
			{
				z0rek("Readonly", p2.z0lrk());
			}
			if (p2.ShowHeaderBottomLine != DCBooleanValue.Inherit)
			{
				z0ZzZzhqh2.z0eek("ShowHeaderBottomLine", null, z0rek(p2.ShowHeaderBottomLine));
			}
			if (p2.z0rek() != 1f)
			{
				z0rek("FieldBorderElementWidth", p2.z0rek());
			}
			if (p2.z0tek() != 0)
			{
				z0rek("KBEntryRangeMask", p2.z0tek());
			}
			z0tek("ID", p2.z0srk());
			if (p2.z0drk())
			{
				z0rek("IsTemplate", p2.z0drk());
			}
			z0tek("MRID", p2.z0grk());
			if (p2.z0uek() != 0)
			{
				z0rek("TimeoutHours", p2.z0uek());
			}
			z0tek("Version", p2.z0hrk());
			z0tek("Title", p2.z0mek());
			z0tek("Description", p2.z0mrk());
			z0tek("LicenseText", p2.z0nek());
			z0rek("CreationTime", z0ZzZzkhh.z0eek(p2.z0nrk()));
			z0rek("LastModifiedTime", z0ZzZzkhh.z0eek(p2.z0wrk()));
			if (p2.z0krk() != 0)
			{
				z0rek("EditMinute", p2.z0krk());
			}
			z0rek("LastPrintTime", z0ZzZzkhh.z0eek(p2.z0oek()));
			z0tek("Author", p2.z0trk());
			z0tek("AuthorName", p2.z0xek());
			if (p2.z0eek() != 0)
			{
				z0rek("AuthorPermissionLevel", p2.z0eek());
			}
			z0tek("DepartmentID", p2.z0cek());
			z0tek("DepartmentName", p2.z0jrk());
			z0tek("DocumentFormat", p2.z0erk());
			z0tek("DocumentType", p2.z0bek());
			if (p2.z0qrk() != 0)
			{
				z0rek("DocumentProcessState", p2.z0qrk());
			}
			if (p2.z0vek() != 0)
			{
				z0rek("DocumentEditState", p2.z0vek());
			}
			z0tek("Comment", p2.z0ark());
			z0tek("Operator", p2.z0ork());
			if (p2.z0irk() != 0)
			{
				z0rek("NumOfPage", p2.z0irk());
			}
			if (p2.z0pek())
			{
				z0rek("UseLanguage2", p2.z0pek());
			}
			if (!p2.z0iek_jiejie20260327142557())
			{
				z0rek("Printable", p2.z0iek_jiejie20260327142557());
			}
			if (p2.z0yrk() != 0)
			{
				z0rek("StartPositionInPringJob", p2.z0yrk());
			}
			if (p2.z0urk() != 0)
			{
				z0rek("HeightInPrintJob", p2.z0urk());
			}
			base.z0rek((object?)p2);
		}
	}

	protected internal void z0rek(string p0, string p1, z0ZzZzstk p2, bool p3, bool p4)
	{
		z0iek = z0eek();
		z0ZzZzhqh z0ZzZzhqh2 = z0eek();
		if (p2 != null)
		{
			if (!p4 && !(p2.GetType() == typeof(z0ZzZzstk)))
			{
				throw z0eek(p2);
			}
			z0eek(p0, p1, p2, p3: false, null);
			if (p4)
			{
				z0eek("ChartCaptionStyle");
			}
			if (p2.z0jrk())
			{
				z0rek("Visible", p2.z0jrk());
			}
			if (!p2.z0xek())
			{
				z0rek("LeftSide", p2.z0xek());
			}
			z0tek("Name", p2.z0mek());
			if (p2.z0cek() != 100.0)
			{
				z0rek("MaxValue", p2.z0cek());
			}
			if (p2.z0hrk() != 0.0)
			{
				z0rek("MinValue", p2.z0hrk());
			}
			if (p2.z0oek() != RangeCalculateStyle.None)
			{
				z0ZzZzhqh2.z0eek("MaxMinValueStyle", null, z0rek(p2.z0oek()));
			}
			if (p2.z0pek() != 10.0)
			{
				z0rek("GridStep", p2.z0pek());
			}
			z0tek("TickTextList", p2.z0srk());
			z0tek("Text", p2.z0iek());
			if (p2.z0drk() != 100f)
			{
				z0rek("Height", p2.z0drk());
			}
			z0rek("Font", p2.z0vek());
			if (p2.z0nek() != ContentAlignment.MiddleCenter)
			{
				z0ZzZzhqh2.z0eek("Alignment", null, z0rek(p2.z0nek()));
			}
			z0tek("Color", p2.z0krk());
			base.z0rek((object?)p2);
		}
	}

	private string z0rek(ContentLayoutAlign p0)
	{
		string text = null;
		return p0 switch
		{
			ContentLayoutAlign.EmbedInText => "EmbedInText", 
			ContentLayoutAlign.Surroundings => "Surroundings", 
			_ => throw z0ZzZzwhh.z0rek((long)p0, typeof(ContentLayoutAlign)), 
		};
	}

	protected internal void z0rek(string p0, string p1, z0ZzZzsvj p2, bool p3, bool p4)
	{
		z0iek = z0eek();
		z0ZzZzhqh z0ZzZzhqh2 = z0eek();
		if (p2 == null)
		{
			return;
		}
		if (!p4 && !(p2.GetType() == typeof(z0ZzZzsvj)))
		{
			throw z0eek(p2);
		}
		z0eek(p0, p1, p2, p3: false, null);
		if (p4)
		{
			z0eek("ListSourceInfo");
		}
		z0tek("SourceName", p2.SourceName);
		z0tek("DisplayPath", p2.DisplayPath);
		z0tek("ValuePath", p2.ValuePath);
		z0ZzZzdvj items = p2.Items;
		if (items != null && items.Count > 0)
		{
			int count = items.Count;
			z0ZzZzhqh2.z0hf(null, "Items", null);
			for (int i = 0; i < count; i++)
			{
				z0rek("Item", string.Empty, items[i], p3: true, p4: false);
			}
			z0ZzZzhqh2.z0bg();
		}
		if (!p2.BufferItems)
		{
			z0rek("BufferItems", p2.BufferItems);
		}
		base.z0rek((object?)p2);
	}

	private string z0rek(ParagraphListStyle p0)
	{
		string text = null;
		return p0 switch
		{
			ParagraphListStyle.None => "None", 
			ParagraphListStyle.ListNumberStyle => "ListNumberStyle", 
			ParagraphListStyle.ListNumberStyleArabic1 => "ListNumberStyleArabic1", 
			ParagraphListStyle.ListNumberStyleArabic2 => "ListNumberStyleArabic2", 
			ParagraphListStyle.ListNumberStyleArabic3 => "ListNumberStyleArabic3", 
			ParagraphListStyle.ListNumberStyleLowercaseLetter => "ListNumberStyleLowercaseLetter", 
			ParagraphListStyle.ListNumberStyleLowercaseRoman => "ListNumberStyleLowercaseRoman", 
			ParagraphListStyle.ListNumberStyleNumberInCircle => "ListNumberStyleNumberInCircle", 
			ParagraphListStyle.ListNumberStyleSimpChinNum1 => "ListNumberStyleSimpChinNum1", 
			ParagraphListStyle.ListNumberStyleSimpChinNum2 => "ListNumberStyleSimpChinNum2", 
			ParagraphListStyle.ListNumberStyleTradChinNum1 => "ListNumberStyleTradChinNum1", 
			ParagraphListStyle.ListNumberStyleTradChinNum2 => "ListNumberStyleTradChinNum2", 
			ParagraphListStyle.ListNumberStyleUppercaseLetter => "ListNumberStyleUppercaseLetter", 
			ParagraphListStyle.ListNumberStyleUppercaseRoman => "ListNumberStyleUppercaseRoman", 
			ParagraphListStyle.ListNumberStyleZodiac1 => "ListNumberStyleZodiac1", 
			ParagraphListStyle.ListNumberStyleZodiac2 => "ListNumberStyleZodiac2", 
			ParagraphListStyle.BulletedList => "BulletedList", 
			ParagraphListStyle.BulletedListBlock => "BulletedListBlock", 
			ParagraphListStyle.BulletedListDiamond => "BulletedListDiamond", 
			ParagraphListStyle.BulletedListCheck => "BulletedListCheck", 
			ParagraphListStyle.BulletedListRightArrow => "BulletedListRightArrow", 
			ParagraphListStyle.BulletedListHollowStar => "BulletedListHollowStar", 
			_ => throw z0ZzZzwhh.z0rek((long)p0, typeof(ParagraphListStyle)), 
		};
	}

	protected internal void z0rek(string p0, string p1, SubDocumentSettings p2, bool p3, bool p4)
	{
		z0iek = z0eek();
		if (p2 != null)
		{
			if (!p4 && !(p2.GetType() == typeof(SubDocumentSettings)))
			{
				throw z0eek(p2);
			}
			z0eek(p0, p1, p2, p3: false, null);
			if (p4)
			{
				z0eek("SubDocumentSettings");
			}
			if (p2.SubDocumentSpacing != 0f)
			{
				z0rek("SubDocumentSpacing", p2.SubDocumentSpacing);
			}
			if (!p2.AllowSave)
			{
				z0rek("AllowSave", p2.AllowSave);
			}
			if (p2.Readonly)
			{
				z0rek("Readonly", p2.Readonly);
			}
			if (p2.Locked)
			{
				z0rek("Locked", p2.Locked);
			}
			if (p2.EnablePermission)
			{
				z0rek("EnablePermission", p2.EnablePermission);
			}
			if (p2.NewPage)
			{
				z0rek("NewPage", p2.NewPage);
			}
			z0tek("BorderColorValue", p2.BorderColorValue);
			z0tek("BackColorValue", p2.BackColorValue);
			base.z0rek((object?)p2);
		}
	}

	protected internal void z0rek(string p0, Color p1)
	{
		z0tek(p0, z0ZzZzlok.z0eek(p1));
	}

	protected internal void z0rek(string p0, string p1, z0ZzZzbuk p2, bool p3, bool p4)
	{
		z0iek = z0eek();
		if (p2 != null)
		{
			if (!p4 && !(p2.GetType() == typeof(z0ZzZzbuk)))
			{
				throw z0eek(p2);
			}
			z0eek(p0, p1, p2, p3: false, null);
			if (p4)
			{
				z0eek("HyperlinkInfo");
			}
			z0tek("Reference", p2.Reference);
			z0tek("Target", p2.Target);
			z0tek("Title", p2.Title);
			base.z0rek((object?)p2);
		}
	}

	private static void z0eek(z0ZzZzhqh p0, zzz.z0ZzZzkuk<char> p1, int p2, bool p3)
	{
		p0.z0eek("Element");
		p0.z0eek("xsi:type", "XString");
		if (p2 >= 0)
		{
			p0.z0eek("StyleIndex", z0ZzZzqik.z0rek(p2));
		}
		if (p3)
		{
			((z0ZzZzdqh)p0).z0rek("Text", new string(p1.z0krk(), 0, p1.Count));
		}
		else
		{
			p0.z0eek("Text");
			p0.z0eek(z0ZzZzhqh.z0vhj.z0nek);
			p0.z0yek().Write(p1.z0krk(), 0, p1.Count);
			p0.z0bg();
		}
		p0.z0bg();
	}

	private string z0rek(DCBooleanValueHasDefault p0)
	{
		string text = null;
		return p0 switch
		{
			DCBooleanValueHasDefault.True => "True", 
			DCBooleanValueHasDefault.False => "False", 
			DCBooleanValueHasDefault.Default => "Default", 
			_ => throw z0ZzZzwhh.z0rek((long)p0, typeof(DCBooleanValueHasDefault)), 
		};
	}

	private string z0rek(ValueValidateLevel p0)
	{
		string text = null;
		return p0 switch
		{
			ValueValidateLevel.Error => "Error", 
			ValueValidateLevel.Warring => "Warring", 
			ValueValidateLevel.Info => "Info", 
			_ => throw z0ZzZzwhh.z0rek((long)p0, typeof(ValueValidateLevel)), 
		};
	}

	private string z0rek(z0ZzZzgdh p0)
	{
		string text = null;
		return p0 switch
		{
			(z0ZzZzgdh)0 => "Center", 
			(z0ZzZzgdh)1 => "Inset", 
			(z0ZzZzgdh)2 => "Outset", 
			(z0ZzZzgdh)3 => "Left", 
			(z0ZzZzgdh)4 => "Right", 
			_ => throw z0ZzZzwhh.z0rek((long)p0, typeof(z0ZzZzgdh)), 
		};
	}

	protected internal void z0rek(string p0, string p1, XTextLabelElement p2, bool p3, bool p4)
	{
		z0iek = z0eek();
		z0ZzZzhqh z0ZzZzhqh2 = z0eek();
		if (p2 == null)
		{
			return;
		}
		if (!p4 && !(p2.GetType() == typeof(XTextLabelElement)))
		{
			throw z0eek(p2);
		}
		z0eek(p0, p1, p2, p3: false, null);
		if (p4)
		{
			z0eek("XTextLabelElement");
		}
		if (((XTextElement)p2).z0pek() != -1)
		{
			z0ZzZzhqh2.z0eek("StyleIndex", ((XTextElement)p2).z0pek());
		}
		z0rek(z0ZzZzhqh2, p2.Attributes);
		z0tek("ID", p2.ID);
		z0tek("ToolTip", p2.ToolTip);
		if (p2.OffsetX != 0f)
		{
			z0rek("OffsetX", p2.OffsetX);
		}
		if (p2.OffsetY != 0f)
		{
			z0rek("OffsetY", p2.OffsetY);
		}
		if (p2.ZOrderStyle != ElementZOrderStyle.Normal)
		{
			z0ZzZzhqh2.z0eek("ZOrderStyle", null, z0rek(p2.ZOrderStyle));
		}
		z0rek(z0ZzZzhqh2, p2.PropertyExpressions);
		z0tek("ValueExpression", p2.ValueExpression);
		if (!p2.Visible)
		{
			z0rek("Visible", p2.Visible);
		}
		if (p2.PrintVisibility != ElementVisibility.Visible)
		{
			z0ZzZzhqh2.z0eek("PrintVisibility", null, z0rek(p2.PrintVisibility));
		}
		z0rek("LinkInfo", string.Empty, p2.z0iek(), p3: false, p4: false);
		if (p2.ContentReadonly != ContentReadonlyState.Inherit)
		{
			z0ZzZzhqh2.z0eek("ContentReadonly", null, z0rek(p2.ContentReadonly));
		}
		if (!p2.Deleteable)
		{
			z0rek("Deleteable", p2.Deleteable);
		}
		z0tek("Name", p2.Name);
		if (!p2.Enabled)
		{
			z0rek("Enabled", p2.Enabled);
		}
		z0tek("StringTag", p2.StringTag);
		z0rek("ValueBinding", string.Empty, p2.ValueBinding, p3: false, p4: false);
		z0rek("Width", p2.Width);
		z0rek("Height", p2.Height);
		z0tek("Text", p2.Text);
		PageLabelTextList pageTexts = p2.PageTexts;
		if (pageTexts != null && pageTexts.Count > 0)
		{
			int count = pageTexts.Count;
			z0ZzZzhqh2.z0hf(null, "PageTexts", null);
			for (int i = 0; i < count; i++)
			{
				z0rek("PageText", string.Empty, pageTexts[i], p3: true, p4: false);
			}
			z0ZzZzhqh2.z0bg();
		}
		if (p2.StrictMatchPageIndex)
		{
			z0rek("StrictMatchPageIndex", p2.StrictMatchPageIndex);
		}
		if (p2.AllowUserEditCurrentPageLabelText)
		{
			z0rek("AllowUserEditCurrentPageLabelText", p2.AllowUserEditCurrentPageLabelText);
		}
		if (p2.z0rek() != -1)
		{
			z0rek("ReferencedTopicID", p2.z0rek());
		}
		if (p2.ContactAction != LabelTextContactActionMode.Disable)
		{
			z0ZzZzhqh2.z0eek("ContactAction", null, z0rek(p2.ContactAction));
		}
		z0tek("AttributeNameForContactAction", p2.AttributeNameForContactAction);
		z0tek("LinkTextForContactAction", p2.LinkTextForContactAction);
		if (p2.Alignment != DCContentAlignment.MiddleCenter)
		{
			z0ZzZzhqh2.z0eek("Alignment", null, z0rek(p2.Alignment));
		}
		if (!p2.Multiline)
		{
			z0rek("Multiline", p2.Multiline);
		}
		if (!p2.AutoSize)
		{
			z0rek("AutoSize", p2.AutoSize);
		}
		base.z0rek((object?)p2);
	}

	protected internal void z0rek(string p0, string p1, z0ZzZzilh p2, bool p3, bool p4)
	{
		z0iek = z0eek();
		z0ZzZzhqh z0ZzZzhqh2 = z0eek();
		if (p2 != null)
		{
			if (!p4 && !(p2.GetType() == typeof(z0ZzZzilh)))
			{
				throw z0eek(p2);
			}
			z0eek(p0, p1, p2, p3: false, null);
			if (p4)
			{
				z0eek("XBean");
			}
			if (p2.z0pek() != -1)
			{
				z0ZzZzhqh2.z0eek("StyleIndex", p2.z0pek());
			}
			z0rek(z0ZzZzhqh2, p2.Attributes);
			z0tek("ID", p2.ID);
			z0tek("LimitedInputChars", p2.LimitedInputChars);
			if (p2.HiddenPrintWhenEmpty)
			{
				z0rek("HiddenPrintWhenEmpty", p2.HiddenPrintWhenEmpty);
			}
			if (p2.MaxInputLength != 0)
			{
				z0rek("MaxInputLength", p2.MaxInputLength);
			}
			z0tek("DataName", p2.z0ht());
			if (p2.z0gt())
			{
				z0rek("CanBeReferenced", p2.z0gt());
			}
			if (p2.z0dt())
			{
				z0rek("BringoutToSave", p2.z0dt());
			}
			z0tek("ToolTip", p2.ToolTip);
			if (p2.AcceptTab)
			{
				z0rek("AcceptTab", p2.AcceptTab);
			}
			z0rek(z0ZzZzhqh2, p2.PropertyExpressions);
			if (p2.EnableValueValidate)
			{
				z0rek("EnableValueValidate", p2.EnableValueValidate);
			}
			z0rek("ValidateStyle", string.Empty, p2.ValidateStyle, p3: false, p4: false);
			z0rek("ValueBinding", string.Empty, p2.ValueBinding, p3: false, p4: false);
			z0tek("DefaultValueForValueBinding", p2.z0nrk());
			z0tek("ContentReadonlyExpression", p2.ContentReadonlyExpression);
			z0tek("VisibleExpression", p2.VisibleExpression);
			z0tek("PrintVisibilityExpression", p2.PrintVisibilityExpression);
			z0tek("ValueExpression", p2.ValueExpression);
			if (p2.EnablePermission != DCBooleanValue.Inherit)
			{
				z0ZzZzhqh2.z0eek("EnablePermission", null, z0rek(p2.EnablePermission));
			}
			z0rek("ContentLock", string.Empty, p2.ContentLock, p3: false, p4: false);
			if (p2.ContentReadonly != ContentReadonlyState.Inherit)
			{
				z0ZzZzhqh2.z0eek("ContentReadonly", null, z0rek(p2.ContentReadonly));
			}
			z0rek("CopySource", string.Empty, p2.CopySource, p3: false, p4: false);
			if (p2.AcceptChildElementTypes2 != ElementType.All)
			{
				z0rek("AcceptChildElementTypes2", string.Empty, z0rek(p2.AcceptChildElementTypes2));
			}
			if (p2.PrintVisibility != ElementVisibility.Visible)
			{
				z0ZzZzhqh2.z0eek("PrintVisibility", null, z0rek(p2.PrintVisibility));
			}
			if (!p2.Visible)
			{
				z0rek("Visible", p2.Visible);
			}
			if (!p2.Deleteable)
			{
				z0rek("Deleteable", p2.Deleteable);
			}
			if (p2.EndingLineBreak)
			{
				z0rek("EndingLineBreak", p2.EndingLineBreak);
			}
			z0tek("StartBorderText", p2.StartBorderText);
			z0tek("EndBorderText", p2.EndBorderText);
			z0rek("BorderElementColor", p2.BorderElementColor);
			z0tek("BorderElementColorValue", p2.BorderElementColorValue);
			z0tek("TextColor", p2.TextColorString);
			if (p2.z0drk() != DCBooleanValueHasDefault.Default)
			{
				z0ZzZzhqh2.z0eek("BackgroundTextItalic", null, z0rek(p2.z0drk()));
			}
			if (p2.LableUnitTextBold != DCBooleanValueHasDefault.Default)
			{
				z0ZzZzhqh2.z0eek("LableUnitTextBold", null, z0rek(p2.LableUnitTextBold));
			}
			z0tek("BackgroundTextColor", p2.BackgroundTextColorString);
			base.z0rek((object?)p2);
		}
	}

	protected internal void z0rek(string p0, string p1, XTextPageBreakElement p2, bool p3, bool p4)
	{
		z0iek = z0eek();
		z0ZzZzhqh z0ZzZzhqh2 = z0eek();
		if (p2 != null)
		{
			if (!p4 && !(p2.GetType() == typeof(XTextPageBreakElement)))
			{
				throw z0eek(p2);
			}
			z0eek(p0, p1, p2, p3: false, null);
			if (p4)
			{
				z0eek("XPageBreak");
			}
			if (p2.z0pek() != -1)
			{
				z0ZzZzhqh2.z0eek("StyleIndex", p2.z0pek());
			}
			z0rek(z0ZzZzhqh2, p2.Attributes);
			z0tek("ID", p2.ID);
			base.z0rek((object?)p2);
		}
	}

	private string z0rek(LineSpacingStyle p0)
	{
		string text = null;
		return p0 switch
		{
			LineSpacingStyle.SpaceSingle => "SpaceSingle", 
			LineSpacingStyle.Space1pt5 => "Space1pt5", 
			LineSpacingStyle.SpaceDouble => "SpaceDouble", 
			LineSpacingStyle.SpaceExactly => "SpaceExactly", 
			LineSpacingStyle.SpaceSpecify => "SpaceSpecify", 
			LineSpacingStyle.SpaceMultiple => "SpaceMultiple", 
			_ => throw z0ZzZzwhh.z0rek((long)p0, typeof(LineSpacingStyle)), 
		};
	}

	protected internal void z0rek(string p0, string p1, z0ZzZzkuj p2, bool p3, bool p4)
	{
		z0iek = z0eek();
		z0ZzZzhqh z0ZzZzhqh2 = z0eek();
		if (p2 == null)
		{
			return;
		}
		if (!p4 && !(p2.GetType() == typeof(z0ZzZzkuj)))
		{
			throw z0eek(p2);
		}
		z0eek(p0, p1, p2, p3: false, null);
		if (p4)
		{
			z0eek("ShapeDocumentImagePage");
		}
		if (((z0ZzZzhuj)p2).z0eek() != -1)
		{
			z0ZzZzhqh2.z0eek("StyleIndex", ((z0ZzZzhuj)p2).z0eek());
		}
		z0rek("LocalStyle", string.Empty, ((z0ZzZzhuj)p2).z0pek(), p3: false, p4: false);
		if (!p2.z0rek_jiejie20260327142557())
		{
			z0rek("Visible", p2.z0rek_jiejie20260327142557());
		}
		z0tek("ID", ((z0ZzZzhuj)p2).z0yek());
		if (((z0ZzZzeuj)p2).z0rek() != 0f)
		{
			z0rek("Left", ((z0ZzZzeuj)p2).z0rek());
		}
		if (p2.z0oek() != 0f)
		{
			z0rek("Top", p2.z0oek());
		}
		if (p2.z0mek() != 100f)
		{
			z0rek("Width", p2.z0mek());
		}
		if (((z0ZzZzeuj)p2).z0eek() != 100f)
		{
			z0rek("Height", ((z0ZzZzeuj)p2).z0eek());
		}
		if (!p2.z0xkk())
		{
			z0rek("Resizeable", p2.z0xkk());
		}
		z0tek("Text", p2.z0pek());
		z0ZzZzguj z0ZzZzguj2 = p2.z0djk();
		if (z0ZzZzguj2 != null && z0ZzZzguj2.Count > 0)
		{
			int count = z0ZzZzguj2.Count;
			z0ZzZzhqh2.z0hf(null, "Elements", null);
			for (int i = 0; i < count; i++)
			{
				z0rek("ShapeElement", string.Empty, z0ZzZzguj2[i], p3: true, p4: false);
			}
			z0ZzZzhqh2.z0bg();
		}
		z0rek("Image", string.Empty, p2.z0eek(), p3: false, p4: false);
		if (!p2.z0rek())
		{
			z0rek("AutoSize", p2.z0rek());
		}
		base.z0rek((object?)p2);
	}

	private string z0rek(PieLabelType p0)
	{
		string text = null;
		return p0 switch
		{
			PieLabelType.InLabel => "InLabel", 
			PieLabelType.OutLabel => "OutLabel", 
			_ => throw z0ZzZzwhh.z0rek((long)p0, typeof(PieLabelType)), 
		};
	}

	private void z0rek(XTextContainerElement p0)
	{
		XTextElementList z0ntk = p0.z0ntk;
		if (z0ntk == null || z0ntk.Count <= 0)
		{
			return;
		}
		z0ZzZzhqh z0ZzZzhqh2 = z0eek();
		z0ZzZzhqh2.z0hf(null, "XElements", null);
		int count = z0ntk.Count;
		XTextElement[] array = ((zzz.z0ZzZzkuk<XTextElement>)z0ntk).z0krk();
		if (p0 is XTextTableRowElement)
		{
			for (int i = 0; i < count; i++)
			{
				if (array[i] is XTextTableCellElement p1)
				{
					z0rek("Element", string.Empty, p1, p3: true, p4: true);
				}
			}
		}
		else if (p0 is XTextTableElement)
		{
			for (int j = 0; j < count; j++)
			{
				if (array[j] is XTextTableRowElement p2)
				{
					z0rek("Element", string.Empty, p2, p3: true, p4: true);
				}
			}
		}
		else
		{
			zzz.z0ZzZzkuk<char> z0ZzZzkuk2;
			if (z0yek.Count > 0)
			{
				z0ZzZzkuk2 = z0yek[z0yek.Count - 1];
				z0yek.RemoveAt(z0yek.Count - 1);
				z0ZzZzkuk2.Clear();
			}
			else
			{
				z0ZzZzkuk2 = new zzz.z0ZzZzkuk<char>();
			}
			bool flag = false;
			int num = -2147483648;
			for (int k = 0; k < count; k++)
			{
				XTextElement xTextElement = array[k];
				if (xTextElement is XTextCharElement)
				{
					if (xTextElement.z0buk != num)
					{
						if (z0ZzZzkuk2.Count > 0)
						{
							z0eek(z0ZzZzhqh2, z0ZzZzkuk2, num, flag);
							z0ZzZzkuk2.Clear();
							flag = false;
						}
						num = xTextElement.z0buk;
					}
					if (!flag && (!z0ZzZzzsh.z0tek(((XTextCharElement)xTextElement).z0bek) || XTextCharElement.z0tek((int)((XTextCharElement)xTextElement).z0bek)))
					{
						flag = true;
					}
					((XTextCharElement)xTextElement).z0eek(z0ZzZzkuk2);
				}
				else
				{
					if (z0ZzZzkuk2.Count > 0)
					{
						z0eek(z0ZzZzhqh2, z0ZzZzkuk2, num, flag);
						z0ZzZzkuk2.Clear();
						flag = false;
					}
					if (k != count - 1 || !(xTextElement is XTextParagraphFlagElement) || !((XTextParagraphFlagElement)xTextElement).z0vek() || xTextElement.z0buk >= 0)
					{
						z0rek("Element", string.Empty, xTextElement, p3: true, p4: false);
					}
				}
			}
			if (z0ZzZzkuk2.Count > 0)
			{
				z0eek(z0ZzZzhqh2, z0ZzZzkuk2, num, flag);
				z0ZzZzkuk2.Clear();
			}
			z0yek.Add(z0ZzZzkuk2);
		}
		z0ZzZzhqh2.z0bg();
	}

	private string z0rek(PrintVisibilityModeWhenUnchecked p0)
	{
		string text = null;
		return p0 switch
		{
			PrintVisibilityModeWhenUnchecked.Visible => "Visible", 
			PrintVisibilityModeWhenUnchecked.HiddenCheckBoxOnly => "HiddenCheckBoxOnly", 
			PrintVisibilityModeWhenUnchecked.HiddenAll => "HiddenAll", 
			_ => throw z0ZzZzwhh.z0rek((long)p0, typeof(PrintVisibilityModeWhenUnchecked)), 
		};
	}

	private string z0rek(DCFastInputMode p0)
	{
		string text = null;
		return p0 switch
		{
			DCFastInputMode.None => "None", 
			DCFastInputMode.NextField => "NextField", 
			DCFastInputMode.BeforeFieldBegin => "BeforeFieldBegin", 
			DCFastInputMode.AfterFieldBegin => "AfterFieldBegin", 
			DCFastInputMode.BeforeFieldEnd => "BeforeFieldEnd", 
			DCFastInputMode.AfterFieldEnd => "AfterFieldEnd", 
			_ => throw z0ZzZzwhh.z0rek((long)p0, typeof(DCFastInputMode)), 
		};
	}

	private string z0rek(MoveFocusHotKeys p0)
	{
		string text = null;
		return p0 switch
		{
			MoveFocusHotKeys.None => "None", 
			MoveFocusHotKeys.Default => "Default", 
			MoveFocusHotKeys.Tab => "Tab", 
			MoveFocusHotKeys.Enter => "Enter", 
			_ => z0ZzZzkhh.z0eek((long)p0, z0ZzZzwhh.z0uek, z0ZzZzwhh.z0yek, "DCSoft.Writer.MoveFocusHotKeys"), 
		};
	}

	protected internal void z0rek(string p0, string p1, z0ZzZzemk p2, bool p3, bool p4)
	{
		z0iek = z0eek();
		z0ZzZzhqh z0ZzZzhqh2 = z0eek();
		if (p2 != null)
		{
			if (!p4 && !(p2.GetType() == typeof(z0ZzZzemk)))
			{
				throw z0eek(p2);
			}
			z0eek(p0, p1, p2, p3: false, null);
			if (p4)
			{
				z0eek("XBrushStyle");
			}
			z0tek("Color", p2.z0vek());
			z0tek("Color2", p2.z0mek());
			if (p2.z0cek() != XBrushStyleConst.Solid)
			{
				z0ZzZzhqh2.z0eek("Style", null, z0rek(p2.z0cek()));
			}
			z0rek("Image", string.Empty, p2.z0oek(), p3: false, p4: false);
			if (!p2.z0yek())
			{
				z0rek("Repeat", p2.z0yek());
			}
			if (p2.z0iek() != 0f)
			{
				z0rek("OffsetX", p2.z0iek());
			}
			if (p2.z0tek() != 0f)
			{
				z0rek("OffsetY", p2.z0tek());
			}
			base.z0rek((object?)p2);
		}
	}

	protected internal void z0rek(string p0, string p1, z0ZzZzzyj p2, bool p3, bool p4)
	{
		z0iek = z0eek();
		z0ZzZzhqh z0ZzZzhqh2 = z0eek();
		if (p2 == null)
		{
			return;
		}
		if (!p4 && !(p2.GetType() == typeof(z0ZzZzzyj)))
		{
			throw z0eek(p2);
		}
		z0eek(p0, p1, p2, p3: false, null);
		if (p4)
		{
			z0eek("ShapeContentStyleContainer");
		}
		z0rek("Default", string.Empty, p2.Default, p3: false, p4: false);
		z0ZzZzzok styles = p2.Styles;
		if (styles != null && styles.Count > 0)
		{
			int count = styles.Count;
			z0ZzZzhqh2.z0hf(null, "Styles", null);
			for (int i = 0; i < count; i++)
			{
				z0rek("Style", string.Empty, styles[i], p3: true, p4: false);
			}
			z0ZzZzhqh2.z0bg();
		}
		base.z0rek((object?)p2);
	}

	protected internal void z0rek(string p0, string p1, ListItem p2, bool p3, bool p4)
	{
		z0iek = z0eek();
		if (p2 != null)
		{
			if (!p4 && !(p2.GetType() == typeof(ListItem)))
			{
				throw z0eek(p2);
			}
			z0eek(p0, p1, p2, p3: false, null);
			if (p4)
			{
				z0eek("ListItem");
			}
			z0tek("ID", p2.z0uek());
			z0tek("EntryID", p2.EntryID);
			if (p2.LonelyChecked)
			{
				z0rek("LonelyChecked", p2.LonelyChecked);
			}
			z0tek("TextInList", p2.TextInList);
			z0tek("Text", p2.Text);
			z0tek("Value", p2.Value);
			z0tek("Group", p2.Group);
			if (p2.CheckedTime.Ticks != 624511296000000000L)
			{
				z0rek("CheckedTime", z0ZzZzkhh.z0eek(p2.CheckedTime));
			}
			z0tek("Tag", p2.Tag);
			if (p2.ListIndex != 0)
			{
				z0rek("ListIndex", p2.ListIndex);
			}
			base.z0rek((object?)p2);
		}
	}

	protected internal void z0rek(string p0, string p1, XTextParagraphFlagElement p2, bool p3, bool p4)
	{
		z0iek = z0eek();
		z0ZzZzhqh z0ZzZzhqh2 = z0eek();
		if (p2 != null)
		{
			if (!p4 && !(p2.GetType() == typeof(XTextParagraphFlagElement)))
			{
				throw z0eek(p2);
			}
			z0eek(p0, p1, p2, p3: false, null);
			if (p4)
			{
				z0eek("XParagraphFlag");
			}
			if (((XTextElement)p2).z0pek() != -1)
			{
				z0ZzZzhqh2.z0eek("StyleIndex", ((XTextElement)p2).z0pek());
			}
			z0rek(z0ZzZzhqh2, p2.Attributes);
			z0tek("ID", p2.ID);
			if (p2.z0krk() != -1)
			{
				z0rek("TopicID", p2.z0krk());
			}
			if (p2.z0jrk())
			{
				z0rek("ResetListIndexFlag", p2.z0jrk());
			}
			if (p2.z0vek())
			{
				z0rek("AutoCreate", p2.z0vek());
			}
			base.z0rek((object?)p2);
		}
	}

	private string z0rek(FormButtonStyle p0)
	{
		string text = null;
		return p0 switch
		{
			FormButtonStyle.None => "None", 
			FormButtonStyle.Auto => "Auto", 
			FormButtonStyle.Button => "Button", 
			FormButtonStyle.FloatButton => "FloatButton", 
			FormButtonStyle.ComboBoxButton => "ComboBoxButton", 
			FormButtonStyle.DateTimePicker => "DateTimePicker", 
			_ => throw z0ZzZzwhh.z0rek((long)p0, typeof(FormButtonStyle)), 
		};
	}

	protected internal void z0rek(string p0, string p1, z0ZzZzuuj p2, bool p3, bool p4)
	{
		z0iek = z0eek();
		z0ZzZzhqh z0ZzZzhqh2 = z0eek();
		if (p2 != null)
		{
			if (!p4 && !(p2.GetType() == typeof(z0ZzZzuuj)))
			{
				throw z0eek(p2);
			}
			z0eek(p0, p1, p2, p3: false, null);
			if (p4)
			{
				z0eek("ShapeWireLabelElement");
			}
			if (((z0ZzZzhuj)p2).z0eek() != -1)
			{
				z0ZzZzhqh2.z0eek("StyleIndex", ((z0ZzZzhuj)p2).z0eek());
			}
			z0rek("LocalStyle", string.Empty, p2.z0pek(), p3: false, p4: false);
			if (!p2.z0rek_jiejie20260327142557())
			{
				z0rek("Visible", p2.z0rek_jiejie20260327142557());
			}
			z0tek("ID", ((z0ZzZzhuj)p2).z0yek());
			if (((z0ZzZzauj)p2).z0eek() != 0f)
			{
				z0rek("X1", ((z0ZzZzauj)p2).z0eek());
			}
			if (((z0ZzZzauj)p2).z0uek() != 0f)
			{
				z0rek("Y1", ((z0ZzZzauj)p2).z0uek());
			}
			if (((z0ZzZzauj)p2).z0yek() != 0f)
			{
				z0rek("X2", ((z0ZzZzauj)p2).z0yek());
			}
			if (((z0ZzZzauj)p2).z0rek() != 0f)
			{
				z0rek("Y2", ((z0ZzZzauj)p2).z0rek());
			}
			if (p2.z0uek())
			{
				z0rek("LabelAtLeft", p2.z0uek());
			}
			if (p2.z0yek())
			{
				z0rek("LabelAtUp", p2.z0yek());
			}
			z0tek("Text", p2.z0rek());
			base.z0rek((object?)p2);
		}
	}

	protected internal void z0rek(string p0, string p1, z0ZzZzykh p2, bool p3, bool p4)
	{
		z0iek = z0eek();
		z0ZzZzhqh z0ZzZzhqh2 = z0eek();
		if (p2 != null)
		{
			if (!p4 && !(p2.GetType() == typeof(z0ZzZzykh)))
			{
				throw z0eek(p2);
			}
			z0eek(p0, p1, p2, p3: false, null);
			if (p4)
			{
				z0eek("EventExpressionInfo");
			}
			if (p2.z0iek() != "ContentChanged")
			{
				z0tek("EventName", p2.z0iek());
			}
			z0tek("Expression", p2.z0yek());
			if (p2.z0rek() != 0)
			{
				z0ZzZzhqh2.z0eek("Target", null, z0rek(p2.z0rek()));
			}
			z0tek("CustomTargetName", p2.z0tek());
			if (p2.z0uek() != "VISIBLE")
			{
				z0tek("TargetPropertyName", p2.z0uek());
			}
			base.z0rek((object?)p2);
		}
	}

	private string z0rek(RenderVisibility p0)
	{
		string text = null;
		return p0 switch
		{
			RenderVisibility.Hidden => "Hidden", 
			RenderVisibility.Paint => "Paint", 
			RenderVisibility.Print => "Print", 
			RenderVisibility.PDF => "PDF", 
			RenderVisibility.All => "All", 
			_ => z0ZzZzkhh.z0eek((long)p0, z0ZzZzwhh.z0vek, z0ZzZzwhh.z0nek, "DCSoft.Drawing.RenderVisibility"), 
		};
	}

	protected internal void z0rek(string p0, string p1, XTextTableElement p2, bool p3, bool p4)
	{
		z0iek = z0eek();
		z0ZzZzhqh z0ZzZzhqh2 = z0eek();
		if (p2 == null)
		{
			return;
		}
		if (!p4 && !(p2.GetType() == typeof(XTextTableElement)))
		{
			throw z0eek(p2);
		}
		z0eek(p0, p1, p2, p3: false, null);
		if (p4)
		{
			z0eek("XTextTable");
		}
		if (((XTextElement)p2).z0pek() != -1)
		{
			z0ZzZzhqh2.z0eek("StyleIndex", ((XTextElement)p2).z0pek());
		}
		if (p2.z0bek() != 0)
		{
			z0ZzZzhqh2.z0eek("NumOfRows", p2.z0bek());
		}
		if (p2.z0ark() != 0)
		{
			z0ZzZzhqh2.z0eek("NumOfColumns", p2.z0ark());
		}
		z0rek(z0ZzZzhqh2, p2.Attributes);
		z0tek("ID", p2.ID);
		z0tek("LimitedInputChars", p2.LimitedInputChars);
		if (p2.HiddenPrintWhenEmpty)
		{
			z0rek("HiddenPrintWhenEmpty", p2.HiddenPrintWhenEmpty);
		}
		if (p2.MaxInputLength != 0)
		{
			z0rek("MaxInputLength", p2.MaxInputLength);
		}
		z0tek("DataName", p2.z0ht());
		if (p2.z0gt())
		{
			z0rek("CanBeReferenced", p2.z0gt());
		}
		if (p2.z0dt())
		{
			z0rek("BringoutToSave", p2.z0dt());
		}
		z0tek("ToolTip", p2.ToolTip);
		if (p2.AcceptTab)
		{
			z0rek("AcceptTab", p2.AcceptTab);
		}
		z0rek(z0ZzZzhqh2, p2.PropertyExpressions);
		if (p2.EnableValueValidate)
		{
			z0rek("EnableValueValidate", p2.EnableValueValidate);
		}
		z0rek("ValidateStyle", string.Empty, p2.ValidateStyle, p3: false, p4: false);
		z0rek("ValueBinding", string.Empty, p2.ValueBinding, p3: false, p4: false);
		z0tek("DefaultValueForValueBinding", ((XTextContainerElement)p2).z0nrk());
		z0tek("ContentReadonlyExpression", p2.ContentReadonlyExpression);
		z0tek("VisibleExpression", p2.VisibleExpression);
		z0tek("PrintVisibilityExpression", p2.PrintVisibilityExpression);
		z0tek("ValueExpression", p2.ValueExpression);
		if (p2.EnablePermission != DCBooleanValue.Inherit)
		{
			z0ZzZzhqh2.z0eek("EnablePermission", null, z0rek(p2.EnablePermission));
		}
		z0rek("ContentLock", string.Empty, p2.ContentLock, p3: false, p4: false);
		if (p2.ContentReadonly != ContentReadonlyState.Inherit)
		{
			z0ZzZzhqh2.z0eek("ContentReadonly", null, z0rek(p2.ContentReadonly));
		}
		z0rek("CopySource", string.Empty, p2.CopySource, p3: false, p4: false);
		z0rek(p2);
		if (p2.PrintVisibility != ElementVisibility.Visible)
		{
			z0ZzZzhqh2.z0eek("PrintVisibility", null, z0rek(p2.PrintVisibility));
		}
		if (!p2.Visible)
		{
			z0rek("Visible", p2.Visible);
		}
		if (!p2.Deleteable)
		{
			z0rek("Deleteable", p2.Deleteable);
		}
		if (p2.z0mrk())
		{
			z0rek("AllowReBindingDataSource", p2.z0mrk());
		}
		if (p2.z0frk() != DCTableAlignment.Default)
		{
			z0ZzZzhqh2.z0eek("Alignment", null, z0rek(p2.z0frk()));
		}
		if (p2.CompressOwnerLineSpacing)
		{
			z0rek("CompressOwnerLineSpacing", p2.CompressOwnerLineSpacing);
		}
		if (!p2.z0mek())
		{
			z0rek("HoldWholeLine", p2.z0mek());
		}
		if (p2.PrintBothBorderWhenJumpPrint)
		{
			z0rek("PrintBothBorderWhenJumpPrint", p2.PrintBothBorderWhenJumpPrint);
		}
		if (!p2.AllowUserDeleteRow)
		{
			z0rek("AllowUserDeleteRow", p2.AllowUserDeleteRow);
		}
		if (!p2.AllowUserInsertRow)
		{
			z0rek("AllowUserInsertRow", p2.AllowUserInsertRow);
		}
		if (p2.z0xrk())
		{
			z0rek("AllowUserToResizeEvenInFormViewMode", p2.z0xrk());
		}
		if (!p2.AllowUserToResizeColumns)
		{
			z0rek("AllowUserToResizeColumns", p2.AllowUserToResizeColumns);
		}
		if (!p2.AllowUserToResizeRows)
		{
			z0rek("AllowUserToResizeRows", p2.AllowUserToResizeRows);
		}
		if (p2.z0dtk() != DCBooleanValue.Inherit)
		{
			z0ZzZzhqh2.z0eek("ShowCellNoneBorder", null, z0rek(p2.z0dtk()));
		}
		if (p2.z0qtk() != 0f)
		{
			z0rek("LeftIndent", p2.z0qtk());
		}
		XTextElementList xTextElementList = p2.z0srk();
		if (xTextElementList != null && xTextElementList.Count > 0)
		{
			int count = xTextElementList.Count;
			z0ZzZzhqh2.z0hf(null, "Columns", null);
			for (int i = 0; i < count; i++)
			{
				z0rek("Element", string.Empty, xTextElementList[i], p3: true, p4: false);
			}
			z0ZzZzhqh2.z0bg();
		}
		if (p2.z0hrk() != TableSubfieldMode.None)
		{
			z0ZzZzhqh2.z0eek("SubfieldMode", null, z0rek(p2.z0hrk()));
		}
		if (p2.z0prk() != 1)
		{
			z0rek("SubfieldNumber", p2.z0prk());
		}
		base.z0rek((object?)p2);
	}

	protected internal void z0rek(string p0, string p1, XTextDirectoryFieldElement p2, bool p3, bool p4)
	{
		z0iek = z0eek();
		z0ZzZzhqh z0ZzZzhqh2 = z0eek();
		if (p2 == null)
		{
			return;
		}
		if (!p4 && !(p2.GetType() == typeof(XTextDirectoryFieldElement)))
		{
			throw z0eek(p2);
		}
		z0eek(p0, p1, p2, p3: false, null);
		if (p4)
		{
			z0eek("XDirectoryField");
		}
		if (((XTextElement)p2).z0pek() != -1)
		{
			z0ZzZzhqh2.z0eek("StyleIndex", ((XTextElement)p2).z0pek());
		}
		z0rek(z0ZzZzhqh2, p2.Attributes);
		z0tek("ID", p2.ID);
		z0tek("LimitedInputChars", p2.LimitedInputChars);
		if (p2.HiddenPrintWhenEmpty)
		{
			z0rek("HiddenPrintWhenEmpty", p2.HiddenPrintWhenEmpty);
		}
		if (p2.MaxInputLength != 0)
		{
			z0rek("MaxInputLength", p2.MaxInputLength);
		}
		z0tek("DataName", p2.z0ht());
		if (p2.z0gt())
		{
			z0rek("CanBeReferenced", p2.z0gt());
		}
		if (p2.z0dt())
		{
			z0rek("BringoutToSave", p2.z0dt());
		}
		z0tek("ToolTip", p2.ToolTip);
		if (p2.AcceptTab)
		{
			z0rek("AcceptTab", p2.AcceptTab);
		}
		z0rek(z0ZzZzhqh2, p2.PropertyExpressions);
		if (p2.EnableValueValidate)
		{
			z0rek("EnableValueValidate", p2.EnableValueValidate);
		}
		z0rek("ValidateStyle", string.Empty, p2.ValidateStyle, p3: false, p4: false);
		z0rek("ValueBinding", string.Empty, p2.ValueBinding, p3: false, p4: false);
		z0tek("DefaultValueForValueBinding", p2.z0nrk());
		z0tek("ContentReadonlyExpression", p2.ContentReadonlyExpression);
		z0tek("VisibleExpression", p2.VisibleExpression);
		z0tek("PrintVisibilityExpression", p2.PrintVisibilityExpression);
		z0tek("ValueExpression", p2.ValueExpression);
		if (p2.EnablePermission != DCBooleanValue.Inherit)
		{
			z0ZzZzhqh2.z0eek("EnablePermission", null, z0rek(p2.EnablePermission));
		}
		z0rek("ContentLock", string.Empty, p2.ContentLock, p3: false, p4: false);
		if (p2.ContentReadonly != ContentReadonlyState.Inherit)
		{
			z0ZzZzhqh2.z0eek("ContentReadonly", null, z0rek(p2.ContentReadonly));
		}
		z0rek("CopySource", string.Empty, p2.CopySource, p3: false, p4: false);
		z0rek(p2);
		if (p2.AcceptChildElementTypes2 != ElementType.All)
		{
			z0rek("AcceptChildElementTypes2", string.Empty, z0rek(p2.AcceptChildElementTypes2));
		}
		if (p2.PrintVisibility != ElementVisibility.Visible)
		{
			z0ZzZzhqh2.z0eek("PrintVisibility", null, z0rek(p2.PrintVisibility));
		}
		if (!p2.Visible)
		{
			z0rek("Visible", p2.Visible);
		}
		if (!p2.Deleteable)
		{
			z0rek("Deleteable", p2.Deleteable);
		}
		if (p2.EndingLineBreak)
		{
			z0rek("EndingLineBreak", p2.EndingLineBreak);
		}
		z0tek("StartBorderText", p2.StartBorderText);
		z0tek("EndBorderText", p2.EndBorderText);
		z0rek("BorderElementColor", p2.BorderElementColor);
		z0tek("BorderElementColorValue", p2.BorderElementColorValue);
		z0tek("TextColor", p2.TextColorString);
		if (((XTextFieldElementBase)p2).z0drk() != DCBooleanValueHasDefault.Default)
		{
			z0ZzZzhqh2.z0eek("BackgroundTextItalic", null, z0rek(((XTextFieldElementBase)p2).z0drk()));
		}
		if (p2.LableUnitTextBold != DCBooleanValueHasDefault.Default)
		{
			z0ZzZzhqh2.z0eek("LableUnitTextBold", null, z0rek(p2.LableUnitTextBold));
		}
		z0tek("BackgroundTextColor", p2.BackgroundTextColorString);
		if (p2.z0oek() != (z0ZzZzscj)1)
		{
			z0ZzZzhqh2.z0eek("BorderTextPosition", null, z0rek(p2.z0oek()));
		}
		if (((XTextInputFieldElementBase)p2).z0rek() != DCFastInputMode.NextField)
		{
			z0ZzZzhqh2.z0eek("FastInputMode", null, z0rek(((XTextInputFieldElementBase)p2).z0rek()));
		}
		if (!p2.TabStop)
		{
			z0rek("TabStop", p2.TabStop);
		}
		if (p2.MoveFocusHotKey != MoveFocusHotKeys.Default)
		{
			z0rek("MoveFocusHotKey", string.Empty, z0rek(p2.MoveFocusHotKey));
		}
		if (p2.TabIndex != 0)
		{
			z0rek("TabIndex", p2.TabIndex);
		}
		if (p2.SpecifyWidth != 0f)
		{
			z0rek("SpecifyWidth", p2.SpecifyWidth);
		}
		if (p2.Alignment != StringAlignment.Near)
		{
			z0ZzZzhqh2.z0eek("Alignment", null, z0rek(p2.Alignment));
		}
		if (p2.z0pek())
		{
			z0rek("AutoFixFontSize", p2.z0pek());
		}
		z0tek("DefaultEventExpression", p2.DefaultEventExpression);
		z0ZzZzukh eventExpressions = p2.EventExpressions;
		if (eventExpressions != null && eventExpressions.Count > 0)
		{
			int count = eventExpressions.Count;
			z0ZzZzhqh2.z0hf(null, "EventExpressions", null);
			for (int i = 0; i < count; i++)
			{
				z0rek("Expression", string.Empty, eventExpressions[i], p3: true, p4: false);
			}
			z0ZzZzhqh2.z0bg();
		}
		z0tek("UnitText", p2.UnitText);
		z0tek("LabelText", p2.LabelText);
		if (!p2.UserEditable)
		{
			z0rek("UserEditable", p2.UserEditable);
		}
		z0tek("Name", p2.Name);
		z0rek("DisplayFormat", string.Empty, p2.DisplayFormat, p3: false, p4: false);
		z0tek("InnerValue", p2.InnerValue);
		if (p2.z0cek() != DCBooleanValue.Inherit)
		{
			z0ZzZzhqh2.z0eek("PrintBackgroundText", null, z0rek(p2.z0cek()));
		}
		z0tek("BackgroundText", p2.BackgroundText);
		if (p2.ViewEncryptType != ContentViewEncryptType.None)
		{
			z0ZzZzhqh2.z0eek("ViewEncryptType", null, z0rek(p2.ViewEncryptType));
		}
		if (p2.BorderVisible != DCVisibleState.Default)
		{
			z0ZzZzhqh2.z0eek("BorderVisible", null, z0rek(p2.BorderVisible));
		}
		if (p2.EnableHighlight != EnableState.Enabled)
		{
			z0ZzZzhqh2.z0eek("EnableHighlight", null, z0rek(p2.EnableHighlight));
		}
		if (p2.DisplayLevel != 3)
		{
			z0rek("DisplayLevel", p2.DisplayLevel);
		}
		if (!p2.ShowPageIndex)
		{
			z0rek("ShowPageIndex", p2.ShowPageIndex);
		}
		base.z0rek((object?)p2);
	}

	private string z0rek(ElementVisibility p0)
	{
		string text = null;
		return p0 switch
		{
			ElementVisibility.Visible => "Visible", 
			ElementVisibility.Hidden => "Hidden", 
			ElementVisibility.None => "None", 
			_ => "Visible", 
		};
	}

	private string z0rek(PaperKind p0)
	{
		string text = null;
		return p0 switch
		{
			PaperKind.Custom => "Custom", 
			PaperKind.Letter => "Letter", 
			PaperKind.Legal => "Legal", 
			PaperKind.A4 => "A4", 
			PaperKind.CSheet => "CSheet", 
			PaperKind.DSheet => "DSheet", 
			PaperKind.ESheet => "ESheet", 
			PaperKind.LetterSmall => "LetterSmall", 
			PaperKind.Tabloid => "Tabloid", 
			PaperKind.Ledger => "Ledger", 
			PaperKind.Statement => "Statement", 
			PaperKind.Executive => "Executive", 
			PaperKind.A3 => "A3", 
			PaperKind.A4Small => "A4Small", 
			PaperKind.A5 => "A5", 
			PaperKind.B4 => "B4", 
			PaperKind.B5 => "B5", 
			PaperKind.Folio => "Folio", 
			PaperKind.Quarto => "Quarto", 
			PaperKind.Standard10x14 => "Standard10x14", 
			PaperKind.Standard11x17 => "Standard11x17", 
			PaperKind.Note => "Note", 
			PaperKind.Number9Envelope => "Number9Envelope", 
			PaperKind.Number10Envelope => "Number10Envelope", 
			PaperKind.Number11Envelope => "Number11Envelope", 
			PaperKind.Number12Envelope => "Number12Envelope", 
			PaperKind.Number14Envelope => "Number14Envelope", 
			PaperKind.DLEnvelope => "DLEnvelope", 
			PaperKind.C5Envelope => "C5Envelope", 
			PaperKind.C3Envelope => "C3Envelope", 
			PaperKind.C4Envelope => "C4Envelope", 
			PaperKind.C6Envelope => "C6Envelope", 
			PaperKind.C65Envelope => "C65Envelope", 
			PaperKind.B4Envelope => "B4Envelope", 
			PaperKind.B5Envelope => "B5Envelope", 
			PaperKind.B6Envelope => "B6Envelope", 
			PaperKind.ItalyEnvelope => "ItalyEnvelope", 
			PaperKind.MonarchEnvelope => "MonarchEnvelope", 
			PaperKind.PersonalEnvelope => "PersonalEnvelope", 
			PaperKind.USStandardFanfold => "USStandardFanfold", 
			PaperKind.GermanStandardFanfold => "GermanStandardFanfold", 
			PaperKind.GermanLegalFanfold => "GermanLegalFanfold", 
			PaperKind.IsoB4 => "IsoB4", 
			PaperKind.JapanesePostcard => "JapanesePostcard", 
			PaperKind.Standard9x11 => "Standard9x11", 
			PaperKind.Standard10x11 => "Standard10x11", 
			PaperKind.Standard15x11 => "Standard15x11", 
			PaperKind.InviteEnvelope => "InviteEnvelope", 
			PaperKind.LetterExtra => "LetterExtra", 
			PaperKind.LegalExtra => "LegalExtra", 
			PaperKind.TabloidExtra => "TabloidExtra", 
			PaperKind.A4Extra => "A4Extra", 
			PaperKind.LetterTransverse => "LetterTransverse", 
			PaperKind.A4Transverse => "A4Transverse", 
			PaperKind.LetterExtraTransverse => "LetterExtraTransverse", 
			PaperKind.APlus => "APlus", 
			PaperKind.BPlus => "BPlus", 
			PaperKind.LetterPlus => "LetterPlus", 
			PaperKind.A4Plus => "A4Plus", 
			PaperKind.A5Transverse => "A5Transverse", 
			PaperKind.B5Transverse => "B5Transverse", 
			PaperKind.A3Extra => "A3Extra", 
			PaperKind.A5Extra => "A5Extra", 
			PaperKind.B5Extra => "B5Extra", 
			PaperKind.A2 => "A2", 
			PaperKind.A3Transverse => "A3Transverse", 
			PaperKind.A3ExtraTransverse => "A3ExtraTransverse", 
			PaperKind.JapaneseDoublePostcard => "JapaneseDoublePostcard", 
			PaperKind.A6 => "A6", 
			PaperKind.JapaneseEnvelopeKakuNumber2 => "JapaneseEnvelopeKakuNumber2", 
			PaperKind.JapaneseEnvelopeKakuNumber3 => "JapaneseEnvelopeKakuNumber3", 
			PaperKind.JapaneseEnvelopeChouNumber3 => "JapaneseEnvelopeChouNumber3", 
			PaperKind.JapaneseEnvelopeChouNumber4 => "JapaneseEnvelopeChouNumber4", 
			PaperKind.LetterRotated => "LetterRotated", 
			PaperKind.A3Rotated => "A3Rotated", 
			PaperKind.A4Rotated => "A4Rotated", 
			PaperKind.A5Rotated => "A5Rotated", 
			PaperKind.B4JisRotated => "B4JisRotated", 
			PaperKind.B5JisRotated => "B5JisRotated", 
			PaperKind.JapanesePostcardRotated => "JapanesePostcardRotated", 
			PaperKind.JapaneseDoublePostcardRotated => "JapaneseDoublePostcardRotated", 
			PaperKind.A6Rotated => "A6Rotated", 
			PaperKind.JapaneseEnvelopeKakuNumber2Rotated => "JapaneseEnvelopeKakuNumber2Rotated", 
			PaperKind.JapaneseEnvelopeKakuNumber3Rotated => "JapaneseEnvelopeKakuNumber3Rotated", 
			PaperKind.JapaneseEnvelopeChouNumber3Rotated => "JapaneseEnvelopeChouNumber3Rotated", 
			PaperKind.JapaneseEnvelopeChouNumber4Rotated => "JapaneseEnvelopeChouNumber4Rotated", 
			PaperKind.B6Jis => "B6Jis", 
			PaperKind.B6JisRotated => "B6JisRotated", 
			PaperKind.Standard12x11 => "Standard12x11", 
			PaperKind.JapaneseEnvelopeYouNumber4 => "JapaneseEnvelopeYouNumber4", 
			PaperKind.JapaneseEnvelopeYouNumber4Rotated => "JapaneseEnvelopeYouNumber4Rotated", 
			PaperKind.Prc16K => "Prc16K", 
			PaperKind.Prc32K => "Prc32K", 
			PaperKind.Prc32KBig => "Prc32KBig", 
			PaperKind.PrcEnvelopeNumber1 => "PrcEnvelopeNumber1", 
			PaperKind.PrcEnvelopeNumber2 => "PrcEnvelopeNumber2", 
			PaperKind.PrcEnvelopeNumber3 => "PrcEnvelopeNumber3", 
			PaperKind.PrcEnvelopeNumber4 => "PrcEnvelopeNumber4", 
			PaperKind.PrcEnvelopeNumber5 => "PrcEnvelopeNumber5", 
			PaperKind.PrcEnvelopeNumber6 => "PrcEnvelopeNumber6", 
			PaperKind.PrcEnvelopeNumber7 => "PrcEnvelopeNumber7", 
			PaperKind.PrcEnvelopeNumber8 => "PrcEnvelopeNumber8", 
			PaperKind.PrcEnvelopeNumber9 => "PrcEnvelopeNumber9", 
			PaperKind.PrcEnvelopeNumber10 => "PrcEnvelopeNumber10", 
			PaperKind.Prc16KRotated => "Prc16KRotated", 
			PaperKind.Prc32KRotated => "Prc32KRotated", 
			PaperKind.Prc32KBigRotated => "Prc32KBigRotated", 
			PaperKind.PrcEnvelopeNumber1Rotated => "PrcEnvelopeNumber1Rotated", 
			PaperKind.PrcEnvelopeNumber2Rotated => "PrcEnvelopeNumber2Rotated", 
			PaperKind.PrcEnvelopeNumber3Rotated => "PrcEnvelopeNumber3Rotated", 
			PaperKind.PrcEnvelopeNumber4Rotated => "PrcEnvelopeNumber4Rotated", 
			PaperKind.PrcEnvelopeNumber5Rotated => "PrcEnvelopeNumber5Rotated", 
			PaperKind.PrcEnvelopeNumber6Rotated => "PrcEnvelopeNumber6Rotated", 
			PaperKind.PrcEnvelopeNumber7Rotated => "PrcEnvelopeNumber7Rotated", 
			PaperKind.PrcEnvelopeNumber8Rotated => "PrcEnvelopeNumber8Rotated", 
			PaperKind.PrcEnvelopeNumber9Rotated => "PrcEnvelopeNumber9Rotated", 
			PaperKind.PrcEnvelopeNumber10Rotated => "PrcEnvelopeNumber10Rotated", 
			_ => throw z0ZzZzwhh.z0rek((long)p0, typeof(PaperKind)), 
		};
	}

	private string z0rek(DCInsertRowDownUseHotKeys p0)
	{
		string text = null;
		return p0 switch
		{
			DCInsertRowDownUseHotKeys.Disable => "Disable", 
			DCInsertRowDownUseHotKeys.EnableOnlyForLastRow => "EnableOnlyForLastRow", 
			DCInsertRowDownUseHotKeys.EnableInAllCases => "EnableInAllCases", 
			_ => throw z0ZzZzwhh.z0rek((long)p0, typeof(DCInsertRowDownUseHotKeys)), 
		};
	}
}
