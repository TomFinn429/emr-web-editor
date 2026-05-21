using System.Text.Json.Serialization;

namespace DCSystem_Drawing.Drawing2D;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum DashCap
{
	Flat,
	Round,
	Triangle
}
