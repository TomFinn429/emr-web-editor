using System.Xml.XPath;

namespace System.Xml;

public class XmlDocumentFragment : XmlNode
{
	private XmlLinkedNode _lastChild;

	public override string Name => OwnerDocument.strDocumentFragmentName;

	public override string LocalName => OwnerDocument.strDocumentFragmentName;

	public override XmlNodeType NodeType => XmlNodeType.DocumentFragment;

	public override XmlNode? ParentNode => null;

	public override XmlDocument OwnerDocument => (XmlDocument)parentNode;

	public override string InnerXml
	{
		set
		{
			RemoveAll();
			XmlLoader xmlLoader = new XmlLoader();
			xmlLoader.ParsePartialContent(this, text, XmlNodeType.Element);
		}
	}

	internal override bool IsContainer => true;

	internal override XmlLinkedNode? LastNode
	{
		get
		{
			return _lastChild;
		}
		set
		{
			_lastChild = lastChild;
		}
	}

	internal override XPathNodeType XPNodeType => XPathNodeType.Root;

	protected internal XmlDocumentFragment(XmlDocument P_0)
	{
		if (P_0 == null)
		{
			throw new ArgumentException("Xdom_Node_Null_Doc");
		}
		parentNode = P_0;
	}

	public override XmlNode CloneNode(bool P_0)
	{
		XmlDocument ownerDocument = OwnerDocument;
		XmlDocumentFragment xmlDocumentFragment = ownerDocument.CreateDocumentFragment();
		if (P_0)
		{
			xmlDocumentFragment.CopyChildren(ownerDocument, this, P_0);
		}
		return xmlDocumentFragment;
	}

	internal override bool IsValidChildType(XmlNodeType P_0)
	{
		switch (P_0)
		{
		case XmlNodeType.Element:
		case XmlNodeType.Text:
		case XmlNodeType.CDATA:
		case XmlNodeType.EntityReference:
		case XmlNodeType.ProcessingInstruction:
		case XmlNodeType.Comment:
		case XmlNodeType.Whitespace:
		case XmlNodeType.SignificantWhitespace:
			return true;
		case XmlNodeType.XmlDeclaration:
		{
			XmlNode firstChild = FirstChild;
			if (firstChild == null || firstChild.NodeType != XmlNodeType.XmlDeclaration)
			{
				return true;
			}
			return false;
		}
		default:
			return false;
		}
	}

	internal override bool CanInsertAfter(XmlNode P_0, XmlNode P_1)
	{
		if (P_0.NodeType == XmlNodeType.XmlDeclaration)
		{
			if (P_1 == null)
			{
				return LastNode == null;
			}
			return false;
		}
		return true;
	}
}
