using System.Collections;

namespace System.Xml;

internal sealed class EmptyEnumerator : IEnumerator
{
	object IEnumerator.Current
	{
		get
		{
			throw new InvalidOperationException("Xml_InvalidOperation");
		}
	}

	bool IEnumerator.MoveNext()
	{
		return false;
	}

	void IEnumerator.Reset()
	{
	}
}
