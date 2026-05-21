namespace System.Xml.Schema;

internal class Datatype_dateTimeBase : Datatype_anySimpleType
{
	private static readonly Type s_atomicValueType = typeof(DateTime);

	private static readonly Type s_listValueType = typeof(DateTime[]);

	private readonly XsdDateTimeFlags _dateTimeFlags;

	internal override FacetsChecker FacetsChecker => DatatypeImplementation.dateTimeFacetsChecker;

	public override XmlTypeCode TypeCode => XmlTypeCode.DateTime;

	public override Type ValueType => s_atomicValueType;

	internal override Type ListValueType => s_listValueType;

	internal override XmlSchemaWhiteSpace BuiltInWhitespaceFacet => XmlSchemaWhiteSpace.Collapse;

	internal override XmlValueConverter CreateValueConverter(XmlSchemaType P_0)
	{
		return XmlDateTimeConverter.Create(P_0);
	}

	internal Datatype_dateTimeBase(XsdDateTimeFlags P_0)
	{
		_dateTimeFlags = P_0;
	}

	internal override int Compare(object P_0, object P_1)
	{
		DateTime dateTime = (DateTime)P_0;
		DateTime value = (DateTime)P_1;
		if (dateTime.Kind == DateTimeKind.Unspecified || value.Kind == DateTimeKind.Unspecified)
		{
			return dateTime.CompareTo(value);
		}
		return dateTime.ToUniversalTime().CompareTo(value.ToUniversalTime());
	}

	internal override Exception TryParseValue(string P_0, XmlNameTable P_1, IXmlNamespaceResolver P_2, out object P_3)
	{
		P_3 = null;
		Exception ex = DatatypeImplementation.dateTimeFacetsChecker.CheckLexicalFacets(ref P_0, this);
		if (ex == null)
		{
			if (!XsdDateTime.TryParse(P_0, _dateTimeFlags, out var xsdDateTime))
			{
				ex = new FormatException(System.SR.Format("XmlConvert_BadFormat", P_0, _dateTimeFlags.ToString()));
			}
			else
			{
				DateTime dateTime;
				try
				{
					dateTime = xsdDateTime;
				}
				catch (ArgumentException ex2)
				{
					ex = ex2;
					goto IL_0073;
				}
				ex = DatatypeImplementation.dateTimeFacetsChecker.CheckValueFacets(dateTime, this);
				if (ex == null)
				{
					P_3 = dateTime;
					return null;
				}
			}
		}
		goto IL_0073;
		IL_0073:
		return ex;
	}
}
