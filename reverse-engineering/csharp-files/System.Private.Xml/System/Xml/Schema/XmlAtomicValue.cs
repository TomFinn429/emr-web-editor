using System.Runtime.InteropServices;
using System.Xml.XPath;

namespace System.Xml.Schema;

public sealed class XmlAtomicValue : XPathItem, ICloneable
{
	[StructLayout((LayoutKind)2, Size = 8)]
	private struct Union
	{
		[FieldOffset(0)]
		public bool boolVal;

		[FieldOffset(0)]
		public double dblVal;

		[FieldOffset(0)]
		public long i64Val;

		[FieldOffset(0)]
		public int i32Val;

		[FieldOffset(0)]
		public DateTime dtVal;
	}

	private sealed class NamespacePrefixForQName : IXmlNamespaceResolver
	{
		public string prefix;

		public string ns;

		public NamespacePrefixForQName(string P_0, string P_1)
		{
			ns = P_1;
			prefix = P_0;
		}

		public string LookupNamespace(string P_0)
		{
			if (P_0 == prefix)
			{
				return ns;
			}
			return null;
		}

		public string LookupPrefix(string P_0)
		{
			if (ns == P_0)
			{
				return prefix;
			}
			return null;
		}
	}

	private readonly XmlSchemaType _xmlType;

	private readonly object _objVal;

	private readonly TypeCode _clrType;

	private Union _unionVal;

	private readonly NamespacePrefixForQName _nsPrefix;

	public override XmlSchemaType XmlType => _xmlType;

	public override Type ValueType => _xmlType.Datatype.ValueType;

	public override object TypedValue
	{
		get
		{
			XmlValueConverter valueConverter = _xmlType.ValueConverter;
			if (_objVal == null)
			{
				switch (_clrType)
				{
				case TypeCode.Boolean:
					return valueConverter.ChangeType(_unionVal.boolVal, ValueType);
				case TypeCode.Int32:
					return valueConverter.ChangeType(_unionVal.i32Val, ValueType);
				case TypeCode.Int64:
					return valueConverter.ChangeType(_unionVal.i64Val, ValueType);
				case TypeCode.Double:
					return valueConverter.ChangeType(_unionVal.dblVal, ValueType);
				case TypeCode.DateTime:
					return valueConverter.ChangeType(_unionVal.dtVal, ValueType);
				}
			}
			return valueConverter.ChangeType(_objVal, ValueType, _nsPrefix);
		}
	}

	public override bool ValueAsBoolean
	{
		get
		{
			XmlValueConverter valueConverter = _xmlType.ValueConverter;
			if (_objVal == null)
			{
				switch (_clrType)
				{
				case TypeCode.Boolean:
					return _unionVal.boolVal;
				case TypeCode.Int32:
					return valueConverter.ToBoolean(_unionVal.i32Val);
				case TypeCode.Int64:
					return valueConverter.ToBoolean(_unionVal.i64Val);
				case TypeCode.Double:
					return valueConverter.ToBoolean(_unionVal.dblVal);
				case TypeCode.DateTime:
					return valueConverter.ToBoolean(_unionVal.dtVal);
				}
			}
			return valueConverter.ToBoolean(_objVal);
		}
	}

	public override DateTime ValueAsDateTime
	{
		get
		{
			XmlValueConverter valueConverter = _xmlType.ValueConverter;
			if (_objVal == null)
			{
				switch (_clrType)
				{
				case TypeCode.Boolean:
					return valueConverter.ToDateTime(_unionVal.boolVal);
				case TypeCode.Int32:
					return valueConverter.ToDateTime(_unionVal.i32Val);
				case TypeCode.Int64:
					return valueConverter.ToDateTime(_unionVal.i64Val);
				case TypeCode.Double:
					return valueConverter.ToDateTime(_unionVal.dblVal);
				case TypeCode.DateTime:
					return _unionVal.dtVal;
				}
			}
			return valueConverter.ToDateTime(_objVal);
		}
	}

	public override double ValueAsDouble
	{
		get
		{
			XmlValueConverter valueConverter = _xmlType.ValueConverter;
			if (_objVal == null)
			{
				switch (_clrType)
				{
				case TypeCode.Boolean:
					return valueConverter.ToDouble(_unionVal.boolVal);
				case TypeCode.Int32:
					return valueConverter.ToDouble(_unionVal.i32Val);
				case TypeCode.Int64:
					return valueConverter.ToDouble(_unionVal.i64Val);
				case TypeCode.Double:
					return _unionVal.dblVal;
				case TypeCode.DateTime:
					return valueConverter.ToDouble(_unionVal.dtVal);
				}
			}
			return valueConverter.ToDouble(_objVal);
		}
	}

	public override int ValueAsInt
	{
		get
		{
			XmlValueConverter valueConverter = _xmlType.ValueConverter;
			if (_objVal == null)
			{
				switch (_clrType)
				{
				case TypeCode.Boolean:
					return valueConverter.ToInt32(_unionVal.boolVal);
				case TypeCode.Int32:
					return _unionVal.i32Val;
				case TypeCode.Int64:
					return valueConverter.ToInt32(_unionVal.i64Val);
				case TypeCode.Double:
					return valueConverter.ToInt32(_unionVal.dblVal);
				case TypeCode.DateTime:
					return valueConverter.ToInt32(_unionVal.dtVal);
				}
			}
			return valueConverter.ToInt32(_objVal);
		}
	}

	public override long ValueAsLong
	{
		get
		{
			XmlValueConverter valueConverter = _xmlType.ValueConverter;
			if (_objVal == null)
			{
				switch (_clrType)
				{
				case TypeCode.Boolean:
					return valueConverter.ToInt64(_unionVal.boolVal);
				case TypeCode.Int32:
					return valueConverter.ToInt64(_unionVal.i32Val);
				case TypeCode.Int64:
					return _unionVal.i64Val;
				case TypeCode.Double:
					return valueConverter.ToInt64(_unionVal.dblVal);
				case TypeCode.DateTime:
					return valueConverter.ToInt64(_unionVal.dtVal);
				}
			}
			return valueConverter.ToInt64(_objVal);
		}
	}

	public override string Value
	{
		get
		{
			XmlValueConverter valueConverter = _xmlType.ValueConverter;
			if (_objVal == null)
			{
				switch (_clrType)
				{
				case TypeCode.Boolean:
					return valueConverter.ToString(_unionVal.boolVal);
				case TypeCode.Int32:
					return valueConverter.ToString(_unionVal.i32Val);
				case TypeCode.Int64:
					return valueConverter.ToString(_unionVal.i64Val);
				case TypeCode.Double:
					return valueConverter.ToString(_unionVal.dblVal);
				case TypeCode.DateTime:
					return valueConverter.ToString(_unionVal.dtVal);
				}
			}
			return valueConverter.ToString(_objVal, _nsPrefix);
		}
	}

	internal XmlAtomicValue(XmlSchemaType P_0, bool P_1)
	{
		ArgumentNullException.ThrowIfNull(P_0, "xmlType");
		_xmlType = P_0;
		_clrType = TypeCode.Boolean;
		_unionVal.boolVal = P_1;
	}

	internal XmlAtomicValue(XmlSchemaType P_0, DateTime P_1)
	{
		ArgumentNullException.ThrowIfNull(P_0, "xmlType");
		_xmlType = P_0;
		_clrType = TypeCode.DateTime;
		_unionVal.dtVal = P_1;
	}

	internal XmlAtomicValue(XmlSchemaType P_0, double P_1)
	{
		ArgumentNullException.ThrowIfNull(P_0, "xmlType");
		_xmlType = P_0;
		_clrType = TypeCode.Double;
		_unionVal.dblVal = P_1;
	}

	internal XmlAtomicValue(XmlSchemaType P_0, int P_1)
	{
		ArgumentNullException.ThrowIfNull(P_0, "xmlType");
		_xmlType = P_0;
		_clrType = TypeCode.Int32;
		_unionVal.i32Val = P_1;
	}

	internal XmlAtomicValue(XmlSchemaType P_0, long P_1)
	{
		ArgumentNullException.ThrowIfNull(P_0, "xmlType");
		_xmlType = P_0;
		_clrType = TypeCode.Int64;
		_unionVal.i64Val = P_1;
	}

	internal XmlAtomicValue(XmlSchemaType P_0, string P_1)
	{
		ArgumentNullException.ThrowIfNull(P_0, "xmlType");
		ArgumentNullException.ThrowIfNull(P_1, "value");
		_xmlType = P_0;
		_objVal = P_1;
	}

	internal XmlAtomicValue(XmlSchemaType P_0, string P_1, IXmlNamespaceResolver P_2)
	{
		ArgumentNullException.ThrowIfNull(P_0, "xmlType");
		ArgumentNullException.ThrowIfNull(P_1, "value");
		_xmlType = P_0;
		_objVal = P_1;
		if (P_2 != null && (_xmlType.TypeCode == XmlTypeCode.QName || _xmlType.TypeCode == XmlTypeCode.Notation))
		{
			string prefixFromQName = GetPrefixFromQName(P_1);
			_nsPrefix = new NamespacePrefixForQName(prefixFromQName, P_2.LookupNamespace(prefixFromQName));
		}
	}

	internal XmlAtomicValue(XmlSchemaType P_0, object P_1)
	{
		ArgumentNullException.ThrowIfNull(P_0, "xmlType");
		ArgumentNullException.ThrowIfNull(P_1, "value");
		_xmlType = P_0;
		_objVal = P_1;
	}

	internal XmlAtomicValue(XmlSchemaType P_0, object P_1, IXmlNamespaceResolver P_2)
	{
		ArgumentNullException.ThrowIfNull(P_0, "xmlType");
		ArgumentNullException.ThrowIfNull(P_1, "value");
		_xmlType = P_0;
		_objVal = P_1;
		if (P_2 != null && (_xmlType.TypeCode == XmlTypeCode.QName || _xmlType.TypeCode == XmlTypeCode.Notation))
		{
			XmlQualifiedName xmlQualifiedName = _objVal as XmlQualifiedName;
			string text = xmlQualifiedName.Namespace;
			_nsPrefix = new NamespacePrefixForQName(P_2.LookupPrefix(text), text);
		}
	}

	object ICloneable.Clone()
	{
		return this;
	}

	public override object ValueAs(Type P_0, IXmlNamespaceResolver? P_1)
	{
		XmlValueConverter valueConverter = _xmlType.ValueConverter;
		if (P_0 == typeof(XPathItem) || P_0 == typeof(XmlAtomicValue))
		{
			return this;
		}
		if (_objVal == null)
		{
			switch (_clrType)
			{
			case TypeCode.Boolean:
				return valueConverter.ChangeType(_unionVal.boolVal, P_0);
			case TypeCode.Int32:
				return valueConverter.ChangeType(_unionVal.i32Val, P_0);
			case TypeCode.Int64:
				return valueConverter.ChangeType(_unionVal.i64Val, P_0);
			case TypeCode.Double:
				return valueConverter.ChangeType(_unionVal.dblVal, P_0);
			case TypeCode.DateTime:
				return valueConverter.ChangeType(_unionVal.dtVal, P_0);
			}
		}
		return valueConverter.ChangeType(_objVal, P_0, P_1);
	}

	public override string ToString()
	{
		return Value;
	}

	private static string GetPrefixFromQName(string P_0)
	{
		int num2;
		int num = ValidateNames.ParseQName(P_0, 0, out num2);
		if (num == 0 || num != P_0.Length)
		{
			return null;
		}
		if (num2 != 0)
		{
			return P_0.Substring(0, num2);
		}
		return string.Empty;
	}
}
