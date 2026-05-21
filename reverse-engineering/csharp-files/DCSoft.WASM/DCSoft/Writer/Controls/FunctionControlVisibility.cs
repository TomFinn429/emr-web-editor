using System.Text.Json.Serialization;

namespace DCSoft.Writer.Controls;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum FunctionControlVisibility
{
	Auto,
	Visible,
	Hide
}
