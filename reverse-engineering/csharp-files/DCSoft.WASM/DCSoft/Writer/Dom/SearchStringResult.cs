namespace DCSoft.Writer.Dom;

public class SearchStringResult
{
	private readonly int _ElementsLength;

	private readonly string _Text;

	private readonly XTextContainerElement _ContainerElement;

	private readonly XTextCharElement _FirstElement;

	public string Text => _Text;

	public int ElementsLength => _ElementsLength;

	public XTextContainerElement ContainerElement => _ContainerElement;

	public XTextCharElement FirstElement => _FirstElement;

	public bool Select()
	{
		XTextDocumentContentElement xTextDocumentContentElement = _FirstElement.z0qek();
		if (xTextDocumentContentElement != null)
		{
			int num = xTextDocumentContentElement.z0frk().z0lrk(_FirstElement);
			if (num >= 0)
			{
				xTextDocumentContentElement.z0sr();
				xTextDocumentContentElement.z0uek(num, _ElementsLength);
				return true;
			}
		}
		return false;
	}

	internal SearchStringResult(XTextContainerElement container, XTextCharElement firstElement, int elementLength, string text)
	{
		_ContainerElement = container;
		_FirstElement = firstElement;
		_ElementsLength = elementLength;
		_Text = text;
	}
}
