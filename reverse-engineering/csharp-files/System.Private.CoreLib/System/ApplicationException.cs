using System.Runtime.CompilerServices;

namespace System;

[Serializable]
[TypeForwardedFrom("mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")]
public class ApplicationException : Exception
{
	public ApplicationException(string? P_0)
		: base(P_0)
	{
		base.HResult = -2146232832;
	}

	public ApplicationException(string? P_0, Exception? P_1)
		: base(P_0, P_1)
	{
		base.HResult = -2146232832;
	}
}
