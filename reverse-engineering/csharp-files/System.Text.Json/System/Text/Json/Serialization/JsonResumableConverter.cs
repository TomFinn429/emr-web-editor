using System.Text.Json.Serialization.Metadata;

namespace System.Text.Json.Serialization;

internal abstract class JsonResumableConverter<T> : JsonConverter<T>
{
	public sealed override bool HandleNull => false;

	public sealed override T Read(ref Utf8JsonReader P_0, Type P_1, JsonSerializerOptions P_2)
	{
		if (P_2 == null)
		{
			ThrowHelper.ThrowArgumentNullException("options");
		}
		ReadStack readStack = default(ReadStack);
		JsonTypeInfo typeInfoInternal = P_2.GetTypeInfoInternal(P_1);
		readStack.Initialize(typeInfoInternal);
		TryRead(ref P_0, P_1, P_2, ref readStack, out var result);
		return result;
	}

	public sealed override void Write(Utf8JsonWriter P_0, T P_1, JsonSerializerOptions P_2)
	{
		if (P_2 == null)
		{
			ThrowHelper.ThrowArgumentNullException("options");
		}
		WriteStack writeStack = default(WriteStack);
		JsonTypeInfo typeInfoInternal = P_2.GetTypeInfoInternal(typeof(T));
		writeStack.Initialize(typeInfoInternal);
		try
		{
			TryWrite(P_0, in P_1, P_2, ref writeStack);
		}
		catch
		{
			writeStack.DisposePendingDisposablesOnException();
			throw;
		}
	}
}
