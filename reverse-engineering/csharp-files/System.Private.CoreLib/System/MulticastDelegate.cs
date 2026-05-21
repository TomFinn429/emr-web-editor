using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace System;

[StructLayout((LayoutKind)0)]
public abstract class MulticastDelegate : Delegate
{
	private Delegate[] delegates;

	public override void GetObjectData(SerializationInfo P_0, StreamingContext P_1)
	{
		throw new SerializationException("Serialization_DelegatesNotSupported");
	}

	public sealed override bool Equals([NotNullWhen(true)] object? P_0)
	{
		if (!base.Equals(P_0))
		{
			return false;
		}
		if (!(P_0 is MulticastDelegate multicastDelegate))
		{
			return false;
		}
		if (delegates == null && multicastDelegate.delegates == null)
		{
			return true;
		}
		if ((delegates == null) ^ (multicastDelegate.delegates == null))
		{
			return false;
		}
		if (delegates.Length != multicastDelegate.delegates.Length)
		{
			return false;
		}
		for (int i = 0; i < delegates.Length; i++)
		{
			if (!delegates[i].Equals(multicastDelegate.delegates[i]))
			{
				return false;
			}
		}
		return true;
	}

	public sealed override int GetHashCode()
	{
		return base.GetHashCode();
	}

	protected override MethodInfo GetMethodImpl()
	{
		if (delegates != null)
		{
			return delegates[delegates.Length - 1].Method;
		}
		return base.GetMethodImpl();
	}
}
