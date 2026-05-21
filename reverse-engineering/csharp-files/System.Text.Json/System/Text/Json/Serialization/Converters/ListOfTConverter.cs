using System.Collections.Generic;

namespace System.Text.Json.Serialization.Converters;

internal sealed class ListOfTConverter<TCollection, TElement> : IEnumerableDefaultConverter<TCollection, TElement> where TCollection : List<TElement>
{
	protected override void Add(in TElement P_0, ref ReadStack P_1)
	{
		((TCollection)P_1.Current.ReturnValue).Add(P_0);
	}

	protected override void CreateCollection(ref Utf8JsonReader P_0, scoped ref ReadStack P_1, JsonSerializerOptions P_2)
	{
		if (P_1.Current.JsonTypeInfo.CreateObject == null)
		{
			ThrowHelper.ThrowNotSupportedException_SerializationNotSupported(P_1.Current.JsonTypeInfo.Type);
		}
		P_1.Current.ReturnValue = P_1.Current.JsonTypeInfo.CreateObject();
	}

	protected override bool OnWriteResume(Utf8JsonWriter P_0, TCollection P_1, JsonSerializerOptions P_2, ref WriteStack P_3)
	{
		int i = P_3.Current.EnumeratorIndex;
		JsonConverter<TElement> elementConverter = JsonCollectionConverter<TCollection, TElement>.GetElementConverter(ref P_3);
		if (elementConverter.CanUseDirectReadOrWrite && !P_3.Current.NumberHandling.HasValue)
		{
			for (; i < P_1.Count; i++)
			{
				elementConverter.Write(P_0, P_1[i], P_2);
			}
		}
		else
		{
			for (; i < P_1.Count; i++)
			{
				if (!elementConverter.TryWrite(P_0, P_1[i], P_2, ref P_3))
				{
					P_3.Current.EnumeratorIndex = i;
					return false;
				}
				P_3.Current.EndCollectionElement();
				if (JsonConverter.ShouldFlush(P_0, ref P_3))
				{
					i = (P_3.Current.EnumeratorIndex = i + 1);
					return false;
				}
			}
		}
		return true;
	}
}
