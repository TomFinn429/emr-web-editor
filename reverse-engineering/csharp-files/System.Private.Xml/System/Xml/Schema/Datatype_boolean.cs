namespace System.Xml.Schema;

internal sealed class Datatype_boolean : Datatype_anySimpleType
{
	private static readonly Type s_atomicValueType = typeof(bool);

	private static readonly Type s_listValueType = typeof(bool[]);

	internal override FacetsChecker FacetsChecker => DatatypeImplementation.miscFacetsChecker;

	public override XmlTypeCode TypeCode => XmlTypeCode.Boolean;

	public override Type ValueType => s_atomicValueType;

	internal override Type ListValueType => s_listValueType;

	internal override XmlSchemaWhiteSpace BuiltInWhitespaceFacet => XmlSchemaWhiteSpace.Collapse;

	internal override XmlValueConverter CreateValueConverter(XmlSchemaType P_0)
	{
		return XmlBooleanConverter.Create(P_0);
	}

	internal override int Compare(object P_0, object P_1)
	{
		return ((bool)P_0).CompareTo((bool)P_1);
	}

	internal override Exception TryParseValue(string P_0, XmlNameTable P_1, IXmlNamespaceResolver P_2, out object P_3)
	{
		P_3 = null;
		Exception ex = DatatypeImplementation.miscFacetsChecker.CheckLexicalFacets(ref P_0, this);
		if (ex == null)
		{
			ex = XmlConvert.TryToBoolean(P_0, out var flag);
			if (ex == null)
			{
				P_3 = flag;
				return null;
			}
		}
		return ex;
	}
}
