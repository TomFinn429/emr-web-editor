using System.Xml.Schema;

namespace System.Xml.XPath;

public abstract class XPathItem
{
	public abstract XmlSchemaType? XmlType { get; }

	public abstract string Value { get; }

	public abstract object TypedValue { get; }

	public abstract Type ValueType { get; }

	public abstract bool ValueAsBoolean { get; }

	public abstract DateTime ValueAsDateTime { get; }

	public abstract double ValueAsDouble { get; }

	public abstract int ValueAsInt { get; }

	public abstract long ValueAsLong { get; }

	public virtual object ValueAs(Type P_0)
	{
		return ValueAs(P_0, null);
	}

	public abstract object ValueAs(Type P_0, IXmlNamespaceResolver? P_1);
}
