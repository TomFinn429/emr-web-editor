using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace System.Text.Json;

internal sealed class JsonPropertyDictionary<T> where T : class
{
	private sealed class KeyCollection : IList<string>, ICollection<string>, IEnumerable<string>, IEnumerable
	{
		private readonly JsonPropertyDictionary<T> _parent;

		public int Count => _parent.Count;

		public bool IsReadOnly => true;

		public string this[int P_0]
		{
			get
			{
				return _parent.List[P_0].Key;
			}
			set
			{
				throw ThrowHelper.GetNotSupportedException_CollectionIsReadOnly();
			}
		}

		public KeyCollection(JsonPropertyDictionary<T> P_0)
		{
			_parent = P_0;
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			foreach (KeyValuePair<string, T> item in _parent)
			{
				yield return item.Key;
			}
		}

		public void Add(string P_0)
		{
			ThrowHelper.ThrowNotSupportedException_CollectionIsReadOnly();
		}

		public void Clear()
		{
			ThrowHelper.ThrowNotSupportedException_CollectionIsReadOnly();
		}

		public bool Contains(string P_0)
		{
			return _parent.ContainsProperty(P_0);
		}

		public void CopyTo(string[] P_0, int P_1)
		{
			if (P_1 < 0)
			{
				ThrowHelper.ThrowArgumentOutOfRangeException_ArrayIndexNegative("index");
			}
			foreach (KeyValuePair<string, T> item in _parent)
			{
				if (P_1 >= P_0.Length)
				{
					ThrowHelper.ThrowArgumentException_ArrayTooSmall("propertyNameArray");
				}
				P_0[P_1++] = item.Key;
			}
		}

		public IEnumerator<string> GetEnumerator()
		{
			foreach (KeyValuePair<string, T> item in _parent)
			{
				yield return item.Key;
			}
		}

		bool ICollection<string>.Remove(string P_0)
		{
			throw ThrowHelper.GetNotSupportedException_CollectionIsReadOnly();
		}

		public int IndexOf(string P_0)
		{
			throw ThrowHelper.GetNotSupportedException_CollectionIsReadOnly();
		}

		public void Insert(int P_0, string P_1)
		{
			throw ThrowHelper.GetNotSupportedException_CollectionIsReadOnly();
		}

		public void RemoveAt(int P_0)
		{
			throw ThrowHelper.GetNotSupportedException_CollectionIsReadOnly();
		}
	}

	private sealed class ValueCollection : IList<T>, ICollection<T>, IEnumerable<T>, IEnumerable
	{
		private readonly JsonPropertyDictionary<T> _parent;

		public int Count => _parent.Count;

		public bool IsReadOnly => true;

		public T this[int P_0]
		{
			get
			{
				return _parent.List[P_0].Value;
			}
			set
			{
				throw ThrowHelper.GetNotSupportedException_CollectionIsReadOnly();
			}
		}

		public ValueCollection(JsonPropertyDictionary<T> P_0)
		{
			_parent = P_0;
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			foreach (KeyValuePair<string, T> item in _parent)
			{
				yield return item.Value;
			}
		}

		public void Add(T P_0)
		{
			ThrowHelper.ThrowNotSupportedException_CollectionIsReadOnly();
		}

		public void Clear()
		{
			ThrowHelper.ThrowNotSupportedException_CollectionIsReadOnly();
		}

		public bool Contains(T P_0)
		{
			return _parent.ContainsValue(P_0);
		}

		public void CopyTo(T[] P_0, int P_1)
		{
			if (P_1 < 0)
			{
				ThrowHelper.ThrowArgumentOutOfRangeException_ArrayIndexNegative("index");
			}
			foreach (KeyValuePair<string, T> item in _parent)
			{
				if (P_1 >= P_0.Length)
				{
					ThrowHelper.ThrowArgumentException_ArrayTooSmall("nodeArray");
				}
				P_0[P_1++] = item.Value;
			}
		}

		public IEnumerator<T> GetEnumerator()
		{
			foreach (KeyValuePair<string, T> item in _parent)
			{
				yield return item.Value;
			}
		}

		bool ICollection<T>.Remove(T P_0)
		{
			throw ThrowHelper.GetNotSupportedException_CollectionIsReadOnly();
		}

		public int IndexOf(T P_0)
		{
			throw ThrowHelper.GetNotSupportedException_CollectionIsReadOnly();
		}

		public void Insert(int P_0, T P_1)
		{
			throw ThrowHelper.GetNotSupportedException_CollectionIsReadOnly();
		}

		public void RemoveAt(int P_0)
		{
			throw ThrowHelper.GetNotSupportedException_CollectionIsReadOnly();
		}
	}

	private Dictionary<string, T> _propertyDictionary;

	private readonly List<KeyValuePair<string, T>> _propertyList;

	private readonly StringComparer _stringComparer;

	private KeyCollection _keyCollection;

	private ValueCollection _valueCollection;

	public List<KeyValuePair<string, T>> List => _propertyList;

	public int Count => _propertyList.Count;

	public IList<string> Keys => GetKeyCollection();

	public IList<T> Values => GetValueCollection();

	public bool IsReadOnly { get; }

	public T this[string P_0]
	{
		get
		{
			if (TryGetPropertyValue(P_0, out var result))
			{
				return result;
			}
			return null;
		}
		[param: DisallowNull]
		set
		{
			SetValue(text, val);
		}
	}

	public JsonPropertyDictionary(bool P_0)
	{
		_stringComparer = (P_0 ? StringComparer.OrdinalIgnoreCase : StringComparer.Ordinal);
		_propertyList = new List<KeyValuePair<string, T>>();
	}

	public JsonPropertyDictionary(bool P_0, int P_1)
	{
		_stringComparer = (P_0 ? StringComparer.OrdinalIgnoreCase : StringComparer.Ordinal);
		_propertyList = new List<KeyValuePair<string, T>>(P_1);
	}

	public void Add(string P_0, T P_1)
	{
		if (IsReadOnly)
		{
			ThrowHelper.ThrowNotSupportedException_CollectionIsReadOnly();
		}
		if (P_0 == null)
		{
			ThrowHelper.ThrowArgumentNullException("propertyName");
		}
		AddValue(P_0, P_1);
	}

	public void Add(KeyValuePair<string, T> P_0)
	{
		if (IsReadOnly)
		{
			ThrowHelper.ThrowNotSupportedException_CollectionIsReadOnly();
		}
		Add(P_0.Key, P_0.Value);
	}

	public bool TryAdd(string P_0, T P_1)
	{
		if (IsReadOnly)
		{
			ThrowHelper.ThrowNotSupportedException_CollectionIsReadOnly();
		}
		return TryAddValue(P_0, P_1);
	}

	public void Clear()
	{
		if (IsReadOnly)
		{
			ThrowHelper.ThrowNotSupportedException_CollectionIsReadOnly();
		}
		_propertyList.Clear();
		_propertyDictionary?.Clear();
	}

	public bool ContainsKey(string P_0)
	{
		if (P_0 == null)
		{
			ThrowHelper.ThrowArgumentNullException("propertyName");
		}
		return ContainsProperty(P_0);
	}

	public bool Contains(KeyValuePair<string, T> P_0)
	{
		using (IEnumerator<KeyValuePair<string, T>> enumerator = GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				KeyValuePair<string, T> current = enumerator.Current;
				if (P_0.Value == current.Value && _stringComparer.Equals(P_0.Key, current.Key))
				{
					return true;
				}
			}
		}
		return false;
	}

	public void CopyTo(KeyValuePair<string, T>[] P_0, int P_1)
	{
		if (P_1 < 0)
		{
			ThrowHelper.ThrowArgumentOutOfRangeException_ArrayIndexNegative("index");
		}
		foreach (KeyValuePair<string, T> property in _propertyList)
		{
			if (P_1 >= P_0.Length)
			{
				ThrowHelper.ThrowArgumentException_ArrayTooSmall("array");
			}
			P_0[P_1++] = property;
		}
	}

	public IEnumerator<KeyValuePair<string, T>> GetEnumerator()
	{
		foreach (KeyValuePair<string, T> property in _propertyList)
		{
			yield return property;
		}
	}

	public bool TryGetValue(string P_0, [MaybeNullWhen(false)] out T P_1)
	{
		if (P_0 == null)
		{
			ThrowHelper.ThrowArgumentNullException("propertyName");
		}
		if (_propertyDictionary != null)
		{
			return _propertyDictionary.TryGetValue(P_0, out P_1);
		}
		foreach (KeyValuePair<string, T> property in _propertyList)
		{
			if (_stringComparer.Equals(P_0, property.Key))
			{
				P_1 = property.Value;
				return true;
			}
		}
		P_1 = null;
		return false;
	}

	public T SetValue(string P_0, T P_1, Action P_2 = null)
	{
		if (IsReadOnly)
		{
			ThrowHelper.ThrowNotSupportedException_CollectionIsReadOnly();
		}
		if (P_0 == null)
		{
			ThrowHelper.ThrowArgumentNullException("propertyName");
		}
		CreateDictionaryIfThresholdMet();
		T val = null;
		if (_propertyDictionary != null)
		{
			if (_propertyDictionary.TryAdd(in P_0, in P_1))
			{
				P_2?.Invoke();
				_propertyList.Add(new KeyValuePair<string, T>(P_0, P_1));
				return null;
			}
			val = _propertyDictionary[P_0];
			if (val == P_1)
			{
				return null;
			}
		}
		int num = FindValueIndex(P_0);
		if (num >= 0)
		{
			if (_propertyDictionary != null)
			{
				_propertyDictionary[P_0] = P_1;
			}
			else
			{
				KeyValuePair<string, T> keyValuePair = _propertyList[num];
				if (keyValuePair.Value == P_1)
				{
					return null;
				}
				val = keyValuePair.Value;
			}
			P_2?.Invoke();
			_propertyList[num] = new KeyValuePair<string, T>(P_0, P_1);
		}
		else
		{
			P_2?.Invoke();
			_propertyDictionary?.Add(P_0, P_1);
			_propertyList.Add(new KeyValuePair<string, T>(P_0, P_1));
		}
		return val;
	}

	private void AddValue(string P_0, T P_1)
	{
		if (!TryAddValue(P_0, P_1))
		{
			ThrowHelper.ThrowArgumentException_DuplicateKey("propertyName", P_0);
		}
	}

	internal bool TryAddValue(string P_0, T P_1)
	{
		if (IsReadOnly)
		{
			ThrowHelper.ThrowNotSupportedException_CollectionIsReadOnly();
		}
		CreateDictionaryIfThresholdMet();
		if (_propertyDictionary == null)
		{
			if (ContainsProperty(P_0))
			{
				return false;
			}
		}
		else if (!_propertyDictionary.TryAdd(in P_0, in P_1))
		{
			return false;
		}
		_propertyList.Add(new KeyValuePair<string, T>(P_0, P_1));
		return true;
	}

	private void CreateDictionaryIfThresholdMet()
	{
		if (_propertyDictionary == null && _propertyList.Count > 9)
		{
			_propertyDictionary = JsonHelpers.CreateDictionaryFromCollection(_propertyList, _stringComparer);
		}
	}

	internal bool ContainsValue(T P_0)
	{
		foreach (T item in GetValueCollection())
		{
			if (item == P_0)
			{
				return true;
			}
		}
		return false;
	}

	private bool ContainsProperty(string P_0)
	{
		if (_propertyDictionary != null)
		{
			return _propertyDictionary.ContainsKey(P_0);
		}
		foreach (KeyValuePair<string, T> property in _propertyList)
		{
			if (_stringComparer.Equals(P_0, property.Key))
			{
				return true;
			}
		}
		return false;
	}

	private int FindValueIndex(string P_0)
	{
		for (int i = 0; i < _propertyList.Count; i++)
		{
			KeyValuePair<string, T> keyValuePair = _propertyList[i];
			if (_stringComparer.Equals(P_0, keyValuePair.Key))
			{
				return i;
			}
		}
		return -1;
	}

	public bool TryGetPropertyValue(string P_0, [MaybeNullWhen(false)] out T P_1)
	{
		return TryGetValue(P_0, out P_1);
	}

	public bool TryRemoveProperty(string P_0, [MaybeNullWhen(false)] out T P_1)
	{
		if (IsReadOnly)
		{
			ThrowHelper.ThrowNotSupportedException_CollectionIsReadOnly();
		}
		if (_propertyDictionary != null)
		{
			if (!_propertyDictionary.TryGetValue(P_0, out P_1))
			{
				return false;
			}
			bool flag = _propertyDictionary.Remove(P_0);
		}
		for (int i = 0; i < _propertyList.Count; i++)
		{
			KeyValuePair<string, T> keyValuePair = _propertyList[i];
			if (_stringComparer.Equals(keyValuePair.Key, P_0))
			{
				_propertyList.RemoveAt(i);
				P_1 = keyValuePair.Value;
				return true;
			}
		}
		P_1 = null;
		return false;
	}

	public IList<string> GetKeyCollection()
	{
		return _keyCollection ?? (_keyCollection = new KeyCollection(this));
	}

	public IList<T> GetValueCollection()
	{
		return _valueCollection ?? (_valueCollection = new ValueCollection(this));
	}
}
