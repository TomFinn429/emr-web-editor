using System.Xml.Serialization;

namespace System.Xml.Schema;

public class XmlSchemaSimpleTypeList : XmlSchemaSimpleTypeContent
{
	private XmlQualifiedName _itemTypeName = XmlQualifiedName.Empty;

	private XmlSchemaSimpleType _itemType;

	private XmlSchemaSimpleType _baseItemType;

	[XmlElement("simpleType", typeof(XmlSchemaSimpleType))]
	public XmlSchemaSimpleType? ItemType
	{
		set
		{
			_itemType = itemType;
		}
	}

	[XmlIgnore]
	public XmlSchemaSimpleType? BaseItemType
	{
		get
		{
			return _baseItemType;
		}
		set
		{
			_baseItemType = baseItemType;
		}
	}
}
