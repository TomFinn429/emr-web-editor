using System.Xml.Serialization;

namespace System.Xml.Schema;

public class XmlSchemaSimpleTypeRestriction : XmlSchemaSimpleTypeContent
{
	private XmlQualifiedName _baseTypeName = XmlQualifiedName.Empty;

	private readonly XmlSchemaObjectCollection _facets = new XmlSchemaObjectCollection();

	[XmlAttribute("base")]
	public XmlQualifiedName BaseTypeName
	{
		set
		{
			_baseTypeName = xmlQualifiedName ?? XmlQualifiedName.Empty;
		}
	}
}
