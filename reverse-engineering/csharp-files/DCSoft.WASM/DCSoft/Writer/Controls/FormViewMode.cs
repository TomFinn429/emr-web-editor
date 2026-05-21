using System.Text.Json.Serialization;

namespace DCSoft.Writer.Controls;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum FormViewMode
{
	Disable,
	Normal,
	Strict
}
