using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization.Metadata;

namespace System.Text.Json.Serialization.Converters;

internal sealed class FSharpValueOptionConverter<TValueOption, TElement> : JsonConverter<TValueOption> where TValueOption : struct, IEquatable<TValueOption>
{
	private readonly JsonConverter<TElement> _elementConverter;

	private readonly FSharpCoreReflectionProxy.StructGetter<TValueOption, TElement> _optionValueGetter;

	private readonly Func<TElement, TValueOption> _optionConstructor;

	private readonly ConverterStrategy _converterStrategy;

	internal override ConverterStrategy ConverterStrategy => _converterStrategy;

	internal override Type ElementType => typeof(TElement);

	public override bool HandleNull => true;

	[RequiresUnreferencedCode("Uses Reflection to access FSharp.Core components at runtime.")]
	[RequiresDynamicCode("Uses Reflection to access FSharp.Core components at runtime.")]
	public FSharpValueOptionConverter(JsonConverter<TElement> elementConverter)
	{
		_elementConverter = elementConverter;
		_optionValueGetter = FSharpCoreReflectionProxy.Instance.CreateFSharpValueOptionValueGetter<TValueOption, TElement>();
		_optionConstructor = FSharpCoreReflectionProxy.Instance.CreateFSharpValueOptionSomeConstructor<TValueOption, TElement>();
		_converterStrategy = elementConverter.ConverterStrategy;
		base.CanUseDirectReadOrWrite = elementConverter.CanUseDirectReadOrWrite;
		base.RequiresReadAhead = elementConverter.RequiresReadAhead;
	}

	internal override bool OnTryRead(ref Utf8JsonReader P_0, Type P_1, JsonSerializerOptions P_2, scoped ref ReadStack P_3, out TValueOption P_4)
	{
		if (!P_3.IsContinuation && P_0.TokenType == JsonTokenType.Null)
		{
			P_4 = default(TValueOption);
			return true;
		}
		P_3.Current.JsonPropertyInfo = P_3.Current.JsonTypeInfo.ElementTypeInfo.PropertyInfoForTypeInfo;
		if (_elementConverter.TryRead(ref P_0, typeof(TElement), P_2, ref P_3, out var val))
		{
			P_4 = _optionConstructor(val);
			return true;
		}
		P_4 = default(TValueOption);
		return false;
	}

	internal override bool OnTryWrite(Utf8JsonWriter P_0, TValueOption P_1, JsonSerializerOptions P_2, ref WriteStack P_3)
	{
		if (P_1.Equals(default(TValueOption)))
		{
			P_0.WriteNullValue();
			return true;
		}
		TElement val = _optionValueGetter(ref P_1);
		P_3.Current.JsonPropertyInfo = P_3.Current.JsonTypeInfo.ElementTypeInfo.PropertyInfoForTypeInfo;
		return _elementConverter.TryWrite(P_0, in val, P_2, ref P_3);
	}

	public override void Write(Utf8JsonWriter P_0, TValueOption P_1, JsonSerializerOptions P_2)
	{
		if (P_1.Equals(default(TValueOption)))
		{
			P_0.WriteNullValue();
			return;
		}
		TElement val = _optionValueGetter(ref P_1);
		_elementConverter.Write(P_0, val, P_2);
	}

	public override TValueOption Read(ref Utf8JsonReader P_0, Type P_1, JsonSerializerOptions P_2)
	{
		if (P_0.TokenType == JsonTokenType.Null)
		{
			return default(TValueOption);
		}
		TElement val = _elementConverter.Read(ref P_0, P_1, P_2);
		return _optionConstructor(val);
	}
}
