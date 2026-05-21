using System.Collections;
using System.Runtime.CompilerServices;

namespace System.Xml;

public abstract class XmlNodeList : IEnumerable, IDisposable
{
	public abstract int Count { get; }

	[IndexerName("ItemOf")]
	public virtual XmlNode? this[int P_0] => Item(P_0);

	public abstract XmlNode? Item(int P_0);

	public abstract IEnumerator GetEnumerator();

	void IDisposable.Dispose()
	{
		PrivateDisposeNodeList();
	}

	protected virtual void PrivateDisposeNodeList()
	{
	}
}
