using System.Runtime.CompilerServices;

namespace System.Collections;

public abstract class ReadOnlyCollectionBase : ICollection
{
	public virtual int Count
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw new NotSupportedException("Linked away");
		}
	}

	bool ICollection.IsSynchronized
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw new NotSupportedException("Linked away");
		}
	}

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
	public virtual IEnumerator GetEnumerator()
	{
		throw new NotSupportedException("Linked away");
	}
}
