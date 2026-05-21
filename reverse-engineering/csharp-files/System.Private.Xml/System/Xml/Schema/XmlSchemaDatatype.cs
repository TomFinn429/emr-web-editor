namespace System.Xml.Schema;

public abstract class XmlSchemaDatatype
{
	public abstract Type ValueType { get; }

	public abstract XmlTokenizedType TokenizedType { get; }

	public virtual XmlSchemaDatatypeVariety Variety => XmlSchemaDatatypeVariety.Atomic;

	public virtual XmlTypeCode TypeCode => XmlTypeCode.None;

	internal abstract XmlValueConverter ValueConverter { get; }

	internal abstract RestrictionFacets? Restriction { get; }

	internal abstract FacetsChecker FacetsChecker { get; }

	internal abstract XmlSchemaWhiteSpace BuiltInWhitespaceFacet { get; }

	internal string TypeCodeString
	{
		get
		{
			string result = string.Empty;
			XmlTypeCode typeCode = TypeCode;
			switch (Variety)
			{
			case XmlSchemaDatatypeVariety.List:
				result = ((typeCode != XmlTypeCode.AnyAtomicType) ? ("List of " + TypeCodeToString(typeCode)) : "List of Union");
				break;
			case XmlSchemaDatatypeVariety.Union:
				result = "Union";
				break;
			case XmlSchemaDatatypeVariety.Atomic:
				result = ((typeCode != XmlTypeCode.AnyAtomicType) ? TypeCodeToString(typeCode) : "anySimpleType");
				break;
			}
			return result;
		}
	}

	public abstract object ParseValue(string P_0, XmlNameTable? P_1, IXmlNamespaceResolver? P_2);

	internal XmlSchemaDatatype()
	{
	}

	internal abstract int Compare(object P_0, object P_1);

	internal abstract Exception TryParseValue(string P_0, XmlNameTable P_1, IXmlNamespaceResolver P_2, out object P_3);

	internal abstract bool IsEqual(object P_0, object P_1);

	internal static string TypeCodeToString(XmlTypeCode P_0)
	{
		return P_0 switch
		{
			XmlTypeCode.None => "None", 
			XmlTypeCode.Item => "AnyType", 
			XmlTypeCode.AnyAtomicType => "AnyAtomicType", 
			XmlTypeCode.String => "String", 
			XmlTypeCode.Boolean => "Boolean", 
			XmlTypeCode.Decimal => "Decimal", 
			XmlTypeCode.Float => "Float", 
			XmlTypeCode.Double => "Double", 
			XmlTypeCode.Duration => "Duration", 
			XmlTypeCode.DateTime => "DateTime", 
			XmlTypeCode.Time => "Time", 
			XmlTypeCode.Date => "Date", 
			XmlTypeCode.GYearMonth => "GYearMonth", 
			XmlTypeCode.GYear => "GYear", 
			XmlTypeCode.GMonthDay => "GMonthDay", 
			XmlTypeCode.GDay => "GDay", 
			XmlTypeCode.GMonth => "GMonth", 
			XmlTypeCode.HexBinary => "HexBinary", 
			XmlTypeCode.Base64Binary => "Base64Binary", 
			XmlTypeCode.AnyUri => "AnyUri", 
			XmlTypeCode.QName => "QName", 
			XmlTypeCode.Notation => "Notation", 
			XmlTypeCode.NormalizedString => "NormalizedString", 
			XmlTypeCode.Token => "Token", 
			XmlTypeCode.Language => "Language", 
			XmlTypeCode.NmToken => "NmToken", 
			XmlTypeCode.Name => "Name", 
			XmlTypeCode.NCName => "NCName", 
			XmlTypeCode.Id => "Id", 
			XmlTypeCode.Idref => "Idref", 
			XmlTypeCode.Entity => "Entity", 
			XmlTypeCode.Integer => "Integer", 
			XmlTypeCode.NonPositiveInteger => "NonPositiveInteger", 
			XmlTypeCode.NegativeInteger => "NegativeInteger", 
			XmlTypeCode.Long => "Long", 
			XmlTypeCode.Int => "Int", 
			XmlTypeCode.Short => "Short", 
			XmlTypeCode.Byte => "Byte", 
			XmlTypeCode.NonNegativeInteger => "NonNegativeInteger", 
			XmlTypeCode.UnsignedLong => "UnsignedLong", 
			XmlTypeCode.UnsignedInt => "UnsignedInt", 
			XmlTypeCode.UnsignedShort => "UnsignedShort", 
			XmlTypeCode.UnsignedByte => "UnsignedByte", 
			XmlTypeCode.PositiveInteger => "PositiveInteger", 
			_ => P_0.ToString(), 
		};
	}

	internal static XmlSchemaDatatype FromXmlTokenizedType(XmlTokenizedType P_0)
	{
		return DatatypeImplementation.FromXmlTokenizedType(P_0);
	}
}
