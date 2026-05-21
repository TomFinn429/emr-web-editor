namespace System.Xml.Schema;

public class XmlSchemaInfo : IXmlSchemaInfo
{
	private bool _isDefault;

	private bool _isNil;

	private XmlSchemaElement _schemaElement;

	private XmlSchemaAttribute _schemaAttribute;

	private XmlSchemaType _schemaType;

	private XmlSchemaSimpleType _memberType;

	private XmlSchemaValidity _validity;

	private XmlSchemaContentType _contentType;

	public XmlSchemaValidity Validity => _validity;

	public bool IsDefault => _isDefault;

	public bool IsNil => _isNil;

	public XmlSchemaSimpleType? MemberType => _memberType;

	public XmlSchemaType? SchemaType => _schemaType;

	public XmlSchemaElement? SchemaElement => _schemaElement;

	public XmlSchemaAttribute? SchemaAttribute => _schemaAttribute;

	public XmlSchemaInfo()
	{
		Clear();
	}

	internal XmlSchemaInfo(XmlSchemaValidity P_0)
		: this()
	{
		_validity = P_0;
	}

	internal void Clear()
	{
		_isNil = false;
		_isDefault = false;
		_schemaType = null;
		_schemaElement = null;
		_schemaAttribute = null;
		_memberType = null;
		_validity = XmlSchemaValidity.NotKnown;
		_contentType = XmlSchemaContentType.Empty;
	}
}
