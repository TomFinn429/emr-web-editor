using System.Text.Json.Serialization;

namespace DCSoft.Writer;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum ContentReadonlyState
{
	True,
	False,
	Inherit
}
