using System.Runtime.Versioning;

namespace System.Runtime.InteropServices.JavaScript;

[SupportedOSPlatform("browser")]
public abstract class JSType
{
	public sealed class Date : JSType
	{
	}

	public sealed class MemoryView : JSType
	{
	}

	public sealed class Array<T> : JSType where T : JSType
	{
	}

	public sealed class Any : JSType
	{
	}
}
