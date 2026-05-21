using System.Collections;
using System.Collections.Generic;

namespace System.Net.Http.Headers;

internal abstract class ObjectCollection<T> : ICollection<T>, IEnumerable<T>, IEnumerable where T : class
{
	public struct Enumerator : IEnumerator<T>, IEnumerator, IDisposable
	{
		private readonly ObjectCollection<T> _list;

		private int _index;

		private T _current;

		public T Current => _current;

		object IEnumerator.Current => _current;

		internal Enumerator(ObjectCollection<T> P_0)
		{
			_list = P_0;
			_index = 0;
			_current = null;
		}

		public void Dispose()
		{
		}

		public bool MoveNext()
		{
			ObjectCollection<T> list = _list;
			if ((uint)_index < (uint)list._size)
			{
				_current = ((list._items is T[] array) ? array[_index] : ((T)list._items));
				_index++;
				return true;
			}
			_index = _list._size + 1;
			_current = null;
			return false;
		}

		void IEnumerator.Reset()
		{
			_index = 0;
			_current = null;
		}
	}

	internal object _items;

	internal int _size;

	public int Count => _size;

	public bool IsReadOnly => false;

	public ObjectCollection()
	{
	}

	public abstract void Validate(T P_0);

	public void Add(T P_0)
	{
		Validate(P_0);
		if (_items == null)
		{
			_items = P_0;
			_size = 1;
			return;
		}
		if (_items is T val)
		{
			_items = new T[4] { val, P_0, null, null };
			_size = 2;
			return;
		}
		T[] array = (T[])_items;
		int size = _size;
		if ((uint)size < (uint)array.Length)
		{
			array[size] = P_0;
		}
		else
		{
			T[] array2 = new T[array.Length * 2];
			Array.Copy(array, array2, size);
			_items = array2;
			array2[size] = P_0;
		}
		_size = size + 1;
	}

	public void Clear()
	{
		_items = null;
		_size = 0;
	}

	public bool Contains(T P_0)
	{
		if (_size > 0)
		{
			if (!(_items is T val))
			{
				if (_items is T[] array)
				{
					return Array.IndexOf(array, P_0, 0, _size) != -1;
				}
				return false;
			}
			return val.Equals(P_0);
		}
		return false;
	}

	public void CopyTo(T[] P_0, int P_1)
	{
		if (_items is T[] array)
		{
			Array.Copy(array, 0, P_0, P_1, _size);
		}
		else if (P_0 == null || _size > P_0.Length - P_1)
		{
			new T[1] { (T)_items }.CopyTo(P_0, P_1);
		}
		else if (_size == 1)
		{
			P_0[P_1] = (T)_items;
		}
	}

	public bool Remove(T P_0)
	{
		if (_items is T val)
		{
			if (val.Equals(P_0))
			{
				_items = null;
				_size = 0;
				return true;
			}
		}
		else if (_items is T[] array)
		{
			int num = Array.IndexOf(array, P_0, 0, _size);
			if (num != -1)
			{
				_size--;
				if (num < _size)
				{
					Array.Copy(array, num + 1, array, num, _size - num);
				}
				array[_size] = null;
				return true;
			}
		}
		return false;
	}

	public Enumerator GetEnumerator()
	{
		return new Enumerator(this);
	}

	IEnumerator<T> IEnumerable<T>.GetEnumerator()
	{
		return GetEnumerator();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}
}
