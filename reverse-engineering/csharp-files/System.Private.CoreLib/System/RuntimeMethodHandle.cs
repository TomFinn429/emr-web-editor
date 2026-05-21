using System.Reflection;
using System.Runtime.Serialization;
using System.Text;

namespace System;

[Serializable]
public struct RuntimeMethodHandle : IEquatable<RuntimeMethodHandle>, ISerializable
{
	private readonly nint value;

	public nint Value => value;

	internal RuntimeMethodHandle(nint P_0)
	{
		value = P_0;
	}

	public void GetObjectData(SerializationInfo P_0, StreamingContext P_1)
	{
		throw new PlatformNotSupportedException();
	}

	public override bool Equals(object? P_0)
	{
		if (P_0 == null || GetType() != P_0.GetType())
		{
			return false;
		}
		return value == ((RuntimeMethodHandle)P_0).Value;
	}

	public bool Equals(RuntimeMethodHandle P_0)
	{
		return value == P_0.Value;
	}

	public override int GetHashCode()
	{
		return ((IntPtr)value).GetHashCode();
	}

	internal static string ConstructInstantiation(RuntimeMethodInfo P_0)
	{
		StringBuilder stringBuilder = new StringBuilder();
		Type[] genericArguments = P_0.GetGenericArguments();
		stringBuilder.Append('[');
		for (int i = 0; i < genericArguments.Length; i++)
		{
			if (i > 0)
			{
				stringBuilder.Append(',');
			}
			stringBuilder.Append(genericArguments[i].Name);
		}
		stringBuilder.Append(']');
		return stringBuilder.ToString();
	}

	internal bool IsNullHandle()
	{
		return value == IntPtr.Zero;
	}

	internal static object ReboxFromNullable(object P_0)
	{
		return P_0;
	}
}
