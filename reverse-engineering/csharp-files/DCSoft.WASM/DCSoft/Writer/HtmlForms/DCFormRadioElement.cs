using DCSoft.Writer.Dom;

namespace DCSoft.Writer.HtmlForms;

public sealed class DCFormRadioElement : DCFormCheckBoxElementBase
{
	public DCFormRadioElement(XTextRadioBoxElement element)
		: base(element)
	{
	}

	public DCFormRadioElement()
	{
	}
}
