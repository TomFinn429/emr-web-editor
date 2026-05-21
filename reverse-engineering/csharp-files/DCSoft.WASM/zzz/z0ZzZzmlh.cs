using DCSoft.Writer.Dom;

namespace zzz;

internal class z0ZzZzmlh
{
	public void z0eek(XTextElementList p0)
	{
		int count = p0.Count;
		XTextElement[] array = ((zzz.z0ZzZzkuk<XTextElement>)p0).z0krk();
		for (int i = 0; i < count; i++)
		{
			XTextElement xTextElement = array[i];
			if (xTextElement is XTextContainerElement xTextContainerElement)
			{
				if (xTextContainerElement is XTextContentElement)
				{
					z0eek((XTextContentElement)xTextContainerElement);
					if (xTextContainerElement.z0crk())
					{
						z0eek(xTextContainerElement.z0be());
					}
				}
				else if (xTextContainerElement is XTextTableElement xTextTableElement)
				{
					XTextElement[] array2 = ((zzz.z0ZzZzkuk<XTextElement>)xTextTableElement.z0stk()).z0krk();
					int count2 = xTextTableElement.z0stk().Count;
					for (int j = 0; j < count2; j++)
					{
						XTextTableRowElement obj = (XTextTableRowElement)array2[j];
						XTextElement[] array3 = ((zzz.z0ZzZzkuk<XTextElement>)obj.z0rek()).z0krk();
						int count3 = obj.z0rek().Count;
						for (int k = 0; k < count3; k++)
						{
							XTextTableCellElement xTextTableCellElement = (XTextTableCellElement)array3[k];
							z0eek(xTextTableCellElement);
							if (((XTextContainerElement)xTextTableCellElement).z0crk())
							{
								z0eek(xTextTableCellElement.z0be());
							}
						}
					}
				}
			}
			_ = xTextElement is XTextContentElement;
		}
	}

	public virtual void z0eek(XTextContentElement p0)
	{
	}
}
