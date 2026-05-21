namespace System.Xml.Schema;

internal class Datatype_NCName : Datatype_Name
{
	public override XmlTypeCode TypeCode => XmlTypeCode.NCName;

	internal override Exception TryParseValue(string P_0, XmlNameTable P_1, IXmlNamespaceResolver P_2, out object P_3)
	{
		P_3 = null;
		Exception ex = DatatypeImplementation.stringFacetsChecker.CheckLexicalFacets(ref P_0, this);
		if (ex == null)
		{
			ex = DatatypeImplementation.stringFacetsChecker.CheckValueFacets(P_0, this);
			if (ex == null)
			{
				P_1.Add(P_0);
				P_3 = P_0;
				return null;
			}
		}
		return ex;
	}
}
