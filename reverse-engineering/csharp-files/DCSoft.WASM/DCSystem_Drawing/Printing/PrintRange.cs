using System.Text.Json.Serialization;

namespace DCSystem_Drawing.Printing;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum PrintRange
{
	AllPages,
	SomePages,
	Selection,
	CurrentPage
}
