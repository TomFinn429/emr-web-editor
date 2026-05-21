using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using Microsoft.JSInterop.Infrastructure;

namespace Microsoft.JSInterop;

public static class DotNetObjectReference
{
	public static DotNetObjectReference<TValue> Create<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicMethods)] TValue>(TValue value) where TValue : class
	{
		if (value == null)
		{
			throw new ArgumentNullException("value");
		}
		return new DotNetObjectReference<TValue>(value);
	}
}
public sealed class DotNetObjectReference<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicMethods)] TValue> : IDotNetObjectReference, IDisposable where TValue : class
{
	private readonly TValue _value;

	private long _objectId;

	private JSRuntime _jsRuntime;

	public TValue Value
	{
		get
		{
			ThrowIfDisposed();
			return _value;
		}
	}

	internal long ObjectId
	{
		get
		{
			ThrowIfDisposed();
			return _objectId;
		}
		set
		{
			ThrowIfDisposed();
			_objectId = objectId;
		}
	}

	internal JSRuntime? JSRuntime
	{
		get
		{
			ThrowIfDisposed();
			return _jsRuntime;
		}
		set
		{
			ThrowIfDisposed();
			_jsRuntime = jsRuntime;
		}
	}

	object IDotNetObjectReference.Value => Value;

	internal bool Disposed
	{
		[CompilerGenerated]
		get
		{
			return _003CDisposed_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			_003CDisposed_003Ek__BackingField = flag;
		}
	}

	internal DotNetObjectReference(TValue P_0)
	{
		_value = P_0;
	}

	public void Dispose()
	{
		if (!Disposed)
		{
			Disposed = true;
			if (_jsRuntime != null)
			{
				_jsRuntime.ReleaseObjectReference(_objectId);
			}
		}
	}

	internal void ThrowIfDisposed()
	{
		ObjectDisposedException.ThrowIf(Disposed, this);
	}
}
