using System;
using System.Text.Json.Serialization;

namespace DCSoft.Writer;

[JsonConverter(typeof(JsonStringEnumConverter))]
[Flags]
public enum WriterDataFormats
{
	None = 0,
	Text = 1,
	RTF = 2,
	Html = 4,
	XML = 8,
	Image = 0x20,
	CommandFormat = 0x40,
	FileSource = 0x80,
	KBEntry = 0x100,
	All = 0xFFF
}
