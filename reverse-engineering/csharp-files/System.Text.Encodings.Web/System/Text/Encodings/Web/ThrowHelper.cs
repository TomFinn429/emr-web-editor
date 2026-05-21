using System.Diagnostics.CodeAnalysis;

namespace System.Text.Encodings.Web;

internal static class ThrowHelper
{
	[DoesNotReturn]
	internal static void ThrowArgumentNullException(ExceptionArgument P_0)
	{
		throw new ArgumentNullException(GetArgumentName(P_0));
	}

	private static string GetArgumentName(ExceptionArgument P_0)
	{
		return P_0.ToString();
	}
}
