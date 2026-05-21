using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Xml.Schema;
using System.Xml.XPath;

namespace System.Xml;

public class XmlDocument : XmlNode
{
	private static readonly (string key, int hash)[] s_nameTableSeeds = new(string, int)[15]
	{
		("#document", System.Xml.NameTable.ComputeHash32("#document")),
		("#document-fragment", System.Xml.NameTable.ComputeHash32("#document-fragment")),
		("#comment", System.Xml.NameTable.ComputeHash32("#comment")),
		("#text", System.Xml.NameTable.ComputeHash32("#text")),
		("#cdata-section", System.Xml.NameTable.ComputeHash32("#cdata-section")),
		("#entity", System.Xml.NameTable.ComputeHash32("#entity")),
		("id", System.Xml.NameTable.ComputeHash32("id")),
		("xmlns", System.Xml.NameTable.ComputeHash32("xmlns")),
		("xml", System.Xml.NameTable.ComputeHash32("xml")),
		("space", System.Xml.NameTable.ComputeHash32("space")),
		("lang", System.Xml.NameTable.ComputeHash32("lang")),
		("#whitespace", System.Xml.NameTable.ComputeHash32("#whitespace")),
		("#significant-whitespace", System.Xml.NameTable.ComputeHash32("#significant-whitespace")),
		("http://www.w3.org/2000/xmlns/", System.Xml.NameTable.ComputeHash32("http://www.w3.org/2000/xmlns/")),
		("http://www.w3.org/XML/1998/namespace", System.Xml.NameTable.ComputeHash32("http://www.w3.org/XML/1998/namespace"))
	};

	private readonly XmlImplementation _implementation;

	private readonly DomNameTable _domNameTable;

	private XmlLinkedNode _lastChild;

	private XmlNamedNodeMap _entities;

	private Hashtable _htElementIdMap;

	private Hashtable _htElementIDAttrDecl;

	private SchemaInfo _schemaInfo;

	private XmlSchemaSet _schemas;

	private bool _reportValidity;

	private bool _actualLoadingStatus;

	private XmlNodeChangedEventHandler _onNodeInsertingDelegate;

	private XmlNodeChangedEventHandler _onNodeInsertedDelegate;

	private XmlNodeChangedEventHandler _onNodeRemovingDelegate;

	private XmlNodeChangedEventHandler _onNodeRemovedDelegate;

	private XmlNodeChangedEventHandler _onNodeChangingDelegate;

	private XmlNodeChangedEventHandler _onNodeChangedDelegate;

	internal bool fEntRefNodesPresent;

	internal bool fCDataNodesPresent;

	private bool _preserveWhitespace;

	private bool _isLoading;

	internal string strDocumentName;

	internal string strDocumentFragmentName;

	internal string strCommentName;

	internal string strTextName;

	internal string strCDataSectionName;

	internal string strEntityName;

	internal string strID;

	internal string strXmlns;

	internal string strXml;

	internal string strSpace;

	internal string strLang;

	internal string strNonSignificantWhitespaceName;

	internal string strSignificantWhitespaceName;

	internal string strReservedXmlns;

	internal string strReservedXml;

	internal string baseURI;

	private XmlResolver _resolver;

	internal bool bSetResolver;

	internal object objLock;

	private XmlAttribute _namespaceXml;

	internal static EmptyEnumerator EmptyEnumerator = new EmptyEnumerator();

	internal static IXmlSchemaInfo NotKnownSchemaInfo = new XmlSchemaInfo(XmlSchemaValidity.NotKnown);

	internal static IXmlSchemaInfo ValidSchemaInfo = new XmlSchemaInfo(XmlSchemaValidity.Valid);

	internal static IXmlSchemaInfo InvalidSchemaInfo = new XmlSchemaInfo(XmlSchemaValidity.Invalid);

	internal SchemaInfo? DtdSchemaInfo
	{
		get
		{
			return _schemaInfo;
		}
		set
		{
			_schemaInfo = schemaInfo;
		}
	}

	public override XmlNodeType NodeType => XmlNodeType.Document;

	public override XmlNode? ParentNode => null;

	public virtual XmlDocumentType? DocumentType => (XmlDocumentType)FindChild(XmlNodeType.DocumentType);

	internal virtual XmlDeclaration? Declaration
	{
		get
		{
			if (HasChildNodes)
			{
				return FirstChild as XmlDeclaration;
			}
			return null;
		}
	}

	public XmlImplementation Implementation => _implementation;

	public override string Name => strDocumentName;

	public override string LocalName => strDocumentName;

	public XmlElement? DocumentElement => (XmlElement)FindChild(XmlNodeType.Element);

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

	public override XmlDocument? OwnerDocument => null;

	public XmlSchemaSet Schemas
	{
		set
		{
			_schemas = schemas;
		}
	}

	internal bool CanReportValidity => _reportValidity;

	internal bool HasSetResolver => bSetResolver;

	public XmlNameTable NameTable => _implementation.NameTable;

	public bool PreserveWhitespace
	{
		set
		{
			_preserveWhitespace = preserveWhitespace;
		}
	}

	public override bool IsReadOnly => false;

	internal XmlNamedNodeMap Entities
	{
		get
		{
			return _entities ?? (_entities = new XmlNamedNodeMap(this));
		}
		set
		{
			_entities = entities;
		}
	}

	internal bool IsLoading
	{
		get
		{
			return _isLoading;
		}
		set
		{
			_isLoading = isLoading;
		}
	}

	internal bool ActualLoadingStatus => _actualLoadingStatus;

	public override string InnerText
	{
		[param: AllowNull]
		set
		{
			throw new InvalidOperationException("Xdom_Document_Innertext");
		}
	}

	public override string InnerXml
	{
		set
		{
			LoadXml(text);
		}
	}

	public override IXmlSchemaInfo SchemaInfo
	{
		get
		{
			if (_reportValidity)
			{
				XmlElement documentElement = DocumentElement;
				if (documentElement != null)
				{
					switch (documentElement.SchemaInfo.Validity)
					{
					case XmlSchemaValidity.Valid:
						return ValidSchemaInfo;
					case XmlSchemaValidity.Invalid:
						return InvalidSchemaInfo;
					}
				}
			}
			return NotKnownSchemaInfo;
		}
	}

	public override string BaseURI => baseURI;

	internal override XPathNodeType XPNodeType => XPathNodeType.Root;

	internal bool HasEntityReferences => fEntRefNodesPresent;

	internal XmlAttribute NamespaceXml
	{
		get
		{
			if (_namespaceXml == null)
			{
				_namespaceXml = new XmlAttribute(AddAttrXmlName(strXmlns, strXml, strReservedXmlns, null), this);
				_namespaceXml.Value = strReservedXml;
			}
			return _namespaceXml;
		}
	}

	public XmlDocument()
		: this(new XmlImplementation())
	{
	}

	protected internal XmlDocument(XmlImplementation P_0)
	{
		_implementation = P_0;
		_domNameTable = new DomNameTable(this);
		strXmlns = "xmlns";
		strXml = "xml";
		strReservedXmlns = "http://www.w3.org/2000/xmlns/";
		strReservedXml = "http://www.w3.org/XML/1998/namespace";
		baseURI = string.Empty;
		objLock = new object();
		if (P_0.NameTable.GetType() == typeof(NameTable))
		{
			NameTable nameTable = (NameTable)P_0.NameTable;
			strDocumentName = nameTable.GetOrAddEntry(s_nameTableSeeds[0].key, s_nameTableSeeds[0].hash);
			strDocumentFragmentName = nameTable.GetOrAddEntry(s_nameTableSeeds[1].key, s_nameTableSeeds[1].hash);
			strCommentName = nameTable.GetOrAddEntry(s_nameTableSeeds[2].key, s_nameTableSeeds[2].hash);
			strTextName = nameTable.GetOrAddEntry(s_nameTableSeeds[3].key, s_nameTableSeeds[3].hash);
			strCDataSectionName = nameTable.GetOrAddEntry(s_nameTableSeeds[4].key, s_nameTableSeeds[4].hash);
			strEntityName = nameTable.GetOrAddEntry(s_nameTableSeeds[5].key, s_nameTableSeeds[5].hash);
			strID = nameTable.GetOrAddEntry(s_nameTableSeeds[6].key, s_nameTableSeeds[6].hash);
			strNonSignificantWhitespaceName = nameTable.GetOrAddEntry(s_nameTableSeeds[11].key, s_nameTableSeeds[11].hash);
			strSignificantWhitespaceName = nameTable.GetOrAddEntry(s_nameTableSeeds[12].key, s_nameTableSeeds[12].hash);
			strXmlns = nameTable.GetOrAddEntry(s_nameTableSeeds[7].key, s_nameTableSeeds[7].hash);
			strXml = nameTable.GetOrAddEntry(s_nameTableSeeds[8].key, s_nameTableSeeds[8].hash);
			strSpace = nameTable.GetOrAddEntry(s_nameTableSeeds[9].key, s_nameTableSeeds[9].hash);
			strLang = nameTable.GetOrAddEntry(s_nameTableSeeds[10].key, s_nameTableSeeds[10].hash);
			strReservedXmlns = nameTable.GetOrAddEntry(s_nameTableSeeds[13].key, s_nameTableSeeds[13].hash);
			strReservedXml = nameTable.GetOrAddEntry(s_nameTableSeeds[14].key, s_nameTableSeeds[14].hash);
		}
		else
		{
			XmlNameTable nameTable2 = P_0.NameTable;
			strDocumentName = nameTable2.Add("#document");
			strDocumentFragmentName = nameTable2.Add("#document-fragment");
			strCommentName = nameTable2.Add("#comment");
			strTextName = nameTable2.Add("#text");
			strCDataSectionName = nameTable2.Add("#cdata-section");
			strEntityName = nameTable2.Add("#entity");
			strID = nameTable2.Add("id");
			strNonSignificantWhitespaceName = nameTable2.Add("#whitespace");
			strSignificantWhitespaceName = nameTable2.Add("#significant-whitespace");
			strXmlns = nameTable2.Add("xmlns");
			strXml = nameTable2.Add("xml");
			strSpace = nameTable2.Add("space");
			strLang = nameTable2.Add("lang");
			strReservedXmlns = nameTable2.Add("http://www.w3.org/2000/xmlns/");
			strReservedXml = nameTable2.Add("http://www.w3.org/XML/1998/namespace");
		}
	}

	internal static void CheckName(string P_0)
	{
		int num = ValidateNames.ParseNmtoken(P_0, 0);
		if (num < P_0.Length)
		{
			throw new XmlException("Xml_BadNameChar", XmlException.BuildCharExceptionArgs(P_0, num));
		}
	}

	internal XmlName AddXmlName(string P_0, string P_1, string P_2, IXmlSchemaInfo P_3)
	{
		return _domNameTable.AddName(P_0, P_1, P_2, P_3);
	}

	internal XmlName GetXmlName(string P_0, string P_1, string P_2, IXmlSchemaInfo P_3)
	{
		return _domNameTable.GetName(P_0, P_1, P_2, P_3);
	}

	internal XmlName AddAttrXmlName(string P_0, string P_1, string P_2, IXmlSchemaInfo P_3)
	{
		XmlName xmlName = AddXmlName(P_0, P_1, P_2, P_3);
		if (!IsLoading)
		{
			object prefix = xmlName.Prefix;
			object namespaceURI = xmlName.NamespaceURI;
			object localName = xmlName.LocalName;
			if ((prefix == strXmlns || (xmlName.Prefix.Length == 0 && localName == strXmlns)) ^ (namespaceURI == strReservedXmlns))
			{
				throw new ArgumentException(System.SR.Format("Xdom_Attr_Reserved_XmlNS", P_2));
			}
		}
		return xmlName;
	}

	internal bool AddIdInfo(XmlName P_0, XmlName P_1)
	{
		if (_htElementIDAttrDecl == null || _htElementIDAttrDecl[P_0] == null)
		{
			if (_htElementIDAttrDecl == null)
			{
				_htElementIDAttrDecl = new Hashtable();
			}
			_htElementIDAttrDecl.Add(P_0, P_1);
			return true;
		}
		return false;
	}

	private XmlName GetIDInfoByElement_(XmlName P_0)
	{
		XmlName xmlName = GetXmlName(P_0.Prefix, P_0.LocalName, string.Empty, null);
		if (xmlName != null)
		{
			return (XmlName)_htElementIDAttrDecl[xmlName];
		}
		return null;
	}

	internal XmlName GetIDInfoByElement(XmlName P_0)
	{
		if (_htElementIDAttrDecl == null)
		{
			return null;
		}
		return GetIDInfoByElement_(P_0);
	}

	private static WeakReference<XmlElement> GetElement(ArrayList P_0, XmlElement P_1)
	{
		ArrayList arrayList = new ArrayList();
		foreach (WeakReference<XmlElement> item in P_0)
		{
			if (!item.TryGetTarget(out var xmlElement))
			{
				arrayList.Add(item);
			}
			else if (xmlElement == P_1)
			{
				return item;
			}
		}
		foreach (WeakReference<XmlElement> item2 in arrayList)
		{
			P_0.Remove(item2);
		}
		return null;
	}

	internal void AddElementWithId(string P_0, XmlElement P_1)
	{
		if (_htElementIdMap == null || !_htElementIdMap.Contains(P_0))
		{
			if (_htElementIdMap == null)
			{
				_htElementIdMap = new Hashtable();
			}
			ArrayList arrayList = new ArrayList();
			arrayList.Add(new WeakReference<XmlElement>(P_1));
			_htElementIdMap.Add(P_0, arrayList);
		}
		else
		{
			ArrayList arrayList2 = (ArrayList)_htElementIdMap[P_0];
			if (GetElement(arrayList2, P_1) == null)
			{
				arrayList2.Add(new WeakReference<XmlElement>(P_1));
			}
		}
	}

	internal void RemoveElementWithId(string P_0, XmlElement P_1)
	{
		if (_htElementIdMap == null || !_htElementIdMap.Contains(P_0))
		{
			return;
		}
		ArrayList arrayList = (ArrayList)_htElementIdMap[P_0];
		WeakReference<XmlElement> element = GetElement(arrayList, P_1);
		if (element != null)
		{
			arrayList.Remove(element);
			if (arrayList.Count == 0)
			{
				_htElementIdMap.Remove(P_0);
			}
		}
	}

	public override XmlNode CloneNode(bool P_0)
	{
		XmlDocument xmlDocument = Implementation.CreateDocument();
		xmlDocument.SetBaseURI(baseURI);
		if (P_0)
		{
			xmlDocument.ImportChildren(this, xmlDocument, P_0);
		}
		return xmlDocument;
	}

	internal XmlResolver GetResolver()
	{
		return _resolver;
	}

	internal override bool IsValidChildType(XmlNodeType P_0)
	{
		switch (P_0)
		{
		case XmlNodeType.ProcessingInstruction:
		case XmlNodeType.Comment:
		case XmlNodeType.Whitespace:
		case XmlNodeType.SignificantWhitespace:
			return true;
		case XmlNodeType.DocumentType:
			if (DocumentType != null)
			{
				throw new InvalidOperationException("Xdom_DualDocumentTypeNode");
			}
			return true;
		case XmlNodeType.Element:
			if (DocumentElement != null)
			{
				throw new InvalidOperationException("Xdom_DualDocumentElementNode");
			}
			return true;
		case XmlNodeType.XmlDeclaration:
			if (Declaration != null)
			{
				throw new InvalidOperationException("Xdom_DualDeclarationNode");
			}
			return true;
		default:
			return false;
		}
	}

	private static bool HasNodeTypeInPrevSiblings(XmlNodeType P_0, XmlNode P_1)
	{
		if (P_1 == null)
		{
			return false;
		}
		XmlNode xmlNode = null;
		if (P_1.ParentNode != null)
		{
			xmlNode = P_1.ParentNode.FirstChild;
		}
		while (xmlNode != null)
		{
			if (xmlNode.NodeType == P_0)
			{
				return true;
			}
			if (xmlNode == P_1)
			{
				break;
			}
			xmlNode = xmlNode.NextSibling;
		}
		return false;
	}

	private static bool HasNodeTypeInNextSiblings(XmlNodeType P_0, XmlNode P_1)
	{
		for (XmlNode xmlNode = P_1; xmlNode != null; xmlNode = xmlNode.NextSibling)
		{
			if (xmlNode.NodeType == P_0)
			{
				return true;
			}
		}
		return false;
	}

	internal override bool CanInsertAfter(XmlNode P_0, XmlNode P_1)
	{
		if (P_1 == null)
		{
			P_1 = LastChild;
		}
		if (P_1 == null)
		{
			return true;
		}
		switch (P_0.NodeType)
		{
		case XmlNodeType.ProcessingInstruction:
		case XmlNodeType.Comment:
		case XmlNodeType.Whitespace:
		case XmlNodeType.SignificantWhitespace:
			return true;
		case XmlNodeType.DocumentType:
			return !HasNodeTypeInPrevSiblings(XmlNodeType.Element, P_1);
		case XmlNodeType.Element:
			return !HasNodeTypeInNextSiblings(XmlNodeType.DocumentType, P_1.NextSibling);
		default:
			return false;
		}
	}

	internal void SetDefaultNamespace(string P_0, string P_1, ref string P_2)
	{
		if (P_0 == strXmlns || (P_0.Length == 0 && P_1 == strXmlns))
		{
			P_2 = strReservedXmlns;
		}
		else if (P_0 == strXml)
		{
			P_2 = strReservedXml;
		}
	}

	public virtual XmlCDataSection CreateCDataSection(string? P_0)
	{
		fCDataNodesPresent = true;
		return new XmlCDataSection(P_0, this);
	}

	public virtual XmlComment CreateComment(string? P_0)
	{
		return new XmlComment(P_0, this);
	}

	public virtual XmlDocumentType CreateDocumentType(string P_0, string? P_1, string? P_2, string? P_3)
	{
		return new XmlDocumentType(P_0, P_1, P_2, P_3, this);
	}

	public virtual XmlDocumentFragment CreateDocumentFragment()
	{
		return new XmlDocumentFragment(this);
	}

	internal void AddDefaultAttributes(XmlElement P_0)
	{
		SchemaInfo dtdSchemaInfo = DtdSchemaInfo;
		SchemaElementDecl schemaElementDecl = GetSchemaElementDecl(P_0);
		if (schemaElementDecl == null || schemaElementDecl.AttDefs == null)
		{
			return;
		}
		foreach (KeyValuePair<XmlQualifiedName, SchemaAttDef> attDef in schemaElementDecl.AttDefs)
		{
			SchemaAttDef value = attDef.Value;
			if (value.Presence == SchemaDeclBase.Use.Default || value.Presence == SchemaDeclBase.Use.Fixed)
			{
				string name = value.Name.Name;
				string text = string.Empty;
				string text2;
				if (dtdSchemaInfo.SchemaType == SchemaType.DTD)
				{
					text2 = value.Name.Namespace;
				}
				else
				{
					text2 = value.Prefix;
					text = value.Name.Namespace;
				}
				XmlAttribute attributeNode = PrepareDefaultAttribute(value, text2, name, text);
				P_0.SetAttributeNode(attributeNode);
			}
		}
	}

	private SchemaElementDecl GetSchemaElementDecl(XmlElement P_0)
	{
		SchemaInfo dtdSchemaInfo = DtdSchemaInfo;
		if (dtdSchemaInfo != null)
		{
			XmlQualifiedName xmlQualifiedName = new XmlQualifiedName(P_0.LocalName, (dtdSchemaInfo.SchemaType == SchemaType.DTD) ? P_0.Prefix : P_0.NamespaceURI);
			if (dtdSchemaInfo.ElementDecls.TryGetValue(xmlQualifiedName, out var result))
			{
				return result;
			}
		}
		return null;
	}

	private XmlAttribute PrepareDefaultAttribute(SchemaAttDef P_0, string P_1, string P_2, string P_3)
	{
		SetDefaultNamespace(P_1, P_2, ref P_3);
		XmlAttribute xmlAttribute = CreateDefaultAttribute(P_1, P_2, P_3);
		xmlAttribute.InnerXml = P_0.DefaultValueRaw;
		if (xmlAttribute is XmlUnspecifiedAttribute xmlUnspecifiedAttribute)
		{
			xmlUnspecifiedAttribute.SetSpecified(false);
		}
		return xmlAttribute;
	}

	public virtual XmlEntityReference CreateEntityReference(string P_0)
	{
		return new XmlEntityReference(P_0, this);
	}

	public virtual XmlProcessingInstruction CreateProcessingInstruction(string P_0, string? P_1)
	{
		ArgumentNullException.ThrowIfNull(P_0, "target");
		return new XmlProcessingInstruction(P_0, P_1, this);
	}

	public virtual XmlDeclaration CreateXmlDeclaration(string P_0, string? P_1, string? P_2)
	{
		return new XmlDeclaration(P_0, P_1, P_2, this);
	}

	public virtual XmlText CreateTextNode(string? P_0)
	{
		return new XmlText(P_0, this);
	}

	public virtual XmlSignificantWhitespace CreateSignificantWhitespace(string? P_0)
	{
		return new XmlSignificantWhitespace(P_0, this);
	}

	public override XPathNavigator? CreateNavigator()
	{
		return CreateNavigator(this);
	}

	protected internal virtual XPathNavigator? CreateNavigator(XmlNode P_0)
	{
		switch (P_0.NodeType)
		{
		case XmlNodeType.EntityReference:
		case XmlNodeType.Entity:
		case XmlNodeType.DocumentType:
		case XmlNodeType.Notation:
		case XmlNodeType.XmlDeclaration:
			return null;
		case XmlNodeType.Text:
		case XmlNodeType.CDATA:
		case XmlNodeType.SignificantWhitespace:
		{
			XmlNode xmlNode = P_0.ParentNode;
			if (xmlNode != null)
			{
				do
				{
					switch (xmlNode.NodeType)
					{
					case XmlNodeType.Attribute:
						return null;
					case XmlNodeType.EntityReference:
						goto IL_006a;
					}
					break;
					IL_006a:
					xmlNode = xmlNode.ParentNode;
				}
				while (xmlNode != null);
			}
			P_0 = NormalizeText(P_0);
			break;
		}
		case XmlNodeType.Whitespace:
		{
			XmlNode xmlNode = P_0.ParentNode;
			if (xmlNode != null)
			{
				do
				{
					switch (xmlNode.NodeType)
					{
					case XmlNodeType.Attribute:
					case XmlNodeType.Document:
						return null;
					case XmlNodeType.EntityReference:
						goto IL_009e;
					}
					break;
					IL_009e:
					xmlNode = xmlNode.ParentNode;
				}
				while (xmlNode != null);
			}
			P_0 = NormalizeText(P_0);
			break;
		}
		}
		return new DocumentXPathNavigator(this, P_0);
	}

	internal static bool IsTextNode(XmlNodeType P_0)
	{
		if ((uint)(P_0 - 3) <= 1u || (uint)(P_0 - 13) <= 1u)
		{
			return true;
		}
		return false;
	}

	private static XmlNode NormalizeText(XmlNode P_0)
	{
		XmlNode xmlNode = null;
		XmlNode xmlNode2 = P_0;
		while (IsTextNode(xmlNode2.NodeType))
		{
			xmlNode = xmlNode2;
			xmlNode2 = xmlNode2.PreviousSibling;
			if (xmlNode2 == null)
			{
				XmlNode xmlNode3 = xmlNode;
				while (xmlNode3.ParentNode != null && xmlNode3.ParentNode.NodeType == XmlNodeType.EntityReference)
				{
					if (xmlNode3.ParentNode.PreviousSibling != null)
					{
						xmlNode2 = xmlNode3.ParentNode.PreviousSibling;
						break;
					}
					xmlNode3 = xmlNode3.ParentNode;
					if (xmlNode3 == null)
					{
						break;
					}
				}
			}
			if (xmlNode2 == null)
			{
				break;
			}
			while (xmlNode2.NodeType == XmlNodeType.EntityReference)
			{
				xmlNode2 = xmlNode2.LastChild;
			}
		}
		return xmlNode;
	}

	public virtual XmlWhitespace CreateWhitespace(string? P_0)
	{
		return new XmlWhitespace(P_0, this);
	}

	public virtual XmlElement? GetElementById(string P_0)
	{
		if (_htElementIdMap != null)
		{
			ArrayList arrayList = (ArrayList)_htElementIdMap[P_0];
			if (arrayList != null)
			{
				foreach (WeakReference<XmlElement> item in arrayList)
				{
					if (item.TryGetTarget(out var xmlElement) && xmlElement.IsConnected())
					{
						return xmlElement;
					}
				}
			}
		}
		return null;
	}

	private XmlNode ImportNodeInternal(XmlNode P_0, bool P_1)
	{
		if (P_0 == null)
		{
			throw new InvalidOperationException("Xdom_Import_NullNode");
		}
		XmlNode xmlNode;
		switch (P_0.NodeType)
		{
		case XmlNodeType.Element:
			xmlNode = CreateElement(P_0.Prefix, P_0.LocalName, P_0.NamespaceURI);
			ImportAttributes(P_0, xmlNode);
			if (P_1)
			{
				ImportChildren(P_0, xmlNode, P_1);
			}
			break;
		case XmlNodeType.Attribute:
			xmlNode = CreateAttribute(P_0.Prefix, P_0.LocalName, P_0.NamespaceURI);
			ImportChildren(P_0, xmlNode, true);
			break;
		case XmlNodeType.Text:
			xmlNode = CreateTextNode(P_0.Value);
			break;
		case XmlNodeType.Comment:
			xmlNode = CreateComment(P_0.Value);
			break;
		case XmlNodeType.ProcessingInstruction:
			xmlNode = CreateProcessingInstruction(P_0.Name, P_0.Value);
			break;
		case XmlNodeType.XmlDeclaration:
		{
			XmlDeclaration xmlDeclaration = (XmlDeclaration)P_0;
			xmlNode = CreateXmlDeclaration(xmlDeclaration.Version, xmlDeclaration.Encoding, xmlDeclaration.Standalone);
			break;
		}
		case XmlNodeType.CDATA:
			xmlNode = CreateCDataSection(P_0.Value);
			break;
		case XmlNodeType.DocumentType:
		{
			XmlDocumentType xmlDocumentType = (XmlDocumentType)P_0;
			xmlNode = CreateDocumentType(xmlDocumentType.Name, xmlDocumentType.PublicId, xmlDocumentType.SystemId, xmlDocumentType.InternalSubset);
			break;
		}
		case XmlNodeType.DocumentFragment:
			xmlNode = CreateDocumentFragment();
			if (P_1)
			{
				ImportChildren(P_0, xmlNode, P_1);
			}
			break;
		case XmlNodeType.EntityReference:
			xmlNode = CreateEntityReference(P_0.Name);
			break;
		case XmlNodeType.Whitespace:
			xmlNode = CreateWhitespace(P_0.Value);
			break;
		case XmlNodeType.SignificantWhitespace:
			xmlNode = CreateSignificantWhitespace(P_0.Value);
			break;
		default:
			throw new InvalidOperationException(System.SR.Format(CultureInfo.InvariantCulture, "Xdom_Import", P_0.NodeType));
		}
		return xmlNode;
	}

	private void ImportAttributes(XmlNode P_0, XmlNode P_1)
	{
		int count = P_0.Attributes.Count;
		for (int i = 0; i < count; i++)
		{
			if (P_0.Attributes[i].Specified)
			{
				P_1.Attributes.SetNamedItem(ImportNodeInternal(P_0.Attributes[i], true));
			}
		}
	}

	private void ImportChildren(XmlNode P_0, XmlNode P_1, bool P_2)
	{
		for (XmlNode xmlNode = P_0.FirstChild; xmlNode != null; xmlNode = xmlNode.NextSibling)
		{
			P_1.AppendChild(ImportNodeInternal(xmlNode, P_2));
		}
	}

	public virtual XmlAttribute CreateAttribute(string? P_0, string P_1, string? P_2)
	{
		return new XmlAttribute(AddAttrXmlName(P_0, P_1, P_2, null), this);
	}

	protected internal virtual XmlAttribute CreateDefaultAttribute(string? P_0, string P_1, string? P_2)
	{
		return new XmlUnspecifiedAttribute(P_0, P_1, P_2, this);
	}

	public virtual XmlElement CreateElement(string? P_0, string P_1, string? P_2)
	{
		XmlElement xmlElement = new XmlElement(AddXmlName(P_0, P_1, P_2, null), true, this);
		if (!IsLoading)
		{
			AddDefaultAttributes(xmlElement);
		}
		return xmlElement;
	}

	private XmlTextReader SetupReader(XmlTextReader P_0)
	{
		P_0.XmlValidatingReaderCompatibilityMode = true;
		P_0.EntityHandling = EntityHandling.ExpandCharEntities;
		if (HasSetResolver)
		{
			P_0.XmlResolver = GetResolver();
		}
		return P_0;
	}

	public virtual void Load(TextReader P_0)
	{
		XmlTextReader xmlTextReader = SetupReader(new XmlTextReader(P_0, NameTable));
		try
		{
			Load(xmlTextReader);
		}
		finally
		{
			xmlTextReader.Impl.Close(false);
		}
	}

	public virtual void Load(XmlReader P_0)
	{
		try
		{
			IsLoading = true;
			_actualLoadingStatus = true;
			RemoveAll();
			fEntRefNodesPresent = false;
			fCDataNodesPresent = false;
			_reportValidity = true;
			XmlLoader xmlLoader = new XmlLoader();
			xmlLoader.Load(this, P_0, _preserveWhitespace);
		}
		finally
		{
			IsLoading = false;
			_actualLoadingStatus = false;
			_reportValidity = true;
		}
	}

	public virtual void LoadXml([StringSyntax("Xml")] string P_0)
	{
		XmlTextReader xmlTextReader = SetupReader(new XmlTextReader(new StringReader(P_0), NameTable));
		try
		{
			Load(xmlTextReader);
		}
		finally
		{
			xmlTextReader.Close();
		}
	}

	internal override XmlNodeChangedEventArgs GetEventArgs(XmlNode P_0, XmlNode P_1, XmlNode P_2, string P_3, string P_4, XmlNodeChangedAction P_5)
	{
		_reportValidity = false;
		switch (P_5)
		{
		case XmlNodeChangedAction.Insert:
			if (_onNodeInsertingDelegate == null && _onNodeInsertedDelegate == null)
			{
				return null;
			}
			break;
		case XmlNodeChangedAction.Remove:
			if (_onNodeRemovingDelegate == null && _onNodeRemovedDelegate == null)
			{
				return null;
			}
			break;
		case XmlNodeChangedAction.Change:
			if (_onNodeChangingDelegate == null && _onNodeChangedDelegate == null)
			{
				return null;
			}
			break;
		}
		return new XmlNodeChangedEventArgs(P_0, P_1, P_2, P_3, P_4, P_5);
	}

	internal XmlNodeChangedEventArgs GetInsertEventArgsForLoad(XmlNode P_0, XmlNode P_1)
	{
		if (_onNodeInsertingDelegate == null && _onNodeInsertedDelegate == null)
		{
			return null;
		}
		string value = P_0.Value;
		return new XmlNodeChangedEventArgs(P_0, null, P_1, value, value, XmlNodeChangedAction.Insert);
	}

	internal override void BeforeEvent(XmlNodeChangedEventArgs P_0)
	{
		if (P_0 != null)
		{
			switch (P_0.Action)
			{
			case XmlNodeChangedAction.Insert:
				_onNodeInsertingDelegate?.Invoke(this, P_0);
				break;
			case XmlNodeChangedAction.Remove:
				_onNodeRemovingDelegate?.Invoke(this, P_0);
				break;
			case XmlNodeChangedAction.Change:
				_onNodeChangingDelegate?.Invoke(this, P_0);
				break;
			}
		}
	}

	internal override void AfterEvent(XmlNodeChangedEventArgs P_0)
	{
		if (P_0 != null)
		{
			switch (P_0.Action)
			{
			case XmlNodeChangedAction.Insert:
				_onNodeInsertedDelegate?.Invoke(this, P_0);
				break;
			case XmlNodeChangedAction.Remove:
				_onNodeRemovedDelegate?.Invoke(this, P_0);
				break;
			case XmlNodeChangedAction.Change:
				_onNodeChangedDelegate?.Invoke(this, P_0);
				break;
			}
		}
	}

	internal XmlAttribute GetDefaultAttribute(XmlElement P_0, string P_1, string P_2, string P_3)
	{
		SchemaInfo dtdSchemaInfo = DtdSchemaInfo;
		SchemaElementDecl schemaElementDecl = GetSchemaElementDecl(P_0);
		if (schemaElementDecl != null && schemaElementDecl.AttDefs != null)
		{
			foreach (KeyValuePair<XmlQualifiedName, SchemaAttDef> attDef in schemaElementDecl.AttDefs)
			{
				SchemaAttDef value = attDef.Value;
				if ((value.Presence == SchemaDeclBase.Use.Default || value.Presence == SchemaDeclBase.Use.Fixed) && value.Name.Name == P_2 && ((dtdSchemaInfo.SchemaType == SchemaType.DTD && value.Name.Namespace == P_1) || (dtdSchemaInfo.SchemaType != SchemaType.DTD && value.Name.Namespace == P_3)))
				{
					return PrepareDefaultAttribute(value, P_1, P_2, P_3);
				}
			}
		}
		return null;
	}

	internal XmlEntity GetEntityNode(string P_0)
	{
		if (DocumentType != null)
		{
			XmlNamedNodeMap entities = DocumentType.Entities;
			if (entities != null)
			{
				return (XmlEntity)entities.GetNamedItem(P_0);
			}
		}
		return null;
	}

	internal void SetBaseURI(string P_0)
	{
		baseURI = P_0;
	}

	internal override XmlNode AppendChildForLoad(XmlNode P_0, XmlDocument P_1)
	{
		if (!IsValidChildType(P_0.NodeType))
		{
			throw new InvalidOperationException("Xdom_Node_Insert_TypeConflict");
		}
		if (!CanInsertAfter(P_0, LastChild))
		{
			throw new InvalidOperationException("Xdom_Node_Insert_Location");
		}
		XmlNodeChangedEventArgs insertEventArgsForLoad = GetInsertEventArgsForLoad(P_0, this);
		if (insertEventArgsForLoad != null)
		{
			BeforeEvent(insertEventArgsForLoad);
		}
		XmlLinkedNode xmlLinkedNode = (XmlLinkedNode)P_0;
		if (_lastChild == null)
		{
			xmlLinkedNode.next = xmlLinkedNode;
		}
		else
		{
			xmlLinkedNode.next = _lastChild.next;
			_lastChild.next = xmlLinkedNode;
		}
		_lastChild = xmlLinkedNode;
		xmlLinkedNode.SetParentForLoad(this);
		if (insertEventArgsForLoad != null)
		{
			AfterEvent(insertEventArgsForLoad);
		}
		return xmlLinkedNode;
	}
}
