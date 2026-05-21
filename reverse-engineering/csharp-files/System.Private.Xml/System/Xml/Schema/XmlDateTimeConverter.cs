namespace System.Xml.Schema;

internal sealed class XmlDateTimeConverter : XmlBaseConverter
{
	private XmlDateTimeConverter(XmlSchemaType P_0)
		: base(P_0)
	{
	}

	public static XmlValueConverter Create(XmlSchemaType P_0)
	{
		return new XmlDateTimeConverter(P_0);
	}

	public override DateTime ToDateTime(DateTimeOffset P_0)
	{
		return XmlBaseConverter.DateTimeOffsetToDateTime(P_0);
	}

	public override DateTime ToDateTime(string P_0)
	{
		ArgumentNullException.ThrowIfNull(P_0, "value");
		return base.TypeCode switch
		{
			XmlTypeCode.Date => XmlBaseConverter.StringToDate(P_0), 
			XmlTypeCode.Time => XmlBaseConverter.StringToTime(P_0), 
			XmlTypeCode.GDay => XmlBaseConverter.StringToGDay(P_0), 
			XmlTypeCode.GMonth => XmlBaseConverter.StringToGMonth(P_0), 
			XmlTypeCode.GMonthDay => XmlBaseConverter.StringToGMonthDay(P_0), 
			XmlTypeCode.GYear => XmlBaseConverter.StringToGYear(P_0), 
			XmlTypeCode.GYearMonth => XmlBaseConverter.StringToGYearMonth(P_0), 
			_ => XmlBaseConverter.StringToDateTime(P_0), 
		};
	}

	public override DateTime ToDateTime(object P_0)
	{
		ArgumentNullException.ThrowIfNull(P_0, "value");
		Type type = P_0.GetType();
		if (type == XmlBaseConverter.DateTimeType)
		{
			return (DateTime)P_0;
		}
		if (type == XmlBaseConverter.DateTimeOffsetType)
		{
			return ToDateTime((DateTimeOffset)P_0);
		}
		if (type == XmlBaseConverter.StringType)
		{
			return ToDateTime((string)P_0);
		}
		if (type == XmlBaseConverter.XmlAtomicValueType)
		{
			return ((XmlAtomicValue)P_0).ValueAsDateTime;
		}
		return (DateTime)ChangeListType(P_0, XmlBaseConverter.DateTimeType, null);
	}

	public override DateTimeOffset ToDateTimeOffset(DateTime P_0)
	{
		return new DateTimeOffset(P_0);
	}

	public override DateTimeOffset ToDateTimeOffset(string P_0)
	{
		ArgumentNullException.ThrowIfNull(P_0, "value");
		return base.TypeCode switch
		{
			XmlTypeCode.Date => XmlBaseConverter.StringToDateOffset(P_0), 
			XmlTypeCode.Time => XmlBaseConverter.StringToTimeOffset(P_0), 
			XmlTypeCode.GDay => XmlBaseConverter.StringToGDayOffset(P_0), 
			XmlTypeCode.GMonth => XmlBaseConverter.StringToGMonthOffset(P_0), 
			XmlTypeCode.GMonthDay => XmlBaseConverter.StringToGMonthDayOffset(P_0), 
			XmlTypeCode.GYear => XmlBaseConverter.StringToGYearOffset(P_0), 
			XmlTypeCode.GYearMonth => XmlBaseConverter.StringToGYearMonthOffset(P_0), 
			_ => XmlBaseConverter.StringToDateTimeOffset(P_0), 
		};
	}

	public override DateTimeOffset ToDateTimeOffset(object P_0)
	{
		ArgumentNullException.ThrowIfNull(P_0, "value");
		Type type = P_0.GetType();
		if (type == XmlBaseConverter.DateTimeType)
		{
			return ToDateTimeOffset((DateTime)P_0);
		}
		if (type == XmlBaseConverter.DateTimeOffsetType)
		{
			return (DateTimeOffset)P_0;
		}
		if (type == XmlBaseConverter.StringType)
		{
			return ToDateTimeOffset((string)P_0);
		}
		if (type == XmlBaseConverter.XmlAtomicValueType)
		{
			return ((XmlAtomicValue)P_0).ValueAsDateTime;
		}
		return (DateTimeOffset)ChangeListType(P_0, XmlBaseConverter.DateTimeOffsetType, null);
	}

	public override string ToString(DateTime P_0)
	{
		return base.TypeCode switch
		{
			XmlTypeCode.Date => XmlBaseConverter.DateToString(P_0), 
			XmlTypeCode.Time => XmlBaseConverter.TimeToString(P_0), 
			XmlTypeCode.GDay => XmlBaseConverter.GDayToString(P_0), 
			XmlTypeCode.GMonth => XmlBaseConverter.GMonthToString(P_0), 
			XmlTypeCode.GMonthDay => XmlBaseConverter.GMonthDayToString(P_0), 
			XmlTypeCode.GYear => XmlBaseConverter.GYearToString(P_0), 
			XmlTypeCode.GYearMonth => XmlBaseConverter.GYearMonthToString(P_0), 
			_ => XmlBaseConverter.DateTimeToString(P_0), 
		};
	}

	public override string ToString(DateTimeOffset P_0)
	{
		return base.TypeCode switch
		{
			XmlTypeCode.Date => XmlBaseConverter.DateOffsetToString(P_0), 
			XmlTypeCode.Time => XmlBaseConverter.TimeOffsetToString(P_0), 
			XmlTypeCode.GDay => XmlBaseConverter.GDayOffsetToString(P_0), 
			XmlTypeCode.GMonth => XmlBaseConverter.GMonthOffsetToString(P_0), 
			XmlTypeCode.GMonthDay => XmlBaseConverter.GMonthDayOffsetToString(P_0), 
			XmlTypeCode.GYear => XmlBaseConverter.GYearOffsetToString(P_0), 
			XmlTypeCode.GYearMonth => XmlBaseConverter.GYearMonthOffsetToString(P_0), 
			_ => XmlBaseConverter.DateTimeOffsetToString(P_0), 
		};
	}

	public override string ToString(object P_0, IXmlNamespaceResolver P_1)
	{
		ArgumentNullException.ThrowIfNull(P_0, "value");
		Type type = P_0.GetType();
		if (type == XmlBaseConverter.DateTimeType)
		{
			return ToString((DateTime)P_0);
		}
		if (type == XmlBaseConverter.DateTimeOffsetType)
		{
			return ToString((DateTimeOffset)P_0);
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

	public override object ChangeType(DateTime P_0, Type P_1)
	{
		ArgumentNullException.ThrowIfNull(P_1, "destinationType");
		if (P_1 == XmlBaseConverter.ObjectType)
		{
			P_1 = base.DefaultClrType;
		}
		if (P_1 == XmlBaseConverter.DateTimeType)
		{
			return P_0;
		}
		if (P_1 == XmlBaseConverter.DateTimeOffsetType)
		{
			return ToDateTimeOffset(P_0);
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
		if (P_1 == XmlBaseConverter.DateTimeType)
		{
			return ToDateTime(P_0);
		}
		if (P_1 == XmlBaseConverter.DateTimeOffsetType)
		{
			return ToDateTimeOffset(P_0);
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
		if (P_1 == XmlBaseConverter.DateTimeType)
		{
			return ToDateTime(P_0);
		}
		if (P_1 == XmlBaseConverter.DateTimeOffsetType)
		{
			return ToDateTimeOffset(P_0);
		}
		if (P_1 == XmlBaseConverter.StringType)
		{
			return ToString(P_0, P_2);
		}
		if (P_1 == XmlBaseConverter.XmlAtomicValueType)
		{
			if (type == XmlBaseConverter.DateTimeType)
			{
				return new XmlAtomicValue(base.SchemaType, (DateTime)P_0);
			}
			if (type == XmlBaseConverter.DateTimeOffsetType)
			{
				return new XmlAtomicValue(base.SchemaType, (DateTimeOffset)P_0);
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
			if (type == XmlBaseConverter.DateTimeType)
			{
				return new XmlAtomicValue(base.SchemaType, (DateTime)P_0);
			}
			if (type == XmlBaseConverter.DateTimeOffsetType)
			{
				return new XmlAtomicValue(base.SchemaType, (DateTimeOffset)P_0);
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
