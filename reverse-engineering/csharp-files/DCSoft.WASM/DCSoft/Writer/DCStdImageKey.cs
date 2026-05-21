using System.Text.Json.Serialization;

namespace DCSoft.Writer;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum DCStdImageKey
{
	None,
	CheckBoxChecked,
	CheckBoxUnchecked,
	RadioBoxChecked,
	RadioBoxUnchecked,
	ParagraphFlagLeftToRight,
	ParagraphFlagRightToLeft,
	Linebreak,
	DragHandle,
	SystemCheckBoxChecked,
	SystemCheckBoxUnchecked,
	SystemRadioBoxChecked,
	SystemRadioBoxUnchecked,
	Collapse,
	Expand,
	RuleDownButton,
	RuleUpButton,
	Max
}
