namespace System.Xml.Schema;

internal sealed class DtdValidator : BaseValidator
{
	public static void SetDefaultTypedValue(SchemaAttDef P_0, IDtdParserAdapter P_1)
	{
		try
		{
			string text = P_0.DefaultValueExpanded;
			XmlSchemaDatatype datatype = P_0.Datatype;
			if (datatype != null)
			{
				if (datatype.TokenizedType != XmlTokenizedType.CDATA)
				{
					text = text.Trim();
				}
				P_0.DefaultValueTyped = datatype.ParseValue(text, P_1.NameTable, P_1.NamespaceResolver);
			}
		}
		catch (Exception)
		{
			IValidationEventHandling validationEventHandling = ((IDtdParserAdapterWithValidation)P_1).ValidationEventHandling;
			if (validationEventHandling != null)
			{
				XmlSchemaException ex2 = new XmlSchemaException("Sch_AttributeDefaultDataType", P_0.Name.ToString());
				validationEventHandling.SendEvent(ex2, XmlSeverityType.Error);
			}
		}
	}
}
