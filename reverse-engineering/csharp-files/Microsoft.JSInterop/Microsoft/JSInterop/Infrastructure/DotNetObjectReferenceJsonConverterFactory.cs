using System;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Microsoft.JSInterop.Infrastructure;

internal sealed class DotNetObjectReferenceJsonConverterFactory : JsonConverterFactory
{
	public JSRuntime JSRuntime { get; }

	public DotNetObjectReferenceJsonConverterFactory(JSRuntime P_0)
	{
		JSRuntime = P_0;
	}

	public override bool CanConvert(Type P_0)
	{
		if (P_0.IsGenericType)
		{
			return P_0.GetGenericTypeDefinition() == typeof(DotNetObjectReference<>);
		}
		return false;
	}

	[UnconditionalSuppressMessage("Trimming", "IL2055", Justification = "We expect that types used with DotNetObjectReference are retained.")]
	public override JsonConverter CreateConverter(Type P_0, JsonSerializerOptions P_1)
	{
		Type type = P_0.GetGenericArguments()[0];
		return (JsonConverter)Activator.CreateInstance(typeof(DotNetObjectReferenceJsonConverter<>).MakeGenericType(type), JSRuntime);
	}
}
