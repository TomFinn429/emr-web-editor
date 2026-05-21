using System.Collections.Generic;

namespace System.Text.Json.Serialization.Converters;

internal sealed class StackOfTConverter<TCollection, TElement> : IEnumerableDefaultConverter<TCollection, TElement> where TCollection : Stack<TElement>
{
	protected override void Add(in TElement P_0, ref ReadStack P_1)
	{
		((TCollection)P_1.Current.ReturnValue).Push(P_0);
	}

	protected override void CreateCollection(ref Utf8JsonReader P_0, scoped ref ReadStack P_1, JsonSerializerOptions P_2)
	{
		if (P_1.Current.JsonTypeInfo.CreateObject == null)
		{
			ThrowHelper.ThrowNotSupportedException_SerializationNotSupported(P_1.Current.JsonTypeInfo.Type);
		}
		P_1.Current.ReturnValue = P_1.Current.JsonTypeInfo.CreateObject();
	}
}
