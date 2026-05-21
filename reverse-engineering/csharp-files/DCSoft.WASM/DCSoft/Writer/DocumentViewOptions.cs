using System;
using System.ComponentModel;
using DCSoft.Drawing;
using DCSoft.Writer.Dom;
using DCSystem_Drawing;
using DCSystem_Drawing.Drawing2D;
using zzz;

namespace DCSoft.Writer;

public class DocumentViewOptions : ICloneable
{
	private bool z0tek = true;

	private bool z0yek = true;

	private bool z0uek;

	private bool z0iek = true;

	private DCAdornTextVisibility z0oek;

	private Color z0pek = Color.Black;

	private bool z0mek;

	private bool z0nek = true;

	private SmoothingMode z0bek = SmoothingMode.None;

	private Color z0vek = Color.Gray;

	private Color z0cek = Color.LightBlue;

	private Color z0xek = Color.FromArgb(50, Color.Blue);

	private float z0zek_jiejie20260327142557;

	private bool z0lrk;

	private ContentLayoutDirectionStyle z0krk = ContentLayoutDirectionStyle.LeftToRight;

	private Color z0jrk = Color.Red;

	private EnableState z0hrk = EnableState.Enabled;

	private Color z0grk = Color.AliceBlue;

	private string z0frk = "yyyy-MM-dd HH:mm:ss";

	private DCRenderVisibility z0drk;

	private bool z0srk;

	private int z0ark = 30;

	private bool z0qrk = true;

	private Color z0wrk = Color.Gray;

	private bool z0erk;

	private RenderVisibility z0rrk = RenderVisibility.All;

	private bool z0trk = true;

	private string z0yrk;

	internal static bool z0urk = false;

	private z0ZzZzfsh z0irk_jiejie20260327142557 = (z0ZzZzfsh)5;

	private float z0ork = 50f;

	private Color z0prk = z0ryk;

	private bool z0mrk;

	private float z0nrk = 1f;

	private bool z0brk;

	private bool z0vrk;

	private InputFieldAdornTextType z0crk = InputFieldAdornTextType.DataSource;

	private bool z0xrk = true;

	private Color z0zrk = Color.Empty;

	private Color z0ltk = Color.Transparent;

	private bool z0ktk = true;

	private Color z0jtk = Color.LightGray;

	private float z0htk = 1f;

	private bool z0gtk = true;

	private DashStyle z0ftk;

	private Color z0dtk = Color.Empty;

	private Color z0stk = Color.Transparent;

	private Color z0atk = Color.FromArgb(100, Color.Gray);

	private Color z0qtk = Color.LightBlue;

	private Color z0wtk = Color.Gray;

	private RenderVisibility z0etk = RenderVisibility.All;

	private Color z0rtk = Color.FromArgb(100, 0, 0, 255);

	private float z0ttk = 10f;

	internal static bool z0ytk = true;

	private bool z0utk;

	private float z0itk = 10f;

	internal static readonly int z0otk = Color.Blue.ToArgb();

	private Color z0ptk = Color.Blue;

	private bool z0mtk = true;

	private bool z0ntk = true;

	private Color z0btk = Color.Red;

	private bool z0vtk = true;

	private bool z0ctk = true;

	private bool z0xtk;

	private bool z0ztk;

	private Color z0lyk = Color.LightCoral;

	private bool z0kyk;

	private Color z0jyk = Color.LightGray;

	private bool z0hyk;

	private InterpolationMode z0gyk = InterpolationMode.High;

	private Color z0fyk = Color.Gray;

	private Color z0dyk = Color.Red;

	private bool z0syk;

	private Color z0ayk = Color.Transparent;

	private Color z0qyk = Color.Empty;

	private Color z0wyk = Color.Transparent;

	private bool z0eyk;

	internal static readonly Color z0ryk = Color.Blue;

	private bool z0tyk;

	private bool z0yyk;

	[DefaultValue(true)]
	public bool ShowExpressionFlag
	{
		get
		{
			return z0iek;
		}
		set
		{
			z0iek = value;
		}
	}

	public Color AdornTextBackColor
	{
		get
		{
			return z0atk;
		}
		set
		{
			z0atk = value;
		}
	}

	[DefaultValue(false)]
	public bool SupportUG
	{
		get
		{
			return z0erk;
		}
		set
		{
			z0erk = value;
		}
	}

	[DefaultValue(true)]
	public bool EnableEncryptView
	{
		get
		{
			return z0ntk;
		}
		set
		{
			z0ntk = value;
		}
	}

	[DefaultValue(InterpolationMode.High)]
	public InterpolationMode ImageInterpolationMode
	{
		get
		{
			return z0gyk;
		}
		set
		{
			z0gyk = value;
		}
	}

	[DefaultValue(false)]
	public bool PrintImageAltText
	{
		get
		{
			return z0uek;
		}
		set
		{
			z0uek = value;
		}
	}

	[DefaultValue(true)]
	public bool ShowGlobalGridLineInTableAndSection
	{
		get
		{
			return z0ctk;
		}
		set
		{
			z0ctk = value;
		}
	}

	[DefaultValue(true)]
	public bool ShowHeaderBottomLine
	{
		get
		{
			return z0gtk;
		}
		set
		{
			z0gtk = value;
		}
	}

	[DefaultValue(true)]
	public bool HiddenFieldBorderWhenLostFocus
	{
		get
		{
			return z0trk;
		}
		set
		{
			z0trk = value;
		}
	}

	[DefaultValue(DCAdornTextVisibility.Hidden)]
	public DCAdornTextVisibility AdornTextVisibility
	{
		get
		{
			return z0oek;
		}
		set
		{
			z0oek = value;
		}
	}

	[DefaultValue(DashStyle.Solid)]
	public DashStyle GridLineStyle
	{
		get
		{
			return z0ftk;
		}
		set
		{
			z0ftk = value;
		}
	}

	[DefaultValue(SmoothingMode.None)]
	public SmoothingMode GraphicsSmoothingMode
	{
		get
		{
			return z0bek;
		}
		set
		{
			z0bek = value;
		}
	}

	[DefaultValue(ContentLayoutDirectionStyle.LeftToRight)]
	public ContentLayoutDirectionStyle LayoutDirection
	{
		get
		{
			return z0krk;
		}
		set
		{
			z0krk = value;
		}
	}

	public Color FieldTextColor
	{
		get
		{
			return z0pek;
		}
		set
		{
			z0pek = value;
		}
	}

	public Color DefaultInputFieldTextColor
	{
		get
		{
			return z0ayk;
		}
		set
		{
			z0ayk = value;
		}
	}

	[DefaultValue(false)]
	public bool ShowFormButton
	{
		get
		{
			return z0yyk;
		}
		set
		{
			z0yyk = value;
		}
	}

	[DefaultValue(false)]
	public bool HiddenTableBorderJumpPrintPage
	{
		get
		{
			return z0tyk;
		}
		set
		{
			z0tyk = value;
		}
	}

	public Color TagColorForValueInvalidateField
	{
		get
		{
			return z0jrk;
		}
		set
		{
			z0jrk = value;
		}
	}

	[DefaultValue(false)]
	public bool ShowGridLine
	{
		get
		{
			return z0mrk;
		}
		set
		{
			z0mrk = value;
		}
	}

	[DefaultValue(1f)]
	public float HeaderBottomLineWidth
	{
		get
		{
			return z0nrk;
		}
		set
		{
			z0nrk = value;
		}
	}

	[DefaultValue(true)]
	public bool ShowCellNoneBorder
	{
		get
		{
			return z0ktk;
		}
		set
		{
			z0ktk = value;
		}
	}

	public Color FieldInvalidateValueBackColor
	{
		get
		{
			return z0stk;
		}
		set
		{
			z0stk = value;
		}
	}

	[DefaultValue(1f)]
	public float FieldBorderElementPixelWidth
	{
		get
		{
			return z0htk;
		}
		set
		{
			z0htk = value;
		}
	}

	public Color NoneBorderColor
	{
		get
		{
			return z0jtk;
		}
		set
		{
			z0jtk = value;
		}
	}

	[DefaultValue(false)]
	public bool EnableFieldTextColor
	{
		get
		{
			return z0syk;
		}
		set
		{
			z0syk = value;
		}
	}

	public Color NormalFieldBorderColor
	{
		get
		{
			return z0prk;
		}
		set
		{
			z0prk = value;
		}
	}

	[DefaultValue(false)]
	public bool ShowBackgroundCellID
	{
		get
		{
			return z0utk;
		}
		set
		{
			z0utk = value;
		}
	}

	[DefaultValue(true)]
	public bool ShowParagraphFlag
	{
		get
		{
			return z0yek;
		}
		set
		{
			z0yek = value;
		}
	}

	public Color FieldFocusedBackColor
	{
		get
		{
			return z0cek;
		}
		set
		{
			z0cek = value;
		}
	}

	[DefaultValue(RenderVisibility.All)]
	public RenderVisibility SectionBorderVisibility
	{
		get
		{
			return z0rrk;
		}
		set
		{
			z0rrk = value;
		}
	}

	[DefaultValue(null)]
	public string CommentFontName
	{
		get
		{
			return z0yrk;
		}
		set
		{
			z0yrk = value;
		}
	}

	[DefaultValue(true)]
	public bool IgnoreFieldBorderWhenPrint
	{
		get
		{
			return z0tek;
		}
		set
		{
			z0tek = value;
		}
	}

	[DefaultValue(0f)]
	public float SpecifyExtenGridLineStep
	{
		get
		{
			return z0zek_jiejie20260327142557;
		}
		set
		{
			z0zek_jiejie20260327142557 = value;
		}
	}

	[DefaultValue(false)]
	public bool ShowLineNumber
	{
		get
		{
			return z0ztk;
		}
		set
		{
			z0ztk = value;
		}
	}

	[DefaultValue(false)]
	public bool PrintBackgroundText
	{
		get
		{
			return z0lrk;
		}
		set
		{
			z0lrk = value;
		}
	}

	public Color TagColorForModifiedField
	{
		get
		{
			return z0ptk;
		}
		set
		{
			z0ptk = value;
		}
	}

	public Color DefaultLineColorForImageEditor
	{
		get
		{
			return z0dtk;
		}
		set
		{
			z0dtk = value;
		}
	}

	[DefaultValue((z0ZzZzfsh)5)]
	public z0ZzZzfsh TextRenderStyle
	{
		get
		{
			return z0irk_jiejie20260327142557;
		}
		set
		{
			z0irk_jiejie20260327142557 = value;
		}
	}

	public Color TagColorForNormalField
	{
		get
		{
			return z0dyk;
		}
		set
		{
			z0dyk = value;
		}
	}

	[DefaultValue(true)]
	public bool ShowPageLine
	{
		get
		{
			return z0qrk;
		}
		set
		{
			z0qrk = value;
		}
	}

	[DefaultValue(false)]
	public bool ShowFieldBorderTextInTheMiddle
	{
		get
		{
			return z0mek;
		}
		set
		{
			z0mek = value;
		}
	}

	public Color FieldBackColor
	{
		get
		{
			return z0grk;
		}
		set
		{
			z0grk = value;
		}
	}

	public Color TagColorForReadonlyField
	{
		get
		{
			return z0fyk;
		}
		set
		{
			z0fyk = value;
		}
	}

	public Color UnEditableFieldBorderColor
	{
		get
		{
			return z0btk;
		}
		set
		{
			z0btk = value;
		}
	}

	public Color FieldHoverBackColor
	{
		get
		{
			return z0qtk;
		}
		set
		{
			z0qtk = value;
		}
	}

	[DefaultValue(false)]
	public bool ReadViewModeSameAsPrint
	{
		get
		{
			return z0urk;
		}
		set
		{
			z0urk = value;
		}
	}

	[DefaultValue(DCRenderVisibility.Default)]
	public DCRenderVisibility FieldBorderPrintVisibility
	{
		get
		{
			return z0drk;
		}
		set
		{
			z0drk = value;
		}
	}

	[DefaultValue(false)]
	public bool BothBlackWhenPrint
	{
		get
		{
			return z0brk;
		}
		set
		{
			z0brk = value;
		}
	}

	[DefaultValue(false)]
	public bool PrintGridLine
	{
		get
		{
			return z0eyk;
		}
		set
		{
			z0eyk = value;
		}
	}

	[DefaultValue(false)]
	public bool HighlightProtectedContent
	{
		get
		{
			return z0xtk;
		}
		set
		{
			z0xtk = value;
		}
	}

	[DefaultValue(50f)]
	public float MinTableColumnWidth
	{
		get
		{
			return z0ork;
		}
		set
		{
			z0ork = value;
		}
	}

	public Color FieldTextPrintColor
	{
		get
		{
			return z0ltk;
		}
		set
		{
			z0ltk = value;
		}
	}

	public Color ReadonlyFieldBackColor
	{
		get
		{
			return z0jyk;
		}
		set
		{
			z0jyk = value;
		}
	}

	[DefaultValue(false)]
	public bool ShowInputFieldStateTag
	{
		get
		{
			return z0vrk;
		}
		set
		{
			z0vrk = value;
		}
	}

	public Color NewInputContentUnderlineColor
	{
		get
		{
			return z0wyk;
		}
		set
		{
			z0wyk = value;
		}
	}

	public Color ReadonlyFieldBorderColor
	{
		get
		{
			return z0wtk;
		}
		set
		{
			z0wtk = value;
		}
	}

	public Color MaskColorForJumpPrint
	{
		get
		{
			return z0rtk;
		}
		set
		{
			z0rtk = value;
		}
	}

	[DefaultValue(RenderVisibility.All)]
	public RenderVisibility TableCellBorderVisibility
	{
		get
		{
			return z0etk;
		}
		set
		{
			z0etk = value;
		}
	}

	[DefaultValue(false)]
	public bool OldWhitespaceWidth
	{
		get
		{
			return z0hyk;
		}
		set
		{
			z0hyk = value;
		}
	}

	[DefaultValue("yyyy-MM-dd HH:mm:ss")]
	public string CommentDateFormatString
	{
		get
		{
			return z0frk;
		}
		set
		{
			z0frk = value;
		}
	}

	public Color SelectionHightlightMaskColor
	{
		get
		{
			return z0xek;
		}
		set
		{
			z0xek = value;
		}
	}

	public Color BackgroundTextColor
	{
		get
		{
			return z0vek;
		}
		set
		{
			z0vek = value;
		}
	}

	[DefaultValue(true)]
	public bool EnableRightToLeft
	{
		get
		{
			return z0mtk;
		}
		set
		{
			z0mtk = value;
		}
	}

	[DefaultValue(true)]
	public bool ShowGrayMaskOverDisableContentParty
	{
		get
		{
			return z0nek;
		}
		set
		{
			z0nek = value;
		}
	}

	[DefaultValue(true)]
	public bool ShowFieldBorderElement
	{
		get
		{
			return z0vtk;
		}
		set
		{
			z0vtk = value;
		}
	}

	[DefaultValue(10f)]
	public float CommentFontSize
	{
		get
		{
			return z0ttk;
		}
		set
		{
			z0ttk = value;
		}
	}

	[DefaultValue(true)]
	public bool ShowRedErrorMessageForPaint
	{
		get
		{
			return z0xrk;
		}
		set
		{
			z0xrk = value;
		}
	}

	public Color ProtectedContentBackColor
	{
		get
		{
			return z0qyk;
		}
		set
		{
			z0qyk = value;
		}
	}

	[DefaultValue(InputFieldAdornTextType.DataSource)]
	public InputFieldAdornTextType DefaultAdornTextType
	{
		get
		{
			return z0crk;
		}
		set
		{
			z0crk = value;
		}
	}

	public Color FieldInvalidateValueForeColor
	{
		get
		{
			return z0lyk;
		}
		set
		{
			z0lyk = value;
		}
	}

	[DefaultValue(EnableState.Enabled)]
	public virtual EnableState DefaultInputFieldHighlight
	{
		get
		{
			return z0hrk;
		}
		set
		{
			z0hrk = value;
		}
	}

	[DefaultValue(10f)]
	public float EmphasisMarkSize
	{
		get
		{
			return z0itk;
		}
		set
		{
			z0itk = value;
		}
	}

	[DefaultValue(30)]
	public int PageMarginLineLength
	{
		get
		{
			return z0ark;
		}
		set
		{
			z0ark = value;
		}
	}

	[DefaultValue(false)]
	public bool PreserveBackgroundTextWhenPrint
	{
		get
		{
			return z0srk;
		}
		set
		{
			z0srk = value;
		}
	}

	public Color FieldBorderColor
	{
		get
		{
			return z0zrk;
		}
		set
		{
			z0zrk = value;
		}
	}

	[z0ZzZzuqh]
	public Color GridLineColor
	{
		get
		{
			return z0wrk;
		}
		set
		{
			z0wrk = value;
		}
	}

	[DefaultValue(false)]
	public bool ShowPageBreak
	{
		get
		{
			return z0kyk;
		}
		set
		{
			z0kyk = value;
		}
	}

	public DCRenderVisibility z0eek_jiejie20260327142557()
	{
		if (z0drk == DCRenderVisibility.Default)
		{
			if (!z0tek)
			{
				return DCRenderVisibility.Hidden;
			}
			return DCRenderVisibility.None;
		}
		return z0drk;
	}

	public DocumentViewOptions Clone()
	{
		return (DocumentViewOptions)((ICloneable)this).Clone();
	}

	private object z0rek()
	{
		return (DocumentViewOptions)MemberwiseClone();
	}

	object ICloneable.Clone()
	{
		//ILSpy generated this explicit interface implementation from .override directive in z0rek
		return this.z0rek();
	}
}
