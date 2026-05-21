using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace System.Collections.Generic;

[Serializable]
[TypeForwardedFrom("System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")]
public class SortedDictionary<TKey, TValue> : IDictionary<TKey, TValue>, ICollection<KeyValuePair<TKey, TValue>>, IEnumerable<KeyValuePair<TKey, TValue>>, IEnumerable, IDictionary, ICollection, IReadOnlyDictionary<TKey, TValue>, IReadOnlyCollection<KeyValuePair<TKey, TValue>> where TKey : notnull
{
	public struct Enumerator : IEnumerator<KeyValuePair<TKey, TValue>>, IEnumerator, IDisposable, IDictionaryEnumerator
	{
		private SortedSet<KeyValuePair<TKey, TValue>>.Enumerator _treeEnum;

		private readonly int _getEnumeratorRetType;

		public KeyValuePair<TKey, TValue> Current => _treeEnum.Current;

		internal bool NotStartedOrEnded => _treeEnum.NotStartedOrEnded;

		object? IEnumerator.Current
		{
			get
			{
				if (NotStartedOrEnded)
				{
					throw new InvalidOperationException("InvalidOperation_EnumOpCantHappen");
				}
				if (_getEnumeratorRetType == 2)
				{
					return new DictionaryEntry(Current.Key, Current.Value);
				}
				return new KeyValuePair<TKey, TValue>(Current.Key, Current.Value);
			}
		}

		object IDictionaryEnumerator.Key
		{
			get
			{
				if (NotStartedOrEnded)
				{
					throw new InvalidOperationException("InvalidOperation_EnumOpCantHappen");
				}
				return Current.Key;
			}
		}

		object? IDictionaryEnumerator.Value
		{
			get
			{
				if (NotStartedOrEnded)
				{
					throw new InvalidOperationException("InvalidOperation_EnumOpCantHappen");
				}
				return Current.Value;
			}
		}

		DictionaryEntry IDictionaryEnumerator.Entry
		{
			get
			{
				if (NotStartedOrEnded)
				{
					throw new InvalidOperationException("InvalidOperation_EnumOpCantHappen");
				}
				return new DictionaryEntry(Current.Key, Current.Value);
			}
		}

		internal Enumerator(SortedDictionary<TKey, TValue> P_0, int P_1)
		{
			_treeEnum = P_0._set.GetEnumerator();
			_getEnumeratorRetType = P_1;
		}

		public bool MoveNext()
		{
			return _treeEnum.MoveNext();
		}

		public void Dispose()
		{
			_treeEnum.Dispose();
		}

		internal void Reset()
		{
			_treeEnum.Reset();
		}

		void IEnumerator.Reset()
		{
			_treeEnum.Reset();
		}
	}

	public sealed class KeyCollection : ICollection<TKey>, IEnumerable<TKey>, IEnumerable, ICollection, IReadOnlyCollection<TKey>
	{
		public struct Enumerator : IEnumerator<TKey>, IEnumerator, IDisposable
		{
			private SortedDictionary<TKey, TValue>.Enumerator _dictEnum;

			public TKey Current => _dictEnum.Current.Key;

			object? IEnumerator.Current
			{
				get
				{
					if (_dictEnum.NotStartedOrEnded)
					{
						throw new InvalidOperationException("InvalidOperation_EnumOpCantHappen");
					}
					return Current;
				}
			}

			internal Enumerator(SortedDictionary<TKey, TValue> P_0)
			{
				_dictEnum = P_0.GetEnumerator();
			}

			public void Dispose()
			{
				_dictEnum.Dispose();
			}

			public bool MoveNext()
			{
				return _dictEnum.MoveNext();
			}

			void IEnumerator.Reset()
			{
				_dictEnum.Reset();
			}
		}

		private readonly SortedDictionary<TKey, TValue> _dictionary;

		public int Count => _dictionary.Count;

		bool ICollection<TKey>.IsReadOnly => true;

		bool ICollection.IsSynchronized => false;

		object ICollection.SyncRoot => ((ICollection)_dictionary).SyncRoot;

		public KeyCollection(SortedDictionary<TKey, TValue> P_0)
		{
			ArgumentNullException.ThrowIfNull(P_0, "dictionary");
			_dictionary = P_0;
		}

		IEnumerator<TKey> IEnumerable<TKey>.GetEnumerator()
		{
			return new Enumerator(_dictionary);
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return new Enumerator(_dictionary);
		}

		public void CopyTo(TKey[] P_0, int P_1)
		{
			ArgumentNullException.ThrowIfNull(P_0, "array");
			if (P_1 < 0)
			{
				throw new ArgumentOutOfRangeException("index", P_1, "ArgumentOutOfRange_NeedNonNegNum");
			}
			if (P_0.Length - P_1 < Count)
			{
				throw new ArgumentException("Arg_ArrayPlusOffTooSmall");
			}
			_dictionary._set.InOrderTreeWalk(delegate(SortedSet<KeyValuePair<TKey, TValue>>.Node node)
			{
				P_0[P_1++] = node.Item.Key;
				return true;
			});
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
			if (P_1 < 0)
			{
				throw new ArgumentOutOfRangeException("index", P_1, "ArgumentOutOfRange_NeedNonNegNum");
			}
			if (P_0.Length - P_1 < _dictionary.Count)
			{
				throw new ArgumentException("Arg_ArrayPlusOffTooSmall");
			}
			if (P_0 is TKey[] array)
			{
				CopyTo(array, P_1);
				return;
			}
			try
			{
				object[] objects = (object[])P_0;
				_dictionary._set.InOrderTreeWalk(delegate(SortedSet<KeyValuePair<TKey, TValue>>.Node node)
				{
					objects[P_1++] = node.Item.Key;
					return true;
				});
			}
			catch (ArrayTypeMismatchException)
			{
				throw new ArgumentException("Argument_InvalidArrayType", "array");
			}
		}

		void ICollection<TKey>.Add(TKey P_0)
		{
			throw new NotSupportedException("NotSupported_KeyCollectionSet");
		}

		void ICollection<TKey>.Clear()
		{
			throw new NotSupportedException("NotSupported_KeyCollectionSet");
		}

		bool ICollection<TKey>.Contains(TKey P_0)
		{
			return _dictionary.ContainsKey(P_0);
		}

		bool ICollection<TKey>.Remove(TKey P_0)
		{
			throw new NotSupportedException("NotSupported_KeyCollectionSet");
		}
	}

	public sealed class ValueCollection : ICollection<TValue>, IEnumerable<TValue>, IEnumerable, ICollection, IReadOnlyCollection<TValue>
	{
		public struct Enumerator : IEnumerator<TValue>, IEnumerator, IDisposable
		{
			private SortedDictionary<TKey, TValue>.Enumerator _dictEnum;

			public TValue Current => _dictEnum.Current.Value;

			object? IEnumerator.Current
			{
				get
				{
					if (_dictEnum.NotStartedOrEnded)
					{
						throw new InvalidOperationException("InvalidOperation_EnumOpCantHappen");
					}
					return Current;
				}
			}

			internal Enumerator(SortedDictionary<TKey, TValue> P_0)
			{
				_dictEnum = P_0.GetEnumerator();
			}

			public void Dispose()
			{
				_dictEnum.Dispose();
			}

			public bool MoveNext()
			{
				return _dictEnum.MoveNext();
			}

			void IEnumerator.Reset()
			{
				_dictEnum.Reset();
			}
		}

		private readonly SortedDictionary<TKey, TValue> _dictionary;

		public int Count => _dictionary.Count;

		bool ICollection<TValue>.IsReadOnly => true;

		bool ICollection.IsSynchronized => false;

		object ICollection.SyncRoot => ((ICollection)_dictionary).SyncRoot;

		public ValueCollection(SortedDictionary<TKey, TValue> P_0)
		{
			ArgumentNullException.ThrowIfNull(P_0, "dictionary");
			_dictionary = P_0;
		}

		IEnumerator<TValue> IEnumerable<TValue>.GetEnumerator()
		{
			return new Enumerator(_dictionary);
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return new Enumerator(_dictionary);
		}

		public void CopyTo(TValue[] P_0, int P_1)
		{
			ArgumentNullException.ThrowIfNull(P_0, "array");
			if (P_1 < 0)
			{
				throw new ArgumentOutOfRangeException("index", P_1, "ArgumentOutOfRange_NeedNonNegNum");
			}
			if (P_0.Length - P_1 < Count)
			{
				throw new ArgumentException("Arg_ArrayPlusOffTooSmall");
			}
			_dictionary._set.InOrderTreeWalk(delegate(SortedSet<KeyValuePair<TKey, TValue>>.Node node)
			{
				P_0[P_1++] = node.Item.Value;
				return true;
			});
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
			if (P_1 < 0)
			{
				throw new ArgumentOutOfRangeException("index", P_1, "ArgumentOutOfRange_NeedNonNegNum");
			}
			if (P_0.Length - P_1 < _dictionary.Count)
			{
				throw new ArgumentException("Arg_ArrayPlusOffTooSmall");
			}
			if (P_0 is TValue[] array)
			{
				CopyTo(array, P_1);
				return;
			}
			try
			{
				object[] objects = (object[])P_0;
				_dictionary._set.InOrderTreeWalk(delegate(SortedSet<KeyValuePair<TKey, TValue>>.Node node)
				{
					objects[P_1++] = node.Item.Value;
					return true;
				});
			}
			catch (ArrayTypeMismatchException)
			{
				throw new ArgumentException("Argument_InvalidArrayType", "array");
			}
		}

		void ICollection<TValue>.Add(TValue P_0)
		{
			throw new NotSupportedException("NotSupported_ValueCollectionSet");
		}

		void ICollection<TValue>.Clear()
		{
			throw new NotSupportedException("NotSupported_ValueCollectionSet");
		}

		bool ICollection<TValue>.Contains(TValue P_0)
		{
			return _dictionary.ContainsValue(P_0);
		}

		bool ICollection<TValue>.Remove(TValue P_0)
		{
			throw new NotSupportedException("NotSupported_ValueCollectionSet");
		}
	}

	[Serializable]
	public sealed class KeyValuePairComparer : Comparer<KeyValuePair<TKey, TValue>>
	{
		internal IComparer<TKey> keyComparer;

		public KeyValuePairComparer(IComparer<TKey>? P_0)
		{
			keyComparer = P_0 ?? Comparer<TKey>.Default;
		}

		public override int Compare(KeyValuePair<TKey, TValue> P_0, KeyValuePair<TKey, TValue> P_1)
		{
			return keyComparer.Compare(P_0.Key, P_1.Key);
		}

		public override bool Equals(object? P_0)
		{
			if (P_0 is KeyValuePairComparer keyValuePairComparer)
			{
				if (keyComparer != keyValuePairComparer.keyComparer)
				{
					return keyComparer.Equals(keyValuePairComparer.keyComparer);
				}
				return true;
			}
			return false;
		}

		public override int GetHashCode()
		{
			return keyComparer.GetHashCode();
		}
	}

	[NonSerialized]
	private KeyCollection _keys;

	[NonSerialized]
	private ValueCollection _values;

	private readonly TreeSet<KeyValuePair<TKey, TValue>> _set;

	bool ICollection<KeyValuePair<TKey, TValue>>.IsReadOnly => false;

	public TValue this[TKey P_0]
	{
		get
		{
			if (P_0 == null)
			{
				throw new ArgumentNullException("key");
			}
			SortedSet<KeyValuePair<TKey, TValue>>.Node node = _set.FindNode(new KeyValuePair<TKey, TValue>(P_0, default(TValue)));
			if (node == null)
			{
				throw new KeyNotFoundException(System.SR.Format("Arg_KeyNotFoundWithKey", P_0.ToString()));
			}
			return node.Item.Value;
		}
		set
		{
			if (val == null)
			{
				throw new ArgumentNullException("key");
			}
			SortedSet<KeyValuePair<TKey, TValue>>.Node node = _set.FindNode(new KeyValuePair<TKey, TValue>(val, default(TValue)));
			if (node == null)
			{
				_set.Add(new KeyValuePair<TKey, TValue>(val, value2));
				return;
			}
			node.Item = new KeyValuePair<TKey, TValue>(node.Item.Key, value2);
			_set.UpdateVersion();
		}
	}

	public int Count => _set.Count;

	public KeyCollection Keys => _keys ?? (_keys = new KeyCollection(this));

	ICollection<TKey> IDictionary<TKey, TValue>.Keys => Keys;

	public ValueCollection Values => _values ?? (_values = new ValueCollection(this));

	ICollection<TValue> IDictionary<TKey, TValue>.Values => Values;

	bool IDictionary.IsReadOnly => false;

	ICollection IDictionary.Keys => Keys;

	object? IDictionary.this[object P_0]
	{
		get
		{
			if (IsCompatibleKey(P_0) && TryGetValue((TKey)P_0, out var val))
			{
				return val;
			}
			return null;
		}
		set
		{
			if (obj == null)
			{
				throw new ArgumentNullException("key");
			}
			if (obj2 == null && default(TValue) != null)
			{
				throw new ArgumentNullException("value");
			}
			try
			{
				TKey val = (TKey)obj;
				try
				{
					this[val] = (TValue)obj2;
				}
				catch (InvalidCastException)
				{
					throw new ArgumentException(System.SR.Format("Arg_WrongType", obj2, typeof(TValue)), "value");
				}
			}
			catch (InvalidCastException)
			{
				throw new ArgumentException(System.SR.Format("Arg_WrongType", obj, typeof(TKey)), "key");
			}
		}
	}

	bool ICollection.IsSynchronized => false;

	object ICollection.SyncRoot => ((ICollection)_set).SyncRoot;

	public SortedDictionary()
		: this((IComparer<TKey>?)null)
	{
	}

	public SortedDictionary(IComparer<TKey>? P_0)
	{
		_set = new TreeSet<KeyValuePair<TKey, TValue>>(new KeyValuePairComparer(P_0));
	}

	void ICollection<KeyValuePair<TKey, TValue>>.Add(KeyValuePair<TKey, TValue> P_0)
	{
		_set.Add(P_0);
	}

	bool ICollection<KeyValuePair<TKey, TValue>>.Contains(KeyValuePair<TKey, TValue> P_0)
	{
		SortedSet<KeyValuePair<TKey, TValue>>.Node node = _set.FindNode(P_0);
		if (node == null)
		{
			return false;
		}
		if (P_0.Value == null)
		{
			return node.Item.Value == null;
		}
		return EqualityComparer<TValue>.Default.Equals(node.Item.Value, P_0.Value);
	}

	bool ICollection<KeyValuePair<TKey, TValue>>.Remove(KeyValuePair<TKey, TValue> P_0)
	{
		SortedSet<KeyValuePair<TKey, TValue>>.Node node = _set.FindNode(P_0);
		if (node == null)
		{
			return false;
		}
		if (EqualityComparer<TValue>.Default.Equals(node.Item.Value, P_0.Value))
		{
			_set.Remove(P_0);
			return true;
		}
		return false;
	}

	public void Add(TKey P_0, TValue P_1)
	{
		ArgumentNullException.ThrowIfNull(P_0, "key");
		_set.Add(new KeyValuePair<TKey, TValue>(P_0, P_1));
	}

	public void Clear()
	{
		_set.Clear();
	}

	public bool ContainsKey(TKey P_0)
	{
		ArgumentNullException.ThrowIfNull(P_0, "key");
		return _set.Contains(new KeyValuePair<TKey, TValue>(P_0, default(TValue)));
	}

	public bool ContainsValue(TValue P_0)
	{
		bool found = false;
		if (P_0 == null)
		{
			_set.InOrderTreeWalk(delegate(SortedSet<KeyValuePair<TKey, TValue>>.Node node)
			{
				if (node.Item.Value == null)
				{
					found = true;
					return false;
				}
				return true;
			});
		}
		else
		{
			EqualityComparer<TValue> valueComparer = EqualityComparer<TValue>.Default;
			_set.InOrderTreeWalk(delegate(SortedSet<KeyValuePair<TKey, TValue>>.Node node)
			{
				if (valueComparer.Equals(node.Item.Value, P_0))
				{
					found = true;
					return false;
				}
				return true;
			});
		}
		return found;
	}

	public void CopyTo(KeyValuePair<TKey, TValue>[] P_0, int P_1)
	{
		_set.CopyTo(P_0, P_1);
	}

	public Enumerator GetEnumerator()
	{
		return new Enumerator(this, 1);
	}

	IEnumerator<KeyValuePair<TKey, TValue>> IEnumerable<KeyValuePair<TKey, TValue>>.GetEnumerator()
	{
		return new Enumerator(this, 1);
	}

	public bool Remove(TKey P_0)
	{
		ArgumentNullException.ThrowIfNull(P_0, "key");
		return _set.Remove(new KeyValuePair<TKey, TValue>(P_0, default(TValue)));
	}

	public bool TryGetValue(TKey P_0, [MaybeNullWhen(false)] out TValue P_1)
	{
		ArgumentNullException.ThrowIfNull(P_0, "key");
		SortedSet<KeyValuePair<TKey, TValue>>.Node node = _set.FindNode(new KeyValuePair<TKey, TValue>(P_0, default(TValue)));
		if (node == null)
		{
			P_1 = default(TValue);
			return false;
		}
		P_1 = node.Item.Value;
		return true;
	}

	void ICollection.CopyTo(Array P_0, int P_1)
	{
		((ICollection)_set).CopyTo(P_0, P_1);
	}

	bool IDictionary.Contains(object P_0)
	{
		if (IsCompatibleKey(P_0))
		{
			return ContainsKey((TKey)P_0);
		}
		return false;
	}

	private static bool IsCompatibleKey(object P_0)
	{
		ArgumentNullException.ThrowIfNull(P_0, "key");
		return P_0 is TKey;
	}

	IDictionaryEnumerator IDictionary.GetEnumerator()
	{
		return new Enumerator(this, 2);
	}

	void IDictionary.Remove(object P_0)
	{
		if (IsCompatibleKey(P_0))
		{
			Remove((TKey)P_0);
		}
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return new Enumerator(this, 1);
	}
}
