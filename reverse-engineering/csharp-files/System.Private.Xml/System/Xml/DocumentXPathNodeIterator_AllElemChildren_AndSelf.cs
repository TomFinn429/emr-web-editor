using System.Xml.XPath;

namespace System.Xml;

internal sealed class DocumentXPathNodeIterator_AllElemChildren_AndSelf : DocumentXPathNodeIterator_AllElemChildren
{
	internal DocumentXPathNodeIterator_AllElemChildren_AndSelf(DocumentXPathNavigator P_0)
		: base(P_0)
	{
	}

	internal DocumentXPathNodeIterator_AllElemChildren_AndSelf(DocumentXPathNodeIterator_AllElemChildren_AndSelf P_0)
		: base(P_0)
	{
	}

	public override XPathNodeIterator Clone()
	{
		return new DocumentXPathNodeIterator_AllElemChildren_AndSelf(this);
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
