using System.Text.Json.Serialization;

namespace DCSoft.Common;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum ValueValidateLevel
{
	Error,
	Warring,
	Info
}
