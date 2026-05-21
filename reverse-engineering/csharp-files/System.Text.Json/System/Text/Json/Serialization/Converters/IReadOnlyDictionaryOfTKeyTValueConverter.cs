using System.Collections.Generic;

namespace System.Text.Json.Serialization.Converters;

internal sealed class IReadOnlyDictionaryOfTKeyTValueConverter<TDictionary, TKey, TValue> : DictionaryDefaultConverter<TDictionary, TKey, TValue> where TDictionary : IReadOnlyDictionary<TKey, TValue>
{
	private readonly bool _isDeserializable = typeof(TDictionary).IsAssignableFrom(typeof(Dictionary<TKey, TValue>));

	internal override bool SupportsCreateObjectDelegate => false;

	protected override void Add(TKey P_0, in TValue P_1, JsonSerializerOptions P_2, ref ReadStack P_3)
	{
		((Dictionary<TKey, TValue>)P_3.Current.ReturnValue)[P_0] = P_1;
	}

	protected override void CreateCollection(ref Utf8JsonReader P_0, scoped ref ReadStack P_1)
	{
		if (!_isDeserializable)
		{
			ThrowHelper.ThrowNotSupportedException_CannotPopulateCollection(TypeToConvert, ref P_0, ref P_1);
		}
		P_1.Current.ReturnValue = new Dictionary<TKey, TValue>();
	}
}
