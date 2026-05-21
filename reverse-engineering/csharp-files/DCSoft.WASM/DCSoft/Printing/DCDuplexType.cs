using System.Text.Json.Serialization;

namespace DCSoft.Printing;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum DCDuplexType
{
	NoSpecify,
	Default,
	Horizontal,
	Simplex,
	Vertical
}
