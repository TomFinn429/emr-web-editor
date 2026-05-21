using System.Globalization;
using System.Runtime.CompilerServices;

namespace System.Collections;

[Serializable]
[TypeForwardedFrom("mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")]
public class SortedList : IDictionary, ICollection, IEnumerable, ICloneable
{
	private sealed class SortedListEnumerator : IDictionaryEnumerator, IEnumerator, ICloneable
	{
		private readonly SortedList _sortedList;

		private object _key;

		private object _value;

		private int _index;

		private readonly int _startIndex;

		private readonly int _endIndex;

		private readonly int _version;

		private bool _current;

		private readonly int _getObjectRetType;

		public object Key
		{
			get
			{
				if (_version != _sortedList.version)
				{
					throw new InvalidOperationException("InvalidOperation_EnumFailedVersion");
				}
				if (!_current)
				{
					throw new InvalidOperationException("InvalidOperation_EnumOpCantHappen");
				}
				return _key;
			}
		}

		public DictionaryEntry Entry
		{
			get
			{
				if (_version != _sortedList.version)
				{
					throw new InvalidOperationException("InvalidOperation_EnumFailedVersion");
				}
				if (!_current)
				{
					throw new InvalidOperationException("InvalidOperation_EnumOpCantHappen");
				}
				return new DictionaryEntry(_key, _value);
			}
		}

		public object Current
		{
			get
			{
				if (!_current)
				{
					throw new InvalidOperationException("InvalidOperation_EnumOpCantHappen");
				}
				if (_getObjectRetType == 1)
				{
					return _key;
				}
				if (_getObjectRetType == 2)
				{
					return _value;
				}
				return new DictionaryEntry(_key, _value);
			}
		}

		public object Value
		{
			get
			{
				if (_version != _sortedList.version)
				{
					throw new InvalidOperationException("InvalidOperation_EnumFailedVersion");
				}
				if (!_current)
				{
					throw new InvalidOperationException("InvalidOperation_EnumOpCantHappen");
				}
				return _value;
			}
		}

		internal SortedListEnumerator(SortedList P_0, int P_1, int P_2, int P_3)
		{
			_sortedList = P_0;
			_index = P_1;
			_startIndex = P_1;
			_endIndex = P_1 + P_2;
			_version = P_0.version;
			_getObjectRetType = P_3;
			_current = false;
		}

		public object Clone()
		{
			return MemberwiseClone();
		}

		public bool MoveNext()
		{
			if (_version != _sortedList.version)
			{
				throw new InvalidOperationException("InvalidOperation_EnumFailedVersion");
			}
			if (_index < _endIndex)
			{
				_key = _sortedList.keys[_index];
				_value = _sortedList.values[_index];
				_index++;
				_current = true;
				return true;
			}
			_key = null;
			_value = null;
			_current = false;
			return false;
		}

		public void Reset()
		{
			if (_version != _sortedList.version)
			{
				throw new InvalidOperationException("InvalidOperation_EnumFailedVersion");
			}
			_index = _startIndex;
			_current = false;
			_key = null;
			_value = null;
		}
	}

	[Serializable]
	[TypeForwardedFrom("mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")]
	private sealed class KeyList : IList, ICollection, IEnumerable
	{
		private readonly SortedList sortedList;

		public int Count => sortedList._size;

		public bool IsReadOnly => true;

		public bool IsFixedSize => true;

		public bool IsSynchronized => sortedList.IsSynchronized;

		public object SyncRoot => sortedList.SyncRoot;

		public object this[int P_0]
		{
			get
			{
				return sortedList.GetKey(P_0);
			}
			set
			{
				throw new NotSupportedException("NotSupported_KeyCollectionSet");
			}
		}

		internal KeyList(SortedList P_0)
		{
			sortedList = P_0;
		}

		public int Add(object P_0)
		{
			throw new NotSupportedException("NotSupported_SortedListNestedWrite");
		}

		public void Clear()
		{
			throw new NotSupportedException("NotSupported_SortedListNestedWrite");
		}

		public bool Contains(object P_0)
		{
			return sortedList.Contains(P_0);
		}

		public void CopyTo(Array P_0, int P_1)
		{
			if (P_0 != null && P_0.Rank != 1)
			{
				throw new ArgumentException("Arg_RankMultiDimNotSupported", "array");
			}
			Array.Copy(sortedList.keys, 0, P_0, P_1, sortedList.Count);
		}

		public void Insert(int P_0, object P_1)
		{
			throw new NotSupportedException("NotSupported_SortedListNestedWrite");
		}

		public IEnumerator GetEnumerator()
		{
			return new SortedListEnumerator(sortedList, 0, sortedList.Count, 1);
		}

		public int IndexOf(object P_0)
		{
			ArgumentNullException.ThrowIfNull(P_0, "key");
			int num = Array.BinarySearch(sortedList.keys, 0, sortedList.Count, P_0, sortedList.comparer);
			if (num >= 0)
			{
				return num;
			}
			return -1;
		}

		public void Remove(object P_0)
		{
			throw new NotSupportedException("NotSupported_SortedListNestedWrite");
		}

		public void RemoveAt(int P_0)
		{
			throw new NotSupportedException("NotSupported_SortedListNestedWrite");
		}
	}

	private object[] keys;

	private object[] values;

	private int _size;

	private int version;

	private IComparer comparer;

	private KeyList keyList;

	public virtual int Capacity
	{
		set
		{
			if (num < Count)
			{
				throw new ArgumentOutOfRangeException("value", "ArgumentOutOfRange_SmallCapacity");
			}
			if (num == keys.Length)
			{
				return;
			}
			if (num > 0)
			{
				object[] array = new object[num];
				object[] array2 = new object[num];
				if (_size > 0)
				{
					Array.Copy(keys, array, _size);
					Array.Copy(values, array2, _size);
				}
				keys = array;
				values = array2;
			}
			else
			{
				keys = Array.Empty<object>();
				values = Array.Empty<object>();
			}
		}
	}

	public virtual int Count => _size;

	public virtual ICollection Keys => GetKeyList();

	public virtual bool IsReadOnly => false;

	public virtual bool IsSynchronized => false;

	public virtual object SyncRoot => this;

	public virtual object? this[object P_0]
	{
		get
		{
			int num = IndexOfKey(P_0);
			if (num >= 0)
			{
				return values[num];
			}
			return null;
		}
		set
		{
			ArgumentNullException.ThrowIfNull(obj, "key");
			int num = Array.BinarySearch(keys, 0, _size, obj, comparer);
			if (num >= 0)
			{
				values[num] = obj2;
				version++;
			}
			else
			{
				Insert(~num, obj, obj2);
			}
		}
	}

	public SortedList()
	{
		keys = Array.Empty<object>();
		values = Array.Empty<object>();
		_size = 0;
		comparer = new Comparer(CultureInfo.CurrentCulture);
	}

	public SortedList(int P_0)
	{
		if (P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("initialCapacity", "ArgumentOutOfRange_NeedNonNegNum");
		}
		keys = new object[P_0];
		values = new object[P_0];
		comparer = new Comparer(CultureInfo.CurrentCulture);
	}

	public virtual object Clone()
	{
		SortedList sortedList = new SortedList(_size);
		Array.Copy(keys, sortedList.keys, _size);
		Array.Copy(values, sortedList.values, _size);
		sortedList._size = _size;
		sortedList.version = version;
		sortedList.comparer = comparer;
		return sortedList;
	}

	public virtual bool Contains(object P_0)
	{
		return IndexOfKey(P_0) >= 0;
	}

	public virtual void CopyTo(Array P_0, int P_1)
	{
		ArgumentNullException.ThrowIfNull(P_0, "array");
		if (P_0.Rank != 1)
		{
			throw new ArgumentException("Arg_RankMultiDimNotSupported", "array");
		}
		if (P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("arrayIndex", "ArgumentOutOfRange_NeedNonNegNum");
		}
		if (P_0.Length - P_1 < Count)
		{
			throw new ArgumentException("Arg_ArrayPlusOffTooSmall");
		}
		for (int i = 0; i < Count; i++)
		{
			DictionaryEntry dictionaryEntry = new DictionaryEntry(keys[i], values[i]);
			P_0.SetValue(dictionaryEntry, i + P_1);
		}
	}

	private void EnsureCapacity(int P_0)
	{
		int num = ((keys.Length == 0) ? 16 : (keys.Length * 2));
		if ((long)(uint)num > 2147483591L)
		{
			num = 2147483591;
		}
		if (num < P_0)
		{
			num = P_0;
		}
		Capacity = num;
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return new SortedListEnumerator(this, 0, _size, 3);
	}

	public virtual IDictionaryEnumerator GetEnumerator()
	{
		return new SortedListEnumerator(this, 0, _size, 3);
	}

	public virtual object GetKey(int P_0)
	{
		if (P_0 < 0 || P_0 >= Count)
		{
			throw new ArgumentOutOfRangeException("index", "ArgumentOutOfRange_IndexMustBeLess");
		}
		return keys[P_0];
	}

	public virtual IList GetKeyList()
	{
		return keyList ?? (keyList = new KeyList(this));
	}

	public virtual int IndexOfKey(object P_0)
	{
		ArgumentNullException.ThrowIfNull(P_0, "key");
		int num = Array.BinarySearch(keys, 0, _size, P_0, comparer);
		if (num < 0)
		{
			return -1;
		}
		return num;
	}

	private void Insert(int P_0, object P_1, object P_2)
	{
		if (_size == keys.Length)
		{
			EnsureCapacity(_size + 1);
		}
		if (P_0 < _size)
		{
			Array.Copy(keys, P_0, keys, P_0 + 1, _size - P_0);
			Array.Copy(values, P_0, values, P_0 + 1, _size - P_0);
		}
		keys[P_0] = P_1;
		values[P_0] = P_2;
		_size++;
		version++;
	}

	public virtual void RemoveAt(int P_0)
	{
		if (P_0 < 0 || P_0 >= Count)
		{
			throw new ArgumentOutOfRangeException("index", "ArgumentOutOfRange_IndexMustBeLess");
		}
		_size--;
		if (P_0 < _size)
		{
			Array.Copy(keys, P_0 + 1, keys, P_0, _size - P_0);
			Array.Copy(values, P_0 + 1, values, P_0, _size - P_0);
		}
		keys[_size] = null;
		values[_size] = null;
		version++;
	}

	public virtual void Remove(object P_0)
	{
		int num = IndexOfKey(P_0);
		if (num >= 0)
		{
			RemoveAt(num);
		}
	}
}
