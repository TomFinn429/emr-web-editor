using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization.Metadata;

namespace System.Text.Json.Serialization.Converters;

[RequiresDynamicCode("Uses Reflection to access FSharp.Core components at runtime.")]
internal sealed class FSharpTypeConverterFactory : JsonConverterFactory
{
	private ObjectConverterFactory _recordConverterFactory;

	[RequiresUnreferencedCode("Uses Reflection to access FSharp.Core components at runtime.")]
	public FSharpTypeConverterFactory()
	{
	}

	[UnconditionalSuppressMessage("ReflectionAnalysis", "IL2026:RequiresUnreferencedCode", Justification = "The ctor is marked RequiresUnreferencedCode.")]
	public override bool CanConvert(Type P_0)
	{
		if (FSharpCoreReflectionProxy.IsFSharpType(P_0))
		{
			return FSharpCoreReflectionProxy.Instance.DetectFSharpKind(P_0) != FSharpCoreReflectionProxy.FSharpKind.Unrecognized;
		}
		return false;
	}

	[UnconditionalSuppressMessage("ReflectionAnalysis", "IL2026:RequiresUnreferencedCode", Justification = "The ctor is marked RequiresUnreferencedCode.")]
	[UnconditionalSuppressMessage("ReflectionAnalysis", "IL2055:MakeGenericType", Justification = "The ctor is marked RequiresUnreferencedCode.")]
	public override JsonConverter CreateConverter(Type P_0, JsonSerializerOptions P_1)
	{
		object[] array = null;
		Type type2;
		switch (FSharpCoreReflectionProxy.Instance.DetectFSharpKind(P_0))
		{
		case FSharpCoreReflectionProxy.FSharpKind.Option:
		{
			Type type = P_0.GetGenericArguments()[0];
			type2 = typeof(FSharpOptionConverter<, >).MakeGenericType(P_0, type);
			array = new object[1] { P_1.GetConverterInternal(type) };
			break;
		}
		case FSharpCoreReflectionProxy.FSharpKind.ValueOption:
		{
			Type type = P_0.GetGenericArguments()[0];
			type2 = typeof(FSharpValueOptionConverter<, >).MakeGenericType(P_0, type);
			array = new object[1] { P_1.GetConverterInternal(type) };
			break;
		}
		case FSharpCoreReflectionProxy.FSharpKind.List:
		{
			Type type = P_0.GetGenericArguments()[0];
			type2 = typeof(FSharpListConverter<, >).MakeGenericType(P_0, type);
			break;
		}
		case FSharpCoreReflectionProxy.FSharpKind.Set:
		{
			Type type = P_0.GetGenericArguments()[0];
			type2 = typeof(FSharpSetConverter<, >).MakeGenericType(P_0, type);
			break;
		}
		case FSharpCoreReflectionProxy.FSharpKind.Map:
		{
			Type[] genericArguments = P_0.GetGenericArguments();
			Type type3 = genericArguments[0];
			Type type4 = genericArguments[1];
			type2 = typeof(FSharpMapConverter<, , >).MakeGenericType(P_0, type3, type4);
			break;
		}
		case FSharpCoreReflectionProxy.FSharpKind.Record:
		{
			ObjectConverterFactory objectConverterFactory = _recordConverterFactory ?? (_recordConverterFactory = new ObjectConverterFactory(false));
			return objectConverterFactory.CreateConverter(P_0, P_1);
		}
		case FSharpCoreReflectionProxy.FSharpKind.Union:
			throw new NotSupportedException("FSharpDiscriminatedUnionsNotSupported");
		default:
			throw new Exception();
		}
		return (JsonConverter)Activator.CreateInstance(type2, array);
	}
}
