using System;

namespace DCSoft.Writer;

[Flags]
public enum ValueEditorActiveMode
{
	None = 0,
	Default = 1,
	Program = 2,
	F2 = 4,
	GotFocus = 8,
	MouseDblClick = 0x10,
	MouseClick = 0x20,
	MouseRightClick = 0x40,
	Enter = 0x80
}
