namespace System.Xml.Schema;

internal sealed class Datatype_QName : Datatype_anySimpleType
{
	private static readonly Type s_atomicValueType = typeof(XmlQualifiedName);

	private static readonly Type s_listValueType = typeof(XmlQualifiedName[]);

	internal override FacetsChecker FacetsChecker => DatatypeImplementation.qnameFacetsChecker;

	public override XmlTypeCode TypeCode => XmlTypeCode.QName;

	public override XmlTokenizedType TokenizedType => XmlTokenizedType.QName;

	public override Type ValueType => s_atomicValueType;

	internal override Type ListValueType => s_listValueType;

	internal override XmlSchemaWhiteSpace BuiltInWhitespaceFacet => XmlSchemaWhiteSpace.Collapse;

	internal override XmlValueConverter CreateValueConverter(XmlSchemaType P_0)
	{
		return XmlMiscConverter.Create(P_0);
	}

	internal override Exception TryParseValue(string P_0, XmlNameTable P_1, IXmlNamespaceResolver P_2, out object P_3)
	{
		P_3 = null;
		if (P_0 == null || P_0.Length == 0)
		{
			return new XmlSchemaException("Sch_EmptyAttributeValue", string.Empty);
		}
		Exception ex = DatatypeImplementation.qnameFacetsChecker.CheckLexicalFacets(ref P_0, this);
		if (ex == null)
		{
			XmlQualifiedName xmlQualifiedName;
			try
			{
				xmlQualifiedName = XmlQualifiedName.Parse(P_0, P_2, out var _);
			}
			catch (ArgumentException ex2)
			{
				ex = ex2;
				goto IL_005f;
			}
			catch (XmlException ex3)
			{
				ex = ex3;
				goto IL_005f;
			}
			ex = DatatypeImplementation.qnameFacetsChecker.CheckValueFacets(xmlQualifiedName, this);
			if (ex == null)
			{
				P_3 = xmlQualifiedName;
				return null;
			}
		}
		goto IL_005f;
		IL_005f:
		return ex;
	}
}
