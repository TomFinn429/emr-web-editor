namespace System.Xml.Schema;

internal class Datatype_double : Datatype_anySimpleType
{
	private static readonly Type s_atomicValueType = typeof(double);

	private static readonly Type s_listValueType = typeof(double[]);

	internal override FacetsChecker FacetsChecker => DatatypeImplementation.numeric2FacetsChecker;

	public override XmlTypeCode TypeCode => XmlTypeCode.Double;

	public override Type ValueType => s_atomicValueType;

	internal override Type ListValueType => s_listValueType;

	internal override XmlSchemaWhiteSpace BuiltInWhitespaceFacet => XmlSchemaWhiteSpace.Collapse;

	internal override XmlValueConverter CreateValueConverter(XmlSchemaType P_0)
	{
		return XmlNumeric2Converter.Create(P_0);
	}

	internal override int Compare(object P_0, object P_1)
	{
		return ((double)P_0).CompareTo((double)P_1);
	}

	internal override Exception TryParseValue(string P_0, XmlNameTable P_1, IXmlNamespaceResolver P_2, out object P_3)
	{
		P_3 = null;
		Exception ex = DatatypeImplementation.numeric2FacetsChecker.CheckLexicalFacets(ref P_0, this);
		if (ex == null)
		{
			ex = XmlConvert.TryToDouble(P_0, out var num);
			if (ex == null)
			{
				ex = DatatypeImplementation.numeric2FacetsChecker.CheckValueFacets(num, this);
				if (ex == null)
				{
					P_3 = num;
					return null;
				}
			}
		}
		return ex;
	}
}
