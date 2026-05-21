using System;

namespace DCSoft.Writer;

[Flags]
public enum DCDocumentTextOutputMode
{
	Normal = 0,
	IncludeHeader = 1,
	IncludeFooter = 2,
	IncludeBackgroundText = 4,
	IncludeBorderText = 8,
	IncludeHiddenText = 0x10
}
