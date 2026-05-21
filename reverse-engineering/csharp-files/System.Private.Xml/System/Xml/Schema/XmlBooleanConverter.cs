namespace System.Xml.Schema;

internal sealed class XmlBooleanConverter : XmlBaseConverter
{
	private XmlBooleanConverter(XmlSchemaType P_0)
		: base(P_0)
	{
	}

	public static XmlValueConverter Create(XmlSchemaType P_0)
	{
		return new XmlBooleanConverter(P_0);
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
		if (type == XmlBaseConverter.BooleanType)
		{
			return (bool)P_0;
		}
		if (type == XmlBaseConverter.StringType)
		{
			return XmlConvert.ToBoolean((string)P_0);
		}
		if (type == XmlBaseConverter.XmlAtomicValueType)
		{
			return ((XmlAtomicValue)P_0).ValueAsBoolean;
		}
		return (bool)ChangeListType(P_0, XmlBaseConverter.BooleanType, null);
	}

	public override string ToString(bool P_0)
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

	public override object ChangeType(bool P_0, Type P_1)
	{
		ArgumentNullException.ThrowIfNull(P_1, "destinationType");
		if (P_1 == XmlBaseConverter.ObjectType)
		{
			P_1 = base.DefaultClrType;
		}
		if (P_1 == XmlBaseConverter.BooleanType)
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
		if (P_1 == XmlBaseConverter.BooleanType)
		{
			return XmlConvert.ToBoolean(P_0);
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
		if (P_1 == XmlBaseConverter.BooleanType)
		{
			return ToBoolean(P_0);
		}
		if (P_1 == XmlBaseConverter.StringType)
		{
			return ToString(P_0, P_2);
		}
		if (P_1 == XmlBaseConverter.XmlAtomicValueType)
		{
			if (type == XmlBaseConverter.BooleanType)
			{
				return new XmlAtomicValue(base.SchemaType, (bool)P_0);
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
			if (type == XmlBaseConverter.BooleanType)
			{
				return new XmlAtomicValue(base.SchemaType, (bool)P_0);
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
