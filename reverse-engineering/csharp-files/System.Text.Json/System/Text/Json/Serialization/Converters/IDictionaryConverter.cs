using System.Collections;
using System.Collections.Generic;
using System.Text.Json.Serialization.Metadata;

namespace System.Text.Json.Serialization.Converters;

internal sealed class IDictionaryConverter<TDictionary> : JsonDictionaryConverter<TDictionary, string, object> where TDictionary : IDictionary
{
	protected override void Add(string P_0, in object P_1, JsonSerializerOptions P_2, ref ReadStack P_3)
	{
		TDictionary val = (TDictionary)P_3.Current.ReturnValue;
		val[P_0] = P_1;
		if (base.IsValueType)
		{
			P_3.Current.ReturnValue = val;
		}
	}

	protected override void CreateCollection(ref Utf8JsonReader P_0, scoped ref ReadStack P_1)
	{
		base.CreateCollection(ref P_0, ref P_1);
		if (((TDictionary)P_1.Current.ReturnValue).IsReadOnly)
		{
			P_1.Current.ReturnValue = null;
			ThrowHelper.ThrowNotSupportedException_CannotPopulateCollection(TypeToConvert, ref P_0, ref P_1);
		}
	}

	protected internal override bool OnWriteResume(Utf8JsonWriter P_0, TDictionary P_1, JsonSerializerOptions P_2, ref WriteStack P_3)
	{
		IDictionaryEnumerator dictionaryEnumerator;
		if (P_3.Current.CollectionEnumerator == null)
		{
			dictionaryEnumerator = P_1.GetEnumerator();
			if (!dictionaryEnumerator.MoveNext())
			{
				return true;
			}
		}
		else
		{
			dictionaryEnumerator = (IDictionaryEnumerator)P_3.Current.CollectionEnumerator;
		}
		JsonTypeInfo jsonTypeInfo = P_3.Current.JsonTypeInfo;
		if (_valueConverter == null)
		{
			_valueConverter = JsonDictionaryConverter<TDictionary, string, object>.GetConverter<object>(jsonTypeInfo.ElementTypeInfo);
		}
		do
		{
			if (JsonConverter.ShouldFlush(P_0, ref P_3))
			{
				P_3.Current.CollectionEnumerator = dictionaryEnumerator;
				return false;
			}
			if ((int)P_3.Current.PropertyState < 2)
			{
				P_3.Current.PropertyState = StackFramePropertyState.Name;
				object key = dictionaryEnumerator.Key;
				if (key is string text)
				{
					if (_keyConverter == null)
					{
						_keyConverter = JsonDictionaryConverter<TDictionary, string, object>.GetConverter<string>(jsonTypeInfo.KeyTypeInfo);
					}
					_keyConverter.WriteAsPropertyNameCore(P_0, text, P_2, P_3.Current.IsWritingExtensionDataProperty);
				}
				else
				{
					_valueConverter.WriteAsPropertyNameCore(P_0, key, P_2, P_3.Current.IsWritingExtensionDataProperty);
				}
			}
			object value = dictionaryEnumerator.Value;
			if (!_valueConverter.TryWrite(P_0, in value, P_2, ref P_3))
			{
				P_3.Current.CollectionEnumerator = dictionaryEnumerator;
				return false;
			}
			P_3.Current.EndDictionaryEntry();
		}
		while (dictionaryEnumerator.MoveNext());
		return true;
	}

	internal override void ConfigureJsonTypeInfo(JsonTypeInfo P_0, JsonSerializerOptions P_1)
	{
		if (P_0.CreateObject == null && TypeToConvert.IsAssignableFrom(typeof(Dictionary<string, object>)))
		{
			P_0.CreateObject = () => new Dictionary<string, object>();
		}
	}
}
