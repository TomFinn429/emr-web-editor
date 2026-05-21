using System.Text.Json.Serialization;

namespace DCSoft.Drawing;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum CharacterCircleStyles
{
	None,
	Circle,
	Rectangle
}
