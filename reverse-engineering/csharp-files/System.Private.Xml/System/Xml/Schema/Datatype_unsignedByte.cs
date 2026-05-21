namespace System.Xml.Schema;

internal sealed class Datatype_unsignedByte : Datatype_unsignedShort
{
	private static readonly Type s_atomicValueType = typeof(byte);

	private static readonly Type s_listValueType = typeof(byte[]);

	private static readonly FacetsChecker s_numeric10FacetsChecker = new Numeric10FacetsChecker(0m, 255m);

	internal override FacetsChecker FacetsChecker => s_numeric10FacetsChecker;

	public override XmlTypeCode TypeCode => XmlTypeCode.UnsignedByte;

	public override Type ValueType => s_atomicValueType;

	internal override Type ListValueType => s_listValueType;

	internal override int Compare(object P_0, object P_1)
	{
		return ((byte)P_0).CompareTo((byte)P_1);
	}

	internal override Exception TryParseValue(string P_0, XmlNameTable P_1, IXmlNamespaceResolver P_2, out object P_3)
	{
		P_3 = null;
		Exception ex = s_numeric10FacetsChecker.CheckLexicalFacets(ref P_0, this);
		if (ex == null)
		{
			ex = XmlConvert.TryToByte(P_0, out var b);
			if (ex == null)
			{
				ex = s_numeric10FacetsChecker.CheckValueFacets(b, this);
				if (ex == null)
				{
					P_3 = b;
					return null;
				}
			}
		}
		return ex;
	}
}
