namespace System.Xml.Schema;

internal sealed class Datatype_floatXdr : Datatype_float
{
	public override object ParseValue(string P_0, XmlNameTable P_1, IXmlNamespaceResolver P_2)
	{
		float num;
		try
		{
			num = XmlConvert.ToSingle(P_0);
		}
		catch (Exception ex)
		{
			throw new XmlSchemaException(System.SR.Format("Sch_InvalidValue", P_0), ex);
		}
		if (!float.IsFinite(num))
		{
			throw new XmlSchemaException("Sch_InvalidValue", P_0);
		}
		return num;
	}
}
