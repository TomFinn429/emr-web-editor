using System.Collections.Generic;

namespace System.Text.Json.Serialization.Converters;

internal sealed class ArrayConverter<TCollection, TElement> : IEnumerableDefaultConverter<TElement[], TElement>
{
	internal override bool CanHaveMetadata => false;

	internal override bool SupportsCreateObjectDelegate => false;

	protected override void Add(in TElement P_0, ref ReadStack P_1)
	{
		((List<TElement>)P_1.Current.ReturnValue).Add(P_0);
	}

	protected override void CreateCollection(ref Utf8JsonReader P_0, scoped ref ReadStack P_1, JsonSerializerOptions P_2)
	{
		P_1.Current.ReturnValue = new List<TElement>();
	}

	protected override void ConvertCollection(ref ReadStack P_0, JsonSerializerOptions P_1)
	{
		List<TElement> list = (List<TElement>)P_0.Current.ReturnValue;
		P_0.Current.ReturnValue = list.ToArray();
	}

	protected override bool OnWriteResume(Utf8JsonWriter P_0, TElement[] P_1, JsonSerializerOptions P_2, ref WriteStack P_3)
	{
		int i = P_3.Current.EnumeratorIndex;
		JsonConverter<TElement> elementConverter = JsonCollectionConverter<TElement[], TElement>.GetElementConverter(ref P_3);
		if (elementConverter.CanUseDirectReadOrWrite && !P_3.Current.NumberHandling.HasValue)
		{
			for (; i < P_1.Length; i++)
			{
				elementConverter.Write(P_0, P_1[i], P_2);
			}
		}
		else
		{
			for (; i < P_1.Length; i++)
			{
				TElement val = P_1[i];
				if (!elementConverter.TryWrite(P_0, in val, P_2, ref P_3))
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
