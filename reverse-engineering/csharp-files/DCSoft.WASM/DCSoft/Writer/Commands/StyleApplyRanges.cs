using System;

namespace DCSoft.Writer.Commands;

[Flags]
public enum StyleApplyRanges
{
	None = 0,
	Text = 1,
	Field = 2,
	Paragraph = 4,
	Cell = 8,
	Row = 0x10,
	Table = 0x20,
	Section = 0x40
}
