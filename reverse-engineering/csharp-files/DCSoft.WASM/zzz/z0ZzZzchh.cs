using DCSoft.Chart;
using DCSoft.Common;
using DCSoft.Data;
using DCSoft.Drawing;
using DCSoft.Printing;
using DCSoft.WinForms;
using DCSoft.Writer;
using DCSoft.Writer.Data;
using DCSoft.Writer.Dom;
using DCSoft.Writer.Security;
using DCSystem_Drawing;
using DCSystem_Drawing.Drawing2D;
using DCSystem_Drawing.Printing;

namespace zzz;

internal class z0ZzZzchh
{
	private class z0zxk : z0ZzZzfgh
	{
		public override void z0sj(z0ZzZzggh p0, object p1)
		{
			z0ZzZzstk z0ZzZzstk2 = (z0ZzZzstk)p1;
			p0.WritePropertyValue("Alignment", z0ZzZzstk2.z0nek(), ContentAlignment.MiddleCenter);
			p0.WritePropertyValue("ColorString", z0ZzZzstk2.z0krk());
			p0.WritePropertyValue("Font", z0ZzZzstk2.z0vek());
			p0.WritePropertyValue("Height", z0ZzZzstk2.z0drk(), 100f);
			p0.WritePropertyValue("Text", z0ZzZzstk2.z0iek());
			p0.WritePropertyValue("Visible", z0ZzZzstk2.z0jrk());
		}
	}

	private class z0lzk : z0ZzZzfgh
	{
		public override void z0sj(z0ZzZzggh p0, object p1)
		{
			z0ZzZzqtk z0ZzZzqtk2 = (z0ZzZzqtk)p1;
			p0.WritePropertyValue("Angle", z0ZzZzqtk2.z0cek(), 45f);
			p0.WritePropertyValue("AxisCompress", z0ZzZzqtk2.z0ark(), AxisCompressStyle.AutoSize);
			if (z0ZzZzqtk2.z0qrk() != null && !p0.IsEmptyInstance(z0ZzZzqtk2.z0qrk()))
			{
				p0.WritePropertyValueInstance("BarBorderPen", z0ZzZzqtk2.z0qrk());
			}
			p0.WritePropertyValue("BarGroupSpacing", z0ZzZzqtk2.z0ktk(), 20);
			p0.WritePropertyValue("BarOpacity", z0ZzZzqtk2.z0ork(), 1.0);
			p0.WritePropertyValue("BarSpacing", z0ZzZzqtk2.z0vek());
			p0.WritePropertyValue("BarWidth", z0ZzZzqtk2.z0pek(), 50);
			if (z0ZzZzqtk2.z0jrk() != null && !p0.IsEmptyInstance(z0ZzZzqtk2.z0jrk()))
			{
				p0.WritePropertyValueInstance("Caption", z0ZzZzqtk2.z0jrk());
			}
			p0.WritePropertyValue("ColorTheme", z0ZzZzqtk2.z0htk(), ColorThemeType.Default);
			if (z0ZzZzqtk2.z0brk() != null && !p0.IsEmptyInstance(z0ZzZzqtk2.z0brk()))
			{
				p0.WritePropertyValueInstance("CustomColorTheme", z0ZzZzqtk2.z0brk());
			}
			p0.WritePropertyValue("Font", z0ZzZzqtk2.z0gtk());
			if (z0ZzZzqtk2.z0wrk() != null && !p0.IsEmptyInstance(z0ZzZzqtk2.z0wrk()))
			{
				p0.WritePropertyValueInstance("GridBackground", z0ZzZzqtk2.z0wrk());
			}
			if (z0ZzZzqtk2.z0xrk() != null && !p0.IsEmptyInstance(z0ZzZzqtk2.z0xrk()))
			{
				p0.WritePropertyValueInstance("GridBorderLineStyle", z0ZzZzqtk2.z0xrk());
			}
			p0.WritePropertyValue("GridLineOffsetX", z0ZzZzqtk2.z0rek());
			p0.WritePropertyValue("GridLineOffsetY", z0ZzZzqtk2.z0frk());
			if (z0ZzZzqtk2.z0ltk() != null && !p0.IsEmptyInstance(z0ZzZzqtk2.z0ltk()))
			{
				p0.WritePropertyValueInstance("GridLineStyle", z0ZzZzqtk2.z0ltk());
			}
			p0.WritePropertyValue("GridTextHeight", z0ZzZzqtk2.z0zrk(), 60);
			p0.WritePropertyValue("GridTextWidth", z0ZzZzqtk2.z0irk(), 100);
			p0.WritePropertyValue("GridValueFormat", z0ZzZzqtk2.z0srk());
			p0.WritePropertyValue("GroupGridLine", z0ZzZzqtk2.z0xek(), defaultValue: true);
			p0.WritePropertyValue("HorizontalTextAlign", z0ZzZzqtk2.z0nek(), StringAlignment.Center);
			if (z0ZzZzqtk2.z0grk() != null && !p0.IsEmptyInstance(z0ZzZzqtk2.z0grk()))
			{
				p0.WritePropertyValueInstance("LabelStyle", z0ZzZzqtk2.z0grk());
			}
			if (z0ZzZzqtk2.z0erk() != null && !p0.IsEmptyInstance(z0ZzZzqtk2.z0erk()))
			{
				p0.WritePropertyValueInstance("LegendStyle", z0ZzZzqtk2.z0erk());
			}
			p0.WritePropertyValue("PaddingBottom", z0ZzZzqtk2.z0lrk());
			p0.WritePropertyValue("PaddingLeft", z0ZzZzqtk2.z0urk());
			p0.WritePropertyValue("PaddingRight", z0ZzZzqtk2.z0zek());
			p0.WritePropertyValue("PaddingTop", z0ZzZzqtk2.z0drk());
			p0.WritePropertyValue("RipenessRate", z0ZzZzqtk2.z0vrk());
			p0.WritePropertyValue("TextColorValue", z0ZzZzqtk2.z0oek());
			p0.WritePropertyValue("Thickness", z0ZzZzqtk2.z0uek());
			p0.WritePropertyValue("VerticalTextAlign", z0ZzZzqtk2.z0nrk(), StringAlignment.Near);
			p0.WritePropertyValue("VerticalXLabel", z0ZzZzqtk2.z0jtk());
			p0.WritePropertyValue("ViewStyle", z0ZzZzqtk2.z0dtk(), ChartViewStyle.Bar);
			if (z0ZzZzqtk2.z0eek() != null && !p0.IsEmptyInstance(z0ZzZzqtk2.z0eek()))
			{
				p0.WritePropertyValueInstance("XAxisCaption", z0ZzZzqtk2.z0eek());
			}
			if (z0ZzZzqtk2.z0mek() != null && z0ZzZzqtk2.z0mek().Count > 0)
			{
				p0.WritePropertyValueInstance("YAxisCaptions", z0ZzZzqtk2.z0mek());
			}
		}
	}

	private class z0kzk : z0ZzZzfgh
	{
		public override void z0sj(z0ZzZzggh p0, object p1)
		{
			z0ZzZzitk z0ZzZzitk2 = (z0ZzZzitk)p1;
			p0.WritePropertyValue("BackColorValue", z0ZzZzitk2.z0uek());
			p0.WritePropertyValue("BorderColorValue", z0ZzZzitk2.z0tek());
			p0.WritePropertyValue("ColorValue", z0ZzZzitk2.z0pek());
			p0.WritePropertyValue("Font", z0ZzZzitk2.z0iek());
			p0.WritePropertyValue("Visible", z0ZzZzitk2.z0yek());
		}
	}

	private class z0jzk : z0ZzZzfgh
	{
		public override void z0sj(z0ZzZzggh p0, object p1)
		{
			z0ZzZzptk z0ZzZzptk2 = (z0ZzZzptk)p1;
			p0.WritePropertyValue("AutoSize", z0ZzZzptk2.z0nek(), defaultValue: true);
			if (z0ZzZzptk2.z0iek() != null && !p0.IsEmptyInstance(z0ZzZzptk2.z0iek()))
			{
				p0.WritePropertyValueInstance("Background", z0ZzZzptk2.z0iek());
			}
			p0.WritePropertyValue("Font", z0ZzZzptk2.z0yek_jiejie20260327142557());
			p0.WritePropertyValue("MaxSize", z0ZzZzptk2.z0tek());
			p0.WritePropertyValue("Size", z0ZzZzptk2.z0uek(), 40);
			p0.WritePropertyValue("SymbolSize", z0ZzZzptk2.z0pek(), 40f);
			p0.WritePropertyValue("TextColorValue", z0ZzZzptk2.z0rek());
			p0.WritePropertyValue("Visible", z0ZzZzptk2.z0eek(), defaultValue: true);
		}
	}

	private class z0hzk : z0ZzZzfgh
	{
		public override void z0sj(z0ZzZzggh p0, object p1)
		{
			z0ZzZzbtk z0ZzZzbtk2 = (z0ZzZzbtk)p1;
			if (z0ZzZzbtk2.z0tek() != null && z0ZzZzbtk2.z0tek().Count > 0)
			{
				p0.WritePropertyValueInstance("Colors", z0ZzZzbtk2.z0tek());
			}
			p0.WritePropertyValue("LightCorrectionFactor", z0ZzZzbtk2.z0uek(), 0.5f);
			p0.WritePropertyValue("ShadeCount", z0ZzZzbtk2.z0iek(), 1);
			p0.WritePropertyValue("ThemeType", z0ZzZzbtk2.z0rek(), ColorThemeType.Default);
		}
	}

	private class z0gzk : z0ZzZzfgh
	{
		public override void z0sj(z0ZzZzggh p0, object p1)
		{
			z0ZzZzcok z0ZzZzcok2 = (z0ZzZzcok)p1;
			p0.WritePropertyValue("Align", z0ZzZzcok2.Align, DocumentContentAlignment.Left);
			p0.WritePropertyValue("BackgroundColor2String", z0ZzZzcok2.BackgroundColor2String);
			p0.WritePropertyValue("BackgroundColorString", z0ZzZzcok2.BackgroundColorString);
			p0.WritePropertyValue("Bold", z0ZzZzcok2.Bold);
			p0.WritePropertyValue("BorderBottom", z0ZzZzcok2.BorderBottom);
			p0.WritePropertyValue("BorderBottomColorString", z0ZzZzcok2.BorderBottomColorString);
			p0.WritePropertyValue("BorderLeft", z0ZzZzcok2.BorderLeft);
			p0.WritePropertyValue("BorderLeftColorString", z0ZzZzcok2.BorderLeftColorString);
			p0.WritePropertyValue("BorderRight", z0ZzZzcok2.BorderRight);
			p0.WritePropertyValue("BorderRightColorString", z0ZzZzcok2.BorderRightColorString);
			p0.WritePropertyValue("BorderSpacing", z0ZzZzcok2.BorderSpacing);
			p0.WritePropertyValue("BorderStyle", z0ZzZzcok2.BorderStyle, DashStyle.Solid);
			p0.WritePropertyValue("BorderTop", z0ZzZzcok2.BorderTop);
			p0.WritePropertyValue("BorderTopColorString", z0ZzZzcok2.BorderTopColorString);
			p0.WritePropertyValue("BorderWidth", z0ZzZzcok2.BorderWidth);
			p0.WritePropertyValue("CharacterCircle", z0ZzZzcok2.CharacterCircle, CharacterCircleStyles.None);
			p0.WritePropertyValue("ColorString", z0ZzZzcok2.ColorString);
			p0.WritePropertyValue("EmphasisMark", z0ZzZzcok2.EmphasisMark);
			p0.WritePropertyValue("FirstLineIndent", z0ZzZzcok2.FirstLineIndent);
			p0.WritePropertyValue("FixedSpacing", z0ZzZzcok2.FixedSpacing);
			p0.WritePropertyValue("FontName", z0ZzZzcok2.FontName);
			p0.WritePropertyValue("FontSize", z0ZzZzcok2.FontSize);
			p0.WritePropertyValue("Index", z0ZzZzcok2.Index, -1);
			p0.WritePropertyValue("Italic", z0ZzZzcok2.Italic);
			p0.WritePropertyValue("LayoutAlign", z0ZzZzcok2.LayoutAlign, ContentLayoutAlign.EmbedInText);
			p0.WritePropertyValue("LeftIndent", z0ZzZzcok2.LeftIndent);
			p0.WritePropertyValue("LetterSpacing", z0ZzZzcok2.LetterSpacing);
			p0.WritePropertyValue("LineSpacing", z0ZzZzcok2.LineSpacing);
			p0.WritePropertyValue("LineSpacingStyle", z0ZzZzcok2.LineSpacingStyle, LineSpacingStyle.SpaceSingle);
			p0.WritePropertyValue("MarginBottom", z0ZzZzcok2.MarginBottom);
			p0.WritePropertyValue("MarginLeft", z0ZzZzcok2.MarginLeft);
			p0.WritePropertyValue("MarginRight", z0ZzZzcok2.MarginRight);
			p0.WritePropertyValue("MarginTop", z0ZzZzcok2.MarginTop);
			p0.WritePropertyValue("Multiline", z0ZzZzcok2.Multiline);
			p0.WritePropertyValue("PaddingBottom", z0ZzZzcok2.PaddingBottom);
			p0.WritePropertyValue("PaddingLeft", z0ZzZzcok2.PaddingLeft);
			p0.WritePropertyValue("PaddingRight", z0ZzZzcok2.PaddingRight);
			p0.WritePropertyValue("PaddingTop", z0ZzZzcok2.PaddingTop);
			p0.WritePropertyValue("ParagraphListStyle", z0ZzZzcok2.ParagraphListStyle, ParagraphListStyle.None);
			p0.WritePropertyValue("ParagraphMultiLevel", z0ZzZzcok2.ParagraphMultiLevel);
			p0.WritePropertyValue("ParagraphOutlineLevel", z0ZzZzcok2.ParagraphOutlineLevel, -1);
			p0.WritePropertyValue("RightToLeft", z0ZzZzcok2.RightToLeft);
			p0.WritePropertyValue("RTFLineSpacing", z0ZzZzcok2.RTFLineSpacing);
			p0.WritePropertyValue("SpacingAfterParagraph", z0ZzZzcok2.SpacingAfterParagraph);
			p0.WritePropertyValue("SpacingBeforeParagraph", z0ZzZzcok2.SpacingBeforeParagraph);
			p0.WritePropertyValue("Strikeout", z0ZzZzcok2.Strikeout);
			p0.WritePropertyValue("Subscript", z0ZzZzcok2.Subscript);
			p0.WritePropertyValue("Superscript", z0ZzZzcok2.Superscript);
			p0.WritePropertyValue("Underline", z0ZzZzcok2.Underline);
			p0.WritePropertyValue("UnderlineColor", z0ZzZzcok2.UnderlineColor);
			p0.WritePropertyValue("UnderlineStyle", z0ZzZzcok2.UnderlineStyle, TextUnderlineStyle.Single);
			p0.WritePropertyValue("VerticalAlign", z0ZzZzcok2.VerticalAlign, VerticalAlignStyle.Top);
			p0.WritePropertyValue("VisibleInDirectory", z0ZzZzcok2.VisibleInDirectory, defaultValue: true);
		}
	}

	private class z0fzk : z0ZzZzfgh
	{
		public override void z0sj(z0ZzZzggh p0, object p1)
		{
			z0ZzZzxok z0ZzZzxok2 = (z0ZzZzxok)p1;
			if (z0ZzZzxok2.Default != null && !p0.IsEmptyInstance(z0ZzZzxok2.Default))
			{
				p0.WritePropertyValueInstance("Default", z0ZzZzxok2.Default);
			}
		}
	}

	private class z0dzk : z0ZzZzfgh
	{
		public override void z0sj(z0ZzZzggh p0, object p1)
		{
			CopySourceInfo copySourceInfo = (CopySourceInfo)p1;
			p0.WritePropertyValue("DescPropertyName", copySourceInfo.z0iek());
			p0.WritePropertyValue("IgnoreChildElements", copySourceInfo.z0yek(), defaultValue: true);
			p0.WritePropertyValue("SourceID", copySourceInfo.z0tek());
			p0.WritePropertyValue("SourcePropertyName", copySourceInfo.z0eek());
		}
	}

	private class z0szk : z0ZzZzfgh
	{
		public override void z0sj(z0ZzZzggh p0, object p1)
		{
			DCChartDataItem dCChartDataItem = (DCChartDataItem)p1;
			p0.WritePropertyValue("ChartStyle", dCChartDataItem.ChartStyle, ChartStyleConsts.Default);
			p0.WritePropertyValue("ColorValue", dCChartDataItem.ColorValue);
			p0.WritePropertyValue("GroupName", dCChartDataItem.GroupName);
			p0.WritePropertyValue("Link", dCChartDataItem.Link);
			p0.WritePropertyValue("SeriesName", dCChartDataItem.SeriesName);
			p0.WritePropertyValue("SymbolType", dCChartDataItem.SymbolType, ShapeTypes.Default);
			p0.WritePropertyValue("Text", dCChartDataItem.Text);
			p0.WritePropertyValue("TipText", dCChartDataItem.TipText);
			p0.WritePropertyValue("Value", dCChartDataItem.Value);
		}
	}

	internal class z0azk : z0ZzZzfgh
	{
		public override void z0sj(z0ZzZzggh p0, object p1)
		{
			DCChartDataItemList dCChartDataItemList = (DCChartDataItemList)p1;
			if (dCChartDataItemList == null || dCChartDataItemList.Count <= 0)
			{
				return;
			}
			foreach (DCChartDataItem item in dCChartDataItemList)
			{
				p0.WritePropertyValueInstance("Item", item);
			}
		}
	}

	private class z0qzk : z0ZzZzfgh
	{
		public override void z0sj(z0ZzZzggh p0, object p1)
		{
			DCContentLockInfo dCContentLockInfo = (DCContentLockInfo)p1;
			p0.WritePropertyValue("AuthorisedUserIDList", dCContentLockInfo.AuthorisedUserIDList);
			p0.WritePropertyValue("CreationTime", dCContentLockInfo.CreationTime);
			p0.WritePropertyValue("OwnerUserID", dCContentLockInfo.OwnerUserID);
		}
	}

	private class z0wzk : z0ZzZzfgh
	{
		public override void z0sj(z0ZzZzggh p0, object p1)
		{
			z0ZzZzzej z0ZzZzzej2 = (z0ZzZzzej)p1;
			p0.WritePropertyValue("AlignToGridLine", z0ZzZzzej2.z0cek(), defaultValue: true);
			p0.WritePropertyValue("ColorValue", z0ZzZzzej2.z0eek());
			p0.WritePropertyValue("GridNumInOnePage", z0ZzZzzej2.z0mek());
			p0.WritePropertyValue("GridSpanInCM", z0ZzZzzej2.z0xek());
			p0.WritePropertyValue("LineStyle", z0ZzZzzej2.z0vek(), DashStyle.Solid);
			p0.WritePropertyValue("LineWidth", z0ZzZzzej2.z0oek(), 1f);
			p0.WritePropertyValue("Printable", z0ZzZzzej2.z0yek(), defaultValue: true);
			p0.WritePropertyValue("Visible", z0ZzZzzej2.z0uek());
		}
	}

	private class z0ezk : z0ZzZzfgh
	{
		public override void z0sj(z0ZzZzggh p0, object p1)
		{
			DocumentComment documentComment = (DocumentComment)p1;
			if (documentComment.z0lrk() != null && documentComment.z0lrk().Count > 0)
			{
				p0.WritePropertyValueInstance("Attributes", documentComment.z0lrk());
			}
			p0.WritePropertyValue("Author", documentComment.z0krk());
			p0.WritePropertyValue("AuthorID", documentComment.z0eek());
			p0.WritePropertyValue("BindingUserTrack", documentComment.z0jrk());
			p0.WritePropertyValue("CreationTime", documentComment.z0mrk());
			p0.WritePropertyValue("CreatorIndex", documentComment.z0urk(), -1);
			p0.WritePropertyValue("ID", documentComment.z0ark());
			p0.WritePropertyValue("Index", documentComment.z0tek());
			p0.WritePropertyValue("Text", documentComment.z0nek());
			p0.WritePropertyValue("Title", documentComment.z0grk());
		}
	}

	private class z0rzk : z0ZzZzfgh
	{
		public override void z0sj(z0ZzZzggh p0, object p1)
		{
			z0ZzZzwcj z0ZzZzwcj2 = (z0ZzZzwcj)p1;
			if (z0ZzZzwcj2 == null || z0ZzZzwcj2.Count <= 0)
			{
				return;
			}
			foreach (DocumentComment item in z0ZzZzwcj2)
			{
				p0.WritePropertyValueInstance("Item", item);
			}
		}
	}

	private class z0tzk : z0ZzZzfgh
	{
		public override void z0sj(z0ZzZzggh p0, object p1)
		{
			p0.GetProvider(typeof(z0ZzZzcok)).z0sj(p0, p1);
			DocumentContentStyle documentContentStyle = (DocumentContentStyle)p1;
			p0.WritePropertyValue("CommentIndex", documentContentStyle.CommentIndex, -1);
			p0.WritePropertyValue("CreatorIndex", documentContentStyle.CreatorIndex, -1);
			p0.WritePropertyValue("DeleterIndex", documentContentStyle.DeleterIndex, -1);
			p0.WritePropertyValue("GridLineColorString", documentContentStyle.GridLineColorString);
			p0.WritePropertyValue("GridLineOffsetY", documentContentStyle.GridLineOffsetY);
			p0.WritePropertyValue("GridLineStyle", documentContentStyle.GridLineStyle, DashStyle.Solid);
			p0.WritePropertyValue("GridLineType", documentContentStyle.GridLineType, ContentGridLineType.None);
			p0.WritePropertyValue("LayoutDirection", documentContentStyle.LayoutDirection, ContentLayoutDirectionStyle.Default);
			p0.WritePropertyValue("PrintBackColorString", documentContentStyle.PrintBackColorString);
			p0.WritePropertyValue("PrintColorString", documentContentStyle.PrintColorString);
			p0.WritePropertyValue("ProtectType", documentContentStyle.ProtectType, ContentProtectType.None);
			p0.WritePropertyValue("TitleLevel", documentContentStyle.TitleLevel, -1);
		}
	}

	private class z0yzk : z0ZzZzfgh
	{
		public override void z0sj(z0ZzZzggh p0, object p1)
		{
			p0.GetProvider(typeof(z0ZzZzxok)).z0sj(p0, p1);
			DocumentContentStyleContainer documentContentStyleContainer = (DocumentContentStyleContainer)p1;
			if (documentContentStyleContainer.Default != null && !p0.IsEmptyInstance(documentContentStyleContainer.Default))
			{
				p0.WritePropertyValueInstance("Default", documentContentStyleContainer.Default);
			}
		}
	}

	private class z0uzk : z0ZzZzfgh
	{
		public override void z0sj(z0ZzZzggh p0, object p1)
		{
			DocumentInfo documentInfo = (DocumentInfo)p1;
			if (z0eek == 1)
			{
				p0.WritePropertyValue("Author", documentInfo.z0trk());
				p0.WritePropertyValue("AuthorName", documentInfo.z0xek());
				p0.WritePropertyValue("AuthorPermissionLevel", documentInfo.z0eek());
				p0.WritePropertyValue("Comment", documentInfo.z0ark());
				p0.WritePropertyValue("CreationTime", documentInfo.z0nrk());
				p0.WritePropertyValue("DepartmentID", documentInfo.z0cek());
				p0.WritePropertyValue("DepartmentName", documentInfo.z0jrk());
				p0.WritePropertyValue("Description", documentInfo.z0mrk());
				p0.WritePropertyValue("DocumentEditState", documentInfo.z0vek());
				p0.WritePropertyValue("DocumentFormat", documentInfo.z0erk());
				p0.WritePropertyValue("DocumentProcessState", documentInfo.z0qrk());
				p0.WritePropertyValue("DocumentType", documentInfo.z0bek());
				p0.WritePropertyValue("EditMinute", documentInfo.z0krk());
				p0.WritePropertyValue("FieldBorderElementWidth", documentInfo.z0rek(), 1f);
				p0.WritePropertyValue("HeightInPrintJob", documentInfo.z0urk());
				p0.WritePropertyValue("ID", documentInfo.z0srk());
				p0.WritePropertyValue("IsTemplate", documentInfo.z0drk());
				p0.WritePropertyValue("KBEntryRangeMask", documentInfo.z0tek());
				p0.WritePropertyValue("LastModifiedTime", documentInfo.z0wrk());
				p0.WritePropertyValue("LastPrintTime", documentInfo.z0oek());
				p0.WritePropertyValue("LicenseText", documentInfo.z0nek());
				p0.WritePropertyValue("MRID", documentInfo.z0grk());
				p0.WritePropertyValue("NumOfPage", documentInfo.z0irk());
				p0.WritePropertyValue("Operator", documentInfo.z0ork());
				p0.WritePropertyValue("Printable", documentInfo.z0iek_jiejie20260327142557(), defaultValue: true);
				p0.WritePropertyValue("Readonly", documentInfo.z0lrk());
				p0.WritePropertyValue("ShowHeaderBottomLine", documentInfo.ShowHeaderBottomLine, DCBooleanValue.Inherit);
				p0.WritePropertyValue("StartPositionInPringJob", documentInfo.z0yrk());
				if (documentInfo.z0frk() != null && !p0.IsEmptyInstance(documentInfo.z0frk()))
				{
					p0.WritePropertyValueInstance("SubDocumentSettings", documentInfo.z0frk());
				}
				p0.WritePropertyValue("TimeoutHours", documentInfo.z0uek());
				p0.WritePropertyValue("Title", documentInfo.z0mek());
				p0.WritePropertyValue("UseLanguage2", documentInfo.z0pek());
				p0.WritePropertyValue("Version", documentInfo.z0hrk());
			}
			else
			{
				p0.WritePropertyValue("Author", documentInfo.z0trk());
				p0.WritePropertyValue("AuthorName", documentInfo.z0xek());
				p0.WritePropertyValue("Comment", documentInfo.z0ark());
				p0.WritePropertyValue("CreationTime", documentInfo.z0nrk());
				p0.WritePropertyValue("DepartmentID", documentInfo.z0cek());
				p0.WritePropertyValue("DepartmentName", documentInfo.z0jrk());
				p0.WritePropertyValue("Description", documentInfo.z0mrk());
				p0.WritePropertyValue("DocumentFormat", documentInfo.z0erk());
				p0.WritePropertyValue("DocumentType", documentInfo.z0bek());
				p0.WritePropertyValue("ID", documentInfo.z0srk());
				p0.WritePropertyValue("MRID", documentInfo.z0grk());
				p0.WritePropertyValue("Operator", documentInfo.z0ork());
				p0.WritePropertyValue("Title", documentInfo.z0mek());
				p0.WritePropertyValue("Version", documentInfo.z0hrk());
			}
		}
	}

	private class z0izk : z0ZzZzfgh
	{
		public override void z0sj(z0ZzZzggh p0, object p1)
		{
			DocumentParameter documentParameter = (DocumentParameter)p1;
			p0.WritePropertyValue("DefaultValue", documentParameter.z0nek());
			p0.WritePropertyValue("Description", documentParameter.z0pek());
			p0.WritePropertyValue("Name", documentParameter.z0eek());
			p0.WritePropertyValue("SourceColumn", documentParameter.z0mek());
			p0.WritePropertyValue("TypeName", documentParameter.z0iek());
			p0.WritePropertyValue("ValueType", documentParameter.z0tek(), (z0ZzZzjvj)7);
			p0.WritePropertyValue("ValueTypeFullName", documentParameter.z0uek());
		}
	}

	internal class z0ozk : z0ZzZzfgh
	{
		public override void z0sj(z0ZzZzggh p0, object p1)
		{
			if (z0eek != 1)
			{
				return;
			}
			z0ZzZzkvj z0ZzZzkvj2 = (z0ZzZzkvj)p1;
			if (z0ZzZzkvj2 == null || z0ZzZzkvj2.Count <= 0)
			{
				return;
			}
			foreach (DocumentParameter item in z0ZzZzkvj2)
			{
				p0.WritePropertyValueInstance("Item", item);
			}
		}
	}

	private class z0pzk : z0ZzZzfgh
	{
		public override void z0sj(z0ZzZzggh p0, object p1)
		{
			z0ZzZzfpk z0ZzZzfpk2 = (z0ZzZzfpk)p1;
			p0.WritePropertyValue("ColorValue", z0ZzZzfpk2.z0pek());
			p0.WritePropertyValue("Font", z0ZzZzfpk2.z0uek());
			p0.WritePropertyValue("MinHeightInCMUnit", z0ZzZzfpk2.z0bek(), 2f);
			p0.WritePropertyValue("Text", z0ZzZzfpk2.z0mek());
			p0.WritePropertyValue("TextInMiddlePage", z0ZzZzfpk2.z0rek());
		}
	}

	private class z0mzk : z0ZzZzfgh
	{
		public override void z0sj(z0ZzZzggh p0, object p1)
		{
			z0ZzZzykh z0ZzZzykh2 = (z0ZzZzykh)p1;
			p0.WritePropertyValue("CustomTargetName", z0ZzZzykh2.z0tek());
			p0.WritePropertyValue("EventName", z0ZzZzykh2.z0iek());
			p0.WritePropertyValue("Expression", z0ZzZzykh2.z0yek());
			p0.WritePropertyValue("Target", z0ZzZzykh2.z0rek(), (z0ZzZzikh)0);
			p0.WritePropertyValue("TargetPropertyName", z0ZzZzykh2.z0uek());
		}
	}

	internal class z0nzk : z0ZzZzfgh
	{
		public override void z0sj(z0ZzZzggh p0, object p1)
		{
			z0ZzZzukh z0ZzZzukh2 = (z0ZzZzukh)p1;
			if (z0ZzZzukh2 == null || z0ZzZzukh2.Count <= 0)
			{
				return;
			}
			foreach (z0ZzZzykh item in z0ZzZzukh2)
			{
				p0.WritePropertyValueInstance("Item", item);
			}
		}
	}

	private class z0bzk : z0ZzZzfgh
	{
		public override void z0sj(z0ZzZzggh p0, object p1)
		{
			z0ZzZzbuk z0ZzZzbuk2 = (z0ZzZzbuk)p1;
			p0.WritePropertyValue("Reference", z0ZzZzbuk2.Reference);
			p0.WritePropertyValue("Target", z0ZzZzbuk2.Target);
			p0.WritePropertyValue("Title", z0ZzZzbuk2.Title);
		}
	}

	private class z0vzk : z0ZzZzfgh
	{
		public override void z0sj(z0ZzZzggh p0, object p1)
		{
			InputFieldSettings inputFieldSettings = (InputFieldSettings)p1;
			p0.WritePropertyValue("DynamicListItems", inputFieldSettings.z0uek());
			p0.WritePropertyValue("EditStyle", inputFieldSettings.z0nek(), InputFieldEditStyle.Text);
			p0.WritePropertyValue("GetValueOrderByTime", inputFieldSettings.z0iek());
			if (inputFieldSettings.z0zek() != null && !p0.IsEmptyInstance(inputFieldSettings.z0zek()))
			{
				p0.WritePropertyValueInstance("ListSource", inputFieldSettings.z0zek());
			}
			p0.WritePropertyValue("ListValueFormatString", inputFieldSettings.z0tek());
			p0.WritePropertyValue("ListValueSeparatorChar", inputFieldSettings.z0oek());
			p0.WritePropertyValue("MultiColumn", inputFieldSettings.z0bek());
			p0.WritePropertyValue("MultiSelect", inputFieldSettings.z0yek());
			p0.WritePropertyValue("RepulsionForGroup", inputFieldSettings.z0xek());
		}
	}

	private class z0czk : z0ZzZzfgh
	{
		public override void z0sj(z0ZzZzggh p0, object p1)
		{
			z0ZzZzfvj z0ZzZzfvj2 = (z0ZzZzfvj)p1;
			p0.WritePropertyValue("AutoSetFirstItems", z0ZzZzfvj2.AutoSetFirstItems);
			p0.WritePropertyValue("AutoUpdateTargetElement", z0ZzZzfvj2.AutoUpdateTargetElement, defaultValue: true);
			p0.WritePropertyValue("IsRoot", z0ZzZzfvj2.IsRoot);
			p0.WritePropertyValue("NextTarget", z0ZzZzfvj2.NextTarget, (z0ZzZzikh)0);
			p0.WritePropertyValue("NextTargetID", z0ZzZzfvj2.NextTargetID);
			p0.WritePropertyValue("ProviderName", z0ZzZzfvj2.ProviderName);
			p0.WritePropertyValue("UserFlag", z0ZzZzfvj2.UserFlag);
		}
	}

	private class z0xzk : z0ZzZzfgh
	{
		public override void z0sj(z0ZzZzggh p0, object p1)
		{
			ListItem listItem = (ListItem)p1;
			if (z0eek == 1)
			{
				p0.WritePropertyValue("CheckedTime", listItem.CheckedTime);
			}
			p0.WritePropertyValue("EntryID", listItem.EntryID);
			p0.WritePropertyValue("Group", listItem.Group);
			p0.WritePropertyValue("ID", listItem.z0uek());
			p0.WritePropertyValue("ListIndex", listItem.ListIndex);
			p0.WritePropertyValue("LonelyChecked", listItem.LonelyChecked);
			p0.WritePropertyValue("Tag", listItem.Tag);
			p0.WritePropertyValue("Text", listItem.Text);
			p0.WritePropertyValue("TextInList", listItem.TextInList);
			p0.WritePropertyValue("Value", listItem.Value);
		}
	}

	internal class z0zzk : z0ZzZzfgh
	{
		public override void z0sj(z0ZzZzggh p0, object p1)
		{
			z0ZzZzdvj z0ZzZzdvj2 = (z0ZzZzdvj)p1;
			if (z0ZzZzdvj2 == null || z0ZzZzdvj2.Count <= 0)
			{
				return;
			}
			using zzz.z0ZzZzkuk<ListItem>.z0bpk z0bpk = z0ZzZzdvj2.z0ltk();
			while (z0bpk.MoveNext())
			{
				ListItem current = z0bpk.Current;
				p0.WritePropertyValueInstance("Item", current);
			}
		}
	}

	private sealed class z0llj : z0ZzZzfgh
	{
		public override void z0sj(z0ZzZzggh p0, object p1)
		{
			z0ZzZzsvj z0ZzZzsvj2 = (z0ZzZzsvj)p1;
			p0.WritePropertyValue("BufferItems", z0ZzZzsvj2.BufferItems, defaultValue: true);
			p0.WritePropertyValue("DisplayPath", z0ZzZzsvj2.DisplayPath);
			if (z0ZzZzsvj2.Items != null && z0ZzZzsvj2.Items.Count > 0)
			{
				p0.WritePropertyValueInstance("Items", z0ZzZzsvj2.Items);
			}
			p0.WritePropertyValue("SourceName", z0ZzZzsvj2.SourceName);
			p0.WritePropertyValue("ValuePath", z0ZzZzsvj2.ValuePath);
		}
	}

	private class z0klj : z0ZzZzfgh
	{
		public override void z0sj(z0ZzZzggh p0, object p1)
		{
			ObjectParameter objectParameter = (ObjectParameter)p1;
			p0.WritePropertyValue("Name", objectParameter.Name);
			p0.WritePropertyValue("Value", objectParameter.Value);
		}
	}

	internal class z0jlj : z0ZzZzfgh
	{
		public override void z0sj(z0ZzZzggh p0, object p1)
		{
			ObjectParameterList objectParameterList = (ObjectParameterList)p1;
			if (objectParameterList == null || objectParameterList.Count <= 0)
			{
				return;
			}
			foreach (ObjectParameter item in objectParameterList)
			{
				p0.WritePropertyValueInstance("Item", item);
			}
		}
	}

	private class z0hlj : z0ZzZzfgh
	{
		public override void z0sj(z0ZzZzggh p0, object p1)
		{
			p0.GetProvider(typeof(z0ZzZzcok)).z0sj(p0, p1);
			z0ZzZzvpk z0ZzZzvpk2 = (z0ZzZzvpk)p1;
			p0.WritePropertyValue("BorderRange", z0ZzZzvpk2.z0eek(), PageBorderRangeTypes.None);
		}
	}

	private class z0glj : z0ZzZzfgh
	{
		public override void z0sj(z0ZzZzggh p0, object p1)
		{
			z0ZzZzfzj z0ZzZzfzj2 = (z0ZzZzfzj)p1;
			p0.WritePropertyValue("Image", z0ZzZzfzj2.z0eek());
			p0.WritePropertyValue("PageIndex", z0ZzZzfzj2.z0tek());
		}
	}

	internal class z0flj : z0ZzZzfgh
	{
		public override void z0sj(z0ZzZzggh p0, object p1)
		{
			z0ZzZzdzj z0ZzZzdzj2 = (z0ZzZzdzj)p1;
			if (z0ZzZzdzj2 == null || z0ZzZzdzj2.Count <= 0)
			{
				return;
			}
			foreach (z0ZzZzfzj item in z0ZzZzdzj2)
			{
				p0.WritePropertyValueInstance("Item", item);
			}
		}
	}

	private class z0dlj : z0ZzZzfgh
	{
		public override void z0sj(z0ZzZzggh p0, object p1)
		{
			PageLabelText pageLabelText = (PageLabelText)p1;
			p0.WritePropertyValue("PageIndex", pageLabelText.PageIndex);
			p0.WritePropertyValue("Text", pageLabelText.Text);
		}
	}

	internal class z0slj : z0ZzZzfgh
	{
		public override void z0sj(z0ZzZzggh p0, object p1)
		{
			PageLabelTextList pageLabelTextList = (PageLabelTextList)p1;
			if (pageLabelTextList == null || pageLabelTextList.Count <= 0)
			{
				return;
			}
			foreach (PageLabelText item in pageLabelTextList)
			{
				p0.WritePropertyValueInstance("Item", item);
			}
		}
	}

	private class z0alj : z0ZzZzfgh
	{
		public override void z0sj(z0ZzZzggh p0, object p1)
		{
			PropertyExpressionInfo propertyExpressionInfo = (PropertyExpressionInfo)p1;
			p0.WritePropertyValue("AllowChainReaction", propertyExpressionInfo.AllowChainReaction, defaultValue: true);
			p0.WritePropertyValue("Expression", propertyExpressionInfo.Expression);
			p0.WritePropertyValue("Name", propertyExpressionInfo.Name);
		}
	}

	internal class z0qlj : z0ZzZzfgh
	{
		public override void z0sj(z0ZzZzggh p0, object p1)
		{
			PropertyExpressionInfoList propertyExpressionInfoList = (PropertyExpressionInfoList)p1;
			if (propertyExpressionInfoList == null || propertyExpressionInfoList.Count <= 0)
			{
				return;
			}
			foreach (PropertyExpressionInfo item in propertyExpressionInfoList)
			{
				p0.WritePropertyValueInstance("Item", item);
			}
		}
	}

	private class z0wlj : z0ZzZzfgh
	{
		public override void z0sj(z0ZzZzggh p0, object p1)
		{
			RepeatedImageValue repeatedImageValue = (RepeatedImageValue)p1;
			p0.WritePropertyValue("ReferenceCount", repeatedImageValue.ReferenceCount);
			p0.WritePropertyValue("ValueIndex", repeatedImageValue.ValueIndex);
		}
	}

	internal class z0elj : z0ZzZzfgh
	{
		public override void z0sj(z0ZzZzggh p0, object p1)
		{
			RepeatedImageValueList repeatedImageValueList = (RepeatedImageValueList)p1;
			if (repeatedImageValueList == null || repeatedImageValueList.Count <= 0)
			{
				return;
			}
			foreach (RepeatedImageValue item in repeatedImageValueList)
			{
				p0.WritePropertyValueInstance("Item", item);
			}
		}
	}

	private class z0rlj : z0ZzZzfgh
	{
		public override void z0sj(z0ZzZzggh p0, object p1)
		{
			p0.GetProvider(typeof(z0ZzZzeuj)).z0sj(p0, p1);
			z0ZzZzluj z0ZzZzluj2 = (z0ZzZzluj)p1;
			p0.WritePropertyValue("AutoZoomFontSize", z0ZzZzluj2.z0nek(), defaultValue: true);
			if (z0ZzZzluj2.z0bek() != null && !p0.IsEmptyInstance(z0ZzZzluj2.z0bek()))
			{
				p0.WritePropertyValueInstance("ContentStyles", z0ZzZzluj2.z0bek());
			}
			p0.WritePropertyValue("DefaultFont", z0ZzZzluj2.z0rek());
			p0.WritePropertyValue("EditMode", z0ZzZzluj2.z0cek(), defaultValue: true);
			p0.WritePropertyValue("LocalElementStyleMode", z0ZzZzluj2.z0eek());
			p0.WritePropertyValue("TextBackColorString", z0ZzZzluj2.z0oek());
		}
	}

	private class z0tlj : z0ZzZzfgh
	{
		public override void z0sj(z0ZzZzggh p0, object p1)
		{
			p0.GetProvider(typeof(z0ZzZzeuj)).z0sj(p0, p1);
			z0ZzZzkuj z0ZzZzkuj2 = (z0ZzZzkuj)p1;
			p0.WritePropertyValue("AutoSize", z0ZzZzkuj2.z0rek(), defaultValue: true);
			p0.WritePropertyValue("Image", z0ZzZzkuj2.z0eek());
		}
	}

	private class z0ylj : z0ZzZzfgh
	{
		public override void z0sj(z0ZzZzggh p0, object p1)
		{
			z0ZzZzhuj z0ZzZzhuj2 = (z0ZzZzhuj)p1;
			p0.WritePropertyValue("ID", z0ZzZzhuj2.z0yek());
			if (z0ZzZzhuj2.z0pek() != null && !p0.IsEmptyInstance(z0ZzZzhuj2.z0pek()))
			{
				p0.WritePropertyValueInstance("LocalStyle", z0ZzZzhuj2.z0pek());
			}
			p0.WritePropertyValue("StyleIndex", z0ZzZzhuj2.z0eek(), -1);
			p0.WritePropertyValue("Visible", z0ZzZzhuj2.z0rek_jiejie20260327142557(), defaultValue: true);
		}
	}

	private class z0ulj : z0ZzZzfgh
	{
		public override void z0sj(z0ZzZzggh p0, object p1)
		{
			p0.GetProvider(typeof(z0ZzZzhuj)).z0sj(p0, p1);
			z0ZzZzauj z0ZzZzauj2 = (z0ZzZzauj)p1;
			p0.WritePropertyValue("X1", z0ZzZzauj2.z0eek());
			p0.WritePropertyValue("X2", z0ZzZzauj2.z0yek());
			p0.WritePropertyValue("Y1", z0ZzZzauj2.z0uek());
			p0.WritePropertyValue("Y2", z0ZzZzauj2.z0rek());
		}
	}

	private class z0ilj : z0ZzZzfgh
	{
		public override void z0sj(z0ZzZzggh p0, object p1)
		{
			p0.GetProvider(typeof(z0ZzZzhuj)).z0sj(p0, p1);
			z0ZzZzquj z0ZzZzquj2 = (z0ZzZzquj)p1;
			p0.WritePropertyValue("PointsString", z0ZzZzquj2.z0rek());
		}
	}

	private class z0olj : z0ZzZzfgh
	{
		public override void z0sj(z0ZzZzggh p0, object p1)
		{
			p0.GetProvider(typeof(z0ZzZzeuj)).z0sj(p0, p1);
			z0ZzZzwuj z0ZzZzwuj2 = (z0ZzZzwuj)p1;
			p0.WritePropertyValue("PointsString", z0ZzZzwuj2.z0eek());
		}
	}

	private class z0plj : z0ZzZzfgh
	{
		public override void z0sj(z0ZzZzggh p0, object p1)
		{
			p0.GetProvider(typeof(z0ZzZzhuj)).z0sj(p0, p1);
			z0ZzZzeuj z0ZzZzeuj2 = (z0ZzZzeuj)p1;
			p0.WritePropertyValue("Height", z0ZzZzeuj2.z0eek(), 100f);
			p0.WritePropertyValue("Left", z0ZzZzeuj2.z0rek());
			p0.WritePropertyValue("Resizeable", z0ZzZzeuj2.z0xkk(), defaultValue: true);
			p0.WritePropertyValue("Text", z0ZzZzeuj2.z0pek());
			p0.WritePropertyValue("Top", z0ZzZzeuj2.z0oek());
			p0.WritePropertyValue("Width", z0ZzZzeuj2.z0mek(), 100f);
		}
	}

	private class z0mlj : z0ZzZzfgh
	{
		public override void z0sj(z0ZzZzggh p0, object p1)
		{
			p0.GetProvider(typeof(z0ZzZzauj)).z0sj(p0, p1);
			z0ZzZzuuj z0ZzZzuuj2 = (z0ZzZzuuj)p1;
			p0.WritePropertyValue("LabelAtLeft", z0ZzZzuuj2.z0uek());
			p0.WritePropertyValue("LabelAtUp", z0ZzZzuuj2.z0yek());
			p0.WritePropertyValue("Text", z0ZzZzuuj2.z0rek());
		}
	}

	private class z0nlj : z0ZzZzfgh
	{
		public override void z0sj(z0ZzZzggh p0, object p1)
		{
			p0.GetProvider(typeof(z0ZzZzeuj)).z0sj(p0, p1);
			z0ZzZziuj z0ZzZziuj2 = (z0ZzZziuj)p1;
			p0.WritePropertyValue("SmoothZoomIn", z0ZzZziuj2.z0eek_jiejie20260327142557());
			p0.WritePropertyValue("ZoomInRate", z0ZzZziuj2.z0rek(), 2f);
		}
	}

	private class z0blj : z0ZzZzfgh
	{
		public override void z0sj(z0ZzZzggh p0, object p1)
		{
			SpecifyPageIndexInfo specifyPageIndexInfo = (SpecifyPageIndexInfo)p1;
			p0.WritePropertyValue("RawPageIndex", specifyPageIndexInfo.RawPageIndex, 1);
			p0.WritePropertyValue("SpecifyPageIndex", specifyPageIndexInfo.SpecifyPageIndex, -1);
		}
	}

	internal class z0vlj : z0ZzZzfgh
	{
		public override void z0sj(z0ZzZzggh p0, object p1)
		{
			SpecifyPageIndexInfoList specifyPageIndexInfoList = (SpecifyPageIndexInfoList)p1;
			if (specifyPageIndexInfoList == null || specifyPageIndexInfoList.Count <= 0)
			{
				return;
			}
			foreach (SpecifyPageIndexInfo item in specifyPageIndexInfoList)
			{
				p0.WritePropertyValueInstance("Item", item);
			}
		}
	}

	private class z0clj : z0ZzZzfgh
	{
		public override void z0sj(z0ZzZzggh p0, object p1)
		{
			SubDocumentSettings subDocumentSettings = (SubDocumentSettings)p1;
			p0.WritePropertyValue("AllowSave", subDocumentSettings.AllowSave, defaultValue: true);
			p0.WritePropertyValue("BackColorValue", subDocumentSettings.BackColorValue);
			p0.WritePropertyValue("BorderColorValue", subDocumentSettings.BorderColorValue);
			p0.WritePropertyValue("EnablePermission", subDocumentSettings.EnablePermission);
			p0.WritePropertyValue("Locked", subDocumentSettings.Locked);
			p0.WritePropertyValue("NewPage", subDocumentSettings.NewPage);
			p0.WritePropertyValue("Readonly", subDocumentSettings.Readonly);
			p0.WritePropertyValue("SubDocumentSpacing", subDocumentSettings.SubDocumentSpacing);
		}
	}

	private class z0xlj : z0ZzZzfgh
	{
		public override void z0sj(z0ZzZzggh p0, object p1)
		{
			z0ZzZzyhh z0ZzZzyhh2 = (z0ZzZzyhh)p1;
			p0.WritePropertyValue("ClientName", z0ZzZzyhh2.z0mek());
			p0.WritePropertyValue("Description", z0ZzZzyhh2.z0uek());
			p0.WritePropertyValue("ID", z0ZzZzyhh2.z0zek());
			p0.WritePropertyValue("Index", z0ZzZzyhh2.z0pek());
			p0.WritePropertyValue("Name", z0ZzZzyhh2.z0yek());
			p0.WritePropertyValue("Name2", z0ZzZzyhh2.z0tek());
			p0.WritePropertyValue("PermissionLevel", z0ZzZzyhh2.z0rek());
			p0.WritePropertyValue("SavedTime", z0ZzZzyhh2.z0xek());
			p0.WritePropertyValue("Tag", z0ZzZzyhh2.z0bek());
		}
	}

	internal class z0zlj : z0ZzZzfgh
	{
		public override void z0sj(z0ZzZzggh p0, object p1)
		{
			z0ZzZzuhh z0ZzZzuhh2 = (z0ZzZzuhh)p1;
			if (z0ZzZzuhh2 == null || z0ZzZzuhh2.Count <= 0)
			{
				return;
			}
			foreach (z0ZzZzyhh item in z0ZzZzuhh2)
			{
				p0.WritePropertyValueInstance("Item", item);
			}
		}
	}

	private class z0lkj : z0ZzZzfgh
	{
		public override void z0sj(z0ZzZzggh p0, object p1)
		{
			z0ZzZzsok z0ZzZzsok2 = (z0ZzZzsok)p1;
			p0.WritePropertyValue("Format", z0ZzZzsok2.Format);
			p0.WritePropertyValue("NoneText", z0ZzZzsok2.NoneText);
			p0.WritePropertyValue("Style", z0ZzZzsok2.Style, ValueFormatStyle.None);
		}
	}

	private class z0kkj : z0ZzZzfgh
	{
		public override void z0sj(z0ZzZzggh p0, object p1)
		{
			ValueValidateStyle valueValidateStyle = (ValueValidateStyle)p1;
			p0.WritePropertyValue("BinaryLength", valueValidateStyle.BinaryLength);
			p0.WritePropertyValue("CheckDecimalDigits", valueValidateStyle.CheckDecimalDigits);
			p0.WritePropertyValue("CheckMaxValue", valueValidateStyle.CheckMaxValue);
			p0.WritePropertyValue("CheckMinValue", valueValidateStyle.CheckMinValue);
			p0.WritePropertyValue("CustomMessage", valueValidateStyle.CustomMessage);
			p0.WritePropertyValue("DateTimeMaxValue", valueValidateStyle.DateTimeMaxValue);
			p0.WritePropertyValue("DateTimeMinValue", valueValidateStyle.DateTimeMinValue);
			p0.WritePropertyValue("ExcludeKeywords", valueValidateStyle.ExcludeKeywords);
			p0.WritePropertyValue("IncludeKeywords", valueValidateStyle.IncludeKeywords);
			p0.WritePropertyValue("Level", valueValidateStyle.Level, ValueValidateLevel.Error);
			p0.WritePropertyValue("MaxDecimalDigits", valueValidateStyle.MaxDecimalDigits);
			p0.WritePropertyValue("MaxLength", valueValidateStyle.MaxLength);
			p0.WritePropertyValue("MaxValue", valueValidateStyle.MaxValue);
			p0.WritePropertyValue("MinLength", valueValidateStyle.MinLength);
			p0.WritePropertyValue("MinValue", valueValidateStyle.MinValue);
			p0.WritePropertyValue("Range", valueValidateStyle.Range);
			p0.WritePropertyValue("RegExpression", valueValidateStyle.RegExpression);
			p0.WritePropertyValue("Required", valueValidateStyle.Required);
			p0.WritePropertyValue("ValueName", valueValidateStyle.ValueName);
			p0.WritePropertyValue("ValueType", valueValidateStyle.ValueType, ValueTypeStyle.Text);
		}
	}

	private class z0jkj : z0ZzZzfgh
	{
		public override void z0sj(z0ZzZzggh p0, object p1)
		{
			z0ZzZzwmk z0ZzZzwmk2 = (z0ZzZzwmk)p1;
			p0.WritePropertyValue("Alpha", z0ZzZzwmk2.Alpha, 80);
			p0.WritePropertyValue("Angle", z0ZzZzwmk2.Angle);
			p0.WritePropertyValue("BackColorValue", z0ZzZzwmk2.BackColorValue);
			p0.WritePropertyValue("ColorValue", z0ZzZzwmk2.ColorValue);
			p0.WritePropertyValue("Font", z0ZzZzwmk2.Font);
			p0.WritePropertyValue("Image", z0ZzZzwmk2.Image);
			p0.WritePropertyValue("PrintWatermark", z0ZzZzwmk2.PrintWatermark, defaultValue: true);
			p0.WritePropertyValue("Repeat", z0ZzZzwmk2.Repeat);
			p0.WritePropertyValue("ShowWatermark", z0ZzZzwmk2.ShowWatermark, defaultValue: true);
			p0.WritePropertyValue("Text", z0ZzZzwmk2.Text);
			p0.WritePropertyValue("Type", z0ZzZzwmk2.Type, WatermarkType.None);
		}
	}

	private class z0hkj : z0ZzZzfgh
	{
		public override void z0sj(z0ZzZzggh p0, object p1)
		{
			XAttribute xAttribute = (XAttribute)p1;
			p0.WritePropertyValue("Name", xAttribute.Name);
			p0.WritePropertyValue("Value", xAttribute.Value);
		}
	}

	internal class z0gkj : z0ZzZzfgh
	{
		public override void z0sj(z0ZzZzggh p0, object p1)
		{
			XAttributeList xAttributeList = (XAttributeList)p1;
			if (xAttributeList == null || xAttributeList.Count <= 0)
			{
				return;
			}
			using zzz.z0ZzZzkuk<XAttribute>.z0bpk z0bpk = xAttributeList.z0ltk();
			while (z0bpk.MoveNext())
			{
				XAttribute current = z0bpk.Current;
				p0.WritePropertyValueInstance("Item", current);
			}
		}
	}

	private class z0fkj : z0ZzZzfgh
	{
		public override void z0sj(z0ZzZzggh p0, object p1)
		{
			z0ZzZzemk z0ZzZzemk2 = (z0ZzZzemk)p1;
			p0.WritePropertyValue("Color2String", z0ZzZzemk2.z0mek());
			p0.WritePropertyValue("ColorString", z0ZzZzemk2.z0vek());
			p0.WritePropertyValue("Image", z0ZzZzemk2.z0oek());
			p0.WritePropertyValue("OffsetX", z0ZzZzemk2.z0iek());
			p0.WritePropertyValue("OffsetY", z0ZzZzemk2.z0tek());
			p0.WritePropertyValue("Repeat", z0ZzZzemk2.z0yek(), defaultValue: true);
			p0.WritePropertyValue("Style", z0ZzZzemk2.z0cek(), XBrushStyleConst.Solid);
		}
	}

	private class z0dkj : z0ZzZzfgh
	{
		public override void z0sj(z0ZzZzggh p0, object p1)
		{
			z0ZzZzymk z0ZzZzymk2 = (z0ZzZzymk)p1;
			p0.WritePropertyValue("StringValue", z0ZzZzymk2.StringValue);
		}
	}

	private class z0skj : z0ZzZzfgh
	{
		public override void z0sj(z0ZzZzggh p0, object p1)
		{
			z0ZzZzevj z0ZzZzevj2 = (z0ZzZzevj)p1;
			p0.WritePropertyValue("AutoUpdate", z0ZzZzevj2.z0yek());
			p0.WritePropertyValue("BindingPath", z0ZzZzevj2.BindingPath);
			p0.WritePropertyValue("BindingPathForText", z0ZzZzevj2.BindingPathForText);
			p0.WritePropertyValue("DataSource", z0ZzZzevj2.DataSource);
			p0.WritePropertyValue("Enabled", z0ZzZzevj2.z0eek(), defaultValue: true);
			p0.WritePropertyValue("Handled", z0ZzZzevj2.z0uek());
			p0.WritePropertyValue("ProcessState", z0ZzZzevj2.ProcessState, DCProcessStates.Always);
			p0.WritePropertyValue("Readonly", z0ZzZzevj2.z0rek());
			p0.WritePropertyValue("WriteTextBindingPath", z0ZzZzevj2.WriteTextBindingPath);
		}
	}

	private class z0akj : z0ZzZzfgh
	{
		public override void z0sj(z0ZzZzggh p0, object p1)
		{
			XPageSettings xPageSettings = (XPageSettings)p1;
			p0.WritePropertyValue("AutoChoosePageSize", xPageSettings.z0tek(), defaultValue: true);
			p0.WritePropertyValue("AutoFitPageSize", xPageSettings.z0yek());
			p0.WritePropertyValue("AutoPaperWidth", xPageSettings.z0ltk());
			p0.WritePropertyValue("BottomMargin", xPageSettings.BottomMargin, 100);
			p0.WritePropertyValue("Copies", xPageSettings.z0brk(), 1);
			p0.WritePropertyValue("DesignerPaperHeight", xPageSettings.z0crk());
			p0.WritePropertyValue("DesignerPaperWidth", xPageSettings.z0rtk());
			if (xPageSettings.DocumentGridLine != null && !p0.IsEmptyInstance(xPageSettings.DocumentGridLine))
			{
				p0.WritePropertyValueInstance("DocumentGridLine", xPageSettings.DocumentGridLine);
			}
			p0.WritePropertyValue("EditTimeBackgroundImage", xPageSettings.z0ark());
			p0.WritePropertyValue("EnableHeaderFooter", xPageSettings.z0mek(), defaultValue: true);
			p0.WritePropertyValue("FooterDistance", xPageSettings.z0utk(), 50);
			p0.WritePropertyValue("ForPOSPrinter", xPageSettings.z0vek());
			p0.WritePropertyValue("GutterPosition", xPageSettings.z0erk());
			p0.WritePropertyValue("GutterStyle", xPageSettings.z0xtk(), DCGutterStyle.Left);
			p0.WritePropertyValue("HeaderDistance", xPageSettings.z0pek(), 50);
			p0.WritePropertyValue("HeaderFooterDifferentFirstPage", xPageSettings.z0ktk());
			p0.WritePropertyValue("Landscape", xPageSettings.z0ork());
			p0.WritePropertyValue("LeftMargin", xPageSettings.LeftMargin, 100);
			p0.WritePropertyValue("OffsetX", xPageSettings.z0gtk());
			p0.WritePropertyValue("OffsetY", xPageSettings.z0srk());
			if (xPageSettings.PageBorderBackground != null && !p0.IsEmptyInstance(xPageSettings.PageBorderBackground))
			{
				p0.WritePropertyValueInstance("PageBorderBackground", xPageSettings.PageBorderBackground);
			}
			p0.WritePropertyValue("PageIndexsForHideHeaderFooter", xPageSettings.z0urk());
			p0.WritePropertyValue("PaperHeight", xPageSettings.z0jtk(), 1169);
			p0.WritePropertyValue("PaperKind", xPageSettings.z0yrk(), PaperKind.A4);
			p0.WritePropertyValue("PaperSource", xPageSettings.z0cek());
			p0.WritePropertyValue("PaperWidth", xPageSettings.z0ntk(), 827);
			p0.WritePropertyValue("PowerDocumentGridLine", xPageSettings.z0uek());
			p0.WritePropertyValue("PrinterName", xPageSettings.z0vrk());
			p0.WritePropertyValue("PrintZoomRate", xPageSettings.z0zek(), 1f);
			p0.WritePropertyValue("RightMargin", xPageSettings.RightMargin, 100);
			p0.WritePropertyValue("ShowGutterLine", xPageSettings.z0otk());
			p0.WritePropertyValue("SpecifyDuplex", xPageSettings.z0zrk(), DCDuplexType.NoSpecify);
			p0.WritePropertyValue("StrictUsePageSize", xPageSettings.z0ftk(), defaultValue: true);
			p0.WritePropertyValue("SwapGutter", xPageSettings.z0nek(), defaultValue: true);
			p0.WritePropertyValue("SwapLeftRightMargin", xPageSettings.z0itk());
			if (xPageSettings.z0xek() != null && !p0.IsEmptyInstance(xPageSettings.z0xek()))
			{
				p0.WritePropertyValueInstance("TerminalText", xPageSettings.z0xek());
			}
			p0.WritePropertyValue("TopMargin", xPageSettings.TopMargin, 100);
			if (xPageSettings.z0jrk() != null && !p0.IsEmptyInstance(xPageSettings.z0jrk()))
			{
				p0.WritePropertyValueInstance("Watermark", xPageSettings.z0jrk());
			}
		}
	}

	private class z0qkj : z0ZzZzfgh
	{
		public override void z0sj(z0ZzZzggh p0, object p1)
		{
			z0ZzZznmk z0ZzZznmk2 = (z0ZzZznmk)p1;
			p0.WritePropertyValue("Alignment", z0ZzZznmk2.Alignment, (z0ZzZzgdh)0);
			p0.WritePropertyValue("ColorString", z0ZzZznmk2.ColorString);
			p0.WritePropertyValue("DashCap", z0ZzZznmk2.DashCap, DashCap.Flat);
			p0.WritePropertyValue("DashStyle", z0ZzZznmk2.DashStyle, DashStyle.Solid);
			p0.WritePropertyValue("EndCap", z0ZzZznmk2.EndCap, (z0ZzZzldh)0);
			p0.WritePropertyValue("LineJoin", z0ZzZznmk2.LineJoin, (z0ZzZzkdh)1);
			p0.WritePropertyValue("MiterLimit", z0ZzZznmk2.MiterLimit, 10f);
			p0.WritePropertyValue("StartCap", z0ZzZznmk2.StartCap, (z0ZzZzldh)0);
			p0.WritePropertyValue("Width", z0ZzZznmk2.Width, 1f);
		}
	}

	private class z0wkj : z0ZzZzfgh
	{
		public override void z0sj(z0ZzZzggh p0, object p1)
		{
			p0.GetProvider(typeof(XTextElement)).z0sj(p0, p1);
			z0ZzZzolh z0ZzZzolh2 = (z0ZzZzolh)p1;
			p0.WritePropertyValue("Name", z0ZzZzolh2.Name);
		}
	}

	private class z0ekj : z0ZzZzfgh
	{
		public override void z0sj(z0ZzZzggh p0, object p1)
		{
			p0.GetProvider(typeof(XTextObjectElement)).z0sj(p0, p1);
			XTextButtonElement xTextButtonElement = (XTextButtonElement)p1;
			p0.WritePropertyValue("AutoSize", xTextButtonElement.AutoSize);
			p0.WritePropertyValue("CommandName", xTextButtonElement.CommandName);
			p0.WritePropertyValue("Image", xTextButtonElement.Image);
			p0.WritePropertyValue("ImageForDown", xTextButtonElement.ImageForDown);
			p0.WritePropertyValue("ImageForMouseOver", xTextButtonElement.ImageForMouseOver);
			p0.WritePropertyValue("PrintAsText", xTextButtonElement.PrintAsText);
			p0.WritePropertyValue("ScriptTextForClick", xTextButtonElement.ScriptTextForClick);
		}
	}

	private class z0rkj : z0ZzZzfgh
	{
		public override void z0sj(z0ZzZzggh p0, object p1)
		{
			p0.GetProvider(typeof(XTextObjectElement)).z0sj(p0, p1);
			XTextChartElement xTextChartElement = (XTextChartElement)p1;
			if (xTextChartElement.z0tek() != null && !p0.IsEmptyInstance(xTextChartElement.z0tek()))
			{
				p0.WritePropertyValueInstance("ChartStyle", xTextChartElement.z0tek());
			}
			p0.WritePropertyValue("DataFieldNameForGroupName", xTextChartElement.z0yek());
			p0.WritePropertyValue("DataFieldNameForLink", xTextChartElement.z0oek());
			p0.WritePropertyValue("DataFieldNameForSeriesName", xTextChartElement.z0cek());
			p0.WritePropertyValue("DataFieldNameForText", xTextChartElement.z0mek());
			p0.WritePropertyValue("DataFieldNameForTipText", xTextChartElement.z0uek());
			p0.WritePropertyValue("DataFieldNameForValue", xTextChartElement.z0pek());
			if (xTextChartElement.z0bek() != null && xTextChartElement.z0bek().Count > 0)
			{
				p0.WritePropertyValueInstance("DataItems", xTextChartElement.z0bek());
			}
			p0.WritePropertyValue("DataSourceName", xTextChartElement.z0iek());
		}
	}

	private sealed class z0tkj_jiejie20260327142557 : z0ZzZzfgh
	{
		public override void z0sj(z0ZzZzggh p0, object p1)
		{
			p0.GetProvider(typeof(XTextCheckBoxElementBase)).z0sj(p0, p1);
			XTextCheckBoxElement xTextCheckBoxElement = (XTextCheckBoxElement)p1;
			p0.WritePropertyValue("ControlStyle", xTextCheckBoxElement.z0oi(), CheckBoxControlStyle.CheckBox);
		}
	}

	private class z0ykj : z0ZzZzfgh
	{
		public override void z0sj(z0ZzZzggh p0, object p1)
		{
			p0.GetProvider(typeof(XTextObjectElement)).z0sj(p0, p1);
			XTextCheckBoxElementBase xTextCheckBoxElementBase = (XTextCheckBoxElementBase)p1;
			p0.WritePropertyValue("BringoutToSave", xTextCheckBoxElementBase.BringoutToSave);
			p0.WritePropertyValue("CanBeReferenced", xTextCheckBoxElementBase.CanBeReferenced);
			p0.WritePropertyValue("Caption", xTextCheckBoxElementBase.Caption);
			p0.WritePropertyValue("CaptionAlign", xTextCheckBoxElementBase.CaptionAlign, StringAlignment.Center);
			p0.WritePropertyValue("CheckAlignLeft", xTextCheckBoxElementBase.CheckAlignLeft, defaultValue: true);
			p0.WritePropertyValue("CheckboxVisibility", xTextCheckBoxElementBase.CheckboxVisibility, RenderVisibility.All);
			p0.WritePropertyValue("CheckBoxVisible", xTextCheckBoxElementBase.CheckBoxVisible, defaultValue: true);
			p0.WritePropertyValue("Checked", xTextCheckBoxElementBase.Checked);
			p0.WritePropertyValue("CheckedValue", xTextCheckBoxElementBase.CheckedValue);
			p0.WritePropertyValue("ControlStyle", xTextCheckBoxElementBase.z0oi(), CheckBoxControlStyle.CheckBox);
			p0.WritePropertyValue("DataName", xTextCheckBoxElementBase.DataName);
			p0.WritePropertyValue("DefaultCheckedForValueBinding", xTextCheckBoxElementBase.DefaultCheckedForValueBinding);
			p0.WritePropertyValue("EnableHighlight", xTextCheckBoxElementBase.EnableHighlight, EnableState.Enabled);
			if (xTextCheckBoxElementBase.z0uek() != null && xTextCheckBoxElementBase.z0uek().Count > 0)
			{
				p0.WritePropertyValueInstance("EventExpressions", xTextCheckBoxElementBase.z0uek());
			}
			p0.WritePropertyValue("GroupName", xTextCheckBoxElementBase.GroupName);
			p0.WritePropertyValue("Multiline", xTextCheckBoxElementBase.Multiline);
			p0.WritePropertyValue("PrintTextForChecked", xTextCheckBoxElementBase.PrintTextForChecked);
			p0.WritePropertyValue("PrintTextForUnChecked", xTextCheckBoxElementBase.PrintTextForUnChecked);
			p0.WritePropertyValue("PrintVisibilityWhenUnchecked", xTextCheckBoxElementBase.PrintVisibilityWhenUnchecked, PrintVisibilityModeWhenUnchecked.Visible);
			p0.WritePropertyValue("Readonly", xTextCheckBoxElementBase.Readonly);
			p0.WritePropertyValue("Requried", xTextCheckBoxElementBase.Requried);
			p0.WritePropertyValue("ToolTip", xTextCheckBoxElementBase.ToolTip);
			if (xTextCheckBoxElementBase.ValueBinding != null && !p0.IsEmptyInstance(xTextCheckBoxElementBase.ValueBinding))
			{
				p0.WritePropertyValueInstance("ValueBinding", xTextCheckBoxElementBase.ValueBinding);
			}
			p0.WritePropertyValue("VisualStyle", xTextCheckBoxElementBase.VisualStyle, CheckBoxVisualStyle.Default);
		}
	}

	private class z0ukj : z0ZzZzfgh
	{
		public override void z0sj(z0ZzZzggh p0, object p1)
		{
			p0.GetProvider(typeof(XTextElement)).z0sj(p0, p1);
			XTextContainerElement xTextContainerElement = (XTextContainerElement)p1;
			p0.WritePropertyValue("AcceptChildElementTypes2", xTextContainerElement.AcceptChildElementTypes2, ElementType.All);
			p0.WritePropertyValue("AcceptTab", xTextContainerElement.AcceptTab);
			if (xTextContainerElement.Attributes != null && xTextContainerElement.Attributes.Count > 0)
			{
				p0.WritePropertyValueInstance("Attributes", xTextContainerElement.Attributes);
			}
			p0.WritePropertyValue("BringoutToSave", xTextContainerElement.z0dt());
			p0.WritePropertyValue("CanBeReferenced", xTextContainerElement.z0gt());
			if (xTextContainerElement.ContentLock != null && !p0.IsEmptyInstance(xTextContainerElement.ContentLock))
			{
				p0.WritePropertyValueInstance("ContentLock", xTextContainerElement.ContentLock);
			}
			p0.WritePropertyValue("ContentReadonly", xTextContainerElement.ContentReadonly, ContentReadonlyState.Inherit);
			p0.WritePropertyValue("ContentReadonlyExpression", xTextContainerElement.ContentReadonlyExpression);
			if (xTextContainerElement.CopySource != null && !p0.IsEmptyInstance(xTextContainerElement.CopySource))
			{
				p0.WritePropertyValueInstance("CopySource", xTextContainerElement.CopySource);
			}
			p0.WritePropertyValue("DataName", xTextContainerElement.z0ht());
			p0.WritePropertyValue("Deleteable", xTextContainerElement.Deleteable, defaultValue: true);
			if (xTextContainerElement.z0be() != null && xTextContainerElement.z0be().Count > 0)
			{
				p0.WritePropertyValueInstance("ElementsForSerialize", xTextContainerElement.z0be());
			}
			p0.WritePropertyValue("EnablePermission", xTextContainerElement.EnablePermission, DCBooleanValue.Inherit);
			p0.WritePropertyValue("EnableValueValidate", xTextContainerElement.EnableValueValidate);
			p0.WritePropertyValue("HiddenPrintWhenEmpty", xTextContainerElement.HiddenPrintWhenEmpty);
			p0.WritePropertyValue("LimitedInputChars", xTextContainerElement.LimitedInputChars);
			p0.WritePropertyValue("PrintVisibility", xTextContainerElement.PrintVisibility, ElementVisibility.Visible);
			if (xTextContainerElement.PropertyExpressions != null && xTextContainerElement.PropertyExpressions.Count > 0)
			{
				p0.WritePropertyValueInstance("PropertyExpressions", xTextContainerElement.PropertyExpressions);
			}
			p0.WritePropertyValue("ToolTip", xTextContainerElement.ToolTip);
			if (xTextContainerElement.ValidateStyle != null && !p0.IsEmptyInstance(xTextContainerElement.ValidateStyle))
			{
				p0.WritePropertyValueInstance("ValidateStyle", xTextContainerElement.ValidateStyle);
			}
			if (xTextContainerElement.ValueBinding != null && !p0.IsEmptyInstance(xTextContainerElement.ValueBinding))
			{
				p0.WritePropertyValueInstance("ValueBinding", xTextContainerElement.ValueBinding);
			}
			p0.WritePropertyValue("ValueExpression", xTextContainerElement.ValueExpression);
			p0.WritePropertyValue("VisibleExpression", xTextContainerElement.VisibleExpression);
		}
	}

	private class z0ikj : z0ZzZzfgh
	{
		public override void z0sj(z0ZzZzggh p0, object p1)
		{
			p0.GetProvider(typeof(XTextContainerElement)).z0sj(p0, p1);
			XTextContentElement xTextContentElement = (XTextContentElement)p1;
			if (xTextContentElement.GridLine != null && !p0.IsEmptyInstance(xTextContentElement.GridLine))
			{
				p0.WritePropertyValueInstance("GridLine", xTextContentElement.GridLine);
			}
			p0.WritePropertyValue("SpecifyFixedLineHeight", xTextContentElement.SpecifyFixedLineHeight);
		}
	}

	private class z0okj : z0ZzZzfgh
	{
		public override void z0sj(z0ZzZzggh p0, object p1)
		{
			p0.GetProvider(typeof(XTextObjectElement)).z0sj(p0, p1);
			XTextControlHostElement xTextControlHostElement = (XTextControlHostElement)p1;
			p0.WritePropertyValue("AllowUserResize", xTextControlHostElement.AllowUserResize, ResizeableType.WidthAndHeight);
			p0.WritePropertyValue("ControlType", xTextControlHostElement.z0ry(), (z0ZzZzrxj)0);
			p0.WritePropertyValue("DelayLoadControl", xTextControlHostElement.DelayLoadControl);
			p0.WritePropertyValue("HostMode", xTextControlHostElement.z0uek(), (z0ZzZzgzj)2);
			p0.WritePropertyValue("OptionsPropertyName", xTextControlHostElement.z0iek());
			if (xTextControlHostElement.Parameters != null && xTextControlHostElement.Parameters.Count > 0)
			{
				p0.WritePropertyValueInstance("Parameters", xTextControlHostElement.Parameters);
			}
			p0.WritePropertyValue("PreviewImageData", xTextControlHostElement.z0tek());
			p0.WritePropertyValue("SavePreviewImage", xTextControlHostElement.z0yek());
			p0.WritePropertyValue("TypeFullName", xTextControlHostElement.TypeFullName);
			p0.WritePropertyValue("ValuePropertyName", xTextControlHostElement.ValuePropertyName);
		}
	}

	private sealed class z0pkj : z0ZzZzfgh
	{
		public override void z0sj(z0ZzZzggh p0, object p1)
		{
			p0.GetProvider(typeof(XTextObjectElement)).z0sj(p0, p1);
			XTextCustomShapeElement xTextCustomShapeElement = (XTextCustomShapeElement)p1;
			p0.WritePropertyValue("ChartPageIndex", xTextCustomShapeElement.z0eek());
			p0.WritePropertyValue("DrawContentHandlerName", xTextCustomShapeElement.z0tek());
		}
	}

	private class z0mkj : z0ZzZzfgh
	{
		public override void z0sj(z0ZzZzggh p0, object p1)
		{
			p0.GetProvider(typeof(XTextInputFieldElementBase)).z0sj(p0, p1);
			XTextDirectoryFieldElement xTextDirectoryFieldElement = (XTextDirectoryFieldElement)p1;
			p0.WritePropertyValue("DisplayLevel", xTextDirectoryFieldElement.DisplayLevel, 3);
			p0.WritePropertyValue("ShowPageIndex", xTextDirectoryFieldElement.ShowPageIndex, defaultValue: true);
		}
	}

	private sealed class z0nkj : z0ZzZzfgh
	{
		public override void z0sj(z0ZzZzggh p0, object p1)
		{
			p0.GetProvider(typeof(XTextContainerElement)).z0sj(p0, p1);
			XTextDocument xTextDocument = (XTextDocument)p1;
			p0.WritePropertyValue("BodyText", xTextDocument.z0xuk());
			if (xTextDocument.Comments != null && xTextDocument.Comments.Count > 0)
			{
				p0.WritePropertyValueInstance("Comments", xTextDocument.Comments);
			}
			if (xTextDocument.z0gnk() != null && !p0.IsEmptyInstance(xTextDocument.z0gnk()))
			{
				p0.WritePropertyValueInstance("ContentStyles", xTextDocument.z0gnk());
			}
			p0.WritePropertyValue("EditorVersionString", xTextDocument.z0mmk());
			p0.WritePropertyValue("FileFormat", xTextDocument.z0ftk());
			p0.WritePropertyValue("FileName", xTextDocument.z0amk());
			if (xTextDocument.z0ipk() != null && !p0.IsEmptyInstance(xTextDocument.z0ipk()))
			{
				p0.WritePropertyValueInstance("Info", xTextDocument.z0ipk());
			}
			p0.WritePropertyValue("LocalExcludeKeywords", xTextDocument.z0tuk());
			p0.WritePropertyValue("MeasureMode", xTextDocument.z0fnk(), MeasureMode.Default);
			if (xTextDocument.PageSettings != null && !p0.IsEmptyInstance(xTextDocument.PageSettings))
			{
				p0.WritePropertyValueInstance("PageSettings", xTextDocument.PageSettings);
			}
			if (xTextDocument.z0gpk() != null && xTextDocument.z0gpk().Count > 0)
			{
				p0.WritePropertyValueInstance("Parameters", xTextDocument.z0gpk());
			}
			if (xTextDocument.z0nmk() != null && xTextDocument.z0nmk().Count > 0)
			{
				p0.WritePropertyValueInstance("RepeatedImages", xTextDocument.z0nmk());
			}
			p0.WritePropertyValue("SpecialTag", xTextDocument.z0tnk());
			if (xTextDocument.z0syk() != null && xTextDocument.z0syk().Count > 0)
			{
				p0.WritePropertyValueInstance("UserHistories", xTextDocument.z0syk());
			}
		}
	}

	private class z0bkj : z0ZzZzfgh
	{
		public override void z0sj(z0ZzZzggh p0, object p1)
		{
			XTextElement xTextElement = (XTextElement)p1;
			if (xTextElement.Attributes != null && xTextElement.Attributes.Count > 0)
			{
				p0.WritePropertyValueInstance("Attributes", xTextElement.Attributes);
			}
			p0.WritePropertyValue("ID", xTextElement.ID);
			p0.WritePropertyValue("StyleIndex", xTextElement.z0pek(), -1);
		}
	}

	internal class z0vkj : z0ZzZzfgh
	{
		public override void z0sj(z0ZzZzggh p0, object p1)
		{
			XTextElementList xTextElementList = (XTextElementList)p1;
			if (xTextElementList == null || xTextElementList.Count <= 0)
			{
				return;
			}
			using zzz.z0ZzZzkuk<XTextElement>.z0bpk z0bpk = xTextElementList.z0ltk();
			while (z0bpk.MoveNext())
			{
				XTextElement current = z0bpk.Current;
				p0.WritePropertyValueInstance("Item", current);
			}
		}
	}

	private class z0ckj : z0ZzZzfgh
	{
		public override void z0sj(z0ZzZzggh p0, object p1)
		{
			p0.GetProvider(typeof(XTextContainerElement)).z0sj(p0, p1);
			XTextFieldElementBase xTextFieldElementBase = (XTextFieldElementBase)p1;
			p0.WritePropertyValue("BackgroundTextColorString", xTextFieldElementBase.BackgroundTextColorString);
			p0.WritePropertyValue("BackgroundTextItalic", xTextFieldElementBase.z0drk(), DCBooleanValueHasDefault.Default);
			p0.WritePropertyValue("BorderElementColor", xTextFieldElementBase.BorderElementColor, Color.Empty);
			p0.WritePropertyValue("BorderElementColorValue", xTextFieldElementBase.BorderElementColorValue);
			p0.WritePropertyValue("EndBorderText", xTextFieldElementBase.EndBorderText);
			p0.WritePropertyValue("EndingLineBreak", xTextFieldElementBase.EndingLineBreak);
			p0.WritePropertyValue("StartBorderText", xTextFieldElementBase.StartBorderText);
			p0.WritePropertyValue("TextColorString", xTextFieldElementBase.TextColorString);
		}
	}

	private class z0xkj : z0ZzZzfgh
	{
		public override void z0sj(z0ZzZzggh p0, object p1)
		{
			p0.GetProvider(typeof(XTextObjectElement)).z0sj(p0, p1);
			XTextHorizontalLineElement xTextHorizontalLineElement = (XTextHorizontalLineElement)p1;
			p0.WritePropertyValue("LineLengthInCM", xTextHorizontalLineElement.LineLengthInCM);
			p0.WritePropertyValue("LineSize", xTextHorizontalLineElement.LineSize, 1f);
		}
	}

	private sealed class z0zkj : z0ZzZzfgh
	{
		public override void z0sj(z0ZzZzggh p0, object p1)
		{
			p0.GetProvider(typeof(XTextObjectElement)).z0sj(p0, p1);
			XTextImageElement xTextImageElement = (XTextImageElement)p1;
			if (xTextImageElement.z0brk() != null && !p0.IsEmptyInstance(xTextImageElement.z0brk()))
			{
				p0.WritePropertyValueInstance("AdditionShape", xTextImageElement.z0brk());
			}
			p0.WritePropertyValue("AdditionShapeFixSize", xTextImageElement.z0jrk());
			p0.WritePropertyValue("Alt", xTextImageElement.z0tek());
			p0.WritePropertyValue("CustomAdditionShapeContent", xTextImageElement.z0yrk());
			p0.WritePropertyValue("EnableEditImageAdditionShape", xTextImageElement.EnableEditImageAdditionShape, defaultValue: true);
			p0.WritePropertyValue("EnableRepeatedImage", xTextImageElement.z0mrk());
			p0.WritePropertyValue("Image", xTextImageElement.z0frk());
			p0.WritePropertyValue("KeepWidthHeightRate", xTextImageElement.KeepWidthHeightRate, defaultValue: true);
			if (xTextImageElement.z0hrk() != null && xTextImageElement.z0hrk().Count > 0)
			{
				p0.WritePropertyValueInstance("PageImages", xTextImageElement.z0hrk());
			}
			p0.WritePropertyValue("SaveContentInFile", xTextImageElement.SaveContentInFile, defaultValue: true);
			p0.WritePropertyValue("SmoothZoom", xTextImageElement.SmoothZoom, defaultValue: true);
			p0.WritePropertyValue("Source", xTextImageElement.z0mek());
			p0.WritePropertyValue("Title", xTextImageElement.z0vrk());
			p0.WritePropertyValue("TransparentColorValue", xTextImageElement.TransparentColorValue);
			p0.WritePropertyValue("VAlign", xTextImageElement.VAlign, VerticalAlignStyle.Bottom);
			p0.WritePropertyValue("ValueIndexOfRepeatedImage", xTextImageElement.z0cek(), -1);
		}
	}

	private class z0ljj : z0ZzZzfgh
	{
		public override void z0sj(z0ZzZzggh p0, object p1)
		{
			p0.GetProvider(typeof(XTextInputFieldElementBase)).z0sj(p0, p1);
			XTextInputFieldElement xTextInputFieldElement = (XTextInputFieldElement)p1;
			p0.WritePropertyValue("AdornTextType", xTextInputFieldElement.z0rek(), InputFieldAdornTextType.Default);
			p0.WritePropertyValue("AutoSetSpellCodeInDropdownList", xTextInputFieldElement.z0pek());
			p0.WritePropertyValue("CustomValueEditorTypeName", xTextInputFieldElement.z0drk());
			p0.WritePropertyValue("EditorActiveMode", xTextInputFieldElement.EditorActiveMode, ValueEditorActiveMode.Program | ValueEditorActiveMode.F2 | ValueEditorActiveMode.MouseDblClick);
			p0.WritePropertyValue("EditorControlTypeName", xTextInputFieldElement.z0xek());
			p0.WritePropertyValue("EnableFieldTextColor", xTextInputFieldElement.z0eek(), defaultValue: true);
			p0.WritePropertyValue("EnableUserEditInnerValue", xTextInputFieldElement.z0vek(), defaultValue: true);
			p0.WritePropertyValue("EnableValueEditor", xTextInputFieldElement.z0yek(), defaultValue: true);
			if (xTextInputFieldElement.FieldSettings != null && !p0.IsEmptyInstance(xTextInputFieldElement.FieldSettings))
			{
				p0.WritePropertyValueInstance("FieldSettings", xTextInputFieldElement.FieldSettings);
			}
			p0.WritePropertyValue("FormButtonStyle", xTextInputFieldElement.z0iek(), FormButtonStyle.Auto);
			if (xTextInputFieldElement.z0nek() != null && !p0.IsEmptyInstance(xTextInputFieldElement.z0nek()))
			{
				p0.WritePropertyValueInstance("LinkListBinding", xTextInputFieldElement.z0nek());
			}
			p0.WritePropertyValue("ShowFormButton", xTextInputFieldElement.z0krk(), DCBooleanValue.Inherit);
			p0.WritePropertyValue("ShowInputFieldStateTag", xTextInputFieldElement.z0frk(), DCBooleanValue.Inherit);
		}
	}

	private class z0kjj : z0ZzZzfgh
	{
		public override void z0sj(z0ZzZzggh p0, object p1)
		{
			p0.GetProvider(typeof(XTextFieldElementBase)).z0sj(p0, p1);
			XTextInputFieldElementBase xTextInputFieldElementBase = (XTextInputFieldElementBase)p1;
			p0.WritePropertyValue("Alignment", xTextInputFieldElementBase.Alignment, StringAlignment.Near);
			p0.WritePropertyValue("BackgroundText", xTextInputFieldElementBase.BackgroundText);
			p0.WritePropertyValue("BorderTextPosition", xTextInputFieldElementBase.z0oek(), (z0ZzZzscj)1);
			p0.WritePropertyValue("BorderVisible", xTextInputFieldElementBase.BorderVisible, DCVisibleState.Default);
			if (xTextInputFieldElementBase.DisplayFormat != null && !p0.IsEmptyInstance(xTextInputFieldElementBase.DisplayFormat))
			{
				p0.WritePropertyValueInstance("DisplayFormat", xTextInputFieldElementBase.DisplayFormat);
			}
			p0.WritePropertyValue("EnableHighlight", xTextInputFieldElementBase.EnableHighlight, EnableState.Enabled);
			p0.WritePropertyValue("EnableValueValidate", xTextInputFieldElementBase.EnableValueValidate, defaultValue: true);
			p0.WritePropertyValue("DefaultEventExpression", xTextInputFieldElementBase.DefaultEventExpression);
			if (xTextInputFieldElementBase.EventExpressions != null && xTextInputFieldElementBase.EventExpressions.Count > 0)
			{
				p0.WritePropertyValueInstance("EventExpressions", xTextInputFieldElementBase.EventExpressions);
			}
			p0.WritePropertyValue("FastInputMode", xTextInputFieldElementBase.z0rek(), DCFastInputMode.NextField);
			p0.WritePropertyValue("InnerValue", xTextInputFieldElementBase.InnerValue);
			p0.WritePropertyValue("LabelText", xTextInputFieldElementBase.LabelText);
			p0.WritePropertyValue("MoveFocusHotKey", xTextInputFieldElementBase.MoveFocusHotKey, MoveFocusHotKeys.Default);
			p0.WritePropertyValue("Name", xTextInputFieldElementBase.Name);
			p0.WritePropertyValue("PrintBackgroundText", xTextInputFieldElementBase.z0cek(), DCBooleanValue.Inherit);
			p0.WritePropertyValue("SpecifyWidth", xTextInputFieldElementBase.SpecifyWidth);
			p0.WritePropertyValue("TabIndex", xTextInputFieldElementBase.TabIndex);
			p0.WritePropertyValue("TabStop", xTextInputFieldElementBase.TabStop, defaultValue: true);
			p0.WritePropertyValue("UnitText", xTextInputFieldElementBase.UnitText);
			p0.WritePropertyValue("UserEditable", xTextInputFieldElementBase.UserEditable, defaultValue: true);
			p0.WritePropertyValue("ViewEncryptType", xTextInputFieldElementBase.ViewEncryptType, ContentViewEncryptType.None);
		}
	}

	private sealed class z0jjj : z0ZzZzfgh
	{
		public override void z0sj(z0ZzZzggh p0, object p1)
		{
			p0.GetProvider(typeof(XTextLabelElementBase)).z0sj(p0, p1);
			XTextLabelElement xTextLabelElement = (XTextLabelElement)p1;
			p0.WritePropertyValue("Alignment", xTextLabelElement.Alignment, DCContentAlignment.MiddleCenter);
			p0.WritePropertyValue("AllowUserEditCurrentPageLabelText", xTextLabelElement.AllowUserEditCurrentPageLabelText);
			p0.WritePropertyValue("AttributeNameForContactAction", xTextLabelElement.AttributeNameForContactAction);
			p0.WritePropertyValue("AutoSize", xTextLabelElement.AutoSize, defaultValue: true);
			p0.WritePropertyValue("ContactAction", xTextLabelElement.ContactAction, LabelTextContactActionMode.Disable);
			p0.WritePropertyValue("LinkTextForContactAction", xTextLabelElement.LinkTextForContactAction);
			p0.WritePropertyValue("Multiline", xTextLabelElement.Multiline, defaultValue: true);
			p0.WritePropertyValue("ReferencedTopicID", xTextLabelElement.z0rek(), -1);
		}
	}

	private class z0hjj : z0ZzZzfgh
	{
		public override void z0sj(z0ZzZzggh p0, object p1)
		{
			p0.GetProvider(typeof(XTextObjectElement)).z0sj(p0, p1);
			XTextLabelElementBase xTextLabelElementBase = (XTextLabelElementBase)p1;
			if (xTextLabelElementBase.PageTexts != null && xTextLabelElementBase.PageTexts.Count > 0)
			{
				p0.WritePropertyValueInstance("PageTexts", xTextLabelElementBase.PageTexts);
			}
			p0.WritePropertyValue("StrictMatchPageIndex", xTextLabelElementBase.StrictMatchPageIndex);
			if (xTextLabelElementBase.ValueBinding != null && !p0.IsEmptyInstance(xTextLabelElementBase.ValueBinding))
			{
				p0.WritePropertyValueInstance("ValueBinding", xTextLabelElementBase.ValueBinding);
			}
		}
	}

	private sealed class z0gjj : z0ZzZzfgh
	{
		public override void z0sj(z0ZzZzggh p0, object p1)
		{
			p0.GetProvider(typeof(XTextControlHostElement)).z0sj(p0, p1);
			XTextMediaElement xTextMediaElement = (XTextMediaElement)p1;
			p0.WritePropertyValue("CsMediaPlayer", xTextMediaElement.z0rek(), defaultValue: true);
			p0.WritePropertyValue("EnableMediaContextMenu", xTextMediaElement.EnableMediaContextMenu, defaultValue: true);
			p0.WritePropertyValue("FileContentType", xTextMediaElement.FileContentType);
			p0.WritePropertyValue("FileName", xTextMediaElement.FileName);
			p0.WritePropertyValue("FileSystemName", xTextMediaElement.FileSystemName);
			p0.WritePropertyValue("LoopPlay", xTextMediaElement.LoopPlay);
			p0.WritePropertyValue("PlayerUIMode", xTextMediaElement.PlayerUIMode, WindowsMediaPlayerUIMode.mini);
			p0.WritePropertyValue("VAlign", xTextMediaElement.VAlign, VerticalAlignStyle.Bottom);
		}
	}

	private sealed class z0fjj : z0ZzZzfgh
	{
		public override void z0sj(z0ZzZzggh p0, object p1)
		{
			p0.GetProvider(typeof(XTextLabelElementBase)).z0sj(p0, p1);
			XTextNewBarcodeElement xTextNewBarcodeElement = (XTextNewBarcodeElement)p1;
			p0.WritePropertyValue("BarcodeStyle2", xTextNewBarcodeElement.BarcodeStyle2, DCBarcodeStyle.Code128C);
			p0.WritePropertyValue("ShowText", xTextNewBarcodeElement.ShowText, defaultValue: true);
			p0.WritePropertyValue("TextAlignment", xTextNewBarcodeElement.TextAlignment, StringAlignment.Center);
		}
	}

	private class z0djj : z0ZzZzfgh
	{
		public override void z0sj(z0ZzZzggh p0, object p1)
		{
			p0.GetProvider(typeof(XTextElement)).z0sj(p0, p1);
			XTextObjectElement xTextObjectElement = (XTextObjectElement)p1;
			if (xTextObjectElement.Attributes != null && xTextObjectElement.Attributes.Count > 0)
			{
				p0.WritePropertyValueInstance("Attributes", xTextObjectElement.Attributes);
			}
			p0.WritePropertyValue("ContentReadonly", xTextObjectElement.ContentReadonly, ContentReadonlyState.Inherit);
			p0.WritePropertyValue("Deleteable", xTextObjectElement.Deleteable, defaultValue: true);
			p0.WritePropertyValue("Enabled", xTextObjectElement.Enabled, defaultValue: true);
			if (xTextObjectElement.z0iek() != null && !p0.IsEmptyInstance(xTextObjectElement.z0iek()))
			{
				p0.WritePropertyValueInstance("LinkInfo", xTextObjectElement.z0iek());
			}
			p0.WritePropertyValue("Name", xTextObjectElement.Name);
			p0.WritePropertyValue("OffsetX", xTextObjectElement.OffsetX);
			p0.WritePropertyValue("OffsetY", xTextObjectElement.OffsetY);
			p0.WritePropertyValue("PrintVisibility", xTextObjectElement.PrintVisibility, ElementVisibility.Visible);
			if (xTextObjectElement.PropertyExpressions != null && xTextObjectElement.PropertyExpressions.Count > 0)
			{
				p0.WritePropertyValueInstance("PropertyExpressions", xTextObjectElement.PropertyExpressions);
			}
			p0.WritePropertyValue("StringTag", xTextObjectElement.StringTag);
			p0.WritePropertyValue("ToolTip", xTextObjectElement.ToolTip);
			p0.WritePropertyValue("ValueExpression", xTextObjectElement.ValueExpression);
			p0.WritePropertyValue("ZOrderStyle", xTextObjectElement.ZOrderStyle, ElementZOrderStyle.Normal);
		}
	}

	private sealed class z0sjj : z0ZzZzfgh
	{
		public override void z0sj(z0ZzZzggh p0, object p1)
		{
			p0.GetProvider(typeof(XTextObjectElement)).z0sj(p0, p1);
			XTextPageInfoElement xTextPageInfoElement = (XTextPageInfoElement)p1;
			p0.WritePropertyValue("AutoHeight", xTextPageInfoElement.AutoHeight);
			p0.WritePropertyValue("ChangePageIndexMidway", xTextPageInfoElement.ChangePageIndexMidway, defaultValue: true);
			p0.WritePropertyValue("DisplayFormat", xTextPageInfoElement.DisplayFormat, ParagraphListStyle.ListNumberStyle);
			p0.WritePropertyValue("FormatString", xTextPageInfoElement.FormatString);
			p0.WritePropertyValue("PageIndexFix", xTextPageInfoElement.PageIndexFix);
			if (xTextPageInfoElement.SpecifyPageIndexs != null && xTextPageInfoElement.SpecifyPageIndexs.Count > 0)
			{
				p0.WritePropertyValueInstance("SpecifyPageIndexs", xTextPageInfoElement.SpecifyPageIndexs);
			}
			p0.WritePropertyValue("SpecifyPageIndexTextList", xTextPageInfoElement.SpecifyPageIndexTextList);
			p0.WritePropertyValue("ValueType", xTextPageInfoElement.ValueType, PageInfoValueType.PageIndex);
		}
	}

	private sealed class z0ajj : z0ZzZzfgh
	{
		public override void z0sj(z0ZzZzggh p0, object p1)
		{
			p0.GetProvider(typeof(XTextElement)).z0sj(p0, p1);
			XTextParagraphFlagElement xTextParagraphFlagElement = (XTextParagraphFlagElement)p1;
			p0.WritePropertyValue("AutoCreate", xTextParagraphFlagElement.z0vek());
			p0.WritePropertyValue("ResetListIndexFlag", xTextParagraphFlagElement.z0jrk());
			p0.WritePropertyValue("TopicID", xTextParagraphFlagElement.z0krk(), -1);
		}
	}

	private class z0qjj : z0ZzZzfgh
	{
		public override void z0sj(z0ZzZzggh p0, object p1)
		{
			p0.GetProvider(typeof(XTextContentElement)).z0sj(p0, p1);
			XTextSectionElement xTextSectionElement = (XTextSectionElement)p1;
			p0.WritePropertyValue("AcceptTab", xTextSectionElement.AcceptTab, defaultValue: true);
			p0.WritePropertyValue("CompressOwnerLineSpacing", xTextSectionElement.CompressOwnerLineSpacing);
			p0.WritePropertyValue("EnableCollapse", xTextSectionElement.EnableCollapse);
			p0.WritePropertyValue("ExpendForDataBinding", xTextSectionElement.ExpendForDataBinding, defaultValue: true);
			p0.WritePropertyValue("ForeColorForCollapsed", xTextSectionElement.ForeColorForCollapsed, Color.Gray);
			p0.WritePropertyValue("ForeColorValueForCollapsed", xTextSectionElement.ForeColorValueForCollapsed);
			p0.WritePropertyValue("InsertEmptyPageForNewPage", xTextSectionElement.InsertEmptyPageForNewPage);
			if (z0eek == 1)
			{
				p0.WritePropertyValue("IsCollapsed", xTextSectionElement.IsCollapsed);
			}
			p0.WritePropertyValue("Name", xTextSectionElement.Name);
			p0.WritePropertyValue("NewPage", xTextSectionElement.NewPage);
			p0.WritePropertyValue("SpecifyHeight", xTextSectionElement.SpecifyHeight);
			p0.WritePropertyValue("Title", xTextSectionElement.Title);
		}
	}

	private sealed class z0wjj : z0ZzZzfgh
	{
		public override void z0sj(z0ZzZzggh p0, object p1)
		{
			p0.GetProvider(typeof(XTextObjectElement)).z0sj(p0, p1);
			XTextSignImageElement xTextSignImageElement = (XTextSignImageElement)p1;
			p0.WritePropertyValue("DefaultSignMode", xTextSignImageElement.DefaultSignMode, DCCASignMode.Normal);
			p0.WritePropertyValue("ImageData", xTextSignImageElement.ImageData);
			p0.WritePropertyValue("LastVerifyResult", xTextSignImageElement.LastVerifyResult);
			p0.WritePropertyValue("SignClientName", xTextSignImageElement.SignClientName);
			p0.WritePropertyValue("SignErrorMessage", xTextSignImageElement.SignErrorMessage);
			p0.WritePropertyValue("SignMessage", xTextSignImageElement.SignMessage);
			p0.WritePropertyValue("SignProviderName", xTextSignImageElement.SignProviderName);
			p0.WritePropertyValue("SignRange", xTextSignImageElement.SignRange, DCSignRange.Parent);
			p0.WritePropertyValue("SignTime", xTextSignImageElement.SignTime);
			p0.WritePropertyValue("SignUserID", xTextSignImageElement.SignUserID);
			p0.WritePropertyValue("SignUserName", xTextSignImageElement.SignUserName);
			p0.WritePropertyValue("Title", xTextSignImageElement.Title);
			p0.WritePropertyValue("UseInnerSignProvider", xTextSignImageElement.UseInnerSignProvider);
		}
	}

	private class z0ejj : z0ZzZzfgh
	{
		public override void z0sj(z0ZzZzggh p0, object p1)
		{
			p0.GetProvider(typeof(XTextContainerElement)).z0sj(p0, p1);
			XTextStringElement xTextStringElement = (XTextStringElement)p1;
			if (xTextStringElement.z0pek() != null && !p0.IsEmptyInstance(xTextStringElement.z0pek()))
			{
				p0.WritePropertyValueInstance("MyXmlTextString20190516", xTextStringElement.z0pek());
			}
			p0.WritePropertyValue("WhiteSpaceLength", xTextStringElement.z0eek());
		}
	}

	private sealed class z0rjj : z0ZzZzfgh
	{
		public override void z0sj(z0ZzZzggh p0, object p1)
		{
			p0.GetProvider(typeof(XTextSectionElement)).z0sj(p0, p1);
			XTextSubDocumentElement xTextSubDocumentElement = (XTextSubDocumentElement)p1;
			p0.WritePropertyValue("ContentLoaded", xTextSubDocumentElement.ContentLoaded);
			p0.WritePropertyValue("DelayLoadWhenExpand", xTextSubDocumentElement.DelayLoadWhenExpand);
			p0.WritePropertyValue("DocumentID", xTextSubDocumentElement.DocumentID);
			if (xTextSubDocumentElement.DocumentInfo != null && !p0.IsEmptyInstance(xTextSubDocumentElement.DocumentInfo))
			{
				p0.WritePropertyValueInstance("DocumentInfo", xTextSubDocumentElement.DocumentInfo);
			}
			p0.WritePropertyValue("FileFormat", xTextSubDocumentElement.FileFormat);
			p0.WritePropertyValue("FileName", xTextSubDocumentElement.FileName);
			p0.WritePropertyValue("ImportUserTrack", xTextSubDocumentElement.ImportUserTrack, defaultValue: true);
			p0.WritePropertyValue("Locked", xTextSubDocumentElement.Locked);
			p0.WritePropertyValue("Printed", xTextSubDocumentElement.Printed);
			p0.WritePropertyValue("PrintedPageIndex", xTextSubDocumentElement.PrintedPageIndex, -1);
			p0.WritePropertyValue("PrintPositionInPage", xTextSubDocumentElement.PrintPositionInPage);
		}
	}

	private sealed class z0tjj : z0ZzZzfgh
	{
		public override void z0sj(z0ZzZzggh p0, object p1)
		{
			p0.GetProvider(typeof(XTextContentElement)).z0sj(p0, p1);
			XTextTableCellElement xTextTableCellElement = (XTextTableCellElement)p1;
			p0.WritePropertyValue("AutoFixFontSize", xTextTableCellElement.z0wrk());
			p0.WritePropertyValue("AutoFixFontSizeMode", xTextTableCellElement.AutoFixFontSizeMode, ContentAutoFixFontSizeMode.None);
			p0.WritePropertyValue("BorderPrintedWhenJumpPrint", xTextTableCellElement.BorderPrintedWhenJumpPrint);
			p0.WritePropertyValue("CloneType", xTextTableCellElement.CloneType, TableRowCloneType.Default);
			p0.WritePropertyValue("ColSpan", xTextTableCellElement.ColSpan, 1);
			p0.WritePropertyValue("Expression", xTextTableCellElement.z0cek());
			p0.WritePropertyValue("MirrorViewForCrossPage", xTextTableCellElement.MirrorViewForCrossPage);
			p0.WritePropertyValue("MoveFocusHotKey", xTextTableCellElement.MoveFocusHotKey, MoveFocusHotKeys.Tab);
			p0.WritePropertyValue("RowSpan", xTextTableCellElement.RowSpan, 1);
			p0.WritePropertyValue("SlantSplitLineStyle", xTextTableCellElement.SlantSplitLineStyle, RectangleSlantSplitStyle.None);
			p0.WritePropertyValue("StressBorder", xTextTableCellElement.z0rek());
			p0.WritePropertyValue("TabStop", xTextTableCellElement.z0mek(), defaultValue: true);
		}
	}

	private sealed class z0yjj : z0ZzZzfgh
	{
		public override void z0sj(z0ZzZzggh p0, object p1)
		{
			p0.GetProvider(typeof(XTextElement)).z0sj(p0, p1);
			XTextTableColumnElement xTextTableColumnElement = (XTextTableColumnElement)p1;
			if (xTextTableColumnElement.Attributes != null && xTextTableColumnElement.Attributes.Count > 0)
			{
				p0.WritePropertyValueInstance("Attributes", xTextTableColumnElement.Attributes);
			}
			if (xTextTableColumnElement.ValueBinding != null && !p0.IsEmptyInstance(xTextTableColumnElement.ValueBinding))
			{
				p0.WritePropertyValueInstance("ValueBinding", xTextTableColumnElement.ValueBinding);
			}
		}
	}

	private sealed class z0ujj : z0ZzZzfgh
	{
		public override void z0sj(z0ZzZzggh p0, object p1)
		{
			p0.GetProvider(typeof(XTextContainerElement)).z0sj(p0, p1);
			XTextTableElement xTextTableElement = (XTextTableElement)p1;
			p0.WritePropertyValue("Alignment", xTextTableElement.z0frk(), DCTableAlignment.Default);
			p0.WritePropertyValue("AllowReBindingDataSource", xTextTableElement.z0mrk());
			p0.WritePropertyValue("AllowUserDeleteRow", xTextTableElement.AllowUserDeleteRow, defaultValue: true);
			p0.WritePropertyValue("AllowUserInsertRow", xTextTableElement.AllowUserInsertRow, defaultValue: true);
			p0.WritePropertyValue("AllowUserToResizeColumns", xTextTableElement.AllowUserToResizeColumns, defaultValue: true);
			p0.WritePropertyValue("AllowUserToResizeEvenInFormViewMode", xTextTableElement.z0xrk());
			p0.WritePropertyValue("AllowUserToResizeRows", xTextTableElement.AllowUserToResizeRows, defaultValue: true);
			if (xTextTableElement.z0srk() != null && xTextTableElement.z0srk().Count > 0)
			{
				p0.WritePropertyValueInstance("Columns", xTextTableElement.z0srk());
			}
			p0.WritePropertyValue("CompressOwnerLineSpacing", xTextTableElement.CompressOwnerLineSpacing);
			p0.WritePropertyValue("HoldWholeLine", xTextTableElement.z0mek(), defaultValue: true);
			p0.WritePropertyValue("LeftIndent", xTextTableElement.z0qtk());
			p0.WritePropertyValue("NumOfColumns", xTextTableElement.z0ark());
			p0.WritePropertyValue("NumOfRows", xTextTableElement.z0bek());
			p0.WritePropertyValue("PrintBothBorderWhenJumpPrint", xTextTableElement.PrintBothBorderWhenJumpPrint);
			p0.WritePropertyValue("ShowCellNoneBorder", xTextTableElement.z0dtk(), DCBooleanValue.Inherit);
			p0.WritePropertyValue("SubfieldMode", xTextTableElement.z0hrk(), TableSubfieldMode.None);
			p0.WritePropertyValue("SubfieldNumber", xTextTableElement.z0prk(), 1);
		}
	}

	private sealed class z0ijj : z0ZzZzfgh
	{
		public override void z0sj(z0ZzZzggh p0, object p1)
		{
			p0.GetProvider(typeof(XTextContainerElement)).z0sj(p0, p1);
			XTextTableRowElement xTextTableRowElement = (XTextTableRowElement)p1;
			p0.WritePropertyValue("AllowInsertRowDownUseHotKey", xTextTableRowElement.AllowInsertRowDownUseHotKey, DCInsertRowDownUseHotKeys.EnableOnlyForLastRow);
			p0.WritePropertyValue("AllowUserPressTabKeyToInsertRowDown", xTextTableRowElement.z0bek());
			p0.WritePropertyValue("AllowUserToResizeHeight", xTextTableRowElement.AllowUserToResizeHeight, DCBooleanValue.Inherit);
			p0.WritePropertyValue("CanSplitByPageLine", xTextTableRowElement.CanSplitByPageLine, defaultValue: true);
			p0.WritePropertyValue("CloneMultipleBaseForBindingDataSource", xTextTableRowElement.z0jrk(), 1);
			p0.WritePropertyValue("CloneType", xTextTableRowElement.CloneType, TableRowCloneType.Default);
			p0.WritePropertyValue("ExpendForDataBinding", xTextTableRowElement.ExpendForDataBinding, defaultValue: true);
			p0.WritePropertyValue("GenerateByValueBingding", xTextTableRowElement.z0yek());
			p0.WritePropertyValue("HeaderStyle", xTextTableRowElement.HeaderStyle);
			p0.WritePropertyValue("NewPage", xTextTableRowElement.NewPage);
			p0.WritePropertyValue("PrintCellBackground", xTextTableRowElement.PrintCellBackground, defaultValue: true);
			p0.WritePropertyValue("PrintCellBorder", xTextTableRowElement.PrintCellBorder, defaultValue: true);
			p0.WritePropertyValue("SpecifyHeight", xTextTableRowElement.SpecifyHeight);
		}
	}

	private sealed class z0ojj : z0ZzZzfgh
	{
		public override void z0sj(z0ZzZzggh p0, object p1)
		{
			p0.GetProvider(typeof(XTextLabelElementBase)).z0sj(p0, p1);
			XTextTDBarcodeElement xTextTDBarcodeElement = (XTextTDBarcodeElement)p1;
			p0.WritePropertyValue("BarcodeType", xTextTDBarcodeElement.BarcodeType, DCTDBarcodeType.QR);
			p0.WritePropertyValue("ErroeCorrectionLevel", xTextTDBarcodeElement.ErroeCorrectionLevel, DCTBErroeCorrectionLevelType.M);
			p0.WritePropertyValue("VAlign", xTextTDBarcodeElement.VAlign, VerticalAlignStyle.Bottom);
		}
	}

	public static void z0eek(z0ZzZzdgh p0)
	{
		p0.z0eek(typeof(z0ZzZzstk), new z0zxk());
		p0.z0eek(typeof(z0ZzZzqtk), new z0lzk());
		p0.z0eek(typeof(z0ZzZzitk), new z0kzk());
		p0.z0eek(typeof(z0ZzZzptk), new z0jzk());
		p0.z0eek(typeof(z0ZzZzbtk), new z0hzk());
		p0.z0eek(typeof(z0ZzZzcok), new z0gzk());
		p0.z0eek(typeof(z0ZzZzxok), new z0fzk());
		p0.z0eek(typeof(CopySourceInfo), new z0dzk());
		p0.z0eek(typeof(DCChartDataItem), new z0szk());
		p0.z0eek(typeof(DCChartDataItemList), new z0azk());
		p0.z0eek(typeof(DCContentLockInfo), new z0qzk());
		p0.z0eek(typeof(z0ZzZzzej), new z0wzk());
		p0.z0eek(typeof(DocumentComment), new z0ezk());
		p0.z0eek(typeof(z0ZzZzwcj), new z0rzk());
		p0.z0eek(typeof(DocumentContentStyle), new z0tzk());
		p0.z0eek(typeof(DocumentContentStyleContainer), new z0yzk());
		p0.z0eek(typeof(DocumentInfo), new z0uzk());
		p0.z0eek(typeof(DocumentParameter), new z0izk());
		p0.z0eek(typeof(z0ZzZzkvj), new z0ozk());
		p0.z0eek(typeof(z0ZzZzfpk), new z0pzk());
		p0.z0eek(typeof(z0ZzZzykh), new z0mzk());
		p0.z0eek(typeof(z0ZzZzukh), new z0nzk());
		p0.z0eek(typeof(z0ZzZzbuk), new z0bzk());
		p0.z0eek(typeof(InputFieldSettings), new z0vzk());
		p0.z0eek(typeof(z0ZzZzfvj), new z0czk());
		p0.z0eek(typeof(ListItem), new z0xzk());
		p0.z0eek(typeof(z0ZzZzdvj), new z0zzk());
		p0.z0eek(typeof(z0ZzZzsvj), new z0llj());
		p0.z0eek(typeof(ObjectParameter), new z0klj());
		p0.z0eek(typeof(ObjectParameterList), new z0jlj());
		p0.z0eek(typeof(z0ZzZzvpk), new z0hlj());
		p0.z0eek(typeof(z0ZzZzfzj), new z0glj());
		p0.z0eek(typeof(z0ZzZzdzj), new z0flj());
		p0.z0eek(typeof(PageLabelText), new z0dlj());
		p0.z0eek(typeof(PageLabelTextList), new z0slj());
		p0.z0eek(typeof(PropertyExpressionInfo), new z0alj());
		p0.z0eek(typeof(PropertyExpressionInfoList), new z0qlj());
		p0.z0eek(typeof(RepeatedImageValue), new z0wlj());
		p0.z0eek(typeof(RepeatedImageValueList), new z0elj());
		p0.z0eek(typeof(z0ZzZzluj), new z0rlj());
		p0.z0eek(typeof(z0ZzZzkuj), new z0tlj());
		p0.z0eek(typeof(z0ZzZzhuj), new z0ylj());
		p0.z0eek(typeof(z0ZzZzauj), new z0ulj());
		p0.z0eek(typeof(z0ZzZzquj), new z0ilj());
		p0.z0eek(typeof(z0ZzZzwuj), new z0olj());
		p0.z0eek(typeof(z0ZzZzeuj), new z0plj());
		p0.z0eek(typeof(z0ZzZzuuj), new z0mlj());
		p0.z0eek(typeof(z0ZzZziuj), new z0nlj());
		p0.z0eek(typeof(SpecifyPageIndexInfo), new z0blj());
		p0.z0eek(typeof(SpecifyPageIndexInfoList), new z0vlj());
		p0.z0eek(typeof(SubDocumentSettings), new z0clj());
		p0.z0eek(typeof(z0ZzZzyhh), new z0xlj());
		p0.z0eek(typeof(z0ZzZzuhh), new z0zlj());
		p0.z0eek(typeof(z0ZzZzsok), new z0lkj());
		p0.z0eek(typeof(ValueValidateStyle), new z0kkj());
		p0.z0eek(typeof(z0ZzZzwmk), new z0jkj());
		p0.z0eek(typeof(XAttribute), new z0hkj());
		p0.z0eek(typeof(XAttributeList), new z0gkj());
		p0.z0eek(typeof(z0ZzZzemk), new z0fkj());
		p0.z0eek(typeof(z0ZzZzymk), new z0dkj());
		p0.z0eek(typeof(z0ZzZzevj), new z0skj());
		p0.z0eek(typeof(XPageSettings), new z0akj());
		p0.z0eek(typeof(z0ZzZznmk), new z0qkj());
		p0.z0eek(typeof(z0ZzZzolh), new z0wkj());
		p0.z0eek(typeof(XTextButtonElement), new z0ekj());
		p0.z0eek(typeof(XTextChartElement), new z0rkj());
		p0.z0eek(typeof(XTextCheckBoxElement), new z0tkj_jiejie20260327142557());
		p0.z0eek(typeof(XTextCheckBoxElementBase), new z0ykj());
		p0.z0eek(typeof(XTextContainerElement), new z0ukj());
		p0.z0eek(typeof(XTextContentElement), new z0ikj());
		p0.z0eek(typeof(XTextControlHostElement), new z0okj());
		p0.z0eek(typeof(XTextCustomShapeElement), new z0pkj());
		p0.z0eek(typeof(XTextDirectoryFieldElement), new z0mkj());
		p0.z0eek(typeof(XTextDocument), new z0nkj());
		p0.z0eek(typeof(XTextElement), new z0bkj());
		p0.z0eek(typeof(XTextElementList), new z0vkj());
		p0.z0eek(typeof(XTextFieldElementBase), new z0ckj());
		p0.z0eek(typeof(XTextHorizontalLineElement), new z0xkj());
		p0.z0eek(typeof(XTextImageElement), new z0zkj());
		p0.z0eek(typeof(XTextInputFieldElement), new z0ljj());
		p0.z0eek(typeof(XTextInputFieldElementBase), new z0kjj());
		p0.z0eek(typeof(XTextLabelElement), new z0jjj());
		p0.z0eek(typeof(XTextLabelElementBase), new z0hjj());
		p0.z0eek(typeof(XTextMediaElement), new z0gjj());
		p0.z0eek(typeof(XTextNewBarcodeElement), new z0fjj());
		p0.z0eek(typeof(XTextObjectElement), new z0djj());
		p0.z0eek(typeof(XTextPageInfoElement), new z0sjj());
		p0.z0eek(typeof(XTextParagraphFlagElement), new z0ajj());
		p0.z0eek(typeof(XTextSectionElement), new z0qjj());
		p0.z0eek(typeof(XTextSignImageElement), new z0wjj());
		p0.z0eek(typeof(XTextStringElement), new z0ejj());
		p0.z0eek(typeof(XTextSubDocumentElement), new z0rjj());
		p0.z0eek(typeof(XTextTableCellElement), new z0tjj());
		p0.z0eek(typeof(XTextTableColumnElement), new z0yjj());
		p0.z0eek(typeof(XTextTableElement), new z0ujj());
		p0.z0eek(typeof(XTextTableRowElement), new z0ijj());
		p0.z0eek(typeof(XTextTDBarcodeElement), new z0ojj());
	}
}
