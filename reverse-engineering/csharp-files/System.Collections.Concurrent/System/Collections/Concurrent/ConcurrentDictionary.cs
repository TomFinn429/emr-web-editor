using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Threading;

namespace System.Collections.Concurrent;

public class ConcurrentDictionary<TKey, TValue> : IDictionary<TKey, TValue>, ICollection<KeyValuePair<TKey, TValue>>, IEnumerable<KeyValuePair<TKey, TValue>>, IEnumerable, IDictionary, ICollection, IReadOnlyDictionary<TKey, TValue>, IReadOnlyCollection<KeyValuePair<TKey, TValue>> where TKey : notnull
{
	private sealed class Enumerator : IEnumerator<KeyValuePair<TKey, TValue>>, IEnumerator, IDisposable
	{
		private readonly ConcurrentDictionary<TKey, TValue> _dictionary;

		private Node[] _buckets;

		private Node _node;

		private int _i;

		private int _state;

		public KeyValuePair<TKey, TValue> Current
		{
			[CompilerGenerated]
			get
			{
				return _003CCurrent_003Ek__BackingField;
			}
			[CompilerGenerated]
			private set
			{
				_003CCurrent_003Ek__BackingField = keyValuePair;
			}
		}

		object IEnumerator.Current => Current;

		public Enumerator(ConcurrentDictionary<TKey, TValue> P_0)
		{
			_dictionary = P_0;
			_i = -1;
		}

		public void Reset()
		{
			_buckets = null;
			_node = null;
			Current = default(KeyValuePair<TKey, TValue>);
			_i = -1;
			_state = 0;
		}

		public void Dispose()
		{
		}

		public bool MoveNext()
		{
			switch (_state)
			{
			case 0:
				_buckets = _dictionary._tables._buckets;
				_i = -1;
				goto case 1;
			case 1:
			{
				Node[] buckets = _buckets;
				int num = ++_i;
				if ((uint)num >= (uint)buckets.Length)
				{
					break;
				}
				_node = Volatile.Read(ref buckets[num]);
				_state = 2;
				goto case 2;
			}
			case 2:
			{
				Node node = _node;
				if (node != null)
				{
					Current = new KeyValuePair<TKey, TValue>(node._key, node._value);
					_node = node._next;
					return true;
				}
				goto case 1;
			}
			}
			_state = 3;
			return false;
		}
	}

	private sealed class Node
	{
		internal readonly TKey _key;

		internal TValue _value;

		internal volatile Node _next;

		internal readonly int _hashcode;

		internal Node(TKey P_0, TValue P_1, int P_2, Node P_3)
		{
			_key = P_0;
			_value = P_1;
			_next = P_3;
			_hashcode = P_2;
		}
	}

	private sealed class Tables
	{
		internal readonly Node[] _buckets;

		internal readonly object[] _locks;

		internal readonly int[] _countPerLock;

		internal readonly ulong _fastModBucketsMultiplier;

		internal Tables(Node[] P_0, object[] P_1, int[] P_2)
		{
			_buckets = P_0;
			_locks = P_1;
			_countPerLock = P_2;
			if (4 != 8)
			{
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal ref Node GetBucket(int P_0)
		{
			Node[] buckets = _buckets;
			if (IntPtr.Size == 8)
			{
				return ref buckets[System.Collections.HashHelpers.FastMod((uint)P_0, (uint)buckets.Length, _fastModBucketsMultiplier)];
			}
			return ref buckets[(uint)P_0 % (uint)buckets.Length];
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal ref Node GetBucketAndLock(int P_0, out uint P_1)
		{
			Node[] buckets = _buckets;
			uint num = ((IntPtr.Size != 8) ? ((uint)P_0 % (uint)buckets.Length) : System.Collections.HashHelpers.FastMod((uint)P_0, (uint)buckets.Length, _fastModBucketsMultiplier));
			P_1 = num % (uint)_locks.Length;
			return ref buckets[num];
		}
	}

	private sealed class DictionaryEnumerator : IDictionaryEnumerator, IEnumerator
	{
		private readonly IEnumerator<KeyValuePair<TKey, TValue>> _enumerator;

		public DictionaryEntry Entry => new DictionaryEntry(_enumerator.Current.Key, _enumerator.Current.Value);

		public object Key => _enumerator.Current.Key;

		public object Value => _enumerator.Current.Value;

		public object Current => Entry;

		internal DictionaryEnumerator(ConcurrentDictionary<TKey, TValue> P_0)
		{
			_enumerator = P_0.GetEnumerator();
		}

		public bool MoveNext()
		{
			return _enumerator.MoveNext();
		}

		public void Reset()
		{
			_enumerator.Reset();
		}
	}

	private volatile Tables _tables;

	private readonly IEqualityComparer<TKey> _comparer;

	private readonly EqualityComparer<TKey> _defaultComparer;

	private readonly bool _growLockArray;

	private int _budget;

	private static readonly bool s_isValueWriteAtomic = IsValueWriteAtomic();

	public TValue this[TKey P_0]
	{
		get
		{
			if (!TryGetValue(P_0, out var result))
			{
				ThrowKeyNotFoundException(P_0);
			}
			return result;
		}
		set
		{
			if (val == null)
			{
				System.ThrowHelper.ThrowKeyNullException();
			}
			TryAddInternal(val, null, val2, true, true, out var _);
		}
	}

	public int Count
	{
		get
		{
			int num = 0;
			try
			{
				AcquireAllLocks(ref num);
				return GetCountInternal();
			}
			finally
			{
				ReleaseLocks(0, num);
			}
		}
	}

	public ICollection<TKey> Keys => GetKeys();

	public ICollection<TValue> Values => GetValues();

	bool ICollection<KeyValuePair<TKey, TValue>>.IsReadOnly => false;

	bool IDictionary.IsReadOnly => false;

	ICollection IDictionary.Keys => GetKeys();

	object? IDictionary.this[object P_0]
	{
		get
		{
			if (P_0 == null)
			{
				System.ThrowHelper.ThrowKeyNullException();
			}
			if (P_0 is TKey val && TryGetValue(val, out var val2))
			{
				return val2;
			}
			return null;
		}
		set
		{
			if (obj == null)
			{
				System.ThrowHelper.ThrowKeyNullException();
			}
			if (!(obj is TKey))
			{
				throw new ArgumentException("ConcurrentDictionary_TypeOfKeyIncorrect");
			}
			ThrowIfInvalidObjectValue(obj2);
			this[(TKey)obj] = (TValue)obj2;
		}
	}

	bool ICollection.IsSynchronized => false;

	object ICollection.SyncRoot
	{
		get
		{
			throw new NotSupportedException("ConcurrentCollection_SyncRoot_NotSupported");
		}
	}

	private static bool IsValueWriteAtomic()
	{
		if (!typeof(TValue).IsValueType || typeof(TValue) == typeof(nint) || typeof(TValue) == typeof(nuint))
		{
			return true;
		}
		switch (Type.GetTypeCode(typeof(TValue)))
		{
		case TypeCode.Boolean:
		case TypeCode.Char:
		case TypeCode.SByte:
		case TypeCode.Byte:
		case TypeCode.Int16:
		case TypeCode.UInt16:
		case TypeCode.Int32:
		case TypeCode.UInt32:
		case TypeCode.Single:
			return true;
		case TypeCode.Int64:
		case TypeCode.UInt64:
		case TypeCode.Double:
			return 4 == 8;
		default:
			return false;
		}
	}

	public ConcurrentDictionary()
		: this(1, 31, true, (IEqualityComparer<TKey>)null)
	{
	}

	internal ConcurrentDictionary(int P_0, int P_1, bool P_2, IEqualityComparer<TKey> P_3)
	{
		if (P_0 < 1)
		{
			throw new ArgumentOutOfRangeException("concurrencyLevel", "ConcurrentDictionary_ConcurrencyLevelMustBePositive");
		}
		if (P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("capacity", "ConcurrentDictionary_CapacityMustNotBeNegative");
		}
		if (P_1 < P_0)
		{
			P_1 = P_0;
		}
		object[] array = new object[P_0];
		array[0] = array;
		for (int i = 1; i < array.Length; i++)
		{
			array[i] = new object();
		}
		int[] array2 = new int[array.Length];
		Node[] array3 = new Node[P_1];
		_tables = new Tables(array3, array, array2);
		_defaultComparer = EqualityComparer<TKey>.Default;
		if (P_3 != null && P_3 != _defaultComparer && P_3 != StringComparer.Ordinal)
		{
			_comparer = P_3;
		}
		_growLockArray = P_2;
		_budget = array3.Length / array.Length;
	}

	public bool TryAdd(TKey P_0, TValue P_1)
	{
		if (P_0 == null)
		{
			System.ThrowHelper.ThrowKeyNullException();
		}
		TValue val;
		return TryAddInternal(P_0, null, P_1, false, true, out val);
	}

	public bool ContainsKey(TKey P_0)
	{
		if (P_0 == null)
		{
			System.ThrowHelper.ThrowKeyNullException();
		}
		TValue val;
		return TryGetValue(P_0, out val);
	}

	public bool TryRemove(TKey P_0, [MaybeNullWhen(false)] out TValue P_1)
	{
		if (P_0 == null)
		{
			System.ThrowHelper.ThrowKeyNullException();
		}
		return TryRemoveInternal(P_0, out P_1, false, default(TValue));
	}

	public bool TryRemove(KeyValuePair<TKey, TValue> P_0)
	{
		if (P_0.Key == null)
		{
			System.ThrowHelper.ThrowArgumentNullException("item", "ConcurrentDictionary_ItemKeyIsNull");
		}
		TValue val;
		return TryRemoveInternal(P_0.Key, out val, true, P_0.Value);
	}

	private bool TryRemoveInternal(TKey P_0, [MaybeNullWhen(false)] out TValue P_1, bool P_2, TValue P_3)
	{
		IEqualityComparer<TKey> comparer = _comparer;
		int num = comparer?.GetHashCode(P_0) ?? P_0.GetHashCode();
		while (true)
		{
			Tables tables = _tables;
			object[] locks = tables._locks;
			uint num2;
			ref Node bucketAndLock = ref tables.GetBucketAndLock(num, out num2);
			lock (locks[num2])
			{
				if (tables != _tables)
				{
					continue;
				}
				Node node = null;
				for (Node node2 = bucketAndLock; node2 != null; node2 = node2._next)
				{
					if (num == node2._hashcode && (comparer?.Equals(node2._key, P_0) ?? _defaultComparer.Equals(node2._key, P_0)))
					{
						if (P_2 && !EqualityComparer<TValue>.Default.Equals(P_3, node2._value))
						{
							P_1 = default(TValue);
							return false;
						}
						if (node == null)
						{
							Volatile.Write(ref bucketAndLock, node2._next);
						}
						else
						{
							node._next = node2._next;
						}
						P_1 = node2._value;
						tables._countPerLock[num2]--;
						return true;
					}
					node = node2;
				}
				break;
			}
		}
		P_1 = default(TValue);
		return false;
	}

	public bool TryGetValue(TKey P_0, [MaybeNullWhen(false)] out TValue P_1)
	{
		if (P_0 == null)
		{
			System.ThrowHelper.ThrowKeyNullException();
		}
		Tables tables = _tables;
		IEqualityComparer<TKey> comparer = _comparer;
		if (comparer == null)
		{
			int hashCode = P_0.GetHashCode();
			if (typeof(TKey).IsValueType)
			{
				for (Node node = Volatile.Read(ref tables.GetBucket(hashCode)); node != null; node = node._next)
				{
					if (hashCode == node._hashcode && EqualityComparer<TKey>.Default.Equals(node._key, P_0))
					{
						P_1 = node._value;
						return true;
					}
				}
			}
			else
			{
				for (Node node2 = Volatile.Read(ref tables.GetBucket(hashCode)); node2 != null; node2 = node2._next)
				{
					if (hashCode == node2._hashcode && _defaultComparer.Equals(node2._key, P_0))
					{
						P_1 = node2._value;
						return true;
					}
				}
			}
		}
		else
		{
			int hashCode2 = comparer.GetHashCode(P_0);
			for (Node node3 = Volatile.Read(ref tables.GetBucket(hashCode2)); node3 != null; node3 = node3._next)
			{
				if (hashCode2 == node3._hashcode && comparer.Equals(node3._key, P_0))
				{
					P_1 = node3._value;
					return true;
				}
			}
		}
		P_1 = default(TValue);
		return false;
	}

	private bool TryGetValueInternal(TKey P_0, int P_1, [MaybeNullWhen(false)] out TValue P_2)
	{
		Tables tables = _tables;
		IEqualityComparer<TKey> comparer = _comparer;
		if (comparer == null)
		{
			if (typeof(TKey).IsValueType)
			{
				for (Node node = Volatile.Read(ref tables.GetBucket(P_1)); node != null; node = node._next)
				{
					if (P_1 == node._hashcode && EqualityComparer<TKey>.Default.Equals(node._key, P_0))
					{
						P_2 = node._value;
						return true;
					}
				}
			}
			else
			{
				for (Node node2 = Volatile.Read(ref tables.GetBucket(P_1)); node2 != null; node2 = node2._next)
				{
					if (P_1 == node2._hashcode && _defaultComparer.Equals(node2._key, P_0))
					{
						P_2 = node2._value;
						return true;
					}
				}
			}
		}
		else
		{
			for (Node node3 = Volatile.Read(ref tables.GetBucket(P_1)); node3 != null; node3 = node3._next)
			{
				if (P_1 == node3._hashcode && comparer.Equals(node3._key, P_0))
				{
					P_2 = node3._value;
					return true;
				}
			}
		}
		P_2 = default(TValue);
		return false;
	}

	public void Clear()
	{
		int num = 0;
		try
		{
			AcquireAllLocks(ref num);
			if (!AreAllBucketsEmpty())
			{
				Tables tables = _tables;
				Tables tables2 = (_tables = new Tables(new Node[31], tables._locks, new int[tables._countPerLock.Length]));
				_budget = Math.Max(1, tables2._buckets.Length / tables2._locks.Length);
			}
		}
		finally
		{
			ReleaseLocks(0, num);
		}
	}

	void ICollection<KeyValuePair<TKey, TValue>>.CopyTo(KeyValuePair<TKey, TValue>[] P_0, int P_1)
	{
		ArgumentNullException.ThrowIfNull(P_0, "array");
		if (P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("index", "ConcurrentDictionary_IndexIsNegative");
		}
		int num = 0;
		try
		{
			AcquireAllLocks(ref num);
			int num2 = 0;
			int[] countPerLock = _tables._countPerLock;
			for (int i = 0; i < countPerLock.Length; i++)
			{
				if (num2 < 0)
				{
					break;
				}
				num2 += countPerLock[i];
			}
			if (P_0.Length - num2 < P_1 || num2 < 0)
			{
				throw new ArgumentException("ConcurrentDictionary_ArrayNotLargeEnough");
			}
			CopyToPairs(P_0, P_1);
		}
		finally
		{
			ReleaseLocks(0, num);
		}
	}

	private void CopyToPairs(KeyValuePair<TKey, TValue>[] P_0, int P_1)
	{
		Node[] buckets = _tables._buckets;
		for (int i = 0; i < buckets.Length; i++)
		{
			for (Node node = buckets[i]; node != null; node = node._next)
			{
				P_0[P_1] = new KeyValuePair<TKey, TValue>(node._key, node._value);
				P_1++;
			}
		}
	}

	private void CopyToEntries(DictionaryEntry[] P_0, int P_1)
	{
		Node[] buckets = _tables._buckets;
		for (int i = 0; i < buckets.Length; i++)
		{
			for (Node node = buckets[i]; node != null; node = node._next)
			{
				P_0[P_1] = new DictionaryEntry(node._key, node._value);
				P_1++;
			}
		}
	}

	private void CopyToObjects(object[] P_0, int P_1)
	{
		Node[] buckets = _tables._buckets;
		for (int i = 0; i < buckets.Length; i++)
		{
			for (Node node = buckets[i]; node != null; node = node._next)
			{
				P_0[P_1] = new KeyValuePair<TKey, TValue>(node._key, node._value);
				P_1++;
			}
		}
	}

	public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
	{
		return new Enumerator(this);
	}

	private bool TryAddInternal(TKey P_0, int? P_1, TValue P_2, bool P_3, bool P_4, out TValue P_5)
	{
		IEqualityComparer<TKey> comparer = _comparer;
		int num = P_1 ?? comparer?.GetHashCode(P_0) ?? P_0.GetHashCode();
		checked
		{
			Tables tables;
			bool flag;
			while (true)
			{
				tables = _tables;
				object[] locks = tables._locks;
				uint num2;
				ref Node bucketAndLock = ref tables.GetBucketAndLock(num, out num2);
				flag = false;
				bool flag2 = false;
				try
				{
					if (P_4)
					{
						Monitor.Enter(locks[num2], ref flag2);
					}
					if (tables != _tables)
					{
						continue;
					}
					Node node = null;
					for (Node node2 = bucketAndLock; node2 != null; node2 = node2._next)
					{
						if (num == node2._hashcode && (comparer?.Equals(node2._key, P_0) ?? _defaultComparer.Equals(node2._key, P_0)))
						{
							if (P_3)
							{
								if (s_isValueWriteAtomic)
								{
									node2._value = P_2;
								}
								else
								{
									Node node3 = new Node(node2._key, P_2, num, node2._next);
									if (node == null)
									{
										Volatile.Write(ref bucketAndLock, node3);
									}
									else
									{
										node._next = node3;
									}
								}
								P_5 = P_2;
							}
							else
							{
								P_5 = node2._value;
							}
							return false;
						}
						node = node2;
					}
					Node node4 = new Node(P_0, P_2, num, bucketAndLock);
					Volatile.Write(ref bucketAndLock, node4);
					tables._countPerLock[num2]++;
					if (tables._countPerLock[num2] > _budget)
					{
						flag = true;
					}
					break;
				}
				finally
				{
					if (flag2)
					{
						Monitor.Exit(locks[num2]);
					}
				}
			}
			if (flag)
			{
				GrowTable(tables);
			}
			P_5 = P_2;
			return true;
		}
	}

	[DoesNotReturn]
	private static void ThrowKeyNotFoundException(TKey P_0)
	{
		throw new KeyNotFoundException(System.SR.Format("Arg_KeyNotFoundWithKey", P_0.ToString()));
	}

	private int GetCountInternal()
	{
		int num = 0;
		int[] countPerLock = _tables._countPerLock;
		for (int i = 0; i < countPerLock.Length; i++)
		{
			num += countPerLock[i];
		}
		return num;
	}

	public TValue GetOrAdd(TKey P_0, Func<TKey, TValue> P_1)
	{
		if (P_0 == null)
		{
			System.ThrowHelper.ThrowKeyNullException();
		}
		if (P_1 == null)
		{
			System.ThrowHelper.ThrowArgumentNullException("valueFactory");
		}
		int num = _comparer?.GetHashCode(P_0) ?? P_0.GetHashCode();
		if (!TryGetValueInternal(P_0, num, out var result))
		{
			TryAddInternal(P_0, num, P_1(P_0), false, true, out result);
		}
		return result;
	}

	public TValue GetOrAdd<TArg>(TKey P_0, Func<TKey, TArg, TValue> P_1, TArg P_2)
	{
		if (P_0 == null)
		{
			System.ThrowHelper.ThrowKeyNullException();
		}
		if (P_1 == null)
		{
			System.ThrowHelper.ThrowArgumentNullException("valueFactory");
		}
		int num = _comparer?.GetHashCode(P_0) ?? P_0.GetHashCode();
		if (!TryGetValueInternal(P_0, num, out var result))
		{
			TryAddInternal(P_0, num, P_1(P_0, P_2), false, true, out result);
		}
		return result;
	}

	void IDictionary<TKey, TValue>.Add(TKey P_0, TValue P_1)
	{
		if (!TryAdd(P_0, P_1))
		{
			throw new ArgumentException("ConcurrentDictionary_KeyAlreadyExisted");
		}
	}

	bool IDictionary<TKey, TValue>.Remove(TKey P_0)
	{
		TValue val;
		return TryRemove(P_0, out val);
	}

	void ICollection<KeyValuePair<TKey, TValue>>.Add(KeyValuePair<TKey, TValue> P_0)
	{
		((IDictionary<TKey, TValue>)this).Add(P_0.Key, P_0.Value);
	}

	bool ICollection<KeyValuePair<TKey, TValue>>.Contains(KeyValuePair<TKey, TValue> P_0)
	{
		if (!TryGetValue(P_0.Key, out var val))
		{
			return false;
		}
		return EqualityComparer<TValue>.Default.Equals(val, P_0.Value);
	}

	bool ICollection<KeyValuePair<TKey, TValue>>.Remove(KeyValuePair<TKey, TValue> P_0)
	{
		return TryRemove(P_0);
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}

	bool IDictionary.Contains(object P_0)
	{
		if (P_0 == null)
		{
			System.ThrowHelper.ThrowKeyNullException();
		}
		if (P_0 is TKey val)
		{
			return ContainsKey(val);
		}
		return false;
	}

	IDictionaryEnumerator IDictionary.GetEnumerator()
	{
		return new DictionaryEnumerator(this);
	}

	void IDictionary.Remove(object P_0)
	{
		if (P_0 == null)
		{
			System.ThrowHelper.ThrowKeyNullException();
		}
		if (P_0 is TKey val)
		{
			TryRemove(val, out var _);
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static void ThrowIfInvalidObjectValue(object P_0)
	{
		if (P_0 != null)
		{
			if (!(P_0 is TValue))
			{
				System.ThrowHelper.ThrowValueNullException();
			}
		}
		else if (default(TValue) != null)
		{
			System.ThrowHelper.ThrowValueNullException();
		}
	}

	void ICollection.CopyTo(Array P_0, int P_1)
	{
		ArgumentNullException.ThrowIfNull(P_0, "array");
		if (P_1 < 0)
		{
			throw new ArgumentOutOfRangeException("index", "ConcurrentDictionary_IndexIsNegative");
		}
		int num = 0;
		try
		{
			AcquireAllLocks(ref num);
			Tables tables = _tables;
			int num2 = 0;
			int[] countPerLock = tables._countPerLock;
			for (int i = 0; i < countPerLock.Length; i++)
			{
				if (num2 < 0)
				{
					break;
				}
				num2 += countPerLock[i];
			}
			if (P_0.Length - num2 < P_1 || num2 < 0)
			{
				throw new ArgumentException("ConcurrentDictionary_ArrayNotLargeEnough");
			}
			if (P_0 is KeyValuePair<TKey, TValue>[] array)
			{
				CopyToPairs(array, P_1);
				return;
			}
			if (P_0 is DictionaryEntry[] array2)
			{
				CopyToEntries(array2, P_1);
				return;
			}
			if (P_0 is object[] array3)
			{
				CopyToObjects(array3, P_1);
				return;
			}
			throw new ArgumentException("ConcurrentDictionary_ArrayIncorrectType", "array");
		}
		finally
		{
			ReleaseLocks(0, num);
		}
	}

	private bool AreAllBucketsEmpty()
	{
		return _tables._countPerLock.AsSpan().IndexOfAnyExcept(0) < 0;
	}

	private void GrowTable(Tables P_0)
	{
		int num = 0;
		try
		{
			AcquireLocks(0, 1, ref num);
			if (P_0 != _tables)
			{
				return;
			}
			long num2 = 0L;
			for (int i = 0; i < P_0._countPerLock.Length; i++)
			{
				num2 += P_0._countPerLock[i];
			}
			if (num2 < P_0._buckets.Length / 4)
			{
				_budget = 2 * _budget;
				if (_budget < 0)
				{
					_budget = 2147483647;
				}
				return;
			}
			int j = 0;
			bool flag = false;
			try
			{
				for (j = checked(P_0._buckets.Length * 2 + 1); j % 3 == 0 || j % 5 == 0 || j % 7 == 0; j = checked(j + 2))
				{
				}
				if (j > 2147483591)
				{
					flag = true;
				}
			}
			catch (OverflowException)
			{
				flag = true;
			}
			if (flag)
			{
				j = 2147483591;
				_budget = 2147483647;
			}
			object[] array = P_0._locks;
			if (_growLockArray && P_0._locks.Length < 1024)
			{
				array = new object[P_0._locks.Length * 2];
				Array.Copy(P_0._locks, array, P_0._locks.Length);
				for (int k = P_0._locks.Length; k < array.Length; k++)
				{
					array[k] = new object();
				}
			}
			Node[] array2 = new Node[j];
			int[] array3 = new int[array.Length];
			Tables tables = new Tables(array2, array, array3);
			AcquireLocks(1, P_0._locks.Length, ref num);
			Node[] buckets = P_0._buckets;
			checked
			{
				foreach (Node node in buckets)
				{
					Node node2 = node;
					while (node2 != null)
					{
						Node next = node2._next;
						uint num3;
						ref Node bucketAndLock = ref tables.GetBucketAndLock(node2._hashcode, out num3);
						bucketAndLock = new Node(node2._key, node2._value, node2._hashcode, bucketAndLock);
						array3[num3]++;
						node2 = next;
					}
				}
			}
			_budget = Math.Max(1, array2.Length / array.Length);
			_tables = tables;
		}
		finally
		{
			ReleaseLocks(0, num);
		}
	}

	private void AcquireAllLocks(ref int P_0)
	{
		if (CDSCollectionETWBCLProvider.Log.IsEnabled())
		{
		}
		AcquireLocks(0, 1, ref P_0);
		AcquireLocks(1, _tables._locks.Length, ref P_0);
	}

	private void AcquireLocks(int P_0, int P_1, ref int P_2)
	{
		object[] locks = _tables._locks;
		for (int i = P_0; i < P_1; i++)
		{
			bool flag = false;
			try
			{
				Monitor.Enter(locks[i], ref flag);
			}
			finally
			{
				if (flag)
				{
					P_2++;
				}
			}
		}
	}

	private void ReleaseLocks(int P_0, int P_1)
	{
		Tables tables = _tables;
		for (int i = P_0; i < P_1; i++)
		{
			Monitor.Exit(tables._locks[i]);
		}
	}

	private ReadOnlyCollection<TKey> GetKeys()
	{
		int num = 0;
		try
		{
			AcquireAllLocks(ref num);
			int countInternal = GetCountInternal();
			if (countInternal < 0)
			{
				System.ThrowHelper.ThrowOutOfMemoryException();
			}
			List<TKey> list = new List<TKey>(countInternal);
			Node[] buckets = _tables._buckets;
			for (int i = 0; i < buckets.Length; i++)
			{
				for (Node node = buckets[i]; node != null; node = node._next)
				{
					list.Add(node._key);
				}
			}
			return new ReadOnlyCollection<TKey>(list);
		}
		finally
		{
			ReleaseLocks(0, num);
		}
	}

	private ReadOnlyCollection<TValue> GetValues()
	{
		int num = 0;
		try
		{
			AcquireAllLocks(ref num);
			int countInternal = GetCountInternal();
			if (countInternal < 0)
			{
				System.ThrowHelper.ThrowOutOfMemoryException();
			}
			List<TValue> list = new List<TValue>(countInternal);
			Node[] buckets = _tables._buckets;
			for (int i = 0; i < buckets.Length; i++)
			{
				for (Node node = buckets[i]; node != null; node = node._next)
				{
					list.Add(node._value);
				}
			}
			return new ReadOnlyCollection<TValue>(list);
		}
		finally
		{
			ReleaseLocks(0, num);
		}
	}
}
