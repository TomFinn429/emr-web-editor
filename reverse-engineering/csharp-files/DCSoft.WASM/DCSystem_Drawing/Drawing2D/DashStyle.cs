using System.Text.Json.Serialization;

namespace DCSystem_Drawing.Drawing2D;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum DashStyle
{
	Solid,
	Dash,
	Dot,
	DashDot,
	DashDotDot,
	Custom
}
