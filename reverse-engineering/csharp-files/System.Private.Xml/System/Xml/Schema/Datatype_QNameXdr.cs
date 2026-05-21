namespace System.Xml.Schema;

internal sealed class Datatype_QNameXdr : Datatype_anySimpleType
{
	private static readonly Type s_atomicValueType = typeof(XmlQualifiedName);

	private static readonly Type s_listValueType = typeof(XmlQualifiedName[]);

	public override XmlTokenizedType TokenizedType => XmlTokenizedType.QName;

	public override Type ValueType => s_atomicValueType;

	internal override Type ListValueType => s_listValueType;

	public override object ParseValue(string P_0, XmlNameTable P_1, IXmlNamespaceResolver P_2)
	{
		if (P_0 == null || P_0.Length == 0)
		{
			throw new XmlSchemaException("Sch_EmptyAttributeValue", string.Empty);
		}
		ArgumentNullException.ThrowIfNull(P_2, "nsmgr");
		try
		{
			string text;
			return XmlQualifiedName.Parse(P_0.Trim(), P_2, out text);
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
}
