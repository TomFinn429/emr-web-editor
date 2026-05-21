using System;
using System.Text.Json.Serialization;

namespace DCSoft.Drawing;

[JsonConverter(typeof(JsonStringEnumConverter))]
[Flags]
public enum PageTitlePosition
{
	TopLeft = 1,
	TopCenter = 2,
	TopRight = 4,
	BottomLeft = 8,
	BottomCenter = 0x10,
	BottomRight = 0x20
}
