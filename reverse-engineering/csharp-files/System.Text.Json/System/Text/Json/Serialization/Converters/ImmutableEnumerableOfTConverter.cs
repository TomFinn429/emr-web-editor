using System.Collections.Generic;
using System.Text.Json.Serialization.Metadata;

namespace System.Text.Json.Serialization.Converters;

internal class ImmutableEnumerableOfTConverter<TCollection, TElement> : IEnumerableDefaultConverter<TCollection, TElement> where TCollection : IEnumerable<TElement>
{
	internal sealed override bool CanHaveMetadata => false;

	internal override bool SupportsCreateObjectDelegate => false;

	protected sealed override void Add(in TElement P_0, ref ReadStack P_1)
	{
		((List<TElement>)P_1.Current.ReturnValue).Add(P_0);
	}

	protected sealed override void CreateCollection(ref Utf8JsonReader P_0, scoped ref ReadStack P_1, JsonSerializerOptions P_2)
	{
		P_1.Current.ReturnValue = new List<TElement>();
	}

	protected sealed override void ConvertCollection(ref ReadStack P_0, JsonSerializerOptions P_1)
	{
		JsonTypeInfo jsonTypeInfo = P_0.Current.JsonTypeInfo;
		Func<IEnumerable<TElement>, TCollection> func = (Func<IEnumerable<TElement>, TCollection>)jsonTypeInfo.CreateObjectWithArgs;
		P_0.Current.ReturnValue = func((List<TElement>)P_0.Current.ReturnValue);
	}
}
