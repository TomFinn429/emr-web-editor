using System.Collections.Generic;
using System.Text.Json.Serialization.Metadata;

namespace System.Text.Json.Serialization.Converters;

internal abstract class DictionaryDefaultConverter<TDictionary, TKey, TValue> : JsonDictionaryConverter<TDictionary, TKey, TValue> where TDictionary : IEnumerable<KeyValuePair<TKey, TValue>>
{
	internal override bool CanHaveMetadata => true;

	protected internal override bool OnWriteResume(Utf8JsonWriter P_0, TDictionary P_1, JsonSerializerOptions P_2, ref WriteStack P_3)
	{
		IEnumerator<KeyValuePair<TKey, TValue>> enumerator;
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
			enumerator = (IEnumerator<KeyValuePair<TKey, TValue>>)P_3.Current.CollectionEnumerator;
		}
		JsonTypeInfo jsonTypeInfo = P_3.Current.JsonTypeInfo;
		if (_keyConverter == null)
		{
			_keyConverter = JsonDictionaryConverter<TDictionary, TKey, TValue>.GetConverter<TKey>(jsonTypeInfo.KeyTypeInfo);
		}
		if (_valueConverter == null)
		{
			_valueConverter = JsonDictionaryConverter<TDictionary, TKey, TValue>.GetConverter<TValue>(jsonTypeInfo.ElementTypeInfo);
		}
		do
		{
			if (JsonConverter.ShouldFlush(P_0, ref P_3))
			{
				P_3.Current.CollectionEnumerator = enumerator;
				return false;
			}
			if ((int)P_3.Current.PropertyState < 2)
			{
				P_3.Current.PropertyState = StackFramePropertyState.Name;
				TKey key = enumerator.Current.Key;
				_keyConverter.WriteAsPropertyNameCore(P_0, key, P_2, P_3.Current.IsWritingExtensionDataProperty);
			}
			TValue value = enumerator.Current.Value;
			if (!_valueConverter.TryWrite(P_0, in value, P_2, ref P_3))
			{
				P_3.Current.CollectionEnumerator = enumerator;
				return false;
			}
			P_3.Current.EndDictionaryEntry();
		}
		while (enumerator.MoveNext());
		enumerator.Dispose();
		return true;
	}
}
