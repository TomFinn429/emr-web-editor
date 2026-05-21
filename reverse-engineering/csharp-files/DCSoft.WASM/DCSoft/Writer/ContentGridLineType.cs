using System.Text.Json.Serialization;

namespace DCSoft.Writer;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum ContentGridLineType
{
	None,
	Display,
	ExtentToBottom
}
