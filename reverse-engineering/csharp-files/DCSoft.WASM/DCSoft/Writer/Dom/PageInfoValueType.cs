using System.Text.Json.Serialization;

namespace DCSoft.Writer.Dom;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum PageInfoValueType
{
	PageIndex,
	NumOfPages,
	LocalPageIndex,
	LocalNumOfPages
}
