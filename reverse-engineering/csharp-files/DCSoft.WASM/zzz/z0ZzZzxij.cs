using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using DCSoft.Common;
using DCSoft.Data;
using DCSoft.Drawing;
using DCSoft.Writer;
using DCSoft.Writer.Controls;
using DCSoft.Writer.Dom;
using DCSoft.Writer.Security;
using DCSystem_Drawing;
using DCSystem_Drawing.Drawing2D;

namespace zzz;

internal static class z0ZzZzxij
{
	public sealed class z0znk : JsonConverter<AppErrorHandleModeConsts>
	{
		public override bool CanConvert(Type typeToConvert)
		{
			return typeToConvert == typeof(AppErrorHandleModeConsts);
		}

		public override AppErrorHandleModeConsts Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			return z0eek(ref reader, AppErrorHandleModeConsts.None);
		}

		public override void Write(Utf8JsonWriter writer, AppErrorHandleModeConsts Value, JsonSerializerOptions options)
		{
			z0eek(writer, Value);
		}
	}

	public sealed class z0lbk : JsonConverter<ContentLayoutDirectionStyle>
	{
		public override void Write(Utf8JsonWriter writer, ContentLayoutDirectionStyle Value, JsonSerializerOptions options)
		{
			z0eek(writer, Value);
		}

		public override ContentLayoutDirectionStyle Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			return z0eek(ref reader, ContentLayoutDirectionStyle.Default);
		}

		public override bool CanConvert(Type typeToConvert)
		{
			return typeToConvert == typeof(ContentLayoutDirectionStyle);
		}
	}

	public sealed class z0kbk : JsonConverter<DashStyle>
	{
		public override void Write(Utf8JsonWriter writer, DashStyle Value, JsonSerializerOptions options)
		{
			z0eek(writer, Value);
		}

		public override bool CanConvert(Type typeToConvert)
		{
			return typeToConvert == typeof(DashStyle);
		}

		public override DashStyle Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			return z0eek(ref reader, DashStyle.Solid);
		}
	}

	public sealed class z0jbk : JsonConverter<DCAdornTextVisibility>
	{
		public override DCAdornTextVisibility Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			return z0eek(ref reader, DCAdornTextVisibility.Hidden);
		}

		public override void Write(Utf8JsonWriter writer, DCAdornTextVisibility Value, JsonSerializerOptions options)
		{
			z0eek(writer, Value);
		}

		public override bool CanConvert(Type typeToConvert)
		{
			return typeToConvert == typeof(DCAdornTextVisibility);
		}
	}

	public sealed class z0hbk : JsonConverter<DCCAMode>
	{
		public override DCCAMode Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			return z0eek(ref reader, DCCAMode.Disabled);
		}

		public override void Write(Utf8JsonWriter writer, DCCAMode Value, JsonSerializerOptions options)
		{
			z0eek(writer, Value);
		}

		public override bool CanConvert(Type typeToConvert)
		{
			return typeToConvert == typeof(DCCAMode);
		}
	}

	public sealed class z0gbk : JsonConverter<DCDocumentTextOutputMode>
	{
		public override bool CanConvert(Type typeToConvert)
		{
			return typeToConvert == typeof(DCDocumentTextOutputMode);
		}

		public override DCDocumentTextOutputMode Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			return z0eek(ref reader, DCDocumentTextOutputMode.Normal);
		}

		public override void Write(Utf8JsonWriter writer, DCDocumentTextOutputMode Value, JsonSerializerOptions options)
		{
			z0eek(writer, Value);
		}
	}

	public sealed class z0fbk : JsonConverter<DCImageCompressSaveMode>
	{
		public override DCImageCompressSaveMode Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			return z0eek(ref reader, DCImageCompressSaveMode.True);
		}

		public override void Write(Utf8JsonWriter writer, DCImageCompressSaveMode Value, JsonSerializerOptions options)
		{
			z0eek(writer, Value);
		}

		public override bool CanConvert(Type typeToConvert)
		{
			return typeToConvert == typeof(DCImageCompressSaveMode);
		}
	}

	public sealed class z0dbk : JsonConverter<DCRenderVisibility>
	{
		public override DCRenderVisibility Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			return z0eek(ref reader, DCRenderVisibility.Default);
		}

		public override void Write(Utf8JsonWriter writer, DCRenderVisibility Value, JsonSerializerOptions options)
		{
			z0eek(writer, Value);
		}

		public override bool CanConvert(Type typeToConvert)
		{
			return typeToConvert == typeof(DCRenderVisibility);
		}
	}

	public sealed class z0sbk : JsonConverter<DCValidateIDRepeatMode>
	{
		public override void Write(Utf8JsonWriter writer, DCValidateIDRepeatMode Value, JsonSerializerOptions options)
		{
			z0eek(writer, Value);
		}

		public override bool CanConvert(Type typeToConvert)
		{
			return typeToConvert == typeof(DCValidateIDRepeatMode);
		}

		public override DCValidateIDRepeatMode Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			return z0eek(ref reader, DCValidateIDRepeatMode.None);
		}
	}

	public sealed class z0abk : JsonConverter<DCWordBreakStyle>
	{
		public override void Write(Utf8JsonWriter writer, DCWordBreakStyle Value, JsonSerializerOptions options)
		{
			z0eek(writer, Value);
		}

		public override DCWordBreakStyle Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			return z0eek(ref reader, DCWordBreakStyle.Normal);
		}

		public override bool CanConvert(Type typeToConvert)
		{
			return typeToConvert == typeof(DCWordBreakStyle);
		}
	}

	public sealed class z0qbk : JsonConverter<DocumentBehaviorOptions>
	{
		public override bool CanConvert(Type typeToConvert)
		{
			return typeToConvert == typeof(DocumentBehaviorOptions);
		}

		public override DocumentBehaviorOptions Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			return z0eek(ref reader, new DocumentBehaviorOptions());
		}

		public override void Write(Utf8JsonWriter writer, DocumentBehaviorOptions value, JsonSerializerOptions options)
		{
			z0eek(writer, value);
		}
	}

	public sealed class z0wbk : JsonConverter<DocumentEditOptions>
	{
		public override bool CanConvert(Type typeToConvert)
		{
			return typeToConvert == typeof(DocumentEditOptions);
		}

		public override void Write(Utf8JsonWriter writer, DocumentEditOptions value, JsonSerializerOptions options)
		{
			z0eek(writer, value);
		}

		public override DocumentEditOptions Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			return z0eek(ref reader, new DocumentEditOptions());
		}
	}

	public sealed class z0ebk : JsonConverter<DocumentOptions>
	{
		public override bool CanConvert(Type typeToConvert)
		{
			return typeToConvert == typeof(DocumentOptions);
		}

		public override void Write(Utf8JsonWriter writer, DocumentOptions value, JsonSerializerOptions options)
		{
			z0eek(writer, value);
		}

		public override DocumentOptions Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			return z0eek(ref reader, new DocumentOptions());
		}
	}

	public sealed class z0rbk : JsonConverter<DocumentSecurityOptions>
	{
		public override void Write(Utf8JsonWriter writer, DocumentSecurityOptions value, JsonSerializerOptions options)
		{
			z0eek(writer, value);
		}

		public override DocumentSecurityOptions Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			return z0eek(ref reader, new DocumentSecurityOptions());
		}

		public override bool CanConvert(Type typeToConvert)
		{
			return typeToConvert == typeof(DocumentSecurityOptions);
		}
	}

	public sealed class z0tbk : JsonConverter<DocumentValueValidateMode>
	{
		public override void Write(Utf8JsonWriter writer, DocumentValueValidateMode Value, JsonSerializerOptions options)
		{
			z0eek(writer, Value);
		}

		public override bool CanConvert(Type typeToConvert)
		{
			return typeToConvert == typeof(DocumentValueValidateMode);
		}

		public override DocumentValueValidateMode Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			return z0eek(ref reader, DocumentValueValidateMode.None);
		}
	}

	public sealed class z0ybk : JsonConverter<DocumentViewOptions>
	{
		public override bool CanConvert(Type typeToConvert)
		{
			return typeToConvert == typeof(DocumentViewOptions);
		}

		public override void Write(Utf8JsonWriter writer, DocumentViewOptions value, JsonSerializerOptions options)
		{
			z0eek(writer, value);
		}

		public override DocumentViewOptions Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			return z0eek(ref reader, new DocumentViewOptions());
		}
	}

	public sealed class z0ubk : JsonConverter<EnableState>
	{
		public override void Write(Utf8JsonWriter writer, EnableState Value, JsonSerializerOptions options)
		{
			z0eek(writer, Value);
		}

		public override bool CanConvert(Type typeToConvert)
		{
			return typeToConvert == typeof(EnableState);
		}

		public override EnableState Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			return z0eek(ref reader, EnableState.Default);
		}
	}

	public sealed class z0ibk : JsonConverter<FormViewMode>
	{
		public override void Write(Utf8JsonWriter writer, FormViewMode Value, JsonSerializerOptions options)
		{
			z0eek(writer, Value);
		}

		public override FormViewMode Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			return z0eek(ref reader, FormViewMode.Disable);
		}

		public override bool CanConvert(Type typeToConvert)
		{
			return typeToConvert == typeof(FormViewMode);
		}
	}

	public sealed class z0obk : JsonConverter<FunctionControlVisibility>
	{
		public override bool CanConvert(Type typeToConvert)
		{
			return typeToConvert == typeof(FunctionControlVisibility);
		}

		public override FunctionControlVisibility Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			return z0eek(ref reader, FunctionControlVisibility.Auto);
		}

		public override void Write(Utf8JsonWriter writer, FunctionControlVisibility Value, JsonSerializerOptions options)
		{
			z0eek(writer, Value);
		}
	}

	public sealed class z0pbk : JsonConverter<GraphicsUnit>
	{
		public override GraphicsUnit Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			return z0eek(ref reader, GraphicsUnit.World);
		}

		public override bool CanConvert(Type typeToConvert)
		{
			return typeToConvert == typeof(GraphicsUnit);
		}

		public override void Write(Utf8JsonWriter writer, GraphicsUnit Value, JsonSerializerOptions options)
		{
			z0eek(writer, Value);
		}
	}

	public sealed class z0mbk : JsonConverter<InputFieldAdornTextType>
	{
		public override void Write(Utf8JsonWriter writer, InputFieldAdornTextType Value, JsonSerializerOptions options)
		{
			z0eek(writer, Value);
		}

		public override InputFieldAdornTextType Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			return z0eek(ref reader, InputFieldAdornTextType.Default);
		}

		public override bool CanConvert(Type typeToConvert)
		{
			return typeToConvert == typeof(InputFieldAdornTextType);
		}
	}

	public sealed class z0nbk : JsonConverter<InsertDocumentWithCheckMRIDType>
	{
		public override bool CanConvert(Type typeToConvert)
		{
			return typeToConvert == typeof(InsertDocumentWithCheckMRIDType);
		}

		public override void Write(Utf8JsonWriter writer, InsertDocumentWithCheckMRIDType Value, JsonSerializerOptions options)
		{
			z0eek(writer, Value);
		}

		public override InsertDocumentWithCheckMRIDType Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			return z0eek(ref reader, InsertDocumentWithCheckMRIDType.None);
		}
	}

	public sealed class z0bbk : JsonConverter<InterpolationMode>
	{
		public override bool CanConvert(Type typeToConvert)
		{
			return typeToConvert == typeof(InterpolationMode);
		}

		public override InterpolationMode Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			return z0eek(ref reader, InterpolationMode.Default);
		}

		public override void Write(Utf8JsonWriter writer, InterpolationMode Value, JsonSerializerOptions options)
		{
			z0eek(writer, Value);
		}
	}

	public sealed class z0vbk : JsonConverter<MoveFocusHotKeys>
	{
		public override MoveFocusHotKeys Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			return z0eek(ref reader, MoveFocusHotKeys.None);
		}

		public override void Write(Utf8JsonWriter writer, MoveFocusHotKeys Value, JsonSerializerOptions options)
		{
			z0eek(writer, Value);
		}

		public override bool CanConvert(Type typeToConvert)
		{
			return typeToConvert == typeof(MoveFocusHotKeys);
		}
	}

	public sealed class z0cbk : JsonConverter<PromptProtectedContentMode>
	{
		public override PromptProtectedContentMode Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			return z0eek(ref reader, PromptProtectedContentMode.None);
		}

		public override void Write(Utf8JsonWriter writer, PromptProtectedContentMode Value, JsonSerializerOptions options)
		{
			z0eek(writer, Value);
		}

		public override bool CanConvert(Type typeToConvert)
		{
			return typeToConvert == typeof(PromptProtectedContentMode);
		}
	}

	public sealed class z0xbk : JsonConverter<RenderVisibility>
	{
		public override RenderVisibility Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			return z0eek(ref reader, RenderVisibility.Hidden);
		}

		public override void Write(Utf8JsonWriter writer, RenderVisibility Value, JsonSerializerOptions options)
		{
			z0eek(writer, Value);
		}

		public override bool CanConvert(Type typeToConvert)
		{
			return typeToConvert == typeof(RenderVisibility);
		}
	}

	public sealed class z0zbk : JsonConverter<SmoothingMode>
	{
		public override SmoothingMode Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			return z0eek(ref reader, SmoothingMode.Invalid);
		}

		public override bool CanConvert(Type typeToConvert)
		{
			return typeToConvert == typeof(SmoothingMode);
		}

		public override void Write(Utf8JsonWriter writer, SmoothingMode Value, JsonSerializerOptions options)
		{
			z0eek(writer, Value);
		}
	}

	public sealed class z0lvk : JsonConverter<z0ZzZzfsh>
	{
		public override bool CanConvert(Type typeToConvert)
		{
			return typeToConvert == typeof(z0ZzZzfsh);
		}

		public override void Write(Utf8JsonWriter writer, z0ZzZzfsh Value, JsonSerializerOptions options)
		{
			z0eek(writer, Value);
		}

		public override z0ZzZzfsh Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			return z0eek(ref reader, (z0ZzZzfsh)0);
		}
	}

	public sealed class z0kvk : JsonConverter<TextUnderlineStyle>
	{
		public override bool CanConvert(Type typeToConvert)
		{
			return typeToConvert == typeof(TextUnderlineStyle);
		}

		public override TextUnderlineStyle Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			return z0eek(ref reader, TextUnderlineStyle.None);
		}

		public override void Write(Utf8JsonWriter writer, TextUnderlineStyle Value, JsonSerializerOptions options)
		{
			z0eek(writer, Value);
		}
	}

	public sealed class z0jvk : JsonConverter<z0ZzZzigh>
	{
		public override void Write(Utf8JsonWriter writer, z0ZzZzigh value, JsonSerializerOptions options)
		{
			z0eek(writer, value);
		}

		public override bool CanConvert(Type typeToConvert)
		{
			return typeToConvert == typeof(z0ZzZzigh);
		}

		public override z0ZzZzigh Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			return z0eek(ref reader, new z0ZzZzigh());
		}
	}

	public sealed class z0hvk : JsonConverter<ValueEditorActiveMode>
	{
		public override bool CanConvert(Type typeToConvert)
		{
			return typeToConvert == typeof(ValueEditorActiveMode);
		}

		public override ValueEditorActiveMode Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			return z0eek(ref reader, ValueEditorActiveMode.None);
		}

		public override void Write(Utf8JsonWriter writer, ValueEditorActiveMode Value, JsonSerializerOptions options)
		{
			z0eek(writer, Value);
		}
	}

	public sealed class z0gvk : JsonConverter<z0ZzZzsok>
	{
		public override bool CanConvert(Type typeToConvert)
		{
			return typeToConvert == typeof(z0ZzZzsok);
		}

		public override z0ZzZzsok Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			return z0eek(ref reader, new z0ZzZzsok());
		}

		public override void Write(Utf8JsonWriter writer, z0ZzZzsok value, JsonSerializerOptions options)
		{
			z0eek(writer, value);
		}
	}

	public sealed class z0fvk : JsonConverter<ValueFormatStyle>
	{
		public override ValueFormatStyle Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			return z0eek(ref reader, ValueFormatStyle.None);
		}

		public override void Write(Utf8JsonWriter writer, ValueFormatStyle Value, JsonSerializerOptions options)
		{
			z0eek(writer, Value);
		}

		public override bool CanConvert(Type typeToConvert)
		{
			return typeToConvert == typeof(ValueFormatStyle);
		}
	}

	public sealed class z0dvk : JsonConverter<ValueTypeStyle>
	{
		public override ValueTypeStyle Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			return z0eek(ref reader, ValueTypeStyle.Text);
		}

		public override bool CanConvert(Type typeToConvert)
		{
			return typeToConvert == typeof(ValueTypeStyle);
		}

		public override void Write(Utf8JsonWriter writer, ValueTypeStyle Value, JsonSerializerOptions options)
		{
			z0eek(writer, Value);
		}
	}

	public sealed class z0svk : JsonConverter<ValueValidateLevel>
	{
		public override void Write(Utf8JsonWriter writer, ValueValidateLevel Value, JsonSerializerOptions options)
		{
			z0eek(writer, Value);
		}

		public override ValueValidateLevel Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			return z0eek(ref reader, ValueValidateLevel.Error);
		}

		public override bool CanConvert(Type typeToConvert)
		{
			return typeToConvert == typeof(ValueValidateLevel);
		}
	}

	public sealed class z0avk : JsonConverter<ValueValidateStyle>
	{
		public override bool CanConvert(Type typeToConvert)
		{
			return typeToConvert == typeof(ValueValidateStyle);
		}

		public override ValueValidateStyle Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			return z0eek(ref reader, new ValueValidateStyle());
		}

		public override void Write(Utf8JsonWriter writer, ValueValidateStyle value, JsonSerializerOptions options)
		{
			z0eek(writer, value);
		}
	}

	public sealed class z0qvk_jiejie20260327142557 : JsonConverter<z0ZzZzwmk>
	{
		public override z0ZzZzwmk Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			return z0eek(ref reader, new z0ZzZzwmk());
		}

		public override void Write(Utf8JsonWriter writer, z0ZzZzwmk value, JsonSerializerOptions options)
		{
			z0eek(writer, value);
		}

		public override bool CanConvert(Type typeToConvert)
		{
			return typeToConvert == typeof(z0ZzZzwmk);
		}
	}

	public sealed class z0wvk : JsonConverter<WatermarkType>
	{
		public override WatermarkType Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			return z0eek(ref reader, WatermarkType.None);
		}

		public override bool CanConvert(Type typeToConvert)
		{
			return typeToConvert == typeof(WatermarkType);
		}

		public override void Write(Utf8JsonWriter writer, WatermarkType Value, JsonSerializerOptions options)
		{
			z0eek(writer, Value);
		}
	}

	public sealed class z0evk : JsonConverter<WriterDataFormats>
	{
		public override void Write(Utf8JsonWriter writer, WriterDataFormats Value, JsonSerializerOptions options)
		{
			z0eek(writer, Value);
		}

		public override WriterDataFormats Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			return z0eek(ref reader, WriterDataFormats.None);
		}

		public override bool CanConvert(Type typeToConvert)
		{
			return typeToConvert == typeof(WriterDataFormats);
		}
	}

	public sealed class z0rvk : JsonConverter<WriterDataObjectRange>
	{
		public override void Write(Utf8JsonWriter writer, WriterDataObjectRange Value, JsonSerializerOptions options)
		{
			z0eek(writer, Value);
		}

		public override bool CanConvert(Type typeToConvert)
		{
			return typeToConvert == typeof(WriterDataObjectRange);
		}

		public override WriterDataObjectRange Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			return z0eek(ref reader, WriterDataObjectRange.OS);
		}
	}

	public sealed class z0tvk : JsonConverter<z0ZzZzimk>
	{
		public override bool CanConvert(Type typeToConvert)
		{
			return typeToConvert == typeof(z0ZzZzimk);
		}

		public override z0ZzZzimk Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			return z0eek(ref reader, new z0ZzZzimk());
		}

		public override void Write(Utf8JsonWriter writer, z0ZzZzimk value, JsonSerializerOptions options)
		{
			z0eek(writer, value);
		}
	}

	public sealed class z0yvk : JsonConverter<z0ZzZzpmk>
	{
		public override bool CanConvert(Type typeToConvert)
		{
			return typeToConvert == typeof(z0ZzZzpmk);
		}

		public override void Write(Utf8JsonWriter writer, z0ZzZzpmk value, JsonSerializerOptions options)
		{
			z0eek(writer, value);
		}

		public override z0ZzZzpmk Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			return z0eek(ref reader, new z0ZzZzpmk());
		}
	}

	private static readonly string z0rek = "IgnoreDataBindingWhenMissValue";

	private static readonly string z0tek = "BackgroundTextColor";

	private static readonly string z0yek = "PromptForRejectFormat";

	private static readonly string z0uek = "CheckMaxValue";

	private static readonly string z0iek = "AutoAssistInsertString";

	private static readonly string z0oek = "ForceCollateWhenPrint";

	private static readonly string z0pek = "FixSizeWhenInsertImage";

	private static readonly string z0mek = "FormView";

	private static readonly string z0nek = "HighlightProtectedContent";

	private static readonly string z0bek = "Underline";

	private static readonly string z0vek = "TextRenderStyle";

	private static readonly string z0cek = "ShowFieldBorderElement";

	private static readonly string z0xek = "TagColorForReadonlyField";

	private static readonly string z0zek = "FieldHoverBackColor";

	private static readonly string z0lrk = "ParseCrLfAsLineBreakElement";

	private static readonly string z0krk = "ClearFieldValueWhenCopy";

	private static readonly string z0jrk = "PreserveClipbardDataWhenExit";

	private static readonly string[] z0hrk = new string[4] { "None", "Simple", "Details", "Flash" };

	private static readonly string z0grk = "ForceRaiseEventAfterFieldContentEdit";

	private static readonly string z0frk = "EnableScript";

	private static readonly string z0drk = "DefaultEditorActiveMode";

	private static readonly string z0srk = "EnableExpression";

	private static readonly string z0ark = "AllowDeleteJumpOutOfField";

	private static readonly string z0qrk = "CAServerIP";

	private static readonly string z0wrk = "CreatorTipFormatString";

	private static readonly string z0erk = "PowerfulCommentCommand";

	private static readonly string z0rrk = "DefaultAdornTextType";

	private static readonly string z0trk = "EnableLogicDelete";

	private static readonly string z0yrk = "Type";

	private static readonly string z0urk = "TrackVisibleLevel0";

	private static readonly string z0irk = "PrintGridLine";

	private static readonly string[] z0ork_jiejie20260327142557 = new string[3] { "OS", "Application", "SingleWriterControl" };

	private static readonly string z0prk = "CommentFontName";

	private static readonly string[] z0mrk = new string[6] { "SystemDefault", "SingleBitPerPixelGridFit", "SingleBitPerPixel", "AntiAliasGridFit", "AntiAlias", "ClearTypeGridFit" };

	private static readonly string z0nrk = "DeleteLineColor";

	private static readonly string[] z0brk = new string[4] { "None", "DetectOnly", "AutoFix", "ThrowException" };

	private static readonly string[] z0vrk = new string[8] { "None", "Numeric", "Currency", "DateTime", "String", "SpecifyLength", "Boolean", "Percent" };

	private static readonly string z0crk = "AutoClearInvalidateCharacter";

	private static readonly string z0xrk = "ShowInputFieldStateTag";

	private static readonly string[] z0zrk = new string[6] { "Solid", "Dash", "Dot", "DashDot", "DashDotDot", "Custom" };

	private static readonly string z0ltk = "PromptForExcludeSystemClipboardRange";

	private static readonly string z0ktk = "EnableEditElementValue";

	private static readonly string z0jtk = "MoveFocusHotKey";

	private static readonly string z0htk = "ShowPageBreak";

	private static readonly string z0gtk = "DisplayFormatToInnerValue";

	private static readonly string z0ftk = "CloneWithoutLogicDeletedContent";

	private static readonly string[] z0dtk = new string[3] { "Error", "Warring", "Info" };

	private static readonly string z0stk = "UnderLineColor";

	private static readonly string z0atk = "DocumentTextOutputMode";

	private static readonly string z0qtk = "AutoScrollToCaretWhenGotFocus";

	private static readonly string[] z0wtk = new string[7] { "Text", "Integer", "Numeric", "Date", "Time", "DateTime", "RegExpress" };

	private static readonly string z0etk = "CopyInTextFormatOnly";

	private static readonly string z0rtk = "ImageInterpolationMode";

	private static readonly string z0ttk = "DateTimeMinValue";

	private static readonly string z0ytk = "FieldFocusedBackColor";

	private static readonly string z0utk = "MaxZoomRate";

	private static readonly string z0itk = "AutoAssistInsertStringDetectTextLength";

	private static readonly string z0otk = "SectionBorderVisibility";

	private static readonly string z0ptk = "MaskColorForJumpPrint";

	private static readonly string[] z0mtk = new string[5] { "None", "ThrowException", "Ignore", "ShowMessge", "ShowDetailMessage" };

	private static readonly string z0ntk = "MinValue";

	private static readonly string z0btk = "EnablePermission";

	private static readonly string z0vtk = "AutoDocumentValueValidate";

	private static readonly string z0ctk = "ShowPageLine";

	private static readonly string z0xtk = "EnableCheckControlLoaded";

	private static readonly string z0ztk = "HeaderBottomLineWidth";

	private static readonly string z0lyk = "TagColorForNormalField";

	private static readonly string z0kyk = "DensityForRepeat";

	private static readonly string z0jyk = "AdornTextVisibility";

	private static readonly string z0hyk = "ShowFieldBorderTextInTheMiddle";

	private static readonly string z0gyk = "EnableCompressUserHistories";

	private static readonly string z0fyk = "PromptProtectedContent";

	private static readonly string z0dyk = "CommentDateFormatString";

	private static readonly string z0syk = "ResetTextFormatWhenCreateNewLine";

	private static readonly string[] z0ayk = new string[3] { "Hidden", "Actived", "Both" };

	private static readonly string z0qyk = "Level";

	private static readonly string z0wyk = "EnableLogUndo";

	private static readonly string z0eyk = "TagColorForValueInvalidateField";

	private static readonly string z0ryk = "ShowRedErrorMessageForPaint";

	private static readonly string z0tyk = "ReadonlyFieldBorderColor";

	private static readonly string z0yyk = "PowerfulSignDocument";

	private static readonly string z0uyk = "ShowGlobalGridLineInTableAndSection";

	private static readonly string z0iyk = "SupportUG";

	private static readonly string z0oyk = "OutputFormatedXMLSource";

	private static readonly string z0pyk = "FillCommentToUserTrackList";

	private static readonly string z0myk = "ShowWatermark";

	private static readonly string z0nyk = "FieldInvalidateValueForeColor";

	private static readonly string z0byk = "PageMarginLineLength";

	private static readonly string z0vyk = "AutoTranslateDescString";

	private static readonly string z0cyk = "TableCellOperationDetectDistance";

	private static readonly string z0xyk = "AutoEnablePermissionWhenUserLogin";

	private static readonly string z0zyk = "EnabledElementEvent";

	private static readonly string z0luk = "CustomPromptForbitCheckMRID";

	private static readonly string z0kuk = "MaxDecimalDigits";

	private static readonly string z0juk = "EnableKBEntryRangeMask";

	private static readonly string z0huk = "ThreeClickToSelectParagraph";

	private static readonly string z0guk = "Strikeout";

	private static readonly string z0fuk = "MinZoomRate";

	private static readonly string z0duk = "SelectionHightlightMaskColor";

	private static readonly string z0suk = "SimpleElementProperties";

	private static readonly string z0auk_jiejie20260327142557 = "CopyWithoutInputFieldStructure";

	private static readonly string z0quk = "FieldTextColor";

	private static readonly string z0wuk = "Range";

	private static readonly string z0euk = "ValidateIDRepeatMode";

	private static readonly string z0ruk = "CommentFontSize";

	private static readonly string z0tuk = "CheckedValueBindingHandledForTableRow";

	private static readonly string[] z0yuk = new string[3] { "True", "False", "Prompt" };

	private static readonly string z0uuk = "EnableHyperLink";

	private static readonly string z0iuk = "MaxTextLengthForPaste";

	private static readonly string z0ouk = "MinCountForDropdownListSpellCodeArea";

	private static readonly string z0puk = "XMLContentEncodingName";

	private static readonly string z0muk = "SpecifyDebugMode";

	private static readonly string z0nuk = "AutoUpdateButtonVisible";

	private static readonly string z0buk_jiejie20260327142557 = "UnderLineColorNum";

	private static readonly string z0vuk = "FieldTextPrintColor";

	private static readonly string z0cuk = "EnableFieldTextColor";

	private static readonly string z0xuk = "HiddenFieldBorderWhenLostFocus";

	private static readonly string z0zuk_jiejie20260327142557 = "ImageShapeEditorBackgroundMenuItemConfig";

	private static readonly string z0lik = "EnableControlHostAtDesignTime";

	private static readonly string z0kik = "ContinueHeaderParagrahStyle";

	private static readonly string z0jik = "HandleCommandException";

	private static readonly string z0hik = "Font";

	private static readonly string z0gik = "UnEditableFieldBorderColor";

	private static readonly string z0fik = "AutoTranslateSourceString";

	private static readonly string z0dik = "DisableCheckMRIDWhenMRIDIsEmptyForOuterDataObject";

	private static readonly string z0sik = "ImageCompressSaveMode";

	private static readonly string z0aik = "DoubleClickToEditComment";

	private static readonly string z0qik = "TagColorForModifiedField";

	private static readonly string z0wik = "AutoCreateInstanceInProperty";

	private static readonly string z0eik = "EditOptions";

	private static readonly string z0rik = "Repeat";

	private static readonly string[] z0tik = new string[4] { "None", "WarringWhenFail", "PromptForbitWhenFail", "ForbitWhenFail" };

	private static readonly string z0yik = "IgnoreTopBottomPaddingWhenGridLineLayout";

	private static readonly string z0uik = "Image";

	private static readonly string z0iik = "DefaultInputFieldHighlight";

	private static readonly string z0oik = "IncludeKeywords";

	private static readonly string z0pik = "Format";

	private static readonly string z0mik = "AllowDragContent";

	private static readonly string z0nik = "Italic";

	private static readonly string z0bik = "TrackVisibleLevel2";

	private static readonly string z0vik = "AppErrorHandleMode";

	private static readonly string z0cik = "ShowDebugMessage";

	private static readonly string z0xik = "DeleteLineNum";

	private static readonly string z0zik = "ShowHeaderBottomLine";

	private static readonly string z0lok_jiejie20260327142557 = "OldWhitespaceWidth";

	private static readonly string[] z0kok = new string[3] { "Default", "Enabled", "Disabled" };

	private static readonly string z0jok = "TableCellBorderVisibility";

	private static readonly string z0hok = "OutputFieldBorderTextToContentText";

	private static readonly string z0gok = "CompressLayoutForFieldBorder";

	private static readonly string z0fok = "AdornTextBackColor";

	private static readonly string z0dok = "CreationDataFormats";

	private static readonly string z0sok = "CAMode";

	private static readonly string z0aok = "CheckDecimalDigits";

	private static readonly string z0qok = "FastInputMode";

	private static readonly string z0wok = "TabKeyToInsertTableRow";

	private static readonly string z0eok = "Name";

	private static readonly string z0rok = "Enabled";

	private static readonly string z0tok = "RaiseQueryListItemsWhenUserEditText";

	private static readonly string z0yok = "BothBlackWhenPrint";

	private static readonly string z0uok = "DesignMode";

	private static readonly string z0iok = "EnableRightToLeft";

	private static readonly string z0ook = "OutputBackgroundTextToRTF";

	private static readonly string z0pok = "ImageDataBase64String";

	private static readonly string z0mok = "ValueValidateMode";

	private static readonly string z0nok = "SecurityOptions";

	private static readonly string z0bok = "EnableContentLock";

	private static readonly string z0vok = "CommentVisibility";

	private static readonly string z0cok = "FieldBorderColor";

	private static readonly string z0xok = "TrackVisibleLevel1";

	private static readonly string z0zok = "MinImageFileSizeForConfirmCompressSaveMode";

	private static readonly string z0lpk = "ShowGridLine";

	private static readonly string z0kpk = "SetParagraphFlagHeightUsePreElement";

	private static readonly string z0jpk = "Style";

	private static readonly string z0hpk = "Bold";

	private static readonly string z0gpk = "IgnoreFieldBorderWhenPrint";

	private static readonly string z0fpk = "EnableEncryptView";

	private static readonly string z0dpk = "Unit";

	private static readonly string z0spk = "PrintWatermark";

	private static readonly string z0apk = "ShowParagraphFlag";

	private static readonly string z0qpk = "AutoUppercaseFirstCharInFirstLine";

	private static readonly string z0wpk = "AutoClearTextFormatWhenPasteOrInsertContent";

	private static readonly string z0epk = "HiddenTableBorderJumpPrintPage";

	private static readonly string z0rpk = "EnableCopySource";

	private static readonly string z0tpk = "AcceptDataFormats";

	private static readonly string z0ypk = "TabKeyToFirstLineIndent";

	private static readonly string z0upk = "ShowCellNoneBorder";

	private static readonly string z0ipk = "ValueType";

	private static readonly string z0opk = "EnableChineseFontSizeName";

	private static readonly string z0ppk = "StdLablesForImageEditor";

	private static readonly string z0mpk = "MinLength";

	private static readonly string z0npk = "WeakMode";

	private static readonly string z0bpk = "MaxValue";

	private static readonly string z0vpk = "GridLinePreviewText";

	private static readonly string z0cpk = "TrackVisibleLevel3";

	private static readonly string z0xpk = "AutoFixElementIDWhenInsertElements";

	private static readonly string z0zpk = "CustomWarringCheckMRID";

	private static readonly string z0lmk = "PromptJumpBackForSearch";

	private static readonly string z0kmk = "PrintBackgroundText";

	private static readonly string z0jmk = "DoubleClickToSelectWord";

	private static readonly string z0hmk = "AutoInsertTableRowWhenMoveToNextCell";

	private static readonly string[] z0gmk = new string[2] { "Normal", "BreakAll" };

	private static readonly string z0fmk = "NewExpressionExecuteMode";

	private static readonly string z0dmk = "ShowLogicDeletedContent";

	private static readonly string z0smk = "EnableSetJumpPrintPositionWhenPreview";

	private static readonly string z0amk = "PageLineUnderPageBreak";

	private static readonly string z0qmk = "DeleterTipFormatString";

	private static readonly string z0wmk = "Text";

	private static readonly string z0emk = "ParagraphFlagFollowTableOrSection";

	private static readonly string z0rmk = "ShowFlagForOnlySoftwareSign";

	private static readonly string z0tmk = "ColorValue";

	private static readonly string z0ymk = "FieldInvalidateValueBackColor";

	private static readonly string z0umk = "ValueName";

	private static readonly string[] z0imk = new string[3] { "Disable", "Normal", "Strict" };

	private static readonly string z0omk = "BackgroundColor";

	private static readonly string z0pmk = "EnableDeleteReadonlyEmptyContainer";

	private static readonly string z0mmk = "ViewOptions";

	private static readonly string z0nmk = "ReadonlyFieldBackColor";

	private static readonly string z0bmk = "EnableDataBinding";

	private static readonly string z0vmk = "DefaultInputFieldTextColor";

	private static readonly string z0cmk = "ShowFormButton";

	private static readonly string z0xmk = "NoneText";

	private static readonly string z0zmk = "ValidateUserIDWhenEditDeleteComment";

	private static readonly string z0lnk = "BackColorValue";

	private static readonly string z0knk = "MaxLength";

	private static readonly string z0jnk = "MinTableColumnWidth";

	private static readonly string z0hnk = "MoveCaretWhenDeleteFail";

	private static readonly string z0gnk = "KeepTableWidthWhenInsertDeleteColumn";

	private static readonly string z0fnk = "DefaultLineColorForImageEditor";

	private static readonly string z0dnk = "ShowTooltip";

	private static readonly string z0snk = "ShowBackgroundCellID";

	private static readonly string z0ank = "AutoRefreshUserTrackInfos";

	private static readonly string z0qnk = "InsertCommentBindingUserTrack";

	private static readonly string z0wnk = "ExcludeKeywords";

	private static readonly string z0enk = "BehaviorOptions";

	private static readonly string z0rnk = "DateTimeMaxValue";

	private static readonly string z0tnk = "LayoutDirection";

	private static readonly string z0ynk = "EnabledCache100KBImageData";

	private static readonly string z0unk = "WidelyRaiseFocusEvent";

	private static readonly string z0ink = "EnableCollapseSection";

	private static readonly string z0onk = "EmphasisMarkSize";

	private static readonly string z0pnk = "GraphicsSmoothingMode";

	private static readonly string z0mnk = "CloneWithoutElementBorderStyle";

	private static readonly string z0nnk = "FieldBackColor";

	private static readonly string z0bnk = "ShowGrayMaskOverDisableContentParty";

	private static readonly string z0vnk = "CommentEditableWhenReadonly";

	private static readonly string[] z0cnk = new string[4] { "None", "Dynamic", "LostFocus", "Program" };

	private static readonly string z0xnk = "AutoIgnoreLastEmptyPage";

	private static readonly Dictionary<string, string> m_z0znk = z0eek();

	private static readonly string m_z0lbk = "ProtectedContentBackColor";

	private static readonly string m_z0kbk = "BinaryLength";

	private static readonly string m_z0jbk = "ShowPermissionMark";

	private static readonly string m_z0hbk = "NewInputContentUnderlineColor";

	private static readonly string m_z0gbk = "GridLineStyle";

	private static readonly string m_z0fbk = "ShowExpressionFlag";

	private static readonly string[] m_z0dbk = new string[4] { "Default", "None", "Hidden", "Visible" };

	private static readonly string m_z0sbk = "UnderLineStyle";

	private static readonly string[] m_z0abk = new string[4] { "Default", "LeftToRight", "RightToLeft", "Invalidate" };

	private static readonly string m_z0qbk = "ShowNewContentMarkForFirstHistory";

	private static readonly string m_z0wbk = "MaximizedPrintPreviewDialog";

	private static readonly string m_z0ebk = "EnableCalculateControl";

	private static readonly string m_z0rbk = "RealDeleteOwnerContent";

	private static readonly string[] m_z0tbk = new string[3] { "None", "Image", "Text" };

	private static readonly string[] m_z0ybk = new string[7] { "World", "Display", "Pixel", "Point", "Inch", "Document", "Millimeter" };

	private static readonly string m_z0ubk = "NoneBorderColor";

	private static readonly string m_z0ibk = "TitleForToolTip";

	private static readonly string m_z0obk = "SaveBodyTextToXml";

	private static readonly string m_z0pbk = "RegExpression";

	private static readonly string m_z0mbk = "CloneSerialize";

	private static readonly string m_z0nbk = "MoveFieldWhenDragWholeContent";

	private static readonly string m_z0bbk = "FieldBorderPrintVisibility";

	private static readonly string m_z0vbk = "DataObjectRange";

	private static readonly string m_z0cbk = "AutoFocusWhenOpenDocument";

	private static readonly string m_z0xbk = "EnableContentChangedEventWhenLoadDocument";

	private static readonly string m_z0zbk = "EncodingCodePageForWriteRTF";

	private static readonly string m_z0lvk = "FieldBorderElementPixelWidth";

	private static readonly string m_z0kvk = "SelectionTextIncludeBackgroundText";

	private static readonly string[] m_z0jvk = new string[3] { "Disabled", "Software", "Hardware" };

	private static readonly string m_z0hvk = "EnableElementEvents";

	private static readonly string m_z0gvk = "CanModifyDeleteSameLevelContent";

	private static readonly string m_z0fvk = "Alpha";

	private static readonly string m_z0dvk = "Size";

	private static readonly string[] m_z0svk = new string[8] { "Default", "DataSource", "ToolTip", "ValidateMessage", "ID", "Name", "TabIndex", "Custom" };

	private static readonly string m_z0avk = "CompressXMLContent";

	private static readonly string z0qvk = "RemoveLastParagraphFlagWhenInsertDocument";

	private static readonly string m_z0wvk = "UseNewValueExpressionEngine";

	private static readonly string m_z0evk = "ShowPermissionTip";

	private static readonly string m_z0rvk = "CheckMinValue";

	private static readonly string[] m_z0tvk = new string[11]
	{
		"None", "Single", "Thick", "Dash", "Dot", "DashDot", "DashDotDot", "Double", "Wavy", "WavyDouble",
		"WavyHeavy"
	};

	private static readonly string m_z0yvk = "ShowLineNumber";

	private static readonly string z0uvk = "Angle";

	private static readonly string z0ivk = "DebugMode";

	private static readonly string[] z0ovk = new string[3] { "Auto", "Visible", "Hide" };

	private static readonly string z0pvk = "InsertDocumentWithCheckMRID";

	private static readonly string z0mvk = "PrintImageAltText";

	private static readonly string z0nvk = "WordBreak";

	private static readonly string z0bvk = "Required";

	private static readonly string z0vvk = "CustomMessage";

	private static readonly string z0cvk = "NormalFieldBorderColor";

	private static readonly string z0xvk = "FixWidthWhenInsertTable";

	private static readonly string z0zvk = "PreserveBackgroundTextWhenPrint";

	private static readonly string z0lck = "Printable";

	private static readonly string z0kck = "SpecifyExtenGridLineStep";

	private static readonly string z0jck = "CAServerPort";

	private static readonly string z0hck = "GlobalSpecifyDebugModeValue";

	private static readonly string z0gck = "ActiveCheckInstallWindowsMediaPlayer";

	public static void z0eek(Utf8JsonWriter p0, WatermarkType p1)
	{
		if (p1 >= WatermarkType.None && (int)p1 < z0ZzZzxij.m_z0tbk.Length)
		{
			p0.WriteStringValue(z0ZzZzxij.m_z0tbk[(int)p1]);
		}
		else
		{
			p0.WriteNumberValue((int)p1);
		}
	}

	public static void z0eek(Utf8JsonWriter p0, ValueFormatStyle p1)
	{
		if (p1 >= ValueFormatStyle.None && (int)p1 < z0vrk.Length)
		{
			p0.WriteStringValue(z0vrk[(int)p1]);
		}
		else
		{
			p0.WriteNumberValue((int)p1);
		}
	}

	public static DocumentSecurityOptions z0eek(ref Utf8JsonReader p0, DocumentSecurityOptions p1)
	{
		if (p1 == null || p0.TokenType != JsonTokenType.StartObject)
		{
			return p1;
		}
		while (p0.Read() && p0.TokenType != JsonTokenType.EndObject)
		{
			if (p0.TokenType == JsonTokenType.PropertyName)
			{
				string text = p0.GetString();
				object obj = z0eek(text);
				if (!p0.Read())
				{
					break;
				}
				if (obj == z0xyk)
				{
					p1.AutoEnablePermissionWhenUserLogin = p0.z0yek(p1: true);
				}
				else if (obj == z0sok)
				{
					p1.CAMode = z0eek(ref p0, DCCAMode.Software);
				}
				else if (obj == z0ZzZzxij.m_z0gvk)
				{
					p1.CanModifyDeleteSameLevelContent = p0.z0yek(p1: true);
				}
				else if (obj == z0qrk)
				{
					p1.CAServerIP = p0.GetString();
				}
				else if (obj == z0jck)
				{
					p1.CAServerPort = p0.z0yek(0);
				}
				else if (obj == z0wrk)
				{
					p1.CreatorTipFormatString = p0.GetString();
				}
				else if (obj == z0qmk)
				{
					p1.DeleterTipFormatString = p0.GetString();
				}
				else if (obj == z0trk)
				{
					p1.EnableLogicDelete = p0.z0yek(p1: false);
				}
				else if (obj == z0btk)
				{
					p1.EnablePermission = p0.z0yek(p1: false);
				}
				else if (obj == z0yyk)
				{
					p1.PowerfulSignDocument = p0.z0yek(p1: true);
				}
				else if (obj == z0ZzZzxij.m_z0rbk)
				{
					p1.RealDeleteOwnerContent = p0.z0yek(p1: false);
				}
				else if (obj == z0rmk)
				{
					p1.ShowFlagForOnlySoftwareSign = p0.z0yek(p1: true);
				}
				else if (obj == z0dmk)
				{
					p1.ShowLogicDeletedContent = p0.z0yek(p1: false);
				}
				else if (obj == z0ZzZzxij.m_z0qbk)
				{
					p1.ShowNewContentMarkForFirstHistory = p0.z0yek(p1: true);
				}
				else if (obj == z0ZzZzxij.m_z0jbk)
				{
					p1.ShowPermissionMark = p0.z0yek(p1: false);
				}
				else if (obj == z0ZzZzxij.m_z0evk)
				{
					p1.ShowPermissionTip = p0.z0yek(p1: true);
				}
				else if (obj == z0urk)
				{
					p1.TrackVisibleLevel0 = z0eek(ref p0, new z0ZzZzigh());
				}
				else if (obj == z0xok)
				{
					p1.TrackVisibleLevel1 = z0eek(ref p0, new z0ZzZzigh());
				}
				else if (obj == z0bik)
				{
					p1.TrackVisibleLevel2 = z0eek(ref p0, new z0ZzZzigh());
				}
				else if (obj == z0cpk)
				{
					p1.TrackVisibleLevel3 = z0eek(ref p0, new z0ZzZzigh());
				}
				else
				{
					z0eek("DocumentSecurityOptions", text);
				}
			}
		}
		return p1;
	}

	public static ContentLayoutDirectionStyle z0eek(ref Utf8JsonReader p0, ContentLayoutDirectionStyle p1)
	{
		if (p0.TokenType == JsonTokenType.String)
		{
			string text = p0.GetString();
			for (int num = z0ZzZzxij.m_z0abk.Length - 1; num >= 0; num--)
			{
				if (text.Equals(z0ZzZzxij.m_z0abk[num], StringComparison.OrdinalIgnoreCase))
				{
					return (ContentLayoutDirectionStyle)num;
				}
			}
		}
		else if (p0.TokenType == JsonTokenType.Number)
		{
			return (ContentLayoutDirectionStyle)p0.GetInt32();
		}
		return p1;
	}

	public static GraphicsUnit z0eek(ref Utf8JsonReader p0, GraphicsUnit p1)
	{
		if (p0.TokenType == JsonTokenType.String)
		{
			string text = p0.GetString();
			for (int num = z0ZzZzxij.m_z0ybk.Length - 1; num >= 0; num--)
			{
				if (text.Equals(z0ZzZzxij.m_z0ybk[num], StringComparison.OrdinalIgnoreCase))
				{
					return (GraphicsUnit)num;
				}
			}
		}
		else if (p0.TokenType == JsonTokenType.Number)
		{
			return (GraphicsUnit)p0.GetInt32();
		}
		return p1;
	}

	public static void z0eek(Utf8JsonWriter p0, DocumentEditOptions p1)
	{
		if (p1 == null)
		{
			throw new ArgumentNullException("instance");
		}
		if (p0 == null)
		{
			throw new ArgumentNullException("jwriter");
		}
		p0.WriteStartObject();
		p0.WriteBoolean(z0hmk, p1.AutoInsertTableRowWhenMoveToNextCell);
		p0.WriteBoolean(z0krk, p1.ClearFieldValueWhenCopy);
		p0.WriteBoolean(z0mnk, p1.CloneWithoutElementBorderStyle);
		p0.WriteBoolean(z0ftk, p1.CloneWithoutLogicDeletedContent);
		p0.WriteBoolean(z0etk, p1.CopyInTextFormatOnly);
		p0.WriteBoolean(z0auk_jiejie20260327142557, p1.CopyWithoutInputFieldStructure);
		p0.WriteBoolean(z0pek, p1.FixSizeWhenInsertImage);
		p0.WriteBoolean(z0xvk, p1.FixWidthWhenInsertTable);
		p0.WriteString(z0vpk, p1.GridLinePreviewText);
		p0.WriteBoolean(z0gnk, p1.KeepTableWidthWhenInsertDeleteColumn);
		p0.WriteBoolean(z0ypk, p1.TabKeyToFirstLineIndent);
		p0.WriteBoolean(z0wok, p1.TabKeyToInsertTableRow);
		p0.WritePropertyName(z0mok);
		z0eek(p0, p1.ValueValidateMode);
		p0.WriteEndObject();
	}

	public static ValueFormatStyle z0eek(ref Utf8JsonReader p0, ValueFormatStyle p1)
	{
		if (p0.TokenType == JsonTokenType.String)
		{
			string text = p0.GetString();
			for (int num = z0vrk.Length - 1; num >= 0; num--)
			{
				if (text.Equals(z0vrk[num], StringComparison.OrdinalIgnoreCase))
				{
					return (ValueFormatStyle)num;
				}
			}
		}
		else if (p0.TokenType == JsonTokenType.Number)
		{
			return (ValueFormatStyle)p0.GetInt32();
		}
		return p1;
	}

	public static DocumentEditOptions z0eek(ref Utf8JsonReader p0, DocumentEditOptions p1)
	{
		if (p1 == null || p0.TokenType != JsonTokenType.StartObject)
		{
			return p1;
		}
		while (p0.Read() && p0.TokenType != JsonTokenType.EndObject)
		{
			if (p0.TokenType == JsonTokenType.PropertyName)
			{
				string text = p0.GetString();
				object obj = z0eek(text);
				if (!p0.Read())
				{
					break;
				}
				if (obj == z0hmk)
				{
					p1.AutoInsertTableRowWhenMoveToNextCell = p0.z0yek(p1: true);
				}
				else if (obj == z0krk)
				{
					p1.ClearFieldValueWhenCopy = p0.z0yek(p1: false);
				}
				else if (obj == z0mnk)
				{
					p1.CloneWithoutElementBorderStyle = p0.z0yek(p1: true);
				}
				else if (obj == z0ftk)
				{
					p1.CloneWithoutLogicDeletedContent = p0.z0yek(p1: false);
				}
				else if (obj == z0etk)
				{
					p1.CopyInTextFormatOnly = p0.z0yek(p1: false);
				}
				else if (obj == z0auk_jiejie20260327142557)
				{
					p1.CopyWithoutInputFieldStructure = p0.z0yek(p1: false);
				}
				else if (obj == z0pek)
				{
					p1.FixSizeWhenInsertImage = p0.z0yek(p1: true);
				}
				else if (obj == z0xvk)
				{
					p1.FixWidthWhenInsertTable = p0.z0yek(p1: true);
				}
				else if (obj == z0vpk)
				{
					p1.GridLinePreviewText = p0.GetString();
				}
				else if (obj == z0gnk)
				{
					p1.KeepTableWidthWhenInsertDeleteColumn = p0.z0yek(p1: true);
				}
				else if (obj == z0ypk)
				{
					p1.TabKeyToFirstLineIndent = p0.z0yek(p1: true);
				}
				else if (obj == z0wok)
				{
					p1.TabKeyToInsertTableRow = p0.z0yek(p1: true);
				}
				else if (obj == z0mok)
				{
					p1.ValueValidateMode = z0eek(ref p0, DocumentValueValidateMode.LostFocus);
				}
				else
				{
					z0eek("DocumentEditOptions", text);
				}
			}
		}
		return p1;
	}

	public static void z0eek(Utf8JsonWriter p0, z0ZzZzimk p1)
	{
		if (p1 == null)
		{
			throw new ArgumentNullException("instance");
		}
		if (p0 == null)
		{
			throw new ArgumentNullException("jwriter");
		}
		p0.WriteStartObject();
		p0.WriteBoolean(z0hpk, p1.Bold);
		p0.WriteBoolean(z0nik, p1.Italic);
		p0.WriteString(z0eok, p1.Name);
		p0.WriteNumber(z0ZzZzxij.m_z0dvk, p1.Size);
		p0.WriteBoolean(z0guk, p1.Strikeout);
		p0.WriteBoolean(z0bek, p1.Underline);
		p0.WritePropertyName(z0dpk);
		z0eek(p0, p1.Unit);
		p0.WriteEndObject();
	}

	public static void z0eek(Utf8JsonWriter p0, EnableState p1)
	{
		if (p1 >= EnableState.Default && (int)p1 < z0kok.Length)
		{
			p0.WriteStringValue(z0kok[(int)p1]);
		}
		else
		{
			p0.WriteNumberValue((int)p1);
		}
	}

	public static TextUnderlineStyle z0eek(ref Utf8JsonReader p0, TextUnderlineStyle p1)
	{
		if (p0.TokenType == JsonTokenType.String)
		{
			string text = p0.GetString();
			for (int num = z0ZzZzxij.m_z0tvk.Length - 1; num >= 0; num--)
			{
				if (text.Equals(z0ZzZzxij.m_z0tvk[num], StringComparison.OrdinalIgnoreCase))
				{
					return (TextUnderlineStyle)num;
				}
			}
		}
		else if (p0.TokenType == JsonTokenType.Number)
		{
			return (TextUnderlineStyle)p0.GetInt32();
		}
		return p1;
	}

	public static void z0eek(Utf8JsonWriter p0, DCAdornTextVisibility p1)
	{
		if (p1 >= DCAdornTextVisibility.Hidden && (int)p1 < z0ayk.Length)
		{
			p0.WriteStringValue(z0ayk[(int)p1]);
		}
		else
		{
			p0.WriteNumberValue((int)p1);
		}
	}

	public static void z0eek(Utf8JsonWriter p0, TextUnderlineStyle p1)
	{
		if (p1 >= TextUnderlineStyle.None && (int)p1 < z0ZzZzxij.m_z0tvk.Length)
		{
			p0.WriteStringValue(z0ZzZzxij.m_z0tvk[(int)p1]);
		}
		else
		{
			p0.WriteNumberValue((int)p1);
		}
	}

	public static void z0eek(Utf8JsonWriter p0, DCWordBreakStyle p1)
	{
		if (p1 >= DCWordBreakStyle.Normal && (int)p1 < z0gmk.Length)
		{
			p0.WriteStringValue(z0gmk[(int)p1]);
		}
		else
		{
			p0.WriteNumberValue((int)p1);
		}
	}

	public static ValueValidateStyle z0eek(ref Utf8JsonReader p0, ValueValidateStyle p1)
	{
		if (p1 == null || p0.TokenType != JsonTokenType.StartObject)
		{
			return p1;
		}
		while (p0.Read() && p0.TokenType != JsonTokenType.EndObject)
		{
			if (p0.TokenType == JsonTokenType.PropertyName)
			{
				string text = p0.GetString();
				object obj = z0eek(text);
				if (!p0.Read())
				{
					break;
				}
				if (obj == z0ZzZzxij.m_z0kbk)
				{
					p1.BinaryLength = p0.z0yek(p1: false);
				}
				else if (obj == z0aok)
				{
					p1.CheckDecimalDigits = p0.z0yek(p1: false);
				}
				else if (obj == z0uek)
				{
					p1.CheckMaxValue = p0.z0yek(p1: false);
				}
				else if (obj == z0ZzZzxij.m_z0rvk)
				{
					p1.CheckMinValue = p0.z0yek(p1: false);
				}
				else if (obj == z0vvk)
				{
					p1.CustomMessage = p0.GetString();
				}
				else if (obj == z0rnk)
				{
					p1.DateTimeMaxValue = p0.z0yek(624511296000000000L);
				}
				else if (obj == z0ttk)
				{
					p1.DateTimeMinValue = p0.z0yek(624511296000000000L);
				}
				else if (obj == z0wnk)
				{
					p1.ExcludeKeywords = p0.GetString();
				}
				else if (obj == z0oik)
				{
					p1.IncludeKeywords = p0.GetString();
				}
				else if (obj == z0qyk)
				{
					p1.Level = z0eek(ref p0, ValueValidateLevel.Error);
				}
				else if (obj == z0kuk)
				{
					p1.MaxDecimalDigits = p0.z0yek(0);
				}
				else if (obj == z0knk)
				{
					p1.MaxLength = p0.z0yek(0);
				}
				else if (obj == z0bpk)
				{
					p1.MaxValue = p0.z0yek(0.0);
				}
				else if (obj == z0mpk)
				{
					p1.MinLength = p0.z0yek(0);
				}
				else if (obj == z0ntk)
				{
					p1.MinValue = p0.z0yek(0.0);
				}
				else if (obj == z0wuk)
				{
					p1.Range = p0.GetString();
				}
				else if (obj == z0ZzZzxij.m_z0pbk)
				{
					p1.RegExpression = p0.GetString();
				}
				else if (obj == z0bvk)
				{
					p1.Required = p0.z0yek(p1: false);
				}
				else if (obj == z0umk)
				{
					p1.ValueName = p0.GetString();
				}
				else if (obj == z0ipk)
				{
					p1.ValueType = z0eek(ref p0, ValueTypeStyle.Text);
				}
				else
				{
					z0eek("ValueValidateStyle", text);
				}
			}
		}
		return p1;
	}

	public static WatermarkType z0eek(ref Utf8JsonReader p0, WatermarkType p1)
	{
		if (p0.TokenType == JsonTokenType.String)
		{
			string text = p0.GetString();
			for (int num = z0ZzZzxij.m_z0tbk.Length - 1; num >= 0; num--)
			{
				if (text.Equals(z0ZzZzxij.m_z0tbk[num], StringComparison.OrdinalIgnoreCase))
				{
					return (WatermarkType)num;
				}
			}
		}
		else if (p0.TokenType == JsonTokenType.Number)
		{
			return (WatermarkType)p0.GetInt32();
		}
		return p1;
	}

	public static RenderVisibility z0eek(ref Utf8JsonReader p0, RenderVisibility p1)
	{
		if (p0.TokenType == JsonTokenType.String)
		{
			string? text = p0.GetString();
			RenderVisibility result = p1;
			if (Enum.TryParse<RenderVisibility>(text, out result))
			{
				return result;
			}
			return p1;
		}
		if (p0.TokenType == JsonTokenType.Number)
		{
			return (RenderVisibility)p0.GetInt32();
		}
		return p1;
	}

	public static z0ZzZzwmk z0eek(ref Utf8JsonReader p0, z0ZzZzwmk p1)
	{
		if (p1 == null || p0.TokenType != JsonTokenType.StartObject)
		{
			return p1;
		}
		while (p0.Read() && p0.TokenType != JsonTokenType.EndObject)
		{
			if (p0.TokenType == JsonTokenType.PropertyName)
			{
				string text = p0.GetString();
				object obj = z0eek(text);
				if (!p0.Read())
				{
					break;
				}
				if (obj == z0ZzZzxij.m_z0fvk)
				{
					p1.Alpha = p0.z0yek(80);
				}
				else if (obj == z0uvk)
				{
					p1.Angle = p0.z0yek(0f);
				}
				else if (obj == z0lnk)
				{
					p1.BackColorValue = p0.GetString();
				}
				else if (obj == z0tmk)
				{
					p1.ColorValue = p0.GetString();
				}
				else if (obj == z0kyk)
				{
					p1.DensityForRepeat = p0.z0yek(1f);
				}
				else if (obj == z0hik)
				{
					p1.Font = z0eek(ref p0, new z0ZzZzimk());
				}
				else if (obj == z0uik)
				{
					p1.Image = z0eek(ref p0, new z0ZzZzpmk());
				}
				else if (obj == z0spk)
				{
					p1.PrintWatermark = p0.z0yek(p1: true);
				}
				else if (obj == z0rik)
				{
					p1.Repeat = p0.z0yek(p1: false);
				}
				else if (obj == z0myk)
				{
					p1.ShowWatermark = p0.z0yek(p1: true);
				}
				else if (obj == z0wmk)
				{
					p1.Text = p0.GetString();
				}
				else if (obj == z0yrk)
				{
					p1.Type = z0eek(ref p0, WatermarkType.None);
				}
				else
				{
					z0eek("WatermarkInfo", text);
				}
			}
		}
		return p1;
	}

	public static ValueValidateLevel z0eek(ref Utf8JsonReader p0, ValueValidateLevel p1)
	{
		if (p0.TokenType == JsonTokenType.String)
		{
			string text = p0.GetString();
			for (int num = z0dtk.Length - 1; num >= 0; num--)
			{
				if (text.Equals(z0dtk[num], StringComparison.OrdinalIgnoreCase))
				{
					return (ValueValidateLevel)num;
				}
			}
		}
		else if (p0.TokenType == JsonTokenType.Number)
		{
			return (ValueValidateLevel)p0.GetInt32();
		}
		return p1;
	}

	public static DocumentViewOptions z0eek(ref Utf8JsonReader p0, DocumentViewOptions p1)
	{
		if (p1 == null || p0.TokenType != JsonTokenType.StartObject)
		{
			return p1;
		}
		while (p0.Read() && p0.TokenType != JsonTokenType.EndObject)
		{
			if (p0.TokenType == JsonTokenType.PropertyName)
			{
				string text = p0.GetString();
				object obj = z0eek(text);
				if (!p0.Read())
				{
					break;
				}
				if (obj == z0fok)
				{
					p1.AdornTextBackColor = p0.z0yek(Color.Black);
				}
				else if (obj == z0jyk)
				{
					p1.AdornTextVisibility = z0eek(ref p0, DCAdornTextVisibility.Hidden);
				}
				else if (obj == z0tek)
				{
					p1.BackgroundTextColor = p0.z0yek(Color.Gray);
				}
				else if (obj == z0yok)
				{
					p1.BothBlackWhenPrint = p0.z0yek(p1: false);
				}
				else if (obj == z0dyk)
				{
					p1.CommentDateFormatString = p0.GetString();
				}
				else if (obj == z0prk)
				{
					p1.CommentFontName = p0.GetString();
				}
				else if (obj == z0ruk)
				{
					p1.CommentFontSize = p0.z0yek(10f);
				}
				else if (obj == z0rrk)
				{
					p1.DefaultAdornTextType = z0eek(ref p0, InputFieldAdornTextType.DataSource);
				}
				else if (obj == z0iik)
				{
					p1.DefaultInputFieldHighlight = z0eek(ref p0, EnableState.Enabled);
				}
				else if (obj == z0vmk)
				{
					p1.DefaultInputFieldTextColor = p0.z0yek(Color.Transparent);
				}
				else if (obj == z0fnk)
				{
					p1.DefaultLineColorForImageEditor = p0.z0yek(Color.Empty);
				}
				else if (obj == z0onk)
				{
					p1.EmphasisMarkSize = p0.z0yek(10f);
				}
				else if (obj == z0fpk)
				{
					p1.EnableEncryptView = p0.z0yek(p1: true);
				}
				else if (obj == z0cuk)
				{
					p1.EnableFieldTextColor = p0.z0yek(p1: false);
				}
				else if (obj == z0iok)
				{
					p1.EnableRightToLeft = p0.z0yek(p1: true);
				}
				else if (obj == z0nnk)
				{
					p1.FieldBackColor = p0.z0yek(Color.AliceBlue);
				}
				else if (obj == z0cok)
				{
					p1.FieldBorderColor = p0.z0yek(Color.Empty);
				}
				else if (obj == z0ZzZzxij.m_z0lvk)
				{
					p1.FieldBorderElementPixelWidth = p0.z0yek(1f);
				}
				else if (obj == z0ZzZzxij.m_z0bbk)
				{
					p1.FieldBorderPrintVisibility = z0eek(ref p0, DCRenderVisibility.Default);
				}
				else if (obj == z0ytk)
				{
					p1.FieldFocusedBackColor = p0.z0yek(Color.LightBlue);
				}
				else if (obj == z0zek)
				{
					p1.FieldHoverBackColor = p0.z0yek(Color.LightBlue);
				}
				else if (obj == z0ymk)
				{
					p1.FieldInvalidateValueBackColor = p0.z0yek(Color.Transparent);
				}
				else if (obj == z0nyk)
				{
					p1.FieldInvalidateValueForeColor = p0.z0yek(Color.LightCoral);
				}
				else if (obj == z0quk)
				{
					p1.FieldTextColor = p0.z0yek(Color.Black);
				}
				else if (obj == z0vuk)
				{
					p1.FieldTextPrintColor = p0.z0yek(Color.Transparent);
				}
				else if (obj == z0pnk)
				{
					p1.GraphicsSmoothingMode = z0eek(ref p0, SmoothingMode.None);
				}
				else if (obj == z0ZzZzxij.m_z0gbk)
				{
					p1.GridLineStyle = z0eek(ref p0, DashStyle.Solid);
				}
				else if (obj == z0ztk)
				{
					p1.HeaderBottomLineWidth = p0.z0yek(1f);
				}
				else if (obj == z0xuk)
				{
					p1.HiddenFieldBorderWhenLostFocus = p0.z0yek(p1: true);
				}
				else if (obj == z0epk)
				{
					p1.HiddenTableBorderJumpPrintPage = p0.z0yek(p1: false);
				}
				else if (obj == z0nek)
				{
					p1.HighlightProtectedContent = p0.z0yek(p1: false);
				}
				else if (obj == z0gpk)
				{
					p1.IgnoreFieldBorderWhenPrint = p0.z0yek(p1: true);
				}
				else if (obj == z0rtk)
				{
					p1.ImageInterpolationMode = z0eek(ref p0, InterpolationMode.High);
				}
				else if (obj == z0tnk)
				{
					p1.LayoutDirection = z0eek(ref p0, ContentLayoutDirectionStyle.LeftToRight);
				}
				else if (obj == z0ptk)
				{
					p1.MaskColorForJumpPrint = p0.z0yek(Color.FromArgb(1677721855));
				}
				else if (obj == z0jnk)
				{
					p1.MinTableColumnWidth = p0.z0yek(50f);
				}
				else if (obj == z0ZzZzxij.m_z0hbk)
				{
					p1.NewInputContentUnderlineColor = p0.z0yek(Color.Transparent);
				}
				else if (obj == z0ZzZzxij.m_z0ubk)
				{
					p1.NoneBorderColor = p0.z0yek(Color.LightGray);
				}
				else if (obj == z0cvk)
				{
					p1.NormalFieldBorderColor = p0.z0yek(Color.Blue);
				}
				else if (obj == z0lok_jiejie20260327142557)
				{
					p1.OldWhitespaceWidth = p0.z0yek(p1: false);
				}
				else if (obj == z0byk)
				{
					p1.PageMarginLineLength = p0.z0yek(30);
				}
				else if (obj == z0zvk)
				{
					p1.PreserveBackgroundTextWhenPrint = p0.z0yek(p1: false);
				}
				else if (obj == z0kmk)
				{
					p1.PrintBackgroundText = p0.z0yek(p1: false);
				}
				else if (obj == z0irk)
				{
					p1.PrintGridLine = p0.z0yek(p1: false);
				}
				else if (obj == z0mvk)
				{
					p1.PrintImageAltText = p0.z0yek(p1: false);
				}
				else if (obj == z0ZzZzxij.m_z0lbk)
				{
					p1.ProtectedContentBackColor = p0.z0yek(Color.Empty);
				}
				else if (obj == z0nmk)
				{
					p1.ReadonlyFieldBackColor = p0.z0yek(Color.AliceBlue);
				}
				else if (obj == z0tyk)
				{
					p1.ReadonlyFieldBorderColor = p0.z0yek(Color.Gray);
				}
				else if (obj == z0otk)
				{
					p1.SectionBorderVisibility = z0eek(ref p0, RenderVisibility.All);
				}
				else if (obj == z0duk)
				{
					p1.SelectionHightlightMaskColor = p0.z0yek(Color.Black);
				}
				else if (obj == z0snk)
				{
					p1.ShowBackgroundCellID = p0.z0yek(p1: false);
				}
				else if (obj == z0upk)
				{
					p1.ShowCellNoneBorder = p0.z0yek(p1: true);
				}
				else if (obj == z0ZzZzxij.m_z0fbk)
				{
					p1.ShowExpressionFlag = p0.z0yek(p1: true);
				}
				else if (obj == z0cek)
				{
					p1.ShowFieldBorderElement = p0.z0yek(p1: true);
				}
				else if (obj == z0cmk)
				{
					p1.ShowFormButton = p0.z0yek(p1: false);
				}
				else if (obj == z0uyk)
				{
					p1.ShowGlobalGridLineInTableAndSection = p0.z0yek(p1: true);
				}
				else if (obj == z0bnk)
				{
					p1.ShowGrayMaskOverDisableContentParty = p0.z0yek(p1: true);
				}
				else if (obj == z0lpk)
				{
					p1.ShowGridLine = p0.z0yek(p1: false);
				}
				else if (obj == z0zik)
				{
					p1.ShowHeaderBottomLine = p0.z0yek(p1: true);
				}
				else if (obj == z0xrk)
				{
					p1.ShowInputFieldStateTag = p0.z0yek(p1: false);
				}
				else if (obj == z0ZzZzxij.m_z0yvk)
				{
					p1.ShowLineNumber = p0.z0yek(p1: false);
				}
				else if (obj == z0htk)
				{
					p1.ShowPageBreak = p0.z0yek(p1: false);
				}
				else if (obj == z0ctk)
				{
					p1.ShowPageLine = p0.z0yek(p1: false);
				}
				else if (obj == z0apk)
				{
					p1.ShowParagraphFlag = p0.z0yek(p1: true);
				}
				else if (obj == z0ryk)
				{
					p1.ShowRedErrorMessageForPaint = p0.z0yek(p1: true);
				}
				else if (obj == z0kck)
				{
					p1.SpecifyExtenGridLineStep = p0.z0yek(0f);
				}
				else if (obj == z0iyk)
				{
					p1.SupportUG = p0.z0yek(p1: false);
				}
				else if (obj == z0jok)
				{
					p1.TableCellBorderVisibility = z0eek(ref p0, RenderVisibility.All);
				}
				else if (obj == z0qik)
				{
					p1.TagColorForModifiedField = p0.z0yek(Color.Blue);
				}
				else if (obj == z0lyk)
				{
					p1.TagColorForNormalField = p0.z0yek(Color.Red);
				}
				else if (obj == z0xek)
				{
					p1.TagColorForReadonlyField = p0.z0yek(Color.Gray);
				}
				else if (obj == z0eyk)
				{
					p1.TagColorForValueInvalidateField = p0.z0yek(Color.Red);
				}
				else if (obj == z0vek)
				{
					p1.TextRenderStyle = z0eek(ref p0, (z0ZzZzfsh)5);
				}
				else if (obj == z0gik)
				{
					p1.UnEditableFieldBorderColor = p0.z0yek(Color.Red);
				}
				else if (obj == z0hyk)
				{
					p1.ShowFieldBorderTextInTheMiddle = p0.z0yek(p1: false);
				}
				else
				{
					z0eek("DocumentViewOptions", text);
				}
			}
		}
		return p1;
	}

	public static ValueTypeStyle z0eek(ref Utf8JsonReader p0, ValueTypeStyle p1)
	{
		if (p0.TokenType == JsonTokenType.String)
		{
			string text = p0.GetString();
			for (int num = z0wtk.Length - 1; num >= 0; num--)
			{
				if (text.Equals(z0wtk[num], StringComparison.OrdinalIgnoreCase))
				{
					return (ValueTypeStyle)num;
				}
			}
		}
		else if (p0.TokenType == JsonTokenType.Number)
		{
			return (ValueTypeStyle)p0.GetInt32();
		}
		return p1;
	}

	public static void z0eek(Utf8JsonWriter p0, MoveFocusHotKeys p1)
	{
		p0.WriteStringValue(p1.ToString());
	}

	public static PromptProtectedContentMode z0eek(ref Utf8JsonReader p0, PromptProtectedContentMode p1)
	{
		if (p0.TokenType == JsonTokenType.String)
		{
			string text = p0.GetString();
			for (int num = z0hrk.Length - 1; num >= 0; num--)
			{
				if (text.Equals(z0hrk[num], StringComparison.OrdinalIgnoreCase))
				{
					return (PromptProtectedContentMode)num;
				}
			}
		}
		else if (p0.TokenType == JsonTokenType.Number)
		{
			return (PromptProtectedContentMode)p0.GetInt32();
		}
		return p1;
	}

	public static MoveFocusHotKeys z0eek(ref Utf8JsonReader p0, MoveFocusHotKeys p1)
	{
		if (p0.TokenType == JsonTokenType.String)
		{
			string? text = p0.GetString();
			MoveFocusHotKeys result = p1;
			if (Enum.TryParse<MoveFocusHotKeys>(text, out result))
			{
				return result;
			}
			return p1;
		}
		if (p0.TokenType == JsonTokenType.Number)
		{
			return (MoveFocusHotKeys)p0.GetInt32();
		}
		return p1;
	}

	public static SmoothingMode z0eek(ref Utf8JsonReader p0, SmoothingMode p1)
	{
		if (p0.TokenType == JsonTokenType.String)
		{
			string text = p0.GetString();
			if (text.Equals("AntiAlias", StringComparison.OrdinalIgnoreCase))
			{
				return SmoothingMode.AntiAlias;
			}
			if (text.Equals("Default", StringComparison.OrdinalIgnoreCase))
			{
				return SmoothingMode.Default;
			}
			if (text.Equals("HighQuality", StringComparison.OrdinalIgnoreCase))
			{
				return SmoothingMode.HighQuality;
			}
			if (text.Equals("HighSpeed", StringComparison.OrdinalIgnoreCase))
			{
				return SmoothingMode.HighSpeed;
			}
			if (text.Equals("Invalid", StringComparison.OrdinalIgnoreCase))
			{
				return SmoothingMode.Invalid;
			}
			if (text.Equals("None", StringComparison.OrdinalIgnoreCase))
			{
				return SmoothingMode.None;
			}
			return SmoothingMode.Invalid;
		}
		if (p0.TokenType == JsonTokenType.Number)
		{
			return (SmoothingMode)p0.GetInt32();
		}
		return p1;
	}

	public static void z0eek(Utf8JsonWriter p0, GraphicsUnit p1)
	{
		if (p1 >= GraphicsUnit.World && (int)p1 < z0ZzZzxij.m_z0ybk.Length)
		{
			p0.WriteStringValue(z0ZzZzxij.m_z0ybk[(int)p1]);
		}
		else
		{
			p0.WriteNumberValue((int)p1);
		}
	}

	public static void z0eek(Utf8JsonWriter p0, InterpolationMode p1)
	{
		p0.WriteStringValue(p1.ToString());
	}

	public static DCImageCompressSaveMode z0eek(ref Utf8JsonReader p0, DCImageCompressSaveMode p1)
	{
		if (p0.TokenType == JsonTokenType.String)
		{
			string text = p0.GetString();
			for (int num = z0yuk.Length - 1; num >= 0; num--)
			{
				if (text.Equals(z0yuk[num], StringComparison.OrdinalIgnoreCase))
				{
					return (DCImageCompressSaveMode)num;
				}
			}
		}
		else if (p0.TokenType == JsonTokenType.Number)
		{
			return (DCImageCompressSaveMode)p0.GetInt32();
		}
		return p1;
	}

	public static void z0eek(Utf8JsonWriter p0, WriterDataObjectRange p1)
	{
		if (p1 >= WriterDataObjectRange.OS && (int)p1 < z0ork_jiejie20260327142557.Length)
		{
			p0.WriteStringValue(z0ork_jiejie20260327142557[(int)p1]);
		}
		else
		{
			p0.WriteNumberValue((int)p1);
		}
	}

	public static DCValidateIDRepeatMode z0eek(ref Utf8JsonReader p0, DCValidateIDRepeatMode p1)
	{
		if (p0.TokenType == JsonTokenType.String)
		{
			string text = p0.GetString();
			for (int num = z0brk.Length - 1; num >= 0; num--)
			{
				if (text.Equals(z0brk[num], StringComparison.OrdinalIgnoreCase))
				{
					return (DCValidateIDRepeatMode)num;
				}
			}
		}
		else if (p0.TokenType == JsonTokenType.Number)
		{
			return (DCValidateIDRepeatMode)p0.GetInt32();
		}
		return p1;
	}

	public static void z0eek(Utf8JsonWriter p0, z0ZzZzpmk p1)
	{
		if (p1 == null)
		{
			throw new ArgumentNullException("instance");
		}
		if (p0 == null)
		{
			throw new ArgumentNullException("jwriter");
		}
		p0.WriteStartObject();
		p0.WriteString(z0pok, p1.ImageDataBase64String);
		p0.WriteEndObject();
	}

	public static void z0eek(Utf8JsonWriter p0, z0ZzZzwmk p1)
	{
		if (p1 == null)
		{
			throw new ArgumentNullException("instance");
		}
		if (p0 == null)
		{
			throw new ArgumentNullException("jwriter");
		}
		p0.WriteStartObject();
		p0.WriteNumber(z0ZzZzxij.m_z0fvk, p1.Alpha);
		p0.WriteNumber(z0uvk, p1.Angle);
		p0.WriteString(z0lnk, p1.BackColorValue);
		p0.WriteString(z0tmk, p1.ColorValue);
		p0.WriteNumber(z0kyk, p1.DensityForRepeat);
		p0.WritePropertyName(z0hik);
		z0eek(p0, p1.Font);
		p0.WritePropertyName(z0uik);
		z0eek(p0, p1.Image);
		p0.WriteBoolean(z0spk, p1.PrintWatermark);
		p0.WriteBoolean(z0rik, p1.Repeat);
		p0.WriteBoolean(z0myk, p1.ShowWatermark);
		p0.WriteString(z0wmk, p1.Text);
		p0.WritePropertyName(z0yrk);
		z0eek(p0, p1.Type);
		p0.WriteEndObject();
	}

	public static DocumentBehaviorOptions z0eek(ref Utf8JsonReader p0, DocumentBehaviorOptions p1)
	{
		if (p1 == null || p0.TokenType != JsonTokenType.StartObject)
		{
			return p1;
		}
		while (p0.Read() && p0.TokenType != JsonTokenType.EndObject)
		{
			if (p0.TokenType == JsonTokenType.PropertyName)
			{
				string text = p0.GetString();
				object obj = z0eek(text);
				if (!p0.Read())
				{
					break;
				}
				if (obj == z0tpk)
				{
					p1.AcceptDataFormats = z0eek(ref p0, WriterDataFormats.All);
				}
				else if (obj == z0gck)
				{
					p1.ActiveCheckInstallWindowsMediaPlayer = p0.z0yek(p1: false);
				}
				else if (obj == z0ark)
				{
					p1.AllowDeleteJumpOutOfField = p0.z0yek(p1: true);
				}
				else if (obj == z0mik)
				{
					p1.AllowDragContent = p0.z0yek(p1: false);
				}
				else if (obj == z0vik)
				{
					p1.AppErrorHandleMode = z0eek(ref p0, AppErrorHandleModeConsts.ThrowException);
				}
				else if (obj == z0iek)
				{
					p1.AutoAssistInsertString = p0.z0yek(p1: false);
				}
				else if (obj == z0itk)
				{
					p1.AutoAssistInsertStringDetectTextLength = p0.z0yek(0);
				}
				else if (obj == z0crk)
				{
					p1.AutoClearInvalidateCharacter = p0.z0yek(p1: true);
				}
				else if (obj == z0wpk)
				{
					p1.AutoClearTextFormatWhenPasteOrInsertContent = p0.z0yek(p1: false);
				}
				else if (obj == z0wik)
				{
					p1.AutoCreateInstanceInProperty = p0.z0yek(p1: false);
				}
				else if (obj == z0vtk)
				{
					p1.AutoDocumentValueValidate = p0.z0yek(p1: false);
				}
				else if (obj == z0xpk)
				{
					p1.AutoFixElementIDWhenInsertElements = p0.z0yek(p1: true);
				}
				else if (obj == z0ZzZzxij.m_z0cbk)
				{
					p1.AutoFocusWhenOpenDocument = p0.z0yek(p1: true);
				}
				else if (obj == z0xnk)
				{
					p1.AutoIgnoreLastEmptyPage = p0.z0yek(p1: true);
				}
				else if (obj == z0ank)
				{
					p1.AutoRefreshUserTrackInfos = p0.z0yek(p1: false);
				}
				else if (obj == z0qtk)
				{
					p1.AutoScrollToCaretWhenGotFocus = p0.z0yek(p1: false);
				}
				else if (obj == z0vyk)
				{
					p1.AutoTranslateDescString = p0.GetString();
				}
				else if (obj == z0fik)
				{
					p1.AutoTranslateSourceString = p0.GetString();
				}
				else if (obj == z0nuk)
				{
					p1.AutoUpdateButtonVisible = p0.z0yek(p1: false);
				}
				else if (obj == z0qpk)
				{
					p1.AutoUppercaseFirstCharInFirstLine = p0.z0yek(p1: false);
				}
				else if (obj == z0tuk)
				{
					p1.CheckedValueBindingHandledForTableRow = p0.z0yek(p1: true);
				}
				else if (obj == z0ZzZzxij.m_z0mbk)
				{
					p1.CloneSerialize = p0.z0yek(p1: true);
				}
				else if (obj == z0vnk)
				{
					p1.CommentEditableWhenReadonly = p0.z0yek(p1: false);
				}
				else if (obj == z0vok)
				{
					p1.CommentVisibility = z0eek(ref p0, FunctionControlVisibility.Auto);
				}
				else if (obj == z0gok)
				{
					p1.CompressLayoutForFieldBorder = p0.z0yek(p1: true);
				}
				else if (obj == z0ZzZzxij.m_z0avk)
				{
					p1.CompressXMLContent = p0.z0yek(p1: false);
				}
				else if (obj == z0kik)
				{
					p1.ContinueHeaderParagrahStyle = p0.z0yek(p1: false);
				}
				else if (obj == z0dok)
				{
					p1.CreationDataFormats = z0eek(ref p0, WriterDataFormats.All);
				}
				else if (obj == z0luk)
				{
					p1.CustomPromptForbitCheckMRID = p0.GetString();
				}
				else if (obj == z0zpk)
				{
					p1.CustomWarringCheckMRID = p0.GetString();
				}
				else if (obj == z0ZzZzxij.m_z0vbk)
				{
					p1.DataObjectRange = z0eek(ref p0, WriterDataObjectRange.OS);
				}
				else if (obj == z0ivk)
				{
					p1.DebugMode = p0.z0yek(p1: false);
				}
				else if (obj == z0drk)
				{
					p1.DefaultEditorActiveMode = z0eek(ref p0, ValueEditorActiveMode.None);
				}
				else if (obj == z0uok)
				{
					p1.DesignMode = p0.z0yek(p1: false);
				}
				else if (obj == z0dik)
				{
					p1.DisableCheckMRIDWhenMRIDIsEmptyForOuterDataObject = p0.z0yek(p1: false);
				}
				else if (obj == z0gtk)
				{
					p1.DisplayFormatToInnerValue = p0.z0yek(p1: true);
				}
				else if (obj == z0atk)
				{
					p1.DocumentTextOutputMode = z0eek(ref p0, DCDocumentTextOutputMode.Normal);
				}
				else if (obj == z0aik)
				{
					p1.DoubleClickToEditComment = p0.z0yek(p1: true);
				}
				else if (obj == z0jmk)
				{
					p1.DoubleClickToSelectWord = p0.z0yek(p1: true);
				}
				else if (obj == z0ZzZzxij.m_z0ebk)
				{
					p1.EnableCalculateControl = p0.z0yek(p1: true);
				}
				else if (obj == z0xtk)
				{
					p1.EnableCheckControlLoaded = p0.z0yek(p1: false);
				}
				else if (obj == z0opk)
				{
					p1.EnableChineseFontSizeName = p0.z0yek(p1: true);
				}
				else if (obj == z0ink)
				{
					p1.EnableCollapseSection = p0.z0yek(p1: false);
				}
				else if (obj == z0gyk)
				{
					p1.EnableCompressUserHistories = p0.z0yek(p1: true);
				}
				else if (obj == z0ZzZzxij.m_z0xbk)
				{
					p1.EnableContentChangedEventWhenLoadDocument = p0.z0yek(p1: false);
				}
				else if (obj == z0bok)
				{
					p1.EnableContentLock = p0.z0yek(p1: true);
				}
				else if (obj == z0lik)
				{
					p1.EnableControlHostAtDesignTime = p0.z0yek(p1: true);
				}
				else if (obj == z0rpk)
				{
					p1.EnableCopySource = p0.z0yek(p1: true);
				}
				else if (obj == z0bmk)
				{
					p1.EnableDataBinding = p0.z0yek(p1: true);
				}
				else if (obj == z0ynk)
				{
					p1.EnabledCache100KBImageData = p0.z0yek(p1: true);
				}
				else if (obj == z0zyk)
				{
					p1.EnabledElementEvent = p0.z0yek(p1: true);
				}
				else if (obj == z0pmk)
				{
					p1.EnableDeleteReadonlyEmptyContainer = p0.z0yek(p1: true);
				}
				else if (obj == z0ktk)
				{
					p1.EnableEditElementValue = p0.z0yek(p1: true);
				}
				else if (obj == z0ZzZzxij.m_z0hvk)
				{
					p1.EnableElementEvents = p0.z0yek(p1: true);
				}
				else if (obj == z0srk)
				{
					p1.EnableExpression = p0.z0yek(p1: true);
				}
				else if (obj == z0uuk)
				{
					p1.EnableHyperLink = p0.z0yek(p1: true);
				}
				else if (obj == z0juk)
				{
					p1.EnableKBEntryRangeMask = p0.z0yek(p1: true);
				}
				else if (obj == z0wyk)
				{
					p1.EnableLogUndo = p0.z0yek(p1: true);
				}
				else if (obj == z0frk)
				{
					p1.EnableScript = p0.z0yek(p1: true);
				}
				else if (obj == z0smk)
				{
					p1.EnableSetJumpPrintPositionWhenPreview = p0.z0yek(p1: true);
				}
				else if (obj == z0ZzZzxij.m_z0zbk)
				{
					p1.EncodingCodePageForWriteRTF = p0.z0yek(936);
				}
				else if (obj == z0wnk)
				{
					p1.ExcludeKeywords = p0.GetString();
				}
				else if (obj == z0qok)
				{
					p1.FastInputMode = p0.z0yek(p1: false);
				}
				else if (obj == z0pyk)
				{
					p1.FillCommentToUserTrackList = p0.z0yek(p1: false);
				}
				else if (obj == z0oek)
				{
					p1.ForceCollateWhenPrint = p0.z0yek(p1: false);
				}
				else if (obj == z0grk)
				{
					p1.ForceRaiseEventAfterFieldContentEdit = p0.z0yek(p1: false);
				}
				else if (obj == z0mek)
				{
					p1.FormView = z0eek(ref p0, FormViewMode.Disable);
				}
				else if (obj == z0hck)
				{
					p1.GlobalSpecifyDebugModeValue = p0.z0yek(p1: false);
				}
				else if (obj == z0jik)
				{
					p1.HandleCommandException = p0.z0yek(p1: true);
				}
				else if (obj == z0rek)
				{
					p1.IgnoreDataBindingWhenMissValue = p0.z0yek(p1: true);
				}
				else if (obj == z0yik)
				{
					p1.IgnoreTopBottomPaddingWhenGridLineLayout = p0.z0yek(p1: false);
				}
				else if (obj == z0sik)
				{
					p1.ImageCompressSaveMode = z0eek(ref p0, DCImageCompressSaveMode.Prompt);
				}
				else if (obj == z0zuk_jiejie20260327142557)
				{
					p1.ImageShapeEditorBackgroundMenuItemConfig = p0.GetString();
				}
				else if (obj == z0qnk)
				{
					p1.InsertCommentBindingUserTrack = p0.z0yek(p1: false);
				}
				else if (obj == z0pvk)
				{
					p1.InsertDocumentWithCheckMRID = z0eek(ref p0, InsertDocumentWithCheckMRIDType.None);
				}
				else if (obj == z0ZzZzxij.m_z0wbk)
				{
					p1.MaximizedPrintPreviewDialog = p0.z0yek(p1: false);
				}
				else if (obj == z0iuk)
				{
					p1.MaxTextLengthForPaste = p0.z0yek(0);
				}
				else if (obj == z0utk)
				{
					p1.MaxZoomRate = p0.z0yek(5f);
				}
				else if (obj == z0ouk)
				{
					p1.MinCountForDropdownListSpellCodeArea = p0.z0yek(4);
				}
				else if (obj == z0zok)
				{
					p1.MinImageFileSizeForConfirmCompressSaveMode = p0.z0yek(51200);
				}
				else if (obj == z0fuk)
				{
					p1.MinZoomRate = p0.z0yek(0.2f);
				}
				else if (obj == z0hnk)
				{
					p1.MoveCaretWhenDeleteFail = p0.z0yek(p1: true);
				}
				else if (obj == z0ZzZzxij.m_z0nbk)
				{
					p1.MoveFieldWhenDragWholeContent = p0.z0yek(p1: true);
				}
				else if (obj == z0jtk)
				{
					p1.MoveFocusHotKey = z0eek(ref p0, MoveFocusHotKeys.None);
				}
				else if (obj == z0fmk)
				{
					p1.NewExpressionExecuteMode = p0.z0yek(p1: true);
				}
				else if (obj == z0ook)
				{
					p1.OutputBackgroundTextToRTF = p0.z0yek(p1: true);
				}
				else if (obj == z0hok)
				{
					p1.OutputFieldBorderTextToContentText = p0.z0yek(p1: true);
				}
				else if (obj == z0oyk)
				{
					p1.OutputFormatedXMLSource = p0.z0yek(p1: true);
				}
				else if (obj == z0amk)
				{
					p1.PageLineUnderPageBreak = p0.z0yek(p1: false);
				}
				else if (obj == z0emk)
				{
					p1.ParagraphFlagFollowTableOrSection = p0.z0yek(p1: false);
				}
				else if (obj == z0lrk)
				{
					p1.ParseCrLfAsLineBreakElement = p0.z0yek(p1: false);
				}
				else if (obj == z0erk)
				{
					p1.PowerfulCommentCommand = p0.z0yek(p1: true);
				}
				else if (obj == z0jrk)
				{
					p1.PreserveClipbardDataWhenExit = p0.z0yek(p1: false);
				}
				else if (obj == z0lck)
				{
					p1.Printable = p0.z0yek(p1: true);
				}
				else if (obj == z0ltk)
				{
					p1.PromptForExcludeSystemClipboardRange = p0.z0yek(p1: true);
				}
				else if (obj == z0yek)
				{
					p1.PromptForRejectFormat = p0.z0yek(p1: true);
				}
				else if (obj == z0lmk)
				{
					p1.PromptJumpBackForSearch = p0.z0yek(p1: true);
				}
				else if (obj == z0fyk)
				{
					p1.PromptProtectedContent = z0eek(ref p0, PromptProtectedContentMode.Details);
				}
				else if (obj == z0tok)
				{
					p1.RaiseQueryListItemsWhenUserEditText = p0.z0yek(p1: false);
				}
				else if (obj == z0qvk)
				{
					p1.RemoveLastParagraphFlagWhenInsertDocument = p0.z0yek(p1: false);
				}
				else if (obj == z0syk)
				{
					p1.ResetTextFormatWhenCreateNewLine = p0.z0yek(p1: false);
				}
				else if (obj == z0ZzZzxij.m_z0obk)
				{
					p1.SaveBodyTextToXml = p0.z0yek(p1: true);
				}
				else if (obj == z0ZzZzxij.m_z0kvk)
				{
					p1.SelectionTextIncludeBackgroundText = p0.z0yek(p1: true);
				}
				else if (obj == z0kpk)
				{
					p1.SetParagraphFlagHeightUsePreElement = p0.z0yek(p1: true);
				}
				else if (obj == z0cik)
				{
					p1.ShowDebugMessage = p0.z0yek(p1: false);
				}
				else if (obj == z0dnk)
				{
					p1.ShowTooltip = p0.z0yek(p1: true);
				}
				else if (obj == z0suk)
				{
					p1.SimpleElementProperties = p0.z0yek(p1: false);
				}
				else if (obj == z0muk)
				{
					p1.SpecifyDebugMode = p0.z0yek(p1: false);
				}
				else if (obj == z0ppk)
				{
					p1.StdLablesForImageEditor = p0.GetString();
				}
				else if (obj == z0cyk)
				{
					p1.TableCellOperationDetectDistance = p0.z0yek(3);
				}
				else if (obj == z0huk)
				{
					p1.ThreeClickToSelectParagraph = p0.z0yek(p1: true);
				}
				else if (obj == z0ZzZzxij.m_z0ibk)
				{
					p1.TitleForToolTip = p0.GetString();
				}
				else if (obj == z0ZzZzxij.m_z0wvk)
				{
					p1.UseNewValueExpressionEngine = p0.z0yek(p1: true);
				}
				else if (obj == z0euk)
				{
					p1.ValidateIDRepeatMode = z0eek(ref p0, DCValidateIDRepeatMode.None);
				}
				else if (obj == z0zmk)
				{
					p1.ValidateUserIDWhenEditDeleteComment = p0.z0yek(p1: false);
				}
				else if (obj == z0npk)
				{
					p1.WeakMode = p0.z0yek(p1: false);
				}
				else if (obj == z0unk)
				{
					p1.WidelyRaiseFocusEvent = p0.z0yek(p1: false);
				}
				else if (obj == z0nvk)
				{
					p1.WordBreak = z0eek(ref p0, DCWordBreakStyle.Normal);
				}
				else if (obj == z0puk)
				{
					p1.XMLContentEncodingName = p0.GetString();
				}
				else
				{
					z0eek("DocumentBehaviorOptions", text);
				}
			}
		}
		return p1;
	}

	public static void z0eek(Utf8JsonWriter p0, DocumentSecurityOptions p1)
	{
		if (p1 == null)
		{
			throw new ArgumentNullException("instance");
		}
		if (p0 == null)
		{
			throw new ArgumentNullException("jwriter");
		}
		p0.WriteStartObject();
		p0.WriteBoolean(z0xyk, p1.AutoEnablePermissionWhenUserLogin);
		p0.WritePropertyName(z0sok);
		z0eek(p0, p1.CAMode);
		p0.WriteBoolean(z0ZzZzxij.m_z0gvk, p1.CanModifyDeleteSameLevelContent);
		p0.WriteString(z0qrk, p1.CAServerIP);
		p0.WriteNumber(z0jck, p1.CAServerPort);
		p0.WriteString(z0wrk, p1.CreatorTipFormatString);
		p0.WriteString(z0qmk, p1.DeleterTipFormatString);
		p0.WriteBoolean(z0trk, p1.EnableLogicDelete);
		p0.WriteBoolean(z0btk, p1.EnablePermission);
		p0.WriteBoolean(z0yyk, p1.PowerfulSignDocument);
		p0.WriteBoolean(z0ZzZzxij.m_z0rbk, p1.RealDeleteOwnerContent);
		p0.WriteBoolean(z0rmk, p1.ShowFlagForOnlySoftwareSign);
		p0.WriteBoolean(z0dmk, p1.ShowLogicDeletedContent);
		p0.WriteBoolean(z0ZzZzxij.m_z0qbk, p1.ShowNewContentMarkForFirstHistory);
		p0.WriteBoolean(z0ZzZzxij.m_z0jbk, p1.ShowPermissionMark);
		p0.WriteBoolean(z0ZzZzxij.m_z0evk, p1.ShowPermissionTip);
		p0.WritePropertyName(z0urk);
		z0eek(p0, p1.TrackVisibleLevel0);
		p0.WritePropertyName(z0xok);
		z0eek(p0, p1.TrackVisibleLevel1);
		p0.WritePropertyName(z0bik);
		z0eek(p0, p1.TrackVisibleLevel2);
		p0.WritePropertyName(z0cpk);
		z0eek(p0, p1.TrackVisibleLevel3);
		p0.WriteEndObject();
	}

	public static void z0eek(Utf8JsonWriter p0, ValueEditorActiveMode p1)
	{
		p0.WriteStringValue(p1.ToString());
	}

	public static InputFieldAdornTextType z0eek(ref Utf8JsonReader p0, InputFieldAdornTextType p1)
	{
		if (p0.TokenType == JsonTokenType.String)
		{
			string text = p0.GetString();
			for (int num = z0ZzZzxij.m_z0svk.Length - 1; num >= 0; num--)
			{
				if (text.Equals(z0ZzZzxij.m_z0svk[num], StringComparison.OrdinalIgnoreCase))
				{
					return (InputFieldAdornTextType)num;
				}
			}
		}
		else if (p0.TokenType == JsonTokenType.Number)
		{
			return (InputFieldAdornTextType)p0.GetInt32();
		}
		return p1;
	}

	public static void z0eek(Utf8JsonWriter p0, ValueValidateStyle p1)
	{
		if (p1 == null)
		{
			throw new ArgumentNullException("instance");
		}
		if (p0 == null)
		{
			throw new ArgumentNullException("jwriter");
		}
		p0.WriteStartObject();
		p0.WriteBoolean(z0ZzZzxij.m_z0kbk, p1.BinaryLength);
		p0.WriteBoolean(z0aok, p1.CheckDecimalDigits);
		p0.WriteBoolean(z0uek, p1.CheckMaxValue);
		p0.WriteBoolean(z0ZzZzxij.m_z0rvk, p1.CheckMinValue);
		p0.WriteString(z0vvk, p1.CustomMessage);
		p0.WriteString(z0rnk, z0ZzZzuyk.z0rek(p1.DateTimeMaxValue));
		p0.WriteString(z0ttk, z0ZzZzuyk.z0rek(p1.DateTimeMinValue));
		p0.WriteString(z0wnk, p1.ExcludeKeywords);
		p0.WriteString(z0oik, p1.IncludeKeywords);
		p0.WritePropertyName(z0qyk);
		z0eek(p0, p1.Level);
		p0.WriteNumber(z0kuk, p1.MaxDecimalDigits);
		p0.WriteNumber(z0knk, p1.MaxLength);
		p0.WriteNumber(z0bpk, p1.MaxValue);
		p0.WriteNumber(z0mpk, p1.MinLength);
		p0.WriteNumber(z0ntk, p1.MinValue);
		p0.WriteString(z0wuk, p1.Range);
		p0.WriteString(z0ZzZzxij.m_z0pbk, p1.RegExpression);
		p0.WriteBoolean(z0bvk, p1.Required);
		p0.WriteString(z0umk, p1.ValueName);
		p0.WritePropertyName(z0ipk);
		z0eek(p0, p1.ValueType);
		p0.WriteEndObject();
	}

	public static void z0eek(Utf8JsonWriter p0, FunctionControlVisibility p1)
	{
		if (p1 >= FunctionControlVisibility.Auto && (int)p1 < z0ovk.Length)
		{
			p0.WriteStringValue(z0ovk[(int)p1]);
		}
		else
		{
			p0.WriteNumberValue((int)p1);
		}
	}

	public static void z0eek(Utf8JsonWriter p0, DCRenderVisibility p1)
	{
		if (p1 >= DCRenderVisibility.Default && (int)p1 < z0ZzZzxij.m_z0dbk.Length)
		{
			p0.WriteStringValue(z0ZzZzxij.m_z0dbk[(int)p1]);
		}
		else
		{
			p0.WriteNumberValue((int)p1);
		}
	}

	public static void z0eek(Utf8JsonWriter p0, DCCAMode p1)
	{
		if (p1 >= DCCAMode.Disabled && (int)p1 < z0ZzZzxij.m_z0jvk.Length)
		{
			p0.WriteStringValue(z0ZzZzxij.m_z0jvk[(int)p1]);
		}
		else
		{
			p0.WriteNumberValue((int)p1);
		}
	}

	public static void z0eek(Utf8JsonWriter p0, ValueValidateLevel p1)
	{
		if (p1 >= ValueValidateLevel.Error && (int)p1 < z0dtk.Length)
		{
			p0.WriteStringValue(z0dtk[(int)p1]);
		}
		else
		{
			p0.WriteNumberValue((int)p1);
		}
	}

	public static void z0eek(Utf8JsonWriter p0, RenderVisibility p1)
	{
		p0.WriteStringValue(p1.ToString());
	}

	public static InsertDocumentWithCheckMRIDType z0eek(ref Utf8JsonReader p0, InsertDocumentWithCheckMRIDType p1)
	{
		if (p0.TokenType == JsonTokenType.String)
		{
			string text = p0.GetString();
			for (int num = z0tik.Length - 1; num >= 0; num--)
			{
				if (text.Equals(z0tik[num], StringComparison.OrdinalIgnoreCase))
				{
					return (InsertDocumentWithCheckMRIDType)num;
				}
			}
		}
		else if (p0.TokenType == JsonTokenType.Number)
		{
			return (InsertDocumentWithCheckMRIDType)p0.GetInt32();
		}
		return p1;
	}

	public static void z0eek(Utf8JsonWriter p0, PromptProtectedContentMode p1)
	{
		if (p1 >= PromptProtectedContentMode.None && (int)p1 < z0hrk.Length)
		{
			p0.WriteStringValue(z0hrk[(int)p1]);
		}
		else
		{
			p0.WriteNumberValue((int)p1);
		}
	}

	public static z0ZzZzsok z0eek(ref Utf8JsonReader p0, z0ZzZzsok p1)
	{
		if (p1 == null || p0.TokenType != JsonTokenType.StartObject)
		{
			return p1;
		}
		while (p0.Read() && p0.TokenType != JsonTokenType.EndObject)
		{
			if (p0.TokenType == JsonTokenType.PropertyName)
			{
				string text = p0.GetString();
				object obj = z0eek(text);
				if (!p0.Read())
				{
					break;
				}
				if (obj == z0pik)
				{
					p1.Format = p0.GetString();
				}
				else if (obj == z0xmk)
				{
					p1.NoneText = p0.GetString();
				}
				else if (obj == z0jpk)
				{
					p1.Style = z0eek(ref p0, ValueFormatStyle.None);
				}
				else
				{
					z0eek("ValueFormater", text);
				}
			}
		}
		return p1;
	}

	public static DCRenderVisibility z0eek(ref Utf8JsonReader p0, DCRenderVisibility p1)
	{
		if (p0.TokenType == JsonTokenType.String)
		{
			string text = p0.GetString();
			for (int num = z0ZzZzxij.m_z0dbk.Length - 1; num >= 0; num--)
			{
				if (text.Equals(z0ZzZzxij.m_z0dbk[num], StringComparison.OrdinalIgnoreCase))
				{
					return (DCRenderVisibility)num;
				}
			}
		}
		else if (p0.TokenType == JsonTokenType.Number)
		{
			return (DCRenderVisibility)p0.GetInt32();
		}
		return p1;
	}

	public static void z0eek(Utf8JsonWriter p0, DocumentValueValidateMode p1)
	{
		if (p1 >= DocumentValueValidateMode.None && (int)p1 < z0cnk.Length)
		{
			p0.WriteStringValue(z0cnk[(int)p1]);
		}
		else
		{
			p0.WriteNumberValue((int)p1);
		}
	}

	public static EnableState z0eek(ref Utf8JsonReader p0, EnableState p1)
	{
		if (p0.TokenType == JsonTokenType.String)
		{
			string text = p0.GetString();
			for (int num = z0kok.Length - 1; num >= 0; num--)
			{
				if (text.Equals(z0kok[num], StringComparison.OrdinalIgnoreCase))
				{
					return (EnableState)num;
				}
			}
		}
		else if (p0.TokenType == JsonTokenType.Number)
		{
			return (EnableState)p0.GetInt32();
		}
		return p1;
	}

	public static DCWordBreakStyle z0eek(ref Utf8JsonReader p0, DCWordBreakStyle p1)
	{
		if (p0.TokenType == JsonTokenType.String)
		{
			string text = p0.GetString();
			for (int num = z0gmk.Length - 1; num >= 0; num--)
			{
				if (text.Equals(z0gmk[num], StringComparison.OrdinalIgnoreCase))
				{
					return (DCWordBreakStyle)num;
				}
			}
		}
		else if (p0.TokenType == JsonTokenType.Number)
		{
			return (DCWordBreakStyle)p0.GetInt32();
		}
		return p1;
	}

	public static DCDocumentTextOutputMode z0eek(ref Utf8JsonReader p0, DCDocumentTextOutputMode p1)
	{
		if (p0.TokenType == JsonTokenType.String)
		{
			string? text = p0.GetString();
			DCDocumentTextOutputMode result = p1;
			if (Enum.TryParse<DCDocumentTextOutputMode>(text, out result))
			{
				return result;
			}
			return p1;
		}
		if (p0.TokenType == JsonTokenType.Number)
		{
			return (DCDocumentTextOutputMode)p0.GetInt32();
		}
		return p1;
	}

	public static FunctionControlVisibility z0eek(ref Utf8JsonReader p0, FunctionControlVisibility p1)
	{
		if (p0.TokenType == JsonTokenType.String)
		{
			string text = p0.GetString();
			for (int num = z0ovk.Length - 1; num >= 0; num--)
			{
				if (text.Equals(z0ovk[num], StringComparison.OrdinalIgnoreCase))
				{
					return (FunctionControlVisibility)num;
				}
			}
		}
		else if (p0.TokenType == JsonTokenType.Number)
		{
			return (FunctionControlVisibility)p0.GetInt32();
		}
		return p1;
	}

	public static void z0eek(Utf8JsonWriter p0, DCImageCompressSaveMode p1)
	{
		if (p1 >= DCImageCompressSaveMode.True && (int)p1 < z0yuk.Length)
		{
			p0.WriteStringValue(z0yuk[(int)p1]);
		}
		else
		{
			p0.WriteNumberValue((int)p1);
		}
	}

	public static void z0eek(Utf8JsonWriter p0, z0ZzZzsok p1)
	{
		if (p1 == null)
		{
			throw new ArgumentNullException("instance");
		}
		if (p0 == null)
		{
			throw new ArgumentNullException("jwriter");
		}
		p0.WriteStartObject();
		p0.WriteString(z0pik, p1.Format);
		p0.WriteString(z0xmk, p1.NoneText);
		p0.WritePropertyName(z0jpk);
		z0eek(p0, p1.Style);
		p0.WriteEndObject();
	}

	public static void z0eek(Utf8JsonWriter p0, InputFieldAdornTextType p1)
	{
		if (p1 >= InputFieldAdornTextType.Default && (int)p1 < z0ZzZzxij.m_z0svk.Length)
		{
			p0.WriteStringValue(z0ZzZzxij.m_z0svk[(int)p1]);
		}
		else
		{
			p0.WriteNumberValue((int)p1);
		}
	}

	public static void z0eek(Utf8JsonWriter p0, DocumentOptions p1)
	{
		if (p1 == null)
		{
			throw new ArgumentNullException("instance");
		}
		if (p0 == null)
		{
			throw new ArgumentNullException("jwriter");
		}
		p0.WriteStartObject();
		p0.WritePropertyName(z0enk);
		z0eek(p0, p1.BehaviorOptions);
		p0.WritePropertyName(z0eik);
		z0eek(p0, p1.EditOptions);
		p0.WritePropertyName(z0nok);
		z0eek(p0, p1.SecurityOptions);
		p0.WritePropertyName(z0mmk);
		z0eek(p0, p1.ViewOptions);
		p0.WriteEndObject();
	}

	public static void z0eek(Utf8JsonWriter p0, z0ZzZzfsh p1)
	{
		if (p1 >= (z0ZzZzfsh)0 && (int)p1 < z0mrk.Length)
		{
			p0.WriteStringValue(z0mrk[(int)p1]);
		}
		else
		{
			p0.WriteNumberValue((int)p1);
		}
	}

	public static InterpolationMode z0eek(ref Utf8JsonReader p0, InterpolationMode p1)
	{
		if (p0.TokenType == JsonTokenType.String)
		{
			string text = p0.GetString();
			if (text.Equals("Bicubic", StringComparison.OrdinalIgnoreCase))
			{
				return InterpolationMode.Bicubic;
			}
			if (text.Equals("Bilinear", StringComparison.OrdinalIgnoreCase))
			{
				return InterpolationMode.Bilinear;
			}
			if (text.Equals("Default", StringComparison.OrdinalIgnoreCase))
			{
				return InterpolationMode.Default;
			}
			if (text.Equals("High", StringComparison.OrdinalIgnoreCase))
			{
				return InterpolationMode.High;
			}
			if (text.Equals("HighQualityBicubic", StringComparison.OrdinalIgnoreCase))
			{
				return InterpolationMode.HighQualityBicubic;
			}
			if (text.Equals("HighQualityBilinear", StringComparison.OrdinalIgnoreCase))
			{
				return InterpolationMode.HighQualityBilinear;
			}
			if (text.Equals("Invalid", StringComparison.OrdinalIgnoreCase))
			{
				return InterpolationMode.Invalid;
			}
			if (text.Equals("Low", StringComparison.OrdinalIgnoreCase))
			{
				return InterpolationMode.Low;
			}
			if (text.Equals("NearestNeighbor", StringComparison.OrdinalIgnoreCase))
			{
				return InterpolationMode.NearestNeighbor;
			}
			return InterpolationMode.Default;
		}
		if (p0.TokenType == JsonTokenType.Number)
		{
			return (InterpolationMode)p0.GetInt32();
		}
		return p1;
	}

	private static object z0eek(string p0)
	{
		if (p0 != null && p0.Length > 0)
		{
			string result = null;
			if (z0ZzZzxij.m_z0znk.TryGetValue(p0, out result))
			{
				return result;
			}
		}
		return null;
	}

	public static FormViewMode z0eek(ref Utf8JsonReader p0, FormViewMode p1)
	{
		if (p0.TokenType == JsonTokenType.String)
		{
			string text = p0.GetString();
			for (int num = z0imk.Length - 1; num >= 0; num--)
			{
				if (text.Equals(z0imk[num], StringComparison.OrdinalIgnoreCase))
				{
					return (FormViewMode)num;
				}
			}
		}
		else if (p0.TokenType == JsonTokenType.Number)
		{
			return (FormViewMode)p0.GetInt32();
		}
		return p1;
	}

	public static void z0eek(Utf8JsonWriter p0, SmoothingMode p1)
	{
		p0.WriteStringValue(p1.ToString());
	}

	public static void z0eek(Utf8JsonWriter p0, DashStyle p1)
	{
		if (p1 >= DashStyle.Solid && (int)p1 < z0zrk.Length)
		{
			p0.WriteStringValue(z0zrk[(int)p1]);
		}
		else
		{
			p0.WriteNumberValue((int)p1);
		}
	}

	public static DCAdornTextVisibility z0eek(ref Utf8JsonReader p0, DCAdornTextVisibility p1)
	{
		if (p0.TokenType == JsonTokenType.String)
		{
			string text = p0.GetString();
			for (int num = z0ayk.Length - 1; num >= 0; num--)
			{
				if (text.Equals(z0ayk[num], StringComparison.OrdinalIgnoreCase))
				{
					return (DCAdornTextVisibility)num;
				}
			}
		}
		else if (p0.TokenType == JsonTokenType.Number)
		{
			return (DCAdornTextVisibility)p0.GetInt32();
		}
		return p1;
	}

	public static z0ZzZzimk z0eek(ref Utf8JsonReader p0, z0ZzZzimk p1)
	{
		if (p1 == null || p0.TokenType != JsonTokenType.StartObject)
		{
			return p1;
		}
		while (p0.Read() && p0.TokenType != JsonTokenType.EndObject)
		{
			if (p0.TokenType == JsonTokenType.PropertyName)
			{
				string text = p0.GetString();
				object obj = z0eek(text);
				if (!p0.Read())
				{
					break;
				}
				if (obj == z0hpk)
				{
					p1.Bold = p0.z0yek(p1: false);
				}
				else if (obj == z0nik)
				{
					p1.Italic = p0.z0yek(p1: false);
				}
				else if (obj == z0eok)
				{
					p1.Name = p0.GetString();
				}
				else if (obj == z0ZzZzxij.m_z0dvk)
				{
					p1.Size = p0.z0yek(9f);
				}
				else if (obj == z0guk)
				{
					p1.Strikeout = p0.z0yek(p1: false);
				}
				else if (obj == z0bek)
				{
					p1.Underline = p0.z0yek(p1: false);
				}
				else if (obj == z0dpk)
				{
					p1.Unit = z0eek(ref p0, GraphicsUnit.Point);
				}
				else
				{
					z0eek("XFontValue", text);
				}
			}
		}
		return p1;
	}

	public static ValueEditorActiveMode z0eek(ref Utf8JsonReader p0, ValueEditorActiveMode p1)
	{
		if (p0.TokenType == JsonTokenType.String)
		{
			string? text = p0.GetString();
			ValueEditorActiveMode result = p1;
			if (Enum.TryParse<ValueEditorActiveMode>(text, out result))
			{
				return result;
			}
			return p1;
		}
		if (p0.TokenType == JsonTokenType.Number)
		{
			return (ValueEditorActiveMode)p0.GetInt32();
		}
		return p1;
	}

	public static void z0eek(Utf8JsonWriter p0, DCValidateIDRepeatMode p1)
	{
		if (p1 >= DCValidateIDRepeatMode.None && (int)p1 < z0brk.Length)
		{
			p0.WriteStringValue(z0brk[(int)p1]);
		}
		else
		{
			p0.WriteNumberValue((int)p1);
		}
	}

	private static void z0eek(string p0, string p1)
	{
	}

	public static void z0eek(Utf8JsonWriter p0, ContentLayoutDirectionStyle p1)
	{
		if (p1 >= ContentLayoutDirectionStyle.Default && (int)p1 < z0ZzZzxij.m_z0abk.Length)
		{
			p0.WriteStringValue(z0ZzZzxij.m_z0abk[(int)p1]);
		}
		else
		{
			p0.WriteNumberValue((int)p1);
		}
	}

	public static void z0eek(Utf8JsonWriter p0, ValueTypeStyle p1)
	{
		if (p1 >= ValueTypeStyle.Text && (int)p1 < z0wtk.Length)
		{
			p0.WriteStringValue(z0wtk[(int)p1]);
		}
		else
		{
			p0.WriteNumberValue((int)p1);
		}
	}

	public static void z0eek(Utf8JsonWriter p0, DocumentBehaviorOptions p1)
	{
		if (p1 == null)
		{
			throw new ArgumentNullException("instance");
		}
		if (p0 == null)
		{
			throw new ArgumentNullException("jwriter");
		}
		p0.WriteStartObject();
		p0.WritePropertyName(z0tpk);
		z0eek(p0, p1.AcceptDataFormats);
		p0.WriteBoolean(z0gck, p1.ActiveCheckInstallWindowsMediaPlayer);
		p0.WriteBoolean(z0ark, p1.AllowDeleteJumpOutOfField);
		p0.WriteBoolean(z0mik, p1.AllowDragContent);
		p0.WritePropertyName(z0vik);
		z0eek(p0, p1.AppErrorHandleMode);
		p0.WriteBoolean(z0iek, p1.AutoAssistInsertString);
		p0.WriteNumber(z0itk, p1.AutoAssistInsertStringDetectTextLength);
		p0.WriteBoolean(z0crk, p1.AutoClearInvalidateCharacter);
		p0.WriteBoolean(z0wpk, p1.AutoClearTextFormatWhenPasteOrInsertContent);
		p0.WriteBoolean(z0wik, p1.AutoCreateInstanceInProperty);
		p0.WriteBoolean(z0vtk, p1.AutoDocumentValueValidate);
		p0.WriteBoolean(z0xpk, p1.AutoFixElementIDWhenInsertElements);
		p0.WriteBoolean(z0ZzZzxij.m_z0cbk, p1.AutoFocusWhenOpenDocument);
		p0.WriteBoolean(z0xnk, p1.AutoIgnoreLastEmptyPage);
		p0.WriteBoolean(z0ank, p1.AutoRefreshUserTrackInfos);
		p0.WriteBoolean(z0qtk, p1.AutoScrollToCaretWhenGotFocus);
		p0.WriteString(z0vyk, p1.AutoTranslateDescString);
		p0.WriteString(z0fik, p1.AutoTranslateSourceString);
		p0.WriteBoolean(z0nuk, p1.AutoUpdateButtonVisible);
		p0.WriteBoolean(z0qpk, p1.AutoUppercaseFirstCharInFirstLine);
		p0.WriteBoolean(z0tuk, p1.CheckedValueBindingHandledForTableRow);
		p0.WriteBoolean(z0ZzZzxij.m_z0mbk, p1.CloneSerialize);
		p0.WriteBoolean(z0vnk, p1.CommentEditableWhenReadonly);
		p0.WritePropertyName(z0vok);
		z0eek(p0, p1.CommentVisibility);
		p0.WriteBoolean(z0gok, p1.CompressLayoutForFieldBorder);
		p0.WriteBoolean(z0ZzZzxij.m_z0avk, p1.CompressXMLContent);
		p0.WriteBoolean(z0kik, p1.ContinueHeaderParagrahStyle);
		p0.WritePropertyName(z0dok);
		z0eek(p0, p1.CreationDataFormats);
		p0.WriteString(z0luk, p1.CustomPromptForbitCheckMRID);
		p0.WriteString(z0zpk, p1.CustomWarringCheckMRID);
		p0.WritePropertyName(z0ZzZzxij.m_z0vbk);
		z0eek(p0, p1.DataObjectRange);
		p0.WriteBoolean(z0ivk, p1.DebugMode);
		p0.WritePropertyName(z0drk);
		z0eek(p0, p1.DefaultEditorActiveMode);
		p0.WriteBoolean(z0uok, p1.DesignMode);
		p0.WriteBoolean(z0dik, p1.DisableCheckMRIDWhenMRIDIsEmptyForOuterDataObject);
		p0.WriteBoolean(z0gtk, p1.DisplayFormatToInnerValue);
		p0.WritePropertyName(z0atk);
		z0eek(p0, p1.DocumentTextOutputMode);
		p0.WriteBoolean(z0aik, p1.DoubleClickToEditComment);
		p0.WriteBoolean(z0jmk, p1.DoubleClickToSelectWord);
		p0.WriteBoolean(z0ZzZzxij.m_z0ebk, p1.EnableCalculateControl);
		p0.WriteBoolean(z0xtk, p1.EnableCheckControlLoaded);
		p0.WriteBoolean(z0opk, p1.EnableChineseFontSizeName);
		p0.WriteBoolean(z0ink, p1.EnableCollapseSection);
		p0.WriteBoolean(z0gyk, p1.EnableCompressUserHistories);
		p0.WriteBoolean(z0ZzZzxij.m_z0xbk, p1.EnableContentChangedEventWhenLoadDocument);
		p0.WriteBoolean(z0bok, p1.EnableContentLock);
		p0.WriteBoolean(z0lik, p1.EnableControlHostAtDesignTime);
		p0.WriteBoolean(z0rpk, p1.EnableCopySource);
		p0.WriteBoolean(z0bmk, p1.EnableDataBinding);
		p0.WriteBoolean(z0ynk, p1.EnabledCache100KBImageData);
		p0.WriteBoolean(z0zyk, p1.EnabledElementEvent);
		p0.WriteBoolean(z0pmk, p1.EnableDeleteReadonlyEmptyContainer);
		p0.WriteBoolean(z0ktk, p1.EnableEditElementValue);
		p0.WriteBoolean(z0ZzZzxij.m_z0hvk, p1.EnableElementEvents);
		p0.WriteBoolean(z0srk, p1.EnableExpression);
		p0.WriteBoolean(z0uuk, p1.EnableHyperLink);
		p0.WriteBoolean(z0juk, p1.EnableKBEntryRangeMask);
		p0.WriteBoolean(z0wyk, p1.EnableLogUndo);
		p0.WriteBoolean(z0frk, p1.EnableScript);
		p0.WriteBoolean(z0smk, p1.EnableSetJumpPrintPositionWhenPreview);
		p0.WriteNumber(z0ZzZzxij.m_z0zbk, p1.EncodingCodePageForWriteRTF);
		p0.WriteString(z0wnk, p1.ExcludeKeywords);
		p0.WriteBoolean(z0qok, p1.FastInputMode);
		p0.WriteBoolean(z0pyk, p1.FillCommentToUserTrackList);
		p0.WriteBoolean(z0oek, p1.ForceCollateWhenPrint);
		p0.WriteBoolean(z0grk, p1.ForceRaiseEventAfterFieldContentEdit);
		p0.WritePropertyName(z0mek);
		z0eek(p0, p1.FormView);
		p0.WriteBoolean(z0hck, p1.GlobalSpecifyDebugModeValue);
		p0.WriteBoolean(z0jik, p1.HandleCommandException);
		p0.WriteBoolean(z0rek, p1.IgnoreDataBindingWhenMissValue);
		p0.WriteBoolean(z0yik, p1.IgnoreTopBottomPaddingWhenGridLineLayout);
		p0.WritePropertyName(z0sik);
		z0eek(p0, p1.ImageCompressSaveMode);
		p0.WriteString(z0zuk_jiejie20260327142557, p1.ImageShapeEditorBackgroundMenuItemConfig);
		p0.WriteBoolean(z0qnk, p1.InsertCommentBindingUserTrack);
		p0.WritePropertyName(z0pvk);
		z0eek(p0, p1.InsertDocumentWithCheckMRID);
		p0.WriteBoolean(z0ZzZzxij.m_z0wbk, p1.MaximizedPrintPreviewDialog);
		p0.WriteNumber(z0iuk, p1.MaxTextLengthForPaste);
		p0.WriteNumber(z0utk, p1.MaxZoomRate);
		p0.WriteNumber(z0ouk, p1.MinCountForDropdownListSpellCodeArea);
		p0.WriteNumber(z0zok, p1.MinImageFileSizeForConfirmCompressSaveMode);
		p0.WriteNumber(z0fuk, p1.MinZoomRate);
		p0.WriteBoolean(z0hnk, p1.MoveCaretWhenDeleteFail);
		p0.WriteBoolean(z0ZzZzxij.m_z0nbk, p1.MoveFieldWhenDragWholeContent);
		p0.WritePropertyName(z0jtk);
		z0eek(p0, p1.MoveFocusHotKey);
		p0.WriteBoolean(z0fmk, p1.NewExpressionExecuteMode);
		p0.WriteBoolean(z0ook, p1.OutputBackgroundTextToRTF);
		p0.WriteBoolean(z0hok, p1.OutputFieldBorderTextToContentText);
		p0.WriteBoolean(z0oyk, p1.OutputFormatedXMLSource);
		p0.WriteBoolean(z0amk, p1.PageLineUnderPageBreak);
		p0.WriteBoolean(z0emk, p1.ParagraphFlagFollowTableOrSection);
		p0.WriteBoolean(z0lrk, p1.ParseCrLfAsLineBreakElement);
		p0.WriteBoolean(z0erk, p1.PowerfulCommentCommand);
		p0.WriteBoolean(z0jrk, p1.PreserveClipbardDataWhenExit);
		p0.WriteBoolean(z0lck, p1.Printable);
		p0.WriteBoolean(z0ltk, p1.PromptForExcludeSystemClipboardRange);
		p0.WriteBoolean(z0yek, p1.PromptForRejectFormat);
		p0.WriteBoolean(z0lmk, p1.PromptJumpBackForSearch);
		p0.WritePropertyName(z0fyk);
		z0eek(p0, p1.PromptProtectedContent);
		p0.WriteBoolean(z0tok, p1.RaiseQueryListItemsWhenUserEditText);
		p0.WriteBoolean(z0qvk, p1.RemoveLastParagraphFlagWhenInsertDocument);
		p0.WriteBoolean(z0syk, p1.ResetTextFormatWhenCreateNewLine);
		p0.WriteBoolean(z0ZzZzxij.m_z0obk, p1.SaveBodyTextToXml);
		p0.WriteBoolean(z0ZzZzxij.m_z0kvk, p1.SelectionTextIncludeBackgroundText);
		p0.WriteBoolean(z0kpk, p1.SetParagraphFlagHeightUsePreElement);
		p0.WriteBoolean(z0cik, p1.ShowDebugMessage);
		p0.WriteBoolean(z0dnk, p1.ShowTooltip);
		p0.WriteBoolean(z0suk, p1.SimpleElementProperties);
		p0.WriteBoolean(z0muk, p1.SpecifyDebugMode);
		p0.WriteString(z0ppk, p1.StdLablesForImageEditor);
		p0.WriteNumber(z0cyk, p1.TableCellOperationDetectDistance);
		p0.WriteBoolean(z0huk, p1.ThreeClickToSelectParagraph);
		p0.WriteString(z0ZzZzxij.m_z0ibk, p1.TitleForToolTip);
		p0.WriteBoolean(z0ZzZzxij.m_z0wvk, p1.UseNewValueExpressionEngine);
		p0.WritePropertyName(z0euk);
		z0eek(p0, p1.ValidateIDRepeatMode);
		p0.WriteBoolean(z0zmk, p1.ValidateUserIDWhenEditDeleteComment);
		p0.WriteBoolean(z0npk, p1.WeakMode);
		p0.WriteBoolean(z0unk, p1.WidelyRaiseFocusEvent);
		p0.WritePropertyName(z0nvk);
		z0eek(p0, p1.WordBreak);
		p0.WriteString(z0puk, p1.XMLContentEncodingName);
		p0.WriteEndObject();
	}

	public static void z0eek(Utf8JsonWriter p0, DocumentViewOptions p1)
	{
		if (p1 == null)
		{
			throw new ArgumentNullException("instance");
		}
		if (p0 == null)
		{
			throw new ArgumentNullException("jwriter");
		}
		p0.WriteStartObject();
		p0.z0yek(z0fok, p1.AdornTextBackColor);
		p0.WritePropertyName(z0jyk);
		z0eek(p0, p1.AdornTextVisibility);
		p0.z0yek(z0tek, p1.BackgroundTextColor);
		p0.WriteBoolean(z0yok, p1.BothBlackWhenPrint);
		p0.WriteString(z0dyk, p1.CommentDateFormatString);
		p0.WriteString(z0prk, p1.CommentFontName);
		p0.WriteNumber(z0ruk, p1.CommentFontSize);
		p0.WritePropertyName(z0rrk);
		z0eek(p0, p1.DefaultAdornTextType);
		p0.WritePropertyName(z0iik);
		z0eek(p0, p1.DefaultInputFieldHighlight);
		p0.z0yek(z0vmk, p1.DefaultInputFieldTextColor);
		p0.z0yek(z0fnk, p1.DefaultLineColorForImageEditor);
		p0.WriteNumber(z0onk, p1.EmphasisMarkSize);
		p0.WriteBoolean(z0fpk, p1.EnableEncryptView);
		p0.WriteBoolean(z0cuk, p1.EnableFieldTextColor);
		p0.WriteBoolean(z0iok, p1.EnableRightToLeft);
		p0.z0yek(z0nnk, p1.FieldBackColor);
		p0.z0yek(z0cok, p1.FieldBorderColor);
		p0.WriteNumber(z0ZzZzxij.m_z0lvk, p1.FieldBorderElementPixelWidth);
		p0.WritePropertyName(z0ZzZzxij.m_z0bbk);
		z0eek(p0, p1.FieldBorderPrintVisibility);
		p0.z0yek(z0ytk, p1.FieldFocusedBackColor);
		p0.z0yek(z0zek, p1.FieldHoverBackColor);
		p0.z0yek(z0ymk, p1.FieldInvalidateValueBackColor);
		p0.z0yek(z0nyk, p1.FieldInvalidateValueForeColor);
		p0.z0yek(z0quk, p1.FieldTextColor);
		p0.z0yek(z0vuk, p1.FieldTextPrintColor);
		p0.WritePropertyName(z0pnk);
		z0eek(p0, p1.GraphicsSmoothingMode);
		p0.WritePropertyName(z0ZzZzxij.m_z0gbk);
		z0eek(p0, p1.GridLineStyle);
		p0.WriteNumber(z0ztk, p1.HeaderBottomLineWidth);
		p0.WriteBoolean(z0xuk, p1.HiddenFieldBorderWhenLostFocus);
		p0.WriteBoolean(z0epk, p1.HiddenTableBorderJumpPrintPage);
		p0.WriteBoolean(z0nek, p1.HighlightProtectedContent);
		p0.WriteBoolean(z0gpk, p1.IgnoreFieldBorderWhenPrint);
		p0.WritePropertyName(z0rtk);
		z0eek(p0, p1.ImageInterpolationMode);
		p0.WritePropertyName(z0tnk);
		z0eek(p0, p1.LayoutDirection);
		p0.z0yek(z0ptk, p1.MaskColorForJumpPrint);
		p0.WriteNumber(z0jnk, p1.MinTableColumnWidth);
		p0.z0yek(z0ZzZzxij.m_z0hbk, p1.NewInputContentUnderlineColor);
		p0.z0yek(z0ZzZzxij.m_z0ubk, p1.NoneBorderColor);
		p0.z0yek(z0cvk, p1.NormalFieldBorderColor);
		p0.WriteBoolean(z0lok_jiejie20260327142557, p1.OldWhitespaceWidth);
		p0.WriteNumber(z0byk, p1.PageMarginLineLength);
		p0.WriteBoolean(z0zvk, p1.PreserveBackgroundTextWhenPrint);
		p0.WriteBoolean(z0kmk, p1.PrintBackgroundText);
		p0.WriteBoolean(z0irk, p1.PrintGridLine);
		p0.WriteBoolean(z0mvk, p1.PrintImageAltText);
		p0.z0yek(z0ZzZzxij.m_z0lbk, p1.ProtectedContentBackColor);
		p0.z0yek(z0nmk, p1.ReadonlyFieldBackColor);
		p0.z0yek(z0tyk, p1.ReadonlyFieldBorderColor);
		p0.WritePropertyName(z0otk);
		z0eek(p0, p1.SectionBorderVisibility);
		p0.z0yek(z0duk, p1.SelectionHightlightMaskColor);
		p0.WriteBoolean(z0snk, p1.ShowBackgroundCellID);
		p0.WriteBoolean(z0upk, p1.ShowCellNoneBorder);
		p0.WriteBoolean(z0ZzZzxij.m_z0fbk, p1.ShowExpressionFlag);
		p0.WriteBoolean(z0cek, p1.ShowFieldBorderElement);
		p0.WriteBoolean(z0cmk, p1.ShowFormButton);
		p0.WriteBoolean(z0uyk, p1.ShowGlobalGridLineInTableAndSection);
		p0.WriteBoolean(z0bnk, p1.ShowGrayMaskOverDisableContentParty);
		p0.WriteBoolean(z0lpk, p1.ShowGridLine);
		p0.WriteBoolean(z0zik, p1.ShowHeaderBottomLine);
		p0.WriteBoolean(z0xrk, p1.ShowInputFieldStateTag);
		p0.WriteBoolean(z0ZzZzxij.m_z0yvk, p1.ShowLineNumber);
		p0.WriteBoolean(z0htk, p1.ShowPageBreak);
		p0.WriteBoolean(z0ctk, p1.ShowPageLine);
		p0.WriteBoolean(z0apk, p1.ShowParagraphFlag);
		p0.WriteBoolean(z0ryk, p1.ShowRedErrorMessageForPaint);
		p0.WriteNumber(z0kck, p1.SpecifyExtenGridLineStep);
		p0.WriteBoolean(z0iyk, p1.SupportUG);
		p0.WritePropertyName(z0jok);
		z0eek(p0, p1.TableCellBorderVisibility);
		p0.z0yek(z0qik, p1.TagColorForModifiedField);
		p0.z0yek(z0lyk, p1.TagColorForNormalField);
		p0.z0yek(z0xek, p1.TagColorForReadonlyField);
		p0.z0yek(z0eyk, p1.TagColorForValueInvalidateField);
		p0.WritePropertyName(z0vek);
		z0eek(p0, p1.TextRenderStyle);
		p0.z0yek(z0gik, p1.UnEditableFieldBorderColor);
		p0.WriteBoolean(z0hyk, p1.ShowFieldBorderTextInTheMiddle);
		p0.WriteEndObject();
	}

	public static DCCAMode z0eek(ref Utf8JsonReader p0, DCCAMode p1)
	{
		if (p0.TokenType == JsonTokenType.String)
		{
			string text = p0.GetString();
			for (int num = z0ZzZzxij.m_z0jvk.Length - 1; num >= 0; num--)
			{
				if (text.Equals(z0ZzZzxij.m_z0jvk[num], StringComparison.OrdinalIgnoreCase))
				{
					return (DCCAMode)num;
				}
			}
		}
		else if (p0.TokenType == JsonTokenType.Number)
		{
			return (DCCAMode)p0.GetInt32();
		}
		return p1;
	}

	public static void z0eek(JsonSerializerOptions p0)
	{
		p0.Converters.Add(new z0znk());
		p0.Converters.Add(new z0lbk());
		p0.Converters.Add(new z0kbk());
		p0.Converters.Add(new z0jbk());
		p0.Converters.Add(new z0hbk());
		p0.Converters.Add(new z0gbk());
		p0.Converters.Add(new z0fbk());
		p0.Converters.Add(new z0dbk());
		p0.Converters.Add(new z0sbk());
		p0.Converters.Add(new z0abk());
		p0.Converters.Add(new z0qbk());
		p0.Converters.Add(new z0wbk());
		p0.Converters.Add(new z0ebk());
		p0.Converters.Add(new z0rbk());
		p0.Converters.Add(new z0tbk());
		p0.Converters.Add(new z0ybk());
		p0.Converters.Add(new z0ubk());
		p0.Converters.Add(new z0ibk());
		p0.Converters.Add(new z0obk());
		p0.Converters.Add(new z0pbk());
		p0.Converters.Add(new z0mbk());
		p0.Converters.Add(new z0nbk());
		p0.Converters.Add(new z0bbk());
		p0.Converters.Add(new z0vbk());
		p0.Converters.Add(new z0cbk());
		p0.Converters.Add(new z0xbk());
		p0.Converters.Add(new z0zbk());
		p0.Converters.Add(new z0lvk());
		p0.Converters.Add(new z0kvk());
		p0.Converters.Add(new z0jvk());
		p0.Converters.Add(new z0hvk());
		p0.Converters.Add(new z0gvk());
		p0.Converters.Add(new z0fvk());
		p0.Converters.Add(new z0dvk());
		p0.Converters.Add(new z0svk());
		p0.Converters.Add(new z0avk());
		p0.Converters.Add(new z0qvk_jiejie20260327142557());
		p0.Converters.Add(new z0wvk());
		p0.Converters.Add(new z0evk());
		p0.Converters.Add(new z0rvk());
		p0.Converters.Add(new z0tvk());
		p0.Converters.Add(new z0yvk());
	}

	private static Dictionary<string, string> z0eek()
	{
		return new Dictionary<string, string>
		{
			{ z0tpk, z0tpk },
			{ z0gck, z0gck },
			{ z0fok, z0fok },
			{ z0jyk, z0jyk },
			{ z0ark, z0ark },
			{ z0mik, z0mik },
			{
				z0ZzZzxij.m_z0fvk,
				z0ZzZzxij.m_z0fvk
			},
			{ z0uvk, z0uvk },
			{ z0vik, z0vik },
			{ z0iek, z0iek },
			{ z0itk, z0itk },
			{ z0crk, z0crk },
			{ z0wpk, z0wpk },
			{ z0wik, z0wik },
			{ z0vtk, z0vtk },
			{ z0xyk, z0xyk },
			{ z0xpk, z0xpk },
			{
				z0ZzZzxij.m_z0cbk,
				z0ZzZzxij.m_z0cbk
			},
			{ z0xnk, z0xnk },
			{ z0hmk, z0hmk },
			{ z0ank, z0ank },
			{ z0qtk, z0qtk },
			{ z0vyk, z0vyk },
			{ z0fik, z0fik },
			{ z0nuk, z0nuk },
			{ z0qpk, z0qpk },
			{ z0lnk, z0lnk },
			{ z0omk, z0omk },
			{ z0tek, z0tek },
			{ z0enk, z0enk },
			{
				z0ZzZzxij.m_z0kbk,
				z0ZzZzxij.m_z0kbk
			},
			{ z0hpk, z0hpk },
			{ z0yok, z0yok },
			{ z0sok, z0sok },
			{
				z0ZzZzxij.m_z0gvk,
				z0ZzZzxij.m_z0gvk
			},
			{ z0qrk, z0qrk },
			{ z0jck, z0jck },
			{ z0aok, z0aok },
			{ z0tuk, z0tuk },
			{ z0uek, z0uek },
			{
				z0ZzZzxij.m_z0rvk,
				z0ZzZzxij.m_z0rvk
			},
			{ z0krk, z0krk },
			{
				z0ZzZzxij.m_z0mbk,
				z0ZzZzxij.m_z0mbk
			},
			{ z0mnk, z0mnk },
			{ z0ftk, z0ftk },
			{ z0tmk, z0tmk },
			{ z0dyk, z0dyk },
			{ z0vnk, z0vnk },
			{ z0prk, z0prk },
			{ z0ruk, z0ruk },
			{ z0vok, z0vok },
			{ z0gok, z0gok },
			{
				z0ZzZzxij.m_z0avk,
				z0ZzZzxij.m_z0avk
			},
			{ z0kik, z0kik },
			{ z0etk, z0etk },
			{ z0auk_jiejie20260327142557, z0auk_jiejie20260327142557 },
			{ z0dok, z0dok },
			{ z0wrk, z0wrk },
			{ z0vvk, z0vvk },
			{ z0luk, z0luk },
			{ z0zpk, z0zpk },
			{
				z0ZzZzxij.m_z0vbk,
				z0ZzZzxij.m_z0vbk
			},
			{ z0rnk, z0rnk },
			{ z0ttk, z0ttk },
			{ z0ivk, z0ivk },
			{ z0rrk, z0rrk },
			{ z0drk, z0drk },
			{ z0iik, z0iik },
			{ z0vmk, z0vmk },
			{ z0fnk, z0fnk },
			{ z0nrk, z0nrk },
			{ z0xik, z0xik },
			{ z0qmk, z0qmk },
			{ z0kyk, z0kyk },
			{ z0uok, z0uok },
			{ z0dik, z0dik },
			{ z0gtk, z0gtk },
			{ z0atk, z0atk },
			{ z0aik, z0aik },
			{ z0jmk, z0jmk },
			{ z0eik, z0eik },
			{ z0onk, z0onk },
			{
				z0ZzZzxij.m_z0ebk,
				z0ZzZzxij.m_z0ebk
			},
			{ z0xtk, z0xtk },
			{ z0opk, z0opk },
			{ z0ink, z0ink },
			{ z0gyk, z0gyk },
			{
				z0ZzZzxij.m_z0xbk,
				z0ZzZzxij.m_z0xbk
			},
			{ z0bok, z0bok },
			{ z0lik, z0lik },
			{ z0rpk, z0rpk },
			{ z0rok, z0rok },
			{ z0bmk, z0bmk },
			{ z0ynk, z0ynk },
			{ z0zyk, z0zyk },
			{ z0pmk, z0pmk },
			{ z0ktk, z0ktk },
			{
				z0ZzZzxij.m_z0hvk,
				z0ZzZzxij.m_z0hvk
			},
			{ z0fpk, z0fpk },
			{ z0srk, z0srk },
			{ z0cuk, z0cuk },
			{ z0uuk, z0uuk },
			{ z0juk, z0juk },
			{ z0trk, z0trk },
			{ z0wyk, z0wyk },
			{ z0btk, z0btk },
			{ z0iok, z0iok },
			{ z0frk, z0frk },
			{ z0smk, z0smk },
			{
				z0ZzZzxij.m_z0zbk,
				z0ZzZzxij.m_z0zbk
			},
			{ z0wnk, z0wnk },
			{ z0qok, z0qok },
			{ z0nnk, z0nnk },
			{ z0cok, z0cok },
			{
				z0ZzZzxij.m_z0lvk,
				z0ZzZzxij.m_z0lvk
			},
			{
				z0ZzZzxij.m_z0bbk,
				z0ZzZzxij.m_z0bbk
			},
			{ z0ytk, z0ytk },
			{ z0zek, z0zek },
			{ z0ymk, z0ymk },
			{ z0nyk, z0nyk },
			{ z0quk, z0quk },
			{ z0vuk, z0vuk },
			{ z0pyk, z0pyk },
			{ z0pek, z0pek },
			{ z0xvk, z0xvk },
			{ z0hik, z0hik },
			{ z0oek, z0oek },
			{ z0grk, z0grk },
			{ z0pik, z0pik },
			{ z0mek, z0mek },
			{ z0hck, z0hck },
			{ z0pnk, z0pnk },
			{ z0vpk, z0vpk },
			{
				z0ZzZzxij.m_z0gbk,
				z0ZzZzxij.m_z0gbk
			},
			{ z0jik, z0jik },
			{ z0ztk, z0ztk },
			{ z0xuk, z0xuk },
			{ z0epk, z0epk },
			{ z0nek, z0nek },
			{ z0rek, z0rek },
			{ z0gpk, z0gpk },
			{ z0yik, z0yik },
			{ z0uik, z0uik },
			{ z0sik, z0sik },
			{ z0pok, z0pok },
			{ z0rtk, z0rtk },
			{ z0zuk_jiejie20260327142557, z0zuk_jiejie20260327142557 },
			{ z0oik, z0oik },
			{ z0qnk, z0qnk },
			{ z0pvk, z0pvk },
			{ z0nik, z0nik },
			{ z0gnk, z0gnk },
			{ z0tnk, z0tnk },
			{ z0qyk, z0qyk },
			{ z0ptk, z0ptk },
			{ z0kuk, z0kuk },
			{
				z0ZzZzxij.m_z0wbk,
				z0ZzZzxij.m_z0wbk
			},
			{ z0knk, z0knk },
			{ z0iuk, z0iuk },
			{ z0bpk, z0bpk },
			{ z0utk, z0utk },
			{ z0ouk, z0ouk },
			{ z0zok, z0zok },
			{ z0mpk, z0mpk },
			{ z0jnk, z0jnk },
			{ z0ntk, z0ntk },
			{ z0fuk, z0fuk },
			{ z0hnk, z0hnk },
			{
				z0ZzZzxij.m_z0nbk,
				z0ZzZzxij.m_z0nbk
			},
			{ z0jtk, z0jtk },
			{ z0eok, z0eok },
			{ z0fmk, z0fmk },
			{
				z0ZzZzxij.m_z0hbk,
				z0ZzZzxij.m_z0hbk
			},
			{
				z0ZzZzxij.m_z0ubk,
				z0ZzZzxij.m_z0ubk
			},
			{ z0xmk, z0xmk },
			{ z0cvk, z0cvk },
			{ z0lok_jiejie20260327142557, z0lok_jiejie20260327142557 },
			{ z0ook, z0ook },
			{ z0hok, z0hok },
			{ z0oyk, z0oyk },
			{ z0amk, z0amk },
			{ z0byk, z0byk },
			{ z0emk, z0emk },
			{ z0lrk, z0lrk },
			{ z0erk, z0erk },
			{ z0yyk, z0yyk },
			{ z0zvk, z0zvk },
			{ z0jrk, z0jrk },
			{ z0lck, z0lck },
			{ z0kmk, z0kmk },
			{ z0irk, z0irk },
			{ z0mvk, z0mvk },
			{ z0spk, z0spk },
			{ z0ltk, z0ltk },
			{ z0yek, z0yek },
			{ z0lmk, z0lmk },
			{ z0fyk, z0fyk },
			{
				z0ZzZzxij.m_z0lbk,
				z0ZzZzxij.m_z0lbk
			},
			{ z0tok, z0tok },
			{ z0wuk, z0wuk },
			{ z0nmk, z0nmk },
			{ z0tyk, z0tyk },
			{
				z0ZzZzxij.m_z0rbk,
				z0ZzZzxij.m_z0rbk
			},
			{
				z0ZzZzxij.m_z0pbk,
				z0ZzZzxij.m_z0pbk
			},
			{ z0qvk, z0qvk },
			{ z0rik, z0rik },
			{ z0bvk, z0bvk },
			{ z0syk, z0syk },
			{
				z0ZzZzxij.m_z0obk,
				z0ZzZzxij.m_z0obk
			},
			{ z0otk, z0otk },
			{ z0nok, z0nok },
			{ z0duk, z0duk },
			{
				z0ZzZzxij.m_z0kvk,
				z0ZzZzxij.m_z0kvk
			},
			{ z0kpk, z0kpk },
			{ z0snk, z0snk },
			{ z0upk, z0upk },
			{ z0cik, z0cik },
			{
				z0ZzZzxij.m_z0fbk,
				z0ZzZzxij.m_z0fbk
			},
			{ z0cek, z0cek },
			{ z0rmk, z0rmk },
			{ z0cmk, z0cmk },
			{ z0uyk, z0uyk },
			{ z0bnk, z0bnk },
			{ z0lpk, z0lpk },
			{ z0zik, z0zik },
			{ z0xrk, z0xrk },
			{
				z0ZzZzxij.m_z0yvk,
				z0ZzZzxij.m_z0yvk
			},
			{ z0dmk, z0dmk },
			{
				z0ZzZzxij.m_z0qbk,
				z0ZzZzxij.m_z0qbk
			},
			{ z0htk, z0htk },
			{ z0ctk, z0ctk },
			{ z0apk, z0apk },
			{
				z0ZzZzxij.m_z0jbk,
				z0ZzZzxij.m_z0jbk
			},
			{
				z0ZzZzxij.m_z0evk,
				z0ZzZzxij.m_z0evk
			},
			{ z0ryk, z0ryk },
			{ z0dnk, z0dnk },
			{ z0myk, z0myk },
			{ z0suk, z0suk },
			{
				z0ZzZzxij.m_z0dvk,
				z0ZzZzxij.m_z0dvk
			},
			{ z0muk, z0muk },
			{ z0kck, z0kck },
			{ z0ppk, z0ppk },
			{ z0guk, z0guk },
			{ z0jpk, z0jpk },
			{ z0iyk, z0iyk },
			{ z0ypk, z0ypk },
			{ z0wok, z0wok },
			{ z0jok, z0jok },
			{ z0cyk, z0cyk },
			{ z0qik, z0qik },
			{ z0lyk, z0lyk },
			{ z0xek, z0xek },
			{ z0eyk, z0eyk },
			{ z0wmk, z0wmk },
			{ z0vek, z0vek },
			{ z0huk, z0huk },
			{
				z0ZzZzxij.m_z0ibk,
				z0ZzZzxij.m_z0ibk
			},
			{ z0urk, z0urk },
			{ z0xok, z0xok },
			{ z0bik, z0bik },
			{ z0cpk, z0cpk },
			{ z0yrk, z0yrk },
			{ z0bek, z0bek },
			{ z0stk, z0stk },
			{ z0buk_jiejie20260327142557, z0buk_jiejie20260327142557 },
			{
				z0ZzZzxij.m_z0sbk,
				z0ZzZzxij.m_z0sbk
			},
			{ z0gik, z0gik },
			{ z0dpk, z0dpk },
			{
				z0ZzZzxij.m_z0wvk,
				z0ZzZzxij.m_z0wvk
			},
			{ z0euk, z0euk },
			{ z0zmk, z0zmk },
			{ z0umk, z0umk },
			{ z0ipk, z0ipk },
			{ z0mok, z0mok },
			{ z0mmk, z0mmk },
			{ z0npk, z0npk },
			{ z0unk, z0unk },
			{ z0nvk, z0nvk },
			{ z0puk, z0puk },
			{ z0hyk, z0hyk }
		};
	}

	public static void z0eek(Utf8JsonWriter p0, DCDocumentTextOutputMode p1)
	{
		p0.WriteStringValue(p1.ToString());
	}

	public static z0ZzZzpmk z0eek(ref Utf8JsonReader p0, z0ZzZzpmk p1)
	{
		if (p1 == null || p0.TokenType != JsonTokenType.StartObject)
		{
			return p1;
		}
		while (p0.Read() && p0.TokenType != JsonTokenType.EndObject)
		{
			if (p0.TokenType == JsonTokenType.PropertyName)
			{
				string text = p0.GetString();
				object obj = z0eek(text);
				if (!p0.Read())
				{
					break;
				}
				if (obj == z0pok)
				{
					p1.ImageDataBase64String = p0.GetString();
				}
				else
				{
					z0eek("XImageValue", text);
				}
			}
		}
		return p1;
	}

	public static DocumentValueValidateMode z0eek(ref Utf8JsonReader p0, DocumentValueValidateMode p1)
	{
		if (p0.TokenType == JsonTokenType.String)
		{
			string text = p0.GetString();
			for (int num = z0cnk.Length - 1; num >= 0; num--)
			{
				if (text.Equals(z0cnk[num], StringComparison.OrdinalIgnoreCase))
				{
					return (DocumentValueValidateMode)num;
				}
			}
		}
		else if (p0.TokenType == JsonTokenType.Number)
		{
			return (DocumentValueValidateMode)p0.GetInt32();
		}
		return p1;
	}

	public static WriterDataFormats z0eek(ref Utf8JsonReader p0, WriterDataFormats p1)
	{
		if (p0.TokenType == JsonTokenType.String)
		{
			string? text = p0.GetString();
			WriterDataFormats result = p1;
			if (Enum.TryParse<WriterDataFormats>(text, out result))
			{
				return result;
			}
			return p1;
		}
		if (p0.TokenType == JsonTokenType.Number)
		{
			return (WriterDataFormats)p0.GetInt32();
		}
		return p1;
	}

	public static void z0eek(Utf8JsonWriter p0, InsertDocumentWithCheckMRIDType p1)
	{
		if (p1 >= InsertDocumentWithCheckMRIDType.None && (int)p1 < z0tik.Length)
		{
			p0.WriteStringValue(z0tik[(int)p1]);
		}
		else
		{
			p0.WriteNumberValue((int)p1);
		}
	}

	public static z0ZzZzigh z0eek(ref Utf8JsonReader p0, z0ZzZzigh p1)
	{
		if (p1 == null || p0.TokenType != JsonTokenType.StartObject)
		{
			return p1;
		}
		while (p0.Read() && p0.TokenType != JsonTokenType.EndObject)
		{
			if (p0.TokenType == JsonTokenType.PropertyName)
			{
				string text = p0.GetString();
				object obj = z0eek(text);
				if (!p0.Read())
				{
					break;
				}
				if (obj == z0omk)
				{
					p1.BackgroundColor = p0.z0yek(Color.Transparent);
				}
				else if (obj == z0nrk)
				{
					p1.DeleteLineColor = p0.z0yek(Color.Red);
				}
				else if (obj == z0xik)
				{
					p1.DeleteLineNum = p0.z0yek(1);
				}
				else if (obj == z0rok)
				{
					p1.Enabled = p0.z0yek(p1: true);
				}
				else if (obj == z0stk)
				{
					p1.UnderLineColor = p0.z0yek(Color.Blue);
				}
				else if (obj == z0buk_jiejie20260327142557)
				{
					p1.UnderLineColorNum = p0.z0yek(1);
				}
				else if (obj == z0ZzZzxij.m_z0sbk)
				{
					p1.UnderLineStyle = z0eek(ref p0, TextUnderlineStyle.Single);
				}
				else
				{
					z0eek("TrackVisibleConfig", text);
				}
			}
		}
		return p1;
	}

	public static DashStyle z0eek(ref Utf8JsonReader p0, DashStyle p1)
	{
		if (p0.TokenType == JsonTokenType.String)
		{
			string text = p0.GetString();
			for (int num = z0zrk.Length - 1; num >= 0; num--)
			{
				if (text.Equals(z0zrk[num], StringComparison.OrdinalIgnoreCase))
				{
					return (DashStyle)num;
				}
			}
		}
		else if (p0.TokenType == JsonTokenType.Number)
		{
			return (DashStyle)p0.GetInt32();
		}
		return p1;
	}

	public static void z0eek(Utf8JsonWriter p0, WriterDataFormats p1)
	{
		p0.WriteStringValue(p1.ToString());
	}

	public static void z0eek(Utf8JsonWriter p0, FormViewMode p1)
	{
		if (p1 >= FormViewMode.Disable && (int)p1 < z0imk.Length)
		{
			p0.WriteStringValue(z0imk[(int)p1]);
		}
		else
		{
			p0.WriteNumberValue((int)p1);
		}
	}

	public static WriterDataObjectRange z0eek(ref Utf8JsonReader p0, WriterDataObjectRange p1)
	{
		if (p0.TokenType == JsonTokenType.String)
		{
			string text = p0.GetString();
			for (int num = z0ork_jiejie20260327142557.Length - 1; num >= 0; num--)
			{
				if (text.Equals(z0ork_jiejie20260327142557[num], StringComparison.OrdinalIgnoreCase))
				{
					return (WriterDataObjectRange)num;
				}
			}
		}
		else if (p0.TokenType == JsonTokenType.Number)
		{
			return (WriterDataObjectRange)p0.GetInt32();
		}
		return p1;
	}

	public static DocumentOptions z0eek(ref Utf8JsonReader p0, DocumentOptions p1)
	{
		if (p1 == null || p0.TokenType != JsonTokenType.StartObject)
		{
			return p1;
		}
		while (p0.Read() && p0.TokenType != JsonTokenType.EndObject)
		{
			if (p0.TokenType == JsonTokenType.PropertyName)
			{
				string text = p0.GetString();
				object obj = z0eek(text);
				if (!p0.Read())
				{
					break;
				}
				if (obj == z0enk)
				{
					p1.BehaviorOptions = z0eek(ref p0, new DocumentBehaviorOptions());
				}
				else if (obj == z0eik)
				{
					p1.EditOptions = z0eek(ref p0, new DocumentEditOptions());
				}
				else if (obj == z0nok)
				{
					p1.SecurityOptions = z0eek(ref p0, new DocumentSecurityOptions());
				}
				else if (obj == z0mmk)
				{
					p1.ViewOptions = z0eek(ref p0, new DocumentViewOptions());
				}
				else
				{
					z0eek("DocumentOptions", text);
				}
			}
		}
		return p1;
	}

	public static void z0eek(Utf8JsonWriter p0, z0ZzZzigh p1)
	{
		if (p1 == null)
		{
			throw new ArgumentNullException("instance");
		}
		if (p0 == null)
		{
			throw new ArgumentNullException("jwriter");
		}
		p0.WriteStartObject();
		p0.z0yek(z0omk, p1.BackgroundColor);
		p0.z0yek(z0nrk, p1.DeleteLineColor);
		p0.WriteNumber(z0xik, p1.DeleteLineNum);
		p0.WriteBoolean(z0rok, p1.Enabled);
		p0.z0yek(z0stk, p1.UnderLineColor);
		p0.WriteNumber(z0buk_jiejie20260327142557, p1.UnderLineColorNum);
		p0.WritePropertyName(z0ZzZzxij.m_z0sbk);
		z0eek(p0, p1.UnderLineStyle);
		p0.WriteEndObject();
	}

	public static AppErrorHandleModeConsts z0eek(ref Utf8JsonReader p0, AppErrorHandleModeConsts p1)
	{
		if (p0.TokenType == JsonTokenType.String)
		{
			string text = p0.GetString();
			for (int num = z0mtk.Length - 1; num >= 0; num--)
			{
				if (text.Equals(z0mtk[num], StringComparison.OrdinalIgnoreCase))
				{
					return (AppErrorHandleModeConsts)num;
				}
			}
		}
		else if (p0.TokenType == JsonTokenType.Number)
		{
			return (AppErrorHandleModeConsts)p0.GetInt32();
		}
		return p1;
	}

	public static z0ZzZzfsh z0eek(ref Utf8JsonReader p0, z0ZzZzfsh p1)
	{
		if (p0.TokenType == JsonTokenType.String)
		{
			string text = p0.GetString();
			for (int num = z0mrk.Length - 1; num >= 0; num--)
			{
				if (text.Equals(z0mrk[num], StringComparison.OrdinalIgnoreCase))
				{
					return (z0ZzZzfsh)num;
				}
			}
		}
		else if (p0.TokenType == JsonTokenType.Number)
		{
			return (z0ZzZzfsh)p0.GetInt32();
		}
		return p1;
	}

	public static void z0eek(Utf8JsonWriter p0, AppErrorHandleModeConsts p1)
	{
		if (p1 >= AppErrorHandleModeConsts.None && (int)p1 < z0mtk.Length)
		{
			p0.WriteStringValue(z0mtk[(int)p1]);
		}
		else
		{
			p0.WriteNumberValue((int)p1);
		}
	}
}
