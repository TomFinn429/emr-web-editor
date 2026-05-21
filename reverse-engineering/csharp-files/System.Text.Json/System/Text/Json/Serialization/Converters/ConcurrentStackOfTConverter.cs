using System.Collections.Concurrent;

namespace System.Text.Json.Serialization.Converters;

internal sealed class ConcurrentStackOfTConverter<TCollection, TElement> : IEnumerableDefaultConverter<TCollection, TElement> where TCollection : ConcurrentStack<TElement>
{
	protected override void Add(in TElement P_0, ref ReadStack P_1)
	{
		((TCollection)P_1.Current.ReturnValue).Push(P_0);
	}
}
