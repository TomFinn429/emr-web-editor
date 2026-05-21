using System;

namespace DCSoft.Writer.Dom;

[Flags]
public enum ElementType
{
	None = 0,
	Text = 1,
	Field = 2,
	InputField = 4,
	Table = 8,
	TableRow = 0x10,
	TableColumn = 0x20,
	TableCell = 0x40,
	Object = 0x80,
	LineBreak = 0x100,
	PageBreak = 0x200,
	ParagraphFlag = 0x400,
	CheckRadioBox = 0x800,
	CheckBox = 0x1000,
	Image = 0x2000,
	Document = 0x4000,
	Button = 0x8000,
	Container = 0x10000,
	All = 0xFFFFFF
}
