using System.Text.Json.Serialization;

namespace DCSoft.Writer;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum InputValueType
{
	Text,
	RTF,
	Html,
	Image,
	FileName,
	Dom
}
