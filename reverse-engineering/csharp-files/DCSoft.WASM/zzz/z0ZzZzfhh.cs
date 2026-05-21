using System;
using DCSoft.Chart;
using DCSoft.Common;
using DCSoft.Data;
using DCSoft.Drawing;
using DCSoft.Printing;
using DCSoft.WinForms;
using DCSoft.Writer;
using DCSoft.Writer.Dom;
using DCSoft.Writer.MedicalExpression;
using DCSoft.Writer.Security;
using DCSystem_Drawing;
using DCSystem_Drawing.Drawing2D;

namespace zzz;

public static class z0ZzZzfhh
{
	internal static readonly string z0rek = "FieldNameForLink";

	internal static readonly string z0tek = "LinkListBinding";

	internal static readonly string z0yek = "ShapeDocumentImagePage";

	internal static readonly string z0uek = "ClientName";

	internal static readonly string z0iek = "NumOfPage";

	internal static readonly string z0oek = "Height";

	internal static readonly string z0pek = "Printable";

	internal static readonly string z0mek = "DocumentEditState";

	internal static readonly string z0nek_jiejie20260327142557 = "KeyFieldName";

	internal static readonly string z0bek = "DownleadWidth";

	internal static readonly string z0vek = "ShapeLineElement";

	internal static readonly string[] z0cek = new string[9] { "None", "Parent", "InputField", "TableCell", "TableRow", "Table", "Section", "Body", "Document" };

	internal static readonly string z0xek = "TextInMiddlePage";

	internal static readonly string z0zek = "CommandName";

	internal static readonly string z0lrk = "CloneMultipleBaseForBindingDataSource";

	internal static readonly string z0krk = "LimitedInputChars";

	internal static readonly string z0jrk = "AllowUserInsertRow";

	internal static readonly string z0hrk = "SignClientName";

	internal static readonly string z0grk = "RedLineWidth";

	internal static readonly string z0frk = "ShowGutterLine";

	internal static readonly string z0drk = "Source";

	internal static readonly string z0srk = "AutoHeightForMultiline";

	internal static readonly string z0ark = "ValuePath";

	internal static readonly string z0qrk = "PartitionImage";

	internal static readonly string z0wrk = "LabelAtLeft";

	internal static readonly string z0erk = "KeyFeildDataSourcePath";

	internal static readonly string z0rrk = "Angle";

	internal static readonly string z0trk = "HeaderDistance";

	internal static readonly string z0yrk = "NormalRangeBackColor";

	internal static readonly string z0urk = "YAxis";

	internal static readonly string[] z0irk = new string[9] { "None", "TopLeftOneLine", "TopLeftTwoLines", "TopRightOneLine", "TopRightTwoLines", "BottomRightOneLine", "BottomRigthTwoLines", "BottomLeftOneLine", "BottomLeftTwoLines" };

	internal static readonly string z0ork = "FooterLines";

	internal static readonly string z0prk = "Body";

	internal static readonly string z0mrk = "FieldName";

	internal static readonly string z0nrk = "ContentLoaded";

	internal static readonly string z0brk_jiejie20260327142557 = "Data";

	internal static readonly string z0vrk = "AllowInsertRowDownUseHotKey";

	internal static readonly string z0crk = "ValueBinding";

	internal static readonly string z0xrk = "ControlHost";

	internal static readonly string z0zrk = "Thickness";

	internal static readonly string z0ltk = "ForeColor";

	internal static readonly string z0ktk = "Item";

	internal static readonly string z0jtk = "Cursor";

	internal static readonly string z0htk = "ScriptText";

	internal static readonly string z0gtk = "Top";

	internal static readonly string z0ftk = "TextInList";

	internal static readonly string z0dtk = "AllowUserDeleteRow";

	internal static readonly string[] z0stk = new string[2] { "EmbedInText", "Surroundings" };

	internal static readonly string z0atk = "TitleColor";

	internal static readonly string z0qtk = "AuthorName";

	internal static readonly string z0wtk = "Italic";

	internal static readonly string z0etk = "ImageForDown";

	internal static readonly string z0rtk = "DataForReValueBinding";

	internal static readonly string z0ttk = "AutoSize";

	internal static readonly string z0ytk = "Comments";

	internal static readonly string z0utk = "IntCharLantern";

	internal static readonly string z0itk = "TerminalText";

	internal static readonly string z0otk = "Header";

	internal static readonly string z0ptk = "FieldNameForLanternValue";

	internal static readonly string z0mtk = "Visible";

	internal static readonly string z0ntk = "Parameter";

	internal static readonly string z0btk = "GridValueFormat";

	internal static readonly string z0vtk = "CreationTime";

	internal static readonly string z0ctk = "CircleText";

	internal static readonly string z0xtk = "DefaultFont";

	internal static readonly string z0ztk = "CaptionAlign";

	internal static readonly string z0lyk = "SpecifyPageIndex";

	internal static readonly string z0kyk = "DateFormatStringForCrossMonth";

	internal static readonly string z0jyk = "EditValuePointMode";

	internal static readonly string z0hyk = "MRID";

	internal static readonly string z0gyk = "MaxMinValueStyle";

	internal static readonly string z0fyk = "Repeat";

	internal static readonly string z0dyk = "ValueTextBackColor";

	internal static readonly string z0syk = "DataGridTopPadding";

	internal static readonly string z0ayk = "YSplitNum";

	internal static readonly string z0qyk = "PieOpacity";

	internal static readonly string z0wyk = "WriteTextBindingPath";

	internal static readonly string z0eyk = "BlankLine";

	internal static readonly string[] z0ryk = new string[3] { "Error", "Warring", "Info" };

	internal static readonly string z0tyk = "DataFieldNameForSeriesName";

	internal static readonly string z0yyk = "ColorForUpValue";

	internal static readonly string z0uyk = "BorderTopColor";

	internal static readonly string z0iyk_jiejie20260327142557 = "LightCorrectionFactor";

	internal static readonly string z0oyk = "AfterOperaDaysFromZero";

	internal static readonly string z0pyk = "EntryID";

	internal static readonly string z0myk = "Button";

	internal static readonly string z0nyk = "ExtendGridLineType";

	internal static readonly string z0byk = "TitleValueDispalyFormat";

	internal static readonly string z0vyk = "Bold";

	internal static readonly string z0cyk = "SeriesName";

	internal static readonly string z0xyk = "ShapePolygonElement";

	internal static readonly string z0zyk = "TopPadding";

	internal static readonly string z0luk = "TopicID";

	internal static readonly string z0kuk = "DefaultCheckedForValueBinding";

	internal static readonly string z0juk = "ThinLineWidth";

	internal static readonly string z0huk = "SourceName";

	internal static readonly string z0guk = "ExpressionStyle";

	internal static readonly string z0fuk = "LicenseText";

	internal static readonly string z0duk = "BorderColor";

	internal static readonly string z0suk = "DeleterIndex";

	internal static readonly string z0auk = "TimeoutHours";

	internal static readonly string z0quk = "ContentStyles";

	internal static readonly string z0wuk = "TimeFieldName";

	internal static readonly string z0euk = "BackColor";

	internal static readonly string z0ruk = "DocumentContentVersion";

	internal static readonly string z0tuk = "TickLineVisible";

	internal static readonly string z0yuk = "MinBarWidth";

	internal static readonly string z0uuk = "CheckBoxVisible";

	internal static readonly string z0iuk = "CustomColorTheme";

	internal static readonly string z0ouk = "SymbolSize";

	internal static readonly string z0puk = "PrintTextForUnChecked";

	internal static readonly string z0muk_jiejie20260327142557 = "PrintBothBorderWhenJumpPrint";

	internal static readonly string z0nuk = "GridTextHeight";

	internal static readonly string z0buk = "IntCharSymbol";

	internal static readonly string z0vuk = "XSpaces";

	internal static readonly string z0cuk = "Items";

	internal static readonly string z0xuk = "AuthorID";

	internal static readonly string z0zuk = "LineWidth";

	internal static readonly string[] z0lik = new string[11]
	{
		"None", "Single", "Thick", "Dash", "Dot", "DashDot", "DashDotDot", "Double", "Wavy", "WavyDouble",
		"WavyHeavy"
	};

	internal static readonly string z0kik = "Author";

	internal static readonly string z0jik = "Size";

	internal static readonly string z0hik = "CheckMaxValue";

	internal static readonly string z0gik = "AutoUpdateTargetElement";

	internal static readonly string z0fik = "BarGroupSpacing";

	internal static readonly string z0dik = "VerticalAlign";

	internal static readonly string z0sik = "HeaderLabels";

	internal static readonly string z0aik = "AuthorPermissionLevel";

	internal static readonly string z0qik = "GenerateByValueBingding";

	internal static readonly string z0wik = "Group";

	internal static readonly string z0eik = "MiterLimit";

	internal static readonly string z0rik = "NextTarget";

	internal static readonly string z0tik = "Text";

	internal static readonly string z0yik = "BindingUserTrack";

	internal static readonly string z0uik = "BorderRightColor";

	internal static readonly string z0iik = "Datas";

	internal static readonly string z0oik = "MarginLeft";

	internal static readonly string z0pik = "X2";

	internal static readonly string z0mik = "PageIndexsForShowBackgroundImage";

	internal static readonly string z0nik = "ChartStyle";

	internal static readonly string z0bik = "ImportHeader";

	internal static readonly string[] z0vik = new string[6] { "None", "Auto", "Button", "FloatButton", "ComboBoxButton", "DateTimePicker" };

	internal static readonly string z0cik = "BufferItems";

	internal static readonly string z0xik = "Background";

	internal static readonly string z0zik = "DefaultSignMode";

	internal static readonly string z0lok = "CanBeReferenced";

	internal static readonly string z0kok = "StrictMatchPageIndex";

	internal static readonly string z0jok = "ValueIndexOfRepeatedImage";

	internal static readonly string z0hok = "AlignToGrid";

	internal static readonly string z0gok = "EndingLineBreak";

	internal static readonly string z0fok_jiejie20260327142557 = "Time";

	internal static readonly string z0dok = "SwapGutter";

	internal static readonly string z0sok = "Default";

	internal static readonly string z0aok = "TemplateSourceFormatString";

	internal static readonly string z0qok = "VAlign";

	internal static readonly string z0wok = "Underline";

	internal static readonly string[] z0eok = new string[3] { "Default", "RichTextBoxCompatibility", "OldCompatibility" };

	internal static readonly string z0rok = "DashCap";

	internal static readonly string[] z0tok = new string[4] { "PageIndex", "NumOfPages", "LocalPageIndex", "LocalNumOfPages" };

	internal static readonly string z0yok = "DensityForRepeat";

	internal static readonly string z0uok = "Document";

	internal static readonly string z0iok = "FieldNameForValue";

	internal static readonly string z0ook = "Type";

	internal static readonly string z0pok = "CustomShape";

	internal static readonly string z0mok = "DateFormatStringForCrossWeek";

	internal static readonly string z0nok = "FieldNameForTitle";

	internal static readonly string z0bok = "MotherTemplate";

	internal static readonly string z0vok = "PageIndexText";

	internal static readonly string[] z0cok = new string[4] { "L", "M", "Q", "H" };

	internal static readonly string z0xok = "PageTexts";

	internal static readonly string z0zok = "FileSystemName";

	internal static readonly string z0lpk = "MarginBottom";

	internal static readonly string z0kpk = "BarcodeField";

	internal static readonly string z0jpk = "SpecifyStartDate";

	internal static readonly string[] z0hpk = new string[3] { "None", "Partial", "Both" };

	internal static readonly string z0gpk = "EditorControlTypeName";

	internal static readonly string[] z0fpk = new string[3] { "None", "LeftRightAndUpDown", "UpDownAndLeftRight" };

	internal static readonly string z0dpk = "SubEntries";

	internal static readonly string z0spk = "SpecifySymbolStyle";

	internal static readonly string z0apk = "WhiteSpaceLength";

	internal static readonly string z0qpk = "LetterSpacing";

	internal static readonly string z0wpk = "Name2";

	internal static readonly string z0epk = "ThickLineWidth";

	internal static readonly string z0rpk = "CheckboxVisibility";

	internal static readonly string z0tpk = "TargetPropertyName";

	internal static readonly string z0ypk = "DataFieldNameForFillColorString";

	internal static readonly string z0upk = "ExpendForDataBinding";

	internal static readonly string z0ipk = "AllowInterrupt";

	internal static readonly string z0opk = "AllowUserCollapseZone";

	internal static readonly string[] z0ppk = new string[4] { "Visible", "Hidden", "Default", "AlwaysVisible" };

	internal static readonly string z0mpk = "RegExpression";

	internal static readonly string z0npk = "Digitals";

	internal static readonly string z0bpk = "ZOrderStyle";

	internal static readonly string z0vpk = "ForPOSPrinter";

	internal static readonly string z0cpk = "UserFlag";

	internal static readonly string z0xpk = "DateFormatStringForFirstIndexOtherPage";

	internal static readonly string z0zpk = "LanternValueColorForDownValue";

	internal static readonly string z0lmk = "CheckAlignLeft";

	internal static readonly string z0kmk = "LineLengthInCM";

	internal static readonly string z0jmk = "UnderlineColor";

	internal static readonly string z0hmk = "LegendStyle";

	internal static readonly string z0gmk = "LonelyChecked";

	internal static readonly string[] z0fmk = new string[3] { "Default", "Crystal", "Nomal" };

	internal static readonly string z0dmk = "Printed";

	internal static readonly string z0smk = "HorizontalTextAlign";

	internal static readonly string z0amk = "CanSplitByPageLine";

	internal static readonly string z0qmk = "KeepWidthHeightRate";

	internal static readonly string[] z0wmk = new string[3] { "True", "False", "Inherit" };

	internal static readonly string z0emk = "PieDocumentStyle";

	internal static readonly string z0rmk = "Subscript";

	internal static readonly string z0tmk = "DefaultSelectedIndexs";

	internal static readonly string z0ymk = "GridBorderLineStyle";

	internal static readonly string z0umk = "GridYSplitNum";

	internal static readonly string z0imk = "XImage";

	internal static readonly string z0omk = "ColorForDownValue";

	internal static readonly string z0pmk = "PageBreak";

	internal static readonly string z0mmk = "SpecifyTitleHeight";

	internal static readonly string z0nmk = "DocumentProcessState";

	internal static readonly string z0bmk = "GridYSpaceNumForBottomPadding";

	internal static readonly string z0vmk = "AllowUserPressTabKeyToInsertRowDown";

	internal static readonly string z0cmk = "ShapeZoomInElement";

	internal static readonly string z0xmk = "ForceUpWhenPageFirstPoint";

	internal static readonly string z0zmk = "AutoExitEditMode";

	internal static readonly string[] z0lnk = new string[3] { "None", "Content", "Range" };

	internal static readonly string z0knk = "Checked";

	internal static readonly string[] z0jnk = new string[3] { "Top", "Middle", "Bottom" };

	internal static readonly string z0hnk = "AutoPaperWidth";

	internal static readonly string z0gnk = "AfterOperaDaysBeginOne";

	internal static readonly string z0fnk = "DivCharForMultiMode";

	internal static readonly string z0dnk = "ChangePageIndexMidway";

	internal static readonly string z0snk = "LineBreak";

	internal static readonly string z0ank = "SpecifyTickWidth";

	internal static readonly string z0qnk = "SlantSplitLineStyle";

	internal static readonly string z0wnk = "TitleVisible";

	internal static readonly string z0enk = "CheckDecimalDigits";

	internal static readonly string z0rnk = "DescPropertyName";

	internal static readonly string z0tnk = "LinkTextForContactAction";

	internal static readonly string[] z0ynk = new string[6] { "None", "NextField", "BeforeFieldBegin", "AfterFieldBegin", "BeforeFieldEnd", "AfterFieldEnd" };

	internal static readonly string z0unk = "ShapeDocument";

	internal static readonly string z0ink = "BorderSpacing";

	internal static readonly string z0onk = "ValuePropertyName";

	internal static readonly string z0pnk = "LineSize";

	internal static readonly string z0mnk = "HeaderStyle";

	internal static readonly string z0nnk = "Table";

	internal static readonly string z0bnk_jiejie20260327142557 = "SQLTextForHeaderLabel";

	internal static readonly string z0vnk = "DynamicListItems";

	internal static readonly string z0cnk = "JointPrintNumber";

	internal static readonly string z0xnk = "AllowUserToResizeColumns";

	internal static readonly string z0znk = "ShowLegendInRule";

	internal static readonly string z0lbk = "DataSourceRowSpan";

	internal static readonly string z0kbk = "LeftSide";

	internal static readonly string z0jbk = "CommentIndex";

	internal static readonly string z0hbk = "EnableLanternValue";

	internal static readonly string z0gbk = "Section";

	internal static readonly string z0fbk = "ContentSource";

	internal static readonly string z0dbk = "FieldSettings";

	internal static readonly string z0sbk = "DataFieldNameForGroupName";

	internal static readonly string z0abk = "ShowPageIndex";

	internal static readonly string z0qbk = "ValueTypeFullName";

	internal static readonly string z0wbk = "AutoFixFontSizeMode";

	internal static readonly string z0ebk = "Range";

	internal static readonly string z0rbk = "Ticks";

	internal static readonly string z0tbk = "Attributes";

	internal static readonly string z0ybk = "TickUnit";

	internal static readonly string z0ubk = "BarSpacing";

	internal static readonly string z0ibk = "SubDocumentSettings";

	internal static readonly string z0obk = "Cells";

	internal static readonly string z0pbk = "NoneText";

	internal static readonly string z0mbk = "Y1";

	internal static readonly string z0nbk = "CheckMinValue";

	internal static readonly string z0bbk = "BigTitleFontSize";

	internal static readonly string z0vbk = "ControlStyle";

	internal static readonly string[] z0cbk = new string[2] { "CheckBox", "RadioBox" };

	internal static readonly string z0xbk = "Entry";

	internal static readonly string z0zbk = "Chart";

	internal static readonly string z0lvk = "FixedSpacing";

	internal static readonly string z0kvk = "Comment";

	internal static readonly string z0jvk = "BorderBottom";

	internal static readonly string z0hvk = "RTFLineSpacing";

	internal static readonly string z0gvk = "FormButtonStyle";

	internal static readonly string z0fvk = "BigVerticalGridLineColor";

	internal static readonly string z0dvk = "GridLineType";

	internal static readonly string z0svk = "Superscript";

	internal static readonly string z0avk = "MirrorViewForCrossPage";

	internal static readonly string z0qvk = "ReferenceCount";

	internal static readonly string z0wvk = "ValueIndex";

	internal static readonly string z0evk = "LayoutType";

	internal static readonly string z0rvk = "SignRange";

	internal static readonly string z0tvk = "ShapeContainerElement";

	internal static readonly string z0yvk = "DelayLoadWhenExpand";

	internal static readonly string z0uvk = "Footer";

	internal static readonly string z0ivk = "ShowFormButton";

	internal static readonly string z0ovk = "EditMinute";

	internal static readonly string[] z0pvk = new string[3] { "None", "Circle", "Rectangle" };

	internal static readonly string z0mvk = "IllegalTextEndCharForLinux";

	internal static readonly string z0nvk = "HollowCovertTargetName";

	internal static readonly string z0bvk_jiejie20260327142557 = "EnableExtMouseMoveEvent";

	internal static readonly string z0vvk = "IsIdentyPartition";

	internal static readonly string z0cvk = "AutoCreate";

	internal static readonly string z0xvk = "ColSpan";

	internal static readonly string z0zvk_jiejie20260327142557 = "ShapeRectangleElement";

	internal static readonly string z0lck_jiejie20260327142557 = "HeaderForFirstPage";

	internal static readonly string z0kck = "StringTag";

	internal static readonly string z0jck = "Remark";

	internal static readonly string z0hck = "DateFormatStringForFirstIndexFirstPage";

	internal static readonly string z0gck = "AutoTickStepSeconds";

	internal static readonly string z0fck = "Label";

	internal static readonly string z0dck = "OffsetY";

	internal static readonly string z0sck = "MarginTop";

	internal static readonly string z0ack = "UnitText";

	internal static readonly string z0qck = "ValueDisplayFormat";

	internal static readonly string z0wck = "ParameterName";

	internal static readonly string z0eck_jiejie20260327142557 = "EnableDataGridLinearAxisMode";

	internal static readonly string z0rck = "EditMode";

	internal static readonly string z0tck = "MultiLine";

	internal static readonly string z0yck = "ListItemsSourceFormatString";

	internal static readonly string z0uck = "Color2";

	internal static readonly string z0ick = "Line";

	internal static readonly string[] z0ock = new string[3] { "Default", "Normal", "SignHand" };

	internal static readonly string z0pck = "FontSize";

	internal static readonly string z0mck = "AutoHeight";

	internal static readonly string z0nck = "BorderStyle";

	internal static readonly string z0bck = "PrintVisibilityExpression";

	internal static readonly string[] z0vck = new string[3] { "Visible", "Hidden", "None" };

	internal static readonly string z0cck = "InnerRepeatImageDataList";

	internal static readonly string z0xck = "Labels";

	internal static readonly string z0zck = "Readonly";

	internal static readonly string z0lxk = "ScriptLanguage";

	internal static readonly string[] z0kxk = new string[3] { "Always", "Once", "Never" };

	internal static readonly string z0jxk = "TitleAlign";

	internal static readonly string z0hxk = "SpecifyLanternSymbolStyle";

	internal static readonly string z0gxk = "CustomValueEditorTypeName";

	internal static readonly string z0fxk = "DebugMode";

	internal static readonly string z0dxk = "EnableValueEditor";

	internal static readonly string z0sxk = "PreviewImageData";

	internal static readonly string z0axk = "StartDateKeyword";

	internal static readonly string z0qxk = "OldWhitespaceWidth";

	internal static readonly string z0wxk = "LastPrintTime";

	internal static readonly string z0exk = "ListSource";

	internal static readonly string z0rxk = "Unit";

	internal static readonly string z0txk = "PFlag";

	internal static readonly string z0yxk = "UnitMode";

	internal static readonly string z0uxk = "LocalElementStyleMode";

	internal static readonly string z0ixk = "CheckedUserHistories";

	internal static readonly string z0oxk = "HeaderFooterDifferentFirstPage";

	internal static readonly string[] z0pxk = new string[3] { "None", "Image", "Text" };

	internal static readonly string z0mxk = "DocumentType";

	internal static readonly string z0nxk = "AutoSetSpellCodeInDropdownList";

	internal static readonly string[] z0bxk = new string[3] { "Left", "Top", "Right" };

	internal static readonly string z0vxk = "ImgBase64ForCustomFill";

	internal static readonly string z0cxk = "ItemBorderStyle";

	internal static readonly string z0xxk = "Index";

	internal static readonly string[] z0zxk = new string[3] { "Normal", "UnderText", "InFrontOfText" };

	internal static readonly string z0lzk = "EnableFieldTextColor";

	internal static readonly string z0kzk = "StartPositionInPringJob";

	internal static readonly string z0jzk_jiejie20260327142557 = "BottomTitle";

	internal static readonly string z0hzk = "LineWidthZoomRateWhenPrint";

	internal static readonly string z0gzk = "CheckedTime";

	internal static readonly string z0fzk = "Info";

	internal static readonly string z0dzk = "AllowReBindingDataSource";

	internal static readonly string z0szk = "ShowGrid";

	internal static readonly string z0azk = "BorderBottomColor";

	internal static readonly string z0qzk = "BarBorderPen";

	internal static readonly string z0wzk = "PowerDocumentGridLine";

	internal static readonly string z0ezk = "FieldNameForText";

	internal static readonly string z0rzk = "NormalMinValue";

	internal static readonly string z0tzk = "PageTitleTexts";

	internal static readonly string z0yzk = "HiddenPrintWhenEmpty";

	internal static readonly string z0uzk = "StyleIndex";

	internal static readonly string z0izk = "PreserveStartKeywordOrder";

	internal static readonly string z0ozk = "ColorTheme";

	internal static readonly string z0pzk = "DataSourceName";

	internal static readonly string z0mzk = "PrintColor";

	internal static readonly string[] z0nzk = new string[8] { "None", "Numeric", "Currency", "DateTime", "String", "SpecifyLength", "Boolean", "Percent" };

	internal static readonly string[] z0bzk = new string[7] { "Text", "DropdownList", "Date", "DateTime", "DateTimeWithoutSecond", "Time", "Numeric" };

	internal static readonly string z0vzk = "DefaultValueForValueBinding";

	internal static readonly string z0czk = "Row";

	internal static readonly string z0xzk = "MaxDecimalDigits";

	internal static readonly string z0zzk = "PageInfo";

	internal static readonly string z0llj = "InsertEmptyPageForNewPage";

	internal static readonly string z0klj_jiejie20260327142557 = "TemplateFileFormat";

	internal static readonly string z0jlj = "TypeName";

	internal static readonly string z0hlj = "Parameters";

	internal static readonly string z0glj = "EmitDataFieldName";

	internal static readonly string z0flj = "TickStep";

	internal static readonly string z0dlj = "RightToLeft";

	internal static readonly string z0slj = "KB";

	internal static readonly string z0alj = "HorizontalLine";

	internal static readonly string z0qlj = "LanternValueFieldName";

	internal static readonly string z0wlj = "UpAndDownTextType";

	internal static readonly string z0elj = "IncludeKeywords";

	internal static readonly string z0rlj = "BlockWidth";

	internal static readonly string z0tlj = "BorderTextPosition";

	internal static readonly string z0ylj = "InputField";

	internal static readonly string z0ulj = "IgnoreChildElements";

	internal static readonly string z0ilj = "ProtectType";

	internal static readonly string z0olj = "ParagraphMultiLevel";

	internal static readonly string z0plj = "DataGridBottomPadding";

	internal static readonly string z0mlj = "BarWidth";

	internal static readonly string z0nlj = "DataForSelfCheck";

	internal static readonly string z0blj = "TabIndex";

	internal static readonly string[] z0vlj = new string[18]
	{
		"Bar", "CascadeBar", "PercentBar", "HorizBar", "HorizCascadeBar", "HorizPercentBar", "ColumnBar", "CascadeColumnBar", "PercentColumnBar", "HorizColumnBar",
		"HorizCascadeColumnBar", "HorizPercentColumnBar", "Line", "Area", "HorizLine", "HorizArea", "Point", "HorizPoint"
	};

	internal static readonly string z0clj = "AuthorisedUserIDList";

	internal static readonly string z0xlj = "GridLineColor";

	internal static readonly string z0zlj = "MedicalExpressionField";

	internal static readonly string z0lkj = "SingleParagraphStyleIndex";

	internal static readonly string z0kkj = "PrinterName";

	internal static readonly string z0jkj = "EmitDataSource";

	internal static readonly string z0hkj = "PrintCellBorder";

	internal static readonly string z0gkj = "EntryTemplateContent";

	internal static readonly string[] z0fkj = new string[4] { "Default", "Bar", "Line", "Point" };

	internal static readonly string z0dkj_jiejie20260327142557 = "DataFieldNameForTipText";

	internal static readonly string[] z0skj = new string[3] { "Visible", "HiddenCheckBoxOnly", "HiddenAll" };

	internal static readonly string z0akj = "VerticalLine";

	internal static readonly string z0qkj = "LoopTextList";

	internal static readonly string z0wkj = "LayoutDirection";

	internal static readonly string z0ekj = "ShowInputFieldStateTag";

	internal static readonly string z0rkj = "MultiSelect";

	internal static readonly string z0tkj = "MaxInputLength";

	internal static readonly string z0ykj = "DesignerPaperHeight";

	internal static readonly string z0ukj_jiejie20260327142557 = "DisplayLevel";

	internal static readonly string z0ikj = "VisibleWhenNoValuePoint";

	internal static readonly string z0okj = "BackgroundColor";

	internal static readonly string z0pkj = "DelayLoadControl";

	internal static readonly string z0mkj = "WebClientHtmlText";

	internal static readonly string z0nkj = "LineStyle";

	internal static readonly string z0bkj_jiejie20260327142557 = "SpecifyEndDate";

	internal static readonly string z0vkj = "MeasureMode";

	internal static readonly string z0ckj = "ShowPointValue";

	internal static readonly string[] z0xkj = new string[15]
	{
		"Rectangle", "Square", "Ellipse", "Circle", "Diamond", "TriangleUp", "TriangleRight", "TriangleDown", "TriangleLeft", "Cross",
		"XCross", "CircleCross", "CircleXCross", "Default", "None"
	};

	internal static readonly string z0zkj = "OwnerLevel";

	internal static readonly string z0ljj = "PrintBackColor";

	internal static readonly string z0kjj = "AccountingNumber";

	internal static readonly string z0jjj = "AllowUserEditCurrentPageLabelText";

	internal static readonly string z0hjj = "FooterDescription";

	internal static readonly string z0gjj = "PaddingBottom";

	internal static readonly string z0fjj = "BrushStyle";

	internal static readonly string z0djj = "Styles";

	internal static readonly string z0sjj = "LastVerifyResult";

	internal static readonly string[] z0ajj = new string[10] { "FourValues", "FourValues1", "FourValues2", "ThreeValues", "Pupil", "LightPositioning", "FetalHeart", "PermanentTeethBitmap", "DeciduousTeech", "PainIndex" };

	internal static readonly string z0qjj = "AllowUserToResizeHeight";

	internal static readonly string z0wjj = "SignUserID";

	internal static readonly string z0ejj = "ShapeEllipseElement";

	internal static readonly string z0rjj = "Font";

	internal static readonly string z0tjj = "IsMultiSelect";

	internal static readonly string z0yjj = "Precision";

	internal static readonly string z0ujj = "DocumentID";

	internal static readonly string z0ijj = "ParagraphListStyle";

	internal static readonly string z0ojj = "TextColor";

	internal static readonly string z0pjj = "EnableEndTime";

	internal static readonly string z0mjj = "UpdateState";

	internal static readonly string z0njj = "StartBorderText";

	internal static readonly string z0bjj = "ImageForMouseOver";

	internal static readonly string z0vjj = "AbNormalRangeSettings";

	internal static readonly string z0cjj = "DepartmentName";

	internal static readonly string z0xjj = "OutofNormalRangeBackColor";

	internal static readonly string z0zjj = "GridBackground";

	internal static readonly string z0lhj = "BorderElementColor";

	internal static readonly string z0khj = "InnerID";

	internal static readonly string z0jhj = "EditStyle";

	internal static readonly string z0hhj = "BarcodeType";

	internal static readonly string z0ghj = "CharValue";

	internal static readonly string z0fhj = "BottomMargin";

	internal static readonly string z0dhj = "AutoZoomFontSize";

	internal static readonly string z0shj = "IsSelect";

	internal static readonly string[] z0ahj = new string[4] { "invisible", "none", "mini", "full" };

	internal static readonly string z0qhj = "TickTextList";

	internal static readonly string z0whj = "DocumentGridLine";

	internal static readonly string z0ehj = "CompressOwnerLineSpacing";

	internal static readonly string z0rhj = "NumOfDaysInOnePage";

	internal static readonly string z0thj = "RequiredInvalidateFlag";

	internal static readonly string[] z0yhj = new string[7] { "AutoDetect", "Control", "OCX", "NativeWinControl", "WPF", "DocumentImage", "InvalidateType" };

	internal static readonly string z0uhj = "Alpha";

	internal static readonly string z0ihj = "GridYSplitInfo";

	internal static readonly string z0ohj = "AutoChoosePageSize";

	internal static readonly string z0phj = "EndBorderText";

	internal static readonly string z0mhj = "HeaderLines";

	internal static readonly string z0nhj = "DrawContentHandlerName";

	internal static readonly string z0bhj = "Media";

	internal static readonly string z0vhj = "Pie";

	internal static readonly string z0chj = "BigVerticalGridLineWidth";

	internal static readonly string z0xhj = "GridStep";

	internal static readonly string z0zhj = "PageIndexFix";

	internal static readonly string[] z0lgj = new string[7] { "Text", "Integer", "Numeric", "Date", "Time", "DateTime", "RegExpress" };

	internal static readonly string z0kgj = "ValueType";

	internal static readonly string z0jgj = "MinLength";

	internal static readonly string z0hgj = "DataEncryptProviderName";

	internal static readonly string z0ggj = "IsTemplate";

	internal static readonly string z0fgj = "FileFormat";

	internal static readonly string z0dgj = "YAxisInfos";

	internal static readonly string z0sgj = "FieldNameForTime";

	internal static readonly string z0agj = "ReplaceUpdateMode";

	internal static readonly string z0qgj = "XBean";

	internal static readonly string z0wgj = "DrawingStyle";

	internal static readonly string z0egj = "DocumentContentStyle";

	internal static readonly string z0rgj = "ImageDataBase64String";

	internal static readonly string z0tgj = "SpecifyPageIndexTextList";

	internal static readonly string z0ygj = "ImportPageSettings";

	internal static readonly string z0ugj = "SpecifyHeight";

	internal static readonly string z0igj = "StartCap";

	internal static readonly string z0ogj = "EnableCustomValuePointSymbol";

	internal static readonly string z0pgj = "InnerValue";

	internal static readonly string z0mgj = "EnableEditImageAdditionShape";

	internal static readonly string z0ngj = "ControlType";

	internal static readonly string z0bgj = "FileContentType";

	internal static readonly string z0vgj = "BorderTop";

	internal static readonly string z0cgj = "BackgroundTextItalic";

	internal static readonly string z0xgj = "GridSpanInCM";

	internal static readonly string z0zgj = "Reference";

	internal static readonly string z0lfj = "SaveLinkedContent";

	internal static readonly string z0kfj = "TDBarcode";

	internal static readonly string z0jfj = "EventExpressions";

	internal static readonly string z0hfj = "OffsetX";

	internal static readonly string z0gfj = "XAxisCaption";

	internal static readonly string z0ffj = "ParameterStyle";

	internal static readonly string z0dfj = "StringValue";

	internal static readonly string z0sfj = "LineJoin";

	internal static readonly string z0afj = "PageIndexFont";

	internal static readonly string z0qfj = "EditorActiveMode";

	internal static readonly string z0wfj = "UseLanguage2";

	internal static readonly string z0efj = "GridNumInOnePage";

	internal static readonly string z0rfj = "BindingPathForText";

	internal static readonly string z0tfj = "GroupName";

	internal static readonly string z0yfj = "RedLinePrintVisible";

	internal static readonly string z0ufj = "PieHeight";

	internal static readonly string z0ifj = "SymbolType";

	internal static readonly string z0ofj = "IdentyColorARGBValue";

	internal static readonly string z0pfj = "MinScale";

	internal static readonly string z0mfj = "ListValueSeparatorChar";

	internal static readonly string z0nfj = "OptionsPropertyName";

	internal static readonly string z0bfj = "AlignToGridLine";

	internal static readonly string z0vfj = "PositionFixModeForAutoHeightLine";

	internal static readonly string z0cfj = "FieldValue";

	internal static readonly string[] z0xfj = new string[5] { "Left", "Center", "Right", "Justify", "Distribute" };

	internal static readonly string z0zfj = "MaxScale";

	internal static readonly string z0ldj = "FieldNameForID";

	internal static readonly string z0kdj = "GutterStyle";

	internal static readonly string z0jdj = "MultiColumn";

	internal static readonly string z0hdj = "AdornTextType";

	internal static readonly string z0gdj = "AcceptTab";

	internal static readonly string z0fdj = "EnablePermission";

	internal static readonly string z0ddj = "RangeMask";

	internal static readonly string z0sdj = "ListIndex";

	internal static readonly string z0adj = "ShapeDocumentPage";

	internal static readonly string z0qdj = "Scale";

	internal static readonly string z0wdj = "CharacterCircle";

	internal static readonly string z0edj = "BinaryLength";

	internal static readonly string z0rdj = "Format";

	internal static readonly string[] z0tdj = new string[6] { "Default", "CheckBox", "RadioBox", "SystemDefault", "SystemCheckBox", "SystemRadioBox" };

	internal static readonly string z0ydj = "LinkInfo";

	internal static readonly string z0udj = "XParagraph";

	internal static readonly string z0idj = "SpacingBeforeParagraph";

	internal static readonly string z0odj = "ShowIcon";

	internal static readonly string z0pdj = "Sign";

	internal static readonly string z0mdj = "EditTimeBackgroundImage";

	internal static readonly string[] z0ndj = new string[3] { "True", "False", "Default" };

	internal static readonly string z0bdj = "OutofNormalRangeTextColor";

	internal static readonly string z0vdj = "RepulsionForGroup";

	internal static readonly string z0cdj = "RightMargin";

	internal static readonly string z0xdj = "ValueFormatString";

	internal static readonly string z0zdj = "TypeFullName";

	internal static readonly string z0lsj = "ListItems";

	internal static readonly string z0ksj = "SpecialTag";

	internal static readonly string z0jsj = "Value";

	internal static readonly string z0hsj = "Field";

	internal static readonly string z0gsj = "Colors";

	internal static readonly string z0fsj = "SeparatorLineVisible";

	internal static readonly string z0dsj = "TabStop";

	internal static readonly string z0ssj_jiejie20260327142557 = "BothBlackWhenPrint";

	internal static readonly string z0asj = "FontName";

	internal static readonly string z0qsj = "Alt";

	internal static readonly string z0wsj = "SignErrorMessage";

	internal static readonly string z0esj = "PaddingTop";

	internal static readonly string z0rsj = "PaperKind";

	internal static readonly string z0tsj = "SubDocumentSpacing";

	internal static readonly string z0ysj = "EnumLableType";

	internal static readonly string z0usj = "HiddenValueTitleBackColor";

	internal static readonly string z0isj = "AllowOutofRange";

	internal static readonly string z0osj = "LanternValueColorForUpValue";

	internal static readonly string z0psj = "VerifiedColor";

	internal static readonly string z0msj = "MaxTextDisplayLength";

	internal static readonly string z0nsj = "LanternValue";

	internal static readonly string[] z0bsj = new string[7] { "World", "Display", "Pixel", "Point", "Inch", "Document", "Millimeter" };

	internal static readonly string z0vsj = "UpAndDown";

	internal static readonly string z0csj = "KBID";

	internal static readonly string z0xsj = "LineStyleForLanternValue";

	internal static readonly string z0zsj = "BaseURL";

	internal static readonly string z0laj = "Color";

	internal static readonly string z0kaj = "StressBorder";

	internal static readonly string z0jaj = "GridLine";

	internal static readonly string[] z0haj = new string[5] { "Top", "Middle", "Bottom", "LeftTopRightBottom", "LeftBottomRightTop" };

	internal static readonly string z0gaj = "DateTimeMaxValue";

	internal static readonly string z0faj = "GroupGridLine";

	internal static readonly string z0daj = "DCDocument2022";

	internal static readonly string[] z0saj = new string[20]
	{
		"FourValuesGeneral", "FourValues", "FourValues1", "FourValues2", "ThreeValues", "Pupil", "LightPositioning", "FetalHeart", "PermanentTeethBitmap", "DeciduousTeech",
		"PainIndex", "PDTeech", "DiseasedTeethBotton", "DiseasedTeethTop", "Fraction", "ElectricPulpTestingTeeth", "StationaryBridgeTeeth", "ThreeValues2", "StrabismusSymbol", "ManyValues"
	};

	internal static readonly string z0aaj = "SignTime";

	internal static readonly string z0qaj = "Scales";

	internal static readonly string z0waj = "ShadowPointVisible";

	internal static readonly string z0eaj = "NextTargetID";

	internal static readonly string z0raj = "Multiline";

	internal static readonly string z0taj = "SaveContentInFile";

	internal static readonly string z0yaj = "LanternValueTitle";

	internal static readonly string z0uaj = "PaddingLeft";

	internal static readonly string[] z0iaj = new string[8] { "Text", "Boolean", "Numeric", "Date", "Time", "DateTime", "Binary", "Object" };

	internal static readonly string z0oaj = "PaperHeight";

	internal static readonly string z0paj = "AxisCompress";

	internal static readonly string[] z0maj = new string[5] { "Center", "Inset", "Outset", "Left", "Right" };

	internal static readonly string z0naj = "PageIndexsForHideHeaderFooter";

	internal static readonly string z0baj = "NormalMaxValue";

	internal static readonly string z0vaj = "Column";

	internal static readonly string z0caj = "AllowChainReaction";

	internal static readonly string z0xaj = "VisualStyle";

	internal static readonly string z0zaj = "PrintZoomRate";

	internal static readonly string z0lqj = "DateFormatStringForCrossYear";

	internal static readonly string[] z0kqj = new string[31]
	{
		"UNSPECIFIED", "UPCA", "UPCE", "SUPP2", "SUPP5", "EAN13", "EAN8", "Interleaved2of5", "Standard2of5", "I2of5",
		"Code39", "Code39Extended", "Code93", "Codabar", "PostNet", "BOOKLAND", "ISBN", "JAN13", "MSI_Mod10", "MSI_2Mod10",
		"MSI_Mod11", "MSI_Mod11_Mod10", "Modified_Plessey", "CODE11", "USD8", "UCC12", "UCC13", "LOGMARS", "Code128A", "Code128B",
		"Code128C"
	};

	internal static readonly string z0jqj = "CustomTargetName";

	internal static readonly string z0hqj = "SwapLeftRightMargin";

	internal static readonly string z0gqj = "DefaultEventExpression";

	internal static readonly string z0fqj = "EmphasisMark";

	internal static readonly string z0dqj = "LayoutAlign";

	internal static readonly string[] z0sqj = new string[4] { "FixSize", "Width", "Height", "WidthAndHeight" };

	internal static readonly string z0aqj = "GridBackColor";

	internal static readonly string z0qqj_jiejie20260327142557 = "GridTextWidth";

	internal static readonly string z0wqj = "CheckBox";

	internal static readonly string z0eqj = "Y2";

	internal static readonly string z0rqj = "Copies";

	internal static readonly string z0tqj = "ValueVisible";

	internal static readonly string z0yqj = "Left";

	internal static readonly string z0uqj = "FormatString";

	internal static readonly string z0iqj = "PageImages";

	internal static readonly string z0oqj = "ImagePixelHeight";

	internal static readonly string z0pqj = "CloneType";

	internal static readonly string z0mqj = "Content";

	internal static readonly string[] z0nqj = new string[3] { "None", "SingleLine", "MultiLine" };

	internal static readonly string z0bqj_jiejie20260327142557 = "ParagraphOutlineLevel";

	internal static readonly string z0vqj = "LeftMargin";

	internal static readonly string z0cqj = "ValueTextMultiLine";

	internal static readonly string z0xqj = "EditValueInDialog";

	internal static readonly string z0zqj = "Zone";

	internal static readonly string z0lwj = "ColorValue";

	internal static readonly string[] z0kwj = new string[11]
	{
		"Default", "Air", "Through", "Summer", "Pin", "Wave", "City", "Compose", "Energy", "Dance",
		"Custom"
	};

	internal static readonly string z0jwj = "LinkVisualStyle";

	internal static readonly string z0hwj = "BorderPrintedWhenJumpPrint";

	internal static readonly string z0gwj = "Tick";

	internal static readonly string z0fwj = "SavePreviewImage";

	internal static readonly string z0dwj = "ValidateStyle";

	internal static readonly string z0swj = "SpecifyFixedLineHeight";

	internal static readonly string z0awj = "LocalExcludeKeywords";

	internal static readonly string z0qwj = "XBookMark";

	internal static readonly string z0wwj = "ProcessState";

	internal static readonly string z0ewj = "ValueFont";

	internal static readonly string z0rwj = "CsMediaPlayer";

	internal static readonly string z0twj = "GutterPosition";

	internal static readonly string z0ywj = "GridLineOffsetX";

	internal static readonly string z0uwj = "Points";

	internal static readonly string z0iwj = "AcceptChildElementTypes2";

	internal static readonly string z0owj = "VerifiedAlignment";

	internal static readonly string z0pwj = "SelectionMode";

	internal static readonly string z0mwj = "ScriptTextForClick";

	internal static readonly string z0nwj = "UserHistories";

	internal static readonly string z0bwj = "TemplateDocuments";

	internal static readonly string z0vwj = "Barcode";

	internal static readonly string z0cwj = "ToolTip";

	internal static readonly string z0xwj = "BorderRange";

	internal static readonly string z0zwj = "DepartmentID";

	internal static readonly string z0lej = "BorderRight";

	internal static readonly string z0kej = "ExcludeKeywords";

	internal static readonly string z0jej = "SQLText";

	internal static readonly string z0hej = "EventName";

	internal static readonly string z0gej_jiejie20260327142557 = "AdditionShape";

	internal static readonly string z0fej = "MaxLength";

	internal static readonly string z0dej = "CustomMessage";

	internal static readonly string[] z0sej = new string[7] { "Disable", "Normal", "FirstSectionInPage", "LastSectionInPage", "TableRow", "FirstTableRowInPage", "LastTableRowInPage" };

	internal static readonly string z0aej = "Landscape";

	internal static readonly string z0qej = "LocalStyle";

	internal static readonly string z0wej = "SubfieldMode";

	internal static readonly string z0eej = "PropertyExpressions";

	internal static readonly string z0rej = "SignUserName";

	internal static readonly string z0tej = "ReferencedTopicID";

	internal static readonly string z0yej = "TopMargin";

	internal static readonly string z0uej = "OwnerID";

	internal static readonly string[] z0iej = new string[8] { "Default", "DataSource", "ToolTip", "ValidateMessage", "ID", "Name", "TabIndex", "Custom" };

	internal static readonly string z0oej = "LastModifiedTime";

	internal static readonly string z0pej = "Url";

	internal static readonly string z0mej = "Images";

	internal static readonly string z0nej = "MarginRight";

	internal static readonly string z0bej = "Rows";

	internal static readonly string z0vej = "PrintTextForChecked";

	internal static readonly string z0cej = "Deleteable";

	internal static readonly string z0xej = "FooterDistance";

	internal static readonly string z0zej = "ValuePrecision";

	internal static readonly string z0lrj = "Visibility";

	internal static readonly string z0krj = "SourceID";

	internal static readonly string z0jrj = "SubDocument";

	internal static readonly string z0hrj = "ImagePixelWidth";

	internal static readonly string z0grj = "SignProviderName";

	internal static readonly string z0frj = "PageSettings";

	internal static readonly string z0drj = "ShowHeaderBottomLine";

	internal static readonly string z0srj = "DataSource";

	internal static readonly string[] z0arj = new string[3] { "Near", "Center", "Far" };

	internal static readonly string z0qrj = "ShapeElement";

	internal static readonly string z0wrj = "HostMode";

	internal static readonly string z0erj = "BarcodeStyle2";

	internal static readonly string z0rrj = "ShadowName";

	internal static readonly string[] z0trj = new string[3] { "None", "Page", "Body" };

	internal static readonly string z0yrj = "YAxisCaptions";

	internal static readonly string z0urj = "ResetListIndexFlag";

	internal static readonly string z0irj = "SymbolStyle";

	internal static readonly string z0orj = "NormalRangeDownLineStyle";

	internal static readonly string z0prj = "TipText";

	internal static readonly string[] z0mrj_jiejie20260327142557 = new string[4] { "None", "AutoMaxValue", "AutoMinValue", "AutoMaxMinValue" };

	internal static readonly string z0nrj = "ShowBorder";

	internal static readonly string[] z0brj = new string[3] { "None", "AutoCompress", "AutoSize" };

	internal static readonly string z0vrj = "UserEditable";

	internal static readonly string z0crj = "BackgroundColor2";

	internal static readonly string z0xrj = "VerticalXLabel";

	internal static readonly string z0zrj = "CopySource";

	internal static readonly string z0ltj = "AutoFixFontSize";

	internal static readonly string z0ktj = "MedicalExpression";

	internal static readonly string z0jtj = "LineAlignment";

	internal static readonly string z0htj = "ScaleRate";

	internal static readonly string z0gtj = "VisibleExpression";

	internal static readonly string z0ftj = "BottomPadding";

	internal static readonly string z0dtj = "RedLineValue";

	internal static readonly string z0stj = "Level";

	internal static readonly string z0atj = "CustomImage";

	internal static readonly string z0qtj = "SpecifyDuplex";

	internal static readonly string z0wtj = "NewPage";

	internal static readonly string z0etj = "BorderWidth";

	internal static readonly string z0rtj = "TagValue";

	internal static readonly string z0ttj_jiejie20260327142557 = "Operator";

	internal static readonly string z0ytj = "PaperSource";

	internal static readonly string z0utj = "ListItemsSource";

	internal static readonly string z0itj = "PrintVisibility";

	internal static readonly string z0otj = "Alignment";

	internal static readonly string z0ptj = "VisibleInDirectory";

	internal static readonly string z0mtj = "ValueFieldName";

	internal static readonly string z0ntj = "Name";

	internal static readonly string z0btj = "LinkTarget";

	internal static readonly string z0vtj = "ClickToHide";

	internal static readonly string z0ctj = "GridLineOffsetY";

	internal static readonly string z0xtj = "FileName";

	internal static readonly string[] z0ztj = new string[3] { "NextElement", "Custom", "None" };

	internal static readonly string z0lyj = "Verified";

	internal static readonly string z0kyj = "EndTime";

	internal static readonly string z0jyj = "DisplayFormat";

	internal static readonly string z0hyj = "DetectRepeatImageForSave";

	internal static readonly string z0gyj = "IsCollapsed";

	internal static readonly string z0fyj = "Config";

	internal static readonly string z0dyj = "SignMessage";

	internal static readonly string z0syj = "FastInputMode";

	internal static readonly string z0ayj = "InitialAngle";

	internal static readonly string z0qyj = "PrintedPageIndex";

	internal static readonly string z0wyj = "Enabled";

	internal static readonly string z0eyj = "KBEntryRangeMask";

	internal static readonly string z0ryj = "TitleBackColor";

	internal static readonly string[] z0tyj = new string[2] { "InLabel", "OutLabel" };

	internal static readonly string z0yyj = "PrintBackgroundText";

	internal static readonly string z0uyj = "Columns";

	internal static readonly string z0iyj = "DataFieldNameForText";

	internal static readonly string z0oyj_jiejie20260327142557 = "TextBackColor";

	internal static readonly string z0pyj = "Y";

	internal static readonly string z0myj = "TemplateFileSystemName";

	internal static readonly string z0nyj = "BorderLeftColor";

	internal static readonly string z0byj = "PageIndexsForPrintBackgroundImage";

	internal static readonly string z0vyj = "TextAlign";

	internal static readonly string z0cyj = "DirectoryField";

	internal static readonly string z0xyj = "DocumentFormat";

	internal static readonly string z0zyj = "RepeatedImages";

	internal static readonly string z0luj = "SourcePropertyName";

	internal static readonly string z0kuj = "Description";

	internal static readonly string z0juj = "LineColor";

	internal static readonly string z0huj = "Required";

	internal static readonly string[] z0guj = new string[3] { "Default", "ContentWithClearField", "Complete" };

	internal static readonly string z0fuj = "Temp20200817";

	internal static readonly string z0duj = "DataFieldNameForValue";

	internal static readonly string z0suj = "DataFeedback";

	internal static readonly string z0auj = "ImportFooter";

	internal static readonly string z0quj = "PlayerUIMode";

	internal static readonly string z0wuj = "StartTime";

	internal static readonly string z0euj = "X";

	internal static readonly string z0ruj = "ImportUserTrack";

	internal static readonly string z0tuj = "ConnectionName";

	internal static readonly string z0yuj = "Expression";

	internal static readonly string z0uuj = "ForeColorForCollapsed";

	internal static readonly string z0iuj = "RulerValue";

	internal static readonly string z0ouj = "RowSpan";

	internal static readonly string z0puj = "TemperatureChart";

	internal static readonly string z0muj = "PageBorderBackground";

	internal static readonly string z0nuj = "SymbolColor";

	internal static readonly string z0buj = "AutoFitPageSize";

	internal static readonly string z0vuj = "DocumentInfo";

	internal static readonly string z0cuj = "ZoomInRate";

	internal static readonly string z0xuj = "SeperatorChar";

	internal static readonly string z0zuj = "DateFormatString";

	internal static readonly string z0lij = "SignImage";

	internal static readonly string z0kij = "AllowSave";

	internal static readonly string z0jij = "DataName";

	internal static readonly string z0hij = "DataFieldNameForLink";

	internal static readonly string z0gij = "NumOfColumns";

	internal static readonly string z0fij = "RipenessRate";

	internal static readonly string z0dij = "SpecifyWidth";

	internal static readonly string z0sij = "AutoUpdate";

	internal static readonly string z0aij = "FieldBorderElementWidth";

	internal static readonly string z0qij = "PageBackColor";

	internal static readonly string z0wij = "DateTimeMinValue";

	internal static readonly string z0eij = "TransparentColor";

	internal static readonly string z0rij = "PrintPositionInPage";

	internal static readonly string z0tij = "Element";

	internal static readonly string z0yij = "ShowText";

	internal static readonly string z0uij = "ImageData";

	internal static readonly string z0iij = "Locked";

	internal static readonly string z0oij = "EnableValueValidate";

	internal static readonly string z0pij = "PrintVisibilityWhenUnchecked";

	internal static readonly string z0mij = "WhitespaceCount";

	internal static readonly string z0nij = "SymbolOffsetY";

	internal static readonly string z0bij = "ShadowPointDetectSeconds";

	internal static readonly string z0vij = "GetValueOrderByTime";

	internal static readonly string z0cij = "DashStyle";

	internal static readonly string z0xij = "SourceColumn";

	internal static readonly string z0zij = "LableUnitTextBold";

	internal static readonly string z0loj = "StartDate";

	internal static readonly string z0koj = "ValueAlign";

	internal static readonly string z0joj = "UnderlineStyle";

	internal static readonly string z0hoj = "BackgroundText";

	internal static readonly string z0goj = "HoldWholeLine";

	internal static readonly string z0foj = "SavedTime";

	internal static readonly string z0doj = "EnableHighlight";

	internal static readonly string z0soj = "BindingPath";

	internal static readonly string z0aoj = "Link";

	internal static readonly string z0qoj = "CreatorIndex";

	internal static readonly string z0woj_jiejie20260327142557 = "AutoTickFormatString";

	internal static readonly string z0eoj = "X1";

	internal static readonly string z0roj = "GridLineStyleH";

	internal static readonly string z0toj = "MaxValue";

	internal static readonly string z0yoj = "BodyGridLineOffset";

	internal static readonly string z0uoj = "UseAdvVerticalStyle2";

	internal static readonly string z0ioj = "DefaultValue";

	internal static readonly string z0ooj = "TitleLevel";

	internal static readonly string z0poj = "LabelStyle";

	internal static readonly string z0moj = "Style";

	internal static readonly string[] z0noj = new string[3] { "Disable", "EnableOnlyForLastRow", "EnableInAllCases" };

	internal static readonly string z0boj = "PaperWidth";

	internal static readonly string z0voj = "BlankDateWhenNoData";

	internal static readonly string z0coj = "ID";

	internal static readonly string z0xoj = "AlertLineColor";

	internal static readonly string z0zoj = "Title";

	internal static readonly string z0lpj = "Image";

	internal static readonly string z0kpj = "Watermark";

	internal static readonly string z0jpj = "PageIndex";

	internal static readonly string z0hpj = "DataItem";

	internal static readonly string[] z0gpj = new string[3] { "Disable", "Static", "Dynamic" };

	internal static readonly string z0fpj = "AllowUserToResizeEvenInFormViewMode";

	internal static readonly string[] z0dpj_jiejie20260327142557 = new string[4] { "Default", "Left", "Center", "Right" };

	internal static readonly string z0spj = "PageTitlePosition";

	internal static readonly string z0apj = "XImagePartition";

	internal static readonly string z0qpj = "SpecifyPageIndexs";

	internal static readonly string z0wpj = "HeightInPrintJob";

	internal static readonly string z0epj = "CustomColorThemeH";

	internal static readonly string z0rpj = "PrintCellBackground";

	internal static readonly string z0tpj = "MinValue";

	internal static readonly string z0ypj = "ContentReadonlyExpression";

	internal static readonly string z0upj = "UseAdvVerticalStyle";

	internal static readonly string z0ipj = "BringoutToSave";

	internal static readonly string z0opj = "TextAlignment";

	internal static readonly string z0ppj = "EndDateKeyword";

	internal static readonly string z0mpj = "ValueTextTopPadding";

	internal static readonly string z0npj = "ColorForPointValue";

	internal static readonly string z0bpj = "ValueName";

	internal static readonly string z0vpj = "LeftIndent";

	internal static readonly string z0cpj = "PaddingRight";

	internal static readonly string z0xpj_jiejie20260327142557 = "DesignerPaperWidth";

	internal static readonly string z0zpj = "ContentLock";

	internal static readonly string z0lmj = "BarOpacity";

	internal static readonly string z0kmj = "ExtendDaysForTimeLine";

	internal static readonly string z0jmj = "VerticalTextAlign";

	internal static readonly string z0hmj = "BodyText";

	internal static readonly string z0gmj = "DataItems";

	internal static readonly string z0fmj = "InputTimePrecision";

	internal static readonly string z0dmj = "SliceRelativeDisplacement";

	internal static readonly string z0smj = "History";

	internal static readonly string[] z0amj = new string[1] { "QR" };

	internal static readonly string z0qmj = "PermissionLevel";

	internal static readonly string z0wmj = "BorderLeft";

	internal static readonly string z0emj = "CaptionFlowLayout";

	internal static readonly string z0rmj = "MergeIntoLeft";

	internal static readonly string z0tmj = "AutoSetFirstItems";

	internal static readonly string z0ymj = "RawPageIndex";

	internal static readonly string z0umj = "NormalRangeUpLineStyle";

	internal static readonly string z0imj = "DownleadLength";

	internal static readonly string z0omj = "ContactAction";

	internal static readonly string z0pmj = "Length";

	internal static readonly string[] z0mmj_jiejie20260327142557 = new string[4] { "Miter", "Bevel", "Round", "MiterClipped" };

	internal static readonly string z0nmj = "LineSpacing";

	internal static readonly string z0bmj = "ScriptMethodName";

	internal static readonly string[] z0vmj = new string[4] { "Default", "LeftToRight", "RightToLeft", "Invalidate" };

	internal static readonly string z0cmj = "ViewEncryptType";

	internal static readonly string z0xmj = "ContentStyle";

	internal static readonly string z0zmj = "Target";

	internal static readonly string z0lnj = "XFileBlock";

	internal static readonly string z0knj = "SpecifyTitleWidth";

	internal static readonly string z0jnj = "StrictUsePageSize";

	internal static readonly string z0hnj = "Resizeable";

	internal static readonly string z0gnj = "Align";

	internal static readonly string z0fnj = "SubfieldNumber";

	internal static readonly string z0dnj = "PartitionList";

	internal static readonly string z0snj = "TitleForToolTip";

	internal static readonly string z0anj = "Elements";

	internal static readonly string z0qnj = "LoopPlay";

	internal static readonly string z0wnj = "AutoClean";

	internal static readonly string z0enj = "RatioToPointFsList";

	internal static readonly string z0rnj = "ProviderName";

	internal static readonly string z0tnj = "SmoothZoom";

	internal static readonly string z0ynj = "Requried";

	internal static readonly string z0unj = "PrintAsText";

	internal static readonly string z0inj = "ContentLinkField";

	internal static readonly string z0onj = "MinHeightInCMUnit";

	internal static readonly string z0pnj = "HiddenOnPageViewWhenNoValuePoints";

	internal static readonly string z0mnj = "ContentReadonly";

	internal static readonly string z0nnj = "Width";

	internal static readonly string[] z0bnj = new string[6] { "Solid", "Dash", "Dot", "DashDot", "DashDotDot", "Custom" };

	internal static readonly string z0vnj = "CustomAdditionShapeContent";

	internal static readonly string z0cnj = "Ruler";

	internal static readonly string z0xnj = "Version";

	internal static readonly string[] z0znj = new string[3] { "True", "False", "Inherit" };

	internal static readonly string z0lbj = "BackgroundTextColor";

	internal static readonly string z0kbj_jiejie20260327142557 = "SpacingAfterParagraph";

	internal static readonly string z0jbj = "SymbolOffsetX";

	internal static readonly string z0hbj = "FirstLineIndent";

	internal static readonly string z0gbj = "DisplayPath";

	internal static readonly string z0fbj = "ShapeWireLabelElement";

	internal static readonly string z0dbj = "Values";

	internal static readonly string z0sbj = "ListValueFormatString";

	internal static readonly string z0abj = "ShowTooltip";

	internal static readonly string z0qbj = "ParentID";

	internal static readonly string z0wbj = "EnableRepeatedImage";

	internal static readonly string z0ebj = "PaperSizeName";

	internal static readonly string z0rbj = "GridLineStyle";

	internal static readonly string z0tbj = "Strikeout";

	internal static readonly string z0ybj = "HighlightOutofNormalRange";

	internal static readonly string z0ubj = "FooterForFirstPage";

	internal static readonly string z0ibj = "ShowBackColor";

	internal static readonly string z0obj = "PageBorderBackgroundStyle";

	internal static readonly string[] z0pbj = new string[3] { "Default", "Enabled", "Disabled" };

	internal static readonly string z0mbj = "ShapeLinesElement";

	internal static readonly string z0nbj = "HeaderLabelLineAlignment";

	internal static readonly string z0bbj = "IsCustomFill";

	internal static readonly string z0vbj = "GridYSpaceNum";

	internal static readonly string z0cbj = "KeyFieldValue";

	internal static readonly string z0xbj = "EndCap";

	internal static readonly string z0zbj = "AttributeNameForContactAction";

	internal static readonly string z0lvj = "ViewStyle";

	internal static readonly string z0kvj = "AllowUserResize";

	internal static readonly string z0jvj = "MaxSize";

	internal static readonly string z0hvj = "InnerRepeatImageIndex";

	internal static readonly string z0gvj = "ValueExpression";

	internal static readonly string z0fvj = "UseInnerSignProvider";

	internal static readonly string z0dvj = "NumOfRows";

	internal static readonly string z0svj = "EnableMediaContextMenu";

	internal static readonly string z0avj = "ThemeType";

	internal static readonly string[] z0qvj = new string[5] { "NoSpecify", "Default", "Horizontal", "Simplex", "Vertical" };

	internal static readonly string z0wvj = "CheckedValue";

	internal static readonly string z0evj = "EnableUserEditInnerValue";

	internal static readonly string z0rvj = "ShadeCount";

	internal static readonly string z0tvj = "BorderVisible";

	internal static readonly string z0yvj = "PrintGrid";

	internal static readonly string z0uvj = "Tag";

	internal static readonly string z0ivj = "AdditionShapeFixSize";

	internal static readonly string z0ovj = "EnableCollapse";

	internal static readonly string z0pvj = "LineSpacingStyle";

	internal static readonly string z0mvj = "KBEntries";

	internal static readonly string z0nvj = "CopyListItems";

	internal static readonly string z0bvj = "Cell";

	internal static readonly string[] z0vvj = new string[3] { "None", "Display", "ExtentToBottom" };

	internal static readonly string[] z0cvj = new string[31]
	{
		"UNSPECIFIED", "UPCA", "UPCE", "SUPP2", "SUPP5", "EAN13", "EAN8", "Interleaved2of5", "Standard2of5", "I2of5",
		"Code39", "Code39Extended", "Code93", "Codabar", "PostNet", "BOOKLAND", "ISBN", "JAN13", "MSI_Mod10", "MSI_2Mod10",
		"MSI_Mod11", "MSI_Mod11_Mod10", "Modified_Plessey", "CODE11", "USD8", "UCC12", "UCC13", "LOGMARS", "Code128A", "Code128B",
		"Code128C"
	};

	internal static readonly string z0xvj = "OwnerUserID";

	internal static readonly string z0zvj = "LabelText";

	internal static readonly string[] z0lcj = new string[6] { "SpaceSingle", "Space1pt5", "SpaceDouble", "SpaceExactly", "SpaceSpecify", "SpaceMultiple" };

	internal static readonly string z0kcj = "SmoothZoomIn";

	internal static readonly string z0jcj = "CommandText";

	internal static readonly string z0hcj = "FieldsForDesign";

	internal static readonly string z0gcj = "ErroeCorrectionLevel";

	internal static readonly string z0fcj = "TableName";

	internal static readonly string z0dcj = "ShowCellNoneBorder";

	internal static readonly string z0scj = "MaxValueForDayIndex";

	internal static readonly string z0acj = "LabelAtUp";

	internal static readonly string z0qcj = "EditorVersionString";

	internal static readonly string z0wcj = "Caption";

	internal static readonly string z0ecj = "ElementIDForExporting";

	internal static readonly string z0rcj = "Zones";

	internal static readonly string z0tcj = "MoveFocusHotKey";

	internal static readonly string z0ycj = "AllowUserToResizeRows";

	internal static readonly string z0ucj = "BarcodeStyle";

	internal static readonly string z0icj = "EllipseStyle";

	internal static readonly string z0ocj = "RadioBox";

	internal static readonly string z0pcj = "ChartPageIndex";

	internal static readonly string z0mcj = "EnableHeaderFooter";

	internal static readonly string z0ncj = "IsRoot";

	internal static string z0eek(DashStyle p0)
	{
		if (p0 >= DashStyle.Solid && p0 < (DashStyle)6)
		{
			return z0bnj[(int)p0];
		}
		return z0ZzZzqik.z0rek((int)p0);
	}

	internal static string z0eek(DCTBErroeCorrectionLevelType p0)
	{
		if (p0 >= DCTBErroeCorrectionLevelType.L && p0 < (DCTBErroeCorrectionLevelType)4)
		{
			return z0cok[(int)p0];
		}
		return z0ZzZzqik.z0rek((int)p0);
	}

	internal static string z0eek(TableRowCloneType p0)
	{
		if (p0 >= TableRowCloneType.Default && p0 < TableRowCloneType.ClearDirectContentAndFieldContent)
		{
			return z0guj[(int)p0];
		}
		return z0ZzZzqik.z0rek((int)p0);
	}

	internal static string z0eek(DCVisibleState p0)
	{
		if (p0 >= DCVisibleState.Visible && p0 < (DCVisibleState)4)
		{
			return z0ppk[(int)p0];
		}
		return z0ZzZzqik.z0rek((int)p0);
	}

	internal static string z0eek(MeasureMode p0)
	{
		if (p0 >= MeasureMode.Default && p0 < (MeasureMode)3)
		{
			return z0eok[(int)p0];
		}
		return z0ZzZzqik.z0rek((int)p0);
	}

	internal static string z0eek(z0ZzZzrxj p0)
	{
		if (p0 >= (z0ZzZzrxj)0 && p0 < (z0ZzZzrxj)7)
		{
			return z0yhj[(int)p0];
		}
		return z0ZzZzqik.z0rek((int)p0);
	}

	internal static string z0eek(DCCASignMode p0)
	{
		if (p0 >= DCCASignMode.Default && p0 < (DCCASignMode)3)
		{
			return z0ock[(int)p0];
		}
		return z0ZzZzqik.z0rek((int)p0);
	}

	internal static string z0eek(CheckBoxVisualStyle p0)
	{
		if (p0 >= CheckBoxVisualStyle.Default && p0 < (CheckBoxVisualStyle)6)
		{
			return z0tdj[(int)p0];
		}
		return z0ZzZzqik.z0rek((int)p0);
	}

	internal static string z0eek(LineSpacingStyle p0)
	{
		if (p0 >= LineSpacingStyle.SpaceSingle && p0 < (LineSpacingStyle)6)
		{
			return z0lcj[(int)p0];
		}
		return z0ZzZzqik.z0rek((int)p0);
	}

	internal static string z0eek(ElementVisibility p0)
	{
		if (p0 >= ElementVisibility.Visible && p0 < (ElementVisibility)3)
		{
			return z0vck[(int)p0];
		}
		return z0ZzZzqik.z0rek((int)p0);
	}

	internal static string z0eek(EnableState p0)
	{
		if (p0 >= EnableState.Default && p0 < (EnableState)3)
		{
			return z0pbj[(int)p0];
		}
		return z0ZzZzqik.z0rek((int)p0);
	}

	internal static string z0eek(DCBarcodeStyle p0)
	{
		if (p0 >= DCBarcodeStyle.UNSPECIFIED && p0 < (DCBarcodeStyle)31)
		{
			return z0kqj[(int)p0];
		}
		return z0ZzZzqik.z0rek((int)p0);
	}

	internal static string z0eek(z0ZzZzgzj p0)
	{
		if (p0 >= (z0ZzZzgzj)0 && p0 < (z0ZzZzgzj)3)
		{
			return z0gpj[(int)p0];
		}
		return z0ZzZzqik.z0rek((int)p0);
	}

	internal static string z0eek(ShapeTypes p0)
	{
		if (p0 >= ShapeTypes.Rectangle && p0 < (ShapeTypes)15)
		{
			return z0xkj[(int)p0];
		}
		return z0ZzZzqik.z0rek((int)p0);
	}

	internal static string z0eek(ContentViewEncryptType p0)
	{
		if (p0 >= ContentViewEncryptType.None && p0 < (ContentViewEncryptType)3)
		{
			return z0hpk[(int)p0];
		}
		return z0ZzZzqik.z0rek((int)p0);
	}

	internal static string z0eek(InputFieldEditStyle p0)
	{
		if (p0 >= InputFieldEditStyle.Text && p0 < (InputFieldEditStyle)7)
		{
			return z0bzk[(int)p0];
		}
		return z0ZzZzqik.z0rek((int)p0);
	}

	internal static string z0eek(ContentLayoutDirectionStyle p0)
	{
		if (p0 >= ContentLayoutDirectionStyle.Default && p0 < (ContentLayoutDirectionStyle)4)
		{
			return z0vmj[(int)p0];
		}
		return z0ZzZzqik.z0rek((int)p0);
	}

	internal static string z0eek(WindowsMediaPlayerUIMode p0)
	{
		if (p0 >= WindowsMediaPlayerUIMode.invisible && p0 < (WindowsMediaPlayerUIMode)4)
		{
			return z0ahj[(int)p0];
		}
		return z0ZzZzqik.z0rek((int)p0);
	}

	public static XTextDocument z0eek(z0ZzZzcah p0, XTextDocument p1)
	{
		if (p0 == null)
		{
			throw new NullReferenceException("NewSerializer20220801.Read_XTextDocument的参数reader为空");
		}
		if (p0 is z0ZzZzihh)
		{
			((z0ZzZzihh)p0).z0eek();
		}
		p0.z0da();
		if (p0.z0la() == (z0ZzZzbah)1)
		{
			try
			{
				if (p0.z0ma() == "XTextDocument")
				{
					XTextDocument xTextDocument = (XTextDocument)new z0ZzZzehh().z0aq(p0);
					if (xTextDocument == null)
					{
						throw new NullReferenceException("NewSerializer20220801.Read_XTextDocument的ser.Deserialize(reader)返回为空");
					}
					if (p1 == null)
					{
						p1 = xTextDocument;
					}
					else
					{
						p1.z0bek(xTextDocument, p1: true, p2: true);
						xTextDocument.Dispose();
					}
					z0ZzZzdhh.z0rek(p1);
					return p1;
				}
				z0eek(null, p0.z0ma());
			}
			finally
			{
				XTextElementList.z0qrk = false;
			}
		}
		return null;
	}

	internal static string z0eek(CharacterCircleStyles p0)
	{
		if (p0 >= CharacterCircleStyles.None && p0 < (CharacterCircleStyles)3)
		{
			return z0pvk[(int)p0];
		}
		return z0ZzZzqik.z0rek((int)p0);
	}

	internal static string z0eek(DCGutterStyle p0)
	{
		if (p0 >= DCGutterStyle.Left && p0 < (DCGutterStyle)3)
		{
			return z0bxk[(int)p0];
		}
		return z0ZzZzqik.z0rek((int)p0);
	}

	internal static string z0eek(DCProcessStates p0)
	{
		if (p0 >= DCProcessStates.Always && p0 < (DCProcessStates)3)
		{
			return z0kxk[(int)p0];
		}
		return z0ZzZzqik.z0rek((int)p0);
	}

	internal static string z0eek(ValueValidateLevel p0)
	{
		if (p0 >= ValueValidateLevel.Error && p0 < (ValueValidateLevel)3)
		{
			return z0ryk[(int)p0];
		}
		return z0ZzZzqik.z0rek((int)p0);
	}

	internal static string z0eek(StringAlignment p0)
	{
		if (p0 >= StringAlignment.Near && p0 < (StringAlignment)3)
		{
			return z0arj[(int)p0];
		}
		return z0ZzZzqik.z0rek((int)p0);
	}

	internal static string z0eek(DCTDBarcodeType p0)
	{
		if (p0 >= DCTDBarcodeType.QR && p0 < (DCTDBarcodeType)1)
		{
			return z0amj[(int)p0];
		}
		return z0ZzZzqik.z0rek((int)p0);
	}

	internal static string z0eek(RectangleSlantSplitStyle p0)
	{
		if (p0 >= RectangleSlantSplitStyle.None && p0 < (RectangleSlantSplitStyle)9)
		{
			return z0irk[(int)p0];
		}
		return z0ZzZzqik.z0rek((int)p0);
	}

	internal static string z0eek(DCFastInputMode p0)
	{
		if (p0 >= DCFastInputMode.None && p0 < (DCFastInputMode)6)
		{
			return z0ynk[(int)p0];
		}
		return z0ZzZzqik.z0rek((int)p0);
	}

	internal static string z0eek(ColorThemeType p0)
	{
		if (p0 >= ColorThemeType.Default && p0 < (ColorThemeType)11)
		{
			return z0kwj[(int)p0];
		}
		return z0ZzZzqik.z0rek((int)p0);
	}

	internal static string z0eek(GraphicsUnit p0)
	{
		if (p0 >= GraphicsUnit.World && p0 < (GraphicsUnit)7)
		{
			return z0bsj[(int)p0];
		}
		return z0ZzZzqik.z0rek((int)p0);
	}

	internal static string z0eek(DCMedicalExpressionStyle p0)
	{
		if (p0 >= DCMedicalExpressionStyle.FourValuesGeneral && p0 < DCMedicalExpressionStyle.AdvancedTeech)
		{
			return z0saj[(int)p0];
		}
		return z0ZzZzqik.z0rek((int)p0);
	}

	internal static string z0eek(ChartViewStyle p0)
	{
		if (p0 >= ChartViewStyle.Bar && p0 < (ChartViewStyle)18)
		{
			return z0vlj[(int)p0];
		}
		return z0ZzZzqik.z0rek((int)p0);
	}

	internal static string z0eek(DocumentContentAlignment p0)
	{
		if (p0 >= DocumentContentAlignment.Left && p0 < (DocumentContentAlignment)5)
		{
			return z0xfj[(int)p0];
		}
		return z0ZzZzqik.z0rek((int)p0);
	}

	internal static string z0eek(TableSubfieldMode p0)
	{
		if (p0 >= TableSubfieldMode.None && p0 < (TableSubfieldMode)3)
		{
			return z0fpk[(int)p0];
		}
		return z0ZzZzqik.z0rek((int)p0);
	}

	internal static string z0eek(AxisCompressStyle p0)
	{
		if (p0 >= AxisCompressStyle.None && p0 < (AxisCompressStyle)3)
		{
			return z0brj[(int)p0];
		}
		return z0ZzZzqik.z0rek((int)p0);
	}

	internal static string z0eek(z0ZzZzkdh p0)
	{
		if (p0 >= (z0ZzZzkdh)0 && p0 < (z0ZzZzkdh)4)
		{
			return z0mmj_jiejie20260327142557[(int)p0];
		}
		return z0ZzZzqik.z0rek((int)p0);
	}

	internal static string z0eek(PieLabelType p0)
	{
		if (p0 >= PieLabelType.InLabel && p0 < (PieLabelType)2)
		{
			return z0tyj[(int)p0];
		}
		return z0ZzZzqik.z0rek((int)p0);
	}

	internal static string z0eek(PrintVisibilityModeWhenUnchecked p0)
	{
		if (p0 >= PrintVisibilityModeWhenUnchecked.Visible && p0 < (PrintVisibilityModeWhenUnchecked)3)
		{
			return z0skj[(int)p0];
		}
		return z0ZzZzqik.z0rek((int)p0);
	}

	internal static string z0eek(PageBorderRangeTypes p0)
	{
		if (p0 >= PageBorderRangeTypes.None && p0 < (PageBorderRangeTypes)3)
		{
			return z0trj[(int)p0];
		}
		return z0ZzZzqik.z0rek((int)p0);
	}

	internal static string z0eek(ContentGridLineType p0)
	{
		if (p0 >= ContentGridLineType.None && p0 < (ContentGridLineType)3)
		{
			return z0vvj[(int)p0];
		}
		return z0ZzZzqik.z0rek((int)p0);
	}

	internal static string z0eek(CheckBoxControlStyle p0)
	{
		if (p0 >= CheckBoxControlStyle.CheckBox && p0 < (CheckBoxControlStyle)2)
		{
			return z0cbk[(int)p0];
		}
		return z0ZzZzqik.z0rek((int)p0);
	}

	internal static string z0eek(FormButtonStyle p0)
	{
		if (p0 >= FormButtonStyle.None && p0 < (FormButtonStyle)6)
		{
			return z0vik[(int)p0];
		}
		return z0ZzZzqik.z0rek((int)p0);
	}

	internal static string z0eek(TextUnderlineStyle p0)
	{
		if (p0 >= TextUnderlineStyle.None && p0 < (TextUnderlineStyle)11)
		{
			return z0lik[(int)p0];
		}
		return z0ZzZzqik.z0rek((int)p0);
	}

	internal static string z0eek(DCDuplexType p0)
	{
		if (p0 >= DCDuplexType.NoSpecify && p0 < (DCDuplexType)5)
		{
			return z0qvj[(int)p0];
		}
		return z0ZzZzqik.z0rek((int)p0);
	}

	internal static string z0eek(RangeCalculateStyle p0)
	{
		if (p0 >= RangeCalculateStyle.None && p0 < (RangeCalculateStyle)4)
		{
			return z0mrj_jiejie20260327142557[(int)p0];
		}
		return z0ZzZzqik.z0rek((int)p0);
	}

	internal static string z0eek(ContentAutoFixFontSizeMode p0)
	{
		if (p0 >= ContentAutoFixFontSizeMode.None && p0 < (ContentAutoFixFontSizeMode)3)
		{
			return z0nqj[(int)p0];
		}
		return z0ZzZzqik.z0rek((int)p0);
	}

	internal static string z0eek(ValueTypeStyle p0)
	{
		if (p0 >= ValueTypeStyle.Text && p0 < (ValueTypeStyle)7)
		{
			return z0lgj[(int)p0];
		}
		return z0ZzZzqik.z0rek((int)p0);
	}

	internal static string z0eek(ElementZOrderStyle p0)
	{
		if (p0 >= ElementZOrderStyle.Normal && p0 < (ElementZOrderStyle)3)
		{
			return z0zxk[(int)p0];
		}
		return z0ZzZzqik.z0rek((int)p0);
	}

	internal static string z0eek(WatermarkType p0)
	{
		if (p0 >= WatermarkType.None && p0 < (WatermarkType)3)
		{
			return z0pxk[(int)p0];
		}
		return z0ZzZzqik.z0rek((int)p0);
	}

	internal static string z0eek(z0ZzZzjvj p0)
	{
		if (p0 >= (z0ZzZzjvj)0 && p0 < (z0ZzZzjvj)8)
		{
			return z0iaj[(int)p0];
		}
		return z0ZzZzqik.z0rek((int)p0);
	}

	internal static string z0eek(DrawingStyle p0)
	{
		if (p0 >= DrawingStyle.Default && p0 < (DrawingStyle)3)
		{
			return z0fmk[(int)p0];
		}
		return z0ZzZzqik.z0rek((int)p0);
	}

	internal static string z0eek(z0ZzZzrrk p0)
	{
		if (p0 >= (z0ZzZzrrk)0 && p0 < (z0ZzZzrrk)31)
		{
			return z0cvj[(int)p0];
		}
		return z0ZzZzqik.z0rek((int)p0);
	}

	private static void z0eek(object p0, string p1)
	{
	}

	internal static string z0eek(z0ZzZzscj p0)
	{
		if (p0 >= (z0ZzZzscj)0 && p0 < (z0ZzZzscj)5)
		{
			return z0haj[(int)p0];
		}
		return z0ZzZzqik.z0rek((int)p0);
	}

	internal static string z0eek(ContentReadonlyState p0)
	{
		if (p0 >= ContentReadonlyState.True && p0 < (ContentReadonlyState)3)
		{
			return z0znj[(int)p0];
		}
		return z0ZzZzqik.z0rek((int)p0);
	}

	internal static string z0eek(DCSignRange p0)
	{
		if (p0 >= DCSignRange.None && p0 < (DCSignRange)9)
		{
			return z0cek[(int)p0];
		}
		return z0ZzZzqik.z0rek((int)p0);
	}

	internal static string z0eek(ContentLayoutAlign p0)
	{
		if (p0 >= ContentLayoutAlign.EmbedInText && p0 < (ContentLayoutAlign)2)
		{
			return z0stk[(int)p0];
		}
		return z0ZzZzqik.z0rek((int)p0);
	}

	internal static string z0eek(ChartStyleConsts p0)
	{
		if (p0 >= ChartStyleConsts.Default && p0 < (ChartStyleConsts)4)
		{
			return z0fkj[(int)p0];
		}
		return z0ZzZzqik.z0rek((int)p0);
	}

	internal static string z0eek(z0ZzZzikh p0)
	{
		if (p0 >= (z0ZzZzikh)0 && p0 < (z0ZzZzikh)3)
		{
			return z0ztj[(int)p0];
		}
		return z0ZzZzqik.z0rek((int)p0);
	}

	internal static string z0eek(VerticalAlignStyle p0)
	{
		if (p0 >= VerticalAlignStyle.Top && p0 < (VerticalAlignStyle)3)
		{
			return z0jnk[(int)p0];
		}
		return z0ZzZzqik.z0rek((int)p0);
	}

	internal static string z0eek(ContentProtectType p0)
	{
		if (p0 >= ContentProtectType.None && p0 < (ContentProtectType)3)
		{
			return z0lnk[(int)p0];
		}
		return z0ZzZzqik.z0rek((int)p0);
	}

	internal static string z0eek(DCTableAlignment p0)
	{
		if (p0 >= DCTableAlignment.Default && p0 < (DCTableAlignment)4)
		{
			return z0dpj_jiejie20260327142557[(int)p0];
		}
		return z0ZzZzqik.z0rek((int)p0);
	}

	internal static string z0eek(DCBooleanValueHasDefault p0)
	{
		if (p0 >= DCBooleanValueHasDefault.True && p0 < (DCBooleanValueHasDefault)3)
		{
			return z0ndj[(int)p0];
		}
		return z0ZzZzqik.z0rek((int)p0);
	}

	internal static string z0eek(DCInsertRowDownUseHotKeys p0)
	{
		if (p0 >= DCInsertRowDownUseHotKeys.Disable && p0 < (DCInsertRowDownUseHotKeys)3)
		{
			return z0noj[(int)p0];
		}
		return z0ZzZzqik.z0rek((int)p0);
	}

	internal static string z0eek(DCBooleanValue p0)
	{
		if (p0 >= DCBooleanValue.True && p0 < (DCBooleanValue)3)
		{
			return z0wmk[(int)p0];
		}
		return z0ZzZzqik.z0rek((int)p0);
	}

	internal static string z0eek(z0ZzZzgdh p0)
	{
		if (p0 >= (z0ZzZzgdh)0 && p0 < (z0ZzZzgdh)5)
		{
			return z0maj[(int)p0];
		}
		return z0ZzZzqik.z0rek((int)p0);
	}

	internal static string z0eek(LabelTextContactActionMode p0)
	{
		if (p0 >= LabelTextContactActionMode.Disable && p0 < (LabelTextContactActionMode)7)
		{
			return z0sej[(int)p0];
		}
		return z0ZzZzqik.z0rek((int)p0);
	}

	internal static string z0eek(ResizeableType p0)
	{
		if (p0 >= ResizeableType.FixSize && p0 < (ResizeableType)4)
		{
			return z0sqj[(int)p0];
		}
		return z0ZzZzqik.z0rek((int)p0);
	}

	internal static string z0eek(PageInfoValueType p0)
	{
		if (p0 >= PageInfoValueType.PageIndex && p0 < (PageInfoValueType)4)
		{
			return z0tok[(int)p0];
		}
		return z0ZzZzqik.z0rek((int)p0);
	}

	internal static string z0eek(ValueFormatStyle p0)
	{
		if (p0 >= ValueFormatStyle.None && p0 < (ValueFormatStyle)8)
		{
			return z0nzk[(int)p0];
		}
		return z0ZzZzqik.z0rek((int)p0);
	}

	internal static string z0eek(InputFieldAdornTextType p0)
	{
		if (p0 >= InputFieldAdornTextType.Default && p0 < (InputFieldAdornTextType)8)
		{
			return z0iej[(int)p0];
		}
		return z0ZzZzqik.z0rek((int)p0);
	}
}
