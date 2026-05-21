namespace System.Xml.Schema;

internal class Datatype_duration : Datatype_anySimpleType
{
	private static readonly Type s_atomicValueType = typeof(TimeSpan);

	private static readonly Type s_listValueType = typeof(TimeSpan[]);

	internal override FacetsChecker FacetsChecker => DatatypeImplementation.durationFacetsChecker;

	public override XmlTypeCode TypeCode => XmlTypeCode.Duration;

	public override Type ValueType => s_atomicValueType;

	internal override Type ListValueType => s_listValueType;

	internal override XmlSchemaWhiteSpace BuiltInWhitespaceFacet => XmlSchemaWhiteSpace.Collapse;

	internal override XmlValueConverter CreateValueConverter(XmlSchemaType P_0)
	{
		return XmlMiscConverter.Create(P_0);
	}

	internal override int Compare(object P_0, object P_1)
	{
		return ((TimeSpan)P_0).CompareTo((TimeSpan)P_1);
	}

	internal override Exception TryParseValue(string P_0, XmlNameTable P_1, IXmlNamespaceResolver P_2, out object P_3)
	{
		P_3 = null;
		if (P_0 == null || P_0.Length == 0)
		{
			return new XmlSchemaException("Sch_EmptyAttributeValue", string.Empty);
		}
		Exception ex = DatatypeImplementation.durationFacetsChecker.CheckLexicalFacets(ref P_0, this);
		if (ex == null)
		{
			ex = XmlConvert.TryToTimeSpan(P_0, out var timeSpan);
			if (ex == null)
			{
				ex = DatatypeImplementation.durationFacetsChecker.CheckValueFacets(timeSpan, this);
				if (ex == null)
				{
					P_3 = timeSpan;
					return null;
				}
			}
		}
		return ex;
	}
}
