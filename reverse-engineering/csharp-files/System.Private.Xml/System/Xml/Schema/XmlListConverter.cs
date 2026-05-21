using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Xml.XPath;

namespace System.Xml.Schema;

internal class XmlListConverter : XmlBaseConverter
{
	protected XmlValueConverter atomicConverter;

	protected XmlListConverter(XmlBaseConverter P_0)
		: base(P_0)
	{
		atomicConverter = P_0;
	}

	protected XmlListConverter(XmlBaseConverter P_0, Type P_1)
		: base(P_0, P_1)
	{
		atomicConverter = P_0;
	}

	protected XmlListConverter(XmlSchemaType P_0)
		: base(P_0)
	{
	}

	public static XmlValueConverter Create(XmlValueConverter P_0)
	{
		if (P_0 == XmlUntypedConverter.Untyped)
		{
			return XmlUntypedConverter.UntypedList;
		}
		if (P_0 == XmlAnyConverter.Item)
		{
			return XmlAnyListConverter.ItemList;
		}
		if (P_0 == XmlAnyConverter.AnyAtomic)
		{
			return XmlAnyListConverter.AnyAtomicList;
		}
		return new XmlListConverter((XmlBaseConverter)P_0);
	}

	public override object ChangeType(object P_0, Type P_1, IXmlNamespaceResolver P_2)
	{
		ArgumentNullException.ThrowIfNull(P_0, "value");
		ArgumentNullException.ThrowIfNull(P_1, "destinationType");
		return ChangeListType(P_0, P_1, P_2);
	}

	protected override object ChangeListType(object P_0, Type P_1, IXmlNamespaceResolver P_2)
	{
		Type type = P_0.GetType();
		if (P_1 == XmlBaseConverter.ObjectType)
		{
			P_1 = base.DefaultClrType;
		}
		if (!(P_0 is IEnumerable) || !IsListType(P_1))
		{
			throw CreateInvalidClrMappingException(type, P_1);
		}
		if (P_1 == XmlBaseConverter.StringType)
		{
			if (type == XmlBaseConverter.StringType)
			{
				return P_0;
			}
			return ListAsString((IEnumerable)P_0, P_2);
		}
		if (type == XmlBaseConverter.StringType)
		{
			P_0 = StringAsList((string)P_0);
		}
		if (P_1.IsArray)
		{
			Type elementType = P_1.GetElementType();
			if (elementType == XmlBaseConverter.ObjectType)
			{
				return ToArray<object>(P_0, P_2);
			}
			if (type == P_1)
			{
				return P_0;
			}
			if (elementType == XmlBaseConverter.BooleanType)
			{
				return ToArray<bool>(P_0, P_2);
			}
			if (elementType == XmlBaseConverter.ByteType)
			{
				return ToArray<byte>(P_0, P_2);
			}
			if (elementType == XmlBaseConverter.ByteArrayType)
			{
				return ToArray<byte[]>(P_0, P_2);
			}
			if (elementType == XmlBaseConverter.DateTimeType)
			{
				return ToArray<DateTime>(P_0, P_2);
			}
			if (elementType == XmlBaseConverter.DateTimeOffsetType)
			{
				return ToArray<DateTimeOffset>(P_0, P_2);
			}
			if (elementType == XmlBaseConverter.DecimalType)
			{
				return ToArray<decimal>(P_0, P_2);
			}
			if (elementType == XmlBaseConverter.DoubleType)
			{
				return ToArray<double>(P_0, P_2);
			}
			if (elementType == XmlBaseConverter.Int16Type)
			{
				return ToArray<short>(P_0, P_2);
			}
			if (elementType == XmlBaseConverter.Int32Type)
			{
				return ToArray<int>(P_0, P_2);
			}
			if (elementType == XmlBaseConverter.Int64Type)
			{
				return ToArray<long>(P_0, P_2);
			}
			if (elementType == XmlBaseConverter.SByteType)
			{
				return ToArray<sbyte>(P_0, P_2);
			}
			if (elementType == XmlBaseConverter.SingleType)
			{
				return ToArray<float>(P_0, P_2);
			}
			if (elementType == XmlBaseConverter.StringType)
			{
				return ToArray<string>(P_0, P_2);
			}
			if (elementType == XmlBaseConverter.TimeSpanType)
			{
				return ToArray<TimeSpan>(P_0, P_2);
			}
			if (elementType == XmlBaseConverter.UInt16Type)
			{
				return ToArray<ushort>(P_0, P_2);
			}
			if (elementType == XmlBaseConverter.UInt32Type)
			{
				return ToArray<uint>(P_0, P_2);
			}
			if (elementType == XmlBaseConverter.UInt64Type)
			{
				return ToArray<ulong>(P_0, P_2);
			}
			if (elementType == XmlBaseConverter.UriType)
			{
				return ToArray<Uri>(P_0, P_2);
			}
			if (elementType == XmlBaseConverter.XmlAtomicValueType)
			{
				return ToArray<XmlAtomicValue>(P_0, P_2);
			}
			if (elementType == XmlBaseConverter.XmlQualifiedNameType)
			{
				return ToArray<XmlQualifiedName>(P_0, P_2);
			}
			if (elementType == XmlBaseConverter.XPathItemType)
			{
				return ToArray<XPathItem>(P_0, P_2);
			}
			if (elementType == XmlBaseConverter.XPathNavigatorType)
			{
				return ToArray<XPathNavigator>(P_0, P_2);
			}
			throw CreateInvalidClrMappingException(type, P_1);
		}
		if (type == base.DefaultClrType && type != XmlBaseConverter.ObjectArrayType)
		{
			return P_0;
		}
		return ToList(P_0, P_2);
	}

	private static bool IsListType(Type P_0)
	{
		if (P_0 == XmlBaseConverter.IListType || P_0 == XmlBaseConverter.ICollectionType || P_0 == XmlBaseConverter.IEnumerableType || P_0 == XmlBaseConverter.StringType)
		{
			return true;
		}
		return P_0.IsArray;
	}

	private T[] ToArray<T>(object P_0, IXmlNamespaceResolver P_1)
	{
		if (P_0 is IList list)
		{
			T[] array = new T[list.Count];
			for (int i = 0; i < list.Count; i++)
			{
				array[i] = (T)atomicConverter.ChangeType(list[i], typeof(T), P_1);
			}
			return array;
		}
		IEnumerable enumerable = P_0 as IEnumerable;
		List<T> list2 = new List<T>();
		foreach (object item in enumerable)
		{
			list2.Add((T)atomicConverter.ChangeType(item, typeof(T), P_1));
		}
		return list2.ToArray();
	}

	private IList ToList(object P_0, IXmlNamespaceResolver P_1)
	{
		if (P_0 is IList list)
		{
			object[] array = new object[list.Count];
			for (int i = 0; i < list.Count; i++)
			{
				array[i] = atomicConverter.ChangeType(list[i], XmlBaseConverter.ObjectType, P_1);
			}
			return array;
		}
		IEnumerable enumerable = P_0 as IEnumerable;
		List<object> list2 = new List<object>();
		foreach (object item in enumerable)
		{
			list2.Add(atomicConverter.ChangeType(item, XmlBaseConverter.ObjectType, P_1));
		}
		return list2;
	}

	private static List<string> StringAsList(string P_0)
	{
		return new List<string>(XmlConvert.SplitString(P_0));
	}

	private string ListAsString(IEnumerable P_0, IXmlNamespaceResolver P_1)
	{
		StringBuilder stringBuilder = new StringBuilder();
		foreach (object item in P_0)
		{
			if (item != null)
			{
				if (stringBuilder.Length != 0)
				{
					stringBuilder.Append(' ');
				}
				stringBuilder.Append(atomicConverter.ToString(item, P_1));
			}
		}
		return stringBuilder.ToString();
	}

	private new Exception CreateInvalidClrMappingException(Type P_0, Type P_1)
	{
		if (P_0 == P_1)
		{
			return new InvalidCastException(System.SR.Format("XmlConvert_TypeListBadMapping", base.XmlTypeName, P_0.Name));
		}
		return new InvalidCastException(System.SR.Format("XmlConvert_TypeListBadMapping2", base.XmlTypeName, P_0.Name, P_1.Name));
	}
}
