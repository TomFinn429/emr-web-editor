using System.Collections.Generic;
using System.Text.Json.Serialization.Metadata;

namespace System.Text.Json.Serialization.Converters;

internal sealed class DictionaryOfTKeyTValueConverter<TCollection, TKey, TValue> : DictionaryDefaultConverter<TCollection, TKey, TValue> where TCollection : Dictionary<TKey, TValue>
{
	protected override void Add(TKey P_0, in TValue P_1, JsonSerializerOptions P_2, ref ReadStack P_3)
	{
		((TCollection)P_3.Current.ReturnValue)[P_0] = P_1;
	}

	protected internal override bool OnWriteResume(Utf8JsonWriter P_0, TCollection P_1, JsonSerializerOptions P_2, ref WriteStack P_3)
	{
		Dictionary<TKey, TValue>.Enumerator enumerator;
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
			enumerator = (Dictionary<TKey, TValue>.Enumerator)(object)P_3.Current.CollectionEnumerator;
		}
		JsonTypeInfo jsonTypeInfo = P_3.Current.JsonTypeInfo;
		if (_keyConverter == null)
		{
			_keyConverter = JsonDictionaryConverter<TCollection, TKey, TValue>.GetConverter<TKey>(jsonTypeInfo.KeyTypeInfo);
		}
		if (_valueConverter == null)
		{
			_valueConverter = JsonDictionaryConverter<TCollection, TKey, TValue>.GetConverter<TValue>(jsonTypeInfo.ElementTypeInfo);
		}
		if (!P_3.SupportContinuation && _valueConverter.CanUseDirectReadOrWrite && !P_3.Current.NumberHandling.HasValue)
		{
			do
			{
				TKey key = enumerator.Current.Key;
				_keyConverter.WriteAsPropertyNameCore(P_0, key, P_2, P_3.Current.IsWritingExtensionDataProperty);
				_valueConverter.Write(P_0, enumerator.Current.Value, P_2);
			}
			while (enumerator.MoveNext());
		}
		else
		{
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
					TKey key2 = enumerator.Current.Key;
					_keyConverter.WriteAsPropertyNameCore(P_0, key2, P_2, P_3.Current.IsWritingExtensionDataProperty);
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
		}
		enumerator.Dispose();
		return true;
	}
}
