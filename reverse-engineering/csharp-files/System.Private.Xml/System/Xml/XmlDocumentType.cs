using System.Xml.Schema;

namespace System.Xml;

public class XmlDocumentType : XmlLinkedNode
{
	private readonly string _name;

	private readonly string _publicId;

	private readonly string _systemId;

	private readonly string _internalSubset;

	private bool _namespaces;

	private XmlNamedNodeMap _entities;

	private XmlNamedNodeMap _notations;

	private SchemaInfo _schemaInfo;

	public override string Name => _name;

	public override string LocalName => _name;

	public override XmlNodeType NodeType => XmlNodeType.DocumentType;

	public override bool IsReadOnly => true;

	public XmlNamedNodeMap Entities => _entities ?? (_entities = new XmlNamedNodeMap(this));

	public XmlNamedNodeMap Notations => _notations ?? (_notations = new XmlNamedNodeMap(this));

	public string? PublicId => _publicId;

	public string? SystemId => _systemId;

	public string? InternalSubset => _internalSubset;

	internal bool ParseWithNamespaces => _namespaces;

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

	protected internal XmlDocumentType(string P_0, string? P_1, string? P_2, string? P_3, XmlDocument P_4)
		: base(P_4)
	{
		_name = P_0;
		_publicId = P_1;
		_systemId = P_2;
		_namespaces = true;
		_internalSubset = P_3;
		if (!P_4.IsLoading)
		{
			P_4.IsLoading = true;
			XmlLoader xmlLoader = new XmlLoader();
			xmlLoader.ParseDocumentType(this);
			P_4.IsLoading = false;
		}
	}

	public override XmlNode CloneNode(bool P_0)
	{
		return OwnerDocument.CreateDocumentType(_name, _publicId, _systemId, _internalSubset);
	}
}
