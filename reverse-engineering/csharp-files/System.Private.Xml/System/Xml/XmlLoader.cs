using System.Collections.Generic;
using System.Globalization;
using System.Xml.Schema;

namespace System.Xml;

internal sealed class XmlLoader
{
	private XmlDocument _doc;

	private XmlReader _reader;

	private bool _preserveWhitespace;

	internal void Load(XmlDocument P_0, XmlReader P_1, bool P_2)
	{
		_doc = P_0;
		if (P_1.GetType() == typeof(XmlTextReader))
		{
			_reader = ((XmlTextReader)P_1).Impl;
		}
		else
		{
			_reader = P_1;
		}
		_preserveWhitespace = P_2;
		if (P_0 == null)
		{
			throw new ArgumentException("Xdom_Load_NoDocument");
		}
		if (P_1 == null)
		{
			throw new ArgumentException("Xdom_Load_NoReader");
		}
		P_0.SetBaseURI(P_1.BaseURI);
		if (P_1.Settings != null && P_1.Settings.ValidationType == ValidationType.Schema)
		{
			P_0.Schemas = P_1.Settings.Schemas;
		}
		if (_reader.ReadState == ReadState.Interactive || _reader.Read())
		{
			LoadDocSequence(P_0);
		}
	}

	private void LoadDocSequence(XmlDocument P_0)
	{
		XmlNode xmlNode;
		while ((xmlNode = LoadNode(true)) != null)
		{
			P_0.AppendChildForLoad(xmlNode, P_0);
			if (!_reader.Read())
			{
				break;
			}
		}
	}

	private XmlNode LoadNode(bool P_0)
	{
		XmlReader reader = _reader;
		XmlNode xmlNode = null;
		do
		{
			XmlNode xmlNode2;
			switch (reader.NodeType)
			{
			case XmlNodeType.Element:
			{
				bool isEmptyElement = reader.IsEmptyElement;
				XmlElement xmlElement2 = _doc.CreateElement(reader.Prefix, reader.LocalName, reader.NamespaceURI);
				xmlElement2.IsEmpty = isEmptyElement;
				if (reader.MoveToFirstAttribute())
				{
					XmlAttributeCollection attributes = xmlElement2.Attributes;
					do
					{
						XmlAttribute xmlAttribute = LoadAttributeNode();
						attributes.Append(xmlAttribute);
					}
					while (reader.MoveToNextAttribute());
					reader.MoveToElement();
				}
				if (!isEmptyElement)
				{
					xmlNode?.AppendChildForLoad(xmlElement2, _doc);
					xmlNode = xmlElement2;
					continue;
				}
				IXmlSchemaInfo schemaInfo = reader.SchemaInfo;
				if (schemaInfo != null)
				{
					xmlElement2.XmlName = _doc.AddXmlName(xmlElement2.Prefix, xmlElement2.LocalName, xmlElement2.NamespaceURI, schemaInfo);
				}
				xmlNode2 = xmlElement2;
				break;
			}
			case XmlNodeType.EndElement:
			{
				if (xmlNode == null)
				{
					return null;
				}
				IXmlSchemaInfo schemaInfo = reader.SchemaInfo;
				if (schemaInfo != null && xmlNode is XmlElement xmlElement)
				{
					xmlElement.XmlName = _doc.AddXmlName(xmlElement.Prefix, xmlElement.LocalName, xmlElement.NamespaceURI, schemaInfo);
				}
				if (xmlNode.ParentNode == null)
				{
					return xmlNode;
				}
				xmlNode = xmlNode.ParentNode;
				continue;
			}
			case XmlNodeType.EntityReference:
				xmlNode2 = LoadEntityReferenceNode(false);
				break;
			case XmlNodeType.EndEntity:
				return null;
			case XmlNodeType.Attribute:
				xmlNode2 = LoadAttributeNode();
				break;
			case XmlNodeType.Text:
				xmlNode2 = _doc.CreateTextNode(reader.Value);
				break;
			case XmlNodeType.SignificantWhitespace:
				xmlNode2 = _doc.CreateSignificantWhitespace(reader.Value);
				break;
			case XmlNodeType.Whitespace:
				if (_preserveWhitespace)
				{
					xmlNode2 = _doc.CreateWhitespace(reader.Value);
					break;
				}
				if (xmlNode == null && !P_0)
				{
					return null;
				}
				continue;
			case XmlNodeType.CDATA:
				xmlNode2 = _doc.CreateCDataSection(reader.Value);
				break;
			case XmlNodeType.XmlDeclaration:
				xmlNode2 = LoadDeclarationNode();
				break;
			case XmlNodeType.ProcessingInstruction:
				xmlNode2 = _doc.CreateProcessingInstruction(reader.Name, reader.Value);
				break;
			case XmlNodeType.Comment:
				xmlNode2 = _doc.CreateComment(reader.Value);
				break;
			case XmlNodeType.DocumentType:
				xmlNode2 = LoadDocumentTypeNode();
				break;
			default:
				throw UnexpectedNodeType(reader.NodeType);
			}
			if (xmlNode != null)
			{
				xmlNode.AppendChildForLoad(xmlNode2, _doc);
				continue;
			}
			return xmlNode2;
		}
		while (reader.Read());
		if (xmlNode != null)
		{
			while (xmlNode.ParentNode != null)
			{
				xmlNode = xmlNode.ParentNode;
			}
		}
		return xmlNode;
	}

	private XmlAttribute LoadAttributeNode()
	{
		XmlReader reader = _reader;
		if (reader.IsDefault)
		{
			return LoadDefaultAttribute();
		}
		XmlAttribute xmlAttribute = _doc.CreateAttribute(reader.Prefix, reader.LocalName, reader.NamespaceURI);
		IXmlSchemaInfo schemaInfo = reader.SchemaInfo;
		if (schemaInfo != null)
		{
			xmlAttribute.XmlName = _doc.AddAttrXmlName(xmlAttribute.Prefix, xmlAttribute.LocalName, xmlAttribute.NamespaceURI, schemaInfo);
		}
		while (reader.ReadAttributeValue())
		{
			XmlNode xmlNode;
			switch (reader.NodeType)
			{
			case XmlNodeType.Text:
				xmlNode = _doc.CreateTextNode(reader.Value);
				break;
			case XmlNodeType.EntityReference:
				xmlNode = _doc.CreateEntityReference(reader.LocalName);
				if (reader.CanResolveEntity)
				{
					reader.ResolveEntity();
					LoadAttributeValue(xmlNode, false);
					if (xmlNode.FirstChild == null)
					{
						xmlNode.AppendChildForLoad(_doc.CreateTextNode(string.Empty), _doc);
					}
				}
				break;
			default:
				throw UnexpectedNodeType(reader.NodeType);
			}
			xmlAttribute.AppendChildForLoad(xmlNode, _doc);
		}
		return xmlAttribute;
	}

	private XmlAttribute LoadDefaultAttribute()
	{
		XmlReader reader = _reader;
		XmlAttribute xmlAttribute = _doc.CreateDefaultAttribute(reader.Prefix, reader.LocalName, reader.NamespaceURI);
		IXmlSchemaInfo schemaInfo = reader.SchemaInfo;
		if (schemaInfo != null)
		{
			xmlAttribute.XmlName = _doc.AddAttrXmlName(xmlAttribute.Prefix, xmlAttribute.LocalName, xmlAttribute.NamespaceURI, schemaInfo);
		}
		LoadAttributeValue(xmlAttribute, false);
		if (xmlAttribute is XmlUnspecifiedAttribute xmlUnspecifiedAttribute)
		{
			xmlUnspecifiedAttribute.SetSpecified(false);
		}
		return xmlAttribute;
	}

	private void LoadAttributeValue(XmlNode P_0, bool P_1)
	{
		XmlReader reader = _reader;
		while (reader.ReadAttributeValue())
		{
			XmlNode xmlNode;
			switch (reader.NodeType)
			{
			case XmlNodeType.Text:
				xmlNode = (P_1 ? new XmlText(reader.Value, _doc) : _doc.CreateTextNode(reader.Value));
				break;
			case XmlNodeType.EndEntity:
				return;
			case XmlNodeType.EntityReference:
				xmlNode = (P_1 ? new XmlEntityReference(_reader.LocalName, _doc) : _doc.CreateEntityReference(_reader.LocalName));
				if (reader.CanResolveEntity)
				{
					reader.ResolveEntity();
					LoadAttributeValue(xmlNode, P_1);
					if (xmlNode.FirstChild == null)
					{
						xmlNode.AppendChildForLoad(P_1 ? new XmlText(string.Empty) : _doc.CreateTextNode(string.Empty), _doc);
					}
				}
				break;
			default:
				throw UnexpectedNodeType(reader.NodeType);
			}
			P_0.AppendChildForLoad(xmlNode, _doc);
		}
	}

	private XmlEntityReference LoadEntityReferenceNode(bool P_0)
	{
		XmlEntityReference xmlEntityReference = (P_0 ? new XmlEntityReference(_reader.Name, _doc) : _doc.CreateEntityReference(_reader.Name));
		if (_reader.CanResolveEntity)
		{
			_reader.ResolveEntity();
			while (_reader.Read() && _reader.NodeType != XmlNodeType.EndEntity)
			{
				XmlNode xmlNode = (P_0 ? LoadNodeDirect() : LoadNode(false));
				if (xmlNode != null)
				{
					xmlEntityReference.AppendChildForLoad(xmlNode, _doc);
				}
			}
			if (xmlEntityReference.LastChild == null)
			{
				xmlEntityReference.AppendChildForLoad(_doc.CreateTextNode(string.Empty), _doc);
			}
		}
		return xmlEntityReference;
	}

	private XmlDeclaration LoadDeclarationNode()
	{
		string text = null;
		string text2 = null;
		string text3 = null;
		while (_reader.MoveToNextAttribute())
		{
			switch (_reader.Name)
			{
			case "version":
				text = _reader.Value;
				break;
			case "encoding":
				text2 = _reader.Value;
				break;
			case "standalone":
				text3 = _reader.Value;
				break;
			}
		}
		if (text == null)
		{
			ParseXmlDeclarationValue(_reader.Value, out text, out text2, out text3);
		}
		return _doc.CreateXmlDeclaration(text, text2, text3);
	}

	private XmlDocumentType LoadDocumentTypeNode()
	{
		string text = null;
		string text2 = null;
		string value = _reader.Value;
		string localName = _reader.LocalName;
		while (_reader.MoveToNextAttribute())
		{
			string name = _reader.Name;
			if (!(name == "PUBLIC"))
			{
				if (name == "SYSTEM")
				{
					text2 = _reader.Value;
				}
			}
			else
			{
				text = _reader.Value;
			}
		}
		XmlDocumentType xmlDocumentType = _doc.CreateDocumentType(localName, text, text2, value);
		IDtdInfo dtdInfo = _reader.DtdInfo;
		if (dtdInfo != null)
		{
			LoadDocumentType(dtdInfo, xmlDocumentType);
		}
		else
		{
			ParseDocumentType(xmlDocumentType);
		}
		return xmlDocumentType;
	}

	private XmlNode LoadNodeDirect()
	{
		XmlReader reader = _reader;
		XmlNode xmlNode = null;
		do
		{
			XmlNode xmlNode2;
			switch (reader.NodeType)
			{
			case XmlNodeType.Element:
			{
				bool isEmptyElement = _reader.IsEmptyElement;
				XmlElement xmlElement = new XmlElement(_reader.Prefix, _reader.LocalName, _reader.NamespaceURI, _doc);
				xmlElement.IsEmpty = isEmptyElement;
				if (_reader.MoveToFirstAttribute())
				{
					XmlAttributeCollection attributes = xmlElement.Attributes;
					do
					{
						XmlAttribute xmlAttribute = LoadAttributeNodeDirect();
						attributes.Append(xmlAttribute);
					}
					while (reader.MoveToNextAttribute());
				}
				if (!isEmptyElement)
				{
					xmlNode.AppendChildForLoad(xmlElement, _doc);
					xmlNode = xmlElement;
					continue;
				}
				xmlNode2 = xmlElement;
				break;
			}
			case XmlNodeType.EndElement:
				if (xmlNode.ParentNode == null)
				{
					return xmlNode;
				}
				xmlNode = xmlNode.ParentNode;
				continue;
			case XmlNodeType.EntityReference:
				xmlNode2 = LoadEntityReferenceNode(true);
				break;
			case XmlNodeType.Attribute:
				xmlNode2 = LoadAttributeNodeDirect();
				break;
			case XmlNodeType.SignificantWhitespace:
				xmlNode2 = new XmlSignificantWhitespace(_reader.Value, _doc);
				break;
			case XmlNodeType.Whitespace:
				if (_preserveWhitespace)
				{
					xmlNode2 = new XmlWhitespace(_reader.Value, _doc);
					break;
				}
				continue;
			case XmlNodeType.Text:
				xmlNode2 = new XmlText(_reader.Value, _doc);
				break;
			case XmlNodeType.CDATA:
				xmlNode2 = new XmlCDataSection(_reader.Value, _doc);
				break;
			case XmlNodeType.ProcessingInstruction:
				xmlNode2 = new XmlProcessingInstruction(_reader.Name, _reader.Value, _doc);
				break;
			case XmlNodeType.Comment:
				xmlNode2 = new XmlComment(_reader.Value, _doc);
				break;
			default:
				throw UnexpectedNodeType(_reader.NodeType);
			case XmlNodeType.EndEntity:
				continue;
			}
			if (xmlNode != null)
			{
				xmlNode.AppendChildForLoad(xmlNode2, _doc);
				continue;
			}
			return xmlNode2;
		}
		while (reader.Read());
		return null;
	}

	private XmlAttribute LoadAttributeNodeDirect()
	{
		XmlReader reader = _reader;
		if (reader.IsDefault)
		{
			XmlUnspecifiedAttribute xmlUnspecifiedAttribute = new XmlUnspecifiedAttribute(reader.Prefix, reader.LocalName, reader.NamespaceURI, _doc);
			LoadAttributeValue(xmlUnspecifiedAttribute, true);
			xmlUnspecifiedAttribute.SetSpecified(false);
			return xmlUnspecifiedAttribute;
		}
		XmlAttribute xmlAttribute = new XmlAttribute(reader.Prefix, reader.LocalName, reader.NamespaceURI, _doc);
		LoadAttributeValue(xmlAttribute, true);
		return xmlAttribute;
	}

	internal void ParseDocumentType(XmlDocumentType P_0)
	{
		XmlDocument ownerDocument = P_0.OwnerDocument;
		if (ownerDocument.HasSetResolver)
		{
			ParseDocumentType(P_0, true, ownerDocument.GetResolver());
		}
		else
		{
			ParseDocumentType(P_0, false, null);
		}
	}

	private void ParseDocumentType(XmlDocumentType P_0, bool P_1, XmlResolver P_2)
	{
		_doc = P_0.OwnerDocument;
		XmlParserContext xmlParserContext = new XmlParserContext(null, new XmlNamespaceManager(_doc.NameTable), null, null, null, null, _doc.BaseURI, string.Empty, XmlSpace.None);
		XmlTextReaderImpl xmlTextReaderImpl = new XmlTextReaderImpl("", XmlNodeType.Element, xmlParserContext);
		xmlTextReaderImpl.Namespaces = P_0.ParseWithNamespaces;
		if (P_1)
		{
			xmlTextReaderImpl.XmlResolver = P_2;
		}
		IDtdParser dtdParser = DtdParser.Create();
		XmlTextReaderImpl.DtdParserProxy dtdParserProxy = new XmlTextReaderImpl.DtdParserProxy(xmlTextReaderImpl);
		IDtdInfo dtdInfo = dtdParser.ParseFreeFloatingDtd(_doc.BaseURI, P_0.Name, P_0.PublicId, P_0.SystemId, P_0.InternalSubset, dtdParserProxy);
		LoadDocumentType(dtdInfo, P_0);
	}

	private void LoadDocumentType(IDtdInfo P_0, XmlDocumentType P_1)
	{
		if (!(P_0 is SchemaInfo schemaInfo))
		{
			throw new XmlException("Xml_InternalError", string.Empty);
		}
		P_1.DtdSchemaInfo = schemaInfo;
		if (schemaInfo == null)
		{
			return;
		}
		_doc.DtdSchemaInfo = schemaInfo;
		if (schemaInfo.Notations != null)
		{
			foreach (SchemaNotation value3 in schemaInfo.Notations.Values)
			{
				P_1.Notations.SetNamedItem(new XmlNotation(value3.Name.Name, value3.Pubid, value3.SystemLiteral, _doc));
			}
		}
		if (schemaInfo.GeneralEntities != null)
		{
			foreach (SchemaEntity value4 in schemaInfo.GeneralEntities.Values)
			{
				XmlEntity xmlEntity = new XmlEntity(value4.Name.Name, value4.Text, value4.Pubid, value4.Url, value4.NData.IsEmpty ? null : value4.NData.Name, _doc);
				xmlEntity.SetBaseURI(value4.DeclaredURI);
				P_1.Entities.SetNamedItem(xmlEntity);
			}
		}
		if (schemaInfo.ParameterEntities != null)
		{
			foreach (SchemaEntity value5 in schemaInfo.ParameterEntities.Values)
			{
				XmlEntity xmlEntity2 = new XmlEntity(value5.Name.Name, value5.Text, value5.Pubid, value5.Url, value5.NData.IsEmpty ? null : value5.NData.Name, _doc);
				xmlEntity2.SetBaseURI(value5.DeclaredURI);
				P_1.Entities.SetNamedItem(xmlEntity2);
			}
		}
		_doc.Entities = P_1.Entities;
		foreach (KeyValuePair<XmlQualifiedName, SchemaElementDecl> elementDecl in schemaInfo.ElementDecls)
		{
			SchemaElementDecl value = elementDecl.Value;
			if (value.AttDefs == null)
			{
				continue;
			}
			foreach (KeyValuePair<XmlQualifiedName, SchemaAttDef> attDef in value.AttDefs)
			{
				SchemaAttDef value2 = attDef.Value;
				if (value2.Datatype.TokenizedType == XmlTokenizedType.ID)
				{
					_doc.AddIdInfo(_doc.AddXmlName(value.Prefix, value.Name.Name, string.Empty, null), _doc.AddAttrXmlName(value2.Prefix, value2.Name.Name, string.Empty, null));
					break;
				}
			}
		}
	}

	private XmlParserContext GetContext(XmlNode P_0)
	{
		string text = null;
		XmlSpace xmlSpace = XmlSpace.None;
		XmlDocumentType documentType = _doc.DocumentType;
		string baseURI = _doc.BaseURI;
		HashSet<string> hashSet = new HashSet<string>();
		XmlNameTable nameTable = _doc.NameTable;
		XmlNamespaceManager xmlNamespaceManager = new XmlNamespaceManager(nameTable);
		bool flag = false;
		while (P_0 != null && P_0 != _doc)
		{
			if (P_0 is XmlElement { HasAttributes: not false } xmlElement)
			{
				xmlNamespaceManager.PushScope();
				foreach (XmlAttribute attribute in xmlElement.Attributes)
				{
					if (attribute.Prefix == _doc.strXmlns && !hashSet.Contains(attribute.LocalName))
					{
						hashSet.Add(attribute.LocalName);
						xmlNamespaceManager.AddNamespace(attribute.LocalName, attribute.Value);
					}
					else if (!flag && attribute.Prefix.Length == 0 && attribute.LocalName == _doc.strXmlns)
					{
						xmlNamespaceManager.AddNamespace(string.Empty, attribute.Value);
						flag = true;
					}
					else if (xmlSpace == XmlSpace.None && attribute.Prefix == _doc.strXml && attribute.LocalName == _doc.strSpace)
					{
						if (attribute.Value == "default")
						{
							xmlSpace = XmlSpace.Default;
						}
						else if (attribute.Value == "preserve")
						{
							xmlSpace = XmlSpace.Preserve;
						}
					}
					else if (text == null && attribute.Prefix == _doc.strXml && attribute.LocalName == _doc.strLang)
					{
						text = attribute.Value;
					}
				}
			}
			P_0 = P_0.ParentNode;
		}
		return new XmlParserContext(nameTable, xmlNamespaceManager, documentType?.Name, documentType?.PublicId, documentType?.SystemId, documentType?.InternalSubset, baseURI, text, xmlSpace);
	}

	internal XmlNamespaceManager ParsePartialContent(XmlNode P_0, string P_1, XmlNodeType P_2)
	{
		_doc = P_0.OwnerDocument;
		XmlParserContext context = GetContext(P_0);
		_reader = CreateInnerXmlReader(P_1, P_2, context, _doc);
		try
		{
			_preserveWhitespace = true;
			bool isLoading = _doc.IsLoading;
			_doc.IsLoading = true;
			if (P_2 == XmlNodeType.Entity)
			{
				XmlNode xmlNode;
				while (_reader.Read() && (xmlNode = LoadNodeDirect()) != null)
				{
					P_0.AppendChildForLoad(xmlNode, _doc);
				}
			}
			else
			{
				XmlNode xmlNode2;
				while (_reader.Read() && (xmlNode2 = LoadNode(true)) != null)
				{
					P_0.AppendChildForLoad(xmlNode2, _doc);
				}
			}
			_doc.IsLoading = isLoading;
		}
		finally
		{
			_reader.Close();
		}
		return context.NamespaceManager;
	}

	internal void LoadInnerXmlElement(XmlElement P_0, string P_1)
	{
		XmlNamespaceManager xmlNamespaceManager = ParsePartialContent(P_0, P_1, XmlNodeType.Element);
		if (P_0.ChildNodes.Count > 0)
		{
			RemoveDuplicateNamespace(P_0, xmlNamespaceManager, false);
		}
	}

	internal void LoadInnerXmlAttribute(XmlAttribute P_0, string P_1)
	{
		ParsePartialContent(P_0, P_1, XmlNodeType.Attribute);
	}

	private void RemoveDuplicateNamespace(XmlElement P_0, XmlNamespaceManager P_1, bool P_2)
	{
		P_1.PushScope();
		XmlAttributeCollection attributes = P_0.Attributes;
		int count = attributes.Count;
		if (P_2 && count > 0)
		{
			for (int num = count - 1; num >= 0; num--)
			{
				XmlAttribute xmlAttribute = attributes[num];
				if (xmlAttribute.Prefix == _doc.strXmlns)
				{
					string text = P_1.LookupNamespace(xmlAttribute.LocalName);
					if (text != null)
					{
						if (xmlAttribute.Value == text)
						{
							P_0.Attributes.RemoveNodeAt(num);
						}
					}
					else
					{
						P_1.AddNamespace(xmlAttribute.LocalName, xmlAttribute.Value);
					}
				}
				else if (xmlAttribute.Prefix.Length == 0 && xmlAttribute.LocalName == _doc.strXmlns)
				{
					string defaultNamespace = P_1.DefaultNamespace;
					if (defaultNamespace != null)
					{
						if (xmlAttribute.Value == defaultNamespace)
						{
							P_0.Attributes.RemoveNodeAt(num);
						}
					}
					else
					{
						P_1.AddNamespace(xmlAttribute.LocalName, xmlAttribute.Value);
					}
				}
			}
		}
		for (XmlNode xmlNode = P_0.FirstChild; xmlNode != null; xmlNode = xmlNode.NextSibling)
		{
			if (xmlNode is XmlElement xmlElement)
			{
				RemoveDuplicateNamespace(xmlElement, P_1, true);
			}
		}
		P_1.PopScope();
	}

	private static string EntitizeName(string P_0)
	{
		return "&" + P_0 + ";";
	}

	internal void ExpandEntity(XmlEntity P_0)
	{
		ParsePartialContent(P_0, EntitizeName(P_0.Name), XmlNodeType.Entity);
	}

	internal void ExpandEntityReference(XmlEntityReference P_0)
	{
		_doc = P_0.OwnerDocument;
		bool isLoading = _doc.IsLoading;
		_doc.IsLoading = true;
		switch (P_0.Name)
		{
		case "lt":
			P_0.AppendChildForLoad(_doc.CreateTextNode("<"), _doc);
			_doc.IsLoading = isLoading;
			return;
		case "gt":
			P_0.AppendChildForLoad(_doc.CreateTextNode(">"), _doc);
			_doc.IsLoading = isLoading;
			return;
		case "amp":
			P_0.AppendChildForLoad(_doc.CreateTextNode("&"), _doc);
			_doc.IsLoading = isLoading;
			return;
		case "apos":
			P_0.AppendChildForLoad(_doc.CreateTextNode("'"), _doc);
			_doc.IsLoading = isLoading;
			return;
		case "quot":
			P_0.AppendChildForLoad(_doc.CreateTextNode("\""), _doc);
			_doc.IsLoading = isLoading;
			return;
		}
		XmlNamedNodeMap entities = _doc.Entities;
		foreach (XmlEntity item in entities)
		{
			if (Ref.Equal(item.Name, P_0.Name))
			{
				ParsePartialContent(P_0, EntitizeName(P_0.Name), XmlNodeType.EntityReference);
				return;
			}
		}
		if (!_doc.ActualLoadingStatus)
		{
			P_0.AppendChildForLoad(_doc.CreateTextNode(""), _doc);
			_doc.IsLoading = isLoading;
			return;
		}
		_doc.IsLoading = isLoading;
		throw new XmlException("Xml_UndeclaredParEntity", P_0.Name);
	}

	private static XmlReader CreateInnerXmlReader(string P_0, XmlNodeType P_1, XmlParserContext P_2, XmlDocument P_3)
	{
		XmlNodeType xmlNodeType = P_1;
		if (xmlNodeType == XmlNodeType.Entity || xmlNodeType == XmlNodeType.EntityReference)
		{
			xmlNodeType = XmlNodeType.Element;
		}
		XmlTextReaderImpl xmlTextReaderImpl = new XmlTextReaderImpl(P_0, xmlNodeType, P_2);
		xmlTextReaderImpl.XmlValidatingReaderCompatibilityMode = true;
		if (P_3.HasSetResolver)
		{
			xmlTextReaderImpl.XmlResolver = P_3.GetResolver();
		}
		if (!P_3.ActualLoadingStatus)
		{
			xmlTextReaderImpl.DisableUndeclaredEntityCheck = true;
		}
		XmlDocumentType documentType = P_3.DocumentType;
		if (documentType != null)
		{
			xmlTextReaderImpl.Namespaces = documentType.ParseWithNamespaces;
			if (documentType.DtdSchemaInfo != null)
			{
				xmlTextReaderImpl.SetDtdInfo(documentType.DtdSchemaInfo);
			}
			else
			{
				IDtdParser dtdParser = DtdParser.Create();
				XmlTextReaderImpl.DtdParserProxy dtdParserProxy = new XmlTextReaderImpl.DtdParserProxy(xmlTextReaderImpl);
				IDtdInfo dtdInfo = dtdParser.ParseFreeFloatingDtd(P_2.BaseURI, P_2.DocTypeName, P_2.PublicId, P_2.SystemId, P_2.InternalSubset, dtdParserProxy);
				documentType.DtdSchemaInfo = dtdInfo as SchemaInfo;
				xmlTextReaderImpl.SetDtdInfo(dtdInfo);
			}
		}
		if (P_1 == XmlNodeType.Entity || P_1 == XmlNodeType.EntityReference)
		{
			xmlTextReaderImpl.Read();
			xmlTextReaderImpl.ResolveEntity();
		}
		return xmlTextReaderImpl;
	}

	internal static void ParseXmlDeclarationValue(string P_0, out string P_1, out string P_2, out string P_3)
	{
		P_1 = null;
		P_2 = null;
		P_3 = null;
		XmlTextReaderImpl xmlTextReaderImpl = new XmlTextReaderImpl(P_0, null);
		try
		{
			xmlTextReaderImpl.Read();
			if (xmlTextReaderImpl.MoveToAttribute("version"))
			{
				P_1 = xmlTextReaderImpl.Value;
			}
			if (xmlTextReaderImpl.MoveToAttribute("encoding"))
			{
				P_2 = xmlTextReaderImpl.Value;
			}
			if (xmlTextReaderImpl.MoveToAttribute("standalone"))
			{
				P_3 = xmlTextReaderImpl.Value;
			}
		}
		finally
		{
			xmlTextReaderImpl.Close();
		}
	}

	internal static Exception UnexpectedNodeType(XmlNodeType P_0)
	{
		return new InvalidOperationException(System.SR.Format(CultureInfo.InvariantCulture, "Xml_UnexpectedNodeType", P_0.ToString()));
	}
}
