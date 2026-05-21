using System.Collections.Generic;

namespace System.Linq;

public static class Enumerable
{
	public static bool Contains<TSource>(this IEnumerable<TSource> P_0, TSource P_1)
	{
		if (!(P_0 is ICollection<TSource> collection))
		{
			return P_0.Contains(P_1, null);
		}
		return collection.Contains(P_1);
	}

	public static bool Contains<TSource>(this IEnumerable<TSource> P_0, TSource P_1, IEqualityComparer<TSource>? P_2)
	{
		if (P_0 == null)
		{
			ThrowHelper.ThrowArgumentNullException(ExceptionArgument.source);
		}
		if (P_2 == null)
		{
			foreach (TSource item in P_0)
			{
				if (EqualityComparer<TSource>.Default.Equals(item, P_1))
				{
					return true;
				}
			}
		}
		else
		{
			foreach (TSource item2 in P_0)
			{
				if (P_2.Equals(item2, P_1))
				{
					return true;
				}
			}
		}
		return false;
	}
}
