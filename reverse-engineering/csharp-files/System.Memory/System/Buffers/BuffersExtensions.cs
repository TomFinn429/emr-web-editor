using System.Runtime.CompilerServices;

namespace System.Buffers;

public static class BuffersExtensions
{
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static void CopyTo<T>(this in ReadOnlySequence<T> P_0, Span<T> P_1)
	{
		if (P_0.IsSingleSegment)
		{
			ReadOnlySpan<T> span = P_0.First.Span;
			if (span.Length > P_1.Length)
			{
				System.ThrowHelper.ThrowArgumentOutOfRangeException(System.ExceptionArgument.destination);
			}
			span.CopyTo(P_1);
		}
		else
		{
			CopyToMultiSegment(in P_0, P_1);
		}
	}

	private static void CopyToMultiSegment<T>(in ReadOnlySequence<T> P_0, Span<T> P_1)
	{
		if (P_0.Length > P_1.Length)
		{
			System.ThrowHelper.ThrowArgumentOutOfRangeException(System.ExceptionArgument.destination);
		}
		SequencePosition start = P_0.Start;
		ReadOnlyMemory<T> readOnlyMemory;
		while (P_0.TryGet(ref start, out readOnlyMemory))
		{
			ReadOnlySpan<T> span = readOnlyMemory.Span;
			span.CopyTo(P_1);
			if (start.GetObject() != null)
			{
				P_1 = P_1.Slice(span.Length);
				continue;
			}
			break;
		}
	}

	public static T[] ToArray<T>(this in ReadOnlySequence<T> P_0)
	{
		T[] array = new T[P_0.Length];
		CopyTo(in P_0, array);
		return array;
	}
}
