using System.Collections;
using System.Xml.XPath;

namespace System.Xml.Schema;

internal abstract class XmlBaseConverter : XmlValueConverter
{
	private readonly XmlSchemaType _schemaType;

	private readonly XmlTypeCode _typeCode;

	private readonly Type _clrTypeDefault;

	protected static readonly Type ICollectionType = typeof(ICollection);

	protected static readonly Type IEnumerableType = typeof(IEnumerable);

	protected static readonly Type IListType = typeof(IList);

	protected static readonly Type ObjectArrayType = typeof(object[]);

	protected static readonly Type StringArrayType = typeof(string[]);

	protected static readonly Type XmlAtomicValueArrayType = typeof(XmlAtomicValue[]);

	protected static readonly Type DecimalType = typeof(decimal);

	protected static readonly Type Int32Type = typeof(int);

	protected static readonly Type Int64Type = typeof(long);

	protected static readonly Type StringType = typeof(string);

	protected static readonly Type XmlAtomicValueType = typeof(XmlAtomicValue);

	protected static readonly Type ObjectType = typeof(object);

	protected static readonly Type ByteType = typeof(byte);

	protected static readonly Type Int16Type = typeof(short);

	protected static readonly Type SByteType = typeof(sbyte);

	protected static readonly Type UInt16Type = typeof(ushort);

	protected static readonly Type UInt32Type = typeof(uint);

	protected static readonly Type UInt64Type = typeof(ulong);

	protected static readonly Type XPathItemType = typeof(XPathItem);

	protected static readonly Type DoubleType = typeof(double);

	protected static readonly Type SingleType = typeof(float);

	protected static readonly Type DateTimeType = typeof(DateTime);

	protected static readonly Type DateTimeOffsetType = typeof(DateTimeOffset);

	protected static readonly Type BooleanType = typeof(bool);

	protected static readonly Type ByteArrayType = typeof(byte[]);

	protected static readonly Type XmlQualifiedNameType = typeof(XmlQualifiedName);

	protected static readonly Type UriType = typeof(Uri);

	protected static readonly Type TimeSpanType = typeof(TimeSpan);

	protected static readonly Type XPathNavigatorType = typeof(XPathNavigator);

	protected XmlSchemaType SchemaType => _schemaType;

	protected XmlTypeCode TypeCode => _typeCode;

	protected string XmlTypeName
	{
		get
		{
			XmlSchemaType xmlSchemaType = _schemaType;
			if (xmlSchemaType != null)
			{
				while (xmlSchemaType.QualifiedName.IsEmpty)
				{
					xmlSchemaType = xmlSchemaType.BaseXmlSchemaType;
				}
				return QNameToString(xmlSchemaType.QualifiedName);
			}
			if (_typeCode == XmlTypeCode.Node)
			{
				return "node";
			}
			if (_typeCode == XmlTypeCode.AnyAtomicType)
			{
				return "xdt:anyAtomicType";
			}
			return "item";
		}
	}

	protected Type DefaultClrType => _clrTypeDefault;

	protected XmlBaseConverter(XmlSchemaType P_0)
	{
		XmlSchemaDatatype datatype = P_0.Datatype;
		while (P_0 != null && !(P_0 is XmlSchemaSimpleType))
		{
			P_0 = P_0.BaseXmlSchemaType;
		}
		if (P_0 == null)
		{
			P_0 = XmlSchemaType.GetBuiltInSimpleType(datatype.TypeCode);
		}
		_schemaType = P_0;
		_typeCode = P_0.TypeCode;
		_clrTypeDefault = P_0.Datatype.ValueType;
	}

	protected XmlBaseConverter(XmlTypeCode P_0)
	{
		switch (P_0)
		{
		case XmlTypeCode.Item:
			_clrTypeDefault = XPathItemType;
			break;
		case XmlTypeCode.Node:
			_clrTypeDefault = XPathNavigatorType;
			break;
		case XmlTypeCode.AnyAtomicType:
			_clrTypeDefault = XmlAtomicValueType;
			break;
		}
		_typeCode = P_0;
	}

	protected XmlBaseConverter(XmlBaseConverter P_0)
	{
		_schemaType = P_0._schemaType;
		_typeCode = P_0._typeCode;
		_clrTypeDefault = Array.CreateInstance(P_0.DefaultClrType, 0).GetType();
	}

	protected XmlBaseConverter(XmlBaseConverter P_0, Type P_1)
	{
		_schemaType = P_0._schemaType;
		_typeCode = P_0._typeCode;
		_clrTypeDefault = P_1;
	}

	public override bool ToBoolean(DateTime P_0)
	{
		return (bool)ChangeType(P_0, BooleanType, null);
	}

	public override bool ToBoolean(double P_0)
	{
		return (bool)ChangeType(P_0, BooleanType, null);
	}

	public override bool ToBoolean(int P_0)
	{
		return (bool)ChangeType(P_0, BooleanType, null);
	}

	public override bool ToBoolean(long P_0)
	{
		return (bool)ChangeType(P_0, BooleanType, null);
	}

	public override bool ToBoolean(string P_0)
	{
		return (bool)ChangeType((object)P_0, BooleanType, (IXmlNamespaceResolver)null);
	}

	public override bool ToBoolean(object P_0)
	{
		return (bool)ChangeType(P_0, BooleanType, null);
	}

	public override DateTime ToDateTime(bool P_0)
	{
		return (DateTime)ChangeType(P_0, DateTimeType, null);
	}

	public override DateTime ToDateTime(DateTimeOffset P_0)
	{
		return (DateTime)ChangeType(P_0, DateTimeType, null);
	}

	public override DateTime ToDateTime(double P_0)
	{
		return (DateTime)ChangeType(P_0, DateTimeType, null);
	}

	public override DateTime ToDateTime(int P_0)
	{
		return (DateTime)ChangeType(P_0, DateTimeType, null);
	}

	public override DateTime ToDateTime(long P_0)
	{
		return (DateTime)ChangeType(P_0, DateTimeType, null);
	}

	public override DateTime ToDateTime(string P_0)
	{
		return (DateTime)ChangeType((object)P_0, DateTimeType, (IXmlNamespaceResolver)null);
	}

	public override DateTime ToDateTime(object P_0)
	{
		return (DateTime)ChangeType(P_0, DateTimeType, null);
	}

	public override DateTimeOffset ToDateTimeOffset(DateTime P_0)
	{
		return (DateTimeOffset)ChangeType(P_0, DateTimeOffsetType, null);
	}

	public override DateTimeOffset ToDateTimeOffset(string P_0)
	{
		return (DateTimeOffset)ChangeType((object)P_0, DateTimeOffsetType, (IXmlNamespaceResolver)null);
	}

	public override DateTimeOffset ToDateTimeOffset(object P_0)
	{
		return (DateTimeOffset)ChangeType(P_0, DateTimeOffsetType, null);
	}

	public override decimal ToDecimal(string P_0)
	{
		return (decimal)ChangeType((object)P_0, DecimalType, (IXmlNamespaceResolver)null);
	}

	public override decimal ToDecimal(object P_0)
	{
		return (decimal)ChangeType(P_0, DecimalType, null);
	}

	public override double ToDouble(bool P_0)
	{
		return (double)ChangeType(P_0, DoubleType, null);
	}

	public override double ToDouble(DateTime P_0)
	{
		return (double)ChangeType(P_0, DoubleType, null);
	}

	public override double ToDouble(int P_0)
	{
		return (double)ChangeType(P_0, DoubleType, null);
	}

	public override double ToDouble(long P_0)
	{
		return (double)ChangeType(P_0, DoubleType, null);
	}

	public override double ToDouble(string P_0)
	{
		return (double)ChangeType((object)P_0, DoubleType, (IXmlNamespaceResolver)null);
	}

	public override double ToDouble(object P_0)
	{
		return (double)ChangeType(P_0, DoubleType, null);
	}

	public override int ToInt32(bool P_0)
	{
		return (int)ChangeType(P_0, Int32Type, null);
	}

	public override int ToInt32(DateTime P_0)
	{
		return (int)ChangeType(P_0, Int32Type, null);
	}

	public override int ToInt32(double P_0)
	{
		return (int)ChangeType(P_0, Int32Type, null);
	}

	public override int ToInt32(long P_0)
	{
		return (int)ChangeType(P_0, Int32Type, null);
	}

	public override int ToInt32(string P_0)
	{
		return (int)ChangeType((object)P_0, Int32Type, (IXmlNamespaceResolver)null);
	}

	public override int ToInt32(object P_0)
	{
		return (int)ChangeType(P_0, Int32Type, null);
	}

	public override long ToInt64(bool P_0)
	{
		return (long)ChangeType(P_0, Int64Type, null);
	}

	public override long ToInt64(DateTime P_0)
	{
		return (long)ChangeType(P_0, Int64Type, null);
	}

	public override long ToInt64(double P_0)
	{
		return (long)ChangeType(P_0, Int64Type, null);
	}

	public override long ToInt64(int P_0)
	{
		return (long)ChangeType(P_0, Int64Type, null);
	}

	public override long ToInt64(string P_0)
	{
		return (long)ChangeType((object)P_0, Int64Type, (IXmlNamespaceResolver)null);
	}

	public override long ToInt64(object P_0)
	{
		return (long)ChangeType(P_0, Int64Type, null);
	}

	public override float ToSingle(double P_0)
	{
		return (float)ChangeType(P_0, SingleType, null);
	}

	public override float ToSingle(string P_0)
	{
		return (float)ChangeType((object)P_0, SingleType, (IXmlNamespaceResolver)null);
	}

	public override float ToSingle(object P_0)
	{
		return (float)ChangeType(P_0, SingleType, null);
	}

	public override string ToString(bool P_0)
	{
		return (string)ChangeType(P_0, StringType, null);
	}

	public override string ToString(DateTime P_0)
	{
		return (string)ChangeType(P_0, StringType, null);
	}

	public override string ToString(DateTimeOffset P_0)
	{
		return (string)ChangeType(P_0, StringType, null);
	}

	public override string ToString(decimal P_0)
	{
		return (string)ChangeType(P_0, StringType, null);
	}

	public override string ToString(double P_0)
	{
		return (string)ChangeType(P_0, StringType, null);
	}

	public override string ToString(int P_0)
	{
		return (string)ChangeType(P_0, StringType, null);
	}

	public override string ToString(long P_0)
	{
		return (string)ChangeType(P_0, StringType, null);
	}

	public override string ToString(float P_0)
	{
		return (string)ChangeType(P_0, StringType, null);
	}

	public override string ToString(object P_0, IXmlNamespaceResolver P_1)
	{
		return (string)ChangeType(P_0, StringType, P_1);
	}

	public override string ToString(object P_0)
	{
		return ToString(P_0, null);
	}

	public override object ChangeType(bool P_0, Type P_1)
	{
		return ChangeType(P_0, P_1, null);
	}

	public override object ChangeType(DateTime P_0, Type P_1)
	{
		return ChangeType(P_0, P_1, null);
	}

	public override object ChangeType(decimal P_0, Type P_1)
	{
		return ChangeType(P_0, P_1, null);
	}

	public override object ChangeType(double P_0, Type P_1)
	{
		return ChangeType(P_0, P_1, null);
	}

	public override object ChangeType(int P_0, Type P_1)
	{
		return ChangeType(P_0, P_1, null);
	}

	public override object ChangeType(long P_0, Type P_1)
	{
		return ChangeType(P_0, P_1, null);
	}

	public override object ChangeType(string P_0, Type P_1, IXmlNamespaceResolver P_2)
	{
		return ChangeType((object)P_0, P_1, P_2);
	}

	public override object ChangeType(object P_0, Type P_1)
	{
		return ChangeType(P_0, P_1, null);
	}

	protected static bool IsDerivedFrom(Type P_0, Type P_1)
	{
		while (P_0 != null)
		{
			if (P_0 == P_1)
			{
				return true;
			}
			P_0 = P_0.BaseType;
		}
		return false;
	}

	protected Exception CreateInvalidClrMappingException(Type P_0, Type P_1)
	{
		if (P_0 == P_1)
		{
			return new InvalidCastException(System.SR.Format("XmlConvert_TypeBadMapping", XmlTypeName, P_0.Name));
		}
		return new InvalidCastException(System.SR.Format("XmlConvert_TypeBadMapping2", XmlTypeName, P_0.Name, P_1.Name));
	}

	protected static string QNameToString(XmlQualifiedName P_0)
	{
		if (P_0.Namespace.Length == 0)
		{
			return P_0.Name;
		}
		if (P_0.Namespace == "http://www.w3.org/2001/XMLSchema")
		{
			return "xs:" + P_0.Name;
		}
		if (P_0.Namespace == "http://www.w3.org/2003/11/xpath-datatypes")
		{
			return "xdt:" + P_0.Name;
		}
		return "{" + P_0.Namespace + "}" + P_0.Name;
	}

	protected virtual object ChangeListType(object P_0, Type P_1, IXmlNamespaceResolver P_2)
	{
		throw CreateInvalidClrMappingException(P_0.GetType(), P_1);
	}

	protected static byte[] StringToBase64Binary(string P_0)
	{
		return Convert.FromBase64String(XmlConvert.TrimString(P_0));
	}

	protected static DateTime StringToDate(string P_0)
	{
		return new XsdDateTime(P_0, XsdDateTimeFlags.Date);
	}

	protected static DateTime StringToDateTime(string P_0)
	{
		return new XsdDateTime(P_0, XsdDateTimeFlags.DateTime);
	}

	protected static TimeSpan StringToDayTimeDuration(string P_0)
	{
		return new XsdDuration(P_0, XsdDuration.DurationType.DayTimeDuration).ToTimeSpan(XsdDuration.DurationType.DayTimeDuration);
	}

	protected static TimeSpan StringToDuration(string P_0)
	{
		return new XsdDuration(P_0, XsdDuration.DurationType.Duration).ToTimeSpan(XsdDuration.DurationType.Duration);
	}

	protected static DateTime StringToGDay(string P_0)
	{
		return new XsdDateTime(P_0, XsdDateTimeFlags.GDay);
	}

	protected static DateTime StringToGMonth(string P_0)
	{
		return new XsdDateTime(P_0, XsdDateTimeFlags.GMonth);
	}

	protected static DateTime StringToGMonthDay(string P_0)
	{
		return new XsdDateTime(P_0, XsdDateTimeFlags.GMonthDay);
	}

	protected static DateTime StringToGYear(string P_0)
	{
		return new XsdDateTime(P_0, XsdDateTimeFlags.GYear);
	}

	protected static DateTime StringToGYearMonth(string P_0)
	{
		return new XsdDateTime(P_0, XsdDateTimeFlags.GYearMonth);
	}

	protected static DateTimeOffset StringToDateOffset(string P_0)
	{
		return new XsdDateTime(P_0, XsdDateTimeFlags.Date);
	}

	protected static DateTimeOffset StringToDateTimeOffset(string P_0)
	{
		return new XsdDateTime(P_0, XsdDateTimeFlags.DateTime);
	}

	protected static DateTimeOffset StringToGDayOffset(string P_0)
	{
		return new XsdDateTime(P_0, XsdDateTimeFlags.GDay);
	}

	protected static DateTimeOffset StringToGMonthOffset(string P_0)
	{
		return new XsdDateTime(P_0, XsdDateTimeFlags.GMonth);
	}

	protected static DateTimeOffset StringToGMonthDayOffset(string P_0)
	{
		return new XsdDateTime(P_0, XsdDateTimeFlags.GMonthDay);
	}

	protected static DateTimeOffset StringToGYearOffset(string P_0)
	{
		return new XsdDateTime(P_0, XsdDateTimeFlags.GYear);
	}

	protected static DateTimeOffset StringToGYearMonthOffset(string P_0)
	{
		return new XsdDateTime(P_0, XsdDateTimeFlags.GYearMonth);
	}

	protected static byte[] StringToHexBinary(string P_0)
	{
		try
		{
			return XmlConvert.FromBinHexString(XmlConvert.TrimString(P_0), false);
		}
		catch (XmlException ex)
		{
			throw new FormatException(ex.Message);
		}
	}

	protected static XmlQualifiedName StringToQName(string P_0, IXmlNamespaceResolver P_1)
	{
		P_0 = P_0.Trim();
		string text;
		string text2;
		try
		{
			ValidateNames.ParseQNameThrow(P_0, out text, out text2);
		}
		catch (XmlException ex)
		{
			throw new FormatException(ex.Message);
		}
		if (P_1 == null)
		{
			throw new InvalidCastException(System.SR.Format("XmlConvert_TypeNoNamespace", P_0, text));
		}
		string text3 = P_1.LookupNamespace(text);
		if (text3 == null)
		{
			throw new InvalidCastException(System.SR.Format("XmlConvert_TypeNoNamespace", P_0, text));
		}
		return new XmlQualifiedName(text2, text3);
	}

	protected static DateTime StringToTime(string P_0)
	{
		return new XsdDateTime(P_0, XsdDateTimeFlags.Time);
	}

	protected static DateTimeOffset StringToTimeOffset(string P_0)
	{
		return new XsdDateTime(P_0, XsdDateTimeFlags.Time);
	}

	protected static TimeSpan StringToYearMonthDuration(string P_0)
	{
		return new XsdDuration(P_0, XsdDuration.DurationType.YearMonthDuration).ToTimeSpan(XsdDuration.DurationType.YearMonthDuration);
	}

	protected static string AnyUriToString(Uri P_0)
	{
		return P_0.OriginalString;
	}

	protected static string Base64BinaryToString(byte[] P_0)
	{
		return Convert.ToBase64String(P_0);
	}

	protected static string DateToString(DateTime P_0)
	{
		return new XsdDateTime(P_0, XsdDateTimeFlags.Date).ToString();
	}

	protected static string DateTimeToString(DateTime P_0)
	{
		return new XsdDateTime(P_0, XsdDateTimeFlags.DateTime).ToString();
	}

	protected static string DayTimeDurationToString(TimeSpan P_0)
	{
		return new XsdDuration(P_0, XsdDuration.DurationType.DayTimeDuration).ToString(XsdDuration.DurationType.DayTimeDuration);
	}

	protected static string DurationToString(TimeSpan P_0)
	{
		return new XsdDuration(P_0, XsdDuration.DurationType.Duration).ToString(XsdDuration.DurationType.Duration);
	}

	protected static string GDayToString(DateTime P_0)
	{
		return new XsdDateTime(P_0, XsdDateTimeFlags.GDay).ToString();
	}

	protected static string GMonthToString(DateTime P_0)
	{
		return new XsdDateTime(P_0, XsdDateTimeFlags.GMonth).ToString();
	}

	protected static string GMonthDayToString(DateTime P_0)
	{
		return new XsdDateTime(P_0, XsdDateTimeFlags.GMonthDay).ToString();
	}

	protected static string GYearToString(DateTime P_0)
	{
		return new XsdDateTime(P_0, XsdDateTimeFlags.GYear).ToString();
	}

	protected static string GYearMonthToString(DateTime P_0)
	{
		return new XsdDateTime(P_0, XsdDateTimeFlags.GYearMonth).ToString();
	}

	protected static string DateOffsetToString(DateTimeOffset P_0)
	{
		return new XsdDateTime(P_0, XsdDateTimeFlags.Date).ToString();
	}

	protected static string DateTimeOffsetToString(DateTimeOffset P_0)
	{
		return new XsdDateTime(P_0, XsdDateTimeFlags.DateTime).ToString();
	}

	protected static string GDayOffsetToString(DateTimeOffset P_0)
	{
		return new XsdDateTime(P_0, XsdDateTimeFlags.GDay).ToString();
	}

	protected static string GMonthOffsetToString(DateTimeOffset P_0)
	{
		return new XsdDateTime(P_0, XsdDateTimeFlags.GMonth).ToString();
	}

	protected static string GMonthDayOffsetToString(DateTimeOffset P_0)
	{
		return new XsdDateTime(P_0, XsdDateTimeFlags.GMonthDay).ToString();
	}

	protected static string GYearOffsetToString(DateTimeOffset P_0)
	{
		return new XsdDateTime(P_0, XsdDateTimeFlags.GYear).ToString();
	}

	protected static string GYearMonthOffsetToString(DateTimeOffset P_0)
	{
		return new XsdDateTime(P_0, XsdDateTimeFlags.GYearMonth).ToString();
	}

	protected static string QNameToString(XmlQualifiedName P_0, IXmlNamespaceResolver P_1)
	{
		if (P_1 == null)
		{
			return "{" + P_0.Namespace + "}" + P_0.Name;
		}
		string text = P_1.LookupPrefix(P_0.Namespace);
		if (text == null)
		{
			throw new InvalidCastException(System.SR.Format("XmlConvert_TypeNoPrefix", P_0, P_0.Namespace));
		}
		if (text.Length == 0)
		{
			return P_0.Name;
		}
		return text + ":" + P_0.Name;
	}

	protected static string TimeToString(DateTime P_0)
	{
		return new XsdDateTime(P_0, XsdDateTimeFlags.Time).ToString();
	}

	protected static string TimeOffsetToString(DateTimeOffset P_0)
	{
		return new XsdDateTime(P_0, XsdDateTimeFlags.Time).ToString();
	}

	protected static string YearMonthDurationToString(TimeSpan P_0)
	{
		return new XsdDuration(P_0, XsdDuration.DurationType.YearMonthDuration).ToString(XsdDuration.DurationType.YearMonthDuration);
	}

	internal static DateTime DateTimeOffsetToDateTime(DateTimeOffset P_0)
	{
		return P_0.LocalDateTime;
	}

	internal static int DecimalToInt32(decimal P_0)
	{
		if (P_0 < -2147483648m || P_0 > 2147483647m)
		{
			object[] array = new string[2]
			{
				XmlConvert.ToString(P_0),
				"Int32"
			};
			throw new OverflowException(System.SR.Format("XmlConvert_Overflow", array));
		}
		return (int)P_0;
	}

	protected static long DecimalToInt64(decimal P_0)
	{
		if (P_0 < -9223372036854775808m || P_0 > 9223372036854775807m)
		{
			object[] array = new string[2]
			{
				XmlConvert.ToString(P_0),
				"Int64"
			};
			throw new OverflowException(System.SR.Format("XmlConvert_Overflow", array));
		}
		return (long)P_0;
	}

	protected static ulong DecimalToUInt64(decimal P_0)
	{
		if (P_0 < 0m || P_0 > 18446744073709551615m)
		{
			object[] array = new string[2]
			{
				XmlConvert.ToString(P_0),
				"UInt64"
			};
			throw new OverflowException(System.SR.Format("XmlConvert_Overflow", array));
		}
		return (ulong)P_0;
	}

	protected static byte Int32ToByte(int P_0)
	{
		if (P_0 < 0 || P_0 > 255)
		{
			object[] array = new string[2]
			{
				XmlConvert.ToString(P_0),
				"Byte"
			};
			throw new OverflowException(System.SR.Format("XmlConvert_Overflow", array));
		}
		return (byte)P_0;
	}

	protected static short Int32ToInt16(int P_0)
	{
		if (P_0 < -32768 || P_0 > 32767)
		{
			object[] array = new string[2]
			{
				XmlConvert.ToString(P_0),
				"Int16"
			};
			throw new OverflowException(System.SR.Format("XmlConvert_Overflow", array));
		}
		return (short)P_0;
	}

	protected static sbyte Int32ToSByte(int P_0)
	{
		if (P_0 < -128 || P_0 > 127)
		{
			object[] array = new string[2]
			{
				XmlConvert.ToString(P_0),
				"SByte"
			};
			throw new OverflowException(System.SR.Format("XmlConvert_Overflow", array));
		}
		return (sbyte)P_0;
	}

	protected static ushort Int32ToUInt16(int P_0)
	{
		if (P_0 < 0 || P_0 > 65535)
		{
			object[] array = new string[2]
			{
				XmlConvert.ToString(P_0),
				"UInt16"
			};
			throw new OverflowException(System.SR.Format("XmlConvert_Overflow", array));
		}
		return (ushort)P_0;
	}

	protected static int Int64ToInt32(long P_0)
	{
		if (P_0 < -2147483648 || P_0 > 2147483647)
		{
			object[] array = new string[2]
			{
				XmlConvert.ToString(P_0),
				"Int32"
			};
			throw new OverflowException(System.SR.Format("XmlConvert_Overflow", array));
		}
		return (int)P_0;
	}

	protected static uint Int64ToUInt32(long P_0)
	{
		if (P_0 < 0 || P_0 > 4294967295u)
		{
			object[] array = new string[2]
			{
				XmlConvert.ToString(P_0),
				"UInt32"
			};
			throw new OverflowException(System.SR.Format("XmlConvert_Overflow", array));
		}
		return (uint)P_0;
	}

	protected static DateTime UntypedAtomicToDateTime(string P_0)
	{
		return new XsdDateTime(P_0, XsdDateTimeFlags.AllXsd);
	}

	protected static DateTimeOffset UntypedAtomicToDateTimeOffset(string P_0)
	{
		return new XsdDateTime(P_0, XsdDateTimeFlags.AllXsd);
	}
}
