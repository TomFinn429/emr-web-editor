using System.Text.Json.Serialization;

namespace DCSoft.Writer;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum InputValueSource
{
	Clipboard,
	UI,
	DragDrop,
	Unknow
}
