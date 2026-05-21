using System;

namespace Microsoft.JSInterop;

public class JSException : Exception
{
	public JSException(string P_0)
		: base(P_0)
	{
	}

	public JSException(string P_0, Exception P_1)
		: base(P_0, P_1)
	{
	}
}
