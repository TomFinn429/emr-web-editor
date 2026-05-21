using System.Diagnostics.CodeAnalysis;

namespace System.Text.RegularExpressions;

internal static class ThrowHelper
{
	[DoesNotReturn]
	internal static void ThrowArgumentNullException(ExceptionArgument P_0)
	{
		throw new ArgumentNullException(GetStringForExceptionArgument(P_0));
	}

	[DoesNotReturn]
	internal static void ThrowArgumentOutOfRangeException(ExceptionArgument P_0)
	{
		throw new ArgumentOutOfRangeException(GetStringForExceptionArgument(P_0));
	}

	[DoesNotReturn]
	internal static void ThrowArgumentOutOfRangeException(ExceptionArgument P_0, ExceptionResource P_1)
	{
		throw new ArgumentOutOfRangeException(GetStringForExceptionArgument(P_0), GetStringForExceptionResource(P_1));
	}

	private static string GetStringForExceptionArgument(ExceptionArgument P_0)
	{
		return P_0 switch
		{
			ExceptionArgument.assemblyname => "assemblyname", 
			ExceptionArgument.array => "array", 
			ExceptionArgument.arrayIndex => "arrayIndex", 
			ExceptionArgument.count => "count", 
			ExceptionArgument.evaluator => "evaluator", 
			ExceptionArgument.i => "i", 
			ExceptionArgument.inner => "inner", 
			ExceptionArgument.input => "input", 
			ExceptionArgument.length => "length", 
			ExceptionArgument.matchTimeout => "matchTimeout", 
			ExceptionArgument.name => "name", 
			ExceptionArgument.options => "options", 
			ExceptionArgument.pattern => "pattern", 
			ExceptionArgument.replacement => "replacement", 
			ExceptionArgument.startat => "startat", 
			ExceptionArgument.str => "str", 
			ExceptionArgument.value => "value", 
			_ => null, 
		};
	}

	private static string GetStringForExceptionResource(ExceptionResource P_0)
	{
		return P_0 switch
		{
			ExceptionResource.BeginIndexNotNegative => "BeginIndexNotNegative", 
			ExceptionResource.CountTooSmall => "CountTooSmall", 
			ExceptionResource.LengthNotNegative => "LengthNotNegative", 
			_ => null, 
		};
	}
}
