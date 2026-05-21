using System.Collections;
using System.Collections.Generic;

namespace DCSoft.Writer.Dom;

public class SearchStringResultList : IEnumerable<SearchStringResult>, IEnumerable
{
	private readonly List<SearchStringResult> _list = new List<SearchStringResult>();

	public SearchStringResult this[int index] => _list[index];

	public int Count => _list.Count;

	internal SearchStringResultList()
	{
	}

	internal void InnerAdd(SearchStringResult result)
	{
		_list.Add(result);
	}

	public IEnumerator<SearchStringResult> GetEnumerator()
	{
		return _list.GetEnumerator();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return _list.GetEnumerator();
	}
}
