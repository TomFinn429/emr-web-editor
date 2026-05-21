using System.Text.Json.Serialization;

namespace DCSoft.Drawing;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum DocumentContentAlignment
{
	Left,
	Center,
	Right,
	Justify,
	Distribute
}
