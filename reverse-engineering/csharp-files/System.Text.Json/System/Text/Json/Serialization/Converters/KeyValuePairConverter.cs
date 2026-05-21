using System.Collections.Generic;
using System.Reflection;

namespace System.Text.Json.Serialization.Converters;

internal sealed class KeyValuePairConverter<TKey, TValue> : SmallObjectWithParameterizedConstructorConverter<KeyValuePair<TKey, TValue>, TKey, TValue, object, object>
{
	private static readonly ConstructorInfo s_constructorInfo = typeof(KeyValuePair<TKey, TValue>).GetConstructor(new Type[2]
	{
		typeof(TKey),
		typeof(TValue)
	});

	public KeyValuePairConverter()
	{
		base.ConstructorInfo = s_constructorInfo;
	}
}
