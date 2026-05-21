namespace System.Xml.Schema;

internal sealed class Datatype_anyURI : Datatype_anySimpleType
{
	private static readonly Type s_atomicValueType = typeof(Uri);

	private static readonly Type s_listValueType = typeof(Uri[]);

	internal override FacetsChecker FacetsChecker => DatatypeImplementation.stringFacetsChecker;

	public override XmlTypeCode TypeCode => XmlTypeCode.AnyUri;

	public override Type ValueType => s_atomicValueType;

	internal override Type ListValueType => s_listValueType;

	internal override XmlSchemaWhiteSpace BuiltInWhitespaceFacet => XmlSchemaWhiteSpace.Collapse;

	internal override XmlValueConverter CreateValueConverter(XmlSchemaType P_0)
	{
		return XmlMiscConverter.Create(P_0);
	}

	internal override int Compare(object P_0, object P_1)
	{
		if (!((Uri)P_0).Equals((Uri)P_1))
		{
			return -1;
		}
		return 0;
	}

	internal override Exception TryParseValue(string P_0, XmlNameTable P_1, IXmlNamespaceResolver P_2, out object P_3)
	{
		P_3 = null;
		Exception ex = DatatypeImplementation.stringFacetsChecker.CheckLexicalFacets(ref P_0, this);
		if (ex == null)
		{
			ex = XmlConvert.TryToUri(P_0, out var uri);
			if (ex == null)
			{
				string originalString = uri.OriginalString;
				ex = StringFacetsChecker.CheckValueFacets(originalString, this, false);
				if (ex == null)
				{
					P_3 = uri;
					return null;
				}
			}
		}
		return ex;
	}
}
