namespace System.Xml.Schema;

internal sealed class Datatype_base64Binary : Datatype_anySimpleType
{
	private static readonly Type s_atomicValueType = typeof(byte[]);

	private static readonly Type s_listValueType = typeof(byte[][]);

	internal override FacetsChecker FacetsChecker => DatatypeImplementation.binaryFacetsChecker;

	public override XmlTypeCode TypeCode => XmlTypeCode.Base64Binary;

	public override Type ValueType => s_atomicValueType;

	internal override Type ListValueType => s_listValueType;

	internal override XmlSchemaWhiteSpace BuiltInWhitespaceFacet => XmlSchemaWhiteSpace.Collapse;

	internal override XmlValueConverter CreateValueConverter(XmlSchemaType P_0)
	{
		return XmlMiscConverter.Create(P_0);
	}

	internal override int Compare(object P_0, object P_1)
	{
		return DatatypeImplementation.Compare((byte[])P_0, (byte[])P_1);
	}

	internal override Exception TryParseValue(string P_0, XmlNameTable P_1, IXmlNamespaceResolver P_2, out object P_3)
	{
		P_3 = null;
		Exception ex = DatatypeImplementation.binaryFacetsChecker.CheckLexicalFacets(ref P_0, this);
		if (ex == null)
		{
			byte[] array;
			try
			{
				array = Convert.FromBase64String(P_0);
			}
			catch (ArgumentException ex2)
			{
				ex = ex2;
				goto IL_003f;
			}
			catch (FormatException ex3)
			{
				ex = ex3;
				goto IL_003f;
			}
			ex = DatatypeImplementation.binaryFacetsChecker.CheckValueFacets(array, this);
			if (ex == null)
			{
				P_3 = array;
				return null;
			}
		}
		goto IL_003f;
		IL_003f:
		return ex;
	}
}
