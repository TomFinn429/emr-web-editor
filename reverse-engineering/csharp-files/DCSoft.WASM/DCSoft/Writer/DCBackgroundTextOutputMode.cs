using System.Text.Json.Serialization;

namespace DCSoft.Writer;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum DCBackgroundTextOutputMode
{
	None,
	Whitespace,
	Output,
	Underline
}
