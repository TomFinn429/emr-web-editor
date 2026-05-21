namespace System.Xml.Schema;

internal sealed class Datatype_char : Datatype_anySimpleType
{
	private static readonly Type s_atomicValueType = typeof(char);

	private static readonly Type s_listValueType = typeof(char[]);

	public override Type ValueType => s_atomicValueType;

	internal override Type ListValueType => s_listValueType;

	internal override int Compare(object P_0, object P_1)
	{
		return ((char)P_0).CompareTo((char)P_1);
	}

	public override object ParseValue(string P_0, XmlNameTable P_1, IXmlNamespaceResolver P_2)
	{
		try
		{
			return XmlConvert.ToChar(P_0);
		}
		catch (XmlSchemaException)
		{
			throw;
		}
		catch (Exception ex2)
		{
			throw new XmlSchemaException(System.SR.Format("Sch_InvalidValue", P_0), ex2);
		}
	}

	internal override Exception TryParseValue(string P_0, XmlNameTable P_1, IXmlNamespaceResolver P_2, out object P_3)
	{
		P_3 = null;
		char c;
		Exception ex = XmlConvert.TryToChar(P_0, out c);
		if (ex == null)
		{
			P_3 = c;
			return null;
		}
		return ex;
	}
}
