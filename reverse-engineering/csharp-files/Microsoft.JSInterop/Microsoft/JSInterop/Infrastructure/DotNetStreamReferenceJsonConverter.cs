using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Microsoft.JSInterop.Infrastructure;

internal sealed class DotNetStreamReferenceJsonConverter : JsonConverter<DotNetStreamReference>
{
	private static readonly JsonEncodedText DotNetStreamRefKey = JsonEncodedText.Encode("__dotNetStream");

	public JSRuntime JSRuntime { get; }

	public DotNetStreamReferenceJsonConverter(JSRuntime P_0)
	{
		JSRuntime = P_0;
	}

	public override DotNetStreamReference Read(ref Utf8JsonReader P_0, Type P_1, JsonSerializerOptions P_2)
	{
		throw new NotSupportedException("DotNetStreamReference cannot be supplied from JavaScript to .NET because the stream contents have already been transferred.");
	}

	public override void Write(Utf8JsonWriter P_0, DotNetStreamReference P_1, JsonSerializerOptions P_2)
	{
		long num = JSRuntime.BeginTransmittingStream(P_1);
		P_0.WriteStartObject();
		P_0.WriteNumber(DotNetStreamRefKey, num);
		P_0.WriteEndObject();
	}
}
