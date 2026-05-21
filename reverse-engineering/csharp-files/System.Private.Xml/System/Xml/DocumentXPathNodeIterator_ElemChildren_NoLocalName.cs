using System.Xml.XPath;

namespace System.Xml;

internal class DocumentXPathNodeIterator_ElemChildren_NoLocalName : DocumentXPathNodeIterator_ElemDescendants
{
	private readonly string _nsAtom;

	internal DocumentXPathNodeIterator_ElemChildren_NoLocalName(DocumentXPathNavigator P_0, string P_1)
		: base(P_0)
	{
		_nsAtom = P_1;
	}

	internal DocumentXPathNodeIterator_ElemChildren_NoLocalName(DocumentXPathNodeIterator_ElemChildren_NoLocalName P_0)
		: base(P_0)
	{
		_nsAtom = P_0._nsAtom;
	}

	public override XPathNodeIterator Clone()
	{
		return new DocumentXPathNodeIterator_ElemChildren_NoLocalName(this);
	}

	protected override bool Match(XmlNode P_0)
	{
		return Ref.Equal(P_0.NamespaceURI, _nsAtom);
	}
}
