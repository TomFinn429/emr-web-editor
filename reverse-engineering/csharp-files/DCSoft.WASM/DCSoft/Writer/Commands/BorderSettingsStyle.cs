using System;

namespace DCSoft.Writer.Commands;

[Flags]
public enum BorderSettingsStyle
{
	None = 0,
	Rectangle = 1,
	Both = 2,
	Custom = 3
}
