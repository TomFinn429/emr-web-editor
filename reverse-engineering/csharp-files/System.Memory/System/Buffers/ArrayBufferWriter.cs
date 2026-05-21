using System.Runtime.CompilerServices;

namespace System.Buffers;

public sealed class ArrayBufferWriter<T> : IBufferWriter<T>
{
	public ReadOnlySpan<T> WrittenSpan
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw new NotSupportedException("Linked away");
		}
	}

	public int WrittenCount
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw new NotSupportedException("Linked away");
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Clear()
	{
		throw new NotSupportedException("Linked away");
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Advance(int P_0)
	{
		throw new NotSupportedException("Linked away");
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Memory<T> GetMemory(int P_0 = 0)
	{
		throw new NotSupportedException("Linked away");
	}
}
