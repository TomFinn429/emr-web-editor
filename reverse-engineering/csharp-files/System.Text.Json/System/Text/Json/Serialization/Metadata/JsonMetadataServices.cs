using System.ComponentModel;
using System.Text.Json.Serialization.Converters;

namespace System.Text.Json.Serialization.Metadata;

[EditorBrowsable(EditorBrowsableState.Never)]
public static class JsonMetadataServices
{
	private static JsonConverter<bool> s_booleanConverter;

	private static JsonConverter<byte[]> s_byteArrayConverter;

	private static JsonConverter<byte> s_byteConverter;

	private static JsonConverter<char> s_charConverter;

	private static JsonConverter<DateTime> s_dateTimeConverter;

	private static JsonConverter<DateTimeOffset> s_dateTimeOffsetConverter;

	private static JsonConverter<DateOnly> s_dateOnlyConverter;

	private static JsonConverter<TimeOnly> s_timeOnlyConverter;

	private static JsonConverter<decimal> s_decimalConverter;

	private static JsonConverter<double> s_doubleConverter;

	private static JsonConverter<Guid> s_guidConverter;

	private static JsonConverter<short> s_int16Converter;

	private static JsonConverter<int> s_int32Converter;

	private static JsonConverter<long> s_int64Converter;

	private static JsonConverter<JsonElement> s_jsonElementConverter;

	private static JsonConverter<JsonDocument> s_jsonDocumentConverter;

	private static JsonConverter<object> s_objectConverter;

	private static JsonConverter<float> s_singleConverter;

	private static JsonConverter<sbyte> s_sbyteConverter;

	private static JsonConverter<string> s_stringConverter;

	private static JsonConverter<TimeSpan> s_timeSpanConverter;

	private static JsonConverter<ushort> s_uint16Converter;

	private static JsonConverter<uint> s_uint32Converter;

	private static JsonConverter<ulong> s_uint64Converter;

	private static JsonConverter<Uri> s_uriConverter;

	private static JsonConverter<Version> s_versionConverter;

	public static JsonConverter<bool> BooleanConverter => s_booleanConverter ?? (s_booleanConverter = new BooleanConverter());

	public static JsonConverter<byte[]> ByteArrayConverter => s_byteArrayConverter ?? (s_byteArrayConverter = new ByteArrayConverter());

	public static JsonConverter<byte> ByteConverter => s_byteConverter ?? (s_byteConverter = new ByteConverter());

	public static JsonConverter<char> CharConverter => s_charConverter ?? (s_charConverter = new CharConverter());

	public static JsonConverter<DateTime> DateTimeConverter => s_dateTimeConverter ?? (s_dateTimeConverter = new DateTimeConverter());

	public static JsonConverter<DateTimeOffset> DateTimeOffsetConverter => s_dateTimeOffsetConverter ?? (s_dateTimeOffsetConverter = new DateTimeOffsetConverter());

	public static JsonConverter<DateOnly> DateOnlyConverter => s_dateOnlyConverter ?? (s_dateOnlyConverter = new DateOnlyConverter());

	public static JsonConverter<TimeOnly> TimeOnlyConverter => s_timeOnlyConverter ?? (s_timeOnlyConverter = new TimeOnlyConverter());

	public static JsonConverter<decimal> DecimalConverter => s_decimalConverter ?? (s_decimalConverter = new DecimalConverter());

	public static JsonConverter<double> DoubleConverter => s_doubleConverter ?? (s_doubleConverter = new DoubleConverter());

	public static JsonConverter<Guid> GuidConverter => s_guidConverter ?? (s_guidConverter = new GuidConverter());

	public static JsonConverter<short> Int16Converter => s_int16Converter ?? (s_int16Converter = new Int16Converter());

	public static JsonConverter<int> Int32Converter => s_int32Converter ?? (s_int32Converter = new Int32Converter());

	public static JsonConverter<long> Int64Converter => s_int64Converter ?? (s_int64Converter = new Int64Converter());

	public static JsonConverter<JsonElement> JsonElementConverter => s_jsonElementConverter ?? (s_jsonElementConverter = new JsonElementConverter());

	public static JsonConverter<JsonDocument> JsonDocumentConverter => s_jsonDocumentConverter ?? (s_jsonDocumentConverter = new JsonDocumentConverter());

	public static JsonConverter<object?> ObjectConverter => s_objectConverter ?? (s_objectConverter = new ObjectConverter());

	public static JsonConverter<float> SingleConverter => s_singleConverter ?? (s_singleConverter = new SingleConverter());

	[CLSCompliant(false)]
	public static JsonConverter<sbyte> SByteConverter => s_sbyteConverter ?? (s_sbyteConverter = new SByteConverter());

	public static JsonConverter<string> StringConverter => s_stringConverter ?? (s_stringConverter = new StringConverter());

	public static JsonConverter<TimeSpan> TimeSpanConverter => s_timeSpanConverter ?? (s_timeSpanConverter = new TimeSpanConverter());

	[CLSCompliant(false)]
	public static JsonConverter<ushort> UInt16Converter => s_uint16Converter ?? (s_uint16Converter = new UInt16Converter());

	[CLSCompliant(false)]
	public static JsonConverter<uint> UInt32Converter => s_uint32Converter ?? (s_uint32Converter = new UInt32Converter());

	[CLSCompliant(false)]
	public static JsonConverter<ulong> UInt64Converter => s_uint64Converter ?? (s_uint64Converter = new UInt64Converter());

	public static JsonConverter<Uri> UriConverter => s_uriConverter ?? (s_uriConverter = new UriConverter());

	public static JsonConverter<Version> VersionConverter => s_versionConverter ?? (s_versionConverter = new VersionConverter());
}
