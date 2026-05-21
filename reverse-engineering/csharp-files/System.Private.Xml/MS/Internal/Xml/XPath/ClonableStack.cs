using System.Collections.Generic;

namespace MS.Internal.Xml.XPath;

internal sealed class ClonableStack<T> : List<T>
{
	public ClonableStack()
	{
	}

	private ClonableStack(IEnumerable<T> P_0)
		: base(P_0)
	{
	}

	public void Push(T P_0)
	{
		Add(P_0);
	}

	public T Pop()
	{
		int num = base.Count - 1;
		T result = base[num];
		RemoveAt(num);
		return result;
	}

	public T Peek()
	{
		return base[base.Count - 1];
	}

	public ClonableStack<T> Clone()
	{
		return new ClonableStack<T>(this);
	}
}
