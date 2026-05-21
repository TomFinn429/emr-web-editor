using System.Diagnostics.CodeAnalysis;

namespace System.Linq;

internal static class ThrowHelper
{
	[DoesNotReturn]
	internal static void ThrowArgumentNullException(ExceptionArgument P_0)
	{
		throw new ArgumentNullException(GetArgumentString(P_0));
	}

	private static string GetArgumentString(ExceptionArgument P_0)
	{
		return P_0 switch
		{
			ExceptionArgument.collectionSelector => "collectionSelector", 
			ExceptionArgument.count => "count", 
			ExceptionArgument.elementSelector => "elementSelector", 
			ExceptionArgument.enumerable => "enumerable", 
			ExceptionArgument.first => "first", 
			ExceptionArgument.func => "func", 
			ExceptionArgument.index => "index", 
			ExceptionArgument.inner => "inner", 
			ExceptionArgument.innerKeySelector => "innerKeySelector", 
			ExceptionArgument.keySelector => "keySelector", 
			ExceptionArgument.outer => "outer", 
			ExceptionArgument.outerKeySelector => "outerKeySelector", 
			ExceptionArgument.predicate => "predicate", 
			ExceptionArgument.resultSelector => "resultSelector", 
			ExceptionArgument.second => "second", 
			ExceptionArgument.selector => "selector", 
			ExceptionArgument.source => "source", 
			ExceptionArgument.third => "third", 
			ExceptionArgument.size => "size", 
			_ => string.Empty, 
		};
	}
}
