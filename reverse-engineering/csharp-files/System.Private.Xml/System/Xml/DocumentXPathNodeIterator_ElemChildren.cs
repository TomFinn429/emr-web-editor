using System.Xml.XPath;

namespace System.Xml;

internal class DocumentXPathNodeIterator_ElemChildren : DocumentXPathNodeIterator_ElemDescendants
{
	protected string localNameAtom;

	protected string nsAtom;

	internal DocumentXPathNodeIterator_ElemChildren(DocumentXPathNavigator P_0, string P_1, string P_2)
		: base(P_0)
	{
		localNameAtom = P_1;
		nsAtom = P_2;
	}

	internal DocumentXPathNodeIterator_ElemChildren(DocumentXPathNodeIterator_ElemChildren P_0)
		: base(P_0)
	{
		localNameAtom = P_0.localNameAtom;
		nsAtom = P_0.nsAtom;
	}

	public override XPathNodeIterator Clone()
	{
		return new DocumentXPathNodeIterator_ElemChildren(this);
	}

	protected override bool Match(XmlNode P_0)
	{
		if (Ref.Equal(P_0.LocalName, localNameAtom))
		{
			return Ref.Equal(P_0.NamespaceURI, nsAtom);
		}
		return false;
	}
}
