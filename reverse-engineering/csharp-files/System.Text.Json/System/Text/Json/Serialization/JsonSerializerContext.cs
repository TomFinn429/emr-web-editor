using System.Runtime.CompilerServices;
using System.Text.Json.Serialization.Metadata;

namespace System.Text.Json.Serialization;

public abstract class JsonSerializerContext : IJsonTypeInfoResolver
{
	internal bool CanUseSerializationLogic
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw new NotSupportedException("Linked away");
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	JsonTypeInfo IJsonTypeInfoResolver.GetTypeInfo(Type P_0, JsonSerializerOptions P_1)
	{
		throw new NotSupportedException("Linked away");
	}
}
