using System.Text.Json.Serialization;

namespace DCSoft.Drawing;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum FormButtonStyle
{
	None,
	Auto,
	Button,
	FloatButton,
	ComboBoxButton,
	DateTimePicker
}
