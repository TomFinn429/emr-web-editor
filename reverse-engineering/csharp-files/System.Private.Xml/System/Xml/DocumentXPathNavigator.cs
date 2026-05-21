using System.Diagnostics.CodeAnalysis;
using System.Text;
using System.Xml.Schema;
using System.Xml.XPath;

namespace System.Xml;

internal sealed class DocumentXPathNavigator : XPathNavigator, IHasXmlNode
{
	private readonly XmlDocument _document;

	private XmlNode _source;

	private int _attributeIndex;

	private XmlElement _namespaceParent;

	public override XmlNameTable NameTable => _document.NameTable;

	public override XPathNodeType NodeType
	{
		get
		{
			CalibrateText();
			return _source.XPNodeType;
		}
	}

	public override string LocalName => _source.XPLocalName;

	public override string NamespaceURI
	{
		get
		{
			if (_source is XmlAttribute { IsNamespace: not false })
			{
				return string.Empty;
			}
			return _source.NamespaceURI;
		}
	}

	public override string Name
	{
		get
		{
			switch (_source.NodeType)
			{
			case XmlNodeType.Element:
			case XmlNodeType.ProcessingInstruction:
				return _source.Name;
			case XmlNodeType.Attribute:
				if (((XmlAttribute)_source).IsNamespace)
				{
					string localName = _source.LocalName;
					if (Ref.Equal(localName, _document.strXmlns))
					{
						return string.Empty;
					}
					return localName;
				}
				return _source.Name;
			default:
				return string.Empty;
			}
		}
	}

	public override string Value
	{
		get
		{
			switch (_source.NodeType)
			{
			case XmlNodeType.Element:
			case XmlNodeType.DocumentFragment:
				return _source.InnerText;
			case XmlNodeType.Document:
				return ValueDocument;
			case XmlNodeType.Text:
			case XmlNodeType.CDATA:
			case XmlNodeType.Whitespace:
			case XmlNodeType.SignificantWhitespace:
				return ValueText;
			default:
				return _source.Value;
			}
		}
	}

	private string ValueDocument
	{
		get
		{
			XmlElement documentElement = _document.DocumentElement;
			if (documentElement != null)
			{
				return documentElement.InnerText;
			}
			return string.Empty;
		}
	}

	private string ValueText
	{
		get
		{
			CalibrateText();
			string text = _source.Value;
			XmlNode xmlNode = NextSibling(_source);
			if (xmlNode != null && xmlNode.IsText)
			{
				StringBuilder stringBuilder = new StringBuilder(text);
				do
				{
					stringBuilder.Append(xmlNode.Value);
					xmlNode = NextSibling(xmlNode);
				}
				while (xmlNode != null && xmlNode.IsText);
				text = stringBuilder.ToString();
			}
			return text;
		}
	}

	public override string BaseURI => _source.BaseURI;

	public override string XmlLang => _source.XmlLang;

	public override object UnderlyingObject
	{
		get
		{
			CalibrateText();
			return _source;
		}
	}

	public override IXmlSchemaInfo SchemaInfo => _source.SchemaInfo;

	public DocumentXPathNavigator(XmlDocument P_0, XmlNode P_1)
	{
		_document = P_0;
		ResetPosition(P_1);
	}

	public DocumentXPathNavigator(DocumentXPathNavigator P_0)
	{
		_document = P_0._document;
		_source = P_0._source;
		_attributeIndex = P_0._attributeIndex;
		_namespaceParent = P_0._namespaceParent;
	}

	public override XPathNavigator Clone()
	{
		return new DocumentXPathNavigator(this);
	}

	public override bool MoveToAttribute(string P_0, string P_1)
	{
		if (_source is XmlElement { HasAttributes: not false } xmlElement)
		{
			XmlAttributeCollection attributes = xmlElement.Attributes;
			for (int i = 0; i < attributes.Count; i++)
			{
				XmlAttribute xmlAttribute = attributes[i];
				if (xmlAttribute.LocalName == P_0 && xmlAttribute.NamespaceURI == P_1)
				{
					if (!xmlAttribute.IsNamespace)
					{
						_source = xmlAttribute;
						_attributeIndex = i;
						return true;
					}
					return false;
				}
			}
		}
		return false;
	}

	public override bool MoveToFirstAttribute()
	{
		if (_source is XmlElement { HasAttributes: not false } xmlElement)
		{
			XmlAttributeCollection attributes = xmlElement.Attributes;
			for (int i = 0; i < attributes.Count; i++)
			{
				XmlAttribute xmlAttribute = attributes[i];
				if (!xmlAttribute.IsNamespace)
				{
					_source = xmlAttribute;
					_attributeIndex = i;
					return true;
				}
			}
		}
		return false;
	}

	public override bool MoveToNextAttribute()
	{
		if (!(_source is XmlAttribute { IsNamespace: false } xmlAttribute))
		{
			return false;
		}
		if (!CheckAttributePosition(xmlAttribute, out var xmlAttributeCollection, _attributeIndex) && !ResetAttributePosition(xmlAttribute, xmlAttributeCollection, out _attributeIndex))
		{
			return false;
		}
		for (int i = _attributeIndex + 1; i < xmlAttributeCollection.Count; i++)
		{
			XmlAttribute xmlAttribute2 = xmlAttributeCollection[i];
			if (!xmlAttribute2.IsNamespace)
			{
				_source = xmlAttribute2;
				_attributeIndex = i;
				return true;
			}
		}
		return false;
	}

	public override bool MoveToNamespace(string P_0)
	{
		if (P_0 == _document.strXmlns)
		{
			return false;
		}
		XmlElement xmlElement = _source as XmlElement;
		if (xmlElement != null)
		{
			string text = ((P_0 == null || P_0.Length == 0) ? _document.strXmlns : P_0);
			string strReservedXmlns = _document.strReservedXmlns;
			do
			{
				XmlAttribute attributeNode = xmlElement.GetAttributeNode(text, strReservedXmlns);
				if (attributeNode != null)
				{
					_namespaceParent = (XmlElement)_source;
					_source = attributeNode;
					return true;
				}
				xmlElement = xmlElement.ParentNode as XmlElement;
			}
			while (xmlElement != null);
			if (P_0 == _document.strXml)
			{
				_namespaceParent = (XmlElement)_source;
				_source = _document.NamespaceXml;
				return true;
			}
		}
		return false;
	}

	public override bool MoveToFirstNamespace(XPathNamespaceScope P_0)
	{
		if (!(_source is XmlElement xmlElement))
		{
			return false;
		}
		int num = 2147483647;
		switch (P_0)
		{
		case XPathNamespaceScope.Local:
		{
			if (!xmlElement.HasAttributes)
			{
				return false;
			}
			XmlAttributeCollection attributes = xmlElement.Attributes;
			if (!MoveToFirstNamespaceLocal(attributes, ref num))
			{
				return false;
			}
			_source = attributes[num];
			_attributeIndex = num;
			_namespaceParent = xmlElement;
			break;
		}
		case XPathNamespaceScope.ExcludeXml:
		{
			XmlAttributeCollection attributes = xmlElement.Attributes;
			if (!MoveToFirstNamespaceGlobal(ref attributes, ref num))
			{
				return false;
			}
			XmlAttribute xmlAttribute = attributes[num];
			while (Ref.Equal(xmlAttribute.LocalName, _document.strXml))
			{
				if (!MoveToNextNamespaceGlobal(ref attributes, ref num))
				{
					return false;
				}
				xmlAttribute = attributes[num];
			}
			_source = xmlAttribute;
			_attributeIndex = num;
			_namespaceParent = xmlElement;
			break;
		}
		case XPathNamespaceScope.All:
		{
			XmlAttributeCollection attributes = xmlElement.Attributes;
			if (!MoveToFirstNamespaceGlobal(ref attributes, ref num))
			{
				_source = _document.NamespaceXml;
			}
			else
			{
				_source = attributes[num];
				_attributeIndex = num;
			}
			_namespaceParent = xmlElement;
			break;
		}
		default:
			return false;
		}
		return true;
	}

	private static bool MoveToFirstNamespaceLocal(XmlAttributeCollection P_0, ref int P_1)
	{
		for (int num = P_0.Count - 1; num >= 0; num--)
		{
			XmlAttribute xmlAttribute = P_0[num];
			if (xmlAttribute.IsNamespace)
			{
				P_1 = num;
				return true;
			}
		}
		return false;
	}

	private static bool MoveToFirstNamespaceGlobal(ref XmlAttributeCollection P_0, ref int P_1)
	{
		if (MoveToFirstNamespaceLocal(P_0, ref P_1))
		{
			return true;
		}
		for (XmlElement xmlElement = P_0.parent.ParentNode as XmlElement; xmlElement != null; xmlElement = xmlElement.ParentNode as XmlElement)
		{
			if (xmlElement.HasAttributes)
			{
				P_0 = xmlElement.Attributes;
				if (MoveToFirstNamespaceLocal(P_0, ref P_1))
				{
					return true;
				}
			}
		}
		return false;
	}

	public override bool MoveToNextNamespace(XPathNamespaceScope P_0)
	{
		if (!(_source is XmlAttribute { IsNamespace: not false } xmlAttribute))
		{
			return false;
		}
		int attributeIndex = _attributeIndex;
		if (!CheckAttributePosition(xmlAttribute, out var xmlAttributeCollection, attributeIndex) && !ResetAttributePosition(xmlAttribute, xmlAttributeCollection, out attributeIndex))
		{
			return false;
		}
		switch (P_0)
		{
		case XPathNamespaceScope.Local:
			if (xmlAttribute.OwnerElement != _namespaceParent)
			{
				return false;
			}
			if (!MoveToNextNamespaceLocal(xmlAttributeCollection, ref attributeIndex))
			{
				return false;
			}
			_source = xmlAttributeCollection[attributeIndex];
			_attributeIndex = attributeIndex;
			break;
		case XPathNamespaceScope.ExcludeXml:
		{
			XmlAttribute xmlAttribute2;
			string localName;
			do
			{
				if (!MoveToNextNamespaceGlobal(ref xmlAttributeCollection, ref attributeIndex))
				{
					return false;
				}
				xmlAttribute2 = xmlAttributeCollection[attributeIndex];
				localName = xmlAttribute2.LocalName;
			}
			while (PathHasDuplicateNamespace(xmlAttribute2.OwnerElement, _namespaceParent, localName) || Ref.Equal(localName, _document.strXml));
			_source = xmlAttribute2;
			_attributeIndex = attributeIndex;
			break;
		}
		case XPathNamespaceScope.All:
		{
			XmlAttribute xmlAttribute2;
			do
			{
				if (!MoveToNextNamespaceGlobal(ref xmlAttributeCollection, ref attributeIndex))
				{
					if (PathHasDuplicateNamespace(null, _namespaceParent, _document.strXml))
					{
						return false;
					}
					_source = _document.NamespaceXml;
					return true;
				}
				xmlAttribute2 = xmlAttributeCollection[attributeIndex];
			}
			while (PathHasDuplicateNamespace(xmlAttribute2.OwnerElement, _namespaceParent, xmlAttribute2.LocalName));
			_source = xmlAttribute2;
			_attributeIndex = attributeIndex;
			break;
		}
		default:
			return false;
		}
		return true;
	}

	private static bool MoveToNextNamespaceLocal(XmlAttributeCollection P_0, ref int P_1)
	{
		for (int num = P_1 - 1; num >= 0; num--)
		{
			XmlAttribute xmlAttribute = P_0[num];
			if (xmlAttribute.IsNamespace)
			{
				P_1 = num;
				return true;
			}
		}
		return false;
	}

	private static bool MoveToNextNamespaceGlobal(ref XmlAttributeCollection P_0, ref int P_1)
	{
		if (MoveToNextNamespaceLocal(P_0, ref P_1))
		{
			return true;
		}
		for (XmlElement xmlElement = P_0.parent.ParentNode as XmlElement; xmlElement != null; xmlElement = xmlElement.ParentNode as XmlElement)
		{
			if (xmlElement.HasAttributes)
			{
				P_0 = xmlElement.Attributes;
				if (MoveToFirstNamespaceLocal(P_0, ref P_1))
				{
					return true;
				}
			}
		}
		return false;
	}

	private bool PathHasDuplicateNamespace(XmlElement P_0, XmlElement P_1, string P_2)
	{
		XmlElement xmlElement = P_1;
		string strReservedXmlns = _document.strReservedXmlns;
		while (xmlElement != null && xmlElement != P_0)
		{
			XmlAttribute attributeNode = xmlElement.GetAttributeNode(P_2, strReservedXmlns);
			if (attributeNode != null)
			{
				return true;
			}
			xmlElement = xmlElement.ParentNode as XmlElement;
		}
		return false;
	}

	public override string LookupNamespace(string P_0)
	{
		string text = base.LookupNamespace(P_0);
		if (text != null)
		{
			text = NameTable.Add(text);
		}
		return text;
	}

	public override bool MoveToNext()
	{
		XmlNode xmlNode = NextSibling(_source);
		if (xmlNode == null)
		{
			return false;
		}
		if (xmlNode.IsText && _source.IsText)
		{
			xmlNode = NextSibling(TextEnd(xmlNode));
			if (xmlNode == null)
			{
				return false;
			}
		}
		XmlNode xmlNode2 = ParentNode(xmlNode);
		while (!IsValidChild(xmlNode2, xmlNode))
		{
			xmlNode = NextSibling(xmlNode);
			if (xmlNode == null)
			{
				return false;
			}
		}
		_source = xmlNode;
		return true;
	}

	public override bool MoveToFirstChild()
	{
		XmlNode xmlNode;
		switch (_source.NodeType)
		{
		case XmlNodeType.Element:
			xmlNode = FirstChild(_source);
			if (xmlNode == null)
			{
				return false;
			}
			break;
		case XmlNodeType.Document:
		case XmlNodeType.DocumentFragment:
			xmlNode = FirstChild(_source);
			if (xmlNode == null)
			{
				return false;
			}
			while (!IsValidChild(_source, xmlNode))
			{
				xmlNode = NextSibling(xmlNode);
				if (xmlNode == null)
				{
					return false;
				}
			}
			break;
		default:
			return false;
		}
		_source = xmlNode;
		return true;
	}

	public override bool MoveToParent()
	{
		XmlNode xmlNode = ParentNode(_source);
		if (xmlNode != null)
		{
			_source = xmlNode;
			return true;
		}
		if (_source is XmlAttribute xmlAttribute)
		{
			xmlNode = (xmlAttribute.IsNamespace ? _namespaceParent : xmlAttribute.OwnerElement);
			if (xmlNode != null)
			{
				_source = xmlNode;
				_namespaceParent = null;
				return true;
			}
		}
		return false;
	}

	public override void MoveToRoot()
	{
		while (true)
		{
			XmlNode xmlNode = _source.ParentNode;
			if (xmlNode == null)
			{
				if (!(_source is XmlAttribute xmlAttribute))
				{
					break;
				}
				xmlNode = (xmlAttribute.IsNamespace ? _namespaceParent : xmlAttribute.OwnerElement);
				if (xmlNode == null)
				{
					break;
				}
			}
			_source = xmlNode;
		}
		_namespaceParent = null;
	}

	public override bool MoveTo(XPathNavigator P_0)
	{
		if (P_0 is DocumentXPathNavigator documentXPathNavigator && _document == documentXPathNavigator._document)
		{
			_source = documentXPathNavigator._source;
			_attributeIndex = documentXPathNavigator._attributeIndex;
			_namespaceParent = documentXPathNavigator._namespaceParent;
			return true;
		}
		return false;
	}

	public override bool MoveToId(string P_0)
	{
		XmlElement elementById = _document.GetElementById(P_0);
		if (elementById != null)
		{
			_source = elementById;
			_namespaceParent = null;
			return true;
		}
		return false;
	}

	public override bool IsSamePosition(XPathNavigator P_0)
	{
		if (P_0 is DocumentXPathNavigator documentXPathNavigator)
		{
			CalibrateText();
			documentXPathNavigator.CalibrateText();
			if (_source == documentXPathNavigator._source)
			{
				return _namespaceParent == documentXPathNavigator._namespaceParent;
			}
			return false;
		}
		return false;
	}

	public override bool IsDescendant([NotNullWhen(true)] XPathNavigator P_0)
	{
		if (P_0 is DocumentXPathNavigator documentXPathNavigator)
		{
			return IsDescendant(_source, documentXPathNavigator._source);
		}
		return false;
	}

	private static XmlNode OwnerNode(XmlNode P_0)
	{
		XmlNode parentNode = P_0.ParentNode;
		if (parentNode != null)
		{
			return parentNode;
		}
		if (P_0 is XmlAttribute xmlAttribute)
		{
			return xmlAttribute.OwnerElement;
		}
		return null;
	}

	private static int GetDepth(XmlNode P_0)
	{
		int num = 0;
		for (XmlNode xmlNode = OwnerNode(P_0); xmlNode != null; xmlNode = OwnerNode(xmlNode))
		{
			num++;
		}
		return num;
	}

	private static XmlNodeOrder Compare(XmlNode P_0, XmlNode P_1)
	{
		if (P_0.XPNodeType == XPathNodeType.Attribute)
		{
			if (P_1.XPNodeType == XPathNodeType.Attribute)
			{
				XmlElement ownerElement = ((XmlAttribute)P_0).OwnerElement;
				if (ownerElement.HasAttributes)
				{
					XmlAttributeCollection attributes = ownerElement.Attributes;
					for (int i = 0; i < attributes.Count; i++)
					{
						XmlAttribute xmlAttribute = attributes[i];
						if (xmlAttribute == P_0)
						{
							return XmlNodeOrder.Before;
						}
						if (xmlAttribute == P_1)
						{
							return XmlNodeOrder.After;
						}
					}
				}
				return XmlNodeOrder.Unknown;
			}
			return XmlNodeOrder.Before;
		}
		if (P_1.XPNodeType == XPathNodeType.Attribute)
		{
			return XmlNodeOrder.After;
		}
		XmlNode nextSibling = P_0.NextSibling;
		while (nextSibling != null && nextSibling != P_1)
		{
			nextSibling = nextSibling.NextSibling;
		}
		if (nextSibling == null)
		{
			return XmlNodeOrder.After;
		}
		return XmlNodeOrder.Before;
	}

	public override XmlNodeOrder ComparePosition(XPathNavigator P_0)
	{
		if (!(P_0 is DocumentXPathNavigator documentXPathNavigator))
		{
			return XmlNodeOrder.Unknown;
		}
		CalibrateText();
		documentXPathNavigator.CalibrateText();
		if (_source == documentXPathNavigator._source && _namespaceParent == documentXPathNavigator._namespaceParent)
		{
			return XmlNodeOrder.Same;
		}
		if (_namespaceParent != null || documentXPathNavigator._namespaceParent != null)
		{
			return base.ComparePosition(P_0);
		}
		XmlNode xmlNode = _source;
		XmlNode xmlNode2 = documentXPathNavigator._source;
		XmlNode xmlNode3 = OwnerNode(xmlNode);
		XmlNode xmlNode4 = OwnerNode(xmlNode2);
		if (xmlNode3 == xmlNode4)
		{
			if (xmlNode3 == null)
			{
				return XmlNodeOrder.Unknown;
			}
			return Compare(xmlNode, xmlNode2);
		}
		int num = GetDepth(xmlNode);
		int num2 = GetDepth(xmlNode2);
		if (num2 > num)
		{
			while (xmlNode2 != null && num2 > num)
			{
				xmlNode2 = OwnerNode(xmlNode2);
				num2--;
			}
			if (xmlNode == xmlNode2)
			{
				return XmlNodeOrder.Before;
			}
			xmlNode4 = OwnerNode(xmlNode2);
		}
		else if (num > num2)
		{
			while (xmlNode != null && num > num2)
			{
				xmlNode = OwnerNode(xmlNode);
				num--;
			}
			if (xmlNode == xmlNode2)
			{
				return XmlNodeOrder.After;
			}
			xmlNode3 = OwnerNode(xmlNode);
		}
		while (xmlNode3 != null && xmlNode4 != null)
		{
			if (xmlNode3 == xmlNode4)
			{
				return Compare(xmlNode, xmlNode2);
			}
			xmlNode = xmlNode3;
			xmlNode2 = xmlNode4;
			xmlNode3 = OwnerNode(xmlNode);
			xmlNode4 = OwnerNode(xmlNode2);
		}
		return XmlNodeOrder.Unknown;
	}

	XmlNode IHasXmlNode.GetNode()
	{
		return _source;
	}

	public override XPathNodeIterator SelectDescendants(string P_0, string P_1, bool P_2)
	{
		string text = _document.NameTable.Get(P_1);
		if (text == null || _source.NodeType == XmlNodeType.Attribute)
		{
			return new DocumentXPathNodeIterator_Empty(this);
		}
		string text2 = _document.NameTable.Get(P_0);
		if (text2 == null)
		{
			return new DocumentXPathNodeIterator_Empty(this);
		}
		if (text2.Length == 0)
		{
			if (P_2)
			{
				return new DocumentXPathNodeIterator_ElemChildren_AndSelf_NoLocalName(this, text);
			}
			return new DocumentXPathNodeIterator_ElemChildren_NoLocalName(this, text);
		}
		if (P_2)
		{
			return new DocumentXPathNodeIterator_ElemChildren_AndSelf(this, text2, text);
		}
		return new DocumentXPathNodeIterator_ElemChildren(this, text2, text);
	}

	public override XPathNodeIterator SelectDescendants(XPathNodeType P_0, bool P_1)
	{
		if (P_0 == XPathNodeType.Element)
		{
			XmlNodeType nodeType = _source.NodeType;
			if (nodeType != XmlNodeType.Document && nodeType != XmlNodeType.Element)
			{
				return new DocumentXPathNodeIterator_Empty(this);
			}
			if (P_1)
			{
				return new DocumentXPathNodeIterator_AllElemChildren_AndSelf(this);
			}
			return new DocumentXPathNodeIterator_AllElemChildren(this);
		}
		return base.SelectDescendants(P_0, P_1);
	}

	[MemberNotNull("_source")]
	internal void ResetPosition(XmlNode P_0)
	{
		_source = P_0;
		if (!(P_0 is XmlAttribute xmlAttribute))
		{
			return;
		}
		XmlElement ownerElement = xmlAttribute.OwnerElement;
		if (ownerElement != null)
		{
			ResetAttributePosition(xmlAttribute, ownerElement.Attributes, out _attributeIndex);
			if (xmlAttribute.IsNamespace)
			{
				_namespaceParent = ownerElement;
			}
		}
	}

	private static bool ResetAttributePosition(XmlAttribute P_0, [NotNullWhen(true)] XmlAttributeCollection P_1, out int P_2)
	{
		if (P_1 != null)
		{
			for (int i = 0; i < P_1.Count; i++)
			{
				if (P_0 == P_1[i])
				{
					P_2 = i;
					return true;
				}
			}
		}
		P_2 = 0;
		return false;
	}

	private static bool CheckAttributePosition(XmlAttribute P_0, [NotNullWhen(true)] out XmlAttributeCollection P_1, int P_2)
	{
		XmlElement ownerElement = P_0.OwnerElement;
		if (ownerElement != null)
		{
			P_1 = ownerElement.Attributes;
			if (P_2 >= 0 && P_2 < P_1.Count && P_0 == P_1[P_2])
			{
				return true;
			}
		}
		else
		{
			P_1 = null;
		}
		return false;
	}

	private void CalibrateText()
	{
		for (XmlNode xmlNode = PreviousText(_source); xmlNode != null; xmlNode = PreviousText(xmlNode))
		{
			ResetPosition(xmlNode);
		}
	}

	private XmlNode ParentNode(XmlNode P_0)
	{
		XmlNode parentNode = P_0.ParentNode;
		if (!_document.HasEntityReferences)
		{
			return parentNode;
		}
		return ParentNodeTail(parentNode);
	}

	private static XmlNode ParentNodeTail(XmlNode P_0)
	{
		while (P_0 != null && P_0.NodeType == XmlNodeType.EntityReference)
		{
			P_0 = P_0.ParentNode;
		}
		return P_0;
	}

	private XmlNode FirstChild(XmlNode P_0)
	{
		XmlNode firstChild = P_0.FirstChild;
		if (!_document.HasEntityReferences)
		{
			return firstChild;
		}
		return FirstChildTail(firstChild);
	}

	private static XmlNode FirstChildTail(XmlNode P_0)
	{
		while (P_0 != null && P_0.NodeType == XmlNodeType.EntityReference)
		{
			P_0 = P_0.FirstChild;
		}
		return P_0;
	}

	private XmlNode NextSibling(XmlNode P_0)
	{
		XmlNode nextSibling = P_0.NextSibling;
		if (!_document.HasEntityReferences)
		{
			return nextSibling;
		}
		return NextSiblingTail(P_0, nextSibling);
	}

	private static XmlNode NextSiblingTail(XmlNode P_0, XmlNode P_1)
	{
		XmlNode xmlNode = P_0;
		while (P_1 == null)
		{
			xmlNode = xmlNode.ParentNode;
			if (xmlNode == null || xmlNode.NodeType != XmlNodeType.EntityReference)
			{
				return null;
			}
			P_1 = xmlNode.NextSibling;
		}
		while (P_1 != null && P_1.NodeType == XmlNodeType.EntityReference)
		{
			P_1 = P_1.FirstChild;
		}
		return P_1;
	}

	private XmlNode PreviousText(XmlNode P_0)
	{
		XmlNode previousText = P_0.PreviousText;
		if (!_document.HasEntityReferences)
		{
			return previousText;
		}
		return PreviousTextTail(P_0, previousText);
	}

	private static XmlNode PreviousTextTail(XmlNode P_0, XmlNode P_1)
	{
		if (P_1 != null)
		{
			return P_1;
		}
		if (!P_0.IsText)
		{
			return null;
		}
		XmlNode xmlNode = P_0.PreviousSibling;
		XmlNode xmlNode2 = P_0;
		while (xmlNode == null)
		{
			xmlNode2 = xmlNode2.ParentNode;
			if (xmlNode2 == null || xmlNode2.NodeType != XmlNodeType.EntityReference)
			{
				return null;
			}
			xmlNode = xmlNode2.PreviousSibling;
		}
		while (xmlNode != null)
		{
			switch (xmlNode.NodeType)
			{
			case XmlNodeType.EntityReference:
				break;
			case XmlNodeType.Text:
			case XmlNodeType.CDATA:
			case XmlNodeType.Whitespace:
			case XmlNodeType.SignificantWhitespace:
				return xmlNode;
			default:
				return null;
			}
			xmlNode = xmlNode.LastChild;
		}
		return null;
	}

	private static bool IsDescendant(XmlNode P_0, XmlNode P_1)
	{
		while (true)
		{
			XmlNode xmlNode = P_1.ParentNode;
			if (xmlNode == null)
			{
				if (!(P_1 is XmlAttribute xmlAttribute))
				{
					break;
				}
				xmlNode = xmlAttribute.OwnerElement;
				if (xmlNode == null)
				{
					break;
				}
			}
			P_1 = xmlNode;
			if (P_0 == P_1)
			{
				return true;
			}
		}
		return false;
	}

	private static bool IsValidChild(XmlNode P_0, XmlNode P_1)
	{
		switch (P_0.NodeType)
		{
		case XmlNodeType.Element:
			return true;
		case XmlNodeType.DocumentFragment:
			switch (P_1.NodeType)
			{
			case XmlNodeType.Element:
			case XmlNodeType.Text:
			case XmlNodeType.CDATA:
			case XmlNodeType.ProcessingInstruction:
			case XmlNodeType.Comment:
			case XmlNodeType.Whitespace:
			case XmlNodeType.SignificantWhitespace:
				return true;
			}
			break;
		case XmlNodeType.Document:
		{
			XmlNodeType nodeType = P_1.NodeType;
			if (nodeType == XmlNodeType.Element || (uint)(nodeType - 7) <= 1u)
			{
				return true;
			}
			break;
		}
		}
		return false;
	}

	private XmlNode TextEnd(XmlNode P_0)
	{
		XmlNode xmlNode = P_0;
		XmlNode result;
		do
		{
			result = xmlNode;
			xmlNode = NextSibling(xmlNode);
		}
		while (xmlNode != null && xmlNode.IsText);
		return result;
	}
}
