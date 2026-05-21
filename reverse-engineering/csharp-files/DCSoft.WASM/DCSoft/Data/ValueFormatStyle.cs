using System.Text.Json.Serialization;

namespace DCSoft.Data;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum ValueFormatStyle
{
	None,
	Numeric,
	Currency,
	DateTime,
	String,
	SpecifyLength,
	Boolean,
	Percent
}
