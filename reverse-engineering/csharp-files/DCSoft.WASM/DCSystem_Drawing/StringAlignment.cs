using System.Text.Json.Serialization;

namespace DCSystem_Drawing;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum StringAlignment
{
	Near,
	Center,
	Far
}
