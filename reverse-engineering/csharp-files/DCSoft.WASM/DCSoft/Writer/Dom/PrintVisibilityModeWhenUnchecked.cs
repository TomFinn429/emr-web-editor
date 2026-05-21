using System.Text.Json.Serialization;

namespace DCSoft.Writer.Dom;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum PrintVisibilityModeWhenUnchecked
{
	Visible,
	HiddenCheckBoxOnly,
	HiddenAll
}
