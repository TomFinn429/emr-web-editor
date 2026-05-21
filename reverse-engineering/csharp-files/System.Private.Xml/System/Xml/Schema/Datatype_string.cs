namespace System.Xml.Schema;

internal class Datatype_string : Datatype_anySimpleType
{
	internal override XmlSchemaWhiteSpace BuiltInWhitespaceFacet => XmlSchemaWhiteSpace.Preserve;

	internal override FacetsChecker FacetsChecker => DatatypeImplementation.stringFacetsChecker;

	public override XmlTypeCode TypeCode => XmlTypeCode.String;

	public override XmlTokenizedType TokenizedType => XmlTokenizedType.CDATA;

	internal override XmlValueConverter CreateValueConverter(XmlSchemaType P_0)
	{
		return XmlStringConverter.Create(P_0);
	}

	internal override Exception TryParseValue(string P_0, XmlNameTable P_1, IXmlNamespaceResolver P_2, out object P_3)
	{
		P_3 = null;
		Exception ex = DatatypeImplementation.stringFacetsChecker.CheckLexicalFacets(ref P_0, this);
		if (ex == null)
		{
			ex = DatatypeImplementation.stringFacetsChecker.CheckValueFacets(P_0, this);
			if (ex == null)
			{
				P_3 = P_0;
				return null;
			}
		}
		return ex;
	}
}
