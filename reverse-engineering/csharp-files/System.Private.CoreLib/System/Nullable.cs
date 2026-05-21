using System.Runtime.CompilerServices;
using System.Runtime.Versioning;

namespace System;

[Serializable]
[NonVersionable]
[TypeForwardedFrom("mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")]
public struct Nullable<T> where T : struct
{
	private readonly bool hasValue;

	internal T value;

	public readonly bool HasValue
	{
		[NonVersionable]
		get
		{
			return hasValue;
		}
	}

	public readonly T Value
	{
		get
		{
			if (!hasValue)
			{
				ThrowHelper.ThrowInvalidOperationException_InvalidOperation_NoValue();
			}
			return value;
		}
	}

	private static object Box(T? P_0)
	{
		if (!P_0.hasValue)
		{
			return null;
		}
		return P_0.value;
	}

	private static T? Unbox(object P_0)
	{
		if (P_0 == null)
		{
			return null;
		}
		return (T)P_0;
	}

	private static T? UnboxExact(object P_0)
	{
		if (P_0 == null)
		{
			return null;
		}
		if (P_0.GetType() != typeof(T))
		{
			throw new InvalidCastException();
		}
		return (T)P_0;
	}

	[NonVersionable]
	public Nullable(T value)
	{
		this.value = value;
		hasValue = true;
	}

	[NonVersionable]
	public readonly T GetValueOrDefault()
	{
		return value;
	}

	public override bool Equals(object? P_0)
	{
		if (!hasValue)
		{
			return P_0 == null;
		}
		if (P_0 == null)
		{
			return false;
		}
		return value.Equals(P_0);
	}

	public override int GetHashCode()
	{
		if (!hasValue)
		{
			return 0;
		}
		return value.GetHashCode();
	}

	public override string? ToString()
	{
		if (!hasValue)
		{
			return "";
		}
		return value.ToString();
	}
}
public static class Nullable
{
	public static Type? GetUnderlyingType(Type P_0)
	{
		ArgumentNullException.ThrowIfNull(P_0, "nullableType");
		if (P_0.IsGenericType && !P_0.IsGenericTypeDefinition)
		{
			Type genericTypeDefinition = P_0.GetGenericTypeDefinition();
			if ((object)genericTypeDefinition == typeof(Nullable<>))
			{
				return P_0.GetGenericArguments()[0];
			}
		}
		return null;
	}
}
