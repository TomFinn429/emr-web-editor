using System.Text.Json.Serialization;

namespace DCSoft.Printing;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum HeaderFooterFlagVisible
{
	None,
	Header,
	Footer,
	HeaderFooter
}
