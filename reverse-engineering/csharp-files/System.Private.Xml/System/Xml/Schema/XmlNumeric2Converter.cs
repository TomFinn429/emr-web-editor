namespace System.Xml.Schema;

internal sealed class XmlNumeric2Converter : XmlBaseConverter
{
	private XmlNumeric2Converter(XmlSchemaType P_0)
		: base(P_0)
	{
	}

	public static XmlValueConverter Create(XmlSchemaType P_0)
	{
		return new XmlNumeric2Converter(P_0);
	}

	public override double ToDouble(string P_0)
	{
		ArgumentNullException.ThrowIfNull(P_0, "value");
		if (base.TypeCode == XmlTypeCode.Float)
		{
			return XmlConvert.ToSingle(P_0);
		}
		return XmlConvert.ToDouble(P_0);
	}

	public override double ToDouble(object P_0)
	{
		ArgumentNullException.ThrowIfNull(P_0, "value");
		Type type = P_0.GetType();
		if (type == XmlBaseConverter.DoubleType)
		{
			return (double)P_0;
		}
		if (type == XmlBaseConverter.SingleType)
		{
			return (float)P_0;
		}
		if (type == XmlBaseConverter.StringType)
		{
			return ToDouble((string)P_0);
		}
		if (type == XmlBaseConverter.XmlAtomicValueType)
		{
			return ((XmlAtomicValue)P_0).ValueAsDouble;
		}
		return (double)ChangeListType(P_0, XmlBaseConverter.DoubleType, null);
	}

	public override float ToSingle(double P_0)
	{
		return (float)P_0;
	}

	public override float ToSingle(string P_0)
	{
		ArgumentNullException.ThrowIfNull(P_0, "value");
		if (base.TypeCode == XmlTypeCode.Float)
		{
			return XmlConvert.ToSingle(P_0);
		}
		return (float)XmlConvert.ToDouble(P_0);
	}

	public override float ToSingle(object P_0)
	{
		ArgumentNullException.ThrowIfNull(P_0, "value");
		Type type = P_0.GetType();
		if (type == XmlBaseConverter.DoubleType)
		{
			return (float)(double)P_0;
		}
		if (type == XmlBaseConverter.SingleType)
		{
			return (float)P_0;
		}
		if (type == XmlBaseConverter.StringType)
		{
			return ToSingle((string)P_0);
		}
		if (type == XmlBaseConverter.XmlAtomicValueType)
		{
			return (float)((XmlAtomicValue)P_0).ValueAs(XmlBaseConverter.SingleType);
		}
		return (float)ChangeListType(P_0, XmlBaseConverter.SingleType, null);
	}

	public override string ToString(double P_0)
	{
		if (base.TypeCode == XmlTypeCode.Float)
		{
			return XmlConvert.ToString(ToSingle(P_0));
		}
		return XmlConvert.ToString(P_0);
	}

	public override string ToString(float P_0)
	{
		if (base.TypeCode == XmlTypeCode.Float)
		{
			return XmlConvert.ToString(P_0);
		}
		return XmlConvert.ToString((double)P_0);
	}

	public override string ToString(object P_0, IXmlNamespaceResolver P_1)
	{
		ArgumentNullException.ThrowIfNull(P_0, "value");
		Type type = P_0.GetType();
		if (type == XmlBaseConverter.DoubleType)
		{
			return ToString((double)P_0);
		}
		if (type == XmlBaseConverter.SingleType)
		{
			return ToString((float)P_0);
		}
		if (type == XmlBaseConverter.StringType)
		{
			return (string)P_0;
		}
		if (type == XmlBaseConverter.XmlAtomicValueType)
		{
			return ((XmlAtomicValue)P_0).Value;
		}
		return (string)ChangeListType(P_0, XmlBaseConverter.StringType, P_1);
	}

	public override object ChangeType(double P_0, Type P_1)
	{
		ArgumentNullException.ThrowIfNull(P_1, "destinationType");
		if (P_1 == XmlBaseConverter.ObjectType)
		{
			P_1 = base.DefaultClrType;
		}
		if (P_1 == XmlBaseConverter.DoubleType)
		{
			return P_0;
		}
		if (P_1 == XmlBaseConverter.SingleType)
		{
			return (float)P_0;
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
		return ChangeListType(P_0, P_1, null);
	}

	public override object ChangeType(string P_0, Type P_1, IXmlNamespaceResolver P_2)
	{
		ArgumentNullException.ThrowIfNull(P_0, "value");
		ArgumentNullException.ThrowIfNull(P_1, "destinationType");
		if (P_1 == XmlBaseConverter.ObjectType)
		{
			P_1 = base.DefaultClrType;
		}
		if (P_1 == XmlBaseConverter.DoubleType)
		{
			return ToDouble(P_0);
		}
		if (P_1 == XmlBaseConverter.SingleType)
		{
			return ToSingle(P_0);
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
		return ChangeListType(P_0, P_1, P_2);
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
		if (P_1 == XmlBaseConverter.DoubleType)
		{
			return ToDouble(P_0);
		}
		if (P_1 == XmlBaseConverter.SingleType)
		{
			return ToSingle(P_0);
		}
		if (P_1 == XmlBaseConverter.StringType)
		{
			return ToString(P_0, P_2);
		}
		if (P_1 == XmlBaseConverter.XmlAtomicValueType)
		{
			if (type == XmlBaseConverter.DoubleType)
			{
				return new XmlAtomicValue(base.SchemaType, (double)P_0);
			}
			if (type == XmlBaseConverter.SingleType)
			{
				return new XmlAtomicValue(base.SchemaType, P_0);
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
			if (type == XmlBaseConverter.DoubleType)
			{
				return new XmlAtomicValue(base.SchemaType, (double)P_0);
			}
			if (type == XmlBaseConverter.SingleType)
			{
				return new XmlAtomicValue(base.SchemaType, P_0);
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
		return ChangeListType(P_0, P_1, P_2);
	}
}
