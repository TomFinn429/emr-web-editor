using System;
using System.Buffers;
using System.Runtime.CompilerServices;

namespace Microsoft.JSInterop.Infrastructure;

internal class ArrayBuilder<T> : IDisposable
{
	protected T[] _items;

	protected int _itemsInUse;

	private static readonly T[] Empty = Array.Empty<T>();

	private readonly ArrayPool<T> _arrayPool;

	private readonly int _minCapacity;

	private bool _disposed;

	public int Count => _itemsInUse;

	public T[] Buffer => _items;

	public ArrayBuilder(int P_0 = 32, ArrayPool<T> P_1 = null)
	{
		_arrayPool = P_1 ?? ArrayPool<T>.Shared;
		_minCapacity = P_0;
		_items = Empty;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public int Append(in T P_0)
	{
		if (_itemsInUse == _items.Length)
		{
			GrowBuffer(_items.Length * 2);
		}
		int num = _itemsInUse++;
		_items[num] = P_0;
		return num;
	}

	public void Clear()
	{
		ReturnBuffer();
		_items = Empty;
		_itemsInUse = 0;
	}

	protected void GrowBuffer(int P_0)
	{
		ObjectDisposedException.ThrowIf(_disposed, null);
		int num = Math.Max(P_0, _minCapacity);
		T[] array = _arrayPool.Rent(num);
		Array.Copy(_items, array, _itemsInUse);
		ReturnBuffer();
		_items = array;
	}

	private void ReturnBuffer()
	{
		if (_items != Empty)
		{
			Array.Clear(_items, 0, _itemsInUse);
			_arrayPool.Return(_items);
		}
	}

	public void Dispose()
	{
		if (!_disposed)
		{
			_disposed = true;
			ReturnBuffer();
			_items = Empty;
			_itemsInUse = 0;
		}
	}
}
