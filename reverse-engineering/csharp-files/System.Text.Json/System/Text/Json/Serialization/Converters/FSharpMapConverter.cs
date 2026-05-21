using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization.Metadata;

namespace System.Text.Json.Serialization.Converters;

internal sealed class FSharpMapConverter<TMap, TKey, TValue> : DictionaryDefaultConverter<TMap, TKey, TValue> where TMap : IEnumerable<KeyValuePair<TKey, TValue>>
{
	private readonly Func<IEnumerable<Tuple<TKey, TValue>>, TMap> _mapConstructor;

	internal override bool CanHaveMetadata => false;

	internal override bool SupportsCreateObjectDelegate => false;

	[RequiresUnreferencedCode("Uses Reflection to access FSharp.Core components at runtime.")]
	[RequiresDynamicCode("Uses Reflection to access FSharp.Core components at runtime.")]
	public FSharpMapConverter()
	{
		_mapConstructor = FSharpCoreReflectionProxy.Instance.CreateFSharpMapConstructor<TMap, TKey, TValue>();
	}

	protected override void Add(TKey P_0, in TValue P_1, JsonSerializerOptions P_2, ref ReadStack P_3)
	{
		((List<Tuple<TKey, TValue>>)P_3.Current.ReturnValue).Add(new Tuple<TKey, TValue>(P_0, P_1));
	}

	protected override void CreateCollection(ref Utf8JsonReader P_0, scoped ref ReadStack P_1)
	{
		P_1.Current.ReturnValue = new List<Tuple<TKey, TValue>>();
	}

	protected override void ConvertCollection(ref ReadStack P_0, JsonSerializerOptions P_1)
	{
		P_0.Current.ReturnValue = _mapConstructor((List<Tuple<TKey, TValue>>)P_0.Current.ReturnValue);
	}
}
