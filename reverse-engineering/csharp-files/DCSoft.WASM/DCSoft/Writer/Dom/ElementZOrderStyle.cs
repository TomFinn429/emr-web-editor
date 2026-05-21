using System.Text.Json.Serialization;

namespace DCSoft.Writer.Dom;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum ElementZOrderStyle
{
	Normal,
	UnderText,
	InFrontOfText
}
