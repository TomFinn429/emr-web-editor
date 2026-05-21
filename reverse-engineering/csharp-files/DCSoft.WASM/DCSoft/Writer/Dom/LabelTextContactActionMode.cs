using System.Text.Json.Serialization;

namespace DCSoft.Writer.Dom;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum LabelTextContactActionMode
{
	Disable,
	Normal,
	FirstSectionInPage,
	LastSectionInPage,
	TableRow,
	FirstTableRowInPage,
	LastTableRowInPage
}
