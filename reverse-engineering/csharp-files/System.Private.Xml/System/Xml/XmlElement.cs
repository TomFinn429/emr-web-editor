using System.Xml.Schema;
using System.Xml.XPath;

namespace System.Xml;

public class XmlElement : XmlLinkedNode
{
	private XmlName _name;

	private XmlAttributeCollection _attributes;

	private XmlLinkedNode _lastChild;

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

	public override string Name => _name.Name;

	public override string LocalName => _name.LocalName;

	public override string NamespaceURI => _name.NamespaceURI;

	public override string Prefix => _name.Prefix;

	public override XmlNodeType NodeType => XmlNodeType.Element;

	public override XmlNode? ParentNode => parentNode;

	public override XmlDocument OwnerDocument => _name.OwnerDocument;

	internal override bool IsContainer => true;

	public bool IsEmpty
	{
		get
		{
			return _lastChild == this;
		}
		set
		{
			if (flag)
			{
				if (_lastChild != this)
				{
					RemoveAllChildren();
					_lastChild = this;
				}
			}
			else if (_lastChild == this)
			{
				_lastChild = null;
			}
		}
	}

	internal override XmlLinkedNode? LastNode
	{
		get
		{
			if (_lastChild != this)
			{
				return _lastChild;
			}
			return null;
		}
		set
		{
			_lastChild = lastChild;
		}
	}

	public override XmlAttributeCollection Attributes
	{
		get
		{
			if (_attributes == null)
			{
				lock (OwnerDocument.objLock)
				{
					if (_attributes == null)
					{
						_attributes = new XmlAttributeCollection(this);
					}
				}
			}
			return _attributes;
		}
	}

	public virtual bool HasAttributes
	{
		get
		{
			if (_attributes == null)
			{
				return false;
			}
			return _attributes.Count > 0;
		}
	}

	public override IXmlSchemaInfo SchemaInfo => _name;

	public override string InnerXml
	{
		set
		{
			RemoveAllChildren();
			XmlLoader xmlLoader = new XmlLoader();
			xmlLoader.LoadInnerXmlElement(this, text);
		}
	}

	public override string InnerText
	{
		get
		{
			return base.InnerText;
		}
		set
		{
			XmlLinkedNode lastNode = LastNode;
			if (lastNode != null && lastNode.NodeType == XmlNodeType.Text && lastNode.next == lastNode)
			{
				lastNode.Value = text;
				return;
			}
			RemoveAllChildren();
			AppendChild(OwnerDocument.CreateTextNode(text));
		}
	}

	public override XmlNode? NextSibling
	{
		get
		{
			if (parentNode != null && parentNode.LastNode != this)
			{
				return next;
			}
			return null;
		}
	}

	internal override XPathNodeType XPNodeType => XPathNodeType.Element;

	internal override string XPLocalName => LocalName;

	internal XmlElement(XmlName P_0, bool P_1, XmlDocument P_2)
		: base(P_2)
	{
		parentNode = null;
		if (!P_2.IsLoading)
		{
			XmlDocument.CheckName(P_0.Prefix);
			XmlDocument.CheckName(P_0.LocalName);
		}
		if (P_0.LocalName.Length == 0)
		{
			throw new ArgumentException("Xdom_Empty_LocalName");
		}
		_name = P_0;
		if (P_1)
		{
			_lastChild = this;
		}
	}

	protected internal XmlElement(string? P_0, string P_1, string? P_2, XmlDocument P_3)
		: this(P_3.AddXmlName(P_0, P_1, P_2, null), true, P_3)
	{
	}

	public override XmlNode CloneNode(bool P_0)
	{
		XmlDocument ownerDocument = OwnerDocument;
		bool isLoading = ownerDocument.IsLoading;
		ownerDocument.IsLoading = true;
		XmlElement xmlElement = ownerDocument.CreateElement(Prefix, LocalName, NamespaceURI);
		ownerDocument.IsLoading = isLoading;
		if (xmlElement.IsEmpty != IsEmpty)
		{
			xmlElement.IsEmpty = IsEmpty;
		}
		if (HasAttributes)
		{
			foreach (XmlAttribute attribute in Attributes)
			{
				XmlAttribute xmlAttribute2 = (XmlAttribute)attribute.CloneNode(true);
				if (xmlAttribute2 is XmlUnspecifiedAttribute xmlUnspecifiedAttribute && !attribute.Specified)
				{
					xmlUnspecifiedAttribute.SetSpecified(false);
				}
				xmlElement.Attributes.InternalAppendAttribute(xmlAttribute2);
			}
		}
		if (P_0)
		{
			xmlElement.CopyChildren(ownerDocument, this, P_0);
		}
		return xmlElement;
	}

	internal override XmlNode AppendChildForLoad(XmlNode P_0, XmlDocument P_1)
	{
		XmlNodeChangedEventArgs insertEventArgsForLoad = P_1.GetInsertEventArgsForLoad(P_0, this);
		if (insertEventArgsForLoad != null)
		{
			P_1.BeforeEvent(insertEventArgsForLoad);
		}
		XmlLinkedNode xmlLinkedNode = (XmlLinkedNode)P_0;
		if (_lastChild == null || _lastChild == this)
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
		default:
			return false;
		}
	}

	public virtual string GetAttribute(string P_0)
	{
		XmlAttribute attributeNode = GetAttributeNode(P_0);
		if (attributeNode != null)
		{
			return attributeNode.Value;
		}
		return string.Empty;
	}

	public virtual XmlAttribute? GetAttributeNode(string P_0)
	{
		if (HasAttributes)
		{
			return Attributes[P_0];
		}
		return null;
	}

	public virtual XmlAttribute? SetAttributeNode(XmlAttribute P_0)
	{
		if (P_0.OwnerElement != null)
		{
			throw new InvalidOperationException("Xdom_Attr_InUse");
		}
		return (XmlAttribute)Attributes.SetNamedItem(P_0);
	}

	public virtual XmlAttribute? GetAttributeNode(string P_0, string? P_1)
	{
		if (HasAttributes)
		{
			return Attributes[P_0, P_1];
		}
		return null;
	}

	public virtual bool HasAttribute(string P_0)
	{
		return GetAttributeNode(P_0) != null;
	}

	public virtual void RemoveAllAttributes()
	{
		if (HasAttributes)
		{
			_attributes.RemoveAll();
		}
	}

	public override void RemoveAll()
	{
		base.RemoveAll();
		RemoveAllAttributes();
	}

	internal void RemoveAllChildren()
	{
		base.RemoveAll();
	}

	internal override void SetParent(XmlNode P_0)
	{
		parentNode = P_0;
	}
}
