using System.Runtime.CompilerServices;

namespace System.Xml.Schema;

internal sealed class LeafRangeNode : LeafNode
{
	public decimal Max
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw new NotSupportedException("Linked away");
		}
	}

	public decimal Min
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw new NotSupportedException("Linked away");
		}
	}

	public BitSet NextIteration
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw new NotSupportedException("Linked away");
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			throw new NotSupportedException("Linked away");
		}
	}
}
