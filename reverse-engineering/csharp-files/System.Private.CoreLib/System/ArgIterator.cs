using System.Runtime.InteropServices;

namespace System;

[StructLayout((LayoutKind)3)]
public ref struct ArgIterator
{
	private nint sig;

	public override bool Equals(object? P_0)
	{
		throw new NotSupportedException("ArgIterator does not support Equals.");
	}

	public override int GetHashCode()
	{
		return ((IntPtr)sig).GetHashCode();
	}
}
