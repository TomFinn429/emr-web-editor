using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace System.Collections.Concurrent;

public class ConcurrentStack<T> : IEnumerable<T>, IEnumerable, ICollection, IReadOnlyCollection<T>
{
	public int Count
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw new NotSupportedException("Linked away");
		}
	}

	bool ICollection.IsSynchronized => false;

	object ICollection.SyncRoot
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw new NotSupportedException("Linked away");
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	void ICollection.CopyTo(Array P_0, int P_1)
	{
		throw new NotSupportedException("Linked away");
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Push(T P_0)
	{
		throw new NotSupportedException("Linked away");
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public IEnumerator<T> GetEnumerator()
	{
		throw new NotSupportedException("Linked away");
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	IEnumerator IEnumerable.GetEnumerator()
	{
		throw new NotSupportedException("Linked away");
	}
}
