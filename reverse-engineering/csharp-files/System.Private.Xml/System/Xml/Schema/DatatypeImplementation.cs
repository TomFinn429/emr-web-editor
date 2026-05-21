using System.Collections;

namespace System.Xml.Schema;

internal abstract class DatatypeImplementation : XmlSchemaDatatype
{
	private sealed class SchemaDatatypeMap : IComparable
	{
		private readonly string _name;

		private readonly DatatypeImplementation _type;

		private readonly int _parentIndex;

		public string Name => _name;

		public int ParentIndex => _parentIndex;

		internal SchemaDatatypeMap(string P_0, DatatypeImplementation P_1)
		{
			_name = P_0;
			_type = P_1;
		}

		internal SchemaDatatypeMap(string P_0, DatatypeImplementation P_1, int P_2)
		{
			_name = P_0;
			_type = P_1;
			_parentIndex = P_2;
		}

		public static explicit operator DatatypeImplementation(SchemaDatatypeMap P_0)
		{
			return P_0._type;
		}

		public int CompareTo(object P_0)
		{
			return string.Compare(_name, (string)P_0, StringComparison.Ordinal);
		}
	}

	private XmlSchemaDatatypeVariety _variety;

	private RestrictionFacets _restriction;

	private DatatypeImplementation _baseType;

	private XmlValueConverter _valueConverter;

	private XmlSchemaType _parentSchemaType;

	private static readonly Hashtable s_builtinTypes;

	private static readonly XmlSchemaSimpleType[] s_enumToTypeCode;

	private static XmlSchemaSimpleType s__anySimpleType;

	private static XmlSchemaSimpleType s__anyAtomicType;

	private static XmlSchemaSimpleType s__untypedAtomicType;

	private static XmlSchemaSimpleType s_yearMonthDurationType;

	private static XmlSchemaSimpleType s_dayTimeDurationType;

	internal static XmlQualifiedName QnAnySimpleType;

	internal static XmlQualifiedName QnAnyType;

	internal static FacetsChecker stringFacetsChecker;

	internal static FacetsChecker miscFacetsChecker;

	internal static FacetsChecker numeric2FacetsChecker;

	internal static FacetsChecker binaryFacetsChecker;

	internal static FacetsChecker dateTimeFacetsChecker;

	internal static FacetsChecker durationFacetsChecker;

	internal static FacetsChecker listFacetsChecker;

	internal static FacetsChecker qnameFacetsChecker;

	internal static FacetsChecker unionFacetsChecker;

	private static readonly DatatypeImplementation s_anySimpleType;

	private static readonly DatatypeImplementation s_anyURI;

	private static readonly DatatypeImplementation s_base64Binary;

	private static readonly DatatypeImplementation s_boolean;

	private static readonly DatatypeImplementation s_byte;

	private static readonly DatatypeImplementation s_char;

	private static readonly DatatypeImplementation s_date;

	private static readonly DatatypeImplementation s_dateTime;

	private static readonly DatatypeImplementation s_dateTimeNoTz;

	private static readonly DatatypeImplementation s_dateTimeTz;

	private static readonly DatatypeImplementation s_day;

	private static readonly DatatypeImplementation s_decimal;

	private static readonly DatatypeImplementation s_double;

	private static readonly DatatypeImplementation s_doubleXdr;

	private static readonly DatatypeImplementation s_duration;

	private static readonly DatatypeImplementation s_ENTITY;

	private static readonly DatatypeImplementation s_ENTITIES;

	private static readonly DatatypeImplementation s_ENUMERATION;

	private static readonly DatatypeImplementation s_fixed;

	private static readonly DatatypeImplementation s_float;

	private static readonly DatatypeImplementation s_floatXdr;

	private static readonly DatatypeImplementation s_hexBinary;

	private static readonly DatatypeImplementation s_ID;

	private static readonly DatatypeImplementation s_IDREF;

	private static readonly DatatypeImplementation s_IDREFS;

	private static readonly DatatypeImplementation s_int;

	private static readonly DatatypeImplementation s_integer;

	private static readonly DatatypeImplementation s_language;

	private static readonly DatatypeImplementation s_long;

	private static readonly DatatypeImplementation s_month;

	private static readonly DatatypeImplementation s_monthDay;

	private static readonly DatatypeImplementation s_name;

	private static readonly DatatypeImplementation s_NCName;

	private static readonly DatatypeImplementation s_negativeInteger;

	private static readonly DatatypeImplementation s_NMTOKEN;

	private static readonly DatatypeImplementation s_NMTOKENS;

	private static readonly DatatypeImplementation s_nonNegativeInteger;

	private static readonly DatatypeImplementation s_nonPositiveInteger;

	private static readonly DatatypeImplementation s_normalizedString;

	private static readonly DatatypeImplementation s_NOTATION;

	private static readonly DatatypeImplementation s_positiveInteger;

	private static readonly DatatypeImplementation s_QName;

	private static readonly DatatypeImplementation s_QNameXdr;

	private static readonly DatatypeImplementation s_short;

	private static readonly DatatypeImplementation s_string;

	private static readonly DatatypeImplementation s_time;

	private static readonly DatatypeImplementation s_timeNoTz;

	private static readonly DatatypeImplementation s_timeTz;

	private static readonly DatatypeImplementation s_token;

	private static readonly DatatypeImplementation s_unsignedByte;

	private static readonly DatatypeImplementation s_unsignedInt;

	private static readonly DatatypeImplementation s_unsignedLong;

	private static readonly DatatypeImplementation s_unsignedShort;

	private static readonly DatatypeImplementation s_uuid;

	private static readonly DatatypeImplementation s_year;

	private static readonly DatatypeImplementation s_yearMonth;

	internal static readonly DatatypeImplementation c_normalizedStringV1Compat;

	internal static readonly DatatypeImplementation c_tokenV1Compat;

	private static readonly DatatypeImplementation s_anyAtomicType;

	private static readonly DatatypeImplementation s_dayTimeDuration;

	private static readonly DatatypeImplementation s_untypedAtomicType;

	private static readonly DatatypeImplementation s_yearMonthDuration;

	private static readonly DatatypeImplementation[] s_tokenizedTypes;

	private static readonly DatatypeImplementation[] s_tokenizedTypesXsd;

	private static readonly SchemaDatatypeMap[] s_xdrTypes;

	private static readonly SchemaDatatypeMap[] s_xsdTypes;

	internal static XmlSchemaSimpleType AnySimpleType => s__anySimpleType;

	internal static XmlSchemaSimpleType UntypedAtomicType => s__untypedAtomicType;

	internal override FacetsChecker FacetsChecker => miscFacetsChecker;

	internal override XmlValueConverter ValueConverter => _valueConverter ?? (_valueConverter = CreateValueConverter(_parentSchemaType));

	public override XmlTokenizedType TokenizedType => XmlTokenizedType.None;

	public override Type ValueType => typeof(string);

	public override XmlSchemaDatatypeVariety Variety => _variety;

	public override XmlTypeCode TypeCode => XmlTypeCode.None;

	internal override RestrictionFacets Restriction => _restriction;

	internal abstract Type ListValueType { get; }

	internal override XmlSchemaWhiteSpace BuiltInWhitespaceFacet => XmlSchemaWhiteSpace.Preserve;

	static DatatypeImplementation()
	{
		s_builtinTypes = new Hashtable();
		s_enumToTypeCode = new XmlSchemaSimpleType[55];
		s__anySimpleType = null;
		s__anyAtomicType = null;
		s__untypedAtomicType = null;
		s_yearMonthDurationType = null;
		s_dayTimeDurationType = null;
		QnAnySimpleType = new XmlQualifiedName("anySimpleType", "http://www.w3.org/2001/XMLSchema");
		QnAnyType = new XmlQualifiedName("anyType", "http://www.w3.org/2001/XMLSchema");
		stringFacetsChecker = new StringFacetsChecker();
		miscFacetsChecker = new MiscFacetsChecker();
		numeric2FacetsChecker = new Numeric2FacetsChecker();
		binaryFacetsChecker = new BinaryFacetsChecker();
		dateTimeFacetsChecker = new DateTimeFacetsChecker();
		durationFacetsChecker = new DurationFacetsChecker();
		listFacetsChecker = new ListFacetsChecker();
		qnameFacetsChecker = new QNameFacetsChecker();
		unionFacetsChecker = new UnionFacetsChecker();
		s_anySimpleType = new Datatype_anySimpleType();
		s_anyURI = new Datatype_anyURI();
		s_base64Binary = new Datatype_base64Binary();
		s_boolean = new Datatype_boolean();
		s_byte = new Datatype_byte();
		s_char = new Datatype_char();
		s_date = new Datatype_date();
		s_dateTime = new Datatype_dateTime();
		s_dateTimeNoTz = new Datatype_dateTimeNoTimeZone();
		s_dateTimeTz = new Datatype_dateTimeTimeZone();
		s_day = new Datatype_day();
		s_decimal = new Datatype_decimal();
		s_double = new Datatype_double();
		s_doubleXdr = new Datatype_doubleXdr();
		s_duration = new Datatype_duration();
		s_ENTITY = new Datatype_ENTITY();
		s_ENTITIES = (DatatypeImplementation)s_ENTITY.DeriveByList(1, null);
		s_ENUMERATION = new Datatype_ENUMERATION();
		s_fixed = new Datatype_fixed();
		s_float = new Datatype_float();
		s_floatXdr = new Datatype_floatXdr();
		s_hexBinary = new Datatype_hexBinary();
		s_ID = new Datatype_ID();
		s_IDREF = new Datatype_IDREF();
		s_IDREFS = (DatatypeImplementation)s_IDREF.DeriveByList(1, null);
		s_int = new Datatype_int();
		s_integer = new Datatype_integer();
		s_language = new Datatype_language();
		s_long = new Datatype_long();
		s_month = new Datatype_month();
		s_monthDay = new Datatype_monthDay();
		s_name = new Datatype_Name();
		s_NCName = new Datatype_NCName();
		s_negativeInteger = new Datatype_negativeInteger();
		s_NMTOKEN = new Datatype_NMTOKEN();
		s_NMTOKENS = (DatatypeImplementation)s_NMTOKEN.DeriveByList(1, null);
		s_nonNegativeInteger = new Datatype_nonNegativeInteger();
		s_nonPositiveInteger = new Datatype_nonPositiveInteger();
		s_normalizedString = new Datatype_normalizedString();
		s_NOTATION = new Datatype_NOTATION();
		s_positiveInteger = new Datatype_positiveInteger();
		s_QName = new Datatype_QName();
		s_QNameXdr = new Datatype_QNameXdr();
		s_short = new Datatype_short();
		s_string = new Datatype_string();
		s_time = new Datatype_time();
		s_timeNoTz = new Datatype_timeNoTimeZone();
		s_timeTz = new Datatype_timeTimeZone();
		s_token = new Datatype_token();
		s_unsignedByte = new Datatype_unsignedByte();
		s_unsignedInt = new Datatype_unsignedInt();
		s_unsignedLong = new Datatype_unsignedLong();
		s_unsignedShort = new Datatype_unsignedShort();
		s_uuid = new Datatype_uuid();
		s_year = new Datatype_year();
		s_yearMonth = new Datatype_yearMonth();
		c_normalizedStringV1Compat = new Datatype_normalizedStringV1Compat();
		c_tokenV1Compat = new Datatype_tokenV1Compat();
		s_anyAtomicType = new Datatype_anyAtomicType();
		s_dayTimeDuration = new Datatype_dayTimeDuration();
		s_untypedAtomicType = new Datatype_untypedAtomicType();
		s_yearMonthDuration = new Datatype_yearMonthDuration();
		s_tokenizedTypes = new DatatypeImplementation[13]
		{
			s_string, s_ID, s_IDREF, s_IDREFS, s_ENTITY, s_ENTITIES, s_NMTOKEN, s_NMTOKENS, s_NOTATION, s_ENUMERATION,
			s_QNameXdr, s_NCName, null
		};
		s_tokenizedTypesXsd = new DatatypeImplementation[13]
		{
			s_string, s_ID, s_IDREF, s_IDREFS, s_ENTITY, s_ENTITIES, s_NMTOKEN, s_NMTOKENS, s_NOTATION, s_ENUMERATION,
			s_QName, s_NCName, null
		};
		s_xdrTypes = new SchemaDatatypeMap[38]
		{
			new SchemaDatatypeMap("bin.base64", s_base64Binary),
			new SchemaDatatypeMap("bin.hex", s_hexBinary),
			new SchemaDatatypeMap("boolean", s_boolean),
			new SchemaDatatypeMap("char", s_char),
			new SchemaDatatypeMap("date", s_date),
			new SchemaDatatypeMap("dateTime", s_dateTimeNoTz),
			new SchemaDatatypeMap("dateTime.tz", s_dateTimeTz),
			new SchemaDatatypeMap("decimal", s_decimal),
			new SchemaDatatypeMap("entities", s_ENTITIES),
			new SchemaDatatypeMap("entity", s_ENTITY),
			new SchemaDatatypeMap("enumeration", s_ENUMERATION),
			new SchemaDatatypeMap("fixed.14.4", s_fixed),
			new SchemaDatatypeMap("float", s_doubleXdr),
			new SchemaDatatypeMap("float.ieee.754.32", s_floatXdr),
			new SchemaDatatypeMap("float.ieee.754.64", s_doubleXdr),
			new SchemaDatatypeMap("i1", s_byte),
			new SchemaDatatypeMap("i2", s_short),
			new SchemaDatatypeMap("i4", s_int),
			new SchemaDatatypeMap("i8", s_long),
			new SchemaDatatypeMap("id", s_ID),
			new SchemaDatatypeMap("idref", s_IDREF),
			new SchemaDatatypeMap("idrefs", s_IDREFS),
			new SchemaDatatypeMap("int", s_int),
			new SchemaDatatypeMap("nmtoken", s_NMTOKEN),
			new SchemaDatatypeMap("nmtokens", s_NMTOKENS),
			new SchemaDatatypeMap("notation", s_NOTATION),
			new SchemaDatatypeMap("number", s_doubleXdr),
			new SchemaDatatypeMap("r4", s_floatXdr),
			new SchemaDatatypeMap("r8", s_doubleXdr),
			new SchemaDatatypeMap("string", s_string),
			new SchemaDatatypeMap("time", s_timeNoTz),
			new SchemaDatatypeMap("time.tz", s_timeTz),
			new SchemaDatatypeMap("ui1", s_unsignedByte),
			new SchemaDatatypeMap("ui2", s_unsignedShort),
			new SchemaDatatypeMap("ui4", s_unsignedInt),
			new SchemaDatatypeMap("ui8", s_unsignedLong),
			new SchemaDatatypeMap("uri", s_anyURI),
			new SchemaDatatypeMap("uuid", s_uuid)
		};
		s_xsdTypes = new SchemaDatatypeMap[45]
		{
			new SchemaDatatypeMap("ENTITIES", s_ENTITIES, 11),
			new SchemaDatatypeMap("ENTITY", s_ENTITY, 11),
			new SchemaDatatypeMap("ID", s_ID, 5),
			new SchemaDatatypeMap("IDREF", s_IDREF, 5),
			new SchemaDatatypeMap("IDREFS", s_IDREFS, 11),
			new SchemaDatatypeMap("NCName", s_NCName, 9),
			new SchemaDatatypeMap("NMTOKEN", s_NMTOKEN, 40),
			new SchemaDatatypeMap("NMTOKENS", s_NMTOKENS, 11),
			new SchemaDatatypeMap("NOTATION", s_NOTATION, 11),
			new SchemaDatatypeMap("Name", s_name, 40),
			new SchemaDatatypeMap("QName", s_QName, 11),
			new SchemaDatatypeMap("anySimpleType", s_anySimpleType, -1),
			new SchemaDatatypeMap("anyURI", s_anyURI, 11),
			new SchemaDatatypeMap("base64Binary", s_base64Binary, 11),
			new SchemaDatatypeMap("boolean", s_boolean, 11),
			new SchemaDatatypeMap("byte", s_byte, 37),
			new SchemaDatatypeMap("date", s_date, 11),
			new SchemaDatatypeMap("dateTime", s_dateTime, 11),
			new SchemaDatatypeMap("decimal", s_decimal, 11),
			new SchemaDatatypeMap("double", s_double, 11),
			new SchemaDatatypeMap("duration", s_duration, 11),
			new SchemaDatatypeMap("float", s_float, 11),
			new SchemaDatatypeMap("gDay", s_day, 11),
			new SchemaDatatypeMap("gMonth", s_month, 11),
			new SchemaDatatypeMap("gMonthDay", s_monthDay, 11),
			new SchemaDatatypeMap("gYear", s_year, 11),
			new SchemaDatatypeMap("gYearMonth", s_yearMonth, 11),
			new SchemaDatatypeMap("hexBinary", s_hexBinary, 11),
			new SchemaDatatypeMap("int", s_int, 31),
			new SchemaDatatypeMap("integer", s_integer, 18),
			new SchemaDatatypeMap("language", s_language, 40),
			new SchemaDatatypeMap("long", s_long, 29),
			new SchemaDatatypeMap("negativeInteger", s_negativeInteger, 34),
			new SchemaDatatypeMap("nonNegativeInteger", s_nonNegativeInteger, 29),
			new SchemaDatatypeMap("nonPositiveInteger", s_nonPositiveInteger, 29),
			new SchemaDatatypeMap("normalizedString", s_normalizedString, 38),
			new SchemaDatatypeMap("positiveInteger", s_positiveInteger, 33),
			new SchemaDatatypeMap("short", s_short, 28),
			new SchemaDatatypeMap("string", s_string, 11),
			new SchemaDatatypeMap("time", s_time, 11),
			new SchemaDatatypeMap("token", s_token, 35),
			new SchemaDatatypeMap("unsignedByte", s_unsignedByte, 44),
			new SchemaDatatypeMap("unsignedInt", s_unsignedInt, 43),
			new SchemaDatatypeMap("unsignedLong", s_unsignedLong, 33),
			new SchemaDatatypeMap("unsignedShort", s_unsignedShort, 42)
		};
		CreateBuiltinTypes();
	}

	internal new static DatatypeImplementation FromXmlTokenizedType(XmlTokenizedType P_0)
	{
		return s_tokenizedTypes[(int)P_0];
	}

	private static DatatypeImplementation FromTypeName(string P_0)
	{
		int num = Array.BinarySearch(s_xsdTypes, P_0, null);
		if (num >= 0)
		{
			return (DatatypeImplementation)s_xsdTypes[num];
		}
		return null;
	}

	internal static XmlSchemaSimpleType StartBuiltinType(XmlQualifiedName P_0, XmlSchemaDatatype P_1)
	{
		XmlSchemaSimpleType xmlSchemaSimpleType = new XmlSchemaSimpleType();
		xmlSchemaSimpleType.SetQualifiedName(P_0);
		xmlSchemaSimpleType.SetDatatype(P_1);
		xmlSchemaSimpleType.ElementDecl = new SchemaElementDecl(P_1);
		xmlSchemaSimpleType.ElementDecl.SchemaType = xmlSchemaSimpleType;
		return xmlSchemaSimpleType;
	}

	internal static void FinishBuiltinType(XmlSchemaSimpleType P_0, XmlSchemaSimpleType P_1)
	{
		P_0.SetBaseSchemaType(P_1);
		P_0.SetDerivedBy(XmlSchemaDerivationMethod.Restriction);
		if (P_0.Datatype.Variety == XmlSchemaDatatypeVariety.Atomic)
		{
			XmlSchemaSimpleTypeRestriction xmlSchemaSimpleTypeRestriction = new XmlSchemaSimpleTypeRestriction();
			xmlSchemaSimpleTypeRestriction.BaseTypeName = P_1.QualifiedName;
			P_0.Content = xmlSchemaSimpleTypeRestriction;
		}
		if (P_0.Datatype.Variety == XmlSchemaDatatypeVariety.List)
		{
			XmlSchemaSimpleTypeList xmlSchemaSimpleTypeList = new XmlSchemaSimpleTypeList();
			P_0.SetDerivedBy(XmlSchemaDerivationMethod.List);
			switch (P_0.Datatype.TypeCode)
			{
			case XmlTypeCode.NmToken:
			{
				XmlSchemaSimpleType itemType = (xmlSchemaSimpleTypeList.BaseItemType = s_enumToTypeCode[34]);
				xmlSchemaSimpleTypeList.ItemType = itemType;
				break;
			}
			case XmlTypeCode.Entity:
			{
				XmlSchemaSimpleType itemType = (xmlSchemaSimpleTypeList.BaseItemType = s_enumToTypeCode[39]);
				xmlSchemaSimpleTypeList.ItemType = itemType;
				break;
			}
			case XmlTypeCode.Idref:
			{
				XmlSchemaSimpleType itemType = (xmlSchemaSimpleTypeList.BaseItemType = s_enumToTypeCode[38]);
				xmlSchemaSimpleTypeList.ItemType = itemType;
				break;
			}
			}
			P_0.Content = xmlSchemaSimpleTypeList;
		}
	}

	internal static void CreateBuiltinTypes()
	{
		SchemaDatatypeMap schemaDatatypeMap = s_xsdTypes[11];
		XmlQualifiedName xmlQualifiedName = new XmlQualifiedName(schemaDatatypeMap.Name, "http://www.w3.org/2001/XMLSchema");
		DatatypeImplementation datatypeImplementation = FromTypeName(xmlQualifiedName.Name);
		s__anySimpleType = StartBuiltinType(xmlQualifiedName, datatypeImplementation);
		datatypeImplementation._parentSchemaType = s__anySimpleType;
		s_builtinTypes.Add(xmlQualifiedName, s__anySimpleType);
		for (int i = 0; i < s_xsdTypes.Length; i++)
		{
			if (i != 11)
			{
				schemaDatatypeMap = s_xsdTypes[i];
				xmlQualifiedName = new XmlQualifiedName(schemaDatatypeMap.Name, "http://www.w3.org/2001/XMLSchema");
				datatypeImplementation = FromTypeName(xmlQualifiedName.Name);
				XmlSchemaSimpleType xmlSchemaSimpleType = (XmlSchemaSimpleType)(datatypeImplementation._parentSchemaType = StartBuiltinType(xmlQualifiedName, datatypeImplementation));
				s_builtinTypes.Add(xmlQualifiedName, xmlSchemaSimpleType);
				if (datatypeImplementation._variety == XmlSchemaDatatypeVariety.Atomic)
				{
					s_enumToTypeCode[(int)datatypeImplementation.TypeCode] = xmlSchemaSimpleType;
				}
			}
		}
		for (int j = 0; j < s_xsdTypes.Length; j++)
		{
			if (j != 11)
			{
				schemaDatatypeMap = s_xsdTypes[j];
				XmlSchemaSimpleType xmlSchemaSimpleType2 = (XmlSchemaSimpleType)s_builtinTypes[new XmlQualifiedName(schemaDatatypeMap.Name, "http://www.w3.org/2001/XMLSchema")];
				if (schemaDatatypeMap.ParentIndex == 11)
				{
					FinishBuiltinType(xmlSchemaSimpleType2, s__anySimpleType);
					continue;
				}
				XmlSchemaSimpleType xmlSchemaSimpleType3 = (XmlSchemaSimpleType)s_builtinTypes[new XmlQualifiedName(s_xsdTypes[schemaDatatypeMap.ParentIndex].Name, "http://www.w3.org/2001/XMLSchema")];
				FinishBuiltinType(xmlSchemaSimpleType2, xmlSchemaSimpleType3);
			}
		}
		xmlQualifiedName = new XmlQualifiedName("anyAtomicType", "http://www.w3.org/2003/11/xpath-datatypes");
		s__anyAtomicType = StartBuiltinType(xmlQualifiedName, s_anyAtomicType);
		s_anyAtomicType._parentSchemaType = s__anyAtomicType;
		FinishBuiltinType(s__anyAtomicType, s__anySimpleType);
		s_builtinTypes.Add(xmlQualifiedName, s__anyAtomicType);
		s_enumToTypeCode[10] = s__anyAtomicType;
		xmlQualifiedName = new XmlQualifiedName("untypedAtomic", "http://www.w3.org/2003/11/xpath-datatypes");
		s__untypedAtomicType = StartBuiltinType(xmlQualifiedName, s_untypedAtomicType);
		s_untypedAtomicType._parentSchemaType = s__untypedAtomicType;
		FinishBuiltinType(s__untypedAtomicType, s__anyAtomicType);
		s_builtinTypes.Add(xmlQualifiedName, s__untypedAtomicType);
		s_enumToTypeCode[11] = s__untypedAtomicType;
		xmlQualifiedName = new XmlQualifiedName("yearMonthDuration", "http://www.w3.org/2003/11/xpath-datatypes");
		s_yearMonthDurationType = StartBuiltinType(xmlQualifiedName, s_yearMonthDuration);
		s_yearMonthDuration._parentSchemaType = s_yearMonthDurationType;
		FinishBuiltinType(s_yearMonthDurationType, s_enumToTypeCode[17]);
		s_builtinTypes.Add(xmlQualifiedName, s_yearMonthDurationType);
		s_enumToTypeCode[53] = s_yearMonthDurationType;
		xmlQualifiedName = new XmlQualifiedName("dayTimeDuration", "http://www.w3.org/2003/11/xpath-datatypes");
		s_dayTimeDurationType = StartBuiltinType(xmlQualifiedName, s_dayTimeDuration);
		s_dayTimeDuration._parentSchemaType = s_dayTimeDurationType;
		FinishBuiltinType(s_dayTimeDurationType, s_enumToTypeCode[17]);
		s_builtinTypes.Add(xmlQualifiedName, s_dayTimeDurationType);
		s_enumToTypeCode[54] = s_dayTimeDurationType;
	}

	internal static XmlSchemaSimpleType GetSimpleTypeFromTypeCode(XmlTypeCode P_0)
	{
		return s_enumToTypeCode[(int)P_0];
	}

	internal XmlSchemaDatatype DeriveByList(int P_0, XmlSchemaType P_1)
	{
		if (_variety == XmlSchemaDatatypeVariety.List)
		{
			throw new XmlSchemaException("Sch_ListFromNonatomic", string.Empty);
		}
		if (_variety == XmlSchemaDatatypeVariety.Union && !((Datatype_union)this).HasAtomicMembers())
		{
			throw new XmlSchemaException("Sch_ListFromNonatomic", string.Empty);
		}
		DatatypeImplementation datatypeImplementation = new Datatype_List(this, P_0);
		datatypeImplementation._variety = XmlSchemaDatatypeVariety.List;
		datatypeImplementation._restriction = null;
		datatypeImplementation._baseType = s_anySimpleType;
		datatypeImplementation._parentSchemaType = P_1;
		return datatypeImplementation;
	}

	internal override bool IsEqual(object P_0, object P_1)
	{
		return Compare(P_0, P_1) == 0;
	}

	internal abstract XmlValueConverter CreateValueConverter(XmlSchemaType P_0);

	public override object ParseValue(string P_0, XmlNameTable P_1, IXmlNamespaceResolver P_2)
	{
		object result;
		Exception ex = TryParseValue(P_0, P_1, P_2, out result);
		if (ex != null)
		{
			throw new XmlSchemaException("Sch_InvalidValueDetailed", new string[3]
			{
				P_0,
				GetTypeName(),
				ex.Message
			}, ex, null, 0, 0, null);
		}
		if (Variety == XmlSchemaDatatypeVariety.Union)
		{
			XsdSimpleValue xsdSimpleValue = null;
			return xsdSimpleValue.TypedValue;
		}
		return result;
	}

	internal string GetTypeName()
	{
		XmlSchemaType parentSchemaType = _parentSchemaType;
		if (parentSchemaType == null || parentSchemaType.QualifiedName.IsEmpty)
		{
			return base.TypeCodeString;
		}
		return parentSchemaType.QualifiedName.ToString();
	}

	protected static int Compare(byte[] P_0, byte[] P_1)
	{
		if (!P_0.AsSpan().SequenceEqual(P_1))
		{
			return -1;
		}
		return 0;
	}
}
