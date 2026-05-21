using System.Text.Json.Serialization;

namespace DCSoft.Writer.Dom;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum InputFieldAdornTextType
{
	Default,
	DataSource,
	ToolTip,
	ValidateMessage,
	ID,
	Name,
	TabIndex
}
