using System.Xml.XPath;

namespace System.Xml;

internal class DocumentXPathNodeIterator_AllElemChildren : DocumentXPathNodeIterator_ElemDescendants
{
	internal DocumentXPathNodeIterator_AllElemChildren(DocumentXPathNavigator P_0)
		: base(P_0)
	{
	}

	internal DocumentXPathNodeIterator_AllElemChildren(DocumentXPathNodeIterator_AllElemChildren P_0)
		: base(P_0)
	{
	}

	public override XPathNodeIterator Clone()
	{
		return new DocumentXPathNodeIterator_AllElemChildren(this);
	}

	protected override bool Match(XmlNode P_0)
	{
		return P_0.NodeType == XmlNodeType.Element;
	}
}
