using System.Text.Json.Serialization;

namespace DCSoft.Writer;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum MoveUnit
{
	Character,
	Word,
	Line,
	Paragraph,
	Cell
}
