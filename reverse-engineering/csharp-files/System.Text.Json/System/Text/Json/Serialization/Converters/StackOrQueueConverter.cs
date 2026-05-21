using System.Collections;
using System.Text.Json.Serialization.Metadata;

namespace System.Text.Json.Serialization.Converters;

internal class StackOrQueueConverter<TCollection> : JsonCollectionConverter<TCollection, object> where TCollection : IEnumerable
{
	protected sealed override void Add(in object P_0, ref ReadStack P_1)
	{
		Action<TCollection, object> action = (Action<TCollection, object>)P_1.Current.JsonTypeInfo.AddMethodDelegate;
		action((TCollection)P_1.Current.ReturnValue, P_0);
	}

	protected sealed override void CreateCollection(ref Utf8JsonReader P_0, scoped ref ReadStack P_1, JsonSerializerOptions P_2)
	{
		JsonTypeInfo jsonTypeInfo = P_1.Current.JsonTypeInfo;
		Func<object> createObject = jsonTypeInfo.CreateObject;
		if (createObject == null)
		{
			ThrowHelper.ThrowNotSupportedException_CannotPopulateCollection(TypeToConvert, ref P_0, ref P_1);
		}
		P_1.Current.ReturnValue = createObject();
	}

	protected sealed override bool OnWriteResume(Utf8JsonWriter P_0, TCollection P_1, JsonSerializerOptions P_2, ref WriteStack P_3)
	{
		IEnumerator enumerator;
		if (P_3.Current.CollectionEnumerator == null)
		{
			enumerator = P_1.GetEnumerator();
			if (!enumerator.MoveNext())
			{
				return true;
			}
		}
		else
		{
			enumerator = P_3.Current.CollectionEnumerator;
		}
		JsonConverter<object> elementConverter = JsonCollectionConverter<TCollection, object>.GetElementConverter(ref P_3);
		do
		{
			if (JsonConverter.ShouldFlush(P_0, ref P_3))
			{
				P_3.Current.CollectionEnumerator = enumerator;
				return false;
			}
			if (!elementConverter.TryWrite(P_0, enumerator.Current, P_2, ref P_3))
			{
				P_3.Current.CollectionEnumerator = enumerator;
				return false;
			}
			P_3.Current.EndCollectionElement();
		}
		while (enumerator.MoveNext());
		return true;
	}
}
