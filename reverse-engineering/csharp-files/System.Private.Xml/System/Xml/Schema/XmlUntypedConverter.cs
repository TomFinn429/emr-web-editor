namespace System.Xml.Schema;

internal sealed class XmlUntypedConverter : XmlListConverter
{
	private readonly bool _allowListToList;

	public static readonly XmlValueConverter Untyped = new XmlUntypedConverter(new XmlUntypedConverter(), false);

	public static readonly XmlValueConverter UntypedList = new XmlUntypedConverter(new XmlUntypedConverter(), true);

	private XmlUntypedConverter()
		: base(DatatypeImplementation.UntypedAtomicType)
	{
	}

	private XmlUntypedConverter(XmlUntypedConverter P_0, bool P_1)
		: base(P_0, P_1 ? XmlBaseConverter.StringArrayType : XmlBaseConverter.StringType)
	{
		_allowListToList = P_1;
	}

	public override bool ToBoolean(string P_0)
	{
		ArgumentNullException.ThrowIfNull(P_0, "value");
		return XmlConvert.ToBoolean(P_0);
	}

	public override bool ToBoolean(object P_0)
	{
		ArgumentNullException.ThrowIfNull(P_0, "value");
		Type type = P_0.GetType();
		if (type == XmlBaseConverter.StringType)
		{
			return XmlConvert.ToBoolean((string)P_0);
		}
		return (bool)ChangeTypeWildcardDestination(P_0, XmlBaseConverter.BooleanType, null);
	}

	public override DateTime ToDateTime(string P_0)
	{
		ArgumentNullException.ThrowIfNull(P_0, "value");
		return XmlBaseConverter.UntypedAtomicToDateTime(P_0);
	}

	public override DateTime ToDateTime(object P_0)
	{
		ArgumentNullException.ThrowIfNull(P_0, "value");
		Type type = P_0.GetType();
		if (type == XmlBaseConverter.StringType)
		{
			return XmlBaseConverter.UntypedAtomicToDateTime((string)P_0);
		}
		return (DateTime)ChangeTypeWildcardDestination(P_0, XmlBaseConverter.DateTimeType, null);
	}

	public override DateTimeOffset ToDateTimeOffset(string P_0)
	{
		ArgumentNullException.ThrowIfNull(P_0, "value");
		return XmlBaseConverter.UntypedAtomicToDateTimeOffset(P_0);
	}

	public override DateTimeOffset ToDateTimeOffset(object P_0)
	{
		ArgumentNullException.ThrowIfNull(P_0, "value");
		Type type = P_0.GetType();
		if (type == XmlBaseConverter.StringType)
		{
			return XmlBaseConverter.UntypedAtomicToDateTimeOffset((string)P_0);
		}
		return (DateTimeOffset)ChangeTypeWildcardDestination(P_0, XmlBaseConverter.DateTimeOffsetType, null);
	}

	public override decimal ToDecimal(string P_0)
	{
		ArgumentNullException.ThrowIfNull(P_0, "value");
		return XmlConvert.ToDecimal(P_0);
	}

	public override decimal ToDecimal(object P_0)
	{
		ArgumentNullException.ThrowIfNull(P_0, "value");
		Type type = P_0.GetType();
		if (type == XmlBaseConverter.StringType)
		{
			return XmlConvert.ToDecimal((string)P_0);
		}
		return (decimal)ChangeTypeWildcardDestination(P_0, XmlBaseConverter.DecimalType, null);
	}

	public override double ToDouble(string P_0)
	{
		ArgumentNullException.ThrowIfNull(P_0, "value");
		return XmlConvert.ToDouble(P_0);
	}

	public override double ToDouble(object P_0)
	{
		ArgumentNullException.ThrowIfNull(P_0, "value");
		Type type = P_0.GetType();
		if (type == XmlBaseConverter.StringType)
		{
			return XmlConvert.ToDouble((string)P_0);
		}
		return (double)ChangeTypeWildcardDestination(P_0, XmlBaseConverter.DoubleType, null);
	}

	public override int ToInt32(string P_0)
	{
		ArgumentNullException.ThrowIfNull(P_0, "value");
		return XmlConvert.ToInt32(P_0);
	}

	public override int ToInt32(object P_0)
	{
		ArgumentNullException.ThrowIfNull(P_0, "value");
		Type type = P_0.GetType();
		if (type == XmlBaseConverter.StringType)
		{
			return XmlConvert.ToInt32((string)P_0);
		}
		return (int)ChangeTypeWildcardDestination(P_0, XmlBaseConverter.Int32Type, null);
	}

	public override long ToInt64(string P_0)
	{
		ArgumentNullException.ThrowIfNull(P_0, "value");
		return XmlConvert.ToInt64(P_0);
	}

	public override long ToInt64(object P_0)
	{
		ArgumentNullException.ThrowIfNull(P_0, "value");
		Type type = P_0.GetType();
		if (type == XmlBaseConverter.StringType)
		{
			return XmlConvert.ToInt64((string)P_0);
		}
		return (long)ChangeTypeWildcardDestination(P_0, XmlBaseConverter.Int64Type, null);
	}

	public override float ToSingle(string P_0)
	{
		ArgumentNullException.ThrowIfNull(P_0, "value");
		return XmlConvert.ToSingle(P_0);
	}

	public override float ToSingle(object P_0)
	{
		ArgumentNullException.ThrowIfNull(P_0, "value");
		Type type = P_0.GetType();
		if (type == XmlBaseConverter.StringType)
		{
			return XmlConvert.ToSingle((string)P_0);
		}
		return (float)ChangeTypeWildcardDestination(P_0, XmlBaseConverter.SingleType, null);
	}

	public override string ToString(bool P_0)
	{
		return XmlConvert.ToString(P_0);
	}

	public override string ToString(DateTime P_0)
	{
		return XmlBaseConverter.DateTimeToString(P_0);
	}

	public override string ToString(DateTimeOffset P_0)
	{
		return XmlBaseConverter.DateTimeOffsetToString(P_0);
	}

	public override string ToString(decimal P_0)
	{
		return XmlConvert.ToString(P_0);
	}

	public override string ToString(double P_0)
	{
		return XmlConvert.ToString(P_0);
	}

	public override string ToString(int P_0)
	{
		return XmlConvert.ToString(P_0);
	}

	public override string ToString(long P_0)
	{
		return XmlConvert.ToString(P_0);
	}

	public override string ToString(float P_0)
	{
		return XmlConvert.ToString(P_0);
	}

	public override string ToString(object P_0, IXmlNamespaceResolver P_1)
	{
		ArgumentNullException.ThrowIfNull(P_0, "value");
		Type type = P_0.GetType();
		if (type == XmlBaseConverter.BooleanType)
		{
			return XmlConvert.ToString((bool)P_0);
		}
		if (type == XmlBaseConverter.ByteType)
		{
			return XmlConvert.ToString((byte)P_0);
		}
		if (type == XmlBaseConverter.ByteArrayType)
		{
			return XmlBaseConverter.Base64BinaryToString((byte[])P_0);
		}
		if (type == XmlBaseConverter.DateTimeType)
		{
			return XmlBaseConverter.DateTimeToString((DateTime)P_0);
		}
		if (type == XmlBaseConverter.DateTimeOffsetType)
		{
			return XmlBaseConverter.DateTimeOffsetToString((DateTimeOffset)P_0);
		}
		if (type == XmlBaseConverter.DecimalType)
		{
			return XmlConvert.ToString((decimal)P_0);
		}
		if (type == XmlBaseConverter.DoubleType)
		{
			return XmlConvert.ToString((double)P_0);
		}
		if (type == XmlBaseConverter.Int16Type)
		{
			return XmlConvert.ToString((short)P_0);
		}
		if (type == XmlBaseConverter.Int32Type)
		{
			return XmlConvert.ToString((int)P_0);
		}
		if (type == XmlBaseConverter.Int64Type)
		{
			return XmlConvert.ToString((long)P_0);
		}
		if (type == XmlBaseConverter.SByteType)
		{
			return XmlConvert.ToString((sbyte)P_0);
		}
		if (type == XmlBaseConverter.SingleType)
		{
			return XmlConvert.ToString((float)P_0);
		}
		if (type == XmlBaseConverter.StringType)
		{
			return (string)P_0;
		}
		if (type == XmlBaseConverter.TimeSpanType)
		{
			return XmlBaseConverter.DurationToString((TimeSpan)P_0);
		}
		if (type == XmlBaseConverter.UInt16Type)
		{
			return XmlConvert.ToString((ushort)P_0);
		}
		if (type == XmlBaseConverter.UInt32Type)
		{
			return XmlConvert.ToString((uint)P_0);
		}
		if (type == XmlBaseConverter.UInt64Type)
		{
			return XmlConvert.ToString((ulong)P_0);
		}
		if (XmlBaseConverter.IsDerivedFrom(type, XmlBaseConverter.UriType))
		{
			return XmlBaseConverter.AnyUriToString((Uri)P_0);
		}
		if (type == XmlBaseConverter.XmlAtomicValueType)
		{
			return (string)((XmlAtomicValue)P_0).ValueAs(XmlBaseConverter.StringType, P_1);
		}
		if (XmlBaseConverter.IsDerivedFrom(type, XmlBaseConverter.XmlQualifiedNameType))
		{
			return XmlBaseConverter.QNameToString((XmlQualifiedName)P_0, P_1);
		}
		return (string)ChangeTypeWildcardDestination(P_0, XmlBaseConverter.StringType, P_1);
	}

	public override object ChangeType(bool P_0, Type P_1)
	{
		ArgumentNullException.ThrowIfNull(P_1, "destinationType");
		if (P_1 == XmlBaseConverter.ObjectType)
		{
			P_1 = base.DefaultClrType;
		}
		if (P_1 == XmlBaseConverter.StringType)
		{
			return XmlConvert.ToString(P_0);
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
		if (P_1 == XmlBaseConverter.StringType)
		{
			return XmlBaseConverter.DateTimeToString(P_0);
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
		if (P_1 == XmlBaseConverter.StringType)
		{
			return XmlConvert.ToString(P_0);
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
		if (P_1 == XmlBaseConverter.StringType)
		{
			return XmlConvert.ToString(P_0);
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
		if (P_1 == XmlBaseConverter.StringType)
		{
			return XmlConvert.ToString(P_0);
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
		if (P_1 == XmlBaseConverter.StringType)
		{
			return XmlConvert.ToString(P_0);
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
		if (P_1 == XmlBaseConverter.BooleanType)
		{
			return XmlConvert.ToBoolean(P_0);
		}
		if (P_1 == XmlBaseConverter.ByteType)
		{
			return XmlBaseConverter.Int32ToByte(XmlConvert.ToInt32(P_0));
		}
		if (P_1 == XmlBaseConverter.ByteArrayType)
		{
			return XmlBaseConverter.StringToBase64Binary(P_0);
		}
		if (P_1 == XmlBaseConverter.DateTimeType)
		{
			return XmlBaseConverter.UntypedAtomicToDateTime(P_0);
		}
		if (P_1 == XmlBaseConverter.DateTimeOffsetType)
		{
			return XmlBaseConverter.UntypedAtomicToDateTimeOffset(P_0);
		}
		if (P_1 == XmlBaseConverter.DecimalType)
		{
			return XmlConvert.ToDecimal(P_0);
		}
		if (P_1 == XmlBaseConverter.DoubleType)
		{
			return XmlConvert.ToDouble(P_0);
		}
		if (P_1 == XmlBaseConverter.Int16Type)
		{
			return XmlBaseConverter.Int32ToInt16(XmlConvert.ToInt32(P_0));
		}
		if (P_1 == XmlBaseConverter.Int32Type)
		{
			return XmlConvert.ToInt32(P_0);
		}
		if (P_1 == XmlBaseConverter.Int64Type)
		{
			return XmlConvert.ToInt64(P_0);
		}
		if (P_1 == XmlBaseConverter.SByteType)
		{
			return XmlBaseConverter.Int32ToSByte(XmlConvert.ToInt32(P_0));
		}
		if (P_1 == XmlBaseConverter.SingleType)
		{
			return XmlConvert.ToSingle(P_0);
		}
		if (P_1 == XmlBaseConverter.TimeSpanType)
		{
			return XmlBaseConverter.StringToDuration(P_0);
		}
		if (P_1 == XmlBaseConverter.UInt16Type)
		{
			return XmlBaseConverter.Int32ToUInt16(XmlConvert.ToInt32(P_0));
		}
		if (P_1 == XmlBaseConverter.UInt32Type)
		{
			return XmlBaseConverter.Int64ToUInt32(XmlConvert.ToInt64(P_0));
		}
		if (P_1 == XmlBaseConverter.UInt64Type)
		{
			return XmlBaseConverter.DecimalToUInt64(XmlConvert.ToDecimal(P_0));
		}
		if (P_1 == XmlBaseConverter.UriType)
		{
			return XmlConvert.ToUri(P_0);
		}
		if (P_1 == XmlBaseConverter.XmlAtomicValueType)
		{
			return new XmlAtomicValue(base.SchemaType, P_0);
		}
		if (P_1 == XmlBaseConverter.XmlQualifiedNameType)
		{
			return XmlBaseConverter.StringToQName(P_0, P_2);
		}
		if (P_1 == XmlBaseConverter.XPathItemType)
		{
			return new XmlAtomicValue(base.SchemaType, P_0);
		}
		if (P_1 == XmlBaseConverter.StringType)
		{
			return P_0;
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
		if (P_1 == XmlBaseConverter.BooleanType && type == XmlBaseConverter.StringType)
		{
			return XmlConvert.ToBoolean((string)P_0);
		}
		if (P_1 == XmlBaseConverter.ByteType && type == XmlBaseConverter.StringType)
		{
			return XmlBaseConverter.Int32ToByte(XmlConvert.ToInt32((string)P_0));
		}
		if (P_1 == XmlBaseConverter.ByteArrayType && type == XmlBaseConverter.StringType)
		{
			return XmlBaseConverter.StringToBase64Binary((string)P_0);
		}
		if (P_1 == XmlBaseConverter.DateTimeType && type == XmlBaseConverter.StringType)
		{
			return XmlBaseConverter.UntypedAtomicToDateTime((string)P_0);
		}
		if (P_1 == XmlBaseConverter.DateTimeOffsetType && type == XmlBaseConverter.StringType)
		{
			return XmlBaseConverter.UntypedAtomicToDateTimeOffset((string)P_0);
		}
		if (P_1 == XmlBaseConverter.DecimalType && type == XmlBaseConverter.StringType)
		{
			return XmlConvert.ToDecimal((string)P_0);
		}
		if (P_1 == XmlBaseConverter.DoubleType && type == XmlBaseConverter.StringType)
		{
			return XmlConvert.ToDouble((string)P_0);
		}
		if (P_1 == XmlBaseConverter.Int16Type && type == XmlBaseConverter.StringType)
		{
			return XmlBaseConverter.Int32ToInt16(XmlConvert.ToInt32((string)P_0));
		}
		if (P_1 == XmlBaseConverter.Int32Type && type == XmlBaseConverter.StringType)
		{
			return XmlConvert.ToInt32((string)P_0);
		}
		if (P_1 == XmlBaseConverter.Int64Type && type == XmlBaseConverter.StringType)
		{
			return XmlConvert.ToInt64((string)P_0);
		}
		if (P_1 == XmlBaseConverter.SByteType && type == XmlBaseConverter.StringType)
		{
			return XmlBaseConverter.Int32ToSByte(XmlConvert.ToInt32((string)P_0));
		}
		if (P_1 == XmlBaseConverter.SingleType && type == XmlBaseConverter.StringType)
		{
			return XmlConvert.ToSingle((string)P_0);
		}
		if (P_1 == XmlBaseConverter.TimeSpanType && type == XmlBaseConverter.StringType)
		{
			return XmlBaseConverter.StringToDuration((string)P_0);
		}
		if (P_1 == XmlBaseConverter.UInt16Type && type == XmlBaseConverter.StringType)
		{
			return XmlBaseConverter.Int32ToUInt16(XmlConvert.ToInt32((string)P_0));
		}
		if (P_1 == XmlBaseConverter.UInt32Type && type == XmlBaseConverter.StringType)
		{
			return XmlBaseConverter.Int64ToUInt32(XmlConvert.ToInt64((string)P_0));
		}
		if (P_1 == XmlBaseConverter.UInt64Type && type == XmlBaseConverter.StringType)
		{
			return XmlBaseConverter.DecimalToUInt64(XmlConvert.ToDecimal((string)P_0));
		}
		if (P_1 == XmlBaseConverter.UriType && type == XmlBaseConverter.StringType)
		{
			return XmlConvert.ToUri((string)P_0);
		}
		if (P_1 == XmlBaseConverter.XmlAtomicValueType)
		{
			if (type == XmlBaseConverter.StringType)
			{
				return new XmlAtomicValue(base.SchemaType, (string)P_0);
			}
			if (type == XmlBaseConverter.XmlAtomicValueType)
			{
				return (XmlAtomicValue)P_0;
			}
		}
		if (P_1 == XmlBaseConverter.XmlQualifiedNameType && type == XmlBaseConverter.StringType)
		{
			return XmlBaseConverter.StringToQName((string)P_0, P_2);
		}
		if (P_1 == XmlBaseConverter.XPathItemType)
		{
			if (type == XmlBaseConverter.StringType)
			{
				return new XmlAtomicValue(base.SchemaType, (string)P_0);
			}
			if (type == XmlBaseConverter.XmlAtomicValueType)
			{
				return (XmlAtomicValue)P_0;
			}
		}
		if (P_1 == XmlBaseConverter.StringType)
		{
			return ToString(P_0, P_2);
		}
		if (P_1 == XmlBaseConverter.XmlAtomicValueType)
		{
			return new XmlAtomicValue(base.SchemaType, ToString(P_0, P_2));
		}
		if (P_1 == XmlBaseConverter.XPathItemType)
		{
			return new XmlAtomicValue(base.SchemaType, ToString(P_0, P_2));
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
		if (P_1 == XmlBaseConverter.XmlAtomicValueType)
		{
			return new XmlAtomicValue(base.SchemaType, ToString(P_0, P_2));
		}
		if (P_1 == XmlBaseConverter.XPathItemType)
		{
			return new XmlAtomicValue(base.SchemaType, ToString(P_0, P_2));
		}
		return ChangeListType(P_0, P_1, P_2);
	}

	protected override object ChangeListType(object P_0, Type P_1, IXmlNamespaceResolver P_2)
	{
		Type type = P_0.GetType();
		if (atomicConverter == null || (!_allowListToList && type != XmlBaseConverter.StringType && P_1 != XmlBaseConverter.StringType))
		{
			if (SupportsType(type))
			{
				throw new InvalidCastException(System.SR.Format("XmlConvert_TypeToString", base.XmlTypeName, type.Name));
			}
			if (SupportsType(P_1))
			{
				throw new InvalidCastException(System.SR.Format("XmlConvert_TypeFromString", base.XmlTypeName, P_1.Name));
			}
			throw CreateInvalidClrMappingException(type, P_1);
		}
		return base.ChangeListType(P_0, P_1, P_2);
	}

	private static bool SupportsType(Type P_0)
	{
		if (P_0 == XmlBaseConverter.BooleanType)
		{
			return true;
		}
		if (P_0 == XmlBaseConverter.ByteType)
		{
			return true;
		}
		if (P_0 == XmlBaseConverter.ByteArrayType)
		{
			return true;
		}
		if (P_0 == XmlBaseConverter.DateTimeType)
		{
			return true;
		}
		if (P_0 == XmlBaseConverter.DateTimeOffsetType)
		{
			return true;
		}
		if (P_0 == XmlBaseConverter.DecimalType)
		{
			return true;
		}
		if (P_0 == XmlBaseConverter.DoubleType)
		{
			return true;
		}
		if (P_0 == XmlBaseConverter.Int16Type)
		{
			return true;
		}
		if (P_0 == XmlBaseConverter.Int32Type)
		{
			return true;
		}
		if (P_0 == XmlBaseConverter.Int64Type)
		{
			return true;
		}
		if (P_0 == XmlBaseConverter.SByteType)
		{
			return true;
		}
		if (P_0 == XmlBaseConverter.SingleType)
		{
			return true;
		}
		if (P_0 == XmlBaseConverter.TimeSpanType)
		{
			return true;
		}
		if (P_0 == XmlBaseConverter.UInt16Type)
		{
			return true;
		}
		if (P_0 == XmlBaseConverter.UInt32Type)
		{
			return true;
		}
		if (P_0 == XmlBaseConverter.UInt64Type)
		{
			return true;
		}
		if (P_0 == XmlBaseConverter.UriType)
		{
			return true;
		}
		if (P_0 == XmlBaseConverter.XmlQualifiedNameType)
		{
			return true;
		}
		return false;
	}
}
