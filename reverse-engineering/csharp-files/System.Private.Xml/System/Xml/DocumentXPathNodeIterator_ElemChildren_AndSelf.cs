using System.Xml.XPath;

namespace System.Xml;

internal sealed class DocumentXPathNodeIterator_ElemChildren_AndSelf : DocumentXPathNodeIterator_ElemChildren
{
	internal DocumentXPathNodeIterator_ElemChildren_AndSelf(DocumentXPathNavigator P_0, string P_1, string P_2)
		: base(P_0, P_1, P_2)
	{
	}

	internal DocumentXPathNodeIterator_ElemChildren_AndSelf(DocumentXPathNodeIterator_ElemChildren_AndSelf P_0)
		: base(P_0)
	{
	}

	public override XPathNodeIterator Clone()
	{
		return new DocumentXPathNodeIterator_ElemChildren_AndSelf(this);
	}

	public override bool MoveNext()
	{
		if (CurrentPosition == 0)
		{
			DocumentXPathNavigator documentXPathNavigator = (DocumentXPathNavigator)Current;
			XmlNode xmlNode = (XmlNode)documentXPathNavigator.UnderlyingObject;
			if (xmlNode.NodeType == XmlNodeType.Element && Match(xmlNode))
			{
				SetPosition(1);
				return true;
			}
		}
		return base.MoveNext();
	}
}
