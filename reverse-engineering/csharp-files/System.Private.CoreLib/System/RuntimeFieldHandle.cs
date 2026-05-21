using System.Runtime.Serialization;

namespace System;

[Serializable]
public struct RuntimeFieldHandle : IEquatable<RuntimeFieldHandle>, ISerializable
{
	private readonly nint value;

	public nint Value => value;

	internal RuntimeFieldHandle(nint P_0)
	{
		value = P_0;
	}

	public void GetObjectData(SerializationInfo P_0, StreamingContext P_1)
	{
		throw new PlatformNotSupportedException();
	}

	internal bool IsNullHandle()
	{
		return value == IntPtr.Zero;
	}

	public override bool Equals(object? P_0)
	{
		if (P_0 == null || GetType() != P_0.GetType())
		{
			return false;
		}
		return value == ((RuntimeFieldHandle)P_0).Value;
	}

	public bool Equals(RuntimeFieldHandle P_0)
	{
		return value == P_0.Value;
	}

	public override int GetHashCode()
	{
		return ((IntPtr)value).GetHashCode();
	}
}
