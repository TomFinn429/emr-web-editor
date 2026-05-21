using System.Text.Json.Serialization;

namespace DCSoft.Drawing;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum TextUnderlineStyle
{
	None,
	Single,
	Thick,
	Dash,
	Dot,
	DashDot,
	DashDotDot,
	Double,
	Wavy,
	WavyDouble,
	WavyHeavy
}
