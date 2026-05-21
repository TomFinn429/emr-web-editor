using System;
using System.Text.Json.Serialization;

namespace DCSoft.Drawing;

[Flags]
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum RenderVisibility
{
	Hidden = 0,
	Paint = 1,
	Print = 2,
	PDF = 4,
	All = 7
}
