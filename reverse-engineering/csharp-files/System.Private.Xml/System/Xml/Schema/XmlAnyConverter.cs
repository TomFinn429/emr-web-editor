using System.Xml.XPath;

namespace System.Xml.Schema;

internal sealed class XmlAnyConverter : XmlBaseConverter
{
	public static readonly XmlValueConverter Item = new XmlAnyConverter(XmlTypeCode.Item);

	public static readonly XmlValueConverter AnyAtomic = new XmlAnyConverter(XmlTypeCode.AnyAtomicType);

	private XmlAnyConverter(XmlTypeCode P_0)
		: base(P_0)
	{
	}

	public override bool ToBoolean(object P_0)
	{
		ArgumentNullException.ThrowIfNull(P_0, "value");
		Type type = P_0.GetType();
		if (type == XmlBaseConverter.XmlAtomicValueType)
		{
			return ((XmlAtomicValue)P_0).ValueAsBoolean;
		}
		return (bool)ChangeTypeWildcardDestination(P_0, XmlBaseConverter.BooleanType, null);
	}

	public override DateTime ToDateTime(object P_0)
	{
		ArgumentNullException.ThrowIfNull(P_0, "value");
		Type type = P_0.GetType();
		if (type == XmlBaseConverter.XmlAtomicValueType)
		{
			return ((XmlAtomicValue)P_0).ValueAsDateTime;
		}
		return (DateTime)ChangeTypeWildcardDestination(P_0, XmlBaseConverter.DateTimeType, null);
	}

	public override DateTimeOffset ToDateTimeOffset(object P_0)
	{
		ArgumentNullException.ThrowIfNull(P_0, "value");
		Type type = P_0.GetType();
		if (type == XmlBaseConverter.XmlAtomicValueType)
		{
			return (DateTimeOffset)((XmlAtomicValue)P_0).ValueAs(XmlBaseConverter.DateTimeOffsetType);
		}
		return (DateTimeOffset)ChangeTypeWildcardDestination(P_0, XmlBaseConverter.DateTimeOffsetType, null);
	}

	public override decimal ToDecimal(object P_0)
	{
		ArgumentNullException.ThrowIfNull(P_0, "value");
		Type type = P_0.GetType();
		if (type == XmlBaseConverter.XmlAtomicValueType)
		{
			return (decimal)((XmlAtomicValue)P_0).ValueAs(XmlBaseConverter.DecimalType);
		}
		return (decimal)ChangeTypeWildcardDestination(P_0, XmlBaseConverter.DecimalType, null);
	}

	public override double ToDouble(object P_0)
	{
		ArgumentNullException.ThrowIfNull(P_0, "value");
		Type type = P_0.GetType();
		if (type == XmlBaseConverter.XmlAtomicValueType)
		{
			return ((XmlAtomicValue)P_0).ValueAsDouble;
		}
		return (double)ChangeTypeWildcardDestination(P_0, XmlBaseConverter.DoubleType, null);
	}

	public override int ToInt32(object P_0)
	{
		ArgumentNullException.ThrowIfNull(P_0, "value");
		Type type = P_0.GetType();
		if (type == XmlBaseConverter.XmlAtomicValueType)
		{
			return ((XmlAtomicValue)P_0).ValueAsInt;
		}
		return (int)ChangeTypeWildcardDestination(P_0, XmlBaseConverter.Int32Type, null);
	}

	public override long ToInt64(object P_0)
	{
		ArgumentNullException.ThrowIfNull(P_0, "value");
		Type type = P_0.GetType();
		if (type == XmlBaseConverter.XmlAtomicValueType)
		{
			return ((XmlAtomicValue)P_0).ValueAsLong;
		}
		return (long)ChangeTypeWildcardDestination(P_0, XmlBaseConverter.Int64Type, null);
	}

	public override float ToSingle(object P_0)
	{
		ArgumentNullException.ThrowIfNull(P_0, "value");
		Type type = P_0.GetType();
		if (type == XmlBaseConverter.XmlAtomicValueType)
		{
			return (float)((XmlAtomicValue)P_0).ValueAs(XmlBaseConverter.SingleType);
		}
		return (float)ChangeTypeWildcardDestination(P_0, XmlBaseConverter.SingleType, null);
	}

	public override object ChangeType(bool P_0, Type P_1)
	{
		ArgumentNullException.ThrowIfNull(P_1, "destinationType");
		if (P_1 == XmlBaseConverter.ObjectType)
		{
			P_1 = base.DefaultClrType;
		}
		if (P_1 == XmlBaseConverter.XmlAtomicValueType)
		{
			return new XmlAtomicValue(XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.Boolean), P_0);
		}
		return ChangeTypeWildcardSource(P_0, P_1, null);
	}

	public override object ChangeType(DateTime P_0, Type P_1)
	{
		ArgumentNullException.ThrowIfNull(P_1, "destinationType");
		if (P_1 == XmlBaseConverter.ObjectType)
		{
			P_1 = base.DefaultClrType;
		}
		if (P_1 == XmlBaseConverter.XmlAtomicValueType)
		{
			return new XmlAtomicValue(XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.DateTime), P_0);
		}
		return ChangeTypeWildcardSource(P_0, P_1, null);
	}

	public override object ChangeType(decimal P_0, Type P_1)
	{
		ArgumentNullException.ThrowIfNull(P_1, "destinationType");
		if (P_1 == XmlBaseConverter.ObjectType)
		{
			P_1 = base.DefaultClrType;
		}
		if (P_1 == XmlBaseConverter.XmlAtomicValueType)
		{
			return new XmlAtomicValue(XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.Decimal), P_0);
		}
		return ChangeTypeWildcardSource(P_0, P_1, null);
	}

	public override object ChangeType(double P_0, Type P_1)
	{
		ArgumentNullException.ThrowIfNull(P_1, "destinationType");
		if (P_1 == XmlBaseConverter.ObjectType)
		{
			P_1 = base.DefaultClrType;
		}
		if (P_1 == XmlBaseConverter.XmlAtomicValueType)
		{
			return new XmlAtomicValue(XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.Double), P_0);
		}
		return ChangeTypeWildcardSource(P_0, P_1, null);
	}

	public override object ChangeType(int P_0, Type P_1)
	{
		ArgumentNullException.ThrowIfNull(P_1, "destinationType");
		if (P_1 == XmlBaseConverter.ObjectType)
		{
			P_1 = base.DefaultClrType;
		}
		if (P_1 == XmlBaseConverter.XmlAtomicValueType)
		{
			return new XmlAtomicValue(XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.Int), P_0);
		}
		return ChangeTypeWildcardSource(P_0, P_1, null);
	}

	public override object ChangeType(long P_0, Type P_1)
	{
		ArgumentNullException.ThrowIfNull(P_1, "destinationType");
		if (P_1 == XmlBaseConverter.ObjectType)
		{
			P_1 = base.DefaultClrType;
		}
		if (P_1 == XmlBaseConverter.XmlAtomicValueType)
		{
			return new XmlAtomicValue(XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.Long), P_0);
		}
		return ChangeTypeWildcardSource(P_0, P_1, null);
	}

	public override object ChangeType(string P_0, Type P_1, IXmlNamespaceResolver P_2)
	{
		ArgumentNullException.ThrowIfNull(P_0, "value");
		ArgumentNullException.ThrowIfNull(P_1, "destinationType");
		if (P_1 == XmlBaseConverter.ObjectType)
		{
			P_1 = base.DefaultClrType;
		}
		if (P_1 == XmlBaseConverter.XmlAtomicValueType)
		{
			return new XmlAtomicValue(XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.String), P_0);
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
		if (P_1 == XmlBaseConverter.BooleanType && type == XmlBaseConverter.XmlAtomicValueType)
		{
			return ((XmlAtomicValue)P_0).ValueAsBoolean;
		}
		if (P_1 == XmlBaseConverter.DateTimeType && type == XmlBaseConverter.XmlAtomicValueType)
		{
			return ((XmlAtomicValue)P_0).ValueAsDateTime;
		}
		if (P_1 == XmlBaseConverter.DateTimeOffsetType && type == XmlBaseConverter.XmlAtomicValueType)
		{
			return ((XmlAtomicValue)P_0).ValueAs(XmlBaseConverter.DateTimeOffsetType);
		}
		if (P_1 == XmlBaseConverter.DecimalType && type == XmlBaseConverter.XmlAtomicValueType)
		{
			return (decimal)((XmlAtomicValue)P_0).ValueAs(XmlBaseConverter.DecimalType);
		}
		if (P_1 == XmlBaseConverter.DoubleType && type == XmlBaseConverter.XmlAtomicValueType)
		{
			return ((XmlAtomicValue)P_0).ValueAsDouble;
		}
		if (P_1 == XmlBaseConverter.Int32Type && type == XmlBaseConverter.XmlAtomicValueType)
		{
			return ((XmlAtomicValue)P_0).ValueAsInt;
		}
		if (P_1 == XmlBaseConverter.Int64Type && type == XmlBaseConverter.XmlAtomicValueType)
		{
			return ((XmlAtomicValue)P_0).ValueAsLong;
		}
		if (P_1 == XmlBaseConverter.SingleType && type == XmlBaseConverter.XmlAtomicValueType)
		{
			return (float)((XmlAtomicValue)P_0).ValueAs(XmlBaseConverter.SingleType);
		}
		if (P_1 == XmlBaseConverter.XmlAtomicValueType)
		{
			if (type == XmlBaseConverter.XmlAtomicValueType)
			{
				return (XmlAtomicValue)P_0;
			}
			if (type == XmlBaseConverter.BooleanType)
			{
				return new XmlAtomicValue(XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.Boolean), (bool)P_0);
			}
			if (type == XmlBaseConverter.ByteType)
			{
				return new XmlAtomicValue(XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.UnsignedByte), P_0);
			}
			if (type == XmlBaseConverter.ByteArrayType)
			{
				return new XmlAtomicValue(XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.Base64Binary), P_0);
			}
			if (type == XmlBaseConverter.DateTimeType)
			{
				return new XmlAtomicValue(XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.DateTime), (DateTime)P_0);
			}
			if (type == XmlBaseConverter.DateTimeOffsetType)
			{
				return new XmlAtomicValue(XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.DateTime), (DateTimeOffset)P_0);
			}
			if (type == XmlBaseConverter.DecimalType)
			{
				return new XmlAtomicValue(XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.Decimal), P_0);
			}
			if (type == XmlBaseConverter.DoubleType)
			{
				return new XmlAtomicValue(XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.Double), (double)P_0);
			}
			if (type == XmlBaseConverter.Int16Type)
			{
				return new XmlAtomicValue(XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.Short), P_0);
			}
			if (type == XmlBaseConverter.Int32Type)
			{
				return new XmlAtomicValue(XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.Int), (int)P_0);
			}
			if (type == XmlBaseConverter.Int64Type)
			{
				return new XmlAtomicValue(XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.Long), (long)P_0);
			}
			if (type == XmlBaseConverter.SByteType)
			{
				return new XmlAtomicValue(XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.Byte), P_0);
			}
			if (type == XmlBaseConverter.SingleType)
			{
				return new XmlAtomicValue(XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.Float), P_0);
			}
			if (type == XmlBaseConverter.StringType)
			{
				return new XmlAtomicValue(XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.String), (string)P_0);
			}
			if (type == XmlBaseConverter.TimeSpanType)
			{
				return new XmlAtomicValue(XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.Duration), P_0);
			}
			if (type == XmlBaseConverter.UInt16Type)
			{
				return new XmlAtomicValue(XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.UnsignedShort), P_0);
			}
			if (type == XmlBaseConverter.UInt32Type)
			{
				return new XmlAtomicValue(XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.UnsignedInt), P_0);
			}
			if (type == XmlBaseConverter.UInt64Type)
			{
				return new XmlAtomicValue(XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.UnsignedLong), P_0);
			}
			if (XmlBaseConverter.IsDerivedFrom(type, XmlBaseConverter.UriType))
			{
				return new XmlAtomicValue(XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.AnyUri), P_0);
			}
			if (XmlBaseConverter.IsDerivedFrom(type, XmlBaseConverter.XmlQualifiedNameType))
			{
				return new XmlAtomicValue(XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.QName), P_0, P_2);
			}
		}
		if (P_1 == XmlBaseConverter.XPathItemType)
		{
			if (type == XmlBaseConverter.XmlAtomicValueType)
			{
				return (XmlAtomicValue)P_0;
			}
			if (XmlBaseConverter.IsDerivedFrom(type, XmlBaseConverter.XPathNavigatorType))
			{
				return (XPathNavigator)P_0;
			}
		}
		if (P_1 == XmlBaseConverter.XPathNavigatorType && XmlBaseConverter.IsDerivedFrom(type, XmlBaseConverter.XPathNavigatorType))
		{
			return ToNavigator((XPathNavigator)P_0);
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

	private XPathNavigator ToNavigator(XPathNavigator P_0)
	{
		if (base.TypeCode != XmlTypeCode.Item)
		{
			throw CreateInvalidClrMappingException(XmlBaseConverter.XPathNavigatorType, XmlBaseConverter.XPathNavigatorType);
		}
		return P_0;
	}
}
