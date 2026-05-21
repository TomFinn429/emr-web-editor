using System.Collections.Generic;

namespace System.Text.Json.Serialization.Converters;

internal class ImmutableDictionaryOfTKeyTValueConverter<TDictionary, TKey, TValue> : DictionaryDefaultConverter<TDictionary, TKey, TValue> where TDictionary : IReadOnlyDictionary<TKey, TValue>
{
	internal sealed override bool CanHaveMetadata => false;

	internal override bool SupportsCreateObjectDelegate => false;

	protected sealed override void Add(TKey P_0, in TValue P_1, JsonSerializerOptions P_2, ref ReadStack P_3)
	{
		((Dictionary<TKey, TValue>)P_3.Current.ReturnValue)[P_0] = P_1;
	}

	protected sealed override void CreateCollection(ref Utf8JsonReader P_0, scoped ref ReadStack P_1)
	{
		P_1.Current.ReturnValue = new Dictionary<TKey, TValue>();
	}

	protected sealed override void ConvertCollection(ref ReadStack P_0, JsonSerializerOptions P_1)
	{
		Func<IEnumerable<KeyValuePair<TKey, TValue>>, TDictionary> func = (Func<IEnumerable<KeyValuePair<TKey, TValue>>, TDictionary>)P_0.Current.JsonTypeInfo.CreateObjectWithArgs;
		P_0.Current.ReturnValue = func((Dictionary<TKey, TValue>)P_0.Current.ReturnValue);
	}
}
