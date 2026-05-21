namespace System.Xml.Schema;

internal class Datatype_anySimpleType : DatatypeImplementation
{
	private static readonly Type s_atomicValueType = typeof(string);

	private static readonly Type s_listValueType = typeof(string[]);

	internal override FacetsChecker FacetsChecker => DatatypeImplementation.miscFacetsChecker;

	public override Type ValueType => s_atomicValueType;

	public override XmlTypeCode TypeCode => XmlTypeCode.AnyAtomicType;

	internal override Type ListValueType => s_listValueType;

	public override XmlTokenizedType TokenizedType => XmlTokenizedType.None;

	internal override XmlSchemaWhiteSpace BuiltInWhitespaceFacet => XmlSchemaWhiteSpace.Collapse;

	internal override XmlValueConverter CreateValueConverter(XmlSchemaType P_0)
	{
		return XmlUntypedConverter.Untyped;
	}

	internal override int Compare(object P_0, object P_1)
	{
		return string.Compare(P_0.ToString(), P_1.ToString(), StringComparison.Ordinal);
	}

	internal override Exception TryParseValue(string P_0, XmlNameTable P_1, IXmlNamespaceResolver P_2, out object P_3)
	{
		P_3 = XmlComplianceUtil.NonCDataNormalize(P_0);
		return null;
	}
}
