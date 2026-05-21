using System.Diagnostics.CodeAnalysis;

namespace System;

internal static class ThrowHelper
{
	[DoesNotReturn]
	internal static void ThrowKeyNullException()
	{
		ThrowArgumentNullException("key");
	}

	[DoesNotReturn]
	internal static void ThrowArgumentNullException(string P_0)
	{
		throw new ArgumentNullException(P_0);
	}

	[DoesNotReturn]
	internal static void ThrowArgumentNullException(string P_0, string P_1)
	{
		throw new ArgumentNullException(P_0, P_1);
	}

	[DoesNotReturn]
	internal static void ThrowValueNullException()
	{
		throw new ArgumentException("ConcurrentDictionary_TypeOfValueIncorrect");
	}

	[DoesNotReturn]
	internal static void ThrowOutOfMemoryException()
	{
		throw new OutOfMemoryException();
	}
}
