using System.Text.Json.Serialization;

namespace DCSoft.Printing;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum DCGutterStyle
{
	Left,
	Top,
	Right
}
