namespace System.Collections;

public abstract class CollectionBase : IList, ICollection, IEnumerable
{
	private readonly ArrayList _list;

	protected ArrayList InnerList => _list;

	protected IList List => this;

	public int Count => _list.Count;

	bool IList.IsReadOnly => InnerList.IsReadOnly;

	bool IList.IsFixedSize => InnerList.IsFixedSize;

	bool ICollection.IsSynchronized => InnerList.IsSynchronized;

	object ICollection.SyncRoot => InnerList.SyncRoot;

	object? IList.this[int P_0]
	{
		get
		{
			if (P_0 < 0 || P_0 >= Count)
			{
				throw new ArgumentOutOfRangeException("index", "ArgumentOutOfRange_IndexMustBeLess");
			}
			return InnerList[P_0];
		}
		set
		{
			if (num < 0 || num >= Count)
			{
				throw new ArgumentOutOfRangeException("index", "ArgumentOutOfRange_IndexMustBeLess");
			}
			OnValidate(obj);
			object obj2 = InnerList[num];
			OnSet(num, obj2, obj);
			InnerList[num] = obj;
			try
			{
				OnSetComplete(num, obj2, obj);
			}
			catch
			{
				InnerList[num] = obj2;
				throw;
			}
		}
	}

	protected CollectionBase()
	{
		_list = new ArrayList();
	}

	public void Clear()
	{
		OnClear();
		InnerList.Clear();
		OnClearComplete();
	}

	public void RemoveAt(int P_0)
	{
		if (P_0 < 0 || P_0 >= Count)
		{
			throw new ArgumentOutOfRangeException("index", "ArgumentOutOfRange_IndexMustBeLess");
		}
		object obj = InnerList[P_0];
		OnValidate(obj);
		OnRemove(P_0, obj);
		InnerList.RemoveAt(P_0);
		try
		{
			OnRemoveComplete(P_0, obj);
		}
		catch
		{
			InnerList.Insert(P_0, obj);
			throw;
		}
	}

	void ICollection.CopyTo(Array P_0, int P_1)
	{
		InnerList.CopyTo(P_0, P_1);
	}

	bool IList.Contains(object P_0)
	{
		return InnerList.Contains(P_0);
	}

	int IList.Add(object P_0)
	{
		OnValidate(P_0);
		OnInsert(InnerList.Count, P_0);
		int num = InnerList.Add(P_0);
		try
		{
			OnInsertComplete(num, P_0);
			return num;
		}
		catch
		{
			InnerList.RemoveAt(num);
			throw;
		}
	}

	void IList.Remove(object P_0)
	{
		OnValidate(P_0);
		int num = InnerList.IndexOf(P_0);
		if (num < 0)
		{
			throw new ArgumentException("Arg_RemoveArgNotFound");
		}
		OnRemove(num, P_0);
		InnerList.RemoveAt(num);
		try
		{
			OnRemoveComplete(num, P_0);
		}
		catch
		{
			InnerList.Insert(num, P_0);
			throw;
		}
	}

	int IList.IndexOf(object P_0)
	{
		return InnerList.IndexOf(P_0);
	}

	void IList.Insert(int P_0, object P_1)
	{
		if (P_0 < 0 || P_0 > Count)
		{
			throw new ArgumentOutOfRangeException("index", "ArgumentOutOfRange_IndexMustBeLessOrEqual");
		}
		OnValidate(P_1);
		OnInsert(P_0, P_1);
		InnerList.Insert(P_0, P_1);
		try
		{
			OnInsertComplete(P_0, P_1);
		}
		catch
		{
			InnerList.RemoveAt(P_0);
			throw;
		}
	}

	public IEnumerator GetEnumerator()
	{
		return InnerList.GetEnumerator();
	}

	protected virtual void OnSet(int P_0, object? P_1, object? P_2)
	{
	}

	protected virtual void OnInsert(int P_0, object? P_1)
	{
	}

	protected virtual void OnClear()
	{
	}

	protected virtual void OnRemove(int P_0, object? P_1)
	{
	}

	protected virtual void OnValidate(object P_0)
	{
		ArgumentNullException.ThrowIfNull(P_0, "value");
	}

	protected virtual void OnSetComplete(int P_0, object? P_1, object? P_2)
	{
	}

	protected virtual void OnInsertComplete(int P_0, object? P_1)
	{
	}

	protected virtual void OnClearComplete()
	{
	}

	protected virtual void OnRemoveComplete(int P_0, object? P_1)
	{
	}
}
