using System.Runtime.CompilerServices;

namespace System.Xml.Schema;

internal sealed class XsdSimpleValue
{
	public XmlSchemaSimpleType XmlType
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw new NotSupportedException("Linked away");
		}
	}

	public object TypedValue
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw new NotSupportedException("Linked away");
		}
	}
}
