using System;
using System.ComponentModel;
using DCSoft.Writer.Controls;
using zzz;

namespace DCSoft.Writer;

public class DocumentBehaviorOptions : ICloneable
{
	private static bool z0rek = false;

	private string z0tek;

	private bool z0yek = true;

	private bool z0uek = true;

	private WriterDataFormats z0iek = WriterDataFormats.All;

	private DCWordBreakStyle z0oek;

	private bool z0pek;

	private bool z0mek_jiejie20260327142557 = true;

	private bool z0nek;

	private bool z0bek;

	private InsertDocumentWithCheckMRIDType z0vek;

	private bool z0cek;

	private bool z0xek;

	private bool z0zek = true;

	private string z0lrk;

	private bool z0krk = true;

	private bool z0jrk;

	private bool z0hrk_jiejie20260327142557;

	private bool z0grk;

	private bool z0frk;

	private bool z0drk;

	private bool z0srk = true;

	private FunctionControlVisibility z0ark;

	private bool z0qrk = true;

	private string z0wrk;

	private bool z0erk = true;

	internal static bool z0rrk = true;

	private bool z0trk = true;

	private PromptProtectedContentMode z0yrk = PromptProtectedContentMode.Details;

	private DCValidateIDRepeatMode z0urk;

	private bool z0irk_jiejie20260327142557;

	private WriterDataObjectRange z0ork;

	private bool z0prk;

	private bool z0mrk;

	private bool z0nrk;

	private bool z0brk_jiejie20260327142557;

	private bool z0vrk = true;

	private bool z0crk = true;

	private bool z0xrk = true;

	private bool z0zrk;

	private bool z0ltk = true;

	private int z0ktk = 51200;

	private WriterDataFormats z0jtk = WriterDataFormats.All;

	private bool z0htk;

	private static bool z0gtk = false;

	private bool z0ftk = true;

	private FormViewMode z0dtk;

	private bool z0stk;

	private bool z0atk = true;

	private bool z0qtk_jiejie20260327142557 = true;

	private bool z0wtk = true;

	private int z0etk = 936;

	private bool z0rtk;

	private bool z0ttk = true;

	private bool z0ytk = true;

	private string z0utk;

	private int z0itk;

	private bool z0otk;

	private DCDocumentTextOutputMode z0ptk;

	private bool z0mtk = true;

	private bool z0ntk;

	private bool z0btk;

	private bool z0vtk;

	private string z0ctk;

	private bool z0xtk;

	private bool z0ztk;

	private bool z0lyk;

	private ValueEditorActiveMode z0kyk;

	private bool z0jyk = true;

	private bool z0hyk = true;

	private bool z0gyk;

	private float z0fyk = 5f;

	private bool z0dyk = true;

	private AppErrorHandleModeConsts z0syk = AppErrorHandleModeConsts.ThrowException;

	private bool z0ayk = true;

	private bool z0qyk = true;

	private int z0wyk = 4;

	private bool z0eyk = true;

	private bool z0ryk = true;

	private bool z0tyk = true;

	private bool z0yyk;

	private bool z0uyk = true;

	private bool z0iyk = true;

	private MoveFocusHotKeys z0oyk;

	private bool z0pyk;

	private bool z0myk = true;

	private DCImageCompressSaveMode z0nyk = DCImageCompressSaveMode.Prompt;

	private bool z0byk;

	private bool z0vyk;

	private bool z0cyk = true;

	private bool z0xyk = true;

	private string z0zyk;

	private int z0luk;

	private int z0kuk = 3;

	private bool z0juk;

	private bool z0huk;

	private string z0guk;

	private bool z0fuk;

	private float z0duk = 0.2f;

	private string z0suk;

	private bool z0auk = true;

	private bool z0quk;

	private bool z0wuk;

	private bool z0euk = true;

	private string z0ruk;

	private bool z0tuk;

	private bool z0yuk = true;

	private bool z0uuk = true;

	private bool z0iuk;

	private bool z0ouk = true;

	private bool z0puk = true;

	private bool z0muk = true;

	private bool z0nuk = true;

	private bool z0buk = true;

	private bool z0vuk = true;

	private bool z0cuk;

	private bool z0xuk = true;

	private bool z0zuk = true;

	[DefaultValue(true)]
	public bool SaveBodyTextToXml
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

	[DefaultValue(false)]
	public bool ParseCrLfAsLineBreakElement
	{
		get
		{
			return z0fuk;
		}
		set
		{
			z0fuk = value;
		}
	}

	[DefaultValue(false)]
	public bool ShowDebugMessage
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

	[DefaultValue(true)]
	public bool EnableElementEvents
	{
		get
		{
			return z0xuk;
		}
		set
		{
			z0xuk = value;
		}
	}

	[DefaultValue(5f)]
	public float MaxZoomRate
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

	[DefaultValue(null)]
	public string StdLablesForImageEditor
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

	[DefaultValue(false)]
	public bool CompressXMLContent
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

	[DefaultValue(true)]
	public bool EnableCompressUserHistories
	{
		get
		{
			return z0puk;
		}
		set
		{
			z0puk = value;
		}
	}

	[DefaultValue(false)]
	public bool AutoDocumentValueValidate
	{
		get
		{
			return z0vyk;
		}
		set
		{
			z0vyk = value;
		}
	}

	[DefaultValue(false)]
	public bool MaximizedPrintPreviewDialog
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
	public bool ForceRaiseEventAfterFieldContentEdit
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

	[DefaultValue(WriterDataFormats.All)]
	public WriterDataFormats AcceptDataFormats
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

	[DefaultValue(null)]
	public string AutoTranslateDescString
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

	[DefaultValue(null)]
	public string TitleForToolTip
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

	[DefaultValue(true)]
	public bool SelectionTextIncludeBackgroundText
	{
		get
		{
			return z0mek_jiejie20260327142557;
		}
		set
		{
			z0mek_jiejie20260327142557 = value;
		}
	}

	[DefaultValue(0)]
	public int MaxTextLengthForPaste
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

	[DefaultValue(true)]
	public bool DoubleClickToEditComment
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

	[DefaultValue(0.2f)]
	public float MinZoomRate
	{
		get
		{
			return z0duk;
		}
		set
		{
			z0duk = value;
		}
	}

	[DefaultValue(true)]
	public bool EnableScript
	{
		get
		{
			return z0nuk;
		}
		set
		{
			z0nuk = value;
		}
	}

	[DefaultValue(true)]
	public bool EnableContentLock
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

	[DefaultValue(null)]
	public string AutoTranslateSourceString
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

	[DefaultValue(null)]
	public string CustomWarringCheckMRID
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

	[DefaultValue(false)]
	public bool AutoUpdateButtonVisible
	{
		get
		{
			return z0juk;
		}
		set
		{
			z0juk = value;
		}
	}

	[DefaultValue(true)]
	public bool OutputFormatedXMLSource
	{
		get
		{
			return z0qtk_jiejie20260327142557;
		}
		set
		{
			z0qtk_jiejie20260327142557 = value;
		}
	}

	[DefaultValue(false)]
	public bool RemoveLastParagraphFlagWhenInsertDocument
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

	[DefaultValue(true)]
	public bool OutputFieldBorderTextToContentText
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
	public bool EnableLogUndo
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

	[DefaultValue(false)]
	public bool PreserveClipbardDataWhenExit
	{
		get
		{
			return z0pyk;
		}
		set
		{
			z0pyk = value;
		}
	}

	[DefaultValue(true)]
	public bool AutoIgnoreLastEmptyPage
	{
		get
		{
			return z0euk;
		}
		set
		{
			z0euk = value;
		}
	}

	[z0ZzZzbjh]
	[DefaultValue(false)]
	[z0ZzZzyqh]
	public bool EnableContentChangedEventWhenLoadDocument
	{
		get
		{
			return z0tuk;
		}
		set
		{
			z0tuk = value;
		}
	}

	[DefaultValue(ValueEditorActiveMode.None)]
	public ValueEditorActiveMode DefaultEditorActiveMode
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

	[DefaultValue(0)]
	public int AutoAssistInsertStringDetectTextLength
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

	[DefaultValue(null)]
	public string XMLContentEncodingName
	{
		get
		{
			return z0guk;
		}
		set
		{
			z0guk = value;
		}
	}

	[DefaultValue(false)]
	public bool AutoScrollToCaretWhenGotFocus
	{
		get
		{
			return z0wuk;
		}
		set
		{
			z0wuk = value;
		}
	}

	[DefaultValue(false)]
	public bool ContinueHeaderParagrahStyle
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

	[DefaultValue(true)]
	public bool PromptForExcludeSystemClipboardRange
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

	[DefaultValue(MoveFocusHotKeys.None)]
	public MoveFocusHotKeys MoveFocusHotKey
	{
		get
		{
			return z0oyk;
		}
		set
		{
			z0oyk = value;
		}
	}

	[DefaultValue(false)]
	public bool GlobalSpecifyDebugModeValue
	{
		get
		{
			return z0rek;
		}
		set
		{
			z0rek = value;
		}
	}

	[DefaultValue(null)]
	public string ExcludeKeywords
	{
		get
		{
			return z0ruk;
		}
		set
		{
			z0ruk = value;
		}
	}

	[DefaultValue(true)]
	public bool AutoFixElementIDWhenInsertElements
	{
		get
		{
			return z0yuk;
		}
		set
		{
			z0yuk = value;
		}
	}

	[DefaultValue(false)]
	public bool AutoClearTextFormatWhenPasteOrInsertContent
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

	[DefaultValue(true)]
	public bool CompressLayoutForFieldBorder
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

	public string CustomPromptForbitCheckMRID
	{
		get
		{
			return z0suk;
		}
		set
		{
			z0suk = value;
		}
	}

	[DefaultValue(true)]
	public bool AutoClearInvalidateCharacter
	{
		get
		{
			return z0cyk;
		}
		set
		{
			z0cyk = value;
		}
	}

	[DefaultValue(true)]
	public bool EnableKBEntryRangeMask
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

	[DefaultValue(false)]
	public bool WidelyRaiseFocusEvent
	{
		get
		{
			return z0byk;
		}
		set
		{
			z0byk = value;
		}
	}

	[DefaultValue(true)]
	public bool DisplayFormatToInnerValue
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

	[z0ZzZzuqh]
	public bool DoubleCompressHtmlWhitespace
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

	[DefaultValue(DCValidateIDRepeatMode.None)]
	public DCValidateIDRepeatMode ValidateIDRepeatMode
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

	[DefaultValue(true)]
	public bool ShowTooltip
	{
		get
		{
			return z0ouk;
		}
		set
		{
			z0ouk = value;
		}
	}

	[DefaultValue(false)]
	public bool ActiveCheckInstallWindowsMediaPlayer
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

	[DefaultValue(false)]
	public bool DebugMode
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

	[DefaultValue(true)]
	public bool DoubleClickToSelectWord
	{
		get
		{
			return z0buk;
		}
		set
		{
			z0buk = value;
		}
	}

	[DefaultValue(false)]
	public bool FastInputMode
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

	[DefaultValue(true)]
	public bool PromptForRejectFormat
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
	public bool EnableControlHostAtDesignTime
	{
		get
		{
			return z0uyk;
		}
		set
		{
			z0uyk = value;
		}
	}

	[DefaultValue(false)]
	public bool ForceCollateWhenPrint
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

	[DefaultValue(AppErrorHandleModeConsts.ThrowException)]
	public AppErrorHandleModeConsts AppErrorHandleMode
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

	[DefaultValue(true)]
	public bool CheckedValueBindingHandledForTableRow
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

	[DefaultValue(4)]
	public int MinCountForDropdownListSpellCodeArea
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

	[DefaultValue(true)]
	public bool ThreeClickToSelectParagraph
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

	[DefaultValue(true)]
	public bool EnableCalculateControl
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

	[DefaultValue(true)]
	public bool PowerfulCommentCommand
	{
		get
		{
			return z0muk;
		}
		set
		{
			z0muk = value;
		}
	}

	[DefaultValue(true)]
	public bool UseNewValueExpressionEngine
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

	[DefaultValue(51200)]
	public int MinImageFileSizeForConfirmCompressSaveMode
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

	[DefaultValue(true)]
	public bool EnableDataBinding
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

	[DefaultValue(true)]
	public bool EnableSetJumpPrintPositionWhenPreview
	{
		get
		{
			return z0iyk;
		}
		set
		{
			z0iyk = value;
		}
	}

	[DefaultValue(false)]
	public bool AutoRefreshUserTrackInfos
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

	[DefaultValue(false)]
	public bool EnableCheckControlLoaded
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

	[DefaultValue(false)]
	public bool CommentEditableWhenReadonly
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

	[DefaultValue(FunctionControlVisibility.Auto)]
	public FunctionControlVisibility CommentVisibility
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

	public static bool StaticAutoCreateInstanceInProperty
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
	public bool CloneSerialize
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

	public static bool GlobalSpecifyDebugMode
	{
		get
		{
			return z0rek;
		}
		set
		{
			z0rek = value;
		}
	}

	[DefaultValue(false)]
	public bool AutoCreateInstanceInProperty
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
	public bool PromptJumpBackForSearch
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

	[DefaultValue(false)]
	public bool InsertCommentBindingUserTrack
	{
		get
		{
			return z0huk;
		}
		set
		{
			z0huk = value;
		}
	}

	[DefaultValue(true)]
	public bool EnabledElementEvent
	{
		get
		{
			return z0xuk;
		}
		set
		{
			z0xuk = value;
		}
	}

	[DefaultValue(true)]
	public bool MoveFieldWhenDragWholeContent
	{
		get
		{
			return z0ryk;
		}
		set
		{
			z0ryk = value;
		}
	}

	[DefaultValue(InsertDocumentWithCheckMRIDType.None)]
	public InsertDocumentWithCheckMRIDType InsertDocumentWithCheckMRID
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
	public bool SetParagraphFlagHeightUsePreElement
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

	[DefaultValue(3)]
	public int TableCellOperationDetectDistance
	{
		get
		{
			return z0kuk;
		}
		set
		{
			z0kuk = value;
		}
	}

	[DefaultValue(true)]
	public bool EnableEditElementValue
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

	[DefaultValue(true)]
	public bool MoveCaretWhenDeleteFail
	{
		get
		{
			return z0vuk;
		}
		set
		{
			z0vuk = value;
		}
	}

	[DefaultValue(false)]
	public bool DesignMode
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

	[DefaultValue(PromptProtectedContentMode.Details)]
	public PromptProtectedContentMode PromptProtectedContent
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

	[DefaultValue(DCDocumentTextOutputMode.Normal)]
	public DCDocumentTextOutputMode DocumentTextOutputMode
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

	[DefaultValue(false)]
	public bool IgnoreTopBottomPaddingWhenGridLineLayout
	{
		get
		{
			return z0cuk;
		}
		set
		{
			z0cuk = value;
		}
	}

	[DefaultValue(false)]
	public bool AutoUppercaseFirstCharInFirstLine
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

	[DefaultValue(true)]
	public bool EnableCopySource
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

	[DefaultValue(true)]
	public bool EnabledCache100KBImageData
	{
		get
		{
			return z0ZzZzpmk.z0xek;
		}
		set
		{
			z0ZzZzpmk.z0xek = value;
		}
	}

	[DefaultValue(true)]
	public bool OutputBackgroundTextToRTF
	{
		get
		{
			return z0uuk;
		}
		set
		{
			z0uuk = value;
		}
	}

	[DefaultValue(false)]
	public bool SimpleElementProperties
	{
		get
		{
			return z0iuk;
		}
		set
		{
			z0iuk = value;
		}
	}

	[DefaultValue(true)]
	public bool AutoFocusWhenOpenDocument
	{
		get
		{
			return z0auk;
		}
		set
		{
			z0auk = value;
		}
	}

	[DefaultValue(true)]
	public bool EnableExpression
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

	[DefaultValue(true)]
	public bool Printable
	{
		get
		{
			return z0myk;
		}
		set
		{
			z0myk = value;
		}
	}

	[DefaultValue(false)]
	public bool ValidateUserIDWhenEditDeleteComment
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

	[DefaultValue(true)]
	public bool EnableHyperLink
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
	public bool AllowDeleteJumpOutOfField
	{
		get
		{
			return z0ytk;
		}
		set
		{
			z0ytk = value;
		}
	}

	[DefaultValue(false)]
	public bool DisableCheckMRIDWhenMRIDIsEmptyForOuterDataObject
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

	[DefaultValue(true)]
	public bool IgnoreDataBindingWhenMissValue
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

	[DefaultValue(DCWordBreakStyle.Normal)]
	public DCWordBreakStyle WordBreak
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

	[DefaultValue(WriterDataObjectRange.OS)]
	public WriterDataObjectRange DataObjectRange
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

	[DefaultValue(false)]
	public bool PageLineUnderPageBreak
	{
		get
		{
			return z0quk;
		}
		set
		{
			z0quk = value;
		}
	}

	[DefaultValue(true)]
	public bool EnableChineseFontSizeName
	{
		get
		{
			return z0xyk;
		}
		set
		{
			z0xyk = value;
		}
	}

	[DefaultValue(true)]
	public bool EnableDeleteReadonlyEmptyContainer
	{
		get
		{
			return z0zek;
		}
		set
		{
			z0zek = value;
		}
	}

	[DefaultValue(936)]
	public int EncodingCodePageForWriteRTF
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
	public bool AllowDragContent
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

	[DefaultValue(WriterDataFormats.All)]
	public WriterDataFormats CreationDataFormats
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

	[DefaultValue(null)]
	public string ImageShapeEditorBackgroundMenuItemConfig
	{
		get
		{
			return z0zyk;
		}
		set
		{
			z0zyk = value;
		}
	}

	[DefaultValue(false)]
	public bool ParagraphFlagFollowTableOrSection
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

	[DefaultValue(FormViewMode.Disable)]
	public FormViewMode FormView
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

	[DefaultValue(false)]
	public bool RaiseQueryListItemsWhenUserEditText
	{
		get
		{
			return z0brk_jiejie20260327142557;
		}
		set
		{
			z0brk_jiejie20260327142557 = value;
		}
	}

	[DefaultValue(DCImageCompressSaveMode.Prompt)]
	public DCImageCompressSaveMode ImageCompressSaveMode
	{
		get
		{
			return z0nyk;
		}
		set
		{
			z0nyk = value;
		}
	}

	[DefaultValue(false)]
	public bool FillCommentToUserTrackList
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

	[DefaultValue(false)]
	public bool WeakMode
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

	[DefaultValue(false)]
	public bool AutoAssistInsertString
	{
		get
		{
			return z0hrk_jiejie20260327142557;
		}
		set
		{
			z0hrk_jiejie20260327142557 = value;
		}
	}

	[z0ZzZzbjh]
	[DefaultValue(false)]
	[z0ZzZzyqh]
	public bool EnableCollapseSection
	{
		get
		{
			return z0otk;
		}
		set
		{
			z0otk = value;
		}
	}

	[DefaultValue(false)]
	public bool SpecifyDebugMode
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
	public bool ResetTextFormatWhenCreateNewLine
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
	public bool HandleCommandException
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

	[DefaultValue(true)]
	public bool NewExpressionExecuteMode
	{
		get
		{
			return z0zuk;
		}
		set
		{
			z0zuk = value;
		}
	}

	public DocumentBehaviorOptions Clone()
	{
		return (DocumentBehaviorOptions)((ICloneable)this).Clone();
	}

	private object z0eek()
	{
		return (DocumentBehaviorOptions)MemberwiseClone();
	}

	object ICloneable.Clone()
	{
		//ILSpy generated this explicit interface implementation from .override directive in z0eek
		return this.z0eek();
	}
}
