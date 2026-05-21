using System.Runtime.CompilerServices;
using System.Runtime.Versioning;

namespace System;

[Serializable]
[TypeForwardedFrom("mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")]
public class Object
{
	[Intrinsic]
	public Type GetType()
	{
		return GetType();
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	protected extern object MemberwiseClone();

	[NonVersionable]
	public Object()
	{
	}

	[NonVersionable]
	~Object()
	{
	}

	public virtual string? ToString()
	{
		return GetType().ToString();
	}

	public virtual bool Equals(object? obj)
	{
		return this == obj;
	}

	public static bool Equals(object? objA, object? objB)
	{
		if (objA == objB)
		{
			return true;
		}
		if (objA == null || objB == null)
		{
			return false;
		}
		return objA.Equals(objB);
	}

	[NonVersionable]
	public static bool ReferenceEquals(object? objA, object? objB)
	{
		return objA == objB;
	}

	public virtual int GetHashCode()
	{
		return RuntimeHelpers.GetHashCode(this);
	}
}
