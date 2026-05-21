using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization.Metadata;

namespace System.Text.Json.Serialization.Converters;

internal sealed class FSharpListConverter<TList, TElement> : IEnumerableDefaultConverter<TList, TElement> where TList : IEnumerable<TElement>
{
	private readonly Func<IEnumerable<TElement>, TList> _listConstructor;

	internal override bool SupportsCreateObjectDelegate => false;

	[RequiresUnreferencedCode("Uses Reflection to access FSharp.Core components at runtime.")]
	[RequiresDynamicCode("Uses Reflection to access FSharp.Core components at runtime.")]
	public FSharpListConverter()
	{
		_listConstructor = FSharpCoreReflectionProxy.Instance.CreateFSharpListConstructor<TList, TElement>();
	}

	protected override void Add(in TElement P_0, ref ReadStack P_1)
	{
		((List<TElement>)P_1.Current.ReturnValue).Add(P_0);
	}

	protected override void CreateCollection(ref Utf8JsonReader P_0, scoped ref ReadStack P_1, JsonSerializerOptions P_2)
	{
		P_1.Current.ReturnValue = new List<TElement>();
	}

	protected override void ConvertCollection(ref ReadStack P_0, JsonSerializerOptions P_1)
	{
		P_0.Current.ReturnValue = _listConstructor((List<TElement>)P_0.Current.ReturnValue);
	}
}
