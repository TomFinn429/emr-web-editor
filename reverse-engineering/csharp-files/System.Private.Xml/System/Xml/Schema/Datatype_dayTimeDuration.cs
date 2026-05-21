namespace System.Xml.Schema;

internal sealed class Datatype_dayTimeDuration : Datatype_duration
{
	public override XmlTypeCode TypeCode => XmlTypeCode.DayTimeDuration;

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
			ex = XsdDuration.TryParse(P_0, XsdDuration.DurationType.DayTimeDuration, out var xsdDuration);
			if (ex == null)
			{
				ex = xsdDuration.TryToTimeSpan(XsdDuration.DurationType.DayTimeDuration, out var timeSpan);
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
		}
		return ex;
	}
}
