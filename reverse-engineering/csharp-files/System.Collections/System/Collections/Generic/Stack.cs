using System.Runtime.CompilerServices;

namespace System.Collections.Generic;

[Serializable]
[TypeForwardedFrom("System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")]
public class Stack<T> : IEnumerable<T>, IEnumerable, ICollection, IReadOnlyCollection<T>
{
	public struct Enumerator : IEnumerator<T>, IEnumerator, IDisposable
	{
		private readonly Stack<T> _stack;

		private readonly int _version;

		private int _index;

		private T _currentElement;

		public T Current
		{
			get
			{
				if (_index < 0)
				{
					ThrowEnumerationNotStartedOrEnded();
				}
				return _currentElement;
			}
		}

		object? IEnumerator.Current => Current;

		internal Enumerator(Stack<T> P_0)
		{
			_stack = P_0;
			_version = P_0._version;
			_index = -2;
			_currentElement = default(T);
		}

		public void Dispose()
		{
			_index = -1;
		}

		public bool MoveNext()
		{
			if (_version != _stack._version)
			{
				throw new InvalidOperationException("InvalidOperation_EnumFailedVersion");
			}
			bool flag;
			if (_index == -2)
			{
				_index = _stack._size - 1;
				flag = _index >= 0;
				if (flag)
				{
					_currentElement = _stack._array[_index];
				}
				return flag;
			}
			if (_index == -1)
			{
				return false;
			}
			flag = --_index >= 0;
			if (flag)
			{
				_currentElement = _stack._array[_index];
			}
			else
			{
				_currentElement = default(T);
			}
			return flag;
		}

		private void ThrowEnumerationNotStartedOrEnded()
		{
			throw new InvalidOperationException((_index == -2) ? "InvalidOperation_EnumNotStarted" : "InvalidOperation_EnumEnded");
		}

		void IEnumerator.Reset()
		{
			if (_version != _stack._version)
			{
				throw new InvalidOperationException("InvalidOperation_EnumFailedVersion");
			}
			_index = -2;
			_currentElement = default(T);
		}
	}

	private T[] _array;

	private int _size;

	private int _version;

	public int Count => _size;

	bool ICollection.IsSynchronized => false;

	object ICollection.SyncRoot => this;

	public Stack()
	{
		_array = Array.Empty<T>();
	}

	public Stack(int P_0)
	{
		if (P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("capacity", P_0, "ArgumentOutOfRange_NeedNonNegNum");
		}
		_array = new T[P_0];
	}

	public void Clear()
	{
		if (RuntimeHelpers.IsReferenceOrContainsReferences<T>())
		{
			Array.Clear(_array, 0, _size);
		}
		_size = 0;
		_version++;
	}

	public bool Contains(T P_0)
	{
		if (_size != 0)
		{
			return Array.LastIndexOf(_array, P_0, _size - 1) != -1;
		}
		return false;
	}

	void ICollection.CopyTo(Array P_0, int P_1)
	{
		ArgumentNullException.ThrowIfNull(P_0, "array");
		if (P_0.Rank != 1)
		{
			throw new ArgumentException("Arg_RankMultiDimNotSupported", "array");
		}
		if (P_0.GetLowerBound(0) != 0)
		{
			throw new ArgumentException("Arg_NonZeroLowerBound", "array");
		}
		if (P_1 < 0 || P_1 > P_0.Length)
		{
			throw new ArgumentOutOfRangeException("arrayIndex", P_1, "ArgumentOutOfRange_IndexMustBeLessOrEqual");
		}
		if (P_0.Length - P_1 < _size)
		{
			throw new ArgumentException("Argument_InvalidOffLen");
		}
		try
		{
			Array.Copy(_array, 0, P_0, P_1, _size);
			Array.Reverse(P_0, P_1, _size);
		}
		catch (ArrayTypeMismatchException)
		{
			throw new ArgumentException("Argument_InvalidArrayType", "array");
		}
	}

	public Enumerator GetEnumerator()
	{
		return new Enumerator(this);
	}

	IEnumerator<T> IEnumerable<T>.GetEnumerator()
	{
		return new Enumerator(this);
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return new Enumerator(this);
	}

	public T Peek()
	{
		int num = _size - 1;
		T[] array = _array;
		if ((uint)num >= (uint)array.Length)
		{
			ThrowForEmptyStack();
		}
		return array[num];
	}

	public T Pop()
	{
		int num = _size - 1;
		T[] array = _array;
		if ((uint)num >= (uint)array.Length)
		{
			ThrowForEmptyStack();
		}
		_version++;
		_size = num;
		T result = array[num];
		if (RuntimeHelpers.IsReferenceOrContainsReferences<T>())
		{
			array[num] = default(T);
		}
		return result;
	}

	public void Push(T P_0)
	{
		int size = _size;
		T[] array = _array;
		if ((uint)size < (uint)array.Length)
		{
			array[size] = P_0;
			_version++;
			_size = size + 1;
		}
		else
		{
			PushWithResize(P_0);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void PushWithResize(T P_0)
	{
		Grow(_size + 1);
		_array[_size] = P_0;
		_version++;
		_size++;
	}

	private void Grow(int P_0)
	{
		int num = ((_array.Length == 0) ? 4 : (2 * _array.Length));
		if ((long)(uint)num > 2147483591L)
		{
			num = 2147483591;
		}
		if (num < P_0)
		{
			num = P_0;
		}
		Array.Resize(ref _array, num);
	}

	private void ThrowForEmptyStack()
	{
		throw new InvalidOperationException("InvalidOperation_EmptyStack");
	}
}
