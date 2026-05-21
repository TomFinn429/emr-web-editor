using System.Runtime.CompilerServices;

namespace System.Text.Json.Serialization.Converters;

internal sealed class JsonMetadataServicesConverter<T> : JsonResumableConverter<T>
{
	internal JsonConverter<T> Converter
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw new NotSupportedException("Linked away");
		}
	}
}
