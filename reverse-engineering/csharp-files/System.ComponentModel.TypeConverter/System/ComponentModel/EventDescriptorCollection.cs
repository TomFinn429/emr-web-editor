using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace System.ComponentModel;

public class EventDescriptorCollection : ICollection, IEnumerable, IList
{
	private sealed class ArraySubsetEnumerator : IEnumerator
	{
		private readonly Array _array;

		private readonly int _total;

		private int _current;

		public object Current
		{
			get
			{
				if (_current == -1)
				{
					throw new InvalidOperationException();
				}
				return _array.GetValue(_current);
			}
		}

		public ArraySubsetEnumerator(Array P_0, int P_1)
		{
			_array = P_0;
			_total = P_1;
			_current = -1;
		}

		public bool MoveNext()
		{
			if (_current < _total - 1)
			{
				_current++;
				return true;
			}
			return false;
		}

		public void Reset()
		{
			_current = -1;
		}
	}

	private EventDescriptor[] _events;

	private readonly string[] _namedSort;

	private readonly IComparer _comparer;

	private bool _eventsOwned;

	private bool _needSort;

	private readonly bool _readOnly;

	public static readonly EventDescriptorCollection Empty = new EventDescriptorCollection(null, true);

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

	public virtual EventDescriptor? this[int P_0]
	{
		get
		{
			if (P_0 >= Count)
			{
				throw new IndexOutOfRangeException();
			}
			EnsureEventsOwned();
			return _events[P_0];
		}
	}

	bool ICollection.IsSynchronized => false;

	object ICollection.SyncRoot => null;

	int ICollection.Count => Count;

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
			EnsureEventsOwned();
			_events[num] = (EventDescriptor)obj;
		}
	}

	bool IList.IsReadOnly => _readOnly;

	bool IList.IsFixedSize => _readOnly;

	public EventDescriptorCollection(EventDescriptor[]? P_0)
	{
		if (P_0 == null)
		{
			_events = Array.Empty<EventDescriptor>();
		}
		else
		{
			_events = P_0;
			Count = P_0.Length;
		}
		_eventsOwned = true;
	}

	public EventDescriptorCollection(EventDescriptor[]? P_0, bool P_1)
		: this(P_0)
	{
		_readOnly = P_1;
	}

	public int Add(EventDescriptor? P_0)
	{
		if (_readOnly)
		{
			throw new NotSupportedException();
		}
		EnsureSize(Count + 1);
		_events[Count++] = P_0;
		return Count - 1;
	}

	public void Clear()
	{
		if (_readOnly)
		{
			throw new NotSupportedException();
		}
		Count = 0;
	}

	public bool Contains(EventDescriptor? P_0)
	{
		return IndexOf(P_0) >= 0;
	}

	void ICollection.CopyTo(Array P_0, int P_1)
	{
		EnsureEventsOwned();
		Array.Copy(_events, 0, P_0, P_1, Count);
	}

	private void EnsureEventsOwned()
	{
		if (!_eventsOwned)
		{
			_eventsOwned = true;
			if (_events != null)
			{
				EventDescriptor[] array = new EventDescriptor[Count];
				Array.Copy(_events, array, Count);
				_events = array;
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
		if (P_0 > _events.Length)
		{
			if (_events.Length == 0)
			{
				Count = 0;
				_events = new EventDescriptor[P_0];
				return;
			}
			EnsureEventsOwned();
			int num = Math.Max(P_0, _events.Length * 2);
			EventDescriptor[] array = new EventDescriptor[num];
			Array.Copy(_events, array, Count);
			_events = array;
		}
	}

	public int IndexOf(EventDescriptor? P_0)
	{
		return Array.IndexOf<EventDescriptor>(_events, P_0, 0, Count);
	}

	public void Insert(int P_0, EventDescriptor? P_1)
	{
		if (_readOnly)
		{
			throw new NotSupportedException();
		}
		EnsureSize(Count + 1);
		if (P_0 < Count)
		{
			Array.Copy(_events, P_0, _events, P_0 + 1, Count - P_0);
		}
		_events[P_0] = P_1;
		Count++;
	}

	public void Remove(EventDescriptor? P_0)
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
			Array.Copy(_events, P_0 + 1, _events, P_0, Count - P_0 - 1);
		}
		_events[Count - 1] = null;
		Count--;
	}

	public IEnumerator GetEnumerator()
	{
		if (_events.Length == Count)
		{
			return _events.GetEnumerator();
		}
		return new ArraySubsetEnumerator(_events, Count);
	}

	protected void InternalSort(string[]? P_0)
	{
		if (_events.Length == 0)
		{
			return;
		}
		InternalSort(_comparer);
		if (P_0 == null || P_0.Length == 0)
		{
			return;
		}
		List<EventDescriptor> list = new List<EventDescriptor>(_events);
		int num = 0;
		int num2 = _events.Length;
		for (int i = 0; i < P_0.Length; i++)
		{
			for (int j = 0; j < num2; j++)
			{
				EventDescriptor eventDescriptor = list[j];
				if (eventDescriptor != null && eventDescriptor.Name.Equals(P_0[i]))
				{
					_events[num++] = eventDescriptor;
					list[j] = null;
					break;
				}
			}
		}
		for (int k = 0; k < num2; k++)
		{
			if (list[k] != null)
			{
				_events[num++] = list[k];
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
			Array.Sort(_events, P_0);
		}
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}

	int IList.Add(object P_0)
	{
		return Add((EventDescriptor)P_0);
	}

	bool IList.Contains(object P_0)
	{
		return Contains((EventDescriptor)P_0);
	}

	void IList.Clear()
	{
		Clear();
	}

	int IList.IndexOf(object P_0)
	{
		return IndexOf((EventDescriptor)P_0);
	}

	void IList.Insert(int P_0, object P_1)
	{
		Insert(P_0, (EventDescriptor)P_1);
	}

	void IList.Remove(object P_0)
	{
		Remove((EventDescriptor)P_0);
	}

	void IList.RemoveAt(int P_0)
	{
		RemoveAt(P_0);
	}
}
