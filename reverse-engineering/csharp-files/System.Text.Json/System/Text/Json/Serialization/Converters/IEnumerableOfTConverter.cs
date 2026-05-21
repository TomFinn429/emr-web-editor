using System.Collections.Generic;

namespace System.Text.Json.Serialization.Converters;

internal sealed class IEnumerableOfTConverter<TCollection, TElement> : IEnumerableDefaultConverter<TCollection, TElement> where TCollection : IEnumerable<TElement>
{
	private readonly bool _isDeserializable = typeof(TCollection).IsAssignableFrom(typeof(List<TElement>));

	internal override bool SupportsCreateObjectDelegate => false;

	protected override void Add(in TElement P_0, ref ReadStack P_1)
	{
		((List<TElement>)P_1.Current.ReturnValue).Add(P_0);
	}

	protected override void CreateCollection(ref Utf8JsonReader P_0, scoped ref ReadStack P_1, JsonSerializerOptions P_2)
	{
		if (!_isDeserializable)
		{
			ThrowHelper.ThrowNotSupportedException_CannotPopulateCollection(TypeToConvert, ref P_0, ref P_1);
		}
		P_1.Current.ReturnValue = new List<TElement>();
	}
}
