namespace System.Collections.Generic;

public static class CollectionExtensions
{
	public static bool TryAdd<TKey, TValue>(this IDictionary<TKey, TValue> P_0, TKey P_1, TValue P_2)
	{
		ArgumentNullException.ThrowIfNull(P_0, "dictionary");
		if (!P_0.ContainsKey(P_1))
		{
			P_0.Add(P_1, P_2);
			return true;
		}
		return false;
	}
}
