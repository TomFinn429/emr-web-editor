namespace System.Xml.Schema;

internal sealed class Datatype_uuid : Datatype_anySimpleType
{
	private static readonly Type s_atomicValueType = typeof(Guid);

	private static readonly Type s_listValueType = typeof(Guid[]);

	public override Type ValueType => s_atomicValueType;

	internal override Type ListValueType => s_listValueType;

	internal override int Compare(object P_0, object P_1)
	{
		if (!((Guid)P_0/*cast due to .constrained prefix*/).Equals(P_1))
		{
			return -1;
		}
		return 0;
	}

	public override object ParseValue(string P_0, XmlNameTable P_1, IXmlNamespaceResolver P_2)
	{
		try
		{
			return XmlConvert.ToGuid(P_0);
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
		Guid guid;
		Exception ex = XmlConvert.TryToGuid(P_0, out guid);
		if (ex == null)
		{
			P_3 = guid;
			return null;
		}
		return ex;
	}
}
