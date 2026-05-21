using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Runtime.Serialization;

namespace System.Text.Json.Serialization.Converters;

[RequiresDynamicCode("JSON serialization and deserialization might require types that cannot be statically analyzed and might need runtime code generation. Use System.Text.Json source generation for native AOT applications.")]
internal sealed class UnsupportedTypeConverterFactory : JsonConverterFactory
{
	public override bool CanConvert(Type P_0)
	{
		if (!typeof(MemberInfo).IsAssignableFrom(P_0) && !(P_0 == typeof(SerializationInfo)) && !(P_0 == typeof(nint)) && !(P_0 == typeof(nuint)))
		{
			return typeof(Delegate).IsAssignableFrom(P_0);
		}
		return true;
	}

	public override JsonConverter CreateConverter(Type P_0, JsonSerializerOptions P_1)
	{
		return (JsonConverter)Activator.CreateInstance(typeof(UnsupportedTypeConverter<>).MakeGenericType(P_0), BindingFlags.Instance | BindingFlags.Public, null, null, null);
	}
}
