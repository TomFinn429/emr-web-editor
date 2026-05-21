using System.Text.Json.Serialization;

namespace DCSoft.Writer;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum DCVisibleState
{
	Visible,
	Hidden,
	Default,
	AlwaysVisible
}
