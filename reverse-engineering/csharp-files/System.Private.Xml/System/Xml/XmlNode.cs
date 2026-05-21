using System.Collections;
using System.Globalization;
using System.Text;
using System.Xml.Schema;
using System.Xml.XPath;

namespace System.Xml;

public abstract class XmlNode : ICloneable, IEnumerable, IXPathNavigable
{
	internal XmlNode parentNode;

	public abstract string Name { get; }

	public virtual string? Value
	{
		get
		{
			return null;
		}
		set
		{
			throw new InvalidOperationException(System.SR.Format(CultureInfo.InvariantCulture, "Xdom_Node_SetVal", NodeType.ToString()));
		}
	}

	public abstract XmlNodeType NodeType { get; }

	public virtual XmlNode? ParentNode
	{
		get
		{
			if (parentNode.NodeType != XmlNodeType.Document)
			{
				return parentNode;
			}
			if (parentNode.FirstChild is XmlLinkedNode xmlLinkedNode)
			{
				XmlLinkedNode xmlLinkedNode2 = xmlLinkedNode;
				do
				{
					if (xmlLinkedNode2 == this)
					{
						return parentNode;
					}
					xmlLinkedNode2 = xmlLinkedNode2.next;
				}
				while (xmlLinkedNode2 != null && xmlLinkedNode2 != xmlLinkedNode);
			}
			return null;
		}
	}

	public virtual XmlNodeList ChildNodes => new XmlChildNodes(this);

	public virtual XmlNode? PreviousSibling => null;

	public virtual XmlNode? NextSibling => null;

	public virtual XmlAttributeCollection? Attributes => null;

	public virtual XmlDocument? OwnerDocument
	{
		get
		{
			if (parentNode.NodeType == XmlNodeType.Document)
			{
				return (XmlDocument)parentNode;
			}
			return parentNode.OwnerDocument;
		}
	}

	public virtual XmlNode? FirstChild => LastNode?.next;

	public virtual XmlNode? LastChild => LastNode;

	internal virtual bool IsContainer => false;

	internal virtual XmlLinkedNode? LastNode
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public virtual bool HasChildNodes => LastNode != null;

	public virtual string NamespaceURI => string.Empty;

	public virtual string Prefix => string.Empty;

	public abstract string LocalName { get; }

	public virtual bool IsReadOnly => HasReadOnlyParent(this);

	public virtual string InnerText
	{
		get
		{
			XmlNode firstChild = FirstChild;
			if (firstChild == null)
			{
				return string.Empty;
			}
			if (firstChild.NextSibling == null)
			{
				XmlNodeType nodeType = firstChild.NodeType;
				if ((uint)(nodeType - 3) <= 1u || (uint)(nodeType - 13) <= 1u)
				{
					return firstChild.Value;
				}
			}
			StringBuilder stringBuilder = System.Text.StringBuilderCache.Acquire();
			AppendChildText(stringBuilder);
			return System.Text.StringBuilderCache.GetStringAndRelease(stringBuilder);
		}
		set
		{
			XmlNode firstChild = FirstChild;
			if (firstChild != null && firstChild.NextSibling == null && firstChild.NodeType == XmlNodeType.Text)
			{
				firstChild.Value = text;
				return;
			}
			RemoveAll();
			AppendChild(OwnerDocument.CreateTextNode(text));
		}
	}

	public virtual string InnerXml
	{
		set
		{
			throw new InvalidOperationException("Xdom_Set_InnerXml");
		}
	}

	public virtual IXmlSchemaInfo SchemaInfo => XmlDocument.NotKnownSchemaInfo;

	public virtual string BaseURI
	{
		get
		{
			for (XmlNode xmlNode = ParentNode; xmlNode != null; xmlNode = xmlNode.ParentNode)
			{
				switch (xmlNode.NodeType)
				{
				case XmlNodeType.EntityReference:
					return ((XmlEntityReference)xmlNode).ChildBaseURI;
				case XmlNodeType.Attribute:
				case XmlNodeType.Entity:
				case XmlNodeType.Document:
					return xmlNode.BaseURI;
				}
			}
			return string.Empty;
		}
	}

	public virtual XmlElement? this[string P_0]
	{
		get
		{
			for (XmlNode xmlNode = FirstChild; xmlNode != null; xmlNode = xmlNode.NextSibling)
			{
				if (xmlNode.NodeType == XmlNodeType.Element && xmlNode.Name == P_0)
				{
					return (XmlElement)xmlNode;
				}
			}
			return null;
		}
	}

	internal virtual string XmlLang
	{
		get
		{
			XmlNode xmlNode = this;
			do
			{
				if (xmlNode is XmlElement xmlElement && xmlElement.HasAttribute("xml:lang"))
				{
					return xmlElement.GetAttribute("xml:lang");
				}
				xmlNode = xmlNode.ParentNode;
			}
			while (xmlNode != null);
			return string.Empty;
		}
	}

	internal virtual XPathNodeType XPNodeType => (XPathNodeType)(-1);

	internal virtual string XPLocalName => string.Empty;

	internal virtual bool IsText => false;

	public virtual XmlNode? PreviousText => null;

	internal XmlNode()
	{
	}

	internal XmlNode(XmlDocument P_0)
	{
		if (P_0 == null)
		{
			throw new ArgumentException("Xdom_Node_Null_Doc");
		}
		parentNode = P_0;
	}

	public virtual XPathNavigator? CreateNavigator()
	{
		if (this is XmlDocument xmlDocument)
		{
			return xmlDocument.CreateNavigator(this);
		}
		XmlDocument ownerDocument = OwnerDocument;
		return ownerDocument.CreateNavigator(this);
	}

	public XmlNode? SelectSingleNode(string P_0)
	{
		XPathNavigator xPathNavigator = CreateNavigator();
		if (xPathNavigator != null)
		{
			XPathNodeIterator xPathNodeIterator = xPathNavigator.Select(P_0);
			if (xPathNodeIterator.MoveNext())
			{
				return ((IHasXmlNode)xPathNodeIterator.Current).GetNode();
			}
		}
		return null;
	}

	public XmlNodeList? SelectNodes(string P_0)
	{
		XPathNavigator xPathNavigator = CreateNavigator();
		if (xPathNavigator == null)
		{
			return null;
		}
		return new XPathNodeList(xPathNavigator.Select(P_0));
	}

	internal bool AncestorNode(XmlNode P_0)
	{
		XmlNode xmlNode = ParentNode;
		while (xmlNode != null && xmlNode != this)
		{
			if (xmlNode == P_0)
			{
				return true;
			}
			xmlNode = xmlNode.ParentNode;
		}
		return false;
	}

	internal bool IsConnected()
	{
		XmlNode xmlNode = ParentNode;
		while (xmlNode != null && xmlNode.NodeType != XmlNodeType.Document)
		{
			xmlNode = xmlNode.ParentNode;
		}
		return xmlNode != null;
	}

	public virtual XmlNode RemoveChild(XmlNode P_0)
	{
		if (!IsContainer)
		{
			throw new InvalidOperationException("Xdom_Node_Remove_Contain");
		}
		if (P_0.ParentNode != this)
		{
			throw new ArgumentException("Xdom_Node_Remove_Child");
		}
		XmlLinkedNode xmlLinkedNode = (XmlLinkedNode)P_0;
		string value = xmlLinkedNode.Value;
		XmlNodeChangedEventArgs eventArgs = GetEventArgs(xmlLinkedNode, this, null, value, value, XmlNodeChangedAction.Remove);
		if (eventArgs != null)
		{
			BeforeEvent(eventArgs);
		}
		XmlLinkedNode lastNode = LastNode;
		if (xmlLinkedNode == FirstChild)
		{
			if (xmlLinkedNode == lastNode)
			{
				LastNode = null;
				xmlLinkedNode.next = null;
				xmlLinkedNode.SetParent(null);
			}
			else
			{
				XmlLinkedNode next = xmlLinkedNode.next;
				if (next.IsText && xmlLinkedNode.IsText)
				{
					UnnestTextNodes(xmlLinkedNode, next);
				}
				lastNode.next = next;
				xmlLinkedNode.next = null;
				xmlLinkedNode.SetParent(null);
			}
		}
		else if (xmlLinkedNode == lastNode)
		{
			XmlLinkedNode xmlLinkedNode2 = (XmlLinkedNode)xmlLinkedNode.PreviousSibling;
			xmlLinkedNode2.next = xmlLinkedNode.next;
			LastNode = xmlLinkedNode2;
			xmlLinkedNode.next = null;
			xmlLinkedNode.SetParent(null);
		}
		else
		{
			XmlLinkedNode xmlLinkedNode3 = (XmlLinkedNode)xmlLinkedNode.PreviousSibling;
			XmlLinkedNode next2 = xmlLinkedNode.next;
			if (next2.IsText)
			{
				if (xmlLinkedNode3.IsText)
				{
					NestTextNodes(xmlLinkedNode3, next2);
				}
				else if (xmlLinkedNode.IsText)
				{
					UnnestTextNodes(xmlLinkedNode, next2);
				}
			}
			xmlLinkedNode3.next = next2;
			xmlLinkedNode.next = null;
			xmlLinkedNode.SetParent(null);
		}
		if (eventArgs != null)
		{
			AfterEvent(eventArgs);
		}
		return P_0;
	}

	public virtual XmlNode? AppendChild(XmlNode P_0)
	{
		XmlDocument xmlDocument = OwnerDocument ?? (this as XmlDocument);
		if (!IsContainer)
		{
			throw new InvalidOperationException("Xdom_Node_Insert_Contain");
		}
		if (this == P_0 || AncestorNode(P_0))
		{
			throw new ArgumentException("Xdom_Node_Insert_Child");
		}
		P_0.ParentNode?.RemoveChild(P_0);
		XmlDocument ownerDocument = P_0.OwnerDocument;
		if (ownerDocument != null && ownerDocument != xmlDocument && ownerDocument != this)
		{
			throw new ArgumentException("Xdom_Node_Insert_Context");
		}
		if (P_0.NodeType == XmlNodeType.DocumentFragment)
		{
			XmlNode firstChild = P_0.FirstChild;
			XmlNode xmlNode = firstChild;
			while (xmlNode != null)
			{
				XmlNode nextSibling = xmlNode.NextSibling;
				P_0.RemoveChild(xmlNode);
				AppendChild(xmlNode);
				xmlNode = nextSibling;
			}
			return firstChild;
		}
		if (!(P_0 is XmlLinkedNode) || !IsValidChildType(P_0.NodeType))
		{
			throw new InvalidOperationException("Xdom_Node_Insert_TypeConflict");
		}
		if (!CanInsertAfter(P_0, LastChild))
		{
			throw new InvalidOperationException("Xdom_Node_Insert_Location");
		}
		string value = P_0.Value;
		XmlNodeChangedEventArgs eventArgs = GetEventArgs(P_0, P_0.ParentNode, this, value, value, XmlNodeChangedAction.Insert);
		if (eventArgs != null)
		{
			BeforeEvent(eventArgs);
		}
		XmlLinkedNode lastNode = LastNode;
		XmlLinkedNode xmlLinkedNode = (XmlLinkedNode)P_0;
		if (lastNode == null)
		{
			xmlLinkedNode.next = xmlLinkedNode;
			LastNode = xmlLinkedNode;
			xmlLinkedNode.SetParent(this);
		}
		else
		{
			xmlLinkedNode.next = lastNode.next;
			lastNode.next = xmlLinkedNode;
			LastNode = xmlLinkedNode;
			xmlLinkedNode.SetParent(this);
			if (lastNode.IsText && xmlLinkedNode.IsText)
			{
				NestTextNodes(lastNode, xmlLinkedNode);
			}
		}
		if (eventArgs != null)
		{
			AfterEvent(eventArgs);
		}
		return xmlLinkedNode;
	}

	internal virtual XmlNode AppendChildForLoad(XmlNode P_0, XmlDocument P_1)
	{
		XmlNodeChangedEventArgs insertEventArgsForLoad = P_1.GetInsertEventArgsForLoad(P_0, this);
		if (insertEventArgsForLoad != null)
		{
			P_1.BeforeEvent(insertEventArgsForLoad);
		}
		XmlLinkedNode lastNode = LastNode;
		XmlLinkedNode xmlLinkedNode = (XmlLinkedNode)P_0;
		if (lastNode == null)
		{
			xmlLinkedNode.next = xmlLinkedNode;
			LastNode = xmlLinkedNode;
			xmlLinkedNode.SetParentForLoad(this);
		}
		else
		{
			xmlLinkedNode.next = lastNode.next;
			lastNode.next = xmlLinkedNode;
			LastNode = xmlLinkedNode;
			if (lastNode.IsText && xmlLinkedNode.IsText)
			{
				NestTextNodes(lastNode, xmlLinkedNode);
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

	internal virtual bool IsValidChildType(XmlNodeType P_0)
	{
		return false;
	}

	internal virtual bool CanInsertAfter(XmlNode P_0, XmlNode P_1)
	{
		return true;
	}

	public abstract XmlNode CloneNode(bool P_0);

	internal virtual void CopyChildren(XmlDocument P_0, XmlNode P_1, bool P_2)
	{
		for (XmlNode xmlNode = P_1.FirstChild; xmlNode != null; xmlNode = xmlNode.NextSibling)
		{
			AppendChildForLoad(xmlNode.CloneNode(P_2), P_0);
		}
	}

	internal static bool HasReadOnlyParent(XmlNode P_0)
	{
		while (P_0 != null)
		{
			switch (P_0.NodeType)
			{
			case XmlNodeType.EntityReference:
			case XmlNodeType.Entity:
				return true;
			case XmlNodeType.Attribute:
				P_0 = ((XmlAttribute)P_0).OwnerElement;
				break;
			default:
				P_0 = P_0.ParentNode;
				break;
			}
		}
		return false;
	}

	object ICloneable.Clone()
	{
		return CloneNode(true);
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return new XmlChildEnumerator(this);
	}

	private void AppendChildText(StringBuilder P_0)
	{
		for (XmlNode xmlNode = FirstChild; xmlNode != null; xmlNode = xmlNode.NextSibling)
		{
			if (xmlNode.FirstChild == null)
			{
				if (xmlNode.NodeType == XmlNodeType.Text || xmlNode.NodeType == XmlNodeType.CDATA || xmlNode.NodeType == XmlNodeType.Whitespace || xmlNode.NodeType == XmlNodeType.SignificantWhitespace)
				{
					P_0.Append(xmlNode.InnerText);
				}
			}
			else
			{
				xmlNode.AppendChildText(P_0);
			}
		}
	}

	public virtual void RemoveAll()
	{
		XmlNode xmlNode = FirstChild;
		while (xmlNode != null)
		{
			XmlNode nextSibling = xmlNode.NextSibling;
			RemoveChild(xmlNode);
			xmlNode = nextSibling;
		}
	}

	internal virtual void SetParent(XmlNode P_0)
	{
		if (P_0 == null)
		{
			parentNode = OwnerDocument;
		}
		else
		{
			parentNode = P_0;
		}
	}

	internal virtual void SetParentForLoad(XmlNode P_0)
	{
		parentNode = P_0;
	}

	internal virtual XmlNode FindChild(XmlNodeType P_0)
	{
		for (XmlNode xmlNode = FirstChild; xmlNode != null; xmlNode = xmlNode.NextSibling)
		{
			if (xmlNode.NodeType == P_0)
			{
				return xmlNode;
			}
		}
		return null;
	}

	internal virtual XmlNodeChangedEventArgs GetEventArgs(XmlNode P_0, XmlNode P_1, XmlNode P_2, string P_3, string P_4, XmlNodeChangedAction P_5)
	{
		XmlDocument ownerDocument = OwnerDocument;
		if (ownerDocument != null)
		{
			if (!ownerDocument.IsLoading && ((P_2 != null && P_2.IsReadOnly) || (P_1 != null && P_1.IsReadOnly)))
			{
				throw new InvalidOperationException("Xdom_Node_Modify_ReadOnly");
			}
			return ownerDocument.GetEventArgs(P_0, P_1, P_2, P_3, P_4, P_5);
		}
		return null;
	}

	internal virtual void BeforeEvent(XmlNodeChangedEventArgs P_0)
	{
		if (P_0 != null)
		{
			OwnerDocument.BeforeEvent(P_0);
		}
	}

	internal virtual void AfterEvent(XmlNodeChangedEventArgs P_0)
	{
		if (P_0 != null)
		{
			OwnerDocument.AfterEvent(P_0);
		}
	}

	internal static void NestTextNodes(XmlNode P_0, XmlNode P_1)
	{
		P_1.parentNode = P_0;
	}

	internal static void UnnestTextNodes(XmlNode P_0, XmlNode P_1)
	{
		P_1.parentNode = P_0.ParentNode;
	}
}
