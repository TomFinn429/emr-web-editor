using System.Xml.XPath;

namespace System.Xml.Schema;

internal sealed class XmlMiscConverter : XmlBaseConverter
{
	private XmlMiscConverter(XmlSchemaType P_0)
		: base(P_0)
	{
	}

	public static XmlValueConverter Create(XmlSchemaType P_0)
	{
		return new XmlMiscConverter(P_0);
	}

	public override string ToString(object P_0, IXmlNamespaceResolver P_1)
	{
		ArgumentNullException.ThrowIfNull(P_0, "value");
		Type type = P_0.GetType();
		if (type == XmlBaseConverter.ByteArrayType)
		{
			switch (base.TypeCode)
			{
			case XmlTypeCode.Base64Binary:
				return XmlBaseConverter.Base64BinaryToString((byte[])P_0);
			case XmlTypeCode.HexBinary:
				return XmlConvert.ToBinHexString((byte[])P_0);
			}
		}
		if (type == XmlBaseConverter.StringType)
		{
			return (string)P_0;
		}
		if (XmlBaseConverter.IsDerivedFrom(type, XmlBaseConverter.UriType) && base.TypeCode == XmlTypeCode.AnyUri)
		{
			return XmlBaseConverter.AnyUriToString((Uri)P_0);
		}
		if (type == XmlBaseConverter.TimeSpanType)
		{
			switch (base.TypeCode)
			{
			case XmlTypeCode.DayTimeDuration:
				return XmlBaseConverter.DayTimeDurationToString((TimeSpan)P_0);
			case XmlTypeCode.Duration:
				return XmlBaseConverter.DurationToString((TimeSpan)P_0);
			case XmlTypeCode.YearMonthDuration:
				return XmlBaseConverter.YearMonthDurationToString((TimeSpan)P_0);
			}
		}
		if (XmlBaseConverter.IsDerivedFrom(type, XmlBaseConverter.XmlQualifiedNameType))
		{
			switch (base.TypeCode)
			{
			case XmlTypeCode.Notation:
				return XmlBaseConverter.QNameToString((XmlQualifiedName)P_0, P_1);
			case XmlTypeCode.QName:
				return XmlBaseConverter.QNameToString((XmlQualifiedName)P_0, P_1);
			}
		}
		return (string)ChangeTypeWildcardDestination(P_0, XmlBaseConverter.StringType, P_1);
	}

	public override object ChangeType(string P_0, Type P_1, IXmlNamespaceResolver P_2)
	{
		ArgumentNullException.ThrowIfNull(P_0, "value");
		ArgumentNullException.ThrowIfNull(P_1, "destinationType");
		if (P_1 == XmlBaseConverter.ObjectType)
		{
			P_1 = base.DefaultClrType;
		}
		if (P_1 == XmlBaseConverter.ByteArrayType)
		{
			switch (base.TypeCode)
			{
			case XmlTypeCode.Base64Binary:
				return XmlBaseConverter.StringToBase64Binary(P_0);
			case XmlTypeCode.HexBinary:
				return XmlBaseConverter.StringToHexBinary(P_0);
			}
		}
		if (P_1 == XmlBaseConverter.XmlQualifiedNameType)
		{
			switch (base.TypeCode)
			{
			case XmlTypeCode.Notation:
				return XmlBaseConverter.StringToQName(P_0, P_2);
			case XmlTypeCode.QName:
				return XmlBaseConverter.StringToQName(P_0, P_2);
			}
		}
		if (P_1 == XmlBaseConverter.StringType)
		{
			return P_0;
		}
		if (P_1 == XmlBaseConverter.TimeSpanType)
		{
			switch (base.TypeCode)
			{
			case XmlTypeCode.DayTimeDuration:
				return XmlBaseConverter.StringToDayTimeDuration(P_0);
			case XmlTypeCode.Duration:
				return XmlBaseConverter.StringToDuration(P_0);
			case XmlTypeCode.YearMonthDuration:
				return XmlBaseConverter.StringToYearMonthDuration(P_0);
			}
		}
		if (P_1 == XmlBaseConverter.UriType && base.TypeCode == XmlTypeCode.AnyUri)
		{
			return XmlConvert.ToUri(P_0);
		}
		if (P_1 == XmlBaseConverter.XmlAtomicValueType)
		{
			return new XmlAtomicValue(base.SchemaType, P_0, P_2);
		}
		return ChangeTypeWildcardSource(P_0, P_1, P_2);
	}

	public override object ChangeType(object P_0, Type P_1, IXmlNamespaceResolver P_2)
	{
		ArgumentNullException.ThrowIfNull(P_0, "value");
		ArgumentNullException.ThrowIfNull(P_1, "destinationType");
		Type type = P_0.GetType();
		if (P_1 == XmlBaseConverter.ObjectType)
		{
			P_1 = base.DefaultClrType;
		}
		if (P_1 == XmlBaseConverter.ByteArrayType)
		{
			if (type == XmlBaseConverter.ByteArrayType)
			{
				switch (base.TypeCode)
				{
				case XmlTypeCode.Base64Binary:
					return (byte[])P_0;
				case XmlTypeCode.HexBinary:
					return (byte[])P_0;
				}
			}
			if (type == XmlBaseConverter.StringType)
			{
				switch (base.TypeCode)
				{
				case XmlTypeCode.Base64Binary:
					return XmlBaseConverter.StringToBase64Binary((string)P_0);
				case XmlTypeCode.HexBinary:
					return XmlBaseConverter.StringToHexBinary((string)P_0);
				}
			}
		}
		if (P_1 == XmlBaseConverter.XmlQualifiedNameType)
		{
			if (type == XmlBaseConverter.StringType)
			{
				switch (base.TypeCode)
				{
				case XmlTypeCode.Notation:
					return XmlBaseConverter.StringToQName((string)P_0, P_2);
				case XmlTypeCode.QName:
					return XmlBaseConverter.StringToQName((string)P_0, P_2);
				}
			}
			if (XmlBaseConverter.IsDerivedFrom(type, XmlBaseConverter.XmlQualifiedNameType))
			{
				switch (base.TypeCode)
				{
				case XmlTypeCode.Notation:
					return (XmlQualifiedName)P_0;
				case XmlTypeCode.QName:
					return (XmlQualifiedName)P_0;
				}
			}
		}
		if (P_1 == XmlBaseConverter.StringType)
		{
			return ToString(P_0, P_2);
		}
		if (P_1 == XmlBaseConverter.TimeSpanType)
		{
			if (type == XmlBaseConverter.StringType)
			{
				switch (base.TypeCode)
				{
				case XmlTypeCode.DayTimeDuration:
					return XmlBaseConverter.StringToDayTimeDuration((string)P_0);
				case XmlTypeCode.Duration:
					return XmlBaseConverter.StringToDuration((string)P_0);
				case XmlTypeCode.YearMonthDuration:
					return XmlBaseConverter.StringToYearMonthDuration((string)P_0);
				}
			}
			if (type == XmlBaseConverter.TimeSpanType)
			{
				switch (base.TypeCode)
				{
				case XmlTypeCode.DayTimeDuration:
					return (TimeSpan)P_0;
				case XmlTypeCode.Duration:
					return (TimeSpan)P_0;
				case XmlTypeCode.YearMonthDuration:
					return (TimeSpan)P_0;
				}
			}
		}
		if (P_1 == XmlBaseConverter.UriType)
		{
			if (type == XmlBaseConverter.StringType && base.TypeCode == XmlTypeCode.AnyUri)
			{
				return XmlConvert.ToUri((string)P_0);
			}
			if (XmlBaseConverter.IsDerivedFrom(type, XmlBaseConverter.UriType) && base.TypeCode == XmlTypeCode.AnyUri)
			{
				return (Uri)P_0;
			}
		}
		if (P_1 == XmlBaseConverter.XmlAtomicValueType)
		{
			if (type == XmlBaseConverter.ByteArrayType)
			{
				switch (base.TypeCode)
				{
				case XmlTypeCode.Base64Binary:
					return new XmlAtomicValue(base.SchemaType, P_0);
				case XmlTypeCode.HexBinary:
					return new XmlAtomicValue(base.SchemaType, P_0);
				}
			}
			if (type == XmlBaseConverter.StringType)
			{
				return new XmlAtomicValue(base.SchemaType, (string)P_0, P_2);
			}
			if (type == XmlBaseConverter.TimeSpanType)
			{
				switch (base.TypeCode)
				{
				case XmlTypeCode.DayTimeDuration:
					return new XmlAtomicValue(base.SchemaType, P_0);
				case XmlTypeCode.Duration:
					return new XmlAtomicValue(base.SchemaType, P_0);
				case XmlTypeCode.YearMonthDuration:
					return new XmlAtomicValue(base.SchemaType, P_0);
				}
			}
			if (XmlBaseConverter.IsDerivedFrom(type, XmlBaseConverter.UriType) && base.TypeCode == XmlTypeCode.AnyUri)
			{
				return new XmlAtomicValue(base.SchemaType, P_0);
			}
			if (type == XmlBaseConverter.XmlAtomicValueType)
			{
				return (XmlAtomicValue)P_0;
			}
			if (XmlBaseConverter.IsDerivedFrom(type, XmlBaseConverter.XmlQualifiedNameType))
			{
				switch (base.TypeCode)
				{
				case XmlTypeCode.Notation:
					return new XmlAtomicValue(base.SchemaType, P_0, P_2);
				case XmlTypeCode.QName:
					return new XmlAtomicValue(base.SchemaType, P_0, P_2);
				}
			}
		}
		if (P_1 == XmlBaseConverter.XPathItemType && type == XmlBaseConverter.XmlAtomicValueType)
		{
			return (XmlAtomicValue)P_0;
		}
		if (P_1 == XmlBaseConverter.XPathItemType)
		{
			return (XPathItem)ChangeType(P_0, XmlBaseConverter.XmlAtomicValueType, P_2);
		}
		if (type == XmlBaseConverter.XmlAtomicValueType)
		{
			return ((XmlAtomicValue)P_0).ValueAs(P_1, P_2);
		}
		return ChangeListType(P_0, P_1, P_2);
	}

	private object ChangeTypeWildcardDestination(object P_0, Type P_1, IXmlNamespaceResolver P_2)
	{
		Type type = P_0.GetType();
		if (type == XmlBaseConverter.XmlAtomicValueType)
		{
			return ((XmlAtomicValue)P_0).ValueAs(P_1, P_2);
		}
		return ChangeListType(P_0, P_1, P_2);
	}

	private object ChangeTypeWildcardSource(object P_0, Type P_1, IXmlNamespaceResolver P_2)
	{
		if (P_1 == XmlBaseConverter.XPathItemType)
		{
			return (XPathItem)ChangeType(P_0, XmlBaseConverter.XmlAtomicValueType, P_2);
		}
		return ChangeListType(P_0, P_1, P_2);
	}
}
