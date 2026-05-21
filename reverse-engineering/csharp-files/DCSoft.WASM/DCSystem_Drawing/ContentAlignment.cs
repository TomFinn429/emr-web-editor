using System.Text.Json.Serialization;

namespace DCSystem_Drawing;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum ContentAlignment
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
