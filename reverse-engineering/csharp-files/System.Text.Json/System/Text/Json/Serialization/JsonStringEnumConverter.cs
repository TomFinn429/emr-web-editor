using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization.Converters;

namespace System.Text.Json.Serialization;

[RequiresDynamicCode("JsonStringEnumConverter cannot be statically analyzed and requires runtime code generation. Consider authoring a custom converter that is not a factory to work around the issue. See https://github.com/dotnet/runtime/issues/73124.")]
public class JsonStringEnumConverter : JsonConverterFactory
{
	private readonly JsonNamingPolicy _namingPolicy;

	private readonly EnumConverterOptions _converterOptions;

	public JsonStringEnumConverter()
		: this(null, true)
	{
	}

	public JsonStringEnumConverter(JsonNamingPolicy? P_0 = null, bool P_1 = true)
	{
		_namingPolicy = P_0;
		_converterOptions = ((!P_1) ? EnumConverterOptions.AllowStrings : (EnumConverterOptions.AllowStrings | EnumConverterOptions.AllowNumbers));
	}

	public sealed override bool CanConvert(Type P_0)
	{
		return P_0.IsEnum;
	}

	public sealed override JsonConverter CreateConverter(Type P_0, JsonSerializerOptions P_1)
	{
		return EnumConverterFactory.Create(P_0, _converterOptions, _namingPolicy, P_1);
	}
}
