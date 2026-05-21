using System.Collections.Generic;

namespace System.Text.Json.Serialization.Converters;

internal abstract class IEnumerableDefaultConverter<TCollection, TElement> : JsonCollectionConverter<TCollection, TElement> where TCollection : IEnumerable<TElement>
{
	internal override bool CanHaveMetadata => true;

	protected override bool OnWriteResume(Utf8JsonWriter P_0, TCollection P_1, JsonSerializerOptions P_2, ref WriteStack P_3)
	{
		IEnumerator<TElement> enumerator;
		if (P_3.Current.CollectionEnumerator == null)
		{
			enumerator = P_1.GetEnumerator();
			if (!enumerator.MoveNext())
			{
				enumerator.Dispose();
				return true;
			}
		}
		else
		{
			enumerator = (IEnumerator<TElement>)P_3.Current.CollectionEnumerator;
		}
		JsonConverter<TElement> elementConverter = JsonCollectionConverter<TCollection, TElement>.GetElementConverter(ref P_3);
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
		enumerator.Dispose();
		return true;
	}
}
