using System.Text.Json.Serialization;

namespace DCSoft.Common;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum ValueTypeStyle
{
	Text,
	Integer,
	Numeric,
	Date,
	Time,
	DateTime,
	RegExpress
}
