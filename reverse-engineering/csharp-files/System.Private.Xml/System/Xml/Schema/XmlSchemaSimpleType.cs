using System.Xml.Serialization;

namespace System.Xml.Schema;

public class XmlSchemaSimpleType : XmlSchemaType
{
	private XmlSchemaSimpleTypeContent _content;

	[XmlElement("restriction", typeof(XmlSchemaSimpleTypeRestriction))]
	[XmlElement("list", typeof(XmlSchemaSimpleTypeList))]
	[XmlElement("union", typeof(XmlSchemaSimpleTypeUnion))]
	public XmlSchemaSimpleTypeContent? Content
	{
		get
		{
			return _content;
		}
		set
		{
			_content = content;
		}
	}
}
