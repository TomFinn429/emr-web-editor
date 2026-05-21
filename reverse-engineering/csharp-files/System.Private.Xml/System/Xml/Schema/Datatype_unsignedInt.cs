namespace System.Xml.Schema;

internal class Datatype_unsignedInt : Datatype_unsignedLong
{
	private static readonly Type s_atomicValueType = typeof(uint);

	private static readonly Type s_listValueType = typeof(uint[]);

	private static readonly FacetsChecker s_numeric10FacetsChecker = new Numeric10FacetsChecker(0m, 4294967295m);

	internal override FacetsChecker FacetsChecker => s_numeric10FacetsChecker;

	public override XmlTypeCode TypeCode => XmlTypeCode.UnsignedInt;

	public override Type ValueType => s_atomicValueType;

	internal override Type ListValueType => s_listValueType;

	internal override int Compare(object P_0, object P_1)
	{
		return ((uint)P_0).CompareTo((uint)P_1);
	}

	internal override Exception TryParseValue(string P_0, XmlNameTable P_1, IXmlNamespaceResolver P_2, out object P_3)
	{
		P_3 = null;
		Exception ex = s_numeric10FacetsChecker.CheckLexicalFacets(ref P_0, this);
		if (ex == null)
		{
			ex = XmlConvert.TryToUInt32(P_0, out var num);
			if (ex == null)
			{
				ex = s_numeric10FacetsChecker.CheckValueFacets(num, this);
				if (ex == null)
				{
					P_3 = num;
					return null;
				}
			}
		}
		return ex;
	}
}
