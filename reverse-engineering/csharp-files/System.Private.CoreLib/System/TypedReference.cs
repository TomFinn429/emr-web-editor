namespace System;

[CLSCompliant(false)]
public ref struct TypedReference
{
	private readonly RuntimeTypeHandle type;

	private readonly ref byte _value;

	private readonly nint _type;

	public override int GetHashCode()
	{
		if (_type == IntPtr.Zero)
		{
			return 0;
		}
		return __reftype(this).GetHashCode();
	}

	public override bool Equals(object? P_0)
	{
		throw new NotSupportedException("NotSupported_NYI");
	}
}
