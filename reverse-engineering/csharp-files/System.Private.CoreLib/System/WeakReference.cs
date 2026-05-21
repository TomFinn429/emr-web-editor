using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace System;

[Serializable]
[TypeForwardedFrom("mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")]
public class WeakReference : ISerializable
{
	private bool trackResurrection;

	private GCHandle handle;

	public virtual bool IsAlive => Target != null;

	public virtual object? Target
	{
		get
		{
			if (!handle.IsAllocated)
			{
				return null;
			}
			return handle.Target;
		}
	}

	~WeakReference()
	{
		handle.Free();
	}

	private void Create(object P_0, bool P_1)
	{
		if (P_1)
		{
			trackResurrection = true;
			handle = GCHandle.Alloc(P_0, GCHandleType.WeakTrackResurrection);
		}
		else
		{
			handle = GCHandle.Alloc(P_0, GCHandleType.Weak);
		}
	}

	private bool IsTrackResurrection()
	{
		return trackResurrection;
	}

	public WeakReference(object? P_0)
		: this(P_0, false)
	{
	}

	public WeakReference(object? P_0, bool P_1)
	{
		Create(P_0, P_1);
	}

	public virtual void GetObjectData(SerializationInfo P_0, StreamingContext P_1)
	{
		ArgumentNullException.ThrowIfNull(P_0, "info");
		P_0.AddValue("TrackedObject", Target, typeof(object));
		P_0.AddValue("TrackResurrection", IsTrackResurrection());
	}
}
[Serializable]
[TypeForwardedFrom("mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")]
public sealed class WeakReference<T> : ISerializable where T : class?
{
	private GCHandle handle;

	private bool trackResurrection;

	private T? Target
	{
		get
		{
			GCHandle gCHandle = handle;
			if (!gCHandle.IsAllocated)
			{
				return null;
			}
			return (T)gCHandle.Target;
		}
	}

	~WeakReference()
	{
		handle.Free();
	}

	private void Create(T P_0, bool P_1)
	{
		if (P_1)
		{
			trackResurrection = true;
			handle = GCHandle.Alloc(P_0, GCHandleType.WeakTrackResurrection);
		}
		else
		{
			handle = GCHandle.Alloc(P_0, GCHandleType.Weak);
		}
	}

	public void SetTarget(T P_0)
	{
		handle.Target = P_0;
	}

	private bool IsTrackResurrection()
	{
		return trackResurrection;
	}

	public WeakReference(T P_0)
		: this(P_0, false)
	{
	}

	public WeakReference(T P_0, bool P_1)
	{
		Create(P_0, P_1);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public bool TryGetTarget([MaybeNullWhen(false)][NotNullWhen(true)] out T P_0)
	{
		return (P_0 = Target) != null;
	}

	public void GetObjectData(SerializationInfo P_0, StreamingContext P_1)
	{
		ArgumentNullException.ThrowIfNull(P_0, "info");
		P_0.AddValue("TrackedObject", Target, typeof(T));
		P_0.AddValue("TrackResurrection", IsTrackResurrection());
	}
}
