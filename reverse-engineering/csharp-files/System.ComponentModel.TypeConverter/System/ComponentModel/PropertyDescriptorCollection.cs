using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace System.ComponentModel;

public class PropertyDescriptorCollection : ICollection, IEnumerable, IList, IDictionary
{
	private sealed class PropertyDescriptorEnumerator : IDictionaryEnumerator, IEnumerator
	{
		private readonly PropertyDescriptorCollection _owner;

		private int _index = -1;

		public object Current => Entry;

		public DictionaryEntry Entry
		{
			get
			{
				PropertyDescriptor propertyDescriptor = _owner[_index];
				return new DictionaryEntry(propertyDescriptor.Name, propertyDescriptor);
			}
		}

		public object Key => _owner[_index].Name;

		public object Value => _owner[_index].Name;

		public PropertyDescriptorEnumerator(PropertyDescriptorCollection P_0)
		{
			_owner = P_0;
		}

		public bool MoveNext()
		{
			if (_index < _owner.Count - 1)
			{
				_index++;
				return true;
			}
			return false;
		}

		public void Reset()
		{
			_index = -1;
		}
	}

	public static readonly PropertyDescriptorCollection Empty = new PropertyDescriptorCollection(null, true);

	private IDictionary _cachedFoundProperties;

	private bool _cachedIgnoreCase;

	private PropertyDescriptor[] _properties;

	private readonly string[] _namedSort;

	private readonly IComparer _comparer;

	private bool _propsOwned;

	private bool _needSort;

	private readonly bool _readOnly;

	private readonly object _internalSyncObject = new object();

	[CompilerGenerated]
	private int _003CCount_003Ek__BackingField;

	public int Count
	{
		[CompilerGenerated]
		get
		{
			return _003CCount_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			_003CCount_003Ek__BackingField = num;
		}
	}

	public virtual PropertyDescriptor this[int P_0]
	{
		get
		{
			if (P_0 >= Count)
			{
				throw new IndexOutOfRangeException();
			}
			EnsurePropsOwned();
			return _properties[P_0];
		}
	}

	public virtual PropertyDescriptor? this[string P_0] => Find(P_0, false);

	bool ICollection.IsSynchronized => false;

	object ICollection.SyncRoot => null;

	int ICollection.Count => Count;

	bool IDictionary.IsReadOnly => _readOnly;

	object? IDictionary.this[object P_0]
	{
		get
		{
			if (P_0 is string)
			{
				return this[(string)P_0];
			}
			return null;
		}
		set
		{
			if (_readOnly)
			{
				throw new NotSupportedException();
			}
			if (obj != null && (object)null == null)
			{
				throw new ArgumentException("value");
			}
			int num = -1;
			if (obj2 is int)
			{
				num = (int)obj2;
				if (num < 0 || num >= Count)
				{
					throw new IndexOutOfRangeException();
				}
			}
			else
			{
				if (!(obj2 is string))
				{
					throw new ArgumentException("key");
				}
				for (int i = 0; i < Count; i++)
				{
					if (_properties[i].Name.Equals((string)obj2))
					{
						num = i;
						break;
					}
				}
			}
			if (num == -1)
			{
				Add((PropertyDescriptor)obj);
				return;
			}
			EnsurePropsOwned();
			_properties[num] = (PropertyDescriptor)obj;
			if (_cachedFoundProperties != null && obj2 is string)
			{
				_cachedFoundProperties[obj2] = obj;
			}
		}
	}

	ICollection IDictionary.Keys
	{
		get
		{
			string[] array = new string[Count];
			for (int i = 0; i < Count; i++)
			{
				array[i] = _properties[i].Name;
			}
			return array;
		}
	}

	bool IList.IsReadOnly => _readOnly;

	bool IList.IsFixedSize => _readOnly;

	object? IList.this[int P_0]
	{
		get
		{
			return this[P_0];
		}
		set
		{
			if (_readOnly)
			{
				throw new NotSupportedException();
			}
			if (num >= Count)
			{
				throw new IndexOutOfRangeException();
			}
			if (obj != null && (object)null == null)
			{
				throw new ArgumentException("value");
			}
			EnsurePropsOwned();
			_properties[num] = (PropertyDescriptor)obj;
		}
	}

	public PropertyDescriptorCollection(PropertyDescriptor[]? P_0)
	{
		if (P_0 == null)
		{
			_properties = Array.Empty<PropertyDescriptor>();
			Count = 0;
		}
		else
		{
			_properties = P_0;
			Count = P_0.Length;
		}
		_propsOwned = true;
	}

	public PropertyDescriptorCollection(PropertyDescriptor[]? P_0, bool P_1)
		: this(P_0)
	{
		_readOnly = P_1;
	}

	public int Add(PropertyDescriptor P_0)
	{
		if (_readOnly)
		{
			throw new NotSupportedException();
		}
		EnsureSize(Count + 1);
		_properties[Count++] = P_0;
		return Count - 1;
	}

	public void Clear()
	{
		if (_readOnly)
		{
			throw new NotSupportedException();
		}
		Count = 0;
		_cachedFoundProperties = null;
	}

	public bool Contains(PropertyDescriptor P_0)
	{
		return IndexOf(P_0) >= 0;
	}

	public void CopyTo(Array P_0, int P_1)
	{
		EnsurePropsOwned();
		Array.Copy(_properties, 0, P_0, P_1, Count);
	}

	private void EnsurePropsOwned()
	{
		if (!_propsOwned)
		{
			_propsOwned = true;
			if (_properties != null)
			{
				PropertyDescriptor[] array = new PropertyDescriptor[Count];
				Array.Copy(_properties, array, Count);
				_properties = array;
			}
		}
		if (_needSort)
		{
			_needSort = false;
			InternalSort(_namedSort);
		}
	}

	private void EnsureSize(int P_0)
	{
		if (P_0 > _properties.Length)
		{
			if (_properties.Length == 0)
			{
				Count = 0;
				_properties = new PropertyDescriptor[P_0];
				return;
			}
			EnsurePropsOwned();
			int num = Math.Max(P_0, _properties.Length * 2);
			PropertyDescriptor[] array = new PropertyDescriptor[num];
			Array.Copy(_properties, array, Count);
			_properties = array;
		}
	}

	public virtual PropertyDescriptor? Find(string P_0, bool P_1)
	{
		lock (_internalSyncObject)
		{
			PropertyDescriptor result = null;
			if (_cachedFoundProperties == null || _cachedIgnoreCase != P_1)
			{
				_cachedIgnoreCase = P_1;
				if (P_1)
				{
					_cachedFoundProperties = new Hashtable(StringComparer.OrdinalIgnoreCase);
				}
				else
				{
					_cachedFoundProperties = new Hashtable();
				}
			}
			object obj = _cachedFoundProperties[P_0];
			if (obj != null)
			{
				return (PropertyDescriptor)obj;
			}
			for (int i = 0; i < Count; i++)
			{
				if (P_1)
				{
					if (string.Equals(_properties[i].Name, P_0, StringComparison.OrdinalIgnoreCase))
					{
						_cachedFoundProperties[P_0] = _properties[i];
						result = _properties[i];
						break;
					}
				}
				else if (_properties[i].Name.Equals(P_0))
				{
					_cachedFoundProperties[P_0] = _properties[i];
					result = _properties[i];
					break;
				}
			}
			return result;
		}
	}

	public int IndexOf(PropertyDescriptor? P_0)
	{
		return Array.IndexOf<PropertyDescriptor>(_properties, P_0, 0, Count);
	}

	public void Insert(int P_0, PropertyDescriptor P_1)
	{
		if (_readOnly)
		{
			throw new NotSupportedException();
		}
		EnsureSize(Count + 1);
		if (P_0 < Count)
		{
			Array.Copy(_properties, P_0, _properties, P_0 + 1, Count - P_0);
		}
		_properties[P_0] = P_1;
		Count++;
	}

	public void Remove(PropertyDescriptor? P_0)
	{
		if (_readOnly)
		{
			throw new NotSupportedException();
		}
		int num = IndexOf(P_0);
		if (num != -1)
		{
			RemoveAt(num);
		}
	}

	public void RemoveAt(int P_0)
	{
		if (_readOnly)
		{
			throw new NotSupportedException();
		}
		if (P_0 < Count - 1)
		{
			Array.Copy(_properties, P_0 + 1, _properties, P_0, Count - P_0 - 1);
		}
		_properties[Count - 1] = null;
		Count--;
	}

	protected void InternalSort(string[]? P_0)
	{
		if (_properties.Length == 0)
		{
			return;
		}
		InternalSort(_comparer);
		if (P_0 == null || P_0.Length == 0)
		{
			return;
		}
		List<PropertyDescriptor> list = new List<PropertyDescriptor>(_properties);
		int num = 0;
		int num2 = _properties.Length;
		for (int i = 0; i < P_0.Length; i++)
		{
			for (int j = 0; j < num2; j++)
			{
				PropertyDescriptor propertyDescriptor = list[j];
				if (propertyDescriptor != null && propertyDescriptor.Name.Equals(P_0[i]))
				{
					_properties[num++] = propertyDescriptor;
					list[j] = null;
					break;
				}
			}
		}
		for (int k = 0; k < num2; k++)
		{
			if (list[k] != null)
			{
				_properties[num++] = list[k];
			}
		}
	}

	protected void InternalSort(IComparer? P_0)
	{
		if (P_0 == null)
		{
			TypeDescriptor.SortDescriptorArray(this);
		}
		else
		{
			Array.Sort(_properties, P_0);
		}
	}

	public virtual IEnumerator GetEnumerator()
	{
		EnsurePropsOwned();
		if (_properties.Length != Count)
		{
			PropertyDescriptor[] array = new PropertyDescriptor[Count];
			Array.Copy(_properties, array, Count);
			return array.GetEnumerator();
		}
		return _properties.GetEnumerator();
	}

	void IList.Clear()
	{
		Clear();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}

	void IList.RemoveAt(int P_0)
	{
		RemoveAt(P_0);
	}

	bool IDictionary.Contains(object P_0)
	{
		if (P_0 is string)
		{
			return this[(string)P_0] != null;
		}
		return false;
	}

	IDictionaryEnumerator IDictionary.GetEnumerator()
	{
		return new PropertyDescriptorEnumerator(this);
	}

	void IDictionary.Remove(object P_0)
	{
		if (P_0 is string)
		{
			PropertyDescriptor propertyDescriptor = this[(string)P_0];
			if (propertyDescriptor != null)
			{
				((IList)this).Remove((object?)propertyDescriptor);
			}
		}
	}

	int IList.Add(object P_0)
	{
		return Add((PropertyDescriptor)P_0);
	}

	bool IList.Contains(object P_0)
	{
		return Contains((PropertyDescriptor)P_0);
	}

	int IList.IndexOf(object P_0)
	{
		return IndexOf((PropertyDescriptor)P_0);
	}

	void IList.Insert(int P_0, object P_1)
	{
		Insert(P_0, (PropertyDescriptor)P_1);
	}

	void IList.Remove(object P_0)
	{
		Remove((PropertyDescriptor)P_0);
	}
}
