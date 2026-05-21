using System.Runtime.CompilerServices;
using System.Runtime.Serialization;

namespace System.Collections.Specialized;

[Serializable]
[TypeForwardedFrom("System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")]
public class OrderedDictionary : IDictionary, ICollection, IEnumerable, ISerializable
{
	private sealed class OrderedDictionaryEnumerator : IDictionaryEnumerator, IEnumerator
	{
		private readonly int _objectReturnType;

		private readonly IEnumerator _arrayEnumerator;

		public object Current
		{
			get
			{
				if (_objectReturnType == 1)
				{
					return ((DictionaryEntry)_arrayEnumerator.Current).Key;
				}
				if (_objectReturnType == 2)
				{
					return ((DictionaryEntry)_arrayEnumerator.Current).Value;
				}
				return Entry;
			}
		}

		public DictionaryEntry Entry => new DictionaryEntry(((DictionaryEntry)_arrayEnumerator.Current).Key, ((DictionaryEntry)_arrayEnumerator.Current).Value);

		public object Key => ((DictionaryEntry)_arrayEnumerator.Current).Key;

		public object Value => ((DictionaryEntry)_arrayEnumerator.Current).Value;

		internal OrderedDictionaryEnumerator(ArrayList P_0, int P_1)
		{
			_arrayEnumerator = P_0.GetEnumerator();
			_objectReturnType = P_1;
		}

		public bool MoveNext()
		{
			return _arrayEnumerator.MoveNext();
		}

		public void Reset()
		{
			_arrayEnumerator.Reset();
		}
	}

	private sealed class OrderedDictionaryKeyValueCollection : IList, ICollection, IEnumerable
	{
		private readonly ArrayList _objects;

		private readonly Hashtable _objectsTable;

		private readonly IEqualityComparer _comparer;

		private bool IsKeys => _objectsTable != null;

		int ICollection.Count => _objects.Count;

		bool ICollection.IsSynchronized => false;

		object ICollection.SyncRoot => _objects.SyncRoot;

		bool IList.IsFixedSize => true;

		bool IList.IsReadOnly => true;

		object IList.this[int P_0]
		{
			get
			{
				DictionaryEntry dictionaryEntry = (DictionaryEntry)_objects[P_0];
				if (!IsKeys)
				{
					return dictionaryEntry.Value;
				}
				return dictionaryEntry.Key;
			}
			set
			{
				throw new NotSupportedException(GetNotSupportedErrorMessage());
			}
		}

		public OrderedDictionaryKeyValueCollection(ArrayList P_0, Hashtable P_1, IEqualityComparer P_2)
		{
			_objects = P_0;
			_objectsTable = P_1;
			_comparer = P_2;
		}

		public OrderedDictionaryKeyValueCollection(ArrayList P_0)
		{
			_objects = P_0;
		}

		void ICollection.CopyTo(Array P_0, int P_1)
		{
			ArgumentNullException.ThrowIfNull(P_0, "array");
			if (P_1 < 0)
			{
				throw new ArgumentOutOfRangeException("index", P_1, "ArgumentOutOfRange_NeedNonNegNum_Index");
			}
			foreach (object @object in _objects)
			{
				P_0.SetValue(IsKeys ? ((DictionaryEntry)@object).Key : ((DictionaryEntry)@object).Value, P_1);
				P_1++;
			}
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return new OrderedDictionaryEnumerator(_objects, IsKeys ? 1 : 2);
		}

		bool IList.Contains(object P_0)
		{
			if (IsKeys)
			{
				if (P_0 != null)
				{
					return _objectsTable.ContainsKey(P_0);
				}
				return false;
			}
			foreach (object @object in _objects)
			{
				if (object.Equals(((DictionaryEntry)@object).Value, P_0))
				{
					return true;
				}
			}
			return false;
		}

		int IList.IndexOf(object P_0)
		{
			for (int i = 0; i < _objects.Count; i++)
			{
				if (IsKeys)
				{
					object key = ((DictionaryEntry)_objects[i]).Key;
					if (_comparer != null)
					{
						if (_comparer.Equals(key, P_0))
						{
							return i;
						}
					}
					else if (key.Equals(P_0))
					{
						return i;
					}
				}
				else if (object.Equals(((DictionaryEntry)_objects[i]).Value, P_0))
				{
					return i;
				}
			}
			return -1;
		}

		void IList.Insert(int P_0, object P_1)
		{
			throw new NotSupportedException(GetNotSupportedErrorMessage());
		}

		void IList.Remove(object P_0)
		{
			throw new NotSupportedException(GetNotSupportedErrorMessage());
		}

		void IList.RemoveAt(int P_0)
		{
			throw new NotSupportedException(GetNotSupportedErrorMessage());
		}

		int IList.Add(object P_0)
		{
			throw new NotSupportedException(GetNotSupportedErrorMessage());
		}

		void IList.Clear()
		{
			throw new NotSupportedException(GetNotSupportedErrorMessage());
		}

		private string GetNotSupportedErrorMessage()
		{
			if (!IsKeys)
			{
				return "NotSupported_ValueCollectionSet";
			}
			return "NotSupported_KeyCollectionSet";
		}
	}

	private ArrayList _objectsArray;

	private Hashtable _objectsTable;

	private int _initialCapacity;

	private IEqualityComparer _comparer;

	private bool _readOnly;

	public int Count
	{
		get
		{
			if (_objectsArray == null)
			{
				return 0;
			}
			return _objectsArray.Count;
		}
	}

	public bool IsReadOnly => _readOnly;

	bool ICollection.IsSynchronized => false;

	public ICollection Keys
	{
		get
		{
			ArrayList arrayList = EnsureObjectsArray();
			Hashtable hashtable = EnsureObjectsTable();
			return new OrderedDictionaryKeyValueCollection(arrayList, hashtable, _comparer);
		}
	}

	object ICollection.SyncRoot => this;

	public object? this[object P_0]
	{
		get
		{
			if (_objectsTable == null)
			{
				return null;
			}
			return _objectsTable[P_0];
		}
		set
		{
			if (_readOnly)
			{
				throw new NotSupportedException("OrderedDictionary_ReadOnly");
			}
			Hashtable hashtable = EnsureObjectsTable();
			if (hashtable.Contains(obj))
			{
				hashtable[obj] = obj2;
				ArrayList arrayList = EnsureObjectsArray();
				arrayList[IndexOfKey(obj)] = new DictionaryEntry(obj, obj2);
			}
			else
			{
				Add(obj, obj2);
			}
		}
	}

	public ICollection Values
	{
		get
		{
			ArrayList arrayList = EnsureObjectsArray();
			return new OrderedDictionaryKeyValueCollection(arrayList);
		}
	}

	public OrderedDictionary(int P_0)
		: this(P_0, null)
	{
	}

	public OrderedDictionary(int P_0, IEqualityComparer? P_1)
	{
		_initialCapacity = P_0;
		_comparer = P_1;
	}

	private ArrayList EnsureObjectsArray()
	{
		return _objectsArray ?? (_objectsArray = new ArrayList(_initialCapacity));
	}

	private Hashtable EnsureObjectsTable()
	{
		return _objectsTable ?? (_objectsTable = new Hashtable(_initialCapacity, _comparer));
	}

	public void Add(object P_0, object? P_1)
	{
		if (_readOnly)
		{
			throw new NotSupportedException("OrderedDictionary_ReadOnly");
		}
		Hashtable hashtable = EnsureObjectsTable();
		ArrayList arrayList = EnsureObjectsArray();
		hashtable.Add(P_0, P_1);
		arrayList.Add(new DictionaryEntry(P_0, P_1));
	}

	public bool Contains(object P_0)
	{
		ArgumentNullException.ThrowIfNull(P_0, "key");
		if (_objectsTable == null)
		{
			return false;
		}
		return _objectsTable.Contains(P_0);
	}

	public void CopyTo(Array P_0, int P_1)
	{
		Hashtable hashtable = EnsureObjectsTable();
		hashtable.CopyTo(P_0, P_1);
	}

	private int IndexOfKey(object P_0)
	{
		if (_objectsArray == null)
		{
			return -1;
		}
		for (int i = 0; i < _objectsArray.Count; i++)
		{
			object key = ((DictionaryEntry)_objectsArray[i]).Key;
			if (_comparer != null)
			{
				if (_comparer.Equals(key, P_0))
				{
					return i;
				}
			}
			else if (key.Equals(P_0))
			{
				return i;
			}
		}
		return -1;
	}

	public void Remove(object P_0)
	{
		if (_readOnly)
		{
			throw new NotSupportedException("OrderedDictionary_ReadOnly");
		}
		ArgumentNullException.ThrowIfNull(P_0, "key");
		int num = IndexOfKey(P_0);
		if (num >= 0)
		{
			Hashtable hashtable = EnsureObjectsTable();
			ArrayList arrayList = EnsureObjectsArray();
			hashtable.Remove(P_0);
			arrayList.RemoveAt(num);
		}
	}

	public virtual IDictionaryEnumerator GetEnumerator()
	{
		ArrayList arrayList = EnsureObjectsArray();
		return new OrderedDictionaryEnumerator(arrayList, 3);
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		ArrayList arrayList = EnsureObjectsArray();
		return new OrderedDictionaryEnumerator(arrayList, 3);
	}

	public virtual void GetObjectData(SerializationInfo P_0, StreamingContext P_1)
	{
		ArgumentNullException.ThrowIfNull(P_0, "info");
		P_0.AddValue("KeyComparer", _comparer, typeof(IEqualityComparer));
		P_0.AddValue("ReadOnly", _readOnly);
		P_0.AddValue("InitialCapacity", _initialCapacity);
		object[] array = new object[Count];
		ArrayList arrayList = EnsureObjectsArray();
		arrayList.CopyTo(array);
		P_0.AddValue("ArrayList", array);
	}
}
