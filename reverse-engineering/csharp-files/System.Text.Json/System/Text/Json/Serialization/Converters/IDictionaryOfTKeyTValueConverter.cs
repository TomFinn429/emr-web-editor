using System.Collections.Generic;
using System.Text.Json.Serialization.Metadata;

namespace System.Text.Json.Serialization.Converters;

internal sealed class IDictionaryOfTKeyTValueConverter<TDictionary, TKey, TValue> : DictionaryDefaultConverter<TDictionary, TKey, TValue> where TDictionary : IDictionary<TKey, TValue>
{
	protected override void Add(TKey P_0, in TValue P_1, JsonSerializerOptions P_2, ref ReadStack P_3)
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

	internal override void ConfigureJsonTypeInfo(JsonTypeInfo P_0, JsonSerializerOptions P_1)
	{
		if (P_0.CreateObject == null && TypeToConvert.IsAssignableFrom(typeof(Dictionary<TKey, TValue>)))
		{
			P_0.CreateObject = () => new Dictionary<TKey, TValue>();
		}
	}
}
