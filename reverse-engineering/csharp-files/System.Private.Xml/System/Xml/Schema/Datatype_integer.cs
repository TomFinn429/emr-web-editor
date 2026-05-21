namespace System.Xml.Schema;

internal class Datatype_integer : Datatype_decimal
{
	public override XmlTypeCode TypeCode => XmlTypeCode.Integer;

	internal override Exception TryParseValue(string P_0, XmlNameTable P_1, IXmlNamespaceResolver P_2, out object P_3)
	{
		P_3 = null;
		Exception ex = FacetsChecker.CheckLexicalFacets(ref P_0, this);
		if (ex == null)
		{
			ex = XmlConvert.TryToInteger(P_0, out var num);
			if (ex == null)
			{
				ex = FacetsChecker.CheckValueFacets(num, this);
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
