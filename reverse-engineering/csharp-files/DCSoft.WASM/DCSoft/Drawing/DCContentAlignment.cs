using System.Text.Json.Serialization;

namespace DCSoft.Drawing;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum DCContentAlignment
{
	TopLeft,
	TopCenter,
	TopRight,
	MiddleLeft,
	MiddleCenter,
	MiddleRight,
	BottomLeft,
	BottomCenter,
	BottomRight
}
