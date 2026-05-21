using System.Runtime.CompilerServices;

namespace System.Xml.Schema;

public class ValidationEventArgs : EventArgs
{
	public XmlSeverityType Severity
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw new NotSupportedException("Linked away");
		}
	}

	public XmlSchemaException Exception
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw new NotSupportedException("Linked away");
		}
	}
}
