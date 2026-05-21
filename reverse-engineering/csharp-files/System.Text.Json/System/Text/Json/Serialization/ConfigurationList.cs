using System.Collections;
using System.Collections.Generic;

namespace System.Text.Json.Serialization;

internal abstract class ConfigurationList<TItem> : IList<TItem>, ICollection<TItem>, IEnumerable<TItem>, IEnumerable
{
	protected readonly List<TItem> _list;

	protected abstract bool IsImmutable { get; }

	public TItem this[int P_0]
	{
		get
		{
			return _list[P_0];
		}
		set
		{
			if (val == null)
			{
				throw new ArgumentNullException("value");
			}
			VerifyMutable();
			OnAddingElement(val);
			_list[num] = val;
		}
	}

	public int Count => _list.Count;

	public bool IsReadOnly => IsImmutable;

	public ConfigurationList(IList<TItem> P_0 = null)
	{
		_list = ((P_0 == null) ? new List<TItem>() : new List<TItem>(P_0));
	}

	protected abstract void VerifyMutable();

	protected virtual void OnAddingElement(TItem P_0)
	{
	}

	public void Add(TItem P_0)
	{
		if (P_0 == null)
		{
			ThrowHelper.ThrowArgumentNullException("item");
		}
		VerifyMutable();
		OnAddingElement(P_0);
		_list.Add(P_0);
	}

	public void Clear()
	{
		VerifyMutable();
		_list.Clear();
	}

	public bool Contains(TItem P_0)
	{
		return _list.Contains(P_0);
	}

	public void CopyTo(TItem[] P_0, int P_1)
	{
		_list.CopyTo(P_0, P_1);
	}

	public IEnumerator<TItem> GetEnumerator()
	{
		return _list.GetEnumerator();
	}

	public int IndexOf(TItem P_0)
	{
		return _list.IndexOf(P_0);
	}

	public void Insert(int P_0, TItem P_1)
	{
		if (P_1 == null)
		{
			ThrowHelper.ThrowArgumentNullException("item");
		}
		VerifyMutable();
		OnAddingElement(P_1);
		_list.Insert(P_0, P_1);
	}

	public bool Remove(TItem P_0)
	{
		VerifyMutable();
		return _list.Remove(P_0);
	}

	public void RemoveAt(int P_0)
	{
		VerifyMutable();
		_list.RemoveAt(P_0);
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return _list.GetEnumerator();
	}
}
