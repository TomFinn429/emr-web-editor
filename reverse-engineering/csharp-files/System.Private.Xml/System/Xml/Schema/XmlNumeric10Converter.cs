namespace System.Xml.Schema;

internal sealed class XmlNumeric10Converter : XmlBaseConverter
{
	private XmlNumeric10Converter(XmlSchemaType P_0)
		: base(P_0)
	{
	}

	public static XmlValueConverter Create(XmlSchemaType P_0)
	{
		return new XmlNumeric10Converter(P_0);
	}

	public override decimal ToDecimal(string P_0)
	{
		ArgumentNullException.ThrowIfNull(P_0, "value");
		if (base.TypeCode == XmlTypeCode.Decimal)
		{
			return XmlConvert.ToDecimal(P_0);
		}
		return XmlConvert.ToInteger(P_0);
	}

	public override decimal ToDecimal(object P_0)
	{
		ArgumentNullException.ThrowIfNull(P_0, "value");
		Type type = P_0.GetType();
		if (type == XmlBaseConverter.DecimalType)
		{
			return (decimal)P_0;
		}
		if (type == XmlBaseConverter.Int32Type)
		{
			return (int)P_0;
		}
		if (type == XmlBaseConverter.Int64Type)
		{
			return (long)P_0;
		}
		if (type == XmlBaseConverter.StringType)
		{
			return ToDecimal((string)P_0);
		}
		if (type == XmlBaseConverter.XmlAtomicValueType)
		{
			return (decimal)((XmlAtomicValue)P_0).ValueAs(XmlBaseConverter.DecimalType);
		}
		return (decimal)ChangeTypeWildcardDestination(P_0, XmlBaseConverter.DecimalType, null);
	}

	public override int ToInt32(long P_0)
	{
		return XmlBaseConverter.Int64ToInt32(P_0);
	}

	public override int ToInt32(string P_0)
	{
		ArgumentNullException.ThrowIfNull(P_0, "value");
		if (base.TypeCode == XmlTypeCode.Decimal)
		{
			return XmlBaseConverter.DecimalToInt32(XmlConvert.ToDecimal(P_0));
		}
		return XmlConvert.ToInt32(P_0);
	}

	public override int ToInt32(object P_0)
	{
		ArgumentNullException.ThrowIfNull(P_0, "value");
		Type type = P_0.GetType();
		if (type == XmlBaseConverter.DecimalType)
		{
			return XmlBaseConverter.DecimalToInt32((decimal)P_0);
		}
		if (type == XmlBaseConverter.Int32Type)
		{
			return (int)P_0;
		}
		if (type == XmlBaseConverter.Int64Type)
		{
			return XmlBaseConverter.Int64ToInt32((long)P_0);
		}
		if (type == XmlBaseConverter.StringType)
		{
			return ToInt32((string)P_0);
		}
		if (type == XmlBaseConverter.XmlAtomicValueType)
		{
			return ((XmlAtomicValue)P_0).ValueAsInt;
		}
		return (int)ChangeTypeWildcardDestination(P_0, XmlBaseConverter.Int32Type, null);
	}

	public override long ToInt64(int P_0)
	{
		return P_0;
	}

	public override long ToInt64(string P_0)
	{
		ArgumentNullException.ThrowIfNull(P_0, "value");
		if (base.TypeCode == XmlTypeCode.Decimal)
		{
			return XmlBaseConverter.DecimalToInt64(XmlConvert.ToDecimal(P_0));
		}
		return XmlConvert.ToInt64(P_0);
	}

	public override long ToInt64(object P_0)
	{
		ArgumentNullException.ThrowIfNull(P_0, "value");
		Type type = P_0.GetType();
		if (type == XmlBaseConverter.DecimalType)
		{
			return XmlBaseConverter.DecimalToInt64((decimal)P_0);
		}
		if (type == XmlBaseConverter.Int32Type)
		{
			return (int)P_0;
		}
		if (type == XmlBaseConverter.Int64Type)
		{
			return (long)P_0;
		}
		if (type == XmlBaseConverter.StringType)
		{
			return ToInt64((string)P_0);
		}
		if (type == XmlBaseConverter.XmlAtomicValueType)
		{
			return ((XmlAtomicValue)P_0).ValueAsLong;
		}
		return (long)ChangeTypeWildcardDestination(P_0, XmlBaseConverter.Int64Type, null);
	}

	public override string ToString(decimal P_0)
	{
		if (base.TypeCode == XmlTypeCode.Decimal)
		{
			return XmlConvert.ToString(P_0);
		}
		return XmlConvert.ToString(decimal.Truncate(P_0));
	}

	public override string ToString(int P_0)
	{
		return XmlConvert.ToString(P_0);
	}

	public override string ToString(long P_0)
	{
		return XmlConvert.ToString(P_0);
	}

	public override string ToString(object P_0, IXmlNamespaceResolver P_1)
	{
		ArgumentNullException.ThrowIfNull(P_0, "value");
		Type type = P_0.GetType();
		if (type == XmlBaseConverter.DecimalType)
		{
			return ToString((decimal)P_0);
		}
		if (type == XmlBaseConverter.Int32Type)
		{
			return XmlConvert.ToString((int)P_0);
		}
		if (type == XmlBaseConverter.Int64Type)
		{
			return XmlConvert.ToString((long)P_0);
		}
		if (type == XmlBaseConverter.StringType)
		{
			return (string)P_0;
		}
		if (type == XmlBaseConverter.XmlAtomicValueType)
		{
			return ((XmlAtomicValue)P_0).Value;
		}
		return (string)ChangeTypeWildcardDestination(P_0, XmlBaseConverter.StringType, P_1);
	}

	public override object ChangeType(decimal P_0, Type P_1)
	{
		ArgumentNullException.ThrowIfNull(P_1, "destinationType");
		if (P_1 == XmlBaseConverter.ObjectType)
		{
			P_1 = base.DefaultClrType;
		}
		if (P_1 == XmlBaseConverter.DecimalType)
		{
			return P_0;
		}
		if (P_1 == XmlBaseConverter.Int32Type)
		{
			return XmlBaseConverter.DecimalToInt32(P_0);
		}
		if (P_1 == XmlBaseConverter.Int64Type)
		{
			return XmlBaseConverter.DecimalToInt64(P_0);
		}
		if (P_1 == XmlBaseConverter.StringType)
		{
			return ToString(P_0);
		}
		if (P_1 == XmlBaseConverter.XmlAtomicValueType)
		{
			return new XmlAtomicValue(base.SchemaType, P_0);
		}
		if (P_1 == XmlBaseConverter.XPathItemType)
		{
			return new XmlAtomicValue(base.SchemaType, P_0);
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
		if (P_1 == XmlBaseConverter.DecimalType)
		{
			return (decimal)P_0;
		}
		if (P_1 == XmlBaseConverter.Int32Type)
		{
			return P_0;
		}
		if (P_1 == XmlBaseConverter.Int64Type)
		{
			return (long)P_0;
		}
		if (P_1 == XmlBaseConverter.StringType)
		{
			return XmlConvert.ToString(P_0);
		}
		if (P_1 == XmlBaseConverter.XmlAtomicValueType)
		{
			return new XmlAtomicValue(base.SchemaType, P_0);
		}
		if (P_1 == XmlBaseConverter.XPathItemType)
		{
			return new XmlAtomicValue(base.SchemaType, P_0);
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
		if (P_1 == XmlBaseConverter.DecimalType)
		{
			return (decimal)P_0;
		}
		if (P_1 == XmlBaseConverter.Int32Type)
		{
			return XmlBaseConverter.Int64ToInt32(P_0);
		}
		if (P_1 == XmlBaseConverter.Int64Type)
		{
			return P_0;
		}
		if (P_1 == XmlBaseConverter.StringType)
		{
			return XmlConvert.ToString(P_0);
		}
		if (P_1 == XmlBaseConverter.XmlAtomicValueType)
		{
			return new XmlAtomicValue(base.SchemaType, P_0);
		}
		if (P_1 == XmlBaseConverter.XPathItemType)
		{
			return new XmlAtomicValue(base.SchemaType, P_0);
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
		if (P_1 == XmlBaseConverter.DecimalType)
		{
			return ToDecimal(P_0);
		}
		if (P_1 == XmlBaseConverter.Int32Type)
		{
			return ToInt32(P_0);
		}
		if (P_1 == XmlBaseConverter.Int64Type)
		{
			return ToInt64(P_0);
		}
		if (P_1 == XmlBaseConverter.StringType)
		{
			return P_0;
		}
		if (P_1 == XmlBaseConverter.XmlAtomicValueType)
		{
			return new XmlAtomicValue(base.SchemaType, P_0);
		}
		if (P_1 == XmlBaseConverter.XPathItemType)
		{
			return new XmlAtomicValue(base.SchemaType, P_0);
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
		if (P_1 == XmlBaseConverter.DecimalType)
		{
			return ToDecimal(P_0);
		}
		if (P_1 == XmlBaseConverter.Int32Type)
		{
			return ToInt32(P_0);
		}
		if (P_1 == XmlBaseConverter.Int64Type)
		{
			return ToInt64(P_0);
		}
		if (P_1 == XmlBaseConverter.StringType)
		{
			return ToString(P_0, P_2);
		}
		if (P_1 == XmlBaseConverter.XmlAtomicValueType)
		{
			if (type == XmlBaseConverter.DecimalType)
			{
				return new XmlAtomicValue(base.SchemaType, P_0);
			}
			if (type == XmlBaseConverter.Int32Type)
			{
				return new XmlAtomicValue(base.SchemaType, (int)P_0);
			}
			if (type == XmlBaseConverter.Int64Type)
			{
				return new XmlAtomicValue(base.SchemaType, (long)P_0);
			}
			if (type == XmlBaseConverter.StringType)
			{
				return new XmlAtomicValue(base.SchemaType, (string)P_0);
			}
			if (type == XmlBaseConverter.XmlAtomicValueType)
			{
				return (XmlAtomicValue)P_0;
			}
		}
		if (P_1 == XmlBaseConverter.XPathItemType)
		{
			if (type == XmlBaseConverter.DecimalType)
			{
				return new XmlAtomicValue(base.SchemaType, P_0);
			}
			if (type == XmlBaseConverter.Int32Type)
			{
				return new XmlAtomicValue(base.SchemaType, (int)P_0);
			}
			if (type == XmlBaseConverter.Int64Type)
			{
				return new XmlAtomicValue(base.SchemaType, (long)P_0);
			}
			if (type == XmlBaseConverter.StringType)
			{
				return new XmlAtomicValue(base.SchemaType, (string)P_0);
			}
			if (type == XmlBaseConverter.XmlAtomicValueType)
			{
				return (XmlAtomicValue)P_0;
			}
		}
		if (P_1 == XmlBaseConverter.ByteType)
		{
			return XmlBaseConverter.Int32ToByte(ToInt32(P_0));
		}
		if (P_1 == XmlBaseConverter.Int16Type)
		{
			return XmlBaseConverter.Int32ToInt16(ToInt32(P_0));
		}
		if (P_1 == XmlBaseConverter.SByteType)
		{
			return XmlBaseConverter.Int32ToSByte(ToInt32(P_0));
		}
		if (P_1 == XmlBaseConverter.UInt16Type)
		{
			return XmlBaseConverter.Int32ToUInt16(ToInt32(P_0));
		}
		if (P_1 == XmlBaseConverter.UInt32Type)
		{
			return XmlBaseConverter.Int64ToUInt32(ToInt64(P_0));
		}
		if (P_1 == XmlBaseConverter.UInt64Type)
		{
			return XmlBaseConverter.DecimalToUInt64(ToDecimal(P_0));
		}
		if (type == XmlBaseConverter.ByteType)
		{
			return ChangeType((byte)P_0, P_1);
		}
		if (type == XmlBaseConverter.Int16Type)
		{
			return ChangeType((short)P_0, P_1);
		}
		if (type == XmlBaseConverter.SByteType)
		{
			return ChangeType((sbyte)P_0, P_1);
		}
		if (type == XmlBaseConverter.UInt16Type)
		{
			return ChangeType((ushort)P_0, P_1);
		}
		if (type == XmlBaseConverter.UInt32Type)
		{
			return ChangeType((uint)P_0, P_1);
		}
		if (type == XmlBaseConverter.UInt64Type)
		{
			return ChangeType((decimal)(ulong)P_0, P_1);
		}
		return ChangeListType(P_0, P_1, P_2);
	}

	private object ChangeTypeWildcardDestination(object P_0, Type P_1, IXmlNamespaceResolver P_2)
	{
		Type type = P_0.GetType();
		if (type == XmlBaseConverter.ByteType)
		{
			return ChangeType((byte)P_0, P_1);
		}
		if (type == XmlBaseConverter.Int16Type)
		{
			return ChangeType((short)P_0, P_1);
		}
		if (type == XmlBaseConverter.SByteType)
		{
			return ChangeType((sbyte)P_0, P_1);
		}
		if (type == XmlBaseConverter.UInt16Type)
		{
			return ChangeType((ushort)P_0, P_1);
		}
		if (type == XmlBaseConverter.UInt32Type)
		{
			return ChangeType((uint)P_0, P_1);
		}
		if (type == XmlBaseConverter.UInt64Type)
		{
			return ChangeType((decimal)(ulong)P_0, P_1);
		}
		return ChangeListType(P_0, P_1, P_2);
	}

	private object ChangeTypeWildcardSource(object P_0, Type P_1, IXmlNamespaceResolver P_2)
	{
		if (P_1 == XmlBaseConverter.ByteType)
		{
			return XmlBaseConverter.Int32ToByte(ToInt32(P_0));
		}
		if (P_1 == XmlBaseConverter.Int16Type)
		{
			return XmlBaseConverter.Int32ToInt16(ToInt32(P_0));
		}
		if (P_1 == XmlBaseConverter.SByteType)
		{
			return XmlBaseConverter.Int32ToSByte(ToInt32(P_0));
		}
		if (P_1 == XmlBaseConverter.UInt16Type)
		{
			return XmlBaseConverter.Int32ToUInt16(ToInt32(P_0));
		}
		if (P_1 == XmlBaseConverter.UInt32Type)
		{
			return XmlBaseConverter.Int64ToUInt32(ToInt64(P_0));
		}
		if (P_1 == XmlBaseConverter.UInt64Type)
		{
			return XmlBaseConverter.DecimalToUInt64(ToDecimal(P_0));
		}
		return ChangeListType(P_0, P_1, P_2);
	}
}
