using System;

namespace DCSoft.Writer.Commands;

[Flags]
public enum PrintPreviewZoomRate
{
	Zooom10 = 0,
	Zoom25 = 1,
	Zoom50 = 2,
	Zoom75 = 3,
	Zoom100 = 4,
	Zoom150 = 5,
	Zoom250 = 6,
	Zoom500 = 7
}
