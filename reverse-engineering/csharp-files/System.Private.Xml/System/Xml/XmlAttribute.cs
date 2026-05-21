using System.Diagnostics.CodeAnalysis;
using System.Xml.Schema;
using System.Xml.XPath;

namespace System.Xml;

public class XmlAttribute : XmlNode
{
	private XmlName _name;

	private XmlLinkedNode _lastChild;

	internal int LocalNameHash => _name.HashCode;

	internal XmlName XmlName
	{
		get
		{
			return _name;
		}
		set
		{
			_name = name;
		}
	}

	public override XmlNode? ParentNode => null;

	public override string Name => _name.Name;

	public override string LocalName => _name.LocalName;

	public override string NamespaceURI => _name.NamespaceURI;

	public override string Prefix => _name.Prefix;

	public override XmlNodeType NodeType => XmlNodeType.Attribute;

	public override XmlDocument OwnerDocument => _name.OwnerDocument;

	public override string Value
	{
		get
		{
			return InnerText;
		}
		[param: AllowNull]
		set
		{
			InnerText = innerText;
		}
	}

	public override IXmlSchemaInfo SchemaInfo => _name;

	public override string InnerText
	{
		set
		{
			if (PrepareOwnerElementInElementIdAttrMap())
			{
				string innerText = base.InnerText;
				base.InnerText = innerText2;
				ResetOwnerElementInElementIdAttrMap(innerText);
			}
			else
			{
				base.InnerText = innerText2;
			}
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

	public virtual bool Specified => true;

	public virtual XmlElement? OwnerElement => parentNode as XmlElement;

	public override string InnerXml
	{
		set
		{
			RemoveAll();
			XmlLoader xmlLoader = new XmlLoader();
			xmlLoader.LoadInnerXmlAttribute(this, text);
		}
	}

	public override string BaseURI
	{
		get
		{
			if (OwnerElement != null)
			{
				return OwnerElement.BaseURI;
			}
			return string.Empty;
		}
	}

	internal override string XmlLang
	{
		get
		{
			if (OwnerElement != null)
			{
				return OwnerElement.XmlLang;
			}
			return string.Empty;
		}
	}

	internal override XPathNodeType XPNodeType
	{
		get
		{
			if (IsNamespace)
			{
				return XPathNodeType.Namespace;
			}
			return XPathNodeType.Attribute;
		}
	}

	internal override string XPLocalName
	{
		get
		{
			if (_name.Prefix.Length == 0 && _name.LocalName == "xmlns")
			{
				return string.Empty;
			}
			return _name.LocalName;
		}
	}

	internal bool IsNamespace => Ref.Equal(_name.NamespaceURI, _name.OwnerDocument.strReservedXmlns);

	internal XmlAttribute(XmlName P_0, XmlDocument P_1)
		: base(P_1)
	{
		parentNode = null;
		if (!P_1.IsLoading)
		{
			XmlDocument.CheckName(P_0.Prefix);
			XmlDocument.CheckName(P_0.LocalName);
		}
		if (P_0.LocalName.Length == 0)
		{
			throw new ArgumentException("Xdom_Attr_Name");
		}
		_name = P_0;
	}

	protected internal XmlAttribute(string? P_0, string P_1, string? P_2, XmlDocument P_3)
		: this(P_3.AddAttrXmlName(P_0, P_1, P_2, null), P_3)
	{
	}

	public override XmlNode CloneNode(bool P_0)
	{
		XmlDocument ownerDocument = OwnerDocument;
		XmlAttribute xmlAttribute = ownerDocument.CreateAttribute(Prefix, LocalName, NamespaceURI);
		xmlAttribute.CopyChildren(ownerDocument, this, true);
		return xmlAttribute;
	}

	internal bool PrepareOwnerElementInElementIdAttrMap()
	{
		XmlDocument ownerDocument = OwnerDocument;
		if (ownerDocument.DtdSchemaInfo != null)
		{
			XmlElement ownerElement = OwnerElement;
			if (ownerElement != null)
			{
				return ownerElement.Attributes.PrepareParentInElementIdAttrMap(Prefix, LocalName);
			}
		}
		return false;
	}

	internal void ResetOwnerElementInElementIdAttrMap(string P_0)
	{
		OwnerElement?.Attributes.ResetParentInElementIdAttrMap(P_0, InnerText);
	}

	internal override XmlNode AppendChildForLoad(XmlNode P_0, XmlDocument P_1)
	{
		XmlNodeChangedEventArgs insertEventArgsForLoad = P_1.GetInsertEventArgsForLoad(P_0, this);
		if (insertEventArgsForLoad != null)
		{
			P_1.BeforeEvent(insertEventArgsForLoad);
		}
		XmlLinkedNode xmlLinkedNode = (XmlLinkedNode)P_0;
		if (_lastChild == null)
		{
			xmlLinkedNode.next = xmlLinkedNode;
			_lastChild = xmlLinkedNode;
			xmlLinkedNode.SetParentForLoad(this);
		}
		else
		{
			XmlLinkedNode lastChild = _lastChild;
			xmlLinkedNode.next = lastChild.next;
			lastChild.next = xmlLinkedNode;
			_lastChild = xmlLinkedNode;
			if (lastChild.IsText && xmlLinkedNode.IsText)
			{
				XmlNode.NestTextNodes(lastChild, xmlLinkedNode);
			}
			else
			{
				xmlLinkedNode.SetParentForLoad(this);
			}
		}
		if (insertEventArgsForLoad != null)
		{
			P_1.AfterEvent(insertEventArgsForLoad);
		}
		return xmlLinkedNode;
	}

	internal override bool IsValidChildType(XmlNodeType P_0)
	{
		if (P_0 != XmlNodeType.Text)
		{
			return P_0 == XmlNodeType.EntityReference;
		}
		return true;
	}

	public override XmlNode RemoveChild(XmlNode P_0)
	{
		XmlNode result;
		if (PrepareOwnerElementInElementIdAttrMap())
		{
			string innerText = InnerText;
			result = base.RemoveChild(P_0);
			ResetOwnerElementInElementIdAttrMap(innerText);
		}
		else
		{
			result = base.RemoveChild(P_0);
		}
		return result;
	}

	public override XmlNode? AppendChild(XmlNode P_0)
	{
		XmlNode result;
		if (PrepareOwnerElementInElementIdAttrMap())
		{
			string innerText = InnerText;
			result = base.AppendChild(P_0);
			ResetOwnerElementInElementIdAttrMap(innerText);
		}
		else
		{
			result = base.AppendChild(P_0);
		}
		return result;
	}

	internal override void SetParent(XmlNode P_0)
	{
		parentNode = P_0;
	}
}
