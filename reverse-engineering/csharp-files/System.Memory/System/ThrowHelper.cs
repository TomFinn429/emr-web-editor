using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace System;

internal static class ThrowHelper
{
	[DoesNotReturn]
	internal static void ThrowArgumentNullException(System.ExceptionArgument P_0)
	{
		throw CreateArgumentNullException(P_0);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static Exception CreateArgumentNullException(System.ExceptionArgument P_0)
	{
		return new ArgumentNullException(P_0.ToString());
	}

	[DoesNotReturn]
	internal static void ThrowArgumentOutOfRangeException(System.ExceptionArgument P_0)
	{
		throw CreateArgumentOutOfRangeException(P_0);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static Exception CreateArgumentOutOfRangeException(System.ExceptionArgument P_0)
	{
		return new ArgumentOutOfRangeException(P_0.ToString());
	}

	[DoesNotReturn]
	internal static void ThrowInvalidOperationException_EndPositionNotReached()
	{
		throw CreateInvalidOperationException_EndPositionNotReached();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static Exception CreateInvalidOperationException_EndPositionNotReached()
	{
		return new InvalidOperationException("EndPositionNotReached");
	}

	[DoesNotReturn]
	internal static void ThrowArgumentOutOfRangeException_PositionOutOfRange()
	{
		throw CreateArgumentOutOfRangeException_PositionOutOfRange();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static Exception CreateArgumentOutOfRangeException_PositionOutOfRange()
	{
		return new ArgumentOutOfRangeException("position");
	}

	[DoesNotReturn]
	public static void ThrowStartOrEndArgumentValidationException(long P_0)
	{
		throw CreateStartOrEndArgumentValidationException(P_0);
	}

	private static Exception CreateStartOrEndArgumentValidationException(long P_0)
	{
		if (P_0 < 0)
		{
			return CreateArgumentOutOfRangeException(System.ExceptionArgument.start);
		}
		return CreateArgumentOutOfRangeException(System.ExceptionArgument.length);
	}
}
