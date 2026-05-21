using System.Text.Json.Serialization;

namespace DCSoft.Printing;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum DCPrintMode
{
	Normal,
	OddPage,
	EvenPage,
	ManualDuplex,
	CurrentPage
}
