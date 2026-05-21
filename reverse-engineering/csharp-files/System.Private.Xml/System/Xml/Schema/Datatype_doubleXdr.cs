namespace System.Xml.Schema;

internal sealed class Datatype_doubleXdr : Datatype_double
{
	public override object ParseValue(string P_0, XmlNameTable P_1, IXmlNamespaceResolver P_2)
	{
		double num;
		try
		{
			num = XmlConvert.ToDouble(P_0);
		}
		catch (Exception ex)
		{
			throw new XmlSchemaException(System.SR.Format("Sch_InvalidValue", P_0), ex);
		}
		if (!double.IsFinite(num))
		{
			throw new XmlSchemaException("Sch_InvalidValue", P_0);
		}
		return num;
	}
}
