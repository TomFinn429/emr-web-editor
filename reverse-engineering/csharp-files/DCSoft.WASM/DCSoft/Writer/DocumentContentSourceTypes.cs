using System.Text.Json.Serialization;

namespace DCSoft.Writer;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum DocumentContentSourceTypes
{
	Unknown,
	None,
	NewFile,
	TextReader,
	Stream,
	File
}
